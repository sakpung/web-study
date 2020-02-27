namespace Leadtools.Medical.Winforms.ExternalStore
{
   partial class ExternalStoreConfigurationView
   {
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalStoreConfigurationView));
         this.tabControlExternalStore = new System.Windows.Forms.TabControl();
         this.tabPageExternalStoreConfiguration = new System.Windows.Forms.TabPage();
         this.groupBoxConfiguration = new System.Windows.Forms.GroupBox();
         this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.tabPageOptions = new System.Windows.Forms.TabPage();
         this.checkBoxVerify = new System.Windows.Forms.CheckBox();
         this.numericUpDownHoldAmount = new System.Windows.Forms.NumericUpDown();
         this.groupBoxClean = new System.Windows.Forms.GroupBox();
         this.schedulerControlClean = new Leadtools.Medical.Winforms.Forwarder.Controls.SchedulerControl();
         this.checkBoxCleanEnable = new System.Windows.Forms.CheckBox();
         this.comboBoxHoldInterval = new System.Windows.Forms.ComboBox();
         this.labelHoldTime = new System.Windows.Forms.Label();
         this.groupBoxExternalStore = new System.Windows.Forms.GroupBox();
         this.schedulerControlExternalStore = new Leadtools.Medical.Winforms.Forwarder.Controls.SchedulerControl();
         this.checkBoxExternalStoreEnable = new System.Windows.Forms.CheckBox();
         this.tabPageAdvanced = new System.Windows.Forms.TabPage();
         this.panelWarning = new System.Windows.Forms.Panel();
         this.label5 = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.groupBoxTools = new System.Windows.Forms.GroupBox();
         this.label6 = new System.Windows.Forms.Label();
         this.numericUpDownDaysToExpire = new System.Windows.Forms.NumericUpDown();
         this.buttonCancelExternalStore = new System.Windows.Forms.Button();
         this.buttonCancelRestore = new System.Windows.Forms.Button();
         this.labelRestoreEndDate = new System.Windows.Forms.Label();
         this.labelStartDate = new System.Windows.Forms.Label();
         this.labelRestoreStartDate = new System.Windows.Forms.Label();
         this.dateTimePickerRestoreEnd = new System.Windows.Forms.DateTimePicker();
         this.label3 = new System.Windows.Forms.Label();
         this.dateTimePickerRestoreStart = new System.Windows.Forms.DateTimePicker();
         this.comboBoxRestore = new System.Windows.Forms.ComboBox();
         this.labelEndDate = new System.Windows.Forms.Label();
         this.labelResetInfo = new System.Windows.Forms.Label();
         this.labelRestoreInfo = new System.Windows.Forms.Label();
         this.dateTimePickerResetEnd = new System.Windows.Forms.DateTimePicker();
         this.buttonRestoreLocalStore = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.labelClearInfo = new System.Windows.Forms.Label();
         this.dateTimePickerResetStart = new System.Windows.Forms.DateTimePicker();
         this.buttonReset = new System.Windows.Forms.Button();
         this.comboBoxReset = new System.Windows.Forms.ComboBox();
         this.labelExternalStoreInfo = new System.Windows.Forms.Label();
         this.buttonCleanLocal = new System.Windows.Forms.Button();
         this.buttonExternalStore = new System.Windows.Forms.Button();
         this.colorDialog1 = new System.Windows.Forms.ColorDialog();
         this.labelError = new System.Windows.Forms.Label();
         this.comboBoxStoreTo = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.buttonVerify = new System.Windows.Forms.Button();
         this.tabControlExternalStore.SuspendLayout();
         this.tabPageExternalStoreConfiguration.SuspendLayout();
         this.groupBoxConfiguration.SuspendLayout();
         this.tabPageOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoldAmount)).BeginInit();
         this.groupBoxClean.SuspendLayout();
         this.groupBoxExternalStore.SuspendLayout();
         this.tabPageAdvanced.SuspendLayout();
         this.panelWarning.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.groupBoxTools.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysToExpire)).BeginInit();
         this.SuspendLayout();
         // 
         // tabControlExternalStore
         // 
         this.tabControlExternalStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControlExternalStore.Controls.Add(this.tabPageExternalStoreConfiguration);
         this.tabControlExternalStore.Controls.Add(this.tabPageOptions);
         this.tabControlExternalStore.Controls.Add(this.tabPageAdvanced);
         this.tabControlExternalStore.Location = new System.Drawing.Point(3, 64);
         this.tabControlExternalStore.Name = "tabControlExternalStore";
         this.tabControlExternalStore.SelectedIndex = 0;
         this.tabControlExternalStore.Size = new System.Drawing.Size(640, 341);
         this.tabControlExternalStore.TabIndex = 4;
         // 
         // tabPageExternalStoreConfiguration
         // 
         this.tabPageExternalStoreConfiguration.Controls.Add(this.groupBoxConfiguration);
         this.tabPageExternalStoreConfiguration.Location = new System.Drawing.Point(4, 22);
         this.tabPageExternalStoreConfiguration.Name = "tabPageExternalStoreConfiguration";
         this.tabPageExternalStoreConfiguration.Size = new System.Drawing.Size(632, 315);
         this.tabPageExternalStoreConfiguration.TabIndex = 2;
         this.tabPageExternalStoreConfiguration.Text = "Configuration";
         this.tabPageExternalStoreConfiguration.UseVisualStyleBackColor = true;
         // 
         // groupBoxConfiguration
         // 
         this.groupBoxConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxConfiguration.Controls.Add(this.flowLayoutPanel);
         this.groupBoxConfiguration.Location = new System.Drawing.Point(3, 13);
         this.groupBoxConfiguration.Name = "groupBoxConfiguration";
         this.groupBoxConfiguration.Size = new System.Drawing.Size(626, 299);
         this.groupBoxConfiguration.TabIndex = 7;
         this.groupBoxConfiguration.TabStop = false;
         this.groupBoxConfiguration.Text = "Configuration Settings";
         // 
         // flowLayoutPanel
         // 
         this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.flowLayoutPanel.AutoScroll = true;
         this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.flowLayoutPanel.Location = new System.Drawing.Point(13, 19);
         this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
         this.flowLayoutPanel.Name = "flowLayoutPanel";
         this.flowLayoutPanel.Size = new System.Drawing.Size(597, 274);
         this.flowLayoutPanel.TabIndex = 8;
         this.flowLayoutPanel.WrapContents = false;
         // 
         // tabPageOptions
         // 
         this.tabPageOptions.Controls.Add(this.checkBoxVerify);
         this.tabPageOptions.Controls.Add(this.numericUpDownHoldAmount);
         this.tabPageOptions.Controls.Add(this.groupBoxClean);
         this.tabPageOptions.Controls.Add(this.comboBoxHoldInterval);
         this.tabPageOptions.Controls.Add(this.labelHoldTime);
         this.tabPageOptions.Controls.Add(this.groupBoxExternalStore);
         this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
         this.tabPageOptions.Name = "tabPageOptions";
         this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageOptions.Size = new System.Drawing.Size(632, 315);
         this.tabPageOptions.TabIndex = 0;
         this.tabPageOptions.Text = "Schedule";
         this.tabPageOptions.UseVisualStyleBackColor = true;
         // 
         // checkBoxVerify
         // 
         this.checkBoxVerify.AutoSize = true;
         this.checkBoxVerify.Location = new System.Drawing.Point(17, 189);
         this.checkBoxVerify.Name = "checkBoxVerify";
         this.checkBoxVerify.Size = new System.Drawing.Size(191, 17);
         this.checkBoxVerify.TabIndex = 6;
         this.checkBoxVerify.Text = "Verify (Retrieve after external store)";
         this.checkBoxVerify.UseVisualStyleBackColor = true;
         // 
         // numericUpDownHoldAmount
         // 
         this.numericUpDownHoldAmount.Location = new System.Drawing.Point(377, 183);
         this.numericUpDownHoldAmount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.numericUpDownHoldAmount.Name = "numericUpDownHoldAmount";
         this.numericUpDownHoldAmount.Size = new System.Drawing.Size(61, 20);
         this.numericUpDownHoldAmount.TabIndex = 3;
         // 
         // groupBoxClean
         // 
         this.groupBoxClean.Controls.Add(this.schedulerControlClean);
         this.groupBoxClean.Controls.Add(this.checkBoxCleanEnable);
         this.groupBoxClean.Location = new System.Drawing.Point(317, 11);
         this.groupBoxClean.Name = "groupBoxClean";
         this.groupBoxClean.Size = new System.Drawing.Size(301, 160);
         this.groupBoxClean.TabIndex = 1;
         this.groupBoxClean.TabStop = false;
         this.groupBoxClean.Text = "     Clear Local";
         // 
         // schedulerControlClean
         // 
         this.schedulerControlClean.Dock = System.Windows.Forms.DockStyle.Fill;
         this.schedulerControlClean.Location = new System.Drawing.Point(3, 16);
         this.schedulerControlClean.Name = "schedulerControlClean";
         this.schedulerControlClean.RepeatEvery = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.schedulerControlClean.RepeatInterval = Leadtools.Medical.Winforms.Forwarder.Controls.IntervalType.Days;
         this.schedulerControlClean.Size = new System.Drawing.Size(295, 141);
         this.schedulerControlClean.TabIndex = 1;
         // 
         // checkBoxCleanEnable
         // 
         this.checkBoxCleanEnable.AutoSize = true;
         this.checkBoxCleanEnable.Location = new System.Drawing.Point(6, 1);
         this.checkBoxCleanEnable.Name = "checkBoxCleanEnable";
         this.checkBoxCleanEnable.Size = new System.Drawing.Size(15, 14);
         this.checkBoxCleanEnable.TabIndex = 0;
         this.checkBoxCleanEnable.UseVisualStyleBackColor = true;
         // 
         // comboBoxHoldInterval
         // 
         this.comboBoxHoldInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxHoldInterval.FormattingEnabled = true;
         this.comboBoxHoldInterval.Location = new System.Drawing.Point(444, 182);
         this.comboBoxHoldInterval.Name = "comboBoxHoldInterval";
         this.comboBoxHoldInterval.Size = new System.Drawing.Size(97, 21);
         this.comboBoxHoldInterval.TabIndex = 4;
         // 
         // labelHoldTime
         // 
         this.labelHoldTime.AutoSize = true;
         this.labelHoldTime.Location = new System.Drawing.Point(314, 190);
         this.labelHoldTime.Name = "labelHoldTime";
         this.labelHoldTime.Size = new System.Drawing.Size(58, 13);
         this.labelHoldTime.TabIndex = 2;
         this.labelHoldTime.Text = "Hold Time:";
         // 
         // groupBoxExternalStore
         // 
         this.groupBoxExternalStore.Controls.Add(this.schedulerControlExternalStore);
         this.groupBoxExternalStore.Controls.Add(this.checkBoxExternalStoreEnable);
         this.groupBoxExternalStore.Location = new System.Drawing.Point(11, 11);
         this.groupBoxExternalStore.Name = "groupBoxExternalStore";
         this.groupBoxExternalStore.Size = new System.Drawing.Size(297, 160);
         this.groupBoxExternalStore.TabIndex = 0;
         this.groupBoxExternalStore.TabStop = false;
         this.groupBoxExternalStore.Text = "     External Store";
         // 
         // schedulerControlExternalStore
         // 
         this.schedulerControlExternalStore.Dock = System.Windows.Forms.DockStyle.Fill;
         this.schedulerControlExternalStore.Location = new System.Drawing.Point(3, 16);
         this.schedulerControlExternalStore.Name = "schedulerControlExternalStore";
         this.schedulerControlExternalStore.RepeatEvery = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.schedulerControlExternalStore.RepeatInterval = Leadtools.Medical.Winforms.Forwarder.Controls.IntervalType.Days;
         this.schedulerControlExternalStore.Size = new System.Drawing.Size(291, 141);
         this.schedulerControlExternalStore.TabIndex = 1;
         // 
         // checkBoxExternalStoreEnable
         // 
         this.checkBoxExternalStoreEnable.AutoSize = true;
         this.checkBoxExternalStoreEnable.Location = new System.Drawing.Point(6, 0);
         this.checkBoxExternalStoreEnable.Name = "checkBoxExternalStoreEnable";
         this.checkBoxExternalStoreEnable.Size = new System.Drawing.Size(15, 14);
         this.checkBoxExternalStoreEnable.TabIndex = 0;
         this.checkBoxExternalStoreEnable.UseVisualStyleBackColor = true;
         // 
         // tabPageAdvanced
         // 
         this.tabPageAdvanced.Controls.Add(this.panelWarning);
         this.tabPageAdvanced.Controls.Add(this.groupBoxTools);
         this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
         this.tabPageAdvanced.Name = "tabPageAdvanced";
         this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAdvanced.Size = new System.Drawing.Size(632, 315);
         this.tabPageAdvanced.TabIndex = 1;
         this.tabPageAdvanced.Text = "Tools";
         this.tabPageAdvanced.UseVisualStyleBackColor = true;
         // 
         // panelWarning
         // 
         this.panelWarning.Controls.Add(this.label5);
         this.panelWarning.Controls.Add(this.pictureBox1);
         this.panelWarning.Location = new System.Drawing.Point(11, 272);
         this.panelWarning.Name = "panelWarning";
         this.panelWarning.Size = new System.Drawing.Size(576, 33);
         this.panelWarning.TabIndex = 1;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.ForeColor = System.Drawing.Color.Red;
         this.label5.Location = new System.Drawing.Point(28, 16);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(230, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Server must be running to enable tools.";
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
         this.pictureBox1.Location = new System.Drawing.Point(4, 4);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(21, 26);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         // 
         // groupBoxTools
         // 
         this.groupBoxTools.Controls.Add(this.label6);
         this.groupBoxTools.Controls.Add(this.numericUpDownDaysToExpire);
         this.groupBoxTools.Controls.Add(this.buttonCancelExternalStore);
         this.groupBoxTools.Controls.Add(this.buttonCancelRestore);
         this.groupBoxTools.Controls.Add(this.labelRestoreEndDate);
         this.groupBoxTools.Controls.Add(this.labelStartDate);
         this.groupBoxTools.Controls.Add(this.labelRestoreStartDate);
         this.groupBoxTools.Controls.Add(this.dateTimePickerRestoreEnd);
         this.groupBoxTools.Controls.Add(this.label3);
         this.groupBoxTools.Controls.Add(this.dateTimePickerRestoreStart);
         this.groupBoxTools.Controls.Add(this.comboBoxRestore);
         this.groupBoxTools.Controls.Add(this.labelEndDate);
         this.groupBoxTools.Controls.Add(this.labelResetInfo);
         this.groupBoxTools.Controls.Add(this.labelRestoreInfo);
         this.groupBoxTools.Controls.Add(this.dateTimePickerResetEnd);
         this.groupBoxTools.Controls.Add(this.buttonRestoreLocalStore);
         this.groupBoxTools.Controls.Add(this.label4);
         this.groupBoxTools.Controls.Add(this.labelClearInfo);
         this.groupBoxTools.Controls.Add(this.dateTimePickerResetStart);
         this.groupBoxTools.Controls.Add(this.buttonReset);
         this.groupBoxTools.Controls.Add(this.comboBoxReset);
         this.groupBoxTools.Controls.Add(this.labelExternalStoreInfo);
         this.groupBoxTools.Controls.Add(this.buttonCleanLocal);
         this.groupBoxTools.Controls.Add(this.buttonExternalStore);
         this.groupBoxTools.Location = new System.Drawing.Point(11, 6);
         this.groupBoxTools.Name = "groupBoxTools";
         this.groupBoxTools.Size = new System.Drawing.Size(576, 260);
         this.groupBoxTools.TabIndex = 0;
         this.groupBoxTools.TabStop = false;
         this.groupBoxTools.Text = "Tools";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(197, 83);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(75, 13);
         this.label6.TabIndex = 5;
         this.label6.Text = "Days to Expire";
         // 
         // numericUpDownDaysToExpire
         // 
         this.numericUpDownDaysToExpire.Location = new System.Drawing.Point(278, 81);
         this.numericUpDownDaysToExpire.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.numericUpDownDaysToExpire.Name = "numericUpDownDaysToExpire";
         this.numericUpDownDaysToExpire.Size = new System.Drawing.Size(89, 20);
         this.numericUpDownDaysToExpire.TabIndex = 6;
         // 
         // buttonCancelExternalStore
         // 
         this.buttonCancelExternalStore.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Remove;
         this.buttonCancelExternalStore.Location = new System.Drawing.Point(163, 19);
         this.buttonCancelExternalStore.Name = "buttonCancelExternalStore";
         this.buttonCancelExternalStore.Size = new System.Drawing.Size(25, 23);
         this.buttonCancelExternalStore.TabIndex = 1;
         this.buttonCancelExternalStore.UseVisualStyleBackColor = true;
         this.buttonCancelExternalStore.Click += new System.EventHandler(this.buttonCancelExternalStore_Click);
         // 
         // buttonCancelRestore
         // 
         this.buttonCancelRestore.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Remove;
         this.buttonCancelRestore.Location = new System.Drawing.Point(163, 124);
         this.buttonCancelRestore.Name = "buttonCancelRestore";
         this.buttonCancelRestore.Size = new System.Drawing.Size(25, 23);
         this.buttonCancelRestore.TabIndex = 8;
         this.buttonCancelRestore.UseVisualStyleBackColor = true;
         this.buttonCancelRestore.Click += new System.EventHandler(this.buttonCancelRestore_Click);
         // 
         // labelRestoreEndDate
         // 
         this.labelRestoreEndDate.AutoSize = true;
         this.labelRestoreEndDate.Location = new System.Drawing.Point(451, 176);
         this.labelRestoreEndDate.Name = "labelRestoreEndDate";
         this.labelRestoreEndDate.Size = new System.Drawing.Size(108, 13);
         this.labelRestoreEndDate.TabIndex = 15;
         this.labelRestoreEndDate.Text = "labelRestoreEndDate";
         // 
         // labelStartDate
         // 
         this.labelStartDate.AutoSize = true;
         this.labelStartDate.Location = new System.Drawing.Point(324, 237);
         this.labelStartDate.Name = "labelStartDate";
         this.labelStartDate.Size = new System.Drawing.Size(74, 13);
         this.labelStartDate.TabIndex = 22;
         this.labelStartDate.Text = "labelStartDate";
         // 
         // labelRestoreStartDate
         // 
         this.labelRestoreStartDate.AutoSize = true;
         this.labelRestoreStartDate.Location = new System.Drawing.Point(324, 176);
         this.labelRestoreStartDate.Name = "labelRestoreStartDate";
         this.labelRestoreStartDate.Size = new System.Drawing.Size(111, 13);
         this.labelRestoreStartDate.TabIndex = 14;
         this.labelRestoreStartDate.Text = "labelRestoreStartDate";
         // 
         // dateTimePickerRestoreEnd
         // 
         this.dateTimePickerRestoreEnd.Checked = false;
         this.dateTimePickerRestoreEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerRestoreEnd.Location = new System.Drawing.Point(451, 149);
         this.dateTimePickerRestoreEnd.Name = "dateTimePickerRestoreEnd";
         this.dateTimePickerRestoreEnd.ShowCheckBox = true;
         this.dateTimePickerRestoreEnd.Size = new System.Drawing.Size(112, 20);
         this.dateTimePickerRestoreEnd.TabIndex = 13;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(429, 153);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(16, 13);
         this.label3.TabIndex = 12;
         this.label3.Text = "to";
         // 
         // dateTimePickerRestoreStart
         // 
         this.dateTimePickerRestoreStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerRestoreStart.Location = new System.Drawing.Point(324, 149);
         this.dateTimePickerRestoreStart.Name = "dateTimePickerRestoreStart";
         this.dateTimePickerRestoreStart.Size = new System.Drawing.Size(98, 20);
         this.dateTimePickerRestoreStart.TabIndex = 11;
         // 
         // comboBoxRestore
         // 
         this.comboBoxRestore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxRestore.FormattingEnabled = true;
         this.comboBoxRestore.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "This Week",
            "Last Week",
            "Date",
            "Date Range"});
         this.comboBoxRestore.Location = new System.Drawing.Point(197, 149);
         this.comboBoxRestore.Name = "comboBoxRestore";
         this.comboBoxRestore.Size = new System.Drawing.Size(121, 21);
         this.comboBoxRestore.TabIndex = 10;
         // 
         // labelEndDate
         // 
         this.labelEndDate.AutoSize = true;
         this.labelEndDate.Location = new System.Drawing.Point(451, 237);
         this.labelEndDate.Name = "labelEndDate";
         this.labelEndDate.Size = new System.Drawing.Size(71, 13);
         this.labelEndDate.TabIndex = 23;
         this.labelEndDate.Text = "labelEndDate";
         // 
         // labelResetInfo
         // 
         this.labelResetInfo.AutoSize = true;
         this.labelResetInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelResetInfo.Location = new System.Drawing.Point(194, 193);
         this.labelResetInfo.Name = "labelResetInfo";
         this.labelResetInfo.Size = new System.Drawing.Size(138, 13);
         this.labelResetInfo.TabIndex = 17;
         this.labelResetInfo.Text = "0 datasets will be reset";
         // 
         // labelRestoreInfo
         // 
         this.labelRestoreInfo.AutoSize = true;
         this.labelRestoreInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelRestoreInfo.Location = new System.Drawing.Point(194, 129);
         this.labelRestoreInfo.Name = "labelRestoreInfo";
         this.labelRestoreInfo.Size = new System.Drawing.Size(124, 13);
         this.labelRestoreInfo.TabIndex = 9;
         this.labelRestoreInfo.Text = "0 datasets to restore";
         // 
         // dateTimePickerResetEnd
         // 
         this.dateTimePickerResetEnd.Checked = false;
         this.dateTimePickerResetEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerResetEnd.Location = new System.Drawing.Point(451, 210);
         this.dateTimePickerResetEnd.Name = "dateTimePickerResetEnd";
         this.dateTimePickerResetEnd.ShowCheckBox = true;
         this.dateTimePickerResetEnd.Size = new System.Drawing.Size(112, 20);
         this.dateTimePickerResetEnd.TabIndex = 21;
         // 
         // buttonRestoreLocalStore
         // 
         this.buttonRestoreLocalStore.Location = new System.Drawing.Point(21, 124);
         this.buttonRestoreLocalStore.Name = "buttonRestoreLocalStore";
         this.buttonRestoreLocalStore.Size = new System.Drawing.Size(139, 23);
         this.buttonRestoreLocalStore.TabIndex = 7;
         this.buttonRestoreLocalStore.Text = "Restore Local Store";
         this.buttonRestoreLocalStore.UseVisualStyleBackColor = true;
         this.buttonRestoreLocalStore.Click += new System.EventHandler(this.buttonRestoreLocalStore_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(429, 216);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(16, 13);
         this.label4.TabIndex = 20;
         this.label4.Text = "to";
         // 
         // labelClearInfo
         // 
         this.labelClearInfo.AutoSize = true;
         this.labelClearInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelClearInfo.Location = new System.Drawing.Point(194, 61);
         this.labelClearInfo.Name = "labelClearInfo";
         this.labelClearInfo.Size = new System.Drawing.Size(144, 13);
         this.labelClearInfo.TabIndex = 4;
         this.labelClearInfo.Text = "0 local datasets to clear";
         // 
         // dateTimePickerResetStart
         // 
         this.dateTimePickerResetStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerResetStart.Location = new System.Drawing.Point(324, 210);
         this.dateTimePickerResetStart.Name = "dateTimePickerResetStart";
         this.dateTimePickerResetStart.Size = new System.Drawing.Size(98, 20);
         this.dateTimePickerResetStart.TabIndex = 19;
         // 
         // buttonReset
         // 
         this.buttonReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.buttonReset.Location = new System.Drawing.Point(21, 188);
         this.buttonReset.Name = "buttonReset";
         this.buttonReset.Size = new System.Drawing.Size(139, 23);
         this.buttonReset.TabIndex = 16;
         this.buttonReset.Text = "Reset External Store";
         this.buttonReset.UseVisualStyleBackColor = true;
         this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
         // 
         // comboBoxReset
         // 
         this.comboBoxReset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxReset.FormattingEnabled = true;
         this.comboBoxReset.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "This Week",
            "Last Week",
            "Date",
            "Date Range"});
         this.comboBoxReset.Location = new System.Drawing.Point(197, 209);
         this.comboBoxReset.Name = "comboBoxReset";
         this.comboBoxReset.Size = new System.Drawing.Size(121, 21);
         this.comboBoxReset.TabIndex = 18;
         // 
         // labelExternalStoreInfo
         // 
         this.labelExternalStoreInfo.AutoSize = true;
         this.labelExternalStoreInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelExternalStoreInfo.Location = new System.Drawing.Point(194, 24);
         this.labelExternalStoreInfo.Name = "labelExternalStoreInfo";
         this.labelExternalStoreInfo.Size = new System.Drawing.Size(113, 13);
         this.labelExternalStoreInfo.TabIndex = 2;
         this.labelExternalStoreInfo.Text = "0 datasets to store";
         // 
         // buttonCleanLocal
         // 
         this.buttonCleanLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.buttonCleanLocal.Location = new System.Drawing.Point(21, 56);
         this.buttonCleanLocal.Name = "buttonCleanLocal";
         this.buttonCleanLocal.Size = new System.Drawing.Size(139, 23);
         this.buttonCleanLocal.TabIndex = 3;
         this.buttonCleanLocal.Text = "Clear Local Store";
         this.buttonCleanLocal.UseVisualStyleBackColor = true;
         this.buttonCleanLocal.Click += new System.EventHandler(this.buttonClean_Click);
         // 
         // buttonExternalStore
         // 
         this.buttonExternalStore.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
         this.buttonExternalStore.Location = new System.Drawing.Point(21, 19);
         this.buttonExternalStore.Name = "buttonExternalStore";
         this.buttonExternalStore.Size = new System.Drawing.Size(139, 23);
         this.buttonExternalStore.TabIndex = 0;
         this.buttonExternalStore.Text = "Send to External Store";
         this.buttonExternalStore.UseVisualStyleBackColor = true;
         this.buttonExternalStore.Click += new System.EventHandler(this.buttonExternalStore_Click);
         // 
         // labelError
         // 
         this.labelError.AutoSize = true;
         this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelError.ForeColor = System.Drawing.Color.Red;
         this.labelError.Location = new System.Drawing.Point(310, 28);
         this.labelError.Name = "labelError";
         this.labelError.Size = new System.Drawing.Size(216, 13);
         this.labelError.TabIndex = 3;
         this.labelError.Text = "No \'External Store\' addins detected!";
         // 
         // comboBoxStoreTo
         // 
         this.comboBoxStoreTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxStoreTo.FormattingEnabled = true;
         this.comboBoxStoreTo.Location = new System.Drawing.Point(7, 25);
         this.comboBoxStoreTo.Name = "comboBoxStoreTo";
         this.comboBoxStoreTo.Size = new System.Drawing.Size(281, 21);
         this.comboBoxStoreTo.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(4, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(73, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "External Store";
         // 
         // buttonVerify
         // 
         this.buttonVerify.Location = new System.Drawing.Point(313, 23);
         this.buttonVerify.Name = "buttonVerify";
         this.buttonVerify.Size = new System.Drawing.Size(65, 23);
         this.buttonVerify.TabIndex = 2;
         this.buttonVerify.Text = "Verify";
         this.buttonVerify.UseVisualStyleBackColor = true;
         this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
         // 
         // ExternalStoreConfigurationView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.buttonVerify);
         this.Controls.Add(this.labelError);
         this.Controls.Add(this.comboBoxStoreTo);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.tabControlExternalStore);
         this.Name = "ExternalStoreConfigurationView";
         this.Size = new System.Drawing.Size(646, 408);
         this.tabControlExternalStore.ResumeLayout(false);
         this.tabPageExternalStoreConfiguration.ResumeLayout(false);
         this.groupBoxConfiguration.ResumeLayout(false);
         this.tabPageOptions.ResumeLayout(false);
         this.tabPageOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoldAmount)).EndInit();
         this.groupBoxClean.ResumeLayout(false);
         this.groupBoxClean.PerformLayout();
         this.groupBoxExternalStore.ResumeLayout(false);
         this.groupBoxExternalStore.PerformLayout();
         this.tabPageAdvanced.ResumeLayout(false);
         this.panelWarning.ResumeLayout(false);
         this.panelWarning.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.groupBoxTools.ResumeLayout(false);
         this.groupBoxTools.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysToExpire)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TabControl tabControlExternalStore;
      private System.Windows.Forms.TabPage tabPageExternalStoreConfiguration;
      private System.Windows.Forms.TabPage tabPageOptions;
      private System.Windows.Forms.NumericUpDown numericUpDownHoldAmount;
      private System.Windows.Forms.GroupBox groupBoxClean;
      private Forwarder.Controls.SchedulerControl schedulerControlClean;
      private System.Windows.Forms.CheckBox checkBoxCleanEnable;
      private System.Windows.Forms.ComboBox comboBoxHoldInterval;
      private System.Windows.Forms.Label labelHoldTime;
      private System.Windows.Forms.GroupBox groupBoxExternalStore;
      private Forwarder.Controls.SchedulerControl schedulerControlExternalStore;
      private System.Windows.Forms.CheckBox checkBoxExternalStoreEnable;
      private System.Windows.Forms.TabPage tabPageAdvanced;
      private System.Windows.Forms.Panel panelWarning;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.GroupBox groupBoxTools;
      private System.Windows.Forms.Label labelClearInfo;
      private System.Windows.Forms.Label labelExternalStoreInfo;
      private System.Windows.Forms.Button buttonCleanLocal;
      private System.Windows.Forms.Button buttonExternalStore;
      private System.Windows.Forms.GroupBox groupBoxConfiguration;
      private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
      private System.Windows.Forms.ColorDialog colorDialog1;
      private System.Windows.Forms.Label labelError;
      private System.Windows.Forms.ComboBox comboBoxStoreTo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button buttonRestoreLocalStore;
      private System.Windows.Forms.Label labelRestoreInfo;
      private System.Windows.Forms.Button buttonVerify;
      private System.Windows.Forms.DateTimePicker dateTimePickerRestoreEnd;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.DateTimePicker dateTimePickerRestoreStart;
      private System.Windows.Forms.ComboBox comboBoxRestore;
      private System.Windows.Forms.Label labelRestoreStartDate;
      private System.Windows.Forms.Label labelRestoreEndDate;
      private System.Windows.Forms.Label labelStartDate;
      private System.Windows.Forms.Label labelEndDate;
      private System.Windows.Forms.Label labelResetInfo;
      private System.Windows.Forms.DateTimePicker dateTimePickerResetEnd;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.DateTimePicker dateTimePickerResetStart;
      private System.Windows.Forms.Button buttonReset;
      private System.Windows.Forms.ComboBox comboBoxReset;
      private System.Windows.Forms.Button buttonCancelRestore;
      private System.Windows.Forms.Button buttonCancelExternalStore;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.NumericUpDown numericUpDownDaysToExpire;
      private System.Windows.Forms.CheckBox checkBoxVerify;

#endif // #if LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE
   }
}
