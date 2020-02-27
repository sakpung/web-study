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
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.Storage.DataAccessLayer;
using static Leadtools.Dicom.Common.Extensions.DicomExtensions;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;

namespace Leadtools.Medical.Winforms
{
   public partial class ViewDatasetDialog : Form
   {
      private DicomPropertyGrid _DicomGrid;
      private MedicalViewer.MedicalViewer _MedicalViewer;
      private Thread loaderThread;
      private IOptionsDataAccessAgent _optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
     
      public DicomDataSet Dataset
      {
         get { return _DicomGrid.DataSet; }
         set 
         { 
            _DicomGrid.DataSet = value;
            _DicomGrid.SelectedGridItem = GetRootGridItem(_DicomGrid.SelectedGridItem);            
         }
      }

      IStorageDataAccessAgent5 _storageDataAccessAgent = null;
      public IStorageDataAccessAgent5 StorageDataAccessAgent
      {
         get
         {
            return _storageDataAccessAgent;
         }
         set
         {
            _storageDataAccessAgent = value;
         }
      }

      public MedicalViewerCell Cell
      {
         get
         {
            return _MedicalViewer.Cells[0] as MedicalViewerCell;
         }
      }
      
      public ViewDatasetDialog()
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
         _DicomGrid = new DicomPropertyGrid();
         _DicomGrid.Dock = DockStyle.Fill;         
         _DicomGrid.ReadOnly = true;
         _DicomGrid.ShowUsageImages = false;       
         _DicomGrid.CommandsVisibleIfAvailable = false;
         _DicomGrid.BeforeAddElement += new EventHandler<BeforeAddElementEventArgs>(_DicomGrid_BeforeAddElement);
         tabPageDataset.Controls.Add(_DicomGrid);
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

      void _DicomGrid_BeforeAddElement(object sender, BeforeAddElementEventArgs e)
      {
         if (e.Element.DicomElement.Tag == DicomTag.PixelData)
         {
            e.Cancel = true;
         }
      }          

      public ViewDatasetDialog(DicomDataSet ds) : this()
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

            _MedicalViewer = new MedicalViewer.MedicalViewer(1, 1);
            _MedicalViewer.Dock = DockStyle.Fill;
            _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None;
            _MedicalViewer.Cells.Add(cell);
            _MedicalViewer.Dock = DockStyle.Fill;
            tabPageImages.Controls.Add(_MedicalViewer);
         }
         catch (Exception e)
         {
            Messager.ShowError(this, e);
            Close();
         }
      }

      private string GetDicomTag(DicomDataSet ds, long tag)
      {
         DicomElement patientElement = ds.FindFirstElement(null,
                                              tag,
                                              true);

         if (patientElement != null)
            return ds.GetConvertValue(patientElement);

         return null;
      }



      public DicomDataSet GetSopInstanceCallBack(string sopInstanceUid)
      {
         DicomDataSet dsImage = null;
         if (_storageDataAccessAgent != null)
         {
            dsImage = _storageDataAccessAgent.GetDicomDataSet(sopInstanceUid);
         }
         return dsImage;
      }

      private bool IsStructuredDisplay(DicomDataSet ds)
      {
         string sopClassUid = ds.GetValue<string>(DicomTag.SOPClassUID, string.Empty);
         return (sopClassUid == DicomUidType.BasicStructuredDisplayStorage);
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

         bool isStructuredDisplay = IsStructuredDisplay(ds);
         DicomElement pixelData = ds.FindFirstElement(null, DicomTag.PixelData, true);
         if (pixelData == null)
         {
            if (isStructuredDisplay)
            {
               count = 1;
            }
         }
         else
         {
            count = ds.GetImageCount(pixelData);
         }

         SetLoadProgress(count > 0, count);
         string exceptionMessage = string.Empty;
         for (int i = 0; i < count; i++)
         {
            RasterImage img = null;

            try
            {
               if (pixelData != null)
               {
                  img = ds.GetImage(pixelData, i, 0, RasterByteOrder.Rgb | RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoScaleModalityLut | DicomGetImageFlags.AutoScaleVoiLut | DicomGetImageFlags.AutoDetectInvalidRleCompression);
               }
               else if (isStructuredDisplay)
               {
                  StructuredDisplayImageOptions sdOptions = new StructuredDisplayImageOptions();
                  sdOptions.ShowOverlay = _optionsAgent.Get<bool>("ExportLayoutIncludeMetadata", true);
                  DicomGetImageFlags getImageFlags = DicomGetImageFlags.AutoScaleModalityLut | DicomGetImageFlags.AutoScaleVoiLut | DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AutoApplyVoiLut;
                  img = ds.GetStructuredDisplayImage(GetSopInstanceCallBack, getImageFlags, sdOptions);;
               }

            }
            catch (Exception ex)
            {
               exceptionMessage = ex.Message;
            }

            if (img != null)
            {
               if (image == null)
               {
                  image = img.Clone();
               }
               else
               {
                  image.AddPage(img);
               }
            }
            SetProgressValue(i + 1);
            Thread.Sleep(0);
         }

         string photometricInterpretation = GetDicomTag(ds, DicomTag.PhotometricInterpretation);
         if (!string.IsNullOrEmpty(photometricInterpretation))
         {
            Cell.PhotometricInterpretation = photometricInterpretation;
         }

         SetCellInfo(image, 
            ds.GetValue<string>(DicomTag.PatientID, string.Empty), 
            ds.GetValue<string>(DicomTag.PatientName, string.Empty),
            ds.GetValue<string>(DicomTag.WindowWidth, string.Empty), 
            ds.GetValue<string>(DicomTag.WindowCenter, string.Empty),
            isStructuredDisplay);

         if (!string.IsNullOrEmpty(exceptionMessage))
         {
            string errorMessage = string.Format("Failed to show image.\n{0}", exceptionMessage);

            if (count > 1)
            {
               errorMessage = string.Format("Failed to load one or more image frames.\n{0}", exceptionMessage);
            }
            Messager.ShowError(this, errorMessage);
         }
      }

      private delegate void SetCellInfoDelegate(RasterImage image, string patientId, string patientName, string windowWidth, string windowCenter, bool isStructuredDisplay);

      private void SetCellInfo(RasterImage image, string patientId, string patientName, string windowWidth, string windowCenter, bool isStructuredDisplay)      
      {
         if (InvokeRequired)
         {
            Invoke(new SetCellInfoDelegate(SetCellInfo), image, patientId, patientName, windowWidth, windowCenter, isStructuredDisplay);
         }
         else
         {
            if (image == null)
            {
               Cell.Image = null;
               tabControlDicom.TabPages.Remove(tabPageImages);
               return;
            }

            SetLoadProgress(false, 0);
            Cell.Image = image;
            Cell.FitImageToCell = true;
            if ((image.GrayscaleMode != RasterGrayscaleMode.None) && (!isStructuredDisplay))
            {
               Cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);
               Cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.Frame);
            }

            // The following are examples of how to add overlays
            // * Cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);
            //   Shows WindowLevelData at the BottomLeft
            // * Cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.Frame);
            //   Shows the Frame (i.e. horizontal and vertical ruler bars that change when zooming
            // * Cell.SetTag(5, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, patientName);
            //   Shows PatientName at the TopLeft
            // * Cell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, patientName);
            //   Shows PatientName at the TopRight
            // * Cell.DeleteTag(2, MedicalViewerTagAlignment.BottomLeft);
            //   Deletes all the overlays for item (2)
            // * Cell.DeleteTag(0, MedicalViewerTagAlignment.TopRight);
            //   Deletes all the overlays for item (0)

            if (image.PageCount > 1)
            {
               tabPageImages.Text = "Images";
            }
            if (!string.IsNullOrEmpty(windowWidth) && !string.IsNullOrEmpty(windowCenter))
            {
               int ww = -1, wc = -1;

               MedicalViewerWindowLevel wl = Cell.GetActionProperties(MedicalViewerActionType.WindowLevel) as MedicalViewerWindowLevel;
               if (wl != null)
               {
                  if (int.TryParse(windowWidth, out ww))
                  {
                     wl.Width = ww;
                  }

                  if (int.TryParse(windowCenter, out wc))
                  {
                     wl.Center = wc;
                  }

                  Cell.SetActionProperties(MedicalViewerActionType.WindowLevel, wl);
               }
            }
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

      private GridItem GetRootGridItem(GridItem gItem)
      {
         GridItem gridItemFind = gItem;
         GridItem gridItemRoot = null;

         while (gridItemFind != null)
         {
            gridItemRoot = gridItemFind;
            gridItemFind = gridItemFind.Parent;
         }

         if (gridItemRoot.GridItems.Count == 0)
            return null;

         return gridItemRoot.GridItems[0];
      }

      private void SetUserTag(int row, MedicalViewerTagAlignment align, object value)
      {
         Cell.SetTag(row, align, MedicalViewerTagType.UserData, value != null ? value.ToString() : (string)value);
      }

      private bool CellHasImage()
      {
         return Cell.Image != null;
      }

      private void tabControlDicom_Selected(object sender, TabControlEventArgs e)
      {
         if (e.TabPage == tabPageImages && !CellHasImage() && Dataset != null && loaderThread == null)
         {
            loaderThread = new Thread(new ParameterizedThreadStart(LoadImage));
            loaderThread.Start(Dataset);
         }
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
         Cursor.Current = Cursors.Default;
         if (this.Dataset != null)
         {
            // Do not show the 'image' tab if there is not a pixel data element
            DicomElement elementPixelData = Dataset.FindFirstElement(null, DicomTag.PixelData, true);
            bool isStructuredDisplay = IsStructuredDisplay(Dataset);
            if ((elementPixelData == null) && (!isStructuredDisplay))
            {
               tabControlDicom.TabPages.Remove(tabPageImages);
            }
         }
      }      
   }
}
