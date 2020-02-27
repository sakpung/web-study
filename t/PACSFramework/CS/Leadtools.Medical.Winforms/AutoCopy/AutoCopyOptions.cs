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
   [Serializable]
   public class AutoCopyOptions
   {
      public bool EnableAutoCopy { get; set; }
      public int AutoCopyThreads { get; set; }
      public bool UseCustomAE { get; set; }
      public string AutoCopyAE { get; set; }

      public AutoCopyOptions()
      {
         EnableAutoCopy = false;
         AutoCopyThreads = 1;
         UseCustomAE = false;
      }
   }
}
