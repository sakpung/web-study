// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.AddIn.Configuration;
using System.IO;

namespace Leadtools.Medical.WebViewer.JobsCleanupAddin
{
   public class JobsCleanupConfigurationViewProxy : IDisposable
   {
      
      public JobsCleanupConfigurationViewProxy()
      {
      }

       public void Dispose ( )
            {
               Dispose(true);
               GC.SuppressFinalize ( this ) ;
            }

       ~JobsCleanupConfigurationViewProxy() 
            {
               Dispose(false);
            }

       protected virtual void Dispose(bool disposing)
       {
          if (disposing)
          {             
          }
       }

       public string ServerDirectory { get; set; }
      public JobsCleanupConfigurationViewProxy(string _ServerDirectory, string _ServiceName)
      {
         ServerDirectory = _ServerDirectory;
         
         PopulateSettings();
      }

      const string PluginsSettingsFolderName = @"JobsCleanupSettings";

      public AdvancedSettings Load(string serviceDirectory)
      {
         string PluginsSettingsPath = Path.Combine(serviceDirectory, PluginsSettingsFolderName);
         try
         {
            Directory.CreateDirectory(PluginsSettingsPath);
         }
         catch{
         }
         AdvancedSettings _advancedSettings = AdvancedSettings.Open(PluginsSettingsPath);
         return _advancedSettings;
      }

      DateTime GetNoRunDateTime()
      {
         return DateTime.Now - new TimeSpan(1, 0, 0);
      }

      DateTime GetRunDateTime()
      {
         return DateTime.Now;
      }
         
      public void ReadSettings(StorageAddInsConfiguration settings, bool fRunNow)
      {
         settings.JobsCleanupAddIn.Run = fRunNow?GetRunDateTime():GetNoRunDateTime();
         settings.JobsCleanupAddIn.Enable = (bool)Enable;
         settings.JobsCleanupAddIn.ExpiryInterval = (int)ExpiryIntervalProperty;
         settings.JobsCleanupAddIn.ExpiryIntervalCustom = (int)ExpiryIntervalCustomProperty;
         settings.JobsCleanupAddIn.CheckInterval = (int)CheckIntervalProperty;
         settings.JobsCleanupAddIn.CheckIntervalCustom = (int)CheckIntervalCustomProperty;
         settings.JobsCleanupAddIn.MaxRetry = (int)MaxRetry;
      }

      public void PopulateSettings()
      {
         //defaults
         Run = GetNoRunDateTime();
         Enable = true;
         CheckIntervalProperty = CheckInterval.custom;
         CheckIntervalCustomProperty = 2;
         ExpiryIntervalProperty = ExpiryInterval.custom;
         ExpiryIntervalCustomProperty = 2;
         MaxRetry = 3;

         try
         {
            StorageAddInsConfiguration settings;
            
            string addInsName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            settings = Load(ServerDirectory).GetAddInCustomData<StorageAddInsConfiguration>(addInsName, StorageAddInsConfiguration.SectionName);

            if (null != settings)
            {
               if (null != settings.JobsCleanupAddIn.Run)
               {
                  Run = (DateTime)settings.JobsCleanupAddIn.Run;
               } 
               if (null != settings.JobsCleanupAddIn.Enable)
               {
                  Enable = (bool)settings.JobsCleanupAddIn.Enable;
               }
               if (null != settings.JobsCleanupAddIn.ExpiryInterval)
               {
                  ExpiryIntervalProperty = (ExpiryInterval)settings.JobsCleanupAddIn.ExpiryInterval;
               }
               if (null != settings.JobsCleanupAddIn.ExpiryIntervalCustom)
               {
                  ExpiryIntervalCustomProperty = (int)settings.JobsCleanupAddIn.ExpiryIntervalCustom;
               }
               if (null != settings.JobsCleanupAddIn.CheckInterval)
               {
                  CheckIntervalProperty = (CheckInterval)settings.JobsCleanupAddIn.CheckInterval;
               }
               if (null != settings.JobsCleanupAddIn.CheckIntervalCustom)
               {
                  CheckIntervalCustomProperty = (int)settings.JobsCleanupAddIn.CheckIntervalCustom;
               }
               if (null != settings.JobsCleanupAddIn.MaxRetry)
               {
                  MaxRetry = (int)settings.JobsCleanupAddIn.MaxRetry;
               }
            }
         }
         catch
         {
         }
      }

      public void Apply()
      {
         AdvancedSettings _advancedSettings = Load(ServerDirectory);
         StorageAddInsConfiguration settings;
         string addInsName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
         settings = _advancedSettings.GetAddInCustomData<StorageAddInsConfiguration>(addInsName, StorageAddInsConfiguration.SectionName);

         if (null == settings)
         {
            settings = new StorageAddInsConfiguration();
         }

         ReadSettings(settings, false);
         _advancedSettings.SetAddInCustomData<StorageAddInsConfiguration>(addInsName, StorageAddInsConfiguration.SectionName, settings);
         _advancedSettings.Save();
      }

      public DateTime Run
      {
         get;
         set;
      }

      public bool Enable
      {
         get;
         set;
      }

      public void RunCleanupNow()
      {
         AdvancedSettings _advancedSettings = Load(ServerDirectory);
         StorageAddInsConfiguration settings;
         string addInsName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
         settings = _advancedSettings.GetAddInCustomData<StorageAddInsConfiguration>(addInsName, StorageAddInsConfiguration.SectionName);

         if (null == settings)
         {
            settings = new StorageAddInsConfiguration();
         }

         ReadSettings(settings, true);
         _advancedSettings.SetAddInCustomData<StorageAddInsConfiguration>(addInsName, StorageAddInsConfiguration.SectionName, settings);
         _advancedSettings.Save();
      }

      public enum CheckInterval
      {
         custom,
         daily,
         weekly
      }

      public CheckInterval CheckIntervalProperty
      {
         get;
         set;
      }

      public int CheckIntervalCustomProperty
      {
         get;
         set;
      }

      public TimeSpan GetCheckIntervalTimeSpan()
      {
         switch (CheckIntervalProperty)
            {
            case CheckInterval.daily:
                  {
                     return new TimeSpan(1, 0, 0, 0);
                  }
            case CheckInterval.weekly:
                  {
                     return new TimeSpan(7, 0, 0, 0);
                  }
            case CheckInterval.custom:
                  {
                     return new TimeSpan(CheckIntervalCustomProperty, 0, 0);
                  }
            }
         return new TimeSpan(0, 1, 0);
      }

      public enum ExpiryInterval
      {
         custom,
         day,
         week,
         month
      }

      public ExpiryInterval ExpiryIntervalProperty
      {
         get;
         set;
      }

      public int ExpiryIntervalCustomProperty
      {
         get;
         set;
      }

      public TimeSpan GetExpiryIntervalTimeSpan()
      {
         switch (ExpiryIntervalProperty)
         {
            case ExpiryInterval.day:
               {
                  return new TimeSpan(1, 0, 0, 0);
               }
            case ExpiryInterval.week:
               {
                  return new TimeSpan(7, 0, 0, 0);
               }
            case ExpiryInterval.month:
               {
                  return new TimeSpan(30, 0, 0, 0);
               }
            case ExpiryInterval.custom:
               {
                  return new TimeSpan(ExpiryIntervalCustomProperty, 0, 0);
               }
         }
         return new TimeSpan(0, 1, 0);
      }
      public int MaxRetry
      {
         get;
         set;
      }
   }
}
