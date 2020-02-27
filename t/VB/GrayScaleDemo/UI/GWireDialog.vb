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
Imports Leadtools.ImageProcessing
Imports System

Partial Public Class GWireDialog
   Inherits Form
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

   Public Sub New(viewer As ViewerForm, mainForm As MainForm)
      _form = viewer
      _viewer = viewer.Viewer
      _mainForm = mainForm
      AddHandler _form.FormClosing, AddressOf _form_FormClosing
      _form.DisableInteractiveModes(_form.Viewer)
      _form.Viewer.InteractiveModes.EnableById(_form.NoneInteractiveMode.Id)

      InitializeComponent()
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      FinishGWire()
      TryCast(_mainForm.ActiveMdiChild, ViewerForm).addToImageList()
      Me.Close()
   End Sub

   Private Sub _bntApply_Click(sender As Object, e As EventArgs) Handles _bntApply.Click
      StartGWire(CInt(_numExternal.Value))
   End Sub

   Public Sub StartGWire(ExternalEnergy As Integer)
      If _gwireCommand IsNot Nothing Then
         Return
      End If

      Dim image As RasterImage = _viewer.Image

      Try
         If _viewer.Floater IsNot Nothing Then
            _viewer.Floater.Dispose()
            _viewer.Floater = Nothing
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
      End Try

      If image.HasRegion Then
         image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.[Set])
      End If

      If image.ViewPerspective <> RasterViewPerspective.TopLeft Then
         image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
      End If
      _gwireCommand = New GWireCommand(image, ExternalEnergy)
      _gwirePrevPath = New List(Of Point)()
      _anchorPoints = New List(Of Point)()

      AddHandler _viewer.MouseDown, AddressOf ActiveViewerForm_MouseDown
      AddHandler _viewer.MouseMove, AddressOf ActiveViewerForm_MouseMove
      AddHandler _viewer.PostRender, AddressOf _viewer_PostRender

      _gwireStarted = True
      _gwireSeedSelected = _gwireNewSeed = False
   End Sub


   Private Sub _form_FormClosing(sender As Object, e As FormClosingEventArgs)
      Me.Close()
      _mainForm.IsSegmentation = False
      _mainForm.UpdateMyControls()
   End Sub

   Private Function CreateRectangleFromPoint(point As Point) As Rectangle
      Dim size As Integer = 3
      Return New Rectangle(point.X - size, point.Y - size, size * 2, size * 2)
   End Function

   Private Sub _viewer_PostRender(sender As Object, args As ImageViewerRenderEventArgs)
      Dim e As PaintEventArgs = args.PaintEventArgs

      If _gwireCommand IsNot Nothing Then
         If _gwireStarted Then
            If _gwirePath IsNot Nothing AndAlso _anchorPoints IsNot Nothing Then
               Dim xFactor As Double = _viewer.XScaleFactor
               Dim yFactor As Double = _viewer.YScaleFactor
               Dim xOffset As Single = -_viewer.DisplayRectangle.Left
               Dim yOffset As Single = -_viewer.DisplayRectangle.Top

               Try
                  If _gwirePath.Length > 1 Then
                     Dim currentPath As Point() = CType(_gwirePath.Clone(), Point())
                     For idx As Integer = 0 To currentPath.Length - 1
                        currentPath(idx).X = CInt(xFactor * (currentPath(idx).X + xOffset) + 0.5)
                        currentPath(idx).Y = CInt(yFactor * (currentPath(idx).Y + yOffset) + 0.5)
                     Next
                     e.Graphics.DrawLines(Pens.Yellow, currentPath)
                  End If
                  If _gwirePrevPath IsNot Nothing Then
                     If _gwirePrevPath.Count > 1 Then
                        Dim oldPath As Point() = _gwirePrevPath.ToArray()
                        For idx As Integer = 0 To oldPath.Length - 1
                           oldPath(idx).X = CInt(xFactor * (oldPath(idx).X + xOffset) + 0.5)
                           oldPath(idx).Y = CInt(yFactor * (oldPath(idx).Y + yOffset) + 0.5)
                        Next
                        e.Graphics.DrawLines(Pens.Yellow, oldPath)
                     End If
                  End If

                  For i As Integer = 0 To _anchorPoints.Count - 1
                     e.Graphics.FillEllipse(Brushes.Yellow, CreateRectangleFromPoint(New Point(CInt((_anchorPoints(i).X + xOffset) * xFactor + 0.5), CInt((_anchorPoints(i).Y + yOffset) * yFactor + 0.5))))
                  Next
               Catch ex As System.Exception
                  Messager.ShowError(Nothing, ex)
               End Try
            End If
         End If
      End If
   End Sub

   Private Sub ActiveViewerForm_MouseMove(sender As Object, e As MouseEventArgs)
      If _gwireCommand IsNot Nothing Then
         _viewer.Cursor = Cursors.Cross
         If _gwireStarted Then

            If _gwireSeedSelected AndAlso _viewer.ClientRectangle.Contains(e.Location) Then
               Dim xFactor As Double = _viewer.XScaleFactor
               Dim yFactor As Double = _viewer.YScaleFactor

               Dim xOffset As Integer = _viewer.ClientRectangle.Left
               Dim yOffset As Integer = _viewer.ClientRectangle.Top

               Dim GWirePath As LeadPoint() = _gwireCommand.GetMinPath(New LeadPoint(CInt((e.X - xOffset) * 1.0 / xFactor + 0.5), CInt((e.Y - yOffset) * 1.0 / yFactor + 0.5)))

               If GWirePath IsNot Nothing Then
                  If _gwireNewSeed Then
                     If _gwirePath IsNot Nothing Then
                        _gwirePrevPath.AddRange(_gwirePath)
                        _gwireNewSeed = False
                     End If
                  End If

                  _gwirePath = New Point(GWirePath.Length - 1) {}

                  For i As Integer = 0 To GWirePath.Length - 1
                     _gwirePath(i).X = GWirePath(i).X
                     _gwirePath(i).Y = GWirePath(i).Y
                  Next

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

      If _gwirePath IsNot Nothing AndAlso _gwirePrevPath IsNot Nothing Then
         Dim prevPathLength As Integer = _gwirePrevPath.Count
         Dim curPathLength As Integer = _gwirePath.Length

         Dim pts As New List(Of LeadPoint)()
         For i As Integer = 0 To prevPathLength - 1
            pts.Add(New LeadPoint(_gwirePrevPath(i).X, _gwirePrevPath(i).Y))
         Next
         For i As Integer = 0 To curPathLength - 1
            pts.Add(New LeadPoint(_gwirePath(i).X, _gwirePath(i).Y))
         Next

         _viewer.Image.AddPolygonToRegion(Nothing, pts.ToArray(), LeadFillMode.Alternate, RasterRegionCombineMode.[Set])
         _viewer.ActiveItem.ImageRegionToFloater()
         _viewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.[Set])
         _form.DisableInteractiveModes(_viewer)
         _viewer.InteractiveModes.EnableById(_form.FloaterInteractiveMode.Id)
         _viewer.FloaterOpacity = 1
      End If

      RemoveHandler _viewer.MouseDown, AddressOf ActiveViewerForm_MouseDown
      RemoveHandler _viewer.MouseMove, AddressOf ActiveViewerForm_MouseMove
      RemoveHandler _viewer.PostRender, AddressOf _viewer_PostRender
      _viewer.Cursor = Cursors.[Default]
      _gwireCommand = Nothing
      _gwireSeedSelected = _gwireStarted = _gwireNewSeed = False
      _gwirePrevPath = Nothing
      _gwirePath = Nothing


      _viewer.Invalidate()
   End Sub

   Private Sub ActiveViewerForm_MouseDown(sender As Object, e As MouseEventArgs)
      If e.Button = MouseButtons.Left Then
         If _gwireCommand IsNot Nothing Then
            If _gwireStarted Then
               If _viewer.ClientRectangle.Contains(e.Location) Then
                  Dim xFactor As Double = _viewer.XScaleFactor
                  Dim yFactor As Double = _viewer.YScaleFactor

                  Dim xOffset As Integer = _viewer.ClientRectangle.Left
                  Dim yOffset As Integer = _viewer.ClientRectangle.Top
                  Dim x As Integer = CInt((e.X - xOffset) * 1.0F / xFactor + 0.5)
                  Dim y As Integer = CInt((e.Y - yOffset) * 1.0F / yFactor + 0.5)
                  If Not _gwireSeedSelected Then
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

   Private Sub GWireDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      _mainForm.IsSegmentation = False
      _mainForm.UpdateMyControls()
      _form.IsPerspective = False
   End Sub
End Class
