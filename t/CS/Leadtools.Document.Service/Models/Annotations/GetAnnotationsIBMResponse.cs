// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Annotations
{
   [DataContract]
   public class GetAnnotationsIBMResponse : Response
   {
      /// <summary>
      /// Dictionary of added IBM-P8 annotations (where the key is the annotation guid).
      /// </summary>
      [DataMember(Name = "added")]
      public Dictionary<string, string> Added;

      /// <summary>
      /// Dictionary of modified IBM-P8 annotations (where the key is the annotation guid).
      /// </summary>
      [DataMember(Name = "modified")]
      public Dictionary<string, string> Modified;

      /// <summary>
      /// Dictionary of deleted IBM-P8 annotations (where the key is the annotation guid and value is null).
      /// </summary>
      [DataMember(Name = "deleted")]
      public Dictionary<string, string> Deleted;
   }
}
