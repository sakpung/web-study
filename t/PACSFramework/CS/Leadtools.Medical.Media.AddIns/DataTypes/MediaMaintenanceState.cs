// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaMaintenanceState
   {
      public MediaMaintenanceState ( ) 
      {
         Enabled = false ;
         KeepIdleDurationInMinutes       = 1440 ;
         KeepPendingDurationInMinutes    = 1440 ;
         KeepProcessingDurationInMinutes = 1440 ;
         KeepFailedDurationInMinutes     = 1440 ;
         KeepCompletedDurationInMinutes  = 1440 ;
      }
      
      public bool Enabled
      {
         get ;
         set ;
      }
      
      public int KeepIdleDurationInMinutes
      {
         get ;
         set ;
      }
      
      public int KeepPendingDurationInMinutes
      {
         get ;
         set ;
      }
      
      public int KeepProcessingDurationInMinutes
      {
         get ;
         set ;
      }
      
      public int KeepFailedDurationInMinutes
      {
         get ;
         set ;
      }
      
      public int KeepCompletedDurationInMinutes
      {
         get ;
         set ;
      }
   }
}
