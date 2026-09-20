//Delcio Amorim     109680
//Gonçalo Cristovão 109041

#include "../common/config_bits.h"
#include <xc.h>
#include <stdint.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#include "../common/UART/uart.h"
#include "pic32conf.h"
#include "timer.h"
#include "analog.h"
#include "sensor.h"
#include "vt100.h"
#include "pwm.h"
#include "controlador_PI.h"

#define SETPOINT_DEFAULT    0.0f   /* temperatura desejada          */
#define SETPOINT_MIN        40.0f   /* setpoint mínimo permitido       */
#define SETPOINT_MAX        66.0f   /* setpoint máximo permitido       */
#define SAMP_FREQ           10      /* frequência de amostragem       */
#define PWM_FREQ            1000.0f /* frequência PWM                 */

#define UART_BUF_SIZE   8
#define INPUT_COL       47   

static char    uart_buf[UART_BUF_SIZE];
static uint8_t uart_idx = 0;

static int uart_process(float *sp)
{
    uint8_t c;
    if (GetChar(&c) != UART_SUCCESS) return 0;

    if (c == '\r' || c == '\n') {

        uart_buf[uart_idx] = '\0';

        if (uart_idx > 0) {
            int val = atoi(uart_buf);

            if (val == 0 || (val >= (int)SETPOINT_MIN && val <= (int)SETPOINT_MAX)) {
                *sp = (float)val;
                uart_idx = 0;
                return 1;   /* novo setpoint disponível */
            } else {
                vt100PlaceCursor(19, INPUT_COL);
                printf("        ");
                vt100PlaceCursor(19, INPUT_COL);
            }
        }

        uart_idx = 0;

    } else if ((c == '\b' || c == 127) && uart_idx > 0) {
        uart_idx--;
        vt100PlaceCursor(19, INPUT_COL + uart_idx);
        PutChar(' ');
        vt100PlaceCursor(19, INPUT_COL + uart_idx);

    } else if (uart_idx < UART_BUF_SIZE - 1 && c >= '0' && c <= '9') {
        vt100PlaceCursor(19, INPUT_COL + uart_idx);
        PutChar(c);
        uart_buf[uart_idx++] = c;
    }

    return 0;
}


int main(void) {

    /* --- Inicializações --- */
    UartInit(PBCLK_F_HZ, 115200);

    vt100HideCursor();
    vt100ClearScreen();
    vt100MoveCursorToOrigin();

    printf("SIE - Controlo de um Processo Termico\r\n");
    printf("%s, %s\r\n", __DATE__, __TIME__);
    vt100PlaceCursor(1, 50);
    vt100BoldOn();
    printf("G3 - Delcio & Goncalo\r\n");
    vt100BoldOff();

    /* LED de estado — RA3 */
    TRISAbits.TRISA3 = 0;
    LATAbits.LATA3   = 1;

    /* ADC — canal 0 (termopar) e canal 1 (termístor) */
    ADCconfig(0, SrcManual, 0);

    /* Timer3*/
    TypeBTimer16bitSetFreq(Timer3, SAMP_FREQ);
    Timer3Start();

    /* PWM — OC1 RD0 a 1 kHz; começa desligado */
    PWMInit((uint32_t)PWM_FREQ);
    PWMSetDuty(0.0f);

    /* PWM2 — OC2 RD1 saída linear temperatura (partilha Timer2 com OC1) */
    PWM2Init();

    /* Reinicia estado do PI */
    controller_PI_reset();


     /* Calibração de offset*/

    printf("\r\nA calibrar offset (resistencia desligada)...\r\n");

    float tensao_offset   = calibrateOffset(0);
    float temp_ambiente   = read_Termistor(1);
    float offset_termopar = tensao_offset - 0.757f;

    vt100PlaceCursor(6, 1);
    printf("Calibracao: Voffset = %.4f V  (desvio = %.4f V)\r\n",
           tensao_offset, offset_termopar);
    printf("T. ambiente (termistor): %.2f C\r\n", temp_ambiente);

    /* --- Variáveis de controlo --- */
    float setpoint = SETPOINT_DEFAULT;
    float temp_min =  999.0f;
    float temp_max = -999.0f;
    uint32_t tick = 0;

    /* --- Cabeçalhos fixos do display --- */
    vt100PlaceCursor(9, 1);
    vt100BoldOn();  printf("--- Leituras em tempo real ---");  vt100BoldOff();

    vt100PlaceCursor(14, 30);
    vt100BoldOn();  printf("Setpoint     :");  vt100BoldOff();
    vt100PlaceCursor(14, 47);
    printf("%.0f C", setpoint);

    vt100PlaceCursor(15, 1);
    vt100BoldOn();  printf("Temp. min    :");  vt100BoldOff();

    vt100PlaceCursor(15, 30);
    vt100BoldOn();  printf("Temp. max    :");  vt100BoldOff();

    vt100PlaceCursor(16, 1);
    vt100BoldOn();  printf("PWM duty     :");  vt100BoldOff();
    vt100PlaceCursor(19, 1);
    printf("-> Setpoint (0 para parar | %d-%d C) + Enter: ", (int)SETPOINT_MIN, (int)SETPOINT_MAX);


    while (1) {

        /* Verifica UART se tem novo setpoint*/
    
        float novo_sp;
        if (uart_process(&novo_sp)) {

            setpoint = novo_sp;
            controller_PI_reset(); 

      
            vt100PlaceCursor(14, 46);
            if (setpoint == 0.0f) {
                printf("PARADO      ");
                PWMSetDuty(0.0f);
            } else {
                printf("%.0f C       ", setpoint);
            }

            /* Reseta min/max e tick para este novo teste de setpoint */
            temp_min =  999.0f;
            temp_max = -999.0f;
            tick     = 0;
            vt100PlaceCursor(15, 16);
            printf("---     ");
            vt100PlaceCursor(15, 46);
            printf("---     ");

           
            vt100PlaceCursor(19, INPUT_COL);
            printf("        ");
            vt100PlaceCursor(19, INPUT_COL);
        
        }

        if (IFS0bits.T3IF == 1) {
            IFS0bits.T3IF = 0;

            /* temperatura */
            float temperatura_atual = ReadTemperature(offset_termopar);

            /* Mínimo e máximo históricos */
            if (temperatura_atual < temp_min) {
                temp_min = temperatura_atual;
                vt100PlaceCursor(15, 16);
                printf(" %d C   ", (int)(temp_min + 0.5f));
            }
            if (temperatura_atual > temp_max) {
                temp_max = temperatura_atual;
                vt100PlaceCursor(15, 46);
                printf("%d C   ", (int)(temp_max + 0.5f));
            }

            /*Controlador PI*/
            float duty;
            if (setpoint == 0.0f) {
                duty = 0.0f;
                PWMSetDuty(0.0f);
            } else {
                duty = PWM_Set_temp(temperatura_atual, setpoint);
            }

            /*Saída linear OC2/RD1 */
            float duty2 = PWM2SetLinear(temperatura_atual,setpoint);

            /*Display duty */
            vt100PlaceCursor(16, 16);
            printf("%5.1f %%   ", duty);
            vt100PlaceCursor(17, 1);
            vt100BoldOn();
            printf("PWM duty2    :");
            vt100BoldOff();
            vt100PlaceCursor(17, 16);
            printf("%5.1f %%   ", duty2);

            /*Envia linha CSV*/
            {
                uint32_t t_s = tick / 10u;
                uint32_t t_d = tick % 10u;
                tick++;
                printf("%lu.%lu,%.1f,%.2f,%.1f,%.1f\r\n",
                       (unsigned long)t_s, (unsigned long)t_d,
                       setpoint, temperatura_atual, duty, duty2);
            }

            /*Reposiciona cursor no campo de input */
            vt100PlaceCursor(19, INPUT_COL + uart_idx);

            LATAINV = 0x0008;
        }
    }
}