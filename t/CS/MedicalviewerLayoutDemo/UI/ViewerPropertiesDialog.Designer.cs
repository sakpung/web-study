namespace MedicalViewerLayoutDemo
{
   partial class ViewerPropertiesDialog
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
         this._btnApply = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnReset = new System.Windows.Forms.Button();
         this._tabColors = new System.Windows.Forms.TabPage();
         this._lblText = new MedicalViewerLayoutDemo.ColorBox();
         this._lblShadowColor = new MedicalViewerLayoutDemo.ColorBox();
         this._lblActiveBorderColor = new MedicalViewerLayoutDemo.ColorBox();
         this._lblActiveSubcellColor = new MedicalViewerLayoutDemo.ColorBox();
         this._lblBackgroundColor = new MedicalViewerLayoutDemo.ColorBox();
         this._lblRulerInColor = new MedicalViewerLayoutDemo.ColorBox();
         this._lblRulerOutColor = new MedicalViewerLayoutDemo.ColorBox();
         this._lblNonActiveBorderColor = new MedicalViewerLayoutDemo.ColorBox();
         this._btnText = new System.Windows.Forms.Button();
         this._btnShadowColor = new System.Windows.Forms.Button();
         this._btnActiveBorderColor = new System.Windows.Forms.Button();
         this._btnActiveSubcellColor = new System.Windows.Forms.Button();
         this._btnBackgroundColor = new System.Windows.Forms.Button();
         this._btnRulerInColor = new System.Windows.Forms.Button();
         this._btnRulerOutColor = new System.Windows.Forms.Button();
         this._btnNonActiveBorderColor = new System.Windows.Forms.Button();
         this._labelDesignForeColor = new MedicalViewerLayoutDemo.ColorBox();
         this._btnDesignForeColor = new System.Windows.Forms.Button();
         this._labelDesignBackColor = new MedicalViewerLayoutDemo.ColorBox();
         this._btnDesignBackColor = new System.Windows.Forms.Button();
         this._tabGeneral = new System.Windows.Forms.TabPage();
         this._cmbRuler = new System.Windows.Forms.ComboBox();
         this._cmbPaintMethod = new System.Windows.Forms.ComboBox();
         this._cmbTextQuality = new System.Windows.Forms.ComboBox();
         this._cmbBorderStyle = new System.Windows.Forms.ComboBox();
         this._cmbMeasurmentUnit = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this._chkShowFreeze = new System.Windows.Forms.CheckBox();
         this._chkMaintainSize = new System.Windows.Forms.CheckBox();
         this._chkShowCellScroll = new System.Windows.Forms.CheckBox();
         this._tabViewer = new System.Windows.Forms.TabControl();
         this._tabColors.SuspendLayout();
         this._tabGeneral.SuspendLayout();
         this._tabViewer.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(185, 303);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(70, 29);
         this._btnApply.TabIndex = 11;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this.applyButton_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(109, 303);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(70, 29);
         this._btnCancel.TabIndex = 10;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOK.Location = new System.Drawing.Point(33, 303);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(70, 29);
         this._btnOK.TabIndex = 9;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this.okButton_Click);
         // 
         // _btnReset
         // 
         this._btnReset.Location = new System.Drawing.Point(264, 303);
         this._btnReset.Name = "_btnReset";
         this._btnReset.Size = new System.Drawing.Size(70, 29);
         this._btnReset.TabIndex = 12;
         this._btnReset.Text = "&Reset";
         this._btnReset.UseVisualStyleBackColor = true;
         this._btnReset.Click += new System.EventHandler(this.resetButton_Click);
         // 
         // _tabColors
         // 
         this._tabColors.Controls.Add(this._btnDesignBackColor);
         this._tabColors.Controls.Add(this._labelDesignBackColor);
         this._tabColors.Controls.Add(this._btnDesignForeColor);
         this._tabColors.Controls.Add(this._labelDesignForeColor);
         this._tabColors.Controls.Add(this._btnNonActiveBorderColor);
         this._tabColors.Controls.Add(this._btnRulerOutColor);
         this._tabColors.Controls.Add(this._btnRulerInColor);
         this._tabColors.Controls.Add(this._btnBackgroundColor);
         this._tabColors.Controls.Add(this._btnActiveSubcellColor);
         this._tabColors.Controls.Add(this._btnActiveBorderColor);
         this._tabColors.Controls.Add(this._btnShadowColor);
         this._tabColors.Controls.Add(this._btnText);
         this._tabColors.Controls.Add(this._lblNonActiveBorderColor);
         this._tabColors.Controls.Add(this._lblRulerOutColor);
         this._tabColors.Controls.Add(this._lblRulerInColor);
         this._tabColors.Controls.Add(this._lblBackgroundColor);
         this._tabColors.Controls.Add(this._lblActiveSubcellColor);
         this._tabColors.Controls.Add(this._lblActiveBorderColor);
         this._tabColors.Controls.Add(this._lblShadowColor);
         this._tabColors.Controls.Add(this._lblText);
         this._tabColors.Location = new System.Drawing.Point(4, 22);
         this._tabColors.Name = "_tabColors";
         this._tabColors.Padding = new System.Windows.Forms.Padding(3);
         this._tabColors.Size = new System.Drawing.Size(345, 262);
         this._tabColors.TabIndex = 1;
         this._tabColors.Text = "Colors";
         this._tabColors.UseVisualStyleBackColor = true;
         // 
         // _lblText
         // 
         this._lblText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblText.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblText.Location = new System.Drawing.Point(97, 19);
         this._lblText.Name = "_lblText";
         this._lblText.Size = new System.Drawing.Size(63, 26);
         this._lblText.TabIndex = 3;
         // 
         // _lblShadowColor
         // 
         this._lblShadowColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblShadowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblShadowColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblShadowColor.Location = new System.Drawing.Point(97, 59);
         this._lblShadowColor.Name = "_lblShadowColor";
         this._lblShadowColor.Size = new System.Drawing.Size(63, 26);
         this._lblShadowColor.TabIndex = 5;
         // 
         // _lblActiveBorderColor
         // 
         this._lblActiveBorderColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblActiveBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblActiveBorderColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblActiveBorderColor.Location = new System.Drawing.Point(97, 100);
         this._lblActiveBorderColor.Name = "_lblActiveBorderColor";
         this._lblActiveBorderColor.Size = new System.Drawing.Size(63, 26);
         this._lblActiveBorderColor.TabIndex = 7;
         // 
         // _lblActiveSubcellColor
         // 
         this._lblActiveSubcellColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblActiveSubcellColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblActiveSubcellColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblActiveSubcellColor.Location = new System.Drawing.Point(96, 139);
         this._lblActiveSubcellColor.Name = "_lblActiveSubcellColor";
         this._lblActiveSubcellColor.Size = new System.Drawing.Size(63, 26);
         this._lblActiveSubcellColor.TabIndex = 9;
         // 
         // _lblBackgroundColor
         // 
         this._lblBackgroundColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblBackgroundColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblBackgroundColor.Location = new System.Drawing.Point(266, 19);
         this._lblBackgroundColor.Name = "_lblBackgroundColor";
         this._lblBackgroundColor.Size = new System.Drawing.Size(63, 26);
         this._lblBackgroundColor.TabIndex = 11;
         // 
         // _lblRulerInColor
         // 
         this._lblRulerInColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblRulerInColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblRulerInColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblRulerInColor.Location = new System.Drawing.Point(266, 59);
         this._lblRulerInColor.Name = "_lblRulerInColor";
         this._lblRulerInColor.Size = new System.Drawing.Size(63, 26);
         this._lblRulerInColor.TabIndex = 13;
         // 
         // _lblRulerOutColor
         // 
         this._lblRulerOutColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblRulerOutColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblRulerOutColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblRulerOutColor.Location = new System.Drawing.Point(266, 100);
         this._lblRulerOutColor.Name = "_lblRulerOutColor";
         this._lblRulerOutColor.Size = new System.Drawing.Size(63, 26);
         this._lblRulerOutColor.TabIndex = 15;
         // 
         // _lblNonActiveBorderColor
         // 
         this._lblNonActiveBorderColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblNonActiveBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblNonActiveBorderColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._lblNonActiveBorderColor.Location = new System.Drawing.Point(266, 139);
         this._lblNonActiveBorderColor.Name = "_lblNonActiveBorderColor";
         this._lblNonActiveBorderColor.Size = new System.Drawing.Size(63, 26);
         this._lblNonActiveBorderColor.TabIndex = 17;
         // 
         // _btnText
         // 
         this._btnText.Location = new System.Drawing.Point(17, 15);
         this._btnText.Name = "_btnText";
         this._btnText.Size = new System.Drawing.Size(73, 34);
         this._btnText.TabIndex = 2;
         this._btnText.Text = "&Text";
         this._btnText.UseVisualStyleBackColor = true;
         this._btnText.Click += new System.EventHandler(this._btnText_Click);
         // 
         // _btnShadowColor
         // 
         this._btnShadowColor.Location = new System.Drawing.Point(17, 55);
         this._btnShadowColor.Name = "_btnShadowColor";
         this._btnShadowColor.Size = new System.Drawing.Size(73, 34);
         this._btnShadowColor.TabIndex = 4;
         this._btnShadowColor.Text = "&Shadow";
         this._btnShadowColor.UseVisualStyleBackColor = true;
         this._btnShadowColor.Click += new System.EventHandler(this._btnShadowColor_Click);
         // 
         // _btnActiveBorderColor
         // 
         this._btnActiveBorderColor.Location = new System.Drawing.Point(17, 95);
         this._btnActiveBorderColor.Name = "_btnActiveBorderColor";
         this._btnActiveBorderColor.Size = new System.Drawing.Size(73, 34);
         this._btnActiveBorderColor.TabIndex = 6;
         this._btnActiveBorderColor.Text = "&Active border";
         this._btnActiveBorderColor.UseVisualStyleBackColor = true;
         this._btnActiveBorderColor.Click += new System.EventHandler(this._btnActiveBorderColor_Click);
         // 
         // _btnActiveSubcellColor
         // 
         this._btnActiveSubcellColor.Location = new System.Drawing.Point(17, 135);
         this._btnActiveSubcellColor.Name = "_btnActiveSubcellColor";
         this._btnActiveSubcellColor.Size = new System.Drawing.Size(73, 34);
         this._btnActiveSubcellColor.TabIndex = 8;
         this._btnActiveSubcellColor.Text = "Active subcell";
         this._btnActiveSubcellColor.UseVisualStyleBackColor = true;
         this._btnActiveSubcellColor.Click += new System.EventHandler(this._btnActiveSubcellColor_Click);
         // 
         // _btnBackgroundColor
         // 
         this._btnBackgroundColor.Location = new System.Drawing.Point(187, 15);
         this._btnBackgroundColor.Name = "_btnBackgroundColor";
         this._btnBackgroundColor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this._btnBackgroundColor.Size = new System.Drawing.Size(73, 34);
         this._btnBackgroundColor.TabIndex = 10;
         this._btnBackgroundColor.Text = "Cell &Backcolor";
         this._btnBackgroundColor.UseVisualStyleBackColor = true;
         this._btnBackgroundColor.Click += new System.EventHandler(this._btnBackgroundColor_Click);
         // 
         // _btnRulerInColor
         // 
         this._btnRulerInColor.Location = new System.Drawing.Point(187, 55);
         this._btnRulerInColor.Name = "_btnRulerInColor";
         this._btnRulerInColor.Size = new System.Drawing.Size(73, 34);
         this._btnRulerInColor.TabIndex = 12;
         this._btnRulerInColor.Text = "&Ruler in";
         this._btnRulerInColor.UseVisualStyleBackColor = true;
         this._btnRulerInColor.Click += new System.EventHandler(this._btnRulerInColor_Click);
         // 
         // _btnRulerOutColor
         // 
         this._btnRulerOutColor.Location = new System.Drawing.Point(187, 95);
         this._btnRulerOutColor.Name = "_btnRulerOutColor";
         this._btnRulerOutColor.Size = new System.Drawing.Size(73, 34);
         this._btnRulerOutColor.TabIndex = 14;
         this._btnRulerOutColor.Text = "Ruler &out";
         this._btnRulerOutColor.UseVisualStyleBackColor = true;
         this._btnRulerOutColor.Click += new System.EventHandler(this._btnRulerOutColor_Click);
         // 
         // _btnNonActiveBorderColor
         // 
         this._btnNonActiveBorderColor.Location = new System.Drawing.Point(187, 135);
         this._btnNonActiveBorderColor.Name = "_btnNonActiveBorderColor";
         this._btnNonActiveBorderColor.Size = new System.Drawing.Size(73, 34);
         this._btnNonActiveBorderColor.TabIndex = 16;
         this._btnNonActiveBorderColor.Text = "Non-active border";
         this._btnNonActiveBorderColor.UseVisualStyleBackColor = true;
         this._btnNonActiveBorderColor.Click += new System.EventHandler(this._btnNonActiveBorderColor_Click);
         // 
         // _labelDesignForeColor
         // 
         this._labelDesignForeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._labelDesignForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._labelDesignForeColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._labelDesignForeColor.Location = new System.Drawing.Point(266, 182);
         this._labelDesignForeColor.Name = "_labelDesignForeColor";
         this._labelDesignForeColor.Size = new System.Drawing.Size(63, 26);
         this._labelDesignForeColor.TabIndex = 19;
         // 
         // _btnDesignForeColor
         // 
         this._btnDesignForeColor.Location = new System.Drawing.Point(187, 178);
         this._btnDesignForeColor.Name = "_btnDesignForeColor";
         this._btnDesignForeColor.Size = new System.Drawing.Size(73, 34);
         this._btnDesignForeColor.TabIndex = 18;
         this._btnDesignForeColor.Text = "Design Forecolor";
         this._btnDesignForeColor.UseVisualStyleBackColor = true;
         this._btnDesignForeColor.Click += new System.EventHandler(this._btnDesignForeColor_Click);
         // 
         // _labelDesignBackColor
         // 
         this._labelDesignBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._labelDesignBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._labelDesignBackColor.BoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this._labelDesignBackColor.Location = new System.Drawing.Point(96, 182);
         this._labelDesignBackColor.Name = "_labelDesignBackColor";
         this._labelDesignBackColor.Size = new System.Drawing.Size(63, 26);
         this._labelDesignBackColor.TabIndex = 21;
         // 
         // _btnDesignBackColor
         // 
         this._btnDesignBackColor.Location = new System.Drawing.Point(17, 178);
         this._btnDesignBackColor.Name = "_btnDesignBackColor";
         this._btnDesignBackColor.Size = new System.Drawing.Size(73, 34);
         this._btnDesignBackColor.TabIndex = 20;
         this._btnDesignBackColor.Text = "Design Backcolor";
         this._btnDesignBackColor.UseVisualStyleBackColor = true;
         this._btnDesignBackColor.Click += new System.EventHandler(this._btnDesignBackColor_Click);
         // 
         // _tabGeneral
         // 
         this._tabGeneral.Controls.Add(this._chkShowCellScroll);
         this._tabGeneral.Controls.Add(this._chkMaintainSize);
         this._tabGeneral.Controls.Add(this._chkShowFreeze);
         this._tabGeneral.Controls.Add(this.label6);
         this._tabGeneral.Controls.Add(this.label7);
         this._tabGeneral.Controls.Add(this.label8);
         this._tabGeneral.Controls.Add(this.label5);
         this._tabGeneral.Controls.Add(this.label3);
         this._tabGeneral.Controls.Add(this._cmbMeasurmentUnit);
         this._tabGeneral.Controls.Add(this._cmbBorderStyle);
         this._tabGeneral.Controls.Add(this._cmbTextQuality);
         this._tabGeneral.Controls.Add(this._cmbPaintMethod);
         this._tabGeneral.Controls.Add(this._cmbRuler);
         this._tabGeneral.Location = new System.Drawing.Point(4, 22);
         this._tabGeneral.Name = "_tabGeneral";
         this._tabGeneral.Padding = new System.Windows.Forms.Padding(3);
         this._tabGeneral.Size = new System.Drawing.Size(345, 262);
         this._tabGeneral.TabIndex = 0;
         this._tabGeneral.Text = "General";
         this._tabGeneral.UseVisualStyleBackColor = true;
         // 
         // _cmbRuler
         // 
         this._cmbRuler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbRuler.FormattingEnabled = true;
         this._cmbRuler.Items.AddRange(new object[] {
            "Inverted",
            "Bordered"});
         this._cmbRuler.Location = new System.Drawing.Point(73, 11);
         this._cmbRuler.Name = "_cmbRuler";
         this._cmbRuler.Size = new System.Drawing.Size(91, 21);
         this._cmbRuler.TabIndex = 27;
         // 
         // _cmbPaintMethod
         // 
         this._cmbPaintMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPaintMethod.FormattingEnabled = true;
         this._cmbPaintMethod.Items.AddRange(new object[] {
            "Normal",
            "Resample",
            "Bicubic"});
         this._cmbPaintMethod.Location = new System.Drawing.Point(243, 37);
         this._cmbPaintMethod.Name = "_cmbPaintMethod";
         this._cmbPaintMethod.Size = new System.Drawing.Size(91, 21);
         this._cmbPaintMethod.TabIndex = 29;
         // 
         // _cmbTextQuality
         // 
         this._cmbTextQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbTextQuality.FormattingEnabled = true;
         this._cmbTextQuality.Items.AddRange(new object[] {
            "Default",
            "Draft",
            "Proof",
            "Force draft",
            "Force Anti-Alias"});
         this._cmbTextQuality.Location = new System.Drawing.Point(243, 10);
         this._cmbTextQuality.Name = "_cmbTextQuality";
         this._cmbTextQuality.Size = new System.Drawing.Size(91, 21);
         this._cmbTextQuality.TabIndex = 30;
         // 
         // _cmbBorderStyle
         // 
         this._cmbBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbBorderStyle.FormattingEnabled = true;
         this._cmbBorderStyle.Items.AddRange(new object[] {
            "Solid",
            "Dashed",
            "Dotted",
            "Dash-Dot",
            "Dash-Dot-Dot"});
         this._cmbBorderStyle.Location = new System.Drawing.Point(73, 38);
         this._cmbBorderStyle.Name = "_cmbBorderStyle";
         this._cmbBorderStyle.Size = new System.Drawing.Size(91, 21);
         this._cmbBorderStyle.TabIndex = 31;
         // 
         // _cmbMeasurmentUnit
         // 
         this._cmbMeasurmentUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbMeasurmentUnit.FormattingEnabled = true;
         this._cmbMeasurmentUnit.Items.AddRange(new object[] {
            "Inches",
            "Feet",
            "Micrometers",
            "Millimeters",
            "Centimeters",
            "Meters"});
         this._cmbMeasurmentUnit.Location = new System.Drawing.Point(73, 65);
         this._cmbMeasurmentUnit.Name = "_cmbMeasurmentUnit";
         this._cmbMeasurmentUnit.Size = new System.Drawing.Size(91, 21);
         this._cmbMeasurmentUnit.TabIndex = 32;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(7, 15);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(58, 13);
         this.label3.TabIndex = 33;
         this.label3.Text = "Ruler s&ytle";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(174, 41);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(70, 13);
         this.label5.TabIndex = 35;
         this.label5.Text = "&Paint method";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(172, 14);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(64, 13);
         this.label8.TabIndex = 36;
         this.label8.Text = "&Text quality";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(7, 46);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(65, 13);
         this.label7.TabIndex = 37;
         this.label7.Text = "&Border style";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(7, 68);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(58, 13);
         this.label6.TabIndex = 38;
         this.label6.Text = "Meas. &Unit";
         // 
         // _chkShowFreeze
         // 
         this._chkShowFreeze.AutoSize = true;
         this._chkShowFreeze.Location = new System.Drawing.Point(10, 95);
         this._chkShowFreeze.Name = "_chkShowFreeze";
         this._chkShowFreeze.Size = new System.Drawing.Size(109, 17);
         this._chkShowFreeze.TabIndex = 40;
         this._chkShowFreeze.Text = "Show free&ze text";
         this._chkShowFreeze.UseVisualStyleBackColor = true;
         // 
         // _chkMaintainSize
         // 
         this._chkMaintainSize.AutoSize = true;
         this._chkMaintainSize.Location = new System.Drawing.Point(130, 95);
         this._chkMaintainSize.Name = "_chkMaintainSize";
         this._chkMaintainSize.Size = new System.Drawing.Size(87, 17);
         this._chkMaintainSize.TabIndex = 42;
         this._chkMaintainSize.Text = "&Maintain size";
         this._chkMaintainSize.UseVisualStyleBackColor = true;
         // 
         // _chkShowCellScroll
         // 
         this._chkShowCellScroll.AutoSize = true;
         this._chkShowCellScroll.Location = new System.Drawing.Point(235, 95);
         this._chkShowCellScroll.Name = "_chkShowCellScroll";
         this._chkShowCellScroll.Size = new System.Drawing.Size(97, 17);
         this._chkShowCellScroll.TabIndex = 43;
         this._chkShowCellScroll.Text = "Sho&w cell scroll";
         this._chkShowCellScroll.UseVisualStyleBackColor = true;
         // 
         // _tabViewer
         // 
         this._tabViewer.Controls.Add(this._tabGeneral);
         this._tabViewer.Controls.Add(this._tabColors);
         this._tabViewer.Location = new System.Drawing.Point(9, 9);
         this._tabViewer.Name = "_tabViewer";
         this._tabViewer.SelectedIndex = 0;
         this._tabViewer.Size = new System.Drawing.Size(353, 288);
         this._tabViewer.TabIndex = 0;
         // 
         // ViewerPropertiesDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(374, 340);
         this.Controls.Add(this._btnReset);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._tabViewer);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ViewerPropertiesDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "ViewerProperties";
         this._tabColors.ResumeLayout(false);
         this._tabGeneral.ResumeLayout(false);
         this._tabGeneral.PerformLayout();
         this._tabViewer.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnReset;
      private System.Windows.Forms.TabPage _tabColors;
      private System.Windows.Forms.Button _btnDesignBackColor;
      private ColorBox _labelDesignBackColor;
      private System.Windows.Forms.Button _btnDesignForeColor;
      private ColorBox _labelDesignForeColor;
      private System.Windows.Forms.Button _btnNonActiveBorderColor;
      private System.Windows.Forms.Button _btnRulerOutColor;
      private System.Windows.Forms.Button _btnRulerInColor;
      private System.Windows.Forms.Button _btnBackgroundColor;
      private System.Windows.Forms.Button _btnActiveSubcellColor;
      private System.Windows.Forms.Button _btnActiveBorderColor;
      private System.Windows.Forms.Button _btnShadowColor;
      private System.Windows.Forms.Button _btnText;
      private ColorBox _lblNonActiveBorderColor;
      private ColorBox _lblRulerOutColor;
      private ColorBox _lblRulerInColor;
      private ColorBox _lblBackgroundColor;
      private ColorBox _lblActiveSubcellColor;
      private ColorBox _lblActiveBorderColor;
      private ColorBox _lblShadowColor;
      private ColorBox _lblText;
      private System.Windows.Forms.TabPage _tabGeneral;
      private System.Windows.Forms.CheckBox _chkShowCellScroll;
      private System.Windows.Forms.CheckBox _chkMaintainSize;
      private System.Windows.Forms.CheckBox _chkShowFreeze;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _cmbMeasurmentUnit;
      private System.Windows.Forms.ComboBox _cmbBorderStyle;
      private System.Windows.Forms.ComboBox _cmbTextQuality;
      private System.Windows.Forms.ComboBox _cmbPaintMethod;
      private System.Windows.Forms.ComboBox _cmbRuler;
      private System.Windows.Forms.TabControl _tabViewer;
   }
}