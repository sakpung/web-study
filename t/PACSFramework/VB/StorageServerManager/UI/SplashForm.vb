' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Namespace Leadtools.Demos.StorageServer
   Partial Friend Class SplashForm : Inherits Form
      Private Shared _splashThread As Thread
      Private Shared _splashForm As SplashForm

      Private Shared _splashBitmap As Image
      Public Shared Property SplashBitmap() As Image
         Get
            Return _splashBitmap
         End Get
         Set(ByVal value As Image)
            _splashBitmap = value
         End Set
      End Property

      Public Property Bitmap() As Image
         Get
            Return pictureBoxBitmap.Image
         End Get
         Set(ByVal value As Image)
            pictureBoxBitmap.Image = value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()

         If _splashThread Is Nothing Then
            ' show the form in a new thread
            _splashThread = New Thread(AddressOf DoShowSplash)
            _splashThread.IsBackground = True
            _splashThread.Start()
         End If
      End Sub

      Public Shared Sub ShowSplash()
         If _splashThread Is Nothing Then
            ' show the form in a new thread
            _splashThread = New Thread(AddressOf DoShowSplash)
            _splashThread.IsBackground = True
            _splashThread.Start()
         End If
      End Sub

      Private Shared Sub DoShowSplash()
         If _splashForm Is Nothing Then
            _splashForm = New SplashForm()
         End If

         _splashForm.Bitmap = SplashBitmap
         ' create a new message pump on this thread (started from ShowSplash)
         Application.Run(_splashForm)
      End Sub

      Public Shared Sub CloseSplash()
         ' need to call on the thread that launched this splash
         If _splashForm.InvokeRequired Then
            _splashForm.Invoke(New MethodInvoker(AddressOf CloseSplash))

         Else
            Application.ExitThread()
         End If
      End Sub

      Private Sub SplashForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
         progressBar.MarqueeAnimationSpeed = 100
      End Sub
   End Class
End Namespace
