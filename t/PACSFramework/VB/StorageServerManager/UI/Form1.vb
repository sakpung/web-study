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
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports Leadtools.Medical.Winforms
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.Winforms.Monitor

Namespace Leadtools.Demos.StorageServer
   Partial Friend Class MainForm : Inherits Form
      Private _About As AboutDialog = Nothing

      Public Sub New()
         InitializeComponent()

         _userWindowState = FormWindowState.Normal

         'ShowInTaskbar    = false ;
         WindowState = _userWindowState
         _lastWindowState = WindowState

         MainNotifyIcon.Icon = Me.Icon
         MainNotifyIcon.Text = Me.Text

         AddHandler MainNotifyIcon.DoubleClick, AddressOf MainNotifyIcon_DoubleClick
         AddHandler showToolStripMenuItem.Click, AddressOf MainNotifyIcon_DoubleClick
         AddHandler aboutToolStripMenuItem.Click, AddressOf aboutToolStripMenuItem_Click
         AddHandler exitToolStripMenuItem.Click, AddressOf exitToolStripMenuItem_Click


         AddHandler WindowStateChanged, AddressOf MainForm_WindowStateChanged

         'this.BackColor = Color.Fuchsia ;
         'TransparencyKey = SystemColors.Control ;
      End Sub

      Private Sub MainForm_WindowStateChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If (Not _localStateChange) Then
               If WindowState <> FormWindowState.Minimized Then
                  _userWindowState = WindowState
               Else
                  EventBroker.Instance.PublishEvent(Of BackgroundProcessEventAgs)(Me, New BackgroundProcessEventAgs(True))
                  Me.Hide()
               End If
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub MainNotifyIcon_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
         Try
            ShowFromTaskBar()
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
         If (keyData And Keys.Alt) <> 0 AndAlso (keyData And Keys.KeyCode) = Keys.X Then
            Application.Exit()
         ElseIf (keyData And Keys.Alt) <> 0 AndAlso (keyData And Keys.KeyCode) = Keys.S Then
            EventBroker.Instance.PublishEvent(Of DisplayFeatureEventArgs)(Me, New DisplayFeatureEventArgs(FeatureNames.DisplaySettingsFeature))
         End If
         Return MyBase.ProcessCmdKey(msg, keyData)
      End Function

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         [Exit]()
      End Sub

      Public Sub [Exit]()
         MainNotifyIcon.Visible = False
         Application.Exit()
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not _About Is Nothing AndAlso (Not _About.IsDisposed) AndAlso _About.Visible Then
            _About.Focus()
         Else
            If (Not _About Is Nothing AndAlso (Not _About.Visible)) OrElse _About Is Nothing Then
               _About = New AboutDialog("Storage Server Manager")
               _About.ShowDialog(Me)
            End If
         End If
      End Sub

      Friend Sub ShowFromTaskBar()
         _localStateChange = True

         Try
            Me.Visible = True

            ShowInTaskbar = True
            If _userWindowState <> FormWindowState.Minimized Then
               WindowState = _userWindowState
            Else
               WindowState = FormWindowState.Maximized
            End If

            Me.Activate()
            EventBroker.Instance.PublishEvent(Of BackgroundProcessEventAgs)(Me, New BackgroundProcessEventAgs(False))
         Finally
            _localStateChange = False
         End Try
      End Sub

      Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
         If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True

            WindowState = FormWindowState.Minimized

            Me.Hide()
         Else
            MainNotifyIcon.Dispose()

            MyBase.OnFormClosing(e)
         End If
      End Sub

      Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
         MyBase.OnSizeChanged(e)

         If WindowState <> _lastWindowState Then
            If Not Nothing Is WindowStateChangedEvent Then
               RaiseEvent WindowStateChanged(Me, e)
            End If
         End If
      End Sub

      'The ControlPaint Class has methods to Lighten and Darken Colors, but they return a Solid Color.
      'The Following 2 methods return a modified color with original Alpha.
      Private Function DarkenColor(ByVal colorIn As Color, ByVal percent As Integer) As Color
         'This method returns Black if you Darken by 100%

         If percent < 0 OrElse percent > 100 Then
            Throw New ArgumentOutOfRangeException("percent")
         End If

         Dim a, r, g, b As Integer

         a = colorIn.A
         r = colorIn.R - CInt((colorIn.R / 100.0F) * percent)
         g = colorIn.G - CInt((colorIn.G / 100.0F) * percent)
         b = colorIn.B - CInt((colorIn.B / 100.0F) * percent)

         Return Color.FromArgb(a, r, g, b)
      End Function

      Private Function LightenColor(ByVal colorIn As Color, ByVal percent As Integer) As Color
         'This method returns White if you lighten by 100%

         If percent < 0 OrElse percent > 100 Then
            Throw New ArgumentOutOfRangeException("percent")
         End If

         Dim a, r, g, b As Integer

         a = colorIn.A
         r = colorIn.R + CInt(((255.0F - colorIn.R) / 100.0F) * percent)
         g = colorIn.G + CInt(((255.0F - colorIn.G) / 100.0F) * percent)
         b = colorIn.B + CInt(((255.0F - colorIn.B) / 100.0F) * percent)

         Return Color.FromArgb(a, r, g, b)
      End Function

      Private Event WindowStateChanged As EventHandler
      Private _userWindowState As FormWindowState
      Private _lastWindowState As FormWindowState
      Private _localStateChange As Boolean = False

      Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
#If (Not DEBUG) Then
         SplashForm.CloseSplash()
#End If
      End Sub
   End Class
End Namespace
