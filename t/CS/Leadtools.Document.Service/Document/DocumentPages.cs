// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentPages : List<DocumentPage>
   {
      [DataMember(Name = "originalFirstPageNumber")]
      public int OriginalFirstPageNumber;

      [DataMember(Name = "originalLastPageNumber")]
      public int OriginalLastPageNumber;

      [DataMember(Name = "originalLastPageNumber")]
      public int OriginalPageCount;

      [DataMember(Name = "defaultResolution")]
      public double DefaultResolution;

      [DataMember(Name = "defaultPageSize")]
      public LeadSize DefaultPageSize;
   }
}
