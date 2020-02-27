// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Medical.ExternalStore.Addin.Process;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.Storage.AddIns.Configuration;

namespace Leadtools.Medical.ExternalStore.Addin
{
   public class JobManager
   {
      private ExternalStoreOptions _Options;
      private readonly Scheduler Scheduler = new Scheduler();
      private readonly IExternalStoreDataAccessAgent _externalStoreAgent;
      private readonly IStorageDataAccessAgent _storageAgent;

      private string _externalStoreGuid;

      public string ExternalStoreGuid
      {
         get { return _externalStoreGuid; }
         set 
         { 
            _externalStoreGuid = value;
            _friendlyName = string.Empty;
         }
      }

      private string _friendlyName = string.Empty;
      public string FriendlyName
      {
         get 
         { 
            if (string.IsNullOrEmpty(_friendlyName))
            {
               _friendlyName = _Options.GetFriendlyName(_externalStoreGuid);
            }
            return _friendlyName.Substring(0, 16);
         }
      }

      private string _serviceName = string.Empty;

      public string ServiceName
      {
         get { return _serviceName; }
         set { _serviceName = value; }
      }

      readonly StorageAddInsConfiguration _storageSettings;

      public JobManager(ExternalStoreOptions options, IExternalStoreDataAccessAgent externalStoreAgent, IStorageDataAccessAgent storeAgent, string serviceName, StorageAddInsConfiguration storageSettings)
      {
         _Options = options;
         _externalStoreAgent = externalStoreAgent;
         _storageAgent = storeAgent;
         _serviceName = serviceName;
         _storageSettings = storageSettings;
      }

      private static void FixUpJob(Job job)
      {  
         //
         // If start time is less than the current time we need to make start time at the next interval
         //
         if (job.StartTime < DateTime.Now)
         {
            if (job.Interval.HasValue)
            {
               job.StartTime = DateTime.Now.Add(job.Interval.Value);
            }
         }
      }

      public void Start()
      {
         try
         {
            ExternalStoreItem item = null;
            if (_Options != null)
            {
               item = _Options.GetCurrentOption();
            }
            if (item != null)
            {
               if (item.ExternalStoreJob != null)
               {
                  FixUpJob(item.ExternalStoreJob);
                  Scheduler.SubmitJob(item.ExternalStoreJob, new Action<Job>(ExternalStore));
               }

               if (item.CleanJob != null)
               {
                  FixUpJob(item.CleanJob);
                  Scheduler.SubmitJob(item.CleanJob, new Action<Job>(Clean));
               }
            }
         }
         catch (Exception ex)
         {
            DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: JobManager.Start(): " + ex.Message);
         }
      }

      public void Start(ExternalStoreOptions options)
      {
         try
         {
            ExternalStoreItem item = null;
            if (options != null)
            {
               item = options.GetCurrentOption();
            }

            if (item != null)
            {
               if (item.ExternalStoreJob != null)
               {
                  FixUpJob(item.ExternalStoreJob);
                  Scheduler.SubmitJob(item.ExternalStoreJob, new Action<Job>(ExternalStore));
               }

               if (item.CleanJob != null)
               {
                  FixUpJob(item.CleanJob);
                  Scheduler.SubmitJob(item.CleanJob, new Action<Job>(Clean));
               }
               _Options = options;
            }
         }
         catch (Exception ex)
         { 
            DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: JobManager.Start(ExternalStoreOptions options): " + ex.Message);
         }
      }      

      public void Stop()
      {
         Scheduler.CancelAll();
      }

      private static void MyPauseJob(Job job)
      {
         if (job.Interval != null)
         {
            job.Pause();
         }
      }

      private static void MyResumeJob(Job job)
      {
         if (job.Interval != null)
         {
            job.Resume();
         }
      }

      private void ExternalStore(Job job)
      {  
         MyPauseJob(job);
         try
         {            
            new ExternalStoreProcess(_Options, _externalStoreGuid, _serviceName).Run(_externalStoreAgent, _storageAgent);
         }
         catch(Exception e)
         {
            string message = string.Format("Error processing 'external store' request ('{0}'): {1}", FriendlyName, e.Message);

            Logger.Global.SystemMessage(LogType.Error, message, ServiceName);
         }
         finally
         {
            MyResumeJob(job);
         }
      }

      private void Clean(Job job)
      {
         Clean(job, 0);
      }

      private void Clean(Job job, int expirationDays)
      {         
         MyPauseJob(job);
         try
         {
                     // StorageAddInsConfiguration storageSettings = Module.StorageConfigManager.GetStorageAddInsSettings();

            new CleanProcess(_Options , _externalStoreGuid, _serviceName, _storageSettings).Run(_externalStoreAgent, _storageAgent, expirationDays);
         }
         catch (Exception e)
         {
            string message = string.Format("Error processing 'clear local store' request ('{0}'): {1}", FriendlyName, e.Message);

            Logger.Global.SystemMessage(LogType.Error, message, ServiceName);
         }
         finally
         {
            MyResumeJob(job);
         }
      }            
   }
}
