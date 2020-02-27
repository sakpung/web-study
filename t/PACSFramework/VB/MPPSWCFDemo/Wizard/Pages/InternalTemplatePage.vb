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

Namespace Leadtools.Wizard.Pages
   Partial Public Class InternalTemplatePage
	   Inherits InternalPage
	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Public Shared Property BannerIcon() As Image
		 Get
			Return _bannerIcon
		 End Get

		 Set(ByVal value As Image)
			_bannerIcon = value
		 End Set
	  End Property

	  Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
		 Try
			MyBase.OnSetActive (sender, e)

			If (Not e.Cancel) Then
			   If Nothing Is IconPictureBox.Image Then
				  If Nothing IsNot BannerIcon Then
					 IconPictureBox.Image = BannerIcon
				  End If
			   End If
			End If
		 Catch exception As Exception
			System.Diagnostics.Debug.Assert (False, exception.Message)

			Throw
		 End Try
	  End Sub

	  Public Shared _bannerIcon As Image
   End Class
End Namespace

