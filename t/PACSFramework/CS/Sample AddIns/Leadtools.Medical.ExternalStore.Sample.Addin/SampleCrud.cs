// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Winforms.ExternalStore;
using System.IO;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom;
using System.Data;

namespace Leadtools.Medical.ExternalStore.Sample.Addin
{
   public class SampleCrud : ICrud
   {
      private SampleConfiguration _sampleConfiguration;

      // Gets/Sets the current configuration settings for this external store add-in
      public SampleConfiguration Configuration
      {
         get
         {
            if (_sampleConfiguration != null)
               return _sampleConfiguration;

            if (Module.Options == null)
               return null;

            ExternalStoreItem item = Module.Options.GetCurrentOption();
            if (item == null)
               return null;

            _sampleConfiguration = item.ExternalStoreAddinConfig.ConfigurationObject as SampleConfiguration;
            return _sampleConfiguration;
         }

         set
         {
            _sampleConfiguration = value;
         }
      }

      // A token is a string value, that together with the external store add-in GUID, corresponds to a file stored externally.
      // For this sample external store add-in, the external store path will be the path SampleConfiguration.Location
      // This function takes the local store name, and returns the external store full path name
      private string GetTokenFromFilename(string fn)
      {
         string fileName = Path.GetFileName(fn);
         string location = Configuration.Location;
         Directory.CreateDirectory(location);
         string token = Path.Combine(location, fileName);
         return token;
      }

      #region ICrud Members

      // No initialization required for the sample external store add-in
      public void Initialize()
      {
         // do nothing
      }

      // This is called by the PACSFramework when the external store settings change for any external store addin through the CSStorageServerManager UI
      // This method should re-read the external store settings
      public void SettingsChanged()
      {
         Module.ExternalStoreSettingsChanged();
      }

      // Since the token is the full path of the externally stored file,
      // simply call File.Delete(token)
      public Exception Delete(string token)
      {
         Exception ret = null;
         try
         {
            File.Delete(token);
         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      // Use the helper method (from Leadtools.Medical.Storage.DataAccessLayer.dll) 
      // which takes a DataRow, and returns a token
      //    string token = RegisteredDataRows.InstanceInfo.StoreToken(DataRow row)
      // Then call the existing ICrud.Delete() method
      public Exception DeleteDicom(DataRow row)
      {
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         return Delete(token);
      }

      public Exception Exists(string token, out bool exists)
      {
         exists = false;
         Exception ret = null;
         try
         {
            exists = File.Exists(token);
         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      public Exception ExistsDicom(DataRow row, out bool exists)
      {
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         return Exists(token, out exists);
      }

      public Exception RetrieveDicom(DataRow row, DicomDataSetLoadFlags loadFlags, out DicomDataSet ds)
      {
         ds = null;
         Exception ret = null;
         try
         {
            ds = new DicomDataSet();

            string token = RegisteredDataRows.InstanceInfo.StoreToken(row);

            ds.Load(token, loadFlags);
         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      private static Exception RetrieveFile(string token, string outFile)
      {
         Exception ret = null;
         try
         {
            File.Copy(token, outFile);
         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      public Exception RetrieveFile(DataRow row, string outFile)
      {
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);
         return RetrieveFile(token, outFile);
      }

      public Exception Store(string filename, bool overwrite, out string token)
      {
         Exception ret = null;
         token = string.Empty;

         try
         {
            string newFileName = GetTokenFromFilename(filename);
            token = newFileName;
            if (overwrite || !File.Exists(newFileName))
            {
               File.Copy(filename, newFileName, true);
            }
         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      private Exception SaveDicom(string filename, DicomDataSet ds, DicomDataSetSaveFlags saveFlags, out string token)
      {
         Exception ret = null;
         string newFileName = GetTokenFromFilename(filename);
         token = newFileName;
         try
         {
            string directory = Path.GetDirectoryName(newFileName);
            Directory.CreateDirectory(directory);
            ds.Save(newFileName, saveFlags);
         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      public Exception StoreDicom(string filename, DicomDataSet ds, DicomDataSetSaveFlags saveFlags, bool overwrite, out string token)
      {
         token = string.Empty;
         Exception ret = null;
         try
         {
            if (overwrite || !File.Exists(filename))
            {
               SaveDicom(filename, ds, saveFlags, out token);
            }

         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      // Patient Updater calls 'UpdateDicom'
      // Write the file if it already exists
      // If no exists, do nothing.
      public Exception UpdateDicom(DataRow row, DicomDataSet dataset, DicomDataSetSaveFlags saveFlags)
      {
         string token = RegisteredDataRows.InstanceInfo.StoreToken(row);

         Exception ret = null;
         try
         {
            // (07.10.2019)
            // Changed this to always write the file, even if it does not exist
            // if (File.Exists(token))
            {
               dataset.Save(token, saveFlags);
            }
         }
         catch (Exception ex)
         {
            ret = ex;
         }
         return ret;
      }

      public string ExternalStoreGuid
      {
         get { return Module.SampleGuid; }
      }

      public string FriendlyName
      {
         get { return Module.FriendlyName; }
      }

      // This is equivalent to the current value of the SampleConfiguration.StoreLocally
      public bool StoreLocal
      {
         get
         {
            return _sampleConfiguration.StoreLocally;
         }
      }

      #endregion
   }
}
