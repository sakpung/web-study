namespace GrayScaleDemo
{
    partial class LineHistogramDialog
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
           this._lblXStart = new System.Windows.Forms.Label();
           this._lblXEnd = new System.Windows.Forms.Label();
           this._lblPixelNumber = new System.Windows.Forms.Label();
           this._lblYStart = new System.Windows.Forms.Label();
           this._lblYEnd = new System.Windows.Forms.Label();
           this._txtPixelNumber = new System.Windows.Forms.TextBox();
           this._tabs = new System.Windows.Forms.TabControl();
           this._tabAll = new System.Windows.Forms.TabPage();
           this._tabRed = new System.Windows.Forms.TabPage();
           this._tabGreen = new System.Windows.Forms.TabPage();
           this._tabBlue = new System.Windows.Forms.TabPage();
           this._lblXPixel = new System.Windows.Forms.Label();
           this._lblYPixel = new System.Windows.Forms.Label();
           this._txtXPixel = new System.Windows.Forms.TextBox();
           this._txtYPixel = new System.Windows.Forms.TextBox();
           this._lblRed = new System.Windows.Forms.Label();
           this._lblRedMax = new System.Windows.Forms.Label();
           this._lblRedMin = new System.Windows.Forms.Label();
           this._txtRed = new System.Windows.Forms.TextBox();
           this._txtRedMax = new System.Windows.Forms.TextBox();
           this._txtRedMin = new System.Windows.Forms.TextBox();
           this._txtGreenMin = new System.Windows.Forms.TextBox();
           this._txtGreenMax = new System.Windows.Forms.TextBox();
           this._txtGreen = new System.Windows.Forms.TextBox();
           this._lblGreenMin = new System.Windows.Forms.Label();
           this._lblGreenMax = new System.Windows.Forms.Label();
           this._lblGreen = new System.Windows.Forms.Label();
           this._txtBlueMin = new System.Windows.Forms.TextBox();
           this._txtBlueMax = new System.Windows.Forms.TextBox();
           this._txtBlue = new System.Windows.Forms.TextBox();
           this._lblBlueMin = new System.Windows.Forms.Label();
           this._lblBlueMax = new System.Windows.Forms.Label();
           this._lblBlue = new System.Windows.Forms.Label();
           this._btnOK = new System.Windows.Forms.Button();
           this._tbTabs = new System.Windows.Forms.TrackBar();
           this._numXStart = new System.Windows.Forms.NumericUpDown();
           this._numXEnd = new System.Windows.Forms.NumericUpDown();
           this._numYStart = new System.Windows.Forms.NumericUpDown();
           this._numYEnd = new System.Windows.Forms.NumericUpDown();
           this._gbCursorPosition = new System.Windows.Forms.GroupBox();
           this._yCursorPosition = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this._xCursorPosition = new System.Windows.Forms.TextBox();
           this.label1 = new System.Windows.Forms.Label();
           this._cbFillCurve = new System.Windows.Forms.CheckBox();
           this._cbMovable = new System.Windows.Forms.CheckBox();
           this._tabs.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._tbTabs)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numXStart)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numXEnd)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numYStart)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numYEnd)).BeginInit();
           this._gbCursorPosition.SuspendLayout();
           this.SuspendLayout();
           // 
           // _lblXStart
           // 
           this._lblXStart.AutoSize = true;
           this._lblXStart.Location = new System.Drawing.Point(79, 72);
           this._lblXStart.Name = "_lblXStart";
           this._lblXStart.Size = new System.Drawing.Size(42, 13);
           this._lblXStart.TabIndex = 0;
           this._lblXStart.Text = "X Start:";
           // 
           // _lblXEnd
           // 
           this._lblXEnd.AutoSize = true;
           this._lblXEnd.Location = new System.Drawing.Point(79, 106);
           this._lblXEnd.Name = "_lblXEnd";
           this._lblXEnd.Size = new System.Drawing.Size(39, 13);
           this._lblXEnd.TabIndex = 1;
           this._lblXEnd.Text = "X End:";
           // 
           // _lblPixelNumber
           // 
           this._lblPixelNumber.AutoSize = true;
           this._lblPixelNumber.Location = new System.Drawing.Point(140, 138);
           this._lblPixelNumber.Name = "_lblPixelNumber";
           this._lblPixelNumber.Size = new System.Drawing.Size(72, 13);
           this._lblPixelNumber.TabIndex = 2;
           this._lblPixelNumber.Text = "Pixel Number:";
           // 
           // _lblYStart
           // 
           this._lblYStart.AutoSize = true;
           this._lblYStart.Location = new System.Drawing.Point(244, 72);
           this._lblYStart.Name = "_lblYStart";
           this._lblYStart.Size = new System.Drawing.Size(42, 13);
           this._lblYStart.TabIndex = 3;
           this._lblYStart.Text = "Y Start:";
           // 
           // _lblYEnd
           // 
           this._lblYEnd.AutoSize = true;
           this._lblYEnd.Location = new System.Drawing.Point(244, 106);
           this._lblYEnd.Name = "_lblYEnd";
           this._lblYEnd.Size = new System.Drawing.Size(39, 13);
           this._lblYEnd.TabIndex = 4;
           this._lblYEnd.Text = "Y End:";
           // 
           // _txtPixelNumber
           // 
           this._txtPixelNumber.Location = new System.Drawing.Point(218, 135);
           this._txtPixelNumber.Name = "_txtPixelNumber";
           this._txtPixelNumber.ReadOnly = true;
           this._txtPixelNumber.Size = new System.Drawing.Size(60, 20);
           this._txtPixelNumber.TabIndex = 9;
           this._txtPixelNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _tabs
           // 
           this._tabs.Controls.Add(this._tabAll);
           this._tabs.Controls.Add(this._tabRed);
           this._tabs.Controls.Add(this._tabGreen);
           this._tabs.Controls.Add(this._tabBlue);
           this._tabs.Location = new System.Drawing.Point(29, 166);
           this._tabs.Name = "_tabs";
           this._tabs.SelectedIndex = 0;
           this._tabs.Size = new System.Drawing.Size(358, 281);
           this._tabs.TabIndex = 10;
           // 
           // _tabAll
           // 
           this._tabAll.BackColor = System.Drawing.Color.White;
           this._tabAll.Location = new System.Drawing.Point(4, 22);
           this._tabAll.Name = "_tabAll";
           this._tabAll.Padding = new System.Windows.Forms.Padding(3);
           this._tabAll.Size = new System.Drawing.Size(350, 255);
           this._tabAll.TabIndex = 0;
           this._tabAll.Text = "All";
           this._tabAll.Paint += new System.Windows.Forms.PaintEventHandler(this._tabAll_Paint);
           this._tabAll.MouseMove += new System.Windows.Forms.MouseEventHandler(this._tab_MouseMove);
           // 
           // _tabRed
           // 
           this._tabRed.BackColor = System.Drawing.Color.White;
           this._tabRed.Location = new System.Drawing.Point(4, 22);
           this._tabRed.Name = "_tabRed";
           this._tabRed.Padding = new System.Windows.Forms.Padding(3);
           this._tabRed.Size = new System.Drawing.Size(350, 255);
           this._tabRed.TabIndex = 1;
           this._tabRed.Text = "Red";
           this._tabRed.Paint += new System.Windows.Forms.PaintEventHandler(this._tabRed_Paint);
           this._tabRed.MouseMove += new System.Windows.Forms.MouseEventHandler(this._tab_MouseMove);
           // 
           // _tabGreen
           // 
           this._tabGreen.BackColor = System.Drawing.Color.White;
           this._tabGreen.Location = new System.Drawing.Point(4, 22);
           this._tabGreen.Name = "_tabGreen";
           this._tabGreen.Padding = new System.Windows.Forms.Padding(3);
           this._tabGreen.Size = new System.Drawing.Size(350, 255);
           this._tabGreen.TabIndex = 2;
           this._tabGreen.Text = "Green";
           this._tabGreen.Paint += new System.Windows.Forms.PaintEventHandler(this._tabGreen_Paint);
           this._tabGreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this._tab_MouseMove);
           // 
           // _tabBlue
           // 
           this._tabBlue.BackColor = System.Drawing.Color.White;
           this._tabBlue.Location = new System.Drawing.Point(4, 22);
           this._tabBlue.Name = "_tabBlue";
           this._tabBlue.Padding = new System.Windows.Forms.Padding(3);
           this._tabBlue.Size = new System.Drawing.Size(350, 255);
           this._tabBlue.TabIndex = 3;
           this._tabBlue.Text = "Blue";
           this._tabBlue.Paint += new System.Windows.Forms.PaintEventHandler(this._tabBlue_Paint);
           this._tabBlue.MouseMove += new System.Windows.Forms.MouseEventHandler(this._tab_MouseMove);
           // 
           // _lblXPixel
           // 
           this._lblXPixel.AutoSize = true;
           this._lblXPixel.Location = new System.Drawing.Point(75, 501);
           this._lblXPixel.Name = "_lblXPixel";
           this._lblXPixel.Size = new System.Drawing.Size(42, 13);
           this._lblXPixel.TabIndex = 11;
           this._lblXPixel.Text = "X Pixel:";
           // 
           // _lblYPixel
           // 
           this._lblYPixel.AutoSize = true;
           this._lblYPixel.Location = new System.Drawing.Point(233, 501);
           this._lblYPixel.Name = "_lblYPixel";
           this._lblYPixel.Size = new System.Drawing.Size(42, 13);
           this._lblYPixel.TabIndex = 12;
           this._lblYPixel.Text = "Y Pixel:";
           // 
           // _txtXPixel
           // 
           this._txtXPixel.Location = new System.Drawing.Point(123, 498);
           this._txtXPixel.Name = "_txtXPixel";
           this._txtXPixel.ReadOnly = true;
           this._txtXPixel.Size = new System.Drawing.Size(60, 20);
           this._txtXPixel.TabIndex = 13;
           this._txtXPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtYPixel
           // 
           this._txtYPixel.Location = new System.Drawing.Point(281, 498);
           this._txtYPixel.Name = "_txtYPixel";
           this._txtYPixel.ReadOnly = true;
           this._txtYPixel.Size = new System.Drawing.Size(60, 20);
           this._txtYPixel.TabIndex = 14;
           this._txtYPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _lblRed
           // 
           this._lblRed.AutoSize = true;
           this._lblRed.Location = new System.Drawing.Point(32, 535);
           this._lblRed.Name = "_lblRed";
           this._lblRed.Size = new System.Drawing.Size(30, 13);
           this._lblRed.TabIndex = 15;
           this._lblRed.Text = "Red:";
           // 
           // _lblRedMax
           // 
           this._lblRedMax.AutoSize = true;
           this._lblRedMax.Location = new System.Drawing.Point(32, 567);
           this._lblRedMax.Name = "_lblRedMax";
           this._lblRedMax.Size = new System.Drawing.Size(30, 13);
           this._lblRedMax.TabIndex = 16;
           this._lblRedMax.Text = "Max:";
           // 
           // _lblRedMin
           // 
           this._lblRedMin.AutoSize = true;
           this._lblRedMin.Location = new System.Drawing.Point(32, 601);
           this._lblRedMin.Name = "_lblRedMin";
           this._lblRedMin.Size = new System.Drawing.Size(27, 13);
           this._lblRedMin.TabIndex = 17;
           this._lblRedMin.Text = "Min:";
           // 
           // _txtRed
           // 
           this._txtRed.Location = new System.Drawing.Point(68, 532);
           this._txtRed.Name = "_txtRed";
           this._txtRed.ReadOnly = true;
           this._txtRed.Size = new System.Drawing.Size(60, 20);
           this._txtRed.TabIndex = 18;
           this._txtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtRedMax
           // 
           this._txtRedMax.Location = new System.Drawing.Point(68, 564);
           this._txtRedMax.Name = "_txtRedMax";
           this._txtRedMax.ReadOnly = true;
           this._txtRedMax.Size = new System.Drawing.Size(60, 20);
           this._txtRedMax.TabIndex = 19;
           this._txtRedMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtRedMin
           // 
           this._txtRedMin.Location = new System.Drawing.Point(68, 598);
           this._txtRedMin.Name = "_txtRedMin";
           this._txtRedMin.ReadOnly = true;
           this._txtRedMin.Size = new System.Drawing.Size(60, 20);
           this._txtRedMin.TabIndex = 20;
           this._txtRedMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtGreenMin
           // 
           this._txtGreenMin.Location = new System.Drawing.Point(196, 598);
           this._txtGreenMin.Name = "_txtGreenMin";
           this._txtGreenMin.ReadOnly = true;
           this._txtGreenMin.Size = new System.Drawing.Size(60, 20);
           this._txtGreenMin.TabIndex = 26;
           this._txtGreenMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtGreenMax
           // 
           this._txtGreenMax.Location = new System.Drawing.Point(196, 564);
           this._txtGreenMax.Name = "_txtGreenMax";
           this._txtGreenMax.ReadOnly = true;
           this._txtGreenMax.Size = new System.Drawing.Size(60, 20);
           this._txtGreenMax.TabIndex = 25;
           this._txtGreenMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtGreen
           // 
           this._txtGreen.Location = new System.Drawing.Point(196, 532);
           this._txtGreen.Name = "_txtGreen";
           this._txtGreen.ReadOnly = true;
           this._txtGreen.Size = new System.Drawing.Size(60, 20);
           this._txtGreen.TabIndex = 24;
           this._txtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _lblGreenMin
           // 
           this._lblGreenMin.AutoSize = true;
           this._lblGreenMin.Location = new System.Drawing.Point(160, 601);
           this._lblGreenMin.Name = "_lblGreenMin";
           this._lblGreenMin.Size = new System.Drawing.Size(27, 13);
           this._lblGreenMin.TabIndex = 23;
           this._lblGreenMin.Text = "Min:";
           // 
           // _lblGreenMax
           // 
           this._lblGreenMax.AutoSize = true;
           this._lblGreenMax.Location = new System.Drawing.Point(160, 567);
           this._lblGreenMax.Name = "_lblGreenMax";
           this._lblGreenMax.Size = new System.Drawing.Size(30, 13);
           this._lblGreenMax.TabIndex = 22;
           this._lblGreenMax.Text = "Max:";
           // 
           // _lblGreen
           // 
           this._lblGreen.AutoSize = true;
           this._lblGreen.Location = new System.Drawing.Point(160, 535);
           this._lblGreen.Name = "_lblGreen";
           this._lblGreen.Size = new System.Drawing.Size(39, 13);
           this._lblGreen.TabIndex = 21;
           this._lblGreen.Text = "Green:";
           // 
           // _txtBlueMin
           // 
           this._txtBlueMin.Location = new System.Drawing.Point(324, 598);
           this._txtBlueMin.Name = "_txtBlueMin";
           this._txtBlueMin.ReadOnly = true;
           this._txtBlueMin.Size = new System.Drawing.Size(60, 20);
           this._txtBlueMin.TabIndex = 32;
           this._txtBlueMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtBlueMax
           // 
           this._txtBlueMax.Location = new System.Drawing.Point(324, 564);
           this._txtBlueMax.Name = "_txtBlueMax";
           this._txtBlueMax.ReadOnly = true;
           this._txtBlueMax.Size = new System.Drawing.Size(60, 20);
           this._txtBlueMax.TabIndex = 31;
           this._txtBlueMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _txtBlue
           // 
           this._txtBlue.Location = new System.Drawing.Point(324, 532);
           this._txtBlue.Name = "_txtBlue";
           this._txtBlue.ReadOnly = true;
           this._txtBlue.Size = new System.Drawing.Size(60, 20);
           this._txtBlue.TabIndex = 30;
           this._txtBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _lblBlueMin
           // 
           this._lblBlueMin.AutoSize = true;
           this._lblBlueMin.Location = new System.Drawing.Point(288, 601);
           this._lblBlueMin.Name = "_lblBlueMin";
           this._lblBlueMin.Size = new System.Drawing.Size(27, 13);
           this._lblBlueMin.TabIndex = 29;
           this._lblBlueMin.Text = "Min:";
           // 
           // _lblBlueMax
           // 
           this._lblBlueMax.AutoSize = true;
           this._lblBlueMax.Location = new System.Drawing.Point(288, 567);
           this._lblBlueMax.Name = "_lblBlueMax";
           this._lblBlueMax.Size = new System.Drawing.Size(30, 13);
           this._lblBlueMax.TabIndex = 28;
           this._lblBlueMax.Text = "Max:";
           // 
           // _lblBlue
           // 
           this._lblBlue.AutoSize = true;
           this._lblBlue.Location = new System.Drawing.Point(288, 535);
           this._lblBlue.Name = "_lblBlue";
           this._lblBlue.Size = new System.Drawing.Size(31, 13);
           this._lblBlue.TabIndex = 27;
           this._lblBlue.Text = "Blue:";
           // 
           // _btnOK
           // 
           this._btnOK.Location = new System.Drawing.Point(175, 667);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(66, 32);
           this._btnOK.TabIndex = 33;
           this._btnOK.Text = "OK";
           this._btnOK.UseVisualStyleBackColor = true;
           this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
           // 
           // _tbTabs
           // 
           this._tbTabs.LargeChange = 1;
           this._tbTabs.Location = new System.Drawing.Point(29, 453);
           this._tbTabs.Maximum = 6;
           this._tbTabs.Name = "_tbTabs";
           this._tbTabs.Size = new System.Drawing.Size(355, 45);
           this._tbTabs.TabIndex = 34;
           this._tbTabs.Scroll += new System.EventHandler(this._tbTabs_Scroll);
           // 
           // _numXStart
           // 
           this._numXStart.Location = new System.Drawing.Point(127, 70);
           this._numXStart.Name = "_numXStart";
           this._numXStart.Size = new System.Drawing.Size(50, 20);
           this._numXStart.TabIndex = 35;
           this._numXStart.ValueChanged += new System.EventHandler(this._numXStart_ValueChanged);
           // 
           // _numXEnd
           // 
           this._numXEnd.Location = new System.Drawing.Point(127, 104);
           this._numXEnd.Name = "_numXEnd";
           this._numXEnd.Size = new System.Drawing.Size(50, 20);
           this._numXEnd.TabIndex = 36;
           this._numXEnd.ValueChanged += new System.EventHandler(this._numXEnd_ValueChanged);
           // 
           // _numYStart
           // 
           this._numYStart.Location = new System.Drawing.Point(291, 70);
           this._numYStart.Name = "_numYStart";
           this._numYStart.Size = new System.Drawing.Size(50, 20);
           this._numYStart.TabIndex = 37;
           this._numYStart.ValueChanged += new System.EventHandler(this._numYStart_ValueChanged);
           // 
           // _numYEnd
           // 
           this._numYEnd.Location = new System.Drawing.Point(291, 104);
           this._numYEnd.Name = "_numYEnd";
           this._numYEnd.Size = new System.Drawing.Size(50, 20);
           this._numYEnd.TabIndex = 38;
           this._numYEnd.ValueChanged += new System.EventHandler(this._numYEnd_ValueChanged);
           // 
           // _gbCursorPosition
           // 
           this._gbCursorPosition.Controls.Add(this._yCursorPosition);
           this._gbCursorPosition.Controls.Add(this.label2);
           this._gbCursorPosition.Controls.Add(this._xCursorPosition);
           this._gbCursorPosition.Controls.Add(this.label1);
           this._gbCursorPosition.Location = new System.Drawing.Point(106, 9);
           this._gbCursorPosition.Name = "_gbCursorPosition";
           this._gbCursorPosition.Size = new System.Drawing.Size(205, 51);
           this._gbCursorPosition.TabIndex = 39;
           this._gbCursorPosition.TabStop = false;
           this._gbCursorPosition.Text = "Cursor Position";
           // 
           // _yCursorPosition
           // 
           this._yCursorPosition.Location = new System.Drawing.Point(141, 23);
           this._yCursorPosition.Name = "_yCursorPosition";
           this._yCursorPosition.ReadOnly = true;
           this._yCursorPosition.Size = new System.Drawing.Size(48, 20);
           this._yCursorPosition.TabIndex = 3;
           this._yCursorPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(112, 25);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(23, 13);
           this.label2.TabIndex = 2;
           this.label2.Text = "Y : ";
           // 
           // _xCursorPosition
           // 
           this._xCursorPosition.Location = new System.Drawing.Point(48, 23);
           this._xCursorPosition.Name = "_xCursorPosition";
           this._xCursorPosition.ReadOnly = true;
           this._xCursorPosition.Size = new System.Drawing.Size(50, 20);
           this._xCursorPosition.TabIndex = 1;
           this._xCursorPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(20, 25);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(23, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "X : ";
           // 
           // _cbFillCurve
           // 
           this._cbFillCurve.AutoSize = true;
           this._cbFillCurve.Location = new System.Drawing.Point(95, 645);
           this._cbFillCurve.Name = "_cbFillCurve";
           this._cbFillCurve.Size = new System.Drawing.Size(69, 17);
           this._cbFillCurve.TabIndex = 40;
           this._cbFillCurve.Text = "Fill Curve";
           this._cbFillCurve.UseVisualStyleBackColor = true;
           this._cbFillCurve.CheckedChanged += new System.EventHandler(this._cbFillCurve_CheckedChanged);
           // 
           // _cbMovable
           // 
           this._cbMovable.AutoSize = true;
           this._cbMovable.Location = new System.Drawing.Point(265, 645);
           this._cbMovable.Name = "_cbMovable";
           this._cbMovable.Size = new System.Drawing.Size(67, 17);
           this._cbMovable.TabIndex = 41;
           this._cbMovable.Text = "Movable";
           this._cbMovable.UseVisualStyleBackColor = true;
           this._cbMovable.CheckedChanged += new System.EventHandler(this._cbMovable_CheckedChanged);
           // 
           // LineHistogramDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(417, 707);
           this.Controls.Add(this._cbMovable);
           this.Controls.Add(this._cbFillCurve);
           this.Controls.Add(this._gbCursorPosition);
           this.Controls.Add(this._numYEnd);
           this.Controls.Add(this._numYStart);
           this.Controls.Add(this._numXEnd);
           this.Controls.Add(this._numXStart);
           this.Controls.Add(this._tbTabs);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this._txtBlueMin);
           this.Controls.Add(this._txtBlueMax);
           this.Controls.Add(this._txtBlue);
           this.Controls.Add(this._lblBlueMin);
           this.Controls.Add(this._lblBlueMax);
           this.Controls.Add(this._lblBlue);
           this.Controls.Add(this._txtGreenMin);
           this.Controls.Add(this._txtGreenMax);
           this.Controls.Add(this._txtGreen);
           this.Controls.Add(this._lblGreenMin);
           this.Controls.Add(this._lblGreenMax);
           this.Controls.Add(this._lblGreen);
           this.Controls.Add(this._txtRedMin);
           this.Controls.Add(this._txtRedMax);
           this.Controls.Add(this._txtRed);
           this.Controls.Add(this._lblRedMin);
           this.Controls.Add(this._lblRedMax);
           this.Controls.Add(this._lblRed);
           this.Controls.Add(this._txtYPixel);
           this.Controls.Add(this._txtXPixel);
           this.Controls.Add(this._lblYPixel);
           this.Controls.Add(this._lblXPixel);
           this.Controls.Add(this._tabs);
           this.Controls.Add(this._txtPixelNumber);
           this.Controls.Add(this._lblYEnd);
           this.Controls.Add(this._lblYStart);
           this.Controls.Add(this._lblPixelNumber);
           this.Controls.Add(this._lblXEnd);
           this.Controls.Add(this._lblXStart);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "LineHistogramDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Line Histogram";
           this.Load += new System.EventHandler(this.LineHistogramDialog_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineHistogramDialog_FormClosing);
           this._tabs.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._tbTabs)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numXStart)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numXEnd)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numYStart)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numYEnd)).EndInit();
           this._gbCursorPosition.ResumeLayout(false);
           this._gbCursorPosition.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblXStart;
        private System.Windows.Forms.Label _lblXEnd;
        private System.Windows.Forms.Label _lblPixelNumber;
        private System.Windows.Forms.Label _lblYStart;
        private System.Windows.Forms.Label _lblYEnd;
        private System.Windows.Forms.TextBox _txtPixelNumber;
        private System.Windows.Forms.TabControl _tabs;
        private System.Windows.Forms.TabPage _tabAll;
        private System.Windows.Forms.TabPage _tabRed;
        private System.Windows.Forms.Label _lblXPixel;
        private System.Windows.Forms.Label _lblYPixel;
        private System.Windows.Forms.TextBox _txtXPixel;
        private System.Windows.Forms.TextBox _txtYPixel;
        private System.Windows.Forms.Label _lblRed;
        private System.Windows.Forms.Label _lblRedMax;
        private System.Windows.Forms.Label _lblRedMin;
        private System.Windows.Forms.TextBox _txtRed;
        private System.Windows.Forms.TextBox _txtRedMax;
        private System.Windows.Forms.TextBox _txtRedMin;
        private System.Windows.Forms.TextBox _txtGreenMin;
        private System.Windows.Forms.TextBox _txtGreenMax;
        private System.Windows.Forms.TextBox _txtGreen;
        private System.Windows.Forms.Label _lblGreenMin;
        private System.Windows.Forms.Label _lblGreenMax;
        private System.Windows.Forms.Label _lblGreen;
        private System.Windows.Forms.TextBox _txtBlueMin;
        private System.Windows.Forms.TextBox _txtBlueMax;
        private System.Windows.Forms.TextBox _txtBlue;
        private System.Windows.Forms.Label _lblBlueMin;
        private System.Windows.Forms.Label _lblBlueMax;
        private System.Windows.Forms.Label _lblBlue;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.TabPage _tabGreen;
        private System.Windows.Forms.TabPage _tabBlue;
        private System.Windows.Forms.TrackBar _tbTabs;
        private System.Windows.Forms.NumericUpDown _numXStart;
        private System.Windows.Forms.NumericUpDown _numXEnd;
        private System.Windows.Forms.NumericUpDown _numYStart;
        private System.Windows.Forms.NumericUpDown _numYEnd;
        private System.Windows.Forms.GroupBox _gbCursorPosition;
        private System.Windows.Forms.TextBox _yCursorPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _xCursorPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _cbFillCurve;
        private System.Windows.Forms.CheckBox _cbMovable;
    }
}