// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.PreCache
{
   [DataContract]
   public class ReportPreCacheResponse : Response
   {
      /// <summary>
      /// An array of the pre-cache entries stored in the pre-cache.
      /// </summary>
      [DataMember(Name = "entries")]
      public PreCacheResponseItem[] Entries;

      /// <summary>
      /// An array of the pre-cache document items that were removed.
      /// </summary>
      [DataMember(Name = "removed")]
      public PreCacheResponseItem[] Removed;
   }
}
