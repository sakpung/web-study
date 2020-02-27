// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   
   public class MPPSQuery
   {
      
      public string AccessionNumber { get; set; }
      
      public string RequestedProcedureId { get; set; }
      
      public string ScheduledProcedureId { get; set; }
      
      public WCFPatient Patient { get; set; }
      
      public WCFPPSInformation PPSInfo { get; set; }
   }
}
