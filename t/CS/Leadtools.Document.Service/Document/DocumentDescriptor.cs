// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentDescriptor
   {
      [DataMember(Name = "documentId")]
      public string DocumentId;

      [DataMember(Name = "name")]
      public string Name;

      [DataMember(Name = "userId")]
      public string UserId;

      [DataMember(Name = "autoDeleteFromCache")]
      public bool AutoDeleteFromCache = true;

      [DataMember(Name = "autoSaveToCache")]
      public bool AutoSaveToCache = true;

      [DataMember(Name = "autoDisposeDocuments")]
      public bool AutoDisposeDocuments;

      [DataMember(Name = "isReadOnly")]
      public bool IsReadOnly;

      [DataMember(Name = "mimeType")]
      public string MimeType;

      [DataMember(Name = "defaultPageSize")]
      public LeadSize DefaultPageSize = LeadSize.Create(8.5 * LEADDocument.UnitsPerInch, 11 * LEADDocument.UnitsPerInch);

      [DataMember(Name = "defaultResolution")]
      public double DefaultResolution;

      [DataMember(Name = "defaultBitsPerPixel")]
      public int DefaultBitsPerPixel = 24;

      [DataMember(Name = "maximumImagePixelSize")]
      public int MaximumImagePixelSize;

      [DataMember(Name = "thumbnailPixelSize")]
      public LeadSize ThumbnailPixelSize = LeadSize.Create(128, 128);

      [DataMember(Name = "unembedSvgImages")]
      public bool UnembedSvgImages;

      [DataMember(Name = "documentType")]
      public string DocumentType;

      [DataMember(Name = "loadDocumentOptions")]
      public LoadDocumentOptions LoadDocumentOptions;

      [DataMember(Name = "isStructureParsed")]
      public bool IsStructureParsed;

      [DataMember(Name = "isStructureSupported")]
      public bool IsStructureSupported;

      [DataMember(Name = "isSvgSupported")]
      public bool IsSvgSupported;

      [DataMember(Name = "isSvgViewingPreferred")]
      public bool IsSvgViewingPreferred;

      [DataMember(Name = "isResolutionsSupported")]
      public bool IsResolutionsSupported;

      [DataMember(Name = "textExtractionMode")]
      public DocumentTextExtractionMode TextExtractionMode = DocumentTextExtractionMode.Auto;

      [DataMember(Name = "imagesRecognitionMode")]
      public DocumentTextImagesRecognitionMode ImagesRecognitionMode = DocumentTextImagesRecognitionMode.Auto;

      [DataMember(Name = "autoParseLinks")]
      public bool AutoParseLinks = true;

      [DataMember(Name = "parseBookmarks")]
      public bool ParseBookmarks = true;

      [DataMember(Name = "parsePageLinks")]
      public bool ParsePageLinks = true;

      [DataMember(Name = "cacheOptions")]
      public DocumentCacheOptions CacheOptions = DocumentCacheOptions.None;

      [DataMember(Name = "metadata")]
      public string Metadata;

      [DataMember(Name = "pages")]
      public DocumentPageDescriptor[] Pages;

      [DataMember(Name = "viewOptions")]
      public DocumentViewOptions ViewOptions;

      [DataMember(Name = "redactionOptions")]
      public DocumentRedactionOptions RedactionOptions;
   }
}
