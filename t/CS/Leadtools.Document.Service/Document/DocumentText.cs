// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentText
   {
      [DataMember(Name = "textExtractionMode")]
      public DocumentTextExtractionMode TextExtractionMode;

      [DataMember(Name = "imagesRecognitionMode")]
      public DocumentTextImagesRecognitionMode ImagesRecognitionMode;

      [DataMember(Name = "autoParseLinks")]
      public bool AutoParseLinks;

      [DataMember(Name = "parseBookmarks")]
      public bool ParseBookmarks;

      [DataMember(Name = "parsePageLinks")]
      public bool ParsePageLinks;
   }
}
