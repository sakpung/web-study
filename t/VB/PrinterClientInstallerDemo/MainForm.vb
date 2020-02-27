' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.IO
Imports Leadtools.Printer.Client.Installer
Imports System.Security.Principal
Imports System.Diagnostics
Imports System.Drawing.Printing
Imports System.Net

Namespace PrinterClientInstaller
   Partial Public Class MainForm : Inherits Form

      'list of the Connection we made
      Dim _networkConnections As List(Of NetworkConnection) = New List(Of NetworkConnection)()

      <STAThread()> _
      Shared Sub Main(ByVal args As String())
         Try
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Try
               Application.Run(New MainForm())
            Catch ex As Exception

            End Try
         Catch
         End Try
      End Sub

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Enabled = False
         _txtPrinterDll.Text = Path.GetDirectoryName(Application.ExecutablePath) + "\\VBPrinterClientDemo.dll"
      End Sub

      Private Sub _btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBrowse.Click
         Dim dlgOpen As OpenFileDialog = New OpenFileDialog()
         dlgOpen.Filter = "DLL File(*.dll)|*.dll"

         Dim dlgRes As DialogResult = dlgOpen.ShowDialog()

         If dlgRes <> DialogResult.OK Then
            Return
         End If

         _txtPrinterDll.Text = dlgOpen.FileName
      End Sub

      Private Sub _btnInstall_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnInstall.Click
         Dim strServer, strPrinter As String

         strServer = _txtServerName.Text
         strPrinter = _cmbPrinters.Text.ToString()

         If String.IsNullOrEmpty(strServer) Or String.IsNullOrEmpty(strPrinter) Or String.IsNullOrEmpty(_txtPrinterDll.Text) Then
            MessageBox.Show(Me, "Printer Name, Printer Server and Printer Demo DLL Should be specified", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
         End If

         If (Not File.Exists(_txtPrinterDll.Text)) Then
            MessageBox.Show(Me, "Printer Demo DLL does not exist", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
         End If

         Try
            PrinterInstaller.SetPrinterConnectionDll(strPrinter, _txtPrinterDll.Text, strServer)
            MessageBox.Show(Me, "Printer installed and connected to demo DLL successfully", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Catch ex As PrinterDriverClientException
            MessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property

      Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
         Enabled = True
         If (Is64) Then
            Text = "LEADTOOLS VB Printer Client Installer 64-bit"
         Else
            Text = "LEADTOOLS VB Printer Client Installer 32-bit"
         End If
      End Sub

      Private Sub _btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRefresh.Click
         _cmbPrinters.Items.Clear()
         Dim lstPrinters As List(Of String) = New List(Of String)()

         'We need to have access to the printer server in order to list the shared printers
         'Do we have access?
         If (Not NetShares.IsServerAccessible(_txtServerName.Text)) Then
            'We dont have access create attempt to connect to the server
            Dim netConnection As NetworkConnection = New NetworkConnection(_txtServerName.Text, Me.Handle)
            If netConnection.ConnectToServer() Then
               'add the new connection to the list
               If (Not _networkConnections.Contains(netConnection)) Then
                  _networkConnections.Add(netConnection)
               End If
            Else
               'we cant connect to server
               _cmbPrinters.Enabled = False
               MessageBox.Show(Me, "The requested server can not be accessed", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return
            End If
         End If

         If (Not String.IsNullOrEmpty(_txtServerName.Text)) Then
            lstPrinters = NetShares.GetSharedPrinter(_txtServerName.Text)
         End If

         If lstPrinters.Count <= 0 Then
            _cmbPrinters.Enabled = False
            MessageBox.Show(Me, "No shared printers found in the domain", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
         End If

         _cmbPrinters.Enabled = True

         For Each strPrinter As String In lstPrinters
            _cmbPrinters.Items.Add(strPrinter)
         Next strPrinter

         If _cmbPrinters.Items.Count > 0 Then
            _cmbPrinters.SelectedIndex = 0
         End If
      End Sub

      Private Sub _txtServerName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtServerName.TextChanged
         _btnRefresh.Enabled = _txtServerName.Text.Length > 0
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         For Each connection As NetworkConnection In _networkConnections
            'Remove all connection we made.
            connection.DisconnectFromServer()
         Next connection
      End Sub

   End Class

   Public Class NetShares
#Region "External Calls"
      <DllImport("Netapi32.dll", SetLastError:=True)> _
      Shared Function NetApiBufferFree(ByVal Buffer As IntPtr) As Integer
      End Function
      <DllImport("Netapi32.dll", CharSet:=CharSet.Unicode)> _
      Private Shared Function NetShareEnum(ByVal ServerName As StringBuilder, ByVal level As Integer, ByRef bufPtr As IntPtr, ByVal prefmaxlen As System.UInt32, ByRef entriesread As Integer, ByRef totalentries As Integer, ByRef resume_handle As Integer) As Integer
      End Function
#End Region
#Region "External Structures"

      <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
      Public Structure SHARE_INFO_1
         Public shi1_netname As String
         Public shi1_type As System.UInt32
         Public shi1_remark As String
         Public Sub New(ByVal sharename As String, ByVal sharetype As System.UInt32, ByVal remark As String)
            Me.shi1_netname = sharename
            Me.shi1_type = sharetype
            Me.shi1_remark = remark
         End Sub
         Public Overrides Function ToString() As String
            Return shi1_netname
         End Function
      End Structure
#End Region

      Private Const MAX_PREFERRED_LENGTH As Long = &HFFFFFFFFL
      Private Const NERR_Success As Integer = 0
      Private Enum NetError As Integer
         NERR_Success = 0
         NERR_BASE = 2100
         NERR_UnknownDevDir = (NERR_BASE + 16)
         NERR_DuplicateShare = (NERR_BASE + 18)
         NERR_BufTooSmall = (NERR_BASE + 23)
      End Enum
      Private Enum SHARE_TYPE As Long
         STYPE_DISKTREE = 0
         STYPE_PRINTQ = 1
         STYPE_DEVICE = 2
         STYPE_IPC = 3
         STYPE_SPECIAL = &H80000000L
      End Enum

      Public Shared Function IsServerAccessible(ByVal ServerParam As String) As Boolean
         Dim entriesread As Integer = 0
         Dim totalentries As Integer = 0
         Dim resume_handle As Integer = 0
         Dim bufPtr As IntPtr = IntPtr.Zero
         Dim server_Renamed As StringBuilder = New StringBuilder(ServerParam)

         'Try to enumerate the server resources
         Dim ret As Integer = NetShareEnum(server_Renamed, 1, bufPtr, MAX_PREFERRED_LENGTH, entriesread, totalentries, resume_handle)
         NetApiBufferFree(bufPtr)

         'if we can enumerate then we have access to the server
         Return ret = NERR_Success
      End Function



      Public Shared Function EnumNetShares(ByVal Server As String) As SHARE_INFO_1()
         Dim ShareInfos As List(Of SHARE_INFO_1) = New List(Of SHARE_INFO_1)()
         Dim entriesread As Integer = 0
         Dim totalentries As Integer = 0
         Dim resume_handle As Integer = 0
         Dim nStructSize As Integer = Marshal.SizeOf(GetType(SHARE_INFO_1))
         Dim bufPtr As IntPtr = IntPtr.Zero
         Dim server_Param As StringBuilder = New StringBuilder(Server)
         Dim ret As Integer = NetShareEnum(server_Param, 1, bufPtr, MAX_PREFERRED_LENGTH, entriesread, totalentries, resume_handle)
         If ret = NERR_Success Then
            Dim currentPtr As IntPtr = bufPtr
            Dim i As Integer = 0
            Do While i < entriesread
               Dim shi1 As SHARE_INFO_1 = CType(Marshal.PtrToStructure(currentPtr, GetType(SHARE_INFO_1)), SHARE_INFO_1)
               ShareInfos.Add(shi1)
               currentPtr = New IntPtr(currentPtr.ToInt32() + nStructSize)
               i += 1
            Loop
            NetApiBufferFree(bufPtr)
            Return ShareInfos.ToArray()
         Else
            ShareInfos.Add(New SHARE_INFO_1("ERROR=" & ret.ToString(), 10, String.Empty))
            Return ShareInfos.ToArray()
         End If
      End Function

      Public Shared Function GetSharedPrinter(ByVal Server As String) As List(Of String)
         Dim lstString As List(Of String) = New List(Of String)()
         Dim shareInfo As SHARE_INFO_1() = EnumNetShares(Server)

         Dim i As Integer = 0
         Do While i < shareInfo.Length
            Dim info As SHARE_INFO_1 = shareInfo(i)
            If info.shi1_type = Convert.ToInt32(SHARE_TYPE.STYPE_PRINTQ) Then
               lstString.Add(info.shi1_netname)
            End If
            i += 1
         Loop

         Return lstString
      End Function
   End Class

   Public Class NetworkConnection ': Implements IEquatable(Of NetworkConnection)
#Region "External Calls"

      <DllImport("mpr.dll")> _
      Private Shared Function WNetUseConnection(ByVal hWndOwner As IntPtr, ByVal lpNetResource As NetResource, ByVal lpPassword As String, ByVal lpUserName As String, ByVal dwFlags As Integer, ByVal lpAccessName As String, ByRef lpBufferSize As Integer, <System.Runtime.InteropServices.Out()> ByRef lpResult As Integer) As Integer
      End Function

      <DllImport("mpr.dll")> _
      Private Shared Function WNetCancelConnection2(ByVal name As String, ByVal flags As Integer, ByVal force As Boolean) As Integer
      End Function

#End Region
#Region "External Structures"

      Public Enum ResourceDisplaytype As Integer
         Generic = &H0
         Domain = &H1
         Server = &H2
         Share = &H3
         File = &H4
         Group = &H5
         Network = &H6
         Root = &H7
         Shareadmin = &H8
         Directory = &H9
         Tree = &HA
         Ndscontainer = &HB
      End Enum

      Public Enum ResourceType As Integer
         Any = 0
         Disk = 1
         Print = 2
         Reserved = 8
      End Enum

      Public Enum ResourceScope As Integer
         Connected = 1
         GlobalNetwork
         Remembered
         Recent
         Context
      End Enum

      <StructLayout(LayoutKind.Sequential)> _
      Public Class NetResource
         Public Scope As ResourceScope
         Public ResourceType As ResourceType
         Public DisplayType As ResourceDisplaytype
         Public Usage As Integer
         Public LocalName As String
         Public RemoteName As String
         Public Comment As String
         Public Provider As String
      End Class

#End Region

      Private _networkName As String
      Private _netResource As NetResource
      Private _mainWinHandle As IntPtr

      Public Sub New(ByVal networkName As String, ByVal mainWinHandle As IntPtr)
         _networkName = "\\" & networkName
         _mainWinHandle = mainWinHandle

         _netResource = New NetResource()
         _netResource.Scope = ResourceScope.GlobalNetwork
         _netResource.ResourceType = ResourceType.Disk
         _netResource.DisplayType = ResourceDisplaytype.Share
         _netResource.RemoteName = _networkName
      End Sub

      Public Sub DisconnectFromServer()
         'Cancel the connection to the server
         WNetCancelConnection2(_networkName, 0, True)
      End Sub

      Public Function ConnectToServer() As Boolean
         Dim nBuffSize As Integer = 0
         Dim nResult As Integer = 0
         'Connect to the server
         Dim result As Integer = WNetUseConnection(_mainWinHandle, _netResource, Nothing, Nothing, 8, Nothing, nBuffSize, nResult)

         Return result = 0
      End Function

      Public Overrides Function Equals(ByVal obj As Object) As Boolean
         Dim connection As NetworkConnection
         connection = CType(obj, NetworkConnection)
         Return connection._networkName = _networkName
      End Function
   End Class

End Namespace
