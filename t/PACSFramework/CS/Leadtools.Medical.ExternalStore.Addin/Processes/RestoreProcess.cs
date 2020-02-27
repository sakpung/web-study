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
using Leadtools.Medical.DataAccessLayer.Catalog;
using System.Data;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom;
using Leadtools.Dicom.Scp.Command;
using System.IO;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.DataTypes;
using System.Threading;

namespace Leadtools.Medical.ExternalStore.Addin
{

   /// <summary>
   /// Manages the restore process.
   /// </summary>
   public class RestoreProcess
   {
      private readonly ExternalStoreOptions _Options;
      private string _friendlyName;
      private readonly string _serviceName;
      private readonly StorageAddInsConfiguration _storageAddinsConfiguration;

      public string FriendlyName
      {
         get
         {
            return _friendlyName.Substring(0, 16);
         }
         set { _friendlyName = value; }
      }
      private static readonly object _restoreLock = new object();
      private static bool   _cancelRestore = false;

      public RestoreProcess(ExternalStoreOptions options, string externalStoreGuid, string serviceName, StorageAddInsConfiguration storageAddinsConfiguration)
      {
         _Options = options;
         FriendlyName = _Options.GetFriendlyName(externalStoreGuid);
         _serviceName = serviceName;
         _storageAddinsConfiguration = storageAddinsConfiguration;
      }

      ICrud _defaultCrud;

      public ICrud DefaultCrud
      {
         get
         {
            if (_defaultCrud == null)
            {
               _defaultCrud = new DefaultCrud();
            }
            return _defaultCrud;
         }
      }

      private static void FillStoreCommandDefaultSettings(CStoreCommandConfiguration c, StorageAddInsConfiguration settings)
      {


         // Set the default store location

         c.DataSetStorageLocation = settings.StoreAddIn.StorageLocation;
         c.DicomFileExtension = settings.StoreAddIn.StoreFileExtension;
#if LEADTOOLS_V19_OR_LATER
         // Set the default Hanging Protocol location
         c.HangingProtocolLocation = settings.StoreAddIn.HangingProtocolLocation;
#endif
         // Set the default Overwrite location
         c.OverwriteBackupLocation = settings.StoreAddIn.OverwriteBackupLocation;

         // Set the default Backup location

         // Set the default CStoreFailures location
         //string storeFailuresLocation = Path.Combine(storeLocation, "StoreFailures");
         //settings.StoreAddIn.CStoreFailuresPath = Path.Combine(storeFailuresLocation, serviceName);

         c.DirectoryStructure.CreatePatientFolder = settings.StoreAddIn.DirectoryStructure.CreatePatientFolder;
         c.DirectoryStructure.CreateSeriesFolder = settings.StoreAddIn.DirectoryStructure.CreateSeriesFolder;
         c.DirectoryStructure.CreateStudyFolder = settings.StoreAddIn.DirectoryStructure.CreateStudyFolder;
         c.DirectoryStructure.UsePatientName = settings.StoreAddIn.DirectoryStructure.UsePatientName;
         c.DirectoryStructure.SplitPatientId = settings.StoreAddIn.DirectoryStructure.SplitPatientId;
         c.SaveThumbnail = settings.StoreAddIn.CreateThumbnailImage;
      }

      public void RunThread(IExternalStoreDataAccessAgent externalStoreAgent, IStorageDataAccessAgent storageAgent, DateRange range)
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "RestoreProcess.Run");

         lock (_restoreLock)
         {
            ExternalStoreInstance[] instances = externalStoreAgent.GetRestoreList(range);
            string message = string.Format("{0} {1} found to restore", instances.Length, "dataset(s)");
            MatchingParameterCollection mpc = new MatchingParameterCollection();

            Logger.Global.SystemMessage(LogType.Information, message, _serviceName);

            CStoreCommandConfiguration storeConfig = new CStoreCommandConfiguration();
            storeConfig.DicomFileExtension = _storageAddinsConfiguration.StoreAddIn.StoreFileExtension;
            FillStoreCommandDefaultSettings(storeConfig, _storageAddinsConfiguration);

            foreach (ExternalStoreInstance instance in instances)
            {
               if (_cancelRestore)
               {
                  _cancelRestore = false;
                  Logger.Global.SystemMessage(LogType.Information, "Cancelling Restore Process", _serviceName);
                  break;
               }

               MatchingParameterList mpl = new MatchingParameterList();

               ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(instance.SOPInstanceUID);
               mpl.Add(instanceEntity);
               mpc.Add(mpl);
               try
               {
                  DataSet ds = storageAgent.QueryCompositeInstances(mpc);

                  DataRow[] rows = ds.Tables[DataTableHelper.InstanceTableName].Select();
                  foreach (DataRow row in rows)
                  {
                     // Get the ICrud that the file was originally stored with
                     ICrud crud = DataAccessServiceLocator.Retrieve<ICrud>(instance.ExternalStoreGuid);
                     if (crud != null)
                     {

                        DicomDataSet dicomDataSet = null;
                        Exception ex = crud.RetrieveDicom(row, DicomDataSetLoadFlags.None, out dicomDataSet);
                        if (ex == null)
                        {
                           string storageLocation = CStoreCommand.GetStorageLocation(storeConfig, dicomDataSet);
                           string dicomInstancePath = Path.Combine(storageLocation,
                                                   instance.SOPInstanceUID) + "." + storeConfig.DicomFileExtension;

                           ex = crud.RetrieveFile(row, dicomInstancePath);
                           if (ex != null)
                           {
                              throw ex;
                           }

                           externalStoreAgent.SetReferencedFile(instance.SOPInstanceUID, dicomInstancePath);
                           Logger.Global.SystemMessage(LogType.Information, string.Format("File Restored: {0} ", dicomInstancePath), _serviceName);
                        }
                     }
                     else
                     {
                        Logger.Global.SystemMessage(LogType.Information, string.Format("Error:  File Not Restored -- Store Token: {0}.  The Addin that for ExternalStoreGuid '{1}' cannot be found.", instance.StoreToken, instance.ExternalStoreGuid), _serviceName);
                     }
                  }

               }
               catch (Exception e)
               {
                  message = string.Format("Error ({0}) restoring instance: {1}", e.Message, instance.SOPInstanceUID);
                  Logger.Global.SystemMessage(LogType.Error, message, _serviceName);
               }
               finally
               {
                  mpc.Clear();
               }
            }
         }
      }

      public void Run(IExternalStoreDataAccessAgent externalStoreAgent, IStorageDataAccessAgent storageAgent, DateRange range)
      {
         Thread thread = new Thread(() => RunThread(externalStoreAgent, storageAgent, range));
         thread.Start();
      }

      public void Cancel()
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "ExternalStoreProcess.Cancel");

         // The idea here is to enable the cancel flag, and disable it after you acuire the restoreLock
         // You can only acquire the restoreLock after the restore process ends
         _cancelRestore = true;
         lock (_restoreLock)
         {
            _cancelRestore = false;
         }
      }
   }
}
