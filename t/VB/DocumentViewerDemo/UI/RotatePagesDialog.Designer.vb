Partial Class RotatePagesDialog
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
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._okButton = New System.Windows.Forms.Button()
      Me._directionLabel = New System.Windows.Forms.Label()
      Me._directionComboBox = New System.Windows.Forms.ComboBox()
      Me._rangeGroupBox = New System.Windows.Forms.GroupBox()
      Me._allRadioButton = New System.Windows.Forms.RadioButton()
      Me._selectedRadioButton = New System.Windows.Forms.RadioButton()
      Me._pagesRadioButton = New System.Windows.Forms.RadioButton()
      Me._fromLabel = New System.Windows.Forms.Label()
      Me._fromTextBox = New System.Windows.Forms.TextBox()
      Me._toTextBox = New System.Windows.Forms.TextBox()
      Me._toLabel = New System.Windows.Forms.Label()
      Me._rotateLabel = New System.Windows.Forms.Label()
      Me._evenOddComboBox = New System.Windows.Forms.ComboBox()
      Me._orientationComboBox = New System.Windows.Forms.ComboBox()
      Me._ofLabel = New System.Windows.Forms.Label()
      Me._rangeGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(496, 357)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(112, 35)
      Me._cancelButton.TabIndex = 4
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _okButton
      ' 
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(378, 357)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(112, 35)
      Me._okButton.TabIndex = 3
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      AddHandler Me._okButton.Click, AddressOf Me._okButton_Click
      ' 
      ' _directionLabel
      ' 
      Me._directionLabel.AutoSize = True
      Me._directionLabel.Location = New System.Drawing.Point(37, 34)
      Me._directionLabel.Name = "_directionLabel"
      Me._directionLabel.Size = New System.Drawing.Size(76, 20)
      Me._directionLabel.TabIndex = 0
      Me._directionLabel.Text = "&Direction:"
      ' 
      ' _directionComboBox
      ' 
      Me._directionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._directionComboBox.FormattingEnabled = True
      Me._directionComboBox.Location = New System.Drawing.Point(152, 31)
      Me._directionComboBox.Name = "_directionComboBox"
      Me._directionComboBox.Size = New System.Drawing.Size(271, 28)
      Me._directionComboBox.TabIndex = 1
      ' 
      ' _rangeGroupBox
      ' 
      Me._rangeGroupBox.Controls.Add(Me._ofLabel)
      Me._rangeGroupBox.Controls.Add(Me._orientationComboBox)
      Me._rangeGroupBox.Controls.Add(Me._evenOddComboBox)
      Me._rangeGroupBox.Controls.Add(Me._rotateLabel)
      Me._rangeGroupBox.Controls.Add(Me._toTextBox)
      Me._rangeGroupBox.Controls.Add(Me._toLabel)
      Me._rangeGroupBox.Controls.Add(Me._fromTextBox)
      Me._rangeGroupBox.Controls.Add(Me._fromLabel)
      Me._rangeGroupBox.Controls.Add(Me._pagesRadioButton)
      Me._rangeGroupBox.Controls.Add(Me._selectedRadioButton)
      Me._rangeGroupBox.Controls.Add(Me._allRadioButton)
      Me._rangeGroupBox.Location = New System.Drawing.Point(30, 86)
      Me._rangeGroupBox.Name = "_rangeGroupBox"
      Me._rangeGroupBox.Size = New System.Drawing.Size(588, 265)
      Me._rangeGroupBox.TabIndex = 2
      Me._rangeGroupBox.TabStop = False
      Me._rangeGroupBox.Text = "&Range"
      ' 
      ' _allRadioButton
      ' 
      Me._allRadioButton.AutoSize = True
      Me._allRadioButton.Location = New System.Drawing.Point(42, 49)
      Me._allRadioButton.Name = "_allRadioButton"
      Me._allRadioButton.Size = New System.Drawing.Size(51, 24)
      Me._allRadioButton.TabIndex = 0
      Me._allRadioButton.TabStop = True
      Me._allRadioButton.Text = "&All"
      Me._allRadioButton.UseVisualStyleBackColor = True
      AddHandler Me._allRadioButton.CheckedChanged, AddressOf Me._allRadioButton_CheckedChanged
      ' 
      ' _selectedRadioButton
      ' 
      Me._selectedRadioButton.AutoSize = True
      Me._selectedRadioButton.Location = New System.Drawing.Point(42, 92)
      Me._selectedRadioButton.Name = "_selectedRadioButton"
      Me._selectedRadioButton.Size = New System.Drawing.Size(97, 24)
      Me._selectedRadioButton.TabIndex = 1
      Me._selectedRadioButton.TabStop = True
      Me._selectedRadioButton.Text = "&Selected"
      Me._selectedRadioButton.UseVisualStyleBackColor = True
      AddHandler Me._selectedRadioButton.CheckedChanged, AddressOf Me._selectedRadioButton_CheckedChanged
      ' 
      ' _pagesRadioButton
      ' 
      Me._pagesRadioButton.AutoSize = True
      Me._pagesRadioButton.Location = New System.Drawing.Point(42, 135)
      Me._pagesRadioButton.Name = "_pagesRadioButton"
      Me._pagesRadioButton.Size = New System.Drawing.Size(79, 24)
      Me._pagesRadioButton.TabIndex = 2
      Me._pagesRadioButton.TabStop = True
      Me._pagesRadioButton.Text = "&Pages"
      Me._pagesRadioButton.UseVisualStyleBackColor = True
      AddHandler Me._pagesRadioButton.CheckedChanged, AddressOf Me._pagesRadioButton_CheckedChanged
      ' 
      ' _fromLabel
      ' 
      Me._fromLabel.AutoSize = True
      Me._fromLabel.Location = New System.Drawing.Point(159, 138)
      Me._fromLabel.Name = "_fromLabel"
      Me._fromLabel.Size = New System.Drawing.Size(50, 20)
      Me._fromLabel.TabIndex = 3
      Me._fromLabel.Text = "&From:"
      ' 
      ' _fromTextBox
      ' 
      Me._fromTextBox.Location = New System.Drawing.Point(215, 135)
      Me._fromTextBox.Name = "_fromTextBox"
      Me._fromTextBox.Size = New System.Drawing.Size(100, 26)
      Me._fromTextBox.TabIndex = 4
      ' 
      ' _toTextBox
      ' 
      Me._toTextBox.Location = New System.Drawing.Point(372, 135)
      Me._toTextBox.Name = "_toTextBox"
      Me._toTextBox.Size = New System.Drawing.Size(100, 26)
      Me._toTextBox.TabIndex = 6
      ' 
      ' _toLabel
      ' 
      Me._toLabel.AutoSize = True
      Me._toLabel.Location = New System.Drawing.Point(335, 137)
      Me._toLabel.Name = "_toLabel"
      Me._toLabel.Size = New System.Drawing.Size(31, 20)
      Me._toLabel.TabIndex = 5
      Me._toLabel.Text = "&To:"
      ' 
      ' _rotateLabel
      ' 
      Me._rotateLabel.AutoSize = True
      Me._rotateLabel.Location = New System.Drawing.Point(38, 186)
      Me._rotateLabel.Name = "_rotateLabel"
      Me._rotateLabel.Size = New System.Drawing.Size(62, 20)
      Me._rotateLabel.TabIndex = 8
      Me._rotateLabel.Text = "R&otate:"
      ' 
      ' _evenOddComboBox
      ' 
      Me._evenOddComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._evenOddComboBox.FormattingEnabled = True
      Me._evenOddComboBox.Location = New System.Drawing.Point(122, 183)
      Me._evenOddComboBox.Name = "_evenOddComboBox"
      Me._evenOddComboBox.Size = New System.Drawing.Size(271, 28)
      Me._evenOddComboBox.TabIndex = 9
      ' 
      ' _orientationComboBox
      ' 
      Me._orientationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._orientationComboBox.FormattingEnabled = True
      Me._orientationComboBox.Location = New System.Drawing.Point(122, 217)
      Me._orientationComboBox.Name = "_orientationComboBox"
      Me._orientationComboBox.Size = New System.Drawing.Size(271, 28)
      Me._orientationComboBox.TabIndex = 10
      ' 
      ' _ofLabel
      ' 
      Me._ofLabel.AutoSize = True
      Me._ofLabel.Location = New System.Drawing.Point(478, 139)
      Me._ofLabel.Name = "_ofLabel"
      Me._ofLabel.Size = New System.Drawing.Size(54, 20)
      Me._ofLabel.TabIndex = 7
      Me._ofLabel.Text = "of ###"
      ' 
      ' RotatePagesDialog
      ' 
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(647, 407)
      Me.Controls.Add(Me._rangeGroupBox)
      Me.Controls.Add(Me._directionComboBox)
      Me.Controls.Add(Me._directionLabel)
      Me.Controls.Add(Me._okButton)
      Me.Controls.Add(Me._cancelButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RotatePagesDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Rotate Pages"
      Me._rangeGroupBox.ResumeLayout(False)
      Me._rangeGroupBox.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _cancelButton As System.Windows.Forms.Button
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _directionLabel As System.Windows.Forms.Label
   Private _directionComboBox As System.Windows.Forms.ComboBox
   Private _rangeGroupBox As System.Windows.Forms.GroupBox
   Private _toTextBox As System.Windows.Forms.TextBox
   Private _toLabel As System.Windows.Forms.Label
   Private _fromTextBox As System.Windows.Forms.TextBox
   Private _fromLabel As System.Windows.Forms.Label
   Private WithEvents _pagesRadioButton As System.Windows.Forms.RadioButton
   Private WithEvents _selectedRadioButton As System.Windows.Forms.RadioButton
   Private WithEvents _allRadioButton As System.Windows.Forms.RadioButton
   Private _orientationComboBox As System.Windows.Forms.ComboBox
   Private _evenOddComboBox As System.Windows.Forms.ComboBox
   Private _rotateLabel As System.Windows.Forms.Label
   Private _ofLabel As System.Windows.Forms.Label
End Class
