// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.Logging.Addins.Commands;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer.MatchingParameters;
using System.IO;
using System.Diagnostics;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using System.Xml;

namespace Leadtools.Medical.Logging.Addins
{
   public class AutoSaveLogCommand : ICommand
   {
      public AutoSaveLogCommand ( LoggingState loggingState )
      {
         LoggingState = loggingState ;
      }
      
      public LoggingState LoggingState
      {
         get ;
         private set ;
      }

      #region ICommand Members

      public void Execute ( )
      {
         try
         {
            ILoggingDataAccessAgent2 loggingDataAccess ;
            DicomEventLogDataSet eventLogDS ;
            
            if ( !DataAccessServices.IsDataAccessServiceRegistered <ILoggingDataAccessAgent2> ( ) )
            {
               throw new InvalidOperationException ( "Logging Data Access is not registered." ) ;
            }
            else
            {
               loggingDataAccess = DataAccessServices.GetDataAccessService <ILoggingDataAccessAgent2> ( ) ;
            }
            
            MatchingParameterCollection           matchingCollection = new MatchingParameterCollection ( ) ;
            MatchingParameterList                 matchingList = new MatchingParameterList ( ) ;
            DICOMServerEventLogMatchingParameters eventLogMatching = new DICOMServerEventLogMatchingParameters  ( ) ;
            
            eventLogMatching.EventDateTime.EndDate = DateTime.Now.Subtract ( new TimeSpan ( 0,1,0 ) ) ;
            
            matchingList.Add       ( eventLogMatching ) ;
            matchingCollection.Add ( matchingList ) ;
            
            string directoryPath = Path.Combine ( LoggingState.AutoSaveDirectory, DateTime.Now.ToShortDateString ( ).Replace ( '/', '-' ) ) ;
            string filePath ;
            
            Directory.CreateDirectory ( directoryPath ) ;
            
            WriteLog ( "Begin Auto Save Log", LogType.Debug ) ;
            
            int batchSize = 10000 ;
            long totalSaved = 0 ;
            
            eventLogDS = loggingDataAccess.QueryDicomEventLogDataset ( matchingCollection, new OrderByParametersList ( ),batchSize, true ) ;

            if ( eventLogDS.DICOMServerEventLog.Count > 0 )
            {
               string indexFile = Path.Combine ( directoryPath, "index" ) ;
               
               indexFile = Path.ChangeExtension ( indexFile, ".xml" ) ;
               
               using ( FileStream indexfs = new FileStream ( indexFile, FileMode.Create, FileAccess.Write ) )
               {
                  XmlDocument document  = new XmlDocument ( ) ;
                  
                  XmlElement rootElement = document.CreateElement ( "logs" ) ;
                  
                  document.AppendChild ( rootElement ) ;
                  
                  while ( eventLogDS.DICOMServerEventLog.Count != 0 ) 
                  {
                     filePath = Path.Combine ( directoryPath, eventLogDS.DICOMServerEventLog [ 0 ].EventID.ToString ( ) ) ;
                     
                     filePath = Path.ChangeExtension ( filePath, "txt" ) ;
                     
                     using ( FileStream fleStream = new FileStream ( filePath, FileMode.Create, FileAccess.Write ) )
                     {
                        using ( StreamWriter streamWriter = new StreamWriter ( fleStream ) )
                        {
                           EventLogWriter.WriteEventLog ( "", eventLogDS, streamWriter, new DICOMServerEventLogFormsFormatter ( ), true, directoryPath ) ;
                           
                           XmlElement element              = document.CreateElement ( "logFile" ) ;
                           XmlAttribute fileAttribute      = document.CreateAttribute ( "file" ) ;
                           XmlAttribute dateStartAttribute = document.CreateAttribute ( "dateStart" ) ;
                           XmlAttribute dateEndfAttribute  = document.CreateAttribute ( "dateEnd" ) ;
                           
                           fileAttribute.Value      = filePath ;
                           dateStartAttribute.Value = eventLogDS.DICOMServerEventLog [ 0 ].EventDateTime.ToString ( ) ;
                           dateEndfAttribute.Value  = eventLogDS.DICOMServerEventLog [ eventLogDS.DICOMServerEventLog.Count - 1 ].EventDateTime.ToString ( ) ;
                           
                           element.Attributes.Append ( fileAttribute ) ;
                           element.Attributes.Append ( dateStartAttribute ) ;
                           element.Attributes.Append ( dateEndfAttribute ) ;
                           
                           rootElement.AppendChild ( element ) ;
                           
                           totalSaved += eventLogDS.DICOMServerEventLog.Count ;
                           
                           if ( LoggingState.DeleteSavedLog ) 
                           {
                              //if failed to delete for any reason lets continue
                              try
                              {
                                 loggingDataAccess.DeleteDicomEventLog ( matchingCollection, batchSize ) ;
                              }
                              catch ( Exception exception )
                              {
                                 Logger.Global.Log ( string.Empty, string.Empty, 0, string.Empty, string.Empty, 0, Leadtools.Dicom.DicomCommandType.Undefined, DateTime.Now, LogType.Error, MessageDirection.None, 
                                                     "Auto Save Log failed to delete logs. " + exception.Message, null, null ) ;
                              }
                           }
                        }
                     }
                     
                     eventLogDS = loggingDataAccess.QueryDicomEventLogDataset ( matchingCollection, new OrderByParametersList ( ),batchSize, true ) ;
                  }
                  
                  document.Save ( indexfs ) ;
               }
               
               WriteLog ( "Exporting log to file: " + indexFile, LogType.Debug ) ;
            }
            
            WriteLog ( "End Auto Save Log. " + totalSaved.ToString ( ) +  " log(s) saved.", LogType.Debug ) ;
         }
         catch ( Exception exception ) 
         {
            Logger.Global.Log ( string.Empty, string.Empty, 0, string.Empty, string.Empty, 0, Leadtools.Dicom.DicomCommandType.Undefined, DateTime.Now, LogType.Error, MessageDirection.None, 
                                "Auto Save Log failed. " + exception.Message, null, null ) ;
         }
      }

      #endregion
      
      private void WriteLog ( string description, LogType type ) 
      {
         DicomLogEntry logEnrty = new DicomLogEntry ( ) ;
         
         logEnrty.Command          = Leadtools.Dicom.DicomCommandType.Undefined ;
         logEnrty.Description      = description  ;
         logEnrty.LogType          = type ;
         logEnrty.MachineName      = Environment.MachineName ;
         logEnrty.MessageDirection = MessageDirection.None ;
         logEnrty.TimeStamp        = DateTime.Now ;
         
         Logger.Global.Log ( logEnrty ) ;
      }
   }
}
