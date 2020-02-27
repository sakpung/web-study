// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Color;

namespace AnimationDemo
{
   public sealed class Constants
   {
      private Constants( )
      {
      }

      private struct TypeName
      {
         public int Value;
         public string Name;

         public TypeName(int v, string n)
         {
            Value = v;
            Name = n;
         }
      }

      private struct TypeNameType
      {
         public Type Type;
         public TypeName[] TypeName;

         public TypeNameType(Type t, TypeName[] tn)
         {
            Type = t;
            TypeName = tn;
         }
      }

      private readonly static TypeNameType[] _typeNameType =
      {
         new TypeNameType(
         typeof(RasterByteOrder),
         new TypeName[]
         {
            new TypeName((int)RasterByteOrder.Bgr,   "Blue-Green-Red (BGR)"),
            new TypeName((int)RasterByteOrder.Rgb,   "Red-Green-Blue (RGB)"),
            new TypeName((int)RasterByteOrder.Gray,  "Gray Scale"),
            new TypeName((int)RasterByteOrder.Romm,  "ROMM"),
            new TypeName((int)RasterByteOrder.Rgb565,"Red-Green-Blue(RGB565)"),
         }),

         new TypeNameType(
         typeof(RasterDitheringMethod),
         new TypeName[]
         {
            new TypeName((int)RasterDitheringMethod.None,           "None"),
            new TypeName((int)RasterDitheringMethod.FloydStein,     "Floyd-Stein"),
            new TypeName((int)RasterDitheringMethod.Stucki,         "Stucki"),
            new TypeName((int)RasterDitheringMethod.Burkes,         "Burkes"),
            new TypeName((int)RasterDitheringMethod.Sierra,         "Sierra"),
            new TypeName((int)RasterDitheringMethod.StevensonArce,  "Stevenson-Arce"),
            new TypeName((int)RasterDitheringMethod.Jarvis,         "Jarvis"),
            new TypeName((int)RasterDitheringMethod.Ordered,        "Ordered"),
            new TypeName((int)RasterDitheringMethod.Clustered,      "Clustered")
         }),

         new TypeNameType(
         typeof(RasterViewPerspective),
         new TypeName[]
         {
            new TypeName((int)RasterViewPerspective.TopLeft,        "Top-Left"),
            new TypeName((int)RasterViewPerspective.BottomLeft,     "Bottom-Left"),
            new TypeName((int)RasterViewPerspective.TopRight,       "Top-Right"),
            new TypeName((int)RasterViewPerspective.BottomLeft180,  "Bottom-Left-180"),
            new TypeName((int)RasterViewPerspective.BottomRight,    "Bottom-Right"),
            new TypeName((int)RasterViewPerspective.TopLeft180,     "Top-Left-180"),
            new TypeName((int)RasterViewPerspective.RightTop,       "Right-Top"),
            new TypeName((int)RasterViewPerspective.TopLeft90,      "Top-Left-90"),
            new TypeName((int)RasterViewPerspective.LeftBottom,     "Left-Bottom"),
            new TypeName((int)RasterViewPerspective.TopLeft270,     "Top-Left2-70"),
            new TypeName((int)RasterViewPerspective.LeftTop,        "Left-Top"),
            new TypeName((int)RasterViewPerspective.BottomLeft90,   "Bottom-Left-90"),
            new TypeName((int)RasterViewPerspective.RightBottom,    "Right-Bottom"),
            new TypeName((int)RasterViewPerspective.BottomLeft270,  "Bottom-Left-270")
         }),

         new TypeNameType(
         typeof(RasterGrayscaleMode),
         new TypeName[]
         {
            new TypeName((int)RasterGrayscaleMode.None,            "None"),
            new TypeName((int)RasterGrayscaleMode.OrderedNormal,   "Ordered Normal"),
            new TypeName((int)RasterGrayscaleMode.OrderedInverse,  "Ordered Inverse"),
            new TypeName((int)RasterGrayscaleMode.NotOrdered,      "Not Ordered")
         }),

         new TypeNameType(
         typeof(HalfToneCommandType),
         new TypeName[]
         {
            new TypeName((int)HalfToneCommandType.Print,       "Print"),
            new TypeName((int)HalfToneCommandType.View,        "View"),
            new TypeName((int)HalfToneCommandType.Rectangular, "Rectangular"),
            new TypeName((int)HalfToneCommandType.Circular,    "Circular"),
            new TypeName((int)HalfToneCommandType.Elliptical,  "Elliptical"),
            new TypeName((int)HalfToneCommandType.Random,      "Random"),
            new TypeName((int)HalfToneCommandType.Linear,      "Linear"),
            new TypeName((int)HalfToneCommandType.UserDefined, "User Defined")
         }),

         new TypeNameType(
         typeof(EdgeDetectorCommandType),
         new TypeName[]
         {
            new TypeName((int)EdgeDetectorCommandType.SobelVertical,       "Sobel Vertical"),
            new TypeName((int)EdgeDetectorCommandType.SobelHorizontal,     "Sobel Horizontal"),
            new TypeName((int)EdgeDetectorCommandType.SobelBoth,           "Sobel Both"),
            new TypeName((int)EdgeDetectorCommandType.PrewittVertical,     "Prewitt Vertical"),
            new TypeName((int)EdgeDetectorCommandType.PrewittHorizontal,   "Prewitt Horizontal"),
            new TypeName((int)EdgeDetectorCommandType.PrewittBoth,         "Prewitt Both"),
            new TypeName((int)EdgeDetectorCommandType.Laplace1,            "Laplace 1"),
            new TypeName((int)EdgeDetectorCommandType.Laplace2,            "Laplace 2"),
            new TypeName((int)EdgeDetectorCommandType.Laplace3,            "Laplace 3"),
            new TypeName((int)EdgeDetectorCommandType.LaplaceDiagonal,     "Laplace Diagonal"),
            new TypeName((int)EdgeDetectorCommandType.LaplaceHorizontal,   "Laplace Horizontal"),
            new TypeName((int)EdgeDetectorCommandType.LaplaceVertical,     "Laplace Vertical"),
            new TypeName((int)EdgeDetectorCommandType.GradientNorth,       "Gradient North"),
            new TypeName((int)EdgeDetectorCommandType.GradientNorthEast,   "Gradient North-East"),
            new TypeName((int)EdgeDetectorCommandType.GradientEast,        "Gradient East"),
            new TypeName((int)EdgeDetectorCommandType.GradientSouthEast,   "Gradient South-East"),
            new TypeName((int)EdgeDetectorCommandType.GradientSouth,       "Gradient South"),
            new TypeName((int)EdgeDetectorCommandType.GradientSouthWest,   "Gradient South-West"),
            new TypeName((int)EdgeDetectorCommandType.GradientWest,        "Gradient West"),
            new TypeName((int)EdgeDetectorCommandType.GradientNorthWest,   "Gradient North-West")
         }),

         new TypeNameType(
         typeof(RasterColorChannel),
         new TypeName[]
         {
            new TypeName((int)RasterColorChannel.Master, "Master"),
            new TypeName((int)RasterColorChannel.Red,    "Red"),
            new TypeName((int)RasterColorChannel.Green,  "Green"),
            new TypeName((int)RasterColorChannel.Blue,   "Blue")
         }),

         new TypeNameType(
         typeof(AntiAliasingCommandType),
         new TypeName[]
         {
            new TypeName((int)AntiAliasingCommandType.Type1,      "Type 1"),
            new TypeName((int)AntiAliasingCommandType.Type2,      "Type 2"),
            new TypeName((int)AntiAliasingCommandType.Type3,      "Type 3"),
            new TypeName((int)AntiAliasingCommandType.Diagonal,   "Diagonal"),
            new TypeName((int)AntiAliasingCommandType.Horizontal, "Horizontal"),
            new TypeName((int)AntiAliasingCommandType.Vertical,   "Vertical")
         }),

         new TypeNameType(
         typeof(EmbossCommandDirection),
         new TypeName[]
         {
            new TypeName((int)EmbossCommandDirection.North,       "North"),
            new TypeName((int)EmbossCommandDirection.NorthEast,   "North-East"),
            new TypeName((int)EmbossCommandDirection.East,        "East"),
            new TypeName((int)EmbossCommandDirection.SouthEast,   "South-East"),
            new TypeName((int)EmbossCommandDirection.South,       "South"),
            new TypeName((int)EmbossCommandDirection.SouthWest,   "South-West"),
            new TypeName((int)EmbossCommandDirection.West,        "West"),
            new TypeName((int)EmbossCommandDirection.NorthWest,   "North-West")
         }),

         new TypeNameType(
         typeof(UnsharpMaskCommandColorType),
         new TypeName[]
         {
            new TypeName((int)UnsharpMaskCommandColorType.None,   "None"),
            new TypeName((int)UnsharpMaskCommandColorType.Rgb,    "RGB"),
            new TypeName((int)UnsharpMaskCommandColorType.Yuv,    "YUV")
         }),

         new TypeNameType(
         typeof(SpatialFilterCommandPredefined),
         new TypeName[]
         {
            new TypeName((int)SpatialFilterCommandPredefined.EmbossNorth,                       "Emboss North"),
            new TypeName((int)SpatialFilterCommandPredefined.EmbossNorthEast,                   "Emboss North-East"),
            new TypeName((int)SpatialFilterCommandPredefined.EmbossEast,                        "Emboss East"),
            new TypeName((int)SpatialFilterCommandPredefined.EmbossSouthEast,                   "Emboss South-East"),
            new TypeName((int)SpatialFilterCommandPredefined.EmbossSouth,                       "Emboss South"),
            new TypeName((int)SpatialFilterCommandPredefined.EmbossSouthWest,                   "Emboss South-West"),
            new TypeName((int)SpatialFilterCommandPredefined.EmbossWest,                        "Emboss West"),
            new TypeName((int)SpatialFilterCommandPredefined.EmbossNorthWest,                   "Emboss North-West"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementNorth,      "Gradient Edge Enhancement North"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthEast,  "Gradient Edge Enhancement North-East"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementEast,       "Gradient Edge Enhancement East"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthEast,  "Gradient Edge Enhancement South-East"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementSouth,      "Gradient Edge Enhancement South"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementSouthWest,  "Gradient Edge Enhancement South-West"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementWest,       "Gradient Edge Enhancement West"),
            new TypeName((int)SpatialFilterCommandPredefined.GradientEdgeEnhancementNorthWest,  "Gradient Edge Enhancement North-West"),
            new TypeName((int)SpatialFilterCommandPredefined.LaplacianFilter1,                  "Laplacian Filter 1"),
            new TypeName((int)SpatialFilterCommandPredefined.LaplacianFilter2,                  "Laplacian Filter 2"),
            new TypeName((int)SpatialFilterCommandPredefined.LaplacianFilter3,                  "Laplacian Filter 3"),
            new TypeName((int)SpatialFilterCommandPredefined.LaplacianDiagonal,                 "Laplacian Diagonal"),
            new TypeName((int)SpatialFilterCommandPredefined.LaplacianHorizontal,               "Laplacian Horizontal"),
            new TypeName((int)SpatialFilterCommandPredefined.LaplacianVertical,                 "Laplacian Vertical"),
            new TypeName((int)SpatialFilterCommandPredefined.SobelHorizontal,                   "Sobel Horizontal"),
            new TypeName((int)SpatialFilterCommandPredefined.SobelVertical,                     "Sobel Vertical"),
            new TypeName((int)SpatialFilterCommandPredefined.PrewittHorizontal,                 "Prewitt Horizontal"),
            new TypeName((int)SpatialFilterCommandPredefined.PrewittVertical,                   "Prewitt Vertical"),
            new TypeName((int)SpatialFilterCommandPredefined.ShiftAndDifferenceDiagonal,        "Shift And Difference Diagonal"),
            new TypeName((int)SpatialFilterCommandPredefined.ShiftAndDifferenceHorizontal,      "Shift And Difference Horizontal"),
            new TypeName((int)SpatialFilterCommandPredefined.ShiftAndDifferenceVertical,        "Shift And Difference Vertical"),
            new TypeName((int)SpatialFilterCommandPredefined.LineSegmentHorizontal,             "Line Segment Horizontal"),
            new TypeName((int)SpatialFilterCommandPredefined.LineSegmentVertical,               "Line Segment Vertical"),
            new TypeName((int)SpatialFilterCommandPredefined.LineSegmentLeftToRight,            "Line Segment Left To Right"),
            new TypeName((int)SpatialFilterCommandPredefined.LineSegmentRightToLeft,            "Line Segment Right To Left")
         }),

         new TypeNameType(
         typeof(BinaryFilterCommandPredefined),
         new TypeName[]
         {
            new TypeName((int)BinaryFilterCommandPredefined.ErosionOmniDirectional,    "Erosion Omni Directional"),
            new TypeName((int)BinaryFilterCommandPredefined.ErosionHorizontal,         "Erosion Horizontal"),
            new TypeName((int)BinaryFilterCommandPredefined.ErosionVertical,           "Erosion Vertical"),
            new TypeName((int)BinaryFilterCommandPredefined.ErosionDiagonal,           "Erosion Diagonal"),
            new TypeName((int)BinaryFilterCommandPredefined.DilationOmniDirectional,   "Dilation Omni Directional"),
            new TypeName((int)BinaryFilterCommandPredefined.DilationHorizontal,        "Dilation Horizontal"),
            new TypeName((int)BinaryFilterCommandPredefined.DilationVertical,          "Dilation Vertical"),
            new TypeName((int)BinaryFilterCommandPredefined.DilationDiagonal,          "Dilation Diagonal")
         }),

         new TypeNameType(
         typeof(ContourFilterCommandType),
         new TypeName[]
         {
            new TypeName((int)ContourFilterCommandType.Thin,            "Thin"),
            new TypeName((int)ContourFilterCommandType.LinkBlackWhite,  "Link Black White"),
            new TypeName((int)ContourFilterCommandType.LinkGray,        "Link Gray"),
            new TypeName((int)ContourFilterCommandType.LinkColor,       "Link Color"),
            new TypeName((int)ContourFilterCommandType.ApproxColor,     "Approx Color")
         }),

         new TypeNameType(
         typeof(HistogramEqualizeType),
         new TypeName[]
         {
            new TypeName((int)HistogramEqualizeType.None,   "None"),
            new TypeName((int)HistogramEqualizeType.Rgb,    "RGB"),
            new TypeName((int)HistogramEqualizeType.Yuv,    "YUV"),
            new TypeName((int)HistogramEqualizeType.Gray,   "Gray")
         }),

         new TypeNameType(
         typeof(IntensityDetectCommandFlags),
         new TypeName[]
         {
            new TypeName((int)IntensityDetectCommandFlags.Master, "Master"),
            new TypeName((int)IntensityDetectCommandFlags.Red,    "Red"),
            new TypeName((int)IntensityDetectCommandFlags.Green,  "Green"),
            new TypeName((int)IntensityDetectCommandFlags.Blue,   "Blue")
         }),

         new TypeNameType(
         typeof(SwapColorsCommandType),
         new TypeName[]
         {
            new TypeName((int)SwapColorsCommandType.RedGreen,        "Red <-> Green"),
            new TypeName((int)SwapColorsCommandType.RedBlue,         "Red <-> Blue"),
            new TypeName((int)SwapColorsCommandType.GreenBlue,       "Green <-> Blue"),
            new TypeName((int)SwapColorsCommandType.RedGreenBlueRed, "Red <-> Green Blue <-> Red"),
            new TypeName((int)SwapColorsCommandType.RedBlueGreenRed, "Red <-> Blue Green <-> Red")
         })
      };

      private static TypeName[] GetTypeNamesFromType(Type type)
      {
         foreach(TypeNameType i in _typeNameType)
         {
            if(i.Type == type)
               return i.TypeName;
         }

         throw new ApplicationException("Invalid type");
      }

      public static string GetNameFromValue(Type type, object val)
      {
         TypeName[] a = GetTypeNamesFromType(type);
         for(int i = 0; i < a.Length; i++)
         {
            if(a[i].Value == (int)val)
               return a[i].Name;
         }

         throw new ApplicationException("Invalid type");
      }

      public static object GetValueFromName(Type type, string name, object def)
      {
         TypeName[] a = GetTypeNamesFromType(type);
         int index = -1;

         if(a != null)
         {
            for(int i = 0; i < a.Length && index == -1; i++)
            {
               if(name == a[i].Name)
                  return a[i].Value;
            }
         }

         return def;
      }
   }
}
