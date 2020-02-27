' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.WinForms
Imports Leadtools.Dicom
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing
Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Diagnostics
Imports Main3DDemo.Leadtools.Demos
Imports Leadtools.Demos.Dialogs

Namespace Main3DDemo
   Partial Public Class MainForm : Inherits Form
      Private seriesBrowserDialog As SeriesBrowser
      Private _viewer As MedicalViewer
      Private counter As CounterDialog
      Private _planeCutLineClicked As Boolean
      Private _mousePoint As Point
      Private _polygonIndex As Integer
      Private _polygon As MedicalViewerMPRPolygon
      Private _clickType As MedicalViewerMPRPolygonHitTest
      Private _showFirstAndLastReferenceLines As Boolean
      Private _polygonHandleClicked As Boolean = False

      Private _cellData As CellData
      Private _MPRMode As Boolean
      Private _showReferenceBoundaries As Boolean
      Private _showReferenceLine As Boolean
      Private _showMPRCrossHair As Boolean
      Private _coloredMPRCrossHair As Boolean
      Private _rightClickContextMenu As ContextMenuStrip
      Private _rightClickGeneratorContextMenu As ContextMenuStrip
      Private _generatorCellIndex As Integer
      Private _currentMousePoint As Point
      Private _currentSelectedMenuItem As ToolStripMenuItem
      Private _actionType As MedicalViewerActionType
      Private _counter As Integer
      Private _showScrollBar As Boolean
      Private _alwaysInterpolate As Boolean



      Public Property AlwaysInterpolate() As Boolean
         Get
            Return _alwaysInterpolate
         End Get

         Set(value As Boolean)
            _alwaysInterpolate = value
         End Set
      End Property


      Public Enum MPRType
         Axial
         Sagittal
         Coronal
      End Enum

      <STAThread()> _
      Shared Sub Main(ByVal args As String())
         
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

         If (Not Medical3DEngine.HardwareCompatible) Then
            MessageBox.Show("Some Hardware didn't meet the specification required to be able to run the 3D properly", "Compatibility Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim check As CheckUtilityDialog = New CheckUtilityDialog(Nothing)
            check.ShowDialog()
         Else
            Application.Run(New MainForm())
         End If
      End Sub

      Public Sub New()
         InitializeComponent()
         InitClass()
      End Sub

      Private Sub InitializeMPRCell(ByVal cell As MedicalViewerMPRCell, ByVal type As MPRType)
         AddBasicActionsFor2DCell(cell)

         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.AllCells Or MedicalViewerActionFlags.RealTime)

         cell.ShowSlabBoundaries = _menuShowSlab.Checked
         cell.SnapRulers = True
         AddProbeToolEvents(cell)
         cell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, type.ToString())

         cell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.LeftOrientation)
         cell.SetTag(0, MedicalViewerTagAlignment.RightCenter, MedicalViewerTagType.RightOrientation)
         cell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.TopOrientation)
         cell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, MedicalViewerTagType.BottomOrientation)

         cell.SetTag(0, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.RulerUnit)

         cell.Tag = New CellData(ViewerCellType.MPRCell)


         Dim windowLevel As MedicalViewerWindowLevel = CType(cell.GetActionProperties(MedicalViewerActionType.WindowLevel), MedicalViewerWindowLevel)

         windowLevel.RelativeSensitivity = True

         cell.AlwaysInterpolate = AlwaysInterpolate

         cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel)

         SetAction(cell, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel)

      End Sub

      Private Sub SetCurrent2DAction(ByVal cell As MedicalViewerCell)
         Select Case _actionType
            Case MedicalViewerActionType.Alpha, MedicalViewerActionType.MagnifyGlass, MedicalViewerActionType.Offset, MedicalViewerActionType.WindowLevel, MedicalViewerActionType.Scale, MedicalViewerActionType.ProbeTool, MedicalViewerActionType.PanoramicPolygon
               cell.SetAction(_actionType, MedicalViewerMouseButtons.Left, getApplyingOperation(_actionType))
            Case Else
               cell.SetAction(MedicalViewerActionType.None, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         End Select
      End Sub

      Private Sub SetCurrent3DAction(ByVal cell As Medical3DControl)
         Dim canExcute As Boolean = cell.CanExecuteAction(_actionType)

         ' Cannot apply window level on the volume while in SSD.
         If (cell.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD) Then
            If (_actionType = MedicalViewerActionType.WindowLevel) Then
               canExcute = False
            End If
         End If

         If (canExcute) Then
            cell.SetAction(_actionType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         Else
            cell.SetAction(MedicalViewerActionType.Rotate3DObject, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         End If
      End Sub

      Private Sub Initialize3DCell(ByVal cell As Medical3DControl)
         cell.AddAction(MedicalViewerActionType.Rotate3DObject)
         cell.AddAction(MedicalViewerActionType.Offset)
         cell.AddAction(MedicalViewerActionType.Scale3DObject)
         cell.AddAction(MedicalViewerActionType.Rotate3DCamera)
         cell.AddAction(MedicalViewerActionType.Translate3DCamera)
         cell.AddAction(MedicalViewerActionType.Scale)
         cell.AddAction(MedicalViewerActionType.TranslatePlane)
         cell.AddAction(MedicalViewerActionType.RotatePlane)
         cell.AddAction(MedicalViewerActionType.WindowLevel)

         SetCurrent3DAction(cell)
         AddHandler cell.ObjectsContainer.CreateObject, AddressOf ObjectsContainer_CreateObject
         _menuInvert.Checked = False
      End Sub

      Private Sub StartProgress(ByVal counterDialog As CounterDialog)
         counterDialog.Show()
      End Sub

      Private Sub EndProgress(ByVal counterDialog As CounterDialog)
         If Not counterDialog Is Nothing Then
            counterDialog.Close()
            counterDialog.Dispose()
            counterDialog = Nothing
         End If
      End Sub

      Private Sub ObjectsContainer_CreateObject(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
         Dim control As Medical3DControl = (CType((CType(sender, Medical3DContainer)).OwnerControl, Medical3DControl))
         Dim counterDialog As CounterDialog = Nothing

         If TypeOf control.Tag Is CounterDialog Then
            counterDialog = CType(control.Tag, CounterDialog)
         End If

         If (e.Percent Mod 5) = 0 Then
            Application.DoEvents()
         End If
         If counterDialog Is Nothing Then
            Return
         End If
         counterDialog.Percent = e.Percent
         counterDialog.Update()
      End Sub

      Private Sub InitializeCell(ByVal cell As MedicalViewerMultiCell)
         cell.ShowCellScroll = _showScrollBar
         cell.PaintingMethod = MedicalViewerPaintingMethod.Bicubic
         AddHandler cell.CellMouseClick, AddressOf _viewer_CellMouseClick
         AddHandler cell.CellMouseDown, AddressOf _viewer_CellMouseDown
         AddHandler cell.PlaneCutLineClicked, AddressOf _viewer_PlaneCutLineClicked
         AddHandler cell.Data3DRequested, AddressOf cell_Data3DRequested
         AddHandler cell.DerivativeGenerated, AddressOf cell_DerivativeGenerated
         AddHandler cell.Data3DFrameRequested, AddressOf cell_Data3DFrameRequested
         AddHandler cell.MPRPolygonCreated, AddressOf cell_CurvedMPRPolygonCreated
         AddHandler cell.PanoramicDataRequested, AddressOf cell_CurvedMPRDataRequested
         AddHandler cell.MPRPolygonClicked, AddressOf cell_CurvedMPRPolygonClicked

         AddProbeToolEvents(cell)
         cell.AutoDisposeInternalData = True
         cell.FitImageToCell = False
         cell.SetScaleMode(MedicalViewerScaleMode.Fit)
         cell.SnapRulers = True

         AddBasicActionsFor2DCell(cell)

         cell.AddAction(MedicalViewerActionType.PanoramicPolygon)


         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, getApplyingOperation(MedicalViewerActionType.Offset))
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, getApplyingOperation(MedicalViewerActionType.Scale))
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, getApplyingOperation(MedicalViewerActionType.Stack))
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, getApplyingOperation(MedicalViewerActionType.WindowLevel))


         Dim data As CellData = CType(cell.Tag, CellData)

         data.CurrentCheckedItem = _menuActionWindowLevel
         data.CurrentCheckedRightClickItem = _rightClickWindowLevel
         data.CurrentActionType = MedicalViewerActionType.WindowLevel

         cell.SetActionKeys(MedicalViewerActionType.Stack, New MedicalViewerKeys(Keys.PageUp, Keys.PageDown, Keys.None, Keys.None, MedicalViewerModifiers.None))



         cell.SetActionKeys(MedicalViewerActionType.WindowLevel, New MedicalViewerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, MedicalViewerModifiers.Ctrl))

         cell.Selected = True

         cell.AlwaysInterpolate = AlwaysInterpolate

         SetCurrent2DAction(cell)
      End Sub






      Private Sub SetAllItemsEnabled(ByVal menu As ContextMenuStrip, ByVal enabled As Boolean)
         For Each item As ToolStripItem In menu.Items
            item.Enabled = enabled
         Next item
      End Sub

      Private Sub SetAllItemsVisible(ByVal menu As ContextMenuStrip, ByVal visible As Boolean)
         For Each item As ToolStripItem In menu.Items
            item.Visible = visible
         Next item
      End Sub

      Private Sub cell_CellMouseDown(ByVal sender As Object, ByVal e As MedicalViewerCellMouseEventArgs)
         Dim cell As MedicalViewerCell = CType(sender, MedicalViewerCell)

         If cell.VirtualImage Is Nothing Then
            _probeToolImage = cell.Image
         Else
            If cell.VirtualImage(e.SubCellIndex).ImageExist Then
               _probeToolImage = cell.VirtualImage(e.SubCellIndex).Image
            End If
         End If
      End Sub
      Private Sub AddProbeToolEvents(ByVal cell As MedicalViewerCell)
         AddHandler cell.ProbeToolTextChanged, AddressOf cell_ProbeToolTextChanged
         AddHandler cell.CellMouseDown, AddressOf cell_CellMouseDown
      End Sub

      Private Sub cell_ProbeToolTextChanged(ByVal sender As Object, ByVal e As MedicalViewerProbeToolTextChangedEventArgs)
         Dim bitmapX As Integer = CInt(e.X)
         Dim bitmapY As Integer = CInt(e.Y)
         Dim output As String

         Dim value As String = GetRealPixelValue(_probeToolImage, bitmapX, bitmapY)

         If value <> "" Then
            output = String.Format("X = {0}, Y = {1} " & Constants.vbLf & "Value = {2} " & Constants.vbLf & "Frame {3}", CInt(e.X), CInt(e.Y), value, e.SubCellIndex + 1)
         Else
            output = String.Format("X = N/A, Y = N/A " & Constants.vbLf & "Value = N/A " & Constants.vbLf & "Frame N/A")
         End If

         e.Text = output
      End Sub

      Private _probeToolImage As RasterImage

      Private Function GetRealPixelValue(ByVal image As RasterImage, ByVal x As Integer, ByVal y As Integer) As String
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
                  Data = image.GetPixelData(y, x)
                  If image.Signed Then
                     Dim highBit As Int16
                     If image.HighBit = 0 Then
                        highBit = CShort(image.BitsPerPixel - 1)
                     Else
                        highBit = CShort(image.HighBit)
                     End If

                     Value = BitConverter.ToInt16(Data, 0)
                     ' account for when all allocated bits are not used for image data encoding
                     If (image.HighBit < (image.BitsPerPixel - 1)) Or (image.LowBit > 0) Then
                        ' actual image low bit is not 0
                        If image.LowBit <> 0 Then
                           Value = CShort(Value >> image.LowBit)
                           highBit = CShort(image.HighBit - image.LowBit)
                        End If

                        ' see if the value is negative 
                        Dim signLimit As Int16
                        signLimit = CShort(Math.Pow(2, highBit + 1) / 2)
                        If Value >= signLimit Then
                           Value = CShort(Value - (Math.Pow(2, highBit + 1)))
                        End If
                     End If

                     Return Value.ToString()
                  Else
                     uValue = BitConverter.ToUInt16(Data, 0)
                     ' when low bit is not zero
                     If image.LowBit > 0 Then
                        uValue = System.Convert.ToUInt16(uValue >> image.LowBit)
                     End If
                     Return uValue.ToString()
                  End If
               Else
                  Dim R As Integer
                  Dim G As Integer
                  Dim B As Integer

                  If image.BitsPerPixel > 32 Then
                     Dim bit16ComponentData As Byte()
                     bit16ComponentData = image.GetPixelData(y, x)
                     R = BitConverter.ToUInt16(bit16ComponentData, 0)
                     G = BitConverter.ToUInt16(bit16ComponentData, 2)
                     B = BitConverter.ToUInt16(bit16ComponentData, 4)
                     Return String.Format("{0}, {1}, {2}", R, G, B)
                  End If


                  Dim PixelColor As RasterColor = image.GetPixelColor(y, x)
                  Return String.Format("{0}, {1}, {2}", PixelColor.R, PixelColor.G, PixelColor.B)
               End If

            End If
         End If
         Return ""
      End Function

      Private Sub cell_CurvedMPRPolygonClicked(ByVal sender As Object, ByVal e As MedicalViewerMPRPolygonClickedEventsArgs)
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)

         If e.Button = MouseButtons.Right Then

            _mousePoint.X = e.X + cell.Location.X
            _mousePoint.Y = e.Y + cell.Location.Y
            _polygonIndex = e.Index
            _polygon = e.Polygon
            _clickType = e.Type
            _polygonHandleClicked = True

            SetAllItemsVisible(_panoramicRightClickMenu, True)
            SetAllItemsEnabled(_panoramicRightClickMenu, True)
            Select Case e.Type
               Case MedicalViewerMPRPolygonHitTest.Body
                  _panoramicRightClickDeletePoint.Visible = False
                  Dim paraxialCell As MedicalViewerParaxialCutCell = GetParaxialCell()
                  ' if there is already one paraxial cell on that line, don't allow adding another.
                  If Not paraxialCell Is Nothing Then
                     _panoramicRightClickCreateParaxialCell.Enabled = False
                  Else ' if there is no paraxial, then disable all the paraxial properties.
                     _panoramicRightClickActiveParaxialColor.Enabled = False
                     _panoramicRightClickParaxialLineColor.Enabled = False
                     _panoramicRightClickParaxialProperties.Enabled = False
                     _panoramicRightClickDeleteParaxialCell.Enabled = False
                  End If

               Case MedicalViewerMPRPolygonHitTest.Handle
                  _panoramicRightClickSeperator1.Visible = False
                  _panoramicRightClickSeperator2.Visible = False
                  _panoramicRightClickInsertPoint.Visible = False
                  _panoramicRightClickDeleteParaxialCell.Visible = False
                  _panoramicRightClickCreateParaxialCell.Visible = False
                  _panoramicRightClickActiveParaxialColor.Visible = False
                  _panoramicRightClickParaxialLineColor.Visible = False
                  _panoramicRightClickParaxialProperties.Visible = False

                  If _polygon.Points.Count <= 2 Then
                     _panoramicRightClickDeletePoint.Enabled = False
                  End If

            End Select

            _panoramicRightClickMenu.Show(_viewer, _mousePoint)
         End If
      End Sub


      Private Sub AddParaxialCell(ByVal cellSource As MedicalViewerMultiCell, ByVal polygon As MedicalViewerMPRPolygon, ByVal index As Integer)
         Dim paraxialCutCell As MedicalViewerParaxialCutCell = New MedicalViewerParaxialCutCell(polygon, index)

         paraxialCutCell.Tag = New CellData(ViewerCellType.Derivate)
         paraxialCutCell.EfficientMemoryEnabled = True
         paraxialCutCell.Rows = 2
         paraxialCutCell.Columns = 2
         paraxialCutCell.ApplyActionOnMove = True
         paraxialCutCell.ShowCellScroll = False
         CopyTags(paraxialCutCell, cellSource, True)

         InitializeCell(paraxialCutCell)

         _viewer.Cells.Add(paraxialCutCell)
      End Sub

      Private Sub cell_CurvedMPRPolygonCreated(ByVal sender As Object, ByVal e As MedicalViewerMPRPolygonEventsArgs)
         Dim cellSource As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         Dim cell As MedicalViewerPanoramicCell = New MedicalViewerPanoramicCell(e.Polygon)

         cell.Tag = New CellData(ViewerCellType.Derivate)

         AddProbeToolEvents(cell)
         CopyTags(cell, cellSource, True)

         AddBasicActionsFor2DCell(cell)

         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.AllCells Or MedicalViewerActionFlags.RealTime)
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.AllCells Or MedicalViewerActionFlags.RealTime)
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.AllCells Or MedicalViewerActionFlags.RealTime)
         _viewer.Cells.Add(cell)

         ' AddParaxialCell(cellSource, e.Polygon, 0);

         e.Polygon.EnableDragThickness = True

         _menuActionWindowLevel_Click(e, e)
      End Sub

#If Not LEADTOOLS_V20_OR_LATER Then
      Private Const _dicomGetImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDectectInvalidRleCompression
#Else
      Private Const _dicomGetImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDetectInvalidRleCompression
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

      Private Sub cell_CurvedMPRDataRequested(ByVal sender As Object, ByVal e As MedicalViewerPanoramicDataRequestedEventArgs)
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         Dim data As CellData = CType(cell.Tag, CellData)
         Dim _codecs As RasterCodecs = New RasterCodecs()

         Dim ds As DicomDataSet = New DicomDataSet()
         If data.CellType = ViewerCellType.SingleFileSeries Then
            ds.Load(data.FileNames(0), DicomDataSetLoadFlags.None)
            e.Frame = ds.GetImage(Nothing, e.FrameIndex, 0, RasterByteOrder.Gray, _dicomGetImageFlags)
         Else
            ds.Load(data.FileNames(e.FrameIndex), DicomDataSetLoadFlags.None)
            e.Frame = ds.GetImage(Nothing, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags)
         End If

         ds.DeleteImage(Nothing, 0, 1)
         ds.Dispose()
      End Sub

      Private Sub cell_Data3DFrameRequested(ByVal sender As Object, ByVal e As MedicalViewer3DFrameRequestedEventArgs)
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         Dim data As CellData = CType(cell.Tag, CellData)

         Dim codecs As RasterCodecs = New RasterCodecs()
         Try
            If data.CellType = ViewerCellType.SingleFileSeries Then
               Dim ds As DicomDataSet = New DicomDataSet()
               ds.Load(data.FileNames(0), DicomDataSetLoadFlags.None)
               e.Image = ds.GetImage(Nothing, e.ImageIndex, 0, RasterByteOrder.Gray, _dicomGetImageFlags)
               ds.Dispose()
            Else
               Dim ds As DicomDataSet = New DicomDataSet()
               ds.Load(data.FileNames(e.ImageIndex), DicomDataSetLoadFlags.None)
               e.Image = ds.GetImage(Nothing, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags)
               ds.Dispose()
            End If
         Finally
            CType(codecs, IDisposable).Dispose()
         End Try
      End Sub

      Private Sub AddBasicActionsFor2DCell(ByVal cell As MedicalViewerBaseCell)
         cell.AddAction(MedicalViewerActionType.Scale)
         cell.AddAction(MedicalViewerActionType.Offset)
         cell.AddAction(MedicalViewerActionType.Stack)
         cell.AddAction(MedicalViewerActionType.MagnifyGlass)
         cell.AddAction(MedicalViewerActionType.WindowLevel)
         If cell.CanExecuteAction(MedicalViewerActionType.Alpha) Then
            cell.AddAction(MedicalViewerActionType.Alpha)
         End If
         cell.AddAction(MedicalViewerActionType.ProbeTool)
      End Sub

      Private Sub cell_DerivativeGenerated(ByVal sender As Object, ByVal e As MedicalViewerDerivativeGeneratedEventArgs)
         e.DerivativeCell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "MIP Slab")
         e.DerivativeCell.Tag = New CellData(ViewerCellType.Derivate)
         e.DerivativeCell.ReferenceLine.Enabled = _showReferenceLine
         e.DerivativeCell.ShowCellBoundaries = _showReferenceBoundaries
         e.DerivativeCell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines

         AddBasicActionsFor2DCell(e.DerivativeCell)

         e.DerivativeCell.ShowCellScroll = _menuShowScrollBar.Checked
         e.DerivativeCell.SetScaleMode(MedicalViewerScaleMode.Fit)
         AddHandler e.DerivativeCell.CellMouseClick, AddressOf _viewer_CellMouseClick
         AddHandler e.DerivativeCell.CellMouseDown, AddressOf _viewer_CellMouseDown
         SetCurrent2DAction(e.DerivativeCell)
         SetCurrentCheckedCellOption(CType(sender, MedicalViewerMultiCell), e.DerivativeCell)
         e.DerivativeCell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.MPRType)
         e.DerivativeCell.SnapRulers = True


         Dim data As CellData = CType((CType(sender, MedicalViewerMultiCell)).Tag, CellData)

         SetAction(e.DerivativeCell, data.CurrentActionType, data.CurrentCheckedItem, data.CurrentCheckedRightClickItem)
      End Sub

      Private Sub cell_Data3DRequested(ByVal sender As Object, ByVal e As MedicalViewerData3DRequestedEventArgs)
         e.Succeed = Medical3DEngine.Provide3DInformation(e)
      End Sub

      Private Sub PrepareRightClickMenu(<System.Runtime.InteropServices.Out()> ByRef menuDest As ContextMenuStrip, ByVal menuSource As ToolStripMenuItem)
         menuDest = New ContextMenuStrip()
         Dim contextArray As ToolStripMenuItem() = New ToolStripMenuItem(menuSource.DropDownItems.Count - 1) {}
         menuSource.DropDownItems.CopyTo(contextArray, 0)
         menuDest.Items.AddRange(contextArray)
      End Sub

      Private Function GetConfigValue() As Boolean
         Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

         Return Convert.ToBoolean(config.AppSettings.Settings("ShowDownloadSamplesDialog").Value)
      End Function



      Private Sub ShowDownloadSamplesDialog()
         If (Not GetConfigValue()) Then
            Dim dialog As ImagesDownloadDialog = New ImagesDownloadDialog("Download Sample Images")
            dialog.TopMost = True
            dialog.ShowDialog()
         End If
      End Sub

      Private Sub InitClass()
         Try
            ShowDownloadSamplesDialog()
            DicomEngine.Startup()

            _viewer = New MedicalViewer(2, 2)
            _viewer.ShowSelectedReferenceLine = True

            _viewer.AllowMultipleSelection = False
            AddHandler _viewer.DeleteCell, AddressOf MedicalViewer_DeleteCell
            AddHandler _viewer.SelectedCellsChanged, AddressOf _viewer_SelectedCellsChanged

            _generatorCellIndex = -1

            _displayPanel.Controls.Add(_viewer)

            _rightClickContextMenu = New ContextMenuStrip()
            Dim contextArray As ToolStripMenuItem() = New ToolStripMenuItem(_cellRightClickMenu.DropDownItems.Count - 1) {}
            _cellRightClickMenu.DropDownItems.CopyTo(contextArray, 0)
            _rightClickContextMenu.Items.AddRange(contextArray)

            _rightClickGeneratorContextMenu = New ContextMenuStrip()
            contextArray = New ToolStripMenuItem(_deleteGeneratorDropMenu.DropDownItems.Count - 1) {}
            _deleteGeneratorDropMenu.DropDownItems.CopyTo(contextArray, 0)
            _rightClickGeneratorContextMenu.Items.AddRange(contextArray)

            _currentSelectedMenuItem = _menu2DCell
            _currentSelectedMenuItem.Checked = True

            _MPRMode = False
            _actionType = MedicalViewerActionType.WindowLevel
            _menuActionWindowLevel.Checked = True
            _rightClickWindowLevel.Checked = True
            oldMeshColor = Color.FromArgb(CInt(255 * 0.8), 128, CInt(255 * 0.8))
            AlwaysInterpolate = True
            Show()


            ' open the DICOMDIR dialog
            _menuItemFileLoadDICOMDIR_Click(Nothing, Nothing)
         Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source)
         End Try
      End Sub

      Private Sub SetCurrentCheckedCellOption(ByVal multiCell As MedicalViewerMultiCell, ByVal cell As MedicalViewerCell)
         If multiCell.GetActionButton(MedicalViewerActionType.Alpha) = MedicalViewerMouseButtons.Left Then
            SetAction(cell, MedicalViewerActionType.Alpha, _menuActionAlpha, _rightClickAlpha)
         ElseIf multiCell.GetActionButton(MedicalViewerActionType.Scale) = MedicalViewerMouseButtons.Left Then
            SetAction(cell, MedicalViewerActionType.Scale, _menuActionScale, _rightClickScale)
         ElseIf multiCell.GetActionButton(MedicalViewerActionType.MagnifyGlass) = MedicalViewerMouseButtons.Left Then
            SetAction(cell, MedicalViewerActionType.MagnifyGlass, _menuActionMagnify, _rightClickMagnify)
         ElseIf multiCell.GetActionButton(MedicalViewerActionType.Offset) = MedicalViewerMouseButtons.Left Then
            SetAction(cell, MedicalViewerActionType.Offset, _menuActionPan, _rightClickPan)
         End If
      End Sub


      Private Function GetCurrentCheckedCellOption(ByVal cellIndex As Integer) As ToolStripMenuItem
         Dim control As Control = _viewer.Cells(cellIndex)

         If TypeOf control Is Medical3DControl Then
            Dim control3D As Medical3DControl = CType(_viewer.Cells(cellIndex), Medical3DControl)

            _menuInvert.Checked = control3D.ObjectsContainer.Inverted
            Select Case control3D.ObjectsContainer.VolumeType
               Case Medical3DVolumeType.SSD
                  Return _menuVolumeSSD
               Case Medical3DVolumeType.VRT
                  Return _menuVolumeVRT
               Case Medical3DVolumeType.MPR
                  Return _menuVolumeMPR
               Case Medical3DVolumeType.MIP
                  Return _menuVolumeMIP
               Case Medical3DVolumeType.MINIP
                  Return _menuVolumeMinIP
            End Select
         End If

         If TypeOf control Is MedicalViewerMultiCell Then
            Dim cell As MedicalViewerMultiCell = CType(_viewer.Cells(cellIndex), MedicalViewerMultiCell)
            If cell.ReferenceLine.DoubleCutLines.Count > 0 Then
               Return _menuDoubleCutPlane2DCell
            ElseIf cell.ReferenceLine.CutLines.Count > 0 Then
               Return _menuCutPlane2DCell
            Else
               Return _menu2DCell
            End If
         End If
         Return _menu2DCell
      End Function

      Private Sub UncheckAllActionMenu()
         UncheckThePerviousMenuItem(_menuActionWindowLevel)
         UncheckThePerviousMenuItem(_rightClickWindowLevel)
      End Sub

      Private Sub _viewer_SelectedCellsChanged(ByVal sender As Object, ByVal e As MedicalViewerSelectedCellsChangedEventArgs)
         Dim cell As MedicalViewerBaseCell = GetFirstSelectedControl()
         If Not cell Is Nothing Then
            If (TypeOf cell Is MedicalViewerMultiCell) OrElse (TypeOf cell Is MedicalViewerCell) Then
               Dim multiCell As MedicalViewerCell = CType(cell, MedicalViewerCell)
               _showReferenceLine = multiCell.ReferenceLine.Enabled
               _menuShowReferenceLine.Checked = _showReferenceLine
               _showReferenceBoundaries = multiCell.ShowCellBoundaries
               _showFirstAndLastReferenceLines = multiCell.ReferenceLine.ShowFirstAndLast
               _menuShowReferenceBoundaries.Checked = _showReferenceBoundaries
               _menuShowScrollBar.Checked = multiCell.ShowCellScroll
               _menuInvert.Checked = False
            ElseIf TypeOf cell Is Medical3DControl Then
               Dim cell3D As Medical3DControl = CType(cell, Medical3DControl)
               _menuInvert.Checked = cell3D.ObjectsContainer.Inverted
            End If

            _currentSelectedMenuItem.Checked = False
            _currentSelectedMenuItem = GetCurrentCheckedCellOption(e.SelectedCellsIndexes(0))
            _currentSelectedMenuItem.Checked = True
         End If
      End Sub

      Private Sub _viewer_PlaneCutLineClicked(ByVal sender As Object, ByVal e As MedicalViewerPlaneCutLineEventArgs)
         If e.Button = MedicalViewerMouseButtons.Right Then
            _generatorCellIndex = e.CellIndex
            _planeCutLineClicked = True
            _mousePoint.X = e.X + _viewer.Cells(e.CellIndex).Location.X
            _mousePoint.Y = e.Y + _viewer.Cells(e.CellIndex).Location.Y
            _rightClickGeneratorContextMenu.Show(_viewer, _mousePoint)
         End If
      End Sub

      Private Sub _viewer_CellMouseDown(ByVal sender As Object, ByVal e As MedicalViewerCellMouseEventArgs)
         _currentMousePoint.X = e.X
         _currentMousePoint.Y = e.Y
      End Sub

      Private Sub _viewer_CellMouseClick(ByVal sender As Object, ByVal e As MedicalViewerCellMouseEventArgs)
         If _polygonHandleClicked Then
            Return
         End If
         ' if the plane cutline event is fired, don't show the right click menu.
         If _planeCutLineClicked Then
            _planeCutLineClicked = False
            Return
         End If

         If Not ((_currentMousePoint.X = e.X) AndAlso (_currentMousePoint.Y = e.Y)) Then
            Return
         End If


         If e.Button = MouseButtons.Right Then
            _mousePoint.X = e.X + _viewer.Cells(e.CellIndex).Location.X
            _mousePoint.Y = e.Y + _viewer.Cells(e.CellIndex).Location.Y
            _generatorCellIndex = e.CellIndex

            _rightClickContextMenu.Show(_viewer, _mousePoint)
            EnableRightClickMenuItems(sender)
         End If
      End Sub


      ' Detect whehter the cell has an image.
      Private Function Is2DCell(ByVal cell As Control) As Boolean
         Return ((TypeOf cell Is MedicalViewerCell) OrElse (TypeOf cell Is MedicalViewerMultiCell))
      End Function

      Private Function SearchForTheGeneratorCellAndReturnTheOtherCell(ByVal cell As MedicalViewerCell) As MedicalViewerCell
         Dim index As Integer
         index = 0
         Do While index < _viewer.Cells.Count
            If TypeOf _viewer.Cells(index) Is MedicalViewerMultiCell Then
               Dim multiCell As MedicalViewerMultiCell = CType(_viewer.Cells(index), MedicalViewerMultiCell)

               Dim cutPlaneIndex As Integer
               cutPlaneIndex = 0
               Do While cutPlaneIndex < multiCell.ReferenceLine.DoubleCutLines.Count
                  If multiCell.ReferenceLine.DoubleCutLines(cutPlaneIndex).FirstDerivativeCell Is cell Then
                     multiCell.Selected = True
                     Return multiCell.ReferenceLine.DoubleCutLines(cutPlaneIndex).SecondDerivativeCell
                  End If

                  If multiCell.ReferenceLine.DoubleCutLines(cutPlaneIndex).SecondDerivativeCell Is cell Then
                     multiCell.Selected = True
                     Return multiCell.ReferenceLine.DoubleCutLines(cutPlaneIndex).FirstDerivativeCell
                  End If
                  cutPlaneIndex += 1
               Loop
            End If
            index += 1
         Loop
         Return Nothing
      End Function

      Private Sub DeleteAllDerivativeCells(ByVal cell As MedicalViewerMultiCell)
         DeleteAllMPRPolygonFromCell(cell)

         Dim index As Integer
         Dim list As List(Of MedicalViewerCell) = New List(Of MedicalViewerCell)()

         index = 0
         Do While index < cell.ReferenceLine.CutLines.Count
            list.Add(cell.ReferenceLine.CutLines(index).DerivativeCell)
            index += 1
         Loop

         index = 0
         Do While index < cell.ReferenceLine.DoubleCutLines.Count
            list.Add(cell.ReferenceLine.DoubleCutLines(index).FirstDerivativeCell)
            list.Add(cell.ReferenceLine.DoubleCutLines(index).SecondDerivativeCell)
            index += 1
         Loop

         ' Delete the cell itself.
         cell.Dispose()

         ' Delete all the derivative cells.
         index = 0
         Do While index < list.Count
            list(index).Dispose()
            index += 1
         Loop
      End Sub

      Private Sub MedicalViewer_DeleteCell(ByVal sender As Object, ByVal e As MedicalViewerDeleteEventArgs)
         ' don't delete the cell on the MPR mode.
         If _MPRMode Then
            e.Delete = False
         Else
            Dim i As Integer = 0
            Do While i < e.CellIndexes.Length
               If TypeOf _viewer.Cells(e.CellIndexes(i)) Is Medical3DControl Then
                  Dim control3D As Medical3DControl = CType(_viewer.Cells(e.CellIndexes(i)), Medical3DControl)

                  If Not (CType(control3D.Tag, CellData)).Cell Is Nothing Then
                     Dim baseCell As MedicalViewerBaseCell = CType((CType(control3D.Tag, CellData)).Cell, MedicalViewerBaseCell)
                     baseCell.Dispose()
                  End If
               Else
                  e.Delete = False
                  If TypeOf _viewer.Cells(e.CellIndexes(0)) Is MedicalViewerPanoramicCell Then
                     Dim panoramicCell As MedicalViewerPanoramicCell = CType(_viewer.Cells(e.CellIndexes(0)), MedicalViewerPanoramicCell)
                     If Not panoramicCell.Polygon Is Nothing Then
                        If Not panoramicCell.Polygon.Parent Is Nothing Then
                           DeleteAllMPRPolygonFromCell(CType(panoramicCell.Polygon.Parent, MedicalViewerMultiCell))
                        End If
                     Else
                        e.Delete = True
                     End If
                  Else
                     If TypeOf _viewer.Cells(e.CellIndexes(0)) Is MedicalViewerMultiCell Then
                        DeleteAllDerivativeCells(CType(_viewer.Cells(e.CellIndexes(0)), MedicalViewerMultiCell))
                     ElseIf TypeOf _viewer.Cells(e.CellIndexes(0)) Is MedicalViewerCell Then
                        Dim cell As MedicalViewerCell = CType(_viewer.Cells(e.CellIndexes(0)), MedicalViewerCell)
                        Dim theOtherCell As MedicalViewerCell = SearchForTheGeneratorCellAndReturnTheOtherCell(CType(_viewer.Cells(e.CellIndexes(0)), MedicalViewerCell))

                        _currentSelectedMenuItem.Checked = False
                        _currentSelectedMenuItem = _menu2DCell
                        _currentSelectedMenuItem.Checked = True

                        If Not theOtherCell Is Nothing Then
                           theOtherCell.Dispose()
                        End If
                        cell.Dispose()
                     End If
                  End If
               End If
               i += 1
            Loop
         End If
      End Sub

      Private Sub _menuItemFileLoadDICOMDIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileLoadDICOMDIR.Click
         ' if there is an already instance of the series browser, then don't create the a new one. and just use the already created one
         ' You will notice that all the data (series and study) are still stored.
         If seriesBrowserDialog Is Nothing Then
            seriesBrowserDialog = New SeriesBrowser()
            seriesBrowserDialog.LoadAs3D = True
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
               _counter = 0
            End If

            If e.State = FrameLoadedState.FrameLoaded Then
               _cellData.InstanceNumbers(_counter) = e.InstanceNumber
               _cellData.FileNames(_counter) = e.ImagePath
               _cellData.ImagePositions(_counter) = e.ImagePosition
               _counter += 1
            End If

            If e.State = FrameLoadedState.EndLoading Then
               Dim a As New List(Of Point3D)()


               a.Add(e.ImagePosition)

               Dim b As New List(Of Single())()


               b.Add(e.ImageOrientation)


               LoadImagesToMedicalViewer(e.SeriesInformation, e.ImageOrientation, seriesBrowserDialog.LoadAs3D)
            End If
         Catch generatedExceptionName As Exception
            e.Cancel = True
         End Try
      End Sub

      Private Function LoadImagesToMedicalViewer(ByVal image As SeriesInformation, ByVal imageOrientation As Single(), ByVal loadAs3D As Boolean) As Boolean
         seriesBrowserDialog.DisableLoading = True

         Dim data As CellData = _cellData

         Dim cell As MedicalViewerMultiCell = New MedicalViewerMultiCell(Nothing, False, 1, 1)
         cell.Tag = data



         cell.FitImageToCell = False
         InitializeCell(cell)
         AddCellToViewer(cell)
         cell.Focus()

         _currentSelectedMenuItem.Checked = False
         _currentSelectedMenuItem = _menu2DCell
         _currentSelectedMenuItem.Checked = True

         SetCellTags(cell, image)
         cell.FitImageToCell = False
         cell.ReferenceLine.Enabled = _showReferenceLine
         cell.ShowCellBoundaries = _showReferenceBoundaries
         cell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines

         cell.PixelSpacing = New Point2D(CSng(image.VoxelSpacing.X), CSng(image.VoxelSpacing.Y))

         cell.FrameOfReferenceUID = image.FrameOfReferenceUID
         If Not imageOrientation Is Nothing Then
            If imageOrientation.Length <> 0 Then
               cell.ImageOrientation = imageOrientation
            End If
         Else
            _cellData.CellType = ViewerCellType.Other
         End If
         CType(cell.Tag, CellData).FrameIndex = (image.DicomFrameNumber + 1)


         EnableCellLowMemoryUsage(cell)
         SetFrameInformation(cell)
         cell.SetScaleMode(MedicalViewerScaleMode.Fit)

         If _cellData.CellType = ViewerCellType.Cell2D AndAlso cell.VirtualImage.Count >= 3 Then
            If loadAs3D Then
               Dim control3D As Medical3DControl = ConvertTo3D(cell)
               If _MPRMode Then
                  control3D.AxialFrame = CType(_viewer.Cells(1), MedicalViewerMPRCell)
                  control3D.SagittalFrame = CType(_viewer.Cells(2), MedicalViewerMPRCell)
                  control3D.CoronalFrame = CType(_viewer.Cells(3), MedicalViewerMPRCell)
               End If
            End If
         Else
            If _MPRMode Then
               _menu2DCell_Click(Nothing, Nothing)
            End If
         End If

         seriesBrowserDialog.DisableLoading = False

         Return True
      End Function

      Private Sub SetFrameInformation(ByVal cell As MedicalViewerMultiCell)
         Dim index As Integer
         Dim data As CellData = CType(cell.Tag, CellData)
         Dim count As Integer = data.FileNames.Length

         index = 0
         Do While index < count
            cell.SetTag(index, 5, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Im: " & data.InstanceNumbers(index).ToString() & " / " & count.ToString())
            cell.SetImagePosition(index, data.ImagePositions(index), index = (count - 1))
            index += 1
         Loop
      End Sub

      Private Sub EnableCellLowMemoryUsage(ByVal cell As MedicalViewerMultiCell)
         Dim cellData As CellData = (CType(cell.Tag, CellData))
         Dim count As Integer = cellData.FileNames.Length
         Dim index As Integer
         Dim data As CellData = CType(cell.Tag, CellData)
         Dim imagesInformation As MedicalViewerImageInformation() = New MedicalViewerImageInformation(count - 1) {}

         Dim codecs As RasterCodecs = New RasterCodecs()
         Try
            Dim counter As CounterDialog = New CounterDialog(count, 1, Me)
            counter.LoadingObject = True
            counter.LoadingText = "Preparing Series Data"
            counter.Show()
            counter.Update()

            index = 0
            Do While index < count

               Dim codecsInformation As CodecsImageInfo = codecs.GetInformation(cellData.FileNames(index), True, cellData.FrameIndex)
               Try
                  counter.Percent = CInt(index * 100 / (Math.Max(count - 1, 1)))
                  If (index Mod 5) = 0 Then
                     Application.DoEvents()
                  End If
                  imagesInformation(index) = New MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height)
               Finally
                  CType(codecsInformation, IDisposable).Dispose()
               End Try

               index += 1
            Loop

            counter.Close()
            counter.Dispose()

            AddHandler cell.FramesRequested, AddressOf cell_FramesRequested
            cell.EnableLowMemoryUsage(2, cellData.FileNames.Length, imagesInformation)
         Finally
            CType(codecs, IDisposable).Dispose()
         End Try
      End Sub

      Private Function LoadRequestedFrameFileName(ByVal e As MedicalViewerRequestedFramesInformationEventArgs, ByVal codecs As RasterCodecs, ByVal data As CellData, ByVal index As Integer) As RasterImage
         Dim ds As DicomDataSet = New DicomDataSet()
         Dim image As RasterImage = Nothing
         If data.CellType <> ViewerCellType.SingleFileSeries Then
            ds.Load(data.FileNames(index), DicomDataSetLoadFlags.None)
            image = ds.GetImage(Nothing, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags)

         Else
            image = GetImage(ds, data.FileNames(0), index)
         End If

         ds.Dispose()
         Return image
      End Function

      Private Sub cell_FramesRequested(ByVal sender As Object, ByVal e As MedicalViewerRequestedFramesInformationEventArgs)
         Dim cell As MedicalViewerMultiCell = CType(sender, MedicalViewerMultiCell)
         Dim data As CellData = CType(cell.Tag, CellData)

         Dim viewer As MedicalViewer = CType(cell.Parent, MedicalViewer)
         If data Is Nothing Then
            Return
         End If

         Dim codecs As RasterCodecs = New RasterCodecs()
         Try
            Dim i As Integer

            If e.RequestedFramesIndexes.Length > 0 Then
               Dim image As RasterImage = LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes(0))
               Try
                  i = 1
                  Do While i < e.RequestedFramesIndexes.Length
                     image.AddPage(LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes(i)))
                     i += 1
                  Loop


                  cell.SetRequestedImage(image, e.RequestedFramesIndexes, MedicalViewerSetImageOptions.Insert)
               Finally
                  CType(image, IDisposable).Dispose()
               End Try
            End If
         Finally
            CType(codecs, IDisposable).Dispose()
         End Try
      End Sub

      Private Sub FillCellTag(ByVal cell As MedicalViewerMultiCell)
      End Sub


      Private Sub SetCellTags(ByVal cell As MedicalViewerMultiCell, ByVal image As SeriesInformation)
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
            cell.SetTag(8, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Echo: " & image.EchoNumber.ToString())
         End If


         cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)

         cell.SetTag(4, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.Alpha)

         cell.SetTag(6, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale)
      End Sub

      Private Sub _menuVolumeMPR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuVolumeMPR.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         If control3D Is Nothing Then
            Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
            If cell Is Nothing Then
               Return
            End If

            control3D = ConvertTo3D(cell)

            If control3D Is Nothing Then
               Return
            End If
         End If

         control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MPR

         CheckMenu(_menuVolumeMPR)

      End Sub

      Private Sub CheckMenu(ByVal selectedMenuItem As ToolStripMenuItem)
         _currentSelectedMenuItem.Checked = False
         selectedMenuItem.Checked = True
         _currentSelectedMenuItem = selectedMenuItem
      End Sub



      Private Sub _menuVolumeVRT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuVolumeVRT.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         If control3D Is Nothing Then
            Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
            If cell Is Nothing Then
               Return
            End If

            control3D = ConvertTo3D(cell)

            If control3D Is Nothing Then
               Return
            End If
         End If

         control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.VRT


         Dim data As CellData = CType(control3D.Tag, CellData)
         If data.ColorMapIndex <> -1 Then
            Dim object3d As Medical3DObject = control3D.ObjectsContainer.Objects(0)
            object3d.ColorMap = _cellData.ColorMap
            object3d.Palette = _cellData.Palette
         End If



         CheckMenu(_menuVolumeVRT)
      End Sub

      Private Sub _menuVolumeMIP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuVolumeMIP.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         If control3D Is Nothing Then
            Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
            If cell Is Nothing Then
               Return
            End If

            control3D = ConvertTo3D(cell)

            If control3D Is Nothing Then
               Return
            End If
         End If

         control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MIP

         CheckMenu(_menuVolumeMIP)
      End Sub

      Private Function GetFirstSelectedMultiCell() As MedicalViewerMultiCell
         For Each control As Control In _viewer.Cells
            If TypeOf control Is MedicalViewerMultiCell Then
               Dim cell As MedicalViewerMultiCell = CType(control, MedicalViewerMultiCell)

               If cell.Selected Then
                  Return CType(control, MedicalViewerMultiCell)
               End If
            End If
         Next control
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
         Next control
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
         Next control
         Return Nothing
      End Function

      Private Sub _menuInvert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuInvert.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         control3D.ObjectsContainer.Inverted = Not control3D.ObjectsContainer.Inverted
         _menuInvert.Checked = Not _menuInvert.Checked
      End Sub

      Private Sub _menuProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuProperties.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         If control3D Is Nothing Then
            Return
         End If


         CType(New ContainerProperties(control3D, _viewer, control3D.ObjectsContainer), ContainerProperties).ShowDialog()
      End Sub

      Private Sub _mainPanel_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _mainPanel.SizeChanged
         If Not _viewer Is Nothing Then
            If Not _displayPanel Is Nothing Then
               _displayPanel.Left = 0
               _displayPanel.Top = 0
               _displayPanel.Width = _mainPanel.Width
               _displayPanel.Height = _mainPanel.Height
            End If

            _viewer.SetBounds(_displayPanel.Left, _displayPanel.Top, _displayPanel.Width, _displayPanel.Height)
         End If
      End Sub

      Private Sub EnableCellLowMemoryUsage(ByVal cell As MedicalViewerMultiCell, ByVal fileName As String, ByVal info As CodecsImageInfo)
         Dim index As Integer
         Dim count As Integer = info.TotalPages
         Dim cellData As CellData = (CType(cell.Tag, CellData))

         Dim imagesInformation As MedicalViewerImageInformation() = New MedicalViewerImageInformation(count - 1) {}

         Dim codecs As RasterCodecs = New RasterCodecs()
         Try
            Dim codecsInformation As CodecsImageInfo = codecs.GetInformation(fileName, True, cellData.FrameIndex)
            Try

               index = 0
               Do While index < count
                  imagesInformation(index) = New MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height)
                  index += 1
               Loop

               AddHandler cell.FramesRequested, AddressOf cell_FramesRequested
               cell.EnableLowMemoryUsage(2, count, imagesInformation)
            Finally
               CType(codecsInformation, IDisposable).Dispose()
            End Try
         Finally
            CType(codecs, IDisposable).Dispose()
         End Try
      End Sub

      Private _openInitialPath As String = String.Empty
      Private Sub GetFileName(<System.Runtime.InteropServices.Out()> ByRef fileName As String)
         Dim codecs As RasterCodecs = New RasterCodecs()
         Dim loader As ImageFileLoader = New ImageFileLoader()
         fileName = ""
         loader.OpenDialogInitialPath = _openInitialPath

         Try
            loader.ShowLoadPagesDialog = False
            If loader.Load(Me, codecs, False) <> 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               fileName = ""
               If loader.LastPage <> 0 Then
                  If loader.LastPage = -1 Then
                     counter = New CounterDialog(-1, 0, Me)
                  Else
                     counter = New CounterDialog(loader.LastPage - loader.FirstPage + 1, 0, Me)
                  End If
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

      Private Sub AddNewDicomDirectoryTab(ByVal dicomDirectroyAvailable As Boolean)
         Return
      End Sub


      ' This method returns the specified DICOM tag in a string format.
      Private Function GetDicomTag(ByVal ds As DicomDataSet, ByVal tag As Long) As String
         Dim patientElement As DicomElement = ds.FindFirstElement(Nothing, tag, True)

         If Not patientElement Is Nothing Then
            Return ds.GetConvertValue(patientElement)
         End If

         Return Nothing
      End Function


      Private Function GetImage(ByVal dicomDataSet As DicomDataSet, ByVal imagePath As String, ByVal index As Integer) As RasterImage
         Try
            dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None)
            Return dicomDataSet.GetImage(Nothing, index, 0, RasterByteOrder.Gray, _dicomGetImageFlags)

         Catch e1 As Exception
            Dim _codecs As RasterCodecs = New RasterCodecs()

            Return _codecs.Load(imagePath, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, 1, 1)
         End Try
      End Function

      ' Load the DICOM file
      ' Load the DICOM file
      Private Function LoadDICOM(ByVal dicomDataSet As DicomDataSet, ByVal imagePath As String) As SeriesInformation
         Try
            Dim imageInformation As SeriesInformation = New SeriesInformation()


            imageInformation.Image = GetImage(dicomDataSet, imagePath, 0)
            If imageInformation.Image Is Nothing Then
               Return Nothing
            End If

            Dim orientation As Double()
            Dim doubleArray As Double()

            Dim patientElement As DicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.PixelSpacing, True)

            If Not patientElement Is Nothing Then
               doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 1)
               imageInformation.VoxelSpacing = New Point3D(CSng(doubleArray(0)), CSng(doubleArray(0)), 0)
            End If

            patientElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.ImageOrientationPatient, True)

            If Not patientElement Is Nothing Then
               orientation = dicomDataSet.GetDoubleValue(patientElement, 0, 6)
               imageInformation.ImageOrientation = orientation
            End If

            patientElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.ImagePositionPatient, True)

            If Not patientElement Is Nothing Then
               doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 3)
               imageInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray)
            End If

            patientElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.FrameOfReferenceUID, True)

            If Not patientElement Is Nothing Then
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

      Private Sub SetDICOMInformation(ByVal dicomDataSet As DicomDataSet, ByVal cell As MedicalViewerMultiCell)
         Dim index As Integer = 0

         Dim cellData As CellData = CType(cell.Tag, CellData)

         cell.SuspendCalculation()

         Dim patientElement As DicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.PerFrameFunctionalGroupsSequence, True)

         If patientElement Is Nothing Then
            Return
         End If


         Dim itemElement As DicomElement = dicomDataSet.FindFirstElement(patientElement, DicomTag.Item, False)

         If itemElement Is Nothing Then
            Return
         End If

         Dim planePositionElement As DicomElement = dicomDataSet.FindFirstElement(itemElement, DicomTag.PlanePositionSequence, False)

         If planePositionElement Is Nothing Then
            Return
         End If


         Dim imagePositionElement As DicomElement = dicomDataSet.FindFirstElement(planePositionElement, DicomTag.ImagePositionPatient, False)

         Do While Not imagePositionElement Is Nothing
            If Not imagePositionElement Is Nothing Then
               Dim doubleArray As Double() = dicomDataSet.GetDoubleValue(imagePositionElement, 0, 3)

               cellData.ImagePositions(index) = Point3D.FromDoubleArray(doubleArray)

               cell.SetImagePosition(index, cellData.ImagePositions(index), False)
               index += 1
            End If

            imagePositionElement = dicomDataSet.FindNextElement(imagePositionElement, False)
         Loop
         cell.ResumeCalculation()
      End Sub


      Private Sub _menuItemFileLoadDICOM_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileLoadDICOM.Click
         Dim imagePath As String = Nothing
         Dim codecs As RasterCodecs = New RasterCodecs()
         GetFileName(imagePath)

         ' Insert new cell if the user has selected an image.
         If imagePath <> "" Then
            Dim dicomDataSet As DicomDataSet = New DicomDataSet()
            dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None)

            Dim imageInformation As SeriesInformation = LoadDICOM(dicomDataSet, imagePath)
            If imageInformation Is Nothing Then
               Return
            End If
            Dim image As RasterImage = imageInformation.Image

            If imageInformation Is Nothing Then
               image.Dispose()
               Return
            End If

            Dim cell As MedicalViewerMultiCell = New MedicalViewerMultiCell(Nothing, True, 1, 1)
            Dim cellData As CellData = New CellData(ViewerCellType.SingleFileSeries)
            cellData.FileNames = New String(0) {}
            cellData.FileNames(0) = imagePath
            cell.Tag = cellData

            Dim oldCursor As Cursor = Cursor
            Cursor = Cursors.WaitCursor
            Dim info As CodecsImageInfo = codecs.GetInformation(imagePath, True)

            EnableCellLowMemoryUsage(cell, imagePath, info)

            cellData.ImagePositions = New Point3D(info.TotalPages - 1) {}

            SetDICOMInformation(dicomDataSet, cell)

            Cursor = oldCursor

            AddCellToViewer(cell)
            InitializeCell(cell)
            SetCellTags(cell, imageInformation)
            cell.FitImageToCell = False
            cell.SnapRulers = True
            cell.ReferenceLine.Enabled = _showReferenceLine
            cell.ShowCellBoundaries = _showReferenceBoundaries
            cell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines
            cell.SetScaleMode(MedicalViewerScaleMode.Fit)
            image.Dispose()

            If info.TotalPages >= 3 Then
               ConvertTo3D(cell)
            End If
         End If
      End Sub

      Private Sub _menuFile_exit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuFile_exit.Click
         Me.Close()
      End Sub

      Private Sub _menuEdit_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _menuEdit.DropDownOpening
         Dim enable As Boolean = True
         Dim ssdEnabled As Boolean = False
         Dim vrtEnabled As Boolean = False

         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         Dim multiCell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()

         If control3D Is Nothing Then
            enable = False
         End If

         If Not control3D Is Nothing Then
            ssdEnabled = (control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD)
            vrtEnabled = (control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.VRT)


            If (CType(control3D.Tag, CellData)).CellType = ViewerCellType.Mesh3D Then
               enable = False
            End If
         End If



         _menuRemoveDensity.Enabled = enable AndAlso Not ssdEnabled

         _menuSSDMeshColor.Enabled = _menuSSDIsoThreshold.Enabled = ssdEnabled

         _menuItemEditReset.Enabled = _menuDeleteAll.Enabled = CBool(_viewer.Cells.Count <> 0)


         _editColorMap.Enabled = vrtEnabled
      End Sub

      Private Sub CopyTags(ByVal destinationCell As MedicalViewerBaseCell, ByVal cell As MedicalViewerBaseCell, ByVal addWindowLevelTag As Boolean)
         CopyTags(destinationCell, cell, addWindowLevelTag, True)
      End Sub


      Private Sub CopyTags(ByVal destinationCell As MedicalViewerBaseCell, ByVal cell As MedicalViewerBaseCell, ByVal addWindowLevelTag As Boolean, ByVal addScaleTag As Boolean)
         Dim information As MedicalViewerTagInformation
         information = cell.GetTag(0, MedicalViewerTagAlignment.LeftCenter)
         If Not information Is Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, information.Type)
         End If
         information = cell.GetTag(0, MedicalViewerTagAlignment.RightCenter)
         If Not information Is Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.RightCenter, information.Type)
         End If
         information = cell.GetTag(0, MedicalViewerTagAlignment.TopCenter)
         If Not information Is Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, information.Type)
         End If
         information = cell.GetTag(0, MedicalViewerTagAlignment.BottomCenter)
         If Not information Is Nothing Then
            destinationCell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, information.Type)
         End If

         information = cell.GetTag(2, MedicalViewerTagAlignment.TopRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(3, MedicalViewerTagAlignment.TopRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(4, MedicalViewerTagAlignment.TopRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(4, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(5, MedicalViewerTagAlignment.TopRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(6, MedicalViewerTagAlignment.TopRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(6, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(7, MedicalViewerTagAlignment.TopRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(7, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text)
         End If

         information = cell.GetTag(9, MedicalViewerTagAlignment.BottomRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(9, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(8, MedicalViewerTagAlignment.BottomRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(8, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(7, MedicalViewerTagAlignment.BottomRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(7, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(6, MedicalViewerTagAlignment.BottomRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(6, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(5, MedicalViewerTagAlignment.BottomRight)
         If Not information Is Nothing Then
            destinationCell.SetTag(5, MedicalViewerTagAlignment.BottomRight, information.Type)
         End If


         information = cell.GetTag(2, MedicalViewerTagAlignment.TopLeft)
         If Not information Is Nothing Then
            destinationCell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(3, MedicalViewerTagAlignment.TopLeft)
         If Not information Is Nothing Then
            destinationCell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text)
         End If
         information = cell.GetTag(4, MedicalViewerTagAlignment.TopLeft)
         If Not information Is Nothing Then
            destinationCell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text)
         End If

         If addWindowLevelTag Then
            information = cell.GetTag(2, MedicalViewerTagAlignment.BottomLeft)
            If Not information Is Nothing Then
               destinationCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, information.Type)
            End If
         End If

         If addScaleTag Then
            information = cell.GetTag(6, MedicalViewerTagAlignment.TopLeft)
            If Not information Is Nothing Then
               destinationCell.SetTag(6, MedicalViewerTagAlignment.TopLeft, information.Type)
            End If

            information = cell.GetTag(7, MedicalViewerTagAlignment.TopLeft)
            If Not information Is Nothing Then
               destinationCell.SetTag(7, MedicalViewerTagAlignment.TopLeft, information.Type)
            End If
         End If
      End Sub


      ' Convert the 2D Cell to 3D
      Private Function ConvertTo3D(ByVal cell As MedicalViewerMultiCell) As Medical3DControl
         Dim control3D As Medical3DControl = Nothing
         Dim counterDialog As CounterDialog = Nothing
         Dim image As RasterImage = Nothing
         Try
            If _menuActionPanoramicPolygon.Checked Then
               _menuActionWindowLevel_Click(Nothing, Nothing)
            End If

            _mainMenu.Enabled = False
            Dim codecs As RasterCodecs = New RasterCodecs()
            Try
               Dim index As Integer

               Dim data As CellData = CType(cell.Tag, CellData)

               DeleteAllGeneratorsFromCell(cell)
               DeleteAllMPRPolygonFromCell(cell)
               cell.DisposeCutPlanesData()

               counterDialog = New CounterDialog(Me)

               control3D = New Medical3DControl()
               control3D.Tag = counterDialog

               control3D.ObjectsContainer.Objects.Add(New Medical3DObject())

               Initialize3DCell(control3D)

               Dim count As Integer

               StartProgress(counterDialog)

               Dim created As Boolean = True

               If data.CellType = ViewerCellType.SingleFileSeries Then
                  count = cell.VirtualImage.Count
                  created = control3D.ObjectsContainer.Objects(0).MemoryEfficientInit(count)
                  If (Not created) Then
                     ' Remove the object
                     control3D.ObjectsContainer.Objects.RemoveAt(0)
                     control3D.Dispose()
                     MessageBox.Show("Not Enough memory to allocate the 3D object")
                     EndProgress(counterDialog)
                     Return Nothing
                  End If

                  index = 0
                  Do While index < count
                     image = codecs.Load(data.FileNames(0), 0, CodecsLoadByteOrder.BgrOrGray, index + 1, index + 1)
                     control3D.ObjectsContainer.Objects(0).MemoryEfficientSetFrame(image, index, data.ImagePositions(index), True)
                     image.Dispose()
                     image = Nothing
                     index += 1
                  Loop
               Else
                  count = data.FileNames.Length
                  created = control3D.ObjectsContainer.Objects(0).MemoryEfficientInit(count)
                  If (Not created) Then
                     ' Remove the object
                     control3D.ObjectsContainer.Objects.RemoveAt(0)
                     control3D.Dispose()
                     MessageBox.Show("Not Enough memory to allocate the 3D object")
                     EndProgress(counterDialog)
                     Return Nothing
                  End If

                  Dim ds As DicomDataSet = New DicomDataSet()
                  index = 0
                  Do While index < count
                     ds.Load(data.FileNames(index), DicomDataSetLoadFlags.None)

                     image = ds.GetImage(Nothing, data.FrameIndex - 1, 0, RasterByteOrder.Gray, _dicomGetImageFlags)
                     ds.DeleteImage(Nothing, 0, 1)

                     control3D.ObjectsContainer.Objects(0).MemoryEfficientSetFrame(image, index, data.ImagePositions(index), False)
                     image.Dispose()
                     image = Nothing
                     index += 1
                  Loop
                  ds.Dispose()
               End If

               control3D.ObjectsContainer.Objects(0).MemoryEfficientEnd(cell.ImageOrientation, cell.PixelSpacing)

               EndProgress(counterDialog)
               control3D.Tag = data

               index = _viewer.Cells.IndexOf(cell)

               _viewer.SuspendLayout()

               If index <> -1 Then
                  _viewer.Cells.RemoveAt(index)
               End If
               CopyTags(control3D, cell, True, False)

               data.Cell = cell
               control3D.Tag = data
               _viewer.Cells.Insert(index, control3D)
               _viewer.ResumeLayout()
               control3D.Selected = True

               _mainMenu.Enabled = True
            Finally
               CType(codecs, IDisposable).Dispose()
            End Try

            Return control3D
         Catch ex As System.Exception
            If Not image Is Nothing Then
               image.Dispose()
            End If
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _mainMenu.Enabled = True
            EndProgress(counterDialog)
            If Not control3D Is Nothing Then
               control3D.Dispose()
            End If
            Return Nothing
         End Try
      End Function


      Private Sub cToolStripMenuItem_Click()
         Dim multiCell As MedicalViewerMultiCell
         Dim annAttributes As MedicalViewerAnnotationAttributes
         Dim AnnotationAction As MedicalViewerBaseAction


         multiCell = CType(IIf(TypeOf _viewer.Cells(0) Is MedicalViewerMultiCell, _viewer.Cells(0), Nothing), MedicalViewerMultiCell)

         annAttributes = multiCell.GetSelectedAnnotationAttributes(multiCell.ActiveSubCell)

         If Not Nothing Is annAttributes Then

            Dim CurrentAction As MedicalViewerAnnotationText


            CurrentAction = CType(multiCell.GetActionProperties(MedicalViewerActionType.AnnotationText, multiCell.ActiveSubCell), MedicalViewerAnnotationText)

            CurrentAction.AnnotationColor = Color.Red

            CurrentAction.Flags = MedicalViewerAnnotationFlags.Selected

            AnnotationAction = CurrentAction

            multiCell.SetActionProperties(annAttributes.Type, AnnotationAction, multiCell.ActiveSubCell)
         End If
      End Sub


      Private Sub LoadImages()
         Dim files As String() = Directory.GetFiles(DemosGlobal.ImagesFolder, "*.dcm")
         Dim codecs As RasterCodecs = New RasterCodecs()
         Try

            Dim i As Integer = 0
            Do While i < _viewer.Cells.Count
               If i >= files.Length Then
                  Exit Do
               End If

               Try
                  CType(_viewer.Cells(i), MedicalViewerCell).Image = codecs.Load(files(i))
               Catch
               End Try
               i += 1
            Loop
         Finally
            CType(codecs, IDisposable).Dispose()
         End Try
      End Sub

      Private Sub _menuAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuAbout.Click
         Using aboutDialog As New AboutDialog("Main 3D", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Function ConvertBackTo2DCell() As MedicalViewerMultiCell
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         Dim data As CellData = CType(control3D.Tag, CellData)
         Dim cell As MedicalViewerMultiCell = data.Cell
         Dim index As Integer

         DeleteAllGeneratorsFromCell(cell)

         index = _viewer.Cells.IndexOf(control3D)
         If index <> -1 Then
            _viewer.Cells.RemoveAt(index)
            _viewer.Cells.Insert(index, cell)
            cell.Selected = True
            cell.Focus()
         End If

         control3D.Dispose()
         Return cell
      End Function

      Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
         _mousePoint.X = e.X
         _mousePoint.Y = e.Y
      End Sub


      Private Sub DeletePolygon(ByVal polygon As MedicalViewerMPRPolygon)
         If Not polygon.PanoramicRepresentation Is Nothing Then
            _viewer.Cells.Remove(polygon.PanoramicRepresentation)
            polygon.PanoramicRepresentation.Dispose()
         End If

         Dim index As Integer = 0
         Dim cell As MedicalViewerParaxialCutCell = Nothing
         Do While index < polygon.ParaxialCuts.Count
            cell = polygon.ParaxialCuts(0)
            polygon.ParaxialCuts.Remove(cell)
            cell.Dispose()
            cell = Nothing
         Loop

         Dim parentCell As MedicalViewerMultiCell = CType(polygon.Parent, MedicalViewerMultiCell)
         parentCell.Polygons.Remove(polygon)
      End Sub

      Private Sub DeleteAllMPRPolygonFromCell(ByVal cell As MedicalViewerMultiCell)
         Dim index As Integer
         index = 0
         Do While index < cell.Polygons.Count
            DeletePolygon(cell.Polygons(index))
         Loop
      End Sub

      Private Sub DeleteAllGeneratorsFromCell(ByVal cell As MedicalViewerMultiCell)
         If cell.ReferenceLine.CutLines.Count <> 0 Then
            Dim derivativeCell As MedicalViewerCell = cell.ReferenceLine.CutLines(0).DerivativeCell
            cell.ReferenceLine.CutLines.RemoveAt(0)
            derivativeCell.Dispose()
         End If

         If cell.ReferenceLine.DoubleCutLines.Count <> 0 Then
            Dim firstDerivativeCell As MedicalViewerCell = cell.ReferenceLine.DoubleCutLines(0).FirstDerivativeCell
            Dim secondDerivativeCell As MedicalViewerCell = cell.ReferenceLine.DoubleCutLines(0).SecondDerivativeCell
            cell.ReferenceLine.DoubleCutLines.RemoveAt(0)
            firstDerivativeCell.Dispose()
            secondDerivativeCell.Dispose()
         End If
      End Sub

      Private Sub SelectCell(ByVal index As Integer)
         If index >= _viewer.Cells.Count Then
            _viewer.Cells(index).Selected = True
         End If
      End Sub

      Private Sub _menuItemShowOptionsDeleteGenerator_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemShowOptionsDeleteGenerator.Click
         If TypeOf _viewer.Cells(_generatorCellIndex) Is MedicalViewerMultiCell Then

            DeleteAllGeneratorsFromCell(CType(_viewer.Cells(_generatorCellIndex), MedicalViewerMultiCell))
         End If
         _currentSelectedMenuItem.Checked = False
         _currentSelectedMenuItem = GetCurrentCheckedCellOption(_generatorCellIndex)
         _currentSelectedMenuItem.Checked = True
         _planeCutLineClicked = False

         SelectCell(_generatorCellIndex)
      End Sub

      Private Sub _menuSSDMeshColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuSSDMeshColor.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         Dim dialog As ColorDialog = New ColorDialog()
         dialog.Color = control3D.ObjectsContainer.Objects(0).SSD.MeshColor

         If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            control3D.ObjectsContainer.Objects(0).SSD.MeshColor = dialog.Color
         End If
      End Sub


      Private Sub ActivateMenu(ByVal currentSelectedMenuItem As ToolStripMenuItem, ByVal sender As Object, ByVal e As EventArgs)
         If currentSelectedMenuItem Is _menuVolumeVRT Then
            _menuVolumeVRT_Click(sender, e)
         ElseIf currentSelectedMenuItem Is _menuVolumeMIP Then
            _menuVolumeMIP_Click(sender, e)
         ElseIf currentSelectedMenuItem Is _menuVolumeMinIP Then
            _menuVolumeMinIP_Click(sender, e)
         ElseIf currentSelectedMenuItem Is _menu2DCell Then
            _menu2DCell_Click(sender, e)
         ElseIf currentSelectedMenuItem Is _menuCutPlane2DCell Then
            _menuCutPlane2DCell_Click(sender, e)
         ElseIf currentSelectedMenuItem Is _menuDoubleCutPlane2DCell Then
            _menuDoubleCutPlane2DCell_Click(sender, e)
         End If
      End Sub

      Private Sub _menuVolumeSSD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuVolumeSSD.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         If (Not Medical3DEngine.CanCreateMesh) Then
            MessageBox.Show("You cannot create any more meshes, only one mesh can be loaded at a time")
            Return
         End If


         Dim oldCursor As Cursor = Cursor
         Cursor = Cursors.WaitCursor

         Try
            If control3D Is Nothing Then
               Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
               If cell Is Nothing Then
                  Return
               End If

               control3D = ConvertTo3D(cell)

               If control3D Is Nothing Then
                  ActivateMenu(_menu2DCell, sender, e)
                  Return
               End If
            End If

            If _MPRMode Then
               _showMPRWindows_Click(sender, e)
            End If


            control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD

            If _menuActionWindowLevel.Checked OrElse _menuActionAlpha.Checked Then
               _menuActionRotate_Click(sender, e)
            End If

            If oldIsoThreshold = 0 Then
               oldIsoThreshold = control3D.ObjectsContainer.Objects(0).SSD.Threshold
            End If

            CheckMenu(_menuVolumeSSD)
         Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' revert back to the old selected menu item
            ActivateMenu(_menu2DCell, sender, e)
         Finally
            Cursor = oldCursor

         End Try
      End Sub

      Private Sub _menuLayoutOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuLayoutOptions.Click
         CType(New LayoutOptions(_viewer, Me), LayoutOptions).ShowDialog(Me)
      End Sub

      Private Function ShowSaveDialog(ByVal filter As String) As String
         Dim saveDialog As SaveFileDialog = New SaveFileDialog()
         saveDialog.AddExtension = True
         saveDialog.Filter = filter
         Dim result As DialogResult = saveDialog.ShowDialog()
         If result = System.Windows.Forms.DialogResult.OK Then
            Return saveDialog.FileName
         Else
            Return Nothing
         End If
      End Function

      Private Function ShowLoadDialog(ByVal filter As String) As String
         Dim openDialog As OpenFileDialog = New OpenFileDialog()
         openDialog.Filter = filter

         Dim result As DialogResult = openDialog.ShowDialog()
         If result = System.Windows.Forms.DialogResult.OK Then
            Return openDialog.FileName
         Else
            Return Nothing
         End If
      End Function

      Private Sub _loadMeshMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _loadMeshMenu.Click
         Dim control3D As Medical3DControl = Nothing

         If (Not Medical3DEngine.CanCreateMesh) Then
            MessageBox.Show("You cannot create any more meshes, only one mesh can be loaded at a time")
            Return
         End If

         Try
            Dim fileName As String = ShowLoadDialog("Mesh Files (*.x)|*.x")
            If Not fileName Is Nothing Then
               control3D = New Medical3DControl()
               If control3D.ObjectsContainer.Objects.Count > 0 Then
                  control3D.ObjectsContainer.Objects.RemoveAt(0)
               End If

               control3D.ObjectsContainer.Objects.Add(New Medical3DObject())
               control3D.Tag = New CellData(ViewerCellType.Mesh3D)
               Initialize3DCell(control3D)
               AddCellToViewer(control3D)
               control3D.ObjectsContainer.Objects(0).SSD.LoadMesh(fileName)
               control3D.Invalidate()
               control3D.Update()
            End If
         Catch exception As Exception
            If Not control3D Is Nothing Then
               If control3D.ObjectsContainer.Objects.Count > 0 Then
                  control3D.ObjectsContainer.Objects.RemoveAt(0)
               End If
            End If
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub _saveMeshMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveMeshMenu.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If
         If control3D.ObjectsContainer.VolumeType <> Medical3DVolumeType.SSD Then
            Return
         End If

         Dim fileName As String = ShowSaveDialog("Mesh Files (*.x)|*.x")

         If Not fileName Is Nothing Then
            control3D.ObjectsContainer.Objects(0).SSD.SaveMesh(fileName)
         End If
      End Sub

      Private Sub _menuSSDIsoThreshold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuSSDIsoThreshold.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         CType(New IsoThresholdDialog(control3D, _viewer, control3D.ObjectsContainer), IsoThresholdDialog).ShowDialog(Me)
      End Sub

      Private Sub _saveObjectStatusMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveObjectStatusMenu.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         Dim fileName As String = ShowSaveDialog("Object Information (*.nfo)|*.nfo")

         If Not fileName Is Nothing Then
            control3D.ObjectsContainer.Objects(0).SaveState(fileName)
         End If
      End Sub

      Private Sub _loadObjectStatusMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _loadObjectStatusMenu.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         Dim fileName As String = ShowLoadDialog("Object Information (*.nfo)|*.nfo")
         If Not fileName Is Nothing Then
            control3D.ObjectsContainer.Objects(0).LoadState(fileName)

            If _MPRMode Then
               _menuShowSlab.Checked = control3D.ObjectsContainer.Objects(0).Slab.Enabled
            End If

            control3D.Invalidate()
         End If
      End Sub

      Private Function CreateInfoFile(ByVal fileName As String) As String
         Dim infoFileName As String = fileName

         Dim index As Integer = infoFileName.LastIndexOf("\"c)
         index += 1

         Dim name As String = infoFileName.Substring(index)

         infoFileName = infoFileName.Remove(index)

         infoFileName = infoFileName & "Information" & name

         Return infoFileName
      End Function

      Private Sub UncheckThePerviousMenuItem(ByVal sender As ToolStripMenuItem)
         If sender Is Nothing Then
            Return
         End If

         For Each item As ToolStripMenuItem In sender.Owner.Items
            If item.Checked Then
               item.Checked = False
            End If
         Next item
      End Sub

      Private Function getApplyingOperation(ByVal actionType As MedicalViewerActionType) As MedicalViewerActionFlags
         If (actionType = MedicalViewerActionType.MagnifyGlass) Then
            Return MedicalViewerActionFlags.Active
         Else
            If False Then
               Return (MedicalViewerActionFlags.AllCells Or MedicalViewerActionFlags.RealTime)
            Else
               Return (MedicalViewerActionFlags.Active)
            End If
         End If
      End Function

      Private Sub SetAction(control As Control, actionType As MedicalViewerActionType, sender As ToolStripMenuItem, rightClickMenuItem As ToolStripMenuItem)
         Dim cell As MedicalViewerBaseCell = CType(control, MedicalViewerBaseCell)
         UncheckThePerviousMenuItem(sender)
         UncheckThePerviousMenuItem(rightClickMenuItem)

         Dim data As CellData = CType(cell.Tag, CellData)

         data.CurrentCheckedItem = sender
         data.CurrentCheckedRightClickItem = rightClickMenuItem
         data.CurrentActionType = actionType

         If actionType = MedicalViewerActionType.Rotate3DObject Then
            actionType = MedicalViewerActionType.WindowLevel
         End If

         Dim applyingOperation As MedicalViewerActionFlags = getApplyingOperation(actionType)

         cell.SetAction(actionType, MedicalViewerMouseButtons.Left, applyingOperation)

         If actionType = MedicalViewerActionType.WindowLevel Then
            cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, getApplyingOperation(MedicalViewerActionType.Offset))
         Else
            cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, getApplyingOperation(MedicalViewerActionType.WindowLevel))
         End If
      End Sub

      Private Sub Set3DAction(ByVal control As Control, ByVal actionType As MedicalViewerActionType, ByVal sender As ToolStripMenuItem, ByVal rightClickMenuItem As ToolStripMenuItem)
         Dim cell As MedicalViewerBaseCell = CType(control, MedicalViewerBaseCell)
         UncheckThePerviousMenuItem(sender)
         UncheckThePerviousMenuItem(rightClickMenuItem)
         'sender.Checked = true;
         'rightClickMenuItem.Checked = true;

         Dim data As CellData = CType(cell.Tag, CellData)

         data.CurrentCheckedItem = sender
         data.CurrentCheckedRightClickItem = rightClickMenuItem
         data.CurrentActionType = actionType


         cell.SetAction(actionType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)

         If actionType = MedicalViewerActionType.WindowLevel Then
            cell.SetAction(MedicalViewerActionType.Rotate3DObject, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
         Else
            cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.AllCells Or MedicalViewerActionFlags.RealTime)
         End If
      End Sub



      Private Sub _menuActionWindowLevel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionWindowLevel.Click, _rightClickWindowLevel.Click
         _actionType = MedicalViewerActionType.WindowLevel
         For Each control As Control In _viewer.Cells
            If Is2DCell(control) Then
               SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel)
            End If

            If TypeOf control Is Medical3DControl Then
               Set3DAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel)
            End If
         Next control
      End Sub

      Private Sub _menuActionAlpha_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionAlpha.Click, _rightClickAlpha.Click
         _actionType = MedicalViewerActionType.Alpha
         For Each control As Control In _viewer.Cells
            If Is2DCell(control) Then
               SetAction(control, MedicalViewerActionType.Alpha, _menuActionAlpha, _rightClickAlpha)
            End If
         Next control
      End Sub

      Private Sub _menuActionScale_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionScale.Click, _rightClickScale.Click
         _actionType = MedicalViewerActionType.Scale
         For Each control As Control In _viewer.Cells

            If (Is2DCell(control)) Then
               SetAction(control, MedicalViewerActionType.Scale, _menuActionScale, _rightClickScale)
            End If

            If TypeOf control Is Medical3DControl Then
               Set3DAction(control, MedicalViewerActionType.Scale, _menuActionScale, _rightClickScale)
            End If

         Next control
      End Sub

      Private Sub _menuActionMagnify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionMagnify.Click, _rightClickMagnify.Click
         _actionType = MedicalViewerActionType.MagnifyGlass
         For Each control As Control In _viewer.Cells
            If Is2DCell(control) Then
               SetAction(control, MedicalViewerActionType.MagnifyGlass, _menuActionMagnify, _rightClickMagnify)
            End If
         Next control
      End Sub

      Private Sub _menuActionPan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionPan.Click, _rightClickPan.Click
         _actionType = MedicalViewerActionType.Offset
         For Each control As Control In _viewer.Cells
            If Is2DCell(control) Then
               SetAction(control, MedicalViewerActionType.Offset, _menuActionPan, _rightClickPan)
            End If
            If TypeOf control Is Medical3DControl Then
               Set3DAction(control, MedicalViewerActionType.Offset, _menuActionPan, _rightClickPan)
            End If
         Next control
      End Sub

      Private Sub _menuActionRotate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionRotate.Click, _rightClickRotate.Click
         _actionType = MedicalViewerActionType.Rotate3DObject
         For Each control As Control In _viewer.Cells
            If TypeOf control Is Medical3DControl Then
               Set3DAction(control, MedicalViewerActionType.Rotate3DObject, _menuActionRotate, _rightClickRotate)
            End If

            If Is2DCell(control) Then
               SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel)
            End If
         Next control
      End Sub

      Private Sub _menuItemAddSingleCutPlane_Click(ByVal sender As Object, ByVal e As EventArgs)
         For Each control As Control In _viewer.Cells
            If (TypeOf control Is MedicalViewerMultiCell) Then
               Dim cell As MedicalViewerMultiCell = CType(control, MedicalViewerMultiCell)

               If cell.Selected AndAlso (Not cell.Derivative) Then
                  DeleteAllGeneratorsFromCell(cell)
                  Dim cutplane As MedicalViewerPlaneCutLine = New MedicalViewerPlaneCutLine()
                  cell.ReferenceLine.CutLines.Add(cutplane)
               End If
            End If
         Next control
      End Sub

      Private Sub _menuItemAddDoubleCutPlane_Click(ByVal sender As Object, ByVal e As EventArgs)
         For Each control As Control In _viewer.Cells
            If (TypeOf control Is MedicalViewerMultiCell) Then
               Dim cell As MedicalViewerMultiCell = CType(control, MedicalViewerMultiCell)
               If cell.Selected AndAlso (Not cell.Derivative) Then
                  DeleteAllGeneratorsFromCell(cell)

                  Dim derivativeCell As MedicalViewerCell = Nothing
                  Dim derivativeCell1 As MedicalViewerCell = Nothing

                  Try
                     derivativeCell = New MedicalViewerCell()
                     _viewer.Cells.Add(derivativeCell)
                     derivativeCell1 = New MedicalViewerCell()
                     _viewer.Cells.Add(derivativeCell1)
                     Dim doubleCutplane As MedicalViewerDoublePlaneCutLine = New MedicalViewerDoublePlaneCutLine(derivativeCell, derivativeCell1)
                     cell.ReferenceLine.DoubleCutLines.Add(doubleCutplane)
                  Catch ex As System.Exception
                     If Not derivativeCell Is Nothing Then
                        derivativeCell.Dispose()
                     End If
                     If Not derivativeCell1 Is Nothing Then
                        derivativeCell1.Dispose()
                     End If
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  End Try

               End If
            End If
         Next control
      End Sub

      Private oldIsoThreshold As Integer
      Private oldMeshColor As Color = Color.White


      Private Sub ResetColorMapData(ByVal control3D As Medical3DControl)
         Dim object3D As Medical3DObject = CType(control3D.ObjectsContainer.Objects(0), Medical3DObject)
         object3D.Palette = Nothing
         object3D.ColorMap = Nothing

         Dim cellData As CellData = CType(control3D.Tag, CellData)
         cellData.ColorMapIndex = -1

         Dim colorMapHistogram As ChannelHistogram()

         Dim Values As Array = System.Enum.GetValues(GetType(MedicalViewerPaletteType))

         If Not cellData.ColorMapList Is Nothing Then
            If cellData.ColorMapList.Count > Values.Length Then
               cellData.ColorMapList.RemoveAt(Values.Length)
            End If


            Dim length As Integer = cellData.ColorMapList.Count
            Dim i As Integer = 0
            Do While i < length
               colorMapHistogram = cellData.ColorMapList(i)

               For index As Integer = 0 To 3
                  If Not colorMapHistogram(index).Points Is Nothing Then
                     colorMapHistogram(index).Points.Clear()
                  End If
                  colorMapHistogram(index).PaletteType = MedicalViewerPaletteType.None
               Next index
               i += 1
            Loop
         End If

         control3D.Invalidate()
      End Sub

      Private Sub _menuItemEditReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditReset.Click
         Dim i As Integer

         Dim offset As MedicalViewerOffset
         Dim control3D As Medical3DControl
         i = 0
         Do While i < _viewer.Cells.Count
            ' check if this is a 3D cell.
            If TypeOf _viewer.Cells(i) Is Medical3DControl Then
               control3D = CType(_viewer.Cells(i), Medical3DControl)
               control3D.ObjectsContainer.ResetRotation()
               control3D.ObjectsContainer.ResetPosition()
               control3D.ObjectsContainer.Camera.Zoom = 27.69F

               If control3D.ObjectsContainer.Objects.Count <> 0 Then
                  control3D.ObjectsContainer.Objects(0).Scale = 100
                  control3D.ObjectsContainer.Objects(0).LowerThreshold = control3D.ObjectsContainer.Objects(0).MinimumValue
                  control3D.ObjectsContainer.Objects(0).UpperThreshold = control3D.ObjectsContainer.Objects(0).MaximumValue
                  control3D.ObjectsContainer.Objects(0).RemoveInterval = Medical3DRemoveIntervalType.OuterRange
                  control3D.ObjectsContainer.Objects(0).EnableThresholding = False
                  control3D.ResetWindowLevelValues()

                  If control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD Then
                     control3D.ObjectsContainer.Objects(0).SSD.MeshColor = oldMeshColor
                     control3D.ObjectsContainer.Objects(0).LowerThreshold = control3D.ObjectsContainer.Objects(0).MinimumValue
                     control3D.ObjectsContainer.Objects(0).UpperThreshold = control3D.ObjectsContainer.Objects(0).MaximumValue
                  End If
               End If
               control3D.ResetOrientationCubePosition()

               ResetColorMapData(control3D)

            ElseIf TypeOf _viewer.Cells(i) Is MedicalViewerCell Then
               Dim cell As MedicalViewerCell = CType(_viewer.Cells(i), MedicalViewerCell)
               offset = CType(cell.GetActionProperties(MedicalViewerActionType.Offset, i), MedicalViewerOffset)
               offset.X = 0
               offset.Y = 0

               Dim alpha As MedicalViewerAlpha = CType(cell.GetActionProperties(MedicalViewerActionType.Alpha, i), MedicalViewerAlpha)
               alpha.Alpha = 0
               cell.SetActionProperties(MedicalViewerActionType.Alpha, alpha)

               cell.SetActionProperties(MedicalViewerActionType.Offset, offset)
               cell.SetScaleMode(MedicalViewerScaleMode.Fit)
               cell.ResetWindowLevelValues()
            End If
            i += 1
         Loop


      End Sub

      Private Sub _rightClickCellReferenceColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rightClickCellReferenceColor.Click
         Dim colorDlg As ColorDialog = New ColorDialog()
         Dim cell As MedicalViewerCell = CType(_viewer.Cells(_generatorCellIndex), MedicalViewerCell)
         colorDlg.Color = cell.ReferenceLine.Color

         If colorDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            cell.ReferenceLine.Color = colorDlg.Color
         End If
         _planeCutLineClicked = False
      End Sub

      Private Sub _menuItemShowOptionsSetGeneratorColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemShowOptionsSetGeneratorColor.Click
         Dim colorDlg As ColorDialog = New ColorDialog()

         If colorDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim cell As MedicalViewerMultiCell = CType(_viewer.Cells(_generatorCellIndex), MedicalViewerMultiCell)

            ' since there will be one generator, either a single or double, then I'll check the type of generator
            ' by checking the count of each collection.
            If cell.ReferenceLine.CutLines.Count <> 0 Then
               cell.ReferenceLine.CutLines(0).Color = colorDlg.Color
            End If

            If cell.ReferenceLine.DoubleCutLines.Count <> 0 Then
               cell.ReferenceLine.DoubleCutLines(0).FirstLineColor = colorDlg.Color
               cell.ReferenceLine.DoubleCutLines(0).SecondLineColor = colorDlg.Color
            End If
         End If
         _planeCutLineClicked = False
      End Sub

      Private Sub _menuRemoveDensity_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuRemoveDensity.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         CType(New ThresholdDialog(control3D, control3D.ObjectsContainer, Medical3DVolumeType.VRT), ThresholdDialog).ShowDialog()
      End Sub

      Private Sub _menuItemEditSSD_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemEditSSD.DropDownOpening
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         Dim enable As Boolean = (control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD)

         Dim cellData As CellData = CType(control3D.Tag, CellData)

         _menuSSDMeshColor.Enabled = enable

         Select Case cellData.CellType
            Case ViewerCellType.Mesh3D
               enable = False
         End Select

         _menuSSDIsoThreshold.Enabled = enable
      End Sub

      Private Sub _menuFile_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _menuFile.DropDownOpening
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         Dim SSDLoaded As Boolean = False
         Dim control3DExist As Boolean = False

         If Not control3D Is Nothing Then
            control3DExist = True
            If control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD Then
               SSDLoaded = True
            End If
         End If

         _saveMeshMenu.Enabled = SSDLoaded
         _saveObjectStatusMenu.Enabled = control3DExist
         _loadObjectStatusMenu.Enabled = control3DExist
         _menuSaveRawData.Enabled = control3DExist

         _loadMeshMenu.Enabled = Not _MPRMode
         _menuLoadObject.Enabled = Not _MPRMode
         _menuItemFileLoadDICOM.Enabled = Not _MPRMode
         _menuItemFileLoadDICOMDIR.Enabled = Not _MPRMode

         If IsLoadedSSDMesh(control3D) OrElse SSDLoaded Then
            _menuSaveRawData.Enabled = False
         End If

         _menuUnload.Enabled = ((Not GetFirstSelectedControl() Is Nothing))

         _saveMPR.Enabled = _MPRMode
         _save3DImage.Enabled = control3DExist AndAlso (control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.VRT)
      End Sub

      Private Sub _menuItemHardwareCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemHardwareCheck.Click
         Dim check As CheckUtilityDialog = New CheckUtilityDialog(Me)
         check.ShowDialog()
      End Sub

      Private Sub _menuCellType_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _menuCellType.DropDownOpening
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()

         Dim control3DExist As Boolean = (control3D Is Nothing)
         Dim Allow3D As Boolean = True
         Dim Allow2D As Boolean = True

         If (cell Is Nothing) AndAlso (control3D Is Nothing) Then
            Allow3D = False
            Allow2D = False
         ElseIf cell Is Nothing Then
            Dim cellData As CellData = CType(control3D.Tag, CellData)

            Select Case cellData.CellType
               Case ViewerCellType.Mesh3D
                  Allow2D = False
                  Allow3D = False
               Case ViewerCellType.LoadedObject
                  Allow3D = True
                  Allow2D = False
            End Select
         ElseIf control3D Is Nothing Then
            Dim cellData As CellData = CType(cell.Tag, CellData)
            Select Case cellData.CellType
               Case ViewerCellType.Other, ViewerCellType.Derivate
                  Allow2D = False
                  Allow3D = False

               Case ViewerCellType.SingleFileSeries, ViewerCellType.Cell2D
                  If cell.VirtualImage.Count < 3 Then
                     Allow3D = False
                     Allow2D = False
                  End If
            End Select
         End If

         _menu2DCell.Enabled = _menuCutPlane2DCell.Enabled = _menuDoubleCutPlane2DCell.Enabled = Allow2D


         _menuVolumeMinIP.Enabled = _menuVolumeMIP.Enabled = _menuVolumeVRT.Enabled = _menuVolumeMPR.Enabled = _menuVolumeSSD.Enabled = Allow3D
      End Sub

      Private _mprControlWindow As Medical3DControl
      Private _mprControlIndex As Integer
      Private _oldViewer As MedicalViewer
      Private Sub ConverttoMPRWindow(ByVal mprMode As Boolean)
         If mprMode Then
            _mprControlWindow = GetFirstSelected3DControl()

            _mprControlIndex = _viewer.Cells.IndexOf(_mprControlWindow)

            _viewer.Cells.Remove(_mprControlWindow)

            _displayPanel.Controls.Remove(_viewer)

            _oldViewer = _viewer
            _viewer = New MedicalViewer(2, 2)

            _viewer.UseExtraSplitters = False
            AddHandler _viewer.DeleteCell, AddressOf MedicalViewer_DeleteCell
            _viewer.Cells.Add(_mprControlWindow)

            _showMPRCrossHair = True
            _coloredMPRCrossHair = True

            _menuShowSlab.Checked = False
            _menuShowCrossHair.Checked = True
            _menuColoredCrossHair.Checked = True

            Dim mprAxial As MedicalViewerMPRCell = New MedicalViewerMPRCell()
            Dim mprSagittal As MedicalViewerMPRCell = New MedicalViewerMPRCell()
            Dim mprCoronal As MedicalViewerMPRCell = New MedicalViewerMPRCell()

            InitializeMPRCell(mprAxial, MPRType.Axial)
            InitializeMPRCell(mprSagittal, MPRType.Sagittal)
            InitializeMPRCell(mprCoronal, MPRType.Coronal)

            mprAxial.ShowMPRCrossHair = True
            mprSagittal.ShowMPRCrossHair = True
            mprCoronal.ShowMPRCrossHair = True

            mprAxial.DistinguishMPRByColor = True
            mprSagittal.DistinguishMPRByColor = True
            mprCoronal.DistinguishMPRByColor = True

            _mprControlWindow.AxialFrame = mprAxial
            _mprControlWindow.SagittalFrame = mprSagittal
            _mprControlWindow.CoronalFrame = mprCoronal

            CopyTags(mprAxial, _mprControlWindow, True)
            CopyTags(mprSagittal, _mprControlWindow, True)
            CopyTags(mprCoronal, _mprControlWindow, True)

            _viewer.Cells.AddRange(New MedicalViewerBaseCell() {mprAxial, mprSagittal, mprCoronal})

            mprAxial.SetScaleMode(MedicalViewerScaleMode.Fit)
            mprSagittal.SetScaleMode(MedicalViewerScaleMode.Fit)
            mprCoronal.SetScaleMode(MedicalViewerScaleMode.Fit)

            _mprControlWindow.ApplyWindowLevelOnMPRSlices = True

            mprAxial.ShowCellScroll = _showScrollBar
            mprSagittal.ShowCellScroll = _showScrollBar
            mprCoronal.ShowCellScroll = _showScrollBar


            _displayPanel.Controls.Add(_viewer)
         Else
            Dim control3D As Medical3DControl = CType(_viewer.Cells(0), Medical3DControl)

            If control3D.ObjectsContainer.Objects(0).Slab.Enabled Then
               control3D.ObjectsContainer.Objects(0).Slab.Enabled = False
            End If

            _viewer.Cells.RemoveAt(0)
            _displayPanel.Controls.Remove(_viewer)
            Dim cell1 As MedicalViewerBaseCell = _viewer.Cells(0)
            Dim cell2 As MedicalViewerBaseCell = _viewer.Cells(1)
            Dim cell3 As MedicalViewerBaseCell = _viewer.Cells(2)
            _viewer.Cells.RemoveAt(0)
            _viewer.Cells.RemoveAt(0)
            _viewer.Cells.RemoveAt(0)

            _viewer.Dispose()

            _viewer = _oldViewer
            _mprControlWindow.AxialFrame = Nothing
            _mprControlWindow.SagittalFrame = Nothing
            _mprControlWindow.CoronalFrame = Nothing

            _displayPanel.Controls.Add(_viewer)
            _viewer.Cells.Insert(_mprControlIndex, _mprControlWindow)

            cell1.Dispose()
            cell2.Dispose()
            cell3.Dispose()
            _mprControlWindow.Selected = True

         End If
         _viewer.SetBounds(_displayPanel.Left, _displayPanel.Top, _displayPanel.Width, _displayPanel.Height)
         _viewer.Focus()
      End Sub

      Private Sub _showMPRWindows_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _showMPRWindows.Click
         Dim cell As MedicalViewerBaseCell = GetFirstSelectedControl()

         If cell Is Nothing Then
            Return
         End If

         If (Not (TypeOf cell Is Medical3DControl)) AndAlso (Not _MPRMode) Then
            Dim control3D As Medical3DControl = ConvertTo3D(CType(cell, MedicalViewerMultiCell))
            If control3D Is Nothing Then
               Return
            End If
            control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MPR
            CheckMenu(_menuVolumeMPR)
         End If

         _MPRMode = Not _MPRMode
         _showMPRWindows.Checked = _MPRMode
         _menuReferenceLine.Enabled = Not _MPRMode
         _menuMPRLayout.Enabled = _MPRMode

         ConverttoMPRWindow(_MPRMode)

         If _menuActionPanoramicPolygon.Checked Then
            _menuActionWindowLevel_Click(sender, e)
         End If

         _viewer.Update()
         Update()
      End Sub

      Private Sub _menu2DCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menu2DCell.Click
         If _MPRMode Then
            _showMPRWindows_Click(sender, e)
         End If

         CheckMenu(_menu2DCell)
         GetClean2DCell()
      End Sub

      Private Function GetClean2DCell() As MedicalViewerMultiCell
         Dim control3D As Medical3DControl
         Dim cell As MedicalViewerMultiCell

         control3D = GetFirstSelected3DControl()
         cell = GetFirstSelectedMultiCell()

         If control3D Is Nothing AndAlso cell Is Nothing Then
            Return Nothing
         End If

         If Not control3D Is Nothing Then
            cell = ConvertBackTo2DCell()
         Else
            DeleteAllGeneratorsFromCell(cell)
            DeleteAllMPRPolygonFromCell(cell)
         End If

         Return cell
      End Function

      Private Sub _menuCutPlane2DCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuCutPlane2DCell.Click
         Dim derivativeCell As MedicalViewerCell = New MedicalViewerCell()

         Try
            If _MPRMode Then
               _showMPRWindows_Click(sender, e)
            End If

            If _menuActionPanoramicPolygon.Checked Then
               _menuActionWindowLevel_Click(sender, e)
            End If

            If _menuCutPlane2DCell.Checked Then
               Return
            End If

            Dim cell As MedicalViewerMultiCell = GetClean2DCell()

            If Not cell Is Nothing Then
               _viewer.Cells.Add(derivativeCell)
               cell.ReferenceLine.CutLines.Add(New MedicalViewerPlaneCutLine(derivativeCell))
               CheckMenu(_menuCutPlane2DCell)

            End If
         Catch exception As Exception
            derivativeCell.Dispose()
            ActivateMenu(_menu2DCell, sender, e)
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Private Sub _menuDoubleCutPlane2DCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuDoubleCutPlane2DCell.Click
         Dim derivativeCell As MedicalViewerCell = New MedicalViewerCell()
         Dim derivativeCell1 As MedicalViewerCell = New MedicalViewerCell()

         Try
            If _MPRMode Then
               _showMPRWindows_Click(sender, e)
            End If

            If _menuActionPanoramicPolygon.Checked Then
               _menuActionWindowLevel_Click(sender, e)
            End If

            If _menuDoubleCutPlane2DCell.Checked Then
               Return
            End If

            Dim cell As MedicalViewerMultiCell = GetClean2DCell()

            If Not cell Is Nothing Then
               _viewer.Cells.Add(derivativeCell)
               _viewer.Cells.Add(derivativeCell1)
               cell.ReferenceLine.DoubleCutLines.Add(New MedicalViewerDoublePlaneCutLine(derivativeCell, derivativeCell1))
               CheckMenu(_menuDoubleCutPlane2DCell)
            End If
         Catch exception As Exception
            derivativeCell.Dispose()
            derivativeCell1.Dispose()
            ActivateMenu(_menu2DCell, sender, e)
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Private Sub _menuShowReferenceLine_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuShowReferenceLine.Click
         Dim cell As MedicalViewerCell
         _showReferenceLine = Not _showReferenceLine
         _menuShowReferenceLine.Checked = _showReferenceLine

         For Each control As Control In _viewer.Cells
            If (TypeOf control Is MedicalViewerCell) OrElse (TypeOf control Is MedicalViewerMultiCell) Then
               cell = CType(control, MedicalViewerCell)
               cell.ReferenceLine.Enabled = _showReferenceLine
            End If
         Next control
      End Sub

      Private Sub _menuShowReferenceBoundaries_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuShowReferenceBoundaries.Click
         Dim cell As MedicalViewerCell
         _showReferenceBoundaries = Not _showReferenceBoundaries
         _menuShowReferenceBoundaries.Checked = _showReferenceBoundaries

         For Each control As Control In _viewer.Cells
            If (TypeOf control Is MedicalViewerMultiCell) OrElse (TypeOf control Is MedicalViewerCell) Then
               cell = CType(control, MedicalViewerCell)
               cell.ShowCellBoundaries = _showReferenceBoundaries
            End If
         Next control
      End Sub

      Private Sub _menuShowCrossHair_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuShowCrossHair.Click
         _showMPRCrossHair = Not _showMPRCrossHair
         _menuShowCrossHair.Checked = _showMPRCrossHair
         Dim mprCell As MedicalViewerMPRCell
         For Each cell As Control In _viewer.Cells
            If TypeOf cell Is MedicalViewerMPRCell Then
               mprCell = CType(cell, MedicalViewerMPRCell)
               mprCell.ShowMPRCrossHair = _showMPRCrossHair
            End If
         Next cell
      End Sub

      Private Sub _menuColoredCrossHair_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuColoredCrossHair.Click
         _coloredMPRCrossHair = Not _coloredMPRCrossHair
         _menuColoredCrossHair.Checked = _coloredMPRCrossHair
         Dim mprCell As MedicalViewerMPRCell
         For Each cell As Control In _viewer.Cells
            If TypeOf cell Is MedicalViewerMPRCell Then
               mprCell = CType(cell, MedicalViewerMPRCell)
               mprCell.DistinguishMPRByColor = _coloredMPRCrossHair
            End If
         Next cell
      End Sub

      Private Sub _menuShowSlab_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuShowSlab.Click
         Dim control3D As Medical3DControl

         If TypeOf _viewer.Cells(0) Is Medical3DControl Then
            control3D = CType(_viewer.Cells(0), Medical3DControl)
         Else
            Return
         End If

         _menuShowSlab.Checked = Not _menuShowSlab.Checked
         control3D.ObjectsContainer.Objects(0).Slab.Enabled = _menuShowSlab.Checked
         Dim mprCell As MedicalViewerMPRCell
         For Each cell As Control In _viewer.Cells
            If TypeOf cell Is MedicalViewerMPRCell Then
               mprCell = CType(cell, MedicalViewerMPRCell)
               mprCell.ShowSlabBoundaries = _menuShowSlab.Checked
            End If
         Next cell
      End Sub

      Private Sub AddCellToViewer(ByVal control As MedicalViewerBaseCell)
         If _MPRMode Then
            ' if the MPR is active the program will delete the first 3D cell and replace it with a new one.
            If _viewer.Cells.Count = 4 Then
               _viewer.Cells(0).Dispose()
            End If

            If Not _viewer Is Nothing Then
               _viewer.Cells.Insert(0, control)
            End If
         Else
            If Not _viewer Is Nothing Then
               _viewer.Cells.Add(control)
            End If
         End If
      End Sub


      Private Sub _menuLoadObject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuLoadObject.Click
         Dim control3D As Medical3DControl = Nothing

         Try
            Dim fileName As String = ShowLoadDialog("RAW data (*.raw)|*.raw")

            If Not fileName Is Nothing Then
               control3D = New Medical3DControl()

               If control3D.ObjectsContainer.Objects.Count = 0 Then
                  control3D.ObjectsContainer.Objects.Add(New Medical3DObject())
               End If

               Initialize3DCell(control3D)
               AddCellToViewer(control3D)
               control3D.ObjectsContainer.Objects(0).LoadObjectFromFile(fileName)
               control3D.Tag = New CellData(ViewerCellType.LoadedObject)
            End If
         Catch ex As System.Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Not control3D Is Nothing Then
               control3D.Dispose()
            End If
            Return
         End Try
      End Sub

      Private Sub _menuSaveRawData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuSaveRawData.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            Return
         End If

         Dim fileName As String = ShowSaveDialog("RAW data (*.raw)|*.raw")

         If Not fileName Is Nothing Then
            control3D.ObjectsContainer.Objects(0).SaveObjectToFile(fileName)
            control3D.Invalidate()
            control3D.Update()
         End If
      End Sub

      Private Function IsLoadedSSDMesh(ByVal control3D As Control) As Boolean
         If control3D Is Nothing Then
            Return False
         End If

         Dim cellData As CellData = CType(control3D.Tag, CellData)
         If cellData.CellType = ViewerCellType.Mesh3D Then
            Return True
         End If
         Return False
      End Function

      Private Sub _menuView_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _menuView.DropDownOpening
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         Dim cell As MedicalViewerBaseCell = CType(GetFirstSelectedControl(), MedicalViewerBaseCell)

         Dim control3DExist As Boolean = False

         If Not control3D Is Nothing Then
            control3DExist = True
         End If

         _menuProperties.Enabled = _menuInvert.Enabled = control3DExist

         Dim enableMPR As Boolean = True
         If control3D Is Nothing Then

            If Not cell Is Nothing Then
               Dim cellData As CellData = CType(cell.Tag, CellData)
               Select Case cellData.CellType
                  Case ViewerCellType.MPRCell

                  Case ViewerCellType.Other, ViewerCellType.Derivate
                     enableMPR = False
                  Case ViewerCellType.SingleFileSeries, ViewerCellType.Cell2D
                     If (CType(cell, MedicalViewerMultiCell)).VirtualImage.Count < 3 Then
                        enableMPR = False
                     End If
               End Select
            Else
               enableMPR = False
            End If
         End If
         _showMPRWindows.Enabled = enableMPR OrElse _MPRMode

         If IsLoadedSSDMesh(control3D) OrElse IsSSDMode(control3D) Then
            _showMPRWindows.Enabled = False
         End If
      End Sub

      Private Sub _menuReferenceLine_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _menuReferenceLine.DropDownOpening
         _menuShowReferenceLine.Enabled = _menuShowReferenceBoundaries.Enabled = Not _MPRMode

         _menuShowAllReferenceLines.Enabled = _menuShowFirstAndLastReferenceLines.Enabled = _menuShowReferenceLine.Checked
      End Sub

      Private Function GetFirstSelectedControl() As MedicalViewerBaseCell
         For Each control As Control In _viewer.Cells
            Dim cell As MedicalViewerBaseCell = CType(control, MedicalViewerBaseCell)

            If cell.Selected Then
               Return CType(control, MedicalViewerBaseCell)
            End If
         Next control
         Return Nothing
      End Function

      Private Function GetFirstDerivativeCell() As MedicalViewerCell
         For Each control As Control In _viewer.Cells
            If (TypeOf control Is MedicalViewerCell) AndAlso (Not (TypeOf control Is MedicalViewerMultiCell)) Then
               Dim cell As MedicalViewerCell = CType(control, MedicalViewerCell)

               If cell.Selected Then
                  Return CType(control, MedicalViewerCell)
               End If
            End If
         Next control
         Return Nothing
      End Function

      Private Function IsSSDMode(ByVal control3D As Medical3DControl) As Boolean
         If control3D Is Nothing Then
            Return False
         End If

         If control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.SSD Then
            Return True
         End If
         Return False
      End Function

      Private Sub _actionsMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _actionsMenuItem.DropDownOpening
         Dim allow2D As Boolean = False
         Dim allow3D As Boolean = False
         Dim allowmulti2D As Boolean = False
         Dim allowPanoramic As Boolean = True
         Dim multicell As MedicalViewerMultiCell = Nothing

         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         Dim cellData As CellData = Nothing

         If Not control3D Is Nothing Then
            allow3D = True
            cellData = CType(control3D.Tag, CellData)
         Else
            Dim cell As MedicalViewerCell = GetFirstDerivativeCell()
            multicell = GetFirstSelectedMultiCell()

            If Not multicell Is Nothing Then
               allowmulti2D = True

               cellData = CType(multicell.Tag, CellData)
               Select Case cellData.CellType
                  Case ViewerCellType.SingleFileSeries, ViewerCellType.Cell2D
                     If multicell.VirtualImage.Count < 3 Then
                        allowPanoramic = False
                     End If
               End Select


            End If

            If Not cell Is Nothing Then
               cellData = CType(cell.Tag, CellData)
               allow2D = True
            End If
         End If

         _menuActionMagnify.Enabled = allowmulti2D OrElse allow2D
         _menuActionAlpha.Enabled = allowmulti2D
         _menuActionPanoramicPolygon.Enabled = allowmulti2D AndAlso Not (TypeOf multicell Is MedicalViewerParaxialCutCell) AndAlso allowPanoramic
         _menuActionProbeTool.Enabled = allowmulti2D OrElse allow2D
         _menuActionWindowLevel.Enabled = (allowmulti2D OrElse allow3D OrElse allow2D)
         _menuActionPan.Enabled = allowmulti2D OrElse allow3D OrElse allow2D
         _menuActionScale.Enabled = allowmulti2D OrElse allow3D OrElse allow2D
         _menuActionRotate.Enabled = allow3D

         If IsLoadedSSDMesh(control3D) OrElse IsSSDMode(control3D) Then
            _menuActionWindowLevel.Enabled = False
            _menuActionAlpha.Enabled = False
         End If

         UncheckAllActionMenu()

         If Not cellData Is Nothing Then
            If Not cellData.CurrentCheckedItem Is Nothing Then
               cellData.CurrentCheckedItem.Checked = True
            End If

            If Not cellData.CurrentCheckedRightClickItem Is Nothing Then
               cellData.CurrentCheckedRightClickItem.Checked = True
            End If
         End If

      End Sub

      Private Sub _menuShowScrollBar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuShowScrollBar.Click
         _showScrollBar = Not _showScrollBar

         For Each control As Control In _viewer.Cells
            If TypeOf control Is MedicalViewerCell Then
               Dim cell As MedicalViewerCell = CType(control, MedicalViewerCell)
               cell.ShowCellScroll = Not cell.ShowCellScroll
            End If
         Next control

         _menuShowScrollBar.Checked = _showScrollBar
      End Sub

      Private Sub _menuUnload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuUnload.Click
         Dim cell As MedicalViewerBaseCell = CType(GetFirstSelectedControl(), MedicalViewerBaseCell)

         ' if you unload the MPR, then go back to the normal view before delete the set.
         If _MPRMode Then
            cell = _viewer.Cells(0)
            _showMPRWindows_Click(sender, e)
         End If
         DeleteCell(cell)
      End Sub

      Private Sub DeleteCell(ByVal cell As MedicalViewerBaseCell)
         If Not cell Is Nothing Then
            _viewer.Cells.Remove(cell)

            If TypeOf cell Is Medical3DControl Then
               Dim control3D As Medical3DControl = CType(cell, Medical3DControl)

               If Not (CType(control3D.Tag, CellData)).Cell Is Nothing Then
                  Dim baseCell As MedicalViewerBaseCell = CType((CType(control3D.Tag, CellData)).Cell, MedicalViewerBaseCell)
                  baseCell.Dispose()
               End If
            ElseIf TypeOf cell Is MedicalViewerMultiCell Then
               Dim multiCell As MedicalViewerMultiCell = CType(cell, MedicalViewerMultiCell)
               DeleteAllGeneratorsFromCell(multiCell)
            ElseIf TypeOf cell Is MedicalViewerCell Then
               Dim theOtherCell As MedicalViewerCell = SearchForTheGeneratorCellAndReturnTheOtherCell(CType(cell, MedicalViewerCell))

               If Not theOtherCell Is Nothing Then
                  theOtherCell.Dispose()
               End If
            End If
            cell.Dispose()
         End If
      End Sub

      Private Sub _menuDeleteAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuDeleteAll.Click
         Dim cell As MedicalViewerBaseCell = Nothing
         If _MPRMode Then
            _menuUnload_Click(sender, e)
         End If

         Do While _viewer.Cells.Count <> 0
            cell = _viewer.Cells(0)
            DeleteCell(cell)
         Loop
      End Sub

      Private Sub EnableRightClickMenuItems(ByVal sender As Object)
         Dim allow2D As Boolean = False
         Dim allow3D As Boolean = False
         Dim allowmulti2D As Boolean = False

         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         If Not control3D Is Nothing Then
            allow3D = True
         Else
            Dim cell As MedicalViewerCell = GetFirstDerivativeCell()
            Dim multicell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
            If Not multicell Is Nothing Then
               allowmulti2D = True
            End If

            If Not cell Is Nothing Then
               allow2D = True
            End If
         End If

         _rightClickMagnify.Enabled = Not allow3D
         _rightClickAlpha.Enabled = allowmulti2D
         _rightClickWindowLevel.Enabled = (allowmulti2D OrElse allow3D OrElse allow2D)
         _rightClickPan.Enabled = allowmulti2D OrElse allow3D OrElse allow2D
         _rightClickScale.Enabled = allowmulti2D OrElse allow3D OrElse allow2D
         _rightClickRotate.Enabled = allow3D

         If IsLoadedSSDMesh(control3D) OrElse IsSSDMode(control3D) Then
            _rightClickWindowLevel.Enabled = False
         End If

         _rightClickCellReferenceColor.Enabled = (Not (TypeOf sender Is Medical3DControl))

      End Sub

      Private Sub _menuVolumeMinIP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuVolumeMinIP.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()

         If control3D Is Nothing Then
            Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
            If cell Is Nothing Then
               Return
            End If

            control3D = ConvertTo3D(cell)

            If control3D Is Nothing Then
               Return
            End If
         End If

         control3D.ObjectsContainer.VolumeType = Medical3DVolumeType.MINIP

         CheckMenu(_menuVolumeMinIP)
      End Sub



      Private Sub _menuActionPanoramicPolygon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionPanoramicPolygon.Click
         UncheckAllActionMenu()

         _menuActionPanoramicPolygon.Checked = True

         ' make sure to convert to 2D cell
         _menu2DCell_Click(sender, e)
         Dim allowed As Boolean = True
         If _menuActionPanoramicPolygon.Checked Then
            For Each baseCell As MedicalViewerBaseCell In _viewer.Cells
               allowed = Not (TypeOf baseCell Is Medical3DControl)
               If allowed Then
                  If TypeOf baseCell Is MedicalViewerPanoramicCell Then
                     allowed = False
                  End If
                  If TypeOf baseCell Is MedicalViewerCell Then
                     If (CType(baseCell, MedicalViewerCell)).Derivative Then
                        allowed = False
                     End If
                  End If
               End If

               If (Not allowed) Then
                  If Is2DCell(baseCell) Then
                     SetAction(baseCell, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel)
                  End If

                  If TypeOf baseCell Is Medical3DControl Then
                     Set3DAction(baseCell, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel)
                  End If
               Else
                  SetAction(baseCell, MedicalViewerActionType.PanoramicPolygon, _menuActionPanoramicPolygon, Nothing)
               End If
            Next baseCell
         Else
            For Each baseCell As MedicalViewerBaseCell In _viewer.Cells
               baseCell.AddAction(MedicalViewerActionType.WindowLevel)
               baseCell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.AllCells Or MedicalViewerActionFlags.RealTime)
            Next baseCell
         End If
      End Sub

      Private Sub _panoramicRightClickCreateParaxialCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickCreateParaxialCell.Click
         Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
         If cell Is Nothing Then
            Return
         End If

         AddParaxialCell(cell, _polygon, _polygonIndex)
      End Sub

      Private Sub _panoramicRightClickInsertPoint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickInsertPoint.Click
         Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
         If cell Is Nothing Then
            Return
         End If

         _mousePoint.Offset(-cell.Location.X, -cell.Location.Y)

         Dim pt As Point = cell.PointToImage(_mousePoint)

         _polygon.Points.Insert(_polygonIndex + 1, pt)
         _polygon.Recalculate()
         _polygon.Parent.Invalidate()
         _polygonHandleClicked = False
      End Sub

      Private Sub DeleteParaxialCell(ByVal polygonLineIndex As Integer)
         If polygonLineIndex = _polygon.Points.Count - 1 Then
            polygonLineIndex -= 1
         End If

         Dim counter As Integer = 0
         counter = 0
         Do While counter < _polygon.ParaxialCuts.Count
            If _polygon.ParaxialCuts(counter).PolygonLineIndex = polygonLineIndex Then
               DeleteCell(_polygon.ParaxialCuts(counter))
               Return
            End If

            counter += 1
         Loop
      End Sub

      Private Sub _panoramicRightClickDeletePoint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickDeletePoint.Click
         DeleteParaxialCell(_polygonIndex)
         _polygon.Points.RemoveAt(_polygonIndex)
         _polygon.Recalculate()
         _polygon.Parent.Invalidate()
         _polygonHandleClicked = False
      End Sub

      Private Sub _panoramicRightClickParaxialLineColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickParaxialLineColor.Click
         Dim dialog As ColorDialog = New ColorDialog()

         Dim cell As MedicalViewerParaxialCutCell = GetParaxialCell()
         dialog.Color = cell.LinesColor
         If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            cell.LinesColor = dialog.Color
         End If
      End Sub

      Private Sub _panoramicRightClickActiveParaxialColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickActiveParaxialColor.Click
         Dim dialog As ColorDialog = New ColorDialog()

         Dim cell As MedicalViewerParaxialCutCell = GetParaxialCell()

         dialog.Color = cell.ActiveLineColor
         If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            cell.ActiveLineColor = dialog.Color
         End If
      End Sub

      Private Sub _panoramicRightClickPolygonColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickPolygonColor.Click
         Dim dialog As ColorDialog = New ColorDialog()
         dialog.Color = _polygon.Color
         If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _polygon.Color = dialog.Color
         End If
      End Sub

      Private Function GetParaxialCell() As MedicalViewerParaxialCutCell
         Dim polygonLineIndex As Integer
         If (_polygonIndex = _polygon.Points.Count - 1) Then
            polygonLineIndex = _polygonIndex - 1
         Else
            polygonLineIndex = _polygonIndex
         End If

         Dim index As Integer
         index = 0
         Do While index < _polygon.ParaxialCuts.Count
            If _polygon.ParaxialCuts(index).PolygonLineIndex = polygonLineIndex Then
               Return _polygon.ParaxialCuts(index)
            End If

            index += 1
         Loop

         Return Nothing
      End Function


      Private Sub _panoramicRightClickParaxialProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickParaxialProperties.Click
         Dim cell As MedicalViewerParaxialCutCell = GetParaxialCell()
         If cell Is Nothing Then
            Return
         End If

         Dim dialog As ParaxialDialog = New ParaxialDialog(cell)
         dialog.ShowDialog()
      End Sub

      Private Sub _panoramicRightClickDeletePolygon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickDeletePolygon.Click
         Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()
         If cell Is Nothing Then
            Return
         End If

         DeleteAllMPRPolygonFromCell(cell)
      End Sub

      Private Sub _panoramicRightClickDeleteParaxialCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panoramicRightClickDeleteParaxialCell.Click
         Dim cell As MedicalViewerParaxialCutCell = GetParaxialCell()
         If cell Is Nothing Then
            Return
         End If

         cell.Dispose()
      End Sub

      Private Sub _menuShowAllReferenceLines_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuShowAllReferenceLines.Click
         _viewer.ShowSelectedReferenceLine = Not _viewer.ShowSelectedReferenceLine
         _menuShowAllReferenceLines.Checked = Not _viewer.ShowSelectedReferenceLine
      End Sub

      Private Sub _menuShowFirstAndLastReferenceLines_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuShowFirstAndLastReferenceLines.Click
         Dim cell As MedicalViewerCell
         _showFirstAndLastReferenceLines = Not _showFirstAndLastReferenceLines
         _menuShowFirstAndLastReferenceLines.Checked = _showFirstAndLastReferenceLines

         For Each control As Control In _viewer.Cells
            If (TypeOf control Is MedicalViewerMultiCell) OrElse (TypeOf control Is MedicalViewerCell) Then
               cell = CType(control, MedicalViewerCell)
               cell.ReferenceLine.ShowFirstAndLast = _showFirstAndLastReferenceLines
            End If
         Next control
      End Sub

      Private Sub _menuActionProbeTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuActionProbeTool.Click, _rightClickProbeTool.Click

         _actionType = MedicalViewerActionType.ProbeTool
         For Each control As Control In _viewer.Cells
            If Is2DCell(control) Then
               SetAction(control, MedicalViewerActionType.ProbeTool, _menuActionProbeTool, _rightClickProbeTool)
            End If

            If TypeOf control Is Medical3DControl Then
               Set3DAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel, _rightClickWindowLevel)
            End If
         Next control
      End Sub

      Private Sub _menuEditFusion_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim cell As MedicalViewerMultiCell = GetFirstSelectedMultiCell()

            Dim imagePath As String = Nothing
            GetFileName(imagePath)

            ' Insert new cell if the user has selected an image.
            If imagePath <> "" Then
               Dim dicomDataSet As DicomDataSet = New DicomDataSet()
               dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None)

               Dim imageInformation As SeriesInformation = LoadDICOM(dicomDataSet, imagePath)

               dicomDataSet.Dispose()

               If imageInformation.Image Is Nothing Then
                  Throw New Exception("Error Loading File")
               End If

               Dim fusion As MedicalViewerFusion = New MedicalViewerFusion()

               Dim _codecs As RasterCodecs = New RasterCodecs()

               fusion.FusedImage = imageInformation.Image
               fusion.FusionScale = 0.5F
               fusion.ColorPalette = MedicalViewerPaletteType.Fire

               cell.SubCells(cell.ActiveSubCell).Fusion.Add(fusion)
            End If
         Catch ex As Exception
            Messager.Show(Me, ex, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Private Sub dHistogramToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _editColorMap.Click
         Dim control3D As Medical3DControl = GetFirstSelected3DControl()
         If control3D Is Nothing Then
            MessageBox.Show("There is no 3D object selected")
            Return

         End If


         Dim myObject As Medical3DObject = control3D.ObjectsContainer.Objects(0)

         Dim dialog As Histogram3DDialog = New Histogram3DDialog(control3D, myObject, Me)
         dialog.ShowDialog()

         Dim data As CellData = CType(control3D.Tag, CellData)

      End Sub

      Private Class MPRCell
         Public Sub New(ByVal cell_Renamed As MedicalViewerMPRCell, ByVal name_Renamed As String, ByVal mPRInfo_Renamed As Medical3DMPRInfo)
            Cell = cell_Renamed
            Name = name_Renamed
            MPRInfo = mPRInfo_Renamed
         End Sub
         Public Cell As MedicalViewerMPRCell
         Public Name As String
         Public MPRInfo As Medical3DMPRInfo
      End Class



      Private Sub UpdateDicomDataSetInformation(ByVal dicomDataSet As DicomDataSet, ByVal mprCell As MedicalViewerMPRCell, ByVal info As Medical3DMPRInfo)
         Dim dicomElement As DicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.ImageOrientationPatient, True)

         If Not dicomElement Is Nothing Then
            Dim myString As String = ""
            For index As Integer = 0 To 5
               myString &= info.Orientation(index).ToString() & "\"
            Next index
            myString.Remove(myString.Length - 1)

            dicomDataSet.SetConvertValue(dicomElement, myString, 6)
         End If


         dicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.ImagePositionPatient, True)

         If Not dicomElement Is Nothing Then
            Dim myString As String = ""
            For index As Integer = 0 To 2
               myString &= info.Orientation(index).ToString() & "\"
            Next index
            myString.Remove(myString.Length - 1)

            dicomDataSet.SetConvertValue(dicomElement, myString, 3)
         End If


         dicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.WindowWidth, True)

         If Not dicomElement Is Nothing Then
            dicomDataSet.SetConvertValue(dicomElement, info.Width.ToString(), 1)
         End If


         dicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.WindowCenter, True)

         If Not dicomElement Is Nothing Then
            dicomDataSet.SetConvertValue(dicomElement, info.Center.ToString(), 1)
         End If


         dicomElement = dicomDataSet.FindFirstElement(Nothing, DicomTag.PixelSpacing, True)

         If Not dicomElement Is Nothing Then
            dicomDataSet.SetConvertValue(dicomElement, String.Format("{0}\{1}", info.CentiPerPixelX, info.CentiPerPixelY), 2)
         End If
      End Sub

      Private Sub _saveMPR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveMPR.Click

         Dim fileName As String = ShowSaveDialog("DICOM Files (*.dcm)|*.dcm")

         If Not fileName Is Nothing Then
            Dim fileNameWithNoExtenstion As String = fileName
            Dim dotIndex As Integer = fileNameWithNoExtenstion.LastIndexOf(".")
            fileNameWithNoExtenstion = fileNameWithNoExtenstion.Remove(dotIndex)


            Dim control3D As Medical3DControl = CType(_viewer.Cells(0), Medical3DControl)
            If control3D Is Nothing Then
               Throw New Exception("No 3d control is found")
            End If

            Dim data As CellData = CType(control3D.Tag, CellData)
            Dim cell As MedicalViewerMultiCell = data.Cell


            Dim cellData As CellData = CType(cell.Tag, CellData)


            Dim dicomDataSet As DicomDataSet = New DicomDataSet()
            dicomDataSet.Load(cellData.FileNames(0), DicomDataSetLoadFlags.None)

            Dim imageCount As Integer = dicomDataSet.GetImageCount(Nothing)

            Dim mprCells As MPRCell() = New MPRCell(2) {}
            mprCells(0) = New MPRCell(control3D.AxialFrame, "Axial", control3D.ObjectsContainer.Objects(0).GetMPRInformation(Medical3DMPRPlaneType.Axial, control3D.AxialFrame.ActiveSubCell))
            mprCells(1) = New MPRCell(control3D.SagittalFrame, "Sagittal", control3D.ObjectsContainer.Objects(0).GetMPRInformation(Medical3DMPRPlaneType.Sagittal, control3D.SagittalFrame.ActiveSubCell))
            mprCells(2) = New MPRCell(control3D.CoronalFrame, "Coronal", control3D.ObjectsContainer.Objects(0).GetMPRInformation(Medical3DMPRPlaneType.Coronal, control3D.CoronalFrame.ActiveSubCell))

            Dim index As Integer = 0
            Do While index < 3
               Dim currentMPRCell As MedicalViewerMPRCell = mprCells(index).Cell
               Dim image As RasterImage = mprCells(index).MPRInfo.Image

               UpdateDicomDataSetInformation(dicomDataSet, currentMPRCell, mprCells(index).MPRInfo)

               dicomDataSet.DeleteImage(Nothing, 0, imageCount)

               dicomDataSet.SetImage(Nothing, image, DicomImageCompressionType.None, DicomImagePhotometricInterpretationType.Monochrome2, image.BitsPerPixel, 2, DicomSetImageFlags.None)

               dicomDataSet.Save(String.Format("{0}_{1}.dcm", fileNameWithNoExtenstion, mprCells(index).Name), DicomDataSetSaveFlags.None)
               index += 1
            Loop

            dicomDataSet.Dispose()
         End If

      End Sub

      Private Sub _save3DImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _save3DImage.Click
         Dim fileName As String = ShowSaveDialog("DICOM Files (*.dcm)|*.dcm")

         If Not fileName Is Nothing Then
            Dim control3D As Medical3DControl = GetFirstSelected3DControl()
            Dim image As RasterImage = control3D.ObjectsContainer.Objects(0).GetRendered3DObject()

            Dim codecs As RasterCodecs = New RasterCodecs()
            codecs.Save(image, fileName, RasterImageFormat.Tif, 64)
         End If
      End Sub

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

   ''' <summary>
   ''' This class contains the information that will be saved in cell "Tag"
   ''' </summary>
   Public Class CellData
      Private _colorMapIndex As Integer
      Private _cellType As ViewerCellType
      Private _colorMapPoint As List(Of ChannelHistogram())
      Private _fileNames As String()
      Private _imagePositions As Point3D()
      Private _frameInstanceNumber As Integer()
      Private _multiPageCount As Integer
      Private _cell As MedicalViewerMultiCell
      Private _frameIndex As Integer
      Private _counterDialog As CounterDialog

      Public Sub New(cellType As ViewerCellType)
         _cellType = cellType
         Initialize()
      End Sub

      Private Sub Initialize()
         _colorMapIndex = -1
      End Sub

      Public Sub New()
         _cellType = ViewerCellType.Cell2D
         Initialize()
      End Sub

      Public Property Counter() As CounterDialog
         Get
            Return _counterDialog
         End Get
         Set(value As CounterDialog)
            _counterDialog = value
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

      Public Property ColorMapIndex() As Integer
         Get
            Return _colorMapIndex
         End Get

         Set(value As Integer)
            _colorMapIndex = value
         End Set
      End Property

      Public Property ColorMapList() As List(Of ChannelHistogram())
         Get
            Return _colorMapPoint
         End Get

         Set(value As List(Of ChannelHistogram()))
            _colorMapPoint = value
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

      Public ColorMap As Medical3DColorMapping = Nothing
      Public Palette As Byte() = Nothing


      Public CurrentCheckedItem As ToolStripMenuItem
      Public CurrentCheckedRightClickItem As ToolStripMenuItem
      Public CurrentActionType As MedicalViewerActionType
   End Class
End Namespace
