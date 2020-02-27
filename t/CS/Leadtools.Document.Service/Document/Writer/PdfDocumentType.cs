// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum PdfDocumentType
   {
      Pdf = 0,
      PdfA = 1,
      Pdf12 = 2,
      Pdf13 = 3,
      Pdf15 = 4,
      Pdf16 = 5
   }
}
