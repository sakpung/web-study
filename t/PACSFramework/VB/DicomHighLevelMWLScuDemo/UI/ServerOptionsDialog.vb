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

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for OptionsDialog.
   ''' </summary>
   Public Class ServerOptionsDialog : Inherits System.Windows.Forms.Form
	  Private _groupBoxServer As System.Windows.Forms.GroupBox
	  Private _labelServerAE As System.Windows.Forms.Label
	  Private _labelServerIP As System.Windows.Forms.Label
	  Private _labelServerPort As System.Windows.Forms.Label
	  Public _textBoxServerAE As System.Windows.Forms.TextBox
	  Public WithEvents _textBoxServerPort As System.Windows.Forms.TextBox
	  Public WithEvents _textBoxServerIP As System.Windows.Forms.TextBox
	  Private WithEvents buttonOK As System.Windows.Forms.Button
	  Private buttonCancel As System.Windows.Forms.Button
	  ''' <summary>
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.Container = Nothing


	  Private _serverAE As String
	  Private _serverIP As String
	  Private _serverPort As Integer
	  Private _clientAE As String
	  Private _clientPort As Integer

	  Public Property ClientPort() As Integer
		 Get
			 Return _clientPort
		 End Get
		 Set
			 _clientPort = Value
		 End Set
	  End Property
	  Private _timeout As Integer
	  Private _useTls As Boolean
	  Private _clientCertificate As String
	  Private _privateKey As String
	  Private _privateKeyPassword As String
	  Public _textBoxTimeout As TextBox
	  Private _labelTimeout As Label
	  Private _logLowLevel As Boolean


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
	  Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServerOptionsDialog))
		  Me._groupBoxServer = New System.Windows.Forms.GroupBox()
		  Me._textBoxServerIP = New System.Windows.Forms.TextBox()
		  Me._textBoxServerPort = New System.Windows.Forms.TextBox()
		  Me._textBoxServerAE = New System.Windows.Forms.TextBox()
		  Me._labelServerPort = New System.Windows.Forms.Label()
		  Me._labelServerIP = New System.Windows.Forms.Label()
		  Me._labelServerAE = New System.Windows.Forms.Label()
		  Me.buttonOK = New System.Windows.Forms.Button()
		  Me.buttonCancel = New System.Windows.Forms.Button()
		  Me._textBoxTimeout = New System.Windows.Forms.TextBox()
		  Me._labelTimeout = New System.Windows.Forms.Label()
		  Me._groupBoxServer.SuspendLayout()
		  Me.SuspendLayout()
		  ' 
		  ' _groupBoxServer
		  ' 
		  Me._groupBoxServer.Controls.Add(Me._textBoxTimeout)
		  Me._groupBoxServer.Controls.Add(Me._labelTimeout)
		  Me._groupBoxServer.Controls.Add(Me._textBoxServerIP)
		  Me._groupBoxServer.Controls.Add(Me._textBoxServerPort)
		  Me._groupBoxServer.Controls.Add(Me._textBoxServerAE)
		  Me._groupBoxServer.Controls.Add(Me._labelServerPort)
		  Me._groupBoxServer.Controls.Add(Me._labelServerIP)
		  Me._groupBoxServer.Controls.Add(Me._labelServerAE)
		  Me._groupBoxServer.Location = New System.Drawing.Point(8, 8)
		  Me._groupBoxServer.Name = "_groupBoxServer"
		  Me._groupBoxServer.Size = New System.Drawing.Size(418, 138)
		  Me._groupBoxServer.TabIndex = 0
		  Me._groupBoxServer.TabStop = False
		  Me._groupBoxServer.Text = "Server (SCP AE) Information"
		  ' 
		  ' _textBoxServerIP
		  ' 
		  Me._textBoxServerIP.Location = New System.Drawing.Point(111, 48)
		  Me._textBoxServerIP.MaxLength = 15
		  Me._textBoxServerIP.Name = "_textBoxServerIP"
		  Me._textBoxServerIP.Size = New System.Drawing.Size(301, 20)
		  Me._textBoxServerIP.TabIndex = 3
'		  Me._textBoxServerIP.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ServerIp_KeyPress);
		  ' 
		  ' _textBoxServerPort
		  ' 
		  Me._textBoxServerPort.Location = New System.Drawing.Point(111, 76)
		  Me._textBoxServerPort.Name = "_textBoxServerPort"
		  Me._textBoxServerPort.Size = New System.Drawing.Size(301, 20)
		  Me._textBoxServerPort.TabIndex = 5
'		  Me._textBoxServerPort.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.Port_KeyPress);
		  ' 
		  ' _textBoxServerAE
		  ' 
		  Me._textBoxServerAE.Location = New System.Drawing.Point(111, 20)
		  Me._textBoxServerAE.Name = "_textBoxServerAE"
		  Me._textBoxServerAE.Size = New System.Drawing.Size(301, 20)
		  Me._textBoxServerAE.TabIndex = 1
		  ' 
		  ' _labelServerPort
		  ' 
		  Me._labelServerPort.AutoSize = True
		  Me._labelServerPort.Location = New System.Drawing.Point(16, 80)
		  Me._labelServerPort.Name = "_labelServerPort"
		  Me._labelServerPort.Size = New System.Drawing.Size(83, 13)
		  Me._labelServerPort.TabIndex = 4
		  Me._labelServerPort.Text = "Server Port No.:"
		  ' 
		  ' _labelServerIP
		  ' 
		  Me._labelServerIP.AutoSize = True
		  Me._labelServerIP.Location = New System.Drawing.Point(16, 52)
		  Me._labelServerIP.Name = "_labelServerIP"
		  Me._labelServerIP.Size = New System.Drawing.Size(95, 13)
		  Me._labelServerIP.TabIndex = 2
		  Me._labelServerIP.Text = "Server IP Address:"
		  ' 
		  ' _labelServerAE
		  ' 
		  Me._labelServerAE.AutoSize = True
		  Me._labelServerAE.Location = New System.Drawing.Point(16, 24)
		  Me._labelServerAE.Name = "_labelServerAE"
		  Me._labelServerAE.Size = New System.Drawing.Size(89, 13)
		  Me._labelServerAE.TabIndex = 0
		  Me._labelServerAE.Text = "Server AE Name:"
		  ' 
		  ' buttonOK
		  ' 
		  Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
		  Me.buttonOK.Location = New System.Drawing.Point(139, 166)
		  Me.buttonOK.Name = "buttonOK"
		  Me.buttonOK.Size = New System.Drawing.Size(75, 23)
		  Me.buttonOK.TabIndex = 2
		  Me.buttonOK.Text = "&OK"
'		  Me.buttonOK.Click += New System.EventHandler(Me.buttonOK_Click);
		  ' 
		  ' buttonCancel
		  ' 
		  Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me.buttonCancel.Location = New System.Drawing.Point(224, 166)
		  Me.buttonCancel.Name = "buttonCancel"
		  Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
		  Me.buttonCancel.TabIndex = 3
		  Me.buttonCancel.Text = "&Cancel"
		  ' 
		  ' _textBoxTimeout
		  ' 
		  Me._textBoxTimeout.Location = New System.Drawing.Point(111, 102)
		  Me._textBoxTimeout.Name = "_textBoxTimeout"
		  Me._textBoxTimeout.Size = New System.Drawing.Size(301, 20)
		  Me._textBoxTimeout.TabIndex = 7
		  ' 
		  ' _labelTimeout
		  ' 
		  Me._labelTimeout.AutoSize = True
		  Me._labelTimeout.Location = New System.Drawing.Point(16, 106)
		  Me._labelTimeout.Name = "_labelTimeout"
		  Me._labelTimeout.Size = New System.Drawing.Size(74, 13)
		  Me._labelTimeout.TabIndex = 6
		  Me._labelTimeout.Text = "Timeout (sec):"
		  ' 
		  ' ServerOptionsDialog
		  ' 
		  Me.AcceptButton = Me.buttonOK
		  Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		  Me.CancelButton = Me.buttonCancel
		  Me.ClientSize = New System.Drawing.Size(438, 204)
		  Me.Controls.Add(Me.buttonCancel)
		  Me.Controls.Add(Me.buttonOK)
		  Me.Controls.Add(Me._groupBoxServer)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.Name = "ServerOptionsDialog"
		  Me.ShowInTaskbar = False
		  Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		  Me.Text = "Options"
'		  Me.Load += New System.EventHandler(Me.OptionsDialog_Load);
		  Me._groupBoxServer.ResumeLayout(False)
		  Me._groupBoxServer.PerformLayout()
		  Me.ResumeLayout(False)

	  End Sub
	  #End Region

	  Public Property LogLowLevel() As Boolean
		 Get
			 Return _logLowLevel
		 End Get
		 Set
			 _logLowLevel = Value
		 End Set
	  End Property

	  Public Property PrivateKeyPassword() As String
		 Get
			 Return _privateKeyPassword
		 End Get
		 Set
			 _privateKeyPassword = Value
		 End Set
	  End Property

	  Public Property PrivateKey() As String
		 Get
			 Return _privateKey
		 End Get
		 Set
			 _privateKey = Value
		 End Set
	  End Property

	  Public Property ClientCertificate() As String
		 Get
			 Return _clientCertificate
		 End Get
		 Set
			 _clientCertificate = Value
		 End Set
	  End Property

	  Public Property UseTls() As Boolean
		 Get
			 Return _useTls
		 End Get
		 Set
			 _useTls = Value
		 End Set
	  End Property

	  Public Property ServerAE() As String
		 Get
			 Return _serverAE
		 End Get
		 Set
			 _serverAE = Value
		 End Set
	  End Property

	  Public Property ServerIP() As String
		 Get
			 Return _serverIP
		 End Get
		 Set
			 _serverIP = Value
		 End Set
	  End Property

	  Public Property ServerPort() As Integer
		 Get
			 Return _serverPort
		 End Get
		 Set
			 _serverPort = Value
		 End Set
	  End Property

	  Public Property ClientAE() As String
		 Get
			 Return _clientAE
		 End Get
		 Set
			 _clientAE = Value
		 End Set
	  End Property

	  Public Property Timeout() As Integer
		 Get
			 Return _timeout
		 End Get
		 Set
			 _timeout = Value
		 End Set
	  End Property


	  Private Sub ServerIp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _textBoxServerIP.KeyPress
		 Dim bValid As Boolean = Char.IsNumber(e.KeyChar) OrElse (e.KeyChar = "."c) OrElse Char.IsControl(e.KeyChar)
		 e.Handled = Not bValid
	  End Sub


	  Private Sub Port_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _textBoxServerPort.KeyPress
		 If Not(Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
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

	  Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOK.Click
		 If (Not CheckIP(_textBoxServerIP, _labelServerIP)) Then
			Return
		 End If
		 If (Not CheckInteger(_textBoxServerPort, _labelServerPort)) Then
			Return
		 End If
		 If (Not CheckInteger(_textBoxTimeout, _labelTimeout)) Then
			Return
		 End If

		 ServerAE = _textBoxServerAE.Text
		 ServerIP = _textBoxServerIP.Text
		 ServerPort = Convert.ToInt32(_textBoxServerPort.Text)
		 Timeout = Convert.ToInt32(_textBoxTimeout.Text)
	  End Sub

	  Private Sub OptionsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		 _textBoxServerAE.Text = ServerAE
		 _textBoxServerIP.Text = ServerIP
		 _textBoxServerPort.Text = ServerPort.ToString()
		 _textBoxTimeout.Text = Timeout.ToString()
	  End Sub
   End Class
End Namespace
