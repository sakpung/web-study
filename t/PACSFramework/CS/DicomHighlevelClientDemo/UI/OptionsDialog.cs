// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Leadtools.DicomDemos;
using System.Collections.Generic;
using Leadtools.Dicom;

#if LEADTOOLS_V18_OR_LATER
using DicomDemo.UI;
#endif

namespace DicomDemo
{
   /// <summary>
   /// Summary description for OptionsDialog.
   /// </summary>
   public class OptionsDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox _groupBoxClient;
      private System.Windows.Forms.Label _labelClientAE;
      public System.Windows.Forms.TextBox _textBoxClientAE;
      public System.Windows.Forms.TextBox _textBoxClientPort;
      private System.Windows.Forms.Label _labelClientPort;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private Label _labelHint;
      private TextBox _textBoxKeyPassword;
      private TextBox _textBoxPrivateKey;
      private Button _buttonPrivateKey;
      private Label _labelPrivateKey;
      private Label _labelPrivateKeyPassword;
      private TextBox _textBoxClientCertificate;
      private Button _buttonClientCertificate;
      private Label _labelCertificate;
      private IContainer components;
      private string _clientAE;
      private int _clientPort;

      private List<String> _storageClassList = new List<string>();

      public List<String> StorageClassList
      {
         get { return _storageClassList; }
         set { _storageClassList = value; }
      }

      public List<DicomAE> ServerList
      {
         get
         {
            //MyServer[] items = new MyServer[dataGridViewServers.Rows.Count];
            List<DicomAE> items = new List<DicomAE>(dataGridViewServers.Rows.Count);
            for (int i = 0; i < dataGridViewServers.Rows.Count; i++)
            {
               DicomAE server ;
               
               server = new DicomAE();
               server.AE = dataGridViewServers.Rows[i].Cells["ColumnAE"].Value.ToString().Trim();
               server.IPAddress = dataGridViewServers.Rows[i].Cells["ColumnIP"].Value.ToString().Trim();
               server.Timeout = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnTimeout"].Value);
               server.Port = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnPort"].Value);
               server.UseTls = Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value);
               
               items.Add ( server ) ;
            }
            return items;
         }

         set
         {
            foreach (DicomAE s in value)
            {
               int n = dataGridViewServers.Rows.Add();
               dataGridViewServers.Rows[n].Cells["ColumnAE"].Value = s.AE.Trim();
               dataGridViewServers.Rows[n].Cells["ColumnIP"].Value = s.IPAddress.Trim();
               dataGridViewServers.Rows[n].Cells["ColumnTimeout"].Value = s.Timeout.ToString().Trim();
               dataGridViewServers.Rows[n].Cells["ColumnPort"].Value = s.Port.ToString().Trim();
               dataGridViewServers.Rows[n].Cells["ColumnTls"].Value = s.UseTls.ToString().Trim();
            }
         }
      }

      private string _clientCertificate;
      private string _privateKey;
      private string _privateKeyPassword;
      private DataGridView dataGridViewServers;
      private Button buttonAddServer;
      private Button buttonDeleteServer;
      private GroupBox _groupBoxSecurity;
      private GroupBox _groupMiscellaneous;
      private CheckBox _checkBoxGroupLengthDataElements;
      private bool _logLowLevel;
      private Label _labelLogLowLevel;
      private CheckBox _checkBoxLogLowLevel;
      private ImageList imageListCiphers;
      private ComboBox _comboBoxClientSecurity;
      private Label _labelClientSecurity;
      private DataGridViewTextBoxColumn ColumnAE;
      private DataGridViewTextBoxColumn ColumnIP;
      private DataGridViewTextBoxColumn ColumnPort;
      private DataGridViewTextBoxColumn ColumnTimeout;
      private DataGridViewCheckBoxColumn ColumnTls;
      private Label _labelCA;
      private Button _buttonCA;
      private TextBox _textBoxCA;
      private GroupBox groupBoxCipherSuites;
      private Button _buttonMoveDown;
      private CheckBox _checkBoxTlsOld;
      private Button _buttonMoveUp;
      private ListView _listViewCipherSuites;
      private bool _groupLengthDataElements;


      public OptionsDialog( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
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
         this._groupBoxClient = new System.Windows.Forms.GroupBox();
         this._comboBoxClientSecurity = new System.Windows.Forms.ComboBox();
         this._labelClientSecurity = new System.Windows.Forms.Label();
         this._textBoxClientPort = new System.Windows.Forms.TextBox();
         this._labelClientPort = new System.Windows.Forms.Label();
         this._textBoxClientAE = new System.Windows.Forms.TextBox();
         this._labelClientAE = new System.Windows.Forms.Label();
         this._labelHint = new System.Windows.Forms.Label();
         this._textBoxKeyPassword = new System.Windows.Forms.TextBox();
         this._textBoxPrivateKey = new System.Windows.Forms.TextBox();
         this._labelPrivateKey = new System.Windows.Forms.Label();
         this._labelPrivateKeyPassword = new System.Windows.Forms.Label();
         this._textBoxClientCertificate = new System.Windows.Forms.TextBox();
         this._labelCertificate = new System.Windows.Forms.Label();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.dataGridViewServers = new System.Windows.Forms.DataGridView();
         this.ColumnAE = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTls = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this._groupBoxSecurity = new System.Windows.Forms.GroupBox();
         this._labelCA = new System.Windows.Forms.Label();
         this._buttonCA = new System.Windows.Forms.Button();
         this._textBoxCA = new System.Windows.Forms.TextBox();
         this._buttonClientCertificate = new System.Windows.Forms.Button();
         this._buttonPrivateKey = new System.Windows.Forms.Button();
         this._groupMiscellaneous = new System.Windows.Forms.GroupBox();
         this._labelLogLowLevel = new System.Windows.Forms.Label();
         this._checkBoxLogLowLevel = new System.Windows.Forms.CheckBox();
         this._checkBoxGroupLengthDataElements = new System.Windows.Forms.CheckBox();
         this.buttonDeleteServer = new System.Windows.Forms.Button();
         this.buttonAddServer = new System.Windows.Forms.Button();
         this.imageListCiphers = new System.Windows.Forms.ImageList(this.components);
         this.groupBoxCipherSuites = new System.Windows.Forms.GroupBox();
         this._buttonMoveDown = new System.Windows.Forms.Button();
         this._checkBoxTlsOld = new System.Windows.Forms.CheckBox();
         this._buttonMoveUp = new System.Windows.Forms.Button();
         this._listViewCipherSuites = new System.Windows.Forms.ListView();
         this._groupBoxClient.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServers)).BeginInit();
         this._groupBoxSecurity.SuspendLayout();
         this._groupMiscellaneous.SuspendLayout();
         this.groupBoxCipherSuites.SuspendLayout();
         this.SuspendLayout();
         // 
         // _groupBoxClient
         // 
         this._groupBoxClient.Controls.Add(this._comboBoxClientSecurity);
         this._groupBoxClient.Controls.Add(this._labelClientSecurity);
         this._groupBoxClient.Controls.Add(this._textBoxClientPort);
         this._groupBoxClient.Controls.Add(this._labelClientPort);
         this._groupBoxClient.Controls.Add(this._textBoxClientAE);
         this._groupBoxClient.Controls.Add(this._labelClientAE);
         this._groupBoxClient.Location = new System.Drawing.Point(8, 8);
         this._groupBoxClient.Name = "_groupBoxClient";
         this._groupBoxClient.Size = new System.Drawing.Size(544, 80);
         this._groupBoxClient.TabIndex = 0;
         this._groupBoxClient.TabStop = false;
         this._groupBoxClient.Text = "Client Information";
         // 
         // _comboBoxClientSecurity
         // 
         this._comboBoxClientSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxClientSecurity.FormattingEnabled = true;
         this._comboBoxClientSecurity.Location = new System.Drawing.Point(350, 46);
         this._comboBoxClientSecurity.Name = "_comboBoxClientSecurity";
         this._comboBoxClientSecurity.Size = new System.Drawing.Size(178, 21);
         this._comboBoxClientSecurity.TabIndex = 5;
         // 
         // _labelClientSecurity
         // 
         this._labelClientSecurity.AutoSize = true;
         this._labelClientSecurity.Location = new System.Drawing.Point(246, 50);
         this._labelClientSecurity.Name = "_labelClientSecurity";
         this._labelClientSecurity.Size = new System.Drawing.Size(102, 13);
         this._labelClientSecurity.TabIndex = 4;
         this._labelClientSecurity.Text = "Client Secure (TLS):";
         // 
         // _textBoxClientPort
         // 
         this._textBoxClientPort.Location = new System.Drawing.Point(111, 46);
         this._textBoxClientPort.Name = "_textBoxClientPort";
         this._textBoxClientPort.Size = new System.Drawing.Size(121, 20);
         this._textBoxClientPort.TabIndex = 3;
         this._textBoxClientPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Port_KeyPress);
         // 
         // _labelClientPort
         // 
         this._labelClientPort.AutoSize = true;
         this._labelClientPort.Location = new System.Drawing.Point(16, 50);
         this._labelClientPort.Name = "_labelClientPort";
         this._labelClientPort.Size = new System.Drawing.Size(58, 13);
         this._labelClientPort.TabIndex = 2;
         this._labelClientPort.Text = "Client Port:";
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
         // _labelHint
         // 
         this._labelHint.AutoSize = true;
         this._labelHint.ForeColor = System.Drawing.Color.Blue;
         this._labelHint.Location = new System.Drawing.Point(264, 102);
         this._labelHint.Name = "_labelHint";
         this._labelHint.Size = new System.Drawing.Size(140, 13);
         this._labelHint.TabIndex = 11;
         this._labelHint.Text = "<== Use \'test\'  for client.pem";
         // 
         // _textBoxKeyPassword
         // 
         this._textBoxKeyPassword.Location = new System.Drawing.Point(110, 98);
         this._textBoxKeyPassword.Name = "_textBoxKeyPassword";
         this._textBoxKeyPassword.Size = new System.Drawing.Size(146, 20);
         this._textBoxKeyPassword.TabIndex = 10;
         // 
         // _textBoxPrivateKey
         // 
         this._textBoxPrivateKey.Location = new System.Drawing.Point(110, 72);
         this._textBoxPrivateKey.Name = "_textBoxPrivateKey";
         this._textBoxPrivateKey.Size = new System.Drawing.Size(418, 20);
         this._textBoxPrivateKey.TabIndex = 8;
         // 
         // _labelPrivateKey
         // 
         this._labelPrivateKey.AutoSize = true;
         this._labelPrivateKey.Location = new System.Drawing.Point(16, 76);
         this._labelPrivateKey.Name = "_labelPrivateKey";
         this._labelPrivateKey.Size = new System.Drawing.Size(64, 13);
         this._labelPrivateKey.TabIndex = 6;
         this._labelPrivateKey.Text = "Private Key:";
         // 
         // _labelPrivateKeyPassword
         // 
         this._labelPrivateKeyPassword.AutoSize = true;
         this._labelPrivateKeyPassword.Location = new System.Drawing.Point(16, 102);
         this._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword";
         this._labelPrivateKeyPassword.Size = new System.Drawing.Size(77, 13);
         this._labelPrivateKeyPassword.TabIndex = 9;
         this._labelPrivateKeyPassword.Text = "Key Password:";
         // 
         // _textBoxClientCertificate
         // 
         this._textBoxClientCertificate.Location = new System.Drawing.Point(110, 46);
         this._textBoxClientCertificate.Name = "_textBoxClientCertificate";
         this._textBoxClientCertificate.Size = new System.Drawing.Size(418, 20);
         this._textBoxClientCertificate.TabIndex = 5;
         // 
         // _labelCertificate
         // 
         this._labelCertificate.AutoSize = true;
         this._labelCertificate.Location = new System.Drawing.Point(16, 50);
         this._labelCertificate.Name = "_labelCertificate";
         this._labelCertificate.Size = new System.Drawing.Size(57, 13);
         this._labelCertificate.TabIndex = 3;
         this._labelCertificate.Text = "Certificate:";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(200, 703);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 7;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.CausesValidation = false;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(285, 703);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 8;
         this.buttonCancel.Text = "&Cancel";
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
         this.dataGridViewServers.Location = new System.Drawing.Point(8, 546);
         this.dataGridViewServers.Name = "dataGridViewServers";
         this.dataGridViewServers.Size = new System.Drawing.Size(544, 150);
         this.dataGridViewServers.TabIndex = 6;
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
         this.ColumnTls.HeaderText = "Server Secure (TLS)";
         this.ColumnTls.Name = "ColumnTls";
         this.ColumnTls.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this.ColumnTls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         this.ColumnTls.Width = 95;
         // 
         // _groupBoxSecurity
         // 
         this._groupBoxSecurity.Controls.Add(this._labelCA);
         this._groupBoxSecurity.Controls.Add(this._buttonCA);
         this._groupBoxSecurity.Controls.Add(this._textBoxCA);
         this._groupBoxSecurity.Controls.Add(this._labelCertificate);
         this._groupBoxSecurity.Controls.Add(this._labelHint);
         this._groupBoxSecurity.Controls.Add(this._buttonClientCertificate);
         this._groupBoxSecurity.Controls.Add(this._textBoxClientCertificate);
         this._groupBoxSecurity.Controls.Add(this._textBoxKeyPassword);
         this._groupBoxSecurity.Controls.Add(this._labelPrivateKeyPassword);
         this._groupBoxSecurity.Controls.Add(this._labelPrivateKey);
         this._groupBoxSecurity.Controls.Add(this._textBoxPrivateKey);
         this._groupBoxSecurity.Controls.Add(this._buttonPrivateKey);
         this._groupBoxSecurity.Location = new System.Drawing.Point(8, 97);
         this._groupBoxSecurity.Name = "_groupBoxSecurity";
         this._groupBoxSecurity.Size = new System.Drawing.Size(544, 125);
         this._groupBoxSecurity.TabIndex = 1;
         this._groupBoxSecurity.TabStop = false;
         this._groupBoxSecurity.Text = "Security";
         // 
         // _labelCA
         // 
         this._labelCA.AutoSize = true;
         this._labelCA.Location = new System.Drawing.Point(5, 24);
         this._labelCA.Name = "_labelCA";
         this._labelCA.Size = new System.Drawing.Size(73, 13);
         this._labelCA.TabIndex = 0;
         this._labelCA.Text = "Cert Authority:";
         // 
         // _buttonCA
         // 
         this._buttonCA.Image = ((System.Drawing.Image)(resources.GetObject("_buttonCA.Image")));
         this._buttonCA.Location = new System.Drawing.Point(80, 21);
         this._buttonCA.Name = "_buttonCA";
         this._buttonCA.Size = new System.Drawing.Size(23, 20);
         this._buttonCA.TabIndex = 1;
         this._buttonCA.UseVisualStyleBackColor = true;
         this._buttonCA.Click += new System.EventHandler(this._buttonCA_Click);
         // 
         // _textBoxCA
         // 
         this._textBoxCA.Location = new System.Drawing.Point(110, 20);
         this._textBoxCA.Name = "_textBoxCA";
         this._textBoxCA.Size = new System.Drawing.Size(418, 20);
         this._textBoxCA.TabIndex = 2;
         // 
         // _buttonClientCertificate
         // 
         this._buttonClientCertificate.Image = ((System.Drawing.Image)(resources.GetObject("_buttonClientCertificate.Image")));
         this._buttonClientCertificate.Location = new System.Drawing.Point(80, 47);
         this._buttonClientCertificate.Name = "_buttonClientCertificate";
         this._buttonClientCertificate.Size = new System.Drawing.Size(23, 20);
         this._buttonClientCertificate.TabIndex = 4;
         this._buttonClientCertificate.UseVisualStyleBackColor = true;
         this._buttonClientCertificate.Click += new System.EventHandler(this._buttonClientCertificate_Click);
         // 
         // _buttonPrivateKey
         // 
         this._buttonPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("_buttonPrivateKey.Image")));
         this._buttonPrivateKey.Location = new System.Drawing.Point(80, 73);
         this._buttonPrivateKey.Name = "_buttonPrivateKey";
         this._buttonPrivateKey.Size = new System.Drawing.Size(23, 20);
         this._buttonPrivateKey.TabIndex = 7;
         this._buttonPrivateKey.UseVisualStyleBackColor = true;
         this._buttonPrivateKey.Click += new System.EventHandler(this._buttonPrivateKey_Click);
         // 
         // _groupMiscellaneous
         // 
         this._groupMiscellaneous.Controls.Add(this._labelLogLowLevel);
         this._groupMiscellaneous.Controls.Add(this._checkBoxLogLowLevel);
         this._groupMiscellaneous.Controls.Add(this._checkBoxGroupLengthDataElements);
         this._groupMiscellaneous.Location = new System.Drawing.Point(8, 428);
         this._groupMiscellaneous.Name = "_groupMiscellaneous";
         this._groupMiscellaneous.Size = new System.Drawing.Size(544, 66);
         this._groupMiscellaneous.TabIndex = 3;
         this._groupMiscellaneous.TabStop = false;
         this._groupMiscellaneous.Text = "Miscellaneous";
         // 
         // _labelLogLowLevel
         // 
         this._labelLogLowLevel.AutoSize = true;
         this._labelLogLowLevel.ForeColor = System.Drawing.Color.Green;
         this._labelLogLowLevel.Location = new System.Drawing.Point(138, 45);
         this._labelLogLowLevel.Name = "_labelLogLowLevel";
         this._labelLogLowLevel.Size = new System.Drawing.Size(189, 13);
         this._labelLogLowLevel.TabIndex = 2;
         this._labelLogLowLevel.Text = "<== Displayed green in the log window";
         // 
         // _checkBoxLogLowLevel
         // 
         this._checkBoxLogLowLevel.AutoSize = true;
         this._checkBoxLogLowLevel.Location = new System.Drawing.Point(15, 43);
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
         // buttonDeleteServer
         // 
         this.buttonDeleteServer.CausesValidation = false;
         this.buttonDeleteServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteServer.Image")));
         this.buttonDeleteServer.Location = new System.Drawing.Point(48, 506);
         this.buttonDeleteServer.Name = "buttonDeleteServer";
         this.buttonDeleteServer.Size = new System.Drawing.Size(40, 39);
         this.buttonDeleteServer.TabIndex = 5;
         this.buttonDeleteServer.UseVisualStyleBackColor = true;
         this.buttonDeleteServer.Click += new System.EventHandler(this.buttonDeleteServer_Click);
         // 
         // buttonAddServer
         // 
         this.buttonAddServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddServer.Image")));
         this.buttonAddServer.Location = new System.Drawing.Point(8, 506);
         this.buttonAddServer.Name = "buttonAddServer";
         this.buttonAddServer.Size = new System.Drawing.Size(40, 39);
         this.buttonAddServer.TabIndex = 4;
         this.buttonAddServer.UseVisualStyleBackColor = true;
         this.buttonAddServer.Click += new System.EventHandler(this.buttonAddServer_Click);
         // 
         // imageListCiphers
         // 
         this.imageListCiphers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCiphers.ImageStream")));
         this.imageListCiphers.TransparentColor = System.Drawing.Color.Transparent;
         this.imageListCiphers.Images.SetKeyName(0, "redBullet.png");
         this.imageListCiphers.Images.SetKeyName(1, "yellowBullet.png");
         this.imageListCiphers.Images.SetKeyName(2, "greenBullet.png");
         // 
         // groupBoxCipherSuites
         // 
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveDown);
         this.groupBoxCipherSuites.Controls.Add(this._checkBoxTlsOld);
         this.groupBoxCipherSuites.Controls.Add(this._buttonMoveUp);
         this.groupBoxCipherSuites.Controls.Add(this._listViewCipherSuites);
         this.groupBoxCipherSuites.Location = new System.Drawing.Point(8, 231);
         this.groupBoxCipherSuites.Name = "groupBoxCipherSuites";
         this.groupBoxCipherSuites.Size = new System.Drawing.Size(544, 188);
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
         // 
         // _listViewCipherSuites
         // 
         this._listViewCipherSuites.Location = new System.Drawing.Point(110, 16);
         this._listViewCipherSuites.Name = "_listViewCipherSuites";
         this._listViewCipherSuites.Size = new System.Drawing.Size(418, 142);
         this._listViewCipherSuites.TabIndex = 2;
         this._listViewCipherSuites.UseCompatibleStateImageBehavior = false;
         // 
         // OptionsDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(560, 731);
         this.Controls.Add(this.groupBoxCipherSuites);
         this.Controls.Add(this._groupMiscellaneous);
         this.Controls.Add(this._groupBoxSecurity);
         this.Controls.Add(this.buttonDeleteServer);
         this.Controls.Add(this.buttonAddServer);
         this.Controls.Add(this.dataGridViewServers);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
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
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServers)).EndInit();
         this._groupBoxSecurity.ResumeLayout(false);
         this._groupBoxSecurity.PerformLayout();
         this._groupMiscellaneous.ResumeLayout(false);
         this._groupMiscellaneous.PerformLayout();
         this.groupBoxCipherSuites.ResumeLayout(false);
         this.groupBoxCipherSuites.PerformLayout();
         this.ResumeLayout(false);

      }
      #endregion

      private DicomRetrieveMode _imageRetrieveMethod;

      public DicomRetrieveMode ImageRetrieveMethod
      {
         get { return _imageRetrieveMethod; }
         set { _imageRetrieveMethod = value; }
      }

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

      public string CertificateAuthority
      {
         get;
         set;
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

      public int ClientPort
      {
         get { return _clientPort; }
         set { _clientPort = value; }
      }

      public ClientPortUsageType ClientPortSecurityUsage
      {
         get;
         set;
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

      private bool CheckIP(string ip)
      {
         try
         {
            System.Net.IPAddress.Parse(ip);
            return true;
         }
         catch (Exception)
         {
            return false;
         }
      }

      private bool CheckIP(TextBox tb, Label lb)
      {
         bool valid = CheckIP(tb.Text);
         if (!valid)
         {
            if (tb.Text.Trim() == string.Empty)
               MessageBox.Show("Invalid " + lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
            return false;
         }
         return true;
      }


      private bool CheckFileExists(TextBox tb, bool showMessageBox)
      {
         bool ret = true;
         string sMsg = string.Empty;
         string sFile = tb.Text.Trim();
         if (sFile.Length == 0)
         {
            sMsg = "File can not be empty if 'Secure (TLS)' is checked.";
            ret = false;
         }
         else if (!File.Exists(sFile))
         {
            sMsg = "File does not exist: " + sFile;
            ret = false;
         }
         if ((ret == false) && showMessageBox)
         {
            _errorProvider.SetError(tb, sMsg);
            tb.SelectAll();
            tb.Focus();
            DialogResult = DialogResult.None;
         }
         return ret;
      }

      private void buttonOK_Click(object sender, System.EventArgs e)
      {
         if (IsAnyServerUseTls())
         {
            if (!CheckFileExists(_textBoxCA, true))
               return;
            if (!CheckFileExists(_textBoxClientCertificate, true))
               return;
            if (!CheckFileExists(_textBoxPrivateKey, true))
               return;
         }

         if (!CheckInteger(_textBoxClientPort, _labelClientPort))
            return;

         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing);

         ClientAE = _textBoxClientAE.Text;
         ClientPort = Convert.ToInt32(_textBoxClientPort.Text);
         CertificateAuthority = _textBoxCA.Text;
         ClientCertificate = _textBoxClientCertificate.Text;
         PrivateKey = _textBoxPrivateKey.Text;
         PrivateKeyPassword = _textBoxKeyPassword.Text;
         LogLowLevel = _checkBoxLogLowLevel.Checked;
         GroupLengthDataElements = _checkBoxGroupLengthDataElements.Checked;

         ClientPortSecurityTypeItem item = _comboBoxClientSecurity.SelectedItem as ClientPortSecurityTypeItem;
         if (item != null)
         {
            ClientPortSecurityUsage = item.ClientSecurity;
         }
      }

      private void EnableDialogItems()
      {
         bool enable = IsAnyServerUseTls();

         _labelCA.Enabled = enable;
         _buttonCA.Enabled = enable;
         _textBoxCA.Enabled = enable;

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

      private ErrorProvider _errorProvider = null;

      private void OptionsDialog_Load(object sender, EventArgs e)
      {
         _errorProvider = new ErrorProvider(this);
         _errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
         _errorProvider.SetIconAlignment(this, ErrorIconAlignment.TopLeft);

         _initializing = true;
         _textBoxClientAE.Text = ClientAE;
         _textBoxClientPort.Text = ClientPort.ToString();
         _textBoxCA.Text = CertificateAuthority;
         _textBoxClientCertificate.Text = ClientCertificate;
         _textBoxPrivateKey.Text = PrivateKey;
         _textBoxKeyPassword.Text = PrivateKeyPassword;
         _checkBoxLogLowLevel.Checked = LogLowLevel;
         _checkBoxGroupLengthDataElements.Checked = GroupLengthDataElements;

         _textBoxCA.TextChanged += _textBoxCA_TextChanged;
         _textBoxClientCertificate.TextChanged += _textBoxClientCertificate_TextChanged;
         _textBoxPrivateKey.TextChanged += _textBoxPrivateKey_TextChanged;

         _checkBoxTlsOld.CheckedChanged += checkBoxTlsOld_CheckedChanged;
         _buttonMoveUp.Click += buttonUp_Click;
         _buttonMoveDown.Click += buttonMoveDown_Click;

         _listViewCipherSuites.InitializeCipherListView(CipherSuites, imageListCiphers);
         _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites();

         _initializing = false;

         _comboBoxClientSecurity.Items.Add(new ClientPortSecurityTypeItem(ClientPortUsageType.Unsecure, "No (unsecure)"));
         _comboBoxClientSecurity.Items.Add(new ClientPortSecurityTypeItem(ClientPortUsageType.Secure,"Yes (secure)"));
         _comboBoxClientSecurity.Items.Add(new ClientPortSecurityTypeItem(ClientPortUsageType.SameAsServer, "Same as 'Server Secure (TLS)'"));

         switch (ClientPortSecurityUsage)
         {
            case ClientPortUsageType.Unsecure:
               _comboBoxClientSecurity.SelectedIndex = 0;
               break;
            case ClientPortUsageType.Secure:
               _comboBoxClientSecurity.SelectedIndex = 1;
               break;
            case ClientPortUsageType.SameAsServer:
               _comboBoxClientSecurity.SelectedIndex = 2;
               break;
         }

         _comboBoxClientSecurity.SelectedIndexChanged += _comboBoxClientSecurity_SelectedIndexChanged;

         EnableDialogItems();
      }

      private void _comboBoxClientSecurity_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_comboBoxClientSecurity.SelectedIndex != 0)
         {
            if (Utils.VerifyOpensslVersion(this) == false)
            {
               _comboBoxClientSecurity.SelectedIndex = 0;
            }
         }
      }

      private void _textBoxCA_TextChanged(object sender, EventArgs e)
      {
         _errorProvider.Clear();
      }

      private void _textBoxPrivateKey_TextChanged(object sender, EventArgs e)
      {
         _errorProvider.Clear();
      }

      private void _textBoxClientCertificate_TextChanged(object sender, EventArgs e)
      {
         _errorProvider.Clear();
      }

      private void _buttonCA_Click(object sender, EventArgs e)
      {
         OpenFileDialog openDialog = new OpenFileDialog();
         openDialog.Title = "Select Certificate Authority";
         openDialog.FileName = _textBoxCA.Text;
         openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxCA.Text = openDialog.FileName;
         }
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
         openDialog.FileName = _textBoxPrivateKey.Text;
         openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
         DialogResult result = openDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            _textBoxPrivateKey.Text = openDialog.FileName;
         }
      }

      private void _checkBoxLoggingLowLevel_CheckedChanged(object sender, EventArgs e)
      {
         EnableDialogItems();
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

      // C
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
                     if ( Utils.VerifyOpensslVersion(this) == false)
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

      private void buttonUp_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up);
      }

      private void buttonMoveDown_Click(object sender, EventArgs e)
      {
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down);
      }

      private void checkBoxTlsOld_CheckedChanged(object sender, EventArgs e)
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

      public CipherSuiteItems CipherSuites = new CipherSuiteItems();
   }

}
