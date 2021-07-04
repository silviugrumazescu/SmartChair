DateTime sensorTimer[3];
DateTime redTimer;
String startingHour;
DateTime onChairTimer;
DateTime lastFileUpdate;
bool recordingCurrentHour = false;
DateTime interval;

////////////////////////////
// DATA SENDING VARIABLES //
////////////////////////////
char sns1[20], sns2[20], sns3[20], sns4[20], alertC[20], intervalBuff[20];
String toSend = "<";
File fDate;
File sensor1, sensor2, sensor3, sensor4, alertCount;
File fIntervalRoot;
File fInterval;
////////////////////////////
////////////////////////////
class Statistics
{

  public:
    static void cleanUp()
    {
      if(recordingCurrentHour == true)
      {
        recordingCurrentHour = false;
        DateTime now = rtc.now();
        String date = "A" + (String)(now.year() % 100) + "B" + (String)now.month() + "C" + (String)now.day();
        SD.mkdir(date + "/ALLSTAT/");
        Serial.print("S-a stat pe scaun: ");
        Serial.println(getInterval(onChairTimer, now));
        updateFile(getInterval(onChairTimer, now), date + "/ALLSTAT/" + startingHour +  ".txt");   
      }
      for (int i = 0; i < 3; i++)
         sensorTimer[i]= DateTime(2000,0,0,0,0,0);
      redTimer = DateTime(2000,0,0,0,0,0);
      lastFileUpdate = DateTime(2000,0,0,0,0,0);
      interval = DateTime(2000,0,0,0,0,0);
      onChairTimer = DateTime(2000,0,0,0,0,0);
      recordingCurrentHour = false;

    }
    static void gatherData() 
    { // functie rulata in loop daca avem o conectiune stabila
      // -- Durata pe rosu a celor trei senzori din spate --
      if (analogRead(sittingSensorPin) > 400) // Doar daca persoana este pe scaun
      {
        for (int i = 0; i < 3; i++)
        {
          if (sensorArrayFlags[i] == false && sensorTimer[i].year() == 2000)
          {
            sensorTimer[i] = rtc.now();
            if(redTimer.year() == 2000)
            {
              redTimer = rtc.now();
              Serial.print("redTimer millis inregistrat: ");
              Serial.print(redTimer.hour());
              Serial.print(" ");
              Serial.print(redTimer.minute());
              Serial.print(" ");
              Serial.print(redTimer.second());// inregistram timpul in care persoana sta gresit pe scaun
            }
          }
          

          if (sensorArrayFlags[i] == true && sensorTimer[i].year() != 2000)
          {
            DateTime now = rtc.now();
            if(getInterval(sensorTimer[i], now) >= 5)
            {            
              String date = "A" + (String)(now.year() % 100) + "B" + (String)now.month() + "C" + (String)now.day();
              SD.mkdir(date + "/SNSTAT/");
              String path = date + "/SNSTAT/SENSOR" + (String)i + ".txt";
              addToFile(getInterval(sensorTimer[i], now), path);              
            }
            sensorTimer[i] = DateTime(2000,0,0,0,0,0);
          }
        }

        if(sensorArrayFlags[0] == true && sensorArrayFlags[1] == true && sensorArrayFlags[2] == true && redTimer.year() != 2000)
        {   
            DateTime now = rtc.now();
            if(getInterval(redTimer, now) >= 5)
            {  
              String date = "A" + (String)(now.year() % 100) + "B" + (String)now.month() + "C" + (String)now.day();
              SD.mkdir(date + "/SNSTAT/");
              String path = date + "/SNSTAT/SENSOR3.txt";
              addToFile(getInterval(redTimer, now), path);
            }
            redTimer = DateTime(2000,0,0,0,0,0);
        }
      }
      // -- Durata si ora in care a stat persoana pe scaun --
      if (analogRead(sittingSensorPin) > 400 && recordingCurrentHour == false)
      {
        recordingCurrentHour = true;
        lastFileUpdate = rtc.now();
        DateTime now = rtc.now();
        String date = "A" + (String)(now.year() % 100) + "B" + (String)now.month() + "C" + (String)now.day();
        onChairTimer = rtc.now();
        Serial.print("Persoana s-a asezat la");
        Serial.print(onChairTimer.hour());
        Serial.print(" ");
        Serial.print(onChairTimer.minute());
        Serial.print(" ");
        Serial.print(onChairTimer.second());
        Serial.print(" ");
        if(!SD.exists(date + "/SNSTAT/SENSOR0.txt"))
        {
          SD.mkdir(date + "/SNSTAT");
          for(int i=0; i < 4; i++)
          {
            updateFile(0, date + "/SNSTAT/SENSOR" + (String)i + ".txt");  
          }  
          updateFile(0, date + "/SNSTAT/ALERTC.txt");
        }
        startingHour = (String)now.hour() + "Y" + (String)now.minute() + "Z" + (String)now.second();
      }
      if (analogRead(sittingSensorPin) < 400 && recordingCurrentHour == true) // Cand persoana se ridica de pe scaun se inregistreaza intervalul stat
      {
        recordingCurrentHour = false;
        lastFileUpdate = DateTime(2000,0,0,0,0,0);
        redTimer = DateTime(2000,0,0,0,0,0);
     //   interval = millis() - onChairTimer;
     //   interval = interval / 100;
        DateTime now = rtc.now();
        String date = "A" + (String)(now.year() % 100) + "B" + (String)now.month() + "C" + (String)now.day();
        SD.mkdir(date + "/ALLSTAT/");
        Serial.print("S-a stat pe scaun: ");
        Serial.println(getInterval(onChairTimer, now));
        updateFile(getInterval(onChairTimer, now), date + "/ALLSTAT/" + startingHour +  ".txt");
      }
      if (recordingCurrentHour == true && getInterval(lastFileUpdate, rtc.now()) > 10) // Daca de 10 sec nu am facut update la fila
      {
        lastFileUpdate = rtc.now();
     //   interval = millis() - onChairTimer;
     //   interval = interval / 100;
        DateTime now = rtc.now();
        String date = "A" + (String)(now.year() % 100) + "B" + (String)now.month() + "C" + (String)now.day();
        SD.mkdir(date + "/ALLSTAT/");
        updateFile(getInterval(onChairTimer ,now), date + "/ALLSTAT/" + startingHour +  ".txt");
      }
    }

    static void sendData() // functie apelata in urma primirii byte-ului corespunzator ( Doar in MODE 1 )
    {
      File root = SD.open("/");
      root.rewindDirectory();
      memset(sns1, 0, 20); memset(sns2, 0, 20); memset(sns3, 0, 20); memset(sns4,0, 20); memset(alertC, 0, 20);
      while (fDate = root.openNextFile())
      {
        if (fDate.isDirectory() && !((String)fDate.name()).startsWith("SYS"))
        {
          toSend = toSend + fDate.name();
          // ========== CITIM VALORILE CELOR 3 SENSORI ========
          sensor1 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR0.txt");
          sensor2 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR1.txt");
          sensor3 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR2.txt");
          sensor4 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR3.txt");
          alertCount = SD.open(String(fDate.name()) + "/SNSTAT/ALERTC.txt");
          sensor1.read(sns1, 20); sensor2.read(sns2, 20); sensor3.read(sns3, 20); sensor4.read(sns4, 20); alertCount.read(alertC, 20);
          sensor1.close(); sensor2.close(); sensor3.close(); sensor4.close(); alertCount.close();
          String ssns1 = String(sns1).substring(0, strlen(sns1));
          String ssns2 = String(sns2).substring(0, strlen(sns2));
          String ssns3 = String(sns3).substring(0, strlen(sns3));
          String ssns4 = String(sns4).substring(0, strlen(sns4));
          String salertC = String(alertC).substring(0, strlen(alertC));
          toSend = toSend + 'G' + String(ssns1) + 'H' + String(ssns2) + 'I' + String(ssns3) + 'J' + String(ssns4) + 'K' + String(salertC);
          memset(sns1, 0, 20); memset(sns2, 0, 20); memset(sns3, 0, 20); memset(sns4, 0, 20); memset(alertC, 0, 20);
          // ========== CITIM VALORILE INTERVALELOR ============
          fIntervalRoot = SD.open(String(fDate.name()) + "/ALLSTAT/");
          while (fInterval = fIntervalRoot.openNextFile())
          {
            fInterval.read(intervalBuff, 20);
            String sintervalBuff = String(intervalBuff).substring(0, strlen(intervalBuff));
            toSend = toSend + 'X' + ((String)fInterval.name()).substring(0, strlen(fInterval.name()) - 4) + '-' + sintervalBuff;
            memset(intervalBuff, 0, 20);
            fInterval.close();
            if (toSend.length() > 50)
            {
              Serial2.print(toSend);
              Serial.println(toSend);
              toSend = "";
            }
          }
          fIntervalRoot.close();
          toSend += '!';
        }
        fDate.close();

      }
      toSend += '>';
      Serial2.print(toSend);
      Serial.println(toSend);
      toSend = "<";
    }

    static void sendDayData(String Year, String Month, String Day)
    {
      File root = SD.open("/");
      root.rewindDirectory();
      toSend = "@";
      memset(sns1, 0, 20); memset(sns2, 0, 20); memset(sns3, 0, 20);  memset(sns4, 0, 20); memset(alertC, 0, 20);
      DateTime now = rtc.now();
      String date = "A" + Year + "B" + Month + "C" + Day;
      Serial.println("++++++++++++++++++" + date);
      while (fDate = root.openNextFile())
      {
        if (fDate.isDirectory() && ((String)fDate.name()).startsWith(date))
        {
          Serial.println();
          Serial.print("opened the directtory ");
          Serial.println(fDate.name());
          toSend = toSend + fDate.name();
          // ========== CITIM VALORILE CELOR 3 SENSORI ========
          sensor1 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR0.txt");
          sensor2 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR1.txt");
          sensor3 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR2.txt");
          sensor4 = SD.open(String(fDate.name()) + "/SNSTAT/SENSOR3.txt");
          alertCount = SD.open(String(fDate.name()) + "/SNSTAT/ALERTC.txt");
          sensor1.read(sns1, 20); sensor2.read(sns2, 20); sensor3.read(sns3, 20); sensor4.read(sns4, 20); alertCount.read(alertC, 20);
          sensor1.close(); sensor2.close(); sensor3.close(); sensor4.close(); alertCount.close();
          String ssns1 = String(sns1).substring(0, strlen(sns1));
          String ssns2 = String(sns2).substring(0, strlen(sns2));
          String ssns3 = String(sns3).substring(0, strlen(sns3));
          String ssns4 = String(sns4).substring(0, strlen(sns4));
          String salertC = String(alertC).substring(0, strlen(alertC));
          toSend = toSend + 'G' + String(ssns1) + 'H' + String(ssns2) + 'I' + String(ssns3) + 'J' + String(ssns4) + 'K' + String(salertC);
          memset(sns1, 0, 20); memset(sns2, 0, 20); memset(sns3, 0, 20); memset(sns4, 0, 20); memset(alertC, 0, 20);
          // ========== CITIM VALORILE INTERVALELOR ============
          fIntervalRoot = SD.open(String(fDate.name()) + "/ALLSTAT/");
          while (fInterval = fIntervalRoot.openNextFile())
          {
            fInterval.read(intervalBuff, 20);
            String sintervalBuff = String(intervalBuff).substring(0, strlen(intervalBuff));
            toSend = toSend + 'X' + ((String)fInterval.name()).substring(0, strlen(fInterval.name()) - 4) + '-' + sintervalBuff;
            memset(intervalBuff, 0, 20);
            fInterval.close();
            if (toSend.length() > 50)
            {
              Serial2.print(toSend);
              Serial.print(toSend);
              toSend = "";
            }
          }
          fIntervalRoot.close();
          toSend += '!';
          fDate.close();
          break;
        }
        fDate.close();

      }
      toSend += '>';
      Serial2.print(toSend);
      Serial.print(toSend);
      toSend = "<";
    }

    static void addOneAlert()
    {
        DateTime now = rtc.now();
        String date = "A" + (String)(now.year() % 100) + "B" + (String)now.month() + "C" + (String)now.day();
        SD.mkdir(date + "/SNSTAT/");
        String path = date + "/SNSTAT/ALERTC.txt";
        addToFile(1, path);
    };
    
    static long getInterval(DateTime first, DateTime last)
    {
        long hour, minute, second;
        if(first.hour() > last.hour())
            hour = 24 - first.hour() + last.hour() - 1;
        else if(first.hour() == last.hour())
          hour = 0;
        else if(last.hour() - first.hour() > 1)
            hour = last.hour() - first.hour() - 1;
        else hour = 0;
        
        if(first.hour() == last.hour())
          if(last.minute() - first.minute() > 1)
            minute = last.minute() - first.minute();
          else minute = 0;
        else
          minute = (60 - first.minute()) + last.minute();
        if(first.minute() == last.minute())
          second = last.second() - first.second(); 
        else 
          second = (60 - first.second()) + last.second();

        return hour*3600 + minute*60 + second; 
      }

  private:

    static void addToFile(long number, String path) 
    {
      long result = 0;
      if (SD.exists(path)) 
      {
        File file = SD.open(path, FILE_READ);
        char bufferA[20];
        int i = 0;
        while (file.available())
          file.read(bufferA, 20);
        file.close();
        result = atoi(bufferA);
        SD.remove(path);
      }
      File file = SD.open(path, FILE_WRITE);
      if (file) 
        file.print(result + number);
      else
        Serial.println("Unsuccesfully opened the file");
      Serial.println("S-a adauga la fila " + path  + " valoarea: " + (String)(number)); // DEBUG
      Serial.println("Interval total: " + (String)(result + number));
      file.close();

    }

    static void updateFile(long number, String path) 
    {
      SD.remove(path);
      File file1 = SD.open(path, FILE_WRITE);
      if(number == 0) number = 1;
      if (file1) 
      {
        Serial.println("Succesfully opened the file");
        file1.print(number);
      }
      else 
      {
        Serial.println("Unsuccesfully opened the file");
      }

      file1.close();
      Serial.println("S-a updatat fila " + path + " cu valoarea: " + (String)number); // DEBUG
    }

};
