' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Demos.Workstation.Configuration


Namespace Leadtools.Demos.Workstation
   Public Interface IMediaInformationView
	  Sub Initialize(ByVal mediaTypes() As MediaType, ByVal priorities() As RequestPriority)
	  Sub SetPacsServers(ByVal servers() As ScpInfo)
	  Sub ReportMediaCreationFailure(ByVal [error] As String)
	  Sub ReportMediaCreationSuccess()
	  Sub ReportServerVerificationSuccess()
	  Sub ReportServerVerificationFailure(ByVal errorMessage As String)

	  Property MediaTitle() As String

	  Property LabelText() As String

	  Property NumberOfCopies() As Integer

	  Property Prioirty() As RequestPriority

	  Property MediaType() As MediaType

     Property SelectedServer() As ScpInfo

     Property IncludeDisplayApplication() As Boolean

     Property ClearInstancesAfterRequest() As Boolean

     WriteOnly Property CanVerify() As Boolean


	  WriteOnly Property CanSendCreateRequest() As Boolean

	  Event VerifySelectedServer As EventHandler
	  Event SendMediaCreationRequest As EventHandler
     Event ViewLoad As EventHandler
	  Event MediaTitleChanged As EventHandler
	  Event SelectedServerChanged As EventHandler

	  Sub MediaTitleValidationError(ByVal errorText As String)
   End Interface
End Namespace
