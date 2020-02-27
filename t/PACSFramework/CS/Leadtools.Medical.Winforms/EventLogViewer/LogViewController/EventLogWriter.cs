// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Leadtools.Medical.Logging.DataAccessLayer;
using System.Data;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.Winforms
{
   public class EventLogWriter
   {
      public static void WriteEventLog
      (
         string header,
         DicomEventLogDataSet eventLogDataSet, 
         StreamWriter streamWriter,
         DICOMServerEventLogFormatter serverEventLogFormsFormatter,
         bool saveDataSet,
         string dataSetDirectoryPath
      )
      {
         if ( !string.IsNullOrEmpty ( header ) )
         {
            streamWriter.WriteLine ( header ) ; 
                           
            streamWriter.WriteLine ( ) ;
         }
         
         foreach ( DicomEventLogDataSet.DICOMServerEventLogRow eventLogItemInfo in eventLogDataSet.DICOMServerEventLog )
         {
            WriteEventLog ( eventLogItemInfo, 
                            streamWriter,
                            serverEventLogFormsFormatter,
                            saveDataSet,
                            dataSetDirectoryPath ) ;
                            
            streamWriter.WriteLine ( ) ;
         }
      }
      
      public static void WriteEventLog
      (
         DicomEventLogDataSet.DICOMServerEventLogRow eventLogItemInfo, 
         StreamWriter fileStreamWriter,
         DICOMServerEventLogFormatter serverEventLogFormsFormatter,
         bool saveDataSet,
         string dataSetDirectoryPath
      )
      {
         if ( null != eventLogItemInfo ) 
         {
            string dataSetFilePath ;
            
            
            dataSetFilePath = string.Empty ;
            
            foreach ( DataColumn currentDataColumn in eventLogItemInfo.Table.Columns )
            {
               if ( currentDataColumn.ColumnName == _structureEventLogDs.DICOMServerEventLog.DatasetColumn.ColumnName )
               {
                  if ( saveDataSet )
                  {
                     if ( null == dataSetDirectoryPath )
                     {
                        dataSetDirectoryPath = string.Empty ;
                     }
                     
                     if ( !string.IsNullOrEmpty ( dataSetDirectoryPath ) && 
                          !Directory.Exists ( dataSetDirectoryPath ) )
                     {
                        Directory.CreateDirectory ( dataSetDirectoryPath ) ;
                     }
                     
                     dataSetFilePath = Path.Combine ( dataSetDirectoryPath, eventLogItemInfo.EventID.ToString ( ) ) ;
                     
                     dataSetFilePath = Path.ChangeExtension ( dataSetFilePath, "dcm" ) ;
                     
                     if ( !eventLogItemInfo.IsDatasetNull ( ) ) 
                     {
                        File.WriteAllBytes ( dataSetFilePath, eventLogItemInfo.Dataset ) ;
                     }
                     else if ( !eventLogItemInfo.IsDatasetPathNull ( ) && !string.IsNullOrEmpty ( eventLogItemInfo.DatasetPath ) &&
                               File.Exists ( eventLogItemInfo.DatasetPath ) )
                     {
                        File.Copy ( eventLogItemInfo.DatasetPath, dataSetFilePath ) ;
                     }
                     else
                     {
                        dataSetFilePath = string.Empty ;
                     }
                  }
                  
                  continue ;
               }
               
               object logValue ;
               
               
               if ( currentDataColumn.ColumnName == _structureEventLogDs.DICOMServerEventLog.DatasetPathColumn.ColumnName )
               {
                  logValue = dataSetFilePath ;
               }
               else if ( eventLogItemInfo.IsNull ( currentDataColumn ) )
               {
                  logValue = string.Empty ;
               }
               else
               {
                  logValue = eventLogItemInfo [ currentDataColumn ] ;
               }
               
               fileStreamWriter.WriteLine ( currentDataColumn.ColumnName + 
                                            ':' + 
                                            " " +
                                            serverEventLogFormsFormatter.Format ( currentDataColumn.ColumnName,
                                                                                  logValue,
                                                                                  null ).ToString ( ) ) ;
            }

         }
      }
      
      private static DicomEventLogDataSet _structureEventLogDs = new DicomEventLogDataSet ( ) ;
   }
}
