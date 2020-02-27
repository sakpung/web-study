// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.UI
{
   partial class GeneralSettingsPresenter
   {

      private const bool WindowsServiceDescriptionEnabled = true;

      private string[] GetAddIns()
      {
         string[] addIns = new string[] 
                           { 
                              "Leadtools.Medical.AutoCopy.AddIn.dll",
                              "Leadtools.Medical.PatientUpdater.AddIn.dll",
                              "Leadtools.Medical.Storage.Addins.dll",
                              "Leadtools.Medical.Forwarder.AddIn.dll", 
                              "Leadtools.Medical.Rules.AddIn.dll",
#if LEADTOOLS_V19_OR_LATER
                              // External Store Base Addin
                              "Leadtools.Medical.ExternalStore.Addin.dll",

                              // Atmos External Store Addin
                              "EsuApiLib.dll",
                              "Leadtools.Medical.ExternalStore.Atmos.Addin.dll", // located in addinsDir

                              // Azure External Store Addin
                              // "Microsoft.WindowsAzure.Storage.dll", 
                              "Leadtools.Medical.ExternalStore.Azure.Addin.dll", // located in addinsDir

                              // LEAD Sample External STore Addin
                              "Leadtools.Medical.ExternalStore.Sample.Addin.dll",

                              // HL7
                              "Leadtools.Medical.HL7PatientUpdate.AddIn.dll", 
#endif // #if LEADTOOLS_V19_OR_LATER

                              "Leadtools.Medical.Security.Addin.dll", 

#if LEADTOOLS_V20_OR_LATER
                              "Leadtools.Medical.PatientRestrict.AddIn.dll",

                              // AmazonS3 External Store Addin
                              "AWSSDK.Core.dll",
                              "AWSSDK.S3.dll",
                              "Leadtools.Medical.ExternalStore.AmazonS3.Addin.dll",
                              "Leadtools.Medical.ExportLayout.AddIn.dll",
#endif
      };

         return addIns;
      }

      private string[] GetConfigurationAddIns()
      {
         string[] configurationAddIns = new string[] 
                                        {
                                          "Leadtools.Medical.Ae.Configuration.dll",
                                          "Leadtools.Medical.Logging.Addin.dll",
                                          "Leadtools.Medical.License.Configuration.dll",
                                        };

         return configurationAddIns;
      }
      
      private const string WindowsServiceDescription = "LTSTORAGESERVER";
      
      private const bool AutoCreateLocationsDefault = true;
   }
}
