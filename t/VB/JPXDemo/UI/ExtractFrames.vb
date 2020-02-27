' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic

Imports Leadtools.Jpeg2000

Public Class ExtractFrames

   Public Sub New(ByVal mainParentForm As MainForm)
      InitializeComponent()

      InitClass()

      _mainParentForm = mainParentForm
   End Sub

   Private _extractFrame As ExtractFrameStructure
   Private _mainParentForm As MainForm

   Private Sub InitClass()
      _txtFromFrame.Text = "0"
      _txtToFrame.Text = "0"
   End Sub

   Private Sub _btnInputBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnInputBrowse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtInputFile.Text = ofd.FileName
      End If
   End Sub

   Private Sub _btnOutputBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOutputBrowse.Click
      Dim sfd As New SaveFileDialog()

      sfd.Title = "Save a File"
      sfd.Filter = "All Files (*.*)|*.*"

      If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtOutputFile.Text = sfd.FileName
      End If
   End Sub

   Private Sub _btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnExtract.Click
      If (_txtInputFile.Text = "") Then
         Messager.ShowError(Me, "Please select an input file.")
         Return
      End If

      If (_txtOutputFile.Text = "") Then
         Messager.ShowError(Me, "Please select an output file.")
         Return
      End If

      If (ExtractFrameProcess()) Then
         Messager.ShowInformation(Me, "Frames Extracted Successfully.")
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      End If
   End Sub

   Private Function ExtractFrameProcess() As Boolean
      Dim frames As New List(Of Integer)
      Dim _fileInformation As Jpeg2000FileInformation

      ' Get In Jpeg 2000 file name
      _extractFrame.inJPG2FileName = _txtInputFile.Text

      ' Get Out Jpeg 2000 file name
      _extractFrame.outJPG2FileName = _txtOutputFile.Text

      ' Get Frame Index
      _fileInformation = _mainParentForm.Jpeg2000Eng.GetFileInformation(_extractFrame.inJPG2FileName)

      If ((Convert.ToInt32(_txtFromFrame.Text) >= _fileInformation.Frame.Length) OrElse (Convert.ToInt32(_txtToFrame.Text) >= _fileInformation.Frame.Length) OrElse (Convert.ToInt32(_txtToFrame.Text) < Convert.ToInt32(_txtFromFrame.Text))) Then
         If _fileInformation.Frame.Length > 1 Then
            Messager.ShowError(Me, String.Format("Frame Index should be between 0 and {0}.", _fileInformation.Frame.Length - 1))
         ElseIf _fileInformation.Frame.Length = 1 Then
            Messager.ShowError(Me, String.Format("Frame Index should be 0, only one is available in this file."))
         Else
            Messager.ShowError(Me, String.Format("No frame is avialable."))
         End If

         Return False
      End If

      frames = New List(Of Integer)

      For index As Integer = Convert.ToInt32(_txtFromFrame.Text) To Convert.ToInt32(_txtToFrame.Text)
         frames.Add(index)
      Next index

      Try
         _mainParentForm.Jpeg2000Eng.ExtractFrames(_extractFrame.inJPG2FileName, _extractFrame.outJPG2FileName, frames)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
      Return True
   End Function

   Private Sub _txtToFromFrames_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtFromFrame.TextChanged, _txtToFrame.TextChanged
      Dim index As Integer
      Dim tempString As String = CType(sender, TextBox).Text

      While (index < tempString.Length)
         If (Not (Char.IsNumber(tempString.Chars(index)))) Then
            tempString = tempString.Remove(index, 1)
         Else
            index += 1
         End If
      End While

      If (tempString.Length = 0) Then
         CType(sender, TextBox).Text = "0"
      Else
         CType(sender, TextBox).Text = tempString
      End If
   End Sub
End Class
