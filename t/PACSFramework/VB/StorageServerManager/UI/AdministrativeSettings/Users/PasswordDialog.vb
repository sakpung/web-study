' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Security
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class PasswordDialog : Inherits Form
      Public Event ValidatePassword As EventHandler(Of ValidatePasswordEventArgs)

      Public Sub New()
         InitializeComponent()

         AddHandler OKButton.Click, AddressOf okButton_Click
      End Sub

      Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Dim ea As ValidatePasswordEventArgs = New ValidatePasswordEventArgs()

            _password = Nothing
            ea.Password = passwordTextBox.Text
            ea.ConfirmPassword = ConfirmPasswordTextBox.Text
            RaiseEvent ValidatePassword(Me, ea)

            If ea.Valid Then
               _password = Extensions.ToSecureString(passwordTextBox.Text)

               passwordTextBox.Text = String.Empty
               ConfirmPasswordTextBox.Text = String.Empty
            Else
               DialogResult = DialogResult.None
            End If
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Public ReadOnly Property Password() As SecureString
         Get
            Return GetUserPassword()
         End Get
      End Property

      Protected Overridable Function GetUserPassword() As SecureString
         Return _password
      End Function

      Private _password As SecureString
   End Class
End Namespace
