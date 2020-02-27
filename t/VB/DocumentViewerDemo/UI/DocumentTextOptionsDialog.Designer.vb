<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentTextOptionsDialog
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
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._okButton = New System.Windows.Forms.Button()
      Me._imagesRecognitionModeComboBox = New System.Windows.Forms.ComboBox()
      Me._imagesRecognitionModeLabel = New System.Windows.Forms.Label()
      Me._optionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._noteLabel = New System.Windows.Forms.Label()
      Me._textExtractionModeComboBox = New System.Windows.Forms.ComboBox()
      Me._textExtractionModeLabel = New System.Windows.Forms.Label()
      Me._optionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(502, 73)
      Me._cancelButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(112, 35)
      Me._cancelButton.TabIndex = 2
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(502, 28)
      Me._okButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(112, 35)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_imagesRecognitionModeComboBox
      '
      Me._imagesRecognitionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._imagesRecognitionModeComboBox.FormattingEnabled = True
      Me._imagesRecognitionModeComboBox.Location = New System.Drawing.Point(255, 28)
      Me._imagesRecognitionModeComboBox.Name = "_imagesRecognitionModeComboBox"
      Me._imagesRecognitionModeComboBox.Size = New System.Drawing.Size(183, 28)
      Me._imagesRecognitionModeComboBox.TabIndex = 1
      '
      '_imagesRecognitionModeLabel
      '
      Me._imagesRecognitionModeLabel.AutoSize = True
      Me._imagesRecognitionModeLabel.Location = New System.Drawing.Point(15, 31)
      Me._imagesRecognitionModeLabel.Name = "_imagesRecognitionModeLabel"
      Me._imagesRecognitionModeLabel.Size = New System.Drawing.Size(192, 20)
      Me._imagesRecognitionModeLabel.TabIndex = 0
      Me._imagesRecognitionModeLabel.Text = "Images recognition mode:"
      '
      '_optionsGroupBox
      '
      Me._optionsGroupBox.Controls.Add(Me._noteLabel)
      Me._optionsGroupBox.Controls.Add(Me._textExtractionModeComboBox)
      Me._optionsGroupBox.Controls.Add(Me._textExtractionModeLabel)
      Me._optionsGroupBox.Controls.Add(Me._imagesRecognitionModeComboBox)
      Me._optionsGroupBox.Controls.Add(Me._imagesRecognitionModeLabel)
      Me._optionsGroupBox.Location = New System.Drawing.Point(12, 12)
      Me._optionsGroupBox.Name = "_optionsGroupBox"
      Me._optionsGroupBox.Size = New System.Drawing.Size(468, 228)
      Me._optionsGroupBox.TabIndex = 0
      Me._optionsGroupBox.TabStop = False
      '
      '_noteLabel
      '
      Me._noteLabel.AutoSize = True
      Me._noteLabel.Location = New System.Drawing.Point(19, 123)
      Me._noteLabel.Name = "_noteLabel"
      Me._noteLabel.Size = New System.Drawing.Size(318, 40)
      Me._noteLabel.TabIndex = 4
      Me._noteLabel.Text = "Note that these options will not take effect if" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the page text has already been o" &
    "btained."
      '
      '_textExtractionModeComboBox
      '
      Me._textExtractionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._textExtractionModeComboBox.FormattingEnabled = True
      Me._textExtractionModeComboBox.Location = New System.Drawing.Point(255, 68)
      Me._textExtractionModeComboBox.Name = "_textExtractionModeComboBox"
      Me._textExtractionModeComboBox.Size = New System.Drawing.Size(183, 28)
      Me._textExtractionModeComboBox.TabIndex = 3
      '
      '_textExtractionModeLabel
      '
      Me._textExtractionModeLabel.AutoSize = True
      Me._textExtractionModeLabel.Location = New System.Drawing.Point(15, 71)
      Me._textExtractionModeLabel.Name = "_textExtractionModeLabel"
      Me._textExtractionModeLabel.Size = New System.Drawing.Size(160, 20)
      Me._textExtractionModeLabel.TabIndex = 2
      Me._textExtractionModeLabel.Text = "Text extraction mode:"
      '
      'DocumentTextOptionsDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(636, 256)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.Controls.Add(Me._optionsGroupBox)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DocumentTextOptionsDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Document Text Options"
      Me._optionsGroupBox.ResumeLayout(False)
      Me._optionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

   Private WithEvents _cancelButton As System.Windows.Forms.Button
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private WithEvents _imagesRecognitionModeComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _imagesRecognitionModeLabel As System.Windows.Forms.Label
   Private WithEvents _optionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _noteLabel As System.Windows.Forms.Label
   Private WithEvents _textExtractionModeComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _textExtractionModeLabel As System.Windows.Forms.Label
End Class
