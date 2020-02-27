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
   [DataContract]
   public class StoreItemInfo
   {
      [DataMember]
      public string MimeType { get; set; }
      [DataMember]
      public int Width { get; set; }
      [DataMember]
      public int Height { get; set; }
      [DataMember]
      public int BitsPerPixel { get; set; }
      [DataMember]
      public int QualityFactor { get; set; }
   }
}
