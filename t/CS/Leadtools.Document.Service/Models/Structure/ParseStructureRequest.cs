// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Structure
{
   [DataContract]
   public class ParseStructureRequest : Request
   {
      [DataMember(Name = "documentId")]
      public string DocumentId;

      [DataMember(Name = "parseBookmarks")]
      public bool ParseBookmarks;

      [DataMember(Name = "parsePageLinks")]
      public bool ParsePageLinks;
   }
}
