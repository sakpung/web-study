' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Leadtools.Demos.Workstation.Configuration
   Public Class StorageCompression
	  Public Property Enable() As Boolean
		 Get
			Return _enable
		 End Get

		 Set(ByVal value As Boolean)
			If value <> _enable Then
			   _enable = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property


	  Public Property Lossy() As Boolean
		 Get
			Return _lossy
		 End Get

		 Set(ByVal value As Boolean)
			If value <> _lossy Then
			   _lossy = value

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

	  Private _enable As Boolean
	  Private _lossy As Boolean
   End Class
End Namespace
