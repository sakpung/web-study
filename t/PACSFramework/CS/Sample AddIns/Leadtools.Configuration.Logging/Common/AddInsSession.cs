// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Diagnostics;
using Leadtools.Logging;
using Leadtools.Configuration.Logging;
using Leadtools.Dicom.AddIn.Configuration;

// The Dicom Communication Logging is handled by creating a ILoggingChannel (MyDicomLoggingChannel) and adding to Logger.Global.LoggingChannels.  
// This is done in the Leadtools.Configuration.Logging addin when it is first loaded and configured by the DICOM Service. 
// When the CSLeadtools.Dicom.Server.Manager.exe changes the 'Enable Logging' option in the server manager 'Event Log' dialog, the CSLeadtools.Dicom.Server.Manager.exe updates the 'advanced.config' of the corresponding DICOM Service to reflect this setting
// The CSLeadtools.Dicom.Server.Manager.exe then sends a message to the Leadtools.Configuration.Logging.dll to tell it to reread its advanced.config, and update the 'Enabled' option of its corresponding MyDicomLoggingChannel


namespace Leadtools.Configuration.Logging
{
   public class ConfigurationLoggingSession : IServerConfig
   {

      internal static MyDicomLoggingChannel CurrentDicomLoggingChannel = null;
      public static string ConnectionString = string.Empty;
      public static string LogDatasetDirectory = string.Empty;
      public static string LogDatabaseDirectory = string.Empty;
      public static string LogDatabaseFullPath = string.Empty;
      public static string ServerDirectory = string.Empty;

      public const string LogDatabaseName = "Logging.sdf";
      public const string AddinName = "Leadtools.Configuration.Logging";
      public const string EnableLogOptionName = "EnableLog";
      public const string LogDatasetsOptionName = "LogDatasets";

      private static bool _logDatasets;
      public static bool LogDatasets
      {
         get { return _logDatasets; }
         set { _logDatasets = value; }
      }


      public static bool ReadSettings(out bool logDatasets)
      {
         AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);
         settings.RefreshSettings();

         logDatasets = false;
         string sRet = settings.GetAddInOption(ConfigurationLoggingSession.AddinName, ConfigurationLoggingSession.LogDatasetsOptionName);
         Boolean.TryParse(sRet, out logDatasets);
         _logDatasets = logDatasets;

         bool enableLog = false;
         sRet = settings.GetAddInOption(ConfigurationLoggingSession.AddinName, ConfigurationLoggingSession.EnableLogOptionName);
         if (Boolean.TryParse(sRet, out enableLog))
         {
            return enableLog;
         }
         return true;
      }

      public static void WriteSettings(bool enableLog, bool logDatasets)
      {
         AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);
         settings.SetAddInOption(ConfigurationLoggingSession.AddinName, ConfigurationLoggingSession.EnableLogOptionName, enableLog.ToString());
         settings.SetAddInOption(ConfigurationLoggingSession.AddinName, ConfigurationLoggingSession.LogDatasetsOptionName, logDatasets.ToString());

         _logDatasets = logDatasets;
         SetLogDatasets(false);

         settings.Save();
      }

      public static void SetLogDatasets(bool logDatasets)
      {
         if (logDatasets)
         {
             LogDatasetDirectory = Path.Combine(LogDatabaseDirectory, @"Log\Datasets");
         }
         else
         {
            LogDatasetDirectory = string.Empty;
         }
      }


      public void Configure(Leadtools.Dicom.AddIn.DicomServer server)
      {
         ServerDirectory = server.ServerDirectory;

         CurrentDicomLoggingChannel = new MyDicomLoggingChannel();

         Logger.Global.LoggingChannels.Add(CurrentDicomLoggingChannel);

         LogDatabaseDirectory = server.ServerDirectory;
         LogDatabaseFullPath = Path.Combine(LogDatabaseDirectory, LogDatabaseName);

         ConnectionString = "Data Source='" + LogDatabaseFullPath + "'";

         ReadSettings(out _logDatasets);
         SetLogDatasets(_logDatasets);

         if (!File.Exists(LogDatabaseFullPath))
         {
            string fullname = GetResourceFullName(LogDatabaseName);
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullname);

            if (stream != null)
            {
               FileStream fs = new FileStream(LogDatabaseFullPath, FileMode.CreateNew);
               byte[] data = new byte[stream.Length];

               stream.Read(data, 0, (int)stream.Length);
               fs.Write(data, 0, (int)stream.Length);
               fs.Close();
            }
         }
      }

      private static string GetResourceFullName(string resName)
      {
         string fullName = null;

         foreach (string str in Assembly.GetExecutingAssembly().GetManifestResourceNames())
         {
            if (str.EndsWith(resName))
            {
               fullName = str;
               break;
            }
         }
         return fullName;

      }
   }
}
