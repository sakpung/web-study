Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class ClientConfiguration
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me.components = New System.ComponentModel.Container()
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientConfiguration))
		 Me.CompressionGroupBox = New System.Windows.Forms.GroupBox()
		 Me.LossyCompressionRadioButton = New System.Windows.Forms.RadioButton()
		 Me.LosslessCompressionRadioButton = New System.Windows.Forms.RadioButton()
		 Me.DebugGroupBox = New System.Windows.Forms.GroupBox()
		 Me.DebugLogFileButton = New System.Windows.Forms.Button()
		 Me.DebugLogFileNameTextBox = New System.Windows.Forms.TextBox()
		 Me.DebugLogFileCheckBox = New System.Windows.Forms.CheckBox()
		 Me.DisplayDetailDebugMsgCheckBox = New System.Windows.Forms.CheckBox()
		 Me.DicomClientGroupBox = New System.Windows.Forms.GroupBox()
		 Me.ForceToAllClientsCheckBox = New System.Windows.Forms.CheckBox()
		 Me.WorkstationHostaddressComboBox = New System.Windows.Forms.ComboBox()
		 Me.WorkstationPortLabel = New System.Windows.Forms.Label()
		 Me.WorkstationPortMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
		 Me.WorkstationIPLabel = New System.Windows.Forms.Label()
		 Me.DicomClientDescriptionLabel = New System.Windows.Forms.Label()
		 Me.WorstationAELabel = New System.Windows.Forms.Label()
		 Me.WorkstationAETextBox = New System.Windows.Forms.TextBox()
		 Me.EnableDebugCheckBox = New System.Windows.Forms.CheckBox()
		 Me.BrowseLogFileDialog = New System.Windows.Forms.SaveFileDialog()
		 Me.ContinueRetireveOnDuplicateCheckBox = New System.Windows.Forms.CheckBox()
		 Me.DicomRetrieveGroupBox = New System.Windows.Forms.GroupBox()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.WorkstationServiceAETitleTextBox = New System.Windows.Forms.TextBox()
		 Me.MoveToWsServiceRadioButton = New System.Windows.Forms.RadioButton()
		 Me.MoveToWsClientRadioButton = New System.Windows.Forms.RadioButton()
		 Me.GenericErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me.DisplayOrientationButton = New System.Windows.Forms.Button()
		 Me.FullScreenModeCheckBox = New System.Windows.Forms.CheckBox()
		 Me.ViewerOverlayTextSizeGroupBox = New System.Windows.Forms.GroupBox()
		 Me.FixedOverlayTextSizeNumericUpDown = New System.Windows.Forms.NumericUpDown()
		 Me.FixedOverlayTextSizeLabel = New System.Windows.Forms.Label()
		 Me.AutoSizeOverlayTextCheckBox = New System.Windows.Forms.CheckBox()
		 Me.LazyLoadingGroupBox = New System.Windows.Forms.GroupBox()
		 Me.EnableLazyLoadingCheckBox = New System.Windows.Forms.CheckBox()
		 Me.LazyLoadingHiddenImagesMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
		 Me.LazyLoadingHiddenLabel = New System.Windows.Forms.Label()
		 Me.LazyLoadingLoadLable = New System.Windows.Forms.Label()
		 Me.LazyLoadingDescriptionLabel = New System.Windows.Forms.Label()
		 Me.UseCompressionCheckBox = New System.Windows.Forms.CheckBox()
		 Me.SaveSessionGroupBox = New System.Windows.Forms.GroupBox()
		 Me.PromptUserSaveSessionRadioButton = New System.Windows.Forms.RadioButton()
		 Me.NeverSaveSessionRadioButton = New System.Windows.Forms.RadioButton()
		 Me.AlwaysSaveSessionRadioButton = New System.Windows.Forms.RadioButton()
		 Me.SaveUserSessionLabel = New System.Windows.Forms.Label()
		 Me.CompressionGroupBox.SuspendLayout()
		 Me.DebugGroupBox.SuspendLayout()
		 Me.DicomClientGroupBox.SuspendLayout()
		 Me.DicomRetrieveGroupBox.SuspendLayout()
		 CType(Me.GenericErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.groupBox1.SuspendLayout()
		 Me.ViewerOverlayTextSizeGroupBox.SuspendLayout()
		 CType(Me.FixedOverlayTextSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.LazyLoadingGroupBox.SuspendLayout()
		 Me.SaveSessionGroupBox.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' CompressionGroupBox
		 ' 
		 Me.CompressionGroupBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.CompressionGroupBox.Controls.Add(Me.LossyCompressionRadioButton)
		 Me.CompressionGroupBox.Controls.Add(Me.LosslessCompressionRadioButton)
		 Me.CompressionGroupBox.Location = New System.Drawing.Point(510, 151)
		 Me.CompressionGroupBox.Name = "CompressionGroupBox"
		 Me.CompressionGroupBox.Size = New System.Drawing.Size(435, 75)
		 Me.CompressionGroupBox.TabIndex = 1
		 Me.CompressionGroupBox.TabStop = False
		 ' 
		 ' LossyCompressionRadioButton
		 ' 
		 Me.LossyCompressionRadioButton.AutoSize = True
		 Me.LossyCompressionRadioButton.Location = New System.Drawing.Point(18, 49)
		 Me.LossyCompressionRadioButton.Name = "LossyCompressionRadioButton"
		 Me.LossyCompressionRadioButton.Size = New System.Drawing.Size(52, 17)
		 Me.LossyCompressionRadioButton.TabIndex = 1
		 Me.LossyCompressionRadioButton.TabStop = True
		 Me.LossyCompressionRadioButton.Text = "Lossy"
		 Me.LossyCompressionRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' LosslessCompressionRadioButton
		 ' 
		 Me.LosslessCompressionRadioButton.AutoSize = True
		 Me.LosslessCompressionRadioButton.Location = New System.Drawing.Point(18, 26)
		 Me.LosslessCompressionRadioButton.Name = "LosslessCompressionRadioButton"
		 Me.LosslessCompressionRadioButton.Size = New System.Drawing.Size(65, 17)
		 Me.LosslessCompressionRadioButton.TabIndex = 0
		 Me.LosslessCompressionRadioButton.TabStop = True
		 Me.LosslessCompressionRadioButton.Text = "Lossless"
		 Me.LosslessCompressionRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' DebugGroupBox
		 ' 
		 Me.DebugGroupBox.Controls.Add(Me.DebugLogFileButton)
		 Me.DebugGroupBox.Controls.Add(Me.DebugLogFileNameTextBox)
		 Me.DebugGroupBox.Controls.Add(Me.DebugLogFileCheckBox)
		 Me.DebugGroupBox.Controls.Add(Me.DisplayDetailDebugMsgCheckBox)
		 Me.DebugGroupBox.Location = New System.Drawing.Point(9, 405)
		 Me.DebugGroupBox.Name = "DebugGroupBox"
		 Me.DebugGroupBox.Size = New System.Drawing.Size(494, 124)
		 Me.DebugGroupBox.TabIndex = 4
		 Me.DebugGroupBox.TabStop = False
		 ' 
		 ' DebugLogFileButton
		 ' 
		 Me.DebugLogFileButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.DebugLogFileButton.BackColor = System.Drawing.SystemColors.Control
		 Me.DebugLogFileButton.CausesValidation = False
		 Me.DebugLogFileButton.ForeColor = System.Drawing.Color.Black
		 Me.DebugLogFileButton.Location = New System.Drawing.Point(457, 72)
		 Me.DebugLogFileButton.Name = "DebugLogFileButton"
		 Me.DebugLogFileButton.Size = New System.Drawing.Size(29, 28)
		 Me.DebugLogFileButton.TabIndex = 3
		 Me.DebugLogFileButton.Text = "..."
		 Me.DebugLogFileButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
		 Me.DebugLogFileButton.UseVisualStyleBackColor = False
		 ' 
		 ' DebugLogFileNameTextBox
		 ' 
		 Me.DebugLogFileNameTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.DebugLogFileNameTextBox.Location = New System.Drawing.Point(59, 77)
		 Me.DebugLogFileNameTextBox.Name = "DebugLogFileNameTextBox"
		 Me.DebugLogFileNameTextBox.Size = New System.Drawing.Size(392, 20)
		 Me.DebugLogFileNameTextBox.TabIndex = 2
		 ' 
		 ' DebugLogFileCheckBox
		 ' 
		 Me.DebugLogFileCheckBox.AutoSize = True
		 Me.DebugLogFileCheckBox.CausesValidation = False
		 Me.DebugLogFileCheckBox.Location = New System.Drawing.Point(36, 54)
		 Me.DebugLogFileCheckBox.Name = "DebugLogFileCheckBox"
		 Me.DebugLogFileCheckBox.Size = New System.Drawing.Size(234, 17)
		 Me.DebugLogFileCheckBox.TabIndex = 1
		 Me.DebugLogFileCheckBox.Text = "Generate Log file for DICOM communication"
		 Me.DebugLogFileCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' DisplayDetailDebugMsgCheckBox
		 ' 
		 Me.DisplayDetailDebugMsgCheckBox.AutoSize = True
		 Me.DisplayDetailDebugMsgCheckBox.Location = New System.Drawing.Point(36, 27)
		 Me.DisplayDetailDebugMsgCheckBox.Name = "DisplayDetailDebugMsgCheckBox"
		 Me.DisplayDetailDebugMsgCheckBox.Size = New System.Drawing.Size(227, 17)
		 Me.DisplayDetailDebugMsgCheckBox.TabIndex = 0
		 Me.DisplayDetailDebugMsgCheckBox.Text = "Display detailed debug messages on errors"
		 Me.DisplayDetailDebugMsgCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' DicomClientGroupBox
		 ' 
		 Me.DicomClientGroupBox.Controls.Add(Me.ForceToAllClientsCheckBox)
		 Me.DicomClientGroupBox.Controls.Add(Me.WorkstationHostaddressComboBox)
		 Me.DicomClientGroupBox.Controls.Add(Me.WorkstationPortLabel)
		 Me.DicomClientGroupBox.Controls.Add(Me.WorkstationPortMaskedTextBox)
		 Me.DicomClientGroupBox.Controls.Add(Me.WorkstationIPLabel)
		 Me.DicomClientGroupBox.Controls.Add(Me.DicomClientDescriptionLabel)
		 Me.DicomClientGroupBox.Controls.Add(Me.WorstationAELabel)
		 Me.DicomClientGroupBox.Controls.Add(Me.WorkstationAETextBox)
		 Me.DicomClientGroupBox.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.DicomClientGroupBox.ForeColor = System.Drawing.Color.White
		 Me.DicomClientGroupBox.Location = New System.Drawing.Point(6, 9)
		 Me.DicomClientGroupBox.Name = "DicomClientGroupBox"
		 Me.DicomClientGroupBox.Size = New System.Drawing.Size(497, 217)
		 Me.DicomClientGroupBox.TabIndex = 0
		 Me.DicomClientGroupBox.TabStop = False
		 Me.DicomClientGroupBox.Text = "DICOM Client"
		 ' 
		 ' ForceToAllClientsCheckBox
		 ' 
		 Me.ForceToAllClientsCheckBox.AutoSize = True
		 Me.ForceToAllClientsCheckBox.Location = New System.Drawing.Point(13, 159)
		 Me.ForceToAllClientsCheckBox.Name = "ForceToAllClientsCheckBox"
		 Me.ForceToAllClientsCheckBox.Size = New System.Drawing.Size(298, 17)
		 Me.ForceToAllClientsCheckBox.TabIndex = 5
		 Me.ForceToAllClientsCheckBox.Text = "Force AE Title and Port to all Workstation Clients"
		 Me.ForceToAllClientsCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' WorkstationHostaddressComboBox
		 ' 
		 Me.WorkstationHostaddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me.WorkstationHostaddressComboBox.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.WorkstationHostaddressComboBox.FormattingEnabled = True
		 Me.WorkstationHostaddressComboBox.Location = New System.Drawing.Point(89, 99)
		 Me.WorkstationHostaddressComboBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		 Me.WorkstationHostaddressComboBox.Name = "WorkstationHostaddressComboBox"
		 Me.WorkstationHostaddressComboBox.Size = New System.Drawing.Size(205, 21)
		 Me.WorkstationHostaddressComboBox.TabIndex = 4
		 ' 
		 ' WorkstationPortLabel
		 ' 
		 Me.WorkstationPortLabel.AutoSize = True
		 Me.WorkstationPortLabel.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.WorkstationPortLabel.Location = New System.Drawing.Point(10, 131)
		 Me.WorkstationPortLabel.Name = "WorkstationPortLabel"
		 Me.WorkstationPortLabel.Size = New System.Drawing.Size(31, 13)
		 Me.WorkstationPortLabel.TabIndex = 11
		 Me.WorkstationPortLabel.Text = "Port:"
		 ' 
		 ' WorkstationPortMaskedTextBox
		 ' 
		 Me.WorkstationPortMaskedTextBox.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.WorkstationPortMaskedTextBox.Location = New System.Drawing.Point(89, 128)
		 Me.WorkstationPortMaskedTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		 Me.WorkstationPortMaskedTextBox.Mask = "000000"
		 Me.WorkstationPortMaskedTextBox.Name = "WorkstationPortMaskedTextBox"
		 Me.WorkstationPortMaskedTextBox.PromptChar = "*"c
		 Me.WorkstationPortMaskedTextBox.Size = New System.Drawing.Size(205, 20)
		 Me.WorkstationPortMaskedTextBox.TabIndex = 12
		 ' 
		 ' WorkstationIPLabel
		 ' 
		 Me.WorkstationIPLabel.AutoSize = True
		 Me.WorkstationIPLabel.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.WorkstationIPLabel.Location = New System.Drawing.Point(11, 101)
		 Me.WorkstationIPLabel.Name = "WorkstationIPLabel"
		 Me.WorkstationIPLabel.Size = New System.Drawing.Size(63, 13)
		 Me.WorkstationIPLabel.TabIndex = 3
		 Me.WorkstationIPLabel.Text = "IP Address:"
		 ' 
		 ' DicomClientDescriptionLabel
		 ' 
		 Me.DicomClientDescriptionLabel.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.DicomClientDescriptionLabel.Location = New System.Drawing.Point(11, 25)
		 Me.DicomClientDescriptionLabel.Name = "DicomClientDescriptionLabel"
		 Me.DicomClientDescriptionLabel.Size = New System.Drawing.Size(480, 34)
		 Me.DicomClientDescriptionLabel.TabIndex = 0
		 Me.DicomClientDescriptionLabel.Text = "The Workstation Client will perform DICOM Query/Retrieve against DICOM servers an" & "d allow you to store DICOM Objects to configured PACS."
		 ' 
		 ' WorstationAELabel
		 ' 
		 Me.WorstationAELabel.AutoSize = True
		 Me.WorstationAELabel.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.WorstationAELabel.Location = New System.Drawing.Point(10, 73)
		 Me.WorstationAELabel.Name = "WorstationAELabel"
		 Me.WorstationAELabel.Size = New System.Drawing.Size(47, 13)
		 Me.WorstationAELabel.TabIndex = 1
		 Me.WorstationAELabel.Text = "AE Title:"
		 ' 
		 ' WorkstationAETextBox
		 ' 
		 Me.WorkstationAETextBox.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.WorkstationAETextBox.Location = New System.Drawing.Point(89, 71)
		 Me.WorkstationAETextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		 Me.WorkstationAETextBox.Name = "WorkstationAETextBox"
		 Me.WorkstationAETextBox.Size = New System.Drawing.Size(205, 20)
		 Me.WorkstationAETextBox.TabIndex = 2
		 ' 
		 ' EnableDebugCheckBox
		 ' 
		 Me.EnableDebugCheckBox.AutoSize = True
		 Me.EnableDebugCheckBox.CausesValidation = False
		 Me.EnableDebugCheckBox.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.EnableDebugCheckBox.ForeColor = System.Drawing.Color.White
		 Me.EnableDebugCheckBox.Location = New System.Drawing.Point(16, 404)
		 Me.EnableDebugCheckBox.Name = "EnableDebugCheckBox"
		 Me.EnableDebugCheckBox.Size = New System.Drawing.Size(138, 17)
		 Me.EnableDebugCheckBox.TabIndex = 5
		 Me.EnableDebugCheckBox.Text = "Enable DEBUG mode"
		 Me.EnableDebugCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' BrowseLogFileDialog
		 ' 
		 Me.BrowseLogFileDialog.Filter = "Text File (*.txt)|*.txt|Alll Files|*.*"
		 ' 
		 ' ContinueRetireveOnDuplicateCheckBox
		 ' 
		 Me.ContinueRetireveOnDuplicateCheckBox.AutoSize = True
		 Me.ContinueRetireveOnDuplicateCheckBox.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.ContinueRetireveOnDuplicateCheckBox.ForeColor = System.Drawing.Color.White
		 Me.ContinueRetireveOnDuplicateCheckBox.Location = New System.Drawing.Point(43, 48)
		 Me.ContinueRetireveOnDuplicateCheckBox.Name = "ContinueRetireveOnDuplicateCheckBox"
		 Me.ContinueRetireveOnDuplicateCheckBox.Size = New System.Drawing.Size(366, 17)
		 Me.ContinueRetireveOnDuplicateCheckBox.TabIndex = 0
		 Me.ContinueRetireveOnDuplicateCheckBox.Text = "Continue retrieving images from PACS when duplicate instances found."
		 Me.ContinueRetireveOnDuplicateCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' DicomRetrieveGroupBox
		 ' 
		 Me.DicomRetrieveGroupBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.DicomRetrieveGroupBox.Controls.Add(Me.label1)
		 Me.DicomRetrieveGroupBox.Controls.Add(Me.WorkstationServiceAETitleTextBox)
		 Me.DicomRetrieveGroupBox.Controls.Add(Me.MoveToWsServiceRadioButton)
		 Me.DicomRetrieveGroupBox.Controls.Add(Me.MoveToWsClientRadioButton)
		 Me.DicomRetrieveGroupBox.Controls.Add(Me.ContinueRetireveOnDuplicateCheckBox)
		 Me.DicomRetrieveGroupBox.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.DicomRetrieveGroupBox.ForeColor = System.Drawing.Color.White
		 Me.DicomRetrieveGroupBox.Location = New System.Drawing.Point(510, 9)
		 Me.DicomRetrieveGroupBox.Name = "DicomRetrieveGroupBox"
		 Me.DicomRetrieveGroupBox.Size = New System.Drawing.Size(435, 133)
		 Me.DicomRetrieveGroupBox.TabIndex = 3
		 Me.DicomRetrieveGroupBox.TabStop = False
		 Me.DicomRetrieveGroupBox.Text = "DICOM Retrieve"
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.label1.Location = New System.Drawing.Point(45, 100)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(47, 13)
		 Me.label1.TabIndex = 13
		 Me.label1.Text = "AE Title:"
		 ' 
		 ' WorkstationServiceAETitleTextBox
		 ' 
		 Me.WorkstationServiceAETitleTextBox.Font = New System.Drawing.Font("Tahoma", 8F)
		 Me.WorkstationServiceAETitleTextBox.Location = New System.Drawing.Point(96, 98)
		 Me.WorkstationServiceAETitleTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		 Me.WorkstationServiceAETitleTextBox.Name = "WorkstationServiceAETitleTextBox"
		 Me.WorkstationServiceAETitleTextBox.ReadOnly = True
		 Me.WorkstationServiceAETitleTextBox.Size = New System.Drawing.Size(205, 20)
		 Me.WorkstationServiceAETitleTextBox.TabIndex = 14
		 ' 
		 ' MoveToWsServiceRadioButton
		 ' 
		 Me.MoveToWsServiceRadioButton.AutoSize = True
		 Me.MoveToWsServiceRadioButton.Location = New System.Drawing.Point(18, 71)
		 Me.MoveToWsServiceRadioButton.Name = "MoveToWsServiceRadioButton"
		 Me.MoveToWsServiceRadioButton.Size = New System.Drawing.Size(325, 17)
		 Me.MoveToWsServiceRadioButton.TabIndex = 10
		 Me.MoveToWsServiceRadioButton.TabStop = True
		 Me.MoveToWsServiceRadioButton.Text = "Move DICOM Objects to Workstation Listener Service"
		 Me.MoveToWsServiceRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' MoveToWsClientRadioButton
		 ' 
		 Me.MoveToWsClientRadioButton.AutoSize = True
		 Me.MoveToWsClientRadioButton.Location = New System.Drawing.Point(18, 22)
		 Me.MoveToWsClientRadioButton.Name = "MoveToWsClientRadioButton"
		 Me.MoveToWsClientRadioButton.Size = New System.Drawing.Size(266, 17)
		 Me.MoveToWsClientRadioButton.TabIndex = 9
		 Me.MoveToWsClientRadioButton.TabStop = True
		 Me.MoveToWsClientRadioButton.Text = "Move DICOM Objects to Workstation Client"
		 Me.MoveToWsClientRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' GenericErrorProvider
		 ' 
		 Me.GenericErrorProvider.ContainerControl = Me
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.groupBox1.Controls.Add(Me.DisplayOrientationButton)
		 Me.groupBox1.Controls.Add(Me.FullScreenModeCheckBox)
		 Me.groupBox1.Controls.Add(Me.ViewerOverlayTextSizeGroupBox)
		 Me.groupBox1.Controls.Add(Me.LazyLoadingGroupBox)
		 Me.groupBox1.ForeColor = System.Drawing.Color.White
		 Me.groupBox1.Location = New System.Drawing.Point(9, 233)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(936, 165)
		 Me.groupBox1.TabIndex = 9
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Viewer Options"
		 ' 
		 ' DisplayOrientationButton
		 ' 
		 Me.DisplayOrientationButton.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.DisplayOrientationButton.Location = New System.Drawing.Point(501, 119)
		 Me.DisplayOrientationButton.Name = "DisplayOrientationButton"
		 Me.DisplayOrientationButton.Size = New System.Drawing.Size(120, 27)
		 Me.DisplayOrientationButton.TabIndex = 12
		 Me.DisplayOrientationButton.Text = "Display Orientation..."
		 Me.DisplayOrientationButton.UseVisualStyleBackColor = False
		 ' 
		 ' FullScreenModeCheckBox
		 ' 
		 Me.FullScreenModeCheckBox.AutoSize = True
		 Me.FullScreenModeCheckBox.Location = New System.Drawing.Point(501, 96)
		 Me.FullScreenModeCheckBox.Name = "FullScreenModeCheckBox"
		 Me.FullScreenModeCheckBox.Size = New System.Drawing.Size(285, 17)
		 Me.FullScreenModeCheckBox.TabIndex = 11
		 Me.FullScreenModeCheckBox.Text = "Run Workstation Viewer in full screen mode on start up"
		 Me.FullScreenModeCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' ViewerOverlayTextSizeGroupBox
		 ' 
		 Me.ViewerOverlayTextSizeGroupBox.Controls.Add(Me.FixedOverlayTextSizeNumericUpDown)
		 Me.ViewerOverlayTextSizeGroupBox.Controls.Add(Me.FixedOverlayTextSizeLabel)
		 Me.ViewerOverlayTextSizeGroupBox.Controls.Add(Me.AutoSizeOverlayTextCheckBox)
		 Me.ViewerOverlayTextSizeGroupBox.ForeColor = System.Drawing.Color.White
		 Me.ViewerOverlayTextSizeGroupBox.Location = New System.Drawing.Point(501, 19)
		 Me.ViewerOverlayTextSizeGroupBox.Name = "ViewerOverlayTextSizeGroupBox"
		 Me.ViewerOverlayTextSizeGroupBox.Size = New System.Drawing.Size(339, 68)
		 Me.ViewerOverlayTextSizeGroupBox.TabIndex = 10
		 Me.ViewerOverlayTextSizeGroupBox.TabStop = False
		 ' 
		 ' FixedOverlayTextSizeNumericUpDown
		 ' 
		 Me.FixedOverlayTextSizeNumericUpDown.Location = New System.Drawing.Point(181, 27)
		 Me.FixedOverlayTextSizeNumericUpDown.Maximum = New Decimal(New Integer() { 99, 0, 0, 0})
		 Me.FixedOverlayTextSizeNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
		 Me.FixedOverlayTextSizeNumericUpDown.Name = "FixedOverlayTextSizeNumericUpDown"
		 Me.FixedOverlayTextSizeNumericUpDown.Size = New System.Drawing.Size(56, 20)
		 Me.FixedOverlayTextSizeNumericUpDown.TabIndex = 2
		 Me.FixedOverlayTextSizeNumericUpDown.Value = New Decimal(New Integer() { 14, 0, 0, 0})
		 ' 
		 ' FixedOverlayTextSizeLabel
		 ' 
		 Me.FixedOverlayTextSizeLabel.AutoSize = True
		 Me.FixedOverlayTextSizeLabel.Location = New System.Drawing.Point(10, 29)
		 Me.FixedOverlayTextSizeLabel.Name = "FixedOverlayTextSizeLabel"
		 Me.FixedOverlayTextSizeLabel.Size = New System.Drawing.Size(168, 13)
		 Me.FixedOverlayTextSizeLabel.TabIndex = 1
		 Me.FixedOverlayTextSizeLabel.Text = "Use fixed size for the overlay text: "
		 ' 
		 ' AutoSizeOverlayTextCheckBox
		 ' 
		 Me.AutoSizeOverlayTextCheckBox.AutoSize = True
		 Me.AutoSizeOverlayTextCheckBox.Location = New System.Drawing.Point(5, -2)
		 Me.AutoSizeOverlayTextCheckBox.Name = "AutoSizeOverlayTextCheckBox"
		 Me.AutoSizeOverlayTextCheckBox.Size = New System.Drawing.Size(134, 17)
		 Me.AutoSizeOverlayTextCheckBox.TabIndex = 0
		 Me.AutoSizeOverlayTextCheckBox.Text = "Auto Size Overlay Text"
		 Me.AutoSizeOverlayTextCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' LazyLoadingGroupBox
		 ' 
		 Me.LazyLoadingGroupBox.Controls.Add(Me.EnableLazyLoadingCheckBox)
		 Me.LazyLoadingGroupBox.Controls.Add(Me.LazyLoadingHiddenImagesMaskedTextBox)
		 Me.LazyLoadingGroupBox.Controls.Add(Me.LazyLoadingHiddenLabel)
		 Me.LazyLoadingGroupBox.Controls.Add(Me.LazyLoadingLoadLable)
		 Me.LazyLoadingGroupBox.Controls.Add(Me.LazyLoadingDescriptionLabel)
		 Me.LazyLoadingGroupBox.Location = New System.Drawing.Point(10, 19)
		 Me.LazyLoadingGroupBox.Name = "LazyLoadingGroupBox"
		 Me.LazyLoadingGroupBox.Size = New System.Drawing.Size(484, 127)
		 Me.LazyLoadingGroupBox.TabIndex = 9
		 Me.LazyLoadingGroupBox.TabStop = False
		 ' 
		 ' EnableLazyLoadingCheckBox
		 ' 
		 Me.EnableLazyLoadingCheckBox.AutoSize = True
		 Me.EnableLazyLoadingCheckBox.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.EnableLazyLoadingCheckBox.Location = New System.Drawing.Point(6, 0)
		 Me.EnableLazyLoadingCheckBox.Name = "EnableLazyLoadingCheckBox"
		 Me.EnableLazyLoadingCheckBox.Size = New System.Drawing.Size(180, 17)
		 Me.EnableLazyLoadingCheckBox.TabIndex = 0
		 Me.EnableLazyLoadingCheckBox.Text = "Enable Viewer Lazy Loading"
		 Me.EnableLazyLoadingCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' LazyLoadingHiddenImagesMaskedTextBox
		 ' 
		 Me.LazyLoadingHiddenImagesMaskedTextBox.HidePromptOnLeave = True
		 Me.LazyLoadingHiddenImagesMaskedTextBox.Location = New System.Drawing.Point(70, 78)
		 Me.LazyLoadingHiddenImagesMaskedTextBox.Mask = "00000"
		 Me.LazyLoadingHiddenImagesMaskedTextBox.Name = "LazyLoadingHiddenImagesMaskedTextBox"
		 Me.LazyLoadingHiddenImagesMaskedTextBox.PromptChar = "*"c
		 Me.LazyLoadingHiddenImagesMaskedTextBox.Size = New System.Drawing.Size(54, 20)
		 Me.LazyLoadingHiddenImagesMaskedTextBox.TabIndex = 3
		 Me.LazyLoadingHiddenImagesMaskedTextBox.ValidatingType = GetType(Integer)
		 ' 
		 ' LazyLoadingHiddenLabel
		 ' 
		 Me.LazyLoadingHiddenLabel.AutoSize = True
		 Me.LazyLoadingHiddenLabel.Location = New System.Drawing.Point(129, 81)
		 Me.LazyLoadingHiddenLabel.Name = "LazyLoadingHiddenLabel"
		 Me.LazyLoadingHiddenLabel.Size = New System.Drawing.Size(227, 13)
		 Me.LazyLoadingHiddenLabel.TabIndex = 4
		 Me.LazyLoadingHiddenLabel.Text = "hidden images above and under the scrollbars."
		 ' 
		 ' LazyLoadingLoadLable
		 ' 
		 Me.LazyLoadingLoadLable.AutoSize = True
		 Me.LazyLoadingLoadLable.Location = New System.Drawing.Point(30, 81)
		 Me.LazyLoadingLoadLable.Name = "LazyLoadingLoadLable"
		 Me.LazyLoadingLoadLable.Size = New System.Drawing.Size(31, 13)
		 Me.LazyLoadingLoadLable.TabIndex = 2
		 Me.LazyLoadingLoadLable.Text = "Load"
		 ' 
		 ' LazyLoadingDescriptionLabel
		 ' 
		 Me.LazyLoadingDescriptionLabel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.LazyLoadingDescriptionLabel.Location = New System.Drawing.Point(7, 24)
		 Me.LazyLoadingDescriptionLabel.Name = "LazyLoadingDescriptionLabel"
		 Me.LazyLoadingDescriptionLabel.Size = New System.Drawing.Size(469, 46)
		 Me.LazyLoadingDescriptionLabel.TabIndex = 1
       Me.LazyLoadingDescriptionLabel.Text = resources.GetString("LazyLoadingDescriptionLabel.Text")
		 ' 
		 ' UseCompressionCheckBox
		 ' 
		 Me.UseCompressionCheckBox.AutoSize = True
		 Me.UseCompressionCheckBox.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.UseCompressionCheckBox.ForeColor = System.Drawing.Color.White
		 Me.UseCompressionCheckBox.Location = New System.Drawing.Point(519, 149)
		 Me.UseCompressionCheckBox.Name = "UseCompressionCheckBox"
		 Me.UseCompressionCheckBox.Size = New System.Drawing.Size(378, 17)
		 Me.UseCompressionCheckBox.TabIndex = 14
		 Me.UseCompressionCheckBox.Text = "Use compression when storing DICOM files into DICOM Servers"
		 Me.UseCompressionCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' SaveSessionGroupBox
		 ' 
		 Me.SaveSessionGroupBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.SaveSessionGroupBox.Controls.Add(Me.PromptUserSaveSessionRadioButton)
		 Me.SaveSessionGroupBox.Controls.Add(Me.NeverSaveSessionRadioButton)
		 Me.SaveSessionGroupBox.Controls.Add(Me.AlwaysSaveSessionRadioButton)
		 Me.SaveSessionGroupBox.Controls.Add(Me.SaveUserSessionLabel)
		 Me.SaveSessionGroupBox.ForeColor = System.Drawing.Color.White
		 Me.SaveSessionGroupBox.Location = New System.Drawing.Point(510, 405)
		 Me.SaveSessionGroupBox.Name = "SaveSessionGroupBox"
		 Me.SaveSessionGroupBox.Size = New System.Drawing.Size(435, 124)
		 Me.SaveSessionGroupBox.TabIndex = 15
		 Me.SaveSessionGroupBox.TabStop = False
		 Me.SaveSessionGroupBox.Text = "Save User Session"
		 ' 
		 ' PromptUserSaveSessionRadioButton
		 ' 
		 Me.PromptUserSaveSessionRadioButton.AutoSize = True
		 Me.PromptUserSaveSessionRadioButton.Location = New System.Drawing.Point(18, 97)
		 Me.PromptUserSaveSessionRadioButton.Name = "PromptUserSaveSessionRadioButton"
		 Me.PromptUserSaveSessionRadioButton.Size = New System.Drawing.Size(83, 17)
		 Me.PromptUserSaveSessionRadioButton.TabIndex = 18
		 Me.PromptUserSaveSessionRadioButton.TabStop = True
		 Me.PromptUserSaveSessionRadioButton.Text = "Prompt User"
		 Me.PromptUserSaveSessionRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' NeverSaveSessionRadioButton
		 ' 
		 Me.NeverSaveSessionRadioButton.AutoSize = True
		 Me.NeverSaveSessionRadioButton.Location = New System.Drawing.Point(18, 73)
		 Me.NeverSaveSessionRadioButton.Name = "NeverSaveSessionRadioButton"
		 Me.NeverSaveSessionRadioButton.Size = New System.Drawing.Size(54, 17)
		 Me.NeverSaveSessionRadioButton.TabIndex = 17
		 Me.NeverSaveSessionRadioButton.TabStop = True
		 Me.NeverSaveSessionRadioButton.Text = "Never"
		 Me.NeverSaveSessionRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' AlwaysSaveSessionRadioButton
		 ' 
		 Me.AlwaysSaveSessionRadioButton.AutoSize = True
		 Me.AlwaysSaveSessionRadioButton.Location = New System.Drawing.Point(18, 49)
		 Me.AlwaysSaveSessionRadioButton.Name = "AlwaysSaveSessionRadioButton"
		 Me.AlwaysSaveSessionRadioButton.Size = New System.Drawing.Size(58, 17)
		 Me.AlwaysSaveSessionRadioButton.TabIndex = 16
		 Me.AlwaysSaveSessionRadioButton.TabStop = True
		 Me.AlwaysSaveSessionRadioButton.Text = "Always"
		 Me.AlwaysSaveSessionRadioButton.UseVisualStyleBackColor = True
		 ' 
		 ' SaveUserSessionLabel
		 ' 
		 Me.SaveUserSessionLabel.AutoSize = True
		 Me.SaveUserSessionLabel.Location = New System.Drawing.Point(10, 27)
		 Me.SaveUserSessionLabel.Name = "SaveUserSessionLabel"
		 Me.SaveUserSessionLabel.Size = New System.Drawing.Size(386, 13)
		 Me.SaveUserSessionLabel.TabIndex = 0
		 Me.SaveUserSessionLabel.Text = "When user exits the workstation, do you want to save the session configuration?"
		 ' 
		 ' ClientConfiguration
		 ' 
		 Me.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.Controls.Add(Me.SaveSessionGroupBox)
		 Me.Controls.Add(Me.UseCompressionCheckBox)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me.DicomRetrieveGroupBox)
		 Me.Controls.Add(Me.EnableDebugCheckBox)
		 Me.Controls.Add(Me.DicomClientGroupBox)
		 Me.Controls.Add(Me.CompressionGroupBox)
		 Me.Controls.Add(Me.DebugGroupBox)
		 Me.ForeColor = System.Drawing.Color.White
		 Me.Name = "ClientConfiguration"
		 Me.Size = New System.Drawing.Size(948, 534)
		 Me.CompressionGroupBox.ResumeLayout(False)
		 Me.CompressionGroupBox.PerformLayout()
		 Me.DebugGroupBox.ResumeLayout(False)
		 Me.DebugGroupBox.PerformLayout()
		 Me.DicomClientGroupBox.ResumeLayout(False)
		 Me.DicomClientGroupBox.PerformLayout()
		 Me.DicomRetrieveGroupBox.ResumeLayout(False)
		 Me.DicomRetrieveGroupBox.PerformLayout()
		 CType(Me.GenericErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ViewerOverlayTextSizeGroupBox.ResumeLayout(False)
		 Me.ViewerOverlayTextSizeGroupBox.PerformLayout()
		 CType(Me.FixedOverlayTextSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.LazyLoadingGroupBox.ResumeLayout(False)
		 Me.LazyLoadingGroupBox.PerformLayout()
		 Me.SaveSessionGroupBox.ResumeLayout(False)
		 Me.SaveSessionGroupBox.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Protected DicomClientGroupBox As System.Windows.Forms.GroupBox
	  Protected CompressionGroupBox As System.Windows.Forms.GroupBox
	  Protected LossyCompressionRadioButton As System.Windows.Forms.RadioButton
	  Protected LosslessCompressionRadioButton As System.Windows.Forms.RadioButton
	  Protected DebugGroupBox As System.Windows.Forms.GroupBox
	  Protected DebugLogFileButton As System.Windows.Forms.Button
	  Protected DebugLogFileNameTextBox As System.Windows.Forms.TextBox
	  Protected DebugLogFileCheckBox As System.Windows.Forms.CheckBox
	  Protected DisplayDetailDebugMsgCheckBox As System.Windows.Forms.CheckBox
	  Protected WorkstationHostaddressComboBox As System.Windows.Forms.ComboBox
	  Protected WorkstationIPLabel As System.Windows.Forms.Label
	  Protected DicomClientDescriptionLabel As System.Windows.Forms.Label
	  Protected WorstationAELabel As System.Windows.Forms.Label
	  Protected WorkstationAETextBox As System.Windows.Forms.TextBox
	  Protected EnableDebugCheckBox As System.Windows.Forms.CheckBox
	  Protected BrowseLogFileDialog As System.Windows.Forms.SaveFileDialog
	  Protected GenericErrorProvider As System.Windows.Forms.ErrorProvider
	  Protected DicomRetrieveGroupBox As System.Windows.Forms.GroupBox
	  Protected ContinueRetireveOnDuplicateCheckBox As System.Windows.Forms.CheckBox
	  Protected LazyLoadingGroupBox As System.Windows.Forms.GroupBox
	  Protected EnableLazyLoadingCheckBox As System.Windows.Forms.CheckBox
	  Protected LazyLoadingHiddenImagesMaskedTextBox As System.Windows.Forms.MaskedTextBox
	  Protected LazyLoadingHiddenLabel As System.Windows.Forms.Label
	  Protected LazyLoadingLoadLable As System.Windows.Forms.Label
	  Protected LazyLoadingDescriptionLabel As System.Windows.Forms.Label
	  Protected AutoSizeOverlayTextCheckBox As System.Windows.Forms.CheckBox
	  Protected FixedOverlayTextSizeLabel As System.Windows.Forms.Label
	  Protected groupBox1 As System.Windows.Forms.GroupBox
	  Protected ViewerOverlayTextSizeGroupBox As System.Windows.Forms.GroupBox
	  Protected FixedOverlayTextSizeNumericUpDown As System.Windows.Forms.NumericUpDown
	  Private FullScreenModeCheckBox As System.Windows.Forms.CheckBox
	  Protected WorkstationPortLabel As System.Windows.Forms.Label
	  Protected WorkstationPortMaskedTextBox As System.Windows.Forms.MaskedTextBox
	  Private MoveToWsServiceRadioButton As System.Windows.Forms.RadioButton
	  Private MoveToWsClientRadioButton As System.Windows.Forms.RadioButton
	  Protected label1 As System.Windows.Forms.Label
	  Protected WorkstationServiceAETitleTextBox As System.Windows.Forms.TextBox
	  Protected UseCompressionCheckBox As System.Windows.Forms.CheckBox
	  Private ForceToAllClientsCheckBox As System.Windows.Forms.CheckBox
	  Private SaveSessionGroupBox As System.Windows.Forms.GroupBox
	  Private PromptUserSaveSessionRadioButton As System.Windows.Forms.RadioButton
	  Private NeverSaveSessionRadioButton As System.Windows.Forms.RadioButton
	  Private AlwaysSaveSessionRadioButton As System.Windows.Forms.RadioButton
	  Private SaveUserSessionLabel As System.Windows.Forms.Label
	  Private DisplayOrientationButton As System.Windows.Forms.Button

   End Class
End Namespace
