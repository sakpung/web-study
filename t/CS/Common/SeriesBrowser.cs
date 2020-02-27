// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Codecs;
using Leadtools.Demos;

using Leadtools.Drawing;
using Leadtools.ImageProcessing;

using Leadtools.MedicalViewer;

namespace Leadtools.Demos
{
   /// <summary>
   /// This class is the a dialog that allows the user to load DICOMDIR files and view the studies, series and thumbnails.
   /// </summary>
   public partial class SeriesBrowser : Form
   {
      BackgroundWorker imagesLoader;
      StudyBrowserDataSet seriesDataSet;
      public IList<SeriesInformation> Images;
      double[] sliceLocationArray;
      double[] doubleArray;
      string[] imagesArray;
      bool[] localizerArray;
      string[] localizerPosition;
      int arrayCounter;
      DicomElement patientElement;
      string referenceUID;
      List<RasterImage> _imagesSeries;
      public List<string> _imagesPath;
      List<int> _echoNumber;
      List<Point3D> _imagePosition;
      int localizerCounter;
      DicomElement _studyElement;
      DicomElement _seriesElement;
      int _seriesCount;
      int _currentSeries;
      MedicalViewerSeriesManager _seriesManager;
      List<MedicalViewerImageData> _imageDataList;
      SeriesLoad[] seriesLoaders;
      private bool _disableLoading;
      private bool _hideLoadAs3D;

      // An event that clients can use to be notified whenever there is a progress with loading the DICOMDIR images
      public event ProgressEventHandler Progress;

      //An event that clients can use to be notified whenever he attempts to load one or more series 
      public event LoadingEventHandler Loading;

      // An event that clients can use to be notified when a new image has been successfully added to the Images collections
      public event ItemAddedEventHandler ItemAdded;

      // An event that clients can use to be notified when a new frame has been loaded, when this event is registered then the dialog will load each frame and send it to the user, then dispose of it.
      // This event decide whether to load all the images at once when loading a certain series, or load them one by one.
      // if true, then it will load one by one. In that case the user is required to request each frame.
      public event FrameLoadedEventHandler FrameLoaded;


      public bool LoadAs3D
      {
         get
         {
            return _checkLoadAs3D.Checked;
         }

         set
         {
            _checkLoadAs3D.Checked = value;
         }
      }

      public bool DisableLoading
      {
         set
         {
            _disableLoading = value;
            btnLoad.Enabled = seriesDataGridView.Rows.Count > 0 ? !_disableLoading : false;
            btnAddDICOMDIR.Enabled =
            _checkLoadAs3D.Enabled = !_disableLoading;
         }

         get
         {
            return _disableLoading;
         }

      }

      public bool HideLoadAs3D
      {
         set
         {
            _hideLoadAs3D = value;
            _checkLoadAs3D.Visible = !_hideLoadAs3D;
         }

         get
         {
            return _hideLoadAs3D;
         }
      }


      // Starts the background worker
      void InitializeBackgroundWorker(bool loadStudy)
      {
         // Don't start the action twice.
         if (imagesLoader.IsBusy)
         {
            return;
         }

         EnableProgressControl(Progress == null);

         int rowCount = loadStudy ? seriesDataGridView.Rows.Count : seriesDataGridView.SelectedRows.Count;
         int seriesCounter = 0;

         seriesLoaders = new SeriesLoad[rowCount];


         for (seriesCounter = 0; seriesCounter < rowCount; seriesCounter++)
         {
            seriesLoaders[seriesCounter] = new SeriesLoad();

            seriesLoaders[seriesCounter].SeriesIndex = loadStudy ? seriesCounter : seriesDataGridView.Rows.IndexOf(seriesDataGridView.SelectedRows[seriesCounter]);

            DataGridViewRow row = seriesDataGridView.Rows[seriesLoaders[seriesCounter].SeriesIndex];
            seriesLoaders[seriesCounter].StudyInstanceUID = row.Cells[StudyID.Name].Value.ToString();
            seriesLoaders[seriesCounter].SeriesInstanceUID = row.Cells[SeriesID.Name].Value.ToString();
            seriesLoaders[seriesCounter].Count = Convert.ToInt32(row.Cells[FrameCount.Name].Value);
            seriesLoaders[seriesCounter].DataGridCount = studiesDataGridView.Rows.Count;
            seriesLoaders[seriesCounter].StudyInstanceUIDArray = new string[seriesLoaders[seriesCounter].DataGridCount];
            seriesLoaders[seriesCounter].DICOMDIRUIDArray = new string[seriesLoaders[seriesCounter].DataGridCount];

            int index;
            for (index = 0; index < seriesLoaders[0].DataGridCount; index++)
               seriesLoaders[0].StudyInstanceUIDArray[index] = studiesDataGridView.Rows[index].Cells[studyInstanceUidColumn.Name].Value.ToString();

            for (index = 0; index < seriesLoaders[0].DataGridCount; index++)
               seriesLoaders[0].DICOMDIRUIDArray[index] = studiesDataGridView.Rows[index].Cells[DICOMDIRfileNameColumn.Name].Value.ToString();
         }

         imagesLoader.RunWorkerAsync(loadStudy);
         if (Progress != null)
         {
            DialogResult = DialogResult.OK;
            Hide();
         }
      }

      // This event Notifies that the background worker task has been completed.
      void imagesLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         EnableProgressControl(false);
         if (e.Error != null)
         {
            throw e.Error;
         }
         else if (!e.Cancelled)
         {
            if (Progress == null)
            {
               DialogResult = DialogResult.OK;
            }
         }
         else
         {
            Images.Clear();
         }
      }

      // Start the time consuming task..
      void imagesLoader_DoWork(object sender, DoWorkEventArgs e)
      {
         try
         {
            // Load all the selected series
            LoadSelectedSeries();

            if (imagesLoader.CancellationPending)
               e.Cancel = true;

         }
         catch (System.Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
            throw;
         }
      }


      // Initialize everything.
      public SeriesBrowser()
      {
         try
         {
            InitializeComponent();

            imagesLoader = new BackgroundWorker();
            imagesLoader.DoWork += new DoWorkEventHandler(imagesLoader_DoWork);
            imagesLoader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(imagesLoader_RunWorkerCompleted);
            imagesLoader.ProgressChanged += new ProgressChangedEventHandler(imagesLoader_ProgressChanged);
            imagesLoader.WorkerSupportsCancellation = true;
            imagesLoader.WorkerReportsProgress = true;
            if (seriesDataSet == null)
               seriesDataSet = new StudyBrowserDataSet();

            Images = new List<SeriesInformation>();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
            throw;
         }
      }

      // An event that fires every time the user shows the series browser dialog
      protected override void OnShown(EventArgs e)
      {
         Images.Clear();
         Focus();
         btnAddDICOMDIR.Focus();
      }

      public void LoadWithoutUI(string dicomDir)
      {
         AddDicomDirectory(dicomDir);

         seriesDataGridView.Rows[0].Selected = true;
         studiesDataGridView.Rows[0].Selected = true;
         InitializeBackgroundWorker(true);
      }

      // An event that clients can use to be notified whenever there is a progress with loading the DICOMDIR images
      void imagesLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         int percentage = e.ProgressPercentage;

         // Sending -1 means that a new image (or set of images) has been loaded successfully and added to the Images collection for the user to use.
         if (e.ProgressPercentage == -1)
         {
            if (ItemAdded != null)
            {
               ItemAdded(sender, new IteamAddedEventArgs(Images[(int)e.UserState]));
            }
         }
         else
         {
            // if this event is registered, then send it.
            if (e.UserState is FrameLoadedEventArgs)
            {
               FrameLoadedEventArgs args = (FrameLoadedEventArgs)(e.UserState);
               FrameLoaded(this, args);
               if (args.Cancel)
               {
                  imagesLoader.CancelAsync();

                  // Receive the exception details here.
                  MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_ErrorNotEnoughMemory"));
               }
               return;
            }
            else if (e.UserState is ProgressEventArgs)
            {
               // otherwise, the method reports a progress with loading the images, providing a variety of information.
               ProgressEventArgs progressInformation = (ProgressEventArgs)e.UserState;

               // send the user the progress event.
               if (Progress != null)
               {
                  Progress(sender, progressInformation);
               }
               else
                  // if the progress event is null, then in internal progress will start.
                  UpdateProgressUI(percentage, progressInformation);
            }
         }
      }

      // this method will update the built in progress information, if the user didn't want to receive any progress.
      private void UpdateProgressUI(int progress, ProgressEventArgs e)
      {
         switch (e.ProgressType)
         {
            case DicomDirProgressType.Preparing:
               labelCounter.Text = String.Format(DemosGlobalization.GetResxString(GetType(), "Resx_PreparingData"), progress);
               break;
            case DicomDirProgressType.LoadingImages:
               if (e.SeriesCount == 1)
                  labelCounter.Text = String.Format(DemosGlobalization.GetResxString(GetType(), "Resx_LoadingImage"), e.CurrentFrame + 1, e.FrameCount);
               else
                  labelCounter.Text = String.Format(DemosGlobalization.GetResxString(GetType(), "Resx_LoadingSeries"), e.CurrentSeries + 1, e.SeriesCount, e.CurrentFrame + 1, e.FrameCount);
               break;
         }

         progressCounter.Value = progress;
         progressCounter.Update();

      }



      // This will load the series images
      bool LoadSeries(int currentSeries, int seriesCount, string studyInstanceUID, string seriesInstanceUID, int count, string[] studyInstanceUIDArray, string[] dicomdirUIDArray, int gridRowCount, int selectedStudyIndex)
      {
         int index = 0;
         bool loaded = false;

         // Go through the study Grid to find the study of this series, in order to get some information (DICOMDIR file name)
         while (index < gridRowCount)
         {
            if ((studyInstanceUID == studyInstanceUIDArray[index]) && (index == selectedStudyIndex))
            {
               // Load the series images.
               loaded = LoadSeriesImages(dicomdirUIDArray[index],
                                      studyInstanceUID,
                                      seriesInstanceUID,
                                      count,
                                      currentSeries,
                                      seriesCount);
               index = gridRowCount;
            }
            else
               index++;
         }

         return loaded;
      }

      // This method will load selected series. (highlighted series from the series grid. Use Ctrl and Left mouse click for multiple series selection).
      void LoadSelectedSeries()
      {
         try
         {
            if (!LoadSeries(seriesLoaders[0].SeriesIndex, 1, seriesLoaders[0].StudyInstanceUID, seriesLoaders[0].SeriesInstanceUID, seriesLoaders[0].Count, seriesLoaders[0].StudyInstanceUIDArray, seriesLoaders[0].DICOMDIRUIDArray, seriesLoaders[0].DataGridCount, studiesDataGridView.SelectedRows[0].Index))
               return;
         }
         catch (System.Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
            throw;
         }
      }

      // This method enables or disables the.built-in progress controls (Progress bar, text, and the progress cancel button).
      void EnableProgressControl(bool enable)
      {
         labelCounter.Text = "";
         labelCounter.Visible =
         progressCounter.Visible =
         buttonCancelProgress.Visible = enable;
         progressCounter.Value = 0;
      }

      // This method will load selected series. (highlighted series from the series grid. Use Ctrl and Left mouse click for multiple series selection).
      private void btnOK_Click(object sender, EventArgs e)
      {
         try
         {
            if (SendLoadingEvent(seriesDataGridView.SelectedRows.Count))
               InitializeBackgroundWorker(false);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
         }
      }

      // Changes the series Grid filter in order to show the series of the selected study from the study grid
      void studiesDataGridView_SelectionChanged(object sender, EventArgs e)
      {
         // if loading disabled, don't load.
         if (!btnLoad.Enabled)
            return;

         try
         {
            if (studiesDataGridView.SelectedRows.Count != 0)
               ViewSeriesRowsForThisStudy(studiesDataGridView.SelectedRows[0].Index);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
            throw;
         }
      }

      // Add a new DICOMDIR file to the DICOMDIR dialog
      private void btnAddDICOMDIR_Click(object sender, EventArgs e)
      {
         AddDicomDirectory();
      }

      // Changes the series Grid filter in order to show the series of the selected study from the study grid (the filter is the Study instance UID tag)
      void ViewSeriesRowsForThisStudy(int studyRowIndex)
      {
         string studyInstanceUID = studiesDataGridView.Rows[studyRowIndex].Cells[studyInstanceUidColumn.Name].Value.ToString();

         if (seriesDataGridView.DataSource != null && seriesDataGridView.DataSource is BindingSource)
         {
            BindingSource bindingSource = seriesDataGridView.DataSource as BindingSource;

            bindingSource.RemoveFilter();

            bindingSource.Filter = string.Format("StudyID = '{0}'", studyRowIndex.ToString());
         }
         else
         {
            BindingSource bindingSource = new BindingSource(seriesDataSet, seriesDataSet.SeriesTable.TableName);
            bindingSource.Filter = string.Format("StudyID = '{0}'", studyRowIndex.ToString());
            seriesDataGridView.DataSource = bindingSource;
         }
      }

      // returns the number of frames of the specified series
      int GetFramesCount(DicomDataSet ds, DicomElement seriesElement)
      {
         DicomElement dicomElement;
         int count = 0;

         dicomElement = ds.GetChildKey(seriesElement);
         while (dicomElement != null)
         {
            count++;
            dicomElement = ds.GetNextKey(dicomElement, true);
         }

         return count;
      }

      // returns the file name of the frame in order to load it
      string GetFrameFileName(DicomDataSet ds, string dicomDirFileName, DicomElement dicomElement)
      {
         int position = dicomDirFileName.LastIndexOf("\\");
         string directoryPath = dicomDirFileName.Remove(position);

         return directoryPath + "\\" + ds.GetConvertValue(dicomElement);
      }


      private Image ResizeImage(Image image, int width, int height)
      {
         Image image2 = new Bitmap(width, height);

         using (Graphics graphicsHandle = Graphics.FromImage(image2))
         {
            //graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphicsHandle.DrawImage(image, 0, 0, width, height);
         }

         image.Dispose();

         return image2;
      }

      // Load the thumbnail of the specified dicomElement and convert it to a GDI plus version in order to view it in the series grid thumbnail columns
      Image LoadGDIPlusImage(DicomDataSet ds, string dicomDirFileName, DicomElement dicomElement)
      {
         Image image = null;
         RasterImage rasterImage = null;

         try
         {
            RasterCodecs codecs = new RasterCodecs();

            // Specify the thumbnail properties
            CodecsThumbnailOptions thumbOptions = new CodecsThumbnailOptions();
            thumbOptions.BitsPerPixel = 24;
            thumbOptions.Height = 64;
            thumbOptions.Width = 64;
            thumbOptions.MaintainAspectRatio = true;

            //Reads thumbnails.
            //rasterImage = codecs.ReadThumbnail(GetFrameFileName(ds, dicomDirFileName, dicomElement), thumbOptions, 0);

            string fileName = GetFrameFileName(ds, dicomDirFileName, dicomElement);


            DicomDataSet imageDataSet = new DicomDataSet();
            imageDataSet.Load(fileName, DicomDataSetLoadFlags.None);

            int imageCount = imageDataSet.GetImageCount(null);

            if (imageCount != 0)
            {
               rasterImage = codecs.Load(fileName);

               image = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None);

               image = ResizeImage(image, 64, 64);

               rasterImage.Dispose();
               codecs.Dispose();
            }


            imageDataSet.Dispose();
            imageDataSet = null;

         }
         catch (System.Exception e)
         {
            Messager.Show(this, e, MessageBoxIcon.Error);
            if (rasterImage != null)
               rasterImage.Dispose();
         }
         return image;
      }


      // return the GDIPlus thumbnail of the middle frame of the series in order to view it in the series grid thumbnail columns
      Image GetThumbnailImage(DicomDataSet ds, string dicomDirFileName, DicomElement seriesElement, int count)
      {
         try
         {
            DicomElement dicomElement;
            int index = 0;
            // The thumnailIndex is the frame in the middle of the series
            int thumbnailIndex = count / 2;

            dicomElement = ds.GetChildKey(seriesElement);
            dicomElement = ds.GetChildElement(dicomElement, true);

            while (dicomElement != null)
            {
               if (index >= thumbnailIndex)
               {
                  dicomElement = ds.FindFirstElement(dicomElement, DicomTag.ReferencedFileID, true);
                  Image image = LoadGDIPlusImage(ds, dicomDirFileName, dicomElement);
                  if (image != null)
                     return image;
               }

               index++;
               dicomElement = ds.GetNextKey(dicomElement, true);
               dicomElement = ds.GetChildElement(dicomElement, true);

            }
            return null;
         }
         catch (System.Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
            throw exception;
         }

      }

      // Go through the study and add the series to the series Grid
      void AddTheStudySeries(DicomDataSet ds, DicomElement studyElement, string studyID, string dicomDirFileName, int studyIndex)
      {
         try
         {
            int i;
            Object[] row = new Object[11];
            // All the information that will be extracted from the seriesElement. This method will extract those and 3 other (studyID, frame count, and a thumbnail image).
            long[] tags = { DicomTag.SeriesDate, DicomTag.SeriesNumber, DicomTag.Modality, DicomTag.OrganExposed, DicomTag.SeriesDescription, DicomTag.NumberOfSeriesRelatedInstances, DicomTag.SeriesInstanceUID };

            DicomElement dicomElement;
            DicomElement seriesInformation;

            dicomElement = ds.GetChildKey(studyElement);
            dicomElement = ds.GetChildElement(dicomElement, true);

            while (dicomElement != null)
            {
               for (i = 0; i < tags.Length; i++)
               {
                  seriesInformation = ds.FindFirstElement(dicomElement,
                                                         tags[i],
                                                         true);

                  if (seriesInformation != null)
                     row[i] = ds.GetConvertValue(seriesInformation);
               }

               int frameCount = GetFramesCount(ds, dicomElement);
               row[i] = studyID;
               row[i + 1] = frameCount;
               row[i + 2] = GetThumbnailImage(ds, dicomDirFileName, dicomElement, frameCount);
               row[i + 3] = studyIndex.ToString();

               // After retrieving all required series information, add them to the series Grid
               if (row[i + 2] != null)
                  seriesDataSet.SeriesTable.Rows.Add(row);

               // get to the next series element.
               dicomElement = ds.GetNextKey(dicomElement, true);
               dicomElement = ds.GetChildElement(dicomElement, true);
            }

         }
         catch (System.Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
            throw;
         }

      }

      void RemoveNewStudy(DataGridView studiesDataGridView, int newOnesIndex)
      {
         int count = studiesDataGridView.Rows.Count;
         count = count - newOnesIndex;
         for (int i = 0; i < count; i++)
            studiesDataGridView.Rows.RemoveAt(newOnesIndex);
      }

      // Go through the DICOMDIR file and extract all the studies, then add them to the study Grid
      bool AddStudyRows(DicomDataSet ds, string dicomDirectoryFileName)
      {
         // get the parent element.
         DicomElement patientElement = ds.GetFirstKey(null, true);

         if (patientElement == null)
         {
            MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_InvalidDICOMDIRFile"), DemosGlobalization.GetResxString(GetType(), "Resx_InvalidDICOMDIR"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
         }

         int lastRowIndex = studiesDataGridView.Rows.Count;
         try
         {
            DicomElement dicomElement;
            DicomElement patientNameInformation;
            DicomElement patientIDInformation;
            DicomElement patientInformation;
            int i;
            string[] row = new string[8];
            string patientName = "";
            string patientID = "";
            // All the information that will be extracted from the studyElement. This method will extract those and 3 other (patientName, patientID and DICOMDIR file name).
            long[] tags = { DicomTag.StudyDescription, DicomTag.AccessionNumber, DicomTag.StudyDate, DicomTag.ReferringPhysicianName, DicomTag.StudyInstanceUID };

            // Get the patient name and ID.
            patientNameInformation = ds.FindFirstElement(null, DicomTag.PatientName, false);
            if (patientNameInformation != null)
               patientName = ds.GetConvertValue(patientNameInformation);

            patientIDInformation = ds.FindFirstElement(null, DicomTag.PatientID, false);
            if (patientIDInformation != null)
               patientID = ds.GetConvertValue(patientIDInformation);


            while (patientNameInformation != null)
            {
               // Get the first Study
               dicomElement = ds.GetChildKey(patientElement);
               dicomElement = ds.GetChildElement(dicomElement, true);

               while (dicomElement != null)
               {
                  row[0] = patientName;
                  row[1] = patientID;

                  for (i = 2; i < 7; i++)
                  {
                     patientInformation = ds.FindFirstElement(dicomElement,
                                                            tags[i - 2],
                                                            true);

                     if (patientInformation != null)
                        row[i] = ds.GetConvertValue(patientInformation);
                  }

                  row[7] = dicomDirectoryFileName;

                  // After retrieving all required study information, add them to the study Grid
                  studiesDataGridView.Rows.Add(row);
                  AddTheStudySeries(ds, dicomElement, row[6], dicomDirectoryFileName, lastRowIndex);
                  lastRowIndex++;

                  // get to the next study element.
                  dicomElement = ds.GetNextKey(dicomElement, true);
                  dicomElement = ds.GetChildElement(dicomElement, true);
               }


               patientNameInformation = ds.FindNextElement(patientNameInformation, false);
               if (patientNameInformation != null)
                  patientName = ds.GetConvertValue(patientNameInformation);

               patientIDInformation = ds.FindNextElement(patientIDInformation, false);
               if (patientIDInformation != null)
                  patientID = ds.GetConvertValue(patientIDInformation);

               patientElement = ds.GetNextKey(patientElement, true);
            }

         }
         catch (System.Exception exception)
         {
            RemoveNewStudy(studiesDataGridView, lastRowIndex);

            System.Diagnostics.Debug.Assert(false, exception.Message);
            MessageBox.Show(exception.Message, DemosGlobalization.GetResxString(GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
         }

         return true;
      }

      // open a DICOMDIR dialog.
      private string OpenDicomDirectoryDialog()
      {
         OpenFileDialog dialog = new OpenFileDialog();
         dialog.InitialDirectory =
#if LT_CLICKONCE
            Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
#else
            String.Empty;
#endif // #if LT_CLICKONCE

         dialog.Filter = "DICOMDIR Files|DICOMDIR|All files (*.*)|*.*";
         dialog.FilterIndex = 1;
         try
         {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
               return dialog.FileName;
            }
         }
         catch (Exception exep)
         {
            MessageBox.Show(exep.Message, dialog.FileName, MessageBoxButtons.OK);
         }

         return null;
      }


      // Add a new DICOMDIR information to the study grid.
      void AddDicomDirectory()
      {
         DicomDataSet ds = new DicomDataSet();

         string dicomDirectoryPath = OpenDicomDirectoryDialog();
         if (dicomDirectoryPath == null)
            return;

         ds.Load(dicomDirectoryPath, DicomDataSetLoadFlags.None);

         // add the DICOMDIR study to the study Grid.
         bool added = AddStudyRows(ds, dicomDirectoryPath);

         if (added)
         {
            // view the series of the selected study in the series Grid.
            ViewSeriesRowsForThisStudy(0);
            // Enables the load button
            btnLoad.Enabled = true;
         }

         ds.Dispose();
      }

      void AddDicomDirectory(string dicomDir)
      {
         DicomDataSet ds = new DicomDataSet();

         //string dicomDirectoryPath = OpenDicomDirectoryDialog();
         if (dicomDir == null)
            return;

         ds.Load(dicomDir, DicomDataSetLoadFlags.None);

         // add the DICOMDIR study to the study Grid.
         bool added = AddStudyRows(ds, dicomDir);

         if (added)
         {
            // view the series of the selected study in the series Grid.
            ViewSeriesRowsForThisStudy(0);
            // Enables the load button
            btnLoad.Enabled = true;
         }

         ds.Dispose();
      }

      // Removes all the studies and the series from the DICOMDIR dialog and start all over.
      private void btnClear_Click(object sender, EventArgs e)
      {
         int index = 0;
         DataGridViewRow row;
         Image image;

         int length = seriesDataGridView.Rows.Count;

         for (; index < length; index++)
         {
            row = seriesDataGridView.Rows[index];
            image = (Image)row.Cells[Thumbnail.Name].Value;
            image.Dispose();
         }


         seriesDataSet.Clear();
         studiesDataGridView.Rows.Clear();
         btnLoad.Enabled = false;
      }

      // Find the study using the Study instance UID, and return it's DicomElement if the study is found
      private DicomElement FindStudy(DicomDataSet ds, string studyInstanceUID)
      {
         // get the parent element.
         DicomElement patientElement = ds.GetFirstKey(null, true);
         DicomElement studyElement = null;
         DicomElement studyInformationElement = null;
         string studyID;

         while (patientElement != null)
         {
            studyElement = ds.GetChildKey(patientElement);
            studyElement = ds.GetChildElement(studyElement, true);

            while (studyElement != null)
            {
               studyInformationElement = ds.FindFirstElement(studyElement,
                                                             DicomTag.StudyInstanceUID,
                                                             true);

               if (studyInformationElement != null)
               {
                  studyID = ds.GetConvertValue(studyInformationElement);

                  if (studyID == studyInstanceUID)
                     return studyInformationElement;
               }

               studyElement = ds.GetNextKey(studyElement, true);
               studyElement = ds.GetChildElement(studyElement, true);
            }


            patientElement = ds.GetNextKey(patientElement, true);
         }

         return null;
      }

      // return the first frame file name of the series.
      private string GetFirstImageName(DicomDataSet ds, DicomElement seriesElement, string directoryPath, out DicomElement imageElement)
      {
         DicomElement imageIDElement = null;

         imageElement = ds.GetChildKey(seriesElement);
         imageElement = ds.GetChildElement(imageElement, true);

         while (imageElement != null)
         {
            imageIDElement = ds.FindFirstElement(imageElement,
                                               DicomTag.ReferencedFileID,
                                               true);

            if (imageIDElement != null)
            {
               return directoryPath + "\\" + ds.GetConvertValue(imageIDElement);
            }


         }

         return "";
      }


      // return the next frame file name of the series.
      private string GetNextImageName(DicomDataSet ds, string directoryPath, ref DicomElement imageElement)
      {
         DicomElement nextImageElement = null;

         imageElement = ds.GetNextKey(imageElement, true);
         imageElement = ds.GetChildElement(imageElement, true);

         while (imageElement != null)
         {
            nextImageElement = ds.FindFirstElement(imageElement,
                                               DicomTag.ReferencedFileID,
                                               true);

            if (imageElement != null)
            {
               DicomElement echoElement = ds.FindFirstElement(imageElement,
                                                 DicomTag.EchoNumber,
                                                 true);

               return directoryPath + "\\" + ds.GetConvertValue(nextImageElement);
            }
         }

         return "";
      }


      // Find the series using the Series instance UID, and return it's DicomElement if the series is found
      private DicomElement FindSeries(DicomDataSet ds, DicomElement studyElement, string seriesInstanceUID)
      {
         DicomElement seriesElement = null;
         DicomElement seriesInformationElement = null;
         string seriesID;

         seriesElement = ds.GetChildKey(studyElement);
         seriesElement = ds.GetChildElement(seriesElement, true);

         while (seriesElement != null)
         {
            seriesInformationElement = ds.FindFirstElement(seriesElement,
                                                           DicomTag.SeriesInstanceUID,
                                                           true);

            if (seriesInformationElement != null)
            {
               seriesID = ds.GetConvertValue(seriesInformationElement);

               if (seriesID == seriesInstanceUID)
                  return seriesInformationElement;
            }

            seriesElement = ds.GetNextKey(seriesElement, true);
            seriesElement = ds.GetChildElement(seriesElement, true);
         }
         return null;
      }

      // This will send Loading event to the user upon loading the series.
      private bool SendLoadingEvent(int seriesCount)
      {
         if (Loading != null)
         {
            LoadingEventArgs args = new LoadingEventArgs(seriesCount);
            Loading(this, args);
            return !args.Cancel;
         }

         return true;
      }


      // When double-clicking one of the studies in the studies grid, the program will load all the series that belong to the selected study
      private void studiesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         // if loading disabled, don't load.
         if (!btnLoad.Enabled)
            return;

         if (SendLoadingEvent(seriesDataGridView.Rows.Count))
            InitializeBackgroundWorker(true);
      }


      private void btnClose_Click(object sender, EventArgs e)
      {
         if (imagesLoader.IsBusy)
            imagesLoader.CancelAsync();

         DialogResult = DialogResult.Cancel;
      }

      // Report the progress by sending a progress event with all the information that the user might need
      void SendImageLoadedEvent(DicomDataSet ds, DicomElement studyElement, DicomElement seriesElement, DicomElement imageElement, int currentSeries, int seriesCount, int currentFrame, int frameCount, DicomDirProgressType progressType)
      {
         ProgressEventArgs progress = new ProgressEventArgs(ds, studyElement, seriesElement, imageElement, currentSeries, seriesCount, currentFrame, frameCount, progressType);
         imagesLoader.ReportProgress((progress.CurrentFrame + 1) * 100 / progress.FrameCount, progress);
      }


      private bool LoadFrames(DicomDataSet ds, int count, string directoryPath)
      {
         string imagePath;
         DicomDataSet dicomDataSet;
         int imageIndex;
         // This loop will go through the images in the series and load them.
         DicomElement imageElement;

         int echoNumber = 0;
         imagePath = GetFirstImageName(ds, _seriesElement, directoryPath, out imageElement);
         for (imageIndex = 0; imageIndex < count; imageIndex++)
         {
            dicomDataSet = new DicomDataSet();

            try
            {
               dicomDataSet.Load(imagePath, DicomDataSetLoadFlags.None);
               if (AddImageToImageArray(dicomDataSet, imageIndex, imagePath, out echoNumber))
               {
                  _imagesPath.Add(imagePath);
                  _echoNumber.Add(echoNumber);
               }

               SendImageLoadedEvent(ds, _studyElement, _seriesElement, imageElement, _currentSeries, _seriesCount, imageIndex, count, FrameLoaded == null ? DicomDirProgressType.LoadingImages : DicomDirProgressType.Preparing);
               dicomDataSet.Dispose();

               if (imagesLoader.CancellationPending)
               {
                  // free the already allocated memory, since the user canceled the operation.
                  foreach (RasterImage image in _imagesSeries)
                  {
                     if (image != null)
                        image.Dispose();
                  }

                  ds.Dispose();
                  SendFrameLoaded(null, 0, FrameLoadedState.CancelLoading, "", 0, 0, new Point3D(0, 0, 0), null, null);

                  return false;
               }
            }
            catch (System.Exception /*ex*/)
            {
            }

            imagePath = GetNextImageName(ds, directoryPath, ref imageElement);
         }
         return true;
      }

      // This method is the one that is used to load the series images, extract the localizers, and arrange the images based on their location(arranging the image is necessary to render the 3D object correctly)
      private bool LoadSeriesImages(string dicomDirFileName, string studyInstanceUID, string seriesInstanceUID, int count, int currentSeries, int seriesCount)
      {
         string directoryPath;
         int position;
         position = dicomDirFileName.LastIndexOf("\\");
         directoryPath = dicomDirFileName.Remove(position);

         sliceLocationArray = new double[count];
         doubleArray = new double[3];
         imagesArray = new string[count];
         localizerArray = new bool[count];
         localizerPosition = new string[count];
         _imagePosition = new List<Point3D>();
         arrayCounter = 0;
         referenceUID = "";
         arrayCounter = 1;

         _imagesSeries = new List<RasterImage>();
         _imagesPath = new List<string>();
         _echoNumber = new List<int>();

         for (int i = 0; i < count; i++)
         {
            localizerPosition[i] = "";
         }

         DicomDataSet ds = new DicomDataSet();
         ds.Load(dicomDirFileName, DicomDataSetLoadFlags.None);

         _studyElement = FindStudy(ds, studyInstanceUID);
         _seriesElement = FindSeries(ds, _studyElement, seriesInstanceUID);

         _seriesCount = seriesCount;
         _currentSeries = currentSeries;

         _seriesManager = new MedicalViewerSeriesManager();
         _imageDataList = new List<MedicalViewerImageData>();


         try
         {

            if (!LoadFrames(ds, count, directoryPath))
               return false;
         }
         catch (System.Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
            throw;
         }

         ds.Dispose();


         _seriesManager.Sort(_imageDataList);

         // extract the localizers out of the image array
         ExtractLocalizers(count);

         // sort the images based on their position, then add them to the final images list.
         if (!AddTheSeriesImages())
            return false;

         return true;
      }

      // This will load the image with the specified index, also it will save some of its information later for additional processing.
      private bool AddImageToImageArray(DicomDataSet ds, int index, string imagePath, out int echoNumber)
      {
         DicomElement echoElemenet;
         string patientID;
         echoNumber = -1;
         bool addThisImage = true;

         if (index == 0)
         {
            MedicalViewerImageData imageData = new MedicalViewerImageData();

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.ImagePositionPatient,
                                                 true);

            doubleArray = ds.GetDoubleValue(patientElement, 0, 3);
            if (doubleArray.Length == 0)
               doubleArray = new double[3];

            _imagePosition.Add(Point3D.FromDoubleArray(doubleArray));

            imageData.ImagePosition = Point3D.FromDoubleArray(doubleArray);
            imageData.Data = imagePath;

            echoElemenet = ds.FindFirstElement(null,
                                                DicomTag.EchoNumber,
                                                true);

            if (echoElemenet != null)
            {
               patientID = String.Empty;
               patientID = ds.GetConvertValue(echoElemenet);
               echoNumber = Convert.ToInt32(patientID);
            }

            imageData.EchoNumber = echoNumber;


            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.InstanceNumber,
                                                 true);

            if (patientElement != null)
            {
               int[] integerArray;
               integerArray = ds.GetIntValue(patientElement, 0, 1);
               if (integerArray.Length != 0)
                  imageData.InstanceNumber = integerArray[0];
            }



            patientElement = ds.FindFirstElement(null,
                                                DicomTag.FrameOfReferenceUID,
                                                true);

            if (patientElement != null)
            {
               referenceUID = ds.GetConvertValue(patientElement);
            }

            imageData.FrameOfReferenceUID = referenceUID;

            patientElement = ds.FindFirstElement(null,
                                                DicomTag.ImageOrientationPatient,
                                                true);

            if (patientElement != null)
            {
               imagesArray[0] = ds.GetConvertValue(patientElement);
               imageData.ImageOrientation = ds.GetConvertValue(patientElement);
            }
            localizerArray[0] = true;

            localizerPosition[0] = imagePath;

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.PixelSpacing,
                                                 true);

            doubleArray = ds.GetDoubleValue(patientElement, 0, 2);
            if (doubleArray.Length != 0)
               imageData.PixelSpacing = new Point2D((float)doubleArray[0], (float)doubleArray[1]);
            else
               imageData.PixelSpacing = new Point2D(1, 1);



            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.SequenceName,
                                                 true);

            if (patientElement != null)
            {
               imageData.SequenceName = ds.GetConvertValue(patientElement);
            }

            if (FrameLoaded == null)
               _imagesSeries.Add(imageData.Image);
            else
               _imagesSeries.Add(null);

            _imageDataList.Add(imageData);

            return addThisImage;
         }
         else
         {
            MedicalViewerImageData imageData = new MedicalViewerImageData();

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.ImagePositionPatient,
                                                 true);

            doubleArray = ds.GetDoubleValue(patientElement, 0, 3);
            if (doubleArray.Length == 0)
               doubleArray = new double[3];

            imageData.ImagePosition = new Point3D((float)doubleArray[0], (float)doubleArray[1], (float)doubleArray[2]);
            echoElemenet = ds.FindFirstElement(null,
                                                DicomTag.EchoNumber,
                                                true);

            patientElement = ds.FindFirstElement(null,
                                                DicomTag.FrameOfReferenceUID,
                                                true);


            if (echoElemenet != null)
            {
               patientID = String.Empty;
               patientID = ds.GetConvertValue(echoElemenet);
               echoNumber = Convert.ToInt32(patientID);
            }
            imageData.EchoNumber = echoNumber;


            if (patientElement != null)
            {
               imageData.FrameOfReferenceUID = ds.GetConvertValue(patientElement);
            }
            else
            {
               imageData.FrameOfReferenceUID = "";
            }

            if (referenceUID != imageData.FrameOfReferenceUID)
               addThisImage = false;



            if (addThisImage)
            {

               patientElement = ds.FindFirstElement(null,
                                     DicomTag.SequenceName,
                                     true);

               if (patientElement != null)
               {
                  imageData.SequenceName = ds.GetConvertValue(patientElement);
               }

               patientElement = ds.FindFirstElement(null,
                                                    DicomTag.InstanceNumber,
                                                    true);

               if (patientElement != null)
               {
                  int[] integerArray;
                  integerArray = ds.GetIntValue(patientElement, 0, 1);
                  if (integerArray.Length != 0)
                     imageData.InstanceNumber = integerArray[0];
               }


               patientElement = ds.FindFirstElement(null,
                                                    DicomTag.ImageOrientationPatient,
                                                    true);

               if (patientElement != null)
                  imageData.ImageOrientation = ds.GetConvertValue(patientElement);

               imageData.Data = imagePath;

               _imagePosition.Add(Point3D.FromDoubleArray(doubleArray));
               imageData.ImagePosition = Point3D.FromDoubleArray(doubleArray);

               patientElement = ds.FindFirstElement(null,
                                                    DicomTag.PixelSpacing,
                                                    true);

               doubleArray = ds.GetDoubleValue(patientElement, 0, 2);

               if (doubleArray.Length != 0)
                  imageData.PixelSpacing = new Point2D((float)doubleArray[0], (float)doubleArray[1]);
               else
                  imageData.PixelSpacing = new Point2D(1, 1);

               if (FrameLoaded == null)
                  _imagesSeries.Add(imageData.Image);
               else
                  _imagesSeries.Add(null);

               _imageDataList.Add(imageData);

               arrayCounter++;
            }
            return addThisImage;
         }
      }




      // This will search for the images with different vital information like orientation, if the orientation of this image is different than the rest of the images, then we must remove it from the image array and load it separately since it doesn't belong to the list.
      private void ExtractLocalizers(int count)
      {
         DicomDataSet ds = new DicomDataSet();
         int i;

         float[] floatArray;
         for (i = 0; i < _seriesManager.Localizers.Count; i++)
         {
            SeriesInformation seriesInformation = new SeriesInformation();
            string fileName = (string)_seriesManager.Localizers[i].LocalizerData.Data;
            ds.Load(fileName, DicomDataSetLoadFlags.None);
            seriesInformation = new SeriesInformation();

            seriesInformation.DicomFrameNumber = GetDicomFrameNumber(ds);


            // if the current dicom file doesn't contain image, then continue
            if (seriesInformation.DicomFrameNumber == -1)
               continue;

            seriesInformation.Image = ds.GetImage(null, seriesInformation.DicomFrameNumber, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AllowRangeExpansion);

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.InstanceNumber,
                                                 true);

            if (patientElement != null)
            {
               int[] integerArray;
               integerArray = ds.GetIntValue(patientElement, 0, 1);
               if (integerArray.Length != 0)
                  seriesInformation.InstanceNumber = integerArray[0];
            }


            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.PixelSpacing,
                                                 true);

            doubleArray = ds.GetDoubleValue(patientElement, 0, 2);

            if (patientElement != null)
               seriesInformation.VoxelSpacing = new Point3D((float)doubleArray[0], (float)doubleArray[1], 1);

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.ImagePositionPatient,
                                                 true);
            doubleArray = ds.GetDoubleValue(patientElement, 0, 3);
            if (patientElement != null)
               seriesInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray);

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.FrameOfReferenceUID,
                                                 true);
            if (patientElement != null)
            {
               string str = ds.GetConvertValue(patientElement);
               seriesInformation.FrameOfReferenceUID = str;
            }

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.ImageOrientationPatient,
                                                 true);

            float[] imageOrientation = null;
            if (patientElement != null)
            {
               doubleArray = ds.GetDoubleValue(patientElement, 0, 6);
               floatArray = new float[] { (float)doubleArray[0], (float)doubleArray[1], (float)doubleArray[2], (float)doubleArray[3], (float)doubleArray[4], (float)doubleArray[5] };
               seriesInformation.ImageOrientation = doubleArray;
               imageOrientation = floatArray;
            }


            seriesInformation.InstitutionName = GetDicomTag(ds, DicomTag.InstitutionName);
            seriesInformation.PatientName = GetDicomTag(ds, DicomTag.PatientName);
            seriesInformation.PatientAge = GetDicomTag(ds, DicomTag.PatientAge);
            seriesInformation.PatientBirthDate = GetDicomTag(ds, DicomTag.PatientBirthDate);
            seriesInformation.PatientSex = GetDicomTag(ds, DicomTag.PatientSex);
            seriesInformation.PatientID = GetDicomTag(ds, DicomTag.PatientID);
            seriesInformation.AccessionNumber = GetDicomTag(ds, DicomTag.AccessionNumber);
            seriesInformation.StudyDate = GetDicomTag(ds, DicomTag.StudyDate);
            seriesInformation.AcquisitionTime = GetDicomTag(ds, DicomTag.AcquisitionTime);
            seriesInformation.SeriesTime = GetDicomTag(ds, DicomTag.SeriesTime);
            seriesInformation.StationName = GetDicomTag(ds, DicomTag.StationName);
            seriesInformation.StudyID = GetDicomTag(ds, DicomTag.StudyID);
            seriesInformation.SeriesDescription = GetDicomTag(ds, DicomTag.SeriesDescription);
            seriesInformation.ImageComments = GetDicomTag(ds, DicomTag.ImageComments);
            if (FrameLoaded == null)
               Images.Add(seriesInformation);
            else
            {
               Point3D imagePosition = seriesInformation.ImagePosition;
               SendFrameLoaded(seriesInformation.Image, 0, FrameLoadedState.StartLoading, fileName, 1, seriesInformation.InstanceNumber, imagePosition, imageOrientation, seriesInformation);
               SendFrameLoaded(seriesInformation.Image, 0, FrameLoadedState.FrameLoaded, fileName, 1, seriesInformation.InstanceNumber, imagePosition, imageOrientation, seriesInformation);
               SendFrameLoaded(null, 0, FrameLoadedState.EndLoading, "", 0, seriesInformation.InstanceNumber, imagePosition, imageOrientation, seriesInformation);

               System.Threading.Thread.Sleep(50);
            }

            localizerCounter++;
         }
      }


      // get a raster image array and convert them into one multi-page Raster Image
      void CreateAMultiPageRasterImage(SeriesInformation seriesInformation, List<RasterImage> imageSeries, int count)
      {
         int i;
         for (i = 0; i < count; i++)
         {
            if (i == 0)
               seriesInformation.Image = _imagesSeries[0];
            else
            {
               seriesInformation.Image.AddPage(_imagesSeries[i]);
            }
         }
      }


      // Send each frame through the FrameLoaded event
      bool SendFrameLoaded(RasterImage image, int imageIndex, FrameLoadedState state, string imagePath, int pageCount, int instanceNumber, Point3D imagePosition, float[] imageOrientation, SeriesInformation imageInformation)
      {
         // if the event is not registered, then exist
         if (FrameLoaded == null)
            return true;

         FrameLoadedEventArgs args = new FrameLoadedEventArgs(image, imageIndex, state, imagePath, pageCount, instanceNumber, imagePosition, imageOrientation, imageInformation);

         imagesLoader.ReportProgress((imageIndex + 1) * 100 / _imagesPath.Count, args);

         return !args.Cancel;
      }

      List<int> GetEchoCount(List<int> echoCount)
      {
         List<int> echoList = new List<int>();
         foreach (int echoNumber in _echoNumber)
         {
            int index = echoList.IndexOf(echoNumber);
            if (index == -1)
            {
               echoList.Add(echoNumber);
               echoCount.Add(1);
            }
            else
            {
               echoCount[index] += 1;
            }
         }
         return echoList;
      }

      public static int GetDicomFrameNumber(DicomDataSet ds)
      {
         int pageIndex;
         int frameNumber = -1;
         int pageCount = ds.GetImageCount(null);
         RasterImage image;

         int maxWidth = 0;

         for (pageIndex = 0; pageIndex < pageCount; pageIndex++)
         {
            image = ds.GetImage(null, pageIndex, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AllowRangeExpansion);

            if (image.Width > maxWidth)
            {
               maxWidth = image.Width;
               frameNumber = pageIndex;
            }

            image.Dispose();
         }
         return frameNumber;
      }

      // Send the frames and delete them afterward for memory efficiency
      bool SendLoadedImage_new(List<string> imagesPath, SeriesInformation seriesInformation)
      {
         DicomDataSet ds;
         MedicalViewerImageData imageData;
         int stackIndex = 0;
         int frameIndex = 0;
         string fileName;
         RasterImage image = null;
         int instanceNumber;

         for (stackIndex = 0; stackIndex < _seriesManager.Stacks.Count; stackIndex++)
         {
            int count = _seriesManager.Stacks[stackIndex].Items.Count;
            for (frameIndex = 0; frameIndex < count; frameIndex++)
            {
               imageData = _seriesManager.Stacks[stackIndex].Items[frameIndex];
               fileName = (string)imageData.Data;
               ds = new DicomDataSet();
               ds.Load(fileName, DicomDataSetLoadFlags.None);
               SendImageLoadedEvent(ds, null, null, null, stackIndex, _seriesManager.Stacks.Count, frameIndex, count, DicomDirProgressType.LoadingImages);
               instanceNumber = imageData.InstanceNumber;

               if (imagesLoader.CancellationPending)
               {
                  SendFrameLoaded(null, 0, FrameLoadedState.CancelLoading, "", 0, 0, new Point3D(0, 0, 0), null, seriesInformation);
                  if (image != null)
                     image.Dispose();
                  ds.Dispose();
                  return false;
               }

               if (frameIndex == 0)
               {
                  seriesInformation.DicomFrameNumber = GetDicomFrameNumber(ds);

                  imageData.Image = ds.GetImage(null, seriesInformation.DicomFrameNumber, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AllowRangeExpansion);
                  image = imageData.Image;
                  SendFrameLoaded(imageData.Image, frameIndex, FrameLoadedState.StartLoading, fileName, count, instanceNumber, _seriesManager.Stacks[stackIndex].Items[frameIndex].ImagePosition, _seriesManager.Stacks[stackIndex].Items[0].ImageOrientationArray, seriesInformation);
               }

               SendFrameLoaded(imageData.Image, frameIndex, FrameLoadedState.FrameLoaded, fileName, count, instanceNumber, _seriesManager.Stacks[stackIndex].Items[frameIndex].ImagePosition, _seriesManager.Stacks[stackIndex].Items[0].ImageOrientationArray, seriesInformation);

               if (frameIndex == count - 1)
               {
                  seriesInformation.EchoNumber = _seriesManager.Stacks[stackIndex].EchoNumber;
                  SendFrameLoaded(imageData.Image, frameIndex, FrameLoadedState.EndLoading, fileName, count, instanceNumber, _seriesManager.Stacks[stackIndex].Items[frameIndex].ImagePosition, _seriesManager.Stacks[stackIndex].Items[0].ImageOrientationArray, seriesInformation);
               }

               ds.Dispose();
            }
         }
         return true;
      }

      // this function will sort the images based on their position.
      bool SortImages_new(List<RasterImage> imageSeries, List<Point3D> position, double[] orientation, SeriesInformation seriesInformation)
      {
         int count = imageSeries.Count;
         MedicalViewerImageData data = _seriesManager.Stacks[0].Items[0];

         seriesInformation.VoxelSpacing = new Point3D(_seriesManager.Stacks[0].PixelSpacing.X, _seriesManager.Stacks[0].PixelSpacing.Y, 1);

         if (FrameLoaded == null)
            CreateAMultiPageRasterImage(seriesInformation, _imagesSeries, position.Count);
         else
            return SendLoadedImage_new(_imagesPath, seriesInformation);

         return true;
      }

      // This method returns the specified DICOM tag in a string format.
      string GetDicomTag(DicomDataSet ds, long tag)
      {
         patientElement = ds.FindFirstElement(null,
                                              tag,
                                              true);

         if (patientElement != null)
            return ds.GetConvertValue(patientElement);

         return null;
      }


      // Sort the images based on their position, then add them to the final images list.
      private bool AddTheSeriesImages()
      {

         float[] floatArray = new float[6];
         DicomDataSet ds = new DicomDataSet();

         if (_seriesManager.Stacks.Count != 0)
         {
            SeriesInformation seriesInformation = new SeriesInformation();
            string fileName = (string)_seriesManager.Stacks[0].Items[0].Data;
            ds.Load(fileName, DicomDataSetLoadFlags.None);

            seriesInformation.InstitutionName = GetDicomTag(ds, DicomTag.InstitutionName);
            seriesInformation.PatientName = GetDicomTag(ds, DicomTag.PatientName);
            seriesInformation.PatientAge = GetDicomTag(ds, DicomTag.PatientAge);
            seriesInformation.PatientBirthDate = GetDicomTag(ds, DicomTag.PatientBirthDate);
            seriesInformation.PatientSex = GetDicomTag(ds, DicomTag.PatientSex);
            seriesInformation.PatientID = GetDicomTag(ds, DicomTag.PatientID);
            seriesInformation.AccessionNumber = GetDicomTag(ds, DicomTag.AccessionNumber);
            seriesInformation.StudyDate = GetDicomTag(ds, DicomTag.StudyDate);
            seriesInformation.AcquisitionTime = GetDicomTag(ds, DicomTag.AcquisitionTime);
            seriesInformation.SeriesTime = GetDicomTag(ds, DicomTag.SeriesTime);
            seriesInformation.StationName = GetDicomTag(ds, DicomTag.StationName);
            seriesInformation.StudyID = GetDicomTag(ds, DicomTag.StudyID);
            seriesInformation.SeriesDescription = GetDicomTag(ds, DicomTag.SeriesDescription);
            seriesInformation.ImageComments = GetDicomTag(ds, DicomTag.ImageComments);
            seriesInformation.InstanceNumber = Convert.ToInt32(GetDicomTag(ds, DicomTag.InstanceNumber));

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.ImageOrientationPatient,
                                                 true);

            double[] orientation = ds.GetDoubleValue(patientElement, 0, 6);

            seriesInformation.ImageOrientation = orientation;

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.ImagePositionPatient,
                                                 true);

            doubleArray = ds.GetDoubleValue(patientElement, 0, 3);

            if (patientElement != null)
               seriesInformation.ImagePosition = Point3D.FromDoubleArray(doubleArray);

            patientElement = ds.FindFirstElement(null,
                                                 DicomTag.FrameOfReferenceUID,
                                                 true);


            if (patientElement != null)
            {
               string str = ds.GetConvertValue(patientElement);

               seriesInformation.FrameOfReferenceUID = str;
            }
            else
               seriesInformation.FrameOfReferenceUID = "";


            if (!SortImages_new(_imagesSeries, _imagePosition, orientation, seriesInformation))
               return false;
            if (FrameLoaded == null)
               Images.Insert(Images.Count - localizerCounter, seriesInformation);
         }
         return true;
      }

      private void buttonCancelProgress_Click(object sender, EventArgs e)
      {
         if (imagesLoader.IsBusy)
            imagesLoader.CancelAsync();
      }

      private void seriesDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
      {
         // if loading disabled, don't load.
         if (!btnLoad.Enabled)
            return;

         if (SendLoadingEvent(1))
            InitializeBackgroundWorker(false);
      }

   }

   // A delegate type for hooking up the progress notifications.
   public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

   // An event that clients can use to be notified whenever he attempts to load one or more series 
   public delegate void LoadingEventHandler(object sender, LoadingEventArgs e);

   // A delegate type for hooking up the frame loaded notifications.
   public delegate void FrameLoadedEventHandler(object sender, FrameLoadedEventArgs e);

   // A delegate type for hooking up the item added notifications.
   public delegate void ItemAddedEventHandler(object sender, IteamAddedEventArgs e);


   // A class that contains the loaded image, which will be sent through the (ItemAdded event)
   public class IteamAddedEventArgs : EventArgs
   {
      private SeriesInformation _item;
      public IteamAddedEventArgs(SeriesInformation item)
      {
         _item = item;
      }

      public SeriesInformation Item
      {
         get
         {
            return _item;
         }
      }
   }

   // A class that is used to store the series information and pass it to the background worker in order to load it.
   public class SeriesLoad
   {
      public string StudyInstanceUID;
      public string SeriesInstanceUID;
      public int Count;
      public string[] StudyInstanceUIDArray;
      public string[] DICOMDIRUIDArray;
      public int DataGridCount;
      public int SeriesIndex;
   }


   public enum FrameLoadedState
   {
      StartLoading,
      FrameLoaded,
      EndLoading,
      CancelLoading
   }

   // A class that is used to give the user all the information he might need when a new frame has been loaded, the frame is disposed afterward for memory efficiency purposes.
   public class FrameLoadedEventArgs : EventArgs
   {
      private RasterImage _frame;
      private int _frameIndex;
      private SeriesInformation _seriesInformation;
      private FrameLoadedState _state;
      private bool _cancel;
      private string _imagePath;
      private int _pageCount;
      private int _instanceNumber;
      private Point3D _imagePosition;
      private float[] _imageOrientation;

      public FrameLoadedEventArgs(RasterImage frame, int frameIndex, FrameLoadedState state, string imagePath, int pageCount, int instanceNumber, Point3D imagePosition, float[] imageOrientation, SeriesInformation seriesInformation)
      {
         _frame = frame;
         _frameIndex = frameIndex;
         _state = state;
         _seriesInformation = seriesInformation;
         _cancel = false;
         _imagePath = imagePath;
         _pageCount = pageCount;
         _instanceNumber = instanceNumber;
         _imagePosition = imagePosition;
         _imageOrientation = imageOrientation;
      }

      public float[] ImageOrientation
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


      public Point3D ImagePosition
      {
         get
         {
            return _imagePosition;
         }

         set
         {
            _imagePosition = value;
         }
      }



      public int InstanceNumber
      {
         get
         {
            return _instanceNumber;
         }

         set
         {
            _instanceNumber = value;
         }
      }

      public string ImagePath
      {
         get
         {
            return _imagePath;
         }
         set
         {
            _imagePath = value;
         }
      }

      public int PageCount
      {
         get
         {
            return _pageCount;
         }
         set
         {
            _pageCount = value;
         }
      }

      public SeriesInformation SeriesInformation
      {
         get
         {
            return _seriesInformation;
         }
         set
         {
            _seriesInformation = value;
         }
      }

      public RasterImage Frame
      {
         get
         {
            return _frame;
         }

         set
         {
            _frame = value;
         }
      }

      public bool Cancel
      {
         get
         {
            return _cancel;
         }

         set
         {
            _cancel = value;
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

      public FrameLoadedState State
      {
         get
         {
            return _state;
         }

         set
         {
            _state = value;
         }
      }

   }

   // A class that is used to give the user the information he might need when upon loading the series
   public class LoadingEventArgs : EventArgs
   {
      private int _seriesCount;
      private bool _cancel;

      public LoadingEventArgs(int seriesCount)
      {
         _seriesCount = seriesCount;
         _cancel = false;
      }

      public bool Cancel
      {
         get
         {
            return _cancel;
         }

         set
         {
            _cancel = value;
         }
      }

      public int SeriesCount
      {
         get
         {
            return _seriesCount;
         }
      }


   }


   public enum DicomDirProgressType
   {
      Preparing,
      LoadingImages
   }

   // A class that is used to give the user all the information he might need when a new image has been (through progress event) loaded using this dialog
   public class ProgressEventArgs : EventArgs
   {
      private DicomDataSet _dataSet;
      private DicomElement _studyElement;
      private DicomElement _seriesElement;
      private DicomElement _imageElement;
      private int _seriesCount;
      private int _frameCount;
      private int _currentFrame;
      private int _currentSeries;
      private bool _cancel;
      private DicomDirProgressType _progressType;

      public ProgressEventArgs(DicomDataSet dataSet,
                               DicomElement studyElement,
                               DicomElement seriesElement,
                               DicomElement imageElement,
                               int currentSeries,
                               int seriesCount,
                               int currentFrame,
                               int frameCount,
                               DicomDirProgressType progressType)
      {
         _dataSet = dataSet;
         _studyElement = studyElement;
         _seriesElement = seriesElement;
         _imageElement = imageElement;
         _seriesCount = seriesCount;
         _frameCount = frameCount;
         _progressType = progressType;
         _currentFrame = currentFrame;
         _seriesCount = seriesCount;
         _currentSeries = currentSeries;
         _cancel = false;
      }

      public DicomDirProgressType ProgressType
      {
         get
         {
            return _progressType;
         }

         set
         {
            _progressType = value;
         }
      }


      public bool Cancel
      {
         get
         {
            return _cancel;
         }

         set
         {
            _cancel = value;
         }
      }

      public DicomDataSet DataSet
      {
         get
         {
            return _dataSet;
         }
      }

      public int SeriesCount
      {
         get
         {
            return _seriesCount;
         }
      }

      public int CurrentSeries
      {
         get
         {
            return _currentSeries;
         }
      }


      public DicomElement StudyElement
      {
         get
         {
            return _studyElement;
         }
      }

      public DicomElement ImageElement
      {
         get
         {
            return _imageElement;
         }
      }

      public int FrameCount
      {
         get
         {
            return _frameCount;
         }
      }

      public int CurrentFrame
      {
         get
         {
            return _currentFrame;
         }
      }
   }

   // This class contains all the information of the loaded images
   public class SeriesInformation
   {
      private RasterImage _image;
      private Point3D _imagePosition;
      private double[] _imageOrientation;
      private Point3D _voxelSpacing;
      private Point3D _firstPosition;
      private Point3D _secondPosition;
      private string _frameOfReferenceUID;
      private string _institutionName;
      private string _patientName;
      private string _patientAge;
      private string _patientBirthDate;
      private string _patientSex;
      private string _patientID;
      private string _accessionNumber;
      private string _studyDate;
      private string _acquisitionTime;
      private string _seriesTime;
      private string _stationName;
      private string _studyID;
      private string _seriesDescription;
      private string _seriesNumber;
      private string _studyDescription;
      private string _imageComments;
      private string _photometricInterpretation;
      private int _dicomFrameNumber;
      private int _echoNumber;
      private int _firstInstanceNumber;
      private int _secondInstanceNumber;
      private int _instanceNumber;

      public int InstanceNumber
      {
         get
         {
            return _instanceNumber;
         }

         set
         {
            _instanceNumber = value;
         }
      }

      public int FirstInstanceNumber
      {
         get
         {
            return _firstInstanceNumber;
         }

         set
         {
            _firstInstanceNumber = value;
         }
      }

      public int SecondInstanceNumber
      {
         get
         {
            return _secondInstanceNumber;
         }

         set
         {
            _secondInstanceNumber = value;
         }
      }


      public int DicomFrameNumber
      {
         get
         {
            return _dicomFrameNumber;
         }

         set
         {
            _dicomFrameNumber = value;
         }
      }


      public RasterImage Image
      {
         get
         {
            return _image;
         }

         set
         {
            _image = value;
         }
      }


      public string InstitutionName
      {
         get
         {
            return _institutionName;
         }

         set
         {
            _institutionName = value;
         }
      }

      public string PatientName
      {
         get
         {
            return _patientName;
         }

         set
         {
            _patientName = value;
         }
      }

      public string PatientAge
      {
         get
         {
            return _patientAge;
         }

         set
         {
            _patientAge = value;
         }
      }

      public string PatientBirthDate
      {
         get
         {
            return _patientBirthDate;
         }

         set
         {
            _patientBirthDate = value;
         }
      }

      public string PatientSex
      {
         get
         {
            return _patientSex;
         }

         set
         {
            _patientSex = value;
         }
      }

      public string PatientID
      {
         get
         {
            return _patientID;
         }

         set
         {
            _patientID = value;
         }
      }

      public string AccessionNumber
      {
         get
         {
            return _accessionNumber;
         }

         set
         {
            _accessionNumber = value;
         }
      }

      public string StudyDate
      {
         get
         {
            return _studyDate;
         }

         set
         {
            _studyDate = value;
         }
      }

      public string AcquisitionTime
      {
         get
         {
            return _acquisitionTime;
         }

         set
         {
            _acquisitionTime = value;
         }
      }

      public string SeriesTime
      {
         get
         {
            return _seriesTime;
         }

         set
         {
            _seriesTime = value;
         }
      }




      public Point3D ImagePosition
      {
         get
         {
            return _imagePosition;
         }

         set
         {
            _imagePosition = value;
         }
      }

      public double[] ImageOrientation
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

      public Point3D VoxelSpacing
      {
         get
         {
            return _voxelSpacing;
         }

         set
         {
            _voxelSpacing = value;
         }
      }

      public Point3D FirstPosition
      {
         get
         {
            return _firstPosition;
         }

         set
         {
            _firstPosition = value;
         }
      }

      public Point3D SecondPosition
      {
         get
         {
            return _secondPosition;
         }

         set
         {
            _secondPosition = value;
         }
      }

      public string FrameOfReferenceUID
      {
         get
         {
            return _frameOfReferenceUID;
         }

         set
         {
            _frameOfReferenceUID = value;
         }
      }



      public string StationName
      {
         get
         {
            return _stationName;
         }

         set
         {
            _stationName = value;
         }
      }

      public string StudyID
      {
         get
         {
            return _studyID;
         }

         set
         {
            _studyID = value;
         }
      }

      public string ImageComments
      {
         get
         {
            return _imageComments;
         }

         set
         {
            _imageComments = value;
         }
      }

      public string PhotometricInterpretation
      {
         get
         {
            return _photometricInterpretation;
         }

         set
         {
            _photometricInterpretation = value;
         }
      }


      public string StudyDescription
      {
         get
         {
            return _studyDescription;
         }

         set
         {
            _studyDescription = value;
         }
      }

      public string SeriesDescription
      {
         get
         {
            return _seriesDescription;
         }

         set
         {
            _seriesDescription = value;
         }
      }

      public string SeriesNumber
      {
         get
         {
            return _seriesNumber;
         }

         set
         {
            _seriesNumber = value;
         }
      }

      public int EchoNumber
      {
         get
         {
            return _echoNumber;
         }

         set
         {
            _echoNumber = value;
         }
      }


      public SeriesInformation()
      {
         _imageOrientation = new double[6] { 1, 0, 0, 0, 1, 0 };

         _image = null;
         _frameOfReferenceUID = "";
      }
   }
}
