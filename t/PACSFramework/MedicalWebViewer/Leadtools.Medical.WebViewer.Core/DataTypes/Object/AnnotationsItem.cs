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
   public class AnnotationIdentifier
   {
      [DataMember]
      public string AnnotationID { get ; set ; }
      [DataMember]
      public string SeriesInstanceUID { get ; set ; }
      [DataMember]
      public string UserData { get ; set ; }
   }
}
