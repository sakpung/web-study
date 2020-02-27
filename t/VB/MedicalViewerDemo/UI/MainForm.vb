' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text
Imports System.Threading
Imports System.Collections.Generic

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Dicom
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing
Imports Leadtools.MedicalViewer
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Annotations.Engine
Imports System
Imports Leadtools.Demos.Dialogs

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Annotations.Automation
#End If

Imports Leadtools.Annotations.WinForms


Namespace MedicalViewerDemo
   Public Delegate Sub MyFunctionDelegate(cell As MedicalViewerMultiCell, subCellIndex As Integer)

   Partial Public Class MainForm
      Inherits Form

      Public ReadOnly Property ManagerHelper() As AutomationManagerHelper
         Get
            Return _managerHelper
         End Get
      End Property

      Public Class StentData
         Public Sub New(stentCell As MedicalViewerMultiCell, avgImageCell As MedicalViewerMultiCell, enhImageCell As MedicalViewerMultiCell)
            _stentCell = stentCell
            _avgImageCell = avgImageCell
            _enhImageCell = enhImageCell
         End Sub

         Private _stentCell As MedicalViewerMultiCell
         Private _avgImageCell As MedicalViewerMultiCell
         Private _enhImageCell As MedicalViewerMultiCell
         Private _enhImageCellWLWidth As Integer
         Private _enhImageCellWLCenter As Integer

         Public ReadOnly Property StentCell() As MedicalViewerMultiCell
            Get
               Return _stentCell
            End Get
         End Property
         Public Property AvgImageCell() As MedicalViewerMultiCell
            Get
               Return _avgImageCell
            End Get
            Set(value As MedicalViewerMultiCell)
               _avgImageCell = value
            End Set
         End Property

         Public Property EnhImageCell() As MedicalViewerMultiCell
            Get
               Return _enhImageCell
            End Get
            Set(value As MedicalViewerMultiCell)
               _enhImageCell = value
            End Set
         End Property

         Public Property EnhImageCellWLWidth() As Integer
            Get
               Return _enhImageCellWLWidth
            End Get
            Set(value As Integer)
               _enhImageCellWLWidth = value
            End Set
         End Property

         Public Property EnhImageCellWLCenter() As Integer
            Get
               Return _enhImageCellWLCenter
            End Get
            Set(value As Integer)
               _enhImageCellWLCenter = value
            End Set
         End Property
      End Class

      Private _stentCell As MedicalViewerMultiCell
      Private _avgImageCell As MedicalViewerMultiCell
      Private _enhImageCell As MedicalViewerMultiCell
      Private _stentCommand As StentEnhancementCommand
      Private _stentDialog As StentEnhancementDialog
      Private _stentDataList As List(Of StentData)
      Private _stentRegion As LeadRect
      Private markerIndex As Integer
      Private _keyStentFrame As Integer
      Private _dialogDisplaced As Boolean
      Private _frameEnabled As Boolean()
      Private _openInitialPath As String = String.Empty

      Public ReadOnly Property StentCommand() As StentEnhancementCommand
         Get
            Return _stentCommand
         End Get
      End Property

      Public ReadOnly Property FrameEnabled() As Boolean()
         Get
            Return _frameEnabled
         End Get
      End Property


      Private Shared _orignalImagesList As List(Of RasterImage())
      Public ReadOnly Property OrignalImagesList() As List(Of RasterImage())
         Get
            Return _orignalImagesList
         End Get
      End Property



      Private _templateList As List(Of LeadPoint)
      Private _referenceList As List(Of LeadPoint)

      Private _referenceCell As MedicalViewerMultiCell
      Private _templateCell As MedicalViewerMultiCell
      Private _refPointAdded As Boolean
      Private _alignPointIdx As Integer

      Private _alignmentDlg As ImageAlignmentDialog
      Private _registeredImageCell As MedicalViewerMultiCell

      Public Property TemplateList() As List(Of LeadPoint)
         Get
            Return _templateList
         End Get
         Set(value As List(Of LeadPoint))
            _templateList = value
         End Set
      End Property

      Public Property ReferenceList() As List(Of LeadPoint)
         Get
            Return _referenceList
         End Get
         Set(value As List(Of LeadPoint))
            _referenceList = value
         End Set
      End Property



      Public StentEnhancementActive As Boolean
      Public UnselectFrameActive As Boolean
      Public ModifyStentActive As Boolean

      Public _modifyStentDlg As ModifyStent

      Private _images As Integer
      Private _cellIndex As Integer
      Private _medicalViewer As MedicalViewer
      Private _applyToAll As Boolean
      Private _printDocument As PrintDocument
      Private _printImage As RasterImage

      Private _currentAction As MedicalViewerActionType

      Private Shared _leftButtonAction As MedicalViewerActionType
      Private Shared _rightButtonAction As MedicalViewerActionType

      Public Property LeftButtonAction() As MedicalViewerActionType
         Get
            Return _leftButtonAction
         End Get
         Set(value As MedicalViewerActionType)
            _leftButtonAction = value
         End Set
      End Property

      Public Property RightButtonAction() As MedicalViewerActionType
         Get
            Return _rightButtonAction
         End Get
         Set(value As MedicalViewerActionType)
            _rightButtonAction = value
         End Set
      End Property

      Public Property CurrentAction() As MedicalViewerActionType

         Get
            Return _currentAction
         End Get

         Set(value As MedicalViewerActionType)
            _currentAction = value
         End Set
      End Property

      Public ReadOnly Property PrintDocument() As PrintDocument
         Get
            Return _printDocument
         End Get
      End Property


      Public Property PrintImage() As RasterImage
         Get
            Return _printImage
         End Get
         Set(value As RasterImage)
            _printImage = value
         End Set
      End Property

      Public Shared _defaultCell As MedicalViewerMultiCell



      <STAThread()> _
      Shared Sub Main()

         
         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Medical) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning")
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.EnableVisualStyles()
         Application.DoEvents()
         Application.Run(New MainForm())
      End Sub



      Public Sub New()
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         InitClass()
         AddHandler _medicalViewer.DeleteCell, AddressOf _medicalViewer_DeleteCell
         _stentMenuItem.Enabled = True
         _stentMenuItem.Visible = True
         _filtersMenuItem.Enabled = True


         _filtersMenuItem.Visible = True
      End Sub

      Private Sub Cells_ItemAdded(sender As Object, e As MedicalViewerCollectionEventArgs(Of MedicalViewerBaseCell))

         If CType(e.Item, MedicalViewerCell).Image IsNot Nothing Then
            Dim imageCount As Integer = CType(e.Item, MedicalViewerCell).Image.PageCount
            _orignalImagesList.Add(New RasterImage(imageCount - 1) {})
         Else
            _orignalImagesList.Add(Nothing)
         End If

      End Sub

#If LEADTOOLS_V19_OR_LATER Then
      Private _automationManager As AnnAutomationManager
      Private _managerHelper As AutomationManagerHelper
      Private Sub InitAutomation(cell As MedicalViewerCell)
         If _managerHelper Is Nothing Then
            _automationManager = CType(_medicalViewer.Cells(0), MedicalViewerMultiCell).AutomationManager
            'new AnnAutomationManager();
            _automationManager.RedactionRealizePassword = String.Empty
            _managerHelper = New AutomationManagerHelper(_automationManager)



            Dim annNoteObjectRenderer As IAnnObjectRenderer = _automationManager.RenderingEngine.Renderers(AnnObject.NoteObjectId)


            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextUnderlineObjectId)
            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextStrikeoutObjectId)
            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextHiliteObjectId)
            _managerHelper.IgnoredObjectsList.Add(AnnObject.TextRedactionObjectId)
            _managerHelper.IgnoredObjectsList.Add(AnnObject.StickyNoteObjectId)

            _managerHelper.CreateToolBar()
            Controls.Add(_managerHelper.ToolBar)

            _managerHelper.ToolBar.Dock = DockStyle.Right
            _managerHelper.ToolBar.BringToFront()
            _managerHelper.ToolBar.AutoSize = True
            _managerHelper.ToolBar.Appearance = ToolBarAppearance.Flat
            AddHandler _managerHelper.ToolBar.ButtonClick, AddressOf ToolBar_ButtonClick
            AddHandler _managerHelper.ToolBar.ButtonDropDown, AddressOf ToolBar_ButtonClick

            UnpushAllAnnotationIcons()

            MainForm_Resize(Me, EventArgs.Empty)
         Else

            Dim automationManager As AnnAutomationManager = cell.AutomationManager
            Dim helpers As New AutomationManagerHelper(automationManager)
         End If
      End Sub

      Private _currentToolbarButton As ToolBarButton = Nothing



      Private Sub UnpushAllAnnotationIcons()
         For Each button As ToolBarButton In _managerHelper.ToolBar.Buttons
            button.Pushed = False
         Next button
      End Sub

      Public Function GetAnnotationActionId(annotationObjectId As Integer) As MedicalViewerActionType
         Select Case annotationObjectId
            Case AnnObject.SelectObjectId
               Return MedicalViewerActionType.None
            Case AnnObject.RulerObjectId
               Return MedicalViewerActionType.AnnotationRuler
            Case AnnObject.ProtractorObjectId
               Return MedicalViewerActionType.AnnotationAngle
            Case AnnObject.TextObjectId
               Return MedicalViewerActionType.AnnotationText
            Case AnnObject.PointerObjectId
               Return MedicalViewerActionType.AnnotationArrow
            Case AnnObject.RectangleObjectId
               Return MedicalViewerActionType.AnnotationRectangle
            Case AnnObject.EllipseObjectId
               Return MedicalViewerActionType.AnnotationEllipse
            Case AnnObject.HiliteObjectId
               Return MedicalViewerActionType.AnnotationHilite
            Case AnnObject.LineObjectId
               Return MedicalViewerActionType.AnnotationLine
            Case AnnObject.PolylineObjectId
               Return MedicalViewerActionType.AnnotationPolyline
            Case AnnObject.PolygonObjectId
               Return MedicalViewerActionType.AnnotationPolygon
            Case AnnObject.CurveObjectId
               Return MedicalViewerActionType.AnnotationCurve
            Case AnnObject.ClosedCurveObjectId
               Return MedicalViewerActionType.AnnotationClosedCurve
            Case AnnObject.TextPointerObjectId
               Return MedicalViewerActionType.AnnotationTextPointer
            Case AnnObject.FreehandObjectId
               Return MedicalViewerActionType.AnnotationFreeHand
            Case AnnObject.TextRollupObjectId
               Return MedicalViewerActionType.AnnotationTextRollup
            Case AnnObject.NoteObjectId
               Return MedicalViewerActionType.AnnotationNote
            Case AnnObject.RubberStampObjectId
               Return MedicalViewerActionType.AnnotationRubberStamp
            Case AnnObject.StampObjectId
               Return MedicalViewerActionType.AnnotationStamp
            Case AnnObject.HotspotObjectId
               Return MedicalViewerActionType.AnnotationHotSpot
            Case AnnObject.FreehandHotspotObjectId
               Return MedicalViewerActionType.AnnotationFreeHandHotSpot
            Case AnnObject.ButtonObjectId
               Return MedicalViewerActionType.AnnotationButton
            Case AnnObject.PointObjectId
               Return MedicalViewerActionType.AnnotationPoint
            Case AnnObject.PolyRulerObjectId
               Return MedicalViewerActionType.AnnotationPolyRuler
            Case AnnObject.CrossProductObjectId
               Return MedicalViewerActionType.AnnotationCrossProduct
            Case AnnObject.RedactionObjectId
               Return MedicalViewerActionType.AnnotationRedaction
            Case AnnObject.EncryptObjectId
               Return MedicalViewerActionType.AnnotationEncrypt
            Case AnnObject.AudioObjectId
               Return MedicalViewerActionType.AnnotationAudio
            Case AnnObject.MediaObjectId
               Return MedicalViewerActionType.AnnotationMedia
            Case Else
               Return MedicalViewerActionType.None
         End Select
      End Function
      Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs)
         _currentToolbarButton = e.Button
         Dim annotationType As MedicalViewerActionType = GetAnnotationActionId(CInt(e.Button.Tag))

         SetAction(annotationType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
      End Sub
#End If

      Private Sub InitClass()
         _alignmentMenuItem.Visible = False
#If LEADTOOLS_V19_OR_LATER Then
         _alignmentMenuItem.Visible = True
#End If
         _stentDataList = New List(Of StentData)()


         _orignalImagesList = New List(Of RasterImage())()

         Try

            If PrinterSettings.InstalledPrinters IsNot Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
               _printDocument = New PrintDocument()
               AddHandler _printDocument.BeginPrint, New PrintEventHandler(AddressOf _printDocument_BeginPrint)
               AddHandler _printDocument.PrintPage, New PrintPageEventHandler(AddressOf _printDocument_PrintPage)
               AddHandler _printDocument.EndPrint, New PrintEventHandler(AddressOf _printDocument_EndPrint)
            Else
               _printDocument = Nothing
            End If
         Catch generatedExceptionName As Exception
            _printDocument = Nothing
         End Try

         Try
            DicomEngine.Startup()

            Using codecs As New RasterCodecs()
               Dim _image As RasterImage
               _applyToAll = False

               _medicalViewer = New MedicalViewer(1, 2)
               _medicalViewer.Location = New Point(0, 0)
               _medicalViewer.Size = New Size(Me.ClientRectangle.Right, Me.ClientRectangle.Bottom)
               AddHandler _medicalViewer.Cells.ItemAdded, AddressOf Cells_ItemAdded

               _mainPanel.Controls.Add(_medicalViewer)

               Dim defaultDialog As New DefaultImagesDialog()


               If defaultDialog.ShowDialog() = DialogResult.Yes Then
                  Dim imagesFolder As String
#If LT_CLICKONCE Then
						imagesFolder = Application.StartupPath
#Else
                  imagesFolder = DemosGlobal.ImagesFolder
#End If

                  Dim fileName As String = Path.Combine(imagesFolder, "xa.dcm")
                  If File.Exists(fileName) Then
                     Dim imageInformations As SeriesInformation = LoadSeries(fileName)
                     _image = imageInformations.Image

                     If _image IsNot Nothing Then
                        Dim cell As New MedicalViewerMultiCell(_image, False, 1, 1)
                        _medicalViewer.Cells.Add(cell)

                        cell.Image = _image
                        cell.ApplyActionOnMove = True

                        cell.SetScaleMode(MedicalViewerScaleMode.Fit)

                        SetCellTags(cell, imageInformations)

                        InitializeCell(cell)
                        InitAutomation(cell)
                        InitializeAutomationManager(cell)

                        InitializeEvents(cell)
                     End If
                  End If

                  fileName = Path.Combine(imagesFolder, "mr.dcm")

                  If File.Exists(fileName) Then
                     Dim imageInformations As SeriesInformation = LoadSeries(fileName)
                     _image = imageInformations.Image

                     If _image IsNot Nothing Then
                        Dim cell As New MedicalViewerMultiCell(_image, True, 1, 1)
                        _medicalViewer.Cells.Add(cell)

                        cell.Image = _image
                        cell.FitImageToCell = True

                        SetCellTags(cell, imageInformations)

                        cell.Rows = 2
                        cell.Columns = 2
                        cell.ApplyActionOnMove = True
                        InitializeCell(cell)
                        InitAutomation(cell)
                        InitializeAutomationManager(cell)
                        InitializeEvents(cell)
                     End If

                  End If
               End If
            End Using
         Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source)
         End Try
      End Sub

      Private Sub _medicalViewer_DeleteCell(sender As Object, e As MedicalViewerDeleteEventArgs)
         Dim i As Integer = 0
         For i = e.CellIndexes.Length - 1 To 0 Step -1

            Dim cell As MedicalViewerMultiCell = CType(_medicalViewer.Cells(e.CellIndexes(i)), MedicalViewerMultiCell)

            If cell.Equals(_enhImageCell) Then
               _enhImageCell = Nothing
            ElseIf cell.Equals(_avgImageCell) Then
               _avgImageCell = Nothing
            End If

            If _orignalImagesList(e.CellIndexes(i)) IsNot Nothing Then
               For Each image As RasterImage In _orignalImagesList(e.CellIndexes(i))
                  If image IsNot Nothing Then
                     image.Dispose()
                  End If
               Next
            End If

            _orignalImagesList.RemoveAt(e.CellIndexes(i))
         Next
      End Sub

      Private Sub InitializeEvents(cell As MedicalViewerMultiCell)
#If LEADTOOLS_V19_OR_LATER Then
         AddHandler cell.Automation.Draw, AddressOf Automation_Draw
         cell.KeepDrawingAnnotation = True
#End If
         AddHandler cell.SpyGlassStarted, AddressOf cell_SpyGlassStarted
         AddHandler cell.AnnotationCreated, AddressOf cell_AnnotationCreated
         AddHandler cell.DeleteAnnotation, AddressOf cell_DeleteAnnotation
         AddProbeToolEvents(cell)

      End Sub

      Private Sub cell_DeleteAnnotation(sender As Object, e As MedicalViewerDeleteEventArgs)
         CType(sender, MedicalViewerMultiCell).RefreshAnnotation()
      End Sub

      Private Sub InitializeAutomationManager(cell As MedicalViewerMultiCell)
         Dim automation As AnnAutomation = cell.Automation
         AddHandler automation.OnShowContextMenu, AddressOf automation_OnShowContextMenu
      End Sub

      Private Shared Sub InitializeCell(cell As MedicalViewerCell)
         cell.InteractiveInterpolation = True

         Dim enums As Array = [Enum].GetValues(GetType(MedicalViewerActionType))

         For Each action As MedicalViewerActionType In enums
            If action <> MedicalViewerActionType.None Then
               If cell.CanExecuteAction(action) Then
                  cell.AddAction(action)
               End If
            End If
         Next

         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)
         _leftButtonAction = MedicalViewerActionType.WindowLevel
         _rightButtonAction = MedicalViewerActionType.Offset

         Dim medicalKeys As New MedicalViewerKeys()
         medicalKeys.MouseDown = Keys.Down
         medicalKeys.MouseUp = Keys.Up
         medicalKeys.MouseLeft = Keys.Left
         medicalKeys.MouseRight = Keys.Right
         cell.SetActionKeys(MedicalViewerActionType.Offset, medicalKeys)
         medicalKeys.Modifiers = MedicalViewerModifiers.Ctrl
         cell.SetActionKeys(MedicalViewerActionType.WindowLevel, medicalKeys)
         medicalKeys.Modifiers = MedicalViewerModifiers.None
         medicalKeys.MouseDown = Keys.PageDown
         medicalKeys.MouseUp = Keys.PageUp
         cell.SetActionKeys(MedicalViewerActionType.Stack, medicalKeys)
         medicalKeys.MouseDown = Keys.Add
         medicalKeys.MouseUp = Keys.Subtract
         cell.SetActionKeys(MedicalViewerActionType.Scale, medicalKeys)

         Dim windowLevel As MedicalViewerWindowLevel = CType(cell.GetActionProperties(MedicalViewerActionType.WindowLevel), MedicalViewerWindowLevel)
         windowLevel.RelativeSensitivity = True
         cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel)
         cell.AlwaysInterpolate = True
         cell.CellBackColor = Color.Black

      End Sub


      Private Sub cell_SpyGlassStarted(sender As Object, e As MedicalViewerSpyGlassStartedEventArgs)
         Dim medicalViewer As MedicalViewer = Me.Viewer

         Dim image As RasterImage = e.Image

         If image.UseLookupTable Then
            Dim colors As RasterColor16() = image.GetLookupTable16()
            Dim length As Integer = colors.Length
            Dim counter As Integer

            For counter = 0 To length - 1
               colors(counter).R = CUShort(colors(counter).R Xor &HFFFF)
               colors(counter).G = CUShort(colors(counter).G Xor &HFFFF)
               colors(counter).B = CUShort(colors(counter).B Xor &HFFFF)
            Next

            image.SetLookupTable16(colors)
         Else
            Dim colors As RasterColor() = image.GetPalette()
            If colors Is Nothing Then
               If image.HasRegion Then
                  image.MakeRegionEmpty()
               End If
               Dim invert As New InvertCommand()
               invert.Run(image)
            Else
               Dim length As Integer = colors.Length
               Dim counter As Integer

               For counter = 0 To length - 1
                  colors(counter).R = CByte(colors(counter).R Xor &HFF)
                  colors(counter).G = CByte(colors(counter).G Xor &HFF)
                  colors(counter).B = CByte(colors(counter).B Xor &HFF)
               Next

               image.SetPalette(colors, 0, length)
            End If
         End If
      End Sub

      Private Sub _printDocument_BeginPrint(sender As Object, e As PrintEventArgs)
         ' This demo only prints one page at a time, so there is no need to re-start the print page number
      End Sub

      Private Sub _printDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
         Dim colorResolutionCommand As New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, Nothing)
         colorResolutionCommand.Run(PrintImage)

         ' Get the print document object
         Dim document As PrintDocument = TryCast(sender, PrintDocument)

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
         printer.Print(PrintImage, PrintImage.Page, e)

         ' Inform the printer we have no more pages to print
         e.HasMorePages = False
      End Sub

      Private Sub _printDocument_EndPrint(sender As Object, e As PrintEventArgs)
         ' Nothing to do here
      End Sub

      Public Property ApplyToAll() As Boolean
         Get
            Return _applyToAll
         End Get
         Set(value As Boolean)
            _applyToAll = value
         End Set
      End Property

      Public Property CellIndex() As Integer
         Get
            Return _cellIndex
         End Get
         Set(value As Integer)
            _cellIndex = value
         End Set
      End Property

      Public Property Images() As Integer
         Get
            Return _images
         End Get

         Set(value As Integer)
            _images = value
         End Set
      End Property

      Public ReadOnly Property Viewer() As MedicalViewer
         Get
            Return _medicalViewer
         End Get
      End Property

      Public Sub RemoveSelectedCells()
         Dim currentCellIndex As Integer = 0
         While currentCellIndex < Viewer.Cells.Count
            Dim cell As MedicalViewerMultiCell = CType(Viewer.Cells(currentCellIndex), MedicalViewerMultiCell)
            If cell.Selected Then
               Viewer.Cells.RemoveAt(currentCellIndex)
               cell.Dispose()
            Else
               currentCellIndex += 1
            End If
         End While
      End Sub

      Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
         Dim toolbar As Integer = 0

         If _managerHelper IsNot Nothing Then
            If _managerHelper.ToolBar IsNot Nothing Then
               toolbar = _managerHelper.ToolBar.Width
            End If
         End If

         If _medicalViewer IsNot Nothing Then
            _medicalViewer.Size = New Size(_mainPanel.ClientRectangle.Right - toolbar, _mainPanel.ClientRectangle.Bottom)
         End If
      End Sub

      Private Sub _miEditRemoveSelectedCells_Click(sender As Object, e As EventArgs) Handles _miEditRemoveSelectedCells.Click
         RemoveSelectedCells()
      End Sub

      Private Sub _miEditSelectAll_Click(sender As Object, e As EventArgs) Handles _miEditSelectAll.Click
         If _medicalViewer IsNot Nothing Then
            _medicalViewer.Cells.SelectAll(True)
         End If
      End Sub

      Private Sub _miEditDeselectAll_Click(sender As Object, e As EventArgs) Handles _miEditDeselectAll.Click
         If _medicalViewer IsNot Nothing Then
            _medicalViewer.Cells.SelectAll(False)
         End If
      End Sub

      Private Sub _miEditInvertSelection_Click(sender As Object, e As EventArgs) Handles _miEditInvertSelection.Click
         If _medicalViewer IsNot Nothing Then
            _medicalViewer.Cells.InvertSelection()
         End If
      End Sub


      Private Sub ShowModlessDialog(show As Boolean)

         If _stentDialog IsNot Nothing Then
            _stentDialog.Visible = show
         End If

         If _modifyStentDlg IsNot Nothing Then
            _modifyStentDlg.Visible = show
         End If

         If _alignmentDlg IsNot Nothing Then
            _alignmentDlg.Visible = show
         End If

      End Sub

      Private Function ShowViewerDialogs(Dialog As Form) As DialogResult
         Dim dialogResult As DialogResult

         ShowModlessDialog(False)

         dialogResult = Dialog.ShowDialog(Me)

         ShowModlessDialog(True)

         Return dialogResult
      End Function

      Public Function GetCellIndex(cell As MedicalViewerCell) As Integer
         Return _medicalViewer.Cells.IndexOf(cell)
      End Function

      ' This method returns the specified DICOM tag in a string format.
      Private Function GetDicomTag(ds As DicomDataSet, tag As Long) As String
         Dim patientElement As DicomElement = ds.FindFirstElement(Nothing, tag, True)

         If patientElement IsNot Nothing Then
            Return ds.GetConvertValue(patientElement)
         End If

         Return Nothing
      End Function


      ' Open "LEAD Open File Dialog" and return the selected image
      Private Function LoadSeries(imagePath As String) As SeriesInformation
         Dim loader As ImageFileLoader = Nothing
         Dim firstPage As Integer = 1
         Dim lastPage As Integer = -1

         Try
            If String.IsNullOrEmpty(imagePath) Then
               loader = New ImageFileLoader()
               loader.ShowLoadPagesDialog = True

               Using codecs As New RasterCodecs()
                  If loader.Load(Me, codecs, False) > 0 Then
                     imagePath = loader.FileName
                     firstPage = loader.FirstPage
                     lastPage = loader.LastPage
                  End If
               End Using
            End If


            Return LoadDICOM(imagePath, firstPage, lastPage)
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try

         Return Nothing
      End Function

      Private Function GetImage(dicomDataSet As DicomDataSet, imagePath As String, firstPage As Integer, lastPage As Integer) As RasterImage
         _images = 1
         Dim counter As New CounterDialog(Me, Nothing)
         counter.Show(Me)
         counter.Update()

         Try
            Dim iconsCount As Integer = 0

            dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None)

            If lastPage = -1 Then
               lastPage = dicomDataSet.GetImageCount(Nothing)
            End If

            If dicomDataSet.GetImageCount(Nothing) = 0 Then
               If counter.Visible Then
                  counter.Close()
               End If
               Return GetRasterImage(imagePath, firstPage, lastPage)
            End If

            Dim imageSeqElement As DicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.IconImageSequence, True)

            If imageSeqElement IsNot Nothing Then
               Dim item As DicomElement = dicomDataSet.GetChildElement(imageSeqElement, True)

               Dim itemChild As DicomElement = dicomDataSet.GetChildElement(item, True)

               Dim pixelDataElement As DicomElement = dicomDataSet.FindFirstElement(itemChild, DicomTag.PixelData, True)

               iconsCount = dicomDataSet.GetImageCount(pixelDataElement)
            End If

#If Not LEADTOOLS_V20_OR_LATER Then
            Dim getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDectectInvalidRleCompression
#Else
            Dim getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDetectInvalidRleCompression
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

            Dim image As RasterImage = dicomDataSet.GetImage(Nothing, firstPage - 1 + iconsCount, 0, RasterByteOrder.Gray, getImageFlags)

            counter.UpdateCounterPercent(firstPage, lastPage - firstPage + 1, True)
            Application.DoEvents()

            For i As Integer = firstPage + iconsCount To lastPage - firstPage + iconsCount
               image.AddPage(dicomDataSet.GetImage(Nothing, i, 0, RasterByteOrder.Gray, getImageFlags))
               counter.UpdateCounterPercent(i + iconsCount + 1, lastPage - firstPage + 1, True)
               Application.DoEvents()
            Next


            Return image
         Catch generatedExceptionName As Exception
            If counter.Visible Then
               counter.Close()
            End If

            Return GetRasterImage(imagePath, firstPage, lastPage)
         End Try
      End Function

      Private Function GetRasterImage(imagePath As String, firstPage As Integer, lastPage As Integer) As RasterImage
         Using codecs As New RasterCodecs()
            Dim image As RasterImage = Nothing
            _images = 1
            Dim counter As New CounterDialog(Me, codecs)
            counter.Show(Me)
            counter.Update()

            Try
               image = codecs.Load(imagePath, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, firstPage, lastPage)
            Catch generatedExceptionName As Exception
               If counter.Visible Then
                  counter.Close()
               End If
            End Try

            Return image
         End Using
      End Function
      ' Load the DICOM file
      Private Function LoadDICOM(imagePath As String, firstPage As Integer, lastPage As Integer) As SeriesInformation
         Try
            Dim imageInformation As New SeriesInformation()


            Dim dicomDataSet As New DicomDataSet()

            imageInformation.Image = GetImage(dicomDataSet, imagePath, firstPage, lastPage)
            If imageInformation.Image Is Nothing Then
               dicomDataSet.Dispose()
               Return Nothing
            End If

            Dim orientation As Double()
            Dim doubleArray As Double()

            Dim patientElement As DicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.PixelSpacing, True)

            If patientElement IsNot Nothing Then
               doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 1)
               imageInformation.VoxelSpacing = New Point3D(CSng(doubleArray(0)), CSng(doubleArray(0)), 0)
            End If

            patientElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.ImageOrientationPatient, True)

            If patientElement IsNot Nothing Then
               orientation = dicomDataSet.GetDoubleValue(patientElement, 0, 6)
               imageInformation.ImageOrientation = orientation
            End If

            patientElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.ImagePositionPatient, True)

            If patientElement IsNot Nothing Then
               doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 3)
               imageInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray)
            End If

            patientElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.FrameOfReferenceUID, True)

            If patientElement IsNot Nothing Then
               Dim str As String = dicomDataSet.GetConvertValue(patientElement)
               imageInformation.FrameOfReferenceUID = str
            End If


            imageInformation.InstitutionName = GetDicomTag(dicomDataSet, DicomTag.InstitutionName)
            imageInformation.PatientName = GetDicomTag(dicomDataSet, DicomTag.PatientName)
            imageInformation.PatientAge = GetDicomTag(dicomDataSet, DicomTag.PatientAge)
            imageInformation.PatientBirthDate = GetDicomTag(dicomDataSet, DicomTag.PatientBirthDate)
            imageInformation.PatientSex = GetDicomTag(dicomDataSet, DicomTag.PatientSex)
            imageInformation.PatientID = GetDicomTag(dicomDataSet, DicomTag.PatientID)
            imageInformation.AccessionNumber = GetDicomTag(dicomDataSet, DicomTag.AccessionNumber)
            imageInformation.StudyDate = GetDicomTag(dicomDataSet, DicomTag.StudyDate)
            imageInformation.AcquisitionTime = GetDicomTag(dicomDataSet, DicomTag.AcquisitionTime)
            imageInformation.SeriesTime = GetDicomTag(dicomDataSet, DicomTag.SeriesTime)
            imageInformation.StationName = GetDicomTag(dicomDataSet, DicomTag.StationName)
            imageInformation.StudyID = GetDicomTag(dicomDataSet, DicomTag.StudyID)
            imageInformation.StudyDescription = GetDicomTag(dicomDataSet, DicomTag.StudyDescription)
            imageInformation.SeriesDescription = GetDicomTag(dicomDataSet, DicomTag.SeriesDescription)
            imageInformation.SeriesNumber = GetDicomTag(dicomDataSet, DicomTag.SeriesNumber)
            imageInformation.ImageComments = GetDicomTag(dicomDataSet, DicomTag.ImageComments)
            imageInformation.PhotometricInterpretation = GetDicomTag(dicomDataSet, DicomTag.PhotometricInterpretation)

            Return imageInformation
         Catch ex As System.Exception
            Messager.Show(Me, ex, MessageBoxIcon.Exclamation)
         End Try

         Return Nothing
      End Function


      Private Sub GetFileName(ByRef fileName As String)
         Dim codecs As New RasterCodecs()
         Dim loader As New ImageFileLoader()
         fileName = ""

         loader.OpenDialogInitialPath = _openInitialPath

         Try
            loader.ShowLoadPagesDialog = False
            If loader.Load(Me, codecs, False) <> 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               fileName = ""
               If loader.LastPage <> 0 Then
                  fileName = loader.FileName

                  If fileName.IndexOf("DICOMDIR") <> -1 Then
                     MessageBox.Show("You cannot load the DICOMDIR from here, use Load DICOMDIR instead", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     fileName = ""
                  End If
               End If
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try
      End Sub

      Private Sub _fileMenuItem_insertCell_Click(sender As Object, e As EventArgs) Handles _fileMenuItem_insertCell.Click
         Try
            If ShowViewerDialogs(New InsertCellDialog(Me)) = DialogResult.OK Then
               Dim medicalViewer As MedicalViewer = Me.Viewer
               Dim imageInformation As SeriesInformation = LoadSeries(Nothing)

               If imageInformation Is Nothing Then
                  Return
               End If

               Dim image As RasterImage = imageInformation.Image

               ' Insert new cell if the user has selected an image.
               If image IsNot Nothing Then
                  Dim cell As New MedicalViewerMultiCell(image, False, 1, 1)

                  If Not String.IsNullOrEmpty(imageInformation.PhotometricInterpretation) Then
                     cell.PhotometricInterpretation = imageInformation.PhotometricInterpretation
                  End If

                  Dim index As Integer
                  If CellIndex <> -1 Then
                     index = CellIndex
                     medicalViewer.Cells.Insert(index, cell)
                  Else
                     index = medicalViewer.Cells.Count
                     medicalViewer.Cells.Add(cell)
                  End If
                  cell.Image = image
                  cell.SetScaleMode(MedicalViewerScaleMode.Fit)

                  SetCellTags(cell, imageInformation)

                  InitializeCell(cell)
                  InitAutomation(cell)
                  InitializeAutomationManager(cell)

                  InitializeEvents(cell)
                  CopyPropertiesFromGlobalCell(cell)

                  ApplyToCell(cell)
                  MainForm_Resize(Me, EventArgs.Empty)
               End If
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub SetCellTags(cell As MedicalViewerCell, imageInformation As SeriesInformation)
         cell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.TopOrientation)


         cell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Frame)

         cell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, [String].Format("Acc#: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.AccessionNumber), imageInformation.AccessionNumber, "AccessionNumber"))))

         cell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, [String].Format("Study Date: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.StudyDate), imageInformation.StudyDate, "StudyDate"))))

         cell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, [String].Format("Study: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.StudyDescription), imageInformation.StudyDescription, "StudyDescription"))))

         cell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, [String].Format("Series: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.SeriesDescription), imageInformation.SeriesDescription, "SeriesDescription"))))

         cell.SetTag(5, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, [String].Format("Se#: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.SeriesNumber), imageInformation.SeriesNumber, "SeriesNumber"))))


         cell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.LeftOrientation)
         cell.SetTag(0, MedicalViewerTagAlignment.RightCenter, MedicalViewerTagType.RightOrientation)

         If imageInformation.Image.GrayscaleMode <> RasterGrayscaleMode.None Then
            cell.SetTag(1, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.WindowLevelData)
         End If


         cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, [String].Format("Name: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.PatientName), imageInformation.PatientName, "PatientName"))))

         cell.SetTag(1, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, [String].Format("PID: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.PatientID), imageInformation.PatientID, "PatientID"))))

         cell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, [String].Format("Sex: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.PatientSex), imageInformation.PatientSex, "PatientSex"))))

         cell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, [String].Format("DOB: {0}", (If(Not [String].IsNullOrEmpty(imageInformation.PatientBirthDate), imageInformation.PatientBirthDate, "PatientBirthDate"))))

         cell.SetTag(0, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.RulerUnit)
         cell.SetTag(1, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.Scale)

         cell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, MedicalViewerTagType.BottomOrientation)
      End Sub

      Private Sub _fileMenuItem_exit_Click(sender As Object, e As EventArgs) Handles _fileMenuItem_exit.Click
         Me.Close()
      End Sub

      Private Sub _miEditFreezeCell_Click(sender As Object, e As EventArgs) Handles _miEditFreezeCell.Click
         ShowViewerDialogs(New FreezeCellDialog(Me))
      End Sub

      Private Sub _miEditToggleFreeze_Click(sender As Object, e As EventArgs) Handles _miEditToggleFreeze.Click
         If _medicalViewer IsNot Nothing Then
            For Each cell As MedicalViewerCell In _medicalViewer.Cells
               If cell.Selected Then
                  cell.Frozen = Not cell.Frozen
               End If
            Next
         End If
      End Sub

      Private Sub _miPropertiesViewerProperties_Click(sender As Object, e As EventArgs) Handles _miPropertiesViewerProperties.Click
         ShowViewerDialogs(New ViewerPropertiesDialog(Me))
      End Sub

      Private Sub _miPropertiesCellProperties_Click(sender As Object, e As EventArgs) Handles _miPropertiesCellProperties.Click
         Dim selected As Boolean = False
         Dim i As Integer = 0
         While Not selected AndAlso i < Me.Viewer.Cells.Count
            If CType(Me.Viewer.Cells(i), MedicalViewerMultiCell).Selected Then
               selected = True
            Else
               i += 1
            End If
         End While
         ShowViewerDialogs(New CellPropertiesDialog(Me, i))
      End Sub

      Private Sub _miActionWindowLevelSet_Click(sender As Object, e As EventArgs) Handles _miActionWindowLevelSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.WindowLevel))
      End Sub

      Private Sub _miActionAlphaSet_Click(sender As Object, e As EventArgs) Handles _miActionAlphaSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.Alpha))
      End Sub

      Private Sub _miActionScaleSet_Click(sender As Object, e As EventArgs) Handles _miActionScaleSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.Scale))
      End Sub

      Private Sub _miMagnifySet_Click(sender As Object, e As EventArgs) Handles _miMagnifySet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.MagnifyGlass))
      End Sub

      Private Sub _miActionStackSet_Click(sender As Object, e As EventArgs) Handles _miActionStackSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.Stack))
      End Sub

      Private Sub _miActionOffsetSet_Click(sender As Object, e As EventArgs) Handles _miActionOffsetSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.Offset))
      End Sub

      Private Sub setToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles _miRegionRectangleSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.RectangleRegion))
      End Sub

      Private Sub _miRegionEllipseSet_Click(sender As Object, e As EventArgs) Handles _miRegionEllipseSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.EllipseRegion))
      End Sub

      Private Sub _miRegionSquareSet_Click(sender As Object, e As EventArgs) Handles _miRegionSquareSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.SquareRegion))
      End Sub

      Private Sub _miRegionCircleSet_Click(sender As Object, e As EventArgs) Handles _miRegionCircleSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.CircleRegion))
      End Sub

      Private Sub _miRegionPolygonSet_Click(sender As Object, e As EventArgs) Handles _miRegionPolygonSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.PolygonRegion))
      End Sub

      Private Sub _miRegionFreeHandSet_Click(sender As Object, e As EventArgs) Handles _miRegionFreeHandSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.FreeHandRegion))
      End Sub

      Private Sub _miRegionMagicWandSet_Click(sender As Object, e As EventArgs) Handles _miRegionMagicWandSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.MagicWandRegion))
      End Sub

      Private Sub _miRegionColorRangeSet_Click(sender As Object, e As EventArgs) Handles _miRegionColorRangeSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.ColorRangeRegion))
      End Sub

      Private Sub _miAnnotationRectangleSet_Click(sender As Object, e As EventArgs) Handles _miAnnotationRectangleSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationRectangle, True))
      End Sub

      Private Sub _miAnnotationEllipseSet_Click(sender As Object, e As EventArgs) Handles _miAnnotationEllipseSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationEllipse, True))
      End Sub

      Private Sub _miAnnotationArrowSet_Click(sender As Object, e As EventArgs) Handles _miAnnotationArrowSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationArrow, True))
      End Sub

      Private Sub _miAnnotationTextSet_Click(sender As Object, e As EventArgs) Handles _miAnnotationTextSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationText, True))
      End Sub

      Private Sub _miAnnotationAngleSet_Click(sender As Object, e As EventArgs) Handles _miAnnotationAngleSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationAngle, True))
      End Sub

      Private Sub _miAnnotationHiliteSet_Click(sender As Object, e As EventArgs) Handles _miAnnotationHiliteSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationHilite, True))
      End Sub

      Private Sub _miActionWindowLevelCustomize_Click(sender As Object, e As EventArgs) Handles _miActionWindowLevelCustomize.Click
         ShowViewerDialogs(New WindowLevelPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      ' This method add a key list to the specifid combo box
      Public Sub AddKeysToCombo(keyComboBox As ComboBox, currentKey As Keys)
         '#Region "Added keys"
         Dim keys__1 As Keys() = {Keys.None, Keys.Space, Keys.PageUp, Keys.PageDown, Keys.[End], Keys.Home, _
          Keys.Left, Keys.Up, Keys.Right, Keys.Down, Keys.PrintScreen, Keys.Insert, _
          Keys.Delete, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, _
          Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.A, _
          Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, _
          Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, _
          Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, _
          Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, _
          Keys.Z, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, _
          Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.Multiply, _
          Keys.Add, Keys.Subtract, Keys.[Decimal], Keys.F1, Keys.F2, Keys.F3, _
          Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, _
          Keys.F10, Keys.F11, Keys.F12}

         For Each key As Keys In keys__1
            keyComboBox.Items.Add(key)
         Next

         keyComboBox.SelectedIndex = keyComboBox.Items.IndexOf(currentKey)
         '#End Region
      End Sub

      Public Sub AddModifiersToCombo(keyComboBox As ComboBox, currentKey As MedicalViewerModifiers)
         '#Region "Added modifiers"
         Dim modifiers As MedicalViewerModifiers() = {MedicalViewerModifiers.None, MedicalViewerModifiers.Ctrl, MedicalViewerModifiers.Alt}

         For Each modifier As MedicalViewerModifiers In modifiers
            keyComboBox.Items.Add(modifier)
         Next

         keyComboBox.SelectedIndex = keyComboBox.Items.IndexOf(currentKey)
         '#End Region
      End Sub

      Public Function GetIndex(combo As ComboBox, text As NumericTextBox) As Integer
         If combo.Text = "None" Then
            Return -3
         ElseIf combo.Text = "Selected" Then
            Return -2
         ElseIf combo.Text = "All" Then
            Return -1
         Else
            Return text.Value
         End If
      End Function

      Public Function IsThereASelectedCell() As Boolean
         Dim index As Integer = 0
         While index < Viewer.Cells.Count
            If CType(Viewer.Cells(index), MedicalViewerMultiCell).Selected Then
               Return True
            Else
               index += 1
            End If
         End While
         Return False
      End Function

      Private Function GetSelectedCell() As MedicalViewerCell
         If _medicalViewer IsNot Nothing Then
            For Each cell As MedicalViewerCell In _medicalViewer.Cells
               If cell.Selected Then
                  Return cell
               End If
            Next
         End If
         Return Nothing
      End Function

      Public Function SearchForFirstSelected() As Integer
         Dim index As Integer = 0
         Dim found As Boolean = False

         While Not found AndAlso index < Viewer.Cells.Count
            If CType(Viewer.Cells(index), MedicalViewerMultiCell).Selected Then
               found = True
            Else
               index += 1
            End If
         End While
         Return If(found, index, (If((Viewer.Cells.Count <> 0), 0, -1)))
      End Function

      Private Sub _miActionScaleCustomizeScale_Click(sender As Object, e As EventArgs) Handles _miActionScaleCustomizeScale.Click
         ShowViewerDialogs(New ScalePropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miActionMagnifyCustomizeMagnify_Click(sender As Object, e As EventArgs) Handles _miActionMagnifyCustomizeMagnify.Click
         ShowViewerDialogs(New MagnifyGlassProperties(Me, GetSelectedCell()))
      End Sub

      Private Sub _miActionStackCustomizeStack_Click(sender As Object, e As EventArgs) Handles _miActionStackCustomizeStack.Click
         ShowViewerDialogs(New StackPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miActionOffsetCustomizeOffset_Click(sender As Object, e As EventArgs) Handles _miActionOffsetCustomizeOffset.Click
         ShowViewerDialogs(New OffsetPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miAnnotationTextCustomizeText_Click(sender As Object, e As EventArgs) Handles _miAnnotationTextCustomizeText.Click
         ShowViewerDialogs(New TextAnnotationDialog(Me))
      End Sub

      Private Sub _miAnnotationRectangleCustomizeRectangle_Click(sender As Object, e As EventArgs) Handles _miAnnotationRectangleCustomizeRectangle.Click
         ShowViewerDialogs(New RectangleAnnotationDialog(Me))
      End Sub

      Private Sub _miAnnotationEllipseCustomizeEllipse_Click(sender As Object, e As EventArgs) Handles _miAnnotationEllipseCustomizeEllipse.Click
         ShowViewerDialogs(New EllipseAnnotationDialog(Me))
      End Sub

      Private Sub _miActionArrowCustomizeArrow_Click(sender As Object, e As EventArgs) Handles _miAnnotationArrowCustomizeArrow.Click
         ShowViewerDialogs(New ArrowAnnotationDialog(Me))
      End Sub

      Private Sub _miAnnotationAngleCustomizeAngle_Click(sender As Object, e As EventArgs) Handles _miAnnotationAngleCustomizeAngle.Click
         ShowViewerDialogs(New AngleAnnotationDialog(Me))
      End Sub

      Private Sub _miAnnotationHiliteCustomizeHilite_Click(sender As Object, e As EventArgs) Handles _miAnnotationHiliteCustomizeHilite.Click
         ShowViewerDialogs(New HiliteAnnotationDialog(Me))
      End Sub

      Private Sub _miStatisticsStatistics_Click(sender As Object, e As EventArgs) Handles _miStatisticsStatistics.Click

         ShowViewerDialogs(New StatisticsDialog(Me))
      End Sub

      Private Sub _miAnnotationRulerSet_Click(sender As Object, e As EventArgs) Handles _miAnnotationRulerSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationRuler))
      End Sub

      Private Sub _miAnnotationRulerCustomize_Click(sender As Object, e As EventArgs) Handles _miAnnotationRulerCustomizeRuler.Click
         ShowViewerDialogs(New RulerAnnotationDialog(Me))
      End Sub

      Private Sub _miEditAnimation_Click(sender As Object, e As EventArgs) Handles _miEditAnimation.Click
         ShowViewerDialogs(New AnimationDialog(Me, SearchForFirstSelected()))
      End Sub

      Public Shared Sub ShowColorDialog(label As Label)
         Dim colorDlg As New ColorDialog()

         colorDlg.Color = label.BackColor
         If colorDlg.ShowDialog() = DialogResult.OK Then
            label.BackColor = colorDlg.Color
         End If
      End Sub

      Private Sub ApplyFilter(command As RasterCommand)
         ' This will apply the command to all selected cells.
         For Each cell As MedicalViewerCell In Viewer.Cells
            If cell.Selected Then
               ' Check whether to apply the command to all the image pages or only of the active page
               If _miEffectOptionsApplyToAllSubCells.Checked Then
                  ' Apply the command to all the image pages
                  Dim index As Integer
                  For index = 1 To cell.Image.PageCount
                     cell.Image.Page = index
                     command.Run(cell.Image)
                     If TypeOf command Is FlipCommand Then
                        Dim flip As FlipCommand = CType(command, FlipCommand)
                        If flip.Horizontal Then
                           CType(cell, MedicalViewerMultiCell).ReverseAnnotationContainer(index - 1)
                        Else
                           CType(cell, MedicalViewerMultiCell).FlipAnnotationContainer(index - 1)
                        End If
                     End If
                  Next
               Else
                  ' Apply the command to only the active page.
                  Dim stack As MedicalViewerStack = CType(cell.GetActionProperties(MedicalViewerActionType.Stack, Viewer.Cells.IndexOf(cell)), MedicalViewerStack)
                  cell.Image.Page = stack.ScrollValue + stack.ActiveSubCell + 1
                  command.Run(cell.Image)
                  If TypeOf command Is FlipCommand Then
                     Dim flip As FlipCommand = CType(command, FlipCommand)
                     If flip.Horizontal Then
                        cell.ReverseAnnotationContainer()
                     Else
                        cell.FlipAnnotationContainer()
                     End If
                  End If
               End If
#If LEADTOOLS_V19_OR_LATER Then
               If TypeOf command Is FlipCommand Then
                  If _templateCell IsNot Nothing AndAlso _templateCell Is cell AndAlso _templateList IsNot Nothing Then
                     Dim idx As Integer
                     For idx = 0 To _templateList.Count - 1
                        Dim Y As Integer = If((Not CType(command, FlipCommand).Horizontal), _templateCell.Image.Height - _templateList(idx).Y, _templateList(idx).Y)
                        Dim X As Integer = If((CType(command, FlipCommand).Horizontal), _templateCell.Image.Width - _templateList(idx).X, _templateList(idx).X)
                        _templateList.RemoveAt(idx)
                        _templateList.Insert(idx, New LeadPoint(X, Y))
                     Next
                  ElseIf _referenceCell IsNot Nothing AndAlso _referenceCell Is cell AndAlso _referenceList IsNot Nothing Then
                     Dim idx As Integer
                     For idx = 0 To _referenceList.Count - 1
                        Dim Y As Integer = If((Not CType(command, FlipCommand).Horizontal), _referenceCell.Image.Height - _referenceList(idx).Y, _referenceList(idx).Y)
                        Dim X As Integer = If((CType(command, FlipCommand).Horizontal), _referenceCell.Image.Width - _referenceList(idx).X, _referenceList(idx).X)
                        _referenceList.RemoveAt(idx)
                        _referenceList.Insert(idx, New LeadPoint(X, Y))
                     Next
                  End If
               End If
#End If
               ' Redraw the cell to adopt the new changes.
               cell.Invalidate()
               cell.Automation.Invalidate(LeadRectD.Empty)
            End If
         Next
      End Sub

      Private Sub _editMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _editMenuItem.DropDownOpening
         Dim selected As Boolean = IsThereASelectedCell()
         Dim enabled As Boolean = Viewer.Cells.Count <> 0
         _miEditCalibrateRuler.Enabled = enabled
         _miEditConvertAnnotationToRegion.Enabled = enabled
         _miEditAnimation.Enabled = enabled
         _miEditFreezeCell.Enabled = enabled
         _miEditToggleFreeze.Enabled = enabled AndAlso selected
         _miEditSelectAll.Enabled = enabled
         _miEditDeselectAll.Enabled = enabled AndAlso selected
         _miEditInvertSelection.Enabled = enabled
         _miEditRepositionCell.Enabled = (Viewer.Cells.Count > 1)
         _miEditRemoveCell.Enabled = enabled
         _miEditRemoveSelectedCells.Enabled = enabled

         If enabled Then
            Dim index As Integer = 0
            Dim rulerFound As Boolean = False
            Dim selectedAnnotationFound As Boolean = False
            Dim annotationAttributes As MedicalViewerAnnotationAttributes

            Dim cell As MedicalViewerMultiCell
            ' search if there is at least one selected ruler, or one selected closed shape annotation object (Rectangle, Ellipse or Hilite).
            For index = 0 To Viewer.Cells.Count - 1
               cell = CType(Viewer.Cells(index), MedicalViewerMultiCell)
               ' Get the selected annotation object of the cell.
               annotationAttributes = cell.GetSelectedAnnotationAttributes(-2)

               ' Check the type of the selected annotation object.
               If annotationAttributes.Type <> MedicalViewerActionType.None Then
                  Select Case annotationAttributes.Type
                     Case MedicalViewerActionType.AnnotationRectangle, MedicalViewerActionType.AnnotationEllipse, MedicalViewerActionType.AnnotationHilite
                        If True Then
                           Dim AnnRectObj As AnnRectangleObject = TryCast(cell.Automation.CurrentEditObject, AnnRectangleObject)
                           If Math.Abs(AnnRectObj.Angle) < 0.1 Then
                              selectedAnnotationFound = True
                           End If
                        End If
                        Exit Select
                     Case MedicalViewerActionType.AnnotationRuler
                        rulerFound = True
                        Exit Select
                  End Select
               End If
               ' If both (ruler) & closed shape annotation object are found, then there is no need for more searching.
               If selectedAnnotationFound AndAlso rulerFound Then
                  Exit For
               End If
            Next

            _miEditCalibrateRuler.Enabled = rulerFound
            _miEditConvertAnnotationToRegion.Enabled = selectedAnnotationFound
         End If
      End Sub

      Private Sub _miEffectOptionsApplyToAllSubCells_Click(sender As Object, e As EventArgs) Handles _miEffectOptionsApplyToAllSubCells.Click
         _miEffectOptionsApplyToAllSubCells.Checked = Not _miEffectOptionsApplyToAllSubCells.Checked
      End Sub

      Private Sub _miEffectInvert_Click(sender As Object, e As EventArgs) Handles _miEffectInvert.Click

         Dim cellIndex As Integer
         Dim cell As MedicalViewerMultiCell = Nothing
         For cellIndex = 0 To Viewer.Cells.Count - 1
            cell = CType(Viewer.Cells(cellIndex), MedicalViewerMultiCell)
            If cell.Selected Then
               ' Check whether to apply the Invert to all the image pages or only on the active page
               If _miEffectOptionsApplyToAllSubCells.Checked Then
                  ' Apply the command to all the image pages
                  CType(Viewer.Cells(cellIndex), MedicalViewerMultiCell).InvertImage()
               Else
                  ' Apply the command to only the active page.
                  Dim stack As MedicalViewerStack = CType(cell.GetActionProperties(MedicalViewerActionType.Stack, cellIndex), MedicalViewerStack)
                  CType(Viewer.Cells(cellIndex), MedicalViewerMultiCell).InvertImage(stack.ScrollValue + stack.ActiveSubCell)
               End If
            End If
         Next
      End Sub

      Private Sub _miEffectReverse_Click(sender As Object, e As EventArgs) Handles _miEffectReverse.Click
         ApplyFilter(New FlipCommand(True))
      End Sub

      Private Sub _miEffectFlip_Click(sender As Object, e As EventArgs) Handles _miEffectFlip.Click
         ApplyFilter(New FlipCommand(False))
      End Sub

      Private Sub _miHelpAbout_Click(sender As Object, e As EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Medical Viewer", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _propertiesMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _propertiesMenuItem.DropDownOpening
         Dim enabled As Boolean = Viewer.Cells.Count <> 0
         _miPropertiesCellProperties.Enabled = enabled
      End Sub

      Private Sub _fileMenuItem_DropDownOpening(sender As Object, e As System.EventArgs) Handles _fileMenuItem.DropDownOpening
         Dim enabled As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell()
         saveToolStripMenuItem.Enabled = InlineAssignHelper(_printCellMenuItem.Enabled, enabled)
      End Sub

      Private Sub loadAnnotationsToolStripMenuItem_DropDownOpening(sender As Object, e As System.EventArgs) Handles loadAnnotationsToolStripMenuItem.DropDownOpening
         Dim enabled As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell()
         selectedCellsToolStripMenuItem1.Enabled = enabled
         allCellToolStripMenuItem.Enabled = (Viewer.Cells.Count <> 0)
      End Sub

      Private Sub saveAnnotationsToolStripMenuItem_DropDownOpening(sender As Object, e As System.EventArgs) Handles saveAnnotationsToolStripMenuItem.DropDownOpening
         Dim enabled As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell()
         selectedCellsToolStripMenuItem.Enabled = enabled
         allCellsToolStripMenuItem.Enabled = (Viewer.Cells.Count <> 0)
      End Sub

      Private Sub saveRegionsToolStripMenuItem_DropDownOpening(sender As Object, e As System.EventArgs) Handles saveRegionsToolStripMenuItem.DropDownOpening
         Dim enabled As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell()
         selectedCellsToolStripMenuItem2.Enabled = enabled
         allCellsToolStripMenuItem1.Enabled = (Viewer.Cells.Count <> 0)
      End Sub

      Private Sub loadRegionsToolStripMenuItem_DropDownOpening(sender As Object, e As System.EventArgs) Handles loadRegionsToolStripMenuItem.DropDownOpening
         Dim enabled As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell()
         selectedCellsToolStripMenuItem3.Enabled = enabled
         allCellsToolStripMenuItem2.Enabled = (Viewer.Cells.Count <> 0)
      End Sub



      Private Sub __transformMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _transformMenuItem.DropDownOpening
         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         Dim enabled As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell() AndAlso Not cell.Frozen

         _miEffectInvert.Enabled = enabled
         If _stentDialog IsNot Nothing Then
            enabled = enabled AndAlso Not _stentDialog.Visible
         End If
         _miEffectFlip.Enabled = enabled
         _miEffectReverse.Enabled = enabled
         _miRotate.Enabled = enabled
      End Sub

      Private Sub _miActionAlphaCustomizeAlpha_Click(sender As Object, e As EventArgs) Handles _miActionAlphaCustomizeAlpha.Click
         ShowViewerDialogs(New AlphaPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miEditRemoveCell_Click(sender As Object, e As EventArgs) Handles _miEditRemoveCell.Click
         ShowViewerDialogs(New RemoveCellDialog(Me))
      End Sub

      Private Sub _miEditCalibrateRuler_Click(sender As Object, e As EventArgs) Handles _miEditCalibrateRuler.Click
         ShowViewerDialogs(New CalibrateRulerDialog(Me))
      End Sub

      Private Sub _miEditConvertAnnotationToRegion_Click(sender As Object, e As EventArgs) Handles _miEditConvertAnnotationToRegion.Click
         For Each cell As MedicalViewerCell In Viewer.Cells
            If cell.Selected Then
               cell.ConvertAnnotationToRegion(RasterRegionCombineMode.[Or], True)
            End If
         Next
      End Sub

      Private Sub _miEditRepositionCell_Click(sender As Object, e As EventArgs) Handles _miEditRepositionCell.Click
         ShowViewerDialogs(New RepositionCellDialog(Me))
      End Sub

      Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
         DicomEngine.Shutdown()
      End Sub

      Private Sub _printCellMenuItem_Click(sender As Object, e As EventArgs) Handles _printCellMenuItem.Click

         ShowViewerDialogs(New PrintCellDialog(Me))

      End Sub

      Private Sub setToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles setToolStripMenuItem.Click
         ShowViewerDialogs(New SetNudgeShrinkActionDialog(Me))
      End Sub

      Private Sub customizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles customizeToolStripMenuItem.Click

         ShowViewerDialogs(New NudgeShrinkToolDialog(Me))

      End Sub

      Private Sub selectedCellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles selectedCellsToolStripMenuItem.Click
         ' saving annotations
         Dim fileName As String = ShowSaveDialog(False)
         If fileName Is Nothing OrElse fileName = "" Then
            Return
         End If

         Viewer.SaveAnnotations(fileName, True)
      End Sub

      Private Function ShowSaveDialog(forRegion As Boolean) As String
         Dim saveDialog As New SaveFileDialog()
         saveDialog.AddExtension = True
         If forRegion Then
            saveDialog.Filter = "Region Files (*.rgn)|*.rgn"
         Else
            saveDialog.Filter = "Annotation Files (*.xml)|*.xml"
         End If
         Dim result As DialogResult = saveDialog.ShowDialog()
         If result = DialogResult.OK Then
            Return saveDialog.FileName
         Else
            Return Nothing
         End If
      End Function

      Private Function ShowLoadDialog(forRegion As Boolean) As String
         Dim openDialog As New OpenFileDialog()
         If forRegion Then
            openDialog.Filter = "Region Files (*.rgn)|*.rgn"
         Else
            openDialog.Filter = "Annotation Files (*.xml)|*.xml"
         End If

         Dim result As DialogResult = openDialog.ShowDialog()
         If result = DialogResult.OK Then
            Return openDialog.FileName
         Else
            Return Nothing
         End If
      End Function

      Private Sub allCellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles allCellsToolStripMenuItem.Click
         Dim fileName As String = ShowSaveDialog(False)
         If fileName Is Nothing OrElse fileName = "" Then
            Return
         End If
         Viewer.SaveAnnotations(fileName, True)
      End Sub

      Private Sub selectedCellsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles selectedCellsToolStripMenuItem1.Click
         Dim fileName As String = ShowLoadDialog(False)
         Dim count As Integer = 1

         If fileName IsNot Nothing Then
            For Each cell As MedicalViewerMultiCell In Viewer.Cells
               If cell.Selected Then
                  cell.LoadAnnotations(fileName, -1, count)
                  count += cell.Image.PageCount
               End If
            Next
         End If
      End Sub

      Private Sub allCellToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles allCellToolStripMenuItem.Click
         Dim fileName As String = ShowLoadDialog(False)
         Dim count As Integer = 1

         If fileName IsNot Nothing Then
            For Each cell As MedicalViewerMultiCell In Viewer.Cells
               cell.LoadAnnotations(fileName, -1, count)
               count += cell.Image.PageCount
            Next
         End If
      End Sub

      Private Sub selectedCellsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles selectedCellsToolStripMenuItem2.Click
         Dim fileName As String = ShowSaveDialog(True)
         Dim index As Integer = 0

         If fileName IsNot Nothing Then
            For Each cell As MedicalViewerMultiCell In Viewer.Cells
               If cell.Selected Then
                  If index = 0 Then
                     cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Create)
                  Else
                     cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Append)
                  End If
                  index += 1
               End If
            Next
         End If
      End Sub

      Private Sub allCellsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles allCellsToolStripMenuItem1.Click
         Dim fileName As String = ShowSaveDialog(True)
         Dim index As Integer = 0

         If fileName IsNot Nothing Then
            For Each cell As MedicalViewerMultiCell In Viewer.Cells
               If index = 0 Then
                  cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Create)
               Else
                  cell.SaveRegion(fileName, -1, 1, MedicalViewerFileOperation.Append)
               End If
               index += 1
            Next
         End If
      End Sub

      Private Sub selectedCellsToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles selectedCellsToolStripMenuItem3.Click
         Dim fileName As String = ShowLoadDialog(True)
         Dim count As Integer = 1

         If fileName IsNot Nothing Then
            For Each cell As MedicalViewerMultiCell In Viewer.Cells
               If cell.Selected Then
                  cell.LoadRegion(fileName, -1, count)
                  count += cell.Image.PageCount
               End If
            Next
         End If
      End Sub

      Private Sub allCellsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles allCellsToolStripMenuItem2.Click
         Dim fileName As String = ShowLoadDialog(True)
         Dim count As Integer = 1

         If fileName IsNot Nothing Then
            For Each cell As MedicalViewerMultiCell In Viewer.Cells
               cell.LoadRegion(fileName, -1, count)
               count += cell.Image.PageCount
            Next
         End If
      End Sub

      Public Sub ApplyToCell(cell As MedicalViewerCell)
         Dim index As Integer
         Dim icon As MedicalViewerIcon
         Dim cellIcon As MedicalViewerIcon
         Dim defaultCell__1 As MedicalViewerCell = DefaultCell


         For index = 0 To cell.Titlebar.Icons.Length - 1
            icon = cell.Titlebar.Icons(index)
            cellIcon = defaultCell__1.Titlebar.Icons(index)

            If icon.Visible <> cellIcon.Visible Then
               icon.Visible = cellIcon.Visible
            End If

            If icon.Color <> cellIcon.Color Then
               icon.Color = cellIcon.Color
            End If

            If icon.ColorPressed <> cellIcon.ColorPressed Then
               icon.ColorPressed = cellIcon.ColorPressed
            End If

            If icon.ColorHover <> cellIcon.ColorHover Then
               icon.ColorHover = cellIcon.ColorHover
            End If

            If icon.[ReadOnly] <> cellIcon.[ReadOnly] Then
               icon.[ReadOnly] = cellIcon.[ReadOnly]
            End If
         Next

         If cell.CellBackColor <> defaultCell__1.CellBackColor Then
            cell.CellBackColor = defaultCell__1.CellBackColor
         End If

         If cell.TextColor <> defaultCell__1.TextColor Then
            cell.TextColor = defaultCell__1.TextColor
         End If

         If cell.TextShadowColor <> defaultCell__1.TextShadowColor Then
            cell.TextShadowColor = defaultCell__1.TextShadowColor
         End If

         If cell.ActiveBorderColor <> defaultCell__1.ActiveBorderColor Then
            cell.ActiveBorderColor = defaultCell__1.ActiveBorderColor
         End If

         If cell.NonActiveBorderColor <> defaultCell__1.NonActiveBorderColor Then
            cell.NonActiveBorderColor = defaultCell__1.NonActiveBorderColor
         End If

         If cell.ActiveSubCellBorderColor <> defaultCell__1.ActiveSubCellBorderColor Then
            cell.ActiveSubCellBorderColor = defaultCell__1.ActiveSubCellBorderColor
         End If

         If cell.RulerInColor <> defaultCell__1.RulerInColor Then
            cell.RulerInColor = defaultCell__1.RulerInColor
         End If

         If cell.RulerOutColor <> defaultCell__1.RulerOutColor Then
            cell.RulerOutColor = defaultCell__1.RulerOutColor
         End If

         If cell.Titlebar.UseCustomColor <> defaultCell__1.Titlebar.UseCustomColor Then
            cell.Titlebar.UseCustomColor = defaultCell__1.Titlebar.UseCustomColor
         End If

         If cell.Titlebar.Color <> defaultCell__1.Titlebar.Color Then
            cell.Titlebar.Color = defaultCell__1.Titlebar.Color
         End If

         If cell.Titlebar.Visible <> defaultCell__1.Titlebar.Visible Then
            cell.Titlebar.Visible = defaultCell__1.Titlebar.Visible
         End If

         If cell.TextQuality <> defaultCell__1.TextQuality Then
            cell.TextQuality = defaultCell__1.TextQuality
         End If

         If cell.RulerStyle <> defaultCell__1.RulerStyle Then
            cell.RulerStyle = defaultCell__1.RulerStyle
         End If

         If cell.ShowCellScroll <> defaultCell__1.ShowCellScroll Then
            cell.ShowCellScroll = defaultCell__1.ShowCellScroll
         End If

         If cell.ShowFreezeText <> defaultCell__1.ShowFreezeText Then
            cell.ShowFreezeText = defaultCell__1.ShowFreezeText
         End If

         If cell.PaintingMethod <> defaultCell__1.PaintingMethod Then
            cell.PaintingMethod = defaultCell__1.PaintingMethod
         End If

         If cell.MeasurementUnit <> defaultCell__1.MeasurementUnit Then
            cell.MeasurementUnit = defaultCell__1.MeasurementUnit
         End If

         If cell.BorderStyle <> defaultCell__1.BorderStyle Then
            cell.BorderStyle = defaultCell__1.BorderStyle
         End If


         If Not defaultCell__1.Cursor.Equals(defaultCell__1.Cursor) Then
            cell.Cursor = defaultCell__1.Cursor
         End If

         If cell.AnnotationSelectCursor IsNot Nothing Then
            If Not defaultCell__1.AnnotationSelectCursor.Equals(cell.AnnotationSelectCursor) Then
               cell.AnnotationSelectCursor = defaultCell__1.AnnotationSelectCursor
            End If
         End If

         If Not defaultCell__1.RegionDefaultCursor.Equals(cell.RegionDefaultCursor) Then
            cell.RegionDefaultCursor = defaultCell__1.RegionDefaultCursor
         End If

         If cell.AnnotationDefaultCursor IsNot Nothing Then
            If Not defaultCell__1.AnnotationDefaultCursor.Equals(cell.AnnotationDefaultCursor) Then
               cell.AnnotationDefaultCursor = defaultCell__1.AnnotationDefaultCursor
            End If
         End If

         If cell.AnnotationMoveCursor IsNot Nothing Then
            If Not defaultCell__1.AnnotationMoveCursor.Equals(cell.AnnotationMoveCursor) Then
               cell.AnnotationMoveCursor = defaultCell__1.AnnotationMoveCursor
            End If
         End If
      End Sub

      Public Shared ReadOnly Property DefaultCell() As MedicalViewerMultiCell
         Get
            If _defaultCell Is Nothing Then
               _defaultCell = New MedicalViewerMultiCell(Nothing, False, 1, 1)
               InitializeCell(_defaultCell)
            End If

            Return _defaultCell
         End Get
      End Property

      Private Shared Sub CopyPropertiesFromGlobalCell(cell As MedicalViewerCell)
         Dim actionType As MedicalViewerActionType
         Dim button As MedicalViewerMouseButtons
         Dim flags As MedicalViewerActionFlags
         Dim keys As MedicalViewerKeys
         Dim myEnum As MedicalViewerActionType = MedicalViewerActionType.SpatialLocator

         myEnum = MedicalViewerActionType.SpyGlass


         For actionType = MedicalViewerActionType.WindowLevel To myEnum
            If Not cell.CanExecuteAction(actionType) Then
               Continue For
            End If
            button = DefaultCell.GetActionButton(actionType)
            flags = DefaultCell.GetActionFlags(actionType)

            If button <> MedicalViewerMouseButtons.None Then
               cell.SetAction(actionType, button, flags)
            End If

            keys = DefaultCell.GetActionKeys(actionType)
            cell.SetActionKeys(actionType, keys)

            If actionType > MedicalViewerActionType.Alpha Then
               Dim baseAction As MedicalViewerBaseAction = DefaultCell.GetActionProperties(actionType)
               cell.SetActionProperties(actionType, baseAction)
            End If
         Next

         Dim windowLevelAction As MedicalViewerWindowLevel = CType(DefaultCell.GetActionProperties(MedicalViewerActionType.WindowLevel), MedicalViewerWindowLevel)

         Dim windowLevel As New MedicalViewerWindowLevel()
         windowLevel.ActionCursor = windowLevelAction.ActionCursor
         windowLevel.CircularMouseMove = windowLevelAction.CircularMouseMove
         windowLevel.Sensitivity = windowLevelAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel)


         Dim AlphaAction As MedicalViewerAlpha = CType(DefaultCell.GetActionProperties(MedicalViewerActionType.Alpha), MedicalViewerAlpha)

         Dim Alpha As New MedicalViewerAlpha()
         Alpha.ActionCursor = AlphaAction.ActionCursor
         Alpha.CircularMouseMove = AlphaAction.CircularMouseMove
         Alpha.Sensitivity = AlphaAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Alpha, Alpha)

         Dim ScaleAction As MedicalViewerScale = CType(DefaultCell.GetActionProperties(MedicalViewerActionType.Scale), MedicalViewerScale)

         Dim Scale As New MedicalViewerScale()
         Scale.ActionCursor = ScaleAction.ActionCursor
         Scale.CircularMouseMove = ScaleAction.CircularMouseMove
         Scale.Sensitivity = ScaleAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Scale, Scale)


         Dim StackAction As MedicalViewerStack = CType(DefaultCell.GetActionProperties(MedicalViewerActionType.Stack), MedicalViewerStack)

         Dim Stack As New MedicalViewerStack()
         Stack.ActionCursor = StackAction.ActionCursor
         Stack.CircularMouseMove = StackAction.CircularMouseMove
         Stack.Sensitivity = StackAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Stack, Stack)

         Dim offsetAction As MedicalViewerOffset = CType(DefaultCell.GetActionProperties(MedicalViewerActionType.Offset), MedicalViewerOffset)

         Dim offset As New MedicalViewerOffset()
         offset.ActionCursor = offsetAction.ActionCursor
         offset.CircularMouseMove = offsetAction.CircularMouseMove
         offset.Sensitivity = offsetAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Offset, offset)

         Dim magnifyAction As MedicalViewerMagnifyGlass = CType(DefaultCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass), MedicalViewerMagnifyGlass)
         cell.SetActionProperties(MedicalViewerActionType.MagnifyGlass, magnifyAction)

         Dim index As Integer = 0
         Dim icon As MedicalViewerIcon
         Dim virtualCellIcon As MedicalViewerIcon

         For index = 0 To cell.Titlebar.Icons.Length - 1
            icon = cell.Titlebar.Icons(index)
            virtualCellIcon = cell.Titlebar.Icons(index)

            If icon.Visible <> virtualCellIcon.Visible Then
               icon.Visible = virtualCellIcon.Visible
            End If

            If icon.Color <> virtualCellIcon.Color Then
               icon.Color = virtualCellIcon.Color
            End If

            If icon.ColorPressed <> virtualCellIcon.ColorPressed Then
               icon.ColorPressed = virtualCellIcon.ColorPressed
            End If

            If icon.ColorHover <> virtualCellIcon.ColorHover Then
               icon.ColorHover = virtualCellIcon.ColorHover
            End If

            If icon.[ReadOnly] <> virtualCellIcon.[ReadOnly] Then
               icon.[ReadOnly] = virtualCellIcon.[ReadOnly]
            End If
         Next
         If cell.CellBackColor <> DefaultCell.CellBackColor Then
            cell.CellBackColor = DefaultCell.CellBackColor
         End If

         If cell.TextColor <> DefaultCell.TextColor Then
            cell.TextColor = DefaultCell.TextColor
         End If

         If cell.TextShadowColor <> DefaultCell.TextShadowColor Then
            cell.TextShadowColor = DefaultCell.TextShadowColor
         End If

         If cell.ActiveBorderColor <> DefaultCell.ActiveBorderColor Then
            cell.ActiveBorderColor = DefaultCell.ActiveBorderColor
         End If

         If cell.NonActiveBorderColor <> DefaultCell.NonActiveBorderColor Then
            cell.NonActiveBorderColor = DefaultCell.NonActiveBorderColor
         End If

         If cell.ActiveSubCellBorderColor <> DefaultCell.ActiveSubCellBorderColor Then
            cell.ActiveSubCellBorderColor = DefaultCell.ActiveSubCellBorderColor
         End If

         If cell.RulerInColor <> DefaultCell.RulerInColor Then
            cell.RulerInColor = DefaultCell.RulerInColor
         End If

         If cell.RulerOutColor <> DefaultCell.RulerOutColor Then
            cell.RulerOutColor = DefaultCell.RulerOutColor
         End If

         If cell.Titlebar.UseCustomColor <> DefaultCell.Titlebar.UseCustomColor Then
            cell.Titlebar.UseCustomColor = DefaultCell.Titlebar.UseCustomColor
         End If

         If cell.Titlebar.Color <> DefaultCell.Titlebar.Color Then
            cell.Titlebar.Color = DefaultCell.Titlebar.Color
         End If

         If cell.Titlebar.Visible <> DefaultCell.Titlebar.Visible Then
            cell.Titlebar.Visible = DefaultCell.Titlebar.Visible
         End If

         If cell.TextQuality <> DefaultCell.TextQuality Then
            cell.TextQuality = DefaultCell.TextQuality
         End If

         If cell.RulerStyle <> DefaultCell.RulerStyle Then
            cell.RulerStyle = DefaultCell.RulerStyle
         End If

         If cell.ShowCellScroll <> DefaultCell.ShowCellScroll Then
            cell.ShowCellScroll = DefaultCell.ShowCellScroll
         End If

         If cell.ShowFreezeText <> DefaultCell.ShowFreezeText Then
            cell.ShowFreezeText = DefaultCell.ShowFreezeText
         End If

         If cell.PaintingMethod <> DefaultCell.PaintingMethod Then
            cell.PaintingMethod = DefaultCell.PaintingMethod
         End If

         If cell.MeasurementUnit <> DefaultCell.MeasurementUnit Then
            cell.MeasurementUnit = DefaultCell.MeasurementUnit
         End If

         If cell.BorderStyle <> DefaultCell.BorderStyle Then
            cell.BorderStyle = DefaultCell.BorderStyle
         End If
      End Sub

      Public Shared Sub ApplyToCells(viewer As MedicalViewer, cmbApplyToCell As ComboBox, txtCellIndex As NumericTextBox, cmbApplyToSubCell As ComboBox, txtSubcellIndex As NumericTextBox, actionType As MedicalViewerActionType, _
       actionProperties As MedicalViewerBaseAction)
         ApplyToCells(viewer, cmbApplyToCell, txtCellIndex, cmbApplyToSubCell, txtSubcellIndex, actionType, _
          actionProperties, Nothing)
      End Sub


      Public Shared Sub ApplyToCells(viewer As MedicalViewer, cmbApplyToCell As ComboBox, txtCellIndex As NumericTextBox, cmbApplyToSubCell As ComboBox, txtSubcellIndex As NumericTextBox, actionType As MedicalViewerActionType, _
       actionProperties As MedicalViewerBaseAction, myFunction As MyFunctionDelegate)
         If cmbApplyToCell Is Nothing Then
            Return
         End If

         If cmbApplyToCell.Text = "None" Then
            Return
         End If

         Dim from As Integer = 0
         Dim [to] As Integer = viewer.Cells.Count

         Select Case cmbApplyToCell.Text
            Case "Custom"
               If txtCellIndex.Value >= viewer.Cells.Count Then
                  Return
               End If
               from = txtCellIndex.Value
               [to] = txtCellIndex.Value + 1
               Exit Select
         End Select

         Dim subCellIndex As Integer = 0

         If txtSubcellIndex IsNot Nothing Then
            subCellIndex = txtSubcellIndex.Value
            Select Case cmbApplyToSubCell.Text
               Case "All"
                  subCellIndex = -1
                  Exit Select
               Case "Selected"
                  subCellIndex = -2
                  Exit Select
            End Select
         Else
            subCellIndex = -1
         End If

         Dim index As Integer
         Dim cell As MedicalViewerMultiCell = Nothing

         For index = from To [to] - 1
            cell = CType(viewer.Cells(index), MedicalViewerMultiCell)
            If cell.Selected OrElse cmbApplyToCell.Text <> "Selected" Then
               cell.SetActionProperties(actionType, actionProperties, subCellIndex)
               If myFunction IsNot Nothing Then
                  myFunction(cell, subCellIndex)
               End If
            End If
         Next
      End Sub

      Public Shared Sub CopyKeysFromGlobalCell(sourceCell As MedicalViewerMultiCell, cell As MedicalViewerMultiCell, actionType As MedicalViewerActionType)
         Dim keys As MedicalViewerKeys = sourceCell.GetActionKeys(actionType)
         cell.SetActionKeys(actionType, keys)
      End Sub

      Public Shared Sub CopyActionPropertiesFromGlobalCell(sourceCell As MedicalViewerMultiCell, cell As MedicalViewerMultiCell, actionType As MedicalViewerActionType)
         Dim baseAction As MedicalViewerCommonActions = CType(cell.GetActionProperties(actionType), MedicalViewerCommonActions)
         Dim virtualBaseAction As MedicalViewerCommonActions = CType(sourceCell.GetActionProperties(actionType), MedicalViewerCommonActions)

         If TypeOf baseAction Is MedicalViewerCommonActions Then
            Dim commonAction As MedicalViewerCommonActions = CType(baseAction, MedicalViewerCommonActions)
            Dim virtualCommonAction As MedicalViewerCommonActions = CType(virtualBaseAction, MedicalViewerCommonActions)
            commonAction.ActionCursor = virtualCommonAction.ActionCursor
            commonAction.CircularMouseMove = virtualCommonAction.CircularMouseMove
            commonAction.Sensitivity = virtualCommonAction.Sensitivity
         End If

         cell.SetActionProperties(actionType, baseAction, cell.ActiveSubCell)
      End Sub
      Private Sub _actionsMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _actionsMenuItem.DropDownOpening
      End Sub

      Private Sub _miSpyGlassSet_Click(sender As Object, e As EventArgs) Handles _miSpyGlassSet.Click

         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.SpyGlass))

      End Sub

      Private Sub _miActionsProbeToolSet_Click(sender As Object, e As EventArgs) Handles _miActionsProbeToolSet.Click

         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.ProbeTool))

      End Sub

      Private Sub _miActionZoomToRectangleSet_Click(sender As Object, e As EventArgs) Handles _miActionZoomToRectangleSet.Click

         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.ZoomToRectangle))

      End Sub

      Private Sub _miActionClickZoomInSet_Click(sender As Object, e As EventArgs) Handles _miActionClickZoomInSet.Click

         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.ClickZoomIn))

      End Sub

      Private Sub _miActionClickZoomOutSet_Click(sender As Object, e As EventArgs) Handles _miActionClickZoomOutSet.Click

         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.ClickZoomOut))

      End Sub

      Private Sub _miActionCobbAngleSet_Click(sender As Object, e As EventArgs) Handles _miActionCobbAngleSet.Click
         _cobbAngleStarted = True
         ShowViewerDialogs(New SetActionDialog(Me, MedicalViewerActionType.AnnotationLine))

      End Sub

      Private _cobbAngleStarted As Boolean

      Private Function FindAnotherLineObjectToAttach(subCell As MedicalViewerSubCell, lineObject As AnnPolylineObject) As AnnPolylineObject
         Dim container As AnnContainer = subCell.AnnotationContainer
         Dim count As Integer = subCell.CobbAngles.Count
         Dim lastObject As Integer = container.Children.Count - 1
         Dim list As AnnPolylineObject() = New AnnPolylineObject((count * 2)) {}
         Dim index As Integer
         Dim counter As Integer = 0

         For index = 0 To count - 1
            list(System.Math.Max(System.Threading.Interlocked.Increment(counter), counter - 1)) = subCell.CobbAngles(index).Line1
            list(System.Math.Max(System.Threading.Interlocked.Increment(counter), counter - 1)) = subCell.CobbAngles(index).Line2
         Next

         Dim annObject As AnnObject
         For index = lastObject To 0 Step -1
            annObject = container.Children(index)
            If TypeOf annObject Is AnnPolylineObject Then
               If annObject.Equals(lineObject) Then
                  Continue For
               End If
               If Array.IndexOf(list, annObject) = -1 Then
                  Return CType(annObject, AnnPolylineObject)
               End If
            End If
         Next

         Return Nothing
      End Function

      Private Sub Automation_Draw(sender As Object, e As AnnDrawDesignerEventArgs)
         If _cobbAngleStarted Then
            If e.OperationStatus = AnnDesignerOperationStatus.[End] Then
               If TypeOf (e.[Object]) Is AnnPolylineObject Then
                  Dim cellIndex As Integer = GetFirstSelectedMultiCellIndex()

                  If cellIndex = -1 Then
                     Return
                  End If

                  Dim cell As MedicalViewerMultiCell = CType(_medicalViewer.Cells(cellIndex), MedicalViewerMultiCell)

                  Dim container As AnnContainer = cell.SubCells(cell.ActiveSubCell).AnnotationContainer

                  Dim annObject As AnnObject = (e.[Object])
                  If TypeOf annObject Is AnnPolylineObject Then
                     Dim lineObject As AnnPolylineObject = CType(annObject, AnnPolylineObject)

                     Dim secondLine As AnnPolylineObject = FindAnotherLineObjectToAttach(cell.SubCells(cell.ActiveSubCell), CType(annObject, AnnPolylineObject))
                     If secondLine IsNot Nothing Then
                        cell.SubCells(cell.ActiveSubCell).CobbAngles.Add(New MedicalViewerCobbAngle(CType(annObject, AnnPolylineObject), secondLine))
                        _cobbAngleStarted = False
                     Else
                        cell.SetAction(MedicalViewerActionType.AnnotationLine, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)

                     End If
                  End If
               End If
            End If
         End If
         UnpushAllAnnotationIcons()
         If Not _currentToolbarButton Is Nothing Then
            _currentToolbarButton.Pushed = True
         End If
      End Sub

      Public Property CurrentToolBarButton() As ToolBarButton
         Get
            Return _currentToolbarButton
         End Get

         Set(value As ToolBarButton)
            _currentToolbarButton = Value
         End Set
      End Property

      Private Sub cell_AnnotationCreated(sender As Object, e As MedicalViewerAnnotationCreatedEventArgs)
         'MedicalViewerMultiCell cell = (MedicalViewerMultiCell)(sender);
         '                AnnContainer container = cell.SubCells[e.SubCellIndex].AnnotationContainer;
         '                AnnObject annObject = e.Object;
         '                if (annObject is AnnLineObject)
         '                {
         '                    AnnLineObject secondLine = FindAnotherLineObjectToAttach(cell.SubCells[cell.ActiveSubCell], (AnnLineObject)annObject);
         '                    if (secondLine != null)
         '                    {
         '                        cell.SubCells[cell.ActiveSubCell].CobbAngles.Add(new MedicalViewerCobbAngle((AnnLineObject)annObject, secondLine));
         '                    }
         '                }

         If e.AnnotationType = MedicalViewerActionType.AnnotationLine Then
         End If
      End Sub

      Private Sub imageInfoToolStripMenuItem_Click(sender As Object, e As EventArgs)
         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         If cell IsNot Nothing Then
            If cell.Image IsNot Nothing Then
               MessageBox.Show([String].Format("Low Bit = {0} \n High Bit {1} \n Signed {2} \n MinimumValue {3} \n MaximumValue {4}", cell.Image.LowBit, cell.Image.HighBit, cell.Image.Signed, cell.Image.MinValue, cell.Image.MaxValue))
            End If
         End If
      End Sub

      Private Sub checkMarkerClicked(firstMarker As LeadPoint, secondMarker As LeadPoint, e As MedicalViewerCellMouseEventArgs)

         Dim highlightArea As Integer = 5
         Dim rect As Rectangle = _stentCell.GetDisplayedImageRectangle()
         Dim rcRegion As LeadRect = _stentCommand.Region
         Dim image As RasterImage = _stentCell.Image

         Dim scaleX As Single = rect.Width * 1.0F / image.Width
         Dim scaleY As Single = rect.Height * 1.0F / image.Height


         Dim firstOutput As New LeadPoint(CInt((firstMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5), CInt((firstMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5))

         Dim secondOutput As New LeadPoint(CInt((secondMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5), CInt((secondMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5))

         Dim firstRect As New Rectangle(firstOutput.X - highlightArea, firstOutput.Y - highlightArea, highlightArea * 2, highlightArea * 2)
         Dim secondRect As New Rectangle(secondOutput.X - highlightArea, secondOutput.Y - highlightArea, highlightArea * 2, highlightArea * 2)

         Dim mousePoint As New Point(e.X, e.Y)

         If firstRect.Contains(mousePoint) Then
            markerIndex = 0
         ElseIf secondRect.Contains(mousePoint) Then
            markerIndex = 1
         End If

      End Sub

      Private Sub cell_CellMouseDown(sender As Object, e As MedicalViewerCellMouseEventArgs)

         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)

         If _currentAction = CType(101, MedicalViewerActionType) Then
            If _stentDialog IsNot Nothing Then
               If _stentCommand IsNot Nothing Then
                  If (cell) Is _stentCell Then
                     If e.Button = MouseButtons.Left Then
                        markerIndex = -1
                        If _stentCommand.StentMarkers Is Nothing Then
                           If e.SubCellIndex = _keyStentFrame Then
                              checkMarkerClicked(_stentCommand.FirstMarker, _stentCommand.SecondMarker, e)
                           End If
                        Else
                           checkMarkerClicked(_stentCommand.StentMarkers(e.SubCellIndex).FirstMarker, _stentCommand.StentMarkers(e.SubCellIndex).SecondMarker, e)
                        End If
                     End If
                  End If
               End If
            End If
         End If


         If cell.Image IsNot Nothing Then
            _probeToolImage = cell.Image
            _probeToolImage.Page = e.SubCellIndex + 1
         End If

      End Sub

      Private Sub AddProbeToolEvents(cell As MedicalViewerCell)
         AddHandler cell.ProbeToolTextChanged, AddressOf cell_ProbeToolTextChanged
         AddHandler cell.CellMouseDown, AddressOf cell_CellMouseDown
      End Sub

      Private Sub cell_ProbeToolTextChanged(sender As Object, e As MedicalViewerProbeToolTextChangedEventArgs)
         Dim bitmapX As Integer = CInt(e.X)
         Dim bitmapY As Integer = CInt(e.Y)
         Dim output As String

         Dim value As String = GetRealPixelValue(_probeToolImage, bitmapX, bitmapY)

         If value <> "" Then
            output = [String].Format("X = {0}, Y = {1} \n Value = {2} \n Frame {3}", CInt(e.X), CInt(e.Y), value, e.SubCellIndex + 1)
         Else
            output = [String].Format("X = N/A, Y = N/A \n Value = N/A \n Frame N/A")
         End If

         e.Text = output
      End Sub

      Private _probeToolImage As RasterImage

      Private Function GetRealPixelValue(image As RasterImage, x As Integer, y As Integer) As String
         Dim bitmapPoint As LeadPoint = image.PointToImage(RasterViewPerspective.TopLeft, New LeadPoint(x, y))

         x = bitmapPoint.X
         y = bitmapPoint.Y

         If x >= 0 AndAlso y >= 0 Then
            If (image.Width >= x) AndAlso (image.Height >= y) Then
               Dim Data As Byte()
               Dim Value As Int16
               Dim uValue As UInt16

               ' just work with extended gray scale here
               If image.GrayscaleMode <> RasterGrayscaleMode.None AndAlso image.BitsPerPixel > 8 Then
                  image.Access()
                  Data = image.GetPixelData(y, x)
                  image.Release()
                  If image.Signed Then
                     Dim highBit As Int16
                     If image.HighBit = 0 Then
                        highBit = CType(image.BitsPerPixel - 1, Int16)
                     Else
                        highBit = CType(image.HighBit, Int16)
                     End If

                     Value = BitConverter.ToInt16(Data, 0)
                     ' account for when all allocated bits are not used for image data encoding
                     If (image.HighBit < (image.BitsPerPixel - 1)) Or (image.LowBit > 0) Then
                        ' actual image low bit is not 0
                        If image.LowBit <> 0 Then
                           Value = CType(Value >> image.LowBit, Int16)
                           highBit = CType(image.HighBit - image.LowBit, Int16)
                        End If

                        ' see if the value is negative 
                        Dim signLimit As Int16
                        signLimit = CType(Math.Truncate(Math.Pow(2, highBit + 1) / 2), Int16)
                        If Value >= signLimit Then
                           Value = CType(Math.Truncate(Value - (Math.Pow(2, highBit + 1))), Int16)
                        End If
                     End If

                     Return Value.ToString()
                  Else
                     uValue = BitConverter.ToUInt16(Data, 0)
                     ' when low bit is not zero
                     If image.LowBit > 0 Then
                        uValue = CType(uValue >> image.LowBit, UInt16)
                     End If
                     Return uValue.ToString()
                  End If
               Else
                  Dim R As Integer
                  Dim G As Integer
                  Dim B As Integer

                  If image.BitsPerPixel > 32 Then
                     Dim bit16ComponentData As Byte()
                     image.Access()
                     bit16ComponentData = image.GetPixelData(y, x)
                     image.Release()
                     R = BitConverter.ToUInt16(bit16ComponentData, 0)
                     G = BitConverter.ToUInt16(bit16ComponentData, 2)
                     B = BitConverter.ToUInt16(bit16ComponentData, 4)
                     Return [String].Format("{0}, {1}, {2}", R, G, B)
                  End If


                  Dim PixelColor As RasterColor = image.GetPixelColor(y, x)
                  Return [String].Format("{0}, {1}, {2}", PixelColor.R, PixelColor.G, PixelColor.B)

               End If
            End If
         End If
         Return ""
      End Function

      Public Function GetFirstSelectedMultiCellIndex() As Integer
         Dim counter As Integer = 0
         For Each control As Control In _medicalViewer.Cells
            If TypeOf control Is MedicalViewerMultiCell Then
               Dim cell As MedicalViewerMultiCell = CType(control, MedicalViewerMultiCell)

               If cell.Selected Then
                  Return counter
               End If

               counter += 1
            End If
         Next
         Return -1
      End Function

      Private Sub cell_CellMouseUp(sender As Object, e As MedicalViewerCellMouseEventArgs)

         If markerIndex <> -1 Then
            markerIndex = -1
            If _stentDialog IsNot Nothing Then
               If CType(sender, MedicalViewerCell) Is _stentCell Then
                  If _stentCommand IsNot Nothing Then
                     If _stentCommand.StentMarkers IsNot Nothing Then
                        _stentCommand.UpdateStentImage(_stentCell.Image)
                        ApplyEnhancements(_stentCommand.EnhancedImage)
                     End If
                  End If
               End If
            End If
         End If


      End Sub

      Private Function moveMarker(e As MedicalViewerCellMouseEventArgs) As LeadPoint

         Dim rcRegion As LeadRect = _stentCommand.Region
         Dim X As Integer = e.X
         Dim Y As Integer = e.Y

         Dim cellRect As Rectangle = _stentCell.GetDisplayedImageRectangle()
         Dim image As RasterImage = _stentCell.Image

         Dim scaleX As Single = cellRect.Width * 1.0F / image.Width
         Dim scaleY As Single = cellRect.Height * 1.0F / image.Height

         X = CInt(Math.Truncate((X - cellRect.Left) / scaleX + 0.5))
         Y = CInt(Math.Truncate((Y - cellRect.Top) / scaleY + 0.5))
         X = X - rcRegion.Left
         Y = Y - rcRegion.Top

         Return New LeadPoint(X, Y)

      End Function

      Private Sub cell_CellMouseMove(sender As Object, e As MedicalViewerCellMouseEventArgs)

         If markerIndex <> -1 Then
            If _stentDialog IsNot Nothing Then
               If CType(sender, MedicalViewerCell) Is _stentCell Then
                  If _stentCommand IsNot Nothing Then
                     Dim currentPoint As LeadPoint = moveMarker(e)
                     Dim region As LeadRect = _stentCommand.Region
                     If _stentCommand.Region.Contains(currentPoint.X + region.Left, currentPoint.Y + region.Top) Then
                        If _stentCommand.StentMarkers Is Nothing Then
                           If e.SubCellIndex = _keyStentFrame Then
                              If markerIndex = 0 Then
                                 _stentCommand.FirstMarker = currentPoint
                              Else
                                 _stentCommand.SecondMarker = currentPoint
                              End If
                           End If
                        Else
                           If markerIndex = 0 Then
                              _stentCommand.StentMarkers(e.SubCellIndex).FirstMarker = currentPoint
                           Else
                              _stentCommand.StentMarkers(e.SubCellIndex).SecondMarker = currentPoint
                           End If
                        End If
                        _stentCell.Invalidate()
                     End If
                  End If
               End If
            End If
         End If

      End Sub

      Private Function CreateRectFromPoint(point As LeadPoint, size As Integer) As Rectangle
         Return New Rectangle(point.X - size, point.Y - size, size * 2, size * 2)
      End Function

      Private Sub cell_PostPaint(sender As Object, e As MedicalViewerPaintInformationEventArgs)

         If _stentCommand Is Nothing OrElse _stentCell IsNot CType(sender, MedicalViewerCell) Then
            Return
         End If

         If _frameEnabled IsNot Nothing Then
            If Not _frameEnabled(e.SubCellIndex) Then
               Return
            End If
         End If

         Dim marker As StentEnhancementMarkers
         If _stentCommand.StentMarkers Is Nothing Then
            If e.SubCellIndex <> _keyStentFrame Then
               Return
            End If
            marker = New StentEnhancementMarkers(_stentCommand.FirstMarker.X, _stentCommand.FirstMarker.Y, _stentCommand.SecondMarker.X, _stentCommand.SecondMarker.Y)
         Else
            marker = _stentCommand.StentMarkers(e.SubCellIndex)
         End If

         Dim cell As MedicalViewerMultiCell = CType(_medicalViewer.Cells(e.CellIndex), MedicalViewerMultiCell)
         Dim image As RasterImage = cell.Image
         Dim rcRegion As LeadRect = _stentCommand.Region

         Dim rect As Rectangle = cell.GetDisplayedImageRectangle()


         Dim scaleX As Single = rect.Width * 1.0F / image.Width
         Dim scaleY As Single = rect.Height * 1.0F / image.Height


         Dim firstOutput As New LeadPoint(CInt(Math.Truncate((marker.FirstMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5)), CInt(Math.Truncate((marker.FirstMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5)))

         Dim secondOutput As New LeadPoint(CInt(Math.Truncate((marker.SecondMarker.X + rcRegion.Left) * scaleX + rect.Left + 0.5)), CInt(Math.Truncate((marker.SecondMarker.Y + rcRegion.Top) * scaleY + rect.Top + 0.5)))

         Dim rect2 As Rectangle = cell.GetDisplayedClippedImageRectangle()

         If Not rect2.IsEmpty Then
            e.Graphics.DrawEllipse(Pens.Red, CreateRectFromPoint(firstOutput, 5))
            e.Graphics.DrawEllipse(Pens.Blue, CreateRectFromPoint(secondOutput, 5))
         End If

      End Sub

      Private Sub CreateStentCells()

         Dim medicalViewer As MedicalViewer = Me.Viewer

         _avgImageCell = InlineAssignHelper(_enhImageCell, Nothing)
         For Each data As StentData In _stentDataList
            If data.StentCell Is _stentCell Then
               If data.AvgImageCell IsNot Nothing Then
                  If Not data.AvgImageCell.IsDisposed Then
                     _avgImageCell = data.AvgImageCell
                  Else
                     _avgImageCell = Nothing
                  End If
               End If

               If data.EnhImageCell IsNot Nothing Then
                  If Not data.EnhImageCell.IsDisposed Then
                     _enhImageCell = data.EnhImageCell
                  Else
                     _enhImageCell = Nothing
                  End If

               End If
            End If
         Next


         If _avgImageCell Is Nothing Then
            _avgImageCell = New MedicalViewerMultiCell()

            _avgImageCell.FitImageToCell = True
            _avgImageCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.UserData, "Average Stent Image")
            _avgImageCell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale)
            _avgImageCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)

            medicalViewer.Cells.Add(_avgImageCell)
            AddHandler _avgImageCell.Disposed, AddressOf _avgImageCell_Disposed

            InitializeCell(_avgImageCell)
            InitAutomation(_avgImageCell)
            InitializeAutomationManager(_avgImageCell)
            AddHandler _avgImageCell.Resized, AddressOf _avgImageCell_Resized
            InitializeEvents(_avgImageCell)
         End If


         If _enhImageCell Is Nothing Then
            _enhImageCell = New MedicalViewerMultiCell()

            _enhImageCell.FitImageToCell = True
            _enhImageCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.UserData, "Default Stent Image Enhancement")
            _enhImageCell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale)
            _enhImageCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)

            medicalViewer.Cells.Add(_enhImageCell)
            AddHandler _enhImageCell.Disposed, AddressOf _enhImageCell_Disposed

            InitializeCell(_enhImageCell)
            InitAutomation(_enhImageCell)
            InitializeAutomationManager(_enhImageCell)
            AddHandler _enhImageCell.Resized, AddressOf _avgImageCell_Resized

            InitializeEvents(_enhImageCell)
         End If


         Dim addToList As Boolean = True
         For Each data As StentData In _stentDataList
            If data.StentCell Is _stentCell Then
               addToList = False
               data.AvgImageCell = _avgImageCell
               data.EnhImageCell = _enhImageCell
               Exit For
            End If
         Next

         If addToList Then
            _stentDataList.Add(New StentData(_stentCell, _avgImageCell, _enhImageCell))
         End If

         Return

      End Sub

      Private Sub _avgImageCell_Resized(sender As Object, e As EventArgs)
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)

         Dim image As RasterImage = cell.Image
         Dim RegionBounds As LeadRect = image.GetRegionBounds(Nothing)

         cell.ZoomToRectangle(ZoomToRectangleHelper(RegionBounds, cell))
      End Sub

      Private Sub _enhImageCell_Disposed(sender As Object, e As EventArgs)

         Dim enhImageCell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         If _stentDialog IsNot Nothing AndAlso _enhImageCell.Equals(enhImageCell) Then
            _dialogDisplaced = False
         End If

         For Each data As StentData In _stentDataList
            If data.EnhImageCell Is enhImageCell Then
               data.EnhImageCell = Nothing
               Exit For
            End If
         Next

         RemoveHandler enhImageCell.Disposed, AddressOf _enhImageCell_Disposed
         enhImageCell = Nothing

      End Sub

      Private Sub _avgImageCell_Disposed(sender As Object, e As EventArgs)

         Dim avgImageCell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         If _stentDialog IsNot Nothing AndAlso _avgImageCell.Equals(avgImageCell) Then
            _stentDialog.ResetAvgEnabled(False)
            _dialogDisplaced = False
         End If

         For Each data As StentData In _stentDataList
            If data.AvgImageCell Is avgImageCell Then
               data.AvgImageCell = Nothing
               Exit For
            End If
         Next
         RemoveHandler avgImageCell.Disposed, AddressOf _avgImageCell_Disposed
         avgImageCell = Nothing

      End Sub

      Private Function ZoomToRectangleHelper(stentRegion As LeadRect, cell As MedicalViewerMultiCell) As Rectangle
         Dim Top As Integer = stentRegion.Top
         Dim Left As Integer = stentRegion.Left
         Dim Right As Integer = stentRegion.Right
         Dim Bottom As Integer = stentRegion.Bottom

         Dim rect As Rectangle = cell.GetDisplayedImageRectangle()
         Dim image As RasterImage = cell.Image
         Dim scaleX As Single = rect.Width * 1.0F / image.Width
         Dim scaleY As Single = rect.Height * 1.0F / image.Height

         Top = CInt(Math.Truncate(Top * scaleY + 0.5 + rect.Top))
         Left = CInt(Math.Truncate(Left * scaleX + 0.5 + rect.Left))
         Right = CInt(Math.Truncate(Right * scaleX + 0.5 + rect.Left))
         Bottom = CInt(Math.Truncate(Bottom * scaleY + 0.5 + rect.Top))

         Return New Rectangle(Left, Top, Right - Left, Bottom - Top)
      End Function

      Public Sub ApplyEnhancements(img As RasterImage)

         CreateStentCells()
         _avgImageCell.Image = img.Clone()
         _enhImageCell.Image = img.Clone()
         Dim image As RasterImage = _enhImageCell.Image

         If image.BitsPerPixel <> 8 Then
            Dim unsharpCommand As New UnsharpMaskCommand(200, 100, 0, UnsharpMaskCommandColorType.Yuv)
            unsharpCommand.Run(image)
         End If

         Dim multiscaleCommand As New MultiscaleEnhancementCommand(900, 3, 170, 5, 140, MultiscaleEnhancementCommandType.Gaussian, _
          MultiscaleEnhancementCommandFlags.EdgeEnhancement Or MultiscaleEnhancementCommandFlags.LatitudeReduction)
         multiscaleCommand.Run(image)

         If image.BitsPerPixel = 16 OrElse image.BitsPerPixel = 8 Then
            Dim Alpha As Single = 0.65F
            Dim Tilesize As Integer = 8
            Dim Tilehistcliplimit As Single = 0.01F
            Dim Binnumber As Integer = 128
            Dim flags As CLAHECommandFlags = CLAHECommandFlags.ApplyRayliehDistribution
            Dim hhh As New CLAHECommand(Alpha, Tilesize, Tilehistcliplimit, Binnumber, flags)
            hhh.Run(image)

            If image.BitsPerPixel = 16 Then
               Dim command As New GetLinearVoiLookupTableCommand(GetLinearVoiLookupTableCommandFlags.None)
               command.Run(image)
               _enhImageCell.SetWindowLevel(CInt(command.Width), CInt(command.Center))
            End If
         End If

         _avgImageCell.ZoomToRectangle(ZoomToRectangleHelper(_stentRegion, _avgImageCell))
         _enhImageCell.ZoomToRectangle(ZoomToRectangleHelper(_stentRegion, _enhImageCell))

         _avgImageCell.Invalidate()
         _enhImageCell.Invalidate()

         For Each data As StentData In _stentDataList
            If data.EnhImageCell Is _enhImageCell Then
               data.EnhImageCellWLCenter = _enhImageCell.GetWindowLevelCenter()
               data.EnhImageCellWLWidth = _enhImageCell.GetWindowLevelWidth()
               Exit For
            End If
         Next


      End Sub

      Public Sub ApplyStent()

         _regionMenuItem.Enabled = False
         If _stentCell Is Nothing OrElse _stentCommand Is Nothing Then
            Return
         End If
         If _stentCell.Image Is Nothing Then
            Return
         End If

         _stentCell.Image.Page = _stentCell.ActiveSubCell + 1

         If _stentCell.Image IsNot Nothing Then
            If Not _stentCell.Image.HasRegion Then
               Return
            End If
         End If

         If _medicalViewer.Rows <> 2 Then
            _medicalViewer.Rows = 2
            _medicalViewer.Columns = 2
         End If

         If Not _dialogDisplaced Then
            _stentDialog.ResetBtnEnabled(False)

            _stentDialog.Left += CInt(_stentDialog.Width / 2)
            _stentDialog.Top += CInt(_stentDialog.Height / 2)
            _dialogDisplaced = True

            Dim image As RasterImage = _stentCell.Image
            If _stentCell.Image.ViewPerspective <> RasterViewPerspective.TopLeft Then
               _stentCell.SetImagePerspective(RasterViewPerspective.TopLeft)
            End If


            Dim WindowWidth As Integer = _stentCell.GetWindowLevelWidth()
            Dim WindowCenter As Integer = _stentCell.GetWindowLevelCenter()

            _stentCell.SetWindowLevel(WindowWidth, WindowCenter)

            Try
               _stentCommand.Run(image)
            Catch ex As System.Exception
               Messager.ShowError(Me, ex)
            End Try

            _frameEnabled = _stentCommand.FrameEnabled

            _stentDialog.UpdateProgress(0)

            ApplyEnhancements(_stentCommand.EnhancedImage)
            _stentDialog.ResetAvgEnabled(True)
         End If

      End Sub

      Public Sub ResetRegion()

         Dim image As RasterImage = _stentCell.Image
         Dim RegionBounds As LeadRect = image.GetRegionBounds(Nothing)

         _keyStentFrame = _stentCell.ActiveSubCell
         _stentCell.SetAction(MedicalViewerActionType.RectangleRegion, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         CheckMoveMarkersAction(False)
         _stentCommand = Nothing
         _stentCell.RemoveRegion()
         _stentCell.Invalidate()

      End Sub

      Public Sub FinishStentEnhancement()

         If _stentCell IsNot Nothing Then
            _stentCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            _stentCell.SetAction(_rightButtonAction, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
            CheckMoveMarkersAction(False)
            _stentDialog = Nothing
            _dialogDisplaced = False

            If _stentCell.Image IsNot Nothing Then
               _stentCell.RemoveRegion()
            End If

            If _modifyStentDlg IsNot Nothing Then
               _modifyStentDlg.Close()
            End If
            _modifyStentDlg = Nothing

            RemoveHandler _stentCell.RegionCreated, AddressOf cell_RegionCreated
            RemoveHandler _stentCell.PostPaint, AddressOf cell_PostPaint

            RemoveHandler _stentCell.CellMouseDown, AddressOf cell_CellMouseDown
            RemoveHandler _stentCell.CellMouseMove, AddressOf cell_CellMouseMove
            RemoveHandler _stentCell.CellMouseUp, AddressOf cell_CellMouseUp

            _stentCommand = Nothing
            '_avgImageCell = null;
            '                _enhImageCell = null;

            _frameEnabled = Nothing
            _stentCell.Invalidate()

            _stentCell = Nothing
         End If

      End Sub

      Private Sub _stentCell_Disposed(sender As Object, e As EventArgs)

         If _stentCell Is Nothing Then
            Return
         End If
         _stentCell = Nothing
         _stentDialog.Close()
         If _modifyStentDlg IsNot Nothing Then
            _modifyStentDlg.Close()
         End If
         _modifyStentDlg = Nothing
         _stentCommand = Nothing
         _stentDialog = Nothing
         _enhImageCell = Nothing
         _avgImageCell = Nothing
         CheckMoveMarkersAction(False)


      End Sub

      Private Sub cell_RegionCreated(sender As Object, e As MedicalViewerRegionCreatedEventArgs)

         If _stentDialog Is Nothing Then
            Return
         End If

         Dim image As RasterImage = _stentCell.Image
         Dim RegionBounds As LeadRect = image.GetRegionBounds(Nothing)


         _stentRegion = RegionBounds

         Dim regionWidth As Integer = RegionBounds.Width
         Dim regionHeight As Integer = RegionBounds.Height

         _keyStentFrame = e.SubCellIndex

         Dim userAction As MedicalViewerActionType = CType(101, MedicalViewerActionType)
         _stentCell.AddAction(userAction)
         _stentCell.SetAction(userAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         _currentAction = CType(101, MedicalViewerActionType)
         CheckMoveMarkersAction(True)

         _stentCommand = New StentEnhancementCommand(RegionBounds, _keyStentFrame)

         _stentCommand.DetectMarkers(image, e.SubCellIndex, RegionBounds)

         AddHandler _stentCommand.Progress, AddressOf _stentCommand_Progress

         _stentDialog.ResetBtnEnabled(True)

         _stentCell.Invalidate()

      End Sub

      Private Sub _stentCommand_Progress(sender As Object, e As RasterCommandProgressEventArgs)

         _stentDialog.UpdateProgress(e.Percent)
         Application.DoEvents()

      End Sub

      Private Sub stentEnhancementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _stentEnhancementMenuItem.Click

         If _stentDialog IsNot Nothing Then
            Return
         End If

         _stentDialog = New StentEnhancementDialog(Me)
         _stentDialog.Show(Me)
         AddHandler _stentDialog.FormClosing, AddressOf _stentDialog_FormClosing

         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         cell.SetImagePerspective(RasterViewPerspective.TopLeft)
         cell.SetAction(MedicalViewerActionType.RectangleRegion, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)

         AddHandler cell.RegionCreated, AddressOf cell_RegionCreated
         AddHandler cell.PostPaint, AddressOf cell_PostPaint

         AddHandler cell.CellMouseDown, AddressOf cell_CellMouseDown
         AddHandler cell.CellMouseMove, AddressOf cell_CellMouseMove
         AddHandler cell.CellMouseUp, AddressOf cell_CellMouseUp
         AddHandler cell.Disposed, AddressOf _stentCell_Disposed

         _stentCell = cell

         _dialogDisplaced = False

      End Sub

      Public Sub _stentDialog_FormClosing(sender As Object, e As FormClosingEventArgs)
         _regionMenuItem.Enabled = True
      End Sub

      Private Sub unselectFramesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _unselectFramesMenuItem.Click

         If _stentCell Is Nothing Then
            Return
         End If
         If _frameEnabled Is Nothing Then
            Return
         End If
         If _modifyStentDlg IsNot Nothing Then
            Return
         End If

         _modifyStentDlg = New ModifyStent(_stentCell, _stentCommand, Me)
         _modifyStentDlg.Show(Me)

      End Sub

      Public Sub ResetAverage()

         If _avgImageCell IsNot Nothing Then
            If _stentCommand.EnhancedImage IsNot Nothing Then
               _avgImageCell.Image = _stentCommand.EnhancedImage.Clone()
               _avgImageCell.ZoomToRectangle(ZoomToRectangleHelper(_stentRegion, _avgImageCell))
               _avgImageCell.Invalidate()
            End If
         End If

      End Sub

      Private Sub multiscaleEnhancementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles multiscaleEnhancementToolStripMenuItem.Click

         Dim cell As MedicalViewerCell = GetSelectedCell()
         If cell IsNot Nothing Then
            ShowViewerDialogs(New MultiscaleEnhancementDialog(Me, cell))
         End If

      End Sub

      Private Sub adaptiveContrastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles adaptiveContrastToolStripMenuItem.Click

         Dim cell As MedicalViewerCell = GetSelectedCell()
         If cell IsNot Nothing Then
            ShowViewerDialogs(New AdaptiveContrastDialog(Me))
         End If

      End Sub

      Private Sub unsharpMaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles unsharpMaskToolStripMenuItem.Click

         Dim cell As MedicalViewerCell = GetSelectedCell()
         If cell IsNot Nothing Then
            ShowViewerDialogs(New UnsharpMaskDialog(Me))
         End If

      End Sub

      Private Sub histogramEqualizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles histogramEqualizeToolStripMenuItem.Click

         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         If cell IsNot Nothing Then
            ShowViewerDialogs(New HistogramEqualizeDialog(cell, Me))
         End If

      End Sub

      Public Delegate Sub ApplyFilterCallBack()
      Public Sub FilterOk_Click(originalBitmap As RasterImage, firstTime As Boolean, ApplyFilter As ApplyFilterCallBack)

         Dim cell As MedicalViewerCell = GetSelectedCell()
         Dim cellIndex As Integer = GetCellIndex(cell)

         If _orignalImagesList(cellIndex) Is Nothing Then
            _orignalImagesList(cellIndex) = New RasterImage(cell.Image.PageCount - 1) {}
         End If

         Dim imageArray As RasterImage() = _orignalImagesList(cellIndex)

         If firstTime Then
            If imageArray(cell.ActiveSubCell) Is Nothing Then
               Dim orignalPage As Integer = cell.Image.Page
               cell.Image.Page = cell.ActiveSubCell + 1
               imageArray(cell.ActiveSubCell) = cell.Image.Clone()
               cell.Image.Page = orignalPage
            End If
            ApplyFilter()
         Else
            If imageArray(cell.ActiveSubCell) Is Nothing Then
               imageArray(cell.ActiveSubCell) = New RasterImage(originalBitmap)
            End If
         End If

      End Sub

      Public Sub FilterApply_Click(ByRef firstTime As Boolean, ByRef originalBitmap As RasterImage, ApplyFilter As ApplyFilterCallBack)
         Dim cell As MedicalViewerCell = GetSelectedCell()

         If firstTime Then
            Dim orignalPage As Integer = cell.Image.Page
            cell.Image.Page = cell.ActiveSubCell + 1
            originalBitmap = cell.Image.Clone()
            cell.Image.Page = orignalPage

            firstTime = False
         Else
            Dim orignalPage As Integer = cell.Image.Page
            cell.Image.Page = cell.ActiveSubCell + 1
            CopyBitmapData(cell.Image, originalBitmap)
            cell.Image.Page = orignalPage
         End If

         ApplyFilter()
      End Sub

      Public Sub FilterCancel_Click(firstTime As Boolean, originalBitmap As RasterImage, invalidate As Boolean)
         If Not firstTime Then
            Dim cell As MedicalViewerCell = GetSelectedCell()

            Dim orignalPage As Integer = cell.Image.Page
            cell.Image.Page = cell.ActiveSubCell + 1
            CopyBitmapData(cell.Image, originalBitmap)
            cell.Image.Page = orignalPage

            If invalidate Then
               cell.Invalidate()
            End If

            originalBitmap.Dispose()
         End If
      End Sub

      Public Sub FilterRunCommand(command As RasterCommand, invalidate As Boolean)
         Dim cell As MedicalViewerCell = GetSelectedCell()

         Dim orignalPage As Integer = cell.Image.Page
         cell.Image.Page = cell.ActiveSubCell + 1
         Try
            command.Run(cell.Image)
         Catch ex As System.Exception
            Messager.ShowError(Me, ex)
         End Try
         cell.Image.Page = orignalPage

         If invalidate Then
            cell.Invalidate()
         End If
      End Sub

      Private Sub stentToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _stentMenuItem.DropDownOpening

         Dim enableEffects As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell()
         _stentEnhancementMenuItem.Enabled = enableEffects
         _unselectFramesMenuItem.Enabled = enableEffects
         _moveMarkersAction.Enabled = enableEffects

      End Sub

      Private Sub filtersToolStripMenuItem1_DropDownOpening(sender As Object, e As EventArgs) Handles _filtersMenuItem.DropDownOpening

         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         Dim enableEffects As Boolean = (Viewer.Cells.Count <> 0) AndAlso IsThereASelectedCell() AndAlso Not cell.Frozen

         _miEffectInvert.Enabled = InlineAssignHelper(multiscaleEnhancementToolStripMenuItem.Enabled, InlineAssignHelper(adaptiveContrastToolStripMenuItem.Enabled, InlineAssignHelper(unsharpMaskToolStripMenuItem.Enabled, InlineAssignHelper(histogramEqualizeToolStripMenuItem.Enabled, InlineAssignHelper(saveToolStripMenuItem.Enabled, enableEffects)))))

         _miEffectCLAHE.Enabled = (enableEffects AndAlso (GetSelectedCell().Image.BitsPerPixel = 16 OrElse GetSelectedCell().Image.BitsPerPixel = 8))

         If cell IsNot Nothing AndAlso _orignalImagesList(GetCellIndex(cell)) IsNot Nothing AndAlso _orignalImagesList(GetCellIndex(cell))(cell.ActiveSubCell) IsNot Nothing Then
            resetToolStripMenuItem.Enabled = True
         Else
            resetToolStripMenuItem.Enabled = False
         End If


      End Sub

      Private Sub _moveMarkersAction_Click(sender As Object, e As EventArgs) Handles _moveMarkersAction.Click

         If _stentCell IsNot Nothing AndAlso _stentCommand IsNot Nothing Then
            If _moveMarkersAction.Checked = False Then
               _stentCell.SetAction(CType(101, MedicalViewerActionType), MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
               _currentAction = CType(101, MedicalViewerActionType)
               _stentCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
               CheckMoveMarkersAction(True)
            Else
               _stentCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
               _currentAction = _leftButtonAction
               CheckMoveMarkersAction(False)
            End If
         End If

      End Sub

      Public Sub CheckMoveMarkersAction(check As Boolean)
         _moveMarkersAction.Checked = check
      End Sub

      Private Function moveMarker(e As MedicalViewerCellMouseEventArgs, cell As MedicalViewerMultiCell) As LeadPoint

         Dim X As Integer = e.X
         Dim Y As Integer = e.Y

         Dim cellRect As Rectangle = cell.GetDisplayedImageRectangle()
         Dim image As RasterImage = cell.Image

         Dim scaleX As Single = cellRect.Width * 1.0F / image.Width
         Dim scaleY As Single = cellRect.Height * 1.0F / image.Height

         X = CInt(Math.Truncate((X - cellRect.Left) * 1.0F / scaleX + 0.5))
         Y = CInt(Math.Truncate((Y - cellRect.Top) * 1.0F / scaleY + 0.5))

         Return New LeadPoint(X, Y)

      End Function

      Private Sub imageAlignmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles imageAlignmentToolStripMenuItem.Click
#If LEADTOOLS_V19_OR_LATER Then
         If _medicalViewer.Cells.Count < 2 Then
            Return
         End If
         If _alignmentDlg IsNot Nothing Then
            Return
         End If


         _referenceCell = Nothing
         _templateCell = Nothing
         For Each cell As MedicalViewerMultiCell In _medicalViewer.Cells
            If cell.Selected Then
               If _referenceCell Is Nothing Then
                  _referenceCell = cell
               Else
                  _templateCell = cell
                  Exit For
               End If
            End If
         Next

         If _templateCell Is Nothing OrElse _referenceCell Is Nothing Then
            Return
         End If

         If _referenceCell.Image.BitsPerPixel <> _templateCell.Image.BitsPerPixel Then
            Messager.ShowError(Me, "The two images should be of the same bit depth (Bits Per Pixel)")
            _templateCell = Nothing
            _referenceCell = Nothing
            Return
         End If

         AddHandler _referenceCell.PostPaint, AddressOf alignmentCell_PostPaint
         AddHandler _templateCell.PostPaint, AddressOf alignmentCell_PostPaint

         Dim SelectPointsAction As MedicalViewerActionType = CType(102, MedicalViewerActionType)
         _referenceCell.AddAction(SelectPointsAction)
         _templateCell.AddAction(SelectPointsAction)
         _referenceCell.SetAction(SelectPointsAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         _templateCell.SetAction(SelectPointsAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         CheckSelectPoints(True)
         _currentAction = SelectPointsAction

         _refPointAdded = False

         _referenceList = New List(Of LeadPoint)()
         _templateList = New List(Of LeadPoint)()

         _alignPointIdx = -1

         AddHandler _referenceCell.CellMouseDown, AddressOf alignmentCell_CellMouseDown
         AddHandler _templateCell.CellMouseDown, AddressOf alignmentCell_CellMouseDown

         AddHandler _referenceCell.CellMouseMove, AddressOf alignmentCell_CellMouseMove
         AddHandler _referenceCell.CellMouseUp, AddressOf alignmentCell_CellMouseUp

         AddHandler _templateCell.CellMouseMove, AddressOf alignmentCell_CellMouseMove
         AddHandler _templateCell.CellMouseUp, AddressOf alignmentCell_CellMouseUp

         AddHandler _referenceCell.Disposed, AddressOf _referenceCell_Disposed
         AddHandler _templateCell.Disposed, AddressOf _templateCell_Disposed

         _alignmentDlg = New ImageAlignmentDialog(Me)
         _alignmentDlg.Show(Me)
#End If
      End Sub

      Private Sub _referenceCell_Disposed(sender As Object, e As EventArgs)
#If LEADTOOLS_V19_OR_LATER Then
         _referenceCell = Nothing
         If _alignmentDlg IsNot Nothing Then
            _alignmentDlg.Close()
         End If
#End If
      End Sub

      Private Sub _templateCell_Disposed(sender As Object, e As EventArgs)
#If LEADTOOLS_V19_OR_LATER Then
         _templateCell = Nothing
         If _alignmentDlg IsNot Nothing Then
            _alignmentDlg.Close()
         End If
#End If
      End Sub

      Private Sub _registeredImageCell_Disposed(sender As Object, e As EventArgs)
#If LEADTOOLS_V19_OR_LATER Then
         _registeredImageCell = Nothing
#End If
      End Sub

      Private Sub alignmentCell_CellMouseDown(sender As Object, e As MedicalViewerCellMouseEventArgs)
#If LEADTOOLS_V19_OR_LATER Then
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         Dim list As List(Of LeadPoint) = Nothing
         If cell Is _referenceCell Then
            list = _referenceList
         ElseIf cell Is _templateCell Then
            list = _templateList
         End If

         If _currentAction = CType(102, MedicalViewerActionType) Then
            If e.Button = MouseButtons.Left Then
               If cell.GetDisplayedImageRectangle().Contains(e.X, e.Y) Then
                  Dim currentPoint As LeadPoint = moveMarker(e, cell)
                  Dim idx As Integer = 0
                  _alignPointIdx = -1
                  For Each point As LeadPoint In list
                     Dim rect As Rectangle = CreateRectFromPoint(point, 5)
                     If rect.Contains(currentPoint.X, currentPoint.Y) Then
                        _alignPointIdx = idx
                        Exit For
                     End If
                     idx += 1
                  Next
                  If _refPointAdded AndAlso cell Is _templateCell Then
                     If _alignPointIdx = -1 Then
                        list.Add(currentPoint)
                        cell.Invalidate()
                        _refPointAdded = False
                        _alignmentDlg.EnableApplyButton(True)
                     End If
                  ElseIf Not _refPointAdded AndAlso cell Is _referenceCell Then
                     If _alignPointIdx = -1 Then
                        list.Add(currentPoint)
                        cell.Invalidate()
                        _refPointAdded = True
                     End If
                  End If
               End If
            End If
         End If
#End If
      End Sub

      Private Sub alignmentCell_CellMouseUp(sender As Object, e As MedicalViewerCellMouseEventArgs)
#If LEADTOOLS_V19_OR_LATER Then
         If _currentAction = CType(102, MedicalViewerActionType) Then
            If e.Button = MouseButtons.Left Then
               _alignPointIdx = -1
               Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
               cell.Invalidate()
            End If
         End If
#End If
      End Sub

      Private Sub alignmentCell_CellMouseMove(sender As Object, e As MedicalViewerCellMouseEventArgs)
#If LEADTOOLS_V19_OR_LATER Then
         If _currentAction = CType(102, MedicalViewerActionType) Then
            Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
            Dim list As List(Of LeadPoint) = Nothing
            If cell Is _referenceCell Then
               list = _referenceList
            ElseIf cell Is _templateCell Then
               list = _templateList
            End If

            If cell.GetDisplayedImageRectangle().Contains(e.X, e.Y) Then
               If cell IsNot Nothing Then
                  If _alignPointIdx <> -1 Then
                     list.RemoveAt(_alignPointIdx)
                     list.Insert(_alignPointIdx, moveMarker(e, cell))
                     _referenceCell.Invalidate()
                     _templateCell.Invalidate()
                     _alignmentDlg.EnableApplyButton(True)
                  End If
               End If
            End If
         End If
#End If
      End Sub

      Private Sub alignmentCell_PostPaint(sender As Object, e As MedicalViewerPaintInformationEventArgs)
#If LEADTOOLS_V19_OR_LATER Then
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         Dim list As List(Of LeadPoint) = Nothing
         If cell Is _referenceCell Then
            list = _referenceList
         ElseIf cell Is _templateCell Then
            list = _templateList
         End If

         If list IsNot Nothing Then
            If list.Count > 0 Then
               If e.SubCellIndex = 0 Then
                  Dim displayRect As Rectangle = cell.GetDisplayedClippedImageRectangle()
                  Dim index As Integer = 0
                  For Each point As LeadPoint In list
                     Dim image As RasterImage = cell.Image
                     Dim rect As Rectangle = cell.GetDisplayedImageRectangle()

                     Dim scaleX As Single = rect.Width * 1.0F / image.Width
                     Dim scaleY As Single = rect.Height * 1.0F / image.Height

                     Dim outPoint As New LeadPoint(CInt(Math.Truncate((point.X) * scaleX + rect.Left + 0.5)), CInt(Math.Truncate((point.Y) * scaleY + rect.Top + 0.5)))

                     If Not displayRect.IsEmpty Then
                        Dim brush As Brush = Brushes.Red
                        If index = _alignPointIdx Then
                           brush = Brushes.Yellow
                        End If
                        e.Graphics.FillEllipse(brush, CreateRectFromPoint(outPoint, 3))
                     End If
                     index += 1
                  Next
               End If
            End If
         End If
#End If
      End Sub

      Public Sub ApplyAlignment()
#If LEADTOOLS_V19_OR_LATER Then
         If _referenceCell Is Nothing OrElse _templateCell Is Nothing OrElse _referenceList Is Nothing OrElse _templateList Is Nothing Then
            Return
         End If

         If _referenceList.Count < 1 Then
            Return
         End If

         If _refPointAdded Then
            Return
         End If

         _alignmentDlg.EnableApplyButton(False)
         _alignmentDlg.OldOptions = _alignmentDlg.Options

         Dim command As New AlignImagesCommand()

         command.RegistrationMethod = _alignmentDlg.Options

         command.ReferenceImagePoints = _referenceList.ToArray()
         command.TemplateImagePoints = _templateList.ToArray()

         command.TemplateImage = _templateCell.Image.Clone()

         Try
            command.Run(_referenceCell.Image.Clone())
         Catch ex As System.Exception
            Messager.ShowError(Me, ex)
            Return
         End Try

         If _registeredImageCell Is Nothing Then
            _medicalViewer.Rows = 2
            _medicalViewer.Columns = 2

            Dim newCell As New MedicalViewerMultiCell()

            _medicalViewer.Cells.Add(newCell)

            InitializeCell(newCell)
            InitAutomation(newCell)
            InitializeAutomationManager(newCell)

            newCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.UserData, "Registered Image")
            newCell.SetTag(1, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale)
            newCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)
            _registeredImageCell = newCell

            AddHandler _registeredImageCell.Disposed, AddressOf _registeredImageCell_Disposed
            _registeredImageCell.Image = command.RegisteredImage.Clone()
            _registeredImageCell.FitImageToCell = False
            _registeredImageCell.SetScaleMode(MedicalViewerScaleMode.Fit)


            _registeredImageCell.Invalidate()
         Else
            If command.RegisteredImage IsNot Nothing Then
               If _registeredImageCell.Image IsNot Nothing Then
                  _registeredImageCell.Image.Dispose()
               End If

               _registeredImageCell.Image = command.RegisteredImage.Clone()
               _registeredImageCell.SetScaleMode(MedicalViewerScaleMode.Fit)

               command.RegisteredImage.Dispose()
            End If
         End If
#End If
      End Sub

      Public Sub FinishAlignment()
#If LEADTOOLS_V19_OR_LATER Then

         If _referenceCell IsNot Nothing Then
            RemoveHandler _referenceCell.PostPaint, AddressOf alignmentCell_PostPaint
            RemoveHandler _referenceCell.CellMouseDown, AddressOf alignmentCell_CellMouseDown
            RemoveHandler _referenceCell.CellMouseMove, AddressOf alignmentCell_CellMouseMove
            RemoveHandler _referenceCell.CellMouseUp, AddressOf alignmentCell_CellMouseUp
            RemoveHandler _referenceCell.Disposed, AddressOf _referenceCell_Disposed

            _referenceCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            _referenceCell.Invalidate()
         End If
         If _templateCell IsNot Nothing Then
            RemoveHandler _templateCell.PostPaint, AddressOf alignmentCell_PostPaint
            RemoveHandler _templateCell.CellMouseDown, AddressOf alignmentCell_CellMouseDown
            RemoveHandler _templateCell.CellMouseMove, AddressOf alignmentCell_CellMouseMove
            RemoveHandler _templateCell.CellMouseUp, AddressOf alignmentCell_CellMouseUp
            RemoveHandler _templateCell.Disposed, AddressOf _templateCell_Disposed

            _templateCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            _templateCell.Invalidate()
         End If
         If _registeredImageCell IsNot Nothing Then
            RemoveHandler _registeredImageCell.Disposed, AddressOf _registeredImageCell_Disposed
         End If
         CheckSelectPoints(False)
         _alignmentDlg = Nothing
         _templateCell = Nothing
         _referenceCell = Nothing
         _templateList = Nothing
         _referenceCell = Nothing

         _registeredImageCell = Nothing
#End If
      End Sub

      Public Sub ResetAlignment()
#If LEADTOOLS_V19_OR_LATER Then
         _refPointAdded = False
         _templateList = New List(Of LeadPoint)()
         _referenceList = New List(Of LeadPoint)()
         _templateCell.Invalidate()
         _referenceCell.Invalidate()
#End If
      End Sub

      Private Sub dISToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _alignmentMenuItem.DropDownOpening
         imageAlignmentToolStripMenuItem.Enabled = (IsThereASelectedCell() And _medicalViewer.Cells.Count >= 2)
      End Sub

      Private Sub _selectPointsActionMenuItem_Click(sender As Object, e As EventArgs) Handles _selectPointsActionMenuItem.Click
#If LEADTOOLS_V19_OR_LATER Then
         If _referenceCell Is Nothing OrElse _templateCell Is Nothing OrElse _referenceList Is Nothing OrElse _templateList Is Nothing Then
            Return
         End If
         If _selectPointsActionMenuItem.Checked = False Then
            _referenceCell.SetAction(CType(102, MedicalViewerActionType), MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            _templateCell.SetAction(CType(102, MedicalViewerActionType), MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            _currentAction = CType(102, MedicalViewerActionType)
            CheckSelectPoints(True)
         Else
            _referenceCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            _templateCell.SetAction(_leftButtonAction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            _currentAction = _leftButtonAction
            CheckSelectPoints(False)
         End If
#End If
      End Sub

      Public Sub CheckSelectPoints(value As Boolean)
         _selectPointsActionMenuItem.Checked = value
      End Sub

      Private Sub cLAHEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _miEffectCLAHE.Click

         Dim cell As MedicalViewerCell = GetSelectedCell()
         If cell IsNot Nothing Then
            ShowViewerDialogs(New CLAHEDialog(Me, cell))
         End If

      End Sub

      Private Sub saveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveToolStripMenuItem.Click
         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         Dim RC As New RasterCodecs()

         Dim _saver As New ImageFileSaver()



         Try
            If cell.Image.HasRegion Then
               cell.Image.MakeRegionEmpty()
            End If

            DemosGlobal.SetDefaultComments(cell.Image, RC)
            _saver.FormatIndex = RasterDialogFileTypesIndex.Tiff
            _saver.BitsPerPixel = 16
            _saver.Save(Me, RC, cell.Image)
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, _saver.FileName, ex)
         End Try

      End Sub

      Private Sub CopyBitmapData(destImage As RasterImage, srcImage As RasterImage)
         srcImage.Access()
         destImage.Access()

         Dim buffer As Byte() = New Byte(srcImage.BytesPerLine - 1) {}

         For y As Integer = 0 To srcImage.Height - 1
            srcImage.GetRow(y, buffer, 0, buffer.Length)
            destImage.SetRow(y, buffer, 0, buffer.Length)
         Next

         srcImage.Release()
         destImage.Release()
      End Sub


      '#if LEADTOOLS_V18_OR_LATER
      '        private RasterImage _originalAvgCellImage = null;
      '        private RasterImage _originalCellImage = null;
      '#endif

      Private Sub resetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles resetToolStripMenuItem.Click

         If MessageBox.Show("Are you sure you want to reset the Image", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)

            Dim orignalPage As Integer = cell.Image.Page
            cell.Image.Page = cell.ActiveSubCell + 1
            Dim orignalImage As RasterImage = _orignalImagesList(GetCellIndex(cell))(cell.ActiveSubCell)
            CopyBitmapData(cell.Image, orignalImage)

            cell.Image.Page = orignalPage

            Dim isEnhImageCell As Boolean = False
            Dim enhImageCellData As StentData = Nothing
            For Each data As StentData In _stentDataList
               If data.EnhImageCell Is cell Then
                  isEnhImageCell = True
                  enhImageCellData = data
                  Exit For
               End If
            Next

            If isEnhImageCell AndAlso enhImageCellData IsNot Nothing Then
               _enhImageCell.SetWindowLevel(enhImageCellData.EnhImageCellWLWidth, enhImageCellData.EnhImageCellWLCenter)

               If _enhImageCell.IsImageInverted(cell.ActiveSubCell) Then
                  _enhImageCell.InvertImage(cell.ActiveSubCell)

               End If
            Else
               Dim windowLevelValues As MedicalViewerWindowLevelValues = cell.GetDefaultWindowLevelValues(cell.ActiveSubCell)

               cell.SetWindowLevel(windowLevelValues.Width, windowLevelValues.Center)

               If cell.IsImageInverted(cell.ActiveSubCell) Then
                  cell.InvertImage(cell.ActiveSubCell)
               End If
            End If

            orignalImage.Dispose()
            _orignalImagesList(GetCellIndex(cell))(cell.ActiveSubCell) = Nothing

            cell.Invalidate()
         End If
      End Sub

      Public Sub SetAction(actionType As MedicalViewerActionType, mouseButton As MedicalViewerMouseButtons, applyingOperation As MedicalViewerActionFlags)
         If mouseButton = MedicalViewerMouseButtons.Left Then
            CurrentAction = actionType
            LeftButtonAction = actionType
            CheckMoveMarkersAction(False)
            CheckSelectPoints(False)
         End If
         If mouseButton = MedicalViewerMouseButtons.Right Then
            RightButtonAction = actionType
         End If

         'cell.SetAction(actionType, mouseButton, applyingOperation);

         For Each viewerCell As MedicalViewerBaseCell In _medicalViewer.Cells
            viewerCell.SetAction(actionType, mouseButton, applyingOperation)
         Next
      End Sub

      Private Sub automation_OnShowContextMenu(sender As Object, e As AnnAutomationEventArgs)
         Dim _viewer As MedicalViewerBaseCell = CType(_medicalViewer.Cells(0), MedicalViewerBaseCell)
         Dim point As Point = _viewer.PointToClient(Cursor.Position)
         If e IsNot Nothing AndAlso e.[Object] IsNot Nothing Then
            _viewer.AutomationInvalidate(LeadRectD.Empty)
            Dim annAutomationObject As AnnAutomationObject = TryCast(e.[Object], AnnAutomationObject)
            If annAutomationObject IsNot Nothing Then
               Dim menu As ObjectContextMenu = TryCast(annAutomationObject.ContextMenu, ObjectContextMenu)
               If menu IsNot Nothing Then
                  menu.Automation = TryCast(sender, AnnAutomation)
                  menu.Show(_viewer, point)
               End If
            End If
         Else
            Dim defaultMenu As New ManagerContextMenu()
            defaultMenu.Automation = TryCast(sender, AnnAutomation)
            defaultMenu.Show(_viewer, point)
         End If
      End Sub



      Private Sub Rotate(angle As Integer)

         For Each cell As MedicalViewerCell In Viewer.Cells
            If cell.Selected Then
               ' Check whether to apply the command to all the image pages or only of the active page
               If _miEffectOptionsApplyToAllSubCells.Checked Then
                  ' Apply the command to all the image pages
                  Dim index As Integer
                  For index = 1 To cell.Image.PageCount
                     cell.Image.Page = index
                     cell.Image.RotateViewPerspective(angle)
                  Next
               Else
                  ' Apply the command to only the active page.
                  Dim stack As MedicalViewerStack = CType(cell.GetActionProperties(MedicalViewerActionType.Stack, Viewer.Cells.IndexOf(cell)), MedicalViewerStack)
                  cell.Image.Page = stack.ScrollValue + stack.ActiveSubCell + 1
                  cell.Image.RotateViewPerspective(angle)
               End If
               ' Redraw the cell to adopt the new changes.
               cell.UpdateView()
               cell.Invalidate()
            End If
         Next
      End Sub

      Private Sub _miRotate90_Click(sender As Object, e As EventArgs) Handles _miRotate90.Click
         Rotate(90)
      End Sub

      Private Sub _miRotate180_Click(sender As Object, e As EventArgs) Handles _miRotate180.Click
         Rotate(180)
      End Sub

      Private Sub _miRotateMinus90_Click(sender As Object, e As EventArgs) Handles _miRotateMinus90.Click
         Rotate(-90)
      End Sub

      Private Sub _miRotateMinus180_Click(sender As Object, e As EventArgs) Handles _miRotateMinus180.Click
         Rotate(-180)
      End Sub

      Private Sub _miEditAnnotation_Click(sender As Object, e As EventArgs) Handles _miEditAnnotation.Click
         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         ShowViewerDialogs(New AnnotationPropertiesDialog(cell))
      End Sub

      Private Sub _annotationMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _annotationMenuItem.DropDownOpening
         Dim cell As MedicalViewerMultiCell = CType(GetSelectedCell(), MedicalViewerMultiCell)
         If cell Is Nothing Then
            _miEditAnnotation.Enabled = False
            Return
         End If

         Dim currentObject As AnnObject = cell.Automation.CurrentEditObject
         If TypeOf currentObject Is AnnPointObject Then
            _miEditAnnotation.Enabled = False
         Else
            If Not currentObject Is Nothing Then
               _miEditAnnotation.Enabled = (currentObject.SupportsStroke OrElse currentObject.SupportsFont OrElse currentObject.SupportsFill)
            Else
               _miEditAnnotation.Enabled = False
            End If
         End If
      End Sub
      Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
         target = value
         Return value
      End Function
   End Class


   ' A class that is derived from System.Windows.Forms.Label control
   Partial Public Class ColorBox
      Inherits System.Windows.Forms.Label
      Private _color As Color


      Public Sub New()
         _color = Color.Transparent
      End Sub

      Public Property BoxColor() As Color
         Get
            Return Color.FromArgb(0, _color.R, _color.G, _color.B)
         End Get
         Set(value As Color)
            _color = Color.FromArgb(255, value)
            If Me.Enabled Then
               BackColor = _color
            End If
         End Set
      End Property

      Protected Overrides Sub OnBackColorChanged(e As EventArgs)
         MyBase.OnBackColorChanged(e)
         If BackColor <> Color.Transparent Then
            _color = BackColor
         End If
      End Sub

      Protected Overrides Sub OnEnabledChanged(e As EventArgs)
         MyBase.OnEnabledChanged(e)
         If Me.Enabled Then
            BackColor = _color
         Else
            BackColor = Color.Transparent
         End If
      End Sub

      Protected Overrides Sub OnDoubleClick(e As EventArgs)
         MainForm.ShowColorDialog(Me)
         _color = BackColor
         MyBase.OnDoubleClick(e)
      End Sub
   End Class


   ' A class that is derieved from TextBox control, that allows only
   ' 1) The numeric values.
   ' 2) The values that fall within the given range.
   Partial Public Class FNumericTextBox
      Inherits System.Windows.Forms.TextBox
      Private _maximumAllowed As Double
      Private _minimumAllowed As Double
      Private _oldText As String

      Public Sub New()
         _maximumAllowed = 1000.0
         _minimumAllowed = -1000.0
         _oldText = ""
      End Sub

      <Description("The minimum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MinimumAllowed() As Double
         Get
            Return _minimumAllowed
         End Get
         Set(value As Double)
            _minimumAllowed = value
         End Set
      End Property

      <Description("The maximum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MaximumAllowed() As Double
         Get
            Return _maximumAllowed
         End Get
         Set(value As Double)
            _maximumAllowed = value
         End Set
      End Property

      <Description("The numeric value of the Text box"), Category("Current Value")> _
      Public Property Value() As Double
         Get
            If Me.Text.Trim() = "" Then
               Return _minimumAllowed
            Else
               Return Convert.ToDouble(Me.Text)
            End If
         End Get
         Set(value As Double)
            Me.Text = value.ToString()
         End Set
      End Property

      ' Is the entered number within the specified valid range
      Private Function IsAllowed(text As String) As Boolean
         Dim isAllowed__1 As Boolean = True

         Try
            Dim newNumber As Double = Convert.ToDouble(text)
            If (newNumber > _maximumAllowed) OrElse (newNumber < _minimumAllowed) Then
               isAllowed__1 = False
            End If
         Catch
            ' This happen if the entered value is not a numeric.
            isAllowed__1 = False
         End Try

         Return isAllowed__1
      End Function

      Protected Overrides Sub OnTextChanged(e As EventArgs)
         If Not IsAllowed(Me.Text) Then
            ' If this condition doesn't exist, the user will be bugged. (trust me).
            If _minimumAllowed <= 0 Then
               Me.Text = _oldText
            End If
         Else
            _oldText = Me.Text
         End If

         MyBase.OnTextChanged(e)
      End Sub

      Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
         ' Increase or decrease the current value by 1 if the user presses the UP or DOWN
         ' and test if the new value is allowed
         If (e.KeyCode = Keys.Up) OrElse (e.KeyCode = Keys.Down) Then
            Dim value As Double = Convert.ToDouble(Me.Text)

            value = If((e.KeyCode = Keys.Up), value + 0.1, value - 0.1)

            If IsAllowed(value.ToString()) Then
               Me.Text = value.ToString()
            End If
         End If

         MyBase.OnKeyDown(e)
      End Sub

      Protected Overrides Sub OnLostFocus(e As EventArgs)
         Dim value As Double = If((Me.Text.Trim() = ""), _minimumAllowed, Convert.ToDouble(Me.Text))
         If value < _minimumAllowed Then
            Me.Text = _minimumAllowed.ToString()
         End If

         MyBase.OnLostFocus(e)
      End Sub

      Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
         ' if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         ' since the user is not entering a new character...
         If ((Control.ModifierKeys And Keys.Control) = 0) AndAlso ((Control.ModifierKeys And Keys.Alt) = 0) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Enter)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Escape)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Back)) Then
            '#Region "Check if the entered character is valid for Numeric format"
            ' Validate the entered character
            If Not [Char].IsNumber(e.KeyChar) Then

               '#Region "Check If the user has entered Minus character"
               ' Here we check if the user wants to enter the "-" character.
               ' there is no Minus character
               ' the cursor at the begining
               ' the minimum allowed accept negative values
               If Not ((Me.Text.IndexOf("-"c) = -1) AndAlso (Me.SelectionStart = 0) AndAlso (_minimumAllowed < 0) AndAlso (e.KeyChar = "-"c)) Then
                  ' the character entered was a Minus character
                  If Not ((e.KeyChar = "."c) AndAlso (Me.Text.IndexOf("."c) = -1)) Then
                     e.KeyChar = [Char].MinValue
                  End If
                  '#End Region
               End If
            End If
            '#End Region

            If _minimumAllowed <= 0 Then
               '#Region "Checkinng if the value falles within the given range"
               If e.KeyChar <> [Char].MinValue Then
                  ' Create the string that will be displayed, and check whether it's valid or not.

                  ' Remove the selected character(s).
                  Dim newString As String = Me.Text.Remove(Me.SelectionStart, Me.SelectionLength)
                  ' Insert the new character.
                  newString = newString.Insert(Me.SelectionStart, e.KeyChar.ToString())
                  If Not IsAllowed(newString) Then
                     ' the new string is not valid, cancel the whole operation.
                     e.KeyChar = [Char].MinValue
                  End If
               End If
               '#End Region
            End If
         End If
         MyBase.OnKeyPress(e)
      End Sub
   End Class


   Partial Public Class CursorButton
      Inherits System.Windows.Forms.Button
      Private _buttonCursor As Cursor

      Public Sub New()
         _buttonCursor = Nothing
      End Sub

      <Description("The Cursor"), Category("Cursor")> _
      Public Property ButtonCursor() As Cursor
         Get
            Return _buttonCursor
         End Get
         Set(value As Cursor)
            _buttonCursor = value
         End Set
      End Property

      Protected Overrides Sub OnClick(e As EventArgs)
         MyBase.OnClick(e)
         Dim openDialog As New OpenFileDialog()
         openDialog.Filter = "Cursor files (*.cur) | *.cur"
         openDialog.RestoreDirectory = True

         If openDialog.ShowDialog() = DialogResult.OK Then
            Try
               _buttonCursor = New System.Windows.Forms.Cursor(openDialog.FileName)
            Catch ex As System.Exception
               Messager.ShowError(Me, ex)

            End Try
         End If
      End Sub

      Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
         MyBase.OnPaint(pevent)
         If _buttonCursor IsNot Nothing Then
            Dim averageWidth As Integer = (pevent.ClipRectangle.Width - _buttonCursor.Size.Width) \ 2
            Dim averageHeight As Integer = (pevent.ClipRectangle.Height - _buttonCursor.Size.Height) \ 2

            _buttonCursor.Draw(pevent.Graphics, New Rectangle(averageWidth, averageHeight, _buttonCursor.Size.Width, _buttonCursor.Size.Height))
         End If
      End Sub
   End Class

   ' A class that is derieved from TextBox control, that allows only
   ' 1) The numeric values.
   ' 2) The values that fall within the given range.
   Partial Public Class NumericTextBox
      Inherits System.Windows.Forms.TextBox
      Private _maximumAllowed As Integer
      Private _minimumAllowed As Integer
      Private _oldText As String

      Public Sub New()
         _maximumAllowed = 1000
         _minimumAllowed = -1000
         _oldText = ""
      End Sub

      <Description("The minimum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MinimumAllowed() As Integer
         Get
            Return _minimumAllowed
         End Get
         Set(value As Integer)
            _minimumAllowed = value
         End Set
      End Property

      <Description("The maximum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MaximumAllowed() As Integer
         Get
            Return _maximumAllowed
         End Get
         Set(value As Integer)
            _maximumAllowed = value
         End Set
      End Property

      <Description("The maximum allowed value to be entered"), Category("Current Value")> _
      Public Property Value() As Integer
         Get
            If Me.Text.Trim() = "" Then
               Return _minimumAllowed
            Else
               Return Convert.ToInt32(Me.Text)
            End If
         End Get
         Set(value As Integer)
            Me.Text = value.ToString()
         End Set
      End Property

      ' Is the entered number within the specified valid range
      Private Function IsAllowed(text As String) As Boolean
         Dim isAllowed__1 As Boolean = True

         Try
            Dim newNumber As Integer = Convert.ToInt32(text)
            If (newNumber > _maximumAllowed) OrElse (newNumber < _minimumAllowed) Then
               isAllowed__1 = False
            End If
         Catch
            ' This happen if the entered value is not a numeric.
            isAllowed__1 = False
         End Try

         Return isAllowed__1
      End Function

      Protected Overrides Sub OnTextChanged(e As EventArgs)
         If Not IsAllowed(Me.Text) Then
            If _minimumAllowed <= 1 Then
               Me.Text = _oldText
            End If
         Else
            _oldText = Me.Text
         End If

         MyBase.OnTextChanged(e)
      End Sub

      Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
         ' Increase or decrease the current value by 1 if the user presses the UP or DOWN
         ' and test if the new value is allowed
         If (e.KeyCode = Keys.Up) OrElse (e.KeyCode = Keys.Down) Then
            Dim value As Integer = Convert.ToInt32(Me.Text)

            value = If((e.KeyCode = Keys.Up), value + 1, value - 1)

            If IsAllowed(value.ToString()) Then
               Me.Text = value.ToString()
            End If
         End If

         MyBase.OnKeyDown(e)
      End Sub

      Protected Overrides Sub OnLostFocus(e As EventArgs)
         Dim value As Integer = Convert.ToInt32(Me.Text)
         If value < _minimumAllowed Then
            Me.Text = _minimumAllowed.ToString()
         End If

         MyBase.OnLostFocus(e)
      End Sub

      Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
         ' if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         ' since the user is not entering a new character...
         If ((Control.ModifierKeys And Keys.Control) = 0) AndAlso ((Control.ModifierKeys And Keys.Alt) = 0) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Enter)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Escape)) Then
            '#Region "Check if the entered character is valid for Numeric format"
            ' Validate the entered character
            If Not [Char].IsNumber(e.KeyChar) Then

               '#Region "Check If the user has entered Minus character"
               ' Here we check if the user wants to enter the "-" character.
               ' there is no Minus character
               ' the cursor at the begining
               ' the minimum allowed accept negative values
               If Not ((Me.Text.IndexOf("-"c) = -1) AndAlso (Me.SelectionStart = 0) AndAlso (_minimumAllowed < 0) AndAlso (e.KeyChar = "-"c)) Then
                  ' the character entered was a Minus character
                  e.KeyChar = [Char].MinValue
                  '#End Region
               End If
            End If
            '#End Region

            If _minimumAllowed <= 1 Then
               '#Region "Checkinng if the value falles within the given range"
               If e.KeyChar <> [Char].MinValue Then
                  ' Create the string that will be displayed, and check whether it's valid or not.

                  ' Remove the selected character(s).
                  Dim newString As String = Me.Text.Remove(Me.SelectionStart, Me.SelectionLength)
                  ' Insert the new character.
                  newString = newString.Insert(Me.SelectionStart, e.KeyChar.ToString())
                  If Not IsAllowed(newString) Then
                     ' the new string is not valid, cancel the whole operation.
                     e.KeyChar = [Char].MinValue
                  End If
               End If
               '#End Region
            End If
         End If
         MyBase.OnKeyPress(e)
      End Sub
   End Class
End Namespace
