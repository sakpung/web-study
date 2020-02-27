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
using Leadtools.Dicom ;
using Leadtools.Dicom.Scp ;
using Leadtools.Dicom.Scp.Command ;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Winforms.EventBrokerArgs;


namespace Leadtools.Medical.Winforms
{
   class AddDicomBackgroundWorker : BackgroundWorker
   {      
      public AddDicomBackgroundWorker ( string AETitle, IStorageDataAccessAgent dataAccess, string implementationClassUID ) 
      {
         base.WorkerReportsProgress = true ;
         base.WorkerSupportsCancellation = true ;
         
         _AETitle                = AETitle ;
         _DataAccess             = dataAccess ;
         _ImplementationClassUID = implementationClassUID ;
      }
      
      public event EventHandler<StoreCommandEventArgs> StoreCommandCreated ;
      public event EventHandler<CancelStoreEventArgs> CancelStore;

      protected bool OnCancelStore(DicomDataSet ds, out string message)
      {
         message = string.Empty;
         if (CancelStore != null)
         {
            CancelStoreEventArgs e = new CancelStoreEventArgs(ds);

            CancelStore(this, e);
            message = e.CancelMessage;
            return e.Cancel;
         }
         return false;
      }

      public void RunWorkerAsync ( string dicomFile ) 
      {
         base.RunWorkerAsync ( ( object ) dicomFile )  ;
      }

      public void RunWorkerAsync ( string [ ] dicomFiles ) 
      {
         base.RunWorkerAsync ( ( object ) dicomFiles )  ;
      }

      private static AddDicomWorkerResultState GetCancelResult(int totalCount, int successCount, int failureCount)
      {
         AddDicomWorkerResultState resultState = new AddDicomWorkerResultState();
         resultState.TotalCount = totalCount;
         resultState.SuccessCount = successCount;
         resultState.FailedCount = failureCount;
         resultState.Cancelled = true;
         return resultState;
      }

      protected override void OnDoWork ( DoWorkEventArgs e )
      {
         List <string>  dicomFiles ;
         int count               = 0;
         int successCount        = 0;
         int failureCount        = 0;
         int selectedFileCount   = 0;
         int totalFileCount      = 0;

         string[] selectedFileArray = e.Argument as string[];
         if (selectedFileArray != null)
         {
            selectedFileCount = selectedFileArray.Length;
         }

         if ( this.CancellationPending )
         {
            // e.Cancel = true;
            e.Result = GetCancelResult(selectedFileCount, successCount, failureCount);
            return;
         }


         dicomFiles = GetDicomFiles ( e ) ;

         if (dicomFiles != null)
         {
            totalFileCount = dicomFiles.Count;
         }
         
         if ( this.CancellationPending ) 
         {
            // e.Cancel = true;
            e.Result = GetCancelResult(totalFileCount, successCount, failureCount);
            return;
         }

         MultiDicomImportEventArgs args = new MultiDicomImportEventArgs(totalFileCount);
         EventBroker.Instance.PublishEvent<MultiDicomImportEventArgs>(this, args);

         
         foreach ( string file in dicomFiles )
         {
            if (this.CancellationPending)
            {
               // e.Cancel = true;
               e.Result = GetCancelResult(totalFileCount, successCount, failureCount);
               return;
            }
            
            using ( DicomDataSet ds = new DicomDataSet ( ) )
            {
               DicomCommandStatusType status;
               string message = string.Empty;
               bool successfulLoad = true;

               try
               {
                  ds.Load(file, DicomDataSetLoadFlags.None);
               }
               catch (Exception ex)
               {
                  successfulLoad = false;
                  message = ex.Message;
                  if (!File.Exists(file))
                  {
                     message = string.Format(@"File does not exist");

                     // This is needed for the following case
                     // If importing a DICOMDIR references a large number of files that do not exist, processing occurs so quickly that the import cannot be cancelled.
                     // So in the case that a file does not exists (i.e. abnormal condition), sleep for 100 ms to give the user time to cancel
                     Thread.Sleep(100);
                  }
               }

               count++ ;
               
               AddDicomWorkerProgressState state ;
               StoreClientSessionProxy     proxy ;
               InstanceCStoreCommand       cmd ;
               
               if (successfulLoad && !OnCancelStore(ds, out message))
               {
                  proxy = new StoreClientSessionProxy();
                  cmd = new InstanceCStoreCommand(proxy, ds, _DataAccess);


                  proxy.AffectedSOPInstance = ds.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
                  proxy.AbstractClass = ds.GetValue<string>(DicomTag.SOPClassUID, string.Empty);
                  proxy.ServerName = _AETitle;
                  proxy.ClientName = _AETitle;


                  ds.InsertElementAndSetValue(DicomTag.MediaStorageSOPInstanceUID, proxy.AffectedSOPInstance);
                  ds.InsertElementAndSetValue(DicomTag.ImplementationClassUID, _ImplementationClassUID);

                  state = new AddDicomWorkerProgressState();

                  OnStoreCommandCreated(this, new StoreCommandEventArgs(cmd));

                  cmd.Execute();

                  status = proxy.LastStatus;
                  message = proxy.LastStatusDescriptionMessage;
               }
               else
               {
                  state = new AddDicomWorkerProgressState();
                  status = DicomCommandStatusType.ProcessingFailure;
               }
               
               if ( status == DicomCommandStatusType.Success )
               {
                  successCount++ ;
                    
                  state.CurrentCount  = successCount ;
               }
               else
               {
                  
                  failureCount++ ;
                  
                  state.CurrentCount  = failureCount ;
               }
               
               state.Status        = status ;
               state.TotalCount    = dicomFiles.Count ;
               state.File          = file ;
               state.LoadedDataSet = ds ;
               state.Description   = message ;
               
               ReportProgress ( ( count * 100 )/dicomFiles.Count, state ) ;
            }
         }

         AddDicomWorkerResultState resultState = new AddDicomWorkerResultState();
         resultState.SuccessCount = successCount;
         resultState.FailedCount = failureCount;
         e.Result = resultState;
      }

      private List <string> GetDicomFiles ( DoWorkEventArgs e ) 
      {
         List <string> dicomFiles ;
         
         
         if ( ! ( ( e.Argument is string[] ) || e.Argument is string ) )
         {
            throw new ArgumentException ( "DoWork argument must contain a valid string array." ) ;
         }
         
         dicomFiles = new List<string> ( ) ;
         
         if ( e.Argument is string [ ] ) 
         {
            string [] files ;
            
            
            files = ( string [ ] ) e.Argument ;
            
            foreach ( string dicomFile in files ) 
            {
               FillDicomFiles ( dicomFile, dicomFiles ) ;
            }
         }
         else
         {
            FillDicomFiles ( e.Argument.ToString ( ), dicomFiles ) ;
         }

         return dicomFiles ;
      }

      private void FillDicomFiles ( string dicomFile, List<string> dicomFiles )
      {
         DicomDataSet dataset ;
         

         dataset = new DicomDataSet ( ) ;
         
         dataset.Load ( dicomFile, DicomDataSetLoadFlags.None ) ;

         using ( dataset )
         {
            if ( IsDicomDir ( dicomFile, dataset ) )
            {
               dicomFiles.AddRange ( GetDicomDirectoryImages ( dicomFile, dataset ) ) ;
            }
            else
            {
               dicomFiles.Add ( dicomFile ) ;
            }
         }
      }
      
      private bool IsDicomDir ( string file, DicomDataSet ds )
      {
         string name = Path.GetFileNameWithoutExtension(file);

         return (ds.InformationClass == DicomClassType.BasicDirectory);
      }
      
      private void OnStoreCommandCreated ( object sender, StoreCommandEventArgs e ) 
      {
         if ( null != StoreCommandCreated )
         {
            StoreCommandCreated ( sender, e ) ;
         }
      }
      
      private List <string> GetDicomDirectoryImages 
      (          
         string dicomFile, 
         DicomDataSet dataset 
      )
      {
         try
         {
            DicomElement    refernceFileElement ;
            List <string> dicomImages ;
            string baseDirectory ;
            
            
            refernceFileElement = null ;
            dicomImages         = new List <string> ( ) ;
            baseDirectory       = Path.GetDirectoryName ( dicomFile ) ;
            
            refernceFileElement = dataset.FindFirstElement ( null, 
                                                             DicomTag.ReferencedFileID, 
                                                             false ) ;
            
            if ( null != refernceFileElement )
            {
               dicomImages.Add ( Path.Combine ( baseDirectory, dataset.GetConvertValue ( refernceFileElement ) ) ) ;
            }
            
            while ( null != ( refernceFileElement = dataset.FindNextElement ( refernceFileElement, false ) ) )
            {
               dicomImages.Add ( Path.Combine ( baseDirectory, dataset.GetConvertValue ( refernceFileElement ) ) ) ;
            }
            
            return dicomImages ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw exception ;
         }
      }

      public string _ImplementationClassUID { get; set; }
      private string _AETitle;

      public string AETitle
      {
         get { return _AETitle; }
         set { _AETitle = value; }
      }
      IStorageDataAccessAgent _DataAccess ;
      
      public class AddDicomWorkerProgressState
      {
      
         public DicomCommandStatusType Status 
         {
            get
            {
               return _status ;
            }
            
            set
            {
               _status = value ;
            }
         }
         
         public DicomDataSet LoadedDataSet
         {
            get
            {
               return _dataset ;
            }
            
            set
            {
               _dataset = value ;
            }
         }
         
         public string File
         {
            get
            {
               return _file ;
            }
            
            set
            {
               _file = value ;
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
         
         public string Description
         {
            get
            {
               return _description ;
            }
            
            set
            {
               _description = value ;
            }
         }
         
         private DicomCommandStatusType    _status = DicomCommandStatusType.Success ;
         private DicomDataSet _dataset = null ;
         private string       _file = string.Empty ;
         private string       _description = string.Empty ;
         private int          _totalCount = 0 ;
         private int          _currentCount  = 0 ;
      }
      
      public class AddDicomWorkerResultState
      {
         public int SuccessCount 
         {
            get
            {
               return _successCount ;
            }
            
            set
            {
               _successCount = value ;
            }
         }
         
         public int FailedCount
         {
            get
            {
               return _failedCount ;
            }
            
            set
            {
               _failedCount = value ;
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

         public bool Cancelled
         {
            get
            {
               return _cancelled ;
            }
            
            set
            {
               _cancelled = value ;
            }
         }
         
         private int _failedCount = 0 ;
         
         private int _successCount = 0 ;

         private int _totalCount = 0 ;

         private bool _cancelled = false;
      }

      public class StoreClientSessionProxy : ICStoreClientSessionProxy
      {
         private string affectedSopInstance ;
         private string abstractClass ;
         private string _serverName ;
         
         public DicomCommandStatusType LastStatus ;
         public string LastStatusDescriptionMessage ;
         
         #region ICStoreClientSessionProxy Members

         public string AffectedSOPInstance
         {
            get
            {
               return affectedSopInstance ;
            }
            set
            {
               affectedSopInstance = value ;
            }
         }

         public void SendCStoreResponse(DicomCommandStatusType status, string descriptionMessage)
         {
            LastStatus  = status ;
            LastStatusDescriptionMessage = descriptionMessage ;
         }

         #endregion

         #region IDICOMCommandClientSessionProxy Members

         public string AbstractClass
         {
            get { return abstractClass; }
            set
            {
               abstractClass = value ;
            }
         }

         public int MessageID
         {
            get { return 0 ; }
         }

         public byte PresentationID
         {
            get { return 0 ; }
         }

         #endregion

         #region IClientSessionProxy Members

         private string _clientName;
         public string ClientName
         {
            get
            {
               if (!string.IsNullOrEmpty(_clientName))
               {
                  return _clientName.Trim();
               }
               return System.Threading.Thread.CurrentPrincipal.Identity.Name;
            }

            internal set
            {
               _clientName = value;
            }
         }

         public bool IsAssociated
         {
            get { return true ;}
         }

         public bool IsConnected
         {
            get { return true ; }
         }

         public void LogEvent
         (
            LogType enumType, 
            MessageDirection enumMessageDirection, 
            string strDescription, 
            DicomCommandType command,
            DicomDataSet DatasetRootElement,
            SerializableDictionary<string, object> customInfo
         )
         {
            
         }

         public string ServerName
         {
            get { return _serverName ; }
            set { _serverName = value ; }
         }

         #endregion
      }

   }
}
