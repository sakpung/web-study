' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Core

'Namespace MainDemo
Public NotInheritable Class Constants
   Private Sub New()
   End Sub

   Private Structure TypeName
      Public Value As Integer
      Public Name As String

      Public Sub New(ByVal v As Integer, ByVal n As String)
         Value = v
         Name = n
      End Sub
   End Structure

   Private Structure TypeNameType
      Public Type As Type
      Public TypeName() As TypeName

      Public Sub New(ByVal t As Type, ByVal tn() As TypeName)
         Type = t
         TypeName = tn
      End Sub
   End Structure

   Private Shared ReadOnly _typeNameType() As TypeNameType = _
   { _
      New TypeNameType( _
      GetType(RasterByteOrder), _
      New TypeName() _
      { _
         New TypeName(CType(RasterByteOrder.Bgr, Integer), "Blue-Green-Red (BGR)"), _
         New TypeName(CType(RasterByteOrder.Rgb, Integer), "Red-Green-Blue (RGB)"), _
         New TypeName(CType(RasterByteOrder.Gray, Integer), "Gray Scale"), _
         New TypeName(CType(RasterByteOrder.Romm, Integer), "ROMM") _
      }), _
      New TypeNameType( _
      GetType(RasterDitheringMethod), _
      New TypeName() _
      { _
         New TypeName(CType(RasterDitheringMethod.None, Integer), "None"), _
         New TypeName(CType(RasterDitheringMethod.FloydStein, Integer), "Floyd-Stein"), _
         New TypeName(CType(RasterDitheringMethod.Stucki, Integer), "Stucki"), _
         New TypeName(CType(RasterDitheringMethod.Burkes, Integer), "Burkes"), _
         New TypeName(CType(RasterDitheringMethod.Sierra, Integer), "Sierra"), _
         New TypeName(CType(RasterDitheringMethod.StevensonArce, Integer), "Stevenson-Arce"), _
         New TypeName(CType(RasterDitheringMethod.Jarvis, Integer), "Jarvis"), _
         New TypeName(CType(RasterDitheringMethod.Ordered, Integer), "Ordered"), _
         New TypeName(CType(RasterDitheringMethod.Clustered, Integer), "Clustered") _
      }), _
      New TypeNameType( _
      GetType(RasterViewPerspective), _
      New TypeName() _
      { _
         New TypeName(CType(RasterViewPerspective.TopLeft, Integer), "Top-Left"), _
         New TypeName(CType(RasterViewPerspective.BottomLeft, Integer), "Bottom-Left"), _
         New TypeName(CType(RasterViewPerspective.TopRight, Integer), "Top-Right"), _
         New TypeName(CType(RasterViewPerspective.BottomLeft180, Integer), "Bottom-Left-180"), _
         New TypeName(CType(RasterViewPerspective.BottomRight, Integer), "Bottom-Right"), _
         New TypeName(CType(RasterViewPerspective.TopLeft180, Integer), "Top-Left-180"), _
         New TypeName(CType(RasterViewPerspective.RightTop, Integer), "Right-Top"), _
         New TypeName(CType(RasterViewPerspective.TopLeft90, Integer), "Top-Left-90"), _
         New TypeName(CType(RasterViewPerspective.LeftBottom, Integer), "Left-Bottom"), _
         New TypeName(CType(RasterViewPerspective.TopLeft270, Integer), "Top-Left2-70"), _
         New TypeName(CType(RasterViewPerspective.LeftTop, Integer), "Left-Top"), _
         New TypeName(CType(RasterViewPerspective.BottomLeft90, Integer), "Bottom-Left-90"), _
         New TypeName(CType(RasterViewPerspective.RightBottom, Integer), "Right-Bottom"), _
         New TypeName(CType(RasterViewPerspective.BottomLeft270, Integer), "Bottom-Left-270") _
      }), _
      New TypeNameType( _
      GetType(RasterGrayscaleMode), _
      New TypeName() _
      { _
         New TypeName(CType(RasterGrayscaleMode.None, Integer), "None"), _
         New TypeName(CType(RasterGrayscaleMode.OrderedNormal, Integer), "Ordered Normal"), _
         New TypeName(CType(RasterGrayscaleMode.OrderedInverse, Integer), "Ordered Inverse"), _
         New TypeName(CType(RasterGrayscaleMode.NotOrdered, Integer), "Not Ordered") _
      }), _
      New TypeNameType( _
      GetType(HalfToneCommandType), _
      New TypeName() _
      { _
         New TypeName(CType(HalfToneCommandType.Print, Integer), "Print"), _
         New TypeName(CType(HalfToneCommandType.View, Integer), "View"), _
         New TypeName(CType(HalfToneCommandType.Rectangular, Integer), "Rectangular"), _
         New TypeName(CType(HalfToneCommandType.Circular, Integer), "Circular"), _
         New TypeName(CType(HalfToneCommandType.Elliptical, Integer), "Elliptical"), _
         New TypeName(CType(HalfToneCommandType.Random, Integer), "Random"), _
         New TypeName(CType(HalfToneCommandType.Linear, Integer), "Linear"), _
         New TypeName(CType(HalfToneCommandType.UserDefined, Integer), "User Defined") _
      }), _
      New TypeNameType( _
      GetType(EdgeDetectorCommandType), _
      New TypeName() _
      { _
         New TypeName(CType(EdgeDetectorCommandType.SobelVertical, Integer), "Sobel Vertical"), _
         New TypeName(CType(EdgeDetectorCommandType.SobelHorizontal, Integer), "Sobel Horizontal"), _
         New TypeName(CType(EdgeDetectorCommandType.SobelBoth, Integer), "Sobel Both"), _
         New TypeName(CType(EdgeDetectorCommandType.PrewittVertical, Integer), "Prewitt Vertical"), _
         New TypeName(CType(EdgeDetectorCommandType.PrewittHorizontal, Integer), "Prewitt Horizontal"), _
         New TypeName(CType(EdgeDetectorCommandType.PrewittBoth, Integer), "Prewitt Both"), _
         New TypeName(CType(EdgeDetectorCommandType.Laplace1, Integer), "Laplace 1"), _
         New TypeName(CType(EdgeDetectorCommandType.Laplace2, Integer), "Laplace 2"), _
         New TypeName(CType(EdgeDetectorCommandType.Laplace3, Integer), "Laplace 3"), _
         New TypeName(CType(EdgeDetectorCommandType.LaplaceDiagonal, Integer), "Laplace Diagonal"), _
         New TypeName(CType(EdgeDetectorCommandType.LaplaceHorizontal, Integer), "Laplace Horizontal"), _
         New TypeName(CType(EdgeDetectorCommandType.LaplaceVertical, Integer), "Laplace Vertical"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientNorth, Integer), "Gradient North"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientNorthEast, Integer), "Gradient North-East"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientEast, Integer), "Gradient East"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientSouthEast, Integer), "Gradient South-East"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientSouth, Integer), "Gradient South"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientSouthWest, Integer), "Gradient South-West"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientWest, Integer), "Gradient West"), _
         New TypeName(CType(EdgeDetectorCommandType.GradientNorthWest, Integer), "Gradient North-West") _
      }), _
      New TypeNameType( _
      GetType(RasterColorChannel), _
      New TypeName() _
      { _
         New TypeName(CType(RasterColorChannel.Master, Integer), "Master"), _
         New TypeName(CType(RasterColorChannel.Red, Integer), "Red"), _
         New TypeName(CType(RasterColorChannel.Green, Integer), "Green"), _
         New TypeName(CType(RasterColorChannel.Blue, Integer), "Blue") _
      }), _
      New TypeNameType( _
      GetType(AntiAliasingCommandType), _
      New TypeName() _
      { _
         New TypeName(CType(AntiAliasingCommandType.Type1, Integer), "Type 1"), _
         New TypeName(CType(AntiAliasingCommandType.Type2, Integer), "Type 2"), _
         New TypeName(CType(AntiAliasingCommandType.Type3, Integer), "Type 3"), _
         New TypeName(CType(AntiAliasingCommandType.Diagonal, Integer), "Diagonal"), _
         New TypeName(CType(AntiAliasingCommandType.Horizontal, Integer), "Horizontal"), _
         New TypeName(CType(AntiAliasingCommandType.Vertical, Integer), "Vertical") _
      }), _
      New TypeNameType( _
      GetType(EmbossCommandDirection), _
      New TypeName() _
      { _
         New TypeName(CType(EmbossCommandDirection.North, Integer), "North"), _
         New TypeName(CType(EmbossCommandDirection.NorthEast, Integer), "North-East"), _
         New TypeName(CType(EmbossCommandDirection.East, Integer), "East"), _
         New TypeName(CType(EmbossCommandDirection.SouthEast, Integer), "South-East"), _
         New TypeName(CType(EmbossCommandDirection.South, Integer), "South"), _
         New TypeName(CType(EmbossCommandDirection.SouthWest, Integer), "South-West"), _
         New TypeName(CType(EmbossCommandDirection.West, Integer), "West"), _
         New TypeName(CType(EmbossCommandDirection.NorthWest, Integer), "North-West") _
      }), _
      New TypeNameType( _
      GetType(UnsharpMaskCommandColorType), _
      New TypeName() _
      { _
         New TypeName(CType(UnsharpMaskCommandColorType.None, Integer), "None"), _
         New TypeName(CType(UnsharpMaskCommandColorType.Rgb, Integer), "RGB"), _
         New TypeName(CType(UnsharpMaskCommandColorType.Yuv, Integer), "YUV") _
      }), _
      New TypeNameType( _
      GetType(SpatialFilterCommandPredefined), _
      New TypeName() _
      { _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossNorth, Integer), "Emboss North"), _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossNorthEast, Integer), "Emboss North-East"), _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossEast, Integer), "Emboss East"), _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossSouthEast, Integer), "Emboss South-East"), _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossSouth, Integer), "Emboss South"), _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossSouthWest, Integer), "Emboss South-West"), _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossWest, Integer), "Emboss West"), _
         New TypeName(CType(SpatialFilterCommandPredefined.EmbossNorthWest, Integer), "Emboss North-West"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorth, Integer), "Gradient Edge Enhancement North"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthEast, Integer), "Gradient Edge Enhancement North-East"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementEast, Integer), "Gradient Edge Enhancement East"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthEast, Integer), "Gradient Edge Enhancement South-East"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouth, Integer), "Gradient Edge Enhancement South"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthWest, Integer), "Gradient Edge Enhancement South-West"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementWest, Integer), "Gradient Edge Enhancement West"), _
         New TypeName(CType(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthWest, Integer), "Gradient Edge Enhancement North-West"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LaplacianFilter1, Integer), "Laplacian Filter 1"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LaplacianFilter2, Integer), "Laplacian Filter 2"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LaplacianFilter3, Integer), "Laplacian Filter 3"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LaplacianDiagonal, Integer), "Laplacian Diagonal"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LaplacianHorizontal, Integer), "Laplacian Horizontal"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LaplacianVertical, Integer), "Laplacian Vertical"), _
         New TypeName(CType(SpatialFilterCommandPredefined.SobelHorizontal, Integer), "Sobel Horizontal"), _
         New TypeName(CType(SpatialFilterCommandPredefined.SobelVertical, Integer), "Sobel Vertical"), _
         New TypeName(CType(SpatialFilterCommandPredefined.PrewittHorizontal, Integer), "Prewitt Horizontal"), _
         New TypeName(CType(SpatialFilterCommandPredefined.PrewittVertical, Integer), "Prewitt Vertical"), _
         New TypeName(CType(SpatialFilterCommandPredefined.ShiftAndDifferenceDiagonal, Integer), "Shift And Difference Diagonal"), _
         New TypeName(CType(SpatialFilterCommandPredefined.ShiftAndDifferenceHorizontal, Integer), "Shift And Difference Horizontal"), _
         New TypeName(CType(SpatialFilterCommandPredefined.ShiftAndDifferenceVertical, Integer), "Shift And Difference Vertical"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LineSegmentHorizontal, Integer), "Line Segment Horizontal"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LineSegmentVertical, Integer), "Line Segment Vertical"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LineSegmentLeftToRight, Integer), "Line Segment Left To Right"), _
         New TypeName(CType(SpatialFilterCommandPredefined.LineSegmentRightToLeft, Integer), "Line Segment Right To Left") _
      }), _
      New TypeNameType( _
      GetType(BinaryFilterCommandPredefined), _
      New TypeName() _
      { _
         New TypeName(CType(BinaryFilterCommandPredefined.ErosionOmniDirectional, Integer), "Erosion Omni Directional"), _
         New TypeName(CType(BinaryFilterCommandPredefined.ErosionHorizontal, Integer), "Erosion Horizontal"), _
         New TypeName(CType(BinaryFilterCommandPredefined.ErosionVertical, Integer), "Erosion Vertical"), _
         New TypeName(CType(BinaryFilterCommandPredefined.ErosionDiagonal, Integer), "Erosion Diagonal"), _
         New TypeName(CType(BinaryFilterCommandPredefined.DilationOmniDirectional, Integer), "Dilation Omni Directional"), _
         New TypeName(CType(BinaryFilterCommandPredefined.DilationHorizontal, Integer), "Dilation Horizontal"), _
         New TypeName(CType(BinaryFilterCommandPredefined.DilationVertical, Integer), "Dilation Vertical"), _
         New TypeName(CType(BinaryFilterCommandPredefined.DilationDiagonal, Integer), "Dilation Diagonal") _
      }), _
      New TypeNameType( _
      GetType(ContourFilterCommandType), _
      New TypeName() _
      { _
         New TypeName(CType(ContourFilterCommandType.Thin, Integer), "Thin"), _
         New TypeName(CType(ContourFilterCommandType.LinkBlackWhite, Integer), "Link Black White"), _
         New TypeName(CType(ContourFilterCommandType.LinkGray, Integer), "Link Gray"), _
         New TypeName(CType(ContourFilterCommandType.LinkColor, Integer), "Link Color"), _
         New TypeName(CType(ContourFilterCommandType.ApproxColor, Integer), "Approx Color") _
      }), _
      New TypeNameType( _
      GetType(HistogramEqualizeType), _
      New TypeName() _
      { _
         New TypeName(CType(HistogramEqualizeType.None, Integer), "None"), _
         New TypeName(CType(HistogramEqualizeType.Rgb, Integer), "RGB"), _
         New TypeName(CType(HistogramEqualizeType.Yuv, Integer), "YUV"), _
         New TypeName(CType(HistogramEqualizeType.Gray, Integer), "Gray") _
      }), _
      New TypeNameType( _
      GetType(IntensityDetectCommandFlags), _
      New TypeName() _
      { _
         New TypeName(CType(IntensityDetectCommandFlags.Master, Integer), "Master"), _
         New TypeName(CType(IntensityDetectCommandFlags.Red, Integer), "Red"), _
         New TypeName(CType(IntensityDetectCommandFlags.Green, Integer), "Green"), _
         New TypeName(CType(IntensityDetectCommandFlags.Blue, Integer), "Blue") _
      }), _
      New TypeNameType( _
      GetType(SwapColorsCommandType), _
      New TypeName() _
      { _
         New TypeName(CType(SwapColorsCommandType.RedGreen, Integer), "Red <-> Green"), _
         New TypeName(CType(SwapColorsCommandType.RedBlue, Integer), "Red <-> Blue"), _
         New TypeName(CType(SwapColorsCommandType.GreenBlue, Integer), "Green <-> Blue"), _
         New TypeName(CType(SwapColorsCommandType.RedGreenBlueRed, Integer), "Red <-> Green Blue <-> Red"), _
         New TypeName(CType(SwapColorsCommandType.RedBlueGreenRed, Integer), "Red <-> Blue Green <-> Red") _
      }) _
   }

   Private Shared Function GetTypeNamesFromType(ByVal type As Type) As TypeName()
      Dim i As TypeNameType
      For Each i In _typeNameType
         If (i.Type Is type) Then
            Return i.TypeName
         End If
      Next

      Throw New ApplicationException("Invalid type")
   End Function

   Public Shared Function GetNameFromValue(ByVal type As Type, ByVal val As Object) As String
      Dim a() As TypeName = GetTypeNamesFromType(type)
      Dim i As Integer
      For i = 0 To a.Length - 1
         If (a(i).Value = CType(val, Integer)) Then
            Return a(i).Name
         End If
      Next

      Throw New ApplicationException("Invalid type")
   End Function

   Public Shared Function GetValueFromName(ByVal type As Type, ByVal name As String, ByVal def As Object) As Object
      Dim a() As TypeName = GetTypeNamesFromType(type)
      Dim index As Integer = -1

      If Not (a Is Nothing) Then
         Dim i As Integer = 0
         While (i < (a.Length) AndAlso index = -1)
            If (name = a(i).Name) Then
               Return a(i).Value
            End If
            i = i + 1
         End While
      End If

      Return def
   End Function
End Class
'End Namespace
