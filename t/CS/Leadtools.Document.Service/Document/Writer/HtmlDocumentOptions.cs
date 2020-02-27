// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class HtmlDocumentOptions : DocumentOptions
   {
      [DataMember(Name = "fontEmbedMode")]
      public DocumentFontEmbedMode FontEmbedMode = DocumentFontEmbedMode.None;
      [DataMember(Name = "useBackgroundColor")]
      public bool UseBackgroundColor = false;
      [DataMember(Name = "dropObjects")]
      public DocumentDropObjects DropObjects = DocumentDropObjects.None;
      [DataMember(Name = "embedImages")]
      public bool EmbedImages = false;
      [DataMember(Name = "embedFonts")]
      public bool EmbedFonts = false;
      [DataMember(Name = "embedCSS")]
      public bool EmbedCSS = true;
      [DataMember(Name = "imageType")]
      public RasterImageFormat ImageType = RasterImageFormat.Png;
      [DataMember(Name = "fontTypes")]
      public DocumentFontTypes FontTypes = DocumentFontTypes.WOFF1;
      [DataMember(Name = "backgroundColor")]
      public string BackgroundColor = "white";

      public override DocumentFormat Format { get { return DocumentFormat.Html; } }
   }
}
