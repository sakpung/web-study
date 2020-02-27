// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace Leadtools.Medical.WebViewer.Jobs.DataAccessLayer
{
   [Flags]
   public enum ListJobsFlags
   {
      None = 0,
      Status = 0x1,
      CompletedStatus = 0x2,
      NegateCompletedStatus = 0x4,
      Retries = 0x8,
      Owner = 0x10,
      TimeStamp = 0x20,
   }

   public interface IDownloadJobsDataAccessAgent
   {
      void AddJob
      (
          string sType,
          string sObject,
          int nStatus,
          int nCompletedStatus,
          string sUserData,
         string sOwner,
          out int nId
      );

      void SetJobStatus
      (
          int nId,
          int nStatus,
         int nCompletedStatus,
         bool bIncrementRetries,
         string sError
      );

      void ReadJobStatus
      (
          long nId,
          out int nStatus,
          out int nCompletedStatus,
          out string sError,
          out string sUserData
      );

      void ReadJob
      (
          long nId,
          out string sType,
          out string sObject,
          out int nStatus,
          out int nCompletedStatus,
          out DateTime time,
         out string sError,
         out string sUserData,
         out string sOwner
      );

      string[] ListJobs
      (
         string sOwner,
          int nStatus,
          int nCompletedStatus,
         int nMaxRetries,
         ListJobsFlags nFlags
      );

      void DeleteJobs
      (
         string sOwner,
         int nStatus,
         int nCompletedStatus,
         int nMinRetries,
         DateTime MinTimeStamp,
         ListJobsFlags nFlags
      );

      void DeleteJobs
      (
         string sOwner,
         int[] jobIds
      );

   }
}
