' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Dicom
Imports System

Namespace DicomVideoCaptureDemo.Common
    Public Enum DICOMVID_IMAGE_COMPRESSION
        DICOMVID_IMAGE_COMPRESSION_NONE = 0
        DICOMVID_IMAGE_COMPRESSION_JPEGLOSSLESS
        DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY
        DICOMVID_IMAGE_COMPRESSION_J2KLOSSLESS
        DICOMVID_IMAGE_COMPRESSION_J2KLOSSY
        DICOMVID_IMAGE_COMPRESSION_MPEG2
    End Enum

    Public Enum DICOM_WRITER_FILTER_TARGET_FORMAT
        DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM
        'Uncompressed DICOM, JPEG and J2K lossy and lossless
        DICOM_WRITER_FILTER_TARGET_FORMAT_MPEG2
        'MPEG-2 compressed DICOM
    End Enum

    Public Structure DICOMSCCLASS
        Public nTag As Long
        Public pszValue As String
        Public Sub New(ByVal tag As Long, ByVal zValue As String)
            nTag = tag
            pszValue = zValue
        End Sub
    End Structure

    Public Structure COMPRESSIONSTRINGPAIR
        Public ImageCompression As DICOMVID_IMAGE_COMPRESSION
        Public pszName As String

        Public Sub New(ByVal compression As DICOMVID_IMAGE_COMPRESSION, ByVal name As String)
            ImageCompression = compression
            pszName = name
        End Sub
    End Structure

    Public Structure MYDICOMUIDIOD
        Public nClass As DicomClassType
        Public pszUID As String

        Public Sub New(ByVal type As DicomClassType, ByVal zUID As String)
            nClass = type
            pszUID = zUID
        End Sub
    End Structure


    Public Class Helper
        Public Shared LEAD_IMPLEMENTATION_CLASS_UID As String = "1.2.840.114257.0.1"
        Public Shared LEAD_IMPLEMENTATION_VERSION_NAME As String = "LEADTOOLS Demo"

        Public Shared CANT_FIND_LEAD_DICOM_FILE_WRITER_ERROR As String = "Could not instantiate the ""LEAD DICOM File Writer"" direct show filter." & Environment.NewLine & "Please make sure that the  ""LEADTOOLS Multimedia Toolkit"" is properly installed on this machine."
        Public Shared CANT_INSTANTIATE_CAPTURE_LIBRARY_ERROR As String = "Could not instantiate the capture library." & Environment.NewLine & "Please make sure that the ""LEADTOOLS Multimedia Toolkit"" is properly installed on this machine."

        ' The names of the LEAD MPEG-2 Encoders.
        '         You obtain these with the DirectShow Filter List utility installed with the Multimedia toolkit.
        '      

        Public Shared LEAD_MPEG2_VIDEO_ENCODER As String = "@device:sw:{33D9A760-90C8-11D0-BD43-00A0C911CE86}\LEAD MPEG2 Encoder (3.0)"
        Public Shared LEAD_MPEG_AUDIO_ENCODER As String = "@device:sw:{33D9A761-90C8-11D0-BD43-00A0C911CE86}\LEAD MPEG Audio Encoder (2.0)"

        Public Shared Q_FACTOR_MIN As Integer = 2
        Public Shared Q_FACTOR_MAX As Integer = 255



        ' Patient

        ' General Study   

        ' General Series

        ' General Image
        '   { DicomTag.IMAGESINACQUISITION,                             "30"},

        ' SC Equipment

        ' SC Image

        ' SOP Common
      Public Shared DefaultElementValues As DICOMSCCLASS() = {New DICOMSCCLASS(DicomTag.FileMetaInformationVersion, "01\00"), New DICOMSCCLASS(DicomTag.MediaStorageSOPClassUID, DicomUidType.SCImageStorage), New DICOMSCCLASS(DicomTag.ImplementationClassUID, "1.2.840.114257.0.1"), New DICOMSCCLASS(DicomTag.ImplementationVersionName, "LEAD DICOM Writer Filter Version 1.0"), New DICOMSCCLASS(DicomTag.SourceApplicationEntityTitle, "LEAD Technologies, Inc."), New DICOMSCCLASS(DicomTag.PatientName, "Anonymous"), _
       New DICOMSCCLASS(DicomTag.PatientID, "123-45-6789"), New DICOMSCCLASS(DicomTag.PatientBirthDate, "11/10/1965"), New DICOMSCCLASS(DicomTag.PatientSex, "M"), New DICOMSCCLASS(DicomTag.StudyDate, "09/08/2000"), New DICOMSCCLASS(DicomTag.StudyTime, "12:00:01.0"), New DICOMSCCLASS(DicomTag.ReferringPhysicianName, "Physician"), _
       New DICOMSCCLASS(DicomTag.StudyID, "1216"), New DICOMSCCLASS(DicomTag.AccessionNumber, "1"), New DICOMSCCLASS(DicomTag.Modality, "OT"), New DICOMSCCLASS(DicomTag.SeriesNumber, "1"), New DICOMSCCLASS(DicomTag.InstanceNumber, "1"), New DICOMSCCLASS(DicomTag.ConversionType, "DV"), _
       New DICOMSCCLASS(DicomTag.SecondaryCaptureDeviceManufacturer, "LEAD Technologies, Inc."), New DICOMSCCLASS(DicomTag.SecondaryCaptureDeviceManufacturerModelName, ""), New DICOMSCCLASS(DicomTag.SecondaryCaptureDeviceSoftwareVersions, ""), New DICOMSCCLASS(DicomTag.VideoImageFormatAcquired, "NTSC"), New DICOMSCCLASS(DicomTag.DateOfSecondaryCapture, "09/08/2000"), New DICOMSCCLASS(DicomTag.TimeOfSecondaryCapture, "12:00:01.0"), _
       New DICOMSCCLASS(DicomTag.SOPClassUID, DicomUidType.SCImageStorage), New DICOMSCCLASS(DicomTag.SpecificCharacterSet, "ISO_IR 100")}

        Public Shared CompressionStringPair As COMPRESSIONSTRINGPAIR() = {New COMPRESSIONSTRINGPAIR(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE, "Uncompressed"), New COMPRESSIONSTRINGPAIR(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSLESS, "Lossless JPEG"), New COMPRESSIONSTRINGPAIR(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY, "Lossy JPEG"), New COMPRESSIONSTRINGPAIR(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSLESS, "Lossless JPEG 2000"), New COMPRESSIONSTRINGPAIR(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSY, "JPEG 2000"), New COMPRESSIONSTRINGPAIR(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2, "MPEG2")}
    End Class
End Namespace
