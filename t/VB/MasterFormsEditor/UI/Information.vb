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
Imports System.Reflection
Imports System.IO
Imports System

Partial Public Class InformationDlg
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Function ShouldShow() As Boolean
      Try
         If TryCast(Settings.[Default]("ShowAgain"), String) = "False" Then
            Return False
         End If
      Catch
         Return True
      End Try

      Return True
   End Function

   Private Sub Information_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim stream As New MemoryStream(Resources.Info)
      richTextBox1.LoadFile(stream, RichTextBoxStreamType.RichText)
      stream.Close()
      checkBox1.Checked = Not ShouldShow()
   End Sub

   Private Sub checkBox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox1.CheckedChanged
      If checkBox1.Checked = True Then
         Settings.[Default]("ShowAgain") = "False"
      Else
         Settings.[Default]("ShowAgain") = "True"
      End If
      Settings.[Default].Save()
      ' Saves settings in application configuration file
   End Sub
End Class
