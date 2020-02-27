' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Wia

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
         MainForm._formatsList.Clear()

         ' Enable the EnumFormats event.
         AddHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

         ' enumerate the selected WIA item capabilities.
         MainForm._wiaSession.EnumFormats(MainForm._selectedWiaItem, 0)

         ' Disable the EnumFormats event.
         RemoveHandler MainForm._wiaSession.EnumFormatsEvent, AddressOf _wiaSession_EnumFormatsEvent

         ' Loop through the formats array adding them to the formats list.
         For Each i As MyFormat In MainForm._formatsList
            Dim item As ListViewItem

            item = _lvFormats.Items.Add(i.TransferModeString)

            item.SubItems.Add(i.FormatName)
            item.SubItems.Add(i.FormatCLSID)
         Next i
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _wiaSession_EnumFormatsEvent(ByVal sender As Object, ByVal e As WiaEnumFormatsEventArgs)
      If e.FormatsCount > 0 Then
         Dim myFormat As MyFormat = myFormat.Empty

#If (Not LEADTOOLS_V17_OR_LATER) Then
         WiaSession.GetFormatGuid(e.Format)
         myFormat.Format = WiaSession.FormatGuid
         myFormat.FormatCLSID = WiaSession.FormatGuid.ToString()
#Else
         myFormat.Format = WiaSession.GetFormatGuid(e.Format)
         myFormat.FormatCLSID = myFormat.Format.ToString()
#End If '#if !LEADTOOLS_V17_OR_LATER
         myFormat.FormatName = e.Format.ToString()
         myFormat.TransferMode = e.TransferMode
         myFormat.TransferModeString = e.TransferMode.ToString()

         MainForm._formatsList.Add(myFormat)
      End If
   End Sub
End Class
