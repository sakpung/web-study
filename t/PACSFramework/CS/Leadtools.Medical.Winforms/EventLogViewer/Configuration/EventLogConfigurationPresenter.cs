// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Logging;

namespace Leadtools.Medical.Winforms
{
   public class EventLogConfigurationPresenter
   {
      public void RunView ( EventLogConfigurationView view, LoggingState logState ) 
      {
         View  = view ;
         State = logState ;
         
         ResetView ( ) ;
         View.SettingsChanged += new EventHandler(View_SettingsChanged);

         View.EnableLoggingChanged += new EventHandler(View_EnableLoggingChanged);
         View.EnableThreadingChanged += new EventHandler(View_EnableThreadingChanged);
         View.LogInformationChanged += new EventHandler(View_LogInformationChanged);
         View.LogWarningsChanged += new EventHandler(View_LogWarningsChanged);
         View.LogDebugChanged += new EventHandler(View_LogDebugChanged);
         View.LogErrorChanged += new EventHandler(View_LogErrorChanged);
         View.LogAuditChanged += new EventHandler(View_LogAuditChanged);
         View.LogDicomMessagesChanged += new EventHandler(View_LogDicomMessagesChanged);
         View.LogDicomDatasetChanged += new EventHandler(View_LogDicomDatasetChanged);
         View.DataSetDirectoryChanged += new EventHandler(View_DataSetDirectoryChanged);
         View.EnableAutoSaveLogChanged += new EventHandler(View_EnableAutoSaveLogChanged);
         View.AutoSaveDaysChanged += new EventHandler(View_AutoSaveDaysChanged);
         View.AutoSaveTimeChanged += new EventHandler(View_AutoSaveTimeChanged);
         View.AutoSaveDirectoryChanged += new EventHandler(View_AutoSaveDirectoryChanged);
         View.DeleteSavedLogChanged += new EventHandler(View_DeleteSavedLogChanged);
      }

      void View_DeleteSavedLogChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.DeleteSavedLogChanged.Key,
            string.Format(AuditMessages.DeleteSavedLogChanged.Message, View.DeleteSavedLog));
      }

      void View_AutoSaveDirectoryChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AutoSaveDirectoryChanged.Key,
            string.Format(AuditMessages.AutoSaveDirectoryChanged.Message, View.AutoSaveDirectory));
      }

      void View_AutoSaveTimeChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AutoSaveTimeChanged.Key,
            string.Format(AuditMessages.AutoSaveTimeChanged.Message, View.AutoSaveTime));
      }

      void View_AutoSaveDaysChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.AutoSaveDaysPeriodChanged.Key,
            string.Format(AuditMessages.AutoSaveDaysPeriodChanged.Message, View.AutoSaveDaysPeriod));
      }

      void View_EnableAutoSaveLogChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.EnableAutoSaveLogChanged.Key,
            string.Format(AuditMessages.EnableAutoSaveLogChanged.Message, View.EnableAutoSaveLog));
      }

      void View_DataSetDirectoryChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.DataSetDirectoryChanged.Key,
            string.Format(AuditMessages.DataSetDirectoryChanged.Message, View.DataSetDirectory));
      }

      void View_LogDicomDatasetChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LogDicomDatasetChanged.Key,
            string.Format(AuditMessages.LogDicomDatasetChanged.Message, View.LogDicomDataSet));
      }

      void View_LogDicomMessagesChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LogDicomChanged.Key,
            string.Format(AuditMessages.LogDicomChanged.Message, View.LogDicom));
      }

      void View_LogErrorChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LogErrorChanged.Key,
            string.Format(AuditMessages.LogErrorChanged.Message, View.LogErrors));
      }


      void View_LogAuditChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LogAuditChanged.Key,
            string.Format(AuditMessages.LogAuditChanged.Message, View.LogErrors));
      }

      void View_LogDebugChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LogDebugChanged.Key,
            string.Format(AuditMessages.LogDebugChanged.Message, View.LogDebug));
      }

      void View_LogWarningsChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LogWarningsChanged.Key,
            string.Format(AuditMessages.LogWarningsChanged.Message, View.LogWarnings));
      }

      void View_LogInformationChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.LogInformationChanged.Key,
            string.Format(AuditMessages.LogInformationChanged.Message, View.LogInformation));
      }

      void View_EnableThreadingChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.EnableThreadingChanged.Key,
            string.Format(AuditMessages.EnableThreadingChanged.Message, View.EnableThreading));
      }

      void View_EnableLoggingChanged(object sender, EventArgs e)
      {
         LocalAuditLogQueue.AddAuditMessage(AuditMessages.EnableLoggingChanged.Key,
            string.Format(AuditMessages.EnableLoggingChanged.Message, View.EnableLogging));
      }

      public event EventHandler SettingsChanged;
      
      private void View_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      public bool IsDirty
      {
         get
         {
            return View.IsDirty;
         }
      }
      
      public void UpdateState ( ) 
      {
         State.EnableLogging   = View.EnableLogging ;
         State.EnableThreading = View.EnableThreading ;
         State.LogInformation  = View.LogInformation ;
         State.LogWarnings     = View.LogWarnings ;
         State.LogDebug        = View.LogDebug ;
         State.LogErrors       = View.LogErrors ;
         State.LogAudit        = View.LogAudit ;
         State.LogDicom        = View.LogDicom;
         State.LogDicomDataSet = View.LogDicomDataSet ;
         
         State.EnableAutoSaveLog  = View.EnableAutoSaveLog ;
         State.AutoSaveDaysPeriod = View.AutoSaveDaysPeriod ;
         State.AutoSaveTime       = View.AutoSaveTime ;
         State.AutoSaveDirectory  = View.AutoSaveDirectory ;
         State.DeleteSavedLog     = View.DeleteSavedLog ;
         State.DataSetDirectory   = View.DataSetDirectory ;
      }
      
      public EventLogConfigurationView View
      {
         get ;
         private set ;
      }
      
      public LoggingState State
      {
         get ;
         private set ;
      }
      
      public void ResetView ( ) 
      {
         View.EnableLogging   = State.EnableLogging ;
         View.EnableThreading = State.EnableThreading ;
         View.LogInformation  = State.LogInformation ;
         View.LogWarnings     = State.LogWarnings ;
         View.LogDebug        = State.LogDebug ;
         View.LogAudit        = State.LogAudit ;
         View.LogErrors       = State.LogErrors ;
         View.LogDicom        = State.LogDicom;
         View.LogDicomDataSet = State.LogDicomDataSet ;
         
         View.EnableAutoSaveLog  = State.EnableAutoSaveLog  ;
         View.AutoSaveDaysPeriod = State.AutoSaveDaysPeriod ;
         View.AutoSaveTime       = State.AutoSaveTime       ;
         View.AutoSaveDirectory  = State.AutoSaveDirectory  ;
         View.DeleteSavedLog     = State.DeleteSavedLog     ;
         View.DataSetDirectory   = State.DataSetDirectory ;
      }
      
      public void ResetState ( LoggingState state )
      {
         State = state ;
         
         ResetView ( ) ;
      }
      
      public bool EnableView
      {
         get
         {
            return View.Enabled ;
         }
         
         set
         {
            View.Enabled = value ;
         }
      }
   }
}
