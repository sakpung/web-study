Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
	Partial Public Class EditServiceDialog
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.AeTitleLabel = New System.Windows.Forms.Label
Me.ServerAETextBox = New System.Windows.Forms.TextBox
Me.DescriptionLabel = New System.Windows.Forms.Label
Me.ServerDescriptionTextBox = New System.Windows.Forms.TextBox
Me.IpAddressLabel = New System.Windows.Forms.Label
Me.PortLabel = New System.Windows.Forms.Label
Me.ClientTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown
Me.ClientTimeoutLabel = New System.Windows.Forms.Label
Me.MaxClientsLabel = New System.Windows.Forms.Label
Me.ServerAllowAnonymousCheckBox = New System.Windows.Forms.CheckBox
Me.OkButton = New System.Windows.Forms.Button
Me.CancelDialogButton = New System.Windows.Forms.Button
Me.ServerSecureCheckBox = New System.Windows.Forms.CheckBox
Me.ImplementationClassTextBox = New System.Windows.Forms.TextBox
Me.ImplementationClassLabel = New System.Windows.Forms.Label
Me.ImplementationVersionNameTextBox = New System.Windows.Forms.TextBox
Me.ImplementationVersionNameLabel = New System.Windows.Forms.Label
Me.TemporaryDirectoryTextBox = New System.Windows.Forms.TextBox
Me.TemporaryDirectoryLabel = New System.Windows.Forms.Label
Me.TempFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
Me.TempFolderBrowseButton = New System.Windows.Forms.Button
Me.ServerIpComboBox = New System.Windows.Forms.ComboBox
Me.ServerTabControl = New System.Windows.Forms.TabControl
Me.SettingsTabPage = New System.Windows.Forms.TabPage
Me.ServerMaxClientsMaskedNumeric = New System.Windows.Forms.NumericUpDown
Me.ServerPortMaskedNumeric = New System.Windows.Forms.NumericUpDown
Me.DisplayNameLabel = New System.Windows.Forms.Label
Me.DisplayNameTextBox = New System.Windows.Forms.TextBox
Me.AllowMultipleConnectionsChcekBox = New System.Windows.Forms.CheckBox
Me.AdvancedTabPage = New System.Windows.Forms.TabPage
Me.ServiceNameLabel = New System.Windows.Forms.Label
Me.ServiceNameTextBox = New System.Windows.Forms.TextBox
Me.StartModeComboBox = New System.Windows.Forms.ComboBox
Me.StartModeLabel = New System.Windows.Forms.Label
Me.SocketOptionsGroupBox = New System.Windows.Forms.GroupBox
Me.SendBufferNumericUpDown = New System.Windows.Forms.NumericUpDown
Me.ReceiveBufferNumericUpDown = New System.Windows.Forms.NumericUpDown
Me.SendBufferLabel = New System.Windows.Forms.Label
Me.ReceiveBufferLabel = New System.Windows.Forms.Label
Me.NoDelayCheckBox = New System.Windows.Forms.CheckBox
Me.MaxPduLengthMaskedTextBox = New System.Windows.Forms.MaskedTextBox
Me.MaxPduLabel = New System.Windows.Forms.Label
Me.TimeoutGroupBox = New System.Windows.Forms.GroupBox
Me.ReconnectTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown
Me.AddInTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown
Me.AddInTimeoutLabel = New System.Windows.Forms.Label
Me.ReconnectTimeoutLabel = New System.Windows.Forms.Label
Me.ErrorLabel = New System.Windows.Forms.Label
Me.RestartLabel = New System.Windows.Forms.Label
Me.ControlsErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
CType(Me.ClientTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
Me.ServerTabControl.SuspendLayout()
Me.SettingsTabPage.SuspendLayout()
CType(Me.ServerMaxClientsMaskedNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.ServerPortMaskedNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
Me.AdvancedTabPage.SuspendLayout()
Me.SocketOptionsGroupBox.SuspendLayout()
CType(Me.SendBufferNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.ReceiveBufferNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
Me.TimeoutGroupBox.SuspendLayout()
CType(Me.ReconnectTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.AddInTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.ControlsErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'AeTitleLabel
'
Me.AeTitleLabel.AutoSize = True
Me.AeTitleLabel.Location = New System.Drawing.Point(6, 10)
Me.AeTitleLabel.Name = "AeTitleLabel"
Me.AeTitleLabel.Size = New System.Drawing.Size(47, 13)
Me.AeTitleLabel.TabIndex = 0
Me.AeTitleLabel.Text = "AE Title:"
'
'ServerAETextBox
'
Me.ServerAETextBox.Location = New System.Drawing.Point(9, 26)
Me.ServerAETextBox.Name = "ServerAETextBox"
Me.ServerAETextBox.Size = New System.Drawing.Size(251, 20)
Me.ServerAETextBox.TabIndex = 1
'
'DescriptionLabel
'
Me.DescriptionLabel.AutoSize = True
Me.DescriptionLabel.Location = New System.Drawing.Point(6, 52)
Me.DescriptionLabel.Name = "DescriptionLabel"
Me.DescriptionLabel.Size = New System.Drawing.Size(63, 13)
Me.DescriptionLabel.TabIndex = 2
Me.DescriptionLabel.Text = "Description:"
'
'ServerDescriptionTextBox
'
Me.ServerDescriptionTextBox.Location = New System.Drawing.Point(9, 69)
Me.ServerDescriptionTextBox.Multiline = True
Me.ServerDescriptionTextBox.Name = "ServerDescriptionTextBox"
Me.ServerDescriptionTextBox.Size = New System.Drawing.Size(251, 102)
Me.ServerDescriptionTextBox.TabIndex = 3
'
'IpAddressLabel
'
Me.IpAddressLabel.AutoSize = True
Me.IpAddressLabel.Location = New System.Drawing.Point(6, 175)
Me.IpAddressLabel.Name = "IpAddressLabel"
Me.IpAddressLabel.Size = New System.Drawing.Size(61, 13)
Me.IpAddressLabel.TabIndex = 4
Me.IpAddressLabel.Text = "IP Address:"
'
'PortLabel
'
Me.PortLabel.AutoSize = True
Me.PortLabel.Location = New System.Drawing.Point(6, 221)
Me.PortLabel.Name = "PortLabel"
Me.PortLabel.Size = New System.Drawing.Size(29, 13)
Me.PortLabel.TabIndex = 6
Me.PortLabel.Text = "Port:"
'
'ClientTimeoutNumericUpDown
'
Me.ClientTimeoutNumericUpDown.Location = New System.Drawing.Point(9, 32)
Me.ClientTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.ClientTimeoutNumericUpDown.Name = "ClientTimeoutNumericUpDown"
Me.ClientTimeoutNumericUpDown.Size = New System.Drawing.Size(74, 20)
Me.ClientTimeoutNumericUpDown.TabIndex = 21
'
'ClientTimeoutLabel
'
Me.ClientTimeoutLabel.AutoSize = True
Me.ClientTimeoutLabel.Location = New System.Drawing.Point(6, 16)
Me.ClientTimeoutLabel.Name = "ClientTimeoutLabel"
Me.ClientTimeoutLabel.Size = New System.Drawing.Size(36, 13)
Me.ClientTimeoutLabel.TabIndex = 20
Me.ClientTimeoutLabel.Text = "Client:"
'
'MaxClientsLabel
'
Me.MaxClientsLabel.AutoSize = True
Me.MaxClientsLabel.Location = New System.Drawing.Point(137, 221)
Me.MaxClientsLabel.Name = "MaxClientsLabel"
Me.MaxClientsLabel.Size = New System.Drawing.Size(64, 13)
Me.MaxClientsLabel.TabIndex = 8
Me.MaxClientsLabel.Text = "Max Clients:"
'
'ServerAllowAnonymousCheckBox
'
Me.ServerAllowAnonymousCheckBox.AutoSize = True
Me.ServerAllowAnonymousCheckBox.Location = New System.Drawing.Point(277, 216)
Me.ServerAllowAnonymousCheckBox.Name = "ServerAllowAnonymousCheckBox"
Me.ServerAllowAnonymousCheckBox.Size = New System.Drawing.Size(109, 17)
Me.ServerAllowAnonymousCheckBox.TabIndex = 20
Me.ServerAllowAnonymousCheckBox.Text = "Allow Anonymous"
Me.ServerAllowAnonymousCheckBox.UseVisualStyleBackColor = True
'
'OkButton
'
Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
Me.OkButton.Location = New System.Drawing.Point(376, 328)
Me.OkButton.Name = "OkButton"
Me.OkButton.Size = New System.Drawing.Size(75, 23)
Me.OkButton.TabIndex = 3
Me.OkButton.Text = "OK"
Me.OkButton.UseVisualStyleBackColor = True
'
'CancelDialogButton
'
Me.CancelDialogButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.CancelDialogButton.Location = New System.Drawing.Point(457, 328)
Me.CancelDialogButton.Name = "CancelDialogButton"
Me.CancelDialogButton.Size = New System.Drawing.Size(75, 23)
Me.CancelDialogButton.TabIndex = 4
Me.CancelDialogButton.Text = "Cancel"
Me.CancelDialogButton.UseVisualStyleBackColor = True
'
'ServerSecureCheckBox
'
Me.ServerSecureCheckBox.AutoSize = True
Me.ServerSecureCheckBox.Location = New System.Drawing.Point(277, 195)
Me.ServerSecureCheckBox.Name = "ServerSecureCheckBox"
Me.ServerSecureCheckBox.Size = New System.Drawing.Size(60, 17)
Me.ServerSecureCheckBox.TabIndex = 19
Me.ServerSecureCheckBox.Text = "Secure"
Me.ServerSecureCheckBox.UseVisualStyleBackColor = True
'
'ImplementationClassTextBox
'
Me.ImplementationClassTextBox.Location = New System.Drawing.Point(277, 68)
Me.ImplementationClassTextBox.MaxLength = 64
Me.ImplementationClassTextBox.Name = "ImplementationClassTextBox"
Me.ImplementationClassTextBox.Size = New System.Drawing.Size(251, 20)
Me.ImplementationClassTextBox.TabIndex = 13
'
'ImplementationClassLabel
'
Me.ImplementationClassLabel.AutoSize = True
Me.ImplementationClassLabel.Location = New System.Drawing.Point(274, 52)
Me.ImplementationClassLabel.Name = "ImplementationClassLabel"
Me.ImplementationClassLabel.Size = New System.Drawing.Size(131, 13)
Me.ImplementationClassLabel.TabIndex = 12
Me.ImplementationClassLabel.Text = "Implementation Class UID:"
'
'ImplementationVersionNameTextBox
'
Me.ImplementationVersionNameTextBox.Location = New System.Drawing.Point(277, 107)
Me.ImplementationVersionNameTextBox.MaxLength = 16
Me.ImplementationVersionNameTextBox.Name = "ImplementationVersionNameTextBox"
Me.ImplementationVersionNameTextBox.Size = New System.Drawing.Size(251, 20)
Me.ImplementationVersionNameTextBox.TabIndex = 15
'
'ImplementationVersionNameLabel
'
Me.ImplementationVersionNameLabel.AutoSize = True
Me.ImplementationVersionNameLabel.Location = New System.Drawing.Point(274, 91)
Me.ImplementationVersionNameLabel.Name = "ImplementationVersionNameLabel"
Me.ImplementationVersionNameLabel.Size = New System.Drawing.Size(150, 13)
Me.ImplementationVersionNameLabel.TabIndex = 14
Me.ImplementationVersionNameLabel.Text = "Implementation Version Name:"
'
'TemporaryDirectoryTextBox
'
Me.TemporaryDirectoryTextBox.Location = New System.Drawing.Point(277, 146)
Me.TemporaryDirectoryTextBox.Name = "TemporaryDirectoryTextBox"
Me.TemporaryDirectoryTextBox.Size = New System.Drawing.Size(217, 20)
Me.TemporaryDirectoryTextBox.TabIndex = 17
'
'TemporaryDirectoryLabel
'
Me.TemporaryDirectoryLabel.AutoSize = True
Me.TemporaryDirectoryLabel.Location = New System.Drawing.Point(274, 130)
Me.TemporaryDirectoryLabel.Name = "TemporaryDirectoryLabel"
Me.TemporaryDirectoryLabel.Size = New System.Drawing.Size(105, 13)
Me.TemporaryDirectoryLabel.TabIndex = 16
Me.TemporaryDirectoryLabel.Text = "Temporary Directory:"
'
'TempFolderBrowseButton
'
Me.TempFolderBrowseButton.Image = Global.Resources.folder
Me.TempFolderBrowseButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
Me.TempFolderBrowseButton.Location = New System.Drawing.Point(495, 143)
Me.TempFolderBrowseButton.Name = "TempFolderBrowseButton"
Me.TempFolderBrowseButton.Size = New System.Drawing.Size(32, 24)
Me.TempFolderBrowseButton.TabIndex = 18
Me.TempFolderBrowseButton.UseVisualStyleBackColor = True
'
'ServerIpComboBox
'
Me.ServerIpComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.ServerIpComboBox.FormattingEnabled = True
Me.ServerIpComboBox.Location = New System.Drawing.Point(9, 191)
Me.ServerIpComboBox.Name = "ServerIpComboBox"
Me.ServerIpComboBox.Size = New System.Drawing.Size(251, 21)
Me.ServerIpComboBox.TabIndex = 5
'
'ServerTabControl
'
Me.ServerTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.ServerTabControl.Controls.Add(Me.SettingsTabPage)
Me.ServerTabControl.Controls.Add(Me.AdvancedTabPage)
Me.ServerTabControl.Location = New System.Drawing.Point(0, 0)
Me.ServerTabControl.Name = "ServerTabControl"
Me.ServerTabControl.SelectedIndex = 0
Me.ServerTabControl.Size = New System.Drawing.Size(542, 294)
Me.ServerTabControl.TabIndex = 0
'
'SettingsTabPage
'
Me.SettingsTabPage.Controls.Add(Me.ServerMaxClientsMaskedNumeric)
Me.SettingsTabPage.Controls.Add(Me.ServerPortMaskedNumeric)
Me.SettingsTabPage.Controls.Add(Me.DisplayNameLabel)
Me.SettingsTabPage.Controls.Add(Me.DisplayNameTextBox)
Me.SettingsTabPage.Controls.Add(Me.AllowMultipleConnectionsChcekBox)
Me.SettingsTabPage.Controls.Add(Me.TemporaryDirectoryLabel)
Me.SettingsTabPage.Controls.Add(Me.ServerIpComboBox)
Me.SettingsTabPage.Controls.Add(Me.AeTitleLabel)
Me.SettingsTabPage.Controls.Add(Me.TempFolderBrowseButton)
Me.SettingsTabPage.Controls.Add(Me.ServerAETextBox)
Me.SettingsTabPage.Controls.Add(Me.DescriptionLabel)
Me.SettingsTabPage.Controls.Add(Me.ServerDescriptionTextBox)
Me.SettingsTabPage.Controls.Add(Me.IpAddressLabel)
Me.SettingsTabPage.Controls.Add(Me.PortLabel)
Me.SettingsTabPage.Controls.Add(Me.TemporaryDirectoryTextBox)
Me.SettingsTabPage.Controls.Add(Me.MaxClientsLabel)
Me.SettingsTabPage.Controls.Add(Me.ImplementationVersionNameTextBox)
Me.SettingsTabPage.Controls.Add(Me.ImplementationVersionNameLabel)
Me.SettingsTabPage.Controls.Add(Me.ServerAllowAnonymousCheckBox)
Me.SettingsTabPage.Controls.Add(Me.ImplementationClassTextBox)
Me.SettingsTabPage.Controls.Add(Me.ImplementationClassLabel)
Me.SettingsTabPage.Controls.Add(Me.ServerSecureCheckBox)
Me.SettingsTabPage.Location = New System.Drawing.Point(4, 22)
Me.SettingsTabPage.Name = "SettingsTabPage"
Me.SettingsTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.SettingsTabPage.Size = New System.Drawing.Size(534, 268)
Me.SettingsTabPage.TabIndex = 0
Me.SettingsTabPage.Text = "Settings"
Me.SettingsTabPage.UseVisualStyleBackColor = True
'
'ServerMaxClientsMaskedNumeric
'
Me.ServerMaxClientsMaskedNumeric.Location = New System.Drawing.Point(140, 237)
Me.ServerMaxClientsMaskedNumeric.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
Me.ServerMaxClientsMaskedNumeric.Name = "ServerMaxClientsMaskedNumeric"
Me.ServerMaxClientsMaskedNumeric.Size = New System.Drawing.Size(120, 20)
Me.ServerMaxClientsMaskedNumeric.TabIndex = 9
Me.ServerMaxClientsMaskedNumeric.Value = New Decimal(New Integer() {1, 0, 0, 0})
'
'ServerPortMaskedNumeric
'
Me.ServerPortMaskedNumeric.Location = New System.Drawing.Point(9, 237)
Me.ServerPortMaskedNumeric.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
Me.ServerPortMaskedNumeric.Name = "ServerPortMaskedNumeric"
Me.ServerPortMaskedNumeric.Size = New System.Drawing.Size(120, 20)
Me.ServerPortMaskedNumeric.TabIndex = 7
Me.ServerPortMaskedNumeric.Value = New Decimal(New Integer() {1, 0, 0, 0})
'
'DisplayNameLabel
'
Me.DisplayNameLabel.AutoSize = True
Me.DisplayNameLabel.Location = New System.Drawing.Point(274, 10)
Me.DisplayNameLabel.Name = "DisplayNameLabel"
Me.DisplayNameLabel.Size = New System.Drawing.Size(114, 13)
Me.DisplayNameLabel.TabIndex = 10
Me.DisplayNameLabel.Text = "Service Display Name:"
'
'DisplayNameTextBox
'
Me.DisplayNameTextBox.Location = New System.Drawing.Point(277, 26)
Me.DisplayNameTextBox.Name = "DisplayNameTextBox"
Me.DisplayNameTextBox.Size = New System.Drawing.Size(251, 20)
Me.DisplayNameTextBox.TabIndex = 11
'
'AllowMultipleConnectionsChcekBox
'
Me.AllowMultipleConnectionsChcekBox.AutoSize = True
Me.AllowMultipleConnectionsChcekBox.Location = New System.Drawing.Point(277, 237)
Me.AllowMultipleConnectionsChcekBox.Name = "AllowMultipleConnectionsChcekBox"
Me.AllowMultipleConnectionsChcekBox.Size = New System.Drawing.Size(124, 17)
Me.AllowMultipleConnectionsChcekBox.TabIndex = 21
Me.AllowMultipleConnectionsChcekBox.Text = "Multiple Connections"
Me.AllowMultipleConnectionsChcekBox.UseVisualStyleBackColor = True
'
'AdvancedTabPage
'
Me.AdvancedTabPage.Controls.Add(Me.ServiceNameLabel)
Me.AdvancedTabPage.Controls.Add(Me.ServiceNameTextBox)
Me.AdvancedTabPage.Controls.Add(Me.StartModeComboBox)
Me.AdvancedTabPage.Controls.Add(Me.StartModeLabel)
Me.AdvancedTabPage.Controls.Add(Me.SocketOptionsGroupBox)
Me.AdvancedTabPage.Controls.Add(Me.MaxPduLengthMaskedTextBox)
Me.AdvancedTabPage.Controls.Add(Me.MaxPduLabel)
Me.AdvancedTabPage.Controls.Add(Me.TimeoutGroupBox)
Me.AdvancedTabPage.Location = New System.Drawing.Point(4, 22)
Me.AdvancedTabPage.Name = "AdvancedTabPage"
Me.AdvancedTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.AdvancedTabPage.Size = New System.Drawing.Size(534, 268)
Me.AdvancedTabPage.TabIndex = 1
Me.AdvancedTabPage.Text = "Advanced"
Me.AdvancedTabPage.UseVisualStyleBackColor = True
'
'ServiceNameLabel
'
Me.ServiceNameLabel.AutoSize = True
Me.ServiceNameLabel.Location = New System.Drawing.Point(9, 12)
Me.ServiceNameLabel.Name = "ServiceNameLabel"
Me.ServiceNameLabel.Size = New System.Drawing.Size(77, 13)
Me.ServiceNameLabel.TabIndex = 5
Me.ServiceNameLabel.Text = "Service Name:"
'
'ServiceNameTextBox
'
Me.ServiceNameTextBox.Enabled = False
Me.ServiceNameTextBox.Location = New System.Drawing.Point(8, 30)
Me.ServiceNameTextBox.Name = "ServiceNameTextBox"
Me.ServiceNameTextBox.Size = New System.Drawing.Size(248, 20)
Me.ServiceNameTextBox.TabIndex = 6
'
'StartModeComboBox
'
Me.StartModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.StartModeComboBox.FormattingEnabled = True
Me.StartModeComboBox.Items.AddRange(New Object() {"Automatic", "Manual", "Disabled"})
Me.StartModeComboBox.Location = New System.Drawing.Point(12, 195)
Me.StartModeComboBox.Name = "StartModeComboBox"
Me.StartModeComboBox.Size = New System.Drawing.Size(160, 21)
Me.StartModeComboBox.TabIndex = 31
'
'StartModeLabel
'
Me.StartModeLabel.AutoSize = True
Me.StartModeLabel.Location = New System.Drawing.Point(9, 174)
Me.StartModeLabel.Name = "StartModeLabel"
Me.StartModeLabel.Size = New System.Drawing.Size(62, 13)
Me.StartModeLabel.TabIndex = 30
Me.StartModeLabel.Text = "Start Mode:"
'
'SocketOptionsGroupBox
'
Me.SocketOptionsGroupBox.Controls.Add(Me.SendBufferNumericUpDown)
Me.SocketOptionsGroupBox.Controls.Add(Me.ReceiveBufferNumericUpDown)
Me.SocketOptionsGroupBox.Controls.Add(Me.SendBufferLabel)
Me.SocketOptionsGroupBox.Controls.Add(Me.ReceiveBufferLabel)
Me.SocketOptionsGroupBox.Controls.Add(Me.NoDelayCheckBox)
Me.SocketOptionsGroupBox.Location = New System.Drawing.Point(277, 101)
Me.SocketOptionsGroupBox.Name = "SocketOptionsGroupBox"
Me.SocketOptionsGroupBox.Size = New System.Drawing.Size(251, 66)
Me.SocketOptionsGroupBox.TabIndex = 29
Me.SocketOptionsGroupBox.TabStop = False
Me.SocketOptionsGroupBox.Text = "Socket Options"
'
'SendBufferNumericUpDown
'
Me.SendBufferNumericUpDown.Location = New System.Drawing.Point(165, 31)
Me.SendBufferNumericUpDown.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
Me.SendBufferNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.SendBufferNumericUpDown.Name = "SendBufferNumericUpDown"
Me.SendBufferNumericUpDown.Size = New System.Drawing.Size(76, 20)
Me.SendBufferNumericUpDown.TabIndex = 21
Me.SendBufferNumericUpDown.Value = New Decimal(New Integer() {29696, 0, 0, 0})
'
'ReceiveBufferNumericUpDown
'
Me.ReceiveBufferNumericUpDown.Location = New System.Drawing.Point(84, 31)
Me.ReceiveBufferNumericUpDown.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
Me.ReceiveBufferNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.ReceiveBufferNumericUpDown.Name = "ReceiveBufferNumericUpDown"
Me.ReceiveBufferNumericUpDown.Size = New System.Drawing.Size(76, 20)
Me.ReceiveBufferNumericUpDown.TabIndex = 20
Me.ReceiveBufferNumericUpDown.Value = New Decimal(New Integer() {29696, 0, 0, 0})
'
'SendBufferLabel
'
Me.SendBufferLabel.AutoSize = True
Me.SendBufferLabel.Location = New System.Drawing.Point(162, 15)
Me.SendBufferLabel.Name = "SendBufferLabel"
Me.SendBufferLabel.Size = New System.Drawing.Size(66, 13)
Me.SendBufferLabel.TabIndex = 18
Me.SendBufferLabel.Text = "Send Buffer:"
'
'ReceiveBufferLabel
'
Me.ReceiveBufferLabel.AutoSize = True
Me.ReceiveBufferLabel.Location = New System.Drawing.Point(80, 15)
Me.ReceiveBufferLabel.Name = "ReceiveBufferLabel"
Me.ReceiveBufferLabel.Size = New System.Drawing.Size(81, 13)
Me.ReceiveBufferLabel.TabIndex = 16
Me.ReceiveBufferLabel.Text = "Receive Buffer:"
'
'NoDelayCheckBox
'
Me.NoDelayCheckBox.AutoSize = True
Me.NoDelayCheckBox.Location = New System.Drawing.Point(7, 34)
Me.NoDelayCheckBox.Name = "NoDelayCheckBox"
Me.NoDelayCheckBox.Size = New System.Drawing.Size(70, 17)
Me.NoDelayCheckBox.TabIndex = 0
Me.NoDelayCheckBox.Text = "No Delay"
Me.NoDelayCheckBox.UseVisualStyleBackColor = True
'
'MaxPduLengthMaskedTextBox
'
Me.MaxPduLengthMaskedTextBox.HidePromptOnLeave = True
Me.MaxPduLengthMaskedTextBox.Location = New System.Drawing.Point(277, 74)
Me.MaxPduLengthMaskedTextBox.Mask = "#########"
Me.MaxPduLengthMaskedTextBox.Name = "MaxPduLengthMaskedTextBox"
Me.MaxPduLengthMaskedTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
Me.MaxPduLengthMaskedTextBox.Size = New System.Drawing.Size(251, 20)
Me.MaxPduLengthMaskedTextBox.TabIndex = 28
Me.MaxPduLengthMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
'
'MaxPduLabel
'
Me.MaxPduLabel.AutoSize = True
Me.MaxPduLabel.Location = New System.Drawing.Point(274, 58)
Me.MaxPduLabel.Name = "MaxPduLabel"
Me.MaxPduLabel.Size = New System.Drawing.Size(92, 13)
Me.MaxPduLabel.TabIndex = 27
Me.MaxPduLabel.Text = "PDU Max Length:"
'
'TimeoutGroupBox
'
Me.TimeoutGroupBox.Controls.Add(Me.ReconnectTimeoutNumericUpDown)
Me.TimeoutGroupBox.Controls.Add(Me.AddInTimeoutNumericUpDown)
Me.TimeoutGroupBox.Controls.Add(Me.ClientTimeoutLabel)
Me.TimeoutGroupBox.Controls.Add(Me.AddInTimeoutLabel)
Me.TimeoutGroupBox.Controls.Add(Me.ClientTimeoutNumericUpDown)
Me.TimeoutGroupBox.Controls.Add(Me.ReconnectTimeoutLabel)
Me.TimeoutGroupBox.Location = New System.Drawing.Point(9, 101)
Me.TimeoutGroupBox.Name = "TimeoutGroupBox"
Me.TimeoutGroupBox.Size = New System.Drawing.Size(251, 66)
Me.TimeoutGroupBox.TabIndex = 26
Me.TimeoutGroupBox.TabStop = False
Me.TimeoutGroupBox.Text = "Timeouts (Seconds)"
'
'ReconnectTimeoutNumericUpDown
'
Me.ReconnectTimeoutNumericUpDown.Location = New System.Drawing.Point(89, 32)
Me.ReconnectTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.ReconnectTimeoutNumericUpDown.Name = "ReconnectTimeoutNumericUpDown"
Me.ReconnectTimeoutNumericUpDown.Size = New System.Drawing.Size(74, 20)
Me.ReconnectTimeoutNumericUpDown.TabIndex = 23
'
'AddInTimeoutNumericUpDown
'
Me.AddInTimeoutNumericUpDown.Location = New System.Drawing.Point(169, 32)
Me.AddInTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.AddInTimeoutNumericUpDown.Name = "AddInTimeoutNumericUpDown"
Me.AddInTimeoutNumericUpDown.Size = New System.Drawing.Size(74, 20)
Me.AddInTimeoutNumericUpDown.TabIndex = 25
'
'AddInTimeoutLabel
'
Me.AddInTimeoutLabel.AutoSize = True
Me.AddInTimeoutLabel.Location = New System.Drawing.Point(166, 16)
Me.AddInTimeoutLabel.Name = "AddInTimeoutLabel"
Me.AddInTimeoutLabel.Size = New System.Drawing.Size(38, 13)
Me.AddInTimeoutLabel.TabIndex = 24
Me.AddInTimeoutLabel.Text = "AddIn:"
'
'ReconnectTimeoutLabel
'
Me.ReconnectTimeoutLabel.AutoSize = True
Me.ReconnectTimeoutLabel.Location = New System.Drawing.Point(86, 16)
Me.ReconnectTimeoutLabel.Name = "ReconnectTimeoutLabel"
Me.ReconnectTimeoutLabel.Size = New System.Drawing.Size(63, 13)
Me.ReconnectTimeoutLabel.TabIndex = 22
Me.ReconnectTimeoutLabel.Text = "Reconnect:"
'
'ErrorLabel
'
Me.ErrorLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.ErrorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ErrorLabel.ForeColor = System.Drawing.Color.Red
Me.ErrorLabel.Location = New System.Drawing.Point(4, 337)
Me.ErrorLabel.Name = "ErrorLabel"
Me.ErrorLabel.Size = New System.Drawing.Size(366, 14)
Me.ErrorLabel.TabIndex = 2
Me.ErrorLabel.Text = "Error"
'
'RestartLabel
'
Me.RestartLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.RestartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.RestartLabel.ForeColor = System.Drawing.Color.Red
Me.RestartLabel.Location = New System.Drawing.Point(4, 308)
Me.RestartLabel.Name = "RestartLabel"
Me.RestartLabel.Size = New System.Drawing.Size(366, 14)
Me.RestartLabel.TabIndex = 1
Me.RestartLabel.Text = "Error"
'
'ControlsErrorProvider
'
Me.ControlsErrorProvider.ContainerControl = Me
'
'EditServiceDialog
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.CancelDialogButton
Me.ClientSize = New System.Drawing.Size(542, 356)
Me.Controls.Add(Me.RestartLabel)
Me.Controls.Add(Me.ErrorLabel)
Me.Controls.Add(Me.ServerTabControl)
Me.Controls.Add(Me.CancelDialogButton)
Me.Controls.Add(Me.OkButton)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "EditServiceDialog"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Add New Server"
CType(Me.ClientTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
Me.ServerTabControl.ResumeLayout(False)
Me.SettingsTabPage.ResumeLayout(False)
Me.SettingsTabPage.PerformLayout()
CType(Me.ServerMaxClientsMaskedNumeric, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.ServerPortMaskedNumeric, System.ComponentModel.ISupportInitialize).EndInit()
Me.AdvancedTabPage.ResumeLayout(False)
Me.AdvancedTabPage.PerformLayout()
Me.SocketOptionsGroupBox.ResumeLayout(False)
Me.SocketOptionsGroupBox.PerformLayout()
CType(Me.SendBufferNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.ReceiveBufferNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
Me.TimeoutGroupBox.ResumeLayout(False)
Me.TimeoutGroupBox.PerformLayout()
CType(Me.ReconnectTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.AddInTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.ControlsErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

		#End Region

		Protected AeTitleLabel As System.Windows.Forms.Label
		Protected WithEvents ServerAETextBox As System.Windows.Forms.TextBox
		Protected DescriptionLabel As System.Windows.Forms.Label
		Protected ServerDescriptionTextBox As System.Windows.Forms.TextBox
		Protected IpAddressLabel As System.Windows.Forms.Label
		Protected PortLabel As System.Windows.Forms.Label
		Protected ClientTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
		Protected ClientTimeoutLabel As System.Windows.Forms.Label
		Protected MaxClientsLabel As System.Windows.Forms.Label
		Protected ServerAllowAnonymousCheckBox As System.Windows.Forms.CheckBox
		Protected OkButton As System.Windows.Forms.Button
		Protected ServerSecureCheckBox As System.Windows.Forms.CheckBox
		Protected ImplementationClassTextBox As System.Windows.Forms.TextBox
		Protected ImplementationClassLabel As System.Windows.Forms.Label
		Protected ImplementationVersionNameTextBox As System.Windows.Forms.TextBox
		Protected ImplementationVersionNameLabel As System.Windows.Forms.Label
		Protected TemporaryDirectoryLabel As System.Windows.Forms.Label
		Protected WithEvents TemporaryDirectoryTextBox As System.Windows.Forms.TextBox
      Protected WithEvents TempFolderBrowseButton As System.Windows.Forms.Button
		Protected TempFolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
		Protected ServerIpComboBox As System.Windows.Forms.ComboBox
		Protected ServerTabControl As System.Windows.Forms.TabControl
		Protected SettingsTabPage As System.Windows.Forms.TabPage
		Protected AdvancedTabPage As System.Windows.Forms.TabPage
		Protected ReconnectTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
		Protected ReconnectTimeoutLabel As System.Windows.Forms.Label
		Protected AddInTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
		Protected AddInTimeoutLabel As System.Windows.Forms.Label
		Protected TimeoutGroupBox As System.Windows.Forms.GroupBox
		Protected MaxPduLabel As System.Windows.Forms.Label
		Protected SocketOptionsGroupBox As System.Windows.Forms.GroupBox
		Protected MaxPduLengthMaskedTextBox As System.Windows.Forms.MaskedTextBox
		Protected SendBufferLabel As System.Windows.Forms.Label
		Protected ReceiveBufferLabel As System.Windows.Forms.Label
		Protected NoDelayCheckBox As System.Windows.Forms.CheckBox
		Protected StartModeComboBox As System.Windows.Forms.ComboBox
		Protected StartModeLabel As System.Windows.Forms.Label
		Protected ErrorLabel As System.Windows.Forms.Label
		Protected CancelDialogButton As System.Windows.Forms.Button
		Protected AllowMultipleConnectionsChcekBox As System.Windows.Forms.CheckBox
		Protected RestartLabel As System.Windows.Forms.Label
		Protected SendBufferNumericUpDown As System.Windows.Forms.NumericUpDown
		Protected ReceiveBufferNumericUpDown As System.Windows.Forms.NumericUpDown
		Protected ControlsErrorProvider As System.Windows.Forms.ErrorProvider
		Private ServiceNameLabel As System.Windows.Forms.Label
		Private ServiceNameTextBox As System.Windows.Forms.TextBox
		Protected DisplayNameLabel As System.Windows.Forms.Label
		Protected WithEvents DisplayNameTextBox As System.Windows.Forms.TextBox
		Private ServerPortMaskedNumeric As System.Windows.Forms.NumericUpDown
		Private ServerMaxClientsMaskedNumeric As System.Windows.Forms.NumericUpDown

	End Class
End Namespace