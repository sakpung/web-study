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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Demos.Workstation.Configuration

Namespace Leadtools.Demos.Workstation
   Partial Friend Class MediaInformationView
      Inherits UserControl
      Implements IMediaInformationView
	  #Region "Public"

		 #Region "Methods"

			Public Sub New()
			   InitializeComponent ()

            _mediaTitleErrorProv = New ErrorProvider(Me)
            AddHandler Me.Load, AddressOf Me_Load
			End Sub

			Public Sub Initialize(ByVal mediaTypes() As MediaType, ByVal priorities() As RequestPriority) Implements IMediaInformationView.Initialize
			   MediaTypeComboBox.DataSource = mediaTypes
			   PriorityComboBox.DataSource = priorities
            IncludeDisplayApplication = True
			   AddHandler VerifyServerButton.Click, AddressOf VerifyServerButton_Click
			   AddHandler SendMediaRequestButton.Click, AddressOf SendMediaRequestButton_Click
			   AddHandler MediaTitleTextBox.TextChanged, AddressOf MediaTitleTextBox_TextChanged
            AddHandler ServerAEComboBox.SelectionChangeCommitted, AddressOf ServerAEComboBox_SelectionChangeCommitted
			End Sub

			Public Sub SetPacsServers(ByVal servers() As ScpInfo) Implements IMediaInformationView.SetPacsServers
			   ServerAEComboBox.DataSource = servers
			End Sub

			Public Sub ReportMediaCreationFailure(ByVal [error] As String) Implements IMediaInformationView.ReportMediaCreationFailure
			   ThreadSafeMessager.ShowError ([error])
			End Sub

			Public Sub ReportMediaCreationSuccess() Implements IMediaInformationView.ReportMediaCreationSuccess
			   ThreadSafeMessager.ShowInformation ("Media request sent successfully.")
			End Sub

			Public Sub ReportServerVerificationSuccess() Implements IMediaInformationView.ReportServerVerificationSuccess
			   ThreadSafeMessager.ShowInformation ("Connection succeeded")
			End Sub
			Public Sub ReportServerVerificationFailure(ByVal errorMessage As String) Implements IMediaInformationView.ReportServerVerificationFailure
			   ThreadSafeMessager.ShowWarning (errorMessage)
			End Sub

			Public Sub MediaTitleValidationError(ByVal errorText As String) Implements IMediaInformationView.MediaTitleValidationError
			   _mediaTitleErrorProv.SetError (MediaTitleTextBox, errorText)
			End Sub


		 #End Region

		 #Region "Properties"

			Public Property MediaTitle() As String Implements IMediaInformationView.MediaTitle
			   Get
				  Return MediaTitleTextBox.Text
			   End Get

			   Set(ByVal value As String)
				  MediaTitleTextBox.Text = value
			   End Set
			End Property

			Public Property LabelText() As String Implements IMediaInformationView.LabelText
			   Get
				  Return LabelTextTextBox.Text
			   End Get

			   Set(ByVal value As String)
				  LabelTextTextBox.Text = value
			   End Set
			End Property

			Public Property NumberOfCopies() As Integer Implements IMediaInformationView.NumberOfCopies
			   Get
				  Return CInt(Fix(NumberOfCopiesNumericUpDown.Value))
			   End Get

			   Set(ByVal value As Integer)
				  NumberOfCopiesNumericUpDown.Value = value
			   End Set
			End Property

			Public Property Prioirty() As RequestPriority Implements IMediaInformationView.Prioirty
			   Get
				  If Nothing Is PriorityComboBox.SelectedItem Then
					 Return RequestPriority.Undefined
				  End If

				  Return CType(PriorityComboBox.SelectedItem, RequestPriority)
			   End Get

			   Set(ByVal value As RequestPriority)
				  PriorityComboBox.SelectedItem = value
			   End Set
			End Property

			Public Property MediaType() As MediaType Implements IMediaInformationView.MediaType
			   Get
				  If Nothing Is MediaTypeComboBox.SelectedItem Then
					 Return MediaType.Default
				  End If

				  Return CType(MediaTypeComboBox.SelectedItem, MediaType)
			   End Get

			   Set(ByVal value As MediaType)
				  MediaTypeComboBox.SelectedItem = value
			   End Set
			End Property

			Public Property SelectedServer() As ScpInfo Implements IMediaInformationView.SelectedServer
			   Get
				  Return TryCast(ServerAEComboBox.SelectedItem, ScpInfo)
			   End Get

			   Set(ByVal value As ScpInfo)
				  ServerAEComboBox.SelectedItem = value
			   End Set
			End Property

         Public Property IncludeDisplayApplication() As Boolean Implements IMediaInformationView.IncludeDisplayApplication
            Get
              Return IncludeDisplayApplicationCheckBox.Checked
            End Get

            Set(ByVal value As Boolean)
              IncludeDisplayApplicationCheckBox.Checked = value
            End Set
         End Property

         Public Property ClearInstancesAfterRequest() As Boolean Implements IMediaInformationView.ClearInstancesAfterRequest
            Get
              Return ClearDicomInstancesCheckBox.Checked
            End Get

            Set(ByVal value As Boolean)
              ClearDicomInstancesCheckBox.Checked = value
            End Set
         End Property

			Public WriteOnly Property CanVerify() As Boolean Implements IMediaInformationView.CanVerify
			   Set(ByVal value As Boolean)
				  VerifyServerButton.Enabled = value
			   End Set
			End Property

			Public WriteOnly Property CanSendCreateRequest() As Boolean Implements IMediaInformationView.CanSendCreateRequest
			   Set(ByVal value As Boolean)
				  SendMediaRequestButton.Enabled = value
			   End Set
			End Property

		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

		 #Region "Callbacks"

			Public Event VerifySelectedServer As EventHandler Implements IMediaInformationView.VerifySelectedServer
			Public Event SendMediaCreationRequest As EventHandler Implements IMediaInformationView.SendMediaCreationRequest
			Public Event MediaTitleChanged As EventHandler Implements IMediaInformationView.MediaTitleChanged
			Public Event SelectedServerChanged As EventHandler Implements IMediaInformationView.SelectedServerChanged
         Public Event ViewLoad As EventHandler Implements IMediaInformationView.ViewLoad
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

			Private Sub OnVerifySelectedServer()
			   If Nothing IsNot VerifySelectedServerEvent Then
				  RaiseEvent VerifySelectedServer(Me, EventArgs.Empty)
			   End If
			End Sub

			Private Sub OnSendMediaCreationRequest()
			   If Nothing IsNot SendMediaCreationRequestEvent Then
				  RaiseEvent SendMediaCreationRequest(Me, EventArgs.Empty)
			   End If
			End Sub

		 #End Region

		 #Region "Properties"

		 #End Region

		 #Region "Events"

			Private Sub ServerAEComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  If Nothing IsNot SelectedServerChangedEvent Then
					 RaiseEvent SelectedServerChanged(Me, e)
				  End If
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   End Try
			End Sub

			Private Sub SendMediaRequestButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  Me.Cursor = Cursors.WaitCursor

				  OnSendMediaCreationRequest ()
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   Finally
				  Me.Cursor = Cursors.Default
			   End Try
			End Sub

			Private Sub VerifyServerButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  Me.Cursor = Cursors.WaitCursor

				  OnVerifySelectedServer ()
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   Finally
				  Me.Cursor = Cursors.Default
			   End Try
			End Sub

			Private Sub MediaTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  _mediaTitleErrorProv.SetError (MediaTitleTextBox, Nothing)

				  If Nothing IsNot MediaTitleChangedEvent Then
					 RaiseEvent MediaTitleChanged(Me, e)
				  End If
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   End Try
         End Sub

         Private Sub Me_Load(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If Nothing IsNot ViewLoadEvent Then
              RaiseEvent ViewLoad(sender, e)
            End If
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

		 #End Region

		 #Region "Data Members"

			Private _mediaTitleErrorProv As ErrorProvider

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
