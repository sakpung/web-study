' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System

''' <summary>
''' Summary description for PdfAdvancedOptions.
''' </summary>
Friend Class PdfAdvancedOptions
   ' Advance Setting
   Private _oneBitComboSel As Integer
   Private _twoBitComboSel As Integer
   Private _pictComboSel As Integer
   Private _qFactor As Integer
   Private _segmentationComboSel As Integer
   Private _checkBackground As Boolean

   Public Sub New()
      _oneBitComboSel = 5
      _twoBitComboSel = 0
      _pictComboSel = 2
      _qFactor = 50
      _segmentationComboSel = 1
      _checkBackground = False
   End Sub
   ' Advance Setting

   Public Property OneBitComboSel() As Integer
      Get
         Return _oneBitComboSel
      End Get
      Set(value As Integer)
         _oneBitComboSel = value
      End Set
   End Property

   Public Property TwoBitComboSel() As Integer
      Get
         Return _twoBitComboSel
      End Get
      Set(value As Integer)
         _twoBitComboSel = value
      End Set
   End Property


   Public Property PictComboSel() As Integer
      Get
         Return _pictComboSel
      End Get
      Set(value As Integer)
         _pictComboSel = value
      End Set
   End Property


   Public Property QFactor() As Integer
      Get
         Return _qFactor
      End Get
      Set(value As Integer)
         _qFactor = value
      End Set
   End Property

   Public Property SegmentationComboSel() As Integer
      Get
         Return _segmentationComboSel
      End Get
      Set(value As Integer)
         _segmentationComboSel = value
      End Set
   End Property


   Public Property CheckBackground() As Boolean
      Get
         Return _checkBackground
      End Get
      Set(value As Boolean)
         _checkBackground = value
      End Set
   End Property
End Class
