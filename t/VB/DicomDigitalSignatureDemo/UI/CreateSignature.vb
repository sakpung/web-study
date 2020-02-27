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
Imports System.IO
Imports System

Namespace DicomDigitalSignatureDemo.UI
   Partial Public Class CreateSignature
      Inherits Form
      Public ReadOnly Property PrivateKey() As String
         Get
            Return _txtBx_PrivateKey.Text
         End Get
      End Property
      Public ReadOnly Property DigitalCertificate() As String
         Get
            Return _txtBx_DigitalCertificate.Text
         End Get
      End Property
      Public ReadOnly Property Password() As String
         Get
            Return _txtBx_Password.Text
         End Get
      End Property
      Public ReadOnly Property SignedDataSet() As String
         Get
            Return _txtBox_SignedDataSet.Text
         End Get
      End Property
      Public Sub New()
         InitializeComponent()

         Dim certificate As String = GetFullCertificatePath()

         If certificate IsNot Nothing Then
            _txtBx_DigitalCertificate.Text = certificate
            _txtBx_PrivateKey.Text = certificate
            _txtBx_Password.Text = "test"
         End If

         checkIfOKEnabled()
      End Sub

      Private Sub _btn_PrivateKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_PrivateKey.Click
         Dim fileDialog As New OpenFileDialog()
         fileDialog.Filter = "All Files (*.*)|*.*"

         If fileDialog.ShowDialog() = DialogResult.OK Then
            Me._txtBx_PrivateKey.Text = fileDialog.FileName
         End If
      End Sub

      Private Sub _btn_DigitalCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_DigitalCertificate.Click
         Dim fileDialog As New OpenFileDialog()
         fileDialog.Filter = "Digital Certificates (*.pem; *.cer; *.crt; *.p7b; *.spc; *.pfx; *.p12)|" & "*.pem; *.cer; *.crt; *.p7b; *.spc; *.pfx; *.p12|" & "All Files (*.*)|*.*"

         If fileDialog.ShowDialog() = DialogResult.OK Then
            Me._txtBx_DigitalCertificate.Text = fileDialog.FileName
         End If
      End Sub

      Private Sub _btn_SignedDataSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_SignedDataSet.Click
         Dim fileDialog As New SaveFileDialog()
         fileDialog.Filter = "DCM Files (*.dcm)|*.dcm|All Files (*.*)|*.*"

         If fileDialog.ShowDialog() = DialogResult.OK Then
            Me._txtBox_SignedDataSet.Text = fileDialog.FileName
         End If
      End Sub

      Private Function GetFullCertificatePath() As String
         Dim path__1 As String = Path.GetDirectoryName(Application.ExecutablePath)
         path__1 = Path.Combine(path__1, "client.pem")
         If File.Exists(path__1) Then
            Return path__1
         End If
         Return Nothing
      End Function

      Private Sub _txtBx_PrivateKey_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtBx_PrivateKey.TextChanged
         checkIfOKEnabled()
      End Sub

      Private Sub _txtBx_DigitalCertificate_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
         checkIfOKEnabled()
      End Sub

      Private Sub _txtBox_SignedDataSet_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
         checkIfOKEnabled()
      End Sub

      Private Sub checkIfOKEnabled()
         If _txtBx_PrivateKey.Text = "" OrElse _txtBx_DigitalCertificate.Text = "" OrElse _txtBox_SignedDataSet.Text = "" Then
            _btn_OK.Enabled = False
         Else
            _btn_OK.Enabled = True
         End If
      End Sub
   End Class
End Namespace
