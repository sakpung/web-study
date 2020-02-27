// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Factory
{
   [DataContract]
   public class SaveToCacheResponse : Response
   {
      /// <summary>
      /// The serialized LEADDocument instance.
      /// </summary>
      [DataMember(Name = "document")]
      public object Document;
   }
}
