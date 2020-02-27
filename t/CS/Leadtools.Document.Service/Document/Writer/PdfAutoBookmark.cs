// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class PdfAutoBookmark
   {
      [DataMember(Name = "useStyles")]
      public bool UseStyles;
      [DataMember(Name = "boldStyle")]
      public bool BoldStyle;
      [DataMember(Name = "italicStyle")]
      public bool ItalicStyle;
      [DataMember(Name = "fontFaceName")]
      public string FontFaceName;
      [DataMember(Name = "fontHeight")]
      public double FontHeight;
   }
}
