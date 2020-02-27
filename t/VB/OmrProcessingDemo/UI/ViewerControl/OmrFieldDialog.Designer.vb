Partial Class OmrFieldDialog
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OmrFieldDialog))
      Me.tbLayout = New System.Windows.Forms.TabControl()
      Me.tabPage1 = New System.Windows.Forms.TabPage()
      Me.grpGrading = New System.Windows.Forms.GroupBox()
      Me.lblCorrectAnswerGrade = New System.Windows.Forms.Label()
      Me._cbGrade = New System.Windows.Forms.CheckBox()
      Me.lblEmptyAnswerGrade = New System.Windows.Forms.Label()
      Me.lblIncorrectAnswerGrade = New System.Windows.Forms.Label()
      Me._numNoResponse = New System.Windows.Forms.NumericUpDown()
      Me._numIncorrect = New System.Windows.Forms.NumericUpDown()
      Me._numCorrect = New System.Windows.Forms.NumericUpDown()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.rdbtnOrFreeflow = New System.Windows.Forms.RadioButton()
      Me.rdbtnOrCols = New System.Windows.Forms.RadioButton()
      Me.rdbtnOrRows = New System.Windows.Forms.RadioButton()
      Me.label1 = New System.Windows.Forms.Label()
      Me._txtFieldName = New System.Windows.Forms.TextBox()
      Me.grpLabelOptions = New System.Windows.Forms.GroupBox()
      Me.pnlImg = New System.Windows.Forms.Panel()
      Me.label6 = New System.Windows.Forms.Label()
      Me.txtValue = New System.Windows.Forms.TextBox()
      Me.cboxValues = New System.Windows.Forms.ComboBox()
      Me.lblvalue = New System.Windows.Forms.Label()
      Me.grpGrid = New System.Windows.Forms.GroupBox()
      Me.btnCreateCustom = New System.Windows.Forms.Button()
      Me._lblValues = New System.Windows.Forms.Label()
      Me.pnlOutputFormat = New System.Windows.Forms.Panel()
      Me.lblFormatExample = New System.Windows.Forms.Label()
      Me.lblOutputFormat = New System.Windows.Forms.Label()
      Me.rdbtnFormatCSV = New System.Windows.Forms.RadioButton()
      Me.rdbtnFormatAggregated = New System.Windows.Forms.RadioButton()
      Me.lstValues = New System.Windows.Forms.ListBox()
      Me._cbRightToLeft = New System.Windows.Forms.CheckBox()
      Me.tabPage2 = New System.Windows.Forms.TabPage()
      Me._highSensitivityLabel = New System.Windows.Forms.Label()
      Me._highSensitivityPictureBox = New System.Windows.Forms.PictureBox()
      Me._lowSensitivityLabel = New System.Windows.Forms.Label()
      Me._lowSensitivityPictureBox = New System.Windows.Forms.PictureBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.grpSensitivity = New System.Windows.Forms.GroupBox()
      Me.rdbtnSensLowest = New System.Windows.Forms.RadioButton()
      Me.rdbtnSensLow = New System.Windows.Forms.RadioButton()
      Me.rdbtnSensHigh = New System.Windows.Forms.RadioButton()
      Me.rdbtnSensHighest = New System.Windows.Forms.RadioButton()
      Me.tbLayout.SuspendLayout()
      Me.tabPage1.SuspendLayout()
      Me.grpGrading.SuspendLayout()
      CType(Me._numNoResponse, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpLabelOptions.SuspendLayout()
      Me.grpGrid.SuspendLayout()
      Me.pnlOutputFormat.SuspendLayout()
      Me.tabPage2.SuspendLayout()
      CType(Me._highSensitivityPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._lowSensitivityPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpSensitivity.SuspendLayout()
      Me.SuspendLayout()
      Me.tbLayout.Controls.Add(Me.tabPage1)
      Me.tbLayout.Controls.Add(Me.tabPage2)
      Me.tbLayout.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tbLayout.Location = New System.Drawing.Point(0, 0)
      Me.tbLayout.Name = "tbLayout"
      Me.tbLayout.SelectedIndex = 0
      Me.tbLayout.Size = New System.Drawing.Size(287, 526)
      Me.tbLayout.TabIndex = 0
      Me.tabPage1.Controls.Add(Me.grpGrading)
      Me.tabPage1.Controls.Add(Me.btnCancel)
      Me.tabPage1.Controls.Add(Me.btnOK)
      Me.tabPage1.Controls.Add(Me.rdbtnOrFreeflow)
      Me.tabPage1.Controls.Add(Me.rdbtnOrCols)
      Me.tabPage1.Controls.Add(Me.rdbtnOrRows)
      Me.tabPage1.Controls.Add(Me.label1)
      Me.tabPage1.Controls.Add(Me._txtFieldName)
      Me.tabPage1.Controls.Add(Me.grpLabelOptions)
      Me.tabPage1.Controls.Add(Me.grpGrid)
      Me.tabPage1.Location = New System.Drawing.Point(4, 22)
      Me.tabPage1.Name = "tabPage1"
      Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.tabPage1.Size = New System.Drawing.Size(279, 500)
      Me.tabPage1.TabIndex = 0
      Me.tabPage1.Text = "Settings"
      Me.tabPage1.UseVisualStyleBackColor = True
      Me.grpGrading.Controls.Add(Me.lblCorrectAnswerGrade)
      Me.grpGrading.Controls.Add(Me._cbGrade)
      Me.grpGrading.Controls.Add(Me.lblEmptyAnswerGrade)
      Me.grpGrading.Controls.Add(Me.lblIncorrectAnswerGrade)
      Me.grpGrading.Controls.Add(Me._numNoResponse)
      Me.grpGrading.Controls.Add(Me._numIncorrect)
      Me.grpGrading.Controls.Add(Me._numCorrect)
      Me.grpGrading.Location = New System.Drawing.Point(16, 326)
      Me.grpGrading.Name = "grpGrading"
      Me.grpGrading.Size = New System.Drawing.Size(243, 133)
      Me.grpGrading.TabIndex = 39
      Me.grpGrading.TabStop = False
      Me.grpGrading.Text = "Grading Options"
      Me.lblCorrectAnswerGrade.AutoSize = True
      Me.lblCorrectAnswerGrade.Location = New System.Drawing.Point(16, 51)
      Me.lblCorrectAnswerGrade.Name = "lblCorrectAnswerGrade"
      Me.lblCorrectAnswerGrade.Size = New System.Drawing.Size(114, 13)
      Me.lblCorrectAnswerGrade.TabIndex = 36
      Me.lblCorrectAnswerGrade.Text = "Correct Answer Grade:"
      Me._cbGrade.AutoSize = True
      Me._cbGrade.Location = New System.Drawing.Point(61, 22)
      Me._cbGrade.Name = "_cbGrade"
      Me._cbGrade.Size = New System.Drawing.Size(115, 17)
      Me._cbGrade.TabIndex = 35
      Me._cbGrade.Text = "Grade This Region"
      Me._cbGrade.UseVisualStyleBackColor = True
      AddHandler Me._cbGrade.CheckedChanged, AddressOf Me._cbGrade_CheckedChanged
      Me.lblEmptyAnswerGrade.AutoSize = True
      Me.lblEmptyAnswerGrade.Location = New System.Drawing.Point(16, 102)
      Me.lblEmptyAnswerGrade.Name = "lblEmptyAnswerGrade"
      Me.lblEmptyAnswerGrade.Size = New System.Drawing.Size(109, 13)
      Me.lblEmptyAnswerGrade.TabIndex = 34
      Me.lblEmptyAnswerGrade.Text = "Empty Answer Grade:"
      Me.lblIncorrectAnswerGrade.AutoSize = True
      Me.lblIncorrectAnswerGrade.Location = New System.Drawing.Point(16, 76)
      Me.lblIncorrectAnswerGrade.Name = "lblIncorrectAnswerGrade"
      Me.lblIncorrectAnswerGrade.Size = New System.Drawing.Size(122, 13)
      Me.lblIncorrectAnswerGrade.TabIndex = 33
      Me.lblIncorrectAnswerGrade.Text = "Incorrect Answer Grade:"
      Me._numNoResponse.DecimalPlaces = 2
      Me._numNoResponse.Enabled = False
      Me._numNoResponse.Location = New System.Drawing.Point(145, 100)
      Me._numNoResponse.Name = "_numNoResponse"
      Me._numNoResponse.Size = New System.Drawing.Size(76, 20)
      Me._numNoResponse.TabIndex = 31
      Me._numIncorrect.DecimalPlaces = 2
      Me._numIncorrect.Enabled = False
      Me._numIncorrect.Location = New System.Drawing.Point(144, 74)
      Me._numIncorrect.Name = "_numIncorrect"
      Me._numIncorrect.Size = New System.Drawing.Size(76, 20)
      Me._numIncorrect.TabIndex = 30
      Me._numCorrect.DecimalPlaces = 2
      Me._numCorrect.Enabled = False
      Me._numCorrect.Location = New System.Drawing.Point(144, 48)
      Me._numCorrect.Name = "_numCorrect"
      Me._numCorrect.Size = New System.Drawing.Size(76, 20)
      Me._numCorrect.TabIndex = 29
      Me._numCorrect.Value = New Decimal(New Integer() {1, 0, 0, 0})
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(170, 465)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 38
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(89, 465)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 38
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      AddHandler Me.btnOK.Click, AddressOf Me.btnOK_Click
      Me.rdbtnOrFreeflow.AutoSize = True
      Me.rdbtnOrFreeflow.Location = New System.Drawing.Point(180, 32)
      Me.rdbtnOrFreeflow.Name = "rdbtnOrFreeflow"
      Me.rdbtnOrFreeflow.Size = New System.Drawing.Size(65, 17)
      Me.rdbtnOrFreeflow.TabIndex = 17
      Me.rdbtnOrFreeflow.TabStop = True
      Me.rdbtnOrFreeflow.Text = "Freeflow"
      Me.rdbtnOrFreeflow.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnOrFreeflow.CheckedChanged, AddressOf Me.rdbtnOrientation_CheckChanged
      Me.rdbtnOrCols.AutoSize = True
      Me.rdbtnOrCols.Location = New System.Drawing.Point(96, 32)
      Me.rdbtnOrCols.Name = "rdbtnOrCols"
      Me.rdbtnOrCols.Size = New System.Drawing.Size(65, 17)
      Me.rdbtnOrCols.TabIndex = 16
      Me.rdbtnOrCols.TabStop = True
      Me.rdbtnOrCols.Text = "Columns"
      Me.rdbtnOrCols.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnOrCols.CheckedChanged, AddressOf Me.rdbtnOrientation_CheckChanged
      Me.rdbtnOrRows.AutoSize = True
      Me.rdbtnOrRows.Location = New System.Drawing.Point(24, 32)
      Me.rdbtnOrRows.Name = "rdbtnOrRows"
      Me.rdbtnOrRows.Size = New System.Drawing.Size(52, 17)
      Me.rdbtnOrRows.TabIndex = 15
      Me.rdbtnOrRows.TabStop = True
      Me.rdbtnOrRows.Text = "Rows"
      Me.rdbtnOrRows.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnOrRows.CheckedChanged, AddressOf Me.rdbtnOrientation_CheckChanged
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(15, 9)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(35, 13)
      Me.label1.TabIndex = 14
      Me.label1.Text = "Name"
      Me._txtFieldName.Location = New System.Drawing.Point(56, 6)
      Me._txtFieldName.Name = "_txtFieldName"
      Me._txtFieldName.Size = New System.Drawing.Size(196, 20)
      Me._txtFieldName.TabIndex = 13
      Me.grpLabelOptions.Controls.Add(Me.pnlImg)
      Me.grpLabelOptions.Controls.Add(Me.label6)
      Me.grpLabelOptions.Controls.Add(Me.txtValue)
      Me.grpLabelOptions.Controls.Add(Me.cboxValues)
      Me.grpLabelOptions.Controls.Add(Me.lblvalue)
      Me.grpLabelOptions.Location = New System.Drawing.Point(16, 55)
      Me.grpLabelOptions.Name = "grpLabelOptions"
      Me.grpLabelOptions.Size = New System.Drawing.Size(243, 265)
      Me.grpLabelOptions.TabIndex = 38
      Me.grpLabelOptions.TabStop = False
      Me.grpLabelOptions.Text = "Label Options"
      Me.pnlImg.BackColor = System.Drawing.SystemColors.ControlDark
      Me.pnlImg.Location = New System.Drawing.Point(10, 50)
      Me.pnlImg.Name = "pnlImg"
      Me.pnlImg.Size = New System.Drawing.Size(217, 164)
      Me.pnlImg.TabIndex = 4
      Me.label6.AutoSize = True
      Me.label6.Location = New System.Drawing.Point(6, 23)
      Me.label6.Name = "label6"
      Me.label6.Size = New System.Drawing.Size(36, 13)
      Me.label6.TabIndex = 1
      Me.label6.Text = "Label:"
      Me.txtValue.Location = New System.Drawing.Point(47, 220)
      Me.txtValue.Name = "txtValue"
      Me.txtValue.Size = New System.Drawing.Size(153, 20)
      Me.txtValue.TabIndex = 3
      AddHandler Me.txtValue.Leave, AddressOf Me.txtValue_Leave
      Me.cboxValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboxValues.FormattingEnabled = True
      Me.cboxValues.Location = New System.Drawing.Point(47, 20)
      Me.cboxValues.Name = "cboxValues"
      Me.cboxValues.Size = New System.Drawing.Size(153, 21)
      Me.cboxValues.TabIndex = 0
      AddHandler Me.cboxValues.SelectedIndexChanged, AddressOf Me.cboxValues_SelectedIndexChanged
      Me.lblvalue.AutoSize = True
      Me.lblvalue.Location = New System.Drawing.Point(7, 223)
      Me.lblvalue.Name = "lblvalue"
      Me.lblvalue.Size = New System.Drawing.Size(37, 13)
      Me.lblvalue.TabIndex = 2
      Me.lblvalue.Text = "Value:"
      Me.grpGrid.Controls.Add(Me.btnCreateCustom)
      Me.grpGrid.Controls.Add(Me._lblValues)
      Me.grpGrid.Controls.Add(Me.pnlOutputFormat)
      Me.grpGrid.Controls.Add(Me.lstValues)
      Me.grpGrid.Controls.Add(Me._cbRightToLeft)
      Me.grpGrid.Location = New System.Drawing.Point(16, 55)
      Me.grpGrid.Name = "grpGrid"
      Me.grpGrid.Size = New System.Drawing.Size(243, 265)
      Me.grpGrid.TabIndex = 37
      Me.grpGrid.TabStop = False
      Me.grpGrid.Text = "Grid Options"
      Me.btnCreateCustom.Location = New System.Drawing.Point(40, 148)
      Me.btnCreateCustom.Name = "btnCreateCustom"
      Me.btnCreateCustom.Size = New System.Drawing.Size(163, 23)
      Me.btnCreateCustom.TabIndex = 39
      Me.btnCreateCustom.Text = "&Create Custom Range..."
      Me.btnCreateCustom.UseVisualStyleBackColor = True
      AddHandler Me.btnCreateCustom.Click, AddressOf Me.btnCreateCustom_Click
      Me._lblValues.AutoSize = True
      Me._lblValues.Location = New System.Drawing.Point(13, 23)
      Me._lblValues.Name = "_lblValues"
      Me._lblValues.Size = New System.Drawing.Size(39, 13)
      Me._lblValues.TabIndex = 36
      Me._lblValues.Text = "Values"
      Me.pnlOutputFormat.Controls.Add(Me.lblFormatExample)
      Me.pnlOutputFormat.Controls.Add(Me.lblOutputFormat)
      Me.pnlOutputFormat.Controls.Add(Me.rdbtnFormatCSV)
      Me.pnlOutputFormat.Controls.Add(Me.rdbtnFormatAggregated)
      Me.pnlOutputFormat.Location = New System.Drawing.Point(13, 177)
      Me.pnlOutputFormat.Name = "pnlOutputFormat"
      Me.pnlOutputFormat.Size = New System.Drawing.Size(204, 82)
      Me.pnlOutputFormat.TabIndex = 38
      Me.lblFormatExample.AutoSize = True
      Me.lblFormatExample.Location = New System.Drawing.Point(54, 68)
      Me.lblFormatExample.Name = "lblFormatExample"
      Me.lblFormatExample.Size = New System.Drawing.Size(36, 13)
      Me.lblFormatExample.TabIndex = 34
      Me.lblFormatExample.Text = "ABCD"
      Me.lblOutputFormat.AutoSize = True
      Me.lblOutputFormat.Location = New System.Drawing.Point(12, 9)
      Me.lblOutputFormat.Name = "lblOutputFormat"
      Me.lblOutputFormat.Size = New System.Drawing.Size(68, 13)
      Me.lblOutputFormat.TabIndex = 31
      Me.lblOutputFormat.Text = "Output Style:"
      Me.rdbtnFormatCSV.AutoSize = True
      Me.rdbtnFormatCSV.Location = New System.Drawing.Point(38, 25)
      Me.rdbtnFormatCSV.Name = "rdbtnFormatCSV"
      Me.rdbtnFormatCSV.Size = New System.Drawing.Size(112, 17)
      Me.rdbtnFormatCSV.TabIndex = 33
      Me.rdbtnFormatCSV.TabStop = True
      Me.rdbtnFormatCSV.Text = "Comma-Separated"
      Me.rdbtnFormatCSV.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnFormatCSV.CheckedChanged, AddressOf Me.rdbtnFormatValue_CheckChanged
      Me.rdbtnFormatAggregated.AutoSize = True
      Me.rdbtnFormatAggregated.Location = New System.Drawing.Point(38, 48)
      Me.rdbtnFormatAggregated.Name = "rdbtnFormatAggregated"
      Me.rdbtnFormatAggregated.Size = New System.Drawing.Size(72, 17)
      Me.rdbtnFormatAggregated.TabIndex = 32
      Me.rdbtnFormatAggregated.TabStop = True
      Me.rdbtnFormatAggregated.Text = "Combined"
      Me.rdbtnFormatAggregated.UseVisualStyleBackColor = True
      AddHandler Me.rdbtnFormatAggregated.CheckedChanged, AddressOf Me.rdbtnFormatValue_CheckChanged
      Me.lstValues.FormattingEnabled = True
      Me.lstValues.Location = New System.Drawing.Point(13, 45)
      Me.lstValues.Name = "lstValues"
      Me.lstValues.Size = New System.Drawing.Size(204, 95)
      Me.lstValues.TabIndex = 35
      AddHandler Me.lstValues.SelectedIndexChanged, AddressOf Me.lstValues_SelectedIndexChanged
      AddHandler Me.lstValues.DoubleClick, AddressOf Me.lstValues_DoubleClick
      Me._cbRightToLeft.AutoSize = True
      Me._cbRightToLeft.Location = New System.Drawing.Point(113, 22)
      Me._cbRightToLeft.Name = "_cbRightToLeft"
      Me._cbRightToLeft.Size = New System.Drawing.Size(88, 17)
      Me._cbRightToLeft.TabIndex = 37
      Me._cbRightToLeft.Text = "Right To Left"
      Me._cbRightToLeft.UseVisualStyleBackColor = True
      Me.tabPage2.Controls.Add(Me._highSensitivityLabel)
      Me.tabPage2.Controls.Add(Me._highSensitivityPictureBox)
      Me.tabPage2.Controls.Add(Me._lowSensitivityLabel)
      Me.tabPage2.Controls.Add(Me._lowSensitivityPictureBox)
      Me.tabPage2.Controls.Add(Me.label2)
      Me.tabPage2.Controls.Add(Me.grpSensitivity)
      Me.tabPage2.Location = New System.Drawing.Point(4, 22)
      Me.tabPage2.Name = "tabPage2"
      Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.tabPage2.Size = New System.Drawing.Size(279, 500)
      Me.tabPage2.TabIndex = 1
      Me.tabPage2.Text = "Sensitivity"
      Me.tabPage2.UseVisualStyleBackColor = True
      Me._highSensitivityLabel.AutoSize = True
      Me._highSensitivityLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._highSensitivityLabel.Location = New System.Drawing.Point(9, 95)
      Me._highSensitivityLabel.Name = "_highSensitivityLabel"
      Me._highSensitivityLabel.Size = New System.Drawing.Size(213, 13)
      Me._highSensitivityLabel.TabIndex = 30
      Me._highSensitivityLabel.Text = "For marks like these, select High Sensitivity."
      Me._highSensitivityPictureBox.Image = (CType((resources.GetObject("_highSensitivityPictureBox.Image")), System.Drawing.Image))
      Me._highSensitivityPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._highSensitivityPictureBox.Location = New System.Drawing.Point(95, 111)
      Me._highSensitivityPictureBox.Name = "_highSensitivityPictureBox"
      Me._highSensitivityPictureBox.Size = New System.Drawing.Size(110, 52)
      Me._highSensitivityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me._highSensitivityPictureBox.TabIndex = 31
      Me._highSensitivityPictureBox.TabStop = False
      Me._lowSensitivityLabel.AutoSize = True
      Me._lowSensitivityLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._lowSensitivityLabel.Location = New System.Drawing.Point(9, 41)
      Me._lowSensitivityLabel.Name = "_lowSensitivityLabel"
      Me._lowSensitivityLabel.Size = New System.Drawing.Size(211, 13)
      Me._lowSensitivityLabel.TabIndex = 29
      Me._lowSensitivityLabel.Text = "For marks like these, select Low Sensitivity."
      Me._lowSensitivityPictureBox.Image = (CType((resources.GetObject("_lowSensitivityPictureBox.Image")), System.Drawing.Image))
      Me._lowSensitivityPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._lowSensitivityPictureBox.Location = New System.Drawing.Point(95, 57)
      Me._lowSensitivityPictureBox.Name = "_lowSensitivityPictureBox"
      Me._lowSensitivityPictureBox.Size = New System.Drawing.Size(110, 27)
      Me._lowSensitivityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me._lowSensitivityPictureBox.TabIndex = 28
      Me._lowSensitivityPictureBox.TabStop = False
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(6, 17)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(257, 13)
      Me.label2.TabIndex = 27
      Me.label2.Text = "Use the samples to help you pick the correct options:"
      Me.grpSensitivity.Controls.Add(Me.rdbtnSensLowest)
      Me.grpSensitivity.Controls.Add(Me.rdbtnSensLow)
      Me.grpSensitivity.Controls.Add(Me.rdbtnSensHigh)
      Me.grpSensitivity.Controls.Add(Me.rdbtnSensHighest)
      Me.grpSensitivity.Location = New System.Drawing.Point(12, 169)
      Me.grpSensitivity.Name = "grpSensitivity"
      Me.grpSensitivity.Size = New System.Drawing.Size(260, 126)
      Me.grpSensitivity.TabIndex = 26
      Me.grpSensitivity.TabStop = False
      Me.grpSensitivity.Text = "OMR Mark Sensitivity"
      Me.rdbtnSensLowest.AutoSize = True
      Me.rdbtnSensLowest.Location = New System.Drawing.Point(6, 28)
      Me.rdbtnSensLowest.Name = "rdbtnSensLowest"
      Me.rdbtnSensLowest.Size = New System.Drawing.Size(59, 17)
      Me.rdbtnSensLowest.TabIndex = 3
      Me.rdbtnSensLowest.TabStop = True
      Me.rdbtnSensLowest.Text = "Lowest"
      Me.rdbtnSensLowest.UseVisualStyleBackColor = True
      Me.rdbtnSensLow.AutoSize = True
      Me.rdbtnSensLow.Location = New System.Drawing.Point(6, 51)
      Me.rdbtnSensLow.Name = "rdbtnSensLow"
      Me.rdbtnSensLow.Size = New System.Drawing.Size(45, 17)
      Me.rdbtnSensLow.TabIndex = 2
      Me.rdbtnSensLow.TabStop = True
      Me.rdbtnSensLow.Text = "Low"
      Me.rdbtnSensLow.UseVisualStyleBackColor = True
      Me.rdbtnSensHigh.AutoSize = True
      Me.rdbtnSensHigh.Location = New System.Drawing.Point(6, 74)
      Me.rdbtnSensHigh.Name = "rdbtnSensHigh"
      Me.rdbtnSensHigh.Size = New System.Drawing.Size(47, 17)
      Me.rdbtnSensHigh.TabIndex = 1
      Me.rdbtnSensHigh.TabStop = True
      Me.rdbtnSensHigh.Text = "High"
      Me.rdbtnSensHigh.UseVisualStyleBackColor = True
      Me.rdbtnSensHighest.AutoSize = True
      Me.rdbtnSensHighest.Location = New System.Drawing.Point(6, 97)
      Me.rdbtnSensHighest.Name = "rdbtnSensHighest"
      Me.rdbtnSensHighest.Size = New System.Drawing.Size(61, 17)
      Me.rdbtnSensHighest.TabIndex = 0
      Me.rdbtnSensHighest.TabStop = True
      Me.rdbtnSensHighest.Text = "Highest"
      Me.rdbtnSensHighest.UseVisualStyleBackColor = True
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(287, 526)
      Me.Controls.Add(Me.tbLayout)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OmrFieldDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "OMR Field Options"
      AddHandler Me.FormClosing, AddressOf Me.OmrFieldDialog_FormClosing
      Me.tbLayout.ResumeLayout(False)
      Me.tabPage1.ResumeLayout(False)
      Me.tabPage1.PerformLayout()
      Me.grpGrading.ResumeLayout(False)
      Me.grpGrading.PerformLayout()
      CType(Me._numNoResponse, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numCorrect, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpLabelOptions.ResumeLayout(False)
      Me.grpLabelOptions.PerformLayout()
      Me.grpGrid.ResumeLayout(False)
      Me.grpGrid.PerformLayout()
      Me.pnlOutputFormat.ResumeLayout(False)
      Me.pnlOutputFormat.PerformLayout()
      Me.tabPage2.ResumeLayout(False)
      Me.tabPage2.PerformLayout()
      CType(Me._highSensitivityPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._lowSensitivityPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpSensitivity.ResumeLayout(False)
      Me.grpSensitivity.PerformLayout()
      Me.ResumeLayout(False)
   End Sub

   Private tbLayout As System.Windows.Forms.TabControl
   Private tabPage1 As System.Windows.Forms.TabPage
   Private tabPage2 As System.Windows.Forms.TabPage
   Private rdbtnOrFreeflow As System.Windows.Forms.RadioButton
   Private rdbtnOrCols As System.Windows.Forms.RadioButton
   Private rdbtnOrRows As System.Windows.Forms.RadioButton
   Private label1 As System.Windows.Forms.Label
   Private _txtFieldName As System.Windows.Forms.TextBox
   Private grpSensitivity As System.Windows.Forms.GroupBox
   Private rdbtnSensLowest As System.Windows.Forms.RadioButton
   Private rdbtnSensLow As System.Windows.Forms.RadioButton
   Private rdbtnSensHigh As System.Windows.Forms.RadioButton
   Private rdbtnSensHighest As System.Windows.Forms.RadioButton
   Private pnlImg As System.Windows.Forms.Panel
   Private txtValue As System.Windows.Forms.TextBox
   Private lblvalue As System.Windows.Forms.Label
   Private label6 As System.Windows.Forms.Label
   Private cboxValues As System.Windows.Forms.ComboBox
   Private btnCancel As System.Windows.Forms.Button
   Private btnOK As System.Windows.Forms.Button
   Private grpLabelOptions As System.Windows.Forms.GroupBox
   Private grpGrid As System.Windows.Forms.GroupBox
   Private _lblValues As System.Windows.Forms.Label
   Private pnlOutputFormat As System.Windows.Forms.Panel
   Private lblOutputFormat As System.Windows.Forms.Label
   Private rdbtnFormatCSV As System.Windows.Forms.RadioButton
   Private rdbtnFormatAggregated As System.Windows.Forms.RadioButton
   Private lstValues As System.Windows.Forms.ListBox
   Private _cbRightToLeft As System.Windows.Forms.CheckBox
   Private grpGrading As System.Windows.Forms.GroupBox
   Private _cbGrade As System.Windows.Forms.CheckBox
   Private lblIncorrectAnswerGrade As System.Windows.Forms.Label
   Private _numNoResponse As System.Windows.Forms.NumericUpDown
   Private _numIncorrect As System.Windows.Forms.NumericUpDown
   Private _numCorrect As System.Windows.Forms.NumericUpDown
   Private lblCorrectAnswerGrade As System.Windows.Forms.Label
   Private lblEmptyAnswerGrade As System.Windows.Forms.Label
   Private lblFormatExample As System.Windows.Forms.Label
   Private btnCreateCustom As System.Windows.Forms.Button
   Private _highSensitivityLabel As System.Windows.Forms.Label
   Private _highSensitivityPictureBox As System.Windows.Forms.PictureBox
   Private _lowSensitivityLabel As System.Windows.Forms.Label
   Private _lowSensitivityPictureBox As System.Windows.Forms.PictureBox
   Private label2 As System.Windows.Forms.Label
End Class
