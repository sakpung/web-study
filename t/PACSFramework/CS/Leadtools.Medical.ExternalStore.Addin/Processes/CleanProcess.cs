// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Medical.ExternalStore.DataAccessLayer.DataTypes;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical.Winforms.DatabaseManager;
using Leadtools.Medical.DataAccessLayer.Catalog;
using System.Data;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.ExternalStore.Addin
{

   /// <summary>
   /// Manages the clean process.
   /// </summary>
   public class CleanProcess
   {
      private readonly ExternalStoreOptions _Options;
      private readonly string _serviceName;
      readonly StorageAddInsConfiguration _storageSettings;

      private string _friendlyName;
      public string FriendlyName
      {
         get
         {
            return _friendlyName;
         }
         set { _friendlyName = value; }
      }
      private static readonly object cleanLock = new object();

      public CleanProcess(ExternalStoreOptions options , string externalStoreGuid, string serviceName, StorageAddInsConfiguration storageSettings)
      {
         _Options = options;
          FriendlyName = _Options.GetFriendlyName(externalStoreGuid);
          _serviceName = serviceName;
          _storageSettings = storageSettings;
      }

      public void Run(IExternalStoreDataAccessAgent externalStoreAgent, IStorageDataAccessAgent storageAgent, int expirationDays)
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "CleanProcess.Run");
         lock (cleanLock)
         {
            ExternalStoreInstance[] instances = externalStoreAgent.GetClearList(expirationDays);
            // StorageAddInsConfiguration storageSettings = Module.StorageConfigManager.GetStorageAddInsSettings();

            if (instances.Length > 0)
            {
               string message = string.Format("{0} {1} found to clear", instances.Length, "local dataset(s)");
               Logger.Global.SystemMessage(LogType.Information, message, _serviceName);

               DicomFileDeleter deleter = new DicomFileDeleter();
               MatchingParameterCollection mpc = new MatchingParameterCollection();

               deleter.DicomFileDeleted += new EventHandler<Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs>(deleter_DicomFileDeleted);
               deleter.DicomFileDeleteFailed += new EventHandler<Leadtools.Medical.Winforms.EventBrokerArgs.DicomFileDeletedEventArgs>(deleter_DicomFileDeleteFailed);
               if (_storageSettings != null)
               {
                  deleter.DeleteFilesOnDatabaseDelete = _storageSettings.StoreAddIn.DeleteFiles;
                  deleter.BackupFilesOnDatabaseDelete = _storageSettings.StoreAddIn.BackupFilesOnDelete;
                  deleter.BackupFilesOnDeleteFolder = _storageSettings.StoreAddIn.DeleteBackupLocation;

                  deleter.DeleteAnnotationsOnImageDelete = false;
                  deleter.DeleteReferencedImagesOnImageDelete = false;
               }

               foreach (ExternalStoreInstance instance in instances)
               {
                  MatchingParameterList mpl = new MatchingParameterList();

                  ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(instance.SOPInstanceUID);
                  mpl.Add(instanceEntity);
                  mpc.Add(mpl);
                  try
                  {
                     DataSet ds = storageAgent.QueryCompositeInstances(mpc);

                     //
                     // Find the instance to delete
                     ////
                     deleter.Delete(null, ds.Tables[DataTableHelper.InstanceTableName].Select());

                     externalStoreAgent.SetReferencedFile(instance.SOPInstanceUID, string.Empty);
                  }
                  catch (Exception e)
                  {
                     message = string.Format("Error ({0}) deleting instance: {1}", e.Message, instance.SOPInstanceUID);
                     Logger.Global.SystemMessage(LogType.Error, message, _serviceName);
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
      }

      void deleter_DicomFileDeleteFailed(object sender, Winforms.EventBrokerArgs.DicomFileDeletedEventArgs e)
      {         
         Logger.Global.SystemMessage(LogType.Error, string.Format("Failed to delete file: '{0}' ", e.FilePath), _serviceName);
      }

      void deleter_DicomFileDeleted(object sender, Winforms.EventBrokerArgs.DicomFileDeletedEventArgs e)
      {
         Logger.Global.SystemMessage(LogType.Information, string.Format("File Deleted: '{0}' ", e.FilePath), _serviceName);
      }
   }
}
