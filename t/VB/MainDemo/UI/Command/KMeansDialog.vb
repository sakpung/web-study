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

Imports Leadtools.ImageProcessing.Core

Namespace MainDemo
   Partial Public Class KMeansDialog : Inherits Form
      Public Type As KMeansCommandFlags
      Public Clusters As Integer

      Public Sub New()
         InitializeComponent()
         _cbType.SelectedIndex = 0
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Select Case _cbType.SelectedIndex
            Case 0
               Type = KMeansCommandFlags.KMeans_Random
            Case 1
               Type = KMeansCommandFlags.KMeans_Uniform
         End Select
         Clusters = CInt(_numClusters.Value)
      End Sub

   End Class
End Namespace
