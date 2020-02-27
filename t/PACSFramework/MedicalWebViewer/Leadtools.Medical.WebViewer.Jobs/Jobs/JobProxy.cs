// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;

namespace Leadtools.Medical.WebViewer.Jobs
{
   public class JobProxy
   {
      private int _id = 0;
      private bool _idisset = false;
      private IDownloadJobsDataAccessAgent _DownloadJobsDataAccessAgent = null;
      
      public JobProxy(IDownloadJobsDataAccessAgent DownloadJobsDataAccessAgent)
      {
         if (null == DownloadJobsDataAccessAgent)
         {
            throw new ArgumentException();
         }

         _DownloadJobsDataAccessAgent = DownloadJobsDataAccessAgent;
      }

      void CheckHasId()
      {
         try
         {
            if (!_idisset)
            {
               throw new Exception("JobProxy - id is required");
            }
         }
         catch (System.Exception ex)
         {
            #region LOG
            {
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, ex.Message, null, null);
            }
            #endregion	
            throw;
         }
      }
      
      public bool Match(string PatientID,
         string StudyInstanceUID,
         string SeriesInstanceUID,
         string SOPInstanceUID)
      {
         if (string.IsNullOrEmpty(PatientID) &&
         string.IsNullOrEmpty(StudyInstanceUID) &&
         string.IsNullOrEmpty(SeriesInstanceUID) &&
         string.IsNullOrEmpty(SOPInstanceUID))
         {
            return true;
         }

         if (!_idisset)
         {
            return true;
         }

         //have to load details...

         string sType;
         string sObject;
         string sUserData;
         string sError;
         string sOwner;
         int nStatus;
         int nCompletedStatus;
         DateTime time;

         _DownloadJobsDataAccessAgent.ReadJob(Id, out sType, out sObject, out nStatus, out nCompletedStatus, out time, out sError, out sUserData, out sOwner);

         using (MoveObjectsJob job = CreateJob(sType, sObject, ""))
         {
            if (null == job.DataSet)
            {
               return false;
            }

            ReverseDicomDatasetAdapter dataSetReader = new ReverseDicomDatasetAdapter()
            {
               query = job.DataSet
            };

            string curPatientID = dataSetReader.PatientID;
            string curStudyInstanceUID = dataSetReader.StudyInstanceUID;
            string curSeriesInstanceUID = dataSetReader.SeriesInstanceUID;
            string curSOPInstanceUID = dataSetReader.SOPInstanceUID;

            if (
               ((PatientID == curPatientID) || (string.IsNullOrEmpty(PatientID) && string.IsNullOrEmpty(curPatientID))) &&
               ((StudyInstanceUID == curStudyInstanceUID) || (string.IsNullOrEmpty(StudyInstanceUID) && string.IsNullOrEmpty(curStudyInstanceUID))) &&
               ((SeriesInstanceUID == curSeriesInstanceUID) || (string.IsNullOrEmpty(SeriesInstanceUID) && string.IsNullOrEmpty(curSeriesInstanceUID))) &&
               ((SOPInstanceUID == curSOPInstanceUID) || (string.IsNullOrEmpty(SOPInstanceUID) && string.IsNullOrEmpty(curSOPInstanceUID)))
               )
            {
               return true;
            }
         }

         return false;
      }

      public int Id
      {
         set
         {
            _idisset = true;
            _id = value;
         }
         get
         {
            return _id;
         }
      }

      public enum Status
      {
         idle,
         pending,
         running,
         completed,
         undefined
      }

      public enum CompletedStatus
      {
         success,
         failed,
         aborted,
         undefined
      }

      public void Cancel()
      {
         CheckHasId();

         lock (_jobLock)
         {
            if (_job != null)
            {
               #region LOG
               {
                  string message = @"Job Aborted";
                  Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                   LogType.Information, MessageDirection.None, message, null, null);
               }
               #endregion	

               _job.TriggerAbort();
            }
         }
      }

      public void Execute()
      {
         CheckHasId();

         BookJob();

         Run();
      }

      private Job _job = null;
      private object _jobLock = new object();

      private void Run()
      {
         try
         {

            string sType;
            string sObject;
            string sUserData;
            string sError;
            string sOwner;
            int nStatus;
            int nCompletedStatus;
            DateTime time;

            #region LOG
            {
               string message = @"Reading Job";
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion

            _DownloadJobsDataAccessAgent.ReadJob(Id, out sType, out sObject, out nStatus, out nCompletedStatus, out time, out sError, out sUserData, out sOwner);
            
            using (Job job = CreateJob(sType, sObject, sOwner))
            {
               #region LOG
               {
                  string message = @"Job Created";
                  Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                   LogType.Information, MessageDirection.None, message, null, null);
               }
               #endregion

               lock (_jobLock)
               {
                  _job = job;
               }

               SetBusy();

               _job.StartJob();
               #region LOG
               {
                  string message = @"Job Started";
                  Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                   LogType.Information, MessageDirection.None, message, null, null);
               }
               #endregion

               if (_job.isAborted)
               {
                  #region LOG
                  {
                     string message = @"Job Aborted";
                     Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                      LogType.Information, MessageDirection.None, message, null, null);
                  }
                  #endregion

                  SetAborted();
               }
               else if (_job.isFailed)
               {
                  #region LOG
                  {
                     string message = @"Job Failed: " + _job.LastError;
                     Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                      LogType.Information, MessageDirection.None, message, null, null);
                  }
                  #endregion

                  SetFailed(_job.LastError);
               }
               else
               {
                  #region LOG
                  {
                     string message = @"Job Succeeded";
                     Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                      LogType.Information, MessageDirection.None, message, null, null);
                  }
                  #endregion
                  SetCompleted();
               }
            }
         }
         catch (System.Exception ex)
         {
            #region LOG
            {
               string message = @"Job Failed: " + ex.Message;
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion

            SetFailed(ex.Message);
         }
         finally
         {
            lock (_jobLock)
            {
               _job = null;
            }
         }
      }

      private void BookJob()
      {
         SetPending();
      }

      public void GetStatus(out JobProxy.Status status, out JobProxy.CompletedStatus completedstatus, out string sError, out string sUserData)
      {
         int nStatus;
         int nCompletedstatus;

         CheckHasId();
         _DownloadJobsDataAccessAgent.ReadJobStatus(Id, out nStatus, out nCompletedstatus, out sError, out sUserData);
         status = (Status)nStatus;
         completedstatus = (CompletedStatus)nCompletedstatus;
      }

      public void GetAllDetails
         (
         out JobProxy.Status status,
         out JobProxy.CompletedStatus completedstatus,
         out string sError,
         out string sUserData,
         out string sOwner,
         out string PatientID,
         out string StudyInstanceUID,
         out string SeriesInstanceUID,
         out string SOPInstanceUID,
         out string ServerAE,
         out string ServerIP,
         out int ServerPort,
         out int ServerTimeout,
         out string ClientAE,
         out string MoveToClientAE,
         out string ClientIP,
         out int ClientPort
         )
      {

         string sType;
         string sObject;
         int nStatus;
         int nCompletedStatus;
         DateTime time;


         PatientID = string.Empty;
         StudyInstanceUID = string.Empty;
         SeriesInstanceUID = string.Empty;
         SOPInstanceUID = string.Empty;

         ServerAE = string.Empty;
         ServerIP = string.Empty;
         ServerPort = 0;
         ServerTimeout = 0;
         ClientAE = string.Empty;
         MoveToClientAE = string.Empty;
         ClientIP = string.Empty;
         ClientPort = 0;

         CheckHasId();

         _DownloadJobsDataAccessAgent.ReadJob(Id, out sType, out sObject, out nStatus, out nCompletedStatus, out time, out sError, out sUserData, out sOwner);

         status = (Status)nStatus;
         completedstatus = (CompletedStatus)nCompletedStatus;

         using (MoveObjectsJob job = CreateJob(sType, sObject, sOwner))
         {
            ServerAE = job.ServerAE;
            ServerIP = job.ServerIP;
            ServerPort = job.ServerPort;
            ServerTimeout = job.ServerTimeout;
            ClientAE = job.ClientAE;
            MoveToClientAE = job.MoveToClientAE;
            ClientIP = job.ClientIP;
            ClientPort = job.ClientPort;

            if (null != job.DataSet)
            {
               ReverseDicomDatasetAdapter dataSetReader = new ReverseDicomDatasetAdapter()
               {
                  query = job.DataSet
               };

               PatientID = dataSetReader.PatientID;
               StudyInstanceUID = dataSetReader.StudyInstanceUID;
               SeriesInstanceUID = dataSetReader.SeriesInstanceUID;
               SOPInstanceUID = dataSetReader.SOPInstanceUID;
            }
         }
      }

      private void SetPending()
      {
         CheckHasId();
         _DownloadJobsDataAccessAgent.SetJobStatus(Id, (int)Status.pending, (int)CompletedStatus.failed, false, "");
      }
      private void SetBusy()
      {
         CheckHasId();
         _DownloadJobsDataAccessAgent.SetJobStatus(Id, (int)Status.running, (int)CompletedStatus.failed, false, "");
      }
      public void SetFailed(string sError)
      {
         CheckHasId();
         _DownloadJobsDataAccessAgent.SetJobStatus(Id, (int)Status.completed, (int)CompletedStatus.failed, true, sError);
      }
      public void SetFailed_NotExecutedYet(string sError)
      {
         CheckHasId();
         _DownloadJobsDataAccessAgent.SetJobStatus(Id, (int)Status.completed, (int)CompletedStatus.failed, false, sError);
      }
      private void SetAborted()
      {
         CheckHasId();
         _DownloadJobsDataAccessAgent.SetJobStatus(Id, (int)Status.completed, (int)CompletedStatus.aborted, false, "Aborted");
      }
      private void SetCompleted()
      {
         CheckHasId();
         _DownloadJobsDataAccessAgent.SetJobStatus(Id, (int)Status.completed, (int)CompletedStatus.success, false, "");
      }

      private static MoveObjectsJob CreateJob(string sType, string sObj, string sOwner)
      {
         MoveObjectsJob moj = JobsPersistence.Load<MoveObjectsJob>(sObj);
         moj.PatientRightsDataAccess = JobsQeue.PatientRightsDataAccess;
         moj.DataAccessAgent = JobsQeue.DataAccessAgent;
         moj.Owner = sOwner;
         if (null != moj.Settings)
         {
            moj.Settings.MoveToClientAE = JobsQeue.MoveToAE;
         }
         return moj;
      }

      public void AddJob
      (
          string sType,
          string sObject,
          int nStatus,
          int nCompletedStatus,
          string sUserData,
         string sOwner
      )
      {
         int nJobId = 0;

         _DownloadJobsDataAccessAgent.AddJob(sType, sObject, (int)Status.idle, (int)CompletedStatus.failed, sUserData, sOwner, out nJobId);

         #region LOG
         {
            string message = @"New Job Added";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         Id = nJobId;
      }
   }
}
