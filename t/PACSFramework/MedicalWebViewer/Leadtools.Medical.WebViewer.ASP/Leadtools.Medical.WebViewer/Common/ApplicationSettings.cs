// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Leadtools.Medical.WebViewer.Common
{
   internal static class ApplicationSettings
   {
      public static string GetSettingValue(string key)
      {
         var currentContext = HttpContext.Current;
         string value = null;
         if (currentContext != null)
         {
            if (ConfigurationManager.AppSettings[key] != null)
               value = ConfigurationManager.AppSettings[key];
         }
         if (value == null)
         {
            // Load it from the config file
            var config = ConfigurationManager.OpenExeConfiguration(typeof(ApplicationSettings).Assembly.Location);
            if (config != null)
            {
               // Get the appSettings section
               var appSettings = (AppSettingsSection)config.GetSection("appSettings");
               if (appSettings != null)
               {
                  if (appSettings.Settings[key] != null)
                     value = appSettings.Settings[key].Value;
                  else
                     value = string.Empty;
               }
            }
         }

         return value;
      }

      public static void Update(this KeyValueConfigurationCollection settings, string key, string value)
      {
         if (settings[key] != null)
         {
            settings.Remove(key);
         }

         settings.Add(key, value);
      }

      public static bool UpdateSettingValue(string key, string value)
      {
         var currentContext = HttpContext.Current;         
         if (currentContext != null)
         {
            if (ConfigurationManager.AppSettings[key] != null)
            {
               if(value == ConfigurationManager.AppSettings[key])
               {
                  return false;
               }
            }
            else
            {
               return false;
            }
         }

         var configuration = WebConfigurationManager.OpenWebConfiguration("~");
         configuration.AppSettings.File = null;

         var section = (AppSettingsSection)configuration.GetSection("appSettings");            
         section.Settings.Update(key, value);

         configuration.Save();

         return true;
      }

      public static ConnectionStringSettingsCollection GetConnectionStrings()
      {
         var currentContext = HttpContext.Current;
         
         if (currentContext != null)
         {
            if (ConfigurationManager.ConnectionStrings != null)
            {
               return ConfigurationManager.ConnectionStrings;
            }
         }
         
         // Load it from the config file
         var config = ConfigurationManager.OpenExeConfiguration(typeof(ApplicationSettings).Assembly.Location);
         if (config != null)
         {
            return config.ConnectionStrings.ConnectionStrings;
         }

         return null;
      }
   }
}
