' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class DocumentInfoControl

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData(ByVal imageInfo As CodecsImageInfo, ByVal rasterCodecsInstance As RasterCodecs)
      ' Set the state of the controls

      If Not IsNothing(imageInfo) Then
         ' Get the index of the format in the DocumentFormats
         Dim index As Integer = DocumentFormats.GetFormatIndex(imageInfo.Format)

         Dim viewUnit As CodecsRasterizeDocumentUnit = rasterCodecsInstance.Options.RasterizeDocument.Load.Unit

         Dim originalWidth As Double
         Dim originalHeight As Double
         Dim originalUnit As CodecsRasterizeDocumentUnit

         If index <> -1 Then
            ' Document format
            _formatValueLabel.Text = String.Format("{0} ({1})", DocumentFormats.FormatFriendlyNames(index), DocumentFormats.Formats(index))

            originalWidth = imageInfo.Document.PageWidth
            originalHeight = imageInfo.Document.PageHeight
            originalUnit = imageInfo.Document.Unit

            _warningLabel.Visible = False
         Else
            ' Raster format
            _formatValueLabel.Text = imageInfo.Format.ToString()

            originalWidth = imageInfo.Width
            originalHeight = imageInfo.Height
            originalUnit = CodecsRasterizeDocumentUnit.Pixel

            _warningLabel.Visible = True
         End If

         _pagesValueLabel.Text = imageInfo.TotalPages.ToString()

         ' Convert to the view unit
         originalWidth = Units.Convert(originalWidth, originalUnit, Units.ScreenResolution, viewUnit)
         originalHeight = Units.Convert(originalHeight, originalUnit, Units.ScreenResolution, viewUnit)

         _originalDocumentSizeValueLabel.Text = Units.Format(originalWidth, originalHeight, viewUnit)

         Dim loadWidth As Double = Units.Convert(imageInfo.Width, CodecsRasterizeDocumentUnit.Pixel, imageInfo.XResolution, viewUnit)
         Dim loadHeight As Double = Units.Convert(imageInfo.Height, CodecsRasterizeDocumentUnit.Pixel, imageInfo.YResolution, viewUnit)
         _loadDocumentSizeValueLabel.Text = Units.Format(loadWidth, loadHeight, viewUnit)
         _loadDocumentSizePixelsLabel.Text = String.Format("{0} at {1} pixels/inch", Units.Format(imageInfo.Width, imageInfo.Height, CodecsRasterizeDocumentUnit.Pixel), imageInfo.XResolution)

         ' Show everything
         _formatValueLabel.Visible = True
         _pagesValueLabel.Visible = True
         _originalDocumentSizeValueLabel.Visible = True
         _loadDocumentSizeValueLabel.Visible = True
         _loadDocumentSizePixelsLabel.Visible = True
      Else
         ' Hide everything
         _formatValueLabel.Visible = False
         _pagesValueLabel.Visible = False
         _originalDocumentSizeValueLabel.Visible = False
         _loadDocumentSizeValueLabel.Visible = False
         _loadDocumentSizePixelsLabel.Visible = False
         _warningLabel.Visible = False
      End If
   End Sub

End Class
