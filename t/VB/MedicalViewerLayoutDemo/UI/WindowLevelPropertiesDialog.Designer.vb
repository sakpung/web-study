Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class WindowLevelPropertiesDialog
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
		 Me.label11 = New System.Windows.Forms.Label()
		 Me.label12 = New System.Windows.Forms.Label()
		 Me.groupBox2 = New System.Windows.Forms.GroupBox()
		 Me._cmbBottomKey = New System.Windows.Forms.ComboBox()
		 Me._cmbTopKey = New System.Windows.Forms.ComboBox()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me._cmbModifiers = New System.Windows.Forms.ComboBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me._cmbRightKey = New System.Windows.Forms.ComboBox()
		 Me._cmbLeftKey = New System.Windows.Forms.ComboBox()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._txtSensitivity = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._btnCursor = New MedicalViewerLayoutDemo.CursorButton()
		 Me._chkCircular = New System.Windows.Forms.CheckBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me._btnApply = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me.label8 = New System.Windows.Forms.Label()
		 Me.label9 = New System.Windows.Forms.Label()
		 Me._cmbApplyToSubCell = New System.Windows.Forms.ComboBox()
		 Me._cmbApplyToCell = New System.Windows.Forms.ComboBox()
		 Me.label10 = New System.Windows.Forms.Label()
		 Me.label13 = New System.Windows.Forms.Label()
		 Me.label14 = New System.Windows.Forms.Label()
		 Me._cmbFillType = New System.Windows.Forms.ComboBox()
		 Me.groupBox3 = New System.Windows.Forms.GroupBox()
		 Me._lblEnd = New MedicalViewerLayoutDemo.ColorBox()
		 Me._btnEnd = New System.Windows.Forms.Button()
		 Me._lblStart = New MedicalViewerLayoutDemo.ColorBox()
		 Me._btnStart = New System.Windows.Forms.Button()
		 Me._txtCenter = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtWidth = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtCellIndex = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtSubcellIndex = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me.groupBox2.SuspendLayout()
		 Me.groupBox1.SuspendLayout()
		 Me.groupBox3.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' label11
		 ' 
		 Me.label11.AutoSize = True
		 Me.label11.Location = New System.Drawing.Point(18, 139)
		 Me.label11.Name = "label11"
		 Me.label11.Size = New System.Drawing.Size(40, 13)
		 Me.label11.TabIndex = 9
		 Me.label11.Text = "&Bottom"
		 ' 
		 ' label12
		 ' 
		 Me.label12.AutoSize = True
		 Me.label12.Location = New System.Drawing.Point(20, 104)
		 Me.label12.Name = "label12"
		 Me.label12.Size = New System.Drawing.Size(26, 13)
		 Me.label12.TabIndex = 8
		 Me.label12.Text = "&Top"
		 ' 
		 ' groupBox2
		 ' 
		 Me.groupBox2.BackColor = System.Drawing.Color.Transparent
		 Me.groupBox2.Controls.Add(Me.label11)
		 Me.groupBox2.Controls.Add(Me.label12)
		 Me.groupBox2.Controls.Add(Me._cmbBottomKey)
		 Me.groupBox2.Controls.Add(Me._cmbTopKey)
		 Me.groupBox2.Controls.Add(Me.label5)
		 Me.groupBox2.Controls.Add(Me._cmbModifiers)
		 Me.groupBox2.Controls.Add(Me.label4)
		 Me.groupBox2.Controls.Add(Me.label3)
		 Me.groupBox2.Controls.Add(Me._cmbRightKey)
		 Me.groupBox2.Controls.Add(Me._cmbLeftKey)
		 Me.groupBox2.Location = New System.Drawing.Point(10, 123)
		 Me.groupBox2.Name = "groupBox2"
		 Me.groupBox2.Size = New System.Drawing.Size(196, 200)
		 Me.groupBox2.TabIndex = 16
		 Me.groupBox2.TabStop = False
		 Me.groupBox2.Text = "Keyboard &Shortcut"
		 ' 
		 ' _cmbBottomKey
		 ' 
		 Me._cmbBottomKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbBottomKey.FormattingEnabled = True
		 Me._cmbBottomKey.Location = New System.Drawing.Point(70, 136)
		 Me._cmbBottomKey.Name = "_cmbBottomKey"
		 Me._cmbBottomKey.Size = New System.Drawing.Size(109, 21)
		 Me._cmbBottomKey.TabIndex = 7
		 ' 
		 ' _cmbTopKey
		 ' 
		 Me._cmbTopKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbTopKey.FormattingEnabled = True
		 Me._cmbTopKey.Location = New System.Drawing.Point(70, 100)
		 Me._cmbTopKey.Name = "_cmbTopKey"
		 Me._cmbTopKey.Size = New System.Drawing.Size(109, 21)
		 Me._cmbTopKey.TabIndex = 6
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(15, 174)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(49, 13)
		 Me.label5.TabIndex = 5
		 Me.label5.Text = "&Modifiers"
		 ' 
		 ' _cmbModifiers
		 ' 
		 Me._cmbModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbModifiers.FormattingEnabled = True
		 Me._cmbModifiers.Location = New System.Drawing.Point(70, 170)
		 Me._cmbModifiers.Name = "_cmbModifiers"
		 Me._cmbModifiers.Size = New System.Drawing.Size(59, 21)
		 Me._cmbModifiers.TabIndex = 4
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(18, 66)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(32, 13)
		 Me.label4.TabIndex = 3
		 Me.label4.Text = "&Right"
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(20, 29)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(25, 13)
		 Me.label3.TabIndex = 2
		 Me.label3.Text = "&Left"
		 ' 
		 ' _cmbRightKey
		 ' 
		 Me._cmbRightKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbRightKey.FormattingEnabled = True
		 Me._cmbRightKey.Location = New System.Drawing.Point(70, 63)
		 Me._cmbRightKey.Name = "_cmbRightKey"
		 Me._cmbRightKey.Size = New System.Drawing.Size(109, 21)
		 Me._cmbRightKey.TabIndex = 1
		 ' 
		 ' _cmbLeftKey
		 ' 
		 Me._cmbLeftKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbLeftKey.FormattingEnabled = True
		 Me._cmbLeftKey.Location = New System.Drawing.Point(70, 25)
		 Me._cmbLeftKey.Name = "_cmbLeftKey"
		 Me._cmbLeftKey.Size = New System.Drawing.Size(109, 21)
		 Me._cmbLeftKey.TabIndex = 0
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(16, 25)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(70, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Action &Cursor"
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._txtSensitivity)
		 Me.groupBox1.Controls.Add(Me._btnCursor)
		 Me.groupBox1.Controls.Add(Me._chkCircular)
		 Me.groupBox1.Controls.Add(Me.label2)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Location = New System.Drawing.Point(10, 10)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(196, 153)
		 Me.groupBox1.TabIndex = 15
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "&General Action Properties"
		 ' 
		 ' _txtSensitivity
		 ' 
		 Me._txtSensitivity.Location = New System.Drawing.Point(103, 58)
		 Me._txtSensitivity.MaximumAllowed = 10000
		 Me._txtSensitivity.MaxLength = 3
		 Me._txtSensitivity.MinimumAllowed = 1
		 Me._txtSensitivity.Name = "_txtSensitivity"
		 Me._txtSensitivity.Size = New System.Drawing.Size(60, 20)
		 Me._txtSensitivity.TabIndex = 4
		 Me._txtSensitivity.Value = 0
		 ' 
		 ' _btnCursor
		 ' 
		 Me._btnCursor.Location = New System.Drawing.Point(103, 18)
		 Me._btnCursor.Name = "_btnCursor"
		 Me._btnCursor.Size = New System.Drawing.Size(61, 31)
		 Me._btnCursor.TabIndex = 3
		 Me._btnCursor.UseVisualStyleBackColor = True
		 ' 
		 ' _chkCircular
		 ' 
		 Me._chkCircular.AutoSize = True
		 Me._chkCircular.Location = New System.Drawing.Point(17, 90)
		 Me._chkCircular.Name = "_chkCircular"
		 Me._chkCircular.Size = New System.Drawing.Size(126, 17)
		 Me._chkCircular.TabIndex = 2
		 Me._chkCircular.Text = "&Circular Mouse Move"
		 Me._chkCircular.UseVisualStyleBackColor = True
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(16, 61)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(54, 13)
		 Me.label2.TabIndex = 1
		 Me.label2.Text = "&Sensitivity"
		 ' 
		 ' _btnApply
		 ' 
		 Me._btnApply.Location = New System.Drawing.Point(365, 294)
		 Me._btnApply.Name = "_btnApply"
		 Me._btnApply.Size = New System.Drawing.Size(70, 29)
		 Me._btnApply.TabIndex = 20
		 Me._btnApply.Text = "App&ly"
		 Me._btnApply.UseVisualStyleBackColor = True
'		 Me._btnApply.Click += New System.EventHandler(Me._btnApply_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(288, 294)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(70, 29)
		 Me._btnCancel.TabIndex = 19
		 Me._btnCancel.Text = "Canc&el"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(212, 294)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(70, 29)
		 Me._btnOK.TabIndex = 18
		 Me._btnOK.Text = "&OK"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(19, 21)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(45, 13)
		 Me.label6.TabIndex = 3
		 Me.label6.Text = "&Apply to"
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(19, 52)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(53, 13)
		 Me.label7.TabIndex = 4
		 Me.label7.Text = "&Cell Index"
		 ' 
		 ' label8
		 ' 
		 Me.label8.AutoSize = True
		 Me.label8.Location = New System.Drawing.Point(19, 83)
		 Me.label8.Name = "label8"
		 Me.label8.Size = New System.Drawing.Size(45, 13)
		 Me.label8.TabIndex = 5
		 Me.label8.Text = "A&pply to"
		 ' 
		 ' label9
		 ' 
		 Me.label9.AutoSize = True
		 Me.label9.Location = New System.Drawing.Point(9, 114)
		 Me.label9.Name = "label9"
		 Me.label9.Size = New System.Drawing.Size(74, 13)
		 Me.label9.TabIndex = 6
		 Me.label9.Text = "&Sub-cell Index"
		 ' 
		 ' _cmbApplyToSubCell
		 ' 
		 Me._cmbApplyToSubCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbApplyToSubCell.Enabled = False
		 Me._cmbApplyToSubCell.FormattingEnabled = True
		 Me._cmbApplyToSubCell.Items.AddRange(New Object() { "Selected", "All", "Custom"})
		 Me._cmbApplyToSubCell.Location = New System.Drawing.Point(91, 81)
		 Me._cmbApplyToSubCell.Name = "_cmbApplyToSubCell"
		 Me._cmbApplyToSubCell.Size = New System.Drawing.Size(109, 21)
		 Me._cmbApplyToSubCell.TabIndex = 11
'		 Me._cmbApplyToSubCell.SelectedIndexChanged += New System.EventHandler(Me._cmbApplyToSubCell_SelectedIndexChanged);
		 ' 
		 ' _cmbApplyToCell
		 ' 
		 Me._cmbApplyToCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbApplyToCell.FormattingEnabled = True
		 Me._cmbApplyToCell.Items.AddRange(New Object() { "None", "Selected", "All", "Custom"})
		 Me._cmbApplyToCell.Location = New System.Drawing.Point(91, 18)
		 Me._cmbApplyToCell.Name = "_cmbApplyToCell"
		 Me._cmbApplyToCell.Size = New System.Drawing.Size(109, 21)
		 Me._cmbApplyToCell.TabIndex = 12
'		 Me._cmbApplyToCell.SelectedIndexChanged += New System.EventHandler(Me._cmbApplyToCell_SelectedIndexChanged);
		 ' 
		 ' label10
		 ' 
		 Me.label10.AutoSize = True
		 Me.label10.Location = New System.Drawing.Point(26, 145)
		 Me.label10.Name = "label10"
		 Me.label10.Size = New System.Drawing.Size(35, 13)
		 Me.label10.TabIndex = 13
		 Me.label10.Text = "&Width"
		 ' 
		 ' label13
		 ' 
		 Me.label13.AutoSize = True
		 Me.label13.Location = New System.Drawing.Point(24, 176)
		 Me.label13.Name = "label13"
		 Me.label13.Size = New System.Drawing.Size(38, 13)
		 Me.label13.TabIndex = 15
		 Me.label13.Text = "Ce&nter"
		 ' 
		 ' label14
		 ' 
		 Me.label14.AutoSize = True
		 Me.label14.Location = New System.Drawing.Point(20, 210)
		 Me.label14.Name = "label14"
		 Me.label14.Size = New System.Drawing.Size(42, 13)
		 Me.label14.TabIndex = 17
		 Me.label14.Text = "&Fill type"
		 ' 
		 ' _cmbFillType
		 ' 
		 Me._cmbFillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbFillType.Enabled = False
		 Me._cmbFillType.FormattingEnabled = True
		 Me._cmbFillType.Location = New System.Drawing.Point(91, 206)
		 Me._cmbFillType.Name = "_cmbFillType"
		 Me._cmbFillType.Size = New System.Drawing.Size(109, 21)
		 Me._cmbFillType.TabIndex = 18
		 ' 
		 ' groupBox3
		 ' 
		 Me.groupBox3.Controls.Add(Me._lblEnd)
		 Me.groupBox3.Controls.Add(Me._btnEnd)
		 Me.groupBox3.Controls.Add(Me._lblStart)
		 Me.groupBox3.Controls.Add(Me._btnStart)
		 Me.groupBox3.Controls.Add(Me._txtCenter)
		 Me.groupBox3.Controls.Add(Me._cmbFillType)
		 Me.groupBox3.Controls.Add(Me.label14)
		 Me.groupBox3.Controls.Add(Me.label13)
		 Me.groupBox3.Controls.Add(Me._txtWidth)
		 Me.groupBox3.Controls.Add(Me.label10)
		 Me.groupBox3.Controls.Add(Me._cmbApplyToCell)
		 Me.groupBox3.Controls.Add(Me._cmbApplyToSubCell)
		 Me.groupBox3.Controls.Add(Me._txtCellIndex)
		 Me.groupBox3.Controls.Add(Me._txtSubcellIndex)
		 Me.groupBox3.Controls.Add(Me.label9)
		 Me.groupBox3.Controls.Add(Me.label8)
		 Me.groupBox3.Controls.Add(Me.label7)
		 Me.groupBox3.Controls.Add(Me.label6)
		 Me.groupBox3.Location = New System.Drawing.Point(212, 12)
		 Me.groupBox3.Name = "groupBox3"
		 Me.groupBox3.Size = New System.Drawing.Size(223, 276)
		 Me.groupBox3.TabIndex = 21
		 Me.groupBox3.TabStop = False
		 Me.groupBox3.Text = "Cell &Properties"
		 ' 
		 ' _lblEnd
		 ' 
		 Me._lblEnd.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
		 Me._lblEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me._lblEnd.BoxColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
		 Me._lblEnd.Location = New System.Drawing.Point(173, 242)
		 Me._lblEnd.Name = "_lblEnd"
		 Me._lblEnd.Size = New System.Drawing.Size(43, 26)
		 Me._lblEnd.TabIndex = 23
		 ' 
		 ' _btnEnd
		 ' 
		 Me._btnEnd.Location = New System.Drawing.Point(115, 239)
		 Me._btnEnd.Name = "_btnEnd"
		 Me._btnEnd.Size = New System.Drawing.Size(54, 30)
		 Me._btnEnd.TabIndex = 22
		 Me._btnEnd.Text = "End"
		 Me._btnEnd.UseVisualStyleBackColor = True
'		 Me._btnEnd.Click += New System.EventHandler(Me._btnEnd_Click);
		 ' 
		 ' _lblStart
		 ' 
		 Me._lblStart.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
		 Me._lblStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me._lblStart.BoxColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
		 Me._lblStart.Location = New System.Drawing.Point(66, 242)
		 Me._lblStart.Name = "_lblStart"
		 Me._lblStart.Size = New System.Drawing.Size(43, 26)
		 Me._lblStart.TabIndex = 21
		 ' 
		 ' _btnStart
		 ' 
		 Me._btnStart.Location = New System.Drawing.Point(9, 240)
		 Me._btnStart.Name = "_btnStart"
		 Me._btnStart.Size = New System.Drawing.Size(54, 30)
		 Me._btnStart.TabIndex = 20
		 Me._btnStart.Text = "Start"
		 Me._btnStart.UseVisualStyleBackColor = True
'		 Me._btnStart.Click += New System.EventHandler(Me._btnStart_Click);
		 ' 
		 ' _txtCenter
		 ' 
		 Me._txtCenter.Enabled = False
		 Me._txtCenter.Location = New System.Drawing.Point(91, 173)
		 Me._txtCenter.MaximumAllowed = 65535
		 Me._txtCenter.MinimumAllowed = -65535
		 Me._txtCenter.Name = "_txtCenter"
		 Me._txtCenter.Size = New System.Drawing.Size(58, 20)
		 Me._txtCenter.TabIndex = 19
		 Me._txtCenter.Text = "0"
		 Me._txtCenter.Value = 0
		 ' 
		 ' _txtWidth
		 ' 
		 Me._txtWidth.Enabled = False
		 Me._txtWidth.Location = New System.Drawing.Point(91, 144)
		 Me._txtWidth.MaximumAllowed = 65535
		 Me._txtWidth.MinimumAllowed = 1
		 Me._txtWidth.Name = "_txtWidth"
		 Me._txtWidth.Size = New System.Drawing.Size(58, 20)
		 Me._txtWidth.TabIndex = 14
		 Me._txtWidth.Value = 0
		 ' 
		 ' _txtCellIndex
		 ' 
		 Me._txtCellIndex.Enabled = False
		 Me._txtCellIndex.Location = New System.Drawing.Point(91, 50)
		 Me._txtCellIndex.MaximumAllowed = 100
		 Me._txtCellIndex.MinimumAllowed = 0
		 Me._txtCellIndex.Name = "_txtCellIndex"
		 Me._txtCellIndex.Size = New System.Drawing.Size(37, 20)
		 Me._txtCellIndex.TabIndex = 10
		 Me._txtCellIndex.Text = "0"
		 Me._txtCellIndex.Value = 0
		 ' 
		 ' _txtSubcellIndex
		 ' 
		 Me._txtSubcellIndex.Enabled = False
		 Me._txtSubcellIndex.Location = New System.Drawing.Point(91, 113)
		 Me._txtSubcellIndex.MaximumAllowed = 100
		 Me._txtSubcellIndex.MinimumAllowed = 0
		 Me._txtSubcellIndex.Name = "_txtSubcellIndex"
		 Me._txtSubcellIndex.Size = New System.Drawing.Size(37, 20)
		 Me._txtSubcellIndex.TabIndex = 9
		 Me._txtSubcellIndex.Text = "0"
		 Me._txtSubcellIndex.Value = 0
		 ' 
		 ' WindowLevelPropertiesDialog
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(444, 331)
		 Me.Controls.Add(Me.groupBox3)
		 Me.Controls.Add(Me.groupBox2)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me._btnApply)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "WindowLevelPropertiesDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Window Level Dialog"
		 Me.groupBox2.ResumeLayout(False)
		 Me.groupBox2.PerformLayout()
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.groupBox3.ResumeLayout(False)
		 Me.groupBox3.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private label11 As System.Windows.Forms.Label
	  Private label12 As System.Windows.Forms.Label
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private _cmbBottomKey As System.Windows.Forms.ComboBox
	  Private _cmbTopKey As System.Windows.Forms.ComboBox
	  Private label5 As System.Windows.Forms.Label
	  Private _cmbModifiers As System.Windows.Forms.ComboBox
	  Private label4 As System.Windows.Forms.Label
	  Private label3 As System.Windows.Forms.Label
	  Private _cmbRightKey As System.Windows.Forms.ComboBox
	  Private _cmbLeftKey As System.Windows.Forms.ComboBox
	  Private label1 As System.Windows.Forms.Label
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private _txtSensitivity As NumericTextBox
	  Private _btnCursor As MedicalViewerLayoutDemo.CursorButton
	  Private _chkCircular As System.Windows.Forms.CheckBox
	  Private label2 As System.Windows.Forms.Label
	  Private WithEvents _btnApply As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private label6 As System.Windows.Forms.Label
	  Private label7 As System.Windows.Forms.Label
	  Private label8 As System.Windows.Forms.Label
	  Private label9 As System.Windows.Forms.Label
	  Private _txtSubcellIndex As NumericTextBox
	  Private _txtCellIndex As NumericTextBox
	  Private WithEvents _cmbApplyToSubCell As System.Windows.Forms.ComboBox
	  Private WithEvents _cmbApplyToCell As System.Windows.Forms.ComboBox
	  Private label10 As System.Windows.Forms.Label
	  Private _txtWidth As NumericTextBox
	  Private label13 As System.Windows.Forms.Label
	  Private label14 As System.Windows.Forms.Label
	  Private _cmbFillType As System.Windows.Forms.ComboBox
	  Private groupBox3 As System.Windows.Forms.GroupBox
	  Private _txtCenter As NumericTextBox
	  Private _lblEnd As MedicalViewerLayoutDemo.ColorBox
	  Private WithEvents _btnEnd As System.Windows.Forms.Button
	  Private _lblStart As MedicalViewerLayoutDemo.ColorBox
	  Private WithEvents _btnStart As System.Windows.Forms.Button
   End Class
End Namespace