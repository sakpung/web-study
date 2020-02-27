// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Tasks.Common;
using System;
using System.Configuration;
using System.IO;

namespace Leadtools.Medical.WebViewer.Common
{
   internal class LTCachingCtrl
   {
      static object _cacheSettingsLock = new object();
      static LTCacheSettings _cacheSettings = null;
      public static LTCacheSettings CacheSettings
      {
         get
         {
            lock (_cacheSettingsLock)
            {
               if (null == _cacheSettings)
                  _cacheSettings = ReadCacheSettings();
               return _cacheSettings.Clone();
            }
         }
      }

      public static void Refresh()
      {
         lock (_cacheSettingsLock)
         {
            _cacheSettings = null;
         }
      }

      public sealed class LTCacheSettings
      {
         public LTCacheSettings()
         {
            Enabled = false;
            EnabledOnStore = false;
            Lifetime = new TimeSpan();
            Threshold = 0;
            DiskQuota = 0;
            FastResizeHugeFrames = false;
            Storage = "";
         }

         public LTCacheSettings Clone()
         {
            return new LTCacheSettings()
            {
               Enabled = Enabled,
               EnabledOnStore = EnabledOnStore,
               Lifetime = Lifetime,
               Threshold = Threshold,
               DiskQuota = DiskQuota,
               FastResizeHugeFrames = FastResizeHugeFrames,
               Storage = Storage
            };
         }

         public bool Enabled;
         public bool EnabledOnStore;
         public string Storage;
         public TimeSpan Lifetime;
         public int Threshold = 0;
         public int DiskQuota = 0;
         public bool FastResizeHugeFrames;
      }

      static Leadtools.Dicom.Imaging.Tasks.CachingTasksCleanup.LTCleanCacheState _cleanCacheState = new Leadtools.Dicom.Imaging.Tasks.CachingTasksCleanup.LTCleanCacheState();

      static string GetDefaultCacheStorage()
      {
         try
         {
            string storageLocation = string.Empty;

            using (StorageModuleConfigurationManager configManager = new StorageModuleConfigurationManager(false))
            {
               var serviceDirectory = ConfigurationManager.AppSettings.Get("storageServerServicePath");

               if (!string.IsNullOrEmpty(serviceDirectory))
               {
                  configManager.Load(serviceDirectory);
                  StorageAddInsConfiguration storageSettings = configManager.GetStorageAddInsSettings();
                  storageLocation = storageSettings.StoreAddIn.StorageLocation;

                  return Path.Combine(storageLocation, @"LTCache");
               }
            }
         }
         catch
         {
         }
         return string.Empty;
      }

      static Leadtools.Dicom.Imaging.Tasks.CachingTasksCleanup.LTCleanCacheState CreateCleanupCacheState(LTCacheSettings settings)
      {
         var cleanCacheState = new Leadtools.Dicom.Imaging.Tasks.CachingTasksCleanup.LTCleanCacheState();
         if (settings.Enabled)
         {
            cleanCacheState.CacheFolder = settings.Storage;
            cleanCacheState.Lifetime = settings.Lifetime;
         }
         else
         {
            cleanCacheState.CacheFolder = string.Empty;
         }
         return cleanCacheState;
      }

      public static Leadtools.Dicom.Imaging.DiskDataCacheStorage CreateCacheStorage(LTCacheSettings settings)
      {
         if (settings.Enabled)
         {
            var dataCacheStorage = new Leadtools.Dicom.Imaging.DiskDataCacheStorage(settings.Storage);
            return dataCacheStorage;
         }
         else
         {
            return null;
         }
      }

      public static Leadtools.Dicom.Imaging.IDataCacheProvider CreateCache(LTCacheSettings settings)
      {
         Leadtools.Dicom.Imaging.Config.CachingConfiguration.Instance.Threshold = settings.Threshold;
         Leadtools.Dicom.Imaging.Config.CachingConfiguration.Instance.CachingDiskQuota = settings.DiskQuota;
         Leadtools.Dicom.Imaging.Config.CachingConfiguration.Instance.FastResizeHugeFrames = settings.FastResizeHugeFrames;

         if (settings.Enabled)
         {
            var dataCache = new Leadtools.Dicom.Imaging.DiskDataCacheProvider(new Leadtools.Dicom.Imaging.DiskDataCacheStorage(settings.Storage));
            return dataCache;
         }
         else
         {
            var dataCache = new Leadtools.Dicom.Imaging.DataCachelessProvider();
            return dataCache;
         }
      }

      static LTCacheSettings ReadCacheSettings()
      {
         var cacheSettings = new LTCacheSettings();

         if (!bool.TryParse(ConfigurationManager.AppSettings.Get("Caching.Enabled"), out cacheSettings.Enabled))
         {
            cacheSettings.Enabled = false;
         }

         cacheSettings.Storage = ConfigurationManager.AppSettings.Get("Caching.Storage");

         if (string.IsNullOrEmpty(cacheSettings.Storage))
         {
            cacheSettings.Storage = GetDefaultCacheStorage();
         }

         if (string.IsNullOrEmpty(cacheSettings.Storage))
         {
            cacheSettings.Enabled = false;
         }

         if (cacheSettings.Enabled)
         {
            if (!bool.TryParse(ConfigurationManager.AppSettings.Get("Caching.OnStore"), out cacheSettings.EnabledOnStore))
            {
               cacheSettings.EnabledOnStore = false;
            }

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("Caching.Threshold"), out cacheSettings.Threshold))
            {
               cacheSettings.Threshold = 0;
            }

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("Caching.DiskQuota"), out cacheSettings.DiskQuota))
            {
               cacheSettings.DiskQuota = 0;
            }

            if (!bool.TryParse(ConfigurationManager.AppSettings.Get("Caching.FastResizeHugeFrames"), out cacheSettings.FastResizeHugeFrames))
            {
               cacheSettings.FastResizeHugeFrames = false;
            }

            if (!TimeSpan.TryParse(ConfigurationManager.AppSettings.Get("Caching.Lifetime"), out cacheSettings.Lifetime))
            {
               cacheSettings.Lifetime = TimeSpan.FromDays(1);
            }
         }

         return cacheSettings;
      }

      public static void QeueuWorkers()
      {
         try
         {
            //BG worker
            if (CacheSettings.Enabled && CacheSettings.EnabledOnStore)
            {
               var license = ServiceUtils.MapConfigPath(ConfigurationManager.AppSettings["license"]);
               var key = ConfigurationManager.AppSettings["key"];

               //out of process dispatch
               var m = typeof(Leadtools.Dicom.Imaging.Tasks.CachingTasksImport).GetMethod("Run");
               var p = new Leadtools.Dicom.Imaging.Tasks.CachingTasksImport.param() { license = license, key = key, cacheStore = CacheSettings.Storage };
               OutOfProcessTaskDispatcher.Instance.RunOne(m, p);

               //local dispatch
               //RecurringTasksDispatcher.Instance.AddAction(ImportIntoCache, null);
            }

            //BG worker
            if (CacheSettings.Enabled)
            {
               //no cleanup if 0 is specified
               if (CacheSettings.Lifetime.TotalSeconds != 0)
               {
                  _cleanCacheState = CreateCleanupCacheState(CacheSettings);
                  RecurringTasksDispatcher.Instance.AddAction(Leadtools.Dicom.Imaging.Tasks.CachingTasksCleanup.CleanupCache, _cleanCacheState);
               }
            }
         }
         catch
         {
            //ignored
         }
      }
   }
}
