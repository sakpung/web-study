Namespace OcrDemo
   Partial Class SaveRecognizedXmlDialog
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
         Me._optionsGroupBox = New System.Windows.Forms.GroupBox()
         Me._fileNameButton = New System.Windows.Forms.Button()
         Me._fileNameTextBox = New System.Windows.Forms.TextBox()
         Me._fileNameLabel = New System.Windows.Forms.Label()
         Me._modeComboBox = New System.Windows.Forms.ComboBox()
         Me._modeLabel = New System.Windows.Forms.Label()
         Me._optionsGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(322, 121)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 1
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(403, 121)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 2
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _optionsGroupBox
         ' 
         Me._optionsGroupBox.Controls.Add(Me._fileNameButton)
         Me._optionsGroupBox.Controls.Add(Me._fileNameTextBox)
         Me._optionsGroupBox.Controls.Add(Me._fileNameLabel)
         Me._optionsGroupBox.Controls.Add(Me._modeComboBox)
         Me._optionsGroupBox.Controls.Add(Me._modeLabel)
         Me._optionsGroupBox.Location = New System.Drawing.Point(13, 13)
         Me._optionsGroupBox.Name = "_optionsGroupBox"
         Me._optionsGroupBox.Size = New System.Drawing.Size(469, 102)
         Me._optionsGroupBox.TabIndex = 0
         Me._optionsGroupBox.TabStop = False
         Me._optionsGroupBox.Text = "&Options:"
         ' 
         ' _fileNameButton
         ' 
         Me._fileNameButton.Location = New System.Drawing.Point(421, 61)
         Me._fileNameButton.Name = "_fileNameButton"
         Me._fileNameButton.Size = New System.Drawing.Size(29, 23)
         Me._fileNameButton.TabIndex = 4
         Me._fileNameButton.Text = "&..."
         Me._fileNameButton.UseVisualStyleBackColor = True
         ' 
         ' _fileNameTextBox
         ' 
         Me._fileNameTextBox.Location = New System.Drawing.Point(91, 63)
         Me._fileNameTextBox.Name = "_fileNameTextBox"
         Me._fileNameTextBox.Size = New System.Drawing.Size(324, 20)
         Me._fileNameTextBox.TabIndex = 3
         ' 
         ' _fileNameLabel
         ' 
         Me._fileNameLabel.AutoSize = True
         Me._fileNameLabel.Location = New System.Drawing.Point(16, 63)
         Me._fileNameLabel.Name = "_fileNameLabel"
         Me._fileNameLabel.Size = New System.Drawing.Size(56, 13)
         Me._fileNameLabel.TabIndex = 2
         Me._fileNameLabel.Text = "&File name:"
         ' 
         ' _modeComboBox
         ' 
         Me._modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._modeComboBox.FormattingEnabled = True
         Me._modeComboBox.Location = New System.Drawing.Point(91, 34)
         Me._modeComboBox.Name = "_modeComboBox"
         Me._modeComboBox.Size = New System.Drawing.Size(324, 21)
         Me._modeComboBox.TabIndex = 1
         ' 
         ' _modeLabel
         ' 
         Me._modeLabel.AutoSize = True
         Me._modeLabel.Location = New System.Drawing.Point(16, 34)
         Me._modeLabel.Name = "_modeLabel"
         Me._modeLabel.Size = New System.Drawing.Size(37, 13)
         Me._modeLabel.TabIndex = 0
         Me._modeLabel.Text = "&Mode:"
         ' 
         ' SaveRecognizedXmlDialog
         ' 
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(498, 158)
         Me.Controls.Add(Me._optionsGroupBox)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
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

#End Region

      Private WithEvents _okButton As System.Windows.Forms.Button
      Private _cancelButton As System.Windows.Forms.Button
      Private _optionsGroupBox As System.Windows.Forms.GroupBox
      Private _modeLabel As System.Windows.Forms.Label
      Private _modeComboBox As System.Windows.Forms.ComboBox
      Private _fileNameLabel As System.Windows.Forms.Label
      Private WithEvents _fileNameTextBox As System.Windows.Forms.TextBox
      Private WithEvents _fileNameButton As System.Windows.Forms.Button
   End Class
End Namespace
