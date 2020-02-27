' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color

Namespace Leadtools.Demos
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
         Public TypeName As TypeName()

         Public Sub New(ByVal t As Type, ByVal tn As TypeName())
            Type = t
            TypeName = tn
         End Sub
      End Structure

      Private Shared ReadOnly _typeNameType As TypeNameType() = {New TypeNameType(GetType(RasterByteOrder), New TypeName() { _
                                                                                  New TypeName(CInt(RasterByteOrder.Bgr), "Blue-Green-Red (BGR)"), _
                                                                                  New TypeName(CInt(RasterByteOrder.Rgb), "Red-Green-Blue (RGB)"), _
                                                                                  New TypeName(CInt(RasterByteOrder.Gray), "Gray Scale"), _
                                                                                  New TypeName(CInt(RasterByteOrder.Romm), "ROMM"), _
                                                                                  New TypeName(CInt(RasterByteOrder.Rgb565), "Red-Green-Blue (565)")}), _
                                                                 New TypeNameType(GetType(RasterDitheringMethod), New TypeName() { _
                                                                                  New TypeName(CInt(RasterDitheringMethod.None), "None"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.FloydStein), "Floyd-Stein"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.Stucki), "Stucki"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.Burkes), "Burkes"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.Sierra), "Sierra"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.StevensonArce), "Stevenson-Arce"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.Jarvis), "Jarvis"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.Ordered), "Ordered"), _
                                                                                  New TypeName(CInt(RasterDitheringMethod.Clustered), "Clustered")}), _
                                                                 New TypeNameType(GetType(RasterViewPerspective), New TypeName() { _
                                                                                  New TypeName(CInt(RasterViewPerspective.TopLeft), "Top-Left"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.BottomLeft), "Bottom-Left"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.TopRight), "Top-Right"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.BottomLeft180), "Bottom-Left-180"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.BottomRight), "Bottom-Right"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.TopLeft180), "Top-Left-180"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.RightTop), "Right-Top"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.TopLeft90), "Top-Left-90"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.LeftBottom), "Left-Bottom"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.TopLeft270), "Top-Left2-70"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.LeftTop), "Left-Top"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.BottomLeft90), "Bottom-Left-90"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.RightBottom), "Right-Bottom"), _
                                                                                  New TypeName(CInt(RasterViewPerspective.BottomLeft270), "Bottom-Left-270")}), _
                                                                 New TypeNameType(GetType(RasterGrayscaleMode), New TypeName() { _
                                                                                  New TypeName(CInt(RasterGrayscaleMode.None), "None"), _
                                                                                  New TypeName(CInt(RasterGrayscaleMode.OrderedNormal), "Ordered Normal"), _
                                                                                  New TypeName(CInt(RasterGrayscaleMode.OrderedInverse), "Ordered Inverse"), _
                                                                                  New TypeName(CInt(RasterGrayscaleMode.NotOrdered), "Not Ordered")}), _
                                                                 New TypeNameType(GetType(HalfToneCommandType), New TypeName() { _
                                                                                  New TypeName(CInt(HalfToneCommandType.Print), "Print"), _
                                                                                  New TypeName(CInt(HalfToneCommandType.View), "View"), _
                                                                                  New TypeName(CInt(HalfToneCommandType.Rectangular), "Rectangular"), _
                                                                                  New TypeName(CInt(HalfToneCommandType.Circular), "Circular"), _
                                                                                  New TypeName(CInt(HalfToneCommandType.Elliptical), "Elliptical"), _
                                                                                  New TypeName(CInt(HalfToneCommandType.Random), "Random"), _
                                                                                  New TypeName(CInt(HalfToneCommandType.Linear), "Linear"), _
                                                                                  New TypeName(CInt(HalfToneCommandType.UserDefined), "User Defined")}), _
                                                                 New TypeNameType(GetType(EdgeDetectorCommandType), New TypeName() { _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.SobelVertical), "Sobel Vertical"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.SobelHorizontal), "Sobel Horizontal"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.SobelBoth), "Sobel Both"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.PrewittVertical), "Prewitt Vertical"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.PrewittHorizontal), "Prewitt Horizontal"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.PrewittBoth), "Prewitt Both"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.Laplace1), "Laplace 1"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.Laplace2), "Laplace 2"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.Laplace3), "Laplace 3"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.LaplaceDiagonal), "Laplace Diagonal"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.LaplaceHorizontal), "Laplace Horizontal"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.LaplaceVertical), "Laplace Vertical"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientNorth), "Gradient North"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientNorthEast), "Gradient North-East"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientEast), "Gradient East"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientSouthEast), "Gradient South-East"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientSouth), "Gradient South"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientSouthWest), "Gradient South-West"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientWest), "Gradient West"), _
                                                                                  New TypeName(CInt(EdgeDetectorCommandType.GradientNorthWest), "Gradient North-West")}), _
                                                                 New TypeNameType(GetType(RasterColorChannel), New TypeName() { _
                                                                                  New TypeName(CInt(RasterColorChannel.Master), "Master"), _
                                                                                  New TypeName(CInt(RasterColorChannel.Red), "Red"), _
                                                                                  New TypeName(CInt(RasterColorChannel.Green), "Green"), _
                                                                                  New TypeName(CInt(RasterColorChannel.Blue), "Blue")}), _
                                                                 New TypeNameType(GetType(AntiAliasingCommandType), New TypeName() { _
                                                                                  New TypeName(CInt(AntiAliasingCommandType.Type1), "Type 1"), _
                                                                                  New TypeName(CInt(AntiAliasingCommandType.Type2), "Type 2"), _
                                                                                  New TypeName(CInt(AntiAliasingCommandType.Type3), "Type 3"), _
                                                                                  New TypeName(CInt(AntiAliasingCommandType.Diagonal), "Diagonal"), _
                                                                                  New TypeName(CInt(AntiAliasingCommandType.Horizontal), "Horizontal"), _
                                                                                  New TypeName(CInt(AntiAliasingCommandType.Vertical), "Vertical")}), _
                                                                 New TypeNameType(GetType(EmbossCommandDirection), New TypeName() { _
                                                                                  New TypeName(CInt(EmbossCommandDirection.North), "North"), _
                                                                                  New TypeName(CInt(EmbossCommandDirection.NorthEast), "North-East"), _
                                                                                  New TypeName(CInt(EmbossCommandDirection.East), "East"), _
                                                                                  New TypeName(CInt(EmbossCommandDirection.SouthEast), "South-East"), _
                                                                                  New TypeName(CInt(EmbossCommandDirection.South), "South"), _
                                                                                  New TypeName(CInt(EmbossCommandDirection.SouthWest), "South-West"), _
                                                                                  New TypeName(CInt(EmbossCommandDirection.West), "West"), _
                                                                                  New TypeName(CInt(EmbossCommandDirection.NorthWest), "North-West")}), _
                                                                 New TypeNameType(GetType(UnsharpMaskCommandColorType), New TypeName() { _
                                                                                  New TypeName(CInt(UnsharpMaskCommandColorType.None), "None"), _
                                                                                  New TypeName(CInt(UnsharpMaskCommandColorType.Rgb), "RGB"), _
                                                                                  New TypeName(CInt(UnsharpMaskCommandColorType.Yuv), "YUV")}), _
                                                                 New TypeNameType(GetType(SpatialFilterCommandPredefined), New TypeName() { _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossNorth), "Emboss North"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossNorthEast), "Emboss North-East"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossEast), "Emboss East"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossSouthEast), "Emboss South-East"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossSouth), "Emboss South"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossSouthWest), "Emboss South-West"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossWest), "Emboss West"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.EmbossNorthWest), "Emboss North-West"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorth), "Gradient Edge Enhancement North"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthEast), "Gradient Edge Enhancement North-East"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementEast), "Gradient Edge Enhancement East"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthEast), "Gradient Edge Enhancement South-East"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouth), "Gradient Edge Enhancement South"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthWest), "Gradient Edge Enhancement South-West"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementWest), "Gradient Edge Enhancement West"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthWest), "Gradient Edge Enhancement North-West"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianFilter1), "Laplacian Filter 1"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianFilter2), "Laplacian Filter 2"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianFilter3), "Laplacian Filter 3"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianDiagonal), "Laplacian Diagonal"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianHorizontal), "Laplacian Horizontal"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianVertical), "Laplacian Vertical"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.SobelHorizontal), "Sobel Horizontal"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.SobelVertical), "Sobel Vertical"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.PrewittHorizontal), "Prewitt Horizontal"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.PrewittVertical), "Prewitt Vertical"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.ShiftAndDifferenceDiagonal), "Shift And Difference Diagonal"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.ShiftAndDifferenceHorizontal), "Shift And Difference Horizontal"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.ShiftAndDifferenceVertical), "Shift And Difference Vertical"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentHorizontal), "Line Segment Horizontal"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentVertical), "Line Segment Vertical"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentLeftToRight), "Line Segment Left To Right"), _
                                                                                  New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentRightToLeft), "Line Segment Right To Left")}), _
                                                                 New TypeNameType(GetType(BinaryFilterCommandPredefined), New TypeName() { _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.ErosionOmniDirectional), "Erosion Omni Directional"), _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.ErosionHorizontal), "Erosion Horizontal"), _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.ErosionVertical), "Erosion Vertical"), _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.ErosionDiagonal), "Erosion Diagonal"), _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.DilationOmniDirectional), "Dilation Omni Directional"), _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.DilationHorizontal), "Dilation Horizontal"), _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.DilationVertical), "Dilation Vertical"), _
                                                                                  New TypeName(CInt(BinaryFilterCommandPredefined.DilationDiagonal), "Dilation Diagonal")}), _
                                                                 New TypeNameType(GetType(ContourFilterCommandType), New TypeName() { _
                                                                                  New TypeName(CInt(ContourFilterCommandType.Thin), "Thin"), _
                                                                                  New TypeName(CInt(ContourFilterCommandType.LinkBlackWhite), "Link Black White"), _
                                                                                  New TypeName(CInt(ContourFilterCommandType.LinkGray), "Link Gray"), _
                                                                                  New TypeName(CInt(ContourFilterCommandType.LinkColor), "Link Color"), _
                                                                                  New TypeName(CInt(ContourFilterCommandType.ApproxColor), "Approx Color")}), _
                                                                 New TypeNameType(GetType(HistogramEqualizeType), New TypeName() { _
                                                                                  New TypeName(CInt(HistogramEqualizeType.None), "None"), _
                                                                                  New TypeName(CInt(HistogramEqualizeType.Rgb), "RGB"), _
                                                                                  New TypeName(CInt(HistogramEqualizeType.Yuv), "YUV"), _
                                                                                  New TypeName(CInt(HistogramEqualizeType.Gray), "Gray")}), _
                                                                 New TypeNameType(GetType(IntensityDetectCommandFlags), New TypeName() { _
                                                                                  New TypeName(CInt(IntensityDetectCommandFlags.Master), "Master"), _
                                                                                  New TypeName(CInt(IntensityDetectCommandFlags.Red), "Red"), _
                                                                                  New TypeName(CInt(IntensityDetectCommandFlags.Green), "Green"), _
                                                                                  New TypeName(CInt(IntensityDetectCommandFlags.Blue), "Blue")}), _
                                                                 New TypeNameType(GetType(SwapColorsCommandType), New TypeName() { _
                                                                                  New TypeName(CInt(SwapColorsCommandType.RedGreen), "Red <-> Green"), _
                                                                                  New TypeName(CInt(SwapColorsCommandType.RedBlue), "Red <-> Blue"), _
                                                                                  New TypeName(CInt(SwapColorsCommandType.GreenBlue), "Green <-> Blue"), _
                                                                                  New TypeName(CInt(SwapColorsCommandType.RedGreenBlueRed), "Red <-> Green Blue <-> Red"), _
                                                                                  New TypeName(CInt(SwapColorsCommandType.RedBlueGreenRed), "Red <-> Blue Green <-> Red")}), _
                                                                 New TypeNameType(GetType(PreDefinedFilterType), New TypeName() { _
                                                                                  New TypeName(CInt(PreDefinedFilterType.GAUSSIAN), "Gaussian"), _
                                                                                  New TypeName(CInt(PreDefinedFilterType.MOTION), "Motion")})}

      Private Shared Function GetTypeNamesFromType(ByVal type As Type) As TypeName()
         For Each i As TypeNameType In _typeNameType
            If i.Type Is type Then
               Return i.TypeName
            End If
         Next i

         Throw New ApplicationException("Invalid type")
      End Function

      Public Shared Function GetNameFromValue(ByVal type As Type, ByVal val As Object) As String
         Dim a As TypeName() = GetTypeNamesFromType(type)
         Dim i As Integer = 0
         Do While i < a.Length
            If a(i).Value = CInt(val) Then
               Return a(i).Name
            End If
            i += 1
         Loop

         Throw New ApplicationException("Invalid type")
      End Function

      Public Shared Function GetValueFromName(ByVal type As Type, ByVal name As String, ByVal def As Object) As Object
         Dim a As TypeName() = GetTypeNamesFromType(type)
         Dim index As Integer = -1

         If Not a Is Nothing Then
            Dim i As Integer = 0
            Do While i < a.Length AndAlso index = -1
               If name = a(i).Name Then
                  Return a(i).Value
               End If
               i += 1
            Loop
         End If

         Return def
      End Function
   End Class
End Namespace
