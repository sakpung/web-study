// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class UploadDocumentBlobRequest : Request
   {
      /// <summary>
      /// The uri, retrieved from BeginUpload, that is used for uploading.
      /// </summary>
      [DataMember(Name = "uri")]
      public Uri Uri;
   }
}
