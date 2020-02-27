// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentStructure
   {
      [DataMember(Name = "isParsed")]
      public bool IsParsed;

      [DataMember(Name = "bookmarks")]
      public List<DocumentBookmark> Bookmarks;

      [DataMember(Name = "parseBookmarks")]
      public bool ParseBookmarks;

      [DataMember(Name = "parsePageLinks")]
      public bool ParsePageLinks;
   }
}
