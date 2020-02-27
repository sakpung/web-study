<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentPathControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
      Me._documentPathGroupBox = New System.Windows.Forms.GroupBox
      Me._documentPathTextBox = New System.Windows.Forms.TextBox
      Me._browseButton = New System.Windows.Forms.Button
      Me._documentPathGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_documentPathGroupBox
      '
      Me._documentPathGroupBox.Controls.Add(Me._documentPathTextBox)
      Me._documentPathGroupBox.Controls.Add(Me._browseButton)
      Me._documentPathGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._documentPathGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._documentPathGroupBox.Name = "_documentPathGroupBox"
      Me._documentPathGroupBox.Size = New System.Drawing.Size(520, 70)
      Me._documentPathGroupBox.TabIndex = 0
      Me._documentPathGroupBox.TabStop = False
      Me._documentPathGroupBox.Text = "Select the document to view:"
      '
      '_documentPathTextBox
      '
      Me._documentPathTextBox.Location = New System.Drawing.Point(16, 35)
      Me._documentPathTextBox.Name = "_documentPathTextBox"
      Me._documentPathTextBox.Size = New System.Drawing.Size(407, 20)
      Me._documentPathTextBox.TabIndex = 0
      '
      '_browseButton
      '
      Me._browseButton.Location = New System.Drawing.Point(429, 33)
      Me._browseButton.Name = "_browseButton"
      Me._browseButton.Size = New System.Drawing.Size(75, 23)
      Me._browseButton.TabIndex = 1
      Me._browseButton.Text = "&Browse..."
      Me._browseButton.UseVisualStyleBackColor = True
      '
      'DocumentPathControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._documentPathGroupBox)
      Me.Name = "DocumentPathControl"
      Me.Size = New System.Drawing.Size(520, 70)
      Me._documentPathGroupBox.ResumeLayout(False)
      Me._documentPathGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _documentPathGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _documentPathTextBox As System.Windows.Forms.TextBox
   Private WithEvents _browseButton As System.Windows.Forms.Button

End Class
