using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartChair___THE_FINAL_FINAL
{
    public partial class PositionAlertForm : Form
    {

        System.Timers.Timer closeDelayTimer = new System.Timers.Timer();

        public PositionAlertForm()
        {
            InitializeComponent();

            closeDelayTimer.Interval = 1000;
            closeDelayTimer.Enabled = false;
            closeDelayTimer.Elapsed += new System.Timers.ElapsedEventHandler(closeDelayTimer_Elapsed);
          
        }
        public string picturePath
        {
            set { statusPictureBox.ImageLocation = value; }
        }
        public string setNotifyPictureBox1
        {
            set { notifyPictureBox1.ImageLocation = value; }
        }
        public string setNotifyPictureBox2
        {
            set { notifyPictureBox2.ImageLocation = value; }
        }

        public void Destroy()
        {
            closeDelayTimer.Start();
        }

        private void closeDelayTimer_Elapsed(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate { this.Hide(); });
                closeDelayTimer.Stop();
            }
            else
            {
                this.CreateHandle();
                this.Invoke((MethodInvoker)delegate { this.Hide(); });
                closeDelayTimer.Stop();
            }
        }
    }
}
