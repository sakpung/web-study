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

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core

Namespace MainDemo
   Partial Public Class CommandProgressDialog : Inherits Form
      Public Image As RasterImage
      Public Command As RasterCommand

      Public Cancel As Boolean
      Private _ar As IAsyncResult

      Private Delegate Sub StartupDelegate()

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub CommandProgressDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim cmd As RasterCommand = CType(Command, RasterCommand)
         Text = String.Format("Processing {0}", cmd)
         Cancel = False
         _ar = BeginInvoke(New StartupDelegate(AddressOf Startup))
      End Sub

      Private Sub Startup()
         Dim commandProgress As EventHandler(Of RasterCommandProgressEventArgs) = New EventHandler(Of RasterCommandProgressEventArgs)(AddressOf Command_Progress)
         AddHandler Command.Progress, commandProgress

         Try
            EndInvoke(_ar)
            Command.Run(Image)

            If Cancel Then
               DialogResult = System.Windows.Forms.DialogResult.Cancel
            Else
               DialogResult = System.Windows.Forms.DialogResult.OK
            End If
            Close()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
         Finally
            RemoveHandler Command.Progress, commandProgress
         End Try
      End Sub

      Private Sub Command_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
         _progressBarCommand.Value = e.Percent

         If Cancel Then
            e.Cancel = True
         End If

         Application.DoEvents()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
         Cancel = True
      End Sub
   End Class
End Namespace
