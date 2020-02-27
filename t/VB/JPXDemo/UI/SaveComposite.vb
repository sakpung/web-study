' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Collections.Generic

Imports Leadtools.Jpeg2000

Public Class SaveComposite
   Public Sub New(ByVal mainForm As MainForm, ByVal dialogName As String, ByVal buttonName As String, ByVal bIsComposite As Boolean)
      InitializeComponent()

      _mainForm = mainForm
      Me.Text = dialogName
      _btnSave.Text = buttonName
      isComposite = bIsComposite

      InitClass()
   End Sub

   Private _mainForm As MainForm
   Private _isComposite As Boolean

   Private Property IsComposite() As Boolean
      Get
         Return _isComposite
      End Get
      Set(ByVal value As Boolean)
         _isComposite = value
      End Set
   End Property

   Private Sub InitClass()
      For Each child As ViewerForm In _mainForm.MdiChildren
         Dim item As New ListItem(Path.GetFileName(child.Text), child.Viewer.Image)
         _cbAvailableColorImages.Items.Add(item)
         _cbAvailableOpacityImages.Items.Add(item)
      Next child

      _cbAvailableColorImages.SelectedIndex = 0
      _cbAvailableOpacityImages.SelectedIndex = 0

      ' Set the Use Opacity to true and to use opacity...
      _cbUseOpacity.Checked = True
      _rbOpacity.Checked = True

      ' Set the BBP ComboBox...
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

      ' Disable the Save Button until the save file name is specified...
      _btnSave.Enabled = False
   End Sub

   Private Sub _cbUseOpacity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cbUseOpacity.CheckedChanged
      _lblAvailableOpacityImages.Enabled = _cbUseOpacity.Checked

      _cbAvailableOpacityImages.Enabled = _cbUseOpacity.Checked
      _rbOpacity.Enabled = _cbUseOpacity.Checked
      _rbPreopacity.Enabled = _cbUseOpacity.Checked
   End Sub

   Private Sub _btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnAdd.Click
      _lstColorImages.Items.Add(_cbAvailableColorImages.Items(_cbAvailableColorImages.SelectedIndex))
      _lstColorImages.SelectedIndex = _lstColorImages.Items.Count - 1

      If (_cbUseOpacity.Checked) Then
         If (_rbOpacity.Checked) Then
            _lstPreOpacityImages.Items.Add(New ListItem("*", Nothing))
            _lstOpacityImages.Items.Add(_cbAvailableOpacityImages.Items(_cbAvailableOpacityImages.SelectedIndex))
            _lstOpacityImages.SelectedIndex = _lstOpacityImages.Items.Count - 1
         Else
            _lstOpacityImages.Items.Add(New ListItem("*", Nothing))
            _lstPreOpacityImages.Items.Add(_cbAvailableOpacityImages.Items(_cbAvailableOpacityImages.SelectedIndex))
            _lstPreOpacityImages.SelectedIndex = _lstPreOpacityImages.Items.Count - 1
         End If
      Else
         _lstOpacityImages.Items.Add(New ListItem("*", Nothing))
         _lstPreOpacityImages.Items.Add(New ListItem("*", Nothing))
      End If

      SetSelectedItem(_lstColorImages.Items.Count - 1)

      _lstColorImages.ScrollAlwaysVisible = False
      _lstPreOpacityImages.ScrollAlwaysVisible = False
      _lstOpacityImages.ScrollAlwaysVisible = False
   End Sub

   Private Sub _btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnMoveUp.Click
      If (_lstColorImages.SelectedIndex < 0) Then
         Return
      End If

      Dim index As Integer = Math.Max(_lstColorImages.SelectedIndex - 1, 0)
      SetSelectedItem(index)
   End Sub

   Private Sub _btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnMoveDown.Click
      If (_lstColorImages.SelectedIndex < 0) Then
         Return
      End If

      Dim index As Integer = Math.Min(_lstColorImages.SelectedIndex + 1, _lstColorImages.Items.Count - 1)
      SetSelectedItem(index)
   End Sub

   Private Sub _btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnDelete.Click
      If (_lstColorImages.SelectedIndex < 0) Then
         Return
      End If

      Dim index As Integer = _lstColorImages.SelectedIndex
      _lstColorImages.Items.RemoveAt(index)
      _lstOpacityImages.Items.RemoveAt(index)
      _lstPreOpacityImages.Items.RemoveAt(index)
        If _lstColorImages.Items.Count > 0 Then
            index = Math.Max(0, index - 1)
            SetSelectedItem(index)
        End If
    End Sub

   Private Sub _btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnUp.Click
      Dim index As Integer = _lstColorImages.SelectedIndex
      If (index <= 0) Then
         Return
      End If

      Dim item As ListItem = CType(_lstColorImages.Items(index), ListItem)
      _lstColorImages.Items.RemoveAt(index)
      _lstColorImages.Items.Insert(index - 1, item)

      item = CType(_lstOpacityImages.Items(index), ListItem)
      _lstOpacityImages.Items.RemoveAt(index)
      _lstOpacityImages.Items.Insert(index - 1, item)

      item = CType(_lstPreOpacityImages.Items(index), ListItem)
      _lstPreOpacityImages.Items.RemoveAt(index)
      _lstPreOpacityImages.Items.Insert(index - 1, item)

      SetSelectedItem(index - 1)
   End Sub

   Private Sub _btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnDown.Click
      Dim index As Integer = _lstColorImages.SelectedIndex
      If (index >= _lstColorImages.Items.Count - 1) Then
         Return
      End If

      Dim item As ListItem = CType(_lstColorImages.Items(index), ListItem)
      _lstColorImages.Items.RemoveAt(index)
      _lstColorImages.Items.Insert(index + 1, item)

      item = CType(_lstOpacityImages.Items(index), ListItem)
      _lstOpacityImages.Items.RemoveAt(index)
      _lstOpacityImages.Items.Insert(index + 1, item)

      item = CType(_lstPreOpacityImages.Items(index), ListItem)
      _lstPreOpacityImages.Items.RemoveAt(index)
      _lstPreOpacityImages.Items.Insert(index + 1, item)

      SetSelectedItem(index + 1)
   End Sub

   Private Sub _btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnBrowse.Click
      If (IsComposite) Then
         Dim sfd As New SaveFileDialog()

         sfd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2"
         sfd.Title = "Save As"

         If (sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            _txtFileName.Text = sfd.FileName
            _btnSave.Enabled = True
         End If
      Else
         Dim ofd As New OpenFileDialog()

         ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2"
         ofd.Title = "Open file"

         If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            _txtFileName.Text = ofd.FileName
            _btnSave.Enabled = True
         End If
      End If
   End Sub

   Private Sub _btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnSave.Click
      If (_lstColorImages.Items.Count = 0) Then
         Messager.ShowError(Me, "Please select images to save")
         Return
      End If

      Dim format As Jpeg2000FileFormat

      If (Path.GetExtension(_txtFileName.Text) = ".jp2") Then
         format = Jpeg2000FileFormat.LeadJp2
      Else
         format = Jpeg2000FileFormat.LeadJpx
      End If

      Dim saveCompositeImage As New List(Of CompositeJpxImages)

      Dim itemImage As CompositeJpxImages
      Dim item As ListItem
      For index As Integer = 0 To _lstColorImages.Items.Count - 1
         itemImage = New CompositeJpxImages()

         item = CType(_lstColorImages.Items(index), ListItem)
         itemImage.ColorImage = item.Image.CloneAll()

         item = CType(_lstOpacityImages.Items(index), ListItem)
         If (item.Name = "*") Then
            itemImage.OpacityImage = Nothing
         Else
            itemImage.OpacityImage = item.Image.CloneAll()
         End If

         item = CType(_lstPreOpacityImages.Items(index), ListItem)
         If (item.Name = "*") Then
            itemImage.PreOpacityImage = Nothing
         Else
            itemImage.PreOpacityImage = item.Image.CloneAll()
         End If

         saveCompositeImage.Add(itemImage)
      Next index

      Try
         If (IsComposite) Then
            _mainForm.Jpeg2000Eng.SaveComposite(_mainForm.Codecs, _
                                                _txtFileName.Text, _
                                                saveCompositeImage, _
                                                format, _
                                                Convert.ToInt32(_cbBPP.SelectedItem), _
                                                Convert.ToInt32(_cbQualityFactor.SelectedIndex))
         Else
            _mainForm.Jpeg2000Eng.AppendFrames(_mainForm.Codecs, _
                                               _txtFileName.Text, _
                                               saveCompositeImage, _
                                               Convert.ToInt32(_cbBPP.SelectedItem), _
                                               Convert.ToInt32(_cbQualityFactor.SelectedIndex))
         End If

         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub SetSelectedItem(ByVal index As Integer)
      _lstColorImages.SelectedIndex = index
      _lstOpacityImages.SelectedIndex = index
      _lstPreOpacityImages.SelectedIndex = index
   End Sub

   Private Sub _lst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _lstColorImages.Click, _
                                                                                              _lstOpacityImages.Click, _
                                                                                              _lstPreOpacityImages.Click
      SetSelectedItem(CType(sender, ListBox).SelectedIndex)
   End Sub
End Class
