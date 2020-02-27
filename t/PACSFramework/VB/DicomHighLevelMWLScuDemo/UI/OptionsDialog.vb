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
Imports System.Collections.Generic

Imports Leadtools.DicomDemos
Imports Leadtools.Dicom

Namespace DicomDemo
    ''' <summary>
    ''' Summary description for OptionsDialog.
    ''' </summary>
    Public Class OptionsDialog : Inherits System.Windows.Forms.Form
        Private WithEvents buttonOK As System.Windows.Forms.Button
        Private buttonCancel As System.Windows.Forms.Button
        Private components As IContainer
        Private _clientAE As String
        Private _clientCertificate As String
        Private _privateKey As String
        Private _labelLogLowLevel As Label
        Private WithEvents _checkBoxLogLowLevel As CheckBox
        Private _privateKeyPassword As String
        Private _logLowLevel As Boolean
        Private _groupLengthDataElements As Boolean

        Private _Mwl As String
        Private _Mpps As String
        Private _Storage As String

        Private _groupBoxClient As GroupBox
        Private _textBoxClientAE As TextBox
        Private _labelClientAE As Label
        Private _groupBoxSecurity As GroupBox
        Private _labelCertificate As Label
        Private _labelHint As Label
        Private WithEvents _buttonClientCertificate As Button
        Private _textBoxClientCertificate As TextBox
        Private _textBoxKeyPassword As TextBox
        Private _labelPrivateKeyPassword As Label
        Private _labelPrivateKey As Label
        Private _textBoxPrivateKey As TextBox
        Private WithEvents _buttonPrivateKey As Button
        Private _groupBoxServers As GroupBox
        Private WithEvents dataGridViewServers As DataGridView
        Private ColumnAE As DataGridViewTextBoxColumn
        Private ColumnIP As DataGridViewTextBoxColumn
        Private ColumnPort As DataGridViewTextBoxColumn
        Private ColumnTimeout As DataGridViewTextBoxColumn
        Private WithEvents buttonDeleteServer As System.Windows.Forms.Button
        Private WithEvents buttonAddServer As System.Windows.Forms.Button
        Private WithEvents _groupMiscellaneous As System.Windows.Forms.GroupBox
        Private WithEvents _checkBoxGroupLengthDataElements As System.Windows.Forms.CheckBox
        Private WithEvents groupBoxCipherSuites As GroupBox
        Private WithEvents _buttonMoveDown As Button
        Private WithEvents _checkBoxTlsOld As CheckBox
        Private WithEvents _buttonMoveUp As Button
        Private WithEvents _listViewCipherSuites As ListView
        Friend WithEvents ImageListCiphers As ImageList
        Private ColumnTls As DataGridViewCheckBoxColumn

        Public Property ServerList() As List(Of DicomAE)
            Get
                'MyServer[] items = new MyServer[dataGridViewServers.Rows.Count];
                Dim items As List(Of DicomAE) = New List(Of DicomAE)(dataGridViewServers.Rows.Count)
                Dim i As Integer = 0
                Do While i < dataGridViewServers.Rows.Count
                    Dim server As DicomAE = New DicomAE()
                    server.AE = dataGridViewServers.Rows(i).Cells("ColumnAE").Value.ToString()
                    server.IPAddress = dataGridViewServers.Rows(i).Cells("ColumnIP").Value.ToString()
                    server.Timeout = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnTimeout").Value)
                    server.Port = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnPort").Value)
                    server.UseTls = Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value)

                    items.Add(server)
                    i += 1
                Loop
                Return items
            End Get

            Set(ByVal value As List(Of DicomAE))
                For Each s As DicomAE In value
                    Dim n As Integer = dataGridViewServers.Rows.Add()
                    dataGridViewServers.Rows(n).Cells("ColumnAE").Value = s.AE
                    dataGridViewServers.Rows(n).Cells("ColumnIP").Value = s.IPAddress
                    dataGridViewServers.Rows(n).Cells("ColumnTimeout").Value = s.Timeout.ToString()
                    dataGridViewServers.Rows(n).Cells("ColumnPort").Value = s.Port.ToString()
                    dataGridViewServers.Rows(n).Cells("ColumnTls").Value = s.UseTls.ToString()
                Next s
            End Set
        End Property

        Public Property Mwl() As String
            Get
                Return _Mwl
            End Get
            Set(ByVal value As String)
                _Mwl = value
            End Set
        End Property

        Public Property Mpps() As String
            Get
                Return _Mpps
            End Get
            Set(ByVal value As String)
                _Mpps = value
            End Set
        End Property

        Public Property Storage() As String
            Get
                Return _Storage
            End Get
            Set(ByVal value As String)
                _Storage = value
            End Set
        End Property


        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
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

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
            Me.buttonOK = New System.Windows.Forms.Button()
            Me.buttonCancel = New System.Windows.Forms.Button()
            Me._labelLogLowLevel = New System.Windows.Forms.Label()
            Me._checkBoxLogLowLevel = New System.Windows.Forms.CheckBox()
            Me._groupBoxClient = New System.Windows.Forms.GroupBox()
            Me._textBoxClientAE = New System.Windows.Forms.TextBox()
            Me._labelClientAE = New System.Windows.Forms.Label()
            Me._groupBoxSecurity = New System.Windows.Forms.GroupBox()
            Me._labelCertificate = New System.Windows.Forms.Label()
            Me._labelHint = New System.Windows.Forms.Label()
            Me._buttonClientCertificate = New System.Windows.Forms.Button()
            Me._textBoxClientCertificate = New System.Windows.Forms.TextBox()
            Me._textBoxKeyPassword = New System.Windows.Forms.TextBox()
            Me._labelPrivateKeyPassword = New System.Windows.Forms.Label()
            Me._labelPrivateKey = New System.Windows.Forms.Label()
            Me._textBoxPrivateKey = New System.Windows.Forms.TextBox()
            Me._buttonPrivateKey = New System.Windows.Forms.Button()
            Me._groupBoxServers = New System.Windows.Forms.GroupBox()
            Me.buttonDeleteServer = New System.Windows.Forms.Button()
            Me.buttonAddServer = New System.Windows.Forms.Button()
            Me.dataGridViewServers = New System.Windows.Forms.DataGridView()
            Me.ColumnAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ColumnIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ColumnPort = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ColumnTimeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ColumnTls = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me._groupMiscellaneous = New System.Windows.Forms.GroupBox()
            Me._checkBoxGroupLengthDataElements = New System.Windows.Forms.CheckBox()
            Me.groupBoxCipherSuites = New System.Windows.Forms.GroupBox()
            Me._buttonMoveDown = New System.Windows.Forms.Button()
            Me._checkBoxTlsOld = New System.Windows.Forms.CheckBox()
            Me._buttonMoveUp = New System.Windows.Forms.Button()
            Me._listViewCipherSuites = New System.Windows.Forms.ListView()
            Me.ImageListCiphers = New System.Windows.Forms.ImageList(Me.components)
            Me._groupBoxClient.SuspendLayout()
            Me._groupBoxSecurity.SuspendLayout()
            Me._groupBoxServers.SuspendLayout()
            CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._groupMiscellaneous.SuspendLayout()
            Me.groupBoxCipherSuites.SuspendLayout()
            Me.SuspendLayout()
            '
            'buttonOK
            '
            Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.buttonOK.Location = New System.Drawing.Point(192, 657)
            Me.buttonOK.Name = "buttonOK"
            Me.buttonOK.Size = New System.Drawing.Size(75, 23)
            Me.buttonOK.TabIndex = 4
            Me.buttonOK.Text = "&OK"
            '
            'buttonCancel
            '
            Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.buttonCancel.Location = New System.Drawing.Point(273, 657)
            Me.buttonCancel.Name = "buttonCancel"
            Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
            Me.buttonCancel.TabIndex = 5
            Me.buttonCancel.Text = "&Cancel"
            '
            '_labelLogLowLevel
            '
            Me._labelLogLowLevel.AutoSize = True
            Me._labelLogLowLevel.ForeColor = System.Drawing.Color.Green
            Me._labelLogLowLevel.Location = New System.Drawing.Point(138, 35)
            Me._labelLogLowLevel.Name = "_labelLogLowLevel"
            Me._labelLogLowLevel.Size = New System.Drawing.Size(189, 13)
            Me._labelLogLowLevel.TabIndex = 2
            Me._labelLogLowLevel.Text = "<== Displayed green in the log window"
            '
            '_checkBoxLogLowLevel
            '
            Me._checkBoxLogLowLevel.AutoSize = True
            Me._checkBoxLogLowLevel.Location = New System.Drawing.Point(15, 33)
            Me._checkBoxLogLowLevel.Name = "_checkBoxLogLowLevel"
            Me._checkBoxLogLowLevel.Size = New System.Drawing.Size(116, 17)
            Me._checkBoxLogLowLevel.TabIndex = 1
            Me._checkBoxLogLowLevel.Text = "Low Level Logging"
            Me._checkBoxLogLowLevel.UseVisualStyleBackColor = True
            '
            '_groupBoxClient
            '
            Me._groupBoxClient.Controls.Add(Me._textBoxClientAE)
            Me._groupBoxClient.Controls.Add(Me._labelClientAE)
            Me._groupBoxClient.Location = New System.Drawing.Point(8, 10)
            Me._groupBoxClient.Name = "_groupBoxClient"
            Me._groupBoxClient.Size = New System.Drawing.Size(536, 50)
            Me._groupBoxClient.TabIndex = 0
            Me._groupBoxClient.TabStop = False
            Me._groupBoxClient.Text = "Client Information"
            '
            '_textBoxClientAE
            '
            Me._textBoxClientAE.Location = New System.Drawing.Point(111, 18)
            Me._textBoxClientAE.Name = "_textBoxClientAE"
            Me._textBoxClientAE.Size = New System.Drawing.Size(417, 20)
            Me._textBoxClientAE.TabIndex = 1
            '
            '_labelClientAE
            '
            Me._labelClientAE.AutoSize = True
            Me._labelClientAE.Location = New System.Drawing.Point(16, 22)
            Me._labelClientAE.Name = "_labelClientAE"
            Me._labelClientAE.Size = New System.Drawing.Size(84, 13)
            Me._labelClientAE.TabIndex = 0
            Me._labelClientAE.Text = "Client AE Name:"
            '
            '_groupBoxSecurity
            '
            Me._groupBoxSecurity.Controls.Add(Me.groupBoxCipherSuites)
            Me._groupBoxSecurity.Controls.Add(Me._labelCertificate)
            Me._groupBoxSecurity.Controls.Add(Me._labelHint)
            Me._groupBoxSecurity.Controls.Add(Me._buttonClientCertificate)
            Me._groupBoxSecurity.Controls.Add(Me._textBoxClientCertificate)
            Me._groupBoxSecurity.Controls.Add(Me._textBoxKeyPassword)
            Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKeyPassword)
            Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKey)
            Me._groupBoxSecurity.Controls.Add(Me._textBoxPrivateKey)
            Me._groupBoxSecurity.Controls.Add(Me._buttonPrivateKey)
            Me._groupBoxSecurity.Location = New System.Drawing.Point(8, 74)
            Me._groupBoxSecurity.Name = "_groupBoxSecurity"
            Me._groupBoxSecurity.Size = New System.Drawing.Size(536, 287)
            Me._groupBoxSecurity.TabIndex = 1
            Me._groupBoxSecurity.TabStop = False
            Me._groupBoxSecurity.Text = "Security"
            '
            '_labelCertificate
            '
            Me._labelCertificate.AutoSize = True
            Me._labelCertificate.Location = New System.Drawing.Point(16, 22)
            Me._labelCertificate.Name = "_labelCertificate"
            Me._labelCertificate.Size = New System.Drawing.Size(57, 13)
            Me._labelCertificate.TabIndex = 0
            Me._labelCertificate.Text = "Certificate:"
            '
            '_labelHint
            '
            Me._labelHint.AutoSize = True
            Me._labelHint.ForeColor = System.Drawing.Color.Blue
            Me._labelHint.Location = New System.Drawing.Point(264, 71)
            Me._labelHint.Name = "_labelHint"
            Me._labelHint.Size = New System.Drawing.Size(140, 13)
            Me._labelHint.TabIndex = 8
            Me._labelHint.Text = "<== Use 'test'  for client.pem"
            '
            '_buttonClientCertificate
            '
            Me._buttonClientCertificate.Image = CType(resources.GetObject("_buttonClientCertificate.Image"), System.Drawing.Image)
            Me._buttonClientCertificate.Location = New System.Drawing.Point(80, 19)
            Me._buttonClientCertificate.Name = "_buttonClientCertificate"
            Me._buttonClientCertificate.Size = New System.Drawing.Size(23, 19)
            Me._buttonClientCertificate.TabIndex = 1
            Me._buttonClientCertificate.UseVisualStyleBackColor = True
            '
            '_textBoxClientCertificate
            '
            Me._textBoxClientCertificate.Location = New System.Drawing.Point(111, 18)
            Me._textBoxClientCertificate.Name = "_textBoxClientCertificate"
            Me._textBoxClientCertificate.Size = New System.Drawing.Size(417, 20)
            Me._textBoxClientCertificate.TabIndex = 2
            '
            '_textBoxKeyPassword
            '
            Me._textBoxKeyPassword.Location = New System.Drawing.Point(111, 67)
            Me._textBoxKeyPassword.Name = "_textBoxKeyPassword"
            Me._textBoxKeyPassword.Size = New System.Drawing.Size(146, 20)
            Me._textBoxKeyPassword.TabIndex = 7
            '
            '_labelPrivateKeyPassword
            '
            Me._labelPrivateKeyPassword.AutoSize = True
            Me._labelPrivateKeyPassword.Location = New System.Drawing.Point(16, 71)
            Me._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword"
            Me._labelPrivateKeyPassword.Size = New System.Drawing.Size(77, 13)
            Me._labelPrivateKeyPassword.TabIndex = 6
            Me._labelPrivateKeyPassword.Text = "Key Password:"
            '
            '_labelPrivateKey
            '
            Me._labelPrivateKey.AutoSize = True
            Me._labelPrivateKey.Location = New System.Drawing.Point(16, 45)
            Me._labelPrivateKey.Name = "_labelPrivateKey"
            Me._labelPrivateKey.Size = New System.Drawing.Size(64, 13)
            Me._labelPrivateKey.TabIndex = 3
            Me._labelPrivateKey.Text = "Private Key:"
            '
            '_textBoxPrivateKey
            '
            Me._textBoxPrivateKey.Location = New System.Drawing.Point(111, 41)
            Me._textBoxPrivateKey.Name = "_textBoxPrivateKey"
            Me._textBoxPrivateKey.Size = New System.Drawing.Size(417, 20)
            Me._textBoxPrivateKey.TabIndex = 5
            '
            '_buttonPrivateKey
            '
            Me._buttonPrivateKey.Image = CType(resources.GetObject("_buttonPrivateKey.Image"), System.Drawing.Image)
            Me._buttonPrivateKey.Location = New System.Drawing.Point(80, 42)
            Me._buttonPrivateKey.Name = "_buttonPrivateKey"
            Me._buttonPrivateKey.Size = New System.Drawing.Size(23, 19)
            Me._buttonPrivateKey.TabIndex = 4
            Me._buttonPrivateKey.UseVisualStyleBackColor = True
            '
            '_groupBoxServers
            '
            Me._groupBoxServers.Controls.Add(Me.buttonDeleteServer)
            Me._groupBoxServers.Controls.Add(Me.buttonAddServer)
            Me._groupBoxServers.Controls.Add(Me.dataGridViewServers)
            Me._groupBoxServers.Location = New System.Drawing.Point(8, 441)
            Me._groupBoxServers.Name = "_groupBoxServers"
            Me._groupBoxServers.Size = New System.Drawing.Size(536, 211)
            Me._groupBoxServers.TabIndex = 3
            Me._groupBoxServers.TabStop = False
            Me._groupBoxServers.Text = "Server Information"
            '
            'buttonDeleteServer
            '
            Me.buttonDeleteServer.CausesValidation = False
            Me.buttonDeleteServer.Image = CType(resources.GetObject("buttonDeleteServer.Image"), System.Drawing.Image)
            Me.buttonDeleteServer.Location = New System.Drawing.Point(48, 17)
            Me.buttonDeleteServer.Name = "buttonDeleteServer"
            Me.buttonDeleteServer.Size = New System.Drawing.Size(40, 39)
            Me.buttonDeleteServer.TabIndex = 1
            Me.buttonDeleteServer.UseVisualStyleBackColor = True
            '
            'buttonAddServer
            '
            Me.buttonAddServer.Image = CType(resources.GetObject("buttonAddServer.Image"), System.Drawing.Image)
            Me.buttonAddServer.Location = New System.Drawing.Point(8, 17)
            Me.buttonAddServer.Name = "buttonAddServer"
            Me.buttonAddServer.Size = New System.Drawing.Size(40, 39)
            Me.buttonAddServer.TabIndex = 0
            Me.buttonAddServer.UseVisualStyleBackColor = True
            '
            'dataGridViewServers
            '
            Me.dataGridViewServers.AllowUserToAddRows = False
            Me.dataGridViewServers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dataGridViewServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataGridViewServers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnAE, Me.ColumnIP, Me.ColumnPort, Me.ColumnTimeout, Me.ColumnTls})
            Me.dataGridViewServers.Location = New System.Drawing.Point(8, 57)
            Me.dataGridViewServers.Name = "dataGridViewServers"
            Me.dataGridViewServers.Size = New System.Drawing.Size(528, 150)
            Me.dataGridViewServers.TabIndex = 2
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
            '_groupMiscellaneous
            '
            Me._groupMiscellaneous.Controls.Add(Me._labelLogLowLevel)
            Me._groupMiscellaneous.Controls.Add(Me._checkBoxLogLowLevel)
            Me._groupMiscellaneous.Controls.Add(Me._checkBoxGroupLengthDataElements)
            Me._groupMiscellaneous.Location = New System.Drawing.Point(8, 379)
            Me._groupMiscellaneous.Name = "_groupMiscellaneous"
            Me._groupMiscellaneous.Size = New System.Drawing.Size(536, 56)
            Me._groupMiscellaneous.TabIndex = 2
            Me._groupMiscellaneous.TabStop = False
            Me._groupMiscellaneous.Text = "Miscellaneous"
            '
            '_checkBoxGroupLengthDataElements
            '
            Me._checkBoxGroupLengthDataElements.AutoSize = True
            Me._checkBoxGroupLengthDataElements.Location = New System.Drawing.Point(15, 14)
            Me._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements"
            Me._checkBoxGroupLengthDataElements.Size = New System.Drawing.Size(201, 17)
            Me._checkBoxGroupLengthDataElements.TabIndex = 0
            Me._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements"
            Me._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = True
            '
            'groupBoxCipherSuites
            '
            Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveDown)
            Me.groupBoxCipherSuites.Controls.Add(Me._checkBoxTlsOld)
            Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveUp)
            Me.groupBoxCipherSuites.Controls.Add(Me._listViewCipherSuites)
            Me.groupBoxCipherSuites.Location = New System.Drawing.Point(0, 97)
            Me.groupBoxCipherSuites.Name = "groupBoxCipherSuites"
            Me.groupBoxCipherSuites.Size = New System.Drawing.Size(536, 190)
            Me.groupBoxCipherSuites.TabIndex = 9
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
            Me._checkBoxTlsOld.TabIndex = 2
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
            Me._listViewCipherSuites.Location = New System.Drawing.Point(111, 16)
            Me._listViewCipherSuites.Name = "_listViewCipherSuites"
            Me._listViewCipherSuites.Size = New System.Drawing.Size(417, 142)
            Me._listViewCipherSuites.TabIndex = 3
            Me._listViewCipherSuites.UseCompatibleStateImageBehavior = False
            '
            'ImageListCiphers
            '
            Me.ImageListCiphers.ImageStream = CType(resources.GetObject("ImageListCiphers.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListCiphers.TransparentColor = System.Drawing.Color.Transparent
            Me.ImageListCiphers.Images.SetKeyName(0, "yellowBullet.png")
            Me.ImageListCiphers.Images.SetKeyName(1, "yellowBullet.png")
            Me.ImageListCiphers.Images.SetKeyName(2, "greenBullet.png")
            '
            'OptionsDialog
            '
            Me.AcceptButton = Me.buttonOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.CancelButton = Me.buttonCancel
            Me.ClientSize = New System.Drawing.Size(560, 686)
            Me.Controls.Add(Me._groupMiscellaneous)
            Me.Controls.Add(Me._groupBoxServers)
            Me.Controls.Add(Me._groupBoxSecurity)
            Me.Controls.Add(Me._groupBoxClient)
            Me.Controls.Add(Me.buttonCancel)
            Me.Controls.Add(Me.buttonOK)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "OptionsDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Options"
            Me._groupBoxClient.ResumeLayout(False)
            Me._groupBoxClient.PerformLayout()
            Me._groupBoxSecurity.ResumeLayout(False)
            Me._groupBoxSecurity.PerformLayout()
            Me._groupBoxServers.ResumeLayout(False)
            CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).EndInit()
            Me._groupMiscellaneous.ResumeLayout(False)
            Me._groupMiscellaneous.PerformLayout()
            Me.groupBoxCipherSuites.ResumeLayout(False)
            Me.groupBoxCipherSuites.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
#End Region

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

        Private Sub ServerIp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Dim bValid As Boolean = Char.IsNumber(e.KeyChar) OrElse (e.KeyChar = "."c) OrElse Char.IsControl(e.KeyChar)
            e.Handled = Not bValid
        End Sub


        Private Sub Port_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
                DialogResult = DialogResult.None
                Return False
            End Try
        End Function

        Private Function CheckIP(ByVal tb As TextBox, ByVal lb As Label) As Boolean
            Try
                System.Net.IPAddress.Parse(tb.Text)
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

        Private Function CheckFileExists(ByVal tb As TextBox, ByVal showMessageBox As Boolean) As Boolean
            Dim ret As Boolean = True
            Dim sMsg As String = String.Empty
            Dim sFile As String = tb.Text.Trim()
            If sFile.Length = 0 Then
                sMsg = "File can not be empty if 'Use Secure TLS Communication' is checked."
                ret = False
            ElseIf (Not File.Exists(sFile)) Then
                sMsg = "File does not exist: " & sFile
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

        ' Return true if any of the servers are using tls
        ' Return false if all of the servers do not use tls
        Private Function IsAnyServerUseTls() As Boolean
            Dim i As Integer = 0
            Do While i < dataGridViewServers.Rows.Count
                If Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value) Then
                    Return True
                End If
                i += 1
            Loop
            Return False
        End Function

        Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOK.Click
            If IsAnyServerUseTls() Then
                If (Not CheckFileExists(_textBoxClientCertificate, True)) Then
                    Return
                End If
                If (Not CheckFileExists(_textBoxPrivateKey, True)) Then
                    Return
                End If
            End If

            _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing)

            ClientAE = _textBoxClientAE.Text
            ClientCertificate = _textBoxClientCertificate.Text
            PrivateKey = _textBoxPrivateKey.Text
            PrivateKeyPassword = _textBoxKeyPassword.Text
            LogLowLevel = _checkBoxLogLowLevel.Checked
            GroupLengthDataElements = _checkBoxGroupLengthDataElements.Checked
        End Sub

        Private Sub EnableDialogItems()
            Dim enable As Boolean = IsAnyServerUseTls()
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

        Private Sub OptionsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            _initializing = True
            _textBoxClientAE.Text = ClientAE
            _textBoxClientCertificate.Text = ClientCertificate
            _textBoxPrivateKey.Text = PrivateKey
            _textBoxKeyPassword.Text = PrivateKeyPassword
            _checkBoxLogLowLevel.Checked = LogLowLevel
            _checkBoxGroupLengthDataElements.Checked = GroupLengthDataElements

            _listViewCipherSuites.InitializeCipherListView(CipherSuites, ImageListCiphers)
            _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites()

            _initializing = False
            EnableDialogItems()
        End Sub

        Private Sub _buttonClientCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonClientCertificate.Click
            Dim openDialog As OpenFileDialog = New OpenFileDialog()
            openDialog.Title = "Select Client Certificate"
            openDialog.FileName = _textBoxClientCertificate.Text
            openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
            Dim result As DialogResult = openDialog.ShowDialog(Me)
            If result = System.Windows.Forms.DialogResult.OK Then
                _textBoxClientCertificate.Text = openDialog.FileName
            End If
        End Sub

        Private Sub _buttonPrivateKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonPrivateKey.Click
            Dim openDialog As OpenFileDialog = New OpenFileDialog()

            openDialog.Title = "Select Private Key File"
            openDialog.FileName = _textBoxClientCertificate.Text
            openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"

            If openDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                _textBoxPrivateKey.Text = openDialog.FileName
            End If
        End Sub

        Private Sub _checkBoxLoggingLowLevel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _checkBoxLogLowLevel.CheckedChanged
            EnableDialogItems()
        End Sub

        Private Function Copy(ByVal scp As Scp) As Scp
            Dim s As Scp = New Scp()

            s.PeerAddress = scp.PeerAddress
            s.Port = scp.Port
            s.Timeout = scp.Timeout
            s.AETitle = scp.AETitle
            Return s
        End Function

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

        Private Sub dataGridViewServers_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dataGridViewServers.CurrentCellDirtyStateChanged
            Dim d As DataGridView = TryCast(sender, DataGridView)
            If d IsNot Nothing Then
                Dim cb As DataGridViewCheckBoxCell = TryCast(d.CurrentCell, DataGridViewCheckBoxCell)
                If cb IsNot Nothing Then
                    If TypeOf cb.Value Is Boolean Then
                        Dim bValue As Boolean = CBool(cb.Value)
                        If bValue Then
                            Dim version As DicomOpenSslVersion = DicomNet.GetOpenSslVersion()
                            If Utils.VerifyOpensslVersion(Me) = False Then
                                cb.Value = False
                                dataGridViewServers.RefreshEdit()
                            End If
                        End If
                    End If
                    d.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
                    EnableDialogItems()
                End If
            End If
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

        Private Sub _buttonMoveUp_Click(sender As Object, e As EventArgs) Handles _buttonMoveUp.Click
            _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up)
        End Sub

        Private Sub _buttonMoveDown_Click(sender As Object, e As EventArgs) Handles _buttonMoveDown.Click
            _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down)
        End Sub

        Public CipherSuites As New CipherSuiteItems()
    End Class
End Namespace
