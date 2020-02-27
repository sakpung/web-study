// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="Models/ImageFrame.ts" />

module DicomTag {

// *****************************************************************************************************************************
// *** 0002
// *****************************************************************************************************************************
    export var FileMetaInformationGroupLength: string                         ="00020000";
    export var FileMetaInformationVersion: string                             ="00020001";
    export var MediaStorageSOPClassUID: string                                ="00020002";
    export var MediaStorageSOPInstanceUID: string                             ="00020003";
    export var TransferSyntaxUID: string                                      ="00020010";
    export var ImplementationClassUID: string                                 ="00020012";
    export var ImplementationVersionName: string                              ="00020013";
    export var SourceApplicationEntityTitle: string                           ="00020016";
    export var SendingApplicationEntityTitle: string                          ="00020017";
    export var ReceivingApplicationEntityTitle: string                        ="00020018";
    export var PrivateInformationCreatorUID: string                           ="00020100";
    export var PrivateInformation: string                                     ="00020102";

// *****************************************************************************************************************************
// *** 0004
// *****************************************************************************************************************************
    export var FileSetID: string                                              ="00041130";
    export var FileSetDescriptorFileID: string                                ="00041141";
    export var SpecificCharacterSetOfFileSetDescriptorFile: string            ="00041142";
    export var OffsetFirstRootDirectory: string                               ="00041200";
    export var OffsetLastRootDirectory: string                                ="00041202";
    export var FileSetConsistencyFlag: string                                 ="00041212";
    export var DirectoryRecordSequence: string                                ="00041220";
    export var OffsetNextDirectory: string                                    ="00041400";
    export var RecordInUseFlag: string                                        ="00041410";
    export var OffsetChildDirectory: string                                   ="00041420";
    export var DirectoryRecordType: string                                    ="00041430";
    export var PrivateRecordUID: string                                       ="00041432";
    export var ReferencedFileID: string                                       ="00041500";
    export var MRDRDirectoryRecordOffset: string                              ="00041504";   // Retired
    export var ReferencedSOPClassUIDInFile: string                            ="00041510";
    export var ReferencedSOPInstanceUIDInFile: string                         ="00041511";
    export var ReferencedTransferSyntaxUIDInFile: string                      ="00041512";
    export var ReferencedRelatedGeneralSOPClassUIDInFile: string              ="0004151A";
    export var NumberOfReferences: string                                     ="00041600";   // Retired

// *****************************************************************************************************************************
// *** 0008
// *****************************************************************************************************************************
    export var LengthToEnd: string                                            ="00080001";   // Retired
    export var SpecificCharacterSet: string                                   ="00080005";
    export var LanguageCodeSequence: string                                   ="00080006";
    export var ImageType: string                                              ="00080008";
    export var RecognitionCode: string                                        ="00080010";   // Retired
    export var InstanceCreationDate: string                                   ="00080012";
    export var InstanceCreationTime: string                                   ="00080013";
    export var InstanceCreatorUID: string                                     ="00080014";
    export var InstanceCoercionDateTime: string                               ="00080015";
    export var SOPClassUID: string                                            ="00080016";
    export var SOPInstanceUID: string                                         ="00080018";
    export var RelatedGeneralSOPClassUID: string                              ="0008001A";
    export var OriginalSpecializedSOPClassUID: string                         ="0008001B";
    export var StudyDate: string                                              ="00080020";
    export var SeriesDate: string                                             ="00080021";
    export var AcquisitionDate: string                                        ="00080022";
    export var ContentDate: string                                            ="00080023";
    export var OverlayDate: string                                            ="00080024";   // Retired
    export var CurveDate: string                                              ="00080025";   // Retired
    export var AcquisitionDateTime: string                                    ="0008002A";
    export var StudyTime: string                                              ="00080030";
    export var SeriesTime: string                                             ="00080031";
    export var AcquisitionTime: string                                        ="00080032";
    export var ContentTime: string                                            ="00080033";
    export var OverlayTime: string                                            ="00080034";   // Retired
    export var CurveTime: string                                              ="00080035";   // Retired
    export var DataSetType: string                                            ="00080040";   // Retired
    export var DataSetSubtype: string                                         ="00080041";   // Retired
    export var NuclearMedicineSeriesType: string                              ="00080042";   // Retired
    export var AccessionNumber: string                                        ="00080050";
    export var IssuerOfAccessionNumberSequence: string                        ="00080051";
    export var QueryRetrieveLevel: string                                     ="00080052";
    export var QueryRetrieveView: string                                      ="00080053";
    export var RetrieveAETitle: string                                        ="00080054";
    export var InstanceAvailability: string                                   ="00080056";
    export var FailedSOPInstanceUIDList: string                               ="00080058";
    export var Modality: string                                               ="00080060";
    export var ModalitiesInStudy: string                                      ="00080061";
    export var SOPClassesInStudy: string                                      ="00080062";
    export var ConversionType: string                                         ="00080064";
    export var PresentationIntentType: string                                 ="00080068";
    export var Manufacturer: string                                           ="00080070";
    export var InstitutionName: string                                        ="00080080";
    export var InstitutionAddress: string                                     ="00080081";
    export var InstitutionCodeSequence: string                                ="00080082";
    export var ReferringPhysicianName: string                                 ="00080090";
    export var ReferringPhysicianAddress: string                              ="00080092";
    export var ReferringPhysicianTelephoneNumbers: string                     ="00080094";
    export var ReferringPhysicianIdentificationSequence: string               ="00080096";
    export var ConsultingPhysicianName: string                                ="0008009C";
    export var ConsultingPhysicianIdentificationSequence: string              ="0008009D";
    export var CodeValue: string                                              ="00080100";
    export var ExtendedCodeValue: string                                      ="00080101";
    export var CodingSchemeDesignator: string                                 ="00080102";
    export var CodingSchemeVersion: string                                    ="00080103";
    export var CodeMeaning: string                                            ="00080104";
    export var MappingResource: string                                        ="00080105";
    export var ContextGroupVersion: string                                    ="00080106";
    export var ContextGroupLocalVersion: string                               ="00080107";
    export var ExtendedCodeMeaning: string                                    ="00080108";
    export var ContextGroupExtensionFlag: string                              ="0008010B";
    export var CodingSchemeUID: string                                        ="0008010C";
    export var ContextGroupExtensionCreatorUID: string                        ="0008010D";
    export var ContextIdentifier: string                                      ="0008010F";
    export var CodingSchemeIdentificationSequence: string                     ="00080110";
    export var CodingSchemeRegistry: string                                   ="00080112";
    export var CodingSchemeExternalID: string                                 ="00080114";
    export var CodingSchemeName: string                                       ="00080115";
    export var CodingSchemeResponsibleOrganization: string                    ="00080116";
    export var ContextUID: string                                             ="00080117";
    export var MappingResourceUID: string                                     ="00080118";
    export var LongCodeValue: string                                          ="00080119";
    export var URNCodeValue: string                                           ="00080120";
    export var EquivalentCodeSequence: string                                 ="00080121";
    export var TimezoneOffsetFromUTC: string                                  ="00080201";
    export var PrivateDataElementCharacteristicsSequence: string              ="00080300";
    export var PrivateGroupReference: string                                  ="00080301";
    export var PrivateCreatorReference: string                                ="00080302";
    export var BlockIdentifyingInformationStatus: string                      ="00080303";
    export var NonidentifyingPrivateElements: string                          ="00080304";
    export var DeidentificationActionSequence: string                         ="00080305";
    export var IdentifyingPrivateElements: string                             ="00080306";
    export var DeidentificationAction: string                                 ="00080307";
    export var NetworkID: string                                              ="00081000";   // Retired
    export var StationName: string                                            ="00081010";
    export var StudyDescription: string                                       ="00081030";
    export var ProcedureCodeSequence: string                                  ="00081032";
    export var SeriesDescription: string                                      ="0008103E";
    export var SeriesDescriptionCodeSequence: string                          ="0008103F";
    export var InstitutionalDepartmentName: string                            ="00081040";
    export var PhysicianOfRecord: string                                      ="00081048";
    export var PhysicianOfRecordIdentificationSequence: string                ="00081049";
    export var PerformingPhysicianName: string                                ="00081050";
    export var PerformingPhysicianIdentificationSequence: string              ="00081052";
    export var NameOfPhysicianReadingStudy: string                            ="00081060";
    export var PhysicianReadingStudyIdentificationSequence: string            ="00081062";
    export var OperatorName: string                                           ="00081070";
    export var OperatorIdentificationSequence: string                         ="00081072";
    export var AdmittingDiagnosesDescription: string                          ="00081080";
    export var AdmittingDiagnosesCodeSequence: string                         ="00081084";
    export var ManufacturerModelName: string                                  ="00081090";
    export var ReferencedResultsSequence: string                              ="00081100";   // Retired
    export var ReferencedStudySequence: string                                ="00081110";
    export var ReferencedPerformedProcedureStepSequence: string               ="00081111";
    export var ReferencedSeriesSequence: string                               ="00081115";
    export var ReferencedPatientSequence: string                              ="00081120";
    export var ReferencedVisitSequence: string                                ="00081125";
    export var ReferencedOverlaySequence: string                              ="00081130";   // Retired
    export var ReferencedStereometricInstanceSequence: string                 ="00081134";
    export var ReferencedWaveformSequence: string                             ="0008113A";
    export var ReferencedImageSequence: string                                ="00081140";
    export var ReferencedCurveSequence: string                                ="00081145";   // Retired
    export var ReferencedInstanceSequence: string                             ="0008114A";
    export var ReferencedRealWorldValueMappingInstanceSequence: string        ="0008114B";
    export var ReferencedSOPClassUID: string                                  ="00081150";
    export var ReferencedSOPInstanceUID: string                               ="00081155";
    export var SOPClassesSupported: string                                    ="0008115A";
    export var ReferencedFrameNumber: string                                  ="00081160";
    export var SimpleFrameList: string                                        ="00081161";
    export var CalculatedFrameList: string                                    ="00081162";
    export var TimeRange: string                                              ="00081163";
    export var FrameExtractionSequence: string                                ="00081164";
    export var MultiFrameSourceSOPInstanceUID: string                         ="00081167";
    export var RetrieveURL: string                                            ="00081190";
    export var TransactionUID: string                                         ="00081195";
    export var WarningReason: string                                          ="00081196";
    export var FailureReason: string                                          ="00081197";
    export var FailedSOPSequence: string                                      ="00081198";
    export var ReferencedSOPSequence: string                                  ="00081199";
    export var StudiesContainingOtherReferencedInstancesSequence: string      ="00081200";
    export var RelatedSeriesSequence: string                                  ="00081250";
    export var LossyImageCompressionRetired: string                           ="00082110";   // Retired
    export var DerivationDescription: string                                  ="00082111";
    export var SourceImageSequence: string                                    ="00082112";
    export var StageName: string                                              ="00082120";
    export var StageNumber: string                                            ="00082122";
    export var NumberOfStages: string                                         ="00082124";
    export var ViewName: string                                               ="00082127";
    export var ViewNumber: string                                             ="00082128";
    export var NumberOfEventTimers: string                                    ="00082129";
    export var NumberOfViewsInStage: string                                   ="0008212A";
    export var EventElapsedTime: string                                       ="00082130";
    export var EventTimerName: string                                         ="00082132";
    export var EventTimerSequence: string                                     ="00082133";
    export var EventTimeOffset: string                                        ="00082134";
    export var EventCodeSequence: string                                      ="00082135";
    export var StartTrim: string                                              ="00082142";
    export var StopTrim: string                                               ="00082143";
    export var RecommendedDisplayFrameRate: string                            ="00082144";
    export var TransducerPosition: string                                     ="00082200";   // Retired
    export var TransducerOrientation: string                                  ="00082204";   // Retired
    export var AnatomicStructure: string                                      ="00082208";   // Retired
    export var AnatomicRegionSequence: string                                 ="00082218";
    export var AnatomicRegionModifierSequence: string                         ="00082220";
    export var PrimaryAnatomicStructureSequence: string                       ="00082228";
    export var AnatomicStructureSpaceOrRegionSequence: string                 ="00082229";
    export var PrimaryAnatomicStructureModifierSequence: string               ="00082230";
    export var TransducerPositionSequence: string                             ="00082240";   // Retired
    export var TransducerPositionModifierSequence: string                     ="00082242";   // Retired
    export var TransducerOrientationSequence: string                          ="00082244";   // Retired
    export var TransducerOrientationModifierSequence: string                  ="00082246";   // Retired
    export var AnatomicStructureSpaceOrRegionCodeSequenceTrial: string        ="00082251";   // Retired
    export var AnatomicPortalOfEntranceCodeSequenceTrial: string              ="00082253";   // Retired
    export var AnatomicApproachDirectionCodeSequenceTrial: string             ="00082255";   // Retired
    export var AnatomicPerspectiveDescriptionTrial: string                    ="00082256";   // Retired
    export var AnatomicPerspectiveCodeSequenceTrial: string                   ="00082257";   // Retired
    export var AnatomicLocationOfExaminingInstrumentDescriptionTrial: string  ="00082258";   // Retired
    export var AnatomicLocationOfExaminingInstrumentCodeSequenceTrial: string ="00082259";   // Retired
    export var AnatomicStructureSpaceOrRegionModifierCodeSequenceTrial: string ="0008225A";   // Retired
    export var OnAxisBackgroundAnatomicStructureCodeSequenceTrial: string     ="0008225C";   // Retired
    export var AlternateRepresentationSequence: string                        ="00083001";
    export var IrradiationEventUID: string                                    ="00083010";
    export var SourceIrradiationEventSequence: string                         ="00083011";
    export var RadiopharmaceuticalAdministrationEventUID: string              ="00083012";
    export var IdentifyingComments: string                                    ="00084000";   // Retired
    export var FrameType: string                                              ="00089007";
    export var ReferencedImageEvidenceSequence: string                        ="00089092";
    export var ReferencedRawDataSequence: string                              ="00089121";
    export var CreatorVersionUID: string                                      ="00089123";
    export var DerivationImageSequence: string                                ="00089124";
    export var SourceImageEvidenceSequence: string                            ="00089154";
    export var PixelPresentation: string                                      ="00089205";
    export var VolumetricProperties: string                                   ="00089206";
    export var VolumeBasedCalculationTechnique: string                        ="00089207";
    export var ComplexImageComponent: string                                  ="00089208";
    export var AcquisitionContrast: string                                    ="00089209";
    export var DerivationCodeSequence: string                                 ="00089215";
    export var ReferencedPresentationStateSequence: string                    ="00089237";
    export var ReferencedOtherPlaneSequence: string                           ="00089410";
    export var FrameDisplaySequence: string                                   ="00089458";
    export var RecommendedDisplayFrameRateInFloat: string                     ="00089459";
    export var SkipFrameRangeFlag: string                                     ="00089460";

// *****************************************************************************************************************************
// *** 0010
// *****************************************************************************************************************************
    export var PatientName: string                                            ="00100010";
    export var PatientID: string                                              ="00100020";
    export var IssuerOfPatientID: string                                      ="00100021";
    export var TypeOfPatientID: string                                        ="00100022";
    export var IssuerOfPatientIDQualifiersSequence: string                    ="00100024";
    export var PatientBirthDate: string                                       ="00100030";
    export var PatientBirthTime: string                                       ="00100032";
    export var PatientSex: string                                             ="00100040";
    export var PatientInsurancePlanCodeSequence: string                       ="00100050";
    export var PatientPrimaryLanguageCodeSequence: string                     ="00100101";
    export var PatientPrimaryLanguageModifierCodeSequence: string             ="00100102";
    export var QualityControlSubject: string                                  ="00100200";
    export var QualityControlSubjectTypeCodeSequence: string                  ="00100201";
    export var OtherPatientIDs: string                                        ="00101000";
    export var OtherPatientNames: string                                      ="00101001";
    export var OtherPatientIDsSequence: string                                ="00101002";
    export var PatientBirthName: string                                       ="00101005";
    export var PatientAge: string                                             ="00101010";
    export var PatientSize: string                                            ="00101020";
    export var PatientSizeCodeSequence: string                                ="00101021";
    export var PatientWeight: string                                          ="00101030";
    export var PatientAddress: string                                         ="00101040";
    export var InsurancePlanIdentification: string                            ="00101050";   // Retired
    export var PatientMotherBirthName: string                                 ="00101060";
    export var MilitaryRank: string                                           ="00101080";
    export var BranchOfService: string                                        ="00101081";
    export var MedicalRecordLocator: string                                   ="00101090";
    export var ReferencedPatientPhotoSequence: string                         ="00101100";
    export var MedicalAlerts: string                                          ="00102000";
    export var Allergies: string                                              ="00102110";
    export var CountryOfResidence: string                                     ="00102150";
    export var RegionOfResidence: string                                      ="00102152";
    export var PatientTelephoneNumbers: string                                ="00102154";
    export var PatientTelecomInformation: string                              ="00102155";
    export var EthnicGroup: string                                            ="00102160";
    export var Occupation: string                                             ="00102180";
    export var SmokingStatus: string                                          ="001021A0";
    export var AdditionalPatientHistory: string                               ="001021B0";
    export var PregnancyStatus: string                                        ="001021C0";
    export var LastMenstrualDate: string                                      ="001021D0";
    export var PatientReligiousPreference: string                             ="001021F0";
    export var PatientSpeciesDescription: string                              ="00102201";
    export var PatientSpeciesCodeSequence: string                             ="00102202";
    export var PatientSexNeutered: string                                     ="00102203";
    export var AnatomicalOrientationType: string                              ="00102210";
    export var PatientBreedDescription: string                                ="00102292";
    export var PatientBreedCodeSequence: string                               ="00102293";
    export var BreedRegistrationSequence: string                              ="00102294";
    export var BreedRegistrationNumber: string                                ="00102295";
    export var BreedRegistryCodeSequence: string                              ="00102296";
    export var ResponsiblePerson: string                                      ="00102297";
    export var ResponsiblePersonRole: string                                  ="00102298";
    export var ResponsibleOrganization: string                                ="00102299";
    export var PatientComments: string                                        ="00104000";
    export var ExaminedBodyThickness: string                                  ="00109431";

// *****************************************************************************************************************************
// *** 0012
// *****************************************************************************************************************************
    export var ClinicalTrialSponsorName: string                               ="00120010";
    export var ClinicalTrialProtocolID: string                                ="00120020";
    export var ClinicalTrialProtocolName: string                              ="00120021";
    export var ClinicalTrialSiteID: string                                    ="00120030";
    export var ClinicalTrialSiteName: string                                  ="00120031";
    export var ClinicalTrialSubjectID: string                                 ="00120040";
    export var ClinicalTrialSubjectReadingID: string                          ="00120042";
    export var ClinicalTrialTimePointID: string                               ="00120050";
    export var ClinicalTrialTimePointDescription: string                      ="00120051";
    export var ClinicalTrialCoordinatingCenterName: string                    ="00120060";
    export var PatientIdentityRemoved: string                                 ="00120062";
    export var DeIdentificationMethod: string                                 ="00120063";
    export var DeIdentificationMethodCodeSequence: string                     ="00120064";
    export var ClinicalTrialSeriesID: string                                  ="00120071";
    export var ClinicalTrialSeriesDescription: string                         ="00120072";
    export var ClinicalTrialProtocolEthicsCommitteeName: string               ="00120081";
    export var ClinicalTrialProtocolEthicsCommitteeApprovalNumber: string     ="00120082";
    export var ConsentForClinicalTrialUseSequence: string                     ="00120083";
    export var DistributionType: string                                       ="00120084";
    export var ConsentForDistributionFlag: string                             ="00120085";

// *****************************************************************************************************************************
// *** 0014
// *****************************************************************************************************************************
    export var CADFileFormat: string                                          ="00140023";   // Retired
    export var ComponentReferenceSystem: string                               ="00140024";   // Retired
    export var ComponentManufacturingProcedure: string                        ="00140025";
    export var ComponentManufacturer: string                                  ="00140028";
    export var MaterialThickness: string                                      ="00140030";
    export var MaterialPipeDiameter: string                                   ="00140032";
    export var MaterialIsolationDiameter: string                              ="00140034";
    export var MaterialGrade: string                                          ="00140042";
    export var MaterialPropertiesDescription: string                          ="00140044";
    export var MaterialPropertiesFileFormat: string                           ="00140045";   // Retired
    export var MaterialNotes: string                                          ="00140046";
    export var ComponentShape: string                                         ="00140050";
    export var CurvatureType: string                                          ="00140052";
    export var OuterDiameter: string                                          ="00140054";
    export var InnerDiameter: string                                          ="00140056";
    export var ActualEnvironmentalConditions: string                          ="00141010";
    export var ExpiryDate: string                                             ="00141020";
    export var EnvironmentalConditions: string                                ="00141040";
    export var EvaluatorSequence: string                                      ="00142002";
    export var EvaluatorNumber: string                                        ="00142004";
    export var EvaluatorName: string                                          ="00142006";
    export var EvaluationAttempt: string                                      ="00142008";
    export var IndicationSequence: string                                     ="00142012";
    export var IndicationNumber: string                                       ="00142014";
    export var IndicationLabel: string                                        ="00142016";
    export var IndicationDescription: string                                  ="00142018";
    export var IndicationType: string                                         ="0014201A";
    export var IndicationDisposition: string                                  ="0014201C";
    export var IndicationROISequence: string                                  ="0014201E";
    export var IndicationPhysicalPropertySequence: string                     ="00142030";
    export var PropertyLabel: string                                          ="00142032";
    export var CoordinateSystemNumberOfAxes: string                           ="00142202";
    export var CoordinateSystemAxesSequence: string                           ="00142204";
    export var CoordinateSystemAxisDescription: string                        ="00142206";
    export var CoordinateSystemDataSetMapping: string                         ="00142208";
    export var CoordinateSystemAxisNumber: string                             ="0014220A";
    export var CoordinateSystemAxisType: string                               ="0014220C";
    export var CoordinateSystemAxisUnits: string                              ="0014220E";
    export var CoordinateSystemAxisValues: string                             ="00142210";
    export var CoordinateSystemTransformSequence: string                      ="00142220";
    export var TransformDescription: string                                   ="00142222";
    export var TransformNumberOfAxes: string                                  ="00142224";
    export var TransformOrderOfAxes: string                                   ="00142226";
    export var TransformedAxisUnits: string                                   ="00142228";
    export var CoordinateSystemTransformRotationAndScaleMatrix: string        ="0014222A";
    export var CoordinateSystemTransformTranslationMatrix: string             ="0014222C";
    export var InternalDetectorFrameTime: string                              ="00143011";
    export var NumberOfFramesIntegrated: string                               ="00143012";
    export var DetectorTemperatureSequence: string                            ="00143020";
    export var SensorName: string                                             ="00143022";
    export var HorizontalOffsetOfSensor: string                               ="00143024";
    export var VerticalOffsetOfSensor: string                                 ="00143026";
    export var SensorTemperature: string                                      ="00143028";
    export var DarkCurrentSequence: string                                    ="00143040";
    export var DarkCurrentCounts: string                                      ="00143050";
    export var GainCorrectionReferenceSequence: string                        ="00143060";
    export var AirCounts: string                                              ="00143070";
    export var KVUsedInGainCalibration: string                                ="00143071";
    export var MAUsedInGainCalibration: string                                ="00143072";
    export var NumberOfFramesUsedForIntegration: string                       ="00143073";
    export var FilterMaterialUsedInGainCalibration: string                    ="00143074";
    export var FilterThicknessUsedInGainCalibration: string                   ="00143075";
    export var DateOfGainCalibration: string                                  ="00143076";
    export var TimeOfGainCalibration: string                                  ="00143077";
    export var BadPixelImage: string                                          ="00143080";
    export var CalibrationNotes: string                                       ="00143099";
    export var PulserEquipmentSequence: string                                ="00144002";
    export var PulserType: string                                             ="00144004";
    export var PulserNotes: string                                            ="00144006";
    export var ReceiverEquipmentSequence: string                              ="00144008";
    export var AmplifierType: string                                          ="0014400A";
    export var ReceiverNotes: string                                          ="0014400C";
    export var PreAmplifierEquipmentSequence: string                          ="0014400E";
    export var PreAmplifierNotes: string                                      ="0014400F";
    export var TransmitTransducerSequence: string                             ="00144010";
    export var ReceiveTransducerSequence: string                              ="00144011";
    export var NumberOfElements: string                                       ="00144012";
    export var ElementShape: string                                           ="00144013";
    export var ElementDimensionA: string                                      ="00144014";
    export var ElementDimensionB: string                                      ="00144015";
    export var ElementPitchA: string                                          ="00144016";
    export var MeasuredBeamDimensionA: string                                 ="00144017";
    export var MeasuredBeamDimensionB: string                                 ="00144018";
    export var LocationOfMeasuredBeamDiameter: string                         ="00144019";
    export var NominalFrequency: string                                       ="0014401A";
    export var MeasuredCenterFrequency: string                                ="0014401B";
    export var MeasuredBandwidth: string                                      ="0014401C";
    export var ElementPitchB: string                                          ="0014401D";
    export var PulserSettingsSequence: string                                 ="00144020";
    export var PulseWidth: string                                             ="00144022";
    export var ExcitationFrequency: string                                    ="00144024";
    export var ModulationType: string                                         ="00144026";
    export var Damping: string                                                ="00144028";
    export var ReceiverSettingsSequence: string                               ="00144030";
    export var AcquiredSoundpathLength: string                                ="00144031";
    export var AcquisitionCompressionType: string                             ="00144032";
    export var AcquisitionSampleSize: string                                  ="00144033";
    export var RectifierSmoothing: string                                     ="00144034";
    export var DACSequence: string                                            ="00144035";
    export var DACType: string                                                ="00144036";
    export var DACGainPoints: string                                          ="00144038";
    export var DACTimePoints: string                                          ="0014403A";
    export var DACAmplitude: string                                           ="0014403C";
    export var PreAmplifierSettingsSequence: string                           ="00144040";
    export var TransmitTransducerSettingsSequence: string                     ="00144050";
    export var ReceiveTransducerSettingsSequence: string                      ="00144051";
    export var IncidentAngle: string                                          ="00144052";
    export var CouplingTechnique: string                                      ="00144054";
    export var CouplingMedium: string                                         ="00144056";
    export var CouplingVelocity: string                                       ="00144057";
    export var ProbeCenterLocationX: string                                   ="00144058";
    export var ProbeCenterLocationZ: string                                   ="00144059";
    export var SoundPathLength: string                                        ="0014405A";
    export var DelayLawIdentifier: string                                     ="0014405C";
    export var GateSettingsSequence: string                                   ="00144060";
    export var GateThreshold: string                                          ="00144062";
    export var VelocityOfSound: string                                        ="00144064";
    export var CalibrationSettingsSequence: string                            ="00144070";
    export var CalibrationProcedure: string                                   ="00144072";
    export var ProcedureVersion: string                                       ="00144074";
    export var ProcedureCreationDate: string                                  ="00144076";
    export var ProcedureExpirationDate: string                                ="00144078";
    export var ProcedureLastModifiedDate: string                              ="0014407A";
    export var CalibrationTime: string                                        ="0014407C";
    export var CalibrationDate: string                                        ="0014407E";
    export var ProbeDriveEquipmentSequence: string                            ="00144080";
    export var DriveType: string                                              ="00144081";
    export var ProbeDriveNotes: string                                        ="00144082";
    export var DriveProbeSequence: string                                     ="00144083";
    export var ProbeInductance: string                                        ="00144084";
    export var ProbeResistance: string                                        ="00144085";
    export var ReceiveProbeSequence: string                                   ="00144086";
    export var ProbeDriveSettingsSequence: string                             ="00144087";
    export var BridgeResistors: string                                        ="00144088";
    export var ProbeOrientationAngle: string                                  ="00144089";
    export var UserSelectedGainY: string                                      ="0014408B";
    export var UserSelectedPhase: string                                      ="0014408C";
    export var UserSelectedOffsetX: string                                    ="0014408D";
    export var UserSelectedOffsetY: string                                    ="0014408E";
    export var ChannelSettingsSequence: string                                ="00144091";
    export var ChannelThreshold: string                                       ="00144092";
    export var ScannerSettingsSequence: string                                ="0014409A";
    export var ScanProcedure: string                                          ="0014409B";
    export var TranslationRateX: string                                       ="0014409C";
    export var TranslationRateY: string                                       ="0014409D";
    export var ChannelOverlap: string                                         ="0014409F";
    export var ImageQualityIndicatorType: string                              ="001440A0";
    export var ImageQualityIndicatorMaterial: string                          ="001440A1";
    export var ImageQualityIndicatorSize: string                              ="001440A2";
    export var LINACEnergy: string                                            ="00145002";
    export var LINACOutput: string                                            ="00145004";
    export var ActiveAperture: string                                         ="00145100";
    export var TotalAperture: string                                          ="00145101";
    export var ApertureElevation: string                                      ="00145102";
    export var MainLobeAngle: string                                          ="00145103";
    export var MainRoofAngle: string                                          ="00145104";
    export var ConnectorType: string                                          ="00145105";
    export var WedgeModelNumber: string                                       ="00145106";
    export var WedgeAngleFloat: string                                        ="00145107";
    export var WedgeRoofAngle: string                                         ="00145108";
    export var WedgeElement1Position: string                                  ="00145109";
    export var WedgeMaterialVelocity: string                                  ="0014510A";
    export var WedgeMaterial: string                                          ="0014510B";
    export var WedgeOffsetZ: string                                           ="0014510C";
    export var WedgeOriginOffsetX: string                                     ="0014510D";
    export var WedgeTimeDelay: string                                         ="0014510E";
    export var WedgeName: string                                              ="0014510F";
    export var WedgeManufacturerName: string                                  ="00145110";
    export var WedgeDescription: string                                       ="00145111";
    export var NominalBeamAngle: string                                       ="00145112";
    export var WedgeOffsetX: string                                           ="00145113";
    export var WedgeOffsetY: string                                           ="00145114";
    export var WedgeTotalLength: string                                       ="00145115";
    export var WedgeInContactLength: string                                   ="00145116";
    export var WedgeFrontGap: string                                          ="00145117";
    export var WedgeTotalHeight: string                                       ="00145118";
    export var WedgeFrontHeight: string                                       ="00145119";
    export var WedgeRearHeight: string                                        ="0014511A";
    export var WedgeTotalWidth: string                                        ="0014511B";
    export var WedgeInContactWidth: string                                    ="0014511C";
    export var WedgeChamferHeight: string                                     ="0014511D";
    export var WedgeCurve: string                                             ="0014511E";
    export var RadiusAlongTheWedge: string                                    ="0014511F";

// *****************************************************************************************************************************
// *** 0018
// *****************************************************************************************************************************
    export var ContrastBolusAgent: string                                     ="00180010";
    export var ContrastBolusAgentSequence: string                             ="00180012";
    export var ContrastBolusT1Relaxivity: string                              ="00180013";
    export var ContrastBolusAdministrationRouteSequence: string               ="00180014";
    export var BodyPartExamined: string                                       ="00180015";
    export var ScanningSequence: string                                       ="00180020";
    export var SequenceVariant: string                                        ="00180021";
    export var ScanOptions: string                                            ="00180022";
    export var MRAcquisitionType: string                                      ="00180023";
    export var SequenceName: string                                           ="00180024";
    export var AngioFlag: string                                              ="00180025";
    export var InterventionDrugInformationSequence: string                    ="00180026";
    export var InterventionDrugStopTime: string                               ="00180027";
    export var InterventionDrugDose: string                                   ="00180028";
    export var InterventionDrugCodeSequence: string                           ="00180029";
    export var AdditionalDrugSequence: string                                 ="0018002A";
    export var Radionuclide: string                                           ="00180030";   // Retired
    export var Radiopharmaceutical: string                                    ="00180031";
    export var EnergyWindowCenterline: string                                 ="00180032";   // Retired
    export var EnergyWindowTotalWidth: string                                 ="00180033";   // Retired
    export var InterventionDrugName: string                                   ="00180034";
    export var InterventionDrugStartTime: string                              ="00180035";
    export var InterventionSequence: string                                   ="00180036";
    export var TherapyType: string                                            ="00180037";   // Retired
    export var InterventionStatus: string                                     ="00180038";
    export var TherapyDescription: string                                     ="00180039";   // Retired
    export var InterventionDescription: string                                ="0018003A";
    export var CineRate: string                                               ="00180040";
    export var InitialCineRunState: string                                    ="00180042";
    export var SliceThickness: string                                         ="00180050";
    export var KVP: string                                                    ="00180060";
    export var CountsAccumulated: string                                      ="00180070";
    export var AcquisitionTerminationCondition: string                        ="00180071";
    export var EffectiveDuration: string                                      ="00180072";
    export var AcquisitionStartCondition: string                              ="00180073";
    export var AcquisitionStartConditionData: string                          ="00180074";
    export var AcquisitionTerminationConditionData: string                    ="00180075";
    export var RepetitionTime: string                                         ="00180080";
    export var EchoTime: string                                               ="00180081";
    export var InversionTime: string                                          ="00180082";
    export var NumberOfAverages: string                                       ="00180083";
    export var ImagingFrequency: string                                       ="00180084";
    export var ImagedNucleus: string                                          ="00180085";
    export var EchoNumber: string                                             ="00180086";
    export var MagneticFieldStrength: string                                  ="00180087";
    export var SpacingBetweenSlices: string                                   ="00180088";
    export var NumberOfPhaseEncodingSteps: string                             ="00180089";
    export var DataCollectionDiameter: string                                 ="00180090";
    export var EchoTrainLength: string                                        ="00180091";
    export var PercentSampling: string                                        ="00180093";
    export var PercentPhaseFieldOfView: string                                ="00180094";
    export var PixelBandwidth: string                                         ="00180095";
    export var DeviceSerialNumber: string                                     ="00181000";
    export var DeviceUID: string                                              ="00181002";
    export var DeviceID: string                                               ="00181003";
    export var PlateID: string                                                ="00181004";
    export var GeneratorID: string                                            ="00181005";
    export var GridID: string                                                 ="00181006";
    export var CassetteID: string                                             ="00181007";
    export var GantryID: string                                               ="00181008";
    export var SecondaryCaptureDeviceID: string                               ="00181010";
    export var HardcopyCreationDeviceID: string                               ="00181011";   // Retired
    export var DateOfSecondaryCapture: string                                 ="00181012";
    export var TimeOfSecondaryCapture: string                                 ="00181014";
    export var SecondaryCaptureDeviceManufacturer: string                     ="00181016";
    export var HardcopyDeviceManufacturer: string                             ="00181017";   // Retired
    export var SecondaryCaptureDeviceManufacturerModelName: string            ="00181018";
    export var SecondaryCaptureDeviceSoftwareVersions: string                 ="00181019";
    export var HardcopyDeviceSoftwareVersion: string                          ="0018101A";   // Retired
    export var HardcopyDeviceManufacturerModelName: string                    ="0018101B";   // Retired
    export var SoftwareVersion: string                                        ="00181020";
    export var VideoImageFormatAcquired: string                               ="00181022";
    export var DigitalImageFormatAcquired: string                             ="00181023";
    export var ProtocolName: string                                           ="00181030";
    export var ContrastBolusRoute: string                                     ="00181040";
    export var ContrastBolusVolume: string                                    ="00181041";
    export var ContrastBolusStartTime: string                                 ="00181042";
    export var ContrastBolusStopTime: string                                  ="00181043";
    export var ContrastBolusTotalDose: string                                 ="00181044";
    export var SyringeCounts: string                                          ="00181045";
    export var ContrastFlowRate: string                                       ="00181046";
    export var ContrastFlowDuration: string                                   ="00181047";
    export var ContrastBolusIngredient: string                                ="00181048";
    export var ContrastBolusIngredientConcentration: string                   ="00181049";
    export var SpatialResolution: string                                      ="00181050";
    export var TriggerTime: string                                            ="00181060";
    export var TriggerSourceOrType: string                                    ="00181061";
    export var NominalInterval: string                                        ="00181062";
    export var FrameTime: string                                              ="00181063";
    export var CardiacFramingType: string                                     ="00181064";
    export var FrameTimeVector: string                                        ="00181065";
    export var FrameDelay: string                                             ="00181066";
    export var ImageTriggerDelay: string                                      ="00181067";
    export var MultiplexGroupTimeOffset: string                               ="00181068";
    export var TriggerTimeOffset: string                                      ="00181069";
    export var SynchronizationTrigger: string                                 ="0018106A";
    export var SynchronizationChannel: string                                 ="0018106C";
    export var TriggerSamplePosition: string                                  ="0018106E";
    export var RadiopharmaceuticalRoute: string                               ="00181070";
    export var RadiopharmaceuticalVolume: string                              ="00181071";
    export var RadiopharmaceuticalStartTime: string                           ="00181072";
    export var RadiopharmaceuticalStopTime: string                            ="00181073";
    export var RadionuclideTotalDose: string                                  ="00181074";
    export var RadionuclideHalfLife: string                                   ="00181075";
    export var RadionuclidePositronFraction: string                           ="00181076";
    export var RadiopharmaceuticalSpecificActivity: string                    ="00181077";
    export var RadiopharmaceuticalStartDateTime: string                       ="00181078";
    export var RadiopharmaceuticalStopDateTime: string                        ="00181079";
    export var BeatRejectionFlag: string                                      ="00181080";
    export var LowRRValue: string                                             ="00181081";
    export var HighRRValue: string                                            ="00181082";
    export var IntervalsAcquired: string                                      ="00181083";
    export var IntervalsRejected: string                                      ="00181084";
    export var PVCRejection: string                                           ="00181085";
    export var SkipBeats: string                                              ="00181086";
    export var HeartRate: string                                              ="00181088";
    export var CardiacNumberOfImages: string                                  ="00181090";
    export var TriggerWindow: string                                          ="00181094";
    export var ReconstructionDiameter: string                                 ="00181100";
    export var DistanceSourceToDetector: string                               ="00181110";
    export var DistanceSourceToPatient: string                                ="00181111";
    export var EstimatedRadiographicMagnificationFactor: string               ="00181114";
    export var GantryDetectorTilt: string                                     ="00181120";
    export var GantryDetectorSlew: string                                     ="00181121";
    export var TableHeight: string                                            ="00181130";
    export var TableTraverse: string                                          ="00181131";
    export var TableMotion: string                                            ="00181134";
    export var TableVerticalIncrement: string                                 ="00181135";
    export var TableLateralIncrement: string                                  ="00181136";
    export var TableLongitudinalIncrement: string                             ="00181137";
    export var TableAngle: string                                             ="00181138";
    export var TableType: string                                              ="0018113A";
    export var RotationDirection: string                                      ="00181140";
    export var AngularPosition: string                                        ="00181141";   // Retired
    export var RadialPosition: string                                         ="00181142";
    export var ScanArc: string                                                ="00181143";
    export var AngularStep: string                                            ="00181144";
    export var CenterOfRotationOffset: string                                 ="00181145";
    export var RotationOffset: string                                         ="00181146";   // Retired
    export var FieldOfViewShape: string                                       ="00181147";
    export var FieldOfViewDimension: string                                   ="00181149";
    export var ExposureTime: string                                           ="00181150";
    export var XRayTubeCurrent: string                                        ="00181151";
    export var Exposure: string                                               ="00181152";
    export var ExposureInUAs: string                                          ="00181153";
    export var AveragePulseWidth: string                                      ="00181154";
    export var RadiationSetting: string                                       ="00181155";
    export var RectificationType: string                                      ="00181156";
    export var RadiationMode: string                                          ="0018115A";
    export var ImageAndFluoroscopyAreaDoseProduct: string                     ="0018115E";
    export var FilterType: string                                             ="00181160";
    export var TypeOfFilters: string                                          ="00181161";
    export var IntensifierSize: string                                        ="00181162";
    export var ImagerPixelSpacing: string                                     ="00181164";
    export var Grid: string                                                   ="00181166";
    export var GeneratorPower: string                                         ="00181170";
    export var CollimatorGridName: string                                     ="00181180";
    export var CollimatorType: string                                         ="00181181";
    export var FocalDistance: string                                          ="00181182";
    export var XFocusCenter: string                                           ="00181183";
    export var YFocusCenter: string                                           ="00181184";
    export var FocalSpot: string                                              ="00181190";
    export var AnodeTargetMaterial: string                                    ="00181191";
    export var BodyPartThickness: string                                      ="001811A0";
    export var CompressionForce: string                                       ="001811A2";
    export var PaddleDescription: string                                      ="001811A4";
    export var DateOfLastCalibration: string                                  ="00181200";
    export var TimeOfLastCalibration: string                                  ="00181201";
    export var DateTimeOfLastCalibration: string                              ="00181202";
    export var ConvolutionKernel: string                                      ="00181210";
    export var UpperLowerPixelValues: string                                  ="00181240";   // Retired
    export var ActualFrameDuration: string                                    ="00181242";
    export var CountRate: string                                              ="00181243";
    export var PreferredPlaybackSequencing: string                            ="00181244";
    export var ReceiveCoilName: string                                        ="00181250";
    export var TransmitCoilName: string                                       ="00181251";
    export var PlateType: string                                              ="00181260";
    export var PhosphorType: string                                           ="00181261";
    export var ScanVelocity: string                                           ="00181300";
    export var WholeBodyTechnique: string                                     ="00181301";
    export var ScanLength: string                                             ="00181302";
    export var AcquisitionMatrix: string                                      ="00181310";
    export var InPlanePhaseEncodingDirection: string                          ="00181312";
    export var FlipAngle: string                                              ="00181314";
    export var VariableFlipAngleFlag: string                                  ="00181315";
    export var SAR: string                                                    ="00181316";
    export var DBDt: string                                                   ="00181318";
    export var AcquisitionDeviceProcessingDescription: string                 ="00181400";
    export var AcquisitionDeviceProcessingCode: string                        ="00181401";
    export var CassetteOrientation: string                                    ="00181402";
    export var CassetteSize: string                                           ="00181403";
    export var ExposuresOnPlate: string                                       ="00181404";
    export var RelativeXRayExposure: string                                   ="00181405";
    export var ExposureIndex: string                                          ="00181411";
    export var TargetExposureIndex: string                                    ="00181412";
    export var DeviationIndex: string                                         ="00181413";
    export var ColumnAngulation: string                                       ="00181450";
    export var TomoLayerHeight: string                                        ="00181460";
    export var TomoAngle: string                                              ="00181470";
    export var TomoTime: string                                               ="00181480";
    export var TomoType: string                                               ="00181490";
    export var TomoClass: string                                              ="00181491";
    export var NumberOfTomosynthesisSourceImages: string                      ="00181495";
    export var PositionerMotion: string                                       ="00181500";
    export var PositionerType: string                                         ="00181508";
    export var PositionerPrimaryAngle: string                                 ="00181510";
    export var PositionerSecondaryAngle: string                               ="00181511";
    export var PositionerPrimaryAngleIncrement: string                        ="00181520";
    export var PositionerSecondaryAngleIncrement: string                      ="00181521";
    export var DetectorPrimaryAngle: string                                   ="00181530";
    export var DetectorSecondaryAngle: string                                 ="00181531";
    export var ShutterShape: string                                           ="00181600";
    export var ShutterLeftVerticalEdge: string                                ="00181602";
    export var ShutterRightVerticalEdge: string                               ="00181604";
    export var ShutterUpperHorizontalEdge: string                             ="00181606";
    export var ShutterLowerHorizontalEdge: string                             ="00181608";
    export var CenterOfCircularShutter: string                                ="00181610";
    export var RadiusOfCircularShutter: string                                ="00181612";
    export var VerticesOfThePolygonalShutter: string                          ="00181620";
    export var ShutterPresentationValue: string                               ="00181622";
    export var ShutterOverlayGroup: string                                    ="00181623";
    export var ShutterPresentationColorCIELabValue: string                    ="00181624";
    export var CollimatorShape: string                                        ="00181700";
    export var CollimatorLeftVerticalEdge: string                             ="00181702";
    export var CollimatorRightVerticalEdge: string                            ="00181704";
    export var CollimatorUpperHorizontalEdge: string                          ="00181706";
    export var CollimatorLowerHorizontalEdge: string                          ="00181708";
    export var CenterOfCircularCollimator: string                             ="00181710";
    export var RadiusOfCircularCollimator: string                             ="00181712";
    export var VerticesOfThePolygonalCollimator: string                       ="00181720";
    export var AcquisitionTimeSynchronized: string                            ="00181800";
    export var TimeSource: string                                             ="00181801";
    export var TimeDistributionProtocol: string                               ="00181802";
    export var NTPSourceAddress: string                                       ="00181803";
    export var PageNumberVector: string                                       ="00182001";
    export var FrameLabelVector: string                                       ="00182002";
    export var FramePrimaryAngleVector: string                                ="00182003";
    export var FrameSecondaryAngleVector: string                              ="00182004";
    export var SliceLocationVector: string                                    ="00182005";
    export var DisplayWindowLabelVector: string                               ="00182006";
    export var NominalScannedPixelSpacing: string                             ="00182010";
    export var DigitizingDeviceTransportDirection: string                     ="00182020";
    export var RotationOfScannedFilm: string                                  ="00182030";
    export var BiopsyTargetSequence: string                                   ="00182041";
    export var TargetUID: string                                              ="00182042";
    export var LocalizingCursorPosition: string                               ="00182043";
    export var CalculatedTargetPosition: string                               ="00182044";
    export var TargetLabel: string                                            ="00182045";
    export var DisplayedZValue: string                                        ="00182046";
    export var IVUSAcquisition: string                                        ="00183100";
    export var IVUSPullbackRate: string                                       ="00183101";
    export var IVUSGatedRate: string                                          ="00183102";
    export var IVUSPullbackStartFrameNumber: string                           ="00183103";
    export var IVUSPullbackStopFrameNumber: string                            ="00183104";
    export var LesionNumber: string                                           ="00183105";
    export var AcquisitionComments: string                                    ="00184000";   // Retired
    export var OutputPower: string                                            ="00185000";
    export var TransducerData: string                                         ="00185010";
    export var FocusDepth: string                                             ="00185012";
    export var ProcessingFunction: string                                     ="00185020";
    export var PostprocessingFunction: string                                 ="00185021";   // Retired
    export var MechanicalIndex: string                                        ="00185022";
    export var BoneThermalIndex: string                                       ="00185024";
    export var CranialThermalIndex: string                                    ="00185026";
    export var SoftTissueThermalIndex: string                                 ="00185027";
    export var SoftTissueFocusThermalIndex: string                            ="00185028";
    export var SoftTissueSurfaceThermalIndex: string                          ="00185029";
    export var DynamicRange: string                                           ="00185030";   // Retired
    export var TotalGain: string                                              ="00185040";   // Retired
    export var DepthOfScanField: string                                       ="00185050";
    export var PatientPosition: string                                        ="00185100";
    export var ViewPosition: string                                           ="00185101";
    export var ProjectionEponymousNameCodeSequence: string                    ="00185104";
    export var ImageTransformationMatrix: string                              ="00185210";   // Retired
    export var ImageTranslationVector: string                                 ="00185212";   // Retired
    export var Sensitivity: string                                            ="00186000";
    export var SequenceOfUltrasoundRegions: string                            ="00186011";
    export var RegionSpatialFormat: string                                    ="00186012";
    export var RegionDataType: string                                         ="00186014";
    export var RegionFlags: string                                            ="00186016";
    export var RegionLocationMinX0: string                                    ="00186018";
    export var RegionLocationMinY0: string                                    ="0018601A";
    export var RegionLocationMaxX1: string                                    ="0018601C";
    export var RegionLocationMaxY1: string                                    ="0018601E";
    export var ReferencePixelX0: string                                       ="00186020";
    export var ReferencePixelY0: string                                       ="00186022";
    export var PhysicalUnitsXDirection: string                                ="00186024";
    export var PhysicalUnitsYDirection: string                                ="00186026";
    export var ReferencePixelPhysicalValueX: string                           ="00186028";
    export var ReferencePixelPhysicalValueY: string                           ="0018602A";
    export var PhysicalDeltaX: string                                         ="0018602C";
    export var PhysicalDeltaY: string                                         ="0018602E";
    export var TransducerFrequency: string                                    ="00186030";
    export var TransducerType: string                                         ="00186031";
    export var PulseRepetitionFrequency: string                               ="00186032";
    export var DopplerCorrectionAngle: string                                 ="00186034";
    export var SteeringAngle: string                                          ="00186036";
    export var DopplerSampleVolumeXPositionRetired: string                    ="00186038";   // Retired
    export var DopplerSampleVolumeXPosition: string                           ="00186039";
    export var DopplerSampleVolumeYPositionRetired: string                    ="0018603A";   // Retired
    export var DopplerSampleVolumeYPosition: string                           ="0018603B";
    export var TMLinePositionX0Retired: string                                ="0018603C";   // Retired
    export var TMLinePositionX0: string                                       ="0018603D";
    export var TMLinePositionY0Retired: string                                ="0018603E";   // Retired
    export var TMLinePositionY0: string                                       ="0018603F";
    export var TMLinePositionX1Retired: string                                ="00186040";   // Retired
    export var TMLinePositionX1: string                                       ="00186041";
    export var TMLinePositionY1Retired: string                                ="00186042";   // Retired
    export var TMLinePositionY1: string                                       ="00186043";
    export var PixelComponentOrganization: string                             ="00186044";
    export var PixelComponentMask: string                                     ="00186046";
    export var PixelComponentRangeStart: string                               ="00186048";
    export var PixelComponentRangeStop: string                                ="0018604A";
    export var PixelComponentPhysicalUnits: string                            ="0018604C";
    export var PixelComponentDataType: string                                 ="0018604E";
    export var NumberOfTableBreakPoints: string                               ="00186050";
    export var TableOfXBreakPoints: string                                    ="00186052";
    export var TableOfYBreakPoints: string                                    ="00186054";
    export var NumberOfTableEntries: string                                   ="00186056";
    export var TableOfPixelValues: string                                     ="00186058";
    export var TableOfParameterValues: string                                 ="0018605A";
    export var RWaveTimeVector: string                                        ="00186060";
    export var DetectorConditionsNominalFlag: string                          ="00187000";
    export var DetectorTemperature: string                                    ="00187001";
    export var DetectorType: string                                           ="00187004";
    export var DetectorConfiguration: string                                  ="00187005";
    export var DetectorDescription: string                                    ="00187006";
    export var DetectorMode: string                                           ="00187008";
    export var DetectorID: string                                             ="0018700A";
    export var DateOfLastDetectorCalibration: string                          ="0018700C";
    export var TimeOfLastDetectorCalibration: string                          ="0018700E";
    export var ExposuresOnDetectorSinceLastCalibration: string                ="00187010";
    export var ExposuresOnDetectorSinceManufactured: string                   ="00187011";
    export var DetectorTimeSinceLastExposure: string                          ="00187012";
    export var DetectorActiveTime: string                                     ="00187014";
    export var DetectorActivationOffsetFromExposure: string                   ="00187016";
    export var DetectorBinning: string                                        ="0018701A";
    export var DetectorElementPhysicalSize: string                            ="00187020";
    export var DetectorElementSpacing: string                                 ="00187022";
    export var DetectorActiveShape: string                                    ="00187024";
    export var DetectorActiveDimension: string                                ="00187026";
    export var DetectorActiveOrigin: string                                   ="00187028";
    export var DetectorManufacturerName: string                               ="0018702A";
    export var DetectorManufacturerModelName: string                          ="0018702B";
    export var FieldOfViewOrigin: string                                      ="00187030";
    export var FieldOfViewRotation: string                                    ="00187032";
    export var FieldOfViewHorizontalFlip: string                              ="00187034";
    export var PixelDataAreaOriginRelativeToFOV: string                       ="00187036";
    export var PixelDataAreaRotationAngleRelativeToFOV: string                ="00187038";
    export var GridAbsorbingMaterial: string                                  ="00187040";
    export var GridSpacingMaterial: string                                    ="00187041";
    export var GridThickness: string                                          ="00187042";
    export var GridPitch: string                                              ="00187044";
    export var GridAspectRatio: string                                        ="00187046";
    export var GridPeriod: string                                             ="00187048";
    export var GridFocalDistance: string                                      ="0018704C";
    export var FilterMaterial: string                                         ="00187050";
    export var FilterThicknessMinimum: string                                 ="00187052";
    export var FilterThicknessMaximum: string                                 ="00187054";
    export var FilterBeamPathLengthMinimum: string                            ="00187056";
    export var FilterBeamPathLengthMaximum: string                            ="00187058";
    export var ExposureControlMode: string                                    ="00187060";
    export var ExposureControlModeDescription: string                         ="00187062";
    export var ExposureStatus: string                                         ="00187064";
    export var PhototimerSetting: string                                      ="00187065";
    export var ExposureTimeInUS: string                                       ="00188150";
    export var XRayTubeCurrentInUA: string                                    ="00188151";
    export var ContentQualification: string                                   ="00189004";
    export var PulseSequenceName: string                                      ="00189005";
    export var MRImagingModifierSequence: string                              ="00189006";
    export var EchoPulseSequence: string                                      ="00189008";
    export var InversionRecovery: string                                      ="00189009";
    export var FlowCompensation: string                                       ="00189010";
    export var MultipleSpinEcho: string                                       ="00189011";
    export var MultiPlanarExcitation: string                                  ="00189012";
    export var PhaseContrast: string                                          ="00189014";
    export var TimeOfFlightContrast: string                                   ="00189015";
    export var Spoiling: string                                               ="00189016";
    export var SteadyStatePulseSequence: string                               ="00189017";
    export var EchoPlanarPulseSequence: string                                ="00189018";
    export var TagAngleFirstAxis: string                                      ="00189019";
    export var MagnetizationTransfer: string                                  ="00189020";
    export var T2Preparation: string                                          ="00189021";
    export var BloodSignalNulling: string                                     ="00189022";
    export var SaturationRecovery: string                                     ="00189024";
    export var SpectrallySelectedSuppression: string                          ="00189025";
    export var SpectrallySelectedExcitation: string                           ="00189026";
    export var SpatialPreSaturation: string                                   ="00189027";
    export var Tagging: string                                                ="00189028";
    export var OversamplingPhase: string                                      ="00189029";
    export var TagSpacingFirstDimension: string                               ="00189030";
    export var GeometryOfKSpaceTraversal: string                              ="00189032";
    export var SegmentedKSpaceTraversal: string                               ="00189033";
    export var RectilinearPhaseEncodeReordering: string                       ="00189034";
    export var TagThickness: string                                           ="00189035";
    export var PartialFourierDirection: string                                ="00189036";
    export var CardiacSynchronizationTechnique: string                        ="00189037";
    export var ReceiveCoilManufacturerName: string                            ="00189041";
    export var MRReceiveCoilSequence: string                                  ="00189042";
    export var ReceiveCoilType: string                                        ="00189043";
    export var QuadratureReceiveCoil: string                                  ="00189044";
    export var MultiCoilDefinitionSequence: string                            ="00189045";
    export var MultiCoilConfiguration: string                                 ="00189046";
    export var MultiCoilElementName: string                                   ="00189047";
    export var MultiCoilElementUsed: string                                   ="00189048";
    export var MRTransmitCoilSequence: string                                 ="00189049";
    export var TransmitCoilManufacturerName: string                           ="00189050";
    export var TransmitCoilType: string                                       ="00189051";
    export var SpectralWidth: string                                          ="00189052";
    export var ChemicalShiftReference: string                                 ="00189053";
    export var VolumeLocalizationTechnique: string                            ="00189054";
    export var MRAcquisitionFrequencyEncodingSteps: string                    ="00189058";
    export var DeCoupling: string                                             ="00189059";
    export var DeCoupledNucleus: string                                       ="00189060";
    export var DeCouplingFrequency: string                                    ="00189061";
    export var DeCouplingMethod: string                                       ="00189062";
    export var DeCouplingChemicalShiftReference: string                       ="00189063";
    export var KSpaceFiltering: string                                        ="00189064";
    export var TimeDomainFiltering: string                                    ="00189065";
    export var NumberOfZeroFills: string                                      ="00189066";
    export var BaselineCorrection: string                                     ="00189067";
    export var ParallelReductionFactorInPlane: string                         ="00189069";
    export var CardiacRRIntervalSpecified: string                             ="00189070";
    export var AcquisitionDuration: string                                    ="00189073";
    export var FrameAcquisitionDateTime: string                               ="00189074";
    export var DiffusionDirectionality: string                                ="00189075";
    export var DiffusionGradientDirectionSequence: string                     ="00189076";
    export var ParallelAcquisition: string                                    ="00189077";
    export var ParallelAcquisitionTechnique: string                           ="00189078";
    export var InversionTimes: string                                         ="00189079";
    export var MetaboliteMapDescription: string                               ="00189080";
    export var PartialFourier: string                                         ="00189081";
    export var EffectiveEchoTime: string                                      ="00189082";
    export var MetaboliteMapCodeSequence: string                              ="00189083";
    export var ChemicalShiftSequence: string                                  ="00189084";
    export var CardiacSignalSource: string                                    ="00189085";
    export var DiffusionBValue: string                                        ="00189087";
    export var DiffusionGradientOrientation: string                           ="00189089";
    export var VelocityEncodingDirection: string                              ="00189090";
    export var VelocityEncodingMinimumValue: string                           ="00189091";
    export var VelocityEncodingAcquisitionSequence: string                    ="00189092";
    export var NumberOfKSpaceTrajectories: string                             ="00189093";
    export var CoverageOfKSpace: string                                       ="00189094";
    export var SpectroscopyAcquisitionPhaseRows: string                       ="00189095";
    export var ParallelReductionFactorInPlaneRetired: string                  ="00189096";   // Retired
    export var TransmitterFrequency: string                                   ="00189098";
    export var ResonantNucleus: string                                        ="00189100";
    export var FrequencyCorrection: string                                    ="00189101";
    export var MRSpectroscopyFOVGeometrySequence: string                      ="00189103";
    export var SlabThickness: string                                          ="00189104";
    export var SlabOrientation: string                                        ="00189105";
    export var MidSlabPosition: string                                        ="00189106";
    export var MRSpatialSaturationSequence: string                            ="00189107";
    export var MRTimingAndRelatedParametersSequence: string                   ="00189112";
    export var MREchoSequence: string                                         ="00189114";
    export var MRModifierSequence: string                                     ="00189115";
    export var MRDiffusionSequence: string                                    ="00189117";
    export var CardiacSynchronizationSequence: string                         ="00189118";
    export var MRAveragesSequence: string                                     ="00189119";
    export var MRFOVGeometrySequence: string                                  ="00189125";
    export var VolumeLocalizationSequence: string                             ="00189126";
    export var SpectroscopyAcquisitionDataColumns: string                     ="00189127";
    export var DiffusionAnisotropyType: string                                ="00189147";
    export var FrameReferenceDateTime: string                                 ="00189151";
    export var MRMetaboliteMapSequence: string                                ="00189152";
    export var ParallelReductionFactorOutOfPlane: string                      ="00189155";
    export var SpectroscopyAcquisitionOutOfPlanePhaseSteps: string            ="00189159";
    export var BulkMotionStatus: string                                       ="00189166";   // Retired
    export var ParallelReductionFactorSecondInPlane: string                   ="00189168";
    export var CardiacBeatRejectionTechnique: string                          ="00189169";
    export var RespiratoryMotionCompensationTechnique: string                 ="00189170";
    export var RespiratorySignalSource: string                                ="00189171";
    export var BulkMotionCompensationTechnique: string                        ="00189172";
    export var BulkMotionSignalSource: string                                 ="00189173";
    export var ApplicableSafetyStandardAgency: string                         ="00189174";
    export var ApplicableSafetyStandardDescription: string                    ="00189175";
    export var OperatingModeSequence: string                                  ="00189176";
    export var OperatingModeType: string                                      ="00189177";
    export var OperatingMode: string                                          ="00189178";
    export var SpecificAbsorptionRateDefinition: string                       ="00189179";
    export var GradientOutputType: string                                     ="00189180";
    export var SpecificAbsorptionRateValue: string                            ="00189181";
    export var GradientOutput: string                                         ="00189182";
    export var FlowCompensationDirection: string                              ="00189183";
    export var TaggingDelay: string                                           ="00189184";
    export var RespiratoryMotionCompensationTechniqueDescription: string      ="00189185";
    export var RespiratorySignalSourceID: string                              ="00189186";
    export var ChemicalShiftMinimumIntegrationLimitInHz: string               ="00189195";   // Retired
    export var ChemicalShiftMaximumIntegrationLimitInHz: string               ="00189196";   // Retired
    export var MRVelocityEncodingSequence: string                             ="00189197";
    export var FirstOrderPhaseCorrection: string                              ="00189198";
    export var WaterReferencedPhaseCorrection: string                         ="00189199";
    export var MRSpectroscopyAcquisitionType: string                          ="00189200";
    export var RespiratoryCyclePosition: string                               ="00189214";
    export var VelocityEncodingMaximumValue: string                           ="00189217";
    export var TagSpacingSecondDimension: string                              ="00189218";
    export var TagAngleSecondAxis: string                                     ="00189219";
    export var FrameAcquisitionDuration: string                               ="00189220";
    export var MRImageFrameTypeSequence: string                               ="00189226";
    export var MRSpectroscopyFrameTypeSequence: string                        ="00189227";
    export var MRAcquisitionPhaseEncodingStepsInPlane: string                 ="00189231";
    export var MRAcquisitionPhaseEncodingStepsOutOfPlane: string              ="00189232";
    export var SpectroscopyAcquisitionPhaseColumns: string                    ="00189234";
    export var CardiacCyclePosition: string                                   ="00189236";
    export var SpecificAbsorptionRateSequence: string                         ="00189239";
    export var RFEchoTrainLength: string                                      ="00189240";
    export var GradientEchoTrainLength: string                                ="00189241";
    export var ArterialSpinLabelingContrast: string                           ="00189250";
    export var MRArterialSpinLabelingSequence: string                         ="00189251";
    export var ASLTechniqueDescription: string                                ="00189252";
    export var ASLSlabNumber: string                                          ="00189253";
    export var ASLSlabThickness: string                                       ="00189254";
    export var ASLSlabOrientation: string                                     ="00189255";
    export var ASLMidSlabPosition: string                                     ="00189256";
    export var ASLContext: string                                             ="00189257";
    export var ASLPulseTrainDuration: string                                  ="00189258";
    export var ASLCrusherFlag: string                                         ="00189259";
    export var ASLCrusherFlowLimit: string                                    ="0018925A";
    export var ASLCrusherDescription: string                                  ="0018925B";
    export var ASLBolusCutOffFlag: string                                     ="0018925C";
    export var ASLBolusCutOffTimingSequence: string                           ="0018925D";
    export var ASLBolusCutOffTechnique: string                                ="0018925E";
    export var ASLBolusCutOffDelayTime: string                                ="0018925F";
    export var ASLSlabSequence: string                                        ="00189260";
    export var ChemicalShiftMinimumIntegrationLimitInPpm: string              ="00189295";
    export var ChemicalShiftMaximumIntegrationLimitInPpm: string              ="00189296";
    export var WaterReferenceAcquisition: string                              ="00189297";
    export var EchoPeakPosition: string                                       ="00189298";
    export var CTAcquisitionTypeSequence: string                              ="00189301";
    export var AcquisitionType: string                                        ="00189302";
    export var TubeAngle: string                                              ="00189303";
    export var CTAcquisitionDetailsSequence: string                           ="00189304";
    export var RevolutionTime: string                                         ="00189305";
    export var SingleCollimationWidth: string                                 ="00189306";
    export var TotalCollimationWidth: string                                  ="00189307";
    export var CTTableDynamicsSequence: string                                ="00189308";
    export var TableSpeed: string                                             ="00189309";
    export var TableFeedPerRotation: string                                   ="00189310";
    export var SpiralPitchFactor: string                                      ="00189311";
    export var CTGeometrySequence: string                                     ="00189312";
    export var DataCollectionCenterPatient: string                            ="00189313";
    export var CTReconstructionSequence: string                               ="00189314";
    export var ReconstructionAlgorithm: string                                ="00189315";
    export var ConvolutionKernelGroup: string                                 ="00189316";
    export var ReconstructionFieldOfView: string                              ="00189317";
    export var ReconstructionTargetCenterPatient: string                      ="00189318";
    export var ReconstructionAngle: string                                    ="00189319";
    export var ImageFilter: string                                            ="00189320";
    export var CTExposureSequence: string                                     ="00189321";
    export var ReconstructionPixelSpacing: string                             ="00189322";
    export var ExposureModulationType: string                                 ="00189323";
    export var EstimatedDoseSaving: string                                    ="00189324";
    export var CTXRayDetailsSequence: string                                  ="00189325";
    export var CTPositionSequence: string                                     ="00189326";
    export var TablePosition: string                                          ="00189327";
    export var ExposureTimeInMs: string                                       ="00189328";
    export var CTImageFrameTypeSequence: string                               ="00189329";
    export var XRayTubeCurrentInMA: string                                    ="00189330";
    export var ExposureInMAs: string                                          ="00189332";
    export var ConstantVolumeFlag: string                                     ="00189333";
    export var FluoroscopyFlag: string                                        ="00189334";
    export var DistanceSourceToDataCollectionCenter: string                   ="00189335";
    export var ContrastBolusAgentNumber: string                               ="00189337";
    export var ContrastBolusIngredientCodeSequence: string                    ="00189338";
    export var ContrastAdministrationProfileSequence: string                  ="00189340";
    export var ContrastBolusUsageSequence: string                             ="00189341";
    export var ContrastBolusAgentAdministered: string                         ="00189342";
    export var ContrastBolusAgentDetected: string                             ="00189343";
    export var ContrastBolusAgentPhase: string                                ="00189344";
    export var CTDIvol: string                                                ="00189345";
    export var CTDIPhantomTypeCodeSequence: string                            ="00189346";
    export var CalciumScoringMassFactorPatient: string                        ="00189351";
    export var CalciumScoringMassFactorDevice: string                         ="00189352";
    export var EnergyWeightingFactor: string                                  ="00189353";
    export var CTAdditionalXRaySourceSequence: string                         ="00189360";
    export var ProjectionPixelCalibrationSequence: string                     ="00189401";
    export var DistanceSourceToIsocenter: string                              ="00189402";
    export var DistanceObjectToTableTop: string                               ="00189403";
    export var ObjectPixelSpacingInCenterOfBeam: string                       ="00189404";
    export var PositionerPositionSequence: string                             ="00189405";
    export var TablePositionSequence: string                                  ="00189406";
    export var CollimatorShapeSequence: string                                ="00189407";
    export var PlanesInAcquisition: string                                    ="00189410";
    export var XAXRFFrameCharacteristicsSequence: string                      ="00189412";
    export var FrameAcquisitionSequence: string                               ="00189417";
    export var XRayReceptorType: string                                       ="00189420";
    export var AcquisitionProtocolName: string                                ="00189423";
    export var AcquisitionProtocolDescription: string                         ="00189424";
    export var ContrastBolusIngredientOpaque: string                          ="00189425";
    export var DistanceReceptorPlaneToDetectorHousing: string                 ="00189426";
    export var IntensifierActiveShape: string                                 ="00189427";
    export var IntensifierActiveDimension: string                             ="00189428";
    export var PhysicalDetectorSize: string                                   ="00189429";
    export var PositionOfIsocenterProjection: string                          ="00189430";
    export var FieldOfViewSequence: string                                    ="00189432";
    export var FieldOfViewDescription: string                                 ="00189433";
    export var ExposureControlSensingRegionsSequence: string                  ="00189434";
    export var ExposureControlSensingRegionShape: string                      ="00189435";
    export var ExposureControlSensingRegionLeftVerticalEdge: string           ="00189436";
    export var ExposureControlSensingRegionRightVerticalEdge: string          ="00189437";
    export var ExposureControlSensingRegionUpperHorizontalEdge: string        ="00189438";
    export var ExposureControlSensingRegionLowerHorizontalEdge: string        ="00189439";
    export var CenterOfCircularExposureControlSensingRegion: string           ="00189440";
    export var RadiusOfCircularExposureControlSensingRegion: string           ="00189441";
    export var VerticesOfThePolygonalExposureControlSensingRegion: string     ="00189442";
    export var ColumnAngulationPatient: string                                ="00189447";
    export var BeamAngle: string                                              ="00189449";
    export var FrameDetectorParametersSequence: string                        ="00189451";
    export var CalculatedAnatomyThickness: string                             ="00189452";
    export var CalibrationSequence: string                                    ="00189455";
    export var ObjectThicknessSequence: string                                ="00189456";
    export var PlaneIdentification: string                                    ="00189457";
    export var FieldOfViewDimensionInFloat: string                            ="00189461";
    export var IsocenterReferenceSystemSequence: string                       ="00189462";
    export var PositionerIsocenterPrimaryAngle: string                        ="00189463";
    export var PositionerIsocenterSecondaryAngle: string                      ="00189464";
    export var PositionerIsocenterDetectorRotationAngle: string               ="00189465";
    export var TableXPositionToIsocenter: string                              ="00189466";
    export var TableYPositionToIsocenter: string                              ="00189467";
    export var TableZPositionToIsocenter: string                              ="00189468";
    export var TableHorizontalRotationAngle: string                           ="00189469";
    export var TableHeadTiltAngle: string                                     ="00189470";
    export var TableCradleTiltAngle: string                                   ="00189471";
    export var FrameDisplayShutterSequence: string                            ="00189472";
    export var AcquiredImageAreaDoseProduct: string                           ="00189473";
    export var CArmPositionerTabletopRelationship: string                     ="00189474";
    export var XRayGeometrySequence: string                                   ="00189476";
    export var IrradiationEventIdentificationSequence: string                 ="00189477";
    export var XRay3DFrameTypeSequence: string                                ="00189504";
    export var ContributingSourcesSequence: string                            ="00189506";
    export var XRay3DAcquisitionSequence: string                              ="00189507";
    export var PrimaryPositionerScanArc: string                               ="00189508";
    export var SecondaryPositionerScanArc: string                             ="00189509";
    export var PrimaryPositionerScanStartAngle: string                        ="00189510";
    export var SecondaryPositionerScanStartAngle: string                      ="00189511";
    export var PrimaryPositionerIncrement: string                             ="00189514";
    export var SecondaryPositionerIncrement: string                           ="00189515";
    export var StartAcquisitionDateTime: string                               ="00189516";
    export var EndAcquisitionDateTime: string                                 ="00189517";
    export var PrimaryPositionerIncrementSign: string                         ="00189518";
    export var SecondaryPositionerIncrementSign: string                       ="00189519";
    export var ApplicationName: string                                        ="00189524";
    export var ApplicationVersion: string                                     ="00189525";
    export var ApplicationManufacturer: string                                ="00189526";
    export var AlgorithmType: string                                          ="00189527";
    export var AlgorithmDescription: string                                   ="00189528";
    export var XRay3DReconstructionSequence: string                           ="00189530";
    export var ReconstructionDescription: string                              ="00189531";
    export var PerProjectionAcquisitionSequence: string                       ="00189538";
    export var DetectorPositionSequence: string                               ="00189541";
    export var XRayAcquisitionDoseSequence: string                            ="00189542";
    export var XRaySourceIsocenterPrimaryAngle: string                        ="00189543";
    export var XRaySourceIsocenterSecondaryAngle: string                      ="00189544";
    export var BreastSupportIsocenterPrimaryAngle: string                     ="00189545";
    export var BreastSupportIsocenterSecondaryAngle: string                   ="00189546";
    export var BreastSupportXPositionToIsocenter: string                      ="00189547";
    export var BreastSupportYPositionToIsocenter: string                      ="00189548";
    export var BreastSupportZPositionToIsocenter: string                      ="00189549";
    export var DetectorIsocenterPrimaryAngle: string                          ="00189550";
    export var DetectorIsocenterSecondaryAngle: string                        ="00189551";
    export var DetectorXPositionToIsocenter: string                           ="00189552";
    export var DetectorYPositionToIsocenter: string                           ="00189553";
    export var DetectorZPositionToIsocenter: string                           ="00189554";
    export var XRayGridSequence: string                                       ="00189555";
    export var XRayFilterSequence: string                                     ="00189556";
    export var DetectorActiveAreaTLHCPosition: string                         ="00189557";
    export var DetectorActiveAreaOrientation: string                          ="00189558";
    export var PositionerPrimaryAngleDirection: string                        ="00189559";
    export var DiffusionBMatrixSequence: string                               ="00189601";
    export var DiffusionBValueXX: string                                      ="00189602";
    export var DiffusionBValueXY: string                                      ="00189603";
    export var DiffusionBValueXZ: string                                      ="00189604";
    export var DiffusionBValueYY: string                                      ="00189605";
    export var DiffusionBValueYZ: string                                      ="00189606";
    export var DiffusionBValueZZ: string                                      ="00189607";
    export var DecayCorrectionDateTime: string                                ="00189701";
    export var StartDensityThreshold: string                                  ="00189715";
    export var StartRelativeDensityDifferenceThreshold: string                ="00189716";
    export var StartCardiacTriggerCountThreshold: string                      ="00189717";
    export var StartRespiratoryTriggerCountThreshold: string                  ="00189718";
    export var TerminationCountsThreshold: string                             ="00189719";
    export var TerminationDensityThreshold: string                            ="00189720";
    export var TerminationRelativeDensityThreshold: string                    ="00189721";
    export var TerminationTimeThreshold: string                               ="00189722";
    export var TerminationCardiacTriggerCountThreshold: string                ="00189723";
    export var TerminationRespiratoryTriggerCountThreshold: string            ="00189724";
    export var DetectorGeometry: string                                       ="00189725";
    export var TransverseDetectorSeparation: string                           ="00189726";
    export var AxialDetectorDimension: string                                 ="00189727";
    export var RadiopharmaceuticalAgentNumber: string                         ="00189729";
    export var PETFrameAcquisitionSequence: string                            ="00189732";
    export var PETDetectorMotionDetailsSequence: string                       ="00189733";
    export var PETTableDynamicsSequence: string                               ="00189734";
    export var PETPositionSequence: string                                    ="00189735";
    export var PETFrameCorrectionFactorsSequence: string                      ="00189736";
    export var RadiopharmaceuticalUsageSequence: string                       ="00189737";
    export var AttenuationCorrectionSource: string                            ="00189738";
    export var NumberOfIterations: string                                     ="00189739";
    export var NumberOfSubsets: string                                        ="00189740";
    export var PETReconstructionSequence: string                              ="00189749";
    export var PETFrameTypeSequence: string                                   ="00189751";
    export var TimeOfFlightInformationUsed: string                            ="00189755";
    export var ReconstructionType: string                                     ="00189756";
    export var DecayCorrected: string                                         ="00189758";
    export var AttenuationCorrected: string                                   ="00189759";
    export var ScatterCorrected: string                                       ="00189760";
    export var DeadTimeCorrected: string                                      ="00189761";
    export var GantryMotionCorrected: string                                  ="00189762";
    export var PatientMotionCorrected: string                                 ="00189763";
    export var CountLossNormalizationCorrected: string                        ="00189764";
    export var RandomsCorrected: string                                       ="00189765";
    export var NonUniformRadialSamplingCorrected: string                      ="00189766";
    export var SensitivityCalibrated: string                                  ="00189767";
    export var DetectorNormalizationCorrection: string                        ="00189768";
    export var IterativeReconstructionMethod: string                          ="00189769";
    export var AttenuationCorrectionTemporalRelationship: string              ="00189770";
    export var PatientPhysiologicalStateSequence: string                      ="00189771";
    export var PatientPhysiologicalStateCodeSequence: string                  ="00189772";
    export var DepthOfFocus: string                                           ="00189801";
    export var ExcludedIntervalsSequence: string                              ="00189803";
    export var ExclusionStartDateTime: string                                 ="00189804";
    export var ExclusionDuration: string                                      ="00189805";
    export var USImageDescriptionSequence: string                             ="00189806";
    export var ImageDataTypeSequence: string                                  ="00189807";
    export var DataType: string                                               ="00189808";
    export var TransducerScanPatternCodeSequence: string                      ="00189809";
    export var AliasedDataType: string                                        ="0018980B";
    export var PositionMeasuringDeviceUsed: string                            ="0018980C";
    export var TransducerGeometryCodeSequence: string                         ="0018980D";
    export var TransducerBeamSteeringCodeSequence: string                     ="0018980E";
    export var TransducerApplicationCodeSequence: string                      ="0018980F";
    export var ZeroVelocityPixelValue: string                                 ="00189810";
    export var ContributingEquipmentSequence: string                          ="0018A001";
    export var ContributionDateTime: string                                   ="0018A002";
    export var ContributionDescription: string                                ="0018A003";

// *****************************************************************************************************************************
// *** 0020
// *****************************************************************************************************************************
    export var StudyInstanceUID: string                                       ="0020000D";
    export var SeriesInstanceUID: string                                      ="0020000E";
    export var StudyID: string                                                ="00200010";
    export var SeriesNumber: string                                           ="00200011";
    export var AcquisitionNumber: string                                      ="00200012";
    export var InstanceNumber: string                                         ="00200013";
    export var IsotopeNumber: string                                          ="00200014";   // Retired
    export var PhaseNumber: string                                            ="00200015";   // Retired
    export var IntervalNumber: string                                         ="00200016";   // Retired
    export var TimeSlotNumber: string                                         ="00200017";   // Retired
    export var AngleNumber: string                                            ="00200018";   // Retired
    export var ItemNumber: string                                             ="00200019";
    export var PatientOrientation: string                                     ="00200020";
    export var OverlayNumber: string                                          ="00200022";   // Retired
    export var CurveNumber: string                                            ="00200024";   // Retired
    export var LUTNumber: string                                              ="00200026";   // Retired
    export var ImagePosition: string                                          ="00200030";   // Retired
    export var ImagePositionPatient: string                                   ="00200032";
    export var ImageOrientation: string                                       ="00200035";   // Retired
    export var ImageOrientationPatient: string                                ="00200037";
    export var Location: string                                               ="00200050";   // Retired
    export var FrameOfReferenceUID: string                                    ="00200052";
    export var Laterality: string                                             ="00200060";
    export var ImageLaterality: string                                        ="00200062";
    export var ImageGeometryType: string                                      ="00200070";   // Retired
    export var MaskingImage: string                                           ="00200080";   // Retired
    export var ReportNumber: string                                           ="002000AA";   // Retired
    export var TemporalPositionIdentifier: string                             ="00200100";
    export var NumberOfTemporalPositions: string                              ="00200105";
    export var TemporalResolution: string                                     ="00200110";
    export var SynchronizationFrameOfReferenceUID: string                     ="00200200";
    export var SOPInstanceUIDOfConcatenationSource: string                    ="00200242";
    export var SeriesInStudy: string                                          ="00201000";   // Retired
    export var AcquisitionsInSeries: string                                   ="00201001";   // Retired
    export var ImagesInAcquisition: string                                    ="00201002";
    export var ImagesInSeries: string                                         ="00201003";   // Retired
    export var AcquisitionsInStudy: string                                    ="00201004";   // Retired
    export var ImagesInStudy: string                                          ="00201005";   // Retired
    export var Reference: string                                              ="00201020";   // Retired
    export var PositionReferenceIndicator: string                             ="00201040";
    export var SliceLocation: string                                          ="00201041";
    export var OtherStudyNumbers: string                                      ="00201070";   // Retired
    export var NumberOfPatientRelatedStudies: string                          ="00201200";
    export var NumberOfPatientRelatedSeries: string                           ="00201202";
    export var NumberOfPatientRelatedInstances: string                        ="00201204";
    export var NumberOfStudyRelatedSeries: string                             ="00201206";
    export var NumberOfStudyRelatedInstances: string                          ="00201208";
    export var NumberOfSeriesRelatedInstances: string                         ="00201209";
    export var SourceImageIDs: string                                         ="00203100";   // Retired
    export var ModifyingDeviceID: string                                      ="00203401";   // Retired
    export var ModifiedImageID: string                                        ="00203402";   // Retired
    export var ModifiedImageDate: string                                      ="00203403";   // Retired
    export var ModifyingDeviceManufacturer: string                            ="00203404";   // Retired
    export var ModifiedImageTime: string                                      ="00203405";   // Retired
    export var ModifiedImageDescription: string                               ="00203406";   // Retired
    export var ImageComments: string                                          ="00204000";
    export var OriginalImageIdentification: string                            ="00205000";   // Retired
    export var OriginalImageIdentificationNomenclature: string                ="00205002";   // Retired
    export var StackID: string                                                ="00209056";
    export var InStackPositionNumber: string                                  ="00209057";
    export var FrameAnatomySequence: string                                   ="00209071";
    export var FrameLaterality: string                                        ="00209072";
    export var FrameContentSequence: string                                   ="00209111";
    export var PlanePositionSequence: string                                  ="00209113";
    export var PlaneOrientationSequence: string                               ="00209116";
    export var TemporalPositionIndex: string                                  ="00209128";
    export var NominalCardiacTriggerDelayTime: string                         ="00209153";
    export var NominalCardiacTriggerTimePriorToRPeak: string                  ="00209154";
    export var ActualCardiacTriggerTimePriorToRPeak: string                   ="00209155";
    export var FrameAcquisitionNumber: string                                 ="00209156";
    export var DimensionIndexValues: string                                   ="00209157";
    export var FrameComments: string                                          ="00209158";
    export var ConcatenationUID: string                                       ="00209161";
    export var InConcatenationNumber: string                                  ="00209162";
    export var InConcatenationTotalNumber: string                             ="00209163";
    export var DimensionOrganizationUID: string                               ="00209164";
    export var DimensionIndexPointer: string                                  ="00209165";
    export var FunctionalGroupPointer: string                                 ="00209167";
    export var UnassignedSharedConvertedAttributesSequence: string            ="00209170";
    export var UnassignedPerFrameConvertedAttributesSequence: string          ="00209171";
    export var ConversionSourceAttributesSequence: string                     ="00209172";
    export var DimensionIndexPrivateCreator: string                           ="00209213";
    export var DimensionOrganizationSequence: string                          ="00209221";
    export var DimensionIndexSequence: string                                 ="00209222";
    export var ConcatenationFrameOffsetNumber: string                         ="00209228";
    export var FunctionalGroupPrivateCreator: string                          ="00209238";
    export var NominalPercentageOfCardiacPhase: string                        ="00209241";
    export var NominalPercentageOfRespiratoryPhase: string                    ="00209245";
    export var StartingRespiratoryAmplitude: string                           ="00209246";
    export var StartingRespiratoryPhase: string                               ="00209247";
    export var EndingRespiratoryAmplitude: string                             ="00209248";
    export var EndingRespiratoryPhase: string                                 ="00209249";
    export var RespiratoryTriggerType: string                                 ="00209250";
    export var RRIntervalTimeNominal: string                                  ="00209251";
    export var ActualCardiacTriggerDelayTime: string                          ="00209252";
    export var RespiratorySynchronizationSequence: string                     ="00209253";
    export var RespiratoryIntervalTime: string                                ="00209254";
    export var NominalRespiratoryTriggerDelayTime: string                     ="00209255";
    export var RespiratoryTriggerDelayThreshold: string                       ="00209256";
    export var ActualRespiratoryTriggerDelayTime: string                      ="00209257";
    export var ImagePositionVolume: string                                    ="00209301";
    export var ImageOrientationVolume: string                                 ="00209302";
    export var UltrasoundAcquisitionGeometry: string                          ="00209307";
    export var ApexPosition: string                                           ="00209308";
    export var VolumeToTransducerMappingMatrix: string                        ="00209309";
    export var VolumeToTableMappingMatrix: string                             ="0020930A";
    export var VolumeToTransducerRelationship: string                         ="0020930B";
    export var PatientFrameOfReferenceSource: string                          ="0020930C";
    export var TemporalPositionTimeOffset: string                             ="0020930D";
    export var PlanePositionVolumeSequence: string                            ="0020930E";
    export var PlaneOrientationVolumeSequence: string                         ="0020930F";
    export var TemporalPositionSequence: string                               ="00209310";
    export var DimensionOrganizationType: string                              ="00209311";
    export var VolumeFrameOfReferenceUID: string                              ="00209312";
    export var TableFrameOfReferenceUID: string                               ="00209313";
    export var DimensionDescriptionLabel: string                              ="00209421";
    export var PatientOrientationInFrameSequence: string                      ="00209450";
    export var FrameLabel: string                                             ="00209453";
    export var AcquisitionIndex: string                                       ="00209518";
    export var ContributingSOPInstancesReferenceSequence: string              ="00209529";
    export var ReconstructionIndex: string                                    ="00209536";

// *****************************************************************************************************************************
// *** 0022
// *****************************************************************************************************************************
    export var LightPathFilterPassThroughWavelength: string                   ="00220001";
    export var LightPathFilterPassBand: string                                ="00220002";
    export var ImagePathFilterPassThroughWavelength: string                   ="00220003";
    export var ImagePathFilterPassBand: string                                ="00220004";
    export var PatientEyeMovementCommanded: string                            ="00220005";
    export var PatientEyeMovementCommandCodeSequence: string                  ="00220006";
    export var SphericalLensPower: string                                     ="00220007";
    export var CylinderLensPower: string                                      ="00220008";
    export var CylinderAxis: string                                           ="00220009";
    export var EmmetropicMagnification: string                                ="0022000A";
    export var IntraOcularPressure: string                                    ="0022000B";
    export var HorizontalFieldOfView: string                                  ="0022000C";
    export var PupilDilated: string                                           ="0022000D";
    export var DegreeOfDilation: string                                       ="0022000E";
    export var StereoBaselineAngle: string                                    ="00220010";
    export var StereoBaselineDisplacement: string                             ="00220011";
    export var StereoHorizontalPixelOffset: string                            ="00220012";
    export var StereoVerticalPixelOffset: string                              ="00220013";
    export var StereoRotation: string                                         ="00220014";
    export var AcquisitionDeviceTypeCodeSequence: string                      ="00220015";
    export var IlluminationTypeCodeSequence: string                           ="00220016";
    export var LightPathFilterTypeStackCodeSequence: string                   ="00220017";
    export var ImagePathFilterTypeStackCodeSequence: string                   ="00220018";
    export var LensesCodeSequence: string                                     ="00220019";
    export var ChannelDescriptionCodeSequence: string                         ="0022001A";
    export var RefractiveStateSequence: string                                ="0022001B";
    export var MydriaticAgentCodeSequence: string                             ="0022001C";
    export var RelativeImagePositionCodeSequence: string                      ="0022001D";
    export var CameraAngleOfView: string                                      ="0022001E";
    export var StereoPairsSequence: string                                    ="00220020";
    export var LeftImageSequence: string                                      ="00220021";
    export var RightImageSequence: string                                     ="00220022";
    export var StereoPairsPresent: string                                     ="00220028";
    export var AxialLengthOfTheEye: string                                    ="00220030";
    export var OphthalmicFrameLocationSequence: string                        ="00220031";
    export var ReferenceCoordinates: string                                   ="00220032";
    export var DepthSpatialResolution: string                                 ="00220035";
    export var MaximumDepthDistortion: string                                 ="00220036";
    export var AlongScanSpatialResolution: string                             ="00220037";
    export var MaximumAlongScanDistortion: string                             ="00220038";
    export var OphthalmicImageOrientation: string                             ="00220039";
    export var DepthOfTransverseImage: string                                 ="00220041";
    export var MydriaticAgentConcentrationUnitsSequence: string               ="00220042";
    export var AcrossScanSpatialResolution: string                            ="00220048";
    export var MaximumAcrossScanDistortion: string                            ="00220049";
    export var MydriaticAgentConcentration: string                            ="0022004E";
    export var IlluminationWaveLength: string                                 ="00220055";
    export var IlluminationPower: string                                      ="00220056";
    export var IlluminationBandwidth: string                                  ="00220057";
    export var MydriaticAgentSequence: string                                 ="00220058";
    export var OphthalmicAxialMeasurementsRightEyeSequence: string            ="00221007";
    export var OphthalmicAxialMeasurementsLeftEyeSequence: string             ="00221008";
    export var OphthalmicAxialMeasurementsDeviceType: string                  ="00221009";
    export var OphthalmicAxialLengthMeasurementsType: string                  ="00221010";
    export var OphthalmicAxialLengthSequence: string                          ="00221012";
    export var OphthalmicAxialLength: string                                  ="00221019";
    export var LensStatusCodeSequence: string                                 ="00221024";
    export var VitreousStatusCodeSequence: string                             ="00221025";
    export var IOLFormulaCodeSequence: string                                 ="00221028";
    export var IOLFormulaDetail: string                                       ="00221029";
    export var KeratometerIndex: string                                       ="00221033";
    export var SourceOfOphthalmicAxialLengthCodeSequence: string              ="00221035";
    export var TargetRefraction: string                                       ="00221037";
    export var RefractiveProcedureOccurred: string                            ="00221039";
    export var RefractiveSurgeryTypeCodeSequence: string                      ="00221040";
    export var OphthalmicUltrasoundMethodCodeSequence: string                 ="00221044";
    export var OphthalmicAxialLengthMeasurementsSequence: string              ="00221050";
    export var IOLPower: string                                               ="00221053";
    export var PredictedRefractiveError: string                               ="00221054";
    export var OphthalmicAxialLengthVelocity: string                          ="00221059";
    export var LensStatusDescription: string                                  ="00221065";
    export var VitreousStatusDescription: string                              ="00221066";
    export var IOLPowerSequence: string                                       ="00221090";
    export var LensConstantSequence: string                                   ="00221092";
    export var IOLManufacturer: string                                        ="00221093";
    export var LensConstantDescription: string                                ="00221094";   // Retired
    export var ImplantName: string                                            ="00221095";
    export var KeratometryMeasurementTypeCodeSequence: string                 ="00221096";
    export var ImplantPartNumber: string                                      ="00221097";
    export var ReferencedOphthalmicAxialMeasurementsSequence: string          ="00221100";
    export var OphthalmicAxialLengthMeasurementsSegmentNameCodeSequence: string ="00221101";
    export var RefractiveErrorBeforeRefractiveSurgeryCodeSequence: string     ="00221103";
    export var IOLPowerForExactEmmetropia: string                             ="00221121";
    export var IOLPowerForExactTargetRefraction: string                       ="00221122";
    export var AnteriorChamberDepthDefinitionCodeSequence: string             ="00221125";
    export var LensThicknessSequence: string                                  ="00221127";
    export var AnteriorChamberDepthSequence: string                           ="00221128";
    export var LensThickness: string                                          ="00221130";
    export var AnteriorChamberDepth: string                                   ="00221131";
    export var SourceOfLensThicknessDataCodeSequence: string                  ="00221132";
    export var SourceOfAnteriorChamberDepthDataCodeSequence: string           ="00221133";
    export var SourceOfRefractiveMeasurementsSequence: string                 ="00221134";
    export var SourceOfRefractiveMeasurementsCodeSequence: string             ="00221135";
    export var OphthalmicAxialLengthMeasurementModified: string               ="00221140";
    export var OphthalmicAxialLengthDataSourceCodeSequence: string            ="00221150";
    export var OphthalmicAxialLengthAcquisitionMethodCodeSequence: string     ="00221153";   // Retired
    export var SignalToNoiseRatio: string                                     ="00221155";
    export var OphthalmicAxialLengthDataSourceDescription: string             ="00221159";
    export var OphthalmicAxialLengthMeasurementsTotalLengthSequence: string   ="00221210";
    export var OphthalmicAxialLengthMeasurementsSegmentalLengthSequence: string ="00221211";
    export var OphthalmicAxialLengthMeasurementsLengthSummationSequence: string ="00221212";
    export var UltrasoundOphthalmicAxialLengthMeasurementsSequence: string    ="00221220";
    export var OpticalOphthalmicAxialLengthMeasurementsSequence: string       ="00221225";
    export var UltrasoundSelectedOphthalmicAxialLengthSequence: string        ="00221230";
    export var OphthalmicAxialLengthSelectionMethodCodeSequence: string       ="00221250";
    export var OpticalSelectedOphthalmicAxialLengthSequence: string           ="00221255";
    export var SelectedSegmentalOphthalmicAxialLengthSequence: string         ="00221257";
    export var SelectedTotalOphthalmicAxialLengthSequence: string             ="00221260";
    export var OphthalmicAxialLengthQualityMetricSequence: string             ="00221262";
    export var OphthalmicAxialLengthQualityMetricTypeCodeSequence: string     ="00221265";   // Retired
    export var OphthalmicAxialLengthQualityMetricTypeDescription: string      ="00221273";   // Retired
    export var IntraocularLensCalculationsRightEyeSequence: string            ="00221300";
    export var IntraocularLensCalculationsLeftEyeSequence: string             ="00221310";
    export var ReferencedOphthalmicAxialLengthMeasurementQCImageSequence: string ="00221330";
    export var OphthalmicMappingDeviceType: string                            ="00221415";
    export var AcquisitionMethodCodeSequence: string                          ="00221420";
    export var AcquisitionMethodAlgorithmSequence: string                     ="00221423";
    export var OphthalmicThicknessMapTypeCodeSequence: string                 ="00221436";
    export var OphthalmicThicknessMappingNormalsSequence: string              ="00221443";
    export var RetinalThicknessDefinitionCodeSequence: string                 ="00221445";
    export var PixelValueMappingToCodedConceptSequence: string                ="00221450";
    export var MappedPixelValue: string                                       ="00221452";
    export var PixelValueMappingExplanation: string                           ="00221454";
    export var OphthalmicThicknessMapQualityThresholdSequence: string         ="00221458";
    export var OphthalmicThicknessMapThresholdQualityRating: string           ="00221460";
    export var AnatomicStructureReferencePoint: string                        ="00221463";
    export var RegistrationToLocalizerSequence: string                        ="00221465";
    export var RegisteredLocalizerUnits: string                               ="00221466";
    export var RegisteredLocalizerTopLeftHandCorner: string                   ="00221467";
    export var RegisteredLocalizerBottomRightHandCorner: string               ="00221468";
    export var OphthalmicThicknessMapQualityRatingSequence: string            ="00221470";
    export var RelevantOPTAttributesSequence: string                          ="00221472";
    export var TransformationMethodCodeSequence: string                       ="00221512";
    export var TransformationAlgorithmSequence: string                        ="00221513";
    export var OphthalmicAxialLengthMethod: string                            ="00221515";
    export var OphthalmicFOV: string                                          ="00221517";
    export var TwoDimensionalToThreeDimensionalMapSequence: string            ="00221518";
    export var WideFieldOphthalmicPhotographyQualityRatingSequence: string    ="00221525";
    export var WideFieldOphthalmicPhotographyQualityThresholdSequence: string ="00221526";
    export var WideFieldOphthalmicPhotographyThresholdQualityRating: string   ="00221527";
    export var XCoordinatesCenterPixelViewAngle: string                       ="00221528";
    export var YCoordinatesCenterPixelViewAngle: string                       ="00221529";
    export var NumberOfMapPoints: string                                      ="00221530";
    export var TwoDimensionalToThreeDimensionalMapData: string                ="00221531";

// *****************************************************************************************************************************
// *** 0024
// *****************************************************************************************************************************
    export var VisualFieldHorizontalExtent: string                            ="00240010";
    export var VisualFieldVerticalExtent: string                              ="00240011";
    export var VisualFieldShape: string                                       ="00240012";
    export var ScreeningTestModeCodeSequence: string                          ="00240016";
    export var MaximumStimulusLuminance: string                               ="00240018";
    export var BackgroundLuminance: string                                    ="00240020";
    export var StimulusColorCodeSequence: string                              ="00240021";
    export var BackgroundIlluminationColorCodeSequence: string                ="00240024";
    export var StimulusArea: string                                           ="00240025";
    export var StimulusPresentationTime: string                               ="00240028";
    export var FixationSequence: string                                       ="00240032";
    export var FixationMonitoringCodeSequence: string                         ="00240033";
    export var VisualFieldCatchTrialSequence: string                          ="00240034";
    export var FixationCheckedQuantity: string                                ="00240035";
    export var PatientNotProperlyFixatedQuantity: string                      ="00240036";
    export var PresentedVisualStimuliDataFlag: string                         ="00240037";
    export var NumberOfVisualStimuli: string                                  ="00240038";
    export var ExcessiveFixationLossesDataFlag: string                        ="00240039";
    export var ExcessiveFixationLosses: string                                ="00240040";
    export var StimuliRetestingQuantity: string                               ="00240042";
    export var CommentsOnPatientPerformanceOfVisualField: string              ="00240044";
    export var FalseNegativesEstimateFlag: string                             ="00240045";
    export var FalseNegativesEstimate: string                                 ="00240046";
    export var NegativeCatchTrialsQuantity: string                            ="00240048";
    export var FalseNegativesQuantity: string                                 ="00240050";
    export var ExcessiveFalseNegativesDataFlag: string                        ="00240051";
    export var ExcessiveFalseNegatives: string                                ="00240052";
    export var FalsePositivesEstimateFlag: string                             ="00240053";
    export var FalsePositivesEstimate: string                                 ="00240054";
    export var CatchTrialsDataFlag: string                                    ="00240055";
    export var PositiveCatchTrialsQuantity: string                            ="00240056";
    export var TestPointNormalsDataFlag: string                               ="00240057";
    export var TestPointNormalsSequence: string                               ="00240058";
    export var GlobalDeviationProbabilityNormalsFlag: string                  ="00240059";
    export var FalsePositivesQuantity: string                                 ="00240060";
    export var ExcessiveFalsePositivesDataFlag: string                        ="00240061";
    export var ExcessiveFalsePositives: string                                ="00240062";
    export var VisualFieldTestNormalsFlag: string                             ="00240063";
    export var ResultsNormalsSequence: string                                 ="00240064";
    export var AgeCorrectedSensitivityDeviationAlgorithmSequence: string      ="00240065";
    export var GlobalDeviationFromNormal: string                              ="00240066";
    export var GeneralizedDefectSensitivityDeviationAlgorithmSequence: string ="00240067";
    export var LocalizedDeviationFromNormal: string                           ="00240068";
    export var PatientReliabilityIndicator: string                            ="00240069";
    export var VisualFieldMeanSensitivity: string                             ="00240070";
    export var GlobalDeviationProbability: string                             ="00240071";
    export var LocalDeviationProbabilityNormalsFlag: string                   ="00240072";
    export var LocalizedDeviationProbability: string                          ="00240073";
    export var ShortTermFluctuationCalculated: string                         ="00240074";
    export var ShortTermFluctuation: string                                   ="00240075";
    export var ShortTermFluctuationProbabilityCalculated: string              ="00240076";
    export var ShortTermFluctuationProbability: string                        ="00240077";
    export var CorrectedLocalizedDeviationFromNormalCalculated: string        ="00240078";
    export var CorrectedLocalizedDeviationFromNormal: string                  ="00240079";
    export var CorrectedLocalizedDeviationFromNormalProbabilityCalculated: string ="00240080";
    export var CorrectedLocalizedDeviationFromNormalProbability: string       ="00240081";
    export var GlobalDeviationProbabilitySequence: string                     ="00240083";
    export var LocalizedDeviationProbabilitySequence: string                  ="00240085";
    export var FovealSensitivityMeasured: string                              ="00240086";
    export var FovealSensitivity: string                                      ="00240087";
    export var VisualFieldTestDuration: string                                ="00240088";
    export var VisualFieldTestPointSequence: string                           ="00240089";
    export var VisualFieldTestPointXCoordinate: string                        ="00240090";
    export var VisualFieldTestPointYCoordinate: string                        ="00240091";
    export var AgeCorrectedSensitivityDeviationValue: string                  ="00240092";
    export var StimulusResults: string                                        ="00240093";
    export var SensitivityValue: string                                       ="00240094";
    export var RetestStimulusSeen: string                                     ="00240095";
    export var RetestSensitivityValue: string                                 ="00240096";
    export var VisualFieldTestPointNormalsSequence: string                    ="00240097";
    export var QuantifiedDefect: string                                       ="00240098";
    export var AgeCorrectedSensitivityDeviationProbabilityValue: string       ="00240100";
    export var GeneralizedDefectCorrectedSensitivityDeviationFlag: string     ="00240102";
    export var GeneralizedDefectCorrectedSensitivityDeviationValue: string    ="00240103";
    export var GeneralizedDefectCorrectedSensitivityDeviationProbabilityValue: string ="00240104";
    export var MinimumSensitivityValue: string                                ="00240105";
    export var BlindSpotLocalized: string                                     ="00240106";
    export var BlindSpotXCoordinate: string                                   ="00240107";
    export var BlindSpotYCoordinate: string                                   ="00240108";
    export var VisualAcuityMeasurementSequence: string                        ="00240110";
    export var RefractiveParametersUsedOnPatientSequence: string              ="00240112";
    export var MeasurementLaterality: string                                  ="00240113";
    export var OphthalmicPatientClinicalInformationLeftEyeSequence: string    ="00240114";
    export var OphthalmicPatientClinicalInformationRightEyeSequence: string   ="00240115";
    export var FovealPointNormativeDataFlag: string                           ="00240117";
    export var FovealPointProbabilityValue: string                            ="00240118";
    export var ScreeningBaselineMeasured: string                              ="00240120";
    export var ScreeningBaselineMeasuredSequence: string                      ="00240122";
    export var ScreeningBaselineType: string                                  ="00240124";
    export var ScreeningBaselineValue: string                                 ="00240126";
    export var AlgorithmSource: string                                        ="00240202";
    export var DataSetName: string                                            ="00240306";
    export var DataSetVersion: string                                         ="00240307";
    export var DataSetSource: string                                          ="00240308";
    export var DataSetDescription: string                                     ="00240309";
    export var VisualFieldTestReliabilityGlobalIndexSequence: string          ="00240317";
    export var VisualFieldGlobalResultsIndexSequence: string                  ="00240320";
    export var DataObservationSequence: string                                ="00240325";
    export var IndexNormalsFlag: string                                       ="00240338";
    export var IndexProbability: string                                       ="00240341";
    export var IndexProbabilitySequence: string                               ="00240344";

// *****************************************************************************************************************************
// *** 0028
// *****************************************************************************************************************************
    export var SamplesPerPixel: string                                        ="00280002";
    export var SamplesPerPixelUsed: string                                    ="00280003";
    export var PhotometricInterpretation: string                              ="00280004";
    export var ImageDimensions: string                                        ="00280005";   // Retired
    export var PlanarConfiguration: string                                    ="00280006";
    export var NumberOfFrames: string                                         ="00280008";
    export var FrameIncrementPointer: string                                  ="00280009";
    export var FrameDimensionPointer: string                                  ="0028000A";
    export var Rows: string                                                   ="00280010";
    export var Columns: string                                                ="00280011";
    export var Planes: string                                                 ="00280012";   // Retired
    export var UltrasoundColorDataPresent: string                             ="00280014";
    export var PixelSpacing: string                                           ="00280030";
    export var ZoomFactor: string                                             ="00280031";
    export var ZoomCenter: string                                             ="00280032";
    export var PixelAspectRatio: string                                       ="00280034";
    export var ImageFormat: string                                            ="00280040";   // Retired
    export var ManipulatedImage: string                                       ="00280050";   // Retired
    export var CorrectedImage: string                                         ="00280051";
    export var CompressionRecognitionCode: string                             ="0028005F";   // Retired
    export var CompressionCode: string                                        ="00280060";   // Retired
    export var CompressionOriginator: string                                  ="00280061";   // Retired
    export var CompressionLabel: string                                       ="00280062";   // Retired
    export var CompressionDescription: string                                 ="00280063";   // Retired
    export var CompressionSequence: string                                    ="00280065";   // Retired
    export var CompressionStepPointers: string                                ="00280066";   // Retired
    export var RepeatInterval: string                                         ="00280068";   // Retired
    export var BitsGrouped: string                                            ="00280069";   // Retired
    export var PerimeterTable: string                                         ="00280070";   // Retired
    export var PerimeterValue: string                                         ="00280071";   // Retired
    export var PredictorRows: string                                          ="00280080";   // Retired
    export var PredictorColumns: string                                       ="00280081";   // Retired
    export var PredictorConstants: string                                     ="00280082";   // Retired
    export var BlockedPixels: string                                          ="00280090";   // Retired
    export var BlockRows: string                                              ="00280091";   // Retired
    export var BlockColumns: string                                           ="00280092";   // Retired
    export var RowOverlap: string                                             ="00280093";   // Retired
    export var ColumnOverlap: string                                          ="00280094";   // Retired
    export var BitsAllocated: string                                          ="00280100";
    export var BitsStored: string                                             ="00280101";
    export var HighBit: string                                                ="00280102";
    export var PixelRepresentation: string                                    ="00280103";
    export var SmallestValidPixelValue: string                                ="00280104";   // Retired
    export var LargestValidPixelValue: string                                 ="00280105";   // Retired
    export var SmallestImagePixelValue: string                                ="00280106";
    export var LargestImagePixelValue: string                                 ="00280107";
    export var SmallestPixelValueInSeries: string                             ="00280108";
    export var LargestPixelValueInSeries: string                              ="00280109";
    export var SmallestImagePixelValueInPlane: string                         ="00280110";   // Retired
    export var LargestImagePixelValueInPlane: string                          ="00280111";   // Retired
    export var PixelPaddingValue: string                                      ="00280120";
    export var PixelPaddingRangeLimit: string                                 ="00280121";
    export var FloatPixelPaddingValue: string                                 ="00280122";
    export var DoubleFloatPixelPaddingValue: string                           ="00280123";
    export var FloatPixelPaddingRangeLimit: string                            ="00280124";
    export var DoubleFloatPixelPaddingRangeLimit: string                      ="00280125";
    export var ImageLocation: string                                          ="00280200";   // Retired
    export var QualityControlImage: string                                    ="00280300";
    export var BurnedInAnnotation: string                                     ="00280301";
    export var RecognizableVisualFeatures: string                             ="00280302";
    export var LongitudinalTemporalInformationModified: string                ="00280303";
    export var ReferencedColorPaletteInstanceUID: string                      ="00280304";
    export var TransformLabel: string                                         ="00280400";   // Retired
    export var TransformVersionNumber: string                                 ="00280401";   // Retired
    export var NumberOfTransformSteps: string                                 ="00280402";   // Retired
    export var SequenceOfCompressedData: string                               ="00280403";   // Retired
    export var DetailsOfCoefficients: string                                  ="00280404";   // Retired
    export var RowsForNthOrderCoefficients: string                            ="00280400";   // Retired
    export var ColumnsForNthOrderCoefficients: string                         ="00280401";   // Retired
    export var CoefficientCoding: string                                      ="00280402";   // Retired
    export var CoefficientCodingPointers: string                              ="00280403";   // Retired
    export var DCTLabel: string                                               ="00280700";   // Retired
    export var DataBlockDescription: string                                   ="00280701";   // Retired
    export var DataBlock: string                                              ="00280702";   // Retired
    export var NormalizationFactorFormat: string                              ="00280710";   // Retired
    export var ZonalMapNumberFormat: string                                   ="00280720";   // Retired
    export var ZonalMapLocation: string                                       ="00280721";   // Retired
    export var ZonalMapFormat: string                                         ="00280722";   // Retired
    export var AdaptiveMapFormat: string                                      ="00280730";   // Retired
    export var CodeNumberFormat: string                                       ="00280740";   // Retired
    export var CodeLabel: string                                              ="00280800";   // Retired
    export var NumberOfTables: string                                         ="00280802";   // Retired
    export var CodeTableLocation: string                                      ="00280803";   // Retired
    export var BitsForCodeWord: string                                        ="00280804";   // Retired
    export var ImageDataLocation: string                                      ="00280808";   // Retired
    export var PixelSpacingCalibrationType: string                            ="00280A02";
    export var PixelSpacingCalibrationDescription: string                     ="00280A04";
    export var PixelIntensityRelationship: string                             ="00281040";
    export var PixelIntensityRelationshipSign: string                         ="00281041";
    export var WindowCenter: string                                           ="00281050";
    export var WindowWidth: string                                            ="00281051";
    export var RescaleIntercept: string                                       ="00281052";
    export var RescaleSlope: string                                           ="00281053";
    export var RescaleType: string                                            ="00281054";
    export var WindowCenterWidthExplanation: string                           ="00281055";
    export var VOILUTFunction: string                                         ="00281056";
    export var GrayScale: string                                              ="00281080";   // Retired
    export var RecommendedViewingMode: string                                 ="00281090";
    export var GrayLookupTableDescriptor: string                              ="00281100";   // Retired
    export var RedPaletteColorLookupTableDescriptor: string                   ="00281101";
    export var GreenPaletteColorLookupTableDescriptor: string                 ="00281102";
    export var BluePaletteColorLookupTableDescriptor: string                  ="00281103";
    export var AlphaPaletteColorLookupTableDescriptor: string                 ="00281104";
    export var LargeRedPaletteColorLookupTableDescriptor: string              ="00281111";   // Retired
    export var LargeGreenPaletteColorLookupTableDescriptor: string            ="00281112";   // Retired
    export var LargeBluePaletteColorLookupTableDescriptor: string             ="00281113";   // Retired
    export var PaletteColorLookupTableUID: string                             ="00281199";
    export var GrayLookupTableData: string                                    ="00281200";   // Retired
    export var RedPaletteColorLookupTableData: string                         ="00281201";
    export var GreenPaletteColorLookupTableData: string                       ="00281202";
    export var BluePaletteColorLookupTableData: string                        ="00281203";
    export var AlphaPaletteColorLookupTableData: string                       ="00281204";
    export var LargeRedPaletteColorLookupTableData: string                    ="00281211";   // Retired
    export var LargeGreenPaletteColorLookupTableData: string                  ="00281212";   // Retired
    export var LargeBluePaletteColorLookupTableData: string                   ="00281213";   // Retired
    export var LargePaletteColorLookupTableUID: string                        ="00281214";   // Retired
    export var SegmentedRedPaletteColorLookupTableData: string                ="00281221";
    export var SegmentedGreenPaletteColorLookupTableData: string              ="00281222";
    export var SegmentedBluePaletteColorLookupTableData: string               ="00281223";
    export var BreastImplantPresent: string                                   ="00281300";
    export var PartialView: string                                            ="00281350";
    export var PartialViewDescription: string                                 ="00281351";
    export var PartialViewCodeSequence: string                                ="00281352";
    export var SpatialLocationsPreserved: string                              ="0028135A";
    export var DataFrameAssignmentSequence: string                            ="00281401";
    export var DataPathAssignment: string                                     ="00281402";
    export var BitsMappedToColorLookupTable: string                           ="00281403";
    export var BlendingLUT1Sequence: string                                   ="00281404";
    export var BlendingLUT1TransferFunction: string                           ="00281405";
    export var BlendingWeightConstant: string                                 ="00281406";
    export var BlendingLookupTableDescriptor: string                          ="00281407";
    export var BlendingLookupTableData: string                                ="00281408";
    export var EnhancedPaletteColorLookupTableSequence: string                ="0028140B";
    export var BlendingLUT2Sequence: string                                   ="0028140C";
    export var BlendingLUT2TransferFunction: string                           ="0028140D";
    export var DataPathID: string                                             ="0028140E";
    export var RGBLUTTransferFunction: string                                 ="0028140F";
    export var AlphaLUTTransferFunction: string                               ="00281410";
    export var ICCProfile: string                                             ="00282000";
    export var LossyImageCompression: string                                  ="00282110";
    export var LossyImageCompressionRatio: string                             ="00282112";
    export var LossyImageCompressionMethod: string                            ="00282114";
    export var ModalityLUTSequence: string                                    ="00283000";
    export var LUTDescriptor: string                                          ="00283002";
    export var LUTExplanation: string                                         ="00283003";
    export var ModalityLUTType: string                                        ="00283004";
    export var LUTData: string                                                ="00283006";
    export var VOILUTSequence: string                                         ="00283010";
    export var SoftcopyVOILUTSequence: string                                 ="00283110";
    export var ImagePresentationComments: string                              ="00284000";   // Retired
    export var BiPlaneAcquisitionSequence: string                             ="00285000";   // Retired
    export var RepresentativeFrameNumber: string                              ="00286010";
    export var FrameNumbersOfInterestFOI: string                              ="00286020";
    export var FrameOfInterestDescription: string                             ="00286022";
    export var FrameOfInterestType: string                                    ="00286023";
    export var MaskPointer: string                                            ="00286030";   // Retired
    export var RWavePointer: string                                           ="00286040";
    export var MaskSubtractionSequence: string                                ="00286100";
    export var MaskOperation: string                                          ="00286101";
    export var ApplicableFrameRange: string                                   ="00286102";
    export var MaskFrameNumbers: string                                       ="00286110";
    export var ContrastFrameAveraging: string                                 ="00286112";
    export var MaskSubPixelShift: string                                      ="00286114";
    export var TIDOffset: string                                              ="00286120";
    export var MaskOperationExplanation: string                               ="00286190";
    export var EquipmentAdministratorSequence: string                         ="00287000";
    export var NumberOfDisplaySubsystems: string                              ="00287001";
    export var CurrentConfigurationID: string                                 ="00287002";
    export var DisplaySubsystemID: string                                     ="00287003";
    export var DisplaySubsystemName: string                                   ="00287004";
    export var DisplaySubsystemDescription: string                            ="00287005";
    export var SystemStatus: string                                           ="00287006";
    export var SystemStatusComment: string                                    ="00287007";
    export var TargetLuminanceCharacteristicsSequence: string                 ="00287008";
    export var LuminanceCharacteristicsID: string                             ="00287009";
    export var DisplaySubsystemConfigurationSequence: string                  ="0028700A";
    export var ConfigurationID: string                                        ="0028700B";
    export var ConfigurationName: string                                      ="0028700C";
    export var ConfigurationDescription: string                               ="0028700D";
    export var ReferencedTargetLuminanceCharacteristicsID: string             ="0028700E";
    export var QAResultsSequence: string                                      ="0028700F";
    export var DisplaySubsystemQAResultsSequence: string                      ="00287010";
    export var ConfigurationQAResultsSequence: string                         ="00287011";
    export var MeasurementEquipmentSequence: string                           ="00287012";
    export var MeasurementFunctions: string                                   ="00287013";
    export var MeasurementEquipmentType: string                               ="00287014";
    export var VisualEvaluationResultSequence: string                         ="00287015";
    export var DisplayCalibrationResultSequence: string                       ="00287016";
    export var DDLValue: string                                               ="00287017";
    export var CIExyWhitePoint: string                                        ="00287018";
    export var DisplayFunctionType: string                                    ="00287019";
    export var GammaValue: string                                             ="0028701A";
    export var NumberOfLuminancePoints: string                                ="0028701B";
    export var LuminanceResponseSequence: string                              ="0028701C";
    export var TargetMinimumLuminance: string                                 ="0028701D";
    export var TargetMaximumLuminance: string                                 ="0028701E";
    export var LuminanceValue: string                                         ="0028701F";
    export var LuminanceResponseDescription: string                           ="00287020";
    export var WhitePointFlag: string                                         ="00287021";
    export var DisplayDeviceTypeCodeSequence: string                          ="00287022";
    export var DisplaySubsystemSequence: string                               ="00287023";
    export var LuminanceResultSequence: string                                ="00287024";
    export var AmbientLightValueSource: string                                ="00287025";
    export var MeasuredCharacteristics: string                                ="00287026";
    export var LuminanceUniformityResultSequence: string                      ="00287027";
    export var VisualEvaluationTestSequence: string                           ="00287028";
    export var TestResult: string                                             ="00287029";
    export var TestResultComment: string                                      ="0028702A";
    export var TestImageValidation: string                                    ="0028702B";
    export var TestPatternCodeSequence: string                                ="0028702C";
    export var MeasurementPatternCodeSequence: string                         ="0028702D";
    export var VisualEvaluationMethodCodeSequence: string                     ="0028702E";
    export var PixelDataProviderURL: string                                   ="00287FE0";
    export var DataPointRows: string                                          ="00289001";
    export var DataPointColumns: string                                       ="00289002";
    export var SignalDomainColumns: string                                    ="00289003";
    export var LargestMonochromePixelValue: string                            ="00289099";   // Retired
    export var DataRepresentation: string                                     ="00289108";
    export var PixelMeasuresSequence: string                                  ="00289110";
    export var FrameVOILUTSequence: string                                    ="00289132";
    export var PixelValueTransformationSequence: string                       ="00289145";
    export var SignalDomainRows: string                                       ="00289235";
    export var DisplayFilterPercentage: string                                ="00289411";
    export var FramePixelShiftSequence: string                                ="00289415";
    export var SubtractionItemID: string                                      ="00289416";
    export var PixelIntensityRelationshipLUTSequence: string                  ="00289422";
    export var FramePixelDataPropertiesSequence: string                       ="00289443";
    export var GeometricalProperties: string                                  ="00289444";
    export var GeometricMaximumDistortion: string                             ="00289445";
    export var ImageProcessingApplied: string                                 ="00289446";
    export var MaskSelectionMode: string                                      ="00289454";
    export var LUTFunction: string                                            ="00289474";
    export var MaskVisibilityPercentage: string                               ="00289478";
    export var PixelShiftSequence: string                                     ="00289501";
    export var RegionPixelShiftSequence: string                               ="00289502";
    export var VerticesOfTheRegion: string                                    ="00289503";
    export var MultiFramePresentationSequence: string                         ="00289505";
    export var PixelShiftFrameRange: string                                   ="00289506";
    export var LUTFrameRange: string                                          ="00289507";
    export var ImageToEquipmentMappingMatrix: string                          ="00289520";
    export var EquipmentCoordinateSystemIdentification: string                ="00289537";

// *****************************************************************************************************************************
// *** 0032
// *****************************************************************************************************************************
    export var StudyStatusID: string                                          ="0032000A";   // Retired
    export var StudyPriorityID: string                                        ="0032000C";   // Retired
    export var StudyIDIssuer: string                                          ="00320012";   // Retired
    export var StudyVerifiedDate: string                                      ="00320032";   // Retired
    export var StudyVerifiedTime: string                                      ="00320033";   // Retired
    export var StudyReadDate: string                                          ="00320034";   // Retired
    export var StudyReadTime: string                                          ="00320035";   // Retired
    export var ScheduledStudyStartDate: string                                ="00321000";   // Retired
    export var ScheduledStudyStartTime: string                                ="00321001";   // Retired
    export var ScheduledStudyStopDate: string                                 ="00321010";   // Retired
    export var ScheduledStudyStopTime: string                                 ="00321011";   // Retired
    export var ScheduledStudyLocation: string                                 ="00321020";   // Retired
    export var ScheduledStudyLocationAETitle: string                          ="00321021";   // Retired
    export var ReasonForStudy: string                                         ="00321030";   // Retired
    export var RequestingPhysicianIdentificationSequence: string              ="00321031";
    export var RequestingPhysician: string                                    ="00321032";
    export var RequestingService: string                                      ="00321033";
    export var RequestingServiceCodeSequence: string                          ="00321034";
    export var StudyArrivalDate: string                                       ="00321040";   // Retired
    export var StudyArrivalTime: string                                       ="00321041";   // Retired
    export var StudyCompletionDate: string                                    ="00321050";   // Retired
    export var StudyCompletionTime: string                                    ="00321051";   // Retired
    export var StudyComponentStatusID: string                                 ="00321055";   // Retired
    export var RequestedProcedureDescription: string                          ="00321060";
    export var RequestedProcedureCodeSequence: string                         ="00321064";
    export var RequestedContrastAgent: string                                 ="00321070";
    export var StudyComments: string                                          ="00324000";   // Retired

// *****************************************************************************************************************************
// *** 0038
// *****************************************************************************************************************************
    export var ReferencedPatientAliasSequence: string                         ="00380004";
    export var VisitStatusID: string                                          ="00380008";
    export var AdmissionID: string                                            ="00380010";
    export var IssuerOfAdmissionID: string                                    ="00380011";   // Retired
    export var IssuerOfAdmissionIDSequence: string                            ="00380014";
    export var RouteOfAdmissions: string                                      ="00380016";
    export var ScheduledAdmissionDate: string                                 ="0038001A";   // Retired
    export var ScheduledAdmissionTime: string                                 ="0038001B";   // Retired
    export var ScheduledDischargeDate: string                                 ="0038001C";   // Retired
    export var ScheduledDischargeTime: string                                 ="0038001D";   // Retired
    export var ScheduledPatientInstitutionResidence: string                   ="0038001E";   // Retired
    export var AdmittingDate: string                                          ="00380020";
    export var AdmittingTime: string                                          ="00380021";
    export var DischargeDate: string                                          ="00380030";   // Retired
    export var DischargeTime: string                                          ="00380032";   // Retired
    export var DischargeDiagnosisDescription: string                          ="00380040";   // Retired
    export var DischargeDiagnosisCodeSequence: string                         ="00380044";   // Retired
    export var SpecialNeeds: string                                           ="00380050";
    export var ServiceEpisodeID: string                                       ="00380060";
    export var IssuerOfServiceEpisodeID: string                               ="00380061";   // Retired
    export var ServiceEpisodeDescription: string                              ="00380062";
    export var IssuerOfServiceEpisodeIDSequence: string                       ="00380064";
    export var PertinentDocumentsSequence: string                             ="00380100";
    export var PertinentResourcesSequence: string                             ="00380101";
    export var ResourceDescription: string                                    ="00380102";
    export var CurrentPatientLocation: string                                 ="00380300";
    export var PatientInstitutionResidence: string                            ="00380400";
    export var PatientState: string                                           ="00380500";
    export var PatientClinicalTrialParticipationSequence: string              ="00380502";
    export var VisitComments: string                                          ="00384000";

// *****************************************************************************************************************************
// *** 003A
// *****************************************************************************************************************************
    export var WaveformOriginality: string                                    ="003A0004";
    export var NumberOfWaveformChannels: string                               ="003A0005";
    export var NumberOfWaveformSamples: string                                ="003A0010";
    export var SamplingFrequency: string                                      ="003A001A";
    export var MultiplexGroupLabel: string                                    ="003A0020";
    export var ChannelDefinitionSequence: string                              ="003A0200";
    export var WaveformChannelNumber: string                                  ="003A0202";
    export var ChannelLabel: string                                           ="003A0203";
    export var ChannelStatus: string                                          ="003A0205";
    export var ChannelSourceSequence: string                                  ="003A0208";
    export var ChannelSourceModifiersSequence: string                         ="003A0209";
    export var SourceWaveformSequence: string                                 ="003A020A";
    export var ChannelDerivationDescription: string                           ="003A020C";
    export var ChannelSensitivity: string                                     ="003A0210";
    export var ChannelSensitivityUnitsSequence: string                        ="003A0211";
    export var ChannelSensitivityCorrectionFactor: string                     ="003A0212";
    export var ChannelBaseline: string                                        ="003A0213";
    export var ChannelTimeSkew: string                                        ="003A0214";
    export var ChannelSampleSkew: string                                      ="003A0215";
    export var ChannelOffset: string                                          ="003A0218";
    export var WaveformBitsStored: string                                     ="003A021A";
    export var FilterLowFrequency: string                                     ="003A0220";
    export var FilterHighFrequency: string                                    ="003A0221";
    export var NotchFilterFrequency: string                                   ="003A0222";
    export var NotchFilterBandwidth: string                                   ="003A0223";
    export var WaveformDataDisplayScale: string                               ="003A0230";
    export var WaveformDisplayBackgroundCIELabValue: string                   ="003A0231";
    export var WaveformPresentationGroupSequence: string                      ="003A0240";
    export var PresentationGroupNumber: string                                ="003A0241";
    export var ChannelDisplaySequence: string                                 ="003A0242";
    export var ChannelRecommendedDisplayCIELabValue: string                   ="003A0244";
    export var ChannelPosition: string                                        ="003A0245";
    export var DisplayShadingFlag: string                                     ="003A0246";
    export var FractionalChannelDisplayScale: string                          ="003A0247";
    export var AbsoluteChannelDisplayScale: string                            ="003A0248";
    export var MultiplexedAudioChannelsDescriptionCodeSequence: string        ="003A0300";
    export var ChannelIdentificationCode: string                              ="003A0301";
    export var ChannelMode: string                                            ="003A0302";

// *****************************************************************************************************************************
// *** 0040
// *****************************************************************************************************************************
    export var ScheduledStationAETitle: string                                ="00400001";
    export var ScheduledProcedureStepStartDate: string                        ="00400002";
    export var ScheduledProcedureStepStartTime: string                        ="00400003";
    export var ScheduledProcedureStepEndDate: string                          ="00400004";
    export var ScheduledProcedureStepEndTime: string                          ="00400005";
    export var ScheduledPerformingPhysicianName: string                       ="00400006";
    export var ScheduledProcedureStepDescription: string                      ="00400007";
    export var ScheduledProtocolCodeSequence: string                          ="00400008";
    export var ScheduledProcedureStepID: string                               ="00400009";
    export var StageCodeSequence: string                                      ="0040000A";
    export var ScheduledPerformingPhysicianIdentificationSequence: string     ="0040000B";
    export var ScheduledStationName: string                                   ="00400010";
    export var ScheduledProcedureStepLocation: string                         ="00400011";
    export var PreMedication: string                                          ="00400012";
    export var ScheduledProcedureStepStatus: string                           ="00400020";
    export var OrderPlacerIdentifierSequence: string                          ="00400026";
    export var OrderFillerIdentifierSequence: string                          ="00400027";
    export var LocalNamespaceEntityID: string                                 ="00400031";
    export var UniversalEntityID: string                                      ="00400032";
    export var UniversalEntityIDType: string                                  ="00400033";
    export var IdentifierTypeCode: string                                     ="00400035";
    export var AssigningFacilitySequence: string                              ="00400036";
    export var AssigningJurisdictionCodeSequence: string                      ="00400039";
    export var AssigningAgencyOrDepartmentCodeSequence: string                ="0040003A";
    export var ScheduledProcedureStepSequence: string                         ="00400100";
    export var ReferencedNonImageCompositeSOPInstanceSequence: string         ="00400220";
    export var PerformedStationAETitle: string                                ="00400241";
    export var PerformedStationName: string                                   ="00400242";
    export var PerformedLocation: string                                      ="00400243";
    export var PerformedProcedureStepStartDate: string                        ="00400244";
    export var PerformedProcedureStepStartTime: string                        ="00400245";
    export var PerformedProcedureStepEndDate: string                          ="00400250";
    export var PerformedProcedureStepEndTime: string                          ="00400251";
    export var PerformedProcedureStepStatus: string                           ="00400252";
    export var PerformedProcedureStepID: string                               ="00400253";
    export var PerformedProcedureStepDescription: string                      ="00400254";
    export var PerformedProcedureTypeDescription: string                      ="00400255";
    export var PerformedProtocolCodeSequence: string                          ="00400260";
    export var PerformedProtocolType: string                                  ="00400261";
    export var ScheduledStepAttributesSequence: string                        ="00400270";
    export var RequestAttributesSequence: string                              ="00400275";
    export var CommentsOnThePerformedProcedureStep: string                    ="00400280";
    export var PerformedProcedureStepDiscontinuationReasonCodeSequence: string ="00400281";
    export var QuantitySequence: string                                       ="00400293";
    export var Quantity: string                                               ="00400294";
    export var MeasuringUnitsSequence: string                                 ="00400295";
    export var BillingItemSequence: string                                    ="00400296";
    export var TotalTimeOfFluoroscopy: string                                 ="00400300";
    export var TotalNumberOfExposures: string                                 ="00400301";
    export var EntranceDose: string                                           ="00400302";
    export var ExposedArea: string                                            ="00400303";
    export var DistanceSourceToEntrance: string                               ="00400306";
    export var DistanceSourceToSupport: string                                ="00400307";   // Retired
    export var ExposureDoseSequence: string                                   ="0040030E";
    export var CommentsOnRadiationDose: string                                ="00400310";
    export var XRayOutput: string                                             ="00400312";
    export var HalfValueLayer: string                                         ="00400314";
    export var OrganDose: string                                              ="00400316";
    export var OrganExposed: string                                           ="00400318";
    export var BillingProcedureStepSequence: string                           ="00400320";
    export var FilmConsumptionSequence: string                                ="00400321";
    export var BillingSuppliesAndDevicesSequence: string                      ="00400324";
    export var ReferencedProcedureStepSequence: string                        ="00400330";   // Retired
    export var PerformedSeriesSequence: string                                ="00400340";
    export var CommentsOnTheScheduledProcedureStep: string                    ="00400400";
    export var ProtocolContextSequence: string                                ="00400440";
    export var ContentItemModifierSequence: string                            ="00400441";
    export var ScheduledSpecimenSequence: string                              ="00400500";
    export var SpecimenAccessionNumber: string                                ="0040050A";   // Retired
    export var ContainerIdentifier: string                                    ="00400512";
    export var IssuerOfTheContainerIdentifierSequence: string                 ="00400513";
    export var AlternateContainerIdentifierSequence: string                   ="00400515";
    export var ContainerTypeCodeSequence: string                              ="00400518";
    export var ContainerDescription: string                                   ="0040051A";
    export var ContainerComponentSequence: string                             ="00400520";
    export var SpecimenSequence: string                                       ="00400550";   // Retired
    export var SpecimenIdentifier: string                                     ="00400551";
    export var SpecimenDescriptionSequenceTrial: string                       ="00400552";   // Retired
    export var SpecimenDescriptionTrial: string                               ="00400553";   // Retired
    export var SpecimenUID: string                                            ="00400554";
    export var AcquisitionContextSequence: string                             ="00400555";
    export var AcquisitionContextDescription: string                          ="00400556";
    export var SpecimenDescriptionSequence: string                            ="00400560";
    export var IssuerOfTheSpecimenIdentifierSequence: string                  ="00400562";
    export var SpecimenTypeCodeSequence: string                               ="0040059A";
    export var SpecimenShortDescription: string                               ="00400600";
    export var SpecimenDetailedDescription: string                            ="00400602";
    export var SpecimenPreparationSequence: string                            ="00400610";
    export var SpecimenPreparationStepContentItemSequence: string             ="00400612";
    export var SpecimenLocalizationContentItemSequence: string                ="00400620";
    export var SlideIdentifier: string                                        ="004006FA";   // Retired
    export var ImageCenterPointCoordinatesSequence: string                    ="0040071A";
    export var XOffsetInSlideCoordinateSystem: string                         ="0040072A";
    export var YOffsetInSlideCoordinateSystem: string                         ="0040073A";
    export var ZOffsetInSlideCoordinateSystem: string                         ="0040074A";
    export var PixelSpacingSequence: string                                   ="004008D8";   // Retired
    export var CoordinateSystemAxisCodeSequence: string                       ="004008DA";   // Retired
    export var MeasurementUnitsCodeSequence: string                           ="004008EA";
    export var VitalStainCodeSequenceTrial: string                            ="004009F8";   // Retired
    export var RequestedProcedureID: string                                   ="00401001";
    export var ReasonForTheRequestedProcedure: string                         ="00401002";
    export var RequestedProcedurePriority: string                             ="00401003";
    export var PatientTransportArrangements: string                           ="00401004";
    export var RequestedProcedureLocation: string                             ="00401005";
    export var PlacerOrderNumberProcedure: string                             ="00401006";   // Retired
    export var FillerOrderNumberProcedure: string                             ="00401007";   // Retired
    export var ConfidentialityCode: string                                    ="00401008";
    export var ReportingPriority: string                                      ="00401009";
    export var ReasonForRequestedProcedureCodeSequence: string                ="0040100A";
    export var NamesOfIntendedRecipientsOfResults: string                     ="00401010";
    export var IntendedRecipientsOfResultsIdentificationSequence: string      ="00401011";
    export var ReasonForPerformedProcedureCodeSequence: string                ="00401012";
    export var RequestedProcedureDescriptionTrial: string                     ="00401060";   // Retired
    export var PersonIdentificationCodeSequence: string                       ="00401101";
    export var PersonAddress: string                                          ="00401102";
    export var PersonTelephoneNumbers: string                                 ="00401103";
    export var PersonTelecomInformation: string                               ="00401104";
    export var RequestedProcedureComments: string                             ="00401400";
    export var ReasonForTheImagingServiceRequest: string                      ="00402001";   // Retired
    export var IssueDateOfImagingServiceRequest: string                       ="00402004";
    export var IssueTimeOfImagingServiceRequest: string                       ="00402005";
    export var PlacerOrderNumberImagingServiceRequestRetired: string          ="00402006";   // Retired
    export var FillerOrderNumberImagingServiceRequestRetired: string          ="00402007";   // Retired
    export var OrderEnteredBy: string                                         ="00402008";
    export var OrderEntererLocation: string                                   ="00402009";
    export var OrderCallbackPhoneNumber: string                               ="00402010";
    export var OrderCallbackTelecomInformation: string                        ="00402011";
    export var PlacerOrderNumberImagingServiceRequest: string                 ="00402016";
    export var FillerOrderNumberImagingServiceRequest: string                 ="00402017";
    export var ImagingServiceRequestComments: string                          ="00402400";
    export var ConfidentialityConstraintOnPatientDataDescription: string      ="00403001";
    export var GeneralPurposeScheduledProcedureStepStatus: string             ="00404001";   // Retired
    export var GeneralPurposePerformedProcedureStepStatus: string             ="00404002";   // Retired
    export var GeneralPurposeScheduledProcedureStepPriority: string           ="00404003";   // Retired
    export var ScheduledProcessingApplicationsCodeSequence: string            ="00404004";   // Retired
    export var ScheduledProcedureStepStartDateTime: string                    ="00404005";
    export var MultipleCopiesFlag: string                                     ="00404006";   // Retired
    export var PerformedProcessingApplicationsCodeSequence: string            ="00404007";
    export var HumanPerformerCodeSequence: string                             ="00404009";
    export var ScheduledProcedureStepModificationDateTime: string             ="00404010";
    export var ExpectedCompletionDateTime: string                             ="00404011";
    export var ResultingGeneralPurposePerformedProcedureStepsSequence: string ="00404015";   // Retired
    export var ReferencedGeneralPurposeScheduledProcedureStepSequence: string ="00404016";   // Retired
    export var ScheduledWorkitemCodeSequence: string                          ="00404018";
    export var PerformedWorkitemCodeSequence: string                          ="00404019";
    export var InputAvailabilityFlag: string                                  ="00404020";
    export var InputInformationSequence: string                               ="00404021";
    export var RelevantInformationSequence: string                            ="00404022";   // Retired
    export var ReferencedGeneralPurposeScheduledProcedureStepTransactionUID: string ="00404023";   // Retired
    export var ScheduledStationNameCodeSequence: string                       ="00404025";
    export var ScheduledStationClassCodeSequence: string                      ="00404026";
    export var ScheduledStationGeographicLocationCodeSequence: string         ="00404027";
    export var PerformedStationNameCodeSequence: string                       ="00404028";
    export var PerformedStationClassCodeSequence: string                      ="00404029";
    export var PerformedStationGeographicLocationCodeSequence: string         ="00404030";
    export var RequestedSubsequentWorkitemCodeSequence: string                ="00404031";   // Retired
    export var NonDICOMOutputCodeSequence: string                             ="00404032";   // Retired
    export var OutputInformationSequence: string                              ="00404033";
    export var ScheduledHumanPerformersSequence: string                       ="00404034";
    export var ActualHumanPerformersSequence: string                          ="00404035";
    export var HumanPerformerOrganization: string                             ="00404036";
    export var HumanPerformerName: string                                     ="00404037";
    export var RawDataHandling: string                                        ="00404040";
    export var InputReadinessState: string                                    ="00404041";
    export var PerformedProcedureStepStartDateTime: string                    ="00404050";
    export var PerformedProcedureStepEndDateTime: string                      ="00404051";
    export var ProcedureStepCancellationDateTime: string                      ="00404052";
    export var EntranceDoseInMGy: string                                      ="00408302";
    export var ParametricMapFrameTypeSequence: string                         ="00409092";
    export var ReferencedImageRealWorldValueMappingSequence: string           ="00409094";
    export var RealWorldValueMappingSequence: string                          ="00409096";
    export var PixelValueMappingCodeSequence: string                          ="00409098";
    export var LUTLabel: string                                               ="00409210";
    export var RealWorldValueLastValueMapped: string                          ="00409211";
    export var RealWorldValueLUTData: string                                  ="00409212";
    export var RealWorldValueFirstValueMapped: string                         ="00409216";
    export var QuantityDefinitionSequence: string                             ="00409220";
    export var RealWorldValueIntercept: string                                ="00409224";
    export var RealWorldValueSlope: string                                    ="00409225";
    export var FindingsFlagTrial: string                                      ="0040A007";   // Retired
    export var RelationshipType: string                                       ="0040A010";
    export var FindingsSequenceTrial: string                                  ="0040A020";   // Retired
    export var FindingsGroupUIDTrial: string                                  ="0040A021";   // Retired
    export var ReferencedFindingsGroupUIDTrial: string                        ="0040A022";   // Retired
    export var FindingsGroupRecordingDateTrial: string                        ="0040A023";   // Retired
    export var FindingsGroupRecordingTimeTrial: string                        ="0040A024";   // Retired
    export var FindingsSourceCategoryCodeSequenceTrial: string                ="0040A026";   // Retired
    export var VerifyingOrganization: string                                  ="0040A027";
    export var DocumentingOrganizationIdentifierCodeSequenceTrial: string     ="0040A028";   // Retired
    export var VerificationDateTime: string                                   ="0040A030";
    export var ObservationDateTime: string                                    ="0040A032";
    export var ValueType: string                                              ="0040A040";
    export var ConceptNameCodeSequence: string                                ="0040A043";
    export var MeasurementPrecisionDescriptionTrial: string                   ="0040A047";   // Retired
    export var ContinuityOfContent: string                                    ="0040A050";
    export var UrgencyOrPriorityAlertsTrial: string                           ="0040A057";   // Retired
    export var SequencingIndicatorTrial: string                               ="0040A060";   // Retired
    export var DocumentIdentifierCodeSequenceTrial: string                    ="0040A066";   // Retired
    export var DocumentAuthorTrial: string                                    ="0040A067";   // Retired
    export var DocumentAuthorIdentifierCodeSequenceTrial: string              ="0040A068";   // Retired
    export var IdentifierCodeSequenceTrial: string                            ="0040A070";   // Retired
    export var VerifyingObserverSequence: string                              ="0040A073";
    export var ObjectBinaryIdentifierTrial: string                            ="0040A074";   // Retired
    export var VerifyingObserverName: string                                  ="0040A075";
    export var DocumentingObserverIdentifierCodeSequenceTrial: string         ="0040A076";   // Retired
    export var AuthorObserverSequence: string                                 ="0040A078";
    export var ParticipantSequence: string                                    ="0040A07A";
    export var CustodialOrganizationSequence: string                          ="0040A07C";
    export var ParticipationType: string                                      ="0040A080";
    export var ParticipationDateTime: string                                  ="0040A082";
    export var ObserverType: string                                           ="0040A084";
    export var ProcedureIdentifierCodeSequenceTrial: string                   ="0040A085";   // Retired
    export var VerifyingObserverIdentificationCodeSequence: string            ="0040A088";
    export var ObjectDirectoryBinaryIdentifierTrial: string                   ="0040A089";   // Retired
    export var EquivalentCDADocumentSequence: string                          ="0040A090";   // Retired
    export var ReferencedWaveformChannels: string                             ="0040A0B0";
    export var DateOfDocumentOrVerbalTransactionTrial: string                 ="0040A110";   // Retired
    export var TimeOfDocumentCreationOrVerbalTransactionTrial: string         ="0040A112";   // Retired
    export var DateTime: string                                               ="0040A120";
    export var Date: string                                                   ="0040A121";
    export var Time: string                                                   ="0040A122";
    export var PersonName: string                                             ="0040A123";
    export var UID: string                                                    ="0040A124";
    export var ReportStatusIDTrial: string                                    ="0040A125";   // Retired
    export var TemporalRangeType: string                                      ="0040A130";
    export var ReferencedSamplePositions: string                              ="0040A132";
    export var ReferencedFrameNumbers: string                                 ="0040A136";
    export var ReferencedTimeOffsets: string                                  ="0040A138";
    export var ReferencedDateTime: string                                     ="0040A13A";
    export var TextValue: string                                              ="0040A160";
    export var FloatingPointValue: string                                     ="0040A161";
    export var RationalNumeratorValue: string                                 ="0040A162";
    export var RationalDenominatorValue: string                               ="0040A163";
    export var ObservationCategoryCodeSequenceTrial: string                   ="0040A167";   // Retired
    export var ConceptCodeSequence: string                                    ="0040A168";
    export var BibliographicCitationTrial: string                             ="0040A16A";   // Retired
    export var PurposeOfReferenceCodeSequence: string                         ="0040A170";
    export var ObservationUID: string                                         ="0040A171";
    export var ReferencedObservationUIDTrial: string                          ="0040A172";   // Retired
    export var ReferencedObservationClassTrial: string                        ="0040A173";   // Retired
    export var ReferencedObjectObservationClassTrial: string                  ="0040A174";   // Retired
    export var AnnotationGroupNumber: string                                  ="0040A180";
    export var ObservationDateTrial: string                                   ="0040A192";   // Retired
    export var ObservationTimeTrial: string                                   ="0040A193";   // Retired
    export var MeasurementAutomationTrial: string                             ="0040A194";   // Retired
    export var ModifierCodeSequence: string                                   ="0040A195";
    export var IdentificationDescriptionTrial: string                         ="0040A224";   // Retired
    export var CoordinatesSetGeometricTypeTrial: string                       ="0040A290";   // Retired
    export var AlgorithmCodeSequenceTrial: string                             ="0040A296";   // Retired
    export var AlgorithmDescriptionTrial: string                              ="0040A297";   // Retired
    export var PixelCoordinatesSetTrial: string                               ="0040A29A";   // Retired
    export var MeasuredValueSequence: string                                  ="0040A300";
    export var NumericValueQualifierCodeSequence: string                      ="0040A301";
    export var CurrentObserverTrial: string                                   ="0040A307";   // Retired
    export var NumericValue: string                                           ="0040A30A";
    export var ReferencedAccessionSequenceTrial: string                       ="0040A313";   // Retired
    export var ReportStatusCommentTrial: string                               ="0040A33A";   // Retired
    export var ProcedureContextSequenceTrial: string                          ="0040A340";   // Retired
    export var VerbalSourceTrial: string                                      ="0040A352";   // Retired
    export var AddressTrial: string                                           ="0040A353";   // Retired
    export var TelephoneNumberTrial: string                                   ="0040A354";   // Retired
    export var VerbalSourceIdentifierCodeSequenceTrial: string                ="0040A358";   // Retired
    export var PredecessorDocumentsSequence: string                           ="0040A360";
    export var ReferencedRequestSequence: string                              ="0040A370";
    export var PerformedProcedureCodeSequence: string                         ="0040A372";
    export var CurrentRequestedProcedureEvidenceSequence: string              ="0040A375";
    export var ReportDetailSequenceTrial: string                              ="0040A380";   // Retired
    export var PertinentOtherEvidenceSequence: string                         ="0040A385";
    export var HL7StructuredDocumentReferenceSequence: string                 ="0040A390";
    export var ObservationSubjectUIDTrial: string                             ="0040A402";   // Retired
    export var ObservationSubjectClassTrial: string                           ="0040A403";   // Retired
    export var ObservationSubjectTypeCodeSequenceTrial: string                ="0040A404";   // Retired
    export var CompletionFlag: string                                         ="0040A491";
    export var CompletionFlagDescription: string                              ="0040A492";
    export var VerificationFlag: string                                       ="0040A493";
    export var ArchiveRequested: string                                       ="0040A494";
    export var PreliminaryFlag: string                                        ="0040A496";
    export var ContentTemplateSequence: string                                ="0040A504";
    export var IdenticalDocumentsSequence: string                             ="0040A525";
    export var ObservationSubjectContextFlagTrial: string                     ="0040A600";   // Retired
    export var ObserverContextFlagTrial: string                               ="0040A601";   // Retired
    export var ProcedureContextFlagTrial: string                              ="0040A603";   // Retired
    export var ContentSequence: string                                        ="0040A730";
    export var RelationshipSequenceTrial: string                              ="0040A731";   // Retired
    export var RelationshipTypeCodeSequenceTrial: string                      ="0040A732";   // Retired
    export var LanguageCodeSequenceTrial: string                              ="0040A744";   // Retired
    export var UniformResourceLocatorTrial: string                            ="0040A992";   // Retired
    export var WaveformAnnotationSequence: string                             ="0040B020";
    export var TemplateIdentifier: string                                     ="0040DB00";
    export var TemplateVersion: string                                        ="0040DB06";   // Retired
    export var TemplateLocalVersion: string                                   ="0040DB07";   // Retired
    export var TemplateExtensionFlag: string                                  ="0040DB0B";   // Retired
    export var TemplateExtensionOrganizationUID: string                       ="0040DB0C";   // Retired
    export var TemplateExtensionCreatorUID: string                            ="0040DB0D";   // Retired
    export var ReferencedContentItemIdentifier: string                        ="0040DB73";
    export var HL7InstanceIdentifier: string                                  ="0040E001";
    export var HL7DocumentEffectiveTime: string                               ="0040E004";
    export var HL7DocumentTypeCodeSequence: string                            ="0040E006";
    export var DocumentClassCodeSequence: string                              ="0040E008";
    export var RetrieveURI: string                                            ="0040E010";
    export var RetrieveLocationUID: string                                    ="0040E011";
    export var TypeOfInstances: string                                        ="0040E020";
    export var DICOMRetrievalSequence: string                                 ="0040E021";
    export var DICOMMediaRetrievalSequence: string                            ="0040E022";
    export var WADORetrievalSequence: string                                  ="0040E023";
    export var XDSRetrievalSequence: string                                   ="0040E024";
    export var WADORSRetrievalSequence: string                                ="0040E025";
    export var RepositoryUniqueID: string                                     ="0040E030";
    export var HomeCommunityID: string                                        ="0040E031";

// *****************************************************************************************************************************
// *** 0042
// *****************************************************************************************************************************
    export var DocumentTitle: string                                          ="00420010";
    export var EncapsulatedDocument: string                                   ="00420011";
    export var MIMETypeOfEncapsulatedDocument: string                         ="00420012";
    export var SourceInstanceSequence: string                                 ="00420013";
    export var ListOfMIMETypes: string                                        ="00420014";

// *****************************************************************************************************************************
// *** 0044
// *****************************************************************************************************************************
    export var ProductPackageIdentifier: string                               ="00440001";
    export var SubstanceAdministrationApproval: string                        ="00440002";
    export var ApprovalStatusFurtherDescription: string                       ="00440003";
    export var ApprovalStatusDateTime: string                                 ="00440004";
    export var ProductTypeCodeSequence: string                                ="00440007";
    export var ProductName: string                                            ="00440008";
    export var ProductDescription: string                                     ="00440009";
    export var ProductLotIdentifier: string                                   ="0044000A";
    export var ProductExpirationDateTime: string                              ="0044000B";
    export var SubstanceAdministrationDateTime: string                        ="00440010";
    export var SubstanceAdministrationNotes: string                           ="00440011";
    export var SubstanceAdministrationDeviceID: string                        ="00440012";
    export var ProductParameterSequence: string                               ="00440013";
    export var SubstanceAdministrationParameterSequence: string               ="00440019";

// *****************************************************************************************************************************
// *** 0046
// *****************************************************************************************************************************
    export var LensDescription: string                                        ="00460012";
    export var RightLensSequence: string                                      ="00460014";
    export var LeftLensSequence: string                                       ="00460015";
    export var UnspecifiedLateralityLensSequence: string                      ="00460016";
    export var CylinderSequence: string                                       ="00460018";
    export var PrismSequence: string                                          ="00460028";
    export var HorizontalPrismPower: string                                   ="00460030";
    export var HorizontalPrismBase: string                                    ="00460032";
    export var VerticalPrismPower: string                                     ="00460034";
    export var VerticalPrismBase: string                                      ="00460036";
    export var LensSegmentType: string                                        ="00460038";
    export var OpticalTransmittance: string                                   ="00460040";
    export var ChannelWidth: string                                           ="00460042";
    export var PupilSize: string                                              ="00460044";
    export var CornealSize: string                                            ="00460046";
    export var AutorefractionRightEyeSequence: string                         ="00460050";
    export var AutorefractionLeftEyeSequence: string                          ="00460052";
    export var DistancePupillaryDistance: string                              ="00460060";
    export var NearPupillaryDistance: string                                  ="00460062";
    export var IntermediatePupillaryDistance: string                          ="00460063";
    export var OtherPupillaryDistance: string                                 ="00460064";
    export var KeratometryRightEyeSequence: string                            ="00460070";
    export var KeratometryLeftEyeSequence: string                             ="00460071";
    export var SteepKeratometricAxisSequence: string                          ="00460074";
    export var RadiusOfCurvature: string                                      ="00460075";
    export var KeratometricPower: string                                      ="00460076";
    export var KeratometricAxis: string                                       ="00460077";
    export var FlatKeratometricAxisSequence: string                           ="00460080";
    export var BackgroundColor: string                                        ="00460092";
    export var Optotype: string                                               ="00460094";
    export var OptotypePresentation: string                                   ="00460095";
    export var SubjectiveRefractionRightEyeSequence: string                   ="00460097";
    export var SubjectiveRefractionLeftEyeSequence: string                    ="00460098";
    export var AddNearSequence: string                                        ="00460100";
    export var AddIntermediateSequence: string                                ="00460101";
    export var AddOtherSequence: string                                       ="00460102";
    export var AddPower: string                                               ="00460104";
    export var ViewingDistance: string                                        ="00460106";
    export var VisualAcuityTypeCodeSequence: string                           ="00460121";
    export var VisualAcuityRightEyeSequence: string                           ="00460122";
    export var VisualAcuityLeftEyeSequence: string                            ="00460123";
    export var VisualAcuityBothEyesOpenSequence: string                       ="00460124";
    export var ViewingDistanceType: string                                    ="00460125";
    export var VisualAcuityModifiers: string                                  ="00460135";
    export var DecimalVisualAcuity: string                                    ="00460137";
    export var OptotypeDetailedDefinition: string                             ="00460139";
    export var ReferencedRefractiveMeasurementsSequence: string               ="00460145";
    export var SpherePower: string                                            ="00460146";
    export var CylinderPower: string                                          ="00460147";
    export var CornealTopographySurface: string                               ="00460201";
    export var CornealVertexLocation: string                                  ="00460202";
    export var PupilCentroidXCoordinate: string                               ="00460203";
    export var PupilCentroidYCoordinate: string                               ="00460204";
    export var EquivalentPupilRadius: string                                  ="00460205";
    export var CornealTopographyMapTypeCodeSequence: string                   ="00460207";
    export var VerticesOfTheOutlineOfPupil: string                            ="00460208";
    export var CornealTopographyMappingNormalsSequence: string                ="00460210";
    export var MaximumCornealCurvatureSequence: string                        ="00460211";
    export var MaximumCornealCurvature: string                                ="00460212";
    export var MaximumCornealCurvatureLocation: string                        ="00460213";
    export var MinimumKeratometricSequence: string                            ="00460215";
    export var SimulatedKeratometricCylinderSequence: string                  ="00460218";
    export var AverageCornealPower: string                                    ="00460220";
    export var CornealISValue: string                                         ="00460224";
    export var AnalyzedArea: string                                           ="00460227";
    export var SurfaceRegularityIndex: string                                 ="00460230";
    export var SurfaceAsymmetryIndex: string                                  ="00460232";
    export var CornealEccentricityIndex: string                               ="00460234";
    export var KeratoconusPredictionIndex: string                             ="00460236";
    export var DecimalPotentialVisualAcuity: string                           ="00460238";
    export var CornealTopographyMapQualityEvaluation: string                  ="00460242";
    export var SourceImageCornealProcessedDataSequence: string                ="00460244";
    export var CornealPointLocation: string                                   ="00460247";
    export var CornealPointEstimated: string                                  ="00460248";
    export var AxialPower: string                                             ="00460249";
    export var TangentialPower: string                                        ="00460250";
    export var RefractivePower: string                                        ="00460251";
    export var RelativeElevation: string                                      ="00460252";
    export var CornealWavefront: string                                       ="00460253";

// *****************************************************************************************************************************
// *** 0048
// *****************************************************************************************************************************
    export var ImagedVolumeWidth: string                                      ="00480001";
    export var ImagedVolumeHeight: string                                     ="00480002";
    export var ImagedVolumeDepth: string                                      ="00480003";
    export var TotalPixelMatrixColumns: string                                ="00480006";
    export var TotalPixelMatrixRows: string                                   ="00480007";
    export var TotalPixelMatrixOriginSequence: string                         ="00480008";
    export var SpecimenLabelInImage: string                                   ="00480010";
    export var FocusMethod: string                                            ="00480011";
    export var ExtendedDepthOfField: string                                   ="00480012";
    export var NumberOfFocalPlanes: string                                    ="00480013";
    export var DistanceBetweenFocalPlanes: string                             ="00480014";
    export var RecommendedAbsentPixelCIELabValue: string                      ="00480015";
    export var IlluminatorTypeCodeSequence: string                            ="00480100";
    export var ImageOrientationSlide: string                                  ="00480102";
    export var OpticalPathSequence: string                                    ="00480105";
    export var OpticalPathIdentifier: string                                  ="00480106";
    export var OpticalPathDescription: string                                 ="00480107";
    export var IlluminationColorCodeSequence: string                          ="00480108";
    export var SpecimenReferenceSequence: string                              ="00480110";
    export var CondenserLensPower: string                                     ="00480111";
    export var ObjectiveLensPower: string                                     ="00480112";
    export var ObjectiveLensNumericalAperture: string                         ="00480113";
    export var PaletteColorLookupTableSequence: string                        ="00480120";
    export var ReferencedImageNavigationSequence: string                      ="00480200";
    export var TopLeftHandCornerOfLocalizerArea: string                       ="00480201";
    export var BottomRightHandCornerOfLocalizerArea: string                   ="00480202";
    export var OpticalPathIdentificationSequence: string                      ="00480207";
    export var PlanePositionSlideSequence: string                             ="0048021A";
    export var ColumnPositionInTotalImagePixelMatrix: string                  ="0048021E";
    export var RowPositionInTotalImagePixelMatrix: string                     ="0048021F";
    export var PixelOriginInterpretation: string                              ="00480301";

// *****************************************************************************************************************************
// *** 0050
// *****************************************************************************************************************************
    export var CalibrationImage: string                                       ="00500004";
    export var DeviceSequence: string                                         ="00500010";
    export var ContainerComponentTypeCodeSequence: string                     ="00500012";
    export var ContainerComponentThickness: string                            ="00500013";
    export var DeviceLength: string                                           ="00500014";
    export var ContainerComponentWidth: string                                ="00500015";
    export var DeviceDiameter: string                                         ="00500016";
    export var DeviceDiameterUnits: string                                    ="00500017";
    export var DeviceVolume: string                                           ="00500018";
    export var IntermarkerDistance: string                                    ="00500019";
    export var ContainerComponentMaterial: string                             ="0050001A";
    export var ContainerComponentID: string                                   ="0050001B";
    export var ContainerComponentLength: string                               ="0050001C";
    export var ContainerComponentDiameter: string                             ="0050001D";
    export var ContainerComponentDescription: string                          ="0050001E";
    export var DeviceDescription: string                                      ="00500020";

// *****************************************************************************************************************************
// *** 0052
// *****************************************************************************************************************************
    export var ContrastBolusIngredientPercentByVolume: string                 ="00520001";
    export var OCTFocalDistance: string                                       ="00520002";
    export var BeamSpotSize: string                                           ="00520003";
    export var EffectiveRefractiveIndex: string                               ="00520004";
    export var OCTAcquisitionDomain: string                                   ="00520006";
    export var OCTOpticalCenterWavelength: string                             ="00520007";
    export var AxialResolution: string                                        ="00520008";
    export var RangingDepth: string                                           ="00520009";
    export var ALineRate: string                                              ="00520011";
    export var ALinesPerFrame: string                                         ="00520012";
    export var CatheterRotationalRate: string                                 ="00520013";
    export var ALinePixelSpacing: string                                      ="00520014";
    export var ModeOfPercutaneousAccessSequence: string                       ="00520016";
    export var IntravascularOCTFrameTypeSequence: string                      ="00520025";
    export var OCTZOffsetApplied: string                                      ="00520026";
    export var IntravascularFrameContentSequence: string                      ="00520027";
    export var IntravascularLongitudinalDistance: string                      ="00520028";
    export var IntravascularOCTFrameContentSequence: string                   ="00520029";
    export var OCTZOffsetCorrection: string                                   ="00520030";
    export var CatheterDirectionOfRotation: string                            ="00520031";
    export var SeamLineLocation: string                                       ="00520033";
    export var FirstALineLocation: string                                     ="00520034";
    export var SeamLineIndex: string                                          ="00520036";
    export var NumberOfPaddedALines: string                                   ="00520038";
    export var InterpolationType: string                                      ="00520039";
    export var RefractiveIndexApplied: string                                 ="0052003A";

// *****************************************************************************************************************************
// *** 0054
// *****************************************************************************************************************************
    export var EnergyWindowVector: string                                     ="00540010";
    export var NumberOfEnergyWindows: string                                  ="00540011";
    export var EnergyWindowInformationSequence: string                        ="00540012";
    export var EnergyWindowRangeSequence: string                              ="00540013";
    export var EnergyWindowLowerLimit: string                                 ="00540014";
    export var EnergyWindowUpperLimit: string                                 ="00540015";
    export var RadiopharmaceuticalInformationSequence: string                 ="00540016";
    export var ResidualSyringeCounts: string                                  ="00540017";
    export var EnergyWindowName: string                                       ="00540018";
    export var DetectorVector: string                                         ="00540020";
    export var NumberOfDetectors: string                                      ="00540021";
    export var DetectorInformationSequence: string                            ="00540022";
    export var PhaseVector: string                                            ="00540030";
    export var NumberOfPhases: string                                         ="00540031";
    export var PhaseInformationSequence: string                               ="00540032";
    export var NumberOfFramesInPhase: string                                  ="00540033";
    export var PhaseDelay: string                                             ="00540036";
    export var PauseBetweenFrames: string                                     ="00540038";
    export var PhaseDescription: string                                       ="00540039";
    export var RotationVector: string                                         ="00540050";
    export var NumberOfRotations: string                                      ="00540051";
    export var RotationInformationSequence: string                            ="00540052";
    export var NumberOfFramesInRotation: string                               ="00540053";
    export var RRIntervalVector: string                                       ="00540060";
    export var NumberOfRRIntervals: string                                    ="00540061";
    export var GatedInformationSequence: string                               ="00540062";
    export var DataInformationSequence: string                                ="00540063";
    export var TimeSlotVector: string                                         ="00540070";
    export var NumberOfTimeSlots: string                                      ="00540071";
    export var TimeSlotInformationSequence: string                            ="00540072";
    export var TimeSlotTime: string                                           ="00540073";
    export var SliceVector: string                                            ="00540080";
    export var NumberOfSlices: string                                         ="00540081";
    export var AngularViewVector: string                                      ="00540090";
    export var TimeSliceVector: string                                        ="00540100";
    export var NumberOfTimeSlices: string                                     ="00540101";
    export var StartAngle: string                                             ="00540200";
    export var TypeOfDetectorMotion: string                                   ="00540202";
    export var TriggerVector: string                                          ="00540210";
    export var NumberOfTriggersInPhase: string                                ="00540211";
    export var ViewCodeSequence: string                                       ="00540220";
    export var ViewModifierCodeSequence: string                               ="00540222";
    export var RadionuclideCodeSequence: string                               ="00540300";
    export var AdministrationRouteCodeSequence: string                        ="00540302";
    export var RadiopharmaceuticalCodeSequence: string                        ="00540304";
    export var CalibrationDataSequence: string                                ="00540306";
    export var EnergyWindowNumber: string                                     ="00540308";
    export var ImageID: string                                                ="00540400";
    export var PatientOrientationCodeSequence: string                         ="00540410";
    export var PatientOrientationModifierCodeSequence: string                 ="00540412";
    export var PatientGantryRelationshipCodeSequence: string                  ="00540414";
    export var SliceProgressionDirection: string                              ="00540500";
    export var ScanProgressionDirection: string                               ="00540501";
    export var SeriesType: string                                             ="00541000";
    export var Units: string                                                  ="00541001";
    export var CountsSource: string                                           ="00541002";
    export var ReprojectionMethod: string                                     ="00541004";
    export var SUVType: string                                                ="00541006";
    export var RandomsCorrectionMethod: string                                ="00541100";
    export var AttenuationCorrectionMethod: string                            ="00541101";
    export var DecayCorrection: string                                        ="00541102";
    export var ReconstructionMethod: string                                   ="00541103";
    export var DetectorLinesOfResponseUsed: string                            ="00541104";
    export var ScatterCorrectionMethod: string                                ="00541105";
    export var AxialAcceptance: string                                        ="00541200";
    export var AxialMash: string                                              ="00541201";
    export var TransverseMash: string                                         ="00541202";
    export var DetectorElementSize: string                                    ="00541203";
    export var CoincidenceWindowWidth: string                                 ="00541210";
    export var SecondaryCountsType: string                                    ="00541220";
    export var FrameReferenceTime: string                                     ="00541300";
    export var PrimaryPromptsCountsAccumulated: string                        ="00541310";
    export var SecondaryCountsAccumulated: string                             ="00541311";
    export var SliceSensitivityFactor: string                                 ="00541320";
    export var DecayFactor: string                                            ="00541321";
    export var DoseCalibrationFactor: string                                  ="00541322";
    export var ScatterFractionFactor: string                                  ="00541323";
    export var DeadTimeFactor: string                                         ="00541324";
    export var ImageIndex: string                                             ="00541330";
    export var CountsIncluded: string                                         ="00541400";   // Retired
    export var DeadTimeCorrectionFlag: string                                 ="00541401";   // Retired

// *****************************************************************************************************************************
// *** 0060
// *****************************************************************************************************************************
    export var HistogramSequence: string                                      ="00603000";
    export var HistogramNumberOfBins: string                                  ="00603002";
    export var HistogramFirstBinValue: string                                 ="00603004";
    export var HistogramLastBinValue: string                                  ="00603006";
    export var HistogramBinWidth: string                                      ="00603008";
    export var HistogramExplanation: string                                   ="00603010";
    export var HistogramData: string                                          ="00603020";

// *****************************************************************************************************************************
// *** 0062
// *****************************************************************************************************************************
    export var SegmentationType: string                                       ="00620001";
    export var SegmentSequence: string                                        ="00620002";
    export var SegmentedPropertyCategoryCodeSequence: string                  ="00620003";
    export var SegmentNumber: string                                          ="00620004";
    export var SegmentLabel: string                                           ="00620005";
    export var SegmentDescription: string                                     ="00620006";
    export var SegmentAlgorithmType: string                                   ="00620008";
    export var SegmentAlgorithmName: string                                   ="00620009";
    export var SegmentIdentificationSequence: string                          ="0062000A";
    export var ReferencedSegmentNumber: string                                ="0062000B";
    export var RecommendedDisplayGrayscaleValue: string                       ="0062000C";
    export var RecommendedDisplayCIELabValue: string                          ="0062000D";
    export var MaximumFractionalValue: string                                 ="0062000E";
    export var SegmentedPropertyTypeCodeSequence: string                      ="0062000F";
    export var SegmentationFractionalType: string                             ="00620010";
    export var SegmentedPropertyTypeModifierCodeSequence: string              ="00620011";
    export var UsedSegmentsSequence: string                                   ="00620012";

// *****************************************************************************************************************************
// *** 0064
// *****************************************************************************************************************************
    export var DeformableRegistrationSequence: string                         ="00640002";
    export var SourceFrameOfReferenceUID: string                              ="00640003";
    export var DeformableRegistrationGridSequence: string                     ="00640005";
    export var GridDimensions: string                                         ="00640007";
    export var GridResolution: string                                         ="00640008";
    export var VectorGridData: string                                         ="00640009";
    export var PreDeformationMatrixRegistrationSequence: string               ="0064000F";
    export var PostDeformationMatrixRegistrationSequence: string              ="00640010";

// *****************************************************************************************************************************
// *** 0066
// *****************************************************************************************************************************
    export var NumberOfSurfaces: string                                       ="00660001";
    export var SurfaceSequence: string                                        ="00660002";
    export var SurfaceNumber: string                                          ="00660003";
    export var SurfaceComments: string                                        ="00660004";
    export var SurfaceProcessing: string                                      ="00660009";
    export var SurfaceProcessingRatio: string                                 ="0066000A";
    export var SurfaceProcessingDescription: string                           ="0066000B";
    export var RecommendedPresentationOpacity: string                         ="0066000C";
    export var RecommendedPresentationType: string                            ="0066000D";
    export var FiniteVolume: string                                           ="0066000E";
    export var Manifold: string                                               ="00660010";
    export var SurfacePointsSequence: string                                  ="00660011";
    export var SurfacePointsNormalsSequence: string                           ="00660012";
    export var SurfaceMeshPrimitivesSequence: string                          ="00660013";
    export var NumberOfSurfacePoints: string                                  ="00660015";
    export var PointCoordinatesData: string                                   ="00660016";
    export var PointPositionAccuracy: string                                  ="00660017";
    export var MeanPointDistance: string                                      ="00660018";
    export var MaximumPointDistance: string                                   ="00660019";
    export var PointsBoundingBoxCoordinates: string                           ="0066001A";
    export var AxisOfRotation: string                                         ="0066001B";
    export var CenterOfRotation: string                                       ="0066001C";
    export var NumberOfVectors: string                                        ="0066001E";
    export var VectorDimensionality: string                                   ="0066001F";
    export var VectorAccuracy: string                                         ="00660020";
    export var VectorCoordinateData: string                                   ="00660021";
    export var TrianglePointIndexList: string                                 ="00660023";
    export var EdgePointIndexList: string                                     ="00660024";
    export var VertexPointIndexList: string                                   ="00660025";
    export var TriangleStripSequence: string                                  ="00660026";
    export var TriangleFanSequence: string                                    ="00660027";
    export var LineSequence: string                                           ="00660028";
    export var PrimitivePointIndexList: string                                ="00660029";
    export var SurfaceCount: string                                           ="0066002A";
    export var ReferencedSurfaceSequence: string                              ="0066002B";
    export var ReferencedSurfaceNumber: string                                ="0066002C";
    export var SegmentSurfaceGenerationAlgorithmIdentificationSequence: string ="0066002D";
    export var SegmentSurfaceSourceInstanceSequence: string                   ="0066002E";
    export var AlgorithmFamilyCodeSequence: string                            ="0066002F";
    export var AlgorithmNameCodeSequence: string                              ="00660030";
    export var AlgorithmVersion: string                                       ="00660031";
    export var AlgorithmParameters: string                                    ="00660032";
    export var FacetSequence: string                                          ="00660034";
    export var SurfaceProcessingAlgorithmIdentificationSequence: string       ="00660035";
    export var AlgorithmName: string                                          ="00660036";
    export var RecommendedPointRadius: string                                 ="00660037";
    export var RecommendedLineThickness: string                               ="00660038";
    export var LongPrimitivePointIndexList: string                            ="00660040";
    export var LongTrianglePointIndexList: string                             ="00660041";
    export var LongEdgePointIndexList: string                                 ="00660042";
    export var LongVertexPointIndexList: string                               ="00660043";

// *****************************************************************************************************************************
// *** 0068
// *****************************************************************************************************************************
    export var ImplantSize: string                                            ="00686210";
    export var ImplantTemplateVersion: string                                 ="00686221";
    export var ReplacedImplantTemplateSequence: string                        ="00686222";
    export var ImplantType: string                                            ="00686223";
    export var DerivationImplantTemplateSequence: string                      ="00686224";
    export var OriginalImplantTemplateSequence: string                        ="00686225";
    export var EffectiveDateTime: string                                      ="00686226";
    export var ImplantTargetAnatomySequence: string                           ="00686230";
    export var InformationFromManufacturerSequence: string                    ="00686260";
    export var NotificationFromManufacturerSequence: string                   ="00686265";
    export var InformationIssueDateTime: string                               ="00686270";
    export var InformationSummary: string                                     ="00686280";
    export var ImplantRegulatoryDisapprovalCodeSequence: string               ="006862A0";
    export var OverallTemplateSpatialTolerance: string                        ="006862A5";
    export var HPGLDocumentSequence: string                                   ="006862C0";
    export var HPGLDocumentID: string                                         ="006862D0";
    export var HPGLDocumentLabel: string                                      ="006862D5";
    export var ViewOrientationCodeSequence: string                            ="006862E0";
    export var ViewOrientationModifier: string                                ="006862F0";
    export var HPGLDocumentScaling: string                                    ="006862F2";
    export var HPGLDocument: string                                           ="00686300";
    export var HPGLContourPenNumber: string                                   ="00686310";
    export var HPGLPenSequence: string                                        ="00686320";
    export var HPGLPenNumber: string                                          ="00686330";
    export var HPGLPenLabel: string                                           ="00686340";
    export var HPGLPenDescription: string                                     ="00686345";
    export var RecommendedRotationPoint: string                               ="00686346";
    export var BoundingRectangle: string                                      ="00686347";
    export var ImplantTemplate3DModelSurfaceNumber: string                    ="00686350";
    export var SurfaceModelDescriptionSequence: string                        ="00686360";
    export var SurfaceModelLabel: string                                      ="00686380";
    export var SurfaceModelScalingFactor: string                              ="00686390";
    export var MaterialsCodeSequence: string                                  ="006863A0";
    export var CoatingMaterialsCodeSequence: string                           ="006863A4";
    export var ImplantTypeCodeSequence: string                                ="006863A8";
    export var FixationMethodCodeSequence: string                             ="006863AC";
    export var MatingFeatureSetsSequence: string                              ="006863B0";
    export var MatingFeatureSetID: string                                     ="006863C0";
    export var MatingFeatureSetLabel: string                                  ="006863D0";
    export var MatingFeatureSequence: string                                  ="006863E0";
    export var MatingFeatureID: string                                        ="006863F0";
    export var MatingFeatureDegreeOfFreedomSequence: string                   ="00686400";
    export var DegreeOfFreedomID: string                                      ="00686410";
    export var DegreeOfFreedomType: string                                    ="00686420";
    export var TwoDMatingFeatureCoordinatesSequence: string                   ="00686430";
    export var ReferencedHPGLDocumentID: string                               ="00686440";
    export var TwoDMatingPoint: string                                        ="00686450";
    export var TwoDMatingAxes: string                                         ="00686460";
    export var TwoDDegreeOfFreedomSequence: string                            ="00686470";
    export var ThreeDDegreeOfFreedomAxis: string                              ="00686490";
    export var RangeOfFreedom: string                                         ="006864A0";
    export var ThreeDMatingPoint: string                                      ="006864C0";
    export var ThreeDMatingAxes: string                                       ="006864D0";
    export var TwoDDegreeOfFreedomAxis: string                                ="006864F0";
    export var PlanningLandmarkPointSequence: string                          ="00686500";
    export var PlanningLandmarkLineSequence: string                           ="00686510";
    export var PlanningLandmarkPlaneSequence: string                          ="00686520";
    export var PlanningLandmarkID: string                                     ="00686530";
    export var PlanningLandmarkDescription: string                            ="00686540";
    export var PlanningLandmarkIdentificationCodeSequence: string             ="00686545";
    export var TwoDPointCoordinatesSequence: string                           ="00686550";
    export var TwoDPointCoordinates: string                                   ="00686560";
    export var ThreeDPointCoordinates: string                                 ="00686590";
    export var TwoDLineCoordinatesSequence: string                            ="006865A0";
    export var TwoDLineCoordinates: string                                    ="006865B0";
    export var ThreeDLineCoordinates: string                                  ="006865D0";
    export var TwoDPlaneCoordinatesSequence: string                           ="006865E0";
    export var TwoDPlaneIntersection: string                                  ="006865F0";
    export var ThreeDPlaneOrigin: string                                      ="00686610";
    export var ThreeDPlaneNormal: string                                      ="00686620";

// *****************************************************************************************************************************
// *** 0070
// *****************************************************************************************************************************
    export var GraphicAnnotationSequence: string                              ="00700001";
    export var GraphicLayer: string                                           ="00700002";
    export var BoundingBoxAnnotationUnits: string                             ="00700003";
    export var AnchorPointAnnotationUnits: string                             ="00700004";
    export var GraphicAnnotationUnits: string                                 ="00700005";
    export var UnformattedTextValue: string                                   ="00700006";
    export var TextObjectSequence: string                                     ="00700008";
    export var GraphicObjectSequence: string                                  ="00700009";
    export var BoundingBoxTopLeftHandCorner: string                           ="00700010";
    export var BoundingBoxBottomRightHandCorner: string                       ="00700011";
    export var BoundingBoxTextHorizontalJustification: string                 ="00700012";
    export var AnchorPoint: string                                            ="00700014";
    export var AnchorPointVisibility: string                                  ="00700015";
    export var GraphicDimensions: string                                      ="00700020";
    export var NumberOfGraphicPoints: string                                  ="00700021";
    export var GraphicData: string                                            ="00700022";
    export var GraphicType: string                                            ="00700023";
    export var GraphicFilled: string                                          ="00700024";
    export var ImageRotationRetired: string                                   ="00700040";   // Retired
    export var ImageHorizontalFlip: string                                    ="00700041";
    export var ImageRotation: string                                          ="00700042";
    export var DisplayedAreaTopLeftHandCornerTrial: string                    ="00700050";   // Retired
    export var DisplayedAreaBottomRightHandCornerTrial: string                ="00700051";   // Retired
    export var DisplayedAreaTopLeftHandCorner: string                         ="00700052";
    export var DisplayedAreaBottomRightHandCorner: string                     ="00700053";
    export var DisplayedAreaSelectionSequence: string                         ="0070005A";
    export var GraphicLayerSequence: string                                   ="00700060";
    export var GraphicLayerOrder: string                                      ="00700062";
    export var GraphicLayerRecommendedDisplayGrayscaleValue: string           ="00700066";
    export var GraphicLayerRecommendedDisplayRGBValue: string                 ="00700067";   // Retired
    export var GraphicLayerDescription: string                                ="00700068";
    export var ContentLabel: string                                           ="00700080";
    export var ContentDescription: string                                     ="00700081";
    export var PresentationCreationDate: string                               ="00700082";
    export var PresentationCreationTime: string                               ="00700083";
    export var ContentCreatorName: string                                     ="00700084";
    export var ContentCreatorIdentificationCodeSequence: string               ="00700086";
    export var AlternateContentDescriptionSequence: string                    ="00700087";
    export var PresentationSizeMode: string                                   ="00700100";
    export var PresentationPixelSpacing: string                               ="00700101";
    export var PresentationPixelAspectRatio: string                           ="00700102";
    export var PresentationPixelMagnificationRatio: string                    ="00700103";
    export var GraphicGroupLabel: string                                      ="00700207";
    export var GraphicGroupDescription: string                                ="00700208";
    export var CompoundGraphicSequence: string                                ="00700209";
    export var CompoundGraphicInstanceID: string                              ="00700226";
    export var FontName: string                                               ="00700227";
    export var FontNameType: string                                           ="00700228";
    export var CSSFontName: string                                            ="00700229";
    export var RotationAngle: string                                          ="00700230";
    export var TextStyleSequence: string                                      ="00700231";
    export var LineStyleSequence: string                                      ="00700232";
    export var FillStyleSequence: string                                      ="00700233";
    export var GraphicGroupSequence: string                                   ="00700234";
    export var TextColorCIELabValue: string                                   ="00700241";
    export var HorizontalAlignment: string                                    ="00700242";
    export var VerticalAlignment: string                                      ="00700243";
    export var ShadowStyle: string                                            ="00700244";
    export var ShadowOffsetX: string                                          ="00700245";
    export var ShadowOffsetY: string                                          ="00700246";
    export var ShadowColorCIELabValue: string                                 ="00700247";
    export var Underlined: string                                             ="00700248";
    export var Bold: string                                                   ="00700249";
    export var Italic: string                                                 ="00700250";
    export var PatternOnColorCIELabValue: string                              ="00700251";
    export var PatternOffColorCIELabValue: string                             ="00700252";
    export var LineThickness: string                                          ="00700253";
    export var LineDashingStyle: string                                       ="00700254";
    export var LinePattern: string                                            ="00700255";
    export var FillPattern: string                                            ="00700256";
    export var FillMode: string                                               ="00700257";
    export var ShadowOpacity: string                                          ="00700258";
    export var GapLength: string                                              ="00700261";
    export var DiameterOfVisibility: string                                   ="00700262";
    export var RotationPoint: string                                          ="00700273";
    export var TickAlignment: string                                          ="00700274";
    export var ShowTickLabel: string                                          ="00700278";
    export var TickLabelAlignment: string                                     ="00700279";
    export var CompoundGraphicUnits: string                                   ="00700282";
    export var PatternOnOpacity: string                                       ="00700284";
    export var PatternOffOpacity: string                                      ="00700285";
    export var MajorTicksSequence: string                                     ="00700287";
    export var TickPosition: string                                           ="00700288";
    export var TickLabel: string                                              ="00700289";
    export var CompoundGraphicType: string                                    ="00700294";
    export var GraphicGroupID: string                                         ="00700295";
    export var ShapeType: string                                              ="00700306";
    export var RegistrationSequence: string                                   ="00700308";
    export var MatrixRegistrationSequence: string                             ="00700309";
    export var MatrixSequence: string                                         ="0070030A";
    export var FrameOfReferenceTransformationMatrixType: string               ="0070030C";
    export var RegistrationTypeCodeSequence: string                           ="0070030D";
    export var FiducialDescription: string                                    ="0070030F";
    export var FiducialIdentifier: string                                     ="00700310";
    export var FiducialIdentifierCodeSequence: string                         ="00700311";
    export var ContourUncertaintyRadius: string                               ="00700312";
    export var UsedFiducialsSequence: string                                  ="00700314";
    export var GraphicCoordinatesDataSequence: string                         ="00700318";
    export var FiducialUID: string                                            ="0070031A";
    export var FiducialSetSequence: string                                    ="0070031C";
    export var FiducialSequence: string                                       ="0070031E";
    export var GraphicLayerRecommendedDisplayCIELabValue: string              ="00700401";
    export var BlendingSequence: string                                       ="00700402";
    export var RelativeOpacity: string                                        ="00700403";
    export var ReferencedSpatialRegistrationSequence: string                  ="00700404";
    export var BlendingPosition: string                                       ="00700405";

// *****************************************************************************************************************************
// *** 0072
// *****************************************************************************************************************************
    export var HangingProtocolName: string                                    ="00720002";
    export var HangingProtocolDescription: string                             ="00720004";
    export var HangingProtocolLevel: string                                   ="00720006";
    export var HangingProtocolCreator: string                                 ="00720008";
    export var HangingProtocolCreationDateTime: string                        ="0072000A";
    export var HangingProtocolDefinitionSequence: string                      ="0072000C";
    export var HangingProtocolUserIdentificationCodeSequence: string          ="0072000E";
    export var HangingProtocolUserGroupName: string                           ="00720010";
    export var SourceHangingProtocolSequence: string                          ="00720012";
    export var NumberOfPriorsReferenced: string                               ="00720014";
    export var ImageSetsSequence: string                                      ="00720020";
    export var ImageSetSelectorSequence: string                               ="00720022";
    export var ImageSetSelectorUsageFlag: string                              ="00720024";
    export var SelectorAttribute: string                                      ="00720026";
    export var SelectorValueNumber: string                                    ="00720028";
    export var TimeBasedImageSetsSequence: string                             ="00720030";
    export var ImageSetNumber: string                                         ="00720032";
    export var ImageSetSelectorCategory: string                               ="00720034";
    export var RelativeTime: string                                           ="00720038";
    export var RelativeTimeUnits: string                                      ="0072003A";
    export var AbstractPriorValue: string                                     ="0072003C";
    export var AbstractPriorCodeSequence: string                              ="0072003E";
    export var ImageSetLabel: string                                          ="00720040";
    export var SelectorAttributeVR: string                                    ="00720050";
    export var SelectorSequencePointer: string                                ="00720052";
    export var SelectorSequencePointerPrivateCreator: string                  ="00720054";
    export var SelectorAttributePrivateCreator: string                        ="00720056";
    export var SelectorATValue: string                                        ="00720060";
    export var SelectorCSValue: string                                        ="00720062";
    export var SelectorISValue: string                                        ="00720064";
    export var SelectorLOValue: string                                        ="00720066";
    export var SelectorLTValue: string                                        ="00720068";
    export var SelectorPNValue: string                                        ="0072006A";
    export var SelectorSHValue: string                                        ="0072006C";
    export var SelectorSTValue: string                                        ="0072006E";
    export var SelectorUTValue: string                                        ="00720070";
    export var SelectorDSValue: string                                        ="00720072";
    export var SelectorFDValue: string                                        ="00720074";
    export var SelectorFLValue: string                                        ="00720076";
    export var SelectorULValue: string                                        ="00720078";
    export var SelectorUSValue: string                                        ="0072007A";
    export var SelectorSLValue: string                                        ="0072007C";
    export var SelectorSSValue: string                                        ="0072007E";
    export var SelectorUIValue: string                                        ="0072007F";
    export var SelectorCodeSequenceValue: string                              ="00720080";
    export var NumberOfScreens: string                                        ="00720100";
    export var NominalScreenDefinitionSequence: string                        ="00720102";
    export var NumberOfVerticalPixels: string                                 ="00720104";
    export var NumberOfHorizontalPixels: string                               ="00720106";
    export var DisplayEnvironmentSpatialPosition: string                      ="00720108";
    export var ScreenMinimumGrayscaleBitDepth: string                         ="0072010A";
    export var ScreenMinimumColorBitDepth: string                             ="0072010C";
    export var ApplicationMaximumRepaintTime: string                          ="0072010E";
    export var DisplaySetsSequence: string                                    ="00720200";
    export var DisplaySetNumber: string                                       ="00720202";
    export var DisplaySetLabel: string                                        ="00720203";
    export var DisplaySetPresentationGroup: string                            ="00720204";
    export var DisplaySetPresentationGroupDescription: string                 ="00720206";
    export var PartialDataDisplayHandling: string                             ="00720208";
    export var SynchronizedScrollingSequence: string                          ="00720210";
    export var DisplaySetScrollingGroup: string                               ="00720212";
    export var NavigationIndicatorSequence: string                            ="00720214";
    export var NavigationDisplaySet: string                                   ="00720216";
    export var ReferenceDisplaySets: string                                   ="00720218";
    export var ImageBoxesSequence: string                                     ="00720300";
    export var ImageBoxNumber: string                                         ="00720302";
    export var ImageBoxLayoutType: string                                     ="00720304";
    export var ImageBoxTileHorizontalDimension: string                        ="00720306";
    export var ImageBoxTileVerticalDimension: string                          ="00720308";
    export var ImageBoxScrollDirection: string                                ="00720310";
    export var ImageBoxSmallScrollType: string                                ="00720312";
    export var ImageBoxSmallScrollAmount: string                              ="00720314";
    export var ImageBoxLargeScrollType: string                                ="00720316";
    export var ImageBoxLargeScrollAmount: string                              ="00720318";
    export var ImageBoxOverlapPriority: string                                ="00720320";
    export var CineRelativeToRealTime: string                                 ="00720330";
    export var FilterOperationsSequence: string                               ="00720400";
    export var FilterByCategory: string                                       ="00720402";
    export var FilterByAttributePresence: string                              ="00720404";
    export var FilterByOperator: string                                       ="00720406";
    export var StructuredDisplayBackgroundCIELabValue: string                 ="00720420";
    export var EmptyImageBoxCIELabValue: string                               ="00720421";
    export var StructuredDisplayImageBoxSequence: string                      ="00720422";
    export var StructuredDisplayTextBoxSequence: string                       ="00720424";
    export var ReferencedFirstFrameSequence: string                           ="00720427";
    export var ImageBoxSynchronizationSequence: string                        ="00720430";
    export var SynchronizedImageBoxList: string                               ="00720432";
    export var TypeOfSynchronization: string                                  ="00720434";
    export var BlendingOperationType: string                                  ="00720500";
    export var ReformattingOperationType: string                              ="00720510";
    export var ReformattingThickness: string                                  ="00720512";
    export var ReformattingInterval: string                                   ="00720514";
    export var ReformattingOperationInitialViewDirection: string              ="00720516";
    export var ThreeDRenderingType: string                                    ="00720520";
    export var SortingOperationsSequence: string                              ="00720600";
    export var SortByCategory: string                                         ="00720602";
    export var SortingDirection: string                                       ="00720604";
    export var DisplaySetPatientOrientation: string                           ="00720700";
    export var VOIType: string                                                ="00720702";
    export var PseudoColorType: string                                        ="00720704";
    export var PseudoColorPaletteInstanceReferenceSequence: string            ="00720705";
    export var ShowGrayscaleInverted: string                                  ="00720706";
    export var ShowImageTrueSizeFlag: string                                  ="00720710";
    export var ShowGraphicAnnotationFlag: string                              ="00720712";
    export var ShowPatientDemographicsFlag: string                            ="00720714";
    export var ShowAcquisitionTechniquesFlag: string                          ="00720716";
    export var DisplaySetHorizontalJustification: string                      ="00720717";
    export var DisplaySetVerticalJustification: string                        ="00720718";

// *****************************************************************************************************************************
// *** 0074
// *****************************************************************************************************************************
    export var ContinuationStartMeterset: string                              ="00740120";
    export var ContinuationEndMeterset: string                                ="00740121";
    export var ProcedureStepState: string                                     ="00741000";
    export var ProcedureStepProgressInformationSequence: string               ="00741002";
    export var ProcedureStepProgress: string                                  ="00741004";
    export var ProcedureStepProgressDescription: string                       ="00741006";
    export var ProcedureStepCommunicationsURISequence: string                 ="00741008";
    export var ContactURI: string                                             ="0074100A";
    export var ContactDisplayName: string                                     ="0074100C";
    export var ProcedureStepDiscontinuationReasonCodeSequence: string         ="0074100E";
    export var BeamTaskSequence: string                                       ="00741020";
    export var BeamTaskType: string                                           ="00741022";
    export var BeamOrderIndexTrial: string                                    ="00741024";   // Retired
    export var AutosequenceFlag: string                                       ="00741025";
    export var TableTopVerticalAdjustedPosition: string                       ="00741026";
    export var TableTopLongitudinalAdjustedPosition: string                   ="00741027";
    export var TableTopLateralAdjustedPosition: string                        ="00741028";
    export var PatientSupportAdjustedAngle: string                            ="0074102A";
    export var TableTopEccentricAdjustedAngle: string                         ="0074102B";
    export var TableTopPitchAdjustedAngle: string                             ="0074102C";
    export var TableTopRollAdjustedAngle: string                              ="0074102D";
    export var DeliveryVerificationImageSequence: string                      ="00741030";
    export var VerificationImageTiming: string                                ="00741032";
    export var DoubleExposureFlag: string                                     ="00741034";
    export var DoubleExposureOrdering: string                                 ="00741036";
    export var DoubleExposureMetersetTrial: string                            ="00741038";   // Retired
    export var DoubleExposureFieldDeltaTrial: string                          ="0074103A";   // Retired
    export var RelatedReferenceRTImageSequence: string                        ="00741040";
    export var GeneralMachineVerificationSequence: string                     ="00741042";
    export var ConventionalMachineVerificationSequence: string                ="00741044";
    export var IonMachineVerificationSequence: string                         ="00741046";
    export var FailedAttributesSequence: string                               ="00741048";
    export var OverriddenAttributesSequence: string                           ="0074104A";
    export var ConventionalControlPointVerificationSequence: string           ="0074104C";
    export var IonControlPointVerificationSequence: string                    ="0074104E";
    export var AttributeOccurrenceSequence: string                            ="00741050";
    export var AttributeOccurrencePointer: string                             ="00741052";
    export var AttributeItemSelector: string                                  ="00741054";
    export var AttributeOccurrencePrivateCreator: string                      ="00741056";
    export var SelectorSequencePointerItems: string                           ="00741057";
    export var ScheduledProcedureStepPriority: string                         ="00741200";
    export var WorklistLabel: string                                          ="00741202";
    export var ProcedureStepLabel: string                                     ="00741204";
    export var ScheduledProcessingParametersSequence: string                  ="00741210";
    export var PerformedProcessingParametersSequence: string                  ="00741212";
    export var UnifiedProcedureStepPerformedProcedureSequence: string         ="00741216";
    export var RelatedProcedureStepSequence: string                           ="00741220";   // Retired
    export var ProcedureStepRelationshipType: string                          ="00741222";   // Retired
    export var ReplacedProcedureStepSequence: string                          ="00741224";
    export var DeletionLock: string                                           ="00741230";
    export var ReceivingAE: string                                            ="00741234";
    export var RequestingAE: string                                           ="00741236";
    export var ReasonForCancellation: string                                  ="00741238";
    export var SCPStatus: string                                              ="00741242";
    export var SubscriptionListStatus: string                                 ="00741244";
    export var UnifiedProcedureStepListStatus: string                         ="00741246";
    export var BeamOrderIndex: string                                         ="00741324";
    export var DoubleExposureMeterset: string                                 ="00741338";
    export var DoubleExposureFieldDelta: string                               ="0074133A";

// *****************************************************************************************************************************
// *** 0076
// *****************************************************************************************************************************
    export var ImplantAssemblyTemplateName: string                            ="00760001";
    export var ImplantAssemblyTemplateIssuer: string                          ="00760003";
    export var ImplantAssemblyTemplateVersion: string                         ="00760006";
    export var ReplacedImplantAssemblyTemplateSequence: string                ="00760008";
    export var ImplantAssemblyTemplateType: string                            ="0076000A";
    export var OriginalImplantAssemblyTemplateSequence: string                ="0076000C";
    export var DerivationImplantAssemblyTemplateSequence: string              ="0076000E";
    export var ImplantAssemblyTemplateTargetAnatomySequence: string           ="00760010";
    export var ProcedureTypeCodeSequence: string                              ="00760020";
    export var SurgicalTechnique: string                                      ="00760030";
    export var ComponentTypesSequence: string                                 ="00760032";
    export var ComponentTypeCodeSequence: string                              ="00760034";
    export var ExclusiveComponentType: string                                 ="00760036";
    export var MandatoryComponentType: string                                 ="00760038";
    export var ComponentSequence: string                                      ="00760040";
    export var ComponentID: string                                            ="00760055";
    export var ComponentAssemblySequence: string                              ="00760060";
    export var Component1ReferencedID: string                                 ="00760070";
    export var Component1ReferencedMatingFeatureSetID: string                 ="00760080";
    export var Component1ReferencedMatingFeatureID: string                    ="00760090";
    export var Component2ReferencedID: string                                 ="007600A0";
    export var Component2ReferencedMatingFeatureSetID: string                 ="007600B0";
    export var Component2ReferencedMatingFeatureID: string                    ="007600C0";

// *****************************************************************************************************************************
// *** 0078
// *****************************************************************************************************************************
    export var ImplantTemplateGroupName: string                               ="00780001";
    export var ImplantTemplateGroupDescription: string                        ="00780010";
    export var ImplantTemplateGroupIssuer: string                             ="00780020";
    export var ImplantTemplateGroupVersion: string                            ="00780024";
    export var ReplacedImplantTemplateGroupSequence: string                   ="00780026";
    export var ImplantTemplateGroupTargetAnatomySequence: string              ="00780028";
    export var ImplantTemplateGroupMembersSequence: string                    ="0078002A";
    export var ImplantTemplateGroupMemberID: string                           ="0078002E";
    export var ThreeDImplantTemplateGroupMemberMatchingPoint: string          ="00780050";
    export var ThreeDImplantTemplateGroupMemberMatchingAxes: string           ="00780060";
    export var ImplantTemplateGroupMemberMatching2DCoordinatesSequence: string ="00780070";
    export var TwoDImplantTemplateGroupMemberMatchingPoint: string            ="00780090";
    export var TwoDImplantTemplateGroupMemberMatchingAxes: string             ="007800A0";
    export var ImplantTemplateGroupVariationDimensionSequence: string         ="007800B0";
    export var ImplantTemplateGroupVariationDimensionName: string             ="007800B2";
    export var ImplantTemplateGroupVariationDimensionRankSequence: string     ="007800B4";
    export var ReferencedImplantTemplateGroupMemberID: string                 ="007800B6";
    export var ImplantTemplateGroupVariationDimensionRank: string             ="007800B8";

// *****************************************************************************************************************************
// *** 0080
// *****************************************************************************************************************************
    export var SurfaceScanAcquisitionTypeCodeSequence: string                 ="00800001";
    export var SurfaceScanModeCodeSequence: string                            ="00800002";
    export var RegistrationMethodCodeSequence: string                         ="00800003";
    export var ShotDurationTime: string                                       ="00800004";
    export var ShotOffsetTime: string                                         ="00800005";
    export var SurfacePointPresentationValueData: string                      ="00800006";
    export var SurfacePointColorCIELabValueData: string                       ="00800007";
    export var UVMappingSequence: string                                      ="00800008";
    export var TextureLabel: string                                           ="00800009";
    export var UValueData: string                                             ="00800010";
    export var VValueData: string                                             ="00800011";
    export var ReferencedTextureSequence: string                              ="00800012";
    export var ReferencedSurfaceDataSequence: string                          ="00800013";

// *****************************************************************************************************************************
// *** 0088
// *****************************************************************************************************************************
    export var StorageMediaFileSetID: string                                  ="00880130";
    export var StorageMediaFileSetUID: string                                 ="00880140";
    export var IconImageSequence: string                                      ="00880200";
    export var TopicTitle: string                                             ="00880904";   // Retired
    export var TopicSubject: string                                           ="00880906";   // Retired
    export var TopicAuthor: string                                            ="00880910";   // Retired
    export var TopicKeywords: string                                          ="00880912";   // Retired

// *****************************************************************************************************************************
// *** 0100
// *****************************************************************************************************************************
    export var SOPInstanceStatus: string                                      ="01000410";
    export var SOPAuthorizationDateTime: string                               ="01000420";
    export var SOPAuthorizationComment: string                                ="01000424";
    export var AuthorizationEquipmentCertificationNumber: string              ="01000426";

// *****************************************************************************************************************************
// *** 0400
// *****************************************************************************************************************************
    export var MACIDNumber: string                                            ="04000005";
    export var MACCalculationTransferSyntaxUID: string                        ="04000010";
    export var MACAlgorithm: string                                           ="04000015";
    export var DataElementsSigned: string                                     ="04000020";
    export var DigitalSignatureUID: string                                    ="04000100";
    export var DigitalSignatureDateTime: string                               ="04000105";
    export var CertificateType: string                                        ="04000110";
    export var CertificateOfSigner: string                                    ="04000115";
    export var Signature: string                                              ="04000120";
    export var CertifiedTimestampType: string                                 ="04000305";
    export var CertifiedTimestamp: string                                     ="04000310";
    export var DigitalSignaturePurposeCodeSequence: string                    ="04000401";
    export var ReferencedDigitalSignatureSequence: string                     ="04000402";
    export var ReferencedSOPInstanceMACSequence: string                       ="04000403";
    export var MAC: string                                                    ="04000404";
    export var EncryptedAttributesSequence: string                            ="04000500";
    export var EncryptedContentTransferSyntaxUID: string                      ="04000510";
    export var EncryptedContent: string                                       ="04000520";
    export var ModifiedAttributesSequence: string                             ="04000550";
    export var OriginalAttributesSequence: string                             ="04000561";
    export var AttributeModificationDateTime: string                          ="04000562";
    export var ModifyingSystem: string                                        ="04000563";
    export var SourceOfPreviousValues: string                                 ="04000564";
    export var ReasonForTheAttributeModification: string                      ="04000565";

// *****************************************************************************************************************************
// *** 1000
// *****************************************************************************************************************************
    export var EscapeTriplet: string                                          ="10000000";   // Retired
    export var RunLengthTriplet: string                                       ="10000001";   // Retired
    export var HuffmanTableSize: string                                       ="10000002";   // Retired
    export var HuffmanTableTriplet: string                                    ="10000003";   // Retired
    export var ShiftTableSize: string                                         ="10000004";   // Retired
    export var ShiftTableTriplet: string                                      ="10000005";   // Retired

// *****************************************************************************************************************************
// *** 1010
// *****************************************************************************************************************************
    export var ZonalMap: string                                               ="10100000";   // Retired

// *****************************************************************************************************************************
// *** 2000
// *****************************************************************************************************************************
    export var NumberOfCopies: string                                         ="20000010";
    export var PrinterConfigurationSequence: string                           ="2000001E";
    export var PrintPriority: string                                          ="20000020";
    export var MediumType: string                                             ="20000030";
    export var FilmDestination: string                                        ="20000040";
    export var FilmSessionLabel: string                                       ="20000050";
    export var MemoryAllocation: string                                       ="20000060";
    export var MaximumMemoryAllocation: string                                ="20000061";
    export var ColorImagePrintingFlag: string                                 ="20000062";   // Retired
    export var CollationFlag: string                                          ="20000063";   // Retired
    export var AnnotationFlag: string                                         ="20000065";   // Retired
    export var ImageOverlayFlag: string                                       ="20000067";   // Retired
    export var PresentationLUTFlag: string                                    ="20000069";   // Retired
    export var ImageBoxPresentationLUTFlag: string                            ="2000006A";   // Retired
    export var MemoryBitDepth: string                                         ="200000A0";
    export var PrintingBitDepth: string                                       ="200000A1";
    export var MediaInstalledSequence: string                                 ="200000A2";
    export var OtherMediaAvailableSequence: string                            ="200000A4";
    export var SupportedImageDisplayFormatsSequence: string                   ="200000A8";
    export var ReferencedFilmBoxSequence: string                              ="20000500";
    export var ReferencedStoredPrintSequence: string                          ="20000510";   // Retired

// *****************************************************************************************************************************
// *** 2010
// *****************************************************************************************************************************
    export var ImageDisplayFormat: string                                     ="20100010";
    export var AnnotationDisplayFormatID: string                              ="20100030";
    export var FilmOrientation: string                                        ="20100040";
    export var FilmSizeID: string                                             ="20100050";
    export var PrinterResolutionID: string                                    ="20100052";
    export var DefaultPrinterResolutionID: string                             ="20100054";
    export var MagnificationType: string                                      ="20100060";
    export var SmoothingType: string                                          ="20100080";
    export var DefaultMagnificationType: string                               ="201000A6";
    export var OtherMagnificationTypesAvailable: string                       ="201000A7";
    export var DefaultSmoothingType: string                                   ="201000A8";
    export var OtherSmoothingTypesAvailable: string                           ="201000A9";
    export var BorderDensity: string                                          ="20100100";
    export var EmptyImageDensity: string                                      ="20100110";
    export var MinDensity: string                                             ="20100120";
    export var MaxDensity: string                                             ="20100130";
    export var Trim: string                                                   ="20100140";
    export var ConfigurationInformation: string                               ="20100150";
    export var ConfigurationInformationDescription: string                    ="20100152";
    export var MaximumCollatedFilms: string                                   ="20100154";
    export var Illumination: string                                           ="2010015E";
    export var ReflectedAmbientLight: string                                  ="20100160";
    export var PrinterPixelSpacing: string                                    ="20100376";
    export var ReferencedFilmSessionSequence: string                          ="20100500";
    export var ReferencedImageBoxSequence: string                             ="20100510";
    export var ReferencedBasicAnnotationBoxSequence: string                   ="20100520";

// *****************************************************************************************************************************
// *** 2020
// *****************************************************************************************************************************
    export var ImageBoxPosition: string                                       ="20200010";
    export var Polarity: string                                               ="20200020";
    export var RequestedImageSize: string                                     ="20200030";
    export var RequestedDecimateCropBehavior: string                          ="20200040";
    export var RequestedResolutionID: string                                  ="20200050";
    export var RequestedImageSizeFlag: string                                 ="202000A0";
    export var DecimateCropResult: string                                     ="202000A2";
    export var BasicGrayscaleImageSequence: string                            ="20200110";
    export var BasicColorImageSequence: string                                ="20200111";
    export var ReferencedImageOverlayBoxSequence: string                      ="20200130";   // Retired
    export var ReferencedVOILUTBoxSequence: string                            ="20200140";   // Retired

// *****************************************************************************************************************************
// *** 2030
// *****************************************************************************************************************************
    export var AnnotationPosition: string                                     ="20300010";
    export var TextString: string                                             ="20300020";

// *****************************************************************************************************************************
// *** 2040
// *****************************************************************************************************************************
    export var ReferencedOverlayPlaneSequence: string                         ="20400010";   // Retired
    export var ReferencedOverlayPlaneGroups: string                           ="20400011";   // Retired
    export var OverlayPixelDataSequence: string                               ="20400020";   // Retired
    export var OverlayMagnificationType: string                               ="20400060";   // Retired
    export var OverlaySmoothingType: string                                   ="20400070";   // Retired
    export var OverlayOrImageMagnification: string                            ="20400072";   // Retired
    export var MagnifyToNumberOfColumns: string                               ="20400074";   // Retired
    export var OverlayForegroundDensity: string                               ="20400080";   // Retired
    export var OverlayBackgroundDensity: string                               ="20400082";   // Retired
    export var OverlayMode: string                                            ="20400090";   // Retired
    export var ThresholdDensity: string                                       ="20400100";   // Retired
    export var ReferencedImageBoxSequenceRetired: string                      ="20400500";   // Retired

// *****************************************************************************************************************************
// *** 2050
// *****************************************************************************************************************************
    export var PresentationLUTSequence: string                                ="20500010";
    export var PresentationLUTShape: string                                   ="20500020";
    export var ReferencedPresentationLUTSequence: string                      ="20500500";

// *****************************************************************************************************************************
// *** 2100
// *****************************************************************************************************************************
    export var PrintJobID: string                                             ="21000010";   // Retired
    export var ExecutionStatus: string                                        ="21000020";
    export var ExecutionStatusInfo: string                                    ="21000030";
    export var CreationDate: string                                           ="21000040";
    export var CreationTime: string                                           ="21000050";
    export var Originator: string                                             ="21000070";
    export var DestinationAE: string                                          ="21000140";   // Retired
    export var OwnerID: string                                                ="21000160";
    export var NumberOfFilms: string                                          ="21000170";
    export var ReferencedPrintJobSequencePullStoredPrint: string              ="21000500";   // Retired

// *****************************************************************************************************************************
// *** 2110
// *****************************************************************************************************************************
    export var PrinterStatus: string                                          ="21100010";
    export var PrinterStatusInfo: string                                      ="21100020";
    export var PrinterName: string                                            ="21100030";
    export var PrintQueueID: string                                           ="21100099";   // Retired

// *****************************************************************************************************************************
// *** 2120
// *****************************************************************************************************************************
    export var QueueStatus: string                                            ="21200010";   // Retired
    export var PrintJobDescriptionSequence: string                            ="21200050";   // Retired
    export var ReferencedPrintJobSequence: string                             ="21200070";   // Retired

// *****************************************************************************************************************************
// *** 2130
// *****************************************************************************************************************************
    export var PrintManagementCapabilitiesSequence: string                    ="21300010";   // Retired
    export var PrinterCharacteristicsSequence: string                         ="21300015";   // Retired
    export var FilmBoxContentSequence: string                                 ="21300030";   // Retired
    export var ImageBoxContentSequence: string                                ="21300040";   // Retired
    export var AnnotationContentSequence: string                              ="21300050";   // Retired
    export var ImageOverlayBoxContentSequence: string                         ="21300060";   // Retired
    export var PresentationLUTContentSequence: string                         ="21300080";   // Retired
    export var ProposedStudySequence: string                                  ="213000A0";   // Retired
    export var OriginalImageSequence: string                                  ="213000C0";   // Retired

// *****************************************************************************************************************************
// *** 2200
// *****************************************************************************************************************************
    export var LabelUsingInformationExtractedFromInstances: string            ="22000001";
    export var LabelText: string                                              ="22000002";
    export var LabelStyleSelection: string                                    ="22000003";
    export var MediaDisposition: string                                       ="22000004";
    export var BarcodeValue: string                                           ="22000005";
    export var BarcodeSymbology: string                                       ="22000006";
    export var AllowMediaSplitting: string                                    ="22000007";
    export var IncludeNonDICOMObjects: string                                 ="22000008";
    export var IncludeDisplayApplication: string                              ="22000009";
    export var PreserveCompositeInstancesAfterMediaCreation: string           ="2200000A";
    export var TotalNumberOfPiecesOfMediaCreated: string                      ="2200000B";
    export var RequestedMediaApplicationProfile: string                       ="2200000C";
    export var ReferencedStorageMediaSequence: string                         ="2200000D";
    export var FailureAttributes: string                                      ="2200000E";
    export var AllowLossyCompression: string                                  ="2200000F";
    export var RequestPriority: string                                        ="22000020";

// *****************************************************************************************************************************
// *** 3002
// *****************************************************************************************************************************
    export var RTImageLabel: string                                           ="30020002";
    export var RTImageName: string                                            ="30020003";
    export var RTImageDescription: string                                     ="30020004";
    export var ReportedValuesOrigin: string                                   ="3002000A";
    export var RTImagePlane: string                                           ="3002000C";
    export var XRayImageReceptorTranslation: string                           ="3002000D";
    export var XRayImageReceptorAngle: string                                 ="3002000E";
    export var RTImageOrientation: string                                     ="30020010";
    export var ImagePlanePixelSpacing: string                                 ="30020011";
    export var RTImagePosition: string                                        ="30020012";
    export var RadiationMachineName: string                                   ="30020020";
    export var RadiationMachineSAD: string                                    ="30020022";
    export var RadiationMachineSSD: string                                    ="30020024";
    export var RTImageSID: string                                             ="30020026";
    export var SourceToReferenceObjectDistance: string                        ="30020028";
    export var FractionNumber: string                                         ="30020029";
    export var ExposureSequence: string                                       ="30020030";
    export var MetersetExposure: string                                       ="30020032";
    export var DiaphragmPosition: string                                      ="30020034";
    export var FluenceMapSequence: string                                     ="30020040";
    export var FluenceDataSource: string                                      ="30020041";
    export var FluenceDataScale: string                                       ="30020042";
    export var PrimaryFluenceModeSequence: string                             ="30020050";
    export var FluenceMode: string                                            ="30020051";
    export var FluenceModeID: string                                          ="30020052";

// *****************************************************************************************************************************
// *** 3004
// *****************************************************************************************************************************
    export var DVHType: string                                                ="30040001";
    export var DoseUnits: string                                              ="30040002";
    export var DoseType: string                                               ="30040004";
    export var SpatialTransformOfDose: string                                 ="30040005";
    export var DoseComment: string                                            ="30040006";
    export var NormalizationPoint: string                                     ="30040008";
    export var DoseSummationType: string                                      ="3004000A";
    export var GridFrameOffsetVector: string                                  ="3004000C";
    export var DoseGridScaling: string                                        ="3004000E";
    export var RTDoseROISequence: string                                      ="30040010";
    export var DoseValue: string                                              ="30040012";
    export var TissueHeterogeneityCorrection: string                          ="30040014";
    export var DVHNormalizationPoint: string                                  ="30040040";
    export var DVHNormalizationDoseValue: string                              ="30040042";
    export var DVHSequence: string                                            ="30040050";
    export var DVHDoseScaling: string                                         ="30040052";
    export var DVHVolumeUnits: string                                         ="30040054";
    export var DVHNumberOfBins: string                                        ="30040056";
    export var DVHData: string                                                ="30040058";
    export var DVHReferencedROISequence: string                               ="30040060";
    export var DVHROIContributionType: string                                 ="30040062";
    export var DVHMinimumDose: string                                         ="30040070";
    export var DVHMaximumDose: string                                         ="30040072";
    export var DVHMeanDose: string                                            ="30040074";

// *****************************************************************************************************************************
// *** 3006
// *****************************************************************************************************************************
    export var StructureSetLabel: string                                      ="30060002";
    export var StructureSetName: string                                       ="30060004";
    export var StructureSetDescription: string                                ="30060006";
    export var StructureSetDate: string                                       ="30060008";
    export var StructureSetTime: string                                       ="30060009";
    export var ReferencedFrameOfReferenceSequence: string                     ="30060010";
    export var RTReferencedStudySequence: string                              ="30060012";
    export var RTReferencedSeriesSequence: string                             ="30060014";
    export var ContourImageSequence: string                                   ="30060016";
    export var PredecessorStructureSetSequence: string                        ="30060018";
    export var StructureSetROISequence: string                                ="30060020";
    export var ROINumber: string                                              ="30060022";
    export var ReferencedFrameOfReferenceUID: string                          ="30060024";
    export var ROIName: string                                                ="30060026";
    export var ROIDescription: string                                         ="30060028";
    export var ROIDisplayColor: string                                        ="3006002A";
    export var ROIVolume: string                                              ="3006002C";
    export var RTRelatedROISequence: string                                   ="30060030";
    export var RTROIRelationship: string                                      ="30060033";
    export var ROIGenerationAlgorithm: string                                 ="30060036";
    export var ROIGenerationDescription: string                               ="30060038";
    export var ROIContourSequence: string                                     ="30060039";
    export var ContourSequence: string                                        ="30060040";
    export var ContourGeometricType: string                                   ="30060042";
    export var ContourSlabThickness: string                                   ="30060044";
    export var ContourOffsetVector: string                                    ="30060045";
    export var NumberOfContourPoints: string                                  ="30060046";
    export var ContourNumber: string                                          ="30060048";
    export var AttachedContours: string                                       ="30060049";
    export var ContourData: string                                            ="30060050";
    export var RTROIObservationsSequence: string                              ="30060080";
    export var ObservationNumber: string                                      ="30060082";
    export var ReferencedROINumber: string                                    ="30060084";
    export var ROIObservationLabel: string                                    ="30060085";
    export var RTROIIdentificationCodeSequence: string                        ="30060086";
    export var ROIObservationDescription: string                              ="30060088";
    export var RelatedRTROIObservationsSequence: string                       ="300600A0";
    export var RTROIInterpretedType: string                                   ="300600A4";
    export var ROIInterpreter: string                                         ="300600A6";
    export var ROIPhysicalPropertiesSequence: string                          ="300600B0";
    export var ROIPhysicalProperty: string                                    ="300600B2";
    export var ROIPhysicalPropertyValue: string                               ="300600B4";
    export var ROIElementalCompositionSequence: string                        ="300600B6";
    export var ROIElementalCompositionAtomicNumber: string                    ="300600B7";
    export var ROIElementalCompositionAtomicMassFraction: string              ="300600B8";
    export var AdditionalRTROIIdentificationCodeSequence: string              ="300600B9";
    export var FrameOfReferenceRelationshipSequence: string                   ="300600C0";   // Retired
    export var RelatedFrameOfReferenceUID: string                             ="300600C2";   // Retired
    export var FrameOfReferenceTransformationType: string                     ="300600C4";   // Retired
    export var FrameOfReferenceTransformationMatrix: string                   ="300600C6";
    export var FrameOfReferenceTransformationComment: string                  ="300600C8";

// *****************************************************************************************************************************
// *** 3008
// *****************************************************************************************************************************
    export var MeasuredDoseReferenceSequence: string                          ="30080010";
    export var MeasuredDoseDescription: string                                ="30080012";
    export var MeasuredDoseType: string                                       ="30080014";
    export var MeasuredDoseValue: string                                      ="30080016";
    export var TreatmentSessionBeamSequence: string                           ="30080020";
    export var TreatmentSessionIonBeamSequence: string                        ="30080021";
    export var CurrentFractionNumber: string                                  ="30080022";
    export var TreatmentControlPointDate: string                              ="30080024";
    export var TreatmentControlPointTime: string                              ="30080025";
    export var TreatmentTerminationStatus: string                             ="3008002A";
    export var TreatmentTerminationCode: string                               ="3008002B";
    export var TreatmentVerificationStatus: string                            ="3008002C";
    export var ReferencedTreatmentRecordSequence: string                      ="30080030";
    export var SpecifiedPrimaryMeterset: string                               ="30080032";
    export var SpecifiedSecondaryMeterset: string                             ="30080033";
    export var DeliveredPrimaryMeterset: string                               ="30080036";
    export var DeliveredSecondaryMeterset: string                             ="30080037";
    export var SpecifiedTreatmentTime: string                                 ="3008003A";
    export var DeliveredTreatmentTime: string                                 ="3008003B";
    export var ControlPointDeliverySequence: string                           ="30080040";
    export var IonControlPointDeliverySequence: string                        ="30080041";
    export var SpecifiedMeterset: string                                      ="30080042";
    export var DeliveredMeterset: string                                      ="30080044";
    export var MetersetRateSet: string                                        ="30080045";
    export var MetersetRateDelivered: string                                  ="30080046";
    export var ScanSpotMetersetsDelivered: string                             ="30080047";
    export var DoseRateDelivered: string                                      ="30080048";
    export var TreatmentSummaryCalculatedDoseReferenceSequence: string        ="30080050";
    export var CumulativeDoseToDoseReference: string                          ="30080052";
    export var FirstTreatmentDate: string                                     ="30080054";
    export var MostRecentTreatmentDate: string                                ="30080056";
    export var NumberOfFractionsDelivered: string                             ="3008005A";
    export var OverrideSequence: string                                       ="30080060";
    export var ParameterSequencePointer: string                               ="30080061";
    export var OverrideParameterPointer: string                               ="30080062";
    export var ParameterItemIndex: string                                     ="30080063";
    export var MeasuredDoseReferenceNumber: string                            ="30080064";
    export var ParameterPointer: string                                       ="30080065";
    export var OverrideReason: string                                         ="30080066";
    export var CorrectedParameterSequence: string                             ="30080068";
    export var CorrectionValue: string                                        ="3008006A";
    export var CalculatedDoseReferenceSequence: string                        ="30080070";
    export var CalculatedDoseReferenceNumber: string                          ="30080072";
    export var CalculatedDoseReferenceDescription: string                     ="30080074";
    export var CalculatedDoseReferenceDoseValue: string                       ="30080076";
    export var StartMeterset: string                                          ="30080078";
    export var EndMeterset: string                                            ="3008007A";
    export var ReferencedMeasuredDoseReferenceSequence: string                ="30080080";
    export var ReferencedMeasuredDoseReferenceNumber: string                  ="30080082";
    export var ReferencedCalculatedDoseReferenceSequence: string              ="30080090";
    export var ReferencedCalculatedDoseReferenceNumber: string                ="30080092";
    export var BeamLimitingDeviceLeafPairsSequence: string                    ="300800A0";
    export var RecordedWedgeSequence: string                                  ="300800B0";
    export var RecordedCompensatorSequence: string                            ="300800C0";
    export var RecordedBlockSequence: string                                  ="300800D0";
    export var TreatmentSummaryMeasuredDoseReferenceSequence: string          ="300800E0";
    export var RecordedSnoutSequence: string                                  ="300800F0";
    export var RecordedRangeShifterSequence: string                           ="300800F2";
    export var RecordedLateralSpreadingDeviceSequence: string                 ="300800F4";
    export var RecordedRangeModulatorSequence: string                         ="300800F6";
    export var RecordedSourceSequence: string                                 ="30080100";
    export var SourceSerialNumber: string                                     ="30080105";
    export var TreatmentSessionApplicationSetupSequence: string               ="30080110";
    export var ApplicationSetupCheck: string                                  ="30080116";
    export var RecordedBrachyAccessoryDeviceSequence: string                  ="30080120";
    export var ReferencedBrachyAccessoryDeviceNumber: string                  ="30080122";
    export var RecordedChannelSequence: string                                ="30080130";
    export var SpecifiedChannelTotalTime: string                              ="30080132";
    export var DeliveredChannelTotalTime: string                              ="30080134";
    export var SpecifiedNumberOfPulses: string                                ="30080136";
    export var DeliveredNumberOfPulses: string                                ="30080138";
    export var SpecifiedPulseRepetitionInterval: string                       ="3008013A";
    export var DeliveredPulseRepetitionInterval: string                       ="3008013C";
    export var RecordedSourceApplicatorSequence: string                       ="30080140";
    export var ReferencedSourceApplicatorNumber: string                       ="30080142";
    export var RecordedChannelShieldSequence: string                          ="30080150";
    export var ReferencedChannelShieldNumber: string                          ="30080152";
    export var BrachyControlPointDeliveredSequence: string                    ="30080160";
    export var SafePositionExitDate: string                                   ="30080162";
    export var SafePositionExitTime: string                                   ="30080164";
    export var SafePositionReturnDate: string                                 ="30080166";
    export var SafePositionReturnTime: string                                 ="30080168";
    export var PulseSpecificBrachyControlPointDeliveredSequence: string       ="30080171";
    export var PulseNumber: string                                            ="30080172";
    export var BrachyPulseControlPointDeliveredSequence: string               ="30080173";
    export var CurrentTreatmentStatus: string                                 ="30080200";
    export var TreatmentStatusComment: string                                 ="30080202";
    export var FractionGroupSummarySequence: string                           ="30080220";
    export var ReferencedFractionNumber: string                               ="30080223";
    export var FractionGroupType: string                                      ="30080224";
    export var BeamStopperPosition: string                                    ="30080230";
    export var FractionStatusSummarySequence: string                          ="30080240";
    export var TreatmentDate: string                                          ="30080250";
    export var TreatmentTime: string                                          ="30080251";

// *****************************************************************************************************************************
// *** 300A
// *****************************************************************************************************************************
    export var RTPlanLabel: string                                            ="300A0002";
    export var RTPlanName: string                                             ="300A0003";
    export var RTPlanDescription: string                                      ="300A0004";
    export var RTPlanDate: string                                             ="300A0006";
    export var RTPlanTime: string                                             ="300A0007";
    export var TreatmentProtocols: string                                     ="300A0009";
    export var PlanIntent: string                                             ="300A000A";
    export var TreatmentSites: string                                         ="300A000B";
    export var RTPlanGeometry: string                                         ="300A000C";
    export var PrescriptionDescription: string                                ="300A000E";
    export var DoseReferenceSequence: string                                  ="300A0010";
    export var DoseReferenceNumber: string                                    ="300A0012";
    export var DoseReferenceUID: string                                       ="300A0013";
    export var DoseReferenceStructureType: string                             ="300A0014";
    export var NominalBeamEnergyUnit: string                                  ="300A0015";
    export var DoseReferenceDescription: string                               ="300A0016";
    export var DoseReferencePointCoordinates: string                          ="300A0018";
    export var NominalPriorDose: string                                       ="300A001A";
    export var DoseReferenceType: string                                      ="300A0020";
    export var ConstraintWeight: string                                       ="300A0021";
    export var DeliveryWarningDose: string                                    ="300A0022";
    export var DeliveryMaximumDose: string                                    ="300A0023";
    export var TargetMinimumDose: string                                      ="300A0025";
    export var TargetPrescriptionDose: string                                 ="300A0026";
    export var TargetMaximumDose: string                                      ="300A0027";
    export var TargetUnderdoseVolumeFraction: string                          ="300A0028";
    export var OrganAtRiskFullVolumeDose: string                              ="300A002A";
    export var OrganAtRiskLimitDose: string                                   ="300A002B";
    export var OrganAtRiskMaximumDose: string                                 ="300A002C";
    export var OrganAtRiskOverdoseVolumeFraction: string                      ="300A002D";
    export var ToleranceTableSequence: string                                 ="300A0040";
    export var ToleranceTableNumber: string                                   ="300A0042";
    export var ToleranceTableLabel: string                                    ="300A0043";
    export var GantryAngleTolerance: string                                   ="300A0044";
    export var BeamLimitingDeviceAngleTolerance: string                       ="300A0046";
    export var BeamLimitingDeviceToleranceSequence: string                    ="300A0048";
    export var BeamLimitingDevicePositionTolerance: string                    ="300A004A";
    export var SnoutPositionTolerance: string                                 ="300A004B";
    export var PatientSupportAngleTolerance: string                           ="300A004C";
    export var TableTopEccentricAngleTolerance: string                        ="300A004E";
    export var TableTopPitchAngleTolerance: string                            ="300A004F";
    export var TableTopRollAngleTolerance: string                             ="300A0050";
    export var TableTopVerticalPositionTolerance: string                      ="300A0051";
    export var TableTopLongitudinalPositionTolerance: string                  ="300A0052";
    export var TableTopLateralPositionTolerance: string                       ="300A0053";
    export var RTPlanRelationship: string                                     ="300A0055";
    export var FractionGroupSequence: string                                  ="300A0070";
    export var FractionGroupNumber: string                                    ="300A0071";
    export var FractionGroupDescription: string                               ="300A0072";
    export var NumberOfFractionsPlanned: string                               ="300A0078";
    export var NumberOfFractionPatternDigitsPerDay: string                    ="300A0079";
    export var RepeatFractionCycleLength: string                              ="300A007A";
    export var FractionPattern: string                                        ="300A007B";
    export var NumberOfBeams: string                                          ="300A0080";
    export var BeamDoseSpecificationPoint: string                             ="300A0082";
    export var BeamDose: string                                               ="300A0084";
    export var BeamMeterset: string                                           ="300A0086";
    export var BeamDosePointDepth: string                                     ="300A0088";   // Retired
    export var BeamDosePointEquivalentDepth: string                           ="300A0089";   // Retired
    export var BeamDosePointSSD: string                                       ="300A008A";   // Retired
    export var BeamDoseMeaning: string                                        ="300A008B";
    export var BeamDoseVerificationControlPointSequence: string               ="300A008C";
    export var AverageBeamDosePointDepth: string                              ="300A008D";
    export var AverageBeamDosePointEquivalentDepth: string                    ="300A008E";
    export var AverageBeamDosePointSSD: string                                ="300A008F";
    export var NumberOfBrachyApplicationSetups: string                        ="300A00A0";
    export var BrachyApplicationSetupDoseSpecificationPoint: string           ="300A00A2";
    export var BrachyApplicationSetupDose: string                             ="300A00A4";
    export var BeamSequence: string                                           ="300A00B0";
    export var TreatmentMachineName: string                                   ="300A00B2";
    export var PrimaryDosimeterUnit: string                                   ="300A00B3";
    export var SourceAxisDistance: string                                     ="300A00B4";
    export var BeamLimitingDeviceSequence: string                             ="300A00B6";
    export var RTBeamLimitingDeviceType: string                               ="300A00B8";
    export var SourceToBeamLimitingDeviceDistance: string                     ="300A00BA";
    export var IsocenterToBeamLimitingDeviceDistance: string                  ="300A00BB";
    export var NumberOfLeafJawPairs: string                                   ="300A00BC";
    export var LeafPositionBoundaries: string                                 ="300A00BE";
    export var BeamNumber: string                                             ="300A00C0";
    export var BeamName: string                                               ="300A00C2";
    export var BeamDescription: string                                        ="300A00C3";
    export var BeamType: string                                               ="300A00C4";
    export var BeamDeliveryDurationLimit: string                              ="300A00C5";
    export var RadiationType: string                                          ="300A00C6";
    export var HighDoseTechniqueType: string                                  ="300A00C7";
    export var ReferenceImageNumber: string                                   ="300A00C8";
    export var PlannedVerificationImageSequence: string                       ="300A00CA";
    export var ImagingDeviceSpecificAcquisitionParameters: string             ="300A00CC";
    export var TreatmentDeliveryType: string                                  ="300A00CE";
    export var NumberOfWedges: string                                         ="300A00D0";
    export var WedgeSequence: string                                          ="300A00D1";
    export var WedgeNumber: string                                            ="300A00D2";
    export var WedgeType: string                                              ="300A00D3";
    export var WedgeID: string                                                ="300A00D4";
    export var WedgeAngle: string                                             ="300A00D5";
    export var WedgeFactor: string                                            ="300A00D6";
    export var TotalWedgeTrayWaterEquivalentThickness: string                 ="300A00D7";
    export var WedgeOrientation: string                                       ="300A00D8";
    export var IsocenterToWedgeTrayDistance: string                           ="300A00D9";
    export var SourceToWedgeTrayDistance: string                              ="300A00DA";
    export var WedgeThinEdgePosition: string                                  ="300A00DB";
    export var BolusID: string                                                ="300A00DC";
    export var BolusDescription: string                                       ="300A00DD";
    export var EffectiveWedgeAngle: string                                    ="300A00DE";
    export var NumberOfCompensators: string                                   ="300A00E0";
    export var MaterialID: string                                             ="300A00E1";
    export var TotalCompensatorTrayFactor: string                             ="300A00E2";
    export var CompensatorSequence: string                                    ="300A00E3";
    export var CompensatorNumber: string                                      ="300A00E4";
    export var CompensatorID: string                                          ="300A00E5";
    export var SourceToCompensatorTrayDistance: string                        ="300A00E6";
    export var CompensatorRows: string                                        ="300A00E7";
    export var CompensatorColumns: string                                     ="300A00E8";
    export var CompensatorPixelSpacing: string                                ="300A00E9";
    export var CompensatorPosition: string                                    ="300A00EA";
    export var CompensatorTransmissionData: string                            ="300A00EB";
    export var CompensatorThicknessData: string                               ="300A00EC";
    export var NumberOfBoli: string                                           ="300A00ED";
    export var CompensatorType: string                                        ="300A00EE";
    export var CompensatorTrayID: string                                      ="300A00EF";
    export var NumberOfBlocks: string                                         ="300A00F0";
    export var TotalBlockTrayFactor: string                                   ="300A00F2";
    export var TotalBlockTrayWaterEquivalentThickness: string                 ="300A00F3";
    export var BlockSequence: string                                          ="300A00F4";
    export var BlockTrayID: string                                            ="300A00F5";
    export var SourceToBlockTrayDistance: string                              ="300A00F6";
    export var IsocenterToBlockTrayDistance: string                           ="300A00F7";
    export var BlockType: string                                              ="300A00F8";
    export var AccessoryCode: string                                          ="300A00F9";
    export var BlockDivergence: string                                        ="300A00FA";
    export var BlockMountingPosition: string                                  ="300A00FB";
    export var BlockNumber: string                                            ="300A00FC";
    export var BlockName: string                                              ="300A00FE";
    export var BlockThickness: string                                         ="300A0100";
    export var BlockTransmission: string                                      ="300A0102";
    export var BlockNumberOfPoints: string                                    ="300A0104";
    export var BlockData: string                                              ="300A0106";
    export var ApplicatorSequence: string                                     ="300A0107";
    export var ApplicatorID: string                                           ="300A0108";
    export var ApplicatorType: string                                         ="300A0109";
    export var ApplicatorDescription: string                                  ="300A010A";
    export var CumulativeDoseReferenceCoefficient: string                     ="300A010C";
    export var FinalCumulativeMetersetWeight: string                          ="300A010E";
    export var NumberOfControlPoints: string                                  ="300A0110";
    export var ControlPointSequence: string                                   ="300A0111";
    export var ControlPointIndex: string                                      ="300A0112";
    export var NominalBeamEnergy: string                                      ="300A0114";
    export var DoseRateSet: string                                            ="300A0115";
    export var WedgePositionSequence: string                                  ="300A0116";
    export var WedgePosition: string                                          ="300A0118";
    export var BeamLimitingDevicePositionSequence: string                     ="300A011A";
    export var LeafJawPositions: string                                       ="300A011C";
    export var GantryAngle: string                                            ="300A011E";
    export var GantryRotationDirection: string                                ="300A011F";
    export var BeamLimitingDeviceAngle: string                                ="300A0120";
    export var BeamLimitingDeviceRotationDirection: string                    ="300A0121";
    export var PatientSupportAngle: string                                    ="300A0122";
    export var PatientSupportRotationDirection: string                        ="300A0123";
    export var TableTopEccentricAxisDistance: string                          ="300A0124";
    export var TableTopEccentricAngle: string                                 ="300A0125";
    export var TableTopEccentricRotationDirection: string                     ="300A0126";
    export var TableTopVerticalPosition: string                               ="300A0128";
    export var TableTopLongitudinalPosition: string                           ="300A0129";
    export var TableTopLateralPosition: string                                ="300A012A";
    export var IsocenterPosition: string                                      ="300A012C";
    export var SurfaceEntryPoint: string                                      ="300A012E";
    export var SourceToSurfaceDistance: string                                ="300A0130";
    export var AverageBeamDosePointSourceToExternalContourSurfaceDistance: string ="300A0131";
    export var SourceToExternalContourDistance: string                        ="300A0132";
    export var ExternalContourEntryPoint: string                              ="300A0133";
    export var CumulativeMetersetWeight: string                               ="300A0134";
    export var TableTopPitchAngle: string                                     ="300A0140";
    export var TableTopPitchRotationDirection: string                         ="300A0142";
    export var TableTopRollAngle: string                                      ="300A0144";
    export var TableTopRollRotationDirection: string                          ="300A0146";
    export var HeadFixationAngle: string                                      ="300A0148";
    export var GantryPitchAngle: string                                       ="300A014A";
    export var GantryPitchRotationDirection: string                           ="300A014C";
    export var GantryPitchAngleTolerance: string                              ="300A014E";
    export var PatientSetupSequence: string                                   ="300A0180";
    export var PatientSetupNumber: string                                     ="300A0182";
    export var PatientSetupLabel: string                                      ="300A0183";
    export var PatientAdditionalPosition: string                              ="300A0184";
    export var FixationDeviceSequence: string                                 ="300A0190";
    export var FixationDeviceType: string                                     ="300A0192";
    export var FixationDeviceLabel: string                                    ="300A0194";
    export var FixationDeviceDescription: string                              ="300A0196";
    export var FixationDevicePosition: string                                 ="300A0198";
    export var FixationDevicePitchAngle: string                               ="300A0199";
    export var FixationDeviceRollAngle: string                                ="300A019A";
    export var ShieldingDeviceSequence: string                                ="300A01A0";
    export var ShieldingDeviceType: string                                    ="300A01A2";
    export var ShieldingDeviceLabel: string                                   ="300A01A4";
    export var ShieldingDeviceDescription: string                             ="300A01A6";
    export var ShieldingDevicePosition: string                                ="300A01A8";
    export var SetupTechnique: string                                         ="300A01B0";
    export var SetupTechniqueDescription: string                              ="300A01B2";
    export var SetupDeviceSequence: string                                    ="300A01B4";
    export var SetupDeviceType: string                                        ="300A01B6";
    export var SetupDeviceLabel: string                                       ="300A01B8";
    export var SetupDeviceDescription: string                                 ="300A01BA";
    export var SetupDeviceParameter: string                                   ="300A01BC";
    export var SetupReferenceDescription: string                              ="300A01D0";
    export var TableTopVerticalSetupDisplacement: string                      ="300A01D2";
    export var TableTopLongitudinalSetupDisplacement: string                  ="300A01D4";
    export var TableTopLateralSetupDisplacement: string                       ="300A01D6";
    export var BrachyTreatmentTechnique: string                               ="300A0200";
    export var BrachyTreatmentType: string                                    ="300A0202";
    export var TreatmentMachineSequence: string                               ="300A0206";
    export var SourceSequence: string                                         ="300A0210";
    export var SourceNumber: string                                           ="300A0212";
    export var SourceType: string                                             ="300A0214";
    export var SourceManufacturer: string                                     ="300A0216";
    export var ActiveSourceDiameter: string                                   ="300A0218";
    export var ActiveSourceLength: string                                     ="300A021A";
    export var SourceModelID: string                                          ="300A021B";
    export var SourceDescription: string                                      ="300A021C";
    export var SourceEncapsulationNominalThickness: string                    ="300A0222";
    export var SourceEncapsulationNominalTransmission: string                 ="300A0224";
    export var SourceIsotopeName: string                                      ="300A0226";
    export var SourceIsotopeHalfLife: string                                  ="300A0228";
    export var SourceStrengthUnits: string                                    ="300A0229";
    export var ReferenceAirKermaRate: string                                  ="300A022A";
    export var SourceStrength: string                                         ="300A022B";
    export var SourceStrengthReferenceDate: string                            ="300A022C";
    export var SourceStrengthReferenceTime: string                            ="300A022E";
    export var ApplicationSetupSequence: string                               ="300A0230";
    export var ApplicationSetupType: string                                   ="300A0232";
    export var ApplicationSetupNumber: string                                 ="300A0234";
    export var ApplicationSetupName: string                                   ="300A0236";
    export var ApplicationSetupManufacturer: string                           ="300A0238";
    export var TemplateNumber: string                                         ="300A0240";
    export var TemplateType: string                                           ="300A0242";
    export var TemplateName: string                                           ="300A0244";
    export var TotalReferenceAirKerma: string                                 ="300A0250";
    export var BrachyAccessoryDeviceSequence: string                          ="300A0260";
    export var BrachyAccessoryDeviceNumber: string                            ="300A0262";
    export var BrachyAccessoryDeviceID: string                                ="300A0263";
    export var BrachyAccessoryDeviceType: string                              ="300A0264";
    export var BrachyAccessoryDeviceName: string                              ="300A0266";
    export var BrachyAccessoryDeviceNominalThickness: string                  ="300A026A";
    export var BrachyAccessoryDeviceNominalTransmission: string               ="300A026C";
    export var ChannelSequence: string                                        ="300A0280";
    export var ChannelNumber: string                                          ="300A0282";
    export var ChannelLength: string                                          ="300A0284";
    export var ChannelTotalTime: string                                       ="300A0286";
    export var SourceMovementType: string                                     ="300A0288";
    export var NumberOfPulses: string                                         ="300A028A";
    export var PulseRepetitionInterval: string                                ="300A028C";
    export var SourceApplicatorNumber: string                                 ="300A0290";
    export var SourceApplicatorID: string                                     ="300A0291";
    export var SourceApplicatorType: string                                   ="300A0292";
    export var SourceApplicatorName: string                                   ="300A0294";
    export var SourceApplicatorLength: string                                 ="300A0296";
    export var SourceApplicatorManufacturer: string                           ="300A0298";
    export var SourceApplicatorWallNominalThickness: string                   ="300A029C";
    export var SourceApplicatorWallNominalTransmission: string                ="300A029E";
    export var SourceApplicatorStepSize: string                               ="300A02A0";
    export var TransferTubeNumber: string                                     ="300A02A2";
    export var TransferTubeLength: string                                     ="300A02A4";
    export var ChannelShieldSequence: string                                  ="300A02B0";
    export var ChannelShieldNumber: string                                    ="300A02B2";
    export var ChannelShieldID: string                                        ="300A02B3";
    export var ChannelShieldName: string                                      ="300A02B4";
    export var ChannelShieldNominalThickness: string                          ="300A02B8";
    export var ChannelShieldNominalTransmission: string                       ="300A02BA";
    export var FinalCumulativeTimeWeight: string                              ="300A02C8";
    export var BrachyControlPointSequence: string                             ="300A02D0";
    export var ControlPointRelativePosition: string                           ="300A02D2";
    export var ControlPoint3DPosition: string                                 ="300A02D4";
    export var CumulativeTimeWeight: string                                   ="300A02D6";
    export var CompensatorDivergence: string                                  ="300A02E0";
    export var CompensatorMountingPosition: string                            ="300A02E1";
    export var SourceToCompensatorDistance: string                            ="300A02E2";
    export var TotalCompensatorTrayWaterEquivalentThickness: string           ="300A02E3";
    export var IsocenterToCompensatorTrayDistance: string                     ="300A02E4";
    export var CompensatorColumnOffset: string                                ="300A02E5";
    export var IsocenterToCompensatorDistances: string                        ="300A02E6";
    export var CompensatorRelativeStoppingPowerRatio: string                  ="300A02E7";
    export var CompensatorMillingToolDiameter: string                         ="300A02E8";
    export var IonRangeCompensatorSequence: string                            ="300A02EA";
    export var CompensatorDescription: string                                 ="300A02EB";
    export var RadiationMassNumber: string                                    ="300A0302";
    export var RadiationAtomicNumber: string                                  ="300A0304";
    export var RadiationChargeState: string                                   ="300A0306";
    export var ScanMode: string                                               ="300A0308";
    export var VirtualSourceAxisDistances: string                             ="300A030A";
    export var SnoutSequence: string                                          ="300A030C";
    export var SnoutPosition: string                                          ="300A030D";
    export var SnoutID: string                                                ="300A030F";
    export var NumberOfRangeShifters: string                                  ="300A0312";
    export var RangeShifterSequence: string                                   ="300A0314";
    export var RangeShifterNumber: string                                     ="300A0316";
    export var RangeShifterID: string                                         ="300A0318";
    export var RangeShifterType: string                                       ="300A0320";
    export var RangeShifterDescription: string                                ="300A0322";
    export var NumberOfLateralSpreadingDevices: string                        ="300A0330";
    export var LateralSpreadingDeviceSequence: string                         ="300A0332";
    export var LateralSpreadingDeviceNumber: string                           ="300A0334";
    export var LateralSpreadingDeviceID: string                               ="300A0336";
    export var LateralSpreadingDeviceType: string                             ="300A0338";
    export var LateralSpreadingDeviceDescription: string                      ="300A033A";
    export var LateralSpreadingDeviceWaterEquivalentThickness: string         ="300A033C";
    export var NumberOfRangeModulators: string                                ="300A0340";
    export var RangeModulatorSequence: string                                 ="300A0342";
    export var RangeModulatorNumber: string                                   ="300A0344";
    export var RangeModulatorID: string                                       ="300A0346";
    export var RangeModulatorType: string                                     ="300A0348";
    export var RangeModulatorDescription: string                              ="300A034A";
    export var BeamCurrentModulationID: string                                ="300A034C";
    export var PatientSupportType: string                                     ="300A0350";
    export var PatientSupportID: string                                       ="300A0352";
    export var PatientSupportAccessoryCode: string                            ="300A0354";
    export var FixationLightAzimuthalAngle: string                            ="300A0356";
    export var FixationLightPolarAngle: string                                ="300A0358";
    export var MetersetRate: string                                           ="300A035A";
    export var RangeShifterSettingsSequence: string                           ="300A0360";
    export var RangeShifterSetting: string                                    ="300A0362";
    export var IsocenterToRangeShifterDistance: string                        ="300A0364";
    export var RangeShifterWaterEquivalentThickness: string                   ="300A0366";
    export var LateralSpreadingDeviceSettingsSequence: string                 ="300A0370";
    export var LateralSpreadingDeviceSetting: string                          ="300A0372";
    export var IsocenterToLateralSpreadingDeviceDistance: string              ="300A0374";
    export var RangeModulatorSettingsSequence: string                         ="300A0380";
    export var RangeModulatorGatingStartValue: string                         ="300A0382";
    export var RangeModulatorGatingStopValue: string                          ="300A0384";
    export var RangeModulatorGatingStartWaterEquivalentThickness: string      ="300A0386";
    export var RangeModulatorGatingStopWaterEquivalentThickness: string       ="300A0388";
    export var IsocenterToRangeModulatorDistance: string                      ="300A038A";
    export var ScanSpotTuneID: string                                         ="300A0390";
    export var NumberOfScanSpotPositions: string                              ="300A0392";
    export var ScanSpotPositionMap: string                                    ="300A0394";
    export var ScanSpotMetersetWeights: string                                ="300A0396";
    export var ScanningSpotSize: string                                       ="300A0398";
    export var NumberOfPaintings: string                                      ="300A039A";
    export var IonToleranceTableSequence: string                              ="300A03A0";
    export var IonBeamSequence: string                                        ="300A03A2";
    export var IonBeamLimitingDeviceSequence: string                          ="300A03A4";
    export var IonBlockSequence: string                                       ="300A03A6";
    export var IonControlPointSequence: string                                ="300A03A8";
    export var IonWedgeSequence: string                                       ="300A03AA";
    export var IonWedgePositionSequence: string                               ="300A03AC";
    export var ReferencedSetupImageSequence: string                           ="300A0401";
    export var SetupImageComment: string                                      ="300A0402";
    export var MotionSynchronizationSequence: string                          ="300A0410";
    export var ControlPointOrientation: string                                ="300A0412";
    export var GeneralAccessorySequence: string                               ="300A0420";
    export var GeneralAccessoryID: string                                     ="300A0421";
    export var GeneralAccessoryDescription: string                            ="300A0422";
    export var GeneralAccessoryType: string                                   ="300A0423";
    export var GeneralAccessoryNumber: string                                 ="300A0424";
    export var SourceToGeneralAccessoryDistance: string                       ="300A0425";
    export var ApplicatorGeometrySequence: string                             ="300A0431";
    export var ApplicatorApertureShape: string                                ="300A0432";
    export var ApplicatorOpening: string                                      ="300A0433";
    export var ApplicatorOpeningX: string                                     ="300A0434";
    export var ApplicatorOpeningY: string                                     ="300A0435";
    export var SourceToApplicatorMountingPositionDistance: string             ="300A0436";
    export var NumberOfBlockSlabItems: string                                 ="300A0440";
    export var BlockSlabSequence: string                                      ="300A0441";
    export var BlockSlabThickness: string                                     ="300A0442";
    export var BlockSlabNumber: string                                        ="300A0443";
    export var DeviceMotionControlSequence: string                            ="300A0450";
    export var DeviceMotionExecutionMode: string                              ="300A0451";
    export var DeviceMotionObservationMode: string                            ="300A0452";
    export var DeviceMotionParameterCodeSequence: string                      ="300A0453";

// *****************************************************************************************************************************
// *** 300C
// *****************************************************************************************************************************
    export var ReferencedRTPlanSequence: string                               ="300C0002";
    export var ReferencedBeamSequence: string                                 ="300C0004";
    export var ReferencedBeamNumber: string                                   ="300C0006";
    export var ReferencedReferenceImageNumber: string                         ="300C0007";
    export var StartCumulativeMetersetWeight: string                          ="300C0008";
    export var EndCumulativeMetersetWeight: string                            ="300C0009";
    export var ReferencedBrachyApplicationSetupSequence: string               ="300C000A";
    export var ReferencedBrachyApplicationSetupNumber: string                 ="300C000C";
    export var ReferencedSourceNumber: string                                 ="300C000E";
    export var ReferencedFractionGroupSequence: string                        ="300C0020";
    export var ReferencedFractionGroupNumber: string                          ="300C0022";
    export var ReferencedVerificationImageSequence: string                    ="300C0040";
    export var ReferencedReferenceImageSequence: string                       ="300C0042";
    export var ReferencedDoseReferenceSequence: string                        ="300C0050";
    export var ReferencedDoseReferenceNumber: string                          ="300C0051";
    export var BrachyReferencedDoseReferenceSequence: string                  ="300C0055";
    export var ReferencedStructureSetSequence: string                         ="300C0060";
    export var ReferencedPatientSetupNumber: string                           ="300C006A";
    export var ReferencedDoseSequence: string                                 ="300C0080";
    export var ReferencedToleranceTableNumber: string                         ="300C00A0";
    export var ReferencedBolusSequence: string                                ="300C00B0";
    export var ReferencedWedgeNumber: string                                  ="300C00C0";
    export var ReferencedCompensatorNumber: string                            ="300C00D0";
    export var ReferencedBlockNumber: string                                  ="300C00E0";
    export var ReferencedControlPointIndex: string                            ="300C00F0";
    export var ReferencedControlPointSequence: string                         ="300C00F2";
    export var ReferencedStartControlPointIndex: string                       ="300C00F4";
    export var ReferencedStopControlPointIndex: string                        ="300C00F6";
    export var ReferencedRangeShifterNumber: string                           ="300C0100";
    export var ReferencedLateralSpreadingDeviceNumber: string                 ="300C0102";
    export var ReferencedRangeModulatorNumber: string                         ="300C0104";
    export var OmittedBeamTaskSequence: string                                ="300C0111";
    export var ReasonForOmission: string                                      ="300C0112";
    export var ReasonForOmissionDescription: string                           ="300C0113";

// *****************************************************************************************************************************
// *** 300E
// *****************************************************************************************************************************
    export var ApprovalStatus: string                                         ="300E0002";
    export var ReviewDate: string                                             ="300E0004";
    export var ReviewTime: string                                             ="300E0005";
    export var ReviewerName: string                                           ="300E0008";

// *****************************************************************************************************************************
// *** 4000
// *****************************************************************************************************************************
    export var Arbitrary: string                                              ="40000010";   // Retired
    export var TextComments: string                                           ="40004000";   // Retired

// *****************************************************************************************************************************
// *** 4008
// *****************************************************************************************************************************
    export var ResultsID: string                                              ="40080040";   // Retired
    export var ResultsIDIssuer: string                                        ="40080042";   // Retired
    export var ReferencedInterpretationSequence: string                       ="40080050";   // Retired
    export var ReportProductionStatusTrial: string                            ="400800FF";   // Retired
    export var InterpretationRecordedDate: string                             ="40080100";   // Retired
    export var InterpretationRecordedTime: string                             ="40080101";   // Retired
    export var InterpretationRecorder: string                                 ="40080102";   // Retired
    export var ReferenceToRecordedSound: string                               ="40080103";   // Retired
    export var InterpretationTranscriptionDate: string                        ="40080108";   // Retired
    export var InterpretationTranscriptionTime: string                        ="40080109";   // Retired
    export var InterpretationTranscriber: string                              ="4008010A";   // Retired
    export var InterpretationText: string                                     ="4008010B";   // Retired
    export var InterpretationAuthor: string                                   ="4008010C";   // Retired
    export var InterpretationApproverSequence: string                         ="40080111";   // Retired
    export var InterpretationApprovalDate: string                             ="40080112";   // Retired
    export var InterpretationApprovalTime: string                             ="40080113";   // Retired
    export var PhysicianApprovingInterpretation: string                       ="40080114";   // Retired
    export var InterpretationDiagnosisDescription: string                     ="40080115";   // Retired
    export var InterpretationDiagnosisCodeSequence: string                    ="40080117";   // Retired
    export var ResultsDistributionListSequence: string                        ="40080118";   // Retired
    export var DistributionName: string                                       ="40080119";   // Retired
    export var DistributionAddress: string                                    ="4008011A";   // Retired
    export var InterpretationID: string                                       ="40080200";   // Retired
    export var InterpretationIDIssuer: string                                 ="40080202";   // Retired
    export var InterpretationTypeID: string                                   ="40080210";   // Retired
    export var InterpretationStatusID: string                                 ="40080212";   // Retired
    export var Impressions: string                                            ="40080300";   // Retired
    export var ResultsComments: string                                        ="40084000";   // Retired

// *****************************************************************************************************************************
// *** 4010
// *****************************************************************************************************************************
    export var LowEnergyDetectors: string                                     ="40100001";
    export var HighEnergyDetectors: string                                    ="40100002";
    export var DetectorGeometrySequence: string                               ="40100004";
    export var ThreatROIVoxelSequence: string                                 ="40101001";
    export var ThreatROIBase: string                                          ="40101004";
    export var ThreatROIExtents: string                                       ="40101005";
    export var ThreatROIBitmap: string                                        ="40101006";
    export var RouteSegmentID: string                                         ="40101007";
    export var GantryType: string                                             ="40101008";
    export var OOIOwnerType: string                                           ="40101009";
    export var RouteSegmentSequence: string                                   ="4010100A";
    export var PotentialThreatObjectID: string                                ="40101010";
    export var ThreatSequence: string                                         ="40101011";
    export var ThreatCategory: string                                         ="40101012";
    export var ThreatCategoryDescription: string                              ="40101013";
    export var ATDAbilityAssessment: string                                   ="40101014";
    export var ATDAssessmentFlag: string                                      ="40101015";
    export var ATDAssessmentProbability: string                               ="40101016";
    export var Mass: string                                                   ="40101017";
    export var Density: string                                                ="40101018";
    export var ZEffective: string                                             ="40101019";
    export var BoardingPassID: string                                         ="4010101A";
    export var CenterOfMass: string                                           ="4010101B";
    export var CenterOfPTO: string                                            ="4010101C";
    export var BoundingPolygon: string                                        ="4010101D";
    export var RouteSegmentStartLocationID: string                            ="4010101E";
    export var RouteSegmentEndLocationID: string                              ="4010101F";
    export var RouteSegmentLocationIDType: string                             ="40101020";
    export var AbortReason: string                                            ="40101021";
    export var VolumeOfPTO: string                                            ="40101023";
    export var AbortFlag: string                                              ="40101024";
    export var RouteSegmentStartTime: string                                  ="40101025";
    export var RouteSegmentEndTime: string                                    ="40101026";
    export var TDRType: string                                                ="40101027";
    export var InternationalRouteSegment: string                              ="40101028";
    export var ThreatDetectionAlgorithmAndVersion: string                     ="40101029";
    export var AssignedLocation: string                                       ="4010102A";
    export var AlarmDecisionTime: string                                      ="4010102B";
    export var AlarmDecision: string                                          ="40101031";
    export var NumberOfTotalObjects: string                                   ="40101033";
    export var NumberOfAlarmObjects: string                                   ="40101034";
    export var PTORepresentationSequence: string                              ="40101037";
    export var ATDAssessmentSequence: string                                  ="40101038";
    export var TIPType: string                                                ="40101039";
    export var DICOSVersion: string                                           ="4010103A";
    export var OOIOwnerCreationTime: string                                   ="40101041";
    export var OOIType: string                                                ="40101042";
    export var OOISize: string                                                ="40101043";
    export var AcquisitionStatus: string                                      ="40101044";
    export var BasisMaterialsCodeSequence: string                             ="40101045";
    export var PhantomType: string                                            ="40101046";
    export var OOIOwnerSequence: string                                       ="40101047";
    export var ScanType: string                                               ="40101048";
    export var ItineraryID: string                                            ="40101051";
    export var ItineraryIDType: string                                        ="40101052";
    export var ItineraryIDAssigningAuthority: string                          ="40101053";
    export var RouteID: string                                                ="40101054";
    export var RouteIDAssigningAuthority: string                              ="40101055";
    export var InboundArrivalType: string                                     ="40101056";
    export var CarrierID: string                                              ="40101058";
    export var CarrierIDAssigningAuthority: string                            ="40101059";
    export var SourceOrientation: string                                      ="40101060";
    export var SourcePosition: string                                         ="40101061";
    export var BeltHeight: string                                             ="40101062";
    export var AlgorithmRoutingCodeSequence: string                           ="40101064";
    export var TransportClassification: string                                ="40101067";
    export var OOITypeDescriptor: string                                      ="40101068";
    export var TotalProcessingTime: string                                    ="40101069";
    export var DetectorCalibrationData: string                                ="4010106C";
    export var AdditionalScreeningPerformed: string                           ="4010106D";
    export var AdditionalInspectionSelectionCriteria: string                  ="4010106E";
    export var AdditionalInspectionMethodSequence: string                     ="4010106F";
    export var AITDeviceType: string                                          ="40101070";
    export var QRMeasurementsSequence: string                                 ="40101071";
    export var TargetMaterialSequence: string                                 ="40101072";
    export var SNRThreshold: string                                           ="40101073";
    export var ImageScaleRepresentation: string                               ="40101075";
    export var ReferencedPTOSequence: string                                  ="40101076";
    export var ReferencedTDRInstanceSequence: string                          ="40101077";
    export var PTOLocationDescription: string                                 ="40101078";
    export var AnomalyLocatorIndicatorSequence: string                        ="40101079";
    export var AnomalyLocatorIndicator: string                                ="4010107A";
    export var PTORegionSequence: string                                      ="4010107B";
    export var InspectionSelectionCriteria: string                            ="4010107C";
    export var SecondaryInspectionMethodSequence: string                      ="4010107D";
    export var PRCSToRCSOrientation: string                                   ="4010107E";

// *****************************************************************************************************************************
// *** 4FFE
// *****************************************************************************************************************************
    export var MACParametersSequence: string                                  ="4FFE0001";

// *****************************************************************************************************************************
// *** 50xx
// *****************************************************************************************************************************
    export var CurveDimensions: string                                        ="50000005";   // Retired
    export var NumberOfPoints: string                                         ="50000010";   // Retired
    export var TypeOfData: string                                             ="50000020";   // Retired
    export var CurveDescription: string                                       ="50000022";   // Retired
    export var AxisUnits: string                                              ="50000030";   // Retired
    export var AxisLabels: string                                             ="50000040";   // Retired
    export var DataValueRepresentation: string                                ="50000103";   // Retired
    export var MinimumCoordinateValue: string                                 ="50000104";   // Retired
    export var MaximumCoordinateValue: string                                 ="50000105";   // Retired
    export var CurveRange: string                                             ="50000106";   // Retired
    export var CurveDataDescriptor: string                                    ="50000110";   // Retired
    export var CoordinateStartValue: string                                   ="50000112";   // Retired
    export var CoordinateStepValue: string                                    ="50000114";   // Retired
    export var CurveActivationLayer: string                                   ="50001001";   // Retired
    export var AudioType: string                                              ="50002000";   // Retired
    export var AudioSampleFormat: string                                      ="50002002";   // Retired
    export var NumberOfChannels: string                                       ="50002004";   // Retired
    export var NumberOfSamples: string                                        ="50002006";   // Retired
    export var SampleRate: string                                             ="50002008";   // Retired
    export var TotalTime: string                                              ="5000200A";   // Retired
    export var AudioSampleData: string                                        ="5000200C";   // Retired
    export var AudioComments: string                                          ="5000200E";   // Retired
    export var CurveLabel: string                                             ="50002500";   // Retired
    export var CurveReferencedOverlaySequence: string                         ="50002600";   // Retired
    export var CurveReferencedOverlayGroup: string                            ="50002610";   // Retired
    export var CurveData: string                                              ="50003000";   // Retired

// *****************************************************************************************************************************
// *** 5200
// *****************************************************************************************************************************
    export var SharedFunctionalGroupsSequence: string                         ="52009229";
    export var PerFrameFunctionalGroupsSequence: string                       ="52009230";

// *****************************************************************************************************************************
// *** 5400
// *****************************************************************************************************************************
    export var WaveformSequence: string                                       ="54000100";
    export var ChannelMinimumValue: string                                    ="54000110";
    export var ChannelMaximumValue: string                                    ="54000112";
    export var WaveformBitsAllocated: string                                  ="54001004";
    export var WaveformSampleInterpretation: string                           ="54001006";
    export var WaveformPaddingValue: string                                   ="5400100A";
    export var WaveformData: string                                           ="54001010";

// *****************************************************************************************************************************
// *** 5600
// *****************************************************************************************************************************
    export var FirstOrderPhaseCorrectionAngle: string                         ="56000010";
    export var SpectroscopyData: string                                       ="56000020";

// *****************************************************************************************************************************
// *** 60xx
// *****************************************************************************************************************************
    export var OverlayRows: string                                            ="60000010";
    export var OverlayColumns: string                                         ="60000011";
    export var OverlayPlanes: string                                          ="60000012";   // Retired
    export var NumberOfFramesInOverlay: string                                ="60000015";
    export var OverlayDescription: string                                     ="60000022";
    export var OverlayType: string                                            ="60000040";
    export var OverlaySubtype: string                                         ="60000045";
    export var OverlayOrigin: string                                          ="60000050";
    export var ImageFrameOrigin: string                                       ="60000051";
    export var OverlayPlaneOrigin: string                                     ="60000052";   // Retired
    export var OverlayCompressionCode: string                                 ="60000060";   // Retired
    export var OverlayCompressionOriginator: string                           ="60000061";   // Retired
    export var OverlayCompressionLabel: string                                ="60000062";   // Retired
    export var OverlayCompressionDescription: string                          ="60000063";   // Retired
    export var OverlayCompressionStepPointers: string                         ="60000066";   // Retired
    export var OverlayRepeatInterval: string                                  ="60000068";   // Retired
    export var OverlayBitsGrouped: string                                     ="60000069";   // Retired
    export var OverlayBitsAllocated: string                                   ="60000100";
    export var OverlayBitPosition: string                                     ="60000102";
    export var OverlayFormat: string                                          ="60000110";   // Retired
    export var OverlayLocation: string                                        ="60000200";   // Retired
    export var OverlayCodeLabel: string                                       ="60000800";   // Retired
    export var OverlayNumberOfTables: string                                  ="60000802";   // Retired
    export var OverlayCodeTableLocation: string                               ="60000803";   // Retired
    export var OverlayBitsForCodeWord: string                                 ="60000804";   // Retired
    export var OverlayActivationLayer: string                                 ="60001001";
    export var OverlayDescriptorGray: string                                  ="60001100";   // Retired
    export var OverlayDescriptorRed: string                                   ="60001101";   // Retired
    export var OverlayDescriptorGreen: string                                 ="60001102";   // Retired
    export var OverlayDescriptorBlue: string                                  ="60001103";   // Retired
    export var OverlaysGray: string                                           ="60001200";   // Retired
    export var OverlaysRed: string                                            ="60001201";   // Retired
    export var OverlaysGreen: string                                          ="60001202";   // Retired
    export var OverlaysBlue: string                                           ="60001203";   // Retired
    export var ROIArea: string                                                ="60001301";
    export var ROIMean: string                                                ="60001302";
    export var ROIStandardDeviation: string                                   ="60001303";
    export var OverlayLabel: string                                           ="60001500";
    export var OverlayData: string                                            ="60003000";
    export var OverlayComments: string                                        ="60004000";   // Retired

// *****************************************************************************************************************************
// *** 7FE0
// *****************************************************************************************************************************
    export var FloatPixelData: string                                         ="7FE00008";
    export var DoubleFloatPixelData: string                                   ="7FE00009";
    export var PixelData: string                                              ="7FE00010";
    export var CoefficientsSDVN: string                                       ="7FE00020";   // Retired
    export var CoefficientsSDHN: string                                       ="7FE00030";   // Retired
    export var CoefficientsSDDN: string                                       ="7FE00040";   // Retired

// *****************************************************************************************************************************
// *** 7Fxx
// *****************************************************************************************************************************
    export var VariablePixelData: string                                      ="7F000010";   // Retired
    export var VariableNextDataGroup: string                                  ="7F000011";   // Retired
    export var VariableCoefficientsSDVN: string                               ="7F000020";   // Retired
    export var VariableCoefficientsSDHN: string                               ="7F000030";   // Retired
    export var VariableCoefficientsSDDN: string                               ="7F000040";   // Retired

// *****************************************************************************************************************************
// *** FFFA
// *****************************************************************************************************************************
    export var DigitalSignaturesSequence: string                              ="FFFAFFFA";

// *****************************************************************************************************************************
// *** FFFC
// *****************************************************************************************************************************
    export var DataSetTrailingPadding: string                                 ="FFFCFFFC";

// *****************************************************************************************************************************
// *** FFFE
// *****************************************************************************************************************************
    export var Item: string                                                   ="FFFEE000";
    export var ItemDelimitationItem: string                                   ="FFFEE00D";
    export var SequenceDelimitationItem: string                               ="FFFEE0DD";

}

class DicomHelper {


    /////////////////////////////////////////////////////////////////////////////////////////////////////
    ////   function Name: PreparePresentationInformation                                     
    ///
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    ////                                                                                              ///
    ///    Converts the raw presentation information retrieved from the proxy into values that can    ///
    ///    be handled easily in the medical viewer.                                                   ///
    ////                                                                                              ///
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    public static supportWindowLevel(cell, index) {
        if (cell.supportWindowLevel)
            return cell.supportWindowLevel(index);
        else
            return true;
    }



    /////////////////////////////////////////////////////////////////////////////////////////////////////
    ////   function Name: PreparePresentationInformation                                     
    ///
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    ////                                                                                              ///
    ///    Converts the raw presentation information retrieved from the proxy into values that can    ///
    ///    be handled easily in the medical viewer.                                                   ///
    ////                                                                                              ///
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    public static PreparePresentationInformation(presentationInformationRaw, pageIndex) {

        var frameInfo: Models.FramePresentationInfo = new Models.FramePresentationInfo();

        frameInfo.orientation = null;
        frameInfo.width = 100;
        frameInfo.height = 100;
        frameInfo.position = [1, 1, 1];
        frameInfo.instanceNumber = 1;
        frameInfo.rowSpacing = 0;
        frameInfo.columnSpacing = 0;
        //if (frameInfo.orientation != null)
        //    frameInfo.orientationOverlay = new lt.Controls.Medical.OrientationLetters(frameInfo.orientation);

        frameInfo.cineOptions = presentationInformationRaw.Cine;

        if (presentationInformationRaw == null)
            return frameInfo;

        if (presentationInformationRaw.PagesPresentationInfo.length <= pageIndex)
            return frameInfo;

        var pageInfo = presentationInformationRaw.PagesPresentationInfo[pageIndex];
        if (pageInfo == null)
            return frameInfo;

        // create orientation array.
        if (pageInfo.ImageOrientationPatientArray != null) {

            frameInfo.orientation = pageInfo.ImageOrientationPatientArray;
        }
        else if (pageInfo.PatientOrientation != null) {
            frameInfo.patientOrientation = pageInfo.PatientOrientation;

            // we removed this, since if there is no orientation value present, we don't render the orientation overlay.
            // default value, when there is no orientation information available.
            //frameInfo.orientation = [1, 0, 0, 0, 1, 0];
        }

        // get the width and height.
        if (null != pageInfo.Width)
            frameInfo.width = pageInfo.Width[0];
        if (null != pageInfo.Height)
            frameInfo.height = pageInfo.Height[0];

        // get the image position.
        if (pageInfo.ImagePositionPatientArray != null) {

            frameInfo.position = pageInfo.ImagePositionPatientArray;
        }
        else {

            // default value, when there is no position information available.
            frameInfo.position = [1, 1, 1];
        }

        // get the instance number.
        if (null != presentationInformationRaw.InstanceNumber)
            frameInfo.instanceNumber = parseInt(presentationInformationRaw.InstanceNumber);

        // get the row spacing and columns spacing.
        if (pageInfo.PixelSpacingPatientArray != null) {
            if (pageInfo.PixelSpacingPatientArray.length == 2) {
                var values = pageInfo.PixelSpacingPatientArray;
                frameInfo.rowSpacing = parseFloat(values[0]);
                frameInfo.columnSpacing = parseFloat(values[1]);
            }
        }

        // create the orientation object that is used to render the orientation letters on the viewer.
        //if (frameInfo.orientation != null)
        //     frameInfo.orientationOverlay = new lt.Controls.Medical._orientationLetters(frameInfo.orientation);
        // else
        //    if (frameInfo.patientOrientation != null) {
        //         {
        //             var orientation = frameInfo.patientOrientation;
        //             frameInfo.orientationOverlay = new lt.Controls.Medical._orientationLetters([0, 1, 0, 0, 1, 0]);
        //             frameInfo.orientationOverlay.setProjectionRadiographOrientation(orientation);
        //         }
        //     }
        return frameInfo;
    }

    public static GetBitsPerPixel(dicomDataSet) {
        var samplesPerPixelTag = DicomHelper.getDicomTag(dicomDataSet, DicomTag.SamplesPerPixel);
        var bitsAllocatedTag = DicomHelper.getDicomTag(dicomDataSet, DicomTag.BitsAllocated);

        var bpp;
        if (samplesPerPixelTag != null && samplesPerPixelTag.Value.length > 0) {
            bpp = parseInt(DicomHelper.GetTagText(samplesPerPixelTag), 10);
        }

        return bpp * parseInt(DicomHelper.GetTagText(bitsAllocatedTag), 10);
    }

    public static GetTagText(tag) {
        if (!tag)
            return '';

        if (tag.Value && tag.Value.length > 0)
            return tag.Value.join("\\");

        return '';
    }

    public static TagExists(metadata, tagNumber: string) {
        var tag = metadata[tagNumber];
        var noExists: boolean = (typeof tag === "undefined");
        return !noExists;
    }

    public static IsDicomImage(metadata) {
        var imageTags = [
            DicomTag.Columns,
            DicomTag.Rows,
            DicomTag.BitsAllocated,
            DicomTag.BitsStored];

        var len = imageTags.length;
        
        for (var i = 0; i < len; i++) {
            if (!this.TagExists(metadata, imageTags[i]))
                return false;
        }
        return true;
    }



    public static GetTagTextValue(metadata, tag) {

        var tagId = this.findTag(metadata, tag);

        if (null != tagId && tagId.Value && tagId.Value.length > 0) {
            return DicomHelper.GetTagText(tagId);
        }
    }


    public static GetDicomImageInformation(metadata, frameIndex? : number) {
        var imageInfo: any = new lt.Controls.Medical.DICOMImageInformation();

        var imageWidthTag = metadata[DicomTag.Columns];
        var imageHeightTag = metadata[DicomTag.Rows];
        var windowWidthTag = metadata[DicomTag.WindowWidth];
        var windowCenterTag = metadata[DicomTag.WindowCenter];
        var smallestTag = metadata[DicomTag.SmallestImagePixelValue]; //Smallest Image Pixel Value
        var largestTag = metadata[DicomTag.LargestImagePixelValue]; //Largest Image Pixel Value
        var hightBitTag = metadata[DicomTag.HighBit]; //hight bit
        var bitsStoredTag = metadata[DicomTag.BitsStored]; //bit Stored
        var interceptTag = this.findTag(metadata, DicomTag.RescaleIntercept); //Rescale Intercept
        var SlopeTag = this.findTag(metadata, DicomTag.RescaleSlope); //Rescale Slope
        var viewPosition = this.findTag(metadata, DicomTag.ViewPosition);


        var patientOrientationTag = this.findTag(metadata, "00200020"); //Paitent orientation, this is just incase the image orientation is not present

        var orientationTag = this.findTag(metadata,"00200037"); //Image Patient Orientation.
        var positionTag = this.findTag(metadata, "00200032"); //Image Patient Position.
        var frameOfReferenceUID = metadata["00200052"]; //Frame of reference UID

        var voiLutSequence = metadata["00283010"]; //VOI LUT Sequence
        var waveFormSequence = metadata["54000100"]; //Wave Form Sequence

        var imageTypeTag = metadata["00080008"]; //Image Type
        var lossyImageCompressionTag = metadata["00282110"]; //The Lossy Image Compression 

        var lutDescriptor = null;
        var lutData = null;

        if (voiLutSequence && voiLutSequence.Value && voiLutSequence.Value.length > 0) {
            var seqItem = voiLutSequence.Value[0];

            if (seqItem && !$.isEmptyObject(seqItem)) {
                lutDescriptor = seqItem['00283002']; //LUT Descriptor
                lutData = seqItem['00283006'];  //LUT Data
            }
        }

        var signedTag = metadata["00280103"]; //Pixel Representation
        

        var mimeType = metadata["00420012"]; //Imager Pixel Spacing
        var photometricInterpretationTag = metadata["00280004"]; //Photometric Interpretation
        var imagerPixelSpacingTag = metadata["00181164"]; //Imager Pixel Spacing
        var pixelSpacingTag = this.findTag(metadata, "00280030"); //Pixel Spacing
        var nominalScannedPixelSpacingTag = metadata["00182010"]; //Nominal Scanned Pixel Spacing
        var detectorElementSpacingTag = metadata["00187022"]; //Detector Element Spacing
        var perFrameArray = metadata[DicomTag.PerFrameFunctionalGroupsSequence];
        var width;
        var height;
        var bpp = 1;
        var bitsStored = 0;
        var highBit;
        var lowBit = 0;
        var signed = false;

        if (imageWidthTag && imageWidthTag.Value.length) {
            width = DicomHelper.GetTagText(imageWidthTag);
        }
        else {
            width = 0;
        }

        if (imageHeightTag && imageHeightTag.Value.length) {
            height = DicomHelper.GetTagText(imageHeightTag);
        }
        else {
            height = 0;
        }

        bpp = DicomHelper.GetBitsPerPixel(metadata);

        if (null != bitsStoredTag && bitsStoredTag.Value && bitsStoredTag.Value.length > 0) {
            bitsStored = parseInt(DicomHelper.GetTagText(bitsStoredTag), 10);
        }
        else {
            bitsStored = bpp;
        }



        if (perFrameArray != null && perFrameArray.Value && perFrameArray.Value.length > 0) {

            var perFrameItem = perFrameArray.Value[frameIndex];
            if (perFrameItem != null) {

                if (perFrameItem[DicomTag.PlanePositionSequence]) {
                    var positionItem = perFrameItem[DicomTag.PlanePositionSequence].Value[0];
                    if (positionItem != null) {
                        positionTag = positionItem[DicomTag.ImagePositionPatient];
                    }

                    if (perFrameItem[DicomTag.PlaneOrientationSequence]) {
                        var orientationItem = perFrameItem[DicomTag.PlaneOrientationSequence].Value[0];
                        if (orientationItem != null) {
                            orientationTag = orientationItem[DicomTag.ImageOrientationPatient];
                        }
                    }

                }
            }

        }


        imageInfo.set_width(parseInt(width, 10));
        imageInfo.set_height(parseInt(height, 10));
        imageInfo.set_bitsPerPixel(bpp);

        if (hightBitTag != null && hightBitTag.Value && hightBitTag.Value.length > 0) {
            highBit = parseInt(DicomHelper.GetTagText(hightBitTag), 10);
            lowBit = highBit - bitsStored + 1;
        }
        else {
            highBit = bpp - 1;

            imageInfo.set_lowBit(0);
        }

        if (viewPosition != null && viewPosition.Value && viewPosition.Value.length > 0) {
            imageInfo.viewPosition = DicomHelper.GetTagText(viewPosition);
        }


        imageInfo.set_highBit(highBit);
        imageInfo.set_lowBit(lowBit);


        var interceptValue = 0;


        if (interceptTag && interceptTag.Value && interceptTag.Value.length > 0) {
            interceptValue = parseFloat(DicomHelper.GetTagText(interceptTag));
            imageInfo.set_modalityIntercept(interceptValue);
        }
        else {
            imageInfo.set_modalityIntercept(0);
        }

        if (null != SlopeTag && SlopeTag.Value && SlopeTag.Value.length > 0) {
            var slope = parseFloat(DicomHelper.GetTagText(SlopeTag));
            imageInfo.set_modalitySlope(slope == 0 ? 1 : slope);
        }
        else {
            imageInfo.set_modalitySlope(1);
        }

        if (lutData != null && lutData.Value && lutData.Value.length) {
            var lutDescValues = DicomHelper.GetTagText(lutDescriptor).split("\\");

            imageInfo.set_firstStoredPixelValueMapped(lutDescValues[1] | 0);

            var myArray = DicomHelper.GetTagText(lutData).split("\\");
            for (var i = myArray.length; i--;) myArray[i] = myArray[i] | 0;
            imageInfo.set_lutDescriptor(myArray);
        }

        if (signedTag != null && signedTag.Value && signedTag.Value.length) {
            signed = (parseInt(DicomHelper.GetTagText(signedTag), 10) === 1) ? true : false;
            imageInfo.set_signed(signed);
        }
        else {
            imageInfo.set_signed(false);
        }


        var offset = 0;//(signed === true) ? 1 << highBit : 0;
        var mask = ((1 << bitsStored) - 1);

        var minValue = 0;
        if (smallestTag != null && smallestTag.Value && smallestTag.Value.length) {
            var smallestPixel = parseInt(DicomHelper.GetTagText(smallestTag), 10);

            if (smallestPixel < 0) {
                if (smallestPixel > offset) {
                    minValue = 0;
                }
                else {
                    minValue = smallestPixel + offset;
                }
            }
            else {
                minValue = Math.min(smallestPixel + offset, mask);
            }
        }
        else {
            minValue = 0;
        }

        imageInfo.set_minValue(minValue);

        var maxValue = -1;

        if (largestTag != null && largestTag.Value && largestTag.Value.length) {
            var largestPixel = parseInt(DicomHelper.GetTagText(largestTag), 10);

            if (largestPixel < 0) {
                if (largestPixel > offset) {
                    maxValue = 0;
                }
                else {
                    maxValue = (largestPixel + offset);
                }
            }
            else {
                maxValue = Math.min(largestPixel + offset, mask);
            }
        }
        else {
            maxValue = 0;
        }

        imageInfo.set_maxValue(maxValue);


        if (windowWidthTag == null)
            windowWidthTag = this.findTag(metadata, DicomTag.WindowWidth);

        if (null != windowWidthTag && windowWidthTag.Value && windowWidthTag.Value.length > 0) {
            imageInfo.set_windowWidth(windowWidthTag.Value[0] >> 0);
        }
        else {
            imageInfo.set_windowWidth(0);
        }

        if (windowCenterTag == null)
            windowCenterTag = this.findTag(metadata, DicomTag.WindowCenter);

        if (null != windowCenterTag && windowCenterTag.Value && windowCenterTag.Value.length > 0) {
            imageInfo.set_windowCenter(windowCenterTag.Value[0] >> 0);
        }
        else {
            imageInfo.set_windowCenter(0);
        }

        if (null != mimeType && mimeType.Value && mimeType.Value.length > 0) {
            imageInfo.set_photometricInterpretation("RGB");
        }
        else {
            if (null != photometricInterpretationTag && photometricInterpretationTag.Value && photometricInterpretationTag.Value.length > 0) {
                imageInfo.set_photometricInterpretation(DicomHelper.GetTagText(photometricInterpretationTag));
            }
            else {
                imageInfo.set_photometricInterpretation("MONOCHROME2");
            }

        }
        var spacing = null;
        var spacingType = null;

        if (null != nominalScannedPixelSpacingTag && nominalScannedPixelSpacingTag.Value && nominalScannedPixelSpacingTag.Value.length > 0) {
            spacing = DicomHelper.GetTagText(nominalScannedPixelSpacingTag);
            spacingType = "detector";
        }

        if (null != imagerPixelSpacingTag && imagerPixelSpacingTag.Value && imagerPixelSpacingTag.Value.length > 0) {
            spacing = DicomHelper.GetTagText(imagerPixelSpacingTag);
            spacingType = "detector";
        }

        if (null != pixelSpacingTag && pixelSpacingTag.Value && pixelSpacingTag.Value.length > 0) {
            spacing = DicomHelper.GetTagText(pixelSpacingTag);

            spacingType = "calibrated";

            var pixelSpacingCalibrationTypeTag = metadata["00280A02"]; //Pixel Spacing Calibration Type

            if (null != pixelSpacingCalibrationTypeTag && pixelSpacingCalibrationTypeTag.Value && pixelSpacingCalibrationTypeTag.Value.length > 0) {
                spacingType = DicomHelper.GetTagText(pixelSpacingCalibrationTypeTag);
            }
        }

        if (null != spacing) {
            var values = spacing.split('\\');
            imageInfo.rowSpacing = parseFloat(values[0]);
            imageInfo.columnSpacing = parseFloat(values[1]);
            imageInfo.spacingType = spacingType;
        }
        else {
            imageInfo.rowSpacing = 0;
            imageInfo.columnSpacing = 0;
        }

        if (null != orientationTag && orientationTag.Value && orientationTag.Value.length > 0) {

            var orientation = DicomHelper.GetTagText(orientationTag);// getElementsByTagName("Image Orientation (Patient)"); // textContent;
            var values = orientation.split('\\');
            if (values.length == 6)
                imageInfo.orientation = values;
        }
        else if (null != patientOrientationTag && patientOrientationTag.Value && patientOrientationTag.Value.length > 0) {
            var orientation = DicomHelper.GetTagText(patientOrientationTag);
            var values = orientation.split('\\');
            if (values.length == 6)
                imageInfo.orientation = values;
        }

        if (null != positionTag && positionTag.Value && positionTag.Value.length > 0) {
            var position = DicomHelper.GetTagText(positionTag);
            var values = position.split('\\');
            imageInfo.position = values;
        }
        else
            imageInfo.position = [1, 1, 1];

        if (frameOfReferenceUID != null && frameOfReferenceUID.Value && frameOfReferenceUID.Value.length > 0) {
            imageInfo.frameOfReferenceUID = DicomHelper.GetTagText(frameOfReferenceUID);
        }
        else
            imageInfo.frameOfReferenceUID = "";

        
        imageInfo.isWaveForm = angular.isDefined(waveFormSequence) && waveFormSequence.Value.length != 0;
        if (imageInfo.isWaveForm) {
            imageInfo.set_photometricInterpretation("RGB");
            imageInfo.backGroundColor = "0xffffff";
        }

        if (null != imageTypeTag && imageTypeTag.Value && imageTypeTag.Value.length > 0) {
            var imageType = DicomHelper.GetTagText(imageTypeTag);
            var values = imageType.split('\\');
            imageInfo.imageType = values;
        }
        else
            imageInfo.imageType = "unknown";

        if (null != lossyImageCompressionTag) {
            var lossyImageCompression = DicomHelper.GetTagText(lossyImageCompressionTag);
            if (lossyImageCompression == "01") {
                imageInfo.lossyImageCompression = true;
            } else {
                imageInfo.lossyImageCompression = false;
            }
        }
        else
            imageInfo.lossyImageCompression = false;

        return imageInfo;
    }

    public static getDicomTag(metadata, tag: string): any {
        var data = metadata[tag];

        return data;
    }

    public static findTag(dicom, tag: string): any {
        for (var key in dicom) {
            if (dicom[key].vr != 'SQ') {                
                if (key == tag) {
                    return dicom[key];
                }
            }
            else {
                if (dicom[key].Value && dicom[key].Value.length > 0) {
                    var length: number = dicom[key].Value.length;

                    for (var index = 0; index < length; index++) {
                        var value = this.findTag(dicom[key].Value[0], tag);

                        if (value!=null)
                            return value;
                    }
                }
            }
        }
        return null;
    }

    public static getDicomTagValue(metadata, tag: string, index?: number) {
        var dcmTag = this.getDicomTag(metadata, tag);

        index = index || 0;
        if (dcmTag != undefined && dcmTag.Value) {
            if (index < dcmTag.Value.length) {
                var value = dcmTag.Value[index];

                if (dcmTag.vr == 'DA') {
                    if (value) {
                        var DateJS: IDateJS = <any>(new Date(DicomHelper.parseDicomDate(value)));

                        value = DateJS;               
                    }
                }

                if (dcmTag.vr == 'TM') {
                    if (value) {
                        var DateJS: IDateJS = (<any>Date).today().at(DicomHelper.parseDicomTime(value));

                        value = DateJS;
                    }
                }   
                return value;
            }
        }

        if (dcmTag) {
            return '';
        }
        return undefined;
    }

    public static cloneDicomTagValue(metadata, tag: string): string {
        var retValue: string = "";

        retValue = DicomHelper.getConvertValue(metadata[tag]);
        return retValue;
    }

    public static getStudyDateTime(metadata, ignoreStudyTime: boolean): IDateJS {
        var studyDateJS: IDateJS = DicomHelper.getDicomTagValue(metadata, DicomTag.StudyDate);
        var studyTimeJS: IDateJS = DicomHelper.getDicomTagValue(metadata, DicomTag.StudyTime);
        if (studyTimeJS != null && !ignoreStudyTime) {
            studyDateJS.addHours(studyTimeJS.getHours());
            studyDateJS.addMinutes(studyTimeJS.getMinutes());
            studyDateJS.addSeconds(studyTimeJS.getSeconds());
        }
        return studyDateJS;
    }

    public static getStudyDateTimeString(metadata, ignoreStudyTime: boolean, includeParenthesis: boolean): string {
        var studyDateTimeJS: IDateJS = this.getStudyDateTime(metadata, ignoreStudyTime);
        var studyDateString: string = "";

        if (studyDateTimeJS != null) {
            if (studyDateTimeJS.getMonth() == 0 && studyDateTimeJS.getDay() == 0 && studyDateTimeJS.getFullYear() == 0) {
                studyDateString = studyDateTimeJS.toString("yyyy-MMM-dd");
            }
            else {
                studyDateString = studyDateTimeJS.toString("yyyy-MMM-dd HH:mm");
            }

            if (includeParenthesis) {
                if (studyDateString.length > 0) {
                    studyDateString = "(" + studyDateString + ")";
                }
            }
        }

        return studyDateString;
    }

    public static get_TagValue(metadata, tag: string, index?: number) {
        var dcmTag = this.getDicomTag(metadata, tag);

        index = index || 0;
        if (dcmTag != undefined && dcmTag.Value) {
            if (index < dcmTag.Value.length)
                return dcmTag.Value[index];
        }

        if (dcmTag) {
            return '';
        }
        return undefined;
    }

    public static get_allValues(metadata, tag: string): Array<any> {
        var dcmTag = this.getDicomTag(metadata, tag);
        var values: Array<any> = new Array<any>();

        if (dcmTag != undefined && dcmTag.Value) {
            for (var i = 0; i < dcmTag.Value.length; i++) {
                var value = dcmTag.Value[i];

                if (dcmTag.vr == 'DA') {
                    if (value) {
                        var DateJS: IDateJS = <any>(new Date(DicomHelper.parseDicomDate(value)));

                        value = DateJS;
                    }
                }

                if (dcmTag.vr == 'TM') {
                    if (value) {
                        var DateJS: IDateJS = (<any>Date).today().at(DicomHelper.parseDicomTime(value));

                        value = DateJS;
                    }
                }
                values.push(value);
            }
        }

        return values;
    }

    public static getConvertValue(dcmTag) {
        if (dcmTag != undefined && dcmTag.Value) {
            if (dcmTag.Value.length)
                return dcmTag.Value.join('\\');
        }
        return undefined;
    }

    private static getStringIfAvailable(tag: string, para: boolean) : string
    {
        if ((tag != null) && (tag != ""))
            return para ? "=" + tag : tag;

        return "";
    }


    public static getPatientName(metadata, tag: string, index?: number): string {
        var dcmTag = this.getDicomTag(metadata, tag);

        var output = "";

        index = index || 0;
        if (dcmTag != undefined && dcmTag.Value) {
            if (index < dcmTag.Value.length) {
                output += this.getStringIfAvailable(dcmTag.Value[index].Alphabetic, false);
                output += this.getStringIfAvailable(dcmTag.Value[index].Ideographic, true);
                output += this.getStringIfAvailable(dcmTag.Value[index].Phonetic, true);
            }
        }
        return output;
    }

    public static getPatientNameFromTag(dcmTag, index?: number): string {
        index = index || 0;
        if (dcmTag != undefined && dcmTag.Value) {
            if (index < dcmTag.Value.length)
                return dcmTag.Value[index].Alphabetic;
        }
        return undefined;
    }

    public static parseDicomDate(dateString: string) {
        if (!dateString)
            return "";
        if (dateString.length == 8) {
            var year = dateString.substring(0, 4);
            var month = dateString.substring(4, 6);
            var day = dateString.substring(6);

            return month + "/" + day + "/" + year;  //new Date(year, month - 1, day).toDateString();
        }
        else {
            return dateString;
        }
    }

    public static parseDicomTime(timeString: string) {
        if (timeString.indexOf(':') != -1) {
            timeString = timeString.replace(new RegExp(':', 'g'), '');
        }

        if (timeString.length >= 6) {
            var hour = parseInt(timeString.substring(0, 2));
            var minutes = timeString.substring(2, 4);
            var seconds = timeString.substring(4, 6);

            hour = hour % 12;
            hour = hour ? hour : 12; // the hour '0' should be '12'
            var ampm = hour >= 12 ? 'PM' : 'AM';

            return hour + ":" + minutes + ":" + seconds + " " + ampm;
        }
        return timeString;
    }

    public static getCodeSequenceList(metadata, tagList: string, itemNumberList: string): Array<Models.CodeSequence> {
        var list: Array<Models.CodeSequence> = new Array<Models.CodeSequence>();

        var tagArray = tagList.split("\\");
        for (var i = 0; i < tagArray.length; i++) {
            tagArray[i] = tagArray[i].replace(':', '');
        }

        var itemNumberArray = [];
        var itemNumber = null;
        if (itemNumberList != null) {
            itemNumberArray = itemNumberList.split("\\");

            var itemNumberArrayCount: number = itemNumberArray.length;
            for (var i = 0; i < itemNumberArrayCount; i++) {
                itemNumberArray[i] = parseInt(itemNumberArray[i]);
            }
            itemNumber = itemNumberArray[itemNumberArrayCount - 1];
        }

        var sequence = metadata[tagArray[0]];

        // tagArray and itemNumberArray must have the same number of items
        if (tagArray.length == itemNumberArray.length) {
            // Only enter this loop if more than one tag in tagArray
            for (var i = 1; i < tagArray.length; i++) {
                var index: number = itemNumberArray[i] - 1;
                var tag: string = tagArray[i];
                sequence = sequence.Value[index][tag];
            }
        }

        if (sequence && sequence.Value && sequence.Value.length > 0) {
            if (itemNumber != null) {
                if (itemNumber <= sequence.Value.length) {
                    var sequenceItem = sequence.Value[itemNumber - 1];
                    var codeSequence: Models.CodeSequence = this.get_CodeSequence(sequenceItem);

                    var invalid: boolean = ((!codeSequence.CodeMeaning || codeSequence.CodeMeaning.length == 0) || (!codeSequence.CodeValue || codeSequence.CodeValue.length == 0));
                    if (!invalid) {
                        list.push(codeSequence);
                    }
                }
            }

            else {
                for (var i = 0; i < sequence.Value.length; i++) {
                    var sequenceItem = sequence.Value[i];
                    var codeSequence: Models.CodeSequence = this.get_CodeSequence(sequenceItem);

                    if ((!codeSequence.CodeMeaning || codeSequence.CodeMeaning.length == 0) || (!codeSequence.CodeValue || codeSequence.CodeValue.length == 0))
                        continue;

                    list.push(codeSequence);
                }
            }
        }
               
        return list;
    }

    public static get_CodeSequence(sequenceItem): Models.CodeSequence {
        var codeSequence: Models.CodeSequence = new Models.CodeSequence();

        codeSequence.CodeValue = sequenceItem[DicomTag.CodeValue] && sequenceItem[DicomTag.CodeValue].Value ? sequenceItem[DicomTag.CodeValue].Value[0] : '';
        codeSequence.CodeMeaning = sequenceItem[DicomTag.CodeMeaning] && sequenceItem[DicomTag.CodeMeaning].Value ? sequenceItem[DicomTag.CodeMeaning].Value[0] : '';
        codeSequence.CodeSchemeDesignator = sequenceItem[DicomTag.CodingSchemeDesignator] && sequenceItem[DicomTag.CodingSchemeDesignator].Value ? sequenceItem[DicomTag.CodingSchemeDesignator].Value[0] : '';
        codeSequence.CodingSchemeVersion = sequenceItem[DicomTag.CodingSchemeVersion] && sequenceItem[DicomTag.CodingSchemeVersion].Vale ? sequenceItem[DicomTag.CodingSchemeVersion].Value[0] : '';

        return codeSequence;
    }
};