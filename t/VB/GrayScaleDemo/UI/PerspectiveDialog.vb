' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Controls
Imports System

Partial Public Class PerspectiveDialog
   Inherits Form
   Private _viewer As ImageViewer
   Private _form As ViewerForm
   Private _mainForm As MainForm
   Private _polyPoints As List(Of Point)
   Private _lastPoint As Point
   Private _currentMousePoint As Point
   Private _firstPointSelected As Boolean
   Private _drawing As Boolean
   Private _movingPntIdx As Integer
   Private _orgImage As RasterImage

   Public Sub New(form As MainForm, viewer As ViewerForm)
      _mainForm = form
      _form = viewer
      _viewer = viewer.Viewer
      InitializeComponent()
      _form.DisableInteractiveModes(_form.Viewer)
      _form.Viewer.InteractiveModes.EnableById(_form.NoneInteractiveMode.Id)
   End Sub

   Private Sub PerspectiveDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      AddHandler _viewer.PostRender, AddressOf _viewer_PostRender
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      AddHandler _form.FormClosing, AddressOf _form_FormClosing
      _polyPoints = New List(Of Point)()
      _firstPointSelected = False
      _drawing = True
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
         If _viewer.Floater IsNot Nothing Then
            _viewer.Floater.Dispose()
            _viewer.Floater = Nothing
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         _mainForm.UpdateMyControls()
      End Try
   End Sub


   Private Sub _form_FormClosing(sender As Object, e As FormClosingEventArgs)
      Me.Close()
   End Sub

   Private Sub _viewer_MouseUp(sender As Object, e As MouseEventArgs)
      If _viewer.ViewBounds.Contains(e.X, e.Y) Then
         If e.Button = MouseButtons.Left Then
            _movingPntIdx = -1
         End If
      End If
   End Sub

   Private Function CreateRectFromPoint(point As Point, size As Integer) As Rectangle
      Return New Rectangle(point.X - size, point.Y - size, size * 2, size * 2)
   End Function

   Private Sub _viewer_MouseDown(sender As Object, e As MouseEventArgs)
      If _viewer.ViewBounds.Contains(e.X, e.Y) Then
         If e.Button = MouseButtons.Left Then
            Dim xFactor As Double = _viewer.XScaleFactor
            Dim yFactor As Double = _viewer.YScaleFactor

            Dim xOffset As Integer = _viewer.ClientRectangle.Left
            Dim yOffset As Integer = _viewer.ClientRectangle.Top

            Dim pnt As New Point(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))

            _movingPntIdx = -1

            If Not _drawing Then
               Dim hyberAreas As Rectangle() = New Rectangle(_polyPoints.Count - 1) {}
               For idx As Integer = 0 To hyberAreas.Length - 1
                  hyberAreas(idx) = CreateRectFromPoint(_polyPoints(idx), 5)
                  If hyberAreas(idx).Contains(pnt) Then
                     _movingPntIdx = idx
                     Exit For
                  End If
               Next
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

   Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
      Dim xFactor As Double = _viewer.XScaleFactor
      Dim yFactor As Double = _viewer.YScaleFactor

      Dim xOffset As Integer = _viewer.ClientRectangle.Left
      Dim yOffset As Integer = _viewer.ClientRectangle.Top

      Dim pnt As New Point(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))
      If _viewer.ViewBounds.Contains(e.X, e.Y) Then
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

   Private Sub _viewer_PostRender(sender As Object, args As ImageViewerRenderEventArgs)
      Dim e As PaintEventArgs = args.PaintEventArgs

      If _firstPointSelected Then
         Dim xFactor As Double = _viewer.XScaleFactor
         Dim yFactor As Double = _viewer.YScaleFactor
         Dim xOffset As Single = -_viewer.DisplayRectangle.Left
         Dim yOffset As Single = -_viewer.DisplayRectangle.Top

         Dim drawPoints As Point() = New Point(_polyPoints.Count - 1) {}

         For idx As Integer = 0 To drawPoints.Length - 1
            drawPoints(idx) = New Point(CInt((_polyPoints(idx).X + xOffset) * xFactor + 0.5), CInt((_polyPoints(idx).Y + yOffset) * yFactor + 0.5))
         Next

         Dim lastPoint As New Point(CInt((_lastPoint.X + xOffset) * xFactor + 0.5), CInt((_lastPoint.Y + yOffset) * yFactor + 0.5))
         Dim currentMousePoint As New Point(CInt((_currentMousePoint.X + xOffset) * xFactor + 0.5), CInt((_currentMousePoint.Y + yOffset) * yFactor + 0.5))

         Dim size As Integer = 3
         e.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(drawPoints(0), size))
         For i As Integer = 1 To drawPoints.Length - 1
            Dim prev As Point = drawPoints(i - 1)
            Dim curnt As Point = drawPoints(i)
            e.Graphics.DrawLine(Pens.Yellow, prev, curnt)
            If Not _drawing Then
               e.Graphics.DrawLine(Pens.Yellow, drawPoints(0), drawPoints(drawPoints.Length - 1))
            End If

            e.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(prev, size))
            e.Graphics.FillEllipse(Brushes.Green, CreateRectFromPoint(curnt, size))
         Next

         If _drawing AndAlso drawPoints.Length < 4 Then
            e.Graphics.DrawLine(Pens.Green, lastPoint, currentMousePoint)
         End If
      End If
   End Sub

   Private Sub ApplyFilter()
      If _polyPoints.Count = 4 AndAlso _firstPointSelected Then
         Dim PolyPoints As New List(Of LeadPoint)()
         For i As Integer = 0 To 3
            PolyPoints.Add(New LeadPoint(_polyPoints(i).X, _polyPoints(i).Y))
         Next
         Dim command As New KeyStoneCommand(PolyPoints.ToArray())
         Try
            command.Run(_viewer.Image)
         Catch ex As System.Exception
            Messager.ShowError(Me, ex)
            Return
         End Try

         _viewer.Cursor = Cursors.[Default]
#If Not LEADTOOLS_V20_OR_LATER Then
         _viewer.Image = command.TransformedBitmap.Clone()
#Else
         _viewer.Image = command.TransformedImage.Clone()
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
         _viewer.Invalidate()
         _firstPointSelected = False
         _btnReset.Enabled = True

         _btnApply.Enabled = False
      End If
   End Sub

   Private Sub _bntApply_Click(sender As Object, e As EventArgs) Handles _btnApply.Click
      ApplyFilter()
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      ApplyFilter()
      TryCast(_mainForm.ActiveMdiChild, ViewerForm).addToImageList()
      Me.Close()
   End Sub

   Private Sub PerspectiveDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      RemoveHandler _viewer.PostRender, AddressOf _viewer_PostRender
      RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      _viewer.Cursor = Cursors.[Default]
      _viewer.Invalidate()

      _mainForm.IsSegmentation = False
      _mainForm.UpdateMyControls()
      TryCast(_mainForm.ActiveMdiChild, ViewerForm).UpdateAfterCommandExecution()
   End Sub

   Private Sub _btnReset_Click(sender As Object, e As EventArgs) Handles _btnReset.Click
      If Not _firstPointSelected AndAlso _polyPoints.Count = 4 Then
         _firstPointSelected = True
         _viewer.Image = _orgImage.Clone()
         _btnApply.Enabled = True
         _btnReset.Enabled = False
      End If

   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      _viewer.Image = _orgImage.Clone()
      Me.Close()
   End Sub

   Private Sub UpdateDialogPoints(pointIndex As Integer, pt As Point)
      Select Case pointIndex
         Case 0
            _numFirstPtX.Value = pt.X
            _numFirstPtY.Value = pt.Y
            Exit Select
         Case 1
            _numSecondPtX.Value = pt.X
            _numSecondPtY.Value = pt.Y
            Exit Select
         Case 2
            _numThirdPtX.Value = pt.X
            _numThirdPtY.Value = pt.Y
            Exit Select
         Case 3
            _numFourthPtX.Value = pt.X
            _numFourthPtY.Value = pt.Y
            Exit Select
      End Select
   End Sub

   Private Sub _numPt_ValueChanged(sender As Object, e As EventArgs) Handles _numFourthPtY.ValueChanged, _numFourthPtX.ValueChanged, _numThirdPtY.ValueChanged, _numThirdPtX.ValueChanged, _numSecondPtY.ValueChanged, _numSecondPtX.ValueChanged, _numFirstPtY.ValueChanged, _numFirstPtX.ValueChanged
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
               Next
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
               Next
            End If
            _polyPoints.Add(_lastPoint)
            _drawing = False
         End If
      End If

      _firstPointSelected = True
      _viewer.Invalidate()
   End Sub
End Class
