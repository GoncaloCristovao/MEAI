/**
 * \file vt100.h
 * 
 * Macro definitions to manage a VT100 compatible screen. 
 */

#ifndef _VT100_H    /* Guard against multiple inclusion */
#define _VT100_H


/* Provide C++ Compatibility */
#ifdef __cplusplus
extern "C" {
#endif

#include <stdio.h>
    
#define vt100HideCursor()           printf("\e[?25l")
#define vt100ClearScreen()          printf("\e[2J")
#define vt100MoveCursorToOrigin()   printf("\e[H")
#define vt100PlaceCursor(r, c)      printf("\e[%d;%dH", (r), (c))
#define vt100BoldOn()               printf("\e[1m");
#define vt100BoldOff()              printf("\e[22m");
#define vt100InverseOn()            printf("\e[7m");
#define vt100InverseOff()           printf("\e[27m");
#define vt100DeleteToEndOfLine()    printf("\e[0K");

    /* Provide C++ Compatibility */
#ifdef __cplusplus
}
#endif

#endif /* _VT100_H */
