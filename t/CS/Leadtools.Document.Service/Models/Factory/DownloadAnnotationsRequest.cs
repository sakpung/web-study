// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class DownloadAnnotationsRequest : Request
   {
      /// <summary>
      /// The ID of the annotations in the cache to download. Cannot be used if URI is used.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The URI to the annotations to download. Cannot be used if ID is used.
      /// This may be a cache URI.
      /// </summary>
      [DataMember(Name = "uri")]
      public Uri Uri;

      /// <summary>
      /// Content disposition
      /// This is optional, if the value is null or empty, then the response Content-Disposition header will be set to either attachment or inline depending on the mime file type.
      /// Otherwise, it will be set to this value.
      /// </summary>
      [DataMember(Name = "contentDisposition")]
      public string ContentDisposition;
   }
}
