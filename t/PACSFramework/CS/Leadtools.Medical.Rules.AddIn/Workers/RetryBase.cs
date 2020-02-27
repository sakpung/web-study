// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Rules.AddIn.Workers
{
   public class RetryBase
   {
      public int Timeout { get; set; }
      public int NumberOfRetries { get; set; }
      public bool EnableRetry { get; set; }
   }
}
