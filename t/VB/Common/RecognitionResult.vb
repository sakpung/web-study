' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Forms.Recognition
Imports Leadtools.Forms.Processing
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls

Imports Leadtools.Drawing

Namespace FormsDemo
   Partial Public Class RecognitionResult : Inherits Form
      Private _filledForms As List(Of FilledForm)
      Private annAutomationManager As AnnAutomationManager = Nothing
      Private _annotationsHelper As AutomationManagerHelper = Nothing
      Private automation As AnnAutomation = Nothing
      Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode
      Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode

      Public Sub New(filledForms As List(Of FilledForm))
         InitializeComponent()
         _filledForms = filledForms
         _cmbSelectedForm.Items.Clear()

         For i As Integer = 0 To _filledForms.Count - 1
            _cmbSelectedForm.Items.Add(_filledForms(i).Name)
         Next

         _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()

         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left

         _panInteractiveMode.IdleCursor = Cursors.Hand
         _panInteractiveMode.IdleCursor = Cursors.Hand
         _zoomToInteractiveMode.IdleCursor = Cursors.Cross
         _zoomToInteractiveMode.IdleCursor = Cursors.Cross
         _filledFormViewer.InteractiveModes.BeginUpdate()
         _fieldViewer.InteractiveModes.BeginUpdate()
         _filledFormViewer.InteractiveModes.Add(_panInteractiveMode)
         _filledFormViewer.InteractiveModes.Add(_zoomToInteractiveMode)
         _fieldViewer.InteractiveModes.Add(_panInteractiveMode)
         _fieldViewer.InteractiveModes.Add(_zoomToInteractiveMode)
         _filledFormViewer.InteractiveModes.EndUpdate()
         _fieldViewer.InteractiveModes.EndUpdate()

      End Sub

      Private Sub DisableInteactiveMode(viewer As Boolean)
         If (viewer) Then
            For Each mode As ImageViewerInteractiveMode In _filledFormViewer.InteractiveModes
               mode.IsEnabled = False
            Next mode
         Else
            For Each mode As ImageViewerInteractiveMode In _fieldViewer.InteractiveModes
               mode.IsEnabled = False
            Next mode
         End If
      End Sub
      Protected Overrides Sub Finalize()
         Try
            If automation IsNot Nothing Then
               automation = Nothing
            End If

            If annAutomationManager IsNot Nothing Then
               annAutomationManager = Nothing
            End If
         Finally
            MyBase.Finalize()
         End Try
      End Sub

      Private Sub SetupAnnotations()
         ' create and setup the automation manager
         annAutomationManager = New AnnAutomationManager()
         _annotationsHelper = New AutomationManagerHelper(annAutomationManager)
         annAutomationManager.CreateDefaultObjects()
         'Run mode to prevent editing of annotations
         annAutomationManager.UserMode = AnnUserMode.Run

         'Create dummy image to init automation
         Dim img As New RasterImage(RasterMemoryFlags.Conventional, 1, 1, 1, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, _
          Nothing, IntPtr.Zero, 0)
         img.XResolution = 150
         img.YResolution = 150
         _filledFormViewer.Image = img

         automation = New AnnAutomation(annAutomationManager, _filledFormViewer)
         automation.Active = True
         _filledFormViewer.Image = Nothing
      End Sub

      Private Sub UpdateControls()
         If _fieldResults.SelectedRows.Count <> 1 Then
            _fieldViewer.Image = Nothing
            _fieldViewerToobar.Enabled = False
         End If
      End Sub

      Private Sub _cmbSelectedForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbSelectedForm.SelectedIndexChanged
         Try
            _cmbSelectedPage.Items.Clear()

            For i As Integer = 0 To _filledForms(_cmbSelectedForm.SelectedIndex).Image.PageCount - 1
               _cmbSelectedPage.Items.Add((i + 1).ToString())
            Next

            _txtMasterForm.Text = _filledForms(_cmbSelectedForm.SelectedIndex).Master.Properties.Name
            _txtFormConficence.Text = _filledForms(_cmbSelectedForm.SelectedIndex).Result.Confidence.ToString() & "%"

            _cmbSelectedPage.SelectedIndex = 0
            UpdateControls()
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Function GetDataString(data As Byte()) As String
         Dim result As String = String.Empty

         For i As Integer = 0 To data.Length - 1
            result = result & System.Convert.ToChar(data(i)).ToString()
         Next

         Return result
      End Function

      Private Sub _cmbSelectedPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbSelectedPage.SelectedIndexChanged
         Try
            If _filledFormViewer.Image IsNot Nothing Then
               _filledFormViewer.Image.Dispose()
            End If

            'If the user chose to only recognize the first page, there will only be a recognition confidence value for the first page
            If _filledForms(_cmbSelectedForm.SelectedIndex).Result.PageResults.Count < _cmbSelectedPage.Items.Count Then
               _txtPageConfidence.Enabled = False
               _txtPageConfidence.Text = ""
            Else
               _txtPageConfidence.Enabled = True
               _txtPageConfidence.Text = _filledForms(_cmbSelectedForm.SelectedIndex).Result.PageResults(_cmbSelectedPage.SelectedIndex).Confidence.ToString() & "%"
            End If


            _filledForms(_cmbSelectedForm.SelectedIndex).Image.Page = _cmbSelectedPage.SelectedIndex + 1
            _filledFormViewer.Image = _filledForms(_cmbSelectedForm.SelectedIndex).Image.Clone()

            _fieldResults.Rows.Clear()

            If _filledForms(_cmbSelectedForm.SelectedIndex).ProcessingPages IsNot Nothing AndAlso _filledForms(_cmbSelectedForm.SelectedIndex).ProcessingPages.Count > _cmbSelectedPage.SelectedIndex Then
               For Each field As FormField In _filledForms(_cmbSelectedForm.SelectedIndex).ProcessingPages(_cmbSelectedPage.SelectedIndex)
                  Dim row As String() = New String(4) {}
                  row(0) = field.Name

                  Dim alignedBounds As LeadRect = LeadRect.Empty

                  If TypeOf field Is TableFormField Then
                     Dim tableField As TableFormField = TryCast(field, TableFormField)
                     Dim pageIndex As Integer = tableField.ExpectedPages.IndexOf(_cmbSelectedPage.SelectedIndex)
                     If tableField.PagesBounds.ContainsKey(pageIndex) Then
                        alignedBounds = tableField.PagesBounds(pageIndex)
                     Else
                        alignedBounds = LeadRect.Empty
                     End If
                  ElseIf TypeOf field Is UnStructuredTextFormField Then
                            alignedBounds = field.Bounds
                        ElseIf TypeOf field Is OmrFormField Then
                            alignedBounds = _filledForms(_cmbSelectedForm.SelectedIndex).Alignment(field.MasterPageNumber - 1).AlignOmrRectangle(field.Bounds)
                  Else
                            alignedBounds = _filledForms(_cmbSelectedForm.SelectedIndex).Alignment(field.MasterPageNumber - 1).AlignRectangle(field.Bounds)
                  End If


                  row(4) = alignedBounds.ToString()

                  Dim bAdded As Boolean = True

                  If field.Result IsNot Nothing Then
							If TypeOf field Is TextFormField Then
								row(1) = "Text"
								row(2) = TryCast(TryCast(field, TextFormField).Result, TextFormFieldResult).Text
								row(3) = TryCast(TryCast(field, TextFormField).Result, TextFormFieldResult).AverageConfidence.ToString()
							ElseIf TypeOf field Is UnStructuredTextFormField Then
								row(1) = "Unstructured Text"
                        row(2) = TryCast(TryCast(field, UnStructuredTextFormField).Result, TextFormFieldResult).Text
                        row(3) = TryCast(TryCast(field, UnStructuredTextFormField).Result, TextFormFieldResult).AverageConfidence.ToString()
                     ElseIf TypeOf field Is OmrFormField Then
                        row(1) = "Omr"
                        row(2) = TryCast(TryCast(field, OmrFormField).Result, OmrFormFieldResult).Text
                        row(3) = TryCast(TryCast(field, OmrFormField).Result, OmrFormFieldResult).AverageConfidence.ToString()
                     ElseIf TypeOf field Is BarcodeFormField Then
                        row(1) = "Barcode"
                        For i As Integer = 0 To TryCast(TryCast(field, BarcodeFormField).Result, BarcodeFormFieldResult).BarcodeData.Count - 1
                           row(2) = GetDataString(TryCast(TryCast(field, BarcodeFormField).Result, BarcodeFormFieldResult).BarcodeData(i).GetData())
                        Next

                        row(3) = "N/A"
                     ElseIf TypeOf field Is ImageFormField Then
                        row(1) = "Image"
                        row(2) = "N/A"
                        row(3) = "N/A"
                     ElseIf TypeOf field Is TableFormField Then
                        row(1) = "Table"
                                row(2) = "Double click here to see the results..."
                        row(3) = "N/A"
                     End If
                  End If

                  If bAdded Then
                            _fieldResults.Rows.Add(row)
                        End If
                        If TypeOf field Is TableFormField Then

                            _fieldResults.Rows(_fieldResults.Rows.Count - 1).Cells(2).Style.ForeColor = Color.Blue
                        End If
                    Next

               If _fieldResults.Rows.Count > 0 Then
                  _fieldResults.Rows(0).Selected = True
               End If
            End If
            UpdateControls()
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub AddHighlight(highlightBounds As Rectangle)
         Dim annotationField As New AnnHiliteObject()
         annotationField.HiliteColor = "Yellow"
         automation.Container.Children.Add(annotationField)
         'Now we can calculate the object bounds correctly
         Dim rc As RectangleF = RectangleF.FromLTRB(highlightBounds.Left, highlightBounds.Top, highlightBounds.Right, highlightBounds.Bottom)
         Dim rect As LeadRectD = BoundsToAnnotations(annotationField, rc)
         annotationField.Rect = rect
      End Sub

      Private Function BoundsToAnnotations(annObject As AnnObject, rect As RectangleF) As LeadRectD
         ' Convert a rectangle from logical (top-left) to annotation object coordinates
         Dim rc As LeadRectD
         rc = LeadRectD.Create(rect.Left + System.Convert.ToDouble(rect.Width < 0) * rect.Width, rect.Top + System.Convert.ToDouble(rect.Height < 0) * rect.Height, Math.Abs(rect.Width), Math.Abs(rect.Height))
         rc = _filledFormViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc)
         rc = automation.Container.Mapper.RectToContainerCoordinates(rc)
         Return rc

      End Function

      Private Sub _fieldResults_SelectionChanged(sender As Object, e As EventArgs) Handles _fieldResults.SelectionChanged
         Try
            'clear annotations
            automation.SelectObjects(Nothing)
            automation.Container.Children.Clear()

            If _fieldResults.Rows.Count > 0 AndAlso _fieldResults.SelectedRows.Count > 0 Then
               If _fieldViewer.Image IsNot Nothing Then
                  _fieldViewer.Image.Dispose()
               End If

               Dim formIndex As Integer = _cmbSelectedForm.SelectedIndex
               Dim pageIndex As Integer = _cmbSelectedPage.SelectedIndex
               Dim fieldIndex As Integer = _fieldResults.SelectedRows(0).Index

               _filledForms(_cmbSelectedForm.SelectedIndex).Image.Page = _cmbSelectedPage.SelectedIndex + 1
               Dim tempRect As LeadRect = LeadRect.Empty
               Dim field As FormField = _filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex)
               If TypeOf field Is TableFormField Then
                  Dim tableField As TableFormField = TryCast(field, TableFormField)
                  Dim expectedPageIndex As Integer = -1
                  If tableField.ExpectedPages.Contains(pageIndex) Then
                     expectedPageIndex = tableField.ExpectedPages.IndexOf(pageIndex)
                  End If

                  If tableField.PagesBounds.ContainsKey(expectedPageIndex) Then
                     tempRect = tableField.PagesBounds(expectedPageIndex)
                  ElseIf TypeOf field Is UnStructuredTextFormField Then
                     tempRect = field.Bounds
                  Else
                     tempRect = LeadRect.Empty

                        End If
                    ElseIf TypeOf field Is OmrFormField Then
                        tempRect = _filledForms(_cmbSelectedForm.SelectedIndex).Alignment(field.MasterPageNumber - 1).AlignOmrRectangle(field.Bounds)
               Else
                  tempRect = _filledForms(_cmbSelectedForm.SelectedIndex).Alignment(field.MasterPageNumber - 1).AlignRectangle(field.Bounds)
               End If

               Dim alignedRect As Rectangle = Leadtools.Demos.Converters.ConvertRect(_filledForms(formIndex).Image.RectangleToImage(RasterViewPerspective.TopLeft, tempRect))
               If Not alignedRect.IsEmpty Then
                  _fieldViewer.Image = _filledForms(formIndex).Image.Clone(Leadtools.Demos.Converters.ConvertRect(alignedRect))
               Else
                  _fieldViewer.Image = Nothing
               End If
               AddHighlight(alignedRect)

               'Ensure field is visible
               Dim LeadImageMatrix As LeadMatrix
               LeadImageMatrix = _filledFormViewer.ImageTransform
               Dim m As System.Drawing.Drawing2D.Matrix
               m = New System.Drawing.Drawing2D.Matrix(Convert.ToSingle(LeadImageMatrix.M11), Convert.ToSingle(LeadImageMatrix.M12), Convert.ToSingle(LeadImageMatrix.M21), Convert.ToSingle(LeadImageMatrix.M22), Convert.ToSingle(LeadImageMatrix.OffsetX), Convert.ToSingle(LeadImageMatrix.OffsetY))

               Dim transformer As New Transformer(m)
               Dim location As PointF = transformer.PointToPhysical(alignedRect.Location)
               _filledFormViewer.CenterAtPoint(LeadPoint.Create(Convert.ToInt32(location.X), Convert.ToInt32(location.Y)))

               UpdateControls()
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub RecognitionResult_Load(sender As Object, e As EventArgs) Handles Me.Load
         SetupAnnotations()
         Dim properties As RasterPaintProperties = RasterPaintProperties.[Default]
         properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic Or RasterPaintDisplayModeFlags.ScaleToGray
         properties.PaintEngine = RasterPaintEngine.Gdi
         properties.UsePaintPalette = True
         _fieldViewer.PaintProperties = properties
         _fieldViewer.UseDpi = False
         DisableInteactiveMode(False)
         _fieldViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)
         _filledFormViewer.PaintProperties = properties
         _filledFormViewer.UseDpi = False
         DisableInteactiveMode(True)
         _filledFormViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)
         _cmbSelectedForm.SelectedIndex = 0
         UpdateControls()
      End Sub

      Private Sub _btnFormPan_Click(sender As Object, e As EventArgs) Handles _btnFormPan.Click
         DisableInteactiveMode(True)
         _filledFormViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)
         _btnFormZoomRect.Checked = Not _btnFormPan.Checked
      End Sub

      Private Sub _btnFieldPan_Click(sender As Object, e As EventArgs) Handles _btnFieldPan.Click
         DisableInteactiveMode(False)
         _fieldViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)
         _btnFieldZoomRect.Checked = Not _btnFieldPan.Checked
      End Sub

      Private Sub _btnFormZoomRect_Click(sender As Object, e As EventArgs) Handles _btnFormZoomRect.Click
         DisableInteactiveMode(True)
         _filledFormViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
         _btnFormPan.Checked = Not _btnFormZoomRect.Checked
      End Sub

      Private Sub _btnFieldZoomRect_Click(sender As Object, e As EventArgs) Handles _btnFieldZoomRect.Click
         DisableInteactiveMode(False)
         _fieldViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
         _btnFieldPan.Checked = Not _btnFieldZoomRect.Checked
      End Sub

      Private Sub _btnFormZoomNormal_Click(sender As Object, e As EventArgs) Handles _btnFormZoomNormal.Click
         Try
            _filledFormViewer.Zoom(ControlSizeMode.ActualSize, 1, _filledFormViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFieldZoomNormal_Click(sender As Object, e As EventArgs) Handles _btnFieldZoomNormal.Click
         Try
            _fieldViewer.Zoom(ControlSizeMode.ActualSize, 1, _filledFormViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFormZoomIn_Click(sender As Object, e As EventArgs) Handles _btnFormZoomIn.Click
         Try
            Dim oldScaleFactor As Double = _filledFormViewer.ScaleFactor
            _filledFormViewer.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1F, _filledFormViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFieldZoomIn_Click(sender As Object, e As EventArgs) Handles _btnFieldZoomIn.Click
         Try
            Dim oldScaleFactor As Double = _fieldViewer.ScaleFactor
            _fieldViewer.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1F, _fieldViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFormZoomOut_Click(sender As Object, e As EventArgs) Handles _btnFormZoomOut.Click
         Try
            If _filledFormViewer.ScaleFactor > 0.1F Then
               Dim oldScaleFactor As Double = _filledFormViewer.ScaleFactor
               _filledFormViewer.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1F, _filledFormViewer.DefaultZoomOrigin)
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFieldZoomOut_Click(sender As Object, e As EventArgs) Handles _btnFieldZoomOut.Click
         Try
            If _fieldViewer.ScaleFactor > 0.1F Then
               Dim oldScaleFactor As Double = _fieldViewer.ScaleFactor
               _fieldViewer.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1F, _fieldViewer.DefaultZoomOrigin)
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFormFit_Click(sender As Object, e As EventArgs) Handles _btnFormFit.Click
         Try
            _filledFormViewer.Zoom(ControlSizeMode.FitAlways, 1, _filledFormViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFieldFit_Click(sender As Object, e As EventArgs) Handles _btnFieldFit.Click
         Try
            _fieldViewer.Zoom(ControlSizeMode.FitAlways, 1, _fieldViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFormFitWidth_Click(sender As Object, e As EventArgs) Handles _btnFormFitWidth.Click
         Try
            _filledFormViewer.Zoom(ControlSizeMode.FitWidth, 1, _filledFormViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _btnFieldFitWidth_Click(sender As Object, e As EventArgs) Handles _btnFieldFitWidth.Click
         Try
            _fieldViewer.Zoom(ControlSizeMode.FitWidth, 1, _fieldViewer.DefaultZoomOrigin)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub _fieldResults_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles _fieldResults.MouseDoubleClick
         Try
            If _fieldResults.Rows.Count > 0 AndAlso _fieldResults.SelectedRows.Count = 1 Then
               Dim formIndex As Integer = _cmbSelectedForm.SelectedIndex
               Dim pageIndex As Integer = _cmbSelectedPage.SelectedIndex
               Dim fieldIndex As Integer = _fieldResults.SelectedRows(0).Index

               If TypeOf _filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex) Is TextFormField OrElse TypeOf _filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex) Is OmrFormField OrElse TypeOf _filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex) Is UnStructuredTextFormField Then
                  Dim detailedResultsdialog As New DetailedCharacterResults(_filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex))
                  detailedResultsdialog.ShowDialog(Me)
               ElseIf TypeOf _filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex) Is TableFormField Then
                  Dim tableField As TableFormField = TryCast(_filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex), TableFormField)
                  If tableField.Result.Status = FormFieldStatus.Success Then
                     Dim detailedResultsdialog As New DetailedTableResults(TryCast(_filledForms(formIndex).ProcessingPages(pageIndex)(fieldIndex), TableFormField))
                     detailedResultsdialog.ShowDialog(Me)
                  Else
                     MessageBox.Show("Table failed to recognize")
                  End If
               End If
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub
   End Class
End Namespace
