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
Imports Leadtools.Annotations

Namespace DicomAnonymizer
   Partial Class ViewImageDialog : Inherits Form
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

      Public ReadOnly Property Cell() As MedicalViewerCell
         Get
            Return TryCast(_MedicalViewer.Cells(0), MedicalViewerCell)
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
            Dim cell_Renamed As MedicalViewerCell = New MedicalViewerCell()

            cell_Renamed.AddAction(MedicalViewerActionType.Stack)
            cell_Renamed.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)
            cell_Renamed.AddAction(MedicalViewerActionType.WindowLevel)
            cell_Renamed.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
            cell_Renamed.AddAction(MedicalViewerActionType.Scale)
            cell_Renamed.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)

            _MedicalViewer = New MedicalViewer(1, 1)
            _MedicalViewer.Dock = DockStyle.Fill
            _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None
            _MedicalViewer.Cells.Add(cell_Renamed)
            _MedicalViewer.Dock = DockStyle.Fill
            _MedicalViewer.BringToFront()
            panelViewer.Controls.Add(_MedicalViewer)
         Catch e As Exception
            Messager.ShowError(Me, e)
            Close()
         End Try
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
            Thread.Sleep(0)
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
            Cell.Selected = True
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
      End Sub

      Private Sub ViewDatasetDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
         Cursor.Current = Cursors.WaitCursor
         loaderThread = New Thread(New ParameterizedThreadStart(AddressOf LoadImage))
         loaderThread.Start(Dataset)
         _MedicalViewer.Focus()
      End Sub
   End Class
End Namespace
