' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.IO
Imports Leadtools
Imports Leadtools.Printer
Imports Leadtools.Document.Writer
Imports Leadtools.Codecs
Imports Leadtools.Dicom
Imports System.Net
Imports System.Threading
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom.Common.Editing
Imports PrintToPACS.Utilities
Imports Leadtools.Dicom.Scu.Common
Imports PrinterDemo
Imports Leadtools.Dicom.Scu
Imports System.Diagnostics
Imports PrintToPACSDemo.Queries
Imports Leadtools.Dicom.Common.DataTypes.Modality
Imports Leadtools.Dicom.Scu.Queries
Imports Leadtools.DicomDemos
Imports System.Collections.Generic
Imports System.Collections
Imports System.Management
Imports Leadtools.WinForms.CommonDialogs.File
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Leadtools.Dicom.Common.Editing.Converters
Imports Leadtools.ImageProcessing
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing.Effects

Namespace PrintToPACSDemo
   Partial Public Class FrmMain : Inherits Form

#Region "Main..."
   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>

   Private Const sHelpInstructions As String = "Command Line Options:" & _sNewlineTab & "/? or /help" & Constants.vbTab + Constants.vbTab & "Displays this help" & _sNewlineTab & "/configure" & Constants.vbTab + Constants.vbTab & "Configures the client (use one or more options below)" & _sNewlineTab & "/server_aetitle={aetitle}" & Constants.vbTab & "Server AE title" & _sNewlineTab & "/server_ip={ip address}" & Constants.vbTab & "Server IP" & _sNewlineTab & "/server_port={port}" & Constants.vbTab & "Server Port" & _sNewlineTab & "/client_aetitle={aetitle}" & Constants.vbTab & "Client AE title" & _sNewlineTab & "/client_port={port}" & Constants.vbTab + Constants.vbTab & "Client Port" & _sNewlineTab & "/defaults" & Constants.vbTab + Constants.vbTab + Constants.vbTab & "Sets defaults for other options"

   Private Shared Function ParseOneServer(ByVal serverString As String) As MyServer
   '   /servers=ae1,ip1,port1,timeout1,secure1

   Dim server As MyServer = Nothing
   Dim fields As String() = serverString.Split(","c)
   If fields.Length = 5 Then
   server = New MyServer()
   server._sAE = fields(0).Trim()
   server._sIP = fields(1).Trim()
   server._port = Convert.ToInt32(fields(2).Trim())
   server._timeout = Convert.ToInt32(fields(3).Trim())
   server._useTls = Convert.ToBoolean(fields(4).Trim())
   End If
   Return server
   End Function

   Private Shared Function ParseServerList(ByVal serversString As String) As MyServer()
   '   /servers=ae1,ip1,port1,timeout1,secure1;ae1,ip1,port1,timeout1,secure1
   serversString.Trim()
   If serversString.EndsWith(";") Then
   serversString = serversString.Substring(0, serversString.Length - 1)
   End If
   Dim servers As String() = serversString.Split(";"c)

   Dim listParam As ArrayList = New ArrayList()
   For Each s As String In servers
   Dim server As MyServer = ParseOneServer(s)
   listParam.Add(server)
   Next s

   Dim items As MyServer() = New MyServer(servers.Length - 1) {}
   listParam.CopyTo(items)
   Return items
   End Function

   Private Shared Function GetDefaultIp() As String
   Dim query As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'")
   Dim queryCollection As ManagementObjectCollection = query.Get()

   For Each mo As ManagementObject In queryCollection
   If queryCollection.Count > 0 Then
      Dim addresses As String() = CType(mo("IPAddress"), String())

      For Each ip As String In addresses
      If (Not ip.Contains(":")) AndAlso (ip <> "0.0.0.0") Then
      Return ip
      End If
      Next ip
   End If
   Next mo
   Return String.Empty
   End Function

   Private Shared Function ReadCommandLine(ByVal args As String()) As Boolean
   Return False
   'const string sHelp = "/help";
   'const string sQuestion = "/?";
   'const string sConfigure = "/configure";
   'const string sServerAeTitle = "/server_aetitle=";
   'const string sServerPort = "/server_port=";
   'const string sServerIp = "/server_ip=";
   'const string sClientAeTitle = "/client_aetitle=";
   'const string sClientPort = "/client_port=";
   'const string sDefaults = "/defaults";
   'const string sServers = "/servers=";
   'bool bConfigure = false;
   'MySettings mySettings = new MySettings();
   'mySettings.Load();

   'foreach (string s in args)
   '{
   '   string sVal = string.Empty;

   '   if ((string.Compare(sHelp, s, true) == 0) || (string.Compare(sQuestion, s, true) == 0))
   '   {
   '      MessageBox.Show(sHelpInstructions, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
   '      return true;
   '   }
   '   else if (s.StartsWith(sConfigure))
   '   {
   '      bConfigure = true;
   '   }
   '   else if (s.StartsWith(sServers))
   '   {
   '      //   /servers=ae1,ip1,port1,timeout1,secure1;ae2,ip2,port2,timeout2,secure2
   '      string sTemp = s.Substring(sServers.Length);
   '      MyServer[] serverList = ParseServerList(sTemp);
   '      mySettings._settings.queryMWLServers.serverList = serverList;
   '      mySettings._settings.querySCPServers.serverList = serverList;
   '      mySettings._settings.storeServers.serverList = serverList;
   '   }
   '   else if (s.StartsWith(sDefaults))
   '   {
   '      //mySettings._settings.serverList = new MyServer(AE, IPAddress, port, 20, false);
   '      mySettings._settings.clientCertificate = Application.StartupPath + "\\client.pem";
   '      mySettings._settings.privateKey = Application.StartupPath + "\\client.pem";
   '      mySettings._settings.privateKeyPassword = "test";
   '      mySettings._settings.logLowLevel = true;
   '      mySettings._settings.showHelpOnStart = true;

   '      string sDefaultIP = string.Empty;
   '      try
   '      {
   '         sDefaultIP = GetDefaultIp();
   '      }
   '      catch (Exception)
   '      {
   '      }

   '      //mySettings._settings.serverIP = sDefaultIP;
   '   }
   '   else if (s.StartsWith(sServerAeTitle, true, null))
   '   {
   '      sVal = s.Substring(sServerAeTitle.Length);
   '      mySettings._settings.queryMWLServers.serverList[0]._sAE = sVal;
   '      mySettings._settings.querySCPServers.serverList[0]._sAE = sVal;
   '      mySettings._settings.storeServers.serverList[0]._sAE = sVal;
   '   }
   '   else if (s.StartsWith(sServerPort, true, null))
   '   {
   '      sVal = s.Substring(sServerPort.Length);
   '      mySettings._settings.queryMWLServers.serverList[0]._port = 104;
   '      mySettings._settings.querySCPServers.serverList[0]._port = 104;
   '      mySettings._settings.storeServers.serverList[0]._port = 104;
   '      try
   '      {
   '         mySettings._settings.queryMWLServers.serverList[0]._port = Convert.ToInt32(sVal);
   '         mySettings._settings.querySCPServers.serverList[0]._port = Convert.ToInt32(sVal);
   '         mySettings._settings.storeServers.serverList[0]._port = Convert.ToInt32(sVal);
   '      }
   '      catch (Exception)
   '      {
   '      }
   '   }
   '   else if (s.StartsWith(sServerIp, true, null))
   '   {
   '      sVal = s.Substring(sServerIp.Length);
   '      mySettings._settings.queryMWLServers.serverList[0]._sIP = sVal;
   '      mySettings._settings.querySCPServers.serverList[0]._sIP = sVal;
   '      mySettings._settings.storeServers.serverList[0]._sIP = sVal;
   '   }

   '   else if (s.StartsWith(sClientAeTitle, true, null))
   '   {
   '      sVal = s.Substring(sClientAeTitle.Length);
   '      mySettings._settings.clientAE = sVal;
   '   }
   '   else if (s.StartsWith(sClientPort, true, null))
   '   {
   '      sVal = s.Substring(sClientPort.Length);
   '      mySettings._settings.clientPort = 1000;
   '      try
   '      {
   '         mySettings._settings.clientPort = Convert.ToInt32(sVal);
   '      }
   '      catch (Exception)
   '      {
   '      }
   '   }

   '   if (bConfigure)
   '   {
   '      mySettings.SavePreconfigure();
   '   }
   '}
   'return bConfigure;
   End Function
   <STAThread()> _
   Shared Sub Main(ByVal args As String())
         Try
            Dim bConfigure As Boolean = ReadCommandLine(args)
            If bConfigure Then
               Return
            End If
         Catch
         End Try

         If Not Support.SetLicense() Then
            Return
         End If

         If args.Length > 0 Then
            FrmMain.StartedPrinter = args(0)
            Dim mySettings As MySettings = New MySettings()
            mySettings.Load()
            If FrmMain.StartedPrinter <> mySettings._settings.printerName Then
               Return
            End If
         End If

         Utils.EngineStartup()
         Utils.DicomNetStartup()
         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New FrmMain())
   End Sub
#End Region

#Region "Constructor..."
   Public Sub New()
   Try
   InitClass()
   InitializeComponent()

   If StartedPrinter <> "" Then
      _printer = New Printer(StartedPrinter)
      AddHandler _printer.JobEvent, AddressOf _printer_JobEvent
      AddHandler _printer.EmfEvent, AddressOf _printer_EmfEvent
   End If
   LoadSettings()
   _mySettings.CopyGlobalSettings()
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   Close()
   End Try
   End Sub
#End Region

#Region "Fields..."

   Public Delegate Sub AddLog(ByVal action As String, ByVal logText As String)
   Public Delegate Sub AddLogColor(ByVal action As String, ByVal logText As String, ByVal sActionColor As Color)
   Public Delegate Sub EnableMenu(ByVal enable As Boolean, ByVal strCaption As String, ByVal strBtnCaption As String)

   Private Const _sNewline As String = Constants.vbCrLf
   Private Const _sNewlineTab As String = Constants.vbCrLf & Constants.vbTab
   Private Const _sNewlineTabTab As String = Constants.vbCrLf & Constants.vbTab + Constants.vbTab
   Private _frmProgress As FrmProgress
   Private _frmOperation As FrmOperation
   Private imgCollection As ListImageBox.ImageCollection = Nothing
   Private _pageNo As Integer = 0
   Private _jobId As Integer = 0
   Private Shared StartedPrinter As String = String.Empty
   Private bFinishedPrinting As Boolean = False
   Private iOldY As Integer = -1, iOldX As Integer = -1, _iOldIndex As Integer = -1
   Private _codec As RasterCodecs

   Private _printer As Printer

   Private bCancelOperation As Boolean = False


   Public Const _sConfigurationImplementationClass As String = "1.2.840.114257.1123456"
   Public Const _sConfigurationImplementationVersionName As String = "1"
   Public Const _sConfigurationProtocolversion As String = "1"

   Private _tracer As TextBoxTraceListener = Nothing

   Private _findQuery As DicomFindQuery = New DicomFindQuery()
   Private _pbQuery As PatientBasedQuery = New PatientBasedQuery()
   Private _bbQuery As BroadBasedQuery = New BroadBasedQuery()

   Private _find As MyQueryRetrieveScu
   Private _cstore As StoreScu
   Private bStored As Boolean = False
   Public _mySettings As MySettings = New MySettings()
   Private OldRowSelection As List(Of DataGridViewRow) = New List(Of DataGridViewRow)()
   Private OldCellSelection As List(Of DataGridViewCell) = New List(Of DataGridViewCell)()
   Private logWindow As LogWindow
   Private _lstSelected As ListView
   Private DICOMPatientInfo As List(Of Long)
   Private DICOMStudyInfo As List(Of Long)
   Private ClassTypes As List(Of DicomClassType)

   Private Const ELEMENT_LENGTH_MAX As Long = CLng(&HFFFFFFFFL)
   Private _ExcludedTags As List(Of Long) = New List(Of Long)()

   Private strLastLocation As String = ""
#End Region

#Region "Forms Events..."

   'TEMP
   Private _pgDicomInfo As Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid
   Private DicomEditableObject As Leadtools.Dicom.Common.Editing.DicomEditableObject
   Private _pictureBox As Leadtools.WinForms.RasterImageViewer = New Leadtools.WinForms.RasterImageViewer()

   Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
   '
   ' Add Excluded Tags
   '
DICOMPatientInfo = New List(Of Long)
DICOMStudyInfo = New List(Of Long)
ClassTypes = New List(Of DicomClassType)

DICOMPatientInfo.Add(DicomTag.PatientName)
DICOMPatientInfo.Add(DicomTag.PatientID)
DICOMPatientInfo.Add(DicomTag.PatientSex)
DICOMPatientInfo.Add(DicomTag.PatientBirthDate)

DICOMStudyInfo.Add(DicomTag.StudyID)
DICOMStudyInfo.Add(DicomTag.AccessionNumber)
DICOMStudyInfo.Add(DicomTag.ReferringPhysicianName)
DICOMStudyInfo.Add(DicomTag.AccessionNumber)
DICOMStudyInfo.Add(DicomTag.StudyDate)
DICOMStudyInfo.Add(DicomTag.StudyTime)

ClassTypes.Add(DicomClassType.SCImageStorage)
ClassTypes.Add(DicomClassType.SCMultiFrameGrayscaleByteImageStorage)
ClassTypes.Add(DicomClassType.SCMultiFrameTrueColorImageStorage)
ClassTypes.Add(DicomClassType.EncapsulatedPdfStorage)

   _ExcludedTags.Add(DicomTag.SOPClassUID)
   _ExcludedTags.Add(DicomTag.SOPInstanceUID)
   _ExcludedTags.Add(DicomTag.StudyInstanceUID)
   _ExcludedTags.Add(DicomTag.SeriesInstanceUID)
   _ExcludedTags.Add(DicomTag.MediaStorageSOPClassUID)
   _ExcludedTags.Add(DicomTag.FrameIncrementPointer)
   _ExcludedTags.Add(DicomTag.MIMETypeOfEncapsulatedDocument)
   _ExcludedTags.Add(DicomTag.PageNumberVector)

   Try
   If StartedPrinter = "" Then
      bFinishedPrinting = True
      InitializePrinter()
   End If

   InitializeForm()
   InitializeTwain()
   InitializeWia()
   SetServersComboBox(True)
   InitializeScreenCapture()
   Dim tmStart As DateTime = DateTime.Now

   Do While (Not bFinishedPrinting) AndAlso (DateTime.Now.Subtract(tmStart)).TotalSeconds < 20
      Application.DoEvents()
   Loop

   Deserialize(_mySettings._settings.DataPath)

   'Initialize Store and Query Options
   CreateCFindObject(New MyServer())
   CreateCStoreObject(New MyServer())
   UpdateToolBarState()

   _captureType = CaptureType.None
   CheckFirstRun()
   ShowHelp()
   _mySettings._settings.FirstRun = False
   _mySettings.Save()
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   Me.Close()
   End Try
   End Sub

   Private Sub _pgDicomInfo_BeforeAddElement(ByVal sender As Object, ByVal e As BeforeAddElementEventArgs)
   '
   ' Excluded items and Volatile Elements will not be displayed in the editor
   '
   e.Cancel = _ExcludedTags.Contains(e.Element.DicomElement.Tag) OrElse e.Element.DataSet.IsVolatileElement(e.Element.DicomElement)
   If (Not e.Cancel) Then
   If e.Element.DicomElement.Tag = DicomTag.ConversionType Then
      e.Element.Choices.Add("DV")
      e.Element.Choices.Add("DI")
      e.Element.Choices.Add("DF")
      e.Element.Choices.Add("WSD")
      e.Element.Choices.Add("SD")
      e.Element.Choices.Add("SI")
      e.Element.Choices.Add("DRW")
      e.Element.Choices.Add("SYN")
      e.Element.Attributes.Add(New TypeConverterAttribute(GetType(DicomPropertyChoiceConverter)))
   ElseIf e.Element.DicomElement.Tag = DicomTag.Modality Then
      e.Element.Choices.Add("CR")
      e.Element.Choices.Add("CT")
      e.Element.Choices.Add("MR")
      e.Element.Choices.Add("NM")
      e.Element.Choices.Add("US")
      e.Element.Choices.Add("OT")
      e.Element.Choices.Add("BI")
      e.Element.Choices.Add("DG")
      e.Element.Choices.Add("ES")
      e.Element.Choices.Add("LS")
      e.Element.Choices.Add("PT")
      e.Element.Choices.Add("RG")
      e.Element.Choices.Add("TG")
      e.Element.Choices.Add("XA")
      e.Element.Choices.Add("RF")
      e.Element.Choices.Add("RTIMAGE")
      e.Element.Choices.Add("RTDOSE")
      e.Element.Choices.Add("RTSTRUCT")
      e.Element.Choices.Add("RTPLAN")
      e.Element.Choices.Add("RTRECORD")
      e.Element.Choices.Add("HC")
      e.Element.Choices.Add("DX")
      e.Element.Choices.Add("MG")
      e.Element.Choices.Add("IO")
      e.Element.Choices.Add("PX")
      e.Element.Choices.Add("GM")
      e.Element.Choices.Add("SM")
      e.Element.Choices.Add("XC")
      e.Element.Choices.Add("PR")
      e.Element.Choices.Add("AU")
      e.Element.Choices.Add("ECG")
      e.Element.Choices.Add("EPS")
      e.Element.Choices.Add("HD")
      e.Element.Choices.Add("SR")
      e.Element.Choices.Add("IVUS")
      e.Element.Choices.Add("OP")
      e.Element.Choices.Add("SMR")
      e.Element.Choices.Add("AR")
      e.Element.Choices.Add("KER")
      e.Element.Choices.Add("VA")
      e.Element.Choices.Add("SRF")
      e.Element.Choices.Add("OCT")
      e.Element.Choices.Add("LEN")
      e.Element.Choices.Add("OPV")
      e.Element.Choices.Add("OPM")
      e.Element.Choices.Add("OAM")
      e.Element.Choices.Add("RESP")
      e.Element.Choices.Add("KO")
      e.Element.Choices.Add("SEG")
      e.Element.Choices.Add("REG")
      e.Element.Choices.Add("OPT")
      e.Element.Choices.Add("BDUS")
      e.Element.Choices.Add("BMD")
      e.Element.Choices.Add("DOC")
      e.Element.Choices.Add("FID")
      e.Element.Choices.Add("DS")
      e.Element.Choices.Add("CF")
      e.Element.Choices.Add("DF")
      e.Element.Choices.Add("VF")
      e.Element.Choices.Add("AS")
      e.Element.Choices.Add("CS")
      e.Element.Choices.Add("EC")
      e.Element.Choices.Add("LP")
      e.Element.Choices.Add("FA")
      e.Element.Choices.Add("CP")
      e.Element.Choices.Add("DM")
      e.Element.Choices.Add("FS")
      e.Element.Choices.Add("MA")
      e.Element.Choices.Add("MS")
      e.Element.Choices.Add("CD")
      e.Element.Choices.Add("DD")
      e.Element.Choices.Add("ST")
      e.Element.Choices.Add("OPR")
      e.Element.Attributes.Add(New TypeConverterAttribute(GetType(DicomPropertyChoiceConverter)))
   End If
   End If
   End Sub

   Private Sub _miResample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miResample.Click
   Dim prop As RasterPaintProperties = _pictureBox.PaintProperties
   _mySettings._settings.UseResample = prop.PaintDisplayMode = RasterPaintDisplayModeFlags.Resample
   If _mySettings._settings.UseResample Then
   prop.PaintDisplayMode = RasterPaintDisplayModeFlags.None
   Else
   prop.PaintDisplayMode = RasterPaintDisplayModeFlags.Resample
   End If
   _mySettings._settings.UseResample = Not _mySettings._settings.UseResample
   _mySettings.Save()
   _pictureBox.PaintProperties = prop
   End Sub

   Private Sub _frmOperation_Cancel(ByVal sender As Object, ByVal e As EventArgs)
   bCancelOperation = True
   End Sub

   Private Sub _pictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
   Dim iDelteY As Integer = e.Y - iOldY
   Dim iDelteX As Integer = e.X - iOldX
   If e.Button = MouseButtons.Middle AndAlso Not _pictureBox.Image Is Nothing Then
   If iDelteY < 0 Then
      ZoomPicture(0.03F)
   End If
   If iDelteY > 0 Then
      ZoomPicture(-0.03F)
   End If
   End If
   If e.Button = MouseButtons.Right AndAlso Not _pictureBox.Image Is Nothing Then
   _pictureBox.ScrollPosition = New System.Drawing.Point(_pictureBox.ScrollPosition.X - iDelteX, _pictureBox.ScrollPosition.Y - iDelteY)
   End If
   iOldY = e.Y
   iOldX = e.X
   End Sub

   Private Sub _lstBoxPages_ListStateChanged(ByVal sender As Object, ByVal e As EventArgs)
   UpdateToolBarState()
   End Sub

   Private Sub _cmListBox_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles _cmListBox.Opening
   _cmiExpanded.Checked = _lstBoxPages.ViewMode = ThumbMode.Expanded
   _cmiCondensed.Checked = _lstBoxPages.ViewMode = ThumbMode.Condensed

   _cmiDeleteAll.Enabled = _lstBoxPages.Items.Count > 0
   _cmiDeleteSelected.Enabled = _lstBoxPages.SelectedItems.Count > 0

   End Sub

   Private Sub _cmiExpanded_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cmiExpanded.Click
   _lstBoxPages.ViewMode = ThumbMode.Expanded
   End Sub

   Private Sub _miDeleteSelectedDataSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miDeleteSelectedDataSet.Click
   If Not _lstDSPatient.SelectedItems Is Nothing AndAlso _lstDSPatient.SelectedItems.Count > 0 Then
   TryCast(_lstDSPatient.SelectedItems(0).Tag, DicomDataSet).Dispose()
   _lstDSPatient.Items.Remove(_lstDSPatient.SelectedItems(0))
   End If
   End Sub

   Private Sub _lstDSPatient_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _lstDSPatient.KeyDown
   If e.KeyCode = Keys.Delete Then
   _miDeleteSelectedDataSet_Click(Nothing, Nothing)
   End If
   End Sub

   Private Sub _lstSCPStudies_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lstSCPStudies.SelectedIndexChanged
   _btnTransferSCPStudies.Enabled = _lstSCPStudies.SelectedItems.Count > 0
   End Sub

   Private Sub _lstMWLItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lstMWLItems.SelectedIndexChanged
   _btnTransferMWL.Enabled = _lstMWLItems.SelectedItems.Count > 0
   End Sub

   Private Sub _cmiCondensed_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cmiCondensed.Click
   _lstBoxPages.ViewMode = ThumbMode.Condensed
   End Sub

   Private Sub _miOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOpen.Click
   Dim dlgOpen As RasterOpenDialog = New RasterOpenDialog(_codec)
   dlgOpen.ShowPreview = True
   dlgOpen.PreviewWindowVisible = True
   dlgOpen.FilterIndex = 1
   dlgOpen.ShowFileInformation = True
   If strLastLocation <> "" Then
   dlgOpen.InitialDirectory = Path.GetDirectoryName(strLastLocation)
   End If

   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   Dim dlgRes As DialogResult = dlgOpen.ShowDialog(Me)
   If dlgRes = DialogResult.Cancel Then
   dlgOpen.Dispose()
   logWindow.TopMost = bTopMost
   Return
   End If
   LoadRasterImage(dlgOpen.FileName)

   If Not dlgOpen Is Nothing Then
   dlgOpen.Dispose()
   End If
   End Sub

   Private Sub _miPaste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPaste.Click
   Try
   Dim img As Bitmap = CType(Clipboard.GetImage(), Bitmap)
   Dim rImg As RasterImage = Leadtools.Drawing.RasterImageConverter.ChangeFromHBitmap(img.GetHbitmap(), IntPtr.Zero)
   CreateImageCollection("Pasted Image", rImg)
   Catch
   End Try
      End Sub

      Private Sub CopySpecificCharacterSetElement(ByVal imageDataSet As DicomDataSet, ByVal infoDataSet As DicomDataSet)
         Dim element As DicomElement = infoDataSet.FindFirstElement(Nothing, DicomTag.SpecificCharacterSet, True)
         If element IsNot Nothing Then
            Dim ba() As Byte = infoDataSet.GetBinaryValue(element, CInt(Fix(element.Length)))
            imageDataSet.InsertElementAndSetValue(DicomTag.SpecificCharacterSet, ba)
         End If
      End Sub

   Private Sub _btnTransferLoadedPatient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTransferLoadedPatient.Click
         If _lstDSPatient.SelectedItems.Count = 0 Then
            Return
         End If
         Dim sourceDataSet As DicomDataSet = Nothing
         sourceDataSet = TryCast(_lstDSPatient.SelectedItems(0).Tag, DicomDataSet)

         CopySpecificCharacterSetElement(_pgDicomInfo.DataSet, sourceDataSet)

         Dim [module] As DicomModule = sourceDataSet.FindModule(DicomModuleType.Patient)
         If [module] Is Nothing Then
            Return
         End If
         SetElements(_pgDicomInfo.DataSet, [module].Elements, sourceDataSet)

         ResetModule(DicomModuleType.GeneralStudy, _pgDicomInfo.DataSet, True)

         GenerateDefaultElements()
         InsertNewStudyModule()
         InsertNewSeries()
   End Sub

   Private Sub _btnTransferLoadedStudies_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTransferLoadedStudies.Click
   If _lstDSStudies.SelectedItems.Count = 0 Then
   Return
   End If

   Dim sourceDataSet As DicomDataSet = Nothing
   sourceDataSet = TryCast(_lstDSStudies.SelectedItems(0).Tag, DicomDataSet)
   Dim [module] As DicomModule = sourceDataSet.FindModule(DicomModuleType.GeneralStudy)

   Dim lstElements As List(Of DicomElement) = New List(Of DicomElement)()
   lstElements.AddRange([module].Elements)
   Dim dElement As DicomElement = Nothing
   dElement = sourceDataSet.FindFirstElement(Nothing, DicomTag.StudyDescription, True)
   If Not dElement Is Nothing Then
   lstElements.Add(dElement)
   End If

   If Not [module] Is Nothing Then
   SetElements(_pgDicomInfo.DataSet, [module].Elements, sourceDataSet)
   End If

   [module] = sourceDataSet.FindModule(DicomModuleType.Patient)
   If Not [module] Is Nothing Then
   SetElements(_pgDicomInfo.DataSet, [module].Elements, sourceDataSet)
   End If

   ResetModule(DicomModuleType.GeneralSeries, _pgDicomInfo.DataSet, True)
   GenerateDefaultElements()
   InsertNewSeries()

   End Sub

   Private Sub _lstView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lstDSStudies.SelectedIndexChanged, _lstDSPatient.SelectedIndexChanged
   Try
   If _lstDSPatient Is TryCast(sender, ListView) Then
      _btnTransferLoadedPatient.Enabled = (TryCast(sender, ListView)).SelectedItems.Count > 0
      _lstDSStudies.Items.Clear()
      Dim item As ListViewItem = Nothing
      Dim dElement As DicomElement = Nothing
      Dim val As String = ""
      Dim dicom As DicomDataSet = CType(_lstDSPatient.SelectedItems(0).Tag, DicomDataSet)
      If dicom Is Nothing Then
      Return
      End If

      For Each dTag As Long In DICOMStudyInfo
      dElement = dicom.FindFirstElement(Nothing, dTag, True)
      val = ""
      If Not dElement Is Nothing Then
      val = dicom.GetValue(Of String)(dElement, Nothing)
      End If

      If item Is Nothing Then
      item = _lstDSStudies.Items.Add(val)
      Else
      item.SubItems.Add(val)
      End If
      Next dTag
      item.Tag = dicom
      item.Selected = True
   End If

   If _lstDSStudies Is TryCast(sender, ListView) Then
      _btnTransferLoadedStudies.Enabled = (TryCast(sender, ListView)).SelectedItems.Count > 0
   End If

   Catch
   _lstDSStudies.Items.Clear()
   _btnTransferLoadedPatient.Enabled = False
   _btnTransferLoadedStudies.Enabled = False
   End Try

   End Sub

   Private Sub _toolBtnTwain_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnTwain.Click
   _miTwainAcquire_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnWia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnWia.Click
   _miWiaAcquire_Click(Nothing, Nothing)
   End Sub

   Private Sub _btnTransferSCPStudies_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTransferSCPStudies.Click
   If _lstSCPStudies.SelectedItems.Count = 0 Then
   Return
   End If

   Dim study As Study = TryCast(_lstSCPStudies.SelectedItems(0).Tag, Study)
   Dim ds As DicomDataSet = _pgDicomInfo.DataSet
   ResetModule(DicomModuleType.Patient, _pgDicomInfo.DataSet, True)
   ResetModule(DicomModuleType.GeneralStudy, _pgDicomInfo.DataSet, True)

   Dim patient As Patient = study.Patient
   If patient Is Nothing Then
   Return
   End If

   InsertPatientInfo(ds, patient)
   InsertNewStudyModule()
   InsertStudyInfo(ds, study)
   _pgDicomInfo.DataSet = _pgDicomInfo.DataSet
   GenerateDefaultElements()
   InsertNewSeries()
   End Sub

   Private Sub _btnTransferSCPPatient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTransferSCPPatient.Click
   If _lstSCPPatient.SelectedItems.Count = 0 Then
   Return
   End If

   Dim study As Study = TryCast(_lstSCPPatient.SelectedItems(0).Tag, List(Of Study))(0)
   Dim ds As DicomDataSet = _pgDicomInfo.DataSet
   ResetModule(DicomModuleType.Patient, _pgDicomInfo.DataSet, True)
   ResetModule(DicomModuleType.GeneralStudy, _pgDicomInfo.DataSet, True)

   Dim patient As Patient = study.Patient
   If patient Is Nothing Then
   Return
   End If

   InsertPatientInfo(ds, patient)
   _pgDicomInfo.DataSet = _pgDicomInfo.DataSet
   GenerateDefaultElements()
   InsertNewStudyModule()
   InsertNewSeries()
   End Sub

   Private Sub _btnMWLTransfer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTransferMWL.Click
   If _lstMWLItems.SelectedItems.Count = 0 Then
   Return
   End If

   ResetModule(DicomModuleType.GeneralSeries, _pgDicomInfo.DataSet, True)
   GenerateDefaultElements()
   InsertNewSeries()

   Dim ds As DicomDataSet = _pgDicomInfo.DataSet
   Dim result As ModalityWorklistResult = Nothing
   result = (TryCast(_lstMWLItems.SelectedItems(0).Tag, ModalityWorklistResult))

   'Study
   Dim dElement As DicomElement
   If Not result.AccessionNumber Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.AccessionNumber, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.AccessionNumber, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, result.AccessionNumber)
   End If

   If Not result.ReferringPysician Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.ReferringPhysicianName, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.ReferringPhysicianName, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, result.ReferringPysician.FullDicomEncoded)
   End If

   'Patient
   If Not result.PatientName Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientName, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientName, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, result.PatientName.FullDicomEncoded)
   End If

   If Not result.PatientId Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientID, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientID, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, result.PatientId)
   End If

   If Not result.PatientSex Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientSex, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientSex, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, result.PatientSex)
   End If

   If Not result.PatientBirthDate Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientBirthDate, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientBirthDate, DicomVRType.UN, False, 0)
   End If
   ds.SetDateValue(dElement, New DateTime() {CDate(result.PatientBirthDate)})
   End If

   If Not result.RequestedProcedureId Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.StudyID, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.StudyID, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, result.RequestedProcedureId)
   End If

   If Not result.StudyInstanceUid Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.StudyInstanceUID, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.StudyInstanceUID, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, result.StudyInstanceUid)
   End If

   _pgDicomInfo.DataSet = ds
   End Sub

   Private Sub _lstSCPPatient_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lstSCPPatient.SelectedIndexChanged
   _btnTransferSCPPatient.Enabled = (_lstSCPPatient.SelectedItems.Count > 0)
   _btnTransferSCPStudies.Enabled = False
   If _lstSCPPatient.SelectedItems.Count = 0 OrElse _lstSCPPatient.SelectedItems(0) Is Nothing Then
   _lstSCPStudies.Items.Clear()
   Return
   End If

   _lstSCPStudies.Items.Clear()

   For Each study As Study In (TryCast(_lstSCPPatient.SelectedItems(0).Tag, List(Of Study)))

      Dim item As ListViewItem
      item = _lstSCPStudies.Items.Add(study.Id)
      If Not study.ReferringPhysiciansName Is Nothing Then
         item.SubItems.Add(study.ReferringPhysiciansName.FullDicomEncoded)
      Else
          item.SubItems.Add("")
      End If
      item.SubItems.Add(study.AccessionNumber)
      If study.Date.HasValue Then
         item.SubItems.Add(study.Date.ToString())
      Else
         item.SubItems.Add(String.Empty)
      End If
         If study.Time.HasValue Then
            item.SubItems.Add(study.Time.ToString())
         Else
            item.SubItems.Add(String.Empty)
         End If

      item.Tag = study
   Next study

   If _lstSCPStudies.Items.Count > 0 Then
      _lstSCPStudies.Items(0).Selected = True
   End If
   End Sub

   Private Sub _miRotate90_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miRotate90.Click
   If _pictureBox.Image Is Nothing Then
   Return
   End If

   Try
   _pictureBox.Image.RotateViewPerspective(90)
   _lstBoxPages.SelectedItem.RasterImage.RotateViewPerspective(90)
   Dim strFileLoc As String = (TryCast(_lstBoxPages.SelectedItem.ImageItem.Tag, IPrintToPACSFile)).FileLocation()

   If _lstBoxPages.SelectedItem.ImageItem.Tag.GetType() Is GetType(PrintPage) Then
      _codec.Save(_lstBoxPages.SelectedItem.RasterImage, strFileLoc, RasterImageFormat.Emf, 0)
   Else
      _codec.Save(_lstBoxPages.SelectedItem.RasterImage, strFileLoc, RasterImageFormat.Tif, 0)
   End If
   Catch
   End Try
   End Sub

   Private Sub _toolBtnRotate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnRotate.Click
   _miRotate90_Click(Nothing, Nothing)
   End Sub

   Private Sub _lstBoxPages_ItemDeSlect(ByVal sender As Object, ByVal e As EventArgs)
   If Not _pictureBox.Image Is Nothing Then
   _pictureBox.Image.Dispose()
   _pictureBox.Image = Nothing
   End If
   _btnNext.Enabled = False
   _btnPrev.Enabled = False
   _lblPageInfo.Text = ""
   UpdateToolBarState()
   End Sub

   Private Sub _miShowHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miShowHelp.Click
   Dim dlg As HelpDialog = New HelpDialog(Nothing, False, False)
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   dlg.ShowDialog(Me)
   logWindow.TopMost = bTopMost

   End Sub

   Private Sub _pictureBox_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
   If (Control.ModifierKeys And Keys.Control) <> 0 Then
   If e.Delta > 0 Then
      _miZoomIn_Click(Nothing, Nothing)
   Else
      _miZoomOut_Click(Nothing, Nothing)
   End If
   Else
   Dim iSelectedPage As Integer = 0
   If _lstBoxPages.ViewMode = ThumbMode.Condensed Then
      iSelectedPage = _lstBoxPages.SelectedItemGroupIndex
   Else
      iSelectedPage = _lstBoxPages.SelectedIndex
   End If

   If e.Delta > 0 Then

      If iSelectedPage < _lstBoxPages.GetGroupImageItems().Count - 1 Then
      _btnNext_Click(Nothing, Nothing)
      End If
   Else
      If iSelectedPage > 0 Then
      _btnPrev_Click(Nothing, Nothing)
      End If
   End If
   End If
   End Sub

   Private Sub FrmMain_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
   Try
   _pictureBox.Invalidate()
   _lstBoxPages.Invalidate()
   Catch
   End Try
   End Sub

   Private Sub _miClearPrintedList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miDeleteAll.Click, _cmiDeleteAll.Click
   Try
   ClearList()
   EnableNextPrevious()
   UpdateToolBarState()
   _lblPageInfo.Text = ""
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Try
   End Sub

   Private Sub _miAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miAbout.Click
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   Try
   Dim aboutDialog As AboutDialog = New AboutDialog("PrintToPACS")
   aboutDialog.ShowDialog()

   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Try
   logWindow.TopMost = bTopMost
   End Sub

   Private Sub _miExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miExit.Click
   Try
   Me.Close()
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Try
   End Sub

   Private Sub _lstBoxPages_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lstBoxPages.SelectedIndexChanged
   ScalePicture(_lstBoxPages.SelectedItem.ImageItem)
   EnableNextPrevious()
   UpdateToolBarState()
   _iOldIndex = _lstBoxPages.SelectedIndex
   _mySettings._settings.LastSelectedIndex = _lstBoxPages.SelectedIndex
   _mySettings.Save()
   End Sub

   Private Sub _miFile_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miFile.DropDownOpening
   Try
   _miSaveAsDICOM.Enabled = (_lstBoxPages.CheckedItems.Count > 0)
   _miStoreToPACS.Enabled = (_lstBoxPages.CheckedItems.Count > 0)
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Try
   End Sub

   Private Sub _lstBoxPages_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _lstBoxPages.KeyDown
   Try
   If e.KeyCode = Keys.Delete AndAlso Not _lstBoxPages.SelectedItem Is Nothing Then
      _miDeleteSelected_Click(Nothing, Nothing)
   End If

   If e.KeyCode = Keys.V AndAlso Control.ModifierKeys = Keys.Control Then
      _miPaste_Click(Nothing, Nothing)

   ElseIf e.KeyCode = Keys.Add Then
      _miZoomIn_Click(_miZoomIn, New EventArgs())
   ElseIf e.KeyCode = Keys.Subtract Then
      _miZoomOut_Click(_miZoomOut, New EventArgs())
   End If
   Catch e1 As ArgumentOutOfRangeException
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Try
   End Sub

   Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
   Try
   Serialize(_mySettings._settings.DataPath)

   If Not _codec Is Nothing Then
      _codec.Dispose()
   End If
   Utils.EngineShutdown()
   Utils.DicomNetShutdown()

   FinilizeScreenCapture()
   FinilizeTwain()
   FinilizeWia()
   _engine.StopCapture()
   Catch e1 As Exception
   'MessageBox.Show("Closing Form " + Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
   End Try
   End Sub

   Private Sub _miNormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miNormal.Click
   Try
   _pictureBox.SizeMode = RasterPaintSizeMode.Normal
   _pictureBox.ScaleFactor = 1
   Catch exp As Exception
   Messager.ShowError(Me, exp)
   End Try
   End Sub

   Private Sub _miFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFit.Click
   Try
   _pictureBox.SizeMode = RasterPaintSizeMode.FitAlways
   _pictureBox.ScaleFactor = 1
   Catch exp As Exception
   Messager.ShowError(Me, exp)
   End Try
   End Sub

   Private Sub _miClearResult_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miClearResult.Click
   If _lstSelected Is _lstDSPatient OrElse _lstSelected Is _lstDSStudies Then
   For Each lvi As ListViewItem In _lstDSPatient.Items
      CType(lvi.Tag, DicomDataSet).Dispose()
   Next lvi
   _btnTransferLoadedPatient.Enabled = False
   _btnTransferLoadedStudies.Enabled = False

   _lstDSPatient.Items.Clear()
   _lstDSStudies.Items.Clear()
   End If
   If _lstSelected Is _lstSCPPatient Then
   _btnTransferSCPStudies.Enabled = False
   _btnTransferSCPPatient.Enabled = False

   _lstSCPStudies.Items.Clear()
   _lstSCPPatient.Items.Clear()
   End If
   If _lstSelected Is _lstMWLItems Then
   _btnTransferMWL.Enabled = False

   _lstMWLItems.Items.Clear()
   End If
   End Sub

   Private Sub _lstView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _lstDSStudies.MouseDown, _lstDSPatient.MouseDown, _lstSCPStudies.MouseDown, _lstSCPPatient.MouseDown, _lstMWLItems.MouseDown
   If e.Button = MouseButtons.Right Then
   _lstSelected = Nothing
   Dim lv As ListView = TryCast(sender, ListView)
   If lv.Items.Count > 0 Then
      _lstSelected = lv
   End If
   End If
   End Sub

   Private Sub _cmResultQuery_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles _cmResultQuery.Opening
   If _lstSelected Is Nothing OrElse _lstSelected.Items.Count = 0 OrElse _lstSelected Is _lstSCPStudies Then
   e.Cancel = True
   End If
   toolStripSeparator22.Visible = (_lstSelected Is _lstDSPatient)
   _miDeleteSelectedDataSet.Visible = (_lstSelected Is _lstDSPatient)
   _miDeleteSelectedDataSet.Enabled = (_lstDSPatient.SelectedItems.Count >= 1)
   End Sub

   Private Sub _miZoomIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miZoomIn.Click
   Try
   ZoomPicture(0.1F)
   Catch exp As Exception
   Messager.ShowError(Me, exp)
   End Try
   End Sub

   Private Sub _miZoomOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miZoomOut.Click
   Try
   If _pictureBox.ScaleFactor > 0.1F Then
      ZoomPicture(-0.1F)
   End If
   Catch exp As Exception
   Messager.ShowError(Me, exp)
   End Try
   End Sub

   Private Sub _pictureBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
   Try
   If e.KeyCode = Keys.Add Then
      _miZoomIn_Click(_miZoomIn, New EventArgs())
   ElseIf e.KeyCode = Keys.Subtract Then
      _miZoomOut_Click(_miZoomOut, New EventArgs())
   End If
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Try
   End Sub

   Private Sub _btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnNext.Click
   If _lstBoxPages.ViewMode = ThumbMode.Expanded Then
   If _lstBoxPages.SelectedIndex < _lstBoxPages.Items.Count - 1 Then
      _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex + 1
   End If
   Else
   If _lstBoxPages.SelectedItemGroupIndex < _lstBoxPages.GetGroupImageItems().Count - 1 Then
      _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex + 1
   End If
   End If
   End Sub

   Private Sub _btnPrev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPrev.Click
   If _lstBoxPages.ViewMode = ThumbMode.Expanded Then
   If _lstBoxPages.SelectedIndex > 0 Then
      _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex - 1
   End If
   Else
   If _lstBoxPages.SelectedItemGroupIndex > 0 Then
      _lstBoxPages.SelectedIndex = _lstBoxPages.SelectedIndex - 1
   End If
   End If
   End Sub

   Private Sub _miSCPOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miSettings.Click
   If DoOptions(0) <> DialogResult.Cancel Then
   SetServersComboBox(False)
   End If
   UpdateComboBoxes()
   End Sub

   Private Sub _btnSCPQuery_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnSCPQuery.Click, _btnMWLQuery.Click
   If DoSearch() Then
   Dim iMatchCount As Integer = 0
   If _tbDicomInfo.SelectedTab Is _pageSCPQuery Then
      iMatchCount = _lstSCPPatient.Items.Count
   Else
      iMatchCount = _lstMWLItems.Items.Count
   End If

   EnableItems(True, "", "")
   If iMatchCount = 0 Then
      Dim bTopMost As Boolean = logWindow.TopMost
      logWindow.TopMost = False
      MessageBox.Show(Me, "No studies found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      logWindow.TopMost = bTopMost
      If _tbDicomInfo.SelectedTab Is _pageSCPQuery Then
         _btnTransferSCPPatient.Enabled = False
      End If
   Else
      If _tbDicomInfo.SelectedTab Is _pageSCPQuery Then
      _lstSCPPatient.Items(0).Selected = True
      _lstSCPPatient.Focus()
      Else
      _lstMWLItems.Items(0).Selected = True
      _lstMWLItems.Focus()
      End If
   End If
   End If
   End Sub

   Private Sub _miSaveAsDICOM_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miSaveAsDICOM.Click
   Dim dicom As DicomDataSet = (TryCast(_pgDicomInfo.SelectedObject, DicomEditableObject)).DataSet
   If (Not CheckRequiredTags(dicom)) Then
   Return
   End If

   Dim dlgSave As SaveFileDialog = New SaveFileDialog()
   dlgSave.Filter = "DICOM Files|*.dcm|DICOM DataSet Files|*.dic"
   If strLastLocation <> "" Then
   dlgSave.InitialDirectory = Path.GetDirectoryName(strLastLocation)
   End If

   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   Dim dlgRes As DialogResult = dlgSave.ShowDialog()

   If dlgRes = DialogResult.Cancel Then
   logWindow.TopMost = bTopMost
   Return
   End If
   Try
   Dim lstSaved As List(Of String) = New List(Of String)()
   Dim strSaveLocation As String = dlgSave.FileName
   strLastLocation = strSaveLocation
   Dim bSuccess As Boolean = False
   EnableItems(False, "Saving Files To HardDisk Please Wait...", "Cancel")
   Dim strMessage As String = DoSave(dicom, lstSaved, strSaveLocation, bSuccess)

   Dim icon As MessageBoxIcon = MessageBoxIcon.Information
   If bSuccess Then
      icon = MessageBoxIcon.Information
   Else
      icon = MessageBoxIcon.Error
   End If

   EnableItems(True, "", "")
   If bSuccess Then
      Dim dlgClear As DialogResult = MessageBox.Show(Me, strMessage & Constants.vbLf & "Do you want to clear the DICOM information?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If dlgClear = DialogResult.Yes Then
      _miClearPG_Click(Nothing, Nothing)
      End If
   Else
      MessageBox.Show(Me, "DICOM file was not saved successfully", Me.Text, MessageBoxButtons.OK, icon)
   End If
   Catch
   End Try
   logWindow.TopMost = bTopMost
   End Sub

   Private Function CheckRequiredTags(ByVal dicom As DicomDataSet) As Boolean
   Dim strMessage As String = ""
   Dim lstRequired As List(Of String) = New List(Of String)()
   GetRequiredTags(dicom, lstRequired)

   Dim dElement As DicomElement = dicom.FindFirstElement(Nothing, DicomTag.PatientName, True)
   Dim val As String = dicom.GetValue(Of String)(dElement, "")
   If val = String.Empty Then
   lstRequired.Add("Patient Name")
   End If

   dElement = dicom.FindFirstElement(Nothing, DicomTag.PatientID, True)
   val = dicom.GetValue(Of String)(dElement, "")
   If val = String.Empty Then
   lstRequired.Add("Patient ID")
   End If

   If lstRequired.Count > 0 Then
   strMessage = "The Following Tags Are Required:" & Constants.vbLf
   For Each strName As String In lstRequired
      strMessage &= "--> " & strName & Constants.vbLf
   Next strName
   End If

   If _lstBoxPages.CheckedItems.Count = 0 AndAlso strMessage = "" Then
   strMessage = "One or more Print job/pages needs to be checked"
   End If
   If strMessage <> "" Then
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   MessageBox.Show(Me, strMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   logWindow.TopMost = bTopMost
   Return False
   Else
   Return True
   End If
   End Function

   Private Sub _miStoreToPACS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miStoreToPACS.Click
   If _mySettings._settings.StoreServers.serverList.Length = 0 Then
   Return
   End If

   Dim server As MyServer = _mySettings._settings.StoreServers.serverList(_cbStoreServers.SelectedIndex)
   Dim strTemp As String, strMessage As String = String.Empty
   strTemp = Path.GetTempFileName()

   Dim dicom As DicomDataSet = (TryCast(_pgDicomInfo.SelectedObject, DicomEditableObject)).DataSet
   Dim lstSaved As List(Of String) = New List(Of String)()
   Dim bSuccess As Boolean = False

   If (Not CheckRequiredTags(dicom)) Then
   Return
   End If

   EnableItems(False, "Saving Temporary Files To HardDisk Please Wait...", "Cancel")
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   strMessage = DoSave(dicom, lstSaved, strTemp, bSuccess)
   EnableItems(True, "", "")

   If bSuccess AndAlso (Not bCancelOperation) Then
   EnableItems(False, "Storing To PACS Please Wait...", "Cancel")
   Try
      strMessage = Constants.vbLf & "Storing to PACS:" & Constants.vbLf
      For Each strFile As String In lstSaved
      Try
      DoStore(strFile, server)
      Catch ex As Exception
      logWindow.TopMost = False
      EnableItems(True, "", "")
      MessageBox.Show("Error Occurred: " & Constants.vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
      Application.DoEvents()
      If bCancelOperation Then
      Exit For
      End If
      Next strFile
      bSuccess = True
      strMessage &= Constants.vbLf & "File Stored Successfully"
   Catch ex As System.Exception
      bSuccess = False
      strMessage &= "Error Occurred:" & Constants.vbLf + ex.Message
   End Try
   End If
   File.Delete(strTemp)

   EnableItems(True, "", "")

   If bSuccess AndAlso bStored AndAlso (Not bCancelOperation) Then
   If _mySettings._settings.autodelete Then
      DeleteCheckedItems()
   End If
   logWindow.TopMost = False
   Dim dlgClear As DialogResult = MessageBox.Show(Me, strMessage & Constants.vbLf & "Do you want to clear the DICOM information?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
   If dlgClear = DialogResult.Yes Then
      _miClearPG_Click(Nothing, Nothing)
   End If
   Else
   logWindow.TopMost = False
   If bCancelOperation Then
      MessageBox.Show(Me, "Operation Cancelled", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   Else
      If bSuccess Then
      MessageBox.Show(Me, "File Was Not Stored Successfully", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
      MessageBox.Show(Me, strMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
   End If
   End If
   logWindow.TopMost = bTopMost
   End Sub

   Private Sub _miClearPG_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miClearPG.Click
   Dim ds As DicomDataSet = _pgDicomInfo.DataSet
   ds.Dispose()
   _pgDicomInfo.DataSet = Nothing
   _cmbSopClasses_SelectedIndexChanged(Nothing, Nothing)
   End Sub

   Private Sub _miClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miClearSearch.Click
   If _tbDicomInfo.SelectedTab Is _pageMWLQuery Then
   If (Not _toolBtnPatient.Checked) Then
      _bbQuery = New BroadBasedQuery()
      _pgSearchMWL.SelectedObject = _bbQuery
   Else
      _pbQuery = New PatientBasedQuery()
      _pgSearchMWL.SelectedObject = _pbQuery
   End If
   End If

   If _tbDicomInfo.SelectedTab Is _pageSCPQuery Then
   _findQuery = New DicomFindQuery()
   _pgSearchSCP.SelectedObject = _findQuery
   End If
   End Sub

   Private Sub _lstBoxPages_ItemAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lstBoxPages.ItemAdded
   Try
   If _lstBoxPages.ViewMode = ThumbMode.Expanded Then
      UpdateLabel(_lstBoxPages.SelectedIndex + 1)
   Else
    UpdateLabel(_lstBoxPages.SelectedItemGroupIndex + 1)
   End If
   Catch
    UpdateLabel(1)
   End Try
   End Sub

   Private Sub _lstView_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _lstDSStudies.Resize, _lstDSPatient.Resize, _lstSCPStudies.Resize, _lstSCPPatient.Resize, _lstMWLItems.Resize
   SizeColumns(TryCast(sender, ListView))
   End Sub

   Private Sub _cmbSopClasses_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbSopClasses.SelectedIndexChanged
   If _cmbSopClasses.SelectedIndex >= 0 Then
   Dim tempDataSet As DicomDataSet = New DicomDataSet(), sourceDataSet As DicomDataSet = _pgDicomInfo.DataSet
   Dim [module] As DicomModule = Nothing
   'Clone the dataset
   If Not sourceDataSet Is Nothing Then
      tempDataSet.Initialize(_pgDicomInfo.DataSet.InformationClass, DicomDataSetInitializeFlags.AddMandatoryElementsOnly Or DicomDataSetInitializeFlags.AddMandatoryModulesOnly)

      [module] = sourceDataSet.FindModule(DicomModuleType.GeneralStudy)
      If Not [module] Is Nothing Then
      SetElements(tempDataSet, [module].Elements, sourceDataSet)
      End If

      [module] = sourceDataSet.FindModule(DicomModuleType.Patient)
      If Not [module] Is Nothing Then
      SetElements(tempDataSet, [module].Elements, sourceDataSet)
      End If
   End If

   InitializeDataSet(ClassTypes(_cmbSopClasses.SelectedIndex))

   'Restore the dataset
   If Not sourceDataSet Is Nothing Then
      sourceDataSet = tempDataSet

      [module] = sourceDataSet.FindModule(DicomModuleType.GeneralStudy)
      If Not [module] Is Nothing Then
      SetElements(_pgDicomInfo.DataSet, [module].Elements, sourceDataSet)
      End If

      [module] = sourceDataSet.FindModule(DicomModuleType.Patient)
      If Not [module] Is Nothing Then
      SetElements(_pgDicomInfo.DataSet, [module].Elements, sourceDataSet)
      End If

      'ResetModule(DicomModuleType.GeneralSeries, _pgDicomInfo.DataSet);
      GenerateDefaultElements()
   Else
      GenerateDefaultElements()
      InsertNewStudyModule()
   End If

   End If
   End Sub

   Private Sub GenerateDefaultElements()
   GenerateUidTag(_pgDicomInfo.DataSet, DicomTag.SeriesInstanceUID)
   GenerateUidTag(_pgDicomInfo.DataSet, DicomTag.SOPInstanceUID)

   Dim dElement As DicomElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.InstanceNumber, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetValue(dElement, "1")
   End If

   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.ConversionType, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetValue(dElement, "DI")
   End If

   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.SeriesNumber, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetValue(dElement, "1")
   End If

   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.FrameIncrementPointer, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetValue(dElement, &H182001) 'HEX 2C6F1H
   End If

   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.MIMETypeOfEncapsulatedDocument, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetValue(dElement, "PDF")
   End If

   If _pgDicomInfo.DataSet.InformationClass = DicomClassType.SCMultiFrameGrayscaleByteImageStorage OrElse _pgDicomInfo.DataSet.InformationClass = DicomClassType.SCMultiFrameTrueColorImageStorage Then
   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.PageNumberVector, True)
   If dElement Is Nothing Then
      dElement = _pgDicomInfo.DataSet.InsertElement(Nothing, False, DicomTag.PageNumberVector, DicomVRType.IS, False, 0)
   End If
   End If

   _pgDicomInfo.DataSet = _pgDicomInfo.DataSet
   End Sub

   Private Sub InsertNewSeries()
   Dim ds As DicomDataSet = _pgDicomInfo.DataSet
   Dim dElement As DicomElement = ds.FindFirstElement(Nothing, DicomTag.Modality, True)
   If dElement Is Nothing Then
   ds.InsertElement(Nothing, False, dElement.Tag, dElement.VR, False, 0)
   End If
   If ds.InformationClass = DicomClassType.EncapsulatedPdfStorage Then
   ds.SetValue(dElement, "DOC")
   Else
   ds.SetValue(dElement, "OT")
   End If
   _pgDicomInfo.DataSet = ds
   End Sub

   Private Sub InsertNewStudyModule()
   Dim dElement As DicomElement
   GenerateUidTag(_pgDicomInfo.DataSet, DicomTag.StudyInstanceUID)

   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.StudyDate, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetDateValue(dElement, New DateTime() {DateTime.Now.Date})
   End If

   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.StudyTime, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetTimeValue(dElement, New DateTime() {New DateTime(DateTime.Now.Year, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)})
   End If

   dElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.StudyID, False)
   If Not dElement Is Nothing Then
   _pgDicomInfo.DataSet.SetValue(dElement, "1")
   End If
   _pgDicomInfo.DataSet = _pgDicomInfo.DataSet
   End Sub

   Private Sub _miEdit_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miEdit.DropDownOpening
   _miRotate90.Enabled = (_lstBoxPages.SelectedItems.Count > 0)
   _miDeleteSelected.Enabled = (_lstBoxPages.SelectedItems.Count > 0)
   _miDeleteAll.Enabled = (_lstBoxPages.Items.Count > 0)
   _miPaste.Enabled = Clipboard.ContainsImage()
   End Sub

   Private Sub _miDeleteSelected_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miDeleteSelected.Click, _cmiDeleteSelected.Click
   DeleteSelectedItems()

   If Not _pictureBox.Image Is Nothing Then
   _pictureBox.Image.Dispose()
   _pictureBox.Image = Nothing
   End If

   EnableNextPrevious()
   UpdateToolBarState()
   _lblPageInfo.Text = ""
   End Sub

   Private Sub _miResetInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miResetInfo.Click
   _miClearPG_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnStoreToPacs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnStoreToPacs.Click
   _miStoreToPACS_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnSaveDicom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnSaveDicom.Click
   _miSaveAsDICOM_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnCLearInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnCLearInfo.Click
   _miClearPG_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnDeleteAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnDeleteAll.Click
   _miClearPrintedList_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnDeleteSelected_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnDeleteSelected.Click
   _miDeleteSelected_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnViewLog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnViewLog.Click
   _miViewLog_Click(Nothing, Nothing)
   End Sub

   Private Sub _miViewLog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miViewLog.Click
   logWindow.Visible = Not logWindow.Visible
   UpdateToolBarState()
   End Sub

   Private Sub _toolBtnHelp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnHelp.Click
   _miShowHelp_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnOpenRaster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnOpenRaster.Click
   _miOpen_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnSettings.Click
   If DoOptions(0) <> DialogResult.Cancel Then
   SetServersComboBox(False)
   End If
   UpdateComboBoxes()
   End Sub

   Private Sub _btnPACSSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPACSSettings.Click
   If DoOptions(1) <> DialogResult.Cancel Then
   SetServersComboBox(False)
   End If
   UpdateComboBoxes()
   End Sub

   Private Sub _miView_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miView.DropDownOpening
   _miResample.Enabled = (Not _pictureBox.Image Is Nothing)
   _miFit.Enabled = (Not _pictureBox.Image Is Nothing)
   _miNormal.Enabled = (Not _pictureBox.Image Is Nothing)
   _miZoomIn.Enabled = (Not _pictureBox.Image Is Nothing)
   _miZoomOut.Enabled = (Not _pictureBox.Image Is Nothing)
   Dim prop As RasterPaintProperties = _pictureBox.PaintProperties
   _miResample.Checked = (prop.PaintDisplayMode = RasterPaintDisplayModeFlags.Resample)
   _miNormal.Checked = (_pictureBox.SizeMode = RasterPaintSizeMode.Normal)
   _miFit.Checked = (_pictureBox.SizeMode = RasterPaintSizeMode.FitAlways)
   _miViewLog.Checked = logWindow.Visible
   Dim oldScaleFactor As Double = _pictureBox.ScaleFactor, dZoomFactor As Double = 0.1
   oldScaleFactor = _pictureBox.ScaleFactor + dZoomFactor
   _miZoomIn.Enabled = Not _pictureBox.Image Is Nothing AndAlso Not (oldScaleFactor > 3 AndAlso dZoomFactor > 0)
   oldScaleFactor = _pictureBox.ScaleFactor - dZoomFactor
   _miZoomOut.Enabled = Not _pictureBox.Image Is Nothing AndAlso Not (oldScaleFactor < 0.06 AndAlso -dZoomFactor < 0)
   End Sub

   Private Sub _cbSevers_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbStoreServers.SelectedIndexChanged
   Dim server As MyServer = (TryCast(_cbStoreServers.SelectedItem, MyServer))
   End Sub

   Private Sub _toolBtnScreenCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnScreenCapture.Click
   _engine.StopCapture()
   Dim bTemp As Boolean = _isHotKeyEnabled
   _isHotKeyEnabled = False
   Dim opt As Leadtools.ScreenCapture.ScreenCaptureOptions = _engine.CaptureOptions
   Dim oldKey As Keys = opt.Hotkey
   opt.Hotkey = Keys.None
   _engine.CaptureOptions = opt
   DoCapture(_mySettings._settings.capturetype)
   _isHotKeyEnabled = bTemp
   opt.Hotkey = oldKey
   _engine.CaptureOptions = opt
   End Sub

   Private Sub _pictureBox_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
   If Not _pictureBox.Image Is Nothing Then
   _pictureBox.SizeMode = RasterPaintSizeMode.FitAlways
   _pictureBox.ScaleFactor = 1
   End If
   End Sub

   Private Sub _btnPushToPACS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPushToPACS.Click
   _toolBtnStoreToPacs_Click(Nothing, Nothing)
   End Sub

   Private Sub _toolBtnPatient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolBtnPatient.Click
   _toolBtnPatient.Checked = Not _toolBtnPatient.Checked
   If _toolBtnPatient.Checked Then
   _pageMWLQuery.Controls.Add(_tbQueryMWList)
   _pgSearchMWL.SelectedObject = _pbQuery
   _toolLblMWLType.Text = "Patient Based Search"
   Else
   _pageMWLQuery.Controls.Add(_tbQueryMWList)
   _pgSearchMWL.SelectedObject = _bbQuery
   _toolLblMWLType.Text = "Broad Based Search"
   End If
   End Sub

   Private Sub _btnOpenImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOpenImage.Click
   _toolBtnOpenRaster_Click(Nothing, Nothing)
   End Sub

   Private Sub _btnScreenCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnScreenCapture.Click
   _toolBtnScreenCapture_Click(Nothing, Nothing)
   End Sub

   Private Sub _btnTwainAquire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTwainAquire.Click
   _toolBtnTwain_Click(Nothing, Nothing)
   End Sub

   Private Sub _btnWIAAquire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnWIAAquire.Click
   _toolBtnWia_Click(Nothing, Nothing)
   End Sub

   Private Sub _miHowToUse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miHowToUse.Click
   Dim usage As FrmUsage = New FrmUsage()
   usage.ShowDialog(Me)
   End Sub

   Private Sub _btnBrowseDataSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBrowseDataSet.Click
   Dim dlgOpen As OpenFileDialog = New OpenFileDialog()
   Dim dlgRes As DialogResult
   dlgOpen.Filter = "Dicom Files|*.dcm|Dicom DataSet Files|*.dic|Dicom XML DataSet Files|*.xml"
   dlgOpen.Multiselect = False
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   dlgRes = dlgOpen.ShowDialog()
   If dlgRes = DialogResult.Cancel Then
   logWindow.TopMost = bTopMost
   Return
   End If

   _txtDataSet.Text = dlgOpen.FileName
   logWindow.TopMost = bTopMost

   LoadDataSet(_txtDataSet.Text)
   End Sub
#End Region

#Region "Print Events..."

   Public Sub _printer_EmfEvent(ByVal sender As Object, ByVal e As EmfEventArgs)
   Dim printpage As PrintPage = New PrintPage(_jobId)
   Me.Enabled = False
   Dim tempFile As String = Path.GetTempFileName()
   printpage.FilePath = tempFile

   File.WriteAllBytes(tempFile, e.Stream.ToArray())

   Dim metaFile As Metafile = New Metafile(e.Stream)
   _pageNo += 1

   Dim emfImage As Image = metaFile.GetThumbnailImage(150, 110, Nothing, IntPtr.Zero)
   printpage.MetaFile = metaFile.GetHenhmetafile()
   metaFile.Dispose()

   imgCollection.Images.Add(New ListImageBox.ImageItem(_codec.Load(printpage.FilePath), imgCollection, printpage))
   If _frmProgress.Visible Then
   _frmProgress.SetProgressState(_pageNo, _jobId)
   End If
   e.Stream.Close()

   End Sub

   Public Sub _printer_JobEvent(ByVal sender As Object, ByVal e As JobEventArgs)
   If e.JobEventState = EventState.JobStart Then
   Me.Enabled = True
   Me.BringToFront()
   Me.Focus()
   _pageNo = 0
   _jobId = e.JobID
   imgCollection = New ListImageBox.ImageCollection("Print JobID " & _jobId)
   If (Not _frmProgress.Visible) Then
      _frmProgress = New FrmProgress(e.PrinterName, _printer)
      _frmProgress.Show()
   End If
   ElseIf e.JobEventState = EventState.JobEnd Then
   _frmProgress.Close()
   _lstBoxPages.AddImageCollection(imgCollection)
   Me.Enabled = True
   Me.BringToFront()
   Me.Focus()
   'EnableNextPrevious();
   _lstBoxPages.SelectedIndex = 0
   _lstBoxPages_SelectedIndexChanged(Nothing, Nothing)
   bFinishedPrinting = True
   End If
   End Sub

#End Region

#Region "Methods..."

   Private Sub InitializeForm()
   _frmProgress = New FrmProgress()

   _pgDicomInfo = New Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid()
   DicomEditableObject = New Leadtools.Dicom.Common.Editing.DicomEditableObject()
   _pictureBox = New Leadtools.WinForms.RasterImageViewer()
   'TEMP
   'this._tbTableLayout.Controls.Add(this._pictureBox, 0, 3);
   ' 
   ' _pictureBox
   ' 
   _pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace
   _pictureBox.Dock = System.Windows.Forms.DockStyle.Fill
   _pictureBox.EnableScrollingInterface = True
   _pictureBox.Location = New System.Drawing.Point(3, 43)
   _pictureBox.Name = "_pictureBox"
   _pictureBox.Size = New System.Drawing.Size(394, 394)
   _pictureBox.TabIndex = 5
   ' 
   ' _pgDicomInfo
   ' 
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
   _pgDicomInfo.ContextMenuStrip = _cnmnuClearDicom
   _pgDicomInfo.DataSet = Nothing
   _pgDicomInfo.DefaultTag = (CLng(-1))
   _pgDicomInfo.Dock = System.Windows.Forms.DockStyle.Fill
   _pgDicomInfo.Location = New System.Drawing.Point(3, 33)
   _pgDicomInfo.Name = "_pgDicomInfo"
   _pgDicomInfo.SelectedObject = DicomEditableObject
   _pgDicomInfo.ShowCommands = True
   _pgDicomInfo.ShowTagInfo = True
   _pgDicomInfo.ShowUsageImages = True
   _pgDicomInfo.Size = New System.Drawing.Size(388, 213)
   _pgDicomInfo.TabIndex = 0
   _tbTableLayout.Controls.Add(_panelImageList, 0, 2)
   _tbTableLayout.SetColumnSpan(_panelImageList, 3)
   _pgDicomInfo.ToolbarVisible = False
   AddHandler _pgDicomInfo.BeforeAddElement, AddressOf _pgDicomInfo_BeforeAddElement

   _tbPropertyGrid.Controls.Add(_pgDicomInfo, 0, 1)
   _panelImageList.Controls.Add(_lstBoxPages)
   _lstBoxPages.ViewMode = ThumbMode.Condensed
   _lstBoxPages.ContextMenuStrip = _cmListBox
   AddHandler _lstBoxPages.ListStateChanged, AddressOf _lstBoxPages_ListStateChanged
   AddHandler _pictureBox.MouseWheel, AddressOf _pictureBox_MouseWheel
   _pictureBox.BorderPadding.Bottom = 10
   _pictureBox.BorderPadding.Top = 10
   _pictureBox.BorderPadding.Left = 10
   _pictureBox.BorderPadding.Right = 10
   _pictureBox.HorizontalAlignMode = RasterPaintAlignMode.Center
   _pictureBox.VerticalAlignMode = RasterPaintAlignMode.Center
   _pictureBox.BackColor = Color.DarkGray
   _pictureBox.EnableScrollingInterface = True
   AddHandler _pictureBox.KeyDown, AddressOf _pictureBox_KeyDown
   AddHandler _lstBoxPages.ItemDeSlect, AddressOf _lstBoxPages_ItemDeSlect
   _pictureBox.InteractiveMode = Leadtools.WinForms.RasterViewerInteractiveMode.ZoomTo
   AddHandler _pictureBox.MouseMove, AddressOf _pictureBox_MouseMove
   _pgSearchSCP.SelectedObject = _findQuery
   _tbPicture.Controls.Add(_pictureBox, 0, 5)
   _tbPicture.SetColumnSpan(_pictureBox, 4)
   _pgDicomInfo.ShowTagInfo = False
   _pgDicomInfo.ShowCommands = False
   _pgDicomInfo.CommandsVisibleIfAvailable = False
   _pgDicomInfo.HelpVisible = False
   AddHandler _pictureBox.DoubleClick, AddressOf _pictureBox_DoubleClick

   Dim fileClientCertificate As String = Application.StartupPath & "\client.pem"
   If File.Exists(fileClientCertificate) Then
   If _mySettings._settings.clientCertificate = String.Empty Then
      _mySettings._settings.clientCertificate = Application.StartupPath & "\client.pem"
   End If
   If _mySettings._settings.privateKey = String.Empty Then
      _mySettings._settings.privateKey = Application.StartupPath & "\client.pem"
   End If
   If _mySettings._settings.privateKeyPassword = String.Empty Then
      _mySettings._settings.privateKeyPassword = "test"
   End If
   End If

   Dim prop As RasterPaintProperties = _pictureBox.PaintProperties
   If (Not _mySettings._settings.UseResample) Then
   prop.PaintDisplayMode = RasterPaintDisplayModeFlags.None
   Else
   prop.PaintDisplayMode = RasterPaintDisplayModeFlags.Resample
   End If
   _pictureBox.PaintProperties = prop
   Text = "LEADTOOLS VB Print to PACS"
   _codec = New RasterCodecs()
   _cmbSopClasses.SelectedIndex = ClassTypes.IndexOf(_mySettings._settings.selectedtype)

   logWindow = New LogWindow(Me)
   logWindow.Visible = False

   _pageMWLQuery.Controls.Add(_tbQueryMWList)
   _pgSearchMWL.SelectedObject = _bbQuery

   _txtPrinterName.Text = _printer.PrinterName
   End Sub

   Private Sub ZoomPicture(ByVal dZoomFactor As Double)
   Try
   Dim oldScaleFactor As Double = _pictureBox.ScaleFactor
   If _pictureBox.SizeMode = RasterPaintSizeMode.FitAlways Then
      Dim dWidthFraction As Double = CDbl(_pictureBox.Width - 30) / CDbl(_pictureBox.Image.Width)
      Dim dHeightFraction As Double = CDbl(_pictureBox.Height - 30) / CDbl(_pictureBox.Image.Height)
      Dim dScale As Double = dWidthFraction
      If dHeightFraction < dWidthFraction Then
      dScale = dHeightFraction
      End If
      _pictureBox.SizeMode = RasterPaintSizeMode.Normal
      oldScaleFactor = dScale
   End If


   oldScaleFactor = oldScaleFactor + dZoomFactor
   If oldScaleFactor > 3 AndAlso dZoomFactor > 0 Then
      Return
   End If
   If oldScaleFactor < 0.06 AndAlso dZoomFactor < 0 Then
      Return
   End If
   _pictureBox.SizeMode = RasterPaintSizeMode.Normal
   _pictureBox.ScaleFactor = oldScaleFactor
   Catch
   End Try
   End Sub

   Private Sub CreateImageCollection(ByVal strTittle As String, ByVal rasterImage As RasterImage)
   Dim imagecollection As ListImageBox.ImageCollection = New ListImageBox.ImageCollection(strTittle)
   Dim page As Page = New Page()
   Dim strTemp As String = Nothing
   strTemp = Path.GetTempFileName()
   _codec.Save(rasterImage, strTemp, RasterImageFormat.Tif, 0)
   page.FilePath = strTemp
   page.DeleteOnDispose = True
   imagecollection.Images.Add(New ListImageBox.ImageItem(_codec.Load(strTemp), imagecollection, page))
   rasterImage.Dispose()

   _lstBoxPages.AddImageCollection(imagecollection)
   End Sub

   Private Sub DeleteCheckedItems()
   For i As Integer = _lstBoxPages.Items.Count - 1 To 0 Step -1
   Dim item As ListImageBox.ListItem = _lstBoxPages.Items(i)
   If item.ImageItem.Checked Then
      _lstBoxPages.RemoveItem(i)
   End If
   Next i

   Try
   _lstBoxPages_SelectedIndexChanged(Nothing, Nothing)
   Catch

   If Not _pictureBox.Image Is Nothing Then
      _pictureBox.Image.Dispose()
      _pictureBox.Image = Nothing
   End If

   EnableNextPrevious()
   _lblPageInfo.Text = ""
   End Try
   End Sub

   Private Sub DeleteSelectedItems()
   For i As Integer = _lstBoxPages.Items.Count - 1 To 0 Step -1
   Dim item As ListImageBox.ListItem = _lstBoxPages.Items(i)
   If item.Selected Then
      _lstBoxPages.RemoveItem(i)
   End If
   Next i
   End Sub

   Public Sub UpdateToolBarState()
   _toolBtnDeleteAll.Enabled = _lstBoxPages.Items.Count > 0
   _toolBtnRotate.Enabled = (_lstBoxPages.SelectedItems.Count > 0)
   _toolBtnDeleteSelected.Enabled = (_lstBoxPages.SelectedItems.Count > 0)
   _toolBtnSaveDicom.Enabled = _lstBoxPages.CheckedItems.Count > 0
   _btnPushToPACS.Enabled = ((_lstBoxPages.CheckedItems.Count > 0) AndAlso (_mySettings._settings.StoreServers.serverList.Length > 0))
   _toolBtnStoreToPacs.Enabled = ((_lstBoxPages.CheckedItems.Count > 0) AndAlso (_mySettings._settings.StoreServers.serverList.Length > 0))
   _btnWIAAquire.Enabled = _wiaAvailable AndAlso _wiaSourceSelected AndAlso Not _wiaAcquiring
   _toolBtnWia.Enabled = _wiaAvailable AndAlso _wiaSourceSelected AndAlso Not _wiaAcquiring
   _btnTwainAquire.Enabled = _twainAvailable
   _toolBtnTwain.Enabled = _twainAvailable
   _btnScreenCapture.Enabled = Not (_mySettings._settings.capturetype = CaptureType.None)
   _toolBtnScreenCapture.Enabled = Not (_mySettings._settings.capturetype = CaptureType.None)
   _toolBtnViewLog.Checked = logWindow.Visible
   End Sub

   Private Sub InitializePrinter()
   Dim installPrinter As Boolean = False
   If (Not PrintingUtilities.IsPrinterExist(_mySettings._settings.printerName)) Then
   installPrinter = True
   InstallPACSPrinter(_mySettings._settings.printerName)
   End If
   If Not PrintingUtilities.IsPrinterExist(_mySettings._settings.printerName) Then
	If DemosGlobal.IsAdmin() Then
		Throw New Exception("Error in installing printer, Please Make sure LEADTOOLS Virtual Printer Driver installed" & vbLf & "Application will close now")
	Else
		Throw New Exception("Error in installing printer run the demo again with administrative rights" & vbLf & "Application will close now")
	End If
	Else
	If installPrinter Then
		MessageBox.Show("Installation " + _mySettings._settings.printerName + " Printer Completed Successfully", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
	End If
	End If
   _printer = New Printer(_mySettings._settings.printerName)
   AddHandler _printer.EmfEvent, AddressOf _printer_EmfEvent
   AddHandler _printer.JobEvent, AddressOf _printer_JobEvent
   End Sub

   Private Sub InitializeDataSet(ByVal dClass As DicomClassType)
   Dim ds As DicomDataSet = New DicomDataSet()
   Try
   If dClass = DicomClassType.SCImageStorage Then
      If File.Exists(_mySettings._settings.secondaryCapturePath) Then
      DicomExtensions.LoadXml(ds, _mySettings._settings.secondaryCapturePath, DicomDataSetLoadXmlFlags.None, Nothing, Nothing)
      End If
   End If

   If dClass = DicomClassType.SCMultiFrameTrueColorImageStorage Then
      If File.Exists(_mySettings._settings.secondaryCaptureColorPath) Then
      DicomExtensions.LoadXml(ds, _mySettings._settings.secondaryCaptureColorPath, DicomDataSetLoadXmlFlags.None, Nothing, Nothing)
      End If
   End If

   If dClass = DicomClassType.SCMultiFrameGrayscaleByteImageStorage Then
      If File.Exists(_mySettings._settings.secondaryCaptureGrayPath) Then
      DicomExtensions.LoadXml(ds, _mySettings._settings.secondaryCaptureGrayPath, DicomDataSetLoadXmlFlags.None, Nothing, Nothing)
      End If
   End If

   If dClass = DicomClassType.EncapsulatedPdfStorage Then
      If File.Exists(_mySettings._settings.PdfPath) Then
      DicomExtensions.LoadXml(ds, _mySettings._settings.PdfPath, DicomDataSetLoadXmlFlags.None, Nothing, Nothing)
      End If
   End If
   Catch
   End Try

   If ds Is Nothing OrElse ds.InformationClass <> dClass Then
   ds.Initialize(dClass, DicomDataSetInitializeFlags.AddMandatoryElementsOnly Or DicomDataSetInitializeFlags.AddMandatoryModulesOnly)
   End If

   ClearTag(ds, DicomTag.PixelData)
   ClearTag(ds, DicomTag.EncapsulatedDocument)

   Dim dElement As DicomElement = ds.FindFirstElement(Nothing, DicomTag.Modality, True)
   If dElement Is Nothing Then
   ds.InsertElement(Nothing, False, dElement.Tag, dElement.VR, False, 0)
   End If
   If ds.InformationClass = DicomClassType.EncapsulatedPdfStorage Then
   ds.SetValue(dElement, "DOC")
   Else
   ds.SetValue(dElement, "OT")
   End If

   _pgDicomInfo.DataSet = ds
   End Sub

   Private Shared Sub ClearListView(ByVal lv As ListView)
   For Each item As ListViewItem In lv.Items
   If Not item.Tag Is Nothing Then
      CType(item.Tag, DicomDataSet).Dispose()
   End If
   Next item
   lv.Items.Clear()
   End Sub

   Private Sub SizeColumns(ByVal lv As ListView)
   For Each header As ColumnHeader In lv.Columns
   header.Width = Convert.ToInt32(lv.Width / lv.Columns.Count)
   Next header
   End Sub

   Private Sub Serialize(ByVal filelocation As String)
   Dim binFormatter As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
   Dim fStream As FileStream = File.Create(filelocation)
   For Each item As ListImageBox.ListItem In _lstBoxPages.Items
   item.RasterImage.Dispose()
   item.RasterImage = Nothing
   item._Controls = Nothing
   item.ImageItem.Image = Nothing
   Application.DoEvents()
   Next item
   binFormatter.Serialize(fStream, _lstBoxPages.ImageCollections)
   fStream.Close()
   End Sub

   Private Sub Deserialize(ByVal filelocation As String)
   EnableItems(False, "Opening Previous Files Please Wait...", "")
   Dim sThreaded As ThreadedClass = New ThreadedClass
   sThreaded.dsfile = filelocation
sThreaded.mainfrm = Me
   Dim t As Thread = New Thread(AddressOf sThreaded.DeserializeThreaded)


   t.Start()
   Do While t.IsAlive
   Application.DoEvents()
   Loop

   End Sub

   Private Delegate Sub AddImageCollectionThreadedDelegate(ByVal collection As ListImageBox.ImageCollection)
   Private Sub AddImageCollectionThreaded(ByVal collection As ListImageBox.ImageCollection)
   If InvokeRequired Then
   Invoke(New AddImageCollectionThreadedDelegate(AddressOf AddImageCollectionThreaded), collection)
   Else
   _lstBoxPages.AddImageCollection(collection)
   End If
   End Sub

   Private Sub CheckFirstRun()
   If _mySettings._settings.FirstRun Then
   Try
      Dim strFirstImage As String = DemosGlobal.ImagesFolder & "\image1.cmp"
      LoadRasterImage(strFirstImage)
      _txtDataSet.Text = DemosGlobal.ImagesFolder & "\image2.dcm"
      LoadDataSet(_txtDataSet.Text)
      _btnTransferLoadedStudies_Click(Nothing, Nothing)
      _lstBoxPages.SelectedIndex = 0
      _lstBoxPages.Items(0).ImageItem.Checked = True
      _lstBoxPages.Items(0).CheckState = CheckState.Checked
      _btnPushToPACS.Enabled = True
      Dim usage As FrmUsage = New FrmUsage()
      usage.ShowDialog(Me)
   Catch
   End Try
   Else
   Try
      _lstBoxPages.SelectedIndex = _mySettings._settings.LastSelectedIndex
   Catch
   End Try
   End If
   End Sub

   Private Sub ShowHelp()
   MyBase.Activate()
   If _mySettings._settings.showHelpOnStart Then
   Dim dlg As HelpDialog = New HelpDialog(Nothing, True, _mySettings._settings.FirstRun)
   dlg.ShowDialog(Me)
   If dlg.CheckBoxNoShowAgainResult Then
      _mySettings._settings.showHelpOnStart = False
      _mySettings.Save()
   End If
   End If
   End Sub

   Private Sub UpdateComboBoxes()
   Dim iSCPIndex As Integer = _cbSCPServers.SelectedIndex, iMWLIndex As Integer = _cbMWLServers.SelectedIndex, iStoreIndex As Integer = _cbStoreServers.SelectedIndex
   If _cbSCPServers.Items.Count <> 0 Then
   If _cbSCPServers.Items.Count > iSCPIndex AndAlso iSCPIndex >= 0 Then
      _cbSCPServers.SelectedIndex = iSCPIndex
   Else
      If _cbSCPServers.Items.Count > _mySettings._settings.DefaultSCPServer Then
      _cbSCPServers.SelectedIndex = _mySettings._settings.DefaultSCPServer
      Else
      _cbSCPServers.SelectedIndex = 0
      End If
   End If
   End If

   If _cbMWLServers.Items.Count <> 0 Then
   If _cbMWLServers.Items.Count > iMWLIndex AndAlso iMWLIndex >= 0 Then
      _cbMWLServers.SelectedIndex = iMWLIndex
   Else
      If _cbMWLServers.Items.Count > _mySettings._settings.DefaultMWLServer Then
      _cbMWLServers.SelectedIndex = _mySettings._settings.DefaultMWLServer
      Else
      _cbMWLServers.SelectedIndex = 0
      End If
   End If
   End If

   If _cbStoreServers.Items.Count <> 0 Then
   If _cbStoreServers.Items.Count > iStoreIndex AndAlso iStoreIndex >= 0 Then
      _cbStoreServers.SelectedIndex = iStoreIndex
   Else
      If _cbStoreServers.Items.Count > _mySettings._settings.DefaultStoreServer Then
      _cbStoreServers.SelectedIndex = _mySettings._settings.DefaultStoreServer
      Else
      _cbStoreServers.SelectedIndex = 0
      End If
   End If
   End If
   End Sub

   Private Function DoOptions(ByVal iSelectedTab As Integer) As DialogResult
   Dim options As OptionsDialog = New OptionsDialog()
   options.serverlistSCP = CType(_mySettings._settings.QuerySCPServers.Clone(), MyServerList)
   options.serverlistMWL = CType(_mySettings._settings.QueryMWLServers.Clone(), MyServerList)
   options.serverlistStore = CType(_mySettings._settings.StoreServers.Clone(), MyServerList)
   options.SelectedTab = iSelectedTab

   options.ClientAE = _mySettings._settings.clientAE
   options.ClientCertificate = _mySettings._settings.clientCertificate
   options.PrivateKey = _mySettings._settings.privateKey
   options.PrivateKeyPassword = _mySettings._settings.privateKeyPassword
   options.LogLowLevel = _mySettings._settings.logLowLevel

   options.AutoDelete = _mySettings._settings.autodelete

   options.TempDirectory = _mySettings._settings.TempDir
   options.Selectedtype = _mySettings._settings.selectedtype

   options.SCCompression = _mySettings._settings.secondaryCaptureCompression
   options.SCColorCompression = _mySettings._settings.secondaryCaptureColorCompression
   options.SCGrayCompression = _mySettings._settings.secondaryCaptureGrayCompression

   options.SCGrayPath = _mySettings._settings.secondaryCaptureGrayPath
   options.SCColorPath = _mySettings._settings.secondaryCaptureColorPath
   options.SCPath = _mySettings._settings.secondaryCapturePath
   options.PdfPath = _mySettings._settings.PdfPath

   options.PrinterName = _mySettings._settings.printerName

   options.DefaultSCPServer = _mySettings._settings.DefaultSCPServer
   options.DefaultMWLServer = _mySettings._settings.DefaultMWLServer
   options.DefaultStoreServer = _mySettings._settings.DefaultStoreServer
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   Dim dr As DialogResult = options.ShowDialog(Me)
   If dr = DialogResult.OK Then
   _mySettings._settings.clientAE = options.ClientAE
   _mySettings._settings.clientCertificate = options.ClientCertificate
   _mySettings._settings.privateKey = options.PrivateKey
   _mySettings._settings.privateKeyPassword = options.PrivateKeyPassword
   _mySettings._settings.logLowLevel = options.LogLowLevel

   _mySettings._settings.QuerySCPServers = options.serverlistSCP
   _mySettings._settings.QueryMWLServers = options.serverlistMWL
   _mySettings._settings.StoreServers = options.serverlistStore

   _mySettings._settings.autodelete = options.AutoDelete

   _mySettings._settings.TempDir = options.TempDirectory
   _mySettings._settings.selectedtype = options.Selectedtype

   _mySettings._settings.secondaryCaptureCompression = options.SCCompression
   _mySettings._settings.secondaryCaptureColorCompression = options.SCColorCompression
   _mySettings._settings.secondaryCaptureGrayCompression = options.SCGrayCompression

   _mySettings._settings.secondaryCaptureGrayPath = options.SCGrayPath
   _mySettings._settings.secondaryCaptureColorPath = options.SCColorPath
   _mySettings._settings.secondaryCapturePath = options.SCPath
   _mySettings._settings.PdfPath = options.PdfPath

   _mySettings._settings.DefaultSCPServer = options.DefaultSCPServer
   _mySettings._settings.DefaultMWLServer = options.DefaultMWLServer
   _mySettings._settings.DefaultStoreServer = options.DefaultStoreServer

   If _mySettings._settings.printerName <> options.PrinterName Then
      Try
      Dim printerInfo As PrinterInfo = New PrinterInfo()
      printerInfo.PrinterName = _mySettings._settings.printerName

      If (Not InstallPACSPrinter(options.PrinterName)) Then
      MessageBox.Show("Error in renaming printer" & Constants.vbLf & "Exit the demo and run it with administrative rights", "Print to PACS demo", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
      _mySettings._settings.printerName = options.PrinterName
      MessageBox.Show("Printer renamed to " & _mySettings._settings.printerName & " completed successfully", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      _printer = New Printer(options.PrinterName)
      AddHandler _printer.EmfEvent, AddressOf _printer_EmfEvent
      AddHandler _printer.JobEvent, AddressOf _printer_JobEvent
      Printer.UnInstall(printerInfo)
      End If
      Catch
      End Try
   End If
   _mySettings.Save()
   End If
   _txtPrinterName.Text = _printer.PrinterName
   logWindow.TopMost = bTopMost
   Return dr
   End Function

   Public Sub EnableItems(ByVal enable As Boolean, ByVal strCaption As String, ByVal strBtnCaption As String)
   If Me.InvokeRequired Then
   Invoke(New EnableMenu(AddressOf EnableItems), New Object() {enable, strCaption, strBtnCaption})
   Else
   If enable Then
      Cursor.Current = Cursors.Arrow
   Else
      Cursor.Current = Cursors.WaitCursor
   End If

   _mmMain.Enabled = enable
   _lstBoxPages.Enabled = enable
   _tbDicomInfo.Enabled = enable
   _cmbSopClasses.Enabled = enable
   _cbStoreServers.Enabled = enable
   _btnPushToPACS.Enabled = enable
   _toolbarMain.Enabled = enable
   _pgDicomInfo.Enabled = enable
   _btnScreenCapture.Enabled = enable
   _btnPACSSettings.Enabled = enable
   _btnOpenImage.Enabled = enable
   _btnWIAAquire.Enabled = enable
   _btnTwainAquire.Enabled = enable
   If enable Then
      UpdateToolBarState()
      If Not _frmOperation Is Nothing Then
      _frmOperation.Close()
      End If
   Else
      If Not (strCaption = "" AndAlso strBtnCaption = "") Then
      If _frmOperation Is Nothing OrElse (Not _frmOperation.Visible) Then
      _frmOperation = New FrmOperation(strCaption, strBtnCaption)
      bCancelOperation = False
      If strBtnCaption <> "" Then
      AddHandler _frmOperation.Cancel, AddressOf _frmOperation_Cancel
      End If
      _frmOperation.Show()
      End If
      End If
   End If
   End If
   End Sub

   Private Function GetFitRect(ByVal rect As Rectangle, ByVal width As Integer, ByVal height As Integer) As Rectangle
   Dim newWidth As Integer = 0
   Dim newHeight As Integer = 0

   newHeight = rect.Height
   newWidth = Convert.ToInt32(newHeight * width / height)

   If newWidth > rect.Width Then
   newWidth = rect.Width
   newHeight = Convert.ToInt32(newWidth * height / width)
   End If

   Return New Rectangle(rect.Left, rect.Top, newWidth, newHeight)
   End Function

   Private Function InstallPACSPrinter(ByVal printername As String) As Boolean
   Dim bRet As Boolean = False
   Dim bExsists As Boolean = PrintingUtilities.IsPrinterExist(printername)

   If (Not bExsists) Then
   bRet = PrintingUtilities.InstallNewPrinter(printername, "")
   End If
   Return bRet OrElse bExsists
   End Function

   Private Sub EnableNextPrevious()
   _btnNext.Enabled = True
   _btnPrev.Enabled = True

   If _lstBoxPages.Items.Count = 0 Then
   _btnPrev.Enabled = False
   _btnNext.Enabled = False
   Return
   End If

   If _lstBoxPages.ViewMode = ThumbMode.Condensed Then
   If _lstBoxPages.SelectedItemGroupIndex < 0 Then
      _btnPrev.Enabled = False
      _btnNext.Enabled = False
      Return
   End If
   If _lstBoxPages.SelectedItemGroupIndex <= 0 Then
      _btnPrev.Enabled = False
   End If

   If _lstBoxPages.SelectedItemGroupIndex = _lstBoxPages.GetSelectedImageCollection().Images.Count - 1 Then
      _btnNext.Enabled = False
   End If
   Else
   If _lstBoxPages.SelectedIndex <= 0 Then
      _btnPrev.Enabled = False
   End If

   If _lstBoxPages.SelectedIndex = _lstBoxPages.Items.Count - 1 Then
      _btnNext.Enabled = False
   End If

   End If
   End Sub

   Private Sub ScalePicture(ByVal item As PrintToPACSDemo.ListImageBox.ImageItem)
   If Not _pictureBox.Image Is Nothing Then
   _pictureBox.Image.Dispose()
   _pictureBox.Image = Nothing
   End If
   _pictureBox.Image = item.Image.Clone()

   _pictureBox_DoubleClick(Nothing, Nothing)

   If _lstBoxPages.ViewMode = ThumbMode.Condensed Then
   UpdateLabel(_lstBoxPages.SelectedItemGroupIndex + 1)
   Else
   UpdateLabel(_lstBoxPages.SelectedIndex + 1)
   End If
   End Sub

   Private Sub UpdateLabel(ByVal iSelectedindex As Integer)
   Try
   _lblPageInfo.Text = "Page " & (iSelectedindex).ToString() & " / " & (_lstBoxPages.GetGroupImageItems().Count).ToString()
   Catch
    _lblPageInfo.Text = ""
   End Try
   End Sub

   Private Sub InitClass()
         If RasterSupport.IsLocked(RasterSupportType.PrintDriver) AndAlso RasterSupport.IsLocked(RasterSupportType.PrintDriverServer) Then
            Throw New Exception("Printer driver capability is required.")
         End If
   End Sub

   Private Sub ClearList()
   Try
   DeleteTempFiles()
   _lstBoxPages.ClearList()
   If Not _pictureBox.Image Is Nothing Then
      _pictureBox.Image.Dispose()
      _pictureBox.Image = Nothing
   End If
   Catch Ex As Exception
   MessageBox.Show(Ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Try
   End Sub

   Private Sub DeleteTempFiles()
   For Each item As ListImageBox.ListItem In _lstBoxPages.Items
   Try
      item.Dispose()
   Catch
   End Try
   Next item
   End Sub

   Public Sub LogError(ByVal sLogText As String)
   LogText("*** ERROR *** ", _sNewlineTab & sLogText, Color.Red)
   End Sub

   Public Sub LogText(ByVal action As String, ByVal logTextParam As String)
   If Me.InvokeRequired Then
   Me.Invoke(New AddLog(AddressOf LogText), New Object() {action, logTextParam})
   Else
   AddAction(action)
   logWindow.RichTextBox.AppendText(logTextParam)
   logWindow.RichTextBox.AppendText(Constants.vbCrLf)
   logWindow.RichTextBox.ScrollToCaret()
   End If
   End Sub

   Public Sub LogText(ByVal sAction As String, ByVal sLogText As String, ByVal sActionColor As Color)
   If Me.InvokeRequired Then
   Me.Invoke(New AddLogColor(AddressOf LogText), New Object() {sAction, sLogText, sActionColor})
   Else
   AddAction(sAction, sActionColor)
   logWindow.RichTextBox.AppendText(sLogText)
   logWindow.RichTextBox.AppendText(_sNewline)
   TextBoxTraceListener.SendMessage(logWindow.RichTextBox.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0)
   End If
   End Sub

   Private Sub AddAction(ByVal sAction As String, ByVal color As Color)
   Dim oldColor As System.Drawing.Color = logWindow.RichTextBox.SelectionColor

   logWindow.RichTextBox.SelectionLength = 0
   logWindow.RichTextBox.SelectionStart = logWindow.RichTextBox.Text.Length
   logWindow.RichTextBox.SelectionColor = color
   logWindow.RichTextBox.SelectionFont = New Font(logWindow.RichTextBox.SelectionFont, FontStyle.Bold)
   logWindow.RichTextBox.AppendText(sAction & ": ")
   logWindow.RichTextBox.SelectionColor = oldColor
   End Sub

   Private Sub AddAction(ByVal action As String)
   Dim oldColor As System.Drawing.Color = logWindow.RichTextBox.SelectionColor
   If action = "" Then
   Return
   End If
   logWindow.RichTextBox.SelectionLength = 0
   logWindow.RichTextBox.SelectionStart = logWindow.RichTextBox.Text.Length
   logWindow.RichTextBox.SelectionColor = Color.Blue
   logWindow.RichTextBox.SelectionFont = New Font(logWindow.RichTextBox.SelectionFont, FontStyle.Bold)
   logWindow.RichTextBox.AppendText(action & ": ")

   logWindow.RichTextBox.SelectionColor = oldColor
   End Sub

   Public Delegate Sub StartUpdateDelegate(ByVal lv As DataGridView)
   Private Sub StartUpdate(ByVal dg As DataGridView)
   If InvokeRequired Then
   Invoke(New StartUpdateDelegate(AddressOf StartUpdate), dg)
   Else
   dg.Rows.Clear()
   End If
   End Sub

   Private Sub SetServersComboBox(ByVal bSelectDefault As Boolean)
   _cbSCPServers.Items.Clear()
   _cbMWLServers.Items.Clear()
   _cbStoreServers.Items.Clear()

   Dim listParam As MyServer()
   Dim defaultserver As Integer = 0

   listParam = _mySettings._settings.QuerySCPServers.serverList
   defaultserver = _mySettings._settings.DefaultSCPServer

   If listParam.Length = 0 Then
   _tbQuerySCPList.Enabled = False
   Else
   _tbQuerySCPList.Enabled = True
   For Each server As MyServer In listParam
      _cbSCPServers.Items.Add(server)
   Next server
   If bSelectDefault Then
      If defaultserver < listParam.Length Then
      _cbSCPServers.SelectedIndex = defaultserver
      Else
      _cbSCPServers.SelectedIndex = 0
      End If
   End If
   End If

   listParam = _mySettings._settings.StoreServers.serverList
   defaultserver = _mySettings._settings.DefaultStoreServer

   If listParam.Length = 0 Then
   _toolBtnStoreToPacs.Enabled = False
   _miStoreToPACS.Enabled = False
   _grpStoreServers.Enabled = False

   Else
   _miStoreToPACS.Enabled = True
   _grpStoreServers.Enabled = True
   UpdateToolBarState()
   For Each server As MyServer In listParam
      _cbStoreServers.Items.Add(server)
   Next server
   If bSelectDefault Then
      If defaultserver < listParam.Length Then
      _cbStoreServers.SelectedIndex = defaultserver
      Else
      _cbStoreServers.SelectedIndex = 0
      End If
   End If
   End If


   listParam = _mySettings._settings.QueryMWLServers.serverList
   defaultserver = _mySettings._settings.DefaultMWLServer

   If listParam.Length = 0 Then
   _tbQueryMWList.Enabled = False
   Else
   _tbQueryMWList.Enabled = True
   For Each server As MyServer In listParam
      _cbMWLServers.Items.Add(server)
   Next server
   If bSelectDefault Then
      If defaultserver < listParam.Length Then
      _cbMWLServers.SelectedIndex = defaultserver
      Else
      _cbMWLServers.SelectedIndex = 0
      End If
   End If
   End If
   End Sub

   Private Sub LoadSettings()
   Try
   ' Settings are stored at:
   ' %USERPROFILE%\Local Settings\Application Data\<Company Name>\<appdomainname>_<eid>_<hash>\<verison>\user.config
   _mySettings.Load()
   Catch ex As Exception
   System.Diagnostics.Debug.Assert(False, ex.Message)
   End Try
   End Sub

   Private Sub LoadRasterImage(ByVal strFileName As String)
   Dim bTopMost As Boolean = logWindow.TopMost
   Dim rImg As RasterImage = Nothing
   Try
   EnableItems(False, "Opening Image Files Please Wait...", "Cancel")
   Dim strFile As String = strFileName
   strLastLocation = strFile
   rImg = _codec.Load(strFile)

   Dim command As GrayscaleCommand = New GrayscaleCommand(8)
   If rImg.IsGray AndAlso rImg.BitsPerPixel <> 8 Then
      command.Run(rImg)
   End If

   Dim imagecollection As ListImageBox.ImageCollection = New ListImageBox.ImageCollection(Path.GetFileName(strFile))
   Dim page As Page = New Page()
   Dim i As Integer = 1
   Do While i <= rImg.PageCount
      Dim strTemp As String = Nothing
      rImg.Page = i

      page = New Page()
      strTemp = Path.GetTempFileName()
      Dim iBPP As Integer = rImg.BitsPerPixel
      If iBPP < 8 Then
      iBPP = 8
      End If
      Dim rTempRaster As RasterImage = rImg.Clone()
      _codec.Save(rTempRaster, strTemp, RasterImageFormat.Tif, iBPP)
      rTempRaster.Dispose()
      page.FilePath = strTemp
      page.DeleteOnDispose = True
      imagecollection.Images.Add(New ListImageBox.ImageItem(_codec.Load(strTemp), imagecollection, page))
      Application.DoEvents()
      If bCancelOperation Then
      Exit Do
      End If
    i += 1
   Loop
   rImg.Dispose()
   _lstBoxPages.AddImageCollection(imagecollection)
   Catch ex As System.Exception
   If Not rImg Is Nothing Then
      rImg.Dispose()
   End If

   ShowErrorMessage(ex)
   End Try
   EnableItems(True, "", "")
   logWindow.TopMost = bTopMost
   End Sub

#End Region

#Region "Dicom Methods"

   Private Sub LoadDataSet(ByVal strFileName As String)
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   If (Not File.Exists(strFileName)) Then
   MessageBox.Show("The selected file does not exist", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   Return
   End If
   Try
   _btnTransferLoadedPatient.Enabled = False
    _btnTransferLoadedStudies.Enabled = False

   Dim dicom As DicomDataSet = New DicomDataSet()

   If Path.GetExtension(strFileName) = ".xml" Then
      DicomExtensions.LoadXml(dicom, strFileName, DicomDataSetLoadXmlFlags.None, Nothing, Nothing)
   Else
      dicom.Load(strFileName, DicomDataSetLoadFlags.None)
   End If

   ClearTag(dicom, DicomTag.PixelData)
   ClearTag(dicom, DicomTag.EncapsulatedDocument)

   Dim dElement As DicomElement
   Dim item As ListViewItem = Nothing

   Dim val As String = ""

   For Each dTag As Long In DICOMPatientInfo
      dElement = dicom.FindFirstElement(Nothing, dTag, True)
      val = ""
      If Not dElement Is Nothing Then
      val = dicom.GetValue(Of String)(dElement, Nothing)
      End If

      If item Is Nothing Then
      item = _lstDSPatient.Items.Add(val)
      Else
      item.SubItems.Add(val)
      End If
   Next dTag
   item.Tag = dicom
   item.Selected = True
   'Series
   Catch
    MessageBox.Show("The selected file is not a valid dicom file", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   End Try
   logWindow.TopMost = bTopMost
   End Sub

	  Private Sub SetElements(ByVal dicomDestination As DicomDataSet, ByVal elements() As DicomElement, ByVal dicomSource As DicomDataSet)
         For Each item As DicomElement In elements
            If item.Length = 0 Then
               Continue For
            End If

            Dim element As DicomElement
            element = dicomDestination.FindFirstElement(Nothing, item.Tag, True)
            If element Is Nothing Then
               element = dicomDestination.InsertElement(Nothing, False, item.Tag, item.VR, False, 0)
            End If
            Select Case item.VR
               Case DicomVRType.DA
                  dicomDestination.SetDateValue(element, dicomSource.GetDateValue(item, 0, 1))
               Case DicomVRType.TM
                  dicomDestination.SetTimeValue(element, dicomSource.GetTimeValue(item, 0, 1))
               Case Else
                  Dim ba() As Byte = dicomSource.GetBinaryValue(item, CInt(Fix(item.Length)))
                  dicomDestination.FreeElementValue(element)
                  Dim ret As Boolean = dicomDestination.SetBinaryValue(element, ba, CInt(Fix(ba.Length)))
            End Select
         Next item
         _pgDicomInfo.DataSet = dicomDestination
      End Sub

   Private Function SaveDicom(ByVal dicom As DicomDataSet, ByVal strSaveFile As String) As List(Of String)
   Try

      Dim value() As Byte = {&H0, &H1}
      dicom.InsertElementAndSetValue(DicomTag.FileMetaInformationVersion, value)
      dicom.InsertElementAndSetValue(DicomTag.MediaStorageSOPClassUID, dicom.GetValue(Of String)(DicomTag.SOPClassUID, String.Empty))
      dicom.InsertElementAndSetValue(DicomTag.MediaStorageSOPInstanceUID, dicom.GetValue(Of String)(DicomTag.SOPInstanceUID, String.Empty))
      dicom.InsertElementAndSetValue(DicomTag.ImplementationClassUID, "1.2.840.114257.1123456")
      dicom.InsertElementAndSetValue(DicomTag.ImplementationVersionName, "LEADPRINTTOPACS")

      Dim saved As List(Of String) = New List(Of String)()
      Dim bit As Integer = 0
      If ClassTypes(_cmbSopClasses.SelectedIndex) = DicomClassType.EncapsulatedPdfStorage Then
      Dim documentFormat As DocumentFormat = documentFormat.User
      Dim documentOptions As DocumentOptions = Nothing
      Dim PdfdocumentOptions As PdfDocumentOptions = New PdfDocumentOptions()
      Dim fileName As String
      fileName = Path.GetTempFileName()
      documentFormat = documentFormat.Pdf
      documentOptions = New PdfDocumentOptions()
      CType(documentOptions, PdfDocumentOptions).DocumentType = PdfDocumentType.Pdf
      CType(documentOptions, PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto
      documentOptions.PageRestriction = DocumentPageRestriction.Relaxed
      Dim documentWriter As DocumentWriter = New DocumentWriter()
      documentWriter.SetOptions(documentFormat, documentOptions)
      documentWriter.BeginDocument(fileName, documentFormat)

      For Each item As ListImageBox.ListItem In _lstBoxPages.CheckedItems
         Dim documentPage As DocumentWriterEmfPage = New DocumentWriterEmfPage()
         If item.ImageItem.Tag.GetType() Is GetType(PrintPage) Then
            documentPage.EmfHandle = (TryCast(item.ImageItem.Tag, PrintPage)).MetaFile
         Else
            Dim rI As RasterImage = _codec.Load((TryCast(item.ImageItem.Tag, IPrintToPACSFile)).FileLocation())
            documentPage.EmfHandle = Leadtools.Drawing.RasterImageConverter.ChangeToEmf(rI)
            rI.Dispose()
         End If
         documentWriter.AddPage(documentPage)
         Application.DoEvents()
         If bCancelOperation Then
            Exit For
         End If
      Next item

      documentWriter.EndDocument()
      SetIncapsualtedDoc(dicom, fileName)
      File.Delete(fileName)
      saved.Add(strSaveFile)
      dicom.Save(strSaveFile, DicomDataSetSaveFlags.MetaHeaderPresent)

      'Delete Element
      ClearTag(dicom, DicomTag.EncapsulatedDocument)
      ClearTag(dicom, DicomTag.HL7InstanceIdentifier)
      ClearTag(dicom, DicomTag.ListOfMIMETypes)
      ClearTag(dicom, DicomTag.VerificationFlag)

      Dim dElement As DicomElement = _pgDicomInfo.DataSet.FindFirstElement(Nothing, DicomTag.MIMETypeOfEncapsulatedDocument, False)
      If Not dElement Is Nothing Then
         _pgDicomInfo.DataSet.SetValue(dElement, "PDF")
      End If
      End If

      If ClassTypes(_cmbSopClasses.SelectedIndex) = DicomClassType.SCImageStorage Then
      'Pixel Data
      Dim i As Integer = 0
      For Each item As ListImageBox.ListItem In _lstBoxPages.CheckedItems
         i += 1

         Dim dInstance As DicomElement = dicom.FindFirstElement(Nothing, DicomTag.InstanceNumber, True)
         If dInstance Is Nothing Then
         dInstance = dicom.InsertElement(Nothing, False, DicomTag.InstanceNumber, DicomVRType.OW, False, 0)
         End If
         dicom.SetValue(dInstance, i)

         Dim dPixel As DicomElement = dicom.FindFirstElement(Nothing, DicomTag.PixelData, True)
         If dPixel Is Nothing Then
         dPixel = dicom.InsertElement(Nothing, False, DicomTag.PixelData, DicomVRType.OW, False, 0)
         Else
         dicom.DeleteElement(dPixel)
         dPixel = dicom.InsertElement(Nothing, False, DicomTag.PixelData, DicomVRType.OW, False, 0)
         End If

         Dim rI As RasterImage = Nothing
         If rI Is Nothing Then
         rI = _codec.Load((TryCast(item.ImageItem.Tag, IPrintToPACSFile)).FileLocation())
         End If

         Dim imagePhotoMetric As DicomImagePhotometricInterpretationType = DicomImagePhotometricInterpretationType.Rgb
         If rI.IsGray Then
         bit = 8
         imagePhotoMetric = DicomImagePhotometricInterpretationType.Monochrome2
         If rI.BitsPerPixel = 12 OrElse rI.BitsPerPixel = 16 Then
         Dim grayCommand As GrayscaleCommand = New GrayscaleCommand(bit)
         grayCommand.Run(rI)
         End If
         Else
         bit = 24
         Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand()
         colorRes.BitsPerPixel = bit
         colorRes.Order = RasterByteOrder.Rgb
         colorRes.Mode = ColorResolutionCommandMode.InPlace
         colorRes.Run(rI)
         End If

         dicom.SetImage(dPixel, rI, _mySettings._settings.secondaryCaptureCompression, imagePhotoMetric, bit, 2, DicomSetImageFlags.AutoSetVoiLut)
         rI.Dispose()

         GenerateUidTag(dicom, DicomTag.SOPInstanceUID)

         Dim strFile As String = Path.GetDirectoryName(strSaveFile) & "\" & Path.GetFileNameWithoutExtension(strSaveFile) & "_" & i.ToString() + Path.GetExtension(strSaveFile)
         saved.Add(strFile)
         dicom.Save(strFile, DicomDataSetSaveFlags.MetaHeaderPresent)
         Application.DoEvents()
         If bCancelOperation Then
         Exit For
         End If
      Next item
      ClearTag(dicom, DicomTag.PixelData)
      ClearTag(dicom, DicomTag.WindowCenter)
      ClearTag(dicom, DicomTag.WindowWidth)
      Dim dInstElement As DicomElement = dicom.FindFirstElement(Nothing, DicomTag.InstanceNumber, True)
      If dInstElement Is Nothing Then
         dInstElement = dicom.InsertElement(Nothing, False, DicomTag.InstanceNumber, DicomVRType.OW, False, 0)
      End If
      dicom.SetValue(dInstElement, "1")

      End If

      If ClassTypes(_cmbSopClasses.SelectedIndex) = DicomClassType.SCMultiFrameTrueColorImageStorage OrElse ClassTypes(_cmbSopClasses.SelectedIndex) = DicomClassType.SCMultiFrameGrayscaleByteImageStorage Then

      'Pixel Data
      Dim dPixel As DicomElement = dicom.FindFirstElement(Nothing, DicomTag.PixelData, True)
      If dPixel Is Nothing Then
         dPixel = dicom.InsertElement(Nothing, False, DicomTag.PixelData, DicomVRType.OW, False, 0)
      End If

      Dim dPageVector As DicomElement = dicom.FindFirstElement(Nothing, DicomTag.PageNumberVector, True)

      Dim rI As RasterImage = Nothing

      Dim i As Integer = 1
      Dim intArray As List(Of Integer) = New List(Of Integer)()

      Dim compression As DicomImageCompressionType = DicomImageCompressionType.None
      Dim imagephotemetric As DicomImagePhotometricInterpretationType = DicomImagePhotometricInterpretationType.Rgb
      Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand()
      If ClassTypes(_cmbSopClasses.SelectedIndex) = DicomClassType.SCMultiFrameTrueColorImageStorage Then
         compression = _mySettings._settings.secondaryCaptureColorCompression
         imagephotemetric = DicomImagePhotometricInterpretationType.Rgb
         bit = 24
         colorRes.BitsPerPixel = bit
         colorRes.Order = RasterByteOrder.Bgr
         colorRes.Mode = ColorResolutionCommandMode.InPlace
      Else
         compression = _mySettings._settings.secondaryCaptureGrayCompression
         imagephotemetric = DicomImagePhotometricInterpretationType.Monochrome2
         bit = 8
         colorRes.BitsPerPixel = bit
         colorRes.Order = RasterByteOrder.Gray
         colorRes.Mode = ColorResolutionCommandMode.InPlace
      End If
      For Each item As ListImageBox.ListItem In _lstBoxPages.CheckedItems
         intArray.Add(i)
         i += 1
         If rI Is Nothing Then
         rI = _codec.Load((TryCast(item.ImageItem.Tag, IPrintToPACSFile)).FileLocation())
         colorRes.Run(rI)
         Continue For
         End If
         Dim rasterimage As RasterImage = _codec.Load((TryCast(item.ImageItem.Tag, IPrintToPACSFile)).FileLocation())
         colorRes.Run(rasterimage)
         rI.AddPage(rasterimage)
         Application.DoEvents()
         If bCancelOperation Then
         Exit For
         End If
      Next item

      Dim rImg As RasterImage = Nothing
      rI.Page = 1
      Dim iMaxWidth As Integer = rI.Width, iMaxHeight As Integer = rI.Height
      Dim iPage As Integer
      iPage = 1
      Do While iPage <= rI.PageCount
         rI.Page = iPage
         rImg = rI
         If rImg.Width > iMaxWidth Then
         iMaxWidth = rImg.Width
         End If

         If rImg.Height > iMaxHeight Then
         iMaxHeight = rImg.Height
         End If
       iPage += 1
      Loop

      Dim rImgNew As RasterImage = Nothing
      Dim lstRaster As List(Of RasterImage) = New List(Of RasterImage)()
      iPage = 1
      Do While iPage <= rI.PageCount
         rI.Page = iPage
         rImg = rI
         If rImg.ImageSize.Width < iMaxWidth OrElse rImg.ImageSize.Height < iMaxHeight Then
         rImgNew = New RasterImage(RasterMemoryFlags.Conventional, iMaxWidth, iMaxHeight, bit, RasterByteOrder.Bgr, rImg.ViewPerspective, rImg.GetPalette(), IntPtr.Zero, 0)
         Dim fillCommand As FillCommand = New FillCommand()
         fillCommand.Color = RasterColorConverter.FromColor(Color.White)
         fillCommand.Run(rImgNew)
         Dim combine As CombineCommand = New CombineCommand()
         Dim xStart, yStart As Integer
         xStart = Convert.ToInt32(Math.Abs(rImgNew.Width - rImg.Width) / 2)
         yStart = Convert.ToInt32(Math.Abs(rImgNew.Height - rImg.Height) / 2)
         combine.DestinationRectangle = New LeadRect(xStart, yStart, rImg.Width, rImg.Height)
         combine.SourcePoint = New LeadPoint(0, 0)
         combine.SourceImage = rImg
         combine.Flags = CombineCommandFlags.OperationAdd Or CombineCommandFlags.Destination0
         combine.Run(rImgNew)
         lstRaster.Add(rImgNew.Clone())
         Else
         lstRaster.Add(rImg.Clone())
         End If
       iPage += 1
      Loop
      rI.Dispose()
      rI = Nothing
      For Each rasterimage As RasterImage In lstRaster
         If rI Is Nothing Then
         rI = rasterimage
         Else
         rI.InsertPage(rI.PageCount + 1, rasterimage)
         End If
      Next rasterimage

      saved.Add(strSaveFile)
      dicom.SetIntValue(dPageVector, intArray.ToArray(), intArray.Count)
      dicom.SetImages(dPixel, rI, compression, imagephotemetric, bit, 2, DicomSetImageFlags.AutoSetVoiLut)
      dicom.Save(strSaveFile, DicomDataSetSaveFlags.MetaHeaderPresent)
      rI.Dispose()
      'Delete Element
      ClearTag(dicom, DicomTag.PixelData)
      ClearTag(dicom, DicomTag.WindowCenter)
      ClearTag(dicom, DicomTag.WindowWidth)
      ClearTag(dicom, DicomTag.RescaleIntercept)
      ClearTag(dicom, DicomTag.RescaleSlope)
      ClearTag(dicom, DicomTag.RescaleType)
      ClearTag(dicom, DicomTag.PageNumberVector)
      End If
      GenerateUidTag(dicom, DicomTag.SeriesInstanceUID)
      GenerateUidTag(dicom, DicomTag.SOPInstanceUID)
      _pgDicomInfo.DataSet = dicom
      Return saved
   Finally
      ClearTag(dicom, DicomTag.FileMetaInformationVersion)
      ClearTag(dicom, DicomTag.MediaStorageSOPClassUID)
      ClearTag(dicom, DicomTag.MediaStorageSOPInstanceUID)
      ClearTag(dicom, DicomTag.ImplementationClassUID)
      ClearTag(dicom, DicomTag.ImplementationVersionName)
   End Try
   End Function

   Private Sub ClearTag(ByVal dicom As DicomDataSet, ByVal tag As Long)
   Dim dElement As DicomElement = dicom.FindFirstElement(Nothing, tag, True)
   If Not dElement Is Nothing Then
   dicom.DeleteElement(dElement)
   End If
   End Sub

   Private Sub SetIncapsualtedDoc(ByVal ds As DicomDataSet, ByVal sFileDocumentIn As String)
   Dim dElement As DicomElement
   Dim strDocumentTitle As String = "", strBurnedInAnnotation As String = "", strVerificationFlag As String = "", strInstanceNumber As String = "", strCodeSchemeDesignator As String = "", strCodeValue As String = "", strCodeMeaning As String = ""
   Dim contentTime As DicomTimeValue = New DicomTimeValue()
   Dim contentDate As DicomDateValue = New DicomDateValue()
   Dim acquistationTime As DicomDateTimeValue = New DicomDateTimeValue()

   dElement = ds.FindFirstElement(Nothing, DicomTag.InstanceNumber, True)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   strInstanceNumber = ds.GetValue(Of String)(dElement, "")
   End If

   dElement = ds.FindFirstElement(Nothing, DicomTag.AcquisitionDateTime, True)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   acquistationTime = ds.GetDateTimeValue(dElement, 0, 1)(0)
   End If

   dElement = ds.FindFirstElement(Nothing, DicomTag.DocumentTitle, True)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   strDocumentTitle = ds.GetStringValue(dElement, 0)
   End If

   dElement = ds.FindFirstElement(Nothing, DicomTag.ContentTime, True)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   contentTime = ds.GetTimeValue(dElement, 0, 1)(0)
   End If

   dElement = ds.FindFirstElement(Nothing, DicomTag.ContentDate, True)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   contentDate = ds.GetDateValue(dElement, 0, 1)(0)
   End If

   dElement = ds.FindFirstElement(Nothing, DicomTag.BurnedInAnnotation, True)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   strBurnedInAnnotation = ds.GetStringValue(dElement, 0)
   End If

   dElement = ds.FindFirstElement(Nothing, DicomTag.VerificationFlag, True)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   strVerificationFlag = ds.GetStringValue(dElement, 0)
   End If

   Dim dElementCNS As DicomElement = ds.FindFirstElement(Nothing, DicomTag.ConceptNameCodeSequence, True)
   If Not dElementCNS Is Nothing AndAlso dElementCNS.Length <> 0 Then
   strCodeMeaning = ds.GetStringValue(dElement, 0)
   End If

   dElement = ds.FindFirstElement(dElementCNS, DicomTag.CodeMeaning, False)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   strCodeMeaning = ds.GetStringValue(dElement, 0)
   End If

   dElement = ds.FindFirstElement(dElementCNS, DicomTag.CodeValue, False)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   strCodeValue = ds.GetValue(Of String)(dElement, "")
   End If

   dElement = ds.FindFirstElement(dElementCNS, DicomTag.CodingSchemeDesignator, False)
   If Not dElement Is Nothing AndAlso dElement.Length <> 0 Then
   strCodeSchemeDesignator = ds.GetStringValue(dElement, 0)
   End If

   dElement = ds.FindFirstElement(Nothing, DicomTag.EncapsulatedDocument, True)
   If dElement Is Nothing Then
   dElement = ds.InsertElement(Nothing, False, DicomTag.EncapsulatedDocument, DicomVRType.UN, False, 0)
   End If

   Dim child As Boolean = False
   Dim encapsulatedDocument As DicomEncapsulatedDocument = New DicomEncapsulatedDocument()
   encapsulatedDocument.Type = DicomEncapsulatedDocumentType.Pdf
   encapsulatedDocument.InstanceNumber = Integer.Parse(strInstanceNumber)
   encapsulatedDocument.ContentDate = contentDate

   encapsulatedDocument.ContentTime = contentTime

   encapsulatedDocument.AcquisitionDateTime = acquistationTime

   encapsulatedDocument.BurnedInAnnotation = strBurnedInAnnotation
   encapsulatedDocument.DocumentTitle = strDocumentTitle
   encapsulatedDocument.VerificationFlag = strVerificationFlag
   encapsulatedDocument.HL7InstanceIdentifier = String.Empty


   Dim sListOfMimeTypes As String() = New String() {"image/jpeg", "application/pdf"}
   encapsulatedDocument.SetListOfMimeTypes(sListOfMimeTypes)

   Dim conceptNameCodeSequence As DicomCodeSequenceItem = New DicomCodeSequenceItem()
   conceptNameCodeSequence.CodingSchemeDesignator = strCodeSchemeDesignator
   conceptNameCodeSequence.CodeValue = strCodeValue
   conceptNameCodeSequence.CodeMeaning = strCodeMeaning

   ds.SetEncapsulatedDocument(dElement, child, sFileDocumentIn, encapsulatedDocument, conceptNameCodeSequence)
   End Sub

	  Private Sub ResetModule(ByVal moduleType As DicomModuleType, ByVal dataset As DicomDataSet, ByVal bKeepOriginalElements As Boolean)
         If bKeepOriginalElements Then
            Dim [module] As DicomModule = dataset.FindModule(moduleType)
            If [module] Is Nothing Then
               Return
            End If

            Dim b() As Byte = {0}
            For Each item As DicomElement In [module].Elements
               If item.Length = 0 Then
                  Continue For
               End If

               Dim element As DicomElement = dataset.FindFirstElement(Nothing, item.Tag, True)
               If element IsNot Nothing Then
                  dataset.SetBinaryValue(element, b, 0)
               End If
            Next item
         Else
            dataset.DeleteModule(moduleType)
            dataset.InsertModule(moduleType, False)
         End If
      End Sub

   Private Sub InsertPatientInfo(ByVal ds As DicomDataSet, ByVal patient As Patient)
   Dim dElement As DicomElement
   If Not patient.Name Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientName, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientName, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, patient.Name.FullDicomEncoded)
   End If

   If Not patient.Id Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientID, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientID, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, patient.Id)
   End If

   If Not patient.Sex Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientSex, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientSex, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, patient.Sex)
   End If

   If Not patient.BirthDate Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.PatientBirthDate, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.PatientBirthDate, DicomVRType.UN, False, 0)
   End If
   ds.SetDateValue(dElement, New DateTime() {CDate(patient.BirthDate)})
   End If
   End Sub

   Private Sub InsertStudyInfo(ByVal ds As DicomDataSet, ByVal study As Study)
   Dim dElement As DicomElement
   If Not study.Id Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.StudyID, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.StudyID, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, study.Id)
   End If

   If Not study.AccessionNumber Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.AccessionNumber, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.AccessionNumber, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, study.AccessionNumber)
   End If

   If Not study.ReferringPhysiciansName Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.ReferringPhysicianName, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.ReferringPhysicianName, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, study.ReferringPhysiciansName.FullDicomEncoded)
   End If

   If Not study.Date Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.StudyDate, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.StudyDate, DicomVRType.UN, False, 0)
   End If
   ds.SetDateValue(dElement, New DateTime() {CDate(study.Date)})
   End If

   If Not study.Description Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.StudyDescription, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.StudyDescription, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, study.Description)
   End If

   If Not study.Time Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.StudyTime, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.StudyTime, DicomVRType.UN, False, 0)
   End If
   ds.SetTimeValue(dElement, New DateTime() {CDate(study.Time)})
   End If

   If Not study.InstanceUID Is Nothing Then
   dElement = ds.FindFirstElement(Nothing, DicomTag.StudyInstanceUID, True)
   If dElement Is Nothing Then
      dElement = ds.InsertElement(Nothing, False, DicomTag.StudyInstanceUID, DicomVRType.UN, False, 0)
   End If
   ds.SetValue(dElement, study.InstanceUID)
   End If
   End Sub

   Private Function DoSave(ByVal dicom As DicomDataSet, ByRef lstSaved As List(Of String), ByVal strSaveLocation As String, ByRef bSuccess As Boolean) As String
   Dim strMessage As String = ""
   If strMessage = "" Then
   Try
      lstSaved = SaveDicom(dicom, strSaveLocation)
      strMessage = "DICOM file was saved successfully" & Constants.vbLf
      bSuccess = lstSaved.Count > 0
      If lstSaved.Count > 0 Then
      For Each str As String In lstSaved
      strMessage &= "--> " & str & Constants.vbLf
      Next str
      End If
   Catch ex As Exception
      strMessage = "DICOM file was not saved successfully, Reason:" & Constants.vbLf + ex.Message
   End Try
   End If
   Return strMessage
   End Function

   Private Sub GetRequiredTags(ByVal dicom As DicomDataSet, ByVal lstRequired As List(Of String))
   Dim iod As DicomIod
   Dim iodTable As DicomIodTable = DicomIodTable.Instance
   Dim editable As DicomEditableObject = CType(_pgDicomInfo.SelectedObject, DicomEditableObject)
   Dim [module] As DicomModule
   Dim IODClass As DicomIod = DicomIodTable.Instance.FindClass(dicom.InformationClass)
   Dim i As Integer = 0
   Do While i < dicom.ModuleCount
   [module] = dicom.FindModuleByIndex(i)
   Dim j As Integer = 0
   Do While j < [module].Elements.Length
      Dim dElement As DicomElement = [module].Elements(j)
      If dElement.Length > 0 Then
      j += 1
      Continue Do
      End If

      iod = DicomIodTable.Instance.Find(IODClass, dElement.Tag, DicomIodType.Element, False)
      If Not ((Not iod Is Nothing) AndAlso (iod.Usage = DicomIodUsageType.Type1MandatoryElement) AndAlso (dElement.Length = 0) AndAlso (dElement.Length <> ELEMENT_LENGTH_MAX)) Then
      j += 1
      Continue Do
      End If

      If (Not lstRequired.Contains(iod.Name)) Then
      lstRequired.Add(iod.Name)
      End If

    j += 1
   Loop
    i += 1
   Loop
   End Sub

   Private Sub GenerateUidTag(ByVal dicom As DicomDataSet, ByVal UidTag As Long)
   Dim element As DicomElement
   element = dicom.FindFirstElement(Nothing, UidTag, True)
   If Not element Is Nothing Then
   dicom.SetValue(element, Utils.GenerateDicomUniqueIdentifier())
   End If

   _pgDicomInfo.DataSet = dicom
   End Sub

#End Region

#Region "FindQuery"

   Private Function GetQueryServer() As DicomScp
   Dim server As DicomScp
   server = New DicomScp()
   Dim s As MyServer = Nothing

   If _tbDicomInfo.SelectedTab Is _pageSCPQuery Then
   s = CType(_cbSCPServers.SelectedItem, MyServer)
   Else
   s = CType(_cbMWLServers.SelectedItem, MyServer)
   End If

   server.AETitle = s._sAE
   server.PeerAddress = IPAddress.Parse(s._sIP)
   server.Port = s._port
   server.Timeout = s._timeout
   Return server
   End Function

   Private Function LoadDatasetResource(ByVal name As String, <System.Runtime.InteropServices.Out()> ByRef handle As IntPtr) As DicomDataSet
   Dim ds As DicomDataSet = New DicomDataSet()
   Dim [assembly] As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
   Dim resourceNames As String() = [assembly].GetManifestResourceNames()

   handle = IntPtr.Zero
   For Each n As String In resourceNames
   If n.ToLower().Contains(name.ToLower()) Then
      Dim stream As Stream = [assembly].GetManifestResourceStream(n)
      Dim data As Byte() = New Byte(Convert.ToInt32(stream.Length - 1)) {}
      handle = Marshal.AllocHGlobal(Convert.ToInt32(stream.Length))

      stream.Read(data, 0, Convert.ToInt32(stream.Length))
      Marshal.Copy(data, 0, handle, Convert.ToInt32(stream.Length))
      ds.Load(handle, stream.Length, DicomDataSetFlags.None)
      Continue For
   End If
   Next n

   Return ds
   End Function

   Private Function DoSearch() As Boolean
   Dim bRet As Boolean = False
   Dim query As ModalityWorklistQuery = GetQueryParams()
   Dim server As DicomScp = GetQueryServer()

   Dim s As MyServer = Nothing
   If _tbDicomInfo.SelectedTab Is _pageSCPQuery Then
   s = CType(_cbSCPServers.SelectedItem, MyServer)
   Else
   s = CType(_cbMWLServers.SelectedItem, MyServer)
   End If

   Dim bSCPQueryEmpty As Boolean
   Dim bSWLQueryEmpty As Boolean
   Dim bPWLQueryEmpty As Boolean
   IsQueryEmpty(bSCPQueryEmpty, bSWLQueryEmpty, bPWLQueryEmpty)

   If (bSCPQueryEmpty AndAlso _tbDicomInfo.SelectedTab Is _pageSCPQuery) OrElse (bPWLQueryEmpty AndAlso _tbDicomInfo.SelectedTab Is _pageMWLQuery AndAlso _toolBtnPatient.Checked) OrElse (bSWLQueryEmpty AndAlso _tbDicomInfo.SelectedTab Is _pageMWLQuery AndAlso (Not _toolBtnPatient.Checked)) Then
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   Dim dlgRes As DialogResult = MessageBox.Show(Me, "The query parameters are empty the query will take long time." & Constants.vbLf & "Are you sure you want to continue?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
   logWindow.TopMost = bTopMost
   If dlgRes = DialogResult.No Then
      Return False
   End If
   End If
   EnableItems(False, "Query PACS Please Wait...", "")
   CreateCFindObject(s)
   AddHandler _find.MatchStudy, AddressOf _find_MatchPatient

   _find.AETitle = _mySettings._settings.clientAE
   _find.HostPort = _mySettings._settings.clientPort
   Dim bScp As Boolean = _tbDicomInfo.SelectedTab Is _pageSCPQuery

   If bScp Then
   _btnTransferSCPPatient.Enabled = _btnTransferSCPStudies.Enabled = False
   _lstSCPPatient.Items.Clear()
   _lstSCPStudies.Items.Clear()
   Else
   _lstMWLItems.Items.Clear()
   _btnTransferMWL.Enabled = False
   End If
   Dim sThread As SearchThreadedClass = New SearchThreadedClass
   sThread.mainfrm = Me
   sThread.bScp = bScp
   sThread.query = query
   sThread.server = server
   Dim t As Thread = New Thread(AddressOf sThread.DoSearchThreaded)
   t.Start()
   Do While t.IsAlive
   Application.DoEvents()
   Loop
   bRet = True
   Return bRet
   End Function

   Private Sub IsQueryEmpty(<System.Runtime.InteropServices.Out()> ByRef bSCPQueryEmpty As Boolean, <System.Runtime.InteropServices.Out()> ByRef bSWLQueryEmpty As Boolean, <System.Runtime.InteropServices.Out()> ByRef bPWLQueryEmpty As Boolean)
   Dim newFindQ As DicomFindQuery = New DicomFindQuery()
   bSCPQueryEmpty = Convert.ToBoolean((_findQuery.InstanceNumber.ToString = newFindQ.InstanceNumber.ToString) And _
 (_findQuery.Modalities = newFindQ.Modalities) And _
 (_findQuery.Modality = newFindQ.Modality) And _
 (_findQuery.PatientId = newFindQ.PatientId) And _
(_findQuery.PatientName = newFindQ.PatientName) And _
(_findQuery.PerfProcStepStartDate.ToString = newFindQ.PerfProcStepStartDate.ToString) And _
 (_findQuery.PerfProcStepStartTime.ToString() = newFindQ.PerfProcStepStartTime.ToString()) And _
(_findQuery.AccessionNumber = newFindQ.AccessionNumber) And _
(_findQuery.QueryLevel = newFindQ.QueryLevel) And _
(_findQuery.ReferringPhysiciansName = newFindQ.ReferringPhysiciansName) And _
 (_findQuery.RequestedProcId = newFindQ.RequestedProcId) And _
 (_findQuery.SchedProcStepId = newFindQ.SchedProcStepId) And _
 (_findQuery.SeriesInstanceUID = newFindQ.SeriesInstanceUID) And _
 (_findQuery.SeriesNumber.ToString = newFindQ.SeriesNumber.ToString) And _
 (_findQuery.SOPInstanceUID = newFindQ.SOPInstanceUID) And _
 (_findQuery.StudyDate.ToString() = newFindQ.StudyDate.ToString()) And _
 (_findQuery.StudyId = newFindQ.StudyId) And _
 (_findQuery.StudyInstanceUID = newFindQ.StudyInstanceUID) And _
 (_findQuery.StudyTime.ToString() = newFindQ.StudyTime.ToString()))

   Dim newBroadQuery As BroadBasedQuery = New BroadBasedQuery()
         bSWLQueryEmpty = _
            (_bbQuery.Modality = newBroadQuery.Modality) And _
            (_bbQuery.ScheduledProcedureStepStartDate.Equals(newBroadQuery.ScheduledProcedureStepStartDate)) And _
            (_bbQuery.ScheduledStationAeTitle = newBroadQuery.ScheduledStationAeTitle)

   Dim newPatientQuery As PatientBasedQuery = New PatientBasedQuery()
   bPWLQueryEmpty = (_pbQuery.PatientId = newPatientQuery.PatientId) And (_pbQuery.PatientName.ToString() = newPatientQuery.PatientName.ToString()) And (_pbQuery.AccessionNumber = newPatientQuery.AccessionNumber) And (_pbQuery.RequestedProcedureId = newPatientQuery.RequestedProcedureId)
   End Sub

   Public Delegate Sub CreateCFind(ByVal server As MyServer)
   Private Sub CreateCFindObject(ByVal server As MyServer)
   If Me.InvokeRequired Then
   Invoke(New CreateCFind(AddressOf CreateCFindObject), New Object() {server})
   Else
   If Not _find Is Nothing Then
      _find.Dispose()
   End If
            If server._useTls Then
#If Not LEADTOOLS_V20_OR_LATER Then
               _find = New MyQueryRetrieveScu(Me, _mySettings._settings.TempDir, DicomNetSecurityeMode.Tls, Nothing)
#Else
               _find = New MyQueryRetrieveScu(Me, _mySettings._settings.TempDir, DicomNetSecurityMode.Tls, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
            Else
               _find = New MyQueryRetrieveScu(Me)
            End If

            _find.ImplementationClass = _sConfigurationImplementationClass
            _find.ProtocolVersion = _sConfigurationProtocolversion
            _find.ImplementationVersionName = _sConfigurationImplementationVersionName
            _find.AETitle = _mySettings._settings.clientAE
            _find.HostPort = 1000

            AddHandler _find.BeforeConnect, AddressOf _find_BeforeConnect
            AddHandler _find.AfterConnect, AddressOf _find_AfterConnect
            AddHandler _find.AfterSecureLinkReady, AddressOf _find_AfterSecureLinkReady
            AddHandler _find.BeforeAssociateRequest, AddressOf _find_BeforeAssociateRequest
            AddHandler _find.AfterAssociateRequest, AddressOf _find_AfterAssociateRequest
            AddHandler _find.BeforeCFind, AddressOf _find_BeforeCFind
            AddHandler _find.AfterCFind, AddressOf _find_AfterCFind

            AddHandler _find.BeforeCMove, AddressOf _find_BeforeCMove
            AddHandler _find.AfterCMove, AddressOf _find_AfterCMove

            AddHandler _find.PrivateKeyPassword, AddressOf _find_PrivateKeyPassword

            If server._useTls Then
               Try
                  _find.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha)
                  If _mySettings._settings.privateKey.Length > 0 Then
                     _find.SetTlsClientCertificate(_mySettings._settings.clientCertificate, DicomTlsCertificateType.Pem, _mySettings._settings.privateKey)
                  Else
                     _find.SetTlsClientCertificate(_mySettings._settings.clientCertificate, DicomTlsCertificateType.Pem, Nothing)
                  End If
               Catch ex As Exception
                  LogError(ex.Message)
               End Try
               _find._mainForm = Me
            End If

            If _mySettings._settings.logLowLevel Then
               If _tracer Is Nothing Then
                  _tracer = New TextBoxTraceListener(logWindow.RichTextBox)
                  Trace.Listeners.Add(_tracer)
               End If
            Else
               If Not _tracer Is Nothing Then
                  Trace.Listeners.Remove(_tracer)
                  _tracer = Nothing
               End If
            End If
            _find.DebugLogFilename = String.Empty
            _find.EnableDebugLog = True
         End If
      End Sub

      Private Sub _find_BeforeConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs)
         LogText("Before Connect", e.Scp.ToString())

      End Sub

      Private Sub _find_AfterConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterConnectEventArgs)
         Dim message As String
         If e.Error = DicomExceptionCode.Success Then
            message = _sNewlineTab & "Connection Successful"
         Else
            message = _sNewlineTab & "Connection failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
         End If

         LogText("After Connect", message)
      End Sub

      Private Sub _find_BeforeAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs)
         LogText("Before Associate Request", e.Associate.ToString())
      End Sub

      Private Sub _find_AfterAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs)
         Dim message As String
         If e.Rejected Then
            message = _sNewlineTab & "Association Rejected" & _sNewlineTab & "Result: " & e.Result.ToString() & _sNewlineTab & "Reason: " & e.Reason.ToString() & _sNewlineTab & "Source: " & e.Source.ToString()
         Else
            message = _sNewlineTab & "Association Accepted" & e.Associate.ToString()
         End If
         LogText("After Associate Request", message)
      End Sub

      Private Sub _find_BeforeCFind(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeCFindEventArgs)
         Dim message As String = _sNewlineTab & "QueryLevel:" & Constants.vbTab + e.QueryLevel.ToString() & _sNewlineTab & "Priority:" & Constants.vbTab + e.Priority.ToString()

         LogText("Before CFind", message)

         'EnableCancel(true);
      End Sub

      Private Sub _find_AfterCFind(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterCFindEventArgs)
         Dim message As String
         If e.Status = DicomCommandStatusType.Success Then
            message = _sNewlineTab & "MatchCount:" & Constants.vbTab + e.MatchCount.ToString() & _sNewlineTab & "Status:" & Constants.vbTab + e.Status.ToString()
         Else
            message = _sNewlineTab & " CFind failed" & _sNewlineTab & "Status: " & e.Status.ToString()
         End If
         LogText("After CFind", message & _sNewlineTab & "****************************" & _sNewlineTab)
         'EnableCancel(false);
      End Sub

      Private Sub _find_MatchStudy(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.MatchEventArgs(Of Study))
         Dim message As String = _sNewlineTab & "QueryLevel: " & e.QueryLevel.ToString() & _sNewlineTab & "Availability:" & Constants.vbTab + e.Availability.ToString() & _sNewlineTab & "Patient:" & Constants.vbTab + e.Info.Patient.ToString() & _sNewlineTab & "RetrieveAETitle:" & Constants.vbTab + e.RetrieveAETitle.ToString()
         LogText("Study Patient Found Found", message)
         Try
            AddStudyItem(e)
         Catch
         End Try
      End Sub

      Private Sub _find_MatchPatient(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.MatchEventArgs(Of Study))
         Dim message As String = _sNewlineTab & "QueryLevel: " & e.QueryLevel.ToString() & _sNewlineTab & "Availability:" & Constants.vbTab + e.Availability.ToString() & _sNewlineTab & "Patient:" & Constants.vbTab + e.Info.Patient.ToString() & _sNewlineTab & "RetrieveAETitle:" & Constants.vbTab + e.RetrieveAETitle.ToString()
         LogText("Study Patient Found Found", message)
         Try
            AddPatientItem(e)
         Catch
         End Try
      End Sub

      Public Delegate Sub AddStudyItemDelegate(ByVal ds As MatchEventArgs(Of Study))
      Private Sub AddStudyItem(ByVal e As MatchEventArgs(Of Study))
         Dim item As ListViewItem

         If InvokeRequired Then
            Invoke(New AddStudyItemDelegate(AddressOf AddStudyItem), e)
         Else

            item = _lstSCPStudies.Items.Add(e.Info.Id)
            If Not e.Info.ReferringPhysiciansName Is Nothing Then
               item.SubItems.Add(e.Info.ReferringPhysiciansName.FullDicomEncoded)
            Else
               item.SubItems.Add("")
            End If
            item.SubItems.Add(e.Info.AccessionNumber)
            If e.Info.Date.HasValue Then
               item.SubItems.Add(e.Info.Date.ToString())
            Else
               item.SubItems.Add(String.Empty)
            End If
            If e.Info.Time.HasValue Then
               item.SubItems.Add(e.Info.Time.ToString())
            Else
               item.SubItems.Add(String.Empty)
            End If

            item.Tag = e.Info
         End If
      End Sub

      Public Delegate Sub AddPatientItemDelegate(ByVal ds As MatchEventArgs(Of Study))
      Private Sub AddPatientItem(ByVal e As MatchEventArgs(Of Study))
         Dim item As ListViewItem = Nothing

         If InvokeRequired Then
            Invoke(New AddStudyItemDelegate(AddressOf AddPatientItem), e)
         Else
            If e.Info.Patient Is Nothing Then
               Return
            End If

            'Check if the Patient already exist in _lstSCPPatient
            For Each lvi As ListViewItem In _lstSCPPatient.Items
               If lvi.SubItems(0).Text = e.Info.Patient.Name.FullDicomEncoded OrElse lvi.SubItems(1).Text = e.Info.Patient.Id Then
                  item = lvi
                  Exit For
               End If
            Next lvi

            If item Is Nothing Then
               item = _lstSCPPatient.Items.Add(e.Info.Patient.Name.FullDicomEncoded)
               item.SubItems.Add(e.Info.Patient.Id)
               item.SubItems.Add(e.Info.Patient.Sex)
               If e.Info.Patient.BirthDate.HasValue Then
                  item.SubItems.Add(e.Info.Patient.BirthDate.ToString())
               Else
                  item.SubItems.Add(String.Empty)
               End If
               item.Tag = New List(Of Study)()
            End If

            TryCast(item.Tag, List(Of Study)).Add(e.Info)
         End If
      End Sub

      Private Sub _find_BeforeCMove(ByVal sender As Object, ByVal e As BeforeCMoveEventArgs)
         Dim message As String = _sNewlineTab & "Priority:" & Constants.vbTab + e.Priority.ToString() + e.Scp.ToString() & _sNewlineTab & "Desination AE:" & Constants.vbTab + e.DestinationAETitle
         LogText("Before CMove", message)
         'EnableCancel(true);
         '         _moveCount = 0;
      End Sub

      Private Sub _find_AfterCMove(ByVal sender As Object, ByVal e As AfterCMoveEventArgs)
         Dim message As String
         If e.Status = DicomCommandStatusType.Success OrElse e.Status = DicomCommandStatusType.Pending OrElse e.Status = DicomCommandStatusType.Warning Then
            message = _sNewlineTab & "Status:" & Constants.vbTab + e.Status.ToString() & _sNewlineTab & "Completed:" & Constants.vbTab + e.Completed.ToString() & _sNewlineTab & "Warning:" & Constants.vbTab + e.Warning.ToString() & _sNewlineTab & "Failed:" & Constants.vbTab + e.Failed.ToString()
         Else
            message = _sNewlineTab & " CMove failed" & Constants.vbCrLf & Constants.vbTab & "Status: " & e.Status.ToString()
         End If
         LogText("After CMove", message)
         'if (e.Status != DicomCommandStatusType.Pending)
         'EnableCancel(false);
      End Sub

      Private Sub _find_AfterSecureLinkReady(ByVal sender As Object, ByVal e As AfterSecureLinkReadyEventArgs)
         Dim message As String
         If e.Error = DicomExceptionCode.Success Then
            message = _sNewlineTab & "Secure Link Ready"
         Else
            message = _sNewlineTab & "Secure Link Failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
         End If

         LogText("After Secure Link Ready", message)
      End Sub

      Private Sub _find_PrivateKeyPassword(ByVal sender As Object, ByVal e As PrivateKeyPasswordEventArgs)
         e.PrivateKeyPassword = _mySettings._settings.privateKeyPassword
      End Sub

      Private Function GetQueryParams() As ModalityWorklistQuery
         Dim query As New ModalityWorklistQuery()

         If _tbDicomInfo.SelectedTab Is _pageMWLQuery AndAlso _toolBtnPatient.Checked Then
            query.PatientName = _pbQuery.PatientName
            query.PatientId = _pbQuery.PatientId
            query.RequestedProcedureId = _pbQuery.RequestedProcedureId
            query.AccessionNumber = _pbQuery.AccessionNumber
         Else
            Dim bq As New BroadQuery()

            bq.ScheduledProcedureStepStartDate = _bbQuery.ScheduledProcedureStepStartDate

            bq.Modality = _bbQuery.Modality
            bq.ScheduledStationAeTitle = _bbQuery.ScheduledStationAeTitle
            query.Broad.Add(bq)
         End If
         Return query
      End Function

      Public Delegate Sub AddResultItemDelegate(ByVal result As ModalityWorklistResult)
      Private Sub AddResultItem(ByVal result As ModalityWorklistResult)
         Dim item As ListViewItem

         If InvokeRequired Then
            Invoke(New AddResultItemDelegate(AddressOf AddResultItem), result)
         Else
            item = _lstMWLItems.Items.Add(result.AccessionNumber)
            item.SubItems.Add(result.PatientId)
            item.SubItems.Add(result.PatientName.FullDicomEncoded)
            If result.PatientBirthDate.HasValue Then
               item.SubItems.Add(result.PatientBirthDate.Value.ToShortDateString())
            Else
               item.SubItems.Add(String.Empty)
            End If
            item.SubItems.Add(result.PatientSex)
            If Not result.ScheduledProcedureStepSequence Is Nothing AndAlso result.ScheduledProcedureStepSequence.Count > 0 Then
               If result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepStartDate.HasValue Then
                  item.SubItems.Add(result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepStartDate.Value.ToShortDateString())
               Else
                  item.SubItems.Add(String.Empty)
               End If
               item.SubItems.Add(result.ScheduledProcedureStepSequence(0).Modality)
               item.SubItems.Add(result.ScheduledProcedureStepSequence(0).ScheduledStationAeTitle)
               item.SubItems.Add(result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepDescription)
            End If
            item.SubItems.Add(result.RequestedProcedureId)

            item.Tag = result
         End If
      End Sub

      Private Sub FoundMatch(ByVal result As ModalityWorklistResult, ByVal ds As DicomDataSet)
         Dim message As String = _sNewlineTab & "Accession #:" & Constants.vbTab + Constants.vbTab & " " & result.AccessionNumber & _sNewlineTab & "Patient Name:" & Constants.vbTab + Constants.vbTab + result.PatientName.FullDicomEncoded & _sNewlineTab & "Scheduled Start Date:" & Constants.vbTab + result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepStartDate.Value.ToShortDateString()
         LogText("Worklist Item Found", message)

         If Not ds Is Nothing Then
            Dim data As DicomDataSet = New DicomDataSet()

            data.Copy(ds, Nothing, Nothing)
            result.Tag = data
         End If
         AddResultItem(result)
      End Sub

#End Region

#Region "StoreScu"
      Private Sub DoStore(ByVal dsFile As String, ByVal storeserver As MyServer)
         Dim sMsg As String = String.Empty
         Dim server As DicomScp = New DicomScp()
         server.AETitle = storeserver._sAE
         server.PeerAddress = IPAddress.Parse(storeserver._sIP)
         server.Port = storeserver._port
         server.Timeout = storeserver._timeout
         Dim s As MyServer = Nothing
         s = CType(_cbStoreServers.SelectedItem, MyServer)
         bStored = False

         CreateCStoreObject(s)
         _cstore.AETitle = _mySettings._settings.clientAE
         _cstore.HostPort = _mySettings._settings.clientPort

         Dim sThreaded As ThreadedClass = New ThreadedClass
         sThreaded.mainfrm = Me
         sThreaded.server = server
         sThreaded.dsfile = dsFile
         Dim t As Thread = New Thread(AddressOf sThreaded.DoStoreThreaded)

         t.Start()
         Do While t.IsAlive
            Application.DoEvents()
         Loop
      End Sub

      Public Delegate Sub ShowErrorMessageDelegate(ByVal ex As Exception)
      Private Sub ShowErrorMessage(ByVal ex As Exception)
         If InvokeRequired Then
            Invoke(New ShowErrorMessageDelegate(AddressOf ShowErrorMessage), ex)
         Else
            EnableItems(True, "", "")
            Dim bTopMost As Boolean = logWindow.TopMost
            logWindow.TopMost = False
            MessageBox.Show(Me, "Error Occurred: " & Constants.vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            logWindow.TopMost = bTopMost
         End If

      End Sub

      Private Sub _cstore_BeforeConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs)
         LogText("Before Connect", e.Scp.ToString())
         e.PrivateKeyPassword = _mySettings._settings.privateKeyPassword
      End Sub

      Private Sub _cstore_AfterConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterConnectEventArgs)
         Dim message As String
         If e.Error = DicomExceptionCode.Success Then
            message = _sNewlineTab & "Connection Successful"
         Else
            message = _sNewlineTab & "Connection Failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
         End If

         LogText("After Connect", message)
      End Sub

      Private Sub _cstore_AfterSecureLinkReady(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterSecureLinkReadyEventArgs)
         Dim message As String
         If e.Error = DicomExceptionCode.Success Then
            message = _sNewlineTab & "Secure Link Ready"
         Else
            message = _sNewlineTab & "Secure Link Failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
         End If

         LogText("After Secure Link Ready", message)
      End Sub

      Private Sub _cstore_BeforeAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs)
         LogText("Before Associate Request", e.Associate.ToString())
      End Sub

      Private Sub _cstore_AfterAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs)
         Dim message As String
         If e.Rejected Then
            message = _sNewlineTab & "Association Rejected" & _sNewlineTab & "Result: " & e.Result.ToString() & _sNewlineTab & "Reason: " & e.Reason.ToString() & _sNewlineTab & "Source: " & e.Source.ToString()
         Else
            message = _sNewlineTab & "Association Accepted" & e.Associate.ToString()
         End If
         LogText("After Associate Request", message)
      End Sub

      Private Sub _cstore_BeforeCStore(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeCStoreEventArgs)
         LogText("Before CStore", _sNewlineTab & "Current DataSet")
      End Sub

      Private Sub _cstore_AfterCStore(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterCStoreEventArgs)
         Dim message As String
         If e.Status = DicomCommandStatusType.Success Then
            message = _sNewlineTab & "Success" & _sNewlineTab & "Current DataSet"
            bStored = True
         Else
            message = _sNewlineTab & "CStore Failed" & _sNewlineTab & "Status: " & e.Status.ToString()
         End If
         LogText("After CStore", message)
      End Sub

      Private Sub CreateCStoreObject(ByVal server As MyServer)
         If Not _cstore Is Nothing Then
            _cstore.Dispose()
         End If

         If server._useTls Then
#If Not LEADTOOLS_V20_OR_LATER Then
            _cstore = New StoreScu(String.Empty, DicomNetSecurityeMode.Tls, Nothing)
#Else
            _cstore = New StoreScu(String.Empty, DicomNetSecurityMode.Tls, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
         Else
            _cstore = New StoreScu()
         End If

         _cstore.ImplementationClass = _sConfigurationImplementationClass
         _cstore.ImplementationVersionName = _sConfigurationImplementationVersionName
         _cstore.ProtocolVersion = _sConfigurationProtocolversion

         ' Subscribe to events for logging
         AddHandler _cstore.BeforeConnect, AddressOf _cstore_BeforeConnect
         AddHandler _cstore.AfterConnect, AddressOf _cstore_AfterConnect
         AddHandler _cstore.AfterSecureLinkReady, AddressOf _cstore_AfterSecureLinkReady
         AddHandler _cstore.BeforeAssociateRequest, AddressOf _cstore_BeforeAssociateRequest
         AddHandler _cstore.AfterAssociateRequest, AddressOf _cstore_AfterAssociateRequest
         AddHandler _cstore.BeforeCStore, AddressOf _cstore_BeforeCStore
         AddHandler _cstore.AfterCStore, AddressOf _cstore_AfterCStore

         AddHandler _cstore.PrivateKeyPassword, AddressOf _cstore_PrivateKeyPassword
         If server._useTls Then
            Try
               _cstore.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha)
               If _mySettings._settings.privateKey.Length > 0 Then
                  _cstore.SetTlsClientCertificate(_mySettings._settings.clientCertificate, DicomTlsCertificateType.Pem, _mySettings._settings.privateKey)
               Else
                  _cstore.SetTlsClientCertificate(_mySettings._settings.clientCertificate, DicomTlsCertificateType.Pem, Nothing)
               End If
            Catch ex As Exception
               LogError(ex.Message)
            End Try

         End If

         If _mySettings._settings.logLowLevel Then
            If _tracer Is Nothing Then
               _tracer = New TextBoxTraceListener(logWindow.RichTextBox)
               Trace.Listeners.Add(_tracer)
            End If
         Else
            If Not _tracer Is Nothing Then
               Trace.Listeners.Remove(_tracer)
               _tracer = Nothing
            End If
         End If

         _cstore.DebugLogFilename = String.Empty
         _cstore.EnableDebugLog = True
      End Sub

      Private Sub _cstore_PrivateKeyPassword(ByVal sender As Object, ByVal e As PrivateKeyPasswordEventArgs)
         e.PrivateKeyPassword = _mySettings._settings.privateKeyPassword
      End Sub

#End Region

Class ThreadedClass
Public server As DicomScp
Public dsfile As String
Public mainfrm As FrmMain
Public Sub DoStoreThreaded()
   Try
      mainfrm._cstore.Store(server, dsfile)
   Catch ex As Exception
      mainfrm.LogError(ex.Message)
      mainfrm.ShowErrorMessage(ex)
   End Try
End Sub
   Public Sub DeserializeThreaded()
  Try
      Dim binFormatter As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
      Dim fStream As FileStream = File.Open(dsfile, FileMode.Open)
      Dim lstLoaded As List(Of ListImageBox.ImageCollection)
      Dim obj As Object
      obj = binFormatter.Deserialize(fStream)
      lstLoaded = CType(obj, List(Of ListImageBox.ImageCollection))
      For iCol As Integer = lstLoaded.Count - 1 To 0 Step -1
      Dim imgCol As ListImageBox.ImageCollection = lstLoaded(iCol)
      For iImg As Integer = imgCol.Images.Count - 1 To 0 Step -1
      Dim item As ListImageBox.ImageItem = imgCol.Images(iImg)
      If item.Tag.GetType() Is GetType(PrintPage) Then
      Dim printpage As PrintPage = (TryCast(item.Tag, PrintPage))

      If File.Exists(printpage.FilePath) Then
         Dim img As Image = Image.FromFile(printpage.FilePath)
         Dim mt As Metafile = TryCast(img, Metafile)
         printpage.MetaFile = mt.GetHenhmetafile()
         mt.Dispose()
         item.Image = mainfrm._codec.Load(printpage.FilePath)
      End If
      End If
      If item.Tag.GetType() Is GetType(Page) Then
      Dim page As Page = TryCast(item.Tag, Page)

      If File.Exists(page.FilePath) Then
         item.Image = mainfrm._codec.Load(page.FilePath)
      End If
      End If

      If item.Image Is Nothing Then
      imgCol.Images.Remove(item)
      End If

      Application.DoEvents()
      If mainfrm.bCancelOperation Then
      Exit For
      End If
      Next iImg
      If imgCol.Images.Count = 0 Then
      lstLoaded.Remove(imgCol)
      End If
      Next iCol
      fStream.Close()

      For Each collection As ListImageBox.ImageCollection In lstLoaded
      mainfrm.AddImageCollectionThreaded(collection)
      Application.DoEvents()
      Next collection
   Catch
   End Try
   mainfrm.EnableItems(True, "", "")

   End Sub
End Class

Class SearchThreadedClass
Public server As DicomScp
Public mainfrm As FrmMain
Public bRet As Boolean
Public bScp As Boolean
Public query As ModalityWorklistQuery
Public Sub DoSearchThreaded()
Dim handle As IntPtr = IntPtr.Zero
   Try
      If bScp Then
      Dim fQuery As FindQuery = mainfrm._findQuery
      fQuery.Modalities.Clear()
      If mainfrm._findQuery.Modalities = "All" Then
      fQuery.Modalities.Add("")
      Else
      If mainfrm._findQuery.Modalities.Contains(",") Then
      Dim arrValue As String() = mainfrm._findQuery.Modalities.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
      fQuery.Modalities.AddRange(arrValue)
      Else
      fQuery.Modalities.Add(mainfrm._findQuery.Modalities)
      End If
      End If

      Using template As DicomDataSet = mainfrm.LoadDatasetResource("StudyRoot_Study_Level_IHE_C-Find.dcm", handle)
      mainfrm._find.Find(server, fQuery, False, template)
      If Not handle.Equals(IntPtr.Zero) Then
      Marshal.FreeHGlobal(handle)
      End If
      End Using
      Else
      Using template As DicomDataSet = mainfrm.LoadDatasetResource("MwlIheCFindScu.dcm", handle)
      mainfrm._find.Find(Of ModalityWorklistQuery, ModalityWorklistResult)(server, query, New DicomMatchDelegate(Of ModalityWorklistResult)(AddressOf mainfrm.FoundMatch))
      If Not handle.Equals(IntPtr.Zero) Then
      Marshal.FreeHGlobal(handle)
      End If
      End Using
      End If
   Catch ex As Exception
     mainfrm.LogError(ex.Message)
      mainfrm.ShowErrorMessage(ex)
      bRet = False
   End Try

End Sub
End Class

   End Class

   <Serializable()> _
   Friend Class PrintPage : Implements IDisposable, IPrintToPACSFile
   Private bSelected As Boolean = False
   Public Property Selected() As Boolean
   Get
    Return bSelected
   End Get
   Set(ByVal value As Boolean)
    bSelected = value
   End Set
   End Property

   Private _jobId As Integer
   Public ReadOnly Property JobId() As Integer
   Get
    Return _jobId
   End Get
   End Property

   Private _strRecognizedFilePath As String = ""
   Public Property RecognizedFilePath() As String
   Get
    Return _strRecognizedFilePath
   End Get
   Set(ByVal value As String)
    _strRecognizedFilePath = value
   End Set
   End Property

   Private _metaFile As IntPtr
   Public Property MetaFile() As IntPtr
   Get
    Return _metaFile
   End Get
   Set(ByVal value As IntPtr)
    _metaFile = value
   End Set
   End Property

   Private file As String = String.Empty
   Public Property FilePath() As String
   Get
    Return file
   End Get
   Set(ByVal value As String)
    file = value
   End Set
   End Property

   Public Sub New(ByVal jobIdParam As Integer)
   _jobId = jobIdParam
   End Sub

   Protected Overrides Sub Finalize()
   'if (File.Exists(tempFile))
   '   File.Delete(tempFile);


   'if (File.Exists(RecognizedFilePath))
   '   File.Delete(RecognizedFilePath);
   'MetaFile.Dispose();
   End Sub

#Region "IDisposable Members"

   Public Sub Dispose() Implements IDisposable.Dispose
   Try
   If System.IO.File.Exists(file) Then
      System.IO.File.Delete(file)
   End If

   If System.IO.File.Exists(RecognizedFilePath) Then
      System.IO.File.Delete(RecognizedFilePath)
   End If
   Catch
   End Try
   'MetaFile.Dispose();
   End Sub
#End Region

   Public Function FileLocation() As String Implements IPrintToPACSFile.FileLocation
   Return file
   End Function
   End Class

   <Serializable()> _
   Friend Class Page : Implements IDisposable, IPrintToPACSFile
   Private bDeleteOnDispose As Boolean = False
   Public Property DeleteOnDispose() As Boolean
   Get
    Return bDeleteOnDispose
   End Get
   Set(ByVal value As Boolean)
    bDeleteOnDispose = value
   End Set
   End Property

   Private file As String = String.Empty
   Public Property FilePath() As String
   Get
    Return file
   End Get
   Set(ByVal value As String)
    file = value
   End Set
   End Property

#Region "IDisposable Members"

   Public Sub Dispose() Implements IDisposable.Dispose
   Try
   If bDeleteOnDispose Then
      If System.IO.File.Exists(file) Then
      System.IO.File.Delete(file)
      End If
   End If
   Catch
   End Try
   End Sub

#End Region

   Public Function FileLocation() As String Implements IPrintToPACSFile.FileLocation
   Return file
   End Function
   End Class

   Friend Interface IPrintToPACSFile
   Function FileLocation() As String
   End Interface
End Namespace
