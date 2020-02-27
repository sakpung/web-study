// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public enum DocumentRedactionMode
   {
      None = 0,
      Apply = 1,
      ApplyThenRasterize = 2
   }
}
