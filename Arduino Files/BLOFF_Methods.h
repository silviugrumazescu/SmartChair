class Mode0{
  
  public:
    
    static void checkSwitch()
    {
      switchState = digitalRead(switchPin);

      if(switchState != previousSwitchState && switchState == LOW)
      {
        switchMode = !switchMode;
        if(switchMode == 1){
            noTone(piezoPin);
            isConnected = false;
            Statistics::cleanUp(); // Pentru a se adauga secundele state pe scaun
            Serial.println("Changed to mode 1 function 0");
        }
        else
        {   
          if(isConnected == true)
            Serial2.print("*BOFF");
          isConnected = false;
          Statistics::cleanUp();
          Serial.println("Changed to mode 0 function 0");
        }
      }
      else if(switchState == HIGH)
      {
          if(previousSwitchState == LOW)
          {
            pushButtonTimer = millis();  
          }
          else if(millis() - pushButtonTimer > 3000) // Entering calibration mode ==============
          {
            if(isConnected == true)
            {
              Serial2.println("*CALI");
            }
            Statistics::cleanUp();
            alarmStarted = false; // pentru cazul in care calibram in timp ce suna alarma
            timerStarted = false; // - || -
            switchState = LOW; // Pentru a nu se schimba modul de functionare
            int maxS1Value = 0;
            int maxS2Value = 0;
            Serial.println("entered calibration mode");
            pushButtonTimer = millis();
            while(millis() - pushButtonTimer < 7000)
            {
                calibrationPiezoAlarm(pushButtonTimer);
                if(analogRead(A2) > maxS1Value)
                {
                  maxS1Value = analogRead(A2);  
                }
                if(analogRead(A8) > maxS2Value)
                {
                  maxS2Value = analogRead(A8);  
                }
            }
            noTone(piezoPin);
            if(maxS1Value > maxS2Value)
            {
              sensorArrayPins[1] = A2;
              sensorArrayPins[2] = A3;
              Serial.println("Series 1 sensors activated");
            }
            else
            {
              sensorArrayPins[1] = A8;
              sensorArrayPins[2] = A9;  
              Serial.println("Series 2 sensors activated");
            }
            pushButtonTimer = 0;
            Serial.println("exited calibration mode");  
            for (int i = 0; i < 3; i++)
            {
              if(analogRead(sensorArrayPins[i]) > 400)
              {
                if(switchMode == 1)
                  Serial2.print(sensorArrayOnMessage[i]);
                else
                  sensorArrayFlags[i] = true;
              }
              if(analogRead(sensorArrayPins[i]) < 400)
              {
                if(switchMode == 1)
                  Serial2.print(sensorArrayOffMessage[i]);
                else
                  sensorArrayFlags[i] = false;
              }
              if(sensorArrayPins[i] == A9)
              {
                // sensozurl A9 nu exista
                if(switchMode == 1)
                  Serial2.print(sensorArrayOnMessage[i]);
                else
                  sensorArrayFlags[i] = true;
              }
            }
          }
          
      }
      previousSwitchState = switchState;
    }

    static void calibrationPiezoAlarm(long startingMillis)
    {
        int counter = (startingMillis - millis()) / 250;
        if(counter % 2 == 1)
          tone(piezoPin, 2000); 
        else
          noTone(piezoPin);
    }
    
    static void waitingToSit()
    {
        
        noTone(piezoPin);
        while(analogRead(sittingSensorPin) < 400 && switchMode == 0) 
        { 
            checkSwitch(); 
            Statistics::gatherData(); 
        }                     
        Statistics::cleanUp();
       // --------- Verificam starea actuala a sensorilor -------------
        if(switchMode == 0)
        {
          lastPiezoTimer = millis(); //resetam timerul cand persoane vine pe scaun
          alarmStarted = false;
          for (int i = 0; i < 3; i++)
          {
              if(analogRead(sensorArrayPins[i]) > 400)
                sensorArrayFlags[i] = true;
              else
                sensorArrayFlags[i] = false; 
              
              if(sensorArrayPins[i] == A9) // sensozurl A9 nu exista
              {
                if(switchMode == 1) 
                    Serial2.print(sensorArrayOnMessage[i]);
                else
                    sensorArrayFlags[i] = true;
              }
           }
        }
    }
      
    static void sensorRead()
    {
        for (int i = 0; i < 3; i++)
        {
            if(analogRead(sensorArrayPins[i]) > 400 && sensorArrayFlags[i] == false) {
              sensorArrayFlags[i] = true;
            }
            if(analogRead(sensorArrayPins[i]) < 400 && sensorArrayFlags[i] == true) {
              sensorArrayFlags[i] = false;
            }

            if(sensorArrayPins[i] == A9) // sensozurl A9 nu exista
            {
              if(switchMode == 1) 
                 Serial2.print(sensorArrayOnMessage[i]);
              else
                 sensorArrayFlags[i] = true;
            }
        }
    }
    
    static void alarmControl()
    {
      
      if(sensorArrayFlags[0] == false || sensorArrayFlags[1] == false || sensorArrayFlags[2] == false) // Daca unul dintre senzori este pe rosu
      { 
        if(timerStarted == false)// Si timerul nu este pornit
        { 
          timerStarted = true;
          lastPiezoTimer = millis();
        }
      }
      else if(timerStarted == true) // Daca toti senzorii sunt pe verde - oprim piezo si timer
      {
        timerStarted = false;
        lastPiezoTimer = millis();
        noTone(piezoPin);
        alarmStarted = false;
      }
      if(timerStarted == true && millis() - lastPiezoTimer > 5000 && alarmStarted == false) // daca timerul e pornit si au trecut 3 sec
      {
        Statistics::addOneAlert();              
        tone(piezoPin, 1000);
        alarmStarted = true;
        Serial.println("ALARM STARTED");
      }
    }
};
