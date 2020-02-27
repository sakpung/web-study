// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.PreCache
{
   [DataContract]
   public class PreCacheDocumentResponse : Response
   {
      /// <summary>
      /// The pre-cache response item.
      /// </summary>
      [DataMember(Name = "item")]
      public PreCacheResponseItem Item;
   }
}
