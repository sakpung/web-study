
Namespace CCOWDashboard
   Partial Class MainForm
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.showDetailedHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me.label1 = New System.Windows.Forms.Label()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.comboBoxScenarios = New System.Windows.Forms.ComboBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.buttonLaunchParticipant1 = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.linkLabelWebWarning = New System.Windows.Forms.LinkLabel()
         Me.labelWebWarning = New System.Windows.Forms.Label()
         Me.panelWebParticipant1 = New System.Windows.Forms.Panel()
         Me.checkBoxWebSSO1 = New System.Windows.Forms.CheckBox()
         Me.buttonLaunchWebParticipant1 = New System.Windows.Forms.Button()
         Me.panelWebParticipant2 = New System.Windows.Forms.Panel()
         Me.checkBoxWebSSO2 = New System.Windows.Forms.CheckBox()
         Me.buttonLaunchWebParticipant2 = New System.Windows.Forms.Button()
         Me.panelParticipant3 = New System.Windows.Forms.Panel()
         Me.checkBoxSSO3 = New System.Windows.Forms.CheckBox()
         Me.buttonLaunchParticipant3 = New System.Windows.Forms.Button()
         Me.panelParticipant2 = New System.Windows.Forms.Panel()
         Me.checkBoxSSO2 = New System.Windows.Forms.CheckBox()
         Me.buttonLaunchParticipant2 = New System.Windows.Forms.Button()
         Me.panelParticipant1 = New System.Windows.Forms.Panel()
         Me.checkBoxSSO1 = New System.Windows.Forms.CheckBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.menuStrip1.SuspendLayout()
         Me.panel1.SuspendLayout()
         Me.groupBox1.SuspendLayout()
         Me.panelWebParticipant1.SuspendLayout()
         Me.panelWebParticipant2.SuspendLayout()
         Me.panelParticipant3.SuspendLayout()
         Me.panelParticipant2.SuspendLayout()
         Me.panelParticipant1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' menuStrip1
         ' 
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.helpToolStripMenuItem})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Size = New System.Drawing.Size(548, 24)
         Me.menuStrip1.TabIndex = 20
         Me.menuStrip1.Text = "menuStrip1"
         ' 
         ' fileToolStripMenuItem
         ' 
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         ' 
         ' exitToolStripMenuItem
         ' 
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
         Me.exitToolStripMenuItem.Text = "&Exit"
         ' 
         ' helpToolStripMenuItem
         ' 
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showDetailedHelpToolStripMenuItem, Me.aboutToolStripMenuItem1})
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "&Help"
         ' 
         ' showDetailedHelpToolStripMenuItem
         ' 
         Me.showDetailedHelpToolStripMenuItem.Name = "showDetailedHelpToolStripMenuItem"
         Me.showDetailedHelpToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
         Me.showDetailedHelpToolStripMenuItem.Text = "Show Detailed Help..."
         ' 
         ' aboutToolStripMenuItem1
         ' 
         Me.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1"
         Me.aboutToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
         Me.aboutToolStripMenuItem1.Text = "About..."
         ' 
         ' label1
         ' 
         Me.label1.Dock = System.Windows.Forms.DockStyle.Top
         Me.label1.Location = New System.Drawing.Point(0, 24)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(548, 103)
         Me.label1.TabIndex = 21
         Me.label1.Text = resources.GetString("label1.Text")
         ' 
         ' panel1
         ' 
         Me.panel1.Controls.Add(Me.comboBoxScenarios)
         Me.panel1.Controls.Add(Me.label2)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel1.Location = New System.Drawing.Point(0, 127)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(548, 35)
         Me.panel1.TabIndex = 22
         ' 
         ' comboBoxScenarios
         ' 
         Me.comboBoxScenarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxScenarios.FormattingEnabled = True
         Me.comboBoxScenarios.Location = New System.Drawing.Point(86, 8)
         Me.comboBoxScenarios.Name = "comboBoxScenarios"
         Me.comboBoxScenarios.Size = New System.Drawing.Size(456, 21)
         Me.comboBoxScenarios.TabIndex = 1
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.label2.Location = New System.Drawing.Point(4, 16)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(76, 13)
         Me.label2.TabIndex = 0
         Me.label2.Text = "1. Scenario:"
         ' 
         ' buttonLaunchParticipant1
         ' 
         Me.buttonLaunchParticipant1.BackColor = System.Drawing.Color.Transparent
         Me.buttonLaunchParticipant1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.buttonLaunchParticipant1.ForeColor = System.Drawing.SystemColors.ControlText
         Me.buttonLaunchParticipant1.Location = New System.Drawing.Point(2, 4)
         Me.buttonLaunchParticipant1.Name = "buttonLaunchParticipant1"
         Me.buttonLaunchParticipant1.Size = New System.Drawing.Size(150, 22)
         Me.buttonLaunchParticipant1.TabIndex = 3
         Me.buttonLaunchParticipant1.Text = "Participant Demo 1"
         Me.buttonLaunchParticipant1.UseVisualStyleBackColor = False
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.linkLabelWebWarning)
         Me.groupBox1.Controls.Add(Me.labelWebWarning)
         Me.groupBox1.Controls.Add(Me.panelWebParticipant1)
         Me.groupBox1.Controls.Add(Me.panelWebParticipant2)
         Me.groupBox1.Controls.Add(Me.panelParticipant3)
         Me.groupBox1.Controls.Add(Me.panelParticipant2)
         Me.groupBox1.Controls.Add(Me.panelParticipant1)
         Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.groupBox1.Location = New System.Drawing.Point(3, 243)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(532, 175)
         Me.groupBox1.TabIndex = 26
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "2. Launch Participant Demo"
         ' 
         ' linkLabelWebWarning
         ' 
         Me.linkLabelWebWarning.AutoSize = True
         Me.linkLabelWebWarning.LinkArea = New System.Windows.Forms.LinkArea(33, 10)
         Me.linkLabelWebWarning.Location = New System.Drawing.Point(14, 156)
         Me.linkLabelWebWarning.Name = "linkLabelWebWarning"
         Me.linkLabelWebWarning.Size = New System.Drawing.Size(387, 17)
         Me.linkLabelWebWarning.TabIndex = 11
         Me.linkLabelWebWarning.TabStop = True
         Me.linkLabelWebWarning.Text = "Failed to reach Web Client Demo, Click here to run the Configuration tool."
         Me.linkLabelWebWarning.UseCompatibleTextRendering = True
         Me.linkLabelWebWarning.Visible = False
         ' 
         ' labelWebWarning
         ' 
         Me.labelWebWarning.AutoSize = True
         Me.labelWebWarning.Location = New System.Drawing.Point(11, 156)
         Me.labelWebWarning.Name = "labelWebWarning"
         Me.labelWebWarning.Size = New System.Drawing.Size(424, 13)
         Me.labelWebWarning.TabIndex = 10
         Me.labelWebWarning.Text = "Run CCOW Dashboard as Administrator to enable Web Paricipant Demos."
         Me.labelWebWarning.Visible = False
         ' 
         ' panelWebParticipant1
         ' 
         Me.panelWebParticipant1.BackColor = System.Drawing.Color.DarkBlue
         Me.panelWebParticipant1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panelWebParticipant1.Controls.Add(Me.checkBoxWebSSO1)
         Me.panelWebParticipant1.Controls.Add(Me.buttonLaunchWebParticipant1)
         Me.panelWebParticipant1.ForeColor = System.Drawing.Color.Red
         Me.panelWebParticipant1.Location = New System.Drawing.Point(83, 90)
         Me.panelWebParticipant1.Name = "panelWebParticipant1"
         Me.panelWebParticipant1.Size = New System.Drawing.Size(161, 58)
         Me.panelWebParticipant1.TabIndex = 8
         ' 
         ' checkBoxWebSSO1
         ' 
         Me.checkBoxWebSSO1.AutoSize = True
         Me.checkBoxWebSSO1.BackColor = System.Drawing.Color.Transparent
         Me.checkBoxWebSSO1.ForeColor = System.Drawing.SystemColors.Control
         Me.checkBoxWebSSO1.Location = New System.Drawing.Point(3, 32)
         Me.checkBoxWebSSO1.Name = "checkBoxWebSSO1"
         Me.checkBoxWebSSO1.Size = New System.Drawing.Size(127, 17)
         Me.checkBoxWebSSO1.TabIndex = 5
         Me.checkBoxWebSSO1.Text = "Launch With SSO"
         Me.checkBoxWebSSO1.UseVisualStyleBackColor = False
         ' 
         ' buttonLaunchWebParticipant1
         ' 
         Me.buttonLaunchWebParticipant1.BackColor = System.Drawing.Color.Transparent
         Me.buttonLaunchWebParticipant1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.buttonLaunchWebParticipant1.ForeColor = System.Drawing.SystemColors.ControlText
         Me.buttonLaunchWebParticipant1.Location = New System.Drawing.Point(2, 4)
         Me.buttonLaunchWebParticipant1.Name = "buttonLaunchWebParticipant1"
         Me.buttonLaunchWebParticipant1.Size = New System.Drawing.Size(154, 22)
         Me.buttonLaunchWebParticipant1.TabIndex = 3
         Me.buttonLaunchWebParticipant1.Text = "Web Participant Demo 1"
         Me.buttonLaunchWebParticipant1.UseVisualStyleBackColor = False
         ' 
         ' panelWebParticipant2
         ' 
         Me.panelWebParticipant2.BackColor = System.Drawing.Color.Purple
         Me.panelWebParticipant2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panelWebParticipant2.Controls.Add(Me.checkBoxWebSSO2)
         Me.panelWebParticipant2.Controls.Add(Me.buttonLaunchWebParticipant2)
         Me.panelWebParticipant2.ForeColor = System.Drawing.Color.Red
         Me.panelWebParticipant2.Location = New System.Drawing.Point(275, 90)
         Me.panelWebParticipant2.Name = "panelWebParticipant2"
         Me.panelWebParticipant2.Size = New System.Drawing.Size(161, 58)
         Me.panelWebParticipant2.TabIndex = 9
         ' 
         ' checkBoxWebSSO2
         ' 
         Me.checkBoxWebSSO2.AutoSize = True
         Me.checkBoxWebSSO2.BackColor = System.Drawing.Color.Transparent
         Me.checkBoxWebSSO2.ForeColor = System.Drawing.SystemColors.Control
         Me.checkBoxWebSSO2.Location = New System.Drawing.Point(3, 32)
         Me.checkBoxWebSSO2.Name = "checkBoxWebSSO2"
         Me.checkBoxWebSSO2.Size = New System.Drawing.Size(127, 17)
         Me.checkBoxWebSSO2.TabIndex = 5
         Me.checkBoxWebSSO2.Text = "Launch With SSO"
         Me.checkBoxWebSSO2.UseVisualStyleBackColor = False
         ' 
         ' buttonLaunchWebParticipant2
         ' 
         Me.buttonLaunchWebParticipant2.BackColor = System.Drawing.Color.Transparent
         Me.buttonLaunchWebParticipant2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.buttonLaunchWebParticipant2.ForeColor = System.Drawing.SystemColors.ControlText
         Me.buttonLaunchWebParticipant2.Location = New System.Drawing.Point(2, 4)
         Me.buttonLaunchWebParticipant2.Name = "buttonLaunchWebParticipant2"
         Me.buttonLaunchWebParticipant2.Size = New System.Drawing.Size(154, 22)
         Me.buttonLaunchWebParticipant2.TabIndex = 3
         Me.buttonLaunchWebParticipant2.Text = "Web Participant Demo 2"
         Me.buttonLaunchWebParticipant2.UseVisualStyleBackColor = False
         ' 
         ' panelParticipant3
         ' 
         Me.panelParticipant3.BackColor = System.Drawing.Color.Blue
         Me.panelParticipant3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panelParticipant3.Controls.Add(Me.checkBoxSSO3)
         Me.panelParticipant3.Controls.Add(Me.buttonLaunchParticipant3)
         Me.panelParticipant3.ForeColor = System.Drawing.Color.Red
         Me.panelParticipant3.Location = New System.Drawing.Point(370, 15)
         Me.panelParticipant3.Name = "panelParticipant3"
         Me.panelParticipant3.Size = New System.Drawing.Size(156, 58)
         Me.panelParticipant3.TabIndex = 8
         ' 
         ' checkBoxSSO3
         ' 
         Me.checkBoxSSO3.AutoSize = True
         Me.checkBoxSSO3.BackColor = System.Drawing.Color.Transparent
         Me.checkBoxSSO3.Checked = True
         Me.checkBoxSSO3.CheckState = System.Windows.Forms.CheckState.Checked
         Me.checkBoxSSO3.ForeColor = System.Drawing.SystemColors.Control
         Me.checkBoxSSO3.Location = New System.Drawing.Point(2, 32)
         Me.checkBoxSSO3.Name = "checkBoxSSO3"
         Me.checkBoxSSO3.Size = New System.Drawing.Size(127, 17)
         Me.checkBoxSSO3.TabIndex = 5
         Me.checkBoxSSO3.Text = "Launch With SSO"
         Me.checkBoxSSO3.UseVisualStyleBackColor = False
         ' 
         ' buttonLaunchParticipant3
         ' 
         Me.buttonLaunchParticipant3.BackColor = System.Drawing.Color.Transparent
         Me.buttonLaunchParticipant3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.buttonLaunchParticipant3.ForeColor = System.Drawing.SystemColors.ControlText
         Me.buttonLaunchParticipant3.Location = New System.Drawing.Point(2, 4)
         Me.buttonLaunchParticipant3.Name = "buttonLaunchParticipant3"
         Me.buttonLaunchParticipant3.Size = New System.Drawing.Size(150, 22)
         Me.buttonLaunchParticipant3.TabIndex = 3
         Me.buttonLaunchParticipant3.Text = "Participant Demo 3"
         Me.buttonLaunchParticipant3.UseVisualStyleBackColor = False
         ' 
         ' panelParticipant2
         ' 
         Me.panelParticipant2.BackColor = System.Drawing.Color.Green
         Me.panelParticipant2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panelParticipant2.Controls.Add(Me.checkBoxSSO2)
         Me.panelParticipant2.Controls.Add(Me.buttonLaunchParticipant2)
         Me.panelParticipant2.ForeColor = System.Drawing.Color.Red
         Me.panelParticipant2.Location = New System.Drawing.Point(188, 15)
         Me.panelParticipant2.Name = "panelParticipant2"
         Me.panelParticipant2.Size = New System.Drawing.Size(156, 58)
         Me.panelParticipant2.TabIndex = 7
         ' 
         ' checkBoxSSO2
         ' 
         Me.checkBoxSSO2.AutoSize = True
         Me.checkBoxSSO2.BackColor = System.Drawing.Color.Transparent
         Me.checkBoxSSO2.Checked = True
         Me.checkBoxSSO2.CheckState = System.Windows.Forms.CheckState.Checked
         Me.checkBoxSSO2.ForeColor = System.Drawing.SystemColors.Control
         Me.checkBoxSSO2.Location = New System.Drawing.Point(3, 32)
         Me.checkBoxSSO2.Name = "checkBoxSSO2"
         Me.checkBoxSSO2.Size = New System.Drawing.Size(127, 17)
         Me.checkBoxSSO2.TabIndex = 5
         Me.checkBoxSSO2.Text = "Launch With SSO"
         Me.checkBoxSSO2.UseVisualStyleBackColor = False
         ' 
         ' buttonLaunchParticipant2
         ' 
         Me.buttonLaunchParticipant2.BackColor = System.Drawing.Color.Transparent
         Me.buttonLaunchParticipant2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.buttonLaunchParticipant2.ForeColor = System.Drawing.SystemColors.ControlText
         Me.buttonLaunchParticipant2.Location = New System.Drawing.Point(2, 4)
         Me.buttonLaunchParticipant2.Name = "buttonLaunchParticipant2"
         Me.buttonLaunchParticipant2.Size = New System.Drawing.Size(150, 22)
         Me.buttonLaunchParticipant2.TabIndex = 3
         Me.buttonLaunchParticipant2.Text = "Participant Demo 2"
         Me.buttonLaunchParticipant2.UseVisualStyleBackColor = False
         ' 
         ' panelParticipant1
         ' 
         Me.panelParticipant1.BackColor = System.Drawing.Color.Red
         Me.panelParticipant1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panelParticipant1.Controls.Add(Me.checkBoxSSO1)
         Me.panelParticipant1.Controls.Add(Me.buttonLaunchParticipant1)
         Me.panelParticipant1.ForeColor = System.Drawing.Color.Red
         Me.panelParticipant1.Location = New System.Drawing.Point(6, 15)
         Me.panelParticipant1.Name = "panelParticipant1"
         Me.panelParticipant1.Size = New System.Drawing.Size(156, 58)
         Me.panelParticipant1.TabIndex = 6
         ' 
         ' checkBoxSSO1
         ' 
         Me.checkBoxSSO1.AutoSize = True
         Me.checkBoxSSO1.BackColor = System.Drawing.Color.Transparent
         Me.checkBoxSSO1.Checked = True
         Me.checkBoxSSO1.CheckState = System.Windows.Forms.CheckState.Checked
         Me.checkBoxSSO1.ForeColor = System.Drawing.SystemColors.Control
         Me.checkBoxSSO1.Location = New System.Drawing.Point(4, 33)
         Me.checkBoxSSO1.Name = "checkBoxSSO1"
         Me.checkBoxSSO1.Size = New System.Drawing.Size(127, 17)
         Me.checkBoxSSO1.TabIndex = 4
         Me.checkBoxSSO1.Text = "Launch With SSO"
         Me.checkBoxSSO1.UseVisualStyleBackColor = False
         ' 
         ' label3
         ' 
         Me.label3.Dock = System.Windows.Forms.DockStyle.Top
         Me.label3.Location = New System.Drawing.Point(0, 162)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(548, 74)
         Me.label3.TabIndex = 23
         Me.label3.Text = resources.GetString("label3.Text")
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(548, 425)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.panel1)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.menuStrip1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "MainForm"
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.panel1.ResumeLayout(False)
         Me.panel1.PerformLayout()
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.panelWebParticipant1.ResumeLayout(False)
         Me.panelWebParticipant1.PerformLayout()
         Me.panelWebParticipant2.ResumeLayout(False)
         Me.panelWebParticipant2.PerformLayout()
         Me.panelParticipant3.ResumeLayout(False)
         Me.panelParticipant3.PerformLayout()
         Me.panelParticipant2.ResumeLayout(False)
         Me.panelParticipant2.PerformLayout()
         Me.panelParticipant1.ResumeLayout(False)
         Me.panelParticipant1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private menuStrip1 As System.Windows.Forms.MenuStrip
      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private label1 As System.Windows.Forms.Label
      Private panel1 As System.Windows.Forms.Panel
      Private WithEvents comboBoxScenarios As System.Windows.Forms.ComboBox
      Private label2 As System.Windows.Forms.Label
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label3 As System.Windows.Forms.Label
      Private WithEvents buttonLaunchParticipant1 As System.Windows.Forms.Button
      Private panelParticipant1 As System.Windows.Forms.Panel
      Private panelParticipant3 As System.Windows.Forms.Panel
      Private WithEvents buttonLaunchParticipant3 As System.Windows.Forms.Button
      Private panelParticipant2 As System.Windows.Forms.Panel
      Private WithEvents buttonLaunchParticipant2 As System.Windows.Forms.Button
      Private checkBoxSSO1 As System.Windows.Forms.CheckBox
      Private checkBoxSSO2 As System.Windows.Forms.CheckBox
      Private checkBoxSSO3 As System.Windows.Forms.CheckBox
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents showDetailedHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private panelWebParticipant1 As System.Windows.Forms.Panel
      Private checkBoxWebSSO1 As System.Windows.Forms.CheckBox
      Private buttonLaunchWebParticipant1 As System.Windows.Forms.Button
      Private panelWebParticipant2 As System.Windows.Forms.Panel
      Private checkBoxWebSSO2 As System.Windows.Forms.CheckBox
      Private buttonLaunchWebParticipant2 As System.Windows.Forms.Button
      Private labelWebWarning As System.Windows.Forms.Label
      Private linkLabelWebWarning As System.Windows.Forms.LinkLabel
   End Class
End Namespace
