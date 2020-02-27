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
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Controls

Partial Public Class PerspectiveDialog : Inherits Form
   Private _viewer As ImageViewer
   Private _form As ViewerControl
   Private _mainForm As MainForm
   Private _polyPoints As List(Of Point)
   Private _lastPoint As Point
   Private _currentMousePoint As Point
   Private _firstPointSelected As Boolean
   Private _drawing As Boolean
   Private _applied As Boolean
   Private _movingPntIdx As Integer
   Private _orgImage As RasterImage

   Public Sub New(ByVal form As MainForm, ByVal viewer As ViewerControl)
      _mainForm = form
      _form = viewer
      _viewer = viewer.RasterImageViewer
      InitializeComponent()
   End Sub

   Private Sub PerspectiveDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      AddHandler _viewer.PostRender, AddressOf _viewer_PostRender
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp

      _polyPoints = New List(Of Point)()
      _firstPointSelected = False
      _drawing = True
      _applied = False
      _movingPntIdx = -1
      _orgImage = _viewer.Image.Clone()
      _btnApply.Enabled = False
      _btnReset.Enabled = False

      _numSecondPtX.Maximum = _viewer.Image.Width - 1
      _numThirdPtX.Maximum = _viewer.Image.Width - 1
      _numFourthPtX.Maximum = _viewer.Image.Width - 1
      _numFirstPtX.Maximum = _viewer.Image.Width - 1

      _numFirstPtY.Maximum = _viewer.Image.Height - 1
      _numFourthPtY.Maximum = _viewer.Image.Height - 1
      _numSecondPtY.Maximum = _viewer.Image.Height - 1
      _numThirdPtY.Maximum = _viewer.Image.Height - 1

      Try
         If Not _viewer.Floater Is Nothing Then
            _viewer.Floater.Dispose()
            _viewer.Floater = Nothing
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))
      If _viewer.ImageBounds.Contains(pixels.X, pixels.Y) Then
         If e.Button = MouseButtons.Left Then
            _movingPntIdx = -1
         End If
      End If
   End Sub

   Private Function CreateRectFromPoint(ByVal point As Point, ByVal size As Integer) As Rectangle
      Return New Rectangle(point.X - size, point.Y - size, size * 2, size * 2)
   End Function

   Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))
      If _viewer.ImageBounds.Contains(pixels.X, pixels.Y) Then
         If e.Button = MouseButtons.Left Then
            Dim xFactor As Double = 1
            Dim yFactor As Double = 1

            Dim xOffset As Integer = 0
            Dim yOffset As Integer = 0

            Dim pnt As Point = New Point(CInt((pixels.X - xOffset) * 1.0 / xFactor + 0.5), CInt((pixels.Y - yOffset) * 1.0 / yFactor + 0.5))

            _movingPntIdx = -1

            If (Not _drawing) Then
               Dim hyberAreas As Rectangle() = New Rectangle(_polyPoints.Count - 1) {}
               Dim idx As Integer = 0
               Do While idx < hyberAreas.Length
                  hyberAreas(idx) = CreateRectFromPoint(_polyPoints(idx), 5)
                  If hyberAreas(idx).Contains(pnt) Then
                     _movingPntIdx = idx
                     Exit Do
                  End If
                  idx += 1
               Loop
            End If

            If _movingPntIdx = -1 Then
               If _polyPoints.Count < 4 Then
                  If pnt.Equals(_lastPoint) Then
                     Return
                  End If
                  _firstPointSelected = True
                  _polyPoints.Add(pnt)
                  _currentMousePoint = pnt
                  UpdateDialogPoints(_polyPoints.Count - 1, pnt)
                  _lastPoint = pnt
               End If

               If _polyPoints.Count = 4 Then
                  _drawing = False
                  _viewer.Invalidate()
                  _btnApply.Enabled = True
               End If
            End If

         End If
      End If
   End Sub

   Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim xFactor As Double = 1
      Dim yFactor As Double = 1

      Dim xOffset As Integer = 0
      Dim yOffset As Integer = 0
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))

      Dim pnt As Point = New Point(CInt((pixels.X - xOffset) * 1.0 / xFactor + 0.5), CInt((pixels.Y - yOffset) * 1.0 / yFactor + 0.5))
      If _viewer.ImageBounds.Contains(pixels.X, pixels.Y) Then
         _viewer.Cursor = Cursors.Cross

         If _firstPointSelected Then
            _currentMousePoint = pnt
         End If

         If _movingPntIdx <> -1 Then
            _polyPoints.RemoveAt(_movingPntIdx)
            _polyPoints.Insert(_movingPntIdx, pnt)
            UpdateDialogPoints(_movingPntIdx, pnt)
         End If
         _viewer.Invalidate()
      End If
      _txtCursorX.Text = pnt.X.ToString()
      _txtCursorY.Text = pnt.Y.ToString()
   End Sub

   Private Sub _viewer_PostRender(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
      If _firstPointSelected Then
         Dim xFactor As Double = _viewer.XScaleFactor
         Dim yFactor As Double = _viewer.YScaleFactor
         Dim xOffset As Single = -_viewer.ImageBounds.Left
         Dim yOffset As Single = -_viewer.ImageBounds.Top

         Dim drawPoints As Point() = New Point(_polyPoints.Count - 1) {}

         Dim idx As Integer = 0
         Do While idx < drawPoints.Length
            Dim TempPoint As LeadPointD = New LeadPointD(_polyPoints(idx).X, _polyPoints(idx).Y)
            TempPoint = _viewer.ImageTransform.Transform(TempPoint)
            drawPoints(idx) = New Point(CInt(TempPoint.X), CInt(TempPoint.Y))
            idx += 1
         Loop

         Dim _lastPointTemp As LeadPointD = New LeadPointD(_lastPoint.X, _lastPoint.Y)
         _lastPointTemp = _viewer.ImageTransform.Transform(_lastPointTemp)
         Dim lastPoint As Point = New Point(CInt(_lastPointTemp.X), CInt(_lastPointTemp.Y))
         Dim _currentMousePointTemp As LeadPointD = New LeadPointD(_currentMousePoint.X, _currentMousePoint.Y)
         _currentMousePointTemp = _viewer.ImageTransform.Transform(_currentMousePointTemp)
         Dim currentMousePoint As Point = New Point(CInt(_currentMousePointTemp.X), CInt(_currentMousePointTemp.Y))

         Dim size As Integer = 3
         e.PaintEventArgs.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(drawPoints(0), size))
         Dim i As Integer = 1
         Do While i < drawPoints.Length
            Dim prev As Point = drawPoints(i - 1)
            Dim curnt As Point = drawPoints(i)
            e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, prev, curnt)
            If (Not _drawing) Then
               e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, drawPoints(0), drawPoints(drawPoints.Length - 1))
            End If

            e.PaintEventArgs.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(prev, size))
            e.PaintEventArgs.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(curnt, size))
            i += 1
         Loop

         If _drawing AndAlso drawPoints.Length < 4 Then
            e.PaintEventArgs.Graphics.DrawLine(Pens.Green, lastPoint, currentMousePoint)
         End If
      End If
   End Sub

   Private Sub ApplyFilter()
      If _polyPoints.Count = 4 AndAlso _firstPointSelected Then
         _applied = True
         Dim PolyPoints As LeadPoint() = New LeadPoint(3) {}
         For i As Integer = 0 To 3
            PolyPoints(i).X = _polyPoints(i).X
            PolyPoints(i).Y = _polyPoints(i).Y
         Next i

         _viewer.Image.MakeRegionEmpty()

         Dim command As KeyStoneCommand = New KeyStoneCommand(PolyPoints)
         Try
            command.Run(_viewer.Image)
         Catch ex As System.Exception
            Messager.ShowError(Me, ex)
            Return
         End Try

         _viewer.Cursor = Cursors.Default
#If Not LEADTOOLS_V20_OR_LATER Then
         If Not command.TransformedBitmap Is Nothing Then
            _viewer.Image = command.TransformedBitmap.Clone()
         End If
#Else
         If Not command.TransformedImage Is Nothing Then
            _viewer.Image = command.TransformedImage.Clone()
         End If
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

         _viewer.Invalidate()
         _form.Invalidate()
         _firstPointSelected = False
         _btnReset.Enabled = True
         _btnApply.Enabled = False

      End If
   End Sub

   Private Sub _bntApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
      ApplyFilter()
   End Sub

   Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
      ApplyFilter()
      _form._viewerRegion = False
      _mainForm.SetDocument(_viewer.Image, _mainForm.Text)
      _mainForm.DoClearAllBarcodes()
      Me.Close()
   End Sub

   Private Sub PerspectiveDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
      RemoveHandler _viewer.PostRender, AddressOf _viewer_PostRender
      RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      _viewer.Cursor = Cursors.Default
      _viewer.Invalidate()
      _form.Invalidate()
      MainForm.InversePerspectiveActive = False
      _mainForm._enableMenus()
      _mainForm.InteractiveToolsList.Remove(_viewer)
   End Sub

   Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
      If (Not _firstPointSelected) AndAlso _polyPoints.Count = 4 Then
         _firstPointSelected = True
         _viewer.Image = _orgImage.Clone()
         _btnApply.Enabled = True
         _btnReset.Enabled = False
      End If

   End Sub

   Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
      If _applied Then
         _viewer.Image = _orgImage.Clone()
         _mainForm.SetDocument(_viewer.Image, _mainForm.Text)
         _mainForm.DoClearAllBarcodes()
      End If
      Me.Close()
   End Sub

   Private Sub UpdateDialogPoints(ByVal pointIndex As Integer, ByVal pt As Point)
      Select Case pointIndex
         Case 0
            _numFirstPtX.Value = pt.X
            _numFirstPtY.Value = pt.Y
         Case 1
            _numSecondPtX.Value = pt.X
            _numSecondPtY.Value = pt.Y
         Case 2
            _numThirdPtX.Value = pt.X
            _numThirdPtY.Value = pt.Y
         Case 3
            _numFourthPtX.Value = pt.X
            _numFourthPtY.Value = pt.Y
      End Select
   End Sub

   Private Sub _numPt_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numFourthPtY.ValueChanged, _numFourthPtX.ValueChanged, _numThirdPtY.ValueChanged, _numThirdPtX.ValueChanged, _numSecondPtY.ValueChanged, _numSecondPtX.ValueChanged, _numFirstPtY.ValueChanged, _numFirstPtX.ValueChanged
      If sender Is _numFirstPtX OrElse sender Is _numFirstPtY Then
         _lastPoint = New Point(CInt(_numFirstPtX.Value), CInt(_numFirstPtY.Value))
         If _polyPoints.Count >= 1 Then
            _polyPoints.RemoveAt(0)
            _polyPoints.Insert(0, _lastPoint)
         Else
            _polyPoints.Add(_lastPoint)
         End If

      End If

      If sender Is _numSecondPtX OrElse sender Is _numSecondPtY Then
         _lastPoint = New Point(CInt(_numSecondPtX.Value), CInt(_numSecondPtY.Value))
         If _polyPoints.Count >= 2 Then
            _polyPoints.RemoveAt(1)
            _polyPoints.Insert(1, _lastPoint)
         Else
            If _polyPoints.Count = 0 Then
               _polyPoints.Add(New Point(0, 0))
            End If
            _polyPoints.Add(_lastPoint)
         End If
      End If

      If sender Is _numThirdPtX OrElse sender Is _numThirdPtY Then
         _lastPoint = New Point(CInt(_numThirdPtX.Value), CInt(_numThirdPtY.Value))
         If _polyPoints.Count >= 3 Then
            _polyPoints.RemoveAt(2)
            _polyPoints.Insert(2, _lastPoint)
         Else
            If _polyPoints.Count < 2 Then
               For i As Integer = _polyPoints.Count To 1
                  _polyPoints.Add(New Point(0, 0))
               Next i
            End If
            _polyPoints.Add(_lastPoint)
         End If
      End If

      If sender Is _numFourthPtX OrElse sender Is _numFourthPtY Then
         _lastPoint = New Point(CInt(_numFourthPtX.Value), CInt(_numFourthPtY.Value))
         If _polyPoints.Count >= 4 Then
            _polyPoints.RemoveAt(3)
            _polyPoints.Insert(3, _lastPoint)
         Else
            If _polyPoints.Count < 3 Then
               For i As Integer = _polyPoints.Count To 2
                  _polyPoints.Add(New Point(0, 0))
               Next i
            End If
            _polyPoints.Add(_lastPoint)
            _drawing = False
         End If
      End If

      _firstPointSelected = True
      _viewer.Invalidate()
   End Sub
End Class
