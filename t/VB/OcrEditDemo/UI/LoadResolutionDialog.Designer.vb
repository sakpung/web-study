<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadResolutionDialog
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
      Me._resolutionGroupBox = New System.Windows.Forms.GroupBox
      Me._resolutionLabelDpi = New System.Windows.Forms.Label
      Me._resolutionTextBox = New System.Windows.Forms.TextBox
      Me._resolutionLabel = New System.Windows.Forms.Label
      Me._okButton = New System.Windows.Forms.Button
      Me._cancelButton = New System.Windows.Forms.Button
      Me._resolutionGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_resolutionGroupBox
      '
      Me._resolutionGroupBox.Controls.Add(Me._resolutionLabelDpi)
      Me._resolutionGroupBox.Controls.Add(Me._resolutionTextBox)
      Me._resolutionGroupBox.Controls.Add(Me._resolutionLabel)
      Me._resolutionGroupBox.Location = New System.Drawing.Point(18, 15)
      Me._resolutionGroupBox.Name = "_resolutionGroupBox"
      Me._resolutionGroupBox.Size = New System.Drawing.Size(242, 71)
      Me._resolutionGroupBox.TabIndex = 0
      Me._resolutionGroupBox.TabStop = False
      Me._resolutionGroupBox.Text = "Select a value between 10 and 10000 DPI:"
      '
      '_resolutionLabelDpi
      '
      Me._resolutionLabelDpi.AutoSize = True
      Me._resolutionLabelDpi.Location = New System.Drawing.Point(180, 37)
      Me._resolutionLabelDpi.Name = "_resolutionLabelDpi"
      Me._resolutionLabelDpi.Size = New System.Drawing.Size(21, 13)
      Me._resolutionLabelDpi.TabIndex = 2
      Me._resolutionLabelDpi.Text = "dpi"
      '
      '_resolutionTextBox
      '
      Me._resolutionTextBox.Location = New System.Drawing.Point(85, 34)
      Me._resolutionTextBox.Name = "_resolutionTextBox"
      Me._resolutionTextBox.Size = New System.Drawing.Size(89, 20)
      Me._resolutionTextBox.TabIndex = 1
      '
      '_resolutionLabel
      '
      Me._resolutionLabel.AutoSize = True
      Me._resolutionLabel.Location = New System.Drawing.Point(19, 37)
      Me._resolutionLabel.Name = "_resolutionLabel"
      Me._resolutionLabel.Size = New System.Drawing.Size(60, 13)
      Me._resolutionLabel.TabIndex = 0
      Me._resolutionLabel.Text = "&Resolution:"
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(280, 25)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(280, 54)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 2
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      'LoadResolutionDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(372, 100)
      Me.Controls.Add(Me._resolutionGroupBox)
      Me.Controls.Add(Me._okButton)
      Me.Controls.Add(Me._cancelButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LoadResolutionDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Set PDF Load Resolution"
      Me._resolutionGroupBox.ResumeLayout(False)
      Me._resolutionGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _resolutionGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _resolutionLabelDpi As System.Windows.Forms.Label
   Private WithEvents _resolutionTextBox As System.Windows.Forms.TextBox
   Private WithEvents _resolutionLabel As System.Windows.Forms.Label
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private WithEvents _cancelButton As System.Windows.Forms.Button
End Class
