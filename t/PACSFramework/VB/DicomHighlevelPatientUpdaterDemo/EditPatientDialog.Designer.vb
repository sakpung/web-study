Namespace DicomDemo
   Partial Friend Class EditPatientDialog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditPatientDialog))
            Me.helpOtherPaitientIds = New System.Windows.Forms.Label()
            Me.textBoxOtherPid = New System.Windows.Forms.TextBox()
            Me.label12 = New System.Windows.Forms.Label()
            Me.CopyButton = New System.Windows.Forms.Button()
            Me.SearchButton = New System.Windows.Forms.Button()
            Me.ActionButton = New System.Windows.Forms.Button()
            Me.dateTimePickerBirth = New System.Windows.Forms.DateTimePicker()
            Me.comboBoxSex = New System.Windows.Forms.ComboBox()
            Me.textBoxFirstname = New System.Windows.Forms.TextBox()
            Me.textBoxLastname = New System.Windows.Forms.TextBox()
            Me.textBoxId = New System.Windows.Forms.TextBox()
            Me.label7 = New System.Windows.Forms.Label()
            Me.label8 = New System.Windows.Forms.Label()
            Me.label9 = New System.Windows.Forms.Label()
            Me.label10 = New System.Windows.Forms.Label()
            Me.label11 = New System.Windows.Forms.Label()
            Me.radioButtonMerge = New System.Windows.Forms.RadioButton()
            Me.label1 = New System.Windows.Forms.Label()
            Me.OtherPatientIds = New System.Windows.Forms.Label()
            Me.label13 = New System.Windows.Forms.Label()
            Me.DateOfBirth = New System.Windows.Forms.Label()
            Me.Sex = New System.Windows.Forms.Label()
            Me.FirstName = New System.Windows.Forms.Label()
            Me.LastName = New System.Windows.Forms.Label()
            Me.PatientId = New System.Windows.Forms.Label()
            Me.label6 = New System.Windows.Forms.Label()
            Me.label5 = New System.Windows.Forms.Label()
            Me.label4 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.radioButtonChange = New System.Windows.Forms.RadioButton()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.groupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'helpOtherPaitientIds
            '
            Me.helpOtherPaitientIds.AutoSize = True
            Me.helpOtherPaitientIds.ForeColor = System.Drawing.Color.Green
            Me.helpOtherPaitientIds.Location = New System.Drawing.Point(325, 152)
            Me.helpOtherPaitientIds.Name = "helpOtherPaitientIds"
            Me.helpOtherPaitientIds.Size = New System.Drawing.Size(289, 13)
            Me.helpOtherPaitientIds.TabIndex = 37
            Me.helpOtherPaitientIds.Text = "Multiple values separated by \     Example:  Pid1\Pid2\Pid3 "
            '
            'textBoxOtherPid
            '
            Me.textBoxOtherPid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.textBoxOtherPid.Location = New System.Drawing.Point(328, 129)
            Me.textBoxOtherPid.Name = "textBoxOtherPid"
            Me.textBoxOtherPid.Size = New System.Drawing.Size(284, 20)
            Me.textBoxOtherPid.TabIndex = 27
            '
            'label12
            '
            Me.label12.AutoSize = True
            Me.label12.ForeColor = System.Drawing.Color.Black
            Me.label12.Location = New System.Drawing.Point(256, 133)
            Me.label12.Name = "label12"
            Me.label12.Size = New System.Drawing.Size(68, 13)
            Me.label12.TabIndex = 26
            Me.label12.Text = "Other PID(s):"
            '
            'CopyButton
            '
            Me.CopyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CopyButton.Enabled = False
            Me.CopyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CopyButton.Location = New System.Drawing.Point(328, 354)
            Me.CopyButton.Name = "CopyButton"
            Me.CopyButton.Size = New System.Drawing.Size(131, 39)
            Me.CopyButton.TabIndex = 36
            Me.CopyButton.Text = "Copy"
            Me.CopyButton.UseVisualStyleBackColor = True
            '
            'SearchButton
            '
            Me.SearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchButton.Location = New System.Drawing.Point(542, 84)
            Me.SearchButton.Name = "SearchButton"
            Me.SearchButton.Size = New System.Drawing.Size(70, 23)
            Me.SearchButton.TabIndex = 25
            Me.SearchButton.Text = "Search"
            Me.SearchButton.UseVisualStyleBackColor = True
            Me.SearchButton.Visible = False
            '
            'ActionButton
            '
            Me.ActionButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ActionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.ActionButton.Location = New System.Drawing.Point(481, 354)
            Me.ActionButton.Name = "ActionButton"
            Me.ActionButton.Size = New System.Drawing.Size(131, 39)
            Me.ActionButton.TabIndex = 38
            Me.ActionButton.Text = "Change"
            Me.ActionButton.UseVisualStyleBackColor = True
            '
            'dateTimePickerBirth
            '
            Me.dateTimePickerBirth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateTimePickerBirth.Location = New System.Drawing.Point(328, 306)
            Me.dateTimePickerBirth.Name = "dateTimePickerBirth"
            Me.dateTimePickerBirth.ShowCheckBox = True
            Me.dateTimePickerBirth.Size = New System.Drawing.Size(284, 20)
            Me.dateTimePickerBirth.TabIndex = 35
            '
            'comboBoxSex
            '
            Me.comboBoxSex.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.comboBoxSex.FormattingEnabled = True
            Me.comboBoxSex.Items.AddRange(New Object() {"M", "F", "O", ""})
            Me.comboBoxSex.Location = New System.Drawing.Point(328, 261)
            Me.comboBoxSex.Name = "comboBoxSex"
            Me.comboBoxSex.Size = New System.Drawing.Size(284, 21)
            Me.comboBoxSex.TabIndex = 33
            '
            'textBoxFirstname
            '
            Me.textBoxFirstname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.textBoxFirstname.Location = New System.Drawing.Point(328, 217)
            Me.textBoxFirstname.Name = "textBoxFirstname"
            Me.textBoxFirstname.Size = New System.Drawing.Size(284, 20)
            Me.textBoxFirstname.TabIndex = 31
            '
            'textBoxLastname
            '
            Me.textBoxLastname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.textBoxLastname.Location = New System.Drawing.Point(328, 173)
            Me.textBoxLastname.Name = "textBoxLastname"
            Me.textBoxLastname.Size = New System.Drawing.Size(284, 20)
            Me.textBoxLastname.TabIndex = 29
            '
            'textBoxId
            '
            Me.textBoxId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.textBoxId.Location = New System.Drawing.Point(328, 85)
            Me.textBoxId.Name = "textBoxId"
            Me.textBoxId.Size = New System.Drawing.Size(208, 20)
            Me.textBoxId.TabIndex = 24
            '
            'label7
            '
            Me.label7.AutoSize = True
            Me.label7.ForeColor = System.Drawing.Color.Black
            Me.label7.Location = New System.Drawing.Point(255, 310)
            Me.label7.Name = "label7"
            Me.label7.Size = New System.Drawing.Size(69, 13)
            Me.label7.TabIndex = 34
            Me.label7.Text = "Date of Birth:"
            '
            'label8
            '
            Me.label8.AutoSize = True
            Me.label8.ForeColor = System.Drawing.Color.Black
            Me.label8.Location = New System.Drawing.Point(296, 265)
            Me.label8.Name = "label8"
            Me.label8.Size = New System.Drawing.Size(28, 13)
            Me.label8.TabIndex = 32
            Me.label8.Text = "Sex:"
            '
            'label9
            '
            Me.label9.AutoSize = True
            Me.label9.ForeColor = System.Drawing.Color.Black
            Me.label9.Location = New System.Drawing.Point(264, 221)
            Me.label9.Name = "label9"
            Me.label9.Size = New System.Drawing.Size(60, 13)
            Me.label9.TabIndex = 30
            Me.label9.Text = "First Name:"
            '
            'label10
            '
            Me.label10.AutoSize = True
            Me.label10.ForeColor = System.Drawing.Color.Black
            Me.label10.Location = New System.Drawing.Point(263, 177)
            Me.label10.Name = "label10"
            Me.label10.Size = New System.Drawing.Size(61, 13)
            Me.label10.TabIndex = 28
            Me.label10.Text = "Last Name:"
            '
            'label11
            '
            Me.label11.AutoSize = True
            Me.label11.ForeColor = System.Drawing.Color.Black
            Me.label11.Location = New System.Drawing.Point(267, 89)
            Me.label11.Name = "label11"
            Me.label11.Size = New System.Drawing.Size(57, 13)
            Me.label11.TabIndex = 23
            Me.label11.Text = "Patient ID:"
            '
            'radioButtonMerge
            '
            Me.radioButtonMerge.AutoSize = True
            Me.radioButtonMerge.Location = New System.Drawing.Point(417, 41)
            Me.radioButtonMerge.Name = "radioButtonMerge"
            Me.radioButtonMerge.Size = New System.Drawing.Size(184, 17)
            Me.radioButtonMerge.TabIndex = 22
            Me.radioButtonMerge.TabStop = True
            Me.radioButtonMerge.Text = "Merge with another patient record"
            Me.radioButtonMerge.UseVisualStyleBackColor = True
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label1.Location = New System.Drawing.Point(240, 12)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(296, 25)
            Me.label1.TabIndex = 20
            Me.label1.Text = "What would you like to do?"
            '
            'OtherPatientIds
            '
            Me.OtherPatientIds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.OtherPatientIds.ForeColor = System.Drawing.Color.Black
            Me.OtherPatientIds.Location = New System.Drawing.Point(67, 92)
            Me.OtherPatientIds.Name = "OtherPatientIds"
            Me.OtherPatientIds.Size = New System.Drawing.Size(172, 13)
            Me.OtherPatientIds.TabIndex = 3
            Me.OtherPatientIds.Text = "label7"
            '
            'label13
            '
            Me.label13.AutoSize = True
            Me.label13.ForeColor = System.Drawing.Color.Black
            Me.label13.Location = New System.Drawing.Point(1, 92)
            Me.label13.Name = "label13"
            Me.label13.Size = New System.Drawing.Size(68, 13)
            Me.label13.TabIndex = 2
            Me.label13.Text = "Other PID(s):"
            '
            'DateOfBirth
            '
            Me.DateOfBirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DateOfBirth.ForeColor = System.Drawing.Color.Black
            Me.DateOfBirth.Location = New System.Drawing.Point(67, 269)
            Me.DateOfBirth.Name = "DateOfBirth"
            Me.DateOfBirth.Size = New System.Drawing.Size(172, 13)
            Me.DateOfBirth.TabIndex = 11
            Me.DateOfBirth.Text = "label7"
            '
            'Sex
            '
            Me.Sex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Sex.ForeColor = System.Drawing.Color.Black
            Me.Sex.Location = New System.Drawing.Point(67, 224)
            Me.Sex.Name = "Sex"
            Me.Sex.Size = New System.Drawing.Size(172, 13)
            Me.Sex.TabIndex = 9
            Me.Sex.Text = "label7"
            '
            'FirstName
            '
            Me.FirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FirstName.ForeColor = System.Drawing.Color.Black
            Me.FirstName.Location = New System.Drawing.Point(67, 179)
            Me.FirstName.Name = "FirstName"
            Me.FirstName.Size = New System.Drawing.Size(172, 13)
            Me.FirstName.TabIndex = 7
            Me.FirstName.Text = "label7"
            '
            'LastName
            '
            Me.LastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LastName.ForeColor = System.Drawing.Color.Black
            Me.LastName.Location = New System.Drawing.Point(67, 136)
            Me.LastName.Name = "LastName"
            Me.LastName.Size = New System.Drawing.Size(172, 13)
            Me.LastName.TabIndex = 5
            Me.LastName.Text = "label7"
            '
            'PatientId
            '
            Me.PatientId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.PatientId.ForeColor = System.Drawing.Color.Black
            Me.PatientId.Location = New System.Drawing.Point(67, 47)
            Me.PatientId.Name = "PatientId"
            Me.PatientId.Size = New System.Drawing.Size(172, 13)
            Me.PatientId.TabIndex = 1
            Me.PatientId.Text = "label7"
            '
            'label6
            '
            Me.label6.AutoSize = True
            Me.label6.ForeColor = System.Drawing.Color.Black
            Me.label6.Location = New System.Drawing.Point(0, 269)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(69, 13)
            Me.label6.TabIndex = 10
            Me.label6.Text = "Date of Birth:"
            '
            'label5
            '
            Me.label5.AutoSize = True
            Me.label5.ForeColor = System.Drawing.Color.Black
            Me.label5.Location = New System.Drawing.Point(41, 224)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(28, 13)
            Me.label5.TabIndex = 8
            Me.label5.Text = "Sex:"
            '
            'label4
            '
            Me.label4.AutoSize = True
            Me.label4.ForeColor = System.Drawing.Color.Black
            Me.label4.Location = New System.Drawing.Point(9, 179)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(60, 13)
            Me.label4.TabIndex = 6
            Me.label4.Text = "First Name:"
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.ForeColor = System.Drawing.Color.Black
            Me.label3.Location = New System.Drawing.Point(8, 136)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(61, 13)
            Me.label3.TabIndex = 4
            Me.label3.Text = "Last Name:"
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.ForeColor = System.Drawing.Color.Black
            Me.label2.Location = New System.Drawing.Point(12, 47)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(57, 13)
            Me.label2.TabIndex = 0
            Me.label2.Text = "Patient ID:"
            '
            'radioButtonChange
            '
            Me.radioButtonChange.AutoSize = True
            Me.radioButtonChange.Location = New System.Drawing.Point(271, 41)
            Me.radioButtonChange.Name = "radioButtonChange"
            Me.radioButtonChange.Size = New System.Drawing.Size(119, 17)
            Me.radioButtonChange.TabIndex = 21
            Me.radioButtonChange.TabStop = True
            Me.radioButtonChange.Text = "Change Patient Info"
            Me.radioButtonChange.UseVisualStyleBackColor = True
            '
            'groupBox1
            '
            Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.groupBox1.Controls.Add(Me.OtherPatientIds)
            Me.groupBox1.Controls.Add(Me.label13)
            Me.groupBox1.Controls.Add(Me.DateOfBirth)
            Me.groupBox1.Controls.Add(Me.Sex)
            Me.groupBox1.Controls.Add(Me.FirstName)
            Me.groupBox1.Controls.Add(Me.LastName)
            Me.groupBox1.Controls.Add(Me.PatientId)
            Me.groupBox1.Controls.Add(Me.label6)
            Me.groupBox1.Controls.Add(Me.label5)
            Me.groupBox1.Controls.Add(Me.label4)
            Me.groupBox1.Controls.Add(Me.label3)
            Me.groupBox1.Controls.Add(Me.label2)
            Me.groupBox1.ForeColor = System.Drawing.Color.Blue
            Me.groupBox1.Location = New System.Drawing.Point(10, 41)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(245, 352)
            Me.groupBox1.TabIndex = 39
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Existing Patient Info"
            '
            'EditPatientDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 405)
            Me.Controls.Add(Me.helpOtherPaitientIds)
            Me.Controls.Add(Me.textBoxOtherPid)
            Me.Controls.Add(Me.label12)
            Me.Controls.Add(Me.CopyButton)
            Me.Controls.Add(Me.SearchButton)
            Me.Controls.Add(Me.ActionButton)
            Me.Controls.Add(Me.dateTimePickerBirth)
            Me.Controls.Add(Me.comboBoxSex)
            Me.Controls.Add(Me.textBoxFirstname)
            Me.Controls.Add(Me.textBoxLastname)
            Me.Controls.Add(Me.textBoxId)
            Me.Controls.Add(Me.label7)
            Me.Controls.Add(Me.label8)
            Me.Controls.Add(Me.label9)
            Me.Controls.Add(Me.label10)
            Me.Controls.Add(Me.label11)
            Me.Controls.Add(Me.radioButtonMerge)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.radioButtonChange)
            Me.Controls.Add(Me.groupBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EditPatientDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Edit Patient"
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private WithEvents helpOtherPaitientIds As System.Windows.Forms.Label
        Private WithEvents textBoxOtherPid As System.Windows.Forms.TextBox
        Private WithEvents label12 As System.Windows.Forms.Label
        Private WithEvents CopyButton As System.Windows.Forms.Button
        Private WithEvents SearchButton As System.Windows.Forms.Button
        Private WithEvents ActionButton As System.Windows.Forms.Button
        Private WithEvents dateTimePickerBirth As System.Windows.Forms.DateTimePicker
        Private WithEvents comboBoxSex As System.Windows.Forms.ComboBox
        Private WithEvents textBoxFirstname As System.Windows.Forms.TextBox
        Private WithEvents textBoxLastname As System.Windows.Forms.TextBox
        Private WithEvents textBoxId As System.Windows.Forms.TextBox
        Private WithEvents label7 As System.Windows.Forms.Label
        Private WithEvents label8 As System.Windows.Forms.Label
        Private WithEvents label9 As System.Windows.Forms.Label
        Private WithEvents label10 As System.Windows.Forms.Label
        Private WithEvents label11 As System.Windows.Forms.Label
        Private WithEvents radioButtonMerge As System.Windows.Forms.RadioButton
        Private WithEvents label1 As System.Windows.Forms.Label
        Private WithEvents OtherPatientIds As System.Windows.Forms.Label
        Private WithEvents label13 As System.Windows.Forms.Label
        Private WithEvents DateOfBirth As System.Windows.Forms.Label
        Private WithEvents Sex As System.Windows.Forms.Label
        Private WithEvents FirstName As System.Windows.Forms.Label
        Private WithEvents LastName As System.Windows.Forms.Label
        Private WithEvents PatientId As System.Windows.Forms.Label
        Private WithEvents label6 As System.Windows.Forms.Label
        Private WithEvents label5 As System.Windows.Forms.Label
        Private WithEvents label4 As System.Windows.Forms.Label
        Private WithEvents label3 As System.Windows.Forms.Label
        Private WithEvents label2 As System.Windows.Forms.Label
        Private WithEvents radioButtonChange As System.Windows.Forms.RadioButton
        Private WithEvents groupBox1 As System.Windows.Forms.GroupBox

#End Region
    End Class
End Namespace