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
   public class GetAnnotationsOptions
   {
      /// <summary>
      /// Annotations type to get
      /// </summary>
      [DataMember]
      public ImageAnnotationsType AnnotationsType { get; set; }
   }
}
