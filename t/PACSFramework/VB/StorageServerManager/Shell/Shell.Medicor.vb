' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Windows.Forms
Imports System.IO
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Demos.StorageServer.Properties
Imports Leadtools.Logging

Namespace Leadtools.Demos.StorageServer
   Partial Public Class Shell
      <DllImport("mscoree.dll", CharSet:=System.Runtime.InteropServices.CharSet.Unicode)> _
      Shared Function StrongNameSignatureVerificationEx(ByVal wszFilePath As String, ByVal fForceVerification As Boolean, ByRef pfWasVerified As Boolean) As Boolean
      End Function

      Private Sub LoadLicense(ByVal licenseFile As String)
         If ServerState.Instance.License Is Nothing Then
            Dim [assembly] As System.Reflection.Assembly = Nothing
            Dim notForced As Boolean = False
            Dim verified As Boolean = False
            Dim licenseAssembly As String = Path.Combine(Application.StartupPath, "Medicor.Medical.License.Configuration.dll")

            verified = StrongNameSignatureVerificationEx(licenseAssembly, False, notForced)
            If verified Then
               Dim token As Byte() = New Byte() {&H9C, &HF8, &H89, &HF5, &H3E, &HA9, &HB9, &H7}

               If CheckToken(licenseAssembly, token) Then
                  [assembly] = System.Reflection.Assembly.LoadFrom(licenseAssembly)
               End If
            End If

            If Not [assembly] Is Nothing Then
               Dim types As IEnumerable(Of Type) = [assembly].Implements(Of ILicense)()

               If types.Count() > 0 Then
                  Dim license As Object = TryCast(Activator.CreateInstance(types.First(), licenseFile), ILicense)

                  If Not license Is Nothing Then
                     Dim method As MethodInfo = license.GetType().GetMethod("Initialize")

                     If Not method Is Nothing Then
                        method.Invoke(license, Nothing)
                        ServerState.Instance.License = TryCast(license, ILicense)
                     End If
                  End If
               End If
            End If
         Else
            ServerState.Instance.License.Load(licenseFile)
         End If

         If ServerState.Instance.License Is Nothing Then
            Messager.ShowError(Nothing, "License component dll either invalid or not found." & Constants.vbLf & "Application can not continue.")
            _Form.Exit()
            Environment.Exit(0)
         End If
      End Sub

      Private Function CheckToken(ByVal [assembly] As String, ByVal expectedToken As Byte()) As Boolean
         If [assembly] Is Nothing Then
            Throw New ArgumentNullException("assembly")
         End If
         If expectedToken Is Nothing Then
            Throw New ArgumentNullException("expectedToken")
         End If

         Try
            ' Get the public key token of the given assembly
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom([assembly])
            Dim asmToken As Byte() = asm.GetName().GetPublicKeyToken()

            ' Compare it to the given token
            If asmToken.Length <> expectedToken.Length Then
               Return False
            End If

            For i As Integer = 0 To asmToken.Length - 1
               If asmToken(i) <> expectedToken(i) Then
                  Return False
               End If
            Next i

            Return True
         Catch e1 As System.IO.FileNotFoundException
            ' couldn't find the assembly
            Return False
         Catch e2 As BadImageFormatException
            ' the given file couldn't get through the loader
            Return False
         End Try
      End Function

      Private Sub Start(ByVal form As MainForm)
         form.Icon = Resources.MainApp
         form.Text = "Medicor Storage Server Manager"
         form.MainNotifyIcon.Icon = form.Icon

         Try
            Application.Run(form)
         Finally
            Logger.Global.Dispose()
         End Try
      End Sub
   End Class
End Namespace
