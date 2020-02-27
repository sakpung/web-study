' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Wizard
Imports Leadtools.Wizard.Pages

Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class IntroductionPage
		Inherits WelcomeTemplatePage
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			MyBase.OnSetActive(sender, e)
		End Sub
	End Class
End Namespace
