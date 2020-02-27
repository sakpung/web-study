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
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Namespace Leadtools.Demos
	Public Partial Class ProgressInfoDialog : Inherits Form
		Private _Thread As Thread
		Private _Owner As IWin32Window
        Private _Exception As Exception
        Private _Action As MethodInvoker

		Public Property Title() As String
			Get
				Return Text
			End Get
			Set
				Text = Value
			End Set
		End Property

		Public Property Description() As String
			Get
				Return labelDescription.Text
			End Get
			Set
				labelDescription.Text = Value
			End Set
		End Property

		Public ReadOnly Property Exception() As Exception
			Get
				Return _Exception
			End Get
		End Property

		Public Sub New(ByVal owner As IWin32Window)
			InitializeComponent()
			_Owner = owner
		End Sub

		Private Sub InfoDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			If Not _Thread Is Nothing Then
                _Thread.Start(_Action)
			End If
		End Sub

        Public Sub Process(ByVal action As Object)
            Try
                Dim a As MethodInvoker = CType(action, MethodInvoker)

                a()
                DialogResult = System.Windows.Forms.DialogResult.OK
            Catch e1 As ThreadAbortException
            Catch e As Exception
                _Exception = e
                DialogResult = DialogResult.Cancel
            End Try
        End Sub
        Public Overloads Function ShowDialog(ByVal action As MethodInvoker) As DialogResult
            _Thread = New Thread(AddressOf Process)
            _Action = action
            Return ShowDialog(_Owner)
        End Function

		Private Sub InfoDialog_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
			'if (_Exception != null && !_Exception.Message.Contains("The RPC server is unavailable"))
			'{
			'    throw _Exception;
			'}
		End Sub

		Private Sub buttonCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCancel.Click
			If Not _Thread Is Nothing Then
				_Thread.Abort()
				_Thread.Join()
				DialogResult = DialogResult.Cancel
			End If
		End Sub
	End Class
End Namespace
