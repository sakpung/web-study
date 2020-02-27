// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public enum DocumentHistoryModifyType
   {
      Created = 0,
      Decrypted = 1,
      Pages = 2,
      PageViewPerspective = 3,
      PageAnnotations = 4,
      PageMarkDeleted = 5,
      PageImage = 6,
      PageSvgBackImage = 7,
      PageSvg = 8,
      PageText = 9,
      PageLinks = 10
   }
}
