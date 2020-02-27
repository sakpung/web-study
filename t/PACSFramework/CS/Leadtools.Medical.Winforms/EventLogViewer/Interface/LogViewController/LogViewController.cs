// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.ComponentModel;
using System.Collections.Generic;
using Leadtools.Medical.Logging.DataAccessLayer.MatchingParameters;


namespace Leadtools.Medical.Winforms
{
   public class ImportLogArgs : EventArgs
   {
      public ImportLogArgs( List<String> files, DICOMServerEventLogMatchingParameters matchingParameters, object currentQueryState, int lastRowsCount)
      {
         Files = files;
         MatchingParameters = matchingParameters;
         LastRowsCount = lastRowsCount;
         CurrentQueryState = currentQueryState;
         Cancelled = false;
      }
      
      public List<String> Files {get; set;}
      public DICOMServerEventLogMatchingParameters MatchingParameters {get; set;}
      public object CurrentQueryState;
      public int LastRowsCount{get; set;}
      public String ErrorMessage{get; set;}
      public bool Cancelled{get;set;}
   }
   
   interface LogViewController
   {
      int PerformQuery ( ) ;
      
      void ImportAsync( List<String> files );
      void CancelImportAsync(ImportLogArgs args);
      
      event EventHandler<ImportLogArgs> ImportCompleted;
      
      event EventHandler<ImportLogArgs> ImportStarting;
      
      void ExportSelected ( string strFilePath ) ;
      
      void DeleteSelected ( ) ;
      
      void DeleteCurrentView ( ) ;
      
      void DeleteAll ( ) ;
      
      void ViewSelectedLogDetail ( ) ;
      
      void RefreshQueryInfo ( ) ;
      
      int CurrentLogsCount
      {
         get ;
         
      }
      
      int SelctedLogsCount
      {
         get ;
         
      }
      
      event EventHandler SelectedLogViewIndexChange ;
      event EventHandler<RunWorkerCompletedEventArgs> DeleteCompleted ;
   }
}
