// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Linq;

using Leadtools.DataAccessLayers;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Medical.WebViewer.Annotations;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using System.Configuration;
using Leadtools.Medical.WebViewer.Common;
using System.Xml.Linq;
using Leadtools.Medical.WebViewer.Wado;

namespace Leadtools.Medical.WebViewer.Services
{
   public sealed class ConnectionSettings
   {
      public string StorageServerServicePath;
      public PACSConnection StorageServerConnection;
      public PACSConnection ClientConnection;

      public ConnectionSettings()
      {
         ReadAppSettings();
      }

      private void ReadAppSettings()
      {
         StorageServerServicePath = ServiceUtils.MapConfigPath(ConfigurationManager.AppSettings.Get("storageServerServicePath"));

         {
            ClientConnection = new PACSConnection();

            //the client AE/IP/port used for connecting to remote PACS for query
            ClientConnection.AETitle = ConfigurationManager.AppSettings.Get("ClientAe");
            if (string.IsNullOrEmpty(ClientConnection.AETitle))
            {
               ClientConnection.AETitle = "LTCLIENT19";
            }
            ClientConnection.IPAddress = ConfigurationManager.AppSettings.Get("ClientIP");
            if (string.IsNullOrEmpty(ClientConnection.IPAddress))
            {
               ClientConnection.IPAddress = ServiceUtils.GetLocalIPAddressesV4();
            }

            ClientConnection.Port = ParseTools.Int(ConfigurationManager.AppSettings.Get("ClientPort"), ServiceUtils.GetFreeIPPort());
         }

         {
            StorageServerConnection = new PACSConnection();
            StorageServerConnection.AETitle = ConfigurationManager.AppSettings.Get("ServerAe");
            StorageServerConnection.IPAddress = ConfigurationManager.AppSettings.Get("ServerIP");
            StorageServerConnection.Port = ParseTools.Int(ConfigurationManager.AppSettings.Get("ServerPort"), -1);

            //read default storage server dicom connection settings
            if (!string.IsNullOrEmpty(StorageServerServicePath) &&
               (string.IsNullOrEmpty(StorageServerConnection.AETitle) ||
               string.IsNullOrEmpty(StorageServerConnection.IPAddress) ||
               StorageServerConnection.Port <= 0))
            {
               try
               {
                  var settingsFile = Path.Combine(StorageServerServicePath, "settings.xml");
                  var doc = XDocument.Load(settingsFile);
                  {
                     StorageServerConnection.Port = ParseTools.Int(doc.Descendants("Port").First().Value, -1);
                     StorageServerConnection.IPAddress = doc.Descendants("IpAddress").First().Value;
                     StorageServerConnection.AETitle = doc.Descendants("AETitle").First().Value;
                  }
               }
               catch
               {
               }
            }

            if (string.IsNullOrEmpty(StorageServerConnection.AETitle))
            {
               StorageServerConnection.AETitle = "LTSTORAGESERVER";
            }
         }
      }
   }
}
