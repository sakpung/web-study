' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO

Imports Leadtools
Imports Leadtools.Jpeg2000

Public Class SaveList
   Private _mainForm As MainForm

   Public Sub New(ByVal mainForm As MainForm)
      InitializeComponent()

      _mainForm = mainForm

      InitClass()
   End Sub

   Private Sub InitClass()
      For Each child As ViewerForm In _mainForm.MdiChildren
         Dim item As ListItem

         item.Name = Path.GetFileName(child.Text)
         item.Image = child.Viewer.Image
         _lstAvailableImages.Items.Add(item)
      Next child

      _lstAvailableImages.SelectedIndex = 0

      '  Set the BBP ComboBox...
      _cbBPP.Items.Add("0")
      _cbBPP.Items.Add("8")
      _cbBPP.Items.Add("12")
      _cbBPP.Items.Add("16")
      _cbBPP.Items.Add("24")
      _cbBPP.Items.Add("32")
      _cbBPP.Items.Add("48")
      _cbBPP.SelectedIndex = 0

      ' Set the Quality Factor ComboBox...
      _cbQualityFactor.Items.Add("0-Lossless")
      For index As Integer = 1 To 255
         _cbQualityFactor.Items.Add(index.ToString())
      Next index
      _cbQualityFactor.SelectedIndex = 0

      '  Disable the Save Button until the save file name is specified...
      _btnSave.Enabled = False
   End Sub

   Private Sub _btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnAdd.Click
      _lstSelectedImages.Items.Add(_lstAvailableImages.Items(_lstAvailableImages.SelectedIndex))
      _lstSelectedImages.SelectedIndex = _lstSelectedImages.Items.Count - 1
   End Sub

   Private Sub _btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnRemove.Click
      Dim index As Integer = _lstSelectedImages.SelectedIndex

      If (index < 0) Then
         Return
      End If

      _lstSelectedImages.Items.RemoveAt(_lstSelectedImages.SelectedIndex)

      If (_lstSelectedImages.Items.Count > 0) Then
         _lstSelectedImages.SelectedIndex = Math.Max(0, index - 1)
      Else
         _lstSelectedImages.SelectedIndex = -1
      End If

   End Sub

   Private Sub _btnAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnAddAll.Click
      For index As Integer = 0 To _lstAvailableImages.Items.Count - 1
         _lstSelectedImages.Items.Add(_lstAvailableImages.Items(index))
         _lstSelectedImages.SelectedIndex = _lstSelectedImages.Items.Count - 1
      Next index
   End Sub

   Private Sub _btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnRemoveAll.Click
      _lstSelectedImages.Items.Clear()
   End Sub

   Private Sub _btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnUp.Click
      Dim index As Integer = _lstSelectedImages.SelectedIndex
      If (index <= 0) Then
         Return
      End If

      Dim item As ListItem = CType(_lstSelectedImages.Items(_lstSelectedImages.SelectedIndex), ListItem)

      _lstSelectedImages.Items.RemoveAt(_lstSelectedImages.SelectedIndex)
      _lstSelectedImages.Items.Insert(index - 1, item)
      _lstSelectedImages.SelectedIndex = index - 1
   End Sub

   Private Sub _btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnDown.Click
      Dim index As Integer = _lstSelectedImages.SelectedIndex
      If (index >= _lstSelectedImages.Items.Count - 1) Then
         Return
      End If

      Dim item As ListItem = CType(_lstSelectedImages.Items(_lstSelectedImages.SelectedIndex), ListItem)

      _lstSelectedImages.Items.RemoveAt(_lstSelectedImages.SelectedIndex)
      _lstSelectedImages.Items.Insert(index + 1, item)
      _lstSelectedImages.SelectedIndex = index + 1
   End Sub

   Private Sub _btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnBrowse.Click
      Dim sfd As New SaveFileDialog()

      sfd.Filter = "JPX Files(*.jpx)|*.jpx"
      sfd.Title = "Save As"

      If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         _txtFileName.Text = sfd.FileName
         _btnSave.Enabled = True
      End If
   End Sub

   Private Sub _btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSave.Click
      If (_lstSelectedImages.Items.Count = 0) Then

         Messager.ShowError(Me, "Please select images to save")
         Return
      End If

      Dim format As Jpeg2000FileFormat
      If (Path.GetExtension(_txtFileName.Text) = ".jp2") Then
         format = Jpeg2000FileFormat.LeadJp2
      Else
         format = Jpeg2000FileFormat.LeadJpx
      End If

      Dim saveImage As RasterImage = (CType(_lstSelectedImages.Items(0), ListItem).Image.CloneAll())
      For index As Integer = 1 To _lstSelectedImages.Items.Count - 1
         saveImage.AddPage((CType(_lstSelectedImages.Items(index), ListItem)).Image.CloneAll())
      Next index

      Try
         _mainForm.Jpeg2000Eng.Save(_mainForm.Codecs, _
                                    _txtFileName.Text, _
                                    saveImage, _
                                    format, _
                                    Convert.ToInt32(_cbBPP.SelectedItem), _
                                    Convert.ToInt32(_cbQualityFactor.SelectedIndex))

         DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub
End Class
