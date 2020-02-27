// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Medical.License.Configuration;
using System.Windows.Forms;
using Leadtools.Logging;
using Leadtools.Logging.Medical ;
using System.Diagnostics;
using Leadtools.Dicom;

namespace Leadtools.Demos.StorageServer
{
   public partial class Shell
   {
      private const string DefaultServiceName = "LTSTORAGESERVER";
      private static void LoadLicense(string licenseFile)
      {
         if (ServerState.Instance.License == null)
         {
            ServerLicense license = new ServerLicense(licenseFile);

            license.Initialize();
            ServerState.Instance.License = license;
         }
         else
         {
            ServerState.Instance.License.Load(licenseFile);
         }
      }

#if LEADTOOLS_V18_OR_LATER
      private static void CheckLicenseFile()
      {
#if LEADTOOLS_V19_OR_LATER
         Leadtools.Demos.Support.SetLicense(true);
#else
         Leadtools.Demos.Support.SetLicense();
#endif
         string applicationName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
         string errorMsg = string.Empty;
         LogType leadLogType = LogType.Information;
         EventLogEntryType eventLogEntryType = EventLogEntryType.Information;
         MessageBoxIcon messageBoxIcon = MessageBoxIcon.None;
         string messageBoxTitle = string.Empty;

#if LEADTOOLS_V19_OR_LATER
         bool isKernelEvaluation = RasterSupport.KernelType == RasterKernelType.Evaluation;
#else
         bool isKernelEvaluation = (RasterSupport.KernelType == RasterKernelType.Evaluation) ||
                             (RasterSupport.KernelType == RasterKernelType.Nag);
#endif // #if LEADTOOLS_V19_OR_LATER

         if (RasterSupport.KernelExpired)
         {
            errorMsg =
               string.Format(
                  "License file is missing, invalid or expired.\r\n'{0}' will function only in a limited mode.\r\n\r\nPlease contact LEAD Sales for information on obtaining a valid license.",
                  applicationName);
            leadLogType = LogType.Error;
            eventLogEntryType = EventLogEntryType.Error;
            messageBoxIcon = MessageBoxIcon.Error;
            messageBoxTitle = "Error";
         }
         else if (isKernelEvaluation)
         {
            errorMsg =
               string.Format(
                  "{0} is running in evaluation mode and will stop running in the future.\r\n\r\nPlease contact LEAD Sales for information on obtaining a valid license.",
                  applicationName);
            leadLogType = LogType.Warning;
            eventLogEntryType = EventLogEntryType.Warning;
            messageBoxIcon = MessageBoxIcon.Warning;
            messageBoxTitle = "Warning";
         }

         if (!string.IsNullOrEmpty(errorMsg))
         {
            MessageBox.Show(
               errorMsg,
               messageBoxTitle,
               MessageBoxButtons.OK,
               messageBoxIcon);

            // StorageServerManager log
            Logger.Global.Log(string.Empty,
                              string.Empty,
                              string.Empty,
                              0,
                              string.Empty,
                              string.Empty,
                              0,
                              DicomCommandType.Undefined,
                              DateTime.Now,
                              leadLogType,
                              MessageDirection.None,
                              errorMsg,
                              null,
                              null
               );

            // Applications and Services Logs -- Leadtools
            System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
            appLog.Source = applicationName;
            appLog.WriteEntry(errorMsg, eventLogEntryType);

            // Windows Logs -- Application Event Log
            using (EventLog eventLog = new EventLog("Application"))
            {
               eventLog.Source = "Application";

               eventLog.WriteEntry(errorMsg, eventLogEntryType, 0, 0);
            }
         }
      }
#endif // #if LEADTOOLS_V18_OR_LATER

      private static void Start(Form form)
      {
         try
         {
            Application.Run(form);
         }
         finally
         {
            Logger.Global.Dispose ( ) ;
         }
      }
 
      public const string storageServerName =
#if (LEADTOOLS_V20_OR_LATER)
         "LEADTOOLS Storage Server 20";
#elif (LEADTOOLS_V19_OR_LATER)
         "LEADTOOLS Storage Server 19";
#else
         "LEADTOOLS Storage Server";
#endif


        public const string storageServerNotes = @"
This is a Fully Functional OEM-ready DICOM Storage server application with source code that includes the following features:

• Storage Add-in that supports query/retrieve and Store with extensive options.

• Logging Add-in that supports many filtering options including Automatic export of logs

• Patient Updater Add-in that includes a patient/study management client that allows users to move, merge, and update patient information using DICOM communications.

• Auto-Copy Add-in that automatically routes retrieved DICOM image data to multiple storage locations.

• Gateway Add-in that acts as a query/retrieve proxy, automatically relaying a single query/retrieve message to any number of specified external DICOM servers.

• Forwarding Add-in that allows DICOM image data to be automatically forwarded to another PACS server immediately upon storage, or on any schedule.

• Administrative options including setting permissions for both users and AE titles.

• Full Source code provided for customization or branding with your own company logo.

" ;
   }

   public abstract class ItemsToolTips
   {
      public const string Gateway = @"The gateway feature allows DICOM servers to be created that act as a proxy to communicate with other DICOM servers on the client’s behalf. This allows clients to send query/retrieve requests only to the gateway server, and those requests are then automatically relayed to any number of additional PACS servers.

The Gateway can forward C-FIND and C-MOVE DICOM messages. The requests will be forwarded to the specified remote DICOM servers and the responses will be forwarded back from the gateway to the requested clients. 

Moved images from remote servers will be stored into the local main storage server database.

Multiple remote servers can specified for each gateway. If one remote server fails to respond, then the next remote server in the list will be used. This continues until one server responds before sending a failure message to the requested client.";

      public const string LoggingConfig = @"The logging configuration allows the server to be configured to control how logging is performed. 

It provides extensive log filtering options including whether to log the DICOM datasets and where to save them.

It also provides an Auto Save feature that dumps the log to text files along with the DICOM datasets at a configurable specific time. The server can optionally be configured to delete the logs from the database after they are saved. 
This feature reduces the amount of logs that accumulate in the database, which helps maintain server performance.";

      public const string DICOMServer = @"The DICOM server settings allow you to create, delete and configure the DICOM Server information such as AE Title, listening IP Address and port number.

Other settings include specifying the clients that are allowed to communicate with the DICOM Server, assigning client permissions, restricting the client count, allow anonymous connections, and a time-out period for idle clients.";

      public const string StorageSettings = @"The storage settings expose a rich set of options that allow complete customization of the storage behavior. Available options include DICOM storage location and file extension, storage folder structure, automatic backup of overwritten stored files, automatic backup of deleted files, and ability to save C-Store and Import failures. 

Other settings allow you to prevent/allow storing duplicate instances, options to allow automatic update of patient, study, series, and instance information, and the ability to automatically create one or more thumbnails per stored image. 

Query settings allow you to validate client request datasets, and customize the storage server response datasets. The storage server can also be configured to accept specific and user-defined storage classes.";


      public const string Forwarding = @"The forwarding feature allows the storage server to be configured so that stored DICOM images can be automatically archived/stored to another PACS server immediately, or on any schedule. 

The schedule can be customized to forward all images in any date range, and can be setup to automatically repeat the forwarding every specified time period. 

Once images have been forwarded, they can optionally be automatically removed from the database after a specified hold time so that the storage server keeps only the most recent data online. 

Advanced features allow you to forward the same images to different servers, and connect to a PACS using a custom AE title.";

   public const string ExternalStore = @"The external store feature allows the storage server to optionally store DICOM datasets to an external store (i.e. a cloud storage).";

      public const string Administration = @"The administration features are available only to administrators. Features include ability to manage users and permissions. Permissions for users include admin, patient updater admin, patient updater edit and delete. 

Other permissions include modify, delete and remove all images from the server. Password complexity and password expiration can be specified, as well as an optional idle-timeout for logged-in users.";

      public const string AutoCopy = @"The auto copy feature allows the storage server to be configured to automatically route moved DICOM image data to any number of PACS servers. 

This feature can be set up so that when the server receives a C-MOVE request to a destination AE it will automatically store it to some other server as well.

When the storage server to connects to the remote PACS servers, it can be configured to optionally use a custom AE title. 

For performance, the auto copy processing can be performed in a user-specified number of different threads.";

      public const string PatientUpdater = @"The patient updater feature allows DICOM clients to send a custom N-Action message to the storage server to seamlessly modify existing patient and study information. 
This feature includes a patient updater client SCU, and a storage server patient updater add-in. 

This feature is useful for updating incorrectly entered information. 
Support includes the ability to copy patients and studies, delete patients and series, move a study to either an existing or a new patient, and merge studies with a new or existing patient. 

Additionally, the storage server can be configured to automatically send the update command to a central PACS server to synchronize changes.";

      public const string SecurityOptions = @"The security options feature allows the storage server to optionally configure DICOM Communications to use Transport Layer Security Protocol.";


   }
}
