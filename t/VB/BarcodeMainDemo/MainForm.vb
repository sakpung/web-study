' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Codecs
Imports Leadtools.Twain
Imports Leadtools.Barcode
Imports System.Drawing.Drawing2D
Imports Leadtools.Controls
Imports BarcodeMainDemo.Leadtools.Demos
Imports Leadtools.Drawing
Imports Leadtools.Demos.Dialogs
Partial Public Class MainForm : Inherits Form
#Region "Private Variables"
   ' The RasterCodecs instance we will use to load/save images
   Private _rasterCodecs As RasterCodecs
   ' The TWAIN scanning session we will use to scan (if available)
   Private _twainSession As TwainSession
   ' The Barcode engine
   Private _barcodeEngine As BarcodeEngine
   ' Barcodes read or written in this document
   Private _documentBarcodes As DocumentBarcodes

   Private _demoOptions As DemoOptions = DemoOptions.Default

   ' A RasterImage that holds barcode symbology samples
   Private _sampleSymbologiesRasterImage As RasterImage

#End Region ' Private Variables

   Public Shared InversePerspectiveActive As Boolean = False

   Private _interactiveToolsList As Dictionary(Of ImageViewer, Form)
   Public ReadOnly Property InteractiveToolsList() As Dictionary(Of ImageViewer, Form)
      Get
         Return _interactiveToolsList
      End Get
   End Property

   Public Sub New()
      InitializeComponent()

      Messager.Caption = "Barcode VB .NET Demo"
      Text = Messager.Caption
   End Sub

#Region "UI"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         Try
            If (Not Init()) Then
               Close()
               Return
            End If
         Catch ex As Exception
            ShowError(ex)
            Close()
         End Try
      End If

      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
      _demoOptions.Save()

      CleanUp()

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub _newToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _newToolStripButton.Click
      DoNewDocument()
   End Sub

   Private Sub _openToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _openToolStripButton.Click
      DoOpenDocument()
   End Sub

   Private Sub _saveToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveToolStripButton.Click
      DoSaveDocument()
   End Sub

   Private Sub _readBarcodesToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _readBarcodesToolStripButton.Click
      DoReadBarcodes(False, LeadRect.Empty, True)
   End Sub

   Private Sub _writeBarcodeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _writeBarcodeToolStripButton.Click
      DoWriteBarcode(LeadRect.Empty)
   End Sub

   Private Sub _readBarcodeOptionsToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _readBarcodeOptionsToolStripButton.Click
      DoReadBarcodeOptions()
   End Sub

   Private Sub _fileToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _fileToolStripMenuItem.DropDownOpening
      _saveToolStripMenuItem.Visible = _viewerControl.Visible
      _closeToolStripMenuItem.Visible = _viewerControl.Visible
   End Sub

   Private Sub _newToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _newToolStripMenuItem.Click
      DoNewDocument()
   End Sub

   Private Sub _openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _openToolStripMenuItem.Click
      DoOpenDocument()
   End Sub

   Private Sub _saveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveToolStripMenuItem.Click
      DoSaveDocument()
   End Sub

   Private Sub _closeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _closeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      SetDocument(Nothing, Nothing)
   End Sub

   Private Sub _selectSourceToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _selectSourceToolStripMenuItem.Click
      SelectTwainSource()
   End Sub

   Private Sub _acquireToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _acquireToolStripMenuItem.Click
      ScanUsingTwain()
   End Sub

   Private Sub _exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _exitToolStripMenuItem.Click
      Close()
   End Sub

   Private Sub _editToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _editToolStripMenuItem.DropDownOpening
      _copyImageToolStripMenuItem.Visible = _viewerControl.Visible

      _pasteImageToolStripMenuItem.Enabled = RasterClipboard.IsReady
   End Sub

   Private Sub _copyImageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _copyImageToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Try
         Dim wait As WaitCursor = New WaitCursor()
         Try
            RasterClipboard.Copy(Me.Handle, _viewerControl.RasterImageViewer.Image, RasterClipboardCopyFlags.Dib)
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub _pasteImageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _pasteImageToolStripMenuItem.Click
      If (Not RasterClipboard.IsReady) Then
         Return
      End If

      Dim image As RasterImage = Nothing

      Try
         Dim wait As WaitCursor = New WaitCursor()
         Try
            image = RasterClipboard.Paste(Me.Handle)
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      Catch ex As Exception
         ShowError(ex)
      End Try

      If Not image Is Nothing Then
         SetDocument(image, DemosGlobalization.GetResxString(Me.GetType(), "Resx_ClipboardImage"))
      End If
   End Sub

   Private Sub _viewToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _fitWidthToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode = ControlSizeMode.FitWidth
      _fitPageToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode = ControlSizeMode.FitAlways
   End Sub

   Private Sub _zoomOutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomOutToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.ZoomViewer(True)
   End Sub

   Private Sub _zoomInToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomInToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.ZoomViewer(False)
   End Sub

   Private Sub _fitWidthToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fitWidthToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.FitPage(True)
   End Sub

   Private Sub _fitPageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fitPageToolStripMenuItem.Click
      _viewerControl.FitPage(False)
   End Sub

   Private Sub _pageToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _pageToolStripMenuItem.DropDownOpening
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim page As Integer = _viewerControl.RasterImageViewer.Image.Page
      Dim pageCount As Integer = _viewerControl.RasterImageViewer.Image.PageCount

      _previousPageToolStripMenuItem.Enabled = page > 1
      _nextPageToolStripMenuItem.Enabled = page < pageCount
      _gotoPageToolStripMenuItem.Enabled = pageCount > 1
   End Sub

   Private Sub _previousPageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _previousPageToolStripMenuItem.Click
      GotoPage(_viewerControl.RasterImageViewer.Image.Page - 1)
   End Sub

   Private Sub _nextPageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _nextPageToolStripMenuItem.Click
      GotoPage(_viewerControl.RasterImageViewer.Image.Page + 1)
   End Sub

   Private Sub _gotoPageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _gotoPageToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim dlg As GotoPageDialog = New GotoPageDialog()
      Try
         dlg.DocumentPage = _viewerControl.RasterImageViewer.Image.Page
         dlg.DocumentPageCount = _viewerControl.RasterImageViewer.Image.PageCount
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            GotoPage(dlg.DocumentPage)
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Private Sub _interactiveToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _interactiveToolStripMenuItem.DropDownOpening
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim interactiveMode As ViewerControlInteractiveMode = _viewerControl.InteractiveMode

      _selectModeToolStripMenuItem.Checked = (interactiveMode = ViewerControlInteractiveMode.SelectMode)
      _panModeToolStripMenuItem.Checked = (interactiveMode = ViewerControlInteractiveMode.PanMode)
      _zoomToModeToolStripMenuItem.Checked = (interactiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode)
      _drawRegionModeToolStripMenuItem.Checked = (interactiveMode = ViewerControlInteractiveMode.RegionMode)
      _readBarcodeModeToolStripMenuItem.Checked = (interactiveMode = ViewerControlInteractiveMode.ReadBarcodeMode)
      _writeBarcodeModeToolStripMenuItem.Checked = (interactiveMode = ViewerControlInteractiveMode.WriteBarcodeMode)
      _writeBarcodeModeToolStripMenuItem.Enabled = _viewerControl.ShowBarcodes
      _deleteRegionToolStripMenuItem.Enabled = _viewerControl._viewerRegion
   End Sub

   Private Sub _selectModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _selectModeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.SelectMode
   End Sub

   Private Sub _panModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panModeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.PanMode
   End Sub

   Private Sub _zoomToModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomToModeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
   End Sub

   Private Sub _drawRegionModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _drawRegionModeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.RegionMode
   End Sub

   Private Sub _readBarcodeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _readBarcodeModeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.ReadBarcodeMode
   End Sub

   Private Sub _barcodeImageTypeToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _barcodeImageTypeToolStripMenuItem.DropDownOpening
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _scannedDocumentImageTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.ImageType = BarcodeImageType.ScannedDocument)
      _pictureImageTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.ImageType = BarcodeImageType.Picture)
      _unknownImageTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.ImageType = BarcodeImageType.Unknown)
   End Sub

   Private Sub _scannedDocumentImageTypeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _scannedDocumentImageTypeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _barcodeEngine.Reader.ImageType = BarcodeImageType.ScannedDocument
   End Sub

   Private Sub _pictureImageTypeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _pictureImageTypeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _barcodeEngine.Reader.ImageType = BarcodeImageType.Picture
   End Sub

   Private Sub _unknownImageTypeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _unknownImageTypeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _barcodeEngine.Reader.ImageType = BarcodeImageType.Unknown
   End Sub

   Private Sub _barcodeBoundaryTypeToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _barcodeBoundaryTypeToolStripMenuItem.DropDownOpening
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _rectangleBoundaryTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.EnableReturnFourPoints = False)
      _fourPointsBoundaryTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.EnableReturnFourPoints = True)

   End Sub

   Private Sub _rectangleBoundaryTypeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rectangleBoundaryTypeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _barcodeEngine.Reader.EnableReturnFourPoints = False
      _viewerControl.FourPoints = False
      ChangingBoundingType()
      _viewerControl.RasterImageViewer.Invalidate()
   End Sub

   Private Sub _fourPointsBoundaryTypeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fourPointsBoundaryTypeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _barcodeEngine.Reader.EnableReturnFourPoints = True
      _viewerControl.FourPoints = True
      ChangingBoundingType()
      _viewerControl.RasterImageViewer.Invalidate()
   End Sub

   Private Sub _writeBarcodeModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _writeBarcodeModeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.WriteBarcodeMode
   End Sub

   Private Sub _deleteRegionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _deleteRegionToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _viewerControl._viewerRegion = False
      _viewerControl.RasterImageViewer.Image.MakeRegionEmpty()
      _viewerControl.ImageRegionChanged()
      _viewerControl.RasterImageViewer.Invalidate()
   End Sub


   Private Sub _preprocessingToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _preprocessingToolStripMenuItem.DropDownOpening
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _preprocessAllPagesToolStripMenuItem.Enabled = _viewerControl.RasterImageViewer.Image.PageCount > 1

      If _viewerControl.RasterImageViewer.Image.BitsPerPixel = 1 Then
         _lineRemoveToolStripMenuItem.Enabled = True
      Else
         _lineRemoveToolStripMenuItem.Enabled = False
      End If

      If _viewerControl.RasterImageViewer.Image.BitsPerPixel = 8 OrElse _viewerControl.RasterImageViewer.Image.BitsPerPixel = 24 OrElse _viewerControl.RasterImageViewer.Image.BitsPerPixel = 32 Then
         _perspectiveDeskewToolStripMenuItem.Enabled = True
      Else
         _perspectiveDeskewToolStripMenuItem.Enabled = False
      End If
   End Sub

   Private Sub _preprocessAllPagesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _preprocessAllPagesToolStripMenuItem.Click
      _preprocessAllPagesToolStripMenuItem.Checked = Not _preprocessAllPagesToolStripMenuItem.Checked
   End Sub

   Private Sub _flipToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _flipToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim cmd As FlipCommand = New FlipCommand(False)
      RunImageProcessingCommand(cmd)
   End Sub

   Private Sub _reverseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _reverseToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim cmd As FlipCommand = New FlipCommand(True)
      RunImageProcessingCommand(cmd)
   End Sub

   Private Sub _rotate90ClockwiseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rotate90ClockwiseToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim cmd As RotateCommand = New RotateCommand(90 * 100, RotateCommandFlags.Resize, RasterColor.FromKnownColor(RasterKnownColor.White))
      RunImageProcessingCommand(cmd)
   End Sub

   Private Sub _rotate90CounterclockwiseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rotate90CounterclockwiseToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim cmd As RotateCommand = New RotateCommand(-90 * 100, RotateCommandFlags.Resize, RasterColor.FromKnownColor(RasterKnownColor.White))
      RunImageProcessingCommand(cmd)
   End Sub

   Private Sub _noiseMinFilterToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _noiseMinFilterToolStripMenuItem.Click
      ' Check support required to use this demo
      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         Messager.ShowError(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_LEADDocumentSupport"))
         Return
      End If

      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If
      Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Min)
      If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
         Dim cmd As MinimumCommand = New MinimumCommand(dlg.Value)
         RunImageProcessingCommand(cmd)
      End If
   End Sub

   Private Sub _noiseMedianFilterToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _noiseMedianFilterToolStripMenuItem.Click
      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         Messager.ShowError(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_LEADDocumentSupport"))
         Return
      End If

      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If
      Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Median)
      If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
         Dim cmd As MedianCommand = New MedianCommand(dlg.Value)
         RunImageProcessingCommand(cmd)
      End If
   End Sub

   Private Sub _noiseMaxFilterToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _noiseMaxFilterToolStripMenuItem.Click
      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         Messager.ShowError(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_LEADDocumentSupport"))
         Return
      End If

      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If
      Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Max)
      If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
         Dim cmd As MaximumCommand = New MaximumCommand(dlg.Value)
         RunImageProcessingCommand(cmd)
      End If
   End Sub

   Private Sub _lineRemoveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _lineRemoveToolStripMenuItem.Click
      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         Messager.ShowError(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_LEADDocumentSupport"))
         Return
      End If

      Try
         Dim _LineRemove As LineRemoveCommand = Nothing
         Dim dlg As LineRemoveDialog = New LineRemoveDialog(New LineRemoveCommand(), _viewerControl.RasterImageViewer.Image.XResolution, _viewerControl.RasterImageViewer.Image.YResolution)
         ' Open the LineRemoveCommand dialog
         If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _LineRemove = New LineRemoveCommand()
            '_LineRemove.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
            ' Update the LineRemoveCommand.Type to select which lines to remove
            _LineRemove.Type = dlg.LineRemoveCommand.Type
            ' Update the LineRemoveCommand UseDpi flag 
            _LineRemove.Flags = dlg.LineRemoveCommand.Flags
            ' Update the LineRemoveCommand.GapLength to set the maximum length of a break or a hole in a line.
            _LineRemove.GapLength = dlg.LineRemoveCommand.GapLength
            ' Update the LineRemoveCommand.MaximumLineWidth to set the maximum average width of a line that is considered for removal.   
            _LineRemove.MaximumLineWidth = dlg.LineRemoveCommand.MaximumLineWidth
            ' Update the LineRemoveCommand.MinimumLineLength to set the minimum length of a line considered for removal.   
            _LineRemove.MinimumLineLength = dlg.LineRemoveCommand.MinimumLineLength
            ' Update the LineRemoveCommand.MaximumWallPercent to set the maximum number of wall slices (expressed as a percent of the total length of the line) that are allowed.
            _LineRemove.MaximumWallPercent = dlg.LineRemoveCommand.MaximumWallPercent
            ' Update LineRemoveCommand.Wall to set the height of a wall. Walls are slices of a line that are too wide to be considered part of the line. 
            _LineRemove.Wall = dlg.LineRemoveCommand.Wall
            'ProgressBar.Visible = true;
            ' Run the command on the loaded image
            _LineRemove.Run(_viewerControl.RasterImageViewer.Image)

         End If

      Catch ex As RasterException
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _imageDeskewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _imageDeskewToolStripMenuItem.Click
      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         Messager.ShowError(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_LEADDocumentSupport"))
         Return
      End If

      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      _preprocessAllPagesToolStripMenuItem.Checked = False

      Dim cmd As DeskewCommand = New DeskewCommand()
      RunImageProcessingCommand(cmd)
   End Sub

   Private Sub _segmentationPerspectiveMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _segmentationPerspectiveMenuItem.Click
      If _interactiveToolsList.ContainsKey(_viewerControl.RasterImageViewer) Then
         Return
      End If

      _mainMenuStrip.Enabled = False
      _mainToolStrip.Enabled = False
      _viewerControl._toolStrip.Enabled = False
      _viewerControl.InteractiveMode = ViewerControlInteractiveMode.SelectMode

      Dim dlg As PerspectiveDialog = New PerspectiveDialog(Me, _viewerControl)
      InversePerspectiveActive = True
      dlg.Show()

      _interactiveToolsList.Add(_viewerControl.RasterImageViewer, dlg)
   End Sub

   Public Sub _enableMenus()
      _mainMenuStrip.Enabled = True
      _mainToolStrip.Enabled = True
      _viewerControl._toolStrip.Enabled = True
   End Sub

   Private Sub _perspectiveDeskewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _perspectiveDeskewToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim cmd As PerspectiveDeskewCommand = New PerspectiveDeskewCommand()
      RunImageProcessingCommand(cmd)
   End Sub

   Private Sub RunImageProcessingCommand(ByVal cmd As RasterCommand)
      ' We must clear all the barcodes found
      DoClearAllBarcodes()

      ' Run the command on all or just current page
      Dim allPages As Boolean = _preprocessAllPagesToolStripMenuItem.Checked

      Dim image As RasterImage = _viewerControl.RasterImageViewer.Image
      Dim savePageNumber As Integer = image.Page

      Try
         Dim wait As WaitCursor = New WaitCursor()
         Try
            Dim page As Integer = 1
            Do While page <= image.PageCount
               If allPages Then
                  image.Page = page
               End If

               If page = image.Page Then
                  cmd.Run(image)
               End If
               page += 1
            Loop
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      Catch ex As Exception
         ShowError(ex)
      Finally
         If savePageNumber <> image.Page Then
            image.Page = savePageNumber
         End If

         _pagesControl.SetDocument(image)
      End Try
   End Sub

   Private Sub _barcodeToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _barcodeToolStripMenuItem.DropDownOpening
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim barcodeSelected As Boolean = _documentBarcodes.Pages(_viewerControl.RasterImageViewer.Image.Page - 1).SelectedIndex <> -1

      _deleteSelectedBarcodeToolStripMenuItem.Enabled = barcodeSelected
      _zoomToSelectedBarcodeToolStripMenuItem.Enabled = barcodeSelected
      _showBarcodesToolStripMenuItem.Checked = _viewerControl.ShowBarcodes

      Dim count As Integer = 0
      Dim i As Integer = 0
      Do While i < _documentBarcodes.Pages.Count
         count += _documentBarcodes.Pages(i).Barcodes.Count
         i += 1
      Loop

      _clearAllBarcodesToolStripMenuItem.Enabled = count > 0
      _exportBarcodesToolStripMenuItem.Enabled = count > 0
   End Sub

   Private Sub _readBarcodeOptionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _readBarcodeOptionsToolStripMenuItem.Click
      DoReadBarcodeOptions()
   End Sub

   Private Sub _readBarcodesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _readBarcodesToolStripMenuItem.Click
      DoReadBarcodes(False, LeadRect.Empty, True)
   End Sub

   Private Sub _writeBarcodeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _writeBarcodeToolStripMenuItem.Click
      DoWriteBarcode(LeadRect.Empty)
   End Sub

   Private Sub _showBarcodesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _showBarcodesToolStripMenuItem.Click
      _showBarcodesToolStripMenuItem.Checked = Not _showBarcodesToolStripMenuItem.Checked
      _viewerControl.ShowBarcodes = _showBarcodesToolStripMenuItem.Checked
      _viewerControl.RasterImageViewer.Invalidate()
   End Sub

   Private Sub _saveCurrentReadOptionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveCurrentReadOptionsToolStripMenuItem.Click
      SaveBarcodeOptions(True)
   End Sub

   Private Sub _loadReadOptionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _loadReadOptionsToolStripMenuItem.Click
      LoadBarcodeOptions(True)
   End Sub

   Private Sub _saveCurrentWriteOptionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveCurrentWriteOptionsToolStripMenuItem.Click
      SaveBarcodeOptions(False)
   End Sub

   Private Sub _loadWriteOptionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _loadWriteOptionsToolStripMenuItem.Click
      LoadBarcodeOptions(False)
   End Sub

   Private Sub _deleteSelectedBarcodeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _deleteSelectedBarcodeToolStripMenuItem.Click
      DoDeleteSelectedBarcode()
   End Sub

   Private Sub _zoomToSelectedBarcodeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomToSelectedBarcodeToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      DoZoomToSelectedBarcode()
   End Sub

   Private Sub _exportBarcodesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _exportBarcodesToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      DoExportBarcodes()
   End Sub

   Private Sub _clearAllBarcodesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _clearAllBarcodesToolStripMenuItem.Click
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      DoClearAllBarcodes()
   End Sub

   Private Sub _aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _aboutToolStripMenuItem.Click
      Using aboutDialog As New AboutDialog("Barcode", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _viewerControl_Action(ByVal sender As Object, ByVal e As ActionEventArgs) Handles _viewerControl.Action
      If e.Action = "PageNumberChanged" Then
         GotoPage(CInt(e.Data))
      ElseIf e.Action = "ReadBarcode" Then
         DoReadBarcodes(True, CType(e.Data, LeadRect), False)
      ElseIf e.Action = "WriteBarcode" Then
         DoWriteBarcode(CType(e.Data, LeadRect))
      ElseIf e.Action = "SelectedBarcodeChanged" Then
         _documentBarcodes.Pages(_viewerControl.RasterImageViewer.Image.Page - 1).SelectedIndex = CInt(e.Data)
         _viewerControl.RasterImageViewer.Invalidate()
         _barcodeControl.SelectedBarcodeChanged()
      End If
   End Sub

   Private Sub _pagesControl_Action(ByVal sender As Object, ByVal e As ActionEventArgs) Handles _pagesControl.Action
      If e.Action = "PageNumberChanged" Then
         GotoPage(CInt(e.Data))
      End If
   End Sub

   Private Sub _barcodeControl_Action(ByVal sender As Object, ByVal e As ActionEventArgs) Handles _barcodeControl.Action
      If e.Action = "SelectedBarcodeChanged" Then
         Dim selectedIndex As Integer = CInt(e.Data)
         _documentBarcodes.Pages(_viewerControl.RasterImageViewer.Image.Page - 1).SelectedIndex = CInt(e.Data)
         _viewerControl.RasterImageViewer.Invalidate()
      ElseIf e.Action = "DeleteSelectedBarcode" Then
         DoDeleteSelectedBarcode()
      ElseIf e.Action = "ZoomToSelectedBarcode" Then
         DoZoomToSelectedBarcode()
      ElseIf e.Action = "ViewSelectedBarcodeIDData" Then
         DoViewSelectedBarcodeIDData()
      End If
   End Sub

   Private Sub UpdateUIState()
      ' Update the status of the various UI controls

      Dim documentOk As Boolean = False
      Dim pageCount As Integer = 1

      If Not _viewerControl.RasterImageViewer.Image Is Nothing Then
         documentOk = True
         pageCount = _viewerControl.RasterImageViewer.Image.PageCount
      End If

      _viewToolStripMenuItem.Visible = documentOk
      _pageToolStripMenuItem.Visible = documentOk
      _interactiveToolStripMenuItem.Visible = documentOk
      _barcodeToolStripMenuItem.Visible = documentOk
      _preprocessingToolStripMenuItem.Visible = documentOk

      _saveToolStripButton.Visible = documentOk
      _readBarcodesToolStripButton.Visible = documentOk
      _writeBarcodeToolStripButton.Visible = documentOk
      _readBarcodeOptionsToolStripButton.Visible = documentOk

      _viewerControl.Visible = documentOk
      _pagesControl.Visible = documentOk AndAlso pageCount > 1
      _barcodeControl.Visible = documentOk
   End Sub
#End Region ' UI

#Region "TWAIN"
   Private Sub StartupTwain()
      ' See if we can start a scanning session
      Try
         If TwainSession.IsAvailable(Me.Handle) Then
            _twainSession = New TwainSession()

            _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", Messager.Caption, TwainStartupFlags.None)

            AddHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
         End If
      Catch ex As TwainException
         _twainSession = Nothing

         If ex.Code = TwainExceptionCode.InvalidDll Then
            Messager.ShowError(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_OldVersion"))
         Else
            ShowError(ex)
         End If
      Catch ex As Exception
         _twainSession = Nothing
         ShowError(ex)
      Finally
         If _twainSession Is Nothing Then
            ' No scanning device or an error
            ' Hide scanning related menu items
            _scanToolStripMenuItem.Visible = False
            _fileSep2ToolStripMenuItem.Visible = False
         End If
      End Try
   End Sub

   Private Sub ShutdownTwain()
      If Not _twainSession Is Nothing Then
         RemoveHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
         _twainSession.Shutdown()
      End If
   End Sub

   Private Sub _twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
      SetDocument(e.Image, DemosGlobalization.GetResxString(Me.GetType(), "Resx_TwainScanning"))
   End Sub

   Private Sub SelectTwainSource()
      ' Select the TWAIN scanning source
      _twainSession.SelectSource(String.Empty)
   End Sub

   Private Sub ScanUsingTwain()
      ' Scan the pages using TWAIN
      Try
         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
            Return
         End If
         _twainSession.Acquire(TwainUserInterfaceFlags.Show)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region ' TWAIN

   Private Function Init() As Boolean
      ' Check support required to use this demo
      If (RasterSupport.IsLocked(RasterSupportType.Barcodes1D) And RasterSupport.IsLocked(RasterSupportType.Barcodes2D)) Then
         Messager.ShowError(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_LEADBarcodeSupport"))
         Return False
      End If

      _rasterCodecs = New RasterCodecs()
      _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300
      _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300
      _interactiveToolsList = New Dictionary(Of ImageViewer, Form)()

      _viewerControl.Visible = False
      _pagesControl.Visible = False
      _barcodeControl.Visible = False

      StartupTwain()
      InitBarcodeEngine()

      UpdateUIState()

      LoadDefaultDocument()

      Return True
   End Function

   Private Sub CleanUp()
      ' Delete all resources
      If Not _sampleSymbologiesRasterImage Is Nothing Then
         _sampleSymbologiesRasterImage.Dispose()
      End If

      If Not _rasterCodecs Is Nothing Then
         _rasterCodecs.Dispose()
      End If

      ShutdownTwain()
   End Sub

   Private Sub ShowError(ByVal ex As Exception)
      Dim re As RasterException = CType(IIf(TypeOf ex Is RasterException, ex, Nothing), RasterException)
      If Not re Is Nothing Then
         Messager.ShowError(Me, String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_LEADError"), re.Code, ex.Message))
      Else
         Dim tw As TwainException = CType(IIf(TypeOf ex Is TwainException, ex, Nothing), TwainException)
         If Not tw Is Nothing Then
            Messager.ShowError(Me, String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_TwainError"), tw.Code, ex.Message))
         Else
            Messager.ShowError(Me, ex)
         End If
      End If
   End Sub

   Private Sub LoadDefaultDocument()
      ' Load the default image

#If LT_CLICKONCE Then
		 Dim documentFileNames As String() = New String () { "Barcode1.tif", "Barcode2.tif" }
#Else
      Dim documentFileNames As String() = New String() {Path.Combine(DemosGlobal.ImagesFolder, "Barcode1.tif"), Path.Combine(DemosGlobal.ImagesFolder, "Barcode2.tif")}
#End If
      Dim image As RasterImage = Nothing

      For Each documentFileName As String In documentFileNames
         If File.Exists(documentFileName) Then
            Try
               Dim wait As WaitCursor = New WaitCursor()
               Try
                  Dim pageImage As RasterImage = _rasterCodecs.Load(documentFileName)

                  If image Is Nothing Then
                     image = pageImage
                  Else
                     image.AddPage(pageImage)
                     pageImage.Dispose()
                  End If
               Finally
                  CType(wait, IDisposable).Dispose()
               End Try
            Catch ex As Exception
               Messager.ShowFileOpenError(Me, documentFileName, ex)
            End Try
         End If
      Next documentFileName

      If Not image Is Nothing Then
         SetDocument(image, DemosGlobalization.GetResxString(Me.GetType(), "Resx_DefaultDocument"))
      End If
   End Sub

   Private Sub DoNewDocument()
      Dim pages As Integer
      Dim bitsPerPixel As Integer
      Dim width As Integer
      Dim height As Integer
      Dim resolution As Integer

      Dim dlg As NewDocumentDialog = New NewDocumentDialog()
      Try
         dlg.DocumentPages = _demoOptions.NewDocumentPages
         dlg.DocumentBitsPerPixel = _demoOptions.NewDocumentBitsPerPixel
         dlg.DocumentResolution = _demoOptions.NewDocumentResolution
         dlg.DocumentWidth = _demoOptions.NewDocumentWidth
         dlg.DocumentHeight = _demoOptions.NewDocumentHeight

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _demoOptions.NewDocumentPages = dlg.DocumentPages
            _demoOptions.NewDocumentBitsPerPixel = dlg.DocumentBitsPerPixel
            _demoOptions.NewDocumentResolution = dlg.DocumentResolution
            _demoOptions.NewDocumentWidth = dlg.DocumentWidth
            _demoOptions.NewDocumentHeight = dlg.DocumentHeight

            pages = dlg.DocumentPages
            bitsPerPixel = dlg.DocumentBitsPerPixel
            width = dlg.DocumentWidth
            height = dlg.DocumentHeight
            resolution = dlg.DocumentResolution
         Else
            Return
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try

      Dim image As RasterImage = Nothing

      ' Create a RasterImage with specified pages and size
      Try
         Dim fillCmd As FillCommand = New FillCommand(RasterColor.FromKnownColor(RasterKnownColor.White))
         Dim order As RasterByteOrder
         If (bitsPerPixel = 1) Then
            order = RasterByteOrder.Rgb
         Else
            order = RasterByteOrder.Bgr
         End If

         Dim wait As WaitCursor = New WaitCursor()
         Try
            Dim page As Integer = 1
            Do While page <= pages
               Dim pageImage As RasterImage = New RasterImage(RasterMemoryFlags.Conventional, width, height, bitsPerPixel, order, RasterViewPerspective.TopLeft, Nothing, IntPtr.Zero, 0)

               ' Set the resolution
               pageImage.XResolution = resolution
               pageImage.YResolution = resolution

               ' Fill it
               fillCmd.Run(pageImage)

               If image Is Nothing Then
                  ' First page
                  image = pageImage
               Else
                  ' Add it to current page
                  image.AddPage(pageImage)
                  pageImage.Dispose()
               End If
               page += 1
            Loop
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      Catch ex As Exception
         ShowError(ex)
         Return
      End Try

      If Not image Is Nothing Then
         SetDocument(image, DemosGlobalization.GetResxString(Me.GetType(), "Resx_NewDocument"))
      End If
   End Sub

   Private Sub DoOpenDocument()
      ' Open a document from disk

      Dim image As RasterImage = Nothing
      Dim fileName As String = Nothing

      If String.IsNullOrEmpty(_demoOptions.OpenCommonDialogFolder) OrElse (Not Directory.Exists(_demoOptions.OpenCommonDialogFolder)) Then
#If LT_CLICKONCE Then
			_demoOptions.OpenCommonDialogFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
#Else
         _demoOptions.OpenCommonDialogFolder = DemosGlobal.ImagesFolder
#End If

      End If

      ' Show the LEADTOOLS common dialog
      Dim loader As ImageFileLoader = New ImageFileLoader()
      loader.LoadOnlyOnePage = False
      loader.ShowLoadPagesDialog = True
      loader.OpenDialogInitialPath = _demoOptions.OpenCommonDialogFolder

      Try
         ' Insert the pages loader into the document
         If loader.Load(Me, _rasterCodecs, True) > 0 Then
            image = loader.Image
            ' Force TopLeft:
            If image.ViewPerspective <> RasterViewPerspective.TopLeft Then
               Dim cmd As ChangeViewPerspectiveCommand = New ChangeViewPerspectiveCommand(True, RasterViewPerspective.TopLeft)
               cmd.Run(image)
            End If
            _demoOptions.OpenCommonDialogFolder = Path.GetDirectoryName(loader.FileName)
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try

      If Not image Is Nothing Then
         SetDocument(image, fileName)
      End If
   End Sub

   Private Sub DoSaveDocument()
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim saver As ImageFileSaver = New ImageFileSaver()

      Try
         saver.Save(Me, _rasterCodecs, _viewerControl.RasterImageViewer.Image)
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, saver.FileName, ex)
      End Try
   End Sub

   Public Sub SetDocument(ByVal image As RasterImage, ByVal title As String)
      Me.SuspendLayout()

      Try
         Dim wait As WaitCursor = New WaitCursor()
         Try
            ' Create empty document barcodes
            _documentBarcodes = New DocumentBarcodes()

            If Not image Is Nothing Then
               Dim page As Integer = 0
               Do While page < image.PageCount
                  Dim pageBarcodes As PageBarcodes = New PageBarcodes()
                  _documentBarcodes.Pages.Add(pageBarcodes)
                  page += 1
               Loop
            End If

            _viewerControl.ShowBarcodes = True
            _viewerControl.SetDocument(image, _documentBarcodes)
            _barcodeControl.SetDocument(image, _documentBarcodes)
            _pagesControl.SetDocument(image)

            If Not image Is Nothing Then
               _viewerControl.Visible = True
               _barcodeControl.Visible = True

               If image.PageCount > 1 Then
                  _pagesControl.Visible = True
               End If

               Text = String.Format("{0} - {1}", title, Messager.Caption)
            Else
               Text = Messager.Caption
            End If
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.ResumeLayout()
         UpdateUIState()
      End Try
   End Sub

   Private Sub GotoPage(ByVal pageNumber As Integer)
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Try
         _pagesControl.SetCurrentPageNumber(pageNumber)
         _viewerControl.SetCurrentPageNumber(pageNumber)
         _barcodeControl.Populate()
      Catch ex As Exception
         ShowError(ex)
      Finally
         UpdateUIState()
      End Try
   End Sub

   Private Sub InitBarcodeEngine()
      _barcodeEngine = New BarcodeEngine()

      _barcodeEngine.Reader.ImageType = BarcodeImageType.Unknown
      _barcodeEngine.Reader.EnableReturnFourPoints = False

      _demoOptions = DemoOptions.Load()

      ' Create the barcodes symbologies multi-frame RasterImage
      Using stream As Stream = Me.GetType().Assembly.GetManifestResourceStream("BarcodeMainDemo.Symbologies.tif")
         _rasterCodecs.Options.Load.AllPages = True
         _sampleSymbologiesRasterImage = _rasterCodecs.Load(stream)
      End Using
   End Sub


   Private Sub SaveBarcodeOptions(ByVal readOptions As Boolean)
      Dim dlg As SaveFileDialog = New SaveFileDialog()
      Try
         If readOptions Then
            dlg.Title = DemosGlobalization.GetResxString(Me.GetType(), "Resx_SaveBarcodeReadOptions")
         Else
            dlg.Title = DemosGlobalization.GetResxString(Me.GetType(), "Resx_SaveBarcodeWriteOptions")
         End If

         dlg.Filter = "XML files (*.xml)|*.xml|All files|*.*"
         dlg.DefaultExt = "xml"
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
               If readOptions Then
                  _barcodeEngine.Reader.SaveOptions(dlg.FileName)
               Else
                  _barcodeEngine.Writer.SaveOptions(dlg.FileName)
               End If
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Private Sub LoadBarcodeOptions(ByVal readOptions As Boolean)
      Dim dlg As OpenFileDialog = New OpenFileDialog()
      Try
         If readOptions Then
            dlg.Title = DemosGlobalization.GetResxString(Me.GetType(), "Resx_LoadBarcodeReadOptions")
         Else
            dlg.Title = DemosGlobalization.GetResxString(Me.GetType(), "Resx_LoadBarcodeWriteOptions")
         End If

         dlg.Filter = "XML files (*.xml)|*.xml|All files|*.*"
         dlg.DefaultExt = "xml"
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
               If readOptions Then
                  _barcodeEngine.Reader.LoadOptions(dlg.FileName)
               Else
                  _barcodeEngine.Writer.LoadOptions(dlg.FileName)
               End If
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Private Sub DoDeleteSelectedBarcode()
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(_viewerControl.RasterImageViewer.Image.Page - 1)
      If Not pageBarcodes Is Nothing AndAlso pageBarcodes.SelectedIndex <> -1 Then
         pageBarcodes.Barcodes.RemoveAt(pageBarcodes.SelectedIndex)
         If pageBarcodes.SelectedIndex >= pageBarcodes.Barcodes.Count Then
            pageBarcodes.SelectedIndex = pageBarcodes.Barcodes.Count - 1
         End If

         _viewerControl.RasterImageViewer.Invalidate()
         _barcodeControl.Populate()
      End If
   End Sub

   Private Function GetMatrixFromLeadMatrix(ByVal matrix As LeadMatrix) As Matrix
      Return New Matrix(CSng(matrix.M11), CSng(matrix.M12), CSng(matrix.M21), CSng(matrix.M22), CSng(matrix.OffsetX), CSng(matrix.OffsetY))
   End Function

   Private Sub DoViewSelectedBarcodeIDData()
#If LEADTOOLS_V20_OR_LATER Then
      Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(_viewerControl.RasterImageViewer.Image.Page - 1)
      If pageBarcodes IsNot Nothing AndAlso pageBarcodes.SelectedIndex <> -1 Then
         Dim data As BarcodeData = pageBarcodes.Barcodes(pageBarcodes.SelectedIndex)
         Dim id As AAMVAID = BarcodeData.ParseAAMVAData(data.GetData(), False)
         If id IsNot Nothing Then
            Dim aamvaDlg As New AAMVADialogBox(id)
            aamvaDlg.ShowDialog()
         End If
      End If
#End If '#If LEADTOOLS_V20_OR_LATER Then
   End Sub


   Private Sub DoZoomToSelectedBarcode()
      Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(_viewerControl.RasterImageViewer.Image.Page - 1)
      If Not pageBarcodes Is Nothing AndAlso pageBarcodes.SelectedIndex <> -1 Then
         Dim image As RasterImage = _viewerControl.RasterImageViewer.Image
         Dim bounds As LeadRect = pageBarcodes.Barcodes(pageBarcodes.SelectedIndex).Bounds

         Dim boundsF As RectangleF = New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)

         ' Convert this rectangle to physical
         Dim m As System.Drawing.Drawing2D.Matrix = GetMatrixFromLeadMatrix(_viewerControl.RasterImageViewer.GetImageTransformWithDpi(True))
         Try
            Dim trans As Transformer = New Transformer(m)
            boundsF = trans.RectangleToPhysical(boundsF)
         Finally
            CType(m, IDisposable).Dispose()
         End Try

         ' Give it a few pixels on the edges
         Dim rc As Rectangle = Rectangle.Round(boundsF)
         rc.Inflate(40, 40)

         _viewerControl.RasterImageViewer.ZoomToRect(New LeadRectD(rc.X, rc.Y, rc.Width, rc.Height))
      End If
   End Sub

   Private Sub DoExportBarcodes()
      Dim dlg As SaveFileDialog = New SaveFileDialog()
      Try
         dlg.Title = DemosGlobalization.GetResxString(Me.GetType(), "Resx_SaveBarcodeData")
         dlg.Filter = "XML files (*.xml)|*.xml|All files|*.*"
         dlg.DefaultExt = "xml"
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
               Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(_viewerControl.RasterImageViewer.Image.Page - 1)

               Dim data As BarcodeData() = New BarcodeData(pageBarcodes.Barcodes.Count - 1) {}
               Dim i As Integer = 0
               Do While i < pageBarcodes.Barcodes.Count
                  data(i) = pageBarcodes.Barcodes(i)
                  i += 1
               Loop

               BarcodeData.Save(dlg.FileName, data)
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Public Sub DoClearAllBarcodes()
      For Each pageBarcodes As PageBarcodes In _documentBarcodes.Pages
         pageBarcodes.Barcodes.Clear()
         pageBarcodes.SelectedIndex = -1
      Next pageBarcodes

      _viewerControl.RasterImageViewer.Invalidate()
      _barcodeControl.Populate()
   End Sub

   Private Sub DoReadBarcodeOptions()
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim dlg As ReadBarcodeOptionsDialogBox = New ReadBarcodeOptionsDialogBox(_barcodeEngine, _sampleSymbologiesRasterImage, _demoOptions.ReadOptionsGroupIndex, _demoOptions.ReadOptionsSymbologies, _demoOptions.ReadBarcodesWhenOptionsDialogCloses)
      Try

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _demoOptions.ReadOptionsGroupIndex = dlg.SelectedGroupIndex
            _demoOptions.ReadOptionsSymbologies = dlg.GetSelectedSymbologies()
            _demoOptions.ReadBarcodesWhenOptionsDialogCloses = dlg.ReadBarcodesWhenDialogCloses

            If _demoOptions.ReadBarcodesWhenOptionsDialogCloses Then
               DoReadBarcodes(False, LeadRect.Empty, True)
            End If
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Private Sub DoReadBarcodes(ByVal currentPageOnly As Boolean, ByVal bounds As LeadRect, ByVal clearOldBarcodes As Boolean)
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim image As RasterImage = _viewerControl.RasterImageViewer.Image

      Dim dlg As ReadBarcodesDialogBox = New ReadBarcodesDialogBox(_barcodeEngine, _demoOptions.ReadOptionsSymbologies, image, currentPageOnly, bounds)
      Try
         dlg.ShowDialog(Me)

         If dlg.ShowReadBarcodeOptions Then
            DoReadBarcodeOptions()
            Return
         End If

         ' Merge barcodes
         If clearOldBarcodes Then
            For Each pageBarcodes As PageBarcodes In _documentBarcodes.Pages
               pageBarcodes.Barcodes.Clear()
               pageBarcodes.SelectedIndex = -1
            Next pageBarcodes
         End If

         If currentPageOnly Then
            ' There should only be one page
            System.Diagnostics.Debug.Assert(dlg.DocumentBarcodes.Pages.Count = 1)

            Dim newPageBarcodes As PageBarcodes = dlg.DocumentBarcodes.Pages(0)
            Dim currentPageBarcodes As PageBarcodes = _documentBarcodes.Pages(image.Page - 1)

            For Each data As BarcodeData In newPageBarcodes.Barcodes
               currentPageBarcodes.Barcodes.Add(data)
            Next data

            currentPageBarcodes.SelectedIndex = currentPageBarcodes.Barcodes.Count - 1
         Else
            Dim pageIndex As Integer = 0
            Do While pageIndex < dlg.DocumentBarcodes.Pages.Count
               Dim newPageBarcodes As PageBarcodes = dlg.DocumentBarcodes.Pages(pageIndex)
               Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(pageIndex)

               For Each data As BarcodeData In newPageBarcodes.Barcodes
                  pageBarcodes.Barcodes.Add(data)
               Next data

               pageBarcodes.SelectedIndex = pageBarcodes.Barcodes.Count - 1
               pageIndex += 1
            Loop
         End If

         _viewerControl.RasterImageViewer.Invalidate()
         _barcodeControl.Populate()
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Private Sub DoWriteBarcode(ByVal bounds As LeadRect)
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      ' Consider having a region of interest to write inside on the image
      Dim regionOfInterest As LeadRect = bounds

      If regionOfInterest.IsEmpty AndAlso _viewerControl.RasterImageViewer.Image.HasRegion Then
         Dim regionBounds As LeadRect = _viewerControl.RasterImageViewer.Image.GetRegionBounds(Nothing)
         regionOfInterest = regionBounds
      End If

      Dim dlg As WriteBarcodeDialogBox = New WriteBarcodeDialogBox(_barcodeEngine, _sampleSymbologiesRasterImage, regionOfInterest, _demoOptions.WriteOptionsGroupIndex, _demoOptions.WriteOptionsSymbology, New WriteBarcodeDialogBox.WriteBarcodeDelegate(AddressOf WriteBarcode))
      Try
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _demoOptions.WriteOptionsGroupIndex = dlg.SelectedGroupIndex
            _demoOptions.WriteOptionsSymbology = dlg.SelectedSymbology

            _pagesControl.SetDocument(_viewerControl.RasterImageViewer.Image)
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Private Function WriteBarcode(ByVal data As BarcodeData) As Boolean
      Try
         Dim wait As WaitCursor = New WaitCursor()
         Try
            Dim image As RasterImage = _viewerControl.RasterImageViewer.Image

            ' When writing a barcode, if the image has a region, the barcode might not all be visible
            ' So same the region first if we have it and set it back after the writing is completed

            Dim region As RasterRegion = Nothing

            If image.HasRegion Then
               region = image.GetRegion(Nothing)
               image.MakeRegionEmpty()
            End If

            Try
               ' First, calculate the rectangle for this Barcode
               Dim writeBounds As LeadRect = New LeadRect(0, 0, image.Width, image.Height)

               ' if the specific user rectangle was specified for drawing the Barcode then overwrite the above rectangle
               If (Not data.Bounds.IsEmpty) AndAlso Not data.Bounds = writeBounds Then
                  writeBounds = data.Bounds
               End If

               _barcodeEngine.Writer.CalculateBarcodeDataBounds(writeBounds, image.XResolution, image.YResolution, data, Nothing)

               ' Next, write the barcode
               _barcodeEngine.Writer.WriteBarcode(image, data, Nothing)
            Finally
               If Not region Is Nothing Then
                  image.SetRegion(Nothing, region, RasterRegionCombineMode.Set)
                  region.Dispose()
               End If
            End Try


            If _viewerControl.FourPoints = True AndAlso data.Symbology <> BarcodeSymbology.Aztec AndAlso data.Symbology <> BarcodeSymbology.Maxi AndAlso data.Symbology <> BarcodeSymbology.MicroQR Then
               Dim rect As LeadRect = data.Bounds
               Dim rc As New LeadRectD(rect.X, rect.Y, rect.Width, rect.Height)

               rect.Left = (CInt(rc.Top) << 16) + CInt(rc.Left)
               rect.Top = (CInt(rc.Top) << 16) + CInt(rc.Right)
               rect.Width = (CInt(rc.Bottom) << 16) + CInt(rc.Right)
               rect.Height = (CInt(rc.Bottom) << 16) + CInt(rc.Left)

               data.Bounds = rect
            End If
            ' You can uncomment this to add the barcode to the list
            ' of data, or just do what the demo does and read it yourself
            ' Add it to the list of barcodes of current page
            Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(image.Page - 1)
            pageBarcodes.Barcodes.Add(data)

            ' And select it
            pageBarcodes.SelectedIndex = pageBarcodes.Barcodes.Count - 1
            _viewerControl.RasterImageViewer.Invalidate()

            _barcodeControl.Populate()
         Finally
            CType(wait, IDisposable).Dispose()
         End Try

         Return True
      Catch ex As BarcodeException
         Dim message As String = String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_BarcodeError"), Environment.NewLine, ex.Code, ex.Message)
         Messager.ShowError(Me, message)
         Return False
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
   End Function

   Public Shared Function IsValidNumber(ByVal OrgStr As String, ByVal minVal As Single, ByVal maxVal As Single) As String
      Dim str As String = ""

      For Each c1 As Char In OrgStr
         If Char.IsNumber(c1) Then
            str &= c1.ToString()
         End If
      Next c1
      If str <> "" Then
         If Single.Parse(str) < minVal Then
            str = minVal.ToString()
         End If

         If Single.Parse(str) > maxVal Then
            str = maxVal.ToString()
         End If
      End If

      Return str
   End Function

   Private Sub ChangingBoundingType()
      If _viewerControl.RasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim xResolution As Integer = If(_viewerControl.RasterImageViewer.Image.XResolution > 0, _viewerControl.RasterImageViewer.Image.XResolution, 96)
      Dim yResolution As Integer = If(_viewerControl.RasterImageViewer.Image.YResolution > 0, _viewerControl.RasterImageViewer.Image.YResolution, 96)
      If _viewerControl.FourPoints = True Then
         For Each pageBarcodes As PageBarcodes In _documentBarcodes.Pages
            For Each data As BarcodeData In pageBarcodes.Barcodes
               If data.Symbology = BarcodeSymbology.Aztec OrElse data.Symbology = BarcodeSymbology.Maxi OrElse data.Symbology = BarcodeSymbology.MicroQR Then
                  Continue For
               End If

               Dim rect As LeadRect = data.Bounds
               Dim rc As New LeadRectD(rect.X, rect.Y, rect.Width, rect.Height)

               rect.Left = (CInt(rc.Top) << 16) + CInt(rc.Left)
               rect.Top = (CInt(rc.Top) << 16) + CInt(rc.Right)
               rect.Width = (CInt(rc.Bottom) << 16) + CInt(rc.Right)
               rect.Height = (CInt(rc.Bottom) << 16) + CInt(rc.Left)

               data.Bounds = rect
            Next
         Next
      Else
         For Each pageBarcodes As PageBarcodes In _documentBarcodes.Pages
            For Each data As BarcodeData In pageBarcodes.Barcodes
               If data.Symbology = BarcodeSymbology.Aztec OrElse data.Symbology = BarcodeSymbology.Maxi OrElse data.Symbology = BarcodeSymbology.MicroQR Then
                  Continue For
               End If

               Dim pointsL As LeadPointD() = New LeadPointD(3) {}
               Dim rect As LeadRect = data.Bounds
               Dim rc As New LeadRectD(rect.X, rect.Y, rect.Width, rect.Height)

               pointsL(0).X = (CInt(rc.Left) And &HFFFF)
               pointsL(0).Y = (CInt(rc.Left) >> 16)
               pointsL(1).X = (CInt(rc.Top) And &HFFFF)
               pointsL(1).Y = (CInt(rc.Top) >> 16)
               pointsL(2).X = (CInt(rc.Width) And &HFFFF)
               pointsL(2).Y = (CInt(rc.Width) >> 16)
               pointsL(3).X = (CInt(rc.Height) And &HFFFF)
               pointsL(3).Y = (CInt(rc.Height) >> 16)

               rect.Left = CInt(Math.Min(Math.Min(pointsL(0).X, pointsL(1).X), Math.Min(pointsL(2).X, pointsL(3).X)))
               rect.Right = CInt(Math.Max(Math.Max(pointsL(0).X, pointsL(1).X), Math.Max(pointsL(2).X, pointsL(3).X)))
               rect.Top = CInt(Math.Min(Math.Min(pointsL(0).Y, pointsL(1).Y), Math.Min(pointsL(2).Y, pointsL(3).Y)))
               rect.Bottom = CInt(Math.Max(Math.Max(pointsL(0).Y, pointsL(1).Y), Math.Max(pointsL(2).Y, pointsL(3).Y)))

               data.Bounds = rect
            Next
         Next
      End If

   End Sub

End Class
