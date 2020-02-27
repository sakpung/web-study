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
using System.IO;

namespace Leadtools.Medical.ExternalStore.Sample.Addin
{
   [Serializable]
   public class SampleExternalStoreAddinConfig : ExternalStoreAddinConfigAbstract
   {
      public SampleExternalStoreAddinConfig()
      {
         _crud = null;
         _configurationObject = new SampleConfiguration();
      }

      #region IExternalStoreAddinConfig Members

      // The unique configuration settings for this add-in (specificed by the SampleConfiguration class)
      private SampleConfiguration _configurationObject;
      public override object ConfigurationObject
      {
         get { return _configurationObject; }
         set { _configurationObject = value as SampleConfiguration; }
      }

      // This add-in supports the AutoClear option
      public override bool EnableAutoClear
      {
         get { return true; }
      }

      // This add-in supports the AutoExternalStore option
      public override bool EnableAutoExternalStore
      {
         get { return true; }
      }

      // This add-in supports the VerifyRetrieve option
      public override bool EnableVerifyRetrieveAfterExternalStore
      {
         get { return true; }
      }
      
      // Returns the FriendlyName
      // Note that the empty settor is required for serialization
      public override string FriendlyName
      {
         get { return Module.FriendlyName; }
         set { }
      }

      // Returns the Guid
      // Note that the empty settor is required for serialization
      public override string Guid
      {
         get { return Module.SampleGuid; }
         set { }
      }

      [NonSerialized]
      private SampleCrud _crud;

      public override ICrud GetCrudInterface()
      {
         if (_crud == null)
         {
            _crud = new SampleCrud();
         }

         _crud.Configuration = ConfigurationObject as SampleConfiguration;
         return _crud;
      }

      public override bool VerifyConfiguration(out string errorString)
      {
         errorString = string.Empty;

         string folderPath = _configurationObject.Location;

         // Check to see if directory exists
         bool exists = Directory.Exists(folderPath);
         if (!exists)
         {
            try
            {
               Directory.CreateDirectory(folderPath);
            }
            catch(Exception)
            {
               errorString = string.Format("Cannot create directory location: '{0}", folderPath);
               return false;
            }
         }

         exists = Directory.Exists(folderPath);
         if (!exists)
         {
            errorString = string.Format("Location does not exist: '{0}", folderPath);
            return false;
         }

         // Check to see if user has write permissions
         try
         {
            // Attempt to get a list of security permissions from the folder. 
            // This will raise an exception if the path is read only or do not have access to view the permissions. 
            Directory.GetAccessControl(folderPath);
         }
         catch (UnauthorizedAccessException)
         {
            errorString = string.Format("No permissions to write to Location: '{0}", folderPath);
            return false;
         }

         return true;
      }

      public override string ToString()
      {
         return FriendlyName;
      }

      #endregion
   }


   // Configuration Class
   [Serializable]
   [ExternalStoreConfigurationAttribute]
   public class SampleConfiguration 
   {
      [DisplayNameAttribute("User ID")]
      [ControlAttribute(Width = 400)]
      public string UserId
      {
         get;
         set;
      }

      [DisplayNameAttribute("Password")]
      [ControlAttribute(Width = 400, Password = true)]
      public string Password
      {
         get;
         set;
      }

      [DisplayNameAttribute("Name")]
      [ControlAttribute(Width = 400)]
      public string Name
      {
         get;
         set;
      }

      MyGenderEnum _gender;
      [DisplayNameAttribute("Gender")]
      [ControlAttribute(Width = 200, Height = 30)]
      public MyGenderEnum Gender
      {
         get { return _gender; }
         set { _gender = value; }
      }

      [DisplayNameAttribute("Age (0..99)")]
      [RangeAttribute(0, 99)]
      public int Age
      {
         get;
         set;
      }
      
      [DisplayNameAttribute("Location")]
      [ControlAttribute(Width = 400)]
      public string Location
      {
         get;
         set;
      }

      private bool _storeLocally;
      [DisplayNameAttribute("Store Locally")]
      public bool StoreLocally
      {
         get { return _storeLocally; }
         set { _storeLocally = value; }
      }

      public SampleConfiguration()
      {
         UserId = "Enter User ID";
         Password = "Enter Password";
         Name = "Enter Name";
         Age = 18;
         StoreLocally = true;
         Location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExternalStoreSampleStore");
      }
   }

      public enum MyGenderEnum
      {
         [Description("Male")]
         Male = 0,

         [Description("Female")]
         Female = 1,

         [Description("Unknown")]
         Unknown = 2
      }
}
