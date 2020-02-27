// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom;
using System.IO;
using System.Data;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Medical.Logging;
using System.Diagnostics;
#endif

namespace Leadtools.Medical.Winforms.Common
{
   public class DicomInstanceRetrieveCommand
   {
      public IStorageDataAccessAgent DataAccess { get ; private set ; }
      public DicomDataSetLoadFlags Flags { get ; set ; }
      
      public DicomInstanceRetrieveCommand ( IStorageDataAccessAgent dataAccess ) 
      {
         DataAccess = dataAccess ;
         Flags = DicomDataSetLoadFlags.None ;
      }
      
      
      public virtual DicomDataSet GetDicomDataSet ( DataRow  instanceData )
      {
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         return RegisteredDataRows.InstanceInfo.LoadDicomDataSet(instanceData, Flags);
#else
         string referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(instanceData);
         
         if ( referencedFile == null )
         {
            throw new ArgumentException ( "Referenced file is null" ) ;
         }
         
         if (string.IsNullOrEmpty(referencedFile))
         {
            throw new FileNotFoundException();
         }
         
         if (!File.Exists(referencedFile))
         {
            throw new FileNotFoundException(string.Format("Unable to find the specified file: '{0}'", referencedFile));
         }

         DicomDataSet dataSet = new DicomDataSet();
         dataSet.Load(referencedFile, Flags);
         
         return dataSet;
#endif
      }
   }


//#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
//   public class DicomInstanceRetrieveExternalStoreCommand
//   {
//      public IStorageDataAccessAgent StoreAgent { get; private set; }
//      public IExternalStoreDataAccessAgent ExternalStoreAgent { get; private set; }
//      public DicomDataSetLoadFlags Flags { get; set; }
//      public bool CacheLocal { get; set; }

//      private ICrud _defaultCrud = null;
//      private ICrud DefaultCrud
//      {
//         get
//         {
//            if (_defaultCrud == null)
//            {
//               _defaultCrud = new DefaultCrud();
//            }
//            return _defaultCrud;
//         }
//      }

//      private string ServiceDirectory { get; set; }

//      public DicomInstanceRetrieveExternalStoreCommand(IStorageDataAccessAgent storeAgent, IExternalStoreDataAccessAgent externalStoreAgent, string serviceDirectory, bool cacheLocal)
//      {
//         StoreAgent = storeAgent;
//         ExternalStoreAgent = externalStoreAgent;
//         Flags = DicomDataSetLoadFlags.None;
//         ServiceDirectory = serviceDirectory;
//         CacheLocal = cacheLocal;
//      }

//      private static void FillStoreCommandDefaultSettings(CStoreCommandConfiguration c, StorageAddInsConfiguration settings)
//      {


//         // Set the default store location

//         c.DataSetStorageLocation = settings.StoreAddIn.StorageLocation;
//         c.DicomFileExtension = settings.StoreAddIn.StoreFileExtension;

//         // Set the default Overwrite location
//         c.OverwriteBackupLocation = settings.StoreAddIn.OverwriteBackupLocation;

//         // Set the default Backup location

//         // Set the default CStoreFailures location
//         //string storeFailuresLocation = Path.Combine(storeLocation, "StoreFailures");
//         //settings.StoreAddIn.CStoreFailuresPath = Path.Combine(storeFailuresLocation, serviceName);

//         c.DirectoryStructure.CreatePatientFolder = settings.StoreAddIn.DirectoryStructure.CreatePatientFolder;
//         c.DirectoryStructure.CreateSeriesFolder = settings.StoreAddIn.DirectoryStructure.CreateSeriesFolder;
//         c.DirectoryStructure.CreateStudyFolder = settings.StoreAddIn.DirectoryStructure.CreateStudyFolder;
//         c.DirectoryStructure.UsePatientName = settings.StoreAddIn.DirectoryStructure.UsePatientName;
//         c.DirectoryStructure.SplitPatientId = settings.StoreAddIn.DirectoryStructure.SplitPatientId;
//         c.SaveThumbnail = settings.StoreAddIn.CreateThumbnailImage;
//      }

//      private object _lockObject = new object();

//      public virtual DicomDataSet GetDicomDataSet(DataRow instanceData, out string referencedFileLocation)
//      {
//         lock (_lockObject)
//         {
//            referencedFileLocation = string.Empty;
//            DicomDataSet ds = RegisteredDataRows.InstanceInfo.LoadDicomDataSet(instanceData, Flags);
//            if (CacheLocal )
//            {
//               bool exists = false;
//               Exception ex = DefaultCrud.ExistsDicom(instanceData, out exists);
//               if (!exists)
//               {
//                  StorageModuleConfigurationManager StorageConfigManager = new StorageModuleConfigurationManager(true);
//                  StorageConfigManager.Load(ServiceDirectory);
//                  StorageAddInsConfiguration storageSettings = StorageConfigManager.GetStorageAddInsSettings();

//                  CStoreCommandConfiguration storeConfig = new CStoreCommandConfiguration();
//                  storeConfig.DicomFileExtension = storageSettings.StoreAddIn.StoreFileExtension;
//                  FillStoreCommandDefaultSettings(storeConfig, storageSettings);

//                  string storageLocation = CStoreCommand.GetStorageLocation(storeConfig, ds);
//                  string sopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(instanceData, DicomTag.SOPInstanceUID);
//                  string dicomInstancePath = Path.Combine(storageLocation, sopInstanceUid + "." + storeConfig.DicomFileExtension);

//                  ICrud crud = DefaultInstanceInfo.GetRetrieveCrud(instanceData);
//                  if (crud != null)
//                  {
//                     ex = crud.RetrieveFile(instanceData, dicomInstancePath);
//                     if (ex == null)
//                     {
//                        ExternalStoreAgent.SetReferencedFile(sopInstanceUid, dicomInstancePath);
//                        referencedFileLocation = dicomInstancePath;
//                     }
//                  }
//               }
//            }
//            return ds;
//         }
//      }
//   }
//#endif // LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE
}
