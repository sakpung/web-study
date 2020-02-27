Imports Microsoft.VisualBasic
Imports System
Imports Leadtools.Medical.Workstation.UI
Namespace Leadtools.Demos.Workstation
   Partial Public Class WorkStationContainer
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
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkStationContainer))
Me.ControlsDisplayPanel = New System.Windows.Forms.Panel
Me.ItemsToolTip = New System.Windows.Forms.ToolTip(Me.components)
Me.LogOutButton = New System.Windows.Forms.Button
Me.QueueManagerButton = New System.Windows.Forms.Button
Me.StorageServiceButton = New System.Windows.Forms.Button
Me.ConfigurationButton = New System.Windows.Forms.Button
Me.SearchButton = New System.Windows.Forms.Button
Me.ViewerButton = New System.Windows.Forms.Button
Me.UserAccessButton = New System.Windows.Forms.Button
Me.WSHelpButton = New System.Windows.Forms.Button
Me.MediaBurningButton = New System.Windows.Forms.Button
Me.ContainerItemsAutoHidePanel = New Leadtools.Medical.Workstation.UI.AutoHidePanel
Me.FullScreenButton = New System.Windows.Forms.Button
Me.ContainerItemsAutoHidePanel.SuspendLayout()
Me.SuspendLayout()
'
'ControlsDisplayPanel
'
Me.ControlsDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.ControlsDisplayPanel.Location = New System.Drawing.Point(0, 0)
Me.ControlsDisplayPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.ControlsDisplayPanel.Name = "ControlsDisplayPanel"
Me.ControlsDisplayPanel.Size = New System.Drawing.Size(747, 499)
Me.ControlsDisplayPanel.TabIndex = 0
'
'LogOutButton
'
Me.LogOutButton.BackColor = System.Drawing.Color.DimGray
Me.LogOutButton.Dock = System.Windows.Forms.DockStyle.Left
Me.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.LogOutButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.LogOutButton.ForeColor = System.Drawing.Color.Black
Me.LogOutButton.Image = CType(resources.GetObject("LogOutButton.Image"), System.Drawing.Image)
Me.LogOutButton.Location = New System.Drawing.Point(296, 0)
Me.LogOutButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.LogOutButton.Name = "LogOutButton"
Me.LogOutButton.Size = New System.Drawing.Size(37, 39)
Me.LogOutButton.TabIndex = 7
Me.ItemsToolTip.SetToolTip(Me.LogOutButton, "Log Out")
Me.LogOutButton.UseVisualStyleBackColor = False
'
'QueueManagerButton
'
Me.QueueManagerButton.BackColor = System.Drawing.Color.DimGray
Me.QueueManagerButton.Dock = System.Windows.Forms.DockStyle.Left
Me.QueueManagerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.QueueManagerButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.QueueManagerButton.ForeColor = System.Drawing.Color.Black
Me.QueueManagerButton.Image = CType(resources.GetObject("QueueManagerButton.Image"), System.Drawing.Image)
Me.QueueManagerButton.Location = New System.Drawing.Point(185, 0)
Me.QueueManagerButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.QueueManagerButton.Name = "QueueManagerButton"
Me.QueueManagerButton.Size = New System.Drawing.Size(37, 39)
Me.QueueManagerButton.TabIndex = 5
Me.ItemsToolTip.SetToolTip(Me.QueueManagerButton, "Queue Manager")
Me.QueueManagerButton.UseVisualStyleBackColor = False
'
'StorageServiceButton
'
Me.StorageServiceButton.BackColor = System.Drawing.Color.DimGray
Me.StorageServiceButton.Dock = System.Windows.Forms.DockStyle.Left
Me.StorageServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.StorageServiceButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.StorageServiceButton.ForeColor = System.Drawing.Color.Black
         Me.StorageServiceButton.Image = Global.Resources.addin_config_32
Me.StorageServiceButton.Location = New System.Drawing.Point(148, 0)
Me.StorageServiceButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.StorageServiceButton.Name = "StorageServiceButton"
Me.StorageServiceButton.Size = New System.Drawing.Size(37, 39)
Me.StorageServiceButton.TabIndex = 4
Me.ItemsToolTip.SetToolTip(Me.StorageServiceButton, "Service Manager")
Me.StorageServiceButton.UseVisualStyleBackColor = False
'
'ConfigurationButton
'
Me.ConfigurationButton.BackColor = System.Drawing.Color.DimGray
Me.ConfigurationButton.Dock = System.Windows.Forms.DockStyle.Left
Me.ConfigurationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.ConfigurationButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.ConfigurationButton.ForeColor = System.Drawing.Color.Black
Me.ConfigurationButton.Image = CType(resources.GetObject("ConfigurationButton.Image"), System.Drawing.Image)
Me.ConfigurationButton.Location = New System.Drawing.Point(74, 0)
Me.ConfigurationButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.ConfigurationButton.Name = "ConfigurationButton"
Me.ConfigurationButton.Size = New System.Drawing.Size(37, 39)
Me.ConfigurationButton.TabIndex = 2
Me.ConfigurationButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
Me.ItemsToolTip.SetToolTip(Me.ConfigurationButton, "Configuration")
Me.ConfigurationButton.UseVisualStyleBackColor = False
'
'SearchButton
'
Me.SearchButton.BackColor = System.Drawing.Color.DimGray
Me.SearchButton.Dock = System.Windows.Forms.DockStyle.Left
Me.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.SearchButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.SearchButton.ForeColor = System.Drawing.Color.Black
Me.SearchButton.Image = CType(resources.GetObject("SearchButton.Image"), System.Drawing.Image)
Me.SearchButton.Location = New System.Drawing.Point(37, 0)
Me.SearchButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.SearchButton.Name = "SearchButton"
Me.SearchButton.Size = New System.Drawing.Size(37, 39)
Me.SearchButton.TabIndex = 1
Me.ItemsToolTip.SetToolTip(Me.SearchButton, "Search")
Me.SearchButton.UseVisualStyleBackColor = False
'
'ViewerButton
'
Me.ViewerButton.BackColor = System.Drawing.Color.LightGray
Me.ViewerButton.Dock = System.Windows.Forms.DockStyle.Left
Me.ViewerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.ViewerButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.ViewerButton.ForeColor = System.Drawing.Color.Black
Me.ViewerButton.Image = CType(resources.GetObject("ViewerButton.Image"), System.Drawing.Image)
Me.ViewerButton.Location = New System.Drawing.Point(0, 0)
Me.ViewerButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.ViewerButton.Name = "ViewerButton"
Me.ViewerButton.Size = New System.Drawing.Size(37, 39)
Me.ViewerButton.TabIndex = 0
Me.ItemsToolTip.SetToolTip(Me.ViewerButton, "Viewer")
Me.ViewerButton.UseVisualStyleBackColor = False
'
'UserAccessButton
'
Me.UserAccessButton.BackColor = System.Drawing.Color.DimGray
Me.UserAccessButton.Dock = System.Windows.Forms.DockStyle.Left
Me.UserAccessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.UserAccessButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.UserAccessButton.ForeColor = System.Drawing.Color.Black
Me.UserAccessButton.Image = CType(resources.GetObject("UserAccessButton.Image"), System.Drawing.Image)
Me.UserAccessButton.Location = New System.Drawing.Point(111, 0)
Me.UserAccessButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.UserAccessButton.Name = "UserAccessButton"
Me.UserAccessButton.Size = New System.Drawing.Size(37, 39)
Me.UserAccessButton.TabIndex = 9
Me.UserAccessButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
Me.ItemsToolTip.SetToolTip(Me.UserAccessButton, "Users")
Me.UserAccessButton.UseVisualStyleBackColor = False
'
'WSHelpButton
'
Me.WSHelpButton.BackColor = System.Drawing.Color.DimGray
Me.WSHelpButton.Dock = System.Windows.Forms.DockStyle.Left
Me.WSHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.WSHelpButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.WSHelpButton.ForeColor = System.Drawing.Color.Black
Me.WSHelpButton.Image = CType(resources.GetObject("WSHelpButton.Image"), System.Drawing.Image)
Me.WSHelpButton.Location = New System.Drawing.Point(333, 0)
Me.WSHelpButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.WSHelpButton.Name = "WSHelpButton"
Me.WSHelpButton.Size = New System.Drawing.Size(37, 39)
Me.WSHelpButton.TabIndex = 13
Me.WSHelpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
Me.ItemsToolTip.SetToolTip(Me.WSHelpButton, "Help")
Me.WSHelpButton.UseVisualStyleBackColor = False
'
'MediaBurningButton
'
Me.MediaBurningButton.BackColor = System.Drawing.Color.DimGray
Me.MediaBurningButton.Dock = System.Windows.Forms.DockStyle.Left
Me.MediaBurningButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.MediaBurningButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.MediaBurningButton.ForeColor = System.Drawing.Color.Black
Me.MediaBurningButton.Image = CType(resources.GetObject("MediaBurningButton.Image"), System.Drawing.Image)
Me.MediaBurningButton.Location = New System.Drawing.Point(222, 0)
Me.MediaBurningButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.MediaBurningButton.Name = "MediaBurningButton"
Me.MediaBurningButton.Size = New System.Drawing.Size(37, 39)
Me.MediaBurningButton.TabIndex = 17
Me.ItemsToolTip.SetToolTip(Me.MediaBurningButton, "Media Burning Manager")
Me.MediaBurningButton.UseVisualStyleBackColor = False
'
'ContainerItemsAutoHidePanel
'
Me.ContainerItemsAutoHidePanel.AutoHide = False
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.WSHelpButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.LogOutButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.FullScreenButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.MediaBurningButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.QueueManagerButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.StorageServiceButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.UserAccessButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.ConfigurationButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.SearchButton)
Me.ContainerItemsAutoHidePanel.Controls.Add(Me.ViewerButton)
Me.ContainerItemsAutoHidePanel.Dock = System.Windows.Forms.DockStyle.Bottom
Me.ContainerItemsAutoHidePanel.EnableResizing = False
Me.ContainerItemsAutoHidePanel.Location = New System.Drawing.Point(0, 499)
Me.ContainerItemsAutoHidePanel.Margin = New System.Windows.Forms.Padding(0)
Me.ContainerItemsAutoHidePanel.Name = "ContainerItemsAutoHidePanel"
Me.ContainerItemsAutoHidePanel.Size = New System.Drawing.Size(747, 39)
Me.ContainerItemsAutoHidePanel.Speed = 40
Me.ContainerItemsAutoHidePanel.State = Leadtools.Medical.Workstation.UI.AutoHidePanelState.Expanded
Me.ContainerItemsAutoHidePanel.StickPinAttached = CType(resources.GetObject("ContainerItemsAutoHidePanel.StickPinAttached"), System.Drawing.Bitmap)
Me.ContainerItemsAutoHidePanel.StickPinUnattached = CType(resources.GetObject("ContainerItemsAutoHidePanel.StickPinUnattached"), System.Drawing.Bitmap)
Me.ContainerItemsAutoHidePanel.TabIndex = 2
Me.ContainerItemsAutoHidePanel.TopLevel = True
'
'FullScreenButton
'
Me.FullScreenButton.BackColor = System.Drawing.Color.DimGray
Me.FullScreenButton.Dock = System.Windows.Forms.DockStyle.Left
Me.FullScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.FullScreenButton.Font = New System.Drawing.Font("Arial", 8.0!)
Me.FullScreenButton.ForeColor = System.Drawing.Color.Black
Me.FullScreenButton.Image = CType(resources.GetObject("FullScreenButton.Image"), System.Drawing.Image)
Me.FullScreenButton.Location = New System.Drawing.Point(259, 0)
Me.FullScreenButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.FullScreenButton.Name = "FullScreenButton"
Me.FullScreenButton.Size = New System.Drawing.Size(37, 39)
Me.FullScreenButton.TabIndex = 6
Me.FullScreenButton.UseVisualStyleBackColor = False
'
'WorkStationContainer
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
Me.Controls.Add(Me.ControlsDisplayPanel)
Me.Controls.Add(Me.ContainerItemsAutoHidePanel)
Me.ForeColor = System.Drawing.Color.White
Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.Name = "WorkStationContainer"
Me.Size = New System.Drawing.Size(747, 538)
Me.ContainerItemsAutoHidePanel.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

	  #End Region

	  Protected ContainerItemsAutoHidePanel As AutoHidePanel
	  Protected LogOutButton As System.Windows.Forms.Button
	  Protected QueueManagerButton As System.Windows.Forms.Button
	  Protected FullScreenButton As System.Windows.Forms.Button
	  Protected ConfigurationButton As System.Windows.Forms.Button
	  Protected StorageServiceButton As System.Windows.Forms.Button
	  Protected SearchButton As System.Windows.Forms.Button
	  Protected ViewerButton As System.Windows.Forms.Button
	  Protected ControlsDisplayPanel As System.Windows.Forms.Panel
	  Protected ItemsToolTip As System.Windows.Forms.ToolTip
	  Protected UserAccessButton As System.Windows.Forms.Button
	  Protected WSHelpButton As System.Windows.Forms.Button
	  Protected MediaBurningButton As System.Windows.Forms.Button

   End Class
End Namespace
