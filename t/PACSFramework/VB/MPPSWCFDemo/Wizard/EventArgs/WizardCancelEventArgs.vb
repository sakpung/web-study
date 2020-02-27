' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports Leadtools.Wizard

Namespace Leadtools.Wizard
	Public Class WizardCancelEventArgs
		Inherits CancelEventArgs
		Private privatePreviousPage As WizardPage
		Public Property PreviousPage() As WizardPage
			Get
				Return privatePreviousPage
			End Get
			Set(ByVal value As WizardPage)
				privatePreviousPage = value
			End Set
		End Property
	End Class
End Namespace
