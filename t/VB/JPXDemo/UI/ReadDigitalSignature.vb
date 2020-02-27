' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO

Imports Leadtools.Jpeg2000

Public Class ReadDigitalSignature
   Public Sub New(ByVal parentForm As MainForm)
      InitializeComponent()

      MainParentForm = parentForm

      InitClass()
   End Sub

   Private _mainParentForm As MainForm

   Public Property MainParentForm() As MainForm
      Get
         Return _mainParentForm
      End Get
      Set(ByVal value As MainForm)
         _mainParentForm = value
      End Set
   End Property

   Private Sub InitClass()
      _nudBoxIndex.Value = 0
   End Sub

   Private Sub _btnJPEG2000Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnJPEG2000Browse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "All Files (*.*)|*.*"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtJPEG2000.Text = ofd.FileName
         _btnRead.Enabled = True
      End If
   End Sub

   Private Sub _btnDataFileBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnDataFileBrowse.Click
      Dim sfd As New SaveFileDialog()

      sfd.Title = "Save a File"
      sfd.Filter = "All Files (*.*)|*.*"

      If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtDataFile.Text = sfd.FileName
      End If
   End Sub

   Private Sub _btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnRead.Click
      Dim boxIndex As Integer
      Dim fileInfo As Jpeg2000FileInformation
      Dim _digitalSignatureBox As DigitalSignatureBox

      If (_txtJPEG2000.Text = "") Then
         Messager.ShowError(Me, "Please select a JPEG 2000 file")
         Return
      End If

      If (_txtDataFile.Text = "") Then
         Messager.ShowError(Me, "Please select a data file")
         Return
      End If

      Try
         fileInfo = MainParentForm.Jpeg2000Eng.GetFileInformation(_txtJPEG2000.Text)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return
      End Try

      boxIndex = Convert.ToInt32(_nudBoxIndex.Value)

      If (fileInfo.DigitalSignature Is Nothing OrElse boxIndex >= fileInfo.DigitalSignature.Length) Then
         Dim message As String

         If (fileInfo.DigitalSignature Is Nothing) Then
            message = "Box Index should be less than 0."
         Else
            message = String.Format("Box Index should be less than {0}.", fileInfo.DigitalSignature.Length)
         End If

         Messager.ShowError(Me, message)
         Return
      End If

      Try
         _digitalSignatureBox = CType(MainParentForm.Jpeg2000Eng.ReadBox(_txtJPEG2000.Text, Jpeg2000BoxType.DigitalSignatureBox, boxIndex), DigitalSignatureBox)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return
      End Try

      If (ReadSGSaveData(_digitalSignatureBox.Data)) Then
         _txtSignatureType.Text = _digitalSignatureBox.SignatureType.ToString()
         _txtPointerType.Text = _digitalSignatureBox.PointerType.ToString()
         _txtOffset.Text = _digitalSignatureBox.Offset.ToString()
         _txtLength.Text = _digitalSignatureBox.Length.ToString()
      End If

      Messager.ShowInformation(Me, "Read succeeded")
   End Sub

   Private Function ReadSGSaveData(ByVal data() As Byte) As Boolean
      If (data Is Nothing) Then
         Return True
      End If
      Try
         Dim _readFile As FileStream = File.Open(_txtDataFile.Text, FileMode.Create)
         _readFile.Write(data, 0, data.Length)
         _readFile.Close()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
      Return True
   End Function
End Class
