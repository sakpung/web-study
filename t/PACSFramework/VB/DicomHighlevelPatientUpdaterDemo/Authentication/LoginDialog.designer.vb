Namespace DicomDemo.Authentication
   Partial Friend Class LoginDialog
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
         Me.pictureBox1 = New System.Windows.Forms.PictureBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.textBoxUserName = New System.Windows.Forms.TextBox()
         Me.textBoxPassword = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.button1 = New System.Windows.Forms.Button()
         Me.buttonLogin = New System.Windows.Forms.Button()
         CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' pictureBox1
         ' 
         Me.pictureBox1.Image = (CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image))
         Me.pictureBox1.Location = New System.Drawing.Point(13, 13)
         Me.pictureBox1.Name = "pictureBox1"
         Me.pictureBox1.Size = New System.Drawing.Size(105, 141)
         Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
         Me.pictureBox1.TabIndex = 0
         Me.pictureBox1.TabStop = False
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(125, 40)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(58, 13)
         Me.label1.TabIndex = 1
         Me.label1.Text = "Username:"
         ' 
         ' textBoxUserName
         ' 
         Me.textBoxUserName.Location = New System.Drawing.Point(128, 57)
         Me.textBoxUserName.Name = "textBoxUserName"
         Me.textBoxUserName.Size = New System.Drawing.Size(226, 20)
         Me.textBoxUserName.TabIndex = 2
         ' 
         ' textBoxPassword
         ' 
         Me.textBoxPassword.Location = New System.Drawing.Point(128, 97)
         Me.textBoxPassword.Name = "textBoxPassword"
         Me.textBoxPassword.Size = New System.Drawing.Size(226, 20)
         Me.textBoxPassword.TabIndex = 4
         Me.textBoxPassword.UseSystemPasswordChar = True
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(125, 80)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(56, 13)
         Me.label2.TabIndex = 3
         Me.label2.Text = "Password:"
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button1.Location = New System.Drawing.Point(278, 134)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 5
         Me.button1.Text = "Cancel"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' buttonLogin
         ' 
         Me.buttonLogin.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonLogin.Enabled = False
         Me.buttonLogin.Location = New System.Drawing.Point(197, 134)
         Me.buttonLogin.Name = "buttonLogin"
         Me.buttonLogin.Size = New System.Drawing.Size(75, 23)
         Me.buttonLogin.TabIndex = 6
         Me.buttonLogin.Text = "Login"
         Me.buttonLogin.UseVisualStyleBackColor = True
         ' 
         ' LoginDialog
         ' 
         Me.AcceptButton = Me.buttonLogin
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(380, 169)
         Me.Controls.Add(Me.buttonLogin)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.textBoxPassword)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.textBoxUserName)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.pictureBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "LoginDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Login"
         CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private pictureBox1 As System.Windows.Forms.PictureBox
      Private label1 As System.Windows.Forms.Label
      Private WithEvents textBoxUserName As System.Windows.Forms.TextBox
      Private WithEvents textBoxPassword As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private button1 As System.Windows.Forms.Button
      Private WithEvents buttonLogin As System.Windows.Forms.Button
   End Class
End Namespace