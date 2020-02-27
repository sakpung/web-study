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
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Controls
Imports System

Partial Public Class ShrinkWrapDialog
   Inherits Form
   Private _viewer As ImageViewer
   Private _form As ViewerForm
   Private _mainForm As MainForm

   Private _radius As Integer
   Private _center As LeadPoint
   Private command As ShrinkWrapCommand
   Private _curntMousePoint As LeadPoint
   Private _drawing As Boolean
   Private _mousedown As Boolean
   Private _isCircle As Boolean

   Public Sub New(form As MainForm, viewer As ViewerForm)
      InitializeComponent()
      _mainForm = form
      _form = viewer
      _viewer = viewer.Viewer
      _cbType.SelectedIndex = 0
      _cbCombine.SelectedIndex = 1
      _form.DisableInteractiveModes(_form.Viewer)
      _form.Viewer.InteractiveModes.EnableById(_form.NoneInteractiveMode.Id)

      _isCircle = True
   End Sub

   Private Sub _btnApply_Click(sender As Object, e As EventArgs) Handles _btnApply.Click
      If command IsNot Nothing Then
         _drawing = True
         command.Threshold = CInt(_numThreshold.Value)
         command.Flags = If((_cbType.SelectedIndex = 0), ShrinkWrapFlags.ShrinkCircle, ShrinkWrapFlags.ShrinkRect)
         _isCircle = (_cbType.SelectedIndex = 0)
         Return
      End If

      command = New ShrinkWrapCommand()
      command.Threshold = CInt(_numThreshold.Value)
      command.Flags = If((_cbType.SelectedIndex = 0), ShrinkWrapFlags.ShrinkCircle, ShrinkWrapFlags.ShrinkRect)
      AddHandler _viewer.PostRender, AddressOf _viewer_PostRender
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      AddHandler _form.FormClosing, AddressOf _form_FormClosing
      _drawing = True
      _mousedown = False
      _isCircle = (_cbType.SelectedIndex = 0)
   End Sub

   Private Sub _form_FormClosing(sender As Object, e As FormClosingEventArgs)
      Me.Close()
      _mainForm.IsSegmentation = False
      _mainForm.UpdateMyControls()
   End Sub

   Private Sub _viewer_MouseUp(sender As Object, e As MouseEventArgs)
      If command IsNot Nothing AndAlso e.Button = MouseButtons.Left AndAlso _drawing AndAlso _mousedown Then
         Dim xFactor As Double = _viewer.XScaleFactor
         Dim yFactor As Double = _viewer.YScaleFactor

         Dim xOffset As Integer = _viewer.ClientRectangle.Left
         Dim yOffset As Integer = _viewer.ClientRectangle.Top

         Dim pnt As New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))

         _curntMousePoint = pnt
         _radius = Length(_center, _curntMousePoint)

         _drawing = False
         _mousedown = False

         If _radius <= 1 Then
            _viewer.Invalidate()
            Return
         End If

         command.Center = _center
         command.Radius = Math.Min(_radius, Math.Max(_viewer.Image.Width, _viewer.Image.Height))

         Try
            command.Flags = If((_isCircle), ShrinkWrapFlags.ShrinkCircle, ShrinkWrapFlags.ShrinkRect)
            command.Flags = command.Flags Or CType(_cbCombine.SelectedIndex, ShrinkWrapFlags)
            command.Run(_viewer.Image)
         Catch ex As System.Exception
            Messager.ShowError(Me, ex)

         End Try
      End If
   End Sub

   Private Sub _viewer_MouseDown(sender As Object, e As MouseEventArgs)
      If command IsNot Nothing AndAlso e.Button = MouseButtons.Left Then
         If _viewer.ViewBounds.Contains(LeadPoint.Create(e.X, e.Y)) Then
            Dim xFactor As Double = _viewer.XScaleFactor
            Dim yFactor As Double = _viewer.YScaleFactor

            Dim xOffset As Integer = _viewer.ClientRectangle.Left
            Dim yOffset As Integer = _viewer.ClientRectangle.Top

            Dim pnt As New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))

            _drawing = True
            _mousedown = True
            _center = pnt
            _curntMousePoint = _center
            _viewer.Invalidate()

            If _viewer.InteractiveModes.FindById(_form.FloaterInteractiveMode.Id).IsEnabled Then
               _form.DisableInteractiveModes(_viewer)
               _viewer.InteractiveModes.EnableById(_form.NoneInteractiveMode.Id)
               Try
                  If _viewer.Floater IsNot Nothing Then
                     Dim xForm As New RasterRegionXForm()
                     xForm.ViewPerspective = RasterViewPerspective.TopLeft
                     xForm.XOffset = CInt(_viewer.FloaterTransform.OffsetX)
                     xForm.YOffset = CInt(_viewer.FloaterTransform.OffsetY)
                     xForm.YScalarDenominator = 1
                     xForm.XScalarDenominator = 1
                     xForm.XScalarNumerator = 1
                     xForm.YScalarNumerator = 1

                     _viewer.Image.SetRegion(xForm, _viewer.Floater.GetRegion(Nothing), RasterRegionCombineMode.[Set])

                     _viewer.Floater.Dispose()
                     _viewer.Floater = Nothing
                  End If
               Catch ex As Exception
                  Messager.ShowError(Me, ex)
               End Try
            End If
         End If
      End If
   End Sub


   Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
      If command IsNot Nothing AndAlso e.Button = MouseButtons.Left AndAlso _drawing AndAlso _mousedown Then
         Dim xFactor As Double = _viewer.XScaleFactor
         Dim yFactor As Double = _viewer.YScaleFactor

         Dim xOffset As Integer = _viewer.ClientRectangle.Left
         Dim yOffset As Integer = _viewer.ClientRectangle.Top

         Dim pnt As New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))
         _curntMousePoint = pnt
         _viewer.Invalidate()
      End If
   End Sub

   Private Function RectFromCenterRadius(center As LeadPoint, radius As Integer) As Rectangle
      Return New Rectangle(New Point(center.X - radius, center.Y - radius), New Size(radius * 2, radius * 2))
   End Function

   Private Function Length(center As LeadPoint, current As LeadPoint) As Integer
      Dim xDiff As Integer = center.X - current.X
      Dim yDiff As Integer = center.Y - current.Y

      Return CInt(Math.Sqrt(CDbl(xDiff * xDiff + yDiff * yDiff)) + 0.5)
   End Function


   Private Sub _viewer_PostRender(sender As Object, args As ImageViewerRenderEventArgs)
      Dim e As PaintEventArgs = args.PaintEventArgs

      If command IsNot Nothing Then
         If _drawing Then
            Dim xFactor As Double = _viewer.XScaleFactor
            Dim yFactor As Double = _viewer.YScaleFactor
            Dim xOffset As Single = -_viewer.DisplayRectangle.Left
            Dim yOffset As Single = -_viewer.DisplayRectangle.Top
            Dim center As New LeadPoint(CInt((_center.X + xOffset) * xFactor + 0.5), CInt((_center.Y + yOffset) * yFactor + 0.5))
            Dim current As New LeadPoint(CInt((_curntMousePoint.X + xOffset) * xFactor + 0.5), CInt((_curntMousePoint.Y + yOffset) * yFactor + 0.5))

            Dim Radius As Integer = Length(center, current)

            e.Graphics.FillEllipse(Brushes.Red, RectFromCenterRadius(center, 2))
            e.Graphics.IntersectClip(_viewer.ClientRectangle)

            If Not _isCircle Then
               e.Graphics.DrawRectangle(Pens.Yellow, RectFromCenterRadius(center, Radius))
            Else
               e.Graphics.DrawEllipse(Pens.Yellow, RectFromCenterRadius(center, Radius))
            End If
         End If
      End If
   End Sub

   Private Sub ShrinkWrapDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      RemoveHandler _viewer.PostRender, AddressOf _viewer_PostRender
      RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp

      Try
         If _viewer.Image.HasRegion Then
            _viewer.ActiveItem.ImageRegionToFloater()
            _viewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.[Set])
            _form.DisableInteractiveModes(_viewer)
            _viewer.InteractiveModes.EnableById(_form.FloaterInteractiveMode.Id)
            _viewer.FloaterOpacity = 1
         End If
         _viewer.Invalidate()
      Catch generatedExceptionName As Exception
         'ex
      End Try
      _mainForm.IsSegmentation = False
      _mainForm.UpdateMyControls()
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Me.Close()
   End Sub
End Class
