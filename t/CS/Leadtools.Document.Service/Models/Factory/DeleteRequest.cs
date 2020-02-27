// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class DeleteRequest : Request
   {
      /// <summary>
      /// The document to delete.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// Do not throw an exception if the document does not exist in the cache
      /// </summary>
      [DataMember(Name = "allowNonExisting")]
      public bool AllowNonExisting;

      /// <summary>
      /// Delete this document even if it was pre-cached
      /// </summary>
      [DataMember(Name = "deletePreCached")]
      public bool DeletePreCached { get; set; }
   }
}
