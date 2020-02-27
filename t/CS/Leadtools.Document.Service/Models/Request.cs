// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models
{
   /// <summary>
   /// A base request type that all other requests derive from.
   /// </summary>
   [DataContract]
   public class Request
   {
      /// <summary>
      /// Any arbitrary data the user may wish to pass along through the LEADTOOLS Document library to the service.
      /// </summary>
      [DataMember(Name = "userData")]
      public string UserData;
   }
}
