' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace CCOWClientParticipationDemo.CCOW
	Public Class ContextEventArgs : Inherits EventArgs
		Private _ContextCoupon As Integer

		Public ReadOnly Property ContextCoupon() As Integer
			Get
				Return _ContextCoupon
			End Get
		End Property

		Private _Reason As String = String.Empty

		Public Property Reason() As String
			Get
				Return _Reason
			End Get
			Set
				_Reason = Value
			End Set
		End Property

		Private _Decision As String = String.Empty

		Public Property Decision() As String
			Get
				Return _Decision
			End Get
			Set
				_Decision = Value
			End Set
		End Property

      Public Sub New(ByVal contextCoupon_Renamed As Integer)
         _ContextCoupon = contextCoupon_Renamed
      End Sub
	End Class
End Namespace
