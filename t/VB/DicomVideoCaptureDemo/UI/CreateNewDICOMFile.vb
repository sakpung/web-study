' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports System
Imports DicomVideoCaptureDemo.DicomVideoCaptureDemo.Common

Namespace DicomVideoCaptureDemo.UI
   Partial Public Class CreateNewDICOMFile
      Inherits Form
      Public m_nClass As DicomClassType
      Public m_nFlags As DicomDataSetInitializeFlags
      Private dataDictionary As Dictionary(Of Integer, DicomClassType)

      Public Sub New()
         InitializeComponent()

         dataDictionary = New Dictionary(Of Integer, DicomClassType)()

         Dim pIOD As DicomIod
         Dim nIndex As Integer

         RemoveClasses()
         pIOD = DicomIodTable.Instance.GetFirst(Nothing, True)
         While pIOD IsNot Nothing
            nIndex = _lstBx.Items.Add(pIOD.Name)
            Dim item As String = TryCast(_lstBx.Items(nIndex), String)
            dataDictionary.Add(nIndex, pIOD.ClassCode)

            pIOD = DicomIodTable.Instance.GetNext(pIOD, True)
         End While
         _lstBx.SelectedIndex = 2
      End Sub

      Private Function IsSupportedIod(ByVal nClass As DicomClassType) As Boolean
         For i As Integer = 0 To m_DICOMUIDIOD.Length - 1
            If m_DICOMUIDIOD(i).nClass = nClass Then
               Return True
            End If
         Next i

         Return False
      End Function

      Private Sub RemoveClasses()
         Dim pClass As DicomIod = Nothing

         For nClass As DicomClassType = DicomClassType.CRImageStorage To CType(DicomClassType.Max - 1, DicomClassType)
            If (Not IsSupportedIod(nClass)) Then
               pClass = DicomIodTable.Instance.FindClass(nClass)
               If pClass IsNot Nothing Then
                  DicomIodTable.Instance.Delete(pClass)
               End If
            End If
         Next nClass
      End Sub


      Public Shared m_DICOMUIDIOD As MYDICOMUIDIOD() = {New MYDICOMUIDIOD(DicomClassType.NMImageStorage, DicomUidType.NMImageStorage), New MYDICOMUIDIOD(DicomClassType.USMultiFrameImageStorage, DicomUidType.USMultiframeImageStorage), New MYDICOMUIDIOD(DicomClassType.SCImageStorage, DicomUidType.SCImageStorage), New MYDICOMUIDIOD(DicomClassType.XAImageStorage, DicomUidType.XAImageStorage), New MYDICOMUIDIOD(DicomClassType.XRFImageStorage, DicomUidType.XrfImageStorage), New MYDICOMUIDIOD(DicomClassType.RTImageStorage, DicomUidType.RTImageStorage), _
       New MYDICOMUIDIOD(DicomClassType.PETImageStorage, DicomUidType.PETImageStorage), New MYDICOMUIDIOD(DicomClassType.VLEndoscopicImageStorage, DicomUidType.VLEndoscopicImageStorageClass), New MYDICOMUIDIOD(DicomClassType.VLMicroscopicImageStorage, DicomUidType.VLMicroscopicImageStorageClass), New MYDICOMUIDIOD(DicomClassType.VLSlideCoordinatesMicroscopicImageStorage, DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass), New MYDICOMUIDIOD(DicomClassType.VLPhotographicImageStorage, DicomUidType.VLPhotographicImageStorageClass), New MYDICOMUIDIOD(DicomClassType.BasicCardiacEP, DicomUidType.CardiacElectrophysiologyWaveformStorage), _
       New MYDICOMUIDIOD(DicomClassType.SCMultiFrameSingleBitImageStorage, DicomUidType.SCMultiFrameSingleBitImageStorage), New MYDICOMUIDIOD(DicomClassType.SCMultiFrameGrayscaleByteImageStorage, DicomUidType.SCMultiFrameGrayscaleByteImageStorage), New MYDICOMUIDIOD(DicomClassType.SCMultiFrameGrayscaleWordImageStorage, DicomUidType.SCMultiFrameGrayscaleWordImageStorage), New MYDICOMUIDIOD(DicomClassType.SCMultiFrameTrueColorImageStorage, DicomUidType.SCMultiFrameTrueColorImageStorage), New MYDICOMUIDIOD(DicomClassType.VideoEndoscopicImageStorage, DicomUidType.VideoEndoscopicImageStorage), New MYDICOMUIDIOD(DicomClassType.VideoMicroscopicImageStorage, DicomUidType.VideoMicroscopicImageStorage), _
       New MYDICOMUIDIOD(DicomClassType.VideoPhotographicImageStorage, DicomUidType.VideoPhotographicImageStorage)}

      'DicomClassType.NMIMAGESTORAGE,
      'DicomClassType.USMULTIFRAMEIMAGESTORAGE,
      'DicomClassType.SCIMAGESTORAGE,
      'DicomClassType.XAIMAGESTORAGE,
      'DicomClassType.XRFIMAGESTORAGE,
      'DicomClassType.RTIMAGESTORAGE,
      'DicomClassType.PETIMAGESTORAGE,
      'DicomClassType.VLENDOSCOPICIMAGESTORAGE,
      'DicomClassType.VLMICROSCOPICIMAGESTORAGE,
      'DicomClassType.VLSLIDECOORDINATESMICROSCOPICIMAGESTORAGE,
      'DicomClassType.VLPHOTOGRAPHICIMAGESTORAGE,
      'DicomClassType.BASICCARDIACEP

      'DicomClassType.SCMULTIFRAMESINGLEBITIMAGESTORAGE,
      'DicomClassType.SCMULTIFRAMEGRAYSCALEBYTEIMAGESTORAGE,
      'DicomClassType.SCMULTIFRAMEGRAYSCALEWORDIMAGESTORAGE,
      'DicomClassType.SCMULTIFRAMETRUECOLORIMAGESTORAGE,
      Shared RemoveList As DicomClassType() = {DicomClassType.CRImageStorage, DicomClassType.CTImageStorage, DicomClassType.MRImageStorage, DicomClassType.NMImageStorageRetired, DicomClassType.USImageStorage, DicomClassType.USImageStorageRetired, _
       DicomClassType.USMultiFrameImageStorageRetired, DicomClassType.StandaloneOverlayStorage, DicomClassType.StandaloneCurveStorage, DicomClassType.BasicStudyDescriptor, DicomClassType.StandaloneModalityLutStorage, DicomClassType.StandaloneVoiLutStorage, _
       DicomClassType.XABiplaneImageStorageRetired, DicomClassType.RTDoseStorage, DicomClassType.RTStructureSetStorage, DicomClassType.RTPlanStorage, DicomClassType.StandalonePETCurveStorage, DicomClassType.StoredPrintStorage, _
       DicomClassType.HCGrayscaleImageStorage, DicomClassType.HCColorImageStorage, DicomClassType.DXImageStoragePresentation, DicomClassType.DXImageStorageProcessing, DicomClassType.DXMammographyImageStoragePresentation, DicomClassType.DXMammographyImageStorageProcessing, _
       DicomClassType.DXIntraoralImageStoragePresentation, DicomClassType.DXIntraoralImageStorageProcessing, DicomClassType.RTBeamsTreatmentRecordStorage, DicomClassType.RTBrachyTreatmentRecordStorage, DicomClassType.RTTreatmentSummaryRecordStorage, DicomClassType.Patient, _
       DicomClassType.Visit, DicomClassType.Study, DicomClassType.StudyComponent, DicomClassType.Results, DicomClassType.Interpretation, DicomClassType.BasicFilmSession, _
       DicomClassType.BasicFilmBox, DicomClassType.BasicGrayscaleImageBox, DicomClassType.BasicColorImageBox, DicomClassType.BasicAnnotationBox, DicomClassType.PrintJob, DicomClassType.Printer, _
       DicomClassType.VoiLutBoxRetired, DicomClassType.ImageOverlayBoxRetired, DicomClassType.StorageCommitmentPushModel, DicomClassType.StorageCommitmentPullModel, DicomClassType.PrintQueue, DicomClassType.ModalityPerformedProcedureStep, _
       DicomClassType.PresentationLut, DicomClassType.PullPrintRequest, DicomClassType.PatientMeta, DicomClassType.StudyMeta, DicomClassType.ResultsMeta, DicomClassType.BasicGrayscalePrintMeta, _
       DicomClassType.BasicColorPrintMeta, DicomClassType.ReferencedGrayscalePrintMetaRetired, DicomClassType.ReferencedColorPrintMetaRetired, DicomClassType.PullStoredPrintMeta, DicomClassType.PrinterConfiguration, DicomClassType.BasicPrintImageOverlayBox, _
       DicomClassType.BasicDirectory, DicomClassType.PatientRootQueryPatient, DicomClassType.PatientRootQueryStudy, DicomClassType.PatientRootQuerySeries, DicomClassType.PatientRootQueryImage, DicomClassType.StudyRootQueryStudy, _
       DicomClassType.StudyRootQuerySeries, DicomClassType.StudyRootQueryImage, DicomClassType.PatientStudyQueryPatient, DicomClassType.PatientStudyQueryStudy, DicomClassType.BasicTextSR, DicomClassType.EnhancedSR, _
       DicomClassType.ComprehensiveSR, DicomClassType.ModalityWorklist, DicomClassType.GrayscaleSoftcopyPresentationState, DicomClassType.BasicVoiceAudio, DicomClassType.TwelveLeadECG, DicomClassType.GeneralECG, _
       DicomClassType.AmbulatoryECG, DicomClassType.Hemodynamic, DicomClassType.EnhancedMRImageStorage, DicomClassType.MRSpectroscopyStorage, DicomClassType.RawDataStorage, DicomClassType.GeneralPurposeScheduledProcedureStep, _
       DicomClassType.GeneralPurposePerformedProcedureStep, DicomClassType.GeneralPurposeWorklistManagementMeta, DicomClassType.KeyObjectSelectionDocument, DicomClassType.MammographyCADSR, DicomClassType.ChestCADSR, DicomClassType.GeneralPurposeWorklist, _
       DicomClassType.Ophthalmic8BitPhotographyImageStorage, DicomClassType.Ophthalmic16BitPhotographyImageStorage, DicomClassType.StereometricRelationshipStorage}

      Private Sub _btn_OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_OK.Click
         Dim nIndex As Integer

         nIndex = _lstBx.SelectedIndex
         If nIndex = -1 Then
            m_nClass = DicomClassType.Max
         Else
            m_nClass = dataDictionary(nIndex)
         End If

         m_nFlags = DicomDataSetInitializeFlags.ExplicitVR Or DicomDataSetInitializeFlags.LittleEndian
      End Sub

      Private Sub _lstBx_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _lstBx.DoubleClick
         _btn_OK_Click(_btn_OK, EventArgs.Empty)
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub
   End Class
End Namespace
