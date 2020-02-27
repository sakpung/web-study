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
using PrintToPACS.Utilities;
using System.Net;
using System.Collections.Generic;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using PrintToPACSDemo.UI;
using PrinterDemo;
using Leadtools.Dicom.Scu.Common;
using Leadtools;
using Leadtools.Dicom.Scu;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Leadtools.DicomDemos;

namespace PrintToPACSDemo
{
   /// <summary>
   /// Summary description for OptionsDialog.
   /// </summary>
   public class OptionsDialog : System.Windows.Forms.Form
   {
      #region Fields

      private System.Windows.Forms.GroupBox _groupBoxClient;
      private System.Windows.Forms.Label _labelClientAE;
      public System.Windows.Forms.TextBox _textBoxClientAE;
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
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;


      private string _clientAE;
      public MyServerList serverlistSCP;
      public MyServerList serverlistMWL;
      public MyServerList serverlistStore;
      List<AssociationHolder> lstAssociations;
      int iLastNumber = 1;

      List<DicomClassType> ClassTypes = new List<DicomClassType>(){
         DicomClassType.SCImageStorage,
         DicomClassType.SCMultiFrameTrueColorImageStorage,
         DicomClassType.SCMultiFrameGrayscaleByteImageStorage,
         DicomClassType.EncapsulatedPdfStorage
      };

      private string _clientCertificate;
      private int _defaultSCPServer = 0;
      private int _defaultMWLServer = 0;
      private int _defaultStoreServer = 0;
      private string _privateKey;
      private string _privateKeyPassword;
      private DicomImageCompressionType _SCCompression;
      private DicomImageCompressionType _SCColorCompression;
      private DicomImageCompressionType _SCGrayCompression;
      private string _SCPath;
      private string _SCColorPath;
      private string _SCGrayPath;
      private string _PdfPath;
      private string _PrinterName;
      private string _TempDirectory;
      private bool _AutoDelete;
      private int _iSelectedTab;
      private DataGridView dataGridViewServers;
      private Button buttonAddServer;
      private Button buttonDeleteServer;
      private GroupBox _groupBoxSecurity;
      private TabControl _tbServers;
      private TabPage _tbSCPQuerypage;
      private TabPage _tbMWLQueryPage;
      private TabPage _tbStorePage;
      private TabControl _tbOptions;
      private TabPage _tpApplicationOptions;
      private TabPage _tpDicomOptions;
      private GroupBox _gpDicomType;
      private TextBox _txtSCPDF;
      private TextBox _txtSCGray;
      private TextBox _txtSCColor;
      private TextBox _txtSC;
      private TextBox _txtTempDir;
      private TextBox _txtPrinterName;
      private Label _lblPrinterName;
      private Label label2;
      private ComboBox _cmbSCColor;
      private ComboBox _cmbSCGray;
      private ComboBox _cmbSC;
      private Label label1;
      private RadioButton _rdPDF;
      private RadioButton _rdGrayScale;
      private RadioButton _rdColored;
      private RadioButton _rdSecondaryCapture;
      private CheckBox _ckAutoDelete;
      private Label label3;
      private Button _btnRename;
      private bool _logLowLevel;
      private DicomClassType _selectedtype;

      List<String> Compressions = new List<String>(){
               "Uncompressed",
               "Lossless JPEG",
               "Lossy JPEG",
               "Lossless J2k",
               "Lossy J2K"
      };

      List<DicomImageCompressionType> ImgCompression = new List<DicomImageCompressionType>(){
         DicomImageCompressionType.None,
         DicomImageCompressionType.JpegLossless,
         DicomImageCompressionType.JpegLossy,
         DicomImageCompressionType.J2kLossless,
         DicomImageCompressionType.J2kLossy
      };

      bool bTimeOut = true;
      private Button _btnBrowseSCPDF;
      private Button _btnBrowseSCGray;
      private Button _btnBrowseSCColor;
      private Button _btnBrowseSC;
      private DataGridViewTextBoxColumn ColumnAE;
      private DataGridViewTextBoxColumn ColumnIP;
      private DataGridViewTextBoxColumn ColumnPort;
      private DataGridViewTextBoxColumn ColumnTimeout;
      private DataGridViewCheckBoxColumn ColumnTls;
      private DataGridViewButtonColumn TestServer;
      private DataGridViewCheckBoxColumn DefaultServer;
      private Button _btnBrowseTempDir;

      #endregion

      #region Constructor
      public OptionsDialog()
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
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #endregion

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
         this._groupBoxClient = new System.Windows.Forms.GroupBox();
         this._textBoxClientAE = new System.Windows.Forms.TextBox();
         this._labelClientAE = new System.Windows.Forms.Label();
         this._labelHint = new System.Windows.Forms.Label();
         this._textBoxKeyPassword = new System.Windows.Forms.TextBox();
         this._textBoxPrivateKey = new System.Windows.Forms.TextBox();
         this._buttonPrivateKey = new System.Windows.Forms.Button();
         this._labelPrivateKey = new System.Windows.Forms.Label();
         this._labelPrivateKeyPassword = new System.Windows.Forms.Label();
         this._textBoxClientCertificate = new System.Windows.Forms.TextBox();
         this._buttonClientCertificate = new System.Windows.Forms.Button();
         this._labelCertificate = new System.Windows.Forms.Label();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.dataGridViewServers = new System.Windows.Forms.DataGridView();
         this.ColumnAE = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnTls = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.TestServer = new System.Windows.Forms.DataGridViewButtonColumn();
         this.DefaultServer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.buttonAddServer = new System.Windows.Forms.Button();
         this.buttonDeleteServer = new System.Windows.Forms.Button();
         this._groupBoxSecurity = new System.Windows.Forms.GroupBox();
         this._tbServers = new System.Windows.Forms.TabControl();
         this._tbSCPQuerypage = new System.Windows.Forms.TabPage();
         this._tbMWLQueryPage = new System.Windows.Forms.TabPage();
         this._tbStorePage = new System.Windows.Forms.TabPage();
         this._tbOptions = new System.Windows.Forms.TabControl();
         this._tpApplicationOptions = new System.Windows.Forms.TabPage();
         this._btnBrowseTempDir = new System.Windows.Forms.Button();
         this._ckAutoDelete = new System.Windows.Forms.CheckBox();
         this.label3 = new System.Windows.Forms.Label();
         this._btnRename = new System.Windows.Forms.Button();
         this._gpDicomType = new System.Windows.Forms.GroupBox();
         this._btnBrowseSCPDF = new System.Windows.Forms.Button();
         this._btnBrowseSCGray = new System.Windows.Forms.Button();
         this._btnBrowseSCColor = new System.Windows.Forms.Button();
         this._btnBrowseSC = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this._cmbSCColor = new System.Windows.Forms.ComboBox();
         this._cmbSCGray = new System.Windows.Forms.ComboBox();
         this._cmbSC = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this._rdPDF = new System.Windows.Forms.RadioButton();
         this._rdGrayScale = new System.Windows.Forms.RadioButton();
         this._rdColored = new System.Windows.Forms.RadioButton();
         this._rdSecondaryCapture = new System.Windows.Forms.RadioButton();
         this._txtSCPDF = new System.Windows.Forms.TextBox();
         this._txtSCGray = new System.Windows.Forms.TextBox();
         this._txtSCColor = new System.Windows.Forms.TextBox();
         this._txtSC = new System.Windows.Forms.TextBox();
         this._txtTempDir = new System.Windows.Forms.TextBox();
         this._txtPrinterName = new System.Windows.Forms.TextBox();
         this._lblPrinterName = new System.Windows.Forms.Label();
         this._tpDicomOptions = new System.Windows.Forms.TabPage();
         this._groupBoxClient.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServers)).BeginInit();
         this._groupBoxSecurity.SuspendLayout();
         this._tbServers.SuspendLayout();
         this._tbOptions.SuspendLayout();
         this._tpApplicationOptions.SuspendLayout();
         this._gpDicomType.SuspendLayout();
         this._tpDicomOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _groupBoxClient
         // 
         this._groupBoxClient.Controls.Add(this._textBoxClientAE);
         this._groupBoxClient.Controls.Add(this._labelClientAE);
         this._groupBoxClient.Location = new System.Drawing.Point(16, 18);
         this._groupBoxClient.Name = "_groupBoxClient";
         this._groupBoxClient.Size = new System.Drawing.Size(630, 68);
         this._groupBoxClient.TabIndex = 1;
         this._groupBoxClient.TabStop = false;
         this._groupBoxClient.Text = "Client Information";
         // 
         // _textBoxClientAE
         // 
         this._textBoxClientAE.Location = new System.Drawing.Point(142, 26);
         this._textBoxClientAE.Name = "_textBoxClientAE";
         this._textBoxClientAE.Size = new System.Drawing.Size(469, 20);
         this._textBoxClientAE.TabIndex = 1;
         // 
         // _labelClientAE
         // 
         this._labelClientAE.AutoSize = true;
         this._labelClientAE.Location = new System.Drawing.Point(16, 30);
         this._labelClientAE.Name = "_labelClientAE";
         this._labelClientAE.Size = new System.Drawing.Size(112, 13);
         this._labelClientAE.TabIndex = 0;
         this._labelClientAE.Text = "PrintToPACS AE Title:";
         // 
         // _labelHint
         // 
         this._labelHint.AutoSize = true;
         this._labelHint.ForeColor = System.Drawing.Color.Blue;
         this._labelHint.Location = new System.Drawing.Point(300, 96);
         this._labelHint.Name = "_labelHint";
         this._labelHint.Size = new System.Drawing.Size(140, 13);
         this._labelHint.TabIndex = 15;
         this._labelHint.Text = "<== Use \'test\'  for client.pem";
         // 
         // _textBoxKeyPassword
         // 
         this._textBoxKeyPassword.Location = new System.Drawing.Point(141, 93);
         this._textBoxKeyPassword.Name = "_textBoxKeyPassword";
         this._textBoxKeyPassword.Size = new System.Drawing.Size(146, 20);
         this._textBoxKeyPassword.TabIndex = 14;
         // 
         // _textBoxPrivateKey
         // 
         this._textBoxPrivateKey.Location = new System.Drawing.Point(141, 61);
         this._textBoxPrivateKey.Name = "_textBoxPrivateKey";
         this._textBoxPrivateKey.Size = new System.Drawing.Size(470, 20);
         this._textBoxPrivateKey.TabIndex = 12;
         // 
         // _buttonPrivateKey
         // 
         this._buttonPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("_buttonPrivateKey.Image")));
         this._buttonPrivateKey.Location = new System.Drawing.Point(112, 61);
         this._buttonPrivateKey.Name = "_buttonPrivateKey";
         this._buttonPrivateKey.Size = new System.Drawing.Size(23, 19);
         this._buttonPrivateKey.TabIndex = 11;
         this._buttonPrivateKey.UseVisualStyleBackColor = true;
         this._buttonPrivateKey.Click += new System.EventHandler(this._buttonPrivateKey_Click);
         // 
         // _labelPrivateKey
         // 
         this._labelPrivateKey.AutoSize = true;
         this._labelPrivateKey.Location = new System.Drawing.Point(16, 61);
         this._labelPrivateKey.Name = "_labelPrivateKey";
         this._labelPrivateKey.Size = new System.Drawing.Size(64, 13);
         this._labelPrivateKey.TabIndex = 10;
         this._labelPrivateKey.Text = "Private Key:";
         // 
         // _labelPrivateKeyPassword
         // 
         this._labelPrivateKeyPassword.AutoSize = true;
         this._labelPrivateKeyPassword.Location = new System.Drawing.Point(16, 93);
         this._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword";
         this._labelPrivateKeyPassword.Size = new System.Drawing.Size(77, 13);
         this._labelPrivateKeyPassword.TabIndex = 13;
         this._labelPrivateKeyPassword.Text = "Key Password:";
         // 
         // _textBoxClientCertificate
         // 
         this._textBoxClientCertificate.Location = new System.Drawing.Point(141, 28);
         this._textBoxClientCertificate.Name = "_textBoxClientCertificate";
         this._textBoxClientCertificate.Size = new System.Drawing.Size(470, 20);
         this._textBoxClientCertificate.TabIndex = 9;
         // 
         // _buttonClientCertificate
         // 
         this._buttonClientCertificate.Image = ((System.Drawing.Image)(resources.GetObject("_buttonClientCertificate.Image")));
         this._buttonClientCertificate.Location = new System.Drawing.Point(112, 29);
         this._buttonClientCertificate.Name = "_buttonClientCertificate";
         this._buttonClientCertificate.Size = new System.Drawing.Size(23, 19);
         this._buttonClientCertificate.TabIndex = 8;
         this._buttonClientCertificate.UseVisualStyleBackColor = true;
         this._buttonClientCertificate.Click += new System.EventHandler(this._buttonClientCertificate_Click);
         // 
         // _labelCertificate
         // 
         this._labelCertificate.AutoSize = true;
         this._labelCertificate.Location = new System.Drawing.Point(16, 32);
         this._labelCertificate.Name = "_labelCertificate";
         this._labelCertificate.Size = new System.Drawing.Size(57, 13);
         this._labelCertificate.TabIndex = 7;
         this._labelCertificate.Text = "Certificate:";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(268, 539);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.CausesValidation = false;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(349, 539);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 3;
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
            this.ColumnTls,
            this.TestServer,
            this.DefaultServer});
         this.dataGridViewServers.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.dataGridViewServers.Location = new System.Drawing.Point(3, 51);
         this.dataGridViewServers.Name = "dataGridViewServers";
         this.dataGridViewServers.Size = new System.Drawing.Size(619, 157);
         this.dataGridViewServers.TabIndex = 5;
         this.dataGridViewServers.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewServers_RowValidating);
         this.dataGridViewServers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServers_CellClick);
         this.dataGridViewServers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewServers_CurrentCellDirtyStateChanged);
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
         // 
         // ColumnPort
         // 
         this.ColumnPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
         this.ColumnPort.HeaderText = "Server Port";
         this.ColumnPort.Name = "ColumnPort";
         // 
         // ColumnTimeout
         // 
         this.ColumnTimeout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
         this.ColumnTimeout.HeaderText = "Timeout (sec)";
         this.ColumnTimeout.Name = "ColumnTimeout";
         // 
         // ColumnTls
         // 
         this.ColumnTls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.ColumnTls.HeaderText = "Secure (TLS)";
         this.ColumnTls.Name = "ColumnTls";
         this.ColumnTls.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this.ColumnTls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         // 
         // TestServer
         // 
         this.TestServer.HeaderText = "Test Connection";
         this.TestServer.Name = "TestServer";
         this.TestServer.Text = "Test";
         this.TestServer.UseColumnTextForButtonValue = true;
         // 
         // DefaultServer
         // 
         this.DefaultServer.HeaderText = "Default Server";
         this.DefaultServer.Name = "DefaultServer";
         // 
         // buttonAddServer
         // 
         this.buttonAddServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddServer.Image")));
         this.buttonAddServer.Location = new System.Drawing.Point(6, 6);
         this.buttonAddServer.Name = "buttonAddServer";
         this.buttonAddServer.Size = new System.Drawing.Size(40, 39);
         this.buttonAddServer.TabIndex = 7;
         this.buttonAddServer.UseVisualStyleBackColor = true;
         this.buttonAddServer.Click += new System.EventHandler(this.buttonAddServer_Click);
         // 
         // buttonDeleteServer
         // 
         this.buttonDeleteServer.CausesValidation = false;
         this.buttonDeleteServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteServer.Image")));
         this.buttonDeleteServer.Location = new System.Drawing.Point(49, 6);
         this.buttonDeleteServer.Name = "buttonDeleteServer";
         this.buttonDeleteServer.Size = new System.Drawing.Size(40, 39);
         this.buttonDeleteServer.TabIndex = 8;
         this.buttonDeleteServer.UseVisualStyleBackColor = true;
         this.buttonDeleteServer.Click += new System.EventHandler(this.buttonDeleteServer_Click);
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
         this._groupBoxSecurity.Location = new System.Drawing.Point(17, 93);
         this._groupBoxSecurity.Name = "_groupBoxSecurity";
         this._groupBoxSecurity.Size = new System.Drawing.Size(629, 136);
         this._groupBoxSecurity.TabIndex = 16;
         this._groupBoxSecurity.TabStop = false;
         this._groupBoxSecurity.Text = "Security";
         // 
         // _tbServers
         // 
         this._tbServers.Controls.Add(this._tbSCPQuerypage);
         this._tbServers.Controls.Add(this._tbMWLQueryPage);
         this._tbServers.Controls.Add(this._tbStorePage);
         this._tbServers.Location = new System.Drawing.Point(17, 246);
         this._tbServers.Name = "_tbServers";
         this._tbServers.SelectedIndex = 0;
         this._tbServers.Size = new System.Drawing.Size(633, 237);
         this._tbServers.TabIndex = 17;
         this._tbServers.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._tbServers_Selecting);
         this._tbServers.SelectedIndexChanged += new System.EventHandler(this._tbServers_SelectedIndexChanged);
         // 
         // _tbSCPQuerypage
         // 
         this._tbSCPQuerypage.Location = new System.Drawing.Point(4, 22);
         this._tbSCPQuerypage.Name = "_tbSCPQuerypage";
         this._tbSCPQuerypage.Padding = new System.Windows.Forms.Padding(3);
         this._tbSCPQuerypage.Size = new System.Drawing.Size(625, 211);
         this._tbSCPQuerypage.TabIndex = 0;
         this._tbSCPQuerypage.Text = "Query Servers";
         this._tbSCPQuerypage.UseVisualStyleBackColor = true;
         // 
         // _tbMWLQueryPage
         // 
         this._tbMWLQueryPage.Location = new System.Drawing.Point(4, 22);
         this._tbMWLQueryPage.Name = "_tbMWLQueryPage";
         this._tbMWLQueryPage.Padding = new System.Windows.Forms.Padding(3);
         this._tbMWLQueryPage.Size = new System.Drawing.Size(625, 211);
         this._tbMWLQueryPage.TabIndex = 1;
         this._tbMWLQueryPage.Text = "MWL Servers";
         this._tbMWLQueryPage.UseVisualStyleBackColor = true;
         // 
         // _tbStorePage
         // 
         this._tbStorePage.Location = new System.Drawing.Point(4, 22);
         this._tbStorePage.Name = "_tbStorePage";
         this._tbStorePage.Padding = new System.Windows.Forms.Padding(3);
         this._tbStorePage.Size = new System.Drawing.Size(625, 211);
         this._tbStorePage.TabIndex = 2;
         this._tbStorePage.Text = "PACS Storage Servers";
         this._tbStorePage.UseVisualStyleBackColor = true;
         // 
         // _tbOptions
         // 
         this._tbOptions.Controls.Add(this._tpApplicationOptions);
         this._tbOptions.Controls.Add(this._tpDicomOptions);
         this._tbOptions.Location = new System.Drawing.Point(12, 12);
         this._tbOptions.Name = "_tbOptions";
         this._tbOptions.SelectedIndex = 0;
         this._tbOptions.Size = new System.Drawing.Size(685, 521);
         this._tbOptions.TabIndex = 18;
         // 
         // _tpApplicationOptions
         // 
         this._tpApplicationOptions.Controls.Add(this._btnBrowseTempDir);
         this._tpApplicationOptions.Controls.Add(this._ckAutoDelete);
         this._tpApplicationOptions.Controls.Add(this.label3);
         this._tpApplicationOptions.Controls.Add(this._btnRename);
         this._tpApplicationOptions.Controls.Add(this._gpDicomType);
         this._tpApplicationOptions.Controls.Add(this._txtTempDir);
         this._tpApplicationOptions.Controls.Add(this._txtPrinterName);
         this._tpApplicationOptions.Controls.Add(this._lblPrinterName);
         this._tpApplicationOptions.Location = new System.Drawing.Point(4, 22);
         this._tpApplicationOptions.Name = "_tpApplicationOptions";
         this._tpApplicationOptions.Padding = new System.Windows.Forms.Padding(3);
         this._tpApplicationOptions.Size = new System.Drawing.Size(677, 495);
         this._tpApplicationOptions.TabIndex = 0;
         this._tpApplicationOptions.Text = "Application Options";
         this._tpApplicationOptions.UseVisualStyleBackColor = true;
         // 
         // _btnBrowseTempDir
         // 
         this._btnBrowseTempDir.Image = ((System.Drawing.Image)(resources.GetObject("_btnBrowseTempDir.Image")));
         this._btnBrowseTempDir.Location = new System.Drawing.Point(276, 310);
         this._btnBrowseTempDir.Name = "_btnBrowseTempDir";
         this._btnBrowseTempDir.Size = new System.Drawing.Size(23, 19);
         this._btnBrowseTempDir.TabIndex = 31;
         this._btnBrowseTempDir.UseVisualStyleBackColor = true;
         // 
         // _ckAutoDelete
         // 
         this._ckAutoDelete.AutoSize = true;
         this._ckAutoDelete.Location = new System.Drawing.Point(21, 449);
         this._ckAutoDelete.Name = "_ckAutoDelete";
         this._ckAutoDelete.Size = new System.Drawing.Size(232, 17);
         this._ckAutoDelete.TabIndex = 26;
         this._ckAutoDelete.Text = "Auto delete Images after successful transfer";
         this._ckAutoDelete.UseVisualStyleBackColor = true;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(96, 310);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(140, 13);
         this.label3.TabIndex = 23;
         this.label3.Text = "DICOM Temporary Directory";
         // 
         // _btnRename
         // 
         this._btnRename.Location = new System.Drawing.Point(454, 19);
         this._btnRename.Name = "_btnRename";
         this._btnRename.Size = new System.Drawing.Size(70, 23);
         this._btnRename.TabIndex = 22;
         this._btnRename.Text = "Rename";
         // 
         // _gpDicomType
         // 
         this._gpDicomType.Controls.Add(this._btnBrowseSCPDF);
         this._gpDicomType.Controls.Add(this._btnBrowseSCGray);
         this._gpDicomType.Controls.Add(this._btnBrowseSCColor);
         this._gpDicomType.Controls.Add(this._btnBrowseSC);
         this._gpDicomType.Controls.Add(this.label2);
         this._gpDicomType.Controls.Add(this._cmbSCColor);
         this._gpDicomType.Controls.Add(this._cmbSCGray);
         this._gpDicomType.Controls.Add(this._cmbSC);
         this._gpDicomType.Controls.Add(this.label1);
         this._gpDicomType.Controls.Add(this._rdPDF);
         this._gpDicomType.Controls.Add(this._rdGrayScale);
         this._gpDicomType.Controls.Add(this._rdColored);
         this._gpDicomType.Controls.Add(this._rdSecondaryCapture);
         this._gpDicomType.Controls.Add(this._txtSCPDF);
         this._gpDicomType.Controls.Add(this._txtSCGray);
         this._gpDicomType.Controls.Add(this._txtSCColor);
         this._gpDicomType.Controls.Add(this._txtSC);
         this._gpDicomType.Location = new System.Drawing.Point(21, 95);
         this._gpDicomType.Name = "_gpDicomType";
         this._gpDicomType.Size = new System.Drawing.Size(636, 155);
         this._gpDicomType.TabIndex = 7;
         this._gpDicomType.TabStop = false;
         this._gpDicomType.Text = "DICOM type";
         // 
         // _btnBrowseSCPDF
         // 
         this._btnBrowseSCPDF.Image = ((System.Drawing.Image)(resources.GetObject("_btnBrowseSCPDF.Image")));
         this._btnBrowseSCPDF.Location = new System.Drawing.Point(255, 118);
         this._btnBrowseSCPDF.Name = "_btnBrowseSCPDF";
         this._btnBrowseSCPDF.Size = new System.Drawing.Size(23, 19);
         this._btnBrowseSCPDF.TabIndex = 30;
         this._btnBrowseSCPDF.UseVisualStyleBackColor = true;
         // 
         // _btnBrowseSCGray
         // 
         this._btnBrowseSCGray.Image = ((System.Drawing.Image)(resources.GetObject("_btnBrowseSCGray.Image")));
         this._btnBrowseSCGray.Location = new System.Drawing.Point(255, 89);
         this._btnBrowseSCGray.Name = "_btnBrowseSCGray";
         this._btnBrowseSCGray.Size = new System.Drawing.Size(23, 19);
         this._btnBrowseSCGray.TabIndex = 29;
         this._btnBrowseSCGray.UseVisualStyleBackColor = true;
         // 
         // _btnBrowseSCColor
         // 
         this._btnBrowseSCColor.Image = ((System.Drawing.Image)(resources.GetObject("_btnBrowseSCColor.Image")));
         this._btnBrowseSCColor.Location = new System.Drawing.Point(255, 63);
         this._btnBrowseSCColor.Name = "_btnBrowseSCColor";
         this._btnBrowseSCColor.Size = new System.Drawing.Size(23, 19);
         this._btnBrowseSCColor.TabIndex = 28;
         this._btnBrowseSCColor.UseVisualStyleBackColor = true;
         // 
         // _btnBrowseSC
         // 
         this._btnBrowseSC.Image = ((System.Drawing.Image)(resources.GetObject("_btnBrowseSC.Image")));
         this._btnBrowseSC.Location = new System.Drawing.Point(255, 36);
         this._btnBrowseSC.Name = "_btnBrowseSC";
         this._btnBrowseSC.Size = new System.Drawing.Size(23, 19);
         this._btnBrowseSC.TabIndex = 27;
         this._btnBrowseSC.UseVisualStyleBackColor = true;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(519, 16);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(67, 13);
         this.label2.TabIndex = 20;
         this.label2.Text = "Compression";
         // 
         // _cmbSCColor
         // 
         this._cmbSCColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbSCColor.FormattingEnabled = true;
         this._cmbSCColor.Location = new System.Drawing.Point(522, 62);
         this._cmbSCColor.Name = "_cmbSCColor";
         this._cmbSCColor.Size = new System.Drawing.Size(100, 21);
         this._cmbSCColor.TabIndex = 19;
         // 
         // _cmbSCGray
         // 
         this._cmbSCGray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbSCGray.FormattingEnabled = true;
         this._cmbSCGray.Location = new System.Drawing.Point(522, 89);
         this._cmbSCGray.Name = "_cmbSCGray";
         this._cmbSCGray.Size = new System.Drawing.Size(100, 21);
         this._cmbSCGray.TabIndex = 18;
         // 
         // _cmbSC
         // 
         this._cmbSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbSC.FormattingEnabled = true;
         this._cmbSC.Location = new System.Drawing.Point(522, 35);
         this._cmbSC.Name = "_cmbSC";
         this._cmbSC.Size = new System.Drawing.Size(100, 21);
         this._cmbSC.TabIndex = 16;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(246, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 15;
         this.label1.Text = "Template";
         // 
         // _rdPDF
         // 
         this._rdPDF.AutoSize = true;
         this._rdPDF.Location = new System.Drawing.Point(15, 117);
         this._rdPDF.Name = "_rdPDF";
         this._rdPDF.Size = new System.Drawing.Size(84, 17);
         this._rdPDF.TabIndex = 14;
         this._rdPDF.Text = "DICOM PDF";
         this._rdPDF.UseVisualStyleBackColor = true;
         // 
         // _rdGrayScale
         // 
         this._rdGrayScale.AutoSize = true;
         this._rdGrayScale.Location = new System.Drawing.Point(15, 90);
         this._rdGrayScale.Name = "_rdGrayScale";
         this._rdGrayScale.Size = new System.Drawing.Size(223, 17);
         this._rdGrayScale.TabIndex = 13;
         this._rdGrayScale.Text = "Secondary Capture Multi-Frame Grayscale";
         this._rdGrayScale.UseVisualStyleBackColor = true;
         // 
         // _rdColored
         // 
         this._rdColored.AutoSize = true;
         this._rdColored.Location = new System.Drawing.Point(15, 63);
         this._rdColored.Name = "_rdColored";
         this._rdColored.Size = new System.Drawing.Size(200, 17);
         this._rdColored.TabIndex = 12;
         this._rdColored.Text = "Secondary Capture Multi-Frame Color";
         this._rdColored.UseVisualStyleBackColor = true;
         // 
         // _rdSecondaryCapture
         // 
         this._rdSecondaryCapture.AutoSize = true;
         this._rdSecondaryCapture.Checked = true;
         this._rdSecondaryCapture.Location = new System.Drawing.Point(15, 36);
         this._rdSecondaryCapture.Name = "_rdSecondaryCapture";
         this._rdSecondaryCapture.Size = new System.Drawing.Size(116, 17);
         this._rdSecondaryCapture.TabIndex = 11;
         this._rdSecondaryCapture.TabStop = true;
         this._rdSecondaryCapture.Text = "Secondary Capture";
         this._rdSecondaryCapture.UseVisualStyleBackColor = true;
         // 
         // _txtSCPDF
         // 
         this._txtSCPDF.Location = new System.Drawing.Point(284, 116);
         this._txtSCPDF.Name = "_txtSCPDF";
         this._txtSCPDF.Size = new System.Drawing.Size(219, 20);
         this._txtSCPDF.TabIndex = 10;
         this._txtSCPDF.Tag = "3";
         // 
         // _txtSCGray
         // 
         this._txtSCGray.Location = new System.Drawing.Point(284, 89);
         this._txtSCGray.Name = "_txtSCGray";
         this._txtSCGray.Size = new System.Drawing.Size(219, 20);
         this._txtSCGray.TabIndex = 9;
         this._txtSCGray.Tag = "2";
         // 
         // _txtSCColor
         // 
         this._txtSCColor.Location = new System.Drawing.Point(284, 62);
         this._txtSCColor.Name = "_txtSCColor";
         this._txtSCColor.Size = new System.Drawing.Size(219, 20);
         this._txtSCColor.TabIndex = 8;
         this._txtSCColor.Tag = "1";
         this._txtSCColor.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
         // 
         // _txtSC
         // 
         this._txtSC.Location = new System.Drawing.Point(284, 35);
         this._txtSC.Name = "_txtSC";
         this._txtSC.Size = new System.Drawing.Size(219, 20);
         this._txtSC.TabIndex = 7;
         this._txtSC.Tag = "0";
         // 
         // _txtTempDir
         // 
         this._txtTempDir.Location = new System.Drawing.Point(305, 310);
         this._txtTempDir.Name = "_txtTempDir";
         this._txtTempDir.Size = new System.Drawing.Size(338, 20);
         this._txtTempDir.TabIndex = 2;
         this._txtTempDir.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
         // 
         // _txtPrinterName
         // 
         this._txtPrinterName.BackColor = System.Drawing.Color.Gainsboro;
         this._txtPrinterName.Location = new System.Drawing.Point(179, 21);
         this._txtPrinterName.Name = "_txtPrinterName";
         this._txtPrinterName.ReadOnly = true;
         this._txtPrinterName.Size = new System.Drawing.Size(269, 20);
         this._txtPrinterName.TabIndex = 1;
         // 
         // _lblPrinterName
         // 
         this._lblPrinterName.AutoSize = true;
         this._lblPrinterName.Location = new System.Drawing.Point(18, 24);
         this._lblPrinterName.Name = "_lblPrinterName";
         this._lblPrinterName.Size = new System.Drawing.Size(137, 13);
         this._lblPrinterName.TabIndex = 0;
         this._lblPrinterName.Text = "DICOM Printer Driver Name";
         // 
         // _tpDicomOptions
         // 
         this._tpDicomOptions.Controls.Add(this._groupBoxSecurity);
         this._tpDicomOptions.Controls.Add(this._groupBoxClient);
         this._tpDicomOptions.Controls.Add(this._tbServers);
         this._tpDicomOptions.Location = new System.Drawing.Point(4, 22);
         this._tpDicomOptions.Name = "_tpDicomOptions";
         this._tpDicomOptions.Padding = new System.Windows.Forms.Padding(3);
         this._tpDicomOptions.Size = new System.Drawing.Size(677, 495);
         this._tpDicomOptions.TabIndex = 1;
         this._tpDicomOptions.Text = "PACS Settings";
         this._tpDicomOptions.UseVisualStyleBackColor = true;
         // 
         // OptionsDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(709, 572);
         this.Controls.Add(this._tbOptions);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
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
         this._tbServers.ResumeLayout(false);
         this._tbOptions.ResumeLayout(false);
         this._tpApplicationOptions.ResumeLayout(false);
         this._tpApplicationOptions.PerformLayout();
         this._gpDicomType.ResumeLayout(false);
         this._gpDicomType.PerformLayout();
         this._tpDicomOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      #region Properties

      public MyServerList ServerList
      {
         get
         {
            MyServerList serverlist = new MyServerList();
            MyServer[] items = new MyServer[dataGridViewServers.Rows.Count];
            for (int i = 0; i < dataGridViewServers.Rows.Count; i++)
            {
               items[i] = new MyServer();
               items[i]._sAE = dataGridViewServers.Rows[i].Cells["ColumnAE"].Value.ToString();
               items[i]._sIP = dataGridViewServers.Rows[i].Cells["ColumnIP"].Value.ToString();
               items[i]._timeout = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnTimeout"].Value);
               items[i]._port = Convert.ToInt32(dataGridViewServers.Rows[i].Cells["ColumnPort"].Value);
               items[i]._useTls = Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value);
            }
            serverlist.serverList = items;
            return serverlist;
         }

         set
         {
            dataGridViewServers.Rows.Clear();
            foreach (MyServer s in value.serverList)
            {
               int n = dataGridViewServers.Rows.Add();
               dataGridViewServers.Rows[n].Cells["ColumnAE"].Value = s._sAE;
               dataGridViewServers.Rows[n].Cells["ColumnIP"].Value = s._sIP;
               dataGridViewServers.Rows[n].Cells["ColumnTimeout"].Value = s._timeout.ToString();
               dataGridViewServers.Rows[n].Cells["ColumnPort"].Value = s._port.ToString();
               dataGridViewServers.Rows[n].Cells["ColumnTls"].Value = s._useTls.ToString();
            }
         }
      }

      public DicomClassType Selectedtype
      {
         get { return _selectedtype; }
         set { _selectedtype = value; }
      }

      public bool LogLowLevel
      {
         get { return _logLowLevel; }
         set { _logLowLevel = value; }
      }

      public string PrivateKeyPassword
      {
         get { return _privateKeyPassword; }
         set { _privateKeyPassword = value; }
      }

      public DicomImageCompressionType SCCompression
      {
         get { return _SCCompression; }
         set { _SCCompression = value; }
      }

      public DicomImageCompressionType SCColorCompression
      {
         get { return _SCColorCompression; }
         set { _SCColorCompression = value; }
      }

      public DicomImageCompressionType SCGrayCompression
      {
         get { return _SCGrayCompression; }
         set { _SCGrayCompression = value; }
      }

      public string SCPath
      {
         get { return _SCPath; }
         set { _SCPath = value; }
      }

      public string SCColorPath
      {
         get { return _SCColorPath; }
         set { _SCColorPath = value; }
      }

      public string SCGrayPath
      {
         get { return _SCGrayPath; }
         set { _SCGrayPath = value; }
      }

      public string PdfPath
      {
         get { return _PdfPath; }
         set { _PdfPath = value; }
      }

      public string PrinterName
      {
         get { return _PrinterName; }
         set { _PrinterName = value; }
      }

      public string TempDirectory
      {
         get { return _TempDirectory; }
         set { _TempDirectory = value; }
      }

      public bool AutoDelete
      {
         get { return _AutoDelete; }
         set { _AutoDelete = value; }
      }

      public int SelectedTab
      {
         get { return _iSelectedTab; }
         set { _iSelectedTab = value; }
      }

      public int DefaultSCPServer
      {
         get { return _defaultSCPServer; }
         set { _defaultSCPServer = value; }
      }

      public int DefaultMWLServer
      {
         get { return _defaultMWLServer; }
         set { _defaultMWLServer = value; }
      }

      public int DefaultStoreServer
      {
         get { return _defaultStoreServer; }
         set { _defaultStoreServer = value; }
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

      #endregion

      #region Form Events

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
         if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
         {
            e.Handled = true;
         }
      }

      private void buttonOK_Click(object sender, System.EventArgs e)
      {
         _tbServers_Selecting(null, null);
         if (IsAnyServerUseTls())
         {
            if (!CheckFileExists("Certificate", _textBoxClientCertificate, true))
               return;
            if (!CheckFileExists("Private Key", _textBoxPrivateKey, true))
               return;
         }


         ClientAE = _textBoxClientAE.Text;
         ClientCertificate = _textBoxClientCertificate.Text;
         PrivateKey = _textBoxPrivateKey.Text;
         PrivateKeyPassword = _textBoxKeyPassword.Text;

         SCPath = _txtSC.Text;
         SCColorPath = _txtSCColor.Text;
         SCGrayPath = _txtSCGray.Text;
         PdfPath = _txtSCPDF.Text;

         if (_rdGrayScale.Checked)
            Selectedtype = DicomClassType.SCMultiFrameGrayscaleByteImageStorage;
         if (_rdSecondaryCapture.Checked)
            Selectedtype = DicomClassType.SCImageStorage;
         if (_rdColored.Checked)
            Selectedtype = DicomClassType.SCMultiFrameTrueColorImageStorage;
         if (_rdPDF.Checked)
            Selectedtype = DicomClassType.EncapsulatedPdfStorage;

         SCCompression = ImgCompression[_cmbSC.SelectedIndex];
         SCColorCompression = ImgCompression[_cmbSCColor.SelectedIndex];
         SCGrayCompression = ImgCompression[_cmbSCGray.SelectedIndex];

         PrinterName = _txtPrinterName.Text;
         TempDirectory = _txtTempDir.Text;
         AutoDelete = _ckAutoDelete.Checked;

         DefaultSCPServer = _defaultSCPServer;
         DefaultMWLServer = _defaultMWLServer;
         DefaultStoreServer = _defaultStoreServer;

      }

      private void OptionsDialog_Load(object sender, EventArgs e)
      {
         _textBoxClientAE.Text = ClientAE;
         _textBoxClientCertificate.Text = ClientCertificate;
         _textBoxPrivateKey.Text = PrivateKey;
         _textBoxKeyPassword.Text = PrivateKeyPassword;
         EnableDialogItems();
         _tbSCPQuerypage.Tag = serverlistSCP;
         _tbMWLQueryPage.Tag = serverlistMWL;
         _tbStorePage.Tag = serverlistStore;
         _tbServers_Selecting(null, null);
         _btnBrowseSC.Tag = _txtSC;
         _btnBrowseSCColor.Tag = _txtSCColor;
         _btnBrowseSCGray.Tag = _txtSCGray;
         _btnBrowseSCPDF.Tag = _txtSCPDF;

         _btnRename.Click += new EventHandler(_btnRename_Click);
         _btnBrowseTempDir.Click += new EventHandler(_btnBrowseTempDir_Click);

         _btnBrowseSC.Click += new EventHandler(_btnBrowseSC_Click);
         _btnBrowseSCColor.Click += new EventHandler(_btnBrowseSC_Click);
         _btnBrowseSCGray.Click += new EventHandler(_btnBrowseSC_Click);
         _btnBrowseSCPDF.Click += new EventHandler(_btnBrowseSC_Click);

         _txtSC.Leave += new EventHandler(_txt_Leave);
         _txtSCColor.Leave += new EventHandler(_txt_Leave);
         _txtSCGray.Leave += new EventHandler(_txt_Leave);
         _txtSCPDF.Leave += new EventHandler(_txt_Leave);

         _txtTempDir.Leave += new EventHandler(_txtTempDir_Leave);

         _cmbSC.Items.AddRange(Compressions.ToArray());
         _cmbSCColor.Items.AddRange(Compressions.ToArray());
         _cmbSCGray.Items.AddRange(Compressions.ToArray());

         _txtSC.Text = SCPath;
         _txtSCGray.Text = SCGrayPath;
         _txtSCColor.Text = SCColorPath;
         _txtSCPDF.Text = PdfPath;

         _txtSC.Text = SCPath;
         _txtSCGray.Text = SCGrayPath;
         _txtSCColor.Text = SCColorPath;
         _txtSCPDF.Text = PdfPath;

         _txtTempDir.Text = TempDirectory;
         _txtPrinterName.Text = PrinterName;

         _cmbSC.SelectedIndex = ImgCompression.IndexOf(SCCompression);
         _cmbSCColor.SelectedIndex = ImgCompression.IndexOf(SCColorCompression);
         _cmbSCGray.SelectedIndex = ImgCompression.IndexOf(SCGrayCompression);

         if (Selectedtype == DicomClassType.SCMultiFrameGrayscaleByteImageStorage)
            _rdGrayScale.Checked = true;
         if (Selectedtype == DicomClassType.SCImageStorage)
            _rdSecondaryCapture.Checked = true;
         if (Selectedtype == DicomClassType.SCMultiFrameTrueColorImageStorage)
            _rdColored.Checked = true;
         if (Selectedtype == DicomClassType.EncapsulatedPdfStorage)
            _rdPDF.Checked = true;

         _ckAutoDelete.Checked = _AutoDelete;

         if (_tbOptions.TabCount > SelectedTab)
         _tbOptions.SelectedIndex = SelectedTab;
      }

      void _txtTempDir_Leave(object sender, EventArgs e)
      {
         if (!Directory.Exists(_txtTempDir.Text))
         {
            MessageBox.Show("The selected directory does not exist");
            _txtTempDir.Text = "";
         }
      }

      void _btnRename_Click(object sender, EventArgs e)
      {
         InputDialog input = new InputDialog("Change Printer Driver Name", "New Printer Driver Name", _txtPrinterName.Text);
         if (input.ShowDialog() != DialogResult.Cancel)
         {
            _txtPrinterName.Text = input.Value;
         }
      }

      void _btnBrowseTempDir_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
         dlgFolder.ShowNewFolderButton = true;
         DialogResult dlgRes = dlgFolder.ShowDialog();

         if (dlgRes != DialogResult.OK)
            return;

         _txtTempDir.Text = dlgFolder.SelectedPath;
      }

      void _btnBrowseSC_Click(object sender, EventArgs e)
      {
         OpenFileDialog dlgOpen = new OpenFileDialog();
         dlgOpen.Filter = "DICOM Xml files|*.xml";
         DialogResult dlgRes = dlgOpen.ShowDialog();
         if (dlgRes == DialogResult.Cancel)
            return;

         TextBox textBox = ((sender as Button).Tag as TextBox);
         textBox.Text = dlgOpen.FileName;
         _txt_Leave(textBox, e);

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
            int iDefaultRowNumber = -1;
            if (_tbServers.SelectedIndex == 0)
               iDefaultRowNumber = DefaultSCPServer;
            if (_tbServers.SelectedIndex == 1)
               iDefaultRowNumber = DefaultMWLServer;
            if (_tbServers.SelectedIndex == 2)
               iDefaultRowNumber = DefaultStoreServer;

            bool bDefaultChanged = false;
            foreach (DataGridViewRow row in dataGridViewServers.SelectedRows)
            {
               if (row.Cells[6].Value != null && (bool)row.Cells[6].Value == true)
                  bDefaultChanged = true;
               dataGridViewServers.Rows.Remove(row);
            }

            if (bDefaultChanged)
               if (dataGridViewServers.Rows.Count > 0)
                  dataGridViewServers.Rows[0].Cells[6].Value = true;

            if (_tbServers.SelectedIndex == 0)
               DefaultSCPServer = iDefaultRowNumber;
            if (_tbServers.SelectedIndex == 1)
               DefaultMWLServer = iDefaultRowNumber;
            if (_tbServers.SelectedIndex == 2)
               DefaultStoreServer = iDefaultRowNumber;
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
               //Utils.ResolveIPAddress(ip);
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
               validatingRow.Cells[ColumnTimeout.Name].Value = 15;
               e.Cancel = false;
               return;
            }

            validatingRow.ErrorText = "";

            int iDefault = -1;
            TabPage tbPage = _tbServers.SelectedTab;
            if (_tbMWLQueryPage == tbPage)
               iDefault = _defaultMWLServer;

            if (_tbSCPQuerypage == tbPage)
               iDefault = _defaultSCPServer;

            if (_tbStorePage == tbPage)
               iDefault = _defaultStoreServer;

            if (dataGridViewServers.Rows.Count > 0)
            {
               if (e.RowIndex == iDefault && e.ColumnIndex == 6)
                  dataGridViewServers.Rows[e.RowIndex].Cells[6].Value = true;
            }

         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Assert(false, ex.Message);
            throw;
         }
      }

      private void dataGridViewServers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
      {
         DataGridView d = sender as DataGridView;
         if (d != null)
         {
            DataGridViewCheckBoxCell cb = d.CurrentCell as DataGridViewCheckBoxCell;
            if (cb != null && cb.ColumnIndex != 6)
            {
               d.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
               TabPage page = _tbServers.SelectedTab;
               MyServerList servers = (MyServerList)page.Tag;

               try
               {
                  ServerList.serverList[d.CurrentCell.RowIndex]._useTls = Convert.ToBoolean(dataGridViewServers.Rows[d.CurrentCell.RowIndex].Cells["ColumnTls"].Value);
                  EnableDialogItems();
               }
               catch { }

            }
         }
      }

      private void _tbServers_SelectedIndexChanged(object sender, EventArgs e)
      {

      }

      private void _tbServers_Selecting(object sender, TabControlCancelEventArgs e)
      {
         foreach (TabPage page in _tbServers.TabPages)
         {
            if (page.Controls.Count != 0)
            {
               page.Controls.Clear();
               MyServerList servers = (MyServerList)page.Tag;

               if (_tbMWLQueryPage == page)
                  serverlistMWL = ServerList;
               if (_tbSCPQuerypage == page)
                  serverlistSCP = ServerList;
               if (_tbStorePage == page)
                  serverlistStore = ServerList;

            }
         }

         TabPage tbPage = _tbServers.SelectedTab;
         tbPage.Controls.Add(buttonDeleteServer);
         tbPage.Controls.Add(buttonAddServer);
         tbPage.Controls.Add(dataGridViewServers);
         int iDefault = -1;
         if (_tbMWLQueryPage == tbPage)
         {
            ServerList = serverlistMWL;
            iDefault = _defaultMWLServer;
         }
         if (_tbSCPQuerypage == tbPage)
         {
            ServerList = serverlistSCP;
            iDefault = _defaultSCPServer;
         }
         if (_tbStorePage == tbPage)
         {
            ServerList = serverlistStore;
            iDefault = _defaultStoreServer;
         }

         if (dataGridViewServers.Rows.Count > 0)
         {
            if (dataGridViewServers.Rows.Count <= iDefault)
               iDefault = dataGridViewServers.Rows.Count - 1;
            dataGridViewServers.Rows[iDefault].Cells[6].Value = true;
         }
      }

      private void textBox4_TextChanged(object sender, EventArgs e)
      {

      }

      private void textBox2_TextChanged(object sender, EventArgs e)
      {

      }

      private void _txt_Leave(object sender, EventArgs e)
      {
         TextBox txtBox = sender as TextBox;
         int iClass = int.Parse((string)txtBox.Tag);
         DicomClassType dclass = ClassTypes[iClass];
         if (txtBox.Text == string.Empty)
            return;
         DicomDataSet ds = new DicomDataSet();
         try
         {
            DicomExtensions.LoadXml(ds, txtBox.Text, DicomDataSetLoadXmlFlags.None);
         }
         catch
         { ds = null; }

         if (ds == null)
         {
            MessageBox.Show("The selected file is not a valid DICOM XML File");
            txtBox.Text = "";
         }
         else
            if (ds.InformationClass != dclass)
            {
               MessageBox.Show("The selected DICOM XML file is not a " + dclass.ToString() + " file");
               txtBox.Text = "";
            }

      }

      private void dataGridViewServers_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            try
            {
               CheckAssociation((sender as Control).Parent, e.RowIndex);
            }
            catch
            {
               MessageBox.Show(this, "Some fields are not valid", "Print To PACS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         MyServerList servers = (MyServerList)_tbServers.SelectedTab.Tag;
         if (e.ColumnIndex == 6 && e.RowIndex >= 0)
         {
            foreach (DataGridViewRow row in dataGridViewServers.Rows)
            {
               row.Cells[6].Value = false;
            }

            dataGridViewServers[6, e.RowIndex].Value = true;
            if ((sender as Control).Parent == _tbMWLQueryPage)
               _defaultMWLServer = e.RowIndex;
            if ((sender as Control).Parent == _tbSCPQuerypage)
               _defaultSCPServer = e.RowIndex;
            if ((sender as Control).Parent == _tbStorePage)
               _defaultStoreServer = e.RowIndex;
         }
         EnableDialogItems();
      }

      private void _find_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         bTimeOut = false;
         foreach (AssociationHolder association in lstAssociations)
         {
            try
            {
               association.Result = e.Associate.GetResult(association.PresentationContextNumber) == DicomAssociateAcceptResultType.Success ? "Success" : "Failed";
            }
            catch { association.Result = "Failed"; }
         }
      }

      private void _find_BeforeAssociateRequest(object sender, BeforeAssociateRequestEventArgs e)
      {
         for (int i = 0; i <= e.Associate.PresentationContextCount; i++)
         {
            e.Associate.DeletePresentation((byte)(2 * i + 1));
         }
         foreach (AssociationHolder association in lstAssociations)
         {
            e.Associate.AddPresentationContext(association.PresentationContextNumber, DicomAssociateAcceptResultType.Success, association.PresentationContext);
            foreach (string str in association.TransferSyntax)
               e.Associate.AddTransfer(association.PresentationContextNumber, str);
         }
      }

      private void _find_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         //if (e.Error == DicomExceptionCode.Success)
         //   MessageBox.Show("Dicom Verification Success");
         //else
         //   MessageBox.Show("Dicom Verification Failed");
      }

      #endregion

      #region Methods

      private void CheckAssociation(Control parent, int iRow)
      {
         string strServerAE = dataGridViewServers[0, iRow].Value.ToString();
         string strServerIP = dataGridViewServers[1, iRow].Value.ToString();
         string strServerPort = dataGridViewServers[2, iRow].Value.ToString();
         string strServerTimeOut = null;
         try
         {
            strServerTimeOut = dataGridViewServers[3, iRow].Value.ToString();
         }
         catch { dataGridViewServers[3, iRow].Value = strServerTimeOut = "15"; }

         bool tls = false;
         if (dataGridViewServers[4, iRow].Value != null)
            tls = bool.Parse(dataGridViewServers[4, iRow].Value.ToString());

         DicomScp dicomScp = new DicomScp();
         dicomScp.AETitle = strServerAE;
         dicomScp.PeerAddress = IPAddress.Parse(strServerIP);
         dicomScp.Port = int.Parse(strServerPort);
         dicomScp.Timeout = int.Parse(strServerTimeOut);
         QueryRetrieveScu _find = null;

#if !LEADTOOLS_V20_OR_LATER
         if (tls)
            _find = new QueryRetrieveScu(_txtTempDir.Text, DicomNetSecurityeMode.Tls, null);
         else
            _find = new QueryRetrieveScu(null, DicomNetSecurityeMode.None, null);
#else
         if (tls)
            _find = new QueryRetrieveScu(_txtTempDir.Text, DicomNetSecurityMode.Tls, null);
         else
            _find = new QueryRetrieveScu(null, DicomNetSecurityMode.None, null);
#endif // #if !LEADTOOLS_V20_OR_LATER

         try
         {

            _find.ImplementationClass = FrmMain._sConfigurationImplementationClass;
            _find.ProtocolVersion = FrmMain._sConfigurationProtocolversion;
            _find.ImplementationVersionName = FrmMain._sConfigurationImplementationVersionName;
            _find.AETitle = _textBoxClientAE.Text;
            _find.HostPort = 1000;

            _find.AfterConnect += new AfterConnectDelegate(_find_AfterConnect);
            _find.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(_find_BeforeAssociateRequest);
            _find.AfterAssociateRequest += new AfterAssociateRequestDelegate(_find_AfterAssociateRequest);
            _find.PrivateKeyPassword += new PrivateKeyPasswordDelegate(_find_PrivateKeyPassword);
            if (tls)
            {
               try
               {
                  if (!CheckFileExists("Certificate", _textBoxClientCertificate, true))
                     return;
                  if (!CheckFileExists("Private Key", _textBoxPrivateKey, true))
                     return;

                  _find.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha);
                  _find.SetTlsClientCertificate(
                     _textBoxClientCertificate.Text,
                     DicomTlsCertificateType.Pem,
                     _textBoxPrivateKey.Text.Length > 0 ? _textBoxPrivateKey.Text : null);
               }
               catch (Exception ex)
               {
                  MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
            }

            DoAssociation(dicomScp, _find, parent != _tbStorePage);
         }
         catch { }
      }

      void _find_PrivateKeyPassword(object sender, PrivateKeyPasswordEventArgs e)
      {
         e.PrivateKeyPassword = _textBoxKeyPassword.Text;
      }

      private void EnableDialogItems()
      {
         bool bEnable = IsAnyServerUseTls();
         _labelCertificate.Enabled = bEnable;
         _buttonClientCertificate.Enabled = bEnable;
         _textBoxClientCertificate.Enabled = bEnable;

         _labelPrivateKey.Enabled = bEnable;
         _buttonClientCertificate.Enabled = bEnable;
         _textBoxClientCertificate.Enabled = bEnable;

         _labelPrivateKey.Enabled = bEnable;
         _buttonPrivateKey.Enabled = bEnable;
         _textBoxPrivateKey.Enabled = bEnable;

         _labelPrivateKeyPassword.Enabled = bEnable;
         _textBoxKeyPassword.Enabled = bEnable;
         _labelHint.Enabled = bEnable;
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

      private bool CheckFileExists(string title, TextBox tb, bool showMessageBox)
      {
         bool ret = true;
         string sMsg = string.Empty;
         string sFile = tb.Text.Trim();
         if (sFile.Length == 0)
         {
            sMsg = title + " Field Error\nField can not be empty if 'Secure (TLS)' is checked.";
            ret = false;
         }
         else if (!File.Exists(sFile))
         {
            sMsg = title + " Field Error\nFile does not exist: " + sFile;
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

      private void DoAssociation(DicomScp dicomScp, QueryRetrieveScu _find, bool bFind)
      {
         string strError = "";
         if (!bFind)
         {
            lstAssociations = new List<AssociationHolder>();
            List<string> transfersyntax;

            transfersyntax = new List<string>();
            transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian);
            lstAssociations.Add(new AssociationHolder(1, DicomUidType.VerificationClass, transfersyntax, "DICOM Verification"));

            //Encapsulated Pdf Storage
            transfersyntax = new List<string>();
            transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian);
            transfersyntax.Add(DicomUidType.ExplicitVRLittleEndian);
            lstAssociations.Add(new AssociationHolder(3, DicomUidType.EncapsulatedPdfStorage, transfersyntax, "\nEncapsulated PDF Storage"));

            iLastNumber = 3;
            AddAssociate(lstAssociations, "\nSecondary Capture Image Storage", DicomUidType.SCImageStorage);
            AddAssociate(lstAssociations, "\nSecondary Capture Multi-Frame Grayscale Byte Image Storage", DicomUidType.SCMultiFrameTrueColorImageStorage);
            AddAssociate(lstAssociations, "\nSecondary Capture Multi-Frame True Color Image Storage", DicomUidType.SCMultiFrameGrayscaleByteImageStorage);

            try
            {
               bTimeOut = true;
               _find.Verify(dicomScp);
            }
            catch (Exception ex)
            {
               strError = ", Reason:\n" + ex.Message;
               bTimeOut = true;
            }
            if (bTimeOut)
               MessageBox.Show("DICOM Verification Failed" + strError, "Print To PACS");
            else
            {
               string Result = "";
               foreach (AssociationHolder associate in lstAssociations)
               {
                  Result += associate.Title + "  " + associate.Result + "\n";
               }
               MessageBox.Show(Result, "Print To PACS");
            }
         }
         else
         {
            lstAssociations = new List<AssociationHolder>();
            List<string> transfersyntax = new List<string>();
            transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian);
            lstAssociations.Add(new AssociationHolder(1, DicomUidType.VerificationClass, transfersyntax, "DICOM Verification"));

            try
            {
               bTimeOut = true;
               _find.Verify(dicomScp);
            }
            catch (Exception ex)
            {
               strError = ", Reason:\n" + ex.Message;
               bTimeOut = true;
            }
            if (bTimeOut)
               MessageBox.Show("DICOM Verification Failed" + strError, "Print To PACS");
            else
            {
               string Result = "";
               foreach (AssociationHolder associate in lstAssociations)
               {
                  Result += associate.Title + "  " + associate.Result + "\n";
               }
               MessageBox.Show(Result, "Print To PACS");
            }
         }
      }

      private void AddAssociate(List<AssociationHolder> lstAssociations, string strTitle, string strClass)
      {
         List<string> transfersyntax;
         iLastNumber += 2;
         //Secondary Capture Image Storage
         transfersyntax = new List<string>();
         transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian);
         transfersyntax.Add(DicomUidType.ExplicitVRLittleEndian);
         lstAssociations.Add(new AssociationHolder((byte)iLastNumber, strClass, transfersyntax, strTitle));
         iLastNumber += 2;
         //JPEG Baseline (Process 1)
         transfersyntax = new List<string>();
         transfersyntax.Add(DicomUidType.JPEGBaseline1);
         lstAssociations.Add(new AssociationHolder((byte)iLastNumber, strClass, transfersyntax, "--> JPEG Baseline (Process 1)"));
         iLastNumber += 2;
         //JPEG Lossless, Non-Hierarchical, First-Order Prediction 
         transfersyntax = new List<string>();
         transfersyntax.Add(DicomUidType.JPEGLosslessNonhier14B);
         lstAssociations.Add(new AssociationHolder((byte)iLastNumber, strClass, transfersyntax, "--> JPEG Lossless, Non-Hierarchical, First-Order Prediction"));
         iLastNumber += 2;
         //JPEG 2000 Image Compression (Lossless Only)
         transfersyntax = new List<string>();
         transfersyntax.Add(DicomUidType.JPEG2000LosslessOnly);
         lstAssociations.Add(new AssociationHolder((byte)iLastNumber, strClass, transfersyntax, "--> JPEG 2000 Image Compression (Lossless Only)"));
         iLastNumber += 2;
         //JPEG 2000 Image Compression
         transfersyntax = new List<string>();
         transfersyntax.Add(DicomUidType.JPEG2000);
         lstAssociations.Add(new AssociationHolder((byte)iLastNumber, strClass, transfersyntax, "--> JPEG 2000 Image Compression"));
      }

      // Return true if any of the servers are using tls
      // Return false if all of the servers do not use tls
      private bool IsAnyServerUseTls()
      {
         UpdateServers();

         for (int i = 0; i < serverlistSCP.serverList.Length; i++)
         {
            if (serverlistSCP.serverList[i]._useTls)
               return true;
         }
         for (int i = 0; i < serverlistMWL.serverList.Length; i++)
         {
            if (serverlistMWL.serverList[i]._useTls)
               return true;
         }
         for (int i = 0; i < serverlistStore.serverList.Length; i++)
         {
            if (serverlistStore.serverList[i]._useTls)
               return true;
         }
         return false;
      }

      private void UpdateServers()
      {
         try
         {
            if (_tbServers.SelectedTab == _tbSCPQuerypage)
               for (int i = 0; i < serverlistSCP.serverList.Length; i++)
                  serverlistSCP.serverList[i]._useTls = Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value);

            if (_tbServers.SelectedTab == _tbMWLQueryPage)
               for (int i = 0; i < serverlistSCP.serverList.Length; i++)
                  serverlistMWL.serverList[i]._useTls = Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value);

            if (_tbServers.SelectedTab == _tbStorePage)
               for (int i = 0; i < serverlistSCP.serverList.Length; i++)
                  serverlistStore.serverList[i]._useTls = Convert.ToBoolean(dataGridViewServers.Rows[i].Cells["ColumnTls"].Value);
         }
         catch { }
      }

      #endregion
   }

   class AssociationHolder
   {
      public string Title;
      public string Result;
      public string PresentationContext;
      public List<string> TransferSyntax;
      public byte PresentationContextNumber;

      public AssociationHolder(byte presentationContextNumber, string presentationContext, List<string> transferSyntax, string title)
      {
         PresentationContext = presentationContext;
         TransferSyntax = transferSyntax;
         PresentationContextNumber = presentationContextNumber;
         Title = title;
      }
   }
}


