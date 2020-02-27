Partial Class TwainDocumentCleanupMessage
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TwainDocumentCleanupMessage))
      Me._chkShowAgain = New System.Windows.Forms.CheckBox()
      Me._btn_OK = New System.Windows.Forms.Button()
      Me.textBox1 = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      '_chkShowAgain
      '
      Me._chkShowAgain.AutoSize = True
      Me._chkShowAgain.Location = New System.Drawing.Point(15, 116)
      Me._chkShowAgain.Name = "_chkShowAgain"
      Me._chkShowAgain.Size = New System.Drawing.Size(184, 17)
      Me._chkShowAgain.TabIndex = 1
      Me._chkShowAgain.Text = "Do not Show This Message Again"
      Me._chkShowAgain.UseVisualStyleBackColor = True
      '
      '_btn_OK
      '
      Me._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btn_OK.Location = New System.Drawing.Point(251, 116)
      Me._btn_OK.Name = "_btn_OK"
      Me._btn_OK.Size = New System.Drawing.Size(121, 23)
      Me._btn_OK.TabIndex = 2
      Me._btn_OK.Text = "OK"
      Me._btn_OK.UseVisualStyleBackColor = True
      '
      'textBox1
      '
      Me.textBox1.BackColor = System.Drawing.SystemColors.Window
      Me.textBox1.Location = New System.Drawing.Point(15, 22)
      Me.textBox1.Multiline = True
      Me.textBox1.Name = "textBox1"
      Me.textBox1.ReadOnly = True
      Me.textBox1.Size = New System.Drawing.Size(357, 75)
      Me.textBox1.TabIndex = 3
      Me.textBox1.Text = "One or more document cleanup functionality is enabled to remove deformations in t" & _
    "he scanned images." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "All scanned images will be converted to black and white au" & _
    "tomatically."
      Me.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'TwainDocumentCleanupMessage
      '
      Me.AcceptButton = Me._btn_OK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 160)
      Me.Controls.Add(Me.textBox1)
      Me.Controls.Add(Me._btn_OK)
      Me.Controls.Add(Me._chkShowAgain)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "TwainDocumentCleanupMessage"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Information"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Private WithEvents _chkShowAgain As System.Windows.Forms.CheckBox
   Private _btn_OK As System.Windows.Forms.Button
   Private textBox1 As System.Windows.Forms.TextBox
End Class
