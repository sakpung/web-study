// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom;
using DicomVideoCaptureDemo.Common;

namespace DicomVideoCaptureDemo.UI
{
   public partial class CreateNewDICOMFile : Form
   {
      public DicomClassType m_nClass;
      public DicomDataSetInitializeFlags m_nFlags;
      private Dictionary<int, DicomClassType> dataDictionary;

      public CreateNewDICOMFile()
      {
         InitializeComponent();

         dataDictionary = new Dictionary<int, DicomClassType>();

         DicomIod pIOD;
         int       nIndex;

         RemoveClasses();
         pIOD = DicomIodTable.Instance.GetFirst(null,true);
         while (pIOD != null)
         {
            nIndex = _lstBx.Items.Add(pIOD.Name);
            string item = _lstBx.Items[nIndex] as string;
            dataDictionary.Add(nIndex, pIOD.ClassCode);

            pIOD = DicomIodTable.Instance.GetNext(pIOD, true);
         }
         _lstBx.SelectedIndex=2;
      }

      bool IsSupportedIod(DicomClassType nClass)
      {
         for (int i = 0; i < m_DICOMUIDIOD.Length; i++)
         {
            if (m_DICOMUIDIOD[i].nClass == nClass)
               return true;
         }

         return false;
      }

      void RemoveClasses()
      {
         DicomIod pClass = null;

         for (DicomClassType nClass = DicomClassType.CRImageStorage; nClass < DicomClassType.Max; nClass++)
         {
            if (!IsSupportedIod(nClass))
            {
               pClass = DicomIodTable.Instance.FindClass(nClass);
               if (pClass != null)
                  DicomIodTable.Instance.Delete(pClass);
            }
         }
      }

      public static MYDICOMUIDIOD[] m_DICOMUIDIOD =
      {
         new MYDICOMUIDIOD( DicomClassType.NMImageStorage                              ,  DicomUidType.NMImageStorage                                 ),
         new MYDICOMUIDIOD( DicomClassType.USMultiFrameImageStorage                    ,  DicomUidType.USMultiframeImageStorage                       ),
         new MYDICOMUIDIOD( DicomClassType.SCImageStorage                              ,  DicomUidType.SCImageStorage                                 ),
         new MYDICOMUIDIOD( DicomClassType.XAImageStorage                              ,  DicomUidType.XAImageStorage                                 ),
         new MYDICOMUIDIOD( DicomClassType.XRFImageStorage                             ,  DicomUidType.XrfImageStorage                                ),
         new MYDICOMUIDIOD( DicomClassType.RTImageStorage                              ,  DicomUidType.RTImageStorage                                 ),
         new MYDICOMUIDIOD( DicomClassType.PETImageStorage                             ,  DicomUidType.PETImageStorage                                ),
         new MYDICOMUIDIOD( DicomClassType.VLEndoscopicImageStorage                    ,  DicomUidType.VLEndoscopicImageStorageClass                  ),
         new MYDICOMUIDIOD( DicomClassType.VLMicroscopicImageStorage                   ,  DicomUidType.VLMicroscopicImageStorageClass                 ),
         new MYDICOMUIDIOD( DicomClassType.VLSlideCoordinatesMicroscopicImageStorage   ,  DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass ),
         new MYDICOMUIDIOD( DicomClassType.VLPhotographicImageStorage                  ,  DicomUidType.VLPhotographicImageStorageClass                ),
         new MYDICOMUIDIOD( DicomClassType.BasicCardiacEP                              ,  DicomUidType.CardiacElectrophysiologyWaveformStorage        ),
         new MYDICOMUIDIOD( DicomClassType.SCMultiFrameSingleBitImageStorage           ,  DicomUidType.SCMultiFrameSingleBitImageStorage              ),
         new MYDICOMUIDIOD( DicomClassType.SCMultiFrameGrayscaleByteImageStorage       ,  DicomUidType.SCMultiFrameGrayscaleByteImageStorage          ),
         new MYDICOMUIDIOD( DicomClassType.SCMultiFrameGrayscaleWordImageStorage       ,  DicomUidType.SCMultiFrameGrayscaleWordImageStorage          ),
         new MYDICOMUIDIOD( DicomClassType.SCMultiFrameTrueColorImageStorage           ,  DicomUidType.SCMultiFrameTrueColorImageStorage              ),
         new MYDICOMUIDIOD( DicomClassType.VideoEndoscopicImageStorage                 ,  DicomUidType.VideoEndoscopicImageStorage                    ),
         new MYDICOMUIDIOD( DicomClassType.VideoMicroscopicImageStorage                ,  DicomUidType.VideoMicroscopicImageStorage                   ),
         new MYDICOMUIDIOD( DicomClassType.VideoPhotographicImageStorage               ,  DicomUidType.VideoPhotographicImageStorage                  ),
         
      };

      static DicomClassType[] RemoveList =
      {
         //DicomClassType.NMIMAGESTORAGE,
         //DicomClassType.USMULTIFRAMEIMAGESTORAGE,
         //DicomClassType.SCIMAGESTORAGE,
         //DicomClassType.XAIMAGESTORAGE,
         //DicomClassType.XRFIMAGESTORAGE,
         //DicomClassType.RTIMAGESTORAGE,
         //DicomClassType.PETIMAGESTORAGE,
         //DicomClassType.VLENDOSCOPICIMAGESTORAGE,
         //DicomClassType.VLMICROSCOPICIMAGESTORAGE,
         //DicomClassType.VLSLIDECOORDINATESMICROSCOPICIMAGESTORAGE,
         //DicomClassType.VLPHOTOGRAPHICIMAGESTORAGE,
         //DicomClassType.BASICCARDIACEP
         
         DicomClassType.CRImageStorage,
         DicomClassType.CTImageStorage,
         DicomClassType.MRImageStorage,
         DicomClassType.NMImageStorageRetired,
         DicomClassType.USImageStorage,
         DicomClassType.USImageStorageRetired,
         DicomClassType.USMultiFrameImageStorageRetired,
         DicomClassType.StandaloneOverlayStorage,
         DicomClassType.StandaloneCurveStorage,
         DicomClassType.BasicStudyDescriptor,
         DicomClassType.StandaloneModalityLutStorage,
         DicomClassType.StandaloneVoiLutStorage,   
         DicomClassType.XABiplaneImageStorageRetired,
         DicomClassType.RTDoseStorage,
         DicomClassType.RTStructureSetStorage,
         DicomClassType.RTPlanStorage,
         DicomClassType.StandalonePETCurveStorage,
         DicomClassType.StoredPrintStorage,
         DicomClassType.HCGrayscaleImageStorage,
         DicomClassType.HCColorImageStorage,
         DicomClassType.DXImageStoragePresentation,
         DicomClassType.DXImageStorageProcessing,
         DicomClassType.DXMammographyImageStoragePresentation,
         DicomClassType.DXMammographyImageStorageProcessing,
         DicomClassType.DXIntraoralImageStoragePresentation,
         DicomClassType.DXIntraoralImageStorageProcessing,
         DicomClassType.RTBeamsTreatmentRecordStorage,
         DicomClassType.RTBrachyTreatmentRecordStorage,
         DicomClassType.RTTreatmentSummaryRecordStorage,      
         DicomClassType.Patient,
         DicomClassType.Visit,
         DicomClassType.Study,
         DicomClassType.StudyComponent,
         DicomClassType.Results,
         DicomClassType.Interpretation,
         DicomClassType.BasicFilmSession,
         DicomClassType.BasicFilmBox,
         DicomClassType.BasicGrayscaleImageBox,
         DicomClassType.BasicColorImageBox,
         DicomClassType.BasicAnnotationBox,
         DicomClassType.PrintJob,
         DicomClassType.Printer,
         DicomClassType.VoiLutBoxRetired,
         DicomClassType.ImageOverlayBoxRetired, 
         DicomClassType.StorageCommitmentPushModel,
         DicomClassType.StorageCommitmentPullModel,
         DicomClassType.PrintQueue, 
         DicomClassType.ModalityPerformedProcedureStep,
         DicomClassType.PresentationLut,
         DicomClassType.PullPrintRequest,
         DicomClassType.PatientMeta,
         DicomClassType.StudyMeta,
         DicomClassType.ResultsMeta,
         DicomClassType.BasicGrayscalePrintMeta,
         DicomClassType.BasicColorPrintMeta,
         DicomClassType.ReferencedGrayscalePrintMetaRetired,
         DicomClassType.ReferencedColorPrintMetaRetired,
         DicomClassType.PullStoredPrintMeta,
         DicomClassType.PrinterConfiguration,
         DicomClassType.BasicPrintImageOverlayBox,
         DicomClassType.BasicDirectory,
         DicomClassType.PatientRootQueryPatient,
         DicomClassType.PatientRootQueryStudy,
         DicomClassType.PatientRootQuerySeries,
         DicomClassType.PatientRootQueryImage,
         DicomClassType.StudyRootQueryStudy,
         DicomClassType.StudyRootQuerySeries,
         DicomClassType.StudyRootQueryImage,
         DicomClassType.PatientStudyQueryPatient,
         DicomClassType.PatientStudyQueryStudy,
         DicomClassType.BasicTextSR,
         DicomClassType.EnhancedSR,
         DicomClassType.ComprehensiveSR,
         DicomClassType.ModalityWorklist,
         DicomClassType.GrayscaleSoftcopyPresentationState,
         DicomClassType.BasicVoiceAudio,   
         DicomClassType.TwelveLeadECG,
         DicomClassType.GeneralECG,
         DicomClassType.AmbulatoryECG,
         DicomClassType.Hemodynamic,
         DicomClassType.EnhancedMRImageStorage,
         DicomClassType.MRSpectroscopyStorage,
         DicomClassType.RawDataStorage,
         //DicomClassType.SCMULTIFRAMESINGLEBITIMAGESTORAGE,
         //DicomClassType.SCMULTIFRAMEGRAYSCALEBYTEIMAGESTORAGE,
         //DicomClassType.SCMULTIFRAMEGRAYSCALEWORDIMAGESTORAGE,
         //DicomClassType.SCMULTIFRAMETRUECOLORIMAGESTORAGE,
         DicomClassType.GeneralPurposeScheduledProcedureStep,
         DicomClassType.GeneralPurposePerformedProcedureStep,
         DicomClassType.GeneralPurposeWorklistManagementMeta,
         DicomClassType.KeyObjectSelectionDocument,
         DicomClassType.MammographyCADSR,
         DicomClassType.ChestCADSR,
         DicomClassType.GeneralPurposeWorklist,
         DicomClassType.Ophthalmic8BitPhotographyImageStorage,
         DicomClassType.Ophthalmic16BitPhotographyImageStorage,
         DicomClassType.StereometricRelationshipStorage,
      };

      private void _btn_OK_Click(object sender, EventArgs e)
      {
         int nIndex;

         nIndex = _lstBx.SelectedIndex;
         if (nIndex == -1)
         {
            m_nClass = DicomClassType.Max;
         }
         else
         {
            m_nClass = dataDictionary[nIndex];
         }

         m_nFlags = DicomDataSetInitializeFlags.ExplicitVR | DicomDataSetInitializeFlags.LittleEndian;
      }

      private void _lstBx_DoubleClick(object sender, EventArgs e)
      {
         _btn_OK_Click(_btn_OK, EventArgs.Empty);
         this.DialogResult = DialogResult.OK;
         this.Close();
      }
   }
}
