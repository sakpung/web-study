// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum OneBitImageCompressionType
   {
      Flate = 0,
      FaxG31D = 1,
      FaxG32D = 2,
      FaxG4 = 3,
      Lzw = 4,
      Jbig2 = 5
   }
}
