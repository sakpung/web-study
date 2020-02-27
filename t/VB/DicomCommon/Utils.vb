' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.Collections
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Collections.Specialized
Imports System.Runtime.InteropServices

Imports Leadtools
Imports Leadtools.Dicom
Imports System.Net
Imports System.Text
Imports System.Security.Permissions
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms
Imports System.Runtime.Serialization
Imports System.Diagnostics
Imports System.Configuration

#If USE_WINDOWS_API_CODE_PACK Then
Imports Microsoft.WindowsAPICodePack.Dialogs
#End If

Namespace Leadtools.DicomDemos
    <StructLayout(LayoutKind.Sequential)>
    Public Structure POINT
        Public X As Integer
        Public Y As Integer

        Public Sub New(ByVal xVal As Integer, ByVal yVal As Integer)
            Me.X = xVal
            Me.Y = yVal
        End Sub

        Public Shared Widening Operator CType(ByVal p As POINT) As System.Drawing.Point
            Return New System.Drawing.Point(p.X, p.Y)
        End Operator

        Public Shared Widening Operator CType(ByVal p As System.Drawing.Point) As POINT
            Return New POINT(p.X, p.Y)
        End Operator
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure MSG
        Public hwnd As IntPtr
        Public message As UInteger
        Public wParam As IntPtr
        Public lParam As IntPtr
        Public time As UInteger
        Public pt As POINT
    End Structure

    Public Enum WaitReturn
        Complete
        Timeout
    End Enum

    ''' <summary>
    ''' Summary description for Scu.
    ''' </summary>
    Public Class Utils
        <DllImport("user32.dll")>
        Shared Function PeekMessage(<System.Runtime.InteropServices.Out()> ByRef lpMsg As MSG, ByVal hWnd As HandleRef, ByVal wMsgFilterMin As UInteger, ByVal wMsgFilterMax As UInteger, ByVal wRemoveMsg As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")>
        Shared Function TranslateMessage(ByRef lpMsg As MSG) As Boolean
        End Function
        <DllImport("user32.dll")>
        Shared Function DispatchMessage(ByRef lpmsg As MSG) As IntPtr
        End Function

        Private Const PM_REMOVE As UInteger = 1

        Public Shared Function WaitForComplete(ByVal mill As Double, ByVal wh As WaitHandle) As WaitReturn
            Dim goal As TimeSpan = New TimeSpan(DateTime.Now.AddMilliseconds(mill).Ticks)
            Dim msg As MSG = New MSG()
            Dim h As HandleRef = New HandleRef(Nothing, IntPtr.Zero)

            Do
                If PeekMessage(msg, h, 0, 0, PM_REMOVE) Then
                    TranslateMessage(msg)
                    DispatchMessage(msg)
                End If

                If wh.WaitOne(New TimeSpan(1), False) Then
                    Return WaitReturn.Complete
                End If

                If goal.CompareTo(New TimeSpan(DateTime.Now.Ticks)) < 0 Then
                    Return WaitReturn.Timeout
                End If

            Loop While True
            Return WaitReturn.Complete
        End Function

        Public Shared Function WaitForComplete(ByVal mill As Double, ByVal completeHandle As WaitHandle, ByVal resetTimeoutHandle As WaitHandle) As WaitReturn
            Dim goal As New TimeSpan(DateTime.Now.AddMilliseconds(mill).Ticks)
            Dim msg As New MSG()
            Dim h As New HandleRef(Nothing, IntPtr.Zero)

            Dim waitHandles() As WaitHandle = {resetTimeoutHandle, completeHandle}

            Do
                If PeekMessage(msg, h, 0, 0, PM_REMOVE) Then
                    TranslateMessage(msg)
                    DispatchMessage(msg)
                End If

                Dim index As Integer = WaitHandle.WaitAny(waitHandles, New TimeSpan(1), False)

                If index = WaitHandle.WaitTimeout Then
                    If goal.CompareTo(New TimeSpan(DateTime.Now.Ticks)) < 0 Then
                        Return WaitReturn.Timeout
                    End If

                Else
                    Debug.Assert(index = 0 OrElse index = 1)
                    Dim autoEvent As AutoResetEvent = TryCast(waitHandles(index), AutoResetEvent)
                    If autoEvent Is completeHandle Then
                        Return WaitReturn.Complete
                    ElseIf autoEvent Is resetTimeoutHandle Then
                        goal = New TimeSpan(DateTime.Now.AddMilliseconds(mill).Ticks)
                    End If
                End If

            Loop While True

            Return WaitReturn.Complete
        End Function

        Public Shared Sub EngineStartup()
            DicomEngine.Startup()
        End Sub

        Public Shared Sub EngineShutdown()
            DicomEngine.Shutdown()
        End Sub

        Public Shared Sub DicomNetStartup()
            DicomNet.Startup()
        End Sub

        Public Shared Sub DicomNetShutdown()
            DicomNet.Shutdown()
        End Sub

        ''' <summary>
        ''' Helper method to get string value from a DICOM dataset.
        ''' </summary>
        ''' <param name="dcm">The DICOM dataset.</param>
        ''' <param name="tag">Dicom tag.</param>
        ''' <returns>String value of the specified DICOM tag.</returns>
        Public Shared Function GetStringValue(ByVal dcm As DicomDataSet, ByVal tag As Long, ByVal tree As Boolean) As String
            Dim element As DicomElement

            element = dcm.FindFirstElement(Nothing, tag, tree)
            If Not element Is Nothing Then
                If dcm.GetElementValueCount(element) > 0 Then
                    Return dcm.GetConvertValue(element)
                End If
            End If

            Return ""
        End Function

        Public Shared Function GetStringValue(ByVal dcm As DicomDataSet, ByVal tag As Long) As String
            Return GetStringValue(dcm, tag, True)
        End Function

#If (LTV15_CONFIG) Then
      Public Shared Function GetStringValue(ByVal dcm As DicomDataSet, ByVal tag As DicomTagType, ByVal tree As Boolean) As String
         Return GetStringValue(dcm, CLng(tag), tree)
      End Function

      Public Shared Function GetStringValue(ByVal dcm As DicomDataSet, ByVal tag As DicomTagType) As String
      Return GetStringValue(dcm,CLng(tag))
      End Function
#End If

        Public Shared Function GetStringValues(ByVal dcm As DicomDataSet, ByVal tag As Long) As StringCollection
            Dim element As DicomElement
            Dim sc As StringCollection = New StringCollection()

            element = dcm.FindFirstElement(Nothing, tag, True)
            If Not element Is Nothing Then
                If dcm.GetElementValueCount(element) > 0 Then
                    Dim s As String = dcm.GetConvertValue(element)
                    Dim items As String() = s.Split("\"c)

                    For Each value As String In items
                        sc.Add(value)
                    Next value
                End If
            End If

            Return sc
        End Function

#If (LTV15_CONFIG) Then
      Public Shared Function GetStringValues(ByVal dcm As DicomDataSet, ByVal tag As DicomTagType) As StringCollection
         Return GetStringValues(dcm, CLng(tag))
      End Function
#End If

        Public Shared Function GetBinaryValues(ByVal dcm As DicomDataSet, ByVal tag As Long) As Byte()
            Dim element As DicomElement

            element = dcm.FindFirstElement(Nothing, tag, True)
            If Not element Is Nothing Then
                If element.Length > 0 Then
                    Return dcm.GetBinaryValue(element, CInt(element.Length))
                End If
            End If

            Return Nothing
        End Function


#If (LTV15_CONFIG) Then
      Public Shared Function GetBinaryValues(ByVal dcm As DicomDataSet, ByVal tag As DicomTagType) As Byte()
         Return GetBinaryValues(dcm, CLng(tag))
      End Function
#End If

        Public Shared Function IsTagPresent(ByVal dcm As DicomDataSet, ByVal tag As Long) As Boolean
            Dim element As DicomElement

            element = dcm.FindFirstElement(Nothing, tag, True)
            Return (Not element Is Nothing)
        End Function

#If (LTV15_CONFIG) Then
      Public Shared Function IsTagPresent(ByVal dcm As DicomDataSet, ByVal tag As DicomTagType) As Boolean
         Return IsTagPresent(dcm, CLng(tag))
      End Function
#End If

        Public Shared Function IsAscii(ByVal value As String) As Boolean
            Return Encoding.UTF8.GetByteCount(value) = value.Length
        End Function


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dcm"></param>
        ''' <param name="tag"></param>
        ''' <param name="tagValue"></param>
        ''' <returns></returns>
        Public Shared Function SetTag(ByVal dcm As DicomDataSet, ByVal tag As Long, ByVal tagValue As Object, ByVal tree As Boolean) As DicomExceptionCode
            Dim ret As DicomExceptionCode = DicomExceptionCode.Success
            Dim element As DicomElement

            If tagValue Is Nothing Then
                Return DicomExceptionCode.Parameter
            End If

            element = dcm.FindFirstElement(Nothing, tag, tree)
            If element Is Nothing Then
                element = dcm.InsertElement(Nothing, False, tag, DicomVRType.UN, False, 0)
            End If

            If element Is Nothing Then
                Return DicomExceptionCode.Parameter
            End If

            Try
                Dim s As String = tagValue.ToString()
                If IsAscii(s) Then
                    dcm.SetConvertValue(element, s, 1)
                Else
                    dcm.SetStringValue(element, s, DicomCharacterSetType.UnicodeInUtf8)
                End If
            Catch de As DicomException
                ret = de.Code
            End Try

            Return ret
        End Function

        Public Shared Function SetTag(ByVal dcm As DicomDataSet, ByVal tag As Long, ByVal tagValue As Object) As DicomExceptionCode
            Return SetTag(dcm, tag, tagValue, True)
        End Function

        Public Shared Sub CreateTag(ByVal dcm As DicomDataSet, ByVal tag As Long)
            Dim element As DicomElement = dcm.FindFirstElement(Nothing, tag, True)
            If element Is Nothing Then
                element = dcm.InsertElement(Nothing, False, tag, DicomVRType.UN, False, 0)
            End If
        End Sub

#If (LTV15_CONFIG) Then
      Public Shared Sub SetTag(ByVal dcm As DicomDataSet, ByVal seq As DicomTagType, ByVal tag As DicomTagType, ByVal tagValue As Object)
         SetTag(dcm, CLng(seq),CLng(tag), tagValue)
      End Sub
#End If

        Public Shared Sub SetTag(ByVal dcm As DicomDataSet, ByVal Sequence As Long, ByVal Tag As Long, ByVal TagValue As Object)
            Dim seqElement As DicomElement = dcm.FindFirstElement(Nothing, Sequence, True)
            Dim seqItem As DicomElement = Nothing
            Dim item As DicomElement = Nothing

            If seqElement Is Nothing Then
                seqElement = dcm.InsertElement(Nothing, False, Tag, DicomVRType.SQ, True, -1)
            End If

            seqItem = dcm.GetChildElement(seqElement, False)
            If seqItem Is Nothing Then
#If (LTV15_CONFIG) Then
              seqItem = dcm.InsertElement(seqElement, True, DicomTagType.SequenceDelimitationItem, DicomVRType.SQ, True, -1)
#Else
                seqItem = dcm.InsertElement(seqElement, True, DicomTag.SequenceDelimitationItem, DicomVRType.SQ, True, -1)
#End If
            End If

            item = dcm.GetChildElement(seqItem, True)
            Do While Not item Is Nothing
#If (LTV15_CONFIG) Then
              If CLng(item.Tag) = Tag Then
                  Exit Do
              End If
#Else
                If item.Tag = Tag Then
                    Exit Do
                End If
#End If

                item = dcm.GetNextElement(item, True, True)
            Loop

            If item Is Nothing Then
                item = dcm.InsertElement(seqItem, True, Tag, DicomVRType.UN, False, -1)
            End If
            dcm.SetConvertValue(item, TagValue.ToString(), 1)
        End Sub


#If (LTV15_CONFIG) Then
      Public Shared Function SetTag(ByVal dcm As DicomDataSet, ByVal tag As DicomTagType, ByVal tagValue As Object) As DicomExceptionCode
         Return SetTag(dcm, CLng(tag), tagValue)
      End Function

      Public Shared Function SetTag(ByVal dcm As DicomDataSet, ByVal tag As DicomTagType, ByVal tagValue As Object, ByVal tree As Boolean) As DicomExceptionCode
          Return SetTag(dcm, CLng(tag), tagValue, tree)
      End Function

#End If

        Public Shared Function SetTag(ByVal dcm As DicomDataSet, ByVal tag As Long, ByVal tagValue As Byte()) As DicomExceptionCode
            Dim ret As DicomExceptionCode = DicomExceptionCode.Success
            Dim element As DicomElement

            If tagValue Is Nothing Then
                Return DicomExceptionCode.Parameter
            End If

            element = dcm.FindFirstElement(Nothing, tag, True)
            If element Is Nothing Then
                element = dcm.InsertElement(Nothing, False, tag, DicomVRType.UN, False, 0)
            End If

            dcm.SetBinaryValue(element, tagValue, tagValue.Length)

            Return ret
        End Function

#If (LTV15_CONFIG) Then
      Public Shared Function InsertKeyElement(ByVal dcmRsp As DicomDataSet, ByVal dcmReq As DicomDataSet, ByVal tag As DicomTagType) As DicomExceptionCode
         Return InsertKeyElement(dcmRsp, dcmReq, CLng(tag))
      End Function
#End If

        Public Shared Function InsertKeyElement(ByVal dcmRsp As DicomDataSet, ByVal dcmReq As DicomDataSet, ByVal tag As Long) As DicomExceptionCode
            Dim ret As DicomExceptionCode = DicomExceptionCode.Success
            Dim element As DicomElement

            Try
                element = dcmReq.FindFirstElement(Nothing, tag, True)
                If Not element Is Nothing Then
                    dcmRsp.InsertElement(Nothing, False, tag, DicomVRType.UN, False, 0)
                End If
            Catch de As DicomException
                ret = de.Code
            End Try

            Return ret
        End Function


#If (LTV15_CONFIG) Then
       Public Shared Function SetKeyElement(ByVal dcmRsp As DicomDataSet, ByVal tag As DicomTagType, ByVal tagValue As Object) As DicomExceptionCode
           Return SetKeyElement(dcmRsp, CLng(tag), tagValue)
       End Function

       Public Shared Function SetKeyElement(ByVal dcmRsp As DicomDataSet, ByVal tag As DicomTagType, ByVal tagValue As Object, ByVal tree As Boolean) As DicomExceptionCode
           Return SetKeyElement(dcmRsp, CLng(tag), tagValue, tree)
       End Function
#End If

        Public Shared Function SetKeyElement(ByVal dcmRsp As DicomDataSet, ByVal tag As Long, ByVal tagValue As Object, ByVal tree As Boolean) As DicomExceptionCode
            Dim ret As DicomExceptionCode = DicomExceptionCode.Success
            Dim element As DicomElement

            If tagValue Is Nothing Then
                Return DicomExceptionCode.Parameter
            End If

            Try
                element = dcmRsp.FindFirstElement(Nothing, tag, tree)
                If Not element Is Nothing Then
                    dcmRsp.SetConvertValue(element, tagValue.ToString(), 1)
                End If
            Catch de As DicomException
                ret = de.Code
            End Try

            Return ret
        End Function

        Public Shared Function SetKeyElement(ByVal dcmRsp As DicomDataSet, ByVal tag As Long, ByVal tagValue As Object) As DicomExceptionCode
            Return SetKeyElement(dcmRsp, tag, tagValue, True)
        End Function

        Public Shared Function GetGroup(ByVal tag As Long) As UInt16
            Return (CUShort(tag >> 16))
        End Function

        Public Shared Function GetElement(ByVal tag As Long) As Integer
            Return (CUShort(tag And &HFFFF))
        End Function

        ' Creates a properly formatted Dicom Unique Identifier (VR type of UI) value
        Private Shared _prevTime As String
        Private Shared _leadRoot As String = Nothing
        Private Shared _lock As Object = New Object()
        Private Shared _count As Integer = 0
        Private Const _maxCount As Integer = Integer.MaxValue

        ' UID is comprised of the following components
        ' {LEAD Root}.{ProcessID}.{date}.{time}.{fraction seconds}.{counter}
        ' {18 +      1 + 10 +    1 + 8 +1 + 6+ 1 + 7              + 10}
        ' Total max length is 63 characters
        Public Shared Function GenerateDicomUniqueIdentifier() As String
            Try
                SyncLock _lock
                    ' yyyy     four digit year
                    ' MM       month from 01 to 12
                    ' dd       01 to 31
                    ' HH       hours using a 24-hour clock form 00 to 23
                    ' mm       minute 00 to 59
                    ' ss       second 00 to 59
                    ' fffffff  ten millionths of a second
                    Const dateFormatString As String = "yyyyMMdd.HHmmss.fffffff"

                    Dim sUidRet As String = ""
                    If _leadRoot Is Nothing Then
                        Dim sb As New StringBuilder()

                        sb.Append("1.2.840.114257.1.1")

                        ' Process Id
                        sb.AppendFormat(".{0}", CUInt(Process.GetCurrentProcess().Id))

                        _leadRoot = sb.ToString()

                        _prevTime = DateTime.UtcNow.ToString(dateFormatString)
                    End If

                    Dim uid As New StringBuilder()
                    uid.Append(_leadRoot)

                    Dim time As String = DateTime.UtcNow.ToString(dateFormatString)
                    If time.Equals(_prevTime) Then
                        If _count = _maxCount Then
                            Throw New Exception("GenerateDicomUniqueIdentifier error -- max count reached.")
                        End If

                        _count += 1
                    Else
                        _count = 1
                        _prevTime = time
                    End If

                    uid.AppendFormat(".{0}.{1}", time, _count)

                    sUidRet = uid.ToString()

                    ' This should not happen
                    If sUidRet.Length > 64 Then
                        sUidRet = sUidRet.Substring(0, 64)
                    End If

                    Return sUidRet
                End SyncLock
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function IsLocalIPAddress(ByVal hostNameOrAddress As String) As Boolean
            If hostNameOrAddress.ToLower() = Dns.GetHostName().ToLower() Then
                Return True
            Else
                Dim serviceAddress As IPAddress = Nothing

                If IPAddress.TryParse(hostNameOrAddress, serviceAddress) Then
                    If IPAddress.IsLoopback(serviceAddress) Then
                        Return True
                    Else
                        Dim localAddresses() As IPAddress


                        localAddresses = Dns.GetHostAddresses(Dns.GetHostName())

                        For Each localAddress As IPAddress In localAddresses
                            If localAddress.Equals(serviceAddress) Then
                                Return True
                            End If
                        Next localAddress
                    End If
                End If
            End If

            Return False
        End Function


        Public Shared Function ResolveIPAddress(ByVal hostNameOrAddress As String) As System.Net.IPAddress
            Dim addresses() As IPAddress
            addresses = Dns.GetHostAddresses(hostNameOrAddress.Trim())
            If addresses Is Nothing OrElse addresses.Length = 0 Then
                Throw New ArgumentException("Invalid hostNameOrAddress parameter.")
            Else
                For Each address As IPAddress In addresses
                    If address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork OrElse address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetworkV6 Then
                        Return address
                    End If
                Next address
                Throw New ArgumentException("Could not resolve a valid host Address. Address must conform to IPv4 or IPv6.")
            End If
        End Function

#If LEADTOOLS_V175_OR_LATER Then

        ' Returns string.empty if valid
        ' Otherwise, returns an error message
        Public Shared Function IsValidHostnameOrAddress(ByVal hostNameOrAddress As String, <System.Runtime.InteropServices.Out()> ByRef [error] As String) As Boolean
            Dim isValid As Boolean = True
            [error] = String.Empty

            If (hostNameOrAddress Is Nothing) OrElse (String.IsNullOrEmpty(hostNameOrAddress.Trim())) Then
                [error] = "Host address must be non-empty"
                Return False
            End If
            Try
                Utils.ResolveIPAddress(hostNameOrAddress)
            Catch exception As Exception
                [error] = exception.Message
                isValid = False
            End Try
            Return isValid
        End Function

        Public Shared Function IsValidApplicationEntity(ByVal aeTitle As String, <System.Runtime.InteropServices.Out()> ByRef [error] As String) As Boolean
            [error] = String.Empty

            If aeTitle Is Nothing Then
                [error] = "Application Entity must not be empty"
                Return False
            End If

            aeTitle = aeTitle.Trim()
            If String.IsNullOrEmpty(aeTitle) Then
                [error] = "Application Entity must not be empty"
                Return False
            End If

            If aeTitle.Length > 16 Then
                [error] = "Application Entity must contain 16 characters or less."
                Return False
            End If

            If aeTitle.Contains("\") Then
                [error] = "Application Entity must not contain the '\' character"
                Return False
            End If

            Return True
        End Function
#End If ' LEADTOOLS_V175_OR_LATER
        Public Shared Function VerifyOpensslVersion(ByVal owner As Form) As Boolean
            Dim isValid As Boolean = True
            Dim version As DicomOpenSslVersion = DicomNet.GetOpenSslVersion()
            If version.IsAvailable = False Then
                ShowMessageBoxWithHyperlinks(owner, version.DownloadMessage, "Download OpenSSL")
                isValid = False
            End If
            Return isValid
        End Function

        Public Shared Sub ShowMessageBoxWithHyperlinks(ByVal owner As Form, ByVal message As String, ByVal caption As String)
            Dim successfulMessageBox As Boolean = False
#If USE_WINDOWS_API_CODE_PACK Then
         Try
            ShowTaskDialogWithHyperlinks(owner, message, caption)
            successfulMessageBox = True
         Catch e1 As Exception

         End Try
#End If ' #if USE_WINDOWS_API_CODE_PACK
            If (Not successfulMessageBox) Then
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub

#If USE_WINDOWS_API_CODE_PACK Then
      Public Shared Sub ShowTaskDialogWithHyperlinks(ByVal owner As Form, ByVal message As String, ByVal caption As String)
         ' If TaskDialog() throws exception:
         '   TaskDialog feature needs to load version 6 of comctl32.dll but a different version is current loaded in memory
         ' then add this line of code in the Main() of your application
         '   Application.EnableVisualStyles();

         Dim taskDialog As New TaskDialog()

         If owner IsNot Nothing Then
            taskDialog.OwnerWindowHandle = owner.Handle
         End If

         AddHandler taskDialog.HyperlinkClick, AddressOf TaskDialog_HyperlinkClick
         AddHandler taskDialog.Opened, AddressOf TaskDialog_Opened
         taskDialog.HyperlinksEnabled = True

         taskDialog.Caption = caption

         taskDialog.StartupLocation = TaskDialogStartupLocation.CenterOwner

         taskDialog.InstructionText = caption

         Dim strings() As String = message.Split(New Char() { ControlChars.Cr, ControlChars.Lf }, StringSplitOptions.RemoveEmptyEntries)

         For Each s As String In strings
            If s.ToLower().StartsWith("http") Then
               Dim newString As String = String.Format("<A HREF=""{0}"">{0} </A>", s)
               message = message.Replace(s, newString)
            End If
         Next s

         taskDialog.Text = message
         taskDialog.Show()
      End Sub

      Private Shared Sub TaskDialog_Opened(ByVal sender As Object, ByVal e As EventArgs)
         Dim taskDialog As TaskDialog = TryCast(sender, TaskDialog)
         If taskDialog IsNot Nothing Then
            taskDialog.Icon = TaskDialogStandardIcon.Information
            taskDialog.InstructionText = taskDialog.InstructionText
         End If
      End Sub

      Private Shared Sub TaskDialog_HyperlinkClick(ByVal sender As Object, ByVal e As TaskDialogHyperlinkClickedEventArgs)
         If (Not String.IsNullOrEmpty(e.LinkText)) Then
            Process.Start(e.LinkText)
         End If
      End Sub
#End If '    #if USE_WINDOWS_API_CODE_PACK
    End Class

    <Serializable()>
    Public Class DicomAE
        Public Sub New()
            _sAE = String.Empty
            _sIP = String.Empty
            _port = 0
            _timeout = 0
            _useTls = False
        End Sub

        Public Sub New(ByVal sAE As String, ByVal sIP As String, ByVal portVal As Integer, ByVal timeoutVal As Integer, ByVal useTlsVal As Boolean)
            _sAE = sAE
            _sIP = sIP
            _port = portVal
            _timeout = timeoutVal
            _useTls = useTlsVal
        End Sub

        Public Overrides Function ToString() As String
            Dim name As String = _sAE
            If _useTls Then
                name = name & "  (Secure)"
            End If
            Return name
        End Function

        Public Property AE() As String
            Get
                Return _sAE
            End Get

            Set(ByVal value As String)
                _sAE = value
            End Set
        End Property

        Public Property IPAddress() As String
            Get
                Return _sIP
            End Get

            Set(ByVal value As String)
                _sIP = value
            End Set
        End Property

        Public Property Port() As Integer
            Get
                Return _port
            End Get

            Set(ByVal value As Integer)
                _port = value
            End Set
        End Property

        Public Property Timeout() As Integer
            Get
                Return _timeout
            End Get

            Set(ByVal value As Integer)
                _timeout = value
            End Set
        End Property

        Public Property UseTls() As Boolean
            Get
                Return _useTls
            End Get

            Set(ByVal value As Boolean)
                _useTls = value
            End Set
        End Property



        Private _sAE As String
        Private _sIP As String
        Private _port As Integer
        Private _timeout As Integer
        Private _useTls As Boolean
    End Class


    Public Class DicomDemoSettingsManager
        Public Shared ReadOnly Property GlobalPacsConfigFilename() As String
            Get
                Return "GlobalPacs.config"
            End Get
        End Property

        Public Shared ReadOnly Property GlobalPacsConfigFullFileName() As String
            Get
                Return Path.Combine(Application.StartupPath, GlobalPacsConfigFilename)
            End Get
        End Property

#If LEADTOOLS_V175_OR_LATER Then
        'Public Shared Function GetGlobalPacsConfiguration() As System.Configuration.Configuration
        'Dim configFile As New ExeConfigurationFileMap()
        'configFile.ExeConfigFilename = DicomDemoSettingsManager.GlobalPacsConfigFullFileName
        'configFile.MachineConfigFilename = DicomDemoSettingsManager.GlobalPacsConfigFullFileName
        'Dim mappedConfiguration As System.Configuration.Configuration = ConfigurationManager.OpenMappedMachineConfiguration(configFile)
        'Return mappedConfiguration

        'End Function

        'Public Shared Function GetGlobalPacsAddinsConfiguration(ByVal ServiceDirectory As String) As System.Configuration.Configuration
        'Dim addInsConfigFile As String = Path.Combine(ServiceDirectory, "..\\" & GlobalPacsConfigFilename)
        'Dim addInsConfigFileMap As New ExeConfigurationFileMap()
        'addInsConfigFileMap.MachineConfigFilename = addInsConfigFile
        'addInsConfigFileMap.ExeConfigFilename = addInsConfigFile
        'Dim configuration As System.Configuration.Configuration = ConfigurationManager.OpenMappedMachineConfiguration(addInsConfigFileMap)
        'Return configuration
        'End Function
#End If

        Public Const StorageDataAccessConfiguration As String = "storageDataAccessConfiguration175"
        Public Const LoggingDataAccessConfiguration As String = "loggingDataAccessConfiguration175"
        Public Const MediaCreationDataAccessConfiguration As String = "mediaCreationDataAccessConfiguration175"
        Public Const UserManagementConfigurationSample As String = "userManagementConfigurationSample175"
        Public Const WorkListDataAccessConfiguration As String = "workListDataAccessConfiguration175"
        Public Const WorkstationDataAccessConfiguration As String = "workstationDataAccessConfiguration175"
        Public Const OptionsConfiguration As String = "optionsConfiguration175"
        Public Const AeManagementConfiguration As String = "aeManagementConfiguration175"
        Public Const AePermissionManagementConfiguration As String = "aePermissionManagementConfiguration175"
        Public Const PermissionManagementConfiguration As String = "permissionManagementConfiguration175"
        Public Const ForwardConfiguration As String = "forwardConfiguration175"
        Public Const DownloadJobsConfiguration As String = "DownloadJobsConfiguration175"
        Public Const PatientRightsConfiguration As String = "patientRightsConfiguration175"

        Public Const ProductNameStorageServer As String = "StorageServer"

        Public Const ProductNameDemoServer As String = "DemoServer"

        Public Const ProductNameWorkstation As String = "Workstation"

        Public Const ProductNamePatientUpdater As String = "PatientUpdater"

        Public Const ProductNameMedicalViewer As String = "MedicalViewer"

        Public Const ProductDentalApp As String = "DentalClient"

        Public Const ProductNameGateway As String = "Gateway"

        Public Shared Sub RunPacsConfigDemo()
            Dim caption As String = "Note"
            Dim message As String = "Please run the PACSConfigDemo to configure this and other PACS Framework demos." & Constants.vbLf + Constants.vbLf & "Would you like to run the PACSConfigDemo now?"

            Dim dr As DialogResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If DialogResult.Yes = dr Then
                Dim pacsConfigDemoFileName As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsConfigDemo_Original.exe")

                If (Not File.Exists(pacsConfigDemoFileName)) Then
                    pacsConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsConfigDemo.exe")
                End If

                If File.Exists(pacsConfigDemoFileName) Then
                    Dim pacConfigProcess As New Process()
                    pacConfigProcess.StartInfo.FileName = pacsConfigDemoFileName

                    pacConfigProcess.Start()
                    pacConfigProcess.WaitForExit()
                Else
                    MessageBox.Show("Could not find the CSPacsConfigDemo.", "Warning", MessageBoxButtons.OK)
                End If
            End If
        End Sub

        Public Shared Sub SaveSettings(ByVal demoName As String, ByVal settings As DicomDemoSettings)
            Try
                Dim filename As String = GetSettingsFilename(demoName)
                Dim xs As XmlSerializer = New XmlSerializer(GetType(DicomDemoSettings))
                Dim xmlTextWriter As TextWriter = New StreamWriter(filename)
                xs.Serialize(xmlTextWriter, settings)
                xmlTextWriter.Close()
            Catch e1 As Exception
                Throw
            End Try
        End Sub

        Public Shared Function LoadSettings(ByVal demoName As String) As DicomDemoSettings
            Dim settingsLoaded As Boolean = False

            Dim SerializerObj As New XmlSerializer(GetType(DicomDemoSettings))
            Dim filename As String = GetSettingsFilename(demoName)

            If File.Exists(filename) Then
                Dim settings As DicomDemoSettings = Nothing

                Try
                    ' Create a new file stream for reading the XML file
                    Using ReadFileStream As TextReader = New StreamReader(filename)
                        ' Load the object saved above by using the Deserialize function
                        settings = CType(SerializerObj.Deserialize(ReadFileStream), DicomDemoSettings)

                        ' Cleanup
                        ReadFileStream.Close()
                        settingsLoaded = True
                    End Using
                Catch e1 As Exception
                    settingsLoaded = False
                End Try
                If settingsLoaded Then
                    SerializerObj = Nothing

                    If settings IsNot Nothing AndAlso settings.CipherSuites.ItemList.Count = 0 Then
                        settings.CipherSuites.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256))
                        settings.CipherSuites.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384))
                        settings.CipherSuites.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256))
                        settings.CipherSuites.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384))
                    End If

                    Return settings
                End If
            End If
            Return Nothing
        End Function


        <DllImport("shfolder.dll", CharSet:=CharSet.Auto)>
        Private Shared Function SHGetFolderPath(ByVal hwndOwner As IntPtr, ByVal nFolder As Integer, ByVal hToken As IntPtr, ByVal dwFlags As Integer, ByVal lpszPath As StringBuilder) As Integer
        End Function

        Private Const CommonDocumentsFolder As Integer = &H2E

        Public Shared Function GetFolderPath() As String
            Dim lpszPath As StringBuilder = New StringBuilder(260)
            ' CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
            SHGetFolderPath(IntPtr.Zero, CInt(CommonDocumentsFolder), IntPtr.Zero, 0, lpszPath)
            Dim path As String = lpszPath.ToString()
            CType(New FileIOPermission(FileIOPermissionAccess.PathDiscovery, path), FileIOPermission).Demand()
            Return path
        End Function

        Public Enum InstallPlatform
            win32 = 0
            x64 = 1
        End Enum

        Public Shared Function GetSettingsFilename(ByVal demo As String, ByVal platform As InstallPlatform) As String
            Dim commonFolder As String = GetFolderPath()
            Dim sPlatform As String = "32"

            If platform = InstallPlatform.x64 Then
                sPlatform = "64"
            Else
                sPlatform = "32"
            End If

            Dim ext As String = Path.GetExtension(demo)
            Dim name As String = Path.GetFileNameWithoutExtension(demo)

#If (LTV20_CONFIG) Then
            Dim settingsFilename As String = String.Format("{0}\{1}{2}{3}_20.xml", commonFolder, name, sPlatform, ext)
#ElseIf (LTV19_CONFIG) Then
         Dim settingsFilename As String = String.Format("{0}\{1}{2}{3}_19.xml", commonFolder, name, sPlatform, ext)
#ElseIf (LTV18_CONFIG) Then
         Dim settingsFilename As String = String.Format("{0}\{1}{2}{3}_18.xml", commonFolder, name, sPlatform, ext)
#ElseIf (LTV175_CONFIG) Then
         Dim settingsFilename As String = String.Format("{0}\{1}{2}{3}_175.xml", commonFolder, name, sPlatform, ext)
#Else
         Dim settingsFilename As String = String.Format("{0}\{1}{2}{3}_17.xml", commonFolder, name, sPlatform, ext)
#End If
            Return settingsFilename
        End Function

        Public Shared Function GetSettingsFilename(ByVal demo As String) As String
            Dim commonFolder As String = GetFolderPath()
            If Is64Process() Then
                Return GetSettingsFilename(demo, InstallPlatform.x64)
            Else
                Return GetSettingsFilename(demo, InstallPlatform.win32)
            End If
        End Function


        Public Shared Function Is64Process() As Boolean
            Return IntPtr.Size = 8
        End Function

        Public Shared Function GetCertificateAuthorityFullPath() As String
            Dim fileCertificateAuthority As String = Application.StartupPath & "\ca.pem"
            If (Not File.Exists(fileCertificateAuthority)) Then
                fileCertificateAuthority = String.Empty
            End If
            Return fileCertificateAuthority
        End Function

        Public Shared Function GetClientCertificateFullPath() As String
            Dim fileClientCertificate As String = Application.StartupPath & "\client.pem"
            If (Not File.Exists(fileClientCertificate)) Then
                fileClientCertificate = String.Empty
            End If
            Return fileClientCertificate
        End Function

        Public Shared Function GetClientCertificatePassword() As String
            Dim password As String = String.Empty
            Dim fileClientCertificate As String = GetClientCertificateFullPath()
            If (Not String.IsNullOrEmpty(fileClientCertificate)) Then
                password = "test"
            End If
            Return password
        End Function

    End Class

    Public Enum DicomRetrieveMode
        CMove = 0
        CGet = 1
    End Enum

    <Serializable>
    Public Class CipherSuiteItem
        Private privateIsChecked As Boolean
        Public Property IsChecked() As Boolean
            Get
                Return privateIsChecked
            End Get
            Set(ByVal value As Boolean)
                privateIsChecked = value
            End Set
        End Property
        Public Cipher As DicomTlsCipherSuiteType

        Public Sub New()
            IsChecked = False
            Cipher = DicomTlsCipherSuiteType.None
        End Sub

        Public Sub New(ByVal isChecked As Boolean, ByVal cipher As DicomTlsCipherSuiteType)
            Me.IsChecked = isChecked
            Me.Cipher = cipher
        End Sub

        Public Sub New(ByVal isChecked As Boolean, ByVal cipher As String)
            Me.IsChecked = isChecked
            Me.Cipher = CipherStringToType(cipher)
        End Sub

        Public Function IsEqual(ByVal i As CipherSuiteItem) As Boolean
            Dim _isEqual As Boolean = True

            If _isEqual Then
                _isEqual = (i.IsChecked = IsChecked)
            End If
            If _isEqual Then
                _isEqual = (i.Cipher = Cipher)
            End If
            Return _isEqual
        End Function

        Public Function Serialize() As String
            Return String.Format("{0},{1}", Me.Cipher.ToString(), Me.IsChecked.ToString())
        End Function

        Friend Shared Function MyParseEnum(Of T)(ByVal value As String) As T
            Return CType(System.Enum.Parse(GetType(T), value, True), T)
        End Function

        Public Shared Function Deserialize(ByVal s As String) As CipherSuiteItem
            Dim item As CipherSuiteItem = Nothing
            Dim itemStrings() As String = s.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
            If itemStrings.Length = 2 Then
                Dim isChecked As Boolean = Convert.ToBoolean(itemStrings(1))
                Dim cipherSuiteType As DicomTlsCipherSuiteType = MyParseEnum(Of DicomTlsCipherSuiteType)(itemStrings(0))
                item = New CipherSuiteItem(isChecked, cipherSuiteType)
            End If
            Return item
        End Function

        Public Overrides Function ToString() As String
            Return CipherTypeToString(Cipher)
        End Function

        Public ReadOnly Property IsTls_1_2() As Boolean
            Get
                Dim isTls_1_2_Renamed As Boolean =
               (Cipher = DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256) OrElse
               (Cipher = DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256) OrElse
               (Cipher = DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384) OrElse
               (Cipher = DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384)
                Return isTls_1_2_Renamed
            End Get
        End Property

        Private Function CipherStringToType(ByVal cipherString As String) As DicomTlsCipherSuiteType
            Dim cipherResult As DicomTlsCipherSuiteType = DicomTlsCipherSuiteType.None

            If String.Compare(cipherString, "TLS_RSA_WITH_AES_128_CBC_SHA") = 0 Then
                cipherResult = DicomTlsCipherSuiteType.RsaWithAes128CbcSha
            ElseIf String.Compare(cipherString, "TLS_RSA_WITH_3DES_EDE_CBC_SHA") = 0 Then
                cipherResult = DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha
            ElseIf String.Compare(cipherString, "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256") = 0 Then
                cipherResult = DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256
            ElseIf String.Compare(cipherString, "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256") = 0 Then
                cipherResult = DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256
            ElseIf String.Compare(cipherString, "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384") = 0 Then
                cipherResult = DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384
            ElseIf String.Compare(cipherString, "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384") = 0 Then
                cipherResult = DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384
            End If

            If cipherResult = DicomTlsCipherSuiteType.None Then
                Debug.Assert(cipherResult <> DicomTlsCipherSuiteType.None)
            End If
            Return cipherResult
        End Function

        Private Function CipherTypeToString(ByVal cipherType As DicomTlsCipherSuiteType) As String
            Dim cipherString As String = String.Empty

            Select Case cipherType
                Case DicomTlsCipherSuiteType.RsaWithAes128CbcSha
                    cipherString = "TLS_RSA_WITH_AES_128_CBC_SHA"

                Case DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha
                    cipherString = "TLS_RSA_WITH_3DES_EDE_CBC_SHA"

                Case DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256
                    cipherString = "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256"

                Case DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256
                    cipherString = "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256"

                Case DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384
                    cipherString = "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384"

                Case DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384
                    cipherString = "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384"
            End Select

            Return cipherString
        End Function
    End Class

    <Serializable>
    Public Class CipherSuiteItems
        Private _cipherSuiteItemList As New List(Of CipherSuiteItem)()

        Public Sub New()
        End Sub

        Public Shared Function Deserialize(ByVal s As String) As CipherSuiteItems
            Dim items As New CipherSuiteItems()
            items.Clear()

            Dim cipherStringList() As String = s.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
            For Each cipherString As String In cipherStringList
                Dim item As CipherSuiteItem = CipherSuiteItem.Deserialize(cipherString)
                items.ItemList.Add(item)
            Next cipherString

            Return items
        End Function

        Public Function Serialize() As String
            Dim returnString As String = String.Empty
            For Each item As CipherSuiteItem In ItemList
                returnString = returnString & ";" & item.Serialize()
            Next item

            If returnString.Length > 0 Then
                returnString = returnString.Substring(1)
            End If

            Return returnString
        End Function

        Public Shared Function Serialize(ByVal cipherSuiteItems As CipherSuiteItems) As String
            Dim xmlSerializer As New XmlSerializer(GetType(CipherSuiteItems))
            Using textWriter As New StringWriter()
                xmlSerializer.Serialize(textWriter, cipherSuiteItems)
                Return textWriter.ToString()
            End Using
        End Function

        Public Function IsEqual(ByVal c As CipherSuiteItems) As Boolean
            Dim _isEqual As Boolean = True
            If _isEqual Then
                _isEqual = (c.ItemList.Count = ItemList.Count)
            End If

            If _isEqual Then
                For i As Integer = 0 To c.ItemList.Count - 1
                    Dim item1 As CipherSuiteItem = TryCast(c.ItemList(i), CipherSuiteItem)
                    Dim item2 As CipherSuiteItem = TryCast(ItemList(i), CipherSuiteItem)
                    If item1 IsNot Nothing AndAlso item2 IsNot Nothing Then
                        _isEqual = _isEqual AndAlso item1.IsEqual(item2)
                    End If

                Next i
            End If

            Return _isEqual
        End Function

        Public Sub Clear()
            _cipherSuiteItemList.Clear()
        End Sub

        Public Sub [Default]()
            Clear()
            ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256))
            ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384))
            ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256))
            ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384))
        End Sub

        Public ReadOnly Property ItemList() As List(Of CipherSuiteItem)
            Get
                Return _cipherSuiteItemList
            End Get
        End Property

        Public Function Contains(ByVal cipherSuiteName As String) As Boolean
            For Each cipherSuiteItem As CipherSuiteItem In _cipherSuiteItemList
                If cipherSuiteItem.ToString() = cipherSuiteName Then
                    Return True
                End If
            Next cipherSuiteItem
            Return False
        End Function

        Public Function AddOldCipherSuites() As Boolean
            Dim changed As Boolean = False
            Dim onlyTLS12CipherSuites As Boolean = True
            For Each cipherSuiteItem As CipherSuiteItem In _cipherSuiteItemList
                If cipherSuiteItem.IsTls_1_2 = False Then
                    onlyTLS12CipherSuites = False
                End If
            Next cipherSuiteItem

            If onlyTLS12CipherSuites Then
                _cipherSuiteItemList.Add(New CipherSuiteItem(False, DicomTlsCipherSuiteType.RsaWithAes128CbcSha))
                _cipherSuiteItemList.Add(New CipherSuiteItem(False, DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha))
                changed = True
            End If
            Return changed
        End Function

        Public Function RemoveOldCipherSuites() As Boolean
            Dim changed As Boolean = False
            Dim cipherSuiteItemCount As Integer = _cipherSuiteItemList.Count
            For i As Integer = cipherSuiteItemCount - 1 To 0 Step -1
                If _cipherSuiteItemList(i).IsTls_1_2 = False Then
                    _cipherSuiteItemList.RemoveAt(i)
                    changed = True
                End If
            Next i
            Return changed
        End Function

        Public Function ContainsOldCipherSuites() As Boolean
            Dim containsOldCipherSuites_Renamed As Boolean = False
            For i As Integer = 0 To _cipherSuiteItemList.Count - 1
                If _cipherSuiteItemList(i).IsTls_1_2 = False Then
                    containsOldCipherSuites_Renamed = True
                    Exit For
                End If
            Next i
            Return containsOldCipherSuites_Renamed
        End Function

        Public Class ClientPortSecurityTypeItem
            Private _clientSecurity As ClientPortUsageType
            Public Property ClientSecurity() As ClientPortUsageType
                Get
                    Return _clientSecurity
                End Get
                Set(ByVal value As ClientPortUsageType)
                    _clientSecurity = value
                End Set
            End Property
            Private _description As String
            Public Property Description() As String
                Get
                    Return _description
                End Get
                Set(ByVal value As String)
                    _description = value
                End Set
            End Property
            Public Sub New(ByVal clientSecurity As ClientPortUsageType, ByVal description As String)
                _clientSecurity = clientSecurity
                _description = description
            End Sub

            Public Overrides Function ToString() As String
                Return Description
            End Function
        End Class

    End Class

    <Serializable()>
    Public Class DicomDemoSettings
        Implements IWorkstationSettings
        Public Sub New()
            ServerList = New List(Of DicomAE)()
            FileList = New List(Of String)()
            ClientAe = New DicomAE()
            _logLowLevel = False
            _groupLengthDataElements = False
            _showHelpOnStart = True
            _isPreconfigured = False
            _firstRun = True
            _compression = 0
            _broadQuery = False
            _excludeList = New List(Of Long)()
            _storageClassList = New List(Of String)()
            _dicomRetrieveMode = DicomRetrieveMode.CMove
            _storageCommitResultsOnSameAssociation = True
            _clientSecurity = ClientPortUsageType.Unsecure
            _cipherSuiteItems = New CipherSuiteItems()
            _cipherSuiteItems.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256))
            _cipherSuiteItems.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384))
            _cipherSuiteItems.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256))
            _cipherSuiteItems.ItemList.Add(New CipherSuiteItem(True, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384))
        End Sub

        Private _cipherSuiteItems As CipherSuiteItems
        Private _serverArrayList As List(Of DicomAE)
        Private _fileArrayList As List(Of String)
        Private _clientAe As DicomAE
        Private _defaultStore As String
        Private _defaultImageQuery As String
        Private _defaultMwlQuery As String
        Private _defaultMpps As String
        Private _clientCertificate As String
        Private _certificateAuthority As String
        Private _clientSecurity As ClientPortUsageType

        Private _clientPrivateKey As String
        Private _clientPrivateKeyPassword As String
        Private _workstationServer As String
        Private _highLevelStorageServer As String
        Private _logLowLevel As Boolean
        Private _groupLengthDataElements As Boolean
        Private _showHelpOnStart As Boolean
        Private _isPreconfigured As Boolean
        Private _firstRun As Boolean
        Private _compression As Integer
        Private _dataPath As String
        Private _broadQuery As Boolean
        Private _excludeList As List(Of Long)
        Private _temporaryDirectory As String
        Private _implementationClass As String
        Private _protocolVersion As String
        Private _implementationVersionName As String
        Private _storageClassList As List(Of String)
        Private _dicomRetrieveMode As DicomRetrieveMode
        Private _disableLogging As Boolean
        Private _storageCommitResultsOnSameAssociation As Boolean

        Public Function GetServer(ByVal sa As String) As DicomAE Implements IWorkstationSettings.GetServer
            Dim ret As DicomAE = Nothing
            For Each ae As DicomAE In _serverArrayList
                If String.Compare(ae.AE, sa, True) = 0 Then
                    ret = ae
                End If
            Next ae
            Return ret
        End Function

        Public Function GetServerAe(ByVal sa As String) As String
            Dim ae As DicomAE = GetServer(sa)
            If Not ae Is Nothing Then
                Return ae.AE
            Else
                Return String.Empty
            End If
        End Function

        Public Function GetServerPort(ByVal sa As String) As Integer
            Dim ae As DicomAE = GetServer(sa)
            If Not ae Is Nothing Then
                Return ae.Port
            Else
                Return 0
            End If
        End Function

        '[XmlElement("servers")]
        Public Property ServerList() As List(Of DicomAE) Implements IWorkstationSettings.ServerList
            Get
                Return _serverArrayList
            End Get

            Set(ByVal value As List(Of DicomAE))
                _serverArrayList = value
            End Set
        End Property

        Public Property CipherSuites() As CipherSuiteItems
            Get
                Return _cipherSuiteItems
            End Get
            Set(ByVal value As CipherSuiteItems)
                _cipherSuiteItems = value
            End Set
        End Property

        Public Property FileList() As List(Of String)
            Get
                Return _fileArrayList
            End Get

            Set(ByVal value As List(Of String))
                _fileArrayList = value
            End Set
        End Property

        Public Property ClientAe() As DicomAE Implements IWorkstationSettings.ClientAe
            Get
                Return _clientAe
            End Get
            Set(ByVal value As DicomAE)
                _clientAe = value
            End Set
        End Property

        Public Property DefaultStore() As String Implements IWorkstationSettings.DefaultStore
            Get
                Return _defaultStore
            End Get
            Set(ByVal value As String)
                _defaultStore = value
            End Set
        End Property


        Public Property DefaultImageQuery() As String Implements IWorkstationSettings.DefaultImageQuery
            Get
                Return _defaultImageQuery
            End Get
            Set(ByVal value As String)
                _defaultImageQuery = value
            End Set
        End Property


        Public Property DefaultMwlQuery() As String
            Get
                Return _defaultMwlQuery
            End Get
            Set(ByVal value As String)
                _defaultMwlQuery = value
            End Set
        End Property

        Public Property DefaultMpps() As String
            Get
                Return _defaultMpps
            End Get
            Set(ByVal value As String)
                _defaultMpps = value
            End Set
        End Property


        Public Property CertificateAuthority() As String
            Get
                Return _certificateAuthority
            End Get
            Set(ByVal value As String)
                _certificateAuthority = value
            End Set
        End Property

        Public Property ClientCertificate() As String
            Get
                Return _clientCertificate
            End Get
            Set(ByVal value As String)
                _clientCertificate = value
            End Set
        End Property

        Public Property ClientPortSecurityUsage() As ClientPortUsageType
            Get
                Return _clientSecurity
            End Get
            Set(ByVal value As ClientPortUsageType)
                _clientSecurity = value
            End Set
        End Property

        Public Property ClientPrivateKey() As String
            Get
                Return _clientPrivateKey
            End Get
            Set(ByVal value As String)
                _clientPrivateKey = value
            End Set
        End Property

        Public Property ClientPrivateKeyPassword() As String
            Get
                Return _clientPrivateKeyPassword
            End Get
            Set(ByVal value As String)
                _clientPrivateKeyPassword = value
            End Set
        End Property

        Public Property WorkstationServer() As String Implements IWorkstationSettings.WorkstationServer
            Get
                Return _workstationServer
            End Get
            Set(ByVal value As String)
                _workstationServer = value
            End Set
        End Property

        Public Property HighLevelStorageServer() As String
            Get
                Return _highLevelStorageServer
            End Get
            Set(ByVal value As String)
                _highLevelStorageServer = value
            End Set
        End Property

        Public Property LogLowLevel() As Boolean
            Get
                Return _logLowLevel
            End Get
            Set(ByVal value As Boolean)
                _logLowLevel = value
            End Set
        End Property

        Public Property GroupLengthDataElements() As Boolean
            Get
                Return _groupLengthDataElements
            End Get
            Set(ByVal value As Boolean)
                _groupLengthDataElements = value
            End Set
        End Property

        Public Property ShowHelpOnStart() As Boolean
            Get
                Return _showHelpOnStart
            End Get
            Set(ByVal value As Boolean)
                _showHelpOnStart = value
            End Set
        End Property

        Public Property IsPreconfigured() As Boolean
            Get
                Return _isPreconfigured
            End Get
            Set(ByVal value As Boolean)
                _isPreconfigured = value
            End Set
        End Property

        Public Property Compression() As Integer
            Get
                Return _compression
            End Get
            Set(ByVal value As Integer)
                _compression = value
            End Set
        End Property

        Public Property FirstRun() As Boolean
            Get
                Return _firstRun
            End Get
            Set(ByVal value As Boolean)
                _firstRun = value
            End Set
        End Property

        Public Property DataPath() As String
            Get
                Return _dataPath
            End Get
            Set(ByVal value As String)
                _dataPath = value
            End Set
        End Property

        Public Property BroadQuery() As Boolean
            Get
                Return _broadQuery
            End Get
            Set(ByVal value As Boolean)
                _broadQuery = value
            End Set
        End Property

        Public Property ExcludeList() As List(Of Long)
            Get
                Return _excludeList
            End Get
            Set(ByVal value As List(Of Long))
                _excludeList = value
            End Set
        End Property

        Public Property StorageClassList() As List(Of String)
            Get
                Return _storageClassList
            End Get
            Set(ByVal value As List(Of String))
                _storageClassList = value
            End Set
        End Property

        Public Property TemporaryDirectory() As String
            Get
                Return _temporaryDirectory
            End Get
            Set(ByVal value As String)
                _temporaryDirectory = value
            End Set
        End Property

        Public Property ImplementationClass() As String
            Get
                Return _implementationClass
            End Get
            Set(ByVal value As String)
                _implementationClass = value
            End Set
        End Property

        Public Property ProtocolVersion() As String
            Get
                Return _protocolVersion
            End Get
            Set(ByVal value As String)
                _protocolVersion = value
            End Set
        End Property

        Public Property ImplementationVersionName() As String
            Get
                Return _implementationVersionName
            End Get
            Set(ByVal value As String)
                _implementationVersionName = value
            End Set
        End Property

        Private _ViewerBeforeSend As Boolean = False

        Public Property ViewerBeforeSend() As Boolean
            Get
                Return _ViewerBeforeSend
            End Get
            Set(ByVal value As Boolean)
                _ViewerBeforeSend = value
            End Set
        End Property

        Public Property DicomImageRetrieveMethod() As DicomRetrieveMode
            Get
                Return _dicomRetrieveMode
            End Get
            Set(ByVal value As DicomRetrieveMode)
                _dicomRetrieveMode = value
            End Set
        End Property

        Public Property DisableLogging As Boolean
            Get
                Return _disableLogging
            End Get
            Set(value As Boolean)
                _disableLogging = value
            End Set
        End Property

        Public Property StorageCommitResultsOnSameAssociation As Boolean
            Get
                Return _storageCommitResultsOnSameAssociation
            End Get
            Set(value As Boolean)
                _storageCommitResultsOnSameAssociation = value
            End Set
        End Property
    End Class

    Public Interface IWorkstationSettings
        Property ServerList() As List(Of DicomAE)

        Property ClientAe() As DicomAE

        Property WorkstationServer() As String

        Property DefaultImageQuery() As String

        Property DefaultStore() As String

        Function GetServer(ByVal serverName As String) As DicomAE
    End Interface

    Public Class Templates
        Public Const MWLFind As String = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCr & vbLf & "                                 <!--LEAD Technologies, Inc. DICOM XML format-->" & vbCr & vbLf & "                                 <dataset IgnoreBinaryData=""false"" IgnoreAllData=""false"" EncodeBinaryBase64=""true"" EncodeBinaryBinHex=""false"" TagWithCommas=""false"" TrimWhiteSpace=""false"">" & vbCr & vbLf & "                                   <element tag=""00020002"" vr=""UI"" vm=""1"" len=""22"" name=""MediaStorageSOPClassUID"">1.2.840.10008.5.1.4.31</element>" & vbCr & vbLf & "                                   <element tag=""00020010"" vr=""UI"" vm=""1"" len=""20"" name=""TransferSyntaxUID"">1.2.840.10008.1.2.1</element>" & vbCr & vbLf & "                                   <element tag=""00080005"" vr=""CS"" vm=""0"" len=""0"" name=""SpecificCharacterSet"" />" & vbCr & vbLf & "                                   <element tag=""00080050"" vr=""SH"" vm=""0"" len=""0"" name=""AccessionNumber"" />" & vbCr & vbLf & "                                   <element tag=""00080080"" vr=""LO"" vm=""0"" len=""0"" name=""InstitutionName"" />" & vbCr & vbLf & "                                   <element tag=""00080081"" vr=""ST"" vm=""0"" len=""0"" name=""InstitutionAddress"" />" & vbCr & vbLf & "                                   <element tag=""00080090"" vr=""PN"" vm=""0"" len=""0"" name=""ReferringPhysicianName"" />" & vbCr & vbLf & "                                   <element tag=""00081110"" vr=""SQ"" vm=""0"" len=""-1"" name=""ReferencedStudySequence"" />" & vbCr & vbLf & "                                   <element tag=""00081120"" vr=""SQ"" vm=""0"" len=""-1"" name=""ReferencedPatientSequence"">" & vbCr & vbLf & "                                     <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"">" & vbCr & vbLf & "                                       <element tag=""00081150"" vr=""UI"" vm=""0"" len=""0"" name=""ReferencedSOPClassUID"" />" & vbCr & vbLf & "                                       <element tag=""00081155"" vr=""UI"" vm=""0"" len=""0"" name=""ReferencedSOPInstanceUID"" />" & vbCr & vbLf & "                                     </element>" & vbCr & vbLf & "                                   </element>" & vbCr & vbLf & "                                   <element tag=""00100010"" vr=""PN"" vm=""0"" len=""0"" name=""PatientName"" />" & vbCr & vbLf & "                                   <element tag=""00100020"" vr=""LO"" vm=""0"" len=""0"" name=""PatientID"" />" & vbCr & vbLf & "                                   <element tag=""00100030"" vr=""DA"" vm=""0"" len=""0"" name=""PatientBirthDate"" />" & vbCr & vbLf & "                                   <element tag=""00100040"" vr=""CS"" vm=""0"" len=""0"" name=""PatientSex"" />" & vbCr & vbLf & "                                   <element tag=""00101000"" vr=""LO"" vm=""0"" len=""0"" name=""OtherPatientIDs"" />" & vbCr & vbLf & "                                   <element tag=""00101001"" vr=""PN"" vm=""0"" len=""0"" name=""OtherPatientNames"" />" & vbCr & vbLf & "                                   <element tag=""00101030"" vr=""DS"" vm=""0"" len=""0"" name=""PatientWeight"" />" & vbCr & vbLf & "                                   <element tag=""00101040"" vr=""LO"" vm=""0"" len=""0"" name=""PatientAddress"" />" & vbCr & vbLf & "                                   <element tag=""00102000"" vr=""LO"" vm=""0"" len=""0"" name=""MedicalAlerts"" />" & vbCr & vbLf & "                                   <element tag=""00102110"" vr=""LO"" vm=""0"" len=""0"" name=""Allergies"" />" & vbCr & vbLf & "                                   <element tag=""001021B0"" vr=""LT"" vm=""0"" len=""0"" name=""AdditionalPatientHistory"" />" & vbCr & vbLf & "                                   <element tag=""001021C0"" vr=""US"" vm=""0"" len=""0"" name=""PregnancyStatus"" />" & vbCr & vbLf & "                                   <element tag=""00104000"" vr=""LT"" vm=""0"" len=""0"" name=""PatientComments"" />" & vbCr & vbLf & "                                   <element tag=""0020000D"" vr=""UI"" vm=""0"" len=""0"" name=""StudyInstanceUID"" />" & vbCr & vbLf & "                                   <element tag=""00321032"" vr=""PN"" vm=""0"" len=""0"" name=""RequestingPhysician"" />" & vbCr & vbLf & "                                   <element tag=""00321033"" vr=""LO"" vm=""0"" len=""0"" name=""RequestingService"" />" & vbCr & vbLf & "                                   <element tag=""00321060"" vr=""LO"" vm=""0"" len=""0"" name=""RequestedProcedureDescription"" />" & vbCr & vbLf & "                                   <element tag=""00321064"" vr=""SQ"" vm=""0"" len=""-1"" name=""RequestedProcedureCodeSequence"">" & vbCr & vbLf & "                                     <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"" />" & vbCr & vbLf & "                                   </element>" & vbCr & vbLf & "                                   <element tag=""00380010"" vr=""LO"" vm=""0"" len=""0"" name=""AdmissionID"" />" & vbCr & vbLf & "                                   <element tag=""00380050"" vr=""LO"" vm=""0"" len=""0"" name=""SpecialNeeds"" />" & vbCr & vbLf & "                                   <element tag=""00380300"" vr=""LO"" vm=""0"" len=""0"" name=""CurrentPatientLocation"" />" & vbCr & vbLf & "                                   <element tag=""00380500"" vr=""LO"" vm=""0"" len=""0"" name=""PatientState"" />" & vbCr & vbLf & "                                   <element tag=""00400100"" vr=""SQ"" vm=""0"" len=""-1"" name=""ScheduledProcedureStepSequence"">" & vbCr & vbLf & "                                     <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"">" & vbCr & vbLf & "                                       <element tag=""00080060"" vr=""CS"" vm=""0"" len=""0"" name=""Modality"" />" & vbCr & vbLf & "                                       <element tag=""00321070"" vr=""LO"" vm=""0"" len=""0"" name=""RequestedContrastAgent"" />" & vbCr & vbLf & "                                       <element tag=""00400001"" vr=""AE"" vm=""0"" len=""0"" name=""ScheduledStationAETitle"" />" & vbCr & vbLf & "                                       <element tag=""00400002"" vr=""DA"" vm=""0"" len=""0"" name=""ScheduledProcedureStepStartDate"" />" & vbCr & vbLf & "                                       <element tag=""00400003"" vr=""TM"" vm=""0"" len=""0"" name=""ScheduledProcedureStepStartTime"" />" & vbCr & vbLf & "                                       <element tag=""00400006"" vr=""PN"" vm=""0"" len=""0"" name=""ScheduledPerformingPhysicianName"" />" & vbCr & vbLf & "                                       <element tag=""00400007"" vr=""LO"" vm=""0"" len=""0"" name=""ScheduledProcedureStepDescription"" />" & vbCr & vbLf & "                                       <element tag=""00400008"" vr=""SQ"" vm=""0"" len=""-1"" name=""ScheduledProtocolCodeSequence"">" & vbCr & vbLf & "                                         <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"" />" & vbCr & vbLf & "                                       </element>" & vbCr & vbLf & "                                       <element tag=""00400009"" vr=""SH"" vm=""0"" len=""0"" name=""ScheduledProcedureStepID"" />" & vbCr & vbLf & "                                       <element tag=""00400010"" vr=""SH"" vm=""0"" len=""0"" name=""ScheduledStationName"" />" & vbCr & vbLf & "                                       <element tag=""00400011"" vr=""SH"" vm=""0"" len=""0"" name=""ScheduledProcedureStepLocation"" />" & vbCr & vbLf & "                                       <element tag=""00400012"" vr=""LO"" vm=""0"" len=""0"" name=""PreMedication"" />" & vbCr & vbLf & "                                       <element tag=""00400020"" vr=""CS"" vm=""0"" len=""0"" name=""ScheduledProcedureStepStatus"" />" & vbCr & vbLf & "                                       <element tag=""00400400"" vr=""LT"" vm=""0"" len=""0"" name=""CommentsOnTheScheduledProcedureStep"" />" & vbCr & vbLf & "                                     </element>" & vbCr & vbLf & "                                   </element>" & vbCr & vbLf & "                                   <element tag=""00401001"" vr=""SH"" vm=""0"" len=""0"" name=""RequestedProcedureID"" />" & vbCr & vbLf & "                                   <element tag=""00401002"" vr=""LO"" vm=""0"" len=""0"" name=""ReasonForTheRequestedProcedure"" />" & vbCr & vbLf & "                                   <element tag=""00401003"" vr=""SH"" vm=""0"" len=""0"" name=""RequestedProcedurePriority"" />" & vbCr & vbLf & "                                   <element tag=""00401010"" vr=""PN"" vm=""0"" len=""0"" name=""NamesOfIntendedRecipientsOfResults"" />" & vbCr & vbLf & "                                   <element tag=""00402001"" vr=""LO"" vm=""0"" len=""0"" name=""ReasonForTheImagingServiceRequest"" />" & vbCr & vbLf & "                                   <element tag=""00402016"" vr=""LO"" vm=""0"" len=""0"" name=""PlacerOrderNumberImagingServiceRequest"" />" & vbCr & vbLf & "                                   <element tag=""00402017"" vr=""LO"" vm=""0"" len=""0"" name=""FillerOrderNumberImagingServiceRequest"" />" & vbCr & vbLf & "                                   <element tag=""00402400"" vr=""LT"" vm=""0"" len=""0"" name=""ImagingServiceRequestComments"" />" & vbCr & vbLf & "                                   <element tag=""00403001"" vr=""LO"" vm=""0"" len=""0"" name=""ConfidentialityConstraintOnPatientDataDescription"" />" & vbCr & vbLf & "                                 </dataset>"
    End Class

    <Serializable>
    Public Class StorageServerInformation
        Public Sub New()
            Me.New(Nothing, Nothing, Nothing)
        End Sub
        Public Sub New(ByVal server As DicomAE, ByVal serviceName As String, ByVal machineName As String)
            DicomServer = server
            serviceName = serviceName
            machineName = machineName
        End Sub

        Private privateDicomServer As DicomAE
        Public Property DicomServer() As DicomAE
            Get
                Return privateDicomServer
            End Get
            Set(ByVal value As DicomAE)
                privateDicomServer = value
            End Set
        End Property
        Private privateServiceName As String
        Public Property ServiceName() As String
            Get
                Return privateServiceName
            End Get
            Set(ByVal value As String)
                privateServiceName = value
            End Set
        End Property
        Private privateMachineName As String
        Public Property MachineName() As String
            Get
                Return privateMachineName
            End Get
            Set(ByVal value As String)
                privateMachineName = value
            End Set
        End Property
    End Class

    Friend Module Extensions
        ' converts an enum value to an integer
        <System.Runtime.CompilerServices.Extension()>
        Public Function ToInt(ByVal enumValue As System.Enum) As Integer
            Return CInt(Fix(CObj(enumValue)))
        End Function

        ' returns true if the flags 'field' has the flag 'value' set
        <System.Runtime.CompilerServices.Extension()>
        Public Function IsFlagged(ByVal field As System.Enum, ByVal value As System.Enum) As Boolean
            Return (field.ToInt() And value.ToInt()) = value.ToInt()
        End Function
    End Module

    Public Module SecurityExtensions
        Public Enum MoveDirection
            Up = -1
            Down = 1
        End Enum

        <System.Runtime.CompilerServices.Extension>
        Public Sub MoveListViewItems(ByVal myListView As ListView, ByVal direction As MoveDirection)
            Dim valid As Boolean = myListView.SelectedItems.Count > 0 AndAlso ((direction = MoveDirection.Down AndAlso (myListView.SelectedItems(myListView.SelectedItems.Count - 1).Index < myListView.Items.Count - 1)) OrElse (direction = MoveDirection.Up AndAlso (myListView.SelectedItems(0).Index > 0)))

            If valid Then
                Dim start As Boolean = True
                Dim firstIndex As Integer = 0
                Dim items As New List(Of ListViewItem)()

                For Each i As ListViewItem In myListView.SelectedItems
                    If start Then
                        firstIndex = i.Index
                        start = False
                    End If
                    items.Add(i)
                Next i

                myListView.BeginUpdate()
                For Each i As ListViewItem In myListView.SelectedItems
                    i.Remove()
                Next i

                ' insert
                If direction = MoveDirection.Up Then
                    Dim insertTo As Integer = firstIndex - 1
                    For Each i As ListViewItem In items
                        Dim item As ListViewItem = myListView.Items.Insert(insertTo, i)
                        item.Selected = True
                        insertTo += 1
                    Next i
                Else
                    Dim insertTo As Integer = firstIndex + 1
                    For Each i As ListViewItem In items
                        myListView.Items.Insert(insertTo, i)
                        insertTo += 1
                    Next i
                End If
                myListView.EndUpdate()
            End If
            myListView.Focus()
        End Sub


        <System.Runtime.CompilerServices.Extension>
        Public Sub InitializeCipherListView(ByVal listView As ListView, ByVal cipherSuites As CipherSuiteItems, ByVal imageListCiphers As ImageList)

            listView.View = View.Details
            listView.CheckBoxes = True
            listView.MultiSelect = True
            listView.HideSelection = False
            listView.SmallImageList = imageListCiphers

            listView.Columns.Add("Cipher", 300)
            listView.Columns.Add("TLS Version", 80)

            UpdateCipherSuitesListView(listView, cipherSuites)
        End Sub

        <System.Runtime.CompilerServices.Extension>
        Public Sub ListViewToCipherSuites(ByVal listView As ListView, ByVal cipherSuites As CipherSuiteItems, ByVal initializing As Boolean)
            If initializing Then
                Return
            End If

            cipherSuites.Clear()
            For Each listViewItem As ListViewItem In listView.Items
                Dim cipherSuiteItem As New CipherSuiteItem(listViewItem.Checked, listViewItem.Text)
                cipherSuites.ItemList.Add(cipherSuiteItem)
            Next listViewItem
        End Sub

        <System.Runtime.CompilerServices.Extension>
        Public Sub UpdateCipherSuitesListView(ByVal listView As ListView, ByVal cipherSuites As CipherSuiteItems)
            If listView.Items.Count = 0 Then
                For Each cipherSuiteItem As CipherSuiteItem In cipherSuites.ItemList
                    Dim item As ListViewItem = listView.Items.Add(cipherSuiteItem.ToString(), If(cipherSuiteItem.IsTls_1_2, 2, 1))
                    item.SubItems.Add(If(cipherSuiteItem.IsTls_1_2, "1.2", "1.0"))
                    item.Checked = cipherSuiteItem.IsChecked
                Next cipherSuiteItem
            Else
                Dim addCount As Integer = cipherSuites.ItemList.Count - listView.Items.Count
                If addCount > 0 Then
                    For i As Integer = 0 To addCount - 1
                        Dim cipherSuiteItem As CipherSuiteItem = cipherSuites.ItemList(listView.Items.Count)
                        Dim item As ListViewItem = listView.Items.Add(cipherSuiteItem.ToString(), If(cipherSuiteItem.IsTls_1_2, 2, 1))
                        item.SubItems.Add(If(cipherSuiteItem.IsTls_1_2, "1.2", "1.0"))
                        item.Checked = cipherSuiteItem.IsChecked
                    Next i
                ElseIf addCount < 0 Then
                    For Each listViewItem As ListViewItem In listView.Items
                        If (Not cipherSuites.Contains(listViewItem.Text)) Then
                            listView.Items.Remove(listViewItem)
                        End If
                    Next listViewItem

                End If
            End If
        End Sub

    End Module

End Namespace
