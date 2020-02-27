' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Leadtools.Wizard
   Public Class WizardPagesCollection
	   Inherits List(Of WizardPage)
	  Private _parent As WizardSheet

	  Friend Sub New(ByVal parent As WizardSheet)
		 _parent = parent
	  End Sub
	  Public Shadows Sub Add(ByVal page As WizardPage)
		 page.ParentWizard = _parent

		 MyBase.Add (page)
	  End Sub
   End Class
End Namespace
