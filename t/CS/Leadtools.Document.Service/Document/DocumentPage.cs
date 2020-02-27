// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentPage
   {
      [DataMember(Name = "documentId")]
      public string DocumentId;

      [DataMember(Name = "pageNumber")]
      public int PageNumber;

      [DataMember(Name = "size")]
      public LeadSize Size;

      [DataMember(Name = "resolution")]
      public double Resolution;

      [DataMember(Name = "originalPageNumber")]
      public int OriginalPageNumber;

      [DataMember(Name = "isDeleted")]
      public bool IsDeleted;

      [DataMember(Name = "isImageModified")]
      public bool IsImageModified;

      [DataMember(Name = "isSvgBackImageModified")]
      public bool IsSvgBackImageModified;

      [DataMember(Name = "isThumbnailModified")]
      public bool IsThumbnailModified;

      [DataMember(Name = "isSvgModified")]
      public bool IsSvgModified;

      [DataMember(Name = "isTextModified")]
      public bool IsTextModified;

      [DataMember(Name = "isAnnotationsModified")]
      public bool IsAnnotationsModified;

      [DataMember(Name = "isLinksModified")]
      public bool IsLinksModified;

      [DataMember(Name = "links")]
      public List<DocumentLink> Links;

      [DataMember(Name = "isViewPerspectiveModified")]
      public bool IsViewPerspectiveModified;

      [DataMember(Name = "viewPerspective")]
      public RasterViewPerspective ViewPerspective;

      public bool IsViewPerspectiveRotated
      {
         get
         {
            var viewPerspective = this.ViewPerspective;
            return viewPerspective == RasterViewPerspective.TopLeft90 || viewPerspective == RasterViewPerspective.TopLeft270 || viewPerspective == RasterViewPerspective.BottomLeft90 || viewPerspective == RasterViewPerspective.BottomLeft270;
         }
      }

      public bool IsViewPerspectiveFlipped
      {
         get
         {
            var viewPerspective = this.ViewPerspective;
            return viewPerspective == RasterViewPerspective.BottomLeft || viewPerspective == RasterViewPerspective.BottomLeft90 || viewPerspective == RasterViewPerspective.BottomLeft180 || viewPerspective == RasterViewPerspective.BottomLeft270;
         }
      }

      public LeadSize ViewPerspectiveSize
      {
         get
         {
            var size = this.Size;

            if (IsViewPerspectiveRotated)
               size = LeadSize.Create(size.Height, size.Width);

            return size;
         }
      }

      public void Rotate(int angle)
      {
         var viewPerspective = this.ViewPerspective;
         viewPerspective = DocumentImages.RotateViewPerspective(viewPerspective, angle);
         this.ViewPerspective = viewPerspective;
      }

      public void Reverse()
      {
         var viewPerspective = this.ViewPerspective;
         viewPerspective = DocumentImages.ReverseViewPerspective(viewPerspective);
         this.ViewPerspective = viewPerspective;
      }

      public void Flip()
      {
         var viewPerspective = this.ViewPerspective;
         viewPerspective = DocumentImages.FlipViewPerspective(viewPerspective);
         this.ViewPerspective = viewPerspective;
      }

      public DocumentRotateFlip GetRotateFlip()
      {
         return DocumentImages.GetRotateFlip(this.ViewPerspective, RasterViewPerspective.TopLeft);
      }
   }
}
