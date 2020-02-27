' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Medical.Workstation

Namespace Leadtools.Demos.Workstation.Configuration
   Public Class DebuggingConfig
	  Public Property Enable() As Boolean
		 Get
			Return _enable
		 End Get

		 Set(ByVal value As Boolean)
			If value <> _enable Then
			   _enable = value

			   OnValueChanged ()

			   WorkstationMessager.DetailedError = Enable AndAlso DisplayDetailedErrors
			End If
		 End Set
	  End Property


	  Public Property DisplayDetailedErrors() As Boolean
		 Get
			Return _displayDetailedErrors
		 End Get

		 Set(ByVal value As Boolean)
			If value <> _displayDetailedErrors Then
			   _displayDetailedErrors = value

			   OnValueChanged ()

			   WorkstationMessager.DetailedError = Enable AndAlso DisplayDetailedErrors
			End If
		 End Set
	  End Property

	  Public Property GenerateLogFile() As Boolean
		 Get
			Return _generateLogFile
		 End Get

		 Set(ByVal value As Boolean)
			If value <> _generateLogFile Then
			   _generateLogFile = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Public Property LogFileName() As String
		 Get
			Return _logFileName
		 End Get

		 Set(ByVal value As String)
			If value <> _logFileName Then
			   _logFileName = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Private Sub OnValueChanged()
		 If Nothing IsNot ValueChangedEvent Then
			RaiseEvent ValueChanged(Me, New EventArgs ())
		 End If
	  End Sub

	  Public Event ValueChanged As EventHandler

	  Private _enable As Boolean = False
	  Private _displayDetailedErrors As Boolean = False
	  Private _generateLogFile As Boolean = False
	  Private _logFileName As String = String.Empty
   End Class
End Namespace
