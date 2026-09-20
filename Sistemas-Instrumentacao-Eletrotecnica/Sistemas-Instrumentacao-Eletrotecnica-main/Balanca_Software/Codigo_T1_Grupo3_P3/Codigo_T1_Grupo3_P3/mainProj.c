//Delcio Amorim     109680
//Gonçalo Cristovão 109041

#define TEMPERATURE_MODE 1
#define SCALE_MODE 0 

#define SYSTEM_MODE SCALE_MODE

#include "../common/config_bits.h"
#include <xc.h>
#include <stdint.h>
#include <stdio.h>

#include "../common/UART/uart.h"
#include "pic32conf.h"
#include "timer.h" 
#include "analog.h"
#include "sensor.h"
#include "vt100.h"
#include "pwm.h"

int main(void) {
    
    const int   SampFreq  = 10;
    
    const float PESO_MAX_1 =290.0f;   /* 91.5% duty = 290g (Range 1) */
    const float PESO_MAX_2 =1040.0f;  /* 91.5% duty = 1040g (Range 2) */
    const float PWM_FREQ =1000.0f;  /* frequência PWM: 1 kHz */

    UartInit(PBCLK_F_HZ, 115200);

    vt100HideCursor();
    vt100ClearScreen();
    vt100MoveCursorToOrigin();

    printf("SIE - Balanca de Precisao\r\n");
    printf("%s, %s\r\n", __DATE__, __TIME__);
    vt100PlaceCursor(1, 50); 
    vt100BoldOn();
    printf(" G3 - Delcio & Goncalo \n\r"); 
    vt100BoldOff();

    TRISAbits.TRISA3 = 0;
    LATAbits.LATA3 = 1;

    ADCconfig(0, SrcManual, 0);

    TypeBTimer16bitSetFreq(Timer3,SampFreq);
    Timer3Start();
    
    /* PWM — OC1/RD0, 1 kHz*/
    PWMInit((uint32_t)PWM_FREQ);
    PWMSetDuty(0.0f);   /* começa a 0% */
    printf("PWM freq: %.0f Hz  (pino RD0)\r\n",PWM_FREQ);
    printf("Sampling freq: %d Hz\r\n", SampFreq);
    printf("\r\n");
    
     /* Calibração de offset*/
    float offset1 = calibrateOffset(0);
    float offset2 = calibrateOffset(1);
    vt100PlaceCursor(6, 1);
    printf("Offset canal 0: %f V\r\n", offset1);
    printf("Offset canal 1: %f V\r\n", offset2);
    //valores obtidos na pratica
    //const float vmin1 = 1.104f;   /* tensão a 0g no canal 0 (Range1) */
    //const float vmin2 = 0.516f;   /* tensão a 0g no canal 1 (Range2) */

    const float vmin1 = offset1;
    const float vmax1 = 2.62f+(offset1-1.02f);       /* tensão a 290g no canal 0 */
    const float vmin2 = offset2;
    const float vmax2 = 3.15f+(offset2-0.498f);      /* tensão a 1040g no canal 1 */

    const float peso_max1 = 290.0f;
    const float peso_max2 = 1040.0f;

    uint8_t adc_range = 0;          /* começa na gama pequena (0–290g) */
    
    vt100PlaceCursor(9, 1);
    printf("Range 1: [0 ; %.0f] g  ->  [%.3f V ; %.3f V]\r\n", peso_max1, vmin1, vmax1);
    printf("Range 2: [0 ; %.0f] g  ->  [%.3f V ; %.3f V]\r\n", peso_max2, vmin2, vmax2);
    
    vt100PlaceCursor(12, 1);
    vt100BoldOn();
    printf("    Tensao:");
    vt100BoldOff();
    
    vt100PlaceCursor(12, 28);
    vt100BoldOn();
    printf("Canal:");
    vt100BoldOff();
    
   
    vt100PlaceCursor(14, 1);
    vt100BoldOn();
    printf("    Weight:");
    vt100BoldOff();
    //-------------------------------
    vt100PlaceCursor(16, 1); 
    vt100BoldOn();
    printf("    PWM duty:"); 
    vt100BoldOff();
    
    vt100PlaceCursor(16, 28); 
    vt100BoldOn();
    printf("Current:"); 
    vt100BoldOff();

    while (1) {
        if (IFS0bits.T3IF == 1) {
            IFS0bits.T3IF = 0;
            float peso_max;
       
            float peso = readSensor(vmin1, vmax1,vmin2, vmax2,peso_max1, peso_max2,&adc_range);
            
            if(peso>290.0f){
                peso_max=PESO_MAX_2;
            }
            if(peso<=290.0f){
                peso_max=PESO_MAX_1;
            }
            PWMSetPeso(peso, peso_max);
            float duty = (peso / peso_max) * 100.0f;
            if (duty < 18.5f)   duty = 18.5f;
            if (duty > 91.5f) duty = 91.5f;
            
            int peso_int  = (int)peso;             /* parte inteira */
            int peso_dec  = (int)(peso * 10) % 10; /* 1ª casa decimal */

            /* Mostra o peso no terminal */
            vt100PlaceCursor(14, 15);
            printf("%4d.%01d", peso_int, peso_dec);
            printf(" g  ");
            
            
            /* Mostra duty no terminal */
            vt100PlaceCursor(16, 15);
            printf("%5.1f", duty);
            printf(" %%   ");
            float current=((duty*16.0f)/100.0f);
            if (duty <= 18.5f)   current = 0.0f;
            if (duty >= 91.5f)   current = 16.0f;
            vt100PlaceCursor(16, 37);   
            printf("%5.1f", current+4.0f);
            printf(" mA   "); 
            
            LATAINV = 0x0008;
        }
    }
}