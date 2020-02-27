// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Rules.AddIn.Common;

namespace Leadtools.Medical.Rules.AddIn.Dialogs
{
   public class GetFailuresEventArgs<T> : EventArgs
   {
      private Dictionary<string, T> _Failures = new Dictionary<string, T>();

      public Dictionary<string, T> Failures
      {
         get
         {
            return _Failures;
         }
          set
          {
              _Failures = value;
          }
      }
   }   
}
