' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Winforms
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ServerInformationView : Inherits UserControl
      Public Sub New()
         InitializeComponent()

            SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        End Sub

      Public Property ServerDisplayName() As String
         Get
            Return ServiceDisplayNameLabel.Text
         End Get

         Set(ByVal value As String)
            ServiceDisplayNameLabel.Text = value
         End Set
      End Property

      Public Property ServerAE() As String
         Get
            Return AETitleLabel.Text
         End Get
         Set(ByVal value As String)
            AETitleLabel.Text = value
         End Set
      End Property

      Public Property IpAddress() As String
         Get
            Return IpAddressLabel.Text
         End Get
         Set(ByVal value As String)
            IpAddressLabel.Text = value
         End Set
      End Property

        Public Property Port() As String
            Get
                Return PortLabel.Text
            End Get
            Set(ByVal value As String)
                PortLabel.Text = value
            End Set
        End Property

        Private _isSecure As Boolean = False

        Public Property IsSecure() As Boolean
            Get
                Return _isSecure
            End Get
            Set(ByVal value As Boolean)
                _isSecure = value
                pictureBoxSecure1.Visible = _isSecure
            End Set
        End Property


        Public Property IsServerRunning() As Boolean
         Get
            Return _isServerRunning
         End Get

         Set(ByVal value As Boolean)
            If value <> _isServerRunning Then
               _isServerRunning = value

               ServerStatusPictureBox.Image = GetStatusImage()
               buttonStart.Enabled = Not _isServerRunning
               buttonStop.Enabled = _isServerRunning
            End If
         End Set
      End Property

      Public WriteOnly Property Status() As String
         Set(ByVal value As String)
            If value = "Running" Then
               labelStatus.ForeColor = Color.Green
            Else
               labelStatus.ForeColor = Color.Red
            End If

            labelStatus.Text = value
         End Set
      End Property

      Public Property CanChangeSettings() As Boolean
         Get
            Return buttonSettings.Enabled
         End Get
         Set(ByVal value As Boolean)
            buttonSettings.Enabled = value
         End Set
      End Property

      Public Event StartService As EventHandler
      Public Event StopService As EventHandler

      Private Function GetStatusImage() As Image
         If IsServerRunning Then
            toolTip.SetToolTip(ServerStatusPictureBox, "Server is running")
            Return Global.My.Resources._1313684564_Symbol_Check
         Else
            toolTip.SetToolTip(ServerStatusPictureBox, "Server is stopped")
            Return Global.My.Resources._1313685426_Symbol_Error
         End If
      End Function


      Private _isServerRunning As Boolean


      Public Property CanStartStopServer() As Boolean
         Get
            Return buttonStop.Enabled
         End Get

         Set(ByVal value As Boolean)
            buttonStop.Enabled = value
            'buttonStart.Enabled = !value && !_isServerRunning;
         End Set
      End Property

      Private Sub buttonSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonSettings.Click
         EventBroker.Instance.PublishEvent(Of DisplayFeatureEventArgs)(Me, New DisplayFeatureEventArgs(FeatureNames.DisplaySettingsFeature))
      End Sub

      Private Sub buttonAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAbout.Click
         ShowAbout()
      End Sub

      Private Sub buttonExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonExit.Click
         Application.Exit()
      End Sub

      Private Sub buttonStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonStart.Click
         Try
            If (Not IsServerRunning) AndAlso (Not Nothing Is StartServiceEvent) Then
               buttonStart.Enabled = False
               RaiseEvent StartService(Me, EventArgs.Empty)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub buttonStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonStop.Click
         Try
            If IsServerRunning AndAlso (Not Nothing Is StopServiceEvent) Then
               buttonStop.Enabled = False
               RaiseEvent StopService(Me, EventArgs.Empty)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub
   End Class
End Namespace
