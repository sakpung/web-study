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
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing

Namespace MainDemo
   Partial Public Class GWireDialog : Inherits Form
      Private _viewer As ImageViewer
      Private _form As ViewerForm
      Private _mainForm As MainForm

      Private _gwireCommand As GWireCommand
      Private _gwireStarted As Boolean
      Private _gwireSeedSelected As Boolean
      Private _gwireNewSeed As Boolean
      Private _gwirePath As Point()
      Private _gwirePrevPath As List(Of Point)

      Private _anchorPoints As List(Of Point)

      Public Sub New(ByVal viewer As ViewerForm, ByVal mainForm As MainForm)
         _form = viewer
         _viewer = viewer.Viewer
         _mainForm = mainForm
         AddHandler _form.FormClosing, AddressOf _form_FormClosing

         InitializeComponent()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         FinishGWire()
         Me.Close()
      End Sub

      Private Sub _bntApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _bntApply.Click
         StartGWire(CInt(_numExternal.Value))
      End Sub

      Public Sub StartGWire(ByVal ExternalEnergy As Integer)
         If Not _gwireCommand Is Nothing Then
            Return
         End If

         Dim image As RasterImage = _viewer.Image

         Try
            If Not _viewer.Floater Is Nothing Then
               _viewer.Floater.Dispose()
               _viewer.Floater = Nothing
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            _mainForm.UpdateControls()
         End Try

         If image.HasRegion Then
            image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.Set)
         End If

         If image.ViewPerspective <> RasterViewPerspective.TopLeft Then
            image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
         End If
         _gwireCommand = New GWireCommand(image, ExternalEnergy)
         _gwirePrevPath = New List(Of Point)()
         _anchorPoints = New List(Of Point)()

         AddHandler _viewer.MouseDown, AddressOf ActiveViewerForm_MouseDown
         AddHandler _viewer.MouseMove, AddressOf ActiveViewerForm_MouseMove
         AddHandler _viewer.PostRender, AddressOf ActiveViewerForm_Paint

         _gwireStarted = True
         _gwireSeedSelected = False
         _gwireNewSeed = False
      End Sub

      Private Sub _form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
         Me.Close()
      End Sub

      Private Function CreateRectangleFromPoint(ByVal point As Point) As Rectangle
         Dim size As Integer = 3
         Return New Rectangle(point.X - size, point.Y - size, size * 2, size * 2)
      End Function

      Private Sub ActiveViewerForm_Paint(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs)
         If Not _gwireCommand Is Nothing Then
            If _gwireStarted Then
               If Not _gwirePath Is Nothing AndAlso Not _anchorPoints Is Nothing Then
                  Dim xFactor As Double = _viewer.XScaleFactor
                  Dim yFactor As Double = _viewer.YScaleFactor
                  Dim xOffset As Single = -_viewer.ImageBounds.Left
                  Dim yOffset As Single = -_viewer.ImageBounds.Top

                  Try
                     If _gwirePath.Length > 1 Then
                        Dim currentPath As Point() = CType(_gwirePath.Clone(), Point())
                        Dim idx As Integer = 0
                        Do While idx < currentPath.Length
                           currentPath(idx).X = CInt(xFactor * (currentPath(idx).X + xOffset) + 0.5)
                           currentPath(idx).Y = CInt(yFactor * (currentPath(idx).Y + yOffset) + 0.5)
                           idx += 1
                        Loop
                        e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, currentPath)
                     End If
                     If Not _gwirePrevPath Is Nothing Then
                        If _gwirePrevPath.Count > 1 Then
                           Dim oldPath As Point() = _gwirePrevPath.ToArray()
                           Dim idx As Integer = 0
                           Do While idx < oldPath.Length
                              oldPath(idx).X = CInt(xFactor * (oldPath(idx).X + xOffset) + 0.5)
                              oldPath(idx).Y = CInt(yFactor * (oldPath(idx).Y + yOffset) + 0.5)
                              idx += 1
                           Loop
                           e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, oldPath)
                        End If
                     End If

                     Dim i As Integer = 0
                     Do While i < _anchorPoints.Count
                        e.PaintEventArgs.Graphics.FillEllipse(Brushes.Yellow, CreateRectangleFromPoint(New Point(CInt((_anchorPoints(i).X + xOffset) * xFactor + 0.5), CInt((_anchorPoints(i).Y + yOffset) * yFactor + 0.5))))
                        i += 1
                     Loop
                  Catch ex As System.Exception
                     Messager.ShowError(Nothing, ex)
                  End Try
               End If
            End If
         End If
      End Sub

      Private Sub ActiveViewerForm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
         If Not _gwireCommand Is Nothing Then
            _viewer.Cursor = Cursors.Cross
            If _gwireStarted Then

               If _gwireSeedSelected AndAlso _viewer.ViewBounds.Contains(LeadPoint.Create(e.Location.X, e.Location.Y)) Then
                  Dim xFactor As Double = _viewer.XScaleFactor
                  Dim yFactor As Double = _viewer.YScaleFactor

                  Dim xOffset As Integer = _viewer.ViewBounds.Left
                  Dim yOffset As Integer = _viewer.ViewBounds.Top

                  Dim GWirePath As LeadPoint() = _gwireCommand.GetMinPath(New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5)))

                  If Not GWirePath Is Nothing Then
                     If _gwireNewSeed Then
                        If Not _gwirePath Is Nothing Then
                           _gwirePrevPath.AddRange(_gwirePath)
                           _gwireNewSeed = False
                        End If
                     End If

                     _gwirePath = New Point(GWirePath.Length - 1) {}

                     Dim i As Integer = 0
                     Do While i < GWirePath.Length
                        _gwirePath(i).X = GWirePath(i).X
                        _gwirePath(i).Y = GWirePath(i).Y
                        i += 1
                     Loop

                     _viewer.Invalidate()
                  End If
               End If
            End If
         End If
      End Sub

      Public Sub FinishGWire()
         If _gwireCommand Is Nothing Then
            Return
         End If

         If Not _gwirePath Is Nothing AndAlso Not _gwirePrevPath Is Nothing Then
            Dim prevPathLength As Integer = _gwirePrevPath.Count
            Dim curPathLength As Integer = _gwirePath.Length

            Dim pts As List(Of LeadPoint) = New List(Of LeadPoint)()
            Dim i As Integer = 0
            Do While i < prevPathLength
               pts.Add(New LeadPoint(_gwirePrevPath(i).X, _gwirePrevPath(i).Y))
               i += 1
            Loop
            i = 0
            Do While i < curPathLength
               pts.Add(New LeadPoint(_gwirePath(i).X, _gwirePath(i).Y))
               i += 1
            Loop

            _viewer.Image.AddPolygonToRegion(Nothing, pts.ToArray(), LeadFillMode.Alternate, RasterRegionCombineMode.Set)
            _viewer.ActiveItem.ImageRegionToFloater()
            _viewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.Set)
            _mainForm.DisableAllInteractiveModes(_viewer)
            _viewer.InteractiveModes.BeginUpdate()
            _form.FloaterInteractiveMode.IsEnabled = True
            _viewer.FloaterOpacity = 1.0
            _viewer.InteractiveModes.EndUpdate()
         End If

         RemoveHandler _viewer.MouseDown, AddressOf ActiveViewerForm_MouseDown
         RemoveHandler _viewer.MouseMove, AddressOf ActiveViewerForm_MouseMove
         RemoveHandler _viewer.PostRender, AddressOf ActiveViewerForm_Paint
         _viewer.Cursor = Cursors.Default
         _gwireCommand.Dispose()
         _gwireCommand = Nothing
         _gwireSeedSelected = False
         _gwireStarted = False
         _gwireNewSeed = False
         _gwirePrevPath = Nothing
         _gwirePath = Nothing

         _viewer.Invalidate()
      End Sub

      Private Sub ActiveViewerForm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
         If e.Button = MouseButtons.Left Then
            If Not _gwireCommand Is Nothing Then
               If _gwireStarted Then
                  If _viewer.ViewBounds.Contains(LeadPoint.Create(e.Location.X, e.Location.Y)) Then
                     Dim xFactor As Double = _viewer.XScaleFactor
                     Dim yFactor As Double = _viewer.YScaleFactor

                     Dim xOffset As Integer = _viewer.ViewBounds.Left
                     Dim yOffset As Integer = _viewer.ViewBounds.Top
                     Dim x As Integer = CInt((e.X - xOffset) * 1.0F / xFactor + 0.5)
                     Dim y As Integer = CInt((e.Y - yOffset) * 1.0F / yFactor + 0.5)
                     If (Not _gwireSeedSelected) Then
                        _gwireCommand.SetSeedPoint(New LeadPoint(x, y))
                        Application.DoEvents()

                        _gwireSeedSelected = True
                        _gwireNewSeed = False
                        _anchorPoints.Add(New Point(x, y))
                     Else
                        _gwireCommand.SetSeedPoint(New LeadPoint(x, y))
                        _gwireNewSeed = True
                        _anchorPoints.Add(New Point(x, y))
                        Dim rect As Rectangle = CreateRectangleFromPoint(New Point(x, y))
                        If rect.Contains(_anchorPoints(0)) Then
                           FinishGWire()
                        End If
                     End If
                  End If
               End If
            End If
         ElseIf e.Button = MouseButtons.Right Then
            FinishGWire()
         End If
      End Sub

      Private Sub GWireDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         _mainForm.InteractiveToolsList.Remove(_viewer)
      End Sub
   End Class
End Namespace
