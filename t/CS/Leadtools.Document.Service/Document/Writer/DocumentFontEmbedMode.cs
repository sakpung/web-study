// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum DocumentFontEmbedMode
   {
      None = 0,
      Auto = 1,
      Force = 2,
      All = 3
   }
}
