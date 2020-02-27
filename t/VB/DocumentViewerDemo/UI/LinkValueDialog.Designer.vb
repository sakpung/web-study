
Partial Class LinkValueDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
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
      Me._closeButton = New System.Windows.Forms.Button()
      Me._infoLabel = New System.Windows.Forms.Label()
      Me._linkValueTextBox = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      ' 
      ' _closeButton
      ' 
      Me._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._closeButton.Location = New System.Drawing.Point(200, 110)
      Me._closeButton.Name = "_closeButton"
      Me._closeButton.Size = New System.Drawing.Size(75, 23)
      Me._closeButton.TabIndex = 2
      Me._closeButton.Text = "C&lose"
      Me._closeButton.UseVisualStyleBackColor = True
      ' 
      ' _infoLabel
      ' 
      Me._infoLabel.Location = New System.Drawing.Point(13, 13)
      Me._infoLabel.Name = "_infoLabel"
      Me._infoLabel.Size = New System.Drawing.Size(259, 56)
      Me._infoLabel.TabIndex = 0
      Me._infoLabel.Text = "You clicked the following link value that cannot be executed by the system:"
      ' 
      ' _linkValueTextBox
      ' 
      Me._linkValueTextBox.Location = New System.Drawing.Point(16, 72)
      Me._linkValueTextBox.Name = "_linkValueTextBox"
      Me._linkValueTextBox.Size = New System.Drawing.Size(259, 20)
      Me._linkValueTextBox.TabIndex = 1
      ' 
      ' LinkValueDialog
      ' 
      Me.AcceptButton = Me._closeButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._closeButton
      Me.ClientSize = New System.Drawing.Size(284, 148)
      Me.Controls.Add(Me._linkValueTextBox)
      Me.Controls.Add(Me._infoLabel)
      Me.Controls.Add(Me._closeButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LinkValueDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Link Value"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _closeButton As System.Windows.Forms.Button
   Private _infoLabel As System.Windows.Forms.Label
   Private _linkValueTextBox As System.Windows.Forms.TextBox
End Class