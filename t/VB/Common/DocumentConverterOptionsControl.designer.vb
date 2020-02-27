Partial Class DocumentConverterOptionsControl
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me._deskewCheckBox = New System.Windows.Forms.CheckBox()
      Me._orientCheckBox = New System.Windows.Forms.CheckBox()
      Me._invertCheckBox = New System.Windows.Forms.CheckBox()
      Me._preprocessingComboBox = New System.Windows.Forms.GroupBox()
      Me._generalGroupBox = New System.Windows.Forms.GroupBox()
      Me._svgImagesRecognitionModeHelpLabel = New System.Windows.Forms.Label()
      Me._emptyPageModeModeLabel = New System.Windows.Forms.Label()
      Me._emptyPageModeComboBox = New System.Windows.Forms.ComboBox()
      Me._useThreadsCheckBox = New System.Windows.Forms.CheckBox()
      Me._svgImagesRecognitionModeLabel = New System.Windows.Forms.Label()
      Me._svgImagesRecognitionModeComboBox = New System.Windows.Forms.ComboBox()
      Me._jobNameTextBox = New System.Windows.Forms.TextBox()
      Me._jobNameLabel = New System.Windows.Forms.Label()
      Me._enableSvgConversionCheckBox = New System.Windows.Forms.CheckBox()
      Me._openOutputDocumentCheckBox = New System.Windows.Forms.CheckBox()
      Me._enableTraceCheckBox = New System.Windows.Forms.CheckBox()
      Me._continueOnRecoverableErrorsCheckBox = New System.Windows.Forms.CheckBox()
      Me._defaultButton = New System.Windows.Forms.Button()
      Me._redactionOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._redactionOptionsControl = New DocumentRedactionOptionsControl()
      Me._preprocessingComboBox.SuspendLayout()
      Me._generalGroupBox.SuspendLayout()
      Me._redactionOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      Me._deskewCheckBox.AutoSize = True
      Me._deskewCheckBox.Location = New System.Drawing.Point(28, 31)
      Me._deskewCheckBox.Name = "_deskewCheckBox"
      Me._deskewCheckBox.Size = New System.Drawing.Size(65, 17)
      Me._deskewCheckBox.TabIndex = 0
      Me._deskewCheckBox.Text = "&Deskew"
      Me._deskewCheckBox.UseVisualStyleBackColor = True
      Me._orientCheckBox.AutoSize = True
      Me._orientCheckBox.Location = New System.Drawing.Point(205, 31)
      Me._orientCheckBox.Name = "_orientCheckBox"
      Me._orientCheckBox.Size = New System.Drawing.Size(54, 17)
      Me._orientCheckBox.TabIndex = 2
      Me._orientCheckBox.Text = "O&rient"
      Me._orientCheckBox.UseVisualStyleBackColor = True
      Me._invertCheckBox.AutoSize = True
      Me._invertCheckBox.Location = New System.Drawing.Point(117, 31)
      Me._invertCheckBox.Name = "_invertCheckBox"
      Me._invertCheckBox.Size = New System.Drawing.Size(53, 17)
      Me._invertCheckBox.TabIndex = 1
      Me._invertCheckBox.Text = "&Invert"
      Me._invertCheckBox.UseVisualStyleBackColor = True
      Me._preprocessingComboBox.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
      Me._preprocessingComboBox.Controls.Add(Me._deskewCheckBox)
      Me._preprocessingComboBox.Controls.Add(Me._orientCheckBox)
      Me._preprocessingComboBox.Controls.Add(Me._invertCheckBox)
      Me._preprocessingComboBox.Location = New System.Drawing.Point(14, 157)
      Me._preprocessingComboBox.Name = "_preprocessingComboBox"
      Me._preprocessingComboBox.Size = New System.Drawing.Size(285, 80)
      Me._preprocessingComboBox.TabIndex = 1
      Me._preprocessingComboBox.TabStop = False
      Me._preprocessingComboBox.Text = "&Preprocessing"
      Me._generalGroupBox.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
      Me._generalGroupBox.Controls.Add(Me._svgImagesRecognitionModeHelpLabel)
      Me._generalGroupBox.Controls.Add(Me._emptyPageModeModeLabel)
      Me._generalGroupBox.Controls.Add(Me._emptyPageModeComboBox)
      Me._generalGroupBox.Controls.Add(Me._useThreadsCheckBox)
      Me._generalGroupBox.Controls.Add(Me._svgImagesRecognitionModeLabel)
      Me._generalGroupBox.Controls.Add(Me._svgImagesRecognitionModeComboBox)
      Me._generalGroupBox.Controls.Add(Me._jobNameTextBox)
      Me._generalGroupBox.Controls.Add(Me._jobNameLabel)
      Me._generalGroupBox.Controls.Add(Me._enableSvgConversionCheckBox)
      Me._generalGroupBox.Controls.Add(Me._openOutputDocumentCheckBox)
      Me._generalGroupBox.Controls.Add(Me._enableTraceCheckBox)
      Me._generalGroupBox.Controls.Add(Me._continueOnRecoverableErrorsCheckBox)
      Me._generalGroupBox.Location = New System.Drawing.Point(14, 3)
      Me._generalGroupBox.Name = "_generalGroupBox"
      Me._generalGroupBox.Size = New System.Drawing.Size(618, 148)
      Me._generalGroupBox.TabIndex = 0
      Me._generalGroupBox.TabStop = False
      Me._generalGroupBox.Text = "&General"
      Me._svgImagesRecognitionModeHelpLabel.Location = New System.Drawing.Point(311, 42)
      Me._svgImagesRecognitionModeHelpLabel.Name = "_svgImagesRecognitionModeHelpLabel"
      Me._svgImagesRecognitionModeHelpLabel.Size = New System.Drawing.Size(291, 32)
      Me._svgImagesRecognitionModeHelpLabel.TabIndex = 11
      Me._svgImagesRecognitionModeHelpLabel.Text = "Help"
      Me._emptyPageModeModeLabel.AutoSize = True
      Me._emptyPageModeModeLabel.Location = New System.Drawing.Point(311, 88)
      Me._emptyPageModeModeLabel.Name = "_emptyPageModeModeLabel"
      Me._emptyPageModeModeLabel.Size = New System.Drawing.Size(95, 13)
      Me._emptyPageModeModeLabel.TabIndex = 7
      Me._emptyPageModeModeLabel.Text = "Empty page mode:"
      Me._emptyPageModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._emptyPageModeComboBox.FormattingEnabled = True
      Me._emptyPageModeComboBox.Location = New System.Drawing.Point(481, 85)
      Me._emptyPageModeComboBox.Name = "_emptyPageModeComboBox"
      Me._emptyPageModeComboBox.Size = New System.Drawing.Size(121, 21)
      Me._emptyPageModeComboBox.TabIndex = 8
      Me._useThreadsCheckBox.AutoSize = True
      Me._useThreadsCheckBox.Location = New System.Drawing.Point(114, 42)
      Me._useThreadsCheckBox.Name = "_useThreadsCheckBox"
      Me._useThreadsCheckBox.Size = New System.Drawing.Size(83, 17)
      Me._useThreadsCheckBox.TabIndex = 1
      Me._useThreadsCheckBox.Text = "Use &threads"
      Me._useThreadsCheckBox.UseVisualStyleBackColor = True
      Me._svgImagesRecognitionModeLabel.AutoSize = True
      Me._svgImagesRecognitionModeLabel.Location = New System.Drawing.Point(311, 19)
      Me._svgImagesRecognitionModeLabel.Name = "_svgImagesRecognitionModeLabel"
      Me._svgImagesRecognitionModeLabel.Size = New System.Drawing.Size(149, 13)
      Me._svgImagesRecognitionModeLabel.TabIndex = 5
      Me._svgImagesRecognitionModeLabel.Text = "SVG images OCR recognition:"
      Me._svgImagesRecognitionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._svgImagesRecognitionModeComboBox.FormattingEnabled = True
      Me._svgImagesRecognitionModeComboBox.Location = New System.Drawing.Point(482, 17)
      Me._svgImagesRecognitionModeComboBox.Name = "_svgImagesRecognitionModeComboBox"
      Me._svgImagesRecognitionModeComboBox.Size = New System.Drawing.Size(121, 21)
      Me._svgImagesRecognitionModeComboBox.TabIndex = 6
      AddHandler Me._svgImagesRecognitionModeComboBox.SelectedIndexChanged, New System.EventHandler(AddressOf Me._svgImagesRecognitionModeComboBox_SelectedIndexChanged)
      Me._jobNameTextBox.Location = New System.Drawing.Point(503, 111)
      Me._jobNameTextBox.Name = "_jobNameTextBox"
      Me._jobNameTextBox.Size = New System.Drawing.Size(100, 20)
      Me._jobNameTextBox.TabIndex = 10
      Me._jobNameLabel.AutoSize = True
      Me._jobNameLabel.Location = New System.Drawing.Point(438, 114)
      Me._jobNameLabel.Name = "_jobNameLabel"
      Me._jobNameLabel.Size = New System.Drawing.Size(56, 13)
      Me._jobNameLabel.TabIndex = 9
      Me._jobNameLabel.Text = "Job name:"
      Me._enableSvgConversionCheckBox.AutoSize = True
      Me._enableSvgConversionCheckBox.Location = New System.Drawing.Point(114, 19)
      Me._enableSvgConversionCheckBox.Name = "_enableSvgConversionCheckBox"
      Me._enableSvgConversionCheckBox.Size = New System.Drawing.Size(178, 17)
      Me._enableSvgConversionCheckBox.TabIndex = 0
      Me._enableSvgConversionCheckBox.Text = "&Use SVG conversion if available"
      Me._enableSvgConversionCheckBox.UseVisualStyleBackColor = True
      Me._openOutputDocumentCheckBox.AutoSize = True
      Me._openOutputDocumentCheckBox.Location = New System.Drawing.Point(114, 111)
      Me._openOutputDocumentCheckBox.Name = "_openOutputDocumentCheckBox"
      Me._openOutputDocumentCheckBox.Size = New System.Drawing.Size(292, 17)
      Me._openOutputDocumentCheckBox.TabIndex = 4
      Me._openOutputDocumentCheckBox.Text = "Open output document in default application on &success"
      Me._openOutputDocumentCheckBox.UseVisualStyleBackColor = True
      Me._enableTraceCheckBox.AutoSize = True
      Me._enableTraceCheckBox.Location = New System.Drawing.Point(114, 88)
      Me._enableTraceCheckBox.Name = "_enableTraceCheckBox"
      Me._enableTraceCheckBox.Size = New System.Drawing.Size(86, 17)
      Me._enableTraceCheckBox.TabIndex = 3
      Me._enableTraceCheckBox.Text = "E&nable trace"
      Me._enableTraceCheckBox.UseVisualStyleBackColor = True
      Me._continueOnRecoverableErrorsCheckBox.AutoSize = True
      Me._continueOnRecoverableErrorsCheckBox.Location = New System.Drawing.Point(114, 65)
      Me._continueOnRecoverableErrorsCheckBox.Name = "_continueOnRecoverableErrorsCheckBox"
      Me._continueOnRecoverableErrorsCheckBox.Size = New System.Drawing.Size(171, 17)
      Me._continueOnRecoverableErrorsCheckBox.TabIndex = 2
      Me._continueOnRecoverableErrorsCheckBox.Text = "&Continue on recoverable errors"
      Me._continueOnRecoverableErrorsCheckBox.UseVisualStyleBackColor = True
      Me._defaultButton.Location = New System.Drawing.Point(14, 246)
      Me._defaultButton.Name = "_defaultButton"
      Me._defaultButton.Size = New System.Drawing.Size(165, 23)
      Me._defaultButton.TabIndex = 2
      Me._defaultButton.Text = "Revert &back to defaults"
      Me._defaultButton.UseVisualStyleBackColor = True
      AddHandler Me._defaultButton.Click, New System.EventHandler(AddressOf Me._defaultButton_Click)
      Me._redactionOptionsGroupBox.Controls.Add(Me._redactionOptionsControl)
      Me._redactionOptionsGroupBox.Location = New System.Drawing.Point(306, 157)
      Me._redactionOptionsGroupBox.Name = "_redactionOptionsGroupBox"
      Me._redactionOptionsGroupBox.Size = New System.Drawing.Size(326, 80)
      Me._redactionOptionsGroupBox.TabIndex = 3
      Me._redactionOptionsGroupBox.TabStop = False
      Me._redactionOptionsGroupBox.Text = "Redaction Options"
      Me._redactionOptionsControl.Location = New System.Drawing.Point(7, 13)
      Me._redactionOptionsControl.Name = "_redactionOptionsControl"
      Me._redactionOptionsControl.Size = New System.Drawing.Size(282, 63)
      Me._redactionOptionsControl.TabIndex = 0
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._redactionOptionsGroupBox)
      Me.Controls.Add(Me._defaultButton)
      Me.Controls.Add(Me._generalGroupBox)
      Me.Controls.Add(Me._preprocessingComboBox)
      Me.Name = "DocumentConverterOptionsControl"
      Me.Size = New System.Drawing.Size(640, 277)
      Me._preprocessingComboBox.ResumeLayout(False)
      Me._preprocessingComboBox.PerformLayout()
      Me._generalGroupBox.ResumeLayout(False)
      Me._generalGroupBox.PerformLayout()
      Me._redactionOptionsGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub

   Private _deskewCheckBox As System.Windows.Forms.CheckBox
   Private _orientCheckBox As System.Windows.Forms.CheckBox
   Private _invertCheckBox As System.Windows.Forms.CheckBox
   Private _preprocessingComboBox As System.Windows.Forms.GroupBox
   Private _generalGroupBox As System.Windows.Forms.GroupBox
   Private _continueOnRecoverableErrorsCheckBox As System.Windows.Forms.CheckBox
   Private _enableTraceCheckBox As System.Windows.Forms.CheckBox
   Private _openOutputDocumentCheckBox As System.Windows.Forms.CheckBox
   Private _defaultButton As System.Windows.Forms.Button
   Private _enableSvgConversionCheckBox As System.Windows.Forms.CheckBox
   Private _jobNameTextBox As System.Windows.Forms.TextBox
   Private _jobNameLabel As System.Windows.Forms.Label
   Private _svgImagesRecognitionModeComboBox As System.Windows.Forms.ComboBox
   Private _svgImagesRecognitionModeLabel As System.Windows.Forms.Label
   Private _useThreadsCheckBox As System.Windows.Forms.CheckBox
   Private _emptyPageModeModeLabel As System.Windows.Forms.Label
   Private _emptyPageModeComboBox As System.Windows.Forms.ComboBox
   Private _svgImagesRecognitionModeHelpLabel As System.Windows.Forms.Label
   Private _redactionOptionsGroupBox As System.Windows.Forms.GroupBox
   Private _redactionOptionsControl As DocumentRedactionOptionsControl
End Class
