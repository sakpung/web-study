// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Leadtools.Dicom;

namespace Leadtools.Medical.Winforms
{
   public class CancelStoreEventArgs : CancelEventArgs
   {
      private DicomDataSet _DataSet;

      public DicomDataSet DataSet
      {
         get { return _DataSet; }
         set { _DataSet = value; }
      }

      public string CancelMessage { get; set; }

      public CancelStoreEventArgs(DicomDataSet ds)
      {
         _DataSet = ds;
      }
   }
}
