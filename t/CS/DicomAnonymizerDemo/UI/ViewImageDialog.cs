// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.Common.Editing.Controls;
using Leadtools.Dicom;
using Leadtools.MedicalViewer;
using Leadtools.Dicom.Common.Editing;
using Leadtools.Demos;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using Leadtools;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.WinForms;
using Leadtools.Annotations.Rendering;

namespace DicomAnonymizer
{
   public partial class ViewImageDialog : Form
   {      
      private MedicalViewer _MedicalViewer;
      private Thread loaderThread;
      
      private DicomDataSet _Dataset;
     
      public DicomDataSet Dataset
      {
         get { return _Dataset; }
         set 
         { 
            _Dataset = value;            
         }
      }      

      public MedicalViewerCell Cell
      {
         get
         {
            return _MedicalViewer.Cells[0] as MedicalViewerCell;
         }
      }
      
      public ViewImageDialog()
      {        
         Cursor.Current = Cursors.WaitCursor;         
         InitializeComponent();
         for (int i = 0; i < 2; i++)
         {
            try
            {
               InitializeMedicalViewer();
               break;
            }
            catch (Exception e)
            {
               if(i == 1)
                  MessageBox.Show(e.Message);
            }
         }         
         SetAppIcon();
      }     

      private void SetAppIcon()
      {         
         try
         {
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location);
         }
         catch
         {           
         }         
      }      

      public ViewImageDialog(DicomDataSet ds)
         : this()
      {
         Dataset = ds;
      }

      private void InitializeMedicalViewer()
      {
         try
         {
            MedicalViewerCell cell = new MedicalViewerCell();

            cell.AddAction(MedicalViewerActionType.Stack);
            cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);
            cell.AddAction(MedicalViewerActionType.WindowLevel);
            cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);
            cell.AddAction(MedicalViewerActionType.Scale);
            cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active);
            
            _MedicalViewer = new MedicalViewer(1, 1);
            _MedicalViewer.Dock = DockStyle.Fill;            
            _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None;
            _MedicalViewer.Cells.Add(cell);
            _MedicalViewer.Dock = DockStyle.Fill;
            _MedicalViewer.BringToFront();
            panelViewer.Controls.Add(_MedicalViewer);
         }
         catch (Exception e)
         {
            Messager.ShowError(this, e);
            Close();
         }
      }

      private void LoadImage(object data)
      {
         DicomDataSet ds = data as DicomDataSet;
         int count = 0;
         RasterImage image = null;

         if (Dataset == null)
         {
            Cell.Image = null;
            return;
         }

         count = ds.GetImageCount(null);
         SetLoadProgress(count > 0,count);
         for (int i = 0; i < count; i++)
         {
            RasterImage img = ds.GetImage(null, i, 0, RasterByteOrder.Rgb | RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoScaleModalityLut);

            if (image == null)
            {
               image = img.Clone();
            }
            else
            {
               image.AddPage(img);
            }
            SetProgressValue(i + 1);
            Thread.Sleep(0);
         }

         SetCellImage(image);
      }

      private delegate void SetCellImageDelegate(RasterImage image);

      private void SetCellImage(RasterImage image)
      {
         if (InvokeRequired)
         {
            Invoke(new SetCellImageDelegate(SetCellImage), image);
         }
         else
         {
            if (image == null)
            {
               Cell.Image = null;               
               return;
            }

            SetLoadProgress(false, 0);
            Cell.Image = image;
            Cell.FitImageToCell = true;
            Cell.Selected = true;
            if (image.PageCount == 1)
               Cell.RemoveAction(MedicalViewerActionType.Stack);
         }
      }

      private delegate void SetLoadProgressDelegate(bool view, int count);

      private void SetLoadProgress(bool view, int count)
      {
         if (InvokeRequired)
         {
            Invoke(new SetLoadProgressDelegate(SetLoadProgress), view,count);
         }
         else
         {
            labelLoadInfo.Visible = view;
            progressBarLoad.Visible = view;
            if (view)
            {
               progressBarLoad.Maximum = count;
            }
            Application.DoEvents();
         }
      }

      private delegate void SetProgressValueDelegate(int value);

      private void SetProgressValue(int value)
      {
         if (InvokeRequired)
         {
            Invoke(new SetProgressValueDelegate(SetProgressValue), value);
         }
         else
         {
            progressBarLoad.Value = value;
            Application.DoEvents();
         }
      }      

      private bool CellHasImage()
      {
         return Cell.Image != null;
      }
     

      private void ViewDatasetDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (loaderThread != null)
         {
            loaderThread.Abort();
         }         
      }

      private void ViewDatasetDialog_Shown(object sender, EventArgs e)
      {
         Cursor.Current = Cursors.WaitCursor;
         loaderThread = new Thread(new ParameterizedThreadStart(LoadImage));
         loaderThread.Start(Dataset);
         _MedicalViewer.Focus();
      }      
   }
}
