// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Script.Serialization;
using Leadtools.Codecs;
using Leadtools.ImageProcessing;

namespace Leadtools.WebScanning.Host
{
   internal static class DemoUtils
   {
#if HTTPS_SUPPORT
      private const string _protocol = "https";
#else
      private const string _protocol = "http";
#endif // #if HTTPS_SUPPORT
      private const string _serviceName = "ScanService";
      private const string _servicePortNumber = "";

      public static string ServiceUrl;

      static DemoUtils()
      {
         ServiceUrl = string.Format("{0}://{1}{2}/{3}", _protocol, System.Net.Dns.GetHostEntry("").HostName, (string.IsNullOrEmpty(_servicePortNumber) ? string.Empty : ":" + _servicePortNumber), _serviceName);
      }

      public static void RegisterServiceUrl()
      {
         RegisterServiceUrl(true);
      }

      public static void UnRegisterServiceUrl()
      {
         RegisterServiceUrl(false);
      }

      private static void RegisterServiceUrl(bool register)
      {
         string url = string.Format("{0}://+:{1}/{2}", _protocol, (string.IsNullOrEmpty(_servicePortNumber) ? "80" : _servicePortNumber), _serviceName);
         if (register)
            StartProcess("netsh", string.Format("http add urlacl url={0} user=everyone", url));
         else
            StartProcess("netsh", string.Format("http delete urlacl url={0}", url));
      }

      private static void StartProcess(string name, string arguments)
      {
         ProcessStartInfo procStartInfo = new ProcessStartInfo(name, arguments);
         procStartInfo.UseShellExecute = false;

         Process process = Process.Start(procStartInfo);
         process.WaitForExit();
      }

      private const int _defaultResolution = 300;

      // Optionally resizes the image before saving it (always preserving the original aspect ratio)
      public static void ResizeImage(RasterImage image, int width, int height)
      {
         SizeCommand sizeCommand;
         int resizeWidth;
         int resizeHeight;

         RasterSizeFlags flags = RasterSizeFlags.Resample;
         if (image.BitsPerPixel == 1)
            flags |= RasterSizeFlags.FavorBlack;

         // First check if its a FAX image (with different resolution), if so, resize it too
         if (image.XResolution != 0 && image.YResolution != 0 && Math.Abs(image.XResolution - image.YResolution) > 2)
         {
            // Yes
            if (image.XResolution > image.YResolution)
            {
               resizeWidth = image.ImageWidth;
               resizeHeight = (int)((double)image.ImageHeight * (double)image.XResolution / (double)image.YResolution);
            }
            else
            {
               resizeHeight = image.ImageHeight;
               resizeWidth = (int)((double)image.ImageWidth * (double)image.YResolution / (double)image.XResolution);
            }

            sizeCommand = new SizeCommand(resizeWidth, resizeHeight, flags);
            sizeCommand.Run(image);

            image.XResolution = Math.Max(image.XResolution, image.YResolution);
            image.YResolution = image.XResolution;
         }

         // Check user resize options, and resize only if needed
         if ((width == 0 && height == 0) ||
            (image.ImageWidth <= width && image.ImageHeight <= height))
            return;

         resizeWidth = width;
         resizeHeight = height;

         // If width or height is 0, means the other is a fixed value and the missing value must be calculated
         // saving the aspect ratio
         if (resizeHeight == 0)
            resizeHeight = (int)((double)image.ImageHeight * (double)resizeWidth / (double)image.ImageWidth + 0.5);
         else if (resizeWidth == 0)
            resizeWidth = (int)((double)image.ImageWidth * (double)resizeHeight / (double)image.ImageHeight + 0.5);

         // Calculate the destination size
         LeadRect rc = new LeadRect(0, 0, resizeWidth, resizeHeight);
         rc = RasterImage.CalculatePaintModeRectangle(
            image.ImageWidth,
            image.ImageHeight,
            rc,
            RasterPaintSizeMode.Fit,
            RasterPaintAlignMode.Near,
            RasterPaintAlignMode.Near);

         image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
         sizeCommand = new SizeCommand(rc.Width, rc.Height, flags);
         sizeCommand.Run(image);

         // Note, if the image was 1BPP, ScaleToGray converts it to 8, the format of the returned image is dealt with
         // in PrepareToSave

         // Since we resized the image, the original DPI is not correct anymore
         image.XResolution = 96;
         image.YResolution = 96;
      }

      public static void InitCodecs(RasterCodecs codecs, int resolution)
      {
         if (resolution == 0)
            resolution = _defaultResolution;

         // Set the load resolution
         codecs.Options.Wmf.Load.Resolution = resolution;
         codecs.Options.RasterizeDocument.Load.Resolution = resolution;
      }

      public static string JsonStringToString(string jsonString, string key)
      {
         JavaScriptSerializer json = new JavaScriptSerializer();
         Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(jsonString);

         return data[key];
      }

      public static int JsonStringToInteger(string jsonString, string key)
      {
         JavaScriptSerializer json = new JavaScriptSerializer();
         Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(jsonString);

         return Convert.ToInt32(data[key]);
      }

      public static bool JsonStringToBoolean(string jsonString, string key)
      {
         JavaScriptSerializer json = new JavaScriptSerializer();
         var data = json.Deserialize<Dictionary<string, string>>(jsonString);

         return Convert.ToBoolean(data[key]);
      }

      public static RasterColor JsonStringToRasterColor(string jsonString, string key)
      {
         JavaScriptSerializer json = new JavaScriptSerializer();
         Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(jsonString);
         Dictionary<string, byte> clr = json.Deserialize<Dictionary<string, byte>>(data[key]);

         RasterColor color = new RasterColor();
         color.A = clr["A"];
         color.R = clr["R"];
         color.G = clr["G"];
         color.B = clr["B"];

         return color;
      }
   }
}
