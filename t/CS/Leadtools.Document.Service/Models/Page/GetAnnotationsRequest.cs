// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Page
{
   [DataContract]
   public class GetAnnotationsRequest : Request
   {
      /// <summary>
      /// The ID of the document to get annotations from.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The page number of the document.
      /// </summary>
      [DataMember(Name = "pageNumber")]
      public int PageNumber;

      /// <summary>
      /// If true, empty annotations will be created if none existed for the page.
      /// </summary>
      [DataMember(Name = "createEmpty")]
      public bool CreateEmpty;
   }
}
