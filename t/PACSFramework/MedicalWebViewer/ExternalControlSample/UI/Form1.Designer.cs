namespace ExternalControlSample
{
   partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageViewInstances = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonShowStudy = new System.Windows.Forms.Button();
            this.linkLabelImage = new System.Windows.Forms.LinkLabel();
            this.comboBoxSopInstanceUid = new System.Windows.Forms.ComboBox();
            this.buttonGetImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSeriesInstanceUid = new System.Windows.Forms.ComboBox();
            this.comboBoxStudyInstanceUid = new System.Windows.Forms.ComboBox();
            this.buttonShowSeries = new System.Windows.Forms.Button();
            this.labelStudyInstanceUid = new System.Windows.Forms.Label();
            this.labelSeriesInstanceUid = new System.Windows.Forms.Label();
            this.comboBoxPatientIdViewInstances = new System.Windows.Forms.ComboBox();
            this.labelPatient = new System.Windows.Forms.Label();
            this.buttonShowPatient = new System.Windows.Forms.Button();
            this.tabPagePatientInformation = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonGetCurrentPatient = new System.Windows.Forms.Button();
            this.radioButtonFindPatientWithInstances = new System.Windows.Forms.RadioButton();
            this.radioButtonFindPatientAll = new System.Windows.Forms.RadioButton();
            this.comboBoxPatientIdPatientInformation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFindPatient = new System.Windows.Forms.Button();
            this.tabPageUpdatePatient = new System.Windows.Forms.TabPage();
            this.patientControlUpdatePatient = new ExternalControlSample.PatientControl();
            this.buttonDeletePatient = new System.Windows.Forms.Button();
            this.buttonUpdatePatient = new System.Windows.Forms.Button();
            this.tabPageAddPatient = new System.Windows.Forms.TabPage();
            this.patientListControlSample = new ExternalControlSample.PatientListControl();
            this.patientControlAddPatient = new ExternalControlSample.PatientControl();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabPageUpdateUser = new System.Windows.Forms.TabPage();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonUpdateUser = new System.Windows.Forms.Button();
            this.usersControlUpdateUser = new ExternalControlSample.UI.UsersControl();
            this.tabPageAddUser = new System.Windows.Forms.TabPage();
            this.usersControlAddUser = new ExternalControlSample.UI.UsersControl();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemLogin = new System.Windows.Forms.MenuItem();
            this.menuItemLogout = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageViewInstances.SuspendLayout();
            this.tabPagePatientInformation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageUpdatePatient.SuspendLayout();
            this.tabPageAddPatient.SuspendLayout();
            this.tabPageUpdateUser.SuspendLayout();
            this.tabPageAddUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewLog
            // 
            this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader5});
            this.listViewLog.LabelWrap = false;
            this.listViewLog.Location = new System.Drawing.Point(3, 555);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(776, 98);
            this.listViewLog.TabIndex = 1;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Command";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Message";
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearLog.Location = new System.Drawing.Point(3, 659);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 2;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageViewInstances);
            this.tabControl1.Controls.Add(this.tabPagePatientInformation);
            this.tabControl1.Controls.Add(this.tabPageUpdatePatient);
            this.tabControl1.Controls.Add(this.tabPageAddPatient);
            this.tabControl1.Controls.Add(this.tabPageUpdateUser);
            this.tabControl1.Controls.Add(this.tabPageAddUser);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 548);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPageViewInstances
            // 
            this.tabPageViewInstances.Controls.Add(this.button1);
            this.tabPageViewInstances.Controls.Add(this.buttonShowStudy);
            this.tabPageViewInstances.Controls.Add(this.linkLabelImage);
            this.tabPageViewInstances.Controls.Add(this.comboBoxSopInstanceUid);
            this.tabPageViewInstances.Controls.Add(this.buttonGetImage);
            this.tabPageViewInstances.Controls.Add(this.label3);
            this.tabPageViewInstances.Controls.Add(this.comboBoxSeriesInstanceUid);
            this.tabPageViewInstances.Controls.Add(this.comboBoxStudyInstanceUid);
            this.tabPageViewInstances.Controls.Add(this.buttonShowSeries);
            this.tabPageViewInstances.Controls.Add(this.labelStudyInstanceUid);
            this.tabPageViewInstances.Controls.Add(this.labelSeriesInstanceUid);
            this.tabPageViewInstances.Controls.Add(this.comboBoxPatientIdViewInstances);
            this.tabPageViewInstances.Controls.Add(this.labelPatient);
            this.tabPageViewInstances.Controls.Add(this.buttonShowPatient);
            this.tabPageViewInstances.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewInstances.Name = "tabPageViewInstances";
            this.tabPageViewInstances.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViewInstances.Size = new System.Drawing.Size(768, 522);
            this.tabPageViewInstances.TabIndex = 1;
            this.tabPageViewInstances.Text = "View Instances";
            this.tabPageViewInstances.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Get Current Patient";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonGetCurrentPatient_Click);
            // 
            // buttonShowStudy
            // 
            this.buttonShowStudy.Location = new System.Drawing.Point(19, 83);
            this.buttonShowStudy.Name = "buttonShowStudy";
            this.buttonShowStudy.Size = new System.Drawing.Size(106, 23);
            this.buttonShowStudy.TabIndex = 16;
            this.buttonShowStudy.Text = "Show Study";
            this.buttonShowStudy.UseVisualStyleBackColor = true;
            this.buttonShowStudy.Click += new System.EventHandler(this.buttonShowStudy_Click);
            // 
            // linkLabelImage
            // 
            this.linkLabelImage.AutoSize = true;
            this.linkLabelImage.Location = new System.Drawing.Point(153, 250);
            this.linkLabelImage.Name = "linkLabelImage";
            this.linkLabelImage.Size = new System.Drawing.Size(130, 13);
            this.linkLabelImage.TabIndex = 15;
            this.linkLabelImage.TabStop = true;
            this.linkLabelImage.Text = "https://www.leadtools.com";
            this.linkLabelImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelImage_LinkClicked);
            // 
            // comboBoxSopInstanceUid
            // 
            this.comboBoxSopInstanceUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSopInstanceUid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSopInstanceUid.FormattingEnabled = true;
            this.comboBoxSopInstanceUid.Location = new System.Drawing.Point(153, 192);
            this.comboBoxSopInstanceUid.Name = "comboBoxSopInstanceUid";
            this.comboBoxSopInstanceUid.Size = new System.Drawing.Size(383, 21);
            this.comboBoxSopInstanceUid.TabIndex = 13;
            // 
            // buttonGetImage
            // 
            this.buttonGetImage.Location = new System.Drawing.Point(19, 192);
            this.buttonGetImage.Name = "buttonGetImage";
            this.buttonGetImage.Size = new System.Drawing.Size(106, 23);
            this.buttonGetImage.TabIndex = 14;
            this.buttonGetImage.Text = "Get Image";
            this.buttonGetImage.UseVisualStyleBackColor = true;
            this.buttonGetImage.Click += new System.EventHandler(this.buttonGetImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "SOP Instance UID";
            // 
            // comboBoxSeriesInstanceUid
            // 
            this.comboBoxSeriesInstanceUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSeriesInstanceUid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeriesInstanceUid.FormattingEnabled = true;
            this.comboBoxSeriesInstanceUid.Location = new System.Drawing.Point(153, 138);
            this.comboBoxSeriesInstanceUid.Name = "comboBoxSeriesInstanceUid";
            this.comboBoxSeriesInstanceUid.Size = new System.Drawing.Size(383, 21);
            this.comboBoxSeriesInstanceUid.TabIndex = 10;
            this.comboBoxSeriesInstanceUid.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeriesInstanceUid_SelectedIndexChanged);
            // 
            // comboBoxStudyInstanceUid
            // 
            this.comboBoxStudyInstanceUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStudyInstanceUid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudyInstanceUid.FormattingEnabled = true;
            this.comboBoxStudyInstanceUid.Location = new System.Drawing.Point(153, 84);
            this.comboBoxStudyInstanceUid.Name = "comboBoxStudyInstanceUid";
            this.comboBoxStudyInstanceUid.Size = new System.Drawing.Size(383, 21);
            this.comboBoxStudyInstanceUid.TabIndex = 8;
            this.comboBoxStudyInstanceUid.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudyInstanceUid_SelectedIndexChanged);
            // 
            // buttonShowSeries
            // 
            this.buttonShowSeries.Location = new System.Drawing.Point(19, 137);
            this.buttonShowSeries.Name = "buttonShowSeries";
            this.buttonShowSeries.Size = new System.Drawing.Size(106, 23);
            this.buttonShowSeries.TabIndex = 11;
            this.buttonShowSeries.Text = "Show Series";
            this.buttonShowSeries.UseVisualStyleBackColor = true;
            this.buttonShowSeries.Click += new System.EventHandler(this.buttonShowSeries_Click);
            // 
            // labelStudyInstanceUid
            // 
            this.labelStudyInstanceUid.AutoSize = true;
            this.labelStudyInstanceUid.Location = new System.Drawing.Point(153, 68);
            this.labelStudyInstanceUid.Name = "labelStudyInstanceUid";
            this.labelStudyInstanceUid.Size = new System.Drawing.Size(100, 13);
            this.labelStudyInstanceUid.TabIndex = 7;
            this.labelStudyInstanceUid.Text = "Study Instance UID";
            // 
            // labelSeriesInstanceUid
            // 
            this.labelSeriesInstanceUid.AutoSize = true;
            this.labelSeriesInstanceUid.Location = new System.Drawing.Point(153, 123);
            this.labelSeriesInstanceUid.Name = "labelSeriesInstanceUid";
            this.labelSeriesInstanceUid.Size = new System.Drawing.Size(102, 13);
            this.labelSeriesInstanceUid.TabIndex = 9;
            this.labelSeriesInstanceUid.Text = "Series Instance UID";
            // 
            // comboBoxPatientIdViewInstances
            // 
            this.comboBoxPatientIdViewInstances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPatientIdViewInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPatientIdViewInstances.FormattingEnabled = true;
            this.comboBoxPatientIdViewInstances.Location = new System.Drawing.Point(153, 30);
            this.comboBoxPatientIdViewInstances.Name = "comboBoxPatientIdViewInstances";
            this.comboBoxPatientIdViewInstances.Size = new System.Drawing.Size(383, 21);
            this.comboBoxPatientIdViewInstances.TabIndex = 5;
            this.comboBoxPatientIdViewInstances.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatientIdViewInstances_SelectedIndexChanged);
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Location = new System.Drawing.Point(153, 14);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(54, 13);
            this.labelPatient.TabIndex = 4;
            this.labelPatient.Text = "Patient ID";
            // 
            // buttonShowPatient
            // 
            this.buttonShowPatient.Location = new System.Drawing.Point(19, 29);
            this.buttonShowPatient.Name = "buttonShowPatient";
            this.buttonShowPatient.Size = new System.Drawing.Size(106, 23);
            this.buttonShowPatient.TabIndex = 6;
            this.buttonShowPatient.Text = "Show Patient";
            this.buttonShowPatient.UseVisualStyleBackColor = true;
            this.buttonShowPatient.Click += new System.EventHandler(this.buttonShowPatient_Click);
            // 
            // tabPagePatientInformation
            // 
            this.tabPagePatientInformation.Controls.Add(this.groupBox2);
            this.tabPagePatientInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPagePatientInformation.Name = "tabPagePatientInformation";
            this.tabPagePatientInformation.Size = new System.Drawing.Size(768, 522);
            this.tabPagePatientInformation.TabIndex = 2;
            this.tabPagePatientInformation.Text = "Patient Information";
            this.tabPagePatientInformation.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonGetCurrentPatient);
            this.groupBox2.Controls.Add(this.radioButtonFindPatientWithInstances);
            this.groupBox2.Controls.Add(this.radioButtonFindPatientAll);
            this.groupBox2.Controls.Add(this.comboBoxPatientIdPatientInformation);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonFindPatient);
            this.groupBox2.Location = new System.Drawing.Point(17, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 124);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patient";
            // 
            // buttonGetCurrentPatient
            // 
            this.buttonGetCurrentPatient.Location = new System.Drawing.Point(125, 60);
            this.buttonGetCurrentPatient.Name = "buttonGetCurrentPatient";
            this.buttonGetCurrentPatient.Size = new System.Drawing.Size(110, 23);
            this.buttonGetCurrentPatient.TabIndex = 3;
            this.buttonGetCurrentPatient.Text = "Get Current Patient";
            this.buttonGetCurrentPatient.UseVisualStyleBackColor = true;
            this.buttonGetCurrentPatient.Click += new System.EventHandler(this.buttonGetCurrentPatient_Click);
            // 
            // radioButtonFindPatientWithInstances
            // 
            this.radioButtonFindPatientWithInstances.AutoSize = true;
            this.radioButtonFindPatientWithInstances.Location = new System.Drawing.Point(11, 101);
            this.radioButtonFindPatientWithInstances.Name = "radioButtonFindPatientWithInstances";
            this.radioButtonFindPatientWithInstances.Size = new System.Drawing.Size(96, 17);
            this.radioButtonFindPatientWithInstances.TabIndex = 5;
            this.radioButtonFindPatientWithInstances.TabStop = true;
            this.radioButtonFindPatientWithInstances.Text = "With Instances";
            this.radioButtonFindPatientWithInstances.UseVisualStyleBackColor = true;
            // 
            // radioButtonFindPatientAll
            // 
            this.radioButtonFindPatientAll.AutoSize = true;
            this.radioButtonFindPatientAll.Location = new System.Drawing.Point(11, 83);
            this.radioButtonFindPatientAll.Name = "radioButtonFindPatientAll";
            this.radioButtonFindPatientAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonFindPatientAll.TabIndex = 4;
            this.radioButtonFindPatientAll.TabStop = true;
            this.radioButtonFindPatientAll.Text = "All";
            this.radioButtonFindPatientAll.UseVisualStyleBackColor = true;
            // 
            // comboBoxPatientIdPatientInformation
            // 
            this.comboBoxPatientIdPatientInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPatientIdPatientInformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPatientIdPatientInformation.FormattingEnabled = true;
            this.comboBoxPatientIdPatientInformation.Location = new System.Drawing.Point(10, 33);
            this.comboBoxPatientIdPatientInformation.Name = "comboBoxPatientIdPatientInformation";
            this.comboBoxPatientIdPatientInformation.Size = new System.Drawing.Size(714, 21);
            this.comboBoxPatientIdPatientInformation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient ID";
            // 
            // buttonFindPatient
            // 
            this.buttonFindPatient.Location = new System.Drawing.Point(10, 60);
            this.buttonFindPatient.Name = "buttonFindPatient";
            this.buttonFindPatient.Size = new System.Drawing.Size(110, 23);
            this.buttonFindPatient.TabIndex = 2;
            this.buttonFindPatient.Text = "Find Patient";
            this.buttonFindPatient.UseVisualStyleBackColor = true;
            this.buttonFindPatient.Click += new System.EventHandler(this.buttonFindPatient_Click);
            // 
            // tabPageUpdatePatient
            // 
            this.tabPageUpdatePatient.Controls.Add(this.patientControlUpdatePatient);
            this.tabPageUpdatePatient.Controls.Add(this.buttonDeletePatient);
            this.tabPageUpdatePatient.Controls.Add(this.buttonUpdatePatient);
            this.tabPageUpdatePatient.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdatePatient.Name = "tabPageUpdatePatient";
            this.tabPageUpdatePatient.Size = new System.Drawing.Size(768, 522);
            this.tabPageUpdatePatient.TabIndex = 3;
            this.tabPageUpdatePatient.Text = "Update Patient";
            this.tabPageUpdatePatient.UseVisualStyleBackColor = true;
            // 
            // patientControlUpdatePatient
            // 
            this.patientControlUpdatePatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientControlUpdatePatient.ControlType = ExternalControlSample.PatientControlType.Update;
            this.patientControlUpdatePatient.Location = new System.Drawing.Point(0, 0);
            this.patientControlUpdatePatient.Name = "patientControlUpdatePatient";
            this.patientControlUpdatePatient.Size = new System.Drawing.Size(765, 291);
            this.patientControlUpdatePatient.TabIndex = 1;
            // 
            // buttonDeletePatient
            // 
            this.buttonDeletePatient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeletePatient.Location = new System.Drawing.Point(139, 328);
            this.buttonDeletePatient.Name = "buttonDeletePatient";
            this.buttonDeletePatient.Size = new System.Drawing.Size(110, 23);
            this.buttonDeletePatient.TabIndex = 0;
            this.buttonDeletePatient.Text = "Delete Patient";
            this.buttonDeletePatient.UseVisualStyleBackColor = true;
            this.buttonDeletePatient.Click += new System.EventHandler(this.buttonDeletePatient_Click);
            // 
            // buttonUpdatePatient
            // 
            this.buttonUpdatePatient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonUpdatePatient.Location = new System.Drawing.Point(5, 328);
            this.buttonUpdatePatient.Name = "buttonUpdatePatient";
            this.buttonUpdatePatient.Size = new System.Drawing.Size(110, 23);
            this.buttonUpdatePatient.TabIndex = 2;
            this.buttonUpdatePatient.Text = "Update Patient";
            this.buttonUpdatePatient.UseVisualStyleBackColor = true;
            this.buttonUpdatePatient.Click += new System.EventHandler(this.buttonUpdatePatient_Click);
            // 
            // tabPageAddPatient
            // 
            this.tabPageAddPatient.Controls.Add(this.patientListControlSample);
            this.tabPageAddPatient.Controls.Add(this.patientControlAddPatient);
            this.tabPageAddPatient.Controls.Add(this.buttonAdd);
            this.tabPageAddPatient.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddPatient.Name = "tabPageAddPatient";
            this.tabPageAddPatient.Size = new System.Drawing.Size(768, 522);
            this.tabPageAddPatient.TabIndex = 4;
            this.tabPageAddPatient.Text = "Add Patient";
            this.tabPageAddPatient.UseVisualStyleBackColor = true;
            // 
            // patientListControlSample
            // 
            this.patientListControlSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientListControlSample.Location = new System.Drawing.Point(0, 0);
            this.patientListControlSample.Name = "patientListControlSample";
            this.patientListControlSample.Size = new System.Drawing.Size(765, 195);
            this.patientListControlSample.TabIndex = 0;
            // 
            // patientControlAddPatient
            // 
            this.patientControlAddPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientControlAddPatient.ControlType = ExternalControlSample.PatientControlType.Add;
            this.patientControlAddPatient.Location = new System.Drawing.Point(3, 201);
            this.patientControlAddPatient.Name = "patientControlAddPatient";
            this.patientControlAddPatient.Size = new System.Drawing.Size(762, 296);
            this.patientControlAddPatient.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(5, 496);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(80, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add Patient";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddPatient_Click);
            // 
            // tabPageUpdateUser
            // 
            this.tabPageUpdateUser.Controls.Add(this.buttonDeleteUser);
            this.tabPageUpdateUser.Controls.Add(this.buttonUpdateUser);
            this.tabPageUpdateUser.Controls.Add(this.usersControlUpdateUser);
            this.tabPageUpdateUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateUser.Name = "tabPageUpdateUser";
            this.tabPageUpdateUser.Size = new System.Drawing.Size(768, 522);
            this.tabPageUpdateUser.TabIndex = 6;
            this.tabPageUpdateUser.Text = "Update User";
            this.tabPageUpdateUser.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Location = new System.Drawing.Point(5, 360);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteUser.TabIndex = 8;
            this.buttonDeleteUser.Text = "Delete User";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // buttonUpdateUser
            // 
            this.buttonUpdateUser.Location = new System.Drawing.Point(5, 331);
            this.buttonUpdateUser.Name = "buttonUpdateUser";
            this.buttonUpdateUser.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateUser.TabIndex = 6;
            this.buttonUpdateUser.Text = "Update User";
            this.buttonUpdateUser.UseVisualStyleBackColor = true;
            this.buttonUpdateUser.Click += new System.EventHandler(this.buttonUpdateUser_Click);
            // 
            // usersControlUpdateUser
            // 
            this.usersControlUpdateUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersControlUpdateUser.ControlType = ExternalControlSample.UI.UsersControlType.Update;
            this.usersControlUpdateUser.Location = new System.Drawing.Point(5, 12);
            this.usersControlUpdateUser.Name = "usersControlUpdateUser";
            this.usersControlUpdateUser.Permissions = ((System.Collections.Generic.List<string>)(resources.GetObject("usersControlUpdateUser.Permissions")));
            this.usersControlUpdateUser.Roles = ((System.Collections.Generic.List<string>)(resources.GetObject("usersControlUpdateUser.Roles")));
            this.usersControlUpdateUser.Size = new System.Drawing.Size(760, 313);
            this.usersControlUpdateUser.TabIndex = 7;
            // 
            // tabPageAddUser
            // 
            this.tabPageAddUser.Controls.Add(this.usersControlAddUser);
            this.tabPageAddUser.Controls.Add(this.buttonAddUser);
            this.tabPageAddUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddUser.Name = "tabPageAddUser";
            this.tabPageAddUser.Size = new System.Drawing.Size(768, 522);
            this.tabPageAddUser.TabIndex = 7;
            this.tabPageAddUser.Text = "Add User";
            this.tabPageAddUser.UseVisualStyleBackColor = true;
            // 
            // usersControlAddUser
            // 
            this.usersControlAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersControlAddUser.ControlType = ExternalControlSample.UI.UsersControlType.Add;
            this.usersControlAddUser.Location = new System.Drawing.Point(5, 12);
            this.usersControlAddUser.Name = "usersControlAddUser";
            this.usersControlAddUser.Permissions = ((System.Collections.Generic.List<string>)(resources.GetObject("usersControlAddUser.Permissions")));
            this.usersControlAddUser.Roles = ((System.Collections.Generic.List<string>)(resources.GetObject("usersControlAddUser.Roles")));
            this.usersControlAddUser.Size = new System.Drawing.Size(760, 313);
            this.usersControlAddUser.TabIndex = 6;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(5, 331);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 5;
            this.buttonAddUser.Text = "Add User";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItemHelp});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemLogin,
            this.menuItemLogout,
            this.menuItem2,
            this.menuItemExit});
            this.menuItem1.Text = "File";
            // 
            // menuItemLogin
            // 
            this.menuItemLogin.Index = 0;
            this.menuItemLogin.Text = "Login";
            this.menuItemLogin.Click += new System.EventHandler(this.menuItemLogin_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Index = 1;
            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 1;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Text = "Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "About...";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 690);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.listViewLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExternalWebViewer Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPageViewInstances.ResumeLayout(false);
            this.tabPageViewInstances.PerformLayout();
            this.tabPagePatientInformation.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageUpdatePatient.ResumeLayout(false);
            this.tabPageAddPatient.ResumeLayout(false);
            this.tabPageUpdateUser.ResumeLayout(false);
            this.tabPageAddUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListView listViewLog;
      private System.Windows.Forms.Button buttonClearLog;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPageViewInstances;
      private System.Windows.Forms.TabPage tabPagePatientInformation;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Button buttonGetCurrentPatient;
      private System.Windows.Forms.RadioButton radioButtonFindPatientWithInstances;
      private System.Windows.Forms.RadioButton radioButtonFindPatientAll;
      private System.Windows.Forms.ComboBox comboBoxPatientIdPatientInformation;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button buttonFindPatient;
      private System.Windows.Forms.TabPage tabPageUpdatePatient;
      private System.Windows.Forms.Button buttonUpdatePatient;
      private System.Windows.Forms.TabPage tabPageAddPatient;
      private System.Windows.Forms.Button buttonDeletePatient;
      private System.Windows.Forms.Button buttonAdd;
      private ExternalControlSample.PatientControl patientControlAddPatient;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private ExternalControlSample.PatientListControl patientListControlSample;
      private ExternalControlSample.PatientControl patientControlUpdatePatient;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItemLogin;
      private System.Windows.Forms.MenuItem menuItemLogout;
      private System.Windows.Forms.TabPage tabPageUpdateUser;
      private System.Windows.Forms.Button buttonUpdateUser;
      private System.Windows.Forms.TabPage tabPageAddUser;
      private System.Windows.Forms.Button buttonAddUser;
      private ExternalControlSample.UI.UsersControl usersControlUpdateUser;
      private ExternalControlSample.UI.UsersControl usersControlAddUser;
      private System.Windows.Forms.ComboBox comboBoxSeriesInstanceUid;
      private System.Windows.Forms.ComboBox comboBoxStudyInstanceUid;
      private System.Windows.Forms.Button buttonShowSeries;
      private System.Windows.Forms.Label labelStudyInstanceUid;
      private System.Windows.Forms.Label labelSeriesInstanceUid;
      private System.Windows.Forms.ComboBox comboBoxPatientIdViewInstances;
      private System.Windows.Forms.Label labelPatient;
      private System.Windows.Forms.Button buttonShowPatient;
      private System.Windows.Forms.LinkLabel linkLabelImage;
      private System.Windows.Forms.ComboBox comboBoxSopInstanceUid;
      private System.Windows.Forms.Button buttonGetImage;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button buttonShowStudy;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button buttonDeleteUser;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.MenuItem menuItemExit;
      private System.Windows.Forms.MenuItem menuItemHelp;
      private System.Windows.Forms.MenuItem menuItemAbout;
   }
}

