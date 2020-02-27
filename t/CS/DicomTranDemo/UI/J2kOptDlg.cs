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
using System.Runtime.InteropServices;

namespace DicomTranDemo
{
   public partial class J2kOptDlg : Form
   {
      public DicomDataSet m_DS;
      public int m_nQFactor;
      public bool m_bLossless;
      public J2kOptDlg()
      {
         InitializeComponent();
         
      }

      protected void FileSaveFillJ2KOptionsAdvanced( ref DicomJpeg2000Options J2KOptions)
      {         
#if !LEADTOOLS_V19_OR_LATER
         chkSelectiveACBypass.Checked = J2KOptions.SelectiveAcBypass;
         chkResetContext.Checked = J2KOptions.ResetContextOnBoundaries;
         chkTermination.Checked = J2KOptions.TerminationOnEachPass;
         chkVerticallyCausal.Checked = J2KOptions.VerticallyCausalContext;
         chkPredictableTermination.Checked = J2KOptions.PredictableTermination;
         chkErrorResilience.Checked = J2KOptions.ErrorResilienceSymbol;
#endif // #if !LEADTOOLS_V19_OR_LATER

         chkColorTransform.Checked = J2KOptions.UseColorTransform;
         chkDerivedQuantization.Checked = J2KOptions.DerivedQuantization;
         chkUseSOPMarker.Checked = J2KOptions.UseSopMarker;
         chkUseEPHMarker.Checked = J2KOptions.UseEphMarker;

         txtXOSIZ.Text = J2KOptions.ImageAreaHorizontalOffset.ToString();
         txtYOSIZ.Text = J2KOptions.ImageAreaVerticalOffset.ToString();
         txtXTSIZ.Text = J2KOptions.ReferenceTileWidth.ToString();
         txtYTSIZ.Text = J2KOptions.ReferenceTileHeight.ToString();
         txtXTOSIZ.Text = J2KOptions.TileHorizontalOffset.ToString();
         txtYTOSIZ.Text = J2KOptions.TileVerticalOffset.ToString();

         txtDecompLevel.Text = J2KOptions.DecompositionLevels.ToString();
#if !LEADTOOLS_V19_OR_LATER
         txtGuardBits.Text = J2KOptions.GuardBits.ToString();
         txtMantissa.Text = J2KOptions.DerivedBaseMantissa.ToString();
         txtExponent.Text = J2KOptions.DerivedBaseExponent.ToString();
         txtCodeBlockWidth.Text = J2KOptions.CodeBlockWidth.ToString();
         txtCodeBlockHeight.Text = J2KOptions.CodeBlockHeight.ToString();
#endif // #if !LEADTOOLS_V19_OR_LATER

         txtTargetSize.Text = J2KOptions.TargetFileSize.ToString();
         txtQFactor.Text = m_nQFactor.ToString();
         txtCompressionRatio.Text = J2KOptions.CompressionRatio.ToString();                 

         switch(J2KOptions.CompressionControl)
         {
            case DicomJpeg2000CompressionControl.Ratio:
               cmbJ2kCompressionControl.SelectedIndex = 0;               
               ShowHideCompressionFields(0);
               break;
            case DicomJpeg2000CompressionControl.TargetSize:
               cmbJ2kCompressionControl.SelectedIndex = 1;
               ShowHideCompressionFields(1);
               break;
            case DicomJpeg2000CompressionControl.QualityFactor:
               cmbJ2kCompressionControl.SelectedIndex = 2;
               ShowHideCompressionFields(2);
               break;
         }   

         switch(J2KOptions.ProgressingOrder)
         {
            case DicomJpeg2000ProgressionsOrder.LayerResolutionComponentPosition:
               cmbJ2KProgressionOrder.SelectedIndex = 0;
               break;
            case DicomJpeg2000ProgressionsOrder.ResolutionLayerComponentPosition:
               cmbJ2KProgressionOrder.SelectedIndex = 1;
               break;
            case DicomJpeg2000ProgressionsOrder.ResolutionPositionComponentLayer:
               cmbJ2KProgressionOrder.SelectedIndex = 2;
               break;
            case DicomJpeg2000ProgressionsOrder.PositionComponentResolutionLayer:
               cmbJ2KProgressionOrder.SelectedIndex = 3;
               break;
            case DicomJpeg2000ProgressionsOrder.ComponentPositionResolutionLayer:
               cmbJ2KProgressionOrder.SelectedIndex = 4;
               break;      
         }         
      }

      private void J2kOptDlg_Load(object sender, EventArgs e)
      {         
         if(m_DS == null)
            return;         

         DicomJpeg2000Options J2KOptions;

         cmbJ2kCompressionControl.Items.Add("Compression Ratio");
         cmbJ2kCompressionControl.Items.Add("J2K Stream Size");
         cmbJ2kCompressionControl.Items.Add("Use QFactor");

         cmbJ2KProgressionOrder.Items.Add("Quality-axis");
         cmbJ2KProgressionOrder.Items.Add("Resolution-axis 1");
         cmbJ2KProgressionOrder.Items.Add("Resolution-axis 2");
         cmbJ2KProgressionOrder.Items.Add("Color-axis");
         cmbJ2KProgressionOrder.Items.Add("Position-axis");

         J2KOptions = m_DS.Jpeg2000Options;
         FileSaveFillJ2KOptionsAdvanced(ref J2KOptions);         
         if(m_bLossless)
         {            
            cmbJ2kCompressionControl.Enabled = false;           
            txtTargetSize.Enabled = false;
            txtCompressionRatio.Enabled = false;
            txtQFactor.Enabled = false;            
         }
      }

      private void btnDefault_Click(object sender, EventArgs e)
      {
         if (m_DS == null)
            return;

         DicomDataSet DummyDS = new DicomDataSet();
         DicomJpeg2000Options J2KOptions = DummyDS.Jpeg2000Options;

         FileSaveFillJ2KOptionsAdvanced(ref J2KOptions);
         m_DS.Jpeg2000Options = J2KOptions;
      }

      private bool GetEditInt(TextBox nID, ref int pVal, int nMinVal, int nMaxVal)
      {
         bool ret = true;
         try
         {
            pVal = Convert.ToInt16(nID.Text);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message,"Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ret = false;
         }


         if (pVal < nMinVal || pVal > nMaxVal)
            ret =  false;

         if (ret == false)
         {
            nID.SelectAll();
            nID.Focus();
         }
         return ret;
      }

      private bool FileSaveGetJ2KOptionsAdvanced( ref DicomJpeg2000Options J2KOptions)
      {
         int nValue = 0;

         if (GetEditInt(txtXOSIZ, ref nValue, 0, 0x3FFFFFFF))
            J2KOptions.ImageAreaHorizontalOffset = nValue;
         else
            return false;

         if (GetEditInt(txtYOSIZ, ref nValue, 0, 0x3FFFFFFF))
            J2KOptions.ImageAreaVerticalOffset = nValue;
         else
            return false;

         if (GetEditInt(txtXTSIZ, ref nValue, 0, 0x3FFFFFFF))
            J2KOptions.ReferenceTileWidth = nValue;
         else
            return false;

         if (GetEditInt(txtYTSIZ, ref nValue, 0, 0x3FFFFFFF))
            J2KOptions.ReferenceTileHeight = nValue;
         else
            return false;

         if (GetEditInt(txtXTOSIZ, ref nValue, 0, 0x3FFFFFFF))
            J2KOptions.TileHorizontalOffset = nValue;
         else
            return false;

         if (GetEditInt(txtYTOSIZ, ref nValue, 0, 0x3FFFFFFF))
            J2KOptions.TileVerticalOffset = nValue;
         else
            return false;

         if (GetEditInt(txtDecompLevel, ref nValue, 0, 32))
            J2KOptions.DecompositionLevels = nValue;
         else
            return false;

#if !LEADTOOLS_V19_OR_LATER
         int xcb, ycb;
         int width;
         int height;

         if(GetEditInt(txtGuardBits, ref nValue, 0, 7))
            J2KOptions.GuardBits = nValue;
         else
            return false;

         if(GetEditInt(txtMantissa, ref nValue, 0, 2047))
            J2KOptions.DerivedBaseMantissa = nValue;
         else
            return false;
         
         if(GetEditInt(txtExponent, ref nValue, 0, 16))
            J2KOptions.DerivedBaseExponent = nValue;
         else
            return false;

         if(GetEditInt(txtCodeBlockWidth, ref nValue, 2, 64))
            J2KOptions.CodeBlockWidth = nValue;
         else
            return false;

         if (GetEditInt(txtCodeBlockHeight, ref nValue, 2, 64))
            J2KOptions.CodeBlockHeight = nValue;
         else
            return false;
         
         for (xcb=0, width  = J2KOptions.CodeBlockWidth; width > (1<<xcb); xcb++);
         for (ycb=0, height = J2KOptions.CodeBlockHeight; height > (1<<ycb); ycb++);

         if ((width != (1 << xcb)) || (xcb < 2))
         {
            SelectTextAndBeep(txtCodeBlockWidth);
            return false;
         }

         if ((height != (1 << ycb)) || (ycb < 2) || ((xcb + ycb) > 12))
         {
            SelectTextAndBeep(txtCodeBlockHeight);
            return false;
         }
#endif // #if !LEADTOOLS_V19_OR_LATER


         if (J2KOptions.TileHorizontalOffset > J2KOptions.ImageAreaHorizontalOffset)
         {
            SelectTextAndBeep(txtXTOSIZ);
            return false;
         }

         if (J2KOptions.TileVerticalOffset > J2KOptions.ImageAreaVerticalOffset)
         {
            SelectTextAndBeep(txtYTOSIZ);
            return false;
         }

         if (J2KOptions.ImageAreaHorizontalOffset > J2KOptions.TileHorizontalOffset + J2KOptions.ReferenceTileWidth)
         {
            SelectTextAndBeep(txtXOSIZ);
            return false;
         }

         if (J2KOptions.ImageAreaVerticalOffset > J2KOptions.TileVerticalOffset + J2KOptions.ReferenceTileHeight)
         {
            SelectTextAndBeep(txtYOSIZ);
            return false;
         }

         if (J2KOptions.ReferenceTileWidth < (uint)(2 << J2KOptions.DecompositionLevels)
            || J2KOptions.ReferenceTileHeight < (uint)(2 << J2KOptions.DecompositionLevels))
         {
            SelectTextAndBeep(txtDecompLevel);
            return false;
         }

         J2KOptions.UseColorTransform = chkColorTransform.Checked;
         J2KOptions.DerivedQuantization = chkDerivedQuantization.Checked;
         J2KOptions.UseSopMarker = chkUseSOPMarker.Checked;
         J2KOptions.UseEphMarker = chkUseEPHMarker.Checked;

#if !LEADTOOLS_V19_OR_LATER
         J2KOptions.SelectiveAcBypass = chkSelectiveACBypass.Checked;
         J2KOptions.ResetContextOnBoundaries = chkResetContext.Checked;
         J2KOptions.TerminationOnEachPass = chkTermination.Checked;
         J2KOptions.VerticallyCausalContext = chkVerticallyCausal.Checked;
         J2KOptions.PredictableTermination = chkPredictableTermination.Checked;
         J2KOptions.ErrorResilienceSymbol = chkErrorResilience.Checked;
#endif // #if !LEADTOOLS_V19_OR_LATER

         J2KOptions.CompressionControl = (DicomJpeg2000CompressionControl)cmbJ2kCompressionControl.SelectedIndex + 1;
         J2KOptions.ProgressingOrder = (DicomJpeg2000ProgressionsOrder)cmbJ2KProgressionOrder.SelectedIndex;

         try
         {
            J2KOptions.TargetFileSize = Convert.ToInt32(txtTargetSize.Text);
         }
         catch (Exception)
         {
            SelectTextAndBeep(txtTargetSize);
            return false;
         }

         m_nQFactor = Convert.ToInt16(txtQFactor.Text);
         J2KOptions.CompressionRatio = Convert.ToSingle(txtCompressionRatio.Text);
         if (J2KOptions.CompressionRatio < 1.0)
            J2KOptions.CompressionRatio = 15.0f;
                  
         return true;         
      }


      [DllImport("user32.dll")]
      static extern bool MessageBeep(uint uType);      
      private void SelectTextAndBeep ( TextBox nID )
      {
         nID.SelectAll();
         nID.Focus();         
         MessageBeep(0);
      }

      private void cmbJ2kCompressionControl_SelectedIndexChanged(object sender, EventArgs e)
      {
         ShowHideCompressionFields(cmbJ2kCompressionControl.SelectedIndex);
      }
      private void ShowHideCompressionFields(int nIndex)
      {         
         switch(nIndex)
         {         
            //Compression Ratio
            case 0:
               lblJ2KTargetSize.Visible = false;
               txtTargetSize.Visible = false;               
               
               lblJ2KCompressionRatio.Visible = true;
               txtCompressionRatio.Visible = true;

               lblJ2KQFactor.Visible = false;
               txtQFactor.Visible = false;               
               break;          
            //Target File Size
            case 1:
               lblJ2KTargetSize.Visible = true;
               txtTargetSize.Visible = true;

               lblJ2KCompressionRatio.Visible = false;
               txtCompressionRatio.Visible = false;

               lblJ2KQFactor.Visible = false;
               txtQFactor.Visible = false;
               break;
            //Use QFactor
            case 2:
               lblJ2KTargetSize.Visible = false;
               txtTargetSize.Visible = false;
               
               lblJ2KCompressionRatio.Visible = false;
               txtCompressionRatio.Visible = false;

               lblJ2KQFactor.Visible = true;
               txtQFactor.Visible = true;               
               break;
         }     
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
         DicomJpeg2000Options J2KOptions = m_DS.Jpeg2000Options;         
         
         if(!FileSaveGetJ2KOptionsAdvanced(ref J2KOptions))
         {
            return;
         }
         m_DS.Jpeg2000Options = J2KOptions;
         base.DialogResult = DialogResult.OK;
         base.Close();
      }
   }
}
