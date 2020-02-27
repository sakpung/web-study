Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class PasswordDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasswordDialog))
         Me.BottomPanel = New System.Windows.Forms.Panel
         Me.ButtonsGroupBox = New System.Windows.Forms.GroupBox
         Me.CancelDialogButton = New System.Windows.Forms.Button
         Me.OKButton = New System.Windows.Forms.Button
         Me.ContainerPanel = New System.Windows.Forms.Panel
         Me.pictureBox1 = New System.Windows.Forms.PictureBox
         Me.ConfirmPasswordTextBox = New System.Windows.Forms.TextBox
         Me.passwordTextBox = New System.Windows.Forms.TextBox
         Me.ConfirmPasswordLabel = New System.Windows.Forms.Label
         Me.PasswordLabel = New System.Windows.Forms.Label
         Me.BottomPanel.SuspendLayout()
         Me.ContainerPanel.SuspendLayout()
         CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         'BottomPanel
         '
         Me.BottomPanel.Controls.Add(Me.ButtonsGroupBox)
         Me.BottomPanel.Controls.Add(Me.CancelDialogButton)
         Me.BottomPanel.Controls.Add(Me.OKButton)
         Me.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.BottomPanel.Location = New System.Drawing.Point(0, 72)
         Me.BottomPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.BottomPanel.Name = "BottomPanel"
         Me.BottomPanel.Size = New System.Drawing.Size(412, 37)
         Me.BottomPanel.TabIndex = 1
         '
         'ButtonsGroupBox
         '
         Me.ButtonsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
         Me.ButtonsGroupBox.Location = New System.Drawing.Point(0, 0)
         Me.ButtonsGroupBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.ButtonsGroupBox.Name = "ButtonsGroupBox"
         Me.ButtonsGroupBox.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.ButtonsGroupBox.Size = New System.Drawing.Size(412, 10)
         Me.ButtonsGroupBox.TabIndex = 0
         Me.ButtonsGroupBox.TabStop = False
         '
         'CancelDialogButton
         '
         Me.CancelDialogButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.CancelDialogButton.Location = New System.Drawing.Point(343, 11)
         Me.CancelDialogButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.CancelDialogButton.Name = "CancelDialogButton"
         Me.CancelDialogButton.Size = New System.Drawing.Size(64, 22)
         Me.CancelDialogButton.TabIndex = 2
         Me.CancelDialogButton.Text = "Cancel"
         Me.CancelDialogButton.UseVisualStyleBackColor = True
         '
         'OKButton
         '
         Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.OKButton.Location = New System.Drawing.Point(273, 11)
         Me.OKButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.OKButton.Name = "OKButton"
         Me.OKButton.Size = New System.Drawing.Size(64, 22)
         Me.OKButton.TabIndex = 1
         Me.OKButton.Text = "OK"
         Me.OKButton.UseVisualStyleBackColor = True
         '
         'ContainerPanel
         '
         Me.ContainerPanel.Controls.Add(Me.pictureBox1)
         Me.ContainerPanel.Controls.Add(Me.ConfirmPasswordTextBox)
         Me.ContainerPanel.Controls.Add(Me.passwordTextBox)
         Me.ContainerPanel.Controls.Add(Me.ConfirmPasswordLabel)
         Me.ContainerPanel.Controls.Add(Me.PasswordLabel)
         Me.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me.ContainerPanel.Location = New System.Drawing.Point(0, 0)
         Me.ContainerPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.ContainerPanel.Name = "ContainerPanel"
         Me.ContainerPanel.Size = New System.Drawing.Size(412, 72)
         Me.ContainerPanel.TabIndex = 0
         '
         'pictureBox1
         '
         Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
         Me.pictureBox1.Location = New System.Drawing.Point(4, 11)
         Me.pictureBox1.Name = "pictureBox1"
         Me.pictureBox1.Size = New System.Drawing.Size(73, 50)
         Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
         Me.pictureBox1.TabIndex = 4
         Me.pictureBox1.TabStop = False
         '
         'ConfirmPasswordTextBox
         '
         Me.ConfirmPasswordTextBox.Location = New System.Drawing.Point(187, 37)
         Me.ConfirmPasswordTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox"
         Me.ConfirmPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
         Me.ConfirmPasswordTextBox.Size = New System.Drawing.Size(213, 20)
         Me.ConfirmPasswordTextBox.TabIndex = 3
         '
         'passwordTextBox
         '
         Me.passwordTextBox.Location = New System.Drawing.Point(187, 11)
         Me.passwordTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.passwordTextBox.Name = "passwordTextBox"
         Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
         Me.passwordTextBox.Size = New System.Drawing.Size(213, 20)
         Me.passwordTextBox.TabIndex = 1
         '
         'ConfirmPasswordLabel
         '
         Me.ConfirmPasswordLabel.AutoSize = True
         Me.ConfirmPasswordLabel.Location = New System.Drawing.Point(83, 40)
         Me.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel"
         Me.ConfirmPasswordLabel.Size = New System.Drawing.Size(97, 13)
         Me.ConfirmPasswordLabel.TabIndex = 2
         Me.ConfirmPasswordLabel.Text = "Confirm Password:"
         '
         'PasswordLabel
         '
         Me.PasswordLabel.AutoSize = True
         Me.PasswordLabel.Location = New System.Drawing.Point(83, 14)
         Me.PasswordLabel.Name = "PasswordLabel"
         Me.PasswordLabel.Size = New System.Drawing.Size(57, 13)
         Me.PasswordLabel.TabIndex = 0
         Me.PasswordLabel.Text = "Password:"
         '
         'PasswordDialog
         '
         Me.AcceptButton = Me.OKButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.CancelDialogButton
         Me.ClientSize = New System.Drawing.Size(412, 109)
         Me.Controls.Add(Me.ContainerPanel)
         Me.Controls.Add(Me.BottomPanel)
         Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "PasswordDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "New Password"
         Me.BottomPanel.ResumeLayout(False)
         Me.ContainerPanel.ResumeLayout(False)
         Me.ContainerPanel.PerformLayout()
         CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Protected BottomPanel As System.Windows.Forms.Panel
      Protected CancelDialogButton As System.Windows.Forms.Button
      Protected OKButton As System.Windows.Forms.Button
      Protected ButtonsGroupBox As System.Windows.Forms.GroupBox
      Protected ContainerPanel As System.Windows.Forms.Panel
      Protected ConfirmPasswordTextBox As System.Windows.Forms.TextBox
      Protected passwordTextBox As System.Windows.Forms.TextBox
      Protected ConfirmPasswordLabel As System.Windows.Forms.Label
      Protected PasswordLabel As System.Windows.Forms.Label
      Private pictureBox1 As System.Windows.Forms.PictureBox
   End Class
End Namespace