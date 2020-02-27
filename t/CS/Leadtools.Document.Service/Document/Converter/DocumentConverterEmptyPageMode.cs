// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Converter
{
   [DataContract]
   public enum DocumentConverterEmptyPageMode
   {
      None = 0,
      Skip = 1,
      SkipIgnoreAnnotations = 2
   }
}
