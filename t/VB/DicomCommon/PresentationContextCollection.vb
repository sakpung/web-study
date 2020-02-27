' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections


Namespace Leadtools.DicomDemos

   Public Interface IPresentationContextCollection

      ReadOnly Property Count() As Integer

      ReadOnly Property IsSynchronized() As Boolean

      ReadOnly Property SyncRoot() As Object

      Sub CopyTo(ByVal array As PresentationContext(), ByVal arrayIndex As Integer)

   End Interface

   Public Interface IPresentationContextList : Inherits IPresentationContextCollection

      ReadOnly Property IsFixedSize() As Boolean

      ReadOnly Property IsReadOnly() As Boolean

      Default Property Item(ByVal index As Integer) As PresentationContext

      Function Add(ByVal value As PresentationContext) As Integer

      Sub Clear()

      Function Contains(ByVal value As PresentationContext) As Boolean

      Function IndexOf(ByVal value As PresentationContext) As Integer

      Sub Insert(ByVal index As Integer, ByVal value As PresentationContext)

      Sub Remove(ByVal value As PresentationContext)

      Sub RemoveAt(ByVal index As Integer)

   End Interface

   <Serializable()> _
   Public Class PresentationContextCollection : Inherits CollectionBase : Implements ICloneable, IPresentationContextList

#Region "Public Constructors"

      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(ByVal capacity As Integer)
         MyBase.New()
         Me.Capacity = capacity
      End Sub

      Public Sub New(ByVal array As PresentationContext())
         MyBase.New()

         InnerList.AddRange(array)
      End Sub

      Public Sub New(ByVal value As PresentationContextCollection)
         MyBase.New()

         InnerList.AddRange(value)
      End Sub

#End Region

#Region "Public Properties"

      Public Overloads Property Capacity() As Integer
         Get
            Return InnerList.Capacity
         End Get
         Set(ByVal Value As Integer)
            InnerList.Capacity = Value
         End Set
      End Property

      Public Overridable Shadows ReadOnly Property Count() As Integer Implements IPresentationContextList.Count
         Get
            Return MyBase.Count()
         End Get
      End Property

      Public Overridable ReadOnly Property IsFixedSize() As Boolean Implements IPresentationContextList.IsFixedSize
         Get
            Return List.IsFixedSize
         End Get
      End Property

      Public Overridable ReadOnly Property IsReadOnly() As Boolean Implements IPresentationContextList.IsReadOnly
         Get
            Return List.IsReadOnly
         End Get
      End Property

      Public Overridable ReadOnly Property IsSynchronized() As Boolean Implements IPresentationContextList.IsSynchronized
         Get
            Return List.IsSynchronized
         End Get
      End Property

      Default Public Overridable Property Item(ByVal index As Integer) As PresentationContext Implements IPresentationContextList.Item
         Get
            Return CType(List(index), PresentationContext)
         End Get
         Set(ByVal Value As PresentationContext)
            List(index) = Value
         End Set
      End Property

      Public Overridable ReadOnly Property SyncRoot() As Object Implements IPresentationContextList.SyncRoot
         Get
            Return List.SyncRoot
         End Get
      End Property

      Public Overridable ReadOnly Property IsUnique() As Boolean
         Get
            Return False
         End Get
      End Property

#End Region

#Region "Public Methods"

      Public Overridable Function Add(ByVal value As PresentationContext) As Integer Implements IPresentationContextList.Add
         Return List.Add(value)
      End Function

      Public Overridable Sub AddRange(ByVal Collection As PresentationContextCollection)
         InnerList.AddRange(Collection)
      End Sub

      Public Overridable Sub AddRange(ByVal array As PresentationContext())
         InnerList.AddRange(array)
      End Sub

      Public Overridable Function BinarySearch(ByVal value As PresentationContext) As Integer
         Return InnerList.BinarySearch(value)
      End Function

      Public Overridable Shadows Sub Clear() Implements IPresentationContextList.Clear
         MyBase.Clear()
      End Sub

      Public Overridable Function Clone() As Object Implements ICloneable.Clone
         Return InnerList.Clone()
      End Function

      Public Function Contains(ByVal value As PresentationContext) As Boolean Implements IPresentationContextList.Contains
         Return List.Contains(value)
      End Function

      Public Overridable Sub CopyTo(ByVal array As PresentationContext())
         InnerList.CopyTo(array)
      End Sub

      Public Overridable Sub CopyTo(ByVal array As PresentationContext(), ByVal arrayIndex As Integer) Implements IPresentationContextList.CopyTo
         List.CopyTo(array, arrayIndex)
      End Sub

      Public Overridable Function IndexOf(ByVal value As PresentationContext) As Integer Implements IPresentationContextList.IndexOf
         Return List.IndexOf(value)
      End Function

      Public Overridable Sub Insert(ByVal index As Integer, ByVal value As PresentationContext) Implements IPresentationContextList.Insert
         List.Insert(index, value)
      End Sub

      Public Shared Function [ReadOnly](ByVal collection As PresentationContextCollection) As PresentationContextCollection
         Return CType(ArrayList.ReadOnly(collection), PresentationContextCollection)
      End Function

      Public Overridable Sub Remove(ByVal value As PresentationContext) Implements IPresentationContextList.Remove
         List.Remove(value)
      End Sub

      Public Overridable Shadows Sub RemoveAt(ByVal index As Integer) Implements IPresentationContextList.RemoveAt
         MyBase.RemoveAt(index)
      End Sub

      Public Overridable Sub RemoveRange(ByVal index As Integer, ByVal count As Integer)
         InnerList.RemoveRange(index, count)
      End Sub

      Public Overridable Sub Reverse()
         InnerList.Reverse()
      End Sub

      Public Overridable Sub Reverse(ByVal index As Integer, ByVal count As Integer)
         InnerList.Reverse(index, count)
      End Sub

      Public Overridable Sub Sort()
         InnerList.Sort()
      End Sub

      Public Overridable Sub Sort(ByVal comparer As IComparer)
         InnerList.Sort(comparer)
      End Sub

      Public Overridable Sub Sort(ByVal index As Integer, ByVal count As Integer, ByVal comparer As IComparer)
         InnerList.Sort(index, count, comparer)
      End Sub

      Public Shared Function Synchronized(ByVal collection As PresentationContextCollection) As PresentationContextCollection
         Return CType(ArrayList.Synchronized(collection), PresentationContextCollection)
      End Function

      Public Overridable Function ToArray() As PresentationContext()
         Return CType(InnerList.ToArray(), PresentationContext())
      End Function

      Public Overridable Sub TrimToSize()
         Capacity = Count
      End Sub

      Public Shared Function Unique(ByVal collection As PresentationContextCollection) As PresentationContextCollection
         If collection Is Nothing Then
            Throw New ArgumentNullException("collection")
         End If

         For i As Integer = collection.Count - 1 To 1 Step -1
            If collection.IndexOf(collection(i)) < i Then
               Throw New ArgumentException("collection", "Argument cannot contain duplicate elements.")
            End If
         Next i

         Return New UniqueList(collection)
      End Function

#End Region

#Region "Class UniqueList"

      Private NotInheritable Class UniqueList : Inherits PresentationContextCollection

         Public Sub New(ByVal Collection As PresentationContextCollection)
            Me.AddRange(Collection)
         End Sub

         Public Overrides Function Add(ByVal value As PresentationContext) As Integer
            CheckUnique(value)
            Return MyBase.Add(value)
         End Function

         Public Overloads Overrides Sub AddRange(ByVal Collection As PresentationContextCollection)
            For Each value As PresentationContext In Collection
               CheckUnique(value)
            Next

            MyBase.AddRange(Collection)
         End Sub

         Public Overloads Overrides Sub AddRange(ByVal array As PresentationContext())
            For Each value As PresentationContext In array
               CheckUnique(value)
            Next

            MyBase.AddRange(array)
         End Sub

         Public Overrides Sub Insert(ByVal index As Integer, ByVal value As PresentationContext)
            CheckUnique(value)
            MyBase.Insert(index, value)
         End Sub


         Default Public Overrides Property Item(ByVal index As Integer) As PresentationContext
            Get
               Return Me.Item(index)
            End Get

            Set(ByVal Value As PresentationContext)
               CheckUnique(index, Value)
               Me(index) = Value
            End Set
         End Property

         Public Overrides ReadOnly Property IsUnique() As Boolean
            Get
               Return True
            End Get
         End Property

         Private Sub CheckUnique(ByVal value As PresentationContext)

            If IndexOf(value) >= 0 Then
               Throw New NotSupportedException("Unique collections cannot contain duplicate elements.")
            End If

         End Sub

         Private Sub CheckUnique(ByVal index As Integer, ByVal value As PresentationContext)

            Dim existing As Integer = IndexOf(value)

            If existing >= 0 AndAlso existing <> index Then
               Throw New NotSupportedException("Unique collections cannot contain duplicate elements.")
            End If
         End Sub

      End Class

#End Region

   End Class

End Namespace
