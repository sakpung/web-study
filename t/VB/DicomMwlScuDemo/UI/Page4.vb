' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Codecs
Imports DialogUtilities
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Controls

Namespace DicomDemo
   Partial Public Class Page4 : Inherits UserControl
      Private _globals As Globals
      Private _rubberBandInteractiveMode As ImageViewerRubberBandInteractiveMode
      Private _rasterMagnifyGlass2 As ImageViewerMagnifyGlassInteractiveMode

      Public Property RubberBandInteractiveMode As ImageViewerRubberBandInteractiveMode
         Get
            Return _rubberBandInteractiveMode
         End Get
         Set(ByVal Value As ImageViewerRubberBandInteractiveMode)
            _rubberBandInteractiveMode = Value
         End Set
      End Property

      Public Property RasterMagnifyGlass2 As ImageViewerMagnifyGlassInteractiveMode
         Get
            Return _rasterMagnifyGlass2
         End Get
         Set(ByVal Value As ImageViewerMagnifyGlassInteractiveMode)
            _rasterMagnifyGlass2 = Value
         End Set
      End Property

      Public Property FullName() As String
         Get
            Return Me.Name
         End Get
         Set(ByVal Value As String)
            Me.Name = Value
         End Set
      End Property
      Public Sub New(ByRef pGlobals As Globals)
         InitializeComponent()

         _globals = pGlobals

         RubberBandInteractiveMode = New ImageViewerRubberBandInteractiveMode()
         RasterMagnifyGlass2 = New ImageViewerMagnifyGlassInteractiveMode()

         RubberBandInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         RubberBandInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSet
         RubberBandInteractiveMode.WorkOnBounds = True
         RubberBandInteractiveMode.IsEnabled = True
         Me.rasterImageViewer.InteractiveModes.Add(RubberBandInteractiveMode)

         RasterMagnifyGlass2.Crosshair = ImageViewerSpyGlassCrosshair.Fine
         RasterMagnifyGlass2.ScaleFactor = 2
         RasterMagnifyGlass2.WorkOnBounds = True
         RasterMagnifyGlass2.Shape = ImageViewerSpyGlassShape.Rectangle
         RasterMagnifyGlass2.Size = New Leadtools.LeadSize(150, 150)
         RasterMagnifyGlass2.IsEnabled = True
         Me.rasterImageViewer.InteractiveModes.Add(RasterMagnifyGlass2)
         Me.rasterImageViewer.InteractiveModes.EnableById(RasterMagnifyGlass2.Id)
      End Sub

      '
      '* After an element tree node is selected, update the text boxes with the element data
      '
      Private Sub m_TreeResult_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
         Try
            ' Get the root parent node
            Dim MWLNode As MyTreeNode = _globals.m_TreeResult.GetSelectedRootNode()

            txtSelectedWorklist.Text = MWLNode.Text
            txtModality.Text = Utils.GetStringValue(MWLNode.m_DS, DemoDicomTags.Modality, False)

            If Not (CType(e.Node, MyTreeNode)).m_Element Is Nothing Then
               txtElementValue.Text = (CType(e.Node, MyTreeNode)).m_DS.GetConvertValue((CType(e.Node, MyTreeNode)).m_Element)
            Else
               txtElementValue.Text = ""
            End If

            ' Disable the next button if the user doesn't have an image and an item selected
            CType(Parent.Parent, MainForm).btnNext.Enabled = ((Not rasterImageViewer.Image Is Nothing) AndAlso (Not _globals.m_TreeResult.SelectedNode Is Nothing))
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try


      End Sub

      '
      '* When this page is made active, add the global MWL tree view and add or remove the AfterSelect
      '*   event
      '
      Private Sub Page4_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.VisibleChanged
         Try
            If Visible Then
               ' Disable the next button if the user doesn't have an image and an item selected
               CType(Parent.Parent, MainForm).btnNext.Enabled = ((Not rasterImageViewer.Image Is Nothing) AndAlso (Not _globals.m_TreeResult.SelectedNode Is Nothing))


               ' Display the global results tree view
               panelTreeView.Controls.Add(_globals.m_TreeResult)

               ' Add needed events from the tree
               AddHandler _globals.m_TreeResult.AfterSelect, AddressOf m_TreeResult_AfterSelect
            Else
               ' Remove events from the tree since we're not using this page anymore
               RemoveHandler _globals.m_TreeResult.AfterSelect, AddressOf m_TreeResult_AfterSelect
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Loads an image into the viewer
      '
      Private Sub btnSelectImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectImage.Click
         Try
            Using codecs As New RasterCodecs()

               Dim loader As ImageFileLoader = New ImageFileLoader()

               loader.ShowLoadPagesDialog = True

               If loader.Load(Me, codecs, True) > 0 Then
                  rasterImageViewer.Image = loader.Image.Clone()
                  CType(Parent.Parent, MainForm).btnNext.Enabled = True
               End If

               ' Disable the next button if the user doesn't have an image and an item selected
               CType(Parent.Parent, MainForm).btnNext.Enabled = ((Not rasterImageViewer.Image Is Nothing) AndAlso (Not _globals.m_TreeResult.SelectedNode Is Nothing))
            End Using
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Creates a new dataset based off of the MWL dataset
      '
      Public Function CreateDataset() As CreateDatasetReturn
         Dim nRet As CreateDatasetReturn = CreateDatasetReturn.GeneralError

         Try

            ' Check for a selected node
            If _globals.m_TreeResult.SelectedNode Is Nothing Then
               Return CreateDatasetReturn.NoItemSelected
            End If

            ' Make sure that the modality is supported            
            nRet = CreateDatasetReturn.ModalityNotFound
            Dim strModality As String = Utils.GetStringValue((CType(_globals.m_TreeResult.SelectedNode, MyTreeNode)).m_DS, DemoDicomTags.Modality, False)
            Dim nClass As DicomClassType = DicomClassType.SCImageStorage ' use SCImageStorage if we cannot find the modality

            Dim i As Integer = 0
            Do While i < _globals.m_ModalityTable.Length
               If strModality = _globals.m_ModalityTable(i).m_strValue Then
                  ' Modality was found, change return type to Success
                  nClass = _globals.m_ModalityTable(i).m_DicomClassType
                  nRet = CreateDatasetReturn.Success
                  Exit Do
               End If
               i += 1
            Loop

            ' Initialize dataset
            Dim ds As MyDicomDataSet = New MyDicomDataSet()
#If LEADTOOLS_V16_OR_LATER Then
				ds.Initialize(nClass, DicomDataSetInitializeFlags.ImplicitVR Or DicomDataSetInitializeFlags.LittleEndian Or DicomDataSetInitializeFlags.AddMandatoryElementsOnly Or DicomDataSetInitializeFlags.AddMandatoryModulesOnly)
#Else
            ds.Initialize(nClass, DicomDataSetInitializeType.ImplicitVRLittleEndian)
#End If
            ds.MapMWLtoDS((CType(_globals.m_TreeResult.SelectedNode, MyTreeNode)).m_DS)
            ds.SetTagSpecificCharacterSet()
            ds.SetTagInstanceNumber(1)

            ' Set Pixel Data
            Dim PixelDataElement As DicomElement = ds.FindFirstElement(Nothing, DemoDicomTags.PixelData, True)
            If Not PixelDataElement Is Nothing Then
               ds.DeleteElement(PixelDataElement)
               PixelDataElement = ds.InsertElement(Nothing, False, DemoDicomTags.PixelData, DicomVRType.OB, False, 0)
            End If

            ' use RGB as default Photometric Interpretation
            Dim nPhotometric As DicomImagePhotometricInterpretationType = DicomImagePhotometricInterpretationType.Rgb
            If Not rasterImageViewer.Image Is Nothing Then
               If rasterImageViewer.Image.Order = Leadtools.RasterByteOrder.Gray Then
                  nPhotometric = DicomImagePhotometricInterpretationType.Monochrome2
               ElseIf Convert.ToInt32(rasterImageViewer.Image.Order) <= 8 Then
                  nPhotometric = DicomImagePhotometricInterpretationType.PaletteColor
               Else
                  nPhotometric = DicomImagePhotometricInterpretationType.Rgb
               End If

               ds.InsertImage(PixelDataElement, rasterImageViewer.Image, 0, DicomImageCompressionType.None, nPhotometric, 0, 0, DicomSetImageFlags.AutoSetVoiLut)
            End If

            ds.DeleteEmptyElementsType3(nClass)
            ds.DeleteEmptyModulesOptional(nClass)

            If Not nPhotometric = DicomImagePhotometricInterpretationType.PaletteColor Then

#if (LTV15_CONFIG)
               If ds.IsEmptyModule(DicomModuleType.PaletteColorLoockupTable) Then
                  ds.DeleteModule(DicomModuleType.PaletteColorLoockupTable)
               End If
#else
               If ds.IsEmptyModule(DicomModuleType.PaletteColorLookupTable) Then
                  ds.DeleteModule(DicomModuleType.PaletteColorLookupTable)
               End If
#End If
                End If

            ' Generate new series instance UID and SOP Instance UID
            ds.InsertUID(DemoDicomTags.SeriesInstanceUID)
            ds.InsertUID(DemoDicomTags.SOPInstanceUID)

            ' If the MWL already had a study instance UID, we use that
            ' If not, generate a new UID
            ds.GenerateStudyInstanceUID()

            _globals.m_nClass = nClass
            _globals.m_DS = ds
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try

         Return nRet
      End Function

      '
      '* Enumeration type for the return value of CreateDataset()
      '
      Public Enum CreateDatasetReturn As Integer
         Success
         GeneralError
         NoItemSelected
         ModalityNotFound
      End Enum
   End Class
End Namespace
