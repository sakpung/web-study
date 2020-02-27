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

namespace Leadtools.Medical.WebViewer.Jobs
{
   public class JobsProxy
   {
      IDownloadJobsDataAccessAgent _DownloadJobsDataAccessAgent = null;
      public JobsProxy(IDownloadJobsDataAccessAgent DownloadJobsDataAccessAgent)
      {
         if (null == DownloadJobsDataAccessAgent)
         {
            throw new ArgumentException();
         }

         _DownloadJobsDataAccessAgent = DownloadJobsDataAccessAgent;
      }

      public JobProxy[] GetAll(JobProxy.Status status, JobProxy.CompletedStatus completedstatus, string sUserName)
      {
         List<JobProxy> jpList = new List<JobProxy>();

         {
            ListJobsFlags nFlags = ListJobsFlags.None;

            if (status != JobProxy.Status.undefined)
            {
               nFlags |= ListJobsFlags.Status;
            }
            if (completedstatus != JobProxy.CompletedStatus.undefined)
            {
               nFlags |= ListJobsFlags.CompletedStatus;
            }
            if (!string.IsNullOrEmpty(sUserName))
            {
               nFlags |= ListJobsFlags.Owner;
            } 
            
            string[] sIds = _DownloadJobsDataAccessAgent.ListJobs(sUserName, (int)status, (int)completedstatus, 0, nFlags);

            foreach (string sId in sIds)
            {
               jpList.Add(new JobProxy(_DownloadJobsDataAccessAgent) { Id = int.Parse(sId) });
            }
         }

         return jpList.ToArray();
      }
   }
}
