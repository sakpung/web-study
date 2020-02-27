// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Leadtools.Logging;

namespace Leadtools.AddIn.Store
{
    [DicomAddInAttribute("CStore AddIn","1.0.0.0",Description="Implements C-STORE-REQ",Author="")]
    public class StoreAddin : IProcessCStore
    {            
        #region IProcessCStore Members

        [PresentationContext(DicomUidType.CTImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.StandaloneOverlayStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.StandaloneCurveStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.StandaloneModalityLutStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.CardiacElectrophysiologyWaveformStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.StandaloneVoiLutStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.StandalonePETCurveStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.StereometricRelationshipStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.BasicTextSR, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.EnhancedSR, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.ComprehensiveSR, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.GrayscaleSoftcopyPresentationStateStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.BasicVoiceAudioWaveformStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.TwleveLeadECGWaveformStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.GeneralECGWaveformStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.AmbulatoryECGWaveformStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RawDataStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.MammographyCadSR, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.ChestCadSR, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.KeyObjectSelectionDocument, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTDoseStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTPlanStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTStructureStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTBeamsTreatmentRecordStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTBrachyTreatmentRecordStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTTreatmentSummaryRecordStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.PseudoColorSoftcopyPresentationStateStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.BlendingSoftcopyPresentationStateStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.XRayRadiationDoseSRStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.SpatialRegistrationStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.DeformableSpatialRegistrationStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.SpatialFiducialsStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.EncapsulatedPdfStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.EncapsulatedCdaStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RealWorldValueMappingStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTIonPlanStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.RTIonBeamsTreatmentRecordStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.SegmentationStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.LensometryMeasurementsStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.AutorefractionMeasurementsStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.KeratometryMeasurementsStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.SubjectiveRefractionMeasurementsStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.VisualAcuityMeasurementsStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.SpectaclePrescriptionReportStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.XABiplaneImageStorageRetired, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.RLELossless,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.RTImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.PETImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.HardcopyColorImageStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.HardcopyGrayscaleImageStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]

        [PresentationContext(DicomUidType.NMImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]

        [PresentationContext(DicomUidType.NMImageStorageRetired, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.DXImageStoragePresentation, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.DXImageStorageProcessing, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.DXMammographyImageStoragePresentation, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.RLELossless,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.DXMammographyImageStorageProcessing, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.DXIntraoralImageStoragePresentation, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.RLELossless,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.DXIntraoralImageStorageProcessing, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.VLEndoscopicImageStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.VLMicroscopicImageStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.VLPhotographicImageStorageClass, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.MRImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.EnhancedMRImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]

        [PresentationContext(DicomUidType.HemodynamicWaveformStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.XAImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.XRayRadiofluoroscopicImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.SCMultiFrameGrayscaleByteImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.SCMultiFrameGrayscaleWordImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.SCMultiFrameTrueColorImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.RLELossless,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.SCMultiFrameSingleBitImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian)]
        [PresentationContext(DicomUidType.Ophthalmic16BitPhotographyImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.Ophthalmic8BitPhotographyImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                 DicomUidType.JPEG2000,
                                                 DicomUidType.JPEG2000LosslessOnly,
                                                 DicomUidType.JPEGBaseline1,
                                                 DicomUidType.JPEGExtended2_4,
                                                 DicomUidType.ExplicitVRBigEndian,
                                                 DicomUidType.ExplicitVRLittleEndian,
                                                 DicomUidType.JPEGLosslessNonhier14,
                                                 DicomUidType.JPEGLosslessNonhier14B)]


        [PresentationContext(DicomUidType.CRImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.USImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.USImageStorageRetired, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.USMultiframeImageStorageRetired, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.SCImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.USMultiframeImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.VideoEndoscopicImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.VideoMicroscopicImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.VideoPhotographicImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.EnhancedCTImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.EnhancedXAImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.EnhancedXrfImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.OphthalmicTomographyImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.XRay3dAngiographicImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.XRay3dCraniofacialImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
        [PresentationContext(DicomUidType.EnhancedPETImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.RLELossless,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]

        [PresentationContext(DicomUidType.XRayRadiofluoroscopicImageStorage, DicomUidType.ImplicitVRLittleEndian,
                                                         DicomUidType.JPEG2000,
                                                         DicomUidType.JPEG2000LosslessOnly,
                                                         DicomUidType.JPEGBaseline1,
                                                         DicomUidType.JPEGExtended2_4,
                                                         DicomUidType.ExplicitVRBigEndian,
                                                         DicomUidType.ExplicitVRLittleEndian,
                                                         DicomUidType.JPEGLosslessNonhier14,
                                                         DicomUidType.JPEGLosslessNonhier14B)]
  
        public DicomCommandStatusType OnStore(DicomClient Client, byte PresentationId,int MessageId, string AffectedClass, string Instance, 
                                              DicomCommandPriorityType Priority, string MoveAE, int MoveMessageId, DicomDataSet Request)
        {
            try
            {
               
               byte[] value = new byte[] { 0x00, 0x01 };
               Request.InsertElementAndSetValue ( DicomTag.FileMetaInformationVersion, value) ;
               Request.InsertElementAndSetValue ( DicomTag.MediaStorageSOPClassUID, AffectedClass) ;
               Request.InsertElementAndSetValue ( DicomTag.MediaStorageSOPInstanceUID, Instance) ;
               Request.InsertElementAndSetValue ( DicomTag.ImplementationClassUID, ( string.IsNullOrEmpty ( Client.Server.ImplementationClass ) ? "1.2.840.114257.1123456" : Client.Server.ImplementationClass ) ) ;
               Request.InsertElementAndSetValue ( DicomTag.ImplementationVersionName, ( string.IsNullOrEmpty ( Client.Server.ImplementationVersionName ) ? "LTPACSF V17" : Client.Server.ImplementationVersionName ) ) ;
               
               return DB.Insert(DateTime.Now, Module.ServerInfo, Client.AETitle, Request);                
            }
            catch(Exception e)
            {
                Logger.Global.Exception("CStore AddIn", e);
                return DicomCommandStatusType.ProcessingFailure;
            }
        }        

        #endregion        

        #region IProcessBreak Members

        public void Break(BreakType type)
        {            
        }

        #endregion
    }
}
