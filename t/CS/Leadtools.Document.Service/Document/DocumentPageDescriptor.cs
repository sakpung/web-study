// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentPageDescriptor
   {
      [DataMember(Name = "documentId")]
      public string DocumentId;

      [DataMember(Name = "pageNumber")]
      public int PageNumber;

      [DataMember(Name = "originalPageNumber")]
      public int OriginalPageNumber = -1;

      [DataMember(Name = "size")]
      public LeadSize Size = new LeadSize();

      [DataMember(Name = "resolution")]
      public double Resolution;

      [DataMember(Name = "viewPerspective")]
      public RasterViewPerspective ViewPerspective = RasterViewPerspective.TopLeft;

      [DataMember(Name = "isDeleted")]
      public bool IsDeleted;
   }
}
