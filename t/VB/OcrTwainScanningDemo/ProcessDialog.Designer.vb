<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessDialog
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
      Me._pbProgress = New System.Windows.Forms.ProgressBar
      Me._lblProcessing = New System.Windows.Forms.Label
      Me._btnCancel = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      '_pbProgress
      '
      Me._pbProgress.Location = New System.Drawing.Point(13, 53)
      Me._pbProgress.Name = "_pbProgress"
      Me._pbProgress.Size = New System.Drawing.Size(416, 23)
      Me._pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me._pbProgress.TabIndex = 8
      '
      '_lblProcessing
      '
      Me._lblProcessing.Location = New System.Drawing.Point(12, 11)
      Me._lblProcessing.Name = "_lblProcessing"
      Me._lblProcessing.Size = New System.Drawing.Size(419, 23)
      Me._lblProcessing.TabIndex = 7
      Me._lblProcessing.Text = "label1"
      Me._lblProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(184, 95)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 6
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      'ProcessDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(442, 128)
      Me.Controls.Add(Me._pbProgress)
      Me.Controls.Add(Me._lblProcessing)
      Me.Controls.Add(Me._btnCancel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ProcessDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "ProcessDialog"
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _pbProgress As System.Windows.Forms.ProgressBar
   Private WithEvents _lblProcessing As System.Windows.Forms.Label
   Private WithEvents _btnCancel As System.Windows.Forms.Button
End Class
