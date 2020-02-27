namespace Leadtools.Annotations.WinForms
{
   partial class BatesStampDialog
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
            CleanUp();
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox6 = new System.Windows.Forms.GroupBox();
         this._btnRemoveStamp = new System.Windows.Forms.Button();
         this._btnAddStamp = new System.Windows.Forms.Button();
         this._listBoxContainerStamps = new System.Windows.Forms.ListBox();
         this.label6 = new System.Windows.Forms.Label();
         this._groupBoxStampElements = new System.Windows.Forms.GroupBox();
         this._txtElements = new System.Windows.Forms.TextBox();
         this._btnAddDate = new System.Windows.Forms.Button();
         this._btnAddBatesNumber = new System.Windows.Forms.Button();
         this._groupBoxStampLogo = new System.Windows.Forms.GroupBox();
         this._btnDeleteLogoPicture = new System.Windows.Forms.Button();
         this._checkBoxStretchLogo = new System.Windows.Forms.CheckBox();
         this._groupBoxLogoPosition = new System.Windows.Forms.GroupBox();
         this._txtLogoPositionHeight = new System.Windows.Forms.TextBox();
         this._txtLogoPositionWidth = new System.Windows.Forms.TextBox();
         this._txtLogoPositionY = new System.Windows.Forms.TextBox();
         this._txtLogoPositionX = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this._txtLogoRotationAngle = new System.Windows.Forms.TextBox();
         this.label12 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this._txtLogoText = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this._txtLogoOpacity = new System.Windows.Forms.TextBox();
         this._btnLoadImage = new System.Windows.Forms.Button();
         this._logoPictureBox = new System.Windows.Forms.PictureBox();
         this._groupBoxStampAlignment = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._comboHorizontalAlignment = new System.Windows.Forms.ComboBox();
         this._comboVerticalAlignment = new System.Windows.Forms.ComboBox();
         this._groupBoxStampText = new System.Windows.Forms.GroupBox();
         this._lblBatesText = new System.Windows.Forms.Label();
         this._btnChangeFont = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._groupBoxPreview = new System.Windows.Forms.GroupBox();
         this._groupBoxViewer = new System.Windows.Forms.GroupBox();
         this._groupBoxSizeMode = new System.Windows.Forms.GroupBox();
         this.radioButtonNormal = new System.Windows.Forms.RadioButton();
         this._radioButtonFit = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox6.SuspendLayout();
         this._groupBoxStampElements.SuspendLayout();
         this._groupBoxStampLogo.SuspendLayout();
         this._groupBoxLogoPosition.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._logoPictureBox)).BeginInit();
         this._groupBoxStampAlignment.SuspendLayout();
         this._groupBoxStampText.SuspendLayout();
         this._groupBoxPreview.SuspendLayout();
         this._groupBoxSizeMode.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.groupBox6);
         this.groupBox1.Controls.Add(this._groupBoxStampElements);
         this.groupBox1.Controls.Add(this._groupBoxStampLogo);
         this.groupBox1.Controls.Add(this._groupBoxStampAlignment);
         this.groupBox1.Controls.Add(this._groupBoxStampText);
         this.groupBox1.Location = new System.Drawing.Point(6, 7);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(654, 647);
         this.groupBox1.TabIndex = 8;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Properties";
         // 
         // groupBox6
         // 
         this.groupBox6.Controls.Add(this._btnRemoveStamp);
         this.groupBox6.Controls.Add(this._btnAddStamp);
         this.groupBox6.Controls.Add(this._listBoxContainerStamps);
         this.groupBox6.Controls.Add(this.label6);
         this.groupBox6.Location = new System.Drawing.Point(17, 28);
         this.groupBox6.Name = "groupBox6";
         this.groupBox6.Size = new System.Drawing.Size(623, 61);
         this.groupBox6.TabIndex = 6;
         this.groupBox6.TabStop = false;
         this.groupBox6.Text = "Stamps";
         // 
         // _btnRemoveStamp
         // 
         this._btnRemoveStamp.Enabled = false;
         this._btnRemoveStamp.Location = new System.Drawing.Point(385, 24);
         this._btnRemoveStamp.Name = "_btnRemoveStamp";
         this._btnRemoveStamp.Size = new System.Drawing.Size(75, 23);
         this._btnRemoveStamp.TabIndex = 3;
         this._btnRemoveStamp.Text = "Remove";
         this._btnRemoveStamp.UseVisualStyleBackColor = true;
         this._btnRemoveStamp.Click += new System.EventHandler(this._btnRemoveStamp_Click);
         // 
         // _btnAddStamp
         // 
         this._btnAddStamp.Location = new System.Drawing.Point(287, 24);
         this._btnAddStamp.Name = "_btnAddStamp";
         this._btnAddStamp.Size = new System.Drawing.Size(75, 23);
         this._btnAddStamp.TabIndex = 1;
         this._btnAddStamp.Text = "Add";
         this._btnAddStamp.UseVisualStyleBackColor = true;
         this._btnAddStamp.Click += new System.EventHandler(this._btnAddStamp_Click);
         // 
         // _listBoxContainerStamps
         // 
         this._listBoxContainerStamps.FormattingEnabled = true;
         this._listBoxContainerStamps.Location = new System.Drawing.Point(131, 11);
         this._listBoxContainerStamps.Name = "_listBoxContainerStamps";
         this._listBoxContainerStamps.Size = new System.Drawing.Size(132, 43);
         this._listBoxContainerStamps.TabIndex = 2;
         this._listBoxContainerStamps.SelectedIndexChanged += new System.EventHandler(this._listBoxContainerStamps_SelectedIndexChanged);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(14, 29);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(102, 13);
         this.label6.TabIndex = 1;
         this.label6.Text = "Container Stamps : ";
         // 
         // _groupBoxStampElements
         // 
         this._groupBoxStampElements.Controls.Add(this._txtElements);
         this._groupBoxStampElements.Controls.Add(this._btnAddDate);
         this._groupBoxStampElements.Controls.Add(this._btnAddBatesNumber);
         this._groupBoxStampElements.Enabled = false;
         this._groupBoxStampElements.Location = new System.Drawing.Point(19, 489);
         this._groupBoxStampElements.Name = "_groupBoxStampElements";
         this._groupBoxStampElements.Size = new System.Drawing.Size(621, 153);
         this._groupBoxStampElements.TabIndex = 1;
         this._groupBoxStampElements.TabStop = false;
         this._groupBoxStampElements.Text = "Elements";
         // 
         // _txtElements
         // 
         this._txtElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._txtElements.Location = new System.Drawing.Point(15, 51);
         this._txtElements.Multiline = true;
         this._txtElements.Name = "_txtElements";
         this._txtElements.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this._txtElements.Size = new System.Drawing.Size(595, 96);
         this._txtElements.TabIndex = 11;
         this._txtElements.TextChanged += new System.EventHandler(this._txtElements_TextChanged);
         // 
         // _btnAddDate
         // 
         this._btnAddDate.Location = new System.Drawing.Point(186, 22);
         this._btnAddDate.Name = "_btnAddDate";
         this._btnAddDate.Size = new System.Drawing.Size(75, 23);
         this._btnAddDate.TabIndex = 1;
         this._btnAddDate.Text = "Add Date";
         this._btnAddDate.UseVisualStyleBackColor = true;
         this._btnAddDate.Click += new System.EventHandler(this.AddNewElement_Click);
         // 
         // _btnAddBatesNumber
         // 
         this._btnAddBatesNumber.Location = new System.Drawing.Point(15, 22);
         this._btnAddBatesNumber.Name = "_btnAddBatesNumber";
         this._btnAddBatesNumber.Size = new System.Drawing.Size(117, 23);
         this._btnAddBatesNumber.TabIndex = 7;
         this._btnAddBatesNumber.Text = "Add Number";
         this._btnAddBatesNumber.UseVisualStyleBackColor = true;
         this._btnAddBatesNumber.Click += new System.EventHandler(this.AddNewElement_Click);
         // 
         // _groupBoxStampLogo
         // 
         this._groupBoxStampLogo.Controls.Add(this._btnDeleteLogoPicture);
         this._groupBoxStampLogo.Controls.Add(this._checkBoxStretchLogo);
         this._groupBoxStampLogo.Controls.Add(this._groupBoxLogoPosition);
         this._groupBoxStampLogo.Controls.Add(this._txtLogoRotationAngle);
         this._groupBoxStampLogo.Controls.Add(this.label12);
         this._groupBoxStampLogo.Controls.Add(this.label11);
         this._groupBoxStampLogo.Controls.Add(this._txtLogoText);
         this._groupBoxStampLogo.Controls.Add(this.label10);
         this._groupBoxStampLogo.Controls.Add(this._txtLogoOpacity);
         this._groupBoxStampLogo.Controls.Add(this._btnLoadImage);
         this._groupBoxStampLogo.Controls.Add(this._logoPictureBox);
         this._groupBoxStampLogo.Enabled = false;
         this._groupBoxStampLogo.Location = new System.Drawing.Point(19, 338);
         this._groupBoxStampLogo.Name = "_groupBoxStampLogo";
         this._groupBoxStampLogo.Size = new System.Drawing.Size(621, 136);
         this._groupBoxStampLogo.TabIndex = 5;
         this._groupBoxStampLogo.TabStop = false;
         this._groupBoxStampLogo.Text = "Logo Properties";
         // 
         // _btnDeleteLogoPicture
         // 
         this._btnDeleteLogoPicture.Location = new System.Drawing.Point(140, 30);
         this._btnDeleteLogoPicture.Name = "_btnDeleteLogoPicture";
         this._btnDeleteLogoPicture.Size = new System.Drawing.Size(27, 23);
         this._btnDeleteLogoPicture.TabIndex = 18;
         this._btnDeleteLogoPicture.Text = "X";
         this._btnDeleteLogoPicture.UseVisualStyleBackColor = true;
         this._btnDeleteLogoPicture.Click += new System.EventHandler(this._btnDeleteLogoPicture_Click);
         // 
         // _checkBoxStretchLogo
         // 
         this._checkBoxStretchLogo.AutoSize = true;
         this._checkBoxStretchLogo.Location = new System.Drawing.Point(15, 95);
         this._checkBoxStretchLogo.Name = "_checkBoxStretchLogo";
         this._checkBoxStretchLogo.Size = new System.Drawing.Size(87, 17);
         this._checkBoxStretchLogo.TabIndex = 17;
         this._checkBoxStretchLogo.Text = "Stretch Logo";
         this._checkBoxStretchLogo.UseVisualStyleBackColor = true;
         this._checkBoxStretchLogo.CheckedChanged += new System.EventHandler(this._checkBoxStretchLogo_CheckedChanged);
         // 
         // _groupBoxLogoPosition
         // 
         this._groupBoxLogoPosition.Controls.Add(this._txtLogoPositionHeight);
         this._groupBoxLogoPosition.Controls.Add(this._txtLogoPositionWidth);
         this._groupBoxLogoPosition.Controls.Add(this._txtLogoPositionY);
         this._groupBoxLogoPosition.Controls.Add(this._txtLogoPositionX);
         this._groupBoxLogoPosition.Controls.Add(this.label4);
         this._groupBoxLogoPosition.Controls.Add(this.label5);
         this._groupBoxLogoPosition.Controls.Add(this.label9);
         this._groupBoxLogoPosition.Controls.Add(this.label8);
         this._groupBoxLogoPosition.Location = new System.Drawing.Point(111, 78);
         this._groupBoxLogoPosition.Name = "_groupBoxLogoPosition";
         this._groupBoxLogoPosition.Size = new System.Drawing.Size(499, 48);
         this._groupBoxLogoPosition.TabIndex = 10;
         this._groupBoxLogoPosition.TabStop = false;
         this._groupBoxLogoPosition.Text = "Position";
         // 
         // _txtLogoPositionHeight
         // 
         this._txtLogoPositionHeight.Location = new System.Drawing.Point(391, 19);
         this._txtLogoPositionHeight.Name = "_txtLogoPositionHeight";
         this._txtLogoPositionHeight.Size = new System.Drawing.Size(63, 20);
         this._txtLogoPositionHeight.TabIndex = 15;
         this._txtLogoPositionHeight.TextChanged += new System.EventHandler(this._txtLogoPosition_TextChanged);
         // 
         // _txtLogoPositionWidth
         // 
         this._txtLogoPositionWidth.Location = new System.Drawing.Point(267, 19);
         this._txtLogoPositionWidth.Name = "_txtLogoPositionWidth";
         this._txtLogoPositionWidth.Size = new System.Drawing.Size(63, 20);
         this._txtLogoPositionWidth.TabIndex = 14;
         this._txtLogoPositionWidth.TextChanged += new System.EventHandler(this._txtLogoPosition_TextChanged);
         // 
         // _txtLogoPositionY
         // 
         this._txtLogoPositionY.Location = new System.Drawing.Point(150, 19);
         this._txtLogoPositionY.Name = "_txtLogoPositionY";
         this._txtLogoPositionY.Size = new System.Drawing.Size(63, 20);
         this._txtLogoPositionY.TabIndex = 13;
         this._txtLogoPositionY.TextChanged += new System.EventHandler(this._txtLogoPosition_TextChanged);
         // 
         // _txtLogoPositionX
         // 
         this._txtLogoPositionX.Location = new System.Drawing.Point(48, 20);
         this._txtLogoPositionX.Name = "_txtLogoPositionX";
         this._txtLogoPositionX.Size = new System.Drawing.Size(63, 20);
         this._txtLogoPositionX.TabIndex = 12;
         this._txtLogoPositionX.TextChanged += new System.EventHandler(this._txtLogoPosition_TextChanged);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(226, 22);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(35, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Width";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(347, 22);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(38, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Height";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(28, 22);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(13, 13);
         this.label9.TabIndex = 7;
         this.label9.Text = "X";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(130, 22);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(13, 13);
         this.label8.TabIndex = 8;
         this.label8.Text = "Y";
         // 
         // _txtLogoRotationAngle
         // 
         this._txtLogoRotationAngle.Location = new System.Drawing.Point(550, 31);
         this._txtLogoRotationAngle.Name = "_txtLogoRotationAngle";
         this._txtLogoRotationAngle.Size = new System.Drawing.Size(60, 20);
         this._txtLogoRotationAngle.TabIndex = 16;
         this._txtLogoRotationAngle.TextChanged += new System.EventHandler(this._txtLogoRotationAngle_TextChanged);
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(511, 34);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(34, 13);
         this.label12.TabIndex = 15;
         this.label12.Text = "Angle";
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(173, 34);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(29, 13);
         this.label11.TabIndex = 14;
         this.label11.Text = "Text";
         // 
         // _txtLogoText
         // 
         this._txtLogoText.Location = new System.Drawing.Point(205, 31);
         this._txtLogoText.Name = "_txtLogoText";
         this._txtLogoText.Size = new System.Drawing.Size(177, 20);
         this._txtLogoText.TabIndex = 13;
         this._txtLogoText.TextChanged += new System.EventHandler(this._txtLogoText_TextChanged);
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(388, 34);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(44, 13);
         this.label10.TabIndex = 12;
         this.label10.Text = "Opacity";
         // 
         // _txtLogoOpacity
         // 
         this._txtLogoOpacity.Location = new System.Drawing.Point(438, 31);
         this._txtLogoOpacity.Name = "_txtLogoOpacity";
         this._txtLogoOpacity.Size = new System.Drawing.Size(63, 20);
         this._txtLogoOpacity.TabIndex = 11;
         this._txtLogoOpacity.TextChanged += new System.EventHandler(this._txtLogoOpacity_TextChanged);
         // 
         // _btnLoadImage
         // 
         this._btnLoadImage.Location = new System.Drawing.Point(3, 30);
         this._btnLoadImage.Name = "_btnLoadImage";
         this._btnLoadImage.Size = new System.Drawing.Size(75, 23);
         this._btnLoadImage.TabIndex = 2;
         this._btnLoadImage.Text = "Load Image";
         this._btnLoadImage.UseVisualStyleBackColor = true;
         this._btnLoadImage.Click += new System.EventHandler(this._btnLoadImage_Click);
         // 
         // _logoPictureBox
         // 
         this._logoPictureBox.Location = new System.Drawing.Point(82, 16);
         this._logoPictureBox.Name = "_logoPictureBox";
         this._logoPictureBox.Size = new System.Drawing.Size(52, 49);
         this._logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this._logoPictureBox.TabIndex = 1;
         this._logoPictureBox.TabStop = false;
         // 
         // _groupBoxStampAlignment
         // 
         this._groupBoxStampAlignment.Controls.Add(this.label2);
         this._groupBoxStampAlignment.Controls.Add(this.label1);
         this._groupBoxStampAlignment.Controls.Add(this._comboHorizontalAlignment);
         this._groupBoxStampAlignment.Controls.Add(this._comboVerticalAlignment);
         this._groupBoxStampAlignment.Enabled = false;
         this._groupBoxStampAlignment.Location = new System.Drawing.Point(17, 239);
         this._groupBoxStampAlignment.Name = "_groupBoxStampAlignment";
         this._groupBoxStampAlignment.Size = new System.Drawing.Size(623, 75);
         this._groupBoxStampAlignment.TabIndex = 4;
         this._groupBoxStampAlignment.TabStop = false;
         this._groupBoxStampAlignment.Text = "Alignment";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(273, 38);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(42, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "Vertical";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(33, 38);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(55, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Horizontal";
         // 
         // _comboHorizontalAlignment
         // 
         this._comboHorizontalAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboHorizontalAlignment.FormattingEnabled = true;
         this._comboHorizontalAlignment.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
         this._comboHorizontalAlignment.Location = new System.Drawing.Point(110, 35);
         this._comboHorizontalAlignment.Name = "_comboHorizontalAlignment";
         this._comboHorizontalAlignment.Size = new System.Drawing.Size(141, 21);
         this._comboHorizontalAlignment.TabIndex = 2;
         this._comboHorizontalAlignment.SelectedIndexChanged += new System.EventHandler(this._comboHorizontalAlignment_SelectedIndexChanged);
         // 
         // _comboVerticalAlignment
         // 
         this._comboVerticalAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboVerticalAlignment.FormattingEnabled = true;
         this._comboVerticalAlignment.Items.AddRange(new object[] {
            "Top",
            "Center",
            "Bottom"});
         this._comboVerticalAlignment.Location = new System.Drawing.Point(341, 35);
         this._comboVerticalAlignment.Name = "_comboVerticalAlignment";
         this._comboVerticalAlignment.Size = new System.Drawing.Size(141, 21);
         this._comboVerticalAlignment.TabIndex = 3;
         this._comboVerticalAlignment.SelectedIndexChanged += new System.EventHandler(this._comboVerticalAlignment_SelectedIndexChanged);
         // 
         // _groupBoxStampText
         // 
         this._groupBoxStampText.Controls.Add(this._lblBatesText);
         this._groupBoxStampText.Controls.Add(this._btnChangeFont);
         this._groupBoxStampText.Enabled = false;
         this._groupBoxStampText.Location = new System.Drawing.Point(17, 103);
         this._groupBoxStampText.Name = "_groupBoxStampText";
         this._groupBoxStampText.Size = new System.Drawing.Size(623, 119);
         this._groupBoxStampText.TabIndex = 0;
         this._groupBoxStampText.TabStop = false;
         this._groupBoxStampText.Text = "Stamp Text";
         // 
         // _lblBatesText
         // 
         this._lblBatesText.AutoSize = true;
         this._lblBatesText.Location = new System.Drawing.Point(120, 22);
         this._lblBatesText.Name = "_lblBatesText";
         this._lblBatesText.Size = new System.Drawing.Size(0, 13);
         this._lblBatesText.TabIndex = 0;
         // 
         // _btnChangeFont
         // 
         this._btnChangeFont.Location = new System.Drawing.Point(17, 86);
         this._btnChangeFont.Name = "_btnChangeFont";
         this._btnChangeFont.Size = new System.Drawing.Size(102, 23);
         this._btnChangeFont.TabIndex = 1;
         this._btnChangeFont.Text = "Change Font";
         this._btnChangeFont.UseVisualStyleBackColor = true;
         this._btnChangeFont.Click += new System.EventHandler(this._btnChangeFont_Click);
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(544, 675);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(128, 33);
         this._btnOK.TabIndex = 9;
         this._btnOK.Text = "Ok";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _groupBoxPreview
         // 
         this._groupBoxPreview.Controls.Add(this._groupBoxViewer);
         this._groupBoxPreview.Controls.Add(this._groupBoxSizeMode);
         this._groupBoxPreview.Location = new System.Drawing.Point(675, 7);
         this._groupBoxPreview.Name = "_groupBoxPreview";
         this._groupBoxPreview.Size = new System.Drawing.Size(654, 647);
         this._groupBoxPreview.TabIndex = 10;
         this._groupBoxPreview.TabStop = false;
         this._groupBoxPreview.Text = "Preview Area";
         // 
         // _groupBoxViewer
         // 
         this._groupBoxViewer.Location = new System.Drawing.Point(8, 19);
         this._groupBoxViewer.Name = "_groupBoxViewer";
         this._groupBoxViewer.Size = new System.Drawing.Size(640, 583);
         this._groupBoxViewer.TabIndex = 12;
         this._groupBoxViewer.TabStop = false;
         // 
         // _groupBoxSizeMode
         // 
         this._groupBoxSizeMode.Controls.Add(this.radioButtonNormal);
         this._groupBoxSizeMode.Controls.Add(this._radioButtonFit);
         this._groupBoxSizeMode.Location = new System.Drawing.Point(6, 608);
         this._groupBoxSizeMode.Name = "_groupBoxSizeMode";
         this._groupBoxSizeMode.Size = new System.Drawing.Size(642, 34);
         this._groupBoxSizeMode.TabIndex = 11;
         this._groupBoxSizeMode.TabStop = false;
         // 
         // radioButtonNormal
         // 
         this.radioButtonNormal.AutoSize = true;
         this.radioButtonNormal.Checked = true;
         this.radioButtonNormal.Location = new System.Drawing.Point(346, 13);
         this.radioButtonNormal.Name = "radioButtonNormal";
         this.radioButtonNormal.Size = new System.Drawing.Size(58, 17);
         this.radioButtonNormal.TabIndex = 13;
         this.radioButtonNormal.TabStop = true;
         this.radioButtonNormal.Text = "Normal";
         this.radioButtonNormal.UseVisualStyleBackColor = true;
         this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.radioButtonNormal_CheckedChanged);
         // 
         // _radioButtonFit
         // 
         this._radioButtonFit.AutoSize = true;
         this._radioButtonFit.Location = new System.Drawing.Point(284, 13);
         this._radioButtonFit.Name = "_radioButtonFit";
         this._radioButtonFit.Size = new System.Drawing.Size(37, 17);
         this._radioButtonFit.TabIndex = 12;
         this._radioButtonFit.Text = "Fit";
         this._radioButtonFit.UseVisualStyleBackColor = true;
         this._radioButtonFit.CheckedChanged += new System.EventHandler(this._radioButtonFit_CheckedChanged);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(701, 675);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(128, 33);
         this._btnCancel.TabIndex = 11;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // BatesStampDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(1337, 713);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._groupBoxPreview);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BatesStampDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Bate Stamp Properties";
         this.groupBox1.ResumeLayout(false);
         this.groupBox6.ResumeLayout(false);
         this.groupBox6.PerformLayout();
         this._groupBoxStampElements.ResumeLayout(false);
         this._groupBoxStampElements.PerformLayout();
         this._groupBoxStampLogo.ResumeLayout(false);
         this._groupBoxStampLogo.PerformLayout();
         this._groupBoxLogoPosition.ResumeLayout(false);
         this._groupBoxLogoPosition.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._logoPictureBox)).EndInit();
         this._groupBoxStampAlignment.ResumeLayout(false);
         this._groupBoxStampAlignment.PerformLayout();
         this._groupBoxStampText.ResumeLayout(false);
         this._groupBoxStampText.PerformLayout();
         this._groupBoxPreview.ResumeLayout(false);
         this._groupBoxSizeMode.ResumeLayout(false);
         this._groupBoxSizeMode.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox6;
      private System.Windows.Forms.Button _btnRemoveStamp;
      private System.Windows.Forms.Button _btnAddStamp;
      private System.Windows.Forms.ListBox _listBoxContainerStamps;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.GroupBox _groupBoxStampElements;
      private System.Windows.Forms.Button _btnAddDate;
      private System.Windows.Forms.Button _btnAddBatesNumber;
      private System.Windows.Forms.GroupBox _groupBoxStampLogo;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button _btnLoadImage;
      private System.Windows.Forms.PictureBox _logoPictureBox;
      private System.Windows.Forms.GroupBox _groupBoxStampAlignment;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox _comboHorizontalAlignment;
      private System.Windows.Forms.ComboBox _comboVerticalAlignment;
      private System.Windows.Forms.GroupBox _groupBoxStampText;
      private System.Windows.Forms.Label _lblBatesText;
      private System.Windows.Forms.Button _btnChangeFont;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox _txtLogoOpacity;
      private System.Windows.Forms.TextBox _txtLogoRotationAngle;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.TextBox _txtLogoText;
      private System.Windows.Forms.GroupBox _groupBoxLogoPosition;
      private System.Windows.Forms.CheckBox _checkBoxStretchLogo;
      private System.Windows.Forms.GroupBox _groupBoxPreview;
      private System.Windows.Forms.GroupBox _groupBoxSizeMode;
      private System.Windows.Forms.RadioButton radioButtonNormal;
      private System.Windows.Forms.RadioButton _radioButtonFit;
      private System.Windows.Forms.TextBox _txtElements;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnDeleteLogoPicture;
      private System.Windows.Forms.TextBox _txtLogoPositionHeight;
      private System.Windows.Forms.TextBox _txtLogoPositionWidth;
      private System.Windows.Forms.TextBox _txtLogoPositionY;
      private System.Windows.Forms.TextBox _txtLogoPositionX;
      private System.Windows.Forms.GroupBox _groupBoxViewer;
   }
}