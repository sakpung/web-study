// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   [Flags]
   public enum DocumentCacheOptions
   {
      None = 0,
      PageImage = 1,
      PageSvg = 2,
      PageSvgBackImage = 4,
      PageThumbnailImage = 8,
      PageText = 16,
      PageAnnotations = 32,
      All = 63
   }
}
