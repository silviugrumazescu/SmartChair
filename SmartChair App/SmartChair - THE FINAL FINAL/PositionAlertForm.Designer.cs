namespace SmartChair___THE_FINAL_FINAL
{
    partial class PositionAlertForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionAlertForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.statusPictureBox = new System.Windows.Forms.PictureBox();
            this.notifyPictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyPictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Perpetua Titling MT", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(297, 20);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(667, 186);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "POZITIA TA PE SCAUN ESTE INCORECTA";
            this.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusPictureBox
            // 
            this.statusPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.statusPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("statusPictureBox.Image")));
            this.statusPictureBox.Location = new System.Drawing.Point(545, 180);
            this.statusPictureBox.Name = "statusPictureBox";
            this.statusPictureBox.Size = new System.Drawing.Size(454, 420);
            this.statusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statusPictureBox.TabIndex = 9;
            this.statusPictureBox.TabStop = false;
            // 
            // notifyPictureBox1
            // 
            this.notifyPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notifyPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("notifyPictureBox1.Image")));
            this.notifyPictureBox1.Location = new System.Drawing.Point(191, 209);
            this.notifyPictureBox1.Name = "notifyPictureBox1";
            this.notifyPictureBox1.Size = new System.Drawing.Size(314, 102);
            this.notifyPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.notifyPictureBox1.TabIndex = 12;
            this.notifyPictureBox1.TabStop = false;
            // 
            // notifyPictureBox2
            // 
            this.notifyPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notifyPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("notifyPictureBox2.Image")));
            this.notifyPictureBox2.Location = new System.Drawing.Point(191, 317);
            this.notifyPictureBox2.Name = "notifyPictureBox2";
            this.notifyPictureBox2.Size = new System.Drawing.Size(314, 102);
            this.notifyPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.notifyPictureBox2.TabIndex = 12;
            this.notifyPictureBox2.TabStop = false;
            // 
            // PositionAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1218, 743);
            this.Controls.Add(this.notifyPictureBox2);
            this.Controls.Add(this.notifyPictureBox1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.statusPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PositionAlertForm";
            this.Text = "PositionAlertForm";
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.PictureBox statusPictureBox;
        private System.Windows.Forms.PictureBox notifyPictureBox2;
        private System.Windows.Forms.PictureBox notifyPictureBox1;
    }
}