' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools.Barcode

' Each page has a list of barcodes and a current selected barcode index
Public Class PageBarcodes
   Public Sub New()
      _barcodes = New List(Of BarcodeData)()
      _selectedIndex = -1
   End Sub

   Private _barcodes As IList(Of BarcodeData)
   Public ReadOnly Property Barcodes() As IList(Of BarcodeData)
      Get
         Return _barcodes
      End Get
   End Property

   Private _selectedIndex As Integer
   Public Property SelectedIndex() As Integer
      Get
         Return _selectedIndex
      End Get
      Set(value As Integer)
         _selectedIndex = value
      End Set
   End Property
End Class

' A document has a list of PageBarcodes
Public Class DocumentBarcodes
   Public Sub New()
      _pages = New List(Of PageBarcodes)()
   End Sub

   Private _pages As IList(Of PageBarcodes)
   Public ReadOnly Property Pages() As IList(Of PageBarcodes)
      Get
         Return _pages
      End Get
   End Property
End Class
