//Delcio Amorim     109680
//Gonçalo Cristovão 109041

/*
 * PWM via Output Compare 1 (OC1) + Timer2 no PIC32
 *
 * Pino de saída: OC1 - pino3
 *   0g        -  18.5% duty
 *   peso_max  -  91.5% duty
 */
 
#include "pwm.h"
#include "timer.h"  
 
/*  PWMInit — configura Timer2 + OC1 em modo PWM  */
void PWMInit(uint32_t freq_hz) {
    
    TypeBTimer16bitSetFreq(Timer2, freq_hz);
    OC1CONbits.ON    = 0;
    OC1CONbits.OCM   = 0b110;  
    OC1CONbits.OCTSEL = 0;      
    OC1RS = 0;   
    OC1R  = 0;
    TRISDbits.TRISD0 = 0;
    OC1CONbits.ON = 1;
    Timer2Start();
}
 

void PWMSetDuty(float duty_percent) {
 
    if (duty_percent < 18.5f)   duty_percent = 18.5f;
    if (duty_percent > 91.5f) duty_percent = 91.5f;
 
    OC1RS = (uint16_t)((duty_percent / 100.0f) * (float)(PR2 + 1));
}

void PWMSetPeso(float peso, float peso_max) {
 
    if (peso_max <= 0.0f) return;
 
    float duty = (peso / peso_max) * 100.0f;
    PWMSetDuty(duty);
}