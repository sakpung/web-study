namespace DicomDemo
{
    partial class EditSeriesDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSeriesDialog));
         this.SearchButton = new System.Windows.Forms.Button();
         this.ActionButton = new System.Windows.Forms.Button();
         this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
         this.comboBoxSex = new System.Windows.Forms.ComboBox();
         this.textBoxFirstname = new System.Windows.Forms.TextBox();
         this.textBoxLastname = new System.Windows.Forms.TextBox();
         this.textBoxId = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.radioButtonChangeSeries = new System.Windows.Forms.RadioButton();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.DateOfBirth = new System.Windows.Forms.Label();
         this.Sex = new System.Windows.Forms.Label();
         this.FirstName = new System.Windows.Forms.Label();
         this.LastName = new System.Windows.Forms.Label();
         this.PatientId = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.SeriesTime = new System.Windows.Forms.Label();
         this.label16 = new System.Windows.Forms.Label();
         this.SeriesModality = new System.Windows.Forms.Label();
         this.SeriesDescription = new System.Windows.Forms.Label();
         this.SeriesDate = new System.Windows.Forms.Label();
         this.label19 = new System.Windows.Forms.Label();
         this.label20 = new System.Windows.Forms.Label();
         this.label21 = new System.Windows.Forms.Label();
         this.dateTimePickerSeriesDate = new System.Windows.Forms.DateTimePicker();
         this.label12 = new System.Windows.Forms.Label();
         this.textBoxDescription = new System.Windows.Forms.TextBox();
         this.label13 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.comboBoxModality = new System.Windows.Forms.ComboBox();
         this.CopyButton = new System.Windows.Forms.Button();
         this.radioButtonMoveSeriesToExistingPatient = new System.Windows.Forms.RadioButton();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.dateTimePickerSeriesTime = new System.Windows.Forms.DateTimePicker();
         this.label17 = new System.Windows.Forms.Label();
         this.radioButtonMoveStudyToNewPatient = new System.Windows.Forms.RadioButton();
         this.radioButtonMoveStudyToExistingPatient = new System.Windows.Forms.RadioButton();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.txtUID = new System.Windows.Forms.TextBox();
         this.label15 = new System.Windows.Forms.Label();
         this.dateTimePickerStudyDate = new System.Windows.Forms.DateTimePicker();
         this.btnStudy = new System.Windows.Forms.Button();
         this.txtID = new System.Windows.Forms.TextBox();
         this.label28 = new System.Windows.Forms.Label();
         this.txtDescription = new System.Windows.Forms.TextBox();
         this.label27 = new System.Windows.Forms.Label();
         this.label26 = new System.Windows.Forms.Label();
         this.label23 = new System.Windows.Forms.Label();
         this.txtAccession = new System.Windows.Forms.TextBox();
         this.OtherPatientIds = new System.Windows.Forms.Label();
         this.label18 = new System.Windows.Forms.Label();
         this.textBoxOtherPid = new System.Windows.Forms.TextBox();
         this.label22 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.tabPage2.SuspendLayout();
         this.SuspendLayout();
         // 
         // SearchButton
         // 
         this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.SearchButton.Location = new System.Drawing.Point(284, 46);
         this.SearchButton.Name = "SearchButton";
         this.SearchButton.Size = new System.Drawing.Size(94, 23);
         this.SearchButton.TabIndex = 24;
         this.SearchButton.Text = "Search";
         this.SearchButton.UseVisualStyleBackColor = true;
         this.SearchButton.Visible = false;
         this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
         // 
         // ActionButton
         // 
         this.ActionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.ActionButton.Location = new System.Drawing.Point(234, 394);
         this.ActionButton.Name = "ActionButton";
         this.ActionButton.Size = new System.Drawing.Size(144, 39);
         this.ActionButton.TabIndex = 26;
         this.ActionButton.Text = "Change";
         this.ActionButton.UseVisualStyleBackColor = true;
         this.ActionButton.Click += new System.EventHandler(this.ActionButton_Click);
         // 
         // dateTimePickerBirth
         // 
         this.dateTimePickerBirth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerBirth.Location = new System.Drawing.Point(79, 183);
         this.dateTimePickerBirth.Name = "dateTimePickerBirth";
         this.dateTimePickerBirth.ShowCheckBox = true;
         this.dateTimePickerBirth.Size = new System.Drawing.Size(299, 20);
         this.dateTimePickerBirth.TabIndex = 15;
         // 
         // comboBoxSex
         // 
         this.comboBoxSex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxSex.FormattingEnabled = true;
         this.comboBoxSex.Items.AddRange(new object[] {
            "M",
            "F",
            "O",
            ""});
         this.comboBoxSex.Location = new System.Drawing.Point(79, 155);
         this.comboBoxSex.Name = "comboBoxSex";
         this.comboBoxSex.Size = new System.Drawing.Size(299, 21);
         this.comboBoxSex.TabIndex = 13;
         // 
         // textBoxFirstname
         // 
         this.textBoxFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxFirstname.Location = new System.Drawing.Point(79, 128);
         this.textBoxFirstname.Name = "textBoxFirstname";
         this.textBoxFirstname.Size = new System.Drawing.Size(299, 20);
         this.textBoxFirstname.TabIndex = 11;
         this.textBoxFirstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Uppercase_KeyPress);
         // 
         // textBoxLastname
         // 
         this.textBoxLastname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxLastname.Location = new System.Drawing.Point(79, 101);
         this.textBoxLastname.Name = "textBoxLastname";
         this.textBoxLastname.Size = new System.Drawing.Size(299, 20);
         this.textBoxLastname.TabIndex = 9;
         this.textBoxLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Uppercase_KeyPress);
         // 
         // textBoxId
         // 
         this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxId.Location = new System.Drawing.Point(79, 47);
         this.textBoxId.Name = "textBoxId";
         this.textBoxId.Size = new System.Drawing.Size(199, 20);
         this.textBoxId.TabIndex = 5;
         this.textBoxId.TextChanged += new System.EventHandler(this.textBoxId_TextChanged);
         this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.ForeColor = System.Drawing.Color.Black;
         this.label7.Location = new System.Drawing.Point(4, 187);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(69, 13);
         this.label7.TabIndex = 14;
         this.label7.Text = "Date of Birth:";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.ForeColor = System.Drawing.Color.Black;
         this.label8.Location = new System.Drawing.Point(45, 158);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(28, 13);
         this.label8.TabIndex = 12;
         this.label8.Text = "Sex:";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.ForeColor = System.Drawing.Color.Black;
         this.label9.Location = new System.Drawing.Point(13, 132);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(60, 13);
         this.label9.TabIndex = 10;
         this.label9.Text = "First Name:";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.ForeColor = System.Drawing.Color.Black;
         this.label10.Location = new System.Drawing.Point(12, 105);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(61, 13);
         this.label10.TabIndex = 8;
         this.label10.Text = "Last Name:";
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.ForeColor = System.Drawing.Color.Black;
         this.label11.Location = new System.Drawing.Point(16, 51);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(57, 13);
         this.label11.TabIndex = 4;
         this.label11.Text = "Patient ID:";
         // 
         // radioButtonChangeSeries
         // 
         this.radioButtonChangeSeries.AutoSize = true;
         this.radioButtonChangeSeries.Checked = true;
         this.radioButtonChangeSeries.Location = new System.Drawing.Point(7, 6);
         this.radioButtonChangeSeries.Name = "radioButtonChangeSeries";
         this.radioButtonChangeSeries.Size = new System.Drawing.Size(115, 17);
         this.radioButtonChangeSeries.TabIndex = 0;
         this.radioButtonChangeSeries.TabStop = true;
         this.radioButtonChangeSeries.Text = "Change Series Info";
         this.radioButtonChangeSeries.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(242, 12);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(296, 25);
         this.label1.TabIndex = 2;
         this.label1.Text = "What would you like to do?";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.OtherPatientIds);
         this.groupBox1.Controls.Add(this.label18);
         this.groupBox1.Controls.Add(this.DateOfBirth);
         this.groupBox1.Controls.Add(this.Sex);
         this.groupBox1.Controls.Add(this.FirstName);
         this.groupBox1.Controls.Add(this.LastName);
         this.groupBox1.Controls.Add(this.PatientId);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.ForeColor = System.Drawing.Color.Blue;
         this.groupBox1.Location = new System.Drawing.Point(12, 62);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(224, 221);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Existing Patient Info";
         // 
         // DateOfBirth
         // 
         this.DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.DateOfBirth.ForeColor = System.Drawing.Color.Black;
         this.DateOfBirth.Location = new System.Drawing.Point(80, 187);
         this.DateOfBirth.Name = "DateOfBirth";
         this.DateOfBirth.Size = new System.Drawing.Size(136, 13);
         this.DateOfBirth.TabIndex = 10;
         this.DateOfBirth.Text = "label7";
         // 
         // Sex
         // 
         this.Sex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Sex.ForeColor = System.Drawing.Color.Black;
         this.Sex.Location = new System.Drawing.Point(80, 159);
         this.Sex.Name = "Sex";
         this.Sex.Size = new System.Drawing.Size(136, 13);
         this.Sex.TabIndex = 9;
         this.Sex.Text = "label7";
         // 
         // FirstName
         // 
         this.FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FirstName.ForeColor = System.Drawing.Color.Black;
         this.FirstName.Location = new System.Drawing.Point(80, 132);
         this.FirstName.Name = "FirstName";
         this.FirstName.Size = new System.Drawing.Size(136, 13);
         this.FirstName.TabIndex = 7;
         this.FirstName.Text = "label7";
         // 
         // LastName
         // 
         this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LastName.ForeColor = System.Drawing.Color.Black;
         this.LastName.Location = new System.Drawing.Point(80, 105);
         this.LastName.Name = "LastName";
         this.LastName.Size = new System.Drawing.Size(136, 13);
         this.LastName.TabIndex = 5;
         this.LastName.Text = "label7";
         // 
         // PatientId
         // 
         this.PatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.PatientId.ForeColor = System.Drawing.Color.Black;
         this.PatientId.Location = new System.Drawing.Point(80, 51);
         this.PatientId.Name = "PatientId";
         this.PatientId.Size = new System.Drawing.Size(136, 13);
         this.PatientId.TabIndex = 1;
         this.PatientId.Text = "label7";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.ForeColor = System.Drawing.Color.Black;
         this.label6.Location = new System.Drawing.Point(5, 187);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(69, 13);
         this.label6.TabIndex = 8;
         this.label6.Text = "Date of Birth:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.ForeColor = System.Drawing.Color.Black;
         this.label5.Location = new System.Drawing.Point(46, 159);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(28, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Sex:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.ForeColor = System.Drawing.Color.Black;
         this.label4.Location = new System.Drawing.Point(14, 132);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(60, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "First Name:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.ForeColor = System.Drawing.Color.Black;
         this.label3.Location = new System.Drawing.Point(13, 105);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(61, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Last Name:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.ForeColor = System.Drawing.Color.Black;
         this.label2.Location = new System.Drawing.Point(17, 51);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(57, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Patient ID:";
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBox2.Controls.Add(this.SeriesTime);
         this.groupBox2.Controls.Add(this.label16);
         this.groupBox2.Controls.Add(this.SeriesModality);
         this.groupBox2.Controls.Add(this.SeriesDescription);
         this.groupBox2.Controls.Add(this.SeriesDate);
         this.groupBox2.Controls.Add(this.label19);
         this.groupBox2.Controls.Add(this.label20);
         this.groupBox2.Controls.Add(this.label21);
         this.groupBox2.ForeColor = System.Drawing.Color.Blue;
         this.groupBox2.Location = new System.Drawing.Point(12, 299);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(224, 204);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Existing Series Info";
         // 
         // SeriesTime
         // 
         this.SeriesTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.SeriesTime.ForeColor = System.Drawing.Color.Black;
         this.SeriesTime.Location = new System.Drawing.Point(80, 51);
         this.SeriesTime.Name = "SeriesTime";
         this.SeriesTime.Size = new System.Drawing.Size(136, 13);
         this.SeriesTime.TabIndex = 3;
         this.SeriesTime.Text = "label7";
         // 
         // label16
         // 
         this.label16.AutoSize = true;
         this.label16.ForeColor = System.Drawing.Color.Black;
         this.label16.Location = new System.Drawing.Point(17, 51);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(65, 13);
         this.label16.TabIndex = 2;
         this.label16.Text = "Series Time:";
         // 
         // SeriesModality
         // 
         this.SeriesModality.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.SeriesModality.ForeColor = System.Drawing.Color.Black;
         this.SeriesModality.Location = new System.Drawing.Point(80, 109);
         this.SeriesModality.Name = "SeriesModality";
         this.SeriesModality.Size = new System.Drawing.Size(136, 13);
         this.SeriesModality.TabIndex = 7;
         this.SeriesModality.Text = "label7";
         // 
         // SeriesDescription
         // 
         this.SeriesDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.SeriesDescription.ForeColor = System.Drawing.Color.Black;
         this.SeriesDescription.Location = new System.Drawing.Point(80, 80);
         this.SeriesDescription.Name = "SeriesDescription";
         this.SeriesDescription.Size = new System.Drawing.Size(136, 13);
         this.SeriesDescription.TabIndex = 5;
         this.SeriesDescription.Text = "label7";
         // 
         // SeriesDate
         // 
         this.SeriesDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.SeriesDate.ForeColor = System.Drawing.Color.Black;
         this.SeriesDate.Location = new System.Drawing.Point(80, 25);
         this.SeriesDate.Name = "SeriesDate";
         this.SeriesDate.Size = new System.Drawing.Size(136, 13);
         this.SeriesDate.TabIndex = 1;
         this.SeriesDate.Text = "label7";
         // 
         // label19
         // 
         this.label19.AutoSize = true;
         this.label19.ForeColor = System.Drawing.Color.Black;
         this.label19.Location = new System.Drawing.Point(33, 109);
         this.label19.Name = "label19";
         this.label19.Size = new System.Drawing.Size(49, 13);
         this.label19.TabIndex = 6;
         this.label19.Text = "Modality:";
         // 
         // label20
         // 
         this.label20.AutoSize = true;
         this.label20.ForeColor = System.Drawing.Color.Black;
         this.label20.Location = new System.Drawing.Point(15, 80);
         this.label20.Name = "label20";
         this.label20.Size = new System.Drawing.Size(67, 13);
         this.label20.TabIndex = 4;
         this.label20.Text = "Series Desc:";
         // 
         // label21
         // 
         this.label21.AutoSize = true;
         this.label21.ForeColor = System.Drawing.Color.Black;
         this.label21.Location = new System.Drawing.Point(17, 25);
         this.label21.Name = "label21";
         this.label21.Size = new System.Drawing.Size(65, 13);
         this.label21.TabIndex = 0;
         this.label21.Text = "Series Date:";
         // 
         // dateTimePickerSeriesDate
         // 
         this.dateTimePickerSeriesDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dateTimePickerSeriesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerSeriesDate.Location = new System.Drawing.Point(79, 257);
         this.dateTimePickerSeriesDate.Name = "dateTimePickerSeriesDate";
         this.dateTimePickerSeriesDate.ShowCheckBox = true;
         this.dateTimePickerSeriesDate.Size = new System.Drawing.Size(299, 20);
         this.dateTimePickerSeriesDate.TabIndex = 17;
         this.dateTimePickerSeriesDate.ValueChanged += new System.EventHandler(this.dateTimePickerSeriesDate_ValueChanged);
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.ForeColor = System.Drawing.Color.Black;
         this.label12.Location = new System.Drawing.Point(8, 261);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(65, 13);
         this.label12.TabIndex = 16;
         this.label12.Text = "Series Date:";
         // 
         // textBoxDescription
         // 
         this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxDescription.Location = new System.Drawing.Point(79, 313);
         this.textBoxDescription.Name = "textBoxDescription";
         this.textBoxDescription.Size = new System.Drawing.Size(299, 20);
         this.textBoxDescription.TabIndex = 21;
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.ForeColor = System.Drawing.Color.Black;
         this.label13.Location = new System.Drawing.Point(6, 317);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(67, 13);
         this.label13.TabIndex = 20;
         this.label13.Text = "Series Desc:";
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.ForeColor = System.Drawing.Color.Black;
         this.label14.Location = new System.Drawing.Point(24, 345);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(49, 13);
         this.label14.TabIndex = 22;
         this.label14.Text = "Modality:";
         // 
         // comboBoxModality
         // 
         this.comboBoxModality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxModality.FormattingEnabled = true;
         this.comboBoxModality.Location = new System.Drawing.Point(79, 341);
         this.comboBoxModality.Name = "comboBoxModality";
         this.comboBoxModality.Size = new System.Drawing.Size(299, 21);
         this.comboBoxModality.TabIndex = 23;
         this.comboBoxModality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxModality_KeyPress);
         // 
         // CopyButton
         // 
         this.CopyButton.Enabled = false;
         this.CopyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.CopyButton.Location = new System.Drawing.Point(79, 394);
         this.CopyButton.Name = "CopyButton";
         this.CopyButton.Size = new System.Drawing.Size(144, 39);
         this.CopyButton.TabIndex = 25;
         this.CopyButton.Text = "Copy";
         this.CopyButton.UseVisualStyleBackColor = true;
         this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
         // 
         // radioButtonMoveSeriesToExistingPatient
         // 
         this.radioButtonMoveSeriesToExistingPatient.AutoSize = true;
         this.radioButtonMoveSeriesToExistingPatient.Location = new System.Drawing.Point(166, 6);
         this.radioButtonMoveSeriesToExistingPatient.Name = "radioButtonMoveSeriesToExistingPatient";
         this.radioButtonMoveSeriesToExistingPatient.Size = new System.Drawing.Size(167, 17);
         this.radioButtonMoveSeriesToExistingPatient.TabIndex = 1;
         this.radioButtonMoveSeriesToExistingPatient.Text = "Move series to existing patient";
         this.radioButtonMoveSeriesToExistingPatient.UseVisualStyleBackColor = true;
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Location = new System.Drawing.Point(247, 40);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(400, 471);
         this.tabControl1.TabIndex = 3;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.textBoxOtherPid);
         this.tabPage1.Controls.Add(this.label22);
         this.tabPage1.Controls.Add(this.dateTimePickerSeriesTime);
         this.tabPage1.Controls.Add(this.label17);
         this.tabPage1.Controls.Add(this.radioButtonMoveStudyToNewPatient);
         this.tabPage1.Controls.Add(this.radioButtonMoveStudyToExistingPatient);
         this.tabPage1.Controls.Add(this.textBoxId);
         this.tabPage1.Controls.Add(this.radioButtonMoveSeriesToExistingPatient);
         this.tabPage1.Controls.Add(this.label11);
         this.tabPage1.Controls.Add(this.CopyButton);
         this.tabPage1.Controls.Add(this.label10);
         this.tabPage1.Controls.Add(this.label9);
         this.tabPage1.Controls.Add(this.radioButtonChangeSeries);
         this.tabPage1.Controls.Add(this.comboBoxModality);
         this.tabPage1.Controls.Add(this.label8);
         this.tabPage1.Controls.Add(this.label14);
         this.tabPage1.Controls.Add(this.label7);
         this.tabPage1.Controls.Add(this.textBoxDescription);
         this.tabPage1.Controls.Add(this.textBoxLastname);
         this.tabPage1.Controls.Add(this.label13);
         this.tabPage1.Controls.Add(this.textBoxFirstname);
         this.tabPage1.Controls.Add(this.dateTimePickerSeriesDate);
         this.tabPage1.Controls.Add(this.comboBoxSex);
         this.tabPage1.Controls.Add(this.label12);
         this.tabPage1.Controls.Add(this.dateTimePickerBirth);
         this.tabPage1.Controls.Add(this.ActionButton);
         this.tabPage1.Controls.Add(this.SearchButton);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(392, 445);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Edit Series";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // dateTimePickerSeriesTime
         // 
         this.dateTimePickerSeriesTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dateTimePickerSeriesTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
         this.dateTimePickerSeriesTime.Location = new System.Drawing.Point(79, 285);
         this.dateTimePickerSeriesTime.Name = "dateTimePickerSeriesTime";
         this.dateTimePickerSeriesTime.ShowCheckBox = true;
         this.dateTimePickerSeriesTime.ShowUpDown = true;
         this.dateTimePickerSeriesTime.Size = new System.Drawing.Size(299, 20);
         this.dateTimePickerSeriesTime.TabIndex = 19;
         this.dateTimePickerSeriesTime.ValueChanged += new System.EventHandler(this.dateTimePickerSeriesTime_ValueChanged);
         // 
         // label17
         // 
         this.label17.AutoSize = true;
         this.label17.ForeColor = System.Drawing.Color.Black;
         this.label17.Location = new System.Drawing.Point(8, 289);
         this.label17.Name = "label17";
         this.label17.Size = new System.Drawing.Size(65, 13);
         this.label17.TabIndex = 18;
         this.label17.Text = "Series Time:";
         // 
         // radioButtonMoveStudyToNewPatient
         // 
         this.radioButtonMoveStudyToNewPatient.AutoSize = true;
         this.radioButtonMoveStudyToNewPatient.Location = new System.Drawing.Point(7, 26);
         this.radioButtonMoveStudyToNewPatient.Name = "radioButtonMoveStudyToNewPatient";
         this.radioButtonMoveStudyToNewPatient.Size = new System.Drawing.Size(150, 17);
         this.radioButtonMoveStudyToNewPatient.TabIndex = 2;
         this.radioButtonMoveStudyToNewPatient.Text = "Move study to new patient";
         this.radioButtonMoveStudyToNewPatient.UseVisualStyleBackColor = true;
         // 
         // radioButtonMoveStudyToExistingPatient
         // 
         this.radioButtonMoveStudyToExistingPatient.AutoSize = true;
         this.radioButtonMoveStudyToExistingPatient.Location = new System.Drawing.Point(166, 26);
         this.radioButtonMoveStudyToExistingPatient.Name = "radioButtonMoveStudyToExistingPatient";
         this.radioButtonMoveStudyToExistingPatient.Size = new System.Drawing.Size(165, 17);
         this.radioButtonMoveStudyToExistingPatient.TabIndex = 3;
         this.radioButtonMoveStudyToExistingPatient.Text = "Move study to existing patient";
         this.radioButtonMoveStudyToExistingPatient.UseVisualStyleBackColor = true;
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.txtUID);
         this.tabPage2.Controls.Add(this.label15);
         this.tabPage2.Controls.Add(this.dateTimePickerStudyDate);
         this.tabPage2.Controls.Add(this.btnStudy);
         this.tabPage2.Controls.Add(this.txtID);
         this.tabPage2.Controls.Add(this.label28);
         this.tabPage2.Controls.Add(this.txtDescription);
         this.tabPage2.Controls.Add(this.label27);
         this.tabPage2.Controls.Add(this.label26);
         this.tabPage2.Controls.Add(this.label23);
         this.tabPage2.Controls.Add(this.txtAccession);
         this.tabPage2.Location = new System.Drawing.Point(4, 22);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage2.Size = new System.Drawing.Size(392, 445);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Edit Study";
         this.tabPage2.UseVisualStyleBackColor = true;
         // 
         // txtUID
         // 
         this.txtUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtUID.Location = new System.Drawing.Point(113, 28);
         this.txtUID.Name = "txtUID";
         this.txtUID.Size = new System.Drawing.Size(263, 20);
         this.txtUID.TabIndex = 1;
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(6, 32);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(103, 13);
         this.label15.TabIndex = 0;
         this.label15.Text = "Study Instance UID:";
         // 
         // dateTimePickerStudyDate
         // 
         this.dateTimePickerStudyDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dateTimePickerStudyDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerStudyDate.Location = new System.Drawing.Point(113, 96);
         this.dateTimePickerStudyDate.Name = "dateTimePickerStudyDate";
         this.dateTimePickerStudyDate.ShowCheckBox = true;
         this.dateTimePickerStudyDate.Size = new System.Drawing.Size(263, 20);
         this.dateTimePickerStudyDate.TabIndex = 5;
         // 
         // btnStudy
         // 
         this.btnStudy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.btnStudy.Location = new System.Drawing.Point(113, 198);
         this.btnStudy.Name = "btnStudy";
         this.btnStudy.Size = new System.Drawing.Size(144, 39);
         this.btnStudy.TabIndex = 10;
         this.btnStudy.Text = "Change Study";
         this.btnStudy.UseVisualStyleBackColor = true;
         this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
         // 
         // txtID
         // 
         this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtID.Location = new System.Drawing.Point(113, 164);
         this.txtID.Name = "txtID";
         this.txtID.Size = new System.Drawing.Size(263, 20);
         this.txtID.TabIndex = 9;
         // 
         // label28
         // 
         this.label28.AutoSize = true;
         this.label28.ForeColor = System.Drawing.Color.Black;
         this.label28.Location = new System.Drawing.Point(58, 168);
         this.label28.Name = "label28";
         this.label28.Size = new System.Drawing.Size(51, 13);
         this.label28.TabIndex = 8;
         this.label28.Text = "Study ID:";
         // 
         // txtDescription
         // 
         this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtDescription.Location = new System.Drawing.Point(113, 130);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(263, 20);
         this.txtDescription.TabIndex = 7;
         // 
         // label27
         // 
         this.label27.AutoSize = true;
         this.label27.ForeColor = System.Drawing.Color.Black;
         this.label27.Location = new System.Drawing.Point(16, 133);
         this.label27.Name = "label27";
         this.label27.Size = new System.Drawing.Size(93, 13);
         this.label27.TabIndex = 6;
         this.label27.Text = "Study Description:";
         // 
         // label26
         // 
         this.label26.AutoSize = true;
         this.label26.ForeColor = System.Drawing.Color.Black;
         this.label26.Location = new System.Drawing.Point(46, 100);
         this.label26.Name = "label26";
         this.label26.Size = new System.Drawing.Size(63, 13);
         this.label26.TabIndex = 4;
         this.label26.Text = "Study Date:";
         // 
         // label23
         // 
         this.label23.AutoSize = true;
         this.label23.ForeColor = System.Drawing.Color.Black;
         this.label23.Location = new System.Drawing.Point(13, 66);
         this.label23.Name = "label23";
         this.label23.Size = new System.Drawing.Size(96, 13);
         this.label23.TabIndex = 2;
         this.label23.Text = "AccessionNumber:";
         // 
         // txtAccession
         // 
         this.txtAccession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtAccession.Location = new System.Drawing.Point(113, 62);
         this.txtAccession.Name = "txtAccession";
         this.txtAccession.Size = new System.Drawing.Size(263, 20);
         this.txtAccession.TabIndex = 3;
         // 
         // OtherPatientIds
         // 
         this.OtherPatientIds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.OtherPatientIds.ForeColor = System.Drawing.Color.Black;
         this.OtherPatientIds.Location = new System.Drawing.Point(80, 78);
         this.OtherPatientIds.Name = "OtherPatientIds";
         this.OtherPatientIds.Size = new System.Drawing.Size(136, 13);
         this.OtherPatientIds.TabIndex = 3;
         this.OtherPatientIds.Text = "label7";
         // 
         // label18
         // 
         this.label18.AutoSize = true;
         this.label18.ForeColor = System.Drawing.Color.Black;
         this.label18.Location = new System.Drawing.Point(6, 78);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(68, 13);
         this.label18.TabIndex = 2;
         this.label18.Text = "Other PID(s):";
         // 
         // textBoxOtherPid
         // 
         this.textBoxOtherPid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxOtherPid.Location = new System.Drawing.Point(79, 74);
         this.textBoxOtherPid.Name = "textBoxOtherPid";
         this.textBoxOtherPid.Size = new System.Drawing.Size(299, 20);
         this.textBoxOtherPid.TabIndex = 7;
         // 
         // label22
         // 
         this.label22.AutoSize = true;
         this.label22.ForeColor = System.Drawing.Color.Black;
         this.label22.Location = new System.Drawing.Point(5, 78);
         this.label22.Name = "label22";
         this.label22.Size = new System.Drawing.Size(68, 13);
         this.label22.TabIndex = 6;
         this.label22.Text = "Other PID(s):";
         // 
         // EditSeriesDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(665, 513);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EditSeriesDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Edit Record";
         this.Load += new System.EventHandler(this.EditSeriesDialog_Load);
         this.Shown += new System.EventHandler(this.EditSeriesDialog_Shown);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         this.tabPage2.ResumeLayout(false);
         this.tabPage2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ActionButton;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.TextBox textBoxFirstname;
        private System.Windows.Forms.TextBox textBoxLastname;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radioButtonChangeSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label DateOfBirth;
        private System.Windows.Forms.Label Sex;
        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label PatientId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label SeriesModality;
        private System.Windows.Forms.Label SeriesDescription;
        private System.Windows.Forms.Label SeriesDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeriesDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxModality;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Label SeriesTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton radioButtonMoveSeriesToExistingPatient;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton radioButtonMoveStudyToNewPatient;
        private System.Windows.Forms.RadioButton radioButtonMoveStudyToExistingPatient;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtAccession;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnStudy;
        private System.Windows.Forms.DateTimePicker dateTimePickerStudyDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeriesTime;
        private System.Windows.Forms.Label label17;
      private System.Windows.Forms.Label OtherPatientIds;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.TextBox textBoxOtherPid;
      private System.Windows.Forms.Label label22;
   }
}