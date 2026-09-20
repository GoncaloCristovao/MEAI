/**! 
 * \file  mainProj.c
 * \author Pedro Fonseca <pf@ua.pt>
 *
 * \date 20 March 2025
 * 
 * \brief Main program for SIE lab projects
 * 
 * \mainpage 
 * 
 * Main part of a program to test the circuits in SIE (Sistemas de 
 * Instrumentação Eletrónica)
 * 
 * The code in main() periodically calls a function, called readSensor(),
 * which is part of the sensor module (sensor.c and sensor.h). 
 * readSensor() calls ADCReadRetentive(), that reads the ADC in a retentive
 * way (i.e., the program waits for the ADC to complete before continuing). 
 * ADCReadRetentive() returns the value in the ADC buffer (the result of the 
 * Analog to Digital conversion). readSensor() is called  at a sampling 
 * frequency SampFreq
 * 
 * On distribution, the readSensor() function simply returns the value read
 * from the ADC buffer. Students must adapt this function to properly 
 * convert the ADC readout to a value with physical meaning: 
 * - temperature, in 1/10 degrees Celsius; or
 * - weight, in grams. 
 */


#define TEMPERATURE_MODE 1
#define SCALE_MODE 0 

// Select Scale or Temperature mode
//#define SYSTEM_MODE SCALE_MODE
#define SYSTEM_MODE SCALE_MODE

/* Configuration bits */
#include "../common/config_bits.h"
#include <xc.h>
#include <stdint.h>
#include <stdio.h>

#include "../common/UART/uart.h"
#include "pic32conf.h"
#include "timer.h" 
#include "analog.h"
#include "sensor.h"
#include "vt100.h"


#define var 100


int main(void) {

    /**************************************************************
     *
     * Definition of constants 
     *
     */
    const int SampFreq = 100; /**< Sampling frequency (in Hz) */

    /************************************************************** 
     * 
     * Configuration section
     * 
     */

    /* Configure UART */
    UartInit(PBCLK_F_HZ, 9600);

//    /* Make cursor invisible */
    vt100HideCursor();
//
//    /* Clear screen */
    vt100ClearScreen();
//
//    
//    /* Move cursor to top */
    vt100MoveCursorToOrigin();

    printf("\r\n");
    printf("SIE - Projeto Balanca de Precisao\r\n");
    printf("%s, %s\r\n", __DATE__, __TIME__);

    TRISAbits.TRISA3 = 0;
    LATAbits.LATA3 = 1;

    /*
     * ADC Configuration 
     * 
     * Source: Chan 0, Source: Timer3 
     */
    //ADCconfig(0, SrcTimer3, 0);
    ADCconfig(0, SrcManual, 0);

    /*
     * Set Timer3 to run at required sampling frequency 
     */
    TypeBTimer16bitSetFreq(Timer3, SampFreq);

    /*
     * Start Timer3
     */
    Timer3Start();

    /*
     * Print the system configuration 
     *
     */
    printf("Frequencia de amostragem: %d Hz\r\n", SampFreq);
    printf("\r\n");


    /****************************************************************
     * 
     * Main cycle
     */
    
    uint16_t buffer0[var] = {0};
    uint16_t buffer1[var] = {0};
    
    int idx = 0;
    
    
    while (1) {
        
        uint16_t valor0, valor1;
        float peso0;
        float peso1;
        float voltage0;
        float voltage1;
        
        ADCSelectChan(0);
        valor0 = ADCReadManual();
        ADCSelectChan(1);
        valor1 = ADCReadManual();

        voltage0 = (valor0 * 3.3f) / 1023.0f;
        voltage1 = (valor1 * 3.3f) / 1023.0f;
        
        /*
        peso0 = (voltage0 - 0.0015f) * (280.0f / 1.91f );
        peso1 = (((voltage1 - 0.0015f) * (1200.0f / 2.42f ))*0.982f);   
        */
        
        buffer0[idx] = peso0;
        buffer1[idx] = peso1;
        
        idx = (idx + 1) % var;

        uint32_t soma0 = 0, soma1 = 0;
        for (int i = 0; i < var; i++) {
            soma0 += buffer0[i];
            soma1 += buffer1[i];
        }

        float media0 = (float)soma0 / var;
        float media1 = (float)soma1 / var;

        
//        /* Place cursor at row 6, col 6 */
        vt100PlaceCursor(6,6); 
        //vt100InverseOn();

/*
        if (media0 > 282.0f && media0 < 3000.0f) {
            printf("Massa acima de 280 g     Tensao(A0):  %.3f V", voltage0);
        }
        else {
            printf("Massa: %6.1f g          Tensao(A0):  %.3f V", media0, voltage0);
        }

        vt100PlaceCursor(8,6);
        
        if (media1 > 1205.0f  && media1 < 3000.0f) {
            printf("Massa acima de 1200 g    Tensao(A1):  %.3f V", voltage1);
        } 
        else {
            printf("Massa: %6.1f g          Tensao(A1):  %.3f V", media1, voltage1);
        }

*/

        // vt100InverseOff(); 
        
 
        /* Delete to end of line */
        vt100DeleteToEndOfLine(); 

        /* Toggle control pin at sampling frequency */
        LATAINV = 0x0008;
    }
}



