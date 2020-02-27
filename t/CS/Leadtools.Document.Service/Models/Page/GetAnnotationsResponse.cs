// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Page
{
   [DataContract]
   public class GetAnnotationsResponse : Response
   {
      /// <summary>
      /// The annotations, as a string.
      /// </summary>
      [DataMember(Name = "annotations")]
      public string Annotations;
   }
}
