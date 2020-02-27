// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;

namespace Leadtools.Medical.Rules.AddIn.Scripting.Actions
{
   public class SchedulerActions
   {
      [CLSCompliant(false)]
      public static Job find_job(string jobId)
      {
         return Module.Scheduler.TryGetJob(jobId);
      }
   }
}
