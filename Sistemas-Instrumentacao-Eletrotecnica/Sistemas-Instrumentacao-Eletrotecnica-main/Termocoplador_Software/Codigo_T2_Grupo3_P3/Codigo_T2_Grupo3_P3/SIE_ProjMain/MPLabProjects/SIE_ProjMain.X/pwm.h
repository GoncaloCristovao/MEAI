//Delcio Amorim     109680
//Gonçalo Cristovão 109041

#ifndef PWM_H
#define PWM_H

#include <stdint.h>

/*OC1 — pino RD0 : saída do controlador PI*/

 
void PWMInit(uint32_t freq_hz);
void PWMSetDuty(float duty_percent);
float PWM_Set_temp(float temperatura_atual, float temperatura_desejada);


/* OC2 — pino RD1 : saída linear temperatura
 *   40 °C -> 10 %  |  66 °C -> 90 % */

void PWM2Init(void);
float PWM2SetLinear(float temperatura,float setpoint);

#endif  