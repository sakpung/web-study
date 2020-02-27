// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class BeginUploadResponse : Response
   {
      /// <summary>
      /// The URI to which the document should be uploaded to the cache.
      /// </summary>
      [DataMember(Name = "uploadUri")]
      public Uri UploadUri;
   }
}
