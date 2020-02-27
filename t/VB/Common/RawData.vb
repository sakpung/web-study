' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports Leadtools

Namespace Leadtools.Demos
   Public Structure RawData
      Public Shared ReadOnly Property [Default]() As RawData
         Get
            Dim data As RawData = New RawData()
            data.Width = 2560
            data.Height = 3500
            data.BitsPerPixel = 24
            data.ViewPerspective = RasterViewPerspective.TopLeft
            data.Order = RasterByteOrder.Bgr
            data.XResolution = 300
            data.YResolution = 300
            data.Offset = 0
            data.Padding = False
            data.ReverseBits = True
            data.Format = RasterImageFormat.Raw
            data.FixedPalette = False
            data.PaletteEnabled = False
            data.WhiteOnBlack = False
            Return data
         End Get
      End Property

      Public Width As Integer ' Width of image
      Public Height As Integer ' Height of image
      Public BitsPerPixel As Integer ' Bits per pixel of image--if palettized, a gray palette is generated
      Public ViewPerspective As RasterViewPerspective ' View perspective of raw data (TopLeft, BottomLeft, etc)
      Public Order As RasterByteOrder ' Rgb or Bgr
      Public XResolution As Integer ' Horizontal resolution in DPI
      Public YResolution As Integer ' Vertical resolution in DPI
      Public Offset As Integer ' Offset into file where raw data begins
      Public Padding As Boolean ' true if each line of data is padded to four bytes
      Public ReverseBits As Boolean ' true if the bits of each byte are reversed
      Public Format As RasterImageFormat ' Raw Format.
      Public FixedPalette As Boolean ' Determine the Palette type (0 for grayscale palette and 1 for Leadtools fixed palette)
      Public PaletteEnabled As Boolean ' Determine if the Palette is enabled for this format.
      Public WhiteOnBlack As Boolean ' Color order white on black
   End Structure
End Namespace
