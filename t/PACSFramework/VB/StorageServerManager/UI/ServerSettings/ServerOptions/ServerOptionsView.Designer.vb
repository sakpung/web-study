Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class ServerOptionsView
      ''' <summary> 
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary> 
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
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
            Me.UseTlsSecurityCheckBox = New System.Windows.Forms.CheckBox()
            Me.checkBoxEnableDefaultRoleSelection = New System.Windows.Forms.CheckBox()
            Me.radioButtonUserRoleTurnDown = New System.Windows.Forms.RadioButton()
            Me.radioButtonUserRoleAccept = New System.Windows.Forms.RadioButton()
            Me.groupBoxUserRole = New System.Windows.Forms.GroupBox()
            Me.radioButtonProviderRoleTurnDown = New System.Windows.Forms.RadioButton()
            Me.radioButtonProviderRoleAccept = New System.Windows.Forms.RadioButton()
            Me.groupBoxProviderRole = New System.Windows.Forms.GroupBox()
            Me.groupBoxRoleSelect = New System.Windows.Forms.GroupBox()
            Me.groupAssociation = New System.Windows.Forms.GroupBox()
            Me.groupBoxRelationalQueries = New System.Windows.Forms.GroupBox()
            Me.rbRelationalQueriesAlways = New System.Windows.Forms.RadioButton()
            Me.rbRelationalQueriesNegotiate = New System.Windows.Forms.RadioButton()
            Me.rbRelationalQueriesNever = New System.Windows.Forms.RadioButton()
            Me.AnonymousClientPortLabel = New System.Windows.Forms.Label()
            Me.AnonymousClientPortNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.AllowAnonymousCMoveCheckBox = New System.Windows.Forms.CheckBox()
            Me.groupBoxConnections = New System.Windows.Forms.GroupBox()
            Me.MaxClientsNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.AllowMultipleCheckBox = New System.Windows.Forms.CheckBox()
            Me.AllowAnonCheckBox = New System.Windows.Forms.CheckBox()
            Me.label6 = New System.Windows.Forms.Label()
            Me.groupBoxTimeout = New System.Windows.Forms.GroupBox()
            Me.AddinsTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.label12 = New System.Windows.Forms.Label()
            Me.ReconnectTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.label11 = New System.Windows.Forms.Label()
            Me.ClientTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.label10 = New System.Windows.Forms.Label()
            Me.label1 = New System.Windows.Forms.Label()
            Me.BrowseTempButton = New System.Windows.Forms.Button()
            Me.TempFolderTextBox = New System.Windows.Forms.TextBox()
            Me.groupBoxUserRole.SuspendLayout()
            Me.groupBoxProviderRole.SuspendLayout()
            Me.groupBoxRoleSelect.SuspendLayout()
            Me.groupAssociation.SuspendLayout()
            Me.groupBoxRelationalQueries.SuspendLayout()
            CType(Me.AnonymousClientPortNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBoxConnections.SuspendLayout()
            CType(Me.MaxClientsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBoxTimeout.SuspendLayout()
            CType(Me.AddinsTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ReconnectTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ClientTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'UseTlsSecurityCheckBox
            '
            Me.UseTlsSecurityCheckBox.AutoSize = True
            Me.UseTlsSecurityCheckBox.Location = New System.Drawing.Point(10, 106)
            Me.UseTlsSecurityCheckBox.Name = "UseTlsSecurityCheckBox"
            Me.UseTlsSecurityCheckBox.Size = New System.Drawing.Size(152, 17)
            Me.UseTlsSecurityCheckBox.TabIndex = 7
            Me.UseTlsSecurityCheckBox.Text = "Secure (Use TLS Security)"
            Me.UseTlsSecurityCheckBox.UseVisualStyleBackColor = True
            '
            'checkBoxEnableDefaultRoleSelection
            '
            Me.checkBoxEnableDefaultRoleSelection.AutoSize = True
            Me.checkBoxEnableDefaultRoleSelection.Location = New System.Drawing.Point(7, 0)
            Me.checkBoxEnableDefaultRoleSelection.Name = "checkBoxEnableDefaultRoleSelection"
            Me.checkBoxEnableDefaultRoleSelection.Size = New System.Drawing.Size(15, 14)
            Me.checkBoxEnableDefaultRoleSelection.TabIndex = 0
            Me.checkBoxEnableDefaultRoleSelection.UseVisualStyleBackColor = True
            '
            'radioButtonUserRoleTurnDown
            '
            Me.radioButtonUserRoleTurnDown.AutoSize = True
            Me.radioButtonUserRoleTurnDown.Location = New System.Drawing.Point(15, 36)
            Me.radioButtonUserRoleTurnDown.Name = "radioButtonUserRoleTurnDown"
            Me.radioButtonUserRoleTurnDown.Size = New System.Drawing.Size(93, 17)
            Me.radioButtonUserRoleTurnDown.TabIndex = 6
            Me.radioButtonUserRoleTurnDown.TabStop = True
            Me.radioButtonUserRoleTurnDown.Text = "Turn Down (0)"
            Me.radioButtonUserRoleTurnDown.UseVisualStyleBackColor = True
            '
            'radioButtonUserRoleAccept
            '
            Me.radioButtonUserRoleAccept.AutoSize = True
            Me.radioButtonUserRoleAccept.Location = New System.Drawing.Point(15, 16)
            Me.radioButtonUserRoleAccept.Name = "radioButtonUserRoleAccept"
            Me.radioButtonUserRoleAccept.Size = New System.Drawing.Size(74, 17)
            Me.radioButtonUserRoleAccept.TabIndex = 5
            Me.radioButtonUserRoleAccept.TabStop = True
            Me.radioButtonUserRoleAccept.Text = "Accept (1)"
            Me.radioButtonUserRoleAccept.UseVisualStyleBackColor = True
            '
            'groupBoxUserRole
            '
            Me.groupBoxUserRole.Controls.Add(Me.radioButtonUserRoleTurnDown)
            Me.groupBoxUserRole.Controls.Add(Me.radioButtonUserRoleAccept)
            Me.groupBoxUserRole.Location = New System.Drawing.Point(17, 22)
            Me.groupBoxUserRole.Name = "groupBoxUserRole"
            Me.groupBoxUserRole.Size = New System.Drawing.Size(146, 57)
            Me.groupBoxUserRole.TabIndex = 7
            Me.groupBoxUserRole.TabStop = False
            Me.groupBoxUserRole.Text = "User Role (SCU) Proposal"
            '
            'radioButtonProviderRoleTurnDown
            '
            Me.radioButtonProviderRoleTurnDown.AutoSize = True
            Me.radioButtonProviderRoleTurnDown.Location = New System.Drawing.Point(16, 36)
            Me.radioButtonProviderRoleTurnDown.Name = "radioButtonProviderRoleTurnDown"
            Me.radioButtonProviderRoleTurnDown.Size = New System.Drawing.Size(93, 17)
            Me.radioButtonProviderRoleTurnDown.TabIndex = 8
            Me.radioButtonProviderRoleTurnDown.TabStop = True
            Me.radioButtonProviderRoleTurnDown.Text = "Turn Down (0)"
            Me.radioButtonProviderRoleTurnDown.UseVisualStyleBackColor = True
            '
            'radioButtonProviderRoleAccept
            '
            Me.radioButtonProviderRoleAccept.AutoSize = True
            Me.radioButtonProviderRoleAccept.Location = New System.Drawing.Point(16, 16)
            Me.radioButtonProviderRoleAccept.Name = "radioButtonProviderRoleAccept"
            Me.radioButtonProviderRoleAccept.Size = New System.Drawing.Size(74, 17)
            Me.radioButtonProviderRoleAccept.TabIndex = 7
            Me.radioButtonProviderRoleAccept.TabStop = True
            Me.radioButtonProviderRoleAccept.Text = "Accept (1)"
            Me.radioButtonProviderRoleAccept.UseVisualStyleBackColor = True
            '
            'groupBoxProviderRole
            '
            Me.groupBoxProviderRole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.groupBoxProviderRole.Controls.Add(Me.radioButtonProviderRoleTurnDown)
            Me.groupBoxProviderRole.Controls.Add(Me.radioButtonProviderRoleAccept)
            Me.groupBoxProviderRole.Location = New System.Drawing.Point(175, 22)
            Me.groupBoxProviderRole.Name = "groupBoxProviderRole"
            Me.groupBoxProviderRole.Size = New System.Drawing.Size(233, 57)
            Me.groupBoxProviderRole.TabIndex = 8
            Me.groupBoxProviderRole.TabStop = False
            Me.groupBoxProviderRole.Text = "Provider Role (SCP) Proposal"
            '
            'groupBoxRoleSelect
            '
            Me.groupBoxRoleSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.groupBoxRoleSelect.Controls.Add(Me.groupBoxProviderRole)
            Me.groupBoxRoleSelect.Controls.Add(Me.groupBoxUserRole)
            Me.groupBoxRoleSelect.Controls.Add(Me.checkBoxEnableDefaultRoleSelection)
            Me.groupBoxRoleSelect.Location = New System.Drawing.Point(10, 135)
            Me.groupBoxRoleSelect.Name = "groupBoxRoleSelect"
            Me.groupBoxRoleSelect.Size = New System.Drawing.Size(414, 88)
            Me.groupBoxRoleSelect.TabIndex = 9
            Me.groupBoxRoleSelect.TabStop = False
            Me.groupBoxRoleSelect.Text = "       Enable Role Selection Negotiation (DIMSE Services)"
            '
            'groupAssociation
            '
            Me.groupAssociation.Controls.Add(Me.groupBoxRoleSelect)
            Me.groupAssociation.Controls.Add(Me.groupBoxRelationalQueries)
            Me.groupAssociation.Location = New System.Drawing.Point(4, 168)
            Me.groupAssociation.Name = "groupAssociation"
            Me.groupAssociation.Size = New System.Drawing.Size(430, 234)
            Me.groupAssociation.TabIndex = 14
            Me.groupAssociation.TabStop = False
            Me.groupAssociation.Text = "Association"
            '
            'groupBoxRelationalQueries
            '
            Me.groupBoxRelationalQueries.Controls.Add(Me.rbRelationalQueriesAlways)
            Me.groupBoxRelationalQueries.Controls.Add(Me.rbRelationalQueriesNegotiate)
            Me.groupBoxRelationalQueries.Controls.Add(Me.rbRelationalQueriesNever)
            Me.groupBoxRelationalQueries.Location = New System.Drawing.Point(9, 19)
            Me.groupBoxRelationalQueries.Name = "groupBoxRelationalQueries"
            Me.groupBoxRelationalQueries.Size = New System.Drawing.Size(197, 92)
            Me.groupBoxRelationalQueries.TabIndex = 0
            Me.groupBoxRelationalQueries.TabStop = False
            Me.groupBoxRelationalQueries.Text = "Relational Queries"
            '
            'rbRelationalQueriesAlways
            '
            Me.rbRelationalQueriesAlways.AutoSize = True
            Me.rbRelationalQueriesAlways.Location = New System.Drawing.Point(7, 63)
            Me.rbRelationalQueriesAlways.Name = "rbRelationalQueriesAlways"
            Me.rbRelationalQueriesAlways.Size = New System.Drawing.Size(58, 17)
            Me.rbRelationalQueriesAlways.TabIndex = 2
            Me.rbRelationalQueriesAlways.TabStop = True
            Me.rbRelationalQueriesAlways.Text = "Always"
            Me.rbRelationalQueriesAlways.UseVisualStyleBackColor = True
            '
            'rbRelationalQueriesNegotiate
            '
            Me.rbRelationalQueriesNegotiate.AutoSize = True
            Me.rbRelationalQueriesNegotiate.Location = New System.Drawing.Point(7, 40)
            Me.rbRelationalQueriesNegotiate.Name = "rbRelationalQueriesNegotiate"
            Me.rbRelationalQueriesNegotiate.Size = New System.Drawing.Size(173, 17)
            Me.rbRelationalQueriesNegotiate.TabIndex = 1
            Me.rbRelationalQueriesNegotiate.TabStop = True
            Me.rbRelationalQueriesNegotiate.Text = "Support - Extended Negotiation"
            Me.rbRelationalQueriesNegotiate.UseVisualStyleBackColor = True
            '
            'rbRelationalQueriesNever
            '
            Me.rbRelationalQueriesNever.AutoSize = True
            Me.rbRelationalQueriesNever.Location = New System.Drawing.Point(7, 17)
            Me.rbRelationalQueriesNever.Name = "rbRelationalQueriesNever"
            Me.rbRelationalQueriesNever.Size = New System.Drawing.Size(99, 17)
            Me.rbRelationalQueriesNever.TabIndex = 0
            Me.rbRelationalQueriesNever.TabStop = True
            Me.rbRelationalQueriesNever.Text = "Do Not Support"
            Me.rbRelationalQueriesNever.UseVisualStyleBackColor = True
            '
            'AnonymousClientPortLabel
            '
            Me.AnonymousClientPortLabel.AutoSize = True
            Me.AnonymousClientPortLabel.Location = New System.Drawing.Point(27, 63)
            Me.AnonymousClientPortLabel.Name = "AnonymousClientPortLabel"
            Me.AnonymousClientPortLabel.Size = New System.Drawing.Size(116, 13)
            Me.AnonymousClientPortLabel.TabIndex = 2
            Me.AnonymousClientPortLabel.Text = "Anonymous Client Port:"
            '
            'AnonymousClientPortNumericUpDown
            '
            Me.AnonymousClientPortNumericUpDown.Location = New System.Drawing.Point(149, 61)
            Me.AnonymousClientPortNumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.AnonymousClientPortNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.AnonymousClientPortNumericUpDown.Name = "AnonymousClientPortNumericUpDown"
            Me.AnonymousClientPortNumericUpDown.Size = New System.Drawing.Size(57, 20)
            Me.AnonymousClientPortNumericUpDown.TabIndex = 3
            Me.AnonymousClientPortNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'AllowAnonymousCMoveCheckBox
            '
            Me.AllowAnonymousCMoveCheckBox.AutoSize = True
            Me.AllowAnonymousCMoveCheckBox.Location = New System.Drawing.Point(10, 41)
            Me.AllowAnonymousCMoveCheckBox.Name = "AllowAnonymousCMoveCheckBox"
            Me.AllowAnonymousCMoveCheckBox.Size = New System.Drawing.Size(149, 17)
            Me.AllowAnonymousCMoveCheckBox.TabIndex = 1
            Me.AllowAnonymousCMoveCheckBox.Text = "Allow Anonymous C-Move"
            Me.AllowAnonymousCMoveCheckBox.UseVisualStyleBackColor = True
            '
            'groupBoxConnections
            '
            Me.groupBoxConnections.Controls.Add(Me.UseTlsSecurityCheckBox)
            Me.groupBoxConnections.Controls.Add(Me.AnonymousClientPortLabel)
            Me.groupBoxConnections.Controls.Add(Me.MaxClientsNumericUpDown)
            Me.groupBoxConnections.Controls.Add(Me.AllowMultipleCheckBox)
            Me.groupBoxConnections.Controls.Add(Me.AnonymousClientPortNumericUpDown)
            Me.groupBoxConnections.Controls.Add(Me.AllowAnonCheckBox)
            Me.groupBoxConnections.Controls.Add(Me.AllowAnonymousCMoveCheckBox)
            Me.groupBoxConnections.Controls.Add(Me.label6)
            Me.groupBoxConnections.Location = New System.Drawing.Point(4, 5)
            Me.groupBoxConnections.Name = "groupBoxConnections"
            Me.groupBoxConnections.Size = New System.Drawing.Size(218, 157)
            Me.groupBoxConnections.TabIndex = 18
            Me.groupBoxConnections.TabStop = False
            Me.groupBoxConnections.Text = "Connections"
            '
            'MaxClientsNumericUpDown
            '
            Me.MaxClientsNumericUpDown.Location = New System.Drawing.Point(81, 127)
            Me.MaxClientsNumericUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
            Me.MaxClientsNumericUpDown.Name = "MaxClientsNumericUpDown"
            Me.MaxClientsNumericUpDown.Size = New System.Drawing.Size(57, 20)
            Me.MaxClientsNumericUpDown.TabIndex = 6
            '
            'AllowMultipleCheckBox
            '
            Me.AllowMultipleCheckBox.AutoSize = True
            Me.AllowMultipleCheckBox.Location = New System.Drawing.Point(10, 83)
            Me.AllowMultipleCheckBox.Name = "AllowMultipleCheckBox"
            Me.AllowMultipleCheckBox.Size = New System.Drawing.Size(181, 17)
            Me.AllowMultipleCheckBox.TabIndex = 4
            Me.AllowMultipleCheckBox.Text = "Allow Client Multiple Connections"
            Me.AllowMultipleCheckBox.UseVisualStyleBackColor = True
            '
            'AllowAnonCheckBox
            '
            Me.AllowAnonCheckBox.AutoSize = True
            Me.AllowAnonCheckBox.Location = New System.Drawing.Point(10, 18)
            Me.AllowAnonCheckBox.Name = "AllowAnonCheckBox"
            Me.AllowAnonCheckBox.Size = New System.Drawing.Size(171, 17)
            Me.AllowAnonCheckBox.TabIndex = 0
            Me.AllowAnonCheckBox.Text = "Allow Anonymous Connections"
            Me.AllowAnonCheckBox.UseVisualStyleBackColor = True
            '
            'label6
            '
            Me.label6.AutoSize = True
            Me.label6.Location = New System.Drawing.Point(8, 129)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(67, 13)
            Me.label6.TabIndex = 5
            Me.label6.Text = "Max. Clients:"
            '
            'groupBoxTimeout
            '
            Me.groupBoxTimeout.Controls.Add(Me.AddinsTimeoutNumericUpDown)
            Me.groupBoxTimeout.Controls.Add(Me.label12)
            Me.groupBoxTimeout.Controls.Add(Me.ReconnectTimeoutNumericUpDown)
            Me.groupBoxTimeout.Controls.Add(Me.label11)
            Me.groupBoxTimeout.Controls.Add(Me.ClientTimeoutNumericUpDown)
            Me.groupBoxTimeout.Controls.Add(Me.label10)
            Me.groupBoxTimeout.Location = New System.Drawing.Point(228, 5)
            Me.groupBoxTimeout.Name = "groupBoxTimeout"
            Me.groupBoxTimeout.Size = New System.Drawing.Size(206, 157)
            Me.groupBoxTimeout.TabIndex = 13
            Me.groupBoxTimeout.TabStop = False
            Me.groupBoxTimeout.Text = "Timeout (Seconds):"
            '
            'AddinsTimeoutNumericUpDown
            '
            Me.AddinsTimeoutNumericUpDown.Location = New System.Drawing.Point(142, 39)
            Me.AddinsTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
            Me.AddinsTimeoutNumericUpDown.Name = "AddinsTimeoutNumericUpDown"
            Me.AddinsTimeoutNumericUpDown.Size = New System.Drawing.Size(57, 20)
            Me.AddinsTimeoutNumericUpDown.TabIndex = 3
            '
            'label12
            '
            Me.label12.AutoSize = True
            Me.label12.Location = New System.Drawing.Point(20, 43)
            Me.label12.Name = "label12"
            Me.label12.Size = New System.Drawing.Size(108, 13)
            Me.label12.TabIndex = 2
            Me.label12.Text = "Message Processing:"
            '
            'ReconnectTimeoutNumericUpDown
            '
            Me.ReconnectTimeoutNumericUpDown.Location = New System.Drawing.Point(142, 62)
            Me.ReconnectTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
            Me.ReconnectTimeoutNumericUpDown.Name = "ReconnectTimeoutNumericUpDown"
            Me.ReconnectTimeoutNumericUpDown.Size = New System.Drawing.Size(57, 20)
            Me.ReconnectTimeoutNumericUpDown.TabIndex = 5
            '
            'label11
            '
            Me.label11.AutoSize = True
            Me.label11.Location = New System.Drawing.Point(20, 66)
            Me.label11.Name = "label11"
            Me.label11.Size = New System.Drawing.Size(105, 13)
            Me.label11.TabIndex = 4
            Me.label11.Text = "Store sub-operation :"
            '
            'ClientTimeoutNumericUpDown
            '
            Me.ClientTimeoutNumericUpDown.Location = New System.Drawing.Point(142, 16)
            Me.ClientTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
            Me.ClientTimeoutNumericUpDown.Name = "ClientTimeoutNumericUpDown"
            Me.ClientTimeoutNumericUpDown.Size = New System.Drawing.Size(57, 20)
            Me.ClientTimeoutNumericUpDown.TabIndex = 1
            '
            'label10
            '
            Me.label10.AutoSize = True
            Me.label10.Location = New System.Drawing.Point(20, 20)
            Me.label10.Name = "label10"
            Me.label10.Size = New System.Drawing.Size(56, 13)
            Me.label10.TabIndex = 0
            Me.label10.Text = "Client Idle:"
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(10, 405)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(105, 13)
            Me.label1.TabIndex = 15
            Me.label1.Text = "Temporary Directory:"
            '
            'BrowseTempButton
            '
            Me.BrowseTempButton.Location = New System.Drawing.Point(355, 420)
            Me.BrowseTempButton.Name = "BrowseTempButton"
            Me.BrowseTempButton.Size = New System.Drawing.Size(75, 23)
            Me.BrowseTempButton.TabIndex = 17
            Me.BrowseTempButton.Text = "Browse..."
            Me.BrowseTempButton.UseVisualStyleBackColor = True
            '
            'TempFolderTextBox
            '
            Me.TempFolderTextBox.Location = New System.Drawing.Point(9, 421)
            Me.TempFolderTextBox.Name = "TempFolderTextBox"
            Me.TempFolderTextBox.Size = New System.Drawing.Size(344, 20)
            Me.TempFolderTextBox.TabIndex = 16
            '
            'ServerOptionsView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.groupAssociation)
            Me.Controls.Add(Me.groupBoxConnections)
            Me.Controls.Add(Me.groupBoxTimeout)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.BrowseTempButton)
            Me.Controls.Add(Me.TempFolderTextBox)
            Me.Name = "ServerOptionsView"
            Me.Size = New System.Drawing.Size(439, 448)
            Me.groupBoxUserRole.ResumeLayout(False)
            Me.groupBoxUserRole.PerformLayout()
            Me.groupBoxProviderRole.ResumeLayout(False)
            Me.groupBoxProviderRole.PerformLayout()
            Me.groupBoxRoleSelect.ResumeLayout(False)
            Me.groupBoxRoleSelect.PerformLayout()
            Me.groupAssociation.ResumeLayout(False)
            Me.groupBoxRelationalQueries.ResumeLayout(False)
            Me.groupBoxRelationalQueries.PerformLayout()
            CType(Me.AnonymousClientPortNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBoxConnections.ResumeLayout(False)
            Me.groupBoxConnections.PerformLayout()
            CType(Me.MaxClientsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBoxTimeout.ResumeLayout(False)
            Me.groupBoxTimeout.PerformLayout()
            CType(Me.AddinsTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ReconnectTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ClientTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private WithEvents UseTlsSecurityCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents checkBoxEnableDefaultRoleSelection As System.Windows.Forms.CheckBox
        Private WithEvents radioButtonUserRoleTurnDown As System.Windows.Forms.RadioButton
        Private WithEvents radioButtonUserRoleAccept As System.Windows.Forms.RadioButton
        Private WithEvents groupBoxUserRole As System.Windows.Forms.GroupBox
        Private WithEvents radioButtonProviderRoleTurnDown As System.Windows.Forms.RadioButton
        Private WithEvents radioButtonProviderRoleAccept As System.Windows.Forms.RadioButton
        Private WithEvents groupBoxProviderRole As System.Windows.Forms.GroupBox
        Private WithEvents groupBoxRoleSelect As System.Windows.Forms.GroupBox
        Private WithEvents groupAssociation As System.Windows.Forms.GroupBox
        Private WithEvents groupBoxRelationalQueries As System.Windows.Forms.GroupBox
        Private WithEvents rbRelationalQueriesAlways As System.Windows.Forms.RadioButton
        Private WithEvents rbRelationalQueriesNegotiate As System.Windows.Forms.RadioButton
        Private WithEvents rbRelationalQueriesNever As System.Windows.Forms.RadioButton
        Private WithEvents AnonymousClientPortLabel As System.Windows.Forms.Label
        Private WithEvents AnonymousClientPortNumericUpDown As System.Windows.Forms.NumericUpDown
        Private WithEvents AllowAnonymousCMoveCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents groupBoxConnections As System.Windows.Forms.GroupBox
        Private WithEvents MaxClientsNumericUpDown As System.Windows.Forms.NumericUpDown
        Private WithEvents AllowMultipleCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents AllowAnonCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents label6 As System.Windows.Forms.Label
        Private WithEvents groupBoxTimeout As System.Windows.Forms.GroupBox
        Private WithEvents AddinsTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
        Private WithEvents label12 As System.Windows.Forms.Label
        Private WithEvents ReconnectTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
        Private WithEvents label11 As System.Windows.Forms.Label
        Private WithEvents ClientTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
        Private WithEvents label10 As System.Windows.Forms.Label
        Private WithEvents label1 As System.Windows.Forms.Label
        Private WithEvents BrowseTempButton As System.Windows.Forms.Button
        Private WithEvents TempFolderTextBox As System.Windows.Forms.TextBox

#End Region
    End Class
End Namespace
