Imports Microsoft.VisualBasic
Imports System
Namespace CCOWAuthenticationDemo
	Public Partial Class MainForm
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.labelAppName = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.labelCurrentUser = New System.Windows.Forms.Label()
			Me.labelFullName = New System.Windows.Forms.Label()
			Me.buttonLogon = New System.Windows.Forms.Button()
			Me.buttonAbout = New System.Windows.Forms.Button()
			Me.loginHeaderPanel1 = New Leadtools.Demos.LoginHeaderPanel()
			Me.label5 = New System.Windows.Forms.Label()
			Me.pictureBoxCcowStatus = New System.Windows.Forms.PictureBox()
			Me.loginHeaderPanel1.SuspendLayout()
			CType(Me.pictureBoxCcowStatus, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' labelAppName
			' 
			Me.labelAppName.BackColor = System.Drawing.Color.Transparent
			Me.labelAppName.Dock = System.Windows.Forms.DockStyle.Fill
			Me.labelAppName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.labelAppName.ForeColor = System.Drawing.SystemColors.Control
			Me.labelAppName.Location = New System.Drawing.Point(0, 0)
			Me.labelAppName.Name = "labelAppName"
			Me.labelAppName.Size = New System.Drawing.Size(428, 168)
			Me.labelAppName.TabIndex = 21
			Me.labelAppName.Text = "ClientDemo"
			Me.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' label1
			' 
			Me.label1.BackColor = System.Drawing.Color.Transparent
			Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label1.ForeColor = System.Drawing.SystemColors.Control
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(428, 168)
			Me.label1.TabIndex = 22
			Me.label1.Text = "ClientDemo"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' label2
			' 
			Me.label2.BackColor = System.Drawing.Color.Transparent
			Me.label2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label2.ForeColor = System.Drawing.SystemColors.Control
			Me.label2.Location = New System.Drawing.Point(0, 0)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(428, 168)
			Me.label2.TabIndex = 23
			Me.label2.Text = "ClientDemo"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label3.Location = New System.Drawing.Point(1, 55)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(82, 13)
			Me.label3.TabIndex = 25
			Me.label3.Text = "Current User:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label4.Location = New System.Drawing.Point(1, 82)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(67, 13)
			Me.label4.TabIndex = 26
			Me.label4.Text = "Full Name:"
			' 
			' labelCurrentUser
			' 
			Me.labelCurrentUser.AutoSize = True
			Me.labelCurrentUser.Location = New System.Drawing.Point(89, 55)
			Me.labelCurrentUser.Name = "labelCurrentUser"
			Me.labelCurrentUser.Size = New System.Drawing.Size(69, 13)
			Me.labelCurrentUser.TabIndex = 27
			Me.labelCurrentUser.Text = "Current User:"
			' 
			' labelFullName
			' 
			Me.labelFullName.AutoSize = True
			Me.labelFullName.Location = New System.Drawing.Point(89, 82)
			Me.labelFullName.Name = "labelFullName"
			Me.labelFullName.Size = New System.Drawing.Size(69, 13)
			Me.labelFullName.TabIndex = 28
			Me.labelFullName.Text = "Current User:"
			' 
			' buttonLogon
			' 
			Me.buttonLogon.Location = New System.Drawing.Point(338, 129)
			Me.buttonLogon.Name = "buttonLogon"
			Me.buttonLogon.Size = New System.Drawing.Size(75, 23)
			Me.buttonLogon.TabIndex = 29
			Me.buttonLogon.Text = "Logon"
			Me.buttonLogon.UseVisualStyleBackColor = True
'			Me.buttonLogon.Click += New System.EventHandler(Me.buttonLogon_Click);
			' 
			' buttonAbout
			' 
			Me.buttonAbout.Location = New System.Drawing.Point(4, 129)
			Me.buttonAbout.Name = "buttonAbout"
			Me.buttonAbout.Size = New System.Drawing.Size(75, 23)
			Me.buttonAbout.TabIndex = 30
			Me.buttonAbout.Text = "About"
			Me.buttonAbout.UseVisualStyleBackColor = True
'			Me.buttonAbout.Click += New System.EventHandler(Me.buttonAbout_Click);
			' 
			' loginHeaderPanel1
			' 
			Me.loginHeaderPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
			Me.loginHeaderPanel1.Controls.Add(Me.label5)
			Me.loginHeaderPanel1.Controls.Add(Me.pictureBoxCcowStatus)
			Me.loginHeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.loginHeaderPanel1.Location = New System.Drawing.Point(0, 0)
			Me.loginHeaderPanel1.Name = "loginHeaderPanel1"
			Me.loginHeaderPanel1.Size = New System.Drawing.Size(428, 42)
			Me.loginHeaderPanel1.TabIndex = 24
			' 
			' label5
			' 
			Me.label5.BackColor = System.Drawing.Color.Transparent
			Me.label5.Dock = System.Windows.Forms.DockStyle.Left
			Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (CByte(0)))
			Me.label5.ForeColor = System.Drawing.SystemColors.Window
			Me.label5.Location = New System.Drawing.Point(0, 0)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(186, 42)
			Me.label5.TabIndex = 1
			Me.label5.Text = "CCOW Single Sign On"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' pictureBoxCcowStatus
			' 
			Me.pictureBoxCcowStatus.BackColor = System.Drawing.Color.Transparent
			Me.pictureBoxCcowStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pictureBoxCcowStatus.Dock = System.Windows.Forms.DockStyle.Right
            Me.pictureBoxCcowStatus.Image = My.Resources.Broken
			Me.pictureBoxCcowStatus.Location = New System.Drawing.Point(378, 0)
			Me.pictureBoxCcowStatus.Name = "pictureBoxCcowStatus"
			Me.pictureBoxCcowStatus.Size = New System.Drawing.Size(50, 42)
			Me.pictureBoxCcowStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pictureBoxCcowStatus.TabIndex = 0
			Me.pictureBoxCcowStatus.TabStop = False
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(428, 168)
			Me.Controls.Add(Me.buttonAbout)
			Me.Controls.Add(Me.buttonLogon)
			Me.Controls.Add(Me.labelFullName)
			Me.Controls.Add(Me.labelCurrentUser)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.loginHeaderPanel1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.labelAppName)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "MainForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "MainForm"
'			Me.Load += New System.EventHandler(Me.MainForm_Load);
'			Me.Shown += New System.EventHandler(Me.MainForm_Shown);
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.MainForm_FormClosing);
			Me.loginHeaderPanel1.ResumeLayout(False)
			CType(Me.pictureBoxCcowStatus, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private labelAppName As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private loginHeaderPanel1 As Leadtools.Demos.LoginHeaderPanel
		Private pictureBoxCcowStatus As System.Windows.Forms.PictureBox
		Private label5 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private labelCurrentUser As System.Windows.Forms.Label
		Private labelFullName As System.Windows.Forms.Label
		Private WithEvents buttonLogon As System.Windows.Forms.Button
		Private WithEvents buttonAbout As System.Windows.Forms.Button
	End Class
End Namespace