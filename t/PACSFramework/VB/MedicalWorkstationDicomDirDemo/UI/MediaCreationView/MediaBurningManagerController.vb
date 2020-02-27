' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports System.ComponentModel
Imports Leadtools.Medical.Workstation.Commands

Namespace Leadtools.Demos.Workstation
   Friend Class MediaBurningManagerController
     Public Sub New(ByVal view As MediaBurningManagerView, ByVal dicomInformationStateParam As ClientQueryDataSet, ByVal displayViewCommandParam As ICommand)
       MediaBurningManagerView = view
       DicomInformationState = dicomInformationStateParam
       __BurningImages = New BindingList(Of ClientQueryDataSet.ImagesRow)()

       MediaBurningManagerView.DicomInstancesSelectionView.SetState(__BurningImages)

       __MediaCreationPresenter = New MediaCreationPresenter(MediaBurningManagerView.MediaInformationView, __BurningImages)
       DisplayViewCommand = displayViewCommandParam

       AddHandler __MediaCreationPresenter.ClearInstances, AddressOf __MediaCreationPresenter_ClearInstnaces
       AddHandler MediaBurningManagerView.CloseViewRequested, AddressOf __MediaBurningManager_CloseViewRequested
     End Sub

	  Public Sub AddSeriesToBurningManager(ByVal study As ClientQueryDataSet.StudiesRow, ByVal series As ClientQueryDataSet.SeriesRow)
		 Dim seriesInstanceUID As String = series.SeriesInstanceUID

		 Dim images() As ClientQueryDataSet.ImagesRow = DicomInformationState.Images.Where (Function(p) p.SeriesInstanceUID = seriesInstanceUID).ToArray ()


		 If Nothing Is images OrElse images.Length = 0 Then
			images = FillImages (series, DicomInformationState)
		 End If

		 If (Not String.IsNullOrEmpty (study.PatientName)) Then
			__MediaCreationPresenter.SetCurrentPatient (study.PatientName)
		 End If

		 MediaBurningManagerView.DicomInstancesSelectionView.AddSeries (study, series, images)

		 DisplayViewCommand.Execute ()
	  End Sub

	  Private privateMediaBurningManagerView As MediaBurningManagerView
	  Public Property MediaBurningManagerView() As MediaBurningManagerView
		  Get
			  Return privateMediaBurningManagerView
		  End Get
		  Private Set(ByVal value As MediaBurningManagerView)
			  privateMediaBurningManagerView = value
		  End Set
	  End Property

	  Private privateDicomInformationState As ClientQueryDataSet
	  Public Property DicomInformationState() As ClientQueryDataSet
		  Get
			  Return privateDicomInformationState
		  End Get
		  Private Set(ByVal value As ClientQueryDataSet)
			  privateDicomInformationState = value
		  End Set
	  End Property

	  Private privateDisplayViewCommand As ICommand
	  Public Property DisplayViewCommand() As ICommand
		  Get
			  Return privateDisplayViewCommand
		  End Get
		  Private Set(ByVal value As ICommand)
			  privateDisplayViewCommand = value
		  End Set
	  End Property

	  Private Function FillImages(ByVal seriesRow As ClientQueryDataSet.SeriesRow, ByVal informationDS As ClientQueryDataSet) As ClientQueryDataSet.ImagesRow()
		 Dim storageDataAccess As IStorageDataAccessAgent
		 Dim matchingcollection As MatchingParameterCollection
		 Dim matchingList As MatchingParameterList
		 Dim matchingStudy As Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Study
		 Dim matchingSeries As Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Series
		 Dim imageRows As List(Of ClientQueryDataSet.ImagesRow)


		 storageDataAccess = DataAccessServices.GetDataAccessService(Of IStorageDataAccessAgent) ()

		 If Nothing Is storageDataAccess Then
			Return New ClientQueryDataSet.ImagesRow () {}
		 End If

		 matchingcollection = New MatchingParameterCollection ()
		 matchingList = New MatchingParameterList ()
		 matchingStudy = New Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Study (seriesRow.StudyInstanceUID)
		 matchingSeries = New Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters.Series (seriesRow.SeriesInstanceUID)

		 matchingList.Add (matchingStudy)
		 matchingList.Add (matchingSeries)
		 matchingcollection.Add (matchingList)

         Dim instances As CompositeInstanceDataSet = storageDataAccess.QueryCompositeInstances(matchingcollection).ToCompositeInstanceDataSet()

		 imageRows = New List(Of ClientQueryDataSet.ImagesRow) ()

		 For Each instance As CompositeInstanceDataSet.InstanceRow In instances.Instance
			Dim imageRow As ClientQueryDataSet.ImagesRow


			imageRow = informationDS.Images.NewImagesRow ()

			imageRow.StudyInstanceUID = seriesRow.StudyInstanceUID
			imageRow.SeriesInstanceUID = seriesRow.SeriesInstanceUID
			imageRow.SOPInstanceUID = instance.SOPInstanceUID
			imageRow.InstanceNumber = If(instance.IsInstanceNumberNull (), String.Empty, instance.InstanceNumber.ToString ())
			imageRow.SOPClassUID = If(instance.IsSOPClassUIDNull (), String.Empty, instance.SOPClassUID)

			informationDS.Images.AddImagesRow (imageRow)
			imageRows.Add (imageRow)

			__BurningImages.Add (imageRow)
		 Next instance

		 Return imageRows.ToArray ()
	  End Function

	  Private Sub __MediaCreationPresenter_ClearInstnaces(ByVal sender As Object, ByVal e As EventArgs)
		 MediaBurningManagerView.DicomInstancesSelectionView.ClearItems ()

		 DicomInformationState.Clear ()
	  End Sub

	  Private Sub __MediaBurningManager_CloseViewRequested(ByVal sender As Object, ByVal e As EventArgs)
		 If MediaBurningManagerView.Owner IsNot Nothing Then
			MediaBurningManagerView.Owner.Focus ()
		 End If

		 MediaBurningManagerView.Hide ()
	  End Sub

	  Private private__MediaCreationPresenter As MediaCreationPresenter
	  Private Property __MediaCreationPresenter() As MediaCreationPresenter
		  Get
			  Return private__MediaCreationPresenter
		  End Get
		  Set(ByVal value As MediaCreationPresenter)
			  private__MediaCreationPresenter = value
		  End Set
	  End Property

	  Private private__BurningImages As BindingList(Of ClientQueryDataSet.ImagesRow)
	  Private Property __BurningImages() As BindingList(Of ClientQueryDataSet.ImagesRow)
		  Get
			  Return private__BurningImages
		  End Get
		  Set(ByVal value As BindingList(Of ClientQueryDataSet.ImagesRow))
			  private__BurningImages = value
		  End Set
	  End Property
   End Class
End Namespace
