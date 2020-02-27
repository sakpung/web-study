// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentBookmark
   {
      [DataMember(Name = "fontStyles")]
      public DocumentFontStyles FontStyles;

      [DataMember(Name = "children")]
      public List<DocumentBookmark> Children;

      [DataMember(Name = "target")]
      public DocumentLinkTarget Target;

      [DataMember(Name = "title")]
      public string Title;
   }
}
