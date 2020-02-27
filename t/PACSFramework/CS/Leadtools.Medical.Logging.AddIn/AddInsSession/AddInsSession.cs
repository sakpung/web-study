// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Logging;
using Leadtools.Medical.Winforms;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn.Configuration;
using System.Diagnostics;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Security.Principal;
using System.Security.AccessControl;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;
using System.Configuration;
using System.Collections;
using System.Threading;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.DataAccessLayer.Configuration;
#endif

namespace Leadtools.Medical.Logging.Addins
{
   public class LoggingConfigurationSession : IServerConfig
   {
      public void Configure ( DicomServer server )
      {  
         LoggingModuleConfigurationManager loggingConfigManager ;
         CommandAsyncProcessor             service ;
         
         _server          = server ;
         ServiceDirectory = server.ServerDirectory ;
         DisplayName      = server.Name;
         
         loggingConfigManager = new LoggingModuleConfigurationManager ( true ) ;
         
         loggingConfigManager.Load ( ServiceDirectory ) ;
         
         ServiceLocator.Register <LoggingModuleConfigurationManager> ( loggingConfigManager ) ;
         
         _loggingConfigManager = loggingConfigManager ;
         
         RegisterDataAccessAgents ( ServiceDirectory, DisplayName ) ;
         
         CheckPermissions ( loggingConfigManager.GetLoggingState ( ) ) ;
         
         ConfigureLogger ( Logger.Global, loggingConfigManager.GetLoggingState ( ), DataAccessServices.GetDataAccessService <ILoggingDataAccessAgent2> ( ) ) ;
         
         service = RegisterAutoSaveLogService ( loggingConfigManager.GetLoggingState ( ) ) ;
         
         if (service != null)
         {
            StartStopService(loggingConfigManager.GetLoggingState(), service);
         }
         
         loggingConfigManager.SettingsUpdated += new EventHandler ( loggingConfigManager_SettingsUpdated ) ;
      }

      public static void ConfigureLogger ( Logger logger, LoggingState loggingState, ILoggingDataAccessAgent2 dataAccess )
      {
         logger.Enabled         = loggingState.EnableLogging ;
         logger.EnableThreading = loggingState.EnableThreading ;
         
         if ( logger.Filter is EventLogFilter ) 
         {
            EventLogFilter filter = ( EventLogFilter ) logger.Filter ;
            
            
            filter.LogErrors      = loggingState.LogErrors ;
            filter.LogInformation = loggingState.LogInformation ;
            filter.LogWarnings    = loggingState.LogWarnings ;
            filter.LogDebug       = loggingState.LogDebug ;
            filter.LogAudit       = loggingState.LogAudit ;
         }

         DataAccessLoggingChannel[] channels = logger.LoggingChannels.OfType<DataAccessLoggingChannel>().ToArray();
         
         if( channels.Length > 0 )
         {
            foreach ( DataAccessLoggingChannel channel in logger.LoggingChannels.OfType <DataAccessLoggingChannel> ( ) )
            {
               channel.LogDataAccessAgent = dataAccess ;

               channel.LogDicomDataSet = loggingState.LogDicomDataSet ;
               
               channel.LogDicomCommunication = loggingState.LogDicom;

               ConfigureLoggingChannel ( channel, loggingState ) ;
            }
         }
         else
         {
            DataAccessLoggingChannel channel = new DataAccessLoggingChannel ( dataAccess ) ;

            channel.LogDicomDataSet = loggingState.LogDicomDataSet;

            channel.LogDicomCommunication = loggingState.LogDicom;
            
            ConfigureLoggingChannel ( channel, loggingState ) ;
            
            logger.LoggingChannels.Clear ( ) ;
            logger.LoggingChannels.Add ( channel ) ;
         }
         
         logger.Logging -= new EventHandler<LogEventArgs> ( Logger_Logging ) ;
         logger.Logged  -= new EventHandler<LogEventArgs>  ( Logger_Logged ) ;
         
         logger.Logging += new EventHandler<LogEventArgs> ( Logger_Logging ) ;
         logger.Logged += new EventHandler<LogEventArgs>  ( Logger_Logged ) ;
      }

      private static void ConfigureLoggingChannel ( DataAccessLoggingChannel channel, LoggingState logginState )
      {
         if ( channel.LogDataAccessAgent is LoggingSqlDataAccessAgent )
         {
            LoggingSqlDataAccessAgent agent = (LoggingSqlDataAccessAgent)channel.LogDataAccessAgent ;

            agent.CopyDicomDataSetOnDisk = true ;
            
            agent.DataSetFolder = logginState.DataSetDirectory ;
         }
      }

      public void CheckPermissions ( LoggingState loggingState )
      {
         WindowsIdentity identity = WindowsIdentity.GetCurrent();
         DirectorySecurity security;
         FileSystemRights rights;
         string message = string.Empty;

         try
         {
            if (Directory.Exists(loggingState.AutoSaveDirectory))
            {
               security = Directory.GetAccessControl(loggingState.AutoSaveDirectory);
               rights = GetDirectoryRights(security, identity);
               message = string.Format("PERMISSIONS => Auto Log Location ({0}): \r\n{1}", loggingState.AutoSaveDirectory, rights);
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                 LogType.Information, MessageDirection.None, message, null, null);
            }
            else
            {
               message = string.Format("Auto Log directory ({0}) doesn't exist.  Cannot determine permissions.", loggingState.AutoSaveDirectory);
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                 LogType.Information, MessageDirection.None, message, null, null);
            }
         }        
         catch (Exception e)
         {
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                              LogType.Information, MessageDirection.None, e.Message, null, null);
         }

         try
         {
            if (Directory.Exists(loggingState.DataSetDirectory))
            {
               security = Directory.GetAccessControl(loggingState.DataSetDirectory);
               rights = GetDirectoryRights(security, identity);
               message = string.Format("PERMISSIONS => Auto Log Dataset Location ({0}): \r\n{1}", loggingState.DataSetDirectory, rights);
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                 LogType.Information, MessageDirection.None, message, null, null);
            }
            else
            {
               message = string.Format("Auto Log dataset directory ({0}) doesn't exist.  Cannot determine permissions.", loggingState.DataSetDirectory);
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                 LogType.Information, MessageDirection.None, message, null, null);
            }
         }        
         catch (Exception e)
         {
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                              LogType.Information, MessageDirection.None, e.Message, null, null);
         }
      }

      private FileSystemRights GetDirectoryRights(DirectorySecurity security, WindowsIdentity id)
      {
         FileSystemRights allowedRights = 0;
         FileSystemRights deniedRights = 0;

         foreach (FileSystemAccessRule rule in
                    security.GetAccessRules(true, true, id.User.GetType()))
         {
            //If the identity associated with the rule        
            //matches the user or any of their groups  
            if (rule.IdentityReference.Equals(id) || id.Groups.Contains(rule.IdentityReference))
            {
               uint right = (uint)rule.FileSystemRights & 0x00FFFFFF;

               //Filter out the generic rights so we get a           
               //nice enumerated value  
               if (rule.AccessControlType == AccessControlType.Allow)
                  allowedRights |= (FileSystemRights)(right);
               else
                  deniedRights |= (FileSystemRights)(right);
            }
         }

         return allowedRights ^ deniedRights;
      } 

      private static void StartStopService ( LoggingState logState, CommandAsyncProcessor service )
      {
         if ( service.Disposed ) 
         {
            return ;
         }
         
         if ( logState.EnableAutoSaveLog )
         {            
            service.Start ( ) ;
         }
         else
         {
            service.Stop ( ) ;
         }
      }

      private CommandAsyncProcessor RegisterAutoSaveLogService ( LoggingState logState )
      {
         AutoSaveLogCommand      autoSaveCommand ;
         CommandAsyncProcessor   service = null;
         IOptionsDataAccessAgent optionsDataAccess  = null;

         optionsDataAccess = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();

         if (optionsDataAccess != null)
         {            
            autoSaveCommand = new AutoSaveLogCommand(logState);
            service = new CommandAsyncProcessor();

            if (logState.EnableAutoSaveLog)
            {
               string nextLogDate;


               nextLogDate = optionsDataAccess.Get<string>(NextLogDateSettingsName, null, new Type[0]);

               if (!string.IsNullOrEmpty(nextLogDate))
               {
                  DateTime nextLog = DateTime.Parse(nextLogDate);

                  if (DateTime.Now > nextLog)
                  {
                     autoSaveCommand.Execute();
                  }
               }
            }

            service.Commands.Add(autoSaveCommand);

            ConfigureServiceIntervals(logState, service, optionsDataAccess);

            service.CommandsExecuted += new EventHandler(service_CommandsExecuted);

            ServiceLocator.Register<CommandAsyncProcessor>(service);
         }
         
         return service ;
      }

      private void ConfigureServiceIntervals
      (
         LoggingState logState, 
         CommandAsyncProcessor service, 
         IOptionsDataAccessAgent optionsDataAccess
      )
      {
         DateTime dueDate = GetDueDate ( logState ) ;
         
         SetNextLogDate ( dueDate, logState, optionsDataAccess ) ;
         
         TimeSpan due      = dueDate.Subtract ( DateTime.Now ) ;
         TimeSpan interval = new TimeSpan ( logState.AutoSaveDaysPeriod, 0, 0, 0 ) ;
         
         service.DueTime   = due ;
         service.Interval  = interval ;
         
         service.RefreshDueIntervalTimes ( ) ;
      }

      private static DateTime GetDueDate ( LoggingState logState )
      {
         DateTime dueDate ;

         dueDate = new DateTime ( DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, logState.AutoSaveTime.Hour, logState.AutoSaveTime.Minute, logState.AutoSaveTime.Second ) ;
         
         if ( DateTime.Now > dueDate )
         {
            dueDate = dueDate.AddDays ( logState.AutoSaveDaysPeriod ) ;
         }
         
         return dueDate;
      }

      private void SetNextLogDate ( DateTime nextLogDate, LoggingState logState, IOptionsDataAccessAgent optionsDataAccess )
      {
         nextLogDate = new DateTime ( nextLogDate.Year, 
                                      nextLogDate.Month, 
                                      nextLogDate.Day, 
                                      logState.AutoSaveTime.Hour, 
                                      logState.AutoSaveTime.Minute, 
                                      logState.AutoSaveTime.Second ) ;

         
         optionsDataAccess.Set<string> ( NextLogDateSettingsName, nextLogDate.ToString ( ), new Type[0] ) ;
      }
      
      void loggingConfigManager_SettingsUpdated ( object sender, EventArgs e )
      {
         try
         {
            LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
            CommandAsyncProcessor             service              = ServiceLocator.Retrieve <CommandAsyncProcessor> ( ) ;
            
            ConfigureLogger ( Logger.Global, 
                              loggingConfigManager.GetLoggingState ( ), 
                              DataAccessServices.GetDataAccessService <ILoggingDataAccessAgent2> ( ) ) ;
                              
            StartStopService ( loggingConfigManager.GetLoggingState ( ), 
                               service ) ;
            
            IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService <IOptionsDataAccessAgent> ( );
            if (optionsAgent != null)
            {
               ConfigureServiceIntervals(loggingConfigManager.GetLoggingState(),
                                           service, optionsAgent);
            }
         }
         catch ( Exception exception )
         {
            Log ( LogType.Error, "Logging Config Error: " + exception.Message ) ;
         }
      }

      void service_CommandsExecuted ( object sender, EventArgs e )
      {
         try
         {
            LoggingModuleConfigurationManager configurationManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
            CommandAsyncProcessor service = ServiceLocator.Retrieve <CommandAsyncProcessor> ( ) ;
            
            IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService <IOptionsDataAccessAgent> ( );
            if (optionsAgent != null)
            {
               if (null != service && configurationManager.GetLoggingState().EnableAutoSaveLog)
               {
                  DateTime nextLogDate = DateTime.Now.AddDays(service.Interval.Days);

                  SetNextLogDate(nextLogDate,
                                   configurationManager.GetLoggingState(),
                                   optionsAgent);
               }
            }
         }
         catch ( Exception exception )
         {
            Log ( LogType.Error, "Logging Config Error: " + exception.Message ) ;
         }
      }
      
      static void Logger_Logging(object sender, LogEventArgs e)
      {
         try
         {
            DicomLogEntry entry = e.LogEntry as DicomLogEntry;

            if (entry != null && entry.DicomDataset != null )
            {
               LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
               
               if ( null == loggingConfigManager ) 
               {
                  return ;
               }
               
               LoggingState state = loggingConfigManager.GetLoggingState ( ) ;
               
                if ( state.EnableLogging && 
                     state.EnableThreading&& 
                     state.LogDicomDataSet && 
                     state.LogDicom )
                {                
                   entry.DicomDataset = Copy(entry.DicomDataset);
                }
            }
         }
         catch{}
      }

      static void Logger_Logged(object sender, LogEventArgs e)
      {
         try
         {
            DicomLogEntry entry = e.LogEntry as DicomLogEntry;

            if (entry != null && entry.DicomDataset != null )
            {
               LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
               
               if ( null == loggingConfigManager ) 
               {
                  return ;
               }
               
               LoggingState state = loggingConfigManager.GetLoggingState ( ) ;
               
               if ( state.EnableLogging && 
                    state.EnableThreading&& 
                    state.LogDicomDataSet && 
                    state.LogDicom )
               {
                  try
                  {
                     entry.DicomDataset.Dispose();
                  }
                  catch { }
               }
            
            }
         }
         catch{}
      }
       
       private static DicomDataSet Copy ( DicomDataSet dsOriginal )
       {          
          DicomDataSet copy = new DicomDataSet();          
          AutoResetEvent copyEvent = new AutoResetEvent(false);

          if (dsOriginal == null)
             return null;

          try
          {
             copy.Copy(dsOriginal, null, null, DicomCopyCallback);
          }
          catch(Exception  e)
          {
             Exception ex = e;
             string errorMessage = string.Empty;

             while (ex != null)
             {
                errorMessage += ex.ToString() + "\r\n";
                ex = ex.InnerException;
             }

             try
             {
                DicomLogEntry logEntry = new DicomLogEntry();

                logEntry.ClientAETitle = "Logger";
                logEntry.Description = errorMessage;
                logEntry.LogType = LogType.Error;

                Logger.Global.Log(logEntry);
             }
             catch { }
          }
          return copy;
       }
       
      public static bool DicomCopyCallback ( DicomElement element, DicomCopyFlags flags )
      {
         return true ;
      }

      private static void RegisterDataAccessAgents ( string serviceDirectory, string serviceName ) 
      {
         if ( !DataAccessServices.IsDataAccessServiceRegistered <ILoggingDataAccessAgent2> ( ) )
         {
            ILoggingDataAccessAgent2 loggingDataAccess ;
            
            
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration ( serviceDirectory ) ;
            loggingDataAccess = DataAccessFactory.GetInstance ( new LoggingDataAccessConfigurationView ( configuration, null, serviceName ) ).CreateDataAccessAgent <ILoggingDataAccessAgent2> ( ) ;
            
            DataAccessServices.RegisterDataAccessService <ILoggingDataAccessAgent2> ( loggingDataAccess ) ;
         }
         
         
         try
         {
         if ( !DataAccessServices.IsDataAccessServiceRegistered <IOptionsDataAccessAgent> ( ) )
         {
            IOptionsDataAccessAgent optionsDataAccess ;
            
            
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration ( serviceDirectory ) ;
            optionsDataAccess = DataAccessFactory.GetInstance ( new OptionsDataAccessConfigurationView ( configuration, null, serviceName ) ).CreateDataAccessAgent <IOptionsDataAccessAgent> ( ) ;
            
            DataAccessServices.RegisterDataAccessService <IOptionsDataAccessAgent> ( optionsDataAccess ) ;
         }
         }
         catch(Exception )
         {
            // Workstation does not use IOptionsDataAccessAgent, so ignore if not registered
         }
      }
      
      private void Log ( LogType type, string description ) 
      {
         Logger.Global.Log ( _server.AETitle, 
                             _server.HostAddress, 
                             _server.Port, 
                             string.Empty, 
                             string.Empty, 
                             0, 
                             DicomCommandType.Undefined, 
                             DateTime.Now, 
                             type, 
                             MessageDirection.None, 
                             description, null, null ) ;
      }

      public static string ServiceDirectory
      {
         get ;
         set ;
      }

      public static string DisplayName
      {
         get;
         set;
      }
      
      private DicomServer _server ;
      
      private LoggingModuleConfigurationManager _loggingConfigManager ;
      
      private const string NextLogDateSettingsName = "NextLogDate" ;
   }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
   public class LoggingServerMessage : IProcessServiceMessage
   {
      #region IProcessServiceMessage Members

      public bool CanProcess(string MessageId)
      {
         return (
                 MessageId == MessageNames.IsAddinHealthy
                 );
      }

      private string _assemblyName = string.Empty;
      public string AssemblyName
      {
         get
         {
            if (string.IsNullOrEmpty(_assemblyName))
            {
               System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
               if (assembly != null)
               {
                  _assemblyName = assembly.ManifestModule.Name;
               }
            }
            return _assemblyName;
         }
      }

      public static T GetAgent<T>(System.Configuration.Configuration configuration, DataAccessConfigurationView view)
      {
         T agent;

         if (!DataAccessServices.IsDataAccessServiceRegistered<T>())
         {
            agent = DataAccessFactory.GetInstance(view).CreateDataAccessAgent<T>();
            DataAccessServices.RegisterDataAccessService<T>(agent);
         }
         else
         {
            agent = DataAccessServices.GetDataAccessService<T>();
         }
         return agent;
      }

      public bool CanAccessDatabase(out string error)
      {
         error = string.Empty;
         bool ret = false;
         try
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(LoggingConfigurationSession.ServiceDirectory);

            IOptionsDataAccessAgent optionsAgent = GetAgent<IOptionsDataAccessAgent>(configuration, new OptionsDataAccessConfigurationView(configuration, null, LoggingConfigurationSession.DisplayName));
            ILoggingDataAccessAgent loggingAgent = GetAgent<ILoggingDataAccessAgent>(configuration, new LoggingDataAccessConfigurationView(configuration, null, LoggingConfigurationSession.DisplayName));

            bool bContinue = true;
            if (loggingAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IAeManagementDataAccessAgent");
               bContinue = false;
            }

            if (bContinue)
            {
               if (optionsAgent == null)
               {
                  error = string.Format("{0} {1}", AssemblyName, "Cannot create IOptionsDataAccessAgent");
                  bContinue = false;
               }
            }

            if (bContinue)
            {
               optionsAgent.GetDefaultOptions();

               loggingAgent.FindDicomEventLog(1, false);
            }
         }
         catch (Exception e)
         {
            error = string.Format("{0} {1}", AssemblyName, e.Message);
         }

         ret = string.IsNullOrEmpty(error);
         return ret;
      }

      public ServiceMessage Process(ServiceMessage Message)
      {
         ServiceMessage serviceMessage = null;
         switch (Message.Message)
         {
            case MessageNames.IsAddinHealthy:
               serviceMessage = new ServiceMessage();
               string error;
               serviceMessage.Message = Message.Message;
               serviceMessage.Success = CanAccessDatabase(out error);
               serviceMessage.Error = error;
               break;
         }
         return serviceMessage;
      }

      #endregion
   }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
}
