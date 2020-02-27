// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using System.Data;
using Leadtools.Medical.DataAccessLayer.Catalog;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Dicom;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Dicom.Scp.Command;
using System.IO;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using System.Diagnostics;
using Leadtools.Dicom.Server.Admin;
#endif // (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.DicomDemos;
using Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer.Configuration;
using System.Reflection;
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
namespace Leadtools.Medical.Storage.AddIns.Messages
{
    public class GetInstanceFileName : IProcessServiceMessage
    {
        private const string GetReferencedFile = "99F19F47-C51B-4961-82EC-FBD7C1091390";

                    #region IProcessServiceMessage Members

        public bool CanProcess(string MessageId)
        {
#if LEADTOOLS_V19_OR_LATER
           return (
                     MessageId == GetReferencedFile || 
                     MessageId == StorageAddinMessage.CanAccessDatabase ||
                     MessageId == MessageNames.CrashDicomServer ||
                     MessageId == MessageNames.GarbageCollectDicomServer
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
                     || 
                     MessageId == MessageNames.IsAddinHealthy
#endif
                   );
#else
           return (MessageId == GetReferencedFile);
#endif // #if LEADTOOLS_V19_OR_LATER
        }

        private static Type MyGetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null)
            {
               return type;
            }

           System.Reflection.Assembly[] myAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in myAssemblies)
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null ;
        }

        public ServiceMessage Process(ServiceMessage Message)
        {
            ServiceMessage message = new ServiceMessage();

            if (Message.Message == GetReferencedFile)
            {
                int retryTimes = 3;
                int retryInterval = 1000;
                string sopInstanceUID = Message.Data[0] as string;
                string referenceFile;

                if(Message.Data.Count > 1)
                {
                    if (!int.TryParse(Message.Data[1].ToString(), out retryTimes))
                        retryTimes = 3;
                }

                if (Message.Data.Count > 2)
                {
                    if (!int.TryParse(Message.Data[2].ToString(), out retryTimes))
                        retryInterval = 1000;
                }
                
                referenceFile = Retry<string>(() =>
                                                       {
                                                           string file = FindReferencedFile(
#if LEADTOOLS_V19_OR_LATER
                                                                     _externalStoreAgent, 
#endif // #if LEADTOOLS_V19_OR_LATER
                                                                     sopInstanceUID);

                                                           if (file.Length == 0)
                                                               throw new ApplicationException("Not Found");
                                                           return file;
                                                       }, retryTimes, retryInterval);

                message.Message = Message.Message;
                message.Data.Add(sopInstanceUID);
                message.Data.Add(referenceFile);
            }
#if LEADTOOLS_V19_OR_LATER
            else if (Message.Message == StorageAddinMessage.CanAccessDatabase)
            {
               message.Message = message.Message;

               string errorString;
               bool result = CanAccessDatabase(out errorString);
               message.Success = result;
               if (result == false)
               {
                  message.Data.Add(errorString);
               }
            }
            else if (Message.Message == MessageNames.GarbageCollectDicomServer)
            {
               message.Success = true;
               GC.Collect();
            }
            else if (Message.Message == MessageNames.CrashDicomServer)
            {
               message.Data.Add(@"Crashing Leadtools.Dicom.Server.exe");
               message.Success = true;


               new Thread(() =>
               {
                  Thread.CurrentThread.IsBackground = true;

                  // The code below calls the internal function DicomDataSet.GenerateException(0) via reflection
                  // ds.GenerateException(0);
                  DicomDataSet ds = new DicomDataSet();
                  Type myType = MyGetType("Leadtools.Dicom.DicomDataSet");
                  if (myType != null)
                  {
                     MethodInfo myMethod = myType.GetMethod("GenerateException", BindingFlags.Instance | BindingFlags.NonPublic);
                     if (myMethod != null)
                     {
                        myMethod.Invoke(ds, new object[] { 0 });
                     }
                  }
               }).Start();
            }
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
            else if (Message.Message == MessageNames.IsAddinHealthy)
            {
               ServiceMessage serviceMessage = new ServiceMessage();
               string error;
               serviceMessage.Message = Message.Message;
               serviceMessage.Success = CanAccessDatabase2(out error);
               serviceMessage.Error = error;
               return serviceMessage;
            }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
#endif // #if LEADTOOLS_V19_OR_LATER
            return message;
        }

        private T Retry<T>(Func<T> method, int numRetries, int milliSecondsToWait)
        {
            T retval = default(T);

            if (method == null)
                throw new ArgumentNullException("method");

            do
            {
                try
                {
                    retval = method();
                    return retval;
                }
                catch (Exception)
                {
                    if (numRetries <= 0) throw;
                    Thread.Sleep(milliSecondsToWait);
                }
            }
            while (numRetries-- > 0);
            return retval;
        }

        #endregion

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
      private string _assemblyName = string.Empty;
      public string AssemblyName
      {
         get
         {
            if (string.IsNullOrEmpty(_assemblyName))
            {
               System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
               if (assembly != null)
               {
                  _assemblyName = assembly.ManifestModule.Name;
               }
            }
            return _assemblyName;
         }
      }

      public static T GetAgent<T>(System.Configuration.Configuration configuration, DataAccessConfigurationView view )
      {
         T agent;

         if (!DataAccessServices.IsDataAccessServiceRegistered<T>())
         {
            agent = DataAccessFactory.GetInstance(view).CreateDataAccessAgent<T>();
            DataAccessServices.RegisterDataAccessService<T>(agent);
         }
         else
         {
            agent = DataAccessServices.GetDataAccessService<T>();
         }
         return agent;
      }

      public bool CanAccessDatabase2(out string error)
      {
         error = string.Empty;
         bool ret = false;
         try
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(AddInsSession.ServiceDirectory);

            IExternalStoreDataAccessAgent externalStoreAgent = GetAgent<IExternalStoreDataAccessAgent>(configuration, new ExternalStoreDataAccessConfigurationView(configuration, null, AddInsSession.DisplayName));
            IStorageDataAccessAgent storageAgent = GetAgent<IStorageDataAccessAgent>(configuration, new StorageDataAccessConfigurationView(configuration, null, AddInsSession.DisplayName));

            bool bContinue = true;
            if (externalStoreAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IExternalStoreDataAccessAgent");
               bContinue = false;
            }

            if (bContinue)
            {
               if (storageAgent == null)
               {
                  error = string.Format("{0} {1}", AssemblyName, "Cannot create IStorageDataAccessAgent");
                  bContinue = false;
               }
            }

            if (bContinue)
            {
               externalStoreAgent.IsExternalStored("notUsed");
               storageAgent.MaxQueryResults = 10;
               storageAgent.IsPatientsExists("patientIdNotUsed");
            }
         }
         catch (Exception e)
         {
            error = string.Format("{0} {1}", AssemblyName, e.Message);
         }

         ret = string.IsNullOrEmpty(error);
         return ret;
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
        IExternalStoreDataAccessAgent _externalStoreAgent = null;
#endif

#if LEADTOOLS_V19_OR_LATER
        private static bool CanAccessDatabase(out string errorString)
        {
           bool result = true;
           errorString = string.Empty;

           IStorageDataAccessAgent agent = null;
           if (DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
           {
              agent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
           }
           if (agent == null)
           {
              errorString = "Error: Cannot create IStorageDataAccessAgent";
              return false;
           }
           agent.MaxQueryResults = 10;
           try
           {
              agent.IsPatientsExists("patientIdNotUsed");
           }
           catch (Exception ex)
           {
              errorString = ex.Message;
              result = false;
           }
           return result;
        }

       internal static string FindReferencedFile(string sopInstanceUID)
       {
          return FindReferencedFile(null, sopInstanceUID);
       }
#endif // #if LEADTOOLS_V19_OR_LATER

       internal static string FindReferencedFile(
#if LEADTOOLS_V19_OR_LATER
       IExternalStoreDataAccessAgent externalStoreAgent, 
#endif // #if LEADTOOLS_V19_OR_LATER
       string sopInstanceUID)
        {
            MatchingParameterCollection mpc = new MatchingParameterCollection();
            MatchingParameterList mpl = new MatchingParameterList();
            DataSet /*CompositeInstanceDataSet*/ instanceData;
            IStorageDataAccessAgent agent = null;
            string referencedFile = string.Empty;

            if (DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
            {
                agent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
            }

            if (agent != null)
            {
                ICatalogEntity instanceEntity = RegisteredEntities.GetInstanceEntity(sopInstanceUID);
                mpl.Add(instanceEntity);
                mpc.Add(mpl);

                instanceData = agent.QueryCompositeInstances(mpc);
                if (instanceData.Tables[DataTableHelper.InstanceTableName].Rows.Count == 1)
                {
                    DataRow row = instanceData.Tables[DataTableHelper.InstanceTableName].Rows[0];
                    referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(row);

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                    if (string.IsNullOrEmpty(referencedFile))
                    {
                        // If empty, it might be on the cloud
                        // Use DicomInstanceRetrieveExternalStoreCommand with cache set to true to copy it locally
                        if (externalStoreAgent == null)
                        {
                            if (DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
                            {
                                externalStoreAgent = DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();
                            }
                        }

                        DicomInstanceRetrieveExternalStoreCommand c = new DicomInstanceRetrieveExternalStoreCommand(agent, externalStoreAgent, AddInsSession.ServiceDirectory, true);
                        DicomDataSet ds = c.GetDicomDataSet(row, out referencedFile);
                    }
#endif // (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                }
            }
            return referencedFile;
        }
    }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
    public class DicomInstanceRetrieveExternalStoreCommand
    {
        public IStorageDataAccessAgent StoreAgent { get; private set; }
        public IExternalStoreDataAccessAgent ExternalStoreAgent { get; private set; }
        public DicomDataSetLoadFlags Flags { get; set; }
        public bool CacheLocal { get; set; }

        private ICrud _defaultCrud = null;
        private ICrud DefaultCrud
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

        private string ServiceDirectory { get; set; }

        public DicomInstanceRetrieveExternalStoreCommand(IStorageDataAccessAgent storeAgent, IExternalStoreDataAccessAgent externalStoreAgent, string serviceDirectory, bool cacheLocal)
        {
            StoreAgent = storeAgent;
            ExternalStoreAgent = externalStoreAgent;
            Flags = DicomDataSetLoadFlags.None;
            ServiceDirectory = serviceDirectory;
            CacheLocal = cacheLocal;
        }

        private static void FillStoreCommandDefaultSettings(CStoreCommandConfiguration c, StorageAddInsConfiguration settings)
        {


            // Set the default store location

            c.DataSetStorageLocation = settings.StoreAddIn.StorageLocation;
#if (LEADTOOLS_V19_OR_LATER)
            c.HangingProtocolLocation = settings.StoreAddIn.HangingProtocolLocation;
#endif
            c.DicomFileExtension = settings.StoreAddIn.StoreFileExtension;

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

        private object _lockObject = new object();

        public virtual DicomDataSet GetDicomDataSet(DataRow instanceData, out string referencedFileLocation)
        {
            lock (_lockObject)
            {
                referencedFileLocation = string.Empty;
                DicomDataSet ds = RegisteredDataRows.InstanceInfo.LoadDicomDataSet(instanceData, Flags);
                if (CacheLocal)
                {
                    bool exists = false;
                    Exception ex = DefaultCrud.ExistsDicom(instanceData, out exists);
                    if (!exists)
                    {
                        StorageModuleConfigurationManager StorageConfigManager = new StorageModuleConfigurationManager(true);
                        StorageConfigManager.Load(ServiceDirectory);
                        StorageAddInsConfiguration storageSettings = StorageConfigManager.GetStorageAddInsSettings();

                        CStoreCommandConfiguration storeConfig = new CStoreCommandConfiguration();
                        storeConfig.DicomFileExtension = storageSettings.StoreAddIn.StoreFileExtension;
                        FillStoreCommandDefaultSettings(storeConfig, storageSettings);

                        string storageLocation = CStoreCommand.GetStorageLocation(storeConfig, ds);
                        string sopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(instanceData, DicomTag.SOPInstanceUID);
                        string dicomInstancePath = Path.Combine(storageLocation, sopInstanceUid + "." + storeConfig.DicomFileExtension);

                        ICrud crud = DefaultInstanceInfo.GetRetrieveCrud(instanceData);
                        if (crud != null)
                        {
                            ex = crud.RetrieveFile(instanceData, dicomInstancePath);
                            if (ex == null)
                            {
                                ExternalStoreAgent.SetReferencedFile(sopInstanceUid, dicomInstancePath);
                                referencedFileLocation = dicomInstancePath;
                            }
                        }
                    }
                }
                return ds;
            }
        }
    }
#endif // LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE
}
