' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Data
Imports System.Text
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Controls
Imports Leadtools.Demos
Imports Leadtools.Twain
Imports Leadtools.Internal
Imports Leadtools.WinForms.CommonDialogs.Color
Imports Leadtools.Wia
Imports Leadtools.Drawing
Imports System.Drawing.Drawing2D
Imports Leadtools.Demos.Dialogs


Namespace MainDemo
   Partial Public Class MainForm : Inherits Form
      Private _codecs As RasterCodecs
      Private _fillColor As RasterColor
      Private _printDocument As PrintDocument
      Private _currentPrintPageNumber As Integer
      Private _twainSession As TwainSession
      Private _inTwainAcquire As Boolean

      Private _acquirePageCount As Integer
      Private _paintProperties As RasterPaintProperties
      Private _animateRegions As Boolean
      Private _panViewerForm As PanViewerForm
      Private _rawdataLoad As RawData
      Private _rawdataSave As RawData
      Private Shared ReadOnly _minimumScaleFactor As Single = 0.05F
      Private Shared ReadOnly _maximumScaleFactor As Single = 11.0F
      Private _saver As ImageFileSaver
      Private _useDpi As Boolean = False
      Private _wiaSession As WiaSession
      Private _wiaAcquiring As Boolean
      Public _wiaAcquireOptions As WiaAcquireOptions = WiaAcquireOptions.Empty
      Public _progressDlg As ProgressForm
      Public _addMagicWand As Boolean = False
      Public _threshold As Integer = 25
      Private _openInitialPath As String = ""
      Private bMRZRunMessage As Boolean = True
      Private bMICRRunMessage As Boolean = True

      Private _interactiveToolsList As Dictionary(Of ImageViewer, Form)
      Public ReadOnly Property InteractiveToolsList() As Dictionary(Of ImageViewer, Form)
         Get
            Return _interactiveToolsList
         End Get
      End Property
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

      Public Sub New()
         InitializeComponent()

         InitClass()

         _saver = New ImageFileSaver()

#If LT_CLICKONCE Then
      LoadDefaultImage("image2.cmp", 1, -1)
#End If ' #if LT_CLICKONCE
      End Sub

      Dim _ignoreVectorList As String = "dxf,dwg,dwf,cgm,cmx,plt,vec,drw,dgn,gbr,shp,pcl,prn,prt,vpg,mif,e00,wmz,nap,stl,3js"

      Private Sub EnableLoadVectorFiles(codecs As RasterCodecs, enable As Boolean)
         Dim ignoreList As String() = _ignoreVectorList.Split(","c)
         For Each flt As String In ignoreList
            Try
               Dim info As CodecsCodecInformation = codecs.GetCodecInformation(flt)
               info.CheckedByInformation = enable
               codecs.SetCodecInformation(info)
            Catch
            End Try
         Next flt
      End Sub

      Private Sub EnableTextFiles(codecs As RasterCodecs, enable As Boolean)
         _codecs.Options.Txt.Load.Enabled = enable
         Dim info As CodecsCodecInformation = codecs.GetCodecInformation("TXT")
         info.CheckedByInformation = enable
         codecs.SetCodecInformation(info)
      End Sub

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS for .NET VB Main Demo"
         Text = Messager.Caption

         _codecs = New RasterCodecs()
         EnableLoadVectorFiles(_codecs, False)
         EnableTextFiles(_codecs, False)

         _fillColor = Converters.FromGdiPlusColor(Color.White)
         _paintProperties = RasterPaintProperties.Default
         _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
         _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.Bicubic
         _animateRegions = False
         _rawdataLoad = RawData.Default
         _rawdataSave = RawData.Default

         _menuItemPreferencesProgressBar.Checked = True
         _interactiveToolsList = New Dictionary(Of ImageViewer, Form)()
         _wiaAcquiring = False


         Try

            If Not PrinterSettings.InstalledPrinters Is Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
               _printDocument = New PrintDocument()
               AddHandler _printDocument.BeginPrint, AddressOf _printDocument_BeginPrint
               AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
               AddHandler _printDocument.EndPrint, AddressOf _printDocument_EndPrint
            Else
               _printDocument = Nothing
            End If
         Catch e1 As Exception
            _printDocument = Nothing
         End Try
         Try
            Dim wait As WaitCursor = New WaitCursor()
            Try
               If TwainSession.IsAvailable(Me.Handle) Then
                  _twainSession = New TwainSession()
                  _twainSession.Startup(Me.Handle, "LEADTOOLS", "LEADTOOLS for .NET", String.Empty, Messager.Caption, TwainStartupFlags.None)
                  AddHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
               End If
            Finally
               CType(wait, IDisposable).Dispose()
            End Try
         Catch ex As TwainException
            If (ex.Code = TwainExceptionCode.InvalidDll) Then
               _twainSession = Nothing
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               _twainSession = Nothing
               Messager.ShowError(Me, ex)
            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _twainSession = Nothing
         End Try

         _panViewerForm = New PanViewerForm()
         _panViewerForm.Owner = Me
         UpdateControls()
      End Sub

      Private Sub CleanUp()

         If Not _twainSession Is Nothing Then
            Try
               _twainSession.Shutdown()
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If
      End Sub

      Public ReadOnly Property ActiveViewerForm() As ViewerForm
         Get
            Return CType(IIf(TypeOf ActiveMdiChild Is ViewerForm, ActiveMdiChild, Nothing), ViewerForm)
         End Get
      End Property

      Public Sub UpdateControls()
         Dim activeForm As ViewerForm = ActiveViewerForm

         EnableAndVisibleMenu(_menuItemFileSave, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemFileSaveRaw, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemFilePrint, Not _printDocument Is Nothing AndAlso Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemFilePrintPreview, Not _printDocument Is Nothing AndAlso Not activeForm Is Nothing AndAlso DialogUtilities.CanRunPrintPreview())
         _menuItemFileSep5.Visible = (Not _printDocument Is Nothing AndAlso Not activeForm Is Nothing)
         _menuItemFileSep2.Visible = Not _twainSession Is Nothing
         EnableAndVisibleMenu(_menuItemFileTwainSelectSource, Not _twainSession Is Nothing)
         EnableAndVisibleMenu(_menuItemFileTwainAcquire, Not _twainSession Is Nothing)
         _menuItemFileSep3.Visible = (Not _twainSession Is Nothing)
         _menuItemFileWiaAcquire.Enabled = Not _wiaAcquiring
         EnableAndVisibleMenu(_menuItemEditCut, Not activeForm Is Nothing AndAlso Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0))
         EnableAndVisibleMenu(_menuItemEditCopy, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemEditCombine, Not activeForm Is Nothing AndAlso Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0))
         _menuItemEditSep1.Visible = _menuItemEditCombine.Visible
         EnableAndVisibleMenu(_menuItemEditRegion, Not activeForm Is Nothing)
         _menuItemEditSep2.Visible = _menuItemEditRegion.Visible
         EnableAndVisibleMenu(_menuItemEditCancelRegion, Not activeForm Is Nothing AndAlso Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0))

         EnableAndVisibleMenu(_menuItemImage, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemPage, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemView, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemColor, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemSegmentation, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemDetection, Not activeForm Is Nothing)


         EnableAndVisibleMenu(_menuItemEffects, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_menuItemWindow, Not activeForm Is Nothing AndAlso MdiChildren.Length > 0)
         _menuItemColorWindowLevel.Enabled = (Not activeForm Is Nothing) AndAlso _
                                                                 ((activeForm.Image.GrayscaleMode <> RasterGrayscaleMode.None) AndAlso _
                                                                  (activeForm.Image.BitsPerPixel = 12 Or activeForm.Image.BitsPerPixel = 16))
         If (Not activeForm Is Nothing) Then

            EnableAndVisibleMenu(_menuItemPageFirst, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPagePrevious, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPageNext, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPageLast, activeForm.Image.PageCount > 1)
            _menuItemPageSep1.Visible = activeForm.Image.PageCount > 1
            EnableAndVisibleMenu(_menuItemPageDeleteCurrentPage, activeForm.Image.PageCount > 1)

            If (activeForm.Image.PageCount > 1) Then
               _menuItemPageFirst.Enabled = activeForm.Image.Page > 1
               _menuItemPagePrevious.Enabled = activeForm.Image.Page > 1
               _menuItemPageNext.Enabled = activeForm.Image.Page <> activeForm.Image.PageCount
               _menuItemPageLast.Enabled = activeForm.Image.Page <> activeForm.Image.PageCount
            End If

            _menuItemViewSizeModeNormal.Checked = activeForm.Viewer.SizeMode = ControlSizeMode.ActualSize
            _menuItemViewSizeModeStretch.Checked = activeForm.Viewer.SizeMode = ControlSizeMode.Stretch
            _menuItemViewSizeModeFitAlways.Checked = activeForm.Viewer.SizeMode = ControlSizeMode.FitAlways
            _menuItemViewSizeModeFitWidth.Checked = activeForm.Viewer.SizeMode = ControlSizeMode.FitWidth
            _menuItemViewSizeModeFit.Checked = activeForm.Viewer.SizeMode = ControlSizeMode.Fit

            _menuItemViewAlignModeHorizontalNear.Checked = activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Near
            _menuItemViewAlignModeHorizontalCenter.Checked = activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Center
            _menuItemViewAlignModeHorizontalFar.Checked = activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Far

            _menuItemViewAlignModeVerticalNear.Checked = activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Near
            _menuItemViewAlignModeVerticalCenter.Checked = activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Center
            _menuItemViewAlignModeVerticalFar.Checked = activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Far

            _menuItemViewPalette.Enabled = activeForm.Image.BitsPerPixel <= 8
            _menuItemViewPaddingFrame.Checked = activeForm.Viewer.ViewBorderThickness <> 0
            _menuItemViewPaddingFrameShadow.Checked = activeForm.Viewer.ViewDropShadow.IsVisible
            _menuItemViewPaddingBorder.Checked = activeForm.Viewer.ViewMargin.All <> 0

            _menuItemViewInteractiveNone.Checked = TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerNoneInteractiveMode Or TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerFloaterInteractiveMode

            If activeForm.PanInteractiveMode.IsEnabled Then
               _menuItemViewInteractivePan.Checked = TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerPanZoomInteractiveMode
            Else
               _menuItemViewInteractivePan.Checked = False
            End If

            _menuItemViewInteractiveCenterAt.Checked = TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerCenterAtInteractiveMode
            _menuItemViewInteractiveZoomTo.Checked = TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerZoomToInteractiveMode

            If activeForm.ScaleInteractiveMode.IsEnabled Then
               _menuItemViewInteractiveScale.Checked = TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerPanZoomInteractiveMode
            Else
               _menuItemViewInteractiveScale.Checked = False
            End If

            _menuItemViewInteractivePage.Checked = TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerPagerInteractiveMode
            _menuItemViewInteractiveMagnifyGlass.Checked = TypeOf (activeForm.Viewer.DefaultInteractiveMode) Is ImageViewerMagnifyGlassInteractiveMode



            _menuItemEditRegionMagicWand.Checked = False

            If (_addMagicWand) Then
               _menuItemEditRegionMagicWand.Checked = _addMagicWand
               _menuItemEditRegionRectangle.Checked = False
               _menuItemEditRegionEllipse.Checked = False
               _menuItemEditRegionFreehand.Checked = False
            Else
               _menuItemEditRegionRectangle.Checked = activeForm.RegionInteractiveMode.IsEnabled AndAlso activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
               _menuItemEditRegionEllipse.Checked = activeForm.RegionInteractiveMode.IsEnabled AndAlso activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Ellipse
               _menuItemEditRegionFreehand.Checked = activeForm.RegionInteractiveMode.IsEnabled AndAlso activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Freehand
               _menuItemEditRegionMagicWand.Checked = False
            End If

            _menuItemEditRegionNone.Enabled = activeForm.Viewer.Image.HasRegion Or (Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0))

            _menuItemViewInteractivePanWindow.Checked = _panViewerForm.Visible

            _menuItemColorAdjustBalanceColors.Enabled = (activeForm.Viewer.Image.GrayscaleMode = RasterGrayscaleMode.None)

            _menuItemViewPaint.Enabled = (_paintProperties.PaintEngine = RasterPaintEngine.Gdi)

            EnableAndVisibleMenu(_menuItemEffectsTextureUnderlay, (Not activeForm Is Nothing) AndAlso ((activeForm.Image.BitsPerPixel = 8 Or activeForm.Image.GrayscaleMode = RasterGrayscaleMode.None)))
            EnableAndVisibleMenu(_menuItemEffectsTexture, (Not activeForm Is Nothing) AndAlso ((activeForm.Image.BitsPerPixel = 8 Or activeForm.Image.GrayscaleMode = RasterGrayscaleMode.None)))
            EnableAndVisibleMenu(_menuItemColorAutoBinarize, (Not activeForm Is Nothing) AndAlso ((activeForm.Image.BitsPerPixel = 8 Or activeForm.Image.GrayscaleMode = RasterGrayscaleMode.None)))

            _menuItemColorMatchHistogram.Enabled = ((activeForm.Viewer.Image.BitsPerPixel = 8) OrElse (activeForm.Viewer.Image.BitsPerPixel = 24))

            _menuItemImageBlankPageDetection.Enabled = activeForm.Viewer.Image.BitsPerPixel <> 12 And activeForm.Viewer.Image.BitsPerPixel <> 16 And activeForm.Viewer.Image.BitsPerPixel <> 48 And activeForm.Viewer.Image.BitsPerPixel <> 64
         End If
      End Sub

      Private Sub EnableAndVisibleMenu(ByVal menu As ToolStripMenuItem, ByVal value As Boolean)
         menu.Enabled = value
         menu.Visible = value
      End Sub

      Private Sub _menuItemFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileOpen.Click
         Try
            Dim imagesInfo As List(Of ImageInformation) = LoadImage(True)
            If Not imagesInfo Is Nothing Then
               For Each info As ImageInformation In imagesInfo
                  If Not info Is Nothing Then
                     NewImage(info)
                  End If
               Next
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileSave.Click
         Try
            CombineFloater()
            DemosGlobal.SetDefaultComments(ActiveViewerForm.Viewer.Image, _codecs)
            _saver.Save(Me, _codecs, ActiveViewerForm.Viewer.Image)
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, _saver.FileName, ex)
         End Try
      End Sub
      Private Sub _menuItemFileTwainSelectSource_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileTwainSelectSource.Click
         _inTwainAcquire = True
         Try
            If Not _twainSession Is Nothing Then
               _twainSession.SelectSource(String.Empty)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
         _inTwainAcquire = False
      End Sub

      Private Sub _menuItemFileTwainAcquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileTwainAcquire.Click
         _inTwainAcquire = True
         _acquirePageCount = 1

         Try
            If Not _twainSession Is Nothing Then
               If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
                  Return
               End If
               Dim res As DialogResult = _twainSession.Acquire(TwainUserInterfaceFlags.Modal Or TwainUserInterfaceFlags.Show)
            End If
         Catch ex As Exception
            If (TypeOf (ex) Is TwainException) Then
               Dim twnEx As TwainException = CType(ex, TwainException)
               If twnEx.Code <> TwainExceptionCode.OperationError Then
                  Messager.ShowError(Me, ex)
               End If
            Else
               Messager.ShowError(Me, ex)
            End If
         Finally
            _acquirePageCount = -1
            _inTwainAcquire = False
         End Try
      End Sub

      Private Sub _twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
         Application.DoEvents()

         If Not e.Image Is Nothing Then
            If _acquirePageCount = 1 Then
               NewImage(New ImageInformation(e.Image, "Twain Image"))
            Else
               ActiveViewerForm.Image.AddPage(e.Image)
            End If

            _acquirePageCount += 1
         End If
      End Sub

      Private Sub _menuItemFilePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFilePrint.Click
         If Not _printDocument Is Nothing Then
            Try
               Dim image As RasterImage = ActiveViewerForm.Viewer.Image
               _printDocument.PrinterSettings.MinimumPage = 1
               _printDocument.PrinterSettings.MaximumPage = image.PageCount
               _printDocument.PrinterSettings.FromPage = 1
               _printDocument.PrinterSettings.ToPage = image.PageCount

               _printDocument.Print()
            Catch
            End Try
         End If
      End Sub

      Private Sub _menuItemFilePrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFilePrintPreview.Click
         If Not _printDocument Is Nothing Then
            Try
               Using dlg As New PrintPreviewDialog()

                  Dim image As RasterImage = ActiveViewerForm.Viewer.Image
                  _printDocument.PrinterSettings.MinimumPage = 1
                  _printDocument.PrinterSettings.MaximumPage = image.PageCount
                  _printDocument.PrinterSettings.FromPage = 1
                  _printDocument.PrinterSettings.ToPage = image.PageCount

                  dlg.Document = _printDocument
                  dlg.WindowState = FormWindowState.Maximized
                  dlg.ShowDialog(Me)
               End Using
            Catch
            End Try
         End If
      End Sub

      Private Sub _menuItemFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileExit.Click
         Close()
      End Sub

      Private Sub MainForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
         Dim activeForm As ViewerForm = ActiveViewerForm

         If Not activeForm Is Nothing Then
            _panViewerForm.SetViewer(activeForm.Viewer)
         Else
            _panViewerForm.SetViewer(Nothing)
         End If

         UpdateControls()
      End Sub

      Private Sub _menuItemEdit_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemEdit.DropDownOpened
         _menuItemEditPaste.Enabled = RasterClipboard.IsReady
      End Sub

      Private Sub _menuItemEditCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEditCut.Click
         Try
            Dim wait As WaitCursor = New WaitCursor()
            Try
               RasterClipboard.Copy(Me.Handle, ImageToRun, RasterClipboardCopyFlags.Empty Or RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Palette Or RasterClipboardCopyFlags.Region)

               Dim activeForm As ViewerForm = ActiveViewerForm

               If Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0) Then
                  activeForm.Viewer.Floater = Nothing
               End If
               activeForm.Viewer.Invalidate(True)
            Finally
               CType(wait, IDisposable).Dispose()
            End Try
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemEditCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEditCopy.Click
         Try
            Dim wait As WaitCursor = New WaitCursor()
            Try
               RasterClipboard.Copy(Me.Handle, ImageToRun, RasterClipboardCopyFlags.Empty Or RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Palette Or RasterClipboardCopyFlags.Region)
            Finally
               CType(wait, IDisposable).Dispose()
            End Try
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemEditPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEditPaste.Click
         Try
            Dim wait As WaitCursor = New WaitCursor()
            Try
               Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)
               If Not image Is Nothing Then
                  Dim activeForm As ViewerForm = ActiveViewerForm

                  If image.HasRegion AndAlso activeForm Is Nothing Then
                     image.MakeRegionEmpty()
                  End If

                  If image.HasRegion Then
                     CombineFloater()
                     ' make sure the images have the same BitsPerPixel and Palette
                     If activeForm.Viewer.Image.BitsPerPixel > 8 Then
                        If image.BitsPerPixel <> activeForm.Viewer.Image.BitsPerPixel Then
                           Try
                              Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand()
                              colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                              colorRes.Order = activeForm.Viewer.Image.Order
                              colorRes.Mode = Leadtools.ImageProcessing.ColorResolutionCommandMode.InPlace
                              colorRes.Run(image)
                           Catch ex As Exception
                              Messager.ShowError(Me, ex)
                           End Try
                        End If
                     Else
                        Try
                           Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand()
                           colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                           colorRes.SetPalette(activeForm.Viewer.Image.GetPalette())
                           colorRes.PaletteFlags = Leadtools.ImageProcessing.ColorResolutionCommandPaletteFlags.UsePalette
                           colorRes.Mode = Leadtools.ImageProcessing.ColorResolutionCommandMode.InPlace
                           colorRes.Run(image)
                        Catch ex As Exception
                           Messager.ShowError(Me, ex)
                        End Try
                     End If
                     activeForm.Viewer.Floater = image
                     activeForm.Viewer.FloaterOpacity = 1.0

                     Dim MyMatrix As LeadMatrix = activeForm.Viewer.ImageTransform
                     Dim m As Matrix = New Matrix(CSng(MyMatrix.M11), CSng(MyMatrix.M12), CSng(MyMatrix.M21), CSng(MyMatrix.M22), CSng(MyMatrix.OffsetX), CSng(MyMatrix.OffsetY))
                     Dim t As Transformer = New Transformer(m)

                     Dim FloaterPosition As Point = New Point(CInt(activeForm.Viewer.FloaterTransform.OffsetX), CInt(activeForm.Viewer.FloaterTransform.OffsetY))

                     Dim floatertransform As LeadMatrix = activeForm.Viewer.FloaterTransform
                     floatertransform.OffsetX = Point.Round(t.PointToLogical(Point.Empty)).X
                     floatertransform.OffsetY = Point.Round(t.PointToLogical(Point.Empty)).Y
                     activeForm.Viewer.FloaterTransform = floatertransform
                     DisableAllInteractiveModes(activeForm.Viewer)
                     activeForm.Viewer.InteractiveModes.BeginUpdate()
                     activeForm.FloaterInteractiveMode.IsEnabled = True
                     activeForm.Viewer.InteractiveModes.EndUpdate()
                  Else
                     NewImage(New ImageInformation(image))
                  End If
               End If
            Finally
               CType(wait, IDisposable).Dispose()
            End Try
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Public Sub DisableAllInteractiveModes(CurrentViewer As ImageViewer)
         CurrentViewer.InteractiveModes.BeginUpdate()
         For Each mode As ImageViewerInteractiveMode In CurrentViewer.InteractiveModes
            mode.IsEnabled = False
         Next
         CurrentViewer.InteractiveModes.EndUpdate()
      End Sub


      Private Sub CancelFloater()
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            If Not activeForm.Viewer.Floater Is Nothing Then
               activeForm.Viewer.Floater.Dispose()
               activeForm.Viewer.Floater = Nothing
               activeForm.Viewer.Invalidate(True)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemEditCancelRegion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemEditCancelRegion.Click
         CancelFloater()

         UpdateControls()
      End Sub
      Private Sub _menuItemEditCombine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEditCombine.Click
         Try
            CombineFloater()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemImageInformation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemImageInformation.Click
         Dim dlg As ImageInformationDialog = New ImageInformationDialog()
         dlg.Image = ActiveViewerForm.Image
         dlg.ShowDialog(Me)
      End Sub

      Private Sub _menuItemImageUnderlay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEffectsTextureUnderlay.Click
         Try
            Dim imagesInfo As List(Of ImageInformation) = LoadImage(False)
            If imagesInfo IsNot Nothing And imagesInfo.Count > 0 And imagesInfo(0) IsNot Nothing Then
               Dim dlg As UnderlayDialog = New UnderlayDialog()
               If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
                  Dim wait As WaitCursor = New WaitCursor()
                  Try
                     Dim activeForm As ViewerForm = ActiveViewerForm

                     If (activeForm.Viewer.FloaterOpacity > 0.0) AndAlso (Not activeForm.Viewer.Floater Is Nothing) Then
                        activeForm.Viewer.Floater.Underlay(imagesInfo(0).Image, dlg.Flags)
                     Else
                        activeForm.Viewer.Image.Underlay(imagesInfo(0).Image, dlg.Flags)
                     End If
                  Finally
                     CType(wait, IDisposable).Dispose()
                  End Try
               End If
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemViewInteractive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewInteractiveZoomTo.Click, _menuItemViewInteractiveScale.Click, _menuItemViewInteractivePan.Click, _menuItemViewInteractivePage.Click, _menuItemViewInteractiveNone.Click, _menuItemViewInteractiveMagnifyGlass.Click, _menuItemViewInteractiveCenterAt.Click
         Dim activeForm As ViewerForm = ActiveViewerForm

         activeForm.Viewer.InteractiveModes.BeginUpdate()
         DisableAllInteractiveModes(activeForm.Viewer)
         If (sender Is _menuItemViewInteractiveNone) Then
            If (Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0)) Then
               activeForm.FloaterInteractiveMode.IsEnabled = True
            Else
               activeForm.NoneInteractiveMode.IsEnabled = True
            End If
         ElseIf (sender Is _menuItemViewInteractivePan) Then
            activeForm.PanInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemViewInteractiveCenterAt) Then
            activeForm.CenterAtInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemViewInteractiveZoomTo) Then
            activeForm.ZoomToInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemViewInteractiveScale) Then
            activeForm.ScaleInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemViewInteractivePage) Then
            CancelFloater()
            activeForm.PagerInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemViewInteractiveMagnifyGlass) Then
            CancelFloater()
            DisableAllInteractiveModes(activeForm.Viewer)
            activeForm.MagnifyGlassInteractiveMode.IsEnabled = True
         End If

         activeForm.Viewer.InteractiveModes.EndUpdate()

         UpdateControls()
      End Sub

      Private Sub _menuItemViewInteractivePanWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemViewInteractivePanWindow.Click
         _panViewerForm.Visible = Not _panViewerForm.Visible
         UpdateControls()
      End Sub

      Private Sub _menuItemPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemPagePrevious.Click, _menuItemPageNext.Click, _menuItemPageLast.Click, _menuItemPageFirst.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            If activeForm.Viewer.Image.HasRegion Then
               activeForm.Viewer.Image.MakeRegionEmpty()
            End If
            If Not activeForm.Viewer.Floater Is Nothing Then
               activeForm.Viewer.Floater.Dispose()
               activeForm.Viewer.Floater = Nothing
            End If

            If sender Is _menuItemPageFirst Then
               activeForm.Image.Page = 1
            ElseIf sender Is _menuItemPagePrevious Then
               activeForm.Image.Page -= 1
            ElseIf sender Is _menuItemPageNext Then
               activeForm.Image.Page += 1
            ElseIf sender Is _menuItemPageLast Then
               activeForm.Image.Page = activeForm.Image.PageCount
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemPageAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemPageAdd.Click
         Try
            Dim imagesInfo As List(Of ImageInformation) = LoadImage(False)

            If Not IsNothing(imagesInfo) Then
               If Not imagesInfo(0) Is Nothing Then
                  ActiveViewerForm.Image.AddPages(imagesInfo(0).Image, 1, imagesInfo(0).Image.PageCount)
               End If
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemPageDeleteCurrentPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemPageDeleteCurrentPage.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            activeForm.Image.RemovePageAt(activeForm.Image.Page)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub


      Private Sub _menuItemViewSizeMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewSizeModeStretch.Click, _menuItemViewSizeModeSnap.Click, _menuItemViewSizeModeNormal.Click, _menuItemViewSizeModeFitWidth.Click, _menuItemViewSizeModeFitAlways.Click, _menuItemViewSizeModeFit.Click
         Dim activeForm As ViewerForm = ActiveViewerForm

         If sender Is _menuItemViewSizeModeNormal Then
            activeForm.Viewer.Zoom(ControlSizeMode.ActualSize, 1, activeForm.Viewer.DefaultZoomOrigin)
         ElseIf sender Is _menuItemViewSizeModeSnap Then
            activeForm.Snap()
            If activeForm.WindowState <> FormWindowState.Normal Then
               activeForm.WindowState = FormWindowState.Normal
            End If
         Else
            activeForm.Viewer.BeginUpdate()
            If sender Is _menuItemViewSizeModeStretch Then
               activeForm.Viewer.Zoom(ControlSizeMode.Stretch, 1, activeForm.Viewer.DefaultZoomOrigin)
            ElseIf sender Is _menuItemViewSizeModeFitAlways Then
               activeForm.Viewer.Zoom(ControlSizeMode.FitAlways, 1, activeForm.Viewer.DefaultZoomOrigin)
            ElseIf sender Is _menuItemViewSizeModeFitWidth Then
               activeForm.Viewer.Zoom(ControlSizeMode.FitWidth, 1, activeForm.Viewer.DefaultZoomOrigin)
            ElseIf sender Is _menuItemViewSizeModeFit Then
               activeForm.Viewer.Zoom(ControlSizeMode.Fit, 1, activeForm.Viewer.DefaultZoomOrigin)
            End If
            activeForm.Viewer.EndUpdate()
         End If

         UpdateControls()

         'Set the DoubleTapSizeMode property for all ImageViewerPanZoomInteractiveModes to use the current size mode of the image viewer control
         activeForm.Viewer.InteractiveModes.BeginUpdate()
         For Each mode As ImageViewerInteractiveMode In activeForm.Viewer.InteractiveModes
            If (TypeOf (mode) Is ImageViewerPanZoomInteractiveMode) Then
               TryCast(mode, ImageViewerPanZoomInteractiveMode).DoubleTapSizeMode = activeForm.Viewer.SizeMode
            End If
         Next
         activeForm.Viewer.InteractiveModes.EndUpdate()
      End Sub

      Private Sub _menuItemViewAlignMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewAlignModeVertical.Click, _menuItemViewAlignModeHorizontal.Click
         Dim activeForm As ViewerForm = ActiveViewerForm

         If (sender Is _menuItemViewAlignModeHorizontalNear) Then
            activeForm.Viewer.ImageHorizontalAlignment = ControlAlignment.Near
         ElseIf (sender Is _menuItemViewAlignModeHorizontalCenter) Then
            activeForm.Viewer.ImageHorizontalAlignment = ControlAlignment.Center
         ElseIf (sender Is _menuItemViewAlignModeHorizontalFar) Then
            activeForm.Viewer.ImageHorizontalAlignment = ControlAlignment.Far
         ElseIf (sender Is _menuItemViewAlignModeVerticalNear) Then
            activeForm.Viewer.ImageVerticalAlignment = ControlAlignment.Near
         ElseIf (sender Is _menuItemViewAlignModeVerticalCenter) Then
            activeForm.Viewer.ImageVerticalAlignment = ControlAlignment.Center
         ElseIf (sender Is _menuItemViewAlignModeVerticalFar) Then
            activeForm.Viewer.ImageVerticalAlignment = ControlAlignment.Far
         End If
         UpdateControls()
      End Sub

      Public Sub Zoom(ByVal zoomIn As Boolean)
         If zoomIn Then
            _menuItemViewZoomIn.PerformClick()
         Else
            _menuItemViewZoomOut.PerformClick()
         End If
      End Sub

      Private Sub _menuItemViewZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewZoomValue.Click, _menuItemViewZoomOut.Click, _menuItemViewZoomNormal.Click, _menuItemViewZoomIn.Click
         ' get the current center in logical units
         Dim viewer As ImageViewer = ActiveViewerForm.Viewer ' get the active viewer
         Dim LeadPhysicalRect As LeadRect = viewer.ViewBounds
         Dim LeadLogicalRect As LeadRect = viewer.ImageBounds
         Dim PhysicalRect As Rectangle = New Rectangle(LeadPhysicalRect.X, LeadPhysicalRect.Y, LeadPhysicalRect.Width, LeadPhysicalRect.Height)
         Dim LogicalRect As Rectangle = New Rectangle(LeadLogicalRect.X, LeadLogicalRect.Y, LeadLogicalRect.Width, LeadLogicalRect.Height)
         Dim rc As System.Drawing.Rectangle = Rectangle.Intersect(PhysicalRect, LogicalRect) ' get what you see in physical coordinates
         Dim center As PointF = New PointF(rc.Left + CInt(rc.Width / 2), rc.Top + CInt(rc.Height / 2)) ' get the center of what you see in physical coordinates

         Dim MyMatrix As LeadMatrix = viewer.ImageTransform
         Dim m As Matrix = New Matrix(CSng(MyMatrix.M11), CSng(MyMatrix.M12), CSng(MyMatrix.M21), CSng(MyMatrix.M22), CSng(MyMatrix.OffsetX), CSng(MyMatrix.OffsetY))
         Dim t As Transformer = New Transformer(m)
         center = t.PointToLogical(center)  ' get the center of what you see in logical coordinates

         ' zoom     
         Dim scaleFactor As Double = viewer.ScaleFactor

         Const ratio As Single = 1.2F

         If sender Is _menuItemViewZoomIn Then
            scaleFactor *= ratio
         ElseIf sender Is _menuItemViewZoomOut Then
            scaleFactor /= ratio
         ElseIf sender Is _menuItemViewZoomNormal Then
            scaleFactor = 1
            If viewer.SizeMode <> ControlSizeMode.ActualSize Then
               viewer.Zoom(ControlSizeMode.ActualSize, 1, viewer.DefaultZoomOrigin)
            End If
         Else
            Dim dlg As ZoomDialog = New ZoomDialog()
            dlg.Value = CInt(scaleFactor * 100)
            dlg.MinimumValue = CInt(_minimumScaleFactor * 100.0F)
            dlg.MaximumValue = CInt(_maximumScaleFactor * 100.0F)

            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               scaleFactor = CSng(dlg.Value) / 100.0F
            End If
         End If

         scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor))

         If viewer.ScaleFactor <> scaleFactor Then
            viewer.Zoom(ControlSizeMode.None, scaleFactor, viewer.DefaultZoomOrigin)

            ' bring the original center into the view center
            MyMatrix = viewer.ImageTransform
            m = New Matrix(CSng(MyMatrix.M11), CSng(MyMatrix.M12), CSng(MyMatrix.M21), CSng(MyMatrix.M22), CSng(MyMatrix.OffsetX), CSng(MyMatrix.OffsetY))
            t = New Transformer(m)
            center = t.PointToPhysical(center) ' get the center of what you saw before the zoom in physical coordinates
            Dim LeadCenter As LeadPoint = New LeadPoint(CInt(center.X), CInt(center.Y))
            viewer.CenterAtPoint(LeadCenter) ' bring the old center into the center of the view
         End If
      End Sub

      Private Sub _menuItemViewPadding_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewPaddingFrameShadow.Click, _menuItemViewPaddingFrame.Click, _menuItemViewPaddingBorder.Click
         Dim activeForm As ViewerForm = ActiveViewerForm

         If (sender Is _menuItemViewPaddingFrame) Then
            If (activeForm.Viewer.ViewBorderThickness = 0) Then
               activeForm.Viewer.ViewBorderThickness = 1
            Else
               activeForm.Viewer.ViewBorderThickness = 0
            End If
         ElseIf (sender Is _menuItemViewPaddingFrameShadow) Then
            Dim dropShadow As ControlDropShadowOptions = activeForm.Viewer.ViewDropShadow
            dropShadow.IsVisible = Not dropShadow.IsVisible
            activeForm.Viewer.ViewDropShadow = dropShadow
         ElseIf (sender Is _menuItemViewPaddingBorder) Then
            Dim currentpadding As Padding
            currentpadding = activeForm.Viewer.ViewMargin
            If (currentpadding.All = 0) Then
               currentpadding.All = 10
            Else
               currentpadding.All = 0
            End If
            activeForm.Viewer.ViewMargin = currentpadding
         End If

         UpdateControls()
      End Sub

      Private Sub _menuItemViewPalette_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewPalette.Click
         Dim dlg As PaletteDialog = New PaletteDialog()
         dlg.Palette = ActiveViewerForm.Image.GetPalette()
         dlg.ShowDialog(Me)
      End Sub

      Private Sub _menuItemViewPaint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewPaintIntensity.Click, _menuItemViewPaintGamma.Click, _menuItemViewPaintContrast.Click
         Dim dlg As ValueDialog = Nothing

         Dim activeForm As ViewerForm = ActiveViewerForm

         If sender Is _menuItemViewPaintIntensity Then
            dlg = New ValueDialog(ValueDialog.TypeConstants.PaintIntensity)
            dlg.Value = activeForm.Viewer.Image.PaintIntensity
         ElseIf sender Is _menuItemViewPaintContrast Then
            dlg = New ValueDialog(ValueDialog.TypeConstants.PaintContrast)
            dlg.Value = activeForm.Viewer.Image.PaintContrast
         ElseIf sender Is _menuItemViewPaintGamma Then
            dlg = New ValueDialog(ValueDialog.TypeConstants.PaintGamma)
            dlg.Value = activeForm.Viewer.Image.PaintGamma
         End If

         If Not dlg Is Nothing AndAlso dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
            If sender Is _menuItemViewPaintIntensity Then
               activeForm.Viewer.Image.PaintIntensity = dlg.Value
            ElseIf sender Is _menuItemViewPaintContrast Then
               activeForm.Viewer.Image.PaintContrast = dlg.Value
            ElseIf sender Is _menuItemViewPaintGamma Then
               activeForm.Viewer.Image.PaintGamma = dlg.Value
            End If

            SetFloaterPaintValues()
         End If
      End Sub

      Public Sub SetFloaterPaintValues()
         Dim activeForm As ViewerForm = ActiveViewerForm
         If Not activeForm Is Nothing Then
            If Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0) Then
               activeForm.Viewer.Floater.PaintIntensity = activeForm.Viewer.Image.PaintIntensity
               activeForm.Viewer.Floater.PaintContrast = activeForm.Viewer.Image.PaintContrast
               activeForm.Viewer.Floater.PaintGamma = activeForm.Viewer.Image.PaintGamma
            End If
         End If
      End Sub

      Private Sub _menuItemPreferencesPaintProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemPreferencesPaintProperties.Click
         Dim dlg As New PaintPropertiesDialog
         dlg.PaintProperties = _paintProperties
         AddHandler dlg.Apply, AddressOf PaintPropertiesDialog_Apply
         dlg.ShowDialog(Me)
         UpdateControls()
      End Sub

      Private Sub PaintPropertiesDialog_Apply(ByVal sender As Object, ByVal e As EventArgs)
         Dim dlg As PaintPropertiesDialog = CType(sender, PaintPropertiesDialog)
         _paintProperties = dlg.PaintProperties
         Dim i As ViewerForm
         For Each i In MdiChildren
            i.UpdatePaintProperties(_paintProperties)
         Next
         UpdateControls()
      End Sub

      Private Sub _menuItemImageFastRotate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemImageRotateFast90.Click, _menuItemImageRotateFast270.Click, _menuItemImageRotateFast180.Click
         Dim degrees As Integer
         If sender Is _menuItemImageRotateFast180 Then
            degrees = 180
         ElseIf sender Is _menuItemImageRotateFast270 Then
            degrees = 270
         Else
            degrees = 90
         End If

         Try
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim saveMode As ControlRegionRenderMode = activeForm.Viewer.FloaterRegionRenderMode
            activeForm.Viewer.FloaterRegionRenderMode = ControlRegionRenderMode.None

            ImageToRun.RotateViewPerspective(degrees)

            activeForm.Viewer.FloaterRegionRenderMode = saveMode
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemEditRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEditRegionRectangle.Click, _menuItemEditRegionFreehand.Click, _menuItemEditRegionEllipse.Click, _menuItemEditRegionMagicWand.Click
         Dim activeForm As ViewerForm = ActiveViewerForm
         _addMagicWand = False


         DisableAllInteractiveModes(activeForm.Viewer)
         activeForm.Viewer.InteractiveModes.BeginUpdate()
         If (sender Is _menuItemEditRegionRectangle) Then
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
            activeForm.RegionInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemEditRegionEllipse) Then
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Ellipse
            activeForm.RegionInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemEditRegionFreehand) Then
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Freehand
            activeForm.RegionInteractiveMode.IsEnabled = True
         ElseIf (sender Is _menuItemEditRegionMagicWand) Then
            _addMagicWand = True
            activeForm.AddMagicWandInteractivMode.IsEnabled = True
            Dim dlg As MagicWandThresholdDialog = New MagicWandThresholdDialog()
            dlg.Value = _threshold
            If (dlg.ShowDialog(Me) = DialogResult.OK) Then
               _threshold = dlg.Value
               activeForm.AddMagicWandInteractivMode.Threshold = _threshold
            End If
         End If

         activeForm.Viewer.InteractiveModes.EndUpdate()

         UpdateControls()
      End Sub

      Private Sub _menuItemFormat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemColorTransformHalftone.Click, _menuItemColorTransformGrayScaleFactor.Click, _menuItemColorTransformColorResolution.Click, _menuItemColorGrayScale.Click
         Dim command As RasterCommand = Nothing

         If sender Is _menuItemColorTransformColorResolution Then
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim dlg As ColorResolutionDialog = New ColorResolutionDialog(activeForm.Image, _paintProperties)
            dlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, dlg.BitsPerPixel, dlg.Order, dlg.DitheringMethod, dlg.PaletteFlags, Nothing)
            End If
         ElseIf sender Is _menuItemColorTransformHalftone Then
            Dim dlg As HalftoneDialog = New HalftoneDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New HalfToneCommand(dlg.Type, dlg.Angle, dlg.Dimension, Nothing)
            End If
         ElseIf sender Is _menuItemColorGrayScale Then
            Dim dlg As GrayScaleDialog = New GrayScaleDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New GrayscaleCommand(dlg.BitsPerPixel)
            End If
         ElseIf sender Is _menuItemColorTransformGrayScaleFactor Then
            Dim dlg As GrayScaleFactorDialog = New GrayScaleFactorDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New GrayScaleExtendedCommand(dlg.RedFactor, dlg.GreenFactor, dlg.BlueFactor)
            End If
         End If

         If Not command Is Nothing Then
            RunCommand(command)
         End If
      End Sub

      Private Sub _menuItemImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemImageFlipCustom.Click, _menuItemImageDeskew.Click, _menuItemImageTrim.Click, _menuItemImageShear.Click, _menuItemImageResize.Click, _menuItemImageAutoTrim.Click, _menuItemImageRotateCustom.Click
         Dim command As RasterCommand = Nothing
         Dim activeForm As ViewerForm = ActiveViewerForm

         If (sender Is _menuItemImageAutoTrim) Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.AutoCrop)
            If (dlg.ShowDialog(Me) = Forms.DialogResult.OK) Then
               command = New AutoCropCommand(dlg.Value)
            End If
         ElseIf (sender Is _menuItemImageTrim) Then
            If Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0) Then
               Dim floater As RasterImage = activeForm.Viewer.Floater
               Dim temp As RasterImage = activeForm.Viewer.Image
               activeForm.Viewer.AutoDisposeImages = False
               activeForm.Viewer.Image = floater
               activeForm.Viewer.Floater = Nothing
               activeForm.Viewer.AutoDisposeImages = True
               temp.Dispose()
               If (activeForm.Viewer.Image.HasRegion) Then
                  activeForm.Viewer.Image.MakeRegionEmpty()
               End If
            Else

               Dim dlg As CropDialog = New CropDialog(activeForm.Image.Width, activeForm.Image.Height)
               If (dlg.ShowDialog(Me) = Forms.DialogResult.OK) Then
                  Dim image As RasterImage = activeForm.Image
                  If (dlg.CropLeft > image.Width OrElse _
                     dlg.CropTop > image.Height OrElse _
                     (dlg.CropLeft + dlg.CropWidth) > image.Width OrElse _
                     (dlg.CropTop + dlg.CropHeight) > image.Height) Then
                     Messager.ShowError(Me, "Crop values greater than image dimension!")
                  Else
                     command = New CropCommand(New LeadRect(dlg.CropLeft, dlg.CropTop, dlg.CropWidth, dlg.CropHeight))
                  End If
               End If
            End If
         ElseIf (sender Is _menuItemImageDeskew) Then
            Dim dlg As DeskewDialog = New DeskewDialog()
            If (dlg.ShowDialog(Me) = Forms.DialogResult.OK) Then
               command = New DeskewCommand(dlg.FillColor, dlg.Flags)
            End If
         ElseIf (sender Is _menuItemImageFlipCustom) Then
            Dim dlg As FlipDialog = New FlipDialog()
            If (dlg.ShowDialog(Me) = Forms.DialogResult.OK) Then
               command = New FlipCommand(dlg.Horizontal)
            End If
         ElseIf (sender Is _menuItemImageRotateCustom) Then
            Dim dlg As RotateDialog = New RotateDialog()
            If (dlg.ShowDialog(Me) = Forms.DialogResult.OK) Then
               command = New RotateCommand(dlg.Angle, dlg.Flags, dlg.FillColor)
            End If
         ElseIf (sender Is _menuItemImageResize) Then
            Dim dlg As ResizeDialog = New ResizeDialog(activeForm.Image.Width, activeForm.Image.Height)
            If (dlg.ShowDialog(Me) = Forms.DialogResult.OK) Then
               command = New SizeCommand(dlg.ImageWidth, dlg.ImageHeight, dlg.Flags)
            End If
         ElseIf (sender Is _menuItemImageShear) Then
            Dim dlg As ShearDialog = New ShearDialog()
            If (dlg.ShowDialog(Me) = Forms.DialogResult.OK) Then
               command = New ShearCommand(dlg.Angle, dlg.Horizontal, dlg.FillColor)
            End If
         End If
         If (Not command Is Nothing) Then
            RunCommand(command)
         End If
      End Sub

      Private Sub _menuItemEffectsSpecial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEffectsBlurMotionBlur.Click, _menuItemEffectsBlurAverage.Click, _menuItemEffectsBlurAntiAlias.Click, _menuItemEffectsSharpenUnsharpMask.Click, _menuItemEffectsSharpenSharpen.Click, _menuItemEffectsNoiseMedian.Click, _menuItemEffectsNoiseAddNoise.Click, _menuItemEffects3DEffectsEmboss.Click, _menuItemEffectsSpecialGaussian.Click, _menuItemEffectsPixelateMosaic.Click, _menuItemEffectsEdgeDetector.Click, _menuItemEffectsArtisticOilify.Click, _menuItemColorPosterize.Click
         Dim command As RasterCommand = Nothing
         Dim activeForm As ViewerForm = ActiveViewerForm

         If sender Is _menuItemEffectsNoiseAddNoise Then
            Dim dlg As AddNoiseDialog = New AddNoiseDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New AddNoiseCommand(dlg.Range, dlg.Channel)
            End If
         ElseIf sender Is _menuItemEffectsBlurAntiAlias Then
            Dim dlg As AntiAliasDialog = New AntiAliasDialog(activeForm.Image.BitsPerPixel)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New AntiAliasingCommand(dlg.Threshold, dlg.Dimension, dlg.Filter)
            End If
         ElseIf sender Is _menuItemEffectsBlurAverage Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Average)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New AverageCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemEffectsEdgeDetector Then
            Dim dlg As EdgeDetectorDialog = New EdgeDetectorDialog(activeForm.Image.BitsPerPixel)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New EdgeDetectorCommand(dlg.Threshold, dlg.Filter)
            End If
         ElseIf sender Is _menuItemEffects3DEffectsEmboss Then
            Dim dlg As EmbossDialog = New EmbossDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New EmbossCommand(dlg.Direction, dlg.Depth)
            End If
         ElseIf sender Is _menuItemEffectsSpecialGaussian Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Gaussian)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New GaussianCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemEffectsNoiseMedian Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Median)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New MedianCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemEffectsPixelateMosaic Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Mosaic)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New MosaicCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemEffectsBlurMotionBlur Then
            Dim dlg As MotionBlurDialog = New MotionBlurDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New MotionBlurCommand(dlg.Dimension, dlg.Angle, dlg.UniDirectional)
            End If
         ElseIf sender Is _menuItemEffectsArtisticOilify Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Oilify)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New OilifyCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemColorPosterize Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Posterize)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New PosterizeCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemEffectsSharpenSharpen Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Sharpen)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New SharpenCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemEffectsSharpenUnsharpMask Then
            Dim dlg As UnsharpMaskDialog = New UnsharpMaskDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New UnsharpMaskCommand(dlg.Amount, dlg.Radius, dlg.Threshold, dlg.ColorSpace)
            End If
         End If

         If Not command Is Nothing Then
            RunCommand(command)
         End If
      End Sub

      Private Sub _menuItemEffectsSpatialSpatialFilters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEffectsSpatialSpatialFilters.Click
         Dim dlg As SpatialDialog = New SpatialDialog()
         If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
            RunCommand(New SpatialFilterCommand(dlg.Filter))
         End If
      End Sub

      Private Sub _menuItemEffectsBinary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEffectsNoiseMin.Click, _menuItemEffectsNoiseMax.Click, _menuItemEffectsBinaryBinaryFilters.Click
         Dim command As RasterCommand = Nothing

         If sender Is _menuItemEffectsBinaryBinaryFilters Then
            Dim dlg As BinaryDialog = New BinaryDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New BinaryFilterCommand(dlg.Filter)
            End If
         ElseIf sender Is _menuItemEffectsNoiseMin Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Min)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New MinimumCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemEffectsNoiseMax Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Max)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New MaximumCommand(dlg.Value)
            End If
         End If

         If Not command Is Nothing Then
            RunCommand(command)
         End If
      End Sub

      Private Sub _menuItemColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemEffectsEdgeContour.Click, _menuItemColorSolarize.Click, _menuItemColorInvert.Click, _menuItemColorIntensityDetect.Click, _menuItemColorHistogramStretchIntensity.Click, _menuItemColorHistogramEqualize.Click, _menuItemColorHistogramContrast.Click, _menuItemColorFill.Click, _menuItemColorAdjustHue.Click, _menuItemColorSwapColors.Click, _menuItemColorUniqueColors.Click
         Dim command As RasterCommand = Nothing

         If sender Is _menuItemEffectsEdgeContour Then
            Dim dlg As ContourDialog = New ContourDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New ContourFilterCommand(dlg.Threshold, dlg.DeltaDirection, dlg.MaximumError, dlg.Type)
            End If
         ElseIf sender Is _menuItemColorFill Then
            If Tools.ShowColorDialog(Me, _fillColor) Then
               command = New FillCommand(_fillColor)
            End If
         ElseIf sender Is _menuItemColorHistogramContrast Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.HistoContrast)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New HistogramContrastCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemColorHistogramEqualize Then
            Dim dlg As HistogramEqualizeDialog = New HistogramEqualizeDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New HistogramEqualizeCommand(dlg.ColorSpace)
            End If
         ElseIf sender Is _menuItemColorAdjustHue Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Hue)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New ChangeHueCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemColorInvert Then
            command = New InvertCommand()
         ElseIf sender Is _menuItemColorIntensityDetect Then
            Dim dlg As IntensityDetectDialog = New IntensityDetectDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New IntensityDetectCommand(dlg.Low, dlg.High, dlg.InColor, dlg.OutColor, dlg.Channel)
            End If
         ElseIf sender Is _menuItemColorSolarize Then
            Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Solarize)
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New SolarizeCommand(dlg.Value)
            End If
         ElseIf sender Is _menuItemColorHistogramStretchIntensity Then
            command = New StretchIntensityCommand()
         ElseIf sender Is _menuItemColorSwapColors Then
            Dim dlg As SwapColorsDialog = New SwapColorsDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New SwapColorsCommand(dlg.Type)
            End If
         ElseIf sender Is _menuItemColorUniqueColors Then
            Dim colorCount As New ColorCountCommand()
            colorCount.Run(ActiveViewerForm.Image)
            Dim message As String = String.Format("Image contains {0} unique colors", colorCount.ColorCount)
            Messager.ShowInformation(Me, message)
         End If

         If Not command Is Nothing Then
            RunCommand(command)
         End If
      End Sub

      Private Sub _menuItemDocument_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemDocumentSmooth.Click, _menuItemDocumentLineRemove.Click, _menuItemDocumentInvertedText.Click, _menuItemDocumentHolePunchRemove.Click, _menuItemDocumentDotRemove.Click, _menuItemDocumentDespeckle.Click, _menuItemDocumentBorderRemove.Click
         Dim command As RasterCommand = Nothing

         If sender Is _menuItemDocumentBorderRemove Then
            Dim dlg As BorderRemoveDialog = New BorderRemoveDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New BorderRemoveCommand(dlg.Flags, dlg.Border, dlg.Percent, dlg.WhiteNoiseLength, dlg.Variance)
            End If
         ElseIf sender Is _menuItemDocumentDespeckle Then
            command = New DespeckleCommand()
         ElseIf sender Is _menuItemDocumentDotRemove Then
            Dim dlg As DotRemoveDialog = New DotRemoveDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New DotRemoveCommand(dlg.Flags, dlg.MinWidth, dlg.MinHeight, dlg.MaxWidth, dlg.MaxHeight)
            End If
         ElseIf sender Is _menuItemDocumentHolePunchRemove Then
            Dim dlg As HolePunchRemoveDialog = New HolePunchRemoveDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New HolePunchRemoveCommand(dlg.Flags, dlg.HoleLocation, dlg.MinCount, dlg.MaxCount, dlg.MinWidth, dlg.MinHeight, dlg.MaxWidth, dlg.MaxHeight)
            End If
         ElseIf sender Is _menuItemDocumentInvertedText Then
            Dim dlg As InvertedTextDialog = New InvertedTextDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New InvertedTextCommand(dlg.Flags, dlg.MinInvertWidth, dlg.MinInvertHeight, dlg.MinBlackPercent, dlg.MaxBlackPercent)
            End If
         ElseIf sender Is _menuItemDocumentLineRemove Then
            Dim dlg As LineRemoveDialog = New LineRemoveDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New LineRemoveCommand(dlg.Flags, dlg.MinLineLength, dlg.MaxLineWidth, dlg.Wall, dlg.MaxWallPercent, dlg.GapLength, dlg.LineVariance, dlg.Remove)
            End If
         ElseIf sender Is _menuItemDocumentSmooth Then
            Dim dlg As SmoothDialog = New SmoothDialog()
            If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
               command = New SmoothCommand(dlg.Flags, dlg.Length)
            End If
         End If

         If Not command Is Nothing Then
            RunCommand(command)
         End If
      End Sub

      Private Sub _menuItemPreferencesProgressBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemPreferencesProgressBar.Click
         _menuItemPreferencesProgressBar.Checked = Not _menuItemPreferencesProgressBar.Checked
      End Sub

      Private Sub _menuItemHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemHelpAbout.Click
         Using aboutDialog As New AboutDialog("Main", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _menuItemWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemWindowTileVertically.Click, _menuItemWindowTileHorizontally.Click, _menuItemWindowCloseAll.Click, _menuItemWindowCascade.Click, _menuItemWindowArrangeIcons.Click
         If sender Is _menuItemWindowCascade Then
            LayoutMdi(MdiLayout.Cascade)
         ElseIf sender Is _menuItemWindowTileHorizontally Then
            LayoutMdi(MdiLayout.TileHorizontal)
         ElseIf sender Is _menuItemWindowTileVertically Then
            LayoutMdi(MdiLayout.TileVertical)
         ElseIf sender Is _menuItemWindowArrangeIcons Then
            LayoutMdi(MdiLayout.ArrangeIcons)
         ElseIf sender Is _menuItemWindowCloseAll Then
            Do While MdiChildren.Length > 0
               MdiChildren(0).Close()
            Loop
            UpdateControls()
         End If
      End Sub

      Private Function LoadImage(ByVal multiSelect As Boolean) As List(Of ImageInformation)
         Dim loader As ImageFileLoader = New ImageFileLoader()

         Try
            loader.OpenDialogInitialPath = _openInitialPath
            loader.ShowLoadPagesDialog = True
            loader.MultiSelect = multiSelect
            loader.UseGdiPlus = (_paintProperties.PaintEngine = RasterPaintEngine.GdiPlus)
            loader.LoadCorrupted = _menuItemLoadingCorruptedImages.Checked
            loader.PreferVector = _menuItemPreferVector.Checked

            Dim filesCount As Integer = loader.Load(Me, _codecs, True)
            If filesCount > 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               _menuItemPreferencesLoadMultithreaded.Checked = _codecs.Options.Jpeg.Load.Multithreaded
               Return loader.Images
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try

         Return Nothing
      End Function

      Private Sub NewImage(ByVal info As ImageInformation)
         ' If this is the first time we are loading a 32-bit image and the paint engine is GDI
         ' Ask if the user wants to switch to GDI+2. GDI engine does not support alpha.
         If Not IsNothing(info.Image) AndAlso (info.Image.BitsPerPixel = 32) AndAlso (_paintProperties.PaintEngine = RasterPaintEngine.Gdi) Then
            Dim message As String = "You are trying to view a 32-bits/pixel image while the current paint engine is set to RasterPaintEngine.Gdi. Switching to RasterPaintEngine.GdiPlus will enable you to view any alpha channel data stored in this image.\n\nDo you want to switch to RasterPaintEngine.GdiPlus now?"
            If (Messager.ShowQuestion( _
               Me, _
               message, _
               MessageBoxButtons.YesNo) = DialogResult.Yes) Then
               _paintProperties.PaintEngine = RasterPaintEngine.GdiPlus
               For Each i As ViewerForm In MdiChildren
                  i.UpdatePaintProperties(_paintProperties)
               Next
            End If
         End If

         Dim child As ViewerForm = New ViewerForm()
         child.MdiParent = Me
         child.Initialize(info, _paintProperties, _animateRegions, True, _useDpi)
         child.Viewer.Zoom(ControlSizeMode.ActualSize, 1, child.Viewer.DefaultZoomOrigin)
         child.Viewer.InteractiveModes.BeginUpdate()
         child.NoneInteractiveMode.IsEnabled = True

         'Set the DoubleTapSizeMode property for all ImageViewerPanZoomInteractiveModes to uses the current size mode of the image viewer control
         For Each mode As ImageViewerInteractiveMode In child.Viewer.InteractiveModes
            If (TypeOf (mode) Is ImageViewerPanZoomInteractiveMode) Then
               TryCast(mode, ImageViewerPanZoomInteractiveMode).DoubleTapSizeMode = child.Viewer.SizeMode
            End If
         Next

         child.Viewer.InteractiveModes.EndUpdate()

         child.Show()

         _menuItemColorWindowLevel.Enabled = (info.Image.GrayscaleMode <> RasterGrayscaleMode.None)
      End Sub

      Private Function ShouldProcessMainImage(ByVal command As RasterCommand) As Boolean
         Dim activeForm As ViewerForm = ActiveViewerForm
         If Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0) Then
            If TypeOf command Is GrayscaleCommand Then
               Return True
            End If
            If TypeOf command Is GrayScaleExtendedCommand Then
               Return True
            End If
            If TypeOf command Is ColorResolutionCommand Then
               Return True
            End If
            If TypeOf command Is HalfToneCommand Then
               Return True
            End If
         End If
         Return False
      End Function

      Private Property ImageToRun() As RasterImage
         Get
            Dim activeForm As ViewerForm = ActiveViewerForm

            If Not activeForm.Viewer.Floater Is Nothing AndAlso (activeForm.Viewer.FloaterOpacity > 0.0) Then
               Return activeForm.Viewer.Floater
            Else
               Return activeForm.Viewer.Image
            End If
         End Get
         Set(ByVal value As RasterImage)
            If Not value Is Nothing Then
               Dim activeForm As ViewerForm = ActiveViewerForm

               If Not activeForm.Viewer.Floater Is Nothing AndAlso activeForm.Viewer.FloaterOpacity > 0.0 Then
                  activeForm.Viewer.Floater = value
               Else
                  activeForm.Viewer.Image = value
               End If
            End If
         End Set
      End Property

      Private Sub RunCommand(ByVal command As RasterCommand)
         Dim activeForm As ViewerForm = ActiveViewerForm

         Try
            ' save the floater position so we preserve the center
            Dim oldFloaterCenter As Point = New Point(0, 0)
            If activeForm.Viewer.FloaterOpacity > 0.0 AndAlso (Not activeForm.Viewer.Floater Is Nothing) Then
               Dim floaterTransform As LeadMatrix = ActiveViewerForm.Viewer.FloaterTransform
               oldFloaterCenter = New Point(CInt(floaterTransform.OffsetX), CInt(floaterTransform.OffsetY))
               Dim rect As Rectangle = Converters.ConvertRect(activeForm.Viewer.Floater.GetRegionBounds(Nothing))
               oldFloaterCenter.Offset(CInt(rect.Right / 2), CInt(rect.Bottom / 2))
            End If
            If _menuItemPreferencesProgressBar.Checked Then
               Dim dlg As CommandProgressDialog = New CommandProgressDialog()
               dlg.Command = command
               dlg.Image = ImageToRun
               ' save the image, in case the command is canceled
               Dim currentPage As Integer = ImageToRun.Page
               Dim backupImage As RasterImage = ImageToRun.CloneAll()
               Try
                  dlg.ShowDialog(Me)
                  If dlg.Cancel Then
                     ImageToRun = backupImage.CloneAll()
                     ImageToRun.Page = currentPage
                  End If
                  dlg.Hide()
                  dlg.Dispose()
                  Application.DoEvents()
               Finally
                  CType(backupImage, IDisposable).Dispose()
               End Try
               If (ShouldProcessMainImage(command)) Then ' if true, then the floater has been processed
                  ' save the image, in case the command is canceled
                  currentPage = activeForm.Viewer.Image.Page
                  backupImage = activeForm.Viewer.Image.CloneAll()
                  Try
                     Dim dlg2 As New CommandProgressDialog
                     dlg2.Command = dlg.Command
                     dlg2.Image = dlg.Image
                     dlg2.ShowDialog(Me)
                     If (dlg2.Cancel) Then
                        activeForm.Viewer.Image = backupImage.CloneAll()
                        activeForm.Viewer.Image.Page = currentPage
                     End If
                     dlg2.Hide()
                     dlg2.Dispose()
                     Application.DoEvents()
                  Finally
                     backupImage.Dispose()
                  End Try
               End If
            Else
               Dim wait As New WaitCursor
               Try
                  command.Run(ImageToRun)
                  If ShouldProcessMainImage(command) Then ' if true, then the floater has been processed
                     command.Run(activeForm.Viewer.Image) ' now process the main image
                  End If
               Finally
                  CType(wait, IDisposable).Dispose()
               End Try
            End If
            If activeForm.Viewer.FloaterOpacity > 0.0 AndAlso (Not activeForm.Viewer.Floater Is Nothing) Then
               Dim saveMode As ControlRegionRenderMode = activeForm.Viewer.FloaterRegionRenderMode
               activeForm.Viewer.FloaterRegionRenderMode = ControlRegionRenderMode.None

               Dim floaterTransform As LeadMatrix = activeForm.Viewer.FloaterTransform
               floaterTransform.OffsetX = floaterTransform.OffsetX
               floaterTransform.OffsetY = floaterTransform.OffsetY

               Dim newFloaterCenter As Point = New Point(CInt(floaterTransform.OffsetX), CInt(floaterTransform.OffsetY))
               newFloaterCenter.Offset(CInt(activeForm.Viewer.Floater.Width / 2), CInt(activeForm.Viewer.Floater.Height / 2))
               ' move the floater so the center is preserved
               Dim floaterPosition As Point = New Point(CInt(floaterTransform.OffsetX), CInt(floaterTransform.OffsetY))
               floaterPosition.Offset(oldFloaterCenter.X - newFloaterCenter.X, oldFloaterCenter.Y - newFloaterCenter.Y)

               floaterTransform.OffsetX = floaterPosition.X
               floaterTransform.OffsetY = floaterPosition.Y

               activeForm.Viewer.FloaterTransform = floaterTransform
               activeForm.Viewer.FloaterRegionRenderMode = saveMode
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _printDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
         ' Start from first page in the image
         _currentPrintPageNumber = 1
      End Sub

      Private Sub _printDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
         CombineFloater()
         Dim image As RasterImage = ActiveViewerForm.Viewer.Image

         ' Get the print document object
         Dim document As PrintDocument = CType(sender, PrintDocument)

         ' Create an new LEADTOOLS image printer class
         Dim printer As New RasterImagePrinter()

         ' Set the document object so page calculations can be performed
         printer.PrintDocument = document

         ' We want to fit and center the image into the maximum print area
         printer.SizeMode = RasterPaintSizeMode.FitAlways
         printer.HorizontalAlignMode = RasterPaintAlignMode.Center
         printer.VerticalAlignMode = RasterPaintAlignMode.Center

         ' Account for FAX images that may have different horizontal and vertical resolution
         printer.UseDpi = True

         ' Print the whole image
         printer.ImageRectangle = Rectangle.Empty

         ' Use maximum page dimension ignoring the margins, this will be equivalant of printing
         ' using Windows Photo Gallery
         printer.PageRectangle = RectangleF.Empty
         printer.UseMargins = False

         ' Print the current page
         printer.Print(image, _currentPrintPageNumber, e)

         ' Go to the next page
         _currentPrintPageNumber = _currentPrintPageNumber + 1

         ' Inform the printer whether we have more pages to print
         If _currentPrintPageNumber <= document.PrinterSettings.ToPage Then
            e.HasMorePages = True
         Else
            e.HasMorePages = False
         End If
      End Sub

      Private Sub _printDocument_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
         ' Nothing to do here
      End Sub

      Private Sub MainForm_DragEnter(ByVal sender As Object, ByVal e As Forms.DragEventArgs) Handles MyBase.DragEnter
         If CanFocus Then
            If Tools.CanDrop(e.Data) Then
               e.Effect = DragDropEffects.Copy
            End If
         End If
      End Sub

      Private Sub MainForm_DragDrop(ByVal sender As Object, ByVal e As Forms.DragEventArgs) Handles MyBase.DragDrop
         If CanFocus Then
            If Tools.CanDrop(e.Data) Then
               Dim files As String() = Tools.GetDropFiles(e.Data)
               If Not files Is Nothing Then
                  LoadDropFiles(Nothing, files)
               End If
            End If
         End If
      End Sub

      Public Sub LoadDropFiles(ByVal viewer As ViewerForm, ByVal files As String())
         Try
            If Not files Is Nothing Then
               Dim i As Integer = 0
               Do While i < files.Length
                  Try
                     Dim image As RasterImage = _codecs.Load(files(i))
                     Dim info As ImageInformation = New ImageInformation(image, files(i))
                     If i = 0 AndAlso Not viewer Is Nothing Then
                        viewer.Initialize(info, _paintProperties, _animateRegions, False, _useDpi)
                     Else
                        NewImage(info)
                     End If
                  Catch ex As Exception
                     Messager.ShowFileOpenError(Me, files(i), ex)
                  End Try
                  i += 1
               Loop
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub CombineFloater()
         Dim activeForm As ViewerForm = ActiveViewerForm

         If activeForm.Viewer.Image.HasRegion Then
            activeForm.Viewer.Image.MakeRegionEmpty()
         ElseIf activeForm.Viewer.FloaterOpacity > 0.0 AndAlso Not activeForm.Viewer.Floater Is Nothing Then
            DisableAllInteractiveModes(activeForm.Viewer)
            activeForm.Viewer.InteractiveModes.BeginUpdate()
            activeForm.NoneInteractiveMode.IsEnabled = True
            activeForm.Viewer.InteractiveModes.EndUpdate()
            activeForm.Viewer.CombineFloater(False)
            activeForm.Viewer.Floater = Nothing
            activeForm.Viewer.Refresh()
         End If

         UpdateControls()
      End Sub

      Private Sub _menuItemImage_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemImage.DropDownOpened
         If ActiveViewerForm.Viewer.Image.BitsPerPixel > 1 Then
            _menuItemDocument.Enabled = False
         Else
            _menuItemDocument.Enabled = True
         End If
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         If _inTwainAcquire Then
            e.Cancel = True
         End If
      End Sub

      Private Sub codecs_LoadInformation(ByVal sender As Object, ByVal e As CodecsLoadInformationEventArgs)
         ' Set the information
         e.Format = _rawdataLoad.Format
         e.Width = _rawdataLoad.Width
         e.Height = _rawdataLoad.Height
         e.BitsPerPixel = _rawdataLoad.BitsPerPixel
         e.XResolution = _rawdataLoad.XResolution
         e.YResolution = _rawdataLoad.YResolution
         e.Offset = _rawdataLoad.Offset
         e.WhiteOnBlack = _rawdataLoad.WhiteOnBlack

         If _rawdataLoad.Padding Then
            e.Pad4 = True
         End If

         e.Order = _rawdataLoad.Order

         If _rawdataLoad.ReverseBits Then
            e.LeastSignificantBitFirst = True
         End If

         e.ViewPerspective = _rawdataLoad.ViewPerspective

         ' If image is palettized create a grayscale palette
         If _rawdataLoad.PaletteEnabled Then
            If e.BitsPerPixel <= 8 Then
               If (Not _rawdataLoad.FixedPalette) Then
                  Dim colors As Integer = 1 << e.BitsPerPixel
                  Dim palette As RasterColor() = New RasterColor(colors - 1) {}
                  Dim i As Integer = 0
                  Do While i < palette.Length
                     Dim val As Byte = CByte((i * 256) / colors)
                     palette(i) = New RasterColor(val, val, val)
                     i += 1
                  Loop

                  e.SetPalette(palette)
               Else
                  e.SetPalette(RasterPalette.Fixed(e.BitsPerPixel))
               End If
            End If
         End If
      End Sub

      Private Sub LoadRaw(ByVal fileName As String)
         Dim dlg As RawDialog = New RawDialog(True)
         dlg.CurrentRawData = _rawdataLoad
         If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
            Dim imageInfo As ImageInformation = New ImageInformation()
            imageInfo.Name = fileName
            _rawdataLoad = dlg.CurrentRawData
            Dim handler As EventHandler(Of CodecsLoadInformationEventArgs) = New EventHandler(Of CodecsLoadInformationEventArgs)(AddressOf codecs_LoadInformation)
            _codecs.Options.Load.Format = _rawdataLoad.Format
            AddHandler _codecs.LoadInformation, handler

            Try
               Dim wait As WaitCursor = New WaitCursor()
               Try
                  imageInfo.Image = _codecs.Load(fileName)
                  NewImage(imageInfo)
               Finally
                  CType(wait, IDisposable).Dispose()
               End Try
            Catch ex As Exception
               MessageBox.Show("Invalid File Parameter " & ex.Message)
            Finally
               RemoveHandler _codecs.LoadInformation, handler
               _codecs.Options.Load.Format = RasterImageFormat.Unknown
            End Try
         End If
      End Sub

      Private Sub SaveRaw(ByVal fileName As String)
         Dim activeForm As ViewerForm = ActiveViewerForm

         Dim dlg As RawDialog = New RawDialog(False)
         _rawdataSave.Width = activeForm.Viewer.Image.Width
         _rawdataSave.Height = activeForm.Viewer.Image.Height
         _rawdataSave.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
         dlg.CurrentRawData = _rawdataSave
         If dlg.ShowDialog(Me) = Forms.DialogResult.OK Then
            Dim imageInfo As ImageInformation = New ImageInformation()
            _rawdataSave = dlg.CurrentRawData
            Try
               Dim wait As WaitCursor = New WaitCursor()
               Try
                  ' Set RAW options
                  _codecs.Options.Raw.Save.Pad4 = _rawdataSave.Padding
                  _codecs.Options.Raw.Save.ReverseBits = _rawdataSave.ReverseBits
                  _codecs.Options.Save.OptimizedPalette = False
                  If _rawdataSave.Format = RasterImageFormat.Unknown Then
                     _rawdataSave.Format = RasterImageFormat.Raw
                  End If

                  Dim fs As FileStream = File.Create(fileName)
                  Try
                     _codecs.Save(activeForm.Viewer.Image, fs, _rawdataSave.Offset, _rawdataSave.Format, _rawdataSave.BitsPerPixel, 1, 1, 1, CodecsSavePageMode.Overwrite)
                     fs.Close()
                  Finally
                     CType(fs, IDisposable).Dispose()
                  End Try
               Finally
                  CType(wait, IDisposable).Dispose()
               End Try
            Catch ex As Exception
               MessageBox.Show("Invalid File Parameter " & ex.Message)
            End Try
         End If
      End Sub

      Private Sub _menuItemFileOpenRaw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileOpenRaw.Click
         Try
            Dim ofd As OpenFileDialog = New OpenFileDialog()
            ofd.Filter = "All Files (*.*)|*.*|RAW (*.raw)|*.raw|Fax (*.fax)|*.fax|ABIC (*.abic;*.abc)|*.abic;*.abc"
            ofd.FilterIndex = 1
            If ofd.ShowDialog(Me) = Forms.DialogResult.OK Then
               LoadRaw(ofd.FileName)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemFileSaveRaw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileSaveRaw.Click
         Dim saver As ImageFileSaver = New ImageFileSaver()

         Try
            CombineFloater()
            Dim sfd As SaveFileDialog = New SaveFileDialog()
            sfd.Filter = "RAW (*.raw)|*.raw|Fax (*.fax)|*.fax"
            sfd.FilterIndex = 1
            If sfd.ShowDialog(Me) = Forms.DialogResult.OK Then
               SaveRaw(sfd.FileName)
            End If
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      Private Sub _menuItemColorWindowLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemColorWindowLevel.Click
         Try
            Dim windowLevelDlg As New RasterWindowLevelDialog()
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim lookupSize As Integer
            Dim minMaxBits As MinMaxBitsCommand = New MinMaxBitsCommand()
            Dim minMaxValues As MinMaxValuesCommand = New MinMaxValuesCommand()
            Dim lookupTable As RasterColor()

            minMaxBits.Run(activeForm.Viewer.Image)
            minMaxValues.Run(activeForm.Viewer.Image)

            lookupSize = (1 << (minMaxBits.MaximumBit - minMaxBits.MinimumBit + 1))
            lookupTable = New RasterColor(lookupSize - 1) {}


            windowLevelDlg.Image = activeForm.Viewer.Image
            windowLevelDlg.ShowPreview = True
            windowLevelDlg.ShowRange = True
            windowLevelDlg.ShowZoomLevel = True
            windowLevelDlg.ZoomToFit = False
            windowLevelDlg.LowBit = minMaxBits.MinimumBit
            windowLevelDlg.HighBit = minMaxBits.MaximumBit
            windowLevelDlg.Low = minMaxValues.MinimumValue
            windowLevelDlg.High = minMaxValues.MaximumValue
            windowLevelDlg.WindowLevelFlags = RasterPaletteWindowLevelFlags.Inside Or RasterPaletteWindowLevelFlags.Linear
            windowLevelDlg.LookupTable = lookupTable
            windowLevelDlg.Signed = activeForm.Viewer.Image.Signed

            Select Case activeForm.Viewer.Image.GrayscaleMode
               Case RasterGrayscaleMode.OrderedNormal
                  windowLevelDlg.StartColor = New RasterColor(0, 0, 0)
                  windowLevelDlg.EndColor = New RasterColor(255, 255, 255)

                  Exit Select

               Case RasterGrayscaleMode.OrderedInverse
                  windowLevelDlg.StartColor = New RasterColor(255, 255, 255)
                  windowLevelDlg.EndColor = New RasterColor(0, 0, 0)

                  Exit Select

               Case RasterGrayscaleMode.NotOrdered
                  windowLevelDlg.StartColor = New RasterColor(0, 0, 0)
                  windowLevelDlg.EndColor = New RasterColor(255, 255, 255)

                  Exit Select

               Case Else
                  MessageBox.Show(Owner, "Window Level is not supported for this bitmap order", "Window Level Error", MessageBoxButtons.OK)

                  _menuItemColorWindowLevel.Enabled = False

                  Return
            End Select

            If windowLevelDlg.ShowDialog(Owner) = Forms.DialogResult.OK Then
               Dim wlFlags As RasterPaletteWindowLevelFlags

               If (windowLevelDlg.Signed) Then
                  wlFlags = RasterPaletteWindowLevelFlags.Signed
               Else
                  wlFlags = RasterPaletteWindowLevelFlags.None
               End If

               If windowLevelDlg.Signed Then
                  RasterPalette.WindowLevelFillLookupTable(lookupTable, windowLevelDlg.StartColor, windowLevelDlg.EndColor, windowLevelDlg.Low, windowLevelDlg.High, windowLevelDlg.LowBit, windowLevelDlg.HighBit, minMaxValues.MinimumValue, minMaxValues.MaximumValue, windowLevelDlg.Factor, windowLevelDlg.WindowLevelFlags Or wlFlags)
               Else
                  RasterPalette.WindowLevelFillLookupTable(lookupTable, windowLevelDlg.StartColor, windowLevelDlg.EndColor, windowLevelDlg.Low, windowLevelDlg.High, windowLevelDlg.LowBit, windowLevelDlg.HighBit, minMaxValues.MinimumValue, minMaxValues.MaximumValue, windowLevelDlg.Factor, windowLevelDlg.WindowLevelFlags Or (RasterPaletteWindowLevelFlags.None))
               End If

               activeForm.Viewer.Image.WindowLevel(windowLevelDlg.LowBit, windowLevelDlg.HighBit, lookupTable, RasterWindowLevelMode.PaintAndProcessing)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemPreferencesLoadTextFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemPreferencesLoadTextFile.Click
         _menuItemPreferencesLoadTextFile.Checked = Not _menuItemPreferencesLoadTextFile.Checked
         EnableTextFiles(_codecs, _menuItemPreferencesLoadTextFile.Checked)
      End Sub

      Private Sub _menuItemPreferencesAnimateRegions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemPreferencesAnimateRegions.Click
         _animateRegions = Not _animateRegions
         _menuItemPreferencesAnimateRegions.Checked = _animateRegions

         For Each i As ViewerForm In MdiChildren
            i.UpdateAnimateRegions(_animateRegions)
         Next
      End Sub

#If LEADTOOLS_V20_OR_LATER Then
      Private Sub _menuItemEffectsOther_Click(sender As Object, e As EventArgs) Handles _menuItemEffectsOtherWienerFilter.Click
         If sender Is _menuItemEffectsOtherWienerFilter Then
            Dim dlg As New WienerFilterDialog(Me, ActiveViewerForm)
            dlg.ShowDialog(Me)
         End If
      End Sub
#End If

      Private Sub _menuItemColorSwapColorOrder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemColorSwapColorOrder.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm
            If (activeForm.Viewer.Image.Order = RasterByteOrder.Rgb) Then
               activeForm.Viewer.Image.Order = RasterByteOrder.Bgr
            Else
               activeForm.Viewer.Image.Order = RasterByteOrder.Rgb
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _menuItemColorAdjustBalanceColors_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemColorAdjustBalanceColors.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            Dim dlg As BalanceColorsDialog = New BalanceColorsDialog(activeForm.Viewer.Image, _paintProperties)

            dlg.RedWeights.ToRed = 1
            dlg.GreenWeights.ToGreen = 1
            dlg.BlueWeights.ToBlue = 1

            If Forms.DialogResult.OK = dlg.ShowDialog(Me) Then
               Dim command As BalanceColorsCommand = New BalanceColorsCommand(dlg.RedWeights, dlg.GreenWeights, dlg.BlueWeights)

               RunCommand(command)
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _menuItemColorAdjustBrightness_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemColorAdjustBrightness.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            Dim dlg As BrightnessDialog = New BrightnessDialog(activeForm.Viewer.Image, _paintProperties)

            If Forms.DialogResult.OK = dlg.ShowDialog(Me) Then
               Dim command As ChangeIntensityCommand = New ChangeIntensityCommand(dlg.Brightness)

               RunCommand(command)
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _menuItemColorMatchHistogram_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemColorMatchHistogram.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim dlg As MatchHistogramDialog = New MatchHistogramDialog(activeForm.Viewer.Image, _paintProperties, Me.MdiChildren)
            If (DialogResult.OK = dlg.ShowDialog) Then
               Dim command As MatchHistogramCommand = New MatchHistogramCommand(CType(Me.MdiChildren(dlg.ImageIndex), ViewerForm).Image)
               RunCommand(command)
            End If

         Catch ex As Exception
            Throw ex
         End Try

      End Sub

      Private Sub _menuItemColorAdjustContrast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemColorAdjustContrast.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            Dim dlg As ContrastDialog = New ContrastDialog(activeForm.Viewer.Image, _paintProperties)

            If Forms.DialogResult.OK = dlg.ShowDialog(Me) Then
               Dim command As ChangeContrastCommand = New ChangeContrastCommand(dlg.Contrast)

               RunCommand(command)
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _menuItemColorAdjustSaturation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemColorAdjustSaturation.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            Dim dlg As SaturationDialog = New SaturationDialog(activeForm.Viewer.Image, _paintProperties)

            If Forms.DialogResult.OK = dlg.ShowDialog(Me) Then
               Dim command As ChangeSaturationCommand = New ChangeSaturationCommand(dlg.Saturation)

               RunCommand(command)
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _menuItemColorAdjustGammaCorrect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemColorAdjustGammaCorrect.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            Dim dlg As GammaAdjustmentDialog = New GammaAdjustmentDialog(activeForm.Viewer.Image, _paintProperties)

            dlg.Gamma = 150

            If Forms.DialogResult.OK = dlg.ShowDialog(Me) Then
               Dim command As GammaCorrectCommand = New GammaCorrectCommand(dlg.Gamma)

               RunCommand(command)
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _menuItemEditRegionNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemEditRegionNone.Click
         CombineFloater()

         UpdateControls()
      End Sub

      Private Sub _menuItemViewAlignModeHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemViewAlignModeHorizontalNear.Click, _menuItemViewAlignModeHorizontalCenter.Click, _menuItemViewAlignModeHorizontalFar.Click
         Dim activeForm As ViewerForm = ActiveViewerForm

         If (sender Is _menuItemViewAlignModeHorizontalNear) Then
            activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Near
         ElseIf (sender Is _menuItemViewAlignModeHorizontalCenter) Then
            activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Center
         Else
            activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Far
         End If

         UpdateControls()
      End Sub

      Private Sub _menuItemViewAlignModeVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemViewAlignModeVerticalNear.Click, _menuItemViewAlignModeVerticalFar.Click, _menuItemViewAlignModeVerticalCenter.Click
         Dim activeForm As ViewerForm = ActiveViewerForm

         If (sender Is _menuItemViewAlignModeVerticalNear) Then
            activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Near
         ElseIf (sender Is _menuItemViewAlignModeVerticalCenter) Then
            activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Center
         Else
            activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Far
         End If

         UpdateControls()
      End Sub

      Private Sub _menuItemImageFastFlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemImageFastFlipVertical.Click, _menuItemImageFastFlipHorizontal.Click
         Try
            ImageToRun.FlipViewPerspective(sender Is _menuItemImageFastFlipHorizontal)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemColorSeparation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemColorSeparationRGB.Click, _menuItemColorSeparationHSV.Click, _menuItemColorSeparationHLS.Click, _menuItemColorSeparationCMYK.Click, _menuItemColorSeparationCMY.Click
         Try

            Dim command As ColorSeparateCommand = New ColorSeparateCommand()

            If (sender Is _menuItemColorSeparationRGB) Then
               CombineFloater()

               command.Type = ColorSeparateCommandType.Rgb
               RunCommand(command)

               ' Create Blue Plane Window
               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Blue Plane")

               ' Create Green Plane Window
               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Green Plane")

               ' Create Red Plane Window
               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Red Plane")

            ElseIf (sender Is _menuItemColorSeparationCMYK) Then

               CombineFloater()

               command.Type = ColorSeparateCommandType.Cmyk
               RunCommand(command)

               ' Create Cyan Plane Window
               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cyan Plane")

               ' Create Magenta Plane Window
               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Magenta Plane")

               ' Create Yellow Plane Window
               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Yellow Plane")

               ' Create Yellow Black Window
               command.DestinationImage.Page = 4
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Black Plane")

            ElseIf (sender Is _menuItemColorSeparationHSV) Then

               CombineFloater()

               command.Type = ColorSeparateCommandType.Hsv
               RunCommand(command)

               ' Create Hue Plane Window
               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Hue Plane")

               ' Create Saturation Plane Window
               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Saturation Plane")

               ' Create Value Plane Window
               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Value Plane")

            ElseIf (sender Is _menuItemColorSeparationHLS) Then

               CombineFloater()

               command.Type = ColorSeparateCommandType.Hls
               RunCommand(command)

               ' Create Hue Plane Window
               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Hue Plane")

               ' Create Lightness Plane Window
               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Lightness Plane")

               ' Create Saturation Plane Window
               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Saturation Plane")

            ElseIf (sender Is _menuItemColorSeparationCMY) Then

               CombineFloater()

               command.Type = ColorSeparateCommandType.Cmy
               RunCommand(command)

               ' Create Cyan Plane Window
               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cyan Plane")

               ' Create Magenta Plane Window
               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Magenta Plane")

               ' Create Yellow Plane Window
               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Yellow Plane")
            End If

         Catch ex As Exception

            Messager.ShowError(Me, ex)

         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemColorSeparationAlpha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemColorSeparationAlpha.Click
         CreateColorPlaneWindow(ActiveViewerForm.Image.CreateAlphaImage(), "Alpha")
      End Sub

      Private Sub CreateColorPlaneWindow(ByVal image As RasterImage, ByVal caption As String)

         Dim info As ImageInformation = New ImageInformation(image, caption)

         NewImage(info)
      End Sub

      Private Sub _menuItemPreferencesUseDpi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemPreferencesUseDpi.Click
         _menuItemPreferencesUseDpi.Checked = Not _menuItemPreferencesUseDpi.Checked
         For Each i As ViewerForm In MdiChildren
            i.Viewer.UseDpi = _menuItemPreferencesUseDpi.Checked
         Next i
         _useDpi = _menuItemPreferencesUseDpi.Checked
      End Sub

      Private Sub _menuItemImageBlankPageDetection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemImageBlankPageDetection.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim command As BlankPageDetectorCommand = New BlankPageDetectorCommand(BlankPageDetectorCommandFlags.UseAdvanced Or BlankPageDetectorCommandFlags.DetectNoisyPage Or BlankPageDetectorCommandFlags.UseBleedThrough, 0, 0, 0, 0)

            command.Run(activeForm.Image)
            MessageBox.Show(" Is Blank   : " & command.IsBlank & vbCrLf & " Accuracy : " & (command.Accuracy * 1.0 / 100) & "%", "Blank Page Detection Results")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

      End Sub

      Private Sub _menuItemFileWiaAcquire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileWiaAcquire.Click
         Dim wiaVersion As Integer
         Dim res As DialogResult

         Try
            Using WiaVersionDlg As WiaVersionForm = New WiaVersionForm()
               If WiaVersionDlg.ShowDialog() = DialogResult.OK Then
                  wiaVersion = WiaVersionDlg._selectedWiaVersion
               Else
                  Return
               End If
            End Using

            Using wait As WaitCursor = New WaitCursor()
               If WiaSession.IsAvailable(CType(wiaVersion, WiaVersion)) Then
                  _wiaSession = New WiaSession()
                  _wiaSession.Startup(CType(wiaVersion, WiaVersion))
                  AddHandler _wiaSession.AcquireEvent, AddressOf _wiaSession_AcquireEvent
               End If
            End Using

            If Not _wiaSession Is Nothing Then
               res = _wiaSession.SelectDeviceDlg(Me.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault)

               If res <> DialogResult.OK Then
                  Return
               End If
            End If

            _wiaAcquiring = True
            _acquirePageCount = 1
            UpdateControls()

            ' Disable the minimize and maximize buttons.
            Me.MinimizeBox = False
            Me.MaximizeBox = False

            If wiaVersion = Leadtools.Wia.WiaVersion.Version2 Then
               _wiaAcquireOptions.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\WiaTest"
               _wiaSession.AcquireOptions = _wiaAcquireOptions
            End If

            Me._mainMenu.Enabled = False

            _progressDlg = New ProgressForm("Transferring...", "", 100)
            _progressDlg.Show(Me)

            res = _wiaSession.Acquire(Me.Handle, Nothing, WiaAcquireFlags.ShowUserInterface Or WiaAcquireFlags.UseCommonUI)

            If res <> DialogResult.OK Then
               Return
            End If

            Me._mainMenu.Enabled = True

            ' Enable back the minimize and maximize buttons.
            Me.MinimizeBox = True
            Me.MaximizeBox = True

            If _progressDlg.Visible Then
               If (Not _progressDlg.Abort) Then
                  _progressDlg.Dispose()
               End If
            End If

            If wiaVersion = Leadtools.Wia.WiaVersion.Version2 Then
               If _wiaSession.FilesCount > 0 Then ' This property indicates how many files where saved when the transfer mode is File mode.
                  Dim strMsg As String = "Acquired page(s) were saved to:" & Chr(13) + Chr(13)
                  If _wiaSession.FilesPaths.Count > 0 Then
                     Dim i As Integer = 0
                     Do While i < _wiaSession.FilesPaths.Count
                        Dim strTemp As String = String.Format("{0}" & Chr(13), _wiaSession.FilesPaths(i))
                        strMsg &= strTemp
                        i += 1
                     Loop
                     MessageBox.Show(Me, strMsg, "File Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If
               Else
                  Dim strMsg As String = "Acquired page(s) were saved to:" & Chr(13) + Chr(13) + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                  MessageBox.Show(Me, strMsg, "File Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            End If

            _wiaAcquiring = False
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            Me._mainMenu.Enabled = True

            ' Enable back the minimize and maximize buttons.
            Me.MinimizeBox = True
            Me.MaximizeBox = True

            _wiaAcquiring = False

            If Not _progressDlg Is Nothing AndAlso _progressDlg.Visible Then
               If (Not _progressDlg.Abort) Then
                  _progressDlg.Dispose()
               End If
            End If

            _acquirePageCount = -1
            If Not _wiaSession Is Nothing Then
               _wiaSession.Shutdown()
            End If
         End Try

         UpdateControls()

      End Sub

      Private Sub _wiaSession_AcquireEvent(ByVal sender As Object, ByVal e As WiaAcquireEventArgs)
         ' Update the progress bar with the received percent value;
         If _progressDlg.Visible Then
            If ((e.Flags And WiaAcquiredPageFlags.StartOfPage) = WiaAcquiredPageFlags.StartOfPage) AndAlso ((e.Flags And WiaAcquiredPageFlags.EndOfPage) <> WiaAcquiredPageFlags.EndOfPage) Then
               _progressDlg.Percent = 0
            Else
               _progressDlg.Percent = e.Percent
            End If

            Application.DoEvents()

            If _progressDlg.Abort Then
               e.Cancel = True
            End If
         End If

         If Not e.Image Is Nothing Then
            If _acquirePageCount = 1 Then
               NewImage(New ImageInformation(e.Image, "WIA Image"))
            Else
               ActiveViewerForm.Image.AddPage(e.Image)
            End If

            _acquirePageCount += 1
            Application.DoEvents()
         End If
      End Sub

      Private Sub _menuItemColorAutoBinarize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemColorAutoBinarize.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim command As AutoBinarizeCommand = New AutoBinarizeCommand()

            RunCommand(command)

         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _menuItemPreferencesLoadCompressed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemPreferencesLoadCompressed.Click
         _menuItemPreferencesLoadCompressed.Checked = Not _menuItemPreferencesLoadCompressed.Checked
         _codecs.Options.Load.SuperCompressed = _menuItemPreferencesLoadCompressed.Checked
      End Sub

      Private Sub _menuItemPreferencesLoadMultithreaded_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemPreferencesLoadMultithreaded.Click
         _menuItemPreferencesLoadMultithreaded.Checked = Not _menuItemPreferencesLoadMultithreaded.Checked
         _codecs.Options.Jpeg.Load.Multithreaded = _menuItemPreferencesLoadMultithreaded.Checked
      End Sub

      Private Sub _menuItemImageColorType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemImageColorType.Click
         Dim colorType As ImageColorTypeCommand = New ImageColorTypeCommand(ImageColorTypeCommandFlags.None)
         Dim activeForm As ViewerForm = ActiveViewerForm
         colorType.Run(activeForm.Image)
         MessageBox.Show("Color Type = " + colorType.ColorType.ToString() + vbCrLf + "Confidence = " + colorType.Confidence.ToString() + "%", "Type of image")
      End Sub

      Private Sub _menuItemSupportVectorFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemSupportVectorFiles.Click
         _menuItemSupportVectorFiles.Checked = Not _menuItemSupportVectorFiles.Checked
         EnableLoadVectorFiles(_codecs, _menuItemSupportVectorFiles.Checked)
      End Sub


      Private Sub _menuItemColorAdjustTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuItemColorAdjustTemperature.Click
         Dim command As TemperatureCommand = Nothing

         Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Temperature)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            command = New TemperatureCommand(dlg.Value)
            RunCommand(command)
         End If

      End Sub

      Private Sub _menuItemLoadingCorruptedImages_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemLoadingCorruptedImages.Click
         _menuItemLoadingCorruptedImages.Checked = Not _menuItemLoadingCorruptedImages.Checked
         _codecs.Options.Load.LoadCorrupted = _menuItemLoadingCorruptedImages.Checked
      End Sub


      Private Sub _menuItemColorAdjust_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs)

         _menuItemColorAdjustTemperature.Enabled = True

      End Sub
      Private Sub kmeansToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationKmeans.Click
         Dim dlg As KMeansDialog = New KMeansDialog()
         If dlg.ShowDialog() = DialogResult.OK Then
            Dim command As KMeansCommand = New KMeansCommand(dlg.Clusters, dlg.Type, Nothing)
            RunCommand(command)
         End If
      End Sub

      Private Sub otsuToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationOtsu.Click

         Dim dlg As OtsuThresholdDialog = New OtsuThresholdDialog()

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim command As OtsuThresholdCommand = New OtsuThresholdCommand(dlg.Clusters)
            RunCommand(command)
         End If

      End Sub

      Private Sub lambdaConnectednessToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationLambda.Click

         Dim dlg As LambdaConnectednessDialog = New LambdaConnectednessDialog()
         If dlg.ShowDialog() = DialogResult.OK Then
            Dim command As LambdaConnectednessCommand = New LambdaConnectednessCommand(dlg.Lambda)
            RunCommand(command)
         End If

      End Sub

      Private Sub levelSetToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationLevelset.Click

         Dim command As LevelsetCommand = New LevelsetCommand()

         If Not ActiveViewerForm.Viewer.Floater Is Nothing Then
            Dim xForm As RasterRegionXForm = New RasterRegionXForm()

            Dim region As RasterRegion = ActiveViewerForm.Viewer.Floater.GetRegion(xForm)

            Dim floaterTransform As LeadMatrix = ActiveViewerForm.Viewer.FloaterTransform

            xForm.XOffset = CInt(floaterTransform.OffsetX)
            xForm.YOffset = CInt(floaterTransform.OffsetY)

            ActiveViewerForm.Viewer.Image.SetRegion(xForm, region, RasterRegionCombineMode.Set)
            ActiveViewerForm.Viewer.Invalidate()
            CancelFloater()
         End If

         Try
            command.Run(ActiveViewerForm.Viewer.Image)

            Dim test As ImageViewerItem = New ImageViewerItem()
            test.ImageRegionToFloater()
            ActiveViewerForm.Viewer.ActiveItem.ImageRegionToFloater()
            ActiveViewerForm.Viewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.Set)

            DisableAllInteractiveModes(ActiveViewerForm.Viewer)
            ActiveViewerForm.Viewer.InteractiveModes.BeginUpdate()
            ActiveViewerForm.FloaterInteractiveMode.IsEnabled = True
            ActiveViewerForm.Viewer.InteractiveModes.EndUpdate()
            ActiveViewerForm.Viewer.FloaterOpacity = 1.0
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

      End Sub

      Private Sub segmentationToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentation.Click

         Dim enable As Boolean = (Not ActiveViewerForm Is Nothing)
         Dim BitsPerPixel As Integer = ActiveViewerForm.Viewer.Image.BitsPerPixel
         Dim enable2 As Boolean = (enable) AndAlso ((BitsPerPixel = 8) OrElse (BitsPerPixel = 16) OrElse (BitsPerPixel = 24) OrElse (BitsPerPixel = 32))
         _menuItemSegmentationGWire.Enabled = enable
         _menuItemSegmentationKmeans.Enabled = enable
         _menuItemSegmentationShrinkWrap.Enabled = enable
         _menuItemSegmentationLevelset.Enabled = enable


         _menuItemSegmentationOtsu.Enabled = enable2
         _menuItemSegmentationLambda.Enabled = enable2
         _menuItemSegmentationSRAD.Enabled = enable2
         _menuItemSegmentationTAD.Enabled = enable2

         _menuItemSegmentationWatershed.Enabled = enable2

      End Sub

      Private Sub gWireToolToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationGWire.Click

         If _interactiveToolsList.ContainsKey(ActiveViewerForm.Viewer) Then
            Return
         End If

         Dim dlg As GWireDialog = New GWireDialog(ActiveViewerForm, Me)
         dlg.Show()

         _interactiveToolsList.Add(ActiveViewerForm.Viewer, dlg)

      End Sub



      Private Sub _menuItemSegmentationShrinkWrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationShrinkWrap.Click

         If _interactiveToolsList.ContainsKey(ActiveViewerForm.Viewer) Then
            Return
         End If

         Dim dlg As ShrinkWrapDialog = New ShrinkWrapDialog(Me, ActiveViewerForm)
         dlg.Show()

         _interactiveToolsList.Add(ActiveViewerForm.Viewer, dlg)

      End Sub

      Private Sub _menuItemSegmentationTAD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationTAD.Click

         Dim dlg As TADAnisotropicDialog = New TADAnisotropicDialog()

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim command As TADAnisotropicDiffusionCommand = New TADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, dlg.Kappa, dlg.Flux)
            RunCommand(command)
         End If

      End Sub

      Private Sub _menuItemSegmentationSRAD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationSRAD.Click

         Dim dlg As SRADAnisotropicDialog = New SRADAnisotropicDialog()

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim command As SRADAnisotropicDiffusionCommand = New SRADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, LeadRect.Create(10, 10, ActiveViewerForm.Viewer.Image.Width - 20, ActiveViewerForm.Viewer.Image.Height - 20))

            If Not ActiveViewerForm.Viewer.Floater Is Nothing Then
               Dim rect As LeadRect = LeadRect.Empty
               Dim boundRect As LeadRect = ActiveViewerForm.Viewer.Floater.GetRegionBoundsClipped(Nothing)
               Dim floaterTransform As LeadMatrix = ActiveViewerForm.Viewer.FloaterTransform
               Dim xOff As Integer = CInt(floaterTransform.OffsetX)
               Dim yOff As Integer = CInt(floaterTransform.OffsetY)

               rect.Top = boundRect.Top + yOff
               rect.Left = boundRect.Left + xOff
               rect.Right = boundRect.Right + xOff
               rect.Bottom = boundRect.Bottom + yOff

               CancelFloater()
               command.Rect = rect
            End If

            RunCommand(command)
         End If

      End Sub

      Private Sub _menuItemSegmentationWatershed_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSegmentationWatershed.Click
         If _interactiveToolsList.ContainsKey(ActiveViewerForm.Viewer) Then
            Return
         End If

         Dim dlg As WatershedDialog = New WatershedDialog(Me, ActiveViewerForm)

         dlg.Show()

         _interactiveToolsList.Add(ActiveViewerForm.Viewer, dlg)

      End Sub

      Private Sub _menuItemGlareDetection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemGlareDetection.Click

         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim command As GlareDetectionCommand = New GlareDetectionCommand()
         Try
            command.Run(activeForm.Image)
            If activeForm.Image.HasRegion Then
               Dim test As ImageViewerItem = New ImageViewerItem()
               test.ImageRegionToFloater()
               ActiveViewerForm.Viewer.ActiveItem.ImageRegionToFloater()
               ActiveViewerForm.Viewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.Set)

               DisableAllInteractiveModes(ActiveViewerForm.Viewer)
               ActiveViewerForm.Viewer.InteractiveModes.BeginUpdate()
               ActiveViewerForm.FloaterInteractiveMode.IsEnabled = True
               ActiveViewerForm.Viewer.InteractiveModes.EndUpdate()
               ActiveViewerForm.Viewer.FloaterOpacity = 0.5
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub _menuItemSignalToNoiseRatio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemSignalToNoiseRatio.Click

         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim command As SignalToNoiseRatioCommand = New SignalToNoiseRatioCommand()
         Try
            command.Run(activeForm.Image)
            MessageBox.Show("Result : " & command.SNR, "Signal to noise ratio")
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub _menuItemTextBlurDetector_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemTextBlurDetector.Click
         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim command As TextBlurDetectorCommand = New TextBlurDetectorCommand()
         Try
            command.Run(activeForm.Image)
            If Not command.InFocusBlocks Is Nothing AndAlso command.InFocusBlocks.Length >= 1 Then
               activeForm.Image.AddRectangleToRegion(Nothing, command.InFocusBlocks(0), RasterRegionCombineMode.Set)
               Dim i As Integer = 1
               Do While i < command.InFocusBlocks.Length
                  activeForm.Image.AddRectangleToRegion(Nothing, command.InFocusBlocks(i), RasterRegionCombineMode.Or)
                  i += 1
               Loop
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub _menuItemMICRDetection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemMICRDetection.Click
         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim tmpImage As RasterImage = New RasterImage(activeForm.Image)
         Dim command As MICRCodeDetectionCommand = New MICRCodeDetectionCommand()
         Try
            If bMICRRunMessage Then
               MessageBox.Show(Me, "This demo detects MICR and MRZ codes in the image.For full functionality, refer to the LEADTOOLS Forms Recognition Demos.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
               bMICRRunMessage = False
            End If
            command.Run(tmpImage)
            activeForm.Image.AddRectangleToRegion(Nothing, command.MICRZone, RasterRegionCombineMode.Set)
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub _menuItemMRZDetection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemMRZDetection.Click
         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim tmpImage As RasterImage = New RasterImage(activeForm.Image)
         Dim command As MRZCodeDetectionCommand = New MRZCodeDetectionCommand()
         Try
            If bMRZRunMessage Then
               MessageBox.Show(Me, "This demo detects MICR and MRZ codes in the image.For full functionality, refer to the LEADTOOLS Forms Recognition Demos.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
               bMRZRunMessage = False
            End If
            command.Run(tmpImage)
            activeForm.Image.AddRectangleToRegion(Nothing, command.MRZZone, RasterRegionCombineMode.Set)
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub


      Private Sub _menuItemColorBlurDetection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemColorBlurDetection.Click
         Dim command As BlurDetectionCommand = New BlurDetectionCommand()
         Dim image As RasterImage = ActiveViewerForm.Image
         Try
            command.Run(image)
            If command.Blurred Then
               MessageBox.Show(" Is Blurred   : True" & vbCrLf & " Blur Extent : " & command.BlurExtent, "Blur Detection Result")
            Else
               MessageBox.Show(" Is Blurred   : False", "Blur Detection Result")
            End If
         Catch ex As Exception
            MessageBox.Show("Error : " & vbCrLf + ex.Message)
         End Try
      End Sub

      Private Sub _menuItemPreferVector_Click(sender As Object, e As EventArgs) Handles _menuItemPreferVector.Click
         _menuItemPreferVector.Checked = Not _menuItemPreferVector.Checked
         _codecs.Options.Load.PreferVector = _menuItemPreferVector.Checked
      End Sub
   End Class
End Namespace
