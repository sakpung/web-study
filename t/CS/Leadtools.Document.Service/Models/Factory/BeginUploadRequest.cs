// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class BeginUploadRequest : Request
   {
      /// <summary>
      /// The ID to use for the new document, or null to create a new random DocumentId.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The options to use for uploading the document.
      /// </summary>
      [DataMember(Name = "options")]
      public UploadDocumentOptions Options;
   }
}
