namespace Leadtools.Ccow.Dialogs
{
    partial class ConfigurationDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationDialog));
         this.tabControlConfiguration = new System.Windows.Forms.TabControl();
         this.tabPageApplications = new System.Windows.Forms.TabPage();
         this.buttonAllowNone = new System.Windows.Forms.Button();
         this.buttonAllowAll = new System.Windows.Forms.Button();
         this.buttonEdit = new System.Windows.Forms.Button();
         this.buttonDelete = new System.Windows.Forms.Button();
         this.buttonAdd = new System.Windows.Forms.Button();
         this.listViewApplications = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.imageListApplications = new System.Windows.Forms.ImageList(this.components);
         this.label1 = new System.Windows.Forms.Label();
         this.tabPageSubjects = new System.Windows.Forms.TabPage();
         this.buttonEditSubject = new System.Windows.Forms.Button();
         this.buttonDeleteSubject = new System.Windows.Forms.Button();
         this.buttonAddSubject = new System.Windows.Forms.Button();
         this.listViewSubjects = new System.Windows.Forms.ListView();
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.label2 = new System.Windows.Forms.Label();
         this.tabPageAdvanced = new System.Windows.Forms.TabPage();
         this.PingInterval = new System.Windows.Forms.NumericUpDown();
         this.PingNotificationTimeout = new System.Windows.Forms.NumericUpDown();
         this.NotificationRetryInterval = new System.Windows.Forms.NumericUpDown();
         this.NotificationTimeout = new System.Windows.Forms.NumericUpDown();
         this.ActionTimeout = new System.Windows.Forms.NumericUpDown();
         this.TransactionTimeout = new System.Windows.Forms.NumericUpDown();
         this.MaxParticipants = new System.Windows.Forms.NumericUpDown();
         this.label6 = new System.Windows.Forms.Label();
         this.buttonApplyConfig = new System.Windows.Forms.Button();
         this.checkBoxPing = new System.Windows.Forms.CheckBox();
         this.label10 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.groupBoxWeb = new System.Windows.Forms.GroupBox();
         this.labelCcowWebNote = new System.Windows.Forms.Label();
         this.webAdress = new System.Windows.Forms.TextBox();
         this.label11 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.buttonOK = new System.Windows.Forms.Button();
         this.tabControlConfiguration.SuspendLayout();
         this.tabPageApplications.SuspendLayout();
         this.tabPageSubjects.SuspendLayout();
         this.tabPageAdvanced.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.PingInterval)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.PingNotificationTimeout)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.NotificationRetryInterval)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.NotificationTimeout)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ActionTimeout)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.TransactionTimeout)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.MaxParticipants)).BeginInit();
         this.tabPage1.SuspendLayout();
         this.groupBoxWeb.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControlConfiguration
         // 
         this.tabControlConfiguration.Controls.Add(this.tabPageApplications);
         this.tabControlConfiguration.Controls.Add(this.tabPageSubjects);
         this.tabControlConfiguration.Controls.Add(this.tabPageAdvanced);
         this.tabControlConfiguration.Controls.Add(this.tabPage1);
         this.tabControlConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlConfiguration.Location = new System.Drawing.Point(0, 0);
         this.tabControlConfiguration.Name = "tabControlConfiguration";
         this.tabControlConfiguration.SelectedIndex = 0;
         this.tabControlConfiguration.Size = new System.Drawing.Size(498, 380);
         this.tabControlConfiguration.TabIndex = 0;
         // 
         // tabPageApplications
         // 
         this.tabPageApplications.Controls.Add(this.buttonAllowNone);
         this.tabPageApplications.Controls.Add(this.buttonAllowAll);
         this.tabPageApplications.Controls.Add(this.buttonEdit);
         this.tabPageApplications.Controls.Add(this.buttonDelete);
         this.tabPageApplications.Controls.Add(this.buttonAdd);
         this.tabPageApplications.Controls.Add(this.listViewApplications);
         this.tabPageApplications.Controls.Add(this.label1);
         this.tabPageApplications.Location = new System.Drawing.Point(4, 22);
         this.tabPageApplications.Name = "tabPageApplications";
         this.tabPageApplications.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageApplications.Size = new System.Drawing.Size(490, 354);
         this.tabPageApplications.TabIndex = 0;
         this.tabPageApplications.Text = "Applications";
         this.tabPageApplications.UseVisualStyleBackColor = true;
         // 
         // buttonAllowNone
         // 
         this.buttonAllowNone.Location = new System.Drawing.Point(407, 181);
         this.buttonAllowNone.Name = "buttonAllowNone";
         this.buttonAllowNone.Size = new System.Drawing.Size(75, 23);
         this.buttonAllowNone.TabIndex = 6;
         this.buttonAllowNone.Text = "Allow None";
         this.buttonAllowNone.UseVisualStyleBackColor = true;
         this.buttonAllowNone.Click += new System.EventHandler(this.buttonAllowNone_Click);
         // 
         // buttonAllowAll
         // 
         this.buttonAllowAll.Location = new System.Drawing.Point(406, 152);
         this.buttonAllowAll.Name = "buttonAllowAll";
         this.buttonAllowAll.Size = new System.Drawing.Size(75, 23);
         this.buttonAllowAll.TabIndex = 5;
         this.buttonAllowAll.Text = "Allow All";
         this.buttonAllowAll.UseVisualStyleBackColor = true;
         this.buttonAllowAll.Click += new System.EventHandler(this.buttonAllowAll_Click);
         // 
         // buttonEdit
         // 
         this.buttonEdit.Location = new System.Drawing.Point(406, 59);
         this.buttonEdit.Name = "buttonEdit";
         this.buttonEdit.Size = new System.Drawing.Size(75, 23);
         this.buttonEdit.TabIndex = 4;
         this.buttonEdit.Text = "Edit";
         this.buttonEdit.UseVisualStyleBackColor = true;
         this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
         // 
         // buttonDelete
         // 
         this.buttonDelete.Location = new System.Drawing.Point(406, 88);
         this.buttonDelete.Name = "buttonDelete";
         this.buttonDelete.Size = new System.Drawing.Size(75, 23);
         this.buttonDelete.TabIndex = 3;
         this.buttonDelete.Text = "Delete";
         this.buttonDelete.UseVisualStyleBackColor = true;
         this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
         // 
         // buttonAdd
         // 
         this.buttonAdd.Location = new System.Drawing.Point(406, 30);
         this.buttonAdd.Name = "buttonAdd";
         this.buttonAdd.Size = new System.Drawing.Size(75, 23);
         this.buttonAdd.TabIndex = 2;
         this.buttonAdd.Text = "Add";
         this.buttonAdd.UseVisualStyleBackColor = true;
         this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
         // 
         // listViewApplications
         // 
         this.listViewApplications.CheckBoxes = true;
         this.listViewApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
         this.listViewApplications.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewApplications.HideSelection = false;
         this.listViewApplications.Location = new System.Drawing.Point(11, 30);
         this.listViewApplications.MultiSelect = false;
         this.listViewApplications.Name = "listViewApplications";
         this.listViewApplications.Size = new System.Drawing.Size(390, 318);
         this.listViewApplications.SmallImageList = this.imageListApplications;
         this.listViewApplications.TabIndex = 1;
         this.listViewApplications.UseCompatibleStateImageBehavior = false;
         this.listViewApplications.View = System.Windows.Forms.View.Details;
         this.listViewApplications.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewApplications_ItemChecked);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Name";
         this.columnHeader1.Width = 226;
         // 
         // imageListApplications
         // 
         this.imageListApplications.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListApplications.ImageStream")));
         this.imageListApplications.TransparentColor = System.Drawing.Color.Transparent;
         this.imageListApplications.Images.SetKeyName(0, "key.png");
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(8, 14);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(67, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Applications:";
         // 
         // tabPageSubjects
         // 
         this.tabPageSubjects.Controls.Add(this.buttonEditSubject);
         this.tabPageSubjects.Controls.Add(this.buttonDeleteSubject);
         this.tabPageSubjects.Controls.Add(this.buttonAddSubject);
         this.tabPageSubjects.Controls.Add(this.listViewSubjects);
         this.tabPageSubjects.Controls.Add(this.label2);
         this.tabPageSubjects.Location = new System.Drawing.Point(4, 22);
         this.tabPageSubjects.Name = "tabPageSubjects";
         this.tabPageSubjects.Size = new System.Drawing.Size(490, 354);
         this.tabPageSubjects.TabIndex = 2;
         this.tabPageSubjects.Text = "Subjects";
         this.tabPageSubjects.UseVisualStyleBackColor = true;
         // 
         // buttonEditSubject
         // 
         this.buttonEditSubject.Location = new System.Drawing.Point(406, 59);
         this.buttonEditSubject.Name = "buttonEditSubject";
         this.buttonEditSubject.Size = new System.Drawing.Size(75, 23);
         this.buttonEditSubject.TabIndex = 9;
         this.buttonEditSubject.Text = "Edit";
         this.buttonEditSubject.UseVisualStyleBackColor = true;
         this.buttonEditSubject.Click += new System.EventHandler(this.buttonEditSubject_Click);
         // 
         // buttonDeleteSubject
         // 
         this.buttonDeleteSubject.Location = new System.Drawing.Point(406, 88);
         this.buttonDeleteSubject.Name = "buttonDeleteSubject";
         this.buttonDeleteSubject.Size = new System.Drawing.Size(75, 23);
         this.buttonDeleteSubject.TabIndex = 8;
         this.buttonDeleteSubject.Text = "Delete";
         this.buttonDeleteSubject.UseVisualStyleBackColor = true;
         this.buttonDeleteSubject.Click += new System.EventHandler(this.buttonDeleteSubject_Click);
         // 
         // buttonAddSubject
         // 
         this.buttonAddSubject.Location = new System.Drawing.Point(406, 30);
         this.buttonAddSubject.Name = "buttonAddSubject";
         this.buttonAddSubject.Size = new System.Drawing.Size(75, 23);
         this.buttonAddSubject.TabIndex = 7;
         this.buttonAddSubject.Text = "Add";
         this.buttonAddSubject.UseVisualStyleBackColor = true;
         this.buttonAddSubject.Click += new System.EventHandler(this.buttonAddSubject_Click);
         // 
         // listViewSubjects
         // 
         this.listViewSubjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
         this.listViewSubjects.FullRowSelect = true;
         this.listViewSubjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewSubjects.HideSelection = false;
         this.listViewSubjects.Location = new System.Drawing.Point(11, 30);
         this.listViewSubjects.MultiSelect = false;
         this.listViewSubjects.Name = "listViewSubjects";
         this.listViewSubjects.Size = new System.Drawing.Size(390, 318);
         this.listViewSubjects.SmallImageList = this.imageListApplications;
         this.listViewSubjects.TabIndex = 6;
         this.listViewSubjects.UseCompatibleStateImageBehavior = false;
         this.listViewSubjects.View = System.Windows.Forms.View.Details;
         this.listViewSubjects.DoubleClick += new System.EventHandler(this.listViewSubjects_DoubleClick);
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Name";
         this.columnHeader2.Width = 226;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Security Type";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(8, 14);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(51, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "Subjects:";
         // 
         // tabPageAdvanced
         // 
         this.tabPageAdvanced.Controls.Add(this.PingInterval);
         this.tabPageAdvanced.Controls.Add(this.PingNotificationTimeout);
         this.tabPageAdvanced.Controls.Add(this.NotificationRetryInterval);
         this.tabPageAdvanced.Controls.Add(this.NotificationTimeout);
         this.tabPageAdvanced.Controls.Add(this.ActionTimeout);
         this.tabPageAdvanced.Controls.Add(this.TransactionTimeout);
         this.tabPageAdvanced.Controls.Add(this.MaxParticipants);
         this.tabPageAdvanced.Controls.Add(this.label6);
         this.tabPageAdvanced.Controls.Add(this.buttonApplyConfig);
         this.tabPageAdvanced.Controls.Add(this.checkBoxPing);
         this.tabPageAdvanced.Controls.Add(this.label10);
         this.tabPageAdvanced.Controls.Add(this.label9);
         this.tabPageAdvanced.Controls.Add(this.label8);
         this.tabPageAdvanced.Controls.Add(this.label7);
         this.tabPageAdvanced.Controls.Add(this.label5);
         this.tabPageAdvanced.Controls.Add(this.label4);
         this.tabPageAdvanced.Controls.Add(this.label3);
         this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
         this.tabPageAdvanced.Name = "tabPageAdvanced";
         this.tabPageAdvanced.Size = new System.Drawing.Size(490, 354);
         this.tabPageAdvanced.TabIndex = 3;
         this.tabPageAdvanced.Text = "Advanced";
         this.tabPageAdvanced.UseVisualStyleBackColor = true;
         // 
         // PingInterval
         // 
         this.PingInterval.Location = new System.Drawing.Point(248, 194);
         this.PingInterval.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
         this.PingInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.PingInterval.Name = "PingInterval";
         this.PingInterval.Size = new System.Drawing.Size(77, 20);
         this.PingInterval.TabIndex = 22;
         this.PingInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.PingInterval.ValueChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // PingNotificationTimeout
         // 
         this.PingNotificationTimeout.Location = new System.Drawing.Point(248, 168);
         this.PingNotificationTimeout.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
         this.PingNotificationTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.PingNotificationTimeout.Name = "PingNotificationTimeout";
         this.PingNotificationTimeout.Size = new System.Drawing.Size(77, 20);
         this.PingNotificationTimeout.TabIndex = 21;
         this.PingNotificationTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.PingNotificationTimeout.ValueChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // NotificationRetryInterval
         // 
         this.NotificationRetryInterval.Location = new System.Drawing.Point(184, 116);
         this.NotificationRetryInterval.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
         this.NotificationRetryInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.NotificationRetryInterval.Name = "NotificationRetryInterval";
         this.NotificationRetryInterval.Size = new System.Drawing.Size(141, 20);
         this.NotificationRetryInterval.TabIndex = 20;
         this.NotificationRetryInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.NotificationRetryInterval.ValueChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // NotificationTimeout
         // 
         this.NotificationTimeout.Location = new System.Drawing.Point(184, 90);
         this.NotificationTimeout.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
         this.NotificationTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.NotificationTimeout.Name = "NotificationTimeout";
         this.NotificationTimeout.Size = new System.Drawing.Size(141, 20);
         this.NotificationTimeout.TabIndex = 19;
         this.NotificationTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.NotificationTimeout.ValueChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // ActionTimeout
         // 
         this.ActionTimeout.Location = new System.Drawing.Point(184, 64);
         this.ActionTimeout.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
         this.ActionTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.ActionTimeout.Name = "ActionTimeout";
         this.ActionTimeout.Size = new System.Drawing.Size(141, 20);
         this.ActionTimeout.TabIndex = 18;
         this.ActionTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.ActionTimeout.ValueChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // TransactionTimeout
         // 
         this.TransactionTimeout.Location = new System.Drawing.Point(184, 38);
         this.TransactionTimeout.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
         this.TransactionTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.TransactionTimeout.Name = "TransactionTimeout";
         this.TransactionTimeout.Size = new System.Drawing.Size(141, 20);
         this.TransactionTimeout.TabIndex = 17;
         this.TransactionTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.TransactionTimeout.ValueChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // MaxParticipants
         // 
         this.MaxParticipants.Location = new System.Drawing.Point(184, 12);
         this.MaxParticipants.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
         this.MaxParticipants.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
         this.MaxParticipants.Name = "MaxParticipants";
         this.MaxParticipants.Size = new System.Drawing.Size(141, 20);
         this.MaxParticipants.TabIndex = 16;
         this.MaxParticipants.ValueChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(197, 170);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(48, 13);
         this.label6.TabIndex = 15;
         this.label6.Text = "Timeout:";
         // 
         // buttonApplyConfig
         // 
         this.buttonApplyConfig.Location = new System.Drawing.Point(184, 246);
         this.buttonApplyConfig.Name = "buttonApplyConfig";
         this.buttonApplyConfig.Size = new System.Drawing.Size(75, 23);
         this.buttonApplyConfig.TabIndex = 8;
         this.buttonApplyConfig.Text = "Apply";
         this.buttonApplyConfig.UseVisualStyleBackColor = true;
         this.buttonApplyConfig.Click += new System.EventHandler(this.buttonApplyConfig_Click);
         // 
         // checkBoxPing
         // 
         this.checkBoxPing.AutoSize = true;
         this.checkBoxPing.Location = new System.Drawing.Point(184, 143);
         this.checkBoxPing.Name = "checkBoxPing";
         this.checkBoxPing.Size = new System.Drawing.Size(15, 14);
         this.checkBoxPing.TabIndex = 7;
         this.checkBoxPing.UseVisualStyleBackColor = true;
         this.checkBoxPing.CheckedChanged += new System.EventHandler(this.ConfigChanged);
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(8, 144);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(67, 13);
         this.label10.TabIndex = 14;
         this.label10.Text = "Enable Ping:";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(8, 118);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(129, 13);
         this.label9.TabIndex = 12;
         this.label9.Text = "Notification Retry Interval:";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(8, 92);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(104, 13);
         this.label8.TabIndex = 10;
         this.label8.Text = "Notification Timeout:";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(8, 66);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(81, 13);
         this.label7.TabIndex = 8;
         this.label7.Text = "Action Timeout:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(8, 40);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(107, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Transaction Timeout:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(8, 14);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(88, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = "Max Participants:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(197, 196);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(45, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Interval:";
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.groupBoxWeb);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(490, 354);
         this.tabPage1.TabIndex = 4;
         this.tabPage1.Text = "Web";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // groupBoxWeb
         // 
         this.groupBoxWeb.Controls.Add(this.labelCcowWebNote);
         this.groupBoxWeb.Controls.Add(this.webAdress);
         this.groupBoxWeb.Controls.Add(this.label11);
         this.groupBoxWeb.Location = new System.Drawing.Point(8, 16);
         this.groupBoxWeb.Name = "groupBoxWeb";
         this.groupBoxWeb.Size = new System.Drawing.Size(473, 101);
         this.groupBoxWeb.TabIndex = 0;
         this.groupBoxWeb.TabStop = false;
         // 
         // labelCcowWebNote
         // 
         this.labelCcowWebNote.AutoSize = true;
         this.labelCcowWebNote.ForeColor = System.Drawing.Color.Crimson;
         this.labelCcowWebNote.Location = new System.Drawing.Point(10, 82);
         this.labelCcowWebNote.Name = "labelCcowWebNote";
         this.labelCcowWebNote.Size = new System.Drawing.Size(294, 13);
         this.labelCcowWebNote.TabIndex = 2;
         this.labelCcowWebNote.Text = "Run CCOW Server as Administrator to enable Web Services.";
         // 
         // webAdress
         // 
         this.webAdress.Location = new System.Drawing.Point(10, 37);
         this.webAdress.Name = "webAdress";
         this.webAdress.ReadOnly = true;
         this.webAdress.Size = new System.Drawing.Size(457, 20);
         this.webAdress.TabIndex = 1;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(7, 20);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(48, 13);
         this.label11.TabIndex = 0;
         this.label11.Text = "Address:";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.buttonOK);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 380);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(498, 42);
         this.panel1.TabIndex = 1;
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(410, 7);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 0;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // ConfigurationDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(498, 422);
         this.Controls.Add(this.tabControlConfiguration);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ConfigurationDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "ConfigurationDialog";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationDialog_FormClosing);
         this.Load += new System.EventHandler(this.ConfigurationDialog_Load);
         this.tabControlConfiguration.ResumeLayout(false);
         this.tabPageApplications.ResumeLayout(false);
         this.tabPageApplications.PerformLayout();
         this.tabPageSubjects.ResumeLayout(false);
         this.tabPageSubjects.PerformLayout();
         this.tabPageAdvanced.ResumeLayout(false);
         this.tabPageAdvanced.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.PingInterval)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.PingNotificationTimeout)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.NotificationRetryInterval)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.NotificationTimeout)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ActionTimeout)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.TransactionTimeout)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.MaxParticipants)).EndInit();
         this.tabPage1.ResumeLayout(false);
         this.groupBoxWeb.ResumeLayout(false);
         this.groupBoxWeb.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlConfiguration;
        private System.Windows.Forms.TabPage tabPageApplications;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPageSubjects;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.ListView listViewApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageListApplications;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonEditSubject;
        private System.Windows.Forms.Button buttonDeleteSubject;
        private System.Windows.Forms.Button buttonAddSubject;
        private System.Windows.Forms.ListView listViewSubjects;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxPing;
        private System.Windows.Forms.Button buttonAllowAll;
        public System.Windows.Forms.Button buttonAllowNone;
        private System.Windows.Forms.Button buttonApplyConfig;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.NumericUpDown PingInterval;
        private System.Windows.Forms.NumericUpDown PingNotificationTimeout;
        private System.Windows.Forms.NumericUpDown NotificationRetryInterval;
        private System.Windows.Forms.NumericUpDown NotificationTimeout;
        private System.Windows.Forms.NumericUpDown ActionTimeout;
        private System.Windows.Forms.NumericUpDown TransactionTimeout;
        private System.Windows.Forms.NumericUpDown MaxParticipants;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxWeb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox webAdress;
        private System.Windows.Forms.Label labelCcowWebNote;
    }
}