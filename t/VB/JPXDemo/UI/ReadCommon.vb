' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO

Imports Leadtools.Jpeg2000

Public Class ReadCommon
   Public Sub New()
      InitializeComponent()

      ShowFilterType = True
      DialogName = "Read Common"

      InitClass()
   End Sub

   Public Sub New(ByVal mainParentForm As MainForm, ByVal dialogName As String, ByVal bShowFilterType As Boolean)
      InitializeComponent()

      ShowFilterType = bShowFilterType
      _dialogName = dialogName
      MainParenForm = mainParentForm

      InitClass()
   End Sub

   Private _dialogName As String
   Private _showFilterType As Boolean
   Private _readBox As ReadBoxCommonStructure
   Private _mainParenForm As MainForm

   Public Property MainParenForm() As MainForm
      Get
         Return _mainParenForm
      End Get
      Set(ByVal value As MainForm)
         _mainParenForm = value
      End Set
   End Property

   Public Property ReadBox() As ReadBoxCommonStructure
      Get
         Return _readBox
      End Get
      Set(ByVal value As ReadBoxCommonStructure)
         _readBox = value
      End Set
   End Property

   Public Property ShowFilterType() As Boolean
      Get
         Return _showFilterType
      End Get
      Set(ByVal value As Boolean)
         _showFilterType = value
      End Set
   End Property

   Public Property DialogName() As String
      Get
         Return _dialogName
      End Get
      Set(ByVal value As String)
         _dialogName = value
      End Set
   End Property

   Private Sub InitClass()
      Me.Text = "Read " + DialogName + " Box Dialog"

      _lblSecond.Text = DialogName + " Box Data File:"

      _btnRead.Enabled = False

      UpdateFilterTypeControls()
   End Sub

   Private Sub UpdateFilterTypeControls()
      If (ShowFilterType) Then
         Return
      End If

      _grpFilterType.Visible = False
      _txtFilterType.Visible = False

      _grpBoxIndex.Location = New Point(_grpBoxIndex.Location.X, _grpBoxIndex.Location.Y - _grpFilterType.Height)
      _btnRead.Location = New Point(_btnRead.Location.X, _btnRead.Location.Y - _grpFilterType.Height)
      Me.Height -= _grpFilterType.Height
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

   Private Sub _btnSecondBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSecondBrowse.Click
      Dim sfd As New SaveFileDialog()

      sfd.Title = "Save a File"
      sfd.Filter = "All Files (*.*)|*.*"

      If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtSecond.Text = sfd.FileName
      End If
   End Sub

   Private Sub _btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnRead.Click
      If (_txtJPEG2000.Text = "") Then
         Messager.ShowError(Me, "Please select images to read")
         Return
      End If

      Dim boxIndex As Integer
      Dim result As Boolean = True
      Dim _fileInformation As Jpeg2000FileInformation

      ' Get Box number
      boxIndex = Convert.ToInt32(_nudBoxIndex.Value)

      Try
         _fileInformation = CType(MainParenForm.Jpeg2000Eng.GetFileInformation(_txtJPEG2000.Text), Jpeg2000FileInformation)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return
      End Try

      Dim length As Integer

      Select Case (ReadBox.boxType)
         Case Jpeg2000BoxType.IprBox
            If (Not IsNothing(_fileInformation.IntellectualPropertyRights)) Then
               length = _fileInformation.IntellectualPropertyRights.Length
            Else
               length = 0
            End If
            result = CheckAndSave(boxIndex, length)

         Case Jpeg2000BoxType.XmlBox
            if(Not Isnothing(_fileInformation.Xml))
               length = _fileInformation.Xml.Length
               else
               length = 0
            End If
               result = CheckAndSave(boxIndex, length)

         Case Jpeg2000BoxType.Mpeg7Box
            if(Not Isnothing(_fileInformation.Mpeg7))
               length = _fileInformation.Mpeg7.Length
               else
               length = 0
            End If
            result = CheckAndSave(boxIndex, length)

         Case Jpeg2000BoxType.MediaDataBox
            if(Not Isnothing(_fileInformation.MediaData))
               length = _fileInformation.MediaData.Length
               else
               length = 0
            End If
            result = CheckAndSave(boxIndex, length)

         Case Jpeg2000BoxType.FreeBox
            If (Not IsNothing(_fileInformation.Free)) Then
               length = _fileInformation.Free.Length
            Else
               length = 0
            End If
            result = CheckAndSave(boxIndex, length)

         Case Jpeg2000BoxType.GtsoBox
            If (Not IsNothing(_fileInformation.DesiredReproduction)) Then
               length = _fileInformation.DesiredReproduction.Length
            Else
               length = 0
            End If
            result = CheckAndSave(boxIndex, length)

         Case Jpeg2000BoxType.BinaryFilterBox
            result = BinaryFilterProcess()

         Case Jpeg2000BoxType.AssociationBox
            If (Not IsNothing(_fileInformation.Association)) Then
               length = _fileInformation.Association.Length
            Else
               length = 0
            End If
            result = CheckAndSave(boxIndex, length)
      End Select

      If (result) Then
         Messager.ShowInformation(Me, "Read succeeded")
         If (ReadBox.boxType <> Jpeg2000BoxType.BinaryFilterBox) Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
         End If
      End If
   End Sub

   Private Function ReadCommonSaveData(ByVal data() As Byte) As Boolean
      Try
         Dim _readFile As FileStream = File.Open(_txtSecond.Text, FileMode.Create)
         _readFile.Write(data, 0, data.Length)
         _readFile.Close()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
      Return True
   End Function

   Private Function CheckAndSave(ByVal boxIndex As Integer, ByVal boxTypeLength As Integer) As Boolean
      If (boxTypeLength = -1 OrElse boxIndex >= boxTypeLength) Then
         If (boxTypeLength > 0) Then
            Messager.ShowError(Me, String.Format("Box Index should be less than {0}.", boxTypeLength))
         Else
            Messager.ShowError(Me, String.Format("The file has no box of this type."))
         End If

         Return False
      End If

      Dim tempReadBox As Jpeg2000Box
      Try
         tempReadBox = MainParenForm.Jpeg2000Eng.ReadBox(_txtJPEG2000.Text, ReadBox.boxType, boxIndex)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try

      Select Case (ReadBox.boxType)
         Case Jpeg2000BoxType.IprBox
            ReadCommonSaveData((CType(tempReadBox, IprBox)).Data)
         Case Jpeg2000BoxType.XmlBox
            ReadCommonSaveData((CType(tempReadBox, XmlBox)).Data)
         Case Jpeg2000BoxType.Mpeg7Box
            ReadCommonSaveData((CType(tempReadBox, Mpeg7Box)).Data)
         Case Jpeg2000BoxType.MediaDataBox
            ReadCommonSaveData((CType(tempReadBox, MediaDataBox)).Data)
         Case Jpeg2000BoxType.FreeBox
            ReadCommonSaveData((CType(tempReadBox, FreeBox)).Data)
         Case Jpeg2000BoxType.GtsoBox
            ReadCommonSaveData((CType(tempReadBox, GtsoBox)).Data)
         Case Jpeg2000BoxType.AssociationBox
            ReadCommonSaveData((CType(tempReadBox, AssociationBox)).Data)
      End Select
      Return True
   End Function

   Private Function BinaryFilterProcess() As Boolean
      Dim boxIndex As Integer
      Dim fileInfo As Jpeg2000FileInformation
      Dim _binaryFilterBox As BinaryFilterBox

      ' Get Jpeg 2000 file name
      If (_txtJPEG2000.Text = "") Then
         Messager.ShowError(Me, "Please select a JPEG 2000 file")
         Return False
      End If

      If (_txtSecond.Text = "") Then
         Messager.ShowError(Me, "Please select a data file")
         Return False
      End If

      ' Get Box number
      boxIndex = Convert.ToInt32(_nudBoxIndex.Value)

      Try
         fileInfo = MainParenForm.Jpeg2000Eng.GetFileInformation(_txtJPEG2000.Text)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try

      If (fileInfo.BinaryFilter Is Nothing OrElse boxIndex >= fileInfo.BinaryFilter.Length) Then
         Dim message As String
         If (fileInfo.BinaryFilter Is Nothing) Then
            message = String.Format("Box Index should be less than 0.")
         Else
            message = String.Format("Box Index should be less than {0}.", fileInfo.BinaryFilter.Length)
         End If

         Messager.ShowError(Me, message)
         Return False
      End If

      Try
         _binaryFilterBox = CType(MainParenForm.Jpeg2000Eng.ReadBox(_txtJPEG2000.Text, Jpeg2000BoxType.BinaryFilterBox, boxIndex), BinaryFilterBox)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try

         If (ReadBinaryFilterSaveData(_binaryFilterBox.Data)) Then
            _txtFilterType.Text = String.Format( _
                                  "{0:x2}{0:x2}{0:x2}{0:x2}-{0:x2}{0:x2}-{0:x2}{0:x2}-{0:x2}{0:x2}-{0:x2}{0:x2}{0:x2}{0:x2}{0:x2}{0:x2}", _
                                  _binaryFilterBox.FilterType.Id(0), _
                                  _binaryFilterBox.FilterType.Id(1), _
                                  _binaryFilterBox.FilterType.Id(2), _
                                  _binaryFilterBox.FilterType.Id(3), _
                                  _binaryFilterBox.FilterType.Id(4), _
                                  _binaryFilterBox.FilterType.Id(5), _
                                  _binaryFilterBox.FilterType.Id(6), _
                                  _binaryFilterBox.FilterType.Id(7), _
                                  _binaryFilterBox.FilterType.Id(8), _
                                  _binaryFilterBox.FilterType.Id(9), _
                                  _binaryFilterBox.FilterType.Id(10), _
                                  _binaryFilterBox.FilterType.Id(11), _
                                  _binaryFilterBox.FilterType.Id(12), _
                                  _binaryFilterBox.FilterType.Id(13), _
                                  _binaryFilterBox.FilterType.Id(14), _
                                  _binaryFilterBox.FilterType.Id(15))
         End If
         Return True
   End Function

   Private Function ReadBinaryFilterSaveData(ByVal data() As Byte) As Boolean
      Try
         Dim _readFile As FileStream = File.Open(_txtSecond.Text, FileMode.Create)
         _readFile.Write(data, 0, data.Length)
         _readFile.Close()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
      Return True
   End Function
End Class
