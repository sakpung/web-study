// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.PreCache
{
   [DataContract]
   public class PreCacheResponseItem
   {
      /// <summary>
      /// The value of the URI for the pre-cache document, as a string.
      /// </summary>
      [DataMember(Name = "uri")]
      public string Uri;

      /// <summary>
      /// The pre-cached items.
      /// </summary>
      [DataMember(Name = "items")]
      public PreCacheResponseSizeItem[] Items;

      /// <summary>
      /// The mapped hashkey of the pre-cache entry from the request URI.
      /// </summary>
      [DataMember(Name = "hashKey")]
      public string RegionHash;
   }
}
