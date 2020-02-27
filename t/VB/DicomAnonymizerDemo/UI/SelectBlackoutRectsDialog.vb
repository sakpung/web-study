' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom.Common.Editing.Controls
Imports Leadtools.Dicom
Imports Leadtools.MedicalViewer
Imports Leadtools.Dicom.Common.Editing
Imports System.Threading
Imports System.Reflection
Imports System.Diagnostics
Imports Leadtools
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers

Namespace DicomAnonymizer
   Partial Class SelectBlackoutRectsDialog : Inherits Form
      Private _MedicalViewer As MedicalViewer
      Private loaderThread As Thread

      Private _Dataset As DicomDataSet

      Public Property Dataset() As DicomDataSet
         Get
            Return _Dataset
         End Get
         Set(ByVal value As DicomDataSet)
            _Dataset = value
         End Set
      End Property

      Private _BlackoutRects As List(Of LeadRect) = New List(Of LeadRect)()

      Public ReadOnly Property BlackoutRects() As List(Of LeadRect)
         Get
            Return _BlackoutRects
         End Get
      End Property

      Public ReadOnly Property Cell() As MedicalViewerMultiCell
         Get
            Return TryCast(_MedicalViewer.Cells(0), MedicalViewerMultiCell)
         End Get
      End Property

      Public Sub New()
         Cursor.Current = Cursors.WaitCursor
         InitializeComponent()
         For i As Integer = 0 To 1
            Try
               InitializeMedicalViewer()
               Exit For
            Catch e As Exception
               If i = 1 Then
                  MessageBox.Show(e.Message)
               End If
            End Try
         Next i
         SetAppIcon()
      End Sub

      Private Sub SetAppIcon()
         Try
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().Location)
         Catch
         End Try
      End Sub

      Public Sub New(ByVal ds As DicomDataSet)
         Me.New()
         Dataset = ds
      End Sub

      Private Sub InitializeMedicalViewer()
         Try
            Dim cell_Renamed As MedicalViewerMultiCell = New MedicalViewerMultiCell()

            Cell.KeepDrawingAnnotation = True

            cell_Renamed.AddAction(MedicalViewerActionType.Stack)
            cell_Renamed.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)
            cell_Renamed.AddAction(MedicalViewerActionType.AnnotationRedaction)
            cell_Renamed.SetAction(MedicalViewerActionType.AnnotationRedaction, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            cell_Renamed.AddAction(MedicalViewerActionType.Scale)
            cell_Renamed.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
            AddHandler cell_Renamed.AnnotationCreated, AddressOf cell_AnnotationCreated
            AddHandler cell_Renamed.DesignerCreated, AddressOf cell_DesignerCreated

            _MedicalViewer = New MedicalViewer(1, 1)
            _MedicalViewer.Dock = DockStyle.Fill
            _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None
            _MedicalViewer.Cells.Add(cell_Renamed)
            _MedicalViewer.Dock = DockStyle.Fill
            panelView.Controls.Add(_MedicalViewer)
         Catch e As Exception
            Messager.ShowError(Me, e)
            Close()
         End Try
      End Sub

      Private _Container As AnnContainer

      Private Function GetContainer(cell As MedicalViewerMultiCell, annotationObject As AnnObject) As AnnContainer

         Dim index As Integer = 0
         Dim length As Integer = Cell.SubCells.Count

         Dim container As AnnContainer

         For index = 0 To length - 1

            container = cell.SubCells(index).AnnotationContainer

            If Not container.Children.IndexOf(annotationObject) = -1 Then
               Return container
            End If

         Next index
         Return Nothing
      End Function

      Private Sub cell_AnnotationCreated(ByVal sender As Object, ByVal e As MedicalViewerAnnotationCreatedEventArgs)
         Dim rectangle As AnnRectangleObject = TryCast(e.Object, AnnRectangleObject)

         rectangle.RotateGripper = New LeadLengthD()
         _Container = GetContainer(TryCast(sender, MedicalViewerMultiCell), rectangle)

         Dim i As Integer = 0
         Do While i < Cell.SubCells.Count
            Dim container As AnnContainer = Cell.SubCells(i).AnnotationContainer

            If Not container Is Nothing AndAlso Not container Is _Container Then
               container.Children.Add(rectangle)
            End If
            i += 1
         Loop
      End Sub

      Private Sub cell_DesignerCreated(ByVal sender As Object, ByVal e As MedicalViewerDesignerCreatedEventArgs)
         If TypeOf e.Designer Is AnnRectangleEditDesigner Then
            Dim designer As AnnRectangleEditDesigner = TryCast(e.Designer, AnnRectangleEditDesigner)

            AddHandler designer.Edit, AddressOf designer_Edit
         End If
      End Sub

      Private Sub designer_Edit(ByVal sender As Object, ByVal e As AnnEditDesignerEventArgs)
         If (e.Operation = AnnEditDesignerOperation.Rotate Or e.Operation = AnnEditDesignerOperation.MoveRotateCenterThumb Or e.Operation = AnnEditDesignerOperation.MoveRotateCenterThumb) And e.OperationStatus = AnnDesignerOperationStatus.Start Then
            e.Cancel = True
         End If
      End Sub

      Private Sub LoadImage(ByVal data As Object)
         Dim ds As DicomDataSet = TryCast(data, DicomDataSet)
         Dim count As Integer = 0
         Dim image As RasterImage = Nothing

         If Dataset Is Nothing Then
            Cell.Image = Nothing
            Return
         End If

         count = ds.GetImageCount(Nothing)
         SetLoadProgress(count > 0, count)
         Dim i As Integer = 0
         Do While i < count
            Dim img As RasterImage = ds.GetImage(Nothing, i, 0, RasterByteOrder.Rgb Or RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut)

            If image Is Nothing Then
               image = img.Clone()
            Else
               image.AddPage(img)
            End If
            SetProgressValue(i + 1)
            Thread.Sleep(100)
            i += 1
         Loop

         SetCellImage(image)
      End Sub

      Private Delegate Sub SetCellImageDelegate(ByVal image As RasterImage)

      Private Sub SetCellImage(ByVal image As RasterImage)
         If InvokeRequired Then
            Invoke(New SetCellImageDelegate(AddressOf SetCellImage), image)
         Else
            If image Is Nothing Then
               Cell.Image = Nothing
               Return
            End If

            SetLoadProgress(False, 0)
            Cell.Image = image
            Cell.FitImageToCell = True
            If image.PageCount = 1 Then
               Cell.RemoveAction(MedicalViewerActionType.Stack)
            End If
         End If
      End Sub

      Private Delegate Sub SetLoadProgressDelegate(ByVal view As Boolean, ByVal count As Integer)

      Private Sub SetLoadProgress(ByVal view As Boolean, ByVal count As Integer)
         If InvokeRequired Then
            Invoke(New SetLoadProgressDelegate(AddressOf SetLoadProgress), view, count)
         Else
            labelLoadInfo.Visible = view
            progressBarLoad.Visible = view
            If view Then
               progressBarLoad.Maximum = count
            End If
            Application.DoEvents()
         End If
      End Sub

      Private Delegate Sub SetProgressValueDelegate(ByVal value As Integer)

      Private Sub SetProgressValue(ByVal value As Integer)
         If InvokeRequired Then
            Invoke(New SetProgressValueDelegate(AddressOf SetProgressValue), value)
         Else
            progressBarLoad.Value = value
            Application.DoEvents()
         End If
      End Sub

      Private Function CellHasImage() As Boolean
         Return Not Cell.Image Is Nothing
      End Function

      Private Sub ViewDatasetDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If Not loaderThread Is Nothing Then
            loaderThread.Abort()
         End If

         If DialogResult = System.Windows.Forms.DialogResult.OK Then
            Dim container As AnnContainer = Cell.GetAnnotationContainer()

            For Each rectangle As AnnRectangleObject In container.Children
               Dim imageRectangle As AnnRectangleObject = New AnnRectangleObject(container.Mapper.RectFromContainerCoordinates(rectangle.Bounds, AnnFixedStateOperations.None))

               _BlackoutRects.Add(New LeadRect(CInt(imageRectangle.Bounds.Left), CInt(imageRectangle.Bounds.Top), CInt(imageRectangle.Bounds.Width), CInt(imageRectangle.Bounds.Height)))
            Next rectangle
         End If
      End Sub

      Private Sub ViewDatasetDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
         Cursor.Current = Cursors.WaitCursor
         loaderThread = New Thread(New ParameterizedThreadStart(AddressOf LoadImage))
         loaderThread.Start(Dataset)
      End Sub
   End Class
End Namespace
