// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace JobProcessorServerConfigDemo
{
   public struct WorkerData
   {
      public string Name;
      public int NewJobCheckPeriod;
      public List<JobType> JobTypes;
   }

   public struct JobType
   {
      public string Name;
      public int MaxNumberOfJobs;
      public int CPUThreshold;
      public bool UseCpuThreshold;
      public int ProgressRate;
      public int AssumeHangAfter;
      public int Attempts;
   }
}
