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
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace Leadtools.Medical.ExternalStore.AmazonS3.Addin
{
   [Serializable]
   public class AmazonS3ExternalStoreAddinConfig : ExternalStoreAddinConfigAbstract
   {
      AmazonS3Configuration _configurationObject;

      public AmazonS3ExternalStoreAddinConfig()
      {
         AmazonS3Configuration amazonS3Configuration = new AmazonS3Configuration();

         _configurationObject = amazonS3Configuration;
      }

      #region IExternalStoreAddinConfig Members

      [XmlElement(typeof(AmazonS3Configuration))]
      public override object ConfigurationObject
      {
         get
         {  
            return _configurationObject;
         }
         
         set
         {
            _configurationObject = value as AmazonS3Configuration;
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

      private string _guid = Module.AmazonS3Guid;
      public override string Guid
      {
         get { return _guid; }
         set { _guid = value;}
      }

      [NonSerialized]
      private AmazonS3Crud _crud = null;

      public override ICrud GetCrudInterface()
      {
         if (_crud == null)
         {
            _crud = new AmazonS3Crud();
         }

         _crud.Configuration = ConfigurationObject as AmazonS3Configuration;
         return _crud;
      }

      private string _friendlyName = Module.AmazonS3FriendlyName;
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
         IAmazonS3 amazonS3Client = null;
         GetBucketLocationResponse response = null;

         try
         {
            Convert.FromBase64String(_configurationObject.SecretAccessKey);
         }
         catch (Exception ex)
         {
            errorString = string.Format("Invalid 'Secret Access Key': '{0}'", ex.Message);
            isValid = false;
         }

         if (isValid)
         {
            try
            {
               amazonS3Client = new AmazonS3Client(
               _configurationObject.AccessKeyId,
               _configurationObject.SecretAccessKey,
               _configurationObject.Region.ToRegionEndpoint()
               );

               response = amazonS3Client.GetBucketLocation(_configurationObject.BucketName);
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
   public class AmazonS3Configuration 
   {
      private string _bucketName;

      [DisplayNameAttribute("AmazonS3 URL")]
      [ControlAttribute(Width = 400)]
      public string BucketName
      {
         get { return _bucketName; }
         set { _bucketName = value; }
      }

      private string _accessKeyId;

      [DisplayNameAttribute("Access Key ID")]
      [ControlAttribute(Width = 400)]
      public string AccessKeyId
      {
         get { return _accessKeyId; }
         set { _accessKeyId = value; }
      }
      string _secretAccessKey;

      [DisplayNameAttribute("Secret Access Key")]
      [ControlAttribute(Width = 400, Height = 30)]
      public string SecretAccessKey
      {
         get { return _secretAccessKey; }
         set { _secretAccessKey = value; }
      }

      RegionEndpointEnum _region;
      [DisplayNameAttribute("Region")]
      [ControlAttribute(Width = 200, Height = 30)]
      public RegionEndpointEnum Region
      {
         get { return _region; }
         set { _region = value; }
      }

      bool _storeLocally;
      [DisplayNameAttribute("Store Locally")]
      public bool StoreLocally
      {
         get { return _storeLocally; }
         set { _storeLocally = value; }
      }

      public AmazonS3Configuration()
      {
         // Set default values
         _accessKeyId = "Enter Access Key ID";
         _secretAccessKey = "Enter Secret Access Key";
         _bucketName = "leadtools.bucket.1";
         _storeLocally = true;
         _region = RegionEndpointEnum.USEastNVirginia;
      }
   }

   public enum RegionEndpointEnum
   {
      [Description("Asia Pacific (Mumbai)")]
      AsiaPacificMumbai = 0,

      [Description("Asia Pacific (Seoul")]
      AsiaPacificSeoul = 1,

      [Description("Asia Pacific (Singapore)")]
      AsiaPacificSingapore = 2,

      [Description("Asia Pacific (Sydney)")]
      AsiaPacificSydney = 3,

      [Description("Asia Pacific (Tokyo)")]
      AsiaPacificTokyo = 4,

      [Description("Canada (Central)")]
      CanadaCentral = 5,

      [Description("EU (Frankfurt)")]
      EUFrankfurt = 6,

      [Description("EU (Ireland)")]
      EUIreland = 7,

      [Description("EU (London)")]
      EULondon = 8,

      [Description("EU (Paris)")]
      EUParis = 9,

      [Description("EU (Stockholm)")]
      EUStockholm = 10,

      [Description("South America (São Paulo)")]
      SouthAmericaSaoPaulo = 11,

      [Description("US East (N. Virginia)")]
      USEastNVirginia = 12,

      [Description("US East (Ohio)")]
      USEastOhio = 13,

      [Description("US West (N. California)")]
      USWestNCalifornia = 14,

      [Description("US West (Oregon)")]
      USWestOregon = 15,

   }

}
