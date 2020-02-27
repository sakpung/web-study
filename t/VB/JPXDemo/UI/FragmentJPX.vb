' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Collections.Generic

Imports Leadtools.Jpeg2000

Public Class FragmentJPX
   Public Sub New(ByVal mainParentForm As MainForm)
      InitializeComponent()

      _mainParentForm = mainParentForm
   End Sub

   Private _mainParentForm As MainForm
   Private _fragmentJpx As FragmentJpxStructure
   Private _fileInformation As Jpeg2000FileInformation

   Private Sub _btnInputBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnInputBrowse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "All Files (*.*)|*.*"

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

   Private Sub _btnCodeStreamsFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCodeStreamsFiles.Click
      Dim sfd As New SaveFileDialog()

      sfd.Title = "Save a File"
      sfd.Filter = "All Files (*.*)|*.*"

      If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtCodeStreamsFiles.Text = sfd.FileName
      End If
   End Sub

   Private Function FragmentProcess() As Boolean
      Dim index, offset As Integer
      Dim url As New List(Of UuidUrl)(1)
      Dim fragments As List(Of Fragment)

      _fragmentJpx = New FragmentJpxStructure()

      ' Get Input Jpeg 2000 file name
      _fragmentJpx.inJPG2FileName = _txtInputFile.Text

      ' Get Output Jpeg 2000 file name
      _fragmentJpx.outJPG2FileName = _txtOutputFile.Text

      ' Get Stream file name
      _fragmentJpx.streamFileName = _txtCodeStreamsFiles.Text

      Try
         _fileInformation = CType(_mainParentForm.Jpeg2000Eng.GetFileInformation(_fragmentJpx.inJPG2FileName), Jpeg2000FileInformation)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try

      ' if(_fileInformation.Format != Jpeg2000FileFormat.LeadJpx || _fileInformation.FragmentTable.Length > 0)
      If (_fileInformation.Format <> Jpeg2000FileFormat.LeadJpx OrElse Not IsNothing(_fileInformation.FragmentTable)) Then
         Messager.ShowError(Me, "The input file is not in JPX format or already fragmented")
         Return False
      End If

      Dim UuidUrlItem As New UuidUrl()
      ReDim UuidUrlItem.Flag(2)
      UuidUrlItem.Flag(0) = 0
      UuidUrlItem.Flag(1) = 0
      UuidUrlItem.Flag(2) = 0
      UuidUrlItem.Version = 0

      Dim encoding As New System.Text.UnicodeEncoding()
      Dim filename() As Byte = encoding.GetBytes(_fragmentJpx.streamFileName)
      ReDim UuidUrlItem.Location(filename.Length + 1)
      Array.Copy(filename, UuidUrlItem.Location, filename.Length)
      UuidUrlItem.Location(filename.Length) = 0 ' Nothing termination
      UuidUrlItem.Location(filename.Length + 1) = 0 ' Nothing termination
      url.Add(UuidUrlItem)

      fragments = New List(Of Fragment)

      offset = 0
      For index = 0 To _fileInformation.CodeStream.Length - 1

         Dim fragmenItem As New Fragment()
         fragmenItem.UrlIndex = 1
         fragmenItem.CodeStreamIndex = Convert.ToInt32(index)
         fragmenItem.Offset = offset
         offset += Convert.ToInt32(_fileInformation.CodeStream(index).DataSize)
         fragments.Add(fragmenItem)
      Next index

      Try
         _mainParentForm.Jpeg2000Eng.FragmentJpxFile(_fragmentJpx.inJPG2FileName, _fragmentJpx.outJPG2FileName, url, fragments)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try

      FragmentSaveStreamFile(_fragmentJpx.streamFileName, _fragmentJpx.inJPG2FileName, _fileInformation)

      Return True
   End Function

   Private Function FragmentSaveStreamFile(ByVal streamFileName As String, ByVal inFileName As String, ByVal fileInformation As Jpeg2000FileInformation) As Boolean
      Dim index As Integer
      Dim buffer() As Byte

      ' Load Box Data File
      Dim streamFile As FileStream = File.Open(streamFileName, FileMode.Create)

      If (IsNothing(streamFile)) Then
         Return False
      End If

      Dim inFile As FileStream = File.Open(inFileName, FileMode.Open)
      If (IsNothing(inFile)) Then
         Return False
      End If

      ReDim buffer(Convert.ToInt32(inFile.Length))
      If (IsNothing(buffer)) Then
         Return False
      End If

      For index = 0 To fileInformation.CodeStream.Length - 1
         inFile.Seek(fileInformation.CodeStream(index).DataOffset, SeekOrigin.Begin)
         inFile.Read(buffer, 0, Convert.ToInt32(fileInformation.CodeStream(index).DataSize))
         streamFile.Write(buffer, 0, Convert.ToInt32(fileInformation.CodeStream(index).DataSize))
      Next index

      inFile.Close()
      streamFile.Close()
      Return True
   End Function

   Private Sub _btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      If (_txtInputFile.Text = "") Then
         Messager.ShowError(Me, "Please select the input file")
         Return
      End If

      If (_txtOutputFile.Text = "") Then
         Messager.ShowError(Me, "Please select the output file")
         Return
      End If

      If (_txtCodeStreamsFiles.Text = "") Then
         Messager.ShowError(Me, "Please set the stream file")
         Return
      End If

      If (FragmentProcess()) Then
         Messager.ShowInformation(Me, "File was fragmented successfully!")
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      Else
         Messager.ShowError(Me, "Error fragmenting the file!")
      End If
   End Sub
End Class
