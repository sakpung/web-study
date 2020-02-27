// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class PdfDocumentOptions : DocumentOptions
   {
      [DataMember(Name = "documentType")]
      public PdfDocumentType DocumentType = PdfDocumentType.Pdf;
      [DataMember(Name = "fontEmbedMode")]
      public DocumentFontEmbedMode FontEmbedMode = DocumentFontEmbedMode.Auto;
      [DataMember(Name = "imageOverText")]
      public bool ImageOverText = false;
      [DataMember(Name = "linearized")]
      public bool Linearized = false;
      [DataMember(Name = "title")]
      public string Title;
      [DataMember(Name = "subject")]
      public string Subject = null;
      [DataMember(Name = "keywords")]
      public string Keywords = null;
      [DataMember(Name = "author")]
      public string Author = null;
      [DataMember(Name = "isProtected")]
      public bool Protected = false;
      [DataMember(Name = "userPassword")]
      public string UserPassword = null;
      [DataMember(Name = "ownerPassword")]
      public string OwnerPassword = null;
      [DataMember(Name = "encryptionMode")]
      public PdfDocumentEncryptionMode EncryptionMode = PdfDocumentEncryptionMode.RC128Bit;
      [DataMember(Name = "printEnabled")]
      public bool PrintEnabled = true;
      [DataMember(Name = "highQualityPrintEnabled")]
      public bool HighQualityPrintEnabled = true;
      [DataMember(Name = "copyEnabled")]
      public bool CopyEnabled = true;
      [DataMember(Name = "editEnabled")]
      public bool EditEnabled = true;
      [DataMember(Name = "annotationsEnabled")]
      public bool AnnotationsEnabled = true;
      [DataMember(Name = "assemblyEnabled")]
      public bool AssemblyEnabled = false;
      [DataMember(Name = "oneBitImageCompression")]
      public OneBitImageCompressionType OneBitImageCompression = OneBitImageCompressionType.Jbig2;
      [DataMember(Name = "coloredImageCompression")]
      public ColoredImageCompressionType ColoredImageCompression = ColoredImageCompressionType.FlateJpeg;
      [DataMember(Name = "qualityFactor")]
      public int QualityFactor = 80;
      [DataMember(Name = "autoBookmarksEnabled")]
      public bool AutoBookmarksEnabled = false;
      [DataMember(Name = "totalBookmarkLevels")]
      public int TotalBookmarkLevels = -1;
      [DataMember(Name = "autoBookmarks")]
      public List<PdfAutoBookmark> AutoBookmarks = new List<PdfAutoBookmark>();
      [DataMember(Name = "customBookmarks")]
      public List<PdfCustomBookmark> CustomBookmarks = new List<PdfCustomBookmark>();
      [DataMember(Name = "imageOverTextSize")]
      public DocumentImageOverTextSize ImageOverTextSize = DocumentImageOverTextSize.Original;
      [DataMember(Name = "imageOverTextMode")]
      public DocumentImageOverTextMode ImageOverTextMode = DocumentImageOverTextMode.Strict;
      [DataMember(Name = "creator")]
      public string Creator = null;
      [DataMember(Name = "producer")]
      public string Producer = null;
      [DataMember(Name = "pageModeType")]
      public PdfDocumentPageModeType PageModeType = PdfDocumentPageModeType.PageOnly;
      [DataMember(Name = "pageLayoutType")]
      public PdfDocumentPageLayoutType PageLayoutType = PdfDocumentPageLayoutType.SinglePageDisplay;
      [DataMember(Name = "pageFitType")]
      public PdfDocumentPageFitType PageFitType = PdfDocumentPageFitType.Default;
      [DataMember(Name = "initialPageNumber")]
      public int InitialPageNumber = 1;
      [DataMember(Name = "xCoordinate")]
      public double XCoordinate = 0;
      [DataMember(Name = "yCoordinate")]
      public double YCoordinate = 0;
      [DataMember(Name = "zoomPercent")]
      public double ZoomPercent = 0;
      [DataMember(Name = "hideToolbar")]
      public bool HideToolbar = false;
      [DataMember(Name = "hideMenubar")]
      public bool HideMenubar = false;
      [DataMember(Name = "hideWindowUI")]
      public bool HideWindowUI = false;
      [DataMember(Name = "fitWindow")]
      public bool FitWindow = false;
      [DataMember(Name = "centerWindow")]
      public bool CenterWindow = false;
      [DataMember(Name = "displayDocTitle")]
      public bool DisplayDocTitle = false;
      [DataMember(Name = "dropObjects")]
      public DocumentDropObjects DropObjects = DocumentDropObjects.None;

      public override DocumentFormat Format { get { return DocumentFormat.Pdf; } }
   }
}
