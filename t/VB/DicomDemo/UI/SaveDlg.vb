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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DicomDemo
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom
Imports DicomDemo.Extensions

Public Class SaveDlg

   Public Sub New(saveOptionsType As SaveOptionsEnum)
      '
      ' Required for Windows Form Designer support
      '
      _saveOptionsType = saveOptionsType
      InitializeComponent()
   End Sub

   Private _saveOptionsType As SaveOptionsEnum

   Private privateDicomDS As DicomDataSet
   Public Property DicomDS() As DicomDataSet
      Get
         Return privateDicomDS
      End Get
      Set(ByVal value As DicomDataSet)
         privateDicomDS = value
      End Set
   End Property


   Private Sub SaveDlg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      If _saveOptionsType = SaveOptionsEnum.NativeDicomModel Then
         Me.Text = "'Native DICOM Model' Save Options"
         textBoxDescription.Text = "The 'Native DICOM Model' xml format is described in PS3.19.A.1 of the DICOM Specification."
         radioButtonBulkDataUuid.Visible = True
         checkBoxFullEndStatement.Visible = True
         CheckBoxWriteKeyword.Visible = False
         checkBoxMinify.Visible = False
      Else
         Me.Text = "'DICOM Json Model' Save Options"
         textBoxDescription.Text = "The 'DICOM Json Model' json format is described in PS3.18.F.2 of the DICOM Specification."
         radioButtonBulkDataUuid.Visible = False
         checkBoxFullEndStatement.Visible = False
         CheckBoxWriteKeyword.Visible = True
         checkBoxMinify.Visible = True
      End If
   End Sub

   Public Function GetXmlFlags() As DicomDataSetSaveXmlFlags
      Dim flags As DicomDataSetSaveXmlFlags = DicomDataSetSaveXmlFlags.NativeDicomModel Or (If(radioButtonInlineBinary.Checked, DicomDataSetSaveXmlFlags.InlineBinary, DicomDataSetSaveXmlFlags.None)) Or (If(radioButtonBulkDataUri.Checked, DicomDataSetSaveXmlFlags.BulkDataUri, DicomDataSetSaveXmlFlags.None)) Or (If(radioButtonBulkDataUuid.Checked, DicomDataSetSaveXmlFlags.BulkDataUuid, DicomDataSetSaveXmlFlags.None)) Or (If(radioButtonIgnorePixelData.Checked, DicomDataSetSaveXmlFlags.IgnorePixelData, DicomDataSetSaveXmlFlags.None)) Or (If(radioButtonIgnoreBinaryData.Checked, DicomDataSetSaveXmlFlags.IgnoreBinaryData, DicomDataSetSaveXmlFlags.None)) Or (If(radioButtonIgnoreAllData.Checked, DicomDataSetSaveXmlFlags.IgnoreAllData, DicomDataSetSaveXmlFlags.None)) Or (If(checkBoxTrimWhiteSpace.Checked, DicomDataSetSaveXmlFlags.TrimWhiteSpace, DicomDataSetSaveXmlFlags.None)) Or (If(checkBoxFullEndStatement.Checked, DicomDataSetSaveXmlFlags.WriteFullEndElement, DicomDataSetSaveXmlFlags.None))

      Return flags
   End Function

   Public Sub SetXmlFlags(ByVal flags As DicomDataSetSaveXmlFlags)
      ' Binary Data Options
      If flags.IsFlagged(DicomDataSetSaveXmlFlags.InlineBinary) Then
         radioButtonInlineBinary.Checked = True
      ElseIf flags.IsFlagged(DicomDataSetSaveXmlFlags.BulkDataUri) Then
         radioButtonBulkDataUri.Checked = True
      Else
         radioButtonBulkDataUuid.Checked = True
      End If

      ' Data Options
      If flags.IsFlagged(DicomDataSetSaveXmlFlags.IgnorePixelData) Then
         radioButtonIgnorePixelData.Checked = True
      ElseIf flags.IsFlagged(DicomDataSetSaveXmlFlags.IgnoreBinaryData) Then
         radioButtonIgnoreBinaryData.Checked = True
      ElseIf flags.IsFlagged(DicomDataSetSaveXmlFlags.IgnoreAllData) Then
         radioButtonIgnoreAllData.Checked = True
      Else
         radioButtonIncludeAllData.Checked = True
      End If

      ' Misc Options
      If flags.IsFlagged(DicomDataSetSaveXmlFlags.TrimWhiteSpace) Then
         checkBoxTrimWhiteSpace.Checked = True
      End If
      If flags.IsFlagged(DicomDataSetSaveXmlFlags.WriteFullEndElement) Then
         checkBoxFullEndStatement.Checked = True
      End If
   End Sub

   Public Function GetJsonFlags() As DicomDataSetSaveJsonFlags
      Dim flags As DicomDataSetSaveJsonFlags = (If(radioButtonInlineBinary.Checked, DicomDataSetSaveJsonFlags.InlineBinary, DicomDataSetSaveJsonFlags.None)) Or (If(radioButtonBulkDataUri.Checked, DicomDataSetSaveJsonFlags.BulkDataUri, DicomDataSetSaveJsonFlags.None)) Or (If(radioButtonIgnorePixelData.Checked, DicomDataSetSaveJsonFlags.IgnorePixelData, DicomDataSetSaveJsonFlags.None)) Or (If(radioButtonIgnoreBinaryData.Checked, DicomDataSetSaveJsonFlags.IgnoreBinaryData, DicomDataSetSaveJsonFlags.None)) Or (If(radioButtonIgnoreAllData.Checked, DicomDataSetSaveJsonFlags.IgnoreAllData, DicomDataSetSaveJsonFlags.None)) Or (If(checkBoxTrimWhiteSpace.Checked, DicomDataSetSaveJsonFlags.TrimWhiteSpace, DicomDataSetSaveJsonFlags.None)) Or (If(checkBoxWriteKeyword.Checked, DicomDataSetSaveJsonFlags.WriteKeyword, DicomDataSetSaveJsonFlags.None)) Or (If(checkBoxMinify.Checked, DicomDataSetSaveJsonFlags.Minify, DicomDataSetSaveJsonFlags.None))

      Return flags
   End Function

   Public Sub SetJsonFlags(ByVal flags As DicomDataSetSaveJsonFlags)
      ' Binary Data Options
      If flags.IsFlagged(DicomDataSetSaveJsonFlags.InlineBinary) Then
         radioButtonInlineBinary.Checked = True
      Else
         radioButtonBulkDataUri.Checked = True
      End If


      ' Data Options
      If flags.IsFlagged(DicomDataSetSaveJsonFlags.IgnorePixelData) Then
         radioButtonIgnorePixelData.Checked = True
      ElseIf flags.IsFlagged(DicomDataSetSaveJsonFlags.IgnoreBinaryData) Then
         radioButtonIgnoreBinaryData.Checked = True
      ElseIf flags.IsFlagged(DicomDataSetSaveJsonFlags.IgnoreAllData) Then
         radioButtonIgnoreAllData.Checked = True
      Else
         radioButtonIncludeAllData.Checked = True
      End If

      ' Misc Options
      If flags.IsFlagged(DicomDataSetSaveJsonFlags.TrimWhiteSpace) Then
         checkBoxTrimWhiteSpace.Checked = True
      End If
   End Sub

   Public Shared Sub SaveXmlFile(ByVal ds As DicomDataSet, ByVal xmlFlags As DicomDataSetSaveXmlFlags)
      Using saveFileDialog As New SaveFileDialog()
         saveFileDialog.Filter = "XML File(*.xml)|*.xml|All files (*.*)|*.*"
         saveFileDialog.AddExtension = True
         saveFileDialog.Title = "Save 'Native DICOM Model' File"
         If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
               ds.SaveXml(saveFileDialog.FileName, xmlFlags)
            Catch de As DicomException
               Dim err As String = String.Format("Error saving dicom dataset!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

               MessageBox.Show(err, "Error")
               Return
            End Try
         End If
      End Using
   End Sub

   Public Shared Sub SaveJsonFile(ByVal ds As DicomDataSet, ByVal jsonFlags As DicomDataSetSaveJsonFlags)
      Using saveFileDialog As New SaveFileDialog()
         saveFileDialog.Filter = "JSON File(*.json)|*.json|All files (*.*)|*.*"
         saveFileDialog.AddExtension = True
         saveFileDialog.Title = "Save 'DICOM JSON Model' File"
         If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
               ds.SaveJson(saveFileDialog.FileName, jsonFlags)
            Catch de As DicomException
               Dim err As String = String.Format("Error saving dicom dataset!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

               MessageBox.Show(err, "Error")
               Return
            End Try
         End If
      End Using
   End Sub


   Private Sub buttonSave_Click(sender As System.Object, e As System.EventArgs) Handles buttonSave.Click
      If Me._saveOptionsType = SaveOptionsEnum.NativeDicomModel Then
         SaveXmlFile(DicomDS, GetXmlFlags())
      Else
         SaveJsonFile(DicomDS, GetJsonFlags())
      End If
   End Sub
End Class

Public Enum SaveOptionsEnum
   NativeDicomModel
   JsonModel
End Enum
