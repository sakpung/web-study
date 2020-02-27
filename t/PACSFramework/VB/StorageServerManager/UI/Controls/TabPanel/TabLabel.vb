' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class TabLabel : Inherits Button
      Public Sub New()
         Image = Nothing
         FlatStyle = System.Windows.Forms.FlatStyle.Popup
      End Sub


      Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
         MyBase.OnPaint(e)
         Dim rect As Rectangle = New Rectangle(New Point(0, 0), New Size(Math.Max(Me.Width, 1), Math.Max(Me.Height, 1)))

         If IsPressed Then
            Using myBrush As Brush = New LinearGradientBrush(rect, Color.LightBlue, Color.White, LinearGradientMode.Horizontal)
               e.Graphics.FillRectangle(myBrush, rect)
            End Using
         Else
            Using myBrush As Brush = New LinearGradientBrush(rect, Color.White, Color.LightBlue, LinearGradientMode.Horizontal)
               e.Graphics.FillRectangle(myBrush, rect)
            End Using
         End If

         If Not Nothing Is Image Then
            e.Graphics.DrawImage(Image, New Point(10, 10))
         End If

         If (Not Image Is Nothing) Then
            e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), New PointF((Image.Width) + 10, 10))
         Else
            e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), New PointF((10) + 10, 10))
         End If
      End Sub

      Protected Overrides Sub OnClick(ByVal e As EventArgs)
         MyBase.OnClick(e)

         IsPressed = True
      End Sub

      Private _isPressed As Boolean

      Public Property IsPressed() As Boolean
         Get
            Return _isPressed
         End Get

         Set(ByVal value As Boolean)
            If _isPressed <> Value Then
               _isPressed = Value

               Invalidate()

               If Not Nothing Is IsPressedChangedEvent Then
                  RaiseEvent IsPressedChanged(Me, EventArgs.Empty)
               End If
            End If
         End Set
      End Property

      Public Event IsPressedChanged As EventHandler
   End Class
End Namespace
