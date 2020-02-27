' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections

Imports Leadtools.Dicom

Namespace Leadtools.DicomDemos

   Public Interface IDicomDataSetCollection

      ReadOnly Property Count() As Integer

      ReadOnly Property IsSynchronized() As Boolean

      ReadOnly Property SyncRoot() As Object

      Sub CopyTo(ByVal array As DicomDataSet(), ByVal arrayIndex As Integer)

   End Interface

   Public Interface IDicomDataSetList : Inherits IDicomDataSetCollection

      ReadOnly Property IsFixedSize() As Boolean

      ReadOnly Property IsReadOnly() As Boolean

      Default Property Item(ByVal index As Integer) As DicomDataSet

      Function Add(ByVal value As DicomDataSet) As Integer

      Sub Clear()

      Function Contains(ByVal value As DicomDataSet) As Boolean

      Function IndexOf(ByVal value As DicomDataSet) As Integer

      Sub Insert(ByVal index As Integer, ByVal value As DicomDataSet)

      Sub Remove(ByVal value As DicomDataSet)

      Sub RemoveAt(ByVal index As Integer)

   End Interface

   <Serializable()> _
   Public Class DicomDataSetCollection : Inherits CollectionBase : Implements ICloneable, IDicomDataSetList

#Region "Public Constructors"

      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(ByVal capacity As Integer)
         MyBase.New()
         Me.Capacity = capacity
      End Sub

      Public Sub New(ByVal array As DicomDataSet())
         MyBase.New()
         InnerList.AddRange(array)
      End Sub

      Public Sub New(ByVal value As DicomDataSetCollection)
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

      Public Overridable Shadows ReadOnly Property Count() As Integer Implements IDicomDataSetList.Count
         Get
            Return MyBase.Count()
         End Get
      End Property

      Public Overridable ReadOnly Property IsFixedSize() As Boolean Implements IDicomDataSetList.IsFixedSize
         Get
            Return List.IsFixedSize
         End Get
      End Property

      Public Overridable ReadOnly Property IsReadOnly() As Boolean Implements IDicomDataSetList.IsReadOnly
         Get
            Return List.IsReadOnly
         End Get
      End Property

      Public Overridable ReadOnly Property IsSynchronized() As Boolean Implements IDicomDataSetList.IsSynchronized
         Get
            Return InnerList.IsSynchronized
         End Get
      End Property

      Default Public Overridable Property Item(ByVal index As Integer) As DicomDataSet Implements IDicomDataSetList.Item
         Get
            Return CType(List(index), DicomDataSet)
         End Get
         Set(ByVal Value As DicomDataSet)
            List(index) = Value
         End Set
      End Property

      Public Overridable ReadOnly Property SyncRoot() As Object Implements IDicomDataSetList.SyncRoot
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

      Public Overridable Function Add(ByVal value As DicomDataSet) As Integer Implements IDicomDataSetList.Add
         Return List.Add(value)
      End Function

      Public Overridable Sub AddRange(ByVal Collection As DicomDataSetCollection)
         InnerList.AddRange(Collection)
      End Sub

      Public Overridable Sub AddRange(ByVal array As DicomDataSet())
         InnerList.AddRange(array)
      End Sub

      Public Overridable Function BinarySearch(ByVal value As DicomDataSet) As Integer
         Return InnerList.BinarySearch(value)
      End Function

      Public Overridable Shadows Sub Clear() Implements IDicomDataSetList.Clear
         MyBase.Clear()
      End Sub

      Public Overridable Function Clone() As Object Implements ICloneable.Clone
         Return InnerList.Clone()
      End Function

      Public Function Contains(ByVal value As DicomDataSet) As Boolean Implements IDicomDataSetList.Contains
         Return List.Contains(value)
      End Function

      Public Overridable Sub CopyTo(ByVal array As DicomDataSet())
         InnerList.CopyTo(array)
      End Sub

      Public Overridable Sub CopyTo(ByVal array As DicomDataSet(), ByVal arrayIndex As Integer) Implements IDicomDataSetList.CopyTo
         List.CopyTo(array, arrayIndex)
      End Sub

      Public Overridable Function IndexOf(ByVal value As DicomDataSet) As Integer Implements IDicomDataSetList.IndexOf
         Return List.IndexOf(value)
      End Function

      Public Overridable Sub Insert(ByVal index As Integer, ByVal value As DicomDataSet) Implements IDicomDataSetList.Insert
         List.Insert(index, value)
      End Sub

      Public Shared Function [ReadOnly](ByVal collection As DicomDataSetCollection) As DicomDataSetCollection
         Return CType(ArrayList.ReadOnly(collection), DicomDataSetCollection)
      End Function

      Public Overridable Sub Remove(ByVal value As DicomDataSet) Implements IDicomDataSetList.Remove
         List.Remove(value)
      End Sub

      Public Overridable Shadows Sub RemoveAt(ByVal index As Integer) Implements IDicomDataSetList.RemoveAt
         MyBase.RemoveAt(index)
      End Sub

      Public Overridable Sub RemoveRange(ByVal index As Integer, ByVal count As Integer)
         InnerList.RemoveRange(index, count)
      End Sub

      Public Shadows Function GetEnumerator() As IEnumerator
         Return MyBase.GetEnumerator()
      End Function

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

      Public Shared Function Synchronized(ByVal collection As DicomDataSetCollection) As DicomDataSetCollection
         ArrayList.Synchronized(collection)
         Return collection
      End Function

      Public Overridable Function ToArray() As DicomDataSet()
         Return CType(InnerList.ToArray(), DicomDataSet())
      End Function

      Public Overridable Sub TrimToSize()
         Capacity = Count
      End Sub

      Public Shared Function Unique(ByVal collection As DicomDataSetCollection) As DicomDataSetCollection
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

      Private NotInheritable Class UniqueList : Inherits DicomDataSetCollection

         Public Sub New(ByVal Collection As DicomDataSetCollection)
            Me.AddRange(Collection)
         End Sub

         Public Overrides Function Add(ByVal value As DicomDataSet) As Integer
            CheckUnique(value)
                Return MyBase.Add(value)
            End Function

         Public Overloads Overrides Sub AddRange(ByVal Collection As DicomDataSetCollection)
            For Each value As DicomDataSet In Collection
               CheckUnique(value)
            Next

            MyBase.AddRange(Collection)
         End Sub

         Public Overloads Overrides Sub AddRange(ByVal array As DicomDataSet())
            For Each value As DicomDataSet In array
               CheckUnique(value)
            Next

            MyBase.AddRange(array)
         End Sub

         Public Overrides Sub Insert(ByVal index As Integer, ByVal value As DicomDataSet)
            CheckUnique(value)
            MyBase.Insert(index, value)
         End Sub


         Default Public Overrides Property Item(ByVal index As Integer) As DicomDataSet
            Get
               Return Me.Item(index)
            End Get

            Set(ByVal Value As DicomDataSet)
               CheckUnique(index, Value)
               Me(index) = Value
            End Set
         End Property

         Public Overrides ReadOnly Property IsUnique() As Boolean
            Get
               Return True
            End Get
         End Property

         Private Sub CheckUnique(ByVal value As DicomDataSet)

            If IndexOf(value) >= 0 Then
               Throw New NotSupportedException("Unique collections cannot contain duplicate elements.")
            End If

         End Sub

         Private Sub CheckUnique(ByVal index As Integer, ByVal value As DicomDataSet)

            Dim existing As Integer = IndexOf(value)

            If existing >= 0 AndAlso existing <> index Then
               Throw New NotSupportedException("Unique collections cannot contain duplicate elements.")
            End If
         End Sub

      End Class

#End Region

   End Class

End Namespace
