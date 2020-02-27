Namespace MedicalViewerDemo
   Partial Class AlphaPropertiesDialog
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
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._chkCircular = New System.Windows.Forms.CheckBox()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._txtSensitivity = New MedicalViewerDemo.NumericTextBox()
         Me._btnCursor = New MedicalViewerDemo.CursorButton()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me._cmbModifiers = New System.Windows.Forms.ComboBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me._cmbRightKey = New System.Windows.Forms.ComboBox()
         Me._cmbLeftKey = New System.Windows.Forms.ComboBox()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me._cmbApplyToCell = New System.Windows.Forms.ComboBox()
         Me._cmbApplyToSubCell = New System.Windows.Forms.ComboBox()
         Me._txtCellIndex = New MedicalViewerDemo.NumericTextBox()
         Me._txtSubCellIndex = New MedicalViewerDemo.NumericTextBox()
         Me._txtFactor = New MedicalViewerDemo.NumericTextBox()
         Me.label10 = New System.Windows.Forms.Label()
         Me.label9 = New System.Windows.Forms.Label()
         Me.label8 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnApply = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(16, 31)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(70, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Action &Cursor"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(16, 72)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(54, 13)
         Me.label2.TabIndex = 1
         Me.label2.Text = "&Sensitivity"
         ' 
         ' _chkCircular
         ' 
         Me._chkCircular.AutoSize = True
         Me._chkCircular.Location = New System.Drawing.Point(17, 107)
         Me._chkCircular.Name = "_chkCircular"
         Me._chkCircular.Size = New System.Drawing.Size(126, 17)
         Me._chkCircular.TabIndex = 2
         Me._chkCircular.Text = "&Circular Mouse Move"
         Me._chkCircular.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._txtSensitivity)
         Me.groupBox1.Controls.Add(Me._btnCursor)
         Me.groupBox1.Controls.Add(Me._chkCircular)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(9, 8)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(196, 153)
         Me.groupBox1.TabIndex = 3
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&General Action Properties"
         ' 
         ' _txtSensitivity
         ' 
         Me._txtSensitivity.Location = New System.Drawing.Point(103, 71)
         Me._txtSensitivity.MaximumAllowed = 10000
         Me._txtSensitivity.MaxLength = 3
         Me._txtSensitivity.MinimumAllowed = 1
         Me._txtSensitivity.Name = "_txtSensitivity"
         Me._txtSensitivity.Size = New System.Drawing.Size(40, 20)
         Me._txtSensitivity.TabIndex = 4
         Me._txtSensitivity.Value = 1
         ' 
         ' _btnCursor
         ' 
         Me._btnCursor.ButtonCursor = Nothing
         Me._btnCursor.Location = New System.Drawing.Point(103, 24)
         Me._btnCursor.Name = "_btnCursor"
         Me._btnCursor.Size = New System.Drawing.Size(61, 31)
         Me._btnCursor.TabIndex = 3
         Me._btnCursor.UseVisualStyleBackColor = True
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.BackColor = System.Drawing.Color.Transparent
         Me.groupBox2.Controls.Add(Me.label5)
         Me.groupBox2.Controls.Add(Me._cmbModifiers)
         Me.groupBox2.Controls.Add(Me.label4)
         Me.groupBox2.Controls.Add(Me.label3)
         Me.groupBox2.Controls.Add(Me._cmbRightKey)
         Me.groupBox2.Controls.Add(Me._cmbLeftKey)
         Me.groupBox2.Location = New System.Drawing.Point(9, 144)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(196, 121)
         Me.groupBox2.TabIndex = 4
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Keyboard &Shortcut"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(12, 95)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(49, 13)
         Me.label5.TabIndex = 5
         Me.label5.Text = "&Modifiers"
         ' 
         ' _cmbModifiers
         ' 
         Me._cmbModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbModifiers.FormattingEnabled = True
         Me._cmbModifiers.Location = New System.Drawing.Point(70, 91)
         Me._cmbModifiers.Name = "_cmbModifiers"
         Me._cmbModifiers.Size = New System.Drawing.Size(59, 21)
         Me._cmbModifiers.TabIndex = 4
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(18, 63)
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
         Me._cmbRightKey.Location = New System.Drawing.Point(70, 60)
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
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me._cmbApplyToCell)
         Me.groupBox3.Controls.Add(Me._cmbApplyToSubCell)
         Me.groupBox3.Controls.Add(Me._txtCellIndex)
         Me.groupBox3.Controls.Add(Me._txtSubCellIndex)
         Me.groupBox3.Controls.Add(Me._txtFactor)
         Me.groupBox3.Controls.Add(Me.label10)
         Me.groupBox3.Controls.Add(Me.label9)
         Me.groupBox3.Controls.Add(Me.label8)
         Me.groupBox3.Controls.Add(Me.label7)
         Me.groupBox3.Controls.Add(Me.label6)
         Me.groupBox3.Location = New System.Drawing.Point(211, 8)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(223, 222)
         Me.groupBox3.TabIndex = 5
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Cell &Properties"
         ' 
         ' _cmbApplyToCell
         ' 
         Me._cmbApplyToCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbApplyToCell.FormattingEnabled = True
         Me._cmbApplyToCell.Items.AddRange(New Object() {"None", "Selected", "All", "Custom"})
         Me._cmbApplyToCell.Location = New System.Drawing.Point(91, 22)
         Me._cmbApplyToCell.Name = "_cmbApplyToCell"
         Me._cmbApplyToCell.Size = New System.Drawing.Size(109, 21)
         Me._cmbApplyToCell.TabIndex = 12
         ' 
         ' _cmbApplyToSubCell
         ' 
         Me._cmbApplyToSubCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbApplyToSubCell.FormattingEnabled = True
         Me._cmbApplyToSubCell.Items.AddRange(New Object() {"Selected", "All", "Custom"})
         Me._cmbApplyToSubCell.Location = New System.Drawing.Point(91, 105)
         Me._cmbApplyToSubCell.Name = "_cmbApplyToSubCell"
         Me._cmbApplyToSubCell.Size = New System.Drawing.Size(109, 21)
         Me._cmbApplyToSubCell.TabIndex = 11
         ' 
         ' _txtCellIndex
         ' 
         Me._txtCellIndex.Location = New System.Drawing.Point(91, 64)
         Me._txtCellIndex.MaximumAllowed = 100
         Me._txtCellIndex.MinimumAllowed = 0
         Me._txtCellIndex.Name = "_txtCellIndex"
         Me._txtCellIndex.Size = New System.Drawing.Size(37, 20)
         Me._txtCellIndex.TabIndex = 10
         Me._txtCellIndex.Text = "0"
         Me._txtCellIndex.Value = 0
         ' 
         ' _txtSubCellIndex
         ' 
         Me._txtSubCellIndex.Location = New System.Drawing.Point(91, 149)
         Me._txtSubCellIndex.MaximumAllowed = 100
         Me._txtSubCellIndex.MinimumAllowed = 0
         Me._txtSubCellIndex.Name = "_txtSubCellIndex"
         Me._txtSubCellIndex.Size = New System.Drawing.Size(37, 20)
         Me._txtSubCellIndex.TabIndex = 9
         Me._txtSubCellIndex.Text = "0"
         Me._txtSubCellIndex.Value = 0
         ' 
         ' _txtFactor
         ' 
         Me._txtFactor.Location = New System.Drawing.Point(91, 189)
         Me._txtFactor.MaximumAllowed = 1000
         Me._txtFactor.MinimumAllowed = -1000
         Me._txtFactor.Name = "_txtFactor"
         Me._txtFactor.Size = New System.Drawing.Size(55, 20)
         Me._txtFactor.TabIndex = 8
         Me._txtFactor.Text = "0"
         Me._txtFactor.Value = 0
         ' 
         ' label10
         ' 
         Me.label10.AutoSize = True
         Me.label10.Location = New System.Drawing.Point(25, 192)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(37, 13)
         Me.label10.TabIndex = 7
         Me.label10.Text = "&Factor"
         ' 
         ' label9
         ' 
         Me.label9.AutoSize = True
         Me.label9.Location = New System.Drawing.Point(9, 152)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(74, 13)
         Me.label9.TabIndex = 6
         Me.label9.Text = "&Sub-cell Index"
         ' 
         ' label8
         ' 
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(19, 109)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(45, 13)
         Me.label8.TabIndex = 5
         Me.label8.Text = "A&pply to"
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(19, 67)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(53, 13)
         Me.label7.TabIndex = 4
         Me.label7.Text = "&Cell Index"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(19, 25)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(45, 13)
         Me.label6.TabIndex = 3
         Me.label6.Text = "&Apply to"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnOk.Location = New System.Drawing.Point(211, 236)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(70, 29)
         Me._btnOk.TabIndex = 6
         Me._btnOk.Text = "&OK"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(287, 236)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(70, 29)
         Me._btnCancel.TabIndex = 7
         Me._btnCancel.Text = "Canc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(364, 236)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(70, 29)
         Me._btnApply.TabIndex = 8
         Me._btnApply.Text = "App&ly"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' AlphaPropertiesDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(441, 272)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AlphaPropertiesDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Alpha Properties Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private _chkCircular As System.Windows.Forms.CheckBox
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private _txtSensitivity As NumericTextBox
      Private _btnCursor As CursorButton
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private _cmbRightKey As System.Windows.Forms.ComboBox
      Private _cmbLeftKey As System.Windows.Forms.ComboBox
      Private label5 As System.Windows.Forms.Label
      Private _cmbModifiers As System.Windows.Forms.ComboBox
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label10 As System.Windows.Forms.Label
      Private label9 As System.Windows.Forms.Label
      Private label8 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private WithEvents _cmbApplyToCell As System.Windows.Forms.ComboBox
      Private WithEvents _cmbApplyToSubCell As System.Windows.Forms.ComboBox
      Private _txtCellIndex As NumericTextBox
      Private _txtSubCellIndex As NumericTextBox
      Private _txtFactor As NumericTextBox
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnApply As System.Windows.Forms.Button
   End Class
End Namespace
