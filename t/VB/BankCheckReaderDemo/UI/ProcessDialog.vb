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
Imports Leadtools.Forms.Commands

Namespace VBBankCheckReader.UI
   Partial Public Class ProcessDialog : Inherits Form

      Public Event ProcessFinished As EventHandler
      Private CancelHit As Boolean = False
      Private _reader As BankCheckReader = Nothing

      Public Sub New(ByVal reader As BankCheckReader)
         InitializeComponent()
         _reader = reader
         AddHandler reader.Process, AddressOf reader_Processed
      End Sub

      Private Sub reader_Processed(ByVal sender As Object, ByVal e As ProgressEventArgs)
         Me.Invoke(New Action(Function() UpdateControls(e)))

         e.Cancel = CancelHit
      End Sub

      Private Function UpdateControls(ByVal e As ProgressEventArgs) As Object
         _progressBar.Value = e.Percentage
         _labelField.Text = e.FieldType.ToString()
         If (e.State = ProcessState.Finish OrElse e.State = ProcessState.Start) Then
            _lableStatus.Text = e.State.ToString()
         Else
            _lableStatus.Text = "Processing"
         End If
         Application.DoEvents()

         If e.State = ProcessState.Finish OrElse e.Percentage = 100 Then
            RemoveHandler _reader.Process, AddressOf reader_Processed
            Me.Close()
            If Not ProcessFinishedEvent Is Nothing Then
               RaiseEvent ProcessFinished(Me, Nothing)
            End If
         End If

         Return Nothing
      End Function

      Private Sub _buttonCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonCancel.Click
         CancelHit = True
         _buttonCancel.Enabled = False
         _reader.Cancel()
      End Sub
   End Class
End Namespace
