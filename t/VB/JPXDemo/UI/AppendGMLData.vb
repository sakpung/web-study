' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Imports Leadtools.Jpeg2000

Public Class AppendGMLData
   Public Sub New(ByVal mainParentForm As MainForm)
      InitializeComponent()

      _mainParentForm = mainParentForm

      InitClass()
   End Sub

   Private Sub InitClass()
      Dim temp As New AppendGMLStructure()
      temp.gMLData = New GmlData()

      AppendGML = temp

      _btnOk.Enabled = False
   End Sub

   Private _mainParentForm As MainForm
   Private _appendGML As AppendGMLStructure

   Public Property MainParentForm() As MainForm
      Get
         Return _mainParentForm
      End Get
      Set(ByVal value As MainForm)
         _mainParentForm = value
      End Set
   End Property

   Public Property AppendGML() As AppendGMLStructure
      Get
         Return _appendGML
      End Get
      Set(ByVal value As AppendGMLStructure)
         _appendGML = value
      End Set
   End Property

   Private Sub _btnJPEG2000Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnJPEG2000Browse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Filter = "JPX Files(*.jpx)|*.jpx"
      ofd.Title = "Open a File"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtJPEG2000FileName.Text = ofd.FileName
      End If
   End Sub

   Private Sub _btnXMLBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnXMLBrowse.Click
      Dim ofd As New OpenFileDialog()

      ofd.Filter = "XML Files(*.xml)|*.xml"
      ofd.Title = "Open a File"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtXMLDataFile.Text = ofd.FileName
      End If
   End Sub

   Private Sub _btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnAdd.Click
      If (AppendGMLUpdateGMLInfo()) Then
         Dim item As New GMLListItem(_txtLabel.Text, Path.GetFileName(_txtXMLDataFile.Text), AppendGML.gMLData.Data(AppendGML.gMLData.Data.Count - 1))

         _lstLabel.Items.Add(_txtLabel.Text)
         _lstXmlDataFile.Items.Add(item)

         SetSelectedItem(_lstLabel.Items.Count - 1)

         _btnOk.Enabled = True
      End If
   End Sub

   Private Sub _btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnUp.Click
      Dim index As Integer = _lstLabel.SelectedIndex
      If (index <= 0) Then
         Return
      End If

      Dim stringItem As String = CType(_lstLabel.Items(index), String)
      _lstLabel.Items.RemoveAt(index)
      _lstLabel.Items.Insert(index - 1, stringItem)

      Dim item As GMLListItem = CType(_lstXmlDataFile.Items(index), GMLListItem)
      _lstXmlDataFile.Items.RemoveAt(index)
      _lstXmlDataFile.Items.Insert(index - 1, item)

      SetSelectedItem(index - 1)
   End Sub

   Private Sub _btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnDown.Click
      Dim index As Integer = _lstLabel.SelectedIndex
      If (index >= _lstLabel.Items.Count - 1) Then
         Return
      End If

      Dim stringItem As String = CType(_lstLabel.Items(index), String)
      _lstLabel.Items.RemoveAt(index)
      _lstLabel.Items.Insert(index + 1, stringItem)

      Dim item As GMLListItem = CType(_lstXmlDataFile.Items(index), GMLListItem)
      _lstXmlDataFile.Items.RemoveAt(index)
      _lstXmlDataFile.Items.Insert(index + 1, item)

      SetSelectedItem(index + 1)
   End Sub

   Private Sub _btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnDelete.Click
      Dim index As Integer = _lstLabel.SelectedIndex

      If (index < 0) Then
         Return
      End If

      _lstLabel.Items.RemoveAt(index)
      _lstXmlDataFile.Items.RemoveAt(index)

      index = Math.Max(0, index - 1)

      If (_lstLabel.Items.Count > 0) Then
         SetSelectedItem(index)
      End If
   End Sub

   Private Sub _btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      If (AppendGMLProcess()) Then
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      End If
   End Sub

   Private Sub _lst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _lstLabel.Click, _lstXmlDataFile.Click
      SetSelectedItem((CType(sender, ListBox)).SelectedIndex)
   End Sub

   Private Sub SetSelectedItem(ByVal index As Integer)
      _lstLabel.SelectedIndex = index
      _lstXmlDataFile.SelectedIndex = index
   End Sub

   Private Function AppendGMLProcess() As Boolean
      Dim _gmlData As GmlData

      If (_txtJPEG2000FileName.Text = "") Then
         Messager.ShowError(Me, "You must select a JPX file!")
         Return False
      End If

      If (_lstXmlDataFile.Items.Count = 0) Then
         Messager.ShowError(Me, "There is no GML data to append")
         Return False
      End If

      If (_lstXmlDataFile.Items.Count = 0) Then
         Messager.ShowError(Me, "There is no GML data to append")
         Return False
      End If

      _gmlData = New GmlData()
      _gmlData.Data = New List(Of GmlElement)

      Dim index As Integer
      For index = 0 To _lstXmlDataFile.Items.Count - 1
         _gmlData.Data.Add((CType(_lstXmlDataFile.Items(index), GMLListItem)).GMLElement)
      Next index

      Try
         MainParentForm.Jpeg2000Eng.AppendGmlData(_txtJPEG2000FileName.Text, _gmlData)

         Messager.ShowError(Me, "Appending Succeeded")
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try

      Return True
   End Function

   Private Function AppendGMLUpdateGMLInfo() As Boolean
      If (_txtLabel.Text = "") Then
         Messager.ShowError(Me, "No Label")
         Return False
      End If

      Dim GmlElement As New GmlElement()
      GmlElement.Label = Encoding.UTF8.GetBytes(_txtLabel.Text)
      GmlElement.Data = File.ReadAllBytes(_txtXMLDataFile.Text)

      Dim dataItem As New GmlData()
      AppendGML.gMLData.Data.Add(GmlElement)

      Return True
   End Function
End Class
