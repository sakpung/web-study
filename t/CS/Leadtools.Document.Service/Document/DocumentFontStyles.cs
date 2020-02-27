// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [Flags]
   [DataContract]
   public enum DocumentFontStyles
   {
      Normal = 0,
      Bold = 1 << 0,
      Italic = 1 << 1,
      Underline = 1 << 2
   }
}
