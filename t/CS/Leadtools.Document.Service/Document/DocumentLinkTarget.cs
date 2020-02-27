// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentLinkTarget
   {
      [DataMember(Name = "pageFitType")]
      public DocumentPageFitType PageFitType;

      [DataMember(Name = "pageNumber")]
      public int PageNumber;

      [DataMember(Name = "position")]
      public LeadPoint Position;

      [DataMember(Name = "zoomPercent")]
      public int ZoomPercent;
   }
}
