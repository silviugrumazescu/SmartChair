using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Drawing.Imaging;


namespace SmartChair___THE_FINAL_FINAL
{
    public partial class MainForm
    {

        public void readDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BLComm._commStream.ReadTimeout = 10000;
                int Byte;
                string message = "";
                this.Invoke(new myDelegate(restartConnectionTimer));
                while (readDataWorker.CancellationPending == false)
                {
                    Byte = BLComm._commStream.ReadByte();
                    Console.Write((char)Byte);
                    if ((char)Byte == '<') // Incepem citirea datelor pentru statistici
                    {
                        readStatData();
                    }
                    else if ((char)Byte == '@')
                    {
                        readDayStatData();
                    }
                    else
                    {
                        message += (char)Byte;
                        if(message.ToCharArray()[0] != '*')
                        {
                            message = "";
                        }
                        if (message.Length == 5)
                        {
                            message = message.Substring(1, message.Length-1);
                            analizeData(message);
                            message = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void readStatData()
        {
            GlobalVar.dates = new date[3000];
            int dateIndex = -1;
            int perioadaIndex = -1;
            string SMTIME, SLTIME, SRTIME, SRED, ALERTC, YEAR, MONTH, DAY;
            SMTIME = SLTIME = SRTIME = YEAR = MONTH = DAY = SRED = ALERTC = "";
            string[] HOUR = new string[10000];
            string[] MIN = new string[10000];
            string[] SEC = new string[10000];
            string[] INTERVAL = new string[10000];
            char mode = '*';

            int byteRead = 0;

            bool readOK = true;

            while (readOK == true)
            {
                this.Invoke(new myDelegate(restartConnectionTimer));
                byteRead = BLComm._commStream.ReadByte();
                Console.Write((char)byteRead);
                if ((char)byteRead == 'G' || // MRTIME
                    (char)byteRead == 'H' || // RRTIME
                    (char)byteRead == 'I' || // LRTIME
                    (char)byteRead == 'J' || // SRED
                    (char)byteRead == 'K')   // ALERTC


                    mode = (char)byteRead;

                else if ((char)byteRead == 'A') { mode = (char)byteRead; } // anul
                else if ((char)byteRead == 'B') { mode = (char)byteRead; } // luna
                else if ((char)byteRead == 'C') { mode = (char)byteRead; } // ziua
                else if ((char)byteRead == '-') { mode = (char)byteRead; } // intevalul 
                else if ((char)byteRead == 'X') { mode = (char)byteRead; perioadaIndex++; } // ora
                else if ((char)byteRead == 'Y') { mode = (char)byteRead; } // min
                else if ((char)byteRead == 'Z') { mode = (char)byteRead; } // sec
                else if ((char)byteRead == '!')// ---- Stocam datele pentru data curenta si asteptam urmatoarea
                {
                    dateIndex++;

                    float s;
                    GlobalVar.dates[dateIndex].Perioada = new perioada[300];
                    GlobalVar.dates[dateIndex].SLTIME = float.Parse(SLTIME);// * 100 deoarece dorim ca informatia sa fie in milisecunde
                    GlobalVar.dates[dateIndex].SRTIME = float.Parse(SRTIME);
                    GlobalVar.dates[dateIndex].SMTIME = float.Parse(SMTIME);
                    GlobalVar.dates[dateIndex].SRED = float.Parse(SRED);
                    GlobalVar.dates[dateIndex].alertCount = float.Parse(ALERTC);
                    GlobalVar.dates[dateIndex].data = GlobalVar.dates[dateIndex].data.AddYears(int.Parse("20" + YEAR) - 1);
                    GlobalVar.dates[dateIndex].data = GlobalVar.dates[dateIndex].data.AddMonths(int.Parse(MONTH) - 1);
                    GlobalVar.dates[dateIndex].data = GlobalVar.dates[dateIndex].data.AddDays(int.Parse(DAY) - 1);
                    for (int i = 0; i <= perioadaIndex; i++)
                    {
                        GlobalVar.dates[dateIndex].Perioada[i].ora = GlobalVar.dates[dateIndex].Perioada[i].ora.AddHours(float.Parse(HOUR[i]));
                        GlobalVar.dates[dateIndex].Perioada[i].ora = GlobalVar.dates[dateIndex].Perioada[i].ora.AddMinutes(float.Parse(MIN[i]));
                        GlobalVar.dates[dateIndex].Perioada[i].ora = GlobalVar.dates[dateIndex].Perioada[i].ora.AddSeconds(float.Parse(SEC[i]));
                        GlobalVar.dates[dateIndex].Perioada[i].interval = float.Parse(INTERVAL[i]); // * 1000 deoarece dorim ca informatia sa fie in milisecunde
                    }
                    GlobalVar.dates[dateIndex].nrPer = perioadaIndex + 1;
                    // ----- Stergem valorile inregistrate pentru a primi altele ----------
                    SRED = SMTIME = SLTIME = SRTIME = ALERTC = YEAR = MONTH = DAY = "";
                    Array.Clear(HOUR, 0, perioadaIndex + 1);
                    Array.Clear(MIN, 0, perioadaIndex + 1);
                    Array.Clear(SEC, 0, perioadaIndex + 1);
                    Array.Clear(INTERVAL, 0, perioadaIndex + 1);
                    perioadaIndex = -1;


                }
                else if ((char)byteRead == '>') // ending data sending
                {

                    for (int q = 0; q <= dateIndex; q++)
                    {
                        GlobalVar.dates[q].dateIndex = dateIndex;
                    }
                    GlobalVar.dateIndex = dateIndex;
                    readOK = false;
                    isStatisticDataReceived = true;
                    WriteToBinaryFile<date[]>(Application.StartupPath.Replace(@"\", @"\\") + "\\file", GlobalVar.dates, false);
                    this.Invoke((MethodInvoker)delegate
                    {
                        statisticsForm.updateCalendar();
                        updateActivityPanel(true);
                    });

                }
                else //Stocam caracterul in variabila corespunzatoare
                {

                    switch (mode)
                    {
                        case 'A':
                            YEAR += (char)byteRead;
                            break;
                        case 'B':
                            MONTH += (char)byteRead;
                            break;
                        case 'C':
                            DAY += (char)byteRead;
                            break;
                        case 'G':
                            SMTIME += (char)byteRead;
                            break;
                        case 'H':
                            SRTIME += (char)byteRead;
                            break;
                        case 'I':
                            SLTIME += (char)byteRead;
                            break;
                        case 'J':
                            SRED += (char)byteRead;
                            break;
                        case 'K':
                            ALERTC += (char)byteRead;
                            break;
                        case '-':
                            INTERVAL[perioadaIndex] += (char)byteRead;
                            break;
                        case 'X':
                            HOUR[perioadaIndex] += (char)byteRead;
                            break;
                        case 'Y':
                            MIN[perioadaIndex] += (char)byteRead;
                            break;
                        case 'Z':
                            SEC[perioadaIndex] += (char)byteRead;
                            break;
                    }
                }
            }
        }
        public void readDayStatData()
        {
            int dateIndex = GlobalVar.dateIndex;
            int perioadaIndex = -1;
            string SMTIME, SLTIME, SRTIME, SRED, YEAR, MONTH, DAY, ALERTC;
            SMTIME = SLTIME = SRTIME = SRED = YEAR = MONTH = DAY = ALERTC = "";
            string[] HOUR = new string[1000];
            string[] MIN = new string[1000];
            string[] SEC = new string[1000];
            string[] INTERVAL = new string[1000];
            char mode = '*';

            int byteRead = 0;

            bool readOK = true;

            while (readOK == true)
            {
                this.Invoke(new myDelegate(restartConnectionTimer));
                byteRead = BLComm._commStream.ReadByte();
                Console.Write((char)byteRead);
                if ((char)byteRead == 'G' || // MRTIME
                    (char)byteRead == 'H' || // RRTIME
                    (char)byteRead == 'I' || // LRTIME
                    (char)byteRead == 'J' ||
                    (char)byteRead == 'K')

                    mode = (char)byteRead;

                else if ((char)byteRead == 'A') { mode = (char)byteRead; } // anul
                else if ((char)byteRead == 'B') { mode = (char)byteRead; } // luna
                else if ((char)byteRead == 'C') { mode = (char)byteRead; } // ziua
                else if ((char)byteRead == '-') { mode = (char)byteRead; } // intevalul
                else if ((char)byteRead == 'X') { mode = (char)byteRead; perioadaIndex++; } // ora
                else if ((char)byteRead == 'Y') { mode = (char)byteRead; } // min
                else if ((char)byteRead == 'Z') { mode = (char)byteRead; } // sec
                else if ((char)byteRead == '!')// ---- Stocam datele pentru data curenta si asteptam urmatoarea
                {
                    float s;

                    DateTime currentDay = new DateTime();

                    currentDay = currentDay.AddYears(int.Parse("20" + YEAR) - 1);
                    currentDay = currentDay.AddMonths(int.Parse(MONTH) - 1);
                    currentDay = currentDay.AddDays(int.Parse(DAY) - 1);
                    bool k = true;
                    for (int v = 0; v <= dateIndex; v++)
                    {
                        if (GlobalVar.dates[v].data == currentDay)
                        {
                            k = false;
                            GlobalVar.dates[v].Perioada = new perioada[100];

                            GlobalVar.dates[v].SLTIME = float.Parse(SLTIME); // * 1000 deoarece avem nevoie de informatie in milisecunde
                            GlobalVar.dates[v].SRTIME = float.Parse(SRTIME);
                            GlobalVar.dates[v].SMTIME = float.Parse(SMTIME);
                            GlobalVar.dates[v].SRED = float.Parse(SRED);
                            GlobalVar.dates[v].alertCount = float.Parse(ALERTC);

                            Array.Clear(GlobalVar.dates[v].Perioada, 0, (int)GlobalVar.dates[v].nrPer);
                            for (int i = 0; i <= perioadaIndex; i++)
                            {

                                GlobalVar.dates[v].Perioada[i].ora = GlobalVar.dates[v].Perioada[i].ora.AddHours(float.Parse(HOUR[i]));
                                GlobalVar.dates[v].Perioada[i].ora = GlobalVar.dates[v].Perioada[i].ora.AddMinutes(float.Parse(MIN[i]));
                                GlobalVar.dates[v].Perioada[i].ora = GlobalVar.dates[v].Perioada[i].ora.AddSeconds(float.Parse(SEC[i]));
                                GlobalVar.dates[v].Perioada[i].interval = float.Parse(INTERVAL[i]); // * 100 deoarece dorim ca informatia sa fie in milisecunde
                            }
                            GlobalVar.dates[v].nrPer = perioadaIndex + 1;
                        }
                    }
                    if (k == true) // Daca nu s-a gasit data curenta se creeaza una noua
                    {
                        dateIndex++;
                        GlobalVar.dates[dateIndex].Perioada = new perioada[100];
                        GlobalVar.dates[dateIndex].SLTIME = float.Parse(SLTIME); // * 1000 deoarece dorim ca informatia sa fie in milisecunde
                        GlobalVar.dates[dateIndex].SRTIME = float.Parse(SRTIME);
                        GlobalVar.dates[dateIndex].SMTIME = float.Parse(SMTIME);
                        GlobalVar.dates[dateIndex].SRED = float.Parse(SRED);
                        GlobalVar.dates[dateIndex].alertCount = float.Parse(ALERTC);
                        GlobalVar.dates[dateIndex].data = currentDay;
                        for (int i = 0; i <= perioadaIndex; i++)
                        {

                            GlobalVar.dates[dateIndex].Perioada[i].ora = GlobalVar.dates[dateIndex].Perioada[i].ora.AddHours(float.Parse(HOUR[i]));
                            GlobalVar.dates[dateIndex].Perioada[i].ora = GlobalVar.dates[dateIndex].Perioada[i].ora.AddMinutes(float.Parse(MIN[i]));
                            GlobalVar.dates[dateIndex].Perioada[i].ora = GlobalVar.dates[dateIndex].Perioada[i].ora.AddSeconds(float.Parse(SEC[i]));
                            GlobalVar.dates[dateIndex].Perioada[i].interval = float.Parse(INTERVAL[i]); // * 100 deoarece dorim ca informatia sa fie in milisecunde
                        }
                        GlobalVar.dates[dateIndex].nrPer = perioadaIndex + 1;
                    }
                }
                else if ((char)byteRead == '>') // ending data sending
                {
                    for (int q = 0; q <= dateIndex; q++)
                    {
                        GlobalVar.dates[q].dateIndex = dateIndex;
                    }
                    GlobalVar.dateIndex = dateIndex;
                    readOK = false;
                    isStatisticDataReceived = true;

                    WriteToBinaryFile<date[]>(Application.StartupPath.Replace(@"\", @"\\") + "\\file", GlobalVar.dates, false);
                    this.Invoke((MethodInvoker)delegate { updateActivityPanel(true);});
                }
                else //Stocam caracterul in variabila corespunzatoare
                {

                    switch (mode)
                    {
                        case 'A':
                            YEAR += (char)byteRead;
                            break;
                        case 'B':
                            MONTH += (char)byteRead;
                            break;
                        case 'C':
                            DAY += (char)byteRead;
                            break;
                        case 'G':
                            SMTIME += (char)byteRead;
                            break;
                        case 'H':
                            SRTIME += (char)byteRead;
                            break;
                        case 'I':
                            SLTIME += (char)byteRead;
                            break;
                        case 'J':
                            SRED += (char)byteRead;
                            break;
                        case 'K':
                            ALERTC += (char)byteRead;
                            break;
                        case '-':
                            INTERVAL[perioadaIndex] += (char)byteRead;
                            break;
                        case 'X':
                            HOUR[perioadaIndex] += (char)byteRead;
                            break;
                        case 'Y':
                            MIN[perioadaIndex] += (char)byteRead;
                            break;
                        case 'Z':
                            SEC[perioadaIndex] += (char)byteRead;
                            break;
                    }
                }
            }
        }


        private void readDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BLComm._client.Close();
            BLComm._commStream.Close();

            BLComm._connectedDevice = null;
            BLComm._guid = Guid.Empty;
            //    _commStream.Dispose();
        }

        public void analizeData(string data)
        {
            switch (data)
            {
                case "SONN":
                    sensorState[3] = true; //Se afla persoana pe scaun
                    break;
                case "ULON":
                    sensorState[0] = true;
                    break;
                case "ULOF":
                    sensorState[0] = false;
                    if (!showUITimer.Enabled) this.Invoke((MethodInvoker)delegate { showUITimer.Enabled = true; });
                    break;
                case "URON":
                    sensorState[1] = true;
                    break;
                case "UROF":
                    sensorState[1] = false;
                    if (!showUITimer.Enabled) this.Invoke((MethodInvoker)delegate { showUITimer.Enabled = true; });
                    break;
                case "DDON":
                    sensorState[2] = true;
                    break;
                case "DDOF":
                    sensorState[2] = false;
                    if (!showUITimer.Enabled) this.Invoke((MethodInvoker)delegate { showUITimer.Enabled = true; });
                    break;
                case "SOFF":
                    Application.StartupPath.Replace(@"\", @"\\");
                    pictureBox3.ImageLocation = Application.StartupPath.Replace(@"\",@"\\") + "\\images\\no-person.jpg";
                    sensorState[3] = false;
                    if (showUITimer.Enabled) this.Invoke((MethodInvoker)delegate
                    {
                        showUITimer.Enabled = false;
                        q = 0; // q is incrementing every 1 sec tick, at 5 tick runs the function
                        if (positionAlertForm.Visible == true)
                        {
                            positionAlertForm.picturePath = pictureBox3.ImageLocation;
                            positionAlertForm.setNotifyPictureBox1 = notifyPictureBox1.ImageLocation;
                            positionAlertForm.setNotifyPictureBox2 = notifyPictureBox2.ImageLocation;
                            positionAlertForm.Destroy();
                        }
                        idlePositionAppearance();
                    });
                    break;
                case "ACTI":
                    this.Invoke(new myDelegate(restartConnectionTimer));
                    break;
                case "BOFF":
                    connectionRecvTimer.Stop();
                    connectionSendTimer.Stop();
                    this.Invoke(new myDelegate(disconnectedUIAppearance));
                    readDataWorker.CancelAsync();
                    //     this.Invoke(new myUIDelegate(changeDebugText), "Chair switched to NO BLUETOOTH MODE");
                    break;
                case "CALI":
                    this.Invoke((MethodInvoker)delegate
                    {
                        Calibrating_Panel.Visible = true;
                        connectionRecvTimer.Stop();
                        connectionSendTimer.Stop();
                        calibratingTimer.Start();
                    });
                    break;
            }
            if (sensorState[3] == false)
            {
                idlePositionAppearance();
                pictureBox3.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\no-person.jpg";
                notifyPictureBox1.ImageLocation = "";
                notifyPictureBox2.ImageLocation = "";
            }
            else if (sensorState[0] == true && sensorState[1] == true && sensorState[2] == true)
            {
                correctPositionAppearance();
                notifyPictureBox1.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\correct-notify1.gif";
                notifyPictureBox2.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\correct-notify2.gif";
                pictureBox3.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\good-position.gif";
                if (showUITimer.Enabled) this.Invoke((MethodInvoker)delegate
                {
                    showUITimer.Enabled = false;
                    q = 0;
                if (positionAlertForm.Visible == true)
                    {
                        positionAlertForm.picturePath = pictureBox3.ImageLocation;
                        positionAlertForm.setNotifyPictureBox1 = notifyPictureBox1.ImageLocation;
                        positionAlertForm.setNotifyPictureBox2 = notifyPictureBox2.ImageLocation;
                        positionAlertForm.Destroy();
                    }
                });
            }
            else
            {
                wrongPositionAppearance();

         
        
                pictureBox3.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\bad-position.jpg";
                if (sensorState[0] == false || sensorState[1] == false)
                {
                    notifyPictureBox1.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\wrong-notify1.gif";
                    if(sensorState[2] == false)
                    {
                        notifyPictureBox2.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\wrong-notify2.gif";
                    }
                    else
                    {
                        notifyPictureBox2.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\almost-correct-notify2.gif";
                    }
                }
                else
                {
                    notifyPictureBox1.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\almost-correct-notify1.gif";
                    notifyPictureBox2.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\wrong-notify2.gif";
                }
            }

        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
        public class GifImage
        {
            private Image gifImage;
            private FrameDimension dimension;
            public int frameCount;
            private int currentFrame = -1;
            private bool reverse;
            private int step = 1;

            public GifImage(string path)
            {
                gifImage = Image.FromFile(path); //initialize
                dimension = new FrameDimension(gifImage.FrameDimensionsList[0]); //gets the GUID
                frameCount = gifImage.GetFrameCount(dimension); //total frames in the animation
            }

            public bool ReverseAtEnd //whether the gif should play backwards when it reaches the end
            {
                get { return reverse; }
                set { reverse = value; }
            }

            public Image GetNextFrame()
            {

                currentFrame += step;

                //if the animation reaches a boundary...
                if (currentFrame >= frameCount || currentFrame < 1)
                {
                    if (reverse)
                    {
                        step *= -1; //...reverse the count
                        currentFrame += step; //apply it
                    }
                    else
                        currentFrame = 0; //...or start over
                }
                return GetFrame(currentFrame);
            }

            public Image GetFrame(int index)
            {
                gifImage.SelectActiveFrame(dimension, index); //find the frame
                return (Image)gifImage.Clone(); //return a copy of it
            }
        }
    }
}