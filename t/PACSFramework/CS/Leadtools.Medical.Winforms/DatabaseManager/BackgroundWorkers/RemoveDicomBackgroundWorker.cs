// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.Threading ;
using System.ComponentModel ;
using System.Text ;
using System.IO ;
using System.Data ;
using Leadtools.Medical.DataAccessLayer ;
using Leadtools.Medical.Storage.DataAccessLayer ;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters ;
using Leadtools.Medical.Workstation.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Dicom;


namespace Leadtools.Medical.Winforms
{
   class RemoveDicomBackgroundWorker : BackgroundWorker
   {
      public RemoveDicomBackgroundWorker ( IStorageDataAccessAgent dataAccessAgent ) 
      {
         base.WorkerReportsProgress = true ;
         base.WorkerSupportsCancellation = true ;
         
         _dataAccessAgent = dataAccessAgent ;
      }

      public void RunWorkerAsync ( ViewGenerator.ViewDataRow [ ] deleteRows ) 
      {
         base.RunWorkerAsync ( ( object ) deleteRows )  ;
      }

      protected override void OnDoWork( DoWorkEventArgs e )
      {
         int count ;
         int totalDeletedImagesCount ;
         
         ViewGenerator.ViewDataRow [ ] deleteRows ;
         
         
         count = 0 ;
         totalDeletedImagesCount = 0 ;
         
         try
         {
            MatchingParameterCollection matchingParamCollection ;
            MatchingParameterList       matchingParamList ;
            
            
            if ( this.CancellationPending ) 
            {
               e.Cancel = true ;
               
               return ;
            }
            
            if ( ! (e.Argument is ViewGenerator.ViewDataRow []) )
            {
               throw new ArgumentException ( "Invalid RemoveDicom argument" ) ;
            }
            
            deleteRows = ( e.Argument as ViewGenerator.ViewDataRow [ ] ) ;
            
            foreach ( ViewGenerator.ViewDataRow deletedRow in deleteRows )
            {
               try
               {
                  DataRow originalRow ;
                  int deletedImagesCount ;
                  string rowKeyValue ;
                  string rowKeyName ;
                  string viewName ;
                  
                  
                  if ( this.CancellationPending ) 
                  {
                     e.Cancel = true ;
                     
                     return ;
                  }
                  
                  originalRow             = deletedRow.OriginalRow ;
                  matchingParamCollection = new MatchingParameterCollection ( ) ;
                  matchingParamList       = new MatchingParameterList ( ) ;
                  
                  matchingParamCollection.Add ( matchingParamList ) ;
                  
                  // if ( originalRow is CompositeInstanceDataSet.InstanceRow )
                  if (string.Compare(originalRow.Table.TableName, DataTableHelper.InstanceTableName)==0)
                  {
                     // imageInstance = new Instance( ( ( CompositeInstanceDataSet.InstanceRow ) originalRow ).SOPInstanceUID ) ;
                     string sSopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(originalRow, DicomTag.SOPInstanceUID);
                     ICatalogEntity imageInstance = RegisteredEntities.GetInstanceEntity(sSopInstanceUid);
                     
                     
                     rowKeyValue = sSopInstanceUid;
                     rowKeyName  = "SOPInstanceUID" ;
                     viewName    = "Images" ;
                     
                     matchingParamList.Add ( imageInstance ) ;
                     
                  }
                  // else if ( originalRow is CompositeInstanceDataSet.SeriesRow ) 
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.SeriesTableName)==0)
                  {
                     // ICatalogEntity seriesEntity ;
                     
                     
                     // seriesEntity = new Series ( ( ( CompositeInstanceDataSet.SeriesRow ) originalRow ).SeriesInstanceUID ) ;
                     string sSeriesInstanceUid = RegisteredDataRows.SeriesInfo.GetElementValue(originalRow, DicomTag.SeriesInstanceUID);
                     ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(sSeriesInstanceUid);
                     // seriesEntity = new Series ( ( ( CompositeInstanceDataSet.SeriesRow ) originalRow ).SeriesInstanceUID ) ;

                     
                     rowKeyValue = sSeriesInstanceUid ;
                     rowKeyName  = "SeriesInstanceUID" ;
                     viewName    = "Series" ;
                     
                     matchingParamList.Add ( seriesEntity ) ;
                  }
                  // else if ( originalRow is CompositeInstanceDataSet.StudyRow ) 
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.StudyTableName) == 0)
                  {
                     // Study studyEntity = new Study ( ( ( CompositeInstanceDataSet.StudyRow ) originalRow ).StudyInstanceUID ) ;
                     string sStudyInstanceUid = RegisteredDataRows.StudyInfo.GetElementValue(originalRow, DicomTag.StudyInstanceUID);
                     ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(sStudyInstanceUid);
                     
                     rowKeyValue = sStudyInstanceUid ;
                     rowKeyName  = "StudyInstanceUID" ;
                     viewName    = "Studies" ;
                     
                     matchingParamList.Add ( studyEntity ) ;
                  }
                  // else if ( originalRow is CompositeInstanceDataSet.PatientRow ) 
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.PatientTableName) == 0)
                  {
                     // Patient patientEntity = new Patient ( ( ( CompositeInstanceDataSet.PatientRow ) originalRow ).PatientID ) ;
                     string sPatientId = RegisteredDataRows.PatientInfo.GetElementValue(originalRow, DicomTag.PatientID);
                     ICatalogEntity patientEntity = RegisteredEntities.GetPatientEntity(sPatientId);
                     
                     rowKeyValue = sPatientId ;
                     rowKeyName  = "PatientId" ;
                     viewName    = "Patients" ;
                     
                     matchingParamList.Add ( patientEntity ) ;
                  }
#if (LEADTOOLS_V19_OR_LATER)
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.HangingProtocolTableName)==0)
                  {
                     string sSopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(originalRow, DicomTag.SOPInstanceUID);
                     ICatalogEntity hangingProtocolInstance = RegisteredEntities.GetHangingProtocolEntity(sSopInstanceUid);
                     
                     
                     rowKeyValue = sSopInstanceUid;
                     rowKeyName  = "SOPInstanceUID" ;
                     viewName    = "Hanging Protocol" ;
                     
                     matchingParamList.Add ( hangingProtocolInstance ) ;
                     
                  }
#endif
                  else
                  {
                     throw new ApplicationException ( "Deleted row is not a valid DICOM format." ) ;
                  }
                                    
#if (LEADTOOLS_V19_OR_LATER)
                  if (string.Compare(originalRow.Table.TableName, DataTableHelper.HangingProtocolTableName)==0 && _dataAccessAgent3 != null)
                  {
                     deletedImagesCount = _dataAccessAgent3.DeleteHangingProtocol(matchingParamCollection);
                  } 
                  else
                  {
                     deletedImagesCount = _dataAccessAgent.DeleteInstance(matchingParamCollection);
                  }
#else
                  deletedImagesCount = _dataAccessAgent.DeleteInstance(matchingParamCollection);
#endif 

                  count++ ;
                  
                  RemoveDiconWorkerProgressState state ;
                  
                  
                  state = new RemoveDiconWorkerProgressState ( ) ;
                  
                  totalDeletedImagesCount += deletedImagesCount ;
                  
                  state.Error = null ;
                  state.CurrentCount = count ;
                  state.DeletedRow = deletedRow ;
                  state.RemovedImagesCount = deletedImagesCount ;
                  state.TotalCount         = totalDeletedImagesCount ;
                  state.RowKeyValue        = rowKeyValue ;
                  state.RowKeyName         = rowKeyName ;
                  state.ViewName           = viewName ;
                  
                  ReportProgress ( ( count * 100 ) / deleteRows.Length, state ) ;
               }
               catch ( Exception exception )
               {
                  RemoveDiconWorkerProgressState state ;
                  
                  
                  state = new RemoveDiconWorkerProgressState ( ) ;
                  
                  count++ ;
                  
                  state.Error        = exception ;
                  state.CurrentCount = count ;
                  state.DeletedRow   = deletedRow ;
                  state.TotalCount   = totalDeletedImagesCount ;
                  state.RemovedImagesCount = 0 ;
                  
                  ReportProgress ( ( count * 100 ) / deleteRows.Length, state ) ;
               }
            }
         }
         finally
         {
            e.Result = totalDeletedImagesCount ;
         }
      }

      private IStorageDataAccessAgent _dataAccessAgent ;

#if (LEADTOOLS_V19_OR_LATER)   
      private IStorageDataAccessAgent3 _dataAccessAgent3
      {
         get
         {
            return _dataAccessAgent as IStorageDataAccessAgent3;
         }
      }
#else
      private IStorageDataAccessAgent _dataAccessAgent3
      {
         get
         {
            return null;
         }
      }
#endif

      public class RemoveDiconWorkerProgressState
      {
      
         public Exception Error 
         {
            get
            {
               return _error ;
            }
            
            set
            {
               _error = value ;
            }
         }
         
         public ViewGenerator.ViewDataRow DeletedRow
         {
            get
            {
               return _deletedRow ;
            }
            
            set
            {
               _deletedRow = value ;
            }
         }
         
         public int RemovedImagesCount 
         {
            get
            {
               return _removedImagesCount ;
            }
            
            set
            {
               _removedImagesCount = value ;
            }
         }
         
         public int CurrentCount 
         {
            get
            {
               return _currentCount ;
            }
            
            set
            {
               _currentCount = value ;
            }
         }
         
         public int TotalCount 
         {
            get
            {
               return _totalCount ;
            }
            
            set
            {
               _totalCount = value ;
            }
         }
         
         public string RowKeyValue 
         {
            get
            {
               return _rowKeyValue ;
            }
            
            set
            {
               _rowKeyValue = value ;
            }
         }
         
         public string RowKeyName  
         {
            get
            {
               return _rowKeyName ;
            }
            
            set
            {
               _rowKeyName = value ;
            }
         }
         
         public string ViewName    
         {
            get
            {
               return _viewName ;
            }
            
            set
            {
               _viewName = value ;
            }
         }
         
         private Exception                  _error = null ;
         private ViewGenerator.ViewDataRow  _deletedRow = null ;
         private int                       _removedImagesCount = 0 ;
         private int                       _currentCount  = 0 ;
         private int                       _totalCount = 0 ;
         private string                    _rowKeyValue = "" ;
         private string                    _rowKeyName  = "" ;
         private string                    _viewName    = "" ;
      }
   }
}
