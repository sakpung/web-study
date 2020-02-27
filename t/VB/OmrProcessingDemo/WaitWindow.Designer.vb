Partial Class WaitWindow
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.lblDisplay = New System.Windows.Forms.Label()
      Me.pbar = New System.Windows.Forms.ProgressBar()
      Me.SuspendLayout()
      Me.lblDisplay.AutoSize = True
      Me.lblDisplay.Location = New System.Drawing.Point(12, 14)
      Me.lblDisplay.Name = "lblDisplay"
      Me.lblDisplay.Size = New System.Drawing.Size(56, 13)
      Me.lblDisplay.TabIndex = 0
      Me.lblDisplay.Text = "Working..."
      Me.pbar.Location = New System.Drawing.Point(12, 30)
      Me.pbar.Name = "pbar"
      Me.pbar.Size = New System.Drawing.Size(330, 23)
      Me.pbar.TabIndex = 1
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(350, 70)
      Me.Controls.Add(Me.pbar)
      Me.Controls.Add(Me.lblDisplay)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "WaitWindow"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Processing..."
      AddHandler Me.FormClosing, AddressOf Me.WaitWindow_FormClosing
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Public lblDisplay As System.Windows.Forms.Label
   Public pbar As System.Windows.Forms.ProgressBar
End Class
