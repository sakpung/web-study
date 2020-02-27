namespace OmrProcessingDemo.ViewerControl
{
   partial class OmrFieldDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OmrFieldDialog));
         this.tbLayout = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.grpGrading = new System.Windows.Forms.GroupBox();
         this.lblCorrectAnswerGrade = new System.Windows.Forms.Label();
         this._cbGrade = new System.Windows.Forms.CheckBox();
         this.lblEmptyAnswerGrade = new System.Windows.Forms.Label();
         this.lblIncorrectAnswerGrade = new System.Windows.Forms.Label();
         this._numNoResponse = new System.Windows.Forms.NumericUpDown();
         this._numIncorrect = new System.Windows.Forms.NumericUpDown();
         this._numCorrect = new System.Windows.Forms.NumericUpDown();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.rdbtnOrFreeflow = new System.Windows.Forms.RadioButton();
         this.rdbtnOrCols = new System.Windows.Forms.RadioButton();
         this.rdbtnOrRows = new System.Windows.Forms.RadioButton();
         this.label1 = new System.Windows.Forms.Label();
         this._txtFieldName = new System.Windows.Forms.TextBox();
         this.grpLabelOptions = new System.Windows.Forms.GroupBox();
         this.pnlImg = new System.Windows.Forms.Panel();
         this.label6 = new System.Windows.Forms.Label();
         this.txtValue = new System.Windows.Forms.TextBox();
         this.cboxValues = new System.Windows.Forms.ComboBox();
         this.lblvalue = new System.Windows.Forms.Label();
         this.grpGrid = new System.Windows.Forms.GroupBox();
         this.btnCreateCustom = new System.Windows.Forms.Button();
         this._lblValues = new System.Windows.Forms.Label();
         this.pnlOutputFormat = new System.Windows.Forms.Panel();
         this.lblFormatExample = new System.Windows.Forms.Label();
         this.lblOutputFormat = new System.Windows.Forms.Label();
         this.rdbtnFormatCSV = new System.Windows.Forms.RadioButton();
         this.rdbtnFormatAggregated = new System.Windows.Forms.RadioButton();
         this.lstValues = new System.Windows.Forms.ListBox();
         this._cbRightToLeft = new System.Windows.Forms.CheckBox();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this._highSensitivityLabel = new System.Windows.Forms.Label();
         this._highSensitivityPictureBox = new System.Windows.Forms.PictureBox();
         this._lowSensitivityLabel = new System.Windows.Forms.Label();
         this._lowSensitivityPictureBox = new System.Windows.Forms.PictureBox();
         this.label2 = new System.Windows.Forms.Label();
         this.grpSensitivity = new System.Windows.Forms.GroupBox();
         this.rdbtnSensLowest = new System.Windows.Forms.RadioButton();
         this.rdbtnSensLow = new System.Windows.Forms.RadioButton();
         this.rdbtnSensHigh = new System.Windows.Forms.RadioButton();
         this.rdbtnSensHighest = new System.Windows.Forms.RadioButton();
         this.tbLayout.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.grpGrading.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numNoResponse)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numIncorrect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numCorrect)).BeginInit();
         this.grpLabelOptions.SuspendLayout();
         this.grpGrid.SuspendLayout();
         this.pnlOutputFormat.SuspendLayout();
         this.tabPage2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._highSensitivityPictureBox)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._lowSensitivityPictureBox)).BeginInit();
         this.grpSensitivity.SuspendLayout();
         this.SuspendLayout();
         // 
         // tbLayout
         // 
         this.tbLayout.Controls.Add(this.tabPage1);
         this.tbLayout.Controls.Add(this.tabPage2);
         this.tbLayout.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tbLayout.Location = new System.Drawing.Point(0, 0);
         this.tbLayout.Name = "tbLayout";
         this.tbLayout.SelectedIndex = 0;
         this.tbLayout.Size = new System.Drawing.Size(287, 526);
         this.tbLayout.TabIndex = 0;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.grpGrading);
         this.tabPage1.Controls.Add(this.btnCancel);
         this.tabPage1.Controls.Add(this.btnOK);
         this.tabPage1.Controls.Add(this.rdbtnOrFreeflow);
         this.tabPage1.Controls.Add(this.rdbtnOrCols);
         this.tabPage1.Controls.Add(this.rdbtnOrRows);
         this.tabPage1.Controls.Add(this.label1);
         this.tabPage1.Controls.Add(this._txtFieldName);
         this.tabPage1.Controls.Add(this.grpLabelOptions);
         this.tabPage1.Controls.Add(this.grpGrid);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(279, 500);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Settings";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // grpGrading
         // 
         this.grpGrading.Controls.Add(this.lblCorrectAnswerGrade);
         this.grpGrading.Controls.Add(this._cbGrade);
         this.grpGrading.Controls.Add(this.lblEmptyAnswerGrade);
         this.grpGrading.Controls.Add(this.lblIncorrectAnswerGrade);
         this.grpGrading.Controls.Add(this._numNoResponse);
         this.grpGrading.Controls.Add(this._numIncorrect);
         this.grpGrading.Controls.Add(this._numCorrect);
         this.grpGrading.Location = new System.Drawing.Point(16, 326);
         this.grpGrading.Name = "grpGrading";
         this.grpGrading.Size = new System.Drawing.Size(243, 133);
         this.grpGrading.TabIndex = 39;
         this.grpGrading.TabStop = false;
         this.grpGrading.Text = "Grading Options";
         // 
         // lblCorrectAnswerGrade
         // 
         this.lblCorrectAnswerGrade.AutoSize = true;
         this.lblCorrectAnswerGrade.Location = new System.Drawing.Point(16, 51);
         this.lblCorrectAnswerGrade.Name = "lblCorrectAnswerGrade";
         this.lblCorrectAnswerGrade.Size = new System.Drawing.Size(114, 13);
         this.lblCorrectAnswerGrade.TabIndex = 36;
         this.lblCorrectAnswerGrade.Text = "Correct Answer Grade:";
         // 
         // _cbGrade
         // 
         this._cbGrade.AutoSize = true;
         this._cbGrade.Location = new System.Drawing.Point(61, 22);
         this._cbGrade.Name = "_cbGrade";
         this._cbGrade.Size = new System.Drawing.Size(115, 17);
         this._cbGrade.TabIndex = 35;
         this._cbGrade.Text = "Grade This Region";
         this._cbGrade.UseVisualStyleBackColor = true;
         this._cbGrade.CheckedChanged += new System.EventHandler(this._cbGrade_CheckedChanged);
         // 
         // lblEmptyAnswerGrade
         // 
         this.lblEmptyAnswerGrade.AutoSize = true;
         this.lblEmptyAnswerGrade.Location = new System.Drawing.Point(16, 102);
         this.lblEmptyAnswerGrade.Name = "lblEmptyAnswerGrade";
         this.lblEmptyAnswerGrade.Size = new System.Drawing.Size(109, 13);
         this.lblEmptyAnswerGrade.TabIndex = 34;
         this.lblEmptyAnswerGrade.Text = "Empty Answer Grade:";
         // 
         // lblIncorrectAnswerGrade
         // 
         this.lblIncorrectAnswerGrade.AutoSize = true;
         this.lblIncorrectAnswerGrade.Location = new System.Drawing.Point(16, 76);
         this.lblIncorrectAnswerGrade.Name = "lblIncorrectAnswerGrade";
         this.lblIncorrectAnswerGrade.Size = new System.Drawing.Size(122, 13);
         this.lblIncorrectAnswerGrade.TabIndex = 33;
         this.lblIncorrectAnswerGrade.Text = "Incorrect Answer Grade:";
         // 
         // _numNoResponse
         // 
         this._numNoResponse.DecimalPlaces = 2;
         this._numNoResponse.Enabled = false;
         this._numNoResponse.Location = new System.Drawing.Point(145, 100);
         this._numNoResponse.Name = "_numNoResponse";
         this._numNoResponse.Size = new System.Drawing.Size(76, 20);
         this._numNoResponse.TabIndex = 31;
         // 
         // _numIncorrect
         // 
         this._numIncorrect.DecimalPlaces = 2;
         this._numIncorrect.Enabled = false;
         this._numIncorrect.Location = new System.Drawing.Point(144, 74);
         this._numIncorrect.Name = "_numIncorrect";
         this._numIncorrect.Size = new System.Drawing.Size(76, 20);
         this._numIncorrect.TabIndex = 30;
         // 
         // _numCorrect
         // 
         this._numCorrect.DecimalPlaces = 2;
         this._numCorrect.Enabled = false;
         this._numCorrect.Location = new System.Drawing.Point(144, 48);
         this._numCorrect.Name = "_numCorrect";
         this._numCorrect.Size = new System.Drawing.Size(76, 20);
         this._numCorrect.TabIndex = 29;
         this._numCorrect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(170, 465);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 38;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(89, 465);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 38;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // rdbtnOrFreeflow
         // 
         this.rdbtnOrFreeflow.AutoSize = true;
         this.rdbtnOrFreeflow.Location = new System.Drawing.Point(180, 32);
         this.rdbtnOrFreeflow.Name = "rdbtnOrFreeflow";
         this.rdbtnOrFreeflow.Size = new System.Drawing.Size(65, 17);
         this.rdbtnOrFreeflow.TabIndex = 17;
         this.rdbtnOrFreeflow.TabStop = true;
         this.rdbtnOrFreeflow.Text = "Freeflow";
         this.rdbtnOrFreeflow.UseVisualStyleBackColor = true;
         this.rdbtnOrFreeflow.CheckedChanged += new System.EventHandler(this.rdbtnOrientation_CheckChanged);
         // 
         // rdbtnOrCols
         // 
         this.rdbtnOrCols.AutoSize = true;
         this.rdbtnOrCols.Location = new System.Drawing.Point(96, 32);
         this.rdbtnOrCols.Name = "rdbtnOrCols";
         this.rdbtnOrCols.Size = new System.Drawing.Size(65, 17);
         this.rdbtnOrCols.TabIndex = 16;
         this.rdbtnOrCols.TabStop = true;
         this.rdbtnOrCols.Text = "Columns";
         this.rdbtnOrCols.UseVisualStyleBackColor = true;
         this.rdbtnOrCols.CheckedChanged += new System.EventHandler(this.rdbtnOrientation_CheckChanged);
         // 
         // rdbtnOrRows
         // 
         this.rdbtnOrRows.AutoSize = true;
         this.rdbtnOrRows.Location = new System.Drawing.Point(24, 32);
         this.rdbtnOrRows.Name = "rdbtnOrRows";
         this.rdbtnOrRows.Size = new System.Drawing.Size(52, 17);
         this.rdbtnOrRows.TabIndex = 15;
         this.rdbtnOrRows.TabStop = true;
         this.rdbtnOrRows.Text = "Rows";
         this.rdbtnOrRows.UseVisualStyleBackColor = true;
         this.rdbtnOrRows.CheckedChanged += new System.EventHandler(this.rdbtnOrientation_CheckChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(15, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 14;
         this.label1.Text = "Name";
         // 
         // _txtFieldName
         // 
         this._txtFieldName.Location = new System.Drawing.Point(56, 6);
         this._txtFieldName.Name = "_txtFieldName";
         this._txtFieldName.Size = new System.Drawing.Size(196, 20);
         this._txtFieldName.TabIndex = 13;
         // 
         // grpLabelOptions
         // 
         this.grpLabelOptions.Controls.Add(this.pnlImg);
         this.grpLabelOptions.Controls.Add(this.label6);
         this.grpLabelOptions.Controls.Add(this.txtValue);
         this.grpLabelOptions.Controls.Add(this.cboxValues);
         this.grpLabelOptions.Controls.Add(this.lblvalue);
         this.grpLabelOptions.Location = new System.Drawing.Point(16, 55);
         this.grpLabelOptions.Name = "grpLabelOptions";
         this.grpLabelOptions.Size = new System.Drawing.Size(243, 265);
         this.grpLabelOptions.TabIndex = 38;
         this.grpLabelOptions.TabStop = false;
         this.grpLabelOptions.Text = "Label Options";
         // 
         // pnlImg
         // 
         this.pnlImg.BackColor = System.Drawing.SystemColors.ControlDark;
         this.pnlImg.Location = new System.Drawing.Point(10, 50);
         this.pnlImg.Name = "pnlImg";
         this.pnlImg.Size = new System.Drawing.Size(217, 164);
         this.pnlImg.TabIndex = 4;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(6, 23);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(36, 13);
         this.label6.TabIndex = 1;
         this.label6.Text = "Label:";
         // 
         // txtValue
         // 
         this.txtValue.Location = new System.Drawing.Point(47, 220);
         this.txtValue.Name = "txtValue";
         this.txtValue.Size = new System.Drawing.Size(153, 20);
         this.txtValue.TabIndex = 3;
         this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
         // 
         // cboxValues
         // 
         this.cboxValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboxValues.FormattingEnabled = true;
         this.cboxValues.Location = new System.Drawing.Point(47, 20);
         this.cboxValues.Name = "cboxValues";
         this.cboxValues.Size = new System.Drawing.Size(153, 21);
         this.cboxValues.TabIndex = 0;
         this.cboxValues.SelectedIndexChanged += new System.EventHandler(this.cboxValues_SelectedIndexChanged);
         // 
         // lblvalue
         // 
         this.lblvalue.AutoSize = true;
         this.lblvalue.Location = new System.Drawing.Point(7, 223);
         this.lblvalue.Name = "lblvalue";
         this.lblvalue.Size = new System.Drawing.Size(37, 13);
         this.lblvalue.TabIndex = 2;
         this.lblvalue.Text = "Value:";
         // 
         // grpGrid
         // 
         this.grpGrid.Controls.Add(this.btnCreateCustom);
         this.grpGrid.Controls.Add(this._lblValues);
         this.grpGrid.Controls.Add(this.pnlOutputFormat);
         this.grpGrid.Controls.Add(this.lstValues);
         this.grpGrid.Controls.Add(this._cbRightToLeft);
         this.grpGrid.Location = new System.Drawing.Point(16, 55);
         this.grpGrid.Name = "grpGrid";
         this.grpGrid.Size = new System.Drawing.Size(243, 265);
         this.grpGrid.TabIndex = 37;
         this.grpGrid.TabStop = false;
         this.grpGrid.Text = "Grid Options";
         // 
         // btnCreateCustom
         // 
         this.btnCreateCustom.Location = new System.Drawing.Point(40, 148);
         this.btnCreateCustom.Name = "btnCreateCustom";
         this.btnCreateCustom.Size = new System.Drawing.Size(163, 23);
         this.btnCreateCustom.TabIndex = 39;
         this.btnCreateCustom.Text = "&Create Custom Range...";
         this.btnCreateCustom.UseVisualStyleBackColor = true;
         this.btnCreateCustom.Click += new System.EventHandler(this.btnCreateCustom_Click);
         // 
         // _lblValues
         // 
         this._lblValues.AutoSize = true;
         this._lblValues.Location = new System.Drawing.Point(13, 23);
         this._lblValues.Name = "_lblValues";
         this._lblValues.Size = new System.Drawing.Size(39, 13);
         this._lblValues.TabIndex = 36;
         this._lblValues.Text = "Values";
         // 
         // pnlOutputFormat
         // 
         this.pnlOutputFormat.Controls.Add(this.lblFormatExample);
         this.pnlOutputFormat.Controls.Add(this.lblOutputFormat);
         this.pnlOutputFormat.Controls.Add(this.rdbtnFormatCSV);
         this.pnlOutputFormat.Controls.Add(this.rdbtnFormatAggregated);
         this.pnlOutputFormat.Location = new System.Drawing.Point(13, 177);
         this.pnlOutputFormat.Name = "pnlOutputFormat";
         this.pnlOutputFormat.Size = new System.Drawing.Size(204, 82);
         this.pnlOutputFormat.TabIndex = 38;
         // 
         // lblFormatExample
         // 
         this.lblFormatExample.AutoSize = true;
         this.lblFormatExample.Location = new System.Drawing.Point(54, 68);
         this.lblFormatExample.Name = "lblFormatExample";
         this.lblFormatExample.Size = new System.Drawing.Size(36, 13);
         this.lblFormatExample.TabIndex = 34;
         this.lblFormatExample.Text = "ABCD";
         // 
         // lblOutputFormat
         // 
         this.lblOutputFormat.AutoSize = true;
         this.lblOutputFormat.Location = new System.Drawing.Point(12, 9);
         this.lblOutputFormat.Name = "lblOutputFormat";
         this.lblOutputFormat.Size = new System.Drawing.Size(68, 13);
         this.lblOutputFormat.TabIndex = 31;
         this.lblOutputFormat.Text = "Output Style:";
         // 
         // rdbtnFormatCSV
         // 
         this.rdbtnFormatCSV.AutoSize = true;
         this.rdbtnFormatCSV.Location = new System.Drawing.Point(38, 25);
         this.rdbtnFormatCSV.Name = "rdbtnFormatCSV";
         this.rdbtnFormatCSV.Size = new System.Drawing.Size(112, 17);
         this.rdbtnFormatCSV.TabIndex = 33;
         this.rdbtnFormatCSV.TabStop = true;
         this.rdbtnFormatCSV.Text = "Comma-Separated";
         this.rdbtnFormatCSV.UseVisualStyleBackColor = true;
         this.rdbtnFormatCSV.CheckedChanged += new System.EventHandler(this.rdbtnFormatValue_CheckChanged);
         // 
         // rdbtnFormatAggregated
         // 
         this.rdbtnFormatAggregated.AutoSize = true;
         this.rdbtnFormatAggregated.Location = new System.Drawing.Point(38, 48);
         this.rdbtnFormatAggregated.Name = "rdbtnFormatAggregated";
         this.rdbtnFormatAggregated.Size = new System.Drawing.Size(72, 17);
         this.rdbtnFormatAggregated.TabIndex = 32;
         this.rdbtnFormatAggregated.TabStop = true;
         this.rdbtnFormatAggregated.Text = "Combined";
         this.rdbtnFormatAggregated.UseVisualStyleBackColor = true;
         this.rdbtnFormatAggregated.CheckedChanged += new System.EventHandler(this.rdbtnFormatValue_CheckChanged);
         // 
         // lstValues
         // 
         this.lstValues.FormattingEnabled = true;
         this.lstValues.Location = new System.Drawing.Point(13, 45);
         this.lstValues.Name = "lstValues";
         this.lstValues.Size = new System.Drawing.Size(204, 95);
         this.lstValues.TabIndex = 35;
         this.lstValues.SelectedIndexChanged += new System.EventHandler(this.lstValues_SelectedIndexChanged);
         this.lstValues.DoubleClick += new System.EventHandler(this.lstValues_DoubleClick);
         // 
         // _cbRightToLeft
         // 
         this._cbRightToLeft.AutoSize = true;
         this._cbRightToLeft.Location = new System.Drawing.Point(113, 22);
         this._cbRightToLeft.Name = "_cbRightToLeft";
         this._cbRightToLeft.Size = new System.Drawing.Size(88, 17);
         this._cbRightToLeft.TabIndex = 37;
         this._cbRightToLeft.Text = "Right To Left";
         this._cbRightToLeft.UseVisualStyleBackColor = true;
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this._highSensitivityLabel);
         this.tabPage2.Controls.Add(this._highSensitivityPictureBox);
         this.tabPage2.Controls.Add(this._lowSensitivityLabel);
         this.tabPage2.Controls.Add(this._lowSensitivityPictureBox);
         this.tabPage2.Controls.Add(this.label2);
         this.tabPage2.Controls.Add(this.grpSensitivity);
         this.tabPage2.Location = new System.Drawing.Point(4, 22);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage2.Size = new System.Drawing.Size(279, 500);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Sensitivity";
         this.tabPage2.UseVisualStyleBackColor = true;
         // 
         // _highSensitivityLabel
         // 
         this._highSensitivityLabel.AutoSize = true;
         this._highSensitivityLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._highSensitivityLabel.Location = new System.Drawing.Point(9, 95);
         this._highSensitivityLabel.Name = "_highSensitivityLabel";
         this._highSensitivityLabel.Size = new System.Drawing.Size(213, 13);
         this._highSensitivityLabel.TabIndex = 30;
         this._highSensitivityLabel.Text = "For marks like these, select High Sensitivity.";
         // 
         // _highSensitivityPictureBox
         // 
         this._highSensitivityPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_highSensitivityPictureBox.Image")));
         this._highSensitivityPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._highSensitivityPictureBox.Location = new System.Drawing.Point(95, 111);
         this._highSensitivityPictureBox.Name = "_highSensitivityPictureBox";
         this._highSensitivityPictureBox.Size = new System.Drawing.Size(110, 52);
         this._highSensitivityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this._highSensitivityPictureBox.TabIndex = 31;
         this._highSensitivityPictureBox.TabStop = false;
         // 
         // _lowSensitivityLabel
         // 
         this._lowSensitivityLabel.AutoSize = true;
         this._lowSensitivityLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._lowSensitivityLabel.Location = new System.Drawing.Point(9, 41);
         this._lowSensitivityLabel.Name = "_lowSensitivityLabel";
         this._lowSensitivityLabel.Size = new System.Drawing.Size(211, 13);
         this._lowSensitivityLabel.TabIndex = 29;
         this._lowSensitivityLabel.Text = "For marks like these, select Low Sensitivity.";
         // 
         // _lowSensitivityPictureBox
         // 
         this._lowSensitivityPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_lowSensitivityPictureBox.Image")));
         this._lowSensitivityPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._lowSensitivityPictureBox.Location = new System.Drawing.Point(95, 57);
         this._lowSensitivityPictureBox.Name = "_lowSensitivityPictureBox";
         this._lowSensitivityPictureBox.Size = new System.Drawing.Size(110, 27);
         this._lowSensitivityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this._lowSensitivityPictureBox.TabIndex = 28;
         this._lowSensitivityPictureBox.TabStop = false;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 17);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(257, 13);
         this.label2.TabIndex = 27;
         this.label2.Text = "Use the samples to help you pick the correct options:";
         // 
         // grpSensitivity
         // 
         this.grpSensitivity.Controls.Add(this.rdbtnSensLowest);
         this.grpSensitivity.Controls.Add(this.rdbtnSensLow);
         this.grpSensitivity.Controls.Add(this.rdbtnSensHigh);
         this.grpSensitivity.Controls.Add(this.rdbtnSensHighest);
         this.grpSensitivity.Location = new System.Drawing.Point(12, 169);
         this.grpSensitivity.Name = "grpSensitivity";
         this.grpSensitivity.Size = new System.Drawing.Size(260, 126);
         this.grpSensitivity.TabIndex = 26;
         this.grpSensitivity.TabStop = false;
         this.grpSensitivity.Text = "OMR Mark Sensitivity";
         // 
         // rdbtnSensLowest
         // 
         this.rdbtnSensLowest.AutoSize = true;
         this.rdbtnSensLowest.Location = new System.Drawing.Point(6, 28);
         this.rdbtnSensLowest.Name = "rdbtnSensLowest";
         this.rdbtnSensLowest.Size = new System.Drawing.Size(59, 17);
         this.rdbtnSensLowest.TabIndex = 3;
         this.rdbtnSensLowest.TabStop = true;
         this.rdbtnSensLowest.Text = "Lowest";
         this.rdbtnSensLowest.UseVisualStyleBackColor = true;
         // 
         // rdbtnSensLow
         // 
         this.rdbtnSensLow.AutoSize = true;
         this.rdbtnSensLow.Location = new System.Drawing.Point(6, 51);
         this.rdbtnSensLow.Name = "rdbtnSensLow";
         this.rdbtnSensLow.Size = new System.Drawing.Size(45, 17);
         this.rdbtnSensLow.TabIndex = 2;
         this.rdbtnSensLow.TabStop = true;
         this.rdbtnSensLow.Text = "Low";
         this.rdbtnSensLow.UseVisualStyleBackColor = true;
         // 
         // rdbtnSensHigh
         // 
         this.rdbtnSensHigh.AutoSize = true;
         this.rdbtnSensHigh.Location = new System.Drawing.Point(6, 74);
         this.rdbtnSensHigh.Name = "rdbtnSensHigh";
         this.rdbtnSensHigh.Size = new System.Drawing.Size(47, 17);
         this.rdbtnSensHigh.TabIndex = 1;
         this.rdbtnSensHigh.TabStop = true;
         this.rdbtnSensHigh.Text = "High";
         this.rdbtnSensHigh.UseVisualStyleBackColor = true;
         // 
         // rdbtnSensHighest
         // 
         this.rdbtnSensHighest.AutoSize = true;
         this.rdbtnSensHighest.Location = new System.Drawing.Point(6, 97);
         this.rdbtnSensHighest.Name = "rdbtnSensHighest";
         this.rdbtnSensHighest.Size = new System.Drawing.Size(61, 17);
         this.rdbtnSensHighest.TabIndex = 0;
         this.rdbtnSensHighest.TabStop = true;
         this.rdbtnSensHighest.Text = "Highest";
         this.rdbtnSensHighest.UseVisualStyleBackColor = true;
         // 
         // OmrFieldDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(287, 526);
         this.Controls.Add(this.tbLayout);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OmrFieldDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OMR Field Options";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OmrFieldDialog_FormClosing);
         this.tbLayout.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         this.grpGrading.ResumeLayout(false);
         this.grpGrading.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numNoResponse)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numIncorrect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numCorrect)).EndInit();
         this.grpLabelOptions.ResumeLayout(false);
         this.grpLabelOptions.PerformLayout();
         this.grpGrid.ResumeLayout(false);
         this.grpGrid.PerformLayout();
         this.pnlOutputFormat.ResumeLayout(false);
         this.pnlOutputFormat.PerformLayout();
         this.tabPage2.ResumeLayout(false);
         this.tabPage2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._highSensitivityPictureBox)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._lowSensitivityPictureBox)).EndInit();
         this.grpSensitivity.ResumeLayout(false);
         this.grpSensitivity.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tbLayout;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.TabPage tabPage2;
      private System.Windows.Forms.RadioButton rdbtnOrFreeflow;
      private System.Windows.Forms.RadioButton rdbtnOrCols;
      private System.Windows.Forms.RadioButton rdbtnOrRows;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _txtFieldName;
      private System.Windows.Forms.GroupBox grpSensitivity;
      private System.Windows.Forms.RadioButton rdbtnSensLowest;
      private System.Windows.Forms.RadioButton rdbtnSensLow;
      private System.Windows.Forms.RadioButton rdbtnSensHigh;
      private System.Windows.Forms.RadioButton rdbtnSensHighest;
      private System.Windows.Forms.Panel pnlImg;
      private System.Windows.Forms.TextBox txtValue;
      private System.Windows.Forms.Label lblvalue;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ComboBox cboxValues;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.GroupBox grpLabelOptions;
      private System.Windows.Forms.GroupBox grpGrid;
      private System.Windows.Forms.Label _lblValues;
      private System.Windows.Forms.Panel pnlOutputFormat;
      private System.Windows.Forms.Label lblOutputFormat;
      private System.Windows.Forms.RadioButton rdbtnFormatCSV;
      private System.Windows.Forms.RadioButton rdbtnFormatAggregated;
      private System.Windows.Forms.ListBox lstValues;
      private System.Windows.Forms.CheckBox _cbRightToLeft;
      private System.Windows.Forms.GroupBox grpGrading;
      private System.Windows.Forms.CheckBox _cbGrade;
      private System.Windows.Forms.Label lblIncorrectAnswerGrade;
      private System.Windows.Forms.NumericUpDown _numNoResponse;
      private System.Windows.Forms.NumericUpDown _numIncorrect;
      private System.Windows.Forms.NumericUpDown _numCorrect;
      private System.Windows.Forms.Label lblCorrectAnswerGrade;
      private System.Windows.Forms.Label lblEmptyAnswerGrade;
      private System.Windows.Forms.Label lblFormatExample;
      private System.Windows.Forms.Button btnCreateCustom;
      private System.Windows.Forms.Label _highSensitivityLabel;
      private System.Windows.Forms.PictureBox _highSensitivityPictureBox;
      private System.Windows.Forms.Label _lowSensitivityLabel;
      private System.Windows.Forms.PictureBox _lowSensitivityPictureBox;
      private System.Windows.Forms.Label label2;
   }
}