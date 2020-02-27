// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.AddIn.StorageCommit
{
   public class StorageCommitItem
   {
      private string _SOPInstanceUID;
      private string _SOPClassUID;
      private string _StudyInstanceUID;

      public string SOPInstanceUID
      {
         get { return _SOPInstanceUID; }
         set { _SOPInstanceUID = value; }
      }

      public string SOPClassUID
      {
         get { return _SOPClassUID; }
         set { _SOPClassUID = value; }
      }

      public string StudyInstanceUID
      {
         get { return _StudyInstanceUID; }
         set { _StudyInstanceUID = value; }
      }

      public DicomCommandStatusType Status;
   }
}
