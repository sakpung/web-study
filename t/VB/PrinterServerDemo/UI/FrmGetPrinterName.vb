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
Imports Leadtools.Printer

Namespace ServerPrinterDemo
   Partial Public Class FrmGetPrinterName : Inherits Form
#Region "Constructor..."
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub New(ByVal activePrinter As String)
         InitializeComponent()
         _printerName = activePrinter
      End Sub
#End Region

#Region "Fields..."
      Private _printingUtilities As PrintingUtilities = New PrintingUtilities()
      Private _printerName As String = String.Empty
#End Region

#Region "Properties..."
      Public ReadOnly Property PrinterName() As String
         Get
            Return _printerName
         End Get
      End Property
#End Region

#Region "Events..."
      Private Sub FrmGetPrinterName_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            _cmbPrintersList.Items.Clear()
            FillLeadtoolsPrintersList()
            EnableControls()
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Private Sub FrmGetPrinterName_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
         Try
            If _cmbPrintersList.Items.Count > 0 Then
               _printerName = _cmbPrintersList.Text
            End If
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub
#End Region

#Region "Methods..."

      Private ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property

      Private Sub FillLeadtoolsPrintersList()
         Dim setupPrinter As String = String.Empty

#If LTV20_CONFIG Then
         If (Is64) Then
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 64-bit"
         Else
            setupPrinter = "LEADTOOLS 20 .NET Network Printer 32-bit"
         End If
#End If

            Try
               Dim lstPrinters As List(Of String) = New List(Of String)()
               Dim printer As Printer
               For Each str As String In PrintingUtilities.GetLeadtoolsPrintersList()
                  printer = New Printer(str)
                  If printer.EnableNetworkPrinting Then
                     lstPrinters.Add(str)
                  End If
                  printer.Dispose()
                  printer = Nothing
               Next str

               _cmbPrintersList.Items.Clear()
               _cmbPrintersList.Items.AddRange(lstPrinters.ToArray())

               If _cmbPrintersList.Items.Count > 0 Then
                  If _printerName <> String.Empty Then
                     _cmbPrintersList.Text = _printerName
                  Else
                     _cmbPrintersList.SelectedIndex = 0
                  End If

                  If _printerName = String.Empty Then
                     Dim i As Integer = 0
                     Do While i < _cmbPrintersList.Items.Count
                        If (CType(IIf(TypeOf _cmbPrintersList.Items(i) Is String, _cmbPrintersList.Items(i), Nothing), String)).ToLower() = setupPrinter.ToLower() Then
                           _cmbPrintersList.SelectedIndex = i
                        End If
                        i += 1
                     Loop
                  End If
               Else
                  Dim errorMessage As String = "No printers are available."
                  MessageBox.Show(errorMessage, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               End If
               EnableControls()
            Catch Ex As Exception
               MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
      End Sub

      Private Sub EnableControls()
         Try
            Dim bprinterExist As Boolean = (_cmbPrintersList.Items.Count > 0)
            _btnOk.Enabled = bprinterExist
            _cmbPrintersList.Enabled = bprinterExist
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub
#End Region
   End Class
End Namespace
