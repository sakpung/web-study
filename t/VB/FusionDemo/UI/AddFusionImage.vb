' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.MedicalViewer
Imports Leadtools
Imports System.Collections.Generic
Imports Leadtools.Annotations.Engine

Namespace FusionDemo
   Partial Public Class AddFusionImage : Inherits Form
      Private _viewer As MedicalViewer
      Private _form As MainForm
      Private _weightList As List(Of Integer)
      Private _cellFusionPaths As List(Of String)
      Private _images As List(Of RasterImage)
      Private _cellFusionNames As List(Of FusionData)()
      Private _cell As MedicalViewerMultiCell = Nothing

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub New(ByVal viewer As MedicalViewer, ByVal form As MainForm)
         _viewer = viewer
         _form = form
         _weightList = New List(Of Integer)()
         _cellFusionPaths = New List(Of String)()
         _images = New List(Of RasterImage)()

         InitializeComponent()
         InitializeFusionList()
         UpdateUI()

         If _listFusionImages.Items.Count <> 0 Then
            _listFusionImages.SelectedIndex = 0
            UpdateText()
         End If

         AddHandler Shown, AddressOf AddFusionImage_Shown
      End Sub

      Protected Overrides Sub Finalize()
         RemoveHandler Shown, AddressOf AddFusionImage_Shown
      End Sub

      Private Sub AddFusionImage_Shown(ByVal sender As Object, ByVal e As EventArgs)
         _btnAdd.Focus()
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         If ApplyFusion() Then
            Me.Close()
         End If
      End Sub

      Private Function ApplyFusion() As Boolean
         If GetTotalCount() > 100 Then
            MessageBox.Show("the weight total for the fused images should not exceed 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
         Else

            Dim cellIndex As Integer = _form.GetFirstSelectedMultiCellIndex()

            If cellIndex = -1 Then
               Return False
            End If

            Dim cell As MedicalViewerMultiCell = CType(_viewer.Cells(cellIndex), MedicalViewerMultiCell)
            If cell Is Nothing Then
               Return False
            End If

            _cellFusionNames = _form.FusionListNames(cellIndex)

            Dim subCellIndex As Integer = cell.ActiveSubCell

            If _form.FusionListNames(cellIndex)(subCellIndex) Is Nothing Then
               _form.FusionListNames(cellIndex)(subCellIndex) = New List(Of FusionData)()
            End If



            Dim index As Integer = 0

            _form.FusionListNames(cellIndex)(subCellIndex).Clear()

            index = 0
            Do While index < _listFusionImages.Items.Count
               _form.FusionListNames(cellIndex)(subCellIndex).Add(New FusionData(_cellFusionPaths(index), _listFusionImages.Items(index).ToString(), 0))
               index += 1
            Loop
         End If

         Return True
      End Function

      Private Sub InitializeFusionList()
         Dim cellIndex As Integer = _form.GetFirstSelectedMultiCellIndex()

         If cellIndex = -1 Then
            Return
         End If

         _cell = CType(_viewer.Cells(cellIndex), MedicalViewerMultiCell)
         If _cell Is Nothing Then
            Return
         End If

         _cellFusionNames = _form.FusionListNames(cellIndex)

         Dim subCellIndex As Integer = _cell.ActiveSubCell

         If _cellFusionNames(subCellIndex) Is Nothing Then
            Return
         End If

         Dim index As Integer = 0

         index = 0
         Do While index < _cellFusionNames(subCellIndex).Count
            _listFusionImages.Items.Add(_cellFusionNames(subCellIndex)(index).Name)
            _cellFusionPaths.Add(_cellFusionNames(subCellIndex)(index).Filename)
            _weightList.Add(CInt(_cell.SubCells(subCellIndex).Fusion(index).FusionScale * 100))
            _images.Add(_cell.SubCells(subCellIndex).Fusion(index).FusedImage)
            index += 1
         Loop
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs)
         ApplyFusion()
      End Sub

      Private Sub _btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnAdd.Click
         Dim seriesName As String = ""
         Dim seriesPath As String = ""
         Dim image As RasterImage = _form.LoadFusionDicom(seriesName, seriesPath, Me)
         If image Is Nothing Then
            Return
         End If

         _listFusionImages.Items.Add(seriesName)
         _cellFusionPaths.Add(seriesPath)

         If _listFusionImages.Items.Count = 1 Then
            _weightList.Add(50)
         Else
            _weightList.Add(0)
         End If

         Dim index As Integer = _listFusionImages.Items.Count - 1


         Dim fusion As New MedicalViewerFusion()
         fusion.FusedImage = image
         fusion.FusionScale = _weightList(index) / 100.0F


         Dim virtualImage As RasterImage = _cell.VirtualImage(_cell.ActiveSubCell).Image

         Dim fitScaleX As Single = virtualImage.Width * 1.0F / image.Width
         Dim fitScaleY As Single = virtualImage.Height * 1.0F / image.Height

         fusion.DisplayRectangle = New RectangleF(0, 0, fitScaleX, fitScaleY)
         _images.Add(image)

         _cell.SubCells(_cell.ActiveSubCell).Fusion.Add(fusion)

         AddFusionEditRectangle(_cell.SubCells(_cell.ActiveSubCell))

         _listFusionImages.SelectedIndex = index

         UpdateText()
         UpdateUI()
      End Sub

      Private Sub AddFusionEditRectangle(ByVal subCell As MedicalViewerSubCell)
         Dim rect As AnnRectangleObject = New AnnRectangleObject()
         rect.IsVisible = False
         rect.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), LeadLengthD.Create(5))

         subCell.AnnotationContainer.Children.Add(rect)
      End Sub

      Private Sub UpdateUI()
         _btnRemove.Enabled = (_listFusionImages.Items.Count <> 0)
         _txtWeight.Enabled = (_listFusionImages.Items.Count <> 0)
         _trackBarWeight.Enabled = (_listFusionImages.Items.Count <> 0)
      End Sub

      Private Function GetTotalCount() As Integer
         Dim count As Integer = 0
         For Each weight As Integer In _weightList
            count += weight
         Next weight

         Return count

      End Function

      Private Function GetFusionDefaultValue() As Integer
         Dim percentage As Double = 0.0
         Dim denominator As Double = _listFusionImages.Items.Count + 1.0

         Dim imagePercent As Double = 100 - GetTotalCount()

         If imagePercent < 0 Then
            Return 0
         End If

         percentage = imagePercent / denominator

         For Each weight As Integer In _weightList
            percentage = percentage + (weight / denominator)
         Next weight

         Return CInt(percentage)
      End Function

      Private Sub _btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRemove.Click
         Dim removeIndex As Integer = _listFusionImages.SelectedIndex

         _cell.SubCells(_cell.ActiveSubCell).Fusion.RemoveAt(removeIndex)

         _listFusionImages.Items.RemoveAt(removeIndex)
         _cellFusionPaths.RemoveAt(removeIndex)
         _weightList.RemoveAt(removeIndex)
         _images(removeIndex).Dispose()
         _images.RemoveAt(removeIndex)

         RemoveFusionEditRectangle(_cell.SubCells(_cell.ActiveSubCell), removeIndex)


         If _listFusionImages.Items.Count <> 0 Then
            _listFusionImages.SelectedIndex = Math.Min(_listFusionImages.Items.Count - 1, removeIndex)
         End If

         UpdateUI()
         _form.CheckFusionTranslucencyAction(_viewer.Cells.IndexOf(_cell))
      End Sub

      Private Sub RemoveFusionEditRectangle(ByVal subCell As MedicalViewerSubCell, ByVal removeIndex As Integer)
         If subCell.AnnotationContainer.Children.Count <> 0 Then
            subCell.AnnotationContainer.Children.RemoveAt(removeIndex)
            _cell.RefreshAnnotation()
         End If
      End Sub

      Private Sub _cmbSubCellIndex_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      End Sub

      Private Sub UpdateText()
         _txtWeight.Text = _weightList(_listFusionImages.SelectedIndex).ToString()
         _trackBarWeight.Value = _weightList(_listFusionImages.SelectedIndex)
      End Sub

      Private Sub _listFusionImages_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _listFusionImages.SelectedIndexChanged
         If _listFusionImages.SelectedIndex <> -1 Then
            UpdateText()
         End If
      End Sub

      Private Sub _txtWeight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtWeight.TextChanged
         Dim index As Integer = _listFusionImages.SelectedIndex
         If index = -1 Then
            Return
         End If

         Dim Num As Integer
         Dim isNum As Boolean = Integer.TryParse(_txtWeight.Text, Num)

         If (Not isNum) Then
            _txtWeight.Text = _weightList(index).ToString()
         Else
            If _txtWeight.Text = "" Then
               _weightList(index) = 0
            Else
               _weightList(index) = Math.Min(100, Convert.ToInt32(_txtWeight.Text))
            End If

            _trackBarWeight.Value = _weightList(index)
            _cell.SubCells(_cell.ActiveSubCell).Fusion(index).FusionScale = _weightList(index) / 100.0F
            _cell.Invalidate()
         End If

      End Sub

      Private Sub _trackBarWeight_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _trackBarWeight.Scroll
         _txtWeight.Text = _trackBarWeight.Value.ToString()
      End Sub
   End Class
End Namespace
