// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentViewOptions
   {
      [DataMember(Name = "viewLayout")]
      public DocumentViewLayout ViewLayout = DocumentViewLayout.Vertical;

      [DataMember(Name = "annotationsUserMode")]
      public DocumentViewAnnotationsUserMode AnnotationsUserMode = DocumentViewAnnotationsUserMode.Design;

      [DataMember(Name = "pageNumber")]
      public int PageNumber = 1;

      [DataMember(Name = "viewZoomPercent")]
      public double ViewZoomPercent = 1;

      [DataMember(Name = "viewScrollOffset")]
      public LeadPoint ViewScrollOffset = new LeadPoint();

      [DataMember(Name = "viewSizeMode")]
      public DocumentViewSizeMode ViewSizeMode = DocumentViewSizeMode.ActualSize;

      [DataMember(Name = "viewItemType")]
      public DocumentViewItemType ViewItemType = DocumentViewItemType.Svg;

      [DataMember(Name = "loadAnnotations")]
      public bool LoadAnnotations = true;

      [DataMember(Name = "loadThumbnails")]
      public bool LoadThumbnails = true;

      [DataMember(Name = "loadBookmarks")]
      public bool LoadBookmarks = true;

      [DataMember(Name = "viewCommands")]
      public List<DocumentViewCommand> ViewCommands = new List<DocumentViewCommand>();
   }
}
