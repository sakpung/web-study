// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Contains the matching parameters for a study level query
   /// </summary>
   [DataContract]
   public class StudiesQueryOptions
   {
      [DataMember]
      public string StudyID { get; set; }
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
      [DataMember]
      public string[] ModalitiesInStudy { get; set; }
      [DataMember]
      public string AccessionNumber { get; set; }
      [DataMember]
      public string ReferDoctorName { get; set; }
      [DataMember]
      public string StudyDateStart { get; set; }
      [DataMember]
      public string StudyDateEnd { get; set; }
      [DataMember]
      public string StudyTimeStart { get; set; }
      [DataMember]
      public string StudyTimeEnd { get; set; }
      [DataMember]
      public string StudyInstanceUID { get; set; }
   }
}
