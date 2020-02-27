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

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo
{
   public partial class MainForm : Form
   {
      // The RasterCodecs object used to load images
      private RasterCodecs _rasterCodecsInstance;
      // Last document information
      private CodecsImageInfo _imageInfo;

      public MainForm()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            using (Graphics g = CreateGraphics())
            {
               Tools.Units.ScreenResolution = (int)g.DpiX;
            }

            // Setup the caption for this demo
            Messager.Caption = "C# Rasterize Document Demo";
            Text = Messager.Caption;

            _rasterCodecsInstance = new RasterCodecs();

            // Setup and initialize the option controls
            foreach (TabPage tp in _optionsTabControl.TabPages)
            {
               UserControls.IOptionsUserControl optionsUserControl = tp.Controls[0] as UserControls.IOptionsUserControl;
               optionsUserControl.SetData(_rasterCodecsInstance);
            }

            _documentInfoControl.SetData(_imageInfo, _rasterCodecsInstance);
         }

         base.OnLoad(e);
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         if (!DesignMode)
         {
            if (_imageInfo != null)
            {
               _imageInfo.Dispose();
            }

            _rasterCodecsInstance.Dispose();
         }

         base.OnFormClosed(e);
      }

      private void _fileExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Rasterize Document", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _getDocumentInformationButton_Click(object sender, EventArgs e)
      {
         GetDocumentInformation();
      }

      private void _loadDocumentInViewerButton_Click(object sender, EventArgs e)
      {
         LoadDocumentInViewer();
      }

      private bool CollectAllOptions()
      {
         // Collects all the options from the controls, return true/false if we can continue

         bool ret = true;
         foreach (TabPage tp in _optionsTabControl.TabPages)
         {
            UserControls.IOptionsUserControl optionsUserControl = tp.Controls[0] as UserControls.IOptionsUserControl;
            ret = optionsUserControl.GetData(_rasterCodecsInstance);
            if (!ret)
            {
               _optionsTabControl.SelectedTab = tp;
               break;
            }
         }

         if (ret)
         {
            ret = _documentPathControl.GetData(_rasterCodecsInstance);
         }

         return ret;
      }

      private bool GetDocumentInformation()
      {
         // Get all the options
         if (!CollectAllOptions())
         {
            return false;
         }

         // Get the new image information

         string documentPath = _documentPathControl.DocumentPath;

         try
         {
            CodecsImageInfo newImageInfo = null;

            using (WaitCursor wait = new WaitCursor())
            {
               newImageInfo = _rasterCodecsInstance.GetInformation(documentPath, false);
            }

            // Use this information
            if (_imageInfo != null)
            {
               _imageInfo.Dispose();
            }

            _imageInfo = newImageInfo;
            _documentInfoControl.SetData(_imageInfo, _rasterCodecsInstance);

            return true;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }
      }

      private void LoadDocumentInViewer()
      {
         // Get information first
         if (!GetDocumentInformation())
         {
            return;
         }

         // Check if we have more than one page to load
         int totalPages = _imageInfo.TotalPages;
         int firstPageNumber = 1;
         int lastPageNumber = 1;

         bool loadDocument = true;

         if (totalPages > 1)
         {
            // Yes, prompt the user for the pages to load
            using (LoadPagesDialog dlg = new LoadPagesDialog())
            {
               dlg.TotalPages = totalPages;
               dlg.FirstPageNumber = firstPageNumber;
               dlg.LastPageNumber = lastPageNumber;

               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  firstPageNumber = dlg.FirstPageNumber;
                  lastPageNumber = dlg.LastPageNumber;
                  loadDocument = true;
               }
               else
               {
                  loadDocument = false;
               }
            }
         }

         if (loadDocument)
         {
            // Load the document
            string documentPath = _documentPathControl.DocumentPath;

            ViewDocument(documentPath, firstPageNumber, lastPageNumber);
         }
      }

      private void ViewDocument(string documentPath, int firstPageNumber, int lastPageNumber)
      {
         Viewer.ViewerForm viewer = new Viewer.ViewerForm();

         try
         {
            viewer.Initialize(documentPath, firstPageNumber, lastPageNumber == -1 ? _imageInfo.TotalPages : lastPageNumber, _rasterCodecsInstance);
            viewer.Show();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            viewer.Dispose();
         }
      }
   }
}
