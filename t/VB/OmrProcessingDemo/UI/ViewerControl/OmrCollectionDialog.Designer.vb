Partial Class OmrCollectionDialog
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
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblValue = New System.Windows.Forms.Label()
      Me.grpGradingOptions = New System.Windows.Forms.GroupBox()
      Me.label10 = New System.Windows.Forms.Label()
      Me.label9 = New System.Windows.Forms.Label()
      Me.label8 = New System.Windows.Forms.Label()
      Me._numNoResponse = New System.Windows.Forms.NumericUpDown()
      Me._numIncorrect = New System.Windows.Forms.NumericUpDown()
      Me._numCorrect = New System.Windows.Forms.NumericUpDown()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNotes = New System.Windows.Forms.Label()
      Me.grpGradingOptions.SuspendLayout()
      CType(Me._numNoResponse, System.ComponentModel.ISupportInitialize).BeginInit()
      CType((Me._numIncorrect), System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(279, 167)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 7
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(198, 167)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 6
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.txtName.Location = New System.Drawing.Point(55, 9)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(299, 20)
      Me.txtName.TabIndex = 5
      Me.lblValue.AutoSize = True
      Me.lblValue.Location = New System.Drawing.Point(12, 12)
      Me.lblValue.Name = "lblValue"
      Me.lblValue.Size = New System.Drawing.Size(37, 13)
      Me.lblValue.TabIndex = 4
      Me.lblValue.Text = "Value:"
      Me.grpGradingOptions.Controls.Add(Me.label10)
      Me.grpGradingOptions.Controls.Add(Me.label9)
      Me.grpGradingOptions.Controls.Add(Me.label8)
      Me.grpGradingOptions.Controls.Add(Me._numNoResponse)
      Me.grpGradingOptions.Controls.Add(Me._numIncorrect)
      Me.grpGradingOptions.Controls.Add(Me._numCorrect)
      Me.grpGradingOptions.Location = New System.Drawing.Point(15, 61)
      Me.grpGradingOptions.Name = "grpGradingOptions"
      Me.grpGradingOptions.Size = New System.Drawing.Size(339, 100)
      Me.grpGradingOptions.TabIndex = 27
      Me.grpGradingOptions.TabStop = False
      Me.grpGradingOptions.Text = "Grading Options"
      Me.label10.AutoSize = True
      Me.label10.Location = New System.Drawing.Point(12, 73)
      Me.label10.Name = "label10"
      Me.label10.Size = New System.Drawing.Size(72, 13)
      Me.label10.TabIndex = 34
      Me.label10.Text = "No Response"
      Me.label9.AutoSize = True
      Me.label9.Location = New System.Drawing.Point(12, 47)
      Me.label9.Name = "label9"
      Me.label9.Size = New System.Drawing.Size(49, 13)
      Me.label9.TabIndex = 33
      Me.label9.Text = "Incorrect"
      Me.label8.AutoSize = True
      Me.label8.Location = New System.Drawing.Point(12, 21)
      Me.label8.Name = "label8"
      Me.label8.Size = New System.Drawing.Size(41, 13)
      Me.label8.TabIndex = 32
      Me.label8.Text = "Correct"
      Me._numNoResponse.DecimalPlaces = 2
      Me._numNoResponse.Location = New System.Drawing.Point(98, 71)
      Me._numNoResponse.Name = "_numNoResponse"
      Me._numNoResponse.Size = New System.Drawing.Size(76, 20)
      Me._numNoResponse.TabIndex = 31
      Me._numIncorrect.DecimalPlaces = 2
      Me._numIncorrect.Location = New System.Drawing.Point(97, 45)
      Me._numIncorrect.Name = "_numIncorrect"
      Me._numIncorrect.Size = New System.Drawing.Size(76, 20)
      Me._numIncorrect.TabIndex = 30
      Me._numCorrect.DecimalPlaces = 2
      Me._numCorrect.Location = New System.Drawing.Point(97, 19)
      Me._numCorrect.Name = "_numCorrect"
      Me._numCorrect.Size = New System.Drawing.Size(76, 20)
      Me._numCorrect.TabIndex = 29
      Me._numCorrect.Value = New Decimal(New Integer() {1, 0, 0, 0})
      Me.txtNote.Location = New System.Drawing.Point(55, 35)
      Me.txtNote.Name = "txtNote"
      Me.txtNote.Size = New System.Drawing.Size(299, 20)
      Me.txtNote.TabIndex = 29
      Me.lblNotes.AutoSize = True
      Me.lblNotes.Location = New System.Drawing.Point(12, 38)
      Me.lblNotes.Name = "lblNotes"
      Me.lblNotes.Size = New System.Drawing.Size(38, 13)
      Me.lblNotes.TabIndex = 28
      Me.lblNotes.Text = "Notes:"
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(366, 200)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.lblNotes)
      Me.Controls.Add(Me.grpGradingOptions)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.lblValue)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OmrCollectionDialog"
      Me.Text = "Update"
      AddHandler Me.FormClosing, AddressOf Me.OmrCollectionDialog_FormClosing
      Me.grpGradingOptions.ResumeLayout(False)
      Me.grpGradingOptions.PerformLayout()
      CType(Me._numNoResponse, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numCorrect, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnCancel As System.Windows.Forms.Button
   Private btnOK As System.Windows.Forms.Button
   Private txtName As System.Windows.Forms.TextBox
   Private lblValue As System.Windows.Forms.Label
   Private grpGradingOptions As System.Windows.Forms.GroupBox
   Private label10 As System.Windows.Forms.Label
   Private label9 As System.Windows.Forms.Label
   Private label8 As System.Windows.Forms.Label
   Private _numNoResponse As System.Windows.Forms.NumericUpDown
   Private _numIncorrect As System.Windows.Forms.NumericUpDown
   Private _numCorrect As System.Windows.Forms.NumericUpDown
   Private txtNote As System.Windows.Forms.TextBox
   Private lblNotes As System.Windows.Forms.Label
End Class
