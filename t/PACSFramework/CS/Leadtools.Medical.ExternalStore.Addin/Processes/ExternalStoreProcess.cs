// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Medical.ExternalStore.DataAccessLayer.DataTypes;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Medical.Winforms.ExternalStore;
using System.IO;
using Leadtools.Medical.Winforms.Forwarder.Controls;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom.Common.Extensions;
using System.Threading;
using Leadtools.Medical.DataAccessLayer;

namespace Leadtools.Medical.ExternalStore.Addin.Process
{
   public class ExternalStoreProcess
   {      
      private readonly ExternalStoreOptions _Options;

      private readonly string _externalStoreGuid;

      private readonly string _serviceName;

      public string FriendlyName { get; set; }

      private static readonly object _externalStoreLock = new object();
      private static bool _cancelExternalStore = false;

      public ExternalStoreProcess(ExternalStoreOptions options, string externalStoreGuid, string serviceName)
      {         
         _Options = options;
         _externalStoreGuid = externalStoreGuid;
         FriendlyName = _Options.GetFriendlyName(externalStoreGuid);
         _serviceName = serviceName;
      }

      public void RunThread(IExternalStoreDataAccessAgent externalStoreAgent, IStorageDataAccessAgent storageAgent)
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "ExternalStoreProcess.Run");
         string message;
         ICrud crud = _Options.GetCrud(_externalStoreGuid);
         if (crud == null)
         {
              message = string.Format("ExternalStore ICrud interface not found:ExternalStoreGuid[{0}], FriendlyName[{1}]", _externalStoreGuid, FriendlyName);
              Logger.Global.SystemMessage(LogType.Error, message, _serviceName);
              return;
         }

         if (!DataAccessServiceLocator.IsRegistered(_externalStoreGuid))
         {
            DataAccessServiceLocator.Register(crud, _externalStoreGuid);
         }

         lock (_externalStoreLock)
         {
            ExternalStoreInstance[] instances = externalStoreAgent.GetExternalStoreList();

           if (instances.Length > 0)
           {
              message = string.Format("{0} {1} found to send to external store", instances.Length, "dataset(s)");
              Logger.Global.SystemMessage(LogType.Information, message, _serviceName);
           }

            ExternalStoreItem item = _Options.GetExternalStoreItem(_externalStoreGuid);
            if (item == null)
            {
               return;
            }

            if (instances.Length > 0 && item.Verify)
            {
               message = string.Format("{0} {1} will be verified after sending to external store", instances.Length, instances.Length == 1 ? "instance" : "instances");
               Logger.Global.SystemMessage(LogType.Information, message, _serviceName);
            }

            foreach (ExternalStoreInstance instance in instances)
            {
               if (_cancelExternalStore)
               {
                  _cancelExternalStore = false;
                  Logger.Global.SystemMessage(LogType.Information, string.Format("Cancelling External Store Process", instance.ReferencedFile), _serviceName);
                  break;
               }

               try
               {
                  if (!File.Exists(instance.ReferencedFile))
                  {
                     message = string.Format("Referenced file doesn't exist.  Instance ({0}) will be removed from external store queue. [{1}]", instance.SOPInstanceUID, instance.ReferencedFile);
                     Logger.Global.SystemMessage(LogType.Warning, message, _serviceName);

                     // TODO: fix this up -- assign a valid token
                     externalStoreAgent.SetInstanceExternalStored(instance.SOPInstanceUID, string.Empty, string.Empty, DateTime.Now, null);
                     continue;
                  }

                  string storeToken;
                  string externalStoreGuid;
                  if (ExternalStoreInstance(crud, instance, out storeToken, out externalStoreGuid) )
                  {
                     DateTime? expires = null;
                     DateTime externalStoreDate = DateTime.Now;

                     if (item.ImageHold != null && item.ImageHold != 0)
                     {
                        switch (item.HoldInterval)
                        {
                           case HoldInterval.Days:
                              expires = externalStoreDate.AddDays(item.ImageHold.Value);
                              break;
                           case HoldInterval.Months:
                              expires = externalStoreDate.AddMonths(item.ImageHold.Value);
                              break;
                           default:
                              expires = externalStoreDate.AddYears(item.ImageHold.Value);
                              break;
                        }
                     }
                     if (!item.Verify || VerifyInstance(crud, storeToken))
                     {
                        if (item.Verify)
                        {
                           message = string.Format("SOP instance successfully verified: {0}", instance.SOPInstanceUID);
                           Logger.Global.SystemMessage(LogType.Information, message, _serviceName);
                        }

                        externalStoreAgent.SetInstanceExternalStored(instance.SOPInstanceUID, externalStoreGuid, storeToken, externalStoreDate, expires);
                        externalStoreAgent.SetToken(instance.SOPInstanceUID, storeToken);
                        externalStoreAgent.SetExternalStoreGuid(instance.SOPInstanceUID, externalStoreGuid);
                     }
                     else
                     {
                        message = string.Format("Failed to verify SOP instance: {0}. Instance not marked as externally stored.", instance.SOPInstanceUID);
                        Logger.Global.SystemMessage(LogType.Error, message, _serviceName);
                     }
                  }
               }
               catch (Exception e)
               {
                  Logger.Global.SystemMessage(LogType.Error, string.Format("{0}", e.Message), _serviceName);
               }
            }
         }
      }

      public void Run(IExternalStoreDataAccessAgent externalStoreAgent, IStorageDataAccessAgent storageAgent)
      {
         Thread thread = new Thread(() => RunThread(externalStoreAgent, storageAgent));
         thread.Start();
      }


      public void Cancel()
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "ExternalStoreProcess.Cancel");

         // The idea here is to enable the cancel flag, and disable it after you acquire the restoreLock
         // You can only acquire the restoreLock after the restore process ends
         _cancelExternalStore = true;
         lock (_externalStoreLock)
         {
            _cancelExternalStore = false;
         }
      }

      private bool ExternalStoreInstance(ICrud crud, ExternalStoreInstance instance, out string token, out string externalStoreGuid)
      {
         externalStoreGuid = string.Empty;
         Exception ex = crud.Store(instance.ReferencedFile, true, out token);
         string message = null;
         if (ex != null)
         {
            message = string.Format("Error: {0}.", ex.Message);
            Logger.Global.SystemMessage(LogType.Error, message, _serviceName);
            return false;
         }

         message = string.Format("File sent to external store ({0}): {1}.", crud.FriendlyName, instance.ReferencedFile);
         Logger.Global.SystemMessage(LogType.Information, message, _serviceName);


         externalStoreGuid = crud.ExternalStoreGuid;
         return true;
      }

      private static bool VerifyInstance(ICrud crud, string token)
      {
         bool exists = false;
         if (crud != null)
         {
            crud.Exists(token, out exists);
         }
         return exists;
      }
   }
}
