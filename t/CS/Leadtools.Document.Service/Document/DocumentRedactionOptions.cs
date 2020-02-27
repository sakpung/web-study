// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class DocumentRedactionOptions
   {
      [DataMember(Name = "viewOptions")]
      public ViewRedactionOptions ViewOptions = new ViewRedactionOptions();

      [DataMember(Name = "convertOptions")]
      public ConvertRedactionOptions ConvertOptions = new ConvertRedactionOptions();
   }
}
