using System.Windows.Forms;
using System;
namespace JobProcessorServerConfigDemo
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
         if(disposing && (components != null))
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mainTabControl = new System.Windows.Forms.TabControl();
         this._mainTabPage = new System.Windows.Forms.TabPage();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._lstvwDatabases = new System.Windows.Forms.ListView();
         this.clmhdrKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.clmhdrValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.buttonDatabaseConfigure = new System.Windows.Forms.Button();
         this._deleteGroupBox = new System.Windows.Forms.GroupBox();
         this._deleteNoteLabel = new System.Windows.Forms.Label();
         this._deleteButton = new System.Windows.Forms.Button();
         this._deleteLabel = new System.Windows.Forms.Label();
         this._createGroupBox = new System.Windows.Forms.GroupBox();
         this._useDotNet4AssembliesCheckBox = new System.Windows.Forms.CheckBox();
         this._createNoteLabel = new System.Windows.Forms.Label();
         this._createButton = new System.Windows.Forms.Button();
         this._x64RadioButton = new System.Windows.Forms.RadioButton();
         this._x86RadioButton = new System.Windows.Forms.RadioButton();
         this._createLabel = new System.Windows.Forms.Label();
         this._propertiesGroupBox = new System.Windows.Forms.GroupBox();
         this._testInfoLabel = new System.Windows.Forms.Label();
         this._virtualDirPathLabel = new System.Windows.Forms.Label();
         this._virtualDirNameLabel = new System.Windows.Forms.Label();
         this._appPoolNameLabel = new System.Windows.Forms.Label();
         this._iisVersionLabel = new System.Windows.Forms.Label();
         this._virtualDirPathTextBox = new System.Windows.Forms.TextBox();
         this._virtualDirNameTextBox = new System.Windows.Forms.TextBox();
         this._appPoolNameTextBox = new System.Windows.Forms.TextBox();
         this._iisVersionTextBox = new System.Windows.Forms.TextBox();
         this._machineTextBox = new System.Windows.Forms.TextBox();
         this._machineLabel = new System.Windows.Forms.Label();
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._testTabPage = new System.Windows.Forms.TabPage();
         this._JobProcessorComponentsHelpLabel = new System.Windows.Forms.Label();
         this._JobProcessorComponentsGroupBox = new System.Windows.Forms.GroupBox();
         this._JobProcessorComponentsRichTextBox = new System.Windows.Forms.RichTextBox();
         this._troubleShootButton = new System.Windows.Forms.Button();
         this._testButton = new System.Windows.Forms.Button();
         this._JobProcessorComponentsGroupBoxLabel = new System.Windows.Forms.Label();
         this._workersTabPage = new System.Windows.Forms.TabPage();
         this._lblComments = new System.Windows.Forms.Label();
         this._btnApply = new System.Windows.Forms.Button();
         this._btnAddJobType = new System.Windows.Forms.Button();
         this._btnAddWorker = new System.Windows.Forms.Button();
         this._gbJobType = new System.Windows.Forms.GroupBox();
         this._btnRemoveJobType = new System.Windows.Forms.Button();
         this._lblAttempts = new System.Windows.Forms.Label();
         this._numJobTypeAttempts = new System.Windows.Forms.NumericUpDown();
         this._lblAssumeHangAfter = new System.Windows.Forms.Label();
         this._numJobTypeAssumeHangAfter = new System.Windows.Forms.NumericUpDown();
         this._chkJobTypeUseCpuThreshold = new System.Windows.Forms.CheckBox();
         this._lblProgressRate = new System.Windows.Forms.Label();
         this._numJobTypeProgressRate = new System.Windows.Forms.NumericUpDown();
         this._lblCPUThreshold = new System.Windows.Forms.Label();
         this._numJobTypeCPUThreshold = new System.Windows.Forms.NumericUpDown();
         this._lblJobTypeMaxNumberOfJobs = new System.Windows.Forms.Label();
         this._txtJobTypeName = new System.Windows.Forms.TextBox();
         this._numJobTypeMaxNumberOfJobs = new System.Windows.Forms.NumericUpDown();
         this._lblJobTypeName = new System.Windows.Forms.Label();
         this._gbWorker = new System.Windows.Forms.GroupBox();
         this._btnRemoveWorker = new System.Windows.Forms.Button();
         this._lblWorkerNewJobCheckPeriod = new System.Windows.Forms.Label();
         this._txtWorkerName = new System.Windows.Forms.TextBox();
         this._lblWorkerName = new System.Windows.Forms.Label();
         this._numWorkerNewJobCheckPeriod = new System.Windows.Forms.NumericUpDown();
         this._tvWorkers = new System.Windows.Forms.TreeView();
         this._helpTabPage = new System.Windows.Forms.TabPage();
         this._troubleShootHelpButton = new System.Windows.Forms.Button();
         this._help3Label = new System.Windows.Forms.Label();
         this._sourceCodeTextBox = new System.Windows.Forms.TextBox();
         this._help2Label = new System.Windows.Forms.Label();
         this._help1Label = new System.Windows.Forms.Label();
         this._mainTabControl.SuspendLayout();
         this._mainTabPage.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this._deleteGroupBox.SuspendLayout();
         this._createGroupBox.SuspendLayout();
         this._propertiesGroupBox.SuspendLayout();
         this._testTabPage.SuspendLayout();
         this._JobProcessorComponentsGroupBox.SuspendLayout();
         this._workersTabPage.SuspendLayout();
         this._gbJobType.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeAttempts)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeAssumeHangAfter)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeProgressRate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeCPUThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeMaxNumberOfJobs)).BeginInit();
         this._gbWorker.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWorkerNewJobCheckPeriod)).BeginInit();
         this._helpTabPage.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainTabControl
         // 
         this._mainTabControl.Controls.Add(this._mainTabPage);
         this._mainTabControl.Controls.Add(this._testTabPage);
         this._mainTabControl.Controls.Add(this._workersTabPage);
         this._mainTabControl.Controls.Add(this._helpTabPage);
         this._mainTabControl.Location = new System.Drawing.Point(12, 12);
         this._mainTabControl.Name = "_mainTabControl";
         this._mainTabControl.SelectedIndex = 0;
         this._mainTabControl.Size = new System.Drawing.Size(660, 668);
         this._mainTabControl.TabIndex = 0;
         // 
         // _mainTabPage
         // 
         this._mainTabPage.Controls.Add(this.groupBox1);
         this._mainTabPage.Controls.Add(this._deleteGroupBox);
         this._mainTabPage.Controls.Add(this._createGroupBox);
         this._mainTabPage.Controls.Add(this._propertiesGroupBox);
         this._mainTabPage.Controls.Add(this._descriptionLabel);
         this._mainTabPage.Location = new System.Drawing.Point(4, 22);
         this._mainTabPage.Name = "_mainTabPage";
         this._mainTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._mainTabPage.Size = new System.Drawing.Size(652, 642);
         this._mainTabPage.TabIndex = 0;
         this._mainTabPage.Text = "Main";
         this._mainTabPage.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lstvwDatabases);
         this.groupBox1.Controls.Add(this.buttonDatabaseConfigure);
         this.groupBox1.Location = new System.Drawing.Point(19, 517);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(620, 119);
         this.groupBox1.TabIndex = 9;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Database Configuration";
         // 
         // _lstvwDatabases
         // 
         this._lstvwDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmhdrKey,
            this.clmhdrValue});
         this._lstvwDatabases.Dock = System.Windows.Forms.DockStyle.Top;
         this._lstvwDatabases.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this._lstvwDatabases.Location = new System.Drawing.Point(3, 16);
         this._lstvwDatabases.MultiSelect = false;
         this._lstvwDatabases.Name = "_lstvwDatabases";
         this._lstvwDatabases.Size = new System.Drawing.Size(614, 79);
         this._lstvwDatabases.TabIndex = 9;
         this._lstvwDatabases.UseCompatibleStateImageBehavior = false;
         this._lstvwDatabases.View = System.Windows.Forms.View.Details;
         // 
         // clmhdrKey
         // 
         this.clmhdrKey.Text = "";
         this.clmhdrKey.Width = 100;
         // 
         // clmhdrValue
         // 
         this.clmhdrValue.Text = "";
         this.clmhdrValue.Width = 200;
         // 
         // buttonDatabaseConfigure
         // 
         this.buttonDatabaseConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonDatabaseConfigure.Location = new System.Drawing.Point(539, 96);
         this.buttonDatabaseConfigure.Name = "buttonDatabaseConfigure";
         this.buttonDatabaseConfigure.Size = new System.Drawing.Size(75, 23);
         this.buttonDatabaseConfigure.TabIndex = 8;
         this.buttonDatabaseConfigure.Text = "Configure...";
         this.buttonDatabaseConfigure.UseVisualStyleBackColor = true;
         this.buttonDatabaseConfigure.Click += new System.EventHandler(this.buttonDatabaseConfigure_Click);
         // 
         // _deleteGroupBox
         // 
         this._deleteGroupBox.Controls.Add(this._deleteNoteLabel);
         this._deleteGroupBox.Controls.Add(this._deleteButton);
         this._deleteGroupBox.Controls.Add(this._deleteLabel);
         this._deleteGroupBox.Location = new System.Drawing.Point(19, 416);
         this._deleteGroupBox.Name = "_deleteGroupBox";
         this._deleteGroupBox.Size = new System.Drawing.Size(620, 88);
         this._deleteGroupBox.TabIndex = 2;
         this._deleteGroupBox.TabStop = false;
         // 
         // _deleteNoteLabel
         // 
         this._deleteNoteLabel.AutoSize = true;
         this._deleteNoteLabel.Location = new System.Drawing.Point(113, 57);
         this._deleteNoteLabel.Name = "_deleteNoteLabel";
         this._deleteNoteLabel.Size = new System.Drawing.Size(380, 13);
         this._deleteNoteLabel.TabIndex = 2;
         this._deleteNoteLabel.Text = "Note: If the application pool or virtual directory do not exist, nothing will hap" +
             "pen.";
         // 
         // _deleteButton
         // 
         this._deleteButton.Location = new System.Drawing.Point(20, 52);
         this._deleteButton.Name = "_deleteButton";
         this._deleteButton.Size = new System.Drawing.Size(75, 23);
         this._deleteButton.TabIndex = 1;
         this._deleteButton.Text = "&Delete";
         this._deleteButton.UseVisualStyleBackColor = true;
         this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
         // 
         // _deleteLabel
         // 
         this._deleteLabel.Location = new System.Drawing.Point(17, 16);
         this._deleteLabel.Name = "_deleteLabel";
         this._deleteLabel.Size = new System.Drawing.Size(585, 33);
         this._deleteLabel.TabIndex = 0;
         this._deleteLabel.Text = "Click the delete button to remove the IIS application pool and virtual directory " +
             "required to use the LEADTOOLS JobProcessor Services.";
         // 
         // _createGroupBox
         // 
         this._createGroupBox.Controls.Add(this._useDotNet4AssembliesCheckBox);
         this._createGroupBox.Controls.Add(this._createNoteLabel);
         this._createGroupBox.Controls.Add(this._createButton);
         this._createGroupBox.Controls.Add(this._x64RadioButton);
         this._createGroupBox.Controls.Add(this._x86RadioButton);
         this._createGroupBox.Controls.Add(this._createLabel);
         this._createGroupBox.Location = new System.Drawing.Point(19, 255);
         this._createGroupBox.Name = "_createGroupBox";
         this._createGroupBox.Size = new System.Drawing.Size(620, 155);
         this._createGroupBox.TabIndex = 0;
         this._createGroupBox.TabStop = false;
         // 
         // _useDotNet4AssembliesCheckBox
         // 
         this._useDotNet4AssembliesCheckBox.AutoSize = true;
         this._useDotNet4AssembliesCheckBox.Location = new System.Drawing.Point(20, 97);
         this._useDotNet4AssembliesCheckBox.Name = "_useDotNet4AssembliesCheckBox";
         this._useDotNet4AssembliesCheckBox.Size = new System.Drawing.Size(270, 17);
         this._useDotNet4AssembliesCheckBox.TabIndex = 4;
         this._useDotNet4AssembliesCheckBox.Text = "Use .NET 4 version of the LEADTOOLS assemblies";
         this._useDotNet4AssembliesCheckBox.UseVisualStyleBackColor = true;
         // 
         // _createNoteLabel
         // 
         this._createNoteLabel.AutoSize = true;
         this._createNoteLabel.Location = new System.Drawing.Point(113, 125);
         this._createNoteLabel.Name = "_createNoteLabel";
         this._createNoteLabel.Size = new System.Drawing.Size(407, 13);
         this._createNoteLabel.TabIndex = 0;
         this._createNoteLabel.Text = "Note: If the application pool or virtual directory already exists, they will be d" +
             "eleted first.";
         // 
         // _createButton
         // 
         this._createButton.Location = new System.Drawing.Point(20, 120);
         this._createButton.Name = "_createButton";
         this._createButton.Size = new System.Drawing.Size(75, 23);
         this._createButton.TabIndex = 5;
         this._createButton.Text = "&Create";
         this._createButton.UseVisualStyleBackColor = true;
         this._createButton.Click += new System.EventHandler(this._createButton_Click);
         // 
         // _x64RadioButton
         // 
         this._x64RadioButton.AutoSize = true;
         this._x64RadioButton.Location = new System.Drawing.Point(20, 74);
         this._x64RadioButton.Name = "_x64RadioButton";
         this._x64RadioButton.Size = new System.Drawing.Size(270, 17);
         this._x64RadioButton.TabIndex = 3;
         this._x64RadioButton.TabStop = true;
         this._x64RadioButton.Text = "Use the x&64 version of the LEADTOOLS assemblies";
         this._x64RadioButton.UseVisualStyleBackColor = true;
         // 
         // _x86RadioButton
         // 
         this._x86RadioButton.AutoSize = true;
         this._x86RadioButton.Location = new System.Drawing.Point(20, 51);
         this._x86RadioButton.Name = "_x86RadioButton";
         this._x86RadioButton.Size = new System.Drawing.Size(270, 17);
         this._x86RadioButton.TabIndex = 2;
         this._x86RadioButton.TabStop = true;
         this._x86RadioButton.Text = "Use the x&86 version of the LEADTOOLS assemblies";
         this._x86RadioButton.UseVisualStyleBackColor = true;
         // 
         // _createLabel
         // 
         this._createLabel.Location = new System.Drawing.Point(17, 16);
         this._createLabel.Name = "_createLabel";
         this._createLabel.Size = new System.Drawing.Size(585, 32);
         this._createLabel.TabIndex = 1;
         this._createLabel.Text = "Select the LEADTOOLS assemblies version to use and click the Create button to cre" +
             "ate the IIS application pool and virtual directory required to use the LEADTOOLS" +
             " JobProcessor Services.";
         // 
         // _propertiesGroupBox
         // 
         this._propertiesGroupBox.Controls.Add(this._testInfoLabel);
         this._propertiesGroupBox.Controls.Add(this._virtualDirPathLabel);
         this._propertiesGroupBox.Controls.Add(this._virtualDirNameLabel);
         this._propertiesGroupBox.Controls.Add(this._appPoolNameLabel);
         this._propertiesGroupBox.Controls.Add(this._iisVersionLabel);
         this._propertiesGroupBox.Controls.Add(this._virtualDirPathTextBox);
         this._propertiesGroupBox.Controls.Add(this._virtualDirNameTextBox);
         this._propertiesGroupBox.Controls.Add(this._appPoolNameTextBox);
         this._propertiesGroupBox.Controls.Add(this._iisVersionTextBox);
         this._propertiesGroupBox.Controls.Add(this._machineTextBox);
         this._propertiesGroupBox.Controls.Add(this._machineLabel);
         this._propertiesGroupBox.Location = new System.Drawing.Point(19, 55);
         this._propertiesGroupBox.Name = "_propertiesGroupBox";
         this._propertiesGroupBox.Size = new System.Drawing.Size(620, 194);
         this._propertiesGroupBox.TabIndex = 1;
         this._propertiesGroupBox.TabStop = false;
         this._propertiesGroupBox.Text = "LEADTOOLS Job Processor Server Properties:";
         // 
         // _testInfoLabel
         // 
         this._testInfoLabel.Location = new System.Drawing.Point(20, 159);
         this._testInfoLabel.Name = "_testInfoLabel";
         this._testInfoLabel.Size = new System.Drawing.Size(559, 32);
         this._testInfoLabel.TabIndex = 10;
         this._testInfoLabel.Text = "Go to the JobProcessor Services Properties and Test page to check the status of the curr" +
             "ent LEADTOOLS JobProcessor components";
         // 
         // _virtualDirPathLabel
         // 
         this._virtualDirPathLabel.AutoSize = true;
         this._virtualDirPathLabel.Location = new System.Drawing.Point(17, 129);
         this._virtualDirPathLabel.Name = "_virtualDirPathLabel";
         this._virtualDirPathLabel.Size = new System.Drawing.Size(106, 13);
         this._virtualDirPathLabel.TabIndex = 8;
         this._virtualDirPathLabel.Text = "Virtual directory path:";
         // 
         // _virtualDirNameLabel
         // 
         this._virtualDirNameLabel.AutoSize = true;
         this._virtualDirNameLabel.Location = new System.Drawing.Point(17, 103);
         this._virtualDirNameLabel.Name = "_virtualDirNameLabel";
         this._virtualDirNameLabel.Size = new System.Drawing.Size(111, 13);
         this._virtualDirNameLabel.TabIndex = 6;
         this._virtualDirNameLabel.Text = "Virtual directory name:";
         // 
         // _appPoolNameLabel
         // 
         this._appPoolNameLabel.AutoSize = true;
         this._appPoolNameLabel.Location = new System.Drawing.Point(17, 77);
         this._appPoolNameLabel.Name = "_appPoolNameLabel";
         this._appPoolNameLabel.Size = new System.Drawing.Size(114, 13);
         this._appPoolNameLabel.TabIndex = 4;
         this._appPoolNameLabel.Text = "Application pool name:";
         // 
         // _iisVersionLabel
         // 
         this._iisVersionLabel.AutoSize = true;
         this._iisVersionLabel.Location = new System.Drawing.Point(17, 51);
         this._iisVersionLabel.Name = "_iisVersionLabel";
         this._iisVersionLabel.Size = new System.Drawing.Size(60, 13);
         this._iisVersionLabel.TabIndex = 2;
         this._iisVersionLabel.Text = "IIS version:";
         // 
         // _virtualDirPathTextBox
         // 
         this._virtualDirPathTextBox.Location = new System.Drawing.Point(151, 126);
         this._virtualDirPathTextBox.Name = "_virtualDirPathTextBox";
         this._virtualDirPathTextBox.ReadOnly = true;
         this._virtualDirPathTextBox.Size = new System.Drawing.Size(451, 20);
         this._virtualDirPathTextBox.TabIndex = 9;
         // 
         // _virtualDirNameTextBox
         // 
         this._virtualDirNameTextBox.Location = new System.Drawing.Point(151, 100);
         this._virtualDirNameTextBox.Name = "_virtualDirNameTextBox";
         this._virtualDirNameTextBox.ReadOnly = true;
         this._virtualDirNameTextBox.Size = new System.Drawing.Size(255, 20);
         this._virtualDirNameTextBox.TabIndex = 7;
         // 
         // _appPoolNameTextBox
         // 
         this._appPoolNameTextBox.Location = new System.Drawing.Point(151, 74);
         this._appPoolNameTextBox.Name = "_appPoolNameTextBox";
         this._appPoolNameTextBox.ReadOnly = true;
         this._appPoolNameTextBox.Size = new System.Drawing.Size(255, 20);
         this._appPoolNameTextBox.TabIndex = 5;
         // 
         // _iisVersionTextBox
         // 
         this._iisVersionTextBox.Location = new System.Drawing.Point(151, 48);
         this._iisVersionTextBox.Name = "_iisVersionTextBox";
         this._iisVersionTextBox.ReadOnly = true;
         this._iisVersionTextBox.Size = new System.Drawing.Size(255, 20);
         this._iisVersionTextBox.TabIndex = 3;
         // 
         // _machineTextBox
         // 
         this._machineTextBox.Location = new System.Drawing.Point(151, 22);
         this._machineTextBox.Name = "_machineTextBox";
         this._machineTextBox.ReadOnly = true;
         this._machineTextBox.Size = new System.Drawing.Size(255, 20);
         this._machineTextBox.TabIndex = 1;
         // 
         // _machineLabel
         // 
         this._machineLabel.AutoSize = true;
         this._machineLabel.Location = new System.Drawing.Point(17, 25);
         this._machineLabel.Name = "_machineLabel";
         this._machineLabel.Size = new System.Drawing.Size(51, 13);
         this._machineLabel.TabIndex = 0;
         this._machineLabel.Text = "Machine:";
         // 
         // _descriptionLabel
         // 
         this._descriptionLabel.Location = new System.Drawing.Point(16, 19);
         this._descriptionLabel.Name = "_descriptionLabel";
         this._descriptionLabel.Size = new System.Drawing.Size(623, 33);
         this._descriptionLabel.TabIndex = 0;
         this._descriptionLabel.Text = "LEADTOOLS JobProcessor services must be configured and hosted in IIS (Internet Informati" +
             "on Services) before they are usable in your application or the LEADTOOLS JobProcessor d" +
             "emos.";
         // 
         // _testTabPage
         // 
         this._testTabPage.Controls.Add(this._JobProcessorComponentsHelpLabel);
         this._testTabPage.Controls.Add(this._JobProcessorComponentsGroupBox);
         this._testTabPage.Location = new System.Drawing.Point(4, 22);
         this._testTabPage.Name = "_testTabPage";
         this._testTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._testTabPage.Size = new System.Drawing.Size(652, 642);
         this._testTabPage.TabIndex = 1;
         this._testTabPage.Text = "JobProcessor Services Properties and Test";
         this._testTabPage.UseVisualStyleBackColor = true;
         // 
         // _JobProcessorComponentsHelpLabel
         // 
         this._JobProcessorComponentsHelpLabel.Location = new System.Drawing.Point(16, 429);
         this._JobProcessorComponentsHelpLabel.Name = "_JobProcessorComponentsHelpLabel";
         this._JobProcessorComponentsHelpLabel.Size = new System.Drawing.Size(610, 91);
         this._JobProcessorComponentsHelpLabel.TabIndex = 1;
         this._JobProcessorComponentsHelpLabel.Text = resources.GetString("_JobProcessorComponentsHelpLabel.Text");
         // 
         // _JobProcessorComponentsGroupBox
         // 
         this._JobProcessorComponentsGroupBox.Controls.Add(this._JobProcessorComponentsRichTextBox);
         this._JobProcessorComponentsGroupBox.Controls.Add(this._troubleShootButton);
         this._JobProcessorComponentsGroupBox.Controls.Add(this._testButton);
         this._JobProcessorComponentsGroupBox.Controls.Add(this._JobProcessorComponentsGroupBoxLabel);
         this._JobProcessorComponentsGroupBox.Location = new System.Drawing.Point(19, 20);
         this._JobProcessorComponentsGroupBox.Name = "_JobProcessorComponentsGroupBox";
         this._JobProcessorComponentsGroupBox.Size = new System.Drawing.Size(610, 406);
         this._JobProcessorComponentsGroupBox.TabIndex = 0;
         this._JobProcessorComponentsGroupBox.TabStop = false;
         this._JobProcessorComponentsGroupBox.Text = "LEADTOOLS JobProcessor Services (You can browse to the Service URL by clicking on its li" +
             "nk):";
         // 
         // _JobProcessorComponentsRichTextBox
         // 
         this._JobProcessorComponentsRichTextBox.Location = new System.Drawing.Point(25, 33);
         this._JobProcessorComponentsRichTextBox.Name = "_JobProcessorComponentsRichTextBox";
         this._JobProcessorComponentsRichTextBox.ReadOnly = true;
         this._JobProcessorComponentsRichTextBox.Size = new System.Drawing.Size(564, 319);
         this._JobProcessorComponentsRichTextBox.TabIndex = 0;
         this._JobProcessorComponentsRichTextBox.Text = "";
         this._JobProcessorComponentsRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this._JobProcessorComponentsRichTextBox_LinkClicked);
         // 
         // _troubleShootButton
         // 
         this._troubleShootButton.Location = new System.Drawing.Point(471, 371);
         this._troubleShootButton.Name = "_troubleShootButton";
         this._troubleShootButton.Size = new System.Drawing.Size(118, 23);
         this._troubleShootButton.TabIndex = 3;
         this._troubleShootButton.Text = "T&roubleshoot...";
         this._troubleShootButton.UseVisualStyleBackColor = true;
         this._troubleShootButton.Click += new System.EventHandler(this._troubleShootButton_Click);
         // 
         // _testButton
         // 
         this._testButton.Location = new System.Drawing.Point(25, 371);
         this._testButton.Name = "_testButton";
         this._testButton.Size = new System.Drawing.Size(75, 23);
         this._testButton.TabIndex = 2;
         this._testButton.Text = "&Test";
         this._testButton.UseVisualStyleBackColor = true;
         this._testButton.Click += new System.EventHandler(this._testButton_Click);
         // 
         // _JobProcessorComponentsGroupBoxLabel
         // 
         this._JobProcessorComponentsGroupBoxLabel.AutoSize = true;
         this._JobProcessorComponentsGroupBoxLabel.Location = new System.Drawing.Point(22, 355);
         this._JobProcessorComponentsGroupBoxLabel.Name = "_JobProcessorComponentsGroupBoxLabel";
         this._JobProcessorComponentsGroupBoxLabel.Size = new System.Drawing.Size(373, 13);
         this._JobProcessorComponentsGroupBoxLabel.TabIndex = 1;
         this._JobProcessorComponentsGroupBoxLabel.Text = "Click the Test button to check the status of the LEADTOOLS JobProcessor Services.";
         // 
         // _workersTabPage
         // 
         this._workersTabPage.Controls.Add(this._lblComments);
         this._workersTabPage.Controls.Add(this._btnApply);
         this._workersTabPage.Controls.Add(this._btnAddJobType);
         this._workersTabPage.Controls.Add(this._btnAddWorker);
         this._workersTabPage.Controls.Add(this._gbJobType);
         this._workersTabPage.Controls.Add(this._gbWorker);
         this._workersTabPage.Controls.Add(this._tvWorkers);
         this._workersTabPage.Location = new System.Drawing.Point(4, 22);
         this._workersTabPage.Name = "_workersTabPage";
         this._workersTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._workersTabPage.Size = new System.Drawing.Size(652, 642);
         this._workersTabPage.TabIndex = 3;
         this._workersTabPage.Text = "Workers";
         this._workersTabPage.UseVisualStyleBackColor = true;
         this._workersTabPage.Enter += new System.EventHandler(this._workersTabPage_Enter);
         // 
         // _lblComments
         // 
         this._lblComments.Location = new System.Drawing.Point(239, 6);
         this._lblComments.Name = "_lblComments";
         this._lblComments.Size = new System.Drawing.Size(401, 141);
         this._lblComments.TabIndex = 24;
         this._lblComments.Text = resources.GetString("_lblComments.Text");
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(545, 601);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(95, 23);
         this._btnApply.TabIndex = 21;
         this._btnApply.Text = "Apply Current Settings";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _btnAddJobType
         // 
         this._btnAddJobType.Location = new System.Drawing.Point(242, 601);
         this._btnAddJobType.Name = "_btnAddJobType";
         this._btnAddJobType.Size = new System.Drawing.Size(95, 23);
         this._btnAddJobType.TabIndex = 22;
         this._btnAddJobType.Text = "Add Job Type";
         this._btnAddJobType.UseVisualStyleBackColor = true;
         this._btnAddJobType.Click += new System.EventHandler(this._btnAddJobType_Click);
         // 
         // _btnAddWorker
         // 
         this._btnAddWorker.Location = new System.Drawing.Point(242, 572);
         this._btnAddWorker.Name = "_btnAddWorker";
         this._btnAddWorker.Size = new System.Drawing.Size(95, 23);
         this._btnAddWorker.TabIndex = 23;
         this._btnAddWorker.Text = "Add Worker";
         this._btnAddWorker.UseVisualStyleBackColor = true;
         this._btnAddWorker.Click += new System.EventHandler(this._btnAddWorker_Click);
         // 
         // _gbJobType
         // 
         this._gbJobType.Controls.Add(this._btnRemoveJobType);
         this._gbJobType.Controls.Add(this._lblAttempts);
         this._gbJobType.Controls.Add(this._numJobTypeAttempts);
         this._gbJobType.Controls.Add(this._lblAssumeHangAfter);
         this._gbJobType.Controls.Add(this._numJobTypeAssumeHangAfter);
         this._gbJobType.Controls.Add(this._chkJobTypeUseCpuThreshold);
         this._gbJobType.Controls.Add(this._lblProgressRate);
         this._gbJobType.Controls.Add(this._numJobTypeProgressRate);
         this._gbJobType.Controls.Add(this._lblCPUThreshold);
         this._gbJobType.Controls.Add(this._numJobTypeCPUThreshold);
         this._gbJobType.Controls.Add(this._lblJobTypeMaxNumberOfJobs);
         this._gbJobType.Controls.Add(this._txtJobTypeName);
         this._gbJobType.Controls.Add(this._numJobTypeMaxNumberOfJobs);
         this._gbJobType.Controls.Add(this._lblJobTypeName);
         this._gbJobType.Location = new System.Drawing.Point(234, 288);
         this._gbJobType.Name = "_gbJobType";
         this._gbJobType.Size = new System.Drawing.Size(412, 278);
         this._gbJobType.TabIndex = 20;
         this._gbJobType.TabStop = false;
         this._gbJobType.Text = "Job Type";
         // 
         // _btnRemoveJobType
         // 
         this._btnRemoveJobType.Location = new System.Drawing.Point(311, 249);
         this._btnRemoveJobType.Name = "_btnRemoveJobType";
         this._btnRemoveJobType.Size = new System.Drawing.Size(95, 23);
         this._btnRemoveJobType.TabIndex = 16;
         this._btnRemoveJobType.Text = "Remove Job Type";
         this._btnRemoveJobType.UseVisualStyleBackColor = true;
         this._btnRemoveJobType.Click += new System.EventHandler(this._btnRemoveJobType_Click);
         // 
         // _lblAttempts
         // 
         this._lblAttempts.AutoSize = true;
         this._lblAttempts.Location = new System.Drawing.Point(16, 226);
         this._lblAttempts.Name = "_lblAttempts";
         this._lblAttempts.Size = new System.Drawing.Size(51, 13);
         this._lblAttempts.TabIndex = 13;
         this._lblAttempts.Text = "Attempts:";
         // 
         // _numJobTypeAttempts
         // 
         this._numJobTypeAttempts.Location = new System.Drawing.Point(191, 219);
         this._numJobTypeAttempts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numJobTypeAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numJobTypeAttempts.Name = "_numJobTypeAttempts";
         this._numJobTypeAttempts.Size = new System.Drawing.Size(80, 20);
         this._numJobTypeAttempts.TabIndex = 12;
         this._numJobTypeAttempts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _lblAssumeHangAfter
         // 
         this._lblAssumeHangAfter.AutoSize = true;
         this._lblAssumeHangAfter.Location = new System.Drawing.Point(16, 186);
         this._lblAssumeHangAfter.Name = "_lblAssumeHangAfter";
         this._lblAssumeHangAfter.Size = new System.Drawing.Size(150, 13);
         this._lblAssumeHangAfter.TabIndex = 11;
         this._lblAssumeHangAfter.Text = "Assume Hang After (seconds):";
         // 
         // _numJobTypeAssumeHangAfter
         // 
         this._numJobTypeAssumeHangAfter.Location = new System.Drawing.Point(191, 179);
         this._numJobTypeAssumeHangAfter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numJobTypeAssumeHangAfter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numJobTypeAssumeHangAfter.Name = "_numJobTypeAssumeHangAfter";
         this._numJobTypeAssumeHangAfter.Size = new System.Drawing.Size(80, 20);
         this._numJobTypeAssumeHangAfter.TabIndex = 10;
         this._numJobTypeAssumeHangAfter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _chkJobTypeUseCpuThreshold
         // 
         this._chkJobTypeUseCpuThreshold.AutoSize = true;
         this._chkJobTypeUseCpuThreshold.Location = new System.Drawing.Point(291, 105);
         this._chkJobTypeUseCpuThreshold.Name = "_chkJobTypeUseCpuThreshold";
         this._chkJobTypeUseCpuThreshold.Size = new System.Drawing.Size(120, 17);
         this._chkJobTypeUseCpuThreshold.TabIndex = 9;
         this._chkJobTypeUseCpuThreshold.Text = "Use CPU Threshold";
         this._chkJobTypeUseCpuThreshold.UseVisualStyleBackColor = true;
         this._chkJobTypeUseCpuThreshold.CheckedChanged += new System.EventHandler(this._chkJobTypeUseCpuThreshold_CheckedChanged);
         // 
         // _lblProgressRate
         // 
         this._lblProgressRate.AutoSize = true;
         this._lblProgressRate.Location = new System.Drawing.Point(16, 145);
         this._lblProgressRate.Name = "_lblProgressRate";
         this._lblProgressRate.Size = new System.Drawing.Size(126, 13);
         this._lblProgressRate.TabIndex = 8;
         this._lblProgressRate.Text = "Progress Rate (seconds):";
         // 
         // _numJobTypeProgressRate
         // 
         this._numJobTypeProgressRate.Location = new System.Drawing.Point(191, 138);
         this._numJobTypeProgressRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numJobTypeProgressRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numJobTypeProgressRate.Name = "_numJobTypeProgressRate";
         this._numJobTypeProgressRate.Size = new System.Drawing.Size(80, 20);
         this._numJobTypeProgressRate.TabIndex = 7;
         this._numJobTypeProgressRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _lblCPUThreshold
         // 
         this._lblCPUThreshold.AutoSize = true;
         this._lblCPUThreshold.Location = new System.Drawing.Point(16, 107);
         this._lblCPUThreshold.Name = "_lblCPUThreshold";
         this._lblCPUThreshold.Size = new System.Drawing.Size(82, 13);
         this._lblCPUThreshold.TabIndex = 6;
         this._lblCPUThreshold.Text = "CPU Threshold:";
         // 
         // _numJobTypeCPUThreshold
         // 
         this._numJobTypeCPUThreshold.Location = new System.Drawing.Point(191, 100);
         this._numJobTypeCPUThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numJobTypeCPUThreshold.Name = "_numJobTypeCPUThreshold";
         this._numJobTypeCPUThreshold.Size = new System.Drawing.Size(80, 20);
         this._numJobTypeCPUThreshold.TabIndex = 5;
         this._numJobTypeCPUThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _lblJobTypeMaxNumberOfJobs
         // 
         this._lblJobTypeMaxNumberOfJobs.AutoSize = true;
         this._lblJobTypeMaxNumberOfJobs.Location = new System.Drawing.Point(16, 63);
         this._lblJobTypeMaxNumberOfJobs.Name = "_lblJobTypeMaxNumberOfJobs";
         this._lblJobTypeMaxNumberOfJobs.Size = new System.Drawing.Size(109, 13);
         this._lblJobTypeMaxNumberOfJobs.TabIndex = 4;
         this._lblJobTypeMaxNumberOfJobs.Text = "Max Number Of Jobs:";
         // 
         // _txtJobTypeName
         // 
         this._txtJobTypeName.Location = new System.Drawing.Point(191, 24);
         this._txtJobTypeName.Name = "_txtJobTypeName";
         this._txtJobTypeName.Size = new System.Drawing.Size(199, 20);
         this._txtJobTypeName.TabIndex = 3;
         // 
         // _numJobTypeMaxNumberOfJobs
         // 
         this._numJobTypeMaxNumberOfJobs.Location = new System.Drawing.Point(191, 56);
         this._numJobTypeMaxNumberOfJobs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numJobTypeMaxNumberOfJobs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numJobTypeMaxNumberOfJobs.Name = "_numJobTypeMaxNumberOfJobs";
         this._numJobTypeMaxNumberOfJobs.Size = new System.Drawing.Size(80, 20);
         this._numJobTypeMaxNumberOfJobs.TabIndex = 2;
         this._numJobTypeMaxNumberOfJobs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _lblJobTypeName
         // 
         this._lblJobTypeName.AutoSize = true;
         this._lblJobTypeName.Location = new System.Drawing.Point(16, 31);
         this._lblJobTypeName.Name = "_lblJobTypeName";
         this._lblJobTypeName.Size = new System.Drawing.Size(38, 13);
         this._lblJobTypeName.TabIndex = 1;
         this._lblJobTypeName.Text = "Name:";
         // 
         // _gbWorker
         // 
         this._gbWorker.Controls.Add(this._btnRemoveWorker);
         this._gbWorker.Controls.Add(this._lblWorkerNewJobCheckPeriod);
         this._gbWorker.Controls.Add(this._txtWorkerName);
         this._gbWorker.Controls.Add(this._lblWorkerName);
         this._gbWorker.Controls.Add(this._numWorkerNewJobCheckPeriod);
         this._gbWorker.Location = new System.Drawing.Point(234, 164);
         this._gbWorker.Name = "_gbWorker";
         this._gbWorker.Size = new System.Drawing.Size(412, 118);
         this._gbWorker.TabIndex = 19;
         this._gbWorker.TabStop = false;
         this._gbWorker.Text = "Worker";
         // 
         // _btnRemoveWorker
         // 
         this._btnRemoveWorker.Location = new System.Drawing.Point(311, 95);
         this._btnRemoveWorker.Name = "_btnRemoveWorker";
         this._btnRemoveWorker.Size = new System.Drawing.Size(95, 23);
         this._btnRemoveWorker.TabIndex = 18;
         this._btnRemoveWorker.Text = "Remove Worker";
         this._btnRemoveWorker.UseVisualStyleBackColor = true;
         this._btnRemoveWorker.Click += new System.EventHandler(this._btnRemoveWorker_Click);
         // 
         // _lblWorkerNewJobCheckPeriod
         // 
         this._lblWorkerNewJobCheckPeriod.AutoSize = true;
         this._lblWorkerNewJobCheckPeriod.Location = new System.Drawing.Point(16, 64);
         this._lblWorkerNewJobCheckPeriod.Name = "_lblWorkerNewJobCheckPeriod";
         this._lblWorkerNewJobCheckPeriod.Size = new System.Drawing.Size(168, 13);
         this._lblWorkerNewJobCheckPeriod.TabIndex = 3;
         this._lblWorkerNewJobCheckPeriod.Text = "New Job Check Period (seconds):";
         // 
         // _txtWorkerName
         // 
         this._txtWorkerName.Location = new System.Drawing.Point(191, 23);
         this._txtWorkerName.Name = "_txtWorkerName";
         this._txtWorkerName.Size = new System.Drawing.Size(199, 20);
         this._txtWorkerName.TabIndex = 2;
         // 
         // _lblWorkerName
         // 
         this._lblWorkerName.AutoSize = true;
         this._lblWorkerName.Location = new System.Drawing.Point(16, 30);
         this._lblWorkerName.Name = "_lblWorkerName";
         this._lblWorkerName.Size = new System.Drawing.Size(38, 13);
         this._lblWorkerName.TabIndex = 1;
         this._lblWorkerName.Text = "Name:";
         // 
         // _numWorkerNewJobCheckPeriod
         // 
         this._numWorkerNewJobCheckPeriod.Location = new System.Drawing.Point(191, 57);
         this._numWorkerNewJobCheckPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numWorkerNewJobCheckPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numWorkerNewJobCheckPeriod.Name = "_numWorkerNewJobCheckPeriod";
         this._numWorkerNewJobCheckPeriod.Size = new System.Drawing.Size(80, 20);
         this._numWorkerNewJobCheckPeriod.TabIndex = 0;
         this._numWorkerNewJobCheckPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // _tvWorkers
         // 
         this._tvWorkers.HideSelection = false;
         this._tvWorkers.Location = new System.Drawing.Point(6, 6);
         this._tvWorkers.Name = "_tvWorkers";
         this._tvWorkers.Size = new System.Drawing.Size(222, 624);
         this._tvWorkers.TabIndex = 18;
         this._tvWorkers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvWorkers_AfterSelect);
         // 
         // _helpTabPage
         // 
         this._helpTabPage.Controls.Add(this._troubleShootHelpButton);
         this._helpTabPage.Controls.Add(this._help3Label);
         this._helpTabPage.Controls.Add(this._sourceCodeTextBox);
         this._helpTabPage.Controls.Add(this._help2Label);
         this._helpTabPage.Controls.Add(this._help1Label);
         this._helpTabPage.Location = new System.Drawing.Point(4, 22);
         this._helpTabPage.Name = "_helpTabPage";
         this._helpTabPage.Size = new System.Drawing.Size(652, 642);
         this._helpTabPage.TabIndex = 2;
         this._helpTabPage.Text = "Help";
         this._helpTabPage.UseVisualStyleBackColor = true;
         // 
         // _troubleShootHelpButton
         // 
         this._troubleShootHelpButton.Location = new System.Drawing.Point(18, 244);
         this._troubleShootHelpButton.Name = "_troubleShootHelpButton";
         this._troubleShootHelpButton.Size = new System.Drawing.Size(118, 23);
         this._troubleShootHelpButton.TabIndex = 7;
         this._troubleShootHelpButton.Text = "T&roubleshoot...";
         this._troubleShootHelpButton.UseVisualStyleBackColor = true;
         this._troubleShootHelpButton.Click += new System.EventHandler(this._troubleShootHelpButton_Click);
         // 
         // _help3Label
         // 
         this._help3Label.Location = new System.Drawing.Point(15, 140);
         this._help3Label.Name = "_help3Label";
         this._help3Label.Size = new System.Drawing.Size(623, 84);
         this._help3Label.TabIndex = 6;
         this._help3Label.Text = resources.GetString("_help3Label.Text");
         // 
         // _sourceCodeTextBox
         // 
         this._sourceCodeTextBox.Location = new System.Drawing.Point(18, 106);
         this._sourceCodeTextBox.Name = "_sourceCodeTextBox";
         this._sourceCodeTextBox.ReadOnly = true;
         this._sourceCodeTextBox.Size = new System.Drawing.Size(611, 20);
         this._sourceCodeTextBox.TabIndex = 5;
         // 
         // _help2Label
         // 
         this._help2Label.Location = new System.Drawing.Point(15, 62);
         this._help2Label.Name = "_help2Label";
         this._help2Label.Size = new System.Drawing.Size(623, 41);
         this._help2Label.TabIndex = 4;
         this._help2Label.Text = "The source code for this application is available with your LEADTOOLS installatio" +
             "n as a Microsoft Visual Studio C# project and is located in:";
         // 
         // _help1Label
         // 
         this._help1Label.Location = new System.Drawing.Point(15, 28);
         this._help1Label.Name = "_help1Label";
         this._help1Label.Size = new System.Drawing.Size(623, 34);
         this._help1Label.TabIndex = 3;
         this._help1Label.Text = "The JobProcessor services must be configured and hosted in IIS (Internet Information Ser" +
             "vices) before they are usable in your application or the LEADTOOLS JobProcessor demos.";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
         this.ClientSize = new System.Drawing.Size(684, 692);
         this.Controls.Add(this._mainTabControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._mainTabControl.ResumeLayout(false);
         this._mainTabPage.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this._deleteGroupBox.ResumeLayout(false);
         this._deleteGroupBox.PerformLayout();
         this._createGroupBox.ResumeLayout(false);
         this._createGroupBox.PerformLayout();
         this._propertiesGroupBox.ResumeLayout(false);
         this._propertiesGroupBox.PerformLayout();
         this._testTabPage.ResumeLayout(false);
         this._JobProcessorComponentsGroupBox.ResumeLayout(false);
         this._JobProcessorComponentsGroupBox.PerformLayout();
         this._workersTabPage.ResumeLayout(false);
         this._gbJobType.ResumeLayout(false);
         this._gbJobType.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeAttempts)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeAssumeHangAfter)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeProgressRate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeCPUThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numJobTypeMaxNumberOfJobs)).EndInit();
         this._gbWorker.ResumeLayout(false);
         this._gbWorker.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWorkerNewJobCheckPeriod)).EndInit();
         this._helpTabPage.ResumeLayout(false);
         this._helpTabPage.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl _mainTabControl;
      private System.Windows.Forms.TabPage _mainTabPage;
      private System.Windows.Forms.TabPage _testTabPage;
      private System.Windows.Forms.GroupBox _propertiesGroupBox;
      private System.Windows.Forms.Label _virtualDirPathLabel;
      private System.Windows.Forms.Label _virtualDirNameLabel;
      private System.Windows.Forms.Label _appPoolNameLabel;
      private System.Windows.Forms.Label _iisVersionLabel;
      private System.Windows.Forms.TextBox _virtualDirPathTextBox;
      private System.Windows.Forms.TextBox _virtualDirNameTextBox;
      private System.Windows.Forms.TextBox _appPoolNameTextBox;
      private System.Windows.Forms.TextBox _iisVersionTextBox;
      private System.Windows.Forms.TextBox _machineTextBox;
      private System.Windows.Forms.Label _machineLabel;
      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.GroupBox _createGroupBox;
      private System.Windows.Forms.Label _createLabel;
      private System.Windows.Forms.RadioButton _x86RadioButton;
      private System.Windows.Forms.RadioButton _x64RadioButton;
      private System.Windows.Forms.Button _createButton;
      private System.Windows.Forms.GroupBox _deleteGroupBox;
      private System.Windows.Forms.Button _deleteButton;
      private System.Windows.Forms.Label _deleteLabel;
      private System.Windows.Forms.Label _testInfoLabel;
      private System.Windows.Forms.GroupBox _JobProcessorComponentsGroupBox;
      private System.Windows.Forms.TabPage _helpTabPage;
      private System.Windows.Forms.Label _JobProcessorComponentsGroupBoxLabel;
      private System.Windows.Forms.Button _testButton;
      private System.Windows.Forms.Label _help2Label;
      private System.Windows.Forms.Label _help1Label;
      private System.Windows.Forms.TextBox _sourceCodeTextBox;
      private System.Windows.Forms.Label _help3Label;
      private System.Windows.Forms.Label _JobProcessorComponentsHelpLabel;
      private System.Windows.Forms.Label _deleteNoteLabel;
      private System.Windows.Forms.Label _createNoteLabel;
      private System.Windows.Forms.Button _troubleShootButton;
      private System.Windows.Forms.Button _troubleShootHelpButton;
      private System.Windows.Forms.RichTextBox _JobProcessorComponentsRichTextBox;
      private System.Windows.Forms.CheckBox _useDotNet4AssembliesCheckBox;
      private System.Windows.Forms.Button buttonDatabaseConfigure;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ListView _lstvwDatabases;
      private ColumnHeader clmhdrKey;
      private ColumnHeader clmhdrValue;
      private TabPage _workersTabPage;
      private Button _btnApply;
      private Button _btnAddJobType;
      private Button _btnAddWorker;
      private GroupBox _gbJobType;
      private Button _btnRemoveJobType;
      private Label _lblAttempts;
      private NumericUpDown _numJobTypeAttempts;
      private Label _lblAssumeHangAfter;
      private NumericUpDown _numJobTypeAssumeHangAfter;
      private CheckBox _chkJobTypeUseCpuThreshold;
      private Label _lblProgressRate;
      private NumericUpDown _numJobTypeProgressRate;
      private Label _lblCPUThreshold;
      private NumericUpDown _numJobTypeCPUThreshold;
      private Label _lblJobTypeMaxNumberOfJobs;
      private TextBox _txtJobTypeName;
      private NumericUpDown _numJobTypeMaxNumberOfJobs;
      private Label _lblJobTypeName;
      private GroupBox _gbWorker;
      private Button _btnRemoveWorker;
      private Label _lblWorkerNewJobCheckPeriod;
      private TextBox _txtWorkerName;
      private Label _lblWorkerName;
      private NumericUpDown _numWorkerNewJobCheckPeriod;
      private TreeView _tvWorkers;
      private Label _lblComments;
   }
}

