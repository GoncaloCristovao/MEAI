#include <stdint.h>
#include "analog.h"

/**
 * Reads the sensor and returns the reading after conversion to physical 
 * quantities. 
 * For temperatures, return value is in 1/10 of degree Celsius.
 * For weighting, return value is in grams.
 * 
 * @return int sensorValue Reading of the sensor.
 */
uint16_t readSensor(void);