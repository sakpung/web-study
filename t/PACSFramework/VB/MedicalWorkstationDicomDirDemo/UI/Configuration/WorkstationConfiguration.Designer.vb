Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class WorkstationConfiguration
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
		 Me.ConfigurationTabControl = New System.Windows.Forms.TabControl()
		 Me.WorkstationClientTabPage = New System.Windows.Forms.TabPage()
		 Me.PACSTabPage = New System.Windows.Forms.TabPage()
		 Me.LowerPanel = New System.Windows.Forms.Panel()
		 Me.SeparatorGroupBox = New System.Windows.Forms.GroupBox()
		 Me.SaveChangesButton = New System.Windows.Forms.Button()
		 Me.UpperPanel = New System.Windows.Forms.Panel()
		 Me.ControlsAreaPanel = New System.Windows.Forms.Panel()
		 Me.WorkstationToolStrip = New System.Windows.Forms.ToolStrip()
		 Me.WorkstationClientToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		 Me.PACSToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		 Me.GenericToolTip = New System.Windows.Forms.ToolTip(Me.components)
		 Me.ConfigurationTabControl.SuspendLayout()
		 Me.LowerPanel.SuspendLayout()
		 Me.UpperPanel.SuspendLayout()
		 Me.WorkstationToolStrip.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' ConfigurationTabControl
		 ' 
		 Me.ConfigurationTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
		 Me.ConfigurationTabControl.Controls.Add(Me.WorkstationClientTabPage)
		 Me.ConfigurationTabControl.Controls.Add(Me.PACSTabPage)
		 Me.ConfigurationTabControl.ItemSize = New System.Drawing.Size(116, 30)
		 Me.ConfigurationTabControl.Location = New System.Drawing.Point(341, 87)
		 Me.ConfigurationTabControl.Name = "ConfigurationTabControl"
		 Me.ConfigurationTabControl.SelectedIndex = 0
		 Me.ConfigurationTabControl.Size = New System.Drawing.Size(527, 415)
		 Me.ConfigurationTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
		 Me.ConfigurationTabControl.TabIndex = 6
		 ' 
		 ' WorkstationClientTabPage
		 ' 
		 Me.WorkstationClientTabPage.BackColor = System.Drawing.Color.SteelBlue
		 Me.WorkstationClientTabPage.Location = New System.Drawing.Point(4, 34)
		 Me.WorkstationClientTabPage.Name = "WorkstationClientTabPage"
		 Me.WorkstationClientTabPage.Padding = New System.Windows.Forms.Padding(3)
		 Me.WorkstationClientTabPage.Size = New System.Drawing.Size(519, 377)
		 Me.WorkstationClientTabPage.TabIndex = 0
		 Me.WorkstationClientTabPage.Text = "Workstation Client"
		 Me.WorkstationClientTabPage.UseVisualStyleBackColor = True
		 ' 
		 ' PACSTabPage
		 ' 
		 Me.PACSTabPage.BackColor = System.Drawing.Color.SteelBlue
		 Me.PACSTabPage.Location = New System.Drawing.Point(4, 34)
		 Me.PACSTabPage.Name = "PACSTabPage"
		 Me.PACSTabPage.Padding = New System.Windows.Forms.Padding(3)
		 Me.PACSTabPage.Size = New System.Drawing.Size(519, 377)
		 Me.PACSTabPage.TabIndex = 1
		 Me.PACSTabPage.Text = "PACS"
		 Me.PACSTabPage.UseVisualStyleBackColor = True
		 ' 
		 ' LowerPanel
		 ' 
		 Me.LowerPanel.Controls.Add(Me.SeparatorGroupBox)
		 Me.LowerPanel.Controls.Add(Me.SaveChangesButton)
		 Me.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom
		 Me.LowerPanel.Location = New System.Drawing.Point(0, 501)
		 Me.LowerPanel.Name = "LowerPanel"
		 Me.LowerPanel.Size = New System.Drawing.Size(922, 65)
		 Me.LowerPanel.TabIndex = 7
		 ' 
		 ' SeparatorGroupBox
		 ' 
		 Me.SeparatorGroupBox.Dock = System.Windows.Forms.DockStyle.Top
		 Me.SeparatorGroupBox.Location = New System.Drawing.Point(0, 0)
		 Me.SeparatorGroupBox.Name = "SeparatorGroupBox"
		 Me.SeparatorGroupBox.Size = New System.Drawing.Size(922, 3)
		 Me.SeparatorGroupBox.TabIndex = 0
		 Me.SeparatorGroupBox.TabStop = False
		 ' 
		 ' SaveChangesButton
		 ' 
		 Me.SaveChangesButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.SaveChangesButton.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.SaveChangesButton.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.SaveChangesButton.ForeColor = System.Drawing.Color.White
         Me.SaveChangesButton.Image = Resources.SaveConfig.ToBitmap()
       Me.SaveChangesButton.Location = New System.Drawing.Point(861, 3)
       Me.SaveChangesButton.Name = "SaveChangesButton"
       Me.SaveChangesButton.Size = New System.Drawing.Size(58, 58)
       Me.SaveChangesButton.TabIndex = 1
       Me.GenericToolTip.SetToolTip(Me.SaveChangesButton, "Save")
       Me.SaveChangesButton.UseVisualStyleBackColor = False
       ' 
       ' UpperPanel
       ' 
       Me.UpperPanel.Controls.Add(Me.ControlsAreaPanel)
       Me.UpperPanel.Controls.Add(Me.WorkstationToolStrip)
       Me.UpperPanel.Dock = System.Windows.Forms.DockStyle.Fill
       Me.UpperPanel.Location = New System.Drawing.Point(0, 0)
       Me.UpperPanel.Name = "UpperPanel"
       Me.UpperPanel.Size = New System.Drawing.Size(922, 566)
       Me.UpperPanel.TabIndex = 8
       ' 
       ' ControlsAreaPanel
       ' 
       Me.ControlsAreaPanel.Dock = System.Windows.Forms.DockStyle.Fill
       Me.ControlsAreaPanel.Location = New System.Drawing.Point(0, 55)
       Me.ControlsAreaPanel.Name = "ControlsAreaPanel"
       Me.ControlsAreaPanel.Size = New System.Drawing.Size(922, 511)
       Me.ControlsAreaPanel.TabIndex = 1
       ' 
       ' WorkstationToolStrip
       ' 
       Me.WorkstationToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WorkstationClientToolStripButton, Me.ToolStripSeparator1, Me.PACSToolStripButton, Me.ToolStripSeparator2})
       Me.WorkstationToolStrip.Location = New System.Drawing.Point(0, 0)
       Me.WorkstationToolStrip.Name = "WorkstationToolStrip"
       Me.WorkstationToolStrip.Size = New System.Drawing.Size(922, 55)
       Me.WorkstationToolStrip.TabIndex = 0
       Me.WorkstationToolStrip.Text = "Workstation Client"
       ' 
       ' WorkstationClientToolStripButton
       ' 
       Me.WorkstationClientToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
       Me.WorkstationClientToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.400001F, System.Drawing.FontStyle.Bold)
       Me.WorkstationClientToolStripButton.ForeColor = System.Drawing.Color.SteelBlue
         Me.WorkstationClientToolStripButton.Image = Resources.ClientConfig.ToBitmap()
       Me.WorkstationClientToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
       Me.WorkstationClientToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.WorkstationClientToolStripButton.Name = "WorkstationClientToolStripButton"
       Me.WorkstationClientToolStripButton.Size = New System.Drawing.Size(52, 52)
       Me.WorkstationClientToolStripButton.Text = "Workstation Client"
       ' 
       ' ToolStripSeparator1
       ' 
       Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
       Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
       ' 
       ' PACSToolStripButton
       ' 
       Me.PACSToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
       Me.PACSToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.400001F, System.Drawing.FontStyle.Bold)
       Me.PACSToolStripButton.ForeColor = System.Drawing.Color.SteelBlue
         Me.PACSToolStripButton.Image = Resources.PACSConfig.ToBitmap()
		 Me.PACSToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		 Me.PACSToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		 Me.PACSToolStripButton.Name = "PACSToolStripButton"
		 Me.PACSToolStripButton.Size = New System.Drawing.Size(52, 52)
		 Me.PACSToolStripButton.Text = "Remote PACS"
		 ' 
		 ' ToolStripSeparator2
		 ' 
		 Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		 Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
		 ' 
		 ' WorkstationConfiguration
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 14F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		 Me.Controls.Add(Me.LowerPanel)
		 Me.Controls.Add(Me.UpperPanel)
		 Me.Font = New System.Drawing.Font("Arial", 8F)
		 Me.ForeColor = System.Drawing.Color.White
		 Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		 Me.Name = "WorkstationConfiguration"
		 Me.Size = New System.Drawing.Size(922, 566)
		 Me.ConfigurationTabControl.ResumeLayout(False)
		 Me.LowerPanel.ResumeLayout(False)
		 Me.UpperPanel.ResumeLayout(False)
		 Me.UpperPanel.PerformLayout()
		 Me.WorkstationToolStrip.ResumeLayout(False)
		 Me.WorkstationToolStrip.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Protected SaveChangesButton As System.Windows.Forms.Button
	  Protected ConfigurationTabControl As System.Windows.Forms.TabControl
	  Protected WorkstationClientTabPage As System.Windows.Forms.TabPage
	  Protected PACSTabPage As System.Windows.Forms.TabPage
	  Protected LowerPanel As System.Windows.Forms.Panel
	  Protected SeparatorGroupBox As System.Windows.Forms.GroupBox
	  Protected UpperPanel As System.Windows.Forms.Panel
	  Protected ControlsAreaPanel As System.Windows.Forms.Panel
	  Protected WorkstationToolStrip As System.Windows.Forms.ToolStrip
	  Protected WorkstationClientToolStripButton As System.Windows.Forms.ToolStripButton
	  Protected PACSToolStripButton As System.Windows.Forms.ToolStripButton
	  Protected ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	  Protected GenericToolTip As System.Windows.Forms.ToolTip
	  Protected ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator


   End Class
End Namespace
