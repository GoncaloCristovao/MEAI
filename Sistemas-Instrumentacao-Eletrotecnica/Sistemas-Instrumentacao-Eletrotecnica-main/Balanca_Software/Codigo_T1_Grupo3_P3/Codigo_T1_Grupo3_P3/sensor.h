//Delcio Amorim     109680
//Gonçalo Cristovão 109041
#include <stdint.h>
#include "analog.h"

float readSensor(float vmin1, float vmax1,float vmin2, float vmax2,float peso_max1, float peso_max2, uint8_t *adc_range);
static float tensaoParaPeso(float tensao, float vmin, float vmax, float peso_max);
uint16_t readADCavg(uint8_t channel);
float calibrateOffset(uint8_t channel);