// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using System.Data;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Dicom;
using Leadtools.Dicom.Scp.Command;
using System.IO;
using Leadtools.Dicom.Common.Anonymization;

namespace Leadtools.Medical.Winforms.DatabaseManager
{
   public class ExportDicomBackgroundWorker : BackgroundWorker
   {      
      private readonly IStorageDataAccessAgent _dataAccessAgent;
      
      public ExportDicomBackgroundWorker(IStorageDataAccessAgent dataAccessAgent)
      {
         WorkerReportsProgress      = true ;
         WorkerSupportsCancellation = true ;
         
         _dataAccessAgent = dataAccessAgent ;
      }

      private IStorageDataAccessAgent3 _dataAccessAgent3
      {
         get
         {
            return _dataAccessAgent as IStorageDataAccessAgent3;
         }
      }

      public event EventHandler<StoreCommandEventArgs> StoreCommandCreated;

      private DicomDir _dicomDirectory = null;
      public DicomDir DicomDirectory
      {
         get { return _dicomDirectory; }
         set
         {
            if (_dicomDirectory != null)
            {
               _dicomDirectory.Dispose();
            }
            _dicomDirectory = value;
         }
      }

      private Anonymizer _anonymizer = null;
      public Anonymizer Anonymizer
      {
         get{ return _anonymizer; }
         set { _anonymizer = value; }
      }

      public void RunWorkerAsync ( ExportDicomWorkerArgs args) 
      {
         base.RunWorkerAsync (args);
      }

      protected override void OnDoWork( DoWorkEventArgs e )
      {
         int count = 0;
         int imagesToExportCount = 0;
         InstanceCStoreCommand cmd = null;

         MatchingParameterCollection matchingParamCollection;
         MatchingParameterList matchingParamList;

         if (this.CancellationPending)
         {
            e.Cancel = true;
            return;
         }

         ExportDicomWorkerArgs args = e.Argument as ExportDicomWorkerArgs;
         if (args == null)
         {
            throw new ArgumentException("Invalid ExportDicom argument");
         }

         if (args.CreateDicomDir)
         {
            DicomDirectory = new DicomDir(args.OutputFolder);
         }

         if (args.Anonymize)
         {
            Anonymizer.BeginBatch();
         }

         try
         {            
            ViewGenerator.ViewDataRow[] exportRows = ( args.Rows );

          imagesToExportCount = exportRows.Length;
            
            foreach ( ViewGenerator.ViewDataRow exportRow in exportRows )
            {
               try
               {
                  string rowKeyValue ;
                  string rowKeyName ;
                  string viewName ;
                                    
                  if ( this.CancellationPending ) 
                  {
                     e.Cancel = true ;
                     
                     return ;
                  }
                  
                  DataRow originalRow = exportRow.OriginalRow;
                  matchingParamCollection = new MatchingParameterCollection ( ) ;
                  matchingParamList       = new MatchingParameterList ( ) ;
                  
                  matchingParamCollection.Add ( matchingParamList ) ;
                  
                  if (string.Compare(originalRow.Table.TableName, DataTableHelper.InstanceTableName)==0)
                  {
                     string sSopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(originalRow, DicomTag.SOPInstanceUID);
                     ICatalogEntity imageInstance = RegisteredEntities.GetInstanceEntity(sSopInstanceUid);
                     
                     rowKeyValue = sSopInstanceUid;
                     rowKeyName  = "SOPInstanceUID" ;
                     viewName    = "Images" ;
                     
                     matchingParamList.Add ( imageInstance ) ;
                     
                  }
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.SeriesTableName)==0)
                  {
                     string sSeriesInstanceUid = RegisteredDataRows.SeriesInfo.GetElementValue(originalRow, DicomTag.SeriesInstanceUID);
                     ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(sSeriesInstanceUid);
                     
                     rowKeyValue = sSeriesInstanceUid ;
                     rowKeyName  = "SeriesInstanceUID" ;
                     viewName    = "Series" ;
                     
                     matchingParamList.Add ( seriesEntity ) ;
                  }
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.StudyTableName) == 0)
                  {
                     string sStudyInstanceUid = RegisteredDataRows.StudyInfo.GetElementValue(originalRow, DicomTag.StudyInstanceUID);
                     ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(sStudyInstanceUid);
                     
                     rowKeyValue = sStudyInstanceUid ;
                     rowKeyName  = "StudyInstanceUID" ;
                     viewName    = "Studies" ;
                     
                     matchingParamList.Add ( studyEntity ) ;
                  }
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.PatientTableName) == 0)
                  {
                     string sPatientId = RegisteredDataRows.PatientInfo.GetElementValue(originalRow, DicomTag.PatientID);
                     ICatalogEntity patientEntity = RegisteredEntities.GetPatientEntity(sPatientId);
                     
                     rowKeyValue = sPatientId ;
                     rowKeyName  = "PatientId" ;
                     viewName    = "Patients" ;
                     
                     matchingParamList.Add ( patientEntity ) ;
                  }
                  else if (string.Compare(originalRow.Table.TableName, DataTableHelper.HangingProtocolTableName) == 0)
                  {
                     string sSopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(originalRow, DicomTag.SOPInstanceUID);
                     ICatalogEntity hangingProtocolInstance = RegisteredEntities.GetHangingProtocolEntity(sSopInstanceUid);

                     rowKeyValue = sSopInstanceUid;
                     rowKeyName = "SOPInstanceUID";
                     viewName = "Hanging Protocol";

                     matchingParamList.Add(hangingProtocolInstance);

                  }
                  else
                  {
                     throw new ApplicationException ( "Deleted row is not a valid DICOM format." ) ;
                  }

                  DataSet exportDataSet = null;
                  DataRow[] rows = null;

                  if (string.Compare(originalRow.Table.TableName, DataTableHelper.HangingProtocolTableName) == 0 && _dataAccessAgent3 != null)
                  {
                     exportDataSet = _dataAccessAgent3.QueryHangingProtocol(matchingParamCollection);
                     rows = exportDataSet.Tables[DataTableHelper.HangingProtocolTableName].Select();
                  }
                  else
                  {
                     exportDataSet = _dataAccessAgent.QueryCompositeInstances(matchingParamCollection);
                     rows = exportDataSet.Tables[DataTableHelper.InstanceTableName].Select();
                  }

                  foreach(DataRow row in rows)
                  {
                     DicomDataSet dicomDataSet = RegisteredDataRows.InstanceInfo.LoadDicomDataSet(row);

                     if (args.Anonymize)
                     {
                        Anonymizer.Anonymize(dicomDataSet);
                     }

                     AddDicomBackgroundWorker.StoreClientSessionProxy proxy = new AddDicomBackgroundWorker.StoreClientSessionProxy();
                     proxy.AffectedSOPInstance = dicomDataSet.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                     proxy.AbstractClass = dicomDataSet.GetValue<string>(DicomTag.SOPClassUID, string.Empty);


                     try
                     {
                        cmd = new InstanceCStoreCommand(proxy, dicomDataSet, _dataAccessAgent);

                        OnStoreCommandCreated(this, new StoreCommandEventArgs(cmd));

                        cmd.Configuration.DataSetStorageLocation = args.OutputFolder;
#if (LEADTOOLS_V19_OR_LATER)
                        cmd.Configuration.HangingProtocolLocation = args.OutputFolder;
#endif

                        string fileLocation = CStoreCommand.GetStorageFullPath(cmd.Configuration, dicomDataSet);
                        if (args.Overwrite || !File.Exists(fileLocation))
                        {
                           // Only exporting, so do not validate SopInstance and do not add to database
                           cmd.DoValidateSopInstance = false;
                           cmd.DoUpdateDatabase = false;
                           cmd.DoUseExternalStoreSettings = false;
                           cmd.DataSetStored += cmd_DataSetStored;

                           cmd.Execute();
                        }
                        else
                        {
                           // File already exists -- it is not overwritten
                           DataSetStoredEventArgs storedArgs = new DataSetStoredEventArgs(dicomDataSet, string.Empty, string.Empty, fileLocation);
                           cmd_DataSetStored(this, storedArgs);
                        }
                     }
                     finally 
                     {
                        if (cmd != null)
                        {
                           cmd.DataSetStored -= cmd_DataSetStored;
                        }
                     }
  
                  }
                  
                  count++ ;

                  ExportDicomWorkerProgressState state = new ExportDicomWorkerProgressState ( );
                                    
                  state.Error = null ;
                  state.CurrentCount = count ;
                  state.ExportRow = exportRow ;
                  state.ExportedImagesCount = 1 ;
                  state.TotalCount         = imagesToExportCount ;
                  state.RowKeyValue        = rowKeyValue ;
                  state.RowKeyName         = rowKeyName ;
                  state.ViewName           = viewName ;
                  
                  ReportProgress ( ( count * 100 ) / exportRows.Length, state ) ;
               }
               catch ( Exception exception )
               {
                  ExportDicomWorkerProgressState state = new ExportDicomWorkerProgressState ( );
                  
                  count++ ;
                  
                  state.Error        = exception ;
                  state.CurrentCount = count ;
                  state.ExportRow   = exportRow ;
                  state.TotalCount   = imagesToExportCount ;
                  state.ExportedImagesCount = 0 ;
                  
                  ReportProgress ( ( count * 100 ) / exportRows.Length, state ) ;
               }
            }
         }
         finally
         {
            e.Result = imagesToExportCount;
            if (DicomDirectory != null)
            {
               DicomDirectory.Save();
               DicomDirectory = null;
            }

            if (Anonymizer != null)
            {
               Anonymizer.EndBatch();
               Anonymizer = null;
            }
         }
      }

      void cmd_DataSetStored(object sender, DataSetStoredEventArgs e)
      {
         if (DicomDirectory != null)
         {
            DicomDirectory.InsertDataSet(e.DataSet, e.ReferencedFileName);
         }

#if DEBUG
         Console.WriteLine(e.ReferencedFileName);
#endif
      }

      private void OnStoreCommandCreated ( object sender, StoreCommandEventArgs e ) 
      {
         if ( null != StoreCommandCreated )
         {
            StoreCommandCreated ( sender, e ) ;
         }
      }

      public class ExportDicomWorkerProgressState
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
         
         internal ViewGenerator.ViewDataRow ExportRow
         {
            get
            {
               return _exportRow ;
            }
            
            set
            {
               _exportRow = value ;
            }
         }
         
         public int ExportedImagesCount 
         {
            get
            {
               return _exportedImagesCount ;
            }
            
            set
            {
               _exportedImagesCount = value ;
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

         public DicomCommandStatusType Status
         {
            get { return _status; }
            set { _status = value; }
         }

         public string File { get; set; }

         public string Description{ get; set; }

         private DicomCommandStatusType     _status =DicomCommandStatusType.Success;
         private Exception                  _error = null ;
         private ViewGenerator.ViewDataRow  _exportRow = null ;
         private int                        _exportedImagesCount = 0 ;
         private int                        _currentCount  = 0 ;
         private int                        _totalCount = 0 ;
         private string                     _rowKeyValue = "" ;
         private string                     _rowKeyName  = "" ;
         private string                     _viewName    = "" ;
      }
   }

   public class ExportDicomWorkerArgs
   {
      public string OutputFolder { get; set; }
      public ViewGenerator.ViewDataRow[] Rows { get; set; }
      public bool Overwrite { get; set; }
      public bool CreateDicomDir { get; set; }
      public bool Anonymize { get; set; }

      public ExportDicomWorkerArgs(string outputFolder, ViewGenerator.ViewDataRow[] rows)
      {
         OutputFolder = outputFolder;
         Rows = rows;

         Overwrite = false;
         CreateDicomDir = false;
         Anonymize = false;
      }
   }
}
