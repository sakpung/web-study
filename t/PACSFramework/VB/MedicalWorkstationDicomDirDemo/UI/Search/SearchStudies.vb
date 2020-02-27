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
Imports System.Threading
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Medical.Workstation.Client
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Workstation.DataAccessLayer.Configuration
Imports Leadtools.Medical.Workstation
'using Leadtools.Demos.Workstation.UI.Search.QueryDataSet;


Namespace Leadtools.Demos.Workstation
   Partial Public Class SearchStudies
      Inherits UserControl
#Region "Public"

#Region "Methods"

         Public Sub New()
            Try
              InitializeComponent()

              Init()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Public Sub QueryStudies(ByVal query As FindQuery, ByVal mode As DicomClientMode)
            FillQueryFields(query)

            DoSearchStudies(DicomClientFactory.CreateQueryClient(mode), query)
         End Sub

         Private Sub FillQueryFields(ByVal query As FindQuery)
            Dim patientName As PersonNameComponent = GetPersonNameComponents(query.PatientName)
            Dim referDrName As PersonNameComponent = GetPersonNameComponents(query.ReferringPhysiciansName)

            PatientLastNameTextBox.Text = patientName.FamilyName
            PatientGivenNameTextBox.Text = patientName.GivenName
            PatientIDTextBox.Text = query.PatientId
            StudiesIDTextBox.Text = query.StudyId

            AccessionNumberTextBox.Text = query.AccessionNumber
            RefDrLastNameTextBox.Text = referDrName.FamilyName
            RefDrGivenNameTextBox.Text = referDrName.GivenName

            If query.StudyDate.StartDate.HasValue OrElse query.StudyTime.StartTime.HasValue Then
              StudyFromDateTimePicker.Value = GetFromDate(query)
              StudyFromDateTimePicker.Checked = True
            Else
              StudyFromDateTimePicker.Checked = False
            End If

            If query.StudyDate.EndDate.HasValue OrElse query.StudyTime.EndTime.HasValue Then
              StudyToDateTimePicker.Value = GetToDate(query)
              StudyToDateTimePicker.Checked = True
            Else
              StudyToDateTimePicker.Checked = False
            End If

            'query.Modalities

            ModalitiesCheckedComboBox.ClearCheckedItems()
            ModalitiesSelectAllCheckBox.Checked = False

         End Sub

         Private Shared Function GetFromDate(ByVal query As FindQuery) As DateTime
            Dim studyDateFrom As DateTime


            If query.StudyDate.StartDate.HasValue AndAlso query.StudyTime.StartTime.HasValue Then
              studyDateFrom = New DateTime(query.StudyDate.StartDate.Value.Year, query.StudyDate.StartDate.Value.Month, query.StudyDate.StartDate.Value.Day, query.StudyTime.StartTime.Value.Hour, query.StudyTime.StartTime.Value.Minute, query.StudyTime.StartTime.Value.Seconds)
            ElseIf query.StudyDate.StartDate.HasValue Then
              studyDateFrom = New DateTime(query.StudyDate.StartDate.Value.Year, query.StudyDate.StartDate.Value.Month, query.StudyDate.StartDate.Value.Day, 0, 0, 0)
            Else
              studyDateFrom = New DateTime(1, 1, 1, query.StudyTime.StartTime.Value.Hour, query.StudyTime.StartTime.Value.Minute, query.StudyTime.StartTime.Value.Seconds)
            End If

            Return studyDateFrom
         End Function

         Private Shared Function GetToDate(ByVal query As FindQuery) As DateTime
            Dim studyDateTo As DateTime

            If query.StudyDate.EndDate.HasValue AndAlso query.StudyTime.EndTime.HasValue Then
              studyDateTo = New DateTime(query.StudyDate.EndDate.Value.Year, query.StudyDate.EndDate.Value.Month, query.StudyDate.EndDate.Value.Day, query.StudyTime.EndTime.Value.Hour, query.StudyTime.EndTime.Value.Minute, query.StudyTime.EndTime.Value.Seconds)
            ElseIf query.StudyDate.StartDate.HasValue Then
              studyDateTo = New DateTime(query.StudyDate.EndDate.Value.Year, query.StudyDate.EndDate.Value.Month, query.StudyDate.EndDate.Value.Day, 0, 0, 0)
            Else
              studyDateTo = New DateTime(1, 1, 1, query.StudyTime.EndTime.Value.Hour, query.StudyTime.EndTime.Value.Minute, query.StudyTime.EndTime.Value.Seconds)
            End If

            Return studyDateTo
         End Function

         Private Function GetPersonNameComponents(ByVal nameString As String) As PersonNameComponent
            Dim nameComponents() As String
            Dim personName As PersonNameComponent


            personName = New PersonNameComponent()

            If (Not String.IsNullOrEmpty(nameString)) Then
              nameComponents = nameString.Split("^"c)

              If nameComponents.Length > 0 Then
                personName.FamilyName = nameComponents(0)
              End If

              If nameComponents.Length > 1 Then
                personName.GivenName = nameComponents(1)
              End If

              If nameComponents.Length > 2 Then
                personName.MiddleName = nameComponents(2)
              End If

              If nameComponents.Length > 3 Then
                personName.NamePrefix = nameComponents(3)
              End If

              If nameComponents.Length > 4 Then
                personName.NameSuffix = nameComponents(4)
              End If
            End If

            Return personName
         End Function

#End Region

#Region "Properties"

#End Region

#Region "Events"

         Public Event DisplayViewer As EventHandler
         Public Event StudySearchCompleted As EventHandler(Of SearchCompletedEventArgs)

#End Region

#Region "Data Types Definition"

         Public Class SearchEventArgs
            Inherits EventArgs
            Public Sub New(ByVal query As FindQuery)
              Me.Query = query
            End Sub

            Public Property Query() As FindQuery
              Get
                Return _query
              End Get

              Private Set(ByVal value As FindQuery)
                _query = value
              End Set
            End Property

            Private _query As FindQuery
         End Class

         Private Class PersonNameComponent
            Public FamilyName As String
            Public GivenName As String
            Public MiddleName As String
            Public NamePrefix As String
            Public NameSuffix As String
         End Class

#End Region

#Region "Callbacks"

         Public Event FindStudiesQuery As EventHandler(Of SearchEventArgs)
         Public Event FindSeriesQuery As EventHandler(Of SearchEventArgs)
         Public Event LoadSeries As EventHandler(Of ProcessSeriesEventArgs)
         Public Event AddSeriesToMediaBurning As EventHandler(Of ProcessSeriesEventArgs)
         Public Event StoreSeries As EventHandler(Of StoreSeriesEventArgs)
         Public Event RetrieveSeries As EventHandler(Of StoreSeriesEventArgs)

#End Region

#End Region

#Region "Protected"

#Region "Methods"

         Private Const WM_KEYDOWN As Integer = &H100

         Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
            If m.Msg = WM_KEYDOWN AndAlso m.WParam.ToInt32() = CInt(Fix(ConsoleKey.Enter)) AndAlso SearchButton.Enabled Then
              btnSearch_Click(Me, EventArgs.Empty)
            End If

            Return MyBase.ProcessKeyPreview(m)
         End Function

         Protected Overridable Sub DoSearchStudies(ByVal client As QueryClient)
            DoSearchStudies(client, GetQueryParams())
         End Sub

         Protected Overridable Sub DoSearchStudies(ByVal client As QueryClient, ByVal query As FindQuery)
            Try
              UpdateSearchStartedUI()

              Dim studies As ClientQueryDataSet


              If PacsServerRadioButton.Checked Then
                _lastSearchServer = ConfigurationData.ActivePacs
              Else
                _lastSearchServer = Nothing
              End If

              activeClient = client

              OnFindStudies(Me, New SearchEventArgs(query))

              studies = ConvertStudiesToDotNetADO(client.FindStudies(query))

              If InvokeRequired Then
                Invoke(New ParameterizedThreadStart(AddressOf UpdateStudies), studies)
              Else
                UpdateStudies(studies)
              End If

              OnStudySearchCompleted(Me, New SearchCompletedEventArgs(query, studies))
            Catch exception As Leadtools.Dicom.Scu.Common.ClientCommunicationCanceled
              ThreadSafeMessager.ShowError(exception.Message)
            Catch exception As Leadtools.Dicom.Scu.Common.ClientConnectionException
              ThreadSafeMessager.ShowError(String.Format("Error retrieving studies." & Constants.vbLf & "{0}" & Constants.vbLf & "DICOM Code: {1}" & Constants.vbLf & "{2}", exception.Message, exception.Code, DicomException.GetCodeMessage(exception.Code)))

              ShowDetailedError(exception)

              Return
            Catch exception As Leadtools.Dicom.Scu.Common.ClientAssociationException
              ThreadSafeMessager.ShowError(String.Format("Error retrieving studies." & Constants.vbLf & "{0}" & Constants.vbLf & "DICOM Reason: {1}" & Constants.vbLf & "{2}", exception.Message, exception.Reason, WorkstationUtils.GetAssociationReasonMessage(exception.Reason)))

              ShowDetailedError(exception)

              Return
            Catch exception As Leadtools.Dicom.Scu.Common.ClientCommunicationException
              ThreadSafeMessager.ShowError("Error retrieving studies." & Constants.vbLf + exception.Message + Constants.vbLf & "DICOM Status: " & exception.Status)

              ShowDetailedError(exception)

              Return
            Catch exception As DicomException
              ThreadSafeMessager.ShowError("Error retrieving studies." & Constants.vbLf + exception.Message)

              ShowDetailedError(exception)

              Return
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              ThreadSafeMessager.ShowError("Error retrieving studies.")

              ShowDetailedError(exception)
            Finally
              Try
                UpdateSearchCompletedUI()
              Catch
              End Try
            End Try

         End Sub

         Protected Sub OnStudySearchCompleted(ByVal sender As Object, ByVal e As SearchCompletedEventArgs)
            If Nothing IsNot StudySearchCompletedEvent Then
              RaiseEvent StudySearchCompleted(sender, e)
            End If
         End Sub

         Protected Overridable Sub OnFindStudies(ByVal sender As Object, ByVal query As SearchEventArgs)
            If Nothing IsNot FindStudiesQueryEvent Then
              RaiseEvent FindStudiesQuery(sender, query)
            End If
         End Sub

         Protected Overridable Sub OnFindSeries(ByVal sender As Object, ByVal query As SearchEventArgs)
            If Nothing IsNot FindSeriesQueryEvent Then
              RaiseEvent FindSeriesQuery(sender, query)
            End If
         End Sub

         Protected Overridable Sub OnLoadSeries(ByVal sender As Object, ByVal args As ProcessSeriesEventArgs)
            If Nothing IsNot LoadSeriesEvent Then
              RaiseEvent LoadSeries(sender, args)
            End If
         End Sub

         Protected Overridable Sub OnStoreSeries(ByVal sender As Object, ByVal args As StoreSeriesEventArgs)
            If StoreSeriesEvent IsNot Nothing Then
              RaiseEvent StoreSeries(sender, args)
            End If
         End Sub

         Protected Overridable Sub OnRetrieveSeries(ByVal sender As Object, ByVal args As StoreSeriesEventArgs)
            If RetrieveSeriesEvent IsNot Nothing Then
              RaiseEvent RetrieveSeries(sender, args)
            End If
         End Sub

         Protected Overridable Sub OnAddSeriesToMediaBurning(ByVal series As ProcessSeriesEventArgs)
            If Nothing IsNot AddSeriesToMediaBurningEvent Then
              RaiseEvent AddSeriesToMediaBurning(Me, series)
            End If
         End Sub

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
              StudiesDataGridView.AutoGenerateColumns = False
              SeriesDataGridView.AutoGenerateColumns = False
              CancelSearchButton.Enabled = False
              StudyToDateTimePicker.Checked = False
              StudyFromDateTimePicker.Checked = False

              Leadtools.Medical.Winforms.Control.CheckedComboBox.FillModalities(ModalitiesCheckedComboBox)

              AddHandler Load, AddressOf SearchStudies_Load
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub RegisterEvents()
            Try
              AddHandler VisibleChanged, AddressOf SearchStudies_VisibleChanged
              AddHandler SearchButton.Click, AddressOf btnSearch_Click
              AddHandler ClearSearchButton.Click, AddressOf btnClear_Click
              AddHandler CancelSearchButton.Click, AddressOf btnCancel_Click

              AddHandler StudiesDataGridView.SelectionChanged, AddressOf dgvStudies_SelectionChanged
              AddHandler StudyFromDateTimePicker.ValueChanged, AddressOf dtpkStudyFrom_ValueChanged
              AddHandler StudyToDateTimePicker.ValueChanged, AddressOf dtpkStudyTo_ValueChanged
              AddHandler StudyFromDateTimePicker.EnabledChanged, AddressOf dtpkStudyFrom_EnabledChanged
              AddHandler StudyToDateTimePicker.EnabledChanged, AddressOf dtpkStudyTo_EnabledChanged
              AddHandler LocalDatabaseRadioButton.CheckedChanged, AddressOf rbtnLocalDatabase_CheckedChanged
              AddHandler PacsServersComboBox.SelectedValueChanged, AddressOf cmbServers_SelectedValueChanged

              AddHandler ModalitiesCheckedComboBox.CheckChanged, AddressOf ModalitiesCheckedComboBox_CheckChanged
              AddHandler ModalitiesSelectAllCheckBox.CheckStateChanged, AddressOf chkSelectAll_CheckStateChanged

              AddHandler StudiesDataGridView.RowContextMenuStripNeeded, AddressOf dgvStudies_RowContextMenuStripNeeded
              AddHandler SeriesDataGridView.RowContextMenuStripNeeded, AddressOf dgvSeries_RowContextMenuStripNeeded

              AddHandler StudiesDataGridView.CellMouseDown, AddressOf dgvStudies_CellMouseDown
              AddHandler SeriesDataGridView.CellMouseDown, AddressOf dgvSeries_CellMouseDown

              AddHandler StudiesContextMenuStrip.Opening, AddressOf cmnuLocalToolStrip_Opening
              AddHandler SeriesContextMenuStrip.Opening, AddressOf cmnuLocalToolStrip_Opening


              AddHandler StudiesContextMenuStrip.Closed, AddressOf cmnuLocalToolStrip_Closed
              AddHandler SeriesContextMenuStrip.Closed, AddressOf cmnuLocalToolStrip_Closed

              AddHandler StoreStudyToolStripMenuItem.Click, AddressOf storeStudyToolStripMenuItem_Click
              AddHandler StoreStudyToServersToolStripMenuItem.DropDownItemClicked, AddressOf storeStudyToServersToolStripMenuItem_DropDownItemClicked

              AddHandler AddStudyToViewerToolStripMenuItem.Click, AddressOf addStudyToViewerToolStripMenuItem_Click
              AddHandler OpenStudyInViewerToolStripMenuItem.Click, AddressOf openStudyInViewerToolStripMenuItem_Click
              AddHandler AddToMediaBurningManagerToolStripMenuItem.Click, AddressOf AddToMediaBurningManagerToolStripMenuItem_Click
              AddHandler SeriesDataGridView.CellMouseDoubleClick, AddressOf dgvSeries_CellMouseDoubleClick
              AddHandler ViewSeriesToolStripMenuItem.Click, AddressOf ViewSeriesToolStripMenuItem_Click
              AddHandler OpenInViewerToolStripMenuItem.Click, AddressOf openInViewerToolStripMenuItem_Click
              AddHandler AddStudiesToQueuetoolStripMenuItem.Click, AddressOf addStudiesToQueuetoolStripMenuItem_Click
              AddHandler AddSeriesToQueuetoolStripMenuItem.Click, AddressOf addSeriesToQueuetoolStripMenuItem_Click

              AddHandler ConfigurationData.ValueChanged, AddressOf ConfigurationData_ValueChanged
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub AddSelectedSeriesToStorageQueue(ByVal storagePacs As ScpInfo)
            Try
              If SeriesDataGridView.SelectedRows.Count = 0 Then
                Return
              End If

              For Each row As DataGridViewRow In SeriesDataGridView.SelectedRows
                Dim studyRow As ClientQueryDataSet.StudiesRow
                Dim seriesRow As ClientQueryDataSet.SeriesRow
                Dim series As StoreSeriesEventArgs


                seriesRow = TryCast((TryCast(row.DataBoundItem, DataRowView)).Row, ClientQueryDataSet.SeriesRow)
                studyRow = (CType(StudiesDataGridView.DataSource, ClientQueryDataSet)).Studies.FindByStudyInstanceUID(seriesRow.StudyInstanceUID)

                series = New StoreSeriesEventArgs(storagePacs, studyRow, seriesRow)

                OnStoreSeries(Me, series)
              Next row
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub OnDisplayViewer(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If Nothing IsNot DisplayViewerEvent Then
                RaiseEvent DisplayViewer(sender, e)
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub FixDateTimePickersMinMaxValues()
            Try

              RemoveHandler StudyFromDateTimePicker.ValueChanged, AddressOf dtpkStudyFrom_ValueChanged
              RemoveHandler StudyToDateTimePicker.ValueChanged, AddressOf dtpkStudyTo_ValueChanged
              RemoveHandler StudyFromDateTimePicker.EnabledChanged, AddressOf dtpkStudyFrom_EnabledChanged
              RemoveHandler StudyToDateTimePicker.EnabledChanged, AddressOf dtpkStudyTo_EnabledChanged

              If StudyFromDateTimePicker.Checked Then
                If StudyToDateTimePicker.Checked Then
                  StudyFromDateTimePicker.MaxDate = StudyToDateTimePicker.Value
                Else
                  StudyFromDateTimePicker.MaxDate = DateTimePicker.MaximumDateTime
                End If
              End If

              If StudyToDateTimePicker.Checked Then
                If StudyFromDateTimePicker.Checked Then
                  StudyToDateTimePicker.MinDate = StudyFromDateTimePicker.Value
                Else
                  StudyToDateTimePicker.MinDate = DateTimePicker.MinimumDateTime
                End If
              End If


              AddHandler StudyFromDateTimePicker.ValueChanged, AddressOf dtpkStudyFrom_ValueChanged
              AddHandler StudyToDateTimePicker.ValueChanged, AddressOf dtpkStudyTo_ValueChanged
              AddHandler StudyFromDateTimePicker.EnabledChanged, AddressOf dtpkStudyFrom_EnabledChanged
              AddHandler StudyToDateTimePicker.EnabledChanged, AddressOf dtpkStudyTo_EnabledChanged
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub UpdateStudies(ByVal data As Object)
            Try
              Dim studies As ClientQueryDataSet = CType(data, ClientQueryDataSet)

              StudiesDataGridView.DataSource = studies

              If studies.Tables.Count <> 0 Then
                StudiesDataGridView.DataMember = studies.Studies.TableName

                If studies.Studies.Rows.Count = 0 Then
                  ThreadSafeMessager.ShowInformation("No studies found matching your search criteria.")
                End If
              Else
                ThreadSafeMessager.ShowInformation("No studies found matching your search criteria.")
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub UpdateSearchStartedUI()
            Try
              If InvokeRequired Then
                Me.Invoke(New MethodInvoker(AddressOf UpdateSearchStartedUI))
              Else
                SearchButton.Enabled = False
                CancelSearchButton.Enabled = True
                Cursor.Current = Cursors.WaitCursor
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub UpdateSearchCompletedUI()
            Try
              If InvokeRequired Then
                Me.Invoke(New MethodInvoker(AddressOf UpdateSearchCompletedUI))
              Else
                SearchButton.Enabled = True
                CancelSearchButton.Enabled = False
                Cursor.Current = Cursors.Default
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub BindSeries(ByVal seriesObject As Object)
            Try
              Dim series As ClientQueryDataSet
              Dim dataAccess As IWorkstationDataAccessAgent


              series = CType(seriesObject, ClientQueryDataSet)

              SeriesDataGridView.DataSource = series

              If 0 <> -series.Tables.Count Then
                SeriesDataGridView.DataMember = series.Series.TableName
              End If

              dataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()

              If Nothing IsNot dataAccess Then
                For Each seriesGridRow As DataGridViewRow In SeriesDataGridView.Rows
                  If dataAccess.HasVolume(seriesGridRow.Cells(SeriesInstanceUIDDataGridViewTextBoxColumn.Name).Value.ToString()) Then
                     seriesGridRow.Cells(VolumeReadyColumn.Name).Value = Resources.Green.ToBitmap()
                  Else
                     seriesGridRow.Cells(VolumeReadyColumn.Name).Value = Resources.Red.ToBitmap()
                  End If
                Next seriesGridRow
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Delegate Function FindQueryHandler() As FindQuery

         Private Function GetQueryParams() As FindQuery

            If InvokeRequired Then
              Return TryCast(Me.Invoke(New FindQueryHandler(AddressOf GetQueryParams)), FindQuery)
            Else
              Dim patientName As String = String.Empty
              Dim physName As String = String.Empty
              Dim query As FindQuery


              patientName = PatientLastNameTextBox.Text.TrimEnd("*"c) & "*"
              physName = RefDrLastNameTextBox.Text.TrimEnd("*"c) & "*"

              If (Not String.IsNullOrEmpty(PatientGivenNameTextBox.Text)) Then
                patientName &= "^" & PatientGivenNameTextBox.Text.TrimEnd("*"c) & "*"
              End If

              If (Not String.IsNullOrEmpty(RefDrGivenNameTextBox.Text)) Then
                physName &= "^" & RefDrGivenNameTextBox.Text.TrimEnd("*"c) & "*"
              End If

              query = New FindQuery()


              query.PatientName = patientName
              query.PatientId = PatientIDTextBox.Text
              query.StudyId = StudiesIDTextBox.Text

              If ModalitiesCheckedComboBox.Text.Length > 0 Then
                query.Modalities.AddRange(ModalitiesCheckedComboBox.Text.Split(","c))
              End If

              query.AccessionNumber = AccessionNumberTextBox.Text
              query.ReferringPhysiciansName = physName

              If StudyFromDateTimePicker.Checked Then
                query.StudyDate.StartDate = StudyFromDateTimePicker.Value
              End If

              If (StudyToDateTimePicker.Checked) Then
                query.StudyDate.EndDate = StudyToDateTimePicker.Value
              End If

              If StudyFromDateTimePicker.Checked Then
                query.StudyTime.StartTime = New Leadtools.Dicom.Common.DataTypes.Time(StudyFromDateTimePicker.Value)
              End If

              If StudyToDateTimePicker.Checked Then
                query.StudyTime.EndTime = New Leadtools.Dicom.Common.DataTypes.Time(StudyToDateTimePicker.Value)
              End If

              Return query
            End If
         End Function

         Private Sub ShowDetailedError(ByVal exception As Exception)
            If WorkstationMessager.DetailedError Then
              WorkstationMessager.ShowDetailedError(Me, exception.Message, exception)
            End If
         End Sub

         Private Function ConvertStudiesToDotNetADO(ByVal studyDataSet() As DicomDataSet) As ClientQueryDataSet
            Try
              Dim resultSet As ClientQueryDataSet


              resultSet = New ClientQueryDataSet()

              For Each study As DicomDataSet In studyDataSet
                resultSet.Studies.AddStudiesRow(GetStringValue(study, DicomTag.PatientID), GetStringValue(study, DicomTag.PatientName), GetStringValue(study, DicomTag.PatientBirthDate), GetStringValue(study, DicomTag.PatientSex), GetStringValue(study, DicomTag.StudyDescription), GetStringValue(study, DicomTag.StudyDate), GetStringValue(study, DicomTag.AccessionNumber), GetStringValue(study, DicomTag.ReferringPhysicianName), GetStringValue(study, DicomTag.StudyInstanceUID))
                study.Dispose()
              Next study

              Return resultSet
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Function

         Private Function ConvertSeriesToDotNetADO(ByVal seriesDataSet() As DicomDataSet, ByVal studyInstanceUID As String) As ClientQueryDataSet
            Try
              Dim resultSet As ClientQueryDataSet


              resultSet = New ClientQueryDataSet()

              For Each series As DicomDataSet In seriesDataSet
                resultSet.Series.AddSeriesRow(GetStringValue(series, DicomTag.SeriesNumber), GetStringValue(series, DicomTag.SeriesDescription), GetStringValue(series, DicomTag.Modality), GetStringValue(series, DicomTag.SeriesDate), GetStringValue(series, DicomTag.SeriesTime), GetStringValue(series, DicomTag.NumberOfSeriesRelatedInstances), studyInstanceUID, GetStringValue(series, DicomTag.SeriesInstanceUID))

                series.Dispose()
              Next series

              Return resultSet
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Function

         Private Function GetStringValue(ByVal dicomDataSet As DicomDataSet, ByVal dicomTag As Long) As String
            Dim element As DicomElement

            element = dicomDataSet.FindFirstElement(Nothing, dicomTag, True)

            If Nothing IsNot element AndAlso element.Length > 0 Then
              Return dicomDataSet.GetConvertValue(element)
            Else
              Return String.Empty
            End If
         End Function

         Private Shared Function CanRetrieve() As Boolean
            Return (ConfigurationData.MoveToWSClient OrElse ((Not String.IsNullOrEmpty(ConfigurationData.WorkstationServiceAE))))
         End Function

         Private Sub UpdateQuerySourceUIState()
            LocalDatabaseRadioButton.Enabled = ConfigurationData.SupportLocalQueriesStore
            PacsServerRadioButton.Enabled = ConfigurationData.SupportDicomCommunication AndAlso ConfigurationData.PACS.Count <> 0

            If ConfigurationData.PACS.Count = 0 Then
              PacsServersComboBox.Items.Clear()
            End If

            SearchSourceGroupBox.Visible = __DisplayQuerySource
         End Sub

         Private Function PerformStudiesSearch(<System.Runtime.InteropServices.Out()> ByRef query As FindQuery) As Boolean
            Dim args() As String = System.Environment.GetCommandLineArgs()
            Dim found As Boolean = False

            query = New FindQuery()

            For Each arg As String In args
              If arg.IndexOf("PatientId", StringComparison.OrdinalIgnoreCase) = 0 Then
                query.PatientId = GetValueFromArg(arg)

                found = True

                Exit For
              End If
            Next arg

            Return found Or ConfigurationData.AutoQuery
         End Function

         Private Function GetValueFromArg(ByVal arg As String) As String
            Dim tokens() As String


            tokens = arg.Split("="c)

            If tokens.Length = 2 Then
              Return tokens(1).Trim()
            Else
              Return Nothing
            End If
         End Function

         Private Sub AddSeriesToMediaBurningManager()
            Try
              If SeriesDataGridView.SelectedRows.Count = 0 Then
                Return
              End If

              For Each row As DataGridViewRow In SeriesDataGridView.SelectedRows
                Dim studyRow As ClientQueryDataSet.StudiesRow
                Dim seriesRow As ClientQueryDataSet.SeriesRow
                Dim series As ProcessSeriesEventArgs


                seriesRow = TryCast((TryCast(row.DataBoundItem, DataRowView)).Row, ClientQueryDataSet.SeriesRow)
                studyRow = (CType(StudiesDataGridView.DataSource, ClientQueryDataSet)).Studies.FindByStudyInstanceUID(seriesRow.StudyInstanceUID)

                series = New ProcessSeriesEventArgs(studyRow, seriesRow)


                OnAddSeriesToMediaBurning(series)
              Next row
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

#End Region

#Region "Properties"

         Private ReadOnly Property __DisplayQuerySource() As Boolean
            Get
              Return ConfigurationData.SupportLocalQueriesStore OrElse ConfigurationData.SupportDicomCommunication
            End Get
         End Property

#End Region

#Region "Events"

         Private Sub SearchStudies_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If (Not Visible) Then
                Return
              End If

              InitPACS()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub InitPACS()
            If ConfigurationData.PACS.Count = 0 AndAlso ConfigurationData.SupportLocalQueriesStore Then
              LocalDatabaseRadioButton.Checked = True
            End If

            UpdateQuerySourceUIState()

            PacsServersComboBox.Items.Clear()

            For Each server As ScpInfo In ConfigurationData.PACS
              PacsServersComboBox.Items.Add(server)
            Next server

            If PacsServersComboBox.Items.Count > 0 Then
              If Nothing IsNot _lastSearchServer AndAlso PacsServersComboBox.Items.Contains(_lastSearchServer) Then
                PacsServersComboBox.SelectedItem = _lastSearchServer
              ElseIf Nothing IsNot ConfigurationData.ActivePacs Then
                PacsServersComboBox.SelectedItem = ConfigurationData.ActivePacs
              ElseIf Nothing IsNot ConfigurationData.DefaultQueryRetrieveServer AndAlso PacsServersComboBox.Items.Contains(ConfigurationData.DefaultQueryRetrieveServer) Then
                PacsServersComboBox.SelectedItem = ConfigurationData.DefaultQueryRetrieveServer
              Else
                PacsServersComboBox.SelectedIndex = 0
              End If
            End If
         End Sub


         Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
            Cursor.Current = Cursors.WaitCursor

            Try
              StudiesDataGridView.DataSource = Nothing
              SeriesDataGridView.DataSource = Nothing

              Dim client As QueryClient = DicomClientFactory.CreateQueryClient()
              Dim searchThread As New Thread(New ParameterizedThreadStart(AddressOf ExecuteSearch))


              searchThread.IsBackground = True
              searchThread.Start(client)
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              ThreadSafeMessager.ShowError("Error retrieving studies." & Constants.vbLf + exception.Message)

              ShowDetailedError(exception)
            Finally
              Cursor.Current = Cursors.Default
            End Try
         End Sub

         Private Sub ExecuteSearch(ByVal client As Object)
                 Try
                    DoSearchStudies(CType(IIf(TypeOf client Is QueryClient, client, Nothing), QueryClient))
                 Catch exception As Exception
                    System.Diagnostics.Debug.Assert(False, exception.Message)
                 End Try
         End Sub
         Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              PatientLastNameTextBox.Text = String.Empty
              PatientGivenNameTextBox.Text = String.Empty
              PatientIDTextBox.Text = String.Empty
              StudiesIDTextBox.Text = String.Empty
              ModalitiesCheckedComboBox.ClearCheckedItems()
              AccessionNumberTextBox.Text = String.Empty
              RefDrLastNameTextBox.Text = String.Empty
              RefDrGivenNameTextBox.Text = String.Empty
              StudyFromDateTimePicker.Checked = False
              StudyToDateTimePicker.Checked = False
              ModalitiesSelectAllCheckBox.Checked = False

              StudiesDataGridView.DataSource = Nothing
              StudiesDataGridView.DataMember = String.Empty

              SeriesDataGridView.DataSource = Nothing
              SeriesDataGridView.DataMember = String.Empty
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If Nothing IsNot activeClient Then
                activeClient.CancelFind()

                activeClient = Nothing
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dtpkStudyFrom_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              FixDateTimePickersMinMaxValues()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dtpkStudyTo_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              FixDateTimePickersMinMaxValues()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dtpkStudyFrom_EnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              FixDateTimePickersMinMaxValues()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dtpkStudyTo_EnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              FixDateTimePickersMinMaxValues()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dgvStudies_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
            Cursor.Current = Cursors.WaitCursor

            Try
              Dim studyInstanceUID As Object


              If StudiesDataGridView.SelectedRows.Count = 0 Then
                Return
              End If

              If Nothing IsNot StudiesDataGridView.SelectedRows(0).Cells(StudyInstanceUIDDataGridViewTextBoxColumn.Name) Then
                studyInstanceUID = StudiesDataGridView.SelectedRows(0).Cells(StudyInstanceUIDDataGridViewTextBoxColumn.Name).Value
              Else
                Return
              End If

              If Nothing IsNot studyInstanceUID Then
                Dim client As QueryClient
                Dim series As ClientQueryDataSet


                client = DicomClientFactory.CreateQueryClient()

                Try
                  Dim query As FindQuery


                  query = New FindQuery()

                  OnFindSeries(Me, New SearchEventArgs(query))

                  query.StudyInstanceUID = studyInstanceUID.ToString()

                  series = ConvertSeriesToDotNetADO(client.FindSeries(query), query.StudyInstanceUID)
                Catch exception As Leadtools.Dicom.Scu.Common.ClientCommunicationCanceled
                  ThreadSafeMessager.ShowError(exception.Message)

                  Return
                Catch exception As Leadtools.Dicom.Scu.Common.ClientConnectionException
                  ThreadSafeMessager.ShowError(String.Format("Error retrieving studies." & Constants.vbLf & "{0}" & Constants.vbLf & "DICOM Code: {1}" & Constants.vbLf & "{2}", exception.Message, exception.Code, DicomException.GetCodeMessage(exception.Code)))

                  ShowDetailedError(exception)

                  Return
                Catch exception As Leadtools.Dicom.Scu.Common.ClientAssociationException
                  ThreadSafeMessager.ShowError(String.Format("Error retrieving studies." & Constants.vbLf & "{0}" & Constants.vbLf & "DICOM Reason: {1}" & Constants.vbLf & "{2}", exception.Message, exception.Reason, WorkstationUtils.GetAssociationReasonMessage(exception.Reason)))

                  ShowDetailedError(exception)

                  Return
                Catch exception As Leadtools.Dicom.Scu.Common.ClientCommunicationException
                  ThreadSafeMessager.ShowError("Error retrieving series." & Constants.vbLf + exception.Message + Constants.vbLf & "DICOM Status: " & exception.Status)

                  ShowDetailedError(exception)

                  Return
                Catch exception As DicomException
                  ThreadSafeMessager.ShowError("Error retrieving series." & Constants.vbLf + exception.Message)

                  ShowDetailedError(exception)

                  Return
                Catch exception As Exception
                  System.Diagnostics.Debug.Assert(False, exception.Message)

                  ThreadSafeMessager.ShowError("Error retrieving series." & Constants.vbLf + exception.Message)

                  ShowDetailedError(exception)

                  Return
                End Try

                If InvokeRequired Then
                  Me.Invoke(New ParameterizedThreadStart(AddressOf BindSeries), series)
                Else
                  BindSeries(series)
                End If
              End If
            Catch exception As Exception
              ThreadSafeMessager.ShowError("Error retrieving data." & Constants.vbLf + exception.Message)

              ShowDetailedError(exception)
            Finally
              Cursor.Current = Cursors.Default
            End Try
         End Sub


         Private Sub ViewSeriesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If SeriesDataGridView.SelectedRows.Count = 0 Then
                Return
              End If

              For Each row As DataGridViewRow In SeriesDataGridView.SelectedRows
                 Dim seriesRow As ClientQueryDataSet.SeriesRow = TryCast((TryCast(row.DataBoundItem, DataRowView)).Row, ClientQueryDataSet.SeriesRow)
                 Dim studyRow As ClientQueryDataSet.StudiesRow = (CType(StudiesDataGridView.DataSource, ClientQueryDataSet)).Studies.FindByStudyInstanceUID(seriesRow.StudyInstanceUID)


                OnLoadSeries(Me, New ProcessSeriesEventArgs(studyRow, seriesRow))
              Next row
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              ThreadSafeMessager.ShowError("Error loading series.")

              ShowDetailedError(exception)

              Return
            End Try
         End Sub

         Private Sub openInViewerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              OnDisplayViewer(Me, New EventArgs())

              ViewSeriesToolStripMenuItem_Click(sender, e)
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dgvSeries_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
            Try
              If _lastSearchServer Is Nothing Then
                OnDisplayViewer(Me, EventArgs.Empty)

                ViewSeriesToolStripMenuItem_Click(sender, e)
              Else
                addSeriesToQueuetoolStripMenuItem_Click(Me, New EventArgs())
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub addStudyToViewerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              SeriesDataGridView.SelectAll()

              ViewSeriesToolStripMenuItem_Click(sender, e)
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub openStudyInViewerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              OnDisplayViewer(sender, e)

              addStudyToViewerToolStripMenuItem_Click(sender, e)

            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub addStudiesToQueuetoolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              SeriesDataGridView.SelectAll()

              addSeriesToQueuetoolStripMenuItem_Click(Me, New EventArgs())
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub AddToMediaBurningManagerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If _applyToAllSeries Then
                SeriesDataGridView.SelectAll()
              End If

              AddSeriesToMediaBurningManager()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub addSeriesToQueuetoolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If SeriesDataGridView.SelectedRows.Count = 0 Then
                Return
              End If

              For Each row As DataGridViewRow In SeriesDataGridView.SelectedRows
                Dim studyRow As ClientQueryDataSet.StudiesRow
                Dim seriesRow As ClientQueryDataSet.SeriesRow
                Dim series As StoreSeriesEventArgs


                seriesRow = TryCast((TryCast(row.DataBoundItem, DataRowView)).Row, ClientQueryDataSet.SeriesRow)
                studyRow = (CType(StudiesDataGridView.DataSource, ClientQueryDataSet)).Studies.FindByStudyInstanceUID(seriesRow.StudyInstanceUID)

                series = New StoreSeriesEventArgs(ConfigurationData.ActivePacs, studyRow, seriesRow)


                OnRetrieveSeries(Me, series)
              Next row
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub chkSelectAll_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              RemoveHandler ModalitiesCheckedComboBox.CheckChanged, AddressOf ModalitiesCheckedComboBox_CheckChanged

              If (ModalitiesSelectAllCheckBox.Checked) AndAlso (ModalitiesSelectAllCheckBox.CheckState = CheckState.Checked) Then
                ModalitiesCheckedComboBox.CheckAllItems()
              ElseIf ((Not ModalitiesSelectAllCheckBox.Checked)) AndAlso (ModalitiesSelectAllCheckBox.CheckState = CheckState.Unchecked) Then
                ModalitiesCheckedComboBox.ClearCheckedItems()
              End If

              AddHandler ModalitiesCheckedComboBox.CheckChanged, AddressOf ModalitiesCheckedComboBox_CheckChanged
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub ModalitiesCheckedComboBox_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              RemoveHandler ModalitiesSelectAllCheckBox.CheckStateChanged, AddressOf chkSelectAll_CheckStateChanged

              If ModalitiesCheckedComboBox.GetCheckedItemsCount() = ModalitiesCheckedComboBox.Items.Count Then
                ModalitiesSelectAllCheckBox.Checked = True
                ModalitiesSelectAllCheckBox.CheckState = CheckState.Checked
              ElseIf ModalitiesCheckedComboBox.GetCheckedItemsCount() = 0 Then
                ModalitiesSelectAllCheckBox.Checked = False
                ModalitiesSelectAllCheckBox.CheckState = CheckState.Unchecked
              Else
                ModalitiesSelectAllCheckBox.Checked = True
                ModalitiesSelectAllCheckBox.CheckState = CheckState.Indeterminate
              End If

              AddHandler ModalitiesSelectAllCheckBox.CheckStateChanged, AddressOf chkSelectAll_CheckStateChanged
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try

         End Sub

         Private Sub dgvStudies_RowContextMenuStripNeeded(ByVal sender As Object, ByVal e As DataGridViewRowContextMenuStripNeededEventArgs)
            Try
              If _lastSearchServer IsNot Nothing Then
                AddStudiesToQueuetoolStripMenuItem.Enabled = CanRetrieve()

                e.ContextMenuStrip = ServerStudiesContextMenuStrip
              Else
                e.ContextMenuStrip = StudiesContextMenuStrip
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dgvSeries_RowContextMenuStripNeeded(ByVal sender As Object, ByVal e As DataGridViewRowContextMenuStripNeededEventArgs)
            Try
              If _lastSearchServer IsNot Nothing Then
                AddSeriesToQueuetoolStripMenuItem.Enabled = CanRetrieve()

                e.ContextMenuStrip = ServerSeriesContextMenuStrip
              Else
                e.ContextMenuStrip = SeriesContextMenuStrip
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dgvStudies_CellMouseDown(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
            Try
              Dim studiesGrid As DataGridView


              studiesGrid = CType(sender, DataGridView)

              If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso e.Button = MouseButtons.Right Then
                If studiesGrid.SelectedRows.Count > 0 AndAlso studiesGrid.Rows.IndexOf(studiesGrid.SelectedRows(0)) = e.RowIndex Then
                  Return
                End If

                If (Control.ModifierKeys And Keys.Control) <> Keys.Control Then
                  studiesGrid.ClearSelection()
                End If

                studiesGrid.Rows(e.RowIndex).Selected = True
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub dgvSeries_CellMouseDown(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
            Try
              If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso e.Button = MouseButtons.Right Then
                CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub cmnuLocalToolStrip_Opening(ByVal sender As Object, ByVal e As CancelEventArgs)
            Try
              If ConfigurationData.SupportDicomCommunication Then
                ToolStripManager.Merge(ServersStudyStoreContextMenuStrip, CType(sender, ToolStrip))
              End If

              If ConfigurationData.PACS.Count = 0 Then
                StoreStudyToolStripMenuItem.Enabled = False
                StoreStudyToServersToolStripMenuItem.Enabled = False
              Else
                Dim storePacs As ScpInfo = Nothing


                StoreStudyToolStripMenuItem.Enabled = True
                StoreStudyToServersToolStripMenuItem.Enabled = True


                If ConfigurationData.DefaultStorageServer IsNot Nothing Then
                  storePacs = ConfigurationData.DefaultStorageServer
                ElseIf ConfigurationData.ActivePacs IsNot Nothing Then
                  storePacs = ConfigurationData.ActivePacs
                Else
                  storePacs = ConfigurationData.PACS(0)
                End If

                ServersStudyStoreContextMenuStrip.Enabled = True

                If (CType(sender, ContextMenuStrip)).SourceControl Is StudiesDataGridView Then
                  _applyToAllSeries = True

                  StoreStudyToolStripMenuItem.Text = String.Format("Store Study ({0})", storePacs.AETitle)
                Else
                  _applyToAllSeries = False

                  StoreStudyToolStripMenuItem.Text = String.Format("Store Series ({0})", storePacs.AETitle)
                End If

                StoreStudyToolStripMenuItem.Tag = storePacs

                StoreStudyToServersToolStripMenuItem.DropDownItems.Clear()

                For Each scp As ScpInfo In ConfigurationData.PACS
                  Dim pacsItem As ToolStripItem


                  pacsItem = StoreStudyToServersToolStripMenuItem.DropDownItems.Add(scp.AETitle)

                  pacsItem.Tag = scp
                Next scp
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub cmnuLocalToolStrip_Closed(ByVal sender As Object, ByVal e As ToolStripDropDownClosedEventArgs)
            Try
              ToolStripManager.RevertMerge(CType(sender, ToolStrip))
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub storeStudyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try

              If _applyToAllSeries = True Then
                SeriesDataGridView.SelectAll()
              End If

              AddSelectedSeriesToStorageQueue(CType(StoreStudyToolStripMenuItem.Tag, ScpInfo))

            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

         Private Sub storeStudyToServersToolStripMenuItem_DropDownItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs)
            Try
              If _applyToAllSeries = True Then
                SeriesDataGridView.SelectAll()
              End If

              AddSelectedSeriesToStorageQueue(CType(e.ClickedItem.Tag, ScpInfo))
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

         Private Sub ConfigurationData_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              LocalDatabaseRadioButton.Checked = (ConfigurationData.ClientBrowsingMode = DicomClientMode.LocalDb)
              PacsServerRadioButton.Checked = (ConfigurationData.ClientBrowsingMode = DicomClientMode.Pacs)

              PacsServersComboBox.Enabled = PacsServerRadioButton.Checked

              UpdateQuerySourceUIState()
              UpdateStudyDateQueryUI()
            Catch e1 As Exception
            End Try
         End Sub

         Private Sub UpdateStudyDateQueryUI()
            StudyFromDateTimePicker.Enabled = ConfigurationData.ClientBrowsingMode <> DicomClientMode.DicomDir
            StudyToDateTimePicker.Enabled = ConfigurationData.ClientBrowsingMode <> DicomClientMode.DicomDir
            If (ConfigurationData.ClientBrowsingMode <> DicomClientMode.DicomDir) Then
               StudyFromDateTimePicker.Checked = StudyFromDateTimePicker.Checked
            Else
               StudyFromDateTimePicker.Checked = False
            End If

            If (ConfigurationData.ClientBrowsingMode <> DicomClientMode.DicomDir) Then
               StudyToDateTimePicker.Checked = StudyToDateTimePicker.Checked
            Else
               StudyToDateTimePicker.Checked = False
            End If

            End Sub
         Private Sub SearchStudies_Load(ByVal sender As Object, ByVal e As EventArgs)
            Try
              InitPACS()

              LocalDatabaseRadioButton.Checked = (ConfigurationData.ClientBrowsingMode = DicomClientMode.LocalDb)
              PacsServerRadioButton.Checked = (ConfigurationData.ClientBrowsingMode = DicomClientMode.Pacs)

              PacsServersComboBox.Enabled = PacsServerRadioButton.Checked

              UpdateQuerySourceUIState()
              UpdateStudyDateQueryUI()
              RegisterEvents()

              Try
                Dim query As FindQuery = Nothing


                If PerformStudiesSearch(query) Then
                  QueryStudies(query, ConfigurationData.ClientBrowsingMode)
                End If
              Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
              End Try
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Sub rbtnLocalDatabase_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If __DisplayQuerySource Then
                ConfigurationData.ClientBrowsingMode = If((LocalDatabaseRadioButton.Checked), DicomClientMode.LocalDb, DicomClientMode.Pacs)
                PacsServersComboBox.Enabled = PacsServerRadioButton.Checked
              End If

            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Sub cmbServers_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            ConfigurationData.ActivePacs = CType(PacsServersComboBox.SelectedItem, ScpInfo)
         End Sub

#End Region

#Region "Data Members"

         Private _applyToAllSeries As Boolean = False
         Private activeClient As QueryClient = Nothing
         Private _lastSearchServer As ScpInfo

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

   Public Class SearchCompletedEventArgs
      Inherits EventArgs
     Public Sub New(ByVal query As FindQuery, ByVal result As ClientQueryDataSet)
       Me.Query = query
       Me.Result = result
     End Sub

     Public Property Query() As FindQuery
       Get
         Return _query
       End Get

       Private Set(ByVal value As FindQuery)
         _query = value
       End Set
     End Property

     Public Property Result() As ClientQueryDataSet
       Get
         Return _result
       End Get

       Private Set(ByVal value As ClientQueryDataSet)
         _result = value
       End Set
     End Property

     Private _query As FindQuery
     Private _result As ClientQueryDataSet
   End Class
End Namespace
