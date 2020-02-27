// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentAnnotations
   {
      [DataMember(Name = "redactionOptions")]
      public DocumentRedactionOptions RedactionOptions;
   }
}
