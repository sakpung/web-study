Namespace PDFDocumentDemo
   Partial Class GetPasswordDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GetPasswordDialog))
         Me._okButton = New System.Windows.Forms.Button()
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._passwordGroupBox = New System.Windows.Forms.GroupBox()
         Me._showCharactersCheckBox = New System.Windows.Forms.CheckBox()
         Me._passwordTextBox = New System.Windows.Forms.TextBox()
         Me._passwordGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._okButton, "_okButton")
         Me._okButton.Name = "_okButton"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._cancelButton, "_cancelButton")
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _passwordGroupBox
         ' 
         Me._passwordGroupBox.Controls.Add(Me._showCharactersCheckBox)
         Me._passwordGroupBox.Controls.Add(Me._passwordTextBox)
         resources.ApplyResources(Me._passwordGroupBox, "_passwordGroupBox")
         Me._passwordGroupBox.Name = "_passwordGroupBox"
         Me._passwordGroupBox.TabStop = False
         ' 
         ' _showCharactersCheckBox
         ' 
         resources.ApplyResources(Me._showCharactersCheckBox, "_showCharactersCheckBox")
         Me._showCharactersCheckBox.Name = "_showCharactersCheckBox"
         Me._showCharactersCheckBox.UseVisualStyleBackColor = True
         ' 
         ' _passwordTextBox
         ' 
         resources.ApplyResources(Me._passwordTextBox, "_passwordTextBox")
         Me._passwordTextBox.Name = "_passwordTextBox"
         ' 
         ' GetPasswordDialog
         ' 
         Me.AcceptButton = Me._okButton
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.Controls.Add(Me._passwordGroupBox)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "GetPasswordDialog"
         Me.ShowInTaskbar = False
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
