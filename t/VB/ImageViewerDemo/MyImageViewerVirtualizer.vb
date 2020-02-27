' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Drawing

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Svg
Imports Leadtools.Controls

Class MyImageViewerVirtualizer
   Inherits ImageViewerVirtualizer
   ' The file containing the image
   Private _imageFileName As String
   ' The LEADTOOLS Raster Codecs objects to use when loading the images (or SVG)
   Private _rasterCodecs As RasterCodecs
   Private _useSVG As Boolean

   Public Sub New(imageFileName As String, rasterCodecs As RasterCodecs, useSVG As Boolean)
      MyBase.New()
      ' Save the parameters
      _imageFileName = imageFileName
      _rasterCodecs = rasterCodecs
      _useSVG = useSVG

      ' Number of items to keep cached in memory, the default is 16. Changing to 8
      Me.MaximumItems = 8
   End Sub

   Protected Overrides Function LoadItem(item As ImageViewerItem) As Object
      ' This method is called when an item comes into view
      ' and is not cached in memory

      ' For this example, all we need is to load the image
      ' from the original file. But we can also load other
      ' state and data from a database or using deserilization.

      ' In our demo, the item index is the page index
      ' However, we can use the item .Tag property or derive our
      ' own class to hold the data needed to load the page

      ' Index is 0-based, so add 1 to get the page number
      Dim pageNumber As Integer = Me.ImageViewer.Items.IndexOf(item) + 1

      ' Load the page and return it
      If _useSVG Then
         Dim svgDocument As SvgDocument = TryCast(_rasterCodecs.LoadSvg(_imageFileName, pageNumber, Nothing), SvgDocument)

         ' Ensure the SVG optimized for fast viewing
         MainForm.OptimizeForView(svgDocument)

         Return svgDocument
      Else
         Dim rasterImage As RasterImage = _rasterCodecs.Load(_imageFileName, 0, CodecsLoadByteOrder.BgrOrGray, pageNumber, pageNumber)
         Return rasterImage
      End If
   End Function

   Protected Overrides Sub SaveItem(item As ImageViewerItem, data As Object)
      ' This method is called when an item is about to be deleted
      ' from the cache. In this example, we do not have anything to do
      ' but you can modify the code if your application needs to serialize
      ' data to disk or a database for example
   End Sub

   Protected Overrides Sub DeleteItem(item As ImageViewerItem, data As Object)
      ' This method is called when the item is no longer used
      ' In this example, we simply dispose the RasterImage/SvgDocument we loaded

      ' Check if it is a raster image
      Dim rasterImage As RasterImage = TryCast(data, RasterImage)
      If rasterImage IsNot Nothing Then
         rasterImage.Dispose()
         Return
      End If

      ' Check if it is an SVG document
      Dim svgDocument As SvgDocument = TryCast(data, SvgDocument)
      If svgDocument IsNot Nothing Then
         svgDocument.Dispose()
         Return
      End If
   End Sub

   Protected Overrides Sub RenderItemPlaceholder(e As ImageViewerRenderEventArgs)
      ' This method is called while an item is being loaded and give us a chance
      ' to offer a hint to the user

      ' Lets render a Loading ... message on the item
      Dim transform As LeadMatrix = Me.ImageViewer.GetItemImageTransform(e.Item)

      Dim graphics As Graphics = e.PaintEventArgs.Graphics
      Dim pt As LeadPointD = LeadPointD.Create(0, 0)
      pt = transform.Transform(pt)
      graphics.DrawString("Loading...", Me.ImageViewer.Font, Brushes.Black, CSng(pt.X), CSng(pt.Y))
   End Sub
End Class
