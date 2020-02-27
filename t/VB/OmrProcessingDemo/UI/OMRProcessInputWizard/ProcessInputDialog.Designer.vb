Partial Class ProcessInputDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnPrevious = New System.Windows.Forms.Button()
      Me.btnNext = New System.Windows.Forms.Button()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(551, 207)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 2
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.btnPrevious.Location = New System.Drawing.Point(389, 207)
      Me.btnPrevious.Name = "btnPrevious"
      Me.btnPrevious.Size = New System.Drawing.Size(75, 23)
      Me.btnPrevious.TabIndex = 3
      Me.btnPrevious.Text = "< Previous"
      Me.btnPrevious.UseVisualStyleBackColor = True
      AddHandler Me.btnPrevious.Click, AddressOf Me.btnPrevious_Click
      Me.btnNext.Location = New System.Drawing.Point(464, 207)
      Me.btnNext.Name = "btnNext"
      Me.btnNext.Size = New System.Drawing.Size(75, 23)
      Me.btnNext.TabIndex = 4
      Me.btnNext.Text = "Next >"
      Me.btnNext.UseVisualStyleBackColor = True
      AddHandler Me.btnNext.Click, AddressOf Me.btnNext_Click
      Me.btnOK.AutoSize = True
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(464, 207)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 5
      Me.btnOK.Text = "Run"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(638, 241)
      Me.Controls.Add(Me.btnPrevious)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnNext)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ProcessInputDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Template Selection"
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnCancel As System.Windows.Forms.Button
   Private WithEvents btnPrevious As System.Windows.Forms.Button
   Private WithEvents btnNext As System.Windows.Forms.Button
   Private btnOK As System.Windows.Forms.Button
End Class
