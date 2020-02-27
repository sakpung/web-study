' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace VBDicomDirLinqDemo.Utils
	<Serializable> _
	Public Class LinqQuery
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
		Private privateQuery As String
		Public Property Query() As String
			Get
				Return privateQuery
			End Get
			Set(ByVal value As String)
				privateQuery = value
			End Set
		End Property

		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class
End Namespace
