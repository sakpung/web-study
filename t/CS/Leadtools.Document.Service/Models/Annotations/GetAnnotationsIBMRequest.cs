// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Annotations
{
   [DataContract]
   public class GetAnnotationsIBMRequest : Request
   {
      /// <summary>
      /// The ID of the document to get annotations history from.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;
   }
}
