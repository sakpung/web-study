// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Dicom;

namespace DicomDemo
{
    public partial class WaveformAttributesDialog : Form
    {
        public DicomWaveformGroup m_pWaveformGroup;

        /*
         * Creates a new WaveformAttributesDialog and initializes the form elements with the information
         *   from the DicomWaveformGroup passed
         */
        public WaveformAttributesDialog(ref DicomWaveformGroup pWaveformGroup)
        {
            InitializeComponent();

            m_pWaveformGroup = pWaveformGroup;

            // Add columns
            lvChannelAttributes.Columns.Add("Channel Sensitivity");
            lvChannelAttributes.Columns.Add("Channel Sensitivity Units");
            lvChannelAttributes.Columns.Add("Channel Source");
            lvChannelAttributes.Columns.Add("Filter Low Freq.");
            lvChannelAttributes.Columns.Add("Filter High Freq.");
            lvChannelAttributes.Columns.Add("Waveform Annotation");

            lvChannelAttributes.Columns[0].Width = 116;
            lvChannelAttributes.Columns[1].Width = 138;
            lvChannelAttributes.Columns[2].Width = 100;
            lvChannelAttributes.Columns[3].Width = 100;
            lvChannelAttributes.Columns[4].Width = 100;
            lvChannelAttributes.Columns[5].Width = 150;

            if ((m_pWaveformGroup != null) && (m_pWaveformGroup.ChannelCount > 0))
            {
                DicomWaveformChannel channel = null;
                DicomCodeSequenceItem ChannelSource;
                DicomWaveformAnnotation annotation = null;

                // Populate the text boxes with the general waveform information
                txtNumberOfChannels.Text = string.Format("{0:g}", m_pWaveformGroup.ChannelCount);
                txtSamplingFrequency.Text = string.Format("{0:g}", m_pWaveformGroup.GetSamplingFrequency());
                txtNumberOfWaveformSamples.Text = string.Format("{0:g}", m_pWaveformGroup.GetNumberOfSamplesPerChannel());

                switch (m_pWaveformGroup.GetSampleInterpretation())
                {
                    case DicomWaveformSampleInterpretationType.Signed16BitLinear:
                        txtSampleInterpretation.Text = "signed 16 bit linear";
                        break;
                    case  DicomWaveformSampleInterpretationType.Unsigned16BitLinear:
                        txtSampleInterpretation.Text = "unsigned 16 bit linear";
                        break;
                    case DicomWaveformSampleInterpretationType.Signed8BitLinear:
                        txtSampleInterpretation.Text = "signed 8 bit linear";
                        break;
                    case DicomWaveformSampleInterpretationType.Unsigned8BitLinear:
                        txtSampleInterpretation.Text = "unsigned 8 bit linear";
                        break;
                    case DicomWaveformSampleInterpretationType.Mulaw8Bit:
                        txtSampleInterpretation.Text = "8 bit mu-law";
                        break;
                    case DicomWaveformSampleInterpretationType.Alaw8Bit:
                        txtSampleInterpretation.Text = "8 bit A-law";
                        break;
                }

                switch (m_pWaveformGroup.GetSampleInterpretation())
                {
                    case DicomWaveformSampleInterpretationType.Signed16BitLinear:
                    case DicomWaveformSampleInterpretationType.Unsigned16BitLinear:
                        txtWaveformBitsAllocated.Text = "16";
                        break;
                    case DicomWaveformSampleInterpretationType.Signed8BitLinear:
                    case DicomWaveformSampleInterpretationType.Unsigned8BitLinear:
                    case DicomWaveformSampleInterpretationType.Mulaw8Bit:
                    case DicomWaveformSampleInterpretationType.Alaw8Bit:
                        txtWaveformBitsAllocated.Text = "8";
                        break;
                }

                txtWaveformPaddingValue.Text = string.Format("{0:g}", m_pWaveformGroup.GetWaveformPaddingValue());

                // Populate the list view with the specific information for each channel
                string[] strItemText;
                for (int nIndex = 0; nIndex < m_pWaveformGroup.ChannelCount; nIndex++)
                {
                    channel = m_pWaveformGroup.GetChannel(nIndex);
                    if (channel != null)
                    {
                        DicomChannelSensitivity channelSensitivity = channel.GetChannelSensitivity();

                        if ((channelSensitivity != null) && ((channelSensitivity.SensitivityUnits.CodeMeaning != null) && (channelSensitivity.SensitivityUnits.CodeMeaning != "")))
                        {
                            ChannelSource = channel.GetChannelSource();

                            strItemText = new string[6] {
                                string.Format("{0:g}", channelSensitivity.Sensitivity),
                                channelSensitivity.SensitivityUnits.CodeMeaning,
                                ChannelSource.CodeMeaning,
                                string.Format("{0:g}", channel.GetFilterLowFrequency()),
                                string.Format("{0:g}", channel.GetFilterHighFrequency()),
                                ""};

                            if (channel.GetAnnotationCount() > 0)
                            {
                                annotation = channel.GetAnnotation(0);
                                if (annotation != null)
                                {
                                    if ((annotation.UnformattedTextValue != null) && (annotation.UnformattedTextValue != ""))
                                    {
                                        strItemText[5] = annotation.UnformattedTextValue;
                                    }
                                    else
                                    {
                                        if ((annotation.CodedName != null) && ((annotation.CodedName.CodeMeaning != null) && (annotation.CodedName != null)))
                                        {
                                            strItemText[5] = annotation.CodedName.CodeMeaning;
                                        }
                                    }
                                }
                            }

                            lvChannelAttributes.Items.Add(new ListViewItem(strItemText));
                        }
                    }
                }
            }
        }
    }
}
