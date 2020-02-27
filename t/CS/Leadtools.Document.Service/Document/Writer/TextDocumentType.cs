// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum TextDocumentType
   {
      Ansi = 0,
      Unicode = 1,
      UnicodeBigEndian = 2,
      UTF8 = 3
   }
}
