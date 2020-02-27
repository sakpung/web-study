<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserInfoDialog
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
      Me.checkBox_DontShowAgain = New System.Windows.Forms.CheckBox()
      Me.button_Ok = New System.Windows.Forms.Button()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._textboxDescription = New System.Windows.Forms.TextBox()
      Me.groupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'checkBox_DontShowAgain
      '
      Me.checkBox_DontShowAgain.AutoSize = True
      Me.checkBox_DontShowAgain.Location = New System.Drawing.Point(13, 205)
      Me.checkBox_DontShowAgain.Name = "checkBox_DontShowAgain"
      Me.checkBox_DontShowAgain.Size = New System.Drawing.Size(174, 17)
      Me.checkBox_DontShowAgain.TabIndex = 4
      Me.checkBox_DontShowAgain.Text = "Don't show this dialog next time"
      Me.checkBox_DontShowAgain.UseVisualStyleBackColor = True
      '
      'button_Ok
      '
      Me.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.button_Ok.Location = New System.Drawing.Point(136, 229)
      Me.button_Ok.Name = "button_Ok"
      Me.button_Ok.Size = New System.Drawing.Size(75, 23)
      Me.button_Ok.TabIndex = 6
      Me.button_Ok.Text = "OK"
      Me.button_Ok.UseVisualStyleBackColor = True
      '
      'groupBox1
      '
      Me.groupBox1.Controls.Add(Me._textboxDescription)
      Me.groupBox1.Location = New System.Drawing.Point(13, 9)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(324, 175)
      Me.groupBox1.TabIndex = 5
      Me.groupBox1.TabStop = False
      '
      '_textboxDescription
      '
      Me._textboxDescription.BackColor = System.Drawing.SystemColors.ControlDark
      Me._textboxDescription.Location = New System.Drawing.Point(7, 4)
      Me._textboxDescription.Multiline = True
      Me._textboxDescription.Name = "_textboxDescription"
      Me._textboxDescription.ReadOnly = True
      Me._textboxDescription.Size = New System.Drawing.Size(311, 165)
      Me._textboxDescription.TabIndex = 0
      '
      'UserInfoDialog
      '
      Me.AcceptButton = Me.button_Ok
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(350, 260)
      Me.Controls.Add(Me.checkBox_DontShowAgain)
      Me.Controls.Add(Me.button_Ok)
      Me.Controls.Add(Me.groupBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "UserInfoDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "UserInfo"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents checkBox_DontShowAgain As System.Windows.Forms.CheckBox
   Private WithEvents button_Ok As System.Windows.Forms.Button
   Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents _textboxDescription As System.Windows.Forms.TextBox
End Class
