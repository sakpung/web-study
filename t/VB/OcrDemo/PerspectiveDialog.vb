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

Imports OcrDemo.OcrDemo
Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Controls

Partial Public Class PerspectiveDialog
   Inherits Form
   Private _viewer As ImageViewer
   Private _form As OcrDemo.ViewerControl.ViewerControl
   Private _polyPoints As List(Of Point)
   Private _lastPoint As Point
   Private _currentMousePoint As Point
   Private _firstPointSelected As Boolean
   Private _drawing As Boolean
   Private _applied As Boolean
   Public OkButtonPressed As Boolean = False
   Private _movingPntIdx As Integer
   Private _orgImage As RasterImage
   Private _manualPerspectiveDeskew As Boolean

   Public Sub New(form As MainForm, viewer As OcrDemo.ViewerControl.ViewerControl, manualPerspectiveDeskew As Boolean)
      _form = viewer
      _viewer = viewer.ImageViewer
      _manualPerspectiveDeskew = manualPerspectiveDeskew
      InitializeComponent()
   End Sub

   Private Sub PerspectiveDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
      AddHandler _viewer.PostRender, AddressOf Me._viewer_PostRender
      AddHandler _viewer.MouseMove, AddressOf Me._viewer_MouseMove
      AddHandler _viewer.MouseDown, AddressOf Me._viewer_MouseDown
      AddHandler _viewer.MouseUp, AddressOf Me._viewer_MouseUp
      _polyPoints = New List(Of Point)()
      _firstPointSelected = False
      _drawing = True
      _applied = False
      _movingPntIdx = -1
      _orgImage = _viewer.Image.Clone()
      _btnApply.Enabled = False
      _btnReset.Enabled = False

      If _manualPerspectiveDeskew Then
         _polyPoints.Add(New Point(5, 10))
         _polyPoints.Add(New Point(_viewer.Image.ImageWidth - 10, 10))
         _polyPoints.Add(New Point(_viewer.Image.ImageWidth - 5, _viewer.Image.ImageHeight - 10))
         _polyPoints.Add(New Point(5, _viewer.Image.ImageHeight - 10))
         UpdateDialogPoints(0, _polyPoints(0))
         UpdateDialogPoints(1, _polyPoints(1))
         UpdateDialogPoints(2, _polyPoints(2))
         UpdateDialogPoints(3, _polyPoints(3))

         _firstPointSelected = True
         _lastPoint = _polyPoints(3)
         _drawing = False
         _viewer.Invalidate()
         _btnApply.Enabled = True

         Me.Text = "Manual Perspective"
      Else
         Me.Text = "Inverse Perspective"
      End If

      Try
         If _viewer.Floater IsNot Nothing Then
            _viewer.Floater.Dispose()
            _viewer.Floater = Nothing
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _viewer_MouseUp(sender As Object, e As MouseEventArgs)
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))
      Dim imageBounds As New LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight)
      If imageBounds.Contains(pixels) Then
         If e.Button = MouseButtons.Left Then
            _movingPntIdx = -1
         End If
      End If
   End Sub

   Private Function CreateRectFromPoint(point As Point, size As Integer) As Rectangle
      Return New Rectangle(point.X - size, point.Y - size, size * 2, size * 2)
   End Function

   Private Sub _viewer_MouseDown(sender As Object, e As MouseEventArgs)
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))
      Dim imageBounds As New LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight)
      If imageBounds.Contains(pixels) Then
         If e.Button = MouseButtons.Left Then
            Dim xFactor As Double = 1
            Dim yFactor As Double = 1

            Dim xOffset As Integer = 0
            Dim yOffset As Integer = 0
            Dim pnt As New Point(CInt(Math.Ceiling((pixels.X - xOffset) * 1.0 / xFactor + 0.5)), CInt(Math.Ceiling((pixels.Y - yOffset) * 1.0 / yFactor + 0.5)))

            _movingPntIdx = -1

            If Not _drawing Then
               Dim hyberAreas As Rectangle() = New Rectangle(_polyPoints.Count - 1) {}
               For idx As Integer = 0 To hyberAreas.Length - 1
                  hyberAreas(idx) = CreateRectFromPoint(_polyPoints(idx), 15)
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
      Dim xFactor As Double = 1
      Dim yFactor As Double = 1

      Dim xOffset As Integer = 0
      Dim yOffset As Integer = 0
      Dim pixels As LeadPoint = _form.PhysicalToLogical(New LeadPoint(e.X, e.Y))

      Dim pnt As New Point(CInt((pixels.X - xOffset) * 1.0 / xFactor + 0.5), CInt((pixels.Y - yOffset) * 1.0 / yFactor + 0.5))
      _txtCursorX.Text = pnt.X.ToString()
      _txtCursorY.Text = pnt.Y.ToString()

      Dim imageBounds As New LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight)
      If imageBounds.Contains(pixels) Then
         '_viewer.Cursor = Cursors.Cross;

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

            _polyPoints.RemoveAt(_movingPntIdx)
            _polyPoints.Insert(_movingPntIdx, pnt)
            UpdateDialogPoints(_movingPntIdx, pnt)
         End If
         _viewer.Invalidate()
      End If
   End Sub

   Private Sub _viewer_PostRender(sender As Object, e As ImageViewerRenderEventArgs)
      If _firstPointSelected Then
         Dim xFactor As Double = _viewer.XScaleFactor
         Dim yFactor As Double = _viewer.YScaleFactor
         Dim xOffset As Single = -_viewer.ImageBounds.Left
         Dim yOffset As Single = -_viewer.ImageBounds.Top

         Dim drawPoints As Point() = New Point(_polyPoints.Count - 1) {}

         For idx As Integer = 0 To drawPoints.Length - 1
            Dim TempPoint As New LeadPointD(_polyPoints(idx).X, _polyPoints(idx).Y)
            TempPoint = _viewer.ImageTransform.Transform(TempPoint)
            drawPoints(idx) = New Point(CInt(TempPoint.X), CInt(TempPoint.Y))
         Next

         Dim lastPointTemp As New LeadPointD(_lastPoint.X, _lastPoint.Y)
         lastPointTemp = _viewer.ImageTransform.Transform(lastPointTemp)
         Dim lastPoint As New Point(CInt(lastPointTemp.X), CInt(lastPointTemp.Y))
         Dim currentMousePointTemp As New LeadPointD(_currentMousePoint.X, _currentMousePoint.Y)
         currentMousePointTemp = _viewer.ImageTransform.Transform(currentMousePointTemp)
         Dim currentMousePoint As New Point(CInt(currentMousePointTemp.X), CInt(currentMousePointTemp.Y))

         Const controlPointSize As Integer = 5
         e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(drawPoints(0), controlPointSize))
         For i As Integer = 1 To drawPoints.Length - 1
            Dim prev As Point = drawPoints(i - 1)
            Dim curnt As Point = drawPoints(i)
            e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, prev, curnt)
            If Not _drawing Then
               e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, drawPoints(0), drawPoints(drawPoints.Length - 1))
            End If

            e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(prev, controlPointSize))
            e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(curnt, controlPointSize))
         Next

         e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(drawPoints(0), controlPointSize))

         If _drawing AndAlso drawPoints.Length < 4 Then
            e.PaintEventArgs.Graphics.DrawLine(Pens.Red, lastPoint, currentMousePoint)
         End If
      End If
   End Sub

   Private Sub ApplyFilter()
      Using wait As New WaitCursor()
         If _polyPoints.Count = 4 AndAlso _firstPointSelected Then
            _applied = True
            Dim PolyPoints As LeadPoint() = New LeadPoint(3) {}
            For i As Integer = 0 To 3
               PolyPoints(i).X = _polyPoints(i).X
               PolyPoints(i).Y = _polyPoints(i).Y
            Next

            _viewer.Image.MakeRegionEmpty()

            Dim command As RasterCommand = Nothing
            If Not _manualPerspectiveDeskew Then
               command = New KeyStoneCommand(PolyPoints)
            Else
               Dim inputPoints As LeadPoint() = {New LeadPoint(0, 0), New LeadPoint(_viewer.Image.ImageWidth, 0), New LeadPoint(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight), New LeadPoint(0, _viewer.Image.ImageHeight)}

               command = New ManualPerspectiveDeskewCommand(inputPoints, PolyPoints)
            End If

            Try
               command.Run(_viewer.Image)
            Catch ex As System.Exception
               Messager.ShowError(Me, ex)
               Return
            End Try

            '_viewer.Cursor = Cursors.Default;
            If command.[GetType]() Is GetType(KeyStoneCommand) Then
#If Not LEADTOOLS_V20_OR_LATER Then
               Dim cmd As KeyStoneCommand = TryCast(command, KeyStoneCommand)
               If cmd.TransformedBitmap IsNot Nothing Then
                  _viewer.Image = cmd.TransformedBitmap.Clone()
               End If
#Else
               Dim cmd As KeyStoneCommand = TryCast(command, KeyStoneCommand)
               If cmd.TransformedImage IsNot Nothing Then
                  _viewer.Image = cmd.TransformedImage.Clone()
               End If
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
            Else
               ' ManualPerspectiveDeskewCommand
               Dim cmd As ManualPerspectiveDeskewCommand = TryCast(command, ManualPerspectiveDeskewCommand)
               If cmd.OutputImage IsNot Nothing Then
                  _viewer.Image = cmd.OutputImage.Clone()
               End If
            End If

            If _manualPerspectiveDeskew Then
               DoAction("ManualPerspectiveCommand", Me)
            Else
               DoAction("InversePerspectiveCommand", Me)
            End If

            _viewer.Invalidate()
            _form.Invalidate()
            _firstPointSelected = False
            _btnReset.Enabled = True
            _btnApply.Enabled = False
         End If
      End Using
   End Sub

   Private Sub _bntApply_Click(sender As Object, e As EventArgs) Handles _btnApply.Click
      ApplyFilter()
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      OkButtonPressed = True
      ApplyFilter()
      Me.Close()
   End Sub

   Private Sub PerspectiveDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      RemoveHandler _viewer.PostRender, AddressOf Me._viewer_PostRender
      RemoveHandler _viewer.MouseMove, AddressOf Me._viewer_MouseMove
      RemoveHandler _viewer.MouseDown, AddressOf Me._viewer_MouseDown
      RemoveHandler _viewer.MouseUp, AddressOf Me._viewer_MouseUp
      '_viewer.Cursor = Cursors.Default;
      _viewer.Invalidate()
      _form.Invalidate()

      MainForm.PerspectiveDeskewActive = False
      If _manualPerspectiveDeskew Then
         DoAction("ManualPerspectiveCommand", Me)
      Else
         DoAction("InversePerspectiveCommand", Me)
      End If
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
      If _applied Then
         _viewer.Image = _orgImage.Clone()
      End If
      Me.Close()
   End Sub

   Private Sub UpdateDialogPoints(pointIndex As Integer, pt As Point)
      Select Case pointIndex
         Case 0
            _numFirstPtX.Text = pt.X.ToString()
            _numFirstPtY.Text = pt.Y.ToString()
            Exit Select
         Case 1
            _numSecondPtX.Text = pt.X.ToString()
            _numSecondPtY.Text = pt.Y.ToString()
            Exit Select
         Case 2
            _numThirdPtX.Text = pt.X.ToString()
            _numThirdPtY.Text = pt.Y.ToString()
            Exit Select
         Case 3
            _numFourthPtX.Text = pt.X.ToString()
            _numFourthPtY.Text = pt.Y.ToString()
            Exit Select
      End Select
   End Sub

   ''' <summary>
   ''' Any action that happens in this control that must be handled by the owner
   ''' </summary>
   Public Event Action As EventHandler(Of ActionEventArgs)

   Private Sub DoAction(action As String, data As Object)
      ' Raise the action event so the main form can handle it

      RaiseEvent Action(Me, New ActionEventArgs(action, data))
   End Sub
End Class
