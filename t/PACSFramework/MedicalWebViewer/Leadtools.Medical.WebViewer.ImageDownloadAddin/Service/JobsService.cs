// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.Jobs;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using System.Timers;
using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Medical.DataAccessLayer;

namespace Leadtools.Medical.WebViewer.ImageDownloadAddin
{
   public class JobsService
   {
      static JobsService _instance = null;
      static IStorageDataAccessAgent DataAccess = null;
      static IPatientRightsDataAccessAgent _PatientRightsDataAccess = null;
      static IDownloadJobsDataAccessAgent DownloadJobsDataAccessAgent = null;
      static Timer _timer;

      readonly static TimeSpan _UpdateInterval = new TimeSpan(1, 0, 0);
      readonly static int _MaxRetries = 3;

      public static JobsService Instance
      {
         get
         {
            if (null == _instance)
            {
               #region LOG
               {
                  string message = @"Image Download - Jobs Service Create Instance";
                  Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                                   LogType.Information, MessageDirection.None, message, null, null);
               }
               #endregion

               _instance = new JobsService();

               DataAccess = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
               _PatientRightsDataAccess = DataAccessServices.GetDataAccessService<IPatientRightsDataAccessAgent>();
               DownloadJobsDataAccessAgent = DataAccessServices.GetDataAccessService<IDownloadJobsDataAccessAgent>();

               _timer = new Timer(10000);
               _timer.Elapsed += new ElapsedEventHandler(_instance._timer_Elapsed);
               _timer.Enabled = true;
            }

            return _instance;
         }
         private set
         {
            if (_instance != null)
            {
               _instance.JobsQ.Dispose();               
            }
            _instance = value;
         }
      }

      static public void Init()
      {
         #region LOG
         {
            string message = @"Image Download - Initialize Jobs Service";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         JobsService inst = JobsService.Instance;
         JobsQeue.PatientRightsDataAccess = _PatientRightsDataAccess;
         JobsQeue.DataAccessAgent = DataAccess;
         JobsQeue.DownloadJobsDataAccessAgent = DownloadJobsDataAccessAgent;
         JobsQeue.MoveToAE = ImageDownloadSession.StorageServerAE;
      }

      static public void ShutDown()
      {
         #region LOG
         {
            string message = @"Image Download - Shutting down Jobs Service";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion

         JobsService.Instance = null;
         _timer.Enabled = false;
      }

      const int MaxConcurrentMoveJobs = 5;
      JobsQeue _jobsQ = null;

      public JobsQeue JobsQ
      {
         get
         {
            return _jobsQ;
         }
      }

      DateTime MileStone { get; set; }

      protected JobsService()
      {
         _jobsQ = new JobsQeue(MaxConcurrentMoveJobs);
         MileStone = DateTime.Now;
      }

      public void RetryFailedjobs()
      {
         #region LOG
         {
            string message = @"Image Download - Retry Failed jobs";
            Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now,
                             LogType.Information, MessageDirection.None, message, null, null);
         }
         #endregion
         
         try
         {
            JobsQ.ReQeueFailedJobs(_MaxRetries);
         }
         catch{//ignored         	
         }         
      }

      void _timer_Elapsed(object sender, ElapsedEventArgs e)
      {
         if (DateTime.Now - MileStone > _UpdateInterval)
         {
            try
            {
               _timer.Enabled = false;
               RetryFailedjobs();
            }
            catch
            {
            }
            finally
            {
               MileStone = DateTime.Now;
               _timer.Enabled = true;
            }
         }
      }
   }
}
