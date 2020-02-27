' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System

''' <summary>
''' Summary description for PdfAdvancedOptions.
''' </summary>
Friend Class PdfStandardOptions
   Private _added As Boolean
   Private _NOMRC As Boolean
   Private _BKThreshold As Integer
   Private _cleanSize As Integer
   Private _CLRThreshold As Integer
   Private _combThreshold As Integer
   Private _segQuality As Integer
   Private _inputImageComboSel As Integer
   Private _outputImageComboSel As Integer
   Private _pageNumber As Integer

   Public Sub New()
      _added = False
      _NOMRC = False
      _BKThreshold = 0
      _cleanSize = 0
      _CLRThreshold = 0
      _combThreshold = 0
      _segQuality = 0
      _inputImageComboSel = 0
      _outputImageComboSel = 0
      _pageNumber = 0

   End Sub
   Public Property Added() As Boolean
      Get
         Return _added
      End Get
      Set(value As Boolean)
         _added = value
      End Set
   End Property

   Public Property NOMRC() As Boolean
      Get
         Return _NOMRC
      End Get
      Set(value As Boolean)
         _NOMRC = value
      End Set
   End Property


   Public Property BKThreshold() As Integer
      Get
         Return _BKThreshold
      End Get
      Set(value As Integer)
         _BKThreshold = value
      End Set
   End Property

   Public Property CleanSize() As Integer
      Get
         Return _cleanSize
      End Get
      Set(value As Integer)
         _cleanSize = value
      End Set
   End Property

   Public Property CLRThreshold() As Integer
      Get
         Return _CLRThreshold
      End Get
      Set(value As Integer)
         _CLRThreshold = value
      End Set
   End Property

   Public Property CombThreshold() As Integer
      Get
         Return _combThreshold
      End Get
      Set(value As Integer)
         _combThreshold = value
      End Set
   End Property

   Public Property SegQuality() As Integer
      Get
         Return _segQuality
      End Get
      Set(value As Integer)
         _segQuality = value
      End Set
   End Property

   Public Property InputImageComboSel() As Integer
      Get
         Return _inputImageComboSel
      End Get
      Set(value As Integer)
         _inputImageComboSel = value
      End Set
   End Property

   Public Property OutputImageComboSel() As Integer
      Get
         Return _outputImageComboSel
      End Get
      Set(value As Integer)
         _outputImageComboSel = value
      End Set
   End Property

   Public Property PageNumber() As Integer
      Get
         Return _pageNumber
      End Get
      Set(value As Integer)
         _pageNumber = value
      End Set
   End Property

End Class

