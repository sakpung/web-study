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


namespace Leadtools.Medical.ExternalStore.Atmos.Addin
{
[Serializable]
   public class AtmosCrud : ICrud
   {
      public AtmosCrud()
      {
         _atmosEsuRestApi = null;
         _defaultCrud = null;
#if DEBUG
         Console.WriteLine("");
#endif
      }

   private AtmosConfiguration _atmosConfiguration;

      public AtmosConfiguration Configuration
      {
         get
         {
            if (_atmosConfiguration != null)
               return _atmosConfiguration;

            if (Module.Options == null)
               return null;

            ExternalStoreItem item = Module.Options.GetCurrentOption();
            if (item == null)
               return null;

            _atmosConfiguration = item.ExternalStoreAddinConfig.ConfigurationObject as AtmosConfiguration;
            return _atmosConfiguration;
         }

         set
         {
            _atmosConfiguration = value;
         }
      }

      private void VerifyConfiguration()
      {
         if (Configuration == null)
         {
            throw new Exception("Error: Atmos ExternalStoreAddin not configured.");
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

      EsuRestApi _atmosEsuRestApi;

      public EsuRestApi AtmosEsuRestApi
      {
         get 
         { 
            if (_atmosEsuRestApi == null)
            {
               try
               {
                  Convert.FromBase64String(_atmosConfiguration.SharedSecret);
               }
               catch(Exception ex)
               {
                  string message = string.Format("'{0}'Invalid Shared Secret: {1}", Module.AtmosFriendlyName, ex.Message);
                  throw new Exception(message);
               }

               _atmosEsuRestApi = new EsuRestApi(
                _atmosConfiguration.AtmosUrl,
                _atmosConfiguration.Port,
                _atmosConfiguration.Uid,
                _atmosConfiguration.SharedSecret
                );
            }
            _atmosEsuRestApi.Timeout = 1000 * _atmosConfiguration.Timeout;
            return _atmosEsuRestApi; 
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
            ObjectId oid = new ObjectId(token.Trim());
            data = AtmosEsuRestApi.ReadObject(oid, null, null);
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

      private Exception Store(byte[] data, string filename, bool overwrite, out string token)
      {
         Exception ret = null;
         token = string.Empty;
         VerifyConfiguration();

         filename = filename.Replace('\\', '/');
         ObjectPath path = new ObjectPath(filename);

         try
         {
            Object oid;
            switch (_atmosConfiguration.StorageModel)
            {
               case StorageModelEnum.Object:
                  string mimeType = string.Empty;
                  oid = AtmosEsuRestApi.CreateObject(null, null, data, mimeType);
                  break;

               case StorageModelEnum.NameSpace:
               default:
                  oid = AtmosEsuRestApi.CreateObjectOnPath(path, null, null, data, null);
                  break;
            }

            token = oid.ToString();
         }
         catch (Exception ex)
         {
            if ((string.Compare("The resource you are trying to create already exists.", ex.Message, true) == 0) && (overwrite))
            {
               ret = Update(path, data, out token);
               return ret;
            }
            ret = ex;
         }
         return ret;
      }

      private Exception Update(ObjectPath objectPath, byte[] data, out string token)
      {
         Exception ret = null;
         token = string.Empty;
         VerifyConfiguration();

         try
         {
            AtmosEsuRestApi.UpdateObject(objectPath, null, null, null, data, null);
            ObjectInfo info = AtmosEsuRestApi.GetObjectInfo(objectPath);
            token = info.ObjectID.ToString();
         }
         catch(Exception ex)
         {
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
            ObjectId oid = new ObjectId(token);
            AtmosEsuRestApi.UpdateObject(oid, null, null, null, data, null);
         }
         catch(Exception ex)
         {
            ret = ex;
         }

         return ret;
      }

      #region ICrud Members

      public void Initialize()
      {
         _atmosEsuRestApi = null;
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
            ObjectId oid = new ObjectId(token);
            AtmosEsuRestApi.DeleteObject(oid);
         }
         catch(Exception ex)
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
            ObjectId oid = new ObjectId(token);
            AtmosEsuRestApi.DeleteObject(oid);
         }
         catch(Exception ex)
         {
            ret = ex;
         }

         if (ret == null)
         {
            message = string.Format("'{0}' external store addin DeleteDicom success, store token '{1}'.", Module.AtmosFriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin DeleteDicom failure, store token '{1}, {2}'.", Module.AtmosFriendlyName, token, ret.Message);
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
            message = string.Format("'{0}' external store addin RetrieveDicom failure, store token '{1}'.  {2}", Module.AtmosFriendlyName, token, ret.Message);
            Exception newException = (Exception)Activator.CreateInstance(ret.GetType(), message, ret);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);

            // return ret;
            return newException;
         }
         
         message = string.Format("'{0}' external store addin RetrieveDicom success, store token '{1}'.", Module.AtmosFriendlyName, token);
         Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);

         dataset = new DicomDataSet();
         MemoryStream stream = new MemoryStream(data);
         dataset.Load(stream, loadFlags);


         return null;
      }

      public Exception Store(string filename, bool overwrite, out string token)
      {
          byte[] fileBytes = File.ReadAllBytes(filename);
          Exception ex = Store(fileBytes, filename, overwrite, out token);
          return ex;
      }

      public Exception StoreDicom(string filename, DicomDataSet dataset, DicomDataSetSaveFlags saveFlags, bool overwrite, out string token)
      {
         string message;
         Exception ret = null;

         Byte[] ba = dataset.ToByteArray(saveFlags);
         ret = Store(ba, filename, overwrite, out token);
         if (ret == null)
         {
            message = string.Format("'{0}' external store addin StoreDicom success, returned store token '{1}'.", Module.AtmosFriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin StoreDicom failure, '{1}'.", Module.AtmosFriendlyName, ret.Message);
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
            message = string.Format("'{0}' external store addin UpdateDicom success, returned store token '{1}'.", Module.AtmosFriendlyName, token);
            Logger.Global.SystemMessage(LogType.Debug, message, Module.ServiceName);
         }
         else
         {
            message = string.Format("'{0}' external store addin UpdateDicom failure, '{1}'.", Module.AtmosFriendlyName, ret.Message);
            Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);
         }

         return ret;
      }

      public Exception Exists(string token, out bool exists)
      {
         Exception ret = null;
         exists = false;
         VerifyConfiguration();

         ObjectId oid = new ObjectId(token);

         try
         {
            ObjectInfo info = AtmosEsuRestApi.GetObjectInfo(oid);
            exists = true;
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
            return _atmosConfiguration.StoreLocally;
         }
      }

      public string ExternalStoreGuid
      {
         get
         {
            return Module.AtmosGuid;
         }
      }

      public string FriendlyName
      {
         get { return Module.AtmosFriendlyName;}
      }

      #endregion
   }
}
