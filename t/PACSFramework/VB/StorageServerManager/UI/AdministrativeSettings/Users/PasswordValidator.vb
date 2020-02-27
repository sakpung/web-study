' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.StorageServer.DataTypes.Options
Imports System.Text.RegularExpressions

Namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
   Public Class PasswordValidator
      Private Sub New()
      End Sub
      Public Shared Function Validate(ByVal password As String, ByVal confirmation As String, ByVal options As PasswordOptions, <System.Runtime.InteropServices.Out()> ByRef validationMessage As String) As Boolean
         validationMessage = String.Empty

         If password.Length = 0 Then
            validationMessage = "Password cannot be empty."
            Return False
         End If

         If password <> confirmation Then
            validationMessage = "Password and confirm password do not match."
            Return False
         End If

         If options.MinimumLength <> 0 Then
            If password.Length < options.MinimumLength Then
               validationMessage = String.Format("Password must be at least {0} long.", options.MinimumLength)
               Return False
            End If
         End If

         If (options.Complexity And Complexity.Lowercase) = Complexity.Lowercase Then
            If (Not Regex.IsMatch(password, "[a-z]")) Then
               validationMessage = String.Format("Password must must have at least one lower case letter.", options.MinimumLength)
               Return False
            End If
         End If

         If (options.Complexity And Complexity.Uppercase) = Complexity.Uppercase Then
            If (Not Regex.IsMatch(password, "[A-Z]")) Then
               validationMessage = String.Format("Password must must have at least one upper case letter.", options.MinimumLength)
               Return False
            End If
         End If

         If (options.Complexity And Complexity.Numbers) = Complexity.Numbers Then
            If (Not Regex.IsMatch(password, "[0-9]")) Then
               validationMessage = String.Format("Password must must have at least one number.", options.MinimumLength)
               Return False
            End If
         End If

         If (options.Complexity And Complexity.Symbol) = Complexity.Symbol Then
            If (Not Regex.IsMatch(password, "[@#$%^&+=]")) Then
               validationMessage = String.Format("Password must must have at least one symbol.", options.MinimumLength)
               Return False
            End If
         End If

         Return True
      End Function
   End Class
End Namespace
