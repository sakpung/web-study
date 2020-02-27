Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class GeneralSettingsView
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralSettingsView))
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me.IpTypePanel = New System.Windows.Forms.Panel()
         Me.IpBothCheckBox = New System.Windows.Forms.RadioButton()
         Me.IpV6CheckBox = New System.Windows.Forms.RadioButton()
         Me.IpV4CheckBox = New System.Windows.Forms.RadioButton()
         Me.label14 = New System.Windows.Forms.Label()
         Me.ImplementationVersionTextBox = New System.Windows.Forms.TextBox()
         Me.label13 = New System.Windows.Forms.Label()
         Me.ImplementationClassTextBox = New System.Windows.Forms.TextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.AeTitleTextBox = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.PortNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.IpAddressComboBox = New System.Windows.Forms.ComboBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.StartModeComboBox = New System.Windows.Forms.ComboBox()
         Me.label7 = New System.Windows.Forms.Label()
         Me.ServiceDescriptionTextBox = New System.Windows.Forms.TextBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.ServiceDisplayNameTextBox = New System.Windows.Forms.TextBox()
         Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
         Me.AddServerToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me.DeleteServerToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me.AETitleErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
         Me.TestServiceButton = New System.Windows.Forms.Button()
         Me.groupBox3.SuspendLayout()
         Me.IpTypePanel.SuspendLayout()
         CType(Me.PortNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.groupBox2.SuspendLayout()
         Me.toolStrip1.SuspendLayout()
         CType(Me.AETitleErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         'groupBox3
         '
         Me.groupBox3.Controls.Add(Me.IpTypePanel)
         Me.groupBox3.Controls.Add(Me.label14)
         Me.groupBox3.Controls.Add(Me.ImplementationVersionTextBox)
         Me.groupBox3.Controls.Add(Me.label13)
         Me.groupBox3.Controls.Add(Me.ImplementationClassTextBox)
         Me.groupBox3.Controls.Add(Me.label1)
         Me.groupBox3.Controls.Add(Me.AeTitleTextBox)
         Me.groupBox3.Controls.Add(Me.label2)
         Me.groupBox3.Controls.Add(Me.PortNumericUpDown)
         Me.groupBox3.Controls.Add(Me.IpAddressComboBox)
         Me.groupBox3.Controls.Add(Me.label3)
         Me.groupBox3.Location = New System.Drawing.Point(3, 46)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(319, 228)
         Me.groupBox3.TabIndex = 28
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "DICOM Server:"
         '
         'IpTypePanel
         '
         Me.IpTypePanel.Controls.Add(Me.IpBothCheckBox)
         Me.IpTypePanel.Controls.Add(Me.IpV6CheckBox)
         Me.IpTypePanel.Controls.Add(Me.IpV4CheckBox)
         Me.IpTypePanel.Location = New System.Drawing.Point(106, 69)
         Me.IpTypePanel.Name = "IpTypePanel"
         Me.IpTypePanel.Size = New System.Drawing.Size(197, 26)
         Me.IpTypePanel.TabIndex = 27
         '
         'IpBothCheckBox
         '
         Me.IpBothCheckBox.AutoSize = True
         Me.IpBothCheckBox.Location = New System.Drawing.Point(112, 3)
         Me.IpBothCheckBox.Name = "IpBothCheckBox"
         Me.IpBothCheckBox.Size = New System.Drawing.Size(47, 17)
         Me.IpBothCheckBox.TabIndex = 2
         Me.IpBothCheckBox.Text = "Both"
         Me.IpBothCheckBox.UseVisualStyleBackColor = True
         '
         'IpV6CheckBox
         '
         Me.IpV6CheckBox.AutoSize = True
         Me.IpV6CheckBox.Location = New System.Drawing.Point(58, 3)
         Me.IpV6CheckBox.Name = "IpV6CheckBox"
         Me.IpV6CheckBox.Size = New System.Drawing.Size(47, 17)
         Me.IpV6CheckBox.TabIndex = 1
         Me.IpV6CheckBox.Text = "IPv6"
         Me.IpV6CheckBox.UseVisualStyleBackColor = True
         '
         'IpV4CheckBox
         '
         Me.IpV4CheckBox.AutoSize = True
         Me.IpV4CheckBox.Location = New System.Drawing.Point(4, 3)
         Me.IpV4CheckBox.Name = "IpV4CheckBox"
         Me.IpV4CheckBox.Size = New System.Drawing.Size(47, 17)
         Me.IpV4CheckBox.TabIndex = 0
         Me.IpV4CheckBox.Text = "IPv4"
         Me.IpV4CheckBox.UseVisualStyleBackColor = True
         '
         'label14
         '
         Me.label14.AutoSize = True
         Me.label14.Location = New System.Drawing.Point(15, 180)
         Me.label14.Name = "label14"
         Me.label14.Size = New System.Drawing.Size(150, 13)
         Me.label14.TabIndex = 25
         Me.label14.Text = "&Implementation Version Name:"
         '
         'ImplementationVersionTextBox
         '
         Me.ImplementationVersionTextBox.Location = New System.Drawing.Point(18, 200)
         Me.ImplementationVersionTextBox.Name = "ImplementationVersionTextBox"
         Me.ImplementationVersionTextBox.Size = New System.Drawing.Size(207, 20)
         Me.ImplementationVersionTextBox.TabIndex = 26
         '
         'label13
         '
         Me.label13.AutoSize = True
         Me.label13.Location = New System.Drawing.Point(15, 129)
         Me.label13.Name = "label13"
         Me.label13.Size = New System.Drawing.Size(131, 13)
         Me.label13.TabIndex = 23
         Me.label13.Text = "&Implementation Class UID:"
         '
         'ImplementationClassTextBox
         '
         Me.ImplementationClassTextBox.Location = New System.Drawing.Point(18, 151)
         Me.ImplementationClassTextBox.Name = "ImplementationClassTextBox"
         Me.ImplementationClassTextBox.Size = New System.Drawing.Size(207, 20)
         Me.ImplementationClassTextBox.TabIndex = 24
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(12, 20)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(47, 13)
         Me.label1.TabIndex = 1
         Me.label1.Text = "&AE Title:"
         '
         'AeTitleTextBox
         '
         Me.AeTitleTextBox.Location = New System.Drawing.Point(106, 17)
         Me.AeTitleTextBox.Name = "AeTitleTextBox"
         Me.AeTitleTextBox.Size = New System.Drawing.Size(197, 20)
         Me.AeTitleTextBox.TabIndex = 2
         '
         'label2
         '
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(12, 103)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(29, 13)
         Me.label2.TabIndex = 3
         Me.label2.Text = "Port:"
         '
         'PortNumericUpDown
         '
         Me.PortNumericUpDown.Location = New System.Drawing.Point(106, 101)
         Me.PortNumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
         Me.PortNumericUpDown.Name = "PortNumericUpDown"
         Me.PortNumericUpDown.Size = New System.Drawing.Size(57, 20)
         Me.PortNumericUpDown.TabIndex = 4
         '
         'IpAddressComboBox
         '
         Me.IpAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.IpAddressComboBox.FormattingEnabled = True
         Me.IpAddressComboBox.Location = New System.Drawing.Point(106, 44)
         Me.IpAddressComboBox.Name = "IpAddressComboBox"
         Me.IpAddressComboBox.Size = New System.Drawing.Size(197, 21)
         Me.IpAddressComboBox.TabIndex = 14
         '
         'label3
         '
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(12, 47)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(61, 13)
         Me.label3.TabIndex = 5
         Me.label3.Text = "IP Address:"
         '
         'groupBox2
         '
         Me.groupBox2.Controls.Add(Me.TestServiceButton)
         Me.groupBox2.Controls.Add(Me.StartModeComboBox)
         Me.groupBox2.Controls.Add(Me.label7)
         Me.groupBox2.Controls.Add(Me.ServiceDescriptionTextBox)
         Me.groupBox2.Controls.Add(Me.label5)
         Me.groupBox2.Controls.Add(Me.label4)
         Me.groupBox2.Controls.Add(Me.ServiceDisplayNameTextBox)
         Me.groupBox2.Location = New System.Drawing.Point(328, 46)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(314, 228)
         Me.groupBox2.TabIndex = 27
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Windows Service:"
         '
         'StartModeComboBox
         '
         Me.StartModeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.StartModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.StartModeComboBox.FormattingEnabled = True
         Me.StartModeComboBox.Location = New System.Drawing.Point(96, 130)
         Me.StartModeComboBox.Name = "StartModeComboBox"
         Me.StartModeComboBox.Size = New System.Drawing.Size(207, 21)
         Me.StartModeComboBox.TabIndex = 25
         '
         'label7
         '
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(18, 133)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(62, 13)
         Me.label7.TabIndex = 24
         Me.label7.Text = "Start Mode:"
         '
         'ServiceDescriptionTextBox
         '
         Me.ServiceDescriptionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.ServiceDescriptionTextBox.Location = New System.Drawing.Point(18, 69)
         Me.ServiceDescriptionTextBox.Multiline = True
         Me.ServiceDescriptionTextBox.Name = "ServiceDescriptionTextBox"
         Me.ServiceDescriptionTextBox.Size = New System.Drawing.Size(285, 52)
         Me.ServiceDescriptionTextBox.TabIndex = 23
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(15, 53)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(63, 13)
         Me.label5.TabIndex = 20
         Me.label5.Text = "Description:"
         '
         'label4
         '
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(15, 23)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(75, 13)
         Me.label4.TabIndex = 21
         Me.label4.Text = "&Display Name:"
         '
         'ServiceDisplayNameTextBox
         '
         Me.ServiceDisplayNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.ServiceDisplayNameTextBox.Location = New System.Drawing.Point(96, 20)
         Me.ServiceDisplayNameTextBox.Name = "ServiceDisplayNameTextBox"
         Me.ServiceDisplayNameTextBox.Size = New System.Drawing.Size(207, 20)
         Me.ServiceDisplayNameTextBox.TabIndex = 22
         '
         'toolStrip1
         '
         Me.toolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
         Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddServerToolStripButton, Me.DeleteServerToolStripButton})
         Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
         Me.toolStrip1.Name = "toolStrip1"
         Me.toolStrip1.Size = New System.Drawing.Size(651, 39)
         Me.toolStrip1.TabIndex = 29
         Me.toolStrip1.Text = "toolStrip1"
         '
         'AddServerToolStripButton
         '
         Me.AddServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.AddServerToolStripButton.Image = CType(resources.GetObject("AddServerToolStripButton.Image"), System.Drawing.Image)
         Me.AddServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.AddServerToolStripButton.Name = "AddServerToolStripButton"
         Me.AddServerToolStripButton.Size = New System.Drawing.Size(36, 36)
         Me.AddServerToolStripButton.Text = "Add Server"
         Me.AddServerToolStripButton.ToolTipText = "Add Server"
         '
         'DeleteServerToolStripButton
         '
         Me.DeleteServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.DeleteServerToolStripButton.Image = CType(resources.GetObject("DeleteServerToolStripButton.Image"), System.Drawing.Image)
         Me.DeleteServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.DeleteServerToolStripButton.Name = "DeleteServerToolStripButton"
         Me.DeleteServerToolStripButton.Size = New System.Drawing.Size(36, 36)
         Me.DeleteServerToolStripButton.Text = "Delete Server"
         Me.DeleteServerToolStripButton.ToolTipText = "Delete Server"
         '
         'AETitleErrorProvider
         '
         Me.AETitleErrorProvider.ContainerControl = Me
         '
         'TestServiceButton
         '
         Me.TestServiceButton.Location = New System.Drawing.Point(181, 180)
         Me.TestServiceButton.Name = "TestServiceButton"
         Me.TestServiceButton.Size = New System.Drawing.Size(122, 23)
         Me.TestServiceButton.TabIndex = 27
         Me.TestServiceButton.Text = "Test DICOM Server"
         Me.TestServiceButton.UseVisualStyleBackColor = True
         '
         'GeneralSettingsView
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.toolStrip1)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.groupBox2)
         Me.MinimumSize = New System.Drawing.Size(651, 277)
         Me.Name = "GeneralSettingsView"
         Me.Size = New System.Drawing.Size(651, 277)
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.IpTypePanel.ResumeLayout(False)
         Me.IpTypePanel.PerformLayout()
         CType(Me.PortNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.toolStrip1.ResumeLayout(False)
         Me.toolStrip1.PerformLayout()
         CType(Me.AETitleErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private groupBox3 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private AeTitleTextBox As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private PortNumericUpDown As System.Windows.Forms.NumericUpDown
      Private IpAddressComboBox As System.Windows.Forms.ComboBox
      Private label3 As System.Windows.Forms.Label
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private StartModeComboBox As System.Windows.Forms.ComboBox
      Private label7 As System.Windows.Forms.Label
      Private ServiceDescriptionTextBox As System.Windows.Forms.TextBox
      Private label5 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private ServiceDisplayNameTextBox As System.Windows.Forms.TextBox
      Private label14 As System.Windows.Forms.Label
      Private ImplementationVersionTextBox As System.Windows.Forms.TextBox
      Private label13 As System.Windows.Forms.Label
      Private ImplementationClassTextBox As System.Windows.Forms.TextBox
      Private toolStrip1 As System.Windows.Forms.ToolStrip
      Public AddServerToolStripButton As System.Windows.Forms.ToolStripButton
      Public DeleteServerToolStripButton As System.Windows.Forms.ToolStripButton
      Private AETitleErrorProvider As System.Windows.Forms.ErrorProvider
      Private IpTypePanel As System.Windows.Forms.Panel
      Private IpBothCheckBox As System.Windows.Forms.RadioButton
      Private IpV6CheckBox As System.Windows.Forms.RadioButton
      Private IpV4CheckBox As System.Windows.Forms.RadioButton
      Private WithEvents TestServiceButton As System.Windows.Forms.Button

   End Class
End Namespace
