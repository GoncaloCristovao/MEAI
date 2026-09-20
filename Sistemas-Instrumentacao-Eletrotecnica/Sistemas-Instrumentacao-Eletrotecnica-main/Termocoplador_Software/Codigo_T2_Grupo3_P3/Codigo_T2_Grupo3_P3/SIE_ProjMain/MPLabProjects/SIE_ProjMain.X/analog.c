/*
 * File:   analog.c
 * Author: Pedro Fonseca <pf@ua.pt>
 *
 * Date 29 January 2023, 14:31
 * 
 * Module for handling PIC32 Analog-to-Digital Converter
 * 
 */

#include <stdio.h>

#include "analog.h"

void ADCconfig(uint8_t SourceChannel,
        ADCTriggerSrc_t ConversionTriggerSource,
        uint8_t SampleTime) {

    /* Turn ADC Module off (to be on the safe side) */
    AD1CON1bits.ON = 0;

    /* A-1. Configure analog input pins 
     * 
     * All 16 pins (AN0 to AN15) configured to analog input.
     * (Write 0 to AD1PCFG)
     */
    AD1PCFGCLR = 0xFF;

    /* Select the input channel
     * 
     * Input channel is defined in parameter SourceChannel. 
     *  
     * ADC will use MUX A, with A- connected to Vref-, so all 15 channels are
     * available.
     */
    AD1CHSbits.CH0SA = SourceChannel % 16; /* %16 to be on the safe side */
    AD1CHSbits.CH0NA = 0;

    /* C-1. Select format */
    /* Format is Integer 16-bit */
    AD1CON1bits.FORM = 0;

    /* Select voltage reference source
     * Voltage sources are AVdd and AVss
     */
    AD1CON2bits.VCFG = 0;

    /* Select scan mode. 
     * No scanning of inputs 
     */
    AD1CON2bits.CSCNA = 0;

    /* Number of conversions per interrupt = 1 */
    AD1CON2bits.SMPI = 0;

    /* Buffer fill mode: one 16-word buffer */
    AD1CON2bits.BUFM = 0;

    /* Always use MUX A */
    AD1CON2bits.ALTS = 0;

    /* Select ADC Clock Source: 
     * ADC clock source is PB Clock
     */
    AD1CON3bits.ADRC = 0;

    /* Select ADC clock prescaler 
     * T_AD = 2 * T_PB(ADCS+1) */
    AD1CON3bits.ADCS = 7;

    /* Select conversion trigger source */
    AD1CON1bits.SSRC = ConversionTriggerSource;


    /* Select Sample time (for auto mode) */
    AD1CON3bits.SAMC = SampleTime;

    /* Turn ADC on */
    AD1CON1bits.ON = 1;


    switch (ConversionTriggerSource) {
        case SrcManual:
            AD1CON1bits.SAMP = 1;
            break;

        case SrcTimer3:
            AD1CON1bits.SAMP = 1;
            AD1CON1bits.ASAM = 1;
            break;

        case SrcInt0:
            // Not used
            break;

        case SrcAuto:
            // Not used
            break;
    }

}

/*
 * Turns ADC module off
 */
inline void ADCoff(void) {
    AD1CON1bits.ON = 0;
}

/*
 * Turns ADC module on
 */
inline void ADCon(void) {
    AD1CON1bits.ON = 1;
}

/*
 * Starts conversion and returns conversion value
 */
uint16_t ADCReadManual(void) {

    AD1CON1bits.SAMP = 0; /* Clear SAMP to end sampling and start conversion */

    while (!AD1CON1bits.DONE); /* Wait for End of Conversion */

    uint16_t result = (uint16_t) ADC1BUF0;
    AD1CON1bits.SAMP = 1; /* Set SAMP to start new sampling */

    return result;
}

uint16_t ADCReadRetentive(void) {

    uint16_t res = 0;

    while (!IFS1bits.AD1IF); /* Test ADC flag */
    res = ADC1BUF0;
    IFS1bits.AD1IF = 0; /* Clear ADC flag */

    return res;
}

void ADCSelectChan(uint8_t sourceChannel) {

    /* Select the input channel
     * 
     * Input channel is defined in parameter SourceChannel. 

     */
    AD1CHSbits.CH0SA = sourceChannel % 16; /* %16 to be on the safe side */
    AD1CHSbits.CH0NA = 0;
}