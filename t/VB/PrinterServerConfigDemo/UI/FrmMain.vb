' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Demos
Imports Leadtools.Printer
Imports PrinterDemo
Imports Leadtools
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports Microsoft.Win32
Imports System.Diagnostics

Namespace ServerPrinterConfigDemo.UI
   Partial Public Class FrmMain : Inherits Form

#Region "Main..."
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main(ByVal args As String())
         Try
            If Not Support.SetLicense() Then
               Return
            End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New FrmMain())
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Shared ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property
#End Region

#Region "Fields..."
      Private _printerSettings As PrinterSettings
      Public Shared ReadOnly Property _strTittle() As String
         Get
            If (Is64()) Then
               Return "LEADTOOLS C# Printer Server Config Demo 64-bit"
            Else
               Return "LEADTOOLS C# Printer Server Config Demo 32-bit"
            End If
         End Get
      End Property

      Private _printer As Printer
      Private _currentPrinterName As String = String.Empty
      Private _EnableNetworkPrinting As Boolean = False
      Private _bUpdate As Boolean = False
      Private _lstTextBox As List(Of TextBox) = New List(Of TextBox)()
#End Region

      Public Sub New()
         Try
            InitializeComponent()
            Text = _strTittle

            _lstTextBox.Add(_txtLocationPDF)
            _lstTextBox.Add(_txtLocationDoc)
            _lstTextBox.Add(_txtLocationXps)
            _lstTextBox.Add(_txtLocationTxt)

            _btnSave.Enabled = False

            FillLeadtoolsPrintersList(Nothing, False)
            If _cmbNetworkPrinters.Items.Count = 0 Then
               _cmbNetworkPrinters.Enabled = False
               _ckNetworkEnabled.Enabled = False
               _ckSharePrinter.Enabled = False
               _grpPrinterSettings.Enabled = False
               _btnUninstall.Enabled = False
            Else
               _bUpdate = False
               _EnableNetworkPrinting = _printer.EnableNetworkPrinting
               _ckNetworkEnabled_CheckedChanged(Nothing, Nothing)
               _bUpdate = True
            End If

         Catch Ex As Exception
            MessageBox.Show(Ex.Message, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
         End Try
      End Sub

      Private Sub FillLeadtoolsPrintersList(ByVal strDefault As String, ByVal bDefaultEnable As Boolean)
         Dim setupPrinter As String = String.Empty

#If LTV20_CONFIG Then
         If (Is64) Then
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 64-bit"
         Else
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 32-bit"
         End If
#End If

            If (Not String.IsNullOrEmpty(strDefault)) Then
               setupPrinter = strDefault
            End If

            Try
               _cmbNetworkPrinters.Items.Clear()
               _cmbNetworkPrinters.Items.AddRange(PrintingUtilities.GetLeadtoolsPrintersList())

               If _cmbNetworkPrinters.Items.Count > 0 Then
                  _cmbNetworkPrinters.SelectedIndex = 0

                  Dim i As Integer = 0
                  Do While i < _cmbNetworkPrinters.Items.Count
                     If (CType(IIf(TypeOf _cmbNetworkPrinters.Items(i) Is String, _cmbNetworkPrinters.Items(i), Nothing), String)).ToLower() = setupPrinter.ToLower() Then
                        _cmbNetworkPrinters.SelectedIndex = i
                     End If
                     i += 1
                  Loop

                  _printer = New Printer(_cmbNetworkPrinters.SelectedItem.ToString())

                  If bDefaultEnable Then
                     _printer.EnableNetworkPrinting = True
                     _ckNetworkEnabled.Checked = True
                  Else

                     _ckNetworkEnabled.Checked = _printer.EnableNetworkPrinting
                     _ckSharePrinter.Checked = PrinterConfiguration.IsPrinterShared(_printer.PrinterName)
                  End If

               Else
                  Dim errorMessage As String = "No printers are available."
                  MessageBox.Show(errorMessage, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               End If
            Catch Ex As Exception
               MessageBox.Show(Ex.ToString(), _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
      End Sub

      Private Sub ApplyPrinterSettings()
         _txtPrinterDescription.Text = _printerSettings._strDescreption

         For Each txtBox As TextBox In _lstTextBox
            txtBox.Clear()
         Next txtBox

         Dim i As Integer = 0
         Do While i < _printerSettings._lstFormats.Count
            Dim fileFormat As PrinterFileFormat = _printerSettings._lstFormats(i)
            _lstTextBox(i).Text = fileFormat._strSaveLocation
            i += 1
         Loop
      End Sub

      Private Sub _ckNetworkEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _ckNetworkEnabled.CheckedChanged
         Try
            If _bUpdate AndAlso _printer.EnableNetworkPrinting <> _ckNetworkEnabled.Checked Then
               _printer.EnableNetworkPrinting = _ckNetworkEnabled.Checked
            End If

            _grpPrinterSettings.Enabled = _ckNetworkEnabled.Checked

            If _ckNetworkEnabled.Checked Then
               Dim bytes As Byte() = _printer.GetNetworkInitialData()
               If bytes Is Nothing OrElse bytes.Length = 0 Then
                  _printerSettings = New PrinterSettings()
                  Try
                     _printer.SetNetworkInitialData(_printerSettings.GetBytes())
                  Catch

                     Dim strMessage As String = "Incorrect IIS Configuration - Error retrieving data from Web service." & Constants.vbLf + Constants.vbLf & _
                                                "In order to use LEADTOOLS Network Virtual Printer:" & Constants.vbLf & _
                                                "   1. IIS should be installed." & Constants.vbLf & _
                                                "   2. IIS must be configured using the LEADTOOLS Printer Server IIS Configuration Demo." & Constants.vbLf + Constants.vbLf & _
                                                "Do you want to launch the LEADTOOLS Printer Server IIS Configuration Demo?"
                     Dim dlgRes As DialogResult = MessageBox.Show(strMessage, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error)

                     If dlgRes = DialogResult.Yes Then
                        Dim strConfigPath As String
                        strConfigPath = Path.GetDirectoryName(Application.ExecutablePath)
                        Process.Start(strConfigPath & "\" & "VBPrinterServerIISConfigDemo_Original.exe")
                     End If


                     Me.Close()
                     Environment.Exit(0)
                     Return
                  End Try

               Else
                  _printerSettings = New PrinterSettings(bytes)
               End If

               ApplyPrinterSettings()
            Else
               Dim i As Integer = 0
               Do While i < _lstTextBox.Count
                  _lstTextBox(i).Clear()
                  i += 1
               Loop
               _txtPrinterDescription.Clear()
            End If
         Catch ex As PrinterDriverException
            If ex.Code = PrinterDriverExceptionCode.PrinterStateLocked Then
               MessageBox.Show(Nothing, "Cannot enable network printing for a locked printer", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               _ckNetworkEnabled.Checked = False
            End If
         End Try


      End Sub

      Private Sub _cmbNetworkPrinters_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbNetworkPrinters.SelectedIndexChanged
         If _ckNetworkEnabled.Checked AndAlso _btnSave.Enabled Then
            Dim dlgRes As DialogResult = MessageBox.Show("Printer Settings Changed" & Constants.vbLf & "Do you want to save them?", _strTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If dlgRes = DialogResult.Yes Then
               _btnSave.PerformClick()
            End If
         End If

         _btnSave.Enabled = False

         If _printer Is Nothing OrElse String.IsNullOrEmpty(_cmbNetworkPrinters.SelectedItem.ToString()) OrElse (_printer.PrinterName = _cmbNetworkPrinters.SelectedItem.ToString()) Then
            Return
         End If

         _printer.Dispose()

         _printer = New Printer(_cmbNetworkPrinters.SelectedItem.ToString())

         _ckNetworkEnabled.Checked = _printer.EnableNetworkPrinting
         _ckSharePrinter.Checked = PrinterConfiguration.IsPrinterShared(_printer.PrinterName)
         _ckNetworkEnabled_CheckedChanged(Nothing, Nothing)
      End Sub

      Private Sub _btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnSave.Click
         Try
            _printerSettings._strDescreption = _txtPrinterDescription.Text

            Dim i As Integer = 0
            Do While i < _printerSettings._lstFormats.Count
               _printerSettings._lstFormats(i)._strSaveLocation = _lstTextBox(i).Text
               i += 1
            Loop

            _printer.SetNetworkInitialData(_printerSettings.GetBytes())
            _btnSave.Enabled = False
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Function CheckDirectory(ByVal strPath As String) As Boolean
         If Directory.Exists(strPath) OrElse String.IsNullOrEmpty(strPath) Then
            Return True
         End If

         Dim dlgRes As DialogResult = MessageBox.Show("Folder does not exist" & Constants.vbLf & "Do you want to create it?", _strTittle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
         If dlgRes = DialogResult.Yes Then
            Directory.CreateDirectory(strPath)
            Return True
         End If

         Return False
      End Function

      Private Sub _btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBrowseTxt.Click, _btnBrowseXps.Click, _btnBrowseDoc.Click, _btnBrowsePdf.Click
         Dim folderDialog As FolderBrowserDialog = New FolderBrowserDialog()
         Dim nTextBox As Integer = Convert.ToInt32((CType(sender, Button)).Tag)
         If CheckDirectory(_lstTextBox(nTextBox).Text) Then
            folderDialog.SelectedPath = _lstTextBox(nTextBox).Text
         End If

         Dim dlgRes As DialogResult = folderDialog.ShowDialog(Me)

         If dlgRes = DialogResult.OK Then
            _lstTextBox(nTextBox).Text = folderDialog.SelectedPath
         End If


      End Sub

      Private Sub _btnAddNewPrinter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnAddNewPrinter.Click
         Try
            Dim frmInstallPrinter As FrmInstallPrinter = New FrmInstallPrinter()
            Dim dialogResult As DialogResult = frmInstallPrinter.ShowDialog()

            If dialogResult = dialogResult.OK Then
               Cursor = Cursors.WaitCursor
               Dim newPrinterName As String = frmInstallPrinter.PrinterName
               _currentPrinterName = frmInstallPrinter.PrinterName
               Dim newPrinterPassword As String = ""

               PrintingUtilities.InstallNewPrinter(newPrinterName, newPrinterPassword)
               _currentPrinterName = newPrinterName
               _EnableNetworkPrinting = frmInstallPrinter.EnableNetwork

               FillLeadtoolsPrintersList(_currentPrinterName, _EnableNetworkPrinting)
               If _cmbNetworkPrinters.Items.Count = 0 Then
                  _cmbNetworkPrinters.Enabled = False
                  _ckNetworkEnabled.Enabled = False
                  _ckSharePrinter.Enabled = False
                  _grpPrinterSettings.Enabled = False
                  _btnUninstall.Enabled = False
               Else
                  _cmbNetworkPrinters.Enabled = True
                  _ckNetworkEnabled.Enabled = True
                  _ckSharePrinter.Enabled = True
                  _grpPrinterSettings.Enabled = True
                  _btnUninstall.Enabled = True

                  _EnableNetworkPrinting = _printer.EnableNetworkPrinting
                  _ckNetworkEnabled_CheckedChanged(Nothing, Nothing)

                  _ckSharePrinter.Checked = True
                  PrinterConfiguration.SharePrinter(_cmbNetworkPrinters.SelectedItem.ToString(), _ckSharePrinter.Checked)
               End If
            End If
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Finally
            Cursor = Cursors.Default
         End Try

      End Sub

      Private Sub _txtLocation_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtLocationTxt.TextChanged, _txtLocationXps.TextChanged, _txtLocationDoc.TextChanged, _txtLocationPDF.TextChanged
         CheckSettingsChanged()
      End Sub

      Private Sub _txtLocation_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _txtLocationTxt.Leave, _txtLocationXps.Leave, _txtLocationDoc.Leave, _txtLocationPDF.Leave
         Dim nTextBox As Integer = Convert.ToInt32((CType(sender, TextBox)).Tag)
         Dim txtBox As TextBox = _lstTextBox(nTextBox)
         _lstTextBox(nTextBox).Text = _lstTextBox(nTextBox).Text.Trim()
         CheckSettingsChanged()

         If _printerSettings._lstFormats(nTextBox)._strSaveLocation <> txtBox.Text Then
            If (Not CheckDirectory(txtBox.Text)) Then
               txtBox.Text = _printerSettings._lstFormats(nTextBox)._strSaveLocation
            End If
         End If
      End Sub

      Private Function CheckSettingsChanged() As Boolean
         Dim bSaveChanged As Boolean = False
         Dim i As Integer = 0
         Do While i < _lstTextBox.Count
            If _printerSettings._lstFormats(i)._strSaveLocation.ToUpper() <> _lstTextBox(i).Text.ToUpper() Then
               bSaveChanged = True
               Exit Do
            End If
            i += 1
         Loop

         Dim bDescreptionChanged As Boolean = False

         bDescreptionChanged = _txtPrinterDescription.Text <> _printerSettings._strDescreption

         _btnSave.Enabled = bSaveChanged OrElse bDescreptionChanged
         Return bSaveChanged OrElse bDescreptionChanged
      End Function


      Private Sub _txtPrinterDescription_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtPrinterDescription.TextChanged
         CheckSettingsChanged()
      End Sub

      Private Sub _ckSharePrinter_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _ckSharePrinter.CheckedChanged
         PrinterConfiguration.SharePrinter(_cmbNetworkPrinters.SelectedItem.ToString(), _ckSharePrinter.Checked)
      End Sub

      Private Function UninstallPrinter(ByVal printerName As String) As DialogResult
         Dim dialogResult As DialogResult = dialogResult.Ignore

         Try
            Dim warningMessage As String = String.Format("Are you sure you want to remove the {0} printer from the system?", printerName)
            dialogResult = MessageBox.Show(warningMessage, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If dialogResult = dialogResult.Yes Then
               Dim printerInfo As PrinterInfo = New PrinterInfo()
               printerInfo.PrinterName = printerName
               printerInfo.MonitorName = printerName
               printerInfo.PortName = printerName

               Printer.UnInstall(printerInfo)
               MessageBox.Show("Uninstalling Printer Completed Successfully", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try

         Return dialogResult
      End Function

      Private Sub _btnUninstall_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnUninstall.Click
         If UninstallPrinter(_printer.PrinterName) <> DialogResult.Yes Then
            Return
         End If

         FillLeadtoolsPrintersList(Nothing, False)
         If _cmbNetworkPrinters.Items.Count = 0 Then
            _cmbNetworkPrinters.Enabled = False
            _ckNetworkEnabled.Enabled = False
            _ckSharePrinter.Enabled = False
            _grpPrinterSettings.Enabled = False
            _btnUninstall.Enabled = False
         Else
            _EnableNetworkPrinting = _printer.EnableNetworkPrinting
            _ckNetworkEnabled_CheckedChanged(Nothing, Nothing)
         End If

      End Sub

      Private Sub FrmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
         Activate()
      End Sub
   End Class

   Friend Class PrinterSettings
      Public _strDescreption As String
      Public _lstFormats As List(Of PrinterFileFormat)

      Public Sub New(ByVal strDescreption As String, ByVal lstFormats As List(Of PrinterFileFormat))
         _strDescreption = strDescreption
         _lstFormats = lstFormats
      End Sub

      Public Sub New(ByVal bytes As Byte())
         _lstFormats = New List(Of PrinterFileFormat)()
         SetBytes(bytes)
      End Sub

      Public Sub New()
         _strDescreption = "Insert actual printer descriptions here, this description will be sent to the " & "user client demo as initialization data"

         _lstFormats = New List(Of PrinterFileFormat)()

         Dim PersonalFolder As String = CStr(Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Common Documents", ""))

         If PersonalFolder = "" Then
            PersonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
         End If

         Dim fileFormat As PrinterFileFormat = New PrinterFileFormat("PDF", PersonalFolder)
         _lstFormats.Add(fileFormat)
         fileFormat = New PrinterFileFormat("DOC", PersonalFolder)
         _lstFormats.Add(fileFormat)
         fileFormat = New PrinterFileFormat("XPS", PersonalFolder)
         _lstFormats.Add(fileFormat)
         fileFormat = New PrinterFileFormat("TEXT", PersonalFolder)
         _lstFormats.Add(fileFormat)

      End Sub

      Public Sub New(ByVal strDescreption As String)
         Me.New()

         _strDescreption = strDescreption
      End Sub

      Public Sub AddFileFormat(ByVal fileFormat As PrinterFileFormat)
         _lstFormats.Add(fileFormat)
      End Sub

      Public Function GetBytes() As Byte()
         Dim strReturn As String = ""
         strReturn &= _strDescreption
         strReturn &= "---"

         For Each fileFormat As PrinterFileFormat In _lstFormats
            strReturn &= fileFormat._strFileFormat
            strReturn &= "---"
            strReturn &= fileFormat._strSaveLocation
            strReturn &= "---"
         Next fileFormat

         Dim [unicode] As Encoding = Encoding.Unicode

         Return [unicode].GetBytes(strReturn.ToCharArray())
      End Function

      Public Function GetSavePath(ByVal strFormat As String) As String
         For Each fileFormat As PrinterFileFormat In _lstFormats
            If fileFormat._strFileFormat.ToUpper() = strFormat.ToUpper() Then
               Return fileFormat._strSaveLocation
            End If
         Next fileFormat

         Return ""
      End Function

      Public Sub SetBytes(ByVal bytes As Byte())
         Dim [unicode] As Encoding = Encoding.Unicode

         If Not _lstFormats Is Nothing Then
            _lstFormats.Clear()
         End If

         Dim strBytes As String = New String([unicode].GetChars(bytes))
         Dim nIndex As Integer
         nIndex = strBytes.IndexOf("---")

         _strDescreption = strBytes.Substring(0, nIndex)
         strBytes = strBytes.Substring(nIndex + 3)

         Dim strFormat As String = "", strLocation As String = ""
         Do While True
            Try
               nIndex = strBytes.IndexOf("---")
               strFormat = strBytes.Substring(0, nIndex)
               strBytes = strBytes.Substring(nIndex + 3)

               nIndex = strBytes.IndexOf("---")
               strLocation = strBytes.Substring(0, nIndex)
               strBytes = strBytes.Substring(nIndex + 3)

               Dim fileFormat As PrinterFileFormat = New PrinterFileFormat(strFormat, strLocation)
               _lstFormats.Add(fileFormat)

            Catch
               Exit Do
            End Try

         Loop
      End Sub

   End Class

   Friend Class PrinterFileFormat
      Public _strFileFormat As String
      Public _strSaveLocation As String

      Public Sub New(ByVal strFileFormat As String, ByVal strSaveLocation As String)
         _strSaveLocation = strSaveLocation
         _strFileFormat = strFileFormat
      End Sub
   End Class

   Public Class PrinterConfiguration

#Region "PRINTER_INFO_2"
      <StructLayout(LayoutKind.Sequential)> _
      Private Structure PRINTER_INFO_2
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pServerName As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pPrinterName As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pShareName As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pPortName As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pDriverName As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pComment As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pLocation As String
         Public pDevMode As IntPtr
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pSepFile As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pPrintProcessor As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pDatatype As String
         <MarshalAs(UnmanagedType.LPStr)> _
         Public pParameters As String
         Public pSecurityDescriptor As IntPtr
         Public Attributes As Int32
         Public Priority As Int32
         Public DefaultPriority As Int32
         Public StartTime As Int32
         Public UntilTime As Int32
         Public Status As Int32
         Public cJobs As Int32
         Public AveragePPM As Int32
      End Structure
#End Region ' PRINTER_INFO_2

#Region "Private Variables"
      Private Shared _hPrinter As IntPtr = New System.IntPtr()
      Private Shared _PrinterValues As PRINTER_DEFAULTS = New PRINTER_DEFAULTS()
      Private Shared _pinfo As PRINTER_INFO_2 = New PRINTER_INFO_2()
      Private Shared _PtrPrinterInfo As IntPtr
      Private Shared _LastError As Integer
      Private Shared _NBytesNeeded As Integer
      Private Shared _NRet As Long
      Private Shared _NJunk As System.Int32
#End Region

#Region "Win API Def"

      <DllImport("kernel32.dll", EntryPoint:="GetLastError", SetLastError:=False, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
      Private Shared Function GetLastError() As Int32
      End Function

      <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
      Private Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
      End Function


      <DllImport("winspool.Drv", EntryPoint:="GetPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
      Private Shared Function GetPrinter(ByVal hPrinter As IntPtr, ByVal dwLevel As Int32, ByVal pPrinter As IntPtr, ByVal dwBuf As Int32, <System.Runtime.InteropServices.Out()> ByRef dwNeeded As Int32) As Boolean
      End Function

      <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
      Private Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> ByVal szPrinter As String, <System.Runtime.InteropServices.Out()> ByRef hPrinter As IntPtr, ByRef pd As PRINTER_DEFAULTS) As Boolean
      End Function

      <DllImport("winspool.drv", CharSet:=CharSet.Ansi, SetLastError:=True)> _
      Private Shared Function SetPrinter(ByVal hPrinter As IntPtr, ByVal Level As Integer, ByVal pPrinter As IntPtr, ByVal Command As Integer) As Boolean
      End Function

      <DllImport("winspool.drv", CharSet:=CharSet.Ansi, SetLastError:=True)> _
      Private Shared Function SetPrinter(ByVal hPrinter As IntPtr, ByVal Level As Integer, ByVal pPrinter As PRINTER_INFO_2, ByVal Command As Integer) As Boolean
      End Function


#End Region

#Region "Constants"
      Private Const DM_DUPLEX As Integer = &H1000
      Private Const DM_IN_BUFFER As Integer = 8
      Private Const DM_OUT_BUFFER As Integer = 2
      Private Const PRINTER_ACCESS_ADMINISTER As Integer = &H4
      Private Const PRINTER_ACCESS_USE As Integer = &H8
      Private Const STANDARD_RIGHTS_REQUIRED As Integer = &HF0000
      Private Const PRINTER_ALL_ACCESS As Integer = (STANDARD_RIGHTS_REQUIRED Or PRINTER_ACCESS_ADMINISTER Or PRINTER_ACCESS_USE)
#End Region

      <StructLayout(LayoutKind.Sequential)> _
      Public Structure PRINTER_DEFAULTS
         Public pDatatype As IntPtr
         Public pDevMode As IntPtr
         Public DesiredAccess As System.UInt64
      End Structure

      Public Shared Function IsPrinterShared(ByVal printerName As String) As Boolean
         Dim bShare As Boolean = False
         Dim pi2 As PRINTER_INFO_2
         pi2 = GetPrinterSettings(printerName)

         pi2.pSecurityDescriptor = IntPtr.Zero

         If (pi2.Attributes And System.Convert.ToUInt32(&H8)) = System.Convert.ToUInt32(&H8) Then
            bShare = True
         End If

         Marshal.FreeHGlobal(_PtrPrinterInfo)
         Return bShare
      End Function

      Public Shared Function SharePrinter(ByVal printerName As String, ByVal share As Boolean) As Boolean
         Try
            _pinfo = GetPrinterSettings(printerName)
            _pinfo.pSecurityDescriptor = IntPtr.Zero


            If share Then
               _pinfo.pShareName = printerName
               _pinfo.Attributes = _pinfo.Attributes Or &H8
            Else
               _pinfo.Attributes = _pinfo.Attributes And ((Not &H8))
            End If

            Marshal.StructureToPtr(_pinfo, _PtrPrinterInfo, False)
            _LastError = Marshal.GetLastWin32Error()

            _NRet = Convert.ToInt16(SetPrinter(_hPrinter, 2, _PtrPrinterInfo, 0))

            If _NRet = 0 Then
               _LastError = Marshal.GetLastWin32Error()
               Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
         Finally
            If Not _hPrinter.Equals(IntPtr.Zero) Then

               ClosePrinter(_hPrinter)
            End If
         End Try
         Marshal.FreeHGlobal(_PtrPrinterInfo)
         Return Convert.ToBoolean(_NRet)
      End Function

      Private Shared Function GetPrinterSettings(ByVal PrinterName As String) As PRINTER_INFO_2
         Const PRINTER_ACCESS_ADMINISTER As Integer = &H4
         Const PRINTER_ACCESS_USE As Integer = &H8
         Const PRINTER_ALL_ACCESS As Integer = (STANDARD_RIGHTS_REQUIRED Or PRINTER_ACCESS_ADMINISTER Or PRINTER_ACCESS_USE)

         _PrinterValues.pDatatype = IntPtr.Zero
         _PrinterValues.pDevMode = IntPtr.Zero
         _PrinterValues.DesiredAccess = PRINTER_ALL_ACCESS
         _NRet = Convert.ToInt32(OpenPrinter(PrinterName, _hPrinter, _PrinterValues))
         If _NRet = 0 Then
            _LastError = Marshal.GetLastWin32Error()
            Throw New Win32Exception(Marshal.GetLastWin32Error())
         End If
         GetPrinter(_hPrinter, 2, IntPtr.Zero, 0, _NBytesNeeded)
         If _NBytesNeeded <= 0 Then
            Throw New System.Exception("Unable to allocate memory")

         Else
            _PtrPrinterInfo = Marshal.AllocHGlobal(_NBytesNeeded)

            _NRet = Convert.ToInt32(GetPrinter(_hPrinter, 2, _PtrPrinterInfo, _NBytesNeeded, _NJunk))

            If _NRet = 0 Then
               _LastError = Marshal.GetLastWin32Error()
               Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            _pinfo = CType(Marshal.PtrToStructure(_PtrPrinterInfo, GetType(PRINTER_INFO_2)), PRINTER_INFO_2)

            If (_NRet = 0) OrElse (_hPrinter.Equals(IntPtr.Zero)) Then

               _LastError = Marshal.GetLastWin32Error()
               Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            Return _pinfo
         End If

      End Function
   End Class
End Namespace
