// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.Winforms
{
   [Serializable]
   public class LoggingState
   {
      public LoggingState ( ) 
      : this ( string.Empty, string.Empty )
      {
      }
      
      public LoggingState ( string autoSaveDirectory, string dataSetDirectory ) 
      {
         EnableLogging   = true ;
         EnableThreading = true ;
         LogInformation  = true ;
         LogWarnings     = true ;
         LogErrors       = true ;
         LogDebug        = true ;
         LogAudit        = true ;
         LogDicom        = true;
         LogDicomDataSet = false ;

         EnableAutoSaveLog  = true ;
         AutoSaveDaysPeriod = 1 ;
         AutoSaveTime       = DateTime.Now ;
         AutoSaveDirectory  = autoSaveDirectory ;
         DeleteSavedLog     = true ;
         DataSetDirectory   = dataSetDirectory ;
         
         if ( string.IsNullOrEmpty ( autoSaveDirectory ) || string.IsNullOrEmpty ( dataSetDirectory ) )
         {
            string logPath ;
            
            
            logPath = Path.Combine ( DicomDemoSettingsManager.GetFolderPath ( ), "DicomEventLog" ) ;
            
            if ( string.IsNullOrEmpty ( autoSaveDirectory ) )
            {
               AutoSaveDirectory = logPath ;
            }
            
            if ( string.IsNullOrEmpty ( dataSetDirectory ) )
            {
               DataSetDirectory = Path.Combine ( logPath, "DataSets" ) ;
            }
         }
      }
      
      public bool EnableLogging { get ; set ; }
      
      public bool EnableThreading { get ; set ; }
      
      public bool LogInformation { get ; set ; }
      
      public bool LogWarnings { get ; set ; }
      
      public bool LogErrors { get ; set ; }
      
      public bool LogDebug { get ; set ; }
      
      public bool LogAudit { get ; set ; }

      public bool LogDicom { get; set; }
      
      public bool LogDicomDataSet { get ; set ; }
      
      public bool EnableAutoSaveLog { get ; set ; }
      
      public int AutoSaveDaysPeriod { get ; set ; }
      
      public DateTime AutoSaveTime { get ; set ; }
      
      public string AutoSaveDirectory { get ; set ; }
      
      public bool DeleteSavedLog { get ; set ; }
      
      public string DataSetDirectory { get ; set ; }
   }
}
