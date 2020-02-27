' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Wia

Friend Structure MyItemData
   Private _itemData As Integer
   Private _itemName As String

   Public Property ItemData() As Integer
      Get
         Return _itemData
      End Get
      Set(ByVal value As Integer)
         _itemData = value
      End Set
   End Property

   Public Property ItemString() As String
      Get
         Return _itemName
      End Get
      Set(ByVal value As String)
         _itemName = value
      End Set
   End Property

   Public Overrides Function ToString() As String
      Return _itemName
   End Function
End Structure

Partial Public Class WiaVersionForm : Inherits Form
   Public _selectedWiaVersion As WiaVersion

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub WiaVersionForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Dim item As MyItemData = New MyItemData()

      item.ItemData = CInt(WiaVersion.Version1)
      item.ItemString = "WIA Version 1.0"
      _lbWiaVersions.Items.Add(item)

      Select Case System.Environment.OSVersion.Version.Major
         Case 5 ' Windows Server 2003 R2, Windows Server 2003, Windows XP, or Windows 2000
            item.ItemData = CInt(WiaVersion.Version2)
            item.ItemString = "WIA Version 2.0 (ONLY supported on Windows VISTA or later)"
            _lbWiaVersions.Items.Add(item)

         Case 6 ' Windows Vista or Windows Server 2008
            item.ItemData = CInt(WiaVersion.Version2)
            item.ItemString = "WIA Version 2.0"
            _lbWiaVersions.Items.Add(item)
      End Select

      _lbWiaVersions.SetSelected(0, True)
   End Sub

   Private Sub _lbWiaVersions_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lbWiaVersions.SelectedIndexChanged
      If _lbWiaVersions.SelectedIndex > 0 AndAlso System.Environment.OSVersion.Version.Major <> 6 Then
         _btnOk.Enabled = False
      Else
         _btnOk.Enabled = True
      End If
   End Sub

   Private Sub _lbWiaVersions_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _lbWiaVersions.DoubleClick
      Dim item As MyItemData = CType(_lbWiaVersions.SelectedItem, MyItemData)
      If item.ItemData = CInt(WiaVersion.Version2) Then
         If System.Environment.OSVersion.Version.Major <> 6 Then
            Return
         End If
      End If
      _selectedWiaVersion = CType(item.ItemData, WiaVersion)
      Me.DialogResult = DialogResult.OK
      Me.Hide()
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
      Dim item As MyItemData = CType(_lbWiaVersions.SelectedItem, MyItemData)
      _selectedWiaVersion = CType(item.ItemData, WiaVersion)
   End Sub
End Class
