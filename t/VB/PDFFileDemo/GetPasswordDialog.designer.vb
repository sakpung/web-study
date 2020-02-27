Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Public Partial Class GetPasswordDialog
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
		 Me._okButton = New System.Windows.Forms.Button()
		 Me._cancelButton = New System.Windows.Forms.Button()
		 Me._passwordGroupBox = New System.Windows.Forms.GroupBox()
		 Me._passwordTextBox = New System.Windows.Forms.TextBox()
		 Me._showCharactersCheckBox = New System.Windows.Forms.CheckBox()
		 Me._passwordGroupBox.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _okButton
		 ' 
		 Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._okButton.Location = New System.Drawing.Point(326, 27)
		 Me._okButton.Name = "_okButton"
		 Me._okButton.Size = New System.Drawing.Size(75, 23)
		 Me._okButton.TabIndex = 1
		 Me._okButton.Text = "OK"
		 Me._okButton.UseVisualStyleBackColor = True
'		 Me._okButton.Click += New System.EventHandler(Me._okButton_Click);
		 ' 
		 ' _cancelButton
		 ' 
		 Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._cancelButton.Location = New System.Drawing.Point(326, 56)
		 Me._cancelButton.Name = "_cancelButton"
		 Me._cancelButton.Size = New System.Drawing.Size(75, 23)
		 Me._cancelButton.TabIndex = 2
		 Me._cancelButton.Text = "Cancel"
		 Me._cancelButton.UseVisualStyleBackColor = True
		 ' 
		 ' _passwordGroupBox
		 ' 
		 Me._passwordGroupBox.Controls.Add(Me._showCharactersCheckBox)
		 Me._passwordGroupBox.Controls.Add(Me._passwordTextBox)
		 Me._passwordGroupBox.Location = New System.Drawing.Point(12, 12)
		 Me._passwordGroupBox.Name = "_passwordGroupBox"
		 Me._passwordGroupBox.Size = New System.Drawing.Size(300, 86)
		 Me._passwordGroupBox.TabIndex = 0
		 Me._passwordGroupBox.TabStop = False
		 Me._passwordGroupBox.Text = "&PDF file is encrypted. Password is required:"
		 ' 
		 ' _passwordTextBox
		 ' 
		 Me._passwordTextBox.Location = New System.Drawing.Point(27, 30)
		 Me._passwordTextBox.Name = "_passwordTextBox"
		 Me._passwordTextBox.PasswordChar = "*"c
		 Me._passwordTextBox.Size = New System.Drawing.Size(241, 20)
		 Me._passwordTextBox.TabIndex = 0
		 ' 
		 ' _showCharactersCheckBox
		 ' 
		 Me._showCharactersCheckBox.AutoSize = True
		 Me._showCharactersCheckBox.Location = New System.Drawing.Point(27, 63)
		 Me._showCharactersCheckBox.Name = "_showCharactersCheckBox"
		 Me._showCharactersCheckBox.Size = New System.Drawing.Size(106, 17)
		 Me._showCharactersCheckBox.TabIndex = 1
		 Me._showCharactersCheckBox.Text = "&Show characters"
		 Me._showCharactersCheckBox.UseVisualStyleBackColor = True
'		 Me._showCharactersCheckBox.CheckedChanged += New System.EventHandler(Me._showCharactersCheckBox_CheckedChanged);
		 ' 
		 ' GetPasswordDialog
		 ' 
		 Me.AcceptButton = Me._okButton
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._cancelButton
		 Me.ClientSize = New System.Drawing.Size(413, 115)
		 Me.Controls.Add(Me._passwordGroupBox)
		 Me.Controls.Add(Me._cancelButton)
		 Me.Controls.Add(Me._okButton)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "GetPasswordDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Get Password"
		 Me._passwordGroupBox.ResumeLayout(False)
		 Me._passwordGroupBox.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _okButton As System.Windows.Forms.Button
	  Private _cancelButton As System.Windows.Forms.Button
	  Private _passwordGroupBox As System.Windows.Forms.GroupBox
	  Private _passwordTextBox As System.Windows.Forms.TextBox
	  Private WithEvents _showCharactersCheckBox As System.Windows.Forms.CheckBox
   End Class
End Namespace