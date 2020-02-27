// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;
using System.Diagnostics;
using Leadtools.ImageProcessing;

namespace Leadtools.Medical.WebViewer.Addins
{
   class ProcessingActions
   {
      public static void MultiscaleEnhancement(RasterImage image, params string[] parameters)
      {
         MultiscaleEnhancementCommand cmd = new MultiscaleEnhancementCommand();
         int contrast, edgeLevels, edgeCoeff, latLevels, latCoeff;
         MultiscaleEnhancementCommandType enhancementType = MultiscaleEnhancementCommandType.Gaussian;

         if (parameters.Length >= 6)
         {
            if (!int.TryParse(parameters[0], out contrast))
               return;

            if (!int.TryParse(parameters[1], out edgeLevels))
               return;

            if (!int.TryParse(parameters[2], out edgeCoeff))
               return;

            if (!int.TryParse(parameters[3], out latLevels))
               return;

            if (!int.TryParse(parameters[4], out latCoeff))
               return;

            parameters[5].TryParse<MultiscaleEnhancementCommandType>(out enhancementType);

            cmd.Contrast = contrast;
            cmd.EdgeLevels = edgeLevels;
            cmd.EdgeCoefficient = edgeCoeff;
            cmd.LatitudeLevels = latLevels;
            cmd.LatitudeCoefficient = latCoeff;
            cmd.Type = enhancementType;
            cmd.Flags = cmd.Flags | MultiscaleEnhancementCommandFlags.DontUseThreading;
            cmd.Run(image);
         }        
      }

      public static void GammaCorrect(RasterImage image, params string[] parameters)
      {
         if (parameters.Length >= 1)
         {
            int value;

            if (int.TryParse(parameters[0], out value))
            {
               GammaCorrectCommand cmd = new GammaCorrectCommand();

               cmd.Gamma = value;
               cmd.Run(image);
            }
         }        
      }

      public static void UnsharpMask(RasterImage image, params string[] parameters)
      {
         if (parameters.Length >= 3)
         {
            int amount, radius, threshold;
            UnsharpMaskCommand cmd = new UnsharpMaskCommand();

            if (!int.TryParse(parameters[0], out amount))
               return;

            if (!int.TryParse(parameters[1], out radius))
               return;

            if (!int.TryParse(parameters[2], out threshold))
               return;

            cmd.Amount = amount;
            cmd.Radius = radius;
            cmd.Threshold = threshold;
            cmd.Run(image);
         }        
      }

      public static void BrightnessContrast(RasterImage image, params string[] parameters)
      {
          if (parameters.Length >= 2)
          {
              int brightness, contrast;
              ContrastBrightnessIntensityCommand cmd = new ContrastBrightnessIntensityCommand();

              if (!int.TryParse(parameters[0], out brightness))
                  return;

              if (!int.TryParse(parameters[1], out contrast))
                  return;

              cmd.Brightness = brightness;
              cmd.Contrast = contrast;
              cmd.Run(image);
          } 
      }

      public static void HSL(RasterImage image, params string[] parameters)
      {
          if (parameters.Length >= 3)
          {
              int hue, saturation, intensity;
              ChangeHueSaturationIntensityCommand cmd = new ChangeHueSaturationIntensityCommand();

              if (!int.TryParse(parameters[0], out hue))
                  return;

              if (!int.TryParse(parameters[1], out saturation))
                  return;

              if (!int.TryParse(parameters[2], out intensity))
                  return;

              cmd.Hue = hue;
              cmd.Saturation = saturation;
              cmd.Intensity = intensity;
              cmd.Run(image);
          } 
      }

      public static void StretchHistogram(RasterImage image, params string[] parameters)
      {
         StretchIntensityCommand cmd = new StretchIntensityCommand();

         cmd.Run(image);
      }

      public static void WindowLevel(RasterImage image, params string[] parameters)
      {
          if (parameters.Length >= 3)
          {
              int width, center;
              bool inverted;

              if (!int.TryParse(parameters[0], out width))
                  return;

              if (!int.TryParse(parameters[1], out center))
                  return;

              if (!bool.TryParse(parameters[2], out inverted))
                  return;

              int nLowBit = image.LowBit;
              int nHighBit = image.HighBit;
              if (nHighBit == -1)
                  nHighBit = image.BitsPerPixel - 1;

              int uLUTLen = 1 << (nHighBit - image.LowBit + 1);

              int nFrom = center - (width >> 1);
              int nTo = center + ((width + 1) >> 1);

              int nFullMinValue;
              int nFullMaxValue;

              int nLookupTableLength = 0;
              if (image.GetLookupTable() != null)
                  nLookupTableLength = image.GetLookupTable().Length;

              if (image.BitsPerPixel == 8)
              {
                  nFullMinValue = 0;
                  nFullMaxValue = 255;
              }
              else
              {
                  if (nLookupTableLength == 0)
                  {
                      nFullMinValue = !image.Signed ? 0 : -(0xffff + 1) / 2;
                      nFullMaxValue = !image.Signed ? 0xffff - 1 : (0xffff + 1) / 2 - 1;
                  }
                  else
                  {
                      nFullMinValue = !image.Signed ? 0 : -(nLookupTableLength + 1) / 2;
                      nFullMaxValue = !image.Signed ? nLookupTableLength - 1 : (nLookupTableLength + 1) / 2 - 1;
                  }
              }


              RasterColor[] lookUpTable = new RasterColor[uLUTLen];

              RasterPaletteWindowLevelFlags flags = ((image.Signed) ? RasterPaletteWindowLevelFlags.Signed : RasterPaletteWindowLevelFlags.None) | RasterPaletteWindowLevelFlags.Outside | RasterPaletteWindowLevelFlags.Linear | RasterPaletteWindowLevelFlags.DicomStyle;


              RasterColor startColor = new RasterColor(0, 0, 0);
              RasterColor endColor = new RasterColor(255, 255, 255);
              RasterPalette.WindowLevelFillLookupTable(lookUpTable, (!inverted) ? startColor : endColor, (!inverted) ? endColor : startColor, nFrom, nTo, nLowBit, nHighBit, nFullMinValue, nFullMaxValue, 1, flags);

              if (image.BitsPerPixel == 8)
              {
                  image.SetPalette(lookUpTable, 0, 256);
              }
              else
              {
                  image.WindowLevel(nLowBit, nHighBit, lookUpTable, RasterWindowLevelMode.PaintAndProcessing);
              }
          } 
      }

      public static void Invert(RasterImage image, params string[] parameters)
      {
          InvertCommand cmd = new InvertCommand();

          cmd.Run(image);
      }

      public static void Flip(RasterImage image, params string[] parameters)
      {
          FlipCommand cmd = new FlipCommand();
          bool horizontal = false;

          if(parameters.Length > 0)
          {
              bool.TryParse(parameters[0], out horizontal);
          }

          cmd.Horizontal = horizontal;
          cmd.Run(image);
      }

      public static void Rotate(RasterImage image, params string[] parameters)
      {
          if (parameters.Length > 0)
          {
              int angle = 0;

              if(int.TryParse(parameters[0], out angle))
              {
                  RotateCommand cmd = new RotateCommand();

                  cmd.Angle = angle * 100;
                  cmd.Run(image);
              }
          }
      }
   }
}
