' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Collections.Generic

Public Class AppendCommon
   Private _dialogName As String
   Private _showFilterType As Boolean
   Private _appendCommonData As AppendCommonStructure
   Private _filterTypes As List(Of String)
   Private pGZIP() As Byte = { _
                              Convert.ToByte(Val("0xEC")), _
                              Convert.ToByte(Val("0x34")), _
                              Convert.ToByte(Val("0x0B")), _
                              Convert.ToByte(Val("0x04")), _
                              Convert.ToByte(Val("0x74")), _
                              Convert.ToByte(Val("0xC5")), _
                              Convert.ToByte(Val("0x11")), _
                              Convert.ToByte(Val("0xD4")), _
                              Convert.ToByte(Val("0xA7")), _
                              Convert.ToByte(Val("0x29")), _
                              Convert.ToByte(Val("0x87")), _
                              Convert.ToByte(Val("0x9E")), _
                              Convert.ToByte(Val("0xA3")), _
                              Convert.ToByte(Val("0x54")), _
                              Convert.ToByte(Val("0x8F")), _
                              Convert.ToByte(Val("0x0E "))}

   Private pDES() As Byte = { _
                              Convert.ToByte(Val("0xEC")), _
                              Convert.ToByte(Val("0x34")), _
                              Convert.ToByte(Val("0x0B")), _
                              Convert.ToByte(Val("0x04")), _
                              Convert.ToByte(Val("0x74")), _
                              Convert.ToByte(Val("0xC5")), _
                              Convert.ToByte(Val("0x11")), _
                              Convert.ToByte(Val("0xD4")), _
                              Convert.ToByte(Val("0xA7")), _
                              Convert.ToByte(Val("0x29")), _
                              Convert.ToByte(Val("0x87")), _
                              Convert.ToByte(Val("0x9E")), _
                              Convert.ToByte(Val("0xA3")), _
                              Convert.ToByte(Val("0x54")), _
                              Convert.ToByte(Val("0x8F")), _
                              Convert.ToByte(Val("0x0F "))}

   Public Property FilterTypes() As List(Of String)
      Get
         Return _filterTypes
      End Get
      Set(ByVal value As List(Of String))
         _filterTypes = value
      End Set
   End Property

   Public Property AppendCommonData() As AppendCommonStructure
      Get
         Return _appendCommonData
      End Get
      Set(ByVal value As AppendCommonStructure)
         _appendCommonData = value
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

   Public Property ShowFilterType() As Boolean
      Get
         Return _showFilterType
      End Get
      Set(ByVal value As Boolean)
         _showFilterType = value
      End Set
   End Property

   Public Property Jpeg2000FileName() As String
      Get
         Return _txtJPEG2000.Text
      End Get
      Set(ByVal value As String)
         _txtJPEG2000.Text = value
      End Set
   End Property

   Public Property SecondLabel() As String
      Get
         Return _lblSecond.Text
      End Get
      Set(ByVal value As String)
         _lblSecond.Text = value
      End Set
   End Property

   Public Sub New()
      InitializeComponent()

      ShowFilterType = False
      DialogName = "Append Common"
      FilterTypes = Nothing

      AppendCommonData = New AppendCommonStructure()

      InitClass()
   End Sub

   Public Sub New(ByVal dialogName As String, ByVal bShowFilterType As Boolean, ByVal filterItems As List(Of String))
      InitializeComponent()

      ShowFilterType = bShowFilterType
      _dialogName = dialogName

      FilterTypes = filterItems

      InitClass()
   End Sub

   Private Sub InitClass()
      Me.Text = "Append " + DialogName + " Box Dialog"

      SecondLabel = DialogName + " Box Data File:"

      ShowFilterTypeControls(ShowFilterType)
   End Sub

   Private Sub ShowFilterTypeControls(ByVal showFilterType As Boolean)
      If (showFilterType) Then
         For index As Integer = 0 To FilterTypes.Count - 1
            _cbFilterType.Items.Add(FilterTypes(index))
         Next index
         _cbFilterType.SelectedIndex = 0
         Return
      End If

      _lblFilterType.Visible = False
      _cbFilterType.Visible = False

      _grpData.Height -= _cbFilterType.Height
      _lblSecond.Location = New Point(_lblSecond.Location.X, _lblSecond.Location.Y - _cbFilterType.Height)
      _txtSecond.Location = New Point(_txtSecond.Location.X, _txtSecond.Location.Y - _cbFilterType.Height)
      _btnSecondBrowse.Location = New Point(_btnSecondBrowse.Location.X, _btnSecondBrowse.Location.Y - _cbFilterType.Height)
      _btnOk.Location = New Point(_btnOk.Location.X, _btnOk.Location.Y - _cbFilterType.Height)
      _btnCancel.Location = New Point(_btnCancel.Location.X, _btnCancel.Location.Y - _cbFilterType.Height)
      Me.Height -= _cbFilterType.Height
   End Sub

   Private Sub _btnJPEG2000Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnJPEG2000Browse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtJPEG2000.Text = ofd.FileName
      End If
   End Sub

   Private Sub _btnSecondBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSecondBrowse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Title = "Open a File"
      ofd.Filter = "All Files (*.*)|*.*"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtSecond.Text = ofd.FileName
      End If
   End Sub

   Private Sub _btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      If (_txtJPEG2000.Text = "") Then
         Messager.ShowError(Me, "Please set the Jpeg2000 file")
         Return
      End If

      If (_txtSecond.Text = "") Then
         Messager.ShowError(Me, "Please set the Data file")
         Return
      End If


      Dim wait As New WaitCursor()
      Try
         Dim temp As New AppendCommonStructure()
         If (ShowFilterType) Then
            Select Case (_cbFilterType.SelectedIndex)
               Case 0
                  temp.type.Id = pGZIP
               Case 1
                  temp.type.Id = pDES
            End Select
         End If

         temp.data = File.ReadAllBytes(_txtSecond.Text)
         AppendCommonData = temp
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         wait.Dispose()
      End Try
   End Sub
End Class
