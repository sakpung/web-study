// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class CloneDocumentResponse : Response
   {
      /// <summary>
      /// The cloned document
      /// </summary>
      [DataMember(Name = "document")]
      public object Document;
   }
}
