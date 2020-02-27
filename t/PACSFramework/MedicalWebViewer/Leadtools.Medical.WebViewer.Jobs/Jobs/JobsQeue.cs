// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.WebViewer.Jobs
{
   public class JobsQeue : IDisposable
   {
      static long _nTotalWorkerThreads = 0;
      static private Semaphore _JobsPool = null;
      static Dictionary<int, JobProxy> _nWorkers = new Dictionary<int, JobProxy>();
      static object objWorkersLock = new object();
      private bool _disposed = false;

      static public IPatientRightsDataAccessAgent PatientRightsDataAccess = null;
      static public IStorageDataAccessAgent DataAccessAgent = null;
      static public IDownloadJobsDataAccessAgent DownloadJobsDataAccessAgent = null;
      static public string MoveToAE = string.Empty;

      public JobsQeue(int nMaxConcurrentJobs)
      {
         if (null == _JobsPool)
         {
            _JobsPool = new Semaphore(nMaxConcurrentJobs, nMaxConcurrentJobs);
         }
      }

      public void Dispose()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            Dispose(true);
            GC.SuppressFinalize(this);
         }
      }

      public virtual void Dispose(bool bUnmanaged)
      {
         ShutdownWorker();
      }

      void ShutdownWorker()
      {
         TimeSpan timeOut = new TimeSpan(0, 0, 10);

         DateTime dtStart = DateTime.Now;

         if (IsBusy)
         {
            CancelAllWorkers();
         }

         while (IsBusy)
         {
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(100));

            if (DateTime.Now - dtStart > timeOut)
            {
               break;
            }
         }

         _JobsPool = null;
      }

      bool IsBusy
      {
         get
         {
            long nTotalWorkerThreads = Interlocked.Read(ref _nTotalWorkerThreads);

            return nTotalWorkerThreads > 0;
         }
      }

      public void ReQeueFailedJobs(int nMaxRetries)
      {
         #region LOG
         {
            string message = @"ReQeueFailedJobs";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion	


         List<JobProxy> jpList = new List<JobProxy>();

         {
            ListJobsFlags nFlags = ListJobsFlags.None;

            nFlags |= ListJobsFlags.Status;
            nFlags |= ListJobsFlags.CompletedStatus;
            nFlags |= ListJobsFlags.NegateCompletedStatus;
            nFlags |= ListJobsFlags.Retries;

            string[] sIds = DownloadJobsDataAccessAgent.ListJobs("", (int)JobProxy.Status.completed, (int)JobProxy.CompletedStatus.success, nMaxRetries, nFlags);

            foreach (string sId in sIds)
            {
               try
               {
                  DownloadJobsDataAccessAgent.SetJobStatus(int.Parse(sId), (int)JobProxy.Status.pending, (int)JobProxy.CompletedStatus.undefined, false, "");
                  QeueJob(sId);
               }
               catch(Exception e)
               {
                  #region LOG
                  {
                     string message = @"ReQeueFailedJob Failure: " + e.Message;
                     Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                      LogType.Information, MessageDirection.None, message, null, null);
                  }
                  #endregion	

                  System.Diagnostics.Debug.Assert(false);
               }               
            }
         }         
      }

      public void QeueJob(string sJobId)
      {
         try
         {
            int nId = 0;
            if (!int.TryParse(sJobId, out nId))
            {
               throw new ArgumentException();
            }

            Interlocked.Increment(ref _nTotalWorkerThreads);
            if (!ThreadPool.QueueUserWorkItem(new WaitCallback(JobWorker), nId))
            {
               Interlocked.Decrement(ref _nTotalWorkerThreads);
               throw new Exception("Job could not be queued");
            }
         }
         catch(Exception e)
         {
            #region LOG
            {
               string message = @"QeueJob Failure: " + e.Message;
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	

            Interlocked.Decrement(ref _nTotalWorkerThreads);
         }
      }

      static void RegisterWorker(int nId, JobProxy job)
      {
         lock (objWorkersLock)
         {
            _nWorkers.Add(nId, job);
         }
      }

      static void UnRegisterWorker(int nId)
      {
         lock (objWorkersLock)
         {
            _nWorkers.Remove(nId);
         }
      }

      public void CancelAllWorkers()
      {
         #region LOG
         {
            string message = @"CancelAllWorkers";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion	

         lock (objWorkersLock)
         {
            foreach (KeyValuePair<int, JobProxy> item in _nWorkers)
            {
               try
               {
                  item.Value.Cancel();
               }
               catch
               {
                  //ignore
               }               
            }
         }
      }

      public void CancelWorker(int nId)
      {
         #region LOG
         {
            string message = @"CancelWorker: " + nId;
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion	

         lock (objWorkersLock)
         {
            JobProxy job = null;
            if (_nWorkers.TryGetValue(nId, out job))
            {
               try
               {
                  job.Cancel();
               }
               catch
               {
                  //ignore
               }
            }
         }
      }

      static void JobWorker(Object stateInfo)
      {

         int nId = 0;
         JobProxy jp = null;
         
         try
         {
            _JobsPool.WaitOne();

            nId = (int)stateInfo;

            jp = new JobProxy(DownloadJobsDataAccessAgent) { Id = nId };

            RegisterWorker(nId, jp);

            jp.Execute();

         }
         catch (Exception e)
         {
            #region LOG
            {
               string message = @"Job Worker Failure (most likely a db connection issue): " + e.Message;
               Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                LogType.Information, MessageDirection.None, message, null, null);
            }
            #endregion	

#if DEBUG
            System.Diagnostics.Trace.WriteLine(e.Message);
            System.Diagnostics.Debugger.Break();
            //most likely a db connection issue
#endif
            //since most errors here are caused by db provider, we cant update the job status
            //exception ignored
         }
         finally
         {
            UnRegisterWorker(nId);

            Interlocked.Decrement(ref _nTotalWorkerThreads);

            _JobsPool.Release();
         }
      }
   }
}
