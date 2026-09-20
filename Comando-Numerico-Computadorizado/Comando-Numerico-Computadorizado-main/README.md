# Computerized Numerical Control (CNC) Systems & Automation

This repository features practical engineering projects developed in Computer Numerical Control (CNC), covering mechanical assembly, control software interface design, automatic G-code generation, and advanced manual machining planning.

---

##  Project 1: Wood CNC Milling Machine Assembly & Custom UI Control

### Overview
Retrofit, mechanical assembly, and control automation of a 3-axis wood CNC milling machine. The objective was to design an intuitive human-machine interface (HMI) to streamline cut operations while offering manual positioning capabilities.

### Key Contributions & Features
- **Mechanical Assembly & Tuning:** Assembled mechanical structure, aligned axes, calibrated lead screws, and integrated end-stops.
- **Automated Parametric Cutting:** Designed a custom interface where users input dimensions to automatically generate production-ready G-code for:
  - L-shaped profiles
  - Circles / pockets
  - Rectangles
- **Manual Jog Mode:** Integrated real-time manual control allowing operators to position the spindle and perform custom cuts.
- **Media & Documentation:** 
  -  Complete project report: [View Report](./01_Wood_CNC_Milling_Machine/Report/)
  -  Real-world machining demo: `Fresadora_Madeira.mp4`

---

##  Project 2: Complex Geometry Manual G-Code Programming

### Overview
Complete manufacturing plan and precise manual G-code programming for a complex mechanical part, executed without automated CAM post-processors to achieve optimal toolpaths and surface finishing.

### Key Contributions & Features
- **Tool Selection & Strategy:** Selected optimal end mills, ball nose cutters, and drilling bits according to material properties and tolerances.
- **Operation Sequencing:** Structured roughing (desbaste), drilling cycles, and final finishing operations with precise feed rates and spindle speeds ($S$ and $F$ calculations).
- **Manual G-Code Synthesis:** Handcrafted G-code commands ($G00, G01, G02, G03$, canned cycles) minimizing cutting times and avoiding collisions.
- **Documentation:** Full calculation sheets, coordinates breakdown, and final report available in the project folder.

---

##  Tools & Technologies
- **Control & Communication:** Mach4 / CNC Controller Interfaces
- **Programming:** G-Code, Parametric Scripting
- **CAD/CAM Analysis:** Mechanical modeling & toolpath validation
- **Hardware:** 3-Axis CNC Router, Stepper Motors, Drivers, Spindle Control