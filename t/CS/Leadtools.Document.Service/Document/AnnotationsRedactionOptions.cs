// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class AnnotationsRedactionOptions
   {
      [DataMember(Name = "mode")]
      public DocumentRedactionMode Mode;

      [DataMember(Name = "replaceCharacter")]
      public char ReplaceCharacter = '*';

      [DataMember(Name = "intersectionPercentage")]
      public int IntersectionPercentage;
   }
}
