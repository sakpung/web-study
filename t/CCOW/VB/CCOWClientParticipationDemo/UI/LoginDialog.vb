' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System
Imports System.Windows.Forms
Imports Leadtools.Demos

Namespace CCOWClientParticipationDemo.UI
	Public Partial Class LoginDialog : Inherits Form
		Private _CCOWApplication As CCOWApplication

		Public Property EnableUser() As Boolean
			Get
				Return comboBoxUsername.Enabled
			End Get
			Set
				comboBoxUsername.Enabled = Value
			End Set
		End Property

		Private _Username As String = String.Empty

		Public Property Username() As String
			Get
				Return comboBoxUsername.Text
			End Get
			Set
				_Username = Value
			End Set
		End Property

		Public Property Password() As String
			Get
				Return textBoxPassword.Text
			End Get
			Set
				textBoxPassword.Text = Value
			End Set
		End Property

		Public Property FirstLogin() As Boolean
			Get
				Return labelFirstLogin.Visible
			End Get
			Set
				labelFirstLogin.Visible = Value
			End Set
		End Property

		Public Sub New(ByVal application As CCOWApplication)
			InitializeComponent()
			_CCOWApplication = application
		End Sub

		Private Sub LoginDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			LoadUsers()
		End Sub

		Private Sub LoadUsers()
			For Each user As User In _CCOWApplication.Users
				Dim index As Integer = comboBoxUsername.Items.Add(user)

				If user.Username = _Username Then
					comboBoxUsername.SelectedIndex = index
				End If
			Next user
		End Sub

		Private Sub LoginDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If DialogResult = System.Windows.Forms.DialogResult.OK Then
				e.Cancel = Not Authenticate()
				If e.Cancel Then
					MessageBox.Show("Invalid password for user.", "Authorization Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			End If
		End Sub

		Private Function Authenticate() As Boolean
			For Each user As User In _CCOWApplication.Users
				If user.Username = comboBoxUsername.Text AndAlso user.Password = textBoxPassword.Text Then
					Return True
				End If
			Next user
			Return False
		End Function

		Private Sub comboBoxUsername_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxUsername.SelectedIndexChanged
			Dim user As User = TryCast(comboBoxUsername.SelectedItem, User)

			If (Not user.DomainLogin) Then
				textBoxPassword.ReadOnly = True
				textBoxPassword.Text = user.Password
			Else
				textBoxPassword.ReadOnly = False
				textBoxPassword.Text = String.Empty
			End If
		End Sub
	End Class
End Namespace
