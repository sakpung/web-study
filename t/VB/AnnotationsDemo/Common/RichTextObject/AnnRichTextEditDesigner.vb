' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.WinForms
Imports System
Imports Leadtools.Annotations.Designers
Imports Leadtools

<Serializable()> _
Public Class AnnRichTextEditDesigner : Inherits AnnRectangleEditDesigner
   Private _toolBar As RichTextMenu
   Private _tb As System.Windows.Forms.RichTextBox

   Private _isEditingText As Boolean = False

   Friend Property IsEditingText() As Boolean
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

   Public Sub New(automationControl As IAnnAutomationControl, container As AnnContainer, annRichTextObject As AnnRichTextObject)
      MyBase.New(automationControl, container, annRichTextObject)
   End Sub

   Private Sub ShowRichTextDialog(richTextBox As RichTextBox)
      _toolBar = New RichTextMenu(richTextBox)
      _toolBar.Location = New Point(200, 200)
      AddHandler _toolBar.Closing, AddressOf _toolBar_Closing

      _toolBar.Show(richTextBox.Parent)
   End Sub

   Private Sub _toolBar_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)
      Dim ownerControl As Control = TryCast(AutomationControl, Control)
      If ownerControl IsNot Nothing Then
         ownerControl.Controls.Remove(_toolBar.RichTextBox)
      End If

      _toolBar.FreeToolbarResources()

   End Sub


   Public Overrides Function OnPointerDoubleClick(sender As AnnContainer, e As AnnPointerEventArgs) As Boolean
      Dim obj As AnnRichTextObject = TryCast(TargetObject, AnnRichTextObject)

      If (obj IsNot Nothing) AndAlso Not obj.IsLocked Then
         _tb = New RichTextBox()
         _tb.Multiline = True
         _tb.HideSelection = False

         _tb.Rtf = obj.Rtf

         Dim bounds As LeadRectD = Container.Mapper.RectFromContainerCoordinates(obj.Bounds, obj.FixedStateOperations)
         bounds.Inflate(20, 20)

         _tb.Location = New Point(CInt(bounds.X), CInt(bounds.Y))
         _tb.Size = New Size(CInt(bounds.Width), CInt(bounds.Height))
         AddHandler _tb.LostFocus, New EventHandler(AddressOf tb_LostFocus)
         AddHandler _tb.KeyDown, New KeyEventHandler(AddressOf tb_KeyDown)
         AddHandler _tb.MouseDown, New MouseEventHandler(AddressOf tb_MouseDown)

         ShowRichTextDialog(_tb)

         Dim imageViewerAutomationControl As ImageViewerAutomationControl = TryCast(AutomationControl, ImageViewerAutomationControl)
         If imageViewerAutomationControl IsNot Nothing Then
            imageViewerAutomationControl.ImageViewer.Controls.Add(_tb)
         End If

         _tb.Focus()
         _tb.SelectAll()
         IsEditingText = True
      End If
      Return False
   End Function

   Public Overrides Sub [End]()
      MyBase.End()

      EndTextMode(_tb, True)
   End Sub
   Private Sub tb_MouseDown(sender As Object, e As MouseEventArgs)
      Dim tb As RichTextBox = TryCast(sender, RichTextBox)
      If Not tb.ClientRectangle.Contains(e.X, e.Y) Then
         EndTextMode(sender, True)
      End If
   End Sub

   Private Sub tb_KeyDown(sender As Object, e As KeyEventArgs)
      If e.KeyCode = Keys.Escape Then
         EndTextMode(sender, False)
      ElseIf e.KeyCode = Keys.Return Then
         If e.Control <> True Then
            Dim tb As RichTextBox = CType(sender, RichTextBox)
            Dim save As Integer = tb.SelectionStart
            Dim s As String = tb.Text.Substring(0, tb.SelectionStart)
            s += Environment.NewLine
            s += tb.Text.Substring(tb.SelectionStart + tb.SelectionLength)
            tb.SelectionStart = save
         Else
            EndTextMode(sender, True)
         End If
      End If
   End Sub

   Private Sub tb_LostFocus(sender As Object, e As EventArgs)
      Dim tb As RichTextBox = TryCast(sender, RichTextBox)
      If _toolBar IsNot Nothing Then
         If Not _toolBar.Focused AndAlso Not tb.Focused Then
            EndTextMode(sender, True)
         End If
      End If
   End Sub

   Private Sub EndTextMode(sender As Object, changeText As Boolean)
      Dim obj As AnnRichTextObject = TryCast(TargetObject, AnnRichTextObject)
      Dim tb As RichTextBox = TryCast(sender, RichTextBox)

      IsEditingText = False

      If tb IsNot Nothing Then
         If Not changeText Then
            tb.Rtf = obj.Rtf
         End If
         obj.Rtf = tb.Rtf
         If tb.Parent IsNot Nothing Then
            If _toolBar IsNot Nothing Then
               RemoveHandler _toolBar.Closing, AddressOf _toolBar_Closing
               _toolBar.Dispose()
               _toolBar = Nothing
            End If

            tb.Parent.Controls.Remove(tb)
         End If
      End If
   End Sub
End Class
