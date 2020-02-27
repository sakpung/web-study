' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Pdf
Imports System

Namespace PDFDocumentDemo
   Partial Public Class DigitalSignaturesDialog
      Inherits Form
      Private _signature As PDFSignature

      Public Sub New(signature As PDFSignature)
         InitializeComponent()

         _signature = signature

         InitializeSummaryTab()
         InitializeDetailsTab()
      End Sub

      Private Sub InitializeSummaryTab()
         _signatureValidityStateValueLabel.Text = PDFSignaturesHelper.GetState(_signature.State)

         _signedByValueLabel.Text = PDFSignaturesHelper.GetSignedByString(_signature.CertificateInfo("Subject"))

         _issuedByValueLabel.Text = PDFSignaturesHelper.GetSignedByString(_signature.CertificateInfo("Issuer"))

         _validFromValueLabel.Text = _signature.ValidFrom.ToLocalTime().ToString()

         _validToValueLabel.Text = _signature.ValidTo.ToLocalTime().ToString()

         _intededUsageValueLabel.Text = PDFSignaturesHelper.GetKeyUsageString(_signature.KeyUsage)

         _certificationInformationLabel.Text = GetCertificationInformationLabelData()
      End Sub

      Private Function GetCertificationInformationLabelData() As String
         Dim infoText As String = _certificationInformationLabel.Text

         Dim state As String = PDFSignaturesHelper.GetState(_signature.State)
         Dim signedBy As String = PDFSignaturesHelper.GetSignedByString(_signature.CertificateInfo("Subject"))

         Return String.Format(infoText, state, signedBy, state)
      End Function

      Private Sub InitializeDetailsTab()
         'Fiil DataGridView with the details of the signature
         For Each entry As KeyValuePair(Of String, String) In _signature.CertificateInfo
            Dim row As DataGridViewRow = CreateGridViewRow(entry.Key, entry.Value)
            _certificateDataGridView.Rows.Add(row)
         Next

         _certificateDataGridView.Rows.Add(CreateGridViewRow("Version", _signature.Version.ToString()))
         _certificateDataGridView.Rows.Add(CreateGridViewRow("Valid To", _signature.ValidTo.ToLocalTime().ToString()))
         _certificateDataGridView.Rows.Add(CreateGridViewRow("Valid From", _signature.ValidFrom.ToLocalTime().ToString()))
         _certificateDataGridView.Rows.Add(CreateGridViewRow("KeyUsage", PDFSignaturesHelper.GetKeyUsageString(_signature.KeyUsage)))
      End Sub

      Private Function CreateGridViewRow(name As String, value As String) As DataGridViewRow
         Dim row As New DataGridViewRow()
         row.CreateCells(_certificateDataGridView, New Object() {"Name", "Value"})
         row.Cells(0).Value = name
         row.Cells(1).Value = value
         Return row
      End Function

      Private Sub _certificateDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles _certificateDataGridView.SelectionChanged
         'Change The information data as the selected row.
         Dim row As DataGridViewRow = _certificateDataGridView.SelectedRows(0)

         Dim descriptionInfo As String = row.Cells(1).Value.ToString()

         If row.Cells(0).Value.ToString() = "Issuer" OrElse row.Cells(0).Value.ToString() = "Subject" Then
            descriptionInfo = PDFSignaturesHelper.GetSubjcetOrIssure(descriptionInfo)
         ElseIf row.Cells(0).Value.ToString() = "KeyUsage" Then
            Dim keyUsageInfo As String = CType(row.Cells(1).Value, String)

            keyUsageInfo = keyUsageInfo.Replace(", ", System.Environment.NewLine)

            descriptionInfo = keyUsageInfo
         End If

         _valueDescriptionTextBox.Text = descriptionInfo
      End Sub

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         Me.Close()
      End Sub
   End Class
End Namespace
