' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Windows.Forms

Imports Leadtools.Document.Viewer
Imports System

' Binds document viewer command to control
Class CommandBinderItem

   Private _tag As Object
   Private _canRun As BinderCanRun
   Private _canRunValue As Object
   Private _getValueCB As GetValueCallback
   Private _autoRun As Boolean
   Private _hasDocumentVisible As Boolean
   Private _updateChecked As Boolean
   Private _updateVisible As Boolean
   Private _updateEnabled As Boolean
   Private _toolStripItem As ToolStripItem
   Private _commandNames As String()
   Private _commandName As String

   Public Sub New()
      Me.UpdateEnabled = True
      Me.HasDocumentVisible = True
      Me.HasDocumentEmptyEnabled = True
      Me.AutoRun = True
   End Sub

   Public Property HasDocumentEmptyEnabled() As Boolean
      Get
         Return m_HasDocumentEmptyEnabled
      End Get
      Set(value As Boolean)
         m_HasDocumentEmptyEnabled = Value
      End Set
   End Property
   Private m_HasDocumentEmptyEnabled As Boolean

   'Public Sub New()
   '   _tag = Nothing
   '   _canRun = Nothing
   '   _canRunValue = Nothing
   '   _getValueCB = Nothing
   '   _autoRun = True
   '   _hasDocumentVisible = True
   '   _updateChecked = False
   '   _updateVisible = False
   '   _updateEnabled = True
   '   _toolStripItem = Nothing
   '   _commandNames = Nothing
   '   _commandName = Nothing

   '   'Me._updateEnabled = True
   '   'Me.HasDocumentVisible = True
   '   'Me.AutoRun = True
   'End Sub

   Public Property CommandName() As String
      Get
         Return _commandName
      End Get
      Set(value As String)
         _commandName = value
      End Set
   End Property

   Public Property CommandNames() As String()
      Get
         Return _commandNames
      End Get
      Set(value As String())
         _commandNames = value
      End Set
   End Property

   Public Property ToolStripItem() As ToolStripItem
      Get
         Return _toolStripItem
      End Get
      Set(value As ToolStripItem)
         _toolStripItem = value
      End Set
   End Property

   Public Property UpdateEnabled() As Boolean
      Get
         Return _updateEnabled
      End Get
      Set(value As Boolean)
         _updateEnabled = value
      End Set
   End Property

   Public Property UpdateVisible() As Boolean
      Get
         Return _updateVisible
      End Get
      Set(value As Boolean)
         _updateVisible = value
      End Set
   End Property

   Public Property UpdateChecked() As Boolean
      Get
         Return _updateChecked
      End Get
      Set(value As Boolean)
         _updateChecked = value
      End Set
   End Property

   Public Property HasDocumentVisible() As Boolean
      Get
         Return _hasDocumentVisible
      End Get
      Set(value As Boolean)
         _hasDocumentVisible = value
      End Set
   End Property

   Public Property AutoRun() As Boolean
      Get
         Return _autoRun
      End Get
      Set(value As Boolean)
         _autoRun = value
      End Set
   End Property

   Public Delegate Function GetValueCallback() As Object
   Public Property GetValue() As GetValueCallback
      Get
         Return _getValueCB
      End Get
      Set(value As GetValueCallback)
         _getValueCB = value
      End Set
   End Property

   Public Property Tag() As Object
      Get
         Return _tag
      End Get
      Set(value As Object)
         _tag = value
      End Set
   End Property

   Public Delegate Function BinderCanRun(documentViewer As DocumentViewer, value As Object) As Boolean

   Public Property CanRun() As BinderCanRun
      Get
         Return _canRun
      End Get
      Set(value As BinderCanRun)
         _canRun = value
      End Set
   End Property

   Public Property CanRunValue() As Object
      Get
         Return _canRunValue
      End Get
      Set(value As Object)
         _canRunValue = value
      End Set
   End Property



   Public Sub RunCommand(documentViewer As DocumentViewer)
      If Me.CommandName IsNot Nothing Then
         documentViewer.Commands.Run(Me.CommandName, If(GetValue IsNot Nothing, GetValue.Invoke(), Nothing))
      ElseIf Me.CommandNames IsNot Nothing Then
         For Each commandName As String In Me.CommandNames
            documentViewer.Commands.Run(commandName, If(GetValue IsNot Nothing, GetValue.Invoke(), Nothing))
         Next
      End If
   End Sub

   Public Function CanRunCommand(documentViewer As DocumentViewer) As Boolean
      If Me.CommandName IsNot Nothing Then
         Return documentViewer.Commands.CanRun(Me.CommandName, If(GetValue IsNot Nothing, GetValue.Invoke(), Nothing))
      End If

      For Each commandName As String In Me.CommandNames
         If documentViewer.Commands.CanRun(commandName, If(GetValue IsNot Nothing, GetValue.Invoke(), Nothing)) Then
            Return True
         End If
      Next

      Return False
   End Function

   Public ReadOnly Property HasAnyCommand() As Boolean
      Get
         Return Me.CommandName IsNot Nothing OrElse Me.CommandNames IsNot Nothing
      End Get
   End Property
End Class

Class CommandsBinder
   Public Sub New(documentViewer As DocumentViewer)
      _documentViewer = documentViewer
   End Sub

   Private _documentViewer As DocumentViewer

   Private _items As New List(Of CommandBinderItem)()
   Public ReadOnly Property Items() As IList(Of CommandBinderItem)
      Get
         Return _items
      End Get
   End Property

   Private _postRuns As New List(Of Action)()
   Public ReadOnly Property PostRuns() As List(Of Action)
      Get
         Return _postRuns
      End Get
   End Property

   Public Sub BindActions(bind As Boolean)
      For Each item As CommandBinderItem In _items
         If bind Then
            If item.AutoRun AndAlso item.HasAnyCommand Then
               item.ToolStripItem.Tag = item
               AddHandler item.ToolStripItem.Click, AddressOf ItemClick
            Else
               item.ToolStripItem.Tag = Nothing
               RemoveHandler item.ToolStripItem.Click, AddressOf ItemClick
            End If
         End If
      Next
   End Sub

   Private Sub ItemClick(sender As Object, e As EventArgs)
      Dim toolStripItem As ToolStripItem = TryCast(sender, ToolStripItem)
      Dim item As CommandBinderItem = TryCast(toolStripItem.Tag, CommandBinderItem)
      item.RunCommand(_documentViewer)
   End Sub

   Public Sub Run()
      Dim hasDocument As Boolean = _documentViewer.HasDocument
      Dim isDocumentEmpty As Boolean

      If _documentViewer.PageCount = 0 Then
         isDocumentEmpty = True
      Else
         isDocumentEmpty = False
      End If

      For Each item As CommandBinderItem In _items
         Dim toolStripItem As ToolStripItem = item.ToolStripItem

         Dim canRun As Boolean = False

         If item.CanRun IsNot Nothing Then
            canRun = item.CanRun(_documentViewer, item.CanRunValue)
         ElseIf item.HasDocumentVisible Then
            canRun = hasDocument
            If toolStripItem.Available <> canRun Then
               toolStripItem.Available = canRun
            End If
         End If

         If canRun AndAlso item.HasAnyCommand Then
            canRun = item.CanRunCommand(_documentViewer)
         End If

         Dim updateCheckedState As Boolean = item.UpdateChecked
         Dim command As DocumentViewerCommand = Nothing
         If item.CommandName IsNot Nothing Then
            ' This might be a state command, check
            command = _documentViewer.Commands.GetCommand(item.CommandName)
         End If

         If Not updateCheckedState Then
            updateCheckedState = command IsNot Nothing AndAlso command.HasState
         End If

         If Not updateCheckedState Then
            If canRun AndAlso Not item.HasDocumentEmptyEnabled AndAlso isDocumentEmpty Then
               canRun = False
            End If
            If item.UpdateEnabled AndAlso toolStripItem.Enabled <> canRun Then
               toolStripItem.Enabled = canRun
            End If
         Else
            Dim checkedState As Boolean = False
            If command IsNot Nothing AndAlso command.HasState Then
               checkedState = command.State
            Else
               checkedState = Not canRun
            End If

            UpdateProperty(toolStripItem, "Checked", checkedState)
         End If

         If item.UpdateVisible AndAlso toolStripItem.Available <> canRun Then
            toolStripItem.Available = canRun
         End If
      Next

      For Each postRun As Action In _postRuns
         postRun()
      Next
   End Sub

   Private Shared Sub UpdateProperty(target As Object, propertyName As String, value As Boolean)
      Dim prop As System.Reflection.PropertyInfo = target.GetType().GetProperty(propertyName)
      If value <> CBool(prop.GetValue(target, Nothing)) Then
         prop.SetValue(target, value, Nothing)
      End If
   End Sub
End Class
