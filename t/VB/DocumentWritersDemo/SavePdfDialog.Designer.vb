Namespace DocumentWritersDemo
   Partial Class SavePdfDialog
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
         Me._documentFileNameGroupBox = New System.Windows.Forms.GroupBox()
         Me._browseDocumentFileNameButton = New System.Windows.Forms.Button()
         Me._documentFileNameTextBox = New System.Windows.Forms.TextBox()
         Me._pdfOptionsTabControl = New System.Windows.Forms.TabControl()
         Me._generalTabPage = New System.Windows.Forms.TabPage()
         Me._pdfAdvancedOptionsButton = New System.Windows.Forms.Button()
         Me._resolutionNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me._pixelsInchesLabel = New System.Windows.Forms.Label()
         Me._resolutionComboBox = New System.Windows.Forms.ComboBox()
         Me._resolutionLabel = New System.Windows.Forms.Label()
         Me._documentTypeComboBox = New System.Windows.Forms.ComboBox()
         Me._documentTypeLabel = New System.Windows.Forms.Label()
         Me._pdfOptionsLabel = New System.Windows.Forms.Label()
         Me._documentFileNameGroupBox.SuspendLayout()
         Me._pdfOptionsTabControl.SuspendLayout()
         Me._generalTabPage.SuspendLayout()
         CType(Me._resolutionNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(460, 291)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 3
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(541, 291)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 4
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _documentFileNameGroupBox
         ' 
         Me._documentFileNameGroupBox.Controls.Add(Me._browseDocumentFileNameButton)
         Me._documentFileNameGroupBox.Controls.Add(Me._documentFileNameTextBox)
         Me._documentFileNameGroupBox.Location = New System.Drawing.Point(12, 12)
         Me._documentFileNameGroupBox.Name = "_documentFileNameGroupBox"
         Me._documentFileNameGroupBox.Size = New System.Drawing.Size(604, 70)
         Me._documentFileNameGroupBox.TabIndex = 0
         Me._documentFileNameGroupBox.TabStop = False
         Me._documentFileNameGroupBox.Text = "Output document file name:"
         ' 
         ' _browseDocumentFileNameButton
         ' 
         Me._browseDocumentFileNameButton.Location = New System.Drawing.Point(559, 26)
         Me._browseDocumentFileNameButton.Name = "_browseDocumentFileNameButton"
         Me._browseDocumentFileNameButton.Size = New System.Drawing.Size(29, 23)
         Me._browseDocumentFileNameButton.TabIndex = 1
         Me._browseDocumentFileNameButton.Text = "..."
         Me._browseDocumentFileNameButton.UseVisualStyleBackColor = True
         ' 
         ' _documentFileNameTextBox
         ' 
         Me._documentFileNameTextBox.Location = New System.Drawing.Point(21, 28)
         Me._documentFileNameTextBox.Name = "_documentFileNameTextBox"
         Me._documentFileNameTextBox.Size = New System.Drawing.Size(532, 20)
         Me._documentFileNameTextBox.TabIndex = 0
         ' 
         ' _pdfOptionsTabControl
         ' 
         Me._pdfOptionsTabControl.Controls.Add(Me._generalTabPage)
         Me._pdfOptionsTabControl.Location = New System.Drawing.Point(8, 112)
         Me._pdfOptionsTabControl.Name = "_pdfOptionsTabControl"
         Me._pdfOptionsTabControl.SelectedIndex = 0
         Me._pdfOptionsTabControl.Size = New System.Drawing.Size(608, 173)
         Me._pdfOptionsTabControl.TabIndex = 2
         ' 
         ' _generalTabPage
         ' 
         Me._generalTabPage.Controls.Add(Me._pdfAdvancedOptionsButton)
         Me._generalTabPage.Controls.Add(Me._resolutionNumericUpDown)
         Me._generalTabPage.Controls.Add(Me._pixelsInchesLabel)
         Me._generalTabPage.Controls.Add(Me._resolutionComboBox)
         Me._generalTabPage.Controls.Add(Me._resolutionLabel)
         Me._generalTabPage.Controls.Add(Me._documentTypeComboBox)
         Me._generalTabPage.Controls.Add(Me._documentTypeLabel)
         Me._generalTabPage.Location = New System.Drawing.Point(4, 22)
         Me._generalTabPage.Name = "_generalTabPage"
         Me._generalTabPage.Size = New System.Drawing.Size(600, 147)
         Me._generalTabPage.TabIndex = 0
         Me._generalTabPage.Text = "General"
         Me._generalTabPage.UseVisualStyleBackColor = True
         ' 
         ' _pdfAdvancedOptionsButton
         ' 
         Me._pdfAdvancedOptionsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._pdfAdvancedOptionsButton.Location = New System.Drawing.Point(161, 45)
         Me._pdfAdvancedOptionsButton.Name = "_pdfAdvancedOptionsButton"
         Me._pdfAdvancedOptionsButton.Size = New System.Drawing.Size(225, 23)
         Me._pdfAdvancedOptionsButton.TabIndex = 12
         Me._pdfAdvancedOptionsButton.Text = "Advanced Options..."
         Me._pdfAdvancedOptionsButton.UseVisualStyleBackColor = True
         ' 
         ' _resolutionNumericUpDown
         ' 
         Me._resolutionNumericUpDown.Increment = New Decimal(New Integer() {10, 0, 0, 0})
         Me._resolutionNumericUpDown.Location = New System.Drawing.Point(294, 74)
         Me._resolutionNumericUpDown.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
         Me._resolutionNumericUpDown.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
         Me._resolutionNumericUpDown.Name = "_resolutionNumericUpDown"
         Me._resolutionNumericUpDown.Size = New System.Drawing.Size(49, 20)
         Me._resolutionNumericUpDown.TabIndex = 5
         Me._resolutionNumericUpDown.Value = New Decimal(New Integer() {96, 0, 0, 0})
         ' 
         ' _pixelsInchesLabel
         ' 
         Me._pixelsInchesLabel.AutoSize = True
         Me._pixelsInchesLabel.Location = New System.Drawing.Point(349, 77)
         Me._pixelsInchesLabel.Name = "_pixelsInchesLabel"
         Me._pixelsInchesLabel.Size = New System.Drawing.Size(96, 13)
         Me._pixelsInchesLabel.TabIndex = 11
         Me._pixelsInchesLabel.Text = "pixels/inches (DPI)"
         ' 
         ' _resolutionComboBox
         ' 
         Me._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._resolutionComboBox.FormattingEnabled = True
         Me._resolutionComboBox.Items.AddRange(New Object() {"Default", "Custom"})
         Me._resolutionComboBox.Location = New System.Drawing.Point(161, 74)
         Me._resolutionComboBox.Name = "_resolutionComboBox"
         Me._resolutionComboBox.Size = New System.Drawing.Size(127, 21)
         Me._resolutionComboBox.TabIndex = 4
         ' 
         ' _resolutionLabel
         ' 
         Me._resolutionLabel.AutoSize = True
         Me._resolutionLabel.Location = New System.Drawing.Point(14, 79)
         Me._resolutionLabel.Name = "_resolutionLabel"
         Me._resolutionLabel.Size = New System.Drawing.Size(140, 13)
         Me._resolutionLabel.TabIndex = 9
         Me._resolutionLabel.Text = "Output document resolution:"
         ' 
         ' _documentTypeComboBox
         ' 
         Me._documentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._documentTypeComboBox.FormattingEnabled = True
         Me._documentTypeComboBox.Location = New System.Drawing.Point(161, 19)
         Me._documentTypeComboBox.Name = "_documentTypeComboBox"
         Me._documentTypeComboBox.Size = New System.Drawing.Size(225, 21)
         Me._documentTypeComboBox.TabIndex = 1
         ' 
         ' _documentTypeLabel
         ' 
         Me._documentTypeLabel.AutoSize = True
         Me._documentTypeLabel.Location = New System.Drawing.Point(14, 22)
         Me._documentTypeLabel.Name = "_documentTypeLabel"
         Me._documentTypeLabel.Size = New System.Drawing.Size(82, 13)
         Me._documentTypeLabel.TabIndex = 0
         Me._documentTypeLabel.Text = "Document type:"
         ' 
         ' _pdfOptionsLabel
         ' 
         Me._pdfOptionsLabel.AutoSize = True
         Me._pdfOptionsLabel.Location = New System.Drawing.Point(9, 96)
         Me._pdfOptionsLabel.Name = "_pdfOptionsLabel"
         Me._pdfOptionsLabel.Size = New System.Drawing.Size(68, 13)
         Me._pdfOptionsLabel.TabIndex = 1
         Me._pdfOptionsLabel.Text = "PDF options:"
         ' 
         ' SavePdfDialog
         ' 
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(632, 321)
         Me.Controls.Add(Me._pdfOptionsLabel)
         Me.Controls.Add(Me._pdfOptionsTabControl)
         Me.Controls.Add(Me._documentFileNameGroupBox)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SavePdfDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Save Document"
         Me._documentFileNameGroupBox.ResumeLayout(False)
         Me._documentFileNameGroupBox.PerformLayout()
         Me._pdfOptionsTabControl.ResumeLayout(False)
         Me._generalTabPage.ResumeLayout(False)
         Me._generalTabPage.PerformLayout()
         CType(Me._resolutionNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents _okButton As System.Windows.Forms.Button
      Private _cancelButton As System.Windows.Forms.Button
      Private _documentFileNameGroupBox As System.Windows.Forms.GroupBox
      Private _documentFileNameTextBox As System.Windows.Forms.TextBox
      Private WithEvents _browseDocumentFileNameButton As System.Windows.Forms.Button
      Private _pdfOptionsTabControl As System.Windows.Forms.TabControl
      Private _generalTabPage As System.Windows.Forms.TabPage
      Private _pdfOptionsLabel As System.Windows.Forms.Label
      Private WithEvents _documentTypeComboBox As System.Windows.Forms.ComboBox
      Private _documentTypeLabel As System.Windows.Forms.Label
      Private _pixelsInchesLabel As System.Windows.Forms.Label
      Private WithEvents _resolutionComboBox As System.Windows.Forms.ComboBox
      Private _resolutionLabel As System.Windows.Forms.Label
      Private _resolutionNumericUpDown As System.Windows.Forms.NumericUpDown
      Private WithEvents _pdfAdvancedOptionsButton As System.Windows.Forms.Button
   End Class
End Namespace
