' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Namespace DicomDemo
	Public Class MyListView : Inherits ListView
		Private _StartedMPPS As List(Of ListViewItem) = New List(Of ListViewItem)()

		Public Property StartedMPPS() As List(Of ListViewItem)
			Get
				Return _StartedMPPS
			End Get
			Set
				_StartedMPPS = Value
			End Set
		End Property
	End Class
End Namespace
