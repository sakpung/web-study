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
using System.Text;
using System.Windows.Forms;

using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    public partial class BasicVoiceDialog : Form
    {
        private int m_nInstanceNumber;
        const string LEAD_IMPLEMENTATION_CLASS_UID ="1.2.840.114257.0.1";
        const string LEAD_IMPLEMENTATION_VERSION_NAME = "LEADTOOLS Demo";

        public BasicVoiceDialog()
        {
            InitializeComponent();

            txtInfo.Text =  "The DICOM standard states: \"The Basic Voice Audio IOD is the " + 
                            " specification of a digitized sound that has been acquired or" +
                            " created by an audio modality or by an audio acquisition" +
                            " function within an imaging modality. A typical use is \"Report Dictation\".\"" +
                            "\r\n\r\nSome of the constraints of this IOD include:\r\n\r\n1.The " +
                            "value of the Sampling Frequency (003A, 001A) in the Waveform " +
                            "Sequence Item shall be 8000.\r\n\r\n2.The value of the Waveform Sample " +
                            "Interpretation (5400,1006) in the Waveform Sequence Item shall be " +
                            "UB, MB, or AB. \r\n\r\nThis means that when you use this IOD for report " +
                            "dictation for example then the \"Samples Per Second (sampling rate)\"" +
                            " for the wave stream needs to be 8K, the \"Format Category\" needs " +
                            "to be PCM, mu-Law or a-Law and the \"Bits Per Sample (sample size)\" needs to be 8." +
                            "\r\n\r\nThis dialog shows how to use the DicomWaveformGroup.LoadAudio function " +
                            "to insert a wave file into a DICOM file of type Basic Voice Audio.";

            m_nInstanceNumber = 0;
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            try
            {
                // Display an open file dialog and then set the filename in the text box
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Wave Files (*.wav)|*.wav|All files (*.*)|*.*||";
                ofd.Multiselect = false;
                ofd.ShowDialog(this);
                txtInputFile.Text = ofd.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            try
            {
                // Display a save file dialog and then set the filename in the text box
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*||";
                sfd.ShowDialog(this);
                txtOutputFile.Text = sfd.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string strOutDicomFileName = txtOutputFile.Text;
            string strInWaveFileName = txtInputFile.Text;
            DicomDataSet VoiceAudioDS = new DicomDataSet();

            // Check the inputs for validity
            if ((strInWaveFileName == "") || !(File.Exists(strInWaveFileName)))
            {
                MessageBox.Show("Please enter a valid input file name ");
                return;
            }
            if (strOutDicomFileName == "")
            {
                MessageBox.Show("Please enter a valid output file name ");
                return;
            }
            if (strOutDicomFileName == strInWaveFileName)
            {
                MessageBox.Show("Input and output file names can't be the same!");
                return;
            }

            // Load the Basic Voice Audio template DICOM file 
            try
            {
                VoiceAudioDS.Reset();
                VoiceAudioDS.Load(Application.StartupPath + @"\..\..\..\Examples\DotNet\Resources\DicomWaveforms\VoiceAudioTemplate.dic", DicomDataSetLoadFlags.LoadAndClose);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening template file:\r\n\r\n" + ex.ToString());
                return;
            }

            // Insert the wave file into the resulting DICOM file
            if (!InsertWaveStream(ref VoiceAudioDS, strInWaveFileName))
                return;


            // Generate new UIDs for the resulting dataset
            SetInstanceUIDs(ref VoiceAudioDS);
            // Generate new instance numbers for the resulting dataset
            SetInstanceNumbers(ref VoiceAudioDS, m_nInstanceNumber++);
            //Set dates and times
            SetStudyDateAndTime(ref VoiceAudioDS);   
            //Fill meta header
            InsertMetaHeader(ref VoiceAudioDS);
            
            // Now save the dataset
            try
            {
                VoiceAudioDS.Save(strOutDicomFileName, DicomDataSetSaveFlags.GroupLengths | DicomDataSetSaveFlags.MetaHeaderPresent);
                MessageBox.Show("A  new basic Voice Audio File was created and saved to:\r\n" + strOutDicomFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Dataset:\r\n\r\n" + ex.ToString());
                return;
            }
        }

        /*
         * Adds a waveform group for a Wav file to a Dataset
         */
        private bool InsertWaveStream(ref DicomDataSet InDS, string strInputWaveFileName)
        {
            DicomWaveformGroup AudioWaveformGroup = new DicomWaveformGroup();
            int nNumberOfChannels = 0;

            // Load an audio file into the waveform group
            try
            {
                AudioWaveformGroup.LoadAudio(strInputWaveFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't insert the wave stream into the dataset.\r\n\r\n" + ex.ToString());
                return false;
            }

            // Verify that hte frequency is 8K
            int nSamplingFrequency = (int)AudioWaveformGroup.GetSamplingFrequency();
            if (nSamplingFrequency != 8000)
            {
                MessageBox.Show("The samples per second (sampling rate) for the wave file should be 8KHz.");
                return false;
            }

            // Set the channel source
            nNumberOfChannels = AudioWaveformGroup.ChannelCount;
            if (nNumberOfChannels > 0)
            {
                DicomWaveformChannel channel = null;
                DicomCodeSequenceItem DicomSourceSequenceItem = new DicomCodeSequenceItem();

                DicomSourceSequenceItem.CodeMeaning = "Dictation";
                DicomSourceSequenceItem.CodeValue = "110011";
                DicomSourceSequenceItem.CodingSchemeDesignator = "DCM";
                DicomSourceSequenceItem.CodingSchemeVersion = "01";

                for (int nIndex = 0; nIndex < nNumberOfChannels; nIndex++)
                {
                    channel = AudioWaveformGroup.GetChannel(nIndex);
                    if (channel != null)
                    {
                        try
                        {
                            channel.SetChannelSource(DicomSourceSequenceItem);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Couldn't set the channel source\r\n\r\n" + ex.ToString());
                            return false;
                        }
                    }
                }
            }

            // Insert the waveform group into the dataset
            try
            {
                InDS.AddWaveformGroup(AudioWaveformGroup, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't insert the wave stream into the dataset.\r\n\r\n" + ex.ToString());
                return false;
            }
            return true;
        }

        /*
         * Sets the necessary UIDs in the Dataset
         */
        private void SetInstanceUIDs(ref DicomDataSet pDS)
        {
            DicomElement element;

            // Set STUDY INSTANCE UID
            element = pDS.FindFirstElement(null, DemoDicomTags.StudyInstanceUID, false);
            if (element == null)
            {
                element = pDS.InsertElement(null, false, DemoDicomTags.StudyInstanceUID, DicomVRType.UI, false, 0);
            }
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1);

            // Set SERIES INSTANCE UID
            element = pDS.FindFirstElement(null, DemoDicomTags.SeriesInstanceUID, false);
            if (element == null)
            {
                element = pDS.InsertElement(null, false, DemoDicomTags.SeriesInstanceUID, DicomVRType.UI, false, 0);
            }
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1);

            // Set SOP INSTANCE UID
            element = pDS.FindFirstElement(null, DemoDicomTags.SOPInstanceUID, false);
            if (element == null)
            {
                element = pDS.InsertElement(null, false, DemoDicomTags.SOPInstanceUID, DicomVRType.UI, false, 0);
            }
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1);

            // Media Storage SOP Instance UID
            element = pDS.FindFirstElement(null, DemoDicomTags.MediaStorageSOPInstanceUID, false);
            if (element == null)
            {
                element = pDS.InsertElement(null, false, DemoDicomTags.MediaStorageSOPInstanceUID, DicomVRType.UI, false, 0);
            }
            pDS.SetConvertValue(element, Utils.GenerateDicomUniqueIdentifier(), 1);
        }

        /*
         * Sets the Instance Numbers for this dataset
         */
        private void SetInstanceNumbers(ref DicomDataSet pDS, int nInstanceNumber)
        {
            DicomElement element;
            string strValue;

            strValue = string.Format("{0}", nInstanceNumber);

            // Series number
            element = pDS.FindFirstElement(null, DemoDicomTags.SeriesNumber, false);
            if (element != null)
            {
                pDS.SetConvertValue(element, strValue, 1);
            }

            // Instance number
            element = pDS.FindFirstElement(null, DemoDicomTags.InstanceNumber, false);
            if (element != null)
            {
                pDS.SetConvertValue(element, strValue, 1);
            }

            // Study ID
            element = pDS.FindFirstElement(null, DemoDicomTags.StudyID, false);
            if (element != null)
            {
                pDS.SetConvertValue(element, strValue, 1);
            }

            strValue = string.Format("854125{0}", nInstanceNumber);
            // Accession number
            element = pDS.FindFirstElement(null, DemoDicomTags.AccessionNumber, false);
            if (element != null)
            {
                pDS.SetConvertValue(element, strValue, 1);
            }
        }

        /*
         * Sets the appropriate dates for this Dataset
         */
        private void SetStudyDateAndTime(ref DicomDataSet pDS)
        {
            try
            {
                DateTime SystemTime = DateTime.Now;
                string strValue;
                DicomElement element;

                // Set study date
                strValue = SystemTime.ToShortDateString();
                element = pDS.FindFirstElement(null, DemoDicomTags.StudyDate, false);
                if (element != null)
                {
                    pDS.SetConvertValue(element, strValue, 1);
                }

                // Set content date
                element = pDS.FindFirstElement(null, DemoDicomTags.ContentDate, false);
                if (element != null)
                {
                    pDS.SetConvertValue(element, strValue, 1);
                }

                // Set Study time
                strValue = string.Format("{0}:{1}:{2}", SystemTime.Hour, SystemTime.Minute, SystemTime.Second);
                element = pDS.FindFirstElement(null, DemoDicomTags.StudyTime, false);
                if (element != null)
                {
                    pDS.SetConvertValue(element, strValue, 1);
                }

                // Set content time
                element = pDS.FindFirstElement(null, DemoDicomTags.ContentTime, false);
                if (element != null)
                {
                    pDS.SetConvertValue(element, strValue, 1);
                }

                strValue = string.Format("{0} {1}:{2}:{3}", SystemTime.ToShortDateString(), SystemTime.Hour, SystemTime.Minute, SystemTime.Second);
                // Set acquisition date time
                element = pDS.FindFirstElement(null, DemoDicomTags.AcquisitionDateTime, false);
                if (element != null)
                {
                    pDS.SetConvertValue(element, strValue, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while setting the dataset's dates: \r\n\r\n" + ex.ToString());
            }
        }

        /*
         * Creates and modifies the meta header for this dataset
         */
        private void InsertMetaHeader(ref DicomDataSet pDS)
        {
            DicomElement element;

            // Add File Meta Information Version
            element = pDS.FindFirstElement(null, DemoDicomTags.FileMetaInformationVersion, false);
            if (element == null)
            {
                element = pDS.InsertElement(null, false, DemoDicomTags.FileMetaInformationVersion, DicomVRType.OB, false, 0);
            }
            byte[] cValue = new byte[2] { 0, 1 };
            pDS.SetBinaryValue(element, cValue, 2);

            // Implementation Class UID
            element = pDS.FindFirstElement(null, DemoDicomTags.ImplementationClassUID, false);
            if (element == null)
            {
                element = pDS.InsertElement(null, false, DemoDicomTags.ImplementationClassUID, DicomVRType.UI, false, 0);
            }
            pDS.SetConvertValue(element, LEAD_IMPLEMENTATION_CLASS_UID, 1);

            // Implementation Version Name
            element = pDS.FindFirstElement(null, DemoDicomTags.ImplementationVersionName, false);
            if (element == null)
            {
                element = pDS.InsertElement(null, false, DemoDicomTags.ImplementationVersionName, DicomVRType.UI, false, 0);
            }
            pDS.SetConvertValue(element, LEAD_IMPLEMENTATION_VERSION_NAME, 1);
        }
    }
}
