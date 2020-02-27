' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports OcrDemo.OcrDemo
Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing

Partial Public Class UnWarpDialog
   Inherits Form
   Private _viewer As ImageViewer
   Private _form As OcrDemo.ViewerControl.ViewerControl
   Private _unWarpPoints As List(Of Point)
   Private _lastPoint As Point
   Private _currentMousePoint As Point
   Private _firstPointSelected As Boolean
   Private _drawing As Boolean
   Private _applied As Boolean
   Public OkButtonPressed As Boolean = False
   Private _movingPntIdx As Integer
   Private _upperCurvePath As LeadPoint() = Nothing
   Private _lowerCurvePath As LeadPoint() = Nothing
   Private _orgImage As RasterImage

   Public Sub New(form As MainForm, viewer As OcrDemo.ViewerControl.ViewerControl)
      _form = viewer
      _viewer = viewer.ImageViewer
      InitializeComponent()
   End Sub

   Private Sub UnWarpDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      AddHandler _viewer.PostRender, AddressOf Me._viewer_PostRender
      AddHandler _viewer.MouseMove, AddressOf Me._viewer_MouseMove
      AddHandler _viewer.MouseDown, AddressOf Me._viewer_MouseDown
      AddHandler _viewer.MouseUp, AddressOf Me._viewer_MouseUp
      _unWarpPoints = New List(Of Point)()
      _firstPointSelected = False
      _drawing = True
      _applied = False
      _movingPntIdx = -1
      _orgImage = _viewer.Image.Clone()
      _btnApply.Enabled = False
      _btnReset.Enabled = False

      Try
         If Not _viewer.Floater Is Nothing Then
            _viewer.Floater.Dispose()
            _viewer.Floater = Nothing
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Function CreateRectFromPoint(ByVal point As Point, ByVal size As Integer) As Rectangle
      Return New Rectangle(point.X - size, point.Y - size, size * 2, size * 2)
   End Function

   Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))
      Dim imageBounds As LeadRect = New LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight)
      If imageBounds.Contains(pixels) Then
         If e.Button = MouseButtons.Left Then
            Dim xFactor As Double = 1
            Dim yFactor As Double = 1

            Dim xOffset As Integer = 0
            Dim yOffset As Integer = 0

            Dim pnt As Point = New Point(CInt(Math.Ceiling(((pixels.X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((pixels.Y - yOffset) * 1.0 / yFactor + 0.5))))

            _movingPntIdx = -1

            If (Not _drawing) Then
               Dim hyberAreas As Rectangle() = New Rectangle(_unWarpPoints.Count - 1) {}
               Dim idx As Integer = 0
               Do While idx < hyberAreas.Length
                  hyberAreas(idx) = CreateRectFromPoint(_unWarpPoints(idx), 20)
                  If hyberAreas(idx).Contains(pnt) Then
                     _movingPntIdx = idx
                     Exit Do
                  End If
                  idx += 1
               Loop
            End If

            If _movingPntIdx = -1 Then
               If _unWarpPoints.Count < 4 Then
                  If pnt.Equals(_lastPoint) Then
                     Return
                  End If
                  _firstPointSelected = True
                  _unWarpPoints.Add(pnt)
                  _currentMousePoint = pnt
                  UpdateDialogPoints(_unWarpPoints.Count - 1, pnt)
                  _lastPoint = pnt
               End If

               If _unWarpPoints.Count = 4 Then
                  For ii As Integer = 1 To 2
                     pnt.X = CInt((_unWarpPoints(1).X - _unWarpPoints(0).X) * ii / 3) + _unWarpPoints(0).X
                     pnt.Y = CInt((_unWarpPoints(1).Y - _unWarpPoints(0).Y) * ii / 3) + _unWarpPoints(0).Y
                     _currentMousePoint = pnt
                     _unWarpPoints.Add(pnt)
                     Invalidate()
                     UpdateDialogPoints(_unWarpPoints.Count - 1, pnt)
                  Next ii

                  For ii As Integer = 1 To 2
                     pnt.X = CInt((_unWarpPoints(2).X - _unWarpPoints(3).X) * ii / 3) + _unWarpPoints(3).X
                     pnt.Y = CInt((_unWarpPoints(2).Y - _unWarpPoints(3).Y) * ii / 3) + _unWarpPoints(3).Y
                     _unWarpPoints.Add(pnt)
                     Invalidate()
                     UpdateDialogPoints(_unWarpPoints.Count - 1, pnt)
                  Next ii

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
      _txtCursorX.Text = pnt.X.ToString()
      _txtCursorY.Text = pnt.Y.ToString()

      Dim imageBounds As LeadRect = New LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight)
      If imageBounds.Contains(pixels) Then
         If _firstPointSelected Then
            _currentMousePoint = pnt
         End If

         If _movingPntIdx <> -1 Then
            If pnt.X < 0 Then
               pnt.X = 0
            End If
            If pnt.X > _viewer.Image.ImageWidth - 1 Then
               pnt.X = _viewer.Image.ImageWidth - 1
            End If
            If pnt.Y < 0 Then
               pnt.Y = 0
            End If
            If pnt.Y > _viewer.Image.ImageHeight - 1 Then
               pnt.Y = _viewer.Image.ImageHeight - 1
            End If

            _unWarpPoints(_movingPntIdx) = pnt
            UpdateDialogPoints(_movingPntIdx, pnt)
         End If
         _viewer.Invalidate()
      End If
   End Sub

   Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))
      Dim imageBounds As LeadRect = New LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight)
      If imageBounds.Contains(pixels) Then
         If e.Button = MouseButtons.Left Then
            _movingPntIdx = -1
         End If
      End If

      If _unWarpPoints.Count >= 4 Then
         Dim xFactor As Double = 1
         Dim yFactor As Double = 1
         Dim xOffset As Integer = 0
         Dim yOffset As Integer = 0

         Dim inUpperPoints As LeadPoint() = New LeadPoint(3) {}
         inUpperPoints(0) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(0).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(0).Y - yOffset) * 1.0 / yFactor + 0.5))))
         inUpperPoints(1) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(4).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(4).Y - yOffset) * 1.0 / yFactor + 0.5))))
         inUpperPoints(2) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(5).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(5).Y - yOffset) * 1.0 / yFactor + 0.5))))
         inUpperPoints(3) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(1).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(1).Y - yOffset) * 1.0 / yFactor + 0.5))))
         Dim cmd As BezierPathCommand = New BezierPathCommand(inUpperPoints)
         cmd.Run(_viewer.Image)
         _upperCurvePath = cmd.PathPoints

         Dim inLowerPoints As LeadPoint() = New LeadPoint(3) {}
         inLowerPoints(0) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(3).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(3).Y - yOffset) * 1.0 / yFactor + 0.5))))
         inLowerPoints(1) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(6).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(6).Y - yOffset) * 1.0 / yFactor + 0.5))))
         inLowerPoints(2) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(7).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(7).Y - yOffset) * 1.0 / yFactor + 0.5))))
         inLowerPoints(3) = New LeadPoint(CInt(Math.Ceiling(((_unWarpPoints(2).X - xOffset) * 1.0 / xFactor + 0.5))), CInt(Math.Ceiling(((_unWarpPoints(2).Y - yOffset) * 1.0 / yFactor + 0.5))))
         cmd = New BezierPathCommand(inLowerPoints)
         cmd.Run(_viewer.Image)
         _lowerCurvePath = cmd.PathPoints

         Invalidate()
      End If
   End Sub

   Private Sub _viewer_PostRender(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
      If _firstPointSelected Then
         Dim xFactor As Double = _viewer.XScaleFactor
         Dim yFactor As Double = _viewer.YScaleFactor
         Dim xOffset As Single = -_viewer.ImageBounds.Left
         Dim yOffset As Single = -_viewer.ImageBounds.Top

         Dim drawPoints As Point() = New Point(_unWarpPoints.Count - 1) {}

         Dim idx As Integer = 0
         Do While idx < drawPoints.Length
            Dim TempPoint As LeadPointD = New LeadPointD(_unWarpPoints(idx).X, _unWarpPoints(idx).Y)
            TempPoint = _viewer.ImageTransform.Transform(TempPoint)
            drawPoints(idx) = New Point(CInt(TempPoint.X), CInt(TempPoint.Y))
            idx += 1
         Loop

         '**********************************************************************

         Const controlPointSize As Integer = 5
         Dim i As Integer = 0
         Do While i < drawPoints.Length
            e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(drawPoints(i), controlPointSize))
            i += 1
         Loop

         If drawPoints.Length >= 4 Then
            _drawing = False
            Dim line As Point() = New Point(1) {}

            line(0) = drawPoints(0)
            line(1) = drawPoints(3)
            e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, line(0), line(1))

            line(0) = drawPoints(1)
            line(1) = drawPoints(2)
            e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, line(0), line(1))

            If _upperCurvePath Is Nothing OrElse _upperCurvePath.Length = 0 Then
               Return
            End If

            Dim curvePoints As Point() = New Point(_upperCurvePath.Length - 1) {}
            Dim j As Integer = 0
            Do While j < _upperCurvePath.Length
               Dim TempPoint As LeadPointD = New LeadPointD(_upperCurvePath(j).X, _upperCurvePath(j).Y)
               TempPoint = _viewer.ImageTransform.Transform(TempPoint)
               curvePoints(j) = New Point(CInt(TempPoint.X), CInt(TempPoint.Y))
               j += 1
            Loop
            e.PaintEventArgs.Graphics.DrawCurve(Pens.Yellow, curvePoints)

            If _lowerCurvePath Is Nothing OrElse _lowerCurvePath.Length = 0 Then
               Return
            End If

            curvePoints = New Point(_lowerCurvePath.Length - 1) {}
            j = 0
            Do While j < _lowerCurvePath.Length
               Dim TempPoint As LeadPointD = New LeadPointD(_lowerCurvePath(j).X, _lowerCurvePath(j).Y)
               TempPoint = _viewer.ImageTransform.Transform(TempPoint)
               curvePoints(j) = New Point(CInt(TempPoint.X), CInt(TempPoint.Y))
               j += 1
            Loop
            e.PaintEventArgs.Graphics.DrawCurve(Pens.Yellow, curvePoints)
         Else
            i = 1
            Do While i < drawPoints.Length
               Dim prev As Point = drawPoints(i - 1)
               Dim curnt As Point = drawPoints(i)
               e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, prev, curnt)
               If (Not _drawing) Then
                  e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, drawPoints(0), drawPoints(drawPoints.Length - 1))
               End If
               i += 1
            Loop
         End If
      End If
   End Sub

   Private Sub ApplyFilter()
      Dim wait As WaitCursor = New WaitCursor()
      Try
         If _unWarpPoints.Count > 4 AndAlso _firstPointSelected Then
            _applied = True
            Dim UnWarpPoints As LeadPoint() = New LeadPoint(7) {}
            For i As Integer = 0 To 7
               UnWarpPoints(i).X = _unWarpPoints(i).X
               UnWarpPoints(i).Y = _unWarpPoints(i).Y
            Next i

            _viewer.Image.MakeRegionEmpty()

            Dim command As UnWarpCommand = New UnWarpCommand(UnWarpPoints)

            Try
               command.Run(_viewer.Image)
            Catch ex As System.Exception
               Messager.ShowError(Me, ex)
               Return
            End Try

            If Not command.OutputImage Is Nothing Then
               _viewer.Image = command.OutputImage.Clone()
            End If

            DoAction("UnWarpCommand", Me)

            _viewer.Invalidate()
            _form.Invalidate()
            _firstPointSelected = False
            _btnReset.Enabled = True
            _btnApply.Enabled = False
         End If
      Finally
         CType(wait, IDisposable).Dispose()
      End Try
   End Sub

   Private Sub _bntApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
      ApplyFilter()
   End Sub

   Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
      OkButtonPressed = True
      MainForm.UnWarpActive = False
      ApplyFilter()
      Me.Close()
   End Sub

   Private Sub UnWarpDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
      RemoveHandler _viewer.PostRender, AddressOf Me._viewer_PostRender
      RemoveHandler _viewer.MouseMove, AddressOf Me._viewer_MouseMove
      RemoveHandler _viewer.MouseDown, AddressOf Me._viewer_MouseDown
      RemoveHandler _viewer.MouseUp, AddressOf Me._viewer_MouseUp
      _viewer.Invalidate()
      _form.Invalidate()

      MainForm.UnWarpActive = False
      DoAction("UnWarpCommand", Me)
   End Sub

   Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
      If (Not _firstPointSelected) AndAlso _unWarpPoints.Count > 4 Then
         _firstPointSelected = True
         _viewer.Image = _orgImage.Clone()
         _btnApply.Enabled = True
         _btnReset.Enabled = False
      End If
   End Sub

   Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
      If _applied Then
         _viewer.Image = _orgImage.Clone()
      End If
      Me.Close()
   End Sub

   Private Sub UpdateDialogPoints(ByVal pointIndex As Integer, ByVal pt As Point)
      Select Case pointIndex
         Case 0
            _numFirstPtX.Text = pt.X.ToString()
            _numFirstPtY.Text = pt.Y.ToString()
         Case 1
            _numSecondPtX.Text = pt.X.ToString()
            _numSecondPtY.Text = pt.Y.ToString()
         Case 2
            _numThirdPtX.Text = pt.X.ToString()
            _numThirdPtY.Text = pt.Y.ToString()
         Case 3
            _numFourthPtX.Text = pt.X.ToString()
            _numFourthPtY.Text = pt.Y.ToString()
      End Select
   End Sub

   ''' <summary>
   ''' Any action that happens in this control that must be handled by the owner
   ''' </summary>
   Public Event Action As EventHandler(Of ActionEventArgs)

   Private Sub DoAction(ByVal action As String, ByVal data As Object)
      ' Raise the action event so the main form can handle it

      If Not ActionEvent Is Nothing Then
         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End If
   End Sub
End Class
