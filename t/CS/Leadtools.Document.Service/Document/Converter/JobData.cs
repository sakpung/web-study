// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Document.Writer;
using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Converter
{
   [DataContract]
   public class JobData
   {
      [DataMember(Name = "jobErrorMode")]
      public DocumentConverterJobErrorMode JobErrorMode = DocumentConverterJobErrorMode.Continue;

      [DataMember(Name = "pageNumberingTemplate")]
      public string PageNumberingTemplate = "##name##_Page(##page##).##extension##";

      [DataMember(Name = "enableSvgConversion")]
      public bool EnableSvgConversion = true;

      [DataMember(Name = "svgImagesRecognitionMode")]
      public DocumentConverterSvgImagesRecognitionMode SvgImagesRecognitionMode = DocumentConverterSvgImagesRecognitionMode.Auto;

      [DataMember(Name = "emptyPageMode")]
      public DocumentConverterEmptyPageMode EmptyPageMode;

      [DataMember(Name = "preprocessorDeskew")]
      public bool PreprocessorDeskew;

      [DataMember(Name = "preprocessorOrient")]
      public bool PreprocessorOrient;

      [DataMember(Name = "preprocessorInvert")]
      public bool PreprocessorInvert;

      [DataMember(Name = "inputDocumentFirstPageNumber")]
      public int InputDocumentFirstPageNumber;

      [DataMember(Name = "inputDocumentLastPageNumber")]
      public int InputDocumentLastPageNumber;

      [DataMember(Name = "documentFormat")]
      public DocumentFormat DocumentFormat;

      [DataMember(Name = "rasterImageFormat")]
      public RasterImageFormat RasterImageFormat;

      [DataMember(Name = "rasterImageBitsPerPixel")]
      public int RasterImageBitsPerPixel;

      [DataMember(Name = "documentOptions")]
      public DocumentOptions DocumentOptions;

      [DataMember(Name = "jobName")]
      public string JobName;

      [DataMember(Name = "annotationsMode")]
      public DocumentConverterAnnotationsMode AnnotationsMode;

      [DataMember(Name = "documentName")]
      public string DocumentName;

      [DataMember(Name = "outputDocumentId")]
      public string OutputDocumentId;

      [DataMember(Name = "annotations")]
      public string Annotations;
   }
}
