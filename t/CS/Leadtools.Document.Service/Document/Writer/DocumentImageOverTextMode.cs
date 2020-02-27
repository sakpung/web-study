// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum DocumentImageOverTextMode
   {
      None = 0,
      Strict = 1,
      Relaxed = 2
   }
}
