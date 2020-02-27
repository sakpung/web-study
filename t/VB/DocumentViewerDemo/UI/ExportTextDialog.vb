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
Imports System.IO

Partial Public Class ExportTextDialog : Inherits Form
   Public Sub New(ByVal text As String)
      InitializeComponent()

      ' Convert to Window style
      If (Not String.IsNullOrEmpty(text)) Then
         _textBox.Text = text.Replace(Constants.vbLf, Environment.NewLine)
      Else
         _textBox.Text = text
      End If
   End Sub

   Private Sub _saveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveButton.Click

      Dim dlg As SaveFileDialog = New SaveFileDialog()
      Try
         dlg.Filter = "Text files|*.txt|All files|*.*"
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Try
               File.WriteAllText(dlg.FileName, _textBox.Text)
            Catch ex As Exception
               Helper.ShowError(Me, ex)
            End Try
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try

   End Sub
End Class
