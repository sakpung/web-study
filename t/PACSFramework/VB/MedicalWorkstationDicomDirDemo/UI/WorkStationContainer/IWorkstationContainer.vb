' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Demos.Workstation
   Friend Interface IWorkstationContainer
	  Sub SetHelpNamescpace(ByVal helpNamespace As String)
	  Sub OnFullScreenChanged(ByVal isFullScreen As Boolean)

	  ReadOnly Property DisplayContainer() As Control

	  WriteOnly Property CanSearch() As Boolean

	  WriteOnly Property CanViewImages() As Boolean

	  WriteOnly Property CanConfigure() As Boolean

	  WriteOnly Property CanManageUsers() As Boolean

	  WriteOnly Property CanManageService() As Boolean

	  WriteOnly Property CanCreateMedia() As Boolean

	  WriteOnly Property CanViewQueueManager() As Boolean

	  WriteOnly Property CanDisplayHelp() As Boolean

	  WriteOnly Property CanToggleFullScreen() As Boolean

     Event ViewLoad As EventHandler

	  Event DoSearch As EventHandler

	  Event DoDisplayViewer As EventHandler

	  Event DoConfigure As EventHandler

	  Event DoManageUsers As EventHandler

	  Event DoManageService As EventHandler

	  Event DoCreateMedia As EventHandler

	  Event DoViewQueueManager As EventHandler

	  Event DoDisplayHelp As EventHandler

	  Event DoToggleFullScreen As EventHandler

	  Event ExitFullScreen As EventHandler

	  Sub OnDisplayedControlChanged(ByVal uiElement As String)
   End Interface
End Namespace
