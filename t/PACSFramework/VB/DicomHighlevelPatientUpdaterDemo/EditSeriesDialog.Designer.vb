Namespace DicomDemo
   Partial Friend Class EditSeriesDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditSeriesDialog))
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
         Me.radioButtonChange = New System.Windows.Forms.RadioButton()
         Me.label1 = New System.Windows.Forms.Label()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
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
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.SeriesTime = New System.Windows.Forms.Label()
         Me.label16 = New System.Windows.Forms.Label()
         Me.SeriesModality = New System.Windows.Forms.Label()
         Me.SeriesDescription = New System.Windows.Forms.Label()
         Me.SeriesDate = New System.Windows.Forms.Label()
         Me.label19 = New System.Windows.Forms.Label()
         Me.label20 = New System.Windows.Forms.Label()
         Me.label21 = New System.Windows.Forms.Label()
         Me.dateTimePickerSeriesDate = New System.Windows.Forms.DateTimePicker()
         Me.label12 = New System.Windows.Forms.Label()
         Me.textBoxDescription = New System.Windows.Forms.TextBox()
         Me.label13 = New System.Windows.Forms.Label()
         Me.label14 = New System.Windows.Forms.Label()
         Me.comboBoxModality = New System.Windows.Forms.ComboBox()
         Me.radioButtonMove = New System.Windows.Forms.RadioButton()
         Me.CopyButton = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' SearchButton
         ' 
         Me.SearchButton.Location = New System.Drawing.Point(500, 91)
         Me.SearchButton.Name = "SearchButton"
         Me.SearchButton.Size = New System.Drawing.Size(94, 23)
         Me.SearchButton.TabIndex = 32
         Me.SearchButton.Text = "Search"
         Me.SearchButton.UseVisualStyleBackColor = True
         Me.SearchButton.Visible = False
         ' 
         ' ActionButton
         ' 
         Me.ActionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me.ActionButton.Location = New System.Drawing.Point(463, 380)
         Me.ActionButton.Name = "ActionButton"
         Me.ActionButton.Size = New System.Drawing.Size(131, 39)
         Me.ActionButton.TabIndex = 31
         Me.ActionButton.Text = "Change"
         Me.ActionButton.UseVisualStyleBackColor = True
         ' 
         ' dateTimePickerBirth
         ' 
         Me.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short
         Me.dateTimePickerBirth.Location = New System.Drawing.Point(319, 235)
         Me.dateTimePickerBirth.Name = "dateTimePickerBirth"
         Me.dateTimePickerBirth.ShowCheckBox = True
         Me.dateTimePickerBirth.Size = New System.Drawing.Size(275, 20)
         Me.dateTimePickerBirth.TabIndex = 30
         ' 
         ' comboBoxSex
         ' 
         Me.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxSex.FormattingEnabled = True
         Me.comboBoxSex.Items.AddRange(New Object() {"M", "F", "O", ""})
         Me.comboBoxSex.Location = New System.Drawing.Point(319, 198)
         Me.comboBoxSex.Name = "comboBoxSex"
         Me.comboBoxSex.Size = New System.Drawing.Size(275, 21)
         Me.comboBoxSex.TabIndex = 29
         ' 
         ' textBoxFirstname
         ' 
         Me.textBoxFirstname.Location = New System.Drawing.Point(319, 168)
         Me.textBoxFirstname.Name = "textBoxFirstname"
         Me.textBoxFirstname.Size = New System.Drawing.Size(275, 20)
         Me.textBoxFirstname.TabIndex = 28
         ' 
         ' textBoxLastname
         ' 
         Me.textBoxLastname.Location = New System.Drawing.Point(319, 133)
         Me.textBoxLastname.Name = "textBoxLastname"
         Me.textBoxLastname.Size = New System.Drawing.Size(275, 20)
         Me.textBoxLastname.TabIndex = 27
         ' 
         ' textBoxId
         ' 
         Me.textBoxId.Location = New System.Drawing.Point(319, 94)
         Me.textBoxId.Name = "textBoxId"
         Me.textBoxId.Size = New System.Drawing.Size(175, 20)
         Me.textBoxId.TabIndex = 26
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.ForeColor = System.Drawing.Color.Black
         Me.label7.Location = New System.Drawing.Point(244, 241)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(69, 13)
         Me.label7.TabIndex = 25
         Me.label7.Text = "Date of Birth:"
         ' 
         ' label8
         ' 
         Me.label8.AutoSize = True
         Me.label8.ForeColor = System.Drawing.Color.Black
         Me.label8.Location = New System.Drawing.Point(285, 206)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(28, 13)
         Me.label8.TabIndex = 24
         Me.label8.Text = "Sex:"
         ' 
         ' label9
         ' 
         Me.label9.AutoSize = True
         Me.label9.ForeColor = System.Drawing.Color.Black
         Me.label9.Location = New System.Drawing.Point(253, 171)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(60, 13)
         Me.label9.TabIndex = 23
         Me.label9.Text = "First Name:"
         ' 
         ' label10
         ' 
         Me.label10.AutoSize = True
         Me.label10.ForeColor = System.Drawing.Color.Black
         Me.label10.Location = New System.Drawing.Point(252, 136)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(61, 13)
         Me.label10.TabIndex = 22
         Me.label10.Text = "Last Name:"
         ' 
         ' label11
         ' 
         Me.label11.AutoSize = True
         Me.label11.ForeColor = System.Drawing.Color.Black
         Me.label11.Location = New System.Drawing.Point(256, 101)
         Me.label11.Name = "label11"
         Me.label11.Size = New System.Drawing.Size(57, 13)
         Me.label11.TabIndex = 21
         Me.label11.Text = "Patient ID:"
         ' 
         ' radioButtonMerge
         ' 
         Me.radioButtonMerge.AutoSize = True
         Me.radioButtonMerge.Location = New System.Drawing.Point(419, 41)
         Me.radioButtonMerge.Name = "radioButtonMerge"
         Me.radioButtonMerge.Size = New System.Drawing.Size(165, 17)
         Me.radioButtonMerge.TabIndex = 20
         Me.radioButtonMerge.Text = "Move study to existing patient"
         Me.radioButtonMerge.UseVisualStyleBackColor = True
         ' 
         ' radioButtonChange
         ' 
         Me.radioButtonChange.AutoSize = True
         Me.radioButtonChange.Checked = True
         Me.radioButtonChange.Location = New System.Drawing.Point(247, 41)
         Me.radioButtonChange.Name = "radioButtonChange"
         Me.radioButtonChange.Size = New System.Drawing.Size(115, 17)
         Me.radioButtonChange.TabIndex = 19
         Me.radioButtonChange.TabStop = True
         Me.radioButtonChange.Text = "Change Series Info"
         Me.radioButtonChange.UseVisualStyleBackColor = True
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.label1.Location = New System.Drawing.Point(242, 12)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(296, 25)
         Me.label1.TabIndex = 18
         Me.label1.Text = "What would you like to do?"
         ' 
         ' groupBox1
         ' 
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
         Me.groupBox1.Location = New System.Drawing.Point(12, 41)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(224, 193)
         Me.groupBox1.TabIndex = 17
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Existing Patient Info"
         ' 
         ' DateOfBirth
         ' 
         Me.DateOfBirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.DateOfBirth.ForeColor = System.Drawing.Color.Black
         Me.DateOfBirth.Location = New System.Drawing.Point(80, 165)
         Me.DateOfBirth.Name = "DateOfBirth"
         Me.DateOfBirth.Size = New System.Drawing.Size(136, 13)
         Me.DateOfBirth.TabIndex = 9
         Me.DateOfBirth.Text = "label7"
         ' 
         ' Sex
         ' 
         Me.Sex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.Sex.ForeColor = System.Drawing.Color.Black
         Me.Sex.Location = New System.Drawing.Point(80, 130)
         Me.Sex.Name = "Sex"
         Me.Sex.Size = New System.Drawing.Size(136, 13)
         Me.Sex.TabIndex = 8
         Me.Sex.Text = "label7"
         ' 
         ' FirstName
         ' 
         Me.FirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.FirstName.ForeColor = System.Drawing.Color.Black
         Me.FirstName.Location = New System.Drawing.Point(80, 95)
         Me.FirstName.Name = "FirstName"
         Me.FirstName.Size = New System.Drawing.Size(136, 13)
         Me.FirstName.TabIndex = 7
         Me.FirstName.Text = "label7"
         ' 
         ' LastName
         ' 
         Me.LastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.LastName.ForeColor = System.Drawing.Color.Black
         Me.LastName.Location = New System.Drawing.Point(80, 60)
         Me.LastName.Name = "LastName"
         Me.LastName.Size = New System.Drawing.Size(136, 13)
         Me.LastName.TabIndex = 6
         Me.LastName.Text = "label7"
         ' 
         ' PatientId
         ' 
         Me.PatientId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.PatientId.ForeColor = System.Drawing.Color.Black
         Me.PatientId.Location = New System.Drawing.Point(80, 24)
         Me.PatientId.Name = "PatientId"
         Me.PatientId.Size = New System.Drawing.Size(136, 13)
         Me.PatientId.TabIndex = 5
         Me.PatientId.Text = "label7"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.ForeColor = System.Drawing.Color.Black
         Me.label6.Location = New System.Drawing.Point(5, 165)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(69, 13)
         Me.label6.TabIndex = 4
         Me.label6.Text = "Date of Birth:"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.ForeColor = System.Drawing.Color.Black
         Me.label5.Location = New System.Drawing.Point(46, 130)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(28, 13)
         Me.label5.TabIndex = 3
         Me.label5.Text = "Sex:"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.ForeColor = System.Drawing.Color.Black
         Me.label4.Location = New System.Drawing.Point(14, 95)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(60, 13)
         Me.label4.TabIndex = 2
         Me.label4.Text = "First Name:"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.ForeColor = System.Drawing.Color.Black
         Me.label3.Location = New System.Drawing.Point(13, 60)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(61, 13)
         Me.label3.TabIndex = 1
         Me.label3.Text = "Last Name:"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.ForeColor = System.Drawing.Color.Black
         Me.label2.Location = New System.Drawing.Point(17, 25)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(57, 13)
         Me.label2.TabIndex = 0
         Me.label2.Text = "Patient ID:"
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.SeriesTime)
         Me.groupBox2.Controls.Add(Me.label16)
         Me.groupBox2.Controls.Add(Me.SeriesModality)
         Me.groupBox2.Controls.Add(Me.SeriesDescription)
         Me.groupBox2.Controls.Add(Me.SeriesDate)
         Me.groupBox2.Controls.Add(Me.label19)
         Me.groupBox2.Controls.Add(Me.label20)
         Me.groupBox2.Controls.Add(Me.label21)
         Me.groupBox2.ForeColor = System.Drawing.Color.Blue
         Me.groupBox2.Location = New System.Drawing.Point(12, 240)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(224, 179)
         Me.groupBox2.TabIndex = 33
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Existing Series Info"
         ' 
         ' SeriesTime
         ' 
         Me.SeriesTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.SeriesTime.ForeColor = System.Drawing.Color.Black
         Me.SeriesTime.Location = New System.Drawing.Point(80, 58)
         Me.SeriesTime.Name = "SeriesTime"
         Me.SeriesTime.Size = New System.Drawing.Size(136, 13)
         Me.SeriesTime.TabIndex = 9
         Me.SeriesTime.Text = "label7"
         ' 
         ' label16
         ' 
         Me.label16.AutoSize = True
         Me.label16.ForeColor = System.Drawing.Color.Black
         Me.label16.Location = New System.Drawing.Point(17, 58)
         Me.label16.Name = "label16"
         Me.label16.Size = New System.Drawing.Size(65, 13)
         Me.label16.TabIndex = 8
         Me.label16.Text = "Series Time:"
         ' 
         ' SeriesModality
         ' 
         Me.SeriesModality.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.SeriesModality.ForeColor = System.Drawing.Color.Black
         Me.SeriesModality.Location = New System.Drawing.Point(80, 125)
         Me.SeriesModality.Name = "SeriesModality"
         Me.SeriesModality.Size = New System.Drawing.Size(136, 13)
         Me.SeriesModality.TabIndex = 7
         Me.SeriesModality.Text = "label7"
         ' 
         ' SeriesDescription
         ' 
         Me.SeriesDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.SeriesDescription.ForeColor = System.Drawing.Color.Black
         Me.SeriesDescription.Location = New System.Drawing.Point(80, 90)
         Me.SeriesDescription.Name = "SeriesDescription"
         Me.SeriesDescription.Size = New System.Drawing.Size(136, 13)
         Me.SeriesDescription.TabIndex = 6
         Me.SeriesDescription.Text = "label7"
         ' 
         ' SeriesDate
         ' 
         Me.SeriesDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.SeriesDate.ForeColor = System.Drawing.Color.Black
         Me.SeriesDate.Location = New System.Drawing.Point(80, 30)
         Me.SeriesDate.Name = "SeriesDate"
         Me.SeriesDate.Size = New System.Drawing.Size(136, 13)
         Me.SeriesDate.TabIndex = 5
         Me.SeriesDate.Text = "label7"
         ' 
         ' label19
         ' 
         Me.label19.AutoSize = True
         Me.label19.ForeColor = System.Drawing.Color.Black
         Me.label19.Location = New System.Drawing.Point(33, 125)
         Me.label19.Name = "label19"
         Me.label19.Size = New System.Drawing.Size(49, 13)
         Me.label19.TabIndex = 2
         Me.label19.Text = "Modality:"
         ' 
         ' label20
         ' 
         Me.label20.AutoSize = True
         Me.label20.ForeColor = System.Drawing.Color.Black
         Me.label20.Location = New System.Drawing.Point(15, 90)
         Me.label20.Name = "label20"
         Me.label20.Size = New System.Drawing.Size(67, 13)
         Me.label20.TabIndex = 1
         Me.label20.Text = "Series Desc:"
         ' 
         ' label21
         ' 
         Me.label21.AutoSize = True
         Me.label21.ForeColor = System.Drawing.Color.Black
         Me.label21.Location = New System.Drawing.Point(17, 30)
         Me.label21.Name = "label21"
         Me.label21.Size = New System.Drawing.Size(65, 13)
         Me.label21.TabIndex = 0
         Me.label21.Text = "Series Date:"
         ' 
         ' dateTimePickerSeriesDate
         ' 
         Me.dateTimePickerSeriesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
         Me.dateTimePickerSeriesDate.Location = New System.Drawing.Point(319, 273)
         Me.dateTimePickerSeriesDate.Name = "dateTimePickerSeriesDate"
         Me.dateTimePickerSeriesDate.ShowCheckBox = True
         Me.dateTimePickerSeriesDate.Size = New System.Drawing.Size(275, 20)
         Me.dateTimePickerSeriesDate.TabIndex = 35
         ' 
         ' label12
         ' 
         Me.label12.AutoSize = True
         Me.label12.ForeColor = System.Drawing.Color.Black
         Me.label12.Location = New System.Drawing.Point(248, 279)
         Me.label12.Name = "label12"
         Me.label12.Size = New System.Drawing.Size(65, 13)
         Me.label12.TabIndex = 34
         Me.label12.Text = "Series Date:"
         ' 
         ' textBoxDescription
         ' 
         Me.textBoxDescription.Location = New System.Drawing.Point(319, 308)
         Me.textBoxDescription.Name = "textBoxDescription"
         Me.textBoxDescription.Size = New System.Drawing.Size(275, 20)
         Me.textBoxDescription.TabIndex = 37
         ' 
         ' label13
         ' 
         Me.label13.AutoSize = True
         Me.label13.ForeColor = System.Drawing.Color.Black
         Me.label13.Location = New System.Drawing.Point(246, 311)
         Me.label13.Name = "label13"
         Me.label13.Size = New System.Drawing.Size(67, 13)
         Me.label13.TabIndex = 36
         Me.label13.Text = "Series Desc:"
         ' 
         ' label14
         ' 
         Me.label14.AutoSize = True
         Me.label14.ForeColor = System.Drawing.Color.Black
         Me.label14.Location = New System.Drawing.Point(264, 346)
         Me.label14.Name = "label14"
         Me.label14.Size = New System.Drawing.Size(49, 13)
         Me.label14.TabIndex = 38
         Me.label14.Text = "Modality:"
         ' 
         ' comboBoxModality
         ' 
         Me.comboBoxModality.FormattingEnabled = True
         Me.comboBoxModality.Location = New System.Drawing.Point(319, 338)
         Me.comboBoxModality.Name = "comboBoxModality"
         Me.comboBoxModality.Size = New System.Drawing.Size(275, 21)
         Me.comboBoxModality.TabIndex = 39
         ' 
         ' radioButtonMove
         ' 
         Me.radioButtonMove.AutoSize = True
         Me.radioButtonMove.Location = New System.Drawing.Point(247, 62)
         Me.radioButtonMove.Name = "radioButtonMove"
         Me.radioButtonMove.Size = New System.Drawing.Size(150, 17)
         Me.radioButtonMove.TabIndex = 40
         Me.radioButtonMove.Text = "Move study to new patient"
         Me.radioButtonMove.UseVisualStyleBackColor = True
         ' 
         ' CopyButton
         ' 
         Me.CopyButton.Enabled = False
         Me.CopyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me.CopyButton.Location = New System.Drawing.Point(319, 380)
         Me.CopyButton.Name = "CopyButton"
         Me.CopyButton.Size = New System.Drawing.Size(131, 39)
         Me.CopyButton.TabIndex = 41
         Me.CopyButton.Text = "Copy"
         Me.CopyButton.UseVisualStyleBackColor = True
         ' 
         ' EditSeriesDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(616, 431)
         Me.Controls.Add(Me.CopyButton)
         Me.Controls.Add(Me.radioButtonMove)
         Me.Controls.Add(Me.comboBoxModality)
         Me.Controls.Add(Me.label14)
         Me.Controls.Add(Me.textBoxDescription)
         Me.Controls.Add(Me.label13)
         Me.Controls.Add(Me.dateTimePickerSeriesDate)
         Me.Controls.Add(Me.label12)
         Me.Controls.Add(Me.groupBox2)
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
         Me.Controls.Add(Me.radioButtonChange)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "EditSeriesDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Edit Series"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents SearchButton As System.Windows.Forms.Button
      Private WithEvents ActionButton As System.Windows.Forms.Button
      Private dateTimePickerBirth As System.Windows.Forms.DateTimePicker
      Private comboBoxSex As System.Windows.Forms.ComboBox
      Private WithEvents textBoxFirstname As System.Windows.Forms.TextBox
      Private WithEvents textBoxLastname As System.Windows.Forms.TextBox
      Private WithEvents textBoxId As System.Windows.Forms.TextBox
      Private label7 As System.Windows.Forms.Label
      Private label8 As System.Windows.Forms.Label
      Private label9 As System.Windows.Forms.Label
      Private label10 As System.Windows.Forms.Label
      Private label11 As System.Windows.Forms.Label
      Private WithEvents radioButtonMerge As System.Windows.Forms.RadioButton
      Private WithEvents radioButtonChange As System.Windows.Forms.RadioButton
      Private label1 As System.Windows.Forms.Label
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private DateOfBirth As System.Windows.Forms.Label
      Private Sex As System.Windows.Forms.Label
      Private FirstName As System.Windows.Forms.Label
      Private LastName As System.Windows.Forms.Label
      Private PatientId As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private SeriesModality As System.Windows.Forms.Label
      Private SeriesDescription As System.Windows.Forms.Label
      Private SeriesDate As System.Windows.Forms.Label
      Private label19 As System.Windows.Forms.Label
      Private label20 As System.Windows.Forms.Label
      Private label21 As System.Windows.Forms.Label
      Private dateTimePickerSeriesDate As System.Windows.Forms.DateTimePicker
      Private label12 As System.Windows.Forms.Label
      Private textBoxDescription As System.Windows.Forms.TextBox
      Private label13 As System.Windows.Forms.Label
      Private label14 As System.Windows.Forms.Label
      Private WithEvents comboBoxModality As System.Windows.Forms.ComboBox
      Private WithEvents radioButtonMove As System.Windows.Forms.RadioButton
      Private WithEvents CopyButton As System.Windows.Forms.Button
      Private SeriesTime As System.Windows.Forms.Label
      Private label16 As System.Windows.Forms.Label
   End Class
End Namespace