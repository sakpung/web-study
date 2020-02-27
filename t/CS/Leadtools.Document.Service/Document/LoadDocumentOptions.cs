// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class LoadDocumentOptions
   {
      [DataMember(Name = "name")]
      public string Name;

      [DataMember(Name = "mimeType")]
      public string MimeType;

      [DataMember(Name = "password")]
      public string Password;

      [DataMember(Name = "annotationsUri")]
      public Uri AnnotationsUri;

      [DataMember(Name = "loadEmbeddedAnnotations")]
      public bool LoadEmbeddedAnnotations;

      [DataMember(Name = "mayHaveDifferentPageSizes")]
      public bool MayHaveDifferentPageSizes;

      [DataMember(Name = "maximumImagePixelSize")]
      public int MaximumImagePixelSize;

      [DataMember(Name = "cacheOptions")]
      public DocumentCacheOptions CacheOptions;

      [DataMember(Name = "documentId")]
      public string DocumentId;

      [DataMember(Name = "firstPageNumber")]
      public int FirstPageNumber;

      [DataMember(Name = "lastPageNumber")]
      public int LastPageNumber;

      [DataMember(Name = "redactionOptions")]
      public DocumentRedactionOptions RedactionOptions;

      [DataMember(Name = "timeoutMilliseconds")]
      public int TimeoutMilliseconds;
   }
}
