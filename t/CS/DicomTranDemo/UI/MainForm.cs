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
using Leadtools.Codecs;
using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomTranDemo
{
   public partial class MainForm : Form
   {
      public string LEAD_IMPLEMENTATION_CLASS_UID = "1.2.840.114257.0.1";
      public string LEAD_IMPLEMENTATION_VERSION_NAME = "LEADTOOLS Demo";
      DicomJpeg2000Options m_J2KOptions;

      public MainForm()
      {
         InitializeComponent();
      }

      private void InFile_Click(object sender, EventArgs e)
      {
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*||";
         dlg.FilterIndex = 1;
         dlg.FileName = txtInFile.Text;

         if (dlg.ShowDialog() == DialogResult.OK)          
            txtInFile.Text = dlg.FileName;         
      }

      private void OutFile_Click(object sender, EventArgs e)
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Filter = "DCM Files (.dcm)|*.dcm||";
         dlg.FilterIndex = 1;
         dlg.FileName = txtInFile.Text;

         if (dlg.ShowDialog() == DialogResult.OK)
            txtOutFile.Text = dlg.FileName; 
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         DicomEngine.Startup();
         DicomDataSet DummyDS = new DicomDataSet();
         m_J2KOptions = DummyDS.Jpeg2000Options;         

         AddUID(DicomUidType.ImplicitVRLittleEndian, "Implicit VR Little Endian (1.2.840.10008.1.2)");
         AddUID(DicomUidType.ExplicitVRLittleEndian, "Explicit VR Little Endian (1.2.840.10008.1.2.1)");
         AddUID(DicomUidType.ExplicitVRBigEndian, "Explicit VR Big Endian (1.2.840.10008.1.2.2)");
         AddUID(DicomUidType.RLELossless, "RLE Lossless (1.2.840.10008.1.2.5)");
         AddUID(DicomUidType.JPEGBaseline1,"JPEG Baseline (Process 1) (1.2.840.10008.1.2.4.50)");
         AddUID(DicomUidType.JPEGExtended2_4,"JPEG Extended (Process 2 & 4) (1.2.840.10008.1.2.4.51)");
         AddUID(DicomUidType.JPEGLosslessNonhier14,"JPEG Lossless, Non-Hierarchical (Process 14) (1.2.840.10008.1.2.4.57)");
         AddUID(DicomUidType.JPEGLosslessNonhier14B,"JPEG Lossless, Non-Hierarchical,First-Order Prediction (1.2.840.10008.1.2.4.70)");
#if LEADTOOLS_V175_OR_LATER
         AddUID(DicomUidType.JPEGLSLossless, "JPEG-LS Lossless (1.2.840.10008.1.2.4.80)");
         AddUID(DicomUidType.JPEGLSLossy, "JPEG-LS Lossy (1.2.840.10008.1.2.4.81)");   
#endif
         AddUID(DicomUidType.JPEG2000LosslessOnly,"JPEG 2000 Lossless Only (1.2.840.10008.1.2.4.90)");
         AddUID(DicomUidType.JPEG2000, "JPEG 2000 (1.2.840.10008.1.2.4.91)");
#if LEADTOOLS_V19_OR_LATER
         AddUID(DicomUidType.JPEG2000Part2MultiComponentImageCompressionLosslessOnly, "JPEG 2000 Part2, Multi Component Image Compression Lossless Only (1.2.840.10008.1.2.4.92)");
         AddUID(DicomUidType.JPEG2000Part2MultiComponentImageCompression, "JPEG 2000 Part2, Multi Component Image Compression (1.2.840.10008.1.2.4.93)");
#endif
         cmbTransferSyntax.SelectedIndex = 0;
         J2kOptionsBtn.Enabled = false;
         txtQFactor.Enabled = false;
         txtQFactor.Text = "2";         
      }

      private void AddUID(string uid, string description)
      {
         MyTransferSyntax xferSyntax = new MyTransferSyntax();
         xferSyntax.szUID = uid; xferSyntax.szDescription = description;
         cmbTransferSyntax.Items.Add(xferSyntax);
      }

      private void UpdateOptions()
      {
         string uid = ((MyTransferSyntax)cmbTransferSyntax.Items[cmbTransferSyntax.SelectedIndex]).szUID;
         bool enable =
             (uid == DicomUidType.RLELossless) ||
             (uid == DicomUidType.ImplicitVRLittleEndian) ||
             (uid == DicomUidType.ExplicitVRLittleEndian) ||
             (uid == DicomUidType.ExplicitVRBigEndian);

         checkBoxYbrFull.Enabled = enable;
         if (!enable)
            checkBoxYbrFull.Checked = false;

         bool showYbrOptions = false;
#if LEADTOOLS_V175_OR_LATER
         showYbrOptions = true;
#endif
         checkBoxYbrFull.Visible = showYbrOptions;
         labelYbrFull.Visible = showYbrOptions;
      }

      private static bool IsUidJpeg2000(string uid)
      {
         bool isJpeg2000;
         switch (uid)
         {
            case DicomUidType.JPEG2000:
            case DicomUidType.JPEG2000LosslessOnly:
            case DicomUidType.JPEG2000Part2MultiComponentImageCompressionLosslessOnly:
            case DicomUidType.JPEG2000Part2MultiComponentImageCompression:
               isJpeg2000 = true;
               break;
            default:
               isJpeg2000 = false;
               break;
         }
         return isJpeg2000;
      }

      private static bool IsUidUsingQFactor(string uid)
      {
         bool isUsingQFactor;
         switch (uid)
         {
            case DicomUidType.JPEGBaseline1:
            case DicomUidType.JPEGExtended2_4:
            case DicomUidType.JPEG2000:
            case DicomUidType.JPEG2000Part2MultiComponentImageCompression:
               isUsingQFactor = true;
               break;
            default:
               isUsingQFactor = false;
               break;
         }
         return isUsingQFactor;
      }

      private void cmbTransferSyntax_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Get desired transfer syntax    
         string uid = ((MyTransferSyntax)cmbTransferSyntax.Items[cmbTransferSyntax.SelectedIndex]).szUID;

         txtQFactor.Enabled = IsUidUsingQFactor(uid);
         J2kOptionsBtn.Enabled = IsUidJpeg2000(uid);

         UpdateOptions();
      }

      private void Change_Click(object sender, EventArgs e)
      {                          
         // Some sanity checks !
         if(txtInFile.Text.Length == 0)
         {
            MessageBox.Show("Please enter a valid input file name ");
            return;
         }
                  
         if (!System.IO.File.Exists(txtInFile.Text)) 
         {
            MessageBox.Show("Please enter a valid input file name ");
            return ;      
         } 
         
         if(txtOutFile.Text.Length == 0)
         {
            MessageBox.Show("Please enter a valid output file name ");
            return ;
         }
         if(txtInFile.Text == txtOutFile.Text)
         {
            MessageBox.Show("Input and output file names can't be the same!");
            return ;
         }

         DicomDataSetSaveFlags saveFlags = (DicomDataSetSaveFlags.MetaHeaderPresent | DicomDataSetSaveFlags.GroupLengths);

         // Get desired transfer syntax 
         string uid = ((MyTransferSyntax)cmbTransferSyntax.Items[cmbTransferSyntax.SelectedIndex]).szUID;
         int nQFactor; 
         if(IsUidUsingQFactor(uid))
         {
            nQFactor = Convert.ToInt16(txtQFactor.Text);
            if ((nQFactor < 2 || nQFactor > 255) && (nQFactor != 0))
            {
               string message =  "Please enter a valid quality factor:\r\n" + 
                                 "\t 0 (lossless)\r\n" +
                                 "\t 2 (lossy highest quality) to 255 (lossy most compression)";

               MessageBox.Show(message, "Please enter a valid quality factor.");
               return ;
            }
         }
         else
         {
            nQFactor = 0;   
         }
         //Load input dataset

#if !(LEADTOOLS_V17_OR_LATER)
         RasterCodecs.Startup();
#endif
         DicomEngine.Startup();
         DicomDataSet DicomDs = new DicomDataSet();
         DicomDs.Reset();
         try
         {
            DicomDs.Load(txtInFile.Text, 0);            
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Failed to load the Dataset!");
            return;
         }

         if (IsUidJpeg2000(uid))
         {
            // Setting JPEG 2000 options 
            DicomDs.Jpeg2000Options = m_J2KOptions;
         }

         // Ensure that the DICOM File Meta Information is added
         CheckFileMetaInfo(DicomDs);

         //Change dataset to desired transfer syntax
         try
         {
            ChangeTransferSyntaxFlags flags = ChangeTransferSyntaxFlags.None;
#if LEADTOOLS_V175_OR_LATER
            if (checkBoxYbrFull.Checked)
               flags |= ChangeTransferSyntaxFlags.YbrFull;
#endif

#if LEADTOOLS_V19_OR_LATER
            DicomDs.ChangeTransferSyntax(txtOutFile.Text, uid, nQFactor, flags, saveFlags);
#else
            DicomDs.ChangeTransferSyntax(uid, nQFactor, flags);
#endif
         }
         catch(Exception ex)
         {
            string errorString = ex.Message.ToLower();
            if (errorString.Contains("parameter"))
            {
               const string strErr = "Failed to change dataset transfer syntax.\nPossible cause:\" Bits Allocated\" for source dataset doesn't match desired \"Transfer Syntax\".";
               MessageBox.Show(strErr, "Failed to change dataset transfer syntax.",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
               MessageBox.Show(ex.Message, "LEAD Error");
            
            return;
         }

#if !LEADTOOLS_V19_OR_LATER
         // Save dataset!
         try
         {
            DicomDs.Save(txtOutFile.Text, saveFlags);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Failed to save dataset");
            return;
         }
#endif // #if !LEADTOOLS_V19_OR_LATER

         DicomEngine.Shutdown();

#if !LEADTOOLS_V17_OR_LATER
         RasterCodecs.Shutdown();
#endif
         MessageBox.Show("Conversion Succeeded", "SUCCESS");
                  
         //this.Cursor = Cursors.WaitCursor;
         //this.Cursor = Cursors.Arrow;
      }
      private void CheckFileMetaInfo(DicomDataSet ds)
      {
         DicomElement Temp;         
         string szValue;

         // File Meta Information Version
         DicomElement Element = ds.FindFirstElement(null, DemoDicomTags.FileMetaInformationVersion, false);
         if (Element == null)
         {
            Element = ds.InsertElement(null, false, DemoDicomTags.FileMetaInformationVersion, DicomVRType.UN, false, 0);                                             
         }
         if (Element != null)
         {
            byte[] Values = new byte[2];
            Values[0] = 0x00;
            Values[1] = 0x01;            

            ds.SetByteValue(Element, Values, 2);            
         }

         // Media Storage SOP Class UID
         Element = ds.FindFirstElement(null, DemoDicomTags.MediaStorageSOPClassUID, false);
         if (Element == null)
         {
            Element = ds.InsertElement(null, false, DemoDicomTags.MediaStorageSOPClassUID, DicomVRType.UN, false, 0);
         }
         if (Element != null)
         {
            Temp = ds.FindFirstElement(null, DemoDicomTags.SOPClassUID, false);
            if (Temp != null)
            {
               szValue = ds.GetStringValue(Temp, 0);
               if (szValue != string.Empty)
               {
                  ds.SetStringValue(Element, szValue, DicomCharacterSetType.Default);
               }
            }
         }

         // Media Storage SOP Instance UID
         Element = ds.FindFirstElement(null, DemoDicomTags.MediaStorageSOPInstanceUID, false);
         if (Element == null)
         {
            Element = ds.InsertElement(null, false, DemoDicomTags.MediaStorageSOPInstanceUID, DicomVRType.UN, false, 0);
         }
         if (Element != null)
         {
            Temp = ds.FindFirstElement(null, DemoDicomTags.SOPInstanceUID, false);
            if (Temp != null)
            {
               szValue = ds.GetStringValue(Temp, 0);
               if (szValue != string.Empty)
               {
                  ds.SetStringValue(Element, szValue, DicomCharacterSetType.Default);
               }
            }
         }

         // Implementation Class UID
         Element = ds.FindFirstElement(null, DemoDicomTags.ImplementationClassUID, false);
         if (Element == null)
         {
            Element = ds.InsertElement(null, false, DemoDicomTags.ImplementationClassUID, DicomVRType.UN, false, 0);
         }
         if (Element != null)
         {
            ds.SetStringValue(Element, LEAD_IMPLEMENTATION_CLASS_UID, DicomCharacterSetType.Default);
         }

         // Implementation Version Name
         Element = ds.FindFirstElement(null, DemoDicomTags.ImplementationVersionName, false);
         if (Element == null)
         {
            Element = ds.InsertElement(null, false, DemoDicomTags.ImplementationVersionName, DicomVRType.UN, false, 0);
         }
         if (Element != null)
         {
            ds.SetStringValue(Element, LEAD_IMPLEMENTATION_VERSION_NAME, DicomCharacterSetType.Default);
         }
      }

      private void J2kOptionsBtn_Click(object sender, EventArgs e)
      {
         DicomDataSet DummyDS = new DicomDataSet();
         J2kOptDlg J2KOptionsDlg = new J2kOptDlg();

         DummyDS.Jpeg2000Options = m_J2KOptions;         
         J2KOptionsDlg.m_DS = DummyDS;
         J2KOptionsDlg.m_nQFactor = Convert.ToInt16(txtQFactor.Text);
         
         string uid = ((MyTransferSyntax)cmbTransferSyntax.Items[cmbTransferSyntax.SelectedIndex]).szUID;
         if ( uid == DicomUidType.JPEG2000LosslessOnly)
         {
            J2KOptionsDlg.m_bLossless = true;
         }         
         J2KOptionsDlg.ShowDialog();
         m_J2KOptions = DummyDS.Jpeg2000Options;         
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         DicomEngine.Shutdown();
      }
   }
}
