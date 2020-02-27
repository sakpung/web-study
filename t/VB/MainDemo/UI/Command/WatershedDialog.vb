' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing

Namespace MainDemo
   Partial Public Class WatershedDialog : Inherits Form
      Private _viewer As ImageViewer
      Private _form As ViewerForm
      Private _mainForm As MainForm
      Private _lengths As List(Of Integer)
      Private _points As List(Of List(Of Point)) '// = New List(List Of Point)()
      Private _currentSegment As List(Of Point)
      Private _segIndex As Integer
      Private _drawing As Boolean
      Private _maskImage As RasterImage
      Private _orgImage As RasterImage

      Public Sub New(ByVal form As MainForm, ByVal viewer As ViewerForm)
         _mainForm = form
         _form = viewer
         _viewer = viewer.Viewer

         InitializeComponent()
      End Sub

      Private Sub WatershedDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         AddHandler _viewer.PostRender, AddressOf _viewer_Paint
         AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
         AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
         AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
         AddHandler _form.FormClosing, AddressOf _form_FormClosing

         _mainForm.DisableAllInteractiveModes(_viewer)

         _maskImage = New RasterImage(_viewer.Image)
         Dim command As FillCommand = New FillCommand(RasterColor.White)
         command.Run(_maskImage)

         _orgImage = _viewer.Image.Clone()

         _lengths = New List(Of Integer)()
         _points = New List(Of List(Of Point))()
         _currentSegment = New List(Of Point)()

         _segIndex = -1
         _drawing = False

         _viewer.Cursor = Cursors.Cross
      End Sub

      Private Sub _form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
         Me.Close()
      End Sub

      Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
         If _viewer.ViewBounds.Contains(LeadPoint.Create(e.X, e.Y)) Then
            If _drawing Then
               _currentSegment.Add(New Point(e.X, e.Y))
               _viewer.Invalidate()
            End If
         End If
      End Sub

      Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
         If e.Button = MouseButtons.Left Then
            _drawing = False
            Dim lst As List(Of Point) = New List(Of Point)(_currentSegment)
            _points.Add(lst)
            _currentSegment.Clear()
            ApplyWatershed()
         End If
      End Sub

      Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
         If e.Button = MouseButtons.Left Then
            _drawing = True
            _segIndex += 1
            Dim point As LeadPoint = _viewer.ScrollOffset
            _viewer.Image = _orgImage.Clone()
            _viewer.ScrollBy(point)
            _viewer.Invalidate()
         End If
      End Sub

      Private Sub _viewer_Paint(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
         If _currentSegment.Count >= 2 Then
            e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, _currentSegment.ToArray())
         End If

         For Each pnts As List(Of Point) In _points
            If pnts.Count >= 2 Then
               e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, pnts.ToArray())
            End If
         Next pnts
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Dim point As LeadPoint = _viewer.ScrollOffset
         _viewer.Image = _orgImage.Clone()
         _viewer.ScrollBy(point)
         _orgImage.Dispose()
         Me.Close()
      End Sub

      Private Sub WatershedDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         RemoveHandler _viewer.PostRender, AddressOf _viewer_Paint
         RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
         RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
         RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
         _viewer.Cursor = Cursors.Default
         _viewer.Invalidate()

         _mainForm.InteractiveToolsList.Remove(_viewer)
      End Sub

      Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         _points.Clear()
         _currentSegment.Clear()
         Dim point As LeadPoint = _viewer.ScrollOffset
         _viewer.Image = _orgImage.Clone()
         _viewer.ScrollBy(point)
         _viewer.Invalidate()
      End Sub

      Private Sub ApplyWatershed()
         If _points.Count > 0 Then
            Dim point As LeadPoint = _viewer.ScrollOffset
            _viewer.Image = _orgImage.Clone()
            _viewer.ScrollBy(point)

            Dim command As WatershedCommand = New WatershedCommand()

            Dim points As LeadPoint()() = New LeadPoint(_points.Count - 1)() {}

            Dim xFactor As Double = _viewer.XScaleFactor
            Dim yFactor As Double = _viewer.YScaleFactor

            Dim xOffset As Integer = _viewer.ViewBounds.Left
            Dim yOffset As Integer = _viewer.ViewBounds.Top

            Dim idx As Integer = 0
            Do While idx < points.Length
               points(idx) = New LeadPoint(_points.ToArray()(idx).ToArray().Length - 1) {}

               Dim idx2 As Integer = 0
               Do While idx2 < points(idx).Length
                  points(idx)(idx2).X = CInt((_points.ToArray()(idx).ToArray()(idx2).X - xOffset) * 1.0 / xFactor + 0.5)
                  points(idx)(idx2).Y = CInt((_points.ToArray()(idx).ToArray()(idx2).Y - yOffset) * 1.0 / yFactor + 0.5)
                  idx2 += 1
               Loop
               idx += 1
            Loop

            command.PointsArray = points

            command.Run(_viewer.Image)
            _viewer.Invalidate()
         End If
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         ApplyWatershed()
         Me.Close()
      End Sub
   End Class
End Namespace
