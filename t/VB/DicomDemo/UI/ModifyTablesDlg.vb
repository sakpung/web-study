' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Dicom
Imports Leadtools.Demos
Imports DicomDemo

Imports Microsoft.VisualBasic


Public Class ModifyTablesDlg


    Private Sub ModifyTablesDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        textBoxUidFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableUid.xml")
        textBoxTagFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableElement.xml")
        textBoxIodFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableIodModule.xml")
        textBoxContextGroupFile.Text = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "dicTableContextGroup.xml")
    End Sub

    Private Sub MyBrowse(ByVal tb As TextBox)
        Dim dlg As New OpenFileDialog()
        dlg.DefaultExt = "xml"
        dlg.FileName = tb.Text
        dlg.Title = "Browse to Table File"
        dlg.InitialDirectory = DemosGlobal.ImagesFolder
        dlg.Filter = "XML Files: (*.xml)|*.xml||"
        If DialogResult.OK = dlg.ShowDialog() Then
            tb.Text = dlg.FileName
        End If
    End Sub

    Private Function Prompt(ByVal table As String) As Boolean
        Dim msg As String = String.Format("This will remove all the items from the {0} table." & Constants.vbLf + Constants.vbLf + Constants.vbTab & "Click 'OK' to continue" & Constants.vbLf + Constants.vbTab & "Click 'Cancel' to cancel", table)
        Return (MessageBox.Show(msg, "Remove All Table Items", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK)
    End Function

    Private Sub PromptResult(ByVal table As String, ByVal removed As Boolean)
        Dim result As String = "Cancelled"
        If removed Then
            result = String.Format("All items have been removed from the {0} table.", table)
        End If
        MessageBox.Show(result, "Remove All Table Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Messager(ByVal file As String, ByVal tableName As String, ByVal result As String)
        Dim successfullyLoaded As Boolean = String.IsNullOrEmpty(result)
        Dim msg As String = String.Format("{0} the {1} table from file" & Constants.vbLf & "'{2}'", If(successfullyLoaded, "Successfully loaded", "Failed to load"), tableName, file)
        Dim icon As MessageBoxIcon
        If successfullyLoaded Then
            icon = MessageBoxIcon.Information
        Else
            icon = MessageBoxIcon.Exclamation
        End If
        MessageBox.Show(msg, "Table Load", MessageBoxButtons.OK, icon)
    End Sub

    ' Load From File
    Private Sub buttonLoadUidTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonLoadUidTable.Click
        Cursor = Cursors.WaitCursor
        Dim result As String = String.Empty
        Dim tableName As String = "UID"
        Dim file As String = textBoxUidFile.Text

        Try
            Leadtools.Dicom.DicomUidTable.Instance.LoadXml(file)
        Catch ex As Exception
            result = ex.Message
        Finally
            Cursor = Cursors.Arrow
        End Try
        Messager(file, tableName, result)
    End Sub

    Private Sub buttonLoadTagTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonLoadTagTable.Click
        Cursor = Cursors.WaitCursor

        Dim result As String = String.Empty
        Dim tableName As String = "Element Tag"
        Dim file As String = textBoxTagFile.Text

        Try
            Leadtools.Dicom.DicomTagTable.Instance.LoadXml(file)
        Catch ex As Exception
            result = ex.Message
        Finally
            Cursor = Cursors.Arrow
        End Try
        Messager(file, tableName, result)
    End Sub

    Private Sub buttonLoadIodTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonLoadIodTable.Click
        Cursor = Cursors.WaitCursor

        Dim result As String = String.Empty
        Dim tableName As String = "IOD"
        Dim file As String = textBoxIodFile.Text

        Try
            Leadtools.Dicom.DicomIodTable.Instance.LoadXml(file)
        Catch ex As Exception
            result = ex.Message
        Finally
            Cursor = Cursors.Arrow
        End Try
        Messager(file, tableName, result)
    End Sub

    Private Sub buttonLoadContextGroupTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonLoadContextGroupTable.Click
        Cursor = Cursors.WaitCursor
        Dim result As String = String.Empty
        Dim tableName As String = "Context Group"
        Dim file As String = textBoxContextGroupFile.Text

        Try
            Leadtools.Dicom.DicomContextGroupTable.Instance.LoadXml(file)
        Catch ex As Exception
            result = ex.Message
        Finally
            Cursor = Cursors.Arrow
        End Try
        Messager(file, tableName, result)
    End Sub

    ' Reset table
    Private Sub buttonResetUidTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonResetUidTable.Click

        Dim table As String = "UID"
        Dim result As Boolean = Prompt(table)
        If result Then
            DicomUidTable.Instance.Reset()
        End If
        PromptResult(table, result)
    End Sub

    Private Sub buttonResetTagTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonResetTagTable.Click
        Dim table As String = "Element Tag"
        Dim result As Boolean = Prompt(table)
        If result Then
            DicomTagTable.Instance.Reset()
        End If
        PromptResult(table, result)
    End Sub

    Private Sub buttonResetIodTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonResetIodTable.Click
        Dim table As String = "IOD"
        Dim result As Boolean = Prompt(table)
        If result Then
            DicomIodTable.Instance.Reset()
        End If
        PromptResult(table, result)
    End Sub

    Private Sub buttonResetContextGroupTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonResetContextGroupTable.Click
        Dim table As String = "Context Group"
        Dim result As Boolean = Prompt(table)
        If result Then
            DicomContextGroupTable.Instance.Reset()
        End If
        PromptResult(table, result)
    End Sub

    ' Show Table
    Private Sub buttonShowUidTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonShowUidTable.Click
        Cursor = Cursors.WaitCursor
        Tools.ShowUidTable()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub buttonTagTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonTagTable.Click
        Cursor = Cursors.WaitCursor
        Tools.ShowTagTable()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub buttonShowIodTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonShowIodTable.Click
        Cursor = Cursors.WaitCursor
        Tools.ShowIodTable()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub buttonShowContextGroupTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonShowContextGroupTable.Click
        Cursor = Cursors.WaitCursor
        Tools.ShowContextGroupTable()
        Cursor = Cursors.Arrow
    End Sub

    ' Browse for file
    Private Sub buttonUidFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonUidFile.Click
        MyBrowse(textBoxUidFile)
    End Sub

    Private Sub buttonTagFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonTagFile.Click
        MyBrowse(textBoxTagFile)
    End Sub

    Private Sub buttonIodFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonIodFile.Click
        MyBrowse(textBoxIodFile)
    End Sub

    Private Sub buttonContextGroupFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonContextGroupFile.Click
        MyBrowse(textBoxContextGroupFile)
    End Sub


    ' This goes last
    Private Sub buttonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClose.Click
        Close()
    End Sub
End Class
