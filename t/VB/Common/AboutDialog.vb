' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics

Partial Public Class AboutDialog
   Inherits Form

   Public Sub New(ByVal demoName As String)
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      _demoName = demoName
   End Sub

   Private _demoName As String

   Private Shared Function Is64Process() As Boolean
      Return IntPtr.Size = 8
   End Function

   Private Sub AboutDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim platform As String = "32"
      If (Not Is64Process()) Then
         platform = "32"
      Else
         platform = "64"
      End If
      _tb1.Text = String.Format("LEADTOOLS .NET VB {0} Demo {1}{2}{2}{2}Copyright © 1991-2019 ALL RIGHTS RESERVED.{2}LEAD Technologies, Inc.", _demoName, platform, Environment.NewLine)
      CenterToParent()
   End Sub

   Private Sub _lblWebSite_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _lblWebSite.LinkClicked
      Dim ll As LinkLabel = CType(sender, LinkLabel)
      If ll IsNot Nothing Then
         Process.Start(ll.Text)
      End If
   End Sub
End Class
