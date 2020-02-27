// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for OptionsDialog.
   /// </summary>
   public class OptionsDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private System.ComponentModel.IContainer components;
      private string _clientAE;
      private string _clientCertificate;
      private string _privateKey;
      private string _privateKeyPassword;
      private bool _logLowLevel;
      private bool _groupLengthDataElements;

      private string _Mwl;
      private string _Mpps;
      private string _Storage;

      private GroupBox _groupBoxClient;
      private TextBox _textBoxClientAE;
      private Label _labelClientAE;
      private GroupBox _groupBoxSecurity;
      private Label _labelCertificate;
      private Label _labelHint;
      private Button _buttonClientCertificate;
      private TextBox _textBoxClientCertificate;
      private TextBox _textBoxKeyPassword;
      private Label _labelPrivateKeyPassword;
      private Label _labelPrivateKey;
      private TextBox _textBoxPrivateKey;
      private Button _buttonPrivateKey;
      private GroupBox _groupBoxServers;
      private Button buttonDeleteServer;
      private Button buttonAddServer;
      private DataGridView dataGridViewServers;
      private DataGridViewTextBoxColumn ColumnAE;
      private DataGridViewTextBoxColumn ColumnIP;
      private DataGridViewTextBoxColumn ColumnPort;
      private DataGridViewTextBoxColumn ColumnTimeout;
      private GroupBox _groupMiscellaneous;
      private CheckBox _checkBoxGroupLengthDataElements;
      private GroupBox groupBoxCipherSuites;
      private Button _buttonMoveDown;
      private CheckBox _checkBoxTlsOld;
      private Button _buttonMoveUp;
      private ListView _listViewCipherSuites;
      private Label _labelLogLowLevel;
      private CheckBox _checkBoxLogLowLevel;
      private ImageList imageListCiphers;
      private DataGridViewCheckBoxColumn ColumnTls;

      public List<DicomAE> ServerList
      {
         get
         {
            //MyServer[] items = new MyServer[dataGridViewServers.Rows.Count];
            List<DicomAE> items = new List<DicomAE>(dataGridViewServers.Rows.Count);
            for (int i = 0; i < dataGridViewServers.Rows.Count; i++)
            {
               DicomAE server = new DicomAE();
               server.AE = dataGridViewServers.Rows[i].Cells["ColumnAE"].Value.ToString();
               server.IPAddress = dataGridViewServers.Rows[i].Cells["ColumnIP"].Value.ToString();
               server.Timeout = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnTimeout"].Value);
               server.Port = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnPort"].Value);
               server.UseTls = Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value);

               items.Add(server);
            }
            return items;
         }

         set
         {
            foreach (DicomAE s in value)
            {
               int n = dataGridViewServers.Rows.Add();
               dataGridViewServers.Rows[n].Cells["ColumnAE"].Value = s.AE;
               dataGridViewServers.Rows[n].Cells["ColumnIP"].Value = s.IPAddress;
               dataGridViewServers.Rows[n].Cells["ColumnTimeout"].Value = s.Timeout.ToString();
               dataGridViewServers.Rows[n].Cells["ColumnPort"].Value = s.Port.ToString();
               dataGridViewServers.Rows[n].Cells["ColumnTls"].Value = s.UseTls.ToString();
            }
         }
      }

      public string Mwl
      {
         get { return _Mwl; }
         set { _Mwl = value; }
      }

      public string Mpps
      {
         get { return _Mpps; }
         set { _Mpps = value; }
      }

      public string Storage
      {
         get { return _Storage; }
         set { _Storage = value; }
      }


      public OptionsDialog()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();         
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this._groupBoxClient = new System.Windows.Forms.GroupBox();
         this._textBoxClientAE = new System.Windows.Forms.TextBox();
         this._labelClientAE = new System.Windows.Forms.Label();
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
         this._groupBoxServers = new System.Windows.Forms.GroupBox();
         this.buttonDeleteServer = new System.Windows.Forms.Button();
         this.buttonAddServer = new System.Windows.Forms.Button();
         this.dataGridViewServers = new System.Windows.Forms.DataGridView();
         this.ColumnAE = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTls = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this._groupMiscellaneous = new System.Windows.Forms.GroupBox();
         this._checkBoxGroupLengthDataElements = new System.Windows.Forms.CheckBox();
         this._labelLogLowLevel = new System.Windows.Forms.Label();
         this._checkBoxLogLowLevel = new System.Windows.Forms.CheckBox();
         this.groupBoxCipherSuites = new System.Windows.Forms.GroupBox();
         this._buttonMoveDown = new System.Windows.Forms.Button();
         this._checkBoxTlsOld = new System.Windows.Forms.CheckBox();
         this._buttonMoveUp = new System.Windows.Forms.Button();
         this._listViewCipherSuites = new System.Windows.Forms.ListView();
         this.imageListCiphers = new System.Windows.Forms.ImageList(this.components);
         this._groupBoxClient.SuspendLayout();
         this._groupBoxSecurity.SuspendLayout();
         this._groupBoxServers.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServers)).BeginInit();
         this._groupMiscellaneous.SuspendLayout();
         this.groupBoxCipherSuites.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(192, 657);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 4;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(273, 657);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 5;
         this.buttonCancel.Text = "&Cancel";
         // 
         // _groupBoxClient
         // 
         this._groupBoxClient.Controls.Add(this._textBoxClientAE);
         this._groupBoxClient.Controls.Add(this._labelClientAE);
         this._groupBoxClient.Location = new System.Drawing.Point(8, 10);
         this._groupBoxClient.Name = "_groupBoxClient";
         this._groupBoxClient.Size = new System.Drawing.Size(536, 50);
         this._groupBoxClient.TabIndex = 0;
         this._groupBoxClient.TabStop = false;
         this._groupBoxClient.Text = "Client Information";
         // 
         // _textBoxClientAE
         // 
         this._textBoxClientAE.Location = new System.Drawing.Point(111, 18);
         this._textBoxClientAE.Name = "_textBoxClientAE";
         this._textBoxClientAE.Size = new System.Drawing.Size(417, 20);
         this._textBoxClientAE.TabIndex = 1;
         // 
         // _labelClientAE
         // 
         this._labelClientAE.AutoSize = true;
         this._labelClientAE.Location = new System.Drawing.Point(16, 22);
         this._labelClientAE.Name = "_labelClientAE";
         this._labelClientAE.Size = new System.Drawing.Size(84, 13);
         this._labelClientAE.TabIndex = 0;
         this._labelClientAE.Text = "Client AE Name:";
         // 
         // _groupBoxSecurity
         // 
         this._groupBoxSecurity.Controls.Add(this.groupBoxCipherSuites);
         this._groupBoxSecurity.Controls.Add(this._labelCertificate);
         this._groupBoxSecurity.Controls.Add(this._labelHint);
         this._groupBoxSecurity.Controls.Add(this._buttonClientCertificate);
         this._groupBoxSecurity.Controls.Add(this._textBoxClientCertificate);
         this._groupBoxSecurity.Controls.Add(this._textBoxKeyPassword);
         this._groupBoxSecurity.Controls.Add(this._labelPrivateKeyPassword);
         this._groupBoxSecurity.Controls.Add(this._labelPrivateKey);
         this._groupBoxSecurity.Controls.Add(this._textBoxPrivateKey);
         this._groupBoxSecurity.Controls.Add(this._buttonPrivateKey);
         this._groupBoxSecurity.Location = new System.Drawing.Point(8, 74);
         this._groupBoxSecurity.Name = "_groupBoxSecurity";
         this._groupBoxSecurity.Size = new System.Drawing.Size(536, 287);
         this._groupBoxSecurity.TabIndex = 1;
         this._groupBoxSecurity.TabStop = false;
         this._groupBoxSecurity.Text = "Security";
         // 
         // _labelCertificate
         // 
         this._labelCertificate.AutoSize = true;
         this._labelCertificate.Location = new System.Drawing.Point(16, 22);
         this._labelCertificate.Name = "_labelCertificate";
         this._labelCertificate.Size = new System.Drawing.Size(57, 13);
         this._labelCertificate.TabIndex = 0;
         this._labelCertificate.Text = "Certificate:";
         // 
         // _labelHint
         // 
         this._labelHint.AutoSize = true;
         this._labelHint.ForeColor = System.Drawing.Color.Blue;
         this._labelHint.Location = new System.Drawing.Point(264, 74);
         this._labelHint.Name = "_labelHint";
         this._labelHint.Size = new System.Drawing.Size(140, 13);
         this._labelHint.TabIndex = 8;
         this._labelHint.Text = "<== Use \'test\'  for client.pem";
         // 
         // _buttonClientCertificate
         // 
         this._buttonClientCertificate.Image = ((System.Drawing.Image)(resources.GetObject("_buttonClientCertificate.Image")));
         this._buttonClientCertificate.Location = new System.Drawing.Point(80, 19);
         this._buttonClientCertificate.Name = "_buttonClientCertificate";
         this._buttonClientCertificate.Size = new System.Drawing.Size(23, 19);
         this._buttonClientCertificate.TabIndex = 1;
         this._buttonClientCertificate.UseVisualStyleBackColor = true;
         this._buttonClientCertificate.Click += new System.EventHandler(this._buttonClientCertificate_Click);
         // 
         // _textBoxClientCertificate
         // 
         this._textBoxClientCertificate.Location = new System.Drawing.Point(111, 18);
         this._textBoxClientCertificate.Name = "_textBoxClientCertificate";
         this._textBoxClientCertificate.Size = new System.Drawing.Size(417, 20);
         this._textBoxClientCertificate.TabIndex = 2;
         // 
         // _textBoxKeyPassword
         // 
         this._textBoxKeyPassword.Location = new System.Drawing.Point(111, 71);
         this._textBoxKeyPassword.Name = "_textBoxKeyPassword";
         this._textBoxKeyPassword.Size = new System.Drawing.Size(52, 20);
         this._textBoxKeyPassword.TabIndex = 7;
         // 
         // _labelPrivateKeyPassword
         // 
         this._labelPrivateKeyPassword.AutoSize = true;
         this._labelPrivateKeyPassword.Location = new System.Drawing.Point(16, 71);
         this._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword";
         this._labelPrivateKeyPassword.Size = new System.Drawing.Size(77, 13);
         this._labelPrivateKeyPassword.TabIndex = 6;
         this._labelPrivateKeyPassword.Text = "Key Password:";
         // 
         // _labelPrivateKey
         // 
         this._labelPrivateKey.AutoSize = true;
         this._labelPrivateKey.Location = new System.Drawing.Point(16, 45);
         this._labelPrivateKey.Name = "_labelPrivateKey";
         this._labelPrivateKey.Size = new System.Drawing.Size(64, 13);
         this._labelPrivateKey.TabIndex = 3;
         this._labelPrivateKey.Text = "Private Key:";
         // 
         // _textBoxPrivateKey
         // 
         this._textBoxPrivateKey.Location = new System.Drawing.Point(111, 45);
         this._textBoxPrivateKey.Name = "_textBoxPrivateKey";
         this._textBoxPrivateKey.Size = new System.Drawing.Size(417, 20);
         this._textBoxPrivateKey.TabIndex = 5;
         // 
         // _buttonPrivateKey
         // 
         this._buttonPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("_buttonPrivateKey.Image")));
         this._buttonPrivateKey.Location = new System.Drawing.Point(80, 45);
         this._buttonPrivateKey.Name = "_buttonPrivateKey";
         this._buttonPrivateKey.Size = new System.Drawing.Size(23, 19);
         this._buttonPrivateKey.TabIndex = 4;
         this._buttonPrivateKey.UseVisualStyleBackColor = true;
         this._buttonPrivateKey.Click += new System.EventHandler(this._buttonPrivateKey_Click);
         // 
         // _groupBoxServers
         // 
         this._groupBoxServers.Controls.Add(this.buttonDeleteServer);
         this._groupBoxServers.Controls.Add(this.buttonAddServer);
         this._groupBoxServers.Controls.Add(this.dataGridViewServers);
         this._groupBoxServers.Location = new System.Drawing.Point(8, 441);
         this._groupBoxServers.Name = "_groupBoxServers";
         this._groupBoxServers.Size = new System.Drawing.Size(536, 211);
         this._groupBoxServers.TabIndex = 3;
         this._groupBoxServers.TabStop = false;
         this._groupBoxServers.Text = "Server Information";
         // 
         // buttonDeleteServer
         // 
         this.buttonDeleteServer.CausesValidation = false;
         this.buttonDeleteServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteServer.Image")));
         this.buttonDeleteServer.Location = new System.Drawing.Point(48, 17);
         this.buttonDeleteServer.Name = "buttonDeleteServer";
         this.buttonDeleteServer.Size = new System.Drawing.Size(40, 39);
         this.buttonDeleteServer.TabIndex = 1;
         this.buttonDeleteServer.UseVisualStyleBackColor = true;
         this.buttonDeleteServer.Click += new System.EventHandler(this.buttonDeleteServer_Click);
         // 
         // buttonAddServer
         // 
         this.buttonAddServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddServer.Image")));
         this.buttonAddServer.Location = new System.Drawing.Point(8, 17);
         this.buttonAddServer.Name = "buttonAddServer";
         this.buttonAddServer.Size = new System.Drawing.Size(40, 39);
         this.buttonAddServer.TabIndex = 0;
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
         this.dataGridViewServers.Location = new System.Drawing.Point(8, 57);
         this.dataGridViewServers.Name = "dataGridViewServers";
         this.dataGridViewServers.Size = new System.Drawing.Size(528, 150);
         this.dataGridViewServers.TabIndex = 2;
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
         // _groupMiscellaneous
         // 
         this._groupMiscellaneous.Controls.Add(this._labelLogLowLevel);
         this._groupMiscellaneous.Controls.Add(this._checkBoxLogLowLevel);
         this._groupMiscellaneous.Controls.Add(this._checkBoxGroupLengthDataElements);
         this._groupMiscellaneous.Location = new System.Drawing.Point(8, 379);
         this._groupMiscellaneous.Name = "_groupMiscellaneous";
         this._groupMiscellaneous.Size = new System.Drawing.Size(536, 56);
         this._groupMiscellaneous.TabIndex = 2;
         this._groupMiscellaneous.TabStop = false;
         this._groupMiscellaneous.Text = "Miscellaneous";
         // 
         // _checkBoxGroupLengthDataElements
         // 
         this._checkBoxGroupLengthDataElements.AutoSize = true;
         this._checkBoxGroupLengthDataElements.Location = new System.Drawing.Point(15, 14);
         this._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements";
         this._checkBoxGroupLengthDataElements.Size = new System.Drawing.Size(201, 17);
         this._checkBoxGroupLengthDataElements.TabIndex = 0;
         this._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements";
         this._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = true;
         // 
         // _labelLogLowLevel
         // 
         this._labelLogLowLevel.AutoSize = true;
         this._labelLogLowLevel.ForeColor = System.Drawing.Color.Green;
         this._labelLogLowLevel.Location = new System.Drawing.Point(138, 35);
         this._labelLogLowLevel.Name = "_labelLogLowLevel";
         this._labelLogLowLevel.Size = new System.Drawing.Size(189, 13);
         this._labelLogLowLevel.TabIndex = 2;
         this._labelLogLowLevel.Text = "<== Displayed green in the log window";
         // 
         // _checkBoxLogLowLevel
         // 
         this._checkBoxLogLowLevel.AutoSize = true;
         this._checkBoxLogLowLevel.Location = new System.Drawing.Point(15, 33);
         this._checkBoxLogLowLevel.Name = "_checkBoxLogLowLevel";
         this._checkBoxLogLowLevel.Size = new System.Drawing.Size(116, 17);
         this._checkBoxLogLowLevel.TabIndex = 1;
         this._checkBoxLogLowLevel.Text = "Low Level Logging";
         this._checkBoxLogLowLevel.UseVisualStyleBackColor = true;
         // 
         // groupBoxCipherSuites
         // 
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveDown);
         this.groupBoxCipherSuites.Controls.Add(this._checkBoxTlsOld);
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveUp);
         this.groupBoxCipherSuites.Controls.Add(this._listViewCipherSuites);
         this.groupBoxCipherSuites.Location = new System.Drawing.Point(0, 97);
         this.groupBoxCipherSuites.Name = "groupBoxCipherSuites";
         this.groupBoxCipherSuites.Size = new System.Drawing.Size(536, 190);
         this.groupBoxCipherSuites.TabIndex = 9;
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
         this._listViewCipherSuites.Location = new System.Drawing.Point(111, 16);
         this._listViewCipherSuites.Name = "_listViewCipherSuites";
         this._listViewCipherSuites.Size = new System.Drawing.Size(417, 142);
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
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(560, 686);
         this.Controls.Add(this._groupMiscellaneous);
         this.Controls.Add(this._groupBoxServers);
         this.Controls.Add(this._groupBoxSecurity);
         this.Controls.Add(this._groupBoxClient);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "OptionsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Options";
         this.Load += new System.EventHandler(this.OptionsDialog_Load);
         this._groupBoxClient.ResumeLayout(false);
         this._groupBoxClient.PerformLayout();
         this._groupBoxSecurity.ResumeLayout(false);
         this._groupBoxSecurity.PerformLayout();
         this._groupBoxServers.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServers)).EndInit();
         this._groupMiscellaneous.ResumeLayout(false);
         this._groupMiscellaneous.PerformLayout();
         this.groupBoxCipherSuites.ResumeLayout(false);
         this.groupBoxCipherSuites.PerformLayout();
         this.ResumeLayout(false);

      }
      #endregion

      public bool LogLowLevel
      {
         get { return _logLowLevel; }
         set { _logLowLevel = value; }
      }

      public bool GroupLengthDataElements
      {
         get { return _groupLengthDataElements; }
         set { _groupLengthDataElements = value;}
      }

      public string PrivateKeyPassword
      {
         get { return _privateKeyPassword; }
         set { _privateKeyPassword = value; }
      }

      public string PrivateKey
      {
         get { return _privateKey; }
         set { _privateKey = value; }
      }

      public string ClientCertificate
      {
         get { return _clientCertificate; }
         set { _clientCertificate = value; }
      }
      
      public string ClientAE
      {
         get { return _clientAE; }
         set { _clientAE = value; }
      }

      private void ServerIp_KeyPress
      (
         object sender,
         System.Windows.Forms.KeyPressEventArgs e
      )
      {
         bool bValid = Char.IsNumber(e.KeyChar) || (e.KeyChar == '.') || Char.IsControl(e.KeyChar);
         e.Handled = !bValid;
      }


      private void Port_KeyPress
      (
         object sender,
         System.Windows.Forms.KeyPressEventArgs e
      )
      {
         if(!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
         {
            e.Handled = true;
         }
      }

      private bool CheckInteger(TextBox tb, Label lb)
      {
         try
         {
            Convert.ToInt32(tb.Text);
            return true;
         }
         catch (Exception)
         {
            if (tb.Text.Trim() == string.Empty)
               MessageBox.Show("Invalid " + lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
            return false;
         }
      }

      private bool CheckIP(TextBox tb, Label lb)
      {
         try
         {
            System.Net.IPAddress.Parse(tb.Text);
            return true;
         }
         catch (Exception)
         {
            if (tb.Text.Trim() == string.Empty)
               MessageBox.Show("Invalid " + lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
            return false;
         }
      }

      private bool CheckFileExists(TextBox tb, bool showMessageBox)
      {
         bool ret = true;
         string sMsg = string.Empty;
         string sFile = tb.Text.Trim();
         if (sFile.Length == 0)
         {
            sMsg = "File can not be empty if 'Use Secure TLS Communication' is checked.";
            ret = false;
         }
         else if (!File.Exists(sFile))
         {
            sMsg = "File does not exist: " + sFile;
            ret = false;
         }
         if ((ret == false) && showMessageBox)
         {
            MessageBox.Show(sMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
         }
         return ret;
      }

      // Return true if any of the servers are using tls
      // Return false if all of the servers do not use tls
      private bool IsAnyServerUseTls()
      {
         for (int i = 0; i < dataGridViewServers.Rows.Count; i++)
         {
            if (Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value))
               return true;
         }
         return false;
      }

      private void buttonOK_Click(object sender, System.EventArgs e)
      {
         if (IsAnyServerUseTls())
         {
            if (!CheckFileExists(_textBoxClientCertificate, true))
               return;
            if (!CheckFileExists(_textBoxPrivateKey, true))
               return;
         }

         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing);

         ClientAE = _textBoxClientAE.Text;
         ClientCertificate = _textBoxClientCertificate.Text;
         PrivateKey = _textBoxPrivateKey.Text;
         PrivateKeyPassword = _textBoxKeyPassword.Text;
         LogLowLevel = _checkBoxLogLowLevel.Checked;
         GroupLengthDataElements = _checkBoxGroupLengthDataElements.Checked;
      }

      private void EnableDialogItems()
      {
         bool enable = IsAnyServerUseTls();
         _labelCertificate.Enabled = enable;
         _buttonClientCertificate.Enabled = enable;
         _textBoxClientCertificate.Enabled = enable;

         _labelPrivateKey.Enabled = enable;
         _buttonClientCertificate.Enabled = enable;
         _textBoxClientCertificate.Enabled = enable;

         _labelPrivateKey.Enabled = enable;
         _buttonPrivateKey.Enabled = enable;
         _textBoxPrivateKey.Enabled = enable;

         _labelPrivateKeyPassword.Enabled = enable;
         _textBoxKeyPassword.Enabled = enable;
         _labelHint.Enabled = enable;

         // Cipher Suites
         _buttonMoveUp.Enabled = enable;
         _buttonMoveDown.Enabled = enable;
         _listViewCipherSuites.Enabled = enable;
         _checkBoxTlsOld.Enabled = enable;

#if !LEADTOOLS_V19_OR_LATER
         this._groupMiscellaneous.Visible = false;
#endif
      }

      private bool _initializing = true;

      private void OptionsDialog_Load(object sender, EventArgs e)
      {
         _initializing = true;
         _textBoxClientAE.Text = ClientAE;        
         _textBoxClientCertificate.Text = ClientCertificate;
         _textBoxPrivateKey.Text = PrivateKey;
         _textBoxKeyPassword.Text = PrivateKeyPassword;
         _checkBoxLogLowLevel.Checked = LogLowLevel;
         _checkBoxGroupLengthDataElements.Checked = GroupLengthDataElements;

         _listViewCipherSuites.InitializeCipherListView(CipherSuites, imageListCiphers);
         _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites();

         _initializing = false;
         EnableDialogItems();
      }

      private void _buttonClientCertificate_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Title = "Select Client Certificate";
         openDialog.FileName = _textBoxClientCertificate.Text;
         openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxClientCertificate.Text = openDialog.FileName;
         }
      }

      private void _buttonPrivateKey_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();

         openDialog.Title = "Select Private Key File";
         openDialog.FileName = _textBoxClientCertificate.Text;
         openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         
         if (openDialog.ShowDialog(this)== DialogResult.OK)
         {
            _textBoxPrivateKey.Text = openDialog.FileName;
         }
      }

      private void _checkBoxLoggingLowLevel_CheckedChanged(object sender, EventArgs e)
      {
         EnableDialogItems();
      }

      private Scp Copy(Scp scp)
      {
          Scp s = new Scp();

          s.PeerAddress = scp.PeerAddress;
          s.Port = scp.Port;
          s.Timeout = scp.Timeout;
          s.AETitle = scp.AETitle;
          return s;
      }

      private void buttonAddServer_Click(object sender, EventArgs e)
      {
         try
         {
            int rowIndex = dataGridViewServers.Rows.Add();
            DataGridViewRow row = dataGridViewServers.Rows[rowIndex];
            row.ReadOnly = false;
            row.Selected = true;
            dataGridViewServers.CurrentCell = row.Cells[0];
            dataGridViewServers.ShowEditingIcon = true;
            dataGridViewServers.BeginEdit(false);
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
         }
      }

      private void buttonDeleteServer_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (DataGridViewRow row in dataGridViewServers.SelectedRows)
            {
               dataGridViewServers.Rows.Remove(row);
            }
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
         }

      }

      private void dataGridViewServers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
      {
         DataGridView d = sender as DataGridView;
         if (d != null)
         {
            DataGridViewCheckBoxCell cb = d.CurrentCell as DataGridViewCheckBoxCell;
            if (cb != null)
            {
               if (cb.Value is bool)
               {
                  bool bValue = (bool)cb.Value;
                  if (bValue)
                  {
                     DicomOpenSslVersion version = DicomNet.GetOpenSslVersion();
                     if (Utils.VerifyOpensslVersion(this) == false)
                     {
                        cb.Value = false;
                        dataGridViewServers.RefreshEdit();
                     }
                  }
               }
               d.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
               EnableDialogItems();
            }
         }
      }

      private void dataGridViewServers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
      {
         try
         {
            DataGridViewRow validatingRow = dataGridViewServers.Rows[e.RowIndex];
            if ((null == validatingRow.Cells[ColumnAE.Name].EditedFormattedValue) ||
                       (string.IsNullOrEmpty(validatingRow.Cells[ColumnAE.Name].EditedFormattedValue.ToString())))
            {
               validatingRow.ErrorText = ColumnAE.HeaderText + " cannot be empty";
               e.Cancel = true;
               return;
            }

            if ((null != validatingRow.Cells[ColumnAE.Name].EditedFormattedValue &&
                 validatingRow.Cells[ColumnAE.Name].EditedFormattedValue.ToString().Length > 16))
            {
               validatingRow.ErrorText = ColumnAE.HeaderText + " must be less than 16 characters";
               e.Cancel = true;
               return;
            }

            if ((null == validatingRow.Cells[ColumnIP.Name].EditedFormattedValue) ||
                 (string.IsNullOrEmpty(validatingRow.Cells[ColumnIP.Name].EditedFormattedValue.ToString())))
            {
               validatingRow.ErrorText = ColumnIP.HeaderText + " cannot be empty.";
               e.Cancel = true;
               return;
            }

            try
            {
               string ip = validatingRow.Cells[ColumnIP.Name].EditedFormattedValue.ToString();
               Utils.ResolveIPAddress(ip);
            }
            catch (Exception exception)
            {
               validatingRow.ErrorText = exception.Message;
               e.Cancel = true;
               return;
            }

            int number;
            if ((null == validatingRow.Cells[ColumnPort.Name].EditedFormattedValue) ||
                 (string.IsNullOrEmpty(validatingRow.Cells[ColumnPort.Name].EditedFormattedValue.ToString())) ||
                 (!int.TryParse(validatingRow.Cells[ColumnPort.Name].EditedFormattedValue.ToString(), out number)))
            {
               validatingRow.ErrorText = string.Format("Invalid {0}.", ColumnPort.HeaderText);
               e.Cancel = true;
               return;
            }

            if ((null == validatingRow.Cells[ColumnTimeout.Name].EditedFormattedValue) ||
                 (string.IsNullOrEmpty(validatingRow.Cells[ColumnTimeout.Name].EditedFormattedValue.ToString())) ||
                 (!int.TryParse(validatingRow.Cells[ColumnTimeout.Name].EditedFormattedValue.ToString(), out number)))
            {
               validatingRow.ErrorText = string.Format("Invalid {0}.", ColumnTimeout.HeaderText);
               e.Cancel = true;
               return;
            }

            validatingRow.ErrorText = "";

         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
            throw;
         }
      }

      public CipherSuiteItems CipherSuites = new CipherSuiteItems();

      private void _buttonMoveUp_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up);
      }

      private void _buttonMoveDown_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down);
      }

      private void _checkBoxTlsOld_CheckedChanged(object sender, EventArgs e)
      {
         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing);
         if (_checkBoxTlsOld.Checked)
         {
            CipherSuites.AddOldCipherSuites();
         }
         else
         {
            CipherSuites.RemoveOldCipherSuites();
         }
         _listViewCipherSuites.UpdateCipherSuitesListView(CipherSuites);
         _listViewCipherSuites.Focus();
      }

   }
}
