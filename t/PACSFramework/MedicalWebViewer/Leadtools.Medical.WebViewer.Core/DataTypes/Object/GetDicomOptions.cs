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
   /// Options for retreiving the DICOM DataSet
   /// </summary>
   [DataContract]
   public class GetDicomOptions
   {
      [DataMember]
      public bool StripImage { get; set; }
      [DataMember]
      public string TransferSyntax { get; set; }
      [DataMember]
      public int QualityFactor { get; set; }
   }
}
