<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GotoPageDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me._pagesLabel = New System.Windows.Forms.Label
      Me._pageTextBox = New System.Windows.Forms.TextBox
      Me._pageLabel = New System.Windows.Forms.Label
      Me._cancelButton = New System.Windows.Forms.Button
      Me._okButton = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      '_pagesLabel
      '
      Me._pagesLabel.AutoSize = True
      Me._pagesLabel.Location = New System.Drawing.Point(166, 15)
      Me._pagesLabel.Name = "_pagesLabel"
      Me._pagesLabel.Size = New System.Drawing.Size(63, 13)
      Me._pagesLabel.TabIndex = 2
      Me._pagesLabel.Text = "of WWWW"
      '
      '_pageTextBox
      '
      Me._pageTextBox.Location = New System.Drawing.Point(60, 12)
      Me._pageTextBox.Name = "_pageTextBox"
      Me._pageTextBox.Size = New System.Drawing.Size(100, 20)
      Me._pageTextBox.TabIndex = 1
      '
      '_pageLabel
      '
      Me._pageLabel.AutoSize = True
      Me._pageLabel.Location = New System.Drawing.Point(8, 15)
      Me._pageLabel.Name = "_pageLabel"
      Me._pageLabel.Size = New System.Drawing.Size(35, 13)
      Me._pageLabel.TabIndex = 0
      Me._pageLabel.Text = "&Page:"
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(153, 46)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 4
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(72, 46)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 3
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      'GotoPageDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(245, 84)
      Me.Controls.Add(Me._pagesLabel)
      Me.Controls.Add(Me._pageTextBox)
      Me.Controls.Add(Me._pageLabel)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "GotoPageDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Go To Page"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _pagesLabel As System.Windows.Forms.Label
   Private WithEvents _pageTextBox As System.Windows.Forms.TextBox
   Private WithEvents _pageLabel As System.Windows.Forms.Label
   Private WithEvents _cancelButton As System.Windows.Forms.Button
   Private WithEvents _okButton As System.Windows.Forms.Button
End Class
