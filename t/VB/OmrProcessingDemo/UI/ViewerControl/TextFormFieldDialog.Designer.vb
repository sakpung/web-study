Partial Class OcrFieldDialog
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
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.grpTextType = New System.Windows.Forms.GroupBox()
      Me.rdbtnData = New System.Windows.Forms.RadioButton()
      Me.rdbtnNumerical = New System.Windows.Forms.RadioButton()
      Me.rdbtnCharacter = New System.Windows.Forms.RadioButton()
      Me.chkEnableOCR = New System.Windows.Forms.CheckBox()
      Me.grpTextType.SuspendLayout()
      Me.SuspendLayout()
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(125, 141)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(206, 141)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.lblName.AutoSize = True
      Me.lblName.Location = New System.Drawing.Point(12, 9)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(38, 13)
      Me.lblName.TabIndex = 2
      Me.lblName.Text = "Name:"
      Me.txtName.Location = New System.Drawing.Point(56, 6)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(225, 20)
      Me.txtName.TabIndex = 3
      Me.grpTextType.Controls.Add(Me.rdbtnData)
      Me.grpTextType.Controls.Add(Me.rdbtnNumerical)
      Me.grpTextType.Controls.Add(Me.rdbtnCharacter)
      Me.grpTextType.Location = New System.Drawing.Point(12, 32)
      Me.grpTextType.Name = "grpTextType"
      Me.grpTextType.Size = New System.Drawing.Size(101, 100)
      Me.grpTextType.TabIndex = 4
      Me.grpTextType.TabStop = False
      Me.grpTextType.Text = "Text Type"
      Me.rdbtnData.AutoSize = True
      Me.rdbtnData.Location = New System.Drawing.Point(6, 65)
      Me.rdbtnData.Name = "rdbtnData"
      Me.rdbtnData.Size = New System.Drawing.Size(48, 17)
      Me.rdbtnData.TabIndex = 2
      Me.rdbtnData.TabStop = True
      Me.rdbtnData.Text = "Data"
      Me.rdbtnData.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnData.CheckedChanged, AddressOf Me.rdBtnTextType_CheckChanged
      Me.rdbtnNumerical.AutoSize = True
      Me.rdbtnNumerical.Location = New System.Drawing.Point(6, 42)
      Me.rdbtnNumerical.Name = "rdbtnNumerical"
      Me.rdbtnNumerical.Size = New System.Drawing.Size(72, 17)
      Me.rdbtnNumerical.TabIndex = 1
      Me.rdbtnNumerical.TabStop = True
      Me.rdbtnNumerical.Text = "Numerical"
      Me.rdbtnNumerical.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnNumerical.CheckedChanged, AddressOf Me.rdBtnTextType_CheckChanged
      Me.rdbtnCharacter.AutoSize = True
      Me.rdbtnCharacter.Location = New System.Drawing.Point(6, 19)
      Me.rdbtnCharacter.Name = "rdbtnCharacter"
      Me.rdbtnCharacter.Size = New System.Drawing.Size(71, 17)
      Me.rdbtnCharacter.TabIndex = 0
      Me.rdbtnCharacter.TabStop = True
      Me.rdbtnCharacter.Text = "Character"
      Me.rdbtnCharacter.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnCharacter.CheckedChanged, AddressOf Me.rdBtnTextType_CheckChanged
      Me.chkEnableOCR.AutoSize = True
      Me.chkEnableOCR.Location = New System.Drawing.Point(125, 52)
      Me.chkEnableOCR.Name = "chkEnableOCR"
      Me.chkEnableOCR.Size = New System.Drawing.Size(85, 17)
      Me.chkEnableOCR.TabIndex = 5
      Me.chkEnableOCR.Text = "Enable OCR"
      Me.chkEnableOCR.UseVisualStyleBackColor = True
      AddHandler Me.chkEnableOCR.CheckedChanged, AddressOf Me.chkEnableOCR_CheckedChanged
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(296, 181)
      Me.Controls.Add(Me.chkEnableOCR)
      Me.Controls.Add(Me.grpTextType)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OcrFieldDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "TextField"
      AddHandler Me.FormClosing, AddressOf Me.OcrFieldDialog_FormClosing
      Me.grpTextType.ResumeLayout(False)
      Me.grpTextType.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private btnOK As System.Windows.Forms.Button
   Private btnCancel As System.Windows.Forms.Button
   Private lblName As System.Windows.Forms.Label
   Private txtName As System.Windows.Forms.TextBox
   Private grpTextType As System.Windows.Forms.GroupBox
   Private rdbtnData As System.Windows.Forms.RadioButton
   Private rdbtnNumerical As System.Windows.Forms.RadioButton
   Private rdbtnCharacter As System.Windows.Forms.RadioButton
   Private chkEnableOCR As System.Windows.Forms.CheckBox
End Class
