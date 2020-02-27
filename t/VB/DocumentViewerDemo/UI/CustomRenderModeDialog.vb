' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Imaging

Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Automation
Imports System

Partial Public Class CustomRenderModeDialog
   Inherits Form
   Public Property AutomationManager() As AnnAutomationManager
      Get
         Return m_AutomationManager
      End Get
      Set(value As AnnAutomationManager)
         m_AutomationManager = value
      End Set
   End Property
   Private m_AutomationManager As AnnAutomationManager

   Public Property AllRenderers() As Dictionary(Of Integer, IAnnObjectRenderer)
      Get
         Return m_AllRenderers
      End Get
      Set(value As Dictionary(Of Integer, IAnnObjectRenderer))
         m_AllRenderers = value
      End Set
   End Property
   Private m_AllRenderers As Dictionary(Of Integer, IAnnObjectRenderer)
   Public Property CurrentRenderers() As Dictionary(Of Integer, IAnnObjectRenderer)
      Get
         Return m_CurrentRenderers
      End Get
      Set(value As Dictionary(Of Integer, IAnnObjectRenderer))
         m_CurrentRenderers = value
      End Set
   End Property
   Private m_CurrentRenderers As Dictionary(Of Integer, IAnnObjectRenderer)
   Public Property ResultRenderers() As Dictionary(Of Integer, IAnnObjectRenderer)
      Get
         Return m_ResultRenderers
      End Get
      Set(value As Dictionary(Of Integer, IAnnObjectRenderer))
         m_ResultRenderers = value
      End Set
   End Property
   Private m_ResultRenderers As Dictionary(Of Integer, IAnnObjectRenderer)

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Structure MyListBoxItem
      Public Property ObjectId() As Integer
         Get
            Return m_ObjectId
         End Get
         Set(value As Integer)
            m_ObjectId = value
         End Set
      End Property
      Private m_ObjectId As Integer
      Public Property Name() As String
         Get
            Return m_Name
         End Get
         Set(value As String)
            m_Name = value
         End Set
      End Property
      Private m_Name As String
      Public Overrides Function ToString() As String
         Return Name
      End Function
   End Structure

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         For Each iter As KeyValuePair(Of Integer, IAnnObjectRenderer) In Me.AllRenderers
            ' Visible means its in RenderMode
            Dim annObjectId As Integer = iter.Key

            ' ignore these types
            Select Case annObjectId
               Case AnnObject.SelectObjectId, AnnObject.ImageObjectId
                  Exit Select
               Case Else

                  Dim automationObject As AnnAutomationObject = Me.AutomationManager.FindObjectById(annObjectId)
                  If automationObject IsNot Nothing Then
                     Dim listBoxItem As MyListBoxItem = New MyListBoxItem() With { _
                       .ObjectId = annObjectId, _
                       .Name = automationObject.Name _
                     }
                     If Me.CurrentRenderers.ContainsKey(annObjectId) Then
                        _visibleObjectsListBox.Items.Add(listBoxItem)
                     Else
                        _invisibleObjectsListBox.Items.Add(listBoxItem)
                     End If
                  End If
                  Exit Select
            End Select
         Next

         UpdateUIState()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _visibleObjectsListBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles _visibleObjectsListBox.DrawItem
      DrawItem(TryCast(sender, ListBox), e)
   End Sub

   Private Sub _invisibleObjectsListBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles _invisibleObjectsListBox.DrawItem
      DrawItem(TryCast(sender, ListBox), e)
   End Sub

   Private Sub DrawItem(listBox As ListBox, e As DrawItemEventArgs)
      If e.Index < 0 Then
         Return
      End If

      Dim graphics As Graphics = e.Graphics
      Dim listBoxItem As MyListBoxItem = CType(listBox.Items(e.Index), MyListBoxItem)
      Dim automationObject As AnnAutomationObject = Me.AutomationManager.FindObjectById(listBoxItem.ObjectId)

      Using brush As SolidBrush = New SolidBrush(e.BackColor)
         graphics.FillRectangle(brush, e.Bounds)
      End Using

      Dim rc As Rectangle = e.Bounds

      If automationObject IsNot Nothing Then
         Dim bitmap As Bitmap = TryCast(automationObject.ToolBarImage, Bitmap)
         If bitmap IsNot Nothing Then
            Const dx As Integer = 2
            Dim factor As Double = 1.0

            If bitmap.Height > rc.Height AndAlso rc.Height > 0 Then
               factor = CDbl(rc.Height) / CDbl(bitmap.Height)
            End If

            Dim width As Integer = CInt(Math.Truncate(bitmap.Width * factor + 0.5))
            Dim height As Integer = CInt(Math.Truncate(bitmap.Height * factor + 0.5))

            Dim bitmapRect As Rectangle = New Rectangle(rc.X + dx, rc.Y + (rc.Height - height) \ 2, width, height)

            Using ia As ImageAttributes = New ImageAttributes()
               Dim color As Color = bitmap.GetPixel(0, 0)
               ia.SetColorKey(color, color)
               graphics.DrawImage(bitmap, bitmapRect, 0, 0, bitmap.Width, bitmap.Height, _
                GraphicsUnit.Pixel, ia)
            End Using

            rc = Rectangle.FromLTRB(rc.X + width + dx * 2, rc.Y, rc.Right, rc.Bottom)
         End If

         Using sf As StringFormat = New StringFormat()
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center

            Using brush As SolidBrush = New SolidBrush(e.ForeColor)
               graphics.DrawString(automationObject.Name, Font, brush, rc, sf)
            End Using
         End Using
      End If
   End Sub

   Private Sub _visibleObjectsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _visibleObjectsListBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _invisibleObjectsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _invisibleObjectsListBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      _moveToInvisibleButton.Enabled = _visibleObjectsListBox.SelectedItems.Count > 0
      _moveToVisibleButton.Enabled = _invisibleObjectsListBox.SelectedItems.Count > 0
   End Sub

   Private Sub _moveToInvisibleButton_Click(sender As Object, e As EventArgs) Handles _moveToInvisibleButton.Click
      MoveObjects(_visibleObjectsListBox, _invisibleObjectsListBox)
   End Sub

   Private Sub _moveToVisibleButton_Click(sender As Object, e As EventArgs) Handles _moveToVisibleButton.Click
      MoveObjects(_invisibleObjectsListBox, _visibleObjectsListBox)
   End Sub

   Private Shared Sub MoveObjects(sourceListBox As ListBox, targetListBox As ListBox)
      ' get the objects
      Dim count As Integer = sourceListBox.SelectedItems.Count
      If count = 0 Then
         Return
      End If

      Dim items As List(Of MyListBoxItem) = New List(Of MyListBoxItem)()
      For i As Integer = 0 To count - 1
         items.Add(CType(sourceListBox.SelectedItems(i), MyListBoxItem))
      Next

      sourceListBox.SuspendLayout()
      targetListBox.SuspendLayout()

      For Each item As MyListBoxItem In items
         sourceListBox.Items.Remove(item)
         targetListBox.Items.Add(item)
      Next

      sourceListBox.ResumeLayout()
      targetListBox.ResumeLayout()
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      ' Get the items in visible
      Dim count As Integer = _visibleObjectsListBox.Items.Count
      Dim items As List(Of MyListBoxItem) = New List(Of MyListBoxItem)()
      For i As Integer = 0 To count - 1
         items.Add(CType(_visibleObjectsListBox.Items(i), MyListBoxItem))
      Next

      ' Update the result
      Me.ResultRenderers = New Dictionary(Of Integer, IAnnObjectRenderer)()

      For Each iter As KeyValuePair(Of Integer, IAnnObjectRenderer) In Me.AllRenderers
         Dim annObjectId As Integer = iter.Key
         For Each item As MyListBoxItem In items
            If item.ObjectId = annObjectId Then
               Me.ResultRenderers.Add(annObjectId, iter.Value)
               Exit For
            End If
         Next
      Next
   End Sub
End Class
