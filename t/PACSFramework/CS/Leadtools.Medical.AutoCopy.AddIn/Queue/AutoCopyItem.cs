// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;

namespace Leadtools.Medical.AutoCopy.AddIn.Queue
{
   /// <summary>
   /// Stores sop instance of items that need to be copied.
   /// </summary>
   public class AutoCopyItem
   {
      public string SourceAE { get; private set; }
      public string ClientAE { get; internal set; }
      public ThreadSafeList<string> Datasets { get; internal set; }

      public AutoCopyItem(string ae)
      {
         SourceAE = ae;
         Datasets = new ThreadSafeList<string>();
      }
   }
}
