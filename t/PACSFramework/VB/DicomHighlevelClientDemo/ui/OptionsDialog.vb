' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms
Imports System.IO
Imports Leadtools.DicomDemos
Imports System.Collections.Generic
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos.CipherSuiteItems

Namespace DicomDemo
    ''' <summary>
    ''' Summary description for OptionsDialog.
    ''' </summary>
    Public Class OptionsDialog
        Inherits System.Windows.Forms.Form
        Private _groupBoxClient As System.Windows.Forms.GroupBox
        Private _labelClientAE As System.Windows.Forms.Label
        Public _textBoxClientAE As System.Windows.Forms.TextBox
        Public WithEvents _textBoxClientPort As System.Windows.Forms.TextBox
        Private _labelClientPort As System.Windows.Forms.Label
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
        Private components As System.ComponentModel.IContainer

        Private _clientAE As String
        Private _clientPort As Integer

        Private _storageClassList As New List(Of String)()

        Public Property StorageClassList() As List(Of String)
            Get
                Return _storageClassList
            End Get
            Set(ByVal value As List(Of String))
                _storageClassList = value
            End Set
        End Property


        Public Property ServerList() As List(Of DicomAE)
            Get
                'MyServer[] items = new MyServer[dataGridViewServers.Rows.Count];
                Dim items As New List(Of DicomAE)(dataGridViewServers.Rows.Count)
                For i As Integer = 0 To dataGridViewServers.Rows.Count - 1
                    Dim server As DicomAE

                    server = New DicomAE()
                    server.AE = dataGridViewServers.Rows(i).Cells("ColumnAE").Value.ToString().Trim()
                    server.IPAddress = dataGridViewServers.Rows(i).Cells("ColumnIP").Value.ToString().Trim()
                    server.Timeout = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnTimeout").Value)
                    server.Port = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnPort").Value)
                    server.UseTls = Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value)

                    items.Add(server)
                Next i
                Return items
            End Get

            Set(ByVal value As List(Of DicomAE))
                For Each s As DicomAE In value
                    Dim n As Integer = dataGridViewServers.Rows.Add()
                    dataGridViewServers.Rows(n).Cells("ColumnAE").Value = s.AE.Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnIP").Value = s.IPAddress.Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnTimeout").Value = s.Timeout.ToString().Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnPort").Value = s.Port.ToString().Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnTls").Value = s.UseTls.ToString().Trim()
                Next s
            End Set
        End Property

        Private _clientCertificate As String
        Private _privateKey As String
        Private _privateKeyPassword As String
        Private WithEvents dataGridViewServers As DataGridView
        Private WithEvents buttonAddServer As Button
        Private WithEvents buttonDeleteServer As Button
        Private _groupBoxSecurity As GroupBox
        Private ColumnAE As DataGridViewTextBoxColumn
        Private ColumnIP As DataGridViewTextBoxColumn
        Private ColumnPort As DataGridViewTextBoxColumn
        Private ColumnTimeout As DataGridViewTextBoxColumn
        Private ColumnTls As DataGridViewCheckBoxColumn
        Private WithEvents _groupMiscellaneous As System.Windows.Forms.GroupBox
        Private WithEvents _checkBoxGroupLengthDataElements As System.Windows.Forms.CheckBox
        Private _logLowLevel As Boolean
        Private WithEvents _labelLogLowLevel As Label
        Private WithEvents _checkBoxLogLowLevel As CheckBox
        Friend WithEvents ImageListCiphers As ImageList
        Private WithEvents groupBoxCipherSuites As GroupBox
        Private WithEvents _buttonMoveDown As Button
        Private WithEvents _checkBoxTlsOld As CheckBox
        Private WithEvents _buttonMoveUp As Button
        Private WithEvents _listViewCipherSuites As ListView
        Private WithEvents _comboBoxClientSecurity As ComboBox
        Private WithEvents _labelClientSecurity As Label
        Private WithEvents _labelCA As Label
        Private WithEvents _buttonCA As Button
        Private WithEvents _textBoxCA As TextBox
        Private _groupLengthDataElements As Boolean


        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            '
            ' TODO: Add any constructor code after InitializeComponent call
            '
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
            Me._groupBoxClient = New System.Windows.Forms.GroupBox()
            Me._textBoxClientPort = New System.Windows.Forms.TextBox()
            Me._labelClientPort = New System.Windows.Forms.Label()
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
            Me.buttonAddServer = New System.Windows.Forms.Button()
            Me.buttonDeleteServer = New System.Windows.Forms.Button()
            Me._groupBoxSecurity = New System.Windows.Forms.GroupBox()
            Me._groupMiscellaneous = New System.Windows.Forms.GroupBox()
            Me._labelLogLowLevel = New System.Windows.Forms.Label()
            Me._checkBoxLogLowLevel = New System.Windows.Forms.CheckBox()
            Me._checkBoxGroupLengthDataElements = New System.Windows.Forms.CheckBox()
            Me.ImageListCiphers = New System.Windows.Forms.ImageList(Me.components)
            Me.groupBoxCipherSuites = New System.Windows.Forms.GroupBox()
            Me._buttonMoveDown = New System.Windows.Forms.Button()
            Me._checkBoxTlsOld = New System.Windows.Forms.CheckBox()
            Me._buttonMoveUp = New System.Windows.Forms.Button()
            Me._listViewCipherSuites = New System.Windows.Forms.ListView()
            Me._comboBoxClientSecurity = New System.Windows.Forms.ComboBox()
            Me._labelClientSecurity = New System.Windows.Forms.Label()
            Me._labelCA = New System.Windows.Forms.Label()
            Me._buttonCA = New System.Windows.Forms.Button()
            Me._textBoxCA = New System.Windows.Forms.TextBox()
            Me._groupBoxClient.SuspendLayout()
            CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._groupBoxSecurity.SuspendLayout()
            Me._groupMiscellaneous.SuspendLayout()
            Me.groupBoxCipherSuites.SuspendLayout()
            Me.SuspendLayout()
            '
            '_groupBoxClient
            '
            Me._groupBoxClient.Controls.Add(Me._comboBoxClientSecurity)
            Me._groupBoxClient.Controls.Add(Me._labelClientSecurity)
            Me._groupBoxClient.Controls.Add(Me._textBoxClientPort)
            Me._groupBoxClient.Controls.Add(Me._labelClientPort)
            Me._groupBoxClient.Controls.Add(Me._textBoxClientAE)
            Me._groupBoxClient.Controls.Add(Me._labelClientAE)
            Me._groupBoxClient.Location = New System.Drawing.Point(8, 8)
            Me._groupBoxClient.Name = "_groupBoxClient"
            Me._groupBoxClient.Size = New System.Drawing.Size(544, 80)
            Me._groupBoxClient.TabIndex = 1
            Me._groupBoxClient.TabStop = False
            Me._groupBoxClient.Text = "Client Information"
            '
            '_textBoxClientPort
            '
            Me._textBoxClientPort.Location = New System.Drawing.Point(111, 46)
            Me._textBoxClientPort.Name = "_textBoxClientPort"
            Me._textBoxClientPort.Size = New System.Drawing.Size(121, 20)
            Me._textBoxClientPort.TabIndex = 2
            '
            '_labelClientPort
            '
            Me._labelClientPort.AutoSize = True
            Me._labelClientPort.Location = New System.Drawing.Point(16, 50)
            Me._labelClientPort.Name = "_labelClientPort"
            Me._labelClientPort.Size = New System.Drawing.Size(78, 13)
            Me._labelClientPort.TabIndex = 1
            Me._labelClientPort.Text = "Client Port No.:"
            '
            '_textBoxClientAE
            '
            Me._textBoxClientAE.Location = New System.Drawing.Point(111, 20)
            Me._textBoxClientAE.Name = "_textBoxClientAE"
            Me._textBoxClientAE.Size = New System.Drawing.Size(418, 20)
            Me._textBoxClientAE.TabIndex = 0
            '
            '_labelClientAE
            '
            Me._labelClientAE.AutoSize = True
            Me._labelClientAE.Location = New System.Drawing.Point(16, 24)
            Me._labelClientAE.Name = "_labelClientAE"
            Me._labelClientAE.Size = New System.Drawing.Size(84, 13)
            Me._labelClientAE.TabIndex = 0
            Me._labelClientAE.Text = "Client AE Name:"
            '
            '_labelHint
            '
            Me._labelHint.AutoSize = True
            Me._labelHint.ForeColor = System.Drawing.Color.Blue
            Me._labelHint.Location = New System.Drawing.Point(264, 102)
            Me._labelHint.Name = "_labelHint"
            Me._labelHint.Size = New System.Drawing.Size(140, 13)
            Me._labelHint.TabIndex = 11
            Me._labelHint.Text = "<== Use 'test'  for client.pem"
            '
            '_textBoxKeyPassword
            '
            Me._textBoxKeyPassword.Location = New System.Drawing.Point(111, 98)
            Me._textBoxKeyPassword.Name = "_textBoxKeyPassword"
            Me._textBoxKeyPassword.Size = New System.Drawing.Size(146, 20)
            Me._textBoxKeyPassword.TabIndex = 10
            '
            '_textBoxPrivateKey
            '
            Me._textBoxPrivateKey.Location = New System.Drawing.Point(111, 72)
            Me._textBoxPrivateKey.Name = "_textBoxPrivateKey"
            Me._textBoxPrivateKey.Size = New System.Drawing.Size(418, 20)
            Me._textBoxPrivateKey.TabIndex = 8
            '
            '_buttonPrivateKey
            '
            Me._buttonPrivateKey.Image = CType(resources.GetObject("_buttonPrivateKey.Image"), System.Drawing.Image)
            Me._buttonPrivateKey.Location = New System.Drawing.Point(80, 73)
            Me._buttonPrivateKey.Name = "_buttonPrivateKey"
            Me._buttonPrivateKey.Size = New System.Drawing.Size(23, 20)
            Me._buttonPrivateKey.TabIndex = 7
            Me._buttonPrivateKey.UseVisualStyleBackColor = True
            '
            '_labelPrivateKey
            '
            Me._labelPrivateKey.AutoSize = True
            Me._labelPrivateKey.Location = New System.Drawing.Point(16, 76)
            Me._labelPrivateKey.Name = "_labelPrivateKey"
            Me._labelPrivateKey.Size = New System.Drawing.Size(64, 13)
            Me._labelPrivateKey.TabIndex = 6
            Me._labelPrivateKey.Text = "Private Key:"
            '
            '_labelPrivateKeyPassword
            '
            Me._labelPrivateKeyPassword.AutoSize = True
            Me._labelPrivateKeyPassword.Location = New System.Drawing.Point(16, 102)
            Me._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword"
            Me._labelPrivateKeyPassword.Size = New System.Drawing.Size(77, 13)
            Me._labelPrivateKeyPassword.TabIndex = 9
            Me._labelPrivateKeyPassword.Text = "Key Password:"
            '
            '_textBoxClientCertificate
            '
            Me._textBoxClientCertificate.Location = New System.Drawing.Point(111, 46)
            Me._textBoxClientCertificate.Name = "_textBoxClientCertificate"
            Me._textBoxClientCertificate.Size = New System.Drawing.Size(418, 20)
            Me._textBoxClientCertificate.TabIndex = 5
            '
            '_buttonClientCertificate
            '
            Me._buttonClientCertificate.Image = CType(resources.GetObject("_buttonClientCertificate.Image"), System.Drawing.Image)
            Me._buttonClientCertificate.Location = New System.Drawing.Point(80, 47)
            Me._buttonClientCertificate.Name = "_buttonClientCertificate"
            Me._buttonClientCertificate.Size = New System.Drawing.Size(23, 20)
            Me._buttonClientCertificate.TabIndex = 4
            Me._buttonClientCertificate.UseVisualStyleBackColor = True
            '
            '_labelCertificate
            '
            Me._labelCertificate.AutoSize = True
            Me._labelCertificate.Location = New System.Drawing.Point(16, 50)
            Me._labelCertificate.Name = "_labelCertificate"
            Me._labelCertificate.Size = New System.Drawing.Size(57, 13)
            Me._labelCertificate.TabIndex = 3
            Me._labelCertificate.Text = "Certificate:"
            '
            'buttonOK
            '
            Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.buttonOK.Location = New System.Drawing.Point(200, 708)
            Me.buttonOK.Name = "buttonOK"
            Me.buttonOK.Size = New System.Drawing.Size(75, 23)
            Me.buttonOK.TabIndex = 8
            Me.buttonOK.Text = "&OK"
            '
            'buttonCancel
            '
            Me.buttonCancel.CausesValidation = False
            Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.buttonCancel.Location = New System.Drawing.Point(285, 708)
            Me.buttonCancel.Name = "buttonCancel"
            Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
            Me.buttonCancel.TabIndex = 0
            Me.buttonCancel.Text = "&Cancel"
            '
            'dataGridViewServers
            '
            Me.dataGridViewServers.AllowUserToAddRows = False
            Me.dataGridViewServers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dataGridViewServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataGridViewServers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnAE, Me.ColumnIP, Me.ColumnPort, Me.ColumnTimeout, Me.ColumnTls})
            Me.dataGridViewServers.Location = New System.Drawing.Point(8, 551)
            Me.dataGridViewServers.Name = "dataGridViewServers"
            Me.dataGridViewServers.Size = New System.Drawing.Size(544, 150)
            Me.dataGridViewServers.TabIndex = 7
            '
            'ColumnAE
            '
            Me.ColumnAE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ColumnAE.HeaderText = "Server AE Title"
            Me.ColumnAE.Name = "ColumnAE"
            '
            'ColumnIP
            '
            Me.ColumnIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.ColumnIP.HeaderText = "Server IP Address"
            Me.ColumnIP.Name = "ColumnIP"
            Me.ColumnIP.Width = 107
            '
            'ColumnPort
            '
            Me.ColumnPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ColumnPort.HeaderText = "Server Port"
            Me.ColumnPort.Name = "ColumnPort"
            Me.ColumnPort.Width = 78
            '
            'ColumnTimeout
            '
            Me.ColumnTimeout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ColumnTimeout.HeaderText = "Timeout (sec)"
            Me.ColumnTimeout.Name = "ColumnTimeout"
            Me.ColumnTimeout.Width = 88
            '
            'ColumnTls
            '
            Me.ColumnTls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.ColumnTls.HeaderText = "Secure (TLS)"
            Me.ColumnTls.Name = "ColumnTls"
            Me.ColumnTls.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.ColumnTls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.ColumnTls.Width = 87
            '
            'buttonAddServer
            '
            Me.buttonAddServer.Image = CType(resources.GetObject("buttonAddServer.Image"), System.Drawing.Image)
            Me.buttonAddServer.Location = New System.Drawing.Point(8, 511)
            Me.buttonAddServer.Name = "buttonAddServer"
            Me.buttonAddServer.Size = New System.Drawing.Size(40, 39)
            Me.buttonAddServer.TabIndex = 5
            Me.buttonAddServer.UseVisualStyleBackColor = True
            '
            'buttonDeleteServer
            '
            Me.buttonDeleteServer.CausesValidation = False
            Me.buttonDeleteServer.Image = CType(resources.GetObject("buttonDeleteServer.Image"), System.Drawing.Image)
            Me.buttonDeleteServer.Location = New System.Drawing.Point(48, 511)
            Me.buttonDeleteServer.Name = "buttonDeleteServer"
            Me.buttonDeleteServer.Size = New System.Drawing.Size(40, 39)
            Me.buttonDeleteServer.TabIndex = 6
            Me.buttonDeleteServer.UseVisualStyleBackColor = True
            '
            '_groupBoxSecurity
            '
            Me._groupBoxSecurity.Controls.Add(Me._labelCA)
            Me._groupBoxSecurity.Controls.Add(Me._buttonCA)
            Me._groupBoxSecurity.Controls.Add(Me._labelCertificate)
            Me._groupBoxSecurity.Controls.Add(Me._textBoxCA)
            Me._groupBoxSecurity.Controls.Add(Me._labelHint)
            Me._groupBoxSecurity.Controls.Add(Me._buttonClientCertificate)
            Me._groupBoxSecurity.Controls.Add(Me._textBoxClientCertificate)
            Me._groupBoxSecurity.Controls.Add(Me._textBoxKeyPassword)
            Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKeyPassword)
            Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKey)
            Me._groupBoxSecurity.Controls.Add(Me._textBoxPrivateKey)
            Me._groupBoxSecurity.Controls.Add(Me._buttonPrivateKey)
            Me._groupBoxSecurity.Location = New System.Drawing.Point(8, 97)
            Me._groupBoxSecurity.Name = "_groupBoxSecurity"
            Me._groupBoxSecurity.Size = New System.Drawing.Size(544, 125)
            Me._groupBoxSecurity.TabIndex = 2
            Me._groupBoxSecurity.TabStop = False
            Me._groupBoxSecurity.Text = "Security"
            '
            '_groupMiscellaneous
            '
            Me._groupMiscellaneous.Controls.Add(Me._labelLogLowLevel)
            Me._groupMiscellaneous.Controls.Add(Me._checkBoxLogLowLevel)
            Me._groupMiscellaneous.Controls.Add(Me._checkBoxGroupLengthDataElements)
            Me._groupMiscellaneous.Location = New System.Drawing.Point(8, 428)
            Me._groupMiscellaneous.Name = "_groupMiscellaneous"
            Me._groupMiscellaneous.Size = New System.Drawing.Size(544, 66)
            Me._groupMiscellaneous.TabIndex = 4
            Me._groupMiscellaneous.TabStop = False
            Me._groupMiscellaneous.Text = "Miscellaneous"
            '
            '_labelLogLowLevel
            '
            Me._labelLogLowLevel.AutoSize = True
            Me._labelLogLowLevel.ForeColor = System.Drawing.Color.Green
            Me._labelLogLowLevel.Location = New System.Drawing.Point(138, 45)
            Me._labelLogLowLevel.Name = "_labelLogLowLevel"
            Me._labelLogLowLevel.Size = New System.Drawing.Size(189, 13)
            Me._labelLogLowLevel.TabIndex = 2
            Me._labelLogLowLevel.Text = "<== Displayed green in the log window"
            '
            '_checkBoxLogLowLevel
            '
            Me._checkBoxLogLowLevel.AutoSize = True
            Me._checkBoxLogLowLevel.Location = New System.Drawing.Point(15, 43)
            Me._checkBoxLogLowLevel.Name = "_checkBoxLogLowLevel"
            Me._checkBoxLogLowLevel.Size = New System.Drawing.Size(116, 17)
            Me._checkBoxLogLowLevel.TabIndex = 1
            Me._checkBoxLogLowLevel.Text = "Low Level Logging"
            Me._checkBoxLogLowLevel.UseVisualStyleBackColor = True
            '
            '_checkBoxGroupLengthDataElements
            '
            Me._checkBoxGroupLengthDataElements.AutoSize = True
            Me._checkBoxGroupLengthDataElements.Location = New System.Drawing.Point(15, 20)
            Me._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements"
            Me._checkBoxGroupLengthDataElements.Size = New System.Drawing.Size(201, 17)
            Me._checkBoxGroupLengthDataElements.TabIndex = 0
            Me._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements"
            Me._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = True
            '
            'ImageListCiphers
            '
            Me.ImageListCiphers.ImageStream = CType(resources.GetObject("ImageListCiphers.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListCiphers.TransparentColor = System.Drawing.Color.Transparent
            Me.ImageListCiphers.Images.SetKeyName(0, "yellowBullet.png")
            Me.ImageListCiphers.Images.SetKeyName(1, "yellowBullet.png")
            Me.ImageListCiphers.Images.SetKeyName(2, "greenBullet.png")
            '
            'groupBoxCipherSuites
            '
            Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveDown)
            Me.groupBoxCipherSuites.Controls.Add(Me._checkBoxTlsOld)
            Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveUp)
            Me.groupBoxCipherSuites.Controls.Add(Me._listViewCipherSuites)
            Me.groupBoxCipherSuites.Location = New System.Drawing.Point(8, 231)
            Me.groupBoxCipherSuites.Name = "groupBoxCipherSuites"
            Me.groupBoxCipherSuites.Size = New System.Drawing.Size(544, 188)
            Me.groupBoxCipherSuites.TabIndex = 3
            Me.groupBoxCipherSuites.TabStop = False
            Me.groupBoxCipherSuites.Text = "Cipher Suites"
            '
            '_buttonMoveDown
            '
            Me._buttonMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me._buttonMoveDown.Image = CType(resources.GetObject("_buttonMoveDown.Image"), System.Drawing.Image)
            Me._buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
            Me._buttonMoveDown.Location = New System.Drawing.Point(16, 120)
            Me._buttonMoveDown.Name = "_buttonMoveDown"
            Me._buttonMoveDown.Size = New System.Drawing.Size(85, 38)
            Me._buttonMoveDown.TabIndex = 1
            Me._buttonMoveDown.Text = "Low Priority"
            Me._buttonMoveDown.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me._buttonMoveDown.UseVisualStyleBackColor = True
            '
            '_checkBoxTlsOld
            '
            Me._checkBoxTlsOld.AutoSize = True
            Me._checkBoxTlsOld.Location = New System.Drawing.Point(110, 164)
            Me._checkBoxTlsOld.Name = "_checkBoxTlsOld"
            Me._checkBoxTlsOld.Size = New System.Drawing.Size(235, 17)
            Me._checkBoxTlsOld.TabIndex = 3
            Me._checkBoxTlsOld.Text = "Include TLS 1.0 Cipher Suites (Less Secure)"
            Me._checkBoxTlsOld.UseVisualStyleBackColor = True
            '
            '_buttonMoveUp
            '
            Me._buttonMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me._buttonMoveUp.Image = CType(resources.GetObject("_buttonMoveUp.Image"), System.Drawing.Image)
            Me._buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me._buttonMoveUp.Location = New System.Drawing.Point(16, 16)
            Me._buttonMoveUp.Name = "_buttonMoveUp"
            Me._buttonMoveUp.Size = New System.Drawing.Size(85, 38)
            Me._buttonMoveUp.TabIndex = 0
            Me._buttonMoveUp.Text = "High Priority"
            Me._buttonMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me._buttonMoveUp.UseVisualStyleBackColor = True
            '
            '_listViewCipherSuites
            '
            Me._listViewCipherSuites.Location = New System.Drawing.Point(110, 16)
            Me._listViewCipherSuites.Name = "_listViewCipherSuites"
            Me._listViewCipherSuites.Size = New System.Drawing.Size(418, 142)
            Me._listViewCipherSuites.TabIndex = 2
            Me._listViewCipherSuites.UseCompatibleStateImageBehavior = False
            '
            '_comboBoxClientSecurity
            '
            Me._comboBoxClientSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._comboBoxClientSecurity.FormattingEnabled = True
            Me._comboBoxClientSecurity.Location = New System.Drawing.Point(351, 46)
            Me._comboBoxClientSecurity.Name = "_comboBoxClientSecurity"
            Me._comboBoxClientSecurity.Size = New System.Drawing.Size(178, 21)
            Me._comboBoxClientSecurity.TabIndex = 4
            '
            '_labelClientSecurity
            '
            Me._labelClientSecurity.AutoSize = True
            Me._labelClientSecurity.Location = New System.Drawing.Point(246, 50)
            Me._labelClientSecurity.Name = "_labelClientSecurity"
            Me._labelClientSecurity.Size = New System.Drawing.Size(102, 13)
            Me._labelClientSecurity.TabIndex = 3
            Me._labelClientSecurity.Text = "Client Secure (TLS):"
            '
            '_labelCA
            '
            Me._labelCA.AutoSize = True
            Me._labelCA.Location = New System.Drawing.Point(5, 24)
            Me._labelCA.Name = "_labelCA"
            Me._labelCA.Size = New System.Drawing.Size(73, 13)
            Me._labelCA.TabIndex = 0
            Me._labelCA.Text = "Cert Authority:"
            '
            '_buttonCA
            '
            Me._buttonCA.Image = CType(resources.GetObject("_buttonCA.Image"), System.Drawing.Image)
            Me._buttonCA.Location = New System.Drawing.Point(80, 21)
            Me._buttonCA.Name = "_buttonCA"
            Me._buttonCA.Size = New System.Drawing.Size(23, 20)
            Me._buttonCA.TabIndex = 1
            Me._buttonCA.UseVisualStyleBackColor = True
            '
            '_textBoxCA
            '
            Me._textBoxCA.Location = New System.Drawing.Point(111, 20)
            Me._textBoxCA.Name = "_textBoxCA"
            Me._textBoxCA.Size = New System.Drawing.Size(418, 20)
            Me._textBoxCA.TabIndex = 2
            '
            'OptionsDialog
            '
            Me.AcceptButton = Me.buttonOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.CancelButton = Me.buttonCancel
            Me.ClientSize = New System.Drawing.Size(560, 734)
            Me.Controls.Add(Me.groupBoxCipherSuites)
            Me.Controls.Add(Me._groupMiscellaneous)
            Me.Controls.Add(Me._groupBoxSecurity)
            Me.Controls.Add(Me.buttonDeleteServer)
            Me.Controls.Add(Me.buttonAddServer)
            Me.Controls.Add(Me.dataGridViewServers)
            Me.Controls.Add(Me.buttonCancel)
            Me.Controls.Add(Me.buttonOK)
            Me.Controls.Add(Me._groupBoxClient)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "OptionsDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Options"
            Me._groupBoxClient.ResumeLayout(False)
            Me._groupBoxClient.PerformLayout()
            CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).EndInit()
            Me._groupBoxSecurity.ResumeLayout(False)
            Me._groupBoxSecurity.PerformLayout()
            Me._groupMiscellaneous.ResumeLayout(False)
            Me._groupMiscellaneous.PerformLayout()
            Me.groupBoxCipherSuites.ResumeLayout(False)
            Me.groupBoxCipherSuites.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private _imageRetrieveMethod As DicomRetrieveMode

        Public Property ImageRetrieveMethod() As DicomRetrieveMode
            Get
                Return _imageRetrieveMethod
            End Get
            Set(ByVal value As DicomRetrieveMode)
                _imageRetrieveMethod = value
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

        Public Property GroupLengthDataElements() As Boolean
            Get
                Return _groupLengthDataElements
            End Get
            Set(ByVal value As Boolean)
                _groupLengthDataElements = value
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

        Public Property PrivateKey() As String
            Get
                Return _privateKey
            End Get
            Set(ByVal value As String)
                _privateKey = value
            End Set
        End Property

        Private _certificateAuthority As String
        Public Property CertificateAuthority() As String
            Get
                Return _certificateAuthority
            End Get
            Set(ByVal value As String)
                _certificateAuthority = value
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

        Public Property ClientPort() As Integer
            Get
                Return _clientPort
            End Get
            Set(ByVal value As Integer)
                _clientPort = value
            End Set
        End Property

        Private _clientPortSecurityUsage As ClientPortUsageType
        Public Property ClientPortSecurityUsage() As ClientPortUsageType
            Get
                Return _clientPortSecurityUsage
            End Get
            Set(ByVal value As ClientPortUsageType)
                _clientPortSecurityUsage = value
            End Set
        End Property

        Private Sub ServerIp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Dim bValid As Boolean = Char.IsNumber(e.KeyChar) OrElse (e.KeyChar = "."c) OrElse Char.IsControl(e.KeyChar)
            e.Handled = Not bValid
        End Sub


        Private Sub Port_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _textBoxClientPort.KeyPress
            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
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
                DialogResult = System.Windows.Forms.DialogResult.None
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
                DialogResult = System.Windows.Forms.DialogResult.None
                Return False
            End If
            Return True
        End Function


        Private Function CheckFileExists(ByVal tb As TextBox, ByVal showMessageBox As Boolean) As Boolean
            Dim ret As Boolean = True
            Dim sMsg As String = String.Empty
            Dim sFile As String = tb.Text.Trim()
            If sFile.Length = 0 Then
                sMsg = "File can not be empty if 'Secure (TLS)' is checked."
                ret = False
            ElseIf (Not File.Exists(sFile)) Then
                sMsg = "File does not exist: " & sFile
                ret = False
            End If
            If (ret = False) AndAlso showMessageBox Then
                _errorProvider.SetError(tb, sMsg)
                tb.SelectAll()
                tb.Focus()
                DialogResult = DialogResult.None
            End If
            Return ret
        End Function

        Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOK.Click
            If IsAnyServerUseTls() Then
                If (Not CheckFileExists(_textBoxCA, True)) Then
                    Return
                End If
                If (Not CheckFileExists(_textBoxClientCertificate, True)) Then
                    Return
                End If
                If (Not CheckFileExists(_textBoxPrivateKey, True)) Then
                    Return
                End If
            End If

            If (Not CheckInteger(_textBoxClientPort, _labelClientPort)) Then
                Return
            End If

            _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing)

            ClientAE = _textBoxClientAE.Text
            ClientPort = Convert.ToInt32(_textBoxClientPort.Text)
            CertificateAuthority = _textBoxCA.Text
            ClientCertificate = _textBoxClientCertificate.Text
            PrivateKey = _textBoxPrivateKey.Text
            PrivateKeyPassword = _textBoxKeyPassword.Text
            LogLowLevel = _checkBoxLogLowLevel.Checked
            GroupLengthDataElements = _checkBoxGroupLengthDataElements.Checked

            Dim item As ClientPortSecurityTypeItem = TryCast(_comboBoxClientSecurity.SelectedItem, ClientPortSecurityTypeItem)
            If item IsNot Nothing Then
                ClientPortSecurityUsage = item.ClientSecurity
            End If
        End Sub

        Private Sub EnableDialogItems()
            Dim enable As Boolean = IsAnyServerUseTls()

            _labelCA.Enabled = enable
            _buttonCA.Enabled = enable
            _textBoxCA.Enabled = enable

            _labelCertificate.Enabled = enable
            _buttonClientCertificate.Enabled = enable
            _textBoxClientCertificate.Enabled = enable

            _labelPrivateKey.Enabled = enable
            _buttonClientCertificate.Enabled = enable
            _textBoxClientCertificate.Enabled = enable

            _labelPrivateKey.Enabled = enable
            _buttonPrivateKey.Enabled = enable
            _textBoxPrivateKey.Enabled = enable

            _labelPrivateKeyPassword.Enabled = enable
            _textBoxKeyPassword.Enabled = enable
            _labelHint.Enabled = enable

            ' Cipher Suites
            _buttonMoveUp.Enabled = enable
            _buttonMoveDown.Enabled = enable
            _listViewCipherSuites.Enabled = enable
            _checkBoxTlsOld.Enabled = enable

#If (Not LEADTOOLS_V19_OR_LATER) Then
		 Me._groupMiscellaneous.Visible = False
#End If
        End Sub

        Private _initializing As Boolean = True
        Private _errorProvider As ErrorProvider = Nothing

        Private Sub OptionsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            _errorProvider = New ErrorProvider(Me)
            _errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            _errorProvider.SetIconAlignment(Me, ErrorIconAlignment.TopLeft)
            _initializing = True
            _textBoxClientAE.Text = ClientAE
            _textBoxClientPort.Text = ClientPort.ToString()
            _textBoxCA.Text = CertificateAuthority
            _textBoxClientCertificate.Text = ClientCertificate
            _textBoxPrivateKey.Text = PrivateKey
            _textBoxKeyPassword.Text = PrivateKeyPassword
            _checkBoxLogLowLevel.Checked = LogLowLevel
            _checkBoxGroupLengthDataElements.Checked = GroupLengthDataElements

            AddHandler _textBoxCA.TextChanged, AddressOf _textBoxCA_TextChanged
            AddHandler _textBoxClientCertificate.TextChanged, AddressOf _textBoxClientCertificate_TextChanged
            AddHandler _textBoxPrivateKey.TextChanged, AddressOf _textBoxPrivateKey_TextChanged

            'AddHandler _checkBoxTlsOld.CheckedChanged, AddressOf checkBoxTlsOld_CheckedChanged
            'AddHandler _buttonMoveUp.Click, AddressOf buttonUp_Click
            'AddHandler _buttonMoveDown.Click, AddressOf buttonMoveDown_Click

            _listViewCipherSuites.InitializeCipherListView(CipherSuites, ImageListCiphers)
            _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites()

            _initializing = False

            _comboBoxClientSecurity.Items.Add(New ClientPortSecurityTypeItem(ClientPortUsageType.Unsecure, "No (unsecure)"))
            _comboBoxClientSecurity.Items.Add(New ClientPortSecurityTypeItem(ClientPortUsageType.Secure, "Yes (secure)"))
            _comboBoxClientSecurity.Items.Add(New ClientPortSecurityTypeItem(ClientPortUsageType.SameAsServer, "Same as 'Server Secure (TLS)'"))

            Select Case ClientPortSecurityUsage
                Case ClientPortUsageType.Unsecure
                    _comboBoxClientSecurity.SelectedIndex = 0
                Case ClientPortUsageType.Secure
                    _comboBoxClientSecurity.SelectedIndex = 1
                Case ClientPortUsageType.SameAsServer
                    _comboBoxClientSecurity.SelectedIndex = 2
            End Select

            EnableDialogItems()
        End Sub

        Private Sub _comboBoxClientSecurity_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _comboBoxClientSecurity.SelectedIndexChanged
            If _comboBoxClientSecurity.SelectedIndex <> 0 Then
                If Utils.VerifyOpensslVersion(Me) = False Then
                    _comboBoxClientSecurity.SelectedIndex = 0
                End If
            End If
        End Sub

        Private Sub _textBoxCA_TextChanged()
            _errorProvider.Clear()
        End Sub

        Private Sub _textBoxPrivateKey_TextChanged()
            _errorProvider.Clear()
        End Sub

        Private Sub _textBoxClientCertificate_TextChanged()
            _errorProvider.Clear()
        End Sub

        Private Sub _buttonCA_Click(sender As Object, e As EventArgs) Handles _buttonCA.Click
            Dim openDialog As New OpenFileDialog()
            openDialog.Title = "Select Certificate Authority"
            openDialog.FileName = _textBoxCA.Text
            openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
            Dim result As DialogResult = openDialog.ShowDialog(Me)
            If result = DialogResult.OK Then
                _textBoxCA.Text = openDialog.FileName
            End If
        End Sub

        Private Sub _buttonClientCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonClientCertificate.Click
            Dim openDialog As New OpenFileDialog()
            openDialog.Title = "Select Client Certificate"
            openDialog.FileName = _textBoxClientCertificate.Text
            openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
            Dim result As DialogResult = openDialog.ShowDialog(Me)
            If result = System.Windows.Forms.DialogResult.OK Then
                _textBoxClientCertificate.Text = openDialog.FileName
            End If
        End Sub

        Private Sub _buttonPrivateKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonPrivateKey.Click
            Dim openDialog As New OpenFileDialog()
            openDialog.Title = "Select Private Key File"
            openDialog.FileName = _textBoxPrivateKey.Text
            openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
            Dim result As DialogResult = openDialog.ShowDialog(Me)
            If result = DialogResult.OK Then
                _textBoxPrivateKey.Text = openDialog.FileName
            End If
        End Sub

        Private Sub _checkBoxLoggingLowLevel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _checkBoxLogLowLevel.CheckedChanged
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
                For Each row As DataGridViewRow In dataGridViewServers.SelectedRows
                    dataGridViewServers.Rows.Remove(row)
                Next row
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

                If (Nothing IsNot validatingRow.Cells(ColumnAE.Name).EditedFormattedValue AndAlso validatingRow.Cells(ColumnAE.Name).EditedFormattedValue.ToString().Length > 16) Then
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
                    Utils.ResolveIPAddress(ip)
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
                    validatingRow.ErrorText = String.Format("Invalid {0}.", ColumnTimeout.HeaderText)
                    e.Cancel = True
                    Return
                End If

                validatingRow.ErrorText = ""

            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
                Throw
            End Try
        End Sub

        ' Return true if any of the servers are using tls
        ' Return false if all of the servers do not use tls
        Private Function IsAnyServerUseTls() As Boolean
            For i As Integer = 0 To dataGridViewServers.Rows.Count - 1
                If Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value) Then
                    Return True
                End If
            Next i
            Return False
        End Function

        ' C
        Private Sub dataGridViewServers_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dataGridViewServers.CurrentCellDirtyStateChanged
            Dim d As DataGridView = TryCast(sender, DataGridView)
            If d IsNot Nothing Then
                Dim cb As DataGridViewCheckBoxCell = TryCast(d.CurrentCell, DataGridViewCheckBoxCell)
                If cb IsNot Nothing Then
                    If TypeOf cb.Value Is Boolean Then
                        Dim bValue As Boolean = CBool(cb.Value)
                        If bValue Then
                            If Utils.VerifyOpensslVersion(Me) = False Then
                                cb.Value = False
                                dataGridViewServers.RefreshEdit()
                                ' dataGridViewServers.Refresh();
                            End If
                        End If
                    End If

                    d.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
                    EnableDialogItems()
                End If
            End If
        End Sub

        Private Sub _buttonMoveUp_Click(sender As Object, e As EventArgs) Handles _buttonMoveUp.Click
            _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up)
        End Sub

        Private Sub _buttonMoveDown_Click(sender As Object, e As EventArgs) Handles _buttonMoveDown.Click
            _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down)
        End Sub

        Private Sub _checkBoxTlsOld_CheckedChanged(sender As Object, e As EventArgs) Handles _checkBoxTlsOld.CheckedChanged
            _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing)
            If _checkBoxTlsOld.Checked Then
                CipherSuites.AddOldCipherSuites()
            Else
                CipherSuites.RemoveOldCipherSuites()
            End If
            _listViewCipherSuites.UpdateCipherSuitesListView(CipherSuites)
            _listViewCipherSuites.Focus()

        End Sub

        Public CipherSuites As New CipherSuiteItems()
    End Class
End Namespace
