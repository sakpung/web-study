// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO;

namespace DicomDemo
{
   static class ConfigurationData
   {
      static ConfigurationData ( ) 
      {
         ReadConfig ( ) ;
      }

      private static void ReadConfig()
      {
         try
         {
            AppSettingsReader configReader ;
            
            
            configReader = new AppSettingsReader ( ) ;
            
            
            SetConfigValue <string> ( configReader,
                                      Constants.ApplicationName,
                                      delegate ( string  data ) { ApplicationName = data ; },
                                      "Database Configuration Wizard" ) ;
            
            SetConfigValue <string> ( configReader, 
                                      Constants.ApplicationIcon, 
                                      delegate ( string data ) { __ApplicationIcon = data ; },
                                      string.Empty ) ;
            
            SetConfigValue <string> ( configReader, 
                                      Constants.DefaultProvider, 
                                      delegate ( string data ) { DefaultProvider = data ; },
                                      ConnectionProviders.SqlCeProvider.Name ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.SupportedProvider, 
                                      delegate ( string data ) { SupportedProvider = data ; },
                                      string.Empty ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.AppendProcessType, 
                                      delegate ( string data ) { AppendProcessType = bool.Parse ( data ) ; },
                                      "True" ) ;
                                      
            SetConfigValue<string>(configReader,
                                      Constants.DefaultStorageServerDbName,
                                      delegate(string data) { DefaultStorageServerDbName = data; },
                                      Constants.DataBasesDefaultNames.StorageServer);
                         
            SetConfigValue <string> ( configReader, 
                                      Constants.DefaultLoggingDbName, 
                                      delegate ( string data ) { DefaultLoggingDbName = data ; },
                                      Constants.DataBasesDefaultNames.Logging ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.DefaultStorageDbName, 
                                      delegate ( string data ) { DefaultStorageDbName = data ; },
                                      Constants.DataBasesDefaultNames.Storage ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.DefaultWorklistDbName, 
                                      delegate ( string data ) { DefaultWorklistDbName = data ; },
                                      Constants.DataBasesDefaultNames.Worklist ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.DefaultMediaCreationDbName, 
                                      delegate ( string data ) { DefaultMediaCreationDbName = data ; },
                                      Constants.DataBasesDefaultNames.Media ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.DefaultWorkstationDbName, 
                                      delegate ( string data ) { DefaultWorkstationDbName = data ; },
                                      Constants.DataBasesDefaultNames.Workstation ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.DefaultUserAccessDbName, 
                                      delegate ( string data ) { DefaultUserAccessDbName = data ; },
                                      Constants.DataBasesDefaultNames.User ) ;
                                      
            SetConfigValue <string> ( configReader, 
                                      Constants.EnabledDatabases, 
                                      delegate ( string data ) { EnabledDatabases = data ; },
                                      DatabaseComponents.StorageServer + ";" +
                                      DatabaseComponents.Logging.ToString ( ) + ";" + 
                                      DatabaseComponents.Storage + ";" +
                                      DatabaseComponents.Worklist + ";" +
                                      DatabaseComponents.MediaCreation + ";" +
                                      DatabaseComponents.Workstation + ";" +
                                      DatabaseComponents.UserManagement ) ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }

      private static void SetConfigValue <T> 
      ( 
         AppSettingsReader reader, 
         string key, 
         Action<T> method,
         T defaultValue 
      ) where T : class 
      {
         try
         {
            if ( ConfigurationManager.AppSettings.AllKeys.Contains ( key ) )
            {
               method ( reader.GetValue ( key, typeof (T) ) as T ) ;
            }
            else
            {
               method ( defaultValue ) ;
            }
         }
         catch 
         {
            method ( defaultValue ) ;
         }
      }
      
      public static bool IsDatabaseSupported ( DatabaseComponents database ) 
      {
         return true ;
      }
      
      public static string ApplicationName
      {
         get ;
         set ;
      }
      
      public static string DefaultProvider
      {
         get ;
         set ;
      }
      
      public static string SupportedProvider        
      {
         get ;
         set ;
      }
      
      public static bool AppendProcessType        
      {
         get ;
         set ;
      }

      public static string DefaultStorageServerDbName
      {
         get;
         set;
      }
      
      public static string DefaultLoggingDbName     
      {
         get ;
         set ;
      }
      
      public static string DefaultStorageDbName     
      {
         get ;
         set ;
      }
      
      public static string DefaultWorklistDbName
      {
         get ;
         set ;
      }
      
      public static string DefaultMediaCreationDbName
      {
         get ;
         set ;
      }
      public static string DefaultWorkstationDbName 
      {
         get ;
         set ;
      }
      
      public static string DefaultUserAccessDbName  
      {
         get ;
         set ;
      }
      
      public static string EnabledDatabases         
      {
         get ;
         set ;
      }
      
      public static SupportedProviders GetSupportedProvider ( ) 
      {
         try
         {
            if ( string.IsNullOrEmpty ( SupportedProvider ) )
            {
               return SupportedProviders.SqlClient | SupportedProviders.SqlServerCe ;
            }
            else
            {
               string []          providers ;
               SupportedProviders supported ;
               
               
               providers = SupportedProvider.Split ( ';' ) ;
               supported = SupportedProviders.None ;
               
               
               foreach ( string provider in providers )
               {
                  supported |= (SupportedProviders) Enum.Parse ( typeof (SupportedProviders), provider ) ;
               }
               
               return supported ;
            }
         }
         catch 
         {
            return SupportedProviders.SqlClient | SupportedProviders.SqlServerCe ;
         }
      }
      
      public static DatabaseComponents GetSupportedDatabase ( )
      {
         try
         {
            if ( string.IsNullOrEmpty ( EnabledDatabases ) )
            {
               return DatabaseComponents.None ;
            }
            else
            {
               DatabaseComponents supported ;
               string [] dbs ;
               
               
               dbs = EnabledDatabases.Split ( ';' ) ;
               supported = DatabaseComponents.None ;
               
               
               foreach ( string database in dbs )
               {
                  supported |= (DatabaseComponents) Enum.Parse ( typeof (DatabaseComponents), database ) ;
               }
               
               return supported ;
            }
         }
         catch 
         {
            return DatabaseComponents.None ;
         }
      }
      
      private static string __ApplicationIcon
      {
         get ;
         set ;
      }
      
      public static Icon ApplicationIcon
      {
         get 
         {
            if ( null == _appIcon ) 
            {
               if ( !string.IsNullOrEmpty ( __ApplicationIcon ) && File.Exists ( __ApplicationIcon ) )
               {
                  _appIcon = new Icon ( __ApplicationIcon ) ;
               }
               else 
               {
                  //_appIcon = CSPacsDatabaseConfigurationDemo.Properties.Resources.MedAddon ;
               }
            }
            
            return _appIcon ;
         }
         
         set 
         {
            _appIcon= value ;
         }
      }
      
      private static Icon _appIcon ;
      
      private class Constants
      {
         public const string ApplicationName            = "ApplicationName" ;
         public const string ApplicationIcon            = "ApplicationIcon" ;
         public const string DefaultProvider            = "DefaultProvider" ;
         public const string SupportedProvider          = "SupportedProvider" ;
         public const string AppendProcessType          = "AppendProcessType" ;
         public const string DefaultLoggingDbName       = "DefaultLoggingDbName" ;
         public const string DefaultStorageDbName       = "DefaultStorageDbName" ;
         public const string DefaultWorklistDbName      = "DefaultWorklistDbName" ;
         public const string DefaultMediaCreationDbName = "DefaultMediaCreationDbName" ;
         public const string DefaultWorkstationDbName   = "DefaultWorkstationDbName" ;
         public const string DefaultUserAccessDbName    = "DefaultUserAccessDbName" ;
         public const string EnabledDatabases           = "EnabledDatabases" ;
         public const string DefaultStorageServerDbName = "DefaultStorageServerDbName";
         
         public static class DataBasesDefaultNames
         {
#if LTV17_CONFIG
            public const string Logging     = "LeadDicomLogging" ;
            public const string Storage     = "LeadDicomStorage" ;
            public const string Worklist    = "LeadWorklist" ;
            public const string Media       = "LeadMediaCreation" ;
            public const string Workstation = "LeadWorkstation" ;
            public const string User        = "LeadUserAccess" ;
#endif
#if LTV175_CONFIG
            public const string Logging     = "LeadDicomLogging175" ;
            public const string Storage     = "LeadDicomStorage175" ;
            public const string Worklist    = "LeadWorklist175" ;
            public const string Media       = "LeadMediaCreation175" ;
            public const string Workstation = "LeadWorkstation175" ;
            public const string User        = "LeadUserAccess175" ;
            public const string StorageServer = "LeadStorageServer175";
#endif
#if LTV18_CONFIG
            public const string Logging     = "LeadDicomLogging18" ;
            public const string Storage     = "LeadDicomStorage18" ;
            public const string Worklist    = "LeadWorklist18" ;
            public const string Media       = "LeadMediaCreation18" ;
            public const string Workstation = "LeadWorkstation18" ;
            public const string User        = "LeadUserAccess18" ;
            public const string StorageServer = "LeadStorageServer18";
#endif
#if LTV19_CONFIG
            public const string Logging     = "LeadDicomLogging19" ;
            public const string Storage     = "LeadDicomStorage19" ;
            public const string Worklist    = "LeadWorklist19" ;
            public const string Media       = "LeadMediaCreation19" ;
            public const string Workstation = "LeadWorkstation19" ;
            public const string User        = "LeadUserAccess19" ;
            public const string StorageServer = "LeadStorageServer19";
#endif
#if LTV20_CONFIG
            public const string Logging     = "LeadDicomLogging20" ;
            public const string Storage     = "LeadDicomStorage20" ;
            public const string Worklist    = "LeadWorklist20" ;
            public const string Media       = "LeadMediaCreation20" ;
            public const string Workstation = "LeadWorkstation20" ;
            public const string User        = "LeadUserAccess20" ;
            public const string StorageServer = "LeadStorageServer20";
#endif
         }
      }
   }
   
      public class ConnectionProviders
      {
         public readonly static ConnectionProviders SqlServerProvider = new ConnectionProviders ( "System.Data.SqlClient" ) ;
         public readonly static ConnectionProviders SqlCeProvider     = new ConnectionProviders ( "Microsoft.SqlServerCe.Client.3.5" ) ;
         
         internal ConnectionProviders ( string name ) 
         {
            Name = name ;
         }
         
         public string Name
         {
            get ;
            private set ;
         }

         public override string ToString ( )
         {
             return Name ;
         }

         public override bool Equals(object obj)
         {
            if ( Object.Equals ( obj, null ) )
            {
               return false ;
            }
            
            if ( ! ( obj is ConnectionProviders ) )
            {
               return false ;
            }
            
            return ( string.Compare ( this.Name, ( (ConnectionProviders ) obj ).Name, false ) == 0 ) ;
         }

         public override int GetHashCode()
         {
            return base.GetHashCode();
         }
         
         public static ConnectionProviders[] FromProvider ( SupportedProviders provider ) 
         {
            List <ConnectionProviders> providers ;
            
            
            providers = new List<ConnectionProviders>( ) ;
            
            if ( ( provider & SupportedProviders.SqlClient ) == SupportedProviders.SqlClient )
            {
               providers.Add ( SqlServerProvider ) ;
            }
            
            if ( ( provider & SupportedProviders.SqlServerCe ) == SupportedProviders.SqlServerCe )
            {
               providers.Add ( SqlCeProvider ) ;
            }
            
            return providers.ToArray ( ) ;
         }
         
         public static ConnectionProviders Parse ( string provider ) 
         {
            if ( provider == SqlCeProvider.Name )
            {
               return SqlCeProvider ;
            }
            
            if ( provider == SqlServerProvider.Name )
            {
               return SqlServerProvider ;
            }
            
            return null ;
         }
      }
   
   [Flags]
   public enum DatabaseComponents
   {
      None = 0,
      Logging = 1,
      Storage  = 2,
      Worklist = 4,
      Workstation = 8,
      UserManagement = 16,
      MediaCreation = 32,
      StorageServer = 64,
   }
   
   [Flags]
   public enum SupportedProviders
   {
      None = 0,
      SqlServerCe = 1,
      SqlClient = 2
   }
}
