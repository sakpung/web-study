// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class CheckCacheInfoRequest : Request
   {
      /// <summary>
      /// The URI to the document to verify the mimetype for. This may be a cache URI.
      /// </summary>
      [DataMember(Name = "uri")]
      public string Uri;
   }
}
