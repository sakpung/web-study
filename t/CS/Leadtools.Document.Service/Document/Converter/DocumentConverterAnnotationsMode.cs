// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Converter
{
   [DataContract]
   public enum DocumentConverterAnnotationsMode
   {
      None = 0,
      External = 1,
      Overlay = 2,
      Embed = 3
   }
}
