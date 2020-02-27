' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace DicomDemo
   Partial Public Class Page7 : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub linkLabels_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked, linkLabel2.LinkClicked, linkLabel3.LinkClicked
         Dim proc As Process = New Process()
         proc.StartInfo.FileName = (CType(sender, LinkLabel)).Text
         proc.Start()
      End Sub
   End Class
End Namespace
