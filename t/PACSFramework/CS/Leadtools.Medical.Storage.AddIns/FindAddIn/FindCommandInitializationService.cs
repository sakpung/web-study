// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom ;
using Leadtools.Dicom.AddIn.Configuration ;
using Leadtools.Dicom.Scp.Command ;
using Leadtools.Dicom.Scp.Command.Configuration ;
using Leadtools.Medical.Storage.AddIns.Configuration ;
using Leadtools.Logging ;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.AddIn;


namespace Leadtools.Medical.Storage.AddIns
{
   class FindCommandInitializationService : IInitializationService
   {
      public FindCommandInitializationService ( ) 
      {}
      
      public FindCommandInitializationService ( StorageModuleConfigurationManager configManager ) 
      {
         _configManager = configManager ;
      }
      
      #region IInitializationService Members

      public void ConfigureCommand ( DicomCommand command )
      {
         try
         {
            StorageAddInsConfiguration storeConfig ;
            
            if ( null == _configManager  )
            {
               if ( ServiceLocator.IsRegistered<StorageModuleConfigurationManager> ( ) )
               {
                  _configManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager> ( ) ;
               }
               else
               {
                  throw new InvalidOperationException ( "No " + typeof (StorageModuleConfigurationManager).Name + " registered." ) ;
               }
            }
            
            storeConfig = _configManager.GetStorageAddInsSettings ( ) ;
            
            if ( null != storeConfig ) 
            {
               if ( command is CFindCommand )
               {
                  ConfigureCFindCommand ( command, storeConfig.QueryAddIn ) ;
               }
               
               if ( command is QueryCFindCommand )
               {
                  ConfigureQueryCFindCommand ( command, storeConfig.QueryAddIn ) ;
               }

            }
         }
         catch ( Exception exception ) 
         {
            LogEvent ( "Failed to configure CFind Command, default configuration will be applied.^\n" + exception.Message, command.RequestDataSet ) ;
         }
      }

      private static void ConfigureCFindCommand 
      ( 
         DicomCommand command, 
         QueryAddInConfigurationElement findConfig 
      )
      {
         CFindCommand findCommand ;
         
         
         findCommand = command as CFindCommand ;
         
         if ( null != findCommand ) 
         {
            findCommand.Configuration.AllowExtraElements = findConfig.DataSetRequestValidation.AllowExtraElements ;
            findCommand.Configuration.AllowMultipleItems = findConfig.DataSetRequestValidation.AllowMultipleItemsSequence ;
            findCommand.Configuration.AllowPrivateElements = findConfig.DataSetRequestValidation.AllowPrivateElements ;
            findCommand.Configuration.AllowZeroItemCount = findConfig.DataSetRequestValidation.AllowZeroItemsSequence ;
         }
      }
      
      private static void ConfigureQueryCFindCommand 
      ( 
         DicomCommand command, 
         QueryAddInConfigurationElement queryConfig 
      )
      {
         QueryCFindCommand queryFindCommand ;
         
         
         queryFindCommand = command as QueryCFindCommand ;
         
         if ( null != queryFindCommand )
         {
            queryFindCommand.QueryConfiguration.IncludePatientRelatedInstances = queryConfig.DataSetResponseOptions.IncludeNumberOfPatientInstances ;
            queryFindCommand.QueryConfiguration.IncludePatientRelatedSeries    = queryConfig.DataSetResponseOptions.IncludeNumberOfPatientSeries ;
            queryFindCommand.QueryConfiguration.IncludePatientRelatedStudies   = queryConfig.DataSetResponseOptions.IncludeNumberOfPatientStudies ;
            queryFindCommand.QueryConfiguration.IncludeSeriesRelatedInstances  = queryConfig.DataSetResponseOptions.IncludeNumberOfSeriesInstances ;
            queryFindCommand.QueryConfiguration.IncludeStudyRelatedInstances   = queryConfig.DataSetResponseOptions.IncludeNumberOfStudyInstances ;
            queryFindCommand.QueryConfiguration.IncludeStudyRelatedSeries      = queryConfig.DataSetResponseOptions.IncludeNumberOfStudySeries ;
            queryFindCommand.QueryConfiguration.QueryIODPath                   = queryConfig.QueryIODPath ;
            
            queryFindCommand.LimitResponses                                     = queryConfig.LimitCFindRsp;
            queryFindCommand.MaximumResponses                                  = queryConfig.MaximumCFindRspCount;
            queryFindCommand.ServiceStatus                                     = queryConfig.ServiceStatus;
         }
      }

      #endregion
      
      private static void LogEvent ( string message, DicomDataSet dataset )
      {
         try
         {
            Logger.Global.Log ( AddInsSession.ServerAE, 
                                AddInsSession.ServerAddress, 
                                AddInsSession.ServerPort, 
                                string.Empty, 
                                string.Empty, 
                                -1, 
                                DicomCommandType.CFind,
                                DateTime.Now, 
                                LogType.Error, 
                                MessageDirection.Input,
                                message,
                                dataset,
                                null ) ;
         }
         catch ( Exception ) 
         {}
      }
      
      private StorageModuleConfigurationManager _configManager ;
   }
}
