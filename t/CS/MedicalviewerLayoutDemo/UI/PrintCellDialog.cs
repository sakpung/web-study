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
using System.Drawing.Printing;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Drawing;
using Leadtools.MedicalViewer;
using Leadtools.Codecs;
using Leadtools.WinForms;

namespace MedicalViewerLayoutDemo
{
   public partial class PrintCellDialog : Form
   {
      private int subCellIndex;
      private Image image;
      private MedicalViewerCellImageFeatures features;
      private bool exploded;
      private MedicalViewerCell _SelectedCell;

      private MedicalViewerCellImageFeatures GetCellFeatures()
      {
         MedicalViewerCellImageFeatures features = (MedicalViewerCellImageFeatures)0;

         if (_chkAnnotation.Checked)
            features |= MedicalViewerCellImageFeatures.Annotations;
         if (_chkRegion.Checked)
            features |= MedicalViewerCellImageFeatures.Regions;
         if (_chkRulers.Checked)
            features |= MedicalViewerCellImageFeatures.Rulers;
         if (_chkBorders.Checked)
            features |= MedicalViewerCellImageFeatures.Borders;
         if (_chkTags.Checked)
            features |= MedicalViewerCellImageFeatures.Tags;

         return features;
      }

      private void UpdateCellImage(MainForm owner)
      {
         if (owner == null)
            return;
         if (image != null)
            image.Dispose();
         image = _SelectedCell.GetCellImage(exploded, features);
         _cellImage.Image = image;
      }

      private void EnableOptionsCheckBoxs(bool enable)
      {
         _chkAnnotation.Enabled = enable;
         _chkRegion.Enabled = enable;
         _chkRulers.Enabled = enable;
         _chkBorders.Enabled = enable;
         _chkTags.Enabled = enable;
      }

      private void EnableAdditionalOptionsCheckBoxs(bool enable)
      {
         _txtIndex.Enabled = enable;
         _lblIndex.Enabled = enable;
         _chkExploded.Enabled = enable;
         subCellIndex = enable ? Convert.ToInt32(_txtIndex.Text) - 1 : -1;
      }

      public PrintCellDialog(MainForm owner, MedicalViewerCell selectedCell)
      {

         InitializeComponent();
         _SelectedCell = selectedCell;
         
         image = null;
         subCellIndex = 0;
         exploded = false;
         SuspendLayout();
         _chkPrintAll.Checked = true;
         _chkAll.Checked = true;
         _txtIndex.MaximumAllowed = _SelectedCell.Image.PageCount;
         EnableOptionsCheckBoxs(false);
         EnableAdditionalOptionsCheckBoxs(false);
         ResumeLayout(false);

         UpdateCellImage(owner);
      }

      private void _btnPrint_Click(object sender, EventArgs e)
      {
         ((MainForm)this.Owner).PrintImage = RasterImageConverter.ConvertFromImage(image, ConvertFromImageOptions.None);
         RasterImage printImage = ((MainForm)this.Owner).PrintImage;
         PrintDocument printDocument = ((MainForm)this.Owner).PrintDocument;

         printDocument.PrinterSettings.MinimumPage = 1;
         printDocument.PrinterSettings.MaximumPage = printImage.PageCount;
         printDocument.PrinterSettings.FromPage = 1;
         printDocument.PrinterSettings.ToPage = printImage.PageCount;
         printDocument.Print();

         this.Close();
      }

      private void _chkAll_CheckedChanged(object sender, EventArgs e)
      {
         EnableOptionsCheckBoxs(!_chkAll.Checked);
         features = _chkAll.Checked ? MedicalViewerCellImageFeatures.All : GetCellFeatures();
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _chkAnnotation_CheckedChanged(object sender, EventArgs e)
      {
         features = GetCellFeatures();
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _chkRegion_CheckedChanged(object sender, EventArgs e)
      {
         features = GetCellFeatures();
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _chkBorders_CheckedChanged(object sender, EventArgs e)
      {
         features = GetCellFeatures();
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _chkRulers_CheckedChanged(object sender, EventArgs e)
      {
         features = GetCellFeatures();
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _chkTags_CheckedChanged(object sender, EventArgs e)
      {
         features = GetCellFeatures();
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _chkPrintAll_CheckedChanged(object sender, EventArgs e)
      {
         EnableAdditionalOptionsCheckBoxs(!_chkPrintAll.Checked);
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _chkExploded_CheckedChanged(object sender, EventArgs e)
      {
         exploded = _chkExploded.Checked;
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _txtIndex_TextChanged(object sender, EventArgs e)
      {
         subCellIndex = Convert.ToInt32(_txtIndex.Text) - 1;
         UpdateCellImage((MainForm)this.Owner);
      }

      private void _btnSave_Click(object sender, EventArgs e)
      {
         ImageFileSaver _saver = new ImageFileSaver();

         try
         {
            using(RasterCodecs codecs = new RasterCodecs())
            {
               using(RasterImage rasterImage = RasterImageConverter.ConvertFromImage(image, ConvertFromImageOptions.None))
               {
                  DemosGlobal.SetDefaultComments(rasterImage, codecs);
                  _saver.Save(this, codecs, rasterImage);
                  this.Close();
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, _saver.FileName, ex);
         }
      }
   }
}
