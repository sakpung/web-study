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

Partial Public Class ImageFileLoaderPagesDialog : Inherits Form
   Private _pages As Integer
   Private _loadOnlyOnePage As Boolean

   Public FirstPage As Integer
   Public LastPage As Integer

   Public Sub New(ByVal pages As Integer, ByVal loadOnlyOnePage As Boolean)
      InitializeComponent()

      _pages = pages
      _loadOnlyOnePage = loadOnlyOnePage
   End Sub

   Private Sub ImageFileLoaderPagesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
      FirstPage = 1
      LastPage = _pages

      Dim text As String = _lblInfo.Text
      text = text.Replace("###", _pages.ToString())

      If _loadOnlyOnePage Then
         _rbLoadSinglePage.Checked = True
         text = text.Replace("$$$", "page")
      Else
         _rbLoadMultiPages.Checked = True
         text = text.Replace("$$$", "pages")
      End If

      _lblInfo.Text = text
      _tbPageNumber.Text = FirstPage.ToString()
      _tbFirstPage.Text = FirstPage.ToString()
      _tbLastPage.Text = LastPage.ToString()
      UpdateControls()
   End Sub

   Private Sub _rbLoadSinglePage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rbLoadSinglePage.Click, _rbLoadSinglePage.Click
      UpdateControls()
      _tbPageNumber.SelectAll()
      _tbPageNumber.Focus()
   End Sub

   Private Sub _rbLoadMultiPages_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _rbLoadMultiPages.Click, _rbLoadMultiPages.Click
      UpdateControls()
      _tbLastPage.SelectAll()
      _tbLastPage.Focus()
   End Sub

   Private Sub UpdateControls()
      _lblPageNumber.Enabled = _rbLoadSinglePage.Checked
      _tbPageNumber.Enabled = _rbLoadSinglePage.Checked

      _lblFirstPage.Enabled = _rbLoadMultiPages.Checked
      _tbFirstPage.Enabled = _rbLoadMultiPages.Checked
      _lblLastPage.Enabled = _rbLoadMultiPages.Checked
      _tbLastPage.Enabled = _rbLoadMultiPages.Checked
   End Sub

   Private Sub _tb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _tbFirstPage.KeyPress, _tbLastPage.KeyPress, _tbFirstPage.KeyPress, _tbLastPage.KeyPress
      If (Not Char.IsControl(e.KeyChar)) AndAlso (Not Char.IsNumber(e.KeyChar)) Then
         e.Handled = True
      End If
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click, _btnOk.Click
      If _rbLoadSinglePage.Checked Then ' Load single page
         If (Not DialogUtilities.ParseInteger(_tbPageNumber, "Page Number", 1, True, _pages, True, True, FirstPage)) Then
            _tbPageNumber.SelectAll()
            _tbPageNumber.Focus()
            Return
         End If

         LastPage = FirstPage
      Else
         If (Not DialogUtilities.ParseInteger(_tbFirstPage, "First Page", 1, True, _pages, True, True, FirstPage)) Then
            _tbFirstPage.SelectAll()
            _tbFirstPage.Focus()
            Return
         End If

         If (Not DialogUtilities.ParseInteger(_tbLastPage, "Last Page", FirstPage, True, _pages, True, True, LastPage)) Then
            _tbLastPage.SelectAll()
            _tbLastPage.Focus()
            Return
         End If
      End If
   End Sub
End Class
