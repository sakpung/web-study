
Partial Class AdvancedPdfDocumentOptionsDialog
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
      Me._compressionsOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._qualityFactorNumericUpDown = New System.Windows.Forms.NumericUpDown()
      Me._qualityFactorLabel = New System.Windows.Forms.Label()
      Me._coloredImageCompressionComboBox = New System.Windows.Forms.ComboBox()
      Me._oneBitImageCompressionComboBox = New System.Windows.Forms.ComboBox()
      Me._coloredImageCompressionLabel = New System.Windows.Forms.Label()
      Me._oneBitImageCompressionLabel = New System.Windows.Forms.Label()
      Me._tabControl = New System.Windows.Forms.TabControl()
      Me._descriptionTab = New System.Windows.Forms.TabPage()
      Me._propertiesGroupBox = New System.Windows.Forms.GroupBox()
      Me._keywordsLabelNote = New System.Windows.Forms.Label()
      Me._keywordsLabel = New System.Windows.Forms.Label()
      Me._authorLabel = New System.Windows.Forms.Label()
      Me._subjectLabel = New System.Windows.Forms.Label()
      Me._titleLabel = New System.Windows.Forms.Label()
      Me._keywordsTextBox = New System.Windows.Forms.TextBox()
      Me._authorTextBox = New System.Windows.Forms.TextBox()
      Me._subjectTextBox = New System.Windows.Forms.TextBox()
      Me._titleTextBox = New System.Windows.Forms.TextBox()
      Me._fontsTab = New System.Windows.Forms.TabPage()
      Me._generalGroupBox = New System.Windows.Forms.GroupBox()
      Me._linearizedCheckBox = New System.Windows.Forms.CheckBox()
      Me._fontEmbeddingLabel = New System.Windows.Forms.Label()
      Me._fontEmbeddingComboBox = New System.Windows.Forms.ComboBox()
      Me._securityTab = New System.Windows.Forms.TabPage()
      Me._securityGroupBox = New System.Windows.Forms.GroupBox()
      Me._encryptionModeComboBox = New System.Windows.Forms.ComboBox()
      Me._encryptionModeLabel = New System.Windows.Forms.Label()
      Me._permissionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._highQualityPrintEnabledCheckBox = New System.Windows.Forms.CheckBox()
      Me._printEnabledCheckBox = New System.Windows.Forms.CheckBox()
      Me._assemblyEnabledCheckBox = New System.Windows.Forms.CheckBox()
      Me._annotationsEnabledCheckBox = New System.Windows.Forms.CheckBox()
      Me._editEnabledCheckBox = New System.Windows.Forms.CheckBox()
      Me._copyEnabledCheckBox = New System.Windows.Forms.CheckBox()
      Me._ownerPasswordLabel = New System.Windows.Forms.Label()
      Me._userPasswordLabel = New System.Windows.Forms.Label()
      Me._ownerPasswordTextBox = New System.Windows.Forms.TextBox()
      Me._userPasswordTextBox = New System.Windows.Forms.TextBox()
      Me._protectedCheckBox = New System.Windows.Forms.CheckBox()
      Me._compressionTab = New System.Windows.Forms.TabPage()
      Me._imageOverTextCompressionOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._imageOverTextModeComboBox = New System.Windows.Forms.ComboBox()
      Me._imageOverTextModeLabel = New System.Windows.Forms.Label()
      Me._imageOverTextSizeComboBox = New System.Windows.Forms.ComboBox()
      Me._imageOverTextSizeLabel = New System.Windows.Forms.Label()
      Me._initialViewTab = New System.Windows.Forms.TabPage()
      Me._userInterfaceOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._hideWindowControlsCheckBox = New System.Windows.Forms.CheckBox()
      Me._hideToolBarCheckBox = New System.Windows.Forms.CheckBox()
      Me._hideMenuBarCheckBox = New System.Windows.Forms.CheckBox()
      Me._windowsOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._showDocumentTitleComboBox = New System.Windows.Forms.ComboBox()
      Me._showDocumentTitleLabel = New System.Windows.Forms.Label()
      Me._centerWindowCheckBox = New System.Windows.Forms.CheckBox()
      Me._resizeWindowCheckBox = New System.Windows.Forms.CheckBox()
      Me._layoutPageModeGroupBox = New System.Windows.Forms.GroupBox()
      Me._initialPageNumberNumericUpDown = New System.Windows.Forms.NumericUpDown()
      Me._numberOfPagesLabel = New System.Windows.Forms.Label()
      Me._openToPageLabel = New System.Windows.Forms.Label()
      Me._pageFitTypeComboBox = New System.Windows.Forms.ComboBox()
      Me._pageFitTypeLabel = New System.Windows.Forms.Label()
      Me._pageLayoutComboBox = New System.Windows.Forms.ComboBox()
      Me._pageLayoutLabel = New System.Windows.Forms.Label()
      Me._pageModeComboBox = New System.Windows.Forms.ComboBox()
      Me._pageModeLabel = New System.Windows.Forms.Label()
      Me._producerLabel = New System.Windows.Forms.Label()
      Me._producerTextBox = New System.Windows.Forms.TextBox()
      Me._creatorLabel = New System.Windows.Forms.Label()
      Me._creatorTextBox = New System.Windows.Forms.TextBox()
      Me._compressionsOptionsGroupBox.SuspendLayout()
      CType(Me._qualityFactorNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._tabControl.SuspendLayout()
      Me._descriptionTab.SuspendLayout()
      Me._propertiesGroupBox.SuspendLayout()
      Me._fontsTab.SuspendLayout()
      Me._generalGroupBox.SuspendLayout()
      Me._securityTab.SuspendLayout()
      Me._securityGroupBox.SuspendLayout()
      Me._permissionsGroupBox.SuspendLayout()
      Me._compressionTab.SuspendLayout()
      Me._imageOverTextCompressionOptionsGroupBox.SuspendLayout()
      Me._initialViewTab.SuspendLayout()
      Me._userInterfaceOptionsGroupBox.SuspendLayout()
      Me._windowsOptionsGroupBox.SuspendLayout()
      Me._layoutPageModeGroupBox.SuspendLayout()
      CType(Me._initialPageNumberNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(318, 442)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 3
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(399, 442)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 4
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_compressionsOptionsGroupBox
      '
      Me._compressionsOptionsGroupBox.Controls.Add(Me._qualityFactorNumericUpDown)
      Me._compressionsOptionsGroupBox.Controls.Add(Me._qualityFactorLabel)
      Me._compressionsOptionsGroupBox.Controls.Add(Me._coloredImageCompressionComboBox)
      Me._compressionsOptionsGroupBox.Controls.Add(Me._oneBitImageCompressionComboBox)
      Me._compressionsOptionsGroupBox.Controls.Add(Me._coloredImageCompressionLabel)
      Me._compressionsOptionsGroupBox.Controls.Add(Me._oneBitImageCompressionLabel)
      Me._compressionsOptionsGroupBox.Location = New System.Drawing.Point(6, 6)
      Me._compressionsOptionsGroupBox.Name = "_compressionsOptionsGroupBox"
      Me._compressionsOptionsGroupBox.Size = New System.Drawing.Size(445, 111)
      Me._compressionsOptionsGroupBox.TabIndex = 0
      Me._compressionsOptionsGroupBox.TabStop = False
      Me._compressionsOptionsGroupBox.Text = "Compression Options:"
      '
      '_qualityFactorNumericUpDown
      '
      Me._qualityFactorNumericUpDown.Location = New System.Drawing.Point(167, 77)
      Me._qualityFactorNumericUpDown.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._qualityFactorNumericUpDown.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
      Me._qualityFactorNumericUpDown.Name = "_qualityFactorNumericUpDown"
      Me._qualityFactorNumericUpDown.Size = New System.Drawing.Size(151, 20)
      Me._qualityFactorNumericUpDown.TabIndex = 5
      Me._qualityFactorNumericUpDown.Value = New Decimal(New Integer() {2, 0, 0, 0})
      '
      '_qualityFactorLabel
      '
      Me._qualityFactorLabel.AutoSize = True
      Me._qualityFactorLabel.Location = New System.Drawing.Point(17, 79)
      Me._qualityFactorLabel.Name = "_qualityFactorLabel"
      Me._qualityFactorLabel.Size = New System.Drawing.Size(75, 13)
      Me._qualityFactorLabel.TabIndex = 4
      Me._qualityFactorLabel.Text = "Quality Factor:"
      '
      '_coloredImageCompressionComboBox
      '
      Me._coloredImageCompressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._coloredImageCompressionComboBox.FormattingEnabled = True
      Me._coloredImageCompressionComboBox.Location = New System.Drawing.Point(167, 50)
      Me._coloredImageCompressionComboBox.Name = "_coloredImageCompressionComboBox"
      Me._coloredImageCompressionComboBox.Size = New System.Drawing.Size(151, 21)
      Me._coloredImageCompressionComboBox.TabIndex = 3
      '
      '_oneBitImageCompressionComboBox
      '
      Me._oneBitImageCompressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._oneBitImageCompressionComboBox.FormattingEnabled = True
      Me._oneBitImageCompressionComboBox.Location = New System.Drawing.Point(167, 23)
      Me._oneBitImageCompressionComboBox.Name = "_oneBitImageCompressionComboBox"
      Me._oneBitImageCompressionComboBox.Size = New System.Drawing.Size(151, 21)
      Me._oneBitImageCompressionComboBox.TabIndex = 1
      '
      '_coloredImageCompressionLabel
      '
      Me._coloredImageCompressionLabel.AutoSize = True
      Me._coloredImageCompressionLabel.Location = New System.Drawing.Point(17, 53)
      Me._coloredImageCompressionLabel.Name = "_coloredImageCompressionLabel"
      Me._coloredImageCompressionLabel.Size = New System.Drawing.Size(141, 13)
      Me._coloredImageCompressionLabel.TabIndex = 2
      Me._coloredImageCompressionLabel.Text = "Colored Image Compression:"
      '
      '_oneBitImageCompressionLabel
      '
      Me._oneBitImageCompressionLabel.AutoSize = True
      Me._oneBitImageCompressionLabel.Location = New System.Drawing.Point(17, 26)
      Me._oneBitImageCompressionLabel.Name = "_oneBitImageCompressionLabel"
      Me._oneBitImageCompressionLabel.Size = New System.Drawing.Size(140, 13)
      Me._oneBitImageCompressionLabel.TabIndex = 0
      Me._oneBitImageCompressionLabel.Text = "One-Bit Image Compression:"
      '
      '_tabControl
      '
      Me._tabControl.Controls.Add(Me._descriptionTab)
      Me._tabControl.Controls.Add(Me._fontsTab)
      Me._tabControl.Controls.Add(Me._securityTab)
      Me._tabControl.Controls.Add(Me._compressionTab)
      Me._tabControl.Controls.Add(Me._initialViewTab)
      Me._tabControl.Location = New System.Drawing.Point(12, 12)
      Me._tabControl.Name = "_tabControl"
      Me._tabControl.SelectedIndex = 0
      Me._tabControl.Size = New System.Drawing.Size(465, 424)
      Me._tabControl.TabIndex = 0
      '
      '_descriptionTab
      '
      Me._descriptionTab.Controls.Add(Me._propertiesGroupBox)
      Me._descriptionTab.Location = New System.Drawing.Point(4, 22)
      Me._descriptionTab.Name = "_descriptionTab"
      Me._descriptionTab.Padding = New System.Windows.Forms.Padding(3)
      Me._descriptionTab.Size = New System.Drawing.Size(457, 398)
      Me._descriptionTab.TabIndex = 0
      Me._descriptionTab.Text = "Description"
      Me._descriptionTab.UseVisualStyleBackColor = True
      '
      '_propertiesGroupBox
      '
      Me._propertiesGroupBox.Controls.Add(Me._producerLabel)
      Me._propertiesGroupBox.Controls.Add(Me._producerTextBox)
      Me._propertiesGroupBox.Controls.Add(Me._creatorLabel)
      Me._propertiesGroupBox.Controls.Add(Me._creatorTextBox)
      Me._propertiesGroupBox.Controls.Add(Me._keywordsLabelNote)
      Me._propertiesGroupBox.Controls.Add(Me._keywordsLabel)
      Me._propertiesGroupBox.Controls.Add(Me._authorLabel)
      Me._propertiesGroupBox.Controls.Add(Me._subjectLabel)
      Me._propertiesGroupBox.Controls.Add(Me._titleLabel)
      Me._propertiesGroupBox.Controls.Add(Me._keywordsTextBox)
      Me._propertiesGroupBox.Controls.Add(Me._authorTextBox)
      Me._propertiesGroupBox.Controls.Add(Me._subjectTextBox)
      Me._propertiesGroupBox.Controls.Add(Me._titleTextBox)
      Me._propertiesGroupBox.Location = New System.Drawing.Point(6, 6)
      Me._propertiesGroupBox.Name = "_propertiesGroupBox"
      Me._propertiesGroupBox.Size = New System.Drawing.Size(445, 215)
      Me._propertiesGroupBox.TabIndex = 0
      Me._propertiesGroupBox.TabStop = False
      Me._propertiesGroupBox.Text = "Description:"
      '
      '_keywordsLabelNote
      '
      Me._keywordsLabelNote.Location = New System.Drawing.Point(19, 182)
      Me._keywordsLabelNote.Name = "_keywordsLabelNote"
      Me._keywordsLabelNote.Size = New System.Drawing.Size(275, 21)
      Me._keywordsLabelNote.TabIndex = 8
      Me._keywordsLabelNote.Text = "Note: Keywords can be separted with a comma or a dot."
      '
      '_keywordsLabel
      '
      Me._keywordsLabel.AutoSize = True
      Me._keywordsLabel.Location = New System.Drawing.Point(19, 152)
      Me._keywordsLabel.Name = "_keywordsLabel"
      Me._keywordsLabel.Size = New System.Drawing.Size(53, 13)
      Me._keywordsLabel.TabIndex = 6
      Me._keywordsLabel.Text = "Keywords"
      '
      '_authorLabel
      '
      Me._authorLabel.AutoSize = True
      Me._authorLabel.Location = New System.Drawing.Point(19, 75)
      Me._authorLabel.Name = "_authorLabel"
      Me._authorLabel.Size = New System.Drawing.Size(38, 13)
      Me._authorLabel.TabIndex = 4
      Me._authorLabel.Text = "Author"
      '
      '_subjectLabel
      '
      Me._subjectLabel.AutoSize = True
      Me._subjectLabel.Location = New System.Drawing.Point(19, 48)
      Me._subjectLabel.Name = "_subjectLabel"
      Me._subjectLabel.Size = New System.Drawing.Size(43, 13)
      Me._subjectLabel.TabIndex = 2
      Me._subjectLabel.Text = "Subject"
      '
      '_titleLabel
      '
      Me._titleLabel.AutoSize = True
      Me._titleLabel.Location = New System.Drawing.Point(19, 22)
      Me._titleLabel.Name = "_titleLabel"
      Me._titleLabel.Size = New System.Drawing.Size(27, 13)
      Me._titleLabel.TabIndex = 0
      Me._titleLabel.Text = "Title"
      '
      '_keywordsTextBox
      '
      Me._keywordsTextBox.Location = New System.Drawing.Point(97, 149)
      Me._keywordsTextBox.Name = "_keywordsTextBox"
      Me._keywordsTextBox.Size = New System.Drawing.Size(342, 20)
      Me._keywordsTextBox.TabIndex = 7
      '
      '_authorTextBox
      '
      Me._authorTextBox.Location = New System.Drawing.Point(97, 71)
      Me._authorTextBox.Name = "_authorTextBox"
      Me._authorTextBox.Size = New System.Drawing.Size(342, 20)
      Me._authorTextBox.TabIndex = 5
      '
      '_subjectTextBox
      '
      Me._subjectTextBox.Location = New System.Drawing.Point(97, 45)
      Me._subjectTextBox.Name = "_subjectTextBox"
      Me._subjectTextBox.Size = New System.Drawing.Size(342, 20)
      Me._subjectTextBox.TabIndex = 3
      '
      '_titleTextBox
      '
      Me._titleTextBox.Location = New System.Drawing.Point(97, 19)
      Me._titleTextBox.Name = "_titleTextBox"
      Me._titleTextBox.Size = New System.Drawing.Size(342, 20)
      Me._titleTextBox.TabIndex = 1
      '
      '_fontsTab
      '
      Me._fontsTab.Controls.Add(Me._generalGroupBox)
      Me._fontsTab.Location = New System.Drawing.Point(4, 22)
      Me._fontsTab.Name = "_fontsTab"
      Me._fontsTab.Padding = New System.Windows.Forms.Padding(3)
      Me._fontsTab.Size = New System.Drawing.Size(457, 398)
      Me._fontsTab.TabIndex = 1
      Me._fontsTab.Text = "Fonts"
      Me._fontsTab.UseVisualStyleBackColor = True
      '
      '_generalGroupBox
      '
      Me._generalGroupBox.Controls.Add(Me._linearizedCheckBox)
      Me._generalGroupBox.Controls.Add(Me._fontEmbeddingLabel)
      Me._generalGroupBox.Controls.Add(Me._fontEmbeddingComboBox)
      Me._generalGroupBox.Location = New System.Drawing.Point(6, 6)
      Me._generalGroupBox.Name = "_generalGroupBox"
      Me._generalGroupBox.Size = New System.Drawing.Size(445, 95)
      Me._generalGroupBox.TabIndex = 0
      Me._generalGroupBox.TabStop = False
      Me._generalGroupBox.Text = "Fonts:"
      '
      '_linearizedCheckBox
      '
      Me._linearizedCheckBox.AutoSize = True
      Me._linearizedCheckBox.Location = New System.Drawing.Point(27, 64)
      Me._linearizedCheckBox.Name = "_linearizedCheckBox"
      Me._linearizedCheckBox.Size = New System.Drawing.Size(154, 17)
      Me._linearizedCheckBox.TabIndex = 2
      Me._linearizedCheckBox.Text = " Fast web view (Linearized)"
      Me._linearizedCheckBox.UseVisualStyleBackColor = True
      '
      '_fontEmbeddingLabel
      '
      Me._fontEmbeddingLabel.AutoSize = True
      Me._fontEmbeddingLabel.Location = New System.Drawing.Point(24, 31)
      Me._fontEmbeddingLabel.Name = "_fontEmbeddingLabel"
      Me._fontEmbeddingLabel.Size = New System.Drawing.Size(86, 13)
      Me._fontEmbeddingLabel.TabIndex = 0
      Me._fontEmbeddingLabel.Text = "Font embedding:"
      '
      '_fontEmbeddingComboBox
      '
      Me._fontEmbeddingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._fontEmbeddingComboBox.FormattingEnabled = True
      Me._fontEmbeddingComboBox.Location = New System.Drawing.Point(132, 28)
      Me._fontEmbeddingComboBox.Name = "_fontEmbeddingComboBox"
      Me._fontEmbeddingComboBox.Size = New System.Drawing.Size(157, 21)
      Me._fontEmbeddingComboBox.TabIndex = 1
      '
      '_securityTab
      '
      Me._securityTab.Controls.Add(Me._securityGroupBox)
      Me._securityTab.Location = New System.Drawing.Point(4, 22)
      Me._securityTab.Name = "_securityTab"
      Me._securityTab.Padding = New System.Windows.Forms.Padding(3)
      Me._securityTab.Size = New System.Drawing.Size(457, 398)
      Me._securityTab.TabIndex = 2
      Me._securityTab.Text = "Security"
      Me._securityTab.UseVisualStyleBackColor = True
      '
      '_securityGroupBox
      '
      Me._securityGroupBox.Controls.Add(Me._encryptionModeComboBox)
      Me._securityGroupBox.Controls.Add(Me._encryptionModeLabel)
      Me._securityGroupBox.Controls.Add(Me._permissionsGroupBox)
      Me._securityGroupBox.Controls.Add(Me._ownerPasswordLabel)
      Me._securityGroupBox.Controls.Add(Me._userPasswordLabel)
      Me._securityGroupBox.Controls.Add(Me._ownerPasswordTextBox)
      Me._securityGroupBox.Controls.Add(Me._userPasswordTextBox)
      Me._securityGroupBox.Controls.Add(Me._protectedCheckBox)
      Me._securityGroupBox.Location = New System.Drawing.Point(6, 6)
      Me._securityGroupBox.Name = "_securityGroupBox"
      Me._securityGroupBox.Size = New System.Drawing.Size(445, 305)
      Me._securityGroupBox.TabIndex = 0
      Me._securityGroupBox.TabStop = False
      Me._securityGroupBox.Text = "Document Security:"
      '
      '_encryptionModeComboBox
      '
      Me._encryptionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._encryptionModeComboBox.FormattingEnabled = True
      Me._encryptionModeComboBox.Location = New System.Drawing.Point(138, 53)
      Me._encryptionModeComboBox.Name = "_encryptionModeComboBox"
      Me._encryptionModeComboBox.Size = New System.Drawing.Size(174, 21)
      Me._encryptionModeComboBox.TabIndex = 2
      '
      '_encryptionModeLabel
      '
      Me._encryptionModeLabel.AutoSize = True
      Me._encryptionModeLabel.Location = New System.Drawing.Point(34, 56)
      Me._encryptionModeLabel.Name = "_encryptionModeLabel"
      Me._encryptionModeLabel.Size = New System.Drawing.Size(89, 13)
      Me._encryptionModeLabel.TabIndex = 1
      Me._encryptionModeLabel.Text = "Encryption mode:"
      '
      '_permissionsGroupBox
      '
      Me._permissionsGroupBox.Controls.Add(Me._highQualityPrintEnabledCheckBox)
      Me._permissionsGroupBox.Controls.Add(Me._printEnabledCheckBox)
      Me._permissionsGroupBox.Controls.Add(Me._assemblyEnabledCheckBox)
      Me._permissionsGroupBox.Controls.Add(Me._annotationsEnabledCheckBox)
      Me._permissionsGroupBox.Controls.Add(Me._editEnabledCheckBox)
      Me._permissionsGroupBox.Controls.Add(Me._copyEnabledCheckBox)
      Me._permissionsGroupBox.Location = New System.Drawing.Point(37, 132)
      Me._permissionsGroupBox.Name = "_permissionsGroupBox"
      Me._permissionsGroupBox.Size = New System.Drawing.Size(402, 161)
      Me._permissionsGroupBox.TabIndex = 7
      Me._permissionsGroupBox.TabStop = False
      Me._permissionsGroupBox.Text = "Permissions:"
      '
      '_highQualityPrintEnabledCheckBox
      '
      Me._highQualityPrintEnabledCheckBox.AutoSize = True
      Me._highQualityPrintEnabledCheckBox.Location = New System.Drawing.Point(10, 129)
      Me._highQualityPrintEnabledCheckBox.Name = "_highQualityPrintEnabledCheckBox"
      Me._highQualityPrintEnabledCheckBox.Size = New System.Drawing.Size(192, 17)
      Me._highQualityPrintEnabledCheckBox.TabIndex = 5
      Me._highQualityPrintEnabledCheckBox.Text = "Enable high quality (faithful) printing"
      Me._highQualityPrintEnabledCheckBox.UseVisualStyleBackColor = True
      '
      '_printEnabledCheckBox
      '
      Me._printEnabledCheckBox.AutoSize = True
      Me._printEnabledCheckBox.Location = New System.Drawing.Point(10, 85)
      Me._printEnabledCheckBox.Name = "_printEnabledCheckBox"
      Me._printEnabledCheckBox.Size = New System.Drawing.Size(96, 17)
      Me._printEnabledCheckBox.TabIndex = 3
      Me._printEnabledCheckBox.Text = "Enable printing"
      Me._printEnabledCheckBox.UseVisualStyleBackColor = True
      '
      '_assemblyEnabledCheckBox
      '
      Me._assemblyEnabledCheckBox.AutoSize = True
      Me._assemblyEnabledCheckBox.Location = New System.Drawing.Point(10, 107)
      Me._assemblyEnabledCheckBox.Name = "_assemblyEnabledCheckBox"
      Me._assemblyEnabledCheckBox.Size = New System.Drawing.Size(155, 17)
      Me._assemblyEnabledCheckBox.TabIndex = 4
      Me._assemblyEnabledCheckBox.Text = "Enable document assembly"
      Me._assemblyEnabledCheckBox.UseVisualStyleBackColor = True
      '
      '_annotationsEnabledCheckBox
      '
      Me._annotationsEnabledCheckBox.AutoSize = True
      Me._annotationsEnabledCheckBox.Location = New System.Drawing.Point(10, 63)
      Me._annotationsEnabledCheckBox.Name = "_annotationsEnabledCheckBox"
      Me._annotationsEnabledCheckBox.Size = New System.Drawing.Size(184, 17)
      Me._annotationsEnabledCheckBox.TabIndex = 2
      Me._annotationsEnabledCheckBox.Text = "Enable comment and annotations"
      Me._annotationsEnabledCheckBox.UseVisualStyleBackColor = True
      '
      '_editEnabledCheckBox
      '
      Me._editEnabledCheckBox.AutoSize = True
      Me._editEnabledCheckBox.Location = New System.Drawing.Point(10, 41)
      Me._editEnabledCheckBox.Name = "_editEnabledCheckBox"
      Me._editEnabledCheckBox.Size = New System.Drawing.Size(143, 17)
      Me._editEnabledCheckBox.TabIndex = 1
      Me._editEnabledCheckBox.Text = "Enable document editing"
      Me._editEnabledCheckBox.UseVisualStyleBackColor = True
      '
      '_copyEnabledCheckBox
      '
      Me._copyEnabledCheckBox.AutoSize = True
      Me._copyEnabledCheckBox.Location = New System.Drawing.Point(10, 19)
      Me._copyEnabledCheckBox.Name = "_copyEnabledCheckBox"
      Me._copyEnabledCheckBox.Size = New System.Drawing.Size(248, 17)
      Me._copyEnabledCheckBox.TabIndex = 0
      Me._copyEnabledCheckBox.Text = "Enable copy from document and text extraction"
      Me._copyEnabledCheckBox.UseVisualStyleBackColor = True
      '
      '_ownerPasswordLabel
      '
      Me._ownerPasswordLabel.AutoSize = True
      Me._ownerPasswordLabel.Location = New System.Drawing.Point(34, 109)
      Me._ownerPasswordLabel.Name = "_ownerPasswordLabel"
      Me._ownerPasswordLabel.Size = New System.Drawing.Size(89, 13)
      Me._ownerPasswordLabel.TabIndex = 5
      Me._ownerPasswordLabel.Text = "Owner password:"
      '
      '_userPasswordLabel
      '
      Me._userPasswordLabel.AutoSize = True
      Me._userPasswordLabel.Location = New System.Drawing.Point(34, 83)
      Me._userPasswordLabel.Name = "_userPasswordLabel"
      Me._userPasswordLabel.Size = New System.Drawing.Size(80, 13)
      Me._userPasswordLabel.TabIndex = 3
      Me._userPasswordLabel.Text = "&User password:"
      '
      '_ownerPasswordTextBox
      '
      Me._ownerPasswordTextBox.Location = New System.Drawing.Point(138, 106)
      Me._ownerPasswordTextBox.MaxLength = 16
      Me._ownerPasswordTextBox.Name = "_ownerPasswordTextBox"
      Me._ownerPasswordTextBox.PasswordChar = "*"c
      Me._ownerPasswordTextBox.Size = New System.Drawing.Size(174, 20)
      Me._ownerPasswordTextBox.TabIndex = 6
      '
      '_userPasswordTextBox
      '
      Me._userPasswordTextBox.Location = New System.Drawing.Point(138, 80)
      Me._userPasswordTextBox.MaxLength = 16
      Me._userPasswordTextBox.Name = "_userPasswordTextBox"
      Me._userPasswordTextBox.PasswordChar = "*"c
      Me._userPasswordTextBox.Size = New System.Drawing.Size(174, 20)
      Me._userPasswordTextBox.TabIndex = 4
      '
      '_protectedCheckBox
      '
      Me._protectedCheckBox.AutoSize = True
      Me._protectedCheckBox.Location = New System.Drawing.Point(17, 27)
      Me._protectedCheckBox.Name = "_protectedCheckBox"
      Me._protectedCheckBox.Size = New System.Drawing.Size(122, 17)
      Me._protectedCheckBox.TabIndex = 0
      Me._protectedCheckBox.Text = "Protected document"
      Me._protectedCheckBox.UseVisualStyleBackColor = True
      '
      '_compressionTab
      '
      Me._compressionTab.Controls.Add(Me._imageOverTextCompressionOptionsGroupBox)
      Me._compressionTab.Controls.Add(Me._compressionsOptionsGroupBox)
      Me._compressionTab.Location = New System.Drawing.Point(4, 22)
      Me._compressionTab.Name = "_compressionTab"
      Me._compressionTab.Padding = New System.Windows.Forms.Padding(3)
      Me._compressionTab.Size = New System.Drawing.Size(457, 398)
      Me._compressionTab.TabIndex = 3
      Me._compressionTab.Text = "Compression"
      Me._compressionTab.UseVisualStyleBackColor = True
      '
      '_imageOverTextCompressionOptionsGroupBox
      '
      Me._imageOverTextCompressionOptionsGroupBox.Controls.Add(Me._imageOverTextModeComboBox)
      Me._imageOverTextCompressionOptionsGroupBox.Controls.Add(Me._imageOverTextModeLabel)
      Me._imageOverTextCompressionOptionsGroupBox.Controls.Add(Me._imageOverTextSizeComboBox)
      Me._imageOverTextCompressionOptionsGroupBox.Controls.Add(Me._imageOverTextSizeLabel)
      Me._imageOverTextCompressionOptionsGroupBox.Location = New System.Drawing.Point(6, 123)
      Me._imageOverTextCompressionOptionsGroupBox.Name = "_imageOverTextCompressionOptionsGroupBox"
      Me._imageOverTextCompressionOptionsGroupBox.Size = New System.Drawing.Size(445, 111)
      Me._imageOverTextCompressionOptionsGroupBox.TabIndex = 1
      Me._imageOverTextCompressionOptionsGroupBox.TabStop = False
      Me._imageOverTextCompressionOptionsGroupBox.Text = "Image Over Text Compression Options:"
      '
      '_imageOverTextModeComboBox
      '
      Me._imageOverTextModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._imageOverTextModeComboBox.FormattingEnabled = True
      Me._imageOverTextModeComboBox.Location = New System.Drawing.Point(167, 53)
      Me._imageOverTextModeComboBox.Name = "_imageOverTextModeComboBox"
      Me._imageOverTextModeComboBox.Size = New System.Drawing.Size(151, 21)
      Me._imageOverTextModeComboBox.TabIndex = 3
      '
      '_imageOverTextModeLabel
      '
      Me._imageOverTextModeLabel.AutoSize = True
      Me._imageOverTextModeLabel.Location = New System.Drawing.Point(17, 56)
      Me._imageOverTextModeLabel.Name = "_imageOverTextModeLabel"
      Me._imageOverTextModeLabel.Size = New System.Drawing.Size(112, 13)
      Me._imageOverTextModeLabel.TabIndex = 2
      Me._imageOverTextModeLabel.Text = "Image over text mode:"
      '
      '_imageOverTextSizeComboBox
      '
      Me._imageOverTextSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._imageOverTextSizeComboBox.FormattingEnabled = True
      Me._imageOverTextSizeComboBox.Location = New System.Drawing.Point(167, 26)
      Me._imageOverTextSizeComboBox.Name = "_imageOverTextSizeComboBox"
      Me._imageOverTextSizeComboBox.Size = New System.Drawing.Size(151, 21)
      Me._imageOverTextSizeComboBox.TabIndex = 1
      '
      '_imageOverTextSizeLabel
      '
      Me._imageOverTextSizeLabel.AutoSize = True
      Me._imageOverTextSizeLabel.Location = New System.Drawing.Point(17, 29)
      Me._imageOverTextSizeLabel.Name = "_imageOverTextSizeLabel"
      Me._imageOverTextSizeLabel.Size = New System.Drawing.Size(104, 13)
      Me._imageOverTextSizeLabel.TabIndex = 0
      Me._imageOverTextSizeLabel.Text = "Image over text size:"
      '
      '_initialViewTab
      '
      Me._initialViewTab.Controls.Add(Me._userInterfaceOptionsGroupBox)
      Me._initialViewTab.Controls.Add(Me._windowsOptionsGroupBox)
      Me._initialViewTab.Controls.Add(Me._layoutPageModeGroupBox)
      Me._initialViewTab.Location = New System.Drawing.Point(4, 22)
      Me._initialViewTab.Name = "_initialViewTab"
      Me._initialViewTab.Padding = New System.Windows.Forms.Padding(3)
      Me._initialViewTab.Size = New System.Drawing.Size(457, 398)
      Me._initialViewTab.TabIndex = 4
      Me._initialViewTab.Text = "Initial View"
      Me._initialViewTab.UseVisualStyleBackColor = True
      '
      '_userInterfaceOptionsGroupBox
      '
      Me._userInterfaceOptionsGroupBox.Controls.Add(Me._hideWindowControlsCheckBox)
      Me._userInterfaceOptionsGroupBox.Controls.Add(Me._hideToolBarCheckBox)
      Me._userInterfaceOptionsGroupBox.Controls.Add(Me._hideMenuBarCheckBox)
      Me._userInterfaceOptionsGroupBox.Location = New System.Drawing.Point(6, 283)
      Me._userInterfaceOptionsGroupBox.Name = "_userInterfaceOptionsGroupBox"
      Me._userInterfaceOptionsGroupBox.Size = New System.Drawing.Size(445, 95)
      Me._userInterfaceOptionsGroupBox.TabIndex = 2
      Me._userInterfaceOptionsGroupBox.TabStop = False
      Me._userInterfaceOptionsGroupBox.Text = "User Interface Options"
      '
      '_hideWindowControlsCheckBox
      '
      Me._hideWindowControlsCheckBox.AutoSize = True
      Me._hideWindowControlsCheckBox.Location = New System.Drawing.Point(23, 65)
      Me._hideWindowControlsCheckBox.Name = "_hideWindowControlsCheckBox"
      Me._hideWindowControlsCheckBox.Size = New System.Drawing.Size(127, 17)
      Me._hideWindowControlsCheckBox.TabIndex = 2
      Me._hideWindowControlsCheckBox.Text = "Hide window co&ntrols"
      Me._hideWindowControlsCheckBox.UseVisualStyleBackColor = True
      '
      '_hideToolBarCheckBox
      '
      Me._hideToolBarCheckBox.AutoSize = True
      Me._hideToolBarCheckBox.Location = New System.Drawing.Point(23, 42)
      Me._hideToolBarCheckBox.Name = "_hideToolBarCheckBox"
      Me._hideToolBarCheckBox.Size = New System.Drawing.Size(83, 17)
      Me._hideToolBarCheckBox.TabIndex = 1
      Me._hideToolBarCheckBox.Text = "Hide tool&bar"
      Me._hideToolBarCheckBox.UseVisualStyleBackColor = True
      '
      '_hideMenuBarCheckBox
      '
      Me._hideMenuBarCheckBox.AutoSize = True
      Me._hideMenuBarCheckBox.Location = New System.Drawing.Point(23, 19)
      Me._hideMenuBarCheckBox.Name = "_hideMenuBarCheckBox"
      Me._hideMenuBarCheckBox.Size = New System.Drawing.Size(95, 17)
      Me._hideMenuBarCheckBox.TabIndex = 0
      Me._hideMenuBarCheckBox.Text = "Hide men&u bar"
      Me._hideMenuBarCheckBox.UseVisualStyleBackColor = True
      '
      '_windowsOptionsGroupBox
      '
      Me._windowsOptionsGroupBox.Controls.Add(Me._showDocumentTitleComboBox)
      Me._windowsOptionsGroupBox.Controls.Add(Me._showDocumentTitleLabel)
      Me._windowsOptionsGroupBox.Controls.Add(Me._centerWindowCheckBox)
      Me._windowsOptionsGroupBox.Controls.Add(Me._resizeWindowCheckBox)
      Me._windowsOptionsGroupBox.Location = New System.Drawing.Point(6, 161)
      Me._windowsOptionsGroupBox.Name = "_windowsOptionsGroupBox"
      Me._windowsOptionsGroupBox.Size = New System.Drawing.Size(445, 116)
      Me._windowsOptionsGroupBox.TabIndex = 1
      Me._windowsOptionsGroupBox.TabStop = False
      Me._windowsOptionsGroupBox.Text = "Window Options"
      '
      '_showDocumentTitleComboBox
      '
      Me._showDocumentTitleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._showDocumentTitleComboBox.FormattingEnabled = True
      Me._showDocumentTitleComboBox.Location = New System.Drawing.Point(100, 79)
      Me._showDocumentTitleComboBox.Name = "_showDocumentTitleComboBox"
      Me._showDocumentTitleComboBox.Size = New System.Drawing.Size(162, 21)
      Me._showDocumentTitleComboBox.TabIndex = 3
      '
      '_showDocumentTitleLabel
      '
      Me._showDocumentTitleLabel.AutoSize = True
      Me._showDocumentTitleLabel.Location = New System.Drawing.Point(38, 82)
      Me._showDocumentTitleLabel.Name = "_showDocumentTitleLabel"
      Me._showDocumentTitleLabel.Size = New System.Drawing.Size(37, 13)
      Me._showDocumentTitleLabel.TabIndex = 2
      Me._showDocumentTitleLabel.Text = "Sho&w:"
      '
      '_centerWindowCheckBox
      '
      Me._centerWindowCheckBox.AutoSize = True
      Me._centerWindowCheckBox.Location = New System.Drawing.Point(23, 51)
      Me._centerWindowCheckBox.Name = "_centerWindowCheckBox"
      Me._centerWindowCheckBox.Size = New System.Drawing.Size(146, 17)
      Me._centerWindowCheckBox.TabIndex = 1
      Me._centerWindowCheckBox.Text = "&Center window on screen"
      Me._centerWindowCheckBox.UseVisualStyleBackColor = True
      '
      '_resizeWindowCheckBox
      '
      Me._resizeWindowCheckBox.AutoSize = True
      Me._resizeWindowCheckBox.Location = New System.Drawing.Point(23, 28)
      Me._resizeWindowCheckBox.Name = "_resizeWindowCheckBox"
      Me._resizeWindowCheckBox.Size = New System.Drawing.Size(162, 17)
      Me._resizeWindowCheckBox.TabIndex = 0
      Me._resizeWindowCheckBox.Text = "&Resize window to initial page"
      Me._resizeWindowCheckBox.UseVisualStyleBackColor = True
      '
      '_layoutPageModeGroupBox
      '
      Me._layoutPageModeGroupBox.Controls.Add(Me._initialPageNumberNumericUpDown)
      Me._layoutPageModeGroupBox.Controls.Add(Me._numberOfPagesLabel)
      Me._layoutPageModeGroupBox.Controls.Add(Me._openToPageLabel)
      Me._layoutPageModeGroupBox.Controls.Add(Me._pageFitTypeComboBox)
      Me._layoutPageModeGroupBox.Controls.Add(Me._pageFitTypeLabel)
      Me._layoutPageModeGroupBox.Controls.Add(Me._pageLayoutComboBox)
      Me._layoutPageModeGroupBox.Controls.Add(Me._pageLayoutLabel)
      Me._layoutPageModeGroupBox.Controls.Add(Me._pageModeComboBox)
      Me._layoutPageModeGroupBox.Controls.Add(Me._pageModeLabel)
      Me._layoutPageModeGroupBox.Location = New System.Drawing.Point(6, 6)
      Me._layoutPageModeGroupBox.Name = "_layoutPageModeGroupBox"
      Me._layoutPageModeGroupBox.Size = New System.Drawing.Size(445, 149)
      Me._layoutPageModeGroupBox.TabIndex = 0
      Me._layoutPageModeGroupBox.TabStop = False
      Me._layoutPageModeGroupBox.Text = "Layout and Page Mode"
      '
      '_initialPageNumberNumericUpDown
      '
      Me._initialPageNumberNumericUpDown.Location = New System.Drawing.Point(100, 117)
      Me._initialPageNumberNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
      Me._initialPageNumberNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._initialPageNumberNumericUpDown.Name = "_initialPageNumberNumericUpDown"
      Me._initialPageNumberNumericUpDown.Size = New System.Drawing.Size(76, 20)
      Me._initialPageNumberNumericUpDown.TabIndex = 7
      Me._initialPageNumberNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      '_numberOfPagesLabel
      '
      Me._numberOfPagesLabel.AutoSize = True
      Me._numberOfPagesLabel.Location = New System.Drawing.Point(182, 119)
      Me._numberOfPagesLabel.Name = "_numberOfPagesLabel"
      Me._numberOfPagesLabel.Size = New System.Drawing.Size(25, 13)
      Me._numberOfPagesLabel.TabIndex = 8
      Me._numberOfPagesLabel.Text = "of 1"
      '
      '_openToPageLabel
      '
      Me._openToPageLabel.AutoSize = True
      Me._openToPageLabel.Location = New System.Drawing.Point(20, 119)
      Me._openToPageLabel.Name = "_openToPageLabel"
      Me._openToPageLabel.Size = New System.Drawing.Size(72, 13)
      Me._openToPageLabel.TabIndex = 6
      Me._openToPageLabel.Text = "&Open to page"
      '
      '_pageFitTypeComboBox
      '
      Me._pageFitTypeComboBox.FormattingEnabled = True
      Me._pageFitTypeComboBox.Location = New System.Drawing.Point(100, 80)
      Me._pageFitTypeComboBox.Name = "_pageFitTypeComboBox"
      Me._pageFitTypeComboBox.Size = New System.Drawing.Size(255, 21)
      Me._pageFitTypeComboBox.TabIndex = 5
      '
      '_pageFitTypeLabel
      '
      Me._pageFitTypeLabel.AutoSize = True
      Me._pageFitTypeLabel.Location = New System.Drawing.Point(20, 83)
      Me._pageFitTypeLabel.Name = "_pageFitTypeLabel"
      Me._pageFitTypeLabel.Size = New System.Drawing.Size(69, 13)
      Me._pageFitTypeLabel.TabIndex = 4
      Me._pageFitTypeLabel.Text = "Page &fit type:"
      '
      '_pageLayoutComboBox
      '
      Me._pageLayoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._pageLayoutComboBox.FormattingEnabled = True
      Me._pageLayoutComboBox.Location = New System.Drawing.Point(100, 53)
      Me._pageLayoutComboBox.Name = "_pageLayoutComboBox"
      Me._pageLayoutComboBox.Size = New System.Drawing.Size(255, 21)
      Me._pageLayoutComboBox.TabIndex = 3
      '
      '_pageLayoutLabel
      '
      Me._pageLayoutLabel.AutoSize = True
      Me._pageLayoutLabel.Location = New System.Drawing.Point(20, 56)
      Me._pageLayoutLabel.Name = "_pageLayoutLabel"
      Me._pageLayoutLabel.Size = New System.Drawing.Size(66, 13)
      Me._pageLayoutLabel.TabIndex = 2
      Me._pageLayoutLabel.Text = "Page &layout:"
      '
      '_pageModeComboBox
      '
      Me._pageModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._pageModeComboBox.FormattingEnabled = True
      Me._pageModeComboBox.Location = New System.Drawing.Point(100, 26)
      Me._pageModeComboBox.Name = "_pageModeComboBox"
      Me._pageModeComboBox.Size = New System.Drawing.Size(255, 21)
      Me._pageModeComboBox.TabIndex = 1
      '
      '_pageModeLabel
      '
      Me._pageModeLabel.AutoSize = True
      Me._pageModeLabel.Location = New System.Drawing.Point(20, 29)
      Me._pageModeLabel.Name = "_pageModeLabel"
      Me._pageModeLabel.Size = New System.Drawing.Size(64, 13)
      Me._pageModeLabel.TabIndex = 0
      Me._pageModeLabel.Text = "Page &mode:"
      '
      '_producerLabel
      '
      Me._producerLabel.AutoSize = True
      Me._producerLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._producerLabel.Location = New System.Drawing.Point(19, 126)
      Me._producerLabel.Name = "_producerLabel"
      Me._producerLabel.Size = New System.Drawing.Size(50, 13)
      Me._producerLabel.TabIndex = 15
      Me._producerLabel.Text = "Producer"
      '
      '_producerTextBox
      '
      Me._producerTextBox.Location = New System.Drawing.Point(97, 123)
      Me._producerTextBox.Name = "_producerTextBox"
      Me._producerTextBox.Size = New System.Drawing.Size(342, 20)
      Me._producerTextBox.TabIndex = 16
      '
      '_creatorLabel
      '
      Me._creatorLabel.AutoSize = True
      Me._creatorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._creatorLabel.Location = New System.Drawing.Point(19, 100)
      Me._creatorLabel.Name = "_creatorLabel"
      Me._creatorLabel.Size = New System.Drawing.Size(41, 13)
      Me._creatorLabel.TabIndex = 13
      Me._creatorLabel.Text = "Creator"
      '
      '_creatorTextBox
      '
      Me._creatorTextBox.Location = New System.Drawing.Point(97, 97)
      Me._creatorTextBox.Name = "_creatorTextBox"
      Me._creatorTextBox.Size = New System.Drawing.Size(342, 20)
      Me._creatorTextBox.TabIndex = 14
      '
      'AdvancedPdfDocumentOptionsDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(486, 473)
      Me.Controls.Add(Me._tabControl)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AdvancedPdfDocumentOptionsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Advanced PDF Options"
      Me._compressionsOptionsGroupBox.ResumeLayout(False)
      Me._compressionsOptionsGroupBox.PerformLayout()
      CType(Me._qualityFactorNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me._tabControl.ResumeLayout(False)
      Me._descriptionTab.ResumeLayout(False)
      Me._propertiesGroupBox.ResumeLayout(False)
      Me._propertiesGroupBox.PerformLayout()
      Me._fontsTab.ResumeLayout(False)
      Me._generalGroupBox.ResumeLayout(False)
      Me._generalGroupBox.PerformLayout()
      Me._securityTab.ResumeLayout(False)
      Me._securityGroupBox.ResumeLayout(False)
      Me._securityGroupBox.PerformLayout()
      Me._permissionsGroupBox.ResumeLayout(False)
      Me._permissionsGroupBox.PerformLayout()
      Me._compressionTab.ResumeLayout(False)
      Me._imageOverTextCompressionOptionsGroupBox.ResumeLayout(False)
      Me._imageOverTextCompressionOptionsGroupBox.PerformLayout()
      Me._initialViewTab.ResumeLayout(False)
      Me._userInterfaceOptionsGroupBox.ResumeLayout(False)
      Me._userInterfaceOptionsGroupBox.PerformLayout()
      Me._windowsOptionsGroupBox.ResumeLayout(False)
      Me._windowsOptionsGroupBox.PerformLayout()
      Me._layoutPageModeGroupBox.ResumeLayout(False)
      Me._layoutPageModeGroupBox.PerformLayout()
      CType(Me._initialPageNumberNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _compressionsOptionsGroupBox As System.Windows.Forms.GroupBox
   Private _qualityFactorNumericUpDown As System.Windows.Forms.NumericUpDown
   Private _qualityFactorLabel As System.Windows.Forms.Label
   Private WithEvents _coloredImageCompressionComboBox As System.Windows.Forms.ComboBox
   Private _oneBitImageCompressionComboBox As System.Windows.Forms.ComboBox
   Private _coloredImageCompressionLabel As System.Windows.Forms.Label
   Private _oneBitImageCompressionLabel As System.Windows.Forms.Label
   Private _tabControl As System.Windows.Forms.TabControl
   Private _descriptionTab As System.Windows.Forms.TabPage
   Private _propertiesGroupBox As System.Windows.Forms.GroupBox
   Private _keywordsLabelNote As System.Windows.Forms.Label
   Private _keywordsLabel As System.Windows.Forms.Label
   Private _authorLabel As System.Windows.Forms.Label
   Private _subjectLabel As System.Windows.Forms.Label
   Private _titleLabel As System.Windows.Forms.Label
   Private _keywordsTextBox As System.Windows.Forms.TextBox
   Private _authorTextBox As System.Windows.Forms.TextBox
   Private _subjectTextBox As System.Windows.Forms.TextBox
   Private _titleTextBox As System.Windows.Forms.TextBox
   Private _fontsTab As System.Windows.Forms.TabPage
   Private _generalGroupBox As System.Windows.Forms.GroupBox
   Private _linearizedCheckBox As System.Windows.Forms.CheckBox
   Private _fontEmbeddingLabel As System.Windows.Forms.Label
   Private _fontEmbeddingComboBox As System.Windows.Forms.ComboBox
   Private _securityTab As System.Windows.Forms.TabPage
   Private _securityGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _encryptionModeComboBox As System.Windows.Forms.ComboBox
   Private _encryptionModeLabel As System.Windows.Forms.Label
   Private _permissionsGroupBox As System.Windows.Forms.GroupBox
   Private _highQualityPrintEnabledCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _printEnabledCheckBox As System.Windows.Forms.CheckBox
   Private _assemblyEnabledCheckBox As System.Windows.Forms.CheckBox
   Private _annotationsEnabledCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _editEnabledCheckBox As System.Windows.Forms.CheckBox
   Private _copyEnabledCheckBox As System.Windows.Forms.CheckBox
   Private _ownerPasswordLabel As System.Windows.Forms.Label
   Private _userPasswordLabel As System.Windows.Forms.Label
   Private _ownerPasswordTextBox As System.Windows.Forms.TextBox
   Private _userPasswordTextBox As System.Windows.Forms.TextBox
   Private WithEvents _protectedCheckBox As System.Windows.Forms.CheckBox
   Private _compressionTab As System.Windows.Forms.TabPage
   Private _initialViewTab As System.Windows.Forms.TabPage
   Private _imageOverTextCompressionOptionsGroupBox As System.Windows.Forms.GroupBox
   Private _imageOverTextModeComboBox As System.Windows.Forms.ComboBox
   Private _imageOverTextModeLabel As System.Windows.Forms.Label
   Private _imageOverTextSizeComboBox As System.Windows.Forms.ComboBox
   Private _imageOverTextSizeLabel As System.Windows.Forms.Label
   Private _layoutPageModeGroupBox As System.Windows.Forms.GroupBox
   Private _pageModeLabel As System.Windows.Forms.Label
   Private _pageFitTypeComboBox As System.Windows.Forms.ComboBox
   Private _pageFitTypeLabel As System.Windows.Forms.Label
   Private _pageLayoutComboBox As System.Windows.Forms.ComboBox
   Private _pageLayoutLabel As System.Windows.Forms.Label
   Private _pageModeComboBox As System.Windows.Forms.ComboBox
   Private _numberOfPagesLabel As System.Windows.Forms.Label
   Private _openToPageLabel As System.Windows.Forms.Label
   Private _userInterfaceOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _hideWindowControlsCheckBox As System.Windows.Forms.CheckBox
   Private _hideToolBarCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _hideMenuBarCheckBox As System.Windows.Forms.CheckBox
   Private _windowsOptionsGroupBox As System.Windows.Forms.GroupBox
   Private _centerWindowCheckBox As System.Windows.Forms.CheckBox
   Private _resizeWindowCheckBox As System.Windows.Forms.CheckBox
   Private _showDocumentTitleComboBox As System.Windows.Forms.ComboBox
   Private _showDocumentTitleLabel As System.Windows.Forms.Label
   Private _initialPageNumberNumericUpDown As System.Windows.Forms.NumericUpDown
   Private WithEvents _producerLabel As System.Windows.Forms.Label
   Private WithEvents _producerTextBox As System.Windows.Forms.TextBox
   Private WithEvents _creatorLabel As System.Windows.Forms.Label
   Private WithEvents _creatorTextBox As System.Windows.Forms.TextBox
End Class
