' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace MainDemo
   Partial Public Class OtsuThresholdDialog : Inherits Form
      Public Clusters As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Clusters = CInt(_numClusters.Value)
      End Sub
   End Class
End Namespace
