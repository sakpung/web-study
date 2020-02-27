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
   Friend Class ThreadSafeMessager
	  Private Delegate Sub ShowMessageHandler(ByVal message As String)
	  Private Delegate Function ShowQuestionHandler(ByVal message As String, ByVal buttons As MessageBoxButtons) As DialogResult

     Private Shared privateOwner As Control
	  Public Shared Property Owner() As Control
		  Get
			  Return privateOwner
		  End Get
		  Set(ByVal value As Control)
			  privateOwner = value
		  End Set
	  End Property

	  Public Shared Sub ShowError(ByVal message As String)
		 If Owner.InvokeRequired Then
			Dim showMesage As ShowMessageHandler


			showMesage = New ShowMessageHandler (AddressOf ShowError)

         Owner.Invoke(showMesage, New Object() {message})
		 Else
			Messager.ShowError (Owner, message)
		 End If
	  End Sub

	  Public Shared Sub ShowWarning(ByVal message As String)
		 If Owner.InvokeRequired Then
			Dim showMesage As ShowMessageHandler


			showMesage = New ShowMessageHandler (AddressOf ShowWarning)

         Owner.Invoke(showMesage, New Object() {message})
		 Else
			Messager.ShowWarning (Owner, message)
		 End If
	  End Sub

	  Public Shared Sub ShowInformation(ByVal message As String)
		 If Owner.InvokeRequired Then
			Dim showMesage As ShowMessageHandler


			showMesage = New ShowMessageHandler (AddressOf ShowInformation)

         Owner.Invoke(showMesage, New Object() {message})
		 Else
			Messager.ShowInformation (Owner, message)
		 End If
	  End Sub

	  Public Shared Function ShowQuestion(ByVal message As String, ByVal buttons As MessageBoxButtons) As DialogResult
		 If Owner.InvokeRequired Then
			Dim showMesage As ShowQuestionHandler


			showMesage = New ShowQuestionHandler (AddressOf ShowQuestion)

         Return CType(Owner.Invoke(showMesage, New Object() {message}), DialogResult)
		 Else
			Return Messager.ShowQuestion (Owner, message, buttons)
		 End If
	  End Function
   End Class
End Namespace
