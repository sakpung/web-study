// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Medical.DataAccessLayer.Configuration;

using Leadtools.Medical.Media.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Winforms.DataAccessLayer.Configuration;
using Leadtools.Medical.Forward.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.Workstation.DataAccessLayer.Configuration;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration;

using Leadtools.Medical.Worklist.DataAccessLayer.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using Leadtools.Medical.ExportLayout.DataAccessLayer.Configuration;

namespace Leadtools.Demos.StorageServer.DataTypes
{
   public class GlobalPacsUpdater
   {
      static GlobalPacsUpdater ( ) 
      {
         _sectionToComponent.Add ( DicomDemoSettingsManager.StorageDataAccessConfiguration, VersionTable.Storage ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.UserManagementConfigurationSample, VersionTable.UserManagement ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.WorkListDataAccessConfiguration, VersionTable.Worklist ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.WorkstationDataAccessConfiguration, VersionTable.Workstation ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.AeManagementConfiguration, VersionTable.AeManagement ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.AePermissionManagementConfiguration, VersionTable.AePermissions ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.ForwardConfiguration, VersionTable.Forward ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.LoggingDataAccessConfiguration, VersionTable.Logging ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.MediaCreationDataAccessConfiguration, VersionTable.Media ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.OptionsConfiguration, VersionTable.Options ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.PermissionManagementConfiguration, VersionTable.Permissions ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.DownloadJobsConfiguration, VersionTable.JobsDownload ) ;
         _sectionToComponent.Add ( DicomDemoSettingsManager.PatientRightsConfiguration, VersionTable.PatientAccess ) ;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         _sectionToComponent.Add ( DicomDemoSettingsManager.ExternalStoreConfiguration, VersionTable.ExternalStore) ;
#endif

#if (LEADTOOLS_V20_OR_LATER)
         _sectionToComponent.Add(DicomDemoSettingsManager.ExportLayoutConfiguration, VersionTable.ExportLayout);
#endif 
      }

      static Dictionary<string,string> _sectionToComponent = new Dictionary<string,string> ( ) ;
      
      private static string[] _configSections = { DicomDemoSettingsManager.StorageDataAccessConfiguration,
                                                  DicomDemoSettingsManager.LoggingDataAccessConfiguration,
                                                  DicomDemoSettingsManager.MediaCreationDataAccessConfiguration,
                                                  DicomDemoSettingsManager.UserManagementConfigurationSample,
                                                  DicomDemoSettingsManager.WorkListDataAccessConfiguration,
                                                  DicomDemoSettingsManager.WorkstationDataAccessConfiguration,
                                                  DicomDemoSettingsManager.OptionsConfiguration,
                                                  DicomDemoSettingsManager.AeManagementConfiguration,
                                                  DicomDemoSettingsManager.AePermissionManagementConfiguration,
                                                  DicomDemoSettingsManager.PermissionManagementConfiguration,
                                                  DicomDemoSettingsManager.ForwardConfiguration,
                                                  DicomDemoSettingsManager.DownloadJobsConfiguration,
                                                  DicomDemoSettingsManager.PatientRightsConfiguration,
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                                                  DicomDemoSettingsManager.ExternalStoreConfiguration,
#endif
#if (LEADTOOLS_V20_OR_LATER)
                                                  DicomDemoSettingsManager.ExportLayoutConfiguration,
#endif
                                     };

      public static string[] _configSectionsStorageServer
                                              = { DicomDemoSettingsManager.StorageDataAccessConfiguration,
                                                  DicomDemoSettingsManager.LoggingDataAccessConfiguration,
                                                  DicomDemoSettingsManager.UserManagementConfigurationSample,
                                                  DicomDemoSettingsManager.OptionsConfiguration,
                                                  DicomDemoSettingsManager.AeManagementConfiguration,
                                                  DicomDemoSettingsManager.AePermissionManagementConfiguration,
                                                  DicomDemoSettingsManager.PermissionManagementConfiguration,
                                                  DicomDemoSettingsManager.ForwardConfiguration,
                                                  DicomDemoSettingsManager.DownloadJobsConfiguration,
                                                  DicomDemoSettingsManager.PatientRightsConfiguration,
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                                                  DicomDemoSettingsManager.ExternalStoreConfiguration,
#endif
#if (LEADTOOLS_V20_OR_LATER)
                                                  DicomDemoSettingsManager.ExportLayoutConfiguration,
#endif
                                     };
                                     
public static string[] _configSectionsWorkstation
                                              = { /**/"storageDataAccessConfiguration175",
                                                  /**/"loggingDataAccessConfiguration175",
                                                  /**/"mediaCreationDataAccessConfiguration175",
                                                  /**/"userManagementConfigurationSample175",
                                                  // "workListDataAccessConfiguration175",
                                                  /**/"workstationDataAccessConfiguration175",
#if (LEADTOOLS_V19_OR_LATER)
                                                  "optionsConfiguration175",
#endif
                                                  // "aeManagementConfiguration175",
                                                  // "aePermissionManagementConfiguration175",
                                                  // "permissionManagementConfiguration175",
                                                  // "forwardConfiguration175",
                                     };
                                     
     public static string[] _configSectionsDemoServer
                                              = { //"storageDataAccessConfiguration175",
                                                  //"loggingDataAccessConfiguration175",
                                                  //"mediaCreationDataAccessConfiguration175",
                                                  //"userManagementConfigurationSample175",
                                                  /**/ "workListDataAccessConfiguration175",
                                                  //"workstationDataAccessConfiguration175",
                                                  // "optionsConfiguration175",
                                                  // "aeManagementConfiguration175",
                                                  // "aePermissionManagementConfiguration175",
                                                  // "permissionManagementConfiguration175",
                                                  // "forwardConfiguration175",
                                     };

      public static void ModifyGlobalPacsConfiguration ( string productName, string serviceName, ModifyConfigurationType changeType )
      {
         string newServiceName = serviceName ;
         
         if ( changeType == ModifyConfigurationType.Remove )
         {
            newServiceName = string.Empty;
         }

         Configuration config = DicomDemoSettingsManager.GetGlobalPacsConfiguration ( ) ;
         
         string[] configSections = null;
         if (productName == DicomDemoSettingsManager.ProductNameWorkstation)
         {
            configSections = _configSectionsWorkstation;
         }
         else if (productName == DicomDemoSettingsManager.ProductNameStorageServer)
         {
            configSections = _configSectionsStorageServer;
         }
         else if (productName == DicomDemoSettingsManager.ProductNameGateway)
         {
            configSections = _configSectionsStorageServer;
         }
         else if (productName == DicomDemoSettingsManager.ProductNameDemoServer)
         {
            configSections = _configSectionsDemoServer;
         }
         
         if (configSections != null)
         {
            foreach (string name in configSections)
            {
               DataAccessSettings dataAccessSettings = config.GetSection(name) as DataAccessSettings;

               if (dataAccessSettings != null)
               {
                  bool found = false;
                  ConnectionElement StorageServerConnection = null;

                  for (int i = dataAccessSettings.Connections.Count - 1; i >= 0; i--)
                  {
                     ConnectionElement connectionElement = dataAccessSettings.Connections[i];

                     if (connectionElement.ProductName == DicomDemoSettingsManager.ProductNameStorageServer)
                     {
                        StorageServerConnection = connectionElement;
                     }

                     if (connectionElement.ProductName == productName)
                     {
                        connectionElement.ServiceName = newServiceName;

                        found = true;

                        break;
                     }
                  }

                  // Add any gateway configuration (from the storage server)to globalpacs.config
                  if ((productName == DicomDemoSettingsManager.ProductNameGateway) && !found && changeType == ModifyConfigurationType.Add)
                  {
                     if (null != StorageServerConnection)
                     {
                        ConnectionElement connection = new ConnectionElement();

                        connection.ProductName = productName;
                        connection.ServiceName = serviceName;
                        connection.ConnectionName = StorageServerConnection.ConnectionName;

                        dataAccessSettings.Connections.Add(connection);
                     }
                  }
               }
            }
         }
         
         config.Save ( ConfigurationSaveMode.Minimal ) ;
      }
   
      
      public enum ModifyConfigurationType
      {
         Remove = 0,
         Add = 1,
      }

      public static string BackupFile(string filePath)
      {
         string backupFileName = string.Empty;
         if (File.Exists(filePath))
         {
            backupFileName = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath));

            backupFileName += Path.ChangeExtension(" - " + DateTime.Now.ToString("MM-dd-yy HH#mm"), Path.GetExtension(filePath));

            File.Copy(filePath, backupFileName, true);
         }
         return backupFileName;
      }
      
       private static string GetVersionFromSection(string sSection)
      {
         string version = string.Empty;
         Match match = Regex.Match(sSection, @"Version=[0-9.]+", RegexOptions.IgnoreCase);
         if (match != null && match.Success)
         {
            if (string.IsNullOrEmpty(version))
            {
               version = match.Groups[0].Value;
            }
         }
         return version;
      }

      public static void AddVersion(List<string> versions, IEnumerable<XElement> query)
      {
         foreach (XElement section in query)
         {
            XAttribute att = section.Attribute("type");

            string sType = att.Value;
            if (sType.Contains("Version"))
            {
               string version = GetVersionFromSection(sType);
               if (!string.IsNullOrEmpty(version))
               {
                  if (!versions.Contains(version))
                  {
                     versions.Add(version);
                  }
               }
            }
         }
      }

      public static List<string> GetServiceAdvancedConfigReferencedToolkitVersion(string configFile)
      {
         List<string> versions = new List<string>();

         try
         {
            IEnumerable<XElement> query;
            XDocument xmlFile = XDocument.Load(configFile);

            // serverConfig:      Leadtools.Dicom.AddIn
            query =
               from el in xmlFile.Elements("configuration").Elements("configSections").Elements("section")
               where (string)el.Attribute("name") == "serverConfig"
               select el;
            AddVersion(versions, query);

            // Addins
            query =
               from el in xmlFile.Elements("configuration").Elements("advancedSettings").Elements("addins").Elements("addin")
               select el;

            foreach (XElement section in query)
            {
               IEnumerable<XElement> temp = from el in section.Elements("customData").Elements("custom")
                                            select el;

               AddVersion(versions, temp);
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }

         return versions;
      }

      
      public static bool GetGlobalPacsConfigReferencedToolkitVersion(string globalPacsConfig, out string version)
      {
         bool allVersionsEqual = true;
         version = string.Empty;

         try
         {
            XDocument xmlFile = XDocument.Load(globalPacsConfig);

            var query = from c in xmlFile.Elements("configuration").Elements("configSections").Elements("section") select c;

            foreach (XElement section in query)
            {
               XAttribute att = section.Attribute("type");

               string sType = att.Value;
               if (sType.Contains("Leadtools.Medical.DataAccessLayer") && sType.Contains("Version"))
               {
                  Match match = Regex.Match(sType, @"Version=[0-9.]+", RegexOptions.IgnoreCase);
                  if (match != null && match.Success)
                  {
                     if (string.IsNullOrEmpty(version))
                     {
                        version = match.Groups[0].Value;
                     }
                     else
                     {
                        allVersionsEqual = allVersionsEqual && (string.Compare(version, match.Groups[0].Value, true) == 0);
                     }
                  }
               }
            }
         }
         catch (Exception)
         {
            allVersionsEqual = false;
         }

         if (allVersionsEqual == false)
         {
            version = string.Empty;
         }

         version = version.Replace("Version=", string.Empty);
         return allVersionsEqual;
      }

      
      public static string[] GetGlobalPacsConfigAllReferencedToolkitVersion(string globalPacsConfig)
      {
         List<string> allVersions = new List<string>();

         try
         {
            XDocument xmlFile = XDocument.Load(globalPacsConfig);

            var query = from c in xmlFile.Elements("configuration").Elements("configSections").Elements("section") select c;

            foreach (XElement section in query)
            {
               XAttribute att = section.Attribute("type");

               string sType = att.Value;
               if (sType.Contains("Leadtools.Medical.DataAccessLayer") && sType.Contains("Version"))
               {
                  Match match = Regex.Match(sType, @"Version=[0-9.]+", RegexOptions.IgnoreCase);
                  if (match != null && match.Success)
                  {
                     string version = match.Groups[0].Value;
                     if (!string.IsNullOrEmpty(version))
                     {
                        version = version.Replace("Version=", string.Empty);
                        if (!allVersions.Contains(version))
                        {
                           allVersions.Add(version);
                        }
                     }
                  }
               }
            }
         }
         catch (Exception)
         {
            // allVersionsEqual = false;
         }
         return allVersions.ToArray();
      }


      public static bool UpdateGlobalPacsConfigReferencedToolkitVersion(string globalPacsConfig, string oldVersion, string newVersion)
      {
         bool ret = false;
         
         oldVersion = "Version=" + oldVersion;
         newVersion = "Version=" +newVersion;

         try
         {
            XDocument xmlFile = XDocument.Load(globalPacsConfig);

            var query = from c in xmlFile.Elements("configuration").Elements("configSections").Elements("section") select c;

            foreach (XElement section in query)
            {
               XAttribute att = section.Attribute("type");

               string sType = att.Value;
               if (sType.Contains("Leadtools.Medical.DataAccessLayer") && sType.Contains(oldVersion))
               {
                  sType = sType.Replace(oldVersion, newVersion);

                  att.Value = sType;
               }
               Console.WriteLine(att);
               // section.Attribute("Version").Value = "MyNewValue";
            }

            xmlFile.Save(globalPacsConfig);
         }
         catch (Exception )
         {
            ret = false;
         }
         return ret;
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      // returns true if needs to be updated
      //
      public static bool AddExternalStoreToGlobalPacsConfig(string globalPacsConfig, bool overwriteExisting)
      {
         XElement sectionForward = null;
         XElement sectionExternalStore = null;
         XElement sectionStorage = null;
         bool ret = true;
         try
         {
            XDocument xmlFile = XDocument.Load(globalPacsConfig);
            var query = from c in xmlFile.Elements("configuration").Elements("configSections").Elements("section") select c;

            foreach (XElement section in query)
            {
               XAttribute att = section.Attribute("name");
               string sName = att.Value;

               if (sName == DicomDemoSettingsManager.StorageDataAccessConfiguration)
               {
                  sectionStorage = section;
               }

               else if (sName == DicomDemoSettingsManager.ForwardConfiguration)
               {
                  sectionForward = section;
               }

               else if (sName == DicomDemoSettingsManager.ExternalStoreConfiguration)
               {
                  sectionExternalStore = section;
               }
            }

            // if sectionExternalStore already exists, then no need to upgrade
            if (sectionExternalStore != null)
            {
               return false;
            }

            if (sectionForward == null)
            {
               return false;
            }

            sectionExternalStore = new XElement(sectionStorage);
            sectionExternalStore.Attribute("name").Value = DicomDemoSettingsManager.ExternalStoreConfiguration;
            sectionForward.AddBeforeSelf(sectionExternalStore);


            XElement forwardElement = xmlFile.Element("configuration").Element(DicomDemoSettingsManager.ForwardConfiguration);
            XElement storageElement = xmlFile.Element("configuration").Element(DicomDemoSettingsManager.StorageDataAccessConfiguration);

            if (forwardElement == null || storageElement == null)
            {
               return false;
            }

            XElement externalStoreElement = new XElement(storageElement);
            externalStoreElement.Name = DicomDemoSettingsManager.ExternalStoreConfiguration;
            forwardElement.AddBeforeSelf(externalStoreElement);

            if (overwriteExisting)
            {
               xmlFile.Save(globalPacsConfig);
            }

         }
         catch (Exception)
         {
            ret = false;
         }

         return ret;
      }

      public static bool AddExportLayoutToGlobalPacsConfig(string globalPacsConfig, bool overwriteExisting)
      {
         XElement sectionForward = null;
         XElement sectionExportLayout = null;
         XElement sectionStorage = null;
         bool ret = true;
         try
         {
            XDocument xmlFile = XDocument.Load(globalPacsConfig);
            var query = from c in xmlFile.Elements("configuration").Elements("configSections").Elements("section") select c;

            foreach (XElement section in query)
            {
               XAttribute att = section.Attribute("name");
               string sName = att.Value;

               if (sName == DicomDemoSettingsManager.StorageDataAccessConfiguration)
               {
                  sectionStorage = section;
               }

               else if (sName == DicomDemoSettingsManager.ForwardConfiguration)
               {
                  sectionForward = section;
               }

               else if (sName == DicomDemoSettingsManager.ExportLayoutConfiguration)
               {
                  sectionExportLayout = section;
               }
            }

            // if sectionExportLayout already exists, then no need to upgrade
            if (sectionExportLayout != null)
            {
               return false;
            }

            if (sectionForward == null)
            {
               return false;
            }

            sectionExportLayout = new XElement(sectionStorage);
            sectionExportLayout.Attribute("name").Value = DicomDemoSettingsManager.ExportLayoutConfiguration;
            sectionForward.AddBeforeSelf(sectionExportLayout);


            XElement forwardElement = xmlFile.Element("configuration").Element(DicomDemoSettingsManager.ForwardConfiguration);
            XElement storageElement = xmlFile.Element("configuration").Element(DicomDemoSettingsManager.StorageDataAccessConfiguration);

            if (forwardElement == null || storageElement == null)
            {
               return false;
            }

            XElement exportLayoutElement = new XElement(storageElement);
            exportLayoutElement.Name = DicomDemoSettingsManager.ExportLayoutConfiguration;
            forwardElement.AddBeforeSelf(exportLayoutElement);

            if (overwriteExisting)
            {
               xmlFile.Save(globalPacsConfig);
            }

         }
         catch (Exception)
         {
            ret = false;
         }

         return ret;
      }

      public static bool AddOptionsToGlobalPacsConfig(string globalPacsConfig, bool overwriteExisting)
      {
         XElement elementStorageAddWorkstation = null;
         XElement elementOptionsAddWorkstation = null;
         bool ret = true;
         try
         {
            XDocument xmlFile = XDocument.Load(globalPacsConfig);

            var query = from c in xmlFile.Elements("configuration").Elements(DicomDemoSettingsManager.StorageDataAccessConfiguration).Elements("add") select c;

            foreach (XElement storageAdd in query)
            {
               XAttribute att = storageAdd.Attribute("productName");
               string sProductName = string.Empty;

               if (att != null)
               {
                  sProductName = att.Value;
               }

               if (sProductName == DicomDemoSettingsManager.ProductNameWorkstation)
               {
                  elementStorageAddWorkstation = storageAdd;
               }
            }

            // Workstation has not been configured (storage data access layer) has not been configured
            if (elementStorageAddWorkstation == null)
            {
               return false;
            }

            query = from c in xmlFile.Elements("configuration").Elements(DicomDemoSettingsManager.OptionsConfiguration).Elements("add") select c;

            foreach (XElement optionsAdd in query)
            {
               XAttribute att = optionsAdd.Attribute("productName");
               string sProductName = string.Empty;

               if (att != null)
               {
                  sProductName = att.Value;
               }

               if (sProductName == DicomDemoSettingsManager.ProductNameWorkstation)
               {
                  elementOptionsAddWorkstation = optionsAdd;
               }
            }

            if (elementOptionsAddWorkstation != null)
            {
               // Options->Workstation already exists -- no need to upgrade
               return false;
            }

            XElement optionsConfiguration175 = xmlFile.Element("configuration").Element(DicomDemoSettingsManager.OptionsConfiguration);
            if (optionsConfiguration175 == null)
            {
               return false;
            }

            optionsConfiguration175.Add(elementStorageAddWorkstation);

            if (overwriteExisting)
            {
               xmlFile.Save(globalPacsConfig);
            }

         }
         catch (Exception)
         {
            ret = false;
         }

         return ret;
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

      public static bool UpdateServiceAdvancedConfigReferencedToolkitVersion(string configFile, string oldVersion, string newVersion)
      {
         bool ret = false;

         oldVersion = "Version=" + oldVersion;
         newVersion = "Version=" + newVersion;

         try
         {
            string text = File.ReadAllText(configFile);
            text = text.Replace(oldVersion, newVersion);

            File.WriteAllText(configFile, text);
            ret = true;
         }
         catch (Exception /*ex*/)
         {
            ret = false;
         }

         return ret;
      }

      private static bool InternalIsExportDataAccessLayerValid(System.Configuration.Configuration globalPacsConfig)
      {
         ExportLayoutDataAccessConfigurationView storageServerExportLayoutConfig = new ExportLayoutDataAccessConfigurationView(globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         bool isValid = IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerExportLayoutConfig.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer);
         return isValid;
      }

      private static bool IsExportLayoutDataAccessAssemblyPresent()
      {
         string exeFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
         string pathName = Path.Combine(exeFolder, @"Leadtools.Medical.ExportLayout.DataAccessLayer.dll");
         bool isPresent = File.Exists(pathName);

         return isPresent;
      }

      private static bool IsExportDataAccessLayerValid(System.Configuration.Configuration globalPacsConfig)
      {
         bool isValid = true;
         if (IsExportLayoutDataAccessAssemblyPresent())
         {
            isValid = InternalIsExportDataAccessLayerValid(globalPacsConfig);
         }
         return isValid;
      }

      public static bool IsDbComponentsConfigured(string[] pacsProductsArray, out string missingDbComponents)
      {
         missingDbComponents = string.Empty;

         if ((pacsProductsArray == null) || (pacsProductsArray.Length == 0))
            return true;

         bool bCheckStorageServer = false;
         bool bCheckWorkstation = false;
         bool bCheckDemoServer = false;

         foreach (string product in pacsProductsArray)
         {
            if (string.Compare(product, DicomDemoSettingsManager.ProductNameDemoServer, true) == 0)
               bCheckDemoServer = true;
            else if (string.Compare(product, DicomDemoSettingsManager.ProductNameStorageServer, true) == 0)
               bCheckStorageServer = true;
            else if (string.Compare(product, DicomDemoSettingsManager.ProductNameWorkstation, true) == 0)
               bCheckWorkstation = true;
         }

         // Storage Server databases
         AeManagementDataAccessConfigurationView            storageServerAeManagementConfig;
         AePermissionManagementDataAccessConfigurationView  storageServerAePermissionManagementView;
         ForwardDataAccessConfigurationView                 storageServerForwardView;
         OptionsDataAccessConfigurationView                 storageServerOptionsView;
         PermissionManagementDataAccessConfigurationView    storageServerPermissionView;
         LoggingDataAccessConfigurationView                 storageServerLoggingConfig;
         StorageDataAccessConfigurationView                 storageServerStorageConfig;
         UserManagementDataAccessConfigurationView          storageServerUserManagConfig;
         // ExportLayoutDataAccessConfigurationView            storageServerExportLayoutConfig;


         // Workstation specific databases
         WorkstationDataAccessConfigurationView workstationConfig;
         MediaCreationDataAccessConfigurationView           workstationMediaConfig;
         LoggingDataAccessConfigurationView                 workstationLoggingConfig;
         StorageDataAccessConfigurationView                 workstationStorageConfig;
         UserManagementDataAccessConfigurationView          workstationUserManagConfig;

#if (LEADTOOLS_V19_OR_LATER)
         OptionsDataAccessConfigurationView                 workstationOptionsConfig;
#endif 
         
         // Worklist
         WorklistDataAccessConfigurationView                worklistConfig;


         //// Common databases (Storage Server, Demo, Workstation)
         //LoggingDataAccessConfigurationView loggingConfig;
         //StorageDataAccessConfigurationView storageConfig;
         //UserManagementDataAccessConfigurationView userManagConfig;

         
         ConfigurationManager.RefreshSection("configuration");


         System.Configuration.Configuration globalPacsConfig = DicomDemoSettingsManager.GetGlobalPacsConfiguration();


         // Storage Server Databases
         storageServerAeManagementConfig            = new AeManagementDataAccessConfigurationView            (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         storageServerAePermissionManagementView    = new AePermissionManagementDataAccessConfigurationView  (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         storageServerForwardView                   = new ForwardDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         storageServerOptionsView                   = new OptionsDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         storageServerPermissionView                = new PermissionManagementDataAccessConfigurationView    (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         storageServerLoggingConfig                 = new LoggingDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         storageServerStorageConfig                 = new StorageDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         storageServerUserManagConfig               = new UserManagementDataAccessConfigurationView          (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         // storageServerExportLayoutConfig            = new ExportLayoutDataAccessConfigurationView            (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);


         // Workstation databases
         workstationConfig = new WorkstationDataAccessConfigurationView             (globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, null);
         workstationMediaConfig                     = new MediaCreationDataAccessConfigurationView           (globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, null);
         workstationLoggingConfig                   = new LoggingDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, null);
         workstationStorageConfig                   = new StorageDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, null);
         workstationUserManagConfig                 = new UserManagementDataAccessConfigurationView          (globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, null);
#if (LEADTOOLS_V19_OR_LATER)
         workstationOptionsConfig                   = new OptionsDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, null);
#endif
         // Worklist database
         worklistConfig                            = new WorklistDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameDemoServer, null);

         //// Common databases (Storage Server, Demo, Workstation)
         //loggingConfig                 = new LoggingDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         //storageConfig                 = new StorageDataAccessConfigurationView                 (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);
         //userManagConfig               = new UserManagementDataAccessConfigurationView          (globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, null);


         if (bCheckStorageServer)
         {
            // Check the LEAD Storage Server database (GlobalPacsConfig)
            bool invalid = (
                  // Storage Server Databases
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerAeManagementConfig.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerAePermissionManagementView.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerForwardView.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerOptionsView.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerPermissionView.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer) ||

                  // Common databases (Storage Server, Demo, Workstation)
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerLoggingConfig.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerStorageConfig.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, storageServerUserManagConfig.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer));

            // invalid = invalid || !IsExportDataAccessLayerValid(globalPacsConfig);
            if (invalid)
            {
               missingDbComponents += "* LEAD Storage Server Database.\n";
            }
         }

         if (bCheckWorkstation)
         {
            // Check the Workstation database (GlobalPacsConfig)
            if (
               // Storage Server Databases
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, workstationConfig.DataAccessSettingsSectionName,                       DicomDemoSettingsManager.ProductNameWorkstation) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, workstationMediaConfig.DataAccessSettingsSectionName,                  DicomDemoSettingsManager.ProductNameWorkstation) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, workstationLoggingConfig.DataAccessSettingsSectionName,                DicomDemoSettingsManager.ProductNameWorkstation) ||
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, workstationStorageConfig.DataAccessSettingsSectionName,                DicomDemoSettingsManager.ProductNameWorkstation) ||
#if (LEADTOOLS_V19_OR_LATER)
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, workstationOptionsConfig.DataAccessSettingsSectionName,                DicomDemoSettingsManager.ProductNameWorkstation) ||
#endif
                  !IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig, workstationUserManagConfig.DataAccessSettingsSectionName,              DicomDemoSettingsManager.ProductNameWorkstation) 
            )
            {
               missingDbComponents += "* Medical Workstation Database.\n";
            }
         }

         if (bCheckDemoServer)
         {
            // Check other databases (machineConfig)
            if (!IsDataAccessSettingsValidGlobalPacsConfig(globalPacsConfig,  worklistConfig.DataAccessSettingsSectionName,                           DicomDemoSettingsManager.ProductNameDemoServer))
            {
               missingDbComponents += "* DICOM Worklist Database.\n";
            }
         }

         return (missingDbComponents == string.Empty);
      }
      
      public static bool IsDataAccessSettingsValid(
         Configuration pacsConfig,
         string sectionName,
         string productName
      )
      {
         return IsDataAccessSettingsValidGlobalPacsConfig(pacsConfig, sectionName, productName) || IsDataAccessSettingsValidMachineConfig(sectionName);
      }

      public static bool IsProductDatabaseUpTodate ( string productName ) 
      {
         Dictionary<string,Version> componentsToUpgrade = GetComponentsToUpgrade ( productName ) ;
         
         return ( null == componentsToUpgrade ) || ( componentsToUpgrade.Count == 0 ) ;
      }
      
      public static Dictionary<string,Version> GetComponentsToUpgrade ( string productName )
      {
         return GetComponentsToUpgrade ( GetProductConnections ( productName ) ) ;
      }
      
      private static Dictionary<string, ConnectionStringSettings> GetProductConnections ( string productName ) 
      {
         System.Configuration.Configuration config = DicomDemoSettingsManager.GetGlobalPacsConfiguration ( ) ;
         
         Dictionary<string, ConnectionStringSettings> productConnections = null;
         
         switch ( productName )
         {
            case DicomDemoSettingsManager.ProductNameGateway:
            case DicomDemoSettingsManager.ProductNamePatientUpdater:
            case DicomDemoSettingsManager.ProductNameStorageServer:
            {
               productConnections = GetStorageServerSections(productName, config);
            }
            break ;
            
            case DicomDemoSettingsManager.ProductNameWorkstation:
            {
               productConnections = GetWorkstationSections(productName, config);
            }
            break ;
            
            case DicomDemoSettingsManager.ProductNameDemoServer:
            {
               productConnections = GetWorklistSections(productName, config);
            }
            break ;
         }
         
         return productConnections;
      }
      
      private static Dictionary<string, ConnectionStringSettings> GetWorklistSections(string productName, System.Configuration.Configuration config)
      {
         Dictionary<string, ConnectionStringSettings> productConnections;
         string[] worklistSections = GlobalPacsUpdater._configSectionsDemoServer;
         productConnections = GetProductConnections(config, productName, worklistSections);
         return productConnections;
      }

      private static Dictionary<string, ConnectionStringSettings> GetWorkstationSections(string productName, System.Configuration.Configuration config)
      {
         Dictionary<string, ConnectionStringSettings> productConnections;
         string[] workstationSections = _configSectionsWorkstation;

         // workstationSections = workstationSections.Where(n => n != "loggingDataAccessConfiguration175").ToArray(); //we don't want to upgrade the logging database YET. 
         productConnections = GetProductConnections(config, productName, workstationSections);
         return productConnections;
      }

      private static Dictionary<string, ConnectionStringSettings> GetStorageServerSections(string productName, System.Configuration.Configuration config)
      {
         Dictionary<string, ConnectionStringSettings> productConnections;
         string[] storageServerSections = _configSectionsStorageServer;

         productConnections = GetProductConnections(config, productName, storageServerSections);
         return productConnections;
      }

      public static Dictionary<string,Version> GetComponentsToUpgrade ( Dictionary<string, ConnectionStringSettings> productConnections )
      {
         if (productConnections == null || productConnections.Count == 0)
         {
            return null;
         }
         else
         {
            Dictionary<string,Version> componentsToUpgrade = new Dictionary<string,Version> ( ) ;
            
            foreach (KeyValuePair<string, ConnectionStringSettings> componentConnection in productConnections)
            {
               Version currentComponentVersion = SqlDbUpgrader.GetVersion (componentConnection.Key, componentConnection.Value);
               Version[] versions = VersionTable.Instance[componentConnection.Key];

               if (null != versions && versions.Length > 0)
               {
                  if (versions[versions.Length - 1] > currentComponentVersion)
                  {
                     componentsToUpgrade.Add(componentConnection.Key, currentComponentVersion);
                  }
               }
            }
         
            return componentsToUpgrade ;
         }
      }
      
      public static void UpgradeProductDatabase ( string productName ) 
      {
         Dictionary <string, Version> componentsToUpgrade = GetComponentsToUpgrade ( productName ) ;
         Dictionary<string, ConnectionStringSettings> componentConnections = GetProductConnections ( productName ) ;
         
         foreach ( KeyValuePair<string, Version> componentUpgrade in componentsToUpgrade ) 
         {
            SqlDbUpgrader.Upgrade ( componentUpgrade.Key, componentUpgrade.Value, componentConnections [ componentUpgrade.Key ] ) ;
         }
      }

      private static Dictionary<string, ConnectionStringSettings> GetProductConnections( Configuration config, string productName, string[] configSections)
      {
         Dictionary<string, ConnectionStringSettings> productConnections = new Dictionary<string, ConnectionStringSettings>();
         
         foreach (string section in configSections)
         {
            DataAccessSettings configSection = config.GetSection(section) as DataAccessSettings;

            if (null != configSection)
            {
               foreach (ConnectionElement connectionElement in configSection.Connections)
               {
                  if (connectionElement.ProductName == productName )
                  {
                     string component = _sectionToComponent[section];

                     productConnections.Add(component, config.ConnectionStrings.ConnectionStrings[connectionElement.ConnectionName]);

                     break;
                  }
               }
            }
         }
         
         return productConnections ;
      }
      
      private static bool IsDataAccessSettingsValidGlobalPacsConfig
      (
         Configuration pacsConfig,
         string sectionName,
         string productName
      )
      {
         DataAccessSettings settings = null;
         ConnectionStringSettings connectionStringSettings = null;
         try
         {
            settings = pacsConfig.GetSection(sectionName) as DataAccessSettings;
            if (settings != null)
            {
               bool found = false;
               string name = string.Empty;

               if (productName != DicomDemoSettingsManager.ProductNameStorageServer && productName != DicomDemoSettingsManager.ProductNameWorkstation && productName != DicomDemoSettingsManager.ProductNameDemoServer)
               {
                  name = settings.ConnectionName;
                  found = true;
               }
               else
               {
                  foreach (ConnectionElement connectionElement in settings.Connections)
                  {
                     if (connectionElement.ProductName == productName)
                     {
                        name = connectionElement.ConnectionName;
                        found = true;
                        break;
                     }
                  }
               }

               if (found && !string.IsNullOrEmpty(name))
               {
                  ConnectionStringsSection connectionStringsSection = pacsConfig.ConnectionStrings;
                  connectionStringSettings = connectionStringsSection.ConnectionStrings[name];
               }
            }

         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.InnerException.ToString(), MessageBoxButtons.OK);
            // Messager.Show(this, ex, System.Windows.Forms.MessageBoxIcon.Error);
            // return null;
         }

         return connectionStringSettings != null;
      }

      private static bool IsDataAccessSettingsValidMachineConfig(string sectionName)
      {
         ConfigurationManager.RefreshSection(sectionName);
         ConfigurationManager.RefreshSection("connectionStrings");

         DataAccessSettings section = null;

         try
         {
            section = ConfigurationManager.GetSection(sectionName) as DataAccessSettings;
         }
         catch (Exception)
         {
         }

         if (null != section)
         {
            ConnectionStringSettings connectionSettings;
            connectionSettings = ConfigurationManager.ConnectionStrings[section.ConnectionName];

            if (null != connectionSettings)
            {
               return true;
            }
         }

         return false;
      }
      
      sealed class VersionTable
      {
         private VersionTable ( ) 
         {
            _componentsVersion = new Dictionary<string,Version[]> (10) ;
            
            // Logging
            _componentsVersion.Add ( Logging, new Version[] { new Version (1,0), new Version (1,5), new Version(1, 6) } );

            // Storage
            _componentsVersion.Add ( Storage, new Version[] { new Version (1,0), new Version (1,5), new Version (1,6)
#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V18_OR_LATER)
            , new Version(1,7)
#endif
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
            , new Version(1,8)
#endif
#if LEADTOOLS_V19_OR_LATER
            , new Version(1,9)
            , new Version(1,10)
            , new Version(1,11)
#if (LEADTOOLS_V20_OR_LATER)
            , new Version(1,12)
            , new Version(1,13)
#endif
#endif
            });
            
            // Worklist
            _componentsVersion.Add ( Worklist, new Version[] { new Version (1,0), new Version(1, 1)} );

            // Media
            _componentsVersion.Add ( Media, new Version[] { new Version (1,0), new Version(1, 1) } );

            // UserManagement
            _componentsVersion.Add ( UserManagement, new Version[]
                                                        {
                                                           new Version (1,0)
#if LEADTOOLS_V19_OR_LATER
            , new Version(1,1)
#endif
#if LEADTOOLS_V20_OR_LATER
            , new Version(1,2)
            , new Version(1,3)
            , new Version(1,4)
#endif
                                                        } );

            // Workstation
            _componentsVersion.Add ( Workstation, new Version[] { new Version (1,0)} );

            // AeManagement
            _componentsVersion.Add ( AeManagement, new Version[] { new Version (1,0)  
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
            , new Version(1,1)
#endif    
#if (LEADTOOLS_V20_OR_LATER)
            , new Version(1,2)
            , new Version(1,3)
            , new Version(1,4)
#endif  
            });

            // Forward
            _componentsVersion.Add ( Forward, new Version[] { new Version (1,0)} );

            // Options
            _componentsVersion.Add ( Options, new Version[] { new Version (1,0)
#if (LEADTOOLS_V19_OR_LATER)
, new Version (1,1)
#endif 

#if (LEADTOOLS_V20_OR_LATER)
, new Version (1,2)
#endif 
});
            // AePermissions
            _componentsVersion.Add ( AePermissions, new Version[] { new Version (1,0)} );

            // Permissions
            _componentsVersion.Add ( Permissions, new Version[] { new Version (1,0), new Version (1,6)} );

            //JobsDownload
            _componentsVersion.Add ( JobsDownload, new Version[] { new Version (1,0)
#if (LEADTOOLS_V20_OR_LATER)
, new Version(1, 1) 
#endif 
} );

            // PatientAccess
            _componentsVersion.Add ( PatientAccess, new Version[] { new Version (1,0)} );

            // ExportLayout
            _componentsVersion.Add(ExportLayout, new Version[] { new Version(1, 0), new Version(1,1) });

         }
         
         static VersionTable ( ) 
         {
            _instance = new VersionTable ( ) ;
         }
         
         public static VersionTable Instance
         {
            get
            {
               return _instance ;
            }
         }
         
         public Version[] this[string key]
         {
            get
            {
               if ( _componentsVersion.ContainsKey (key))
               {
                  return _componentsVersion[key];
               }
               
               return null ;
            }
         }
         
         public const string Version               = "DbVersion";
         public const string Logging               = "Logging" ;
         public const string Storage               = "Storage" ;
         public const string Worklist              = "Worklist" ;
         public const string Media                 = "Media" ;
         public const string UserManagement        = "UserManagement";
         public const string Workstation           = "Workstation" ;
         public const string AeManagement          = "AeManagement";
         public const string Forward               = "Forward";
         public const string Options               = "Options";
         public const string MedicalWorkstation    = "MedicalWorkstation";
         public const string AePermissions         = "AePermissions";
         public const string Permissions           = "Permissions";
         
         public const string JobsDownload          = "JobsDownload";
         public const string PatientAccess         = "PatientAccess";
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         public const string ExternalStore         = "ExternalStore";
#endif

#if (LEADTOOLS_V20_OR_LATER)
         public const string ExportLayout           = "ExportLayout";
#endif

         private static VersionTable _instance ;
         
         private Dictionary<string, Version[]> _componentsVersion ;
      }
   
      abstract class SqlDbUpgrader
      {
         static SqlDbUpgrader ( ) 
         {
            {
               _sqlServerComponentToVersionScripts = new Dictionary<string,Dictionary<Version,string[]>> ( ) ;
               
               {//Logging 
                  Dictionary <Version,string[]> loggingScripts = new Dictionary<Version,string[]> ( ) ;
                  loggingScripts.Add ( new Version (1,0), new string[0]);//Create
                  loggingScripts.Add(new Version(1, 5), new string[] { _SqlServerScripts.Logging1_5x1, _SqlServerScripts.Logging1_5x2 });//Create
#if (LEADTOOLS_V20_OR_LATER)
                  loggingScripts.Add(new Version(1, 6), new string[] { _SqlServerScripts.Logging1_6x1, _SqlServerScripts.Logging1_6x1 });
#endif
                  _sqlServerComponentToVersionScripts.Add ( VersionTable.Logging, loggingScripts ) ;
               }
               
               {//Storage
                  Dictionary <Version,string[]> storageScripts = new Dictionary<Version,string[]> ( ) ;
                  storageScripts.Add ( new Version (1,0), new string[0]);//Create
                  storageScripts.Add ( new Version (1,5), new string[] {_SqlServerScripts.Storage1_5x1,_SqlServerScripts.Storage1_5x2,_SqlServerScripts.Storage1_5x3});
                  storageScripts.Add ( new Version (1,6), new string[] {_SqlServerScripts.Storage1_6x1});
#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V18_OR_LATER)
                  storageScripts.Add ( new Version (1,7), new string[] {_SqlServerScripts.Storage1_7x1});
#endif

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                  storageScripts.Add ( new Version (1,8), new string[] {_SqlServerScripts.Storage1_8x1, _SqlServerScripts.Storage1_8x2});
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
#if LEADTOOLS_V19_OR_LATER
                  storageScripts.Add(new Version(1, 9), new string[] { _SqlServerScripts.Storage1_9x1});
                  storageScripts.Add(new Version(1, 10), new string[] { _SqlServerScripts.Storage1_10x1});
                  storageScripts.Add(new Version(1, 11), new string[] { _SqlServerScripts.Storage1_11x1});
#if (LEADTOOLS_V20_OR_LATER)
                  storageScripts.Add(new Version(1, 12), new string[] { _SqlServerScripts.Storage1_12x1, _SqlServerScripts.Storage1_12x2});

                  // Note: including JobsDownload uprades scripts with Storage because the Jobs tables are installed with the storage server database.  
                  // The Jobs tables are only used by the Medical WebViewer
                  storageScripts.Add(new Version(1, 13), new string[] { _SqlServerScripts.Storage1_13x1, _SqlServerScripts.Storage1_13x2, _SqlServerScripts.JobsDownload1_1x1, _SqlServerScripts.JobsDownload1_1x2 });
#endif
#endif
                  _sqlServerComponentToVersionScripts.Add ( VersionTable.Storage, storageScripts ) ;
               }
               
               {//permissions
                  Dictionary <Version,string[]> permissionsScripts = new Dictionary<Version,string[]> ( ) ;
                  permissionsScripts.Add ( new Version (1,0), new string[0]);//Create
                  permissionsScripts.Add(new Version(1, 5), new string[] { _SqlServerScripts.Permissions1_5x1, _SqlServerScripts.Permissions1_5x2, _SqlServerScripts.Permissions1_5x3 });
#if (LEADTOOLS_V20_OR_LATER)
                  permissionsScripts.Add(new Version(1, 6), new string[] { _SqlServerScripts.Permissions1_6x1});
#endif // #if (LEADTOOLS_V20_OR_LATER)
                  _sqlServerComponentToVersionScripts.Add ( VersionTable.Permissions, permissionsScripts ) ;
               }
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
               {
                  //AeManagement
                  Dictionary<Version, string[]> aeManagmentScripts = new Dictionary<Version, string[]>();
                  aeManagmentScripts.Add(new Version(1, 0), new string[0]);//Create
                  aeManagmentScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.AeManagement1_1x1});
#if (LEADTOOLS_V20_OR_LATER)
                  aeManagmentScripts.Add(new Version(1, 2), new string[] { _SqlServerScripts.AeManagement1_2x1 });
                  aeManagmentScripts.Add(new Version(1, 3), new string[] { _SqlServerScripts.AeManagement1_3x1 });
                  aeManagmentScripts.Add(new Version(1, 4), new string[] { _SqlServerScripts.AeManagement1_4x1 });
#endif // #if (LEADTOOLS_V20_OR_LATER)
                  _sqlServerComponentToVersionScripts.Add(VersionTable.AeManagement, aeManagmentScripts);
               }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)   

#if (LEADTOOLS_V19_OR_LATER)
                {
                   //Options
                   Dictionary<Version, string[]> optionsScripts = new Dictionary<Version, string[]>();
                   optionsScripts.Add(new Version(1, 0), new string[0]);//Create
                   optionsScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.Options1_1x1 });
#if (LEADTOOLS_V20_OR_LATER)
                   optionsScripts.Add(new Version(1, 2), new string[] { _SqlServerScripts.Options1_2x1 });
#endif // #if (LEADTOOLS_V20_OR_LATER)
                  _sqlServerComponentToVersionScripts.Add(VersionTable.Options, optionsScripts);
                }

               {
                  //UserManagement
                  Dictionary<Version, string[]> userManagementScripts = new Dictionary<Version, string[]>();
                  userManagementScripts.Add(new Version(1, 0), new string[0]);//Create
                  userManagementScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.UserManagement1_1x1 });
#if (LEADTOOLS_V20_OR_LATER)
                  userManagementScripts.Add(new Version(1, 2), new string[] { _SqlServerScripts.UserManagement1_2x1 });
                  userManagementScripts.Add(new Version(1, 3), new string[] { _SqlServerScripts.UserManagement1_3x1 });
                  userManagementScripts.Add(new Version(1, 4), new string[] { _SqlServerScripts.UserManagement1_4x1 });
#endif
                  _sqlServerComponentToVersionScripts.Add(VersionTable.UserManagement, userManagementScripts);
               }

#if (LEADTOOLS_V20_OR_LATER)
               {
                  //JobsDownload
                  Dictionary<Version, string[]> jobsDownloadScripts = new Dictionary<Version, string[]>();
                  jobsDownloadScripts.Add(new Version(1, 0), new string[0]);//Create
                  jobsDownloadScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.JobsDownload1_1x1, _SqlServerScripts.JobsDownload1_1x2 });
                  _sqlServerComponentToVersionScripts.Add(VersionTable.JobsDownload, jobsDownloadScripts);
               }

               //Media
               {
                  Dictionary<Version, string[]> mediaScripts = new Dictionary<Version, string[]>();
                  mediaScripts.Add(new Version(1, 0), new string[0]);//Create
                  mediaScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.Media1_1x1,  _SqlServerScripts.Media1_1x2, _SqlServerScripts.Media1_1x3});
                  _sqlServerComponentToVersionScripts.Add(VersionTable.Media, mediaScripts);
               }

               //Worklist
               {
                  Dictionary<Version, string[]> worklistScripts = new Dictionary<Version, string[]>();
                  worklistScripts.Add(new Version(1, 0), new string[0]);//Create
                  worklistScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.Worklist1_1x1, _SqlServerScripts.Worklist1_1x2, _SqlServerScripts.Worklist1_1x3, _SqlServerScripts.Worklist1_1x4});
                  _sqlServerComponentToVersionScripts.Add(VersionTable.Worklist, worklistScripts);
               }

               //ExportLayout
               {
                  Dictionary<Version, string[]> exportLayoutScripts = new Dictionary<Version, string[]>();
                  exportLayoutScripts.Add(new Version(1, 0), new string[0]);//Create
                  exportLayoutScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.ExportLayout1_1x1});
                  _sqlServerComponentToVersionScripts.Add(VersionTable.ExportLayout, exportLayoutScripts);
               }

#endif // #if (LEADTOOLS_V20_OR_LATER)
#endif // #if (LEADTOOLS_V19_OR_LATER)
            }

            {
               _sqlCeComponentToVersionScripts = new Dictionary<string, Dictionary<Version, string[]>>();
               {//Logging 
                  Dictionary<Version, string[]> loggingScripts = new Dictionary<Version, string[]>();
                  loggingScripts.Add(new Version(1, 0), new string[0]);//Create
                  loggingScripts.Add(new Version(1, 5), new string[] { _SqlCeScripts.Logging1_5x1, _SqlCeScripts.Logging1_5x2 });//Create
#if (LEADTOOLS_V20_OR_LATER)
                  loggingScripts.Add(new Version(1, 6), new string[] { _SqlCeScripts.Logging1_6x1, _SqlCeScripts.Logging1_6x1 });
#endif
                  _sqlCeComponentToVersionScripts.Add(VersionTable.Logging, loggingScripts);
               }

               {//Storage
                  Dictionary<Version, string[]> storageScripts = new Dictionary<Version, string[]>();
                  storageScripts.Add(new Version(1, 0), new string[0]);//Create
                  storageScripts.Add(new Version(1, 5), new string[] { _SqlCeScripts.Storage1_5x1, _SqlCeScripts.Storage1_5x2, _SqlCeScripts.Storage1_5x3 });
                  storageScripts.Add(new Version(1, 6), new string[] { _SqlCeScripts.Storage1_6x1 });

#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V18_OR_LATER)
                  storageScripts.Add(new Version(1, 7), new string[] { _SqlCeScripts.Storage1_7x1 });
#endif

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                  storageScripts.Add(new Version(1, 8), new string[] { _SqlCeScripts.Storage1_8x1, _SqlCeScripts.Storage1_8x2 });
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
#if LEADTOOLS_V19_OR_LATER
                  storageScripts.Add(new Version(1, 9), new string[] { _SqlCeScripts.Storage1_9x1 });
                  storageScripts.Add(new Version(1, 10), new string[] { _SqlCeScripts.Storage1_10x1 });
                  storageScripts.Add(new Version(1, 11), new string[] { _SqlCeScripts.Storage1_11x1 });
#if (LEADTOOLS_V20_OR_LATER)
                  storageScripts.Add(new Version(1, 12), new string[] { _SqlCeScripts.Storage1_12x1, _SqlCeScripts.Storage1_12x2 });

                  // Note: including JobsDownload uprades scripts with Storage because the Jobs tables are installed with the storage server database.  
                  // The Jobs tables are only used by the Medical WebViewer

                  storageScripts.Add(new Version(1, 13), new string[] { _SqlCeScripts.Storage1_13x1, _SqlCeScripts.Storage1_13x2, _SqlCeScripts.JobsDownload1_1x1, _SqlCeScripts.JobsDownload1_1x2 });
#endif
#endif
                  _sqlCeComponentToVersionScripts.Add(VersionTable.Storage, storageScripts);
               }

               {//permissions
                  Dictionary<Version, string[]> permissionsScripts = new Dictionary<Version, string[]>();
                  permissionsScripts.Add(new Version(1, 0), new string[0]);//Create
                  permissionsScripts.Add(new Version(1, 5), new string[] { _SqlCeScripts.Permissions1_5x1, _SqlCeScripts.Permissions1_5x2, _SqlCeScripts.Permissions1_5x3 });
#if (LEADTOOLS_V20_OR_LATER)                  
                  permissionsScripts.Add(new Version(1, 6), new string[] { _SqlCeScripts.Permissions1_6x1});
#endif
                  _sqlCeComponentToVersionScripts.Add(VersionTable.Permissions, permissionsScripts);
               }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
               {
                  //AeManagement
                  Dictionary<Version, string[]> aeManagmentScripts = new Dictionary<Version, string[]>();
                  aeManagmentScripts.Add(new Version(1, 0), new string[0]);//Create
                  aeManagmentScripts.Add(new Version(1, 1), new string[] { _SqlCeScripts.AeManagement1_1x1 });
#if (LEADTOOLS_V20_OR_LATER)
                  aeManagmentScripts.Add(new Version(1, 2), new string[] { _SqlCeScripts.AeManagement1_2x1 });
                  aeManagmentScripts.Add(new Version(1, 3), new string[] { _SqlCeScripts.AeManagement1_3x1 });
                  aeManagmentScripts.Add(new Version(1, 4), new string[] { _SqlCeScripts.AeManagement1_4x1 });

#endif // #if (LEADTOOLS_V20_OR_LATER)
                  _sqlCeComponentToVersionScripts.Add(VersionTable.AeManagement, aeManagmentScripts);
               }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)

#if (LEADTOOLS_V19_OR_LATER)
               {
                  //Options
                  Dictionary<Version, string[]> optionsScripts = new Dictionary<Version, string[]>();
                  optionsScripts.Add(new Version(1, 0), new string[0]);//Create
                  optionsScripts.Add(new Version(1, 1), new string[] { _SqlCeScripts.Options1_1x1 }); 
#if (LEADTOOLS_V20_OR_LATER)
                  optionsScripts.Add(new Version(1, 2), new string[] { _SqlCeScripts.Options1_2x1 });
#endif // #if (LEADTOOLS_V20_OR_LATER)
                  _sqlCeComponentToVersionScripts.Add(VersionTable.Options, optionsScripts);
               }

               {
                  //UserManagement
                  Dictionary<Version, string[]> userManagementScripts = new Dictionary<Version, string[]>();
                  userManagementScripts.Add(new Version(1, 0), new string[0]);//Create
                  userManagementScripts.Add(new Version(1, 1), new string[] { _SqlCeScripts.UserManagement1_1x1 });
#if (LEADTOOLS_V20_OR_LATER)
                  userManagementScripts.Add(new Version(1, 2), new string[] { _SqlCeScripts.UserManagement1_2x1 });
                  userManagementScripts.Add(new Version(1, 3), new string[] { _SqlCeScripts.UserManagement1_3x1 });
                  userManagementScripts.Add(new Version(1, 4), new string[] { _SqlCeScripts.UserManagement1_4x1 });
#endif
                  _sqlCeComponentToVersionScripts.Add(VersionTable.UserManagement, userManagementScripts);
               }

#if (LEADTOOLS_V20_OR_LATER)
               {
                  //JobsDownload
                  Dictionary<Version, string[]> jobsDownloadScripts = new Dictionary<Version, string[]>();
                  jobsDownloadScripts.Add(new Version(1, 0), new string[0]);//Create
                  jobsDownloadScripts.Add(new Version(1, 1), new string[] { _SqlServerScripts.JobsDownload1_1x1, _SqlServerScripts.JobsDownload1_1x2});
                  _sqlCeComponentToVersionScripts.Add(VersionTable.JobsDownload, jobsDownloadScripts);
               }
#endif // #if (LEADTOOLS_V20_OR_LATER)
#endif // #if (LEADTOOLS_V19_OR_LATER)
            }
            
         }

         // If there are only two columns and one entry, than all versions are 1.0 except for logging (1.5)
         public static Version GetOldVersion(string componentName)
         {
            if (string.Compare(VersionTable.Logging, componentName, true) == 0)
            {
               return new Version(1, 5);
            }
            else
            {
               return new Version(1, 0);
            }
         }
         
         public static Version GetVersion ( string componentName, ConnectionStringSettings connectionSettings) 
         {
            Scripts xxx ;
            Dictionary <string, Dictionary<Version,string[]>> yyy ;
            Microsoft.Practices.EnterpriseLibrary.Data.Database dataProvider = CreateDataProvider ( connectionSettings, out xxx, out yyy ) ;
            
            using ( DbConnection connection = dataProvider.CreateConnection ( ) )
            {
               using ( DbCommand cmd = connection.CreateCommand ( ) )
               {
                  cmd.CommandText = "SELECT * FROM DbVersion" ;
                  
                  using ( IDataReader reader = dataProvider.ExecuteReader ( cmd ) )
                  {
                     while ( reader.Read ( ) )
                     {
                        if ( reader.FieldCount > 2 )
                        {
                           if ( string.Compare ( reader.GetString ( 2 ), componentName, true ) == 0 )
                           {
                              return new Version ( reader.GetInt32 ( 0 ), reader.GetInt32 (1) ) ;
                           }
                        }
                        else
                        {
                           // This is to upgrade older versions of the database, where there were only two columns (Major, Minor) and one row
                           // return new Version ( reader.GetInt32 ( 0 ), reader.GetInt32 (1) ) ;
                           return GetOldVersion(componentName);
                        }
                     }
                  }
               }
            }
         
            return new Version (1,0);
         }

         private static string[] acceptableExceptionsArray = {
                                                    @"specified table already exists",
                                                    @"column ID occurred more than once in the specification"
                                                 };
         
         public static void Upgrade ( string component, Version current, ConnectionStringSettings connectionSettings ) 
         {
            Scripts scriptsObject ;
            Dictionary <string, Dictionary<Version,string[]>> componentToVersionScripts ;
            Microsoft.Practices.EnterpriseLibrary.Data.Database dataProvider = CreateDataProvider ( connectionSettings, out scriptsObject, out componentToVersionScripts ) ;
            
            if ( !componentToVersionScripts.ContainsKey (component) )
            {
               return ;
            }
            
            Dictionary <Version,string[]> componentScripts = componentToVersionScripts [ component ] ;
            
            if ( null == componentScripts ) 
            {
               return ;
            }
            
            bool execute = false ;
            
            foreach ( KeyValuePair<Version,string[]> versionStrings in componentScripts ) 
            {
               if ( !execute )
               {
                  if ( versionStrings.Key == current )
                  {
                     execute = true ;
                  }
               }
               else
               {
                  string[] scripts = versionStrings.Value ;
            
                  using ( DbConnection connection = dataProvider.CreateConnection ( ) )
                  {
                     connection.Open ( ) ;
                     
                     DbTransaction transaction = connection.BeginTransaction ( ) ;
                     
                     try 
                     {
                        // Create Tables
                        foreach ( string upgrageScript in scripts ) 
                        {
                           if (!string.IsNullOrEmpty(upgrageScript))
                           {
                              using (DbCommand command = connection.CreateCommand())
                              {
                                 command.Transaction = transaction;

                                 using (StringReader reader = new StringReader(upgrageScript))
                                 {
                                    StringBuilder sb = new StringBuilder();
                                    string line;
                                    while ((line = reader.ReadLine()) != null)
                                    {
                                       line = line.Trim();
                                       if (line.Equals("GO", StringComparison.OrdinalIgnoreCase))
                                       {
                                          command.CommandText = sb.ToString();

                                          try
                                          {
                                             command.ExecuteNonQuery();
                                          }
                                          catch (Exception ex)
                                          {
                                             if(acceptableExceptionsArray.Any(ex.Message.Contains))
                                             {
                                                Console.WriteLine(ex.Message);
                                             }
                                             else
                                             {
                                                Console.WriteLine(ex.Message);
                                             }

                                          }

                                          sb.Remove(0, sb.Length);
                                       }
                                       else
                                       {
                                          sb.Append(line);
                                          sb.Append(Environment.NewLine);
                                       }
                                    }

                                    string finalQuery = sb.ToString();
                                    finalQuery = finalQuery.Trim();

                                    if (!string.IsNullOrEmpty(finalQuery))
                                    {
                                       command.CommandText = sb.ToString();

                                       try
                                       {
                                          command.ExecuteNonQuery();
                                       }
                                       catch (Exception ex)
                                       {
                                          Console.WriteLine(ex.Message);
                                       }
                                    }
                                 }


                                 // command.CommandText = upgrageScript;
                                 // command.Transaction = transaction;
                                 // command.ExecuteNonQuery();
                              }
                           }
                        }
                        
                        UpdateVersionNumber ( component, componentScripts.Keys.ToArray()[componentScripts.Keys.Count-1], connection, transaction, scriptsObject ) ;
                        
                        transaction.Commit ( ) ;
                     }
                     catch ( Exception) 
                     {
                        transaction.Rollback ( ) ;
                        
                        throw ;
                     }
                     finally
                     {
                        transaction.Dispose ( ) ;
                     }
                  }
               }
            }
         }

         // Moved the actual reference to 'SqlCeDatabase' to another database
         private static Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDataProvider_SqlCe(string connectionString)
         {
             Microsoft.Practices.EnterpriseLibrary.Data.Database dataProvider = dataProvider = new SqlCeDatabase(connectionString);
             return dataProvider;
         }

         private static Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDataProvider(ConnectionStringSettings connectionStringSettings, out Scripts scriptsObject, out Dictionary<string, Dictionary<Version, string[]>> componentToVersionScripts)
         {
            Microsoft.Practices.EnterpriseLibrary.Data.Database dataProvider;

            if (connectionStringSettings.ProviderName == "System.Data.SqlClient")
            {
               dataProvider = new SqlDatabase(connectionStringSettings.ConnectionString);
               scriptsObject = _SqlServerScripts;
               componentToVersionScripts = _sqlServerComponentToVersionScripts;
            }
            else if (connectionStringSettings.ProviderName == "Microsoft.SqlServerCe.Client.3.5")
            {
               // dataProvider = new SqlCeDatabase(connectionStringSettings.ConnectionString);
               dataProvider = CreateDataProvider_SqlCe(connectionStringSettings.ConnectionString);
               scriptsObject = _SqlCeScripts;
               componentToVersionScripts = _sqlCeComponentToVersionScripts;
            }
            else
            {
               throw new Exception("Unsupported data provider");
            }

            return dataProvider;
         }

         private static void UpdateVersionNumber(string component, Version currentVersion, DbConnection connection, DbTransaction transaction, Scripts scripts)
         {
            using ( DbCommand cmd = connection.CreateCommand ( ) )
            {
               cmd.CommandText = "SELECT * FROM DbVersion" ;
               cmd.Transaction = transaction ;
               
               bool exists = false ;
               
               using ( DbDataReader reader = cmd.ExecuteReader ( ) )
               {
                  if ( reader.FieldCount > 2 )
                  {
                     while ( reader.Read ( ) )
                     {
                        if ( string.Compare ( reader.GetString ( 2 ), component, true ) == 0 )
                        {
                           exists = true ;
                           
                           reader.Close ( ) ;
                           
                           break ;
                        }
                     }
                  }
                  else
                  {
                     if ( reader.Read ( ) )
                     {
                        exists = true ;
                     }
                     
                     reader.Close ( ) ;
                     
                     using ( DbCommand alterCmd = connection.CreateCommand ( ) )
                     {
                        // This is the case for old version of DbVersion (two columns, one row)
                        // We must upgrade this to the new format (three columns, one or more rows)
                        
                        // Add the third column [Name]
                        cmd.CommandText = scripts.AlterDbVersion ;
                        cmd.Transaction = transaction ;
                        cmd.ExecuteNonQuery ( ) ;
                        
                        // Remove the primary key constraint
                        cmd.CommandText = scripts.RemoveDbPrimaryKey;
                        cmd.ExecuteNonQuery();
                        
                        // If there are exactly two columns, than this is the 'Logging' component
                        cmd.CommandText = string.Format ( scripts.AddComponentNameToDbVersion, VersionTable.Logging ) ;
                        cmd.ExecuteNonQuery ( ) ;
                        
                        // Now there are three columns -- force new componenet to get added by setting 'exists' to false
                        exists = false;
                        
                     }
                  }
               }
               
               if ( exists ) 
               {
                  cmd.CommandText = string.Format ( scripts.UpdateDbVersion, currentVersion.Major, currentVersion.Minor, component ) ;
               }
               else
               {
                  cmd.CommandText = string.Format ( scripts.InsertDbVersion, currentVersion.Major, currentVersion.Minor, component ) ;
               }
               
               cmd.Transaction = transaction ;
               cmd.ExecuteNonQuery ( ) ;
            }
         }
         private static Dictionary <string, Dictionary<Version,string[]>> _sqlServerComponentToVersionScripts ;
         private static Dictionary <string, Dictionary<Version,string[]>> _sqlCeComponentToVersionScripts ;
         private static Scripts _SqlServerScripts = new SqlServerScripts ( ) ;
         private static Scripts _SqlCeScripts = new SqlCeScripts ( ) ;
      }
      
      abstract class Scripts
      {
         public abstract string AlterDbVersion { get ;}
         public abstract string RemoveDbPrimaryKey { get ;}
         public abstract string AddComponentNameToDbVersion { get ;}
         public abstract string UpdateDbVersion { get ;}
         public abstract string InsertDbVersion { get ;}
         public abstract string Logging1_5x1 { get ;}
         public abstract string Logging1_5x2 { get ;}
         public abstract string Logging1_6x1 { get; }
         public abstract string Storage1_5x1 { get ;}
         public abstract string Storage1_5x2 { get ;}
         public abstract string Storage1_5x3 { get ; }
         public abstract string Storage1_6x1 { get ; }
#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V18_OR_LATER)
         public abstract string Storage1_7x1 { get ; }
#endif
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         public abstract string Storage1_8x1 { get ; }
         public abstract string Storage1_8x2 { get ; }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

#if LEADTOOLS_V19_OR_LATER
         public abstract string Storage1_9x1 { get; }
         public abstract string Storage1_10x1 { get; }
         public abstract string Storage1_11x1 { get; }
#if (LEADTOOLS_V20_OR_LATER)
         public abstract string Storage1_12x1 { get; }
         public abstract string Storage1_12x2 { get; }

         public abstract string Storage1_13x1 { get; }
         public abstract string Storage1_13x2 { get; }
         //public abstract string Storage1_14x1 { get; }
#endif

         public abstract string UserManagement1_1x1 { get;}
#if (LEADTOOLS_V20_OR_LATER)
         public abstract string UserManagement1_2x1 { get; }
         public abstract string UserManagement1_3x1 { get; }
         public abstract string UserManagement1_4x1 { get; }
#endif

#endif

         public abstract string Permissions1_5x1 { get ; }
         public abstract string Permissions1_5x2 { get ; }
         public abstract string Permissions1_5x3 { get ; }

         public abstract string Permissions1_6x1 { get; }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)  
         // AeManagement
         public abstract string AeManagement1_1x1 { get ; }
#endif

#if (LEADTOOLS_V20_OR_LATER)
         public abstract string AeManagement1_2x1 { get; }
         public abstract string AeManagement1_3x1 { get; }

         public abstract string AeManagement1_4x1 { get; }
#endif

         public abstract string Options1_1x1 { get; }
         public abstract string Options1_2x1 { get; }

         // JobsDownload
         public abstract string JobsDownload1_1x1 { get; }
         public abstract string JobsDownload1_1x2 { get; }

         public abstract string Media1_1x1 { get; }
         public abstract string Media1_1x2 { get; }
         public abstract string Media1_1x3 { get; }


         public abstract string Worklist1_1x1 { get; }
         public abstract string Worklist1_1x2 { get; }
         public abstract string Worklist1_1x3 { get; }
         public abstract string Worklist1_1x4 { get; }
         public abstract string ExportLayout1_1x1 { get; }

      }

      class SqlServerScripts : Scripts
      {
         public override string AlterDbVersion { get { return 
   @"ALTER TABLE [DbVersion] ADD [Name] nvarchar(100) NULL;" ;
    } }

         public override string RemoveDbPrimaryKey
         {
            get { return 
   @"ALTER TABLE [DbVersion] DROP Constraint PK_Major_Minor;" ;
    } } 
    
         public override string AddComponentNameToDbVersion { get { return 
   @"UPDATE [DbVersion] SET [Name]='{0}' WHERE [Name] is NULL" ;
   }}
         public override string UpdateDbVersion { get { return 
   @"UPDATE [DbVersion]
   SET [Major]={0}, [Minor]={1}
   WHERE [Name]='{2}'" ;
   }}
         public override string InsertDbVersion { get { return 
   @"INSERT INTO [DbVersion]([Major], [Minor],[Name])
   VALUES({0}, {1}, '{2}')" ;
         }}
         
         public override string Logging1_5x1 { get { return 
   @"ALTER TABLE DICOMServerEventLog ADD [DatasetPath] nvarchar(400) NULL;" ;
   }}

         public override string Logging1_5x2 { get { return 
   @"ALTER TABLE DICOMServerEventLog ADD [CustomType] nvarchar(15) NULL;" ;
    }}

         public override string Logging1_6x1
         {
            get
            {
               return
    @"IF EXISTS 
      (	SELECT name 
         FROM sys.stats
         WHERE object_id = OBJECT_ID( 'dbo.DICOMServerEventLog')
      )
      Begin
         ALTER TABLE dbo.[DICOMServerEventLog] ALTER COLUMN [CustomInformation] NVARCHAR(MAX)
         ALTER TABLE dbo.[DICOMServerEventLog] ALTER COLUMN [Description] NVARCHAR(MAX)
         ALTER TABLE dbo.[DICOMServerEventLog] ALTER COLUMN [Dataset] VARBINARY(MAX)
      End
      ";
            }
         }

         public override string Storage1_5x1 { get { return 
   @"
   CREATE TABLE [PresentationInstance] (
	   [SOPInstanceUID] [nvarchar] (64) NOT NULL ,
	   [ContentLabel] [nvarchar] (50) NULL ,
	   [CreationDate] [datetime] NULL ,
	   [ContentDescription] [nvarchar] (64) NULL ,
	   [ContentCreatorFamilyName] [nvarchar] (64) NULL ,
	   [ContentCreatorGivenName] [nvarchar] (63) NULL ,
	   [ContentCreatorMiddleName] [nvarchar] (62) NULL ,
	   [ContentCreatorNamePrefix] [nvarchar] (61) NULL ,
	   [ContentCreatorNameSuffix] [nchar] (60) NULL ,
	   CONSTRAINT [PK_PresentationState] PRIMARY KEY  CLUSTERED 
	   (
		   [SOPInstanceUID]
	   )  ON [PRIMARY] ,
	   CONSTRAINT [FK_PresentationState_Instance] FOREIGN KEY 
	   (
		   [SOPInstanceUID]
	   ) REFERENCES [Instance] (
		   [SOPInstanceUID]
	   ) ON DELETE CASCADE  ON UPDATE CASCADE 
   ) ON [PRIMARY]
   ";
   }}
         public override string Storage1_5x2 { get { return 
   @"
   CREATE TABLE [ReferencedSeriesSequence] (
	   [SeriesInstanceUID] [nvarchar] (64) NOT NULL ,
	   [SOPInstanceUID] [nvarchar] (64) NOT NULL ,
	   CONSTRAINT [PK_ReferencedSeriesSequence_1] PRIMARY KEY  CLUSTERED 
	   (
		   [SeriesInstanceUID],
		   [SOPInstanceUID]
	   )  ON [PRIMARY] ,
	   CONSTRAINT [FK_ReferencedSeriesSequence_PresentationInstance] FOREIGN KEY 
	   (
		   [SOPInstanceUID]
	   ) REFERENCES [PresentationInstance] (
		   [SOPInstanceUID]
	   ) ON DELETE CASCADE  ON UPDATE CASCADE 
   ) ON [PRIMARY]
   ";
   }}
         public override string Storage1_5x3 { get { return 
   @"
   CREATE TABLE [ReferencedImageSequence] (
	   [SeriesInstanceUID] [nvarchar] (64) NOT NULL ,
	   [SOPInstanceUID] [nvarchar] (64) NOT NULL ,
	   [ReferencedSOPInstanceUID] [nvarchar] (64) NOT NULL ,
	   [ReferencedSOPClassUID] [nvarchar] (64) NOT NULL ,
	   [ItemIndex] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
	   CONSTRAINT [PK_ReferencedImageSequence] PRIMARY KEY  CLUSTERED 
	   (
		   [SeriesInstanceUID],
		   [SOPInstanceUID],
		   [ReferencedSOPInstanceUID]
	   )  ON [PRIMARY] ,
	   CONSTRAINT [FK_ReferencedImageSequence_ReferencedSeriesSequence] FOREIGN KEY 
	   (
		   [SeriesInstanceUID],
		   [SOPInstanceUID]
	   ) REFERENCES [ReferencedSeriesSequence] (
		   [SeriesInstanceUID],
		   [SOPInstanceUID]
	   ) ON DELETE CASCADE  ON UPDATE CASCADE 
   ) ON [PRIMARY]
   " ;
   }}
#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V18_OR_LATER)
   public override string Storage1_7x1 
   {
      get
      {
         return 
            @"
if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Instance' and COLUMN_NAME = 'StoreAETitle'
             )
ALTER TABLE Instance ADD [StoreAETitle] nvarchar(16) NULL";
      }
   }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
   public override string Storage1_8x1 
   {
      get
      {
         return 
            @" 
IF NOT EXISTS 
      (	SELECT name 
         FROM sys.stats
         WHERE object_id = OBJECT_ID( 'dbo.ExternalStore')
      )
Begin

CREATE TABLE [ExternalStore](
	[SOPInstanceUID] [nvarchar](64) NOT NULL,
	[StoreDate] [datetime] NULL,
	[ExpireDate] [datetime] NULL,
	[StoreToken] [nvarchar](400) NULL,
	[ExternalStoreGuid] [nvarchar](400) NULL,
 CONSTRAINT [PK_ExternalStore] PRIMARY KEY CLUSTERED 
(
	[SOPInstanceUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [ExternalStore]  WITH CHECK ADD  CONSTRAINT [FK_ExternalStore_Instance] FOREIGN KEY([SOPInstanceUID])
REFERENCES [Instance] ([SOPInstanceUID])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [ExternalStore] CHECK CONSTRAINT [FK_ExternalStore_Instance]
END
";
      }
   }

   public override string Storage1_8x2 
   {
      get
      {
         return 
            @"
if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Instance' and COLUMN_NAME = 'StoreToken'
             )
ALTER TABLE Instance ADD [StoreToken] nvarchar(400) NULL

if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Instance' and COLUMN_NAME = 'ExternalStoreGuid'
             )
ALTER TABLE Instance ADD [ExternalStoreGuid] nvarchar(400) NULL
            ";
      }
   }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
#if LEADTOOLS_V19_OR_LATER
   public override string Storage1_9x1
   {
       get 
       {
           return @"
                if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'ImageInstance' and COLUMN_NAME = 'EchoNumber'
             )
             ALTER TABLE ImageInstance ADD EchoNumber [int] NULL

             if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'ImageInstance' and COLUMN_NAME = 'FrameOfReferenceUID'
             )
             ALTER TABLE ImageInstance ADD FrameOfReferenceUID [nvarchar](64) NULL

            if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'ImageInstance' and COLUMN_NAME = 'SequenceName'
             )
             ALTER TABLE ImageInstance ADD SequenceName [nvarchar](16) NULL

             if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'ImageInstance' and COLUMN_NAME = 'ImagePositionPatient'
             )
             ALTER TABLE ImageInstance ADD ImagePositionPatient [nvarchar](256) NULL

            if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'ImageInstance' and COLUMN_NAME = 'ImageOrientationPatient'
             )
             ALTER TABLE ImageInstance ADD ImageOrientationPatient [nvarchar](256) NULL

             if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'ImageInstance' and COLUMN_NAME = 'PixelSpacing'
             )
             ALTER TABLE ImageInstance ADD PixelSpacing [nvarchar](256) NULL
            ";
       }
   }

   public override string Storage1_10x1
   {
       get 
       {
          return
             @"
                IF NOT EXISTS (
                     SELECT *
                     FROM INFORMATION_SCHEMA.COLUMNS
                     WHERE TABLE_NAME = 'Series' and COLUMN_NAME = 'Laterality'
                )
                ALTER TABLE Series ADD [Laterality] nvarchar(16) NULL

                IF NOT EXISTS (
                     SELECT *
                     FROM INFORMATION_SCHEMA.COLUMNS
                     WHERE TABLE_NAME = 'Series' and COLUMN_NAME = 'ProtocolName'
                )
                ALTER TABLE Series ADD [ProtocolName] nvarchar(64) NULL

                IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.HangingProtocol'))
                BEGIN
                CREATE TABLE [HangingProtocol] (
                   [SOPClassUID] [nvarchar](64) NOT NULL,
                   [SOPInstanceUID] [nvarchar](64) NOT NULL,
                   [Name] [nvarchar](16) NOT NULL,
                   [Description] [nvarchar](64) NOT NULL,
                   [Level] [nvarchar](16) NOT NULL,
                   [Creator] [nvarchar](64) NOT NULL,
                   [CreationDateTime] [datetime] NULL,
                   [UserGroupName] [nvarchar](64) NULL,
                   [NumberOfPriorsReferenced] [int] NOT NULL,
                   [SpecificCharacterSet] [nvarchar](16) NULL,
                   [ReferencedFile] [nvarchar](400) PRIMARY KEY CLUSTERED 
                   ([SOPInstanceUID] ASC) WITH (
                      PAD_INDEX = OFF,
                      STATISTICS_NORECOMPUTE = OFF,
                      IGNORE_DUP_KEY = OFF,
                      ALLOW_ROW_LOCKS = ON,
                      ALLOW_PAGE_LOCKS = ON
                      ) ON [PRIMARY]
                                   ) ON [PRIMARY]
                END
                
                IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.HangingProtocolDefinitonSequence'))
                BEGIN
                  CREATE TABLE [HangingProtocolDefinitonSequence](
                     [DefinitionSequenceGuid] [nvarchar](64) NOT NULL,
                     [SOPInstanceUID] [nvarchar](64) NOT NULL,
                     [Modality] [nvarchar](16) NOT NULL,
                     [Laterality] [nvarchar](16) NULL,
                     [StudyDescription] [nvarchar](64) NULL,
                     [BodyPartExamined] [nvarchar](16) NULL,
                     [ProtocolName] [nvarchar](64) NULL,
                  CONSTRAINT [PK_DefinitionSequenceGuid] PRIMARY KEY CLUSTERED ([DefinitionSequenceGuid] ASC) WITH (
                     PAD_INDEX = OFF,
                     STATISTICS_NORECOMPUTE = OFF,
                     IGNORE_DUP_KEY = OFF,
                     ALLOW_ROW_LOCKS = ON,
                     ALLOW_PAGE_LOCKS = ON
                    ) ON [PRIMARY]
                   ) ON [PRIMARY] 
                END
                 
                IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_HangingProtocolDefinitonSequence_HangingProtocol]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                BEGIN
                  ALTER TABLE [HangingProtocolDefinitonSequence]  WITH CHECK ADD  CONSTRAINT [FK_HangingProtocolDefinitonSequence_HangingProtocol] FOREIGN KEY ([SOPInstanceUID])
                     REFERENCES [HangingProtocol] ([SOPInstanceUID])
                  ON UPDATE CASCADE
                  ON DELETE CASCADE
                END
                
                IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_HangingProtocolDefinitonSequence_HangingProtocol]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)    
                BEGIN
                  ALTER TABLE [HangingProtocolDefinitonSequence] CHECK CONSTRAINT [FK_HangingProtocolDefinitonSequence_HangingProtocol]
                END
                    
                IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.HangingProtocolAnatomicRegionSequence'))
                BEGIN
                  CREATE TABLE [HangingProtocolAnatomicRegionSequence](
                     [DefinitionSequenceGuid] [nvarchar](64) NOT NULL,
                     [CodeValue] [nvarchar](16) NOT NULL,
                     [CodingSchemeDesignator] [nvarchar](16) NOT NULL,  
                     [CodingSchemeVersion] [nvarchar](16) NULL,
                     [CodeMeaning] [nvarchar](64) NOT NULL )
                
                  ALTER TABLE [HangingProtocolAnatomicRegionSequence]  WITH CHECK ADD  CONSTRAINT [FK_HangingProtocolAnatomicRegionSequence_HangingProtocolDefinitonSequence] FOREIGN KEY ([DefinitionSequenceGuid])
                     REFERENCES [HangingProtocolDefinitonSequence] ([DefinitionSequenceGuid])
                     ON UPDATE CASCADE
                     ON DELETE CASCADE
                    
                     ALTER TABLE [HangingProtocolAnatomicRegionSequence] CHECK CONSTRAINT [FK_HangingProtocolAnatomicRegionSequence_HangingProtocolDefinitonSequence]
                END
                                  
                IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.HangingProtocolProcedureCodeSequence'))
                BEGIN  
                  CREATE TABLE [HangingProtocolProcedureCodeSequence](
                     [DefinitionSequenceGuid] [nvarchar](64) NOT NULL,
                     [CodeValue] [nvarchar](16) NOT NULL,
                     [CodingSchemeDesignator] [nvarchar](16) NOT NULL,  
                     [CodingSchemeVersion] [nvarchar](16) NULL,
                     [CodeMeaning] [nvarchar](64) NOT NULL)
                    
                  ALTER TABLE [HangingProtocolProcedureCodeSequence]  WITH CHECK ADD  CONSTRAINT [FK_HangingProtocolProcedureCodeSequence_HangingProtocolDefinitonSequence] FOREIGN KEY ([DefinitionSequenceGuid])
                     REFERENCES [HangingProtocolDefinitonSequence] ([DefinitionSequenceGuid])
                     ON UPDATE CASCADE
                     ON DELETE CASCADE
                    
                    ALTER TABLE [HangingProtocolProcedureCodeSequence] CHECK CONSTRAINT [FK_HangingProtocolProcedureCodeSequence_HangingProtocolDefinitonSequence]
                END
                  
                IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.HangingProtocolReasonForRequestedProcedureCodeSequence'))
                BEGIN 
                  CREATE TABLE [HangingProtocolReasonForRequestedProcedureCodeSequence](
                     [DefinitionSequenceGuid] [nvarchar](64) NOT NULL,
                     [CodeValue] [nvarchar](16) NOT NULL,
                     [CodingSchemeDesignator] [nvarchar](16) NOT NULL,  
                     [CodingSchemeVersion] [nvarchar](16) NULL,
                     [CodeMeaning] [nvarchar](64) NOT NULL)
                    
                  ALTER TABLE [HangingProtocolReasonForRequestedProcedureCodeSequence]  WITH CHECK ADD  CONSTRAINT [FK_HangingProtocolReasonForRequestedProcedureCodeSequence_HangingProtocolDefinitonSequence] FOREIGN KEY([DefinitionSequenceGuid])
                     REFERENCES [HangingProtocolDefinitonSequence] ([DefinitionSequenceGuid])
                     ON UPDATE CASCADE
                     ON DELETE CASCADE
                    
                  ALTER TABLE [HangingProtocolReasonForRequestedProcedureCodeSequence] CHECK CONSTRAINT [FK_HangingProtocolReasonForRequestedProcedureCodeSequence_HangingProtocolDefinitonSequence]
                END            " +

             @"
               IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.ReasonForRequestedProcedureCodeSequence'))
               BEGIN
                 CREATE TABLE [ReasonForRequestedProcedureCodeSequence] (
                    [SeriesInstanceUID] nvarchar(64) NOT NULL
                  , [CodeValue] nvarchar(16) NOT NULL
                  , [CodingSchemeDesignator] nvarchar(16) NOT NULL
                  , [CodeMeaning] nvarchar(64) NULL
                  , [CodingSchemeVersion] nvarchar(16) NULL)

                 ALTER TABLE [ReasonForRequestedProcedureCodeSequence] ADD CONSTRAINT [PK_SeriesInstanceUID_CodeValue_CodingSchemaDesignator] PRIMARY KEY ([SeriesInstanceUID],[CodeValue],[CodingSchemeDesignator])
                 ALTER TABLE [ReasonForRequestedProcedureCodeSequence] ADD CONSTRAINT [FK_ReasonForRequestedProcedureCodeSequence_Series] FOREIGN KEY ([SeriesInstanceUID]) REFERENCES [Series]([SeriesInstanceUID]) ON DELETE CASCADE ON UPDATE CASCADE
               END


               IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.AnatomicRegionSequence'))
               BEGIN
                  CREATE TABLE [AnatomicRegionSequence] (
                     [SOPInstanceUID] nvarchar(64) NOT NULL
                   , [CodeValue] nvarchar(16) NOT NULL
                   , [CodingSchemeDesignator] nvarchar(16) NOT NULL
                   , [CodeMeaning] nvarchar(64) NULL
                   , [CodingSchemeVersion] nvarchar(16) NULL)

                  ALTER TABLE [AnatomicRegionSequence] ADD CONSTRAINT [PK_SOPInstanceUID_CodeValue_CodingSchemeDesignator] PRIMARY KEY ([SOPInstanceUID],[CodeValue],[CodingSchemeDesignator])
                  ALTER TABLE [AnatomicRegionSequence] ADD CONSTRAINT [FK_AnatomicRegionSequence_Instance] FOREIGN KEY ([SOPInstanceUID]) REFERENCES [Instance]([SOPInstanceUID]) ON DELETE CASCADE ON UPDATE CASCADE
               END
";
       }
   }

   public override string Storage1_11x1
   {
      get
      {
         return
            @"
                IF NOT EXISTS (
                     SELECT *
                     FROM INFORMATION_SCHEMA.COLUMNS
                     WHERE TABLE_NAME = 'HangingProtocol' and COLUMN_NAME = 'UserGroupName'
                )
                ALTER TABLE HangingProtocol ADD [UserGroupName] nvarchar(64) NULL
";
      }
   }

#if (LEADTOOLS_V20_OR_LATER)
   public override string Storage1_12x1
   {
      get
      {
         return
            @"
                IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[MetadataJson]'))
                CREATE TABLE [dbo].[MetadataJson](
	                  [SOPInstanceUID] [nvarchar](64) NOT NULL,
	                [Data] [nvarchar](max) NULL,
                   CONSTRAINT [PK_MetadataJson] PRIMARY KEY CLUSTERED 
                   (
	                  [SOPInstanceUID] ASC
                     )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

               ALTER TABLE [dbo].[MetadataJson]  WITH CHECK ADD FOREIGN KEY([SOPInstanceUID])
               REFERENCES [dbo].[Instance] ([SOPInstanceUID])
               ON UPDATE CASCADE
               ON DELETE CASCADE
            ";
      }
   }

   public override string Storage1_12x2
   {
      get
      {
         return
            @"
                IF NOT EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[MetadataXml]'))
                CREATE TABLE [dbo].[MetadataXml](
	                  [SOPInstanceUID] [nvarchar](64) NOT NULL,
	                [Data] [nvarchar](max) NULL,
                   CONSTRAINT [PK_MetadataXml] PRIMARY KEY CLUSTERED 
                   (
	                  [SOPInstanceUID] ASC
                     )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

               ALTER TABLE [dbo].[MetadataXml]  WITH CHECK ADD FOREIGN KEY([SOPInstanceUID])
               REFERENCES [dbo].[Instance] ([SOPInstanceUID])
               ON UPDATE CASCADE
               ON DELETE CASCADE
            ";
      }
   }


   public override string Storage1_13x1
   {
      get
      {
         return
       @"
          IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[Patient]'))
          Begin
            ALTER TABLE dbo.[Patient] ALTER COLUMN [Comments] NVARCHAR(MAX)
          End
      ";
      }
   }

   public override string Storage1_13x2
   {
      get
      {
         return
            @"
      IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[Study]'))
      Begin
         ALTER TABLE dbo.[Study] ALTER COLUMN [AdditionalPatientHistory] NVARCHAR(MAX)
      End
      ";
      }
   }

   public override string ExportLayout1_1x1
   {
      get
      {
      return
      @" 
      IF NOT EXISTS 
            (	SELECT name 
               FROM sys.stats
               WHERE object_id = OBJECT_ID( 'dbo.ExportLayout')
            )
      Begin

      CREATE TABLE [dbo].[ExportLayout](
	      [SOPInstanceUID] [nvarchar](64) NOT NULL,
	      [ExportDate] [datetime] NULL,
	      [ReferencedFile] [nvarchar](400) NULL,
      CONSTRAINT [PK_ExportLayout] PRIMARY KEY CLUSTERED 
         (
	      [SOPInstanceUID] ASC
         )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
         ) ON [PRIMARY]

      ALTER TABLE [dbo].[ExportLayout]  WITH CHECK ADD  CONSTRAINT [FK_ExportLayout_Instance] FOREIGN KEY([SOPInstanceUID])
         REFERENCES [dbo].[Instance] ([SOPInstanceUID])
         ON UPDATE CASCADE
         ON DELETE CASCADE

      ALTER TABLE [dbo].[ExportLayout] CHECK CONSTRAINT [FK_ExportLayout_Instance]
      END
      ";
      }
   }
#endif // #if (LEADTOOLS_V20_OR_LATER)

         public override string UserManagement1_1x1{ get{return
      @"
       if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Users' and COLUMN_NAME = 'UseCardReader'
             )
         BEGIN
             ALTER TABLE Users ADD UseCardReader [bit] NOT NULL DEFAULT ((0))
         END

       if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Users' and COLUMN_NAME = 'FriendlyName'
             )
         BEGIN
             ALTER TABLE Users ADD FriendlyName [nvarchar](256) NULL
         END
   ";
}}

#if (LEADTOOLS_V20_OR_LATER)
    public override string UserManagement1_2x1{ get{return
      @"
       if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Users' and COLUMN_NAME = 'UserType'
             )
         BEGIN
             ALTER TABLE Users ADD UserType [nvarchar](50) NULL
         END
   ";
}}

         public override string UserManagement1_3x1
         {
            get
            {
               return
@"
       if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Users' and COLUMN_NAME = 'ExtendedName'
             )
         BEGIN
             ALTER TABLE Users ADD ExtendedName [nvarchar](360) NULL
         END
   ";
            }
         }

         public override string UserManagement1_4x1
         {
            get
            {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[UserOptions]'))
            Begin
               ALTER TABLE dbo.[UserOptions] ALTER COLUMN [Value] NVARCHAR(MAX)
            End
         ";
            }
         }
#endif // #if (LEADTOOLS_V20_OR_LATER)

#endif

         public override string Storage1_6x1 { get { return
   @"
   IF NOT EXISTS 
      (	SELECT name 
         FROM sys.stats
         WHERE name = '_dta_stat_Instance1' 
         AND object_id = OBJECT_ID( 'dbo.Instance')
      )
   CREATE STATISTICS [_dta_stat_Instance1] ON [dbo].[Instance]([InstanceNumber], [SeriesInstanceUID])


   IF NOT EXISTS 
      (	SELECT name 
         FROM sys.stats
         WHERE name = '_dta_stat_Instance_2' 
         AND object_id = OBJECT_ID( 'dbo.Instance')
       )
   CREATE STATISTICS [_dta_stat_Instance_2] ON [dbo].[Instance]([SeriesInstanceUID], [SOPInstanceUID])

   IF NOT EXISTS 
      (	SELECT name 
         FROM sys.stats
         WHERE name = '_dta_stat_Series' 
         AND object_id = OBJECT_ID( 'dbo.Series')
       )
   CREATE STATISTICS [_dta_stat_Series] ON [dbo].[Series]([SeriesInstanceUID], [StudyInstanceUID])

   IF NOT EXISTS 
      (	SELECT name 
         FROM sys.stats
         WHERE name = '_dta_stat_Study' 
         AND object_id = OBJECT_ID( 'dbo.Study')
       )
   CREATE STATISTICS [_dta_stat_Study] ON [dbo].[Study]([StudyInstanceUID], [PatientID])

    IF NOT EXISTS 
      (	SELECT name 
         FROM sys.indexes
         WHERE name = 'IX_Instance' 
         AND object_id = OBJECT_ID( 'dbo.Instance')
       )   
   BEGIN
   CREATE NONCLUSTERED INDEX [IX_Instance] ON [dbo].[Instance] 
   (
      [SeriesInstanceUID] ASC
   )WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
   END
   
   
   
   IF NOT EXISTS 
      (	SELECT name 
         FROM sys.indexes
         WHERE name = 'IX_Series' 
         AND object_id = OBJECT_ID( 'dbo.Series')
       )   
   BEGIN
   CREATE NONCLUSTERED INDEX [IX_Series] ON [dbo].[Series] 
   (
      [StudyInstanceUID] ASC
   )WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
   END
   
   
   
   IF NOT EXISTS 
      (	SELECT name 
         FROM sys.indexes
         WHERE name = 'IX_Study' 
         AND object_id = OBJECT_ID( 'dbo.Study')
       )   
   BEGIN
	CREATE NONCLUSTERED INDEX [IX_Study] ON [dbo].[Study] 
	(
		[PatientID] ASC,
		[StudyInstanceUID] ASC
	)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
   END
   " ;
   }}

         public override string Permissions1_5x1 { get { return 
   @"
   CREATE TABLE [RolesList](
	   [RoleName] [nvarchar](50) NOT NULL,
	   [Description] [nvarchar](100) NULL,
    CONSTRAINT [PK_RolesList] PRIMARY KEY CLUSTERED 
   (
      [RoleName] ASC
   ) ON [PRIMARY]
   ) ON [PRIMARY]
   " ; } }
         public override string Permissions1_5x2 { get { return 
   @"
   CREATE TABLE [UserRoles](
	   [UserName] [nvarchar](16) NOT NULL,
	   [RoleName] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
   (
	   [UserName] ASC,
	   [RoleName] ASC
   )ON [PRIMARY]
   ) ON [PRIMARY]
   " ; } }
         public override string Permissions1_5x3 { get { return 
   @"
   CREATE TABLE [dbo].[RolesPermissions](
	   [RoleName] [nvarchar](50) NOT NULL,
	   [Permission] [nvarchar](50) NOT NULL
   ) ON [PRIMARY]
   " ; } }

         public override string Permissions1_6x1
         {
            get
            {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[RoleOptions]'))
            Begin
               ALTER TABLE dbo.[RoleOptions] ALTER COLUMN [Value] NVARCHAR(MAX)
            End
         ";
            }
         }


#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         public override string AeManagement1_1x1 { get { return 
               @"
if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'AeInfo' and COLUMN_NAME = 'FriendlyName'
             )
ALTER TABLE AeInfo ADD [FriendlyName] nvarchar(100) NULL
            "; } }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER) 

#if (LEADTOOLS_V20_OR_LATER)
         public override string AeManagement1_2x1
         {
            get
            {
               return
@"
if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'AeInfo' and COLUMN_NAME = 'PortUsage'
             )
ALTER TABLE AeInfo ADD PortUsage [int] Not NULL Default 1
            ";
            }
         }

         public override string AeManagement1_3x1
         {
            get
            {
               return
@"
if not exists (
                SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'AeInfo' and COLUMN_NAME = 'LastAccessDate'
             )
ALTER TABLE AeInfo ADD LastAccessDate [datetime] NULL Default NULL
            ";
            }
         }

         public override string AeManagement1_4x1
         {
            get
            {
               return
               @"
               IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'RolesAeMapping')
               BEGIN
                  CREATE TABLE[dbo].[RolesAeMapping](

                     [RoleName][nvarchar](50) NOT NULL,

                    [AETitle] [nvarchar](16) NOT NULL
	               ) ON[PRIMARY]
               END
               ";
            }
         }
#endif // #if (LEADTOOLS_V20_OR_LATER)


         public override string Options1_1x1 { 
            get 
               { return
               @"
IF NOT EXISTS 
      (	SELECT name 
         FROM sys.stats
         WHERE object_id = OBJECT_ID( 'dbo.Options')
      )
Begin
   CREATE TABLE [dbo].[Options](
      [Key] [nvarchar](100) NOT NULL,
      [Value] [nvarchar](max) NULL,
         CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
         (
            [Key] ASC
         )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
      )
End
            "; } 
            }

      public override string Options1_2x1
      {
         get
         {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[Options]'))
            Begin
               ALTER TABLE dbo.[Options] ALTER COLUMN [Value] NVARCHAR(MAX)
            End
         ";
         }
      }

         public override string JobsDownload1_1x1
         {

            get
            {
               return
            @"
                IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[JobsQueue]'))
                Begin
                  ALTER TABLE dbo.[JobsQueue] ALTER COLUMN [error] VARCHAR(MAX)
                  ALTER TABLE dbo.[JobsQueue] ALTER COLUMN [object] VARCHAR(MAX)
                  ALTER TABLE dbo.[JobsQueue] ALTER COLUMN [userdata] VARCHAR(MAX)
                End
            ";
            }
         }

         public override string JobsDownload1_1x2
         {
            get
            {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[MonitorCalibration]'))
            Begin
               ALTER TABLE dbo.[MonitorCalibration] ALTER COLUMN [Comments] VARCHAR(MAX)
            End
         ";
            }
         }

         public override string Media1_1x1
         {
            get
            {
               return
            @"
                IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[Configuration]'))
                Begin
                  ALTER TABLE dbo.[Configuration] ALTER COLUMN [Data] VARCHAR(MAX)
                End
            ";
            }
         }

   public override string Media1_1x2
   {
      get
      {
               return
            @"
                IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[MediaInformation]'))
                Begin
                  ALTER TABLE dbo.[MediaInformation] ALTER COLUMN [BarcodeValue] VARCHAR(MAX)
                  ALTER TABLE dbo.[MediaInformation] ALTER COLUMN [MediaDisposition] VARCHAR(MAX)
                End
            ";
      }
   }

   public override string Media1_1x3
   {
      get
      {
               return
             @"
                IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[SeriesVolume]'))
                Begin
                  ALTER TABLE dbo.[SeriesVolume] ALTER COLUMN [UserIdentifier] NVARCHAR(MAX)
                End
            ";
      }
   }

         public override string Worklist1_1x1
         {
            get
            {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[ImagingServiceRequest]'))
            Begin
               ALTER TABLE dbo.[ImagingServiceRequest] ALTER COLUMN [ImagingServiceRequestComments] VARCHAR(MAX)
            End
         ";
            }
         }

         public override string Worklist1_1x2
         {
            get
            {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[PerformedSeriesSequence]'))
            Begin
               ALTER TABLE dbo.[PerformedSeriesSequence] ALTER COLUMN [OperatorName] VARCHAR(MAX)
               ALTER TABLE dbo.[PerformedSeriesSequence] ALTER COLUMN [PerformingPhysicianName] VARCHAR(MAX)
               ALTER TABLE dbo.[PerformedSeriesSequence] ALTER COLUMN [RetrieveAETitle] VARCHAR(MAX)
            End
         ";
            }
         }

         public override string Worklist1_1x3
         {
            get
            {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[RequestedProcedure]'))
            Begin
               ALTER TABLE dbo.[RequestedProcedure] ALTER COLUMN [RequestedProcedureComments] VARCHAR(MAX)
            End
         ";
            }
         }

         public override string Worklist1_1x4
         {
            get
            {
               return
         @"
            IF EXISTS (   SELECT name FROM sys.stats WHERE object_id = OBJECT_ID( 'dbo.[Patient]'))
            Begin
               ALTER TABLE dbo.[Patient] ALTER COLUMN [AdditionalPatientHistory] VARCHAR(MAX)
               ALTER TABLE dbo.[Patient] ALTER COLUMN [PatientComments] VARCHAR(MAX)
            End
         ";
            }
         }

      }    

   class SqlCeScripts : SqlServerScripts
      {
         public override string Storage1_5x1
         {
            get
            {
               return
   @"
   CREATE TABLE [PresentationInstance] (
	   [SOPInstanceUID] [nvarchar] (64) NOT NULL PRIMARY KEY REFERENCES Instance(SOPInstanceUID),
	   [ContentLabel] [nvarchar] (50) NULL ,
	   [CreationDate] [datetime] NULL ,
	   [ContentDescription] [nvarchar] (64) NULL ,
	   [ContentCreatorFamilyName] [nvarchar] (64) NULL ,
	   [ContentCreatorGivenName] [nvarchar] (63) NULL ,
	   [ContentCreatorMiddleName] [nvarchar] (62) NULL ,
	   [ContentCreatorNamePrefix] [nvarchar] (61) NULL ,
	   [ContentCreatorNameSuffix] [nchar] (60) NULL 
   )
   ";
            }
         }

         public override string Storage1_5x2
         {
            get
            {
               return
                  @"
   CREATE TABLE [ReferencedSeriesSequence] (
	   [SeriesInstanceUID] [nvarchar] (64) NOT NULL,
	   [SOPInstanceUID] [nvarchar] (64) NOT NULL,
	   primary key([SeriesInstanceUID],[SOPInstanceUID]),
	   foreign key([SOPInstanceUID]) REFERENCES PresentationInstance(SOPInstanceUID)
   )
   ";
            }
         }

         public override string Storage1_5x3
         {
            get
            {
               return
                  @"
   CREATE TABLE [ReferencedImageSequence] (
	   [SeriesInstanceUID] [nvarchar] (64) NOT NULL,
	   [SOPInstanceUID] [nvarchar] (64) NOT NULL,
	   [ReferencedSOPInstanceUID] [nvarchar] (64) NOT NULL,
	   [ReferencedSOPClassUID] [nvarchar] (64) NOT NULL ,
	   [ItemIndex] [int] IDENTITY (1, 1) NOT NULL,
	   primary key([SeriesInstanceUID],[SOPInstanceUID],[ReferencedSOPInstanceUID]),
	   foreign key([SeriesInstanceUID], [SOPInstanceUID]) REFERENCES ReferencedSeriesSequence(SeriesInstanceUID, SOPInstanceUID)
   )
   ";
            }
         }

#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V18_OR_LATER)
         public override string Storage1_7x1
         {
            get
            {
               return
                  @"
ALTER TABLE Instance ADD [StoreAETitle] nvarchar(16) NULL";
            }
         }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         public override string Storage1_8x1
         {
            get
            {
               return
                  @" 
                 CREATE TABLE [ExternalStore] (
                   [SOPInstanceUID] nvarchar(64) NOT NULL
                 , [StoreDate] datetime NULL
                 , [ExpireDate] datetime NULL
                 , [StoreToken] nvarchar(400) NULL
                 , [ExternalStoreGuid] nvarchar(400) NULL
                 , CONSTRAINT [PK_ExternalStore] PRIMARY KEY ([SOPInstanceUID])
                 , FOREIGN KEY ([SOPInstanceUID]) REFERENCES [Instance] ([SOPInstanceUID]) ON DELETE CASCADE ON UPDATE CASCADE
                 )
";
            }
         }

         public override string Storage1_8x2
         {
            get
            {
               return
                  @"
ALTER TABLE Instance ADD [StoreToken] nvarchar(400) NULL 

GO

ALTER TABLE Instance ADD [ExternalStoreGuid] nvarchar(400) NULL
            ";
            }
         }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)



         public override string Storage1_6x1
         {
            get
            {
               return
                  @"";
            }
         }

#if LEADTOOLS_V19_OR_LATER
         public override string Storage1_9x1
         {
            get
            {
               return @"

             ALTER TABLE ImageInstance ADD EchoNumber [int] NULL
             GO
             ALTER TABLE ImageInstance ADD FrameOfReferenceUID [nvarchar](64) NULL
             GO
             ALTER TABLE ImageInstance ADD SequenceName [nvarchar](16) NULL
             GO
             ALTER TABLE ImageInstance ADD ImagePositionPatient [nvarchar](256) NULL
             GO
             ALTER TABLE ImageInstance ADD ImageOrientationPatient [nvarchar](256) NULL
             GO
             ALTER TABLE ImageInstance ADD PixelSpacing [nvarchar](256) NULL
            ";
            }
         }

         public override string Storage1_10x1
         {
            get
            {
               return
                  @"
                ALTER TABLE Series ADD [Laterality] nvarchar(16) NULL

                GO

                ALTER TABLE Series ADD [ProtocolName] nvarchar(64) NULL

                GO

                  CREATE TABLE [HangingProtocol] (
  [SOPClassUID] nvarchar(64) NOT NULL
, [SOPInstanceUID] nvarchar(64) NOT NULL
, [Name] nvarchar(16) NOT NULL
, [Description] nvarchar(64) NOT NULL
, [Level] nvarchar(16) NOT NULL
, [Creator] nvarchar(64) NOT NULL
, [CreationDateTime] datetime NULL
, [NumberOfPriorsReferenced] int NOT NULL
, [SpecificCharacterSet] nvarchar(16) NULL
, [ReferencedFile] nvarchar(400) NULL
, CONSTRAINT [PK__HangingP__666A30A3282DF8C2] PRIMARY KEY ([SOPInstanceUID])
)

                 GO
                
CREATE TABLE [HangingProtocolDefinitonSequence] (
  [DefinitionSequenceGuid] nvarchar(64) NOT NULL
, [SOPInstanceUID] nvarchar(64) NOT NULL
, [Modality] nvarchar(16) NOT NULL
, [Laterality] nvarchar(16) NULL
, [StudyDescription] nvarchar(64) NULL
, [BodyPartExamined] nvarchar(16) NULL
, [ProtocolName] nvarchar(64) NULL
, CONSTRAINT [PK_DefinitionSequenceGuid] PRIMARY KEY ([DefinitionSequenceGuid])
, FOREIGN KEY ([SOPInstanceUID]) REFERENCES [HangingProtocol] ([SOPInstanceUID]) ON DELETE CASCADE ON UPDATE CASCADE
)
                
                  GO
                    
CREATE TABLE [HangingProtocolAnatomicRegionSequence] (
  [DefinitionSequenceGuid] nvarchar(64) NOT NULL
, [CodeValue] nvarchar(16) NOT NULL
, [CodingSchemeDesignator] nvarchar(16) NOT NULL
, [CodingSchemeVersion] nvarchar(16) NULL
, [CodeMeaning] nvarchar(64) NOT NULL
, FOREIGN KEY ([DefinitionSequenceGuid]) REFERENCES [HangingProtocolDefinitonSequence] ([DefinitionSequenceGuid]) ON DELETE CASCADE ON UPDATE CASCADE
)
   
                  GO
                
                
CREATE TABLE [HangingProtocolProcedureCodeSequence] (
  [DefinitionSequenceGuid] nvarchar(64) NOT NULL
, [CodeValue] nvarchar(16) NOT NULL
, [CodingSchemeDesignator] nvarchar(16) NOT NULL
, [CodingSchemeVersion] nvarchar(16) NULL
, [CodeMeaning] nvarchar(64) NOT NULL
, FOREIGN KEY ([DefinitionSequenceGuid]) REFERENCES [HangingProtocolDefinitonSequence] ([DefinitionSequenceGuid]) ON DELETE CASCADE ON UPDATE CASCADE
)
                    
                  GO
                 
CREATE TABLE [HangingProtocolReasonForRequestedProcedureCodeSequence] (
  [DefinitionSequenceGuid] nvarchar(64) NOT NULL
, [CodeValue] nvarchar(16) NOT NULL
, [CodingSchemeDesignator] nvarchar(16) NOT NULL
, [CodingSchemeVersion] nvarchar(16) NULL
, [CodeMeaning] nvarchar(64) NOT NULL
, FOREIGN KEY ([DefinitionSequenceGuid]) REFERENCES [HangingProtocolDefinitonSequence] ([DefinitionSequenceGuid]) ON DELETE CASCADE ON UPDATE CASCADE
)
                    
                  GO

CREATE TABLE [ReasonForRequestedProcedureCodeSequence] (
  [SeriesInstanceUID] nvarchar(64) NOT NULL
, [CodeValue] nvarchar(16) NOT NULL
, [CodingSchemeDesignator] nvarchar(16) NOT NULL
, [CodeMeaning] nvarchar(64) NULL
, [CodingSchemeVersion] nvarchar(16) NULL
, CONSTRAINT [PK_SeriesInstanceUID_CodeValue_CodingSchemaDesignator] PRIMARY KEY ([SeriesInstanceUID],[CodeValue],[CodingSchemeDesignator])
, FOREIGN KEY ([SeriesInstanceUID]) REFERENCES [Series] ([SeriesInstanceUID]) ON DELETE CASCADE ON UPDATE CASCADE
)

                 GO

CREATE TABLE [AnatomicRegionSequence] (
  [SOPInstanceUID] nvarchar(64) NOT NULL
, [CodeValue] nvarchar(16) NOT NULL
, [CodingSchemeDesignator] nvarchar(16) NOT NULL
, [CodeMeaning] nvarchar(64) NULL
, [CodingSchemeVersion] nvarchar(16) NULL
, CONSTRAINT [PK_SOPInstanceUID_CodeValue_CodingSchemeDesignator] PRIMARY KEY ([SOPInstanceUID],[CodeValue],[CodingSchemeDesignator])
, FOREIGN KEY ([SOPInstanceUID]) REFERENCES [Instance] ([SOPInstanceUID]) ON DELETE CASCADE ON UPDATE CASCADE
)";
            }
         }

         public override string Storage1_11x1
         {
            get
            {
               return
                  @"
                ALTER TABLE HangingProtocol ADD [UserGroupName] nvarchar(64) NULL";
            }
         }

         public override string UserManagement1_1x1
         {
            get
            {
               return
                  @"
             ALTER TABLE Users ADD UseCardReader [bit] NOT NULL DEFAULT ((0))

             GO
            
             ALTER TABLE Users ADD FriendlyName [nvarchar](256) NULL
   ";
            }
         }

#if (LEADTOOLS_V20_OR_LATER)
         public override string UserManagement1_2x1
         {
            get
            {
               return
                  @" ALTER TABLE Users ADD UserType [nvarchar](50) NULL ";
            }
         }

         public override string UserManagement1_3x1
         {
            get
            {
               return
                  @" ALTER TABLE Users ADD ExtendedName [nvarchar](360) NULL ";
            }
         }
#endif // #if (LEADTOOLS_V20_OR_LATER)
#endif

         public override string Permissions1_5x1
         {
            get
            {
               return
                  @"
   CREATE TABLE [RolesList](
	   [RoleName] [nvarchar](50) NOT NULL,
	   [Description] [nvarchar](100) NULL,
	   primary key([RoleName])
   )
   ";
            }
         }
         public override string Permissions1_5x2
         {
            get
            {
               return
                  @"
   CREATE TABLE [UserRoles](
	   [UserName] [nvarchar](16) NOT NULL,
	   [RoleName] [nvarchar](50) NOT NULL,
	   primary key([UserName],[RoleName])
   ) 
   ";
            }
         }
         public override string Permissions1_5x3
         {
            get
            {
               return
                  @"
   CREATE TABLE [RolesPermissions](
	   [RoleName] [nvarchar](50) NOT NULL,
	   [Permission] [nvarchar](50) NOT NULL
   )
   ";
            }
         }

      }
   }
}
