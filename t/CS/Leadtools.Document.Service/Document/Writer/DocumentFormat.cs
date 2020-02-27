// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public enum DocumentFormat
   {
      User = -1,
      Ltd = 0,
      Pdf = 1,
      Doc = 2,
      Rtf = 3,
      Html = 4,
      Text = 5,
      Emf = 6,
      Xps = 7,
      Docx = 8,
      Xls = 9,
      Pub = 10,
      Mob = 11,
      Svg = 12,
      AltoXml = 13
   }
}
