// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn.Interfaces;
using System.IO;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer;
using EsuApiLib;
using EsuApiLib.Rest;
using System.Data;
using Leadtools.Logging;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.ExternalStore.Addin;
using Amazon.S3;
using Amazon.S3.Model;

namespace Leadtools.Medical.ExternalStore.AmazonS3.Addin
{
[Serializable]
   public class AmazonS3Crud : ICrud
   {
      public AmazonS3Crud()
      {
         _amazonClient = null;
         _defaultCrud = null;
#if DEBUG
         Console.WriteLine("");
#endif
      }

   private AmazonS3Configuration _amazonS3Configuration;

      public AmazonS3Configuration Configuration
      {
         get
         {
            if (_amazonS3Configuration != null)
               return _amazonS3Configuration;

            if (Module.Options == null)
               return null;

            ExternalStoreItem item = Module.Options.GetCurrentOption();
            if (item == null)
               return null;

            _amazonS3Configuration = item.ExternalStoreAddinConfig.ConfigurationObject as AmazonS3Configuration;
            return _amazonS3Configuration;
         }

         set
         {
            _amazonS3Configuration = value;
         }
      }

      private void VerifyConfiguration()
      {
         if (Configuration == null)
         {
            throw new Exception("Error: AmazonS3 ExternalStoreAddin not configured.");
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

      IAmazonS3 _amazonClient;

      public IAmazonS3 AmazonClient
      {
         get 
         { 
            if (_amazonClient == null)
            {
               _amazonClient = new AmazonS3Client(
                _amazonS3Configuration.AccessKeyId,
                _amazonS3Configuration.SecretAccessKey,
                _amazonS3Configuration.Region.ToRegionEndpoint()
                );
            }
            return _amazonClient; 
         }
      }

      private Exception Retrieve(string token, out byte[] data)
      {
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

         Exception ret = null;
         try
         {
            GetObjectRequest request = new GetObjectRequest()
            {
               BucketName = Configuration.BucketName,
               Key = token
            };
            using (GetObjectResponse response = AmazonClient.GetObject(request))
            {
               using (var memoryStream = new MemoryStream())
               {
                  response.ResponseStream.CopyTo(memoryStream);
                  data = memoryStream.ToArray();
               }
            }
         }
         catch (Exception ex)
         {
            ret = ex;
         }

         return ret;
      }

      private Exception RetrieveFile(string token, string outFile)
      {
         VerifyConfiguration();

         if (token == null)
         {
            return new ArgumentException("Referenced file is null");
         }

         if (string.IsNullOrEmpty(token))
         {
            return new FileNotFoundException();
         }

         Exception ret = null;
         try
         {
            GetObjectRequest request = new GetObjectRequest()
            {
               BucketName = Configuration.BucketName,
               Key = token
            };
            using (GetObjectResponse response = AmazonClient.GetObject(request))
            {
               // if (!File.Exists(outFile))
               {
                  response.WriteResponseStreamToFile(outFile);
               }
            }
         }
         catch (Exception ex)
         {
            ret = ex;
         }

         return ret;
      }

      private Exception Store(byte[] data, string filename, bool overwrite, out string token)
      {
         return Store(data, filename, overwrite, out token, false);
      }

      private Exception Store(byte[] data, string filename, bool overwrite, out string token, bool fileNameIsToken)
      {
         Exception ret = null;
         token = string.Empty;
         VerifyConfiguration();

         try
         {
            string key = string.Empty;
            if (fileNameIsToken)
            {
               key = filename;
            }
            else
            {
               key = filename.FileNameToToken();
            }
            using (Stream dataStream = new MemoryStream(data))
            {
               PutObjectRequest request = new PutObjectRequest()
               {
                  BucketName = Configuration.BucketName,
                  Key = key,
                  InputStream = dataStream
               };

               PutObjectResponse response = AmazonClient.PutObject(request);
               token = key;
            }
         }
         catch (Exception ex)
         {
            //if ((string.Compare("The resource you are trying to create already exists.", ex.Message, true) == 0) && (overwrite))
            //{
            //   ret = Update(path, data, out token);
            //   return ret;
            //}
            ret = ex;
         }
           
         return ret;
      }

      private Exception Update(string token, byte[] data)
      {
         string notUsed = string.Empty;
         Exception ret = Store(data, token, true, out notUsed, true);
         return ret;
      }

      #region ICrud Members

      public void Initialize()
      {
         _amazonClient = null;
      }

      public void SettingsChanged()
      {
        Module.ExternalStoreSettingsChanged();
      }

      public Exception Delete(string token)
      {
         Exception ret = null;
         VerifyConfiguration();

         try
         {
            DeleteObjectRequest request = new DeleteObjectRequest()
            {
               BucketName = Configuration.BucketName,
               Key = token
            };

            AmazonClient.DeleteObject(request);
         }
         catch (Exception ex)
         {
            ret = ex;
         }

         return ret;
      }

      public Exception DeleteDicom(DataRow row)
      {
         string message;

         Exception ret = null;
         VerifyConfiguration();

         //  Delete from cloud
         string token =  RegisteredDataRows.InstanceInfo.StoreToken(row);
         if (string.IsNullOrEmpty(token))
         {
            return null;
         }

         try
         {
            DeleteObjectRequest request = new DeleteObjectRequest()
            {
               BucketName = Configuration.BucketName,
               Key = token
            };

            AmazonClient.DeleteObject(request);
         }
         catch(Exception ex)
         {
            ret = ex;
         }

         if (ret == null)
         {
            message = string.Format("'{0}' external store addin DeleteDicom success, store token '{1}'.", Module.AmazonS3FriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin DeleteDicom failure, store token '{1}, {2}'.", Module.AmazonS3FriendlyName, token, ret.Message);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);
         }

         return ret;
      }

      public Exception RetrieveFile(DataRow row, string outFile)
      {
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         return RetrieveFile(token, outFile);
      }

      public Exception RetrieveDicom(DataRow row, DicomDataSetLoadFlags loadFlags, out DicomDataSet dataset)
      {
         dataset = null;

         //Retrieve from the external store
         byte[] data;

         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         string message;

         Exception ret = Retrieve(token, out data);
         if (ret != null)
         {
            message = string.Format("'{0}' external store addin RetrieveDicom failure, store token '{1}'.  {2}", Module.AmazonS3FriendlyName, token, ret.Message);
            Exception newException = (Exception)Activator.CreateInstance(ret.GetType(), message, ret);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);

            // return ret;
            return newException;
         }
         
         message = string.Format("'{0}' external store addin RetrieveDicom success, store token '{1}'.", Module.AmazonS3FriendlyName, token);
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

         try
         {
            string key = filename.FileNameToToken();
            PutObjectRequest request = new PutObjectRequest()
            {
               BucketName = Configuration.BucketName,
               Key = key,
               FilePath = filename
            };

            PutObjectResponse response = AmazonClient.PutObject(request);
            token = key;
         }
         catch (Exception ex)
         {
            //if ((string.Compare("The resource you are trying to create already exists.", ex.Message, true) == 0) && (overwrite))
            //{
            //   ret = Update(path, data, out token);
            //   return ret;
            //}
            ret = ex;
         }


         return ret;
      }

      public Exception StoreDicom(string filename, DicomDataSet dataset, DicomDataSetSaveFlags saveFlags, bool overwrite, out string token)
      {
         string message;
         Exception ret = null;

         Byte[] ba = dataset.ToByteArray(saveFlags);
         ret = Store(ba, filename, overwrite, out token);
         if (ret == null)
         {
            message = string.Format("'{0}' external store addin StoreDicom success, returned store token '{1}'.", Module.AmazonS3FriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin StoreDicom failure, '{1}'.", Module.AmazonS3FriendlyName, ret.Message);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);
         }

         return ret;
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
            message = string.Format("'{0}' external store addin UpdateDicom success, returned store token '{1}'.", Module.AmazonS3FriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin UpdateDicom failure, '{1}'.", Module.AmazonS3FriendlyName, ret.Message);
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
            ListObjectsRequest request = new ListObjectsRequest();
            request.BucketName = Configuration.BucketName;
            request.Prefix = token;
            ListObjectsResponse response = AmazonClient.ListObjects(request);

            foreach (S3Object entry in response.S3Objects)
            {
               if (string.Compare(token, entry.Key, true) == 0)
               {
                  exists = true;
                  break;
               }
            }
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
            return _amazonS3Configuration.StoreLocally;
         }
      }

      public string ExternalStoreGuid
      {
         get
         {
            return Module.AmazonS3Guid;
         }
      }

      public string FriendlyName
      {
         get { return Module.AmazonS3FriendlyName;}
      }

      #endregion
   }
}
