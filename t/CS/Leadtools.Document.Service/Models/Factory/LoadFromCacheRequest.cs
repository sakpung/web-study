// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class LoadFromCacheRequest : Request
   {
      /// <summary>
      /// The ID to load from the cache (which must be retrieved from an item after LoadFromUri was called, and saved).
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;
   }
}
