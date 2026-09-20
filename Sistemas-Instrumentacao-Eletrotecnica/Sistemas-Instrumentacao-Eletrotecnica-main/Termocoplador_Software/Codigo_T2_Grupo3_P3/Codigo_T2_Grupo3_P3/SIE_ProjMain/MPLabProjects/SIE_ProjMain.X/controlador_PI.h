//Delcio Amorim     109680
//Gonçalo Cristovão 109041
#ifndef CONTROLADOR_PI_H
#define CONTROLADOR_PI_H

#include <stdint.h>

float controller_PI(float temperatura_atual, float temperatura_desejada);


void controller_PI_reset(void);

#endif 