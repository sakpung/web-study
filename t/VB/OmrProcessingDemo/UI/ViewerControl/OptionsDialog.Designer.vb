Partial Class OptionsDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.chkAutoEstimate = New System.Windows.Forms.CheckBox()
      Me.chkAutosave = New System.Windows.Forms.CheckBox()
      Me.nudAutosave = New System.Windows.Forms.NumericUpDown()
      Me.lblAutoSaveMinutes = New System.Windows.Forms.Label()
      CType(Me.nudAutosave, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      Me.btnOK.Location = New System.Drawing.Point(162, 125)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      AddHandler Me.btnOK.Click, AddressOf Me.btnOK_Click
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(243, 125)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.chkAutoEstimate.AutoSize = True
      Me.chkAutoEstimate.Location = New System.Drawing.Point(12, 12)
      Me.chkAutoEstimate.Name = "chkAutoEstimate"
      Me.chkAutoEstimate.Size = New System.Drawing.Size(238, 17)
      Me.chkAutoEstimate.TabIndex = 2
      Me.chkAutoEstimate.Text = "&Automatically Estimate Missing OMR Bubbles"
      Me.chkAutoEstimate.UseVisualStyleBackColor = True
      Me.chkAutosave.AutoSize = True
      Me.chkAutosave.Location = New System.Drawing.Point(12, 48)
      Me.chkAutosave.Name = "chkAutosave"
      Me.chkAutosave.Size = New System.Drawing.Size(165, 17)
      Me.chkAutosave.TabIndex = 3
      Me.chkAutosave.Text = "Auto-&Save recovery file every"
      Me.chkAutosave.UseVisualStyleBackColor = True
      AddHandler Me.chkAutosave.CheckedChanged, AddressOf Me.chkAutosave_CheckedChanged
      Me.nudAutosave.Location = New System.Drawing.Point(173, 45)
      Me.nudAutosave.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudAutosave.Name = "nudAutosave"
      Me.nudAutosave.Size = New System.Drawing.Size(43, 20)
      Me.nudAutosave.TabIndex = 4
      Me.nudAutosave.Value = New Decimal(New Integer() {1, 0, 0, 0})
      Me.lblAutoSaveMinutes.AutoSize = True
      Me.lblAutoSaveMinutes.Location = New System.Drawing.Point(222, 49)
      Me.lblAutoSaveMinutes.Name = "lblAutoSaveMinutes"
      Me.lblAutoSaveMinutes.Size = New System.Drawing.Size(43, 13)
      Me.lblAutoSaveMinutes.TabIndex = 5
      Me.lblAutoSaveMinutes.Text = "minutes"
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(330, 160)
      Me.Controls.Add(Me.lblAutoSaveMinutes)
      Me.Controls.Add(Me.nudAutosave)
      Me.Controls.Add(Me.chkAutosave)
      Me.Controls.Add(Me.chkAutoEstimate)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OptionsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Options"
      CType(Me.nudAutosave, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnOK As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private chkAutoEstimate As System.Windows.Forms.CheckBox
   Private chkAutosave As System.Windows.Forms.CheckBox
   Private nudAutosave As System.Windows.Forms.NumericUpDown
   Private lblAutoSaveMinutes As System.Windows.Forms.Label
End Class
