using Leadtools.Dicom;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Medical.Storage.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leadtools.Medical.Winforms.GenerateMetadataBackgroundWorker;

namespace Leadtools.Medical.Winforms
{
   public class GenerateMetadataBackgroundWorker : BackgroundWorker
   {
      private IStorageDataAccessAgent4 _dataAccessAgent4;

      public event EventHandler<CancelGenerateMetadataEventArgs> CancelGenerateMetadata;

      public GenerateMetadataBackgroundWorker(IStorageDataAccessAgent4 dataAccessAgent)
      {
         base.WorkerReportsProgress = true;
         base.WorkerSupportsCancellation = true;

         _dataAccessAgent4 = dataAccessAgent;
      }

      protected bool OnCancelGenerateMetadata(DicomDataSet ds, out string message)
      {
         message = string.Empty;
         if (CancelGenerateMetadata != null)
         {
            CancelGenerateMetadataEventArgs e = new CancelGenerateMetadataEventArgs(ds);

            CancelGenerateMetadata(this, e);
            message = e.CancelMessage;
            return e.Cancel;
         }
         return false;
      }

      public void RunWorkerAsync(ViewGenerator.ViewDataRow[] deleteRows)
      {
         base.RunWorkerAsync((object)deleteRows);
      }

      MatchingParameterCollection GenerateMatchingParameterCollection(ViewGenerator.ViewDataRow metadataRow, out string rowKeyValue, out string rowKeyName, out string viewName)
      {
         DataRow originalRow = metadataRow.OriginalRow;
         MatchingParameterCollection matchingParamCollection = new MatchingParameterCollection();
         MatchingParameterList matchingParamList = new MatchingParameterList();

         matchingParamCollection.Add(matchingParamList);

         if (string.Compare(originalRow.Table.TableName, DataTableHelper.InstanceTableName) == 0)
         {
            string sSopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(originalRow, DicomTag.SOPInstanceUID);
            ICatalogEntity imageInstance = RegisteredEntities.GetInstanceEntity(sSopInstanceUid);

            rowKeyValue = sSopInstanceUid;
            rowKeyName = "SOPInstanceUID";
            viewName = "Images";

            matchingParamList.Add(imageInstance);

         }
         else if (string.Compare(originalRow.Table.TableName, DataTableHelper.SeriesTableName) == 0)
         {
            string sSeriesInstanceUid = RegisteredDataRows.SeriesInfo.GetElementValue(originalRow, DicomTag.SeriesInstanceUID);
            ICatalogEntity seriesEntity = RegisteredEntities.GetSeriesEntity(sSeriesInstanceUid);

            rowKeyValue = sSeriesInstanceUid;
            rowKeyName = "SeriesInstanceUID";
            viewName = "Series";

            matchingParamList.Add(seriesEntity);
         }
         else if (string.Compare(originalRow.Table.TableName, DataTableHelper.StudyTableName) == 0)
         {
            string sStudyInstanceUid = RegisteredDataRows.StudyInfo.GetElementValue(originalRow, DicomTag.StudyInstanceUID);
            ICatalogEntity studyEntity = RegisteredEntities.GetStudyEntity(sStudyInstanceUid);

            rowKeyValue = sStudyInstanceUid;
            rowKeyName = "StudyInstanceUID";
            viewName = "Studies";

            matchingParamList.Add(studyEntity);
         }
         else if (string.Compare(originalRow.Table.TableName, DataTableHelper.PatientTableName) == 0)
         {
            string sPatientId = RegisteredDataRows.PatientInfo.GetElementValue(originalRow, DicomTag.PatientID);
            ICatalogEntity patientEntity = RegisteredEntities.GetPatientEntity(sPatientId);

            rowKeyValue = sPatientId;
            rowKeyName = "PatientId";
            viewName = "Patients";

            matchingParamList.Add(patientEntity);
         }
         else
         {
            throw new ApplicationException("Row is not a valid DICOM format.");
         }

         return matchingParamCollection;
      }

      public int GetSelectedInstanceCount(ViewGenerator.ViewDataRow[] metadataRows)
      {
         int totalMetadataCount = 0;

         string rowKeyValue;
         string rowKeyName;
         string viewName;

         // Get total count
         totalMetadataCount = 0;
         foreach (ViewGenerator.ViewDataRow metadataRow in metadataRows)
         {
            MatchingParameterCollection matchingParamCollection = GenerateMatchingParameterCollection(metadataRow, out rowKeyValue, out rowKeyName, out viewName);
            DataRow[] rows = null;
            DataSet metadataDataSet = metadataDataSet = _dataAccessAgent4.QueryCompositeInstances(matchingParamCollection);
            rows = metadataDataSet.Tables[DataTableHelper.InstanceTableName].Select();
            totalMetadataCount += rows.Count();
         }
         return totalMetadataCount;
      }

      private static GenerateMetadataWorkerResultState GetCancelResult(int totalCount, int successCount)
      {
         GenerateMetadataWorkerResultState resultState = new GenerateMetadataWorkerResultState(successCount, totalCount, true);
         return resultState;
      }

      protected override void OnDoWork(DoWorkEventArgs e)
      {
         int successCount = 0;
         int totalMetadataCount = 0;

         if (this.CancellationPending)
         {
            // e.Cancel = true;
            return;
         }

         GenerateMetadataWorkerArgs args = e.Argument as GenerateMetadataWorkerArgs;
         if (args == null)
         {
            throw new ArgumentException("Invalid GenerateMetadata argument");
         }

         try
         {
            ViewGenerator.ViewDataRow[] metadataRows = (args.Rows);

            string rowKeyValue;
            string rowKeyName;
            string viewName;

            // Get total count
            totalMetadataCount = 0;
            foreach (ViewGenerator.ViewDataRow metadataRow in metadataRows)
            {
               MatchingParameterCollection matchingParamCollection = GenerateMatchingParameterCollection(metadataRow, out rowKeyValue, out rowKeyName, out viewName);
               DataSet metadataDataSet = metadataDataSet = _dataAccessAgent4.QueryCompositeInstances(matchingParamCollection);
               DataRow[] rows = metadataDataSet.Tables[DataTableHelper.InstanceTableName].Select();
               totalMetadataCount += rows.Count();
            }

            // Generate the metadata
            foreach (ViewGenerator.ViewDataRow metadataRow in metadataRows)
            {
               try
               {
                  MatchingParameterCollection matchingParamCollection = GenerateMatchingParameterCollection(metadataRow, out rowKeyValue, out rowKeyName, out viewName);

                  DataSet metadataDataSet = null;
                  DataRow[] rows = null;

                  metadataDataSet = _dataAccessAgent4.QueryCompositeInstances(matchingParamCollection);
                  rows = metadataDataSet.Tables[DataTableHelper.InstanceTableName].Select();

                  GenerateMetadataWorkerProgressState state = new GenerateMetadataWorkerProgressState();
                  foreach (DataRow row in rows)
                  {
                     string sopInstanceUid = RegisteredDataRows.InstanceInfo.GetElementValue(row, DicomTag.SOPInstanceUID);
                     DicomDataSet dicomDataSet = RegisteredDataRows.InstanceInfo.LoadDicomDataSet(row);
                     _dataAccessAgent4.StoreMetadata(dicomDataSet, sopInstanceUid, args.Options, true);

                     successCount++;
                     state.Error = null;
                     state.CurrentCount = successCount;
                     state.TotalCount = totalMetadataCount;
                     state.RowKeyValue = rowKeyValue;
                     state.RowKeyName = rowKeyName;
                     state.ViewName = viewName;

                     ReportProgress((totalMetadataCount * 100) / totalMetadataCount, state);

                     string cancelMessage;
                     OnCancelGenerateMetadata(dicomDataSet, out cancelMessage );

                     if (this.CancellationPending)
                     {
                        e.Result = GetCancelResult(totalMetadataCount, successCount);
                        // e.Cancel = true;
                        return;
                     }
                  }
               }
               catch (Exception exception)
               {
                  GenerateMetadataWorkerProgressState state = new GenerateMetadataWorkerProgressState();

                  successCount++;
                  state.Error = exception;
                  state.CurrentCount = successCount;
                  state.TotalCount = totalMetadataCount;

                  ReportProgress((totalMetadataCount * 100) / totalMetadataCount, state);
               }
            }
         }
         finally
         {
            if (e.Result == null)
            {
               e.Result = new GenerateMetadataWorkerResultState( successCount, totalMetadataCount, false);
            }
         }
      }

      public class GenerateMetadataWorkerProgressState
      {
         public Exception Error
         {
            get
            {
               return _error;
            }

            set
            {
               _error = value;
            }
         }

         public int CurrentCount
         {
            get
            {
               return _currentCount;
            }

            set
            {
               _currentCount = value;
            }
         }

         public int TotalCount
         {
            get
            {
               return _totalCount;
            }

            set
            {
               _totalCount = value;
            }
         }

         public string RowKeyValue
         {
            get
            {
               return _rowKeyValue;
            }

            set
            {
               _rowKeyValue = value;
            }
         }

         public string RowKeyName
         {
            get
            {
               return _rowKeyName;
            }

            set
            {
               _rowKeyName = value;
            }
         }

         public string ViewName
         {
            get
            {
               return _viewName;
            }

            set
            {
               _viewName = value;
            }
         }

         public DicomCommandStatusType Status
         {
            get { return _status; }
            set { _status = value; }
         }

         public string File { get; set; }

         public string Description { get; set; }

         private DicomCommandStatusType _status = DicomCommandStatusType.Success;
         private Exception _error = null;
         private int _currentCount = 0;
         private int _totalCount = 0;
         private string _rowKeyValue = "";
         private string _rowKeyName = "";
         private string _viewName = "";
      }

      public class GenerateMetadataWorkerResultState
      {

         public GenerateMetadataWorkerResultState(int successCount, int totalCount, bool cancelled)
         {
            SuccessCount = successCount;
            TotalCount = totalCount;
            Cancelled = cancelled;
         }

         public int SuccessCount
         {
            get;
            set;
         }

         public int TotalCount
         {
            get;
            set;
         }

         public bool Cancelled
         {
            get;
            set;
         }
      }

      public class GenerateMetadataWorkerArgs
      {
         public ViewGenerator.ViewDataRow[] Rows { get; set; }
         public bool Overwrite { get; set; }

         public MetadataOptions Options { get; set; }

         public GenerateMetadataWorkerArgs(ViewGenerator.ViewDataRow[] rows)
         {
            Rows = rows;

            Overwrite = false;
         }
      }

      public class CancelGenerateMetadataEventArgs : CancelEventArgs
      {
         private DicomDataSet _DataSet;

         public DicomDataSet DataSet
         {
            get { return _DataSet; }
            set { _DataSet = value; }
         }

         public string CancelMessage { get; set; }

         public CancelGenerateMetadataEventArgs(DicomDataSet ds)
         {
            _DataSet = ds;
         }
      }

      public enum MetadataCommand
      {
         None,
         Generate,
         Delete
      }

      public enum MetadataCategory
      {
         None,
         Xml,
         Json,
         All,
      }
   }

   public class MetadataEventArgs : EventArgs
   {


      public MetadataEventArgs(MetadataCommand command, MetadataCategory category, MetadataScope scope, bool finished, string reason, int successCount, int totalCount, bool canceled)
      {
         Command = command;
         Category = category;
         Scope = scope;
         Finished = finished;
         Reason = reason;
         SuccessCount = successCount;
         TotalCount = totalCount;
         Canceled = canceled;
      }

      public MetadataCommand Command
      {
         get;
         set;
      }

      public MetadataCategory Category
      {
         get;
         set;
      }

      public MetadataScope Scope
      {
         get;
         set;
      }

      public bool Finished
      {
         get;
         set;
      }

      public string Reason
      {
         get;
         set;
      }

      public int SuccessCount
      {
         get;
         set;
      }

      public int TotalCount
      {
         get;
         set;
      }

      public bool Canceled
      {
         get;
         set;
      }
   }
}
