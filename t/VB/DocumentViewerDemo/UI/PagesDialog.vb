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

Partial Public Class PagesDialog : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Operation As String
   Public PageCount As Integer
   Public FirstPageNumber As Integer
   Public LastPageNumber As Integer
   Public ShowCurrentPageNumber As Boolean = True
   Public SinglePageMode As Boolean = True

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         Me.Text = Me.Operation
         _operationLabel.Text = _operationLabel.Text.Replace("###", Me.Operation.ToLowerInvariant())
         If PageCount <> -1 Then
            _pagesLabel.Text = _pagesLabel.Text.Replace("###", Me.PageCount.ToString())
            _lastPageCheckBox.Visible = False
            _firstPageNumberNumericUpDown.Maximum = Me.PageCount

            If Me.SinglePageMode Then
               _firstPageNumberLabel.Text = "&Page number:"
               _lastPageNumberLabel.Visible = False
               _lastPageNumberNumericUpDown.Visible = False
               _lastPageNumberNumericUpDown.Enabled = False
            Else
               _lastPageNumberNumericUpDown.Maximum = Me.PageCount
            End If

            Me.FirstPageNumber = Math.Max(1, Math.Min(Me.PageCount, Me.FirstPageNumber))

            If Me.SinglePageMode Then
               Me.LastPageNumber = Me.FirstPageNumber
            Else
               Me.LastPageNumber = Math.Max(1, Math.Min(Me.PageCount, Me.LastPageNumber))
               If Me.LastPageNumber < Me.FirstPageNumber Then
                  Me.LastPageNumber = Me.FirstPageNumber
               End If
            End If

            If Me.ShowCurrentPageNumber Then
               _currentPageNumberLabel.Text = _currentPageNumberLabel.Text.Replace("###", Me.FirstPageNumber.ToString())
            Else
               _currentPageNumberLabel.Visible = False
            End If

            _firstPageNumberNumericUpDown.Value = Me.FirstPageNumber

            If (Not Me.SinglePageMode) Then
               _lastPageNumberNumericUpDown.Value = Me.LastPageNumber
               _allPagesCheckBox.Checked = (Me.FirstPageNumber = 1 AndAlso Me.LastPageNumber = Me.PageCount)
            End If
         Else
            _pagesLabel.Visible = False
            _lastPageCheckBox.Visible = True
            _firstPageNumberNumericUpDown.Maximum = Int32.MaxValue
            _currentPageNumberLabel.Visible = False

            _firstPageNumberNumericUpDown.Value = Me.FirstPageNumber




            If Me.LastPageNumber = -1 Then
               _lastPageNumberNumericUpDown.Value = Me.FirstPageNumber
            Else
               _lastPageNumberNumericUpDown.Value = Me.LastPageNumber
            End If

            _lastPageCheckBox.Checked = (Me.LastPageNumber = -1)
            _allPagesCheckBox.Checked = (Me.FirstPageNumber = 1 AndAlso Me.LastPageNumber = -1)


         End If
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _firstPageNumberNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
      Me.FirstPageNumber = CInt(_firstPageNumberNumericUpDown.Value)

      If (Not Me.SinglePageMode) AndAlso Me.PageCount <> -1 Then
         If Me.LastPageNumber < Me.FirstPageNumber Then
            _lastPageNumberNumericUpDown.Value = Me.FirstPageNumber
         End If
      End If
   End Sub

   Private Sub _lastPageNumberNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
      Me.LastPageNumber = CInt(_lastPageNumberNumericUpDown.Value)
      If Me.FirstPageNumber > Me.LastPageNumber Then
         _firstPageNumberNumericUpDown.Value = Me.LastPageNumber
      End If
   End Sub

   Private Sub _allPagesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _firstPageNumberNumericUpDown.Enabled = Not _allPagesCheckBox.Checked

      If (Not Me.SinglePageMode) Then
         _lastPageNumberNumericUpDown.Enabled = Not _allPagesCheckBox.Checked
      Else
         _lastPageNumberNumericUpDown.Enabled = Not _lastPageCheckBox.Checked
      End If

      If _lastPageCheckBox.Visible Then
         _lastPageCheckBox.Enabled = Not _allPagesCheckBox.Checked
         _lastPageNumberNumericUpDown.Enabled = (Not _lastPageCheckBox.Checked) AndAlso Not _allPagesCheckBox.Checked
      End If
   End Sub

   Private Sub _lastPageCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _lastPageNumberNumericUpDown.Enabled = Not _lastPageCheckBox.Checked
      If (Not _lastPageCheckBox.Checked) Then
         Me.LastPageNumber = CInt(_lastPageNumberNumericUpDown.Value)
      End If
   End Sub

   Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      If Me.PageCount <> -1 Then
         If _allPagesCheckBox.Checked Then
            Me.FirstPageNumber = 1
            Me.LastPageNumber = Me.PageCount
         ElseIf Me.SinglePageMode Then
            Me.LastPageNumber = Me.FirstPageNumber
         End If
      Else
         If _allPagesCheckBox.Checked Then
            Me.FirstPageNumber = 1
            Me.LastPageNumber = -1
         ElseIf _lastPageCheckBox.Checked Then
            Me.LastPageNumber = -1
         Else
            If Me.FirstPageNumber > Me.LastPageNumber Then
               Helper.ShowWarning(Me, "First page number must be less than or equal to last page number")
               Me._firstPageNumberNumericUpDown.Focus()
               DialogResult = DialogResult.None
            End If
         End If
      End If
   End Sub
End Class
