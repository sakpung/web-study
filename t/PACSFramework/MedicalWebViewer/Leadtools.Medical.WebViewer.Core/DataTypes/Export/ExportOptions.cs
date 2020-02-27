// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    public enum CompressionType
    {
        Low,
        Medium,
        High
    }

   [DataContract]
   public class ExportOptions
   {            
      [DataMember]
      public bool BurnAnnotations { get; set; }
      [DataMember]
      public bool CreateDICOMDIR { get; set; }
      [DataMember]
      public CompressionType ImageCompression { get; set; }
      [DataMember]
      public bool IncludeOverflowImages { get; set; }
      [DataMember]
      public int LayoutImageWidth { get; set; }
      [DataMember]
      public string FileFormat { get; set; }            
      [DataMember]
      public bool ReduceGrayscaleTo8BitsSelected { get; set; }
      [DataMember]
      public bool Anonymize { get; set; }
      [DataMember]
      public string DczPassword { get; set; }
      [DataMember]
      public bool IncludeViewer { get; set; }
   }

    [DataContract]
    public class PrintOptions
    {
        [DataMember]
        public bool BurnAnnotations { get; set; }
        [DataMember]
        public bool IncludeOverflowImages { get; set; }
        [DataMember]
        public int LayoutImageWidth { get; set; }
        [DataMember]
        public bool WhiteBackground { get; set; }
        [DataMember]
        public bool PatientInfo { get; set; }
        [DataMember]
        public double PageWidth { get; set; }
        [DataMember]
        public double PageHeight { get; set; }
        [DataMember]
        public bool ReduceGrayscaleTo8BitsSelected { get; set; }
        [DataMember]
        public string AnnotationsFileName { get; set; }
        [DataMember]
        public bool LayoutPatientInfo { get; set; }
    }
}
