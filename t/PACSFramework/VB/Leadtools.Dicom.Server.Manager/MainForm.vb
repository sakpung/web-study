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
Imports System.IO
Imports System.Management
Imports System.Diagnostics
Imports System.Threading
Imports System.ServiceProcess
Imports Leadtools.Dicom.Server.Manager.Dialogs
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Dicom.AddIn
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.DicomDemos
Imports Leadtools.Dicom.Server.Admin
Imports System.Runtime.Remoting.Lifetime
Imports System.Runtime.Remoting
Imports System.Configuration
Imports Leadtools.Medical.Logging.DataAccessLayer.Configuration
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports System.Collections
Imports System.Net.NetworkInformation
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection

Namespace Leadtools.Dicom.Server.Manager
    Partial Public Class MainForm
        Inherits Form
        Private ApplicationDirectory As String = String.Empty
        Private serviceTimer As System.Threading.Timer = Nothing
        Private oldAeInfo As AeInfo = Nothing
        Private administrator As ServiceAdministrator = Nothing
        Private ActiveService As DicomService = Nothing
        Private EnableOptions As Boolean = False
        Private _serviceMessage As ServiceMessage
        Private oldStatus As ServiceControllerStatus = ServiceControllerStatus.Stopped
        Private eventLog As EventLogDialog = Nothing
        Private Const ConnectionName As String = "LeadDicomLogging"
        Private showHelp As Boolean = False

        Public bShowedBadFormatException As Boolean = False
      Public _ipType As DicomNetIpTypeFlags = DicomNetIpTypeFlags.Ipv4OrIpv6

      ' Settings
      Public _mySettings As New DicomDemoSettings()
      Public _demoName As String = Path.GetFileName(Application.ExecutablePath)
      Private _runningPacsConfigDemo As Boolean = False

      Private Sub InitializeServiceAdministrator()
         If administrator IsNot Nothing Then
            RemoveHandler administrator.Error, AddressOf administrator_Error
            RemoveHandler administrator.ServiceRemoved, AddressOf administrator_ServiceRemoved
            RemoveHandler administrator.ServiceAdded, AddressOf administrator_ServiceAdded
            administrator.Dispose()
         End If


         administrator = New ServiceAdministrator(ApplicationDirectory, False)
         AddHandler administrator.Error, AddressOf administrator_Error
         AddHandler administrator.ServiceRemoved, AddressOf administrator_ServiceRemoved
         AddHandler administrator.ServiceAdded, AddressOf administrator_ServiceAdded
#If LEADTOOLS_V175_OR_LATER Then
         administrator.Initialize()
#Else
		 administrator.Unlock(Support.MedicalServerKey)
#End If
      End Sub

        Public Sub New()
            InitializeComponent()
            ApplicationDirectory = Application.StartupPath & "\"

            labelIpAddress.Text = String.Empty
            labelPort.Text = String.Empty
            InitializeStrings()
         Icon = My.Resources.ApplicationIcon

         InitializeServiceAdministrator()
#If LEADTOOLS_V175_OR_LATER Then
            Support.SetLicense()
#Else
            Support.Unlock(False)
#End If

            administrator = New ServiceAdministrator(ApplicationDirectory, False)
            AddHandler administrator.Error, AddressOf administrator_Error
            AddHandler administrator.ServiceRemoved, AddressOf administrator_ServiceRemoved
            AddHandler administrator.ServiceAdded, AddressOf administrator_ServiceAdded

#If LEADTOOLS_V175_OR_LATER Then
            administrator.Initialize()
#Else
		    administrator.Unlock(Support.MedicalServerKey)
#End If
            If System.Net.Sockets.Socket.OSSupportsIPv6 = False Then
                _ipType = DicomNetIpTypeFlags.Ipv4
         End If

         ' Leadtools.Configuration.Logging.dll is shipped (and compiled) in the PACAddins Folder
         ' When a service is created, it is copied to the {ServiceName}/Configuration folder
         ' But it also needs to be in the root, because the demo server references it directly 
         ' So copy it to the root if it is not already there
         ' Note that fully qualified paths must be used so this works properly if run from a shortcut
         Dim pathExe As String = AppDomain.CurrentDomain.BaseDirectory

         Dim loggingConfigurationAssemblyName As String = "Leadtools.Configuration.Logging.dll"
         Dim loggingConfigurationAssemblyName_Path As String = Path.Combine(pathExe, loggingConfigurationAssemblyName)
         If (Not File.Exists(loggingConfigurationAssemblyName_Path)) Then
            Dim shippedLoggingConfiguration As String = Path.Combine("PACSAddIns", loggingConfigurationAssemblyName)
            Dim shippedLoggingConfiguration_Path As String = Path.Combine(pathExe, shippedLoggingConfiguration)
            If File.Exists(shippedLoggingConfiguration_Path) Then
               File.Copy(shippedLoggingConfiguration_Path, loggingConfigurationAssemblyName_Path)
               ' Load the assembly -- For 64-bit version, assembly is not found after copy
               Assembly.Load(String.Format("{0}, Version=1.0.0.0, Culture=neutral", Path.GetFileNameWithoutExtension(loggingConfigurationAssemblyName)))
            End If
         End If

         eventLog = New EventLogDialog(Nothing)
        End Sub

        Private Delegate Sub AddServiceDelegate(ByVal service As DicomService)

      Private Sub administrator_ServiceAdded(ByVal sender As Object, ByVal e As ServiceAddedEventArgs)
         If _runningPacsConfigDemo Then
            Return
         End If
         Invoke(New AddServiceDelegate(AddressOf AddService), e.Service)
      End Sub

        Private Sub AddService(ByVal service As DicomService)
            AddService(service, True)
        End Sub

        Private Delegate Sub RemoveServiceDelegate(ByVal AETitle As String)

      Private Sub administrator_ServiceRemoved(ByVal sender As Object, ByVal e As ServiceRemovedEventArgs)
         If _runningPacsConfigDemo Then
            Return
         End If
         Invoke(New RemoveServiceDelegate(AddressOf RemoveService), e.AETitle)
      End Sub

        Private Sub RemoveService(ByVal AETitle As String)
            Dim removedItem As ComboItemImage = Nothing

            For Each item As ComboItemImage In comboBoxService.Items
                Dim service As DicomService = TryCast(item.Item, DicomService)

                If service.Settings.AETitle = AETitle Then
                    removedItem = item
                    Exit For
                End If
            Next item

            If Not removedItem Is Nothing Then
                comboBoxService.Items.Remove(removedItem)
                labelIpAddress.Text = String.Empty
                labelPort.Text = String.Empty

                If comboBoxService.Items.Count > 0 Then
                    comboBoxService.SelectedIndex = 0
                End If

                comboBoxService.Enabled = comboBoxService.Items.Count > 1
                listViewAeTitles.Items.Clear()
                listViewClients.Items.Clear()
                If comboBoxService.SelectedIndex = -1 Then
                    ActiveService = Nothing
                End If
            End If
        End Sub

        Private Sub administrator_Error(ByVal sender As Object, ByVal e As Leadtools.Dicom.Server.Admin.ErrorEventArgs)
            If (TypeOf e.Error Is BadImageFormatException) AndAlso ((Not bShowedBadFormatException)) Then
                bShowedBadFormatException = True
                Dim msg As String = "Error loading [{0}]." & Constants.vbLf + Constants.vbLf & "This {1}-bit LEADTOOLS DICOM Server Manager process cannot load {2}-bit AddIn dlls, so the AddIn options can not be displayed.  " & "Please use the {3}-bit version of LEADTOOLS DICOM Server Manager to view the AddIn options." & Constants.vbLf + Constants.vbLf & "Note:" & Constants.vbLf & "If you prefer to use the {4}-bit dlls instead of the {5}-bit dlls:" & Constants.vbLf & "* Delete any existing {6}-bit DICOM services using the LEADTOOLS DICOM Server manager" & Constants.vbLf & "* Start the {7}-bit version of the LEADTOOLS DICOM server manager" & Constants.vbLf & "* Add one or more new {8}-bit DICOM services" & Constants.vbLf & "* Copy the {9}-bit AddIn dlls from the PACSAddins folder to the corresponding service AddIns folders"
                Dim sCurrent As String = "32"
                Dim sOther As String = "64"

                Dim message As String = String.Empty

                If Is64() Then
                    sCurrent = "32"
                    sOther = "64"
                Else
                    sCurrent = "64"
                    sOther = "32"
                End If
                message = String.Format(msg, (TryCast(e.Error, BadImageFormatException)).FileName, sOther, sCurrent, sCurrent, sOther, sCurrent, sCurrent, sOther, sOther, sOther, sOther)
                MessageBox.Show(message, "Error Loading AddIn Options", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Sub

        Private Sub InitializeStrings()
            Text = My.Resources.ApplicationTitle
            If (Not DicomDemoSettingsManager.Is64Process()) Then
                Text = Text & " (32 bit)"
            Else
                Text = Text & "(64 bit)"
            End If
            labelServerIp.Text = My.Resources.ServerIpLabel
            labelServerPort.Text = My.Resources.ServerPortLabel
            labelServer.Text = My.Resources.ServerLabel
            tabPageAeTitles.Text = My.Resources.AeTitleTabLabel
            tabPageClients.Text = My.Resources.ClientsTabLabel
            columnIpAddress.Text = My.Resources.IPAddressColumnLabel
            columnAeTitle.Text = My.Resources.AeTitleLabel
            columnConnectTime.Text = My.Resources.ConnectTimeColumnLabel
            columnLastAction.Text = My.Resources.LastActionColumnLabel

            columnHeaderAeTitle.Text = My.Resources.AeTitleLabel
            columnHeaderHostname.Text = My.Resources.HostNamePortColumnLabel
            columnHeaderPort.Text = My.Resources.PortLabel
            columnHeaderSecurePort.Text = My.Resources.SecurePortColumnLabel
        End Sub

        ''' <summary>
        ''' Obtains a lifetime service object to control the lifetime policy for this instance. Returning null makes this a singleton object that doesn't
        ''' expire.
        ''' </summary>
        ''' <returns>
        ''' An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance.
        ''' This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to 
        ''' the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        ''' </returns>
        ''' <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        ''' <PermissionSet>
        ''' 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/>
        ''' </PermissionSet>
        Public Overrides Function InitializeLifetimeService() As Object
            Return Nothing
        End Function

        Private Function IsEval() As Boolean
            Dim isEval_Renamed As Boolean = True
#If LEADTOOLS_V175_OR_LATER Then
            isEval_Renamed = (RasterSupport.KernelType = RasterKernelType.Evaluation AndAlso (Not RasterSupport.KernelExpired))
#Else
		 isEval_Renamed = RasterSupport.KernelType = RasterKernelType.Nag OrElse (RasterSupport.KernelType = RasterKernelType.Evaluation AndAlso (Not RasterSupport.KernelExpired))
#End If
            If isEval_Renamed Then
                Return True
            End If
            Return False
        End Function

      Private Function GetDemoServerAddins(ByVal baseDir As String) As String()
         Dim addinsDir As String = baseDir & "\PACSAddIns\"

         Dim addins As New List(Of String)()
         addins.Add(addinsDir & "Leadtools.AddIn.Find.dll")
         addins.Add(addinsDir & "Leadtools.AddIn.Move.dll")
         addins.Add(addinsDir & "Leadtools.AddIn.Security.dll")
         addins.Add(addinsDir & "Leadtools.AddIn.StorageCommit.dll")
         addins.Add(addinsDir & "Leadtools.AddIn.Store.dll")

         ' Note this is not in the PACSAddins folder
         addins.Add(Path.Combine(baseDir, "Leadtools.Medical.Worklist.AddIns.dll"))
         Return addins.ToArray()
      End Function

      Private Function GetDemoServerConfigurationAddins(ByVal baseDir As String) As String()
         Dim addinsDir As String = baseDir & "\PACSAddIns\"
         Dim addins As New List(Of String)()

         ' Note this is not in the PACSAddins folder
         addins.Add(Path.Combine(addinsDir, "Leadtools.Configuration.Logging.dll"))
         Return addins.ToArray()
      End Function

      Public Shared Sub CopyAddIns(ByVal addins() As String, ByVal service As DicomService, ByVal addinsFolderName As String)
         If addins Is Nothing Then
            Return
         End If

         Dim destDir As String = Path.Combine(service.ServiceDirectory, addinsFolderName)
         If (Not Directory.Exists(destDir)) Then
            Directory.CreateDirectory(destDir)
         End If

         For Each addin As String In addins
            Dim f As New FileInfo(addin)
            Dim newFile As String = Path.Combine(destDir, f.Name)

            Try
               File.Copy(addin, newFile, True)
            Catch e As IOException
               '
               ' If the addin is being used by another process we will not report and
               ' error.
               '
               If (Not e.Message.Contains("being used by another process")) Then
                  Throw e
               End If
            End Try
         Next addin
      End Sub

      Private Sub buttonServiceAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim dialog As New EditServiceDialog(Nothing, GetSettings())
         dialog.IpType = _ipType

         If dialog.ShowDialog(Me) = DialogResult.OK Then
            Try
               Dim service As DicomService = administrator.InstallService(dialog.Settings)

               AddService(service, True)

               CopyAddIns(GetDemoServerAddins(Program.BaseDir), ActiveService, "Addins")
               CopyAddIns(GetDemoServerConfigurationAddins(Program.BaseDir), ActiveService, "Configuration")
            Catch ex As Exception
               MessageBox.Show(ex.Message, "Error Installing Service", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
         End If
      End Sub

        Private Function GetSettings() As List(Of ServerSettings)
            Dim settings As New List(Of ServerSettings)()

            For Each item As ComboItemImage In comboBoxService.Items
                Dim service As DicomService = TryCast(item.Item, DicomService)

                settings.Add(service.Settings)
            Next item

            Return settings
        End Function


 Private Shared Function ExcludeIpv6(ByVal ip As IPAddress) As Boolean
		 Dim sIp As String = ip.ToString()
		 If sIp.Contains(".") Then
			Return True
		 End If

		 If sIp.Contains("fe80::1") Then
			Return True
		 End If

		 Return False
 End Function

	  Public Shared Sub GetIpListsXp(ByVal ipType As DicomNetIpTypeFlags, <System.Runtime.InteropServices.Out()> ByRef ipListIpv4 As ArrayList, <System.Runtime.InteropServices.Out()> ByRef ipListIpv6 As ArrayList)
		 ipListIpv4 = New ArrayList()
		 ipListIpv6 = New ArrayList()

		 ' Obtain a reference to all network interfaces in the machine
		 Dim adapters() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
		 For Each adapter As NetworkInterface In adapters
			If adapter.OperationalStatus = OperationalStatus.Up Then
			   Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
			   For Each uniCast As IPAddressInformation In properties.UnicastAddresses
				  Dim ip As IPAddress = uniCast.Address
				  Dim bLoopback As Boolean = IPAddress.IsLoopback(ip)
				  If (Not IPAddress.IsLoopback(ip)) Then
					 If (ipType And DicomNetIpTypeFlags.Ipv4) = DicomNetIpTypeFlags.Ipv4 Then
						If uniCast.Address.AddressFamily = AddressFamily.InterNetwork Then
						   ipListIpv4.Add(uniCast.Address.ToString())
						End If
					 End If

					 If (ipType And DicomNetIpTypeFlags.Ipv6) = DicomNetIpTypeFlags.Ipv6 Then
						If uniCast.Address.AddressFamily = AddressFamily.InterNetworkV6 Then
						   If (Not ExcludeIpv6(ip)) Then
							  ipListIpv6.Add(uniCast.Address.ToString())
						   End If
						End If
					 End If
				  End If
			   Next uniCast
			End If
		 Next adapter
	  End Sub

	  Public Shared Sub GetIpListsVistaOrHigher(ByVal ipType As DicomNetIpTypeFlags, <System.Runtime.InteropServices.Out()> ByRef ipListIpv4 As ArrayList, <System.Runtime.InteropServices.Out()> ByRef ipListIpv6 As ArrayList)
		 ipListIpv4 = New ArrayList()
		 ipListIpv6 = New ArrayList()

		 Dim searcher As New ManagementObjectSearcher("SELECT * From Win32_NetworkAdapterConfiguration WHERE IPEnabled = 1")
		 If searcher IsNot Nothing Then
			Dim adapters As ManagementObjectCollection = searcher.Get()

			For Each adapter As ManagementObject In adapters
			   Dim ipAddressIpv4 As String = String.Empty
			   Dim ipAddressIpv6 As String = String.Empty
			   Dim ipArray() As String = CType(adapter("IPAddress"), String())

			   If ipArray IsNot Nothing Then
				  If ipArray.Length >= 1 Then
					 ipAddressIpv4 = ipArray(0)
				  End If
				  If ipArray.Length >= 2 Then
					 ipAddressIpv6 = ipArray(1)
				  End If

			   End If
			   If (ipType And DicomNetIpTypeFlags.Ipv4) = DicomNetIpTypeFlags.Ipv4 Then
				  If (Not String.IsNullOrEmpty(ipAddressIpv4)) Then
					 ipListIpv4.Add(ipAddressIpv4)
				  End If
			   End If
			   If (ipType And DicomNetIpTypeFlags.Ipv6) = DicomNetIpTypeFlags.Ipv6 Then
				  If (Not String.IsNullOrEmpty(ipAddressIpv6)) Then
					 ipListIpv6.Add(ipAddressIpv6)
				  End If
			   End If
			Next adapter
		 End If
	  End Sub

	  Private Function GetIpList(ByVal ipType As DicomNetIpTypeFlags) As ArrayList
		 Dim ipListIpv4 As ArrayList = Nothing
		 Dim ipListIpv6 As ArrayList = Nothing

		 If DemosGlobal.IsOnVistaOrLater Then
			MainForm.GetIpListsVistaOrHigher(ipType, ipListIpv4, ipListIpv6)
		 Else
			MainForm.GetIpListsXp(ipType, ipListIpv4, ipListIpv6)
		 End If

		 ipListIpv4.AddRange(ipListIpv6)
		 Return ipListIpv4
	  End Function

        Private Sub SetIpAddressLabel(ByVal ip As String, ByVal ipType As DicomNetIpTypeFlags)
            labelIpAddress.Text = If(ip = "*", "All (hover for details)", ip)
            If ip = "*" Then
                Dim ipList As ArrayList = GetIpList(ipType)
                Dim sTip As String = String.Empty
                For Each s As String In ipList
                    sTip = sTip & s & Constants.vbLf
                Next s

                ' Remove the trailing '\n'
                sTip = sTip.Substring(0, sTip.Length - 1)
                toolTip.SetToolTip(labelIpAddress, sTip)
            Else
                toolTip.SetToolTip(labelIpAddress, "")
            End If
        End Sub


        Private Sub buttonServiceEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonEditServer.Click
            Dim dialog As New EditServiceDialog(AddInUtils.Clone(Of ServerSettings)(ActiveService.Settings), GetSettings())
            dialog.IpType = _ipType

            If dialog.ShowDialog(Me) = DialogResult.OK Then
                ActiveService.Settings = dialog.Settings
                'labelIpAddress.Text = ActiveService.Settings.IpAddress;
                SetIpAddressLabel(ActiveService.Settings.IpAddress, ActiveService.Settings.IpType)
                labelPort.Text = ActiveService.Settings.Port.ToString()
            End If
      End Sub

      ' returns true if a new settings file was created
      ' false if the settings file already exists
      Private Function LoadSettings() As Boolean
         Dim newSettings As Boolean = False
         Try
            _mySettings = Nothing

            Try
               _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName)
            Catch e1 As Exception
            End Try

            If _mySettings Is Nothing Then
               _mySettings = New DicomDemoSettings()
               DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
               newSettings = True
            End If

         Catch ex As Exception
         End Try
         Return newSettings
      End Function

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            CheckLoggingConfiguration()
            If eventLog IsNot Nothing Then
               AddHandler eventLog.FormClosing, AddressOf eventLog_FormClosing
            End If

            Dim newSettings As Boolean = LoadSettings()
            Dim serviceCount As Integer = administrator.Services.Count

            If newSettings AndAlso serviceCount = 0 Then
               _runningPacsConfigDemo = True
               DicomDemoSettingsManager.RunPacsConfigDemo()
               _runningPacsConfigDemo = False
            End If


            If administrator.IsLocked Then
               If administrator.IsLocked Then
                  For Each c As Control In Controls
                     c.Enabled = False
                  Next c
               End If
               labelError.Visible = True
               labelError.Text = "Error: Support is locked!"
               labelError.Enabled = True
            Else
               LoadServices()
               comboBoxService.Enabled = comboBoxService.Items.Count > 0
               toolStripButtonEditServer.Enabled = comboBoxService.Enabled
               toolStripButtonDeleteServer.Enabled = comboBoxService.Enabled
               serviceTimer = New System.Threading.Timer(New TimerCallback(AddressOf CheckServiceStatus))
               serviceTimer.Change(500, 500)
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
        End Sub


	  Private Sub CheckLoggingConfiguration()
         toolStripButtonEventLog.Enabled = True
         eventLog = New EventLogDialog(ActiveService)
      End Sub


        Private Sub eventLog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            toolStripButtonEventLog.Checked = False
        End Sub

        ''' <summary>
        ''' Checks the service status.
        ''' </summary>
        ''' <param name="state">The state.</param>
        Private Sub CheckServiceStatus(ByVal state As Object)
            serviceTimer.Change(Timeout.Infinite, Timeout.Infinite)
            Try
                AsyncHelper.SynchronizedInvoke(Me, AddressOf AnonymousMethod1)
                If ActiveService IsNot Nothing Then
                    '
                    ' Check to see if we need to update our options
                    '
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf AnonymousMethod2)
                Else
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf AnonymousMethod3)
                End If
            Finally

                AsyncHelper.SynchronizedInvoke(Me, AddressOf AnonymousMethod4)
                serviceTimer.Change(100, 100)
            End Try
        End Sub
        Private Sub AnonymousMethod1()
            comboBoxService.Enabled = comboBoxService.Items.Count > 0
            toolStripButtonEditServer.Enabled = comboBoxService.Enabled
            toolStripButtonDeleteServer.Enabled = comboBoxService.Enabled
        End Sub
        Private Sub AnonymousMethod2()
            Dim item As ComboItemImage = TryCast(comboBoxService.SelectedItem, ComboItemImage)
            If item IsNot Nothing Then
                Dim old As Image = item.Image
                Dim running As Boolean = ActiveService.Status = ServiceControllerStatus.Running
                Dim paused As Boolean = ActiveService.Status = ServiceControllerStatus.Paused
                toolStripButtonStart.Enabled = (Not running) OrElse paused
                toolStripButtonStop.Enabled = running OrElse paused
                toolStripButtonPause.Enabled = running
                If oldStatus <> ActiveService.Status Then
                    item.Image = GetStatusImage(ActiveService.Status)
                    oldStatus = ActiveService.Status
                    comboBoxService.Refresh()
                End If
            End If
            If ActiveService IsNot Nothing Then
                If ActiveService.AddInOptions.Count <> listViewOptions.Items.Count Then
                    LoadOptions()
                End If
            End If
        End Sub
        Private Sub AnonymousMethod3()
            toolStripButtonStart.Enabled = False
            toolStripButtonStop.Enabled = False
            toolStripButtonPause.Enabled = False
        End Sub
        Private Sub AnonymousMethod4()
            UpdateUI()
        End Sub

      Public Function GetLogDatabaseFullPath() As String
         If ActiveService Is Nothing Then
            Return String.Empty
         End If

         Debug.Assert((Not String.IsNullOrEmpty(ActiveService.ServiceDirectory)))
         Dim startPath As String = ActiveService.ServiceDirectory
         Dim LogDatabaseFullPath As String = Path.Combine(startPath, EventLogDialog.LogDatabaseName)
         Return LogDatabaseFullPath
      End Function

      Public Function LogDatabaseExists() As Boolean
         Dim logDatabaseFullPath As String = GetLogDatabaseFullPath()
         Dim enableLog As Boolean = File.Exists(logDatabaseFullPath)
         Return enableLog
      End Function

      ''' <summary>
      ''' Updates the UI.
      ''' </summary>
      Private Sub UpdateUI()
         If ActiveService Is Nothing Then
            Return
         End If

         toolStripButtonAddAeTitle.Enabled = ActiveService.IsAdminAvailable
         toolStripButtonEditAeTitle.Enabled = ActiveService.IsAdminAvailable AndAlso listViewAeTitles.SelectedItems.Count > 0
         toolStripButtonDeleteAeTitle.Enabled = ActiveService.IsAdminAvailable AndAlso listViewAeTitles.SelectedItems.Count > 0
         toolStripButtonViewAssociation.Enabled = listViewClients.SelectedItems.Count = 1
         toolStripButtonDisconnectClient.Enabled = toolStripButtonViewAssociation.Enabled

         Dim bLoadDatabaseExists As Boolean = LogDatabaseExists()
         toolStripButtonEventLog.Enabled = bLoadDatabaseExists
         If (Not bLoadDatabaseExists) Then
            If eventLog IsNot Nothing Then
               eventLog.Hide()
            End If
         End If
      End Sub

      Private Function IsServicesValid() As Boolean
         Dim isValid As Boolean = True
         For Each service As KeyValuePair(Of String, DicomService) In administrator.Services
            If service.Value.Settings Is Nothing Then
               isValid = False
            End If
         Next service
         Return isValid
      End Function

      Private Sub LoadServices()

         Dim isValid As Boolean = IsServicesValid()
         If (Not isValid) Then
            InitializeServiceAdministrator()
         End If

         For Each service As KeyValuePair(Of String, DicomService) In administrator.Services
            If service.Value.Settings Is Nothing Then
               ' This shouldn't happen
            End If
            AddService(service.Value, False)
         Next service

         If comboBoxService.Items.Count > 0 AndAlso comboBoxService.SelectedIndex = -1 Then
            comboBoxService.SelectedIndex = 0
         End If
      End Sub

        Private Function IsServiceAdded(ByVal service As DicomService) As Boolean
            For Each item As ComboItemImage In comboBoxService.Items
                Dim s As DicomService = TryCast(item.Item, DicomService)

                If service Is s Then
                    Return True
                End If
            Next item
            Return False
        End Function

        ''' <summary>
        ''' Gets the status image corresponding to the server status.
        ''' </summary>
        ''' <param name="status">The service status.</param>
        ''' <returns></returns>
        Private Function GetStatusImage(ByVal status As ServiceControllerStatus) As Image
            Select Case status
                Case ServiceControllerStatus.Running
                    Return My.Resources.StartService_Image
                Case ServiceControllerStatus.Stopped
                    Return My.Resources.StopService_Image
                Case ServiceControllerStatus.Paused
                    Return My.Resources.PauseService_Image
            End Select
            Return Nothing
      End Function

      Private Function IsServerManagerService(ByVal service As DicomService) As Boolean
         Dim bAddToList As Boolean = True
         For Each addin As IAddInOptions In service.AddInOptions
            If addin.Text.Contains("Media") OrElse addin.Text.Contains("Patient Updater") Then
               bAddToList = False
            End If
         Next addin

         Try
            If bAddToList Then
               ' Check to see if it is a gateway
               Dim gatewayPath As String = Path.Combine(service.ServiceDirectory, "Addins\Leadtools.Medical.Gateway.AddIn.dll")
               bAddToList = Not File.Exists(gatewayPath)
            End If
         Catch e1 As Exception
         End Try

         Return bAddToList
      End Function

      Private Sub AddService(ByVal service As DicomService, ByVal [select] As Boolean)
         If (IsServerManagerService(service) = False) Then
            Return
         End If

         If IsServiceAdded(service) Then
            Return
         End If

         ' Add only if the service has not already been added
         Dim item As New ComboItemImage(service)
         Dim index As Integer = comboBoxService.Items.Add(item)

         item.Image = GetStatusImage(service.Status)
         comboBoxService.Enabled = comboBoxService.Items.Count > 1
         If [select] Then
            comboBoxService.SelectedIndex = index
         End If

         AddHandler service.StatusChange, AddressOf service_StatusChange
         AddHandler service.Message, AddressOf service_Message
      End Sub

        Private Sub MyDelegate5()
            If _serviceMessage.Success Then
                AddAe(TryCast(_serviceMessage.Data(0), AeInfo))
            Else
                ShowError("Error Adding AE Title", _serviceMessage.Error)
            End If
        End Sub

        Private Sub MyDelegate6()
            If _serviceMessage.Success Then
                LoadAes(TryCast(_serviceMessage.Data(0), List(Of AeInfo)))
            Else
                ShowError("Error Getting AE Titles", _serviceMessage.Error)
            End If
        End Sub

        Private Sub MyDelegate7()
            If (Not _serviceMessage.Success) Then
                ShowError("Error Updating AE Title", _serviceMessage.Error)
                UpdateAe(TryCast(_serviceMessage.Data(0), String), TryCast(_serviceMessage.Data(1), AeInfo), True)
            Else
                UpdateAe(TryCast(_serviceMessage.Data(0), String), TryCast(_serviceMessage.Data(1), AeInfo), False)
            End If
        End Sub

        Private Sub MyDelegate8()
            If (Not _serviceMessage.Success) Then
                ShowError("Error Removing AE Title", _serviceMessage.Error)
            Else
                RemoveAe(TryCast(_serviceMessage.Data(0), String))
            End If
        End Sub

      Private Sub MyDelegate9()
         Dim baseIndex As Integer = GetBaseIndex()
         AddClient(TryCast(_serviceMessage.Data(baseIndex), ClientInfo))
      End Sub

      Private Sub MyDelegate10()
         Dim baseIndex As Integer = GetBaseIndex()
         RemoveClient(TryCast(_serviceMessage.Data(baseIndex), ClientInfo))
      End Sub

      Private Sub MyDelegate11()
         Dim baseIndex As Integer = GetBaseIndex()
         UpdateClient(TryCast(_serviceMessage.Data(baseIndex), ClientInfo))
      End Sub

      Private Sub MyDelegate12()
         Dim baseIndex As Integer = GetBaseIndex()
         Dim action As String = TryCast(_serviceMessage.Data(baseIndex), String)
         Dim aetitle As String = TryCast(_serviceMessage.Data(baseIndex + 1), String)

         SetLastAction(action, aetitle)
      End Sub

      Private Function GetBaseIndex() As Integer
         Dim baseIndex As Integer
#If LEADTOOLS_V19_OR_LATER Then
         baseIndex = 1
#Else
         clientInfoIndex = 0
#End If
         Return baseIndex
      End Function

        Private Sub service_Message(ByVal sender As Object, ByVal e As MessageEventArgs)
            '
            ' If message isn't for current service return
            '
            If Not ActiveService Is (TryCast(sender, DicomService)) Then
                Return
            End If

            'Dim m As ServiceMessage = AddInUtils.Clone(Of ServiceMessage)(e.Message)
            _serviceMessage = AddInUtils.Clone(Of ServiceMessage)(e.Message)

            Select Case _serviceMessage.Message
                Case MessageNames.AddAeTitle
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate5)
                Case MessageNames.GetAeTitles
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate6)
                Case MessageNames.UpdateAeTitle
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate7)
                Case MessageNames.RemoveAeTitle
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate8)
                Case MessageNames.ClientConnected
               AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate9)
                Case MessageNames.ClientDisconnected
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate10)
                Case MessageNames.ClientAssociated
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate11)
                Case MessageNames.ClientAction
                    AsyncHelper.SynchronizedInvoke(Me, AddressOf MyDelegate12)
            End Select
        End Sub


        Private Sub service_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
            If ActiveService Is (TryCast(sender, DicomService)) AndAlso ActiveService.Status = ServiceControllerStatus.Running Then
                AsyncHelper.SynchronizedInvoke(Me, AddressOf AnonymousMethod5)
            End If
        End Sub
        Private Sub AnonymousMethod5()
            InitializeService()
        End Sub

        Private Function Is64() As Boolean
            Dim bits As Integer = IntPtr.Size * 8

            Return bits = 64
        End Function

        Private Sub comboBoxService_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxService.SelectedIndexChanged
            Dim item As ComboItemImage = TryCast(comboBoxService.SelectedItem, ComboItemImage)
            ActiveService = TryCast(item.Item, DicomService)

            listViewAeTitles.Items.Clear()
            item.Image = GetStatusImage(ActiveService.Status)
            toolStripButtonEditServer.Enabled = True
            toolStripButtonDeleteServer.Enabled = True

            'labelIpAddress.Text = ActiveService.Settings.IpAddress;
            SetIpAddressLabel(ActiveService.Settings.IpAddress, ActiveService.Settings.IpType)
            labelPort.Text = ActiveService.Settings.Port.ToString()

         ' Log
         If eventLog IsNot Nothing Then
            eventLog.ActiveService = ActiveService
            eventLog.Clear()
            eventLog.UpdateService()
         End If

            '
            ' Load Options
            '
            LoadOptions()

            oldStatus = ActiveService.Status
            If ActiveService.Status = ServiceControllerStatus.Running Then
                InitializeService()
            End If
        End Sub

        Private Sub LoadOptions()
            listViewOptions.Items.Clear()
            imageListOptions.Images.Clear()
            Try
                '
                ' Make a copy of the list because it could change while
                ' we are enumerating.
                '
                Dim list As New List(Of IAddInOptions)(ActiveService.AddInOptions)

                For Each [option] As IAddInOptions In list
                    If (Not IsOptionLoaded([option])) Then
                        AddOption([option])
                    End If
                Next [option]
            Catch
            End Try
        End Sub

        Private Sub AddOption(ByVal [option] As IAddInOptions)
            Dim imageIndex As Integer = 0
            Dim item As ListViewItem = Nothing

            If [option].Image IsNot Nothing Then
                imageListOptions.Images.Add([option].Image.ToImage())
                imageIndex = imageListOptions.Images.Count - 1
            End If

            item = New ListViewItem([option].Text, imageIndex)
            item.Tag = [option]
            item.ToolTipText = "Double-click for options"
            listViewOptions.Items.Add(item)
        End Sub

        Private Function IsOptionLoaded(ByVal [option] As IAddInOptions) As Boolean
            For Each item As ListViewItem In listViewOptions.Items
                Dim o As IAddInOptions = TryCast(item.Tag, IAddInOptions)

                If o.Text = [option].Text Then
                    Return True
                End If
            Next item
            Return False
        End Function

        Private Function IsMedicalWorkstationAddinException(ByVal ex As Exception) As Boolean
            If ex.Message.Contains("LEADTOOLS Medical Workstation AddIn") Then
                Return True
            ElseIf ex.InnerException IsNot Nothing Then
                Return IsMedicalWorkstationAddinException(ex.InnerException)
            Else
                Return False
            End If
        End Function

        Private Sub listViewOptions_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles listViewOptions.DoubleClick
            If listViewOptions.SelectedItems.Count = 1 Then
                Dim [option] As IAddInOptions = TryCast(listViewOptions.SelectedItems(0).Tag, IAddInOptions)

                Try
                    [option].Configure(Me, ActiveService.Settings, ActiveService.ServiceDirectory)
                Catch ex As Exception
                    If IsMedicalWorkstationAddinException(ex) Then
                        MessageBox.Show("This service is used by the Medical Workstation demos. You must run one of the Medical Workstation demos to access this addin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Try
            End If
        End Sub

        ''' <summary>
        ''' Shows the error.
        ''' </summary>
        ''' <param name="Caption">The caption.</param>
        ''' <param name="Message">The message.</param>
        Private Sub ShowError(ByVal Caption As String, ByVal Message As String)
            MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

        Private Sub InitializeService()
            listViewAeTitles.Items.Clear()

            '
            ' Request server ae titles
            '    
            Try
                ActiveService.SendMessage(MessageNames.GetAeTitles)
            Catch ex As Exception
            '  MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadAes(ByVal aes As List(Of AeInfo))
            For Each ae As AeInfo In aes
                AddAe(ae)
            Next ae
        End Sub

        ''' <summary>
        ''' Adds the ae.
        ''' </summary>
        ''' <param name="info">The ae info.</param>
        Private Sub AddAe(ByVal info As AeInfo)
            Dim item As ListViewItem = listViewAeTitles.Items.Add(info.AETitle)

            item.SubItems.Add(info.Address)
            item.SubItems.Add(info.Port.ToString())
            item.SubItems.Add(info.SecurePort.ToString())
            item.Tag = info
        End Sub

        ''' <summary>
        ''' Removes the ae.
        ''' </summary>
        ''' <param name="deleteAE">The delete AE.</param>
        Private Sub RemoveAe(ByVal deleteAE As String)
            For Each item As ListViewItem In listViewAeTitles.Items
                Dim ae As AeInfo = TryCast(item.Tag, AeInfo)

                If ae.AETitle = deleteAE Then
                    listViewAeTitles.Items.Remove(item)
                    Exit For
                End If
            Next item
        End Sub

        ''' <summary>
        ''' Updates the ae.
        ''' </summary>
        ''' <param name="oldAe">The old ae.</param>
        ''' <param name="info">The new ae info.</param>
        Private Sub UpdateAe(ByVal oldAe As String, ByVal info As AeInfo, ByVal failed As Boolean)
            For Each item As ListViewItem In listViewAeTitles.Items
                Dim old As AeInfo = TryCast(item.Tag, AeInfo)

                If old.AETitle = oldAe Then
                    '
                    ' If the update didn't fail we will update the display
                    '
                    If (Not failed) Then
                        item.Text = info.AETitle
                        item.SubItems(1).Text = info.Address
                        item.SubItems(2).Text = info.Port.ToString()
                        item.SubItems(3).Text = info.SecurePort.ToString()
                        item.Tag = info
                    Else
                        item.Tag = oldAeInfo
                    End If
                    Exit For
                End If
            Next item
        End Sub

        ''' <summary>
        ''' Adds the client.
        ''' </summary>
        ''' <param name="client">The client.</param>
      Private Sub AddClient(ByVal client As ClientInfo)
         If client IsNot Nothing Then
            Dim item As ListViewItem = listViewClients.Items.Add(client.IpAddress)

            item.Tag = client
            item.SubItems.Add(client.AETitle)
            item.SubItems.Add(client.ConnectTime.ToString())
            item.SubItems.Add(String.Empty)
         End If
      End Sub

        ''' <summary>
        ''' Removes the client.
        ''' </summary>
        ''' <param name="client">The client.</param>
      Private Sub RemoveClient(ByVal client As ClientInfo)
         If client IsNot Nothing Then
            For Each item As ListViewItem In listViewClients.Items
               Dim lvc As ClientInfo = TryCast(item.Tag, ClientInfo)

               If lvc.Id = client.Id Then
                  listViewClients.Items.Remove(item)
                  Exit For
               End If
            Next item
         End If
      End Sub

        ''' <summary>
        ''' Updates the client.
        ''' </summary>
        ''' <param name="client">The client.</param>
      Private Sub UpdateClient(ByVal client As ClientInfo)
         If client IsNot Nothing Then
            For Each item As ListViewItem In listViewClients.Items
               Dim lvc As ClientInfo = TryCast(item.Tag, ClientInfo)

               If lvc.Id = client.Id Then
                  item.Tag = client
               End If
            Next item
         End If
      End Sub

        ''' <summary>
        ''' Sets the last action.
        ''' </summary>
        ''' <param name="action">The action.</param>
        ''' <param name="aetitle">The aetitle.</param>
        Private Sub SetLastAction(ByVal action As String, ByVal aetitle As String)
            For Each item As ListViewItem In listViewClients.Items
                Dim c As ClientInfo = TryCast(item.Tag, ClientInfo)

                If c.AETitle = aetitle Then
                    item.SubItems(3).Text = action
                    Exit For
                End If
            Next item
        End Sub

        Private Sub buttonStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonStart.Click
            Try
                ActiveService.Start()
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, "Error Starting Service", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub buttonPause_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonPause.Click
            ActiveService.Pause()
        End Sub

        Private Sub buttonStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonStop.Click
            ActiveService.Stop()
            listViewAeTitles.Items.Clear()
            listViewClients.Items.Clear()
        End Sub

        Private Sub toolStripButtonAddAeTitle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonAddAeTitle.Click
            Dim dialog As New EditAeTitleDialog(Nothing)

            If dialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Try
                    ActiveService.SendMessage(MessageNames.AddAeTitle, dialog.AeInfo)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        End Sub

        Private Sub toolStripButtonEditAeTitle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonEditAeTitle.Click
            Dim dialog As New EditAeTitleDialog(TryCast(listViewAeTitles.SelectedItems(0).Tag, AeInfo))
            Dim oldAe As String = dialog.AeInfo.AETitle

            oldAeInfo = AddInUtils.Clone(Of AeInfo)(dialog.AeInfo)
            If dialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Try
                    ActiveService.SendMessage(MessageNames.UpdateAeTitle, oldAe, dialog.AeInfo)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub toolStripButtonDeleteAeTitle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonDeleteAeTitle.Click
            Dim info As AeInfo = TryCast(listViewAeTitles.SelectedItems(0).Tag, AeInfo)

            Try
                ActiveService.SendMessage(MessageNames.RemoveAeTitle, info.AETitle)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub notifyIcon_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
            ShowFromTaskBar()
        End Sub

        ''' <summary>
        ''' Shows from the task bar.
        ''' </summary>
        Public Sub ShowFromTaskBar()
            WindowState = FormWindowState.Normal
            ShowInTaskbar = True
            notifyIcon.Visible = False
        End Sub

        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Close()
        End Sub

        Private Sub toolStripButtonDeleteServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonDeleteServer.Click
            Dim item As ComboItemImage = TryCast(comboBoxService.SelectedItem, ComboItemImage)
            Dim result As DialogResult = System.Windows.Forms.DialogResult.Yes

            '
            ' Disable the ui checking until done
            '
            serviceTimer.Change(Timeout.Infinite, Timeout.Infinite)

            If ActiveService.Status = ServiceControllerStatus.Running Then
                result = MessageBox.Show("Service is currently running" & Constants.vbCrLf & "Do you want to stop and delete?", "Service Running", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = System.Windows.Forms.DialogResult.Yes Then
                    ActiveService.Stop()
                    Do While ActiveService.Status <> ServiceControllerStatus.Stopped
                        Application.DoEvents()
                    Loop
                End If
            End If

            If result = System.Windows.Forms.DialogResult.Yes Then
                Try
                    administrator.UnInstallService(ActiveService)
                    comboBoxService.Items.Remove(item)
                    labelIpAddress.Text = String.Empty
                    labelPort.Text = String.Empty

                    If comboBoxService.Items.Count > 0 Then
                        comboBoxService.SelectedIndex = 0
                    End If

                    comboBoxService.Enabled = comboBoxService.Items.Count > 1
                    listViewAeTitles.Items.Clear()
                    listViewClients.Items.Clear()
                    MessageBox.Show("Service successfully uninstalled", "Service Uninstalled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If comboBoxService.SelectedIndex = -1 Then
                        ActiveService = Nothing
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error Uninstalling Service", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            serviceTimer.Change(500, 500)
        End Sub

        Private Sub toolStripButtonViewAssociation_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim client As ClientInfo = TryCast(listViewClients.SelectedItems(0).Tag, ClientInfo)
            Dim dialog As New AssociationDialog(client)

            dialog.ShowDialog(Me)
        End Sub

        Private Sub toolStripButtonDisconnectClient_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim client As ClientInfo = TryCast(listViewClients.SelectedItems(0).Tag, ClientInfo)

            Try
                ActiveService.SendMessage(MessageNames.DisconnectClient, client)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub MainForm_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
            If WindowState = FormWindowState.Minimized Then
                ShowInTaskbar = False
                notifyIcon.Visible = True
            End If
        End Sub

        Private Sub comboBoxService_DropDown(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxService.DropDown
            For Each item As ComboItemImage In comboBoxService.Items
                If item IsNot comboBoxService.SelectedItem Then
                    Dim service As DicomService = TryCast(item.Item, DicomService)

                    item.Image = GetStatusImage(service.Status)
                End If
            Next item
        End Sub

        Private Sub listViewAeTitles_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
            If toolStripButtonEditAeTitle.Enabled Then
                toolStripButtonEditAeTitle_Click(Me, EventArgs.Empty)
            End If
        End Sub

      Private Sub toolStripButtonStartAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonStartAll.Click
         For Each service As KeyValuePair(Of String, DicomService) In administrator.Services
            If IsServerManagerService(service.Value) Then
               Try
                  If service.Value.Status = ServiceControllerStatus.Paused OrElse service.Value.Status = ServiceControllerStatus.Stopped Then
                     service.Value.Start()
                  End If
               Catch ex As Exception
                  MessageBox.Show(ex.Message, "Error Starting: " & service.Value.Settings.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Error)
               End Try
            End If
         Next service
      End Sub

      Private Sub toolStripButtonStopAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonStopAll.Click
         For Each service As KeyValuePair(Of String, DicomService) In administrator.Services
            If IsServerManagerService(service.Value) Then
               Try
                  If service.Value.Status = ServiceControllerStatus.Paused OrElse service.Value.Status = ServiceControllerStatus.Running Then
                     service.Value.Stop()
                  End If
               Catch ex As Exception
                  MessageBox.Show(ex.Message, "Error Stopping: " & service.Value.Settings.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Error)
               End Try
            End If
         Next service
      End Sub

        Private Sub tabControl1_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabControl1.Selecting
            e.Cancel = e.TabPage Is tabPageClients AndAlso (ActiveService Is Nothing OrElse ActiveService.Status = ServiceControllerStatus.Stopped)
        End Sub

        Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
            If serviceTimer IsNot Nothing Then
                serviceTimer.Change(Timeout.Infinite, Timeout.Infinite)
            End If

            If eventLog IsNot Nothing Then
                eventLog.Close()
                eventLog = Nothing
            End If
        End Sub

        Private Sub toolStripButtonHelp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonHelp.Click
            Dim dlg As New HelpDialog()

            dlg.ShowDialog(Me)
        End Sub

        Private Sub toolStripButtonEventLog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonEventLog.Click
         If toolStripButtonEventLog.Checked Then
            If eventLog Is Nothing OrElse eventLog.IsDisposed Then
               eventLog = New EventLogDialog(ActiveService)
            End If

            eventLog.ActiveService = ActiveService
            eventLog.StartPosition = FormStartPosition.CenterParent
            eventLog.Show(Me)
         Else
            eventLog.Hide()
         End If
        End Sub

        Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
            If My.Settings.Default.ShowHelpAgain Then
                Dim dlg As New HelpDialog()

                dlg.ShowHelpCheckBox = True
                dlg.ShowDialog(Me)
                If dlg.CheckBoxNoShowAgainResult = True Then
                    My.Settings.Default.ShowHelpAgain = False
                    My.Settings.Default.Save()
                End If
            End If
        End Sub
    End Class
End Namespace
