' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Partial Public Class RegionForm : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Property UseIncludeRegions() As Boolean
      Get
         Return _chkIncludeRegions.Checked
      End Get
      Set(value As Boolean)
         _chkIncludeRegions.Checked = value
      End Set
   End Property

   Public Property UseExcludeRegions() As Boolean
      Get
         Return _chkExcludeRegions.Checked
      End Get
      Set(value As Boolean)
         _chkExcludeRegions.Checked = value
      End Set
   End Property

   Public Property UseInterestRegions() As Boolean
      Get
         Return _chkRegionsOfInterest.Checked
      End Get
      Set(value As Boolean)
         _chkRegionsOfInterest.Checked = value
      End Set
   End Property

   Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
      If (Not _chkExcludeRegions.Checked) AndAlso (Not _chkIncludeRegions.Checked) AndAlso (Not _chkRegionsOfInterest.Checked) Then
         MessageBox.Show("You must select at least one option", "Error")
         Return
      End If

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub
End Class
