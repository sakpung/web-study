// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum PdfDocumentPageModeType
   {
      PageOnly = 0,
      BookmarksAndPage = 1,
      ThumbnailAndPage = 2,
      FullScreen = 3,
      LayerAndPage = 4,
      AttachmentsAndPage = 5
   }
}
