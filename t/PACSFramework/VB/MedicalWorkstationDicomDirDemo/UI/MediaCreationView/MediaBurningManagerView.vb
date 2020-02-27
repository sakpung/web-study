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

Namespace Leadtools.Demos.Workstation
   Partial Public Class MediaBurningManagerView
	   Inherits Form
	  Public Sub New()
		 InitializeComponent()

		 AddHandler CloseButton.Click, AddressOf CloseViewButton_Click
	  End Sub

	  Private Sub CloseViewButton_Click(ByVal sender As Object, ByVal e As EventArgs)
		 OnCloseViewRequested ()
	  End Sub

	  Public Event CloseViewRequested As EventHandler

	  Public ReadOnly Property MediaInformationView() As IMediaInformationView
		 Get
			Return MediaInformationControl
		 End Get
	  End Property

	  Public ReadOnly Property DicomInstancesSelectionView() As IDicomInstancesSelectionView
		 Get
			Return DicomInstancesSelectionControl
		 End Get
	  End Property

	  Private Sub OnCloseViewRequested()
		 If Nothing IsNot CloseViewRequestedEvent Then
			RaiseEvent CloseViewRequested(Me, EventArgs.Empty)
		 End If
	  End Sub
   End Class
End Namespace
