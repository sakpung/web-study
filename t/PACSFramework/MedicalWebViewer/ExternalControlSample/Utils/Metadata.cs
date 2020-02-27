// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalControlSample
{
   public class Metadata
   {

      public Metadata(string patientId, string studyInstanceUid, string seriesInstanceUid, string sopInstanceUid)
      {
         PatientId = patientId;
         StudyInstanceUid = studyInstanceUid;
         SeriesInstanceUid = seriesInstanceUid;
         SopInstanceUid = sopInstanceUid;
      }

      public string PatientId
      {
         get;
         set;
      }

      public string StudyInstanceUid
      {
         get;
         set;
      }

      public string SeriesInstanceUid
      {
         get;
         set;
      }

      public string SopInstanceUid
      {
         get;
         set;
      }
   }
}
