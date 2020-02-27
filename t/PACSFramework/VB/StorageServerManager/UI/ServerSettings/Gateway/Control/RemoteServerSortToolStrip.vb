' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class RemoteServerSortToolStrip : Inherits ToolStrip
      Public Sub New()
         MyBase.New()
         _moveUp.Text = ""
         _moveDown.Text = ""

         Items.AddRange(New ToolStripItem() {_moveDown, _moveUp})

         AddHandler _moveUp.Click, AddressOf _moveUp_Click
         AddHandler _moveDown.Click, AddressOf _moveDown_Click

         _moveUp.Image = My.Resources.up
         _moveDown.Image = My.Resources.down
      End Sub

      Public Event MoveUp As EventHandler
      Public Event MoveDown As EventHandler

      Private Sub _moveUp_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is MoveUpEvent Then
            RaiseEvent MoveUp(Me, e)
         End If
      End Sub

      Private Sub _moveDown_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is MoveDownEvent Then
            RaiseEvent MoveDown(Me, e)
         End If
      End Sub

      Public Property CanMoveUp() As Boolean
         Get
            Return _moveUp.Enabled
         End Get

         Set(ByVal value As Boolean)
            _moveUp.Enabled = Value
         End Set
      End Property

      Public Property CanMoveDown() As Boolean
         Get
            Return _moveDown.Enabled
         End Get

         Set(ByVal value As Boolean)
            _moveDown.Enabled = Value
         End Set
      End Property


      Private _moveUp As ToolStripButton = New ToolStripButton()
      Private _moveDown As ToolStripButton = New ToolStripButton()
   End Class
End Namespace
