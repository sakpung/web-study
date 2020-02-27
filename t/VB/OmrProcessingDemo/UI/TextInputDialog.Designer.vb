Partial Class TextInputDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.lblValue = New System.Windows.Forms.Label()
      Me.txtValue = New System.Windows.Forms.TextBox()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      Me.lblValue.AutoSize = True
      Me.lblValue.Location = New System.Drawing.Point(12, 9)
      Me.lblValue.Name = "lblValue"
      Me.lblValue.Size = New System.Drawing.Size(37, 13)
      Me.lblValue.TabIndex = 0
      Me.lblValue.Text = "Value:"
      Me.txtValue.Location = New System.Drawing.Point(55, 6)
      Me.txtValue.Name = "txtValue"
      Me.txtValue.Size = New System.Drawing.Size(299, 20)
      Me.txtValue.TabIndex = 1
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(279, 32)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(198, 32)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 2
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(366, 66)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.txtValue)
      Me.Controls.Add(Me.lblValue)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TextInputDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Update"
      AddHandler Me.FormClosing, AddressOf Me.TextInputDialog_FormClosing
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private lblValue As System.Windows.Forms.Label
   Private txtValue As System.Windows.Forms.TextBox
   Private btnCancel As System.Windows.Forms.Button
   Private btnOK As System.Windows.Forms.Button
End Class
