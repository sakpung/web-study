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

Partial Public Class OtsuThresholdDialog
   Inherits Form
   Private _clusters As Integer

   Public Clusters As Integer
   Private _mainForm As MainForm

   Public Sub New(form As MainForm)
      _mainForm = form
      InitializeComponent()
   End Sub

   Private Sub OtsuThresholdDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New OtsuThresholdCommand()
      _clusters = cmd.Clusters

      Clusters = _clusters

      _numClusters.Value = Clusters
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Clusters = CInt(_numClusters.Value)
      _clusters = Clusters
      TryCast(_mainForm.ActiveMdiChild, ViewerForm).addToImageList()
      _mainForm.IsSegmentation = False
      _mainForm.UpdateMyControls()
      TryCast(_mainForm.ActiveMdiChild, ViewerForm).UpdateAfterCommandExecution()
   End Sub
End Class
