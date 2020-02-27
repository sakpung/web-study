Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class OffsetPropertiesDialog
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
		 Me._txtCellIndex = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me._chkCircular = New System.Windows.Forms.CheckBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me._btnApply = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me._txtSensitivity = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._btnActionCursor = New CursorButton()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me._cmbModifiers = New System.Windows.Forms.ComboBox()
		 Me.groupBox2 = New System.Windows.Forms.GroupBox()
		 Me.label11 = New System.Windows.Forms.Label()
		 Me.label12 = New System.Windows.Forms.Label()
		 Me._cmbBottomKey = New System.Windows.Forms.ComboBox()
		 Me._cmbTopKey = New System.Windows.Forms.ComboBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me._cmbRightKey = New System.Windows.Forms.ComboBox()
		 Me._cmbLeftKey = New System.Windows.Forms.ComboBox()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me.groupBox3 = New System.Windows.Forms.GroupBox()
		 Me.label9 = New System.Windows.Forms.Label()
		 Me.label8 = New System.Windows.Forms.Label()
		 Me._txtY = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtX = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._cmbApplyToCell = New System.Windows.Forms.ComboBox()
		 Me.groupBox2.SuspendLayout()
		 Me.groupBox1.SuspendLayout()
		 Me.groupBox3.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _txtCellIndex
		 ' 
		 Me._txtCellIndex.Location = New System.Drawing.Point(86, 97)
		 Me._txtCellIndex.MaximumAllowed = 100
		 Me._txtCellIndex.MinimumAllowed = 0
		 Me._txtCellIndex.Name = "_txtCellIndex"
		 Me._txtCellIndex.Size = New System.Drawing.Size(41, 20)
		 Me._txtCellIndex.TabIndex = 10
		 Me._txtCellIndex.Text = "0"
		 Me._txtCellIndex.Value = 0
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(27, 100)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(53, 13)
		 Me.label7.TabIndex = 4
		 Me.label7.Text = "&Cell Index"
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(35, 56)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(45, 13)
		 Me.label6.TabIndex = 3
		 Me.label6.Text = "&Apply to"
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
		 Me._btnApply.Location = New System.Drawing.Point(367, 258)
		 Me._btnApply.Name = "_btnApply"
		 Me._btnApply.Size = New System.Drawing.Size(70, 29)
		 Me._btnApply.TabIndex = 14
		 Me._btnApply.Text = "App&ly"
		 Me._btnApply.UseVisualStyleBackColor = True
'		 Me._btnApply.Click += New System.EventHandler(Me._btnApply_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(290, 258)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(70, 29)
		 Me._btnCancel.TabIndex = 13
		 Me._btnCancel.Text = "Canc&el"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(214, 258)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(70, 29)
		 Me._btnOK.TabIndex = 12
		 Me._btnOK.Text = "&OK"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
		 ' 
		 ' _txtSensitivity
		 ' 
		 Me._txtSensitivity.Location = New System.Drawing.Point(103, 58)
		 Me._txtSensitivity.MaximumAllowed = 10000
		 Me._txtSensitivity.MaxLength = 3
		 Me._txtSensitivity.MinimumAllowed = 1
		 Me._txtSensitivity.Name = "_txtSensitivity"
		 Me._txtSensitivity.Size = New System.Drawing.Size(40, 20)
		 Me._txtSensitivity.TabIndex = 4
		 Me._txtSensitivity.Value = 0
		 ' 
		 ' _btnActionCursor
		 ' 
		 Me._btnActionCursor.Location = New System.Drawing.Point(103, 18)
		 Me._btnActionCursor.Name = "_btnActionCursor"
		 Me._btnActionCursor.Size = New System.Drawing.Size(61, 31)
		 Me._btnActionCursor.TabIndex = 3
		 Me._btnActionCursor.UseVisualStyleBackColor = True
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(15, 142)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(49, 13)
		 Me.label5.TabIndex = 5
		 Me.label5.Text = "&Modifiers"
		 ' 
		 ' _cmbModifiers
		 ' 
		 Me._cmbModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbModifiers.FormattingEnabled = True
		 Me._cmbModifiers.Location = New System.Drawing.Point(70, 138)
		 Me._cmbModifiers.Name = "_cmbModifiers"
		 Me._cmbModifiers.Size = New System.Drawing.Size(59, 21)
		 Me._cmbModifiers.TabIndex = 4
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
		 Me.groupBox2.Location = New System.Drawing.Point(12, 118)
		 Me.groupBox2.Name = "groupBox2"
		 Me.groupBox2.Size = New System.Drawing.Size(196, 168)
		 Me.groupBox2.TabIndex = 10
		 Me.groupBox2.TabStop = False
		 Me.groupBox2.Text = "Keyboard &Shortcut"
		 ' 
		 ' label11
		 ' 
		 Me.label11.AutoSize = True
		 Me.label11.Location = New System.Drawing.Point(18, 112)
		 Me.label11.Name = "label11"
		 Me.label11.Size = New System.Drawing.Size(40, 13)
		 Me.label11.TabIndex = 9
		 Me.label11.Text = "&Bottom"
		 ' 
		 ' label12
		 ' 
		 Me.label12.AutoSize = True
		 Me.label12.Location = New System.Drawing.Point(20, 85)
		 Me.label12.Name = "label12"
		 Me.label12.Size = New System.Drawing.Size(26, 13)
		 Me.label12.TabIndex = 8
		 Me.label12.Text = "&Top"
		 ' 
		 ' _cmbBottomKey
		 ' 
		 Me._cmbBottomKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbBottomKey.FormattingEnabled = True
		 Me._cmbBottomKey.Location = New System.Drawing.Point(70, 109)
		 Me._cmbBottomKey.Name = "_cmbBottomKey"
		 Me._cmbBottomKey.Size = New System.Drawing.Size(109, 21)
		 Me._cmbBottomKey.TabIndex = 7
		 ' 
		 ' _cmbTopKey
		 ' 
		 Me._cmbTopKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbTopKey.FormattingEnabled = True
		 Me._cmbTopKey.Location = New System.Drawing.Point(70, 81)
		 Me._cmbTopKey.Name = "_cmbTopKey"
		 Me._cmbTopKey.Size = New System.Drawing.Size(109, 21)
		 Me._cmbTopKey.TabIndex = 6
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(18, 56)
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
		 Me._cmbRightKey.Location = New System.Drawing.Point(70, 53)
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
		 Me.groupBox1.Controls.Add(Me._btnActionCursor)
		 Me.groupBox1.Controls.Add(Me._chkCircular)
		 Me.groupBox1.Controls.Add(Me.label2)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Location = New System.Drawing.Point(12, 5)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(196, 153)
		 Me.groupBox1.TabIndex = 9
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "&General Action Properties"
		 ' 
		 ' groupBox3
		 ' 
		 Me.groupBox3.Controls.Add(Me.label9)
		 Me.groupBox3.Controls.Add(Me.label8)
		 Me.groupBox3.Controls.Add(Me._txtY)
		 Me.groupBox3.Controls.Add(Me._txtX)
		 Me.groupBox3.Controls.Add(Me._cmbApplyToCell)
		 Me.groupBox3.Controls.Add(Me._txtCellIndex)
		 Me.groupBox3.Controls.Add(Me.label7)
		 Me.groupBox3.Controls.Add(Me.label6)
		 Me.groupBox3.Location = New System.Drawing.Point(214, 5)
		 Me.groupBox3.Name = "groupBox3"
		 Me.groupBox3.Size = New System.Drawing.Size(223, 243)
		 Me.groupBox3.TabIndex = 11
		 Me.groupBox3.TabStop = False
		 Me.groupBox3.Text = "Cell &Properties"
		 ' 
		 ' label9
		 ' 
		 Me.label9.AutoSize = True
		 Me.label9.Location = New System.Drawing.Point(60, 182)
		 Me.label9.Name = "label9"
		 Me.label9.Size = New System.Drawing.Size(14, 13)
		 Me.label9.TabIndex = 16
		 Me.label9.Text = "&Y"
		 ' 
		 ' label8
		 ' 
		 Me.label8.AutoSize = True
		 Me.label8.Location = New System.Drawing.Point(58, 142)
		 Me.label8.Name = "label8"
		 Me.label8.Size = New System.Drawing.Size(14, 13)
		 Me.label8.TabIndex = 15
		 Me.label8.Text = "&X"
		 ' 
		 ' _txtY
		 ' 
		 Me._txtY.Location = New System.Drawing.Point(86, 179)
		 Me._txtY.MaximumAllowed = 1000000
		 Me._txtY.MinimumAllowed = -1000000
		 Me._txtY.Name = "_txtY"
		 Me._txtY.Size = New System.Drawing.Size(41, 20)
		 Me._txtY.TabIndex = 14
		 Me._txtY.Text = "0"
		 Me._txtY.Value = 0
		 ' 
		 ' _txtX
		 ' 
		 Me._txtX.Location = New System.Drawing.Point(86, 139)
		 Me._txtX.MaximumAllowed = 1000000
		 Me._txtX.MinimumAllowed = -1000000
		 Me._txtX.Name = "_txtX"
		 Me._txtX.Size = New System.Drawing.Size(41, 20)
		 Me._txtX.TabIndex = 13
		 Me._txtX.Text = "0"
		 Me._txtX.Value = 0
		 ' 
		 ' _cmbApplyToCell
		 ' 
		 Me._cmbApplyToCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbApplyToCell.FormattingEnabled = True
		 Me._cmbApplyToCell.Items.AddRange(New Object() { "None", "Selected", "All", "Custom"})
		 Me._cmbApplyToCell.Location = New System.Drawing.Point(86, 53)
		 Me._cmbApplyToCell.Name = "_cmbApplyToCell"
		 Me._cmbApplyToCell.Size = New System.Drawing.Size(87, 21)
		 Me._cmbApplyToCell.TabIndex = 12
'		 Me._cmbApplyToCell.SelectedIndexChanged += New System.EventHandler(Me._cmbApplyToCell_SelectedIndexChanged);
		 ' 
		 ' OffsetPropertiesDialog
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(446, 294)
		 Me.Controls.Add(Me._btnApply)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.Controls.Add(Me.groupBox2)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me.groupBox3)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "OffsetPropertiesDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Offset Properties"
		 Me.groupBox2.ResumeLayout(False)
		 Me.groupBox2.PerformLayout()
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.groupBox3.ResumeLayout(False)
		 Me.groupBox3.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _txtCellIndex As NumericTextBox
	  Private label7 As System.Windows.Forms.Label
	  Private label6 As System.Windows.Forms.Label
	  Private _chkCircular As System.Windows.Forms.CheckBox
	  Private label2 As System.Windows.Forms.Label
	  Private WithEvents _btnApply As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private _txtSensitivity As NumericTextBox
	  Private _btnActionCursor As CursorButton
	  Private label5 As System.Windows.Forms.Label
	  Private _cmbModifiers As System.Windows.Forms.ComboBox
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private label4 As System.Windows.Forms.Label
	  Private label3 As System.Windows.Forms.Label
	  Private _cmbRightKey As System.Windows.Forms.ComboBox
	  Private _cmbLeftKey As System.Windows.Forms.ComboBox
	  Private label1 As System.Windows.Forms.Label
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private groupBox3 As System.Windows.Forms.GroupBox
	  Private WithEvents _cmbApplyToCell As System.Windows.Forms.ComboBox
	  Private label11 As System.Windows.Forms.Label
	  Private label12 As System.Windows.Forms.Label
	  Private _cmbBottomKey As System.Windows.Forms.ComboBox
	  Private _cmbTopKey As System.Windows.Forms.ComboBox
	  Private label9 As System.Windows.Forms.Label
	  Private label8 As System.Windows.Forms.Label
	  Private _txtY As NumericTextBox
	  Private _txtX As NumericTextBox
   End Class
End Namespace