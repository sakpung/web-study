// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Models.Annotations
{
   [DataContract]
   public class SetAnnotationsLEADRequest : Request
   {
      /// <summary>
      /// The ID of the document to set annotations to.
      /// </summary>
      [DataMember(Name = "documentId")]
      public string DocumentId;

      /// <summary>
      /// The annotation objects to convert.
      /// </summary>
      [DataMember(Name = "annotations")]
      public LEADAnnotation[] Annotations;
   }
}
