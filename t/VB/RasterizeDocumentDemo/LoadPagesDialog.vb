' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.ComponentModel

Public Class LoadPagesDialog
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

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If Not DesignMode Then
         _documentPagesControl.TotalPages = _totalPages
         _documentPagesControl.FirstPageNumber = _firstPageNumber
         _documentPagesControl.LastPageNumber = _lastPageNumber
         _documentPagesControl.SetData()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      If _documentPagesControl.GetData() Then
         _totalPages = _documentPagesControl.TotalPages
         _firstPageNumber = _documentPagesControl.FirstPageNumber
         _lastPageNumber = _documentPagesControl.LastPageNumber
      Else
         DialogResult = DialogResult.None
      End If
   End Sub
End Class
