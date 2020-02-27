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
   /// the matching parameters for a patient level.
   /// </summary>
   [DataContract]
   public class PatientsQueryOptions
   {
      [DataMember]
      public string PatientName { get; set; }
      [DataMember]
      public string PatientID { get; set; }
      [DataMember]
      public string Sex { get; set; }
      [DataMember]
      public string BirthDate { get; set; }
      [DataMember]
      public string EthnicGroup { get; set; }
      [DataMember]
      public string Comments { get; set; }
   }
}
