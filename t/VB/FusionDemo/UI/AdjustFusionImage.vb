' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.MedicalViewer
Imports System.Collections.Generic
Imports System.Drawing.Drawing2D
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Designers
Imports Leadtools
Imports Leadtools.Annotations.WinForms
Imports System

Namespace FusionDemo
   Partial Public Class AdjustFusionImage
      Inherits Form
      Private _viewer As MedicalViewer
      Private _form As MainForm
      Private _cellFusionNames As List(Of FusionData)()
      Private _cell As MedicalViewerMultiCell
      Private _currentAnnDesigner As AnnEditDesigner
      Private _update As Boolean

      Public Property Cell() As MedicalViewerMultiCell
         Get
            Return _cell
         End Get
         Set(value As MedicalViewerMultiCell)
            _cell = value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub New(viewer As MedicalViewer, form As MainForm)
         _viewer = viewer
         _form = form

         AddHandler Me.Shown, AddressOf AdjustFusionImage_Shown
         AddHandler Me.FormClosed, AddressOf AdjustFusionImage_FormClosed

         InitializeComponent()
         InitializeAdjustFusionImageForm()
      End Sub

      Private Sub AdjustFusionImage_FormClosed(sender As Object, e As FormClosedEventArgs)
         RemoveHandler _cell.Paint, AddressOf _cell_Paint
         RemoveHandler _cell.DesignerCreated, AddressOf _cell_DesignerCreated
         RemoveHandler _cell.ActiveSubCellChanged, AddressOf _cell_ActiveSubCellChanged
         RemoveHandler _cell.DeleteAnnotation, AddressOf _cell_DeleteAnnotation
         RemoveHandler _cell.Automation.Edit, AddressOf Automation_Edit
         RemoveHandler _cell.Automation.SetCursor, AddressOf Automation_SetCursor
         RemoveHandler _cell.Automation.RestoreCursor, AddressOf Automation_RestoreCursor
         RemoveHandler Me.Shown, AddressOf AdjustFusionImage_Shown
      End Sub

      Private Sub AdjustFusionImage_Shown(sender As Object, e As EventArgs)
         UpdateFusionComboBox()
      End Sub

      Private Sub InitializeAdjustFusionImageForm()
         _currentAnnDesigner = Nothing

         Dim cellIndex As Integer = _form.GetFirstSelectedMultiCellIndex()
         If cellIndex = -1 Then
            Return
         End If

         _cell = CType(_viewer.Cells(cellIndex), MedicalViewerMultiCell)
         If _cell Is Nothing Then
            Return
         End If

         AddHandler _cell.Automation.Edit, AddressOf Automation_Edit
         AddHandler _cell.Automation.SetCursor, AddressOf Automation_SetCursor
         AddHandler _cell.Automation.RestoreCursor, AddressOf Automation_RestoreCursor

         _cellFusionNames = _form.FusionListNames(cellIndex)
         UpdateFusionUI(0)
         UpdateFusionComboBox()
         Dim subCell As MedicalViewerSubCell = _cell.SubCells(_cell.ActiveSubCell)

         AddHandler Me.FormClosing, AddressOf AdjustFusionImage_FormClosing

         AddHandler _cell.Paint, AddressOf _cell_Paint
         AddHandler _cell.DesignerCreated, AddressOf _cell_DesignerCreated
         AddHandler _cell.ActiveSubCellChanged, AddressOf _cell_ActiveSubCellChanged
         AddHandler _cell.DeleteAnnotation, AddressOf _cell_DeleteAnnotation

      End Sub
      Private Sub Automation_RestoreCursor(sender As Object, e As EventArgs)
         If _viewer.Cursor <> Cursors.[Default] Then
            _viewer.Cursor = Cursors.[Default]
            For Each control As Control In _viewer.Cells
               _form.SetAction(control, MedicalViewerActionType.AnnotationPoint, Nothing)
            Next
         End If
      End Sub
      Private Sub Automation_SetCursor(sender As Object, e As AnnCursorEventArgs)
         Dim newCursor As Cursor = Nothing
         For Each control As Control In _viewer.Cells
            _form.SetAction(control, MedicalViewerActionType.None, Nothing)
         Next
         If e.IsRotateCenter Then
            newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateCenterControlPoint)
         ElseIf e.IsRotateGripper Then
            newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateGripperControlPoint)
         ElseIf e.ThumbIndex < 0 Then
            newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectedObject)
         Else
            newCursor = AutomationManagerHelper.AutomationCursors(CursorType.ControlPoint)
         End If
         If _viewer.Cursor <> newCursor Then
            _viewer.Cursor = newCursor
         End If
      End Sub

      Private Sub Automation_Edit(sender As Object, e As AnnEditDesignerEventArgs)
         AdjustFusionImage_Edit(sender, CType(e.[Object], AnnRectangleObject))
      End Sub

      Private Sub _cell_ActiveSubCellChanged(sender As Object, e As MedicalViewerActiveSubCellChangedEventArgs)
         If _cell.SubCells(_cell.ActiveSubCell).Fusion.Count < 1 Then
            EnableControls(False)
         Else
            EnableControls(True)
            TerminateAdjustFusionImageForm()
            InitializeAdjustFusionImageForm()
         End If
      End Sub

      Private Sub _cell_DeleteAnnotation(sender As Object, e As MedicalViewerDeleteEventArgs)
         Dim msgBoxResult As DialogResult = MessageBox.Show("Are you sure want to delete this fusion image?", "Delete Fusion Image", MessageBoxButtons.YesNo)

         If msgBoxResult = DialogResult.Yes Then
            _cell.SubCells(_cell.ActiveSubCell).Fusion.RemoveAt(_cmbFusedIndex.SelectedIndex)
            _form.FusionListNames(_form.GetFirstSelectedMultiCellIndex())(_cell.ActiveSubCell).RemoveAt(_cmbFusedIndex.SelectedIndex)
            _cmbFusedIndex.Items.RemoveAt(_cmbFusedIndex.SelectedIndex)
            If _cmbFusedIndex.Items.Count < 1 Then
               Me.Close()
            Else
               _cmbFusedIndex.SelectedIndex = 0
            End If
         Else
            e.Delete = False
         End If

         _form.CheckFusionTranslucencyAction(_viewer.Cells.IndexOf(_cell))
      End Sub

      Private Sub _cell_DesignerCreated(sender As Object, e As MedicalViewerDesignerCreatedEventArgs)
         _currentAnnDesigner = CType(e.Designer, AnnEditDesigner)
         e.[Object].RotateGripper = New LeadLengthD(e.[Object].RotateGripper.Value / 2)
      End Sub

      Private Function GetContainer(cell As MedicalViewerMultiCell, annotationObject As AnnObject) As AnnContainer
         Dim index As Integer = 0
         Dim length As Integer = cell.SubCells.Count

         Dim container As AnnContainer
         For index = 0 To length - 1
            container = cell.SubCells(index).AnnotationContainer

            If container.Children.IndexOf(annotationObject) <> -1 Then
               Return container
            End If
         Next
         Return Nothing
      End Function

      Private Sub AdjustFusionImage_Edit(sender As Object, fusionEditRect As AnnRectangleObject)
         Dim subCellIndex As Integer = _cell.ActiveSubCell
         Dim index As Integer = _cmbFusedIndex.SelectedIndex

         Dim fusion As MedicalViewerFusion = _cell.SubCells(subCellIndex).Fusion(index)

         Dim _Container As AnnContainer = GetContainer(_cell, fusionEditRect)
         fusion.Rotation = CSng(fusionEditRect.Angle)

         Dim pt As LeadPointD() = New LeadPointD(0) {}


         Dim rect As LeadRectD = _Container.Mapper.RectFromContainerCoordinates(fusionEditRect.Rect, AnnFixedStateOperations.None)

         Dim displayRect As Rectangle = _cell.GetDisplayedImageRectangle()

         rect.Offset(-displayRect.Left, -displayRect.Top)


         pt(0).X = CSng(rect.X + rect.Width / 2)
         pt(0).Y = CSng(rect.Y + rect.Height / 2)

         Dim point As LeadPointD = LeadPointD.Create(pt(0).X, pt(0).Y)


         _cell.AutomationContainer.Mapper.Transform.TransformPoints(pt)

         Dim normalizedXPosition As Single = CSng((CSng(point.X) - CSng(displayRect.Width) / 2) / fusion.FusedImage.Width * 100 / _cell.GetScale(subCellIndex))
         Dim normalizedYPosition As Single = CSng((CSng(point.Y) - CSng(displayRect.Height) / 2) / fusion.FusedImage.Height * 100 / _cell.GetScale(subCellIndex))

         Dim scaleX As Single = CSng((rect.Width / fusion.FusedImage.Width) * 100 / _cell.GetScale(subCellIndex))
         Dim scaleY As Single = CSng((rect.Height / fusion.FusedImage.Height) * 100 / _cell.GetScale(subCellIndex))

         If scaleX = 0 Then
            scaleX = 0.1F
         End If

         If scaleY = 0 Then
            scaleY = 0.1F
         End If

         Dim rectangle As New RectangleF(normalizedXPosition, normalizedYPosition, Math.Abs(scaleX), Math.Abs(scaleY))

         fusion.DisplayRectangle = rectangle

         UpdateFusionUI(index)

         Dim cellData As CellData = CType(_cell.Tag, CellData)
         If cellData.SyncCellFusion Then
            UpdateCellFusions(fusion, subCellIndex, index)
         End If

         _cell.Invalidate()
      End Sub

      Private Sub AdjustFusionImage_FormClosing(sender As Object, e As FormClosingEventArgs)
         TerminateAdjustFusionImageForm()
      End Sub

      Private Sub TerminateAdjustFusionImageForm()
         HideAllFusionEditRectangles()
         If _currentAnnDesigner IsNot Nothing Then
            _currentAnnDesigner.[End]()
         End If

         RemoveHandler Me.FormClosing, AddressOf AdjustFusionImage_FormClosing

         If _cell IsNot Nothing AndAlso Not _cell.IsDisposed Then
            Dim subCell As MedicalViewerSubCell = _cell.SubCells(_cell.ActiveSubCell)

            RemoveHandler _cell.Paint, AddressOf _cell_Paint
            RemoveHandler _cell.DesignerCreated, AddressOf _cell_DesignerCreated
            RemoveHandler _cell.DeleteAnnotation, AddressOf _cell_DeleteAnnotation
            RemoveHandler _cell.ActiveSubCellChanged, AddressOf _cell_ActiveSubCellChanged
         End If

         If _palettePreview.Image IsNot Nothing Then
            _palettePreview.Image.Dispose()
            _palettePreview.Image = Nothing
         End If

         If _orgImagePalettePreview.Image IsNot Nothing Then
            _orgImagePalettePreview.Image.Dispose()
            _orgImagePalettePreview.Image = Nothing
         End If
      End Sub

      Private Sub _cell_Paint(sender As Object, e As PaintEventArgs)
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
      End Sub

      Private Sub UpdateFusionComboBox()
         _cmbFusedIndex.Items.Clear()

         Dim subCellIndex As Integer = _cell.ActiveSubCell

         Dim index As Integer = 0
         Dim length As Integer = If(_cellFusionNames(subCellIndex) Is Nothing, 0, _cellFusionNames(subCellIndex).Count)

         For index = 0 To length - 1
            _cmbFusedIndex.Items.Add(_cellFusionNames(subCellIndex)(index).Name)
         Next

         EnableControls(length <> 0)

         If length <> 0 Then
            _cmbFusedIndex.SelectedIndex = 0
         End If
      End Sub

      Private Sub EnableControls(enabled As Boolean)
         _txtRotate.Enabled = enabled
         _txtWLWidth.Enabled = enabled
         _txtWLCenter.Enabled = enabled
         _txtOffsetX.Enabled = enabled
         _txtOffsetY.Enabled = enabled
         _cmbPalette.Enabled = enabled
         _cmbFusedIndex.Enabled = enabled
         _chkFit.Enabled = enabled
         _txtScaleX.Enabled = (Not _chkFit.Checked) AndAlso enabled
         _txtScaleY.Enabled = (Not _chkFit.Checked) AndAlso enabled
      End Sub

      Private Sub UpdateFusion()
         If Not _update Then
            Return
         End If

         Dim subCellIndex As Integer = _cell.ActiveSubCell
         Dim index As Integer = _cmbFusedIndex.SelectedIndex

         Dim subCell As MedicalViewerSubCell = _cell.SubCells(subCellIndex)
         Dim fusion As MedicalViewerFusion = subCell.Fusion(index)

         UpdatePalettePreview(_cmbPalette, _palettePreview)

         If _txtWLWidth.Text = "" Then
            fusion.Width = 1
         Else
            fusion.Width = Convert.ToInt32(_txtWLWidth.Text)
         End If

         If _txtWLCenter.Text = "" Then
            fusion.Center = 0
         Else
            fusion.Center = Convert.ToInt32(_txtWLCenter.Text)
         End If

         fusion.ColorPalette = CType(_cmbPalette.SelectedIndex, MedicalViewerPaletteType)

         If _txtOffsetX.Text = "" Then
            fusion.DisplayRectangle = New RectangleF(0, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height)
         Else
            Try
               Dim offsetX As Single = Single.Parse(_txtOffsetX.Text) / fusion.FusedImage.Width
               fusion.DisplayRectangle = New RectangleF(offsetX, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height)
            Catch
            End Try
         End If

         If _txtOffsetY.Text = "" Then
            fusion.DisplayRectangle = New RectangleF(fusion.DisplayRectangle.X, 0, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height)
         Else
            Try
               Dim offsetY As Single = Single.Parse(_txtOffsetY.Text) / fusion.FusedImage.Height
               fusion.DisplayRectangle = New RectangleF(fusion.DisplayRectangle.X, offsetY, fusion.DisplayRectangle.Width, fusion.DisplayRectangle.Height)
            Catch
            End Try
         End If


         Dim image As RasterImage = _cell.VirtualImage(subCellIndex).Image

         Dim fitScaleX As Single = image.Width * 1.0F / fusion.FusedImage.Width
         Dim fitScaleY As Single = image.Height * 1.0F / fusion.FusedImage.Height

         Dim xScale As Single = 0.001F
         If _txtScaleX.Text <> "" Then
            xScale = Math.Max(xScale, Single.Parse(_txtScaleX.Text))
         End If

         Dim yScale As Single = 0.001F
         If _txtScaleY.Text <> "" Then
            yScale = Math.Max(yScale, Single.Parse(_txtScaleY.Text))
         End If

         If _txtScaleX.Text = "" Then
            fusion.DisplayRectangle = New RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, 1, fusion.DisplayRectangle.Height)
         Else
            fusion.DisplayRectangle = New RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, If(_chkFit.Checked, fitScaleX, xScale / 100.0F), fusion.DisplayRectangle.Height)
         End If

         If _txtScaleY.Text = "" Then
            fusion.DisplayRectangle = New RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, 1)
         Else
            fusion.DisplayRectangle = New RectangleF(fusion.DisplayRectangle.X, fusion.DisplayRectangle.Y, fusion.DisplayRectangle.Width, If(_chkFit.Checked, fitScaleY, yScale / 100.0F))
         End If

         If _txtRotate.Text = "" Then
            fusion.Rotation = 0
         Else
            Try
               fusion.Rotation = Single.Parse(_txtRotate.Text)
            Catch
            End Try
         End If


         UpdateFusionEditRectangle(index)

         Dim cellData As CellData = CType(_cell.Tag, CellData)
         If cellData.SyncCellFusion Then
            UpdateCellFusions(fusion, subCellIndex, index)
         End If
      End Sub

      Private Sub SuspendUpdate()
         _update = False
      End Sub

      Private Sub ResumeUpdate()
         _update = True
      End Sub

      Private Sub UpdateCellFusions(refFusion As MedicalViewerFusion, subCellIndex As Integer, index As Integer)
         For i As Integer = 0 To _cell.SubCells.Count - 1
            If i = subCellIndex Then
               Continue For
            End If

            If _cell.SubCells(i).Fusion.Count <= index Then
               Continue For
            End If

            Dim fusion As MedicalViewerFusion = _cell.SubCells(i).Fusion(index)
            fusion.Center = refFusion.Center
            fusion.ColorPalette = refFusion.ColorPalette
            fusion.DisplayRectangle = New RectangleF(refFusion.DisplayRectangle.X, refFusion.DisplayRectangle.Y, refFusion.DisplayRectangle.Width, refFusion.DisplayRectangle.Height)
            fusion.Fit = refFusion.Fit
            fusion.FusionScale = refFusion.FusionScale
            fusion.OffsetX = refFusion.OffsetX
            fusion.OffsetY = refFusion.OffsetY
            fusion.Rotation = refFusion.Rotation
            fusion.Scale = refFusion.Scale
            fusion.Width = refFusion.Width
         Next
      End Sub


      Private Sub UpdateFusionUI(index As Integer)
         SuspendUpdate()
         Dim subCellIndex As Integer = _cell.ActiveSubCell

         _cmbOrgImagePalette.SelectedIndex = CInt(_cell.SubCells(subCellIndex).PaletteType)

         If index >= 0 AndAlso _cell.SubCells(subCellIndex).Fusion.Count > index Then
            Dim subCell As MedicalViewerSubCell = _cell.SubCells(subCellIndex)
            Dim fusion As MedicalViewerFusion = subCell.Fusion(index)

            _cmbPalette.SelectedIndex = CInt(fusion.ColorPalette)
            _txtWLWidth.Text = fusion.Width.ToString()
            _txtWLCenter.Text = fusion.Center.ToString()

            UpdatePalettePreview(_cmbPalette, _palettePreview)

            _txtOffsetX.Text = (fusion.DisplayRectangle.X * fusion.FusedImage.Width).ToString("#0.000")
            _txtOffsetY.Text = (fusion.DisplayRectangle.Y * fusion.FusedImage.Height).ToString("#0.000")

            _chkFit.Checked = (Math.Abs(fusion.DisplayRectangle.Width - 1) < 0.0001 AndAlso Math.Abs(fusion.DisplayRectangle.Height - 1) < 0.0001)

            _txtScaleX.Text = (fusion.DisplayRectangle.Width * 100).ToString("#0.000")
            _txtScaleX.Enabled = Not _chkFit.Checked
            _txtScaleY.Text = (fusion.DisplayRectangle.Height * 100).ToString("#0.000")
            _txtScaleY.Enabled = Not _chkFit.Checked

            _txtRotate.Text = fusion.Rotation.ToString("#0.000")

            _txtRotate.Refresh()

            _txtOffsetX.Refresh()
            _txtOffsetY.Refresh()

            _txtScaleX.Refresh()
            _txtScaleY.Refresh()
            _chkFit.Refresh()
         End If

         ResumeUpdate()
      End Sub

      Private Sub FillImage(img As Image, colors As Color())
         Dim xstep As Single = CSng(img.Width) / CSng(colors.Length)

         Dim brushes As New List(Of SolidBrush)()
         For Each color As Color In colors
            brushes.Add(New SolidBrush(color))
         Next

         Using g As Graphics = Graphics.FromImage(img)
            For x As Integer = 0 To colors.Length - 1
               g.FillRectangle(brushes(x), New RectangleF(x * xstep, 0, xstep, img.Height))
            Next
         End Using
      End Sub

      Private Sub UpdatePalettePreview(cmbPalette As ComboBox, palettePreview As PictureBox)
         Dim palette As Byte() = MedicalViewerCell.GetPalette(CType(cmbPalette.SelectedIndex, MedicalViewerPaletteType))
         If palette IsNot Nothing Then
            Dim colorArray As Color() = New Color(CInt(palette.Length / 3 - 1)) {}
            For i As Integer = 0 To palette.Length - 1 Step 3
               colorArray(CInt(i / 3)) = Color.FromArgb(palette(i), palette(i + 1), palette(i + 2))
            Next
            If palettePreview.Image IsNot Nothing Then
               palettePreview.Image.Dispose()
               palettePreview.Image = Nothing
            End If
            Dim paletteImage As Image = New Bitmap(palettePreview.Width, palettePreview.Height)
            FillImage(paletteImage, colorArray)

            palettePreview.Image = paletteImage
         Else
            palettePreview.Image = Nothing
         End If
      End Sub

      Private Sub AddAnnotationRectangle(subCell As MedicalViewerSubCell)
         Dim rect As New AnnRectangleObject()
         rect.IsVisible = False
         rect.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), LeadLengthD.Create(5))
         subCell.AnnotationContainer.Children.Add(rect)
      End Sub

      Private Sub ShowFusionEditRectangle(index As Integer)
         Dim subCellIndex As Integer = _cell.ActiveSubCell

         Dim subCell As MedicalViewerSubCell = _cell.SubCells(subCellIndex)

         For i As Integer = 0 To subCell.AnnotationContainer.Children.Count - 1
            subCell.AnnotationContainer.Children(i).IsVisible = False
         Next

         AddAnnotationRectangle(subCell)

         UpdateFusionEditRectangle(index)

         subCell.AnnotationContainer.Children(index).IsVisible = True
         _cell.RefreshAnnotation()
      End Sub

      Private Sub UpdateFusionEditRectangle(index As Integer)
         Dim subCellIndex As Integer = _cell.ActiveSubCell

         Dim subCell As MedicalViewerSubCell = _cell.SubCells(subCellIndex)
         Dim fusion As MedicalViewerFusion = _cell.SubCells(subCellIndex).Fusion(index)
         Dim fusionEditRect As AnnRectangleObject = CType(subCell.AnnotationContainer.Children(index), AnnRectangleObject)
         Dim scaleRatio As Double = _cell.GetScale(subCellIndex) / 100

         Dim location As Point = _cell.GetDisplayedImageRectangle().Location

         Dim container As AnnContainer = subCell.AnnotationContainer
         Dim scale As Double = _cell.GetScale(subCellIndex)

         Dim fusionEditRectSize As New LeadSizeD()
         fusionEditRectSize.Width = fusion.FusedImage.Width * fusion.DisplayRectangle.Width * scale / 100
         fusionEditRectSize.Height = fusion.FusedImage.Height * fusion.DisplayRectangle.Height * scale / 100

         fusionEditRectSize = container.Mapper.SizeToContainerCoordinates(fusionEditRectSize)

         Dim fusionEditRectPos As New LeadPointD()
         fusionEditRectPos.X = (subCell.AnnotationContainer.Size.Width - fusionEditRectSize.Width) / 2
         fusionEditRectPos.Y = (subCell.AnnotationContainer.Size.Height - fusionEditRectSize.Height) / 2

         'container.Bounds
         fusionEditRect.Rect = New LeadRectD(fusionEditRectPos, fusionEditRectSize)

         Dim _Container As AnnContainer = GetContainer(_cell, fusionEditRect)

         fusionEditRect.Rotate(fusion.Rotation, New LeadPointD(_Container.Size.Width / 2, _Container.Size.Height / 2))
         Dim point As LeadPointD = LeadPointD.Create(fusion.DisplayRectangle.X * fusion.FusedImage.Width * scaleRatio + location.X, fusion.DisplayRectangle.Y * fusion.FusedImage.Height * scaleRatio + location.Y)
         point = _Container.Mapper.PointToContainerCoordinates(point)
         fusionEditRect.Translate(point.X, point.Y)

         fusionEditRect.RotateCenter = New LeadPointD(fusionEditRect.Rect.Left + (fusionEditRect.Rect.Width / 2), fusionEditRect.Rect.Top + (fusionEditRect.Rect.Height / 2))

         _cell.RefreshAnnotation()
         _cell.Automation.Invalidate(LeadRectD.Empty)
         _cell.Invalidate()
      End Sub

      Private Sub HideAllFusionEditRectangles()
         If _cell.IsDisposed Then
            Return
         End If

         _cell.Automation.DeleteSelectedObjects()
         For Each subCell As MedicalViewerSubCell In _cell.SubCells
            subCell.AnnotationContainer.Children.Clear()
         Next

         _cell.RefreshAnnotation()
      End Sub

      Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnClose.Click
         If _currentAnnDesigner IsNot Nothing Then
            _currentAnnDesigner.[End]()
         End If

         Close()
      End Sub

      Private Sub _btnApply_Click(sender As Object, e As EventArgs)
         _btnOK_Click(sender, e)
      End Sub

      Private Sub _txtOffsetY_TextChanged(sender As Object, e As EventArgs) Handles _txtOffsetY.TextChanged
         UpdateFusion()
      End Sub

      Private Sub _txtOffsetX_TextChanged(sender As Object, e As EventArgs) Handles _txtOffsetX.TextChanged
         UpdateFusion()
      End Sub

      Private Sub _txtScale_TextChanged(sender As Object, e As EventArgs) Handles _txtScaleY.TextChanged, _txtScaleX.TextChanged
         UpdateFusion()
      End Sub

      Private Sub _txtWLWidth_TextChanged(sender As Object, e As EventArgs) Handles _txtWLWidth.TextChanged
         UpdateFusion()
      End Sub

      Private Sub _txtWLCenter_TextChanged(sender As Object, e As EventArgs) Handles _txtWLCenter.TextChanged
         UpdateFusion()
      End Sub

      Private Sub _txtRotate_TextChanged(sender As Object, e As EventArgs) Handles _txtRotate.TextChanged
         UpdateFusion()
      End Sub

      Private Sub _chkFit_CheckedChanged(sender As Object, e As EventArgs) Handles _chkFit.CheckedChanged
         _txtScaleX.Enabled = Not _chkFit.Checked
         _txtScaleY.Enabled = Not _chkFit.Checked
         UpdateFusion()
      End Sub

      Private Sub _cmbFusedIndex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbFusedIndex.SelectedIndexChanged
         UpdateFusionUI(_cmbFusedIndex.SelectedIndex)

         ShowFusionEditRectangle(_cmbFusedIndex.SelectedIndex)

         If _currentAnnDesigner IsNot Nothing Then
            _currentAnnDesigner.[End]()
         End If
      End Sub

      Private Sub _cmbPalette_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbPalette.SelectedIndexChanged
         UpdateFusion()
      End Sub

      Private Sub _cmbOrgImagePalette_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbOrgImagePalette.SelectedIndexChanged
         UpdatePalettePreview(_cmbOrgImagePalette, _orgImagePalettePreview)

         _cell.SubCells(_cell.ActiveSubCell).PaletteType = CType(_cmbOrgImagePalette.SelectedIndex, MedicalViewerPaletteType)
      End Sub

      Private Sub _btnReset_Click(sender As Object, e As EventArgs) Handles _btnReset.Click
         Dim subCellIndex As Integer = _cell.ActiveSubCell
         Dim index As Integer = _cmbFusedIndex.SelectedIndex

         _cmbOrgImagePalette.SelectedIndex = 0

         UpdatePalettePreview(_cmbOrgImagePalette, _orgImagePalettePreview)

         If index >= 0 AndAlso _cell.SubCells(subCellIndex).Fusion.Count > index Then
            Dim subCell As MedicalViewerSubCell = _cell.SubCells(subCellIndex)
            Dim fusion As MedicalViewerFusion = subCell.Fusion(index)

            Dim tmpFusion As New MedicalViewerFusion()
            tmpFusion.FusedImage = fusion.FusedImage

            SuspendUpdate()
            _txtWLWidth.Text = tmpFusion.Width.ToString()
            _txtWLCenter.Text = tmpFusion.Center.ToString()

            _txtScaleX.Text = "100.000"
            _txtScaleY.Text = "100.000"

            _txtOffsetX.Text = "0.000"
            _txtOffsetY.Text = "0.000"

            _txtRotate.Text = "0.000"

            _chkFit.Checked = True

            _cmbPalette.SelectedIndex = 0

            ResumeUpdate()

            UpdateFusion()

            _txtRotate.Refresh()

            _txtOffsetX.Refresh()
            _txtOffsetY.Refresh()

            _txtScaleX.Refresh()
            _txtScaleY.Refresh()

            _chkFit.Refresh()

            _cmbPalette.Refresh()
            resetOffset()
         End If
      End Sub

      Private Sub resetOffset()
         Using offset As MedicalViewerOffset = CType(_cell.GetActionProperties(MedicalViewerActionType.Offset), MedicalViewerOffset)
            offset.X = 0
            offset.Y = 0
            _cell.SetActionProperties(MedicalViewerActionType.Offset, offset)
         End Using
      End Sub

   End Class
End Namespace
