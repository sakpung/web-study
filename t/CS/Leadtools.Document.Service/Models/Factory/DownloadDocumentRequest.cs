// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   public class DownloadDocumentRequest : Request
   {
      /// <summary>
      /// The ID of the document in the cache to download. Cannot be used if URI is used.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The URI to the document to download. Cannot be used if ID is used.
      /// This may be a cache URI.
      /// </summary>
      [DataMember(Name = "uri")]
      public Uri Uri;

      /// <summary>
      /// If true, external annotations will be returned as well (the result will be a ZIP).
      /// </summary>
      [DataMember(Name = "includeAnnotations")]
      public bool IncludeAnnotations;


      /// <summary>
      /// Content disposition
      /// This is optional, if the value is null or empty, then the response Content-Disposition header will be set to either attachment or inline depending on the mime file type.
      /// Otherwise, it will be set to this value.
      /// For instance, if this document is a PDF, then by default Content-Disposition will be set to inline since the mime type is viewable in the browser. This allows the user to open the
      /// document directly in the browser.
      /// To force downloading, set the value of Content-Disposition to "attachment".
      /// </summary>
      [DataMember(Name = "contentDisposition")]
      public string ContentDisposition;
   }
}
