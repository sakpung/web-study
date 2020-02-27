// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using Leadtools.Dicom.AddIn.Interfaces;
using System.IO;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer;
using System.Data;
using Leadtools.Logging;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.ExternalStore.Addin;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;


namespace Leadtools.Medical.ExternalStore.Azure.Addin
{
[Serializable]
   public class AzureCrud : ICrud
   {
      public AzureCrud()
      {
         _azureCloudBlobContainer = null;
         _defaultCrud = null;
      }

   private AzureConfiguration _azureConfiguration;

      public AzureConfiguration Configuration
      {
         get
         {
            if (_azureConfiguration != null)
               return _azureConfiguration;

            if (Module.Options == null)
               return null;

            ExternalStoreItem item = Module.Options.GetCurrentOption();
            if (item == null)
               return null;

            _azureConfiguration = item.ExternalStoreAddinConfig.ConfigurationObject as AzureConfiguration;
            return _azureConfiguration;
         }

         set
         {
            _azureConfiguration = value;
         }
      }

      private void VerifyConfiguration()
      {
         if (Configuration == null)
         {
            throw new Exception("Error: Azure ExternalStoreAddin not configured.");
         }
      }

      private DefaultCrud _defaultCrud;
      internal DefaultCrud DefaultCrud
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

      CloudBlobContainer _azureCloudBlobContainer;
      public CloudBlobContainer AzureCloudBlobContainer
      {
         get
         {
            if (_azureCloudBlobContainer == null)
            {
               StorageCredentials storageCredentials = new StorageCredentials(_azureConfiguration.StorageAccountName, _azureConfiguration.StorageAccountKey);
               CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(storageCredentials, _azureConfiguration.UseHttps);

               CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
               _azureCloudBlobContainer = cloudBlobClient.GetContainerReference(_azureConfiguration.ContainerName);

               // Set public access level to the container.
               _azureCloudBlobContainer.SetPermissions(new BlobContainerPermissions()
               {
                  PublicAccess = BlobContainerPublicAccessType.Container
               });
            }
            return _azureCloudBlobContainer;
         }
      }

      #region Private Members
            private readonly char[] _pathSeparators = new char[] {
               Path.DirectorySeparatorChar,  
               Path.AltDirectorySeparatorChar  
               };

      private  CloudBlockBlob StoretokenToBlob(string s)
      {
         string[] list = s.Split(_pathSeparators, StringSplitOptions.RemoveEmptyEntries);

         if (list.Length < 4)
            return null;

         string http = list[0].ToLower();
         if (!http.Contains("http"))
            return null;

         string url = list[1].ToLower();
         if (!url.Contains("blob.core.windows.net"))
            return null;

         // list[2] is the container name
         // list[3] contains the directory names
         // list[length - 1] contains the blob name

         int len = list.Length;
         CloudBlobDirectory blobdir = AzureCloudBlobContainer.GetDirectoryReference(list[3]);
         for (int i = 4; i < len - 1; i++)
         {
            blobdir = blobdir.GetDirectoryReference(list[i]);
         }

         CloudBlockBlob cloudBlockBlob = blobdir.GetBlockBlobReference(list[len - 1]);

         return cloudBlockBlob;
      }

      private Exception Retrieve(string token, out byte[] data)
      {
         Exception ret = null;
         VerifyConfiguration();

         data = null;

         if (token == null)
         {
            return new ArgumentException("Referenced file is null");
         }

         if (string.IsNullOrEmpty(token))
         {
            return new FileNotFoundException();
         }

         try
         {
            token = token.Trim();
            CloudBlockBlob cloudBlockBlob = StoretokenToBlob(token);

            MemoryStream target = new MemoryStream();
            cloudBlockBlob.DownloadToStream(target);

            target.Seek(0, SeekOrigin.Begin);
            data = new byte[target.Length];
            target.Read(data, 0, (int)target.Length);
         }
         catch (Exception ex)
         {
            ret = ex;
         }

         return ret;
      }

      private Exception RetrieveFile(string token, string outFile)
      {
         byte[] outArray;

         Exception ret = Retrieve(token, out outArray);
         if (ret != null)
         {
            return ret;
         }

         if (outArray == null || outArray.Length == 0)
         {
            return new FileNotFoundException( string.Format("Unable to locate file with token: '{0}'", token));
         }

         File.WriteAllBytes(outFile, outArray);
         return null;
      }

      private string ModifyFilename(string filename)
      {
         filename = filename.Replace('\\', '/');
         filename = filename.Replace(' ', '_');
        
         string[] list = filename.Split(_pathSeparators, StringSplitOptions.RemoveEmptyEntries);
         if (list.Length == 0)
         {
            string msg = string.Format("AzureCrud.Store: Invalid filename '{0}'", filename);
            throw new Exception(msg);
         }

         if (list[0].Contains(':'))
         {
            list[0] = string.Empty;
         }

         filename = string.Empty;
         for(int i=1; i<list.Length-1; i++)
         {
            filename += list[i] + '/';
         }
         filename = filename + list[list.Length-1];

         return filename;
      }

      private Exception Store(byte[] data, string filename, bool overwrite, out string token)
      {
         Exception ret = null;
         token = string.Empty;
         VerifyConfiguration();

         try
         {
            string blobName = ModifyFilename(filename);
            CloudBlockBlob cloudBlockBlob = AzureCloudBlobContainer.GetBlockBlobReference(blobName);
            cloudBlockBlob.UploadFromByteArray(data, 0, data.Length);
            token = cloudBlockBlob.StorageUri.PrimaryUri.AbsoluteUri;
         }
         catch (Exception ex)
         {
            if ((string.Compare("The resource you are trying to create already exists.", ex.Message, true) == 0) && (overwrite))
            {
               return ret;
            }
            ret = ex;
         }
         return ret;
      }

      private Exception Update(string token, byte[] data)
      {
         Exception ret = null;
         VerifyConfiguration();

         try
         {
            token = token.Trim();
            CloudBlockBlob cloudBlockBlob = StoretokenToBlob(token);
            cloudBlockBlob.UploadFromByteArray(data, 0, data.Length);
         }
         catch (Exception ex)
         {
            if (string.Compare("The resource you are trying to create already exists.", ex.Message, true) == 0)
            {
               return ret;
            }
            ret = ex;
         }
         return ret;
      }

      #endregion

      #region ICrud Members

      public void Initialize()
      {
      }

      public void SettingsChanged()
      {
        Module.ExternalStoreSettingsChanged();
      }

      public Exception Delete(string token)
      {
         string message;

         Exception ret = null;
         VerifyConfiguration();

         if (string.IsNullOrEmpty(token))
         {
            return null;
         }

         try
         {
            CloudBlockBlob cloudBlockBlob = StoretokenToBlob(token);
            if (cloudBlockBlob != null)
            {
               cloudBlockBlob.Delete();

            }
         }
         catch (Exception ex)
         {
            ret = ex;
         }

         if (ret == null)
         {
            message = string.Format("'{0}' external store addin DeleteDicom success, store token '{1}'.", Module.AzureFriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin DeleteDicom failure, store token '{1}, {2}'.", Module.AzureFriendlyName, token, ret.Message);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);
         }

         return ret;
      }

      public Exception DeleteDicom(DataRow row)
      {

         VerifyConfiguration();

         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);

         return Delete(token);
      }

      public Exception RetrieveFile(DataRow row, string outFile)
      {
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         return RetrieveFile(token, outFile);
      }

      public Exception RetrieveDicom(DataRow row, DicomDataSetLoadFlags loadFlags, out DicomDataSet dataset)
      {
         dataset = null;

         // Try the external store
         byte[] data;

         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         string message;

         Exception ret = Retrieve(token, out data);
         if (ret != null)
         {
            message = string.Format("'{0}' external store addin RetrieveDicom failure, store token '{1}'.  {2}", Module.AzureFriendlyName, token, ret.Message);
            Exception newException = (Exception)Activator.CreateInstance(ret.GetType(), message, ret);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);

            return newException;
         }
         
         message = string.Format("'{0}' external store addin RetrieveDicom success, store token '{1}'.", Module.AzureFriendlyName, token);
         Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);

         dataset = new DicomDataSet();
         MemoryStream stream = new MemoryStream(data);
         dataset.Load(stream, loadFlags);


         return null;
      }

      public Exception Store(string filename, bool overwrite, out string token)
      {
         Exception ret = null;
         token = string.Empty;
         VerifyConfiguration();

         try
         {
            string blobName = ModifyFilename(filename);
            CloudBlockBlob cloudBlockBlob = AzureCloudBlobContainer.GetBlockBlobReference(blobName);
#if LEADTOOLS_V20_OR_LATER
            cloudBlockBlob.UploadFromFile(filename);
#else
            cloudBlockBlob.UploadFromFile(filename, FileMode.Open);
#endif
            token = cloudBlockBlob.StorageUri.PrimaryUri.AbsoluteUri;
         }
         catch (Exception ex)
         {
            if ((string.Compare("The resource you are trying to create already exists.", ex.Message, true) == 0) && (overwrite))
            {
               return ret;
            }
            ret = ex;
         }
         return ret;
      }

      public Exception StoreDicom(string filename, DicomDataSet dataset, DicomDataSetSaveFlags saveFlags, bool overwrite, out string token)
      {
         string message;

         Byte[] ba = dataset.ToByteArray(saveFlags);
         Exception ret = Store(ba, filename, overwrite, out token);
         if (ret == null)
         {
            message = string.Format("'{0}' external store addin StoreDicom success, returned store token '{1}'.", Module.AzureFriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin StoreDicom failure, '{1}'.", Module.AzureFriendlyName, ret.Message);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);
         }
         return ret;
      }

      public Exception Exists(string token, out bool exists)
      {
         Exception ret = null;
         exists = false;
         VerifyConfiguration();

         try
         {
            CloudBlockBlob cloudBlockBlob = StoretokenToBlob(token);
            exists = cloudBlockBlob.Exists();

         }
         catch (Exception ex)
         {
            if (string.Compare(ex.Message, "The requested object was not found", true) != 0)
            {
               ret = ex;
            }
         }
         return ret;
      }

      public Exception ExistsDicom(DataRow row, out bool exists)
      {
         VerifyConfiguration();

         // Try the external store
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         return Exists(token, out exists);
      }

      public bool StoreLocal
      {
         get
         {
            return _azureConfiguration.StoreLocally;
         }
      }

      public string ExternalStoreGuid
      {
         get
         {
            return Module.AzureGuid;
         }
      }

      public string FriendlyName
      {
         get { return Module.AzureFriendlyName;}
      }

      // Patient Updater calls 'UpdateDicom'
      public Exception UpdateDicom(DataRow row, DicomDataSet dataset, DicomDataSetSaveFlags saveFlags)
      {
         string message;
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         Byte[] ba = dataset.ToByteArray(saveFlags);
         Exception ret = Update(token, ba);
         if (ret == null)
         {
            message = string.Format("'{0}' external store addin UpdateDicom success, returned store token '{1}'.", Module.AzureFriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin UpdateDicom failure, '{1}'.", Module.AzureFriendlyName, ret.Message);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);
         }

         return ret;
      }

#endregion
   }
}
