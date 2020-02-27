// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using System.ComponentModel;
using Leadtools.Dicom.AddIn.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using EsuApiLib.Rest;
using EsuApiLib;

namespace Leadtools.Medical.ExternalStore.Atmos.Addin
{
   [Serializable]
   public class AtmosExternalStoreAddinConfig : ExternalStoreAddinConfigAbstract
   {
      AtmosConfiguration _configurationObject;

      public AtmosExternalStoreAddinConfig()
      {
         AtmosConfiguration atmosConfiguration = new AtmosConfiguration();

         _configurationObject = atmosConfiguration;
      }

      #region IExternalStoreAddinConfig Members

      [XmlElement(typeof(AtmosConfiguration))]
      public override object ConfigurationObject
      {
         get
         {  
            return _configurationObject;
         }
         
         set
         {
            _configurationObject = value as AtmosConfiguration;
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

      private string _guid = Module.AtmosGuid;
      public override string Guid
      {
         get { return _guid; }
         set { _guid = value;}
      }

      [NonSerialized]
      private AtmosCrud _crud = null;

      public override ICrud GetCrudInterface()
      {
         if (_crud == null)
         {
            _crud = new AtmosCrud();
         }

         _crud.Configuration = ConfigurationObject as AtmosConfiguration;
         return _crud;
      }

      private string _friendlyName = Module.AtmosFriendlyName;
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
         EsuRestApi esuRestApi = null;

         try
         {
            Convert.FromBase64String(_configurationObject.SharedSecret);
         }
         catch (Exception ex)
         {
            errorString = string.Format("Invalid 'Shared Secret': '{0}'", ex.Message);
            isValid = false;
         }

         if (isValid)
         {
            try
            {
               esuRestApi = new EsuRestApi(
               _configurationObject.AtmosUrl,
               _configurationObject.Port,
               _configurationObject.Uid,
               _configurationObject.SharedSecret
               );
               esuRestApi.Timeout = 4000;
               ServiceInformation si = esuRestApi.GetServiceInformation();
            }
            catch (Exception ex)
            {
               errorString = ex.Message;
               isValid = false;
            }
         }

         return isValid;
      }


      #endregion
   }


   [Serializable]
   [ExternalStoreConfigurationAttribute]
   public class AtmosConfiguration 
   {
      private string _atmosUrl;

      [DisplayNameAttribute("Atmos URL")]
      [ControlAttribute(Width = 400)]
      public string AtmosUrl
      {
         get { return _atmosUrl; }
         set { _atmosUrl = value; }
      }

      private string _uid;

      [DisplayNameAttribute("UID")]
      [ControlAttribute(Width = 400)]
      public string Uid
      {
         get { return _uid; }
         set { _uid = value; }
      }
      string _sharedSecret;

      [DisplayNameAttribute("Shared Secret")]
      [ControlAttribute(Width = 400, Height = 30)]
      public string SharedSecret
      {
         get { return _sharedSecret; }
         set { _sharedSecret = value; }
      }
      int _port;

      [DisplayNameAttribute("Port (0..9999)")]
      [RangeAttribute(0, 9999)]
      public int Port
      {
         get { return _port; }
         set { _port = value; }
      }

      int _timeout;
      [DisplayNameAttribute("Timeout (seconds)")]
      [RangeAttribute(0, 300)]
      public int Timeout
      {
         get { return _timeout; }
         set { _timeout = value; }
      }

      StorageModelEnum _storageModel;
      [DisplayNameAttribute("Storage Model")]
      [ControlAttribute(Width = 200, Height = 30)]
      public StorageModelEnum StorageModel
      {
         get { return _storageModel; }
         set { _storageModel = value; }
      }

      bool _storeLocally;
      [DisplayNameAttribute("Store Locally")]
      public bool StoreLocally
      {
         get { return _storeLocally; }
         set { _storeLocally = value; }
      }

      public AtmosConfiguration()
      {
         // Set default values
         _uid = "Enter UID";
         _sharedSecret = "Enter Shared Secret";
         _port = 443;
         _atmosUrl = "api.atmosonline.com";
         _storeLocally = true;
         _timeout = 100;
         _storageModel = StorageModelEnum.Object;
      }
   }

   public enum StorageModelEnum
   {
      [Description("Object Model")]
      Object = 0,

      [Description("NameSpace Model")]
      NameSpace = 1
   }

}
