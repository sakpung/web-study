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
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace DicomDemo
	Public Partial Class BasicVoiceDialog : Inherits Form
		Private m_nInstanceNumber As Integer
		Private Const LEAD_IMPLEMENTATION_CLASS_UID As String ="1.2.840.114257.0.1"
		Private Const LEAD_IMPLEMENTATION_VERSION_NAME As String = "LEADTOOLS Demo"

		Public Sub New()
			InitializeComponent()

			txtInfo.Text = "The DICOM standard states: ""The Basic Voice Audio IOD is the " & " specification of a digitized sound that has been acquired or" & " created by an audio modality or by an audio acquisition" & " function within an imaging modality. A typical use is ""Report Dictation"".""" & Constants.vbCrLf & Constants.vbCrLf & "Some of the constraints of this IOD include:" & Constants.vbCrLf & Constants.vbCrLf & "1.The " & "value of the Sampling Frequency (003A, 001A) in the Waveform " & "Sequence Item shall be 8000." & Constants.vbCrLf & Constants.vbCrLf & "2.The value of the Waveform Sample " & "Interpretation (5400,1006) in the Waveform Sequence Item shall be " & "UB, MB, or AB. " & Constants.vbCrLf & Constants.vbCrLf & "This means that when you use this IOD for report " & "dictation for example then the ""Samples Per Second (sampling rate)""" & " for the wave stream needs to be 8K, the ""Format Category"" needs " & "to be PCM, mu-Law or a-Law and the ""Bits Per Sample (sample size)"" needs to be 8." & Constants.vbCrLf & Constants.vbCrLf & "This dialog shows how to use the DicomWaveformGroup.LoadAudio function " & "to insert a wave file into a DICOM file of type Basic Voice Audio."

			m_nInstanceNumber = 0
		End Sub

		Private Sub btnBrowse1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowse1.Click
			Try
				' Display an open file dialog and then set the filename in the text box
				Dim ofd As OpenFileDialog = New OpenFileDialog()
				ofd.Filter = "Wave Files (*.wav)|*.wav|All files (*.*)|*.*||"
				ofd.Multiselect = False
				ofd.ShowDialog(Me)
				txtInputFile.Text = ofd.FileName
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btnBrowse2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowse2.Click
			Try
				' Display a save file dialog and then set the filename in the text box
				Dim sfd As SaveFileDialog = New SaveFileDialog()
                sfd.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*||"
				sfd.ShowDialog(Me)
				txtOutputFile.Text = sfd.FileName
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreate.Click
			Dim strOutDicomFileName As String = txtOutputFile.Text
			Dim strInWaveFileName As String = txtInputFile.Text
			Dim VoiceAudioDS As DicomDataSet = New DicomDataSet()

			' Check the inputs for validity
			If (strInWaveFileName = "") OrElse Not(File.Exists(strInWaveFileName)) Then
				MessageBox.Show("Please enter a valid input file name ")
				Return
			End If
			If strOutDicomFileName = "" Then
				MessageBox.Show("Please enter a valid output file name ")
				Return
			End If
			If strOutDicomFileName = strInWaveFileName Then
				MessageBox.Show("Input and output file names can't be the same!")
				Return
			End If

			' Load the Basic Voice Audio template DICOM file 
			Try
				VoiceAudioDS.Reset()
				VoiceAudioDS.Load(Application.StartupPath & "\..\..\..\Examples\DotNet\Resources\DicomWaveforms\VoiceAudioTemplate.dic", DicomDataSetLoadFlags.LoadAndClose)
			Catch ex As Exception
				MessageBox.Show("Error opening template file:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
				Return
			End Try

			' Insert the wave file into the resulting DICOM file
			If (Not InsertWaveStream(VoiceAudioDS, strInWaveFileName)) Then
				Return
			End If


			' Generate new UIDs for the resulting dataset
			SetInstanceUIDs(VoiceAudioDS)
			' Generate new instance numbers for the resulting dataset
            SetInstanceNumbers(VoiceAudioDS, m_nInstanceNumber)
            m_nInstanceNumber += 1
			'Set dates and times
			SetStudyDateAndTime(VoiceAudioDS)
			'Fill meta header
			InsertMetaHeader(VoiceAudioDS)

			' Now save the dataset
			Try
				VoiceAudioDS.Save(strOutDicomFileName, DicomDataSetSaveFlags.GroupLengths Or DicomDataSetSaveFlags.MetaHeaderPresent)
				MessageBox.Show("A  new basic Voice Audio File was created and saved to:" & Constants.vbCrLf & strOutDicomFileName)
			Catch ex As Exception
				MessageBox.Show("Error saving Dataset:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
				Return
			End Try
		End Sub

		'
		 '* Adds a waveform group for a Wav file to a Dataset
		 '
		Private Function InsertWaveStream(ByRef InDS As DicomDataSet, ByVal strInputWaveFileName As String) As Boolean
			Dim AudioWaveformGroup As DicomWaveformGroup = New DicomWaveformGroup()
			Dim nNumberOfChannels As Integer = 0

			' Load an audio file into the waveform group
			Try
				AudioWaveformGroup.LoadAudio(strInputWaveFileName)
			Catch ex As Exception
				MessageBox.Show("Couldn't insert the wave stream into the dataset." & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
				Return False
			End Try

			' Verify that hte frequency is 8K
			Dim nSamplingFrequency As Integer = CInt(AudioWaveformGroup.GetSamplingFrequency())
			If nSamplingFrequency <> 8000 Then
				MessageBox.Show("The samples per second (sampling rate) for the wave file should be 8KHz.")
				Return False
			End If

			' Set the channel source
			nNumberOfChannels = AudioWaveformGroup.ChannelCount
			If nNumberOfChannels > 0 Then
				Dim channel As DicomWaveformChannel = Nothing
				Dim DicomSourceSequenceItem As DicomCodeSequenceItem = New DicomCodeSequenceItem()

				DicomSourceSequenceItem.CodeMeaning = "Dictation"
				DicomSourceSequenceItem.CodeValue = "110011"
				DicomSourceSequenceItem.CodingSchemeDesignator = "DCM"
				DicomSourceSequenceItem.CodingSchemeVersion = "01"

				Dim nIndex As Integer = 0
				Do While nIndex < nNumberOfChannels
					channel = AudioWaveformGroup.GetChannel(nIndex)
					If Not channel Is Nothing Then
						Try
							channel.SetChannelSource(DicomSourceSequenceItem)
						Catch ex As Exception
							MessageBox.Show("Couldn't set the channel source" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
							Return False
						End Try
					End If
					nIndex += 1
				Loop
			End If

			' Insert the waveform group into the dataset
			Try
				InDS.AddWaveformGroup(AudioWaveformGroup, 0)
			Catch ex As Exception
				MessageBox.Show("Couldn't insert the wave stream into the dataset." & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
				Return False
			End Try
			Return True
		End Function

		'
		 '* Sets the necessary UIDs in the Dataset
		 '
		Private Sub SetInstanceUIDs(ByRef pDS As DicomDataSet)
			Dim element As DicomElement

			' Set STUDY INSTANCE UID
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.StudyInstanceUID, False)
			If element Is Nothing Then
				element = pDS.InsertElement(Nothing, False, DemoDicomTags.StudyInstanceUID, DicomVRType.UI, False, 0)
			End If
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1)

			' Set SERIES INSTANCE UID
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.SeriesInstanceUID, False)
			If element Is Nothing Then
				element = pDS.InsertElement(Nothing, False, DemoDicomTags.SeriesInstanceUID, DicomVRType.UI, False, 0)
			End If
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1)

			' Set SOP INSTANCE UID
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.SOPInstanceUID, False)
			If element Is Nothing Then
				element = pDS.InsertElement(Nothing, False, DemoDicomTags.SOPInstanceUID, DicomVRType.UI, False, 0)
			End If
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1)

			' Media Storage SOP Instance UID
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.MediaStorageSOPInstanceUID, False)
			If element Is Nothing Then
				element = pDS.InsertElement(Nothing, False, DemoDicomTags.MediaStorageSOPInstanceUID, DicomVRType.UI, False, 0)
			End If
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1)
		End Sub

		'
		 '* Sets the Instance Numbers for this dataset
		 '
		Private Sub SetInstanceNumbers(ByRef pDS As DicomDataSet, ByVal nInstanceNumber As Integer)
			Dim element As DicomElement
			Dim strValue As String

			strValue = String.Format("{0}", nInstanceNumber)

			' Series number
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.SeriesNumber, False)
			If Not element Is Nothing Then
				pDS.SetConvertValue(element, strValue, 1)
			End If

			' Instance number
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.InstanceNumber, False)
			If Not element Is Nothing Then
				pDS.SetConvertValue(element, strValue, 1)
			End If

			' Study ID
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.StudyID, False)
			If Not element Is Nothing Then
				pDS.SetConvertValue(element, strValue, 1)
			End If

			strValue = String.Format("854125{0}", nInstanceNumber)
			' Accession number
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.AccessionNumber, False)
			If Not element Is Nothing Then
				pDS.SetConvertValue(element, strValue, 1)
			End If
		End Sub

		'
		 '* Sets the appropriate dates for this Dataset
		 '
		Private Sub SetStudyDateAndTime(ByRef pDS As DicomDataSet)
			Try
				Dim SystemTime As DateTime = DateTime.Now
				Dim strValue As String
				Dim element As DicomElement

				' Set study date
				strValue = SystemTime.ToShortDateString()
				element = pDS.FindFirstElement(Nothing, DemoDicomTags.StudyDate, False)
				If Not element Is Nothing Then
					pDS.SetConvertValue(element, strValue, 1)
				End If

				' Set content date
				element = pDS.FindFirstElement(Nothing, DemoDicomTags.ContentDate, False)
				If Not element Is Nothing Then
					pDS.SetConvertValue(element, strValue, 1)
				End If

				' Set Study time
				strValue = String.Format("{0}:{1}:{2}", SystemTime.Hour, SystemTime.Minute, SystemTime.Second)
				element = pDS.FindFirstElement(Nothing, DemoDicomTags.StudyTime, False)
				If Not element Is Nothing Then
					pDS.SetConvertValue(element, strValue, 1)
				End If

				' Set content time
				element = pDS.FindFirstElement(Nothing, DemoDicomTags.ContentTime, False)
				If Not element Is Nothing Then
					pDS.SetConvertValue(element, strValue, 1)
				End If

				strValue = String.Format("{0} {1}:{2}:{3}", SystemTime.ToShortDateString(), SystemTime.Hour, SystemTime.Minute, SystemTime.Second)
				' Set acquisition date time
				element = pDS.FindFirstElement(Nothing, DemoDicomTags.AcquisitionDatetime, False)
				If Not element Is Nothing Then
					pDS.SetConvertValue(element, strValue, 1)
				End If
			Catch ex As Exception
				MessageBox.Show("Error while setting the dataset's dates: " & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
			End Try
		End Sub

		'
		 '* Creates and modifies the meta header for this dataset
		 '
		Private Sub InsertMetaHeader(ByRef pDS As DicomDataSet)
			Dim element As DicomElement

			' Add File Meta Information Version
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.FileMetaInformationVersion, False)
			If element Is Nothing Then
				element = pDS.InsertElement(Nothing, False, DemoDicomTags.FileMetaInformationVersion, DicomVRType.OB, False, 0)
			End If
			Dim cValue As Byte() = New Byte(1) { 0, 1 }
			pDS.SetBinaryValue(element, cValue, 2)

			' Implementation Class UID
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.ImplementationClassUID, False)
			If element Is Nothing Then
				element = pDS.InsertElement(Nothing, False, DemoDicomTags.ImplementationClassUID, DicomVRType.UI, False, 0)
			End If
			pDS.SetConvertValue(element, LEAD_IMPLEMENTATION_CLASS_UID, 1)

			' Implementation Version Name
			element = pDS.FindFirstElement(Nothing, DemoDicomTags.ImplementationVersionName, False)
			If element Is Nothing Then
				element = pDS.InsertElement(Nothing, False, DemoDicomTags.ImplementationVersionName, DicomVRType.UI, False, 0)
			End If
			pDS.SetConvertValue(element, LEAD_IMPLEMENTATION_VERSION_NAME, 1)
		End Sub
	End Class
End Namespace
