// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

using Leadtools.Dicom;

namespace DicomDemo
{
    public partial class PlayBasicVoiceDialog : Form
    {
        private bool m_bInputDICOMFileNameChanged;
        private string m_strWaveFileName;
        private SoundPlayer m_SoundPlayer;

        public PlayBasicVoiceDialog()
        {
            InitializeComponent();

            try
            {
                m_SoundPlayer = new SoundPlayer();
                m_bInputDICOMFileNameChanged = true;
                m_strWaveFileName = Environment.GetEnvironmentVariable("TEMP");
                m_strWaveFileName += "\\ExtractedWaveFile.wav";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop any currently playing audio file
                btnStop.PerformClick();

                // Display an open file dialog and then set the filename in the text box
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*||";
                ofd.Multiselect = false;
                ofd.ShowDialog(this);
                txtBasicVoiceInputFile.Text = ofd.FileName;

                m_bInputDICOMFileNameChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                string strInFileName = txtBasicVoiceInputFile.Text;

                if (strInFileName == "" || !File.Exists(strInFileName))
                {
                    MessageBox.Show("Please enter a valid input file name");
                    return;
                }

                //Do we need to extract the wave stream from the DICOM file?
                if (m_bInputDICOMFileNameChanged)
                {
                    DicomDataSet ds = new DicomDataSet();
                    DicomWaveformGroup AudioWaveformGroup;

                    ds.Reset();

                    // Load the dataset
                    ds.Load(strInFileName, DicomDataSetLoadFlags.None);

                    // Do we have any waveforms in the dataset?
                    if (ds.WaveformGroupCount < 1)
                    {
                        MessageBox.Show("This dataset has no waveform groups");
                        return;
                    }

                    // Extract the first waveform group
                    AudioWaveformGroup = ds.GetWaveformGroup(0);

                    // Extract the wave stream from the waveform group and save it to disk
                    try
                    {
                       AudioWaveformGroup.SaveAudio(m_strWaveFileName);
                    }
                    catch
                    {
                       MessageBox.Show("Couldn't extract wave stream from DICOM file!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       return;
                    }
                }

                // Play the wave file
                m_SoundPlayer.SoundLocation = m_strWaveFileName;
                m_SoundPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop playing the audio file
                m_SoundPlayer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
