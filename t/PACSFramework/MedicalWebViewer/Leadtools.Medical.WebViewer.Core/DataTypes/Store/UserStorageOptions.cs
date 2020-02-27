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
   public class UserStorageOptions
   {
      [DataMember]
      public bool EnablePreCompressesImage { get; set; }
      [DataMember]
      public string LossyCompressionMimeType { get; set; }
      [DataMember]
      public string LosslessCompressionMimeType { get; set; }
      [DataMember]
      public int LossyCompressionQFactor { get; set; }
      [DataMember]
      public bool EnablePreGeneratedThumbnail { get; set; }
      [DataMember]
      public int ThumbnailWidth { get; set; }
      [DataMember]
      public int ThumbnailHeight { get; set; }
   }
}
