' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Runtime.InteropServices

Imports Leadtools
Imports System

Friend NotInheritable Class Support
   <Flags()>
   Public Enum MessageBoxOptions As UInteger
      OkOnly = &H0
      IconHand = &H10
   End Enum

   <DllImport("user32.dll", EntryPoint:="MessageBoxW", SetLastError:=True, CharSet:=CharSet.Unicode)>
   Shared Function MessageBox(hwnd As IntPtr,
      <MarshalAs(UnmanagedType.LPTStr)> lpText As String,
      <MarshalAs(UnmanagedType.LPTStr)> lpCaption As String,
      <MarshalAs(UnmanagedType.U4)> uType As MessageBoxOptions) As <MarshalAs(UnmanagedType.U4)> UInteger
   End Function

   Private Sub New()
   End Sub
   Public Const MedicalServerKey As String = ""

    Public Shared Function SetLicense(ByVal silent As Boolean) As Boolean
        Try
            ' TODO: Change this to use your license file and developer key */
            Dim licenseFilePath As String = "Replace this with the path to the LEADTOOLS license file"
            Dim developerKey As String = "Replace this with your developer key"
            RasterSupport.SetLicense(licenseFilePath, developerKey)
        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message)
        End Try

        If RasterSupport.KernelExpired Then
            Dim dirs() As String = {System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), System.IO.Path.GetDirectoryName(New Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath)}

            Dim licenseFileRelativePath As String = Nothing
            Dim keyFileRelativePath As String = Nothing

            For Each dir As String In dirs
                ' Try the common LIC directory 
                licenseFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\Support\Common\License\LEADTOOLS.LIC")
                keyFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\Support\Common\License\LEADTOOLS.LIC.key")

                If (Not System.IO.File.Exists(licenseFileRelativePath)) Then
                    licenseFileRelativePath = System.IO.Path.Combine(dir, "..\..\Support\Common\License\LEADTOOLS.LIC")
                    keyFileRelativePath = System.IO.Path.Combine(dir, "..\..\Support\Common\License\LEADTOOLS.LIC.key")
                End If

                If (Not System.IO.File.Exists(licenseFileRelativePath)) Then
                    licenseFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\..\Support\Common\License\LEADTOOLS.LIC")
                    keyFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\..\Support\Common\License\LEADTOOLS.LIC.key")
                End If

                If (Not System.IO.File.Exists(licenseFileRelativePath)) Then
                    licenseFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\..\..\Support\Common\License\LEADTOOLS.LIC")
                    keyFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\..\..\Support\Common\License\LEADTOOLS.LIC.key")
                End If

                If (Not System.IO.File.Exists(licenseFileRelativePath)) Then
                    licenseFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\..\..\..\Support\Common\License\LEADTOOLS.LIC")
                    keyFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\..\..\..\Support\Common\License\LEADTOOLS.LIC.key")
                End If

                If (Not System.IO.File.Exists(licenseFileRelativePath)) Then
                    licenseFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\Support\Common\License\LEADTOOLS.LIC")
                    keyFileRelativePath = System.IO.Path.Combine(dir, "..\..\..\..\Support\Common\License\LEADTOOLS.LIC.key")
                End If

                If System.IO.File.Exists(licenseFileRelativePath) AndAlso System.IO.File.Exists(keyFileRelativePath) Then
                    Exit For
                End If
            Next dir

            If System.IO.File.Exists(licenseFileRelativePath) AndAlso System.IO.File.Exists(keyFileRelativePath) Then
                Dim developerKey As String = System.IO.File.ReadAllText(keyFileRelativePath)
                Try
                    RasterSupport.SetLicense(licenseFileRelativePath, developerKey)
                Catch ex As Exception
                    System.Diagnostics.Debug.Write(ex.Message)
                End Try
            End If
        End If

        If RasterSupport.KernelExpired Then
            If silent = False Then
                Dim msg As String = "Your license file is missing, invalid or expired. LEADTOOLS will not function. Please contact LEAD Sales for information on obtaining a valid license."
                Dim logmsg As String = String.Format("*** NOTE: {0} ***{1}", msg, Environment.NewLine)
                System.Diagnostics.Debugger.Log(0, Nothing, "*******************************************************************************" & Environment.NewLine)
                System.Diagnostics.Debugger.Log(0, Nothing, logmsg)
                System.Diagnostics.Debugger.Log(0, Nothing, "*******************************************************************************" & Environment.NewLine)

                Try
                    MessageBox(IntPtr.Zero, msg, "No LEADTOOLS License", CType(MessageBoxOptions.OkOnly + MessageBoxOptions.IconHand, MessageBoxOptions))
                Catch
                End Try

                System.Diagnostics.Process.Start("https://www.leadtools.com/downloads/evaluation-form.asp?evallicenseonly=true")
            End If

            Return False
        End If
        Return True
    End Function

    Public Shared Function SetLicense() As Boolean
      Return SetLicense(False)
   End Function

End Class
