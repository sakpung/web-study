' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Namespace DicomDemo

   '* Object that contains objects and properties that needs to be shared between multiple pages.
   '
   Public Class Globals
      Public Shared _closing As Boolean = False
      
      ' Page 0
      Public m_nTimerMax As Integer

      ' Page 1
      Public m_MWLServer As DicomServer
      Public m_strMWLClientAE As String
      Public m_bMWLServerValid As Boolean

      ' Page 2
      Public m_nQueryType As Integer ' 1 = Broad, 2 = Patient
      ' Broad
      Public m_bCheckScheduledDate As Boolean
      Public m_bCheckModality As Boolean
      Public m_ScheduledDate As DateTime
      Public m_strModality As String
      ' Patient
      Public m_strAccessionNumber As String
      Public m_strPatientID As String
      Public m_strPatientName As String
      Public m_strRequestedProcedureID As String

      ' Modality Table
      'IF YOU ADD NEW ITEMS TO THIS LIST, MAKE SURE THEY ARE SORTED BY THE CLASS (1st parameter)
      Public m_ModalityTable As ModalityItem() = New ModalityItem() {New ModalityItem("CR", "Computed Radiography", DicomClassType.CRImageStorage), New ModalityItem("CT", "Computed Tomography", DicomClassType.CTImageStorage), New ModalityItem("DX", "Digital Radiography", DicomClassType.DXImageStoragePresentation), New ModalityItem("ES", "Endoscopy", DicomClassType.VLEndoscopicImageStorage), New ModalityItem("GM", "General Microscopy", DicomClassType.VLMicroscopicImageStorage), New ModalityItem("IO", "Intra-oral Radiography", DicomClassType.DXIntraoralImageStoragePresentation), New ModalityItem("MG", "Mammography", DicomClassType.DXMammographyImageStoragePresentation), New ModalityItem("MR", "Magnetic Resonance", DicomClassType.MRImageStorage), New ModalityItem("NM", "Nuclear Medicine", DicomClassType.NMImageStorage), New ModalityItem("PX", "Panoramic X-Ray", DicomClassType.DXImageStoragePresentation), New ModalityItem("RF", "Radio Fluoroscopy", DicomClassType.XRFImageStorage), New ModalityItem("RTDOSE", "Radiotherapy Dose", DicomClassType.RTDoseStorage), New ModalityItem("RTIMAGE", "Radiotherapy Image", DicomClassType.RTImageStorage), New ModalityItem("RTPLAN", "Radiotherapy Plan", DicomClassType.RTPlanStorage), New ModalityItem("RTSTRUCT", "Radiotherapy Structure Set", DicomClassType.RTStructureSetStorage), New ModalityItem("SC", "Secondary Capture Image", DicomClassType.SCImageStorage), New ModalityItem("SM", "Slide Microscopy", DicomClassType.VLSlideCoordinatesMicroscopicImageStorage), New ModalityItem("US", "Ultrasound", DicomClassType.USImageStorage), New ModalityItem("XA", "X-Ray Angiography", DicomClassType.XAImageStorage), New ModalityItem("XC", "External-camera Photography", DicomClassType.VLPhotographicImageStorage)}

      ' Page 3 and 4
      Public m_TreeResult As MyTreeView
      Public m_IconImageList As New ImageList
      Public m_nClass As DicomClassType

      ' Page 5
      Public m_DS As MyDicomDataSet
      Public m_bMandatoryElementsFilled As Boolean

      ' Page 6
      Public m_StorageServer As DicomServer
      Public m_strStorageClientAE As String
      Public m_bStoreOnServer As Boolean

      Public Sub New()
         ' Set default values and initialize objects
         ' PAGE 0
         m_nTimerMax = 15

         ' PAGE 1
         m_MWLServer = New DicomServer()
         m_MWLServer.AETitle = "LEAD_SERVER"
         m_MWLServer.Address = IPAddress.Parse("127.0.0.1")
         m_MWLServer.Port = 104

         m_strMWLClientAE = "LEAD_CLIENT"

         m_bMWLServerValid = False

         ' PAGE 2
         m_nQueryType = 1

         m_bCheckScheduledDate = False
         m_bCheckModality = False
         m_ScheduledDate = DateTime.Today
         m_strModality = m_ModalityTable(0).m_strValue

         m_strAccessionNumber = ""
         m_strPatientID = ""
         m_strPatientName = ""
         m_strRequestedProcedureID = ""

         ' PAGE 3 & 4
         m_TreeResult = New MyTreeView()
         m_TreeResult.Dock = DockStyle.Fill

         ' Build the icon image list
         m_IconImageList.Images.Add(My.Resources.icoElement)
         m_IconImageList.Images.Add(My.Resources.icoFolder)
         m_IconImageList.Images.Add(My.Resources.icoMissing)
         m_IconImageList.Images.Add(My.Resources.icoSequence)
         m_IconImageList.Images.Add(My.Resources.icoWorklist)

         m_TreeResult.ImageList = m_IconImageList

         ' PAGE 5
         m_DS = New MyDicomDataSet()

         ' Page 6
         m_StorageServer = New DicomServer()
         m_StorageServer.AETitle = "LEAD_SERVER"
         m_StorageServer.Address = IPAddress.Parse("127.0.0.1")
         m_StorageServer.Port = 104
         m_strStorageClientAE = "LEAD_CLIENT"
         m_bStoreOnServer = True
      End Sub
   End Class


   '
   '* Class used for populating and using the Modalities on Page2
   '
   Public Class ModalityItem
      Public m_strValue As String
      Public m_strDescription As String
      Public m_DicomClassType As DicomClassType

      Public Sub New()
         m_strValue = ""
         m_strDescription = ""
         m_DicomClassType = CType(0, DicomClassType)
      End Sub

      Public Sub New(ByVal Value As String, ByVal Description As String, ByVal ClassType As DicomClassType)
         m_strValue = Value
         m_strDescription = Description
         m_DicomClassType = ClassType
      End Sub

      Public Overrides Function ToString() As String
         Return m_strValue & " - " & m_strDescription
      End Function
   End Class

   '
   '* Enumeration type for the icons used by the MyTreeView and MyListView classes
   '
   Public Enum MyIconIndex As Integer
      Element
      Folder
      Missing
      Sequence
      Worklist
   End Enum
End Namespace
