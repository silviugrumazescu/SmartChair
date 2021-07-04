class Mode1 {

  public:

    static void checkSwitch()
    {
      switchState = digitalRead(switchPin);

      if (switchState != previousSwitchState && switchState == LOW)
      {
        switchMode = !switchMode;
        if (switchMode == 1) {
          Serial.println("Changed to mode 1 function 1");
          noTone(piezoPin);
          isConnected = false;
        }
        else
        {
          if (isConnected == true)
            Serial2.print("*BOFF");
          isConnected = false;
          Statistics::cleanUp(); // Pentru a inregistra valorile ramase
          Serial.println("Changed to mode 0 function 1");
        }
      }
      else if(switchState == HIGH)
      {
          if(previousSwitchState == LOW)
          {
            pushButtonTimer = millis();  
          }
          else if(millis() - pushButtonTimer > 3000) // Entering calibrarion mode ===============
          {
            Statistics::cleanUp();
            if(isConnected == true)
            {
              Serial2.println("*CALI");
            }
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
            delay(500);
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

    static void checkConnection()
    {
      if (millis() - lastConnSendTimer > 2000) // La un interval de 3 sec transmitem PC ca scaunul este activ
      {
        lastConnSendTimer = millis();
        Serial2.print("*ACTI");
      }

      if (millis() - lastConnRecvTimer > 2500) // La un interval de 2.5 sec PC ne transmite un mesaj
      {

        isConnected = false;
        Statistics::cleanUp(); // Datele raman salvate la reconectare daca nu ruleaza functia
        Serial.println("DISCONNECTED");
      }

      if (Serial2.available() > 0)
      {
        byte response;
        response = Serial2.read();
        if (response == echoByte) 
        {
          lastConnRecvTimer = millis();
          Serial.println("Received connection byte");
        }
        else if(response == dataSendingByte) // Curent date
        {
          DateTime now = rtc.now();
          Statistics::sendDayData((String)now.year(), (String)now.month(), (String)now.day());
        }
        else if(response == yearDataSendingByte) //All time dates
        {
          Statistics::sendData();  
        }
        else if(response == alertSendingByte)
        {
          Statistics::addOneAlert();
          Serial.println("Added one to the alert");  
        }
        else if(char(response) == '*') //Custom date
        {
          char c;
          String Year = "";
          String Month = "";
          String Day = "";
          char mode;
          while(true)
          {
            if(Serial2.available())
            {
              response = Serial2.read();
              c = char(response);
              Serial.println(c);
              if(c == 'a' || c == 'b' || c == 'c')
                mode = c;
              else if(c == 'd')
              {
                Statistics::sendDayData(Year, Month, Day);
                break;
              }
              else if(response == 255) Serial.println();
              else 
              {
                switch(mode)
                {
                  case 'a':
                    Year += String(c);
                    break;
                  case 'b':
                    Month += String(c);
                    break;
                  case 'c':
                    Day += String(c);
                    break;
                }  
              }
            }
          }
        }
      }
    }

    static void waitingToSit()
    {
      Statistics::cleanUp();
      Serial2.print("*SOFF"); // Transmitem programului ca nimeni nu se afla pe scaun
      Serial.println("Nimeni nu se afla pe scaun");
      while (isConnected == true) // Iesim din loop daca persoana se aseaza pe scaun sau conexiunea esueaza
      {
        checkConnection(); checkSwitch(); Statistics::gatherData();
        if (analogRead(sittingSensorPin) > 400) // Daca persoana se aseaza pe scaun
        {
          Serial2.print("*SONN");
          break;                     // Iesim din loop
        }
      }
      // --------- Verificam starea actuala a sensorilor -------------
      if (isConnected == true)
      {
        for (int i = 0; i < 3; i++)
        {
          if (analogRead(sensorArrayPins[i]) > 400)
            Serial2.print(sensorArrayOnMessage[i]);

          if (analogRead(sensorArrayPins[i]) < 400)
            Serial2.print(sensorArrayOffMessage[i]);

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


    static void waitingToConnect()
    {
      
      checkSwitch();
      if (Serial2.available() > 0) // asteptam raspuns de la computer
      {
        byte response = Serial2.read();
        if (response == echoByte)
        {

          Serial.println("CONNECTED");
          isConnected = true;
          lastConnSendTimer = millis();
          lastConnRecvTimer = millis();

          if(digitalRead(sensorArrayPins[0]) == LOW)
              Serial2.println("*SOFF");
          else 
              Serial2.println("*SONN");

               // --------- Verificam starea actuala a sensorilor -------------
          if (isConnected == true)
          {
            for (int i = 0; i < 3; i++)
            {
              if (analogRead(sensorArrayPins[i]) > 400)
                Serial2.print(sensorArrayOnMessage[i]);
    
              if (analogRead(sensorArrayPins[i]) < 400)
                Serial2.print(sensorArrayOffMessage[i]);

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
      }
    }

    static void sensorRead()
    {
      for (int i = 0; i < 3; i++)
      {
        if (analogRead(sensorArrayPins[i]) > 400 && sensorArrayFlags[i] == false)
        {
          sensorArrayFlags[i] = true;
          Serial2.print(sensorArrayOnMessage[i]);
        }

        if (analogRead(sensorArrayPins[i]) < 400 && sensorArrayFlags[i] == true)
        {
          sensorArrayFlags[i] = false;
          Serial2.print(sensorArrayOffMessage[i]);
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

};
