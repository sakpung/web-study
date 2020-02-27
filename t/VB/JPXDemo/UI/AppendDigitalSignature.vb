' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO

Public Class AppendDigitalSignature
   Public Sub New()
      InitializeComponent()

      InitClass()
   End Sub

   Private _digitalSignatureData As DigitalSignatureStructure

   Public Property DigitalSignatureData() As DigitalSignatureStructure
      Get
         Return _digitalSignatureData
      End Get
      Set(ByVal value As DigitalSignatureStructure)
         _digitalSignatureData = value
      End Set
   End Property

   Private Sub InitClass()
      _nudLength.Value = 0

      _nudOffset.Value = 0

      For index As Integer = 0 To 255
         _cbSignatureType.Items.Add(index.ToString())
      Next index

      _cbSignatureType.SelectedIndex = 0

      _cbPointerType.Items.Add("Full")
      _cbPointerType.Items.Add("Partial")
      _cbPointerType.SelectedIndex = 0

      UpdateControls(False)
   End Sub

   Private Sub UpdateControls(ByVal enable As Boolean)
      _grpPointerData.Enabled = enable

      _lblOffset.Enabled = enable
      _nudOffset.Enabled = enable

      _lblLength.Enabled = enable
      _nudLength.Enabled = enable
   End Sub

   Private Sub _btnJPEGBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnJPEGBrowse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "Jpx Files (*.jpx)|*.jpx"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtJPEG2000File.Text = ofd.FileName
      End If
   End Sub

   Private Sub _btnSignatureData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSignatureData.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "All Files (*.*)|*.*"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtSignatureDataFile.Text = ofd.FileName
      End If
   End Sub

   Private Sub _cbPointerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbPointerType.SelectedIndexChanged
      UpdateControls(_cbPointerType.SelectedIndex = 1)
   End Sub

   Private Sub _btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      If (_txtJPEG2000File.Text = "") Then
         Messager.ShowError(Me, "Please select a Jpeg2000 file")
         Return
      End If

      If (_txtSignatureDataFile.Text = "") Then
         Messager.ShowError(Me, "Please select a signature data file")
         Return
      End If

      Dim temp As New DigitalSignatureStructure()
      temp.length = Convert.ToInt32(_nudLength.Value)
      temp.offset = Convert.ToInt32(_nudOffset.Value)
      temp.pointerType = _cbPointerType.SelectedIndex
      temp.signatureType = Convert.ToInt32(_cbSignatureType.SelectedIndex)

      ' Load Box Data File
      temp.data = File.ReadAllBytes(_txtSignatureDataFile.Text)

      ' Get Jpeg 2000 file name
      temp.jPG2FileName = _txtJPEG2000File.Text

      DigitalSignatureData = temp

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub
End Class
