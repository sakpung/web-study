' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.WinForms
Imports Leadtools.Dicom
Imports Leadtools.Codecs
Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports Leadtools.ImageProcessing

Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Diagnostics
Imports Leadtools.Annotations.Engine
Imports System

Namespace FusionDemo
   Partial Public Class MainForm
      Inherits Form
      Private _fusionListNames As List(Of List(Of FusionData)())
      Private seriesBrowserDialog As SeriesBrowser
      Private _viewer As MedicalViewer
      Private counter As CounterDialog
      Private _adjustFusionImage As AdjustFusionImage = Nothing
      Private _cellData As CellData
      Private _counter As Integer
      Private _alwaysInterpolate As Boolean
      Private _actionType As MedicalViewerActionType
      Private _openInitialPath As String = String.Empty

      Public Property AlwaysInterpolate() As Boolean
         Get
            Return _alwaysInterpolate
         End Get

         Set(value As Boolean)
            _alwaysInterpolate = value
         End Set
      End Property

      <STAThread()> _
      Shared Sub Main(args As String())
         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Medical) Then
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
         End If
         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Public Sub New()
         InitializeComponent()
         InitClass()

         _fusionListNames = New List(Of List(Of FusionData)())()
      End Sub

      Protected Overrides Sub Finalize()
         Try
            If _viewer IsNot Nothing Then
               RemoveHandler _viewer.DeleteCell, AddressOf MedicalViewer_DeleteCell
               RemoveHandler _viewer.SelectedCellsChanged, AddressOf _viewer_SelectedCellsChanged
            End If
         Finally
            MyBase.Finalize()
         End Try
      End Sub


      Private Sub StartProgress(counterDialog As CounterDialog)
         counterDialog.Show()
      End Sub

      Private Sub EndProgress(counterDialog As CounterDialog)
         If counterDialog IsNot Nothing Then
            counterDialog.Close()
            counterDialog.Dispose()
            counterDialog = Nothing
         End If
      End Sub

      Private Sub InitializeCell(cell As MedicalViewerMultiCell)
         cell.ShowCellScroll = True
         cell.PaintingMethod = MedicalViewerPaintingMethod.Bicubic
         cell.FitImageToCell = False
         cell.SetScaleMode(MedicalViewerScaleMode.Fit)
         cell.SnapRulers = False

         AddBasicActionsFor2DCell(cell)

         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)

         cell.SetActionKeys(MedicalViewerActionType.Stack, New MedicalViewerKeys(Keys.PageUp, Keys.PageDown, Keys.None, Keys.None, MedicalViewerModifiers.None))

         cell.SetActionKeys(MedicalViewerActionType.WindowLevel, New MedicalViewerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, MedicalViewerModifiers.Ctrl))

         cell.AlwaysInterpolate = AlwaysInterpolate

         SetAction(cell, _actionType)

         cell.Selected = True

         AddHandler cell.SelectedSubCellChanged, AddressOf cell_SelectedSubCellChanged

      End Sub

      Private Sub cell_SelectedSubCellChanged(sender As Object, e As MedicalViewerActiveSubCellChangedEventArgs)
         CheckFusionTranslucencyAction(e.CellIndex)
      End Sub

      Private Sub SetAllItemsEnabled(menu As ContextMenuStrip, enabled As Boolean)
         For Each item As ToolStripItem In menu.Items
            item.Enabled = enabled
         Next
      End Sub

      Private Sub SetAllItemsVisible(menu As ContextMenuStrip, visible As Boolean)
         For Each item As ToolStripItem In menu.Items
            item.Visible = visible
         Next
      End Sub

      Private Sub AddBasicActionsFor2DCell(cell As MedicalViewerBaseCell)
         cell.AddAction(MedicalViewerActionType.Scale)
         cell.AddAction(MedicalViewerActionType.Offset)
         cell.AddAction(MedicalViewerActionType.Stack)
         cell.AddAction(MedicalViewerActionType.MagnifyGlass)
         cell.AddAction(MedicalViewerActionType.WindowLevel)
         cell.AddAction(MedicalViewerActionType.FusionTranslucency)
         If cell.CanExecuteAction(MedicalViewerActionType.Alpha) Then
            cell.AddAction(MedicalViewerActionType.Alpha)
         End If
      End Sub

      Private Sub InitClass()
         Try
            DicomEngine.Startup()

            _viewer = New MedicalViewer(2, 2)

            AddHandler _viewer.DeleteCell, AddressOf MedicalViewer_DeleteCell

            AddHandler _viewer.SelectedCellsChanged, AddressOf _viewer_SelectedCellsChanged

            _viewer.AllowMultipleSelection = True

            _displayPanel.Controls.Add(_viewer)

            AlwaysInterpolate = True

            _actionType = MedicalViewerActionType.WindowLevel

            _menuActionWindowLevel.Checked = True
         Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source)
         End Try
      End Sub

      Private Sub _viewer_SelectedCellsChanged(sender As Object, e As MedicalViewerSelectedCellsChangedEventArgs)
         CheckFusionTranslucencyAction(e.CellIndex)
      End Sub

      Public Sub CheckFusionTranslucencyAction(cellIndex As Integer)
         If _actionType = MedicalViewerActionType.FusionTranslucency Then
            Dim cell As MedicalViewerMultiCell = CType(_viewer.Cells(cellIndex), MedicalViewerMultiCell)

            If Not cell.Selected Then
               Return
            End If

            If cell.SubCells(cell.ActiveSubCell).Fusion.Count < 1 Then
               _actionType = MedicalViewerActionType.WindowLevel
               For Each control As Control In _viewer.Cells
                  SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel)
               Next
            End If
         End If
      End Sub

      Private Sub DeleteFusionImages(cell As MedicalViewerMultiCell)
         Dim subCellIndex As Integer = 0
         Dim length As Integer = cell.SubCells.Count
         Dim index As Integer = 0
         Dim image As RasterImage = Nothing
         Dim subCell As MedicalViewerSubCell

         While subCellIndex < length
            subCell = cell.SubCells(subCellIndex)

            While index < subCell.Fusion.Count
               image = subCell.Fusion(index).FusedImage
               subCell.Fusion.RemoveAt(index)
               If image IsNot Nothing Then
                  image.Dispose()
               End If
            End While
            subCellIndex += 1
         End While
      End Sub


      Private Sub MedicalViewer_DeleteCell(sender As Object, e As MedicalViewerDeleteEventArgs)

         For index As Integer = 0 To e.CellIndexes.Length - 1

            Dim cellIndex As Integer = e.CellIndexes(index)
            Dim cell As MedicalViewerMultiCell = CType(_viewer.Cells(cellIndex), MedicalViewerMultiCell)
            _fusionListNames.RemoveAt(cellIndex)

            If _adjustFusionImage IsNot Nothing AndAlso cell.Equals(_adjustFusionImage.Cell) Then
               _adjustFusionImage.Close()
            End If

            DeleteFusionImages(cell)
         Next

         For index As Integer = 0 To _viewer.Cells.Count - 1
            If index <> e.CellIndexes(0) Then
               _viewer.Cells(index).Selected = True
               Return
            End If
         Next
      End Sub

      Private Sub _menuItemFileLoadDICOMDIR_Click(sender As Object, e As EventArgs) Handles _menuItemFileLoadDICOMDIR.Click
         ' if there is an already instance of the series browser, then don't create the a new one. and just use the already created one
         ' You will notice that all the data (series and study) are still stored.
         If seriesBrowserDialog Is Nothing Then
            seriesBrowserDialog = New SeriesBrowser()
            seriesBrowserDialog.LoadAs3D = False
            seriesBrowserDialog.HideLoadAs3D = True
            ' this will be fired every time the browser loads a new frame.
            AddHandler seriesBrowserDialog.FrameLoaded, AddressOf seriesBrowserDialog_FrameLoaded
         End If
         seriesBrowserDialog.ShowDialog()
      End Sub

      Private Sub seriesBrowserDialog_FrameLoaded(sender As Object, e As FrameLoadedEventArgs)
         Try
            If e.State = FrameLoadedState.StartLoading Then
               _cellData = New CellData()
               _cellData.FileNames = New String(e.PageCount - 1) {}
               _cellData.InstanceNumbers = New Integer(e.PageCount - 1) {}
               _cellData.ImagePositions = New Point3D(e.PageCount - 1) {}
               _cellData.ImageOrientation = New Double(e.PageCount - 1)() {}
               _counter = 0
            End If

            If e.State = FrameLoadedState.FrameLoaded Then
               _cellData.InstanceNumbers(_counter) = e.InstanceNumber
               _cellData.FileNames(_counter) = e.ImagePath
               _cellData.ImagePositions(_counter) = e.ImagePosition
               Dim output As Double() = New Double(e.ImageOrientation.Length - 1) {}
               For i As Integer = 0 To e.ImageOrientation.Length - 1
                  output(i) = e.ImageOrientation(i)
               Next
               _cellData.ImageOrientation(_counter) = output
               _counter += 1
            End If

            If e.State = FrameLoadedState.EndLoading Then
               LoadImagesToMedicalViewer(e.SeriesInformation, e.ImageOrientation, seriesBrowserDialog.LoadAs3D)
            End If
         Catch generatedExceptionName As Exception
            e.Cancel = True
         End Try
      End Sub

      Private Function LoadImagesToMedicalViewer(image As SeriesInformation, imageOrientation As Single(), loadAs3D As Boolean) As Boolean
         seriesBrowserDialog.DisableLoading = True

         Dim data As CellData = _cellData

         Dim cell As New MedicalViewerMultiCell(Nothing, True, 1, 1)
         cell.Tag = data


         InitializeCell(cell)
         cell.Focus()

         SetCellTags(cell, image)

         cell.PixelSpacing = New Point2D(CSng(image.VoxelSpacing.X), CSng(image.VoxelSpacing.Y))

         cell.FrameOfReferenceUID = image.FrameOfReferenceUID
         If imageOrientation IsNot Nothing Then
            If imageOrientation.Length <> 0 Then
               cell.ImageOrientation = imageOrientation
            End If
         Else
            _cellData.CellType = ViewerCellType.Other
         End If
         CType(cell.Tag, CellData).FrameIndex = (image.DicomFrameNumber + 1)


         EnableCellLowMemoryUsage(cell)
         cell.SetScaleMode(MedicalViewerScaleMode.Fit)
         SetFrameInformation(cell)
         AddCellToViewer(cell, cell.VirtualImage.Count)


         If _viewer.Cells.Count = 1 Then
            cell.Selected = True
         End If

         seriesBrowserDialog.DisableLoading = False

         Return True
      End Function

      Private Sub SetFrameInformation(cell As MedicalViewerMultiCell)
         Dim index As Integer
         Dim data As CellData = CType(cell.Tag, CellData)
         Dim count As Integer = data.FileNames.Length

         For index = 0 To count - 1
            cell.SetTag(index, 5, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Im: " + data.InstanceNumbers(index).ToString() + " / " + count.ToString())
            cell.SetImagePosition(index, data.ImagePositions(index), index = (count - 1))
         Next
      End Sub

      Private Sub EnableCellLowMemoryUsage(cell As MedicalViewerMultiCell)
         Dim cellData As CellData = CType(cell.Tag, CellData)
         Dim count As Integer = cellData.FileNames.Length
         Dim index As Integer
         Dim data As CellData = CType(cell.Tag, CellData)
         Dim imagesInformation As MedicalViewerImageInformation() = New MedicalViewerImageInformation(count - 1) {}
         Using codecs As New RasterCodecs()
            Dim counter As New CounterDialog(count, 1, Me)
            counter.LoadingObject = True
            counter.LoadingText = "Preparing Series Data"
            counter.Show()
            counter.Update()

            For index = 0 To count - 1
               Using codecsInformation As CodecsImageInfo = codecs.GetInformation(cellData.FileNames(index), True, cellData.FrameIndex)
                  counter.Percent = CInt((index * 100 / (Math.Max(count - 1, 1))))
                  If (index Mod 5) = 0 Then
                     Application.DoEvents()
                  End If
                  imagesInformation(index) = New MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height)
               End Using
            Next

            counter.Close()
            counter.Dispose()

            AddHandler cell.FramesRequested, AddressOf cell_FramesRequested
            cell.EnableLowMemoryUsage(2, cellData.FileNames.Length, imagesInformation)
         End Using
      End Sub

      Private Function LoadRequestedFrameFileName(e As MedicalViewerRequestedFramesInformationEventArgs, codecs As RasterCodecs, data As CellData, index As Integer) As RasterImage
         Dim ds As New DicomDataSet()
         Dim image As RasterImage = Nothing
         If data.CellType <> ViewerCellType.SingleFileSeries Then
            ds.Load(data.FileNames(index), DicomDataSetLoadFlags.None)

            image = ds.GetImage(Nothing, data.FrameIndex - 1, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AllowRangeExpansion)
         Else
            image = GetImage(ds, data.FileNames(0), index)
         End If

         ds.Dispose()
         Return image
      End Function

      Private Sub cell_FramesRequested(sender As Object, e As MedicalViewerRequestedFramesInformationEventArgs)
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         Dim data As CellData = CType(cell.Tag, CellData)

         Dim viewer As MedicalViewer = CType(cell.Parent, MedicalViewer)
         If data Is Nothing Then
            Return
         End If

         Dim cellIndex As Integer = If((viewer Is Nothing), _viewer.Cells.Count, e.CellIndex)

         Using codecs As New RasterCodecs()
            Dim i As Integer

            If e.RequestedFramesIndexes.Length > 0 Then
               Using image As RasterImage = LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes(0))
                  FillSubCellFusion(cell, cellIndex, e.RequestedFramesIndexes(0))

                  For i = 1 To e.RequestedFramesIndexes.Length - 1
                     image.AddPage(LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes(i)))

                     FillSubCellFusion(cell, cellIndex, e.RequestedFramesIndexes(i))
                  Next

                  cell.SetRequestedImage(image, e.RequestedFramesIndexes, MedicalViewerSetImageOptions.Insert)
               End Using
            End If
         End Using
      End Sub

      Private Sub FillSubCellFusion(cell As MedicalViewerMultiCell, cellIndex As Integer, frameIndex As Integer)
         Dim ds As New DicomDataSet()
         Dim cellFusions As List(Of FusionData)() = Nothing
         If _fusionListNames.Count > cellIndex Then
            cellFusions = _fusionListNames(cellIndex)
         End If

         Dim fusions As IList(Of MedicalViewerFusion) = cell.SubCells(frameIndex).Fusion
         'initialize fusion for sub cell
         If _fusionListNames.Count > cellIndex AndAlso cellFusions(frameIndex) IsNot Nothing AndAlso fusions.Count <> cellFusions(frameIndex).Count Then
            For i As Integer = 0 To cellFusions(frameIndex).Count - 1
               Dim fusion As New MedicalViewerFusion()
               fusion.FusionScale = 50 / 100.0F
               fusion.DisplayRectangle = New RectangleF(0, 0, 1, 1)

               cell.SubCells(frameIndex).Fusion.Add(fusion)
            Next
         End If

         'put image in sub cell fusion
         For i As Integer = 0 To fusions.Count - 1
            fusions(i).FusedImage = GetImage(ds, cellFusions(frameIndex)(i).Filename, cellFusions(frameIndex)(i).Index)
         Next
         ds.Dispose()
      End Sub

      Private Sub SetCellTags(cell As MedicalViewerMultiCell, image As SeriesInformation)
         cell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.LeftOrientation)
         cell.SetTag(0, MedicalViewerTagAlignment.RightCenter, MedicalViewerTagType.RightOrientation)
         cell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.TopOrientation)
         cell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, MedicalViewerTagType.BottomOrientation)

         cell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.InstitutionName)
         cell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientName)
         cell.SetTag(4, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientAge)
         cell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientBirthDate)
         cell.SetTag(6, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientSex)
         cell.SetTag(7, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientID)

         cell.SetTag(9, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.AccessionNumber)
         cell.SetTag(8, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.StudyDate)
         cell.SetTag(7, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.AcquisitionTime)
         cell.SetTag(6, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.SeriesTime)
         cell.SetTag(5, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.FieldOfView)

         cell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, image.AccessionNumber)
         cell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, image.StudyDate)
         cell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, image.AcquisitionTime)
         cell.SetTag(7, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Frame)
         If image.EchoNumber <> -1 Then
            cell.SetTag(8, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Echo: " + image.EchoNumber.ToString())
         End If


         cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)

         cell.SetTag(4, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.Alpha)

         cell.SetTag(6, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale)
      End Sub


      Public Function GetFirstSelectedMultiCellIndex() As Integer
         Dim counter As Integer = 0
         For Each control As Control In _viewer.Cells
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

      Public Function GetSelectedMultiCellIndexs() As List(Of Integer)
         Dim counter As Integer = 0

         Dim selectedCells As New List(Of Integer)()


         For Each control As Control In _viewer.Cells
            If TypeOf control Is MedicalViewerMultiCell Then
               Dim cell As MedicalViewerMultiCell = CType(control, MedicalViewerMultiCell)

               If cell.Selected Then
                  selectedCells.Add(counter)
               End If

               Dim aa As Object = cell.Tag

               counter += 1
            End If
         Next

         Return selectedCells
      End Function


      Public Function GetFirstSelectedMultiCell() As MedicalViewerMultiCell
         For Each control As Control In _viewer.Cells
            If TypeOf control Is MedicalViewerMultiCell Then
               Dim cell As MedicalViewerMultiCell = CType(control, MedicalViewerMultiCell)

               If cell.Selected Then
                  Return CType(control, MedicalViewerMultiCell)
               End If
            End If
         Next
         Return Nothing
      End Function


      Private Function GetFirstSelectedCell() As MedicalViewerCell
         For Each control As Control In _viewer.Cells
            If TypeOf control Is MedicalViewerCell Then
               Dim cell As MedicalViewerCell = CType(control, MedicalViewerCell)

               If cell.Selected Then
                  Return CType(control, MedicalViewerCell)
               End If
            End If
         Next
         Return Nothing
      End Function


      Private Function GetFirstSelected3DControl() As Medical3DControl
         For Each control As Control In _viewer.Cells
            If TypeOf control Is Medical3DControl Then
               Dim ctrl3D As Medical3DControl = CType(control, Medical3DControl)

               If ctrl3D.Selected Then
                  Return CType(control, Medical3DControl)
               End If
            End If
         Next
         Return Nothing
      End Function

      Private Sub _mainPanel_SizeChanged(sender As Object, e As EventArgs) Handles _mainPanel.SizeChanged
         If _viewer IsNot Nothing Then
            If _displayPanel IsNot Nothing Then
               _displayPanel.Left = 0
               _displayPanel.Top = 0
               _displayPanel.Width = _mainPanel.Width
               _displayPanel.Height = _mainPanel.Height
            End If

            _viewer.SetBounds(_displayPanel.Left, _displayPanel.Top, _displayPanel.Width, _displayPanel.Height)
         End If
      End Sub

      Private Sub EnableCellLowMemoryUsage(cell As MedicalViewerMultiCell, fileName As String, info As CodecsImageInfo)
         Dim index As Integer
         Dim count As Integer = info.TotalPages
         Dim cellData As CellData = CType(cell.Tag, CellData)

         Dim imagesInformation As MedicalViewerImageInformation() = New MedicalViewerImageInformation(count - 1) {}

         Using codecs As New RasterCodecs()
            Using codecsInformation As CodecsImageInfo = codecs.GetInformation(fileName, True, cellData.FrameIndex)

               For index = 0 To count - 1
                  imagesInformation(index) = New MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height)
               Next

               AddHandler cell.FramesRequested, AddressOf cell_FramesRequested
               cell.EnableLowMemoryUsage(2, count, imagesInformation)
            End Using
         End Using
      End Sub


      Private Sub GetFileName(ByRef fileName As String, owner As Form)
         Dim codecs As New RasterCodecs()
         Dim loader As New ImageFileLoader()
         fileName = ""
         loader.OpenDialogInitialPath = _openInitialPath
         Try
            loader.ShowLoadPagesDialog = False
            If loader.Load(owner, codecs, False) <> 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               fileName = ""
               If loader.LastPage <> 0 Then
                  counter = New CounterDialog(If(loader.LastPage = -1, -1, loader.LastPage - loader.FirstPage + 1), 0, Me)
                  counter.FirstPage = loader.FirstPage

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

      Private Sub AddNewDicomDirectoryTab(dicomDirectroyAvailable As Boolean)
         Return
      End Sub


      ' This method returns the specified DICOM tag in a string format.
      Private Function GetDicomTag(ds As DicomDataSet, tag As Long) As String
         Dim patientElement As DicomElement = ds.FindFirstElement(Nothing, tag, True)

         If patientElement IsNot Nothing Then
            Return ds.GetConvertValue(patientElement)
         End If

         Return Nothing
      End Function


      Private Function GetImage(dicomDataSet As DicomDataSet, imagePath As String, index As Integer) As RasterImage
         Try
            dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None)

            Return dicomDataSet.GetImage(Nothing, index, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AllowRangeExpansion)
         Catch generatedExceptionName As Exception
            Dim _codecs As New RasterCodecs()

            Return _codecs.Load(imagePath, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1)
         End Try
      End Function

      ' Load the DICOM file
      Private Function LoadDICOM(imagePath As String) As SeriesInformation
         Try
            Dim imageInformation As New SeriesInformation()


            Dim dicomDataSet As New DicomDataSet()

            imageInformation.Image = GetImage(dicomDataSet, imagePath, 0)
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
            imageInformation.SeriesDescription = GetDicomTag(dicomDataSet, DicomTag.SeriesDescription)
            imageInformation.ImageComments = GetDicomTag(dicomDataSet, DicomTag.ImageComments)

            Return imageInformation
         Catch ex As System.Exception
            Messager.Show(Me, ex, MessageBoxIcon.Exclamation)
         End Try

         Return Nothing
      End Function

      Public Sub LoadDicomImage(owner As Form)
         Dim imagePath As String = ""
         Dim codecs As New RasterCodecs()
         GetFileName(imagePath, owner)

         ' Insert new cell if the user has selected an image.
         If imagePath <> "" Then
            Dim imageInformation As SeriesInformation = LoadDICOM(imagePath)
            If imageInformation Is Nothing Then
               Return
            End If
            Dim image As RasterImage = imageInformation.Image

            If imageInformation Is Nothing Then
               image.Dispose()
               Return
            End If

            Dim cell As New MedicalViewerMultiCell(Nothing, True, 1, 1)
            Dim cellData As New CellData(ViewerCellType.SingleFileSeries)
            cellData.FileNames = New String(0) {}
            cellData.FileNames(0) = imagePath
            cell.Tag = cellData

            Dim oldCursor As Cursor = Cursor
            Cursor = Cursors.WaitCursor
            Dim info As CodecsImageInfo = codecs.GetInformation(imagePath, True)

            EnableCellLowMemoryUsage(cell, imagePath, info)

            Cursor = oldCursor

            InitializeCell(cell)
            AddCellToViewer(cell, cell.VirtualImage.Count)
            SetCellTags(cell, imageInformation)
            cell.SnapRulers = False

            If _viewer.Cells.Count = 1 Then
               cell.Selected = True
            End If


            image.Dispose()
         End If
      End Sub


      Private Sub _menuItemFileLoadDICOM_Click(sender As Object, e As EventArgs) Handles _menuItemFileLoadDICOM.Click
         LoadDicomImage(Me)
      End Sub

      Private Sub _menuFile_exit_Click(sender As Object, e As EventArgs) Handles _menuFile_exit.Click
         Me.Close()
      End Sub

      Private Sub _menuEdit_DropDownOpening(sender As Object, e As EventArgs) Handles _menuEdit.DropDownOpening
         _menuAdjustFusion.Enabled = InlineAssignHelper(_menuAddFusion.Enabled, InlineAssignHelper(_menuDeleteAll.Enabled, _viewer.Cells.Count <> 0))

         _menuFuseTwoCells.Enabled = (GetSelectedMultiCellIndexs().Count = 2)

         Dim cellIndex As Integer = GetFirstSelectedMultiCellIndex()

         If cellIndex = -1 Then
            _menuAddFusion.Enabled = InlineAssignHelper(_menuAdjustFusion.Enabled, False)
            Return
         End If

         If _adjustFusionImage IsNot Nothing AndAlso _adjustFusionImage.Visible Then
            _menuAddFusion.Enabled = False
         End If
      End Sub

      Private Sub CopyTags(destinationCell As MedicalViewerBaseCell, cell As MedicalViewerBaseCell, addWindowLevelTag As Boolean)
         CopyTags(destinationCell, cell, addWindowLevelTag, True)
      End Sub


      Private Sub CopyTags(destinationCell As MedicalViewerBaseCell, cell As MedicalViewerBaseCell, addWindowLevelTag As Boolean, addScaleTag As Boolean)
         Dim information As MedicalViewerTagInformation
         information = cell.GetTag(0, MedicalViewerTagAlignment.LeftCenter)
         If information IsNot Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, information.Type)
         End If
         information = cell.GetTag(0, MedicalViewerTagAlignment.RightCenter)
         If information IsNot Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.RightCenter, information.Type)
         End If
         information = cell.GetTag(0, MedicalViewerTagAlignment.TopCenter)
         If information IsNot Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, information.Type)
         End If
         information = cell.GetTag(0, MedicalViewerTagAlignment.BottomCenter)
         If information IsNot Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, information.Type)
         End If

         information = cell.GetTag(2, MedicalViewerTagAlignment.TopRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(3, MedicalViewerTagAlignment.TopRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(4, MedicalViewerTagAlignment.TopRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(4, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(5, MedicalViewerTagAlignment.TopRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(6, MedicalViewerTagAlignment.TopRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(6, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(7, MedicalViewerTagAlignment.TopRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(7, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If

         information = cell.GetTag(9, MedicalViewerTagAlignment.BottomRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(9, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(8, MedicalViewerTagAlignment.BottomRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(8, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(7, MedicalViewerTagAlignment.BottomRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(7, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(6, MedicalViewerTagAlignment.BottomRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(6, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(5, MedicalViewerTagAlignment.BottomRight)
         If information IsNot Nothing Then
            destinationCell.SetTag(5, MedicalViewerTagAlignment.BottomRight, information.Type)
         End If


         information = cell.GetTag(2, MedicalViewerTagAlignment.TopLeft)
         If information IsNot Nothing Then
            destinationCell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(3, MedicalViewerTagAlignment.TopLeft)
         If information IsNot Nothing Then
            destinationCell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(4, MedicalViewerTagAlignment.TopLeft)
         If information IsNot Nothing Then
            destinationCell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text)
         End If

         If addWindowLevelTag Then
            information = cell.GetTag(2, MedicalViewerTagAlignment.BottomLeft)
            If information IsNot Nothing Then
               destinationCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, information.Type)
            End If
         End If

         If addScaleTag Then
            information = cell.GetTag(6, MedicalViewerTagAlignment.TopLeft)
            If information IsNot Nothing Then
               destinationCell.SetTag(6, MedicalViewerTagAlignment.TopLeft, information.Type)
            End If

            information = cell.GetTag(7, MedicalViewerTagAlignment.TopLeft)
            If information IsNot Nothing Then
               destinationCell.SetTag(7, MedicalViewerTagAlignment.TopLeft, information.Type)
            End If
         End If
      End Sub

      Private Sub LoadImages()
         Dim files As String() = Directory.GetFiles(DemosGlobal.ImagesFolder, "*.dcm")
         Using codecs As New RasterCodecs()

            For i As Integer = 0 To _viewer.Cells.Count - 1
               If i >= files.Length Then
                  Exit For
               End If

               Try
                  CType(_viewer.Cells(i), MedicalViewerCell).Image = codecs.Load(files(i))
               Catch
               End Try
            Next
         End Using
      End Sub

      Private Sub _menuAbout_Click(sender As Object, e As EventArgs) Handles _menuAbout.Click
         Using aboutDialog As New AboutDialog("Fusion Demo", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _menuLayoutOptions_Click(sender As Object, e As EventArgs)
         Dim LayoutOptions As LayoutOptions = New LayoutOptions(_viewer, Me)
         LayoutOptions.ShowDialog(Me)
      End Sub


      Private Sub UncheckThePerviousMenuItem(sender As ToolStripMenuItem)
         For Each item As ToolStripMenuItem In sender.Owner.Items
            If item.Checked Then
               item.Checked = False
            End If
         Next
      End Sub

      Private Sub SetAction(cell As MedicalViewerBaseCell, actionType As MedicalViewerActionType)
         cell.SetAction(actionType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)

         If actionType = MedicalViewerActionType.WindowLevel Then
            cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
         Else
            cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
         End If

         If actionType <> MedicalViewerActionType.Scale Then
            cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active)
         Else
            cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active)
         End If
      End Sub

      Public Sub SetAction(control As Control, actionType As MedicalViewerActionType, sender As ToolStripMenuItem)
         Dim cell As MedicalViewerBaseCell = CType(control, MedicalViewerBaseCell)
         If sender IsNot Nothing Then
            UncheckThePerviousMenuItem(sender)
            sender.Checked = True
         End If

         If actionType = MedicalViewerActionType.AnnotationPoint Then
            SetAction(cell, _actionType)
         Else
            SetAction(cell, actionType)
         End If

      End Sub

      Private Sub _menuActionWindowLevel_Click(sender As Object, e As EventArgs) Handles _menuActionWindowLevel.Click
         _actionType = MedicalViewerActionType.WindowLevel
         For Each control As Control In _viewer.Cells
            SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel)
         Next
      End Sub

      Private Sub _menuActionAlpha_Click(sender As Object, e As EventArgs) Handles _menuActionAlpha.Click
         _actionType = MedicalViewerActionType.Alpha
         For Each control As Control In _viewer.Cells
            SetAction(control, MedicalViewerActionType.Alpha, _menuActionAlpha)
         Next
      End Sub

      Private Sub _menuActionScale_Click(sender As Object, e As EventArgs) Handles _menuActionScale.Click
         _actionType = MedicalViewerActionType.Scale
         For Each control As Control In _viewer.Cells
            SetAction(control, MedicalViewerActionType.Scale, _menuActionScale)
         Next
      End Sub

      Private Sub _menuActionMagnify_Click(sender As Object, e As EventArgs) Handles _menuActionMagnify.Click
         _actionType = MedicalViewerActionType.MagnifyGlass
         For Each control As Control In _viewer.Cells
            SetAction(control, MedicalViewerActionType.MagnifyGlass, _menuActionMagnify)
         Next
      End Sub

      Private Sub _menuActionPan_Click(sender As Object, e As EventArgs) Handles _menuActionPan.Click
         _actionType = MedicalViewerActionType.Offset
         For Each control As Control In _viewer.Cells
            SetAction(control, MedicalViewerActionType.Offset, _menuActionPan)
         Next
      End Sub

      Private Sub AddCellToViewer(control As MedicalViewerBaseCell, count As Integer)
         If _viewer IsNot Nothing Then
            _viewer.Cells.Add(control)
            _fusionListNames.Add(New List(Of FusionData)(count - 1) {})
         End If
      End Sub

      Public ReadOnly Property FusionListNames() As List(Of List(Of FusionData)())
         Get
            Return _fusionListNames
         End Get
      End Property

      Private Function GetFirstSelectedControl() As MedicalViewerBaseCell
         For Each control As Control In _viewer.Cells
            Dim cell As MedicalViewerBaseCell = CType(control, MedicalViewerBaseCell)

            If cell.Selected Then
               Return CType(control, MedicalViewerBaseCell)
            End If
         Next
         Return Nothing
      End Function

      Private Sub _actionsMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _actionsMenuItem.DropDownOpening
         Dim parent As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
         For Each item As ToolStripMenuItem In parent.DropDownItems
            item.Enabled = (_viewer.Cells.Count <> 0)
         Next

         Dim cellIndex As Integer = GetFirstSelectedMultiCellIndex()

         If cellIndex = -1 Then
            _menuActionTranslucensy.Enabled = False
            Return
         End If

         Dim cell As MedicalViewerMultiCell = CType(_viewer.Cells(cellIndex), MedicalViewerMultiCell)

         _menuActionTranslucensy.Enabled = (cell.SubCells(cell.ActiveSubCell).Fusion.Count > 0)
      End Sub

      Private Sub _menuUnload_Click(sender As Object, e As EventArgs)
         Dim cell As MedicalViewerBaseCell = CType(GetFirstSelectedControl(), MedicalViewerBaseCell)

         DeleteCell(cell)
      End Sub

      Private Sub DeleteCell(cell As MedicalViewerBaseCell)
         If cell IsNot Nothing Then
            Dim index As Integer = _viewer.Cells.IndexOf(cell)
            _viewer.Cells.Remove(cell)
            _fusionListNames.RemoveAt(index)

            DeleteFusionImages(CType(cell, MedicalViewerMultiCell))
            cell.Dispose()
         End If
      End Sub

      Private Sub _menuDeleteAll_Click(sender As Object, e As EventArgs) Handles _menuDeleteAll.Click
         Dim cell As MedicalViewerBaseCell = Nothing

         While _viewer.Cells.Count <> 0
            cell = _viewer.Cells(0)
            DeleteCell(cell)
         End While

         If _adjustFusionImage IsNot Nothing Then
            _adjustFusionImage.Close()
         End If
      End Sub

      Public Function LoadFusionDicom(ByRef seriesName As String, ByRef seriesPath As String, owner As Form) As RasterImage
         seriesName = ""
         Dim imagePath As String = ""
         GetFileName(imagePath, owner)

         seriesPath = imagePath

         If imagePath <> "" Then
            Dim imageInformation As SeriesInformation = LoadDICOM(imagePath)

            seriesName = imageInformation.PatientName

            If seriesName Is Nothing Then
               Dim stringArray As String() = imagePath.Split(New Char(0) {"\"c})

               seriesName = stringArray(stringArray.Length - 1)
            End If

            Return imageInformation.Image
         End If

         Return Nothing
      End Function

      Private Sub _menuAddFusion_Click(sender As Object, e As EventArgs) Handles _menuAddFusion.Click
         Dim cellIndex As Integer = GetFirstSelectedMultiCellIndex()

         If cellIndex = -1 Then
            Return
         End If

         Dim fusionImage As New AddFusionImage(_viewer, Me)
         fusionImage.ShowDialog()
      End Sub

      Private Sub _menuAdjustFusion_Click(sender As Object, e As EventArgs) Handles _menuAdjustFusion.Click
         If _adjustFusionImage IsNot Nothing AndAlso _adjustFusionImage.Visible Then
            Return
         End If

         Dim cellIndex As Integer = GetFirstSelectedMultiCellIndex()

         If cellIndex = -1 Then
            Return
         End If
         _adjustFusionImage = New AdjustFusionImage(_viewer, Me)
         _adjustFusionImage.Show(Me)
         _adjustFusionImage.Location = New Point(CInt(Me.Width * 0.75 - _adjustFusionImage.Width / 2 + Me.Location.X), CInt(Me.Height * 0.25 - _adjustFusionImage.Height / 2 + Me.Location.Y))
      End Sub

      Private Sub _menuProperties_Click(sender As Object, e As EventArgs) Handles _menuProperties.Click
         Dim options As New LayoutOptions(_viewer, Me)
         options.ShowDialog()
      End Sub

      Private Sub _menuFuseTwoCells_Click(sender As Object, e As EventArgs) Handles _menuFuseTwoCells.Click
         Dim indexs As List(Of Integer) = GetSelectedMultiCellIndexs()

         Dim orgCell As MedicalViewerMultiCell = CType(_viewer.Cells(indexs(0)), MedicalViewerMultiCell)
         Dim fuCell As MedicalViewerMultiCell = CType(_viewer.Cells(indexs(1)), MedicalViewerMultiCell)

         Dim cell As New MedicalViewerMultiCell(Nothing, True, 1, 1)
         Dim cellData As New CellData()

         Dim orgCellData As CellData = CType(orgCell.Tag, CellData)
         Dim fuCellData As CellData = CType(fuCell.Tag, CellData)

         cellData.CellType = orgCellData.CellType
         cellData.SyncCellFusion = True

         cellData.FileNames = New String(orgCellData.FileNames.Length - 1) {}
         orgCellData.FileNames.CopyTo(cellData.FileNames, 0)

         cellData.FrameIndex = orgCellData.FrameIndex

         If orgCellData.ImagePositions IsNot Nothing Then
            cellData.ImagePositions = New Point3D(orgCellData.ImagePositions.Length - 1) {}
            orgCellData.ImagePositions.CopyTo(cellData.ImagePositions, 0)
         End If

         If orgCellData.InstanceNumbers IsNot Nothing Then
            cellData.InstanceNumbers = New Integer(orgCellData.InstanceNumbers.Length - 1) {}
            orgCellData.InstanceNumbers.CopyTo(cellData.InstanceNumbers, 0)
         End If

         cell.Tag = cellData

         InitializeCell(cell)
         cell.Focus()

         cell.PixelSpacing = New Point2D(orgCell.PixelSpacing.X, orgCell.PixelSpacing.Y)

         cell.FrameOfReferenceUID = orgCell.FrameOfReferenceUID
         If orgCell.ImageOrientation IsNot Nothing Then
            If orgCell.ImageOrientation.Length <> 0 Then
               cell.ImageOrientation = orgCell.ImageOrientation
            End If
         Else
            _cellData.CellType = ViewerCellType.Other
         End If

         AddHandler cell.SelectedSubCellChanged, AddressOf fusecell_SelectedSubCellChanged

         AddCellToViewer(cell, orgCell.VirtualImage.Count)

         Dim cellIndex As Integer = _viewer.Cells.IndexOf(cell)

         Dim FuseTwoCellsPropertiesDlg As New FuseTwoCellsProperties(orgCell, fuCell)

         If fuCellData.ImagePositions Is Nothing OrElse fuCellData.ImageOrientation Is Nothing Then
            FuseTwoCellsPropertiesDlg.BestAlignedChecked = InlineAssignHelper(FuseTwoCellsPropertiesDlg.EnableBestAligned, False)
         End If

         FuseTwoCellsPropertiesDlg.ShowDialog()

         'fill _fusionListNames with the fusion image file name and index
         For i As Integer = FuseTwoCellsPropertiesDlg.Start - 1 To FuseTwoCellsPropertiesDlg.[End] - 1
            If _fusionListNames(cellIndex)(i) Is Nothing Then
               _fusionListNames(cellIndex)(i) = New List(Of FusionData)()
            End If


            Dim indx As Integer = i
            If FuseTwoCellsPropertiesDlg.UseBestAligned Then
               indx = orgCell.BestAligned(i, fuCellData.ImagePositions, fuCellData.ImageOrientation)
               If indx = -1 Then
                  indx = i
               End If
            End If
            indx = indx - FuseTwoCellsPropertiesDlg.Start + 1

            If fuCellData.CellType <> ViewerCellType.SingleFileSeries Then
               Dim dicomDataSet As New DicomDataSet()

               GetImage(dicomDataSet, fuCellData.FileNames(indx), 0)

               _fusionListNames(cellIndex)(i).Add(New FusionData(fuCellData.FileNames(indx), GetDicomTag(dicomDataSet, DicomTag.PatientName), 0, indx, orgCell, fuCell))
            Else
               Dim dicomDataSet As New DicomDataSet()

               GetImage(dicomDataSet, fuCellData.FileNames(0), indx)

               _fusionListNames(cellIndex)(i).Add(New FusionData(fuCellData.FileNames(0), GetDicomTag(dicomDataSet, DicomTag.PatientName), indx, indx, orgCell, fuCell))
            End If
         Next

         'enable Low Memory Usage for the cell
         If cellData.CellType <> ViewerCellType.SingleFileSeries Then
            EnableCellLowMemoryUsage(cell)
            SetFrameInformation(cell)
         Else
            Using codecs As New RasterCodecs()
               Dim info As CodecsImageInfo = codecs.GetInformation(cellData.FileNames(0), True)

               EnableCellLowMemoryUsage(cell, cellData.FileNames(0), info)
            End Using
         End If

         'add annotation rectangle for all fusions
         For i As Integer = FuseTwoCellsPropertiesDlg.Start - 1 To FuseTwoCellsPropertiesDlg.[End] - 1
            Dim rect As New AnnRectangleObject()
            rect.IsVisible = False
            rect.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(5))

            cell.SubCells(i).AnnotationContainer.Children.Add(rect)
            cell.AnnotationPrecedency = True


            If cell.SubCells(i).Fusion.Count = 0 Then
               Dim fusion As New MedicalViewerFusion()
               fusion.FusionScale = 50 / 100.0F
               fusion.DisplayRectangle = New RectangleF(0, 0, 1, 1)

               cell.SubCells(i).Fusion.Add(fusion)
            End If
         Next

         cell.SetScaleMode(MedicalViewerScaleMode.Fit)
      End Sub

      Private Sub fusecell_SelectedSubCellChanged(sender As Object, e As MedicalViewerActiveSubCellChangedEventArgs)
         Dim fusionData As FusionData = Nothing

         If _fusionListNames(e.CellIndex)(e.SubCellIndex) IsNot Nothing Then
            fusionData = _fusionListNames(e.CellIndex)(e.SubCellIndex)(0)
         End If

         If fusionData IsNot Nothing AndAlso fusionData.OrignalCell IsNot Nothing AndAlso Not fusionData.OrignalCell.IsDisposed Then
            fusionData.OrignalCell.ActiveSubCell = e.SubCellIndex

         ElseIf fusionData Is Nothing Then
            'if cell hasn't fusion get cell with fusion OrignalCell and scroll it
            For Each list As List(Of FusionData) In _fusionListNames(e.CellIndex)
               If list IsNot Nothing AndAlso list(0) IsNot Nothing Then
                  list(0).OrignalCell.ActiveSubCell = e.SubCellIndex
                  Exit For
               End If
            Next
         End If

         If fusionData IsNot Nothing AndAlso fusionData.FusionCell IsNot Nothing AndAlso Not fusionData.FusionCell.IsDisposed Then
            fusionData.FusionCell.ActiveSubCell = fusionData.OrignalFusionImageIndex
         End If
      End Sub

      Private Sub _menuActionTranslucensy_Click(sender As Object, e As EventArgs) Handles _menuActionTranslucensy.Click
         _actionType = MedicalViewerActionType.FusionTranslucency

         For Each control As Control In _viewer.Cells
            SetAction(control, MedicalViewerActionType.FusionTranslucency, _menuActionTranslucensy)
         Next
      End Sub

      Private Sub manualWLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _manualWLToolStripMenuItem.Click
         Dim widthMin As Integer, widthMax As Integer, levelMin As Integer, levelMax As Integer
         For Each cell As MedicalViewerCell In _viewer.Cells
            If cell.Selected Then
               Dim index As Integer = _viewer.Cells.IndexOf(cell)
               Using image As RasterImage = cell.VirtualImage(cell.ActiveSubCell).Image.Clone()
                  Using windowLevelProperties As MedicalViewerWindowLevel = CType(cell.GetActionProperties(MedicalViewerActionType.WindowLevel), MedicalViewerWindowLevel)
                     widthMax = CInt(Math.Pow(2, image.BitsPerPixel)) - 1
                     widthMin = 1
                     levelMax = CInt(Math.Pow(2, image.BitsPerPixel)) - 1
                     levelMin = CInt(Math.Pow(2, image.BitsPerPixel)) * -1 + 1

                     Dim dlg As New WindowLevelDialog(windowLevelProperties.Center, windowLevelProperties.Width, widthMin, widthMax, levelMin, levelMax, _
                      index)
                     If dlg.ShowDialog() = DialogResult.OK Then
                        windowLevelProperties.Center = dlg.WL_Level
                        windowLevelProperties.Width = dlg.WL_Width
                        cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevelProperties)
                     End If
                  End Using
               End Using
            End If
         Next
      End Sub

      Private Sub _curveTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _linearToolStripMenuItem.Click, _exponentialToolStripMenuItem.Click, _logarithmicToolStripMenuItem.Click, _sigmoidToolStripMenuItem.Click
         For Each cell As MedicalViewerCell In _viewer.Cells
            Using windowLevelProperties As MedicalViewerWindowLevel = CType(cell.GetActionProperties(MedicalViewerActionType.WindowLevel), MedicalViewerWindowLevel)
               Select Case sender.ToString()
                  Case "Linear"
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Linear
                     Console.WriteLine(sender.ToString())
                     Exit Select
                  Case "Exponential"
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Exponential
                     Console.WriteLine(sender.ToString())
                     Exit Select
                  Case "Logarithmic"
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Logarithmic
                     Console.WriteLine(sender.ToString())
                     Exit Select
                  Case "Sigmoid"
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Sigmoid
                     Console.WriteLine(sender.ToString())
                     Exit Select
                  Case Else
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.None
                     Exit Select
               End Select
               cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevelProperties)
            End Using
         Next
      End Sub
      Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
         target = value
         Return value
      End Function
   End Class



   ' Determine the type of the cell.
   Public Enum ViewerCellType
      Derivate
      SingleFileSeries
      MPRCell
      Cell2D
      Mesh3D
      LoadedObject
      Other
   End Enum

   Public Class FusionData
      Public Sub New()
         _index = 0
      End Sub

      Public Sub New(filename As String, name As String, index As Integer)
         _name = name
         _filename = filename
         _index = index
         _orignalFusionImageIndex = 0
      End Sub

      Public Sub New(filename As String, name As String, index As Integer, orignalFusionImageIndex As Integer, orgCell As MedicalViewerMultiCell, fuCell As MedicalViewerMultiCell)
         _name = name
         _filename = filename
         _index = index
         _orignalFusionImageIndex = orignalFusionImageIndex
         _orignalCell = orgCell
         _fusionCell = fuCell
      End Sub

      Private _name As String
      Public Property Name() As String
         Get
            Return _name
         End Get
         Set(value As String)
            _name = value
         End Set
      End Property

      Private _filename As String
      Public Property Filename() As String
         Get
            Return _filename
         End Get
         Set(value As String)
            _filename = value
         End Set
      End Property

      Private _index As Integer
      Public Property Index() As Integer
         Get
            Return _index
         End Get
         Set(value As Integer)
            _index = value
         End Set
      End Property

      Private _orignalFusionImageIndex As Integer
      Public Property OrignalFusionImageIndex() As Integer
         Get
            Return _orignalFusionImageIndex
         End Get
         Set(value As Integer)
            _orignalFusionImageIndex = value
         End Set
      End Property

      Private _orignalCell As MedicalViewerMultiCell
      Public Property OrignalCell() As MedicalViewerMultiCell
         Get
            Return _orignalCell
         End Get
         Set(value As MedicalViewerMultiCell)
            _orignalCell = value
         End Set
      End Property

      Private _fusionCell As MedicalViewerMultiCell
      Public Property FusionCell() As MedicalViewerMultiCell
         Get
            Return _fusionCell
         End Get
         Set(value As MedicalViewerMultiCell)
            _fusionCell = value
         End Set
      End Property
   End Class

   ''' <summary>
   ''' This class contains the information that will be saved in cell "Tag"
   ''' </summary>
   Public Class CellData
      Private _cellType As ViewerCellType
      Private _fileNames As String()
      Private _imagePositions As Point3D()
      Private _imageOrientation As Double()()
      Private _frameInstanceNumber As Integer()
      Private _multiPageCount As Integer
      Private _cell As MedicalViewerMultiCell
      Private _frameIndex As Integer
      Private _counterDialog As CounterDialog
      Private _syncCellFusion As Boolean

      Public Sub New(cellType As ViewerCellType)
         _cellType = cellType
         _syncCellFusion = False
      End Sub

      Public Sub New()
         _cellType = ViewerCellType.Cell2D
         _syncCellFusion = False
      End Sub


      Public Property Counter() As CounterDialog
         Get
            Return _counterDialog
         End Get
         Set(value As CounterDialog)
            _counterDialog = value
         End Set
      End Property

      Public Property SyncCellFusion() As Boolean
         Get
            Return _syncCellFusion
         End Get
         Set(value As Boolean)
            _syncCellFusion = value
         End Set
      End Property


      Public Property ImagePositions() As Point3D()
         Get
            Return _imagePositions
         End Get
         Set(value As Point3D())
            _imagePositions = value
         End Set
      End Property

      Public Property ImageOrientation() As Double()()
         Get
            Return _imageOrientation
         End Get
         Set(value As Double()())
            _imageOrientation = value
         End Set
      End Property



      Public Property FrameIndex() As Integer
         Get
            Return _frameIndex
         End Get
         Set(value As Integer)
            _frameIndex = value
         End Set
      End Property




      Public Property Cell() As MedicalViewerMultiCell
         Get
            Return _cell
         End Get
         Set(value As MedicalViewerMultiCell)
            _cell = value
         End Set
      End Property


      Public Property CellType() As ViewerCellType
         Get
            Return _cellType
         End Get
         Set(value As ViewerCellType)
            _cellType = value
         End Set
      End Property


      Public Property MultiPageCount() As Integer
         Get
            Return _multiPageCount
         End Get
         Set(value As Integer)
            _multiPageCount = value
         End Set
      End Property

      Public Property InstanceNumbers() As Integer()
         Get
            Return _frameInstanceNumber
         End Get
         Set(value As Integer())
            _frameInstanceNumber = value
         End Set
      End Property

      Public Property FileNames() As String()
         Get
            Return _fileNames
         End Get
         Set(value As String())
            _fileNames = value
         End Set
      End Property
   End Class
End Namespace
