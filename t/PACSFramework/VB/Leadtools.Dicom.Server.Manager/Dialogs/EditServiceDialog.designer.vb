Namespace Leadtools.Dicom.Server.Manager.Dialogs
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
Me.labelAeTitle = New System.Windows.Forms.Label
Me.ServerAE = New System.Windows.Forms.TextBox
Me.labelDescription = New System.Windows.Forms.Label
Me.ServerDescription = New System.Windows.Forms.TextBox
Me.labelIpAddress = New System.Windows.Forms.Label
Me.labelPort = New System.Windows.Forms.Label
Me.ClientTimeout = New System.Windows.Forms.NumericUpDown
Me.labelClientTimeout = New System.Windows.Forms.Label
Me.labelMaxClients = New System.Windows.Forms.Label
Me.ServerAllowAnonymous = New System.Windows.Forms.CheckBox
Me.buttonOk = New System.Windows.Forms.Button
Me.buttonCancel = New System.Windows.Forms.Button
Me.ImplementationClass = New System.Windows.Forms.TextBox
Me.labelImplementationClass = New System.Windows.Forms.Label
Me.ImplementationVersionName = New System.Windows.Forms.TextBox
Me.labelImplementationVersionName = New System.Windows.Forms.Label
Me.TemporaryDirectory = New System.Windows.Forms.TextBox
Me.labelTemporaryDirectory = New System.Windows.Forms.Label
Me.ServerPort = New System.Windows.Forms.MaskedTextBox
Me.ServerMaxClients = New System.Windows.Forms.MaskedTextBox
Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
Me.buttonFolderBrowse = New System.Windows.Forms.Button
Me.tabControl1 = New System.Windows.Forms.TabControl
Me.tabPageSettings = New System.Windows.Forms.TabPage
Me.groupBoxIpType = New System.Windows.Forms.GroupBox
Me.radioButtonIpv4Ipv6 = New System.Windows.Forms.RadioButton
Me.radioButtonIpv6 = New System.Windows.Forms.RadioButton
Me.radioButtonIpv4 = New System.Windows.Forms.RadioButton
Me.ServerIp = New System.Windows.Forms.ComboBox
Me.AllowMultipleConnections = New System.Windows.Forms.CheckBox
Me.ServerSecure = New System.Windows.Forms.CheckBox
Me.tabPageAdvanced = New System.Windows.Forms.TabPage
Me.numericUpDownPipes = New System.Windows.Forms.NumericUpDown
Me.labelPipes = New System.Windows.Forms.Label
Me.checkBoxImageCopy = New System.Windows.Forms.CheckBox
Me.StartMode = New System.Windows.Forms.ComboBox
Me.labelStartMode = New System.Windows.Forms.Label
Me.groupBoxSocketOptions = New System.Windows.Forms.GroupBox
Me.SendBuffer = New System.Windows.Forms.NumericUpDown
Me.ReceiveBuffer = New System.Windows.Forms.NumericUpDown
Me.labelSendBuffer = New System.Windows.Forms.Label
Me.labelReceiveBuffer = New System.Windows.Forms.Label
Me.NoDelay = New System.Windows.Forms.CheckBox
Me.MaxPduLength = New System.Windows.Forms.MaskedTextBox
Me.labelMaxPdu = New System.Windows.Forms.Label
Me.groupBoxTimeout = New System.Windows.Forms.GroupBox
Me.ReconnectTimeout = New System.Windows.Forms.NumericUpDown
Me.AddInTimeout = New System.Windows.Forms.NumericUpDown
Me.labelAddInTimeout = New System.Windows.Forms.Label
Me.labelReconnectTimeout = New System.Windows.Forms.Label
Me.labelDisplayName = New System.Windows.Forms.Label
Me.DisplayName = New System.Windows.Forms.TextBox
Me.labelError = New System.Windows.Forms.Label
Me.labelRestart = New System.Windows.Forms.Label
CType(Me.ClientTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
Me.tabControl1.SuspendLayout()
Me.tabPageSettings.SuspendLayout()
Me.groupBoxIpType.SuspendLayout()
Me.tabPageAdvanced.SuspendLayout()
CType(Me.numericUpDownPipes, System.ComponentModel.ISupportInitialize).BeginInit()
Me.groupBoxSocketOptions.SuspendLayout()
CType(Me.SendBuffer, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.ReceiveBuffer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.groupBoxTimeout.SuspendLayout()
CType(Me.ReconnectTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.AddInTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'labelAeTitle
'
Me.labelAeTitle.AutoSize = True
Me.labelAeTitle.Location = New System.Drawing.Point(6, 13)
Me.labelAeTitle.Name = "labelAeTitle"
Me.labelAeTitle.Size = New System.Drawing.Size(47, 13)
Me.labelAeTitle.TabIndex = 0
Me.labelAeTitle.Text = "AE Title:"
'
'ServerAE
'
Me.ServerAE.Location = New System.Drawing.Point(9, 29)
Me.ServerAE.Name = "ServerAE"
Me.ServerAE.Size = New System.Drawing.Size(251, 20)
Me.ServerAE.TabIndex = 1
'
'labelDescription
'
Me.labelDescription.AutoSize = True
Me.labelDescription.Location = New System.Drawing.Point(6, 52)
Me.labelDescription.Name = "labelDescription"
Me.labelDescription.Size = New System.Drawing.Size(63, 13)
Me.labelDescription.TabIndex = 2
Me.labelDescription.Text = "Description:"
'
'ServerDescription
'
Me.ServerDescription.Location = New System.Drawing.Point(9, 67)
Me.ServerDescription.Multiline = True
Me.ServerDescription.Name = "ServerDescription"
Me.ServerDescription.Size = New System.Drawing.Size(251, 60)
Me.ServerDescription.TabIndex = 3
'
'labelIpAddress
'
Me.labelIpAddress.AutoSize = True
Me.labelIpAddress.Location = New System.Drawing.Point(6, 130)
Me.labelIpAddress.Name = "labelIpAddress"
Me.labelIpAddress.Size = New System.Drawing.Size(61, 13)
Me.labelIpAddress.TabIndex = 4
Me.labelIpAddress.Text = "IP Address:"
'
'labelPort
'
Me.labelPort.AutoSize = True
Me.labelPort.Location = New System.Drawing.Point(6, 272)
Me.labelPort.Name = "labelPort"
Me.labelPort.Size = New System.Drawing.Size(29, 13)
Me.labelPort.TabIndex = 6
Me.labelPort.Text = "Port:"
'
'ClientTimeout
'
Me.ClientTimeout.Location = New System.Drawing.Point(9, 32)
Me.ClientTimeout.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.ClientTimeout.Name = "ClientTimeout"
Me.ClientTimeout.Size = New System.Drawing.Size(74, 20)
Me.ClientTimeout.TabIndex = 21
'
'labelClientTimeout
'
Me.labelClientTimeout.AutoSize = True
Me.labelClientTimeout.Location = New System.Drawing.Point(6, 16)
Me.labelClientTimeout.Name = "labelClientTimeout"
Me.labelClientTimeout.Size = New System.Drawing.Size(36, 13)
Me.labelClientTimeout.TabIndex = 20
Me.labelClientTimeout.Text = "Client:"
'
'labelMaxClients
'
Me.labelMaxClients.AutoSize = True
Me.labelMaxClients.Location = New System.Drawing.Point(149, 272)
Me.labelMaxClients.Name = "labelMaxClients"
Me.labelMaxClients.Size = New System.Drawing.Size(64, 13)
Me.labelMaxClients.TabIndex = 8
Me.labelMaxClients.Text = "Max Clients:"
'
'ServerAllowAnonymous
'
Me.ServerAllowAnonymous.AutoSize = True
Me.ServerAllowAnonymous.Location = New System.Drawing.Point(277, 170)
Me.ServerAllowAnonymous.Name = "ServerAllowAnonymous"
Me.ServerAllowAnonymous.Size = New System.Drawing.Size(109, 17)
Me.ServerAllowAnonymous.TabIndex = 18
Me.ServerAllowAnonymous.Text = "Allow Anonymous"
Me.ServerAllowAnonymous.UseVisualStyleBackColor = True
'
'buttonOk
'
Me.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK
Me.buttonOk.Location = New System.Drawing.Point(376, 380)
Me.buttonOk.Name = "buttonOk"
Me.buttonOk.Size = New System.Drawing.Size(75, 23)
Me.buttonOk.TabIndex = 3
Me.buttonOk.Text = "OK"
Me.buttonOk.UseVisualStyleBackColor = True
'
'buttonCancel
'
Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.buttonCancel.Location = New System.Drawing.Point(457, 380)
Me.buttonCancel.Name = "buttonCancel"
Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
Me.buttonCancel.TabIndex = 4
Me.buttonCancel.Text = "Cancel"
Me.buttonCancel.UseVisualStyleBackColor = True
'
'ImplementationClass
'
Me.ImplementationClass.Location = New System.Drawing.Point(277, 29)
Me.ImplementationClass.MaxLength = 64
Me.ImplementationClass.Name = "ImplementationClass"
Me.ImplementationClass.Size = New System.Drawing.Size(251, 20)
Me.ImplementationClass.TabIndex = 11
'
'labelImplementationClass
'
Me.labelImplementationClass.AutoSize = True
Me.labelImplementationClass.Location = New System.Drawing.Point(274, 13)
Me.labelImplementationClass.Name = "labelImplementationClass"
Me.labelImplementationClass.Size = New System.Drawing.Size(131, 13)
Me.labelImplementationClass.TabIndex = 10
Me.labelImplementationClass.Text = "Implementation Class UID:"
'
'ImplementationVersionName
'
Me.ImplementationVersionName.Location = New System.Drawing.Point(277, 68)
Me.ImplementationVersionName.MaxLength = 16
Me.ImplementationVersionName.Name = "ImplementationVersionName"
Me.ImplementationVersionName.Size = New System.Drawing.Size(251, 20)
Me.ImplementationVersionName.TabIndex = 13
'
'labelImplementationVersionName
'
Me.labelImplementationVersionName.AutoSize = True
Me.labelImplementationVersionName.Location = New System.Drawing.Point(274, 52)
Me.labelImplementationVersionName.Name = "labelImplementationVersionName"
Me.labelImplementationVersionName.Size = New System.Drawing.Size(150, 13)
Me.labelImplementationVersionName.TabIndex = 12
Me.labelImplementationVersionName.Text = "Implementation Version Name:"
'
'TemporaryDirectory
'
Me.TemporaryDirectory.Location = New System.Drawing.Point(277, 107)
Me.TemporaryDirectory.Name = "TemporaryDirectory"
Me.TemporaryDirectory.Size = New System.Drawing.Size(217, 20)
Me.TemporaryDirectory.TabIndex = 15
'
'labelTemporaryDirectory
'
Me.labelTemporaryDirectory.AutoSize = True
Me.labelTemporaryDirectory.Location = New System.Drawing.Point(274, 91)
Me.labelTemporaryDirectory.Name = "labelTemporaryDirectory"
Me.labelTemporaryDirectory.Size = New System.Drawing.Size(105, 13)
Me.labelTemporaryDirectory.TabIndex = 14
Me.labelTemporaryDirectory.Text = "Temporary Directory:"
'
'ServerPort
'
Me.ServerPort.HidePromptOnLeave = True
Me.ServerPort.Location = New System.Drawing.Point(9, 288)
Me.ServerPort.Mask = "00000"
Me.ServerPort.Name = "ServerPort"
Me.ServerPort.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
Me.ServerPort.Size = New System.Drawing.Size(106, 20)
Me.ServerPort.TabIndex = 7
Me.ServerPort.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
Me.ServerPort.ValidatingType = GetType(Integer)
'
'ServerMaxClients
'
Me.ServerMaxClients.AllowPromptAsInput = False
Me.ServerMaxClients.HidePromptOnLeave = True
Me.ServerMaxClients.Location = New System.Drawing.Point(152, 288)
Me.ServerMaxClients.Mask = "00000"
Me.ServerMaxClients.Name = "ServerMaxClients"
Me.ServerMaxClients.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
Me.ServerMaxClients.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.ServerMaxClients.Size = New System.Drawing.Size(108, 20)
Me.ServerMaxClients.TabIndex = 9
Me.ServerMaxClients.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
Me.ServerMaxClients.ValidatingType = GetType(Integer)
'
'buttonFolderBrowse
'
Me.buttonFolderBrowse.Image = Global.My.Resources.Resources.BrowseFolder_Image
Me.buttonFolderBrowse.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
Me.buttonFolderBrowse.Location = New System.Drawing.Point(495, 107)
Me.buttonFolderBrowse.Name = "buttonFolderBrowse"
Me.buttonFolderBrowse.Size = New System.Drawing.Size(32, 20)
Me.buttonFolderBrowse.TabIndex = 16
Me.buttonFolderBrowse.UseVisualStyleBackColor = True
'
'tabControl1
'
Me.tabControl1.Controls.Add(Me.tabPageSettings)
Me.tabControl1.Controls.Add(Me.tabPageAdvanced)
Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Top
Me.tabControl1.Location = New System.Drawing.Point(0, 0)
Me.tabControl1.Name = "tabControl1"
Me.tabControl1.SelectedIndex = 0
Me.tabControl1.Size = New System.Drawing.Size(542, 344)
Me.tabControl1.TabIndex = 0
'
'tabPageSettings
'
Me.tabPageSettings.Controls.Add(Me.groupBoxIpType)
Me.tabPageSettings.Controls.Add(Me.AllowMultipleConnections)
Me.tabPageSettings.Controls.Add(Me.labelTemporaryDirectory)
Me.tabPageSettings.Controls.Add(Me.labelAeTitle)
Me.tabPageSettings.Controls.Add(Me.buttonFolderBrowse)
Me.tabPageSettings.Controls.Add(Me.ServerAE)
Me.tabPageSettings.Controls.Add(Me.labelDescription)
Me.tabPageSettings.Controls.Add(Me.ServerDescription)
Me.tabPageSettings.Controls.Add(Me.ServerMaxClients)
Me.tabPageSettings.Controls.Add(Me.labelIpAddress)
Me.tabPageSettings.Controls.Add(Me.ServerPort)
Me.tabPageSettings.Controls.Add(Me.labelPort)
Me.tabPageSettings.Controls.Add(Me.TemporaryDirectory)
Me.tabPageSettings.Controls.Add(Me.labelMaxClients)
Me.tabPageSettings.Controls.Add(Me.ImplementationVersionName)
Me.tabPageSettings.Controls.Add(Me.labelImplementationVersionName)
Me.tabPageSettings.Controls.Add(Me.ServerAllowAnonymous)
Me.tabPageSettings.Controls.Add(Me.ImplementationClass)
Me.tabPageSettings.Controls.Add(Me.labelImplementationClass)
Me.tabPageSettings.Controls.Add(Me.ServerSecure)
Me.tabPageSettings.Location = New System.Drawing.Point(4, 22)
Me.tabPageSettings.Name = "tabPageSettings"
Me.tabPageSettings.Padding = New System.Windows.Forms.Padding(3)
Me.tabPageSettings.Size = New System.Drawing.Size(534, 318)
Me.tabPageSettings.TabIndex = 0
Me.tabPageSettings.Text = "Settings"
Me.tabPageSettings.UseVisualStyleBackColor = True
'
'groupBoxIpType
'
Me.groupBoxIpType.Controls.Add(Me.radioButtonIpv4Ipv6)
Me.groupBoxIpType.Controls.Add(Me.radioButtonIpv6)
Me.groupBoxIpType.Controls.Add(Me.radioButtonIpv4)
Me.groupBoxIpType.Controls.Add(Me.ServerIp)
Me.groupBoxIpType.Location = New System.Drawing.Point(8, 144)
Me.groupBoxIpType.Name = "groupBoxIpType"
Me.groupBoxIpType.Size = New System.Drawing.Size(232, 104)
Me.groupBoxIpType.TabIndex = 5
Me.groupBoxIpType.TabStop = False
'
'radioButtonIpv4Ipv6
'
Me.radioButtonIpv4Ipv6.AutoSize = True
Me.radioButtonIpv4Ipv6.Location = New System.Drawing.Point(8, 80)
Me.radioButtonIpv4Ipv6.Name = "radioButtonIpv4Ipv6"
Me.radioButtonIpv4Ipv6.Size = New System.Drawing.Size(82, 17)
Me.radioButtonIpv4Ipv6.TabIndex = 3
Me.radioButtonIpv4Ipv6.TabStop = True
Me.radioButtonIpv4Ipv6.Text = "Ipv4 or Ipv6"
Me.radioButtonIpv4Ipv6.UseVisualStyleBackColor = True
'
'radioButtonIpv6
'
Me.radioButtonIpv6.AutoSize = True
Me.radioButtonIpv6.Location = New System.Drawing.Point(8, 64)
Me.radioButtonIpv6.Name = "radioButtonIpv6"
Me.radioButtonIpv6.Size = New System.Drawing.Size(47, 17)
Me.radioButtonIpv6.TabIndex = 2
Me.radioButtonIpv6.TabStop = True
Me.radioButtonIpv6.Text = "IPv6"
Me.radioButtonIpv6.UseVisualStyleBackColor = True
'
'radioButtonIpv4
'
Me.radioButtonIpv4.AutoSize = True
Me.radioButtonIpv4.Location = New System.Drawing.Point(8, 48)
Me.radioButtonIpv4.Name = "radioButtonIpv4"
Me.radioButtonIpv4.Size = New System.Drawing.Size(47, 17)
Me.radioButtonIpv4.TabIndex = 1
Me.radioButtonIpv4.TabStop = True
Me.radioButtonIpv4.Text = "IPv4"
Me.radioButtonIpv4.UseVisualStyleBackColor = True
'
'ServerIp
'
Me.ServerIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.ServerIp.Location = New System.Drawing.Point(8, 16)
Me.ServerIp.Name = "ServerIp"
Me.ServerIp.Size = New System.Drawing.Size(208, 21)
Me.ServerIp.TabIndex = 0
'
'AllowMultipleConnections
'
Me.AllowMultipleConnections.AutoSize = True
Me.AllowMultipleConnections.Location = New System.Drawing.Point(277, 196)
Me.AllowMultipleConnections.Name = "AllowMultipleConnections"
Me.AllowMultipleConnections.Size = New System.Drawing.Size(124, 17)
Me.AllowMultipleConnections.TabIndex = 19
Me.AllowMultipleConnections.Text = "Multiple Connections"
Me.AllowMultipleConnections.UseVisualStyleBackColor = True
'
'ServerSecure
'
Me.ServerSecure.AutoSize = True
Me.ServerSecure.Location = New System.Drawing.Point(277, 144)
Me.ServerSecure.Name = "ServerSecure"
Me.ServerSecure.Size = New System.Drawing.Size(60, 17)
Me.ServerSecure.TabIndex = 17
Me.ServerSecure.Text = "Secure"
Me.ServerSecure.UseVisualStyleBackColor = True
'
'tabPageAdvanced
'
Me.tabPageAdvanced.Controls.Add(Me.numericUpDownPipes)
Me.tabPageAdvanced.Controls.Add(Me.labelPipes)
Me.tabPageAdvanced.Controls.Add(Me.checkBoxImageCopy)
Me.tabPageAdvanced.Controls.Add(Me.StartMode)
Me.tabPageAdvanced.Controls.Add(Me.labelStartMode)
Me.tabPageAdvanced.Controls.Add(Me.groupBoxSocketOptions)
Me.tabPageAdvanced.Controls.Add(Me.MaxPduLength)
Me.tabPageAdvanced.Controls.Add(Me.labelMaxPdu)
Me.tabPageAdvanced.Controls.Add(Me.groupBoxTimeout)
Me.tabPageAdvanced.Controls.Add(Me.labelDisplayName)
Me.tabPageAdvanced.Controls.Add(Me.DisplayName)
Me.tabPageAdvanced.Location = New System.Drawing.Point(4, 22)
Me.tabPageAdvanced.Name = "tabPageAdvanced"
Me.tabPageAdvanced.Padding = New System.Windows.Forms.Padding(3)
Me.tabPageAdvanced.Size = New System.Drawing.Size(534, 318)
Me.tabPageAdvanced.TabIndex = 1
Me.tabPageAdvanced.Text = "Advanced"
Me.tabPageAdvanced.UseVisualStyleBackColor = True
'
'numericUpDownPipes
'
Me.numericUpDownPipes.Location = New System.Drawing.Point(277, 147)
Me.numericUpDownPipes.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
Me.numericUpDownPipes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.numericUpDownPipes.Name = "numericUpDownPipes"
Me.numericUpDownPipes.Size = New System.Drawing.Size(76, 20)
Me.numericUpDownPipes.TabIndex = 36
Me.numericUpDownPipes.Value = New Decimal(New Integer() {10, 0, 0, 0})
'
'labelPipes
'
Me.labelPipes.AutoSize = True
Me.labelPipes.Location = New System.Drawing.Point(274, 129)
Me.labelPipes.Name = "labelPipes"
Me.labelPipes.Size = New System.Drawing.Size(114, 13)
Me.labelPipes.TabIndex = 35
Me.labelPipes.Text = "# Administrative Pipes:"
'
'checkBoxImageCopy
'
Me.checkBoxImageCopy.AutoSize = True
Me.checkBoxImageCopy.Location = New System.Drawing.Point(12, 183)
Me.checkBoxImageCopy.Name = "checkBoxImageCopy"
Me.checkBoxImageCopy.Size = New System.Drawing.Size(250, 17)
Me.checkBoxImageCopy.TabIndex = 34
Me.checkBoxImageCopy.Text = "Copy dataset image during message notification"
Me.checkBoxImageCopy.UseVisualStyleBackColor = True
'
'StartMode
'
Me.StartMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.StartMode.FormattingEnabled = True
Me.StartMode.Items.AddRange(New Object() {"Automatic", "Manual", "Disabled"})
Me.StartMode.Location = New System.Drawing.Point(12, 146)
Me.StartMode.Name = "StartMode"
Me.StartMode.Size = New System.Drawing.Size(160, 21)
Me.StartMode.TabIndex = 31
'
'labelStartMode
'
Me.labelStartMode.AutoSize = True
Me.labelStartMode.Location = New System.Drawing.Point(9, 129)
Me.labelStartMode.Name = "labelStartMode"
Me.labelStartMode.Size = New System.Drawing.Size(62, 13)
Me.labelStartMode.TabIndex = 30
Me.labelStartMode.Text = "Start Mode:"
'
'groupBoxSocketOptions
'
Me.groupBoxSocketOptions.Controls.Add(Me.SendBuffer)
Me.groupBoxSocketOptions.Controls.Add(Me.ReceiveBuffer)
Me.groupBoxSocketOptions.Controls.Add(Me.labelSendBuffer)
Me.groupBoxSocketOptions.Controls.Add(Me.labelReceiveBuffer)
Me.groupBoxSocketOptions.Controls.Add(Me.NoDelay)
Me.groupBoxSocketOptions.Location = New System.Drawing.Point(277, 56)
Me.groupBoxSocketOptions.Name = "groupBoxSocketOptions"
Me.groupBoxSocketOptions.Size = New System.Drawing.Size(251, 66)
Me.groupBoxSocketOptions.TabIndex = 29
Me.groupBoxSocketOptions.TabStop = False
Me.groupBoxSocketOptions.Text = "Socket Options"
'
'SendBuffer
'
Me.SendBuffer.Location = New System.Drawing.Point(165, 31)
Me.SendBuffer.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
Me.SendBuffer.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.SendBuffer.Name = "SendBuffer"
Me.SendBuffer.Size = New System.Drawing.Size(76, 20)
Me.SendBuffer.TabIndex = 21
Me.SendBuffer.Value = New Decimal(New Integer() {29696, 0, 0, 0})
'
'ReceiveBuffer
'
Me.ReceiveBuffer.Location = New System.Drawing.Point(84, 31)
Me.ReceiveBuffer.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
Me.ReceiveBuffer.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.ReceiveBuffer.Name = "ReceiveBuffer"
Me.ReceiveBuffer.Size = New System.Drawing.Size(76, 20)
Me.ReceiveBuffer.TabIndex = 20
Me.ReceiveBuffer.Value = New Decimal(New Integer() {29696, 0, 0, 0})
'
'labelSendBuffer
'
Me.labelSendBuffer.AutoSize = True
Me.labelSendBuffer.Location = New System.Drawing.Point(162, 15)
Me.labelSendBuffer.Name = "labelSendBuffer"
Me.labelSendBuffer.Size = New System.Drawing.Size(66, 13)
Me.labelSendBuffer.TabIndex = 18
Me.labelSendBuffer.Text = "Send Buffer:"
'
'labelReceiveBuffer
'
Me.labelReceiveBuffer.AutoSize = True
Me.labelReceiveBuffer.Location = New System.Drawing.Point(80, 15)
Me.labelReceiveBuffer.Name = "labelReceiveBuffer"
Me.labelReceiveBuffer.Size = New System.Drawing.Size(81, 13)
Me.labelReceiveBuffer.TabIndex = 16
Me.labelReceiveBuffer.Text = "Receive Buffer:"
'
'NoDelay
'
Me.NoDelay.AutoSize = True
Me.NoDelay.Location = New System.Drawing.Point(7, 34)
Me.NoDelay.Name = "NoDelay"
Me.NoDelay.Size = New System.Drawing.Size(70, 17)
Me.NoDelay.TabIndex = 0
Me.NoDelay.Text = "No Delay"
Me.NoDelay.UseVisualStyleBackColor = True
'
'MaxPduLength
'
Me.MaxPduLength.HidePromptOnLeave = True
Me.MaxPduLength.Location = New System.Drawing.Point(277, 29)
Me.MaxPduLength.Mask = "#########"
Me.MaxPduLength.Name = "MaxPduLength"
Me.MaxPduLength.PromptChar = Global.Microsoft.VisualBasic.ChrW(35)
Me.MaxPduLength.Size = New System.Drawing.Size(251, 20)
Me.MaxPduLength.TabIndex = 28
Me.MaxPduLength.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
'
'labelMaxPdu
'
Me.labelMaxPdu.AutoSize = True
Me.labelMaxPdu.Location = New System.Drawing.Point(274, 13)
Me.labelMaxPdu.Name = "labelMaxPdu"
Me.labelMaxPdu.Size = New System.Drawing.Size(92, 13)
Me.labelMaxPdu.TabIndex = 27
Me.labelMaxPdu.Text = "PDU Max Length:"
'
'groupBoxTimeout
'
Me.groupBoxTimeout.Controls.Add(Me.ReconnectTimeout)
Me.groupBoxTimeout.Controls.Add(Me.AddInTimeout)
Me.groupBoxTimeout.Controls.Add(Me.labelClientTimeout)
Me.groupBoxTimeout.Controls.Add(Me.labelAddInTimeout)
Me.groupBoxTimeout.Controls.Add(Me.ClientTimeout)
Me.groupBoxTimeout.Controls.Add(Me.labelReconnectTimeout)
Me.groupBoxTimeout.Location = New System.Drawing.Point(9, 56)
Me.groupBoxTimeout.Name = "groupBoxTimeout"
Me.groupBoxTimeout.Size = New System.Drawing.Size(251, 66)
Me.groupBoxTimeout.TabIndex = 26
Me.groupBoxTimeout.TabStop = False
Me.groupBoxTimeout.Text = "Timeouts (Seconds)"
'
'ReconnectTimeout
'
Me.ReconnectTimeout.Location = New System.Drawing.Point(89, 32)
Me.ReconnectTimeout.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.ReconnectTimeout.Name = "ReconnectTimeout"
Me.ReconnectTimeout.Size = New System.Drawing.Size(74, 20)
Me.ReconnectTimeout.TabIndex = 23
'
'AddInTimeout
'
Me.AddInTimeout.Location = New System.Drawing.Point(169, 32)
Me.AddInTimeout.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
Me.AddInTimeout.Name = "AddInTimeout"
Me.AddInTimeout.Size = New System.Drawing.Size(74, 20)
Me.AddInTimeout.TabIndex = 25
'
'labelAddInTimeout
'
Me.labelAddInTimeout.AutoSize = True
Me.labelAddInTimeout.Location = New System.Drawing.Point(166, 16)
Me.labelAddInTimeout.Name = "labelAddInTimeout"
Me.labelAddInTimeout.Size = New System.Drawing.Size(38, 13)
Me.labelAddInTimeout.TabIndex = 24
Me.labelAddInTimeout.Text = "AddIn:"
'
'labelReconnectTimeout
'
Me.labelReconnectTimeout.AutoSize = True
Me.labelReconnectTimeout.Location = New System.Drawing.Point(86, 16)
Me.labelReconnectTimeout.Name = "labelReconnectTimeout"
Me.labelReconnectTimeout.Size = New System.Drawing.Size(63, 13)
Me.labelReconnectTimeout.TabIndex = 22
Me.labelReconnectTimeout.Text = "Reconnect:"
'
'labelDisplayName
'
Me.labelDisplayName.AutoSize = True
Me.labelDisplayName.Location = New System.Drawing.Point(6, 13)
Me.labelDisplayName.Name = "labelDisplayName"
Me.labelDisplayName.Size = New System.Drawing.Size(114, 13)
Me.labelDisplayName.TabIndex = 4
Me.labelDisplayName.Text = "Service Display Name:"
'
'DisplayName
'
Me.DisplayName.Location = New System.Drawing.Point(9, 29)
Me.DisplayName.Name = "DisplayName"
Me.DisplayName.Size = New System.Drawing.Size(251, 20)
Me.DisplayName.TabIndex = 5
'
'labelError
'
Me.labelError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.labelError.ForeColor = System.Drawing.Color.Red
Me.labelError.Location = New System.Drawing.Point(4, 389)
Me.labelError.Name = "labelError"
Me.labelError.Size = New System.Drawing.Size(366, 14)
Me.labelError.TabIndex = 2
Me.labelError.Text = "Error"
'
'labelRestart
'
Me.labelRestart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.labelRestart.ForeColor = System.Drawing.Color.Red
Me.labelRestart.Location = New System.Drawing.Point(4, 360)
Me.labelRestart.Name = "labelRestart"
Me.labelRestart.Size = New System.Drawing.Size(366, 14)
Me.labelRestart.TabIndex = 1
Me.labelRestart.Text = "Error"
'
'EditServiceDialog
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.buttonCancel
Me.ClientSize = New System.Drawing.Size(542, 409)
Me.Controls.Add(Me.labelRestart)
Me.Controls.Add(Me.labelError)
Me.Controls.Add(Me.tabControl1)
Me.Controls.Add(Me.buttonCancel)
Me.Controls.Add(Me.buttonOk)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "EditServiceDialog"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Add New Server"
CType(Me.ClientTimeout, System.ComponentModel.ISupportInitialize).EndInit()
Me.tabControl1.ResumeLayout(False)
Me.tabPageSettings.ResumeLayout(False)
Me.tabPageSettings.PerformLayout()
Me.groupBoxIpType.ResumeLayout(False)
Me.groupBoxIpType.PerformLayout()
Me.tabPageAdvanced.ResumeLayout(False)
Me.tabPageAdvanced.PerformLayout()
CType(Me.numericUpDownPipes, System.ComponentModel.ISupportInitialize).EndInit()
Me.groupBoxSocketOptions.ResumeLayout(False)
Me.groupBoxSocketOptions.PerformLayout()
CType(Me.SendBuffer, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.ReceiveBuffer, System.ComponentModel.ISupportInitialize).EndInit()
Me.groupBoxTimeout.ResumeLayout(False)
Me.groupBoxTimeout.PerformLayout()
CType(Me.ReconnectTimeout, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.AddInTimeout, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

        Private labelAeTitle As System.Windows.Forms.Label
        Private WithEvents ServerAE As System.Windows.Forms.TextBox
        Private labelDescription As System.Windows.Forms.Label
        Private ServerDescription As System.Windows.Forms.TextBox
        Private labelIpAddress As System.Windows.Forms.Label
        Private labelPort As System.Windows.Forms.Label
        Private ClientTimeout As System.Windows.Forms.NumericUpDown
        Private labelClientTimeout As System.Windows.Forms.Label
        Private labelMaxClients As System.Windows.Forms.Label
        Private ServerAllowAnonymous As System.Windows.Forms.CheckBox
        Private buttonOk As System.Windows.Forms.Button
      Private ImplementationClass As System.Windows.Forms.TextBox
        Private labelImplementationClass As System.Windows.Forms.Label
        Private ImplementationVersionName As System.Windows.Forms.TextBox
        Private labelImplementationVersionName As System.Windows.Forms.Label
        Private labelTemporaryDirectory As System.Windows.Forms.Label
        Private WithEvents TemporaryDirectory As System.Windows.Forms.TextBox
        Private WithEvents ServerPort As System.Windows.Forms.MaskedTextBox
        Private ServerMaxClients As System.Windows.Forms.MaskedTextBox
      Private WithEvents buttonFolderBrowse As System.Windows.Forms.Button
        Private folderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
        Private tabControl1 As System.Windows.Forms.TabControl
        Private tabPageSettings As System.Windows.Forms.TabPage
        Private tabPageAdvanced As System.Windows.Forms.TabPage
        Private labelDisplayName As System.Windows.Forms.Label
        Private WithEvents DisplayName As System.Windows.Forms.TextBox
        Private ReconnectTimeout As System.Windows.Forms.NumericUpDown
        Private labelReconnectTimeout As System.Windows.Forms.Label
        Private AddInTimeout As System.Windows.Forms.NumericUpDown
        Private labelAddInTimeout As System.Windows.Forms.Label
        Private groupBoxTimeout As System.Windows.Forms.GroupBox
        Private labelMaxPdu As System.Windows.Forms.Label
        Private groupBoxSocketOptions As System.Windows.Forms.GroupBox
        Private MaxPduLength As System.Windows.Forms.MaskedTextBox
        Private labelSendBuffer As System.Windows.Forms.Label
        Private labelReceiveBuffer As System.Windows.Forms.Label
        Private NoDelay As System.Windows.Forms.CheckBox
        Private StartMode As System.Windows.Forms.ComboBox
        Private labelStartMode As System.Windows.Forms.Label
        Private labelError As System.Windows.Forms.Label
        Private buttonCancel As System.Windows.Forms.Button
        Private AllowMultipleConnections As System.Windows.Forms.CheckBox
        Private labelRestart As System.Windows.Forms.Label
        Private SendBuffer As System.Windows.Forms.NumericUpDown
        Private ReceiveBuffer As System.Windows.Forms.NumericUpDown
        Private checkBoxImageCopy As System.Windows.Forms.CheckBox
        Private labelPipes As System.Windows.Forms.Label
        Private numericUpDownPipes As System.Windows.Forms.NumericUpDown
        Private WithEvents groupBoxIpType As System.Windows.Forms.GroupBox
        Private WithEvents radioButtonIpv4Ipv6 As System.Windows.Forms.RadioButton
        Private WithEvents radioButtonIpv6 As System.Windows.Forms.RadioButton
        Private WithEvents radioButtonIpv4 As System.Windows.Forms.RadioButton
      Private WithEvents ServerIp As System.Windows.Forms.ComboBox
      Private WithEvents ServerSecure As System.Windows.Forms.CheckBox
    End Class
End Namespace