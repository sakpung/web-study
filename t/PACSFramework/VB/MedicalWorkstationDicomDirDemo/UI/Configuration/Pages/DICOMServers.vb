' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Windows.Forms
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.DicomDemos


Namespace Leadtools.Demos.Workstation
   Partial Public Class DICOMServers
	   Inherits UserControl
	  #Region "Public"

		 #Region "Methods"

			Public Sub New()
			   Try
				  InitializeComponent ()

				  Init ()

				  RegisterEvents ()
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

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
				  _valueChangedRegistered = False

				  ReadConfiguration ()
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw exception
			   End Try
			End Sub

			Private Sub RegisterEvents()
			   Try
				  AddHandler Load, AddressOf DICOMServers_Load
				  AddHandler AddDicomServerToolStripButton.Click, AddressOf btnAddServer_Click
				  AddHandler DeleteDicomServerToolStripButton.Click, AddressOf btnDeleteServer_Click

				  AddHandler DICOMServersDataGridView.RowValidating, AddressOf grdvDICOMServers_RowValidating
				  AddHandler DICOMServersDataGridView.RowValidated, AddressOf grdvDICOMServers_RowValidated
				  AddHandler DICOMServersDataGridView.CellValidating, AddressOf grdvDICOMServers_CellValidating
				  AddHandler DICOMServersDataGridView.CellValidated, AddressOf grdvDICOMServers_CellValidated
				  AddHandler DICOMServersDataGridView.SelectionChanged, AddressOf grdvDICOMServers_SelectionChanged
				  AddHandler DICOMServersDataGridView.UserDeletedRow, AddressOf grdvDICOMServers_UserDeletedRow
				  AddHandler DICOMServersDataGridView.CellContentClick, AddressOf grdvDICOMServers_CellContentClick
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw exception
			   End Try
			End Sub

			Private Sub ReadConfiguration()
			   If InvokeRequired Then
				  Invoke (New MethodInvoker (AddressOf ReadConfiguration))

				  Return
			   Else
				  UnregisterValueChanged ()

				  Try
					 __DICOMServers = ConfigurationData.PACS

					 DICOMServersDataGridView.Rows.Clear ()

					 For Each server As ScpInfo In ConfigurationData.PACS
						Dim defaultQueryretrieve As Boolean
						Dim defaultStore As Boolean
						Dim rowIndex As Integer


						defaultQueryretrieve = (Nothing IsNot ConfigurationData.DefaultQueryRetrieveServer AndAlso ConfigurationData.DefaultQueryRetrieveServer.Equals (server))
						defaultStore = (Nothing IsNot ConfigurationData.DefaultStorageServer AndAlso ConfigurationData.DefaultStorageServer.Equals (server))

						rowIndex = DICOMServersDataGridView.Rows.Add (New Object () { server.AETitle, server.Address, server.Port, server.Timeout, defaultQueryretrieve, defaultStore })

						DICOMServersDataGridView.Rows (rowIndex).Tag = server
					 Next server

					 DeleteDicomServerToolStripButton.Enabled = DICOMServersDataGridView.SelectedRows.Count > 0
				  Finally
					 RegisterValueChanged ()
				  End Try
			   End If
			End Sub

			Private Sub grdvDICOMServers_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs)
			   Try
				  Dim validatingRow As DataGridViewRow


				  validatingRow = DICOMServersDataGridView.Rows (e.RowIndex)

				  Try
					 Dim number As Integer



					 If (e.ColumnIndex = AETitleColumn.Index) AndAlso ((Nothing Is e.FormattedValue) OrElse (String.IsNullOrEmpty (e.FormattedValue.ToString ()))) Then
						validatingRow.ErrorText = "AE Title can't be empty"

						e.Cancel = True
					 ElseIf (e.ColumnIndex = AETitleColumn.Index) AndAlso ((Nothing IsNot e.FormattedValue AndAlso e.FormattedValue.ToString ().Length > 16)) Then
						validatingRow.ErrorText = "AE Title must be less than 16 characters"

						e.Cancel = True
					 ElseIf e.ColumnIndex = IPAddressColumn.Index Then
						If (Nothing Is e.FormattedValue) OrElse (String.IsNullOrEmpty (e.FormattedValue.ToString ())) Then
						   validatingRow.ErrorText = "host can't be empty."

						   e.Cancel = True
						Else
						   Try
							  Utils.ResolveIPAddress (validatingRow.Cells (IPAddressColumn.Name).EditedFormattedValue.ToString ())
						   Catch exception As Exception
							  validatingRow.ErrorText = exception.Message

							  e.Cancel = True
						   End Try
						End If
					 ElseIf (e.ColumnIndex = PortColumn.Index) AndAlso (Nothing Is e.FormattedValue OrElse String.IsNullOrEmpty (e.FormattedValue.ToString ()) OrElse (Not Integer.TryParse (e.FormattedValue.ToString ().Replace (",", ""), number))) Then
						validatingRow.ErrorText = "Invalid Port number."

						e.Cancel = True
					 ElseIf (e.ColumnIndex = TimeoutColumn.Index) AndAlso (Nothing Is validatingRow.Cells (TimeoutColumn.Name).EditedFormattedValue OrElse String.IsNullOrEmpty (e.FormattedValue.ToString ()) OrElse (Not Integer.TryParse (e.FormattedValue.ToString ().Replace (",", ""), number))) Then
						validatingRow.ErrorText = "Invalid timeout value."

						e.Cancel = True
					 Else
						validatingRow.ErrorText = ""
					 End If
				  Catch exception As Exception
					 e.Cancel = True

					 validatingRow.ErrorText = exception.Message
				  End Try
			   Catch e1 As Exception
				  e.Cancel = True
			   End Try
			End Sub


		 #End Region

		 #Region "Properties"

			Private Property __DICOMServers() As IList(Of ScpInfo)
			   Get
				  Return _dicomServers
			   End Get

			   Set(ByVal value As IList(Of ScpInfo))
				  _dicomServers = value
			   End Set
			End Property


		 #End Region

		 #Region "Events"

			Private Sub ConfigurationData_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  ReadConfiguration ()
			   Catch e1 As Exception
			   End Try
			End Sub

			Private Sub DICOMServers_Load(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  If Visible Then
					 ReadConfiguration ()
				  End If

				  RegisterValueChanged ()
			   Catch e1 As Exception
			   End Try
			End Sub

			Private Sub btnAddServer_Click(ByVal sender As Object, ByVal e As EventArgs)
			   UnregisterValueChanged ()


			   Try
				  If (Not Me.Validate ()) Then
					 Return
				  End If

				  Dim scp As ScpInfo


				  scp = New ScpInfo ()

				  Dim rowIndex As Integer = DICOMServersDataGridView.Rows.Add ()

				  Dim pacsRow As DataGridViewRow = DICOMServersDataGridView.Rows (rowIndex)

				  pacsRow.Tag = scp
				  pacsRow.ReadOnly = False
				  pacsRow.Selected = True

				  __DICOMServers.Add (scp)

				  DICOMServersDataGridView.CurrentCell = pacsRow.Cells (0)
				  DICOMServersDataGridView.ShowEditingIcon = True
				  DICOMServersDataGridView.BeginEdit (False)
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)


			   Finally
				  RegisterValueChanged ()
			   End Try
			End Sub

			Private Sub btnDeleteServer_Click(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  UnregisterValueChanged ()

				  If DICOMServersDataGridView.SelectedRows.Count <> 0 Then
					 Dim deleteRow As DataGridViewRow
					 Dim server As ScpInfo


					 deleteRow = DICOMServersDataGridView.SelectedRows (0)

					 server = CType(deleteRow.Tag, ScpInfo)

					 If __DICOMServers.Contains (server) Then
						__DICOMServers.Remove (server)
					 End If

					 DICOMServersDataGridView.Rows.Remove (deleteRow)
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)
			   Finally
				  RegisterValueChanged ()
			   End Try
			End Sub

			Private Sub grdvDICOMServers_RowValidating(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs)
			   Try
				  Dim validatingRow As DataGridViewRow
				  Dim number As Integer

				  validatingRow = DICOMServersDataGridView.Rows (e.RowIndex)

				  If (Nothing Is validatingRow.Cells (AETitleColumn.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty (validatingRow.Cells (AETitleColumn.Name).EditedFormattedValue.ToString ())) Then
					 validatingRow.ErrorText = "AE Title can't be empty"

					 e.Cancel = True

					 Return
				  End If

				  If (Nothing IsNot validatingRow.Cells (AETitleColumn.Name).EditedFormattedValue AndAlso validatingRow.Cells (AETitleColumn.Name).EditedFormattedValue.ToString ().Length > 16) Then
					 validatingRow.ErrorText = "AE Title must be less than 16 characters"

					 e.Cancel = True

					 Return
				  End If

				  If (Nothing Is validatingRow.Cells (IPAddressColumn.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty (validatingRow.Cells (IPAddressColumn.Name).EditedFormattedValue.ToString ())) Then
					 validatingRow.ErrorText = "host can't be empty."

					 e.Cancel = True

					 Return
				  End If

				  Try
					 Utils.ResolveIPAddress (validatingRow.Cells (IPAddressColumn.Name).EditedFormattedValue.ToString ())
				  Catch exception As Exception
					 validatingRow.ErrorText = exception.Message

					 e.Cancel = True

					 Return
				  End Try

				  If (Nothing Is validatingRow.Cells (PortColumn.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty (validatingRow.Cells (PortColumn.Name).EditedFormattedValue.ToString ())) OrElse ((Not Integer.TryParse (validatingRow.Cells (PortColumn.Name).EditedFormattedValue.ToString ().Replace (",", ""), number))) Then
					 validatingRow.ErrorText = "Invalid Port number."

					 e.Cancel = True

					 Return
				  End If

				  If (Nothing Is validatingRow.Cells (TimeoutColumn.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty (validatingRow.Cells (TimeoutColumn.Name).EditedFormattedValue.ToString ())) OrElse ((Not Integer.TryParse (validatingRow.Cells (TimeoutColumn.Name).EditedFormattedValue.ToString ().Replace (",", ""), number))) Then
					 validatingRow.ErrorText = "Invalid timeout value."

					 e.Cancel = True

					 Return
				  End If

				  validatingRow.ErrorText = ""

			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Sub

			Private Sub grdvDICOMServers_RowValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
			   Try
				  UnregisterValueChanged ()

				  Dim validatingRow As DataGridViewRow
				  Dim scp As ScpInfo

				  validatingRow = DICOMServersDataGridView.Rows (e.RowIndex)

				  scp = CType(validatingRow.Tag, ScpInfo)

				  scp.AETitle = validatingRow.Cells (AETitleColumn.Name).EditedFormattedValue.ToString ()
				  scp.Address = validatingRow.Cells (IPAddressColumn.Name).EditedFormattedValue.ToString ()
				  scp.Port = Integer.Parse (validatingRow.Cells (PortColumn.Name).EditedFormattedValue.ToString ().Replace (",", ""))
				  scp.Timeout = Integer.Parse (validatingRow.Cells (TimeoutColumn.Name).EditedFormattedValue.ToString ().Replace (",", ""))

				  If (Not __DICOMServers.Contains (scp)) Then
					 __DICOMServers.Add (scp)
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)
			   Finally
				  RegisterValueChanged ()
			   End Try
			End Sub

			Private Sub grdvDICOMServers_CellValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
			   Try
				  Dim validatingRow As DataGridViewRow
				  Dim scp As ScpInfo


				  UnregisterValueChanged ()

				  validatingRow = DICOMServersDataGridView.Rows (e.RowIndex)

				  scp = CType(validatingRow.Tag, ScpInfo)

				  If e.ColumnIndex = AETitleColumn.Index Then
					 scp.AETitle = validatingRow.Cells (AETitleColumn.Name).EditedFormattedValue.ToString ()
				  ElseIf e.ColumnIndex = IPAddressColumn.Index Then
					 scp.Address = validatingRow.Cells (IPAddressColumn.Name).EditedFormattedValue.ToString ()
				  ElseIf e.ColumnIndex = PortColumn.Index Then
					 scp.Port = Integer.Parse (validatingRow.Cells (PortColumn.Name).EditedFormattedValue.ToString ().Replace (",", ""))
				  ElseIf e.ColumnIndex = TimeoutColumn.Index Then
					 scp.Timeout = Integer.Parse (validatingRow.Cells (TimeoutColumn.Name).EditedFormattedValue.ToString ().Replace (",", ""))
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)
			   Finally
				  RegisterValueChanged ()
			   End Try
			End Sub

			Private Sub grdvDICOMServers_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
			   Try
				  DeleteDicomServerToolStripButton.Enabled = DICOMServersDataGridView.SelectedRows.Count <> 0
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)
			   End Try
			End Sub

			Private Sub grdvDICOMServers_UserDeletedRow(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs)
			   Try
				  UnregisterValueChanged ()

				  Dim server As ScpInfo


				  server = CType(e.Row.Tag, ScpInfo)

				  If __DICOMServers.Contains (server) Then
					 __DICOMServers.Remove (server)
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)
			   Finally
				  RegisterValueChanged ()
			   End Try
			End Sub

			Private Sub RegisterValueChanged()
			   If (Not _valueChangedRegistered) Then
				  AddHandler ConfigurationData.ValueChanged, AddressOf ConfigurationData_ValueChanged

				  _valueChangedRegistered = True
			   End If
			End Sub

			Private Sub UnregisterValueChanged()
			   If _valueChangedRegistered Then
				  RemoveHandler ConfigurationData.ValueChanged, AddressOf ConfigurationData_ValueChanged

				  _valueChangedRegistered = False
			   End If
			End Sub

			Private Sub grdvDICOMServers_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
			   Try
				  UnregisterValueChanged ()

				  If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
					 Return
				  End If

				  If (DICOMServersDataGridView.Columns (e.ColumnIndex) Is DefaultStoreServerColumn) OrElse (DICOMServersDataGridView.Columns (e.ColumnIndex) Is DefaultQueryRetrieveColumn) Then
					 Dim defaultChceked As Boolean


					 defaultChceked = CBool(DICOMServersDataGridView.Rows (e.RowIndex).Cells (e.ColumnIndex).EditedFormattedValue)

					 If defaultChceked Then
						For rowIndedx As Integer = 0 To DICOMServersDataGridView.Rows.Count - 1
						   If rowIndedx <> e.RowIndex Then
							  DICOMServersDataGridView.Rows (rowIndedx).Cells (e.ColumnIndex).Value = False
						   End If
						Next rowIndedx

						If DICOMServersDataGridView.Columns (e.ColumnIndex) Is DefaultStoreServerColumn Then
						   ConfigurationData.DefaultStorageServer = CType(DICOMServersDataGridView.Rows (e.RowIndex).Tag, ScpInfo)
						Else
						   ConfigurationData.DefaultQueryRetrieveServer = CType(DICOMServersDataGridView.Rows (e.RowIndex).Tag, ScpInfo)
						End If
					 Else
						If DICOMServersDataGridView.Columns (e.ColumnIndex) Is DefaultStoreServerColumn Then
						   ConfigurationData.DefaultStorageServer = Nothing
						Else
						   ConfigurationData.DefaultQueryRetrieveServer = Nothing
						End If
					 End If
				  End If
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)
			   Finally
				  RegisterValueChanged ()
			   End Try
			End Sub

		 #End Region

		 #Region "Data Members"

			Private _dicomServers As IList(Of ScpInfo)
			Private _valueChangedRegistered As Boolean

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
