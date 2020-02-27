// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Leadtools;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using System.Drawing.Imaging;
using System.Diagnostics;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Logging;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   [Serializable]
   public partial class HL7ServerMWL : IModule, IProcessBreak
   {
      public const string Source = "HL7MWL";

      static TCPServerWorker _serverWorker = null;
      static HL7Options _hl7Options = new HL7Options();

      public static HL7ServerMWL Instance = null;
      
      #region IModule Members
      private static string DatasetDir = string.Empty;

      public void AddServices()
      {
         Instance = this;

         if (_hl7Options.Autostart)
         {
            try
            {
               _serverWorker = new TCPServerWorker(_hl7Options.HL7IPAddress, _hl7Options.HL7Port, Source);
               _serverWorker.Startup();
               SystemMessage(Logger.Global, LogType.Information, "HL7 Server started (listening on IP: " + _hl7Options.HL7IPAddress + ", Port: " + _hl7Options.HL7Port + ")", null);
            }
            catch(Exception e)
            {
               _serverWorker = null;
               SystemMessage(Logger.Global, LogType.Error, "HL7 Server could not start. " + e.Message, Source);
            }
         }
      }

      public static void SystemMessage(Logger logger, LogType type, string description, string aetitle)
      {
         try
         {
            string message = string.Format("[{0}] {1}", Source, description);

            logger.Log(Source, aetitle, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, type, MessageDirection.None, message, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception(Source, exception);
         }
      }

      static public HL7Options HL7Options
      {
         get
         {
            return _hl7Options;
         }
      }

      public static string GetOptionsFile(string ServerDirectory)
      {
         string optionsFile = ServerDirectory;
         if (!optionsFile.EndsWith(@"\"))
            optionsFile += @"\";
         optionsFile += "HL7ServerMWL.xml";

         // Uncomment to show where options file gets loaded
         //string source = "Leadtools.Medical.HL7MWL.AddIn";
         //EventLog.WriteEntry(source, optionsFile, EventLogEntryType.Error, 7);

         return optionsFile;
      }


      public void Load(string ServerDirectory, string DisplayName)
      {
         ILicense license = null;

         if (ServiceLocator.IsRegistered<ILicense>())
            license = ServiceLocator.Retrieve<ILicense>();

         InitializeLicense();
         
         DB.RegisterDataAccessAgents(ServerDirectory, DisplayName);
         InitializeOptions(ServerDirectory, DisplayName);
      }

      public static void InitializeOptions(string ServerDirectory, string DisplayName)
      {
         CheckServerDirectory(ServerDirectory, DisplayName);
         string optionsFile = GetOptionsFile(ServerDirectory);

         try
         {
            if (File.Exists(optionsFile))
               _hl7Options = AddInUtils.DeserializeFile<HL7Options>(optionsFile);
            else
               AddInUtils.Serialize<HL7Options>(_hl7Options, optionsFile);
         }
         catch
         {
            _hl7Options = new HL7Options();
         }
      }

      /// <summary>
      /// Checks the server directory.  This is the directory where service addins will be added.
      /// </summary>
      /// <param name="ServerDirectory">The server directory.</param>
      /// <param name="DisplayName">The display name.</param>
      private static void CheckServerDirectory(string ServerDirectory, string DisplayName)
      {
         if (!Directory.Exists(ServerDirectory))
         {
            Directory.CreateDirectory(ServerDirectory);
         }

         //
         // Create Server Log directory
         //
         if (!Directory.Exists(ServerDirectory + @"\Log\"))
         {
            Directory.CreateDirectory(ServerDirectory + @"\Log\");
         }

         //
         // Create Server Dataset directory
         //
         DatasetDir = ServerDirectory + @"\Log\Datasets\";
         if (!Directory.Exists(DatasetDir))
         {
            Directory.CreateDirectory(DatasetDir);
         }
      }
      #endregion     

      #region IProcessBreak Members
      public void Break(BreakType type)
      {
         Instance = null;

         if (_serverWorker != null)
         {
            _serverWorker.Dispose();
         }
      }
      #endregion
   }
}
