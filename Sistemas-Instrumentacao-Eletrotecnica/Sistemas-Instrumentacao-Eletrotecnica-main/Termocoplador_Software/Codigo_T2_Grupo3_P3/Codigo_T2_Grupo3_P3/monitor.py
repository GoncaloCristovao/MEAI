 
# monitor.py — SIE G3 | Delcio & Gonçalo

import sys, os, csv, json, time, threading, re
import serial
import serial.tools.list_ports
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import matplotlib.gridspec as gridspec
import tkinter as tk
from datetime import datetime
from collections import deque

 
# CONFIGURAÇÃO
 
BAUD_RATE  = 115200
MAX_POINTS = 500000
OUTPUT_DIR = "dados"

THINGSPEAK_API_KEY = "VI6SFT63HDXFJLH3"
THINGSPEAK_URL     = "https://api.thingspeak.com/update"
CLOUD_INTERVAL_S   = 15
 
# DETEÇÃO AUTOMÁTICA DE PORTA
 
def find_port():
    ports = list(serial.tools.list_ports.comports())
    if not ports:
        return None
    for p in ports:
        desc = (p.description or "").upper()
        if any(k in desc for k in ("PIC", "USB", "FTDI", "SERIAL", "UART")):
            return p.device
    return ports[0].device

 
# BUFFERS PARTILHADOS
 
lock      = threading.Lock()
buf_time  = deque(maxlen=MAX_POINTS)
buf_temp  = deque(maxlen=MAX_POINTS)
buf_sp    = deque(maxlen=MAX_POINTS)
buf_duty  = deque(maxlen=MAX_POINTS)
buf_duty2 = deque(maxlen=MAX_POINTS)
all_rows  = []
running   = True
ser       = None
time_offset = [0.0]  # acumulador quando o PIC32 reinicia o tick
 
# ENVIO DE SETPOINT
 
def send_setpoint(val_str):
    global ser
    if ser is None or not ser.is_open:
        print("[AVISO] Porta serie nao esta aberta.")
        return
    val_str = val_str.strip()
    if not val_str:
        return
    try:
        val = int(val_str)
    except ValueError:
        print(f"[AVISO] Valor invalido: {val_str}")
        return
    ser.write((str(val) + "\n").encode("utf-8"))
    print(f"[Setpoint] Enviado: {val} C")

 
# CLOUD — ThingSpeak
 
last_cloud_send = 0.0

def send_to_cloud(temp, sp, duty, duty2):
    if not THINGSPEAK_API_KEY:
        return
    global last_cloud_send
    now = time.time()
    if now - last_cloud_send < CLOUD_INTERVAL_S:
        return
    last_cloud_send = now
    def _send():
        try:
            import requests
            params = {
                "api_key": THINGSPEAK_API_KEY,
                "field1":  round(temp,  2),
                "field2":  round(sp,    1),
                "field3":  round(duty,  1),
                "field4":  round(duty2, 1),
            }
            r = requests.get(THINGSPEAK_URL, params=params, timeout=5)
            if r.status_code == 200 and r.text != "0":
                print(f"[Cloud] OK -> entrada #{r.text}")
            else:
                print(f"[Cloud] Falhou (status={r.status_code})")
        except Exception as e:
            print(f"[Cloud] Erro: {e}")
    threading.Thread(target=_send, daemon=True).start()

 
# THREAD DE LEITURA SÉRIE
 
def serial_reader(port):
    global running, ser
    try:
        ser = serial.Serial(port, BAUD_RATE, timeout=2)
        print(f"[OK] Ligado a {port} @ {BAUD_RATE} baud")
    except serial.SerialException as e:
        print(f"[ERRO] Nao foi possivel abrir {port}: {e}")
        running = False
        return

    while running:
        try:
            raw = ser.readline().decode("utf-8", errors="ignore").strip()
        except Exception:
            continue

        # Formato PIC32: %lu.%lu,%.1f,%.2f,%.1f,%.1f
        # tempo, setpoint, temperatura, duty, duty2
        m = re.search(r'(\d+\.\d+),([\d.]+),(-?[\d.]+),(-?[\d.]+),(-?[\d.]+)', raw)
        if not m:
            continue

        try:
            t     = float(m.group(1))
            sp    = float(m.group(2))
            temp  = float(m.group(3))
            duty  = float(m.group(4))
            duty2 = float(m.group(5))
        except ValueError:
            continue

        with lock:
            # Se o tempo recuou (PIC32 fez tick=0), acumula o último valor
            if buf_time and t + time_offset[0] < buf_time[-1]:
                time_offset[0] = buf_time[-1] + 0.1
            t_real = t + time_offset[0]
            buf_time.append(t_real)
            buf_temp.append(temp)
            buf_sp.append(sp)
            buf_duty.append(duty)
            buf_duty2.append(duty2)
            all_rows.append({
                "time_s":       t,
                "setpoint":     sp,
                "temperatura":  temp,
                "duty_PI":      duty,
                "duty2_linear": duty2,
            })

        send_to_cloud(temp, sp, duty, duty2)

    ser.close()
 
# GRÁFICO
 
BG      = "#1e1e2e"
PANEL   = "#2a2a3e"
GRID    = "#44445a"
WHITE   = "#e0e0f0"
C_TEMP  = "#ff6b6b"
C_SP    = "#ffd93d"
C_DUTY  = "#4ecdc4"
C_DUTY2 = "#a29bfe"

def style_ax(ax, ylabel, title):
    ax.set_facecolor(PANEL)
    ax.tick_params(colors=WHITE, labelsize=9)
    ax.yaxis.label.set_color(WHITE)
    ax.xaxis.label.set_color(WHITE)
    ax.title.set_color(WHITE)
    ax.set_ylabel(ylabel, fontsize=10)
    ax.set_title(title, fontsize=10, pad=4)
    ax.grid(True, alpha=0.35, color=GRID)
    for s in ax.spines.values():
        s.set_edgecolor(GRID)

def setup_plot():
    fig = plt.figure(figsize=(13, 8), facecolor=BG)
    fig.suptitle(
        "SIE — Controlo de Processo Termico  |  G3 Delcio & Goncalo",
        fontsize=13, fontweight="bold", color=WHITE
    )

    gs = gridspec.GridSpec(2, 1, figure=fig, hspace=0.45)

    ax1 = fig.add_subplot(gs[0])
    ax2 = fig.add_subplot(gs[1], sharex=ax1)

    style_ax(ax1, "Temperatura (C)", "Temperatura vs Setpoint")
    style_ax(ax2, "Duty cycle (%)",  "PWM duty cycles")
    ax2.set_xlabel("Tempo (s)", fontsize=10)

    line_temp, = ax1.plot([], [], color=C_TEMP,  lw=2,   label="Temperatura (C)")
    line_sp,   = ax1.plot([], [], color=C_SP,    lw=1.5, ls="--", label="Setpoint (C)")
    ax1.legend(loc="upper left", facecolor=PANEL, labelcolor=WHITE,
               fontsize=9, framealpha=0.8)

    line_duty,  = ax2.plot([], [], color=C_DUTY,  lw=2, label="PWM duty PI (%)")
    line_duty2, = ax2.plot([], [], color=C_DUTY2, lw=2, label="PWM duty2 linear (%)")
    ax2.set_ylim(-5, 105)
    ax2.legend(loc="upper left", facecolor=PANEL, labelcolor=WHITE,
               fontsize=9, framealpha=0.8)

    info_box = ax1.text(
        0.99, 0.97, "", transform=ax1.transAxes,
        ha="right", va="top", fontsize=9, color=WHITE,
        bbox=dict(boxstyle="round,pad=0.4", facecolor=PANEL,
                  edgecolor=GRID, alpha=0.9)
    )

    return fig, ax1, ax2, line_temp, line_sp, line_duty, line_duty2, info_box

def animate(frame, ax1, ax2, lt, ls, ld, ld2, info_box):
    with lock:
        if len(buf_time) < 2:
            return
        t     = list(buf_time)
        temp  = list(buf_temp)
        sp    = list(buf_sp)
        duty  = list(buf_duty)
        duty2 = list(buf_duty2)

    lt.set_data(t, temp)
    ls.set_data(t, sp)
    ld.set_data(t, duty)
    ld2.set_data(t, duty2)

    ax1.relim(); ax1.autoscale_view()
    ax2.set_xlim(t[0], max(t[-1], t[0] + 1))

    cloud_str = "Cloud: ON" if THINGSPEAK_API_KEY else "Cloud: OFF"
    info_box.set_text(
        f"T = {temp[-1]:.1f} C  |  SP = {sp[-1]:.0f} C\n"
        f"duty = {duty[-1]:.1f}%  |  duty2 = {duty2[-1]:.1f}%\n"
        f"Amostras: {len(all_rows)}  |  {cloud_str}"
    )

 
# PAINEL DE CONTROLO — tkinter  
 
def build_control_panel():
    root = tk.Tk()
    root.title("Controlo — SIE G3")
    root.configure(bg="#1e1e2e")
    root.resizable(True, False)

    # Linha de controlo
    ctrl = tk.Frame(root, bg="#1e1e2e")
    ctrl.pack(padx=20, pady=18, fill="x")

    tk.Label(ctrl, text="Setpoint (°C):", bg="#1e1e2e", fg="#e0e0f0",
             font=("Consolas", 12)).pack(side="left", padx=(0, 8))

    sp_entry = tk.Entry(ctrl, font=("Consolas", 13), width=8,
                        bg="#2a2a3e", fg="#ffd93d",
                        insertbackground="white", relief="flat", bd=4)
    sp_entry.pack(side="left", padx=(0, 10))
    sp_entry.insert(0, "50")

    def do_send():
        send_setpoint(sp_entry.get())
        sp_entry.select_range(0, tk.END)

    def do_stop():
        send_setpoint("0")

    sp_entry.bind("<Return>", lambda e: do_send())

    tk.Button(ctrl, text="Enviar", command=do_send,
              bg="#4ecdc4", fg="#1e1e2e",
              font=("Consolas", 11, "bold"),
              relief="flat", padx=14).pack(side="left", padx=(0, 8))

    tk.Button(ctrl, text="Parar (0)", command=do_stop,
              bg="#ff6b6b", fg="#1e1e2e",
              font=("Consolas", 11, "bold"),
              relief="flat", padx=14).pack(side="left")

    # Linha de estado
    status = tk.Label(root, text="Aguarda dados...",
                      bg="#1e1e2e", fg="#a6adc8",
                      font=("Consolas", 9))
    status.pack(pady=(0, 14))

    def update_status():
        with lock:
            if buf_temp:
                t    = buf_temp[-1]
                s    = buf_sp[-1]
                d    = buf_duty[-1]
                d2   = buf_duty2[-1]
                ts   = buf_time[-1]
                status.config(
                    text=f"T={t:.1f}C  SP={s:.0f}C  duty={d:.1f}%  duty2={d2:.1f}%  t={ts:.1f}s"
                )
        root.after(500, update_status)

    update_status()
    return root
  
# GUARDAR FICHEIROS
 
def save_files():
    if not all_rows:
        print("[INFO] Sem dados para guardar.")
        return
    os.makedirs(OUTPUT_DIR, exist_ok=True)
    stamp = datetime.now().strftime("%Y%m%d_%H%M%S")

    csv_path = os.path.join(OUTPUT_DIR, f"processo_{stamp}.csv")
    with open(csv_path, "w", newline="") as f:
        writer = csv.DictWriter(f, fieldnames=all_rows[0].keys())
        writer.writeheader()
        writer.writerows(all_rows)
    print(f"[OK] CSV guardado : {csv_path}  ({len(all_rows)} amostras)")

    json_path = os.path.join(OUTPUT_DIR, f"processo_{stamp}.json")
    meta = {
        "projeto":   "SIE G3 - Controlo de Processo Termico",
        "autores":   ["Delcio Amorim 109680", "Goncalo Cristovao 109041"],
        "data":      datetime.now().isoformat(),
        "amostras":  len(all_rows),
        "duracao_s": all_rows[-1]["time_s"] if all_rows else 0,
        "dados":     all_rows,
    }
    with open(json_path, "w", encoding="utf-8") as f:
        json.dump(meta, f, indent=2, ensure_ascii=False)
    print(f"[OK] JSON guardado: {json_path}")
 
# MAIN
 
if __name__ == "__main__":
    port = sys.argv[1] if len(sys.argv) > 1 else find_port()
    if port is None:
        print("[ERRO] Nenhuma porta serie encontrada.")
        sys.exit(1)

    print(f"[INFO] Porta serie : {port}")
    print(f"[INFO] ThingSpeak  : {'ativado' if THINGSPEAK_API_KEY else 'desativado'}")
    print("[INFO] Fecha a janela do grafico para terminar e guardar os ficheiros.\n")

    # Thread de leitura UART
    t = threading.Thread(target=serial_reader, args=(port,), daemon=True)
    t.start()

    # Gráfico matplotlib em thread separada
    def run_plot():
        fig, ax1, ax2, lt, ls, ld, ld2, info_box = setup_plot()
        ani = animation.FuncAnimation(
            fig, animate,
            fargs=(ax1, ax2, lt, ls, ld, ld2, info_box),
            interval=250,
            cache_frame_data=False
        )
        plt.show()

    plot_thread = threading.Thread(target=run_plot, daemon=True)
    plot_thread.start()

    # Painel tkinter na thread principal
    root = build_control_panel()
    try:
        root.mainloop()
    except KeyboardInterrupt:
        pass
    finally:
        running = False
        print("\n[INFO] A guardar ficheiros...")
        save_files()
        print("[INFO] Terminado.")
