// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.UserControls
{
   public partial class DocumentInfoControl : UserControl
   {
      public DocumentInfoControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(CodecsImageInfo imageInfo, RasterCodecs rasterCodecsInstance)
      {
         // Set the state of the controls

         if(imageInfo != null)
         {
            // Get the index of the format in the DocumentFormats
            int index = Tools.DocumentFormats.GetFormatIndex(imageInfo.Format);

            CodecsRasterizeDocumentUnit viewUnit = rasterCodecsInstance.Options.RasterizeDocument.Load.Unit;

            double originalWidth;
            double originalHeight;
            CodecsRasterizeDocumentUnit originalUnit;

            if(index != -1)
            {
               // Document format
               _formatValueLabel.Text = string.Format("{0} ({1})", Tools.DocumentFormats.FormatFriendlyNames[index], Tools.DocumentFormats.Formats[index]);

               originalWidth = imageInfo.Document.PageWidth;
               originalHeight = imageInfo.Document.PageHeight;
               originalUnit = imageInfo.Document.Unit;

               _warningLabel.Visible = false;
            }
            else
            {
               // Raster format
               _formatValueLabel.Text = imageInfo.Format.ToString();

               originalWidth = imageInfo.Width;
               originalHeight = imageInfo.Height;
               originalUnit = CodecsRasterizeDocumentUnit.Pixel;

               _warningLabel.Visible = true;
            }

            _pagesValueLabel.Text = imageInfo.TotalPages.ToString();

            // Convert to the view unit
            originalWidth = Tools.Units.Convert(originalWidth, originalUnit, Tools.Units.ScreenResolution, viewUnit);
            originalHeight = Tools.Units.Convert(originalHeight, originalUnit, Tools.Units.ScreenResolution, viewUnit);

            _originalDocumentSizeValueLabel.Text = Tools.Units.Format(originalWidth, originalHeight, viewUnit);

            double loadWidth = Tools.Units.Convert(imageInfo.Width, CodecsRasterizeDocumentUnit.Pixel, imageInfo.XResolution, viewUnit);
            double loadHeight = Tools.Units.Convert(imageInfo.Height, CodecsRasterizeDocumentUnit.Pixel, imageInfo.YResolution, viewUnit);
            _loadDocumentSizeValueLabel.Text = Tools.Units.Format(loadWidth, loadHeight, viewUnit);
            _loadDocumentSizePixelsLabel.Text = string.Format("{0} at {1} pixels/inch", Tools.Units.Format(imageInfo.Width, imageInfo.Height, CodecsRasterizeDocumentUnit.Pixel), imageInfo.XResolution);

            // Show everything
            _formatValueLabel.Visible = true;
            _pagesValueLabel.Visible = true;
            _originalDocumentSizeValueLabel.Visible = true;
            _loadDocumentSizeValueLabel.Visible = true;
            _loadDocumentSizePixelsLabel.Visible = true;
         }
         else
         {
            // Hide everything
            _formatValueLabel.Visible = false;
            _pagesValueLabel.Visible = false;
            _originalDocumentSizeValueLabel.Visible = false;
            _loadDocumentSizeValueLabel.Visible = false;
            _loadDocumentSizePixelsLabel.Visible = false;
            _warningLabel.Visible = false;
         }
      }
   }
}
