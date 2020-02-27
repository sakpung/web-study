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
   /// Not used
   /// </summary>
   [DataContract]
   public class GetImagesOptions
   {
      [DataMember]
      public int Width { get; set; }
      [DataMember]
      public int Height { get; set; }
      [DataMember]
      public string MimeType { get; set; }
      [DataMember]
      public int BitsPerPixel { get; set; }
      [DataMember]
      public int QualityFactor { get; set; }
   }
}
