' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Controls.Internal
Imports Leadtools.Drawing
Imports System.Drawing
Imports System

Namespace Leadtools.Controls
   Public Class ImageViewerAddMagicWandInteractivMode
      Inherits ImageViewerInteractiveMode
      Private _threshold As Integer

      Public Sub New()
         _threshold = 25
      End Sub

      Public Overrides ReadOnly Property Name() As String
         Get
            Return "AddMagicWand"
         End Get
      End Property

      Public Property Threshold() As Integer
         Get
            Return _threshold
         End Get
         Set(value As Integer)
            _threshold = value
         End Set
      End Property

      Public Overrides ReadOnly Property Id() As Integer
         Get
            Return ImageViewerInteractiveMode.UserModeId
         End Get
      End Property

      Public Overrides Sub Start(imageViewer As ImageViewer)
         MyBase.Start(imageViewer)
         Dim service As InteractiveService = MyBase.InteractiveService
         AddHandler service.Tap, AddressOf service_Tap
      End Sub

      Public Overrides Sub [Stop](imageViewer As ImageViewer)
         If IsStarted Then
            Dim service As InteractiveService = MyBase.InteractiveService
            AddHandler service.Tap, AddressOf service_Tap
            MyBase.[Stop](imageViewer)
         End If
      End Sub

      Private Sub service_Tap(sender As Object, e As InteractiveEventArgs)
         If CanStartWork(e) Then
            e.IsHandled = True
            OnWorkStarted(EventArgs.Empty)

            Dim imageViewer As ImageViewer = Me.ImageViewer

            imageViewer.BeginRender()
            AddMagicWand(e.Origin)
            imageViewer.EndRender()

            OnWorkCompleted(EventArgs.Empty)
         End If
      End Sub

      Private Sub AddMagicWand(MagicWandPoint As LeadPoint)
         Dim imageViewer As ImageViewer = Me.ImageViewer

         Dim MyMatrix As LeadMatrix = imageViewer.ImageTransform
         Dim t As New Transformer(New System.Drawing.Drawing2D.Matrix(CSng(MyMatrix.M11), CSng(MyMatrix.M12), CSng(MyMatrix.M21), CSng(MyMatrix.M22), CSng(MyMatrix.OffsetX), CSng(MyMatrix.OffsetY)))

         Dim pt As LeadPoint = MagicWandPoint

         pt = imageViewer.Image.PointToImage(RasterViewPerspective.TopLeft, pt)

         Dim ptF As PointF = t.PointToLogical(New PointF(pt.X, pt.Y))

         Dim lowerColor As New RasterColor(Threshold, Threshold, Threshold)
         Dim upperColor As New RasterColor(Threshold, Threshold, Threshold)

         If (CInt(Math.Truncate(ptF.X)) > imageViewer.Image.Width) OrElse (CInt(Math.Truncate(ptF.Y)) > imageViewer.Image.Height) Then
            Return
         Else
            If (CInt(Math.Truncate(ptF.X)) > 0) AndAlso (CInt(Math.Truncate(ptF.Y)) > 0) Then
               imageViewer.Image.AddMagicWandToRegion(CInt(Math.Truncate(ptF.X)), CInt(Math.Truncate(ptF.Y)), lowerColor, upperColor, RasterRegionCombineMode.[Set])
               imageViewer.ActiveItem.ImageRegionToFloater()
               imageViewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.Set)
            End If
         End If
      End Sub
   End Class
End Namespace
