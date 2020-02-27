Namespace DocumentWritersDemo
   Partial Class NewDocumentDialogBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
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
         Me._okButton = New System.Windows.Forms.Button()
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._widthLabel = New System.Windows.Forms.Label()
         Me._heightLabel = New System.Windows.Forms.Label()
         Me._dimensionsGroupBox = New System.Windows.Forms.GroupBox()
         Me._heightNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me._widthNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me._pixelsInchesLabel = New System.Windows.Forms.Label()
         Me._physicalSizeValueLabel = New System.Windows.Forms.Label()
         Me._pixelsLabel = New System.Windows.Forms.Label()
         Me._physicalSizeLabel = New System.Windows.Forms.Label()
         Me._resolutionComboBox = New System.Windows.Forms.ComboBox()
         Me._resolutionLabel = New System.Windows.Forms.Label()
         Me._heightInchesLabel = New System.Windows.Forms.Label()
         Me._widthInchesLabel = New System.Windows.Forms.Label()
         Me._defaultButton = New System.Windows.Forms.Button()
         Me._dimensionsGroupBox.SuspendLayout()
         CType(Me._heightNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._widthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(231, 193)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 1
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(312, 193)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 2
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _widthLabel
         ' 
         Me._widthLabel.AutoSize = True
         Me._widthLabel.Location = New System.Drawing.Point(24, 37)
         Me._widthLabel.Name = "_widthLabel"
         Me._widthLabel.Size = New System.Drawing.Size(38, 13)
         Me._widthLabel.TabIndex = 0
         Me._widthLabel.Text = "Width:"
         ' 
         ' _heightLabel
         ' 
         Me._heightLabel.AutoSize = True
         Me._heightLabel.Location = New System.Drawing.Point(24, 67)
         Me._heightLabel.Name = "_heightLabel"
         Me._heightLabel.Size = New System.Drawing.Size(41, 13)
         Me._heightLabel.TabIndex = 3
         Me._heightLabel.Text = "Height:"
         ' 
         ' _dimensionsGroupBox
         ' 
         Me._dimensionsGroupBox.Controls.Add(Me._heightNumericUpDown)
         Me._dimensionsGroupBox.Controls.Add(Me._widthNumericUpDown)
         Me._dimensionsGroupBox.Controls.Add(Me._pixelsInchesLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._physicalSizeValueLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._pixelsLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._physicalSizeLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._resolutionComboBox)
         Me._dimensionsGroupBox.Controls.Add(Me._resolutionLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._heightInchesLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._widthInchesLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._widthLabel)
         Me._dimensionsGroupBox.Controls.Add(Me._heightLabel)
         Me._dimensionsGroupBox.Location = New System.Drawing.Point(12, 12)
         Me._dimensionsGroupBox.Name = "_dimensionsGroupBox"
         Me._dimensionsGroupBox.Size = New System.Drawing.Size(375, 175)
         Me._dimensionsGroupBox.TabIndex = 0
         Me._dimensionsGroupBox.TabStop = False
         Me._dimensionsGroupBox.Text = "&Dimensions"
         ' 
         ' _heightNumericUpDown
         ' 
         Me._heightNumericUpDown.DecimalPlaces = 2
         Me._heightNumericUpDown.Location = New System.Drawing.Point(105, 65)
         Me._heightNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._heightNumericUpDown.Name = "_heightNumericUpDown"
         Me._heightNumericUpDown.Size = New System.Drawing.Size(136, 20)
         Me._heightNumericUpDown.TabIndex = 13
         Me._heightNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' _widthNumericUpDown
         ' 
         Me._widthNumericUpDown.DecimalPlaces = 2
         Me._widthNumericUpDown.Location = New System.Drawing.Point(105, 35)
         Me._widthNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._widthNumericUpDown.Name = "_widthNumericUpDown"
         Me._widthNumericUpDown.Size = New System.Drawing.Size(136, 20)
         Me._widthNumericUpDown.TabIndex = 12
         Me._widthNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' _pixelsInchesLabel
         ' 
         Me._pixelsInchesLabel.AutoSize = True
         Me._pixelsInchesLabel.Location = New System.Drawing.Point(247, 98)
         Me._pixelsInchesLabel.Name = "_pixelsInchesLabel"
         Me._pixelsInchesLabel.Size = New System.Drawing.Size(96, 13)
         Me._pixelsInchesLabel.TabIndex = 8
         Me._pixelsInchesLabel.Text = "pixels/inches (DPI)"
         ' 
         ' _physicalSizeValueLabel
         ' 
         Me._physicalSizeValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._physicalSizeValueLabel.Location = New System.Drawing.Point(105, 129)
         Me._physicalSizeValueLabel.Name = "_physicalSizeValueLabel"
         Me._physicalSizeValueLabel.Size = New System.Drawing.Size(136, 23)
         Me._physicalSizeValueLabel.TabIndex = 10
         Me._physicalSizeValueLabel.Text = "label1"
         Me._physicalSizeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _pixelsLabel
         ' 
         Me._pixelsLabel.AutoSize = True
         Me._pixelsLabel.Location = New System.Drawing.Point(247, 134)
         Me._pixelsLabel.Name = "_pixelsLabel"
         Me._pixelsLabel.Size = New System.Drawing.Size(33, 13)
         Me._pixelsLabel.TabIndex = 11
         Me._pixelsLabel.Text = "pixels"
         ' 
         ' _physicalSizeLabel
         ' 
         Me._physicalSizeLabel.AutoSize = True
         Me._physicalSizeLabel.Location = New System.Drawing.Point(24, 134)
         Me._physicalSizeLabel.Name = "_physicalSizeLabel"
         Me._physicalSizeLabel.Size = New System.Drawing.Size(70, 13)
         Me._physicalSizeLabel.TabIndex = 9
         Me._physicalSizeLabel.Text = "Physical size:"
         ' 
         ' _resolutionComboBox
         ' 
         Me._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._resolutionComboBox.FormattingEnabled = True
         Me._resolutionComboBox.Items.AddRange(New Object() {"75", "96", "192", "200", "300", "600", _
          "1200"})
         Me._resolutionComboBox.Location = New System.Drawing.Point(105, 95)
         Me._resolutionComboBox.Name = "_resolutionComboBox"
         Me._resolutionComboBox.Size = New System.Drawing.Size(136, 21)
         Me._resolutionComboBox.TabIndex = 7
         ' 
         ' _resolutionLabel
         ' 
         Me._resolutionLabel.AutoSize = True
         Me._resolutionLabel.Location = New System.Drawing.Point(24, 98)
         Me._resolutionLabel.Name = "_resolutionLabel"
         Me._resolutionLabel.Size = New System.Drawing.Size(60, 13)
         Me._resolutionLabel.TabIndex = 6
         Me._resolutionLabel.Text = "Resolution:"
         ' 
         ' _heightInchesLabel
         ' 
         Me._heightInchesLabel.AutoSize = True
         Me._heightInchesLabel.Location = New System.Drawing.Point(247, 67)
         Me._heightInchesLabel.Name = "_heightInchesLabel"
         Me._heightInchesLabel.Size = New System.Drawing.Size(38, 13)
         Me._heightInchesLabel.TabIndex = 5
         Me._heightInchesLabel.Text = "inches"
         ' 
         ' _widthInchesLabel
         ' 
         Me._widthInchesLabel.AutoSize = True
         Me._widthInchesLabel.Location = New System.Drawing.Point(247, 37)
         Me._widthInchesLabel.Name = "_widthInchesLabel"
         Me._widthInchesLabel.Size = New System.Drawing.Size(38, 13)
         Me._widthInchesLabel.TabIndex = 2
         Me._widthInchesLabel.Text = "inches"
         ' 
         ' _defaultButton
         ' 
         Me._defaultButton.Location = New System.Drawing.Point(12, 194)
         Me._defaultButton.Name = "_defaultButton"
         Me._defaultButton.Size = New System.Drawing.Size(121, 23)
         Me._defaultButton.TabIndex = 3
         Me._defaultButton.Text = "Default dimension"
         Me._defaultButton.UseVisualStyleBackColor = True
         ' 
         ' NewDocumentDialogBox
         ' 
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(400, 228)
         Me.Controls.Add(Me._defaultButton)
         Me.Controls.Add(Me._dimensionsGroupBox)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "NewDocumentDialogBox"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Create new document"
         Me._dimensionsGroupBox.ResumeLayout(False)
         Me._dimensionsGroupBox.PerformLayout()
         CType(Me._heightNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._widthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _okButton As System.Windows.Forms.Button
      Private _cancelButton As System.Windows.Forms.Button
      Private _widthLabel As System.Windows.Forms.Label
      Private _heightLabel As System.Windows.Forms.Label
      Private _dimensionsGroupBox As System.Windows.Forms.GroupBox
      Private _widthInchesLabel As System.Windows.Forms.Label
      Private _heightInchesLabel As System.Windows.Forms.Label
      Private WithEvents _resolutionComboBox As System.Windows.Forms.ComboBox
      Private _resolutionLabel As System.Windows.Forms.Label
      Private _physicalSizeValueLabel As System.Windows.Forms.Label
      Private _pixelsLabel As System.Windows.Forms.Label
      Private _physicalSizeLabel As System.Windows.Forms.Label
      Private _pixelsInchesLabel As System.Windows.Forms.Label
      Private WithEvents _widthNumericUpDown As System.Windows.Forms.NumericUpDown
      Private WithEvents _heightNumericUpDown As System.Windows.Forms.NumericUpDown
      Private WithEvents _defaultButton As System.Windows.Forms.Button
   End Class
End Namespace
