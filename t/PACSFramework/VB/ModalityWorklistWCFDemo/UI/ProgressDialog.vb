' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Namespace ModalityWorklistWCFDemo.UI
	Partial Public Class ProgressDialog
		Inherits Form
		Private _ActionThread As Thread = Nothing

		Public Property Title() As String
			Get
				Return Text
			End Get
			Set(ByVal value As String)
				Text = value
			End Set
		End Property

		Public Property Description() As String
			Get
				Return labelProgressInfo.Text
			End Get
			Set(ByVal value As String)
				labelProgressInfo.Text = value
			End Set
		End Property

		Public Property Style() As ProgressBarStyle
			Get
				Return progressBar.Style
			End Get
			Set(ByVal value As ProgressBarStyle)
				progressBar.Style = Style
			End Set
		End Property

		Public Property Progress() As Integer
			Get
				Return progressBar.Value
			End Get
			Set(ByVal value As Integer)
				progressBar.Value = Progress
			End Set
		End Property

		Private _Action As Action = Nothing

		Public Property Action() As Action
			Get
				Return _Action
			End Get
			Set(ByVal value As Action)
				_Action = value
			End Set
		End Property

		Public Property CanCancel() As Boolean
			Get
				Return buttonCancel.Enabled
			End Get
			Set(ByVal value As Boolean)
				buttonCancel.Enabled = False
			End Set
		End Property

		Private _Exception As Exception

		Public ReadOnly Property Exception() As Exception
			Get
				Return _Exception
			End Get
		End Property

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ProgressDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			If _Action IsNot Nothing Then
				_ActionThread = New Thread(AddressOf AnonymousMethod1)
				_ActionThread.Start()
			End If
		End Sub
      Private Delegate Sub SetResultDelegate(ByVal result As DialogResult)

      Private Sub AnonymousMethod1()
         Try
            _Action()
            SetResult(DialogResult.OK)
            Return
         Catch e1 As ThreadAbortException
         Catch exception As Exception
            _Exception = exception
         End Try
         SetResult(DialogResult.Cancel)
      End Sub

      Private Sub SetResult(ByVal result As DialogResult)
         If InvokeRequired Then
            Me.Invoke(New SetResultDelegate(AddressOf SetResult), DialogResult.OK)
         Else
            DialogResult = result
         End If
      End Sub

      Private Sub buttonCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCancel.Click
         If _ActionThread IsNot Nothing Then
            _ActionThread.Abort()
         End If
         Close()
      End Sub
   End Class
End Namespace
