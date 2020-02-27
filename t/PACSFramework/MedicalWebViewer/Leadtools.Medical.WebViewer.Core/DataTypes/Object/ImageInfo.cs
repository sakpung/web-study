// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   [DataContract]
   public enum ImageCompression
   {
      [DataMember]
      None,
      [DataMember]
      RLE,
      [DataMember]
      JPEGLossless,
      [DataMember]
      JPEGLossy,
      [DataMember]
      JPEGLSLossless,
      [DataMember]
      JPEGLSLossy,
      [DataMember]
      J2KLossless,
      [DataMember]
      J2KLossy,
      [DataMember]
      MPEG2,
   }

   [DataContract]
   public enum ImagePhotometricInterpretationType
   {
      [DataMember]
      Monochrome1,
      [DataMember]
      Monochrome2,
      [DataMember]
      PaletteColor,
      [DataMember]
      RGB,
      [DataMember]
      ARGB,
      [DataMember]
      CMYK,
      [DataMember]
      YBRFull422,
      [DataMember]
      YBRFull,
      [DataMember]
      YBRRCT,
      [DataMember]
      YBRICT,
   }

   [DataContract]
   public class ImageInfo
   {
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "UIDs")]
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIDs")]
      [DataMember]
      public ObjectUID UIDs { get; set; }

      [DataMember]
      public long DicomFileSize { get; set; }

      [DataMember]
      public int Width { get; set; }

      [DataMember]
      public int Height { get; set; }

      [DataMember]
      public int XResolution { get; set; }
      
      [DataMember]
      public int YResolution { get; set; }
      
      [DataMember]
      public int BitAllocated { get; set; }

      [DataMember]
      public ImageCompression Compression { get; set; }

      [DataMember]
      public int NumberOfFrames { get; set; }

      [DataMember]
      public string TransferSyntax { get; set; }

      [DataMember]
      public int BitsStored { get; set; }

      [DataMember]
      public int HighBit { get; set; }

      [DataMember]
      public ImagePhotometricInterpretationType PhotometricInterpretation { get; set; }

      [DataMember]
      public int PixelRepresentation { get; set; }

      [DataMember]
      public int PlanarConfiguration { get; set; }

      /// <summary>
      /// Annotations type
      /// </summary>
      [DataMember]
      public ImageAnnotationsType AnnotationsType { get; set; }
   }
}
