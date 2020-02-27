Partial Class RowNumberDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.txtValue = New System.Windows.Forms.TextBox()
      Me.lblValue = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me.nudStart = New System.Windows.Forms.NumericUpDown()
      CType(Me.nudStart, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(350, 36)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 7
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(269, 36)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 6
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.txtValue.Location = New System.Drawing.Point(67, 9)
      Me.txtValue.Name = "txtValue"
      Me.txtValue.Size = New System.Drawing.Size(180, 20)
      Me.txtValue.TabIndex = 5
      AddHandler Me.txtValue.Enter, AddressOf Me.txtValue_Enter
      Me.lblValue.AutoSize = True
      Me.lblValue.Location = New System.Drawing.Point(12, 12)
      Me.lblValue.Name = "lblValue"
      Me.lblValue.Size = New System.Drawing.Size(54, 13)
      Me.lblValue.TabIndex = 4
      Me.lblValue.Text = "Template:"
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(253, 12)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(99, 13)
      Me.label1.TabIndex = 8
      Me.label1.Text = "Start Numbering At:"
      Me.nudStart.Location = New System.Drawing.Point(358, 10)
      Me.nudStart.Name = "nudStart"
      Me.nudStart.Size = New System.Drawing.Size(67, 20)
      Me.nudStart.TabIndex = 9
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(440, 66)
      Me.Controls.Add(Me.nudStart)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.txtValue)
      Me.Controls.Add(Me.lblValue)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RowNumberDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Update"
      AddHandler Me.FormClosing, AddressOf Me.RowNumberDialog_FormClosing
      CType(nudStart, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnCancel As System.Windows.Forms.Button
   Private btnOK As System.Windows.Forms.Button
   Private txtValue As System.Windows.Forms.TextBox
   Private lblValue As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private nudStart As System.Windows.Forms.NumericUpDown
End Class
