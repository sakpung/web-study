// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class UploadDocumentOptions
   {
      [DataMember(Name = "documentId")]
      public string DocumentId;

      [DataMember(Name = "name")]
      public string Name;

      [DataMember(Name = "mimeType")]
      public string MimeType;

      [DataMember(Name = "pageCount")]
      public int PageCount;

      [DataMember(Name = "enableStreaming")]
      public bool EnableStreaming;


      [DataMember(Name = "password")]
      public string Password;

      [DataMember(Name = "postUploadOperations")]
      public Dictionary<string, string> PostUploadOperations = new Dictionary<string, string>();
   }
}
