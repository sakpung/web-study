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
Imports System.Linq
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.UI.Commands
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.DicomDemos
Imports System.IO
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Workstation.DataAccessLayer.Configuration
Imports System.Net
Imports Leadtools.Dicom


Namespace Leadtools.Demos.Workstation
   Partial Public Class MainForm
	   Inherits Form
	  Public Sub New()
		 InitializeComponent ()
	  End Sub

      Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
         MyBase.OnLoad(e)
         Me.Activate()
      End Sub
	  Public Overrides Function InitializeLifetimeService() As Object
		 Return Nothing
	  End Function

	  Public ReadOnly Property WorkStationContainerControl() As WorkStationContainer
		 Get
			Return workStationContainerControl_Renamed
		 End Get
	  End Property
   End Class
End Namespace
