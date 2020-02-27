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
Imports Leadtools.Medical.Winforms

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class UserView : Inherits UserControl
      Private _UsersAccounts As UsersAccountView

      Public ReadOnly Property UsersAccounts() As UsersAccountView
         Get
            Return _UsersAccounts
         End Get
      End Property

      Public Sub New()
         InitializeComponent()

         _UsersAccounts = New UsersAccountView()
         _UsersAccounts.Dock = DockStyle.Fill
         Controls.Add(_UsersAccounts)
         AddHandler _UsersAccounts.ValueChanged, AddressOf _UsersAccounts_ValueChanged
      End Sub

      Private Sub _UsersAccounts_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not SettingsChangedEvent Is Nothing Then
            RaiseEvent SettingsChanged(sender, e)
         End If
      End Sub

      Public Event SettingsChanged As EventHandler

   End Class
End Namespace
