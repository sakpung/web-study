' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.Codecs
Imports Leadtools.Demos

Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing

Imports Leadtools.MedicalViewer
Imports System

''' <summary>
''' This class is the a dialog that allows the user to load DICOMDIR files and view the studies, series and thumbnails.
''' </summary>
Partial Public Class SeriesBrowser
   Inherits Form
   Private imagesLoader As BackgroundWorker
   Private seriesDataSet As StudyBrowserDataSet
   Public Images As IList(Of SeriesInformation)
   Private sliceLocationArray As Double()
   Private doubleArray As Double()
   Private imagesArray As String()
   Private localizerArray As Boolean()
   Private localizerPosition As String()
   Private arrayCounter As Integer
   Private patientElement As DicomElement
   Private referenceUID As String
   Private _imagesSeries As List(Of RasterImage)
   Public _imagesPath As List(Of String)
   Private _echoNumber As List(Of Integer)
   Private _imagePosition As List(Of Point3D)
   Private localizerCounter As Integer
   Private _studyElement As DicomElement
   Private _seriesElement As DicomElement
   Private _seriesCount As Integer
   Private _currentSeries As Integer
   Private _seriesManager As MedicalViewerSeriesManager
   Private _imageDataList As List(Of MedicalViewerImageData)
   Private seriesLoaders As SeriesLoad()
   Private _disableLoading As Boolean
   Private _hideLoadAs3D As Boolean

   ' An event that clients can use to be notified whenever there is a progress with loading the DICOMDIR images
   Public Event Progress As ProgressEventHandler

   'An event that clients can use to be notified whenever he attempts to load one or more series 
   Public Event Loading As LoadingEventHandler

   ' An event that clients can use to be notified when a new image has been successfully added to the Images collections
   Public Event ItemAdded As ItemAddedEventHandler

   ' An event that clients can use to be notified when a new frame has been loaded, when this event is registered then the dialog will load each frame and send it to the user, then dispose of it.
   ' This event decide whether to load all the images at once when loading a certain series, or load them one by one.
   ' if true, then it will load one by one. In that case the user is required to request each frame.
   Public Event FrameLoaded As FrameLoadedEventHandler


   Public Property LoadAs3D() As Boolean
      Get
         Return _checkLoadAs3D.Checked
      End Get

      Set(value As Boolean)
         _checkLoadAs3D.Checked = value
      End Set
   End Property

   Public Property DisableLoading() As Boolean

      Get
         Return _disableLoading
      End Get
      Set(value As Boolean)
         _disableLoading = value
         btnLoad.Enabled = If(seriesDataGridView.Rows.Count > 0, Not _disableLoading, False)
         btnAddDICOMDIR.Enabled = InlineAssignHelper(_checkLoadAs3D.Enabled, Not _disableLoading)
      End Set
   End Property


   Public Property HideLoadAs3D() As Boolean

      Get
         Return _hideLoadAs3D
      End Get
      Set(value As Boolean)
         _hideLoadAs3D = value
         _checkLoadAs3D.Visible = Not _hideLoadAs3D
      End Set
   End Property


   ' Starts the background worker
   Private Sub InitializeBackgroundWorker(loadStudy As Boolean)
      ' Don't start the action twice.
      If imagesLoader.IsBusy Then
         Return
      End If

      EnableProgressControl(ProgressEvent Is Nothing)

      Dim rowCount As Integer = If(loadStudy, seriesDataGridView.Rows.Count, seriesDataGridView.SelectedRows.Count)
      Dim seriesCounter As Integer = 0

      seriesLoaders = New SeriesLoad(rowCount - 1) {}


      For seriesCounter = 0 To rowCount - 1
         seriesLoaders(seriesCounter) = New SeriesLoad()

         seriesLoaders(seriesCounter).SeriesIndex = If(loadStudy, seriesCounter, seriesDataGridView.Rows.IndexOf(seriesDataGridView.SelectedRows(seriesCounter)))

         Dim row As DataGridViewRow = seriesDataGridView.Rows(seriesLoaders(seriesCounter).SeriesIndex)
         seriesLoaders(seriesCounter).StudyInstanceUID = row.Cells(StudyID.Name).Value.ToString()
         seriesLoaders(seriesCounter).SeriesInstanceUID = row.Cells(SeriesID.Name).Value.ToString()
         seriesLoaders(seriesCounter).Count = Convert.ToInt32(row.Cells(FrameCount.Name).Value)
         seriesLoaders(seriesCounter).DataGridCount = studiesDataGridView.Rows.Count
         seriesLoaders(seriesCounter).StudyInstanceUIDArray = New String(seriesLoaders(seriesCounter).DataGridCount - 1) {}
         seriesLoaders(seriesCounter).DICOMDIRUIDArray = New String(seriesLoaders(seriesCounter).DataGridCount - 1) {}

         Dim index As Integer
         For index = 0 To seriesLoaders(0).DataGridCount - 1
            seriesLoaders(0).StudyInstanceUIDArray(index) = studiesDataGridView.Rows(index).Cells(studyInstanceUidColumn.Name).Value.ToString()
         Next

         For index = 0 To seriesLoaders(0).DataGridCount - 1
            seriesLoaders(0).DICOMDIRUIDArray(index) = studiesDataGridView.Rows(index).Cells(DICOMDIRfileNameColumn.Name).Value.ToString()
         Next
      Next

      imagesLoader.RunWorkerAsync(loadStudy)
      If ProgressEvent IsNot Nothing Then
         DialogResult = DialogResult.OK
         Hide()
      End If
   End Sub

   ' This event Notifies that the background worker task has been completed.
   Private Sub imagesLoader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
      EnableProgressControl(False)
      If e.[Error] IsNot Nothing Then
         Throw e.[Error]
      ElseIf Not e.Cancelled Then
         If ProgressEvent Is Nothing Then
            DialogResult = DialogResult.OK
         End If
      Else
         Images.Clear()
      End If
   End Sub

   ' Start the time consuming task..
   Private Sub imagesLoader_DoWork(sender As Object, e As DoWorkEventArgs)
      Try
         ' Load all the selected series
         LoadSelectedSeries()

         If imagesLoader.CancellationPending Then
            e.Cancel = True

         End If
      Catch exception As System.Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
         Throw
      End Try
   End Sub


   ' Initialize everything.
   Public Sub New()
      Try
         InitializeComponent()

         imagesLoader = New BackgroundWorker()
         AddHandler imagesLoader.DoWork, AddressOf imagesLoader_DoWork
         AddHandler imagesLoader.RunWorkerCompleted, AddressOf imagesLoader_RunWorkerCompleted
         AddHandler imagesLoader.ProgressChanged,AddressOf  imagesLoader_ProgressChanged 
         imagesLoader.WorkerSupportsCancellation = True
         imagesLoader.WorkerReportsProgress = True
         If seriesDataSet Is Nothing Then
            seriesDataSet = New StudyBrowserDataSet()
         End If

         Images = New List(Of SeriesInformation)()
      Catch exception As Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
         Throw
      End Try
   End Sub

   ' An event that fires every time the user shows the series browser dialog
   Protected Overrides Sub OnShown(e As EventArgs)
      Images.Clear()
      Focus()
      btnAddDICOMDIR.Focus()
   End Sub

   ' An event that clients can use to be notified whenever there is a progress with loading the DICOMDIR images
   Private Sub imagesLoader_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
      Dim percentage As Integer = e.ProgressPercentage

      ' Sending -1 means that a new image (or set of images) has been loaded successfully and added to the Images collection for the user to use.
      If e.ProgressPercentage = -1 Then
         RaiseEvent ItemAdded(sender, New IteamAddedEventArgs(Images(CInt(e.UserState))))
      Else
         ' if this event is registered, then send it.
         If TypeOf e.UserState Is FrameLoadedEventArgs Then
            Dim args As FrameLoadedEventArgs = CType(e.UserState, FrameLoadedEventArgs)
            RaiseEvent FrameLoaded(Me, args)
            If args.Cancel Then
               imagesLoader.CancelAsync()

               ' Receive the exception details here.
               MessageBox.Show(Leadtools.Demos.DemosGlobalization.GetResxString([GetType](), "Resx_ErrorNotEnoughMemory"))
            End If
            Return
         ElseIf TypeOf e.UserState Is ProgressEventArgs Then
            ' otherwise, the method reports a progress with loading the images, providing a variety of information.
            Dim progressInformation As ProgressEventArgs = CType(e.UserState, ProgressEventArgs)

            ' send the user the progress event.
            If ProgressEvent IsNot Nothing Then
               RaiseEvent Progress(sender, progressInformation)
            Else
               ' if the progress event is null, then in internal progress will start.
               UpdateProgressUI(percentage, progressInformation)
            End If
         End If
      End If
   End Sub

   ' this method will update the built in progress information, if the user didn't want to receive any progress.
   Private Sub UpdateProgressUI(progress As Integer, e As ProgressEventArgs)
      Select Case e.ProgressType
         Case DicomDirProgressType.Preparing
            labelCounter.Text = [String].Format(Leadtools.Demos.DemosGlobalization.GetResxString([GetType](), "Resx_PreparingData"), progress)
            Exit Select
         Case DicomDirProgressType.LoadingImages
            If e.SeriesCount = 1 Then
               labelCounter.Text = [String].Format(Leadtools.Demos.DemosGlobalization.GetResxString([GetType](), "Resx_LoadingImage"), e.CurrentFrame + 1, e.FrameCount)
            Else
               labelCounter.Text = [String].Format(Leadtools.Demos.DemosGlobalization.GetResxString([GetType](), "Resx_LoadingSeries"), e.CurrentSeries + 1, e.SeriesCount, e.CurrentFrame + 1, e.FrameCount)
            End If
            Exit Select
      End Select

      progressCounter.Value = progress
      progressCounter.Update()

   End Sub



   ' This will load the series images
   Private Function LoadSeries(currentSeries As Integer, seriesCount As Integer, studyInstanceUID As String, seriesInstanceUID As String, count As Integer, studyInstanceUIDArray As String(), _
    dicomdirUIDArray As String(), gridRowCount As Integer, selectedStudyIndex As Integer) As Boolean
      Dim index As Integer = 0
      Dim loaded As Boolean = False

      ' Go through the study Grid to find the study of this series, in order to get some information (DICOMDIR file name)
      While index < gridRowCount
         If (studyInstanceUID = studyInstanceUIDArray(index)) AndAlso (index = selectedStudyIndex) Then
            ' Load the series images.
            loaded = LoadSeriesImages(dicomdirUIDArray(index), studyInstanceUID, seriesInstanceUID, count, currentSeries, seriesCount)
            index = gridRowCount
         Else
            index += 1
         End If
      End While

      Return loaded
   End Function

   ' This method will load selected series. (highlighted series from the series grid. Use Ctrl and Left mouse click for multiple series selection).
   Private Sub LoadSelectedSeries()
      Try
         If Not LoadSeries(seriesLoaders(0).SeriesIndex, 1, seriesLoaders(0).StudyInstanceUID, seriesLoaders(0).SeriesInstanceUID, seriesLoaders(0).Count, seriesLoaders(0).StudyInstanceUIDArray, _
          seriesLoaders(0).DICOMDIRUIDArray, seriesLoaders(0).DataGridCount, studiesDataGridView.SelectedRows(0).Index) Then
            Return
         End If
      Catch exception As System.Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
         Throw
      End Try
   End Sub

   ' This method enables or disables the.built-in progress controls (Progress bar, text, and the progress cancel button).
   Private Sub EnableProgressControl(enable As Boolean)
      labelCounter.Text = ""
      labelCounter.Visible = InlineAssignHelper(progressCounter.Visible, InlineAssignHelper(buttonCancelProgress.Visible, enable))
      progressCounter.Value = 0
   End Sub

   ' This method will load selected series. (highlighted series from the series grid. Use Ctrl and Left mouse click for multiple series selection).
   Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
      Try
         If SendLoadingEvent(seriesDataGridView.SelectedRows.Count) Then
            InitializeBackgroundWorker(False)
         End If
      Catch exception As Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
      End Try
   End Sub

   ' Changes the series Grid filter in order to show the series of the selected study from the study grid
   Private Sub studiesDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles studiesDataGridView.SelectionChanged
      ' if loading disabled, don't load.
      If Not btnLoad.Enabled Then
         Return
      End If

      Try
         If studiesDataGridView.SelectedRows.Count <> 0 Then
            ViewSeriesRowsForThisStudy(studiesDataGridView.SelectedRows(0).Index)
         End If
      Catch exception As Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
         Throw
      End Try
   End Sub

   ' Add a new DICOMDIR file to the DICOMDIR dialog
   Private Sub btnAddDICOMDIR_Click(sender As Object, e As EventArgs) Handles btnAddDICOMDIR.Click
      AddDicomDirectory()
   End Sub

   ' Changes the series Grid filter in order to show the series of the selected study from the study grid (the filter is the Study instance UID tag)
   Private Sub ViewSeriesRowsForThisStudy(studyRowIndex As Integer)
      Dim studyInstanceUID As String = studiesDataGridView.Rows(studyRowIndex).Cells(studyInstanceUidColumn.Name).Value.ToString()

      If seriesDataGridView.DataSource IsNot Nothing AndAlso TypeOf seriesDataGridView.DataSource Is BindingSource Then
         Dim bindingSource As BindingSource = TryCast(seriesDataGridView.DataSource, BindingSource)

         bindingSource.RemoveFilter()

         bindingSource.Filter = String.Format("StudyID = '{0}'", studyRowIndex.ToString())
      Else
         Dim bindingSource As New BindingSource(seriesDataSet, seriesDataSet.SeriesTable.TableName)
         bindingSource.Filter = String.Format("StudyID = '{0}'", studyRowIndex.ToString())
         seriesDataGridView.DataSource = bindingSource
      End If
   End Sub

   ' returns the number of frames of the specified series
   Private Function GetFramesCount(ds As DicomDataSet, seriesElement As DicomElement) As Integer
      Dim dicomElement As DicomElement
      Dim count As Integer = 0

      dicomElement = ds.GetChildKey(seriesElement)
      While dicomElement IsNot Nothing
         count += 1
         dicomElement = ds.GetNextKey(dicomElement, True)
      End While

      Return count
   End Function

   ' returns the file name of the frame in order to load it
   Private Function GetFrameFileName(ds As DicomDataSet, dicomDirFileName As String, dicomElement As DicomElement) As String
      Dim position As Integer = dicomDirFileName.LastIndexOf("\")
      Dim directoryPath As String = dicomDirFileName.Remove(position)

      Return (directoryPath & Convert.ToString("\")) + ds.GetConvertValue(dicomElement)
   End Function


   Private Function ResizeImage(image As Image, width As Integer, height As Integer) As Image
      Dim image2 As Image = New Bitmap(width, height)

      Using graphicsHandle As Graphics = Graphics.FromImage(image2)
         'graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
         graphicsHandle.DrawImage(image, 0, 0, width, height)
      End Using

      image.Dispose()

      Return image2
   End Function

   ' Load the thumbnail of the specified dicomElement and convert it to a GDI plus version in order to view it in the series grid thumbnail columns
   Private Function LoadGDIPlusImage(ds As DicomDataSet, dicomDirFileName As String, dicomElement As DicomElement) As Image
      Dim image As Image = Nothing
      Dim rasterImage As RasterImage = Nothing

      Try
         Dim codecs As New RasterCodecs()

         ' Specify the thumbnail properties
         Dim thumbOptions As New CodecsThumbnailOptions()
         thumbOptions.BitsPerPixel = 24
         thumbOptions.Height = 64
         thumbOptions.Width = 64
         thumbOptions.MaintainAspectRatio = True

         'Reads thumbnails.
         'rasterImage = codecs.ReadThumbnail(GetFrameFileName(ds, dicomDirFileName, dicomElement), thumbOptions, 0);

         Dim fileName As String = GetFrameFileName(ds, dicomDirFileName, dicomElement)


         Dim imageDataSet As New DicomDataSet()
         imageDataSet.Load(fileName, DicomDataSetLoadFlags.None)

         Dim imageCount As Integer = imageDataSet.GetImageCount(Nothing)

         If imageCount <> 0 Then
            rasterImage = codecs.Load(fileName)

            image = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None)

            image = ResizeImage(image, 64, 64)

            rasterImage.Dispose()
            codecs.Dispose()
         End If


         imageDataSet.Dispose()

         imageDataSet = Nothing
      Catch e As System.Exception
         Messager.Show(Me, e, MessageBoxIcon.[Error])
         If rasterImage IsNot Nothing Then
            rasterImage.Dispose()
         End If
      End Try
      Return image
   End Function


   ' return the GDIPlus thumbnail of the middle frame of the series in order to view it in the series grid thumbnail columns
   Private Function GetThumbnailImage(ds As DicomDataSet, dicomDirFileName As String, seriesElement As DicomElement, count As Integer) As Image
      Try
         Dim dicomElement As DicomElement
         Dim index As Integer = 0
         ' The thumnailIndex is the frame in the middle of the series
         Dim thumbnailIndex As Integer = CInt(count / 2)

         dicomElement = ds.GetChildKey(seriesElement)
         dicomElement = ds.GetChildElement(dicomElement, True)

         While dicomElement IsNot Nothing
            If index >= thumbnailIndex Then
               dicomElement = ds.FindFirstElement(dicomElement, DicomTag.ReferencedFileID, True)
               Dim image As Image = LoadGDIPlusImage(ds, dicomDirFileName, dicomElement)
               If image IsNot Nothing Then
                  Return image
               End If
            End If

            index += 1
            dicomElement = ds.GetNextKey(dicomElement, True)

            dicomElement = ds.GetChildElement(dicomElement, True)
         End While
         Return Nothing
      Catch exception As System.Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
         Throw exception
      End Try

   End Function

   ' Go through the study and add the series to the series Grid
   Private Sub AddTheStudySeries(ds As DicomDataSet, studyElement As DicomElement, studyID As String, dicomDirFileName As String, studyIndex As Integer)
      Try
         Dim i As Integer
         Dim row As [Object]() = New [Object](10) {}
         ' All the information that will be extracted from the seriesElement. This method will extract those and 3 other (studyID, frame count, and a thumbnail image).
         Dim tags As Long() = {DicomTag.SeriesDate, DicomTag.SeriesNumber, DicomTag.Modality, DicomTag.OrganExposed, DicomTag.SeriesDescription, DicomTag.NumberOfSeriesRelatedInstances, _
          DicomTag.SeriesInstanceUID}

         Dim dicomElement As DicomElement
         Dim seriesInformation As DicomElement

         dicomElement = ds.GetChildKey(studyElement)
         dicomElement = ds.GetChildElement(dicomElement, True)

         While dicomElement IsNot Nothing
            For i = 0 To tags.Length - 1
               seriesInformation = ds.FindFirstElement(dicomElement, tags(i), True)

               If seriesInformation IsNot Nothing Then
                  row(i) = ds.GetConvertValue(seriesInformation)
               End If
            Next

            Dim frameCount As Integer = GetFramesCount(ds, dicomElement)
            row(i) = studyID
            row(i + 1) = frameCount
            row(i + 2) = GetThumbnailImage(ds, dicomDirFileName, dicomElement, frameCount)
            row(i + 3) = studyIndex.ToString()

            ' After retrieving all required series information, add them to the series Grid
            If row(i + 2) IsNot Nothing Then
               seriesDataSet.SeriesTable.Rows.Add(row)
            End If

            ' get to the next series element.
            dicomElement = ds.GetNextKey(dicomElement, True)
            dicomElement = ds.GetChildElement(dicomElement, True)

         End While
      Catch exception As System.Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
         Throw
      End Try

   End Sub

   Private Sub RemoveNewStudy(studiesDataGridView As DataGridView, newOnesIndex As Integer)
      Dim count As Integer = studiesDataGridView.Rows.Count
      count = count - newOnesIndex
      For i As Integer = 0 To count - 1
         studiesDataGridView.Rows.RemoveAt(newOnesIndex)
      Next
   End Sub

   ' Go through the DICOMDIR file and extract all the studies, then add them to the study Grid
   Private Function AddStudyRows(ds As DicomDataSet, dicomDirectoryFileName As String) As Boolean
      ' get the parent element.
      Dim patientElement As DicomElement = ds.GetFirstKey(Nothing, True)

      If patientElement Is Nothing Then
         MessageBox.Show(Leadtools.Demos.DemosGlobalization.GetResxString([GetType](), "Resx_InvalidDICOMDIRFile"), Leadtools.Demos.DemosGlobalization.GetResxString([GetType](), "Resx_InvalidDICOMDIR"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return False
      End If

      Dim lastRowIndex As Integer = studiesDataGridView.Rows.Count
      Try
         Dim dicomElement As DicomElement
         Dim patientNameInformation As DicomElement
         Dim patientIDInformation As DicomElement
         Dim patientInformation As DicomElement
         Dim i As Integer
         Dim row As String() = New String(7) {}
         Dim patientName As String = ""
         Dim patientID As String = ""
         ' All the information that will be extracted from the studyElement. This method will extract those and 3 other (patientName, patientID and DICOMDIR file name).
         Dim tags As Long() = {DicomTag.StudyDescription, DicomTag.AccessionNumber, DicomTag.StudyDate, DicomTag.ReferringPhysicianName, DicomTag.StudyInstanceUID}

         ' Get the patient name and ID.
         patientNameInformation = ds.FindFirstElement(Nothing, DicomTag.PatientName, False)
         If patientNameInformation IsNot Nothing Then
            patientName = ds.GetConvertValue(patientNameInformation)
         End If

         patientIDInformation = ds.FindFirstElement(Nothing, DicomTag.PatientID, False)
         If patientIDInformation IsNot Nothing Then
            patientID = ds.GetConvertValue(patientIDInformation)
         End If


         While patientNameInformation IsNot Nothing
            ' Get the first Study
            dicomElement = ds.GetChildKey(patientElement)
            dicomElement = ds.GetChildElement(dicomElement, True)

            While dicomElement IsNot Nothing
               row(0) = patientName
               row(1) = patientID

               For i = 2 To 6
                  patientInformation = ds.FindFirstElement(dicomElement, tags(i - 2), True)

                  If patientInformation IsNot Nothing Then
                     row(i) = ds.GetConvertValue(patientInformation)
                  End If
               Next

               row(7) = dicomDirectoryFileName

               ' After retrieving all required study information, add them to the study Grid
               studiesDataGridView.Rows.Add(row)
               AddTheStudySeries(ds, dicomElement, row(6), dicomDirectoryFileName, lastRowIndex)
               lastRowIndex += 1

               ' get to the next study element.
               dicomElement = ds.GetNextKey(dicomElement, True)
               dicomElement = ds.GetChildElement(dicomElement, True)
            End While


            patientNameInformation = ds.FindNextElement(patientNameInformation, False)
            If patientNameInformation IsNot Nothing Then
               patientName = ds.GetConvertValue(patientNameInformation)
            End If

            patientIDInformation = ds.FindNextElement(patientIDInformation, False)
            If patientIDInformation IsNot Nothing Then
               patientID = ds.GetConvertValue(patientIDInformation)
            End If

            patientElement = ds.GetNextKey(patientElement, True)

         End While
      Catch exception As System.Exception
         RemoveNewStudy(studiesDataGridView, lastRowIndex)

         System.Diagnostics.Debug.Assert(False, exception.Message)
         MessageBox.Show(exception.Message, Leadtools.Demos.DemosGlobalization.GetResxString([GetType](), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return False
      End Try

      Return True
   End Function

   ' open a DICOMDIR dialog.
   Private Function OpenDicomDirectoryDialog() As String
      Dim dialog As New OpenFileDialog()

      dialog.Filter = "DICOMDIR Files|DICOMDIR|All files (*.*)|*.*"
      dialog.FilterIndex = 1
      Try
         If dialog.ShowDialog() = DialogResult.OK Then
            Return dialog.FileName
         End If
      Catch exep As Exception
         MessageBox.Show(exep.Message, dialog.FileName, MessageBoxButtons.OK)
      End Try

      Return Nothing
   End Function


   ' Add a new DICOMDIR information to the study grid.
   Private Sub AddDicomDirectory()
      Dim ds As New DicomDataSet()

      Dim dicomDirectoryPath As String = OpenDicomDirectoryDialog()
      If dicomDirectoryPath Is Nothing Then
         Return
      End If

      ds.Load(dicomDirectoryPath, DicomDataSetLoadFlags.None)

      ' add the DICOMDIR study to the study Grid.
      Dim added As Boolean = AddStudyRows(ds, dicomDirectoryPath)

      If added Then
         ' view the series of the selected study in the series Grid.
         ViewSeriesRowsForThisStudy(0)
         ' Enables the load button
         btnLoad.Enabled = True
      End If

      ds.Dispose()
   End Sub

   ' Removes all the studies and the series from the DICOMDIR dialog and start all over.
   Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
      Dim index As Integer = 0
      Dim row As DataGridViewRow
      Dim image As Image

      Dim length As Integer = seriesDataGridView.Rows.Count

      While index < length
         row = seriesDataGridView.Rows(index)
         image = CType(row.Cells(Thumbnail.Name).Value, Image)
         image.Dispose()
         index += 1
      End While


      seriesDataSet.Clear()
      studiesDataGridView.Rows.Clear()
      btnLoad.Enabled = False
   End Sub

   ' Find the study using the Study instance UID, and return it's DicomElement if the study is found
   Private Function FindStudy(ds As DicomDataSet, studyInstanceUID As String) As DicomElement
      ' get the parent element.
      Dim patientElement As DicomElement = ds.GetFirstKey(Nothing, True)
      Dim studyElement As DicomElement = Nothing
      Dim studyInformationElement As DicomElement = Nothing
      Dim studyID As String

      While patientElement IsNot Nothing
         studyElement = ds.GetChildKey(patientElement)
         studyElement = ds.GetChildElement(studyElement, True)

         While studyElement IsNot Nothing
            studyInformationElement = ds.FindFirstElement(studyElement, DicomTag.StudyInstanceUID, True)

            If studyInformationElement IsNot Nothing Then
               studyID = ds.GetConvertValue(studyInformationElement)

               If studyID = studyInstanceUID Then
                  Return studyInformationElement
               End If
            End If

            studyElement = ds.GetNextKey(studyElement, True)
            studyElement = ds.GetChildElement(studyElement, True)
         End While


         patientElement = ds.GetNextKey(patientElement, True)
      End While

      Return Nothing
   End Function

   ' return the first frame file name of the series.
   Private Function GetFirstImageName(ds As DicomDataSet, seriesElement As DicomElement, directoryPath As String, ByRef imageElement As DicomElement) As String
      Dim imageIDElement As DicomElement = Nothing

      imageElement = ds.GetChildKey(seriesElement)
      imageElement = ds.GetChildElement(imageElement, True)

      While imageElement IsNot Nothing
         imageIDElement = ds.FindFirstElement(imageElement, DicomTag.ReferencedFileID, True)

         If imageIDElement IsNot Nothing Then
            Return (directoryPath & Convert.ToString("\")) + ds.GetConvertValue(imageIDElement)


         End If
      End While

      Return ""
   End Function


   ' return the next frame file name of the series.
   Private Function GetNextImageName(ds As DicomDataSet, directoryPath As String, ByRef imageElement As DicomElement) As String
      Dim nextImageElement As DicomElement = Nothing

      imageElement = ds.GetNextKey(imageElement, True)
      imageElement = ds.GetChildElement(imageElement, True)

      While imageElement IsNot Nothing
         nextImageElement = ds.FindFirstElement(imageElement, DicomTag.ReferencedFileID, True)

         If imageElement IsNot Nothing Then
            Dim echoElement As DicomElement = ds.FindFirstElement(imageElement, DicomTag.EchoNumber, True)

            Return (directoryPath & Convert.ToString("\")) + ds.GetConvertValue(nextImageElement)
         End If
      End While

      Return ""
   End Function


   ' Find the series using the Series instance UID, and return it's DicomElement if the series is found
   Private Function FindSeries(ds As DicomDataSet, studyElement As DicomElement, seriesInstanceUID As String) As DicomElement
      Dim seriesElement As DicomElement = Nothing
      Dim seriesInformationElement As DicomElement = Nothing
      Dim seriesID As String

      seriesElement = ds.GetChildKey(studyElement)
      seriesElement = ds.GetChildElement(seriesElement, True)

      While seriesElement IsNot Nothing
         seriesInformationElement = ds.FindFirstElement(seriesElement, DicomTag.SeriesInstanceUID, True)

         If seriesInformationElement IsNot Nothing Then
            seriesID = ds.GetConvertValue(seriesInformationElement)

            If seriesID = seriesInstanceUID Then
               Return seriesInformationElement
            End If
         End If

         seriesElement = ds.GetNextKey(seriesElement, True)
         seriesElement = ds.GetChildElement(seriesElement, True)
      End While
      Return Nothing
   End Function

   ' This will send Loading event to the user upon loading the series.
   Private Function SendLoadingEvent(seriesCount As Integer) As Boolean
      If LoadingEvent IsNot Nothing Then
         Dim args As New LoadingEventArgs(seriesCount)
         RaiseEvent Loading(Me, args)
         Return Not args.Cancel
      End If

      Return True
   End Function


   ' When double-clicking one of the studies in the studies grid, the program will load all the series that belong to the selected study
   Private Sub studiesDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles studiesDataGridView.CellDoubleClick
      ' if loading disabled, don't load.
      If Not btnLoad.Enabled Then
         Return
      End If

      If SendLoadingEvent(seriesDataGridView.Rows.Count) Then
         InitializeBackgroundWorker(True)
      End If
   End Sub


   Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
      If imagesLoader.IsBusy Then
         imagesLoader.CancelAsync()
      End If

      DialogResult = DialogResult.Cancel
   End Sub

   ' Report the progress by sending a progress event with all the information that the user might need
   Private Sub SendImageLoadedEvent(ds As DicomDataSet, studyElement As DicomElement, seriesElement As DicomElement, imageElement As DicomElement, currentSeries As Integer, seriesCount As Integer, _
    currentFrame As Integer, frameCount As Integer, progressType As DicomDirProgressType)
      Dim progress As New ProgressEventArgs(ds, studyElement, seriesElement, imageElement, currentSeries, seriesCount, _
       currentFrame, frameCount, progressType)
      imagesLoader.ReportProgress(CInt((progress.CurrentFrame + 1) * 100 / progress.FrameCount), progress)
   End Sub


   Private Function LoadFrames(ds As DicomDataSet, count As Integer, directoryPath As String) As Boolean
      Dim imagePath As String
      Dim dicomDataSet As DicomDataSet
      Dim imageIndex As Integer
      ' This loop will go through the images in the series and load them.
      Dim imageElement As DicomElement = Nothing

      Dim echoNumber As Integer = 0
      imagePath = GetFirstImageName(ds, _seriesElement, directoryPath, imageElement)
      For imageIndex = 0 To count - 1
         dicomDataSet = New DicomDataSet()

         Try
            dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None)
            If AddImageToImageArray(dicomDataSet, imageIndex, imagePath, echoNumber) Then
               _imagesPath.Add(imagePath)
               _echoNumber.Add(echoNumber)
            End If

            SendImageLoadedEvent(ds, _studyElement, _seriesElement, imageElement, _currentSeries, _seriesCount, _
             imageIndex, count, If(FrameLoadedEvent Is Nothing, DicomDirProgressType.LoadingImages, DicomDirProgressType.Preparing))
            dicomDataSet.Dispose()

            If imagesLoader.CancellationPending Then
               ' free the already allocated memory, since the user canceled the operation.
               For Each image As RasterImage In _imagesSeries
                  If image IsNot Nothing Then
                     image.Dispose()
                  End If
               Next

               ds.Dispose()
               SendFrameLoaded(Nothing, 0, FrameLoadedState.CancelLoading, "", 0, 0, _
                New Point3D(0, 0, 0), Nothing, Nothing)

               Return False
            End If
         Catch ex As System.Exception
         End Try

         imagePath = GetNextImageName(ds, directoryPath, imageElement)
      Next
      Return True
   End Function

   ' This method is the one that is used to load the series images, extract the localizers, and arrange the images based on their location(arranging the image is necessary to render the 3D object correctly)
   Private Function LoadSeriesImages(dicomDirFileName As String, studyInstanceUID As String, seriesInstanceUID As String, count As Integer, currentSeries As Integer, seriesCount As Integer) As Boolean
      Dim directoryPath As String
      Dim position As Integer
      position = dicomDirFileName.LastIndexOf("\")
      directoryPath = dicomDirFileName.Remove(position)

      sliceLocationArray = New Double(count - 1) {}
      doubleArray = New Double(2) {}
      imagesArray = New String(count - 1) {}
      localizerArray = New Boolean(count - 1) {}
      localizerPosition = New String(count - 1) {}
      _imagePosition = New List(Of Point3D)()
      arrayCounter = 0
      referenceUID = ""
      arrayCounter = 1

      _imagesSeries = New List(Of RasterImage)()
      _imagesPath = New List(Of String)()
      _echoNumber = New List(Of Integer)()

      For i As Integer = 0 To count - 1
         localizerPosition(i) = ""
      Next

      Dim ds As New DicomDataSet()
      ds.Load(dicomDirFileName, DicomDataSetLoadFlags.None)

      _studyElement = FindStudy(ds, studyInstanceUID)
      _seriesElement = FindSeries(ds, _studyElement, seriesInstanceUID)

      _seriesCount = seriesCount
      _currentSeries = currentSeries

      _seriesManager = New MedicalViewerSeriesManager()
      _imageDataList = New List(Of MedicalViewerImageData)()


      Try

         If Not LoadFrames(ds, count, directoryPath) Then
            Return False
         End If
      Catch exception As System.Exception
         System.Diagnostics.Debug.Assert(False, exception.Message)
         Throw
      End Try

      ds.Dispose()


      _seriesManager.Sort(_imageDataList)

      ' extract the localizers out of the image array
      ExtractLocalizers(count)

      ' sort the images based on their position, then add them to the final images list.
      If Not AddTheSeriesImages() Then
         Return False
      End If

      Return True
   End Function

   ' This will load the image with the specified index, also it will save some of its information later for additional processing.
   Private Function AddImageToImageArray(ds As DicomDataSet, index As Integer, imagePath As String, ByRef echoNumber As Integer) As Boolean
      Dim echoElemenet As DicomElement
      Dim patientID As String
      echoNumber = -1
      Dim addThisImage As Boolean = True

      If index = 0 Then
         Dim imageData As New MedicalViewerImageData()

         patientElement = ds.FindFirstElement(Nothing, DicomTag.ImagePositionPatient, True)

         doubleArray = ds.GetDoubleValue(patientElement, 0, 3)
         If doubleArray.Length = 0 Then
            doubleArray = New Double(2) {}
         End If

         _imagePosition.Add(Point3D.FromDoubleArray(doubleArray))

         imageData.ImagePosition = Point3D.FromDoubleArray(doubleArray)
         imageData.Data = imagePath

         echoElemenet = ds.FindFirstElement(Nothing, DicomTag.EchoNumber, True)

         If echoElemenet IsNot Nothing Then
            patientID = [String].Empty
            patientID = ds.GetConvertValue(echoElemenet)
            echoNumber = Convert.ToInt32(patientID)
         End If

         imageData.EchoNumber = echoNumber


         patientElement = ds.FindFirstElement(Nothing, DicomTag.InstanceNumber, True)

         If patientElement IsNot Nothing Then
            Dim integerArray As Integer()
            integerArray = ds.GetIntValue(patientElement, 0, 1)
            If integerArray.Length <> 0 Then
               imageData.InstanceNumber = integerArray(0)
            End If
         End If



         patientElement = ds.FindFirstElement(Nothing, DicomTag.FrameOfReferenceUID, True)

         If patientElement IsNot Nothing Then
            referenceUID = ds.GetConvertValue(patientElement)
         End If

         imageData.FrameOfReferenceUID = referenceUID

         patientElement = ds.FindFirstElement(Nothing, DicomTag.ImageOrientationPatient, True)

         If patientElement IsNot Nothing Then
            imagesArray(0) = ds.GetConvertValue(patientElement)
            imageData.ImageOrientation = ds.GetConvertValue(patientElement)
         End If
         localizerArray(0) = True

         localizerPosition(0) = imagePath

         patientElement = ds.FindFirstElement(Nothing, DicomTag.PixelSpacing, True)

         doubleArray = ds.GetDoubleValue(patientElement, 0, 2)
         If doubleArray.Length <> 0 Then
            imageData.PixelSpacing = New Point2D(CSng(doubleArray(0)), CSng(doubleArray(1)))
         Else
            imageData.PixelSpacing = New Point2D(1, 1)
         End If



         patientElement = ds.FindFirstElement(Nothing, DicomTag.SequenceName, True)

         If patientElement IsNot Nothing Then
            imageData.SequenceName = ds.GetConvertValue(patientElement)
         End If

         If FrameLoadedEvent Is Nothing Then
            _imagesSeries.Add(imageData.Image)
         Else
            _imagesSeries.Add(Nothing)
         End If

         _imageDataList.Add(imageData)

         Return addThisImage
      Else
         Dim imageData As New MedicalViewerImageData()

         patientElement = ds.FindFirstElement(Nothing, DicomTag.ImagePositionPatient, True)

         doubleArray = ds.GetDoubleValue(patientElement, 0, 3)
         If doubleArray.Length = 0 Then
            doubleArray = New Double(2) {}
         End If

         imageData.ImagePosition = New Point3D(CSng(doubleArray(0)), CSng(doubleArray(1)), CSng(doubleArray(2)))
         echoElemenet = ds.FindFirstElement(Nothing, DicomTag.EchoNumber, True)

         patientElement = ds.FindFirstElement(Nothing, DicomTag.FrameOfReferenceUID, True)


         If echoElemenet IsNot Nothing Then
            patientID = [String].Empty
            patientID = ds.GetConvertValue(echoElemenet)
            echoNumber = Convert.ToInt32(patientID)
         End If
         imageData.EchoNumber = echoNumber


         If patientElement IsNot Nothing Then
            imageData.FrameOfReferenceUID = ds.GetConvertValue(patientElement)
         Else
            imageData.FrameOfReferenceUID = ""
         End If

         If referenceUID <> imageData.FrameOfReferenceUID Then
            addThisImage = False
         End If



         If addThisImage Then

            patientElement = ds.FindFirstElement(Nothing, DicomTag.SequenceName, True)

            If patientElement IsNot Nothing Then
               imageData.SequenceName = ds.GetConvertValue(patientElement)
            End If

            patientElement = ds.FindFirstElement(Nothing, DicomTag.InstanceNumber, True)

            If patientElement IsNot Nothing Then
               Dim integerArray As Integer()
               integerArray = ds.GetIntValue(patientElement, 0, 1)
               If integerArray.Length <> 0 Then
                  imageData.InstanceNumber = integerArray(0)
               End If
            End If


            patientElement = ds.FindFirstElement(Nothing, DicomTag.ImageOrientationPatient, True)

            If patientElement IsNot Nothing Then
               imageData.ImageOrientation = ds.GetConvertValue(patientElement)
            End If

            imageData.Data = imagePath

            _imagePosition.Add(Point3D.FromDoubleArray(doubleArray))
            imageData.ImagePosition = Point3D.FromDoubleArray(doubleArray)

            patientElement = ds.FindFirstElement(Nothing, DicomTag.PixelSpacing, True)

            doubleArray = ds.GetDoubleValue(patientElement, 0, 2)

            If doubleArray.Length <> 0 Then
               imageData.PixelSpacing = New Point2D(CSng(doubleArray(0)), CSng(doubleArray(1)))
            Else
               imageData.PixelSpacing = New Point2D(1, 1)
            End If

            If FrameLoadedEvent Is Nothing Then
               _imagesSeries.Add(imageData.Image)
            Else
               _imagesSeries.Add(Nothing)
            End If

            _imageDataList.Add(imageData)

            arrayCounter += 1
         End If
         Return addThisImage
      End If
   End Function




   ' This will search for the images with different vital information like orientation, if the orientation of this image is different than the rest of the images, then we must remove it from the image array and load it separately since it doesn't belong to the list.
   Private Sub ExtractLocalizers(count As Integer)
      Dim ds As New DicomDataSet()
      Dim i As Integer

      Dim floatArray As Single()
      For i = 0 To _seriesManager.Localizers.Count - 1
         Dim imageInformation As New SeriesInformation()
         Dim fileName As String = CType(_seriesManager.Localizers(i).LocalizerData.Data, String)
         ds.Load(fileName, DicomDataSetLoadFlags.None)
         imageInformation = New SeriesInformation()

         imageInformation.DicomFrameNumber = GetDicomFrameNumber(ds)


         ' if the current dicom file doesn't contain image, then continue
         If imageInformation.DicomFrameNumber = -1 Then
            Continue For
         End If

         imageInformation.Image = ds.GetImage(Nothing, imageInformation.DicomFrameNumber, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AllowRangeExpansion)

         patientElement = ds.FindFirstElement(Nothing, DicomTag.InstanceNumber, True)

         If patientElement IsNot Nothing Then
            Dim integerArray As Integer()
            integerArray = ds.GetIntValue(patientElement, 0, 1)
            If integerArray.Length <> 0 Then
               imageInformation.InstanceNumber = integerArray(0)
            End If
         End If


         patientElement = ds.FindFirstElement(Nothing, DicomTag.PixelSpacing, True)

         doubleArray = ds.GetDoubleValue(patientElement, 0, 2)

         If patientElement IsNot Nothing Then
            imageInformation.VoxelSpacing = New Point3D(CSng(doubleArray(0)), CSng(doubleArray(1)), 1)
         End If

         patientElement = ds.FindFirstElement(Nothing, DicomTag.ImagePositionPatient, True)
         doubleArray = ds.GetDoubleValue(patientElement, 0, 3)
         If patientElement IsNot Nothing Then
            imageInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray)
         End If

         patientElement = ds.FindFirstElement(Nothing, DicomTag.FrameOfReferenceUID, True)
         If patientElement IsNot Nothing Then
            Dim str As String = ds.GetConvertValue(patientElement)
            imageInformation.FrameOfReferenceUID = str
         End If

         patientElement = ds.FindFirstElement(Nothing, DicomTag.ImageOrientationPatient, True)

         Dim imageOrientation As Single() = Nothing
         If patientElement IsNot Nothing Then
            doubleArray = ds.GetDoubleValue(patientElement, 0, 6)
            floatArray = New Single() {CSng(doubleArray(0)), CSng(doubleArray(1)), CSng(doubleArray(2)), CSng(doubleArray(3)), CSng(doubleArray(4)), CSng(doubleArray(5))}
            imageInformation.ImageOrientation = doubleArray
            imageOrientation = floatArray
         End If


         imageInformation.InstitutionName = GetDicomTag(ds, DicomTag.InstitutionName)
         imageInformation.PatientName = GetDicomTag(ds, DicomTag.PatientName)
         imageInformation.PatientAge = GetDicomTag(ds, DicomTag.PatientAge)
         imageInformation.PatientBirthDate = GetDicomTag(ds, DicomTag.PatientBirthDate)
         imageInformation.PatientSex = GetDicomTag(ds, DicomTag.PatientSex)
         imageInformation.PatientID = GetDicomTag(ds, DicomTag.PatientID)
         imageInformation.AccessionNumber = GetDicomTag(ds, DicomTag.AccessionNumber)
         imageInformation.StudyDate = GetDicomTag(ds, DicomTag.StudyDate)
         imageInformation.AcquisitionTime = GetDicomTag(ds, DicomTag.AcquisitionTime)
         imageInformation.SeriesTime = GetDicomTag(ds, DicomTag.SeriesTime)
         imageInformation.StationName = GetDicomTag(ds, DicomTag.StationName)
         imageInformation.StudyID = GetDicomTag(ds, DicomTag.StudyID)
         imageInformation.SeriesDescription = GetDicomTag(ds, DicomTag.SeriesDescription)
         imageInformation.ImageComments = GetDicomTag(ds, DicomTag.ImageComments)
         If FrameLoadedEvent Is Nothing Then
            Images.Add(imageInformation)
         Else
            Dim imagePosition As Point3D = imageInformation.ImagePosition
            SendFrameLoaded(imageInformation.Image, 0, FrameLoadedState.StartLoading, fileName, 1, imageInformation.InstanceNumber, _
             imagePosition, imageOrientation, imageInformation)
            SendFrameLoaded(imageInformation.Image, 0, FrameLoadedState.FrameLoaded, fileName, 1, imageInformation.InstanceNumber, _
             imagePosition, imageOrientation, imageInformation)
            SendFrameLoaded(Nothing, 0, FrameLoadedState.EndLoading, "", 0, imageInformation.InstanceNumber, _
             imagePosition, imageOrientation, imageInformation)

            System.Threading.Thread.Sleep(50)
         End If

         localizerCounter += 1
      Next
   End Sub


   ' get a raster image array and convert them into one multi-page Raster Image
   Private Sub CreateAMultiPageRasterImage(imageInformation As SeriesInformation, imageSeries As List(Of RasterImage), count As Integer)
      Dim i As Integer
      For i = 0 To count - 1
         If i = 0 Then
            imageInformation.Image = _imagesSeries(0)
         Else
            imageInformation.Image.AddPage(_imagesSeries(i))
         End If
      Next
   End Sub


   ' Send each frame through the FrameLoaded event
   Private Function SendFrameLoaded(image As RasterImage, imageIndex As Integer, state As FrameLoadedState, imagePath As String, pageCount As Integer, instanceNumber As Integer, _
    imagePosition As Point3D, imageOrientation As Single(), imageInformation As SeriesInformation) As Boolean
      ' if the event is not registered, then exist
      If FrameLoadedEvent Is Nothing Then
         Return True
      End If

      Dim args As New FrameLoadedEventArgs(image, imageIndex, state, imagePath, pageCount, instanceNumber, _
       imagePosition, imageOrientation, imageInformation)

      imagesLoader.ReportProgress(CInt((imageIndex + 1) * 100 / _imagesPath.Count), args)

      Return Not args.Cancel
   End Function

   Private Function GetEchoCount(echoCount As List(Of Integer)) As List(Of Integer)
      Dim echoList As New List(Of Integer)()
      For Each echoNumber As Integer In _echoNumber
         Dim index As Integer = echoList.IndexOf(echoNumber)
         If index = -1 Then
            echoList.Add(echoNumber)
            echoCount.Add(1)
         Else
            echoCount(index) += 1
         End If
      Next
      Return echoList
   End Function

   Private Function GetDicomFrameNumber(ds As DicomDataSet) As Integer
      Dim pageIndex As Integer
      Dim frameNumber As Integer = -1
      Dim pageCount As Integer = ds.GetImageCount(Nothing)
      Dim image As RasterImage

      Dim maxWidth As Integer = 0

      For pageIndex = 0 To pageCount - 1
         image = ds.GetImage(Nothing, pageIndex, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AllowRangeExpansion)

         If image.Width > maxWidth Then
            maxWidth = image.Width
            frameNumber = pageIndex
         End If

         image.Dispose()
      Next
      Return frameNumber
   End Function

   ' Send the frames and delete them afterward for memory efficiency
   Private Function SendLoadedImage_new(imagesPath As List(Of String), imageInformation As SeriesInformation) As Boolean
      Dim ds As DicomDataSet
      Dim imageData As MedicalViewerImageData
      Dim stackIndex As Integer = 0
      Dim frameIndex As Integer = 0
      Dim fileName As String
      Dim image As RasterImage = Nothing
      Dim instanceNumber As Integer

      For stackIndex = 0 To _seriesManager.Stacks.Count - 1
         Dim count As Integer = _seriesManager.Stacks(stackIndex).Items.Count
         For frameIndex = 0 To count - 1
            imageData = _seriesManager.Stacks(stackIndex).Items(frameIndex)
            fileName = CType(imageData.Data, String)
            ds = New DicomDataSet()
            ds.Load(fileName, DicomDataSetLoadFlags.None)
            SendImageLoadedEvent(ds, Nothing, Nothing, Nothing, stackIndex, _seriesManager.Stacks.Count, _
             frameIndex, count, DicomDirProgressType.LoadingImages)
            instanceNumber = imageData.InstanceNumber

            If imagesLoader.CancellationPending Then
               SendFrameLoaded(Nothing, 0, FrameLoadedState.CancelLoading, "", 0, 0, _
                New Point3D(0, 0, 0), Nothing, imageInformation)
               If image IsNot Nothing Then
                  image.Dispose()
               End If
               ds.Dispose()
               Return False
            End If

            If frameIndex = 0 Then
               imageInformation.DicomFrameNumber = GetDicomFrameNumber(ds)

               imageData.Image = ds.GetImage(Nothing, imageInformation.DicomFrameNumber, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AllowRangeExpansion)
               image = imageData.Image
               SendFrameLoaded(imageData.Image, frameIndex, FrameLoadedState.StartLoading, fileName, count, instanceNumber, _
                _seriesManager.Stacks(stackIndex).Items(frameIndex).ImagePosition, _seriesManager.Stacks(stackIndex).Items(0).ImageOrientationArray, imageInformation)
            End If

            SendFrameLoaded(imageData.Image, frameIndex, FrameLoadedState.FrameLoaded, fileName, count, instanceNumber, _
             _seriesManager.Stacks(stackIndex).Items(frameIndex).ImagePosition, _seriesManager.Stacks(stackIndex).Items(0).ImageOrientationArray, imageInformation)

            If frameIndex = count - 1 Then
               imageInformation.EchoNumber = _seriesManager.Stacks(stackIndex).EchoNumber
               SendFrameLoaded(imageData.Image, frameIndex, FrameLoadedState.EndLoading, fileName, count, instanceNumber, _
                _seriesManager.Stacks(stackIndex).Items(frameIndex).ImagePosition, _seriesManager.Stacks(stackIndex).Items(0).ImageOrientationArray, imageInformation)
            End If

            ds.Dispose()
         Next
      Next
      Return True
   End Function

   ' this function will sort the images based on their position.
   Private Function SortImages_new(imageSeries As List(Of RasterImage), position As List(Of Point3D), orientation As Double(), imageInformation As SeriesInformation) As Boolean
      Dim count As Integer = imageSeries.Count
      Dim data As MedicalViewerImageData = _seriesManager.Stacks(0).Items(0)

      imageInformation.VoxelSpacing = New Point3D(_seriesManager.Stacks(0).PixelSpacing.X, _seriesManager.Stacks(0).PixelSpacing.Y, 1)

      If FrameLoadedEvent Is Nothing Then
         CreateAMultiPageRasterImage(imageInformation, _imagesSeries, position.Count)
      Else
         Return SendLoadedImage_new(_imagesPath, imageInformation)
      End If

      Return True
   End Function

   ' This method returns the specified DICOM tag in a string format.
   Private Function GetDicomTag(ds As DicomDataSet, tag As Long) As String
      patientElement = ds.FindFirstElement(Nothing, tag, True)

      If patientElement IsNot Nothing Then
         Return ds.GetConvertValue(patientElement)
      End If

      Return Nothing
   End Function


   ' Sort the images based on their position, then add them to the final images list.
   Private Function AddTheSeriesImages() As Boolean

      Dim floatArray As Single() = New Single(5) {}
      Dim ds As New DicomDataSet()

      If _seriesManager.Stacks.Count <> 0 Then
         Dim imageInformation As New SeriesInformation()
         Dim fileName As String = CType(_seriesManager.Stacks(0).Items(0).Data, String)
         ds.Load(fileName, DicomDataSetLoadFlags.None)

         imageInformation.InstitutionName = GetDicomTag(ds, DicomTag.InstitutionName)
         imageInformation.PatientName = GetDicomTag(ds, DicomTag.PatientName)
         imageInformation.PatientAge = GetDicomTag(ds, DicomTag.PatientAge)
         imageInformation.PatientBirthDate = GetDicomTag(ds, DicomTag.PatientBirthDate)
         imageInformation.PatientSex = GetDicomTag(ds, DicomTag.PatientSex)
         imageInformation.PatientID = GetDicomTag(ds, DicomTag.PatientID)
         imageInformation.AccessionNumber = GetDicomTag(ds, DicomTag.AccessionNumber)
         imageInformation.StudyDate = GetDicomTag(ds, DicomTag.StudyDate)
         imageInformation.AcquisitionTime = GetDicomTag(ds, DicomTag.AcquisitionTime)
         imageInformation.SeriesTime = GetDicomTag(ds, DicomTag.SeriesTime)
         imageInformation.StationName = GetDicomTag(ds, DicomTag.StationName)
         imageInformation.StudyID = GetDicomTag(ds, DicomTag.StudyID)
         imageInformation.SeriesDescription = GetDicomTag(ds, DicomTag.SeriesDescription)
         imageInformation.ImageComments = GetDicomTag(ds, DicomTag.ImageComments)
         imageInformation.InstanceNumber = Convert.ToInt32(GetDicomTag(ds, DicomTag.InstanceNumber))

         patientElement = ds.FindFirstElement(Nothing, DicomTag.ImageOrientationPatient, True)

         Dim orientation As Double() = ds.GetDoubleValue(patientElement, 0, 6)

         imageInformation.ImageOrientation = orientation

         patientElement = ds.FindFirstElement(Nothing, DicomTag.ImagePositionPatient, True)

         doubleArray = ds.GetDoubleValue(patientElement, 0, 3)

         If patientElement IsNot Nothing Then
            imageInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray)
         End If

         patientElement = ds.FindFirstElement(Nothing, DicomTag.FrameOfReferenceUID, True)


         If patientElement IsNot Nothing Then
            Dim str As String = ds.GetConvertValue(patientElement)

            imageInformation.FrameOfReferenceUID = str
         Else
            imageInformation.FrameOfReferenceUID = ""
         End If


         If Not SortImages_new(_imagesSeries, _imagePosition, orientation, imageInformation) Then
            Return False
         End If
         If FrameLoadedEvent Is Nothing Then
            Images.Insert(Images.Count - localizerCounter, imageInformation)
         End If
      End If
      Return True
   End Function

   Private Sub buttonCancelProgress_Click(sender As Object, e As EventArgs) Handles buttonCancelProgress.Click
      If imagesLoader.IsBusy Then
         imagesLoader.CancelAsync()
      End If
   End Sub

   Private Sub seriesDataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles seriesDataGridView.CellMouseDoubleClick
      ' if loading disabled, don't load.
      If Not btnLoad.Enabled Then
         Return
      End If

      If SendLoadingEvent(1) Then
         InitializeBackgroundWorker(False)
      End If
   End Sub
   Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
      target = value
      Return value
   End Function

End Class

' A delegate type for hooking up the progress notifications.
Public Delegate Sub ProgressEventHandler(sender As Object, e As ProgressEventArgs)

' An event that clients can use to be notified whenever he attempts to load one or more series 
Public Delegate Sub LoadingEventHandler(sender As Object, e As LoadingEventArgs)

' A delegate type for hooking up the frame loaded notifications.
Public Delegate Sub FrameLoadedEventHandler(sender As Object, e As FrameLoadedEventArgs)

' A delegate type for hooking up the item added notifications.
Public Delegate Sub ItemAddedEventHandler(sender As Object, e As IteamAddedEventArgs)


' A class that contains the loaded image, which will be sent through the (ItemAdded event)
Public Class IteamAddedEventArgs
   Inherits EventArgs
   Private _item As SeriesInformation
   Public Sub New(item As SeriesInformation)
      _item = item
   End Sub

   Public ReadOnly Property Item() As SeriesInformation
      Get
         Return _item
      End Get
   End Property
End Class

' A class that is used to store the series information and pass it to the background worker in order to load it.
Public Class SeriesLoad
   Public StudyInstanceUID As String
   Public SeriesInstanceUID As String
   Public Count As Integer
   Public StudyInstanceUIDArray As String()
   Public DICOMDIRUIDArray As String()
   Public DataGridCount As Integer
   Public SeriesIndex As Integer
End Class


Public Enum FrameLoadedState
   StartLoading
   FrameLoaded
   EndLoading
   CancelLoading
End Enum

' A class that is used to give the user all the information he might need when a new frame has been loaded, the frame is disposed afterward for memory efficiency purposes.
Public Class FrameLoadedEventArgs
   Inherits EventArgs
   Private _frame As RasterImage
   Private _frameIndex As Integer
   Private _seriesInformation As SeriesInformation
   Private _state As FrameLoadedState
   Private _cancel As Boolean
   Private _imagePath As String
   Private _pageCount As Integer
   Private _instanceNumber As Integer
   Private _imagePosition As Point3D
   Private _imageOrientation As Single()

   Public Sub New(frame As RasterImage, frameIndex As Integer, state As FrameLoadedState, imagePath As String, pageCount As Integer, instanceNumber As Integer, _
    imagePosition As Point3D, imageOrientation As Single(), seriesInformation As SeriesInformation)
      _frame = frame
      _frameIndex = frameIndex
      _state = state
      _seriesInformation = seriesInformation
      _cancel = False
      _imagePath = imagePath
      _pageCount = pageCount
      _instanceNumber = instanceNumber
      _imagePosition = imagePosition
      _imageOrientation = imageOrientation
   End Sub

   Public Property ImageOrientation() As Single()
      Get
         Return _imageOrientation
      End Get

      Set(value As Single())
         _imageOrientation = value
      End Set
   End Property


   Public Property ImagePosition() As Point3D
      Get
         Return _imagePosition
      End Get

      Set(value As Point3D)
         _imagePosition = value
      End Set
   End Property



   Public Property InstanceNumber() As Integer
      Get
         Return _instanceNumber
      End Get

      Set(value As Integer)
         _instanceNumber = value
      End Set
   End Property

   Public Property ImagePath() As String
      Get
         Return _imagePath
      End Get
      Set(value As String)
         _imagePath = value
      End Set
   End Property

   Public Property PageCount() As Integer
      Get
         Return _pageCount
      End Get
      Set(value As Integer)
         _pageCount = value
      End Set
   End Property

   Public Property SeriesInformation() As SeriesInformation
      Get
         Return _seriesInformation
      End Get
      Set(value As SeriesInformation)
         _seriesInformation = value
      End Set
   End Property

   Public Property Frame() As RasterImage
      Get
         Return _frame
      End Get

      Set(value As RasterImage)
         _frame = value
      End Set
   End Property

   Public Property Cancel() As Boolean
      Get
         Return _cancel
      End Get

      Set(value As Boolean)
         _cancel = value
      End Set
   End Property

   Public Property FrameIndex() As Integer
      Get
         Return _frameIndex
      End Get

      Set(value As Integer)
         _frameIndex = value
      End Set
   End Property

   Public Property State() As FrameLoadedState
      Get
         Return _state
      End Get

      Set(value As FrameLoadedState)
         _state = value
      End Set
   End Property

End Class

' A class that is used to give the user the information he might need when upon loading the series
Public Class LoadingEventArgs
   Inherits EventArgs
   Private _seriesCount As Integer
   Private _cancel As Boolean

   Public Sub New(seriesCount As Integer)
      _seriesCount = seriesCount
      _cancel = False
   End Sub

   Public Property Cancel() As Boolean
      Get
         Return _cancel
      End Get

      Set(value As Boolean)
         _cancel = value
      End Set
   End Property

   Public ReadOnly Property SeriesCount() As Integer
      Get
         Return _seriesCount
      End Get
   End Property


End Class


Public Enum DicomDirProgressType
   Preparing
   LoadingImages
End Enum

' A class that is used to give the user all the information he might need when a new image has been (through progress event) loaded using this dialog
Public Class ProgressEventArgs
   Inherits EventArgs
   Private _dataSet As DicomDataSet
   Private _studyElement As DicomElement
   Private _seriesElement As DicomElement
   Private _imageElement As DicomElement
   Private _seriesCount As Integer
   Private _frameCount As Integer
   Private _currentFrame As Integer
   Private _currentSeries As Integer
   Private _cancel As Boolean
   Private _progressType As DicomDirProgressType

   Public Sub New(dataSet As DicomDataSet, studyElement As DicomElement, seriesElement As DicomElement, imageElement As DicomElement, currentSeries As Integer, seriesCount As Integer, _
    currentFrame As Integer, frameCount As Integer, progressType As DicomDirProgressType)
      _dataSet = dataSet
      _studyElement = studyElement
      _seriesElement = seriesElement
      _imageElement = imageElement
      _seriesCount = seriesCount
      _frameCount = frameCount
      _progressType = progressType
      _currentFrame = currentFrame
      _seriesCount = seriesCount
      _currentSeries = currentSeries
      _cancel = False
   End Sub

   Public Property ProgressType() As DicomDirProgressType
      Get
         Return _progressType
      End Get

      Set(value As DicomDirProgressType)
         _progressType = value
      End Set
   End Property


   Public Property Cancel() As Boolean
      Get
         Return _cancel
      End Get

      Set(value As Boolean)
         _cancel = value
      End Set
   End Property

   Public ReadOnly Property DataSet() As DicomDataSet
      Get
         Return _dataSet
      End Get
   End Property

   Public ReadOnly Property SeriesCount() As Integer
      Get
         Return _seriesCount
      End Get
   End Property

   Public ReadOnly Property CurrentSeries() As Integer
      Get
         Return _currentSeries
      End Get
   End Property


   Public ReadOnly Property StudyElement() As DicomElement
      Get
         Return _studyElement
      End Get
   End Property

   Public ReadOnly Property ImageElement() As DicomElement
      Get
         Return _imageElement
      End Get
   End Property

   Public ReadOnly Property FrameCount() As Integer
      Get
         Return _frameCount
      End Get
   End Property

   Public ReadOnly Property CurrentFrame() As Integer
      Get
         Return _currentFrame
      End Get
   End Property
End Class

' This class contains all the information of the loaded images
Public Class SeriesInformation
   Private _image As RasterImage
   Private _imagePosition As Point3D
   Private _imageOrientation As Double()
   Private _voxelSpacing As Point3D
   Private _firstPosition As Point3D
   Private _secondPosition As Point3D
   Private _frameOfReferenceUID As String
   Private _institutionName As String
   Private _patientName As String
   Private _patientAge As String
   Private _patientBirthDate As String
   Private _patientSex As String
   Private _patientID As String
   Private _accessionNumber As String
   Private _studyDate As String
   Private _acquisitionTime As String
   Private _seriesTime As String
   Private _stationName As String
   Private _studyID As String
   Private _seriesDescription As String
   Private _seriesNumber As String
   Private _studyDescription As String
   Private _imageComments As String
   Private _photometricInterpretation As String
   Private _dicomFrameNumber As Integer
   Private _echoNumber As Integer
   Private _firstInstanceNumber As Integer
   Private _secondInstanceNumber As Integer
   Private _instanceNumber As Integer

   Public Property InstanceNumber() As Integer
      Get
         Return _instanceNumber
      End Get

      Set(value As Integer)
         _instanceNumber = value
      End Set
   End Property

   Public Property FirstInstanceNumber() As Integer
      Get
         Return _firstInstanceNumber
      End Get

      Set(value As Integer)
         _firstInstanceNumber = value
      End Set
   End Property

   Public Property SecondInstanceNumber() As Integer
      Get
         Return _secondInstanceNumber
      End Get

      Set(value As Integer)
         _secondInstanceNumber = value
      End Set
   End Property


   Public Property DicomFrameNumber() As Integer
      Get
         Return _dicomFrameNumber
      End Get

      Set(value As Integer)
         _dicomFrameNumber = value
      End Set
   End Property


   Public Property Image() As RasterImage
      Get
         Return _image
      End Get

      Set(value As RasterImage)
         _image = value
      End Set
   End Property


   Public Property InstitutionName() As String
      Get
         Return _institutionName
      End Get

      Set(value As String)
         _institutionName = value
      End Set
   End Property

   Public Property PatientName() As String
      Get
         Return _patientName
      End Get

      Set(value As String)
         _patientName = value
      End Set
   End Property

   Public Property PatientAge() As String
      Get
         Return _patientAge
      End Get

      Set(value As String)
         _patientAge = value
      End Set
   End Property

   Public Property PatientBirthDate() As String
      Get
         Return _patientBirthDate
      End Get

      Set(value As String)
         _patientBirthDate = value
      End Set
   End Property

   Public Property PatientSex() As String
      Get
         Return _patientSex
      End Get

      Set(value As String)
         _patientSex = value
      End Set
   End Property

   Public Property PatientID() As String
      Get
         Return _patientID
      End Get

      Set(value As String)
         _patientID = value
      End Set
   End Property

   Public Property AccessionNumber() As String
      Get
         Return _accessionNumber
      End Get

      Set(value As String)
         _accessionNumber = value
      End Set
   End Property

   Public Property StudyDate() As String
      Get
         Return _studyDate
      End Get

      Set(value As String)
         _studyDate = value
      End Set
   End Property

   Public Property AcquisitionTime() As String
      Get
         Return _acquisitionTime
      End Get

      Set(value As String)
         _acquisitionTime = value
      End Set
   End Property

   Public Property SeriesTime() As String
      Get
         Return _seriesTime
      End Get

      Set(value As String)
         _seriesTime = value
      End Set
   End Property




   Public Property ImagePosition() As Point3D
      Get
         Return _imagePosition
      End Get

      Set(value As Point3D)
         _imagePosition = value
      End Set
   End Property

   Public Property ImageOrientation() As Double()
      Get
         Return _imageOrientation
      End Get

      Set(value As Double())
         _imageOrientation = value
      End Set
   End Property

   Public Property VoxelSpacing() As Point3D
      Get
         Return _voxelSpacing
      End Get

      Set(value As Point3D)
         _voxelSpacing = value
      End Set
   End Property

   Public Property FirstPosition() As Point3D
      Get
         Return _firstPosition
      End Get

      Set(value As Point3D)
         _firstPosition = value
      End Set
   End Property

   Public Property SecondPosition() As Point3D
      Get
         Return _secondPosition
      End Get

      Set(value As Point3D)
         _secondPosition = value
      End Set
   End Property

   Public Property FrameOfReferenceUID() As String
      Get
         Return _frameOfReferenceUID
      End Get

      Set(value As String)
         _frameOfReferenceUID = value
      End Set
   End Property



   Public Property StationName() As String
      Get
         Return _stationName
      End Get

      Set(value As String)
         _stationName = value
      End Set
   End Property

   Public Property StudyID() As String
      Get
         Return _studyID
      End Get

      Set(value As String)
         _studyID = value
      End Set
   End Property

   Public Property ImageComments() As String
      Get
         Return _imageComments
      End Get

      Set(value As String)
         _imageComments = value
      End Set
   End Property

   Public Property PhotometricInterpretation() As String
      Get
         Return _photometricInterpretation
      End Get

      Set(value As String)
         _photometricInterpretation = value
      End Set
   End Property


   Public Property StudyDescription() As String
      Get
         Return _studyDescription
      End Get

      Set(value As String)
         _studyDescription = value
      End Set
   End Property

   Public Property SeriesDescription() As String
      Get
         Return _seriesDescription
      End Get

      Set(value As String)
         _seriesDescription = value
      End Set
   End Property

   Public Property SeriesNumber() As String
      Get
         Return _seriesNumber
      End Get

      Set(value As String)
         _seriesNumber = value
      End Set
   End Property

   Public Property EchoNumber() As Integer
      Get
         Return _echoNumber
      End Get

      Set(value As Integer)
         _echoNumber = value
      End Set
   End Property


   Public Sub New()
      _imageOrientation = New Double(5) {}
      _image = Nothing
      _frameOfReferenceUID = ""
   End Sub
End Class
