Partial Class HighlightOptionsDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.chkCorrect = New System.Windows.Forms.CheckBox()
      Me.chkIncorrect = New System.Windows.Forms.CheckBox()
      Me.chkCorrectModified = New System.Windows.Forms.CheckBox()
      Me.chkIncorrectModified = New System.Windows.Forms.CheckBox()
      Me.btnCorrect = New System.Windows.Forms.Button()
      Me.btnIncorrect = New System.Windows.Forms.Button()
      Me.btnModCorrect = New System.Windows.Forms.Button()
      Me.btnModIncorrect = New System.Windows.Forms.Button()
      Me.chkExpected = New System.Windows.Forms.CheckBox()
      Me.btnExpected = New System.Windows.Forms.Button()
      Me.chkReview = New System.Windows.Forms.CheckBox()
      Me.btnReview = New System.Windows.Forms.Button()
      Me.btnCriteria = New System.Windows.Forms.Button()
      Me.btnApply = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.Location = New System.Drawing.Point(143, 205)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 23)
      Me.btnOk.TabIndex = 0
      Me.btnOk.Text = "OK"
      Me.btnOk.UseVisualStyleBackColor = True
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(224, 205)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.chkCorrect.AutoSize = True
      Me.chkCorrect.Location = New System.Drawing.Point(28, 22)
      Me.chkCorrect.Name = "chkCorrect"
      Me.chkCorrect.Size = New System.Drawing.Size(119, 17)
      Me.chkCorrect.TabIndex = 2
      Me.chkCorrect.Text = "Correct Responses:"
      Me.chkCorrect.UseVisualStyleBackColor = True
      AddHandler Me.chkCorrect.CheckedChanged, AddressOf Me.rdbtn_CheckChanged
      Me.chkIncorrect.AutoSize = True
      Me.chkIncorrect.Location = New System.Drawing.Point(28, 46)
      Me.chkIncorrect.Name = "chkIncorrect"
      Me.chkIncorrect.Size = New System.Drawing.Size(127, 17)
      Me.chkIncorrect.TabIndex = 3
      Me.chkIncorrect.Text = "Incorrect Responses:"
      Me.chkIncorrect.UseVisualStyleBackColor = True
      AddHandler Me.chkIncorrect.CheckedChanged, AddressOf Me.rdbtn_CheckChanged
      Me.chkCorrectModified.AutoSize = True
      Me.chkCorrectModified.Location = New System.Drawing.Point(28, 70)
      Me.chkCorrectModified.Name = "chkCorrectModified"
      Me.chkCorrectModified.Size = New System.Drawing.Size(170, 17)
      Me.chkCorrectModified.TabIndex = 4
      Me.chkCorrectModified.Text = "Reviewed Correct Responses:"
      Me.chkCorrectModified.UseVisualStyleBackColor = True
      AddHandler Me.chkCorrectModified.CheckedChanged, AddressOf Me.rdbtn_CheckChanged
      Me.chkIncorrectModified.AutoSize = True
      Me.chkIncorrectModified.Location = New System.Drawing.Point(28, 94)
      Me.chkIncorrectModified.Name = "chkIncorrectModified"
      Me.chkIncorrectModified.Size = New System.Drawing.Size(178, 17)
      Me.chkIncorrectModified.TabIndex = 5
      Me.chkIncorrectModified.Text = "Reviewed Incorrect Responses:"
      Me.chkIncorrectModified.UseVisualStyleBackColor = True
      AddHandler Me.chkIncorrectModified.CheckedChanged, AddressOf Me.rdbtn_CheckChanged
      Me.btnCorrect.Location = New System.Drawing.Point(224, 18)
      Me.btnCorrect.Name = "btnCorrect"
      Me.btnCorrect.Size = New System.Drawing.Size(75, 23)
      Me.btnCorrect.TabIndex = 6
      Me.btnCorrect.Text = "Change"
      Me.btnCorrect.UseVisualStyleBackColor = True
      AddHandler Me.btnCorrect.Click, AddressOf Me.btnColorChange_Click
      Me.btnIncorrect.Location = New System.Drawing.Point(224, 42)
      Me.btnIncorrect.Name = "btnIncorrect"
      Me.btnIncorrect.Size = New System.Drawing.Size(75, 23)
      Me.btnIncorrect.TabIndex = 7
      Me.btnIncorrect.Text = "Change"
      Me.btnIncorrect.UseVisualStyleBackColor = True
      AddHandler Me.btnIncorrect.Click, AddressOf Me.btnColorChange_Click
      Me.btnModCorrect.Location = New System.Drawing.Point(224, 66)
      Me.btnModCorrect.Name = "btnModCorrect"
      Me.btnModCorrect.Size = New System.Drawing.Size(75, 23)
      Me.btnModCorrect.TabIndex = 8
      Me.btnModCorrect.Text = "Change"
      Me.btnModCorrect.UseVisualStyleBackColor = True
      AddHandler Me.btnModCorrect.Click, AddressOf Me.btnColorChange_Click
      Me.btnModIncorrect.Location = New System.Drawing.Point(224, 90)
      Me.btnModIncorrect.Name = "btnModIncorrect"
      Me.btnModIncorrect.Size = New System.Drawing.Size(75, 23)
      Me.btnModIncorrect.TabIndex = 9
      Me.btnModIncorrect.Text = "Change"
      Me.btnModIncorrect.UseVisualStyleBackColor = True
      AddHandler Me.btnModIncorrect.Click, AddressOf Me.btnColorChange_Click
      Me.chkExpected.AutoSize = True
      Me.chkExpected.Location = New System.Drawing.Point(28, 118)
      Me.chkExpected.Name = "chkExpected"
      Me.chkExpected.Size = New System.Drawing.Size(85, 17)
      Me.chkExpected.TabIndex = 10
      Me.chkExpected.Text = "Answer Key:"
      Me.chkExpected.UseVisualStyleBackColor = True
      AddHandler Me.chkExpected.CheckedChanged, AddressOf Me.rdbtn_CheckChanged
      Me.btnExpected.Location = New System.Drawing.Point(224, 114)
      Me.btnExpected.Name = "btnExpected"
      Me.btnExpected.Size = New System.Drawing.Size(75, 23)
      Me.btnExpected.TabIndex = 11
      Me.btnExpected.Text = "Change"
      Me.btnExpected.UseVisualStyleBackColor = True
      AddHandler Me.btnExpected.Click, AddressOf Me.btnColorChange_Click
      Me.chkReview.AutoSize = True
      Me.chkReview.Location = New System.Drawing.Point(28, 142)
      Me.chkReview.Name = "chkReview"
      Me.chkReview.Size = New System.Drawing.Size(99, 17)
      Me.chkReview.TabIndex = 12
      Me.chkReview.Text = "Needs Review:"
      Me.chkReview.UseVisualStyleBackColor = True
      AddHandler Me.chkReview.CheckedChanged, AddressOf Me.rdbtn_CheckChanged
      Me.btnReview.Location = New System.Drawing.Point(224, 138)
      Me.btnReview.Name = "btnReview"
      Me.btnReview.Size = New System.Drawing.Size(75, 23)
      Me.btnReview.TabIndex = 13
      Me.btnReview.Text = "Change"
      Me.btnReview.UseVisualStyleBackColor = True
      AddHandler Me.btnReview.Click, AddressOf Me.btnColorChange_Click
      Me.btnCriteria.Location = New System.Drawing.Point(133, 138)
      Me.btnCriteria.Name = "btnCriteria"
      Me.btnCriteria.Size = New System.Drawing.Size(24, 23)
      Me.btnCriteria.TabIndex = 14
      Me.btnCriteria.Text = "..."
      Me.btnCriteria.UseVisualStyleBackColor = True
      AddHandler Me.btnCriteria.Click, AddressOf Me.btnCriteria_Click
      Me.btnApply.Location = New System.Drawing.Point(12, 205)
      Me.btnApply.Name = "btnApply"
      Me.btnApply.Size = New System.Drawing.Size(75, 23)
      Me.btnApply.TabIndex = 15
      Me.btnApply.Text = "&Apply"
      Me.btnApply.UseVisualStyleBackColor = True
      AddHandler Me.btnApply.Click, AddressOf Me.btnApply_Click
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(314, 241)
      Me.Controls.Add(Me.btnApply)
      Me.Controls.Add(Me.btnCriteria)
      Me.Controls.Add(Me.btnReview)
      Me.Controls.Add(Me.chkReview)
      Me.Controls.Add(Me.btnExpected)
      Me.Controls.Add(Me.chkExpected)
      Me.Controls.Add(Me.btnModIncorrect)
      Me.Controls.Add(Me.btnModCorrect)
      Me.Controls.Add(Me.btnIncorrect)
      Me.Controls.Add(Me.btnCorrect)
      Me.Controls.Add(Me.chkIncorrectModified)
      Me.Controls.Add(Me.chkCorrectModified)
      Me.Controls.Add(Me.chkIncorrect)
      Me.Controls.Add(Me.chkCorrect)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "HighlightOptionsDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Change Color Code"
      AddHandler Me.FormClosing, AddressOf Me.HighlightOptionsDialog_FormClosing
      AddHandler Me.Shown, AddressOf Me.HighlightOptionsDialog_Shown
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnOk As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private chkCorrect As System.Windows.Forms.CheckBox
   Private chkIncorrect As System.Windows.Forms.CheckBox
   Private chkCorrectModified As System.Windows.Forms.CheckBox
   Private chkIncorrectModified As System.Windows.Forms.CheckBox
   Private btnCorrect As System.Windows.Forms.Button
   Private btnIncorrect As System.Windows.Forms.Button
   Private btnModCorrect As System.Windows.Forms.Button
   Private btnModIncorrect As System.Windows.Forms.Button
   Private chkExpected As System.Windows.Forms.CheckBox
   Private btnExpected As System.Windows.Forms.Button
   Private chkReview As System.Windows.Forms.CheckBox
   Private btnReview As System.Windows.Forms.Button
   Private btnCriteria As System.Windows.Forms.Button
   Private btnApply As System.Windows.Forms.Button
End Class
