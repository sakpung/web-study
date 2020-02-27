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

Namespace ManagedPrinterClientDemo
   Partial Public Class MainForm : Inherits Form
      Private _printerSettings As PrinterSettings
      Private _PrinterName As String

      Public Function GetData() As String
         Return _cmbFileFormats.SelectedItem.ToString() & "---" & _txtSavePath.Text & "\" & _txtSaveName.Text
      End Function

      Private ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property

      Public Sub New(ByVal printerName As String, ByVal bytes As Byte())
         _PrinterName = printerName
         InitializeComponent()
         _printerSettings = New PrinterSettings(bytes)
         _txtPrinterName.Text = _PrinterName

         If (Is64) Then
            Text = "LEADTOOLS VB Printer Client Demo 64-bit"
         Else
            Text = "LEADTOOLS VB Printer Client Demo 32-bit"
         End If

         ApplyPrinterSettings()
      End Sub

      Private Sub ApplyPrinterSettings()
         _txtPrinterDescription.Text = _printerSettings._strDescreption
         _cmbFileFormats.Items.Clear()

         For Each fileFormat As PrinterFileFormat In _printerSettings._lstFormats
            _cmbFileFormats.Items.Add(fileFormat._strFileFormat)
         Next fileFormat

         If _cmbFileFormats.Items.Count > 0 Then
            _cmbFileFormats.SelectedIndex = 0
         End If

      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         If String.IsNullOrEmpty(_txtSaveName.Text) Then
            MessageBox.Show(Me, "Please enter a valid file name", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If

         DialogResult = DialogResult.OK
         Return
      End Sub

      Private Sub _cmbFileFormats_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbFileFormats.SelectedIndexChanged
         Try
            Dim fileFormat As PrinterFileFormat = _printerSettings._lstFormats(_cmbFileFormats.SelectedIndex)
            _txtSavePath.Text = fileFormat._strSaveLocation
         Catch
         End Try
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
         _strDescreption = "Insert actual printer description here. This description will be sent to the user client demo as initialization data."

         _lstFormats = New List(Of PrinterFileFormat)()

         Dim PersonalFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

         Dim fileFormat As PrinterFileFormat = New PrinterFileFormat("PDF", PersonalFolder)
         _lstFormats.Add(fileFormat)
         fileFormat = New PrinterFileFormat("XPS", PersonalFolder)
         _lstFormats.Add(fileFormat)
         fileFormat = New PrinterFileFormat("DOC", PersonalFolder)
         _lstFormats.Add(fileFormat)
         fileFormat = New PrinterFileFormat("DOCX", PersonalFolder)
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

            Catch e As System.Exception
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
End Namespace
