Imports Microsoft.VisualBasic
Imports System
Namespace CCOWClientParticipationDemo.UI
	Public Partial Class LoginDialog
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginDialog))
			Me.textBoxPassword = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.button2 = New System.Windows.Forms.Button()
			Me.buttonOK = New System.Windows.Forms.Button()
			Me.comboBoxUsername = New System.Windows.Forms.ComboBox()
			Me.panel1 = New Leadtools.Demos.LoginHeaderPanel()
			Me.labelAppName = New System.Windows.Forms.Label()
			Me.labelFirstLogin = New System.Windows.Forms.Label()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' textBoxPassword
			' 
			Me.textBoxPassword.Location = New System.Drawing.Point(102, 168)
			Me.textBoxPassword.Name = "textBoxPassword"
			Me.textBoxPassword.ReadOnly = True
			Me.textBoxPassword.Size = New System.Drawing.Size(209, 20)
			Me.textBoxPassword.TabIndex = 1
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(20, 176)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 13)
			Me.label2.TabIndex = 12
			Me.label2.Text = "Password:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(20, 135)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(61, 13)
			Me.label1.TabIndex = 9
			Me.label1.Text = "User name:"
			' 
			' button2
			' 
			Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.button2.Location = New System.Drawing.Point(236, 204)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(75, 23)
			Me.button2.TabIndex = 3
			Me.button2.Text = "Cancel"
			Me.button2.UseVisualStyleBackColor = True
			' 
			' buttonOK
			' 
			Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.buttonOK.Location = New System.Drawing.Point(155, 204)
			Me.buttonOK.Name = "buttonOK"
			Me.buttonOK.Size = New System.Drawing.Size(75, 23)
			Me.buttonOK.TabIndex = 2
			Me.buttonOK.Text = "OK"
			Me.buttonOK.UseVisualStyleBackColor = True
			' 
			' comboBoxUsername
			' 
			Me.comboBoxUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.comboBoxUsername.FormattingEnabled = True
			Me.comboBoxUsername.Location = New System.Drawing.Point(102, 127)
			Me.comboBoxUsername.Name = "comboBoxUsername"
			Me.comboBoxUsername.Size = New System.Drawing.Size(209, 21)
			Me.comboBoxUsername.TabIndex = 0
'			Me.comboBoxUsername.SelectedIndexChanged += New System.EventHandler(Me.comboBoxUsername_SelectedIndexChanged);
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.labelAppName)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(323, 51)
			Me.panel1.TabIndex = 13
			' 
			' labelAppName
			' 
			Me.labelAppName.BackColor = System.Drawing.Color.Transparent
			Me.labelAppName.Dock = System.Windows.Forms.DockStyle.Fill
			Me.labelAppName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.labelAppName.ForeColor = System.Drawing.SystemColors.Control
			Me.labelAppName.Location = New System.Drawing.Point(0, 0)
			Me.labelAppName.Name = "labelAppName"
			Me.labelAppName.Size = New System.Drawing.Size(323, 51)
			Me.labelAppName.TabIndex = 0
			Me.labelAppName.Text = "This is an application specific login dialog.  The user should use the applicatio" & "n specific logon name."
			Me.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' labelFirstLogin
			' 
			Me.labelFirstLogin.ForeColor = System.Drawing.Color.Red
			Me.labelFirstLogin.Location = New System.Drawing.Point(4, 55)
			Me.labelFirstLogin.Name = "labelFirstLogin"
			Me.labelFirstLogin.Size = New System.Drawing.Size(319, 69)
			Me.labelFirstLogin.TabIndex = 14
			Me.labelFirstLogin.Text = resources.GetString("labelFirstLogin.Text")
			Me.labelFirstLogin.Visible = False
			' 
			' LoginDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(323, 237)
			Me.Controls.Add(Me.labelFirstLogin)
			Me.Controls.Add(Me.comboBoxUsername)
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.textBoxPassword)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.buttonOK)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "LoginDialog"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Login To CCOW Desktop"
'			Me.Load += New System.EventHandler(Me.LoginDialog_Load);
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.LoginDialog_FormClosing);
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private panel1 As Leadtools.Demos.LoginHeaderPanel
		Private labelAppName As System.Windows.Forms.Label
		Private textBoxPassword As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private button2 As System.Windows.Forms.Button
		Private buttonOK As System.Windows.Forms.Button
		Private WithEvents comboBoxUsername As System.Windows.Forms.ComboBox
		Private labelFirstLogin As System.Windows.Forms.Label



	End Class
End Namespace