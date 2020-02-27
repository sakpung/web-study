
' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System

Namespace FormsDemo
   Partial Public Class FormsInformation
      Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub _lbllink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles _lbllink.LinkClicked
         System.Diagnostics.Process.Start("https://www.leadtools.com/videos/playvideo.asp?id=11")
      End Sub

      Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
         Me.Close()
      End Sub
   End Class
End Namespace