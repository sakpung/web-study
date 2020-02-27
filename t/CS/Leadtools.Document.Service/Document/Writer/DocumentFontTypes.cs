// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   [Flags]
   public enum DocumentFontTypes
   {
      Default = 0,
      WOFF1 = 1,
      EOT = 2,
      TTF = 4,
      WOFF2 = 8
   }
}
