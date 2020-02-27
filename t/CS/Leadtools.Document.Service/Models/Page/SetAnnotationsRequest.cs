// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Page
{
   [DataContract]
   public class SetAnnotationsRequest : Request
   {
      /// <summary>
      /// The ID of the document to set annotations for.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The page number.
      /// </summary>
      [DataMember(Name = "pageNumber")]
      public int PageNumber;

      /// <summary>
      /// The annotations, as a string.
      /// </summary>
      [DataMember(Name = "annotations")]
      public string Annotations;
   }
}
