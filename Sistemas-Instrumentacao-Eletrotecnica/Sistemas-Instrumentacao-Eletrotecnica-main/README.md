# Electrical Instrumentation & Measurement Systems (SIE)

This repository contains circuit designs, analog signal conditioning stages, and embedded firmware developed for the **Sistemas de Instrumentação Eletrotécnica** curricular unit. Complete circuit justifications, operational amplifier selection, passive filter calculations, and calibration models are thoroughly documented in the accompanying project reports.

---

##  Project 1: Digital Precision Scale (Load Cell & Signal Conditioning)

### Overview
Development of a digital scale based on strain gauges in a Wheatstone bridge topology, covering low-noise analog conditioning, multi-stage filtering, and firmware for mass acquisition.

### Key Contributions & Features
- **Analog Front-End & Hardware Design:**
  - Wheatstone bridge interfacing with strain gauge load sensors.
  - Dedicated instrumentation amplifier configuration designed for high Common-Mode Rejection Ratio (CMRR) and low DC drift.
  - Active/passive low-pass filtering to attenuate high-frequency environmental and mains noise.
- **Embedded Software & Processing:**
  - High-resolution ADC acquisition with moving-average digital filtering to mitigate mechanical oscillations.
  - Linear regression calibration translating raw differential voltages into mass ($g$).
  - Tare routine and serial/telemetry output.
- **Documentation:** Full component dimensioning, filtering stage Bode responses, and error analysis available in the folder report.

---

##  Project 2: K-Type Thermocouple Interface & Closed-Loop Temperature Control

### Overview
Design of a complete thermal acquisition node and closed-loop temperature control system using a K-Type thermocouple and a power resistor as the heating plant.

### Key Contributions & Features
- **Cold-Junction Compensation (CJC) via Thermistor:**
  - Implemented CJC using a reference NTC thermistor to measure local ambient temperature.
  - Real-time arithmetic compensation matching the thermocouple Seebeck coefficient with ambient drift.
- **Signal Conditioning & Plant Actuation:**
  - Microvolt-level analog front-end with precision amplification and tailored filtering stages.
  - Actuation of a power resistor acting as the thermal heating element.
- **Closed-Loop Control & Firmware:**
  - Firmware loop reading both sensor points (ambient reference vs. hot junction).
  - Feedback control algorithm regulating resistor power to maintain the target temperature setpoint.
- **Documentation:** Circuit schematics, thermal transient responses, amplifier choice justification, and control loop parameters documented in the final report.

---

##  Tools, Hardware & Technologies
- **Embedded Platform:** Microchip Microcontrollers (PIC32 / XC32 toolchain)
- **Programming Language:** Embedded C
- **Hardware & Sensors:**
  - K-Type Thermocouple, Precision NTC Thermistor, Strain Gauges
  - Power Resistors (thermal actuator), Instrumentation & Operational Amplifiers
  - Passive RC and active analog filters
- **Laboratory Equipment:** Digital Storage Oscilloscopes, Precision DMMs, Bench DC Power Supplies
