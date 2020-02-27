' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel


Namespace Leadtools.Wizard
   Public Delegate Sub WizardPageEventHandler(ByVal sender As Object, ByVal e As WizardPageEventArgs)

   Public Class WizardPageEventArgs
	   Inherits CancelEventArgs
	  Public Sub New(ByVal currentPage As WizardPage)
		 _currentPage = currentPage
	  End Sub

	  Private _newPage As WizardPage = Nothing
	  Private _currentPage As WizardPage = Nothing

	  Public Property NewPage() As WizardPage
		 Get
			Return _newPage
		 End Get

		 Set(ByVal value As WizardPage)
			_newPage = value
		 End Set
	  End Property

	  Public ReadOnly Property CurrentPage() As WizardPage
		 Get
			Return _currentPage
		 End Get

	  End Property
   End Class
End Namespace
