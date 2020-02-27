namespace Leadtools.Dicom.Server.Manager.Dialogs
{
    partial class EditServiceDialog
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
           this.labelAeTitle = new System.Windows.Forms.Label();
           this.ServerAE = new System.Windows.Forms.TextBox();
           this.labelDescription = new System.Windows.Forms.Label();
           this.ServerDescription = new System.Windows.Forms.TextBox();
           this.labelIpAddress = new System.Windows.Forms.Label();
           this.labelPort = new System.Windows.Forms.Label();
           this.ClientTimeout = new System.Windows.Forms.NumericUpDown();
           this.labelClientTimeout = new System.Windows.Forms.Label();
           this.labelMaxClients = new System.Windows.Forms.Label();
           this.ServerAllowAnonymous = new System.Windows.Forms.CheckBox();
           this.buttonOk = new System.Windows.Forms.Button();
           this.buttonCancel = new System.Windows.Forms.Button();
           this.ServerSecure = new System.Windows.Forms.CheckBox();
           this.ImplementationClass = new System.Windows.Forms.TextBox();
           this.labelImplementationClass = new System.Windows.Forms.Label();
           this.ImplementationVersionName = new System.Windows.Forms.TextBox();
           this.labelImplementationVersionName = new System.Windows.Forms.Label();
           this.TemporaryDirectory = new System.Windows.Forms.TextBox();
           this.labelTemporaryDirectory = new System.Windows.Forms.Label();
           this.ServerPort = new System.Windows.Forms.MaskedTextBox();
           this.ServerMaxClients = new System.Windows.Forms.MaskedTextBox();
           this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
           this.buttonFolderBrowse = new System.Windows.Forms.Button();
           this.tabControl1 = new System.Windows.Forms.TabControl();
           this.tabPageSettings = new System.Windows.Forms.TabPage();
           this.groupBoxIpType = new System.Windows.Forms.GroupBox();
           this.radioButtonIpv4Ipv6 = new System.Windows.Forms.RadioButton();
           this.radioButtonIpv6 = new System.Windows.Forms.RadioButton();
           this.radioButtonIpv4 = new System.Windows.Forms.RadioButton();
           this.ServerIp = new System.Windows.Forms.ComboBox();
           this.AllowMultipleConnections = new System.Windows.Forms.CheckBox();
           this.tabPageAdvanced = new System.Windows.Forms.TabPage();
           this.numericUpDownPipes = new System.Windows.Forms.NumericUpDown();
           this.labelPipes = new System.Windows.Forms.Label();
           this.checkBoxImageCopy = new System.Windows.Forms.CheckBox();
           this.StartMode = new System.Windows.Forms.ComboBox();
           this.labelStartMode = new System.Windows.Forms.Label();
           this.groupBoxSocketOptions = new System.Windows.Forms.GroupBox();
           this.SendBuffer = new System.Windows.Forms.NumericUpDown();
           this.ReceiveBuffer = new System.Windows.Forms.NumericUpDown();
           this.labelSendBuffer = new System.Windows.Forms.Label();
           this.labelReceiveBuffer = new System.Windows.Forms.Label();
           this.NoDelay = new System.Windows.Forms.CheckBox();
           this.MaxPduLength = new System.Windows.Forms.MaskedTextBox();
           this.labelMaxPdu = new System.Windows.Forms.Label();
           this.groupBoxTimeout = new System.Windows.Forms.GroupBox();
           this.ReconnectTimeout = new System.Windows.Forms.NumericUpDown();
           this.AddInTimeout = new System.Windows.Forms.NumericUpDown();
           this.labelAddInTimeout = new System.Windows.Forms.Label();
           this.labelReconnectTimeout = new System.Windows.Forms.Label();
           this.labelDisplayName = new System.Windows.Forms.Label();
           this.DisplayName = new System.Windows.Forms.TextBox();
           this.labelError = new System.Windows.Forms.Label();
           this.labelRestart = new System.Windows.Forms.Label();
           ((System.ComponentModel.ISupportInitialize)(this.ClientTimeout)).BeginInit();
           this.tabControl1.SuspendLayout();
           this.tabPageSettings.SuspendLayout();
           this.groupBoxIpType.SuspendLayout();
           this.tabPageAdvanced.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPipes)).BeginInit();
           this.groupBoxSocketOptions.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.SendBuffer)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.ReceiveBuffer)).BeginInit();
           this.groupBoxTimeout.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.ReconnectTimeout)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.AddInTimeout)).BeginInit();
           this.SuspendLayout();
           // 
           // labelAeTitle
           // 
           this.labelAeTitle.AutoSize = true;
           this.labelAeTitle.Location = new System.Drawing.Point(6, 13);
           this.labelAeTitle.Name = "labelAeTitle";
           this.labelAeTitle.Size = new System.Drawing.Size(47, 13);
           this.labelAeTitle.TabIndex = 0;
           this.labelAeTitle.Text = "AE Title:";
           // 
           // ServerAE
           // 
           this.ServerAE.Location = new System.Drawing.Point(9, 29);
           this.ServerAE.Name = "ServerAE";
           this.ServerAE.Size = new System.Drawing.Size(251, 20);
           this.ServerAE.TabIndex = 1;
           this.ServerAE.TextChanged += new System.EventHandler(this.ServerAE_TextChanged);
           this.ServerAE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServerAE_KeyPress);
           // 
           // labelDescription
           // 
           this.labelDescription.AutoSize = true;
           this.labelDescription.Location = new System.Drawing.Point(6, 52);
           this.labelDescription.Name = "labelDescription";
           this.labelDescription.Size = new System.Drawing.Size(63, 13);
           this.labelDescription.TabIndex = 2;
           this.labelDescription.Text = "Description:";
           // 
           // ServerDescription
           // 
           this.ServerDescription.Location = new System.Drawing.Point(9, 67);
           this.ServerDescription.Multiline = true;
           this.ServerDescription.Name = "ServerDescription";
           this.ServerDescription.Size = new System.Drawing.Size(251, 60);
           this.ServerDescription.TabIndex = 3;
           // 
           // labelIpAddress
           // 
           this.labelIpAddress.AutoSize = true;
           this.labelIpAddress.Location = new System.Drawing.Point(6, 130);
           this.labelIpAddress.Name = "labelIpAddress";
           this.labelIpAddress.Size = new System.Drawing.Size(61, 13);
           this.labelIpAddress.TabIndex = 4;
           this.labelIpAddress.Text = "IP Address:";
           // 
           // labelPort
           // 
           this.labelPort.AutoSize = true;
           this.labelPort.Location = new System.Drawing.Point(6, 272);
           this.labelPort.Name = "labelPort";
           this.labelPort.Size = new System.Drawing.Size(29, 13);
           this.labelPort.TabIndex = 6;
           this.labelPort.Text = "Port:";
           // 
           // ClientTimeout
           // 
           this.ClientTimeout.Location = new System.Drawing.Point(9, 32);
           this.ClientTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
           this.ClientTimeout.Name = "ClientTimeout";
           this.ClientTimeout.Size = new System.Drawing.Size(74, 20);
           this.ClientTimeout.TabIndex = 21;
           // 
           // labelClientTimeout
           // 
           this.labelClientTimeout.AutoSize = true;
           this.labelClientTimeout.Location = new System.Drawing.Point(6, 16);
           this.labelClientTimeout.Name = "labelClientTimeout";
           this.labelClientTimeout.Size = new System.Drawing.Size(36, 13);
           this.labelClientTimeout.TabIndex = 20;
           this.labelClientTimeout.Text = "Client:";
           // 
           // labelMaxClients
           // 
           this.labelMaxClients.AutoSize = true;
           this.labelMaxClients.Location = new System.Drawing.Point(149, 272);
           this.labelMaxClients.Name = "labelMaxClients";
           this.labelMaxClients.Size = new System.Drawing.Size(64, 13);
           this.labelMaxClients.TabIndex = 8;
           this.labelMaxClients.Text = "Max Clients:";
           // 
           // ServerAllowAnonymous
           // 
           this.ServerAllowAnonymous.AutoSize = true;
           this.ServerAllowAnonymous.Location = new System.Drawing.Point(277, 170);
           this.ServerAllowAnonymous.Name = "ServerAllowAnonymous";
           this.ServerAllowAnonymous.Size = new System.Drawing.Size(109, 17);
           this.ServerAllowAnonymous.TabIndex = 18;
           this.ServerAllowAnonymous.Text = "Allow Anonymous";
           this.ServerAllowAnonymous.UseVisualStyleBackColor = true;
           // 
           // buttonOk
           // 
           this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonOk.Location = new System.Drawing.Point(376, 380);
           this.buttonOk.Name = "buttonOk";
           this.buttonOk.Size = new System.Drawing.Size(75, 23);
           this.buttonOk.TabIndex = 3;
           this.buttonOk.Text = "OK";
           this.buttonOk.UseVisualStyleBackColor = true;
           // 
           // buttonCancel
           // 
           this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.buttonCancel.Location = new System.Drawing.Point(457, 380);
           this.buttonCancel.Name = "buttonCancel";
           this.buttonCancel.Size = new System.Drawing.Size(75, 23);
           this.buttonCancel.TabIndex = 4;
           this.buttonCancel.Text = "Cancel";
           this.buttonCancel.UseVisualStyleBackColor = true;
           // 
           // ServerSecure
           // 
           this.ServerSecure.AutoSize = true;
           this.ServerSecure.Location = new System.Drawing.Point(277, 150);
           this.ServerSecure.Name = "ServerSecure";
           this.ServerSecure.Size = new System.Drawing.Size(60, 17);
           this.ServerSecure.TabIndex = 17;
           this.ServerSecure.Text = "Secure";
           this.ServerSecure.UseVisualStyleBackColor = true;
           // 
           // ImplementationClass
           // 
           this.ImplementationClass.Location = new System.Drawing.Point(277, 29);
           this.ImplementationClass.MaxLength = 64;
           this.ImplementationClass.Name = "ImplementationClass";
           this.ImplementationClass.Size = new System.Drawing.Size(251, 20);
           this.ImplementationClass.TabIndex = 11;
           // 
           // labelImplementationClass
           // 
           this.labelImplementationClass.AutoSize = true;
           this.labelImplementationClass.Location = new System.Drawing.Point(274, 13);
           this.labelImplementationClass.Name = "labelImplementationClass";
           this.labelImplementationClass.Size = new System.Drawing.Size(131, 13);
           this.labelImplementationClass.TabIndex = 10;
           this.labelImplementationClass.Text = "Implementation Class UID:";
           // 
           // ImplementationVersionName
           // 
           this.ImplementationVersionName.Location = new System.Drawing.Point(277, 68);
           this.ImplementationVersionName.MaxLength = 16;
           this.ImplementationVersionName.Name = "ImplementationVersionName";
           this.ImplementationVersionName.Size = new System.Drawing.Size(251, 20);
           this.ImplementationVersionName.TabIndex = 13;
           // 
           // labelImplementationVersionName
           // 
           this.labelImplementationVersionName.AutoSize = true;
           this.labelImplementationVersionName.Location = new System.Drawing.Point(274, 52);
           this.labelImplementationVersionName.Name = "labelImplementationVersionName";
           this.labelImplementationVersionName.Size = new System.Drawing.Size(150, 13);
           this.labelImplementationVersionName.TabIndex = 12;
           this.labelImplementationVersionName.Text = "Implementation Version Name:";
           // 
           // TemporaryDirectory
           // 
           this.TemporaryDirectory.Location = new System.Drawing.Point(277, 107);
           this.TemporaryDirectory.Name = "TemporaryDirectory";
           this.TemporaryDirectory.Size = new System.Drawing.Size(217, 20);
           this.TemporaryDirectory.TabIndex = 15;
           this.TemporaryDirectory.TextChanged += new System.EventHandler(this.TemporaryDirectory_TextChanged);
           this.TemporaryDirectory.Leave += new System.EventHandler(this.TemporaryDirectory_Leave);
           // 
           // labelTemporaryDirectory
           // 
           this.labelTemporaryDirectory.AutoSize = true;
           this.labelTemporaryDirectory.Location = new System.Drawing.Point(274, 91);
           this.labelTemporaryDirectory.Name = "labelTemporaryDirectory";
           this.labelTemporaryDirectory.Size = new System.Drawing.Size(105, 13);
           this.labelTemporaryDirectory.TabIndex = 14;
           this.labelTemporaryDirectory.Text = "Temporary Directory:";
           // 
           // ServerPort
           // 
           this.ServerPort.HidePromptOnLeave = true;
           this.ServerPort.Location = new System.Drawing.Point(9, 288);
           this.ServerPort.Mask = "00000";
           this.ServerPort.Name = "ServerPort";
           this.ServerPort.PromptChar = '#';
           this.ServerPort.Size = new System.Drawing.Size(106, 20);
           this.ServerPort.TabIndex = 7;
           this.ServerPort.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
           this.ServerPort.ValidatingType = typeof(int);
           this.ServerPort.Leave += new System.EventHandler(this.ServerPort_Leave);
           this.ServerPort.TextChanged += new System.EventHandler(this.ServerPort_TextChanged);
           // 
           // ServerMaxClients
           // 
           this.ServerMaxClients.AllowPromptAsInput = false;
           this.ServerMaxClients.HidePromptOnLeave = true;
           this.ServerMaxClients.Location = new System.Drawing.Point(152, 288);
           this.ServerMaxClients.Mask = "00000";
           this.ServerMaxClients.Name = "ServerMaxClients";
           this.ServerMaxClients.PromptChar = '#';
           this.ServerMaxClients.RightToLeft = System.Windows.Forms.RightToLeft.No;
           this.ServerMaxClients.Size = new System.Drawing.Size(108, 20);
           this.ServerMaxClients.TabIndex = 9;
           this.ServerMaxClients.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
           this.ServerMaxClients.ValidatingType = typeof(int);
           // 
           // buttonFolderBrowse
           // 
           this.buttonFolderBrowse.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.BrowseFolder_Image;
           this.buttonFolderBrowse.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
           this.buttonFolderBrowse.Location = new System.Drawing.Point(495, 107);
           this.buttonFolderBrowse.Name = "buttonFolderBrowse";
           this.buttonFolderBrowse.Size = new System.Drawing.Size(32, 20);
           this.buttonFolderBrowse.TabIndex = 16;
           this.buttonFolderBrowse.UseVisualStyleBackColor = true;
           this.buttonFolderBrowse.Click += new System.EventHandler(this.buttonFolderBrowse_Click);
           // 
           // tabControl1
           // 
           this.tabControl1.Controls.Add(this.tabPageSettings);
           this.tabControl1.Controls.Add(this.tabPageAdvanced);
           this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
           this.tabControl1.Location = new System.Drawing.Point(0, 0);
           this.tabControl1.Name = "tabControl1";
           this.tabControl1.SelectedIndex = 0;
           this.tabControl1.Size = new System.Drawing.Size(542, 344);
           this.tabControl1.TabIndex = 0;
           // 
           // tabPageSettings
           // 
           this.tabPageSettings.Controls.Add(this.groupBoxIpType);
           this.tabPageSettings.Controls.Add(this.AllowMultipleConnections);
           this.tabPageSettings.Controls.Add(this.labelTemporaryDirectory);
           this.tabPageSettings.Controls.Add(this.labelAeTitle);
           this.tabPageSettings.Controls.Add(this.buttonFolderBrowse);
           this.tabPageSettings.Controls.Add(this.ServerAE);
           this.tabPageSettings.Controls.Add(this.labelDescription);
           this.tabPageSettings.Controls.Add(this.ServerDescription);
           this.tabPageSettings.Controls.Add(this.ServerMaxClients);
           this.tabPageSettings.Controls.Add(this.labelIpAddress);
           this.tabPageSettings.Controls.Add(this.ServerPort);
           this.tabPageSettings.Controls.Add(this.labelPort);
           this.tabPageSettings.Controls.Add(this.TemporaryDirectory);
           this.tabPageSettings.Controls.Add(this.labelMaxClients);
           this.tabPageSettings.Controls.Add(this.ImplementationVersionName);
           this.tabPageSettings.Controls.Add(this.labelImplementationVersionName);
           this.tabPageSettings.Controls.Add(this.ServerAllowAnonymous);
           this.tabPageSettings.Controls.Add(this.ImplementationClass);
           this.tabPageSettings.Controls.Add(this.labelImplementationClass);
           this.tabPageSettings.Controls.Add(this.ServerSecure);
           this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
           this.tabPageSettings.Name = "tabPageSettings";
           this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageSettings.Size = new System.Drawing.Size(534, 318);
           this.tabPageSettings.TabIndex = 0;
           this.tabPageSettings.Text = "Settings";
           this.tabPageSettings.UseVisualStyleBackColor = true;
           // 
           // groupBoxIpType
           // 
           this.groupBoxIpType.Controls.Add(this.radioButtonIpv4Ipv6);
           this.groupBoxIpType.Controls.Add(this.radioButtonIpv6);
           this.groupBoxIpType.Controls.Add(this.radioButtonIpv4);
           this.groupBoxIpType.Controls.Add(this.ServerIp);
           this.groupBoxIpType.Location = new System.Drawing.Point(8, 144);
           this.groupBoxIpType.Name = "groupBoxIpType";
           this.groupBoxIpType.Size = new System.Drawing.Size(232, 104);
           this.groupBoxIpType.TabIndex = 5;
           this.groupBoxIpType.TabStop = false;
           // 
           // radioButtonIpv4Ipv6
           // 
           this.radioButtonIpv4Ipv6.AutoSize = true;
           this.radioButtonIpv4Ipv6.Location = new System.Drawing.Point(8, 80);
           this.radioButtonIpv4Ipv6.Name = "radioButtonIpv4Ipv6";
           this.radioButtonIpv4Ipv6.Size = new System.Drawing.Size(82, 17);
           this.radioButtonIpv4Ipv6.TabIndex = 3;
           this.radioButtonIpv4Ipv6.TabStop = true;
           this.radioButtonIpv4Ipv6.Text = "Ipv4 or Ipv6";
           this.radioButtonIpv4Ipv6.UseVisualStyleBackColor = true;
           this.radioButtonIpv4Ipv6.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
           // 
           // radioButtonIpv6
           // 
           this.radioButtonIpv6.AutoSize = true;
           this.radioButtonIpv6.Location = new System.Drawing.Point(8, 64);
           this.radioButtonIpv6.Name = "radioButtonIpv6";
           this.radioButtonIpv6.Size = new System.Drawing.Size(47, 17);
           this.radioButtonIpv6.TabIndex = 2;
           this.radioButtonIpv6.TabStop = true;
           this.radioButtonIpv6.Text = "IPv6";
           this.radioButtonIpv6.UseVisualStyleBackColor = true;
           this.radioButtonIpv6.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
           // 
           // radioButtonIpv4
           // 
           this.radioButtonIpv4.AutoSize = true;
           this.radioButtonIpv4.Location = new System.Drawing.Point(8, 48);
           this.radioButtonIpv4.Name = "radioButtonIpv4";
           this.radioButtonIpv4.Size = new System.Drawing.Size(47, 17);
           this.radioButtonIpv4.TabIndex = 1;
           this.radioButtonIpv4.TabStop = true;
           this.radioButtonIpv4.Text = "IPv4";
           this.radioButtonIpv4.UseVisualStyleBackColor = true;
           this.radioButtonIpv4.CheckedChanged += new System.EventHandler(this.radioButtonIp_CheckedChanged);
           // 
           // ServerIp
           // 
           this.ServerIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.ServerIp.Location = new System.Drawing.Point(8, 16);
           this.ServerIp.Name = "ServerIp";
           this.ServerIp.Size = new System.Drawing.Size(208, 21);
           this.ServerIp.TabIndex = 0;
           // 
           // AllowMultipleConnections
           // 
           this.AllowMultipleConnections.AutoSize = true;
           this.AllowMultipleConnections.Location = new System.Drawing.Point(277, 190);
           this.AllowMultipleConnections.Name = "AllowMultipleConnections";
           this.AllowMultipleConnections.Size = new System.Drawing.Size(124, 17);
           this.AllowMultipleConnections.TabIndex = 19;
           this.AllowMultipleConnections.Text = "Multiple Connections";
           this.AllowMultipleConnections.UseVisualStyleBackColor = true;
           // 
           // tabPageAdvanced
           // 
           this.tabPageAdvanced.Controls.Add(this.numericUpDownPipes);
           this.tabPageAdvanced.Controls.Add(this.labelPipes);
           this.tabPageAdvanced.Controls.Add(this.checkBoxImageCopy);
           this.tabPageAdvanced.Controls.Add(this.StartMode);
           this.tabPageAdvanced.Controls.Add(this.labelStartMode);
           this.tabPageAdvanced.Controls.Add(this.groupBoxSocketOptions);
           this.tabPageAdvanced.Controls.Add(this.MaxPduLength);
           this.tabPageAdvanced.Controls.Add(this.labelMaxPdu);
           this.tabPageAdvanced.Controls.Add(this.groupBoxTimeout);
           this.tabPageAdvanced.Controls.Add(this.labelDisplayName);
           this.tabPageAdvanced.Controls.Add(this.DisplayName);
           this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
           this.tabPageAdvanced.Name = "tabPageAdvanced";
           this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageAdvanced.Size = new System.Drawing.Size(534, 318);
           this.tabPageAdvanced.TabIndex = 1;
           this.tabPageAdvanced.Text = "Advanced";
           this.tabPageAdvanced.UseVisualStyleBackColor = true;
           // 
           // numericUpDownPipes
           // 
           this.numericUpDownPipes.Location = new System.Drawing.Point(277, 147);
           this.numericUpDownPipes.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this.numericUpDownPipes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.numericUpDownPipes.Name = "numericUpDownPipes";
           this.numericUpDownPipes.Size = new System.Drawing.Size(76, 20);
           this.numericUpDownPipes.TabIndex = 36;
           this.numericUpDownPipes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
           // 
           // labelPipes
           // 
           this.labelPipes.AutoSize = true;
           this.labelPipes.Location = new System.Drawing.Point(274, 129);
           this.labelPipes.Name = "labelPipes";
           this.labelPipes.Size = new System.Drawing.Size(114, 13);
           this.labelPipes.TabIndex = 35;
           this.labelPipes.Text = "# Administrative Pipes:";
           // 
           // checkBoxImageCopy
           // 
           this.checkBoxImageCopy.AutoSize = true;
           this.checkBoxImageCopy.Location = new System.Drawing.Point(12, 183);
           this.checkBoxImageCopy.Name = "checkBoxImageCopy";
           this.checkBoxImageCopy.Size = new System.Drawing.Size(250, 17);
           this.checkBoxImageCopy.TabIndex = 34;
           this.checkBoxImageCopy.Text = "Copy dataset image during message notification";
           this.checkBoxImageCopy.UseVisualStyleBackColor = true;
           // 
           // StartMode
           // 
           this.StartMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.StartMode.FormattingEnabled = true;
           this.StartMode.Items.AddRange(new object[] {
            "Automatic",
            "Manual",
            "Disabled"});
           this.StartMode.Location = new System.Drawing.Point(12, 146);
           this.StartMode.Name = "StartMode";
           this.StartMode.Size = new System.Drawing.Size(160, 21);
           this.StartMode.TabIndex = 31;
           // 
           // labelStartMode
           // 
           this.labelStartMode.AutoSize = true;
           this.labelStartMode.Location = new System.Drawing.Point(9, 129);
           this.labelStartMode.Name = "labelStartMode";
           this.labelStartMode.Size = new System.Drawing.Size(62, 13);
           this.labelStartMode.TabIndex = 30;
           this.labelStartMode.Text = "Start Mode:";
           // 
           // groupBoxSocketOptions
           // 
           this.groupBoxSocketOptions.Controls.Add(this.SendBuffer);
           this.groupBoxSocketOptions.Controls.Add(this.ReceiveBuffer);
           this.groupBoxSocketOptions.Controls.Add(this.labelSendBuffer);
           this.groupBoxSocketOptions.Controls.Add(this.labelReceiveBuffer);
           this.groupBoxSocketOptions.Controls.Add(this.NoDelay);
           this.groupBoxSocketOptions.Location = new System.Drawing.Point(277, 56);
           this.groupBoxSocketOptions.Name = "groupBoxSocketOptions";
           this.groupBoxSocketOptions.Size = new System.Drawing.Size(251, 66);
           this.groupBoxSocketOptions.TabIndex = 29;
           this.groupBoxSocketOptions.TabStop = false;
           this.groupBoxSocketOptions.Text = "Socket Options";
           // 
           // SendBuffer
           // 
           this.SendBuffer.Location = new System.Drawing.Point(165, 31);
           this.SendBuffer.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
           this.SendBuffer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.SendBuffer.Name = "SendBuffer";
           this.SendBuffer.Size = new System.Drawing.Size(76, 20);
           this.SendBuffer.TabIndex = 21;
           this.SendBuffer.Value = new decimal(new int[] {
            29696,
            0,
            0,
            0});
           // 
           // ReceiveBuffer
           // 
           this.ReceiveBuffer.Location = new System.Drawing.Point(84, 31);
           this.ReceiveBuffer.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
           this.ReceiveBuffer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.ReceiveBuffer.Name = "ReceiveBuffer";
           this.ReceiveBuffer.Size = new System.Drawing.Size(76, 20);
           this.ReceiveBuffer.TabIndex = 20;
           this.ReceiveBuffer.Value = new decimal(new int[] {
            29696,
            0,
            0,
            0});
           // 
           // labelSendBuffer
           // 
           this.labelSendBuffer.AutoSize = true;
           this.labelSendBuffer.Location = new System.Drawing.Point(162, 15);
           this.labelSendBuffer.Name = "labelSendBuffer";
           this.labelSendBuffer.Size = new System.Drawing.Size(66, 13);
           this.labelSendBuffer.TabIndex = 18;
           this.labelSendBuffer.Text = "Send Buffer:";
           // 
           // labelReceiveBuffer
           // 
           this.labelReceiveBuffer.AutoSize = true;
           this.labelReceiveBuffer.Location = new System.Drawing.Point(80, 15);
           this.labelReceiveBuffer.Name = "labelReceiveBuffer";
           this.labelReceiveBuffer.Size = new System.Drawing.Size(81, 13);
           this.labelReceiveBuffer.TabIndex = 16;
           this.labelReceiveBuffer.Text = "Receive Buffer:";
           // 
           // NoDelay
           // 
           this.NoDelay.AutoSize = true;
           this.NoDelay.Location = new System.Drawing.Point(7, 34);
           this.NoDelay.Name = "NoDelay";
           this.NoDelay.Size = new System.Drawing.Size(70, 17);
           this.NoDelay.TabIndex = 0;
           this.NoDelay.Text = "No Delay";
           this.NoDelay.UseVisualStyleBackColor = true;
           // 
           // MaxPduLength
           // 
           this.MaxPduLength.HidePromptOnLeave = true;
           this.MaxPduLength.Location = new System.Drawing.Point(277, 29);
           this.MaxPduLength.Mask = "#########";
           this.MaxPduLength.Name = "MaxPduLength";
           this.MaxPduLength.PromptChar = '#';
           this.MaxPduLength.Size = new System.Drawing.Size(251, 20);
           this.MaxPduLength.TabIndex = 28;
           this.MaxPduLength.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
           // 
           // labelMaxPdu
           // 
           this.labelMaxPdu.AutoSize = true;
           this.labelMaxPdu.Location = new System.Drawing.Point(274, 13);
           this.labelMaxPdu.Name = "labelMaxPdu";
           this.labelMaxPdu.Size = new System.Drawing.Size(92, 13);
           this.labelMaxPdu.TabIndex = 27;
           this.labelMaxPdu.Text = "PDU Max Length:";
           // 
           // groupBoxTimeout
           // 
           this.groupBoxTimeout.Controls.Add(this.ReconnectTimeout);
           this.groupBoxTimeout.Controls.Add(this.AddInTimeout);
           this.groupBoxTimeout.Controls.Add(this.labelClientTimeout);
           this.groupBoxTimeout.Controls.Add(this.labelAddInTimeout);
           this.groupBoxTimeout.Controls.Add(this.ClientTimeout);
           this.groupBoxTimeout.Controls.Add(this.labelReconnectTimeout);
           this.groupBoxTimeout.Location = new System.Drawing.Point(9, 56);
           this.groupBoxTimeout.Name = "groupBoxTimeout";
           this.groupBoxTimeout.Size = new System.Drawing.Size(251, 66);
           this.groupBoxTimeout.TabIndex = 26;
           this.groupBoxTimeout.TabStop = false;
           this.groupBoxTimeout.Text = "Timeouts (Seconds)";
           // 
           // ReconnectTimeout
           // 
           this.ReconnectTimeout.Location = new System.Drawing.Point(89, 32);
           this.ReconnectTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
           this.ReconnectTimeout.Name = "ReconnectTimeout";
           this.ReconnectTimeout.Size = new System.Drawing.Size(74, 20);
           this.ReconnectTimeout.TabIndex = 23;
           // 
           // AddInTimeout
           // 
           this.AddInTimeout.Location = new System.Drawing.Point(169, 32);
           this.AddInTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
           this.AddInTimeout.Name = "AddInTimeout";
           this.AddInTimeout.Size = new System.Drawing.Size(74, 20);
           this.AddInTimeout.TabIndex = 25;
           // 
           // labelAddInTimeout
           // 
           this.labelAddInTimeout.AutoSize = true;
           this.labelAddInTimeout.Location = new System.Drawing.Point(166, 16);
           this.labelAddInTimeout.Name = "labelAddInTimeout";
           this.labelAddInTimeout.Size = new System.Drawing.Size(38, 13);
           this.labelAddInTimeout.TabIndex = 24;
           this.labelAddInTimeout.Text = "AddIn:";
           // 
           // labelReconnectTimeout
           // 
           this.labelReconnectTimeout.AutoSize = true;
           this.labelReconnectTimeout.Location = new System.Drawing.Point(86, 16);
           this.labelReconnectTimeout.Name = "labelReconnectTimeout";
           this.labelReconnectTimeout.Size = new System.Drawing.Size(63, 13);
           this.labelReconnectTimeout.TabIndex = 22;
           this.labelReconnectTimeout.Text = "Reconnect:";
           // 
           // labelDisplayName
           // 
           this.labelDisplayName.AutoSize = true;
           this.labelDisplayName.Location = new System.Drawing.Point(6, 13);
           this.labelDisplayName.Name = "labelDisplayName";
           this.labelDisplayName.Size = new System.Drawing.Size(114, 13);
           this.labelDisplayName.TabIndex = 4;
           this.labelDisplayName.Text = "Service Display Name:";
           // 
           // DisplayName
           // 
           this.DisplayName.Location = new System.Drawing.Point(9, 29);
           this.DisplayName.Name = "DisplayName";
           this.DisplayName.Size = new System.Drawing.Size(251, 20);
           this.DisplayName.TabIndex = 5;
           this.DisplayName.TextChanged += new System.EventHandler(this.DisplayName_TextChanged);
           this.DisplayName.Leave += new System.EventHandler(this.DisplayName_Leave);
           // 
           // labelError
           // 
           this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelError.ForeColor = System.Drawing.Color.Red;
           this.labelError.Location = new System.Drawing.Point(4, 389);
           this.labelError.Name = "labelError";
           this.labelError.Size = new System.Drawing.Size(366, 14);
           this.labelError.TabIndex = 2;
           this.labelError.Text = "Error";
           // 
           // labelRestart
           // 
           this.labelRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelRestart.ForeColor = System.Drawing.Color.Red;
           this.labelRestart.Location = new System.Drawing.Point(4, 360);
           this.labelRestart.Name = "labelRestart";
           this.labelRestart.Size = new System.Drawing.Size(366, 14);
           this.labelRestart.TabIndex = 1;
           this.labelRestart.Text = "Error";
           // 
           // EditServiceDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this.buttonCancel;
           this.ClientSize = new System.Drawing.Size(542, 409);
           this.Controls.Add(this.labelRestart);
           this.Controls.Add(this.labelError);
           this.Controls.Add(this.tabControl1);
           this.Controls.Add(this.buttonCancel);
           this.Controls.Add(this.buttonOk);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "EditServiceDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Add New Server";
           this.Load += new System.EventHandler(this.EditServerDialog_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditServerDialog_FormClosing);
           ((System.ComponentModel.ISupportInitialize)(this.ClientTimeout)).EndInit();
           this.tabControl1.ResumeLayout(false);
           this.tabPageSettings.ResumeLayout(false);
           this.tabPageSettings.PerformLayout();
           this.groupBoxIpType.ResumeLayout(false);
           this.groupBoxIpType.PerformLayout();
           this.tabPageAdvanced.ResumeLayout(false);
           this.tabPageAdvanced.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPipes)).EndInit();
           this.groupBoxSocketOptions.ResumeLayout(false);
           this.groupBoxSocketOptions.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.SendBuffer)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.ReceiveBuffer)).EndInit();
           this.groupBoxTimeout.ResumeLayout(false);
           this.groupBoxTimeout.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.ReconnectTimeout)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.AddInTimeout)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAeTitle;
        private System.Windows.Forms.TextBox ServerAE;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox ServerDescription;
        private System.Windows.Forms.Label labelIpAddress;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.NumericUpDown ClientTimeout;
        private System.Windows.Forms.Label labelClientTimeout;
        private System.Windows.Forms.Label labelMaxClients;
        private System.Windows.Forms.CheckBox ServerAllowAnonymous;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox ServerSecure;
        private System.Windows.Forms.TextBox ImplementationClass;
        private System.Windows.Forms.Label labelImplementationClass;
        private System.Windows.Forms.TextBox ImplementationVersionName;
        private System.Windows.Forms.Label labelImplementationVersionName;
        private System.Windows.Forms.Label labelTemporaryDirectory;
        private System.Windows.Forms.TextBox TemporaryDirectory;
        private System.Windows.Forms.MaskedTextBox ServerPort;
        private System.Windows.Forms.MaskedTextBox ServerMaxClients;
        private System.Windows.Forms.Button buttonFolderBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.Label labelDisplayName;
        private System.Windows.Forms.TextBox DisplayName;
        private System.Windows.Forms.NumericUpDown ReconnectTimeout;
        private System.Windows.Forms.Label labelReconnectTimeout;
        private System.Windows.Forms.NumericUpDown AddInTimeout;
        private System.Windows.Forms.Label labelAddInTimeout;
        private System.Windows.Forms.GroupBox groupBoxTimeout;
        private System.Windows.Forms.Label labelMaxPdu;
        private System.Windows.Forms.GroupBox groupBoxSocketOptions;
        private System.Windows.Forms.MaskedTextBox MaxPduLength;
       private System.Windows.Forms.Label labelSendBuffer;
        private System.Windows.Forms.Label labelReceiveBuffer;
       private System.Windows.Forms.CheckBox NoDelay;
        private System.Windows.Forms.ComboBox StartMode;
        private System.Windows.Forms.Label labelStartMode;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox AllowMultipleConnections;
        private System.Windows.Forms.Label labelRestart;
       private System.Windows.Forms.NumericUpDown SendBuffer;
       private System.Windows.Forms.NumericUpDown ReceiveBuffer;
       private System.Windows.Forms.CheckBox checkBoxImageCopy;
        private System.Windows.Forms.Label labelPipes;
        private System.Windows.Forms.NumericUpDown numericUpDownPipes;
        private System.Windows.Forms.GroupBox groupBoxIpType;
        private System.Windows.Forms.RadioButton radioButtonIpv4Ipv6;
        private System.Windows.Forms.RadioButton radioButtonIpv6;
        private System.Windows.Forms.RadioButton radioButtonIpv4;
        private System.Windows.Forms.ComboBox ServerIp;
    }
}
