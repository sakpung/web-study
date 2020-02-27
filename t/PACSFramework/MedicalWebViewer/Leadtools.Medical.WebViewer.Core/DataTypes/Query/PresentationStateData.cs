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
   /// extends the instance data to include some presentation state specific data
   /// </summary>
   [DataContract]
   public class PresentationStateData : InstanceData
   {
      [DataMember]
      public string ContentLabel { get ; set ; }
      [DataMember]
      public string ContentDescription { get ; set ; }
      [DataMember]
      public string  ContentCreatorName { get ; set ; }
      [DataMember]
      public string CreationDate { get ; set ; }
      [DataMember]
      public List<string> ReferencedSOPInstanceUIDs { get; set; }
   }
}
