<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnableLanguagesDialog
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
      Me._selectLabel = New System.Windows.Forms.Label
      Me._descriptionLabel = New System.Windows.Forms.Label
      Me._languagesListBox = New System.Windows.Forms.ListBox
      Me._cancelButton = New System.Windows.Forms.Button
      Me._okButton = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      '_selectLabel
      '
      Me._selectLabel.AutoSize = True
      Me._selectLabel.Location = New System.Drawing.Point(5, 13)
      Me._selectLabel.Name = "_selectLabel"
      Me._selectLabel.Size = New System.Drawing.Size(242, 13)
      Me._selectLabel.TabIndex = 0
      Me._selectLabel.Text = "Select the OCR languages to enable in this demo:"
      '
      '_descriptionLabel
      '
      Me._descriptionLabel.Location = New System.Drawing.Point(8, 218)
      Me._descriptionLabel.Name = "_descriptionLabel"
      Me._descriptionLabel.Size = New System.Drawing.Size(301, 46)
      Me._descriptionLabel.TabIndex = 2
      Me._descriptionLabel.Text = "Select Engine/Components from the main menu for additional languages available fo" & _
          "r this OCR engine type"
      '
      '_languagesListBox
      '
      Me._languagesListBox.FormattingEnabled = True
      Me._languagesListBox.Location = New System.Drawing.Point(8, 41)
      Me._languagesListBox.Name = "_languagesListBox"
      Me._languagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
      Me._languagesListBox.Size = New System.Drawing.Size(298, 160)
      Me._languagesListBox.TabIndex = 1
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(231, 287)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 4
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(150, 287)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 3
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      'EnableLanguagesDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(315, 323)
      Me.Controls.Add(Me._selectLabel)
      Me.Controls.Add(Me._descriptionLabel)
      Me.Controls.Add(Me._languagesListBox)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EnableLanguagesDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Enable Languages"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _selectLabel As System.Windows.Forms.Label
   Private WithEvents _descriptionLabel As System.Windows.Forms.Label
   Private WithEvents _languagesListBox As System.Windows.Forms.ListBox
   Private WithEvents _cancelButton As System.Windows.Forms.Button
   Private WithEvents _okButton As System.Windows.Forms.Button
End Class
