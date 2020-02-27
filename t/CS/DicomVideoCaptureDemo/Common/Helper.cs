// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;

namespace DicomVideoCaptureDemo.Common
{
   public enum DICOMVID_IMAGE_COMPRESSION
   {
      DICOMVID_IMAGE_COMPRESSION_NONE = 0,
      DICOMVID_IMAGE_COMPRESSION_JPEGLOSSLESS,
      DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY,
      DICOMVID_IMAGE_COMPRESSION_J2KLOSSLESS,
      DICOMVID_IMAGE_COMPRESSION_J2KLOSSY,
      DICOMVID_IMAGE_COMPRESSION_MPEG2,
   };

   public enum DICOM_WRITER_FILTER_TARGET_FORMAT
   {
      DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM,//Uncompressed DICOM, JPEG and J2K lossy and lossless
      DICOM_WRITER_FILTER_TARGET_FORMAT_MPEG2//MPEG-2 compressed DICOM
   };

   public struct DICOMSCCLASS
   {
      public long nTag;
      public string pszValue;
      public DICOMSCCLASS(long tag, string zValue)
      {
         nTag = tag;
         pszValue = zValue;
      }
   };

   public struct COMPRESSIONSTRINGPAIR
   {
      public DICOMVID_IMAGE_COMPRESSION ImageCompression;
      public string pszName;

      public COMPRESSIONSTRINGPAIR(DICOMVID_IMAGE_COMPRESSION compression, string name)
      {
         ImageCompression = compression;
         pszName = name;
      }
   };

   public struct MYDICOMUIDIOD
   {
      public DicomClassType nClass;
      public string pszUID;

      public MYDICOMUIDIOD(DicomClassType type, string zUID)
      {
         nClass = type;
         pszUID = zUID;
      }
   };


   public class Helper
   {
      public static string LEAD_IMPLEMENTATION_CLASS_UID = "1.2.840.114257.0.1";
      public static string LEAD_IMPLEMENTATION_VERSION_NAME = "LEADTOOLS Demo";

      public static string CANT_FIND_LEAD_DICOM_FILE_WRITER_ERROR = "Could not instantiate the \"LEAD DICOM File Writer\" direct show filter.\nPlease make sure that the  \"LEADTOOLS Multimedia Toolkit\" is properly installed on this machine.";
      public static string CANT_INSTANTIATE_CAPTURE_LIBRARY_ERROR = "Could not instantiate the capture library.\nPlease make sure that the \"LEADTOOLS Multimedia Toolkit\" is properly installed on this machine.";

      /* The names of the LEAD MPEG-2 Encoders.
         You obtain these with the DirectShow Filter List utility installed with the Multimedia toolkit.
      */
      public static string LEAD_MPEG2_VIDEO_ENCODER = "@device:sw:{33D9A760-90C8-11D0-BD43-00A0C911CE86}\\LEAD MPEG2 Encoder (3.0)";
      public static string LEAD_MPEG_AUDIO_ENCODER = "@device:sw:{33D9A761-90C8-11D0-BD43-00A0C911CE86}\\LEAD MPEG Audio Encoder (2.0)";

      public static int Q_FACTOR_MIN = 2;
      public static int Q_FACTOR_MAX = 255;


      public static DICOMSCCLASS[] DefaultElementValues =
      {
            new DICOMSCCLASS( DicomTag.FileMetaInformationVersion,                     "01\\00"),
            new DICOMSCCLASS( DicomTag.MediaStorageSOPClassUID,                        DicomUidType.SCImageStorage ),   
            new DICOMSCCLASS( DicomTag.ImplementationClassUID,                         "1.2.840.114257.0.1"),
            new DICOMSCCLASS( DicomTag.ImplementationVersionName,                      "LEAD DICOM Writer Filter Version 1.0"),
            new DICOMSCCLASS( DicomTag.SourceApplicationEntityTitle,                   "LEAD Technologies, Inc."),
            
            // Patient
            new DICOMSCCLASS( DicomTag.PatientName,                                      "Anonymous"),
            new DICOMSCCLASS( DicomTag.PatientID,                                        "123-45-6789"),
            new DICOMSCCLASS( DicomTag.PatientBirthDate,                                "11/10/1965"),
            new DICOMSCCLASS( DicomTag.PatientSex,                                       "M"),
            
            // General Study   
            new DICOMSCCLASS( DicomTag.StudyDate,                                        "09/08/2000"),
            new DICOMSCCLASS( DicomTag.StudyTime,                                        "12:00:01.0"),
            new DICOMSCCLASS( DicomTag.ReferringPhysicianName,                          "Physician"),
            new DICOMSCCLASS( DicomTag.StudyID,                                          "1216"),
            new DICOMSCCLASS( DicomTag.AccessionNumber,                                  "1"),
            
            // General Series
            new DICOMSCCLASS( DicomTag.Modality,                                          "OT"),
            new DICOMSCCLASS( DicomTag.SeriesNumber,                                     "1" ),
            
            // General Image
            new DICOMSCCLASS( DicomTag.InstanceNumber,                                   "1"),
            //   { DicomTag.IMAGESINACQUISITION,                             "30"},
            
            // SC Equipment
            new DICOMSCCLASS( DicomTag.ConversionType,                                   "DV"),
            new DICOMSCCLASS( DicomTag.SecondaryCaptureDeviceManufacturer,             "LEAD Technologies, Inc."),
            new DICOMSCCLASS( DicomTag.SecondaryCaptureDeviceManufacturerModelName,  "" ),
            new DICOMSCCLASS( DicomTag.SecondaryCaptureDeviceSoftwareVersions,         "" ),
            new DICOMSCCLASS( DicomTag.VideoImageFormatAcquired,                       "NTSC"),
            
            // SC Image
            new DICOMSCCLASS( DicomTag.DateOfSecondaryCapture,                         "09/08/2000" ),
            new DICOMSCCLASS( DicomTag.TimeOfSecondaryCapture,                         "12:00:01.0" ),
            
            // SOP Common
            new DICOMSCCLASS( DicomTag.SOPClassUID,                                     DicomUidType.SCImageStorage),
            new DICOMSCCLASS( DicomTag.SpecificCharacterSet,                            "ISO_IR 100")   
         };

      public static COMPRESSIONSTRINGPAIR[] CompressionStringPair =
      {
         new COMPRESSIONSTRINGPAIR(  DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE,            "Uncompressed"),
         new COMPRESSIONSTRINGPAIR(  DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSLESS,    "Lossless JPEG"),
         new COMPRESSIONSTRINGPAIR(  DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY,       "Lossy JPEG"),
         new COMPRESSIONSTRINGPAIR(  DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSLESS,     "Lossless JPEG 2000"),
         new COMPRESSIONSTRINGPAIR(  DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSY,        "JPEG 2000"),
         new COMPRESSIONSTRINGPAIR(  DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2,           "MPEG2")
      };
   }
}
