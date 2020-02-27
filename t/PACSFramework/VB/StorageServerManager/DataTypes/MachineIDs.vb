' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Management

Namespace Leadtools.Demos.StorageServer.DataTypes
   Public Class MachineIDs
      Private Shared _ins As MachineIDs = New MachineIDs()

      Public Shared ReadOnly Property Instance() As MachineIDs
         Get
            Return _ins
         End Get
      End Property

      Private _sMACAddress As List(Of String) = Nothing
      Private _sHDSerial As List(Of String) = Nothing
      Private _sCPUId As String = Nothing

      Public ReadOnly Property MACAddress() As List(Of String)
         Get
            If Nothing Is _sMACAddress Then
               _sMACAddress = GetMACAddress()
            End If
            Return _sMACAddress
         End Get
      End Property

      Public ReadOnly Property HDSerial() As List(Of String)
         Get
            If Nothing Is _sHDSerial Then
               _sHDSerial = GetHDSerial(True)
            End If
            Return _sHDSerial
         End Get
      End Property

      Public ReadOnly Property CPUId() As String
         Get
            If Nothing Is _sCPUId Then
               _sCPUId = GetCPUId()
            End If
            Return _sCPUId
         End Get
      End Property

      Private Function GetHDSerial(ByVal fFirstHDOnly As Boolean) As List(Of String)
         Dim HDSerialsList As List(Of String) = New List(Of String)()
         Dim m As MachineIDs = MachineIDs.Instance
         Dim myScope As ManagementScope = New ManagementScope("root\CIMV2")
         Dim q As SelectQuery = New SelectQuery("Win32_LogicalDisk")
         Dim s As ManagementObjectSearcher = New ManagementObjectSearcher(myScope, q)

         For Each disk As ManagementObject In s.Get()
            Try
               Dim dsk As ManagementObject = New ManagementObject(disk.ToString())
               dsk.Get()
               Dim volumeSerial As String = dsk("VolumeSerialNumber").ToString()
               HDSerialsList.Add(volumeSerial)

               If fFirstHDOnly Then
                  Exit Try
               End If
            Catch
            End Try
         Next disk
         Return HDSerialsList
      End Function

      ''' <summary>
      ''' this function is expensive
      ''' </summary>
      ''' <returns></returns>
      Private Function GetCPUId() As String
         Dim cpuInfo As String = String.Empty
         Dim mc As ManagementClass = New ManagementClass("win32_processor")
         Dim moc As ManagementObjectCollection = mc.GetInstances()

         For Each mo As ManagementObject In moc
            If cpuInfo = "" Then
               'Get only the first CPU's ID
               cpuInfo = mo.Properties("processorID").Value.ToString()
               Exit For
            End If
         Next mo
         Return cpuInfo
      End Function

      Private Function GetMACAddress() As List(Of String)
         Dim MACAddressList As List(Of String) = New List(Of String)()
         Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("select MACAddress from Win32_NetworkAdapter")

         Try
            For Each share As ManagementObject In searcher.Get()
               For Each PD As PropertyData In share.Properties
                  If Not PD.Value Is Nothing AndAlso PD.Value.ToString() <> "" Then
                     Select Case PD.Value.GetType().ToString()
                        Case "System.String[]"
                           Dim str As String() = CType(PD.Value, String())

                           Dim str2 As String = ""
                           For Each st As String In str
                              str2 &= st & " "
                           Next st

                           MACAddressList.Add(str2)

                        Case "System.UInt16[]"
                           Dim shortData As UShort() = CType(PD.Value, UShort())


                           Dim tstr2 As String = ""
                           For Each st As UShort In shortData
                              tstr2 &= st.ToString() & " "
                           Next st

                           MACAddressList.Add(tstr2)


                        Case Else
                           MACAddressList.Add(PD.Value.ToString())
                     End Select
                  End If
               Next PD
            Next share
         Catch
         End Try

         Return MACAddressList
      End Function

      Public Sub New()
      End Sub
   End Class
End Namespace
