' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace DicomDemo
   Partial Public Class Page2 : Inherits UserControl
      Private _globals As Globals

      Public Sub New(ByRef pGlobals As Globals)
         InitializeComponent()

         _globals = pGlobals
      End Sub

      Private Sub radBroad_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radBroad.CheckedChanged
         grpBroad.Enabled = radBroad.Checked
      End Sub

      Private Sub radPatient_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radPatient.CheckedChanged
         grpPatient.Enabled = radPatient.Checked
      End Sub

      Private Sub Page2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            PopulateModalityComboBox()

            ' Set control values from global values
            If _globals.m_nQueryType = 1 Then
               radBroad.Checked = True
            Else
               radPatient.Checked = True
            End If

            chkScheduledDate.Checked = _globals.m_bCheckScheduledDate
            dtpScheduledDate.Value = _globals.m_ScheduledDate
            chkModality.Checked = _globals.m_bCheckModality
            'find and select the Modality or the first if it cannot be found
            Dim i As Integer = 0
            Do While i < _globals.m_ModalityTable.Length
               If _globals.m_strModality = _globals.m_ModalityTable(i).m_strValue Then
                  cboModality.SelectedIndex = i
                  Exit Do
               End If
               i += 1
            Loop

            txtAccessionNumber.Text = _globals.m_strAccessionNumber
            txtPatientID.Text = _globals.m_strPatientID
            txtPatientName.Text = _globals.m_strPatientName
            txtRequestedProcedureID.Text = _globals.m_strRequestedProcedureID
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Populates the combo box with the modality table
      '
      Private Sub PopulateModalityComboBox()
         Try
            Dim i As Integer = 0
            Do While i < _globals.m_ModalityTable.Length
               cboModality.Items.Add(_globals.m_ModalityTable(i).ToString())
               i += 1
            Loop
            cboModality.Sorted = True
            cboModality.SelectedIndex = 0
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      Private Sub chkScheduledDate_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkScheduledDate.CheckedChanged
         dtpScheduledDate.Enabled = chkScheduledDate.Checked
      End Sub

      Private Sub chkModality_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkModality.CheckedChanged
         cboModality.Enabled = chkModality.Checked
      End Sub
   End Class
End Namespace
