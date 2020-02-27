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
Imports System.Net
Imports Leadtools.Dicom.Scu
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports Leadtools.Medical.UserManagementDataAccessLayer


Namespace Leadtools.Demos.Workstation
   Partial Public Class WorkstationConfiguration
	   Inherits UserControl
	  #Region "Public"

		 #Region "Methods"

			Public Sub New()
			   Try
				  InitializeComponent ()

				  Init ()
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw exception
			   End Try
			End Sub

		 #End Region

		 #Region "Properties"

			Public Property CanViewPACSConfig() As Boolean
			   Get
				  Return _canViewPACSConfig
			   End Get

			   Set(ByVal value As Boolean)
				  If value <> _canViewPACSConfig Then
					 _canViewPACSConfig = value

					 PACSToolStripButton.Enabled = value

					 If value = False AndAlso Me.Handle <> IntPtr.Zero AndAlso ControlsAreaPanel.Controls.Contains (_servers) Then
						WorkstationClientToolStripButton.PerformClick ()
					 End If
				  End If
			   End Set
			End Property

			Public Property CanEditWorkstationClientInfo() As Boolean
			   Get
				  Return _client.CanChangeClientInfo
			   End Get

			   Set(ByVal value As Boolean)
				  _client.CanChangeClientInfo = value
			   End Set
			End Property

			Public Property CanChangeForceClientInfo() As Boolean
			   Get
				  Return _client.CanChangeForceClientInfo
			   End Get

			   Set(ByVal value As Boolean)
				  _client.CanChangeForceClientInfo = value
			   End Set
			End Property

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

			Private Sub Init()
			   Try
				  _client = New ClientConfiguration ()
				  _servers = New DICOMServers ()
				  CanViewPACSConfig = True

				  ConfigurationTabControl.TabPages (0).Controls.Add (_client)
				  ConfigurationTabControl.TabPages (1).Controls.Add (_servers)

				  _client.Dock = DockStyle.Fill
				  _servers.Dock = DockStyle.Fill

				  WorkstationToolStrip.CausesValidation = True

				  AddHandler Load, AddressOf WorkstationConfiguration_Load
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw exception
			   End Try
			End Sub

			Private Sub RegisterEvents()
			   Try
				  AddHandler WorkstationClientToolStripButton.Click, AddressOf btnWorkstationClient_Click
				  AddHandler PACSToolStripButton.Click, AddressOf btnPACS_Click
				  AddHandler SaveChangesButton.Click, AddressOf btnSaveChanges_Click

				  AddHandler ConfigurationData.ValueChanged, AddressOf Control_ValueChanged

			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw exception
			   End Try
			End Sub

			Private Sub Control_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			   SaveChangesButton.Enabled = True
			End Sub

			Private Sub WorkstationConfiguration_Load(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  SaveChangesButton.Enabled = False

				  RegisterEvents ()

				  WorkstationClientToolStripButton.PerformClick ()
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   End Try
			End Sub

			Private Sub btnSaveChanges_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  SaveChanges ()
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   End Try
			End Sub

			Private Sub btnWorkstationClient_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  If Me.Validate () Then
					 ControlsAreaPanel.Controls.Clear ()

					 ControlsAreaPanel.Controls.Add (_client)
				  End If
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   End Try
			End Sub

			Private Sub btnPACS_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  If Me.Validate () Then
					 ControlsAreaPanel.Controls.Clear ()

					 ControlsAreaPanel.Controls.Add (_servers)
				  End If
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   End Try
			End Sub

			Private Sub SaveChanges()
			   ConfigurationData.SaveChanges ()

			   SaveChangesButton.Enabled = ConfigurationData.HasChanges ()
			End Sub

		 #End Region

		 #Region "Properties"


		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Members"

			Private _client As ClientConfiguration
			Private _servers As DICOMServers
			Private _canViewPACSConfig As Boolean

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
