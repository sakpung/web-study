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
   public enum DocumentDropObjects
   {
      None = 0,
      DropText = 64,
      DropImages = 128,
      DropShapes = 256
   }
}
