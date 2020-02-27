// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public enum DocumentPageFitType
   {
      None = 0,
      Fit = 1,
      FitAlways = 2,
      FitWidth = 3,
      FitHeight = 4,
   }
}
