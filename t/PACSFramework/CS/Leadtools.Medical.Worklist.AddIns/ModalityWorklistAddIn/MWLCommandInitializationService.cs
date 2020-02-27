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
using Leadtools.Medical.Worklist.AddIns.Configuration ;
using Leadtools.Logging ;
using Leadtools.Logging.Medical;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Worklist.DataAccessLayer;


namespace Leadtools.Medical.Worklist.AddIns
{
   class MWLCommandInitializationService : IInitializationService
   {
      #region IInitializationService Members

      public void ConfigureCommand ( DicomCommand command )
      {
         try
         {
            AdvancedSettings settings ;
            WorklistAddInsConfiguration worklistConfig ;
            
            settings       = AdvancedSettings.Open ( AddInsSession.ServiceDirectory ) ;
            worklistConfig = GetWorklistAddInsSettings ( settings ) ;

            
            
            if ( null != worklistConfig ) 
            {
               if ( DataAccessServices.IsDataAccessServiceRegistered <IWorklistDataAccessAgent> ( ) )
               {
                  IWorklistDataAccessAgent dataAccess = DataAccessServices.GetDataAccessService <IWorklistDataAccessAgent> ( ) ;
                  
                  if ( dataAccess is WorklistDbDataAccessAgent )
                  {
                     if ( worklistConfig.LimitNumberOfResponses )
                     {
                        ( ( WorklistDbDataAccessAgent ) dataAccess ).NumberOfMatchingWlResponses = worklistConfig.NumberOfMatchingResponses ;
                     }
                     else
                     {
                        ( ( WorklistDbDataAccessAgent ) dataAccess ).NumberOfMatchingWlResponses = -1 ;
                     }
                  }
               }
               
               if ( command is CFindCommand )
               {
                  ConfigureCFindCommand ( command, worklistConfig ) ;
               }
               
               if ( command is MWLCFindCommand )
               {
                  ConfigureQueryCFindCommand ( command, worklistConfig ) ;
               }

            }
         }
         catch ( Exception exception ) 
         {
            LogEvent ( "Failed to configure Modality Worklist CFind Command, default configuration will be applied.^\n" + exception.Message, command.RequestDataSet ) ;
         }
      }

      private static void ConfigureCFindCommand 
      ( 
         DicomCommand command, 
         WorklistAddInsConfiguration findConfig 
      )
      {
         CFindCommand findCommand ;
         
         
         findCommand = command as CFindCommand ;
         
         if ( null != findCommand ) 
         {
            findCommand.Configuration.AllowExtraElements = findConfig.ModalityWorklistValidation.AllowExtraElements ;
            findCommand.Configuration.AllowMultipleItems = findConfig.ModalityWorklistValidation.AllowMultipleItemsSequence ;
            findCommand.Configuration.AllowPrivateElements = findConfig.ModalityWorklistValidation.AllowPrivateElements ;
            findCommand.Configuration.AllowZeroItemCount = findConfig.ModalityWorklistValidation.AllowZeroItemsSequence ;
         }
      }
      
      private static void ConfigureQueryCFindCommand 
      ( 
         DicomCommand command, 
         WorklistAddInsConfiguration findConfig 
      )
      {
         MWLCFindCommand queryFindCommand ;
         
         
         queryFindCommand = command as MWLCFindCommand ;
         
         if ( null != queryFindCommand )
         {
            queryFindCommand.MWLConfiguration.ExcludeCompletedStatus            = findConfig.EliminateCompletedMWL ;
            queryFindCommand.MWLConfiguration.ExcludeDiscontinuedStatus         = findConfig.EliminateDiscontinuedMWL ;
            queryFindCommand.MWLConfiguration.ExcludeInProgressStatus           = findConfig.EliminateInProgressMWL ;
            queryFindCommand.MWLConfiguration.LimitMWLResponseToClientStationAE = findConfig.UseStationAETitleForMatching ;
            queryFindCommand.MWLConfiguration.ModalityWorklistIODPath           = findConfig.ModaliyWorklistIODPath ;
         }
      }

      #endregion
      
      private static WorklistAddInsConfiguration GetWorklistAddInsSettings
      (
         AdvancedSettings advancedSettings
      )
      {
         WorklistAddInsConfiguration settings;
         string addInsName ;
         
         
         addInsName = System.Reflection.Assembly.GetExecutingAssembly ( ).GetName ( ).Name ;
         
         settings = advancedSettings.GetAddInCustomData <WorklistAddInsConfiguration> ( addInsName, 
                                                                                        WorklistAddInsConfiguration.SectionName ) ;
         if ( null == settings ) 
         {
            settings = new WorklistAddInsConfiguration ( ) ;
         }
         
         return settings;
      }
      
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
   }
}
