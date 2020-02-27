' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.ComponentModel

Public Class DocumentPagesControl

   Private _totalPages As Integer

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property TotalPages() As Integer
      Get
         Return _totalPages
      End Get
      Set(ByVal value As Integer)
         _totalPages = value
      End Set
   End Property

   Private _firstPageNumber As Integer

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property FirstPageNumber() As Integer
      Get
         Return _firstPageNumber
      End Get
      Set(ByVal value As Integer)
         _firstPageNumber = value
      End Set
   End Property

   Private _lastPageNumber As Integer

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property LastPageNumber() As Integer
      Get
         Return _lastPageNumber
      End Get
      Set(ByVal value As Integer)
         _lastPageNumber = value
      End Set
   End Property

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData()
      _pagesGroupBox.Text = String.Format("This document contains {0} total &pages.  Select the pages you want to load:", _totalPages)

      If (_firstPageNumber) = 1 AndAlso (_lastPageNumber = -1) Then
         _firstPageNumberTextBox.Text = "1"
         _lastPageNumberTextBox.Text = _totalPages.ToString()
         _loadAllPagesCheckBox.Checked = True
      Else
         _firstPageNumberTextBox.Text = _firstPageNumber.ToString()
         _lastPageNumberTextBox.Text = _lastPageNumber.ToString()
         _loadAllPagesCheckBox.Checked = False
      End If
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData() As Boolean
      Dim ret As Boolean = True

      If _loadAllPagesCheckBox.Checked Then
         _firstPageNumber = 1
         _lastPageNumber = -1
      Else
         Dim firstPageNumber As Integer
         ret = GetPageNumber(_firstPageNumberTextBox, "First page number", 1, _totalPages, firstPageNumber)

         If (ret) Then
            Dim lastPageNumber As Integer
            ret = GetPageNumber(_lastPageNumberTextBox, "Last page number", firstPageNumber, _totalPages, lastPageNumber)
            If (ret) Then
               _firstPageNumber = FirstPageNumber
               _lastPageNumber = lastPageNumber
            End If
         End If
      End If

      Return ret
   End Function

   Private Sub _loadAllPagesCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _loadAllPagesCheckBox.CheckedChanged
      If _loadAllPagesCheckBox.Checked Then
         _firstPageNumberTextBox.Text = "1"
         _lastPageNumberTextBox.Text = _totalPages.ToString()

         _firstPageNumberTextBox.Enabled = False
         _lastPageNumberTextBox.Enabled = False
      Else
         If _lastPageNumber = -1 Then
            _lastPageNumber = _totalPages
         End If

         _firstPageNumberTextBox.Text = _firstPageNumber.ToString()
         _lastPageNumberTextBox.Text = _lastPageNumber.ToString()

         _firstPageNumberTextBox.Enabled = True
         _lastPageNumberTextBox.Enabled = True
      End If
   End Sub

   Private Function GetPageNumber(ByVal pageNumberTextBox As TextBox, ByVal name As String, ByVal minimumNumber As Integer, ByVal maximumNumber As Integer, ByRef pageNumber As Integer)
      If Not Integer.TryParse(pageNumberTextBox.Text, pageNumber) Then
         Messager.ShowError( _
            Me, _
            String.Format("{0} must be an integer between {1} and {2}", name, minimumNumber, maximumNumber))
         pageNumberTextBox.Focus()
         Return False
      End If

      If (pageNumber < minimumNumber) OrElse (pageNumber > maximumNumber) Then
         Messager.ShowError( _
            Me, _
            String.Format("{0} must be an integer between {1} and {2}", name, minimumNumber, maximumNumber))
         pageNumberTextBox.Focus()
         Return False
      End If

      Return True
   End Function
End Class
