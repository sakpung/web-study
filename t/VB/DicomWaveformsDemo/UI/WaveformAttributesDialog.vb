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
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Dicom

Namespace DicomDemo
	Public Partial Class WaveformAttributesDialog : Inherits Form
		Public m_pWaveformGroup As DicomWaveformGroup

		'
		 '* Creates a new WaveformAttributesDialog and initializes the form elements with the information
		 '*   from the DicomWaveformGroup passed
		 '
		Public Sub New(ByRef pWaveformGroup As DicomWaveformGroup)
			InitializeComponent()

			m_pWaveformGroup = pWaveformGroup

			' Add columns
			lvChannelAttributes.Columns.Add("Channel Sensitivity")
			lvChannelAttributes.Columns.Add("Channel Sensitivity Units")
			lvChannelAttributes.Columns.Add("Channel Source")
			lvChannelAttributes.Columns.Add("Filter Low Freq.")
			lvChannelAttributes.Columns.Add("Filter High Freq.")
			lvChannelAttributes.Columns.Add("Waveform Annotation")

			lvChannelAttributes.Columns(0).Width = 116
			lvChannelAttributes.Columns(1).Width = 138
			lvChannelAttributes.Columns(2).Width = 100
			lvChannelAttributes.Columns(3).Width = 100
			lvChannelAttributes.Columns(4).Width = 100
			lvChannelAttributes.Columns(5).Width = 150

			If (Not m_pWaveformGroup Is Nothing) AndAlso (m_pWaveformGroup.ChannelCount > 0) Then
				Dim channel As DicomWaveformChannel = Nothing
				Dim ChannelSource As DicomCodeSequenceItem
				Dim annotation As DicomWaveformAnnotation = Nothing

				' Populate the text boxes with the general waveform information
				txtNumberOfChannels.Text = String.Format("{0:g}", m_pWaveformGroup.ChannelCount)
				txtSamplingFrequency.Text = String.Format("{0:g}", m_pWaveformGroup.GetSamplingFrequency())
				txtNumberOfWaveformSamples.Text = String.Format("{0:g}", m_pWaveformGroup.GetNumberOfSamplesPerChannel())

				Select Case m_pWaveformGroup.GetSampleInterpretation()
					Case DicomWaveformSampleInterpretationType.Signed16BitLinear
						txtSampleInterpretation.Text = "signed 16 bit linear"
					Case DicomWaveformSampleInterpretationType.Unsigned16BitLinear
						txtSampleInterpretation.Text = "unsigned 16 bit linear"
					Case DicomWaveformSampleInterpretationType.Signed8BitLinear
						txtSampleInterpretation.Text = "signed 8 bit linear"
					Case DicomWaveformSampleInterpretationType.Unsigned8BitLinear
						txtSampleInterpretation.Text = "unsigned 8 bit linear"
					Case DicomWaveformSampleInterpretationType.Mulaw8Bit
						txtSampleInterpretation.Text = "8 bit mu-law"
					Case DicomWaveformSampleInterpretationType.Alaw8Bit
						txtSampleInterpretation.Text = "8 bit A-law"
				End Select

				Select Case m_pWaveformGroup.GetSampleInterpretation()
					Case DicomWaveformSampleInterpretationType.Signed16BitLinear, DicomWaveformSampleInterpretationType.Unsigned16BitLinear
						txtWaveformBitsAllocated.Text = "16"
					Case DicomWaveformSampleInterpretationType.Signed8BitLinear, DicomWaveformSampleInterpretationType.Unsigned8BitLinear, DicomWaveformSampleInterpretationType.Mulaw8Bit, DicomWaveformSampleInterpretationType.Alaw8Bit
						txtWaveformBitsAllocated.Text = "8"
				End Select

				txtWaveformPaddingValue.Text = String.Format("{0:g}", m_pWaveformGroup.GetWaveformPaddingValue())

				' Populate the list view with the specific information for each channel
				Dim strItemText As String()
				Dim nIndex As Integer = 0
				Do While nIndex < m_pWaveformGroup.ChannelCount
					channel = m_pWaveformGroup.GetChannel(nIndex)
					If Not channel Is Nothing Then
						Dim channelSensitivity As DicomChannelSensitivity = channel.GetChannelSensitivity()

						If (Not channelSensitivity Is Nothing) AndAlso ((Not channelSensitivity.SensitivityUnits.CodeMeaning Is Nothing) AndAlso (channelSensitivity.SensitivityUnits.CodeMeaning <> "")) Then
							ChannelSource = channel.GetChannelSource()

							strItemText = New String(5) { String.Format("{0:g}", channelSensitivity.Sensitivity), channelSensitivity.SensitivityUnits.CodeMeaning, ChannelSource.CodeMeaning, String.Format("{0:g}", channel.GetFilterLowFrequency()), String.Format("{0:g}", channel.GetFilterHighFrequency()), ""}

							If channel.GetAnnotationCount() > 0 Then
								annotation = channel.GetAnnotation(0)
								If Not annotation Is Nothing Then
									If (Not annotation.UnformattedTextValue Is Nothing) AndAlso (annotation.UnformattedTextValue <> "") Then
										strItemText(5) = annotation.UnformattedTextValue
									Else
										If (Not annotation.CodedName Is Nothing) AndAlso ((Not annotation.CodedName.CodeMeaning Is Nothing) AndAlso (Not annotation.CodedName Is Nothing)) Then
											strItemText(5) = annotation.CodedName.CodeMeaning
										End If
									End If
								End If
							End If

							lvChannelAttributes.Items.Add(New ListViewItem(strItemText))
						End If
					End If
					nIndex += 1
				Loop
			End If
		End Sub
	End Class
End Namespace
