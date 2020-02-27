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
Imports System.IO
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Dicom
Imports Leadtools.ImageProcessing.Color
Imports DicomDigitalSignatureDemo.DicomDigitalSignatureDemo.UI
Imports DicomDigitalSignatureDemo.Leadtools.DicomDemos

Namespace DicomDigitalSignatureDemo
    Partial Public Class MainForm
        Inherits Form
        Private m_CreateSignatureDlg As CreateSignature

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()>
        Shared Sub Main()

            If Not Support.SetLicense() Then
                Return
            End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub

        Public Sub New()
            InitializeComponent()

            ' Setup the caption for this demo
            Messager.Caption = "VB Dicom Digital Signature Demo"

            ' Create Signature Dialog
            m_CreateSignatureDlg = New CreateSignature()

            DicomEngine.Startup()
        End Sub

        Private Sub _btn_Open_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Open.Click
            Dim fileDialog As New OpenFileDialog()
            fileDialog.Filter = "DICOM Files (*.dic; *.dcm)|*.dic; *.dcm|All Files (*.*)|*.*"
            If fileDialog.ShowDialog() = DialogResult.OK Then
                Me._txBx_DataSet.Text = fileDialog.FileName
            End If
        End Sub

        Private Sub _txBx_DataSet_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txBx_DataSet.TextChanged
            If Me._txBx_DataSet.Text = "" Then
                Me._btn_Sign.Enabled = False
                Me._btn_Verify.Enabled = False
            Else
                Me._btn_Sign.Enabled = True
                Me._btn_Verify.Enabled = True
            End If
        End Sub

        Private Sub _btn_Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Sign.Click
            If Utils.VerifyOpensslVersion(Me) = False Then
                Return
            End If
            If m_CreateSignatureDlg.ShowDialog() = DialogResult.OK Then
                EnableControls(False)

                Dim sDataSet As String
                sDataSet = Me._txBx_DataSet.Text

                Try
                    Dim DataSet As New DicomDataSet()

                    ' Load the Data Set to be signed
                    DataSet.Load(sDataSet, DicomDataSetLoadFlags.LoadAndClose)

                    Dim waitCursor As New WaitCursor()

                    ' Create a Digital Signature in the main Data Set
                    DataSet.CreateSignature(Nothing, m_CreateSignatureDlg.PrivateKey, m_CreateSignatureDlg.DigitalCertificate, m_CreateSignatureDlg.Password, Nothing, 0,
                     Nothing, 0)


                    ' Save the signed Data Set
                    DataSet.Save(m_CreateSignatureDlg.SignedDataSet, DicomDataSetSaveFlags.None)


                    MessageBox.Show("The Data Set was signed successfully.", "Demo")
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Sign Failed")
                Finally
                    EnableControls()
                End Try
            End If
        End Sub

        Private Sub EnableControls(ByVal bEnable As Boolean)
            If bEnable = False Then
                Me._btn_Verify.Enabled = False
                Me._btn_Open.Enabled = False
                Me._btn_Sign.Enabled = False
                Me._txBx_DataSet.Enabled = False
            Else
                Me._btn_Verify.Enabled = (_txBx_DataSet.Text <> "")
                Me._btn_Sign.Enabled = (_txBx_DataSet.Text <> "")
                Me._btn_Open.Enabled = True
                Me._txBx_DataSet.Enabled = True
            End If
        End Sub

        Private Sub EnableControls()
            EnableControls(True)
        End Sub

        Private Sub _btn_Verify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Verify.Click
            If Utils.VerifyOpensslVersion(Me) = False Then
                Return
            End If

            EnableControls(False)

            Try
                Dim sDataSet As String = _txBx_DataSet.Text

                Dim DataSet As New DicomDataSet()

                ' Load the Data Set
                DataSet.Load(sDataSet, DicomDataSetLoadFlags.LoadAndClose)
                Dim waitCursor As New WaitCursor()

                ' Get the Digital Signature Count
                Dim iCount As Integer = DataSet.GetSignaturesCount(Nothing)
                If iCount < 1 Then
                    MessageBox.Show("There are no digital signatures in this DICOM data set.", "Demo")
                Else
                    ' Verify all the Digital Signatures in the whole Data Set
                    Dim bRet As Boolean = DataSet.VerifySignature(Nothing)
                    If bRet = True Then
                        Dim szMsg As String = String.Format("There are {0} digital signatures, and all were verified", iCount)
                        MessageBox.Show(szMsg, "Demo")
                    Else
                        Dim szMsg As String = String.Format("Failed to verify the Digital Signatures")
                        MessageBox.Show("Failed to verify the Digital Signatures", "Demo")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Failed")
            Finally
                EnableControls()
            End Try
        End Sub
    End Class
End Namespace
