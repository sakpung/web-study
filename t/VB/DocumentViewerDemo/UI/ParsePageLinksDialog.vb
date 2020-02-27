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

Partial Public Class ParsePageLinksDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public MaxPageCount As Integer
   Public AutoParsePageLinksDecisionFinal As Boolean

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _infoLabel.Text = _infoLabel.Text.Replace("###", MaxPageCount.ToString())
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _yesButton_Click(sender As Object, e As EventArgs) Handles _yesButton.Click
      Me.AutoParsePageLinksDecisionFinal = _rememberDecisionCheckBox.Checked
   End Sub

   Private Sub _noButton_Click(sender As Object, e As EventArgs) Handles _noButton.Click
      Me.AutoParsePageLinksDecisionFinal = _rememberDecisionCheckBox.Checked
   End Sub
End Class
