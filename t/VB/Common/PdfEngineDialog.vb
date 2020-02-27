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

Partial Public Class PdfEngineDialog : Inherits Form
   Public Sub New()
      DialogUtilities.RunFPU()

      InitializeComponent()
   End Sub

   Public Sub ShowWarningMessagesOnly()
      _gbOptions.Text = "The demo can continue without PDF support. What do you want to do now:"
      _rbCancel.Text = "Close the demo"
      _rbContinue.Text = "Continue with the demo without PDF support"
      _rbContinue.Checked = True
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
      If _rbCancel.Checked Then
         DialogResult = System.Windows.Forms.DialogResult.Cancel
      Else
         DialogResult = System.Windows.Forms.DialogResult.OK
      End If
   End Sub

   Private Sub _lbEngine_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _lbEngine.LinkClicked
      Process.Start(_lbEngine.Text)
   End Sub

   Private Sub PdfEngineDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If LTV15_CONFIG Then
      Me._lbEngine.Text = "https://www.leadtools.com/rd/v150/LEADTOOLSPDFRuntime.exe"
#ElseIf LTV16_CONFIG Then
      Me._lbEngine.Text = "https://www.leadtools.com/rd/v160/LEADTOOLSPDFRuntime.exe"
#Else
      Me._lblLine2.Text = String.Empty
      Me._lbEngine.Text = String.Empty
      Me._lbEngine.Visible = False
      Me._lbEngine.Enabled = False
#End If
   End Sub
End Class
