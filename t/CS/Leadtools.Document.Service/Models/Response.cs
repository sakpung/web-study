// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models
{
   /// <summary>
   /// A base response type that all other responses derive from.
   /// </summary>
   [DataContract]
   public class Response
   {
      /// <summary>
      /// Any arbitrary data the user may wish to pass along from the service through the LEADTOOLS Document library.
      /// </summary>
      [DataMember(Name = "userData")]
      public string UserData;
   }
}
