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
Imports Leadtools.Wia

Namespace PrintToPACSDemo
   Partial Public Class SupportedFormatsForm : Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub SupportedFormatsForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         ' Add the list view columns.
         _lvFormats.Columns.Add("Transfer Mode (TYMED)", 130, HorizontalAlignment.Left)
         _lvFormats.Columns.Add("Format Name", 80, HorizontalAlignment.Left)
         _lvFormats.Columns.Add("Format GUID", 210, HorizontalAlignment.Left)

         Try
            FrmMain._formatsList.Clear()

            ' Enable the EnumFormats event.
            AddHandler FrmMain._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

            ' enumerate the selected WIA item capabilities.
            FrmMain._wiaSession.EnumFormats(FrmMain._enumeratedItemsList(FrmMain._selectedItemIndex), 0)

            ' Disable the EnumFormats event.
            RemoveHandler FrmMain._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

            ' Loop through the formats array adding them to the formats list.
            For Each i As MyFormat In FrmMain._formatsList
               Dim item As ListViewItem

               item = _lvFormats.Items.Add(i.TransferModeString)

               item.SubItems.Add(i.FormatName)
               item.SubItems.Add(i.FormatCLSID)
            Next i
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _wiaSession_EnumFormatsEvent(ByVal sender As Object, ByVal e As Leadtools.Wia.WiaEnumFormatsEventArgs)
         If e.FormatsCount > 0 Then
            Dim myFormat As MyFormat = myFormat.Empty
            myFormat.Format = WiaSession.GetFormatGuid(e.Format)
            myFormat.FormatCLSID = myFormat.Format.ToString()
            myFormat.FormatName = e.Format.ToString()
            myFormat.TransferMode = e.TransferMode
            myFormat.TransferModeString = e.TransferMode.ToString()

            FrmMain._formatsList.Add(myFormat)
         End If
      End Sub
   End Class
End Namespace
