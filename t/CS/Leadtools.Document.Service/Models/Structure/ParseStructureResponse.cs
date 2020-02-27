// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Structure
{
   [DataContract]
   public class ParseStructureResponse : Response
   {
      [DataMember(Name = "bookmarks")]
      public DocumentBookmark[] Bookmarks;

      [DataMember(Name = "pageLinks")]
      public DocumentLink[][] PageLinks;
   }
}
