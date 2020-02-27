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
using DicomVideoCaptureDemo.Common;

namespace DicomVideoCaptureDemo.UI
{
   public partial class CompressionSettingsDlg : Form
   {
      public CompressionSettingsDlg()
      {
         InitializeComponent();
      }

      private void _btn_Video_Click(object sender, EventArgs e)
      {
         if (Program.mainForm != null)
         {
            Program.mainForm.ShowMPEG2OptionsDlg();
         }
      }

      private void _btn_Audio_Click(object sender, EventArgs e)
      {
         if (Program.mainForm!=null)
         {
            Program.mainForm.ShowMPEG2AudioOptionsDlg();
         }   	
      }

      DICOMVID_IMAGE_COMPRESSION GetCompression()
      {
         if(Program.mainForm!=null)
         {
            return Program.mainForm.GetCompression();
         }
         return DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_NONE;
      }

      void SetCompression(DICOMVID_IMAGE_COMPRESSION ImageCompression)
      {
         if (Program.mainForm != null)
         {
            Program.mainForm.SetCompression(ImageCompression);
         }   
      }

      static int GetCompressionIndex(DICOMVID_IMAGE_COMPRESSION ImageCompression)
      {
         for(int i = 0 ; i < Helper.CompressionStringPair.Length ;i++)
         {
            if (ImageCompression == Helper.CompressionStringPair[i].ImageCompression)
               return i;
         }

         return 0;
      }
      void SetQFactor(int nQFactor)
      {
         if(Program.mainForm!=null)
         {
            Program.mainForm.SetQFactor(nQFactor);
         }
         
      }

      int GetQFactor()
      {
         if (Program.mainForm!=null)
         {
            return Program.mainForm.GetQFactor();
         }
         return Helper.Q_FACTOR_MIN;
      }

      void EnableQFactorCombo()
      {
         switch(GetCompression())
         {
            case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_JPEGLOSSY:
            case DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_J2KLOSSY:
               _combo_QFactor.Enabled = true;
               break;
            default:
               _combo_QFactor.Enabled = false;
               break;
         }
      }

      private void Compression_Settings_Load(object sender, EventArgs e)
      {
         String strTmp;
         int i;

         for (i = 0; i < Helper.CompressionStringPair.Length; i++)
         {
            _combo_CompressionType.Items.Add(Helper.CompressionStringPair[i].pszName);
         }

         _combo_CompressionType.SelectedIndex = GetCompressionIndex(GetCompression());

         for (i = Helper.Q_FACTOR_MIN; i <= Helper.Q_FACTOR_MAX; i++)
         {
            strTmp =  i.ToString();
            _combo_QFactor.Items.Add(strTmp);
         }
         _combo_QFactor.SelectedIndex = GetQFactor() - Helper.Q_FACTOR_MIN;
         EnableQFactorCombo();	
         EnableMPEG2Options();
         // disable preview while we are changing compressor settings
         EnablePreview(false);
      }

      void EnableMPEG2Options()
      {
         if(GetCompression() == DICOMVID_IMAGE_COMPRESSION.DICOMVID_IMAGE_COMPRESSION_MPEG2)
         {
            _btn_Video.Enabled = true;
            _btn_Audio.Enabled = true;
         }
         else
         {
            _btn_Video.Enabled = false;
            _btn_Audio.Enabled = false;
         }
      }

      void EnablePreview(bool bPreview)
      {
         if(Program.mainForm!=null)
         {
            Program.mainForm.CaptureCtrl1.Preview = bPreview;
         }   	
      }

      private void _combo_CompressionType_SelectedIndexChanged(object sender, EventArgs e)
      {
         int nCursel = _combo_CompressionType.SelectedIndex;
         if (nCursel != -1)
         {
            SetCompression(Helper.CompressionStringPair[nCursel].ImageCompression);
         }
         EnableQFactorCombo();
         EnableMPEG2Options();
      }

      private void _btn_Close_Click(object sender, EventArgs e)
      {
         SetQFactor(_combo_QFactor.SelectedIndex + Helper.Q_FACTOR_MIN);
         // enable preview now that we finished changing the compressor settings
         EnablePreview(true);
      }
   }
}
