' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing
Imports Leadtools.Controls
Imports System

Partial Public Class WatershedDialog
   Inherits Form
   Private _viewer As ImageViewer
   Private _form As ViewerForm
   Private _mainForm As MainForm
   Private _lengths As List(Of Integer)
   Private _points As List(Of List(Of Point))
   Private _currentSegment As List(Of Point)
   Private _segIndex As Integer
   Private _drawing As Boolean
   Private _maskImage As RasterImage
   Private _orgImage As RasterImage

   Public Sub New(form As MainForm, viewer As ViewerForm)
      _mainForm = form
      _form = viewer
      _viewer = viewer.Viewer

      InitializeComponent()
   End Sub

   Private Sub WatershedDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      AddHandler _viewer.PostRender, AddressOf _viewer_Paint
      AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      AddHandler _form.FormClosing, AddressOf _form_FormClosing

      _maskImage = New RasterImage(_viewer.Image)
      Dim command As New FillCommand(RasterColor.White)
      command.Run(_maskImage)

      _orgImage = _viewer.Image.Clone()

      _lengths = New List(Of Integer)()
      _points = New List(Of List(Of Point))()
      _currentSegment = New List(Of Point)()

      _segIndex = -1
      _drawing = False

      _viewer.Cursor = Cursors.Cross
   End Sub

   Private Sub _form_FormClosing(sender As Object, e As FormClosingEventArgs)
      Me.Close()
   End Sub

   Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
      If _viewer.ViewBounds.Contains(LeadPoint.Create(e.X, e.Y)) Then
         If _drawing Then
            _currentSegment.Add(New Point(e.X, e.Y))
            _viewer.Invalidate()
         End If
      End If
   End Sub

   Private Sub _viewer_MouseUp(sender As Object, e As MouseEventArgs)
      If e.Button = MouseButtons.Left Then
         _drawing = False
         Dim lst As New List(Of Point)(_currentSegment)
         _points.Add(lst)
         _currentSegment.Clear()
         ApplyWatershed()
      End If
   End Sub

   Private Sub _viewer_MouseDown(sender As Object, e As MouseEventArgs)
      If e.Button = MouseButtons.Left Then
         _drawing = True
         _segIndex += 1
         _viewer.Image = _orgImage.Clone()
         _viewer.Invalidate()
      End If
   End Sub

   Private Sub _viewer_Paint(sender As Object, e As ImageViewerRenderEventArgs)
      If _currentSegment.Count >= 2 Then
         e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, _currentSegment.ToArray())
      End If

      For Each pnts As List(Of Point) In _points
         If pnts.Count >= 2 Then
            e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, pnts.ToArray())
         End If
      Next
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      _viewer.Image = _orgImage.Clone()
      _orgImage.Dispose()
      Me.Close()
   End Sub

   Private Sub WatershedDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      RemoveHandler _viewer.PostRender, AddressOf _viewer_Paint
      RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      _viewer.Cursor = Cursors.[Default]
      _viewer.Invalidate()

      _mainForm.IsSegmentation = False
      _mainForm.UpdateMyControls()
   End Sub

   Private Sub _btnReset_Click(sender As Object, e As EventArgs) Handles _btnReset.Click
      _points.Clear()
      _currentSegment.Clear()
      _viewer.Image = _orgImage.Clone()
      _viewer.Invalidate()
   End Sub

   Private Sub ApplyWatershed()
      If _points.Count > 0 Then
         _viewer.Image = _orgImage.Clone()

         Dim command As New WatershedCommand()

         Dim points As LeadPoint()() = New LeadPoint(_points.Count - 1)() {}

         Dim xFactor As Double = _viewer.XScaleFactor
         Dim yFactor As Double = _viewer.YScaleFactor

         Dim xOffset As Integer = _viewer.ViewBounds.Left
         Dim yOffset As Integer = _viewer.ViewBounds.Top

         For idx As Integer = 0 To points.Length - 1
            points(idx) = New LeadPoint(_points.ToArray()(idx).ToArray().Length - 1) {}

            For idx2 As Integer = 0 To points(idx).Length - 1
               points(idx)(idx2).X = CInt((_points.ToArray()(idx).ToArray()(idx2).X - xOffset) * 1.0 / xFactor + 0.5)
               points(idx)(idx2).Y = CInt((_points.ToArray()(idx).ToArray()(idx2).Y - yOffset) * 1.0 / yFactor + 0.5)
            Next
         Next

         command.PointsArray = points

         command.Run(_viewer.Image)
         _viewer.Invalidate()
      End If
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      ApplyWatershed()
      TryCast(_mainForm.ActiveMdiChild, ViewerForm).addToImageList()
      TryCast(_mainForm.ActiveMdiChild, ViewerForm).UpdateAfterCommandExecution()
      Me.Close()
   End Sub
End Class
