// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document;
using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.PreCache
{
   [DataContract]
   public class PreCacheDocumentRequest : Request
   {
      /// <summary>
      /// The URI to the document to be pre-cached.
      /// </summary>
      [DataMember(Name = "uri")]
      public Uri Uri;

      /// <summary>
      /// The date this document will be expired. If null, then the document will never expire.
      /// </summary>
      [DataMember(Name = "expiryDate")]
      public DateTime? ExpiryDate;

      /// <summary>
      /// The parts of the document to pre-cache. If None (default value), then DocumentCacheOptions.All is used.
      /// Array of serialized Leadtools.Document.DocumentCacheOptions.
      /// </summary>
      [DataMember(Name = "cacheOptions")]
      public DocumentCacheOptions CacheOptions;

      /// <summary>
      /// The maximum pixel size values to use when pre-caching images. If null, then 4096 and 2048 are used.
      /// </summary>
      [DataMember(Name = "maximumImagePixelSizes")]
      public int[] MaximumImagePixelSizes;

      /// <summary>
      /// Page number where pre-caching starts. 0 to start at the first page
      /// </summary>
      [DataMember(Name = "firstPageNumber")]
      public int FirstPageNumber;

      /// <summary>
      /// Page number where pre-caching stops. 0 or -1 to stop at the last page
      /// </summary>
      [DataMember(Name = "lastPageNumber")]
      public int LastPageNumber;

      /// <summary>
      /// A simple passcode to restrict others from pre-caching. For production, use a more advanced authorization system.
      /// </summary>
      [DataMember(Name = "passcode")]
      public string Passcode;
   }
}
