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
   <DefaultEvent ("SetActive")> _
   Partial Public Class WizardPage
	   Inherits UserControl
	  #Region "Public"

		 #Region "Methods"

			Public Sub New()
			   Try
				  InitializeComponent ()

				  AddHandler Load, AddressOf WizardPage_Load
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub


			Public Overridable Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			   Try
				  If SetActiveEvent IsNot Nothing Then
					 RaiseEvent SetActive(sender, e)
				  End If

				  GetWizard ().SetWizardButtons (GetWizardButtons ())
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

			Public Overridable Sub OnWizardNext(ByVal sender As Object, ByVal e As WizardPageEventArgs)
			   Try
				  If WizardNextEvent IsNot Nothing Then
					 RaiseEvent WizardNext(sender, e)
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

			Public Overridable Sub OnWizardBack(ByVal sender As Object, ByVal e As WizardPageEventArgs)
			   Try
				  If WizardBackEvent IsNot Nothing Then
					 RaiseEvent WizardBack(sender, e)
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

			Public Overridable Sub OnWizardFinish(ByVal sender As Object, ByVal e As CancelEventArgs)
			   Try
				  If Nothing IsNot WizardFinishEvent Then
					 RaiseEvent WizardFinish(sender, e)
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

			Public Overridable Sub OnWizardCancel(ByVal sender As Object, ByVal e As CancelEventArgs)
			   Try
				  If Nothing IsNot WizardCancelEvent Then
					 RaiseEvent WizardCancel(sender, e)
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

			Public Overridable Sub OnOptionButton1(ByVal sender As Object, ByVal e As EventArgs)
			End Sub

			Public Overridable Sub OnReset()
			End Sub


		 #End Region

		 #Region "Properties"

		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

		 #Region "Callbacks"

			<Category ("Wizard")> _
			Public Event SetActive As CancelEventHandler

			<Category ("Wizard")> _
			Public Event WizardNext As WizardPageEventHandler

			<Category ("Wizard")> _
			Public Event WizardBack As WizardPageEventHandler


			<Category ("Wizard")> _
			Public Event WizardFinish As CancelEventHandler


			<Category ("Wizard")> _
			Public Event WizardCancel As CancelEventHandler


		 #End Region

	  #End Region

	  #Region "Protected"

		 #Region "Methods"

			Protected Function GetWizard() As WizardSheet
			   Try
				  If Nothing IsNot m_parentWizard Then
					 Return m_parentWizard
				  Else
					 Throw New ApplicationException ("This page is not included in a WizardSheet.")
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Function

			Protected Overridable Sub SetWizardButtons()
			   Try
				  If Nothing IsNot m_parentWizard Then
					 GetWizard ().SetWizardButtons (GetWizardButtons ())
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

			Protected Overridable Function GetWizardButtons() As WizardSheet.WizardButtons
			   Try
				  Return WizardSheet.WizardButtons.Back Or WizardSheet.WizardButtons.Cancel Or WizardSheet.WizardButtons.Next Or WizardSheet.WizardButtons.About
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

			Private Sub WizardPage_Load(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  SetWizardButtons ()
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

		 #Region "Data Members"

			Private m_parentWizard As WizardSheet
			Private m_previousPage As WizardPage

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

	  #End Region

	  #Region "internal"

		 #Region "Methods"

		 #End Region

		 #Region "Properties"


			Friend Property ParentWizard() As WizardSheet
			   Get
				  Return m_parentWizard
			   End Get

			   Set(ByVal value As WizardSheet)
				  m_parentWizard = value
			   End Set
			End Property

			Friend Property PreviousPage() As WizardPage
			   Get
				  Return m_previousPage
			   End Get

			   Set(ByVal value As WizardPage)
				  m_previousPage = value
			   End Set
			End Property


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
