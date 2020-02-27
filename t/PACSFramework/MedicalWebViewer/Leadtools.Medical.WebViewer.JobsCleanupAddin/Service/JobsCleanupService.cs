// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.Jobs;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using System.Timers;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using System.Reflection;
using Leadtools.Dicom.AddIn.Configuration;
using System.IO;
using System.Configuration;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer.Configuration;

namespace Leadtools.Medical.WebViewer.JobsCleanupAddin
{
   public class JobsCleanupService : IDisposable
   {
      static JobsCleanupService _instance = null;
      static IDownloadJobsDataAccessAgent DownloadJobsDataAccessAgent = null;
      static Timer _timer;

      public static bool HasInstance
      {
         get { return _instance != null; }
      }

      public static JobsCleanupService Instance
      {
         get
         {
            if (null == _instance)
            {
               #region LOG
               {
                  string message = @"Jobs Cleanup - Jobs Service Create Instance";
                  Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                   LogType.Information, MessageDirection.None, message, null, null);
               }
               #endregion

               _instance = new JobsCleanupService();
                              
               try
               {
                  DownloadJobsDataAccessAgent = DataAccessServices.GetDataAccessService<IDownloadJobsDataAccessAgent>();
               }
               catch (System.Exception ex)
               {
                  #region LOG
                  {
                     Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                      LogType.Error, MessageDirection.None, ex.Message, null, null);
                  }
                  #endregion
                  throw;	
               }

               _timer = new Timer(1000);
               _timer.Elapsed += new ElapsedEventHandler(_instance._timer_Elapsed);
               _timer.Enabled = true;
            }

            return _instance;
         }
      }

      static public void Init()
      {
         #region LOG
         {
            string message = @"Jobs Cleanup - Initialize Jobs Service";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         JobsCleanupService __instance = Instance;
      }

      static public void ShutDown()
      {
         #region LOG
         {
            string message = @"Jobs Cleanup - Shutting down Jobs Service";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         _timer.Enabled = false;
         _instance.Dispose();
         _instance = null;
      }

      DateTime MileStone { get; set; }

      protected JobsCleanupService()
      {
         MileStone = DateTime.Now;
         LoadSettings();
         RegisterForSettingsChangedEvent();
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      ~JobsCleanupService()
      {
         Dispose(false);
      }

      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
         {
            UnRegisterForSettingsChangedEvent();
         }
      }

      private AdvancedSettings _advancedSettings;
      private SettingsChangedNotifier _settingsChangedNotify;

      const string PluginsSettingsFolderName = @"JobsCleanupSettings";

      public AdvancedSettings Load(string serviceDirectory)
      {
         string PluginsSettingsPath = Path.Combine(serviceDirectory, PluginsSettingsFolderName);
         try
         {
            Directory.CreateDirectory(PluginsSettingsPath);
         }
         catch
         {
         }
         AdvancedSettings _advancedSettings = AdvancedSettings.Open(PluginsSettingsPath);
         return _advancedSettings;
      }

      void RegisterForSettingsChangedEvent()
      {
         _advancedSettings = Load(JobsCleanupSession.ServiceDirectory);

         _settingsChangedNotify = new SettingsChangedNotifier(_advancedSettings);

         _settingsChangedNotify.SettingsChanged += new EventHandler(notifier_SettingsChanged);

         _settingsChangedNotify.Enabled = true;

      }

      void UnRegisterForSettingsChangedEvent()
      {
         if (null != _settingsChangedNotify)
         {
            _settingsChangedNotify.Dispose();

            _settingsChangedNotify = null;
         }
      }

      private void notifier_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (null != _advancedSettings)
            {
               _advancedSettings.RefreshSettings();
               LoadSettings();
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
         }
      }

      bool _bEnabled = true;
      TimeSpan _UpdateInterval = new TimeSpan(1, 0, 0);
      TimeSpan _Expiry = new TimeSpan(30, 0, 0, 0);
      int _MaxRetries = 3;

      public void LoadSettings()
      {
         try
         {
            JobsCleanupConfigurationViewProxy proxy = new JobsCleanupConfigurationViewProxy(JobsCleanupSession.ServiceDirectory, JobsCleanupSession.ServiceName);

            _bEnabled = proxy.Enable;
            _UpdateInterval = proxy.GetCheckIntervalTimeSpan();
            _Expiry = proxy.GetExpiryIntervalTimeSpan();
            _MaxRetries = proxy.MaxRetry;
            
            if (proxy.Run>=DateTime.Now-new TimeSpan(0,0,5))
            {
               _FlagRunNow = true;
            }
         }
         catch{
         }
      }

      void Cleanup(bool fDeleteAny)
      {
         #region LOG
         {
            string message = @"Jobs Cleanup - Retry Failed jobs";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         //delete completed successfully
         {
            ListJobsFlags nFlags = ListJobsFlags.None;

            nFlags |= ListJobsFlags.Status;
            nFlags |= ListJobsFlags.CompletedStatus;
            nFlags |= ListJobsFlags.TimeStamp;

            DateTime ExpiryTime = DateTime.Now - _Expiry;
            DownloadJobsDataAccessAgent.DeleteJobs("", (int)JobProxy.Status.completed, (int)JobProxy.CompletedStatus.success, 0, ExpiryTime, nFlags);
         }

         //delete failed
         {
            ListJobsFlags nFlags = ListJobsFlags.None;

            nFlags |= ListJobsFlags.Status;
            nFlags |= ListJobsFlags.CompletedStatus;
            nFlags |= ListJobsFlags.NegateCompletedStatus;
            nFlags |= ListJobsFlags.Retries;
            nFlags |= ListJobsFlags.TimeStamp;

            DateTime ExpiryTime = DateTime.Now - _Expiry;
            DownloadJobsDataAccessAgent.DeleteJobs("", (int)JobProxy.Status.completed, (int)JobProxy.CompletedStatus.success, _MaxRetries + 1, ExpiryTime, nFlags);
         }

         if(fDeleteAny)
         {
            ListJobsFlags nFlags = ListJobsFlags.None;

            nFlags |= ListJobsFlags.Status;
            
            DateTime ExpiryTime = DateTime.Now - _Expiry;
            DownloadJobsDataAccessAgent.DeleteJobs("", (int)JobProxy.Status.completed, 0, 0, ExpiryTime, nFlags);
         }
      }

      bool _FlagRunNow = false;
      void _timer_Elapsed(object sender, ElapsedEventArgs e)
      {
         if (_FlagRunNow ||(DateTime.Now - MileStone > _UpdateInterval))
         {
            try
            {
               _timer.Enabled = false;
               if (_bEnabled||_FlagRunNow)
                  Cleanup(_FlagRunNow);
            }
            catch
            {
            }
            finally
            {
               MileStone = DateTime.Now;
               _timer.Enabled = true;
               _FlagRunNow = false;
            }
         }
      }
   }
}
