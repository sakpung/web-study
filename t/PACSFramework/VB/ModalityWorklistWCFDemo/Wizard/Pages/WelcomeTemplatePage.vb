' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Wizard.Pages
	Partial Public Class WelcomeTemplatePage
		Inherits FirstPage
		#Region "Public"

		#Region "Methods"

		Public Sub New()
			Try
				InitializeComponent()
			Catch exception As Exception
				System.Diagnostics.Debug.Assert(False, exception.Message)

				Throw
			End Try
		End Sub

		#End Region

		#Region "Properties"

		Public Shared Property BannerImage() As Image
			Get
				Return _bannerIcon
			End Get

			Set(ByVal value As Image)
				_bannerIcon = value
			End Set
		End Property

		Public Overrides Sub OnSetActive(ByVal sender As Object, ByVal e As WizardCancelEventArgs)
			Try
				MyBase.OnSetActive(sender, e)


				If (Not e.Cancel) Then
					If Nothing Is RightBannerPictureBox.Image Then
						If Nothing IsNot BannerImage Then
							RightBannerPictureBox.Image = BannerImage
						End If
					End If
				End If
			Catch exception As Exception
				System.Diagnostics.Debug.Assert(False, exception.Message)

				Throw
			End Try
		End Sub


		#End Region

		#Region "Events"

		#End Region

		#Region "Data Types Definition"

		#End Region

		#Region "Callbacks"

		#End Region

		#End Region

		#Region "Protected"

		#Region "Methods"

		#End Region

		#Region "Properties"

		#End Region

		#Region "Events"

		#End Region

		#Region "Data Members"

		#End Region

		#Region "Data Types Definition"

		#End Region

		#End Region

		#Region "Private"

		#Region "Methods"

		#End Region

		#Region "Properties"

		#End Region

		#Region "Events"

		#End Region

		#Region "Data Members"

		Public Shared _bannerIcon As Image

		#End Region

		#Region "Data Types Definition"

		#End Region

		#End Region

		#Region "internal"

		#Region "Methods"

		#End Region

		#Region "Properties"

		#End Region

		#Region "Events"

		#End Region

		#Region "Data Types Definition"

		#End Region

		#Region "Callbacks"

		#End Region

		#End Region
	End Class
End Namespace
