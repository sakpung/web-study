
Partial Class DocumentConverterDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentConverterDialog))
      Me._tabControl = New System.Windows.Forms.TabControl()
      Me._documentTabPage = New System.Windows.Forms.TabPage()
      Me._documentControl = New DocumentConverterDocumentControl()
      Me._optionsTabPage = New System.Windows.Forms.TabPage()
      Me._optionsControl = New DocumentConverterOptionsControl()
      Me._ocrSettingsTabPage = New System.Windows.Forms.TabPage()
      Me._ocrEngineSettingsControl = New OcrEngineSettingsControl()
      Me._ocrEnginePanel = New System.Windows.Forms.Panel()
      Me._ocrEngineLabel = New System.Windows.Forms.Label()
      Me._ocrLanguagesTabPage = New System.Windows.Forms.TabPage()
      Me._languagesGroupBox = New System.Windows.Forms.GroupBox()
      Me._languagesAdditionalLabel = New System.Windows.Forms.Label()
      Me._languagesHintLabel = New System.Windows.Forms.Label()
      Me._languagesMoveTopButton = New System.Windows.Forms.Button()
      Me._enabledLanguagesListBox = New System.Windows.Forms.ListBox()
      Me._enabledLanguagesLabel = New System.Windows.Forms.Label()
      Me._languagesMoveLeftButton = New System.Windows.Forms.Button()
      Me._languagesMoveRightButton = New System.Windows.Forms.Button()
      Me._languagesListBox = New System.Windows.Forms.ListBox()
      Me._languagesLabel = New System.Windows.Forms.Label()
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._aboutButton = New System.Windows.Forms.Button()
      Me._tabControl.SuspendLayout()
      Me._documentTabPage.SuspendLayout()
      Me._optionsTabPage.SuspendLayout()
      Me._ocrSettingsTabPage.SuspendLayout()
      Me._ocrEnginePanel.SuspendLayout()
      Me._ocrLanguagesTabPage.SuspendLayout()
      Me._languagesGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_tabControl
      '
      Me._tabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._tabControl.Controls.Add(Me._documentTabPage)
      Me._tabControl.Controls.Add(Me._optionsTabPage)
      Me._tabControl.Controls.Add(Me._ocrSettingsTabPage)
      Me._tabControl.Controls.Add(Me._ocrLanguagesTabPage)
      Me._tabControl.Location = New System.Drawing.Point(12, 12)
      Me._tabControl.Name = "_tabControl"
      Me._tabControl.SelectedIndex = 0
      Me._tabControl.Size = New System.Drawing.Size(646, 344)
      Me._tabControl.TabIndex = 0
      '
      '_documentTabPage
      '
      Me._documentTabPage.Controls.Add(Me._documentControl)
      Me._documentTabPage.Location = New System.Drawing.Point(4, 22)
      Me._documentTabPage.Name = "_documentTabPage"
      Me._documentTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._documentTabPage.Size = New System.Drawing.Size(638, 318)
      Me._documentTabPage.TabIndex = 0
      Me._documentTabPage.Text = "Document"
      Me._documentTabPage.UseVisualStyleBackColor = True
      '
      '_documentControl
      '
      Me._documentControl.Dock = System.Windows.Forms.DockStyle.Fill
      Me._documentControl.Location = New System.Drawing.Point(3, 3)
      Me._documentControl.Name = "_documentControl"
      Me._documentControl.Size = New System.Drawing.Size(632, 312)
      Me._documentControl.TabIndex = 0
      '
      '_optionsTabPage
      '
      Me._optionsTabPage.Controls.Add(Me._optionsControl)
      Me._optionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._optionsTabPage.Name = "_optionsTabPage"
      Me._optionsTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._optionsTabPage.Size = New System.Drawing.Size(638, 318)
      Me._optionsTabPage.TabIndex = 1
      Me._optionsTabPage.Text = "Options"
      Me._optionsTabPage.UseVisualStyleBackColor = True
      '
      '_optionsControl
      '
      Me._optionsControl.Dock = System.Windows.Forms.DockStyle.Fill
      Me._optionsControl.Location = New System.Drawing.Point(3, 3)
      Me._optionsControl.Name = "_optionsControl"
      Me._optionsControl.Size = New System.Drawing.Size(632, 312)
      Me._optionsControl.TabIndex = 0
      '
      '_ocrSettingsTabPage
      '
      Me._ocrSettingsTabPage.Controls.Add(Me._ocrEngineSettingsControl)
      Me._ocrSettingsTabPage.Controls.Add(Me._ocrEnginePanel)
      Me._ocrSettingsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._ocrSettingsTabPage.Name = "_ocrSettingsTabPage"
      Me._ocrSettingsTabPage.Size = New System.Drawing.Size(638, 318)
      Me._ocrSettingsTabPage.TabIndex = 2
      Me._ocrSettingsTabPage.Text = "OCR Settings"
      Me._ocrSettingsTabPage.UseVisualStyleBackColor = True
      '
      '_ocrEngineSettingsControl
      '
      Me._ocrEngineSettingsControl.Location = New System.Drawing.Point(3, 32)
      Me._ocrEngineSettingsControl.Name = "_ocrEngineSettingsControl"
      Me._ocrEngineSettingsControl.Size = New System.Drawing.Size(510, 266)
      Me._ocrEngineSettingsControl.TabIndex = 1
      '
      '_ocrEnginePanel
      '
      Me._ocrEnginePanel.Controls.Add(Me._ocrEngineLabel)
      Me._ocrEnginePanel.Dock = System.Windows.Forms.DockStyle.Top
      Me._ocrEnginePanel.Location = New System.Drawing.Point(0, 0)
      Me._ocrEnginePanel.Name = "_ocrEnginePanel"
      Me._ocrEnginePanel.Size = New System.Drawing.Size(638, 26)
      Me._ocrEnginePanel.TabIndex = 0
      '
      '_ocrEngineLabel
      '
      Me._ocrEngineLabel.AutoSize = True
      Me._ocrEngineLabel.Location = New System.Drawing.Point(12, 8)
      Me._ocrEngineLabel.Name = "_ocrEngineLabel"
      Me._ocrEngineLabel.Size = New System.Drawing.Size(90, 13)
      Me._ocrEngineLabel.TabIndex = 0
      Me._ocrEngineLabel.Text = "OCR Engine:###"
      '
      '_ocrLanguagesTabPage
      '
      Me._ocrLanguagesTabPage.Controls.Add(Me._languagesGroupBox)
      Me._ocrLanguagesTabPage.Location = New System.Drawing.Point(4, 22)
      Me._ocrLanguagesTabPage.Name = "_ocrLanguagesTabPage"
      Me._ocrLanguagesTabPage.Size = New System.Drawing.Size(638, 318)
      Me._ocrLanguagesTabPage.TabIndex = 3
      Me._ocrLanguagesTabPage.Text = "OCR Languages"
      Me._ocrLanguagesTabPage.UseVisualStyleBackColor = True
      '
      '_languagesGroupBox
      '
      Me._languagesGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._languagesGroupBox.Controls.Add(Me._languagesAdditionalLabel)
      Me._languagesGroupBox.Controls.Add(Me._languagesHintLabel)
      Me._languagesGroupBox.Controls.Add(Me._languagesMoveTopButton)
      Me._languagesGroupBox.Controls.Add(Me._enabledLanguagesListBox)
      Me._languagesGroupBox.Controls.Add(Me._enabledLanguagesLabel)
      Me._languagesGroupBox.Controls.Add(Me._languagesMoveLeftButton)
      Me._languagesGroupBox.Controls.Add(Me._languagesMoveRightButton)
      Me._languagesGroupBox.Controls.Add(Me._languagesListBox)
      Me._languagesGroupBox.Controls.Add(Me._languagesLabel)
      Me._languagesGroupBox.Location = New System.Drawing.Point(8, 12)
      Me._languagesGroupBox.Name = "_languagesGroupBox"
      Me._languagesGroupBox.Size = New System.Drawing.Size(622, 294)
      Me._languagesGroupBox.TabIndex = 1
      Me._languagesGroupBox.TabStop = False
      Me._languagesGroupBox.Text = "Select the OCR languages to enable in this demo:"
      '
      '_languagesAdditionalLabel
      '
      Me._languagesAdditionalLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._languagesAdditionalLabel.Location = New System.Drawing.Point(18, 225)
      Me._languagesAdditionalLabel.Name = "_languagesAdditionalLabel"
      Me._languagesAdditionalLabel.Size = New System.Drawing.Size(584, 56)
      Me._languagesAdditionalLabel.TabIndex = 8
      '
      '_languagesHintLabel
      '
      Me._languagesHintLabel.AutoSize = True
      Me._languagesHintLabel.Location = New System.Drawing.Point(16, 202)
      Me._languagesHintLabel.Name = "_languagesHintLabel"
      Me._languagesHintLabel.Size = New System.Drawing.Size(341, 13)
      Me._languagesHintLabel.TabIndex = 7
      Me._languagesHintLabel.Text = "Hint: The main language is the first item in the 'Enabled Languages' list."
      '
      '_languagesMoveTopButton
      '
      Me._languagesMoveTopButton.Location = New System.Drawing.Point(390, 49)
      Me._languagesMoveTopButton.Name = "_languagesMoveTopButton"
      Me._languagesMoveTopButton.Size = New System.Drawing.Size(32, 32)
      Me._languagesMoveTopButton.TabIndex = 6
      Me._languagesMoveTopButton.Text = "^"
      Me._languagesMoveTopButton.UseVisualStyleBackColor = True
      '
      '_enabledLanguagesListBox
      '
      Me._enabledLanguagesListBox.FormattingEnabled = True
      Me._enabledLanguagesListBox.Location = New System.Drawing.Point(224, 49)
      Me._enabledLanguagesListBox.Name = "_enabledLanguagesListBox"
      Me._enabledLanguagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
      Me._enabledLanguagesListBox.Size = New System.Drawing.Size(160, 147)
      Me._enabledLanguagesListBox.TabIndex = 5
      '
      '_enabledLanguagesLabel
      '
      Me._enabledLanguagesLabel.AutoSize = True
      Me._enabledLanguagesLabel.Location = New System.Drawing.Point(221, 27)
      Me._enabledLanguagesLabel.Name = "_enabledLanguagesLabel"
      Me._enabledLanguagesLabel.Size = New System.Drawing.Size(102, 13)
      Me._enabledLanguagesLabel.TabIndex = 4
      Me._enabledLanguagesLabel.Text = "Enabled Languages"
      '
      '_languagesMoveLeftButton
      '
      Me._languagesMoveLeftButton.Location = New System.Drawing.Point(185, 152)
      Me._languagesMoveLeftButton.Name = "_languagesMoveLeftButton"
      Me._languagesMoveLeftButton.Size = New System.Drawing.Size(32, 32)
      Me._languagesMoveLeftButton.TabIndex = 3
      Me._languagesMoveLeftButton.Text = "<"
      Me._languagesMoveLeftButton.UseVisualStyleBackColor = True
      '
      '_languagesMoveRightButton
      '
      Me._languagesMoveRightButton.Location = New System.Drawing.Point(185, 114)
      Me._languagesMoveRightButton.Name = "_languagesMoveRightButton"
      Me._languagesMoveRightButton.Size = New System.Drawing.Size(32, 32)
      Me._languagesMoveRightButton.TabIndex = 2
      Me._languagesMoveRightButton.Text = ">"
      Me._languagesMoveRightButton.UseVisualStyleBackColor = True
      '
      '_languagesListBox
      '
      Me._languagesListBox.FormattingEnabled = True
      Me._languagesListBox.Location = New System.Drawing.Point(19, 49)
      Me._languagesListBox.Name = "_languagesListBox"
      Me._languagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
      Me._languagesListBox.Size = New System.Drawing.Size(160, 147)
      Me._languagesListBox.TabIndex = 1
      '
      '_languagesLabel
      '
      Me._languagesLabel.AutoSize = True
      Me._languagesLabel.Location = New System.Drawing.Point(16, 28)
      Me._languagesLabel.Name = "_languagesLabel"
      Me._languagesLabel.Size = New System.Drawing.Size(106, 13)
      Me._languagesLabel.TabIndex = 0
      Me._languagesLabel.Text = "Available Languages"
      '
      '_okButton
      '
      Me._okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(502, 362)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 2
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_cancelButton
      '
      Me._cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(583, 362)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 3
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_aboutButton
      '
      Me._aboutButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me._aboutButton.Location = New System.Drawing.Point(12, 362)
      Me._aboutButton.Name = "_aboutButton"
      Me._aboutButton.Size = New System.Drawing.Size(75, 23)
      Me._aboutButton.TabIndex = 1
      Me._aboutButton.Text = "About..."
      Me._aboutButton.UseVisualStyleBackColor = True
      '
      'DocumentConverterDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(670, 393)
      Me.Controls.Add(Me._aboutButton)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.Controls.Add(Me._tabControl)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DocumentConverterDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Document Converter Options"
      Me._tabControl.ResumeLayout(False)
      Me._documentTabPage.ResumeLayout(False)
      Me._optionsTabPage.ResumeLayout(False)
      Me._ocrSettingsTabPage.ResumeLayout(False)
      Me._ocrEnginePanel.ResumeLayout(False)
      Me._ocrEnginePanel.PerformLayout()
      Me._ocrLanguagesTabPage.ResumeLayout(False)
      Me._languagesGroupBox.ResumeLayout(False)
      Me._languagesGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _tabControl As System.Windows.Forms.TabControl
   Private _documentTabPage As System.Windows.Forms.TabPage
   Private _optionsTabPage As System.Windows.Forms.TabPage
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _documentControl As DocumentConverterDocumentControl
   Private _optionsControl As DocumentConverterOptionsControl
   Private WithEvents _aboutButton As System.Windows.Forms.Button
   Private _ocrSettingsTabPage As System.Windows.Forms.TabPage
   Private _ocrLanguagesTabPage As System.Windows.Forms.TabPage
   Private _ocrEngineSettingsControl As OcrEngineSettingsControl
   Private _ocrEnginePanel As System.Windows.Forms.Panel
   Private _ocrEngineLabel As System.Windows.Forms.Label
   Private WithEvents _languagesGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _languagesAdditionalLabel As System.Windows.Forms.Label
   Private WithEvents _languagesHintLabel As System.Windows.Forms.Label
   Private WithEvents _languagesMoveTopButton As System.Windows.Forms.Button
   Private WithEvents _enabledLanguagesListBox As System.Windows.Forms.ListBox
   Private WithEvents _enabledLanguagesLabel As System.Windows.Forms.Label
   Private WithEvents _languagesMoveLeftButton As System.Windows.Forms.Button
   Private WithEvents _languagesMoveRightButton As System.Windows.Forms.Button
   Private WithEvents _languagesListBox As System.Windows.Forms.ListBox
   Private WithEvents _languagesLabel As System.Windows.Forms.Label
End Class
