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

Partial Public Class MyOptionsDialog
   Inherits Form
   Public MyOptions As MyOptions

   Public Sub New()
      InitializeComponent()
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _propertyGrid.SelectedObject = MyOptions
      End If

      AddHandler _okButton.Click, AddressOf Me._okButton_Click

      MyBase.OnLoad(e)
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs)
      If String.IsNullOrEmpty(MyOptions.InputFolder) Then
         Warn("Please select an input folder")
         Return
      End If

      If String.IsNullOrEmpty(MyOptions.OutputFolder) Then
         Warn("Please select an output folder")
         Return
      End If
   End Sub

   Private Sub Warn(message As String)
      MessageBox.Show(Me, message, Messager.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Me.DialogResult = System.Windows.Forms.DialogResult.None
   End Sub
End Class
