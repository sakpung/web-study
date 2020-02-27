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
Imports Leadtools

Namespace PrinterDemo
   Partial Public Class FrmInstallPrinter : Inherits Form
#Region "Constructor..."
      Public Sub New()
         InitializeComponent()
      End Sub
#End Region

#Region "Fields..."
      Private _printerName As String = String.Empty
      Private _enableNetwork As Boolean = False
#End Region

#Region "Properties..."
      Public ReadOnly Property PrinterName() As String
         Get
            Return _printerName
         End Get
      End Property

      Public ReadOnly Property EnableNetwork() As Boolean
         Get
            Return _enableNetwork
         End Get
      End Property
#End Region

#Region "Events..."
      Private Sub FrmInstallPrinter_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            EnableControls()
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Private Sub FrmInstallPrinter_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         Try
            _printerName = _txtBoxPrinterName.Text
            _enableNetwork = _ckEnableNetwork.Checked
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub

      Private Sub _txtBoxPrinterName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtBoxPrinterName.TextChanged
         Try
            EnableControls()
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub
#End Region

#Region "Methods..."
      Private Sub EnableControls()
         Try
            Dim bEnable As Boolean = (_txtBoxPrinterName.Text <> String.Empty)
            _btnOk.Enabled = bEnable

            If RasterSupport.IsLocked(RasterSupportType.PrintDriverServer) Then 'Network Key
               _ckEnableNetwork.Enabled = False
            End If
         Catch Ex As Exception
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End Sub
#End Region
   End Class
End Namespace
