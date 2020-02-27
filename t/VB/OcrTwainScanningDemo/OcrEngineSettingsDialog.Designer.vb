<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcrEngineSettingsDialog
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
      Me._ocrEngineSettings = New OcrTwainScanningDemo.OcrEngineSettingsControl
      Me._btnClose = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      '_ocrEngineSettings
      '
      Me._ocrEngineSettings.Location = New System.Drawing.Point(12, 12)
      Me._ocrEngineSettings.Name = "_ocrEngineSettings"
      Me._ocrEngineSettings.Size = New System.Drawing.Size(510, 266)
      Me._ocrEngineSettings.TabIndex = 0
      '
      '_btnClose
      '
      Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnClose.Location = New System.Drawing.Point(447, 294)
      Me._btnClose.Name = "_btnClose"
      Me._btnClose.Size = New System.Drawing.Size(75, 23)
      Me._btnClose.TabIndex = 1
      Me._btnClose.Text = "Close"
      Me._btnClose.UseVisualStyleBackColor = True
      '
      'OcrEngineSettingsDialog
      '
      Me.AcceptButton = Me._btnClose
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(536, 326)
      Me.Controls.Add(Me._btnClose)
      Me.Controls.Add(Me._ocrEngineSettings)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OcrEngineSettingsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "OCR Engine Settings"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents _ocrEngineSettings As OcrTwainScanningDemo.OcrEngineSettingsControl
   Private WithEvents _btnClose As System.Windows.Forms.Button
End Class
