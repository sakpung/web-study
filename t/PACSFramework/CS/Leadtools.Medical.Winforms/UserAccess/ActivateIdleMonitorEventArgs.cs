// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   public class ActivateIdleMonitorEventArgs : EventArgs
   {
      private bool _Activate;

      public bool Activate
      {
         get { return _Activate; }
         set { _Activate = value; }
      }

      public ActivateIdleMonitorEventArgs(bool activate)
      {
         _Activate = activate;
      }
   }
   
   public class ExitMinimizedStateEventArgs : EventArgs
   {
      private long _minimizedSeconds;

      public long MinimizedSeconds
      {
         get { return _minimizedSeconds; }
         set { _minimizedSeconds = value; }
      }
      
      public ExitMinimizedStateEventArgs(long minimizedSeconds)
      {
         _minimizedSeconds = minimizedSeconds;
      }
      
   }
}
