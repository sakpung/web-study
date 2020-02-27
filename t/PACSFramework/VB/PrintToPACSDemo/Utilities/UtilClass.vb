' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Collections
Imports System.Xml.Serialization
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.IO
Imports Leadtools.Dicom
Imports Leadtools.Wia
Imports Leadtools.DicomDemos
Imports PrintToPACSDemo
Imports System.Windows.Forms

Namespace PrintToPACS.Utilities

   <Serializable()> _
   Public Class MyServer : Implements ICloneable
      Public _sAE As String
      Public _sIP As String
      Public _port As Integer
      Public _timeout As Integer
      Public _useTls As Boolean

      Public Sub New()
         _sAE = String.Empty
         _sIP = String.Empty
         _port = 0
         _timeout = 0
         _useTls = False
      End Sub

      Public Sub New(ByVal dicomAE As DicomAE)
         _sAE = dicomAE.AE
         _sIP = dicomAE.IPAddress
         _port = dicomAE.Port
         _timeout = dicomAE.Timeout
         _useTls = dicomAE.UseTls
      End Sub

      Public Sub New(ByVal sAE As String, ByVal sIP As String, ByVal port As Integer, ByVal timeout As Integer, ByVal useTls As Boolean)
         _sAE = sAE
         _sIP = sIP
         _port = port
         _timeout = timeout
         _useTls = useTls
      End Sub

      Public Overrides Function ToString() As String
         Dim strText As String = _sAE
         Return strText
      End Function

#Region "ICloneable Members"

      Public Function Clone() As Object Implements ICloneable.Clone
         Dim server As MyServer = New MyServer()
         server._port = _port
         server._sAE = _sAE
         server._sIP = _sIP
         server._timeout = _timeout
         server._useTls = _useTls
         Return server
      End Function

#End Region
   End Class

   Public Class MyServerList : Implements ICloneable
      Public serverArrayList As ArrayList

      Public currentServerAE As String

      Public originalServerAE As String
      Public originalServerIP As String
      Public originalServerPort As Integer
      Public preConfigured As Boolean

      Private Const defaultServerAE As String = "LEAD_SERVER"
      Private Const defaultServerIP As String = "127.0.0.1"
      Private Const defaultServerPort As Integer = 104
      Private Const defaultServerTimeout As Integer = 30
      Private Const defaultServerUseTls As Boolean = False


      <XmlElement("servers")> _
      Public Property serverList() As MyServer()
         Get
            Dim items As MyServer() = New MyServer(serverArrayList.Count - 1) {}
            serverArrayList.CopyTo(items)
            Return items
         End Get
         Set(value As MyServer())
            serverArrayList.Clear()
            If Value Is Nothing Then
               Return
            End If
            Dim items As MyServer() = CType(Value, MyServer())

            For Each item As MyServer In items
               serverArrayList.Add(item)
            Next item
         End Set
      End Property


      Public Sub New()
         Dim myServer As MyServer = New MyServer(defaultServerAE, defaultServerIP, defaultServerPort, defaultServerTimeout, defaultServerUseTls)

         serverArrayList = New ArrayList()

         currentServerAE = myServer._sAE
         serverArrayList.Add(myServer)

         originalServerAE = myServer._sAE
         originalServerIP = myServer._sIP
         originalServerPort = myServer._port
         preConfigured = False
      End Sub

      Public Function IsQuerySCPPreconfigured() As Boolean
         Dim ret As Boolean = ((String.Compare(GetSelectedServerAE().Trim(), originalServerAE.Trim(), True) = 0) AndAlso (String.Compare(GetSelectedServerIP().Trim(), originalServerIP.Trim(), True) = 0) AndAlso (GetSelectedServerPort() = originalServerPort))
         Return ret
      End Function

      Public Function GetSelectedServerAE() As String
         For Each s As MyServer In serverArrayList
            If currentServerAE = s._sAE Then
               Return s._sAE
            End If
         Next s
         Return defaultServerAE
      End Function

      Public Function GetSelectedServerIP() As String
         For Each s As MyServer In serverArrayList
            If currentServerAE = s._sAE Then
               Return s._sIP
            End If
         Next s
         Return defaultServerIP
      End Function

      Public Function GetSelectedServerPort() As Integer
         For Each s As MyServer In serverArrayList
            If currentServerAE = s._sAE Then
               Return s._port
            End If
         Next s
         Return defaultServerPort
      End Function

      Public Function GetSelectedQuerySCPServerUseTls() As Boolean
         For Each s As MyServer In serverArrayList
            If currentServerAE = s._sAE Then
               Return s._useTls
            End If
         Next s
         Return defaultServerUseTls
      End Function

      Public Function GetSelectedQuerySCPServerTimeout() As Integer
         For Each s As MyServer In serverArrayList
            If currentServerAE = s._sAE Then
               Return s._timeout
            End If
         Next s
         Return defaultServerTimeout
      End Function

#Region "ICloneable Members"

      Public Function Clone() As Object Implements ICloneable.Clone
         Dim list As MyServerList = New MyServerList()
         list.originalServerAE = originalServerAE
         list.originalServerIP = originalServerIP
         list.originalServerPort = originalServerPort
         list.currentServerAE = currentServerAE
         list.preConfigured = preConfigured
         list.serverArrayList = New ArrayList()
         For Each server As MyServer In serverList
            list.serverArrayList.Add(server.Clone())
         Next server
         Return list
      End Function

#End Region
   End Class

   Public Class MyAppSettings
      <XmlIgnore()> _
      Public _querySCPServers As MyServerList
      Public _queryMWLServers As MyServerList
      Public _storeServers As MyServerList

      Public clientAE As String
      Public clientPort As Integer
      Public clientCertificate As String
      Public privateKey As String
      Public printerName As String
      Public secondaryCapturePath As String
      Public secondaryCaptureCompression As DicomImageCompressionType
      Public secondaryCaptureColorPath As String
      Public secondaryCaptureColorCompression As DicomImageCompressionType
      Public secondaryCaptureGrayPath As String
      Public secondaryCaptureGrayCompression As DicomImageCompressionType
      Public PdfPath As String
      Public TempDir As String
      Public DataPath As String
      Public autodelete As Boolean
      Public privateKeyPassword As String
      Public wiaSelectedDevice As String
      Public TwainSelectedDevice As String
      Public logLowLevel As Boolean
      Public showHelpOnStart As Boolean
      Public UseResample As Boolean
      Public FirstRun As Boolean
      Public DefaultSCPServer As Integer
      Public DefaultMWLServer As Integer
      Public wiaVersion As Integer
      Public LastSelectedIndex As Integer
      Public DefaultStoreServer As Integer
      Public capturetype As CaptureType
      Public selectedtype As DicomClassType
      Private Const defaultClientAE As String = "LEAD_CLIENT"
      Private Const defaultClientPort As Integer = 1000

      Private Shared Function Is64Process() As Boolean
         Return IntPtr.Size = 8
      End Function

      Public Sub New()
         querySCPServers = New MyServerList()
         queryMWLServers = New MyServerList()
         storeServers = New MyServerList()

         clientAE = defaultClientAE
         clientCertificate = String.Empty
         privateKey = String.Empty
         privateKeyPassword = "test"
         logLowLevel = True
         showHelpOnStart = True

#If LTV20_CONFIG Then
         If (Is64Process()) Then
            printerName = "LEADTOOLS 20 PrintToPACS 64-bit"
         Else
            printerName = "LEADTOOLS 20 PrintToPACS 32-bit"
         End If
#End If
         Dim strCommonLocation As String = Path.GetDirectoryName(Application.ExecutablePath)
         strCommonLocation = Path.GetDirectoryName(strCommonLocation)
         strCommonLocation = Path.GetDirectoryName(strCommonLocation)
         strCommonLocation = Path.GetDirectoryName(strCommonLocation)
         strCommonLocation &= "\bin\common\xml"

         If File.Exists(strCommonLocation & "\" & "SC-basic-ds.xml") Then
            secondaryCapturePath = strCommonLocation & "\" & "SC-basic-ds.xml"
         Else
            secondaryCapturePath = ""
         End If

         secondaryCaptureCompression = DicomImageCompressionType.None

         If File.Exists(strCommonLocation & "\" & "SC-Multi-Frame True Color Image-ds.xml") Then
            secondaryCaptureColorPath = strCommonLocation & "\" & "SC-Multi-Frame True Color Image-ds.xml"
         Else
            secondaryCaptureColorPath = ""
         End If

         secondaryCaptureColorCompression = DicomImageCompressionType.None

         If File.Exists(strCommonLocation & "\" & "SC-Multi-Frame Grayscale Byte-ds.xml") Then
            secondaryCaptureGrayPath = strCommonLocation & "\" & "SC-Multi-Frame Grayscale Byte-ds.xml"
         Else
            secondaryCaptureGrayPath = ""
         End If

         secondaryCaptureGrayCompression = DicomImageCompressionType.None

         If File.Exists(strCommonLocation & "\" & "EncapsulatedPDF-Template-ds.xml") Then
            PdfPath = strCommonLocation & "\" & "EncapsulatedPDF-Template-ds.xml"
         Else
            PdfPath = ""
         End If

         TempDir = ""
         UseResample = False
         clientPort = 1000
         selectedtype = DicomClassType.SCImageStorage
         autodelete = False
         capturetype = capturetype.FullScreen
         DefaultSCPServer = 0
         DefaultMWLServer = 0
         DefaultStoreServer = 0
         wiaVersion = 0
         If (Is64Process()) Then
            DataPath = MySettings.GetFolderPath() & "\SerializedData_64.ser"
         Else
            DataPath = MySettings.GetFolderPath() & "\SerializedData_32.ser"
         End If
         FirstRun = True
         LastSelectedIndex = -1
      End Sub

      <XmlElement("SCP servers")> _
      Public Property QuerySCPServers() As MyServerList
         Get
            Return _querySCPServers
         End Get
         Set(value As MyServerList)
            _querySCPServers = Value
         End Set
      End Property

      <XmlElement("MWL servers")> _
      Public Property QueryMWLServers() As MyServerList
         Get
            Return _queryMWLServers
         End Get
         Set(ByVal value As MyServerList)
            _queryMWLServers = value
         End Set
      End Property

      <XmlElement("Store servers")> _
      Public Property StoreServers() As MyServerList
         Get
            Return _storeServers
         End Get
         Set(value As MyServerList)
            _storeServers = Value
         End Set
      End Property
   End Class

   Public Class MySettings
      Public _settings As MyAppSettings
      Public Sub New()
         _settings = New MyAppSettings()
      End Sub

      <DllImport("shfolder.dll", CharSet:=CharSet.Auto)> _
      Private Shared Function SHGetFolderPath(ByVal hwndOwner As IntPtr, ByVal nFolder As Integer, ByVal hToken As IntPtr, ByVal dwFlags As Integer, ByVal lpszPath As StringBuilder) As Integer
      End Function

      Private Const CommonDocumentsFolder As Integer = &H2E

      Public Shared Function GetFolderPath() As String
         Dim lpszPath As StringBuilder = New StringBuilder(260)
         ' CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
         SHGetFolderPath(IntPtr.Zero, CInt(CommonDocumentsFolder), IntPtr.Zero, 0, lpszPath)
         Dim path As String = lpszPath.ToString()
         Dim oTemp As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.PathDiscovery, path)
         oTemp.Demand()
         Return path
      End Function

      Private Shared Function Is64Process() As Boolean
         Return IntPtr.Size = 8
      End Function

      Public Function GetSettingsFilename() As String
         Dim commonFolder As String = GetFolderPath()
         Dim settingsFilename As String

#If (LTV20_CONFIG) Then
         If (Is64Process()) Then
            settingsFilename = commonFolder & "\PrintToPACSDemo_64_20.xml"
         Else
            settingsFilename = commonFolder & "\PrintToPACSDemo_32_20.xml"
         End If
#End If

         Return settingsFilename
      End Function

      Public Sub SavePreconfigure()
         _settings.QuerySCPServers.originalServerAE = _settings.QuerySCPServers.serverList(0)._sAE
         _settings.QuerySCPServers.originalServerIP = _settings.QuerySCPServers.serverList(0)._sIP
         _settings.QuerySCPServers.originalServerPort = _settings.QuerySCPServers.serverList(0)._port
         _settings.QuerySCPServers.preConfigured = True

         _settings.QueryMWLServers.originalServerAE = _settings.QueryMWLServers.serverList(0)._sAE
         _settings.QueryMWLServers.originalServerIP = _settings.QueryMWLServers.serverList(0)._sIP
         _settings.QueryMWLServers.originalServerPort = _settings.QueryMWLServers.serverList(0)._port
         _settings.QueryMWLServers.preConfigured = True

         _settings.StoreServers.originalServerAE = _settings.StoreServers.serverList(0)._sAE
         _settings.StoreServers.originalServerIP = _settings.StoreServers.serverList(0)._sIP
         _settings.StoreServers.originalServerPort = _settings.StoreServers.serverList(0)._port
         _settings.StoreServers.preConfigured = True
         Save()
      End Sub

      Public Sub Save()
         Try
            Dim filename As String = GetSettingsFilename()
            Dim xs As XmlSerializer = New XmlSerializer(GetType(MyAppSettings))
            Dim xmlTextWriter As TextWriter = New StreamWriter(filename)
            xs.Serialize(xmlTextWriter, Me._settings)
            xmlTextWriter.Close()
         Catch e1 As Exception
         End Try
      End Sub

      Public Sub CopyGlobalSettings()
         ' Read the PACSConfigDemo settings
         Dim demoName As String = Path.GetFileName(Application.ExecutablePath)
         Dim globalSettings As DicomDemoSettings = DicomDemoSettingsManager.LoadSettings(demoName)
         If Not globalSettings Is Nothing AndAlso globalSettings.IsPreconfigured AndAlso globalSettings.FirstRun Then
            globalSettings.FirstRun = False

            ' Servers
            Dim defaultStore As DicomAE = globalSettings.GetServer(globalSettings.DefaultStore)
            If Not defaultStore Is Nothing Then
               Dim storeServer As MyServer = New MyServer(defaultStore)
               _settings.StoreServers.serverArrayList.Clear()
               _settings.StoreServers.serverArrayList.Add(storeServer)
            End If

            Dim defaultImageQuery As DicomAE = globalSettings.GetServer(globalSettings.DefaultImageQuery)
            If Not defaultImageQuery Is Nothing Then
               Dim imageQueryServer As MyServer = New MyServer(defaultImageQuery)
               _settings.QuerySCPServers.serverArrayList.Clear()
               _settings.QuerySCPServers.serverArrayList.Add(imageQueryServer)
            End If

            Dim defaultMwlQuery As DicomAE = globalSettings.GetServer(globalSettings.DefaultMwlQuery)
            If Not defaultMwlQuery Is Nothing Then
               Dim mwlQueryServer As MyServer = New MyServer(defaultMwlQuery)
               _settings.QueryMWLServers.serverArrayList.Clear()
               _settings.QueryMWLServers.serverArrayList.Add(mwlQueryServer)
            End If

            ' Client
            _settings.clientAE = globalSettings.ClientAe.AE
            _settings.clientPort = globalSettings.ClientAe.Port

            DicomDemoSettingsManager.SaveSettings(demoName, globalSettings)
            Save()
         End If
      End Sub

      Public Sub Load()
         Dim SerializerObj As XmlSerializer = New XmlSerializer(GetType(MyAppSettings))
         Dim filename As String = GetSettingsFilename()

         If File.Exists(filename) Then
            Try
               ' Create a new file stream for reading the XML file
               Dim ReadFileStream As FileStream = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)

               ' Load the object saved above by using the Deserialize function
               _settings = CType(SerializerObj.Deserialize(ReadFileStream), MyAppSettings)

               ' Cleanup
               ReadFileStream.Close()
            Catch e1 As Exception
            End Try



         End If
      End Sub
   End Class
End Namespace
