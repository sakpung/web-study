Namespace DicomDemo
    Partial Public Class OptionsDialog
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
         Me._groupBoxClient = New System.Windows.Forms.GroupBox()
         Me._textBoxClientPort = New System.Windows.Forms.TextBox()
         Me._labelClientPort = New System.Windows.Forms.Label()
         Me._textBoxClientAE = New System.Windows.Forms.TextBox()
         Me._labelClientAE = New System.Windows.Forms.Label()
         Me._groupBoxCompression = New System.Windows.Forms.GroupBox()
         Me._radioButtonCompressionLossless = New System.Windows.Forms.RadioButton()
         Me._radioButtonCompressionLossy = New System.Windows.Forms.RadioButton()
         Me._radioButtonCompressionNative = New System.Windows.Forms.RadioButton()
         Me._buttonOK = New System.Windows.Forms.Button()
         Me._buttonCancel = New System.Windows.Forms.Button()
         Me._groupBoxSecurity = New System.Windows.Forms.GroupBox()
         Me._labelCertificate = New System.Windows.Forms.Label()
         Me._labelHint = New System.Windows.Forms.Label()
         Me._buttonClientCertificate = New System.Windows.Forms.Button()
         Me._textBoxClientCertificate = New System.Windows.Forms.TextBox()
         Me._textBoxKeyPassword = New System.Windows.Forms.TextBox()
         Me._labelPrivateKeyPassword = New System.Windows.Forms.Label()
         Me._labelPrivateKey = New System.Windows.Forms.Label()
         Me._textBoxPrivateKey = New System.Windows.Forms.TextBox()
         Me._buttonPrivateKey = New System.Windows.Forms.Button()
         Me.dataGridViewServers = New System.Windows.Forms.DataGridView()
         Me.ColumnAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.ColumnIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.ColumnPort = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.ColumnTimeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me.ColumnTls = New System.Windows.Forms.DataGridViewCheckBoxColumn()
         Me.buttonDeleteServer = New System.Windows.Forms.Button()
         Me.buttonAddServer = New System.Windows.Forms.Button()
         Me.GroupBoxStorageCommit = New System.Windows.Forms.GroupBox()
         Me._radioButtonWaitForResults = New System.Windows.Forms.RadioButton()
         Me._radioButtonNoWaitForResults = New System.Windows.Forms.RadioButton()
         Me._groupMiscellaneous = New System.Windows.Forms.GroupBox()
         Me._checkBoxGroupLengthDataElements = New System.Windows.Forms.CheckBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._checkBoxDisableLogging = New System.Windows.Forms.CheckBox()
         Me._labelLogLowLevel = New System.Windows.Forms.Label()
         Me._checkBoxLogLowLevel = New System.Windows.Forms.CheckBox()
         Me.groupBoxCipherSuites = New System.Windows.Forms.GroupBox()
         Me._buttonMoveDown = New System.Windows.Forms.Button()
         Me._checkBoxTlsOld = New System.Windows.Forms.CheckBox()
         Me._buttonMoveUp = New System.Windows.Forms.Button()
         Me._listViewCipherSuites = New System.Windows.Forms.ListView()
         Me.ImageListCiphers = New System.Windows.Forms.ImageList(Me.components)
         Me._groupBoxClient.SuspendLayout()
         Me._groupBoxCompression.SuspendLayout()
         Me._groupBoxSecurity.SuspendLayout()
         CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.GroupBoxStorageCommit.SuspendLayout()
         Me._groupMiscellaneous.SuspendLayout()
         Me.groupBoxCipherSuites.SuspendLayout()
         Me.SuspendLayout()
         '
         '_groupBoxClient
         '
         Me._groupBoxClient.Controls.Add(Me._textBoxClientPort)
         Me._groupBoxClient.Controls.Add(Me._labelClientPort)
         Me._groupBoxClient.Controls.Add(Me._textBoxClientAE)
         Me._groupBoxClient.Controls.Add(Me._labelClientAE)
         Me._groupBoxClient.Location = New System.Drawing.Point(8, 8)
         Me._groupBoxClient.Name = "_groupBoxClient"
         Me._groupBoxClient.Size = New System.Drawing.Size(536, 74)
         Me._groupBoxClient.TabIndex = 0
         Me._groupBoxClient.TabStop = False
         Me._groupBoxClient.Text = "Client Information"
         '
         '_textBoxClientPort
         '
         Me._textBoxClientPort.Location = New System.Drawing.Point(111, 47)
         Me._textBoxClientPort.Name = "_textBoxClientPort"
         Me._textBoxClientPort.Size = New System.Drawing.Size(417, 20)
         Me._textBoxClientPort.TabIndex = 0
         '
         '_labelClientPort
         '
         Me._labelClientPort.AutoSize = True
         Me._labelClientPort.Location = New System.Drawing.Point(16, 51)
         Me._labelClientPort.Name = "_labelClientPort"
         Me._labelClientPort.Size = New System.Drawing.Size(55, 13)
         Me._labelClientPort.TabIndex = 3
         Me._labelClientPort.Text = "ClientPort:"
         '
         '_textBoxClientAE
         '
         Me._textBoxClientAE.Location = New System.Drawing.Point(111, 20)
         Me._textBoxClientAE.Name = "_textBoxClientAE"
         Me._textBoxClientAE.Size = New System.Drawing.Size(417, 20)
         Me._textBoxClientAE.TabIndex = 2
         '
         '_labelClientAE
         '
         Me._labelClientAE.AutoSize = True
         Me._labelClientAE.Location = New System.Drawing.Point(16, 24)
         Me._labelClientAE.Name = "_labelClientAE"
         Me._labelClientAE.Size = New System.Drawing.Size(84, 13)
         Me._labelClientAE.TabIndex = 1
         Me._labelClientAE.Text = "Client AE Name:"
         '
         '_groupBoxCompression
         '
         Me._groupBoxCompression.Controls.Add(Me._radioButtonCompressionLossless)
         Me._groupBoxCompression.Controls.Add(Me._radioButtonCompressionLossy)
         Me._groupBoxCompression.Controls.Add(Me._radioButtonCompressionNative)
         Me._groupBoxCompression.Location = New System.Drawing.Point(8, 392)
         Me._groupBoxCompression.Name = "_groupBoxCompression"
         Me._groupBoxCompression.Size = New System.Drawing.Size(248, 80)
         Me._groupBoxCompression.TabIndex = 3
         Me._groupBoxCompression.TabStop = False
         Me._groupBoxCompression.Text = "Compression"
         '
         '_radioButtonCompressionLossless
         '
         Me._radioButtonCompressionLossless.AutoSize = True
         Me._radioButtonCompressionLossless.Location = New System.Drawing.Point(16, 55)
         Me._radioButtonCompressionLossless.Name = "_radioButtonCompressionLossless"
         Me._radioButtonCompressionLossless.Size = New System.Drawing.Size(65, 17)
         Me._radioButtonCompressionLossless.TabIndex = 2
         Me._radioButtonCompressionLossless.TabStop = True
         Me._radioButtonCompressionLossless.Text = "Lo&ssless"
         Me._radioButtonCompressionLossless.UseVisualStyleBackColor = True
         '
         '_radioButtonCompressionLossy
         '
         Me._radioButtonCompressionLossy.AutoSize = True
         Me._radioButtonCompressionLossy.Location = New System.Drawing.Point(16, 36)
         Me._radioButtonCompressionLossy.Name = "_radioButtonCompressionLossy"
         Me._radioButtonCompressionLossy.Size = New System.Drawing.Size(52, 17)
         Me._radioButtonCompressionLossy.TabIndex = 1
         Me._radioButtonCompressionLossy.TabStop = True
         Me._radioButtonCompressionLossy.Text = "&Lossy"
         Me._radioButtonCompressionLossy.UseVisualStyleBackColor = True
         '
         '_radioButtonCompressionNative
         '
         Me._radioButtonCompressionNative.AutoSize = True
         Me._radioButtonCompressionNative.Location = New System.Drawing.Point(16, 17)
         Me._radioButtonCompressionNative.Name = "_radioButtonCompressionNative"
         Me._radioButtonCompressionNative.Size = New System.Drawing.Size(56, 17)
         Me._radioButtonCompressionNative.TabIndex = 0
         Me._radioButtonCompressionNative.TabStop = True
         Me._radioButtonCompressionNative.Text = "&Native"
         Me._radioButtonCompressionNative.UseVisualStyleBackColor = True
         '
         '_buttonOK
         '
         Me._buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._buttonOK.Location = New System.Drawing.Point(199, 766)
         Me._buttonOK.Name = "_buttonOK"
         Me._buttonOK.Size = New System.Drawing.Size(75, 23)
         Me._buttonOK.TabIndex = 9
         Me._buttonOK.Text = "&OK"
         Me._buttonOK.UseVisualStyleBackColor = True
         '
         '_buttonCancel
         '
         Me._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._buttonCancel.Location = New System.Drawing.Point(287, 766)
         Me._buttonCancel.Name = "_buttonCancel"
         Me._buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me._buttonCancel.TabIndex = 10
         Me._buttonCancel.Text = "Cancel"
         Me._buttonCancel.UseVisualStyleBackColor = True
         '
         '_groupBoxSecurity
         '
         Me._groupBoxSecurity.Controls.Add(Me._labelCertificate)
         Me._groupBoxSecurity.Controls.Add(Me._labelHint)
         Me._groupBoxSecurity.Controls.Add(Me._buttonClientCertificate)
         Me._groupBoxSecurity.Controls.Add(Me._textBoxClientCertificate)
         Me._groupBoxSecurity.Controls.Add(Me._textBoxKeyPassword)
         Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKeyPassword)
         Me._groupBoxSecurity.Controls.Add(Me._labelPrivateKey)
         Me._groupBoxSecurity.Controls.Add(Me._textBoxPrivateKey)
         Me._groupBoxSecurity.Controls.Add(Me._buttonPrivateKey)
         Me._groupBoxSecurity.Location = New System.Drawing.Point(8, 89)
         Me._groupBoxSecurity.Name = "_groupBoxSecurity"
         Me._groupBoxSecurity.Size = New System.Drawing.Size(536, 103)
         Me._groupBoxSecurity.TabIndex = 1
         Me._groupBoxSecurity.TabStop = False
         Me._groupBoxSecurity.Text = "Security"
         '
         '_labelCertificate
         '
         Me._labelCertificate.AutoSize = True
         Me._labelCertificate.Location = New System.Drawing.Point(16, 20)
         Me._labelCertificate.Name = "_labelCertificate"
         Me._labelCertificate.Size = New System.Drawing.Size(57, 13)
         Me._labelCertificate.TabIndex = 0
         Me._labelCertificate.Text = "Certificate:"
         '
         '_labelHint
         '
         Me._labelHint.AutoSize = True
         Me._labelHint.ForeColor = System.Drawing.Color.Blue
         Me._labelHint.Location = New System.Drawing.Point(264, 72)
         Me._labelHint.Name = "_labelHint"
         Me._labelHint.Size = New System.Drawing.Size(140, 13)
         Me._labelHint.TabIndex = 8
         Me._labelHint.Text = "<== Use 'test'  for client.pem"
         '
         '_buttonClientCertificate
         '
         Me._buttonClientCertificate.Image = CType(resources.GetObject("_buttonClientCertificate.Image"), System.Drawing.Image)
         Me._buttonClientCertificate.Location = New System.Drawing.Point(80, 17)
         Me._buttonClientCertificate.Name = "_buttonClientCertificate"
         Me._buttonClientCertificate.Size = New System.Drawing.Size(23, 19)
         Me._buttonClientCertificate.TabIndex = 1
         Me._buttonClientCertificate.UseVisualStyleBackColor = True
         '
         '_textBoxClientCertificate
         '
         Me._textBoxClientCertificate.Location = New System.Drawing.Point(111, 16)
         Me._textBoxClientCertificate.Name = "_textBoxClientCertificate"
         Me._textBoxClientCertificate.Size = New System.Drawing.Size(417, 20)
         Me._textBoxClientCertificate.TabIndex = 2
         '
         '_textBoxKeyPassword
         '
         Me._textBoxKeyPassword.Location = New System.Drawing.Point(111, 68)
         Me._textBoxKeyPassword.Name = "_textBoxKeyPassword"
         Me._textBoxKeyPassword.Size = New System.Drawing.Size(146, 20)
         Me._textBoxKeyPassword.TabIndex = 7
         '
         '_labelPrivateKeyPassword
         '
         Me._labelPrivateKeyPassword.AutoSize = True
         Me._labelPrivateKeyPassword.Location = New System.Drawing.Point(16, 72)
         Me._labelPrivateKeyPassword.Name = "_labelPrivateKeyPassword"
         Me._labelPrivateKeyPassword.Size = New System.Drawing.Size(77, 13)
         Me._labelPrivateKeyPassword.TabIndex = 6
         Me._labelPrivateKeyPassword.Text = "Key Password:"
         '
         '_labelPrivateKey
         '
         Me._labelPrivateKey.AutoSize = True
         Me._labelPrivateKey.Location = New System.Drawing.Point(16, 46)
         Me._labelPrivateKey.Name = "_labelPrivateKey"
         Me._labelPrivateKey.Size = New System.Drawing.Size(64, 13)
         Me._labelPrivateKey.TabIndex = 3
         Me._labelPrivateKey.Text = "Private Key:"
         '
         '_textBoxPrivateKey
         '
         Me._textBoxPrivateKey.Location = New System.Drawing.Point(111, 42)
         Me._textBoxPrivateKey.Name = "_textBoxPrivateKey"
         Me._textBoxPrivateKey.Size = New System.Drawing.Size(417, 20)
         Me._textBoxPrivateKey.TabIndex = 5
         '
         '_buttonPrivateKey
         '
         Me._buttonPrivateKey.Image = CType(resources.GetObject("_buttonPrivateKey.Image"), System.Drawing.Image)
         Me._buttonPrivateKey.Location = New System.Drawing.Point(80, 43)
         Me._buttonPrivateKey.Name = "_buttonPrivateKey"
         Me._buttonPrivateKey.Size = New System.Drawing.Size(23, 19)
         Me._buttonPrivateKey.TabIndex = 4
         Me._buttonPrivateKey.UseVisualStyleBackColor = True
         '
         'dataGridViewServers
         '
         Me.dataGridViewServers.AllowUserToAddRows = False
         Me.dataGridViewServers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
         Me.dataGridViewServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
         Me.dataGridViewServers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnAE, Me.ColumnIP, Me.ColumnPort, Me.ColumnTimeout, Me.ColumnTls})
         Me.dataGridViewServers.Location = New System.Drawing.Point(8, 606)
         Me.dataGridViewServers.Name = "dataGridViewServers"
         Me.dataGridViewServers.Size = New System.Drawing.Size(544, 150)
         Me.dataGridViewServers.TabIndex = 8
         '
         'ColumnAE
         '
         Me.ColumnAE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
         Me.ColumnAE.HeaderText = "Server AE Title"
         Me.ColumnAE.Name = "ColumnAE"
         '
         'ColumnIP
         '
         Me.ColumnIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
         Me.ColumnIP.HeaderText = "Server IP Address"
         Me.ColumnIP.Name = "ColumnIP"
         Me.ColumnIP.Width = 107
         '
         'ColumnPort
         '
         Me.ColumnPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
         Me.ColumnPort.HeaderText = "Server Port"
         Me.ColumnPort.Name = "ColumnPort"
         Me.ColumnPort.Width = 78
         '
         'ColumnTimeout
         '
         Me.ColumnTimeout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
         Me.ColumnTimeout.HeaderText = "Timeout (sec)"
         Me.ColumnTimeout.Name = "ColumnTimeout"
         Me.ColumnTimeout.Width = 88
         '
         'ColumnTls
         '
         Me.ColumnTls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
         Me.ColumnTls.HeaderText = "Secure (TLS)"
         Me.ColumnTls.Name = "ColumnTls"
         Me.ColumnTls.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
         Me.ColumnTls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
         Me.ColumnTls.Width = 87
         '
         'buttonDeleteServer
         '
         Me.buttonDeleteServer.CausesValidation = False
         Me.buttonDeleteServer.Image = CType(resources.GetObject("buttonDeleteServer.Image"), System.Drawing.Image)
         Me.buttonDeleteServer.Location = New System.Drawing.Point(48, 566)
         Me.buttonDeleteServer.Name = "buttonDeleteServer"
         Me.buttonDeleteServer.Size = New System.Drawing.Size(40, 39)
         Me.buttonDeleteServer.TabIndex = 7
         Me.buttonDeleteServer.UseVisualStyleBackColor = True
         '
         'buttonAddServer
         '
         Me.buttonAddServer.Image = CType(resources.GetObject("buttonAddServer.Image"), System.Drawing.Image)
         Me.buttonAddServer.Location = New System.Drawing.Point(8, 566)
         Me.buttonAddServer.Name = "buttonAddServer"
         Me.buttonAddServer.Size = New System.Drawing.Size(40, 39)
         Me.buttonAddServer.TabIndex = 6
         Me.buttonAddServer.UseVisualStyleBackColor = True
         '
         'GroupBoxStorageCommit
         '
         Me.GroupBoxStorageCommit.Controls.Add(Me._radioButtonWaitForResults)
         Me.GroupBoxStorageCommit.Controls.Add(Me._radioButtonNoWaitForResults)
         Me.GroupBoxStorageCommit.Location = New System.Drawing.Point(262, 392)
         Me.GroupBoxStorageCommit.Name = "GroupBoxStorageCommit"
         Me.GroupBoxStorageCommit.Size = New System.Drawing.Size(282, 80)
         Me.GroupBoxStorageCommit.TabIndex = 4
         Me.GroupBoxStorageCommit.TabStop = False
         Me.GroupBoxStorageCommit.Text = "Storage Commit"
         '
         '_radioButtonWaitForResults
         '
         Me._radioButtonWaitForResults.AutoSize = True
         Me._radioButtonWaitForResults.Location = New System.Drawing.Point(15, 17)
         Me._radioButtonWaitForResults.Name = "_radioButtonWaitForResults"
         Me._radioButtonWaitForResults.Size = New System.Drawing.Size(202, 17)
         Me._radioButtonWaitForResults.TabIndex = 0
         Me._radioButtonWaitForResults.TabStop = True
         Me._radioButtonWaitForResults.Text = "Wait for Results on Same Association"
         Me._radioButtonWaitForResults.UseVisualStyleBackColor = True
         '
         '_radioButtonNoWaitForResults
         '
         Me._radioButtonNoWaitForResults.AutoSize = True
         Me._radioButtonNoWaitForResults.Location = New System.Drawing.Point(15, 36)
         Me._radioButtonNoWaitForResults.Name = "_radioButtonNoWaitForResults"
         Me._radioButtonNoWaitForResults.Size = New System.Drawing.Size(256, 17)
         Me._radioButtonNoWaitForResults.TabIndex = 1
         Me._radioButtonNoWaitForResults.TabStop = True
         Me._radioButtonNoWaitForResults.Text = "No Wait for Results (Results on new Association)"
         Me._radioButtonNoWaitForResults.UseVisualStyleBackColor = True
         '
         '_groupMiscellaneous
         '
         Me._groupMiscellaneous.Controls.Add(Me.label1)
         Me._groupMiscellaneous.Controls.Add(Me._checkBoxDisableLogging)
         Me._groupMiscellaneous.Controls.Add(Me._labelLogLowLevel)
         Me._groupMiscellaneous.Controls.Add(Me._checkBoxLogLowLevel)
         Me._groupMiscellaneous.Controls.Add(Me._checkBoxGroupLengthDataElements)
         Me._groupMiscellaneous.Location = New System.Drawing.Point(8, 478)
         Me._groupMiscellaneous.Name = "_groupMiscellaneous"
         Me._groupMiscellaneous.Size = New System.Drawing.Size(536, 80)
         Me._groupMiscellaneous.TabIndex = 5
         Me._groupMiscellaneous.TabStop = False
         Me._groupMiscellaneous.Text = "Miscellaneous"
         '
         '_checkBoxGroupLengthDataElements
         '
         Me._checkBoxGroupLengthDataElements.AutoSize = True
         Me._checkBoxGroupLengthDataElements.Location = New System.Drawing.Point(15, 20)
         Me._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements"
         Me._checkBoxGroupLengthDataElements.Size = New System.Drawing.Size(201, 17)
         Me._checkBoxGroupLengthDataElements.TabIndex = 0
         Me._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements"
         Me._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = True
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.ForeColor = System.Drawing.Color.Green
         Me.label1.Location = New System.Drawing.Point(138, 60)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(227, 13)
         Me.label1.TabIndex = 4
         Me.label1.Text = "<== Disable logging for Optimized Performance"
         '
         '_checkBoxDisableLogging
         '
         Me._checkBoxDisableLogging.AutoSize = True
         Me._checkBoxDisableLogging.Location = New System.Drawing.Point(15, 58)
         Me._checkBoxDisableLogging.Name = "_checkBoxDisableLogging"
         Me._checkBoxDisableLogging.Size = New System.Drawing.Size(102, 17)
         Me._checkBoxDisableLogging.TabIndex = 2
         Me._checkBoxDisableLogging.Text = "Disable Logging"
         Me._checkBoxDisableLogging.UseVisualStyleBackColor = True
         '
         '_labelLogLowLevel
         '
         Me._labelLogLowLevel.AutoSize = True
         Me._labelLogLowLevel.ForeColor = System.Drawing.Color.Green
         Me._labelLogLowLevel.Location = New System.Drawing.Point(138, 41)
         Me._labelLogLowLevel.Name = "_labelLogLowLevel"
         Me._labelLogLowLevel.Size = New System.Drawing.Size(189, 13)
         Me._labelLogLowLevel.TabIndex = 3
         Me._labelLogLowLevel.Text = "<== Displayed green in the log window"
         '
         '_checkBoxLogLowLevel
         '
         Me._checkBoxLogLowLevel.AutoSize = True
         Me._checkBoxLogLowLevel.Location = New System.Drawing.Point(15, 39)
         Me._checkBoxLogLowLevel.Name = "_checkBoxLogLowLevel"
         Me._checkBoxLogLowLevel.Size = New System.Drawing.Size(116, 17)
         Me._checkBoxLogLowLevel.TabIndex = 1
         Me._checkBoxLogLowLevel.Text = "Low Level Logging"
         Me._checkBoxLogLowLevel.UseVisualStyleBackColor = True
         '
         'groupBoxCipherSuites
         '
         Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveDown)
         Me.groupBoxCipherSuites.Controls.Add(Me._checkBoxTlsOld)
         Me.groupBoxCipherSuites.Controls.Add(Me._buttonMoveUp)
         Me.groupBoxCipherSuites.Controls.Add(Me._listViewCipherSuites)
         Me.groupBoxCipherSuites.Location = New System.Drawing.Point(8, 196)
         Me.groupBoxCipherSuites.Name = "groupBoxCipherSuites"
         Me.groupBoxCipherSuites.Size = New System.Drawing.Size(536, 190)
         Me.groupBoxCipherSuites.TabIndex = 2
         Me.groupBoxCipherSuites.TabStop = False
         Me.groupBoxCipherSuites.Text = "Cipher Suites"
         '
         '_buttonMoveDown
         '
         Me._buttonMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
         Me._buttonMoveDown.Image = CType(resources.GetObject("_buttonMoveDown.Image"), System.Drawing.Image)
         Me._buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
         Me._buttonMoveDown.Location = New System.Drawing.Point(16, 120)
         Me._buttonMoveDown.Name = "_buttonMoveDown"
         Me._buttonMoveDown.Size = New System.Drawing.Size(85, 38)
         Me._buttonMoveDown.TabIndex = 1
         Me._buttonMoveDown.Text = "Low Priority"
         Me._buttonMoveDown.TextAlign = System.Drawing.ContentAlignment.TopCenter
         Me._buttonMoveDown.UseVisualStyleBackColor = True
         '
         '_checkBoxTlsOld
         '
         Me._checkBoxTlsOld.AutoSize = True
         Me._checkBoxTlsOld.Location = New System.Drawing.Point(110, 164)
         Me._checkBoxTlsOld.Name = "_checkBoxTlsOld"
         Me._checkBoxTlsOld.Size = New System.Drawing.Size(235, 17)
         Me._checkBoxTlsOld.TabIndex = 2
         Me._checkBoxTlsOld.Text = "Include TLS 1.0 Cipher Suites (Less Secure)"
         Me._checkBoxTlsOld.UseVisualStyleBackColor = True
         '
         '_buttonMoveUp
         '
         Me._buttonMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
         Me._buttonMoveUp.Image = CType(resources.GetObject("_buttonMoveUp.Image"), System.Drawing.Image)
         Me._buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me._buttonMoveUp.Location = New System.Drawing.Point(16, 16)
         Me._buttonMoveUp.Name = "_buttonMoveUp"
         Me._buttonMoveUp.Size = New System.Drawing.Size(85, 38)
         Me._buttonMoveUp.TabIndex = 0
         Me._buttonMoveUp.Text = "High Priority"
         Me._buttonMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
         Me._buttonMoveUp.UseVisualStyleBackColor = True
         '
         '_listViewCipherSuites
         '
         Me._listViewCipherSuites.Location = New System.Drawing.Point(110, 16)
         Me._listViewCipherSuites.Name = "_listViewCipherSuites"
         Me._listViewCipherSuites.Size = New System.Drawing.Size(418, 142)
         Me._listViewCipherSuites.TabIndex = 3
         Me._listViewCipherSuites.UseCompatibleStateImageBehavior = False
         '
         'ImageListCiphers
         '
         Me.ImageListCiphers.ImageStream = CType(resources.GetObject("ImageListCiphers.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.ImageListCiphers.TransparentColor = System.Drawing.Color.Transparent
         Me.ImageListCiphers.Images.SetKeyName(0, "yellowBullet.png")
         Me.ImageListCiphers.Images.SetKeyName(1, "yellowBullet.png")
         Me.ImageListCiphers.Images.SetKeyName(2, "greenBullet.png")
         '
         'OptionsDialog
         '
         Me.AcceptButton = Me._buttonOK
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
         Me.CancelButton = Me._buttonCancel
         Me.ClientSize = New System.Drawing.Size(560, 794)
         Me.Controls.Add(Me.groupBoxCipherSuites)
         Me.Controls.Add(Me._groupMiscellaneous)
         Me.Controls.Add(Me.GroupBoxStorageCommit)
         Me.Controls.Add(Me.buttonDeleteServer)
         Me.Controls.Add(Me.buttonAddServer)
         Me.Controls.Add(Me.dataGridViewServers)
         Me.Controls.Add(Me._groupBoxSecurity)
         Me.Controls.Add(Me._buttonCancel)
         Me.Controls.Add(Me._buttonOK)
         Me.Controls.Add(Me._groupBoxCompression)
         Me.Controls.Add(Me._groupBoxClient)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "OptionsDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Options"
         Me._groupBoxClient.ResumeLayout(False)
         Me._groupBoxClient.PerformLayout()
         Me._groupBoxCompression.ResumeLayout(False)
         Me._groupBoxCompression.PerformLayout()
         Me._groupBoxSecurity.ResumeLayout(False)
         Me._groupBoxSecurity.PerformLayout()
         CType(Me.dataGridViewServers, System.ComponentModel.ISupportInitialize).EndInit()
         Me.GroupBoxStorageCommit.ResumeLayout(False)
         Me.GroupBoxStorageCommit.PerformLayout()
         Me._groupMiscellaneous.ResumeLayout(False)
         Me._groupMiscellaneous.PerformLayout()
         Me.groupBoxCipherSuites.ResumeLayout(False)
         Me.groupBoxCipherSuites.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _groupBoxClient As System.Windows.Forms.GroupBox
      Private _groupBoxCompression As System.Windows.Forms.GroupBox
      Private WithEvents _buttonOK As System.Windows.Forms.Button
      Private _buttonCancel As System.Windows.Forms.Button
      Private _textBoxClientAE As System.Windows.Forms.TextBox
      Private _labelClientAE As System.Windows.Forms.Label
      Private _radioButtonCompressionLossless As System.Windows.Forms.RadioButton
      Private _radioButtonCompressionLossy As System.Windows.Forms.RadioButton
      Private _radioButtonCompressionNative As System.Windows.Forms.RadioButton
      Private _groupBoxSecurity As System.Windows.Forms.GroupBox
      Private _labelCertificate As System.Windows.Forms.Label
      Private _labelHint As System.Windows.Forms.Label
      Private WithEvents _buttonClientCertificate As System.Windows.Forms.Button
      Private _textBoxClientCertificate As System.Windows.Forms.TextBox
      Private _textBoxKeyPassword As System.Windows.Forms.TextBox
      Private _labelPrivateKeyPassword As System.Windows.Forms.Label
      Private _labelPrivateKey As System.Windows.Forms.Label
      Private _textBoxPrivateKey As System.Windows.Forms.TextBox
      Private WithEvents _buttonPrivateKey As System.Windows.Forms.Button
      Private WithEvents buttonDeleteServer As System.Windows.Forms.Button
      Private WithEvents buttonAddServer As System.Windows.Forms.Button
      Private WithEvents dataGridViewServers As System.Windows.Forms.DataGridView
      Private ColumnAE As System.Windows.Forms.DataGridViewTextBoxColumn
      Private ColumnIP As System.Windows.Forms.DataGridViewTextBoxColumn
      Private ColumnPort As System.Windows.Forms.DataGridViewTextBoxColumn
      Private ColumnTimeout As System.Windows.Forms.DataGridViewTextBoxColumn
      Private ColumnTls As System.Windows.Forms.DataGridViewCheckBoxColumn
      Friend WithEvents GroupBoxStorageCommit As System.Windows.Forms.GroupBox
      Private WithEvents _radioButtonWaitForResults As System.Windows.Forms.RadioButton
      Private WithEvents _radioButtonNoWaitForResults As System.Windows.Forms.RadioButton
      Private WithEvents _textBoxClientPort As System.Windows.Forms.TextBox
      Private WithEvents _labelClientPort As System.Windows.Forms.Label
      Private WithEvents _groupMiscellaneous As System.Windows.Forms.GroupBox
      Private WithEvents _checkBoxGroupLengthDataElements As System.Windows.Forms.CheckBox
      Private WithEvents label1 As System.Windows.Forms.Label
      Friend WithEvents _checkBoxDisableLogging As System.Windows.Forms.CheckBox
      Private WithEvents _labelLogLowLevel As System.Windows.Forms.Label
      Private WithEvents _checkBoxLogLowLevel As System.Windows.Forms.CheckBox
      Private WithEvents groupBoxCipherSuites As System.Windows.Forms.GroupBox
      Private WithEvents _buttonMoveDown As System.Windows.Forms.Button
      Private WithEvents _checkBoxTlsOld As System.Windows.Forms.CheckBox
      Private WithEvents _buttonMoveUp As System.Windows.Forms.Button
      Private WithEvents _listViewCipherSuites As System.Windows.Forms.ListView
      Friend WithEvents ImageListCiphers As System.Windows.Forms.ImageList
   End Class
End Namespace