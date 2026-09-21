# SmartPot: Closed-Loop IoT Irrigation & Soil Hydrology Management

An autonomous, cloud-connected plant management system developed as part of the **Tecnologias de Acionamento e Comando (TAC)** curriculum in the MSc in Industrial Automation Engineering at the **University of Aveiro**.

The system replaces open-loop, scheduled irrigation with a closed-loop cyber-physical pipeline. By modeling soil matrix potential hysteresis, dynamic percolation delays, and mechanical peristaltic actuation, the device balances biological safety with water conservation for moisture-sensitive species (*Spathiphyllum* / Peace Lily).

---

##  System Architecture & Data Flow

```text
 [ Soil Sensor YL-69 ] ──(Analog ADC 12-bit)──┐
                                             ▼
 [ Peristaltic Pump ] ◄──(Optocoupled Relay)── [ ESP32 Microcontroller ] ◄──(NTP Time)
                                             │               ▲
                            (Bit-banged I2C) │               │ (REST / Sockets)
                                             ▼               ▼
                                    [ LCD 16x2 Display ]   [ Google Firebase RTDB ]
                                                             │           ▲
                                                (Bi-directional Sync)    │
                                                             ▼           │
                                                 [ Mobile App (Thunkable) ]