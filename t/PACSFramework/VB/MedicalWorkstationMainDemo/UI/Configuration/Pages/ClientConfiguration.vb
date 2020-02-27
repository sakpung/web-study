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
Imports System.Net
Imports System.Windows.Forms
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.Medical.Winforms
Imports Leadtools.Dicom.Common.DataTypes


Namespace Leadtools.Demos.Workstation
   Partial Public Class ClientConfiguration
	   Inherits UserControl
	  #Region "Public"

		 #Region "Methods"

			Public Sub New()
			   Try
				  InitializeComponent ()

				  Init ()
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

		 #End Region

		 #Region "Properties"

			Public Property CanChangeClientInfo() As Boolean
			   Get
				  Return _canChangeClientInfo
			   End Get

			   Set(ByVal value As Boolean)
				  _canChangeClientInfo = value

				  WorkstationAETextBox.Enabled = value
				  WorkstationPortMaskedTextBox.Enabled = value

				  If (Not value) Then
					 CanChangeForceClientInfo = False
				  End If
			   End Set
			End Property

			Public Property CanChangeForceClientInfo() As Boolean
			   Get
				  Return ForceToAllClientsCheckBox.Enabled
			   End Get

			   Set(ByVal value As Boolean)
				  ForceToAllClientsCheckBox.Enabled = value
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
				  Dim hostName As String
				  Dim localIpAddress() As IPAddress


				  CanChangeClientInfo = True
				  __UpdatingConfig = False

				  hostName = Dns.GetHostName ()

				  WorkstationHostaddressComboBox.Items.Add (hostName)

				  If ConfigurationData.WorkstationClient.Address = hostName Then
					 WorkstationHostaddressComboBox.SelectedItem = hostName
				  End If

				  localIpAddress = Dns.GetHostAddresses (hostName)

				  For Each address As IPAddress In localIpAddress
					 If address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
						WorkstationHostaddressComboBox.Items.Add (address.ToString ())

						If ConfigurationData.WorkstationClient.Address = address.ToString () Then
						   WorkstationHostaddressComboBox.SelectedItem = address.ToString ()
						End If
					 End If
				  Next address

				  AlwaysSaveSessionRadioButton.Tag = SaveOptions.AlwaysSave
				  NeverSaveSessionRadioButton.Tag = SaveOptions.NeverSave
				  PromptUserSaveSessionRadioButton.Tag = SaveOptions.PromptUser

				  ReadConfiguration ()

				  AddHandler Load, AddressOf ClientConfiguration_Load
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw exception
			   End Try
			End Sub

			Private Sub ReadConfiguration()
			   If __UpdatingConfig Then
				  Return
			   End If

			   Me.SuspendLayout ()

			   Try
				  WorkstationAETextBox.Text = ConfigurationData.WorkstationClient.AETitle
                WorkstationPortMaskedTextBox.Text = ConfigurationData.WorkstationClient.Port.ToString()
                WorkstationSecureCheckBox.Checked = ConfigurationData.WorkstationClient.Secure
                MoveToWsClientRadioButton.Checked = ConfigurationData.MoveToWSClient
				  MoveToWsServiceRadioButton.Checked = Not ConfigurationData.MoveToWSClient
				  WorkstationServiceAETitleTextBox.Text = ConfigurationData.WorkstationServiceAE
				  ForceToAllClientsCheckBox.Checked = ConfigurationData.SetClientToAllWorkstations
				  EnableDebugCheckBox.Checked = ConfigurationData.Debugging.Enable
				  DisplayDetailDebugMsgCheckBox.Checked = ConfigurationData.Debugging.DisplayDetailedErrors
				  DebugLogFileCheckBox.Checked = ConfigurationData.Debugging.GenerateLogFile
				  DebugLogFileNameTextBox.Text = ConfigurationData.Debugging.LogFileName
				  UseCompressionCheckBox.Checked = ConfigurationData.Compression.Enable
				  LossyCompressionRadioButton.Checked = ConfigurationData.Compression.Lossy
				  EnableLazyLoadingCheckBox.Checked = ConfigurationData.ViewerLazyLoading.Enable
				  LazyLoadingHiddenImagesMaskedTextBox.Text = ConfigurationData.ViewerLazyLoading.HiddenImages.ToString ()
				  AutoSizeOverlayTextCheckBox.Checked = ConfigurationData.ViewerAutoSizeOverlayText
				  FixedOverlayTextSizeNumericUpDown.Value = ConfigurationData.ViewerOverlayTextSize
				  FixedOverlayTextSizeNumericUpDown.Enabled = Not ConfigurationData.ViewerAutoSizeOverlayText
				  FullScreenModeCheckBox.Checked = ConfigurationData.RunFullScreen
				  ContinueRetireveOnDuplicateCheckBox.Checked = ConfigurationData.ContinueRetrieveOnDuplicateInstance

				  LosslessCompressionRadioButton.Checked = Not LossyCompressionRadioButton.Checked
				  CompressionGroupBox.Enabled = UseCompressionCheckBox.Checked
				  DebugGroupBox.Enabled = EnableDebugCheckBox.Checked
				  LazyLoadingHiddenImagesMaskedTextBox.Enabled = EnableLazyLoadingCheckBox.Checked

				  AlwaysSaveSessionRadioButton.Checked = ConfigurationData.SaveSessionBehavior = SaveOptions.AlwaysSave
				  NeverSaveSessionRadioButton.Checked = ConfigurationData.SaveSessionBehavior = SaveOptions.NeverSave
				  PromptUserSaveSessionRadioButton.Checked = ConfigurationData.SaveSessionBehavior = SaveOptions.PromptUser

				  HandleDicomRetrieveUI ()
			   Finally
				  Me.ResumeLayout ()
			   End Try
			End Sub

			Private Sub HandleDicomRetrieveUI()
			   ContinueRetireveOnDuplicateCheckBox.Enabled = ConfigurationData.MoveToWSClient
			   WorkstationServiceAETitleTextBox.Enabled = Not ConfigurationData.MoveToWSClient

			End Sub

			Private Sub RegisterEvents()
			   Try
				  AddHandler WorkstationAETextBox.Validating, AddressOf txtWorkstationAE_Validating
				  AddHandler WorkstationAETextBox.TextChanged, AddressOf WorkstationAETextBox_TextChanged

				  AddHandler WorkstationPortMaskedTextBox.TextChanged, AddressOf WorkstationPortMaskedTextBox_TextChanged
				  'WorkstationPortMaskedTextBox.Validated                 += new EventHandler ( txtWorkstationPort_Validated ) ;
				  AddHandler WorkstationHostaddressComboBox.SelectedIndexChanged, AddressOf cmbWorkstationIPaddress_SelectedIndexChanged
                AddHandler WorkstationSecureCheckBox.CheckedChanged, AddressOf WorkstationSecureCheckBox_CheckedChanged

                AddHandler ForceToAllClientsCheckBox.CheckedChanged, AddressOf ForceToAllClientsCheckBox_CheckedChanged
				  AddHandler MoveToWsClientRadioButton.CheckedChanged, AddressOf MoveToWsClientRadioButton_CheckedChanged

				  AddHandler ContinueRetireveOnDuplicateCheckBox.CheckedChanged, AddressOf chkContinueRetireve_CheckedChanged

				  AddHandler EnableDebugCheckBox.CheckedChanged, AddressOf chkEnableDebug_CheckedChanged
				  AddHandler DisplayDetailDebugMsgCheckBox.CheckedChanged, AddressOf chkDebugMsg_CheckedChanged
				  AddHandler DebugLogFileCheckBox.CheckedChanged, AddressOf chkLogFile_CheckedChanged
				  AddHandler DebugLogFileNameTextBox.Validating, AddressOf txtLogFileName_Validating
				  AddHandler DebugLogFileNameTextBox.Validated, AddressOf txtLogFileName_Validated

				  AddHandler UseCompressionCheckBox.CheckedChanged, AddressOf chkUseCompression_CheckedChanged
				  AddHandler LossyCompressionRadioButton.CheckedChanged, AddressOf rbtnLossyCompression_CheckedChanged

				  AddHandler EnableLazyLoadingCheckBox.CheckedChanged, AddressOf chkLazyLoading_CheckedChanged
				  AddHandler LazyLoadingHiddenImagesMaskedTextBox.TextChanged, AddressOf mtxtHiddenImages_TextChanged

				  AddHandler AutoSizeOverlayTextCheckBox.CheckedChanged, AddressOf AutoSizeOverlayTextCheckBox_CheckedChanged
				  AddHandler FixedOverlayTextSizeNumericUpDown.ValueChanged, AddressOf FixedOverlayTextSizeNumericUpDown_ValueChanged

				  AddHandler FullScreenModeCheckBox.CheckedChanged, AddressOf FullScreenModeCheckBox_CheckedChanged

				  AddHandler DebugLogFileButton.Click, AddressOf btnLogFile_Click

				  AddHandler AlwaysSaveSessionRadioButton.CheckedChanged, AddressOf AlwaysSaveSessionRadioButton_CheckedChanged
				  AddHandler NeverSaveSessionRadioButton.CheckedChanged, AddressOf AlwaysSaveSessionRadioButton_CheckedChanged
				  AddHandler PromptUserSaveSessionRadioButton.CheckedChanged, AddressOf AlwaysSaveSessionRadioButton_CheckedChanged

				  AddHandler DisplayOrientationButton.Click, AddressOf DisplayOrientationButton_Click

				  AddHandler ConfigurationData.ValueChanged, AddressOf ConfigurationData_ValueChanged
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw exception
			   End Try
			End Sub

			Private Sub txtWorkstationAE_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
			   If WorkstationAETextBox.Text.Length = 0 Then
				  GenericErrorProvider.SetError (WorkstationAETextBox, "AE Title can't be empty.")

				  e.Cancel = True
			   ElseIf WorkstationAETextBox.Text.Length > 16 Then
				  GenericErrorProvider.SetError (WorkstationAETextBox, "AE Title must be less than 16 characters.")

				  e.Cancel = True
			   Else
				  GenericErrorProvider.SetError (WorkstationAETextBox, String.Empty)
			   End If
			End Sub

			Private Sub WorkstationAETextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True
				  ConfigurationData.WorkstationClient.AETitle = WorkstationAETextBox.Text
			   Catch
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub


		 #End Region

		 #Region "Properties"

			Private private__UpdatingConfig As Boolean
			Private Property __UpdatingConfig() As Boolean
				Get
					Return private__UpdatingConfig
				End Get
				Set(ByVal value As Boolean)
					private__UpdatingConfig = value
				End Set
			End Property

		 #End Region

		 #Region "Events"

			Private Sub ClientConfiguration_Load(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  ReadConfiguration ()

				  If WorkstationHostaddressComboBox.SelectedItem Is Nothing AndAlso WorkstationHostaddressComboBox.Items.Count > 0 Then
					 Try
						__UpdatingConfig = True

						WorkstationHostaddressComboBox.SelectedIndex = 0

						ConfigurationData.WorkstationClient.Address = WorkstationHostaddressComboBox.Items (0).ToString ()
					 Finally
						__UpdatingConfig = False
					 End Try
				  End If

				  RegisterEvents ()
			   Catch e1 As Exception
			   End Try
			End Sub

			Private Sub ConfigurationData_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			   ReadConfiguration ()
			End Sub

			Private Sub cmbWorkstationIPaddress_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  ConfigurationData.WorkstationClient.Address = WorkstationHostaddressComboBox.SelectedItem.ToString ()
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub WorkstationPortMaskedTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.WorkstationClient.Port = Integer.Parse (WorkstationPortMaskedTextBox.Text)
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub chkDebugMsg_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  ConfigurationData.Debugging.DisplayDetailedErrors = DisplayDetailDebugMsgCheckBox.Checked
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub chkEnableDebug_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.Debugging.Enable = EnableDebugCheckBox.Checked

				  DebugGroupBox.Enabled = EnableDebugCheckBox.Checked

				  If DebugLogFileCheckBox.Checked Then
					 DebugLogFileNameTextBox.Focus ()
				  Else
					 GenericErrorProvider.SetError (DebugLogFileNameTextBox, "")
				  End If
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub chkLogFile_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.Debugging.GenerateLogFile = DebugLogFileCheckBox.Checked

				  If DebugLogFileCheckBox.Checked Then
					 DebugLogFileNameTextBox.Focus ()
				  Else
					 GenericErrorProvider.SetError (DebugLogFileNameTextBox, "")
				  End If
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub txtLogFileName_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
			   If DebugLogFileNameTextBox.Text.Length = 0 AndAlso EnableDebugCheckBox.Checked AndAlso DebugLogFileCheckBox.Checked Then
				  e.Cancel = True

				  GenericErrorProvider.SetError (DebugLogFileNameTextBox, "Enter valid file name.")
			   Else
				  e.Cancel = False

				  GenericErrorProvider.SetError (DebugLogFileNameTextBox, "")
			   End If
			End Sub

			Private Sub txtLogFileName_Validated(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.Debugging.LogFileName = DebugLogFileNameTextBox.Text

				  GenericErrorProvider.SetError (DebugLogFileNameTextBox, "")
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub chkUseCompression_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.Compression.Enable = UseCompressionCheckBox.Checked

				  CompressionGroupBox.Enabled = UseCompressionCheckBox.Checked
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

        Private Sub rbtnLossyCompression_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                __UpdatingConfig = True

                ConfigurationData.Compression.Lossy = LossyCompressionRadioButton.Checked
            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
            Finally
                __UpdatingConfig = False
            End Try
        End Sub

        Private Sub WorkstationSecureCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                __UpdatingConfig = True

                ConfigurationData.WorkstationClient.Secure = WorkstationSecureCheckBox.Checked
            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
            Finally
                __UpdatingConfig = False
            End Try
        End Sub

        Private Sub ForceToAllClientsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.SetClientToAllWorkstations = ForceToAllClientsCheckBox.Checked
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub MoveToWsClientRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

              ConfigurationData.MoveToWSClient = MoveToWsClientRadioButton.Checked

               HandleDicomRetrieveUI()
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub chkContinueRetireve_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.ContinueRetrieveOnDuplicateInstance = ContinueRetireveOnDuplicateCheckBox.Checked
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub btnLogFile_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  If BrowseLogFileDialog.ShowDialog () = DialogResult.OK Then
					 DebugLogFileNameTextBox.Text = BrowseLogFileDialog.FileName

					 GenericErrorProvider.SetError (DebugLogFileNameTextBox, "")
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)
			   End Try
			End Sub

			Private Sub chkLazyLoading_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.ViewerLazyLoading.Enable = EnableLazyLoadingCheckBox.Checked

				  LazyLoadingHiddenImagesMaskedTextBox.Enabled = EnableLazyLoadingCheckBox.Checked
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub mtxtHiddenImages_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.ViewerLazyLoading.HiddenImages = Integer.Parse (LazyLoadingHiddenImagesMaskedTextBox.Text)
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub AutoSizeOverlayTextCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.ViewerAutoSizeOverlayText = AutoSizeOverlayTextCheckBox.Checked
				  FixedOverlayTextSizeNumericUpDown.Enabled = Not AutoSizeOverlayTextCheckBox.Checked
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub FixedOverlayTextSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.ViewerOverlayTextSize = CInt(Fix(FixedOverlayTextSizeNumericUpDown.Value))
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub FullScreenModeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  ConfigurationData.RunFullScreen = FullScreenModeCheckBox.Checked
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub AlwaysSaveSessionRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  __UpdatingConfig = True

				  If TypeOf sender Is RadioButton Then
					 Dim saveSessionBehav As RadioButton


					 saveSessionBehav = CType(sender, RadioButton)

					 If TypeOf saveSessionBehav.Tag Is SaveOptions Then
						ConfigurationData.SaveSessionBehavior = CType(saveSessionBehav.Tag, SaveOptions)
					 End If
				  End If
			   Catch ex As Exception
				  System.Diagnostics.Debug.Assert (False, ex.Message)
			   Finally
				  __UpdatingConfig = False
			   End Try
			End Sub

			Private Sub DisplayOrientationButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  Dim orientationView As OrientationConfigDialog


				  orientationView = New OrientationConfigDialog ()

				  orientationView.Configuration = WorkstationShellController.Instance.DisplayOrientation

				  If orientationView.ShowDialog () = DialogResult.OK Then
					 WorkstationShellController.Instance.UpdateDisplayOrientation (orientationView.Configuration)
				  End If
			   Catch exception As Exception
				  ThreadSafeMessager.ShowError (exception.Message)
			   End Try
			End Sub

		 #End Region

		 #Region "Data Members"

			Private _canChangeClientInfo As Boolean

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
