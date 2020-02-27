' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Ccow

Namespace CCOWClientParticipationDemo.CCOW
	Public Class AuthenticationRepository
		Private _AuthRepository As IAuthenticationRepository

		Private _KeyContainer As KeyContainer = Nothing

		Public ReadOnly Property KeyContainer() As KeyContainer
			Get
				Return _KeyContainer
			End Get
		End Property

		Public Sub New(ByVal ApplicationName As String)
			_AuthRepository = Utils.COMCreateObject(Of IAuthenticationRepository)("CCOW.AuthenticationRepository")
			_KeyContainer = New KeyContainer(ApplicationName)
		End Sub
	End Class
End Namespace
