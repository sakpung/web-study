<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobForm))
      Me._imageFileNameTextBox = New System.Windows.Forms.TextBox
      Me._imageFileNameLabel = New System.Windows.Forms.Label
      Me._imageFileNameBrowseButton = New System.Windows.Forms.Button
      Me._documentFormatLabel = New System.Windows.Forms.Label
      Me._engineLanguagesButton = New System.Windows.Forms.Button
      Me._imageFileNamePagesLabel = New System.Windows.Forms.Label
      Me._documentFileNameBrowseButton = New System.Windows.Forms.Button
      Me._imageFileNamePagesValueLabel = New System.Windows.Forms.Label
      Me._documentFileNameTextBox = New System.Windows.Forms.TextBox
      Me._engineSettingsButton = New System.Windows.Forms.Button
      Me._viewFinalDocumentCheckBox = New System.Windows.Forms.CheckBox
      Me._exitButton = New System.Windows.Forms.Button
      Me._runButton = New System.Windows.Forms.Button
      Me._imageFilePagesBrowseButton = New System.Windows.Forms.Button
      Me._documentFileNameLabel = New System.Windows.Forms.Label
      Me._optionsGroupBox = New System.Windows.Forms.GroupBox
      Me._preprocessingComboBox = New System.Windows.Forms.ComboBox
      Me._enableTraceCheckBox = New System.Windows.Forms.CheckBox
      Me._continueOnErrorCheckBox = New System.Windows.Forms.CheckBox
      Me._preprocessingLabel = New System.Windows.Forms.Label
      Me._maximumPagesBeforeLtdInfoLabel = New System.Windows.Forms.Label
      Me._maximumPagesBeforeLtdTextBox = New System.Windows.Forms.TextBox
      Me._maximumPagesBeforeLtdLabel = New System.Windows.Forms.Label
      Me._maximumThreadsPerJobInfoLabel = New System.Windows.Forms.Label
      Me._maximumThreadsPerJobTextBox = New System.Windows.Forms.TextBox
      Me._maximumThreadsPerJobLabel = New System.Windows.Forms.Label
      Me._zonesFileNameTextBox = New System.Windows.Forms.TextBox
      Me._zonesFileNameLabel = New System.Windows.Forms.Label
      Me._zonesFileNameBrowseButton = New System.Windows.Forms.Button
      Me._documentFormatsSelectorPanel = New System.Windows.Forms.Panel
      Me._jobDataGroupBox = New System.Windows.Forms.GroupBox
      Me._infoLabel = New System.Windows.Forms.Label
      Me._optionsGroupBox.SuspendLayout()
      Me._jobDataGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_imageFileNameTextBox
      '
      Me._imageFileNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._imageFileNameTextBox.Location = New System.Drawing.Point(124, 36)
      Me._imageFileNameTextBox.Name = "_imageFileNameTextBox"
      Me._imageFileNameTextBox.Size = New System.Drawing.Size(657, 20)
      Me._imageFileNameTextBox.TabIndex = 1
      '
      '_imageFileNameLabel
      '
      Me._imageFileNameLabel.AutoSize = True
      Me._imageFileNameLabel.Location = New System.Drawing.Point(34, 39)
      Me._imageFileNameLabel.Name = "_imageFileNameLabel"
      Me._imageFileNameLabel.Size = New System.Drawing.Size(84, 13)
      Me._imageFileNameLabel.TabIndex = 0
      Me._imageFileNameLabel.Text = "Image file name:"
      '
      '_imageFileNameBrowseButton
      '
      Me._imageFileNameBrowseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._imageFileNameBrowseButton.Location = New System.Drawing.Point(787, 34)
      Me._imageFileNameBrowseButton.Name = "_imageFileNameBrowseButton"
      Me._imageFileNameBrowseButton.Size = New System.Drawing.Size(31, 23)
      Me._imageFileNameBrowseButton.TabIndex = 2
      Me._imageFileNameBrowseButton.Text = "..."
      Me._imageFileNameBrowseButton.UseVisualStyleBackColor = True
      '
      '_documentFormatLabel
      '
      Me._documentFormatLabel.AutoSize = True
      Me._documentFormatLabel.Location = New System.Drawing.Point(44, 88)
      Me._documentFormatLabel.Name = "_documentFormatLabel"
      Me._documentFormatLabel.Size = New System.Drawing.Size(74, 13)
      Me._documentFormatLabel.TabIndex = 6
      Me._documentFormatLabel.Text = "Output format:"
      '
      '_engineLanguagesButton
      '
      Me._engineLanguagesButton.Location = New System.Drawing.Point(680, 9)
      Me._engineLanguagesButton.Name = "_engineLanguagesButton"
      Me._engineLanguagesButton.Size = New System.Drawing.Size(148, 23)
      Me._engineLanguagesButton.TabIndex = 2
      Me._engineLanguagesButton.Text = "Engine languages..."
      Me._engineLanguagesButton.UseVisualStyleBackColor = True
      '
      '_imageFileNamePagesLabel
      '
      Me._imageFileNamePagesLabel.AutoSize = True
      Me._imageFileNamePagesLabel.Location = New System.Drawing.Point(78, 64)
      Me._imageFileNamePagesLabel.Name = "_imageFileNamePagesLabel"
      Me._imageFileNamePagesLabel.Size = New System.Drawing.Size(40, 13)
      Me._imageFileNamePagesLabel.TabIndex = 3
      Me._imageFileNamePagesLabel.Text = "Pages:"
      '
      '_documentFileNameBrowseButton
      '
      Me._documentFileNameBrowseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._documentFileNameBrowseButton.Location = New System.Drawing.Point(787, 113)
      Me._documentFileNameBrowseButton.Name = "_documentFileNameBrowseButton"
      Me._documentFileNameBrowseButton.Size = New System.Drawing.Size(31, 23)
      Me._documentFileNameBrowseButton.TabIndex = 10
      Me._documentFileNameBrowseButton.Text = "..."
      Me._documentFileNameBrowseButton.UseVisualStyleBackColor = True
      '
      '_imageFileNamePagesValueLabel
      '
      Me._imageFileNamePagesValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._imageFileNamePagesValueLabel.Location = New System.Drawing.Point(124, 59)
      Me._imageFileNamePagesValueLabel.Name = "_imageFileNamePagesValueLabel"
      Me._imageFileNamePagesValueLabel.Size = New System.Drawing.Size(294, 23)
      Me._imageFileNamePagesValueLabel.TabIndex = 4
      Me._imageFileNamePagesValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_documentFileNameTextBox
      '
      Me._documentFileNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._documentFileNameTextBox.Location = New System.Drawing.Point(124, 115)
      Me._documentFileNameTextBox.Name = "_documentFileNameTextBox"
      Me._documentFileNameTextBox.Size = New System.Drawing.Size(657, 20)
      Me._documentFileNameTextBox.TabIndex = 9
      '
      '_engineSettingsButton
      '
      Me._engineSettingsButton.Location = New System.Drawing.Point(526, 9)
      Me._engineSettingsButton.Name = "_engineSettingsButton"
      Me._engineSettingsButton.Size = New System.Drawing.Size(148, 23)
      Me._engineSettingsButton.TabIndex = 1
      Me._engineSettingsButton.Text = "Engine settings..."
      Me._engineSettingsButton.UseVisualStyleBackColor = True
      '
      '_viewFinalDocumentCheckBox
      '
      Me._viewFinalDocumentCheckBox.AutoSize = True
      Me._viewFinalDocumentCheckBox.Location = New System.Drawing.Point(8, 383)
      Me._viewFinalDocumentCheckBox.Name = "_viewFinalDocumentCheckBox"
      Me._viewFinalDocumentCheckBox.Size = New System.Drawing.Size(121, 17)
      Me._viewFinalDocumentCheckBox.TabIndex = 5
      Me._viewFinalDocumentCheckBox.Text = "View final document"
      Me._viewFinalDocumentCheckBox.UseVisualStyleBackColor = True
      '
      '_exitButton
      '
      Me._exitButton.Location = New System.Drawing.Point(759, 383)
      Me._exitButton.Name = "_exitButton"
      Me._exitButton.Size = New System.Drawing.Size(75, 23)
      Me._exitButton.TabIndex = 7
      Me._exitButton.Text = "Exit"
      Me._exitButton.UseVisualStyleBackColor = True
      '
      '_runButton
      '
      Me._runButton.Location = New System.Drawing.Point(678, 384)
      Me._runButton.Name = "_runButton"
      Me._runButton.Size = New System.Drawing.Size(75, 23)
      Me._runButton.TabIndex = 6
      Me._runButton.Text = "Run"
      Me._runButton.UseVisualStyleBackColor = True
      '
      '_imageFilePagesBrowseButton
      '
      Me._imageFilePagesBrowseButton.Location = New System.Drawing.Point(424, 59)
      Me._imageFilePagesBrowseButton.Name = "_imageFilePagesBrowseButton"
      Me._imageFilePagesBrowseButton.Size = New System.Drawing.Size(31, 23)
      Me._imageFilePagesBrowseButton.TabIndex = 5
      Me._imageFilePagesBrowseButton.Text = "..."
      Me._imageFilePagesBrowseButton.UseVisualStyleBackColor = True
      '
      '_documentFileNameLabel
      '
      Me._documentFileNameLabel.AutoSize = True
      Me._documentFileNameLabel.Location = New System.Drawing.Point(14, 118)
      Me._documentFileNameLabel.Name = "_documentFileNameLabel"
      Me._documentFileNameLabel.Size = New System.Drawing.Size(104, 13)
      Me._documentFileNameLabel.TabIndex = 8
      Me._documentFileNameLabel.Text = "Document file name:"
      '
      '_optionsGroupBox
      '
      Me._optionsGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._optionsGroupBox.Controls.Add(Me._preprocessingComboBox)
      Me._optionsGroupBox.Controls.Add(Me._enableTraceCheckBox)
      Me._optionsGroupBox.Controls.Add(Me._continueOnErrorCheckBox)
      Me._optionsGroupBox.Controls.Add(Me._preprocessingLabel)
      Me._optionsGroupBox.Controls.Add(Me._maximumPagesBeforeLtdInfoLabel)
      Me._optionsGroupBox.Controls.Add(Me._maximumPagesBeforeLtdTextBox)
      Me._optionsGroupBox.Controls.Add(Me._maximumPagesBeforeLtdLabel)
      Me._optionsGroupBox.Controls.Add(Me._maximumThreadsPerJobInfoLabel)
      Me._optionsGroupBox.Controls.Add(Me._maximumThreadsPerJobTextBox)
      Me._optionsGroupBox.Controls.Add(Me._maximumThreadsPerJobLabel)
      Me._optionsGroupBox.Controls.Add(Me._zonesFileNameTextBox)
      Me._optionsGroupBox.Controls.Add(Me._zonesFileNameLabel)
      Me._optionsGroupBox.Controls.Add(Me._zonesFileNameBrowseButton)
      Me._optionsGroupBox.Location = New System.Drawing.Point(10, 188)
      Me._optionsGroupBox.Name = "_optionsGroupBox"
      Me._optionsGroupBox.Size = New System.Drawing.Size(824, 179)
      Me._optionsGroupBox.TabIndex = 4
      Me._optionsGroupBox.TabStop = False
      Me._optionsGroupBox.Text = "Options:"
      '
      '_preprocessingComboBox
      '
      Me._preprocessingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._preprocessingComboBox.FormattingEnabled = True
      Me._preprocessingComboBox.Location = New System.Drawing.Point(184, 108)
      Me._preprocessingComboBox.Name = "_preprocessingComboBox"
      Me._preprocessingComboBox.Size = New System.Drawing.Size(271, 21)
      Me._preprocessingComboBox.TabIndex = 10
      '
      '_enableTraceCheckBox
      '
      Me._enableTraceCheckBox.AutoSize = True
      Me._enableTraceCheckBox.Location = New System.Drawing.Point(183, 156)
      Me._enableTraceCheckBox.Name = "_enableTraceCheckBox"
      Me._enableTraceCheckBox.Size = New System.Drawing.Size(86, 17)
      Me._enableTraceCheckBox.TabIndex = 12
      Me._enableTraceCheckBox.Text = "Enable trace"
      Me._enableTraceCheckBox.UseVisualStyleBackColor = True
      '
      '_continueOnErrorCheckBox
      '
      Me._continueOnErrorCheckBox.AutoSize = True
      Me._continueOnErrorCheckBox.Location = New System.Drawing.Point(183, 133)
      Me._continueOnErrorCheckBox.Name = "_continueOnErrorCheckBox"
      Me._continueOnErrorCheckBox.Size = New System.Drawing.Size(171, 17)
      Me._continueOnErrorCheckBox.TabIndex = 11
      Me._continueOnErrorCheckBox.Text = "Continue on recoverable errors"
      Me._continueOnErrorCheckBox.UseVisualStyleBackColor = True
      '
      '_preprocessingLabel
      '
      Me._preprocessingLabel.AutoSize = True
      Me._preprocessingLabel.Location = New System.Drawing.Point(100, 111)
      Me._preprocessingLabel.Name = "_preprocessingLabel"
      Me._preprocessingLabel.Size = New System.Drawing.Size(77, 13)
      Me._preprocessingLabel.TabIndex = 9
      Me._preprocessingLabel.Text = "Preprocessing:"
      '
      '_maximumPagesBeforeLtdInfoLabel
      '
      Me._maximumPagesBeforeLtdInfoLabel.AutoSize = True
      Me._maximumPagesBeforeLtdInfoLabel.Location = New System.Drawing.Point(289, 86)
      Me._maximumPagesBeforeLtdInfoLabel.Name = "_maximumPagesBeforeLtdInfoLabel"
      Me._maximumPagesBeforeLtdInfoLabel.Size = New System.Drawing.Size(438, 13)
      Me._maximumPagesBeforeLtdInfoLabel.TabIndex = 8
      Me._maximumPagesBeforeLtdInfoLabel.Text = "or more pages. Select 0 to not use LTD (1 page LTD are always used when multi-thr" & _
          "eading)"
      '
      '_maximumPagesBeforeLtdTextBox
      '
      Me._maximumPagesBeforeLtdTextBox.Location = New System.Drawing.Point(183, 83)
      Me._maximumPagesBeforeLtdTextBox.Name = "_maximumPagesBeforeLtdTextBox"
      Me._maximumPagesBeforeLtdTextBox.Size = New System.Drawing.Size(100, 20)
      Me._maximumPagesBeforeLtdTextBox.TabIndex = 7
      '
      '_maximumPagesBeforeLtdLabel
      '
      Me._maximumPagesBeforeLtdLabel.AutoSize = True
      Me._maximumPagesBeforeLtdLabel.Location = New System.Drawing.Point(14, 86)
      Me._maximumPagesBeforeLtdLabel.Name = "_maximumPagesBeforeLtdLabel"
      Me._maximumPagesBeforeLtdLabel.Size = New System.Drawing.Size(163, 13)
      Me._maximumPagesBeforeLtdLabel.TabIndex = 6
      Me._maximumPagesBeforeLtdLabel.Text = "Use LTD format if document has:"
      '
      '_maximumThreadsPerJobInfoLabel
      '
      Me._maximumThreadsPerJobInfoLabel.AutoSize = True
      Me._maximumThreadsPerJobInfoLabel.Location = New System.Drawing.Point(289, 62)
      Me._maximumThreadsPerJobInfoLabel.Name = "_maximumThreadsPerJobInfoLabel"
      Me._maximumThreadsPerJobInfoLabel.Size = New System.Drawing.Size(486, 13)
      Me._maximumThreadsPerJobInfoLabel.TabIndex = 5
      Me._maximumThreadsPerJobInfoLabel.Text = "0 = Use all available CPUs/Cores (fastest), 1 = Single threaded, otherwise, numbe" & _
          "r of threads up to 64"
      '
      '_maximumThreadsPerJobTextBox
      '
      Me._maximumThreadsPerJobTextBox.Location = New System.Drawing.Point(183, 57)
      Me._maximumThreadsPerJobTextBox.Name = "_maximumThreadsPerJobTextBox"
      Me._maximumThreadsPerJobTextBox.Size = New System.Drawing.Size(100, 20)
      Me._maximumThreadsPerJobTextBox.TabIndex = 4
      '
      '_maximumThreadsPerJobLabel
      '
      Me._maximumThreadsPerJobLabel.AutoSize = True
      Me._maximumThreadsPerJobLabel.Location = New System.Drawing.Point(45, 60)
      Me._maximumThreadsPerJobLabel.Name = "_maximumThreadsPerJobLabel"
      Me._maximumThreadsPerJobLabel.Size = New System.Drawing.Size(132, 13)
      Me._maximumThreadsPerJobLabel.TabIndex = 3
      Me._maximumThreadsPerJobLabel.Text = "Multi-threaded documents:"
      '
      '_zonesFileNameTextBox
      '
      Me._zonesFileNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._zonesFileNameTextBox.Location = New System.Drawing.Point(183, 29)
      Me._zonesFileNameTextBox.Name = "_zonesFileNameTextBox"
      Me._zonesFileNameTextBox.Size = New System.Drawing.Size(598, 20)
      Me._zonesFileNameTextBox.TabIndex = 1
      '
      '_zonesFileNameLabel
      '
      Me._zonesFileNameLabel.AutoSize = True
      Me._zonesFileNameLabel.Location = New System.Drawing.Point(92, 32)
      Me._zonesFileNameLabel.Name = "_zonesFileNameLabel"
      Me._zonesFileNameLabel.Size = New System.Drawing.Size(85, 13)
      Me._zonesFileNameLabel.TabIndex = 0
      Me._zonesFileNameLabel.Text = "Zones file name:"
      '
      '_zonesFileNameBrowseButton
      '
      Me._zonesFileNameBrowseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._zonesFileNameBrowseButton.Location = New System.Drawing.Point(787, 27)
      Me._zonesFileNameBrowseButton.Name = "_zonesFileNameBrowseButton"
      Me._zonesFileNameBrowseButton.Size = New System.Drawing.Size(31, 23)
      Me._zonesFileNameBrowseButton.TabIndex = 2
      Me._zonesFileNameBrowseButton.Text = "..."
      Me._zonesFileNameBrowseButton.UseVisualStyleBackColor = True
      '
      '_documentFormatsSelectorPanel
      '
      Me._documentFormatsSelectorPanel.Location = New System.Drawing.Point(124, 86)
      Me._documentFormatsSelectorPanel.Name = "_documentFormatsSelectorPanel"
      Me._documentFormatsSelectorPanel.Size = New System.Drawing.Size(331, 23)
      Me._documentFormatsSelectorPanel.TabIndex = 7
      '
      '_jobDataGroupBox
      '
      Me._jobDataGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._jobDataGroupBox.Controls.Add(Me._documentFormatsSelectorPanel)
      Me._jobDataGroupBox.Controls.Add(Me._imageFileNameTextBox)
      Me._jobDataGroupBox.Controls.Add(Me._imageFileNameLabel)
      Me._jobDataGroupBox.Controls.Add(Me._imageFileNameBrowseButton)
      Me._jobDataGroupBox.Controls.Add(Me._documentFormatLabel)
      Me._jobDataGroupBox.Controls.Add(Me._imageFileNamePagesLabel)
      Me._jobDataGroupBox.Controls.Add(Me._documentFileNameBrowseButton)
      Me._jobDataGroupBox.Controls.Add(Me._imageFileNamePagesValueLabel)
      Me._jobDataGroupBox.Controls.Add(Me._documentFileNameTextBox)
      Me._jobDataGroupBox.Controls.Add(Me._imageFilePagesBrowseButton)
      Me._jobDataGroupBox.Controls.Add(Me._documentFileNameLabel)
      Me._jobDataGroupBox.Location = New System.Drawing.Point(10, 33)
      Me._jobDataGroupBox.Name = "_jobDataGroupBox"
      Me._jobDataGroupBox.Size = New System.Drawing.Size(824, 149)
      Me._jobDataGroupBox.TabIndex = 3
      Me._jobDataGroupBox.TabStop = False
      Me._jobDataGroupBox.Text = "Job data:"
      '
      '_infoLabel
      '
      Me._infoLabel.AutoSize = True
      Me._infoLabel.Location = New System.Drawing.Point(7, 6)
      Me._infoLabel.Name = "_infoLabel"
      Me._infoLabel.Size = New System.Drawing.Size(404, 13)
      Me._infoLabel.TabIndex = 0
      Me._infoLabel.Text = "This demo shows the different features of the IOcrAutoRecognizeManager interface." & _
          ""
      '
      'JobForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(841, 412)
      Me.Controls.Add(Me._engineLanguagesButton)
      Me.Controls.Add(Me._engineSettingsButton)
      Me.Controls.Add(Me._viewFinalDocumentCheckBox)
      Me.Controls.Add(Me._exitButton)
      Me.Controls.Add(Me._runButton)
      Me.Controls.Add(Me._optionsGroupBox)
      Me.Controls.Add(Me._jobDataGroupBox)
      Me.Controls.Add(Me._infoLabel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.Name = "JobForm"
      Me.Text = "JobForm"
      Me._optionsGroupBox.ResumeLayout(False)
      Me._optionsGroupBox.PerformLayout()
      Me._jobDataGroupBox.ResumeLayout(False)
      Me._jobDataGroupBox.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _imageFileNameTextBox As System.Windows.Forms.TextBox
   Private WithEvents _imageFileNameLabel As System.Windows.Forms.Label
   Private WithEvents _imageFileNameBrowseButton As System.Windows.Forms.Button
   Private WithEvents _documentFormatLabel As System.Windows.Forms.Label
   Private WithEvents _engineLanguagesButton As System.Windows.Forms.Button
   Private WithEvents _imageFileNamePagesLabel As System.Windows.Forms.Label
   Private WithEvents _documentFileNameBrowseButton As System.Windows.Forms.Button
   Private WithEvents _imageFileNamePagesValueLabel As System.Windows.Forms.Label
   Private WithEvents _documentFileNameTextBox As System.Windows.Forms.TextBox
   Private WithEvents _engineSettingsButton As System.Windows.Forms.Button
   Private WithEvents _viewFinalDocumentCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _exitButton As System.Windows.Forms.Button
   Private WithEvents _runButton As System.Windows.Forms.Button
   Private WithEvents _imageFilePagesBrowseButton As System.Windows.Forms.Button
   Private WithEvents _documentFileNameLabel As System.Windows.Forms.Label
   Private WithEvents _optionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _preprocessingComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _enableTraceCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _continueOnErrorCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _preprocessingLabel As System.Windows.Forms.Label
   Private WithEvents _maximumPagesBeforeLtdInfoLabel As System.Windows.Forms.Label
   Private WithEvents _maximumPagesBeforeLtdTextBox As System.Windows.Forms.TextBox
   Private WithEvents _maximumPagesBeforeLtdLabel As System.Windows.Forms.Label
   Private WithEvents _maximumThreadsPerJobInfoLabel As System.Windows.Forms.Label
   Private WithEvents _maximumThreadsPerJobTextBox As System.Windows.Forms.TextBox
   Private WithEvents _maximumThreadsPerJobLabel As System.Windows.Forms.Label
   Private WithEvents _zonesFileNameTextBox As System.Windows.Forms.TextBox
   Private WithEvents _zonesFileNameLabel As System.Windows.Forms.Label
   Private WithEvents _zonesFileNameBrowseButton As System.Windows.Forms.Button
   Private WithEvents _documentFormatsSelectorPanel As System.Windows.Forms.Panel
   Private WithEvents _jobDataGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _infoLabel As System.Windows.Forms.Label
End Class
