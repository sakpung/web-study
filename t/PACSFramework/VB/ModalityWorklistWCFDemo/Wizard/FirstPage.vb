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
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Wizard
   Partial Public Class FirstPage
	   Inherits WizardPage
	  #Region "Public"

		 #Region "Methods"

			Public Sub New()
			   Try
				  InitializeComponent ()
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub


		 #End Region

		 #Region "Properties"

		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

		 #Region "Callbacks"

		 #End Region

	  #End Region

	  #Region "Protected"

		 #Region "Methods"

			Protected Overrides Function GetWizardButtons() As WizardSheet.WizardButtons
			   Try
                Return WizardSheet.WizardButtons.Cancel Or WizardSheet.WizardButtons.Next Or WizardSheet.WizardButtons.About
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Function

		 #End Region

		 #Region "Properties"

		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Members"

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

		 #Region "Events"

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

		 #Region "Callbacks"

		 #End Region

	  #End Region
   End Class
End Namespace
