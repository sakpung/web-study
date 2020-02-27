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

Partial Public Class LinkValueDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public LinkValue As String

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _linkValueTextBox.Text = LinkValue
      End If

      MyBase.OnLoad(e)
   End Sub
End Class
