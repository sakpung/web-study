' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Leadtools.Demos.Workstation.Configuration
   Public Class LazyLoading
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


	  Public Property HiddenImages() As Integer
		 Get
			Return _hiddenImages
		 End Get

		 Set(ByVal value As Integer)
			If value <> _hiddenImages Then
			   _hiddenImages = value

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
	  Private _hiddenImages As Integer = 0
   End Class
End Namespace
