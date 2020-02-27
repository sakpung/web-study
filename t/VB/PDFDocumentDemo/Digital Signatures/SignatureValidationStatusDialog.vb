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
   Partial Public Class SignatureValidationStatusDialog
      Inherits Form
      Private _signature As PDFSignature

      Public Sub New(signature As PDFSignature)
         InitializeComponent()

         If signature Is Nothing Then
            Return
         End If

         _signature = signature

         SetCertificationInformation()
      End Sub

      Private Sub SetCertificationInformation()
         Dim state As String = PDFSignaturesHelper.GetState(_signature.State)

         _infoLabel.Text = String.Format(_infoLabel.Text, state)
      End Sub

      Private Sub _signatureDetailsButton_Click(sender As Object, e As EventArgs) Handles _signaturePropertiesButton.Click
         Using signaturesDialog As New DigitalSignaturesDialog(_signature)
            signaturesDialog.ShowDialog()
         End Using
      End Sub

      Private Sub _closeButton_Click(sender As Object, e As EventArgs) Handles _closeButton.Click
         Me.Close()
      End Sub
   End Class
End Namespace
