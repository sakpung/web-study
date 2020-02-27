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

Namespace ServerPrinterDemo
   Friend Class PrintingUtilities
#Region "Methods..."
      <DllImport("shell32.dll")> _
      Public Shared Function IsUserAnAdmin() As Boolean
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

      Friend Shared Function GetLeadtoolsPrintersList() As String()
         Try
            Dim printersList As List(Of String) = New List(Of String)()

            For Each printerName As String In PrinterSettings.InstalledPrinters
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

            Dim bExist As Boolean = (printersList.IndexOf(printerName) > 0)
            Return bExist
         Catch
            Return True
         End Try
      End Function
#End Region
   End Class
End Namespace
