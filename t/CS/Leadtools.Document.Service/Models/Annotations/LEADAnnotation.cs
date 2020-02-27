// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Annotations
{
   [DataContract]
   public class LEADAnnotation
   {
      /// <summary>
      /// The LEAD Annotation as an XML string.
      /// </summary>
      [DataMember(Name = "annotation")]
      public string Annotation;

      /// <summary>
      /// The password to lock the object with. If null or empty, it will not be used.
      /// </summary>
      [DataMember(Name = "password")]
      public string Password;

      /// <summary>
      /// The user ID to associate with this LEAD Annotation.
      /// </summary>
      [DataMember(Name = "userId")]
      public string UserId;
   }
}
