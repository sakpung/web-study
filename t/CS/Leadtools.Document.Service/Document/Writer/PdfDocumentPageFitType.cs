// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum PdfDocumentPageFitType
   {
      Default = 0,
      FitWidth = 1,
      FitHeight = 2,
      FitWidthBounds = 3,
      FitHeightBounds = 4,
      FitBounds = 5
   }
}
