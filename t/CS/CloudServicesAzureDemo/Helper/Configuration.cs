using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leadtools;
using Microsoft.Azure.WebJobs.Host;

namespace Serverless_Cloud_Services_API
{
   public static class DemoConfiguration
   {
      //The path to your license file.
      public const string LicensePath = @"";

      //The contents of your LEADTOOLS license key file
      public const string DeveloperKey = "";

      //Path to the LEADTOOLS OCR engine bin directory
      public static string OCREnginePath = "";

      //The max file size allowed by URL parameters
      public const int MaxUrlMbs = 30;

      //The max file size allowed by URL parameters
      public const int MaxSvgElements = 30000;

      // Output File Directory
      public static string OutputFileDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
      
      //The connection string for your Azure Blob Storage Account
      internal static string BlobStorageConnectionString = "";

      //The Azure Blob container to use
      internal static string BlobContainerName = "";

      public static bool UnlockSupport(TraceWriter log)
      {
         if (RasterSupport.KernelExpired)
         {
            try
            {
               RasterSupport.SetLicense(LicensePath, DeveloperKey);
            }
            catch (Exception ex)
            {
               log.Error("Error Setting License: " + ex.Message);
            }
         }

         if (RasterSupport.KernelExpired)
         {
            string msg = "Your license file is missing, invalid or expired. LEADTOOLS will not function. Please contact LEAD Sales for information on obtaining a valid license.";
            log.Error($"*******************************************************************************{Environment.NewLine}");
            log.Error($"*** NOTE: {msg} ***{Environment.NewLine}");
            log.Error($"*******************************************************************************{Environment.NewLine}");
            return false;

         }
         return true;
      }
   }
}
