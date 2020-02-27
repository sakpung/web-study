' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.Codecs

Namespace ImageProcessingDemo
   Public Class ImageViewerAddMagicWandInteractivMode
      Inherits ImageViewerInteractiveMode
      Private _threshold As Integer
      Private _regionCombineMode As RasterRegionCombineMode

      Public Sub New()
         _threshold = 25
      End Sub

      Public Overrides ReadOnly Property Name() As String
         Get
            Return "AddMagicWand"
         End Get
      End Property

      Public Property Threshold As Integer
         Get
            Return _threshold
         End Get
         Set(value As Integer)
            _threshold = value
         End Set
      End Property

      Public Property MagicWandRegionCombineMode As RasterRegionCombineMode

         Get
            Return _regionCombineMode
         End Get
         Set(value As RasterRegionCombineMode)
            _regionCombineMode = value
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
         Dim MyViewer As ImageViewer = Me.ImageViewer

         Dim MyMatrix As LeadMatrix = MyViewer.ImageTransform
         Dim t As New Transformer(New System.Drawing.Drawing2D.Matrix(CSng(MyMatrix.M11), CSng(MyMatrix.M12), CSng(MyMatrix.M21), CSng(MyMatrix.M22), CSng(MyMatrix.OffsetX), CSng(MyMatrix.OffsetY)))

         Dim pt As LeadPoint = MagicWandPoint

         pt = MyViewer.Image.PointToImage(RasterViewPerspective.TopLeft, pt)

         Dim ptF As PointF = t.PointToLogical(New PointF(pt.X, pt.Y))

         Dim lowerColor As New RasterColor(255, 255, 255)
         Dim upperColor As New RasterColor(0, 0, 0)

         Dim RegionData As Byte() = RasterRegionConverter.GetGdiRegionData(MyViewer.Image, Nothing)

         If (CInt(ptF.X) > MyViewer.Image.Width) OrElse (CInt(ptF.Y) > MyViewer.Image.Height) Then
            Return
         ElseIf (CInt(ptF.X) > 0) AndAlso (CInt(ptF.Y) > 0) Then
            If RegionData Is Nothing Then
               MyViewer.Image.AddMagicWandToRegion(CInt(ptF.X), CInt(ptF.Y), lowerColor, upperColor, RasterRegionCombineMode.[Set])
            ElseIf (RegionData.Length = 32) AndAlso (MagicWandRegionCombineMode = RasterRegionCombineMode.[And]) Then
               MyViewer.Image.AddMagicWandToRegion(CInt(ptF.X), CInt(ptF.Y), lowerColor, upperColor, RasterRegionCombineMode.[Set])
            Else
               MyViewer.Image.AddMagicWandToRegion(CInt(ptF.X), CInt(ptF.Y), lowerColor, upperColor, MagicWandRegionCombineMode)
            End If
         End If
      End Sub
   End Class
End Namespace
