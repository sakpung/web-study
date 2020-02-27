namespace Leadtools.Medical.Winforms
{
   partial class InsertModifyClientControl
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertModifyClientControl));
         this.groupBoxClient = new System.Windows.Forms.GroupBox();
         this.textBoxFriendlyName = new System.Windows.Forms.TextBox();
         this.labelFriendlyName = new System.Windows.Forms.Label();
         this.buttonPing = new System.Windows.Forms.Button();
         this.groupBoxReconnectPort = new System.Windows.Forms.GroupBox();
         this.pictureBoxUnsecurePort = new System.Windows.Forms.PictureBox();
         this.label1 = new System.Windows.Forms.Label();
         this.comboBoxClientPortSelection = new System.Windows.Forms.ComboBox();
         this.labelSecurePort = new System.Windows.Forms.Label();
         this.labelUnsecurePort = new System.Windows.Forms.Label();
         this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
         this.numericUpDownSecurePort = new System.Windows.Forms.NumericUpDown();
         this.groupBoxPermissions = new System.Windows.Forms.GroupBox();
         this.listViewPermissions = new System.Windows.Forms.ListView();
         this.checkBoxMask = new System.Windows.Forms.CheckBox();
         this.textBoxMask = new System.Windows.Forms.TextBox();
         this.labelMask = new System.Windows.Forms.Label();
         this.checkBoxVerifyAddress = new System.Windows.Forms.CheckBox();
         this.textBoxAddress = new System.Windows.Forms.TextBox();
         this.labelAddress = new System.Windows.Forms.Label();
         this.textBoxAeTitle = new System.Windows.Forms.TextBox();
         this.labelAeTitle = new System.Windows.Forms.Label();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.pictureBoxSecurePort = new System.Windows.Forms.PictureBox();
         this.groupBoxClient.SuspendLayout();
         this.groupBoxReconnectPort.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnsecurePort)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecurePort)).BeginInit();
         this.groupBoxPermissions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecurePort)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBoxClient
         // 
         this.groupBoxClient.Controls.Add(this.textBoxFriendlyName);
         this.groupBoxClient.Controls.Add(this.labelFriendlyName);
         this.groupBoxClient.Controls.Add(this.buttonPing);
         this.groupBoxClient.Controls.Add(this.groupBoxReconnectPort);
         this.groupBoxClient.Controls.Add(this.groupBoxPermissions);
         this.groupBoxClient.Controls.Add(this.checkBoxMask);
         this.groupBoxClient.Controls.Add(this.textBoxMask);
         this.groupBoxClient.Controls.Add(this.labelMask);
         this.groupBoxClient.Controls.Add(this.checkBoxVerifyAddress);
         this.groupBoxClient.Controls.Add(this.textBoxAddress);
         this.groupBoxClient.Controls.Add(this.labelAddress);
         this.groupBoxClient.Controls.Add(this.textBoxAeTitle);
         this.groupBoxClient.Controls.Add(this.labelAeTitle);
         this.groupBoxClient.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBoxClient.Location = new System.Drawing.Point(0, 0);
         this.groupBoxClient.Name = "groupBoxClient";
         this.groupBoxClient.Size = new System.Drawing.Size(515, 428);
         this.groupBoxClient.TabIndex = 0;
         this.groupBoxClient.TabStop = false;
         this.groupBoxClient.Text = "Client Information";
         // 
         // textBoxFriendlyName
         // 
         this.textBoxFriendlyName.Location = new System.Drawing.Point(138, 46);
         this.textBoxFriendlyName.Name = "textBoxFriendlyName";
         this.textBoxFriendlyName.Size = new System.Drawing.Size(159, 20);
         this.textBoxFriendlyName.TabIndex = 3;
         this.textBoxFriendlyName.Validated += new System.EventHandler(this.textBoxFriendlyName_Validated);
         // 
         // labelFriendlyName
         // 
         this.labelFriendlyName.AutoSize = true;
         this.labelFriendlyName.Location = new System.Drawing.Point(18, 50);
         this.labelFriendlyName.Name = "labelFriendlyName";
         this.labelFriendlyName.Size = new System.Drawing.Size(32, 13);
         this.labelFriendlyName.TabIndex = 2;
         this.labelFriendlyName.Text = "Alias:";
         // 
         // buttonPing
         // 
         this.buttonPing.Enabled = false;
         this.buttonPing.Image = ((System.Drawing.Image)(resources.GetObject("buttonPing.Image")));
         this.buttonPing.Location = new System.Drawing.Point(270, 71);
         this.buttonPing.Name = "buttonPing";
         this.buttonPing.Size = new System.Drawing.Size(27, 23);
         this.buttonPing.TabIndex = 6;
         this.buttonPing.UseVisualStyleBackColor = true;
         this.buttonPing.Click += new System.EventHandler(this.buttonPing_Click);
         // 
         // groupBoxReconnectPort
         // 
         this.groupBoxReconnectPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxReconnectPort.Controls.Add(this.pictureBoxSecurePort);
         this.groupBoxReconnectPort.Controls.Add(this.pictureBoxUnsecurePort);
         this.groupBoxReconnectPort.Controls.Add(this.label1);
         this.groupBoxReconnectPort.Controls.Add(this.comboBoxClientPortSelection);
         this.groupBoxReconnectPort.Controls.Add(this.labelSecurePort);
         this.groupBoxReconnectPort.Controls.Add(this.labelUnsecurePort);
         this.groupBoxReconnectPort.Controls.Add(this.numericUpDownPort);
         this.groupBoxReconnectPort.Controls.Add(this.numericUpDownSecurePort);
         this.groupBoxReconnectPort.Location = new System.Drawing.Point(12, 124);
         this.groupBoxReconnectPort.Name = "groupBoxReconnectPort";
         this.groupBoxReconnectPort.Size = new System.Drawing.Size(497, 107);
         this.groupBoxReconnectPort.TabIndex = 11;
         this.groupBoxReconnectPort.TabStop = false;
         this.groupBoxReconnectPort.Text = "Reconnect Port";
         // 
         // pictureBoxUnsecurePort
         // 
         this.pictureBoxUnsecurePort.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Tick;
         this.pictureBoxUnsecurePort.Location = new System.Drawing.Point(295, 17);
         this.pictureBoxUnsecurePort.Name = "pictureBoxUnsecurePort";
         this.pictureBoxUnsecurePort.Size = new System.Drawing.Size(20, 20);
         this.pictureBoxUnsecurePort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBoxUnsecurePort.TabIndex = 8;
         this.pictureBoxUnsecurePort.TabStop = false;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(44, 73);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(76, 13);
         this.label1.TabIndex = 7;
         this.label1.Text = "Port Usage:";
         // 
         // comboBoxClientPortSelection
         // 
         this.comboBoxClientPortSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxClientPortSelection.FormattingEnabled = true;
         this.comboBoxClientPortSelection.Location = new System.Drawing.Point(126, 69);
         this.comboBoxClientPortSelection.Name = "comboBoxClientPortSelection";
         this.comboBoxClientPortSelection.Size = new System.Drawing.Size(159, 21);
         this.comboBoxClientPortSelection.TabIndex = 6;
         this.comboBoxClientPortSelection.Validated += new System.EventHandler(this.comboBoxClientPortSelection_Validated);
         // 
         // labelSecurePort
         // 
         this.labelSecurePort.AutoSize = true;
         this.labelSecurePort.Location = new System.Drawing.Point(54, 45);
         this.labelSecurePort.Name = "labelSecurePort";
         this.labelSecurePort.Size = new System.Drawing.Size(66, 13);
         this.labelSecurePort.TabIndex = 5;
         this.labelSecurePort.Text = "Secure Port:";
         // 
         // labelUnsecurePort
         // 
         this.labelUnsecurePort.AutoSize = true;
         this.labelUnsecurePort.Location = new System.Drawing.Point(46, 19);
         this.labelUnsecurePort.Name = "labelUnsecurePort";
         this.labelUnsecurePort.Size = new System.Drawing.Size(78, 13);
         this.labelUnsecurePort.TabIndex = 4;
         this.labelUnsecurePort.Text = "Unsecure Port:";
         // 
         // numericUpDownPort
         // 
         this.numericUpDownPort.Location = new System.Drawing.Point(126, 17);
         this.numericUpDownPort.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
         this.numericUpDownPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownPort.Name = "numericUpDownPort";
         this.numericUpDownPort.Size = new System.Drawing.Size(159, 20);
         this.numericUpDownPort.TabIndex = 1;
         this.numericUpDownPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownPort.Validated += new System.EventHandler(this.numericUpDownPort_Validated);
         // 
         // numericUpDownSecurePort
         // 
         this.numericUpDownSecurePort.Location = new System.Drawing.Point(126, 43);
         this.numericUpDownSecurePort.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
         this.numericUpDownSecurePort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownSecurePort.Name = "numericUpDownSecurePort";
         this.numericUpDownSecurePort.Size = new System.Drawing.Size(159, 20);
         this.numericUpDownSecurePort.TabIndex = 3;
         this.numericUpDownSecurePort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownSecurePort.Validated += new System.EventHandler(this.numericUpDownSecurePort_Validated);
         // 
         // groupBoxPermissions
         // 
         this.groupBoxPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxPermissions.Controls.Add(this.listViewPermissions);
         this.groupBoxPermissions.Location = new System.Drawing.Point(12, 246);
         this.groupBoxPermissions.Name = "groupBoxPermissions";
         this.groupBoxPermissions.Size = new System.Drawing.Size(497, 175);
         this.groupBoxPermissions.TabIndex = 12;
         this.groupBoxPermissions.TabStop = false;
         this.groupBoxPermissions.Text = "Permissions";
         // 
         // listViewPermissions
         // 
         this.listViewPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewPermissions.CheckBoxes = true;
         this.listViewPermissions.FullRowSelect = true;
         this.listViewPermissions.Location = new System.Drawing.Point(6, 18);
         this.listViewPermissions.Name = "listViewPermissions";
         this.listViewPermissions.Size = new System.Drawing.Size(485, 150);
         this.listViewPermissions.TabIndex = 0;
         this.listViewPermissions.UseCompatibleStateImageBehavior = false;
         this.listViewPermissions.View = System.Windows.Forms.View.List;
         this.listViewPermissions.Validated += new System.EventHandler(this.listViewPermissions_Validated);
         // 
         // checkBoxMask
         // 
         this.checkBoxMask.AutoSize = true;
         this.checkBoxMask.Location = new System.Drawing.Point(317, 100);
         this.checkBoxMask.Name = "checkBoxMask";
         this.checkBoxMask.Size = new System.Drawing.Size(111, 17);
         this.checkBoxMask.TabIndex = 10;
         this.checkBoxMask.Text = "Use Subnet Mask";
         this.checkBoxMask.UseVisualStyleBackColor = true;
         this.checkBoxMask.CheckedChanged += new System.EventHandler(this.checkBoxMask_CheckedChanged);
         this.checkBoxMask.Validated += new System.EventHandler(this.checkBoxMask_Validated);
         // 
         // textBoxMask
         // 
         this.textBoxMask.Location = new System.Drawing.Point(138, 98);
         this.textBoxMask.Name = "textBoxMask";
         this.textBoxMask.Size = new System.Drawing.Size(159, 20);
         this.textBoxMask.TabIndex = 9;
         this.textBoxMask.Validated += new System.EventHandler(this.textBoxMask_Validated);
         // 
         // labelMask
         // 
         this.labelMask.AutoSize = true;
         this.labelMask.Location = new System.Drawing.Point(18, 102);
         this.labelMask.Name = "labelMask";
         this.labelMask.Size = new System.Drawing.Size(73, 13);
         this.labelMask.TabIndex = 8;
         this.labelMask.Text = "Subnet Mask:";
         // 
         // checkBoxVerifyAddress
         // 
         this.checkBoxVerifyAddress.AutoSize = true;
         this.checkBoxVerifyAddress.Location = new System.Drawing.Point(317, 74);
         this.checkBoxVerifyAddress.Name = "checkBoxVerifyAddress";
         this.checkBoxVerifyAddress.Size = new System.Drawing.Size(162, 17);
         this.checkBoxVerifyAddress.TabIndex = 7;
         this.checkBoxVerifyAddress.Text = "Verify Hostname/ IP Address";
         this.checkBoxVerifyAddress.UseVisualStyleBackColor = true;
         this.checkBoxVerifyAddress.CheckedChanged += new System.EventHandler(this.checkBoxVerifyAddress_CheckedChanged);
         this.checkBoxVerifyAddress.Validated += new System.EventHandler(this.checkBoxVerifyAddress_Validated);
         // 
         // textBoxAddress
         // 
         this.textBoxAddress.Location = new System.Drawing.Point(138, 72);
         this.textBoxAddress.Name = "textBoxAddress";
         this.textBoxAddress.Size = new System.Drawing.Size(132, 20);
         this.textBoxAddress.TabIndex = 5;
         this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
         this.textBoxAddress.Validated += new System.EventHandler(this.textBoxAddress_Validated);
         // 
         // labelAddress
         // 
         this.labelAddress.AutoSize = true;
         this.labelAddress.Location = new System.Drawing.Point(18, 76);
         this.labelAddress.Name = "labelAddress";
         this.labelAddress.Size = new System.Drawing.Size(114, 13);
         this.labelAddress.TabIndex = 4;
         this.labelAddress.Text = "Hostname/IP Address:";
         // 
         // textBoxAeTitle
         // 
         this.textBoxAeTitle.Location = new System.Drawing.Point(138, 20);
         this.textBoxAeTitle.Name = "textBoxAeTitle";
         this.textBoxAeTitle.Size = new System.Drawing.Size(159, 20);
         this.textBoxAeTitle.TabIndex = 1;
         this.textBoxAeTitle.Validated += new System.EventHandler(this.textBoxAeTitle_Validated);
         // 
         // labelAeTitle
         // 
         this.labelAeTitle.AutoSize = true;
         this.labelAeTitle.Location = new System.Drawing.Point(18, 24);
         this.labelAeTitle.Name = "labelAeTitle";
         this.labelAeTitle.Size = new System.Drawing.Size(47, 13);
         this.labelAeTitle.TabIndex = 0;
         this.labelAeTitle.Text = "AE Title:";
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // pictureBoxSecurePort
         // 
         this.pictureBoxSecurePort.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Tick;
         this.pictureBoxSecurePort.Location = new System.Drawing.Point(295, 43);
         this.pictureBoxSecurePort.Name = "pictureBoxSecurePort";
         this.pictureBoxSecurePort.Size = new System.Drawing.Size(20, 20);
         this.pictureBoxSecurePort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBoxSecurePort.TabIndex = 9;
         this.pictureBoxSecurePort.TabStop = false;
         // 
         // InsertModifyClientControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxClient);
         this.MinimumSize = new System.Drawing.Size(487, 320);
         this.Name = "InsertModifyClientControl";
         this.Size = new System.Drawing.Size(515, 428);
         this.Load += new System.EventHandler(this.InsertModifyClientControl_Load);
         this.groupBoxClient.ResumeLayout(false);
         this.groupBoxClient.PerformLayout();
         this.groupBoxReconnectPort.ResumeLayout(false);
         this.groupBoxReconnectPort.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnsecurePort)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecurePort)).EndInit();
         this.groupBoxPermissions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecurePort)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxClient;
      private System.Windows.Forms.NumericUpDown numericUpDownSecurePort;
      private System.Windows.Forms.NumericUpDown numericUpDownPort;
      private System.Windows.Forms.CheckBox checkBoxMask;
      private System.Windows.Forms.TextBox textBoxMask;
      private System.Windows.Forms.Label labelMask;
      private System.Windows.Forms.CheckBox checkBoxVerifyAddress;
      private System.Windows.Forms.TextBox textBoxAddress;
      private System.Windows.Forms.Label labelAddress;
      private System.Windows.Forms.TextBox textBoxAeTitle;
      private System.Windows.Forms.Label labelAeTitle;
      private System.Windows.Forms.GroupBox groupBoxPermissions;
      private System.Windows.Forms.ListView listViewPermissions;
      private System.Windows.Forms.ErrorProvider errorProvider;
      private System.Windows.Forms.GroupBox groupBoxReconnectPort;
      private System.Windows.Forms.Button buttonPing;
      private System.Windows.Forms.TextBox textBoxFriendlyName;
      private System.Windows.Forms.Label labelFriendlyName;
      private System.Windows.Forms.Label labelSecurePort;
      private System.Windows.Forms.Label labelUnsecurePort;
      private System.Windows.Forms.ComboBox comboBoxClientPortSelection;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.PictureBox pictureBoxUnsecurePort;
      private System.Windows.Forms.PictureBox pictureBoxSecurePort;
   }
}
