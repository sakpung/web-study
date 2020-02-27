' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Configuration
Imports Leadtools.Medical.DataAccessLayer

Namespace VBCustomizingWorklistDAL.UI
   Partial Public Class DatabaseStatus : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Property ConnectionString() As String
         Get
            Return ConnectionStringTextBox.Text
         End Get

         Set(ByVal value As String)
            ConnectionStringTextBox.Text = value
         End Set
      End Property

      Public Property ProviderName() As String
         Get
            Return ProviderTextBox.Text
         End Get

         Set(ByVal value As String)
            ProviderTextBox.Text = value
         End Set
      End Property
   End Class
End Namespace
