// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Document
{
   [DataContract]
   public class DecryptRequest : Request
   {
      /// <summary>
      /// The document's identification number.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The attempted password for the document.
      /// </summary>
      [DataMember(Name = "password")]
      public string Password;
   }
}
