// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using System.ComponentModel;
using Leadtools.Dicom.AddIn.Attributes;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Leadtools.Medical.ExternalStore.Azure.Addin
{
   [Serializable]
   public class AzureExternalStoreAddinConfig : ExternalStoreAddinConfigAbstract
   {
      AzureConfiguration _configurationObject;

      public AzureExternalStoreAddinConfig()
      {
         _crud = null;
         AzureConfiguration azureConfiguration = new AzureConfiguration();

         _configurationObject = azureConfiguration;
      }

      #region IExternalStoreAddinConfig Members

      [XmlElement(typeof(AzureConfiguration))]
      public override object ConfigurationObject
      {
         get
         {
            return _configurationObject;
         }

         set
         {
            _configurationObject = value as AzureConfiguration;
         }
      }

      public override bool EnableAutoClear
      {
         get { return true; }
      }

      public override bool EnableAutoExternalStore
      {
         get { return true; }
      }

      public override bool EnableVerifyRetrieveAfterExternalStore
      {
         get { return true; }
      }

      private string _guid = Module.AzureGuid;
      public override string Guid
      {
         get { return _guid; }
         set { _guid = value; }
      }

      [NonSerialized]
      private AzureCrud _crud;

      public override ICrud GetCrudInterface()
      {
         if (_crud == null)
         {
            _crud = new AzureCrud();
         }

         _crud.Configuration = ConfigurationObject as AzureConfiguration;
         return _crud;
      }

      private string _friendlyName = Module.AzureFriendlyName;
      public override string FriendlyName
      {
         get { return _friendlyName; }
         set { _friendlyName = value; }
      }

      public override string ToString()
      {
         return _friendlyName;
      }

      public override bool VerifyConfiguration(out string errorString)
      {
         bool isValid = true;
         errorString = string.Empty;



         try
         {
            StorageCredentials storageCredentials = new StorageCredentials(_configurationObject.StorageAccountName, _configurationObject.StorageAccountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(storageCredentials, _configurationObject.UseHttps);

            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container. 
            CloudBlobContainer container = cloudBlobClient.GetContainerReference("testcontainer1");

            // Create the container if it does not already exist.
            container.CreateIfNotExists();

            // Output container URI to debug window.
            System.Diagnostics.Debug.WriteLine(container.Uri);
         }
         catch (Exception ex)
         {
            errorString = ex.Message;
            isValid = false;
         }

         return isValid;
      }


      #endregion
   }


   [Serializable]
   [ExternalStoreConfigurationAttribute]
   public class AzureConfiguration 
   {
      private string _storageAccountName;

      [DisplayNameAttribute("Account Name")]
      [ControlAttribute(Width = 600)]
      public string StorageAccountName
      {
         get { return _storageAccountName; }
         set { _storageAccountName = value; }
      }

      private string _storageAccountKey;

      [DisplayNameAttribute("Account Key")]
      [ControlAttribute(Width = 600)]
      public string StorageAccountKey
      {
         get { return _storageAccountKey; }
         set { _storageAccountKey = value; }
      }

      private string _containerName;
       [DisplayNameAttribute("Container Name")]
      [ControlAttribute(Width = 600)]
      public string ContainerName
      {
         get { return _containerName; }
         set { _containerName = value; }
      }

      bool _useHttps;
      [DisplayNameAttribute("Use HTTPS")]
      public bool UseHttps
      {
         get { return _useHttps; }
         set { _useHttps = value; }
      }
     

      bool _storeLocally;
      [DisplayNameAttribute("Store Locally")]
      public bool StoreLocally
      {
         get { return _storeLocally; }
         set { _storeLocally = value; }
      }

      public AzureConfiguration()
      {
         // Set default values
         _storageAccountName = "testcontainer";
         _storageAccountKey ="storageAccountKey";
         _containerName = "mycontainer";
         _useHttps = true;
         _storeLocally = true;
      }
   }

}
