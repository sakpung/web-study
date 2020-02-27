// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Runtime.Serialization;

namespace Leadtools.Document.Service.Document.Writer
{
   [DataContract]
   public class AltoXmlDocumentOptions : DocumentOptions
   {
      [DataMember(Name = "measurementUnit")]
      public AltoXmlMeasurementUnit MeasurementUnit = AltoXmlMeasurementUnit.MM10;
      [DataMember(Name = "fileName")]
      public string FileName;
      [DataMember(Name = "processingDateTime")]
      public string ProcessingDateTime;
      [DataMember(Name = "processingAgency")]
      public string ProcessingAgency;
      [DataMember(Name = "processingStepDescription")]
      public string ProcessingStepDescription;
      [DataMember(Name = "processingStepSettings")]
      public string ProcessingStepSettings;
      [DataMember(Name = "softwareCreator")]
      public string SoftwareCreator;
      [DataMember(Name = "softwareName")]
      public string SoftwareName;
      [DataMember(Name = "softwareVersion")]
      public string SoftwareVersion;
      [DataMember(Name = "applicationDescription")]
      public string ApplicationDescription;
      [DataMember(Name = "firstPhysicalPageNumber")]
      public int FirstPhysicalPageNumber = 1;
      [DataMember(Name = "formatted")]
      public bool Formatted = false;
      [DataMember(Name = "indentation")]
      public string Indentation = "  ";
      [DataMember(Name = "sort")]
      public bool Sort = false;
      [DataMember(Name = "plainText")]
      public bool PlainText = false;
      [DataMember(Name = "showGlyphInfo")]
      public bool ShowGlyphInfo = false;
      [DataMember(Name = "showGlyphVariants")]
      public bool ShowGlyphVariants = false;

      public override DocumentFormat Format { get { return DocumentFormat.AltoXml; } }
   }
}
