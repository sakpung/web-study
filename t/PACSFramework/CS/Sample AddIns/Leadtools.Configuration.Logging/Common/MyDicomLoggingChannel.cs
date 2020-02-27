// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Logging.Medical;
using Leadtools.Logging;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Configuration;
using System.Diagnostics;
using System.IO;

namespace Leadtools.Configuration.Logging
{
   public class MyDicomLoggingChannel : ILoggingChannel
   {
      public const string SettingsChanged = "7A12A6F3-3D78-4855-BE91-A2E144087C06";

      private bool _enabled = true;
      
      #region ILoggingChannel Members

      public MyDicomLoggingChannel()
      {
      }

      public bool Enabled
      {
         get
         {
            return _enabled;
         }
         set
         {
            _enabled = value;
         }
      }

      public void WriteLog(ILogEntry logEntry)
      {
         DicomLogEntry dicomLogEntry = (DicomLogEntry)logEntry;
         DB.AddDicomEventLog(dicomLogEntry);
      }

      #endregion

      #region IDisposable Members

      public void Dispose()
      {
         // nothing
      }

      #endregion
   }

   public class LoggingServerMessage : IProcessServiceMessage
   {

      public const string SettingsChanged = "7A12A6F3-3D78-4855-BE91-A2E144087C06";
      #region IProcessServiceMessage Members

      public bool CanProcess(string MessageId)
      {         
         return (MessageId == LoggingServerMessage.SettingsChanged);
      }

      public Dicom.AddIn.Common.ServiceMessage Process(Dicom.AddIn.Common.ServiceMessage Message)
      {
         switch(Message.Message)
         {
            case LoggingServerMessage.SettingsChanged:
               bool logDatasets = false;
               ConfigurationLoggingSession.CurrentDicomLoggingChannel.Enabled = ConfigurationLoggingSession.ReadSettings(out logDatasets);
               ConfigurationLoggingSession.SetLogDatasets(logDatasets);

               break;
         }
         return null;
      }

      #endregion
   }

}
