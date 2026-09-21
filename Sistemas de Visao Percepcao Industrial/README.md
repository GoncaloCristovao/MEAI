# Industrial Vision and Perception Systems (SVPI)

> **MSc in Industrial Automation Engineering** — University of Aveiro  
> **Final Practical Assessment:** **19 / 20** 

This repository brings together the engineering projects developed for the **Industrial Vision and Perception Systems** curricular unit (Department of Mechanical Engineering / DETI).

The coursework addresses the end-to-end computer vision and industrial perception stack: classical digital image processing, rotation/scale invariance algorithms, deep learning neural networks for pattern recognition, and commercial-grade automated optical inspection (AOI) systems deployed in real-time environments.

---

##  Project Overview

| Project | Platform & Tools | Core Focus | Final Grade |
| :--- | :--- | :--- | :---: |
| **[Lab 1: Game Pieces Detection & Analysis](./Trabalho_1/)** | MATLAB | Classical vision, noisy background segmentation & morphology | **20 / 20** |
| **[Lab 2: Envelope Parsing & MNIST Classification](./Trabalho_2/)** | MATLAB & Deep Learning | Color/text segmentation & OCR via Artificial Neural Networks | **19 / 20** |
| **[Lab 3: PCB Automated Optical Inspection](./Trabalho_3/)** | Teledyne DALSA Sherlock | Real-time industrial inspection of PCB traces and IC pins | **19 / 20** |

---

##  Laboratory Summaries

### 1. [Lab 1: Morphological Detection & Analysis of Game Pieces](./Trabalho_1/)
* **Objective:** Non-interactive batch processing of complex composite scenes containing domino tiles, dice faces, playing cards, and arbitrary geometric noise over textured backgrounds.
* **Key Implementations:**
  * Custom bounding-box detection and object isolation without relying on pre-packaged cropping utilities.
  * Invariant angle alignment ($0^\circ$ and $45^\circ$) and dual thresholding (handling both bright-on-dark and dark-on-bright contrast).
  * Feature extraction: domino pip counting, double-tile detection, dice pip aggregation, suit classification, and ascending card rank sorting.

### 2. [Lab 2: Envelope Postal Data Extraction & Neural Network OCR](./Trabalho_2/)
* **Objective:** End-to-end parsing of postal envelope scans: recipient identification, postage stamp matching, and handwritten ZIP code recognition via deep learning.
* **Key Implementations:**
  * Multi-colored envelope boundary isolation, orientation deskewing, and word/door number spatial segmentation.
  * Robust template and feature-based classification across 7 distinct postage stamp variants (and stamp-absent states).
  * Design, training, and integration of an **Artificial Neural Network** (ANN) to classify handwritten postal digits from the benchmark **MNIST** dataset.

### 3. [Lab 3: Automated Optical Inspection (AOI) of Printed Circuit Boards](./Trabalho_3/)
* **Objective:** Production-line quality control inspection built on the industrial standard **Teledyne DALSA Sherlock (v7.3.x)** vision platform.
* **Key Implementations:**
  * Angular auto-alignment, fiducial referencing, and corner-based OCR extraction of unit serial identifiers.
  * High-density copper track defect detection (broken traces across critical routing corridors).
  * IC pin integrity analysis: identification of missing pins, lateral bridges, misalignments, and extraneous drilled vias.

---

##  Stack & Engineering Methodologies
* **Environments & Tools:** MATLAB (Image Processing & Deep Learning Toolboxes), Teledyne DALSA Sherlock.
* **Image Processing:** Spatial filtering, adaptive binarization, morphological operators, profile projections, and template cross-correlation.
* **Machine Learning:** Feedforward Artificial Neural Networks trained on MNIST for optical character recognition.