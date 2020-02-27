// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class CheckCacheInfoResponse : Response
   {
      /// <summary>
      /// The cache info for the document. If null, the document does not exist.
      /// </summary>
      [DataMember(Name = "cacheInfo")]
      public CacheInfo CacheInfo;
   }
}
