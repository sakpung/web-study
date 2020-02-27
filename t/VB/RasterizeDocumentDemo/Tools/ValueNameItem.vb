' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
' Used as an item for listbox and combobox controls
Class ValueNameItem(Of T)
   Private _value As T

   ' The item value
   Public Property Value() As T
      Get
         Return _value
      End Get
      Set(ByVal value As T)
         _value = value
      End Set
   End Property

   ' The item name
   Private _name As String

   Public Property Name() As String
      Get
         Return _name
      End Get
      Set(ByVal value As String)
         _name = value
      End Set
   End Property

   Public Sub New(ByVal value As T, ByVal name As String)
      _value = value
      _name = name
   End Sub

   Public Overrides Function ToString() As String
      Return _name
   End Function

   ' Return the selected item from a list
   Public Shared Function SelectItem(ByVal value As T, ByVal items As System.Collections.IEnumerable) As Object
      For Each item As ValueNameItem(Of T) In items
         If item.Value.Equals(value) Then
            Return item
         End If
      Next

      Return Nothing
   End Function

   Public Shared Function GetSelectedItem(ByVal item As Object) As T
      Return CType(item, ValueNameItem(Of T)).Value
   End Function
End Class
