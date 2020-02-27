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

Imports Leadtools.ImageProcessing.Color
Imports Leadtools
Imports Leadtools.Controls
Imports System

Enum downButtonPosition
   NONE = 0
   START_RECT = 1
   END_RECT = 2
End Enum

Partial Public Class LineHistogramDialog
   Inherits Form
   Private _xStart As Integer, _yStart As Integer, _xEnd As Integer, _yEnd As Integer, _scale As Integer, _div As Integer
   Private _ptStart As LeadPoint, _ptEnd As LeadPoint
   Private _redData As Integer()
   Private _greenData As Integer()
   Private _blueData As Integer()
   Private _image As RasterImage
   Private _redPen As Pen, _greenPen As Pen, _bluePen As Pen
   Private _redPoints As Point(), _greenPoints As Point(), _bluePoints As Point()
   Private _firstTime As Boolean = True
   Private _isGrayScale As Boolean, _pressed As Boolean
   Private _form As ViewerForm
   Private _viewer As ImageViewer
   Private _button As downButtonPosition
   Private _startRect As Rectangle, _endRect As Rectangle

   Public Sub New(form As ViewerForm, viewer As ImageViewer, isGray As Boolean)
      InitializeComponent()
      _image = viewer.Image
      _isGrayScale = isGray
      _form = form
      _viewer = viewer
      _button = downButtonPosition.NONE
      AddHandler _viewer.PostRender, AddressOf _viewer_PostRender
   End Sub

   Private Sub LineHistogramDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         _xStart = 0
         _yStart = 0
         _xEnd = 0
         _yEnd = 0
         _redPen = New Pen(Color.Red)
         _greenPen = New Pen(Color.Green)
         _bluePen = New Pen(Color.Blue)
         _numXStart.Maximum = _image.Width - 1
         _numXEnd.Maximum = _image.Width - 1
         _numYStart.Maximum = _image.Height - 1
         _numYEnd.Maximum = _image.Height - 1

         AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
         AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
         AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
         _pressed = False
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Private Sub ApplyLineHistogram()
      Try
         _ptStart = New LeadPoint(_xStart, _yStart)
         _ptEnd = New LeadPoint(_xEnd, _yEnd)

         Dim cmd As New LineProfileCommand()
         cmd.FirstPoint = _ptStart
         cmd.SecondPoint = _ptEnd
         _image.UseLookupTable = False
         cmd.Run(_image)
         _image.UseLookupTable = True

         _redData = cmd.RedBuffer
         _greenData = cmd.GreenBuffer
         _blueData = cmd.BlueBuffer

         If _redData.Length > 350 Then
            _tbTabs.Maximum = Convert.ToInt32(Math.Floor(_redData.Length / 50.0))
         Else
            _tbTabs.Maximum = 0
         End If

         _redPoints = New Point(_redData.Length - _scale - 1) {}
         _greenPoints = New Point(_greenData.Length - _scale - 1) {}
         _bluePoints = New Point(_blueData.Length - _scale - 1) {}

         Dim x As Integer = 0
         Dim start As Integer = If((_scale = 0), 0, _scale)

         If _isGrayScale = True Then
            _div = Convert.ToInt32(Math.Ceiling(Max(_redData) / 250.0))
         Else
            _div = 1
         End If

         For i As Integer = start To _redData.Length - 1
            _redPoints(x) = New Point(System.Math.Max(System.Threading.Interlocked.Increment(x), x - 1), CInt(_tabRed.Height - _redData(i) / _div))
         Next


         x = 0
         For i As Integer = start To _greenData.Length - 1
            _greenPoints(x) = New Point(System.Math.Max(System.Threading.Interlocked.Increment(x), x - 1), CInt(_tabGreen.Height - _greenData(i) / _div))
         Next


         x = 0
         For i As Integer = start To _blueData.Length - 1
            _bluePoints(x) = New Point(System.Math.Max(System.Threading.Interlocked.Increment(x), x - 1), CInt(_tabBlue.Height - _blueData(i) / _div))
         Next

         If _redData.Length > 1 Then
            _firstTime = False
         End If

         _txtPixelNumber.Text = _redData.Length.ToString()
         _txtRedMax.Text = Max(_redData).ToString()
         _txtGreenMax.Text = Max(_greenData).ToString()
         _txtBlueMax.Text = Max(_blueData).ToString()
         _txtRedMin.Text = Min(_redData).ToString()
         _txtGreenMin.Text = Min(_greenData).ToString()
         _txtBlueMin.Text = Min(_blueData).ToString()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Function Max(array As Integer()) As Integer
      Dim max__1 As Integer = array(0)
      For i As Integer = 1 To array.Length - 1
         If array(i) > max__1 Then
            max__1 = array(i)
         End If
      Next

      Return max__1
   End Function

   Private Function Min(array As Integer()) As Integer
      Dim min__1 As Integer = array(0)
      For i As Integer = 1 To array.Length - 1
         If array(i) < min__1 Then
            min__1 = array(i)
         End If
      Next

      Return min__1
   End Function

   Private Sub _tabAll_Paint(sender As Object, e As PaintEventArgs) Handles _tabAll.Paint
      If Not _firstTime AndAlso _redPoints.Length > 1 Then
         If _cbFillCurve.Checked Then
            Dim redPoints As Point(), greenPoints As Point(), bluePoints As Point()

            redPoints = New Point(_redData.Length + 1) {}
            greenPoints = New Point(_greenPoints.Length + 1) {}
            bluePoints = New Point(_bluePoints.Length + 1) {}

            FillCurve(redPoints, 0)
            FillCurve(greenPoints, 1)
            FillCurve(bluePoints, 2)

            e.Graphics.FillPolygon(New SolidBrush(Color.Red), redPoints)
            e.Graphics.FillPolygon(New SolidBrush(Color.Green), greenPoints)
            e.Graphics.FillPolygon(New SolidBrush(Color.Blue), bluePoints)
         Else
            e.Graphics.DrawCurve(_redPen, _redPoints)
            e.Graphics.DrawCurve(_greenPen, _greenPoints)
            e.Graphics.DrawCurve(_bluePen, _bluePoints)
         End If
      End If
   End Sub

   Private Sub FillCurve(array As Point(), index As Integer)
      Dim i As Integer
      Select Case index
         Case 0
            For i = 0 To _redPoints.Length - 1
               array(i) = New Point(_redPoints(i).X, _redPoints(i).Y)
            Next
            array(System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)) = New Point(_redPoints.Length, 255)
            array(i) = New Point(0, 255)
            Exit Select

         Case 1
            For i = 0 To _greenPoints.Length - 1
               array(i) = New Point(_greenPoints(i).X, _greenPoints(i).Y)
            Next
            array(System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)) = New Point(i - 1, 255)
            array(i) = New Point(0, 255)
            Exit Select

         Case 2
            For i = 0 To _bluePoints.Length - 1
               array(i) = New Point(_bluePoints(i).X, _bluePoints(i).Y)
            Next
            array(System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)) = New Point(i - 1, 255)
            array(i) = New Point(0, 255)
            Exit Select
      End Select
   End Sub

   Private Sub _tabRed_Paint(sender As Object, e As PaintEventArgs) Handles _tabRed.Paint
      If Not _firstTime AndAlso _redPoints.Length > 1 Then
         If _cbFillCurve.Checked Then
            Dim redPoints As Point()
            redPoints = New Point(_redPoints.Length + 1) {}
            FillCurve(redPoints, 0)
            e.Graphics.FillPolygon(New SolidBrush(Color.Red), redPoints)
         Else
            e.Graphics.DrawCurve(_redPen, _redPoints)
         End If
      End If
   End Sub

   Private Sub _tabGreen_Paint(sender As Object, e As PaintEventArgs) Handles _tabGreen.Paint
      If Not _firstTime AndAlso _redPoints.Length > 1 Then
         If _cbFillCurve.Checked Then
            Dim greenPoints As Point()
            greenPoints = New Point(_greenPoints.Length + 1) {}
            FillCurve(greenPoints, 1)
            e.Graphics.FillPolygon(New SolidBrush(Color.Green), greenPoints)
         Else
            e.Graphics.DrawCurve(_greenPen, _greenPoints)
         End If
      End If
   End Sub

   Private Sub _tabBlue_Paint(sender As Object, e As PaintEventArgs) Handles _tabBlue.Paint
      If Not _firstTime AndAlso _redPoints.Length > 1 Then
         If _cbFillCurve.Checked Then
            Dim bluePoints As Point()
            bluePoints = New Point(_bluePoints.Length + 1) {}
            FillCurve(bluePoints, 2)
            e.Graphics.FillPolygon(New SolidBrush(Color.Blue), bluePoints)
         Else
            e.Graphics.DrawCurve(_bluePen, _bluePoints)
         End If
      End If
   End Sub

   Private Sub _tab_MouseMove(sender As Object, e As MouseEventArgs) Handles _tabAll.MouseMove, _tabRed.MouseMove, _tabGreen.MouseMove, _tabBlue.MouseMove
      Try
         If _firstTime OrElse e.X >= _redData.Length Then
            Return
         End If

         Dim start As LeadPoint, [end] As LeadPoint
         If _ptStart.X <= _ptEnd.X Then
            start = _ptStart
            [end] = _ptEnd
         Else
            start = _ptEnd
            [end] = _ptStart
         End If

         Dim dx As Double = Math.Abs(([end].X - start.X) * 1.0 / _redData.Length)
         Dim dy As Double = Math.Abs(([end].Y - start.Y) * 1.0 / _redData.Length)

         _txtXPixel.Text = Convert.ToInt32((e.X + _scale) * dx).ToString()
         _txtYPixel.Text = Convert.ToInt32((e.X + _scale) * dy).ToString()

         _txtRed.Text = _redData(e.X).ToString()
         _txtGreen.Text = _greenData(e.X).ToString()
         _txtBlue.Text = _blueData(e.X).ToString()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _tbTabs_Scroll(sender As Object, e As EventArgs) Handles _tbTabs.Scroll
      Try
         _scale = _tbTabs.Value * 50
         ApplyLineHistogram()
         '_viewer.Invalidate();
         _tabs.Refresh()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      Close()
   End Sub

   Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
      Dim tmpPnt As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y))
      If _pressed Then
         Select Case _button
            Case downButtonPosition.END_RECT, downButtonPosition.NONE
               _xEnd = tmpPnt.X
               _yEnd = tmpPnt.Y
               _numXEnd.Text = _xEnd.ToString()
               _numYEnd.Text = _yEnd.ToString()
               If _cbMovable.Checked Then
                  _endRect = New Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20)
               End If
               If _cbMovable.Checked AndAlso _button = downButtonPosition.NONE Then
                  _startRect = New Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20)
               End If
               Exit Select
            Case downButtonPosition.START_RECT
               _xStart = tmpPnt.X
               _yStart = tmpPnt.Y
               _numXStart.Text = _xStart.ToString()
               _numYStart.Text = _yStart.ToString()
               If _cbMovable.Checked Then
                  _startRect = New Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20)
               End If
               Exit Select
         End Select
         _viewer.Invalidate()
      End If
      _yCursorPosition.Text = tmpPnt.Y.ToString()
      _xCursorPosition.Text = tmpPnt.X.ToString()
   End Sub

   Private Sub _viewer_MouseDown(sender As Object, e As MouseEventArgs)
      Dim point As Point = _viewer.PointToScreen(New Point(0, 0))
      Cursor.Clip = New Rectangle(point.X + Math.Max(0, _viewer.ViewBounds.Left), point.Y + Math.Max(0, _viewer.ViewBounds.Top), _viewer.ViewBounds.Width, _viewer.ViewBounds.Height)
      If e.Button = MouseButtons.Left Then
         Dim tmpPnt As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y))
         _pressed = True

         If _cbMovable.Checked Then
            If _startRect.Contains(tmpPnt.X, tmpPnt.Y) Then
               _button = downButtonPosition.START_RECT
            ElseIf _endRect.Contains(tmpPnt.X, tmpPnt.Y) Then
               _button = downButtonPosition.END_RECT
            Else
               _button = downButtonPosition.NONE
               _xEnd = tmpPnt.X
               _xStart = tmpPnt.X
               _yEnd = tmpPnt.Y
               _yStart = tmpPnt.Y
               _numXStart.Text = _xStart.ToString()
               _numYStart.Text = _yStart.ToString()
               _startRect = New Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20)
               _endRect = New Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20)
            End If
         Else
            _xEnd = tmpPnt.X
            _xStart = tmpPnt.X
            _yEnd = tmpPnt.Y
            _yStart = tmpPnt.Y
            _numXStart.Text = _xStart.ToString()
            _numYStart.Text = _yStart.ToString()
         End If
      End If
   End Sub

   Private Sub _viewer_PostRender(sender As Object, args As ImageViewerRenderEventArgs)
      Dim firstPoint As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadPoint.Create(_xStart, _yStart))
      Dim endPoint As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadPoint.Create(_xEnd, _yEnd))
      Dim dashValuesWhite As Single() = {4, 4, 4, 4}
      Dim penBlack As New Pen(Color.Black, 1)
      Dim penWhite As New Pen(Color.White, 1)
      Dim e As PaintEventArgs = args.PaintEventArgs
      penWhite.DashPattern = dashValuesWhite

      e.Graphics.DrawLine(penBlack, firstPoint.X, firstPoint.Y, endPoint.X, endPoint.Y)
      e.Graphics.DrawLine(penWhite, firstPoint.X, firstPoint.Y, endPoint.X, endPoint.Y)
      Dim startRect As LeadRect = _viewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadRect.Create(_startRect.X, _startRect.Y, _startRect.Width, _startRect.Height))
      Dim endRect As LeadRect = _viewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadRect.Create(_endRect.X, _endRect.Y, _endRect.Width, _endRect.Height))
      If _cbMovable.Checked Then
         e.Graphics.DrawRectangle(penBlack, startRect.X, startRect.Y, startRect.Width, startRect.Height)
         e.Graphics.DrawRectangle(penWhite, startRect.X, startRect.Y, startRect.Width, startRect.Height)
         e.Graphics.DrawRectangle(penBlack, endRect.X, endRect.Y, endRect.Width, endRect.Height)
         e.Graphics.DrawRectangle(penWhite, endRect.X, endRect.Y, endRect.Width, endRect.Height)
      End If
   End Sub

   Private Sub _viewer_MouseUp(sender As Object, e As MouseEventArgs)
      Cursor.Clip = Rectangle.Empty

      If e.Button = MouseButtons.Left Then
         Dim tmpPnt As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y))
         _pressed = False

         Select Case _button
            Case downButtonPosition.END_RECT, downButtonPosition.NONE
               _xEnd = tmpPnt.X
               _yEnd = tmpPnt.Y
               _numXEnd.Text = _xEnd.ToString()
               _numYEnd.Text = _yEnd.ToString()
               Exit Select
            Case downButtonPosition.START_RECT
               _xStart = tmpPnt.X
               _yStart = tmpPnt.Y
               _numXStart.Text = _xStart.ToString()
               _numYStart.Text = _yStart.ToString()
               Exit Select
         End Select
         If _cbMovable.Checked Then
            _startRect = New Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20)
            _endRect = New Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20)
         End If
      End If
   End Sub

   Private Sub LineHistogramDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      RemoveHandler _viewer.PostRender, AddressOf _viewer_PostRender

      _viewer.Invalidate()

      AddHandler _viewer.MouseUp, AddressOf _form.Viewer_MouseUp
      AddHandler _viewer.MouseDown, AddressOf _form.Viewer_MouseDown
      AddHandler _viewer.MouseMove, AddressOf _form.Viewer_MouseMove
      AddHandler _viewer.MouseWheel, AddressOf _form.Viewer_MouseWheel
      AddHandler _viewer.Paint, AddressOf _form._viewer_Paint
   End Sub

   Private Sub _numXStart_ValueChanged(sender As Object, e As EventArgs) Handles _numXStart.ValueChanged
      Try
         _xStart = Integer.Parse(_numXStart.Text)

         ApplyLineHistogram()
         _tabs.Refresh()
         _viewer.Invalidate()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _numYStart_ValueChanged(sender As Object, e As EventArgs) Handles _numYStart.ValueChanged
      Try
         _yStart = Integer.Parse(_numYStart.Text)

         ApplyLineHistogram()
         _tabs.Refresh()
         _viewer.Invalidate()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _numXEnd_ValueChanged(sender As Object, e As EventArgs) Handles _numXEnd.ValueChanged
      Try
         _xEnd = Integer.Parse(_numXEnd.Text)

         ApplyLineHistogram()
         _tabs.Refresh()
         _viewer.Invalidate()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _numYEnd_ValueChanged(sender As Object, e As EventArgs) Handles _numYEnd.ValueChanged
      Try
         _yEnd = Integer.Parse(_numYEnd.Text)

         ApplyLineHistogram()
         _tabs.Refresh()
         _viewer.Invalidate()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _cbFillCurve_CheckedChanged(sender As Object, e As EventArgs) Handles _cbFillCurve.CheckedChanged
      ApplyLineHistogram()
      _tabs.Refresh()
      _viewer.Invalidate()
   End Sub

   Private Sub _cbMovable_CheckedChanged(sender As Object, e As EventArgs) Handles _cbMovable.CheckedChanged
      _startRect = New Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20)
      _endRect = New Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20)
      ApplyLineHistogram()
      _tabs.Refresh()
      _viewer.Invalidate()
   End Sub
End Class
