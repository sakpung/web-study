// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Leadtools;
using Leadtools.WinForms;
using Leadtools.Dicom;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.ImageProcessing;

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Leadtools.Annotations.Engine;
using FusionDemo.UI;

namespace FusionDemo
{
   public partial class MainForm : Form
   {
      List<List<FusionData>[]> _fusionListNames;
      SeriesBrowser seriesBrowserDialog;
      MedicalViewer _viewer;
      CounterDialog counter;
      AdjustFusionImage _adjustFusionImage = null;
      private CellData _cellData;
      int _counter;
      private bool _alwaysInterpolate;
      private MedicalViewerActionType _actionType;
      private string _openInitialPath =
#if LT_CLICKONCE
            Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
#else
            String.Empty;
#endif // #if LT_CLICKONCE

      public bool AlwaysInterpolate
      {
         get
         {
            return _alwaysInterpolate;
         }

         set
         {
            _alwaysInterpolate = value;
         }
      }

      [STAThread]
      static void Main(string[] args)
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Medical))
         {
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      public MainForm()
      {
         InitializeComponent();
         InitClass();

         _fusionListNames = new List<List<FusionData>[]>();
      }

      ~MainForm()
      {
         if (_viewer != null)
         {
            _viewer.DeleteCell -= new EventHandler<MedicalViewerDeleteEventArgs>(MedicalViewer_DeleteCell);
            _viewer.SelectedCellsChanged -= new EventHandler<MedicalViewerSelectedCellsChangedEventArgs>(_viewer_SelectedCellsChanged);
         }
      }


      private void StartProgress(CounterDialog counterDialog)
      {
         counterDialog.Show();
      }

      private void EndProgress(CounterDialog counterDialog)
      {
         if (counterDialog != null)
         {
            counterDialog.Close();
            counterDialog.Dispose();
            counterDialog = null;
         }
      }

      private void InitializeCell(MedicalViewerMultiCell cell)
      {
         cell.ShowCellScroll = true;
         cell.PaintingMethod = MedicalViewerPaintingMethod.Bicubic;
         cell.FitImageToCell = false;
         cell.SetScaleMode(MedicalViewerScaleMode.Fit);
         cell.SnapRulers = false;

         AddBasicActionsFor2DCell(cell);

         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active );
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active );
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active);
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active);

         cell.SetActionKeys(MedicalViewerActionType.Stack, new MedicalViewerKeys(Keys.PageUp, Keys.PageDown, Keys.None, Keys.None, MedicalViewerModifiers.None));

         cell.SetActionKeys(MedicalViewerActionType.WindowLevel, new MedicalViewerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, MedicalViewerModifiers.Ctrl));

         cell.AlwaysInterpolate = AlwaysInterpolate;

         SetAction(cell, _actionType);

         cell.Selected = true;

         cell.SelectedSubCellChanged += new EventHandler<MedicalViewerActiveSubCellChangedEventArgs>(cell_SelectedSubCellChanged);

      }

      void cell_SelectedSubCellChanged(object sender, MedicalViewerActiveSubCellChangedEventArgs e)
      {
         CheckFusionTranslucencyAction(e.CellIndex);
      }

      void SetAllItemsEnabled(ContextMenuStrip menu, bool enabled)
      {
         foreach (ToolStripItem item in menu.Items)
         {
            item.Enabled = enabled;
         }
      }

      void SetAllItemsVisible(ContextMenuStrip menu, bool visible)
      {
         foreach (ToolStripItem item in menu.Items)
         {
            item.Visible = visible;
         }
      }

      void AddBasicActionsFor2DCell(MedicalViewerBaseCell cell)
      {
         cell.AddAction(MedicalViewerActionType.Scale);
         cell.AddAction(MedicalViewerActionType.Offset);
         cell.AddAction(MedicalViewerActionType.Stack);
         cell.AddAction(MedicalViewerActionType.MagnifyGlass);
         cell.AddAction(MedicalViewerActionType.WindowLevel);
         cell.AddAction(MedicalViewerActionType.FusionTranslucency);
         if (cell.CanExecuteAction(MedicalViewerActionType.Alpha))
            cell.AddAction(MedicalViewerActionType.Alpha);
      }

      private void InitClass()
      {
         try
         {
            DicomEngine.Startup();

            _viewer = new MedicalViewer(2, 2);

            _viewer.DeleteCell += new EventHandler<MedicalViewerDeleteEventArgs>(MedicalViewer_DeleteCell);

            _viewer.SelectedCellsChanged += new EventHandler<MedicalViewerSelectedCellsChangedEventArgs>(_viewer_SelectedCellsChanged);

            _viewer.AllowMultipleSelection = true;

            _displayPanel.Controls.Add(_viewer);

            AlwaysInterpolate = true;

            _actionType = MedicalViewerActionType.WindowLevel;
            _menuActionWindowLevel.Checked = true;

         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, ex.Source);
         }
      }

      void _viewer_SelectedCellsChanged(object sender, MedicalViewerSelectedCellsChangedEventArgs e)
      {
         CheckFusionTranslucencyAction(e.CellIndex);
      }

      public void CheckFusionTranslucencyAction(int cellIndex)
      {
         if (_actionType == MedicalViewerActionType.FusionTranslucency)
         {
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_viewer.Cells[cellIndex];

            if (!cell.Selected)
               return;

            if (cell.SubCells[cell.ActiveSubCell].Fusion.Count < 1)
            {
               _actionType = MedicalViewerActionType.WindowLevel;
               foreach (Control control in _viewer.Cells)
               {
                  SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel);
               }
            }
         }
      }

      void DeleteFusionImages(MedicalViewerMultiCell cell)
      {
         int subCellIndex = 0;
         int length = cell.SubCells.Count;
         int index = 0;
         RasterImage image = null;
         MedicalViewerSubCell subCell;

         for ( ; subCellIndex < length; subCellIndex++)
         {
            subCell = cell.SubCells[subCellIndex];

            for ( ; index < subCell.Fusion.Count; )
            {
               image = subCell.Fusion[index].FusedImage;
               subCell.Fusion.RemoveAt(index);
               if (image != null)
                  image.Dispose();
            }
         }
      }


      void MedicalViewer_DeleteCell(object sender, MedicalViewerDeleteEventArgs e)
      {

         for (int index = 0; index < e.CellIndexes.Length; index++)
         {

            int cellIndex = e.CellIndexes[index];
            MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_viewer.Cells[cellIndex];
            _fusionListNames.RemoveAt(cellIndex);

            if (_adjustFusionImage != null && cell.Equals(_adjustFusionImage.Cell))
               _adjustFusionImage.Close();

            DeleteFusionImages(cell);
         }

         for (int index = 0; index <_viewer.Cells.Count; index++)
         {
            if (index != e.CellIndexes[0])
            {
               _viewer.Cells[index].Selected = true;
               return;
            }
         }
      }

      private void _menuItemFileLoadDICOMDIR_Click(object sender, EventArgs e)
      {
         // if there is an already instance of the series browser, then don't create the a new one. and just use the already created one
         // You will notice that all the data (series and study) are still stored.
         if (seriesBrowserDialog == null)
         {
            seriesBrowserDialog = new SeriesBrowser();
            seriesBrowserDialog.LoadAs3D = false;
            seriesBrowserDialog.HideLoadAs3D = true;
            // this will be fired every time the browser loads a new frame.
            seriesBrowserDialog.FrameLoaded += new FrameLoadedEventHandler(seriesBrowserDialog_FrameLoaded);
         }
         seriesBrowserDialog.ShowDialog();
      }

      void seriesBrowserDialog_FrameLoaded(object sender, FrameLoadedEventArgs e)
      {
         try
         {
            if (e.State == FrameLoadedState.StartLoading)
            {
               _cellData = new CellData();
               _cellData.FileNames = new string[e.PageCount];
               _cellData.InstanceNumbers = new int[e.PageCount];
               _cellData.ImagePositions = new Point3D[e.PageCount];
               _cellData.ImageOrientation = new double[e.PageCount][];
               _counter = 0;
            }

            if (e.State == FrameLoadedState.FrameLoaded)
            {
               _cellData.InstanceNumbers[_counter] = e.InstanceNumber;
               _cellData.FileNames[_counter] = e.ImagePath;
               _cellData.ImagePositions[_counter] = e.ImagePosition;
               double[] output = new double[e.ImageOrientation.Length];
               for (int i = 0; i < e.ImageOrientation.Length; i++)
               {
                  output[i] = e.ImageOrientation[i];
               }
               _cellData.ImageOrientation[_counter] = output;
               _counter++;
            }

            if (e.State == FrameLoadedState.EndLoading)
            {
               LoadImagesToMedicalViewer(e.SeriesInformation, e.ImageOrientation, seriesBrowserDialog.LoadAs3D);
            }
         }
         catch (Exception)
         {
            e.Cancel = true;
         }
      }

      private bool LoadImagesToMedicalViewer(SeriesInformation image, float[] imageOrientation, bool loadAs3D)
      {
         seriesBrowserDialog.DisableLoading = true;

         CellData data = _cellData;

         MedicalViewerMultiCell cell = new MedicalViewerMultiCell(null, true, 1, 1);
         cell.Tag = data;


         InitializeCell(cell);
         cell.Focus();

         SetCellTags(cell, image);

         cell.PixelSpacing = new Point2D((float)image.VoxelSpacing.X, (float)image.VoxelSpacing.Y);

         cell.FrameOfReferenceUID = image.FrameOfReferenceUID;
         if (imageOrientation != null)
         {
            if (imageOrientation.Length != 0)
               cell.ImageOrientation = imageOrientation;
         }
         else
         {
            _cellData.CellType = ViewerCellType.Other;
         }
          ((CellData)cell.Tag).FrameIndex = (image.DicomFrameNumber + 1);


         EnableCellLowMemoryUsage(cell);
         cell.SetScaleMode(MedicalViewerScaleMode.Fit);
         SetFrameInformation(cell);
         AddCellToViewer(cell, cell.VirtualImage.Count);


         if (_viewer.Cells.Count == 1)
            cell.Selected = true;

         seriesBrowserDialog.DisableLoading = false;

         return true;
      }

      void SetFrameInformation(MedicalViewerMultiCell cell)
      {
         int index;
         CellData data = (CellData)cell.Tag;
         int count = data.FileNames.Length;

         for (index = 0; index < count; index++)
         {
            cell.SetTag(index, 5, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Im: " + data.InstanceNumbers[index].ToString() + " / " + count.ToString());
            cell.SetImagePosition(index, data.ImagePositions[index], index == (count - 1));
         }
      }

      private void EnableCellLowMemoryUsage(MedicalViewerMultiCell cell)
      {
         CellData cellData = ((CellData)cell.Tag);
         int count = cellData.FileNames.Length;
         int index;
         CellData data = (CellData)cell.Tag;
         MedicalViewerImageInformation[] imagesInformation = new MedicalViewerImageInformation[count];
         using (RasterCodecs codecs = new RasterCodecs())
         {
            CounterDialog counter = new CounterDialog(count, 1, this);
            counter.LoadingObject = true;
            counter.LoadingText = "Preparing Series Data";
            counter.Show();
            counter.Update();

            for (index = 0; index < count; index++)
            {
               using (CodecsImageInfo codecsInformation = codecs.GetInformation(cellData.FileNames[index], true, cellData.FrameIndex))
               {
                  counter.Percent = (index * 100 / (Math.Max(count - 1, 1)));
                  if ((index % 5) == 0)
                     Application.DoEvents();
                  imagesInformation[index] = new MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height);
               }
            }

            counter.Close();
            counter.Dispose();

            cell.FramesRequested += new EventHandler<MedicalViewerRequestedFramesInformationEventArgs>(cell_FramesRequested);
            cell.EnableLowMemoryUsage(2, cellData.FileNames.Length, imagesInformation);
         }
      }

      RasterImage LoadRequestedFrameFileName(MedicalViewerRequestedFramesInformationEventArgs e, RasterCodecs codecs, CellData data, int index)
      {
         DicomDataSet ds = new DicomDataSet();
         RasterImage image = null;
         if (data.CellType != ViewerCellType.SingleFileSeries)
         {
            ds.Load(data.FileNames[index], DicomDataSetLoadFlags.None);
            image = ds.GetImage(null, data.FrameIndex - 1, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AllowRangeExpansion);

         }
         else
         {
            image = GetImage(ds, data.FileNames[0], index);
         }

         ds.Dispose();
         return image;
      }

      void cell_FramesRequested(object sender, MedicalViewerRequestedFramesInformationEventArgs e)
      {
         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)sender;
         CellData data = (CellData)cell.Tag;

         MedicalViewer viewer = (MedicalViewer)cell.Parent;
         if (data == null)
            return;

         int cellIndex = (viewer == null) ? _viewer.Cells.Count : e.CellIndex;

         using (RasterCodecs codecs = new RasterCodecs())
         {
            int i;

            if (e.RequestedFramesIndexes.Length > 0)
            {
               using (RasterImage image = LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes[0]))
               {
                  FillSubCellFusion(cell, cellIndex, e.RequestedFramesIndexes[0]);

                  for (i = 1; i < e.RequestedFramesIndexes.Length; i++)
                  {
                     image.AddPage(LoadRequestedFrameFileName(e, codecs, data, e.RequestedFramesIndexes[i]));

                     FillSubCellFusion(cell, cellIndex, e.RequestedFramesIndexes[i]);
                  }

                  cell.SetRequestedImage(image, e.RequestedFramesIndexes, MedicalViewerSetImageOptions.Insert);
               }
            }
         }
      }

      private void FillSubCellFusion(MedicalViewerMultiCell cell, int cellIndex, int frameIndex)
      {
         DicomDataSet ds = new DicomDataSet();
         List<FusionData>[] cellFusions = null;
         if (_fusionListNames.Count > cellIndex)
            cellFusions = _fusionListNames[cellIndex];

         IList<MedicalViewerFusion> fusions = cell.SubCells[frameIndex].Fusion;
         //initialize fusion for sub cell
         if (_fusionListNames.Count > cellIndex && cellFusions[frameIndex] != null && fusions.Count != cellFusions[frameIndex].Count)
         {
            for (int i = 0; i < cellFusions[frameIndex].Count; i++)
            {
               MedicalViewerFusion fusion = new MedicalViewerFusion();
               fusion.FusionScale = 50 / 100.0f;
               fusion.DisplayRectangle = new RectangleF(0, 0, 1, 1);

               cell.SubCells[frameIndex].Fusion.Add(fusion);
            }
         }

         //put image in sub cell fusion
         for (int i = 0; i < fusions.Count; i++)
         {
            fusions[i].FusedImage = GetImage(ds, cellFusions[frameIndex][i].Filename, cellFusions[frameIndex][i].Index);
         }
         ds.Dispose();
      }

      private void SetCellTags(MedicalViewerMultiCell cell, SeriesInformation image)
      {
         cell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, MedicalViewerTagType.LeftOrientation);
         cell.SetTag(0, MedicalViewerTagAlignment.RightCenter, MedicalViewerTagType.RightOrientation);
         cell.SetTag(0, MedicalViewerTagAlignment.TopCenter, MedicalViewerTagType.TopOrientation);
         cell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, MedicalViewerTagType.BottomOrientation);

         cell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.InstitutionName);
         cell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientName);
         cell.SetTag(4, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientAge);
         cell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientBirthDate);
         cell.SetTag(6, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientSex);
         cell.SetTag(7, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, image.PatientID);

         cell.SetTag(9, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.AccessionNumber);
         cell.SetTag(8, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.StudyDate);
         cell.SetTag(7, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.AcquisitionTime);
         cell.SetTag(6, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, image.SeriesTime);
         cell.SetTag(5, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.FieldOfView);

         cell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, image.AccessionNumber);
         cell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, image.StudyDate);
         cell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, image.AcquisitionTime);
         cell.SetTag(7, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Frame);
         if (image.EchoNumber != -1)
            cell.SetTag(8, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Echo: " + image.EchoNumber.ToString());


         cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData);

         cell.SetTag(4, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.Alpha);

         cell.SetTag(6, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Scale);
      }


      public int GetFirstSelectedMultiCellIndex()
      {
         int counter = 0;
         foreach (Control control in _viewer.Cells)
         {
            if (control is MedicalViewerMultiCell)
            {
               MedicalViewerMultiCell cell = (MedicalViewerMultiCell)control;

               if (cell.Selected)
                  return counter;

               counter++;
            }
         }
         return -1;
      }

      public List<int> GetSelectedMultiCellIndexs()
      {
         int counter = 0;

         List<int> selectedCells = new List<int>();


         foreach (Control control in _viewer.Cells)
         {
            if (control is MedicalViewerMultiCell)
            {
               MedicalViewerMultiCell cell = (MedicalViewerMultiCell)control;

               if (cell.Selected)
                  selectedCells.Add(counter);

               object aa = cell.Tag;

               counter++;
            }
         }

         return selectedCells;
      }


      public MedicalViewerMultiCell GetFirstSelectedMultiCell()
      {
         foreach (Control control in _viewer.Cells)
         {
            if (control is MedicalViewerMultiCell)
            {
               MedicalViewerMultiCell cell = (MedicalViewerMultiCell)control;

               if (cell.Selected)
                  return (MedicalViewerMultiCell)control;
            }
         }
         return null;
      }


      MedicalViewerCell GetFirstSelectedCell()
      {
         foreach (Control control in _viewer.Cells)
         {
            if (control is MedicalViewerCell)
            {
               MedicalViewerCell cell = (MedicalViewerCell)control;

               if (cell.Selected)
                  return (MedicalViewerCell)control;
            }
         }
         return null;
      }


      Medical3DControl GetFirstSelected3DControl()
      {
         foreach (Control control in _viewer.Cells)
         {
            if (control is Medical3DControl)
            {
               Medical3DControl ctrl3D = (Medical3DControl)control;

               if (ctrl3D.Selected)
                  return (Medical3DControl)control;
            }
         }
         return null;
      }

      private void _mainPanel_SizeChanged(object sender, EventArgs e)
      {
         if (_viewer != null)
         {
            if (_displayPanel != null)
            {
               _displayPanel.Left = 0;
               _displayPanel.Top = 0;
               _displayPanel.Width = _mainPanel.Width;
               _displayPanel.Height = _mainPanel.Height;
            }

            _viewer.SetBounds(_displayPanel.Left, _displayPanel.Top, _displayPanel.Width, _displayPanel.Height);
         }
      }

      private void EnableCellLowMemoryUsage(MedicalViewerMultiCell cell, string fileName, CodecsImageInfo info)
      {
         int index;
         int count = info.TotalPages;
         CellData cellData = ((CellData)cell.Tag);

         MedicalViewerImageInformation[] imagesInformation = new MedicalViewerImageInformation[count];

         using (RasterCodecs codecs = new RasterCodecs())
         {
            using (CodecsImageInfo codecsInformation = codecs.GetInformation(fileName, true, cellData.FrameIndex))
            {

               for (index = 0; index < count; index++)
               {
                  imagesInformation[index] = new MedicalViewerImageInformation(codecsInformation.XResolution, codecsInformation.YResolution, codecsInformation.Width, codecsInformation.Height);
               }

               cell.FramesRequested += new EventHandler<MedicalViewerRequestedFramesInformationEventArgs>(cell_FramesRequested);
               cell.EnableLowMemoryUsage(2, count, imagesInformation);
            }
         }
      }


      private void GetFileName(out string fileName, Form owner)
      {
         RasterCodecs codecs = new RasterCodecs();
         ImageFileLoader loader = new ImageFileLoader();
         fileName = "";
         loader.OpenDialogInitialPath = _openInitialPath;
         try
         {
            loader.ShowLoadPagesDialog = false;
            if (loader.Load(owner, codecs, false) != 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               fileName = "";
               if (loader.LastPage != 0)
               {
                  counter = new CounterDialog(loader.LastPage == -1 ? -1 : loader.LastPage - loader.FirstPage + 1, 0, this);
                  counter.FirstPage = loader.FirstPage;

                  fileName = loader.FileName;

                  if (fileName.IndexOf("DICOMDIR") != -1)
                  {
                     MessageBox.Show("You cannot load the DICOMDIR from here, use Load DICOMDIR instead", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     fileName = "";
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      void AddNewDicomDirectoryTab(bool dicomDirectroyAvailable)
      {
         return;
      }


      // This method returns the specified DICOM tag in a string format.
      string GetDicomTag(DicomDataSet ds, long tag)
      {
         DicomElement patientElement = ds.FindFirstElement(null,
                                              tag,
                                              true);

         if (patientElement != null)
            return ds.GetConvertValue(patientElement);

         return null;
      }


      private RasterImage GetImage(DicomDataSet dicomDataSet, string imagePath, int index)
      {
         try
         {
            dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None);
            return dicomDataSet.GetImage(null, index, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AllowRangeExpansion);

         }
         catch (Exception)
         {
            RasterCodecs _codecs = new RasterCodecs();

            return _codecs.Load(imagePath, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1);
         }
      }

      // Load the DICOM file
      private SeriesInformation LoadDICOM(string imagePath)
      {
         try
         {
            SeriesInformation imageInformation = new SeriesInformation();


            DicomDataSet dicomDataSet = new DicomDataSet();

            imageInformation.Image = GetImage(dicomDataSet, imagePath, 0);
            if (imageInformation.Image == null)
            {
               dicomDataSet.Dispose();
               return null;
            }

            double[] orientation;
            double[] doubleArray;

            DicomElement patientElement = dicomDataSet.FindFirstElement(null,
                                                             DicomTag.PixelSpacing,
                                                             true);

            if (patientElement != null)
            {
               doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 1);
               imageInformation.VoxelSpacing = new Point3D((float)doubleArray[0], (float)doubleArray[0], 0);
            }

            patientElement = dicomDataSet.FindFirstElement(null,
                                                 DicomTag.ImageOrientationPatient,
                                                 true);

            if (patientElement != null)
            {
               orientation = dicomDataSet.GetDoubleValue(patientElement, 0, 6);
               imageInformation.ImageOrientation = orientation;
            }

            patientElement = dicomDataSet.FindFirstElement(null,
                                                 DicomTag.ImagePositionPatient,
                                                 true);

            if (patientElement != null)
            {
               doubleArray = dicomDataSet.GetDoubleValue(patientElement, 0, 3);
               imageInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray);
            }

            patientElement = dicomDataSet.FindFirstElement(null,
                                                 DicomTag.FrameOfReferenceUID,
                                                 true);

            if (patientElement != null)
            {
               string str = dicomDataSet.GetConvertValue(patientElement);
               imageInformation.FrameOfReferenceUID = str;
            }


            imageInformation.InstitutionName = GetDicomTag(dicomDataSet, DicomTag.InstitutionName);
            imageInformation.PatientName = GetDicomTag(dicomDataSet, DicomTag.PatientName);
            imageInformation.PatientAge = GetDicomTag(dicomDataSet, DicomTag.PatientAge);
            imageInformation.PatientBirthDate = GetDicomTag(dicomDataSet, DicomTag.PatientBirthDate);
            imageInformation.PatientSex = GetDicomTag(dicomDataSet, DicomTag.PatientSex);
            imageInformation.PatientID = GetDicomTag(dicomDataSet, DicomTag.PatientID);
            imageInformation.AccessionNumber = GetDicomTag(dicomDataSet, DicomTag.AccessionNumber);
            imageInformation.StudyDate = GetDicomTag(dicomDataSet, DicomTag.StudyDate);
            imageInformation.AcquisitionTime = GetDicomTag(dicomDataSet, DicomTag.AcquisitionTime);
            imageInformation.SeriesTime = GetDicomTag(dicomDataSet, DicomTag.SeriesTime);
            imageInformation.StationName = GetDicomTag(dicomDataSet, DicomTag.StationName);
            imageInformation.StudyID = GetDicomTag(dicomDataSet, DicomTag.StudyID);
            imageInformation.SeriesDescription = GetDicomTag(dicomDataSet, DicomTag.SeriesDescription);
            imageInformation.ImageComments = GetDicomTag(dicomDataSet, DicomTag.ImageComments);

            return imageInformation;
         }
         catch (System.Exception ex)
         {
            Messager.Show(this, ex, MessageBoxIcon.Exclamation);
         }

         return null;
      }

      public void LoadDicomImage(Form owner)
      {
         string imagePath;
         RasterCodecs codecs = new RasterCodecs();
         GetFileName(out imagePath, owner);

         // Insert new cell if the user has selected an image.
         if (imagePath != "")
         {
            SeriesInformation imageInformation = LoadDICOM(imagePath);
            if (imageInformation == null)
               return;
            RasterImage image = imageInformation.Image;

            if (imageInformation == null)
            {
               image.Dispose();
               return;
            }

            MedicalViewerMultiCell cell = new MedicalViewerMultiCell(null, true, 1, 1);
            CellData cellData = new CellData(ViewerCellType.SingleFileSeries);
            cellData.FileNames = new string[1];
            cellData.FileNames[0] = imagePath;
            cell.Tag = cellData;

            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;
            CodecsImageInfo info = codecs.GetInformation(imagePath, true);

            EnableCellLowMemoryUsage(cell, imagePath, info);

            Cursor = oldCursor;

            InitializeCell(cell);
            AddCellToViewer(cell, cell.VirtualImage.Count);
            SetCellTags(cell, imageInformation);
            cell.SnapRulers = false;

            if (_viewer.Cells.Count == 1)
               cell.Selected = true;


            image.Dispose();
         }
      }


      private void _menuItemFileLoadDICOM_Click(object sender, EventArgs e)
      {
         LoadDicomImage(this);
      }

      private void _menuFile_exit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _menuEdit_DropDownOpening(object sender, EventArgs e)
      {
         _menuAdjustFusion.Enabled =
         _menuAddFusion.Enabled =
         _menuDeleteAll.Enabled = _viewer.Cells.Count != 0;

         _menuFuseTwoCells.Enabled = (GetSelectedMultiCellIndexs().Count == 2);

         int cellIndex = GetFirstSelectedMultiCellIndex();

         if (cellIndex == -1)
         {
            _menuAddFusion.Enabled =
            _menuAdjustFusion.Enabled = false;
            return;
         }

         if (_adjustFusionImage != null && _adjustFusionImage.Visible)
            _menuAddFusion.Enabled = false;
      }

      private void CopyTags(MedicalViewerBaseCell destinationCell, MedicalViewerBaseCell cell, bool addWindowLevelTag)
      {
         CopyTags(destinationCell, cell, addWindowLevelTag, true);
      }


      private void CopyTags(MedicalViewerBaseCell destinationCell, MedicalViewerBaseCell cell, bool addWindowLevelTag, bool addScaleTag)
      {
         MedicalViewerTagInformation information;
         information = cell.GetTag(0, MedicalViewerTagAlignment.LeftCenter);
         if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.LeftCenter, information.Type);
         information = cell.GetTag(0, MedicalViewerTagAlignment.RightCenter);
         if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.RightCenter, information.Type);
         information = cell.GetTag(0, MedicalViewerTagAlignment.TopCenter);
         if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.TopCenter, information.Type);
         information = cell.GetTag(0, MedicalViewerTagAlignment.BottomCenter);
         if (information != null) destinationCell.SetTag(0, MedicalViewerTagAlignment.BottomCenter, information.Type);

         information = cell.GetTag(2, MedicalViewerTagAlignment.TopRight);
         if (information != null) destinationCell.SetTag(2, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(3, MedicalViewerTagAlignment.TopRight);
         if (information != null) destinationCell.SetTag(3, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(4, MedicalViewerTagAlignment.TopRight);
         if (information != null) destinationCell.SetTag(4, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(5, MedicalViewerTagAlignment.TopRight);
         if (information != null) destinationCell.SetTag(5, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(6, MedicalViewerTagAlignment.TopRight);
         if (information != null) destinationCell.SetTag(6, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(7, MedicalViewerTagAlignment.TopRight);
         if (information != null) destinationCell.SetTag(7, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, information.Text);

         information = cell.GetTag(9, MedicalViewerTagAlignment.BottomRight);
         if (information != null) destinationCell.SetTag(9, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(8, MedicalViewerTagAlignment.BottomRight);
         if (information != null) destinationCell.SetTag(8, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(7, MedicalViewerTagAlignment.BottomRight);
         if (information != null) destinationCell.SetTag(7, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(6, MedicalViewerTagAlignment.BottomRight);
         if (information != null) destinationCell.SetTag(6, MedicalViewerTagAlignment.BottomRight, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(5, MedicalViewerTagAlignment.BottomRight);
         if (information != null) destinationCell.SetTag(5, MedicalViewerTagAlignment.BottomRight, information.Type);


         information = cell.GetTag(2, MedicalViewerTagAlignment.TopLeft);
         if (information != null) destinationCell.SetTag(2, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(3, MedicalViewerTagAlignment.TopLeft);
         if (information != null) destinationCell.SetTag(3, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text);
         information = cell.GetTag(4, MedicalViewerTagAlignment.TopLeft);
         if (information != null) destinationCell.SetTag(4, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, information.Text);

         if (addWindowLevelTag)
         {
            information = cell.GetTag(2, MedicalViewerTagAlignment.BottomLeft);
            if (information != null) destinationCell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, information.Type);
         }

         if (addScaleTag)
         {
            information = cell.GetTag(6, MedicalViewerTagAlignment.TopLeft);
            if (information != null) destinationCell.SetTag(6, MedicalViewerTagAlignment.TopLeft, information.Type);

            information = cell.GetTag(7, MedicalViewerTagAlignment.TopLeft);
            if (information != null) destinationCell.SetTag(7, MedicalViewerTagAlignment.TopLeft, information.Type);
         }
      }

      private void LoadImages()
      {
         string[] files = Directory.GetFiles(DemosGlobal.ImagesFolder, "*.dcm");
         using (RasterCodecs codecs = new RasterCodecs())
         {

            for (int i = 0; i < _viewer.Cells.Count; i++)
            {
               if (i >= files.Length)
                  break;

               try
               {
                  ((MedicalViewerCell)_viewer.Cells[i]).Image = codecs.Load(files[i]);
               }
               catch { }
            }
         }
      }

      private void _menuAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Fusion Demo", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _menuLayoutOptions_Click(object sender, EventArgs e)
      {
         (new LayoutOptions(_viewer, this)).ShowDialog(this);
      }


      private void UncheckThePerviousMenuItem(ToolStripMenuItem sender)
      {
         foreach (ToolStripMenuItem item in sender.Owner.Items)
         {
            if (item.Checked)
               item.Checked = false;
         }
      }

      private void SetAction(MedicalViewerBaseCell cell, MedicalViewerActionType actionType)
      {
         cell.SetAction(actionType, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active );

         if (actionType == MedicalViewerActionType.WindowLevel)
            cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active );
         else
            cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active );

         if (actionType != MedicalViewerActionType.Scale)
            cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle , MedicalViewerActionFlags.Active);
         else
            cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active);
      }

      private void SetAction(Control control, MedicalViewerActionType actionType, ToolStripMenuItem sender)
      {
         MedicalViewerBaseCell cell = (MedicalViewerBaseCell)control;
         UncheckThePerviousMenuItem(sender);
         sender.Checked = true;
         SetAction(cell, actionType);
      }

      private void _menuActionWindowLevel_Click(object sender, EventArgs e)
      {
         _actionType = MedicalViewerActionType.WindowLevel;
         foreach (Control control in _viewer.Cells)
         {
            SetAction(control, MedicalViewerActionType.WindowLevel, _menuActionWindowLevel);
         }
      }

      private void _menuActionAlpha_Click(object sender, EventArgs e)
      {
         _actionType = MedicalViewerActionType.Alpha;
         foreach (Control control in _viewer.Cells)
         {
            SetAction(control, MedicalViewerActionType.Alpha, _menuActionAlpha);
         }
      }

      private void _menuActionScale_Click(object sender, EventArgs e)
      {
         _actionType = MedicalViewerActionType.Scale;
         foreach (Control control in _viewer.Cells)
         {
            SetAction(control, MedicalViewerActionType.Scale, _menuActionScale);
         }
      }

      private void _menuActionMagnify_Click(object sender, EventArgs e)
      {
         _actionType = MedicalViewerActionType.MagnifyGlass;
         foreach (Control control in _viewer.Cells)
         {
            SetAction(control, MedicalViewerActionType.MagnifyGlass, _menuActionMagnify);
         }
      }

      private void _menuActionPan_Click(object sender, EventArgs e)
      {
         _actionType = MedicalViewerActionType.Offset;
         foreach (Control control in _viewer.Cells)
         {
            SetAction(control, MedicalViewerActionType.Offset, _menuActionPan);
         }
      }

      void AddCellToViewer(MedicalViewerBaseCell control, int count)
      {
         if (_viewer != null)
         {
            _viewer.Cells.Add(control);
            _fusionListNames.Add(new List<FusionData>[count]);
         }
      }

      public List<List<FusionData>[]> FusionListNames
      {
         get
         {
            return _fusionListNames;
         }
      }

      MedicalViewerBaseCell GetFirstSelectedControl()
      {
         foreach (Control control in _viewer.Cells)
         {
            MedicalViewerBaseCell cell = (MedicalViewerBaseCell)control;

            if (cell.Selected)
               return (MedicalViewerBaseCell)control;
         }
         return null;
      }

      private void _actionsMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         ToolStripMenuItem parent = ((ToolStripMenuItem)sender);
         foreach (ToolStripMenuItem item in parent.DropDownItems)
         {
            item.Enabled = (_viewer.Cells.Count != 0);
         }

         int cellIndex = GetFirstSelectedMultiCellIndex();

         if (cellIndex == -1)
         {
            _menuActionTranslucensy.Enabled = false;
            return;
         }

         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_viewer.Cells[cellIndex];

         _menuActionTranslucensy.Enabled = (cell.SubCells[cell.ActiveSubCell].Fusion.Count > 0);
      }

      private void _menuUnload_Click(object sender, EventArgs e)
      {
         MedicalViewerBaseCell cell = (MedicalViewerBaseCell)GetFirstSelectedControl();

         DeleteCell(cell);
      }

      void DeleteCell(MedicalViewerBaseCell cell)
      {
         if (cell != null)
         {
            int index = _viewer.Cells.IndexOf(cell);
            _viewer.Cells.Remove(cell);
            _fusionListNames.RemoveAt(index);

            DeleteFusionImages((MedicalViewerMultiCell)cell);
            cell.Dispose();
         }
      }

      private void _menuDeleteAll_Click(object sender, EventArgs e)
      {
         MedicalViewerBaseCell cell = null;

         while (_viewer.Cells.Count != 0)
         {
            cell = _viewer.Cells[0];
            DeleteCell(cell);
         }

         if (_adjustFusionImage != null)
            _adjustFusionImage.Close();
      }

      public RasterImage LoadFusionDicom(out string seriesName, out string seriesPath, Form owner)
      {
         seriesName = "";
         string imagePath;
         GetFileName(out imagePath, owner);

         seriesPath = imagePath;

         if (imagePath != "")
         {
            SeriesInformation imageInformation = LoadDICOM(imagePath);

            seriesName = imageInformation.PatientName;

            if (seriesName == null)
            {
               string[] stringArray = imagePath.Split(new char[1] {'\\'});

               seriesName = stringArray[stringArray.Length - 1];
            }

            return imageInformation.Image;
         }

         return null;
      }

      private void _menuAddFusion_Click(object sender, EventArgs e)
      {
         int cellIndex = GetFirstSelectedMultiCellIndex();

         if (cellIndex == -1)
            return;

         AddFusionImage fusionImage = new AddFusionImage(_viewer, this);
         fusionImage.ShowDialog();
      }

      private void _menuAdjustFusion_Click(object sender, EventArgs e)
      {
         if (_adjustFusionImage != null && _adjustFusionImage.Visible)
            return;

         int cellIndex = GetFirstSelectedMultiCellIndex();

         if (cellIndex == -1)
            return;

         _adjustFusionImage = new AdjustFusionImage(_viewer, this);
         _adjustFusionImage.Show(this);
         _adjustFusionImage.Location = new Point((int)(this.Width * 0.75) - _adjustFusionImage.Width / 2 + this.Location.X, (int)(this.Height * 0.25) - _adjustFusionImage.Height / 2 + this.Location.Y);
      }

      private void _menuProperties_Click(object sender, EventArgs e)
      {
         LayoutOptions options = new LayoutOptions(_viewer, this);
         options.ShowDialog();
      }

      private void _menuFuseTwoCells_Click(object sender, EventArgs e)
      {
         List<int> indexs = GetSelectedMultiCellIndexs();

         MedicalViewerMultiCell orgCell = (MedicalViewerMultiCell)_viewer.Cells[indexs[0]];
         MedicalViewerMultiCell fuCell = (MedicalViewerMultiCell)_viewer.Cells[indexs[1]];

         MedicalViewerMultiCell cell = new MedicalViewerMultiCell(null, true, 1, 1);
         CellData cellData = new CellData();

         CellData orgCellData = (CellData)orgCell.Tag;
         CellData fuCellData = (CellData)fuCell.Tag;

         cellData.CellType = orgCellData.CellType;
         cellData.SyncCellFusion = true;

         cellData.FileNames = new string[orgCellData.FileNames.Length];
         orgCellData.FileNames.CopyTo(cellData.FileNames, 0);

         cellData.FrameIndex = orgCellData.FrameIndex;

         if (orgCellData.ImagePositions != null)
         {
            cellData.ImagePositions = new Point3D[orgCellData.ImagePositions.Length];
            orgCellData.ImagePositions.CopyTo(cellData.ImagePositions, 0);
         }

         if (orgCellData.InstanceNumbers != null)
         {
            cellData.InstanceNumbers = new int[orgCellData.InstanceNumbers.Length];
            orgCellData.InstanceNumbers.CopyTo(cellData.InstanceNumbers, 0);
         }

         cell.Tag = cellData;

         InitializeCell(cell);
         cell.Focus();

         cell.PixelSpacing = new Point2D(orgCell.PixelSpacing.X, orgCell.PixelSpacing.Y);

         cell.FrameOfReferenceUID = orgCell.FrameOfReferenceUID;
         if (orgCell.ImageOrientation != null)
         {
            if (orgCell.ImageOrientation.Length != 0)
               cell.ImageOrientation = orgCell.ImageOrientation;
         }
         else
         {
            _cellData.CellType = ViewerCellType.Other;
         }

         cell.SelectedSubCellChanged += new EventHandler<MedicalViewerActiveSubCellChangedEventArgs>(fusecell_SelectedSubCellChanged);

         AddCellToViewer(cell, orgCell.VirtualImage.Count);

         int cellIndex = _viewer.Cells.IndexOf(cell);

         FuseTwoCellsProperties FuseTwoCellsPropertiesDlg = new FuseTwoCellsProperties(orgCell, fuCell);

         if (fuCellData.ImagePositions == null || fuCellData.ImageOrientation == null)
            FuseTwoCellsPropertiesDlg.BestAlignedChecked = FuseTwoCellsPropertiesDlg.EnableBestAligned = false;

         FuseTwoCellsPropertiesDlg.ShowDialog();

         //fill _fusionListNames with the fusion image file name and index
         for (int i = FuseTwoCellsPropertiesDlg.Start - 1; i < FuseTwoCellsPropertiesDlg.End; i++)
         {
            if (_fusionListNames[cellIndex][i] == null)
               _fusionListNames[cellIndex][i] = new List<FusionData>();


            int indx = i;
            if (FuseTwoCellsPropertiesDlg.UseBestAligned)
            {
               indx = orgCell.BestAligned(i, fuCellData.ImagePositions, fuCellData.ImageOrientation);
               if (indx == -1)
                  indx = i;
            }
            indx = indx - FuseTwoCellsPropertiesDlg.Start + 1;

            if (fuCellData.CellType != ViewerCellType.SingleFileSeries)
            {
               DicomDataSet dicomDataSet = new DicomDataSet();

               GetImage(dicomDataSet, fuCellData.FileNames[indx], 0);

               _fusionListNames[cellIndex][i].Add(new FusionData(fuCellData.FileNames[indx], GetDicomTag(dicomDataSet, DicomTag.PatientName), 0, indx, orgCell, fuCell));
            }
            else
            {
               DicomDataSet dicomDataSet = new DicomDataSet();

               GetImage(dicomDataSet, fuCellData.FileNames[0], indx);

               _fusionListNames[cellIndex][i].Add(new FusionData(fuCellData.FileNames[0], GetDicomTag(dicomDataSet, DicomTag.PatientName), indx, indx, orgCell, fuCell));
            }
         }

         //enable Low Memory Usage for the cell
         if (cellData.CellType != ViewerCellType.SingleFileSeries)
         {
            EnableCellLowMemoryUsage(cell);
            SetFrameInformation(cell);
         }
         else
         {
            using (RasterCodecs codecs = new RasterCodecs())
            {
               CodecsImageInfo info = codecs.GetInformation(cellData.FileNames[0], true);

               EnableCellLowMemoryUsage(cell, cellData.FileNames[0], info);
            }
         }

         //add annotation rectangle for all fusions
         for (int i = FuseTwoCellsPropertiesDlg.Start - 1; i < FuseTwoCellsPropertiesDlg.End; i++)
         {
            AnnRectangleObject rect = new AnnRectangleObject();
            rect.IsVisible = false;
            rect.Stroke =  AnnStroke.Create( AnnSolidColorBrush.Create("Red"), new LeadLengthD(5));

            cell.SubCells[i].AnnotationContainer.Children.Add(rect);
            cell.AnnotationPrecedency = true;


            if (cell.SubCells[i].Fusion.Count == 0)
            {
               MedicalViewerFusion fusion = new MedicalViewerFusion();
               fusion.FusionScale = 50 / 100.0f;
               fusion.DisplayRectangle = new RectangleF(0, 0, 1, 1);

               cell.SubCells[i].Fusion.Add(fusion);
            }
         }

         cell.SetScaleMode(MedicalViewerScaleMode.Fit);
      }

      void fusecell_SelectedSubCellChanged(object sender, MedicalViewerActiveSubCellChangedEventArgs e)
      {
         FusionData fusionData = null;

         if (_fusionListNames[e.CellIndex][e.SubCellIndex] != null)
            fusionData = _fusionListNames[e.CellIndex][e.SubCellIndex][0];

         if (fusionData != null && fusionData.OrignalCell != null && !fusionData.OrignalCell.IsDisposed)
            fusionData.OrignalCell.ActiveSubCell = e.SubCellIndex;

         else if (fusionData == null)//if cell hasn't fusion get cell with fusion OrignalCell and scroll it
         {
            foreach (List<FusionData> list in _fusionListNames[e.CellIndex])
            {
               if (list != null && list[0] != null)
               {
                  list[0].OrignalCell.ActiveSubCell = e.SubCellIndex;
                  break;
               }
            }
         }

         if (fusionData != null && fusionData.FusionCell != null && !fusionData.FusionCell.IsDisposed)
            fusionData.FusionCell.ActiveSubCell = fusionData.OrignalFusionImageIndex;
      }

      private void _menuActionTranslucensy_Click(object sender, EventArgs e)
      {
         _actionType = MedicalViewerActionType.FusionTranslucency;

         foreach (Control control in _viewer.Cells)
         {
            SetAction(control, MedicalViewerActionType.FusionTranslucency, _menuActionTranslucensy);
         }
      }

      private void manualWLToolStripMenuItem_Click(object sender, EventArgs e)
      {
         int widthMin, widthMax, levelMin, levelMax;
         foreach(MedicalViewerCell cell in _viewer.Cells)
         {
            if (cell.Selected)
            {
               int index = _viewer.Cells.IndexOf(cell);
               using (RasterImage image = cell.VirtualImage[cell.ActiveSubCell].Image.Clone())
               {
                  using (MedicalViewerWindowLevel windowLevelProperties = (MedicalViewerWindowLevel)cell.GetActionProperties(MedicalViewerActionType.WindowLevel))
                  {
                     widthMax = (int)Math.Pow(2, image.BitsPerPixel) - 1;
                     widthMin = 1;
                     levelMax = (int)Math.Pow(2, image.BitsPerPixel) - 1;
                     levelMin = (int)Math.Pow(2, image.BitsPerPixel) * -1 + 1;

                     WindowLevelDialog dlg = new WindowLevelDialog(windowLevelProperties.Center, windowLevelProperties.Width, widthMin, widthMax, levelMin, levelMax, index);
                     if (dlg.ShowDialog() == DialogResult.OK)
                     {
                        windowLevelProperties.Center = dlg.WL_Level;
                        windowLevelProperties.Width = dlg.WL_Width;
                        cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevelProperties);
                     }
                  }
               }
            }
         }
      }

      private void _curveTypeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         foreach (MedicalViewerCell cell in _viewer.Cells)
         {
            using (MedicalViewerWindowLevel windowLevelProperties = (MedicalViewerWindowLevel)cell.GetActionProperties(MedicalViewerActionType.WindowLevel))
            {
               switch (sender.ToString())
               {
                  case "Linear":
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Linear;
                     Console.WriteLine(sender.ToString());
                     break;
                  case "Exponential":
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Exponential;
                     Console.WriteLine(sender.ToString());
                     break;
                  case "Logarithmic":
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Logarithmic;
                     Console.WriteLine(sender.ToString());
                     break;
                  case "Sigmoid":
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.Sigmoid;
                     Console.WriteLine(sender.ToString());
                     break;
                  default:
                     windowLevelProperties.LookupTableType = MedicalViewerLookupTableType.None;
                     break;
               }
               cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevelProperties);
            }
         }
      }
   }



   // Determine the type of the cell.
   public enum ViewerCellType
   {
      Derivate,
      SingleFileSeries,
      MPRCell,
      Cell2D,
      Mesh3D,
      LoadedObject,
      Other
   }

   public class FusionData
   {
      public FusionData()
      {
         _index = 0;
      }

      public FusionData(String filename, String name, int index)
      {
         _name = name;
         _filename = filename;
         _index = index;
         _orignalFusionImageIndex = 0;
      }

      public FusionData(String filename, String name, int index, int orignalFusionImageIndex, MedicalViewerMultiCell orgCell, MedicalViewerMultiCell fuCell)
      {
         _name = name;
         _filename = filename;
         _index = index;
         _orignalFusionImageIndex = orignalFusionImageIndex;
         _orignalCell = orgCell;
         _fusionCell = fuCell;
      }

      private String _name;
      public String Name
      {
         get
         {
            return _name;
         }
         set
         {
            _name = value;
         }
      }

      private String _filename;
      public String Filename
      {
         get
         {
            return _filename;
         }
         set
         {
            _filename = value;
         }
      }

      private int _index;
      public int Index
      {
         get
         {
            return _index;
         }
         set
         {
            _index = value;
         }
      }

      private int _orignalFusionImageIndex;
      public int OrignalFusionImageIndex
      {
         get
         {
            return _orignalFusionImageIndex;
         }
         set
         {
            _orignalFusionImageIndex = value;
         }
      }

      private MedicalViewerMultiCell _orignalCell;
      public MedicalViewerMultiCell OrignalCell
      {
         get
         {
            return _orignalCell;
         }
         set
         {
            _orignalCell = value;
         }
      }

      private MedicalViewerMultiCell _fusionCell;
      public MedicalViewerMultiCell FusionCell
      {
         get
         {
            return _fusionCell;
         }
         set
         {
            _fusionCell = value;
         }
      }
   }

   /// <summary>
   /// This class contains the information that will be saved in cell "Tag"
   /// </summary>
   public class CellData
   {
      private ViewerCellType _cellType;
      private string[] _fileNames;
      private Point3D[] _imagePositions;
      private double[][] _imageOrientation;
      private int[] _frameInstanceNumber;
      private int _multiPageCount;
      private MedicalViewerMultiCell _cell;
      private int _frameIndex;
      private CounterDialog _counterDialog;
      private bool _syncCellFusion;

      public CellData(ViewerCellType cellType)
      {
         _cellType = cellType;
         _syncCellFusion = false;
      }

      public CellData()
      {
         _cellType = ViewerCellType.Cell2D;
         _syncCellFusion = false;
      }


      public CounterDialog Counter
      {
         get
         {
            return _counterDialog;
         }
         set
         {
            _counterDialog = value;
         }
      }

      public bool SyncCellFusion
      {
         get
         {
            return _syncCellFusion;
         }
         set
         {
            _syncCellFusion = value;
         }
      }


      public Point3D[] ImagePositions
      {
         get
         {
            return _imagePositions;
         }
         set
         {
            _imagePositions = value;
         }
      }

      public double[][] ImageOrientation
      {
         get
         {
            return _imageOrientation;
         }
         set
         {
            _imageOrientation = value;
         }
      }



      public int FrameIndex
      {
         get
         {
            return _frameIndex;
         }
         set
         {
            _frameIndex = value;
         }
      }




      public MedicalViewerMultiCell Cell
      {
         get
         {
            return _cell;
         }
         set
         {
            _cell = value;
         }
      }


      public ViewerCellType CellType
      {
         get
         {
            return _cellType;
         }
         set
         {
            _cellType = value;
         }
      }


      public int MultiPageCount
      {
         get
         {
            return _multiPageCount;
         }
         set
         {
            _multiPageCount = value;
         }
      }

      public int[] InstanceNumbers
      {
         get
         {
            return _frameInstanceNumber;
         }
         set
         {
            _frameInstanceNumber = value;
         }
      }

      public string[] FileNames
      {
         get
         {
            return _fileNames;
         }
         set
         {
            _fileNames = value;
         }
      }
   }

}
