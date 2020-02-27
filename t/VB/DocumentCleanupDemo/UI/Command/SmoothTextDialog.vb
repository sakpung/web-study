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

Namespace DocumentCleanupDemo
   Partial Public Class SmoothTextDialog : Inherits Form

      '' The SmoothCommand Class is part of the LEAD Document Imaging function group, This class will smooth the bumps and fills in the nicks of a 1-bit black and white image.
      '' This dialog will use the SmoothCommand flags that will indicate how this command will process and the SmoothCommand.Length member.
      '' The Flags used are:
      '' SmoothCommandFlags.FavorLong and SmoothCommandFlags.FavorShort
      ''SmoothCommand.Length, this member will be used to set the length of the bump (or nick) to remove (or fill).   

      Private _SmoothCommand As SmoothCommand = Nothing

      Public Sub New()
         InitializeComponent()
         _SmoothCommand = New SmoothCommand()
         InitializeUI()
      End Sub
      Public Sub New(ByVal SmoothCommand As SmoothCommand)
         InitializeComponent()
         _SmoothCommand = SmoothCommand
         InitializeUI()
      End Sub
      Public Property SmoothCommand() As SmoothCommand
         Get
            UpdateCommand()
            Return _SmoothCommand
         End Get
         Set(ByVal value As SmoothCommand)
            _SmoothCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = Windows.Forms.DialogResult.Cancel
      End Sub

      Private Sub InitializeUI()
         '' Set the behavior of the smoothing process.  
         _tbLength.Text = _SmoothCommand.Length.ToString()
         If (_SmoothCommand.Flags And SmoothCommandFlags.FavorLong) = SmoothCommandFlags.FavorLong Then
            _rbLong.Checked = True
         Else
            _rbShort.Checked = True
         End If
      End Sub

      Private Sub UpdateCommand()
         '' Set the length of the bump (or nick) to remove (or fill). 
         If _tbLength.Text <> "" Then
            _SmoothCommand.Length = Convert.ToInt32(_tbLength.Text)
         End If
         _SmoothCommand.Flags = CType(IIf(_rbLong.Checked, SmoothCommandFlags.FavorLong, SmoothCommandFlags.None), SmoothCommandFlags)
      End Sub

      Private Function IsValidNumber(ByVal s As String, ByVal minVal As Int32, ByVal maxVal As Int32) As Boolean
         Dim retval As Boolean = True
         Try
            Dim x As Integer = Int32.Parse(s)
            If x > maxVal OrElse x < minVal Then
               retval = False
            End If
         Catch e1 As Exception
            retval = False
         End Try
         Return retval
      End Function

      Private Sub _tbLength_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbLength.TextChanged
         _tbLength.Text = MainForm.IsValidNumber(_tbLength.Text, 1, 10000)
      End Sub
   End Class
End Namespace
