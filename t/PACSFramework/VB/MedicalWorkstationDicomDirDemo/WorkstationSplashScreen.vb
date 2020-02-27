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
Imports System.IO

Namespace Leadtools.Demos.Workstation
   Partial Public Class WorkstationSplashScreen
	   Inherits Form
	  Public Sub New()
		 InitializeComponent()

		 BackgroundImage = GetSplashScreenImage ()
	  End Sub

	  Private Function GetSplashScreenImage() As Image
		 Dim splashScreenPath As String = Application.StartupPath


		 splashScreenPath = Path.Combine (splashScreenPath, "splash.png")

		 If File.Exists (splashScreenPath) Then
			Try
			   Return Image.FromFile (splashScreenPath)
			Catch e1 As Exception
               Return Resources.SplashScreen_MedWorkViewer
         End Try
       Else
            Return Resources.SplashScreen_MedWorkViewer
		 End If
	  End Function
   End Class
End Namespace
