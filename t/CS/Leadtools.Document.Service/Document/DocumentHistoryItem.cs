// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentHistoryItem
   {
      [DataMember(Name = "userId")]
      public string UserId;
      [DataMember(Name = "timestamp")]
      public string Timestamp;
      [DataMember(Name = "comment")]
      public string Comment;
      [DataMember(Name = "modifyType")]
      public DocumentHistoryModifyType ModifyType;
      [DataMember(Name = "pageNumber")]
      public int PageNumber;
   }
}
