Imports Microsoft.VisualBasic
Imports System
Namespace Ocr2SharePointDemo
   Public Partial Class SharePointServerSettingsControl
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (Not components Is Nothing) Then
			components.Dispose()
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me._domainTextBox = New System.Windows.Forms.TextBox()
		 Me._proxyGroupBox = New System.Windows.Forms.GroupBox()
		 Me._portTextBox = New System.Windows.Forms.TextBox()
		 Me._hostTextBox = New System.Windows.Forms.TextBox()
		 Me._portLabel = New System.Windows.Forms.Label()
		 Me._hostLabel = New System.Windows.Forms.Label()
		 Me._useProxyCheckBox = New System.Windows.Forms.CheckBox()
		 Me._userNameTextBox = New System.Windows.Forms.TextBox()
		 Me._passwordTextBox = New System.Windows.Forms.TextBox()
		 Me._credentialsGroupBox = New System.Windows.Forms.GroupBox()
		 Me._domainLabel = New System.Windows.Forms.Label()
		 Me._passwordLabel = New System.Windows.Forms.Label()
		 Me._userNameLabel = New System.Windows.Forms.Label()
		 Me._useCredentialsCheckBox = New System.Windows.Forms.CheckBox()
		 Me._urlGroupBox = New System.Windows.Forms.GroupBox()
		 Me._urlExampleLabel = New System.Windows.Forms.Label()
		 Me._urlTextBox = New System.Windows.Forms.TextBox()
		 Me._descriptionLabel = New System.Windows.Forms.Label()
		 Me._connectButton = New System.Windows.Forms.Button()
		 Me._proxyGroupBox.SuspendLayout()
		 Me._credentialsGroupBox.SuspendLayout()
		 Me._urlGroupBox.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _domainTextBox
		 ' 
		 Me._domainTextBox.Location = New System.Drawing.Point(128, 103)
		 Me._domainTextBox.Name = "_domainTextBox"
		 Me._domainTextBox.Size = New System.Drawing.Size(100, 20)
		 Me._domainTextBox.TabIndex = 6
		 ' 
		 ' _proxyGroupBox
		 ' 
		 Me._proxyGroupBox.Controls.Add(Me._portTextBox)
		 Me._proxyGroupBox.Controls.Add(Me._hostTextBox)
		 Me._proxyGroupBox.Controls.Add(Me._portLabel)
		 Me._proxyGroupBox.Controls.Add(Me._hostLabel)
		 Me._proxyGroupBox.Controls.Add(Me._useProxyCheckBox)
		 Me._proxyGroupBox.Location = New System.Drawing.Point(365, 47)
		 Me._proxyGroupBox.Name = "_proxyGroupBox"
		 Me._proxyGroupBox.Size = New System.Drawing.Size(372, 242)
		 Me._proxyGroupBox.TabIndex = 3
		 Me._proxyGroupBox.TabStop = False
		 Me._proxyGroupBox.Text = "Proxy settings"
		 ' 
		 ' _portTextBox
		 ' 
		 Me._portTextBox.Location = New System.Drawing.Point(128, 77)
		 Me._portTextBox.Name = "_portTextBox"
		 Me._portTextBox.Size = New System.Drawing.Size(100, 20)
		 Me._portTextBox.TabIndex = 5
		 ' 
		 ' _hostTextBox
		 ' 
		 Me._hostTextBox.Location = New System.Drawing.Point(128, 51)
		 Me._hostTextBox.Name = "_hostTextBox"
		 Me._hostTextBox.Size = New System.Drawing.Size(202, 20)
		 Me._hostTextBox.TabIndex = 4
		 ' 
		 ' _portLabel
		 ' 
		 Me._portLabel.AutoSize = True
		 Me._portLabel.Location = New System.Drawing.Point(42, 80)
		 Me._portLabel.Name = "_portLabel"
		 Me._portLabel.Size = New System.Drawing.Size(29, 13)
		 Me._portLabel.TabIndex = 2
		 Me._portLabel.Text = "Port:"
		 ' 
		 ' _hostLabel
		 ' 
		 Me._hostLabel.AutoSize = True
		 Me._hostLabel.Location = New System.Drawing.Point(42, 54)
		 Me._hostLabel.Name = "_hostLabel"
		 Me._hostLabel.Size = New System.Drawing.Size(32, 13)
		 Me._hostLabel.TabIndex = 1
		 Me._hostLabel.Text = "Host:"
		 ' 
		 ' _useProxyCheckBox
		 ' 
		 Me._useProxyCheckBox.AutoSize = True
		 Me._useProxyCheckBox.Location = New System.Drawing.Point(22, 28)
		 Me._useProxyCheckBox.Name = "_useProxyCheckBox"
		 Me._useProxyCheckBox.Size = New System.Drawing.Size(321, 17)
		 Me._useProxyCheckBox.TabIndex = 0
		 Me._useProxyCheckBox.Text = "Use the following proxy settings when connecting to the server"
		 Me._useProxyCheckBox.UseVisualStyleBackColor = True
'		 Me._useProxyCheckBox.CheckedChanged += New System.EventHandler(Me._useProxyCheckBox_CheckedChanged);
		 ' 
		 ' _userNameTextBox
		 ' 
		 Me._userNameTextBox.Location = New System.Drawing.Point(128, 51)
		 Me._userNameTextBox.Name = "_userNameTextBox"
		 Me._userNameTextBox.Size = New System.Drawing.Size(100, 20)
		 Me._userNameTextBox.TabIndex = 2
		 ' 
		 ' _passwordTextBox
		 ' 
		 Me._passwordTextBox.Location = New System.Drawing.Point(128, 77)
		 Me._passwordTextBox.Name = "_passwordTextBox"
		 Me._passwordTextBox.PasswordChar = "*"c
		 Me._passwordTextBox.Size = New System.Drawing.Size(100, 20)
		 Me._passwordTextBox.TabIndex = 4
		 ' 
		 ' _credentialsGroupBox
		 ' 
		 Me._credentialsGroupBox.Controls.Add(Me._domainTextBox)
		 Me._credentialsGroupBox.Controls.Add(Me._passwordTextBox)
		 Me._credentialsGroupBox.Controls.Add(Me._userNameTextBox)
		 Me._credentialsGroupBox.Controls.Add(Me._domainLabel)
		 Me._credentialsGroupBox.Controls.Add(Me._passwordLabel)
		 Me._credentialsGroupBox.Controls.Add(Me._userNameLabel)
		 Me._credentialsGroupBox.Controls.Add(Me._useCredentialsCheckBox)
		 Me._credentialsGroupBox.Location = New System.Drawing.Point(6, 148)
		 Me._credentialsGroupBox.Name = "_credentialsGroupBox"
		 Me._credentialsGroupBox.Size = New System.Drawing.Size(353, 141)
		 Me._credentialsGroupBox.TabIndex = 2
		 Me._credentialsGroupBox.TabStop = False
		 Me._credentialsGroupBox.Text = "Network credentials to use when connecting to the server:"
		 ' 
		 ' _domainLabel
		 ' 
		 Me._domainLabel.AutoSize = True
		 Me._domainLabel.Location = New System.Drawing.Point(42, 106)
		 Me._domainLabel.Name = "_domainLabel"
		 Me._domainLabel.Size = New System.Drawing.Size(46, 13)
		 Me._domainLabel.TabIndex = 5
		 Me._domainLabel.Text = "Domain:"
		 ' 
		 ' _passwordLabel
		 ' 
		 Me._passwordLabel.AutoSize = True
		 Me._passwordLabel.Location = New System.Drawing.Point(42, 80)
		 Me._passwordLabel.Name = "_passwordLabel"
		 Me._passwordLabel.Size = New System.Drawing.Size(56, 13)
		 Me._passwordLabel.TabIndex = 3
		 Me._passwordLabel.Text = "Password:"
		 ' 
		 ' _userNameLabel
		 ' 
		 Me._userNameLabel.AutoSize = True
		 Me._userNameLabel.Location = New System.Drawing.Point(42, 54)
		 Me._userNameLabel.Name = "_userNameLabel"
		 Me._userNameLabel.Size = New System.Drawing.Size(58, 13)
		 Me._userNameLabel.TabIndex = 1
		 Me._userNameLabel.Text = "Username:"
		 ' 
		 ' _useCredentialsCheckBox
		 ' 
		 Me._useCredentialsCheckBox.AutoSize = True
		 Me._useCredentialsCheckBox.Location = New System.Drawing.Point(22, 28)
		 Me._useCredentialsCheckBox.Name = "_useCredentialsCheckBox"
		 Me._useCredentialsCheckBox.Size = New System.Drawing.Size(308, 17)
		 Me._useCredentialsCheckBox.TabIndex = 0
		 Me._useCredentialsCheckBox.Text = "Use the following credentials when connecting to the server"
		 Me._useCredentialsCheckBox.UseVisualStyleBackColor = True
'		 Me._useCredentialsCheckBox.CheckedChanged += New System.EventHandler(Me._useCredentialsCheckBox_CheckedChanged);
		 ' 
		 ' _urlGroupBox
		 ' 
		 Me._urlGroupBox.Controls.Add(Me._urlExampleLabel)
		 Me._urlGroupBox.Controls.Add(Me._urlTextBox)
		 Me._urlGroupBox.Location = New System.Drawing.Point(6, 47)
		 Me._urlGroupBox.Name = "_urlGroupBox"
		 Me._urlGroupBox.Size = New System.Drawing.Size(353, 79)
		 Me._urlGroupBox.TabIndex = 1
		 Me._urlGroupBox.TabStop = False
		 Me._urlGroupBox.Text = "SharePoint server address (Root only):"
		 ' 
		 ' _urlExampleLabel
		 ' 
		 Me._urlExampleLabel.AutoSize = True
		 Me._urlExampleLabel.Location = New System.Drawing.Point(132, 53)
		 Me._urlExampleLabel.Name = "_urlExampleLabel"
		 Me._urlExampleLabel.Size = New System.Drawing.Size(177, 13)
		 Me._urlExampleLabel.TabIndex = 1
		 Me._urlExampleLabel.Text = "For example: http://myserver/mysite"
		 Me._urlExampleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		 ' 
		 ' _urlTextBox
		 ' 
		 Me._urlTextBox.Location = New System.Drawing.Point(22, 30)
		 Me._urlTextBox.Name = "_urlTextBox"
		 Me._urlTextBox.Size = New System.Drawing.Size(308, 20)
		 Me._urlTextBox.TabIndex = 0
'		 Me._urlTextBox.TextChanged += New System.EventHandler(Me._urlTextBox_TextChanged);
		 ' 
		 ' _descriptionLabel
		 ' 
		 Me._descriptionLabel.AutoSize = True
		 Me._descriptionLabel.Location = New System.Drawing.Point(3, 15)
		 Me._descriptionLabel.Name = "_descriptionLabel"
		 Me._descriptionLabel.Size = New System.Drawing.Size(584, 13)
		 Me._descriptionLabel.TabIndex = 0
         Me._descriptionLabel.Text = "Enter the SharePoint server properties and click 'Connect'. Only SharePoint " & "2010 and later is supported by this demo."
		 ' 
		 ' _connectButton
		 ' 
		 Me._connectButton.Location = New System.Drawing.Point(6, 296)
		 Me._connectButton.Name = "_connectButton"
		 Me._connectButton.Size = New System.Drawing.Size(75, 23)
		 Me._connectButton.TabIndex = 4
		 Me._connectButton.Text = "&Connect"
		 Me._connectButton.UseVisualStyleBackColor = True
'		 Me._connectButton.Click += New System.EventHandler(Me._connectButton_Click);
		 ' 
		 ' SharePointServerSettingsControl
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me._connectButton)
		 Me.Controls.Add(Me._proxyGroupBox)
		 Me.Controls.Add(Me._credentialsGroupBox)
		 Me.Controls.Add(Me._urlGroupBox)
		 Me.Controls.Add(Me._descriptionLabel)
		 Me.Name = "SharePointServerSettingsControl"
		 Me.Size = New System.Drawing.Size(740, 330)
		 Me._proxyGroupBox.ResumeLayout(False)
		 Me._proxyGroupBox.PerformLayout()
		 Me._credentialsGroupBox.ResumeLayout(False)
		 Me._credentialsGroupBox.PerformLayout()
		 Me._urlGroupBox.ResumeLayout(False)
		 Me._urlGroupBox.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _domainTextBox As System.Windows.Forms.TextBox
	  Private _proxyGroupBox As System.Windows.Forms.GroupBox
	  Private _portTextBox As System.Windows.Forms.TextBox
	  Private _hostTextBox As System.Windows.Forms.TextBox
	  Private _portLabel As System.Windows.Forms.Label
	  Private _hostLabel As System.Windows.Forms.Label
	  Private WithEvents _useProxyCheckBox As System.Windows.Forms.CheckBox
	  Private _userNameTextBox As System.Windows.Forms.TextBox
	  Private _passwordTextBox As System.Windows.Forms.TextBox
	  Private _credentialsGroupBox As System.Windows.Forms.GroupBox
	  Private _domainLabel As System.Windows.Forms.Label
	  Private _passwordLabel As System.Windows.Forms.Label
	  Private _userNameLabel As System.Windows.Forms.Label
	  Private WithEvents _useCredentialsCheckBox As System.Windows.Forms.CheckBox
	  Private _urlGroupBox As System.Windows.Forms.GroupBox
	  Private _urlExampleLabel As System.Windows.Forms.Label
	  Private WithEvents _urlTextBox As System.Windows.Forms.TextBox
	  Private _descriptionLabel As System.Windows.Forms.Label
	  Private WithEvents _connectButton As System.Windows.Forms.Button
   End Class
End Namespace
