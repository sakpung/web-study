// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.PreCache
{
   [DataContract]
   public class ReportPreCacheRequest : Request
   {
      /// <summary>
      /// Choose whether to delete all pre-cache entries.
      /// </summary>
      [DataMember(Name = "clear")]
      public bool Clear;

      /// <summary>
      /// Choose whether to remove pre-cache entries that don't have a matching cache entry.
      /// </summary>
      [DataMember(Name = "clean")]
      public bool Clean;

      /// <summary>
      /// A simple passcode to restrict others from receiving a pre-cache report. For production, use a more advanced authorization system.
      /// </summary>
      [DataMember(Name = "passcode")]
      public string Passcode;
   }
}
