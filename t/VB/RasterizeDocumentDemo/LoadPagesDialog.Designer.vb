<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadPagesDialog
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
      Me._cancelButton = New System.Windows.Forms.Button
      Me._okButton = New System.Windows.Forms.Button
      Me._documentPagesControl = New RasterizeDocumentDemo.DocumentPagesControl
      Me.SuspendLayout()
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(416, 104)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 2
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(335, 104)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_documentPagesControl
      '
      Me._documentPagesControl.Location = New System.Drawing.Point(12, 12)
      Me._documentPagesControl.Name = "_documentPagesControl"
      Me._documentPagesControl.Size = New System.Drawing.Size(489, 86)
      Me._documentPagesControl.TabIndex = 0
      '
      'LoadPagesDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(512, 134)
      Me.Controls.Add(Me._documentPagesControl)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LoadPagesDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Select the Document Pages to Load"
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _cancelButton As System.Windows.Forms.Button
   Private WithEvents _okButton As System.Windows.Forms.Button
   Friend WithEvents _documentPagesControl As RasterizeDocumentDemo.DocumentPagesControl
End Class
