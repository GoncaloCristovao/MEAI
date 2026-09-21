/*
  SmartPot (Vaso Inteligente)
  Gonçalo Cristóvão - 109041
 */

#include <WiFi.h>
#include <Firebase_ESP_Client.h>
#include "time.h"
#include <Wire.h> 

// Configurações WI-FI
#define WIFI_SSID "iPhone de Gonçalo"
#define WIFI_PASSWORD "*********"

// Configurações do Projeto Firebase (Database Realtime)
#define API_KEY "AIzaSyAbL0QWgFxGON4HFWcgyJNjSY6uJFSmAAQ"
#define DATABASE_URL "https://smartpot-50b64-default-rtdb.europe-west1.firebasedatabase.app/"
#define USER_EMAIL "esp32@vaso.com"
#define USER_PASSWORD "VasoEsp"

// Bibliotecas auxiliares do Firebase para gestão de Token e Erros
#include "addons/TokenHelper.h"
#include "addons/RTDBHelper.h"

// Objetos globais para gestão da conexão
FirebaseData fbdo;
FirebaseAuth auth;
FirebaseConfig config;

// Hardware (Periféricos) e Comunicação I2C (Display LCD)
#define SDA_PIN  21
#define SCL_PIN  22
#define LCD_ADDR 0x27 // Endereço do adaptador I2C PCF8574 (Datasheet)
// A esp32 irá enviae o byte 0010 0111 (0x27), para iniciar a comunicação

const int pinoSensor = 34; // Entrada Analógica (Sensor YL-69)
const int pinoRele = 26;   // Saída Digital (Bomba de Água)  

// Parametrização:
// Calibração do Sensor (Valores obtidos experimentalmente)
// Sensores YL-69 lê valores Altos no Seco e Baixo no solo Encharcado, no Ar e na Água [4095(0%) - 0(100%)].
// Valor exprimental, através de exprimentos do sensor no solo sem planta:
const int valorSeco = 3900; // Solo Seco (0 %)  
const int valorMolhado = 1750; // Solo Encharcado (100 %)   

const int humidadeMinima = 30; // Ativação da rega
const int humidadeIdeal = 60;  // Meta de paragem (Histerese)
const int humidadeMaxima = 75; // Alerta de encharcamento
const int limiarAjuste = 50;   // Início da lógica de precisão

const int limiteRegas = 13;    // Segurança: Deteção de reservatório vazio
int contadorRegas = 0;         

// Configuração de Tempo (NTP)
const char* ntpServer = "pool.ntp.org";
const long  gmtOffset_sec = 0;       // Portugal (UTC+0)
const int   daylightOffset_sec = 0;  // horario de Iferno (-1h = 0), horario de Verão (+1h = 3600s)

// LCD (Comunicação I2C) 
// Implementação do protocolo para o adaptador PCF8574 (datasheet)
void enviarByteI2C(byte dados) {
  Wire.beginTransmission(LCD_ADDR); // inicio de comunicacação I2C, o PCF8574 responde com um bit a '0'
  Wire.write(dados | 0x08); // O bit 0x08 mantém a luz de fundo (Backlight) ligada
  Wire.endTransmission();
}

// O LCD lê os dados quando o pino 'Enable' passa de ALTO para BAIXO
void pulsoEnable(byte dados) {
  enviarByteI2C(dados | 0x04);  // Enable HIGH
  delayMicroseconds(1);         
  enviarByteI2C(dados & ~0x04); // Enable LOW (Momento da leitura)
  delayMicroseconds(50);        // Tempo de processamento do LCD
}

// Divide o byte em 2 partes, porque o LCD trabalha a 4-bits
void enviarParaLCD(byte valor, byte modo) {
  // modo 0 = Comando, modo 1 = Caracter
  byte parteAlta = valor & 0xF0;
  byte parteBaixa = (valor << 4) & 0xF0;
  pulsoEnable(parteAlta | modo);  
  pulsoEnable(parteBaixa | modo); 
}

// Funções de alto nível para usar no código principal
void lcd_command(byte cmd) { 
  enviarParaLCD(cmd, 0); 
  delay(2); 
  }
void lcd_write_char(char data) { 
  enviarParaLCD(data, 1); 
  }

void lcd_init() {
  delay(50);
  // Sequência de Reset (Datasheet)
  enviarByteI2C(0x30);
  pulsoEnable(0x30); 
  delay(5);

  enviarByteI2C(0x30); 
  pulsoEnable(0x30); 
  delay(5);

  enviarByteI2C(0x30); 
  pulsoEnable(0x30); 
  delay(1);

  enviarByteI2C(0x20); 
  pulsoEnable(0x20); // Define modo 4-bits
  
  // Configurações finais
  lcd_command(0x28); // 2 Linhas, Matriz 5x8
  lcd_command(0x0C); // Display ON, Cursor OFF
  lcd_command(0x06); // Escrever da esquerda para a direita
  lcd_command(0x01); // Limpar ecrã
  delay(5);
}

void lcd_set_cursor(int col, int row) {
  // Mapeamento de memória do LCD 16x2
  int row_offsets[] = { 0x00, 0x40, 0x14, 0x54 };
  lcd_command(0x80 | (col + row_offsets[row]));
}

void lcd_print(String text) {
  for (int i = 0; i < text.length(); i++) { 
    lcd_write_char(text[i]);
  }
}

// Funções de Dados e de Relógio: 
// Retorna apenas as horas e minutos (ex: "14:30") para o display constante
String obterHora() {
  struct tm timeinfo;
  if(!getLocalTime(&timeinfo))
  { return "--:--"; }
  char timeStringBuff[10];
  strftime(timeStringBuff, sizeof(timeStringBuff), "%H:%M", &timeinfo);
  return String(timeStringBuff);
}

// Retorna data completa para registo de eventos (ex: "1/01/2026 14:30")
String obterDataHora() {
  struct tm timeinfo;
  if(!getLocalTime(&timeinfo))
  { return "Erro NTP"; }
  char timeStringBuff[20];
  strftime(timeStringBuff, sizeof(timeStringBuff), "%d/%m/%Y %H:%M", &timeinfo);
  return String(timeStringBuff);
}

// Determina em que ficheiro do Firebase guardar os dados (dia_0 a dia_6)
// Baseado no dia da semana atual (0=Domingo, 1=Segunda, etc.)
String obterCaminhoDia() {
  struct tm timeinfo;
  if(!getLocalTime(&timeinfo))
  { 
    return "/historico/dia_0"; // Fallback se não houver relógio
    }
  return "/historico/dia_" + String(timeinfo.tm_wday);
}

// Lê o sensor, faz média de 10 leituras e converte para %
int lerSensorEstavel() {
  long soma = 0;
  for(int i=0; i<10; i++){ soma += analogRead(pinoSensor); 
  delay(10); }
  // map converte o valor analógico inverso (3900 -> 0%, 1750 -> 100%)
  // humidade = media*x + b, em que x = valorSeco-valorMolhado
  int hum = map(soma/10, valorSeco, valorMolhado, 0, 100); 
  return constrain(hum, 0, 100); // Garante que fica entre 0 e 100
}

// Display LCD:
void mostrarMonitorizacao(int humidade) {
    // Linha 0: Dados principais
  lcd_set_cursor(0, 0); 
  lcd_print("Solo:"); 
  lcd_print(String(humidade)); 
  lcd_print("%   ");// apagar os espacos, porque depois da "Rega Concluida" fica com 3 caracteres "clu"
  
  // Posiciona a hora sempre no canto direito         
  lcd_set_cursor(11, 0); 
  lcd_print(obterHora());

  // Linha 1: Estado / Diagnóstico
  lcd_set_cursor(0, 1);
  if (humidade > humidadeMaxima) {
     lcd_print("Solo Encharcado!"); 
  }
  else if (humidade >= humidadeMinima) {
     lcd_print("Saudavel :)     "); 
  } 
  else {
     lcd_print("Murcha :(       "); 
  }
}

// Inicialização do Projeto (Display)
void setup() {
  Serial.begin(115200);
  Wire.begin(SDA_PIN, SCL_PIN); 

  // Inicializa Rele (Logica Inversa: HIGH = Desligado)
  pinMode(pinoRele, OUTPUT);
  digitalWrite(pinoRele, HIGH); 

  // Inicializa LCD
  lcd_init();

  // Conexao Wi-Fi (Mostra progresso)
  lcd_set_cursor(0, 0); 
  lcd_print("A Ligar Wi-Fi...");
  
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
     delay(500); 
     Serial.print("."); 
    }
  
  lcd_set_cursor(0, 1); 
  lcd_print("Wi-Fi OK!       "); // Espacos para limpar linha
  delay(2000); // Pausa para ler "Wi-Fi OK"

  // Sincronizacao de Relogio (NTP)
  configTime(gmtOffset_sec, daylightOffset_sec, ntpServer);
  delay(2000); // Espera de 2 segundos para o NTP atualizar a hora antes de mostrar

  // Ecra de Boas-vindas com Data/Hora
  lcd_command(0x01); // Limpa o ecra
  lcd_set_cursor(0, 0); 
  lcd_print("SmartPot     ");
  lcd_set_cursor(0, 1); 
  lcd_print(obterDataHora());
  delay(3000); 

  // Ecra de Transicao
  lcd_command(0x01); 
  lcd_set_cursor(0, 0); 
  lcd_print("Monitor Humidade");
  lcd_set_cursor(0, 1); 
  lcd_print("A iniciar...    ");
  delay(2000);
  
  // Inicializacao Firebase
  config.api_key = API_KEY;
  config.database_url = DATABASE_URL;
  auth.user.email = USER_EMAIL;
  auth.user.password = USER_PASSWORD;
  
  Firebase.begin(&config, &auth);
  Firebase.reconnectWiFi(true);

  lcd_command(0x01); // Limpa o ecra para entrar no Loop
}

// Ciclo principal do Sistema
void loop() {
  int humidade = lerSensorEstavel();
  String caminhoHoje = obterCaminhoDia();

  // Segurança: Tanque Vazio
    if (contadorRegas >= limiteRegas) {
      lcd_set_cursor(0, 0); 
      lcd_print("Tanque Vazio!   ");
      lcd_set_cursor(0, 1); 
      lcd_print("Abastecer Agua  ");
      
      if (Firebase.ready()) {
          Firebase.RTDB.setString(&fbdo, "/rega/ultima", "ERRO: Tanque Vazio");
          
          // Verifica se o utilizador resetou via App (enviou 0)
          if (Firebase.RTDB.getInt(&fbdo, "/status/numero_regas")) {
             if (fbdo.intData() == 0) { 
                 contadorRegas = 0; // Reset do contador
                 lcd_command(0x01); // Limpa o aviso do ecra
                 return; // Sai do erro e volta ao funcionamento normal
             }
          }
      }
      delay(5000); // Mantem o aviso visivel por 5s antes de verificar novamente
      return;      
  }

  // Monitorização da Humidade
  mostrarMonitorizacao(humidade);

  // Lógica de Rega (Histerese com ajuste)
  if (humidade < humidadeMinima) {
      lcd_command(0x01); 
      lcd_set_cursor(0, 0); 
      lcd_print("Humidade Baixa:");
      lcd_set_cursor(0, 1); 
      lcd_print("Solo Seco!      "); 
      delay(2000); 

      bool alvoAtingido = false;
      while (humidade < humidadeIdeal) {
          if (contadorRegas >= limiteRegas) 
          break; 

          // 'long' previne overflow (int 16-bit limita a 32.767) e garante escalabilidade
          long tempoRega = 30000; // Tempo padrão (30s)
          String msgLCD = "Iniciada (30s)";
          
          if (humidade >= limiarAjuste) {
             tempoRega = 10000; // Micro-dosagem para precisão final(10s)
             msgLCD = "Iniciada (10s)";
          }

          if (Firebase.ready()) {
              lcd_command(0x01); 
              lcd_set_cursor(0, 0); 
              lcd_print("Sistema de Rega");
              lcd_set_cursor(0, 1); 
              lcd_print(msgLCD);
              
              // Define o booleano (Verdadeiro se for para micro-dose, Falso se for dose cheia)
              bool regaCurta = (humidade >= limiarAjuste); 

              // Define a mensagem com base no booleano
              String mensagemFirebase;
              if (regaCurta) {
                  mensagemFirebase = " A Regar (10s)";
              } else {
                  mensagemFirebase = " A Regar (30s)";
              }

              // Envia a mensagem limpa
              Firebase.RTDB.setString(&fbdo, "/rega/ultima", mensagemFirebase);              
              
              Firebase.RTDB.setString(&fbdo, "/historico/horaInicioRega", obterDataHora());

              digitalWrite(pinoRele, LOW); // Bomba Ligada 
              delay(tempoRega); 
              digitalWrite(pinoRele, HIGH); // Bomba Desligada

              contadorRegas++;
              Firebase.RTDB.setInt(&fbdo, "/status/numero_regas", contadorRegas);

              // Informa a App que a bomba parou e a agua esta a descer
              Firebase.RTDB.setString(&fbdo, "/rega/ultima", " Absorcao");

              // Período de Absorção (Monitorização ativa enquanto a água percola)
              for(int i = 0; i < 120; i++) { 
                  int humInst = lerSensorEstavel();
                  lcd_set_cursor(0, 0); 
                  lcd_print("Solo: "); 
                  lcd_print(String(humInst)); 
                  lcd_print("%       "); // espacos para apagar o 3 caracteres "ega" de "Sistem de Rega"
                  lcd_set_cursor(0, 1); 
                  lcd_print("Absorcao...     "); 

                  if (humInst >= humidadeIdeal) 
                  { humidade = humInst; 
                  alvoAtingido = true; 
                  break; 
                  }
                  if (i % 10 == 0 && Firebase.ready()){
                    Firebase.RTDB.setInt(&fbdo, caminhoHoje, humInst);
                  } 
                  delay(500); 
              }
              if (alvoAtingido) break;

              humidade = lerSensorEstavel();
          }
      } 
      lcd_command(0x01); 
      lcd_set_cursor(0,0); 
      lcd_print("Rega Concluida!"); 
      
      // Informa a App que o processo terminou com sucesso
      if(Firebase.ready()) {
          Firebase.RTDB.setString(&fbdo, "/rega/ultima", " Rega Concluida");
      }

      delay(2000);
  }

  // Atualização Final
  if (Firebase.ready()) {
    // Guarda o valor atual no dia correspondente (dia_0 ... dia_6)
    Firebase.RTDB.setInt(&fbdo, caminhoHoje, humidade);

    // Verifica reset remoto em funcionamento normal
    if (Firebase.RTDB.getInt(&fbdo, "/status/numero_regas")) {
       if (fbdo.intData() == 0) 
       contadorRegas = 0; // Sincronização de reset remoto
    }
  }
  delay(1000); 
}