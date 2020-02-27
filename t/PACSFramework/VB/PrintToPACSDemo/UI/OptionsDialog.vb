' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO
Imports PrintToPACS.Utilities
Imports System.Net
Imports System.Collections.Generic
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions
Imports PrinterDemo
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools
Imports Leadtools.Dicom.Scu
Imports System.Diagnostics
Imports System.Threading
Imports System.Runtime.InteropServices
Imports Leadtools.DicomDemos

Namespace PrintToPACSDemo
   ''' <summary>
   ''' Summary description for OptionsDialog.
   ''' </summary>
   Public Class OptionsDialog : Inherits System.Windows.Forms.Form
#Region "Fields"

   Private _groupBoxClient As System.Windows.Forms.GroupBox
   Private _labelClientAE As System.Windows.Forms.Label
   Public _textBoxClientAE As System.Windows.Forms.TextBox
   Private WithEvents buttonOK As System.Windows.Forms.Button
   Private buttonCancel As System.Windows.Forms.Button
   Private _labelHint As Label
   Private _textBoxKeyPassword As TextBox
   Private _textBoxPrivateKey As TextBox
   Private WithEvents _buttonPrivateKey As Button
   Private _labelPrivateKey As Label
   Private _labelPrivateKeyPassword As Label
   Private _textBoxClientCertificate As TextBox
   Private WithEvents _buttonClientCertificate As Button
   Private _labelCertificate As Label
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.Container = Nothing


   Private _clientAE As String
   Public serverlistSCP As MyServerList
   Public serverlistMWL As MyServerList
   Public serverlistStore As MyServerList
   Private lstAssociations As List(Of AssociationHolder)
   Private iLastNumber As Integer = 1

   Private ClassTypes As List(Of DicomClassType)

   Private _clientCertificate As String
   Private _defaultSCPServer As Integer = 0
   Private _defaultMWLServer As Integer = 0
   Private _defaultStoreServer As Integer = 0
   Private _privateKey As String
   Private _privateKeyPassword As String
   Private _SCCompression As DicomImageCompressionType
   Private _SCColorCompression As DicomImageCompressionType
   Private _SCGrayCompression As DicomImageCompressionType
   Private _SCPath As String
   Private _SCColorPath As String
   Private _SCGrayPath As String
   Private _PdfPath As String
   Private _PrinterName As String
   Private _TempDirectory As String
   Private _AutoDelete As Boolean
   Private _iSelectedTab As Integer
   Private WithEvents dataGridViewServers As DataGridView
   Private WithEvents buttonAddServer As Button
   Private WithEvents buttonDeleteServer As Button
   Private _groupBoxSecurity As GroupBox
   Private WithEvents _tbServers As TabControl
   Private _tbSCPQuerypage As TabPage
   Private _tbMWLQueryPage As TabPage
   Private _tbStorePage As TabPage
   Private _tbOptions As TabControl
   Private _tpApplicationOptions As TabPage
   Private _tpDicomOptions As TabPage
   Private _gpDicomType As GroupBox
   Private _txtSCPDF As TextBox
   Private _txtSCGray As TextBox
   Private WithEvents _txtSCColor As TextBox
   Private _txtSC As TextBox
   Private WithEvents _txtTempDir As TextBox
   Private _txtPrinterName As TextBox
   Private _lblPrinterName As Label
   Private label2 As Label
   Private _cmbSCColor As ComboBox
   Private _cmbSCGray As ComboBox
   Private _cmbSC As ComboBox
   Private label1 As Label
   Private _rdPDF As RadioButton
   Private _rdGrayScale As RadioButton
   Private _rdColored As RadioButton
   Private _rdSecondaryCapture As RadioButton
   Private _ckAutoDelete As CheckBox
   Private label3 As Label
   Private _btnRename As Button
   Private _logLowLevel As Boolean
   Private _selectedtype As DicomClassType

   Private Compressions As List(Of String)

   Private ImgCompression As List(Of DicomImageCompressionType)
   Private bTimeOut As Boolean = True
   Private _btnBrowseSCPDF As Button
   Private _btnBrowseSCGray As Button
   Private _btnBrowseSCColor As Button
   Private _btnBrowseSC As Button
   Private ColumnAE As DataGridViewTextBoxColumn
   Private ColumnIP As DataGridViewTextBoxColumn
   Private ColumnPort As DataGridViewTextBoxColumn
   Private ColumnTimeout As DataGridViewTextBoxColumn
   Private ColumnTls As DataGridViewCheckBoxColumn
   Private TestServer As DataGridViewButtonColumn
   Private DefaultServer As DataGridViewCheckBoxColumn
   Private _btnBrowseTempDir As Button

#End Region

#Region "Constructor"
   Public Sub New()
   '
   ' Required for Windows Form Designer support
   '
   InitializeComponent()

   '
   ' TODO: Add any constructor code after InitializeComponent call
   ''
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
   If disposing Then
   If Not components Is Nothing Then
      components.Dispose()
   End If
   End If
   MyBase.Dispose(disposing)
   End Sub

#End Region

#Region "Windows Form Designer generated code"
   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
   Me._groupBoxClient = New System.Windows.Forms.GroupBox()
   Me._textBoxClientAE = New System.Windows.Forms.TextBox()
   Me._labelClientAE = New System.Windows.Forms.Label()
   Me._labelHint = New System.Windows.Forms.Label()
   Me._textBoxKeyPassword = New System.Windows.Forms.TextBox()
   Me._textBoxPrivateKey = New System.Windows.Forms.TextBox()
   Me._buttonPrivateKey = New System.Windows.Forms.Button()
   Me._labelPrivateKey = New System.Windows.Forms.Label()
   Me._labelPrivateKeyPassword = New System.Windows.Forms.Label()
   Me._textBoxClientCertificate = New System.Windows.Forms.TextBox()
   Me._buttonClientCertificate = New System.Windows.Forms.Button()
   Me._labelCertificate = New System.Windows.Forms.Label()
   Me.buttonOK = New System.Windows.Forms.Button()
   Me.buttonCancel = New System.Windows.Forms.Button()
   Me.dataGridViewServers = New System.Windows.Forms.DataGridView()
   Me.ColumnAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
   Me.ColumnIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
   Me.ColumnPort = New System.Windows.Forms.DataGridViewTextBoxColumn()
   Me.ColumnTimeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
   Me.ColumnTls = New System.Windows.Forms.DataGridViewCheckBoxColumn()
   Me.TestServer = New System.Windows.Forms.DataGridViewButtonColumn()
   Me.DefaultServer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
   Me.buttonAddServer = New System.Windows.Forms.Button()
   Me.buttonDeleteServer = New System.Windows.Forms.Button()
   Me._groupBoxSecurity = New System.Windows.Forms.GroupBox()
   Me._tbServers = New System.Windows.Forms.TabControl()
   Me._tbSCPQuerypage = New System.Windows.Forms.TabPage()
   Me._tbMWLQueryPage = New System.Windows.Forms.TabPage()
   Me._tbStorePage = New System.Windows.Forms.TabPage()
   Me._tbOptions = New System.Windows.Forms.TabControl()
   Me._tpApplicationOptions = New System.Windows.Forms.TabPage()
   Me._btnBrowseTempDir = New System.Windows.Forms.Button()
   Me._ckAutoDelete = New System.Windows.Forms.CheckBox()
   Me.label3 = New System.Windows.Forms.Label()
   Me._btnRename = New System.Windows.Forms.Button()
   Me._gpDicomType = New System.Windows.Forms.GroupBox()
   Me._btnBrowseSCPDF = New System.Windows.Forms.Button()
   Me._btnBrowseSCGray = New System.Windows.Forms.Button()
   Me._btnBrowseSCColor = New System.Windows.Forms.Button()
   Me._btnBrowseSC = New System.Windows.Forms.Button()
   Me.label2 = New System.Windows.Forms.Label()
   Me._cmbSCColor = New System.Windows.Forms.ComboBox()
   Me._cmbSCGray = New System.Windows.Forms.ComboBox()
   Me._cmbSC = New System.Windows.Forms.ComboBox()
   Me.label1 = New System.Windows.Forms.Label()
   Me._rdPDF = New System.Windows.Forms.RadioButton()
   Me._rdGrayScale = New System.Windows.Forms.RadioButton()
   Me._rdColored = New System.Windows.Forms.RadioButton()
   Me._rdSecondaryCapture = New System.Windows.Forms.RadioButton()
   Me._txtSCPDF = New System.Windows.Forms.TextBox()
   Me._txtSCGray = New System.Windows.Forms.TextBox()
   Me._txtSCColor = New System.Windows.Forms.TextBox()
   Me._txtSC = New System.Windows.Forms.TextBox()
   Me._txtTempDir = New System.Windows.Forms.TextBox()
   Me._txtPrinterName = New System.Windows.Forms.TextBox()
   Me._lblPrinterName = New System.Windows.Forms.Label()
   Me._tpDicomOptions = New System.Windows.Forms.TabPage()
   Me._groupBoxClient.SuspendLayout()
   CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).BeginInit()
   Me._groupBoxSecurity.SuspendLayout()
   Me._tbServers.SuspendLayout()
   Me._tbOptions.SuspendLayout()
   Me._tpApplicationOptions.SuspendLayout()
   Me._gpDicomType.SuspendLayout()
   Me._tpDicomOptions.SuspendLayout()
   Me.SuspendLayout()
   ' 
   ' _groupBoxClient
   ' 
   Me._groupBoxClient.Controls.Add(Me._textBoxClientAE)
   Me._groupBoxClient.Controls.Add(Me._labelClientAE)
   Me._groupBoxClient.Location = New System.Drawing.Point(16, 18)
   Me._groupBoxClient.Name = "_groupBoxClient"
   Me._groupBoxClient.Size = New System.Drawing.Size(630, 68)
   Me._groupBoxClient.TabIndex = 1
   Me._groupBoxClient.TabStop = False
   Me._groupBoxClient.Text = "Client Information"
   ' 
   ' _textBoxClientAE
   ' 
   Me._textBoxClientAE.Location = New System.Drawing.Point(142, 26)
   Me._textBoxClientAE.Name = "_textBoxClientAE"
   Me._textBoxClientAE.Size = New System.Drawing.Size(469, 20)
   Me._textBoxClientAE.TabIndex = 1
   ' 
   ' _labelClientAE
   ' 
   Me._labelClientAE.AutoSize = True
   Me._labelClientAE.Location = New System.Drawing.Point(16, 30)
   Me._labelClientAE.Name = "_labelClientAE"
   Me._labelClientAE.Size = New System.Drawing.Size(112, 13)
   Me._labelClientAE.TabIndex = 0
   Me._labelClientAE.Text = "PrintToPACS AE Title:"
   ' 
   ' _labelHint
   ' 
   Me._labelHint.AutoSize = True
   Me._labelHint.ForeColor = System.Drawing.Color.Blue
   Me._labelHint.Location = New System.Drawing.Point(300, 96)
   Me._labelHint.Name = "_labelHint"
   Me._labelHint.Size = New System.Drawing.Size(140, 13)
   Me._labelHint.TabIndex = 15
   Me._labelHint.Text = "<== Use 'test'  for client.pem"
   ' 
   ' _textBoxKeyPassword
   ' 
   Me._textBoxKeyPassword.Location = New System.Drawing.Point(141, 93)
   Me._textBoxKeyPassword.Name = "_textBoxKeyPassword"
   Me._textBoxKeyPassword.Size = New System.Drawing.Size(146, 20)
   Me._textBoxKeyPassword.TabIndex = 14
   ' 
   ' _textBoxPrivateKey
   ' 
   Me._textBoxPrivateKey.Location = New System.Drawing.Point(141, 61)
   Me._textBoxPrivateKey.Name = "_textBoxPrivateKey"
   Me._textBoxPrivateKey.Size = New System.Drawing.Size(470, 20)
   Me._textBoxPrivateKey.TabIndex = 12
   ' 
   ' _buttonPrivateKey
   ' 
   Me._buttonPrivateKey.Image = (CType(resources.GetObject("_buttonPrivateKey.Image"), System.Drawing.Image))
   Me._buttonPrivateKey.Location = New System.Drawing.Point(112, 61)
   Me._buttonPrivateKey.Name = "_buttonPrivateKey"
   Me._buttonPrivateKey.Size = New System.Drawing.Size(23, 19)
   Me._buttonPrivateKey.TabIndex = 11
   Me._buttonPrivateKey.UseVisualStyleBackColor = True
'		 Me._buttonPrivateKey.Click += New System.EventHandler(Me._buttonPrivateKey_Click);
   ' 
   ' _labelPrivateKey
   ' 
   Me._labelPrivateKey.AutoSize = True
   Me._labelPrivateKey.Location = New System.Drawing.Point(16, 61)
   Me._labelPrivateKey.Name = "_labelPrivateKey"
   Me._labelPrivateKey.Size = New System.Drawing.Size(64, 13)
   Me._labelPrivateKey.TabIndex = 10
   Me._labelPrivateKey.Text = "Private Key:"
   ' 
   ' _labelPrivateKeyPassword
   ' 
   Me._labelPrivateKeyPassword.AutoSize = True
   Me._labelPrivateKeyPassword.Location = New System.Drawing.Point(16, 93)
   Me._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword"
   Me._labelPrivateKeyPassword.Size = New System.Drawing.Size(77, 13)
   Me._labelPrivateKeyPassword.TabIndex = 13
   Me._labelPrivateKeyPassword.Text = "Key Password:"
   ' 
   ' _textBoxClientCertificate
   ' 
   Me._textBoxClientCertificate.Location = New System.Drawing.Point(141, 28)
   Me._textBoxClientCertificate.Name = "_textBoxClientCertificate"
   Me._textBoxClientCertificate.Size = New System.Drawing.Size(470, 20)
   Me._textBoxClientCertificate.TabIndex = 9
   ' 
   ' _buttonClientCertificate
   ' 
   Me._buttonClientCertificate.Image = (CType(resources.GetObject("_buttonClientCertificate.Image"), System.Drawing.Image))
   Me._buttonClientCertificate.Location = New System.Drawing.Point(112, 29)
   Me._buttonClientCertificate.Name = "_buttonClientCertificate"
   Me._buttonClientCertificate.Size = New System.Drawing.Size(23, 19)
   Me._buttonClientCertificate.TabIndex = 8
   Me._buttonClientCertificate.UseVisualStyleBackColor = True
'		 Me._buttonClientCertificate.Click += New System.EventHandler(Me._buttonClientCertificate_Click);
   ' 
   ' _labelCertificate
   ' 
   Me._labelCertificate.AutoSize = True
   Me._labelCertificate.Location = New System.Drawing.Point(16, 32)
   Me._labelCertificate.Name = "_labelCertificate"
   Me._labelCertificate.Size = New System.Drawing.Size(57, 13)
   Me._labelCertificate.TabIndex = 7
   Me._labelCertificate.Text = "Certificate:"
   ' 
   ' buttonOK
   ' 
   Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
   Me.buttonOK.Location = New System.Drawing.Point(268, 539)
   Me.buttonOK.Name = "buttonOK"
   Me.buttonOK.Size = New System.Drawing.Size(75, 23)
   Me.buttonOK.TabIndex = 2
   Me.buttonOK.Text = "&OK"
'		 Me.buttonOK.Click += New System.EventHandler(Me.buttonOK_Click);
   ' 
   ' buttonCancel
   ' 
   Me.buttonCancel.CausesValidation = False
   Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
   Me.buttonCancel.Location = New System.Drawing.Point(349, 539)
   Me.buttonCancel.Name = "buttonCancel"
   Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
   Me.buttonCancel.TabIndex = 3
   Me.buttonCancel.Text = "&Cancel"
   ' 
   ' dataGridViewServers
   ' 
   Me.dataGridViewServers.AllowUserToAddRows = False
   Me.dataGridViewServers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
   Me.dataGridViewServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
   Me.dataGridViewServers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnAE, Me.ColumnIP, Me.ColumnPort, Me.ColumnTimeout, Me.ColumnTls, Me.TestServer, Me.DefaultServer})
   Me.dataGridViewServers.Dock = System.Windows.Forms.DockStyle.Bottom
   Me.dataGridViewServers.Location = New System.Drawing.Point(3, 51)
   Me.dataGridViewServers.Name = "dataGridViewServers"
   Me.dataGridViewServers.Size = New System.Drawing.Size(619, 157)
   Me.dataGridViewServers.TabIndex = 5
'		 Me.dataGridViewServers.RowValidating += New System.Windows.Forms.DataGridViewCellCancelEventHandler(Me.dataGridViewServers_RowValidating);
'		 Me.dataGridViewServers.CellClick += New System.Windows.Forms.DataGridViewCellEventHandler(Me.dataGridViewServers_CellClick);
'		 Me.dataGridViewServers.CurrentCellDirtyStateChanged += New System.EventHandler(Me.dataGridViewServers_CurrentCellDirtyStateChanged);
   ' 
   ' ColumnAE
   ' 
   Me.ColumnAE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
   Me.ColumnAE.HeaderText = "Server AE Title"
   Me.ColumnAE.Name = "ColumnAE"
   ' 
   ' ColumnIP
   ' 
   Me.ColumnIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
   Me.ColumnIP.HeaderText = "Server IP Address"
   Me.ColumnIP.Name = "ColumnIP"
   ' 
   ' ColumnPort
   ' 
   Me.ColumnPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
   Me.ColumnPort.HeaderText = "Server Port"
   Me.ColumnPort.Name = "ColumnPort"
   ' 
   ' ColumnTimeout
   ' 
   Me.ColumnTimeout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
   Me.ColumnTimeout.HeaderText = "Timeout (sec)"
   Me.ColumnTimeout.Name = "ColumnTimeout"
   ' 
   ' ColumnTls
   ' 
   Me.ColumnTls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
   Me.ColumnTls.HeaderText = "Secure (TLS)"
   Me.ColumnTls.Name = "ColumnTls"
   Me.ColumnTls.Resizable = System.Windows.Forms.DataGridViewTriState.True
   Me.ColumnTls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
   ' 
   ' TestServer
   ' 
   Me.TestServer.HeaderText = "Test Connection"
   Me.TestServer.Name = "TestServer"
   Me.TestServer.Text = "Test"
   Me.TestServer.UseColumnTextForButtonValue = True
   ' 
   ' DefaultServer
   ' 
   Me.DefaultServer.HeaderText = "Default Server"
   Me.DefaultServer.Name = "DefaultServer"
   ' 
   ' buttonAddServer
   ' 
   Me.buttonAddServer.Image = (CType(resources.GetObject("buttonAddServer.Image"), System.Drawing.Image))
   Me.buttonAddServer.Location = New System.Drawing.Point(6, 6)
   Me.buttonAddServer.Name = "buttonAddServer"
   Me.buttonAddServer.Size = New System.Drawing.Size(40, 39)
   Me.buttonAddServer.TabIndex = 7
   Me.buttonAddServer.UseVisualStyleBackColor = True
'		 Me.buttonAddServer.Click += New System.EventHandler(Me.buttonAddServer_Click);
   ' 
   ' buttonDeleteServer
   ' 
   Me.buttonDeleteServer.CausesValidation = False
   Me.buttonDeleteServer.Image = (CType(resources.GetObject("buttonDeleteServer.Image"), System.Drawing.Image))
   Me.buttonDeleteServer.Location = New System.Drawing.Point(49, 6)
   Me.buttonDeleteServer.Name = "buttonDeleteServer"
   Me.buttonDeleteServer.Size = New System.Drawing.Size(40, 39)
   Me.buttonDeleteServer.TabIndex = 8
   Me.buttonDeleteServer.UseVisualStyleBackColor = True
'		 Me.buttonDeleteServer.Click += New System.EventHandler(Me.buttonDeleteServer_Click);
   ' 
   ' _groupBoxSecurity
   ' 
   Me._groupBoxSecurity.Controls.Add(Me._labelCertificate)
   Me._groupBoxSecurity.Controls.Add(Me._labelHint)
   Me._groupBoxSecurity.Controls.Add(Me._buttonClientCertificate)
   Me._groupBoxSecurity.Controls.Add(Me._textBoxClientCertificate)
   Me._groupBoxSecurity.Controls.Add(Me._textBoxKeyPassword)
   Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKeyPassword)
   Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKey)
   Me._groupBoxSecurity.Controls.Add(Me._textBoxPrivateKey)
   Me._groupBoxSecurity.Controls.Add(Me._buttonPrivateKey)
   Me._groupBoxSecurity.Location = New System.Drawing.Point(17, 93)
   Me._groupBoxSecurity.Name = "_groupBoxSecurity"
   Me._groupBoxSecurity.Size = New System.Drawing.Size(629, 136)
   Me._groupBoxSecurity.TabIndex = 16
   Me._groupBoxSecurity.TabStop = False
   Me._groupBoxSecurity.Text = "Security"
   ' 
   ' _tbServers
   ' 
   Me._tbServers.Controls.Add(Me._tbSCPQuerypage)
   Me._tbServers.Controls.Add(Me._tbMWLQueryPage)
   Me._tbServers.Controls.Add(Me._tbStorePage)
   Me._tbServers.Location = New System.Drawing.Point(17, 246)
   Me._tbServers.Name = "_tbServers"
   Me._tbServers.SelectedIndex = 0
   Me._tbServers.Size = New System.Drawing.Size(633, 237)
   Me._tbServers.TabIndex = 17
'		 Me._tbServers.Selecting += New System.Windows.Forms.TabControlCancelEventHandler(Me._tbServers_Selecting);
'		 Me._tbServers.SelectedIndexChanged += New System.EventHandler(Me._tbServers_SelectedIndexChanged);
   ' 
   ' _tbSCPQuerypage
   ' 
   Me._tbSCPQuerypage.Location = New System.Drawing.Point(4, 22)
   Me._tbSCPQuerypage.Name = "_tbSCPQuerypage"
   Me._tbSCPQuerypage.Padding = New System.Windows.Forms.Padding(3)
   Me._tbSCPQuerypage.Size = New System.Drawing.Size(625, 211)
   Me._tbSCPQuerypage.TabIndex = 0
   Me._tbSCPQuerypage.Text = "Query Servers"
   Me._tbSCPQuerypage.UseVisualStyleBackColor = True
   ' 
   ' _tbMWLQueryPage
   ' 
   Me._tbMWLQueryPage.Location = New System.Drawing.Point(4, 22)
   Me._tbMWLQueryPage.Name = "_tbMWLQueryPage"
   Me._tbMWLQueryPage.Padding = New System.Windows.Forms.Padding(3)
   Me._tbMWLQueryPage.Size = New System.Drawing.Size(625, 211)
   Me._tbMWLQueryPage.TabIndex = 1
   Me._tbMWLQueryPage.Text = "MWL Servers"
   Me._tbMWLQueryPage.UseVisualStyleBackColor = True
   ' 
   ' _tbStorePage
   ' 
   Me._tbStorePage.Location = New System.Drawing.Point(4, 22)
   Me._tbStorePage.Name = "_tbStorePage"
   Me._tbStorePage.Padding = New System.Windows.Forms.Padding(3)
   Me._tbStorePage.Size = New System.Drawing.Size(625, 211)
   Me._tbStorePage.TabIndex = 2
   Me._tbStorePage.Text = "PACS Storage Servers"
   Me._tbStorePage.UseVisualStyleBackColor = True
   ' 
   ' _tbOptions
   ' 
   Me._tbOptions.Controls.Add(Me._tpApplicationOptions)
   Me._tbOptions.Controls.Add(Me._tpDicomOptions)
   Me._tbOptions.Location = New System.Drawing.Point(12, 12)
   Me._tbOptions.Name = "_tbOptions"
   Me._tbOptions.SelectedIndex = 0
   Me._tbOptions.Size = New System.Drawing.Size(685, 521)
   Me._tbOptions.TabIndex = 18
   ' 
   ' _tpApplicationOptions
   ' 
   Me._tpApplicationOptions.Controls.Add(Me._btnBrowseTempDir)
   Me._tpApplicationOptions.Controls.Add(Me._ckAutoDelete)
   Me._tpApplicationOptions.Controls.Add(Me.label3)
   Me._tpApplicationOptions.Controls.Add(Me._btnRename)
   Me._tpApplicationOptions.Controls.Add(Me._gpDicomType)
   Me._tpApplicationOptions.Controls.Add(Me._txtTempDir)
   Me._tpApplicationOptions.Controls.Add(Me._txtPrinterName)
   Me._tpApplicationOptions.Controls.Add(Me._lblPrinterName)
   Me._tpApplicationOptions.Location = New System.Drawing.Point(4, 22)
   Me._tpApplicationOptions.Name = "_tpApplicationOptions"
   Me._tpApplicationOptions.Padding = New System.Windows.Forms.Padding(3)
   Me._tpApplicationOptions.Size = New System.Drawing.Size(677, 495)
   Me._tpApplicationOptions.TabIndex = 0
   Me._tpApplicationOptions.Text = "Application Options"
   Me._tpApplicationOptions.UseVisualStyleBackColor = True
   ' 
   ' _btnBrowseTempDir
   ' 
   Me._btnBrowseTempDir.Image = (CType(resources.GetObject("_btnBrowseTempDir.Image"), System.Drawing.Image))
   Me._btnBrowseTempDir.Location = New System.Drawing.Point(276, 310)
   Me._btnBrowseTempDir.Name = "_btnBrowseTempDir"
   Me._btnBrowseTempDir.Size = New System.Drawing.Size(23, 19)
   Me._btnBrowseTempDir.TabIndex = 31
   Me._btnBrowseTempDir.UseVisualStyleBackColor = True
   ' 
   ' _ckAutoDelete
   ' 
   Me._ckAutoDelete.AutoSize = True
   Me._ckAutoDelete.Location = New System.Drawing.Point(21, 449)
   Me._ckAutoDelete.Name = "_ckAutoDelete"
   Me._ckAutoDelete.Size = New System.Drawing.Size(232, 17)
   Me._ckAutoDelete.TabIndex = 26
   Me._ckAutoDelete.Text = "Auto delete Images after successful transfer"
   Me._ckAutoDelete.UseVisualStyleBackColor = True
   ' 
   ' label3
   ' 
   Me.label3.AutoSize = True
   Me.label3.Location = New System.Drawing.Point(96, 310)
   Me.label3.Name = "label3"
   Me.label3.Size = New System.Drawing.Size(140, 13)
   Me.label3.TabIndex = 23
   Me.label3.Text = "DICOM Temporary Directory"
   ' 
   ' _btnRename
   ' 
   Me._btnRename.Location = New System.Drawing.Point(454, 19)
   Me._btnRename.Name = "_btnRename"
   Me._btnRename.Size = New System.Drawing.Size(70, 23)
   Me._btnRename.TabIndex = 22
   Me._btnRename.Text = "Rename"
   ' 
   ' _gpDicomType
   ' 
   Me._gpDicomType.Controls.Add(Me._btnBrowseSCPDF)
   Me._gpDicomType.Controls.Add(Me._btnBrowseSCGray)
   Me._gpDicomType.Controls.Add(Me._btnBrowseSCColor)
   Me._gpDicomType.Controls.Add(Me._btnBrowseSC)
   Me._gpDicomType.Controls.Add(Me.label2)
   Me._gpDicomType.Controls.Add(Me._cmbSCColor)
   Me._gpDicomType.Controls.Add(Me._cmbSCGray)
   Me._gpDicomType.Controls.Add(Me._cmbSC)
   Me._gpDicomType.Controls.Add(Me.label1)
   Me._gpDicomType.Controls.Add(Me._rdPDF)
   Me._gpDicomType.Controls.Add(Me._rdGrayScale)
   Me._gpDicomType.Controls.Add(Me._rdColored)
   Me._gpDicomType.Controls.Add(Me._rdSecondaryCapture)
   Me._gpDicomType.Controls.Add(Me._txtSCPDF)
   Me._gpDicomType.Controls.Add(Me._txtSCGray)
   Me._gpDicomType.Controls.Add(Me._txtSCColor)
   Me._gpDicomType.Controls.Add(Me._txtSC)
   Me._gpDicomType.Location = New System.Drawing.Point(21, 95)
   Me._gpDicomType.Name = "_gpDicomType"
   Me._gpDicomType.Size = New System.Drawing.Size(636, 155)
   Me._gpDicomType.TabIndex = 7
   Me._gpDicomType.TabStop = False
   Me._gpDicomType.Text = "DICOM type"
   ' 
   ' _btnBrowseSCPDF
   ' 
   Me._btnBrowseSCPDF.Image = (CType(resources.GetObject("_btnBrowseSCPDF.Image"), System.Drawing.Image))
   Me._btnBrowseSCPDF.Location = New System.Drawing.Point(255, 118)
   Me._btnBrowseSCPDF.Name = "_btnBrowseSCPDF"
   Me._btnBrowseSCPDF.Size = New System.Drawing.Size(23, 19)
   Me._btnBrowseSCPDF.TabIndex = 30
   Me._btnBrowseSCPDF.UseVisualStyleBackColor = True
   ' 
   ' _btnBrowseSCGray
   ' 
   Me._btnBrowseSCGray.Image = (CType(resources.GetObject("_btnBrowseSCGray.Image"), System.Drawing.Image))
   Me._btnBrowseSCGray.Location = New System.Drawing.Point(255, 89)
   Me._btnBrowseSCGray.Name = "_btnBrowseSCGray"
   Me._btnBrowseSCGray.Size = New System.Drawing.Size(23, 19)
   Me._btnBrowseSCGray.TabIndex = 29
   Me._btnBrowseSCGray.UseVisualStyleBackColor = True
   ' 
   ' _btnBrowseSCColor
   ' 
   Me._btnBrowseSCColor.Image = (CType(resources.GetObject("_btnBrowseSCColor.Image"), System.Drawing.Image))
   Me._btnBrowseSCColor.Location = New System.Drawing.Point(255, 63)
   Me._btnBrowseSCColor.Name = "_btnBrowseSCColor"
   Me._btnBrowseSCColor.Size = New System.Drawing.Size(23, 19)
   Me._btnBrowseSCColor.TabIndex = 28
   Me._btnBrowseSCColor.UseVisualStyleBackColor = True
   ' 
   ' _btnBrowseSC
   ' 
   Me._btnBrowseSC.Image = (CType(resources.GetObject("_btnBrowseSC.Image"), System.Drawing.Image))
   Me._btnBrowseSC.Location = New System.Drawing.Point(255, 36)
   Me._btnBrowseSC.Name = "_btnBrowseSC"
   Me._btnBrowseSC.Size = New System.Drawing.Size(23, 19)
   Me._btnBrowseSC.TabIndex = 27
   Me._btnBrowseSC.UseVisualStyleBackColor = True
   ' 
   ' label2
   ' 
   Me.label2.AutoSize = True
   Me.label2.Location = New System.Drawing.Point(519, 16)
   Me.label2.Name = "label2"
   Me.label2.Size = New System.Drawing.Size(67, 13)
   Me.label2.TabIndex = 20
   Me.label2.Text = "Compression"
   ' 
   ' _cmbSCColor
   ' 
   Me._cmbSCColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
   Me._cmbSCColor.FormattingEnabled = True
   Me._cmbSCColor.Location = New System.Drawing.Point(522, 62)
   Me._cmbSCColor.Name = "_cmbSCColor"
   Me._cmbSCColor.Size = New System.Drawing.Size(100, 21)
   Me._cmbSCColor.TabIndex = 19
   ' 
   ' _cmbSCGray
   ' 
   Me._cmbSCGray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
   Me._cmbSCGray.FormattingEnabled = True
   Me._cmbSCGray.Location = New System.Drawing.Point(522, 89)
   Me._cmbSCGray.Name = "_cmbSCGray"
   Me._cmbSCGray.Size = New System.Drawing.Size(100, 21)
   Me._cmbSCGray.TabIndex = 18
   ' 
   ' _cmbSC
   ' 
   Me._cmbSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
   Me._cmbSC.FormattingEnabled = True
   Me._cmbSC.Location = New System.Drawing.Point(522, 35)
   Me._cmbSC.Name = "_cmbSC"
   Me._cmbSC.Size = New System.Drawing.Size(100, 21)
   Me._cmbSC.TabIndex = 16
   ' 
   ' label1
   ' 
   Me.label1.AutoSize = True
   Me.label1.Location = New System.Drawing.Point(246, 16)
   Me.label1.Name = "label1"
   Me.label1.Size = New System.Drawing.Size(51, 13)
   Me.label1.TabIndex = 15
   Me.label1.Text = "Template"
   ' 
   ' _rdPDF
   ' 
   Me._rdPDF.AutoSize = True
   Me._rdPDF.Location = New System.Drawing.Point(15, 117)
   Me._rdPDF.Name = "_rdPDF"
   Me._rdPDF.Size = New System.Drawing.Size(84, 17)
   Me._rdPDF.TabIndex = 14
   Me._rdPDF.Text = "DICOM PDF"
   Me._rdPDF.UseVisualStyleBackColor = True
   ' 
   ' _rdGrayScale
   ' 
   Me._rdGrayScale.AutoSize = True
   Me._rdGrayScale.Location = New System.Drawing.Point(15, 90)
   Me._rdGrayScale.Name = "_rdGrayScale"
   Me._rdGrayScale.Size = New System.Drawing.Size(223, 17)
   Me._rdGrayScale.TabIndex = 13
   Me._rdGrayScale.Text = "Secondary Capture Multi-Frame Grayscale"
   Me._rdGrayScale.UseVisualStyleBackColor = True
   ' 
   ' _rdColored
   ' 
   Me._rdColored.AutoSize = True
   Me._rdColored.Location = New System.Drawing.Point(15, 63)
   Me._rdColored.Name = "_rdColored"
   Me._rdColored.Size = New System.Drawing.Size(200, 17)
   Me._rdColored.TabIndex = 12
   Me._rdColored.Text = "Secondary Capture Multi-Frame Color"
   Me._rdColored.UseVisualStyleBackColor = True
   ' 
   ' _rdSecondaryCapture
   ' 
   Me._rdSecondaryCapture.AutoSize = True
   Me._rdSecondaryCapture.Checked = True
   Me._rdSecondaryCapture.Location = New System.Drawing.Point(15, 36)
   Me._rdSecondaryCapture.Name = "_rdSecondaryCapture"
   Me._rdSecondaryCapture.Size = New System.Drawing.Size(116, 17)
   Me._rdSecondaryCapture.TabIndex = 11
   Me._rdSecondaryCapture.TabStop = True
   Me._rdSecondaryCapture.Text = "Secondary Capture"
   Me._rdSecondaryCapture.UseVisualStyleBackColor = True
   ' 
   ' _txtSCPDF
   ' 
   Me._txtSCPDF.Location = New System.Drawing.Point(284, 116)
   Me._txtSCPDF.Name = "_txtSCPDF"
   Me._txtSCPDF.Size = New System.Drawing.Size(219, 20)
   Me._txtSCPDF.TabIndex = 10
   Me._txtSCPDF.Tag = "3"
   ' 
   ' _txtSCGray
   ' 
   Me._txtSCGray.Location = New System.Drawing.Point(284, 89)
   Me._txtSCGray.Name = "_txtSCGray"
   Me._txtSCGray.Size = New System.Drawing.Size(219, 20)
   Me._txtSCGray.TabIndex = 9
   Me._txtSCGray.Tag = "2"
   ' 
   ' _txtSCColor
   ' 
   Me._txtSCColor.Location = New System.Drawing.Point(284, 62)
   Me._txtSCColor.Name = "_txtSCColor"
   Me._txtSCColor.Size = New System.Drawing.Size(219, 20)
   Me._txtSCColor.TabIndex = 8
   Me._txtSCColor.Tag = "1"
'		 Me._txtSCColor.TextChanged += New System.EventHandler(Me.textBox4_TextChanged);
   ' 
   ' _txtSC
   ' 
   Me._txtSC.Location = New System.Drawing.Point(284, 35)
   Me._txtSC.Name = "_txtSC"
   Me._txtSC.Size = New System.Drawing.Size(219, 20)
   Me._txtSC.TabIndex = 7
   Me._txtSC.Tag = "0"
   ' 
   ' _txtTempDir
   ' 
   Me._txtTempDir.Location = New System.Drawing.Point(305, 310)
   Me._txtTempDir.Name = "_txtTempDir"
   Me._txtTempDir.Size = New System.Drawing.Size(338, 20)
   Me._txtTempDir.TabIndex = 2
'		 Me._txtTempDir.TextChanged += New System.EventHandler(Me.textBox2_TextChanged);
   ' 
   ' _txtPrinterName
   ' 
   Me._txtPrinterName.BackColor = System.Drawing.Color.Gainsboro
   Me._txtPrinterName.Location = New System.Drawing.Point(179, 21)
   Me._txtPrinterName.Name = "_txtPrinterName"
   Me._txtPrinterName.ReadOnly = True
   Me._txtPrinterName.Size = New System.Drawing.Size(269, 20)
   Me._txtPrinterName.TabIndex = 1
   ' 
   ' _lblPrinterName
   ' 
   Me._lblPrinterName.AutoSize = True
   Me._lblPrinterName.Location = New System.Drawing.Point(18, 24)
   Me._lblPrinterName.Name = "_lblPrinterName"
   Me._lblPrinterName.Size = New System.Drawing.Size(137, 13)
   Me._lblPrinterName.TabIndex = 0
   Me._lblPrinterName.Text = "DICOM Printer Driver Name"
   ' 
   ' _tpDicomOptions
   ' 
   Me._tpDicomOptions.Controls.Add(Me._groupBoxSecurity)
   Me._tpDicomOptions.Controls.Add(Me._groupBoxClient)
   Me._tpDicomOptions.Controls.Add(Me._tbServers)
   Me._tpDicomOptions.Location = New System.Drawing.Point(4, 22)
   Me._tpDicomOptions.Name = "_tpDicomOptions"
   Me._tpDicomOptions.Padding = New System.Windows.Forms.Padding(3)
   Me._tpDicomOptions.Size = New System.Drawing.Size(677, 495)
   Me._tpDicomOptions.TabIndex = 1
   Me._tpDicomOptions.Text = "PACS Settings"
   Me._tpDicomOptions.UseVisualStyleBackColor = True
   ' 
   ' OptionsDialog
   ' 
   Me.AcceptButton = Me.buttonOK
   Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
   Me.CancelButton = Me.buttonCancel
   Me.ClientSize = New System.Drawing.Size(709, 572)
   Me.Controls.Add(Me._tbOptions)
   Me.Controls.Add(Me.buttonOK)
   Me.Controls.Add(Me.buttonCancel)
   Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
   Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
   Me.Name = "OptionsDialog"
   Me.ShowInTaskbar = False
   Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
   Me.Text = "Options"
'		 Me.Load += New System.EventHandler(Me.OptionsDialog_Load);
   Me._groupBoxClient.ResumeLayout(False)
   Me._groupBoxClient.PerformLayout()
   CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).EndInit()
   Me._groupBoxSecurity.ResumeLayout(False)
   Me._groupBoxSecurity.PerformLayout()
   Me._tbServers.ResumeLayout(False)
   Me._tbOptions.ResumeLayout(False)
   Me._tpApplicationOptions.ResumeLayout(False)
   Me._tpApplicationOptions.PerformLayout()
   Me._gpDicomType.ResumeLayout(False)
   Me._gpDicomType.PerformLayout()
   Me._tpDicomOptions.ResumeLayout(False)
   Me.ResumeLayout(False)

   End Sub
#End Region

#Region "Properties"

   Public Property ServerList() As MyServerList
   Get
         Dim serverlistParam As MyServerList = New MyServerList()
   Dim items As MyServer() = New MyServer(dataGridViewServers.Rows.Count - 1) {}
   Dim i As Integer = 0
   Do While i < dataGridViewServers.Rows.Count
      items(i) = New MyServer()
      items(i)._sAE = dataGridViewServers.Rows(i).Cells("ColumnAE").Value.ToString()
      items(i)._sIP = dataGridViewServers.Rows(i).Cells("ColumnIP").Value.ToString()
      items(i)._timeout = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnTimeout").Value)
      items(i)._port = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnPort").Value)
      items(i)._useTls = Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value)
    i += 1
   Loop
   serverlistParam.serverList = items
   Return serverlistParam
   End Get

   Set(ByVal value As MyServerList)
   dataGridViewServers.Rows.Clear()
   For Each s As MyServer In value.serverList
      Dim n As Integer = dataGridViewServers.Rows.Add()
      dataGridViewServers.Rows(n).Cells("ColumnAE").Value = s._sAE
      dataGridViewServers.Rows(n).Cells("ColumnIP").Value = s._sIP
      dataGridViewServers.Rows(n).Cells("ColumnTimeout").Value = s._timeout.ToString()
      dataGridViewServers.Rows(n).Cells("ColumnPort").Value = s._port.ToString()
      dataGridViewServers.Rows(n).Cells("ColumnTls").Value = s._useTls.ToString()
   Next s
   End Set
   End Property

   Public Property Selectedtype() As DicomClassType
   Get
    Return _selectedtype
   End Get
   Set(ByVal value As DicomClassType)
    _selectedtype = value
   End Set
   End Property

   Public Property LogLowLevel() As Boolean
   Get
    Return _logLowLevel
   End Get
   Set(ByVal value As Boolean)
    _logLowLevel = value
   End Set
   End Property

   Public Property PrivateKeyPassword() As String
   Get
    Return _privateKeyPassword
   End Get
   Set(ByVal value As String)
    _privateKeyPassword = value
   End Set
   End Property

   Public Property SCCompression() As DicomImageCompressionType
   Get
    Return _SCCompression
   End Get
   Set(ByVal value As DicomImageCompressionType)
    _SCCompression = value
   End Set
   End Property

   Public Property SCColorCompression() As DicomImageCompressionType
   Get
    Return _SCColorCompression
   End Get
   Set(ByVal value As DicomImageCompressionType)
    _SCColorCompression = value
   End Set
   End Property

   Public Property SCGrayCompression() As DicomImageCompressionType
   Get
    Return _SCGrayCompression
   End Get
   Set(ByVal value As DicomImageCompressionType)
    _SCGrayCompression = value
   End Set
   End Property

   Public Property SCPath() As String
   Get
    Return _SCPath
   End Get
   Set(ByVal value As String)
    _SCPath = value
   End Set
   End Property

   Public Property SCColorPath() As String
   Get
    Return _SCColorPath
   End Get
   Set(ByVal value As String)
    _SCColorPath = value
   End Set
   End Property

   Public Property SCGrayPath() As String
   Get
    Return _SCGrayPath
   End Get
   Set(ByVal value As String)
    _SCGrayPath = value
   End Set
   End Property

   Public Property PdfPath() As String
   Get
    Return _PdfPath
   End Get
   Set(ByVal value As String)
    _PdfPath = value
   End Set
   End Property

   Public Property PrinterName() As String
   Get
    Return _PrinterName
   End Get
   Set(ByVal value As String)
    _PrinterName = value
   End Set
   End Property

   Public Property TempDirectory() As String
   Get
    Return _TempDirectory
   End Get
   Set(ByVal value As String)
    _TempDirectory = value
   End Set
   End Property

   Public Property AutoDelete() As Boolean
   Get
    Return _AutoDelete
   End Get
   Set(ByVal value As Boolean)
    _AutoDelete = value
   End Set
   End Property

   Public Property SelectedTab() As Integer
   Get
    Return _iSelectedTab
   End Get
   Set(ByVal value As Integer)
    _iSelectedTab = value
   End Set
   End Property

   Public Property DefaultSCPServer() As Integer
   Get
    Return _defaultSCPServer
   End Get
   Set(ByVal value As Integer)
    _defaultSCPServer = value
   End Set
   End Property

   Public Property DefaultMWLServer() As Integer
   Get
    Return _defaultMWLServer
   End Get
   Set(ByVal value As Integer)
    _defaultMWLServer = value
   End Set
   End Property

   Public Property DefaultStoreServer() As Integer
   Get
    Return _defaultStoreServer
   End Get
   Set(ByVal value As Integer)
    _defaultStoreServer = value
   End Set
   End Property

   Public Property PrivateKey() As String
   Get
    Return _privateKey
   End Get
   Set(ByVal value As String)
    _privateKey = value
   End Set
   End Property

   Public Property ClientCertificate() As String
   Get
    Return _clientCertificate
   End Get
   Set(ByVal value As String)
    _clientCertificate = value
   End Set
   End Property

   Public Property ClientAE() As String
   Get
    Return _clientAE
   End Get
   Set(ByVal value As String)
    _clientAE = value
   End Set
   End Property

#End Region

#Region "Form Events"

   Private Sub ServerIp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
   Dim bValid As Boolean = Char.IsNumber(e.KeyChar) OrElse (e.KeyChar = "."c) OrElse Char.IsControl(e.KeyChar)
   e.Handled = Not bValid
   End Sub


   Private Sub Port_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
   If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
   e.Handled = True
   End If
   End Sub

   Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOK.Click
   _tbServers_Selecting(Nothing, Nothing)
   If IsAnyServerUseTls() Then
   If (Not CheckFileExists("Certificate", _textBoxClientCertificate, True)) Then
      Return
   End If
   If (Not CheckFileExists("Private Key", _textBoxPrivateKey, True)) Then
      Return
   End If
   End If


   ClientAE = _textBoxClientAE.Text
   ClientCertificate = _textBoxClientCertificate.Text
   PrivateKey = _textBoxPrivateKey.Text
   PrivateKeyPassword = _textBoxKeyPassword.Text

   SCPath = _txtSC.Text
   SCColorPath = _txtSCColor.Text
   SCGrayPath = _txtSCGray.Text
   PdfPath = _txtSCPDF.Text

   If _rdGrayScale.Checked Then
   Selectedtype = DicomClassType.SCMultiFrameGrayscaleByteImageStorage
   End If
   If _rdSecondaryCapture.Checked Then
   Selectedtype = DicomClassType.SCImageStorage
   End If
   If _rdColored.Checked Then
   Selectedtype = DicomClassType.SCMultiFrameTrueColorImageStorage
   End If
   If _rdPDF.Checked Then
   Selectedtype = DicomClassType.EncapsulatedPdfStorage
   End If

   SCCompression = ImgCompression(_cmbSC.SelectedIndex)
   SCColorCompression = ImgCompression(_cmbSCColor.SelectedIndex)
   SCGrayCompression = ImgCompression(_cmbSCGray.SelectedIndex)

   PrinterName = _txtPrinterName.Text
   TempDirectory = _txtTempDir.Text
   AutoDelete = _ckAutoDelete.Checked

   DefaultSCPServer = _defaultSCPServer
   DefaultMWLServer = _defaultMWLServer
   DefaultStoreServer = _defaultStoreServer

   End Sub

   Private Sub OptionsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

ClassTypes = New List(Of DicomClassType)
Compressions = New List(Of String)
ImgCompression = New List(Of DicomImageCompressionType)

ClassTypes.Add(DicomClassType.SCImageStorage)
ClassTypes.Add(DicomClassType.SCMultiFrameTrueColorImageStorage)
ClassTypes.Add(DicomClassType.SCMultiFrameGrayscaleByteImageStorage)
ClassTypes.Add(DicomClassType.EncapsulatedPdfStorage)

 Compressions.Add("Uncompressed")
Compressions.Add("Lossless JPEG")
Compressions.Add("Lossy JPEG")
Compressions.Add("Lossless J2k")
Compressions.Add("Lossy J2K")


ImgCompression.Add(DicomImageCompressionType.None)
ImgCompression.Add(DicomImageCompressionType.JpegLossless)
ImgCompression.Add(DicomImageCompressionType.JpegLossy)
ImgCompression.Add(DicomImageCompressionType.J2kLossless)
ImgCompression.Add(DicomImageCompressionType.J2kLossy)


   _textBoxClientAE.Text = ClientAE
   _textBoxClientCertificate.Text = ClientCertificate
   _textBoxPrivateKey.Text = PrivateKey
   _textBoxKeyPassword.Text = PrivateKeyPassword
   EnableDialogItems()
   _tbSCPQuerypage.Tag = serverlistSCP
   _tbMWLQueryPage.Tag = serverlistMWL
   _tbStorePage.Tag = serverlistStore
   _tbServers_Selecting(Nothing, Nothing)
   _btnBrowseSC.Tag = _txtSC
   _btnBrowseSCColor.Tag = _txtSCColor
   _btnBrowseSCGray.Tag = _txtSCGray
   _btnBrowseSCPDF.Tag = _txtSCPDF

   AddHandler _btnRename.Click, AddressOf _btnRename_Click
   AddHandler _btnBrowseTempDir.Click, AddressOf _btnBrowseTempDir_Click

   AddHandler _btnBrowseSC.Click, AddressOf _btnBrowseSC_Click
   AddHandler _btnBrowseSCColor.Click, AddressOf _btnBrowseSC_Click
   AddHandler _btnBrowseSCGray.Click, AddressOf _btnBrowseSC_Click
   AddHandler _btnBrowseSCPDF.Click, AddressOf _btnBrowseSC_Click

   AddHandler _txtSC.Leave, AddressOf _txt_Leave
   AddHandler _txtSCColor.Leave, AddressOf _txt_Leave
   AddHandler _txtSCGray.Leave, AddressOf _txt_Leave
   AddHandler _txtSCPDF.Leave, AddressOf _txt_Leave

   AddHandler _txtTempDir.Leave, AddressOf _txtTempDir_Leave

   _cmbSC.Items.AddRange(Compressions.ToArray())
   _cmbSCColor.Items.AddRange(Compressions.ToArray())
   _cmbSCGray.Items.AddRange(Compressions.ToArray())

   _txtSC.Text = SCPath
   _txtSCGray.Text = SCGrayPath
   _txtSCColor.Text = SCColorPath
   _txtSCPDF.Text = PdfPath

   _txtSC.Text = SCPath
   _txtSCGray.Text = SCGrayPath
   _txtSCColor.Text = SCColorPath
   _txtSCPDF.Text = PdfPath

   _txtTempDir.Text = TempDirectory
   _txtPrinterName.Text = PrinterName

   _cmbSC.SelectedIndex = ImgCompression.IndexOf(SCCompression)
   _cmbSCColor.SelectedIndex = ImgCompression.IndexOf(SCColorCompression)
   _cmbSCGray.SelectedIndex = ImgCompression.IndexOf(SCGrayCompression)

   If Selectedtype = DicomClassType.SCMultiFrameGrayscaleByteImageStorage Then
   _rdGrayScale.Checked = True
   End If
   If Selectedtype = DicomClassType.SCImageStorage Then
   _rdSecondaryCapture.Checked = True
   End If
   If Selectedtype = DicomClassType.SCMultiFrameTrueColorImageStorage Then
   _rdColored.Checked = True
   End If
   If Selectedtype = DicomClassType.EncapsulatedPdfStorage Then
   _rdPDF.Checked = True
   End If

   _ckAutoDelete.Checked = _AutoDelete

   If _tbOptions.TabCount > SelectedTab Then
   _tbOptions.SelectedIndex = SelectedTab
   End If
   End Sub

   Private Sub _txtTempDir_Leave(ByVal sender As Object, ByVal e As EventArgs)
   If (Not Directory.Exists(_txtTempDir.Text)) Then
   MessageBox.Show("The selected directory does not exist")
   _txtTempDir.Text = ""
   End If
   End Sub

   Private Sub _btnRename_Click(ByVal sender As Object, ByVal e As EventArgs)
   Dim input As InputDialog = New InputDialog("Change Printer Driver Name", "New Printer Driver Name", _txtPrinterName.Text)
   If input.ShowDialog() <> DialogResult.Cancel Then
   _txtPrinterName.Text = input.Value
   End If
   End Sub

   Private Sub _btnBrowseTempDir_Click(ByVal sender As Object, ByVal e As EventArgs)
   Dim dlgFolder As FolderBrowserDialog = New FolderBrowserDialog()
   dlgFolder.ShowNewFolderButton = True
   Dim dlgRes As DialogResult = dlgFolder.ShowDialog()

   If dlgRes <> DialogResult.OK Then
   Return
   End If

   _txtTempDir.Text = dlgFolder.SelectedPath
   End Sub

   Private Sub _btnBrowseSC_Click(ByVal sender As Object, ByVal e As EventArgs)
   Dim dlgOpen As OpenFileDialog = New OpenFileDialog()
   dlgOpen.Filter = "DICOM Xml files|*.xml"
   Dim dlgRes As DialogResult = dlgOpen.ShowDialog()
   If dlgRes = DialogResult.Cancel Then
   Return
   End If

   Dim textBox As TextBox = (TryCast((TryCast(sender, Button)).Tag, TextBox))
   textBox.Text = dlgOpen.FileName
   _txt_Leave(textBox, e)

   End Sub

   Private Sub _buttonClientCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonClientCertificate.Click
   Dim openDialog As OpenFileDialog = New OpenFileDialog()
   openDialog.Title = "Select Client Certificate"
   openDialog.FileName = _textBoxClientCertificate.Text
   openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
   Dim result As DialogResult = openDialog.ShowDialog(Me)
   If result = DialogResult.OK Then
   _textBoxClientCertificate.Text = openDialog.FileName
   End If
   End Sub

   Private Sub _buttonPrivateKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonPrivateKey.Click
   Dim openDialog As OpenFileDialog = New OpenFileDialog()
   openDialog.Title = "Select Private Key File"
   openDialog.FileName = _textBoxClientCertificate.Text
   openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
   Dim result As DialogResult = openDialog.ShowDialog(Me)
   If result = DialogResult.OK Then
   _textBoxPrivateKey.Text = openDialog.FileName
   End If
   End Sub

   Private Sub _checkBoxLoggingLowLevel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
   EnableDialogItems()
   End Sub

   Private Sub buttonAddServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddServer.Click
   Try
   Dim rowIndex As Integer = dataGridViewServers.Rows.Add()
   Dim row As DataGridViewRow = dataGridViewServers.Rows(rowIndex)
   row.ReadOnly = False
   row.Selected = True
   dataGridViewServers.CurrentCell = row.Cells(0)
   dataGridViewServers.ShowEditingIcon = True
   dataGridViewServers.BeginEdit(False)
   Catch ex As Exception
   System.Diagnostics.Debug.Assert(False, ex.Message)
   End Try
   End Sub

   Private Sub buttonDeleteServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteServer.Click
   Try
   Dim iDefaultRowNumber As Integer = -1
   If _tbServers.SelectedIndex = 0 Then
      iDefaultRowNumber = DefaultSCPServer
   End If
   If _tbServers.SelectedIndex = 1 Then
      iDefaultRowNumber = DefaultMWLServer
   End If
   If _tbServers.SelectedIndex = 2 Then
      iDefaultRowNumber = DefaultStoreServer
   End If

   Dim bDefaultChanged As Boolean = False
   For Each row As DataGridViewRow In dataGridViewServers.SelectedRows
      If Not row.Cells(6).Value Is Nothing AndAlso CBool(row.Cells(6).Value) = True Then
      bDefaultChanged = True
      End If
      dataGridViewServers.Rows.Remove(row)
   Next row

   If bDefaultChanged Then
      If dataGridViewServers.Rows.Count > 0 Then
      dataGridViewServers.Rows(0).Cells(6).Value = True
      End If
   End If

   If _tbServers.SelectedIndex = 0 Then
      DefaultSCPServer = iDefaultRowNumber
   End If
   If _tbServers.SelectedIndex = 1 Then
      DefaultMWLServer = iDefaultRowNumber
   End If
   If _tbServers.SelectedIndex = 2 Then
      DefaultStoreServer = iDefaultRowNumber
   End If
   Catch ex As Exception
   System.Diagnostics.Debug.Assert(False, ex.Message)
   End Try

   End Sub

   Private Sub dataGridViewServers_RowValidating(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles dataGridViewServers.RowValidating
   Try
   Dim validatingRow As DataGridViewRow = dataGridViewServers.Rows(e.RowIndex)
   If (Nothing Is validatingRow.Cells(ColumnAE.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnAE.Name).EditedFormattedValue.ToString())) Then
      validatingRow.ErrorText = ColumnAE.HeaderText & " cannot be empty"
      e.Cancel = True
      Return
   End If

   If (Not Nothing Is validatingRow.Cells(ColumnAE.Name).EditedFormattedValue AndAlso validatingRow.Cells(ColumnAE.Name).EditedFormattedValue.ToString().Length > 16) Then
      validatingRow.ErrorText = ColumnAE.HeaderText & " must be less than 16 characters"
      e.Cancel = True
      Return
   End If
   If (Nothing Is validatingRow.Cells(ColumnIP.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnIP.Name).EditedFormattedValue.ToString())) Then
      validatingRow.ErrorText = ColumnIP.HeaderText & " cannot be empty."
      e.Cancel = True
      Return
   End If

   Try
      Dim ip As String = validatingRow.Cells(ColumnIP.Name).EditedFormattedValue.ToString()
      'Utils.ResolveIPAddress(ip);
   Catch exception As Exception
      validatingRow.ErrorText = exception.Message
      e.Cancel = True
      Return
   End Try

   Dim number As Integer
   If (Nothing Is validatingRow.Cells(ColumnPort.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnPort.Name).EditedFormattedValue.ToString())) OrElse ((Not Integer.TryParse(validatingRow.Cells(ColumnPort.Name).EditedFormattedValue.ToString(), number))) Then
      validatingRow.ErrorText = String.Format("Invalid {0}.", ColumnPort.HeaderText)
      e.Cancel = True
      Return
   End If

   If (Nothing Is validatingRow.Cells(ColumnTimeout.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnTimeout.Name).EditedFormattedValue.ToString())) OrElse ((Not Integer.TryParse(validatingRow.Cells(ColumnTimeout.Name).EditedFormattedValue.ToString(), number))) Then
      validatingRow.Cells(ColumnTimeout.Name).Value = 15
      e.Cancel = False
      Return
   End If

   validatingRow.ErrorText = ""

   Dim iDefault As Integer = -1
   Dim tbPage As TabPage = _tbServers.SelectedTab
   If _tbMWLQueryPage Is tbPage Then
      iDefault = _defaultMWLServer
   End If

   If _tbSCPQuerypage Is tbPage Then
      iDefault = _defaultSCPServer
   End If

   If _tbStorePage Is tbPage Then
      iDefault = _defaultStoreServer
   End If

   If dataGridViewServers.Rows.Count > 0 Then
      If e.RowIndex = iDefault AndAlso e.ColumnIndex = 6 Then
      dataGridViewServers.Rows(e.RowIndex).Cells(6).Value = True
      End If
   End If

   Catch ex As Exception
   System.Diagnostics.Debug.Assert(False, ex.Message)
   Throw
   End Try
   End Sub

   Private Sub dataGridViewServers_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dataGridViewServers.CurrentCellDirtyStateChanged
   Dim d As DataGridView = TryCast(sender, DataGridView)
   If Not d Is Nothing Then
   Dim cb As DataGridViewCheckBoxCell = TryCast(d.CurrentCell, DataGridViewCheckBoxCell)
   If Not cb Is Nothing AndAlso cb.ColumnIndex <> 6 Then
      d.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
      Dim page As TabPage = _tbServers.SelectedTab
      Dim servers As MyServerList = CType(page.Tag, MyServerList)

      Try
      ServerList.serverList(d.CurrentCell.RowIndex)._useTls = Convert.ToBoolean(dataGridViewServers.Rows(d.CurrentCell.RowIndex).Cells("ColumnTls").Value)
      EnableDialogItems()
      Catch
      End Try

   End If
   End If
   End Sub

   Private Sub _tbServers_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbServers.SelectedIndexChanged

   End Sub

   Private Sub _tbServers_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles _tbServers.Selecting
   For Each page As TabPage In _tbServers.TabPages
   If page.Controls.Count <> 0 Then
      page.Controls.Clear()
      Dim servers As MyServerList = CType(page.Tag, MyServerList)

      If _tbMWLQueryPage Is page Then
      serverlistMWL = ServerList
      End If
      If _tbSCPQuerypage Is page Then
      serverlistSCP = ServerList
      End If
      If _tbStorePage Is page Then
      serverlistStore = ServerList
      End If

   End If
   Next page

   Dim tbPage As TabPage = _tbServers.SelectedTab
   tbPage.Controls.Add(buttonDeleteServer)
   tbPage.Controls.Add(buttonAddServer)
   tbPage.Controls.Add(dataGridViewServers)
   Dim iDefault As Integer = -1
   If _tbMWLQueryPage Is tbPage Then
   ServerList = serverlistMWL
   iDefault = _defaultMWLServer
   End If
   If _tbSCPQuerypage Is tbPage Then
   ServerList = serverlistSCP
   iDefault = _defaultSCPServer
   End If
   If _tbStorePage Is tbPage Then
   ServerList = serverlistStore
   iDefault = _defaultStoreServer
   End If

   If dataGridViewServers.Rows.Count > 0 Then
   If dataGridViewServers.Rows.Count <= iDefault Then
      iDefault = dataGridViewServers.Rows.Count - 1
   End If
   dataGridViewServers.Rows(iDefault).Cells(6).Value = True
   End If
   End Sub

   Private Sub textBox4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtSCColor.TextChanged

   End Sub

   Private Sub textBox2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtTempDir.TextChanged

   End Sub

   Private Sub _txt_Leave(ByVal sender As Object, ByVal e As EventArgs)
   Dim txtBox As TextBox = TryCast(sender, TextBox)
   Dim iClass As Integer = Integer.Parse(CStr(txtBox.Tag))
   Dim dclass As DicomClassType = ClassTypes(iClass)
   If txtBox.Text = String.Empty Then
   Return
   End If
   Dim ds As DicomDataSet = New DicomDataSet()
   Try
   DicomExtensions.LoadXml(ds, txtBox.Text, DicomDataSetLoadXmlFlags.None)
   Catch
    ds = Nothing
   End Try

   If ds Is Nothing Then
   MessageBox.Show("The selected file is not a valid DICOM XML File")
   txtBox.Text = ""
   Else
   If ds.InformationClass <> dclass Then
      MessageBox.Show("The selected DICOM XML file is not a " & dclass.ToString() & " file")
      txtBox.Text = ""
   End If
   End If

   End Sub

   Private Sub dataGridViewServers_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridViewServers.CellClick
   If e.ColumnIndex = 5 AndAlso e.RowIndex >= 0 Then
   Try
      CheckAssociation((TryCast(sender, Control)).Parent, e.RowIndex)
   Catch
      MessageBox.Show(Me, "Some fields are not valid", "Print To PACS", MessageBoxButtons.OK, MessageBoxIcon.Error)
   End Try
   End If
   Dim servers As MyServerList = CType(_tbServers.SelectedTab.Tag, MyServerList)
   If e.ColumnIndex = 6 AndAlso e.RowIndex >= 0 Then
   For Each row As DataGridViewRow In dataGridViewServers.Rows
      row.Cells(6).Value = False
   Next row

   dataGridViewServers(6, e.RowIndex).Value = True
   If (TryCast(sender, Control)).Parent Is _tbMWLQueryPage Then
      _defaultMWLServer = e.RowIndex
   End If
   If (TryCast(sender, Control)).Parent Is _tbSCPQuerypage Then
      _defaultSCPServer = e.RowIndex
   End If
   If (TryCast(sender, Control)).Parent Is _tbStorePage Then
      _defaultStoreServer = e.RowIndex
   End If
   End If
   EnableDialogItems()
   End Sub

   Private Sub _find_AfterAssociateRequest(ByVal sender As Object, ByVal e As AfterAssociateRequestEventArgs)
   bTimeOut = False
   For Each association As AssociationHolder In lstAssociations
   Try
      If e.Associate.GetResult(association.PresentationContextNumber) = DicomAssociateAcceptResultType.Success Then
       association.Result = "Success"
      Else
       association.Result = "Failed"
      End If
   Catch
    association.Result = "Failed"
   End Try
   Next association
   End Sub

   Private Sub _find_BeforeAssociateRequest(ByVal sender As Object, ByVal e As BeforeAssociateRequestEventArgs)
   Dim i As Integer = 0
   Do While i <= e.Associate.PresentationContextCount
   e.Associate.DeletePresentation(CByte(2 * i + 1))
    i += 1
   Loop
   For Each association As AssociationHolder In lstAssociations
   e.Associate.AddPresentationContext(association.PresentationContextNumber, DicomAssociateAcceptResultType.Success, association.PresentationContext)
   For Each str As String In association.TransferSyntax
      e.Associate.AddTransfer(association.PresentationContextNumber, str)
   Next str
   Next association
   End Sub

   Private Sub _find_AfterConnect(ByVal sender As Object, ByVal e As AfterConnectEventArgs)
   'if (e.Error == DicomExceptionCode.Success)
   '   MessageBox.Show("Dicom Verification Success");
   'else
   '   MessageBox.Show("Dicom Verification Failed");
   End Sub

#End Region

#Region "Methods"

   Private Sub CheckAssociation(ByVal parent As Control, ByVal iRow As Integer)
   Dim strServerAE As String = dataGridViewServers(0, iRow).Value.ToString()
   Dim strServerIP As String = dataGridViewServers(1, iRow).Value.ToString()
   Dim strServerPort As String = dataGridViewServers(2, iRow).Value.ToString()
   Dim strServerTimeOut As String = Nothing
   Try
   strServerTimeOut = dataGridViewServers(3, iRow).Value.ToString()
   Catch
     strServerTimeOut = "15"
    dataGridViewServers(3, iRow).Value = "15"
   End Try

   Dim tls As Boolean = False
   If Not dataGridViewServers(4, iRow).Value Is Nothing Then
   tls = Boolean.Parse(dataGridViewServers(4, iRow).Value.ToString())
   End If

   Dim dicomScp As DicomScp = New DicomScp()
   dicomScp.AETitle = strServerAE
   dicomScp.PeerAddress = IPAddress.Parse(strServerIP)
   dicomScp.Port = Integer.Parse(strServerPort)
   dicomScp.Timeout = Integer.Parse(strServerTimeOut)
   Dim _find As QueryRetrieveScu = Nothing

#If Not LEADTOOLS_V20_OR_LATER Then
         If tls Then
            _find = New QueryRetrieveScu(_txtTempDir.Text, DicomNetSecurityeMode.Tls, Nothing)
         Else
            _find = New QueryRetrieveScu(Nothing, DicomNetSecurityeMode.None, Nothing)
         End If
#Else
         If tls Then
            _find = New QueryRetrieveScu(_txtTempDir.Text, DicomNetSecurityMode.Tls, Nothing)
         Else
            _find = New QueryRetrieveScu(Nothing, DicomNetSecurityMode.None, Nothing)
         End If
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

   Try

   _find.ImplementationClass = FrmMain._sConfigurationImplementationClass
   _find.ProtocolVersion = FrmMain._sConfigurationProtocolversion
   _find.ImplementationVersionName = FrmMain._sConfigurationImplementationVersionName
   _find.AETitle = _textBoxClientAE.Text
   _find.HostPort = 1000

   AddHandler _find.AfterConnect, AddressOf _find_AfterConnect
   AddHandler _find.BeforeAssociateRequest, AddressOf _find_BeforeAssociateRequest
   AddHandler _find.AfterAssociateRequest, AddressOf _find_AfterAssociateRequest
   AddHandler _find.PrivateKeyPassword, AddressOf _find_PrivateKeyPassword
   If tls Then
      Try
      If (Not CheckFileExists("Certificate", _textBoxClientCertificate, True)) Then
      Return
      End If
      If (Not CheckFileExists("Private Key", _textBoxPrivateKey, True)) Then
      Return
      End If

      _find.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha)
      If _textBoxPrivateKey.Text.Length > 0 Then
       _find.SetTlsClientCertificate(_textBoxClientCertificate.Text, DicomTlsCertificateType.Pem, _textBoxPrivateKey.Text)
      Else
       _find.SetTlsClientCertificate(_textBoxClientCertificate.Text, DicomTlsCertificateType.Pem, Nothing)
      End If
      Catch ex As Exception
      MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
      End Try
   End If

   DoAssociation(dicomScp, _find, Not parent Is _tbStorePage)
   Catch
   End Try
   End Sub

   Private Sub _find_PrivateKeyPassword(ByVal sender As Object, ByVal e As PrivateKeyPasswordEventArgs)
   e.PrivateKeyPassword = _textBoxKeyPassword.Text
   End Sub

   Private Sub EnableDialogItems()
   Dim bEnable As Boolean = IsAnyServerUseTls()
   _labelCertificate.Enabled = bEnable
   _buttonClientCertificate.Enabled = bEnable
   _textBoxClientCertificate.Enabled = bEnable

   _labelPrivateKey.Enabled = bEnable
   _buttonClientCertificate.Enabled = bEnable
   _textBoxClientCertificate.Enabled = bEnable

   _labelPrivateKey.Enabled = bEnable
   _buttonPrivateKey.Enabled = bEnable
   _textBoxPrivateKey.Enabled = bEnable

   _labelPrivateKeyPassword.Enabled = bEnable
   _textBoxKeyPassword.Enabled = bEnable
   _labelHint.Enabled = bEnable
   End Sub

   Private Function CheckInteger(ByVal tb As TextBox, ByVal lb As Label) As Boolean
   Try
   Convert.ToInt32(tb.Text)
   Return True
   Catch e1 As Exception
   If tb.Text.Trim() = String.Empty Then
      MessageBox.Show("Invalid " & lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
   End If
   tb.SelectAll()
   tb.Focus()
   DialogResult = DialogResult.None
   Return False
   End Try
   End Function

   Private Function CheckIP(ByVal ip As String) As Boolean
   Try
   System.Net.IPAddress.Parse(ip)
   Return True
   Catch e1 As Exception
   Return False
   End Try
   End Function

   Private Function CheckIP(ByVal tb As TextBox, ByVal lb As Label) As Boolean
   Dim valid As Boolean = CheckIP(tb.Text)
   If (Not valid) Then
   If tb.Text.Trim() = String.Empty Then
      MessageBox.Show("Invalid " & lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
   End If
   tb.SelectAll()
   tb.Focus()
   DialogResult = DialogResult.None
   Return False
   End If
   Return True
   End Function

   Private Function CheckFileExists(ByVal title As String, ByVal tb As TextBox, ByVal showMessageBox As Boolean) As Boolean
   Dim ret As Boolean = True
   Dim sMsg As String = String.Empty
   Dim sFile As String = tb.Text.Trim()
   If sFile.Length = 0 Then
   sMsg = title & " Field Error" & Constants.vbLf & "Field can not be empty if 'Secure (TLS)' is checked."
   ret = False
   ElseIf (Not File.Exists(sFile)) Then
   sMsg = title & " Field Error" & Constants.vbLf & "File does not exist: " & sFile
   ret = False
   End If
   If (ret = False) AndAlso showMessageBox Then
   MessageBox.Show(sMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
   tb.SelectAll()
   tb.Focus()
   DialogResult = DialogResult.None
   End If
   Return ret
   End Function

   Private Sub DoAssociation(ByVal dicomScp As DicomScp, ByVal _find As QueryRetrieveScu, ByVal bFind As Boolean)
   Dim strError As String = ""
   If (Not bFind) Then
   lstAssociations = New List(Of AssociationHolder)()
   Dim transfersyntax As List(Of String)

   transfersyntax = New List(Of String)()
   transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian)
   lstAssociations.Add(New AssociationHolder(1, DicomUidType.VerificationClass, transfersyntax, "DICOM Verification"))

   'Encapsulated Pdf Storage
   transfersyntax = New List(Of String)()
   transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian)
   transfersyntax.Add(DicomUidType.ExplicitVRLittleEndian)
   lstAssociations.Add(New AssociationHolder(3, DicomUidType.EncapsulatedPdfStorage, transfersyntax, Constants.vbLf & "Encapsulated PDF Storage"))

   iLastNumber = 3
   AddAssociate(lstAssociations, Constants.vbLf & "Secondary Capture Image Storage", DicomUidType.SCImageStorage)
   AddAssociate(lstAssociations, Constants.vbLf & "Secondary Capture Multi-Frame Grayscale Byte Image Storage", DicomUidType.SCMultiFrameTrueColorImageStorage)
   AddAssociate(lstAssociations, Constants.vbLf & "Secondary Capture Multi-Frame True Color Image Storage", DicomUidType.SCMultiFrameGrayscaleByteImageStorage)

   Try
      bTimeOut = True
      _find.Verify(dicomScp)
   Catch ex As Exception
      strError = ", Reason:" & Constants.vbLf + ex.Message
      bTimeOut = True
   End Try
   If bTimeOut Then
      MessageBox.Show("DICOM Verification Failed" & strError, "Print To PACS")
   Else
      Dim Result As String = ""
      For Each associate As AssociationHolder In lstAssociations
      Result &= associate.Title & "  " & associate.Result & Constants.vbLf
      Next associate
      MessageBox.Show(Result, "Print To PACS")
   End If
   Else
   lstAssociations = New List(Of AssociationHolder)()
   Dim transfersyntax As List(Of String) = New List(Of String)()
   transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian)
   lstAssociations.Add(New AssociationHolder(1, DicomUidType.VerificationClass, transfersyntax, "DICOM Verification"))

   Try
      bTimeOut = True
      _find.Verify(dicomScp)
   Catch ex As Exception
      strError = ", Reason:" & Constants.vbLf + ex.Message
      bTimeOut = True
   End Try
   If bTimeOut Then
      MessageBox.Show("DICOM Verification Failed" & strError, "Print To PACS")
   Else
      Dim Result As String = ""
      For Each associate As AssociationHolder In lstAssociations
      Result &= associate.Title & "  " & associate.Result & Constants.vbLf
      Next associate
      MessageBox.Show(Result, "Print To PACS")
   End If
   End If
   End Sub

   Private Sub AddAssociate(ByVal lstAssociations As List(Of AssociationHolder), ByVal strTitle As String, ByVal strClass As String)
   Dim transfersyntax As List(Of String)
   iLastNumber += 2
   'Secondary Capture Image Storage
   transfersyntax = New List(Of String)()
   transfersyntax.Add(DicomUidType.ImplicitVRLittleEndian)
   transfersyntax.Add(DicomUidType.ExplicitVRLittleEndian)
   lstAssociations.Add(New AssociationHolder(CByte(iLastNumber), strClass, transfersyntax, strTitle))
   iLastNumber += 2
   'JPEG Baseline (Process 1)
   transfersyntax = New List(Of String)()
   transfersyntax.Add(DicomUidType.JPEGBaseline1)
   lstAssociations.Add(New AssociationHolder(CByte(iLastNumber), strClass, transfersyntax, "--> JPEG Baseline (Process 1)"))
   iLastNumber += 2
   'JPEG Lossless, Non-Hierarchical, First-Order Prediction 
   transfersyntax = New List(Of String)()
   transfersyntax.Add(DicomUidType.JPEGLosslessNonhier14B)
   lstAssociations.Add(New AssociationHolder(CByte(iLastNumber), strClass, transfersyntax, "--> JPEG Lossless, Non-Hierarchical, First-Order Prediction"))
   iLastNumber += 2
   'JPEG 2000 Image Compression (Lossless Only)
   transfersyntax = New List(Of String)()
   transfersyntax.Add(DicomUidType.JPEG2000LosslessOnly)
   lstAssociations.Add(New AssociationHolder(CByte(iLastNumber), strClass, transfersyntax, "--> JPEG 2000 Image Compression (Lossless Only)"))
   iLastNumber += 2
   'JPEG 2000 Image Compression
   transfersyntax = New List(Of String)()
   transfersyntax.Add(DicomUidType.JPEG2000)
   lstAssociations.Add(New AssociationHolder(CByte(iLastNumber), strClass, transfersyntax, "--> JPEG 2000 Image Compression"))
   End Sub

   ' Return true if any of the servers are using tls
   ' Return false if all of the servers do not use tls
   Private Function IsAnyServerUseTls() As Boolean
   UpdateServers()

   Dim i As Integer = 0
   Do While i < serverlistSCP.serverList.Length
   If serverlistSCP.serverList(i)._useTls Then
      Return True
   End If
    i += 1
   Loop
   i = 0
   Do While i < serverlistMWL.serverList.Length
   If serverlistMWL.serverList(i)._useTls Then
      Return True
   End If
    i += 1
   Loop
   i = 0
   Do While i < serverlistStore.serverList.Length
   If serverlistStore.serverList(i)._useTls Then
      Return True
   End If
    i += 1
   Loop
   Return False
   End Function

   Private Sub UpdateServers()
   Try
   If _tbServers.SelectedTab Is _tbSCPQuerypage Then
      Dim i As Integer = 0
      Do While i < serverlistSCP.serverList.Length
      serverlistSCP.serverList(i)._useTls = Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value)

       i += 1
      Loop
   End If

   If _tbServers.SelectedTab Is _tbMWLQueryPage Then
      Dim i As Integer = 0
      Do While i < serverlistSCP.serverList.Length
      serverlistMWL.serverList(i)._useTls = Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value)

       i += 1
      Loop
   End If

   If _tbServers.SelectedTab Is _tbStorePage Then
      Dim i As Integer = 0
      Do While i < serverlistSCP.serverList.Length
      serverlistStore.serverList(i)._useTls = Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value)

       i += 1
      Loop
   End If
   Catch
   End Try
   End Sub

#End Region
   End Class

   Friend Class AssociationHolder
   Public Title As String
   Public Result As String
   Public PresentationContext As String
   Public TransferSyntax As List(Of String)
   Public PresentationContextNumber As Byte

   Public Sub New(ByVal presentationContextNumberParam As Byte, ByVal presentationContextParam As String, ByVal transferSyntaxParam As List(Of String), ByVal titleParam As String)
   PresentationContext = presentationContextParam
   TransferSyntax = transferSyntaxParam
   PresentationContextNumber = presentationContextNumberParam
   Title = titleParam
   End Sub
   End Class
End Namespace


