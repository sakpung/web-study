' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools

Public Class DocumentConverterRasterFormat
   Public Sub New()
   End Sub

   ' Friendly name
   Private _friendlyName As String
   Public Property FriendlyName() As String
      Get
         Return _friendlyName
      End Get
      Set(value As String)
         _friendlyName = value
      End Set
   End Property

   ' Format to use when saving
   Private _rasterImageFormat As RasterImageFormat
   Public Property RasterImageFormat() As RasterImageFormat
      Get
         Return _rasterImageFormat
      End Get
      Set(value As RasterImageFormat)
         _rasterImageFormat = value
      End Set
   End Property

   ' Bits/pixel to use when saving
   Private _bitsPerPixel As Integer
   Public Property BitsPerPixel() As Integer
      Get
         Return _bitsPerPixel
      End Get
      Set(value As Integer)
         _bitsPerPixel = value
      End Set
   End Property

   ' Default file extension to use when saving
   Private _extension As String
   Public Property Extension() As String
      Get
         Return _extension
      End Get
      Set(value As String)
         _extension = value
      End Set
   End Property

   Public Overrides Function ToString() As String
      If Not String.IsNullOrEmpty(Me.Extension) Then
         Return String.Format("{0} ({1})", Me.FriendlyName, Me.Extension.ToUpperInvariant())
      Else
         Return Me.FriendlyName
      End If
   End Function
End Class
