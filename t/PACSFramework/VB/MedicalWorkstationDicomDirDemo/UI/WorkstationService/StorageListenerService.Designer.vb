Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class StorageListenerService
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
		 Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
		 Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		 Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		 Me.StartAddInsToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
		 Me.toolStripButton1 = New System.Windows.Forms.ToolStripSeparator()
		 Me.ServiceATitleLabel = New System.Windows.Forms.Label()
		 Me.IpAddressLabel = New System.Windows.Forms.Label()
		 Me.ServerPortLabel = New System.Windows.Forms.Label()
		 Me.IpLabel = New System.Windows.Forms.Label()
		 Me.PortLabel = New System.Windows.Forms.Label()
		 Me.LEADStorageServiceAELabel = New System.Windows.Forms.Label()
		 Me.ServiceTabControl = New System.Windows.Forms.TabControl()
		 Me.AeTitlesTabPage = New System.Windows.Forms.TabPage()
		 Me.ClientsToolStripContainer = New System.Windows.Forms.ToolStripContainer()
		 Me.AeTitlesListView = New System.Windows.Forms.ListView()
		 Me.AeTitleColumnHeader = New System.Windows.Forms.ColumnHeader()
		 Me.HostnameColumnHeader = New System.Windows.Forms.ColumnHeader()
		 Me.PortColumnHeader = New System.Windows.Forms.ColumnHeader()
		 Me.HeaderSecurePortColumnHeader = New System.Windows.Forms.ColumnHeader()
		 Me.AeTitleToolStrip = New System.Windows.Forms.ToolStrip()
		 Me.WorkstationDisplayNameLabel = New System.Windows.Forms.Label()
		 Me.AddAeTitleToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.EditAeTitleToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.DeleteAeTitleToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.EditServerToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.ToolStripButtonStart = New System.Windows.Forms.ToolStripButton()
		 Me.PauseToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.StopToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.AddServerToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.DeleteServerToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.EventLogViewerToolStripButton = New System.Windows.Forms.ToolStripButton()
		 Me.MainToolStrip.SuspendLayout()
		 Me.ServiceTabControl.SuspendLayout()
		 Me.AeTitlesTabPage.SuspendLayout()
		 Me.ClientsToolStripContainer.ContentPanel.SuspendLayout()
		 Me.ClientsToolStripContainer.TopToolStripPanel.SuspendLayout()
		 Me.ClientsToolStripContainer.SuspendLayout()
		 Me.AeTitleToolStrip.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' MainToolStrip
		 ' 
		 Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
		 Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.EditServerToolStripButton, Me.ToolStripSeparator1, Me.ToolStripButtonStart, Me.PauseToolStripButton, Me.StopToolStripButton, Me.ToolStripSeparator2, Me.AddServerToolStripButton, Me.DeleteServerToolStripButton, Me.StartAddInsToolStripSeparator, Me.EventLogViewerToolStripButton, Me.toolStripButton1})
		 Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
		 Me.MainToolStrip.Name = "MainToolStrip"
		 Me.MainToolStrip.Size = New System.Drawing.Size(552, 39)
		 Me.MainToolStrip.TabIndex = 0
		 Me.MainToolStrip.Text = "toolStrip1"
		 ' 
		 ' ToolStripSeparator1
		 ' 
		 Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		 Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
		 ' 
		 ' ToolStripSeparator2
		 ' 
		 Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		 Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
		 ' 
		 ' StartAddInsToolStripSeparator
		 ' 
		 Me.StartAddInsToolStripSeparator.Name = "StartAddInsToolStripSeparator"
		 Me.StartAddInsToolStripSeparator.Size = New System.Drawing.Size(6, 39)
		 ' 
		 ' toolStripButton1
		 ' 
		 Me.toolStripButton1.Name = "toolStripButton1"
		 Me.toolStripButton1.Size = New System.Drawing.Size(6, 39)
		 ' 
		 ' ServiceATitleLabel
		 ' 
		 Me.ServiceATitleLabel.AutoSize = True
		 Me.ServiceATitleLabel.Location = New System.Drawing.Point(5, 71)
		 Me.ServiceATitleLabel.Name = "ServiceATitleLabel"
		 Me.ServiceATitleLabel.Size = New System.Drawing.Size(63, 13)
		 Me.ServiceATitleLabel.TabIndex = 2
		 Me.ServiceATitleLabel.Text = "Service AE:"
		 ' 
		 ' IpAddressLabel
		 ' 
		 Me.IpAddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
		 Me.IpAddressLabel.Location = New System.Drawing.Point(74, 89)
		 Me.IpAddressLabel.Name = "IpAddressLabel"
		 Me.IpAddressLabel.Size = New System.Drawing.Size(105, 13)
		 Me.IpAddressLabel.TabIndex = 5
		 ' 
		 ' ServerPortLabel
		 ' 
		 Me.ServerPortLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
		 Me.ServerPortLabel.Location = New System.Drawing.Point(74, 106)
		 Me.ServerPortLabel.Name = "ServerPortLabel"
		 Me.ServerPortLabel.Size = New System.Drawing.Size(98, 13)
		 Me.ServerPortLabel.TabIndex = 7
		 ' 
		 ' IpLabel
		 ' 
		 Me.IpLabel.AutoSize = True
		 Me.IpLabel.Location = New System.Drawing.Point(5, 89)
		 Me.IpLabel.Name = "IpLabel"
		 Me.IpLabel.Size = New System.Drawing.Size(61, 13)
		 Me.IpLabel.TabIndex = 4
		 Me.IpLabel.Text = "IP Address:"
		 ' 
		 ' PortLabel
		 ' 
		 Me.PortLabel.AutoSize = True
		 Me.PortLabel.Location = New System.Drawing.Point(5, 106)
		 Me.PortLabel.Name = "PortLabel"
		 Me.PortLabel.Size = New System.Drawing.Size(29, 13)
		 Me.PortLabel.TabIndex = 6
		 Me.PortLabel.Text = "Port:"
		 ' 
		 ' LEADStorageServiceAELabel
		 ' 
		 Me.LEADStorageServiceAELabel.AutoSize = True
		 Me.LEADStorageServiceAELabel.Font = New System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold)
		 Me.LEADStorageServiceAELabel.Location = New System.Drawing.Point(74, 71)
		 Me.LEADStorageServiceAELabel.Name = "LEADStorageServiceAELabel"
		 Me.LEADStorageServiceAELabel.Size = New System.Drawing.Size(0, 13)
		 Me.LEADStorageServiceAELabel.TabIndex = 3
		 ' 
		 ' ServiceTabControl
		 ' 
		 Me.ServiceTabControl.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me.ServiceTabControl.Controls.Add(Me.AeTitlesTabPage)
		 Me.ServiceTabControl.Location = New System.Drawing.Point(7, 138)
		 Me.ServiceTabControl.Name = "ServiceTabControl"
		 Me.ServiceTabControl.SelectedIndex = 0
		 Me.ServiceTabControl.Size = New System.Drawing.Size(539, 346)
		 Me.ServiceTabControl.TabIndex = 8
		 ' 
		 ' AeTitlesTabPage
		 ' 
		 Me.AeTitlesTabPage.Controls.Add(Me.ClientsToolStripContainer)
		 Me.AeTitlesTabPage.Location = New System.Drawing.Point(4, 22)
		 Me.AeTitlesTabPage.Name = "AeTitlesTabPage"
		 Me.AeTitlesTabPage.Padding = New System.Windows.Forms.Padding(3)
		 Me.AeTitlesTabPage.Size = New System.Drawing.Size(531, 320)
		 Me.AeTitlesTabPage.TabIndex = 1
		 Me.AeTitlesTabPage.Text = "Client Nodes"
		 Me.AeTitlesTabPage.UseVisualStyleBackColor = True
		 ' 
		 ' ClientsToolStripContainer
		 ' 
		 Me.ClientsToolStripContainer.BottomToolStripPanelVisible = False
		 ' 
		 ' ClientsToolStripContainer.ContentPanel
		 ' 
		 Me.ClientsToolStripContainer.ContentPanel.Controls.Add(Me.AeTitlesListView)
		 Me.ClientsToolStripContainer.ContentPanel.Size = New System.Drawing.Size(525, 275)
		 Me.ClientsToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.ClientsToolStripContainer.LeftToolStripPanelVisible = False
		 Me.ClientsToolStripContainer.Location = New System.Drawing.Point(3, 3)
		 Me.ClientsToolStripContainer.Name = "ClientsToolStripContainer"
		 Me.ClientsToolStripContainer.RightToolStripPanelVisible = False
		 Me.ClientsToolStripContainer.Size = New System.Drawing.Size(525, 314)
		 Me.ClientsToolStripContainer.TabIndex = 4
		 Me.ClientsToolStripContainer.Text = "toolStripContainer1"
		 ' 
		 ' ClientsToolStripContainer.TopToolStripPanel
		 ' 
		 Me.ClientsToolStripContainer.TopToolStripPanel.Controls.Add(Me.AeTitleToolStrip)
		 ' 
		 ' AeTitlesListView
		 ' 
		 Me.AeTitlesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.AeTitleColumnHeader, Me.HostnameColumnHeader, Me.PortColumnHeader, Me.HeaderSecurePortColumnHeader})
		 Me.AeTitlesListView.Dock = System.Windows.Forms.DockStyle.Fill
		 Me.AeTitlesListView.FullRowSelect = True
		 Me.AeTitlesListView.GridLines = True
		 Me.AeTitlesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		 Me.AeTitlesListView.HideSelection = False
		 Me.AeTitlesListView.Location = New System.Drawing.Point(0, 0)
		 Me.AeTitlesListView.MultiSelect = False
		 Me.AeTitlesListView.Name = "AeTitlesListView"
		 Me.AeTitlesListView.Size = New System.Drawing.Size(525, 275)
		 Me.AeTitlesListView.TabIndex = 0
		 Me.AeTitlesListView.UseCompatibleStateImageBehavior = False
		 Me.AeTitlesListView.View = System.Windows.Forms.View.Details
		 ' 
		 ' AeTitleColumnHeader
		 ' 
		 Me.AeTitleColumnHeader.Text = "AE Title"
		 Me.AeTitleColumnHeader.Width = 103
		 ' 
		 ' HostnameColumnHeader
		 ' 
		 Me.HostnameColumnHeader.Text = "Address/Host Name"
		 Me.HostnameColumnHeader.Width = 118
		 ' 
		 ' PortColumnHeader
		 ' 
		 Me.PortColumnHeader.Text = "Port"
		 Me.PortColumnHeader.Width = 42
		 ' 
		 ' HeaderSecurePortColumnHeader
		 ' 
		 Me.HeaderSecurePortColumnHeader.Text = "Secure Port"
		 Me.HeaderSecurePortColumnHeader.Width = 100
		 ' 
		 ' AeTitleToolStrip
		 ' 
		 Me.AeTitleToolStrip.Dock = System.Windows.Forms.DockStyle.None
		 Me.AeTitleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		 Me.AeTitleToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
		 Me.AeTitleToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.AddAeTitleToolStripButton, Me.EditAeTitleToolStripButton, Me.DeleteAeTitleToolStripButton})
		 Me.AeTitleToolStrip.Location = New System.Drawing.Point(0, 0)
		 Me.AeTitleToolStrip.Name = "AeTitleToolStrip"
		 Me.AeTitleToolStrip.Size = New System.Drawing.Size(525, 39)
		 Me.AeTitleToolStrip.Stretch = True
		 Me.AeTitleToolStrip.TabIndex = 0
		 ' 
		 ' WorkstationDisplayNameLabel
		 ' 
		 Me.WorkstationDisplayNameLabel.AutoSize = True
		 Me.WorkstationDisplayNameLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		 Me.WorkstationDisplayNameLabel.Location = New System.Drawing.Point(3, 43)
		 Me.WorkstationDisplayNameLabel.Name = "WorkstationDisplayNameLabel"
		 Me.WorkstationDisplayNameLabel.Size = New System.Drawing.Size(0, 17)
		 Me.WorkstationDisplayNameLabel.TabIndex = 1
		 ' 
		 ' AddAeTitleToolStripButton
		 ' 
		 Me.AddAeTitleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.AddAeTitleToolStripButton.Image = Resources.client_add_32
       Me.AddAeTitleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.AddAeTitleToolStripButton.Name = "AddAeTitleToolStripButton"
       Me.AddAeTitleToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.AddAeTitleToolStripButton.Text = "Add Client"
       ' 
       ' EditAeTitleToolStripButton
       ' 
       Me.EditAeTitleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.EditAeTitleToolStripButton.Image = Resources.client_edit_32
       Me.EditAeTitleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.EditAeTitleToolStripButton.Name = "EditAeTitleToolStripButton"
       Me.EditAeTitleToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.EditAeTitleToolStripButton.Text = "Update Client"
       ' 
       ' DeleteAeTitleToolStripButton
       ' 
       Me.DeleteAeTitleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.DeleteAeTitleToolStripButton.Image = Resources.client_remove_32
       Me.DeleteAeTitleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.DeleteAeTitleToolStripButton.Name = "DeleteAeTitleToolStripButton"
       Me.DeleteAeTitleToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.DeleteAeTitleToolStripButton.Text = "Delete Client"
       ' 
       ' EditServerToolStripButton
       ' 
       Me.EditServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.EditServerToolStripButton.Image = Resources.server_edit_32
       Me.EditServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.EditServerToolStripButton.Name = "EditServerToolStripButton"
       Me.EditServerToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.EditServerToolStripButton.Text = "toolStripButton2"
       Me.EditServerToolStripButton.ToolTipText = "Edit Server"
       ' 
       ' ToolStripButtonStart
       ' 
       Me.ToolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.ToolStripButtonStart.Image = Resources.server_start_32
       Me.ToolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.ToolStripButtonStart.Name = "ToolStripButtonStart"
       Me.ToolStripButtonStart.Size = New System.Drawing.Size(36, 36)
       Me.ToolStripButtonStart.Text = "toolStripButton4"
       Me.ToolStripButtonStart.ToolTipText = "Start Server"
       ' 
       ' PauseToolStripButton
       ' 
       Me.PauseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.PauseToolStripButton.Image = Resources.server_pause_32
       Me.PauseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.PauseToolStripButton.Name = "PauseToolStripButton"
       Me.PauseToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.PauseToolStripButton.Text = "toolStripButton5"
       Me.PauseToolStripButton.ToolTipText = "Pause Server"
       ' 
       ' StopToolStripButton
       ' 
       Me.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.StopToolStripButton.Image = Resources.server_stop_32
       Me.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.StopToolStripButton.Name = "StopToolStripButton"
       Me.StopToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.StopToolStripButton.Text = "Stop"
       Me.StopToolStripButton.ToolTipText = "Stop Server"
       ' 
       ' AddServerToolStripButton
       ' 
       Me.AddServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.AddServerToolStripButton.Image = Resources.server_add_32
       Me.AddServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.AddServerToolStripButton.Name = "AddServerToolStripButton"
       Me.AddServerToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.AddServerToolStripButton.Text = "Add Server"
       Me.AddServerToolStripButton.ToolTipText = "Add Server"
       ' 
       ' DeleteServerToolStripButton
       ' 
       Me.DeleteServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.DeleteServerToolStripButton.Image = Resources.server_delete_32
       Me.DeleteServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
       Me.DeleteServerToolStripButton.Name = "DeleteServerToolStripButton"
       Me.DeleteServerToolStripButton.Size = New System.Drawing.Size(36, 36)
       Me.DeleteServerToolStripButton.Text = "Delete Server"
       Me.DeleteServerToolStripButton.ToolTipText = "Delete Server"
       ' 
       ' EventLogViewerToolStripButton
       ' 
       Me.EventLogViewerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.EventLogViewerToolStripButton.Image = Resources.EventLogViewer
		 Me.EventLogViewerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		 Me.EventLogViewerToolStripButton.Name = "EventLogViewerToolStripButton"
		 Me.EventLogViewerToolStripButton.Size = New System.Drawing.Size(36, 36)
		 Me.EventLogViewerToolStripButton.Text = "Event Log Viewer"
		 Me.EventLogViewerToolStripButton.ToolTipText = "Event Log Viewer"
		 ' 
		 ' StorageListenerService
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))), (CInt(Fix((CByte(75))))))
		 Me.Controls.Add(Me.WorkstationDisplayNameLabel)
		 Me.Controls.Add(Me.ServiceTabControl)
		 Me.Controls.Add(Me.LEADStorageServiceAELabel)
		 Me.Controls.Add(Me.IpAddressLabel)
		 Me.Controls.Add(Me.ServerPortLabel)
		 Me.Controls.Add(Me.IpLabel)
		 Me.Controls.Add(Me.PortLabel)
		 Me.Controls.Add(Me.ServiceATitleLabel)
		 Me.Controls.Add(Me.MainToolStrip)
		 Me.ForeColor = System.Drawing.Color.White
		 Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		 Me.Name = "StorageListenerService"
		 Me.Size = New System.Drawing.Size(552, 488)
		 Me.MainToolStrip.ResumeLayout(False)
		 Me.MainToolStrip.PerformLayout()
		 Me.ServiceTabControl.ResumeLayout(False)
		 Me.AeTitlesTabPage.ResumeLayout(False)
		 Me.ClientsToolStripContainer.ContentPanel.ResumeLayout(False)
		 Me.ClientsToolStripContainer.TopToolStripPanel.ResumeLayout(False)
		 Me.ClientsToolStripContainer.TopToolStripPanel.PerformLayout()
		 Me.ClientsToolStripContainer.ResumeLayout(False)
		 Me.ClientsToolStripContainer.PerformLayout()
		 Me.AeTitleToolStrip.ResumeLayout(False)
		 Me.AeTitleToolStrip.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Public EditServerToolStripButton As System.Windows.Forms.ToolStripButton
	  Public ToolStripButtonStart As System.Windows.Forms.ToolStripButton
	  Public PauseToolStripButton As System.Windows.Forms.ToolStripButton
	  Public StopToolStripButton As System.Windows.Forms.ToolStripButton
	  Public AddServerToolStripButton As System.Windows.Forms.ToolStripButton
	  Public DeleteServerToolStripButton As System.Windows.Forms.ToolStripButton
	  Public MainToolStrip As System.Windows.Forms.ToolStrip
	  Public ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	  Public ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	  Public ServiceATitleLabel As System.Windows.Forms.Label
	  Public IpAddressLabel As System.Windows.Forms.Label
	  Public ServerPortLabel As System.Windows.Forms.Label
	  Public IpLabel As System.Windows.Forms.Label
	  Public PortLabel As System.Windows.Forms.Label
	  Public LEADStorageServiceAELabel As System.Windows.Forms.Label
	  Public ServiceTabControl As System.Windows.Forms.TabControl
	  Public AeTitlesTabPage As System.Windows.Forms.TabPage
	  Public ClientsToolStripContainer As System.Windows.Forms.ToolStripContainer
	  Public AeTitlesListView As System.Windows.Forms.ListView
	  Public AeTitleColumnHeader As System.Windows.Forms.ColumnHeader
	  Public HostnameColumnHeader As System.Windows.Forms.ColumnHeader
	  Public PortColumnHeader As System.Windows.Forms.ColumnHeader
	  Public HeaderSecurePortColumnHeader As System.Windows.Forms.ColumnHeader
	  Public AeTitleToolStrip As System.Windows.Forms.ToolStrip
	  Public AddAeTitleToolStripButton As System.Windows.Forms.ToolStripButton
	  Public EditAeTitleToolStripButton As System.Windows.Forms.ToolStripButton
	  Public DeleteAeTitleToolStripButton As System.Windows.Forms.ToolStripButton
	  Public WorkstationDisplayNameLabel As System.Windows.Forms.Label
	  Public StartAddInsToolStripSeparator As System.Windows.Forms.ToolStripSeparator
	  Public EventLogViewerToolStripButton As System.Windows.Forms.ToolStripButton
	  Private toolStripButton1 As System.Windows.Forms.ToolStripSeparator



   End Class
End Namespace
