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

Namespace PrintToPACSDemo
   Partial Public Class FrmOperation : Inherits Form
   Public Event Cancel As EventHandler
   Private _strCaption As String = ""
   Public Property Caption() As String
   Get
    Return _strCaption
   End Get
   Set(ByVal value As String)
    _strCaption = Value
   End Set
   End Property

   Private _strBtnCaption As String = ""
   Public Property ButtontCaption() As String
   Get
    Return _strBtnCaption
   End Get
   Set(ByVal value As String)
    _strBtnCaption = Value
   End Set
   End Property

   Private Sub New()
   InitializeComponent()
   End Sub

   Public Sub New(ByVal strCaption As String, ByVal strBtnCaption As String)
   InitializeComponent()
   _strBtnCaption = strBtnCaption
   _strCaption = strCaption
   _lblCaption.Text = strCaption
   _btnCancelOperation.Text = strBtnCaption

   If strBtnCaption = "" Then
   _btnCancelOperation.Visible = False
   End If
   End Sub

   Private Sub _btnCancelOperation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancelOperation.Click
   If Not CancelEvent Is Nothing Then
   RaiseEvent Cancel(Nothing, Nothing)
   End If
   End Sub

   End Class
End Namespace
