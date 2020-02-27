// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.Tools
{
   static class Units
   {
      public static int ScreenResolution;

      private static string[] _unitAbbreviations =
      {
         "pixels",
         "inches",
         "millimeters"
      };

      public static string Format(double width, double height, CodecsRasterizeDocumentUnit unit)
      {
         if(unit == CodecsRasterizeDocumentUnit.Pixel)
         {
            return string.Format("{0} x {1} {2}", (int)width, (int)height, _unitAbbreviations[(int)unit]);
         }
         else
         {
            return string.Format("{0} x {1} {2}", width.ToString("0.00"), height.ToString("0.00"), _unitAbbreviations[(int)unit]);
         }
      }

      public static double Convert(double value, CodecsRasterizeDocumentUnit sourceUnit, int resolution, CodecsRasterizeDocumentUnit destinationUnit)
      {
         double pixels = ConvertToPixels(value, sourceUnit, resolution);
         double result = ConvertFromPixels(pixels, destinationUnit, resolution);
         return result;
      }

      // An inch in millimeters
      private const double _mmRatio = 25.400000025908000026426160026955;

      private static double ConvertToPixels(double value, CodecsRasterizeDocumentUnit unit, int resolution)
      {
         double ret;

         switch(unit)
         {
            case CodecsRasterizeDocumentUnit.Pixel:
               ret = value;
               break;

            case CodecsRasterizeDocumentUnit.Inch:
               ret = value * (double)resolution;
               break;

            case CodecsRasterizeDocumentUnit.Millimeter:
               ret = value * (double)resolution / _mmRatio;
               break;

            default:
               throw new InvalidOperationException();
         }

         return ret;
      }

      private static double ConvertFromPixels(double value, CodecsRasterizeDocumentUnit unit, int resolution)
      {
         double ret;

         switch(unit)
         {
            case CodecsRasterizeDocumentUnit.Pixel:
               ret = value;
               break;

            case CodecsRasterizeDocumentUnit.Inch:
               ret = value / (double)resolution;
               break;

            case CodecsRasterizeDocumentUnit.Millimeter:
               ret = value * _mmRatio / (double)resolution;
               break;

            default:
               throw new InvalidOperationException();
         }

         return ret;
      }
   }
}
