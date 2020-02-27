// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.Services.Twain;

namespace Leadtools.WebScanning.Host
{
   internal static class ImageProcessing
   {
      private delegate void IPFunction(RasterImage image, string arguments);

      private static readonly IDictionary<string, IPFunction> _ipCommands = new Dictionary<string, IPFunction>
      {
         { "Flip", FlipImage },
         { "Rotate", RotateImage },
         { "Deskew", DeskewImage },
         { "HolePunchRemove", HolePunchRemove },
         { "BorderRemove", BorderRemove }
      };

      public static void Run(PageImageProcessingEventArgs e)
      {
         string commandName = e.CommandName;
         string arguments = e.Arguments;
         RasterImage image = e.Image;

         // check the commands
         var ipFunction = _ipCommands[commandName] != null ? _ipCommands[commandName] : null;
         if (ipFunction != null)
            ipFunction(image, arguments);

         if (e.IsPreview)
            DemoUtils.ResizeImage(image, e.PreviewWidth, e.PreviewHeight);
      }

      private static void FlipImage(RasterImage image, string arguments)
      {
         bool horizontal = DemoUtils.JsonStringToBoolean(arguments, "horizontal");

         image.FlipViewPerspective(horizontal);
      }

      private static void RotateImage(RasterImage image, string arguments)
      {
         int angle = DemoUtils.JsonStringToInteger(arguments, "angle");
         while (angle > 360) angle -= 360;
         while (angle < 0) angle += 360;

         if (Math.Abs(angle) != 90 && Math.Abs(angle) != 180 && Math.Abs(angle) != 270 && Math.Abs(angle) != 360)
            throw new ArgumentException("Invalid angle");

         image.RotateViewPerspective(angle);
      }

      private static void DeskewImage(RasterImage image, string arguments)
      {
         int angleRange = DemoUtils.JsonStringToInteger(arguments, "angleRange");
         int angleResolution = DemoUtils.JsonStringToInteger(arguments, "angleResolution");
         RasterColor fillColor = DemoUtils.JsonStringToRasterColor(arguments, "fillColor");
         int flags = DemoUtils.JsonStringToInteger(arguments, "flags");

         DeskewCommand cmd = new DeskewCommand(fillColor, (DeskewCommandFlags)flags);
         cmd.AngleRange = angleRange;
         cmd.AngleResolution = angleResolution;

         cmd.Run(image);
      }

      private static void BorderRemove(RasterImage image, string arguments)
      {
         int flags = DemoUtils.JsonStringToInteger(arguments, "flags");
         int border = DemoUtils.JsonStringToInteger(arguments, "border");
         int percent = DemoUtils.JsonStringToInteger(arguments, "percent");
         int whiteNoiseLength = DemoUtils.JsonStringToInteger(arguments, "whiteNoiseLength");
         int variance = DemoUtils.JsonStringToInteger(arguments, "variance");

         if (image.BitsPerPixel != 1)
         {
            ColorResolutionCommand cmdColorRes = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 1, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.Fixed, null);

            cmdColorRes.Run(image);
         }

         if ((BorderRemoveBorderFlags)border == BorderRemoveBorderFlags.None)
         {
            border = (int)(new BorderRemoveCommand()).Border;
         }

         BorderRemoveCommand cmd = new BorderRemoveCommand((BorderRemoveCommandFlags)flags, (BorderRemoveBorderFlags)border, percent, whiteNoiseLength, variance);

         cmd.Run(image);
      }

      private static void HolePunchRemove(RasterImage image, string arguments)
      {
         int flags = DemoUtils.JsonStringToInteger(arguments, "flags");
         int location = DemoUtils.JsonStringToInteger(arguments, "location");

         int minimumHoleCount = DemoUtils.JsonStringToInteger(arguments, "minimumHoleCount");
         int maximumHoleCount = DemoUtils.JsonStringToInteger(arguments, "maximumHoleCount");

         int minimumHoleWidth = DemoUtils.JsonStringToInteger(arguments, "minimumHoleWidth");
         int minimumHoleHeight = DemoUtils.JsonStringToInteger(arguments, "minimumHoleHeight");

         int maximumHoleWidth = DemoUtils.JsonStringToInteger(arguments, "maximumHoleWidth");
         int maximumHoleHeight = DemoUtils.JsonStringToInteger(arguments, "maximumHoleHeight");

         if (image.BitsPerPixel != 1)
         {
            ColorResolutionCommand cmdColorRes = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 1, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.Fixed, null);

            cmdColorRes.Run(image);
         }

         HolePunchRemoveCommand cmd = new HolePunchRemoveCommand((HolePunchRemoveCommandFlags)flags,
            (HolePunchRemoveCommandLocation)location,
            minimumHoleCount,
            maximumHoleCount,
            minimumHoleWidth,
            minimumHoleHeight,
            maximumHoleWidth,
            maximumHoleHeight);

         cmd.Run(image);
      }
   }
}
