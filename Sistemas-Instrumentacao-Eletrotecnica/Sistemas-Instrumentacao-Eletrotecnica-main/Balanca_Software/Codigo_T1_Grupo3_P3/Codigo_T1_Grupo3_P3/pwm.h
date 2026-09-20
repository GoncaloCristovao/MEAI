//Delcio Amorim     109680
//Gonçalo Cristovão 109041 
#ifndef PWM_H
#define PWM_H

#include <xc.h>
#include <stdint.h>

void    PWMInit(uint32_t freq_hz);       
void    PWMSetDuty(float duty_percent);     
void    PWMSetPeso(float peso, float peso_max);  

#endif
