' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports System

Public Class OutputWindow
   Inherits RichTextBox
   Public Enum LineStyle
      Normal
      Bold
      [Error]
      Success
   End Enum

   <DefaultValue(False)> _
   Public Property AddTime() As Boolean
      Get
         Return m_AddTime
      End Get
      Set(value As Boolean)
         m_AddTime = value
      End Set
   End Property
   Private m_AddTime As Boolean

   Public Sub New()
      Me.Font = New Font("Consolas", 8)
      Me.[ReadOnly] = True

      Dim contextMenu As ContextMenuStrip = New ContextMenuStrip()
      Dim item As ToolStripMenuItem = New ToolStripMenuItem("Clear")
      AddHandler item.Click, Sub(sender, e)
                                Me.Clear()

                             End Sub
      contextMenu.Items.Add(item)
      Me.ContextMenuStrip = contextMenu
   End Sub

   Public Sub AddTextLine(ex As Exception)
      If Not Enabled Then
         Return
      End If

      AddTextLine(String.Format("Exception: {0}{1}{2}", ex.[GetType]().Name, Environment.NewLine, ex.Message), LineStyle.[Error])
   End Sub

   Private Function AddCurrentTime(text As String) As String
      If Not AddTime Then
         Return text
      End If

      Dim now As DateTime = DateTime.Now

      Dim nowString As String = String.Format("{0}:{1}:{2}", now.Hour.ToString("00"), now.Minute.ToString("00"), now.Second.ToString("00"))
      If text IsNot Nothing Then
         text = nowString & "-" & text
      Else
         text = nowString
      End If

      Return text
   End Function

   Public Sub AddText(text As String)
      If Not Enabled Then
         Return
      End If

      text = AddCurrentTime(text)
      AppendText(text)

      ScrollToCaret()
   End Sub

   Public Sub AddTextLine(text As String)
      If Not Enabled Then
         Return
      End If

      text = AddCurrentTime(text)

      If text IsNot Nothing Then
         AppendText(text & Environment.NewLine)
      Else
         AppendText(Environment.NewLine)
      End If

      ScrollToCaret()
   End Sub

   Public Sub AddTextLine(text As String, lineStyle__1 As LineStyle)
      If Not Enabled Then
         Return
      End If

      text = AddCurrentTime(text)

      If lineStyle__1 = LineStyle.Normal Then
         AddTextLine(text)
         Return
      End If

      Dim oldSelectionStart As Integer = SelectionStart

      If text IsNot Nothing Then
         AppendText(text & Environment.NewLine)
      Else
         AppendText(Environment.NewLine)
      End If

      Dim newSelectionStart As Integer = SelectionStart
      Me.SelectionStart = oldSelectionStart
      Me.SelectionLength = newSelectionStart - oldSelectionStart

      Dim color__2 As Color

      Select Case lineStyle__1
         Case LineStyle.[Error]
            color__2 = Color.Red
            Exit Select

         Case LineStyle.Success
            color__2 = Color.Blue
            Exit Select
         Case Else

            color__2 = Color.Black
            Exit Select
      End Select

      Me.SelectionColor = color__2
      Using font__3 As Font = New Font(Font.FontFamily, Font.Size, FontStyle.Bold)
         SelectionFont = font__3
      End Using

      Me.SelectionStart = newSelectionStart

      Me.ScrollToCaret()
   End Sub
End Class

' A trace listener implementation for the output window
Public Class OutputWindowTraceListener
   Inherits TraceListener
   Private Sub New()
   End Sub

   Public Sub New(outputWindow As OutputWindow)
      _outputWindow = outputWindow
   End Sub

   Private _outputWindow As OutputWindow

   Public Overrides Sub Write(message As String)
      _outputWindow.BeginInvoke(CType(Sub() _outputWindow.AddText(message), MethodInvoker))
   End Sub

   Public Overrides Sub WriteLine(message As String)
      _outputWindow.BeginInvoke(CType(Sub() _outputWindow.AddTextLine(message), MethodInvoker))
   End Sub
End Class
