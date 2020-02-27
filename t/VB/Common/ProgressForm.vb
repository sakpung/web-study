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

Partial Public Class ProgressForm : Inherits Form
   Private _abort As Boolean

   Public Sub New(ByVal caption_Renamed As String, ByVal informationString_Renamed As String, ByVal progressMaxValue As Integer)
      InitializeComponent()

      _abort = False
      Me.Text = caption_Renamed
      _lblInformation.Text = informationString_Renamed
      _progress.Maximum = progressMaxValue
   End Sub

   Public Property Percent() As Integer
      Get
         Return _progress.Value
      End Get
      Set(ByVal value As Integer)
         _progress.Value = Value
      End Set
   End Property

   Public Property InformationString() As String
      Get
         Return _lblInformation.Text
      End Get
      Set(ByVal value As String)
         _lblInformation.Text = Value
      End Set
   End Property

   Public Property Caption() As String
      Get
         Return Me.Text
      End Get
      Set(ByVal value As String)
         Me.Text = Value
      End Set
   End Property

   Public ReadOnly Property Abort() As Boolean
      Get
         Return _abort
      End Get
   End Property

   Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
      _abort = True
      DialogResult = Windows.Forms.DialogResult.Abort
      Me.Dispose()
      Application.DoEvents()
   End Sub
End Class
