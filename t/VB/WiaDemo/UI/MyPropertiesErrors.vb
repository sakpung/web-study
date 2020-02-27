' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Friend Structure MyPropertiesErrors
   Private _deviceName As String
   Private _itemName As String
   Private _propertyName As String
   Private _propertyValue As String
   Private _errorCodeString As String

   Public Shared ReadOnly Property Empty() As MyPropertiesErrors
      Get
         Return New MyPropertiesErrors(0)
      End Get
   End Property

   Public Sub New(ByVal dummy As Integer)
      _deviceName = String.Empty
      _itemName = String.Empty
      _propertyName = String.Empty
      _propertyValue = String.Empty
      _errorCodeString = String.Empty
   End Sub

   Public Property DeviceName() As String
      Get
         Return _deviceName
      End Get
      Set(ByVal value As String)
         _deviceName = Value
      End Set
   End Property

   Public Property ItemName() As String
      Get
         Return _itemName
      End Get
      Set(ByVal value As String)
         _itemName = Value
      End Set
   End Property

   Public Property PropertyName() As String
      Get
         Return _propertyName
      End Get
      Set(ByVal value As String)
         _propertyName = Value
      End Set
   End Property

   Public Property PropertyValue() As String
      Get
         Return _propertyValue
      End Get
      Set(ByVal value As String)
         _propertyValue = Value
      End Set
   End Property

   Public Property ErrorCodeString() As String
      Get
         Return _errorCodeString
      End Get
      Set(ByVal value As String)
         _errorCodeString = Value
      End Set
   End Property
End Structure
