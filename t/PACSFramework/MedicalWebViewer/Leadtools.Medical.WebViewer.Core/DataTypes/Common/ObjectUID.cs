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
   /// Object UIDs
   /// </summary>
   [DataContract]
   public class ObjectUID
   {
      [DataMember]
      public string StudyInstanceUID { get; set; }
      [DataMember]
      public string SeriesInstanceUID { get; set; }
      [DataMember]
      public string SOPInstanceUID { get; set; }
   }
}
