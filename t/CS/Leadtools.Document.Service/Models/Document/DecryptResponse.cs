// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Document
{
   [DataContract]
   public class DecryptResponse : Response
   {
      /// <summary>
      /// The decrypted document's information.
      /// </summary>
      [DataMember(Name = "document")]
      public object Document;
   }
}
