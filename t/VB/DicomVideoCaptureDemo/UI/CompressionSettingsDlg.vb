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
Imports System
Imports DicomVideoCaptureDemo.DicomVideoCaptureDemo.Common

Namespace DicomVideoCaptureDemo.UI
   Partial Public Class CompressionSettingsDlg
      Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub _btn_Video_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Video.Click
         If MainForm.mainForm IsNot Nothing Then
            MainForm.mainForm.ShowMPEG2OptionsDlg()
         End If
      End Sub

      Private Sub _btn_Audio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Audio.Click
         If MainForm.mainForm IsNot Nothing Then
            MainForm.mainForm.ShowMPEG2AudioOptionsDlg()
         End If
      End Sub

      Private Function GetCompression() As DICOMVID_IMAGE_COMPRESSION
         If MainForm.mainForm IsNot Nothing Then
            Return MainForm.mainForm.GetCompression()
         End If
         Return DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE
      End Function

      Private Sub SetCompression(ByVal ImageCompression As DICOMVID_IMAGE_COMPRESSION)
         If MainForm.mainForm IsNot Nothing Then
            MainForm.mainForm.SetCompression(ImageCompression)
         End If
      End Sub

      Private Shared Function GetCompressionIndex(ByVal ImageCompression As DICOMVID_IMAGE_COMPRESSION) As Integer
         For i As Integer = 0 To Helper.CompressionStringPair.Length - 1
            If ImageCompression = Helper.CompressionStringPair(i).ImageCompression Then
               Return i
            End If
         Next

         Return 0
      End Function
      Private Sub SetQFactor(ByVal nQFactor As Integer)
         If MainForm.mainForm IsNot Nothing Then
            MainForm.mainForm.SetQFactor(nQFactor)
         End If

      End Sub

      Private Function GetQFactor() As Integer
         If MainForm.mainForm IsNot Nothing Then
            Return MainForm.mainForm.GetQFactor()
         End If
         Return Helper.Q_FACTOR_MIN
      End Function

      Private Sub EnableQFactorCombo()
         Select Case GetCompression()
            Case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY, DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSY
               _combo_QFactor.Enabled = True
               Exit Select
            Case Else
               _combo_QFactor.Enabled = False
               Exit Select
         End Select
      End Sub

      Private Sub Compression_Settings_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Dim strTmp As String
         Dim i As Integer

         For i = 0 To Helper.CompressionStringPair.Length - 1
            _combo_CompressionType.Items.Add(Helper.CompressionStringPair(i).pszName)
         Next

         _combo_CompressionType.SelectedIndex = GetCompressionIndex(GetCompression())

         For i = Helper.Q_FACTOR_MIN To Helper.Q_FACTOR_MAX
            strTmp = i.ToString()
            _combo_QFactor.Items.Add(strTmp)
         Next
         _combo_QFactor.SelectedIndex = GetQFactor() - Helper.Q_FACTOR_MIN
         EnableQFactorCombo()
         EnableMPEG2Options()
         ' disable preview while we are changing compressor settings
         EnablePreview(False)
      End Sub

      Private Sub EnableMPEG2Options()
         If GetCompression() = DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2 Then
            _btn_Video.Enabled = True
            _btn_Audio.Enabled = True
         Else
            _btn_Video.Enabled = False
            _btn_Audio.Enabled = False
         End If
      End Sub

      Private Sub EnablePreview(ByVal bPreview As Boolean)
         If MainForm.mainForm IsNot Nothing Then
            MainForm.mainForm.CaptureCtrl1.Preview = bPreview
         End If
      End Sub

      Private Sub _combo_CompressionType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _combo_CompressionType.SelectedIndexChanged
         Dim nCursel As Integer = _combo_CompressionType.SelectedIndex
         If nCursel <> -1 Then
            SetCompression(Helper.CompressionStringPair(nCursel).ImageCompression)
         End If
         EnableQFactorCombo()
         EnableMPEG2Options()
      End Sub

      Private Sub _btn_Close_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btn_Close.Click
         SetQFactor(_combo_QFactor.SelectedIndex + Helper.Q_FACTOR_MIN)
         ' enable preview now that we finished changing the compressor settings
         EnablePreview(True)
      End Sub
   End Class
End Namespace
