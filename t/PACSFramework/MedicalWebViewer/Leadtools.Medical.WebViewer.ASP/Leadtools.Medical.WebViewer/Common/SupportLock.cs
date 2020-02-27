// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace Leadtools.Medical.WebViewer.Common
{
   class SupportLock
   {
      static string Read(string configKey, string formatContents=null)
      {
         // licKey can be relative, absolute, or file contents
         var licKeySetting = ApplicationSettings.GetSettingValue(configKey);
         if (!string.IsNullOrEmpty(licKeySetting))
            licKeySetting = licKeySetting.Trim();

         if (!string.IsNullOrEmpty(licKeySetting) && FileUtility.IsAbsolutePath(licKeySetting) && File.Exists(licKeySetting))
         {
            var licKeyFile = licKeySetting;
            return File.ReadAllText(licKeyFile);
         }
         else if (!string.IsNullOrEmpty(licKeySetting))
         {
            // Could be a relative path or a developer key, see if the file exist
            var licKeyFile = FileUtility.GetAbsolutePath(licKeySetting);
            if (File.Exists(licKeyFile))
            {
               return File.ReadAllText(licKeyFile);
            }
            else
            {
               if (!string.IsNullOrEmpty(formatContents))
               {
                  return string.Format(formatContents, licKeySetting);
               }
               else
               {
                  return licKeySetting;
               }
            }
         }
         return null;
      }
      static string ReadLicenseKey()
      {
         // licKey can be relative, absolute, or file contents
         var key = Read("lt.License.Key");
         if (key == null)
         {
            // Was not found there, check the bin folder
            var currentContext = HttpContext.Current;
            if (currentContext != null && currentContext.Server != null)
            {
               string licBinPath = currentContext.Server.MapPath(@"~/bin/LEADTOOLS.LIC");
               if (File.Exists(licBinPath))
               {
                  // get value for licKey, process to get file contents
                  string licKeyBinPath = currentContext.Server.MapPath(@"~/bin/LEADTOOLS.LIC.key");
                  if (File.Exists(licKeyBinPath))
                     return File.ReadAllText(licKeyBinPath);
               }
            }
         }
         return key ;
      }

      static string ReadLicense()
      {
         // devLic can be relative, absolute, or file contents
         var lic = Read("lt.License", "[License]License = <doc><ver>2.0</ver><code>{0}</code></doc>");
         if (lic == null)
         {
            // Was not found there, check the bin folder
            var currentContext = HttpContext.Current;
            if (currentContext != null && currentContext.Server != null)
            {
               string licBinPath = currentContext.Server.MapPath(@"~/bin/LEADTOOLS.LIC");
               if (File.Exists(licBinPath))
               {
                  return File.ReadAllText(licBinPath);
               }
            }
         }
         return lic;
      }

      public static void SetLicense()
      {
         if (!RasterSupport.KernelExpired)
            return;

         // file path may be relative or absolute
         // license/dev key may be relative, absolute, or the full text
         string license = ReadLicense();
         string licKey = ReadLicenseKey();
                  
         if (!string.IsNullOrEmpty(license) && !string.IsNullOrEmpty(licKey))
         {
            RasterSupport.SetLicense (Encoding.ASCII.GetBytes(license), licKey);
         }
         else if (string.IsNullOrEmpty(license) && RasterSupport.KernelExpired)
         {
            Demos.Support.SetLicense(true);
         }          
      }
   }
}
