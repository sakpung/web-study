' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Effects

'Namespace InteractiveHist
Public Class HistogramData
   Public Enum MovePoint
      MoveNone = 0
      MoveStart = 1
      MoveEnd = 3
      MoveNewStart = 4
      MoveNewEnd = 5
   End Enum

   Public Enum FilterNoiseReplaceType
      StartEndPoints             = 0
      MinimumMaximumInternsity = 1
      ReplaceColor = 2
      Zero = 4
   End Enum

   Public Structure MovingLine
      Public position As Integer
      Private color As Color

      Public Sub New(ByVal clr As Color)
         Color = clr
         position = 0
      End Sub
   End Structure

   Public Structure HistogramLabel
      Public paint As Rectangle
      Public moveType As MovePoint
      Public zoomed As Boolean
      Public penWidth As Integer
      Public mousePosition As Integer
      Public startRange As Integer
      Public endRange As Integer
      Public drawHistogram() As Integer
      Public drawStartRange As Integer
      Public drawEndRange As Integer
      Public histogramLength As Integer
      Public drawLength As Integer
   End Structure

   Public Structure Segmentation
      Public startLine As MovingLine
      Public endLine As MovingLine
   End Structure

   Public Structure GrayDistribution
      Public startLine As MovingLine
      Public endLine As MovingLine
   End Structure

   Public Structure FilterNoise
      Public startLine As MovingLine
      Public endLine As MovingLine
   End Structure

   Public Structure Rescaling
      Public startLine As MovingLine
      Public endLine As MovingLine
      Public newStartLine As MovingLine
      Public newEndLine As MovingLine
      Public prevEndHist As MovingLine
   End Structure

   Public Structure ChannelData
      Public orginalHistogram() As Int64

      Public innerColor As Color
      Public outerColor As Color
      Public segmentation As Segmentation
      Public grayDistribution As GrayDistribution
      Public filterNoise As FilterNoise
      Public rescale As Rescaling
      Public RGBLUTSegment() As RasterColor
      Public RGBLUTGray() As RasterColor
      Public RGBPrevLUT() As RasterColor
      Public LUTSegment() As Integer
      Public LUTGray() As Integer
      Public LUTFilter() As Integer
      Public LUTRescale() As Integer
      Public minHistogramValue As Integer
      Public maxHistogramValue As Integer
   End Structure

   Public Structure InteractiveHistogramDialogData
      Public image As RasterImage
      Public originalImage As RasterImage
      Public savedImage As RasterImage
      Public undoImage As RasterImage
      Public view As Rectangle
      Public channel As RasterColorChannel
      Public histogramLabel As HistogramLabel
      Public cD() As ChannelData
      Public scale As Integer
      Public fullView As Boolean
      Public minimumValue As Integer
      Public maximumValue As Integer
      Public pushed As Boolean
      Public distance As Integer
      Public signed As Boolean
      Public originalLUT() As RasterColor
      Public histogramAvaliable As Boolean
      Public gradient As Boolean
      Public shift As Boolean
      Public shiftRight As Boolean
      Public getHistogram As Boolean
      Public grayLUT As Boolean
      Public letApplyOnPallete As Boolean

      ' Segmentation variables...
      Public segmentStartColor As RasterColor
      Public segmentEndColor As RasterColor

      ' Gray Distribution Variables...
      Public grayFunctionType As FunctionalLookupTableFlags
      Public grayFactor As Integer
      Public grayStartColor As RasterColor
      Public grayEndColor As RasterColor
      Public grayCenter As Integer
      Public grayWidth As Integer
      Public graySelectionOnly As Boolean
      Public grayPredefinedPalette As Boolean
      Public predefinedPalette() As RasterColor

      ' Filter (Noise) Variables...
      Public noiseReplaceType As FilterNoiseReplaceType
      Public noiseMinIntensity As Integer
      Public noiseMaxIntensity As Integer
      Public noiseReplaceColor As RasterColor
      Public numberofPallet As Integer
      Public applyInProgress() As Boolean

      ' Rescaling Variables...
      Public rescaleShiftAmount As Integer
   End Structure
End Class
