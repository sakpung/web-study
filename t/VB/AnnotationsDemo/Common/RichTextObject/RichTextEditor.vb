' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Annotations.Engine
Imports System.Windows.Forms
Imports Leadtools.Annotations.WinForms
Imports System.Drawing
Imports System
Imports Leadtools

Public Class RichTextBoxEditor
   Private _owner As IAnnAutomationControl = Nothing
   Private _targetObject As AnnObject = Nothing
   Private _container As AnnContainer = Nothing

   Private _toolBar As RichTextMenu
   Private _tb As System.Windows.Forms.RichTextBox

   Private _isEditingText As Boolean = False

   Public Property IsEditingText() As Boolean
      Get
         Return _isEditingText
      End Get
      Set(value As Boolean)
         If value <> _isEditingText Then
            _isEditingText = value
            Dim e As New EventArgs()
         End If
      End Set
   End Property
   Public Sub New(owner As IAnnAutomationControl, targetObject As AnnObject, container As AnnContainer)
      _owner = owner
      _targetObject = targetObject
      _container = container
   End Sub

   Public Sub ShowRichTextDialog(richTextObject As AnnRichTextObject)
      If (richTextObject IsNot Nothing) AndAlso Not richTextObject.IsLocked AndAlso Not richTextObject.Bounds.IsEmpty Then
         _tb = New RichTextBox()
         _tb.Multiline = True
         _tb.HideSelection = False

         _tb.Rtf = richTextObject.Rtf

         Dim bounds As LeadRectD = _container.Mapper.RectFromContainerCoordinates(richTextObject.Bounds, richTextObject.FixedStateOperations)
         bounds.Inflate(20, 20)

         _tb.Location = New Point(CInt(bounds.X), CInt(bounds.Y))
         _tb.Size = New Size(CInt(bounds.Width), CInt(bounds.Height))
         AddHandler _tb.LostFocus, AddressOf tb_LostFocus
         AddHandler _tb.KeyDown, AddressOf tb_KeyDown
         AddHandler _tb.MouseDown, AddressOf tb_MouseDown

         _toolBar = New RichTextMenu(_tb)
         _toolBar.Location = New Point(200, 200)
         AddHandler _toolBar.Closing, AddressOf _toolBar_Closing

         _toolBar.Show(_tb.Parent)

         Dim imageViewerAutomationControl As ImageViewerAutomationControl = TryCast(_owner, ImageViewerAutomationControl)
         If imageViewerAutomationControl IsNot Nothing Then
            imageViewerAutomationControl.ImageViewer.Controls.Add(_tb)
         End If

         _tb.Focus()
         _tb.SelectAll()
         IsEditingText = True
      End If
   End Sub

   Private Sub _toolBar_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)
      Dim ownerControl As Control = TryCast(_owner, Control)
      If ownerControl IsNot Nothing Then
         ownerControl.Controls.Remove(_toolBar.RichTextBox)
      End If

      _toolBar.FreeToolbarResources()
   End Sub

   Private Sub tb_MouseDown(sender As Object, e As MouseEventArgs)
      Dim tb As RichTextBox = TryCast(sender, RichTextBox)
      If Not tb.ClientRectangle.Contains(e.X, e.Y) Then
         EndTextMode(True)
      End If
   End Sub

   Private Sub tb_KeyDown(sender As Object, e As KeyEventArgs)
      If e.KeyCode = Keys.Escape Then
         EndTextMode(False)
      ElseIf e.KeyCode = Keys.[Return] Then
         If e.Control <> True Then
            Dim tb As RichTextBox = CType(sender, RichTextBox)
            Dim save As Integer = tb.SelectionStart
            Dim s As String = tb.Text.Substring(0, tb.SelectionStart)
            s += Environment.NewLine
            s += tb.Text.Substring(tb.SelectionStart + tb.SelectionLength)
            tb.SelectionStart = save
         Else
            EndTextMode(True)
         End If
      End If
   End Sub

   Private Sub tb_LostFocus(sender As Object, e As EventArgs)
      Dim tb As RichTextBox = TryCast(sender, RichTextBox)
      If _toolBar IsNot Nothing Then
         If Not _toolBar.Focused AndAlso Not tb.Focused Then
            EndTextMode(True)
         End If
      End If
   End Sub

   Public Sub EndTextMode(changeText As Boolean)
      Dim obj As AnnRichTextObject = TryCast(_targetObject, AnnRichTextObject)

      IsEditingText = False

      If _tb IsNot Nothing Then
         If Not changeText Then
            _tb.Rtf = obj.Rtf
         End If
         obj.Rtf = _tb.Rtf
         If _tb.Parent IsNot Nothing Then
            If _toolBar IsNot Nothing Then
               RemoveHandler _toolBar.Closing, AddressOf _toolBar_Closing
               _toolBar.Dispose()
               _toolBar = Nothing
            End If

            _tb.Parent.Controls.Remove(_tb)
         End If
      End If
   End Sub
End Class
