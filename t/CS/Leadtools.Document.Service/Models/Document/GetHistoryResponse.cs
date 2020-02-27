// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Document
{
   [DataContract]
   public class GetHistoryResponse : Response
   {
      /// <summary>
      /// The document history items.
      /// </summary>
      [DataMember(Name = "items")]
      public DocumentHistoryItem[] Items;
   }
}
