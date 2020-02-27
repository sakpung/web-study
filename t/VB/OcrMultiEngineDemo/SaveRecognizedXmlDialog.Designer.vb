<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveRecognizedXmlDialog
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
      Me._fileNameButton = New System.Windows.Forms.Button
      Me._fileNameTextBox = New System.Windows.Forms.TextBox
      Me._okButton = New System.Windows.Forms.Button
      Me._fileNameLabel = New System.Windows.Forms.Label
      Me._modeComboBox = New System.Windows.Forms.ComboBox
      Me._modeLabel = New System.Windows.Forms.Label
      Me._optionsGroupBox = New System.Windows.Forms.GroupBox
      Me._cancelButton = New System.Windows.Forms.Button
      Me._optionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_fileNameButton
      '
      Me._fileNameButton.Location = New System.Drawing.Point(421, 61)
      Me._fileNameButton.Name = "_fileNameButton"
      Me._fileNameButton.Size = New System.Drawing.Size(29, 23)
      Me._fileNameButton.TabIndex = 4
      Me._fileNameButton.Text = "&..."
      Me._fileNameButton.UseVisualStyleBackColor = True
      '
      '_fileNameTextBox
      '
      Me._fileNameTextBox.Location = New System.Drawing.Point(91, 63)
      Me._fileNameTextBox.Name = "_fileNameTextBox"
      Me._fileNameTextBox.Size = New System.Drawing.Size(324, 20)
      Me._fileNameTextBox.TabIndex = 3
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(321, 120)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_fileNameLabel
      '
      Me._fileNameLabel.AutoSize = True
      Me._fileNameLabel.Location = New System.Drawing.Point(16, 63)
      Me._fileNameLabel.Name = "_fileNameLabel"
      Me._fileNameLabel.Size = New System.Drawing.Size(55, 13)
      Me._fileNameLabel.TabIndex = 2
      Me._fileNameLabel.Text = "&File name:"
      '
      '_modeComboBox
      '
      Me._modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._modeComboBox.FormattingEnabled = True
      Me._modeComboBox.Location = New System.Drawing.Point(91, 34)
      Me._modeComboBox.Name = "_modeComboBox"
      Me._modeComboBox.Size = New System.Drawing.Size(324, 21)
      Me._modeComboBox.TabIndex = 1
      '
      '_modeLabel
      '
      Me._modeLabel.AutoSize = True
      Me._modeLabel.Location = New System.Drawing.Point(16, 34)
      Me._modeLabel.Name = "_modeLabel"
      Me._modeLabel.Size = New System.Drawing.Size(37, 13)
      Me._modeLabel.TabIndex = 0
      Me._modeLabel.Text = "&Mode:"
      '
      '_optionsGroupBox
      '
      Me._optionsGroupBox.Controls.Add(Me._fileNameButton)
      Me._optionsGroupBox.Controls.Add(Me._fileNameTextBox)
      Me._optionsGroupBox.Controls.Add(Me._fileNameLabel)
      Me._optionsGroupBox.Controls.Add(Me._modeComboBox)
      Me._optionsGroupBox.Controls.Add(Me._modeLabel)
      Me._optionsGroupBox.Location = New System.Drawing.Point(12, 12)
      Me._optionsGroupBox.Name = "_optionsGroupBox"
      Me._optionsGroupBox.Size = New System.Drawing.Size(469, 102)
      Me._optionsGroupBox.TabIndex = 0
      Me._optionsGroupBox.TabStop = False
      Me._optionsGroupBox.Text = "&Options:"
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(402, 120)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 2
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      'SaveRecognizedXmlDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(494, 153)
      Me.Controls.Add(Me._okButton)
      Me.Controls.Add(Me._optionsGroupBox)
      Me.Controls.Add(Me._cancelButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SaveRecognizedXmlDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Save Document Recognition Data as XML"
      Me._optionsGroupBox.ResumeLayout(False)
      Me._optionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _fileNameButton As System.Windows.Forms.Button
   Private WithEvents _fileNameTextBox As System.Windows.Forms.TextBox
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private WithEvents _fileNameLabel As System.Windows.Forms.Label
   Private WithEvents _modeComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _modeLabel As System.Windows.Forms.Label
   Private WithEvents _optionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _cancelButton As System.Windows.Forms.Button
End Class
