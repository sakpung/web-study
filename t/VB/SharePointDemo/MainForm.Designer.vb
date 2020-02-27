Imports Microsoft.VisualBasic
Imports System
Namespace SharePointDemo
   Public Partial Class MainForm
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

	  #Region "Windows Form Designer generated code"

	  ''' <summary>
	  ''' Required method for Designer support - do not modify
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		 Me._mainMenuStrip = New System.Windows.Forms.MenuStrip()
		 Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._fileOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
		 Me._fileExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._viewZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._viewZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._viewSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
		 Me._viewFitPageWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._viewFitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._pagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._pagesPreviousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._pagesNextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._interactiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._interactiveSelectModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._interactivePanModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._interactiveZoomToSelectionModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._sharePointServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._sharePointServerPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._sharePointServerRefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._sharePointServerSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
		 Me._sharePointServerUploadCurrentImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._helpAboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		 Me._viewerControl = New SharePointDemo.ViewerControl()
		 Me._serverControl = New SharePointDemo.ServerControl()
		 Me._verticalSplitter = New System.Windows.Forms.Splitter()
		 Me._mainMenuStrip.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _mainMenuStrip
		 ' 
		 Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me._fileToolStripMenuItem, Me._viewToolStripMenuItem, Me._pagesToolStripMenuItem, Me._interactiveToolStripMenuItem, Me._sharePointServerToolStripMenuItem, Me._helpToolStripMenuItem})
		 Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
		 Me._mainMenuStrip.Name = "_mainMenuStrip"
		 Me._mainMenuStrip.Size = New System.Drawing.Size(802, 24)
		 Me._mainMenuStrip.TabIndex = 0
		 Me._mainMenuStrip.Text = "menuStrip1"
		 ' 
		 ' _fileToolStripMenuItem
		 ' 
		 Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me._fileOpenToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._fileExitToolStripMenuItem})
		 Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
		 Me._fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
		 Me._fileToolStripMenuItem.Text = "&File"
		 ' 
		 ' _fileOpenToolStripMenuItem
		 ' 
		 Me._fileOpenToolStripMenuItem.Name = "_fileOpenToolStripMenuItem"
		 Me._fileOpenToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
		 Me._fileOpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		 Me._fileOpenToolStripMenuItem.Text = "&Open..."
'		 Me._fileOpenToolStripMenuItem.Click += New System.EventHandler(Me._fileOpenToolStripMenuItem_Click);
		 ' 
		 ' _fileSep1ToolStripMenuItem
		 ' 
		 Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
		 Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(149, 6)
		 ' 
		 ' _fileExitToolStripMenuItem
		 ' 
		 Me._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem"
		 Me._fileExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		 Me._fileExitToolStripMenuItem.Text = "E&xit"
'		 Me._fileExitToolStripMenuItem.Click += New System.EventHandler(Me._fileExitToolStripMenuItem_Click);
		 ' 
		 ' _viewToolStripMenuItem
		 ' 
		 Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me._viewZoomOutToolStripMenuItem, Me._viewZoomInToolStripMenuItem, Me._viewSep1ToolStripMenuItem, Me._viewFitPageWidthToolStripMenuItem, Me._viewFitPageToolStripMenuItem})
		 Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
		 Me._viewToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
		 Me._viewToolStripMenuItem.Text = "&View"
'		 Me._viewToolStripMenuItem.DropDownOpening += New System.EventHandler(Me._viewToolStripMenuItem_DropDownOpening);
		 ' 
		 ' _viewZoomOutToolStripMenuItem
		 ' 
		 Me._viewZoomOutToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.ZoomOut
		 Me._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem"
		 Me._viewZoomOutToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
		 Me._viewZoomOutToolStripMenuItem.Text = "Zoom &out"
'		 Me._viewZoomOutToolStripMenuItem.Click += New System.EventHandler(Me._viewZoomOutToolStripMenuItem_Click);
		 ' 
		 ' _viewZoomInToolStripMenuItem
		 ' 
		 Me._viewZoomInToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.ZoomIn
		 Me._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem"
		 Me._viewZoomInToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
		 Me._viewZoomInToolStripMenuItem.Text = "Zoom &in"
'		 Me._viewZoomInToolStripMenuItem.Click += New System.EventHandler(Me._viewZoomInToolStripMenuItem_Click);
		 ' 
		 ' _viewSep1ToolStripMenuItem
		 ' 
		 Me._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem"
		 Me._viewSep1ToolStripMenuItem.Size = New System.Drawing.Size(139, 6)
		 ' 
		 ' _viewFitPageWidthToolStripMenuItem
		 ' 
		 Me._viewFitPageWidthToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.FitPageWidth
		 Me._viewFitPageWidthToolStripMenuItem.Name = "_viewFitPageWidthToolStripMenuItem"
		 Me._viewFitPageWidthToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
		 Me._viewFitPageWidthToolStripMenuItem.Text = "Fit page &width"
'		 Me._viewFitPageWidthToolStripMenuItem.Click += New System.EventHandler(Me._viewFitPageWidthToolStripMenuItem_Click);
		 ' 
		 ' _viewFitPageToolStripMenuItem
		 ' 
		 Me._viewFitPageToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.FitPage
		 Me._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem"
		 Me._viewFitPageToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
		 Me._viewFitPageToolStripMenuItem.Text = "&Fit page"
'		 Me._viewFitPageToolStripMenuItem.Click += New System.EventHandler(Me._viewFitPageToolStripMenuItem_Click);
		 ' 
		 ' _pagesToolStripMenuItem
		 ' 
		 Me._pagesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me._pagesPreviousToolStripMenuItem, Me._pagesNextToolStripMenuItem})
		 Me._pagesToolStripMenuItem.Name = "_pagesToolStripMenuItem"
		 Me._pagesToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
		 Me._pagesToolStripMenuItem.Text = "&Pages"
'		 Me._pagesToolStripMenuItem.DropDownOpening += New System.EventHandler(Me._pagesToolStripMenuItem_DropDownOpening);
		 ' 
		 ' _pagesPreviousToolStripMenuItem
		 ' 
		 Me._pagesPreviousToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.PreviousPage
		 Me._pagesPreviousToolStripMenuItem.Name = "_pagesPreviousToolStripMenuItem"
		 Me._pagesPreviousToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
		 Me._pagesPreviousToolStripMenuItem.Text = "&Previous"
'		 Me._pagesPreviousToolStripMenuItem.Click += New System.EventHandler(Me._pagesPreviousToolStripMenuItem_Click);
		 ' 
		 ' _pagesNextToolStripMenuItem
		 ' 
		 Me._pagesNextToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.NextPage
		 Me._pagesNextToolStripMenuItem.Name = "_pagesNextToolStripMenuItem"
		 Me._pagesNextToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
		 Me._pagesNextToolStripMenuItem.Text = "&Next"
'		 Me._pagesNextToolStripMenuItem.Click += New System.EventHandler(Me._pagesNextToolStripMenuItem_Click);
		 ' 
		 ' _interactiveToolStripMenuItem
		 ' 
		 Me._interactiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me._interactiveSelectModeToolStripMenuItem, Me._interactivePanModeToolStripMenuItem, Me._interactiveZoomToSelectionModeToolStripMenuItem})
		 Me._interactiveToolStripMenuItem.Name = "_interactiveToolStripMenuItem"
		 Me._interactiveToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
		 Me._interactiveToolStripMenuItem.Text = "&Interactive"
'		 Me._interactiveToolStripMenuItem.DropDownOpening += New System.EventHandler(Me._interactiveToolStripMenuItem_DropDownOpening);
		 ' 
		 ' _interactiveSelectModeToolStripMenuItem
		 ' 
		 Me._interactiveSelectModeToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.SelectMode
		 Me._interactiveSelectModeToolStripMenuItem.Name = "_interactiveSelectModeToolStripMenuItem"
		 Me._interactiveSelectModeToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
		 Me._interactiveSelectModeToolStripMenuItem.Text = "&Select mode"
'		 Me._interactiveSelectModeToolStripMenuItem.Click += New System.EventHandler(Me._interactiveSelectModeToolStripMenuItem_Click);
		 ' 
		 ' _interactivePanModeToolStripMenuItem
		 ' 
		 Me._interactivePanModeToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.PanMode
		 Me._interactivePanModeToolStripMenuItem.Name = "_interactivePanModeToolStripMenuItem"
		 Me._interactivePanModeToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
		 Me._interactivePanModeToolStripMenuItem.Text = "&Pan mode"
'		 Me._interactivePanModeToolStripMenuItem.Click += New System.EventHandler(Me._interactivePanModeToolStripMenuItem_Click);
		 ' 
		 ' _interactiveZoomToSelectionModeToolStripMenuItem
		 ' 
		 Me._interactiveZoomToSelectionModeToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.ZoomSelectionMode
		 Me._interactiveZoomToSelectionModeToolStripMenuItem.Name = "_interactiveZoomToSelectionModeToolStripMenuItem"
		 Me._interactiveZoomToSelectionModeToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
		 Me._interactiveZoomToSelectionModeToolStripMenuItem.Text = "&Zoom to selection mode"
'		 Me._interactiveZoomToSelectionModeToolStripMenuItem.Click += New System.EventHandler(Me._interactiveZoomToSelectionModeToolStripMenuItem_Click);
		 ' 
		 ' _sharePointServerToolStripMenuItem
		 ' 
		 Me._sharePointServerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me._sharePointServerPropertiesToolStripMenuItem, Me._sharePointServerRefreshToolStripMenuItem, Me._sharePointServerSep1ToolStripMenuItem, Me._sharePointServerUploadCurrentImageToolStripMenuItem})
		 Me._sharePointServerToolStripMenuItem.Name = "_sharePointServerToolStripMenuItem"
		 Me._sharePointServerToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
		 Me._sharePointServerToolStripMenuItem.Text = "&SharePoint Server"
'		 Me._sharePointServerToolStripMenuItem.DropDownOpening += New System.EventHandler(Me._sharePointServerToolStripMenuItem_DropDownOpening);
		 ' 
		 ' _sharePointServerPropertiesToolStripMenuItem
		 ' 
		 Me._sharePointServerPropertiesToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.Server
		 Me._sharePointServerPropertiesToolStripMenuItem.Name = "_sharePointServerPropertiesToolStripMenuItem"
		 Me._sharePointServerPropertiesToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
		 Me._sharePointServerPropertiesToolStripMenuItem.Text = "&Properties..."
'		 Me._sharePointServerPropertiesToolStripMenuItem.Click += New System.EventHandler(Me._sharePointServerPropertiesToolStripMenuItem_Click);
		 ' 
		 ' _sharePointServerRefreshToolStripMenuItem
		 ' 
		 Me._sharePointServerRefreshToolStripMenuItem.Image = Global.SharePointDemo.My.Resources.Refresh
		 Me._sharePointServerRefreshToolStripMenuItem.Name = "_sharePointServerRefreshToolStripMenuItem"
		 Me._sharePointServerRefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
		 Me._sharePointServerRefreshToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
		 Me._sharePointServerRefreshToolStripMenuItem.Text = "&Refresh"
'		 Me._sharePointServerRefreshToolStripMenuItem.Click += New System.EventHandler(Me._sharePointServerRefreshToolStripMenuItem_Click);
		 ' 
		 ' _sharePointServerSep1ToolStripMenuItem
		 ' 
		 Me._sharePointServerSep1ToolStripMenuItem.Name = "_sharePointServerSep1ToolStripMenuItem"
		 Me._sharePointServerSep1ToolStripMenuItem.Size = New System.Drawing.Size(185, 6)
		 ' 
		 ' _sharePointServerUploadCurrentImageToolStripMenuItem
		 ' 
		 Me._sharePointServerUploadCurrentImageToolStripMenuItem.Name = "_sharePointServerUploadCurrentImageToolStripMenuItem"
		 Me._sharePointServerUploadCurrentImageToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
		 Me._sharePointServerUploadCurrentImageToolStripMenuItem.Text = "&Upload current image..."
'		 Me._sharePointServerUploadCurrentImageToolStripMenuItem.Click += New System.EventHandler(Me._sharePointServerUploadCurrentImageToolStripMenuItem_Click);
		 ' 
		 ' _helpToolStripMenuItem
		 ' 
		 Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me._helpAboutToolStripMenuItem})
		 Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
		 Me._helpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
		 Me._helpToolStripMenuItem.Text = "&Help"
		 ' 
		 ' _helpAboutToolStripMenuItem
		 ' 
		 Me._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem"
		 Me._helpAboutToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
		 Me._helpAboutToolStripMenuItem.Text = "&About..."
'		 Me._helpAboutToolStripMenuItem.Click += New System.EventHandler(Me._helpAboutToolStripMenuItem_Click);
		 ' 
		 ' _viewerControl
		 ' 
		 Me._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill
		 Me._viewerControl.Location = New System.Drawing.Point(304, 24)
		 Me._viewerControl.Name = "_viewerControl"
		 Me._viewerControl.RasterImage = Nothing
		 Me._viewerControl.Size = New System.Drawing.Size(498, 508)
		 Me._viewerControl.TabIndex = 2
'		 Me._viewerControl.OpenFileClicked += New System.EventHandler(Of System.EventArgs)(Me._viewerControl_OpenFileClicked);
'		 Me._viewerControl.UploadClicked += New System.EventHandler(Of System.EventArgs)(Me._viewerControl_UploadClicked);
		 ' 
		 ' _serverControl
		 ' 
		 Me._serverControl.Dock = System.Windows.Forms.DockStyle.Left
		 Me._serverControl.Location = New System.Drawing.Point(0, 24)
		 Me._serverControl.Name = "_serverControl"
		 Me._serverControl.Size = New System.Drawing.Size(304, 508)
		 Me._serverControl.TabIndex = 3
'		 Me._serverControl.RefreshClicked += New System.EventHandler(Of System.EventArgs)(Me._serverControl_RefreshClicked);
'		 Me._serverControl.DownloadClicked += New System.EventHandler(Of System.EventArgs)(Me._serverControl_DownloadClicked);
'		 Me._serverControl.ServerClicked += New System.EventHandler(Of System.EventArgs)(Me._serverControl_ServerClicked);
		 ' 
		 ' _verticalSplitter
		 ' 
		 Me._verticalSplitter.Location = New System.Drawing.Point(304, 24)
		 Me._verticalSplitter.Name = "_verticalSplitter"
		 Me._verticalSplitter.Size = New System.Drawing.Size(3, 508)
		 Me._verticalSplitter.TabIndex = 4
		 Me._verticalSplitter.TabStop = False
		 ' 
		 ' MainForm
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(802, 532)
		 Me.Controls.Add(Me._verticalSplitter)
		 Me.Controls.Add(Me._viewerControl)
		 Me.Controls.Add(Me._serverControl)
		 Me.Controls.Add(Me._mainMenuStrip)
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MainMenuStrip = Me._mainMenuStrip
		 Me.Name = "MainForm"
		 Me.Text = "MainForm"
		 Me._mainMenuStrip.ResumeLayout(False)
		 Me._mainMenuStrip.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _mainMenuStrip As System.Windows.Forms.MenuStrip
	  Private _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _fileExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _helpAboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _viewerControl As ViewerControl
	  Private WithEvents _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _viewZoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _viewZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private _viewSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
	  Private WithEvents _viewFitPageWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _viewFitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _pagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _pagesNextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _pagesPreviousToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _interactiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _interactiveSelectModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _interactivePanModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _interactiveZoomToSelectionModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _serverControl As ServerControl
	  Private WithEvents _sharePointServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _sharePointServerPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _sharePointServerRefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private _verticalSplitter As System.Windows.Forms.Splitter
	  Private WithEvents _fileOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
	  Private _sharePointServerSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
	  Private WithEvents _sharePointServerUploadCurrentImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace

