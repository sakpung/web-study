<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OcrOmrOptionsDialog
   Inherits System.Windows.Forms.Form



   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OcrOmrOptionsDialog))
      Me._highSensitivityLabel = New System.Windows.Forms.Label
      Me._highSensitivityPictureBox = New System.Windows.Forms.PictureBox
      Me._lowSensitivityLabel = New System.Windows.Forms.Label
      Me._lowSensitivityPictureBox = New System.Windows.Forms.PictureBox
      Me._optionsGroupBox = New System.Windows.Forms.GroupBox
      Me._filledStateCharacterTextBox = New System.Windows.Forms.TextBox
      Me._unfilledStateCharacterTextBox = New System.Windows.Forms.TextBox
      Me._filledStateCharacterLabel = New System.Windows.Forms.Label
      Me._unfilledStateCharacterLabel = New System.Windows.Forms.Label
      Me._sensitivityComboBox = New System.Windows.Forms.ComboBox
      Me._sensitivityLabel = New System.Windows.Forms.Label
      Me._frameDetectionMethodComboBox = New System.Windows.Forms.ComboBox
      Me._frameDetectionMethodLabel = New System.Windows.Forms.Label
      Me._descriptionLabel = New System.Windows.Forms.Label
      Me._cancelButton = New System.Windows.Forms.Button
      Me._okButton = New System.Windows.Forms.Button
      CType(Me._highSensitivityPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._lowSensitivityPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._optionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_highSensitivityLabel
      '
      Me._highSensitivityLabel.AutoSize = True
      Me._highSensitivityLabel.Location = New System.Drawing.Point(132, 114)
      Me._highSensitivityLabel.Name = "_highSensitivityLabel"
      Me._highSensitivityLabel.Size = New System.Drawing.Size(217, 13)
      Me._highSensitivityLabel.TabIndex = 9
      Me._highSensitivityLabel.Text = "For marks like these, select High Sensitivity."
      '
      '_highSensitivityPictureBox
      '
      Me._highSensitivityPictureBox.Image = CType(resources.GetObject("_highSensitivityPictureBox.Image"), System.Drawing.Image)
      Me._highSensitivityPictureBox.Location = New System.Drawing.Point(16, 114)
      Me._highSensitivityPictureBox.Name = "_highSensitivityPictureBox"
      Me._highSensitivityPictureBox.Size = New System.Drawing.Size(110, 52)
      Me._highSensitivityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me._highSensitivityPictureBox.TabIndex = 14
      Me._highSensitivityPictureBox.TabStop = False
      '
      '_lowSensitivityLabel
      '
      Me._lowSensitivityLabel.AutoSize = True
      Me._lowSensitivityLabel.Location = New System.Drawing.Point(132, 82)
      Me._lowSensitivityLabel.Name = "_lowSensitivityLabel"
      Me._lowSensitivityLabel.Size = New System.Drawing.Size(215, 13)
      Me._lowSensitivityLabel.TabIndex = 8
      Me._lowSensitivityLabel.Text = "For marks like these, select Low Sensitivity."
      '
      '_lowSensitivityPictureBox
      '
      Me._lowSensitivityPictureBox.Image = CType(resources.GetObject("_lowSensitivityPictureBox.Image"), System.Drawing.Image)
      Me._lowSensitivityPictureBox.Location = New System.Drawing.Point(16, 81)
      Me._lowSensitivityPictureBox.Name = "_lowSensitivityPictureBox"
      Me._lowSensitivityPictureBox.Size = New System.Drawing.Size(110, 27)
      Me._lowSensitivityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me._lowSensitivityPictureBox.TabIndex = 12
      Me._lowSensitivityPictureBox.TabStop = False
      '
      '_optionsGroupBox
      '
      Me._optionsGroupBox.Controls.Add(Me._filledStateCharacterTextBox)
      Me._optionsGroupBox.Controls.Add(Me._unfilledStateCharacterTextBox)
      Me._optionsGroupBox.Controls.Add(Me._filledStateCharacterLabel)
      Me._optionsGroupBox.Controls.Add(Me._unfilledStateCharacterLabel)
      Me._optionsGroupBox.Controls.Add(Me._sensitivityComboBox)
      Me._optionsGroupBox.Controls.Add(Me._sensitivityLabel)
      Me._optionsGroupBox.Controls.Add(Me._frameDetectionMethodComboBox)
      Me._optionsGroupBox.Controls.Add(Me._frameDetectionMethodLabel)
      Me._optionsGroupBox.Location = New System.Drawing.Point(16, 175)
      Me._optionsGroupBox.Name = "_optionsGroupBox"
      Me._optionsGroupBox.Size = New System.Drawing.Size(329, 137)
      Me._optionsGroupBox.TabIndex = 10
      Me._optionsGroupBox.TabStop = False
      '
      '_filledStateCharacterTextBox
      '
      Me._filledStateCharacterTextBox.Location = New System.Drawing.Point(166, 100)
      Me._filledStateCharacterTextBox.MaxLength = 1
      Me._filledStateCharacterTextBox.Name = "_filledStateCharacterTextBox"
      Me._filledStateCharacterTextBox.Size = New System.Drawing.Size(49, 20)
      Me._filledStateCharacterTextBox.TabIndex = 7
      Me._filledStateCharacterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      '_unfilledStateCharacterTextBox
      '
      Me._unfilledStateCharacterTextBox.Location = New System.Drawing.Point(166, 74)
      Me._unfilledStateCharacterTextBox.MaxLength = 1
      Me._unfilledStateCharacterTextBox.Name = "_unfilledStateCharacterTextBox"
      Me._unfilledStateCharacterTextBox.Size = New System.Drawing.Size(49, 20)
      Me._unfilledStateCharacterTextBox.TabIndex = 5
      Me._unfilledStateCharacterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      '_filledStateCharacterLabel
      '
      Me._filledStateCharacterLabel.AutoSize = True
      Me._filledStateCharacterLabel.Location = New System.Drawing.Point(8, 103)
      Me._filledStateCharacterLabel.Name = "_filledStateCharacterLabel"
      Me._filledStateCharacterLabel.Size = New System.Drawing.Size(112, 13)
      Me._filledStateCharacterLabel.TabIndex = 6
      Me._filledStateCharacterLabel.Text = "&Filled state character:"
      '
      '_unfilledStateCharacterLabel
      '
      Me._unfilledStateCharacterLabel.AutoSize = True
      Me._unfilledStateCharacterLabel.Location = New System.Drawing.Point(8, 77)
      Me._unfilledStateCharacterLabel.Name = "_unfilledStateCharacterLabel"
      Me._unfilledStateCharacterLabel.Size = New System.Drawing.Size(123, 13)
      Me._unfilledStateCharacterLabel.TabIndex = 4
      Me._unfilledStateCharacterLabel.Text = "&Unfilled state character:"
      '
      '_sensitivityComboBox
      '
      Me._sensitivityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._sensitivityComboBox.FormattingEnabled = True
      Me._sensitivityComboBox.Location = New System.Drawing.Point(166, 47)
      Me._sensitivityComboBox.Name = "_sensitivityComboBox"
      Me._sensitivityComboBox.Size = New System.Drawing.Size(145, 21)
      Me._sensitivityComboBox.TabIndex = 3
      '
      '_sensitivityLabel
      '
      Me._sensitivityLabel.AutoSize = True
      Me._sensitivityLabel.Location = New System.Drawing.Point(8, 50)
      Me._sensitivityLabel.Name = "_sensitivityLabel"
      Me._sensitivityLabel.Size = New System.Drawing.Size(60, 13)
      Me._sensitivityLabel.TabIndex = 2
      Me._sensitivityLabel.Text = "&Sensitivity:"
      '
      '_frameDetectionMethodComboBox
      '
      Me._frameDetectionMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._frameDetectionMethodComboBox.FormattingEnabled = True
      Me._frameDetectionMethodComboBox.Location = New System.Drawing.Point(166, 20)
      Me._frameDetectionMethodComboBox.Name = "_frameDetectionMethodComboBox"
      Me._frameDetectionMethodComboBox.Size = New System.Drawing.Size(145, 21)
      Me._frameDetectionMethodComboBox.TabIndex = 1
      '
      '_frameDetectionMethodLabel
      '
      Me._frameDetectionMethodLabel.AutoSize = True
      Me._frameDetectionMethodLabel.Location = New System.Drawing.Point(8, 23)
      Me._frameDetectionMethodLabel.Name = "_frameDetectionMethodLabel"
      Me._frameDetectionMethodLabel.Size = New System.Drawing.Size(128, 13)
      Me._frameDetectionMethodLabel.TabIndex = 0
      Me._frameDetectionMethodLabel.Text = "F&rame detection method:"
      '
      '_descriptionLabel
      '
      Me._descriptionLabel.Location = New System.Drawing.Point(13, 13)
      Me._descriptionLabel.Name = "_descriptionLabel"
      Me._descriptionLabel.Size = New System.Drawing.Size(332, 65)
      Me._descriptionLabel.TabIndex = 7
      Me._descriptionLabel.Text = "Select the OMR (Optical Mark Recognition) options used in the OCR engine when rec" & _
          "ognizing OMR zones." & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "Use the samples below to help you pick the correct options:" & _
          ""
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(271, 318)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 13
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(190, 318)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 11
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      'OcrOmrOptionsDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(358, 349)
      Me.Controls.Add(Me._highSensitivityLabel)
      Me.Controls.Add(Me._highSensitivityPictureBox)
      Me.Controls.Add(Me._lowSensitivityLabel)
      Me.Controls.Add(Me._lowSensitivityPictureBox)
      Me.Controls.Add(Me._optionsGroupBox)
      Me.Controls.Add(Me._descriptionLabel)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OcrOmrOptionsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "OMR Options"
      CType(Me._highSensitivityPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._lowSensitivityPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me._optionsGroupBox.ResumeLayout(False)
      Me._optionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _highSensitivityLabel As System.Windows.Forms.Label
   Private WithEvents _highSensitivityPictureBox As System.Windows.Forms.PictureBox
   Private WithEvents _lowSensitivityLabel As System.Windows.Forms.Label
   Private WithEvents _lowSensitivityPictureBox As System.Windows.Forms.PictureBox
   Private WithEvents _optionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _filledStateCharacterTextBox As System.Windows.Forms.TextBox
   Private WithEvents _unfilledStateCharacterTextBox As System.Windows.Forms.TextBox
   Private WithEvents _filledStateCharacterLabel As System.Windows.Forms.Label
   Private WithEvents _unfilledStateCharacterLabel As System.Windows.Forms.Label
   Private WithEvents _sensitivityComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _sensitivityLabel As System.Windows.Forms.Label
   Private WithEvents _frameDetectionMethodComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _frameDetectionMethodLabel As System.Windows.Forms.Label
   Private WithEvents _descriptionLabel As System.Windows.Forms.Label
   Private WithEvents _cancelButton As System.Windows.Forms.Button
   Private WithEvents _okButton As System.Windows.Forms.Button

End Class
