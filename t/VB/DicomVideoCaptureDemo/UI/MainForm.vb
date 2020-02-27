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
Imports System.IO
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Dicom
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Multimedia
Imports System.Reflection
Imports LMMPEG2EncoderLib
Imports LTDicWrtLib
Imports System.Runtime.InteropServices
Imports DicomVideoCaptureDemo.DicomVideoCaptureDemo.Common
Imports System
Imports DicomVideoCaptureDemo.DicomVideoCaptureDemo.UI

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Namespace DicomVideoCaptureDemo
   Partial Public Class MainForm
      Inherits Form
#Region "Variables"
      Public CaptureCtrl1 As New CaptureCtrl()
      Public Shared mainForm As MainForm
      Private m_DS As DicomDataSet
      Private m_pDICOMIOD As DicomIod
      Private m_bDataSetInitialized As Boolean = False
      Private _modified As Boolean
      Private _bMMCapabilitiesInitialized As Boolean
      Private m_bNowPlaying As Boolean
      Private m_nInstanceNumber As Integer
      Private m_CompressionType As DICOMVID_IMAGE_COMPRESSION
      Private m_nQFactor As Integer
      Private m_DicomWriter As ILTDicWrt
      Private m_pDICOMFilter As Object
      Private _timer As Timer

#End Region

#Region "Device Click Menu"
      Private Sub VideoDeviceClick(ByVal sender As Object, ByVal e As System.EventArgs)
         If _bMMCapabilitiesInitialized Then
            'Point to menu item clicked
            Dim objCurMenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

            Try
               CaptureCtrl1.VideoDevices.Selection = CInt(objCurMenuItem.Tag) - 1
            Catch
               MessageBox.Show("This video capture device is not available. Make sure no other program is using the device or try changing the display resolution", "Error")
            End Try

            objCurMenuItem = Nothing
            UpdateMenuStatus()
         End If
      End Sub

      Private Sub AudioDeviceClick(ByVal sender As Object, ByVal e As System.EventArgs)
         If _bMMCapabilitiesInitialized Then
            Try
               'Point to menu item clicked
               Dim objCurMenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
               CaptureCtrl1.AudioDevices.Selection = CInt(objCurMenuItem.Tag) - 1
               objCurMenuItem = Nothing
            Catch ex As System.Exception
               MessageBox.Show("This audio capture device is not available." & Environment.NewLine & "Make sure no other program is using the device." & Environment.NewLine & "If you have a player running, you can try setting " & Environment.NewLine & "the player so it plays to the MIDI device")
            End Try

            UpdateMenuStatus()
         End If
      End Sub
#End Region

#Region "CaptureCtrl Events"

      Private Sub CaptureCtrl1_Progress(ByVal sender As Object, ByVal e As ProgressEventArgs)
         'WriteCaptureStatus(false);
      End Sub

      Private Sub CaptureCtrl1_ErrorAbort(ByVal sender As Object, ByVal e As ErrorAbortEventArgs)
         MessageBox.Show(" Error " & System.Convert.ToString(e.errorcode) & " occurred in your Application.")
         'UpdateMenuStatus();
      End Sub

      Private Sub MenuFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         Close()
      End Sub


      Private Sub CaptureCtrl1_Complete(ByVal sender As Object, ByVal e As System.EventArgs)
         'MenuFileSelectCaptureFile.Enabled = true;
         'UpdateMenuStatus();
      End Sub

      Private Sub CaptureCtrl1_KeyDownEvent(ByVal sender As Object, ByVal e As KeyDownEventArgs)
         If (e.keyCode = &H1B) And (CaptureCtrl1.FullScreenMode) Then
            CaptureCtrl1.ToggleFullScreenMode()
            e.keyCode = 0
         End If
      End Sub

      Private Sub _panel_CapturePanel_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _panel_CapturePanel.Resize
         Me.CaptureCtrl1.Size = New System.Drawing.Size(_panel_CapturePanel.Size.Width - 10, _panel_CapturePanel.Size.Height - 10)
      End Sub
#End Region

#Region "Menu Events"
      Private Sub _mi_captureProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_captureProperties.Click
         If _bMMCapabilitiesInitialized = False Then
            Return
         End If

         CaptureCtrl1.Preview = False
         CaptureCtrl1.ShowDialog(CaptureDlg.Capture, Me)
         CaptureCtrl1.Preview = True
      End Sub

      Private Sub _mi_compressionSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_compressionSettings.Click
         CaptureCtrl1.Preview = False
         Dim CompressionSettingsDlg As New CompressionSettingsDlg()
         CompressionSettingsDlg.ShowDialog()
         CaptureCtrl1.Preview = True
      End Sub

      Private Sub _mi_About_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_About.Click
#If LEADTOOLS_V19_OR_LATER Then
         Using aboutDialog As New AboutDialog("Dicom Video Capture", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
#Else
         Using aboutDialog As New AboutDialog("Dicom Video Capture")
	         aboutDialog.ShowDialog(Me)
         End Using
#End If
      End Sub

      Private Sub _mi_Toolbar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_Toolbar.Click
         _toolbar_Main.Enabled = Not _mi_Toolbar.Checked
         _toolbar_Main.Visible = Not _mi_Toolbar.Checked


         UpdateMenuStatus()
      End Sub

      Private Sub _mi_NewFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_NewFile.Click
         Dim newDicomDlg As New CreateNewDICOMFile()

         Select Case CheckDirtyFlag()
            Case DialogResult.Yes
               OnFileSaveAs()
               Exit Select
            Case DialogResult.No
               Exit Select
            Case DialogResult.Cancel
               Return
         End Select

         'Get class (IOD) for the new DICOM file
         If newDicomDlg.ShowDialog() = DialogResult.OK Then
            Dim Wait As New WaitCursor()

            ' Prepare a new data set 
            Reset()
            If Not CreateDICOMFileFromTemplate(newDicomDlg.m_nClass) Then
               m_DS.Initialize(newDicomDlg.m_nClass, newDicomDlg.m_nFlags)
            End If

            ' Remove any optional elements from 
            ' the dataset and set some default values 
            CleanDSAndSetDefaultValues(newDicomDlg.m_nClass, m_DS, False)

            ' Is this IOD in our list ?
            If (InlineAssignHelper(m_pDICOMIOD, GetDSIOD(m_DS))) Is Nothing Then
               MessageBox.Show("Could not create a new DICOM file")
               Return
            End If
            'Yes we have a valid dataset
            m_bDataSetInitialized = True
            ' Update the elements tree
            updateTreeView()
            SetModifiedFlag(True)
         End If

         UpdateMenuStatus()

      End Sub

      Private Sub _mi_OpenFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_OpenFile.Click
         Select Case CheckDirtyFlag()
            Case DialogResult.Yes
               OnFileSaveAs()
               Exit Select
            Case DialogResult.No
               Exit Select
            Case DialogResult.Cancel
               Return
         End Select

         Dim dlg As New OpenFileDialog()
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|DICOM Files (*.dic)|*.dic|All files (*.*)|*.*"

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim Wait As New WaitCursor()
            Reset()
            ' Load Data Set from this file.
            m_DS.Load(dlg.FileName, DicomDataSetLoadFlags.None)

            ' Is this IOD in our list ?
            If (InlineAssignHelper(m_pDICOMIOD, GetDSIOD(m_DS))) Is Nothing Then
               m_DS.Reset()
               MessageBox.Show("This DICOM file does not support multi-frame images")


            Else
               ChangeDSToAcceptCompressed()
               m_bDataSetInitialized = True
            End If
            ' Update the elements tree
            updateTreeView()
            UpdateMenuStatus()
         End If
      End Sub

      Private Sub _mi_SaveFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_SaveFile.Click
         Dim dlg As New SaveFileDialog()
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|All files (*.*)|*.*"

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim strOutputFileName As String = GetOutputFileName()
            If strOutputFileName.Length > 0 Then
               Dim VideoStreamIntoDataset As New DicomDataSet()
               Try
                  VideoStreamIntoDataset.Load(strOutputFileName, DicomDataSetLoadFlags.None)
                  m_DS.Copy(VideoStreamIntoDataset, Nothing, Nothing)
               Catch generatedExceptionName As Exception
               End Try

               m_DS.Save(dlg.FileName, DicomDataSetSaveFlags.GroupLengths Or DicomDataSetSaveFlags.MetaHeaderPresent)
            End If
            SetModifiedFlag(False)
         End If
      End Sub

      Private Sub _mi_CloseFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_CloseFile.Click
         Select Case CheckDirtyFlag()
            Case DialogResult.Yes
               OnFileSaveAs()
               Exit Select
            Case DialogResult.No
               Exit Select
            Case DialogResult.Cancel
               Return
         End Select
         Reset()


         Dim strOutputFileName As String = GetOutputFileName()
         If strOutputFileName.Length > 0 Then
            File.Delete(strOutputFileName)
         End If

         UpdateMenuStatus()
         updateTreeView()
      End Sub

      Private Sub _mi_StartCaptureIntoDicomFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_StartCaptureIntoDicomFile.Click
         If False = _bMMCapabilitiesInitialized Then
            Return
         End If

         If Not m_bDataSetInitialized Then
            MessageBox.Show("Before you start capturing please either load a DICOM file or create a new one.")
            Return
         End If

         CaptureCtrl1.Preview = False
         If GetCompression() = DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2 Then
            MessageBox.Show("Warning: Compressing MPEG2 data requires high computation power. We recommend using a high-end machine capable of handling this type of load." & Environment.NewLine & "Please note that the size (width and height) of the video you capture heavily affects the speed of the compression process. For example compressing a (640X480) video is approximately four times slower than compressing a (320X240) video. You can change the size of the video by adjusting the ""Capture Properties"" from the ""Options"" menu.")
         End If
         CaptureCtrl1.Preview = True

         Dim Wait As New WaitCursor()

         Dim strTemplate As String = GetTemplateFileName(True)
         Dim strOutput As String = GetOutputFileName()

         m_DicomWriter.DICOMTemplateFile = strTemplate
         CaptureCtrl1.TargetFile = strOutput

         ' Ok start capturing now
         If GetCompression() = DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2 Then
            Dim devices As Devices
            Dim index As Integer = -1
            devices = CaptureCtrl1.AudioDevices
            index = devices.Selection
            If index = -1 Then
               CaptureCtrl1.StartCapture(CaptureMode.Video)
            Else
               CaptureCtrl1.StartCapture(CaptureMode.VideoAndAudio)

            End If
         Else
            CaptureCtrl1.StartCapture(CaptureMode.Video)
         End If

         'Show the user that capturing is in progress
         StartToolbarPlay()
         SetModifiedFlag(True)

         UpdateMenuStatus()
      End Sub

      Private Sub _mi_StopCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_StopCapture.Click
         Dim Wait As New WaitCursor()

         If False = _bMMCapabilitiesInitialized Then
            Return
         End If

         CaptureCtrl1.StopCapture()
         StopToolbarPlay()

         UpdateMenuStatus()
      End Sub

      Public Sub UpdateMenuStatus()
         ' Uncheck Menus
         For Each menuItem As ToolStripMenuItem In _mi_VideoDevice.DropDownItems
            menuItem.Checked = False
            menuItem.Enabled = Not IsCapturing()
         Next

         For Each menuItem As ToolStripMenuItem In _mi_AudioDevice.DropDownItems
            menuItem.Checked = False
            menuItem.Enabled = Not IsCapturing()
         Next

         ' Check Menus
         CType(_mi_VideoDevice.DropDownItems(CaptureCtrl1.VideoDevices.Selection + 1), ToolStripMenuItem).Checked = True
         CType(_mi_AudioDevice.DropDownItems(CaptureCtrl1.AudioDevices.Selection + 1), ToolStripMenuItem).Checked = True

         _mi_Toolbar.Checked = _toolbar_Main.Enabled


         _mi_CloseFile.Enabled = m_bDataSetInitialized AndAlso Not IsCapturing()
         _mi_SaveFile.Enabled = InlineAssignHelper(_tS_Save.Enabled, m_bDataSetInitialized AndAlso Not IsCapturing())
         _mi_NewFile.Enabled = InlineAssignHelper(_tS_New.Enabled, Not IsCapturing())
         _mi_OpenFile.Enabled = InlineAssignHelper(_tS_Open.Enabled, Not IsCapturing())

         If _bMMCapabilitiesInitialized Then
            Dim state As CaptureState
            state = CaptureCtrl1.State
            Dim f As Boolean
            f = CaptureCtrl1.IsModeAvailable(CaptureMode.Video)
            _mi_StartCaptureIntoDicomFile.Enabled = f AndAlso (state <> CaptureState.Running)
            _mi_StopCapture.Enabled = IsCapturing()
            _mi_compressionSettings.Enabled = m_bDataSetInitialized AndAlso Not IsCapturing()
            f = CaptureCtrl1.HasDialog(CaptureDlg.Capture)

            _mi_captureProperties.Enabled = f AndAlso (state <> CaptureState.Running)
         Else
            _mi_StartCaptureIntoDicomFile.Enabled = False
            _mi_StopCapture.Enabled = False
            _mi_compressionSettings.Enabled = False
            _mi_captureProperties.Enabled = False
         End If
      End Sub

#End Region

#Region "Toolbar Events"

      Private Sub toolStripButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tS_New.Click
         _mi_NewFile_Click(Nothing, Nothing)
      End Sub

      Private Sub toolStripButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tS_Open.Click
         _mi_OpenFile_Click(Nothing, Nothing)
      End Sub

      Private Sub toolStripButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tS_Save.Click
         _mi_SaveFile_Click(Nothing, Nothing)
      End Sub

      Private Sub toolStripButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tS_Help.Click
         _mi_About_Click(Nothing, Nothing)
      End Sub

#End Region

#Region "TreeView Methods"
      Private Sub updateTreeView()
         _treeView.Nodes.Clear()
         If m_DS IsNot Nothing Then
            If m_DS.InformationClass = DicomClassType.BasicDirectory Then
               Return
            End If

            If _treeView.ImageList Is Nothing OrElse _treeView.ImageList.Images.Count = 0 Then
               _treeView.ImageList = New ImageList()
               _treeView.ImageList.Images.Add(My.Resources.STORAGE1)
               _treeView.ImageList.Images.Add(My.Resources.STORAGE2)

               _treeView.ImageList.Images.Add(My.Resources.STREAM)
            End If

            DoFillDICOMElementsTree(m_DS, Nothing, Nothing)
         End If
      End Sub

      Private Sub DoFillDICOMElementsTree(ByVal pDS As DicomDataSet, ByVal hParentTree As TreeNode, ByVal pParentElement As DicomElement)
         Dim i As Integer
         Dim j As UInt32
         Dim nCount As Integer
         Dim nClass As DicomClassType
         Dim nFlags As DicomDataSetFlags
         Dim pModule As DicomModule
         Dim pElement As DicomElement
         Dim pIOD As DicomIod
         Dim hItem As TreeNode
         Dim strName As String


         If pParentElement Is Nothing Then

            nClass = pDS.InformationClass
            nFlags = pDS.InformationFlags
            nCount = pDS.ModuleCount
            For i = 0 To nCount - 1
               pModule = pDS.FindModuleByIndex(i)
               If pModule IsNot Nothing Then
                  pIOD = DicomIodTable.Instance.FindModule(nClass, pModule.Type)
                  If pIOD IsNot Nothing Then
                     strName = pIOD.Name
                  Else
                     strName = "Unknown"
                  End If

                  hParentTree = _treeView.Nodes.Add(strName, strName, 0, 0)
                  'hParentTree = GetTreeCtrl ().InsertItem( strName, 
                  '                                                   GetImage(IDB_STORAGE_COLLAPSED), 
                  '                                                   GetImage(IDB_STORAGE_COLLAPSED), 
                  '                                                   TVI_ROOT, 
                  '                                                   TVI_LAST);
                  '                  GetTreeCtrl ().SetItemState(hParentTree, TVIS_BOLD, TVIS_BOLD);


                  For j = 0 To CUInt(pModule.Elements.Length - 1)
                     hItem = InsertElement(hParentTree, pModule.Elements(CInt(j)))
                     If pDS.GetChildElement(pModule.Elements(CInt(j)), True) IsNot Nothing Then
                        DoFillDICOMElementsTree(pDS, hItem, pModule.Elements(CInt(j)))
                     End If
                  Next
               End If
            Next
         Else
            pElement = pDS.GetChildElement(pParentElement, True)
            While pElement IsNot Nothing
               hItem = InsertElement(hParentTree, pElement)

               If (pElement.Length = &HFFFFFFFFUI) AndAlso (pDS.GetChildElement(pElement, True) IsNot Nothing) Then
                  If pDS.GetChildElement(pElement, True) IsNot Nothing Then
                     DoFillDICOMElementsTree(pDS, hItem, pElement)
                  End If
               End If

               pElement = pDS.GetNextElement(pElement, True, True)
            End While
         End If
      End Sub

      Private Function InsertElement(ByVal hParentTree As TreeNode, ByVal pElement As DicomElement) As TreeNode
         Dim strName As String = Nothing
         Dim pTag As DicomTag = Nothing
         Dim hItem As TreeNode = Nothing
         Dim strValue As String = Nothing


         pTag = DicomTagTable.Instance.Find(pElement.Tag)

         strName = String.Format("{0:X4}:{1:X4} - {2}", pElement.Tag >> 16, pElement.Tag And &HFFFF, If((pTag IsNot Nothing), pTag.Name, "Unknown"))

         GetElementValue(pElement, strValue)
         strName = strName & " : "
         If strValue IsNot Nothing AndAlso strValue.Length > 0 Then
            strName = strName & strValue
         End If
         If pElement.Length = &HFFFFFFFFUI Then
            hItem = hParentTree.Nodes.Add(strName, strName, 0, 0)
         Else
            hItem = hParentTree.Nodes.Add(strName, strName, 2, 2)
         End If

         If hItem IsNot Nothing Then
            hItem.Tag = pElement
         End If

         Return hItem
      End Function


      Private Sub _treeView_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles _treeView.NodeMouseDoubleClick
         Dim hItem As TreeNode = e.Node
         If hItem IsNot Nothing Then
            Dim pElement As DicomElement = CType(hItem.Tag, DicomElement)
            If (pElement IsNot Nothing) AndAlso (pElement.Tag <> DicomTag.PixelData) Then
               Dim strName As String
               Dim pTag As DicomTag
               Dim strValue As String = ""
               Dim dlg As New DicomModifyElementDlg()

               pTag = DicomTagTable.Instance.Find(pElement.Tag)
               If pTag Is Nothing Then
                  Return
               End If
               strName = String.Format("{0}", If((pTag IsNot Nothing), pTag.Name, "Unknown"))
               GetElementValue(pElement, strValue)
               strName = strName & " : "

               Dim pDS As DicomDataSet = m_DS
               If pDS IsNot Nothing Then
                  dlg.m_pDicomIOD = DicomIodTable.Instance.Find(m_pDICOMIOD, pElement.Tag, DicomIodType.Element, False)
                  dlg.m_pElement = pElement
                  dlg.m_strValue = strValue
                  dlg.m_nCount = pDS.GetElementValueCount(pElement)
                  If (dlg.m_pDicomIOD IsNot Nothing) AndAlso (dlg.ShowDialog() = DialogResult.OK) Then
                     dlg.m_strValue.TrimStart()
                     dlg.m_strValue.TrimEnd()
                     pDS.FreeElementValue(dlg.m_pElement)
                     pDS.SetConvertValue(dlg.m_pElement, dlg.m_strValue, dlg.m_nCount)
                     strValue = ""
                     strValue = String.Format("{0:X4}:{1:X4} - {2}", CType(pElement.Tag >> 16, UInt16), CType(pElement.Tag And &HFFFF, UInt16), If((pTag IsNot Nothing), pTag.Name, "Unknown"))
                     strValue = (strValue & " : ") + dlg.m_strValue
                     hItem.Text = strValue
                     SetModifiedFlag(True)
                  End If
               End If
            End If
         End If
      End Sub
#End Region

#Region "MainForm Events"
      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         If (mainForm Is Nothing) Then
            mainForm = Me
         End If

         InitMMCapabilities()
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         Select Case CheckDirtyFlag()
            Case DialogResult.Yes
               OnFileSaveAs()
               Exit Select
            Case DialogResult.No
               Exit Select
            Case DialogResult.Cancel
               e.Cancel = True
               Exit Select
         End Select
      End Sub
#End Region

#Region "Public Methods"
      Public Sub SetQFactor(ByVal nQFactor As Integer)
         If nQFactor < Helper.Q_FACTOR_MIN Then
            nQFactor = Helper.Q_FACTOR_MIN
         End If
         If nQFactor > Helper.Q_FACTOR_MAX Then
            nQFactor = Helper.Q_FACTOR_MAX
         End If
         m_nQFactor = nQFactor
         m_DicomWriter.CompressionQuality = m_nQFactor
      End Sub

      Public Function GetQFactor() As Integer
         Return m_nQFactor

      End Function

      Public Sub SetCompression(ByVal ImageCompression As DICOMVID_IMAGE_COMPRESSION)
         m_CompressionType = ImageCompression
         Dim TargetFormat As DICOM_WRITER_FILTER_TARGET_FORMAT = DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM

         If m_CompressionType = DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2 Then
            TargetFormat = DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_MPEG2
         Else
            Dim nDICOMCompression As DICOMCOMPRESSION = DICOMCOMPRESSION.COMP_UNCOMPRESSED
            TargetFormat = DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM
            Select Case m_CompressionType
               Case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE
                  nDICOMCompression = DICOMCOMPRESSION.COMP_UNCOMPRESSED
                  Exit Select
               Case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSLESS
                  nDICOMCompression = DICOMCOMPRESSION.COMP_LOSSLESSJPEG
                  Exit Select
               Case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY
                  nDICOMCompression = DICOMCOMPRESSION.COMP_JPEG422
                  Exit Select
               Case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSLESS
                  nDICOMCompression = DICOMCOMPRESSION.COMP_LOSSLESSJPEG2000
                  Exit Select
               Case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSY
                  nDICOMCompression = DICOMCOMPRESSION.COMP_JPEG2000
                  Exit Select
               Case Else
                  Return

            End Select

            m_DicomWriter.CompressionFormat = CInt(nDICOMCompression)
         End If

         SetTargetFormat(TargetFormat)
      End Sub

      Public Function GetCompression() As DICOMVID_IMAGE_COMPRESSION
         Return m_CompressionType
      End Function

      Public Sub ShowMPEG2OptionsDlg()
         If GetCompression() = DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2 Then
            CaptureCtrl1.ShowDialog(CaptureDlg.VideoCompressor, Me)
         Else
            CaptureCtrl1.ShowDialog(CaptureDlg.TargetFormat, Me)
         End If

         CaptureCtrl1.StopCapture()
      End Sub

      Public Sub ShowMPEG2AudioOptionsDlg()
         If GetCompression() = DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2 Then
            CaptureCtrl1.ShowDialog(CaptureDlg.AudioCompressor, Me)
         End If

         CaptureCtrl1.StopCapture()
      End Sub
#End Region

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Medical) Then
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Public Sub New()
         InitializeComponent()

         ' Setup the caption for this demo
         Messager.Caption = "C# Dicom Video Capture Demo"

         DicomEngine.Startup()
         m_DS = New DicomDataSet()
      End Sub

      Private Function InitMMCapabilities() As Boolean
         m_DicomWriter = Nothing
         _bMMCapabilitiesInitialized = False
         CreateTargetFormats()

         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         CType(Me.CaptureCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.CaptureCtrl1.AudioDevices.Selection = -1
         Me.CaptureCtrl1.Location = New System.Drawing.Point(5, 5)
         Me.CaptureCtrl1.Name = "CaptureCtrl1"
         Me.CaptureCtrl1.OcxState = CType(resources.GetObject("CaptureCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
         Me.CaptureCtrl1.Size = New System.Drawing.Size(_panel_CapturePanel.Size.Width - 10, _panel_CapturePanel.Size.Height - 10)
         Me.CaptureCtrl1.TabIndex = 3
         Me.CaptureCtrl1.VideoDevices.Selection = -1

         AddHandler Me.CaptureCtrl1.KeyDown, New KeyDownEventHandler(AddressOf Me.CaptureCtrl1_KeyDownEvent)
         AddHandler Me.CaptureCtrl1.ErrorAbort, New ErrorAbortEventHandler(AddressOf Me.CaptureCtrl1_ErrorAbort)
         AddHandler Me.CaptureCtrl1.Complete, New System.EventHandler(AddressOf Me.CaptureCtrl1_Complete)
         AddHandler Me.CaptureCtrl1.Progress, New ProgressEventHandler(AddressOf Me.CaptureCtrl1_Progress)

         Me.CaptureCtrl1.BackColor = Color.White
         Me._panel_CapturePanel.Controls.Add(Me.CaptureCtrl1)
         CaptureCtrl1.EnterEdit()
         CaptureCtrl1.VideoWindowSizeMode = SizeMode.Normal
         CaptureCtrl1.Preview = True
         CaptureCtrl1.LeaveEdit()

         Dim pUnk As IntPtr = Marshal.GetIUnknownForObject(m_pDICOMFilter)
         Dim guid As Guid = GetType(ILTDicWrt).GUID
         Dim pI As IntPtr
         Marshal.QueryInterface(pUnk, guid, pI)

         m_DicomWriter = TryCast(Marshal.GetObjectForIUnknown(pI), ILTDicWrt)
         _bMMCapabilitiesInitialized = True
         SetCompression(DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE)
         SetQFactor(Helper.Q_FACTOR_MIN)

         BuildDeviceMenu()
         UpdateMenuStatus()
         Return True
      End Function

      Private Sub BuildDeviceMenu()
         Dim count As Integer = 0
         Dim name As String = Nothing

         count = CaptureCtrl1.VideoDevices.Count
         ' Adding the 'None' menu Item.
         ' Set the caption to 'None'.
         Dim menuItem1 As New ToolStripMenuItem("None")
         menuItem1.Tag = _mi_VideoDevice.DropDownItems.Count
         _mi_VideoDevice.DropDownItems.Add(menuItem1)
         AddHandler menuItem1.Click, New System.EventHandler(AddressOf VideoDeviceClick)

         If count > 0 Then
            ' Adding the Video Devices to the Video Device menu item.
            For Each dev As Device In CaptureCtrl1.VideoDevices
               ' Get the Device name
               name = dev.FriendlyName
               ' Create the Menu Item.
               Dim menuItem2 As New ToolStripMenuItem(name)
               menuItem2.Tag = _mi_VideoDevice.DropDownItems.Count
               _mi_VideoDevice.DropDownItems.Add(menuItem2)
               AddHandler menuItem2.Click, New System.EventHandler(AddressOf VideoDeviceClick)
            Next
         End If

         count = CaptureCtrl1.AudioDevices.Count
         ' Adding the 'None' menu Item.
         ' Set the caption to 'None'.
         Dim menuItem3 As New ToolStripMenuItem("None")
         menuItem3.Tag = _mi_AudioDevice.DropDownItems.Count
         _mi_AudioDevice.DropDownItems.Add(menuItem3)
         AddHandler menuItem3.Click, New System.EventHandler(AddressOf AudioDeviceClick)

         If count > 0 Then
            ' Adding the Audio Devices to the Audio Device menu item.
            For Each dev As Device In CaptureCtrl1.AudioDevices
               ' Get the Device name
               name = dev.FriendlyName
               Dim menuItem2 As New ToolStripMenuItem(name)
               menuItem2.Tag = _mi_AudioDevice.DropDownItems.Count
               _mi_AudioDevice.DropDownItems.Add(menuItem2)
               ' Create the Menu Item.
               AddHandler menuItem2.Click, New System.EventHandler(AddressOf AudioDeviceClick)
            Next
         End If
      End Sub

#Region "Methods"
      Private Function GetDSIOD(ByVal pDS As DicomDataSet) As DicomIod
         If pDS IsNot Nothing Then
            Dim pElement As DicomElement
            pElement = pDS.FindFirstElement(Nothing, DicomTag.SOPClassUID, False)
            If pElement IsNot Nothing Then
               Dim pszText As String = Nothing
               Dim nClass As Integer = -1

               pszText = pDS.GetConvertValue(pElement)
               If pszText IsNot Nothing Then
                  nClass = GetClassFromUID(pszText)
                  If nClass <> -1 Then
                     Return GetIODFromMyList(nClass)

                  End If
               End If
            End If
         End If
         Return Nothing
      End Function

      Private Function GetIODFromMyList(ByVal nClass As Integer) As DicomIod
         If nClass = -1 Then
            Return Nothing
         End If
         Return (DicomIodTable.Instance.FindClass(CType(nClass, DicomClassType)))
      End Function

      Private Function GetClassFromUID(ByVal pszUID As String) As Integer
         For i As Integer = 0 To CreateNewDICOMFile.m_DICOMUIDIOD.Length - 1
            If CreateNewDICOMFile.m_DICOMUIDIOD(i).pszUID = pszUID Then
               Return CInt(CreateNewDICOMFile.m_DICOMUIDIOD(i).nClass)
            End If
         Next
         Return -1
      End Function

      Private Sub CleanDSAndSetDefaultValues(ByVal uClass As DicomClassType, ByVal pDicomDataSet As DicomDataSet, ByVal bInsertMissingElements As Boolean)
         CleanDataSet(uClass, pDicomDataSet)
         ' Set some default values 
         SetDSDefaultValues(pDicomDataSet, bInsertMissingElements)
      End Sub

      Private Sub CreateTargetFormats()

         Dim formats As TargetFormats = Nothing
         Dim format As TargetFormat = Nothing

         formats = CaptureCtrl1.TargetFormats
         format = formats.DICOM

         format.UseFilterCache = True
         ''' get the DICOM filter for private use
         m_pDICOMFilter = format.GetCacheObject(TargetFormatObject.Mux)

         format = formats.MPEG2DICOM
         format.UseFilterCache = True
      End Sub

      ' Set some default values from a predefined table(m_DefaultElementValues)
      Private Sub SetDSDefaultValues(ByRef pDicomDataSet As DicomDataSet, ByVal bInsertMissingElements As Boolean)

         Dim i As Integer
         Dim pTag As DicomTag
         Dim nVR As DicomVRType
         Dim pElement As DicomElement
         Dim Time As DateTime
         Dim szValue As String


         Time = DateTime.Now
         ' Loop through all the elements in the default value table
         For i = 0 To Helper.DefaultElementValues.Length - 1

            pTag = DicomTagTable.Instance.Find(Helper.DefaultElementValues(i).nTag)
            nVR = (If((pTag IsNot Nothing), pTag.VR, DicomVRType.UN))
            pElement = Nothing
            pElement = pDicomDataSet.FindFirstElement(Nothing, Helper.DefaultElementValues(i).nTag, False)
            If pElement Is Nothing Then
               ' If the element is missing and the user of 
               ' this functions wants to add it , then add it 
               If bInsertMissingElements Then
                  pElement = pDicomDataSet.InsertElement(Nothing, False, Helper.DefaultElementValues(i).nTag, nVR, False, -1)
               End If
            End If
            If Helper.DefaultElementValues(i).nTag = DicomTag.DateOfSecondaryCapture Then
               szValue = String.Format("{0:D2}/{1:D2}/{2:D4}", Time.Month, Time.Day, Time.Year)
               If pElement IsNot Nothing Then
                  pDicomDataSet.FreeElementValue(pElement)
                  pDicomDataSet.SetConvertValue(pElement, szValue, 1)
               End If
            ElseIf Helper.DefaultElementValues(i).nTag = DicomTag.TimeOfSecondaryCapture Then
               szValue = String.Format("{0:D2}:{1:D2}:{2:D4}.0", Time.Hour, Time.Minute, Time.Second)
               If pElement IsNot Nothing Then
                  pDicomDataSet.FreeElementValue(pElement)
                  pDicomDataSet.SetConvertValue(pElement, szValue, 1)
               End If
            Else
               If (pElement IsNot Nothing) AndAlso CanUpdateElementValue(pDicomDataSet, pElement) Then
                  ' Set the value for this element
                  pDicomDataSet.FreeElementValue(pElement)
                  pDicomDataSet.SetConvertValue(pElement, Helper.DefaultElementValues(i).pszValue, 1)
               End If
            End If
         Next
         ' Set different UIDs for this dataset 
         SetInstanceUIDs(pDicomDataSet)
         'Set instance numbers
         SetInstanceNumbers(pDicomDataSet, System.Math.Max(System.Threading.Interlocked.Increment(m_nInstanceNumber), m_nInstanceNumber - 1))
         ' Update study date and time
         SetStudyDateAndTime(pDicomDataSet)
         ' Set meta header info
         InsertMetaHeader(pDicomDataSet)
      End Sub

      Private Function CanUpdateElementValue(ByVal pDicomDataSet As DicomDataSet, ByVal pElement As DicomElement) As Boolean
         If (pElement IsNot Nothing) AndAlso (pDicomDataSet.GetConvertValue(pElement) IsNot Nothing) Then
            Select Case pElement.Tag
               Case DicomTag.MediaStorageSOPClassUID, DicomTag.SOPClassUID, DicomTag.Modality
                  Return False
            End Select
         End If
         Return True
      End Function

      Private Sub InsertMetaHeader(ByVal pDS As DicomDataSet)
         Dim pElement As DicomElement

         ' Add File Meta Information Version
         pElement = pDS.FindFirstElement(Nothing, DicomTag.FileMetaInformationVersion, False)
         If pElement Is Nothing Then
            pElement = pDS.InsertElement(Nothing, False, DicomTag.FileMetaInformationVersion, DicomVRType.OB, False, 0)
         End If
         If pElement IsNot Nothing Then
            Dim cValue As Byte() = {&H0, &H1}
            pDS.SetByteValue(pElement, cValue, 2)
         End If
         ' Implementation Class UID
         pElement = pDS.FindFirstElement(Nothing, DicomTag.ImplementationClassUID, False)
         If pElement Is Nothing Then
            pElement = pDS.InsertElement(Nothing, False, DicomTag.ImplementationClassUID, DicomVRType.UI, False, 0)
         End If
         If pElement IsNot Nothing Then
            pDS.SetConvertValue(pElement, Helper.LEAD_IMPLEMENTATION_CLASS_UID, 1)
         End If

         ' Implementation Version Name
         pElement = pDS.FindFirstElement(Nothing, DicomTag.ImplementationVersionName, False)
         If pElement Is Nothing Then
            pElement = pDS.InsertElement(Nothing, False, DicomTag.ImplementationVersionName, DicomVRType.SH, False, 0)
         End If
         If pElement IsNot Nothing Then
            pDS.SetConvertValue(pElement, Helper.LEAD_IMPLEMENTATION_VERSION_NAME, 1)
         End If
      End Sub

      Private Sub CleanDataSet(ByVal uClass As DicomClassType, ByVal pDicomDataSet As DicomDataSet)
         DeleteEmptyElementsType3(uClass, pDicomDataSet)
         DeleteEmptyModulesOptional(uClass, pDicomDataSet)
      End Sub

      Private Sub DeleteEmptyModulesOptional(ByVal uClass As DicomClassType, ByVal pDicomDataSet As DicomDataSet)
         Dim nCountModule As Integer = DicomIodTable.Instance.GetModuleCount(uClass)
         Dim pIOD As DicomIod

         For i As Integer = 0 To nCountModule - 1
            pIOD = DicomIodTable.Instance.FindModuleByIndex(uClass, i)
            If (pIOD IsNot Nothing) AndAlso (pIOD.Usage = DicomIodUsageType.OptionalModule) Then
               Dim pModule As DicomModule = pDicomDataSet.FindModule(pIOD.ModuleCode)
               If (pModule IsNot Nothing) AndAlso IsEmptyModule(pModule, pDicomDataSet) Then
                  pDicomDataSet.DeleteModule(pIOD.ModuleCode)
               End If
            End If
         Next
      End Sub

      Private Function IsEmptyModule(ByVal pModule As DicomModule, ByVal pDicomDataSet As DicomDataSet) As Boolean
         If pModule Is Nothing Then
            Return True
         End If

         Dim bEmpty As Boolean = True
         For i As UInt32 = 0 To CUInt(pModule.Elements.Length - 1)
            If pModule.Elements(CInt(i)).Length = &HFFFFFFFFUI Then
               bEmpty = bEmpty AndAlso IsEmptySequence(pModule.Elements(CInt(i)), pDicomDataSet)

            ElseIf pModule.Elements(CInt(i)).Length <> 0 Then
               bEmpty = False
            End If
         Next
         Return bEmpty
      End Function

      ' Delete any optional element which has no value
      Private Sub DeleteEmptyElementsType3(ByVal uClass As DicomClassType, ByVal pDicomDataSet As DicomDataSet)
         Dim pElementPrev As DicomElement = Nothing
         Dim pElement As DicomElement
         Dim pIODClass As DicomIod = DicomIodTable.Instance.FindClass(uClass)
         If pIODClass IsNot Nothing Then
            Dim pIOD As DicomIod

            pElement = pDicomDataSet.GetFirstElement(Nothing, False, True)
            pElementPrev = Nothing
            While pElement IsNot Nothing
               pIOD = DicomIodTable.Instance.Find(pIODClass, pElement.Tag, DicomIodType.Element, False)

               If (pIOD IsNot Nothing) AndAlso (pIOD.Usage = DicomIodUsageType.OptionalElement) Then
                  ' nLength==0 means (1) Sequence     or (2)Empty Element 

                  ' Case 1: Sequence
                  If pElement.Length = &HFFFFFFFFUI Then
                     Dim bEmptySequence As Boolean = IsEmptySequence(pElement, pDicomDataSet)
                     If bEmptySequence Then
                        'if deleting the first element, pElementPrev is NULL
                        'Therefore we must call GetFirstElement
                        pDicomDataSet.DeleteElement(pElement)
                        pElement = pElementPrev
                        If pElement Is Nothing Then
                           pElement = pDicomDataSet.GetFirstElement(Nothing, False, True)
                        End If
                     End If

                     ' Case 2: Empty Element
                  ElseIf pElement.Length = 0 Then
                     'if deleting the first element, pElementPrev is NULL
                     'Therefore we must call GetFirstElement
                     pDicomDataSet.DeleteElement(pElement)
                     pElement = pElementPrev
                     If pElement Is Nothing Then
                        pElement = pDicomDataSet.GetFirstElement(Nothing, False, True)
                     End If
                  End If
               End If

               pElementPrev = pElement
               pElement = pDicomDataSet.GetNextElement(pElement, False, True)
            End While
         End If

      End Sub

      Private Function IsEmptySequence(ByVal pElementSequence As DicomElement, ByVal pDicomDataSet As DicomDataSet) As Boolean
         Dim pElementItem As DicomElement
         Dim pElement As DicomElement
         Dim bEmpty As Boolean


         bEmpty = True
         pElementItem = pDicomDataSet.GetChildElement(pElementSequence, True)
         While pElementItem IsNot Nothing
            pElement = pDicomDataSet.GetChildElement(pElementItem, True)
            While pElement IsNot Nothing
               ' If a sequence, make a recursive call
               If pElement.Length = &HFFFFFFFFUI Then
                  bEmpty = bEmpty AndAlso IsEmptySequence(pElement, pDicomDataSet)

               ElseIf pElement.Length <> 0 Then
                  bEmpty = False
               End If
               pElement = pDicomDataSet.GetNextElement(pElement, True, True)
            End While
            pElementItem = pDicomDataSet.GetNextElement(pElementItem, True, True)
         End While
         Return bEmpty
      End Function

      Private Function CheckDirtyFlag() As DialogResult
         If IsModified() Then
            Return MessageBox.Show("Do you want to save the changes you made to this Data Set?", "", MessageBoxButtons.YesNoCancel)
         End If

         Return DialogResult.No
      End Function

      Private Function IsModified() As Boolean
            Return _modified
        End Function

      Private Sub Reset()
         m_DS.Reset()
         m_pDICOMIOD = Nothing
         m_bDataSetInitialized = False

         SetModifiedFlag(False)
      End Sub

      ' Save DICOM file
      Private Sub OnFileSaveAs()
         Dim dlg As New SaveFileDialog()
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|All files (*.*)|*.*||"

         ' Get file name
         If dlg.ShowDialog() = DialogResult.OK Then
            Dim Wait As New WaitCursor()
            'Save dataset into file

            Try
               Dim strOutputFileName As String = GetOutputFileName()
               If strOutputFileName.Length > 0 Then
                  Dim VideoStreamIntoDataset As New DicomDataSet()

                  VideoStreamIntoDataset.Load(strOutputFileName, DicomDataSetLoadFlags.LoadAndClose)
                  m_DS.Copy(VideoStreamIntoDataset, Nothing, Nothing)
                  m_DS.Save(dlg.FileName, DicomDataSetSaveFlags.GroupLengths Or DicomDataSetSaveFlags.MetaHeaderAbsent)
               End If
            Catch ex As Exception
               MessageBox.Show(ex.Message)
            End Try

            SetModifiedFlag(False)
         End If
      End Sub

      Private Sub SetModifiedFlag(ByVal bSet As Boolean)
         _modified = bSet
      End Sub

      Private Function CreateDICOMFileFromTemplate(ByVal uClass As DicomClassType) As Boolean
         Dim fileData As Byte() = Nothing

         Select Case uClass

            Case DicomClassType.VideoEndoscopicImageStorage
               fileData = My.Resources.Video_endoscopy
               Exit Select
            Case DicomClassType.VideoMicroscopicImageStorage
               fileData = My.Resources.Video_microscopy
               Exit Select
            Case DicomClassType.VideoPhotographicImageStorage
               fileData = My.Resources.Video_Photography
               Exit Select
            Case DicomClassType.SCMultiFrameTrueColorImageStorage
               fileData = My.Resources.Multi_frame_SC
               Exit Select
            Case Else
               Return False
         End Select

         Dim szTempPath As String = Path.GetTempPath()
         Dim pszFullName As String = Path.Combine(szTempPath, "TemplatePS.dcm")
         If pszFullName Is Nothing Then

            Return False
         End If

         Dim fileStream As Stream = File.Create(pszFullName)
         If fileStream Is Nothing Then

            Return False
         End If

         fileStream.Write(fileData, 0, fileData.Length)
         fileStream.Flush()
         fileStream.Close()

         ' Loading the DS
         m_DS.Load(pszFullName, DicomDataSetLoadFlags.LoadAndClose)

         File.Delete(pszFullName)
         Return True
      End Function

      Private Sub SetInstanceUIDs(ByVal pDicomDataSet As DicomDataSet)
         Dim pElement As DicomElement
         Dim pszInstanceGuid As String


         ' Set STUDY INSTANCE UID
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.StudyInstanceUID, False)
         If pElement Is Nothing Then
            pElement = pDicomDataSet.InsertElement(Nothing, False, DicomTag.StudyInstanceUID, DicomVRType.UI, False, 0)
         End If
         pszInstanceGuid = WinAPI.GenerateDicomUniqueIdentifier()
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1)

         ' Set SERIES INSTANCE UID
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.SeriesInstanceUID, False)
         If pElement Is Nothing Then
            pElement = pDicomDataSet.InsertElement(Nothing, False, DicomTag.SeriesInstanceUID, DicomVRType.UI, False, 0)
         End If
         pDicomDataSet.FreeElementValue(pElement)
         pszInstanceGuid = WinAPI.GenerateDicomUniqueIdentifier()
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1)

         ' Set SOP INSTANCE UID
         pszInstanceGuid = WinAPI.GenerateDicomUniqueIdentifier()
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.SOPInstanceUID, False)
         If pElement Is Nothing Then
            pElement = pDicomDataSet.InsertElement(Nothing, False, DicomTag.SOPInstanceUID, DicomVRType.UI, False, 0)
         End If
         pDicomDataSet.FreeElementValue(pElement)
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1)

         ' Media Storage SOP Instance UID
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.MediaStorageSOPInstanceUID, False)
         If pElement Is Nothing Then
            pElement = pDicomDataSet.InsertElement(Nothing, False, DicomTag.MediaStorageSOPInstanceUID, DicomVRType.UI, False, 0)
         End If
         pDicomDataSet.FreeElementValue(pElement)
         pDicomDataSet.SetConvertValue(pElement, pszInstanceGuid, 1)
      End Sub

      Private Sub SetInstanceNumbers(ByVal pDicomDataSet As DicomDataSet, ByVal nInstanceNumber As Integer)
         Dim pElement As DicomElement
         Dim szValue As String

         szValue = nInstanceNumber.ToString()

         ' Series number
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.SeriesNumber, False)
         If pElement IsNot Nothing Then
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If

         ' Instance number
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.InstanceNumber, False)
         If pElement IsNot Nothing Then
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If
         ' Study ID
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.StudyID, False)
         If pElement IsNot Nothing Then
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If

         szValue = "854125" & nInstanceNumber.ToString()
         ' Accession number
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.AccessionNumber, False)
         If pElement IsNot Nothing Then
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If
      End Sub

      Private Sub SetStudyDateAndTime(ByVal pDicomDataSet As DicomDataSet)
         Dim Time As DateTime
         Dim szValue As String = Nothing
         Dim pElement As DicomElement

         Time = DateTime.Now

         ' Set study date
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.StudyDate, False)
         If pElement IsNot Nothing Then
            szValue = String.Format("%02d/%02d/%04d", Time.Month, Time.Day, Time.Year)
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If
         ' Set content date
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.ContentDate, False)
         If pElement IsNot Nothing Then
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If
         ' Set study time
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.StudyTime, False)
         If pElement IsNot Nothing Then
            szValue = String.Format("%02d:%02d:%04d.0", Time.Hour, Time.Minute, Time.Second)
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If
         ' Set content time
         pElement = pDicomDataSet.FindFirstElement(Nothing, DicomTag.ContentTime, False)
         If pElement IsNot Nothing Then
            pDicomDataSet.FreeElementValue(pElement)
            pDicomDataSet.SetConvertValue(pElement, szValue, 1)
         End If

      End Sub

      'Get value for a certain element
      Private Sub GetElementValue(ByVal pElement As DicomElement, ByRef strValue As String)
         Dim nCount As Integer = 0
         Dim pszValue As String
         Dim i As Integer

         Dim pDS As DicomDataSet = m_DS

         If (pElement Is Nothing) OrElse (pDS.ExistsElement(pElement) = False) Then
            Return
         End If
         If pElement.Tag = DicomTag.PixelData Then
            strValue = ""
            Return
         End If

         nCount = pDS.GetElementValueCount(pElement)
         pDS.FreeElementValue(pElement)
         If nCount = 0 Then
            Return
         End If
         strValue = ""

         If pDS.GetConvertValue(pElement) Is Nothing Then
            ' Is this a date?
            If pElement.VR = DicomVRType.DA Then
               Dim pDate As DicomDateValue()
               For i = 0 To nCount - 1
                  pDate = pDS.GetDateValue(pElement, i, 1)
                  If pDate IsNot Nothing Then
                     strValue = String.Format("{0:D}/{1:D}/{2:D}", pDate(0).Day, pDate(0).Month, pDate(0).Year)
                  End If
               Next
            End If
            Return
         End If

         'Get the value of this element
         pszValue = pDS.GetConvertValue(pElement)
         Dim pTemp1 As String
         i = 0
         pTemp1 = pszValue
         While i < nCount
            If nCount > 1 Then
               If pszValue.Contains("\") Then
                  pszValue = pszValue.Remove(pszValue.IndexOf("\"c))
               End If
            End If
            i += 1
         End While
         strValue = pszValue
         strValue = pszValue
      End Sub

      Private Function IsCapturing() As Boolean
         If CaptureCtrl1 IsNot Nothing Then
            Return (If((CaptureCtrl1.State = CaptureState.Running), True, False))
         End If
         Return False
      End Function

      Private Function CanInsertCompressedImage() As Boolean
         Dim pElement As DicomElement = Nothing

         pElement = m_DS.FindFirstElement(Nothing, DicomTag.TransferSyntaxUID, False)
         If pElement IsNot Nothing Then
            Dim pszText As String = Nothing
            pszText = m_DS.GetConvertValue(pElement)
            If pszText = DicomUidType.ImplicitVRLittleEndian OrElse pszText = DicomUidType.ExplicitVRBigEndian Then
               Return False
            Else
               Return True

            End If
         End If
         Return True
      End Function

      Private Function ChangeDSToAcceptCompressed() As Boolean
         Dim szPath As String
         Dim szFileName As String
         Dim pPixelDataElement As DicomElement = Nothing

         'If the dataset can already accept compressed images then don't do anything
         If True = CanInsertCompressedImage() Then
            Return True
         End If
         ' Get a temp file name
         szPath = Path.GetTempPath()
         szFileName = Path.Combine(szPath, Path.GetTempFileName())

         ' Delete the pixel data element
         pPixelDataElement = m_DS.FindFirstElement(Nothing, DicomTag.PixelData, False)
         If pPixelDataElement IsNot Nothing Then
            m_DS.DeleteElement(pPixelDataElement)
            pPixelDataElement = Nothing
         End If
         ' Save the dataset into a temp file and pass 
         ' proper flags to make it Explicit Little Endian
         m_DS.Save(szFileName, DicomDataSetSaveFlags.ExplicitVR Or DicomDataSetSaveFlags.LittleEndian Or DicomDataSetSaveFlags.MetaHeaderPresent Or DicomDataSetSaveFlags.GroupLengths)

         ' Reset the data set and then load the temp file we saved
         m_DS.Reset()
         m_DS.Load(szFileName, DicomDataSetLoadFlags.LoadAndClose)

         ' Clean Up!
         File.Delete(szFileName)
         Return True
      End Function

      Private Function GetOutputFileName() As String
         Dim szFileName As String = Path.GetTempPath()
         If szFileName Is Nothing OrElse szFileName.Length = 0 Then
            MessageBox.Show("Cannot get <TEMP> folder.")
            Return ""
         End If

         szFileName += "DicomVidOutput.dcm"

         Return szFileName
      End Function

      Private Function SetTargetFormat(ByVal TargetFormat As DICOM_WRITER_FILTER_TARGET_FORMAT) As Boolean
         CaptureCtrl1.EnterEdit()
         Dim bRet As Boolean = False

         Select Case TargetFormat
            Case DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_CUSTOM
               CaptureCtrl1.TargetFormat = TargetFormatType.DICOM
               ' clear any compressor (might have been set when we selected MPEG-2 DICOM)
               SelectMPEG2Compressor(False)
               Exit Select
            Case DICOM_WRITER_FILTER_TARGET_FORMAT.DICOM_WRITER_FILTER_TARGET_FORMAT_MPEG2
               CaptureCtrl1.TargetFormat = TargetFormatType.DICOM
               ' select a MPEG-2 compressor
               SelectMPEG2Compressor(True)
               Exit Select
            Case Else
               bRet = False
               Exit Select
         End Select
         CaptureCtrl1.LeaveEdit()
         Return bRet
      End Function


      Private Sub SelectMPEG2Compressor(ByVal bSelect As Boolean)
         Dim videoCompressors As VideoCompressors = Nothing
         Dim audioCompressors As AudioCompressors = Nothing

         videoCompressors = CaptureCtrl1.VideoCompressors
         If videoCompressors Is Nothing AndAlso bSelect Then
            MessageBox.Show("Can't find any Video compressors!")
            Return
         End If

         audioCompressors = CaptureCtrl1.AudioCompressors
         If (audioCompressors Is Nothing) AndAlso bSelect Then
            MessageBox.Show("Can't find any Audio compressors, You won't be able to capture Audio!")
            audioCompressors = Nothing
         End If

         If Not bSelect Then
            If videoCompressors IsNot Nothing Then
               videoCompressors.Selection = -1
            End If
            If audioCompressors IsNot Nothing Then
               audioCompressors.Selection = -1
            End If
         Else
            Dim lIndex As Integer
            ' look for the LEAD MPEG-2 Encoder 
            lIndex = videoCompressors.IndexOf(Helper.LEAD_MPEG2_VIDEO_ENCODER)
            If lIndex = -1 Then
               MessageBox.Show("Cannot find the MPEG-2 encoder. You will not be able to capture MPEG-2 DICOM files!")
            Else
               videoCompressors.Selection = lIndex
               ' set the compatibility mode to DICOM
               Dim pUnk As Object
               ' get a pointer to the MPEG-2 object
               pUnk = CaptureCtrl1.GetSubObject(CaptureObject.VideoCompressor)
               Dim pMPEG2Encoder As ILMMPG2Encoder
               pMPEG2Encoder = TryCast(pUnk, ILMMPG2Encoder)
               pMPEG2Encoder.DefaultMpegMode = eMPEG2DEFAULTMODE.MPEG2MODE_DICOM
               pMPEG2Encoder.RateControlMethod = eRATECONTROL.MPEG2_CONSTANT_QUALITY
               pMPEG2Encoder.QuantizerValue = 8
            End If

            lIndex = -1
            If audioCompressors IsNot Nothing Then
               lIndex = audioCompressors.IndexOf(Helper.LEAD_MPEG_AUDIO_ENCODER)
               If lIndex = -1 Then
                  MessageBox.Show("Cannot find the LEAD MPEG Audio Encoder. You will not be able to capture Audio.")
               Else
                  audioCompressors.Selection = lIndex
               End If
            End If
         End If
      End Sub

      Private Function GetTemplateFileName(ByVal bCreate As Boolean) As String
         Dim szFileName As String = Path.GetTempPath()
         If szFileName Is Nothing Then
            MessageBox.Show("Cannot get <TEMP> folder.")
            Return ""
         End If

         szFileName = Path.Combine(szFileName, "Template.dcm")

         Dim strTemplateFileName As String = szFileName

         If bCreate Then
            Dim Ds As New DicomDataSet()
            Ds.Initialize(DicomClassType.Unknown, DicomDataSetInitializeFlags.None)
            Ds.Save(strTemplateFileName, DicomDataSetSaveFlags.None)
         End If

         Return strTemplateFileName
      End Function

      Private Sub StartToolbarPlay()
         If False = m_bNowPlaying Then
            If _timer Is Nothing Then
               _timer = New Timer()
               AddHandler _timer.Tick, New EventHandler(AddressOf timer_Tick)
               _timer.Interval = 100

               _tS_ProgressBar.Minimum = 0
               _tS_ProgressBar.Maximum = 100
               _tS_ProgressBar.[Step] = 10
            End If

            _tS_ProgressBar.Value = 0
            _timer.Start()
            m_bNowPlaying = True
         End If

         UpdateMenuStatus()
      End Sub

      Private Sub StopToolbarPlay()
         If m_bNowPlaying Then
            _timer.[Stop]()
            _tS_ProgressBar.Value = 0
            m_bNowPlaying = False
         End If

         UpdateMenuStatus()
      End Sub

      Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
         If _tS_ProgressBar.Value < _tS_ProgressBar.Maximum Then
            _tS_ProgressBar.PerformStep()
         Else
            _tS_ProgressBar.Value = 0
         End If
      End Sub
#End Region

      Private Sub _mi_Exit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mi_Exit.Click
         Me.Close()
      End Sub
      Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
         target = value
         Return value
      End Function
   End Class
End Namespace
