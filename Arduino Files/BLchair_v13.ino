#include <RTClib.h>
//#include <SoftwareSerial.h>
#include <SD.h>

#define sittingSensorPin A0

#define powerLedPin 7
#define ledPin 4
#define piezoPin 6
#define switchPin 5

bool isConnected = false;

byte echoByte = 0x61;
byte dataSendingByte =  0x62;
byte yearDataSendingByte = 0x63;
byte alertSendingByte = 0x64;

// Timere pentru asigurarea conexiunii
long lastConnSendTimer = 0;
long lastConnRecvTimer = 0;

// Switch button
int switchState = 0;
int previousSwitchState = 0;
int switchMode = 0;
long pushButtonTimer = 0;

// Variabilele senzorilor
int    sensorArrayPins[]       = {A1    , A2    , A3    };
bool   sensorArrayFlags[]      = {false , false , false };
String sensorArrayOnMessage[]  = {"*DDON", "*ULON", "*URON"};
String sensorArrayOffMessage[] = {"*DDOF", "*ULOF", "*UROF"};

//piezo
bool timerStarted = false;
bool alarmStarted = false;
long lastPiezoTimer = 0;

RTC_DS1307 rtc;

#include "Statistics.h"
#include "BLON_Methods.h"
#include "BLOFF_Methods.h"

void setup() 
{
  pinMode(piezoPin, OUTPUT);
  noTone(piezoPin);
  pinMode(switchPin, INPUT);
  pinMode(ledPin, OUTPUT);
  pinMode(powerLedPin, OUTPUT);
  digitalWrite(ledPin, LOW);
  digitalWrite(powerLedPin, HIGH);

  for (int i = 0; i < 3; i++) 
  {
    pinMode(sensorArrayPins[i], INPUT);
  }
  pinMode(A8, INPUT);
  pinMode(A9, INPUT);
  
  Serial2.begin(38400);
  Serial.begin(115200);
  while (!SD.begin(53)) { Serial.println("Cant open SD"); }
  while (!rtc.begin()) { Serial.println("Cant open rtc"); }

  rtc.adjust(DateTime(__DATE__, __TIME__));
  DateTime time = rtc.now();
  Serial.println(time.year());
  Serial.println(time.month());
  Serial.println(time.day());
  Statistics::cleanUp();
}

void loop() {

  Mode0::checkSwitch();

  if (switchMode == 1) // Modul bluetooth
  {
    digitalWrite(ledPin, HIGH);

    while (isConnected == false && switchMode == 1)
      Mode1::waitingToConnect();  //Loop infinit pana la primirea raspunsului de la calculator

    // ++++++++++++++++++++++++++++ SCAUN CONECTAT ++++++++++++++++++++++++++++

    if (analogRead(sittingSensorPin) < 400 && switchMode == 1) // Daca persoana nu se afla pe scaun
      Mode1::waitingToSit();                                   // Loop infinit pana se aseaza

    // ++++++++++++++++++++++++++++ PERSOANA ASEZATA +++++++++++++++++++++++++

    if (isConnected == true)
    {
      Mode1::sensorRead();
      Statistics::gatherData();
      Mode1::checkConnection();
      
    }

  }
  else if (switchMode == 0) // Modul fara bluetooth
  {
    digitalWrite(ledPin, LOW);

    if (analogRead(sittingSensorPin) < 400)
      Mode0::waitingToSit();

    // ++++++++++++++++++++++++++++ PERSOANA ASEZATA +++++++++++++++++++++++++

    Mode0::checkSwitch();

    if (switchMode == 0)
    {
      Mode0::sensorRead();
      Mode0::alarmControl();
      Statistics::gatherData();
    }
  }

}
