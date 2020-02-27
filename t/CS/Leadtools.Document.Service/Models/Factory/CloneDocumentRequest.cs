// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class CloneDocumentRequest : Request
   {
      /// <summary>
      /// The ID of the source document to clone
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The ID of the target cloned document (optional)
      /// </summary>
      [DataMember(Name = "cloneDocumentId")]
      public string CloneDocumentId;
   }
}
