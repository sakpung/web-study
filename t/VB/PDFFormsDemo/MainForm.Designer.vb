Imports Leadtools.Controls
Imports Leadtools

Namespace PDFFormsDemo
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
         Me._miFile = New System.Windows.Forms.MenuItem()
         Me._miFileOpen = New System.Windows.Forms.MenuItem()
         Me._miFileLoadDataFromXML = New System.Windows.Forms.MenuItem()
         Me._miFileSaveDataToXML = New System.Windows.Forms.MenuItem()
         Me._miFileSep1 = New System.Windows.Forms.MenuItem()
         Me._miFilePrint = New System.Windows.Forms.MenuItem()
         Me._miFileSep2 = New System.Windows.Forms.MenuItem()
         Me._miFileClose = New System.Windows.Forms.MenuItem()
         Me._miFileExit = New System.Windows.Forms.MenuItem()
         Me._miView = New System.Windows.Forms.MenuItem()
         Me._miViewSizeMode = New System.Windows.Forms.MenuItem()
         Me._miViewSizeModeActualSize = New System.Windows.Forms.MenuItem()
         Me._miViewSizeModeStretch = New System.Windows.Forms.MenuItem()
         Me._miViewSizeModeFitAlways = New System.Windows.Forms.MenuItem()
         Me._miViewSizeModeFitWidth = New System.Windows.Forms.MenuItem()
         Me._miViewSizeModeFit = New System.Windows.Forms.MenuItem()
         Me._miViewSizeModeFitHeight = New System.Windows.Forms.MenuItem()
         Me._miViewZoom = New System.Windows.Forms.MenuItem()
         Me._miViewZoom25 = New System.Windows.Forms.MenuItem()
         Me._miViewZoom50 = New System.Windows.Forms.MenuItem()
         Me._miViewZoom75 = New System.Windows.Forms.MenuItem()
         Me._miViewZoom100 = New System.Windows.Forms.MenuItem()
         Me._miViewZoom125 = New System.Windows.Forms.MenuItem()
         Me._miViewZoom150 = New System.Windows.Forms.MenuItem()
         Me._miViewZoom200 = New System.Windows.Forms.MenuItem()
         Me._miViewUseSVGMode = New System.Windows.Forms.MenuItem()
         Me._miMultiPage = New System.Windows.Forms.MenuItem()
         Me._miMultiPageFirst = New System.Windows.Forms.MenuItem()
         Me._miMultiPagePrevious = New System.Windows.Forms.MenuItem()
         Me._miMultiPageNext = New System.Windows.Forms.MenuItem()
         Me._miMultiPageLast = New System.Windows.Forms.MenuItem()
         Me._miMultiPageSep = New System.Windows.Forms.MenuItem()
         Me._miMultiPageGoto = New System.Windows.Forms.MenuItem()
         Me._miHelp = New System.Windows.Forms.MenuItem()
         Me._miHelpAbout = New System.Windows.Forms.MenuItem()
         Me._imageViewer = New ImageViewer()
         Me._imageViewerPanel = New System.Windows.Forms.Panel()
         Me._imageList = New ImageViewer()
         Me._imageListPanel = New System.Windows.Forms.Panel()
         Me._mainTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
         Me._formFieldToolTip = New System.Windows.Forms.ToolTip(Me.components)
         Me._formFieldContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me._propertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainTableLayoutPanel.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mmMain
         ' 
         Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miView, Me._miMultiPage, Me._miHelp})
         ' 
         ' _miFile
         ' 
         Me._miFile.Index = 0
         Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileLoadDataFromXML, Me._miFileSaveDataToXML, Me._miFileSep1, Me._miFilePrint, Me._miFileSep2, _
          Me._miFileClose, Me._miFileExit})
         Me._miFile.Text = "&File"
         ' 
         ' _miFileOpen
         ' 
         Me._miFileOpen.Index = 0
         Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
         Me._miFileOpen.Text = "&Open PDF..."
         ' 
         ' _miFileLoadDataFromXML
         ' 
         Me._miFileLoadDataFromXML.Index = 1
         Me._miFileLoadDataFromXML.Shortcut = System.Windows.Forms.Shortcut.CtrlL
         Me._miFileLoadDataFromXML.Text = "&Load Data From XML..."
         ' 
         ' _miFileSaveDataToXML
         ' 
         Me._miFileSaveDataToXML.Index = 2
         Me._miFileSaveDataToXML.Shortcut = System.Windows.Forms.Shortcut.CtrlS
         Me._miFileSaveDataToXML.Text = "&Save Data To XML..."
         ' 
         ' _miFileSep
         ' 
         Me._miFileSep1.Index = 3
         Me._miFileSep1.Text = "-"
         ' 
         ' _miFilePrint
         ' 
         Me._miFilePrint.Index = 4
         Me._miFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP
         Me._miFilePrint.Text = "&Print"
         ' 
         ' _miFileSep2
         ' 
         Me._miFileSep2.Index = 5
         Me._miFileSep2.Text = "-"
         ' 
         ' _miFileClose
         ' 
         Me._miFileClose.Index = 6
         Me._miFileClose.Text = "&Close"
         ' 
         ' _miFileExit
         ' 
         Me._miFileExit.Index = 7
         Me._miFileExit.Text = "E&xit"
         ' 
         ' _miView
         ' 
         Me._miView.Index = 1
         Me._miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewSizeMode, Me._miViewZoom, Me._miViewUseSVGMode})
         Me._miView.Text = "&View"
         ' 
         ' _miViewSizeMode
         ' 
         Me._miViewSizeMode.Index = 0
         Me._miViewSizeMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewSizeModeActualSize, Me._miViewSizeModeStretch, Me._miViewSizeModeFitAlways, Me._miViewSizeModeFitWidth, Me._miViewSizeModeFit, Me._miViewSizeModeFitHeight})
         Me._miViewSizeMode.Text = "&Size Mode"
         ' 
         ' _miViewSizeModeActualSize
         ' 
         Me._miViewSizeModeActualSize.Index = 0
         Me._miViewSizeModeActualSize.Text = "&ActualSize"
         ' 
         ' _miViewSizeModeStretch
         ' 
         Me._miViewSizeModeStretch.Index = 1
         Me._miViewSizeModeStretch.Text = "&Stretch"
         ' 
         ' _miViewSizeModeFitAlways
         ' 
         Me._miViewSizeModeFitAlways.Index = 2
         Me._miViewSizeModeFitAlways.Text = "Fit &Always"
         ' 
         ' _miViewSizeModeFitWidth
         ' 
         Me._miViewSizeModeFitWidth.Index = 3
         Me._miViewSizeModeFitWidth.Text = "Fit &Width"
         ' 
         ' _miViewSizeModeFit
         ' 
         Me._miViewSizeModeFit.Index = 4
         Me._miViewSizeModeFit.Text = "&Fit"
         ' 
         ' _miViewSizeModeFitHeight
         ' 
         Me._miViewSizeModeFitHeight.Index = 5
         Me._miViewSizeModeFitHeight.Text = "&FitHeight"
         ' 
         ' _miViewZoom
         ' 
         Me._miViewZoom.Index = 1
         Me._miViewZoom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewZoom25, Me._miViewZoom50, Me._miViewZoom75, Me._miViewZoom100, Me._miViewZoom125, Me._miViewZoom150, _
          Me._miViewZoom200})
         Me._miViewZoom.Text = "&Zoom"
         ' 
         ' _miViewZoom25
         ' 
         Me._miViewZoom25.Index = 0
         Me._miViewZoom25.Text = "25%"
         ' 
         ' _miViewZoom50
         ' 
         Me._miViewZoom50.Index = 1
         Me._miViewZoom50.Text = "50%"
         ' 
         ' _miViewZoom75
         ' 
         Me._miViewZoom75.Index = 2
         Me._miViewZoom75.Text = "75%"
         ' 
         ' _miViewZoom100
         ' 
         Me._miViewZoom100.Index = 3
         Me._miViewZoom100.Text = "100%"
         ' 
         ' _miViewZoom125
         ' 
         Me._miViewZoom125.Index = 4
         Me._miViewZoom125.Text = "125%"
         ' 
         ' _miViewZoom150
         ' 
         Me._miViewZoom150.Index = 5
         Me._miViewZoom150.Text = "150%"
         ' 
         ' _miViewZoom200
         ' 
         Me._miViewZoom200.Index = 6
         Me._miViewZoom200.Text = "200%"
         ' 
         ' _miViewUseSVGMode
         ' 
         Me._miViewUseSVGMode.Index = 2
         Me._miViewUseSVGMode.Text = "Use SVG &Mode"
         ' 
         ' _miMultiPage
         ' 
         Me._miMultiPage.Index = 2
         Me._miMultiPage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miMultiPageFirst, Me._miMultiPagePrevious, Me._miMultiPageNext, Me._miMultiPageLast, Me._miMultiPageSep, Me._miMultiPageGoto})
         Me._miMultiPage.Text = "&Multi-Page"
         ' 
         ' _miMultiPageFirst
         ' 
         Me._miMultiPageFirst.Index = 0
         Me._miMultiPageFirst.Text = "First"
         ' 
         ' _miMultiPagePrevious
         ' 
         Me._miMultiPagePrevious.Index = 1
         Me._miMultiPagePrevious.Text = "Previous"
         ' 
         ' _miMultiPageNext
         ' 
         Me._miMultiPageNext.Index = 2
         Me._miMultiPageNext.Text = "Next"
         ' 
         ' _miMultiPageLast
         ' 
         Me._miMultiPageLast.Index = 3
         Me._miMultiPageLast.Text = "Last"
         ' 
         ' _miMultiPageSep
         ' 
         Me._miMultiPageSep.Index = 4
         Me._miMultiPageSep.Text = "-"
         ' 
         ' _miMultiPageGoto
         ' 
         Me._miMultiPageGoto.Index = 5
         Me._miMultiPageGoto.Text = "Go To Page"
         ' 
         ' _miHelp
         ' 
         Me._miHelp.Index = 3
         Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
         Me._miHelp.Text = "&Help"
         ' 
         ' _miHelpAbout
         ' 
         Me._miHelpAbout.Index = 0
         Me._miHelpAbout.Text = "&About..."
         ' 
         ' _imageViewer
         ' 
         Me._imageViewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._imageViewer.BackColor = System.Drawing.SystemColors.InactiveCaption
         Me._imageViewer.ImageBackgroundColor = System.Drawing.Color.White
         Me._imageViewer.AutoDisposeImages = False
         Me._imageViewer.ViewHorizontalAlignment = ControlAlignment.Center
         Me._imageViewer.ViewVerticalAlignment = ControlAlignment.Center
         Me._imageViewer.UseDpi = True
         Me._imageViewer.Zoom(ControlSizeMode.ActualSize, 1, _imageViewer.DefaultZoomOrigin)
         ' 
         ' _imageViewerPanel
         ' 
         Me._imageViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._imageViewerPanel.Location = New System.Drawing.Point(153, 3)
         Me._imageViewerPanel.Name = "_imageViewerPanel"
         Me._imageViewerPanel.Size = New System.Drawing.Size(544, 379)
         Me._imageViewerPanel.Margin = New System.Windows.Forms.Padding(0)
         Me._imageViewerPanel.TabIndex = 0
         Me._imageViewerPanel.Controls.Add(_imageViewer)
         ' 
         ' _imageList
         ' 
         Me._imageList.ViewLayout = New ImageViewerVerticalViewLayout() With { _
           .Columns = 1 _
         }
         Me._imageList.Dock = System.Windows.Forms.DockStyle.Fill
         Me._imageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._imageList.BackColor = System.Drawing.SystemColors.ActiveCaption
         Me._imageList.ImageBackgroundColor = System.Drawing.Color.White
         Me._imageList.ViewHorizontalAlignment = ControlAlignment.Center
         Me._imageList.UseDpi = True
         Me._imageList.ItemSize = New LeadSize(100, 120)
         Me._imageList.ItemSpacing = New LeadSize(20, 20)
         Me._imageList.SelectedItemBorderColor = System.Drawing.Color.Blue
         Me._imageList.ItemBorderThickness = 2
         Me._imageList.ItemSizeMode = ControlSizeMode.Fit
         Me._imageList.InteractiveModes.Add(New ImageViewerSelectItemsInteractiveMode() With { _
           .SelectionMode = ImageViewerSelectionMode.[Single] _
         })
         Me._imageList.Items.Clear()
         ' 
         ' _imageListPanel
         ' 
         Me._imageListPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._imageListPanel.Location = New System.Drawing.Point(3, 3)
         Me._imageListPanel.Name = "_imageListPanel"
         Me._imageListPanel.Size = New System.Drawing.Size(144, 379)
         Me._imageListPanel.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
         Me._imageListPanel.TabIndex = 1
         Me._imageListPanel.Controls.Add(_imageList)
         ' 
         ' _mainTableLayoutPanel
         ' 
         Me._mainTableLayoutPanel.ColumnCount = 2
         Me._mainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0F))
         Me._mainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
         Me._mainTableLayoutPanel.Controls.Add(Me._imageViewerPanel, 1, 0)
         Me._mainTableLayoutPanel.Controls.Add(Me._imageListPanel, 0, 0)
         Me._mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._mainTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
         Me._mainTableLayoutPanel.Name = "_mainTableLayoutPanel"
         Me._mainTableLayoutPanel.RowCount = 1
         Me._mainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
         Me._mainTableLayoutPanel.Size = New System.Drawing.Size(700, 385)
         Me._mainTableLayoutPanel.TabIndex = 2
         ' 
         ' _formFieldToolTip
         ' 
         Me._formFieldToolTip.ShowAlways = True
         ' 
         ' _formFieldContextMenu
         ' 
         Me._formFieldContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._propertiesToolStripMenuItem})
         Me._formFieldContextMenu.Name = "_formFieldContextMenu"
         Me._formFieldContextMenu.Size = New System.Drawing.Size(153, 48)
         ' 
         ' _propertiesToolStripMenuItem
         ' 
         Me._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem"
         Me._propertiesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._propertiesToolStripMenuItem.Text = "Properties"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(700, 385)
         Me.Controls.Add(Me._mainTableLayoutPanel)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Menu = Me._mmMain
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me._mainTableLayoutPanel.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _mmMain As System.Windows.Forms.MainMenu
      Private _miFile As System.Windows.Forms.MenuItem
      Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
      Private WithEvents _miFileLoadDataFromXML As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveDataToXML As System.Windows.Forms.MenuItem
      Private _miFileSep1 As System.Windows.Forms.MenuItem
      Private WithEvents _miFilePrint As System.Windows.Forms.MenuItem
      Private _miFileSep2 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileClose As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
      Private _miHelp As System.Windows.Forms.MenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
      Private _imageViewerPanel As System.Windows.Forms.Panel
      Private _imageListPanel As System.Windows.Forms.Panel
      Private WithEvents _imageList As ImageViewer
      Private WithEvents _imageViewer As ImageViewer
      Private _mainTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
      Private _formFieldToolTip As System.Windows.Forms.ToolTip
      Private _formFieldContextMenu As System.Windows.Forms.ContextMenuStrip
      Private WithEvents _propertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _miView As System.Windows.Forms.MenuItem
      Private _miViewSizeMode As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSizeModeActualSize As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSizeModeStretch As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSizeModeFitAlways As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSizeModeFitWidth As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSizeModeFit As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSizeModeFitHeight As System.Windows.Forms.MenuItem
      Private _miViewZoom As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoom25 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoom50 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoom75 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoom100 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoom125 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoom150 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoom200 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewUseSVGMode As System.Windows.Forms.MenuItem
      Private _miMultiPage As System.Windows.Forms.MenuItem
      Private WithEvents _miMultiPageFirst As System.Windows.Forms.MenuItem
      Private WithEvents _miMultiPagePrevious As System.Windows.Forms.MenuItem
      Private WithEvents _miMultiPageNext As System.Windows.Forms.MenuItem
      Private WithEvents _miMultiPageLast As System.Windows.Forms.MenuItem
      Private _miMultiPageSep As System.Windows.Forms.MenuItem
      Private WithEvents _miMultiPageGoto As System.Windows.Forms.MenuItem
   End Class
End Namespace