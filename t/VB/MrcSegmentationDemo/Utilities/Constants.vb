' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System

Imports Leadtools
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color

Namespace MrcSegmentationDemo
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

      Private Shared ReadOnly _typeNameType As TypeNameType() = {New TypeNameType(GetType(RasterByteOrder), New TypeName() {New TypeName(CInt(RasterByteOrder.Bgr), "Blue-Green-Red (BGR)"), New TypeName(CInt(RasterByteOrder.Rgb), "Red-Green-Blue (RGB)"), New TypeName(CInt(RasterByteOrder.Gray), "Gray Scale"), New TypeName(CInt(RasterByteOrder.Romm), "ROMM"), New TypeName(CInt(RasterByteOrder.Rgb565), "RGB 565")}), New TypeNameType(GetType(RasterDitheringMethod), New TypeName() {New TypeName(CInt(RasterDitheringMethod.None), "None"), New TypeName(CInt(RasterDitheringMethod.FloydStein), "Floyd-Stein"), New TypeName(CInt(RasterDitheringMethod.Stucki), "Stucki"), New TypeName(CInt(RasterDitheringMethod.Burkes), "Burkes"), New TypeName(CInt(RasterDitheringMethod.Sierra), "Sierra"), New TypeName(CInt(RasterDitheringMethod.StevensonArce), "Stevenson-Arce"), New TypeName(CInt(RasterDitheringMethod.Jarvis), "Jarvis"), New TypeName(CInt(RasterDitheringMethod.Ordered), "Ordered"), New TypeName(CInt(RasterDitheringMethod.Clustered), "Clustered")}), New TypeNameType(GetType(RasterViewPerspective), New TypeName() {New TypeName(CInt(RasterViewPerspective.TopLeft), "Top-Left"), New TypeName(CInt(RasterViewPerspective.BottomLeft), "Bottom-Left"), New TypeName(CInt(RasterViewPerspective.TopRight), "Top-Right"), New TypeName(CInt(RasterViewPerspective.BottomLeft180), "Bottom-Left-180"), New TypeName(CInt(RasterViewPerspective.BottomRight), "Bottom-Right"), New TypeName(CInt(RasterViewPerspective.TopLeft180), "Top-Left-180"), New TypeName(CInt(RasterViewPerspective.RightTop), "Right-Top"), New TypeName(CInt(RasterViewPerspective.TopLeft90), "Top-Left-90"), New TypeName(CInt(RasterViewPerspective.LeftBottom), "Left-Bottom"), New TypeName(CInt(RasterViewPerspective.TopLeft270), "Top-Left2-70"), New TypeName(CInt(RasterViewPerspective.LeftTop), "Left-Top"), New TypeName(CInt(RasterViewPerspective.BottomLeft90), "Bottom-Left-90"), New TypeName(CInt(RasterViewPerspective.RightBottom), "Right-Bottom"), New TypeName(CInt(RasterViewPerspective.BottomLeft270), "Bottom-Left-270")}), New TypeNameType(GetType(RasterGrayscaleMode), New TypeName() {New TypeName(CInt(RasterGrayscaleMode.None), "None"), New TypeName(CInt(RasterGrayscaleMode.OrderedNormal), "Ordered Normal"), New TypeName(CInt(RasterGrayscaleMode.OrderedInverse), "Ordered Inverse"), New TypeName(CInt(RasterGrayscaleMode.NotOrdered), "Not Ordered")}), New TypeNameType(GetType(HalfToneCommandType), New TypeName() {New TypeName(CInt(HalfToneCommandType.Print), "Print"), New TypeName(CInt(HalfToneCommandType.View), "View"), New TypeName(CInt(HalfToneCommandType.Rectangular), "Rectangular"), New TypeName(CInt(HalfToneCommandType.Circular), "Circular"), New TypeName(CInt(HalfToneCommandType.Elliptical), "Elliptical"), New TypeName(CInt(HalfToneCommandType.Random), "Random"), New TypeName(CInt(HalfToneCommandType.Linear), "Linear"), New TypeName(CInt(HalfToneCommandType.UserDefined), "User Defined")}), New TypeNameType(GetType(EdgeDetectorCommandType), New TypeName() {New TypeName(CInt(EdgeDetectorCommandType.SobelVertical), "Sobel Vertical"), New TypeName(CInt(EdgeDetectorCommandType.SobelHorizontal), "Sobel Horizontal"), New TypeName(CInt(EdgeDetectorCommandType.SobelBoth), "Sobel Both"), New TypeName(CInt(EdgeDetectorCommandType.PrewittVertical), "Prewitt Vertical"), New TypeName(CInt(EdgeDetectorCommandType.PrewittHorizontal), "Prewitt Horizontal"), New TypeName(CInt(EdgeDetectorCommandType.PrewittBoth), "Prewitt Both"), New TypeName(CInt(EdgeDetectorCommandType.Laplace1), "Laplace 1"), New TypeName(CInt(EdgeDetectorCommandType.Laplace2), "Laplace 2"), New TypeName(CInt(EdgeDetectorCommandType.Laplace3), "Laplace 3"), New TypeName(CInt(EdgeDetectorCommandType.LaplaceDiagonal), "Laplace Diagonal"), New TypeName(CInt(EdgeDetectorCommandType.LaplaceHorizontal), "Laplace Horizontal"), New TypeName(CInt(EdgeDetectorCommandType.LaplaceVertical), "Laplace Vertical"), New TypeName(CInt(EdgeDetectorCommandType.GradientNorth), "Gradient North"), New TypeName(CInt(EdgeDetectorCommandType.GradientNorthEast), "Gradient North-East"), New TypeName(CInt(EdgeDetectorCommandType.GradientEast), "Gradient East"), New TypeName(CInt(EdgeDetectorCommandType.GradientSouthEast), "Gradient South-East"), New TypeName(CInt(EdgeDetectorCommandType.GradientSouth), "Gradient South"), New TypeName(CInt(EdgeDetectorCommandType.GradientSouthWest), "Gradient South-West"), New TypeName(CInt(EdgeDetectorCommandType.GradientWest), "Gradient West"), New TypeName(CInt(EdgeDetectorCommandType.GradientNorthWest), "Gradient North-West")}), New TypeNameType(GetType(RasterColorChannel), New TypeName() {New TypeName(CInt(RasterColorChannel.Master), "Master"), New TypeName(CInt(RasterColorChannel.Red), "Red"), New TypeName(CInt(RasterColorChannel.Green), "Green"), New TypeName(CInt(RasterColorChannel.Blue), "Blue")}), New TypeNameType(GetType(AntiAliasingCommandType), New TypeName() {New TypeName(CInt(AntiAliasingCommandType.Type1), "Type 1"), New TypeName(CInt(AntiAliasingCommandType.Type2), "Type 2"), New TypeName(CInt(AntiAliasingCommandType.Type3), "Type 3"), New TypeName(CInt(AntiAliasingCommandType.Diagonal), "Diagonal"), New TypeName(CInt(AntiAliasingCommandType.Horizontal), "Horizontal"), New TypeName(CInt(AntiAliasingCommandType.Vertical), "Vertical")}), New TypeNameType(GetType(EmbossCommandDirection), New TypeName() {New TypeName(CInt(EmbossCommandDirection.North), "North"), New TypeName(CInt(EmbossCommandDirection.NorthEast), "North-East"), New TypeName(CInt(EmbossCommandDirection.East), "East"), New TypeName(CInt(EmbossCommandDirection.SouthEast), "South-East"), New TypeName(CInt(EmbossCommandDirection.South), "South"), New TypeName(CInt(EmbossCommandDirection.SouthWest), "South-West"), New TypeName(CInt(EmbossCommandDirection.West), "West"), New TypeName(CInt(EmbossCommandDirection.NorthWest), "North-West")}), New TypeNameType(GetType(UnsharpMaskCommandColorType), New TypeName() {New TypeName(CInt(UnsharpMaskCommandColorType.None), "None"), New TypeName(CInt(UnsharpMaskCommandColorType.Rgb), "RGB"), New TypeName(CInt(UnsharpMaskCommandColorType.Yuv), "YUV")}), New TypeNameType(GetType(SpatialFilterCommandPredefined), New TypeName() {New TypeName(CInt(SpatialFilterCommandPredefined.EmbossNorth), "Emboss North"), New TypeName(CInt(SpatialFilterCommandPredefined.EmbossNorthEast), "Emboss North-East"), New TypeName(CInt(SpatialFilterCommandPredefined.EmbossEast), "Emboss East"), New TypeName(CInt(SpatialFilterCommandPredefined.EmbossSouthEast), "Emboss South-East"), New TypeName(CInt(SpatialFilterCommandPredefined.EmbossSouth), "Emboss South"), New TypeName(CInt(SpatialFilterCommandPredefined.EmbossSouthWest), "Emboss South-West"), New TypeName(CInt(SpatialFilterCommandPredefined.EmbossWest), "Emboss West"), New TypeName(CInt(SpatialFilterCommandPredefined.EmbossNorthWest), "Emboss North-West"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorth), "Gradient Edge Enhancement North"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthEast), "Gradient Edge Enhancement North-East"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementEast), "Gradient Edge Enhancement East"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthEast), "Gradient Edge Enhancement South-East"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouth), "Gradient Edge Enhancement South"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthWest), "Gradient Edge Enhancement South-West"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementWest), "Gradient Edge Enhancement West"), New TypeName(CInt(SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthWest), "Gradient Edge Enhancement North-West"), New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianFilter1), "Laplacian Filter 1"), New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianFilter2), "Laplacian Filter 2"), New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianFilter3), "Laplacian Filter 3"), New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianDiagonal), "Laplacian Diagonal"), New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianHorizontal), "Laplacian Horizontal"), New TypeName(CInt(SpatialFilterCommandPredefined.LaplacianVertical), "Laplacian Vertical"), New TypeName(CInt(SpatialFilterCommandPredefined.SobelHorizontal), "Sobel Horizontal"), New TypeName(CInt(SpatialFilterCommandPredefined.SobelVertical), "Sobel Vertical"), New TypeName(CInt(SpatialFilterCommandPredefined.PrewittHorizontal), "Prewitt Horizontal"), New TypeName(CInt(SpatialFilterCommandPredefined.PrewittVertical), "Prewitt Vertical"), New TypeName(CInt(SpatialFilterCommandPredefined.ShiftAndDifferenceDiagonal), "Shift And Difference Diagonal"), New TypeName(CInt(SpatialFilterCommandPredefined.ShiftAndDifferenceHorizontal), "Shift And Difference Horizontal"), New TypeName(CInt(SpatialFilterCommandPredefined.ShiftAndDifferenceVertical), "Shift And Difference Vertical"), New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentHorizontal), "Line Segment Horizontal"), New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentVertical), "Line Segment Vertical"), New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentLeftToRight), "Line Segment Left To Right"), New TypeName(CInt(SpatialFilterCommandPredefined.LineSegmentRightToLeft), "Line Segment Right To Left")}), New TypeNameType(GetType(BinaryFilterCommandPredefined), New TypeName() {New TypeName(CInt(BinaryFilterCommandPredefined.ErosionOmniDirectional), "Erosion Omni Directional"), New TypeName(CInt(BinaryFilterCommandPredefined.ErosionHorizontal), "Erosion Horizontal"), New TypeName(CInt(BinaryFilterCommandPredefined.ErosionVertical), "Erosion Vertical"), New TypeName(CInt(BinaryFilterCommandPredefined.ErosionDiagonal), "Erosion Diagonal"), New TypeName(CInt(BinaryFilterCommandPredefined.DilationOmniDirectional), "Dilation Omni Directional"), New TypeName(CInt(BinaryFilterCommandPredefined.DilationHorizontal), "Dilation Horizontal"), New TypeName(CInt(BinaryFilterCommandPredefined.DilationVertical), "Dilation Vertical"), New TypeName(CInt(BinaryFilterCommandPredefined.DilationDiagonal), "Dilation Diagonal")}), New TypeNameType(GetType(ContourFilterCommandType), New TypeName() {New TypeName(CInt(ContourFilterCommandType.Thin), "Thin"), New TypeName(CInt(ContourFilterCommandType.LinkBlackWhite), "Link Black White"), New TypeName(CInt(ContourFilterCommandType.LinkGray), "Link Gray"), New TypeName(CInt(ContourFilterCommandType.LinkColor), "Link Color"), New TypeName(CInt(ContourFilterCommandType.ApproxColor), "Approx Color")}), New TypeNameType(GetType(HistogramEqualizeType), New TypeName() {New TypeName(CInt(HistogramEqualizeType.None), "None"), New TypeName(CInt(HistogramEqualizeType.Rgb), "RGB"), New TypeName(CInt(HistogramEqualizeType.Yuv), "YUV"), New TypeName(CInt(HistogramEqualizeType.Gray), "Gray")}), New TypeNameType(GetType(IntensityDetectCommandFlags), New TypeName() {New TypeName(CInt(IntensityDetectCommandFlags.Master), "Master"), New TypeName(CInt(IntensityDetectCommandFlags.Red), "Red"), New TypeName(CInt(IntensityDetectCommandFlags.Green), "Green"), New TypeName(CInt(IntensityDetectCommandFlags.Blue), "Blue")}), New TypeNameType(GetType(SwapColorsCommandType), New TypeName() {New TypeName(CInt(SwapColorsCommandType.RedGreen), "Red <-> Green"), New TypeName(CInt(SwapColorsCommandType.RedBlue), "Red <-> Blue"), New TypeName(CInt(SwapColorsCommandType.GreenBlue), "Green <-> Blue"), New TypeName(CInt(SwapColorsCommandType.RedGreenBlueRed), "Red <-> Green Blue <-> Red"), New TypeName(CInt(SwapColorsCommandType.RedBlueGreenRed), "Red <-> Blue Green <-> Red")})}

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
               If name Is a(i).Name Then
                  Return a(i).Value
               End If
               i += 1
            Loop
         End If

         Return def
      End Function
   End Class
End Namespace
