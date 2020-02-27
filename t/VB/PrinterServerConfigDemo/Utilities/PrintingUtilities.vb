' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Text
Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports Leadtools.Printer
Imports System.IO
Imports System.Management

Namespace PrinterDemo
   Friend Class PrintingUtilities
#Region "Methods..."

      Private Shared ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property

      <DllImport("shell32.dll")> _
      Public Shared Function IsUserAnAdmin() As Boolean
      End Function

      Friend Shared Function InstallNewPrinter(ByVal printerName As String, ByVal printerPassword As String) As Boolean
         Try
            If IsPrinterExist(printerName) Then
               Dim errorMessage As String = "Duplicated printer name. Please enter another name."
               MessageBox.Show(errorMessage, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return False
            Else
#If LTV20_CONFIG Then
               Dim documentPrinterRegPath As String = "SOFTWARE\LEAD Technologies, Inc.\20\Printer\"
#End If
               Dim printerInfo As PrinterInfo = New PrinterInfo()
               printerInfo.PortName = printerName
               printerInfo.MonitorName = printerName
               printerInfo.ProductName = printerName
               printerInfo.PrinterName = printerName
               printerInfo.Password = printerPassword
               printerInfo.RegistryKey = documentPrinterRegPath & printerName
               printerInfo.RootDir = GetPrinterPath(documentPrinterRegPath)
               printerInfo.Url = "https://www.leadtools.com/support/default.htm"
               printerInfo.PrinterExe = Path.GetDirectoryName(Application.ExecutablePath) & "\" & "VBPrinterServerDemo_Original.exe"
               printerInfo.AboutIcon = "C:\Users\Public\Documents\LEADTOOLS Images\PrinterDriver.ico"
               If (Is64) Then
                  printerInfo.AboutString = "LEADTOOLS VB Network Printer 64-Bit"
               Else
                  printerInfo.AboutString = "LEADTOOLS VB Network Printer 32-Bit"
               End If

               Printer.Install(printerInfo)
               MessageBox.Show("Installing New Printer Completed Successfully", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
               Return True
            End If
         Catch
            Return False
         End Try
      End Function

      Friend Shared Function GetPrinterPath(ByVal registryPath As String) As String
         Try
            Dim connectionExe As String = String.Empty
            Dim subPathExe As String = String.Empty
            Dim registryKey As RegistryKey = Registry.LocalMachine.OpenSubKey(registryPath & "Data")

            If Not registryKey Is Nothing Then
               connectionExe = registryKey.GetValue("ConnectionExe").ToString()
               Dim pathExe As String() = connectionExe.Split("\"c)

               Dim iLoop As Integer = 0
               Do While iLoop < pathExe.Length - 2
                  subPathExe &= pathExe(iLoop) & "\"
                  iLoop += 1
               Loop
               subPathExe.Remove(subPathExe.Length - 1, 1)
            End If
            Return subPathExe
         Catch
            Return String.Empty
         End Try
      End Function

      Private Shared Function GetPrinters() As List(Of String)
         Dim printerNames As List(Of String) = New List(Of String)()

         ' Use the ObjectQuery to get the list of configured printers
         Dim oquery As System.Management.ObjectQuery = New System.Management.ObjectQuery("SELECT * FROM Win32_Printer")

         Dim mosearcher As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(oquery)

         Dim moc As System.Management.ManagementObjectCollection = mosearcher.Get()

         For Each mo As ManagementObject In moc
            Dim pdc As System.Management.PropertyDataCollection = mo.Properties
            For Each pd As System.Management.PropertyData In pdc
               If (Not CBool(mo("Network"))) Then
                  Dim bExists As Boolean = printerNames.Contains(mo("DeviceID").ToString())
                  If (Not bExists) Then
                     printerNames.Add(mo("DeviceID").ToString())
                  End If
               End If
            Next pd
         Next mo

         Return printerNames

      End Function

      Friend Shared Function GetLeadtoolsPrintersList() As String()
         Try
            Dim printersList As List(Of String) = New List(Of String)()

            For Each printerName As String In GetPrinters().ToArray()
               Try
                  If Printer.IsLeadtoolsPrinter(printerName) Then
                     printersList.Add(printerName)
                  End If
               Catch

               End Try
            Next printerName
            Return printersList.ToArray()
         Catch
            Return New List(Of String)().ToArray()
         End Try
      End Function

      Friend Shared Function GetAllPrintersList() As String()
         Try
            Dim allPrinterList As List(Of String) = New List(Of String)()

            For Each printerName As String In PrinterSettings.InstalledPrinters
               allPrinterList.Add(printerName)
            Next printerName
            Return allPrinterList.ToArray()
         Catch
            Return New List(Of String)().ToArray()
         End Try
      End Function

      Friend Shared Function IsPrinterExist(ByVal printerName As String) As Boolean
         Try
            Dim printers As String() = GetAllPrintersList()
            Dim printersList As List(Of String) = New List(Of String)()
            printersList.AddRange(printers)

            Dim bExist As Boolean = (printersList.IndexOf(printerName) >= 0)
            Return bExist
         Catch
            Return True
         End Try
      End Function
#End Region
   End Class
End Namespace
