// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.Forward.DataAccessLayer.DataTypes;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical.Winforms.DatabaseManager;
using System.Diagnostics;
using Leadtools.Medical.DataAccessLayer.Catalog;
using System.Data;
using System.Threading;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Forwarder.AddIn.Processes
{
   /// <summary>
   /// Manages the clean process.
   /// </summary>
   public class CleanProcess
   {
      private ForwardOptions _Options;
      private string _ServerAE;
      private static object cleanLock = new object();
      private static bool _cancelClean = false;

      public CleanProcess(ForwardOptions options, string ae)
      {         
         _Options = options;
         _ServerAE = ae;
      }

      public void Run(IForwardDataAccessAgent forwardAgent, IStorageDataAccessAgent storageAgent)
      {
         Thread thread = new Thread(() => RunThread(forwardAgent, storageAgent));
         thread.Start();
      }

      public void RunThread(IForwardDataAccessAgent forwardAgent, IStorageDataAccessAgent storageAgent)
      {
         lock (cleanLock)
         {
            ForwardInstance[] instances = forwardAgent.GetCleanList();
            StorageAddInsConfiguration storageSettings = Module.StorageConfigManager.GetStorageAddInsSettings();
            string message = string.Format("[Forwarder] {0} {1} found to clean", instances.Length, instances.Length == 1 ? "dataset" : "datasets");
            DicomFileDeleter deleter = new DicomFileDeleter();
            MatchingParameterCollection mpc = new MatchingParameterCollection();

            deleter.DicomFileDeleted += new EventHandler<Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs>(deleter_DicomFileDeleted);
            deleter.DicomFileDeleteFailed += new EventHandler<Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs>(deleter_DicomFileDeleteFailed);
            if (storageSettings != null)
            {
               deleter.DeleteFilesOnDatabaseDelete = storageSettings.StoreAddIn.DeleteFiles;
               deleter.BackupFilesOnDatabaseDelete = storageSettings.StoreAddIn.BackupFilesOnDelete;
               deleter.BackupFilesOnDeleteFolder = storageSettings.StoreAddIn.DeleteBackupLocation;
            }

            Logger.Global.SystemMessage(LogType.Debug, message, _ServerAE);
            foreach (ForwardInstance instance in instances)
            {
#if LEADTOOLS_V18_OR_LATER
               if (_cancelClean)
               {
                  _cancelClean = false;
                  Logger.Global.SystemMessage(LogType.Information, string.Format("Cancelling Clean Process"), _ServerAE);
                  break;
               }
#endif // #if LEADTOOLS_V18_OR_LATER
               MatchingParameterList mpl = new MatchingParameterList();

               ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(instance.SOPInstanceUID);
               mpl.Add(instanceEntity);
               mpc.Add(mpl);
               try
               {
                  DataSet ds = storageAgent.QueryCompositeInstances(mpc);

                  //
                  // Find the instance to delete
                  //
                  storageAgent.DeleteInstance(GetMatchingParameters(instance.SOPInstanceUID));
                  if (ds != null)
                  {                     
                     deleter.Delete(null, ds.Tables[DataTableHelper.InstanceTableName].Select());
                  }
               }
               catch (Exception e)
               {
                  message = string.Format("[Forwarder] Error ({0}) deleting instance: {1}", e.Message, instance.SOPInstanceUID);
                  Logger.Global.SystemMessage(LogType.Error, message, _ServerAE);
               }
               finally
               {
                  mpc.Clear();
               }
            }
            deleter.DicomFileDeleted -= deleter_DicomFileDeleted;
            deleter.DicomFileDeleteFailed -= deleter_DicomFileDeleteFailed;
         }
      }

      void deleter_DicomFileDeleteFailed(object sender, Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs e)
      {         
         Logger.Global.SystemMessage(LogType.Error, string.Format("[Forwarder] Failed to delete file: {0}: {0} ", e.FilePath), _ServerAE);
      }

      void deleter_DicomFileDeleted(object sender, Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs e)
      {
         Logger.Global.SystemMessage(LogType.Audit, string.Format("[Forwarder] File Deleted: {0} ", e.FilePath), _ServerAE);
      }

      private MatchingParameterCollection GetMatchingParameters(string sopInstanceUID)
      {
         MatchingParameterCollection matchingParamCollection = new MatchingParameterCollection();
         MatchingParameterList matchingParamList = new MatchingParameterList();
         // Instance instance = new Instance(sopInstanceUID);
         ICatalogEntity instance = RegisteredEntities.GetInstanceEntity(sopInstanceUID);

         matchingParamList.Add(instance);
         matchingParamCollection.Add(matchingParamList);
         return matchingParamCollection;
      }

#if LEADTOOLS_V18_OR_LATER
      public void Cancel()
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "CleanProcess.Cancel");

         // The idea here is to enable the cancel flag, and disable it after you acquire the restoreLock
         // You can only acquire the cleanLock after the clean process ends
         _cancelClean = true;
         lock (cleanLock)
         {
            _cancelClean = false;
         }
      }
#endif // #if LEADTOOLS_V18_OR_LATER
   }
}
