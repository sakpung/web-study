<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EngineSettingsDialog
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
      Me._descriptionLabel = New System.Windows.Forms.Label
      Me._closeButton = New System.Windows.Forms.Button
      Me._ocrEngineSettingsControl = New OcrAutoRecognizeDemo.OcrEngineSettingsControl
      Me.SuspendLayout()
      '
      '_descriptionLabel
      '
      Me._descriptionLabel.AutoSize = True
      Me._descriptionLabel.Location = New System.Drawing.Point(12, 11)
      Me._descriptionLabel.Name = "_descriptionLabel"
      Me._descriptionLabel.Size = New System.Drawing.Size(150, 13)
      Me._descriptionLabel.TabIndex = 0
      Me._descriptionLabel.Text = "Change OCR Engine Settings:"
      '
      '_closeButton
      '
      Me._closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._closeButton.Location = New System.Drawing.Point(451, 324)
      Me._closeButton.Name = "_closeButton"
      Me._closeButton.Size = New System.Drawing.Size(75, 23)
      Me._closeButton.TabIndex = 2
      Me._closeButton.Text = "Close"
      Me._closeButton.UseVisualStyleBackColor = True
      '
      '_ocrEngineSettingsControl
      '
      Me._ocrEngineSettingsControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._ocrEngineSettingsControl.Location = New System.Drawing.Point(12, 39)
      Me._ocrEngineSettingsControl.Name = "_ocrEngineSettingsControl"
      Me._ocrEngineSettingsControl.Size = New System.Drawing.Size(510, 266)
      Me._ocrEngineSettingsControl.TabIndex = 1
      '
      'EngineSettingsDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._closeButton
      Me.ClientSize = New System.Drawing.Size(539, 359)
      Me.Controls.Add(Me._ocrEngineSettingsControl)
      Me.Controls.Add(Me._descriptionLabel)
      Me.Controls.Add(Me._closeButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EngineSettingsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "OCR Engine Settings"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _descriptionLabel As System.Windows.Forms.Label
   Private WithEvents _closeButton As System.Windows.Forms.Button
   Friend WithEvents _ocrEngineSettingsControl As OcrAutoRecognizeDemo.OcrEngineSettingsControl
End Class
