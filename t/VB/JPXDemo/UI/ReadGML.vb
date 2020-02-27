' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Jpeg2000

Public Class ReadGML
   Public Sub New(ByVal mainParentForm As MainForm)
      InitializeComponent()

      _mainParentForm = mainParentForm

      InitClass()
   End Sub

   Private Sub InitClass()
      _btnRead.Enabled = False
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

   Private Sub _btnJPEG2000Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnJPEG2000Browse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "All Files (*.*)|*.*"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtJPEG2000.Text = ofd.FileName
         _btnRead.Enabled = True
      End If
   End Sub

   Private Sub _btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnRead.Click
      Dim _gmlData As GmlData

      If (_txtJPEG2000.Text = "") Then
         Messager.ShowError(Me, "Please select a file!")
         Return
      End If

      Try
         _gmlData = MainParentForm.Jpeg2000Eng.ReadGmlData(_txtJPEG2000.Text)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return
      End Try

      Dim message As String
      If (_gmlData.Data.Count > 0) Then
         message = String.Format("This file has GML data for {0} codestreams", _gmlData.Data.Count)
      Else
         message = "This file has no GML data"
      End If

      Messager.ShowInformation(Me, message)

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub
End Class
