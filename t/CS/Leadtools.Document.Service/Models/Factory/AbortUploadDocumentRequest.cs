// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class AbortUploadDocumentRequest : Request
   {
      /// <summary>
      /// The URI from BeginUpload to stop loading to.
      /// </summary>
      [DataMember(Name = "uri")]
      public Uri Uri;
   }
}
