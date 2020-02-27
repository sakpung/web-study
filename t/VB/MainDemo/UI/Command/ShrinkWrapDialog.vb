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

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Controls
Imports System.Drawing.Drawing2D
Imports Leadtools.Drawing

Namespace MainDemo
   Partial Public Class ShrinkWrapDialog : Inherits Form
      Private _radius As Integer
      Private _center As LeadPoint
      Private _viewer As ImageViewer
      Private _form As ViewerForm
      Private _mainForm As MainForm
      Private command As ShrinkWrapCommand
      Private _curntMousePoint As LeadPoint
      Private _drawing As Boolean
      Private _isCircle As Boolean

      Public Sub New(ByVal form As MainForm, ByVal viewer As ViewerForm)
         InitializeComponent()
         _mainForm = form
         _form = viewer
         _viewer = viewer.Viewer
         _cbType.SelectedIndex = 0
         _cbCombine.SelectedIndex = 1
         _isCircle = True
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         If Not command Is Nothing Then
            _drawing = True
            command.Threshold = CInt(_numThreshold.Value)
            If (_cbType.SelectedIndex = 0) Then
               command.Flags = ShrinkWrapFlags.ShrinkCircle
            Else
               command.Flags = ShrinkWrapFlags.ShrinkRect
            End If
            _isCircle = (_cbType.SelectedIndex = 0)
            Return
         End If

         command = New ShrinkWrapCommand()
         command.Threshold = CInt(_numThreshold.Value)
         If (_cbType.SelectedIndex = 0) Then
            command.Flags = ShrinkWrapFlags.ShrinkCircle
         Else
            command.Flags = ShrinkWrapFlags.ShrinkRect
         End If
         AddHandler _viewer.PostRender, AddressOf _viewer_Paint
         AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
         AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
         AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
         AddHandler _form.FormClosing, AddressOf _form_FormClosing
         _drawing = True
         _isCircle = (_cbType.SelectedIndex = 0)
      End Sub

      Private Sub _form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
         Me.Close()
      End Sub

      Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
         If Not command Is Nothing AndAlso e.Button = MouseButtons.Left AndAlso _drawing Then
            Dim xFactor As Double = _viewer.XScaleFactor
            Dim yFactor As Double = _viewer.YScaleFactor

            Dim xOffset As Integer = _viewer.ViewBounds.Left
            Dim yOffset As Integer = _viewer.ViewBounds.Top

            Dim pnt As LeadPoint = New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))

            _curntMousePoint = pnt
            _radius = Length(_center, _curntMousePoint)

            _drawing = False

            If _radius <= 1 Then
               _viewer.Invalidate()
               Return
            End If

            command.Center = _center
            command.Radius = Math.Min(_radius, Math.Max(_viewer.Image.Width, _viewer.Image.Height))

            Try
               If (_isCircle) Then
                  command.Flags = ShrinkWrapFlags.ShrinkCircle
               Else
                  command.Flags = ShrinkWrapFlags.ShrinkRect
               End If
               command.Flags = command.Flags Or CType(_cbCombine.SelectedIndex, ShrinkWrapFlags)
               command.Run(_viewer.Image)
            Catch ex As System.Exception
               Messager.ShowError(Me, ex)
            End Try

         End If
      End Sub

      Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
         If Not command Is Nothing AndAlso e.Button = MouseButtons.Left Then
            Dim xFactor As Double = _viewer.XScaleFactor
            Dim yFactor As Double = _viewer.YScaleFactor

            Dim xOffset As Integer = _viewer.ViewBounds.Left
            Dim yOffset As Integer = _viewer.ViewBounds.Top

            Dim pnt As LeadPoint = New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))

            _drawing = True
            _center = pnt
            _curntMousePoint = _center
            _viewer.Invalidate()


            If TypeOf _viewer.WorkingInteractiveMode Is ImageViewerFloaterInteractiveMode Then
               _mainForm.DisableAllInteractiveModes(_viewer)
               _form.Viewer.InteractiveModes.BeginUpdate()
               _form.NoneInteractiveMode.IsEnabled = True
               _form.Viewer.InteractiveModes.EndUpdate()
               Try
                  If Not _viewer.Floater Is Nothing Then
                     Dim xForm As RasterRegionXForm = New RasterRegionXForm()
                     xForm.ViewPerspective = RasterViewPerspective.TopLeft
                     'LeadMatrix mm = _viewer.FloaterTransform.OffsetY;
                     'Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
                     'Transformer t = new Transformer(m);
                     Dim floaterTransform As LeadMatrix = _viewer.FloaterTransform

                     xForm.XOffset = CInt(floaterTransform.OffsetX)
                     xForm.YOffset = CInt(floaterTransform.OffsetY)
                     xForm.YScalarDenominator = 1
                     xForm.XScalarDenominator = 1
                     xForm.XScalarNumerator = 1
                     xForm.YScalarNumerator = 1

                     _viewer.Image.SetRegion(xForm, _viewer.Floater.GetRegion(Nothing), RasterRegionCombineMode.Set)

                     _viewer.Floater.Dispose()
                     _viewer.Floater = Nothing

                  End If

               Catch ex As Exception
                  Messager.ShowError(Me, ex)
               End Try
            End If
         End If
      End Sub


      Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
         If Not command Is Nothing AndAlso e.Button = MouseButtons.Left AndAlso _drawing Then
            Dim xFactor As Double = _viewer.XScaleFactor
            Dim yFactor As Double = _viewer.YScaleFactor

            Dim xOffset As Integer = _viewer.ViewBounds.Left
            Dim yOffset As Integer = _viewer.ViewBounds.Top

            Dim pnt As LeadPoint = New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5))
            _curntMousePoint = pnt
            _viewer.Invalidate()
         End If
      End Sub

      Private Function RectFromCenterRadius(ByVal center As LeadPoint, ByVal radius As Integer) As Rectangle
         Return New Rectangle(New Point(center.X - radius, center.Y - radius), New Size(radius * 2, radius * 2))
      End Function

      Private Function Length(ByVal center As LeadPoint, ByVal current As LeadPoint) As Integer
         Dim xDiff As Integer = center.X - current.X
         Dim yDiff As Integer = center.Y - current.Y

         Return CInt(Math.Sqrt(CDbl(xDiff * xDiff + yDiff * yDiff)) + 0.5)
      End Function

      Private Sub _viewer_Paint(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
         If Not command Is Nothing Then
            If _drawing Then
               Dim xFactor As Double = _viewer.XScaleFactor
               Dim yFactor As Double = _viewer.YScaleFactor
               Dim xOffset As Single = -_viewer.ViewBounds.Left
               Dim yOffset As Single = -_viewer.ViewBounds.Top
               Dim center As LeadPoint = New LeadPoint(CInt((_center.X + xOffset) * xFactor + 0.5), CInt((_center.Y + yOffset) * yFactor + 0.5))
               Dim current As LeadPoint = New LeadPoint(CInt((_curntMousePoint.X + xOffset) * xFactor + 0.5), CInt((_curntMousePoint.Y + yOffset) * yFactor + 0.5))

               Dim Radius As Integer = Length(center, current)

               e.PaintEventArgs.Graphics.FillEllipse(Brushes.Red, RectFromCenterRadius(center, 2))
               e.PaintEventArgs.Graphics.IntersectClip(New Rectangle(_viewer.ViewBounds.X, _viewer.ViewBounds.Y, _viewer.ViewBounds.Width, _viewer.ViewBounds.Height))

               If (Not _isCircle) Then
                  e.PaintEventArgs.Graphics.DrawRectangle(Pens.Yellow, RectFromCenterRadius(center, Radius))
               Else
                  e.PaintEventArgs.Graphics.DrawEllipse(Pens.Yellow, RectFromCenterRadius(center, Radius))
               End If
            End If
         End If
      End Sub

      Private Sub ShrinkWrapDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         RemoveHandler _viewer.PostRender, AddressOf _viewer_Paint
         RemoveHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
         RemoveHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
         RemoveHandler _viewer.MouseUp, AddressOf _viewer_MouseUp

         _viewer.ActiveItem.ImageRegionToFloater()
         _viewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.Set)
         _mainForm.DisableAllInteractiveModes(_viewer)
         _form.Viewer.InteractiveModes.BeginUpdate()
         _form.FloaterInteractiveMode.IsEnabled = True
         _viewer.FloaterOpacity = 1.0 'Visible = true;
         _form.Viewer.InteractiveModes.EndUpdate()
         _viewer.Invalidate()

         _mainForm.InteractiveToolsList.Remove(_viewer)
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.Close()
      End Sub
   End Class
End Namespace
