namespace DicomDemo
{
   partial class OptionsDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
         this._groupBoxClient = new System.Windows.Forms.GroupBox();
         this._textBoxClientPort = new System.Windows.Forms.TextBox();
         this._labelClientPort = new System.Windows.Forms.Label();
         this._textBoxClientAE = new System.Windows.Forms.TextBox();
         this._labelClientAE = new System.Windows.Forms.Label();
         this._groupBoxCompression = new System.Windows.Forms.GroupBox();
         this._radioButtonCompressionLossless = new System.Windows.Forms.RadioButton();
         this._radioButtonCompressionLossy = new System.Windows.Forms.RadioButton();
         this._radioButtonCompressionNative = new System.Windows.Forms.RadioButton();
         this._buttonOK = new System.Windows.Forms.Button();
         this._buttonCancel = new System.Windows.Forms.Button();
         this._groupBoxSecurity = new System.Windows.Forms.GroupBox();
         this._labelCertificate = new System.Windows.Forms.Label();
         this._labelHint = new System.Windows.Forms.Label();
         this._buttonClientCertificate = new System.Windows.Forms.Button();
         this._textBoxClientCertificate = new System.Windows.Forms.TextBox();
         this._textBoxKeyPassword = new System.Windows.Forms.TextBox();
         this._labelPrivateKeyPassword = new System.Windows.Forms.Label();
         this._labelPrivateKey = new System.Windows.Forms.Label();
         this._textBoxPrivateKey = new System.Windows.Forms.TextBox();
         this._buttonPrivateKey = new System.Windows.Forms.Button();
         this.buttonDeleteServer = new System.Windows.Forms.Button();
         this.buttonAddServer = new System.Windows.Forms.Button();
         this.dataGridViewServers = new System.Windows.Forms.DataGridView();
         this.ColumnAE = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTls = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this._groupBoxStorageCommit = new System.Windows.Forms.GroupBox();
         this._radioButtonWaitForResults = new System.Windows.Forms.RadioButton();
         this._radioButtonNoWaitForResults = new System.Windows.Forms.RadioButton();
         this._groupMiscellaneous = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this._checkBoxDisableLogging = new System.Windows.Forms.CheckBox();
         this._labelLogLowLevel = new System.Windows.Forms.Label();
         this._checkBoxLogLowLevel = new System.Windows.Forms.CheckBox();
         this._checkBoxGroupLengthDataElements = new System.Windows.Forms.CheckBox();
         this.groupBoxCipherSuites = new System.Windows.Forms.GroupBox();
         this._buttonMoveDown = new System.Windows.Forms.Button();
         this._checkBoxTlsOld = new System.Windows.Forms.CheckBox();
         this._buttonMoveUp = new System.Windows.Forms.Button();
         this._listViewCipherSuites = new System.Windows.Forms.ListView();
         this.imageListCiphers = new System.Windows.Forms.ImageList(this.components);
         this._groupBoxClient.SuspendLayout();
         this._groupBoxCompression.SuspendLayout();
         this._groupBoxSecurity.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServers)).BeginInit();
         this._groupBoxStorageCommit.SuspendLayout();
         this._groupMiscellaneous.SuspendLayout();
         this.groupBoxCipherSuites.SuspendLayout();
         this.SuspendLayout();
         // 
         // _groupBoxClient
         // 
         this._groupBoxClient.Controls.Add(this._textBoxClientPort);
         this._groupBoxClient.Controls.Add(this._labelClientPort);
         this._groupBoxClient.Controls.Add(this._textBoxClientAE);
         this._groupBoxClient.Controls.Add(this._labelClientAE);
         this._groupBoxClient.Location = new System.Drawing.Point(8, 8);
         this._groupBoxClient.Name = "_groupBoxClient";
         this._groupBoxClient.Size = new System.Drawing.Size(536, 74);
         this._groupBoxClient.TabIndex = 0;
         this._groupBoxClient.TabStop = false;
         this._groupBoxClient.Text = "Client Information";
         // 
         // _textBoxClientPort
         // 
         this._textBoxClientPort.Location = new System.Drawing.Point(111, 47);
         this._textBoxClientPort.Name = "_textBoxClientPort";
         this._textBoxClientPort.Size = new System.Drawing.Size(417, 20);
         this._textBoxClientPort.TabIndex = 3;
         // 
         // _labelClientPort
         // 
         this._labelClientPort.AutoSize = true;
         this._labelClientPort.Location = new System.Drawing.Point(16, 51);
         this._labelClientPort.Name = "_labelClientPort";
         this._labelClientPort.Size = new System.Drawing.Size(55, 13);
         this._labelClientPort.TabIndex = 2;
         this._labelClientPort.Text = "ClientPort:";
         // 
         // _textBoxClientAE
         // 
         this._textBoxClientAE.Location = new System.Drawing.Point(111, 20);
         this._textBoxClientAE.Name = "_textBoxClientAE";
         this._textBoxClientAE.Size = new System.Drawing.Size(417, 20);
         this._textBoxClientAE.TabIndex = 1;
         // 
         // _labelClientAE
         // 
         this._labelClientAE.AutoSize = true;
         this._labelClientAE.Location = new System.Drawing.Point(16, 24);
         this._labelClientAE.Name = "_labelClientAE";
         this._labelClientAE.Size = new System.Drawing.Size(84, 13);
         this._labelClientAE.TabIndex = 0;
         this._labelClientAE.Text = "Client AE Name:";
         // 
         // _groupBoxCompression
         // 
         this._groupBoxCompression.Controls.Add(this._radioButtonCompressionLossless);
         this._groupBoxCompression.Controls.Add(this._radioButtonCompressionLossy);
         this._groupBoxCompression.Controls.Add(this._radioButtonCompressionNative);
         this._groupBoxCompression.Location = new System.Drawing.Point(8, 392);
         this._groupBoxCompression.Name = "_groupBoxCompression";
         this._groupBoxCompression.Size = new System.Drawing.Size(248, 80);
         this._groupBoxCompression.TabIndex = 3;
         this._groupBoxCompression.TabStop = false;
         this._groupBoxCompression.Text = "Compression";
         // 
         // _radioButtonCompressionLossless
         // 
         this._radioButtonCompressionLossless.AutoSize = true;
         this._radioButtonCompressionLossless.Location = new System.Drawing.Point(16, 55);
         this._radioButtonCompressionLossless.Name = "_radioButtonCompressionLossless";
         this._radioButtonCompressionLossless.Size = new System.Drawing.Size(65, 17);
         this._radioButtonCompressionLossless.TabIndex = 2;
         this._radioButtonCompressionLossless.TabStop = true;
         this._radioButtonCompressionLossless.Text = "Lo&ssless";
         this._radioButtonCompressionLossless.UseVisualStyleBackColor = true;
         // 
         // _radioButtonCompressionLossy
         // 
         this._radioButtonCompressionLossy.AutoSize = true;
         this._radioButtonCompressionLossy.Location = new System.Drawing.Point(16, 36);
         this._radioButtonCompressionLossy.Name = "_radioButtonCompressionLossy";
         this._radioButtonCompressionLossy.Size = new System.Drawing.Size(52, 17);
         this._radioButtonCompressionLossy.TabIndex = 1;
         this._radioButtonCompressionLossy.TabStop = true;
         this._radioButtonCompressionLossy.Text = "&Lossy";
         this._radioButtonCompressionLossy.UseVisualStyleBackColor = true;
         // 
         // _radioButtonCompressionNative
         // 
         this._radioButtonCompressionNative.AutoSize = true;
         this._radioButtonCompressionNative.Location = new System.Drawing.Point(16, 17);
         this._radioButtonCompressionNative.Name = "_radioButtonCompressionNative";
         this._radioButtonCompressionNative.Size = new System.Drawing.Size(56, 17);
         this._radioButtonCompressionNative.TabIndex = 0;
         this._radioButtonCompressionNative.TabStop = true;
         this._radioButtonCompressionNative.Text = "&Native";
         this._radioButtonCompressionNative.UseVisualStyleBackColor = true;
         // 
         // _buttonOK
         // 
         this._buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._buttonOK.Location = new System.Drawing.Point(199, 766);
         this._buttonOK.Name = "_buttonOK";
         this._buttonOK.Size = new System.Drawing.Size(75, 23);
         this._buttonOK.TabIndex = 9;
         this._buttonOK.Text = "&OK";
         this._buttonOK.UseVisualStyleBackColor = true;
         this._buttonOK.Click += new System.EventHandler(this._buttonOK_Click);
         // 
         // _buttonCancel
         // 
         this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._buttonCancel.Location = new System.Drawing.Point(287, 766);
         this._buttonCancel.Name = "_buttonCancel";
         this._buttonCancel.Size = new System.Drawing.Size(75, 23);
         this._buttonCancel.TabIndex = 10;
         this._buttonCancel.Text = "Cancel";
         this._buttonCancel.UseVisualStyleBackColor = true;
         // 
         // _groupBoxSecurity
         // 
         this._groupBoxSecurity.Controls.Add(this._labelCertificate);
         this._groupBoxSecurity.Controls.Add(this._labelHint);
         this._groupBoxSecurity.Controls.Add(this._buttonClientCertificate);
         this._groupBoxSecurity.Controls.Add(this._textBoxClientCertificate);
         this._groupBoxSecurity.Controls.Add(this._textBoxKeyPassword);
         this._groupBoxSecurity.Controls.Add(this._labelPrivateKeyPassword);
         this._groupBoxSecurity.Controls.Add(this._labelPrivateKey);
         this._groupBoxSecurity.Controls.Add(this._textBoxPrivateKey);
         this._groupBoxSecurity.Controls.Add(this._buttonPrivateKey);
         this._groupBoxSecurity.Location = new System.Drawing.Point(8, 89);
         this._groupBoxSecurity.Name = "_groupBoxSecurity";
         this._groupBoxSecurity.Size = new System.Drawing.Size(536, 103);
         this._groupBoxSecurity.TabIndex = 1;
         this._groupBoxSecurity.TabStop = false;
         this._groupBoxSecurity.Text = "Security";
         // 
         // _labelCertificate
         // 
         this._labelCertificate.AutoSize = true;
         this._labelCertificate.Location = new System.Drawing.Point(16, 20);
         this._labelCertificate.Name = "_labelCertificate";
         this._labelCertificate.Size = new System.Drawing.Size(57, 13);
         this._labelCertificate.TabIndex = 0;
         this._labelCertificate.Text = "Certificate:";
         // 
         // _labelHint
         // 
         this._labelHint.AutoSize = true;
         this._labelHint.ForeColor = System.Drawing.Color.Blue;
         this._labelHint.Location = new System.Drawing.Point(264, 72);
         this._labelHint.Name = "_labelHint";
         this._labelHint.Size = new System.Drawing.Size(140, 13);
         this._labelHint.TabIndex = 8;
         this._labelHint.Text = "<== Use \'test\'  for client.pem";
         // 
         // _buttonClientCertificate
         // 
         this._buttonClientCertificate.Image = ((System.Drawing.Image)(resources.GetObject("_buttonClientCertificate.Image")));
         this._buttonClientCertificate.Location = new System.Drawing.Point(80, 17);
         this._buttonClientCertificate.Name = "_buttonClientCertificate";
         this._buttonClientCertificate.Size = new System.Drawing.Size(23, 19);
         this._buttonClientCertificate.TabIndex = 1;
         this._buttonClientCertificate.UseVisualStyleBackColor = true;
         this._buttonClientCertificate.Click += new System.EventHandler(this._buttonClientCertificate_Click);
         // 
         // _textBoxClientCertificate
         // 
         this._textBoxClientCertificate.Location = new System.Drawing.Point(111, 16);
         this._textBoxClientCertificate.Name = "_textBoxClientCertificate";
         this._textBoxClientCertificate.Size = new System.Drawing.Size(417, 20);
         this._textBoxClientCertificate.TabIndex = 2;
         // 
         // _textBoxKeyPassword
         // 
         this._textBoxKeyPassword.Location = new System.Drawing.Point(111, 68);
         this._textBoxKeyPassword.Name = "_textBoxKeyPassword";
         this._textBoxKeyPassword.Size = new System.Drawing.Size(146, 20);
         this._textBoxKeyPassword.TabIndex = 7;
         // 
         // _labelPrivateKeyPassword
         // 
         this._labelPrivateKeyPassword.AutoSize = true;
         this._labelPrivateKeyPassword.Location = new System.Drawing.Point(16, 72);
         this._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword";
         this._labelPrivateKeyPassword.Size = new System.Drawing.Size(77, 13);
         this._labelPrivateKeyPassword.TabIndex = 6;
         this._labelPrivateKeyPassword.Text = "Key Password:";
         // 
         // _labelPrivateKey
         // 
         this._labelPrivateKey.AutoSize = true;
         this._labelPrivateKey.Location = new System.Drawing.Point(16, 46);
         this._labelPrivateKey.Name = "_labelPrivateKey";
         this._labelPrivateKey.Size = new System.Drawing.Size(64, 13);
         this._labelPrivateKey.TabIndex = 3;
         this._labelPrivateKey.Text = "Private Key:";
         // 
         // _textBoxPrivateKey
         // 
         this._textBoxPrivateKey.Location = new System.Drawing.Point(111, 42);
         this._textBoxPrivateKey.Name = "_textBoxPrivateKey";
         this._textBoxPrivateKey.Size = new System.Drawing.Size(417, 20);
         this._textBoxPrivateKey.TabIndex = 5;
         // 
         // _buttonPrivateKey
         // 
         this._buttonPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("_buttonPrivateKey.Image")));
         this._buttonPrivateKey.Location = new System.Drawing.Point(80, 43);
         this._buttonPrivateKey.Name = "_buttonPrivateKey";
         this._buttonPrivateKey.Size = new System.Drawing.Size(23, 19);
         this._buttonPrivateKey.TabIndex = 4;
         this._buttonPrivateKey.UseVisualStyleBackColor = true;
         this._buttonPrivateKey.Click += new System.EventHandler(this._buttonPrivateKey_Click);
         // 
         // buttonDeleteServer
         // 
         this.buttonDeleteServer.CausesValidation = false;
         this.buttonDeleteServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteServer.Image")));
         this.buttonDeleteServer.Location = new System.Drawing.Point(48, 566);
         this.buttonDeleteServer.Name = "buttonDeleteServer";
         this.buttonDeleteServer.Size = new System.Drawing.Size(40, 39);
         this.buttonDeleteServer.TabIndex = 7;
         this.buttonDeleteServer.UseVisualStyleBackColor = true;
         this.buttonDeleteServer.Click += new System.EventHandler(this.buttonDeleteServer_Click);
         // 
         // buttonAddServer
         // 
         this.buttonAddServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddServer.Image")));
         this.buttonAddServer.Location = new System.Drawing.Point(8, 566);
         this.buttonAddServer.Name = "buttonAddServer";
         this.buttonAddServer.Size = new System.Drawing.Size(40, 39);
         this.buttonAddServer.TabIndex = 6;
         this.buttonAddServer.UseVisualStyleBackColor = true;
         this.buttonAddServer.Click += new System.EventHandler(this.buttonAddServer_Click);
         // 
         // dataGridViewServers
         // 
         this.dataGridViewServers.AllowUserToAddRows = false;
         this.dataGridViewServers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dataGridViewServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridViewServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAE,
            this.ColumnIP,
            this.ColumnPort,
            this.ColumnTimeout,
            this.ColumnTls});
         this.dataGridViewServers.Location = new System.Drawing.Point(8, 606);
         this.dataGridViewServers.Name = "dataGridViewServers";
         this.dataGridViewServers.Size = new System.Drawing.Size(544, 150);
         this.dataGridViewServers.TabIndex = 8;
         this.dataGridViewServers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewServers_CurrentCellDirtyStateChanged);
         this.dataGridViewServers.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewServers_RowValidating);
         // 
         // ColumnAE
         // 
         this.ColumnAE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
         this.ColumnAE.HeaderText = "Server AE Title";
         this.ColumnAE.Name = "ColumnAE";
         // 
         // ColumnIP
         // 
         this.ColumnIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.ColumnIP.HeaderText = "Server IP Address";
         this.ColumnIP.Name = "ColumnIP";
         this.ColumnIP.Width = 107;
         // 
         // ColumnPort
         // 
         this.ColumnPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
         this.ColumnPort.HeaderText = "Server Port";
         this.ColumnPort.Name = "ColumnPort";
         this.ColumnPort.Width = 78;
         // 
         // ColumnTimeout
         // 
         this.ColumnTimeout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
         this.ColumnTimeout.HeaderText = "Timeout (sec)";
         this.ColumnTimeout.Name = "ColumnTimeout";
         this.ColumnTimeout.Width = 88;
         // 
         // ColumnTls
         // 
         this.ColumnTls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.ColumnTls.HeaderText = "Secure (TLS)";
         this.ColumnTls.Name = "ColumnTls";
         this.ColumnTls.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this.ColumnTls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         this.ColumnTls.Width = 87;
         // 
         // _groupBoxStorageCommit
         // 
         this._groupBoxStorageCommit.Controls.Add(this._radioButtonWaitForResults);
         this._groupBoxStorageCommit.Controls.Add(this._radioButtonNoWaitForResults);
         this._groupBoxStorageCommit.Location = new System.Drawing.Point(262, 392);
         this._groupBoxStorageCommit.Name = "_groupBoxStorageCommit";
         this._groupBoxStorageCommit.Size = new System.Drawing.Size(282, 80);
         this._groupBoxStorageCommit.TabIndex = 4;
         this._groupBoxStorageCommit.TabStop = false;
         this._groupBoxStorageCommit.Text = "Storage Commit";
         // 
         // _radioButtonWaitForResults
         // 
         this._radioButtonWaitForResults.AutoSize = true;
         this._radioButtonWaitForResults.Location = new System.Drawing.Point(15, 17);
         this._radioButtonWaitForResults.Name = "_radioButtonWaitForResults";
         this._radioButtonWaitForResults.Size = new System.Drawing.Size(202, 17);
         this._radioButtonWaitForResults.TabIndex = 0;
         this._radioButtonWaitForResults.TabStop = true;
         this._radioButtonWaitForResults.Text = "Wait for Results on Same Association";
         this._radioButtonWaitForResults.UseVisualStyleBackColor = true;
         // 
         // _radioButtonNoWaitForResults
         // 
         this._radioButtonNoWaitForResults.AutoSize = true;
         this._radioButtonNoWaitForResults.Location = new System.Drawing.Point(15, 36);
         this._radioButtonNoWaitForResults.Name = "_radioButtonNoWaitForResults";
         this._radioButtonNoWaitForResults.Size = new System.Drawing.Size(256, 17);
         this._radioButtonNoWaitForResults.TabIndex = 1;
         this._radioButtonNoWaitForResults.TabStop = true;
         this._radioButtonNoWaitForResults.Text = "No Wait for Results (Results on new Association)";
         this._radioButtonNoWaitForResults.UseVisualStyleBackColor = true;
         // 
         // _groupMiscellaneous
         // 
         this._groupMiscellaneous.Controls.Add(this.label1);
         this._groupMiscellaneous.Controls.Add(this._checkBoxDisableLogging);
         this._groupMiscellaneous.Controls.Add(this._labelLogLowLevel);
         this._groupMiscellaneous.Controls.Add(this._checkBoxLogLowLevel);
         this._groupMiscellaneous.Controls.Add(this._checkBoxGroupLengthDataElements);
         this._groupMiscellaneous.Location = new System.Drawing.Point(8, 478);
         this._groupMiscellaneous.Name = "_groupMiscellaneous";
         this._groupMiscellaneous.Size = new System.Drawing.Size(536, 80);
         this._groupMiscellaneous.TabIndex = 5;
         this._groupMiscellaneous.TabStop = false;
         this._groupMiscellaneous.Text = "Miscellaneous";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.ForeColor = System.Drawing.Color.Green;
         this.label1.Location = new System.Drawing.Point(138, 60);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(227, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "<== Disable logging for Optimized Performance";
         // 
         // _checkBoxDisableLogging
         // 
         this._checkBoxDisableLogging.AutoSize = true;
         this._checkBoxDisableLogging.Location = new System.Drawing.Point(15, 58);
         this._checkBoxDisableLogging.Name = "_checkBoxDisableLogging";
         this._checkBoxDisableLogging.Size = new System.Drawing.Size(102, 17);
         this._checkBoxDisableLogging.TabIndex = 3;
         this._checkBoxDisableLogging.Text = "Disable Logging";
         this._checkBoxDisableLogging.UseVisualStyleBackColor = true;
         // 
         // _labelLogLowLevel
         // 
         this._labelLogLowLevel.AutoSize = true;
         this._labelLogLowLevel.ForeColor = System.Drawing.Color.Green;
         this._labelLogLowLevel.Location = new System.Drawing.Point(138, 41);
         this._labelLogLowLevel.Name = "_labelLogLowLevel";
         this._labelLogLowLevel.Size = new System.Drawing.Size(189, 13);
         this._labelLogLowLevel.TabIndex = 2;
         this._labelLogLowLevel.Text = "<== Displayed green in the log window";
         // 
         // _checkBoxLogLowLevel
         // 
         this._checkBoxLogLowLevel.AutoSize = true;
         this._checkBoxLogLowLevel.Location = new System.Drawing.Point(15, 39);
         this._checkBoxLogLowLevel.Name = "_checkBoxLogLowLevel";
         this._checkBoxLogLowLevel.Size = new System.Drawing.Size(116, 17);
         this._checkBoxLogLowLevel.TabIndex = 1;
         this._checkBoxLogLowLevel.Text = "Low Level Logging";
         this._checkBoxLogLowLevel.UseVisualStyleBackColor = true;
         // 
         // _checkBoxGroupLengthDataElements
         // 
         this._checkBoxGroupLengthDataElements.AutoSize = true;
         this._checkBoxGroupLengthDataElements.Location = new System.Drawing.Point(15, 20);
         this._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements";
         this._checkBoxGroupLengthDataElements.Size = new System.Drawing.Size(201, 17);
         this._checkBoxGroupLengthDataElements.TabIndex = 0;
         this._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements";
         this._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = true;
         // 
         // groupBoxCipherSuites
         // 
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveDown);
         this.groupBoxCipherSuites.Controls.Add(this._checkBoxTlsOld);
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveUp);
         this.groupBoxCipherSuites.Controls.Add(this._listViewCipherSuites);
         this.groupBoxCipherSuites.Location = new System.Drawing.Point(8, 196);
         this.groupBoxCipherSuites.Name = "groupBoxCipherSuites";
         this.groupBoxCipherSuites.Size = new System.Drawing.Size(536, 190);
         this.groupBoxCipherSuites.TabIndex = 2;
         this.groupBoxCipherSuites.TabStop = false;
         this.groupBoxCipherSuites.Text = "Cipher Suites";
         // 
         // _buttonMoveDown
         // 
         this._buttonMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this._buttonMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("_buttonMoveDown.Image")));
         this._buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
         this._buttonMoveDown.Location = new System.Drawing.Point(16, 120);
         this._buttonMoveDown.Name = "_buttonMoveDown";
         this._buttonMoveDown.Size = new System.Drawing.Size(85, 38);
         this._buttonMoveDown.TabIndex = 1;
         this._buttonMoveDown.Text = "Low Priority";
         this._buttonMoveDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         this._buttonMoveDown.UseVisualStyleBackColor = true;
         this._buttonMoveDown.Click += new System.EventHandler(this._buttonMoveDown_Click);
         // 
         // _checkBoxTlsOld
         // 
         this._checkBoxTlsOld.AutoSize = true;
         this._checkBoxTlsOld.Location = new System.Drawing.Point(110, 164);
         this._checkBoxTlsOld.Name = "_checkBoxTlsOld";
         this._checkBoxTlsOld.Size = new System.Drawing.Size(235, 17);
         this._checkBoxTlsOld.TabIndex = 3;
         this._checkBoxTlsOld.Text = "Include TLS 1.0 Cipher Suites (Less Secure)";
         this._checkBoxTlsOld.UseVisualStyleBackColor = true;
         this._checkBoxTlsOld.CheckedChanged += new System.EventHandler(this._checkBoxTlsOld_CheckedChanged);
         // 
         // _buttonMoveUp
         // 
         this._buttonMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this._buttonMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("_buttonMoveUp.Image")));
         this._buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this._buttonMoveUp.Location = new System.Drawing.Point(16, 16);
         this._buttonMoveUp.Name = "_buttonMoveUp";
         this._buttonMoveUp.Size = new System.Drawing.Size(85, 38);
         this._buttonMoveUp.TabIndex = 0;
         this._buttonMoveUp.Text = "High Priority";
         this._buttonMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this._buttonMoveUp.UseVisualStyleBackColor = true;
         this._buttonMoveUp.Click += new System.EventHandler(this._buttonMoveUp_Click);
         // 
         // _listViewCipherSuites
         // 
         this._listViewCipherSuites.Location = new System.Drawing.Point(110, 16);
         this._listViewCipherSuites.Name = "_listViewCipherSuites";
         this._listViewCipherSuites.Size = new System.Drawing.Size(418, 142);
         this._listViewCipherSuites.TabIndex = 2;
         this._listViewCipherSuites.UseCompatibleStateImageBehavior = false;
         // 
         // imageListCiphers
         // 
         this.imageListCiphers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCiphers.ImageStream")));
         this.imageListCiphers.TransparentColor = System.Drawing.Color.Transparent;
         this.imageListCiphers.Images.SetKeyName(0, "yellowBullet.png");
         this.imageListCiphers.Images.SetKeyName(1, "yellowBullet.png");
         this.imageListCiphers.Images.SetKeyName(2, "greenBullet.png");
         // 
         // OptionsDialog
         // 
         this.AcceptButton = this._buttonOK;
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
         this.CancelButton = this._buttonCancel;
         this.ClientSize = new System.Drawing.Size(560, 794);
         this.Controls.Add(this.groupBoxCipherSuites);
         this.Controls.Add(this._groupMiscellaneous);
         this.Controls.Add(this._groupBoxStorageCommit);
         this.Controls.Add(this.buttonDeleteServer);
         this.Controls.Add(this.buttonAddServer);
         this.Controls.Add(this.dataGridViewServers);
         this.Controls.Add(this._groupBoxSecurity);
         this.Controls.Add(this._buttonCancel);
         this.Controls.Add(this._buttonOK);
         this.Controls.Add(this._groupBoxCompression);
         this.Controls.Add(this._groupBoxClient);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "OptionsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Options";
         this.Load += new System.EventHandler(this.OptionsDialog_Load);
         this._groupBoxClient.ResumeLayout(false);
         this._groupBoxClient.PerformLayout();
         this._groupBoxCompression.ResumeLayout(false);
         this._groupBoxCompression.PerformLayout();
         this._groupBoxSecurity.ResumeLayout(false);
         this._groupBoxSecurity.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServers)).EndInit();
         this._groupBoxStorageCommit.ResumeLayout(false);
         this._groupBoxStorageCommit.PerformLayout();
         this._groupMiscellaneous.ResumeLayout(false);
         this._groupMiscellaneous.PerformLayout();
         this.groupBoxCipherSuites.ResumeLayout(false);
         this.groupBoxCipherSuites.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _groupBoxClient;
      private System.Windows.Forms.GroupBox _groupBoxCompression;
      private System.Windows.Forms.Button _buttonOK;
      private System.Windows.Forms.Button _buttonCancel;
      private System.Windows.Forms.TextBox _textBoxClientAE;
      private System.Windows.Forms.Label _labelClientAE;
      private System.Windows.Forms.RadioButton _radioButtonCompressionLossless;
      private System.Windows.Forms.RadioButton _radioButtonCompressionLossy;
      private System.Windows.Forms.RadioButton _radioButtonCompressionNative;
       private System.Windows.Forms.GroupBox _groupBoxSecurity;
       private System.Windows.Forms.Label _labelCertificate;
       private System.Windows.Forms.Label _labelHint;
       private System.Windows.Forms.Button _buttonClientCertificate;
       private System.Windows.Forms.TextBox _textBoxClientCertificate;
       private System.Windows.Forms.TextBox _textBoxKeyPassword;
       private System.Windows.Forms.Label _labelPrivateKeyPassword;
       private System.Windows.Forms.Label _labelPrivateKey;
       private System.Windows.Forms.TextBox _textBoxPrivateKey;
       private System.Windows.Forms.Button _buttonPrivateKey;
       private System.Windows.Forms.Button buttonDeleteServer;
       private System.Windows.Forms.Button buttonAddServer;
       private System.Windows.Forms.DataGridView dataGridViewServers;
       private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAE;
       private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIP;
       private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPort;
       private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTimeout;
       private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTls;
       private System.Windows.Forms.GroupBox _groupBoxStorageCommit;
       private System.Windows.Forms.TextBox _textBoxClientPort;
       private System.Windows.Forms.Label _labelClientPort;
       private System.Windows.Forms.RadioButton _radioButtonWaitForResults;
       private System.Windows.Forms.RadioButton _radioButtonNoWaitForResults;
       private System.Windows.Forms.GroupBox _groupMiscellaneous;
       private System.Windows.Forms.CheckBox _checkBoxGroupLengthDataElements;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox _checkBoxDisableLogging;
      private System.Windows.Forms.Label _labelLogLowLevel;
      private System.Windows.Forms.CheckBox _checkBoxLogLowLevel;
      private System.Windows.Forms.GroupBox groupBoxCipherSuites;
      private System.Windows.Forms.Button _buttonMoveDown;
      private System.Windows.Forms.CheckBox _checkBoxTlsOld;
      private System.Windows.Forms.Button _buttonMoveUp;
      private System.Windows.Forms.ListView _listViewCipherSuites;
      private System.Windows.Forms.ImageList imageListCiphers;
   }
}