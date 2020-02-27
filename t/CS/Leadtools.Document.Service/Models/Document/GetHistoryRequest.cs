// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Document
{
   [DataContract]
   public class GetHistoryRequest : Request
   {
      /// <summary>
      /// The ID of the document to get the history of.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// Whether or not to clear the history after retrieving it.
      /// </summary>
      [DataMember(Name = "clearHistory")]
      public bool ClearHistory;
   }
}
