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

namespace SmartChair___THE_FINAL_FINAL
{
    public partial class MainForm : Form
    {
        bool isStatisticDataReceived = false;

        bool[] sensorState = { false, false, false, false };

        byte echoByte = 0x61;
        byte dataSendingByte = 0x62;
        byte yearDataSendingByte = 0x63;
        byte alertSendingByte = 0x64;

        StatisticsForm statisticsForm = new StatisticsForm();
        PositionAlertForm positionAlertForm = new PositionAlertForm();

        public delegate void myDelegate();
        public delegate void myUIDelegate(String text);

        System.Timers.Timer connectionSendTimer = new System.Timers.Timer();
        System.Timers.Timer connectionRecvTimer = new System.Timers.Timer();

        public int showUITimerDelay = 5;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionSendTimer.Interval = 1000;
            connectionRecvTimer.Interval = 3000;

            connectionRecvTimer.Elapsed += new System.Timers.ElapsedEventHandler(connectionRecvTimer_Elapsed);
            connectionSendTimer.Elapsed += new System.Timers.ElapsedEventHandler(connectionSendTimer_Elapsed);
            //Change appearance
            disconnectedUIAppearance();
            Connect_Button.ButtonText = "FIND MY CHAIR";

            connectionRecvTimer.Stop();
            connectionSendTimer.Stop();
            statisticsForm.Hide();
            positionAlertForm.Hide();

            showUITimerDelayComboBox.SelectedItem = showUITimerDelayComboBox.Items[0];

        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            if (!connectWorker.IsBusy && !readDataWorker.IsBusy)
            {
                connectWorker.RunWorkerAsync();
                Connect_Button.ButtonText = "Se cauta dispozitivul..";
            }

        }

        private void Disconnect_Button_Click(object sender, EventArgs e)
        {
            connectionRecvTimer.Stop();
            connectionSendTimer.Stop();
            this.Invoke(new myDelegate(disconnectedUIAppearance));
            this.Invoke(new myUIDelegate(changeInfoText), "Te-ai deconectat! ");
            this.Invoke((MethodInvoker)delegate { Connect_Button.ButtonText = "FIND MY CHAIR"; });
            readDataWorker.CancelAsync();
        }

        private void connectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BLComm._client = new BluetoothClient();
                if (BLComm._connectedDevice == null)
                {
                    if (File.Exists(Application.StartupPath.Replace(@"\", @"\\") + "\\deviceInfo"))
                    {
                        BluetoothDeviceInfo b = new BluetoothDeviceInfo(ReadFromBinaryFile<InTheHand.Net.BluetoothAddress>(Application.StartupPath.Replace(@"\", @"\\") + "\\deviceInfo"));
                        BLComm._connectedDevice = b;
                    }
                    else
                    {
                        BluetoothDeviceInfo[] peers = BLComm._client.DiscoverDevices();
                        foreach (BluetoothDeviceInfo peer in peers)
                            if (peer.DeviceName == "HC-05")
                            {
                                BLComm._connectedDevice = peer;
                                WriteToBinaryFile<InTheHand.Net.BluetoothAddress>(Application.StartupPath.Replace(@"\", @"\\") + "\\deviceInfo", BLComm._connectedDevice.DeviceAddress, false);
                            }
                    }
                }
                this.Invoke(new myUIDelegate(changeInfoText), "Dispozivitul cu numele " + BLComm._connectedDevice.DeviceName + " a fost gasit. Se incearca conectarea!");
                BLComm._guid = BluetoothService.SerialPort;
                var ep = new InTheHand.Net.BluetoothEndPoint(BLComm._connectedDevice.DeviceAddress, BLComm._guid);
                BLComm._client.Connect(ep);
                BLComm._commStream = BLComm._client.GetStream();
                this.Invoke(new myUIDelegate(changeInfoText), "V-ati conectat cu succes la " + BLComm._connectedDevice.DeviceName);
                this.Invoke(new myDelegate(connectedUIAppearance));
                this.Invoke(new myDelegate(idlePositionAppearance));

                BLComm._commStream.WriteByte(echoByte); // Acest byte anunta scaunul ca a inceput comunicarea

                connectionSendTimer.Start();
                connectionRecvTimer.Start();
                connectionSendTimer.Enabled = true;

                if (File.Exists(Application.StartupPath.Replace(@"\", @"\\") + "\\file"))
                {
                    GlobalVar.dates = ReadFromBinaryFile<date[]>(Application.StartupPath.Replace(@"\", @"\\") + "\\file");
                    GlobalVar.dateIndex = GlobalVar.dates[0].dateIndex;
                    this.Invoke((MethodInvoker)delegate
                    {
                        updateActivityPanel(true);
                    });
                }

                readDataWorker.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                this.Invoke(new myUIDelegate(changeInfoText), "Nu te-ai putut conecta, te rog incearca din nou!");
                this.Invoke((MethodInvoker)delegate { Connect_Button.ButtonText = "FIND MY CHAIR"; });
            }
        }

        private void connectionRecvTimer_Elapsed(object sender, EventArgs e)
        {
            connectionRecvTimer.Stop();
            connectionSendTimer.Stop();
            this.Invoke(new myDelegate(disconnectedUIAppearance));
            this.Invoke(new myDelegate(idlePositionAppearance));
            this.Invoke(new myUIDelegate(changeInfoText), "Te-ai deconectat!");
            this.Invoke((MethodInvoker)delegate { Connect_Button.ButtonText = "FIND MY CHAIR"; });
            readDataWorker.CancelAsync();

        }

        private void connectionSendTimer_Elapsed(object sender, EventArgs e)
        {
            if (readDataWorker.IsBusy == true)
                BLComm._commStream.WriteByte(echoByte);
        }

        public void restartConnectionTimer()
        {
            connectionRecvTimer.Stop();
            connectionRecvTimer.Start();
        }

        public void disconnectedUIAppearance()
        {
            this.Height = 400;
            this.Width = 467;
            panel1.BackColor = System.Drawing.Color.White;
            Welcome_Label.Visible = true;
            this.Show();
            Disconnect_Button.Enabled = false;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            settingPanelStatusLabel.Text = "DISCONNECTED";
            settingPanelStatusLabel.ForeColor = System.Drawing.Color.Maroon;
            settingPanelButton.OnHovercolor = Color.FromArgb(89, 95, 140);
            settingPanelButton.Normalcolor = Color.FromArgb(53, 56, 84);
        }

        public void connectedUIAppearance()
        {
            this.Height = 500;
            this.Width = 538;
            Welcome_Label.Visible = false;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            Disconnect_Button.Enabled = true;
            settingPanelStatusLabel.Text = "CONNECTED";
            settingPanelStatusLabel.ForeColor = System.Drawing.Color.Green;
        }

        public void idlePositionAppearance()
        {

            settingPanelButton.Normalcolor = Color.FromArgb(53, 56, 84);
            settingPanelButton.OnHovercolor = Color.FromArgb(89, 95, 140);

            Disconnect_Button.Normalcolor = Color.FromArgb(53, 56, 84);
            Disconnect_Button.OnHovercolor = Color.FromArgb(89, 95, 140);

            this.Invoke((MethodInvoker)delegate { noPersonAlertLabel.Visible = true; });
        }

        public void wrongPositionAppearance()
        {

            settingPanelButton.Normalcolor = Color.FromArgb(136, 0, 0);
            settingPanelButton.OnHovercolor = Color.FromArgb(221, 0, 0);

            Disconnect_Button.Normalcolor = Color.FromArgb(136, 0, 0);
            Disconnect_Button.OnHovercolor = Color.FromArgb(221, 0, 0);

            this.Invoke((MethodInvoker)delegate { noPersonAlertLabel.Visible = false; });
        }
        public void correctPositionAppearance()
        { 

            settingPanelButton.Normalcolor = Color.FromArgb(26, 68, 33);
            settingPanelButton.OnHovercolor = Color.FromArgb(53, 138, 68);

            Disconnect_Button.Normalcolor = Color.FromArgb(26, 68, 33);
            Disconnect_Button.OnHovercolor = Color.FromArgb(53, 138, 68);

            this.Invoke((MethodInvoker)delegate { noPersonAlertLabel.Visible = false; });
        }

        int q = 0;

        private void showUITimer_Tick(object sender, EventArgs e)
        {
            if (q < showUITimerDelay) { q++; }
            else if (q == showUITimerDelay)
            {
                positionAlertForm.picturePath = pictureBox3.ImageLocation;
                positionAlertForm.setNotifyPictureBox1 = notifyPictureBox1.ImageLocation;
                positionAlertForm.setNotifyPictureBox2 = notifyPictureBox2.ImageLocation;
                positionAlertForm.Show();
                positionAlertForm.WindowState = FormWindowState.Maximized;
                positionAlertForm.Activate();
                BLComm._commStream.WriteByte(alertSendingByte);
                q++;
            }
            else
            {
                positionAlertForm.Show();
                positionAlertForm.WindowState = FormWindowState.Maximized;
                positionAlertForm.Activate();
            }
        }

        public string statusPicturePath
        {
            get { return pictureBox3.ImageLocation; }
        }

       public void changeInfoText(String text) { InfoBox.Text = text; }

        int direction1 = 0; // 0 - left/ 1 - right

        private void settingPanelButton_Click(object sender, EventArgs e)
        {

            if (settingPanelControl.Height == 36)
            {
                direction1 = 1;
                settingPanelTransitionTimer.Enabled = true;

            }
            else
            {
                direction1 = 0;
                settingPanelTransitionTimer.Enabled = true;
            }
        }

        private void settingPanelTransitionTimer_Tick(object sender, EventArgs e)
        {
            if (direction1 == 1)
            {
                if (settingPanelControl.Height >= 88) { settingPanelTransitionTimer.Enabled = false; settingPanelControl.Height = 88; }
                else { settingPanelControl.Height += 6; }
            }
            else
            {
                if (settingPanelControl.Height <= 36) { settingPanelTransitionTimer.Enabled = false; settingPanelControl.Height = 36; }
                else { settingPanelControl.Height -= 6; }
            }
        }

        int direction2 = 0; // 0-up / 1-down


        private void activityPanelBarButton_Click(object sender, EventArgs e)
        {
            if (isStatisticDataReceived == false /*&& activityPanelWaitingLabel.Visible != true*/)
            {
                updateActivityPanel(false);
                DateTime now = DateTime.Now;
                byte[] toSend = Encoding.ASCII.GetBytes("*a" + now.Year.ToString().Substring(now.Year.ToString().Length - 2) + "b" + now.Month.ToString() + "c" + now.Day.ToString() + "d");
                BLComm._commStream.Write(toSend, 0, toSend.Length);
                isStatisticDataReceived = true;
            }


            if (activityPanel.Height == 63)
            {
                direction2 = 1;
                activityPanelTransitionTimer.Enabled = true; // Animation for panel using timer
            }
            else
            {
                direction2 = 0;
                activityPanelTransitionTimer.Enabled = true; // Animation for panel using timer
            }

        }

        private void activityPanelTransitionTimer_Tick(object sender, EventArgs e)
        {
            if (direction2 == 1)
            {
                if (activityPanel.Height >= 441) { activityPanelTransitionTimer.Enabled = false; activityPanel.Height = 441; }
                else { activityPanel.Height += 20; }
            }
            else
            {
                if (activityPanel.Height <= 63) { activityPanelTransitionTimer.Enabled = false; activityPanel.Height = 63; }
                else { activityPanel.Height -= 20; }
            }
        }

        public void updateActivityPanel(bool state) // false- data not received / true - update data
        {
            if (state == true)
            {
                DateTime today = DateTime.Now;
                for (int i = 0; i <= GlobalVar.dateIndex; i++)
                {
                    if (GlobalVar.dates[i].data.Day == today.Day && GlobalVar.dates[i].data.Month == today.Month && GlobalVar.dates[i].data.Year == today.Year)
                    {
                        activityPanelChart.Series[0].Points.Clear();

                        activityPanelChart.Series[0].Points.Add((int)GlobalVar.dates[i].getCorrectTime());
                        activityPanelChart.Series[0].Points[0].Label = (GlobalVar.dates[i].getCorrectTime() * 100 / GlobalVar.dates[i].sumPer()).ToString("0.0") + "%";
                        activityPanelChart.Series[0].Points.Add((int)GlobalVar.dates[i].SRED);
                        activityPanelChart.Series[0].Points[1].Label = (GlobalVar.dates[i].SRED * 100 / GlobalVar.dates[i].sumPer()).ToString("0.0") + "%";

                        int[] sumPer = StatisticsForm.splitToComponentTimes(GlobalVar.dates[i].sumPer());
                        int[] sumRed = StatisticsForm.splitToComponentTimes(GlobalVar.dates[i].SRED);
                        int[] sumGreen = StatisticsForm.splitToComponentTimes(GlobalVar.dates[i].sumPer() - GlobalVar.dates[i].SRED);

                        activityPanelTotalTime.Text = /* sumPer[0] + "h " + sumPer[1] + "min " + sumPer[2] + "sec"; */  sumGreen[0] + "h " + sumGreen[1] + "min " + sumGreen[2] + "sec";
                        activityPanelWrongTime.Text = sumRed[0] + "h " + sumRed[1] + "min " + sumRed[2] + "sec";
                        activityPanelAlertCount.Text = GlobalVar.dates[i].alertCount.ToString();

                        float value = 1 - (GlobalVar.dates[i].SRED / GlobalVar.dates[i].sumPer());
                        if (value >= 0.99) activityPanelGrade.Text = "A";
                        else if (value >= 0.97) activityPanelGrade.Text = "B";
                        else activityPanelGrade.Text = "C";


                    }
                }
            }
            activityPanelWrongTimeLabel.Visible = state;
            activityPanelTotalTimeLabel.Visible = state;
            activityPanelAlertCountLabel.Visible = state;
            activityPanelGradeLabel.Visible = state;
            activityPanelTotalTime.Visible = state;
            activityPanelWrongTime.Visible = state;
            activityPanelAlertCount.Visible = state;
            activityPanelGrade.Visible = state;
            activityPanelChart.Visible = state;
            activityPanelTitle.Visible = state;
            activityPanelRefreshButton.Visible = state;
            activityPanelShowMoreButton.Visible = state;

            activityPanelWaitingLabel.Visible = !state;
        }

        private void activityPanelShowMoreButton_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                updateActivityPanel(true);
                statisticsForm.updateCalendar();
                statisticsForm.Show();
            });
            //  BLComm._commStream.WriteByte(yearDataSendingByte);
        }

        private void activityPanelRefreshButton_Click(object sender, EventArgs e)
        {
            updateActivityPanel(false);
            DateTime now = DateTime.Now;
            byte[] toSend = Encoding.ASCII.GetBytes("*a" + now.Year.ToString().Substring(now.Year.ToString().Length - 2) + "b" + now.Month.ToString() + "c" + now.Day.ToString() + "d");
            BLComm._commStream.Write(toSend, 0, toSend.Length);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            positionAlertForm.Activate();
        }

        private void FormCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMinimizeButton_Click(object sender, EventArgs e)
        {
            AppTrayIcon.Visible = true;
            AppTrayIcon.ShowBalloonTip(1000);
            this.Hide();
        }

        private void AppTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            AppTrayIcon.Visible = false;
        }

        private void calibratingTimer_Tick(object sender, EventArgs e)
        {
            int number = int.Parse(calibratingCounterLabel.Text);
            number--;
            if(number == 0)
            {
                calibratingTimer.Stop();
                calibratingCounterLabel.Text = "7";
                connectionRecvTimer.Start();
                connectionSendTimer.Start();
                Calibrating_Panel.Visible = false;
            }
            else
            {
                calibratingCounterLabel.Text = number.ToString();
            }
        }

        private void showUITimerDelayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(showUITimerDelayComboBox.SelectedIndex)
            {
                case 0:
                    showUITimerDelay = 2;
                    break;
                case 1:
                    showUITimerDelay = 5;
                    break;
                case 2:
                    showUITimerDelay = 10;
                    break;
            }
        }
    }

}
[Serializable]
public static class BLComm
{
    public static BluetoothClient _client;
    public static BluetoothDeviceInfo _connectedDevice;
    public static Guid _guid;
    public static NetworkStream _commStream;
}

public static class GlobalVar
{
    public static int dateIndex = -1;
    public static date[] dates = new date[3000];
}

