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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Leadtools.Demos.Workstation.Configuration

Namespace Leadtools.Demos.Workstation
   Partial Public Class ImagesDownloadDialog
	   Inherits Form
	  Public Sub New()
		 InitializeComponent()

		 Me.Text = ConfigurationData.ApplicationName
	  End Sub

	  Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
		 Process.Start ("ftp://ftp.leadtools.com/pub/3d/")
	  End Sub
   End Class
End Namespace
