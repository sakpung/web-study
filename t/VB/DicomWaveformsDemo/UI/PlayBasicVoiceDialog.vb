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
Imports System.Media
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Dicom

Namespace DicomDemo
	Public Partial Class PlayBasicVoiceDialog : Inherits Form
		Private m_bInputDICOMFileNameChanged As Boolean
		Private m_strWaveFileName As String
		Private m_SoundPlayer As SoundPlayer

		Public Sub New()
			InitializeComponent()

			Try
				m_SoundPlayer = New SoundPlayer()
				m_bInputDICOMFileNameChanged = True
				m_strWaveFileName = Environment.GetEnvironmentVariable("TEMP")
				m_strWaveFileName &= "\ExtractedWaveFile.wav"
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowse.Click
			Try
				' Stop any currently playing audio file
				btnStop.PerformClick()

				' Display an open file dialog and then set the filename in the text box
				Dim ofd As OpenFileDialog = New OpenFileDialog()
				ofd.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*||"
				ofd.Multiselect = False
				ofd.ShowDialog(Me)
				txtBasicVoiceInputFile.Text = ofd.FileName

				m_bInputDICOMFileNameChanged = True
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPlay.Click
			Try
				Dim strInFileName As String = txtBasicVoiceInputFile.Text

				If strInFileName = "" OrElse (Not File.Exists(strInFileName)) Then
					MessageBox.Show("Please enter a valid input file name")
					Return
				End If

				'Do we need to extract the wave stream from the DICOM file?
				If m_bInputDICOMFileNameChanged Then
					Dim ds As DicomDataSet = New DicomDataSet()
					Dim AudioWaveformGroup As DicomWaveformGroup

					ds.Reset()

					' Load the dataset
					ds.Load(strInFileName, DicomDataSetLoadFlags.None)

					' Do we have any waveforms in the dataset?
					If ds.WaveformGroupCount < 1 Then
						MessageBox.Show("This dataset has no waveform groups")
						Return
					End If

					' Extract the first waveform group
					AudioWaveformGroup = ds.GetWaveformGroup(0)

					' Extract the wave stream from the waveform group and save it to disk
				   Try
					   AudioWaveformGroup.SaveAudio(m_strWaveFileName)
					Catch
					   MessageBox.Show("Couldn't extract wave stream from DICOM file!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					   Return
					End Try
				End If

				' Play the wave file
				m_SoundPlayer.SoundLocation = m_strWaveFileName
				m_SoundPlayer.Play()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btnStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStop.Click
			Try
				' Stop playing the audio file
				m_SoundPlayer.Stop()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub
	End Class
End Namespace
