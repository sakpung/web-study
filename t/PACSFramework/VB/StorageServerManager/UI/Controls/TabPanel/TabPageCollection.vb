' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Public Class TabPageCollection
      Private _controls As List(Of PageData)
      Public Sub New()
         _controls = New List(Of PageData)()
      End Sub

      <Browsable(False)> _
      Public ReadOnly Property Count() As Integer
         Get
            Return _controls.Count
         End Get
      End Property

      Public ReadOnly Property IsReadOnly() As Boolean
         Get
            Return False
         End Get
      End Property

      Default Public Overridable Property Item(ByVal index As Integer) As PageData
         Get
            If index < 0 OrElse index >= _controls.Count Then
               Throw New IndexOutOfRangeException()
            End If

            Return _controls(index)
         End Get

         Set(ByVal value As PageData)
            If index < 0 OrElse index >= _controls.Count Then
               Throw New IndexOutOfRangeException()
            End If

            If Not _controls(index) Is value Then
               Dim oldPage As PageData = _controls(index)

               _controls(index) = value

               OnPageRemoved(oldPage)
               OnPageAdded(value)
            End If
         End Set
      End Property

      Public Overridable Sub Add(ByVal value As PageData)
         _controls.Add(value)

         OnPageAdded(value)
      End Sub

      Public Overridable Sub Remove(ByVal value As PageData)
         _controls.Remove(value)

         OnPageRemoved(value)
      End Sub

      Public Overridable Sub Clear()
         For Each control As PageData In _controls.ToArray()
            Remove(control)
         Next control
      End Sub

      Public Function Contains(ByVal page As PageData) As Boolean
         Return _controls.Contains(page)
      End Function

      Public Function GetEnumerator() As IEnumerator
         Return _controls.GetEnumerator()
      End Function

      Public Function IndexOf(ByVal page As PageData) As Integer
         Return _controls.IndexOf(page)
      End Function

      Friend Event PageAdded As EventHandler(Of DataEventArgs(Of PageData))
      Friend Event PageRemoved As EventHandler(Of DataEventArgs(Of PageData))

      Private Sub OnPageAdded(ByVal tabPage As PageData)
         If Not Nothing Is PageAddedEvent Then
            RaiseEvent PageAdded(Me, New DataEventArgs(Of PageData)(tabPage))
         End If
      End Sub

      Private Sub OnPageRemoved(ByVal tabPage As PageData)
         If Not Nothing Is PageRemovedEvent Then
            RaiseEvent PageRemoved(Me, New DataEventArgs(Of PageData)(tabPage))
         End If
      End Sub
   End Class
End Namespace
