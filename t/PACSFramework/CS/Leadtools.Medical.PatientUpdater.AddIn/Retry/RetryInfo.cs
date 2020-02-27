// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Medical.PatientUpdater.AddIn.Queue;

namespace Leadtools.Medical.PatientUpdater.AddIn.Retry
{
   [Serializable]
   public class RetryInfo
   {
      public DicomScp Scp { get; set; }      
      public DateTime Expires { get; set; }
      public AutoUpdateItem Item { get; set; }
      public string Address { get; set; }

      public RetryInfo()
      {
      }

      public RetryInfo(DicomScp scp, AutoUpdateItem item, string address)
      {
         Scp = scp;
         Item = item;
         Address = address;
      }
   }
}
