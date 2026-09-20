//Delcio Amorim     109680
//Gonçalo Cristovão 109041
// Canal 0 - gama [0, 290] g   Range 1
// Canal 1 - gama [0, 1040] g  Range 2
 

#include "sensor.h"
#include "analog.h"
#include "vt100.h"
#include <stdio.h>


#define ADC_AVG_SAMPLES     10      
#define ADC_WARMUP_DELAY    2000    
#define ADC_SAMPLE_DELAY    1000     

#define FILTER_ALPHA        0.05f   /* filtro exponencial - 5%*/
                               

uint16_t readADCavg(uint8_t channel) {

    /* Muda o canal e descarta a primeira leitura (canal acabou de mudar) */
    ADCSelectChan(channel);
    ADCReadManual();

    /* Pequeno delay */
    for (volatile int w = 0; w < ADC_WARMUP_DELAY; w++)
    {
        _nop();
    }
    

    uint32_t soma = 0;
    for (uint8_t i = 0; i < ADC_AVG_SAMPLES; i++) {
        soma += ADCReadManual();
        for (volatile int w = 0; w < ADC_SAMPLE_DELAY; w++)
        {
            _nop();
        }
    }

    return (uint16_t)(soma / ADC_AVG_SAMPLES);
}

static float tensaoParaPeso(float tensao, float vmin, float vmax, float peso_max) {
    if (vmax <= vmin) return 0.0f;  
    float peso = ((tensao - vmin) / (vmax - vmin)) * peso_max;
    return peso;
}

 
float readSensor(float vmin1, float vmax1,float vmin2, float vmax2,float peso_max1, float peso_max2,uint8_t *adc_range) {

    uint16_t sensVal = readADCavg(*adc_range);
    float tensao = (sensVal * 3.3f) / 1023.0f;
    vt100PlaceCursor(12, 15);
    printf("%6.3f V", tensao ); 
    vt100PlaceCursor(12, 35);
    printf("%d", *adc_range); 
    float peso   = 0.0f;

    /*  canal 0 - [0–290g] */
    if (*adc_range == 0) {

        peso = tensaoParaPeso(tensao, vmin1, vmax1, peso_max1);

        /* Sobe de gama quando peso ultrapassa o máximo do Range 1 */
        if (peso > peso_max1) {
            *adc_range = 1;
            sensVal = readADCavg(1);
            tensao  = (sensVal * 3.3f) / 1023.0f;
            peso    = tensaoParaPeso(tensao, vmin2, vmax2, peso_max2);
        }
    }

    /* canal 1 - [0–1040g] */
    else {

        peso = tensaoParaPeso(tensao, vmin2, vmax2, peso_max2);

        /*  desce de gama se bem abaixo de 290g */
        if (peso < (peso_max1 - 15.0f)) {// Histerese de 15g
            *adc_range = 0;
            sensVal = readADCavg(0);
            tensao  = (sensVal * 3.3f) / 1023.0f;
            peso    = tensaoParaPeso(tensao, vmin1, vmax1, peso_max1);
        }
    }

     
    if (peso < 0.0f)       peso = 0.0f;
    if (peso > peso_max2)  peso = peso_max2;

    /* Filtro exponencial   */
    static float peso_filtrado = 0.0f;
    peso_filtrado = (1.0f - FILTER_ALPHA) * peso_filtrado + FILTER_ALPHA * peso;

    return peso_filtrado;
}


float calibrateOffset(uint8_t channel) {
    const uint16_t samples = 100;
    uint32_t soma = 0;
     /* Pequeno delay */
    for (volatile int w = 0; w < ADC_SAMPLE_DELAY; w++){
        _nop();
    }
    for (uint16_t i = 0; i < samples; i++) {
        soma += readADCavg(channel);
    }

    float media  = (float)soma / (float)samples;
    float tensao = (media * 3.3f) / 1023.0f;

    return tensao;
}