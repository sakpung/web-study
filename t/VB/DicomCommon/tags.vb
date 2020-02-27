' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Threading
Imports System.Collections
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Collections.Specialized
Imports System.Runtime.InteropServices

Imports Leadtools
Imports Leadtools.Dicom

namespace Leadtools.DicomDemos
      <StructLayout(LayoutKind.Sequential)> _
   public class DemoDicomTags
#if (LTV15_CONFIG)
      public const  MediaStorageSOPClassUID as DicomTagType = DicomTagType.MediaStorageSOPClassUID
      public const PixelData as DicomTagType =DicomTagType.PixelData
      public const SOPClassUID as DicomTagType =DicomTagType.SOPClassUID
      public const Undefined as DicomTagType =DicomTagType.Undefined
      public const DataSetTrailingPadding as DicomTagType =DicomTagType.DataSetTrailingPadding
      public const ItemDelimitationItem as DicomTagType =DicomTagType.ItemDelimitationItem
      public const SequenceDelimitationItem as DicomTagType =DicomTagType.SequenceDelimitationItem
      public const TransferSyntaxUID as DicomTagType =DicomTagType.TransferSyntaxUID
      public const QueryRetrieveLevel as DicomTagType = DicomTagType.QueryRetrieveLevel
      public const StudyInstanceUID as DicomTagType = DicomTagType.StudyInstanceUID
      public const SeriesInstanceUID as DicomTagType = DicomTagType.SeriesInstanceUID
      public const PatientID as DicomTagType = DicomTagType.PatientID
      public const PatientName as DicomTagType = DicomTagType.PatientName
      public const StudyID as DicomTagType = DicomTagType.StudyID
      public const AccessionNumber as DicomTagType = DicomTagType.AccessionNumber
      public const StudyDate as DicomTagType = DicomTagType.StudyDate
      public const Modality as DicomTagType = DicomTagType.Modality
      public const ScheduledProcedureStepStartDate as DicomTagType = DicomTagType.ScheduledProcedureStepStartDate
      public const RequestedProcedureID as DicomTagType = DicomTagType.RequestedProcedureID
      public const SOPInstanceUID as DicomTagType = DicomTagType.SOPInstanceUID
      public const ReferringPhysicianName as DicomTagType = DicomTagType.ReferringPhysicianName
      public const StudyDescription as DicomTagType = DicomTagType.StudyDescription
      public const SeriesDate as DicomTagType = DicomTagType.SeriesDate
      public const SeriesNumber as DicomTagType = DicomTagType.SeriesNumber
      public const SeriesDescription as DicomTagType = DicomTagType.SeriesDescription
      public const NumberOfSeriesRelatedInstances as DicomTagType = DicomTagType.NumberOfSeriesRelatedInstances
      public const InstitutionName as DicomTagType = DicomTagType.InstitutionName
      public const PatientBirthDate as DicomTagType = DicomTagType.PatientBirthDate
      public const PatientSex as DicomTagType = DicomTagType.PatientSex
      public const PatientWeight as DicomTagType = DicomTagType.PatientWeight
      public const RequestingPhysician as DicomTagType = DicomTagType.RequestingPhysician
      public const RequestedProcedureDescription as DicomTagType = DicomTagType.RequestedProcedureDescription
      public const AdmissionID as DicomTagType = DicomTagType.AdmissionID
      public const ScheduledStationAETitle as DicomTagType = DicomTagType.ScheduledStationAETitle
      public const ScheduledProcedureStepStartTime as DicomTagType = DicomTagType.ScheduledProcedureStepStartTime
      public const ScheduledPerformingPhysicianName as DicomTagType = DicomTagType.ScheduledPerformingPhysicianName
      public const ScheduledProcedureStepDescription as DicomTagType = DicomTagType.ScheduledProcedureStepDescription
      public const ScheduledProcedureStepID as DicomTagType = DicomTagType.ScheduledProcedureStepID
      public const ScheduledProcedureStepLocation as DicomTagType = DicomTagType.ScheduledProcedureStepLocation
      public const ReasonForTheRequestedProcedure as DicomTagType = DicomTagType.ReasonForTheRequestedProcedure
      public const RequestedProcedurePriority as DicomTagType = DicomTagType.RequestedProcedurePriority
      public const ScheduledProcedureStepSequence as DicomTagType = DicomTagType.ScheduledProcedureStepSequence
      public const Item as DicomTagType = DicomTagType.Item
      public const ScheduledProtocolCodeSequence as DicomTagType = DicomTagType.ScheduledActionItemCodeSequence
      public const RequestAttributesSequence as DicomTagType = DicomTagType.RequestAttributesSequence
      public const NamesOfIntendedRecipientsOfResults as DicomTagType = DicomTagType.NamesOfIntendedRecipientsOfResults
      public const PhysicianOfRecord as DicomTagType = DicomTagType.PhysicianOfRecord
      public const OperatorName as DicomTagType = DicomTagType.OperatorsName
      public const PerformedProcedureStepID as DicomTagType = DicomTagType.PerformedProcedureStepID
      public const SpecificCharacterSet as DicomTagType = DicomTagType.SpecificCharacterSet
      public const InstanceNumber as DicomTagType = DicomTagType.InstanceNumber
      public const FillerOrderNumberProcedure as DicomTagType = DicomTagType.FillerOrderNumberProcedureRetired
      public const MediaStorageSOPInstanceUID as DicomTagType = DicomTagType.MediaStorageSOPInstanceUID
      public const ImplementationClassUID as DicomTagType = DicomTagType.ImplementationClassUID
      public const ImplementationVersionName as DicomTagType = DicomTagType.ImplementationVersionName
      public const PatientBirthTime as DicomTagType = DicomTagType.PatientBirthTime
      public const EthnicGroup as DicomTagType = DicomTagType.EthnicGroup
      public const PatientComments as DicomTagType = DicomTagType.PatientComments
      public const NumberOfPatientRelatedStudies as DicomTagType = DicomTagType.NumberOfPatientRelatedStudies
      public const NumberOfPatientRelatedSeries as DicomTagType = DicomTagType.NumberOfPatientRelatedSeries
      public const NumberOfPatientRelatedInstances as DicomTagType = DicomTagType.NumberOfPatientRelatedInstances
      public const StudyTime as DicomTagType = DicomTagType.StudyTime
      public const NumberOfStudyRelatedSeries as DicomTagType = DicomTagType.NumberOfStudyRelatedSeries
      public const NumberOfStudyRelatedInstances as DicomTagType = DicomTagType.NumberOfStudyRelatedInstances
      public const ReferencedFileID as DicomTagType = DicomTagType.ReferencedFileID
      public const FileMetaInformationVersion as DicomTagType = DicomTagType.FileMetaInformationVersion
      public const ContentDate as DicomTagType = DicomTagType.ContentDate
      public const ContentTime as DicomTagType = DicomTagType.ContentTime
      public const AcquisitionDateTime as DicomTagType = DicomTagType.AcquisitionDatetime
#else
      public const MediaStorageSOPClassUID as long = DicomTag.MediaStorageSOPClassUID
      public const PixelData as long = DicomTag.PixelData
      public const SOPClassUID as long = DicomTag.SOPClassUID
      public const Undefined as long = DicomTag.Undefined
      public const DataSetTrailingPadding as long = DicomTag.DataSetTrailingPadding
      public const ItemDelimitationItem as long = DicomTag.ItemDelimitationItem
      public const SequenceDelimitationItem as long = DicomTag.SequenceDelimitationItem
      public const TransferSyntaxUID as long = DicomTag.TransferSyntaxUID
      public const QueryRetrieveLevel as long = DicomTag.QueryRetrieveLevel
      public const StudyInstanceUID as long = DicomTag.StudyInstanceUID
      public const SeriesInstanceUID as long = DicomTag.SeriesInstanceUID
      public const PatientID as long = DicomTag.PatientID
      public const PatientName as long = DicomTag.PatientName
      public const StudyID as long = DicomTag.StudyID
      public const AccessionNumber as long = DicomTag.AccessionNumber
      public const StudyDate as long = DicomTag.StudyDate
      public const Modality as long = DicomTag.Modality
      public const ScheduledProcedureStepStartDate as long = DicomTag.ScheduledProcedureStepStartDate
      public const RequestedProcedureID as long = DicomTag.RequestedProcedureID
      public const SOPInstanceUID as long = DicomTag.SOPInstanceUID
      public const ReferringPhysicianName as long = DicomTag.ReferringPhysicianName
      public const StudyDescription as long = DicomTag.StudyDescription
      public const SeriesDate as long = DicomTag.SeriesDate
      public const SeriesNumber as long = DicomTag.SeriesNumber
      public const SeriesDescription as long = DicomTag.SeriesDescription
      public const NumberOfSeriesRelatedInstances as long = DicomTag.NumberOfSeriesRelatedInstances
      public const InstitutionName as long = DicomTag.InstitutionName
      public const PatientBirthDate as long = DicomTag.PatientBirthDate
      public const PatientSex as long = DicomTag.PatientSex
      public const PatientWeight as long = DicomTag.PatientWeight
      public const RequestingPhysician as long = DicomTag.RequestingPhysician
      public const RequestedProcedureDescription as long = DicomTag.RequestedProcedureDescription
      public const AdmissionID as long = DicomTag.AdmissionID
      public const ScheduledStationAETitle as long = DicomTag.ScheduledStationAETitle
      public const ScheduledProcedureStepStartTime as long = DicomTag.ScheduledProcedureStepStartTime
      public const ScheduledPerformingPhysicianName as long = DicomTag.ScheduledPerformingPhysicianName
      public const ScheduledProcedureStepDescription as long = DicomTag.ScheduledProcedureStepDescription
      public const ScheduledProcedureStepID as long = DicomTag.ScheduledProcedureStepID
      public const ScheduledProcedureStepLocation as long = DicomTag.ScheduledProcedureStepLocation
      public const ReasonForTheRequestedProcedure as long = DicomTag.ReasonForTheRequestedProcedure
      public const RequestedProcedurePriority as long = DicomTag.RequestedProcedurePriority
      public const ScheduledProcedureStepSequence as long = DicomTag.ScheduledProcedureStepSequence
      public const Item as long = DicomTag.Item
      public const ScheduledProtocolCodeSequence as long = DicomTag.ScheduledProtocolCodeSequence
      public const RequestAttributesSequence as long = DicomTag.RequestAttributesSequence
      public const NamesOfIntendedRecipientsOfResults as long = DicomTag.NamesOfIntendedRecipientsOfResults
      public const PhysicianOfRecord as long = DicomTag.PhysicianOfRecord
      public const OperatorName as long = DicomTag.OperatorName
      public const PerformedProcedureStepID as long = DicomTag.PerformedProcedureStepID
      public const SpecificCharacterSet as long = DicomTag.SpecificCharacterSet
      public const InstanceNumber as long = DicomTag.InstanceNumber
      public const FillerOrderNumberProcedure as long = DicomTag.FillerOrderNumberProcedure
      public const MediaStorageSOPInstanceUID as long = DicomTag.MediaStorageSOPInstanceUID
      public const ImplementationClassUID as long = DicomTag.ImplementationClassUID
      public const ImplementationVersionName as long = DicomTag.ImplementationVersionName
      public const PatientBirthTime as long = DicomTag.PatientBirthTime
      public const EthnicGroup as long = DicomTag.EthnicGroup
      public const PatientComments as long = DicomTag.PatientComments
      public const NumberOfPatientRelatedStudies as long = DicomTag.NumberOfPatientRelatedStudies
      public const NumberOfPatientRelatedSeries as long = DicomTag.NumberOfPatientRelatedSeries
      public const NumberOfPatientRelatedInstances as long = DicomTag.NumberOfPatientRelatedInstances
      public const StudyTime as long = DicomTag.StudyTime
      public const NumberOfStudyRelatedSeries as long = DicomTag.NumberOfStudyRelatedSeries
      public const NumberOfStudyRelatedInstances as long = DicomTag.NumberOfStudyRelatedInstances
      public const ReferencedFileID as long = DicomTag.ReferencedFileID
      public const FileMetaInformationVersion as long = DicomTag.FileMetaInformationVersion
      public const ContentDate as long = DicomTag.ContentDate
      public const ContentTime as long = DicomTag.ContentTime
      public const AcquisitionDateTime as long = DicomTag.AcquisitionDateTime
#end if
   end class
end namespace
