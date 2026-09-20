//Delcio Amorim     109680
//Gonçalo Cristovão 109041

#include "controlador_PI.h"

/* Parâmetros do controlador PI*/
#define PI_KP           5.0f   /* ganho proporcional           */
#define PI_TI           60.0f   /* tempo integral [s]           */
#define PI_PERIOD_S     0.1f    /* período de amostragem [s]   */
#define PI_OUT_MIN      0.0f    /* duty mínimo [%]            */
#define PI_OUT_MAX      100.0f  /* duty máximo [%]           */

/* Estado interno — static para persistir entre chamadas */
static float integral      = 0.0f;
static float erro_anterior = 0.0f;

/*   Devolve duty cycle [0.0 ; 100.0] % */
float controller_PI(float temperatura_atual, float temperatura_desejada) {

    float erro = temperatura_desejada - temperatura_atual;

    /* Componente integral   */
    integral += erro * PI_PERIOD_S;

    /* Saída do controlador PI */
    float Gc = PI_KP * erro + (PI_KP / PI_TI) * integral;

    /* Anti-windup: limita a saída e congela o integrador se saturar */
    if (Gc > PI_OUT_MAX) {
        Gc = PI_OUT_MAX;
        integral -= erro * PI_PERIOD_S;   /* cancela a última acumulação     */
    } else if (Gc < PI_OUT_MIN) {
        Gc = PI_OUT_MIN;
        integral -= erro * PI_PERIOD_S;   /* cancela a última acumulação     */
    }

    erro_anterior = erro;

    return Gc;
}

/* reinicia o estado interno do integrador */
void controller_PI_reset(void) {
    integral      = 0.0f;
    erro_anterior = 0.0f;
}