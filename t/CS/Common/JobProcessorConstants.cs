// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadtools.Demos
{
   class JobProcessorConstants
   {
      public class Database
      {
         public const string JobsTable = "JobsTable";
         public const string GuidColumn = "cGuid";
         public const string StatusColumn = "cStatus";
         public const string WorkerColumn = "cWorker";
         public const string AttemptsColumn = "cAttempts";
         public const string PercentageColumn = "cPercentage";
         public const string AddedTimeColumn = "cAddedTime";
         public const string LastStartedTimeColumn = "cLastStartedTime";
         public const string LastUpdatedTimeColumn = "cLastUpdatedTime";
         public const string CompletedTimeColumn = "cCompletedTime";
         public const string FailedTimeColumn = "cFailedTime";
         public const string FailedErrorIDColumn = "cFailedErrorID";
         public const string FailedMessageColumn = "cFailedMessage";
         public const string MustAbortColumn = "cMustAbort";
         public const string AbortReasonColumn = "cAbortReason";
         public const string UserTokenColumn = "cUserToken";
         public const string JobMetadataColumn = "cJobMetadata";
         public const string WorkerMetadataColumn = "cWorkerMetadata";
         public const string JobTypeColumn = "cJobType";
      }
   }
}
