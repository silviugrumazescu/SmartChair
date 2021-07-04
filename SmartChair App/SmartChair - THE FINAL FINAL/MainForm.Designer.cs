namespace SmartChair___THE_FINAL_FINAL
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Connect_Button = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.InfoBox = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.InfoBox_Label = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Calibrating_Panel = new System.Windows.Forms.Panel();
            this.calibratingCounterLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.activityPanel = new System.Windows.Forms.Panel();
            this.activityPanelBarButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bottomPanelBorder = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelAlertCountLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelAlertCount = new System.Windows.Forms.Label();
            this.activityPanelShowMoreButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.activityPanelTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.activityPanelGrade = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelGradeLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelWrongTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelTotalTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelWrongTimeLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelTotalTimeLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.activityPanelRefreshButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.activityPanelWaitingLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.noPersonAlertLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.notifyPictureBox2 = new System.Windows.Forms.PictureBox();
            this.notifyPictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Welcome_Label = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.FormCloseButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.FormMinimizeButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.settingPanelControl = new System.Windows.Forms.Panel();
            this.showUITimerDelayComboBox = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.settingPanelButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Disconnect_Button = new Bunifu.Framework.UI.BunifuFlatButton();
            this.settingPanelStatusLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.settingPanelTransitionTimer = new System.Windows.Forms.Timer(this.components);
            this.activityPanelTransitionTimer = new System.Windows.Forms.Timer(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.connectWorker = new System.ComponentModel.BackgroundWorker();
            this.readDataWorker = new System.ComponentModel.BackgroundWorker();
            this.showUITimer = new System.Windows.Forms.Timer(this.components);
            this.AppTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.calibratingTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.Calibrating_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.activityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityPanelChart)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormCloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormMinimizeButton)).BeginInit();
            this.settingPanelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(538, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.Connect_Button);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.InfoBox);
            this.tabPage1.Controls.Add(this.InfoBox_Label);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(530, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // Connect_Button
            // 
            this.Connect_Button.ActiveBorderThickness = 1;
            this.Connect_Button.ActiveCornerRadius = 1;
            this.Connect_Button.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.Connect_Button.ActiveForecolor = System.Drawing.Color.White;
            this.Connect_Button.ActiveLineColor = System.Drawing.Color.White;
            this.Connect_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Connect_Button.AutoSize = true;
            this.Connect_Button.BackColor = System.Drawing.Color.White;
            this.Connect_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Connect_Button.BackgroundImage")));
            this.Connect_Button.ButtonText = "FIND MY CHAIR";
            this.Connect_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Connect_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.Connect_Button.IdleBorderThickness = 1;
            this.Connect_Button.IdleCornerRadius = 1;
            this.Connect_Button.IdleFillColor = System.Drawing.Color.White;
            this.Connect_Button.IdleForecolor = System.Drawing.Color.Black;
            this.Connect_Button.IdleLineColor = System.Drawing.Color.Black;
            this.Connect_Button.Location = new System.Drawing.Point(139, 305);
            this.Connect_Button.Margin = new System.Windows.Forms.Padding(5);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(270, 68);
            this.Connect_Button.TabIndex = 7;
            this.Connect_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 74);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(143, 139);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // InfoBox
            // 
            this.InfoBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.InfoBox.Location = new System.Drawing.Point(167, 74);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(282, 165);
            this.InfoBox.TabIndex = 5;
            this.InfoBox.Text = "Scaun deconectat!";
            this.InfoBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoBox_Label
            // 
            this.InfoBox_Label.BackColor = System.Drawing.Color.Transparent;
            this.InfoBox_Label.Location = new System.Drawing.Point(46, 191);
            this.InfoBox_Label.Name = "InfoBox_Label";
            this.InfoBox_Label.Size = new System.Drawing.Size(272, 65);
            this.InfoBox_Label.TabIndex = 2;
            this.InfoBox_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Calibrating_Panel);
            this.tabPage2.Controls.Add(this.activityPanel);
            this.tabPage2.Controls.Add(this.mainPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(530, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Calibrating_Panel
            // 
            this.Calibrating_Panel.Controls.Add(this.calibratingCounterLabel);
            this.Calibrating_Panel.Controls.Add(this.label1);
            this.Calibrating_Panel.Controls.Add(this.pictureBox1);
            this.Calibrating_Panel.Location = new System.Drawing.Point(0, 0);
            this.Calibrating_Panel.Name = "Calibrating_Panel";
            this.Calibrating_Panel.Size = new System.Drawing.Size(529, 445);
            this.Calibrating_Panel.TabIndex = 11;
            this.Calibrating_Panel.Visible = false;
            // 
            // calibratingCounterLabel
            // 
            this.calibratingCounterLabel.AutoSize = true;
            this.calibratingCounterLabel.Font = new System.Drawing.Font("Minion Pro", 99.74999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibratingCounterLabel.ForeColor = System.Drawing.Color.Maroon;
            this.calibratingCounterLabel.Location = new System.Drawing.Point(91, 175);
            this.calibratingCounterLabel.Name = "calibratingCounterLabel";
            this.calibratingCounterLabel.Size = new System.Drawing.Size(139, 179);
            this.calibratingCounterLabel.TabIndex = 2;
            this.calibratingCounterLabel.Text = "7";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Adobe Devanagari", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(85, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "THE CHAIR IS CURRENTLY CALIBRATING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(202, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(325, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // activityPanel
            // 
            this.activityPanel.BackColor = System.Drawing.Color.White;
            this.activityPanel.Controls.Add(this.activityPanelBarButton);
            this.activityPanel.Controls.Add(this.bottomPanelBorder);
            this.activityPanel.Controls.Add(this.activityPanelAlertCountLabel);
            this.activityPanel.Controls.Add(this.activityPanelAlertCount);
            this.activityPanel.Controls.Add(this.activityPanelShowMoreButton);
            this.activityPanel.Controls.Add(this.activityPanelTitle);
            this.activityPanel.Controls.Add(this.activityPanelChart);
            this.activityPanel.Controls.Add(this.activityPanelGrade);
            this.activityPanel.Controls.Add(this.activityPanelGradeLabel);
            this.activityPanel.Controls.Add(this.activityPanelWrongTime);
            this.activityPanel.Controls.Add(this.activityPanelTotalTime);
            this.activityPanel.Controls.Add(this.activityPanelWrongTimeLabel);
            this.activityPanel.Controls.Add(this.activityPanelTotalTimeLabel);
            this.activityPanel.Controls.Add(this.activityPanelRefreshButton);
            this.activityPanel.Controls.Add(this.activityPanelWaitingLabel);
            this.activityPanel.Controls.Add(this.bunifuCustomLabel3);
            this.activityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.activityPanel.Location = new System.Drawing.Point(3, 3);
            this.activityPanel.Name = "activityPanel";
            this.activityPanel.Size = new System.Drawing.Size(524, 63);
            this.activityPanel.TabIndex = 1;
            // 
            // activityPanelBarButton
            // 
            this.activityPanelBarButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.activityPanelBarButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.activityPanelBarButton.BackColor = System.Drawing.Color.White;
            this.activityPanelBarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.activityPanelBarButton.BorderRadius = 0;
            this.activityPanelBarButton.ButtonText = "ACTIVITY PANEL";
            this.activityPanelBarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activityPanelBarButton.DisabledColor = System.Drawing.Color.Gray;
            this.activityPanelBarButton.Iconcolor = System.Drawing.Color.Transparent;
            this.activityPanelBarButton.Iconimage = null;
            this.activityPanelBarButton.Iconimage_right = null;
            this.activityPanelBarButton.Iconimage_right_Selected = null;
            this.activityPanelBarButton.Iconimage_Selected = null;
            this.activityPanelBarButton.IconMarginLeft = 0;
            this.activityPanelBarButton.IconMarginRight = 0;
            this.activityPanelBarButton.IconRightVisible = false;
            this.activityPanelBarButton.IconRightZoom = 0D;
            this.activityPanelBarButton.IconVisible = false;
            this.activityPanelBarButton.IconZoom = 90D;
            this.activityPanelBarButton.IsTab = false;
            this.activityPanelBarButton.Location = new System.Drawing.Point(0, 17);
            this.activityPanelBarButton.Margin = new System.Windows.Forms.Padding(0);
            this.activityPanelBarButton.Name = "activityPanelBarButton";
            this.activityPanelBarButton.Normalcolor = System.Drawing.Color.White;
            this.activityPanelBarButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelBarButton.OnHoverTextColor = System.Drawing.Color.White;
            this.activityPanelBarButton.selected = false;
            this.activityPanelBarButton.Size = new System.Drawing.Size(524, 46);
            this.activityPanelBarButton.TabIndex = 8;
            this.activityPanelBarButton.Text = "ACTIVITY PANEL";
            this.activityPanelBarButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.activityPanelBarButton.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelBarButton.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.activityPanelBarButton.Click += new System.EventHandler(this.activityPanelBarButton_Click);
            // 
            // bottomPanelBorder
            // 
            this.bottomPanelBorder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bottomPanelBorder.AutoSize = true;
            this.bottomPanelBorder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.bottomPanelBorder.Location = new System.Drawing.Point(0, 50);
            this.bottomPanelBorder.Name = "bottomPanelBorder";
            this.bottomPanelBorder.Size = new System.Drawing.Size(685, 26);
            this.bottomPanelBorder.TabIndex = 11;
            this.bottomPanelBorder.Text = "_________________________________________________________________________________" +
    "________________________________\r\n___";
            // 
            // activityPanelAlertCountLabel
            // 
            this.activityPanelAlertCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activityPanelAlertCountLabel.AutoSize = true;
            this.activityPanelAlertCountLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityPanelAlertCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelAlertCountLabel.Location = new System.Drawing.Point(223, 138);
            this.activityPanelAlertCountLabel.Name = "activityPanelAlertCountLabel";
            this.activityPanelAlertCountLabel.Size = new System.Drawing.Size(89, 27);
            this.activityPanelAlertCountLabel.TabIndex = 12;
            this.activityPanelAlertCountLabel.Text = "ALERTE";
            // 
            // activityPanelAlertCount
            // 
            this.activityPanelAlertCount.AutoSize = true;
            this.activityPanelAlertCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.activityPanelAlertCount.ForeColor = System.Drawing.Color.Red;
            this.activityPanelAlertCount.Location = new System.Drawing.Point(252, 358);
            this.activityPanelAlertCount.Name = "activityPanelAlertCount";
            this.activityPanelAlertCount.Size = new System.Drawing.Size(27, 29);
            this.activityPanelAlertCount.TabIndex = 13;
            this.activityPanelAlertCount.Text = "7";
            // 
            // activityPanelShowMoreButton
            // 
            this.activityPanelShowMoreButton.Activecolor = System.Drawing.Color.Transparent;
            this.activityPanelShowMoreButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activityPanelShowMoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelShowMoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.activityPanelShowMoreButton.BorderRadius = 0;
            this.activityPanelShowMoreButton.ButtonText = "VEZI DETALII";
            this.activityPanelShowMoreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activityPanelShowMoreButton.DisabledColor = System.Drawing.Color.Transparent;
            this.activityPanelShowMoreButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(243)))), ((int)(((byte)(237)))));
            this.activityPanelShowMoreButton.Iconcolor = System.Drawing.Color.Transparent;
            this.activityPanelShowMoreButton.Iconimage = null;
            this.activityPanelShowMoreButton.Iconimage_right = null;
            this.activityPanelShowMoreButton.Iconimage_right_Selected = null;
            this.activityPanelShowMoreButton.Iconimage_Selected = null;
            this.activityPanelShowMoreButton.IconMarginLeft = 0;
            this.activityPanelShowMoreButton.IconMarginRight = 0;
            this.activityPanelShowMoreButton.IconRightVisible = false;
            this.activityPanelShowMoreButton.IconRightZoom = 0D;
            this.activityPanelShowMoreButton.IconVisible = false;
            this.activityPanelShowMoreButton.IconZoom = 90D;
            this.activityPanelShowMoreButton.IsTab = false;
            this.activityPanelShowMoreButton.Location = new System.Drawing.Point(-3, -169);
            this.activityPanelShowMoreButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.activityPanelShowMoreButton.Name = "activityPanelShowMoreButton";
            this.activityPanelShowMoreButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelShowMoreButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelShowMoreButton.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(84)))));
            this.activityPanelShowMoreButton.selected = false;
            this.activityPanelShowMoreButton.Size = new System.Drawing.Size(157, 36);
            this.activityPanelShowMoreButton.TabIndex = 0;
            this.activityPanelShowMoreButton.Text = "VEZI DETALII";
            this.activityPanelShowMoreButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.activityPanelShowMoreButton.Textcolor = System.Drawing.Color.White;
            this.activityPanelShowMoreButton.TextFont = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityPanelShowMoreButton.Click += new System.EventHandler(this.activityPanelShowMoreButton_Click);
            // 
            // activityPanelTitle
            // 
            this.activityPanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activityPanelTitle.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.activityPanelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelTitle.Location = new System.Drawing.Point(165, -177);
            this.activityPanelTitle.Name = "activityPanelTitle";
            this.activityPanelTitle.Size = new System.Drawing.Size(194, 78);
            this.activityPanelTitle.TabIndex = 1;
            this.activityPanelTitle.Text = "STATISTICILE DE AZI";
            this.activityPanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // activityPanelChart
            // 
            this.activityPanelChart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activityPanelChart.BorderlineColor = System.Drawing.SystemColors.WindowFrame;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.activityPanelChart.ChartAreas.Add(chartArea2);
            this.activityPanelChart.Location = new System.Drawing.Point(0, -82);
            this.activityPanelChart.Name = "activityPanelChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Name = "Series1";
            this.activityPanelChart.Series.Add(series2);
            this.activityPanelChart.Size = new System.Drawing.Size(300, 216);
            this.activityPanelChart.TabIndex = 2;
            this.activityPanelChart.Text = "chart1";
            // 
            // activityPanelGrade
            // 
            this.activityPanelGrade.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activityPanelGrade.AutoSize = true;
            this.activityPanelGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.activityPanelGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelGrade.Location = new System.Drawing.Point(334, 12);
            this.activityPanelGrade.Name = "activityPanelGrade";
            this.activityPanelGrade.Size = new System.Drawing.Size(109, 108);
            this.activityPanelGrade.TabIndex = 6;
            this.activityPanelGrade.Text = "A";
            // 
            // activityPanelGradeLabel
            // 
            this.activityPanelGradeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activityPanelGradeLabel.AutoSize = true;
            this.activityPanelGradeLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityPanelGradeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelGradeLabel.Location = new System.Drawing.Point(286, -62);
            this.activityPanelGradeLabel.Name = "activityPanelGradeLabel";
            this.activityPanelGradeLabel.Size = new System.Drawing.Size(199, 64);
            this.activityPanelGradeLabel.TabIndex = 6;
            this.activityPanelGradeLabel.Text = "GRADE";
            // 
            // activityPanelWrongTime
            // 
            this.activityPanelWrongTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activityPanelWrongTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(143)))), ((int)(((byte)(130)))));
            this.activityPanelWrongTime.Location = new System.Drawing.Point(371, 189);
            this.activityPanelWrongTime.Name = "activityPanelWrongTime";
            this.activityPanelWrongTime.Size = new System.Drawing.Size(148, 13);
            this.activityPanelWrongTime.TabIndex = 4;
            this.activityPanelWrongTime.Text = "1h 20 min 30 sec";
            this.activityPanelWrongTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // activityPanelTotalTime
            // 
            this.activityPanelTotalTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activityPanelTotalTime.AutoSize = true;
            this.activityPanelTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(143)))), ((int)(((byte)(130)))));
            this.activityPanelTotalTime.Location = new System.Drawing.Point(4, 189);
            this.activityPanelTotalTime.Name = "activityPanelTotalTime";
            this.activityPanelTotalTime.Size = new System.Drawing.Size(91, 13);
            this.activityPanelTotalTime.TabIndex = 4;
            this.activityPanelTotalTime.Text = "1 h 20 min 30 sec";
            // 
            // activityPanelWrongTimeLabel
            // 
            this.activityPanelWrongTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.activityPanelWrongTimeLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityPanelWrongTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelWrongTimeLabel.Location = new System.Drawing.Point(405, 138);
            this.activityPanelWrongTimeLabel.Name = "activityPanelWrongTimeLabel";
            this.activityPanelWrongTimeLabel.Size = new System.Drawing.Size(116, 51);
            this.activityPanelWrongTimeLabel.TabIndex = 3;
            this.activityPanelWrongTimeLabel.Text = "TIMP POZITIE INCORECTA:";
            this.activityPanelWrongTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // activityPanelTotalTimeLabel
            // 
            this.activityPanelTotalTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activityPanelTotalTimeLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityPanelTotalTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelTotalTimeLabel.Location = new System.Drawing.Point(1, 138);
            this.activityPanelTotalTimeLabel.Name = "activityPanelTotalTimeLabel";
            this.activityPanelTotalTimeLabel.Size = new System.Drawing.Size(116, 51);
            this.activityPanelTotalTimeLabel.TabIndex = 3;
            this.activityPanelTotalTimeLabel.Text = "TIMP POZITIE CORECTA:";
            // 
            // activityPanelRefreshButton
            // 
            this.activityPanelRefreshButton.Activecolor = System.Drawing.Color.Transparent;
            this.activityPanelRefreshButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.activityPanelRefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelRefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.activityPanelRefreshButton.BorderRadius = 0;
            this.activityPanelRefreshButton.ButtonText = "REFRESH";
            this.activityPanelRefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activityPanelRefreshButton.DisabledColor = System.Drawing.Color.Transparent;
            this.activityPanelRefreshButton.ForeColor = System.Drawing.Color.White;
            this.activityPanelRefreshButton.Iconcolor = System.Drawing.Color.Transparent;
            this.activityPanelRefreshButton.Iconimage = null;
            this.activityPanelRefreshButton.Iconimage_right = null;
            this.activityPanelRefreshButton.Iconimage_right_Selected = null;
            this.activityPanelRefreshButton.Iconimage_Selected = null;
            this.activityPanelRefreshButton.IconMarginLeft = 0;
            this.activityPanelRefreshButton.IconMarginRight = 0;
            this.activityPanelRefreshButton.IconRightVisible = false;
            this.activityPanelRefreshButton.IconRightZoom = 0D;
            this.activityPanelRefreshButton.IconVisible = false;
            this.activityPanelRefreshButton.IconZoom = 90D;
            this.activityPanelRefreshButton.IsTab = false;
            this.activityPanelRefreshButton.Location = new System.Drawing.Point(369, -169);
            this.activityPanelRefreshButton.Name = "activityPanelRefreshButton";
            this.activityPanelRefreshButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelRefreshButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.activityPanelRefreshButton.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(84)))));
            this.activityPanelRefreshButton.selected = false;
            this.activityPanelRefreshButton.Size = new System.Drawing.Size(157, 36);
            this.activityPanelRefreshButton.TabIndex = 0;
            this.activityPanelRefreshButton.Text = "REFRESH";
            this.activityPanelRefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.activityPanelRefreshButton.Textcolor = System.Drawing.Color.White;
            this.activityPanelRefreshButton.TextFont = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityPanelRefreshButton.Click += new System.EventHandler(this.activityPanelRefreshButton_Click);
            // 
            // activityPanelWaitingLabel
            // 
            this.activityPanelWaitingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.activityPanelWaitingLabel.AutoSize = true;
            this.activityPanelWaitingLabel.Font = new System.Drawing.Font("Minion Pro", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityPanelWaitingLabel.Location = new System.Drawing.Point(121, 12);
            this.activityPanelWaitingLabel.Name = "activityPanelWaitingLabel";
            this.activityPanelWaitingLabel.Size = new System.Drawing.Size(302, 50);
            this.activityPanelWaitingLabel.TabIndex = 7;
            this.activityPanelWaitingLabel.Text = "Se așteaptă datele...";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(-34, 4);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(685, 18);
            this.bunifuCustomLabel3.TabIndex = 14;
            this.bunifuCustomLabel3.Text = "_________________________________________________________________________________" +
    "________________________________\r\n___";
            this.bunifuCustomLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.noPersonAlertLabel);
            this.mainPanel.Controls.Add(this.notifyPictureBox2);
            this.mainPanel.Controls.Add(this.notifyPictureBox1);
            this.mainPanel.Controls.Add(this.pictureBox3);
            this.mainPanel.Location = new System.Drawing.Point(0, 50);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(534, 392);
            this.mainPanel.TabIndex = 3;
            // 
            // noPersonAlertLabel
            // 
            this.noPersonAlertLabel.Font = new System.Drawing.Font("Myriad Arabic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPersonAlertLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.noPersonAlertLabel.Location = new System.Drawing.Point(0, 9);
            this.noPersonAlertLabel.Name = "noPersonAlertLabel";
            this.noPersonAlertLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.noPersonAlertLabel.Size = new System.Drawing.Size(534, 88);
            this.noPersonAlertLabel.TabIndex = 10;
            this.noPersonAlertLabel.Text = "SCAUN NEOCUPAT";
            this.noPersonAlertLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noPersonAlertLabel.Visible = false;
            // 
            // notifyPictureBox2
            // 
            this.notifyPictureBox2.Location = new System.Drawing.Point(327, 24);
            this.notifyPictureBox2.Name = "notifyPictureBox2";
            this.notifyPictureBox2.Size = new System.Drawing.Size(197, 64);
            this.notifyPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.notifyPictureBox2.TabIndex = 9;
            this.notifyPictureBox2.TabStop = false;
            // 
            // notifyPictureBox1
            // 
            this.notifyPictureBox1.Location = new System.Drawing.Point(3, 24);
            this.notifyPictureBox1.Name = "notifyPictureBox1";
            this.notifyPictureBox1.Size = new System.Drawing.Size(197, 64);
            this.notifyPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.notifyPictureBox1.TabIndex = 9;
            this.notifyPictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(92, 68);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(354, 318);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // Welcome_Label
            // 
            this.Welcome_Label.AutoSize = true;
            this.Welcome_Label.BackColor = System.Drawing.Color.White;
            this.Welcome_Label.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.Welcome_Label.Location = new System.Drawing.Point(25, 25);
            this.Welcome_Label.Name = "Welcome_Label";
            this.Welcome_Label.Size = new System.Drawing.Size(203, 42);
            this.Welcome_Label.TabIndex = 6;
            this.Welcome_Label.Text = "WELCOME!";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 1;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.FormCloseButton);
            this.panel1.Controls.Add(this.FormMinimizeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 44);
            this.panel1.TabIndex = 1;
            // 
            // FormCloseButton
            // 
            this.FormCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FormCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.FormCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("FormCloseButton.Image")));
            this.FormCloseButton.ImageActive = null;
            this.FormCloseButton.Location = new System.Drawing.Point(498, 4);
            this.FormCloseButton.Name = "FormCloseButton";
            this.FormCloseButton.Size = new System.Drawing.Size(35, 35);
            this.FormCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FormCloseButton.TabIndex = 2;
            this.FormCloseButton.TabStop = false;
            this.FormCloseButton.Zoom = 10;
            this.FormCloseButton.Click += new System.EventHandler(this.FormCloseButton_Click);
            // 
            // FormMinimizeButton
            // 
            this.FormMinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FormMinimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.FormMinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("FormMinimizeButton.Image")));
            this.FormMinimizeButton.ImageActive = null;
            this.FormMinimizeButton.Location = new System.Drawing.Point(457, 4);
            this.FormMinimizeButton.Name = "FormMinimizeButton";
            this.FormMinimizeButton.Size = new System.Drawing.Size(35, 35);
            this.FormMinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FormMinimizeButton.TabIndex = 2;
            this.FormMinimizeButton.TabStop = false;
            this.FormMinimizeButton.Zoom = 10;
            this.FormMinimizeButton.Click += new System.EventHandler(this.FormMinimizeButton_Click);
            // 
            // settingPanelControl
            // 
            this.settingPanelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(143)))), ((int)(((byte)(130)))));
            this.settingPanelControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingPanelControl.Controls.Add(this.showUITimerDelayComboBox);
            this.settingPanelControl.Controls.Add(this.bunifuCustomLabel2);
            this.settingPanelControl.Controls.Add(this.settingPanelButton);
            this.settingPanelControl.Controls.Add(this.Disconnect_Button);
            this.settingPanelControl.Controls.Add(this.settingPanelStatusLabel);
            this.settingPanelControl.Controls.Add(this.bunifuCustomLabel1);
            this.settingPanelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingPanelControl.Location = new System.Drawing.Point(0, 464);
            this.settingPanelControl.Name = "settingPanelControl";
            this.settingPanelControl.Size = new System.Drawing.Size(538, 36);
            this.settingPanelControl.TabIndex = 2;
            // 
            // showUITimerDelayComboBox
            // 
            this.showUITimerDelayComboBox.BackColor = System.Drawing.Color.Bisque;
            this.showUITimerDelayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.showUITimerDelayComboBox.FormattingEnabled = true;
            this.showUITimerDelayComboBox.Items.AddRange(new object[] {
            "2 secunde",
            "5 secunde",
            "10 secunde"});
            this.showUITimerDelayComboBox.Location = new System.Drawing.Point(155, 59);
            this.showUITimerDelayComboBox.Name = "showUITimerDelayComboBox";
            this.showUITimerDelayComboBox.Size = new System.Drawing.Size(119, 21);
            this.showUITimerDelayComboBox.TabIndex = 8;
            this.showUITimerDelayComboBox.SelectedIndexChanged += new System.EventHandler(this.showUITimerDelayComboBox_SelectedIndexChanged);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(151, 39);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(160, 21);
            this.bunifuCustomLabel2.TabIndex = 5;
            this.bunifuCustomLabel2.Text = "DURATA BLOCARE:";
            // 
            // settingPanelButton
            // 
            this.settingPanelButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.settingPanelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(84)))));
            this.settingPanelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingPanelButton.BorderRadius = 0;
            this.settingPanelButton.ButtonText = "SETTINGS";
            this.settingPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPanelButton.DisabledColor = System.Drawing.Color.Gray;
            this.settingPanelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingPanelButton.Iconcolor = System.Drawing.Color.Transparent;
            this.settingPanelButton.Iconimage = null;
            this.settingPanelButton.Iconimage_right = null;
            this.settingPanelButton.Iconimage_right_Selected = null;
            this.settingPanelButton.Iconimage_Selected = null;
            this.settingPanelButton.IconMarginLeft = 0;
            this.settingPanelButton.IconMarginRight = 0;
            this.settingPanelButton.IconRightVisible = true;
            this.settingPanelButton.IconRightZoom = 0D;
            this.settingPanelButton.IconVisible = true;
            this.settingPanelButton.IconZoom = 90D;
            this.settingPanelButton.IsTab = false;
            this.settingPanelButton.Location = new System.Drawing.Point(0, 0);
            this.settingPanelButton.Name = "settingPanelButton";
            this.settingPanelButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(84)))));
            this.settingPanelButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(95)))), ((int)(((byte)(140)))));
            this.settingPanelButton.OnHoverTextColor = System.Drawing.Color.White;
            this.settingPanelButton.selected = false;
            this.settingPanelButton.Size = new System.Drawing.Size(536, 36);
            this.settingPanelButton.TabIndex = 4;
            this.settingPanelButton.Text = "SETTINGS";
            this.settingPanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingPanelButton.Textcolor = System.Drawing.Color.White;
            this.settingPanelButton.TextFont = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settingPanelButton.Click += new System.EventHandler(this.settingPanelButton_Click);
            // 
            // Disconnect_Button
            // 
            this.Disconnect_Button.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.Disconnect_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Disconnect_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(78)))));
            this.Disconnect_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Disconnect_Button.BorderRadius = 0;
            this.Disconnect_Button.ButtonText = "DISCONNECT";
            this.Disconnect_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Disconnect_Button.DisabledColor = System.Drawing.Color.Gray;
            this.Disconnect_Button.Iconcolor = System.Drawing.Color.Transparent;
            this.Disconnect_Button.Iconimage = null;
            this.Disconnect_Button.Iconimage_right = null;
            this.Disconnect_Button.Iconimage_right_Selected = null;
            this.Disconnect_Button.Iconimage_Selected = null;
            this.Disconnect_Button.IconMarginLeft = 0;
            this.Disconnect_Button.IconMarginRight = 0;
            this.Disconnect_Button.IconRightVisible = true;
            this.Disconnect_Button.IconRightZoom = 0D;
            this.Disconnect_Button.IconVisible = true;
            this.Disconnect_Button.IconZoom = 90D;
            this.Disconnect_Button.IsTab = false;
            this.Disconnect_Button.Location = new System.Drawing.Point(429, 11);
            this.Disconnect_Button.Name = "Disconnect_Button";
            this.Disconnect_Button.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(78)))));
            this.Disconnect_Button.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(77)))), ((int)(((byte)(2)))));
            this.Disconnect_Button.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(44)))), ((int)(((byte)(78)))));
            this.Disconnect_Button.selected = false;
            this.Disconnect_Button.Size = new System.Drawing.Size(103, 48);
            this.Disconnect_Button.TabIndex = 3;
            this.Disconnect_Button.Text = "DISCONNECT";
            this.Disconnect_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Disconnect_Button.Textcolor = System.Drawing.Color.White;
            this.Disconnect_Button.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Disconnect_Button.Click += new System.EventHandler(this.Disconnect_Button_Click);
            // 
            // settingPanelStatusLabel
            // 
            this.settingPanelStatusLabel.AutoSize = true;
            this.settingPanelStatusLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settingPanelStatusLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.settingPanelStatusLabel.Location = new System.Drawing.Point(10, 60);
            this.settingPanelStatusLabel.Name = "settingPanelStatusLabel";
            this.settingPanelStatusLabel.Size = new System.Drawing.Size(107, 16);
            this.settingPanelStatusLabel.TabIndex = 2;
            this.settingPanelStatusLabel.Text = "DISCONNECTED";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(9, 39);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(70, 21);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "STATUS:";
            // 
            // settingPanelTransitionTimer
            // 
            this.settingPanelTransitionTimer.Interval = 1;
            this.settingPanelTransitionTimer.Tick += new System.EventHandler(this.settingPanelTransitionTimer_Tick);
            // 
            // activityPanelTransitionTimer
            // 
            this.activityPanelTransitionTimer.Interval = 1;
            this.activityPanelTransitionTimer.Tick += new System.EventHandler(this.activityPanelTransitionTimer_Tick);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // connectWorker
            // 
            this.connectWorker.WorkerSupportsCancellation = true;
            this.connectWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connectWorker_DoWork);
            // 
            // readDataWorker
            // 
            this.readDataWorker.WorkerSupportsCancellation = true;
            this.readDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.readDataWorker_DoWork);
            this.readDataWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.readDataWorker_RunWorkerCompleted);
            // 
            // showUITimer
            // 
            this.showUITimer.Interval = 750;
            this.showUITimer.Tick += new System.EventHandler(this.showUITimer_Tick);
            // 
            // AppTrayIcon
            // 
            this.AppTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.AppTrayIcon.BalloonTipText = "The application is being held in the task bar";
            this.AppTrayIcon.BalloonTipTitle = "SmartChair";
            this.AppTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AppTrayIcon.Icon")));
            this.AppTrayIcon.Text = "The application is being held in the task bar";
            this.AppTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppTrayIcon_MouseDoubleClick);
            // 
            // calibratingTimer
            // 
            this.calibratingTimer.Interval = 1000;
            this.calibratingTimer.Tick += new System.EventHandler(this.calibratingTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(538, 500);
            this.Controls.Add(this.Welcome_Label);
            this.Controls.Add(this.settingPanelControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.Calibrating_Panel.ResumeLayout(false);
            this.Calibrating_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.activityPanel.ResumeLayout(false);
            this.activityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityPanelChart)).EndInit();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormCloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormMinimizeButton)).EndInit();
            this.settingPanelControl.ResumeLayout(false);
            this.settingPanelControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Bunifu.Framework.UI.BunifuCustomLabel InfoBox_Label;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel settingPanelControl;
        private Bunifu.Framework.UI.BunifuCustomLabel settingPanelStatusLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton FormCloseButton;
        private Bunifu.Framework.UI.BunifuImageButton FormMinimizeButton;
        private System.Windows.Forms.Panel activityPanel;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelWaitingLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelGrade;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelGradeLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelWrongTime;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelTotalTime;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelWrongTimeLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelTotalTimeLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart activityPanelChart;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelTitle;
        private Bunifu.Framework.UI.BunifuFlatButton activityPanelShowMoreButton;
        private System.Windows.Forms.Timer settingPanelTransitionTimer;
        private System.Windows.Forms.Timer activityPanelTransitionTimer;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.ComponentModel.BackgroundWorker connectWorker;
        private System.ComponentModel.BackgroundWorker readDataWorker;
        private System.Windows.Forms.Timer showUITimer;
        private Bunifu.Framework.UI.BunifuFlatButton Disconnect_Button;
        private Bunifu.Framework.UI.BunifuFlatButton settingPanelButton;
        private System.Windows.Forms.NotifyIcon AppTrayIcon;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuFlatButton activityPanelRefreshButton;
        private System.Windows.Forms.PictureBox notifyPictureBox1;
        private System.Windows.Forms.PictureBox notifyPictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel noPersonAlertLabel;
        private System.Windows.Forms.Panel Calibrating_Panel;
        private Bunifu.Framework.UI.BunifuCustomLabel calibratingCounterLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer calibratingTimer;
        private Bunifu.Framework.UI.BunifuCustomLabel Welcome_Label;
        private Bunifu.Framework.UI.BunifuCustomLabel InfoBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuThinButton2 Connect_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel mainPanel;
        private Bunifu.Framework.UI.BunifuFlatButton activityPanelBarButton;
        private Bunifu.Framework.UI.BunifuCustomLabel bottomPanelBorder;
        private System.Windows.Forms.Label activityPanelAlertCount;
        private Bunifu.Framework.UI.BunifuCustomLabel activityPanelAlertCountLabel;
        private System.Windows.Forms.ComboBox showUITimerDelayComboBox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
    }
}