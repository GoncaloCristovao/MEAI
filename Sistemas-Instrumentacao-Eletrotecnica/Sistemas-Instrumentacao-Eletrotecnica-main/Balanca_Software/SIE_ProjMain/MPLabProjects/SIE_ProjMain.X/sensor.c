#include "sensor.h"
#include "vt100.h"


uint16_t readSensor(void) {
    uint16_t sensVal;

    /* Select the ADC channel */
    ADCSelectChan(0); 
    
    /* Perform reading */
    sensVal = ADCReadRetentive();

    return sensVal;
}