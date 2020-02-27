// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using System.Diagnostics;
using Leadtools.Logging;
using System.Collections.ObjectModel;
using System.IO;

namespace Leadtools.Medical.License.Configuration
{
   public class ServerLicense : ILicense
   {
      private DicomServer _Server;
      private string _LicenseFile;      

      public ServerLicense(DicomServer server)
      {         
         if (server != null)
         {
            _LicenseFile = server.LicenseFile;
            _Server = server;
            _Server.ServerSettingsChanged += new EventHandler(SettingsChanged);            
         }

         LoadFeatures();
      }

      public ServerLicense(string licenseFile)
      {
         _LicenseFile = licenseFile;
      }

      public void Initialize()
      {
         LoadFeatures();
      }

      public void Load(string licenseFile)
      {
      }

      void SettingsChanged(object sender, EventArgs e)
      {
         if (_LicenseFile.ToLower() != _Server.LicenseFile.ToLower())
         {            
            _LicenseFile = _Server.LicenseFile;
            try
            {
               OnLicenseChanged();
            }
            catch (Exception exception)
            {
               Logger.Global.Exception("Licensing", exception);              
            }
         }
      }
     
      #region ILicense Members

      public IFeature GetFeature(string featureId)
      {
         foreach (IFeature feature in _Features)
         {
            if (feature.Id == featureId)
               return feature;
         }
         return null;
      }      

      public long GetFeatureCount(string featureId)
      {
         return long.MaxValue;
      }

      public string GetFeatureData(string featureId)
      {
         return string.Empty;
      }     

      public bool IsFeatureEvaluation(string featureId)
      {
         return false;
      }

      public bool IsFeatureExpired(string featureId)
      {
         return false;
      }

      public bool IsFeatureValid(string featureId)
      {
         return true;
      }

      public bool IsValid()
      {
         return true;
      }

      private List<IFeature> _Features = new List<IFeature>();

      public ReadOnlyCollection<IFeature> Features
      {
         get 
         {
            return _Features.AsReadOnly();
         }
      }

      public string Customer
      {
         get 
         {
            return Environment.UserName;
         }
      }

      public string Manufacturer
      {
         get
         {
            return Environment.MachineName;
         }
      }

      public string Product
      {
         get
         {
            return "LEADTOOLS Pacs Imaging";
         }
      }

      public event EventHandler LicenseChanged;

      private void OnLicenseChanged()
      {
         if (LicenseChanged != null)
         {
            LicenseChanged(this, EventArgs.Empty);
         }
      }      

      #endregion       
  
      private void LoadFeatures()
      {
         _Features.Clear();
         try
         {
            _Features.Add(new LicenseFeature("F000", "General Functionality") { Type = LicenseFeatureType.On });
            _Features.Add(new LicenseFeature(ServerFeatures.MaxConcurrentConnections, "Maximum Concurrent Connections") { Type = LicenseFeatureType.LimitedNumber , Counter=0 });
            _Features.Add(new LicenseFeature(ServerFeatures.MaxConfigurableClients, "Maximum Configurable Clients") { Type = LicenseFeatureType.LimitedNumber, Counter=0 });
            _Features.Add(new LicenseFeature(ServerFeatures.MaxStudiesStored, "Maximum Stored Studies") { Type = LicenseFeatureType.LimitedNumber, Counter = 0 });
            _Features.Add(new LicenseFeature(ServerFeatures.MaxSeriesStored, "Maximum Stored Series") { Type = LicenseFeatureType.LimitedNumber, Counter = 0 });
            _Features.Add(new LicenseFeature(ServerFeatures.Forwarding, "Image Forwarding") { Type = LicenseFeatureType.On });
            _Features.Add(new LicenseFeature(ServerFeatures.Gateway, "Central Server Gateway") { Type = LicenseFeatureType.On });
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
            _Features.Add(new LicenseFeature(ServerFeatures.Rules, "Rules") { Type = LicenseFeatureType.On });
            _Features.Add(new LicenseFeature(ServerFeatures.Worklist, "WorkList") { Type = LicenseFeatureType.On });
            _Features.Add(new LicenseFeature(ServerFeatures.ExternalStore, "External Store") { Type = LicenseFeatureType.On });
#endif
         }
         catch (Exception)
         {
         }
      }     
   }
}
