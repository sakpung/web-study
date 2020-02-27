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
   /// contains the matching parameters for querying a series.
   /// </summary>
   [DataContract]
   public class SeriesQueryOptions
   {
      [DataMember]
      public string Modality { get; set; }
      [DataMember]
      public string SeriesNumber { get; set; }
      [DataMember]
      public string SeriesInstanceUID { get; set; }
      [DataMember]
      public string SeriesDateStart { get; set; }
      [DataMember]
      public string SeriesDateEnd { get; set; }
      [DataMember]
      public string SeriesDescription { get; set; }
   }
}
