namespace Leadtools.Medical.Winforms.Forwarder
{
   partial class ForwardManagerConfigurationView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForwardManagerConfigurationView));
         this.tabControlForward = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.numericUpDownHoldAmount = new System.Windows.Forms.NumericUpDown();
         this.groupBoxClean = new System.Windows.Forms.GroupBox();
         this.checkBoxCleanEnable = new System.Windows.Forms.CheckBox();
         this.comboBoxHoldInterval = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.groupBoxForward = new System.Windows.Forms.GroupBox();
         this.checkBoxForwardEnable = new System.Windows.Forms.CheckBox();
         this.panel1 = new System.Windows.Forms.Panel();
         this.comboBoxForwardTo = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tabPageAdvanced = new System.Windows.Forms.TabPage();
         this.panelWarning = new System.Windows.Forms.Panel();
         this.label5 = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.checkBoxVerify = new System.Windows.Forms.CheckBox();
         this.groupBoxTools = new System.Windows.Forms.GroupBox();
         this.buttonCancelClean = new System.Windows.Forms.Button();
         this.buttonCancelForward = new System.Windows.Forms.Button();
         this.comboBoxToolForwardTo = new System.Windows.Forms.ComboBox();
         this.label6 = new System.Windows.Forms.Label();
         this.labelCleanInfo = new System.Windows.Forms.Label();
         this.labelForwardInfo = new System.Windows.Forms.Label();
         this.groupBoxReset = new System.Windows.Forms.GroupBox();
         this.labelResetInfo = new System.Windows.Forms.Label();
         this.labelEndDate = new System.Windows.Forms.Label();
         this.labelStartDay = new System.Windows.Forms.Label();
         this.buttonReset = new System.Windows.Forms.Button();
         this.dateTimePickerResetEnd = new System.Windows.Forms.DateTimePicker();
         this.label4 = new System.Windows.Forms.Label();
         this.dateTimePickerResetStart = new System.Windows.Forms.DateTimePicker();
         this.comboBoxReset = new System.Windows.Forms.ComboBox();
         this.buttonClean = new System.Windows.Forms.Button();
         this.buttonForward = new System.Windows.Forms.Button();
         this.textBoxCustomAE = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.checkBoxCustomAE = new System.Windows.Forms.CheckBox();
         this.schedulerControlClean = new Leadtools.Medical.Winforms.Forwarder.Controls.SchedulerControl();
         this.schedulerControlForward = new Leadtools.Medical.Winforms.Forwarder.Controls.SchedulerControl();
         this.tabControlForward.SuspendLayout();
         this.tabPage1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoldAmount)).BeginInit();
         this.groupBoxClean.SuspendLayout();
         this.groupBoxForward.SuspendLayout();
         this.panel1.SuspendLayout();
         this.tabPageAdvanced.SuspendLayout();
         this.panelWarning.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.groupBoxTools.SuspendLayout();
         this.groupBoxReset.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControlForward
         // 
         this.tabControlForward.Controls.Add(this.tabPage1);
         this.tabControlForward.Controls.Add(this.tabPageAdvanced);
         this.tabControlForward.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlForward.Location = new System.Drawing.Point(0, 0);
         this.tabControlForward.Name = "tabControlForward";
         this.tabControlForward.SelectedIndex = 0;
         this.tabControlForward.Size = new System.Drawing.Size(646, 387);
         this.tabControlForward.TabIndex = 0;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.numericUpDownHoldAmount);
         this.tabPage1.Controls.Add(this.groupBoxClean);
         this.tabPage1.Controls.Add(this.comboBoxHoldInterval);
         this.tabPage1.Controls.Add(this.label2);
         this.tabPage1.Controls.Add(this.groupBoxForward);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(638, 361);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Options";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // numericUpDownHoldAmount
         // 
         this.numericUpDownHoldAmount.Location = new System.Drawing.Point(377, 182);
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
         this.groupBoxClean.Location = new System.Drawing.Point(317, 10);
         this.groupBoxClean.Name = "groupBoxClean";
         this.groupBoxClean.Size = new System.Drawing.Size(301, 160);
         this.groupBoxClean.TabIndex = 1;
         this.groupBoxClean.TabStop = false;
         this.groupBoxClean.Text = "     Clean";
         // 
         // checkBoxCleanEnable
         // 
         this.checkBoxCleanEnable.AutoSize = true;
         this.checkBoxCleanEnable.Location = new System.Drawing.Point(6, 1);
         this.checkBoxCleanEnable.Name = "checkBoxCleanEnable";
         this.checkBoxCleanEnable.Size = new System.Drawing.Size(15, 14);
         this.checkBoxCleanEnable.TabIndex = 0;
         this.checkBoxCleanEnable.UseVisualStyleBackColor = true;
         this.checkBoxCleanEnable.CheckedChanged += new System.EventHandler(this.checkBoxCleanEnable_CheckedChanged);
         // 
         // comboBoxHoldInterval
         // 
         this.comboBoxHoldInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxHoldInterval.FormattingEnabled = true;
         this.comboBoxHoldInterval.Location = new System.Drawing.Point(444, 181);
         this.comboBoxHoldInterval.Name = "comboBoxHoldInterval";
         this.comboBoxHoldInterval.Size = new System.Drawing.Size(97, 21);
         this.comboBoxHoldInterval.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(314, 189);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(58, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Hold Time:";
         // 
         // groupBoxForward
         // 
         this.groupBoxForward.Controls.Add(this.schedulerControlForward);
         this.groupBoxForward.Controls.Add(this.checkBoxForwardEnable);
         this.groupBoxForward.Controls.Add(this.panel1);
         this.groupBoxForward.Location = new System.Drawing.Point(11, 10);
         this.groupBoxForward.Name = "groupBoxForward";
         this.groupBoxForward.Size = new System.Drawing.Size(297, 209);
         this.groupBoxForward.TabIndex = 0;
         this.groupBoxForward.TabStop = false;
         this.groupBoxForward.Text = "     Forward";
         // 
         // checkBoxForwardEnable
         // 
         this.checkBoxForwardEnable.AutoSize = true;
         this.checkBoxForwardEnable.Location = new System.Drawing.Point(6, 0);
         this.checkBoxForwardEnable.Name = "checkBoxForwardEnable";
         this.checkBoxForwardEnable.Size = new System.Drawing.Size(15, 14);
         this.checkBoxForwardEnable.TabIndex = 0;
         this.checkBoxForwardEnable.UseVisualStyleBackColor = true;
         this.checkBoxForwardEnable.CheckedChanged += new System.EventHandler(this.checkBoxForwardEnable_CheckedChanged);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.comboBoxForwardTo);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(3, 160);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(291, 46);
         this.panel1.TabIndex = 2;
         // 
         // comboBoxForwardTo
         // 
         this.comboBoxForwardTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxForwardTo.FormattingEnabled = true;
         this.comboBoxForwardTo.Location = new System.Drawing.Point(83, 11);
         this.comboBoxForwardTo.Name = "comboBoxForwardTo";
         this.comboBoxForwardTo.Size = new System.Drawing.Size(156, 21);
         this.comboBoxForwardTo.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 19);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Forward To:";
         // 
         // tabPageAdvanced
         // 
         this.tabPageAdvanced.Controls.Add(this.panelWarning);
         this.tabPageAdvanced.Controls.Add(this.checkBoxVerify);
         this.tabPageAdvanced.Controls.Add(this.groupBoxTools);
         this.tabPageAdvanced.Controls.Add(this.textBoxCustomAE);
         this.tabPageAdvanced.Controls.Add(this.label3);
         this.tabPageAdvanced.Controls.Add(this.checkBoxCustomAE);
         this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
         this.tabPageAdvanced.Name = "tabPageAdvanced";
         this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAdvanced.Size = new System.Drawing.Size(638, 361);
         this.tabPageAdvanced.TabIndex = 1;
         this.tabPageAdvanced.Text = "Advanced";
         this.tabPageAdvanced.UseVisualStyleBackColor = true;
         // 
         // panelWarning
         // 
         this.panelWarning.Controls.Add(this.label5);
         this.panelWarning.Controls.Add(this.pictureBox1);
         this.panelWarning.Location = new System.Drawing.Point(11, 284);
         this.panelWarning.Name = "panelWarning";
         this.panelWarning.Size = new System.Drawing.Size(576, 33);
         this.panelWarning.TabIndex = 5;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.ForeColor = System.Drawing.Color.Red;
         this.label5.Location = new System.Drawing.Point(28, 16);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(293, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Server must be running to enable forwarding tools.";
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
         // checkBoxVerify
         // 
         this.checkBoxVerify.AutoSize = true;
         this.checkBoxVerify.Location = new System.Drawing.Point(11, 60);
         this.checkBoxVerify.Name = "checkBoxVerify";
         this.checkBoxVerify.Size = new System.Drawing.Size(239, 17);
         this.checkBoxVerify.TabIndex = 3;
         this.checkBoxVerify.Text = "Verify (Send C-FIND after image is forwarded)";
         this.checkBoxVerify.UseVisualStyleBackColor = true;
         // 
         // groupBoxTools
         // 
         this.groupBoxTools.Controls.Add(this.buttonCancelClean);
         this.groupBoxTools.Controls.Add(this.buttonCancelForward);
         this.groupBoxTools.Controls.Add(this.comboBoxToolForwardTo);
         this.groupBoxTools.Controls.Add(this.label6);
         this.groupBoxTools.Controls.Add(this.labelCleanInfo);
         this.groupBoxTools.Controls.Add(this.labelForwardInfo);
         this.groupBoxTools.Controls.Add(this.groupBoxReset);
         this.groupBoxTools.Controls.Add(this.buttonClean);
         this.groupBoxTools.Controls.Add(this.buttonForward);
         this.groupBoxTools.Location = new System.Drawing.Point(11, 83);
         this.groupBoxTools.Name = "groupBoxTools";
         this.groupBoxTools.Size = new System.Drawing.Size(576, 195);
         this.groupBoxTools.TabIndex = 4;
         this.groupBoxTools.TabStop = false;
         this.groupBoxTools.Text = "Tools";
         // 
         // buttonCancelClean
         // 
         this.buttonCancelClean.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Remove;
         this.buttonCancelClean.Location = new System.Drawing.Point(102, 48);
         this.buttonCancelClean.Name = "buttonCancelClean";
         this.buttonCancelClean.Size = new System.Drawing.Size(25, 23);
         this.buttonCancelClean.TabIndex = 6;
         this.buttonCancelClean.UseVisualStyleBackColor = true;
         this.buttonCancelClean.Click += new System.EventHandler(this.buttonCancelClean_Click);
         // 
         // buttonCancelForward
         // 
         this.buttonCancelForward.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Remove;
         this.buttonCancelForward.Location = new System.Drawing.Point(102, 19);
         this.buttonCancelForward.Name = "buttonCancelForward";
         this.buttonCancelForward.Size = new System.Drawing.Size(25, 23);
         this.buttonCancelForward.TabIndex = 1;
         this.buttonCancelForward.UseVisualStyleBackColor = true;
         this.buttonCancelForward.Click += new System.EventHandler(this.buttonCancelForward_Click);
         // 
         // comboBoxToolForwardTo
         // 
         this.comboBoxToolForwardTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxToolForwardTo.FormattingEnabled = true;
         this.comboBoxToolForwardTo.Location = new System.Drawing.Point(377, 20);
         this.comboBoxToolForwardTo.Name = "comboBoxToolForwardTo";
         this.comboBoxToolForwardTo.Size = new System.Drawing.Size(156, 21);
         this.comboBoxToolForwardTo.TabIndex = 4;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(307, 24);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(64, 13);
         this.label6.TabIndex = 3;
         this.label6.Text = "Forward To:";
         // 
         // labelCleanInfo
         // 
         this.labelCleanInfo.AutoSize = true;
         this.labelCleanInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelCleanInfo.Location = new System.Drawing.Point(141, 53);
         this.labelCleanInfo.Name = "labelCleanInfo";
         this.labelCleanInfo.Size = new System.Drawing.Size(116, 13);
         this.labelCleanInfo.TabIndex = 7;
         this.labelCleanInfo.Text = "0 datasets to clean";
         // 
         // labelForwardInfo
         // 
         this.labelForwardInfo.AutoSize = true;
         this.labelForwardInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelForwardInfo.Location = new System.Drawing.Point(141, 24);
         this.labelForwardInfo.Name = "labelForwardInfo";
         this.labelForwardInfo.Size = new System.Drawing.Size(127, 13);
         this.labelForwardInfo.TabIndex = 2;
         this.labelForwardInfo.Text = "0 datasets to forward";
         // 
         // groupBoxReset
         // 
         this.groupBoxReset.Controls.Add(this.labelResetInfo);
         this.groupBoxReset.Controls.Add(this.labelEndDate);
         this.groupBoxReset.Controls.Add(this.labelStartDay);
         this.groupBoxReset.Controls.Add(this.buttonReset);
         this.groupBoxReset.Controls.Add(this.dateTimePickerResetEnd);
         this.groupBoxReset.Controls.Add(this.label4);
         this.groupBoxReset.Controls.Add(this.dateTimePickerResetStart);
         this.groupBoxReset.Controls.Add(this.comboBoxReset);
         this.groupBoxReset.Location = new System.Drawing.Point(21, 91);
         this.groupBoxReset.Name = "groupBoxReset";
         this.groupBoxReset.Size = new System.Drawing.Size(549, 98);
         this.groupBoxReset.TabIndex = 8;
         this.groupBoxReset.TabStop = false;
         this.groupBoxReset.Text = "Reset Forwarding";
         // 
         // labelResetInfo
         // 
         this.labelResetInfo.AutoSize = true;
         this.labelResetInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelResetInfo.Location = new System.Drawing.Point(88, 68);
         this.labelResetInfo.Name = "labelResetInfo";
         this.labelResetInfo.Size = new System.Drawing.Size(138, 13);
         this.labelResetInfo.TabIndex = 7;
         this.labelResetInfo.Text = "0 datasets will be reset";
         // 
         // labelEndDate
         // 
         this.labelEndDate.AutoSize = true;
         this.labelEndDate.Location = new System.Drawing.Point(257, 43);
         this.labelEndDate.Name = "labelEndDate";
         this.labelEndDate.Size = new System.Drawing.Size(0, 13);
         this.labelEndDate.TabIndex = 5;
         // 
         // labelStartDay
         // 
         this.labelStartDay.AutoSize = true;
         this.labelStartDay.Location = new System.Drawing.Point(130, 43);
         this.labelStartDay.Name = "labelStartDay";
         this.labelStartDay.Size = new System.Drawing.Size(0, 13);
         this.labelStartDay.TabIndex = 4;
         // 
         // buttonReset
         // 
         this.buttonReset.Image = ((System.Drawing.Image)(resources.GetObject("buttonReset.Image")));
         this.buttonReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.buttonReset.Location = new System.Drawing.Point(6, 63);
         this.buttonReset.Name = "buttonReset";
         this.buttonReset.Size = new System.Drawing.Size(75, 23);
         this.buttonReset.TabIndex = 6;
         this.buttonReset.Text = "Reset";
         this.buttonReset.UseVisualStyleBackColor = true;
         this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
         // 
         // dateTimePickerResetEnd
         // 
         this.dateTimePickerResetEnd.Checked = false;
         this.dateTimePickerResetEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerResetEnd.Location = new System.Drawing.Point(260, 19);
         this.dateTimePickerResetEnd.Name = "dateTimePickerResetEnd";
         this.dateTimePickerResetEnd.ShowCheckBox = true;
         this.dateTimePickerResetEnd.Size = new System.Drawing.Size(112, 20);
         this.dateTimePickerResetEnd.TabIndex = 3;
         this.dateTimePickerResetEnd.ValueChanged += new System.EventHandler(this.dateTimePickerResetEnd_ValueChanged);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(238, 23);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(16, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = "to";
         // 
         // dateTimePickerResetStart
         // 
         this.dateTimePickerResetStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerResetStart.Location = new System.Drawing.Point(133, 19);
         this.dateTimePickerResetStart.Name = "dateTimePickerResetStart";
         this.dateTimePickerResetStart.Size = new System.Drawing.Size(98, 20);
         this.dateTimePickerResetStart.TabIndex = 1;
         this.dateTimePickerResetStart.ValueChanged += new System.EventHandler(this.dateTimePickerResetStart_ValueChanged);
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
         this.comboBoxReset.Location = new System.Drawing.Point(6, 19);
         this.comboBoxReset.Name = "comboBoxReset";
         this.comboBoxReset.Size = new System.Drawing.Size(121, 21);
         this.comboBoxReset.TabIndex = 0;
         this.comboBoxReset.SelectionChangeCommitted += new System.EventHandler(this.comboBoxReset_SelectionChangeCommitted);
         // 
         // buttonClean
         // 
         this.buttonClean.Image = ((System.Drawing.Image)(resources.GetObject("buttonClean.Image")));
         this.buttonClean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.buttonClean.Location = new System.Drawing.Point(21, 48);
         this.buttonClean.Name = "buttonClean";
         this.buttonClean.Size = new System.Drawing.Size(75, 23);
         this.buttonClean.TabIndex = 5;
         this.buttonClean.Text = "Clean";
         this.buttonClean.UseVisualStyleBackColor = true;
         this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
         // 
         // buttonForward
         // 
         this.buttonForward.Image = ((System.Drawing.Image)(resources.GetObject("buttonForward.Image")));
         this.buttonForward.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
         this.buttonForward.Location = new System.Drawing.Point(21, 19);
         this.buttonForward.Name = "buttonForward";
         this.buttonForward.Size = new System.Drawing.Size(75, 23);
         this.buttonForward.TabIndex = 0;
         this.buttonForward.Text = "Forward";
         this.buttonForward.UseVisualStyleBackColor = true;
         this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
         // 
         // textBoxCustomAE
         // 
         this.textBoxCustomAE.Location = new System.Drawing.Point(97, 32);
         this.textBoxCustomAE.MaxLength = 16;
         this.textBoxCustomAE.Name = "textBoxCustomAE";
         this.textBoxCustomAE.Size = new System.Drawing.Size(131, 20);
         this.textBoxCustomAE.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(29, 39);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(62, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Custom AE:";
         // 
         // checkBoxCustomAE
         // 
         this.checkBoxCustomAE.AutoSize = true;
         this.checkBoxCustomAE.Location = new System.Drawing.Point(11, 10);
         this.checkBoxCustomAE.Name = "checkBoxCustomAE";
         this.checkBoxCustomAE.Size = new System.Drawing.Size(123, 17);
         this.checkBoxCustomAE.TabIndex = 0;
         this.checkBoxCustomAE.Text = "Use Custom AE Title";
         this.checkBoxCustomAE.UseVisualStyleBackColor = true;
         this.checkBoxCustomAE.CheckedChanged += new System.EventHandler(this.checkBoxCustomAE_CheckedChanged);
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
         // schedulerControlForward
         // 
         this.schedulerControlForward.Dock = System.Windows.Forms.DockStyle.Fill;
         this.schedulerControlForward.Location = new System.Drawing.Point(3, 16);
         this.schedulerControlForward.Name = "schedulerControlForward";
         this.schedulerControlForward.RepeatEvery = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.schedulerControlForward.RepeatInterval = Leadtools.Medical.Winforms.Forwarder.Controls.IntervalType.Days;
         this.schedulerControlForward.Size = new System.Drawing.Size(291, 144);
         this.schedulerControlForward.TabIndex = 1;
         // 
         // ForwardManagerConfigurationView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tabControlForward);
         this.Name = "ForwardManagerConfigurationView";
         this.Size = new System.Drawing.Size(646, 387);
         this.tabControlForward.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoldAmount)).EndInit();
         this.groupBoxClean.ResumeLayout(false);
         this.groupBoxClean.PerformLayout();
         this.groupBoxForward.ResumeLayout(false);
         this.groupBoxForward.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.tabPageAdvanced.ResumeLayout(false);
         this.tabPageAdvanced.PerformLayout();
         this.panelWarning.ResumeLayout(false);
         this.panelWarning.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.groupBoxTools.ResumeLayout(false);
         this.groupBoxTools.PerformLayout();
         this.groupBoxReset.ResumeLayout(false);
         this.groupBoxReset.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControlForward;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.ComboBox comboBoxForwardTo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBoxClean;
      private System.Windows.Forms.GroupBox groupBoxForward;
      private Leadtools.Medical.Winforms.Forwarder.Controls.SchedulerControl schedulerControlForward;
      private System.Windows.Forms.CheckBox checkBoxCleanEnable;
      private System.Windows.Forms.CheckBox checkBoxForwardEnable;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.ComboBox comboBoxHoldInterval;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown numericUpDownHoldAmount;
      private Leadtools.Medical.Winforms.Forwarder.Controls.SchedulerControl schedulerControlClean;
      private System.Windows.Forms.TabPage tabPageAdvanced;
      private System.Windows.Forms.CheckBox checkBoxCustomAE;
      private System.Windows.Forms.TextBox textBoxCustomAE;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.GroupBox groupBoxTools;
      private System.Windows.Forms.CheckBox checkBoxVerify;
      private System.Windows.Forms.Button buttonClean;
      private System.Windows.Forms.Button buttonForward;
      private System.Windows.Forms.GroupBox groupBoxReset;
      private System.Windows.Forms.ComboBox comboBoxReset;
      private System.Windows.Forms.Button buttonReset;
      private System.Windows.Forms.DateTimePicker dateTimePickerResetEnd;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.DateTimePicker dateTimePickerResetStart;
      private System.Windows.Forms.Label labelEndDate;
      private System.Windows.Forms.Label labelStartDay;
      private System.Windows.Forms.Label labelCleanInfo;
      private System.Windows.Forms.Label labelForwardInfo;
      private System.Windows.Forms.Label labelResetInfo;
      private System.Windows.Forms.Panel panelWarning;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ComboBox comboBoxToolForwardTo;
      private System.Windows.Forms.Button buttonCancelForward;
      private System.Windows.Forms.Button buttonCancelClean;
   }
}
