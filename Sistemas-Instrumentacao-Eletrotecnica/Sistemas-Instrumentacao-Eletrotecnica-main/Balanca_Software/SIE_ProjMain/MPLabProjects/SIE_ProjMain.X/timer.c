/*
 * File:   timer.c
 * Author: Pedro Fonseca <pf@ua.pt>
 *
 * Date 26 January 2023, 17:22
 * 
 * Module to handle timers in PIC32
 * 
 */

#include "timer.h"
#include <assert.h>
#include <stdio.h>

 const uint8_t OK = 0;
 const uint8_t NOK = 1;

const uint32_t TypeBTimerPreScalerVals[] = {1, 2, 4, 8, 16, 32, 64, 256};

/*
 * Starts Timer 2.
 * 
 */
inline void Timer2Start(void) {
    T2CONbits.ON = 1;
}

/*
 * Stops Timer 2
 */
inline void Timer2Stop(void) {
    T2CONbits.ON = 0;
}

/*
 * Gets EOC flag from Timer2
 */
inline int Timer2GetEOC(void) {
    return IFS0bits.T2IF;
}

/*
 * Clears EOC flag of Timer2
 */
inline void Timer2ClearEOC(void) {
    IFS0bits.T2IF = 0;
}

/*
 * Configures Timer2
 */
void Timer2Setup(bool TimerOn32bit, TypeBTimerPreScalers_t Prescaler, uint32_t PR2val) {

    /* If timer is running on 16bit, the Prescaler value must fit in a 16 bit value */
    assert(TimerOn32bit || PR2val <= 0xFFFFL);

    /* Stop the timer */
    Timer2Stop();

    /* Clears interrupt flag */
    Timer2ClearEOC();

    /* Set timer mode */
    if (TimerOn32bit) {
        T2CONbits.T32 = 1;
    } else {
        T2CONbits.T32 = 0;
        PR2val &= 0xFFFFL;
    }

    /* Configure TGATE and TCS so that CLK source is PBCLK */
    T2CONbits.TGATE = 0;
    T2CONbits.TCS = 0;

    /* Set Prescaler and PR2 */
    /* For the Prescaler, Note that the sequence of values in the enum 
     * and the position in the sequence corresponds to the bit value 
     * to be written to TCKPS */
    T2CONbits.TCKPS = Prescaler;

    PR2 = PR2val;
}

/*
 * Configures Timer3
 */
void Timer3Setup(TypeBTimerPreScalers_t Prescaler, uint32_t PR3val) {

    /* If timer is running on 16bit, the Prescaler must fit in a 16 bit register */
    assert(PR3val <= 0xFFFFL);

    /* Stop the timer */
    Timer3Stop();

    /* Clears interrupt flag */
    Timer3ClearEOC();

    /* Configure TGATE and TCS so that CLK source is PBCLK */
    T3CONbits.TGATE = 0;
    T3CONbits.TCS = 0;

    /* Set Prescaler and PR2 */
    /* For the Prescaler, Note that the sequence of values in the enum 
     * and the position in the sequence corresponds to the bit value 
     * to be written to TCKPS */
    T3CONbits.TCKPS = Prescaler;

    PR3 = PR3val;
}

/*
 * Gets EOC flag from Timer2
 */
int Timer3GetEOC(void) {
    return IFS0bits.T3IF;
}

/*
 * Clears EOC flag of Timer3
 */
inline void Timer3ClearEOC(void) {
    IFS0bits.T3IF = 0;
}

/*
 * Starts Timer 3.
 */
inline void Timer3Start(void) {
    T3CONbits.ON = 1;
}

/*
 * Stops Timer 3
 */
inline void Timer3Stop(void) {
    T3CONbits.ON = 0;
}

/*
 * Gets the PreScaler and PR3Val necessary to generate a EOC frequency on Timer3
 * running with a PB Clock of PB_CLK_F_HZ (in Hz)
 * 
 * @param Freq_Hz           Desired frequency, in Hz
 * @param pPreScaler        PreScaler value (pointer to)
 * @param pPRxVal           PR3 value (pointer to)
 * @return                  0 if success; !=0, otherwise 
 */
int TypeBTimer16bitGetConfigFromFreq(uint32_t Freq_Hz, TypeBTimerPreScalers_t *pPreScaler, uint32_t *pPRxVal) {
    /* Check input values*/
    if (*pPreScaler > 7) {
        return NOK;
    }
    uint32_t PRxval_tent; /* Tentative value for PRx */
    int i;

    /* The program will start with the smallest value for the prescaler, and 
     * then increase until a suitable value for PR3 is found (suitable means
     * fitting in a 16-bit wide register 
     */
    for (i = 0; i < 8; i++) {
        PRxval_tent = PBCLK_F_HZ / (Freq_Hz * TypeBTimerPreScalerVals[i]);
        if (PRxval_tent < 0x10000 && PRxval_tent > 0) {
            /* PRxval fits in 16bit register */
            break;
        }
    }

    if (i < 8) {
        /* Values are OK; found possible values for the config parameters */

        *pPRxVal = PRxval_tent;
        *pPreScaler = i;
        return OK;
    } else {
        /* Search in tne for() cycle when until the end with no suitable value found */
        return NOK;
    }
}

/*
 * Sets the counting frequency of a Type B Timer
 * 
 * If the requested frequency is not possible, the Timer registers are not 
 * changed and the function returns NOK. When the requested frequency is possible,
 * the Timer<i>x</i> (*x*=2..5) registers are set accordingly and the function 
 * returns OK. 
 * 
 * @param Freq_Hz   Requested frequency (in Hz)
 * \return          OK: sucess; NOK: failure
 */
int TypeBTimer16bitSetFreq(TypeBTimerNo_t TimerNo, uint32_t Freq_Hz) {

    TypeBTimerPreScalers_t PreScaler=0;
    uint32_t PRxVal=0;
    int result;

    result = TypeBTimer16bitGetConfigFromFreq(Freq_Hz, &PreScaler, &PRxVal);
    
    if (result == OK) {
        switch (TimerNo) {
            case Timer2:
                Timer2Setup(false, PreScaler, PRxVal);
                break;
            case Timer3:
                Timer3Setup(PreScaler, PRxVal);
                break;
            default:
                result = NOK;
                break;
        }

    }
    return result;
}