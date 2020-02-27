' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class ServerMainMenu : Inherits MenuStrip
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()

         Init()

         RegisterEvents()
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

      Public Event ExitApplication As EventHandler
      Public Event ShowSettings As EventHandler
      Public Event ShowAbout As EventHandler

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

      Private Sub Init()
         _file = New ToolStripMenuItem("&File")
         _tools = New ToolStripMenuItem("&Tools")
         _help = New ToolStripMenuItem("&Help")
         _fileExit = New ToolStripMenuItem("E&xit")
         _toolsSettings = New ToolStripMenuItem("&Settings...")
         _helpAbout = New ToolStripMenuItem("&About")


         _file.DropDownItems.Add(_fileExit)
         _tools.DropDownItems.Add(_toolsSettings)
         _help.DropDownItems.Add(_helpAbout)

         Me.Items.Add(_file)
         Me.Items.Add(_tools)
         Me.Items.Add(_help)

         _toolsSettings.Enabled = UserManager.User.IsAdmin() OrElse UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings)
      End Sub

      Private Sub RegisterEvents()
         AddHandler _fileExit.Click, AddressOf _fileExit_Click
         AddHandler _toolsSettings.Click, AddressOf _toolsSettings_Click
         AddHandler _helpAbout.Click, AddressOf _helpAbout_Click
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Private Sub _toolsSettings_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is ShowSettingsEvent Then
               RaiseEvent ShowSettings(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _fileExit_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is ExitApplicationEvent Then
               RaiseEvent ExitApplication(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _helpAbout_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is ShowAboutEvent Then
               RaiseEvent ShowAbout(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

#End Region

#Region "Data Members"

      Private _file As ToolStripMenuItem
      Private _tools As ToolStripMenuItem
      Private _help As ToolStripMenuItem
      Private _fileExit As ToolStripMenuItem
      Private _toolsSettings As ToolStripMenuItem
      Private _helpAbout As ToolStripMenuItem

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class

End Namespace
