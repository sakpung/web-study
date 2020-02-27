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
   /// not used
   /// </summary>
   [DataContract]
   public class FilterResultsOptions
   {
      [DataMember]
      public string SortField { get; set; }
      [DataMember]
      public bool Ascending { get; set; }
      [DataMember]
      public int MaxRows { get; set; }
   }
}
