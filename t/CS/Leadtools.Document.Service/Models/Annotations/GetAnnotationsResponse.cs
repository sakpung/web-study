// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Annotations
{
   [DataContract]
   public class GetAnnotationsResponse : Response
   {
      /// <summary>
      /// Dictionary of added LEAD annotations (where the key is the annotation guid).
      /// </summary>
      [DataMember(Name = "added")]
      public Dictionary<string, string> Added;

      /// <summary>
      /// Dictionary of modified LEAD annotations (where the key is the annotation guid).
      /// </summary>
      [DataMember(Name = "modified")]
      public Dictionary<string, string> Modified;

      /// <summary>
      /// Dictionary of deleted LEAD annotations (where the key is the annotation guid and value is null).
      /// </summary>
      [DataMember(Name = "deleted")]
      public Dictionary<string, string> Deleted;
   }
}
