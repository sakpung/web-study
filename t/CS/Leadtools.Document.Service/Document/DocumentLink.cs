// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentLink
   {
      [DataMember(Name = "bounds")]
      public LeadRect Bounds;

      [DataMember(Name = "linkType")]
      public DocumentLinkType LinkType;

      [DataMember(Name = "value")]
      public string Value;

      [DataMember(Name = "target")]
      public DocumentLinkTarget Target;
   }
}
