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

Namespace DicomDemo
   Partial Class ProgressDialog : Inherits Form
      Public Property Title() As String
         Get
            Return Text
         End Get
         Set(ByVal value As String)
            Text = Value
         End Set
      End Property

      Public Property ProgressInfo() As String
         Get
            Return ProgressInfoLabel.Text
         End Get
         Set(ByVal value As String)
            ProgressInfoLabel.Text = Value
         End Set
      End Property

      Private _Marquee As Boolean = True

      Public Property Marquee() As Boolean
         Get
            Return _Marquee
         End Get
         Set(ByVal value As Boolean)
            _Marquee = Value
         End Set
      End Property

      Private _ActionThread As Thread

      Public Property ActionThread() As Thread
         Get
            Return _ActionThread
         End Get
         Set(ByVal value As Thread)
            _ActionThread = Value
         End Set
      End Property

      Private _Cancel As Action

      Public Property Cancel() As Action
         Get
            Return _Cancel
         End Get
         Set(ByVal value As Action)
            _Cancel = Value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub ProgressDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         If _Marquee Then
            progressBar.MarqueeAnimationSpeed = 30
            progressBar.Style = ProgressBarStyle.Marquee
         End If

         Dim dialogThread As Thread = New Thread(AddressOf ProgressDlgThread)
         dialogThread.Start()
      End Sub

      Private Sub ProgressDlgThread()
         _ActionThread.Start()
         Do While _ActionThread.IsAlive
            Thread.Sleep(0)
         Loop
         SynchronizedInvoke(AddressOf ProgressDlgResult)
      End Sub

      Private Sub ProgressDlgResult()
         DialogResult = DialogResult.OK
      End Sub
      Private Sub SynchronizedInvoke(ByVal del As MethodInvoker)
         If InvokeRequired Then
            BeginInvoke(del, Nothing)
         Else
            del()
         End If
      End Sub

      Private Sub ProgressDialog_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
         CancelOperationButton.Enabled = Not Cancel Is Nothing
      End Sub

      Private Sub CancelOperationButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelOperationButton.Click
         If Not Cancel Is Nothing Then
            _Cancel()
         End If
      End Sub
   End Class
End Namespace
