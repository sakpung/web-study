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

Imports Leadtools.ImageProcessing.Core
Imports System

Partial Public Class KMeansDialog
   Inherits Form
   Private _type As KMeansCommandFlags
   Private _clusters As Integer
   Public Type As KMeansCommandFlags
   Public Clusters As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub KMeansDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New KMeansCommand()
      _type = cmd.Type
      _clusters = cmd.Clusters
      _cbType.SelectedIndex = 0

      Type = _type
      Clusters = _clusters

      _numClusters.Value = Clusters
      Select Case Type
         Case KMeansCommandFlags.KMeans_Random
            _cbType.SelectedIndex = 0
            Exit Select
         Case KMeansCommandFlags.KMeans_Uniform
            _cbType.SelectedIndex = 1
            Exit Select
      End Select
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Select Case _cbType.SelectedIndex
         Case 0
            Type = KMeansCommandFlags.KMeans_Random
            Exit Select
         Case 1
            Type = KMeansCommandFlags.KMeans_Uniform
            Exit Select
      End Select
      Clusters = CInt(_numClusters.Value)

      _clusters = Clusters
      _type = Type
   End Sub
End Class
