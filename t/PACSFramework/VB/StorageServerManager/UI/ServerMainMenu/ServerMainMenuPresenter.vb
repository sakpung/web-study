' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.Winforms

Namespace Leadtools.Demos.StorageServer.UI
   Public Class ServerMainMenuPresenter
#Region "Public"

#Region "Methods"

      Public Sub New()
      End Sub

      Public Sub RunView(ByVal view As ServerMainMenu)
         AddHandler view.ExitApplication, AddressOf view_ExitApplication
         AddHandler view.ShowSettings, AddressOf view_ShowSettings
         AddHandler view.ShowAbout, AddressOf view_ShowAbout
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

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

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Private Sub view_ShowSettings(ByVal sender As Object, ByVal e As EventArgs)
         EventBroker.Instance.PublishEvent(Of DisplayFeatureEventArgs)(Me, New DisplayFeatureEventArgs(FeatureNames.DisplaySettingsFeature))
      End Sub

      Private Sub view_ShowAbout(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("About")
      End Sub

      Private Sub view_ExitApplication(ByVal sender As Object, ByVal e As EventArgs)
         Application.Exit()
      End Sub

#End Region

#Region "Data Members"

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
