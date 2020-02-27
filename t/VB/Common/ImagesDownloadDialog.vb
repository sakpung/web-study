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
Imports System.Diagnostics
Imports System.Configuration

Namespace Leadtools.Demos
   Public Partial Class ImagesDownloadDialog : Inherits Form
        Private _showCheckBox As Boolean
        Public Sub New(ByVal appName As String)
            InitializeComponent()

            Me.Text = appName
            _chkBoxDontShowThisAgain.Checked = ShowCheckBox
        End Sub

        Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked, linkLabel1.LinkClicked
            Process.Start("ftp://ftp.leadtools.com/pub/3d/")
        End Sub

        Private Sub SetConfigValue(ByVal value As Boolean)
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            config.AppSettings.Settings("ShowDownloadSamplesDialog").Value = value.ToString()
            config.Save(ConfigurationSaveMode.Modified)
        End Sub

        Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click, _btnOK.Click
            SetConfigValue(_chkBoxDontShowThisAgain.Checked)
        End Sub

        Public Property ShowCheckBox() As Boolean
            Get
                Return _showCheckBox
            End Get

            Set(ByVal value As Boolean)
                _showCheckBox = Value
            End Set
        End Property

   End Class
End Namespace
