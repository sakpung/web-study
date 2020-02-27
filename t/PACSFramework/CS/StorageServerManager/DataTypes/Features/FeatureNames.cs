// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.DataTypes
{
   public class FeatureNames
   {
      public FeatureNames ( string name, string displayName ) 
      {
         Name        = name ;
         DisplayName = displayName ;
      }

      static FeatureNames ( ) 
      {
         DisplaySettingsFeature = new FeatureNames ( "DisplaySettingsDlg", "Settings" ) ;
         ServerParentFeature    = new FeatureNames ( "DICOMServer", "DICOM Server" ) ;
         ServerSettings         = new FeatureNames ( "ServerGeneralSettings", "Settings" ) ;
         ServerOptions          = new FeatureNames ( "ServerOptions", "Options" ) ;
         ServerNetworking       = new FeatureNames ( "ServerNetworking", "Networking" ) ;
         LoggingConfig          = new FeatureNames ( "LoggingConfiguration", "Logging Configuration" ) ;
         ClientConfig           = new FeatureNames ( "ClientConfiguration", "Client Configuration" ) ;
         ServerFiles            = new FeatureNames ( "Files", "Files" ) ;
         AdministrationParentFeature = new FeatureNames ( "Administration", "Administration")  ;
         PasswordOptions        = new FeatureNames ( "PasswordOptions", "Login Options" ) ;
         Users                  = new FeatureNames ( "Users", "Users" ) ;
         CardUsers              = new FeatureNames ( "CardUsers", "Card Users" ) ;
         PatientUpdater         = new FeatureNames ( "PatientUpdater", "Patient Updater" ) ;
         AutoCopy               = new FeatureNames ( "AutoCopy", "Auto Copy" ) ;
         StoreSettingsParentFeature = new FeatureNames ( "StoreSettings", "Storage Settings" ) ;
         IodClasses             = new FeatureNames ( "IodClasses", "IOD Classes" ) ;
         StoreSettings          = new FeatureNames ( "StoreSettings", "Store Settings" ) ;
         QuerySettings          = new FeatureNames ( "QuerySettings", "Query Settings" ) ;
         Forwarder              = new FeatureNames("Forwarder", "Forwarding");
         Gateway                = new FeatureNames("Gateway", "Gateway");
         Roles                  = new FeatureNames("Roles", "Roles");
         DatabaseManagerOptions = new FeatureNames("DatabaseManagerOptions", "Database Manager Options");

#if LEADTOOLS_V20_OR_LATER
         ClientConfigurationOptions = new FeatureNames("ClientConfigurationOptions", "Client Configuration Options");
#endif 
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         ExternalStore          = new FeatureNames("ExternalStore", "External Store") ;
#endif

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         AnonymizeOptions       = new FeatureNames("AnonymizeOptions", "Anonymize Options");
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         StorageCommit       = new FeatureNames("StorageCommit", "Storage Commit Settings");

         SecurityOptions     = new FeatureNames("DICOM Security", "DICOM Security Options");
      }


      public string Name        { get ;private set ; }
      public string DisplayName { get ;private set ; }

      public static FeatureNames DisplaySettingsFeature { get ; private set ; } 
      public static FeatureNames ServerParentFeature    { get ; private set ; }
      public static FeatureNames ServerSettings         { get ; private set ; } 
      public static FeatureNames ServerOptions          { get ; private set ; } 
      public static FeatureNames ServerNetworking       { get ; private set ; } 
      public static FeatureNames LoggingConfig          { get ; private set ; }
      public static FeatureNames ClientConfig           { get; private set; }
      public static FeatureNames ServerFiles            { get ; private set ; }
      public static FeatureNames AdministrationParentFeature { get ; private set ; }
      public static FeatureNames PasswordOptions        { get; private set; }
      public static FeatureNames CardUsers              { get; private set; }
      public static FeatureNames Users                  { get; private set; }
      public static FeatureNames PatientUpdater         { get; private set; }
      public static FeatureNames AutoCopy               { get; private set; }
      public static FeatureNames StoreSettingsParentFeature { get; private set; }
      public static FeatureNames IodClasses             { get; private set; }
      public static FeatureNames StoreSettings          { get; private set; }
      public static FeatureNames QuerySettings          { get; private set; }
      public static FeatureNames Forwarder              { get; private set; }
      public static FeatureNames Gateway                { get; private set; }
      public static FeatureNames Roles                  { get; private set; }
      public static FeatureNames DatabaseManagerOptions { get; private set; }
#if LEADTOOLS_V20_OR_LATER
      public static FeatureNames ClientConfigurationOptions { get; private set; }
#endif
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      public static FeatureNames ExternalStore          { get; private set; }
#endif
#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      public static FeatureNames AnonymizeOptions       { get; private set; }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      public static FeatureNames StorageCommit { get; private set; }

      public static FeatureNames SecurityOptions { get; private set; }
   }
}
