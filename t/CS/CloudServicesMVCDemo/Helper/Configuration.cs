using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Leadtools;
using System.Web.Hosting;

namespace Cloud_Services_Api.Configuration
{
   public static class DemoConfiguration
   {
      ///The path to your license file.
      public const string LicensePath = @"";

      ///The contents of your LEADTOOLS license key file
      public const string DeveloperKey = "";

      ///Path to the LEADTOOLS OCR engine bin directory
      public static string OCREnginePath = @"";

      ///The max file size allowed by URL parameters
      public const int MaxUrlMbs = 30;

      ///The max file size allowed by URL parameters
      public const int MaxSvgElements = 30000;

      /// Output File Directory when performing conversions
      public static string OutputFileDirectory = HostingEnvironment.MapPath(@"~/Files/");

      public static bool UnlockSupport()
      {
         if (RasterSupport.KernelExpired)
         {
            try
            {
               RasterSupport.SetLicense(LicensePath, DeveloperKey);
            }
            catch (Exception ex)
            {
               Debug.WriteLine("Error Setting License: " + ex.Message);
            }
         }

         if (RasterSupport.KernelExpired)
         {
            string msg = "Your license file is missing, invalid or expired. LEADTOOLS will not function. Please contact LEAD Sales for information on obtaining a valid license.";
            Debug.WriteLine($"*******************************************************************************{Environment.NewLine}");
            Debug.WriteLine($"*** NOTE: {msg} ***{Environment.NewLine}");
            Debug.WriteLine($"*******************************************************************************{Environment.NewLine}");
            return false;

         }
         return true;
      }
   }
}