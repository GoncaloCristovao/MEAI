//Delcio Amorim     109680
//Gonçalo Cristovão 109041

/*
 * PWM via Output Compare no PIC32
 * OC1 — pino RD0 : saída do controlador PI   
 * OC2 — pino RD1 : saída linear temperatura  
*/

#include "pwm.h"
#include "controlador_PI.h"
#include "timer.h"

/* Parâmetros do mapeamento linear (OC2) */
#define PWM2_TEMP_MIN    40.0f   /* temperatura mínima da gama   */
#define PWM2_TEMP_MAX    66.0f   /* temperatura máxima da gama   */
#define PWM2_DUTY_MIN    10.0f   
#define PWM2_DUTY_MAX    90.0f   


void PWMInit(uint32_t freq_hz) {

    TypeBTimer16bitSetFreq(Timer2, freq_hz);

    OC1CONbits.ON     = 0;
    OC1CONbits.OCM    = 0b110;  /* PWM sem fault */
    OC1CONbits.OCTSEL = 0;      /* usa Timer2    */
    OC1RS = 0;
    OC1R  = 0;

    TRISDbits.TRISD0 = 0;       /* RD0 como saída */
    OC1CONbits.ON    = 1;

    Timer2Start();
}

/* PWMSetDuty — aplica duty cycle [0.0 ; 100.0 %] ao OC1*/
void PWMSetDuty(float duty_percent) {
    if (duty_percent < 0.0f)   duty_percent = 0.0f;
    if (duty_percent > 100.0f) duty_percent = 100.0f;
    OC1RS = (uint16_t)((duty_percent / 100.0f) * (float)(PR2 + 1));
}

/* PWM_Set_temp — calcula PI, aplica ao OC1 e devolve o duty usado*/
float PWM_Set_temp(float temperatura_atual, float temperatura_desejada) {
    float duty = controller_PI(temperatura_atual, temperatura_desejada);
    PWMSetDuty(duty);
    return duty;
}


/*  OC2 — saída linear temperatura  (pino RD1) */

void PWM2Init(void) {

    OC2CONbits.ON     = 0;
    OC2CONbits.OCM    = 0b110;   
    OC2CONbits.OCTSEL = 0;       
    OC2RS = 0;
    OC2R  = 0;

    TRISDbits.TRISD1 = 0;       /* RD1 como saída */
    OC2CONbits.ON    = 1;
}

/*  40 °C → 10 %   |   66 °C → 90 % */
float PWM2SetLinear(float temperatura,float setpoint) {

    float duty = PWM2_DUTY_MIN
               + (temperatura - PWM2_TEMP_MIN)
               * (PWM2_DUTY_MAX - PWM2_DUTY_MIN)
               / (PWM2_TEMP_MAX - PWM2_TEMP_MIN);

    /* Saturação: mantém dentro de [10 % ; 90 %] */
    if (duty < PWM2_DUTY_MIN) duty = PWM2_DUTY_MIN;
    if (duty > PWM2_DUTY_MAX) duty = PWM2_DUTY_MAX;
    if (setpoint == 0.0f) duty = 0.0f;

    /* Aplica ao OC2 — partilha PR2 com OC1 */
    OC2RS = (uint16_t)((duty / 100.0f) * (float)(PR2 + 1));

    return duty;
}