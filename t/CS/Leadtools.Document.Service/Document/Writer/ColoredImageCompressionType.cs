// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum ColoredImageCompressionType
   {
      FlateJpeg = 0,
      LzwJpeg = 1,
      Flate = 2,
      Lzw = 3,
      Jpeg = 4,
      FlateJpx = 5,
      LzwJpx = 6,
      Jpx = 7
   }
}
