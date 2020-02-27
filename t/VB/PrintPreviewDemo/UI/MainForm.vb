' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing.Imaging
Imports System.Drawing.Printing

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Drawing

Imports System.IO
Imports Leadtools.Demos.Dialogs



Public Class MainForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents _mmMain As System.Windows.Forms.MainMenu
   Friend WithEvents _miFile As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miFilePrint As System.Windows.Forms.MenuItem
   Friend WithEvents _miFilePageSetup As System.Windows.Forms.MenuItem
   Friend WithEvents _miFilePrintPreview As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep2 As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoom As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomIn As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomOut As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomNormal As System.Windows.Forms.MenuItem
   Friend WithEvents _miPage As System.Windows.Forms.MenuItem
   Friend WithEvents _miPageFirst As System.Windows.Forms.MenuItem
   Friend WithEvents _miPagePrevious As System.Windows.Forms.MenuItem
   Friend WithEvents _miPageNext As System.Windows.Forms.MenuItem
   Friend WithEvents _miPageLast As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelp As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Friend WithEvents _tbbPageLast As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbZoomOut As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbZoomNone As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbSep2 As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbZoomIn As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbFilePrintPreview As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbPagePrevious As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbPageNext As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbSep3 As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbPageFirst As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbSep1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbbFilePrint As System.Windows.Forms.ToolBarButton
   Friend WithEvents _tbMain As System.Windows.Forms.ToolBar
   Friend WithEvents _tbbFileOpen As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
      Me._mmMain = New System.Windows.Forms.MainMenu
      Me._miFile = New System.Windows.Forms.MenuItem
      Me._miFileOpen = New System.Windows.Forms.MenuItem
      Me._miFileSep1 = New System.Windows.Forms.MenuItem
      Me._miFilePrint = New System.Windows.Forms.MenuItem
      Me._miFilePageSetup = New System.Windows.Forms.MenuItem
      Me._miFilePrintPreview = New System.Windows.Forms.MenuItem
      Me._miFileSep2 = New System.Windows.Forms.MenuItem
      Me._miFileExit = New System.Windows.Forms.MenuItem
      Me._miZoom = New System.Windows.Forms.MenuItem
      Me._miZoomIn = New System.Windows.Forms.MenuItem
      Me._miZoomOut = New System.Windows.Forms.MenuItem
      Me._miZoomSep1 = New System.Windows.Forms.MenuItem
      Me._miZoomNormal = New System.Windows.Forms.MenuItem
      Me._miPage = New System.Windows.Forms.MenuItem
      Me._miPageFirst = New System.Windows.Forms.MenuItem
      Me._miPagePrevious = New System.Windows.Forms.MenuItem
      Me._miPageNext = New System.Windows.Forms.MenuItem
      Me._miPageLast = New System.Windows.Forms.MenuItem
      Me._miHelp = New System.Windows.Forms.MenuItem
      Me._miHelpAbout = New System.Windows.Forms.MenuItem
      Me._tbMain = New System.Windows.Forms.ToolBar
      Me._tbbFileOpen = New System.Windows.Forms.ToolBarButton
      Me._tbbSep1 = New System.Windows.Forms.ToolBarButton
      Me._tbbFilePrint = New System.Windows.Forms.ToolBarButton
      Me._tbbSep2 = New System.Windows.Forms.ToolBarButton
      Me._tbbZoomIn = New System.Windows.Forms.ToolBarButton
      Me._tbbZoomOut = New System.Windows.Forms.ToolBarButton
      Me._tbbZoomNone = New System.Windows.Forms.ToolBarButton
      Me._tbbFilePrintPreview = New System.Windows.Forms.ToolBarButton
      Me._tbbSep3 = New System.Windows.Forms.ToolBarButton
      Me._tbbPageFirst = New System.Windows.Forms.ToolBarButton
      Me._tbbPagePrevious = New System.Windows.Forms.ToolBarButton
      Me._tbbPageNext = New System.Windows.Forms.ToolBarButton
      Me._tbbPageLast = New System.Windows.Forms.ToolBarButton
      Me.SuspendLayout()
      '
      '_mmMain
      '
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miZoom, Me._miPage, Me._miHelp})
      '
      '_miFile
      '
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSep1, Me._miFilePrint, Me._miFilePageSetup, Me._miFilePrintPreview, Me._miFileSep2, Me._miFileExit})
      Me._miFile.Text = "&File"
      '
      '_miFileOpen
      '
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open..."
      '
      '_miFileSep1
      '
      Me._miFileSep1.Index = 1
      Me._miFileSep1.Text = "-"
      '
      '_miFilePrint
      '
      Me._miFilePrint.Index = 2
      Me._miFilePrint.Text = "&Print..."
      '
      '_miFilePageSetup
      '
      Me._miFilePageSetup.Index = 3
      Me._miFilePageSetup.Text = "Page &Setup..."
      '
      '_miFilePrintPreview
      '
      Me._miFilePrintPreview.Index = 4
      Me._miFilePrintPreview.Text = "Print Pre&view..."
      '
      '_miFileSep2
      '
      Me._miFileSep2.Index = 5
      Me._miFileSep2.Text = "-"
      '
      '_miFileExit
      '
      Me._miFileExit.Index = 6
      Me._miFileExit.Text = "E&xit"
      '
      '_miZoom
      '
      Me._miZoom.Index = 1
      Me._miZoom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miZoomIn, Me._miZoomOut, Me._miZoomSep1, Me._miZoomNormal})
      Me._miZoom.RadioCheck = True
      Me._miZoom.Text = "&Zoom"
      '
      '_miZoomIn
      '
      Me._miZoomIn.Index = 0
      Me._miZoomIn.RadioCheck = True
      Me._miZoomIn.Text = "&In (2x)"
      '
      '_miZoomOut
      '
      Me._miZoomOut.Index = 1
      Me._miZoomOut.RadioCheck = True
      Me._miZoomOut.Text = "&Out (2x)"
      '
      '_miZoomSep1
      '
      Me._miZoomSep1.Index = 2
      Me._miZoomSep1.RadioCheck = True
      Me._miZoomSep1.Text = "-"
      '
      '_miZoomNormal
      '
      Me._miZoomNormal.Index = 3
      Me._miZoomNormal.RadioCheck = True
      Me._miZoomNormal.Text = "&Normal (100%)"
      '
      '_miPage
      '
      Me._miPage.Index = 2
      Me._miPage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miPageFirst, Me._miPagePrevious, Me._miPageNext, Me._miPageLast})
      Me._miPage.Text = "&Page"
      '
      '_miPageFirst
      '
      Me._miPageFirst.Index = 0
      Me._miPageFirst.Text = "&First"
      '
      '_miPagePrevious
      '
      Me._miPagePrevious.Index = 1
      Me._miPagePrevious.Text = "&Previous"
      '
      '_miPageNext
      '
      Me._miPageNext.Index = 2
      Me._miPageNext.Text = "&Next"
      '
      '_miPageLast
      '
      Me._miPageLast.Index = 3
      Me._miPageLast.Text = "&Last"
      '
      '_miHelp
      '
      Me._miHelp.Index = 3
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      '
      '_tbMain
      '
      Me._tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me._tbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me._tbbFileOpen, Me._tbbSep1, Me._tbbFilePrint, Me._tbbSep2, Me._tbbZoomIn, Me._tbbZoomOut, Me._tbbZoomNone, Me._tbbFilePrintPreview, Me._tbbSep3, Me._tbbPageFirst, Me._tbbPagePrevious, Me._tbbPageNext, Me._tbbPageLast})
      Me._tbMain.DropDownArrows = True
      Me._tbMain.Location = New System.Drawing.Point(0, 0)
      Me._tbMain.Name = "_tbMain"
      Me._tbMain.ShowToolTips = True
      Me._tbMain.Size = New System.Drawing.Size(680, 28)
      Me._tbMain.TabIndex = 2
      '
      '_tbbFileOpen
      '
      Me._tbbFileOpen.ImageIndex = 0
      Me._tbbFileOpen.ToolTipText = "Open"
      '
      '_tbbSep1
      '
      Me._tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      '_tbbFilePrint
      '
      Me._tbbFilePrint.ImageIndex = 1
      Me._tbbFilePrint.ToolTipText = "Print"
      '
      '_tbbSep2
      '
      Me._tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      '_tbbZoomIn
      '
      Me._tbbZoomIn.ImageIndex = 2
      Me._tbbZoomIn.ToolTipText = "Zoom In"
      '
      '_tbbZoomOut
      '
      Me._tbbZoomOut.ImageIndex = 3
      Me._tbbZoomOut.ToolTipText = "Zoom Out"
      '
      '_tbbZoomNone
      '
      Me._tbbZoomNone.ImageIndex = 4
      Me._tbbZoomNone.ToolTipText = "No Zoom (100%)"
      '
      '_tbbFilePrintPreview
      '
      Me._tbbFilePrintPreview.ImageIndex = 5
      Me._tbbFilePrintPreview.ToolTipText = "Print Preview"
      '
      '_tbbSep3
      '
      Me._tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      '_tbbPageFirst
      '
      Me._tbbPageFirst.ImageIndex = 6
      '
      '_tbbPagePrevious
      '
      Me._tbbPagePrevious.ImageIndex = 7
      Me._tbbPagePrevious.ToolTipText = "Previous Page"
      '
      '_tbbPageNext
      '
      Me._tbbPageNext.ImageIndex = 8
      Me._tbbPageNext.ToolTipText = "Next Page"
      '
      '_tbbPageLast
      '
      Me._tbbPageLast.ImageIndex = 9
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(680, 417)
      Me.Controls.Add(Me._tbMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.ResumeLayout(False)

   End Sub

#End Region

   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()
      
      If Not Support.SetLicense() Then
         Return
      End If

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub

   ' the raster image viewer
   Private _viewer As ImageViewer

   ' codecs used in loading images
   Private _codecs As RasterCodecs

   ' Print document object
   Private _printDocument As PrintDocument
   Private _printPage As Integer

   Private Const _minScaleFactor As Single = 0.009F
   Private Const _maxScaleFactor As Single = 11.0F
   Private _openInitialPath As String = ""
   ' <summary>
   ' Initialize the Application
   ' </summary>

   Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' setup the toolbar images
      Dim btmp As Bitmap = New Bitmap(Me.GetType(), "ToolBar.bmp")
      btmp.MakeTransparent(btmp.GetPixel(0, 0))
      _tbMain.ImageList = New ImageList
      _tbMain.ImageList.ColorDepth = ColorDepth.Depth24Bit
      _tbMain.ImageList.ImageSize = New Size(btmp.Height, btmp.Height)
      _tbMain.ImageList.Images.AddStrip(btmp)

      ' setup our caption
      Messager.Caption = "LEADTOOLS for .NET VB Print Preview Demo"
      Text = Messager.Caption

      ' initialize the _viewer object
      _viewer = New ImageViewer
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()

      Try
         If ((Not PrinterSettings.InstalledPrinters Is Nothing) AndAlso (PrinterSettings.InstalledPrinters.Count > 0)) Then
            _printDocument = New PrintDocument
            AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
         Else
            _printDocument = Nothing
         End If
      Catch
         _printDocument = Nothing
      End Try

      ' initialize the codecs object
      _codecs = New RasterCodecs

      ' initialize controls
      UpdateMyControls()
   End Sub

   ' <summary>
   ' Updates the UI, depending on the application state.
   ' </summary>
   Private Sub UpdateMyControls()
      _miFilePrint.Enabled = ((Not IsNothing(_printDocument)) AndAlso (Not IsNothing(_viewer.Image)))
      _miFilePrint.Visible = ((Not IsNothing(_printDocument)) AndAlso (Not IsNothing(_viewer.Image)))
      _miFilePageSetup.Enabled = (Not IsNothing(_printDocument))
      _miFilePageSetup.Visible = (Not IsNothing(_printDocument))
      _miFilePrintPreview.Enabled = ((Not IsNothing(_printDocument)) AndAlso (Not IsNothing(_viewer.Image)))
      _miFilePrintPreview.Visible = ((Not IsNothing(_printDocument)) AndAlso (Not IsNothing(_viewer.Image)))
      _miFileSep2.Enabled = (Not IsNothing(_printDocument))
      _miFileSep2.Visible = (Not IsNothing(_printDocument))
      _miZoom.Enabled = (Not IsNothing(_viewer.Image))
      _miZoom.Visible = (Not IsNothing(_viewer.Image))
      If ((Not IsNothing(_viewer.Image)) AndAlso (_viewer.Image.PageCount > 1)) Then
         _miPage.Enabled = True
         _miPage.Visible = True
         Dim page As Integer = _viewer.Image.Page
         _miPageFirst.Enabled = (page <> 1)
         _miPageFirst.Visible = True
         _miPagePrevious.Enabled = (page <> 1)
         _miPagePrevious.Visible = True
         _miPageNext.Enabled = (page <> _viewer.Image.PageCount)
         _miPageNext.Visible = True
         _miPageLast.Enabled = (page <> _viewer.Image.PageCount)
         _miPageLast.Visible = True

         _tbbPageFirst.Enabled = _miPageFirst.Enabled
         _tbbPageFirst.Visible = True
         _tbbPagePrevious.Enabled = _miPagePrevious.Enabled
         _tbbPagePrevious.Visible = True
         _tbbPageNext.Enabled = _miPageNext.Enabled
         _tbbPageNext.Visible = True
         _tbbPageLast.Enabled = _miPageLast.Enabled
         _tbbPageLast.Visible = True
      Else
         _miPage.Enabled = False
         _miPage.Visible = False
         _tbbPageFirst.Enabled = False
         _tbbPageFirst.Visible = False
         _tbbPagePrevious.Enabled = False
         _tbbPagePrevious.Visible = False
         _tbbPageNext.Enabled = False
         _tbbPageNext.Visible = False
         _tbbPageLast.Enabled = False
         _tbbPageLast.Visible = False
      End If
      _tbbFilePrint.Enabled = _miFilePrint.Enabled
      _tbbFilePrint.Visible = _miFilePrint.Visible
      _tbbSep2.Enabled = (Not IsNothing(_viewer.Image))
      _tbbSep2.Visible = (Not IsNothing(_viewer.Image))
      _tbbZoomIn.Enabled = (Not IsNothing(_viewer.Image))
      _tbbZoomIn.Visible = (Not IsNothing(_viewer.Image))
      _tbbZoomOut.Enabled = (Not IsNothing(_viewer.Image))
      _tbbZoomOut.Visible = (Not IsNothing(_viewer.Image))
      _tbbZoomNone.Enabled = (Not IsNothing(_viewer.Image))
      _tbbZoomNone.Visible = (Not IsNothing(_viewer.Image))
      _tbbFilePrintPreview.Enabled = _miFilePrintPreview.Enabled
      _tbbFilePrintPreview.Visible = _miFilePrintPreview.Visible
      _tbbSep3.Enabled = (Not IsNothing(_viewer.Image))
      _tbbSep3.Visible = (Not IsNothing(_viewer.Image))

      _tbbZoomOut.Enabled = (_viewer.ScaleFactor > _minScaleFactor)
      _tbbZoomIn.Enabled = (_viewer.ScaleFactor < _maxScaleFactor)
      _tbbZoomNone.Enabled = (_viewer.ScaleFactor <> 1)

      _miZoomIn.Enabled = _tbbZoomIn.Enabled
      _miZoomOut.Enabled = _tbbZoomOut.Enabled
      _miZoomNormal.Enabled = _tbbZoomNone.Enabled
   End Sub

   ' <summary>
   ' Open new image
   ' </summary>
   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      Try
         Dim loader As ImageFileLoader = New ImageFileLoader

         loader.OpenDialogInitialPath = _openInitialPath
         loader.ShowLoadPagesDialog = True
         If (loader.Load(Me, _codecs, True) > 0) Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            ' update the caption
            Text = String.Format("{0} - {1}", loader.FileName, Messager.Caption)

            ' set the new image in the viewer
            _viewer.Image = loader.Image
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   ' <summary>
   ' Print the current image
   ' </summary>

   Private Sub _miFilePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFilePrint.Click
      _printPage = 1
      If (Not IsNothing(_printDocument)) Then
         Try
            _printDocument.Print()
         Catch
         End Try
      End If
   End Sub

   ' <summary>
   ' Setup the Page for printing
   ' </summary>
   Private Sub _miFilePageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFilePageSetup.Click
      Try
         _printPage = 1
         Dim dlg As New PageSetupDialog
         dlg.Document = _printDocument
         dlg.ShowDialog(Me)
      Catch
      End Try
   End Sub

   ' <summary>
   ' Show the Print Preview dialog
   ' </summary>
   Private Sub _miFilePrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFilePrintPreview.Click
      Try
         _printPage = 1
         If (Not IsNothing(_printDocument)) Then
            Dim dlg As New PrintPreviewDialog
            Dim i As Control
            dlg.Icon = Icon
            For Each i In dlg.Controls
               If (TypeOf (i) Is PrintPreviewControl) Then
                  Dim c As PrintPreviewControl = CType(i, PrintPreviewControl)
                  c.StartPage = _viewer.Image.Page - 1
                  Exit For
               End If
            Next
            dlg.Document = _printDocument
            dlg.ShowDialog(Me)
         End If
      Catch
      End Try
   End Sub

   ' <summary>
   ' Shutdown
   ' </summary>
   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   ' <summary>
   ' Handles Zoom menu
   ' </summary>

   Private Sub _miZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miZoomIn.Click, _
                                                                                                _miZoomOut.Click, _
                                                                                                _miZoomNormal.Click
      Dim scaleFactor As Double = _viewer.ScaleFactor

      If (sender Is _miZoomIn) Then
         scaleFactor *= 2
      ElseIf (sender Is _miZoomOut) Then
         scaleFactor /= 2
      ElseIf (sender Is _miZoomNormal) Then
         scaleFactor = 1
      End If

      _viewer.Zoom(ControlSizeMode.None, Math.Max(_minScaleFactor, Math.Min(_maxScaleFactor, scaleFactor)), _viewer.DefaultZoomOrigin)
      UpdateMyControls()
   End Sub

   ' <summary>
   ' Handles Page menu
   ' </summary>
   Private Sub _miPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miPageFirst.Click, _
                                                                                                _miPagePrevious.Click, _
                                                                                                _miPageNext.Click, _
                                                                                                _miPageLast.Click
      Dim page As Integer = _viewer.Image.Page
      If (sender Is _miPageFirst) Then
         page = 1
      ElseIf (sender Is _miPagePrevious) Then
         page -= 1
      ElseIf (sender Is _miPageNext) Then
         page += 1
      ElseIf (sender Is _miPageLast) Then
         page = _viewer.Image.PageCount
      End If
      page = Math.Max(1, Math.Min(_viewer.Image.PageCount, page))

      If (page <> _viewer.Image.Page) Then
         _viewer.Image.Page = page
         UpdateMyControls()
      End If
   End Sub

   ' <summary>
   ' Show the About dialog
   ' </summary>
   Private Sub _miHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Print Preview", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   ' <summary>
   ' Toolbar button is clicked, call the corresponding menu PreformClick method
   ' </summary>
   Private Sub _tbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles _tbMain.ButtonClick
      If (e.Button Is _tbbFileOpen) Then
         _miFileOpen.PerformClick()
      ElseIf (e.Button Is _tbbFilePrint) Then
         _miFilePrint.PerformClick()
      ElseIf (e.Button Is _tbbZoomIn) Then
         _miZoomIn.PerformClick()
      ElseIf (e.Button Is _tbbZoomOut) Then
         _miZoomOut.PerformClick()
      ElseIf (e.Button Is _tbbZoomNone) Then
         _miZoomNormal.PerformClick()
      ElseIf (e.Button Is _tbbFilePrintPreview) Then
         _miFilePrintPreview.PerformClick()
      ElseIf (e.Button Is _tbbPageFirst) Then
         _miPageFirst.PerformClick()
      ElseIf (e.Button Is _tbbPagePrevious) Then
         _miPagePrevious.PerformClick()
      ElseIf (e.Button Is _tbbPageNext) Then
         _miPageNext.PerformClick()
      ElseIf (e.Button Is _tbbPageLast) Then
         _miPageLast.PerformClick()
      End If
   End Sub

   ' <summary>
   ' Print Page event
   ' </summary>
   Private Sub _printDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
      Dim savePage As Integer = _viewer.Image.Page

      Try
         _viewer.Image.Page = _printPage
         _printPage = _printPage + 1
         Dim img As Image = RasterImageConverter.ConvertToImage(_viewer.Image, ConvertToImageOptions.None)

         Try
            If (DialogUtilities.CanRunPrintPreview) Then
               e.Graphics.DrawImage(img, 0, 0)
            End If
         Finally
            img.Dispose()
         End Try


         e.HasMorePages = _printPage <= _viewer.Image.PageCount
         If (_printPage > _viewer.Image.PageCount) Then
            _printPage = 1
         End If
      Finally
         _viewer.Image.Page = savePage
      End Try
   End Sub
End Class
