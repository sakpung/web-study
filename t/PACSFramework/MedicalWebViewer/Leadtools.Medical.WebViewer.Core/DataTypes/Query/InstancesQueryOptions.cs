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
   /// Contains the query parameters for DICOM Instance 
   /// </summary>
   [DataContract]
   public class InstancesQueryOptions
   {
      [DataMember]
      public string InstanceNumber { get; set; }
      [DataMember]
      public string SOPInstanceUID { get; set; }
   }
}
