// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum PdfDocumentPageLayoutType
   {
      SinglePageDisplay = 0,
      OneColumnDisplay = 1,
      TwoColumnLeftDisplay = 2,
      TwoColumnRightDisplay = 3,
      TwoPageLeft = 4,
      TwoPageRight = 5
   }
}
