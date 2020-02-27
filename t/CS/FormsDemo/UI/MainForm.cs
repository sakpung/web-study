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
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.WinForms;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.Codecs;
using Leadtools.Forms.Common;
using Leadtools.Forms.Processing;
using Leadtools.Forms.Recognition;
using Leadtools.Ocr;
using Leadtools.Forms.Recognition.Barcode;
using Leadtools.Forms.Recognition.Ocr;
#if FOR_DOTNET4
using Leadtools.Forms.Recognition.Search;
#endif
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Forms.Auto;
using Leadtools.Twain;
using Leadtools.Barcode;
using Leadtools.ImageProcessing.Core;

namespace FormsDemo
{
   public partial class MainForm : Form
   {
      //These enums will work with Passed Args to application.
      enum DemoDefaultModes
      {
         Default = 0,//Default OCR
         DL = 1,//Driving License
         Invoice = 2,//Invoice
         Omr = 3,//OMR
      }

      private List<IOcrEngine> ocrEngines;
      private IOcrEngine cleanUpOcrEngine;
      private BarcodeEngine barcodeEngine;
      private RasterCodecs rasterCodecs;
      private RasterImage scannedImage;
      private bool canceled = false;
      private OcrEngineType ocrEngineType;
      private DiskMasterFormsRepository workingRepository;
      private AutoFormsEngine autoEngine;
      private Stopwatch recognitionTimer = new Stopwatch();
      private bool isScanning = false;
      private TwainSession twainSession = null;
      private bool recognitionInProcess = false;
      private string _lastFolder;
      int currentMasterCount = 0;
      private DemoDefaultModes demoMode = DemoDefaultModes.Default;
      private string scannerMessage = String.Format("Although scanning can be implemented in multiple ways within a Forms Recognition and processing application, this demo uses the below implementation:{0}{0}" +
                                                   "1) The scanner must have a feeder{0}" +
                                                   "2) Any number of filled forms can be loaded into the scanner in any order. Pages within each filled form must be in order however.{0}" +
                                                   "3) Only the first page will be used for recognition. Once the first page of a form is scanned, recognized, and processed, the rest of the pages for that form (if multipage) will be scanned and processed as needed. This process is repeated for all forms.{0}" +
                                                   "4) We will attempt to set your scanner to scan in B/W at 300DPI. If your scanner does not support this configuration, an error message will appear and the scanner dialog will be shown so that you can configure the scanner's settings.", Environment.NewLine);

      public MainForm()
      {
         FormsInformation infoDlg = new FormsInformation();
         infoDlg.ShowDialog(this);

         InitializeComponent();
      }

      [STAThread]
      static void Main(string[] args)
      {
         if (!Support.SetLicense())
            return;

         Boolean bLocked = RasterSupport.IsLocked(RasterSupportType.Forms);
         if (bLocked)
            MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         Boolean bOCRLocked = RasterSupport.IsLocked(RasterSupportType.OcrLEAD) & RasterSupport.IsLocked(RasterSupportType.OcrOmniPage);
         if (bOCRLocked)
            MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         if (bLocked | bOCRLocked)
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      private DemoDefaultModes DemoMode
      {
         get
         {
            return demoMode;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private void Startup()
      {
         try
         {
            //Check if repository directory was passed in. The master forms editor demo has the ability to launch this demo
            //and it will pass it's repository directory. It will also pass the ocr engine it was using so we can default to it.
            //First argument is the ocr engine. The next is the repository path.
            string[] commandArgs = Environment.GetCommandLineArgs();
            if (commandArgs.Length >= 2)
            {
               if (commandArgs[1] == "DrivingLicense" || commandArgs[1] == "Invoice" || commandArgs[1] == "Omr")
               {
                  if (commandArgs[1] == "DrivingLicense")
                  {
                     demoMode = DemoDefaultModes.DL;
                  }
                  else if (commandArgs[1] == "Invoice")
                  {
                     demoMode = DemoDefaultModes.Invoice;
                  }
                  else if (commandArgs[1] == "Omr")
                  {
                      demoMode = DemoDefaultModes.Omr;
                  }
               }
               else
               {
                  Properties.Settings settings = new Properties.Settings();
                  settings.OcrEngineType = commandArgs[1];
                  settings.Save();

                  if (commandArgs.Length == 3 && Directory.Exists(commandArgs[2]))
                     _txtMasterFormRespository.Text = commandArgs[2];
               }
            }

            // Application can have the following args:
            // 1- DrivingLicense
            // 2- Invoice
            //
            // If you pass one of these args Demo will Start
            // Demo will Load default Masters for selected mode
            // And will open sample image related to this mode.
            else if (commandArgs.Length == 1)
            {
               if (commandArgs[0] == "DrivingLicense")
               {
                  demoMode = DemoDefaultModes.DL;
               }
               else if (commandArgs[0] == "Invoice")
               {
                  demoMode = DemoDefaultModes.Invoice;
               }
               else if (commandArgs[0] == "Omr")
               {
                  demoMode = DemoDefaultModes.Omr;
               }
            }

            InitDemoWithMode();
            if (!StartUpEngines())
            {
               Messager.ShowError(this, "One or more required engines did not start. The application will now close.");
               this.Close();
               return;
            }

            if (String.IsNullOrEmpty(_txtMasterFormRespository.Text))
               _txtMasterFormRespository.Text = GetFormsDir();

            CreateRepository();
            SetupAutoFormsEngine();

            if (this.DemoMode == DemoDefaultModes.Default)
               Messager.Caption = "LEADTOOLS Forms Demo";
            else if (this.DemoMode == DemoDefaultModes.DL)
            {
               Messager.Caption = "LEADTOOLS Driving License Demo";
               _rb_DL.Checked = true;
               ProcessImageFormPath(DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\Driving License\License.png");
            }
            else if (this.DemoMode == DemoDefaultModes.Invoice)
            {
               Messager.Caption = "LEADTOOLS Invoice Demo";
               ProcessImageFormPath(DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\Invoice\Invoice.tif");
            }
            else if (this.DemoMode == DemoDefaultModes.Omr)
            {
                Messager.Caption = "LEADTOOLS Omr Demo";
                _rb_OMR.Checked = true;
                ProcessImageFormPath(DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\OMR\AnswerSheet1.jpg");
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }

         UpdateControls();
      }

      private void InitDemoWithMode()
      {
         if (this.DemoMode != DemoDefaultModes.Default)
         {
            _btnBrowseMasterFormRespository.Enabled = false;
            _rb_OCR.Enabled = false;
            _rb_OCR_ICR.Enabled = false;
            _rb_DL.Enabled = false;
            _rb_Invoice.Enabled = false;
            _rb_OMR.Enabled = false;

            _rb_OCR.Visible = false;
            _rb_OCR_ICR.Visible = false;
            _rb_DL.Visible = false;
            _rb_Invoice.Visible = false;
            _rb_OMR.Visible = false;
         }
         if (this.DemoMode == DemoDefaultModes.DL)
            this.Text = "Driver License Reader";
         else if (this.DemoMode == DemoDefaultModes.Invoice)
            this.Text = "Invoice Processing";
         else if (this.DemoMode == DemoDefaultModes.Omr)
            this.Text = "Omr Processing";
      }

      private void UpdateControls()
      {

         bool twainIsAvailable = TwainSession.IsAvailable(this.Handle);

         _lblMasterFormRespository.Text = String.Format("Master Form Respository (Count = {0})", currentMasterCount);
         _menuItemRecognition.Enabled = !recognitionInProcess;
         _menuItemRecognizeScannedForms.Enabled = currentMasterCount > 0 && twainSession != null && twainIsAvailable && !recognitionInProcess;
         _menuItemRecognizeSingleForm.Enabled = currentMasterCount > 0 && !recognitionInProcess;
         _menuItemRecognizeMultipleForms.Enabled = currentMasterCount > 0 && !recognitionInProcess;

         _menuItemFile.Enabled = !recognitionInProcess;
         _menuItemOptions.Enabled = !recognitionInProcess;
         _menuItemHelp.Enabled = !recognitionInProcess;
         if (this.DemoMode == DemoDefaultModes.Default)
            _btnBrowseMasterFormRespository.Enabled = !recognitionInProcess;

         _btnCancel.Enabled = recognitionInProcess;

         if (!recognitionInProcess)
         {
            _lblFormName.Text = "Form Name: NA";
            _pbProgress.Value = 0;
         }
      }

      private int GetMasterFormCount(IMasterFormsCategory rootCategory)
      {
         try
         {
            int count = rootCategory.MasterFormsCount;
            foreach (IMasterFormsCategory childCategory in rootCategory.ChildCategories)
               count = count + GetMasterFormCount(childCategory);
            return count;
         }
         catch
         {
            return 0;
         }
      }

      private string GetFormsDir()
      {
         string formsDir = "";
         if (this.DemoMode == DemoDefaultModes.Default)
         {
            if (_rb_OCR.Checked == true)
               formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\OCR";
            else if (_rb_OCR_ICR.Checked == true)
               formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\OCR_ICR";
            else if (_rb_DL.Checked == true)
               formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\Driving License";
            else if (_rb_Invoice.Checked == true)
                formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\Invoice";
            else
                formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\OMR";
         }
         else if (this.DemoMode == DemoDefaultModes.DL)
         {
            formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\Driving License";
         }
         else if (this.DemoMode == DemoDefaultModes.Invoice)
         {
            formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\Invoice";
         }
         else if (this.DemoMode == DemoDefaultModes.Omr)
         {
             formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets\OMR";
         }
         return formsDir;
      }

      private void _menuItemRecognizeMultipleForms_Click(object sender, EventArgs e)
      {
         try
         {
            recognitionInProcess = true;
            UpdateControls();

            using (FolderBrowserDialogEx fbd = new FolderBrowserDialogEx())
            {
               if (String.IsNullOrEmpty(_lastFolder))
                  fbd.SelectedPath = GetSamplesPath();
               else
                  fbd.SelectedPath = _lastFolder;

               fbd.ShowNewFolderButton = false;
               fbd.ShowFullPathInEditBox = true;
               fbd.ShowEditBox = true;
               if (fbd.ShowDialog(this) == DialogResult.OK)
               {
                  canceled = false;
                  _lastFolder = fbd.SelectedPath;
                  string[] files = Directory.GetFiles(fbd.SelectedPath);
                  AddOperationTime(null, null, TimeSpan.Zero, true);
                  List<FilledForm> recognizedForms = new List<FilledForm>();
                  foreach (string file in files)
                  {
                     //recognize and process each file in the directory
                     Application.DoEvents();
                     if (!canceled)
                     {
                        try
                        {
                           FilledForm newForm = new FilledForm();
                           newForm.FileName = file;
                           //if(Path.GetExtension(file).Equals("db"))
                           //    continue;
                           newForm.Name = Path.GetFileNameWithoutExtension(file);
                           _lblFormName.Text = String.Concat("Form Name: ", newForm.Name);
                           _lblStatus.Text = "Status: NA";
                           //Load the image
                           newForm.Image = LoadImageFile(file, 1, -1);
                           //Run the recognition and processing
                           if (RunFormRecognitionAndProcessing(newForm))
                              recognizedForms.Add(newForm);
                        }
                        catch
                        {
                           //Do nothing since we are processing a directory of images
                           //and do not want to stop execution
                        }
                     }
                  }

                  ShowResults(recognizedForms);
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         finally
         {
            recognitionInProcess = false;
            UpdateControls();
         }
      }

      private void _menuItemRecognizeSingleForm_Click(object sender, EventArgs e)
      {
         try
         {
            recognitionInProcess = true;
            UpdateControls();

            //Create and initialize ImageFileLoader class
            ImageFileLoader loader = new ImageFileLoader();
            loader.ShowLoadPagesDialog = true;
            loader.OpenDialogInitialPath = GetSamplesPath();

            AddOperationTime(null, null, TimeSpan.Zero, true);
            if (loader.Load(this, rasterCodecs, false) > 0)
            {
               canceled = false;

               FilledForm newForm = new FilledForm();
               newForm.FileName = loader.FileName;
               newForm.Name = Path.GetFileNameWithoutExtension(loader.FileName);
               _lblFormName.Text = String.Concat("Form Name: ", newForm.Name);
               _lblStatus.Text = "Status: NA";
               //Load the image
               newForm.Image = LoadImageFile(loader.FileName, loader.FirstPage, loader.LastPage);
               //Run the recognition and processing
               List<FilledForm> recognizedForms = new List<FilledForm>();
               if (RunFormRecognitionAndProcessing(newForm))
                  recognizedForms.Add(newForm);

               ShowResults(recognizedForms);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         finally
         {
            recognitionInProcess = false;
            UpdateControls();
         }
      }

      void ProcessImageFormPath(string imagePath)
      {
         try
         {
            recognitionInProcess = true;
            UpdateControls();

            FilledForm newForm = new FilledForm();
            newForm.FileName = Path.GetFileName(imagePath);
            newForm.Name = Path.GetFileNameWithoutExtension(imagePath);
            _lblFormName.Text = String.Concat("Form Name: ", newForm.Name);
            _lblStatus.Text = "Status: NA";
            //Load the image
            newForm.Image = LoadImageFile(imagePath, 1, 1);
            //Run the recognition and processing
            List<FilledForm> recognizedForms = new List<FilledForm>();
            if (RunFormRecognitionAndProcessing(newForm))
               recognizedForms.Add(newForm);

            ShowResults(recognizedForms);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         finally
         {
            recognitionInProcess = false;
            UpdateControls();
         }
      }

      private string GetSamplesPath()
      {
         string formsDir;
         if (_rb_OCR.Checked == true)
            formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\OCR";
         else if (_rb_OCR_ICR.Checked == true)
            formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\OCR_ICR";
         else if (_rb_DL.Checked == true)
            formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\Driving License";
         else if (_rb_Invoice.Checked == true)
             formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\Invoice";
         else
             formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\Forms to be Recognized\OMR";
         return formsDir;
      }

#if LEADTOOLS_V19_OR_LATER
      private FormsPageType GetPageType()
      {
          FormsPageType pageType = FormsPageType.Normal;
          if (_rb_DL.Checked == true)
              pageType = FormsPageType.IDCard;
          else if (_rb_OMR.Checked == true)
              pageType = FormsPageType.Omr;
          return pageType;
      }
#endif

      private void ShowResults(List<FilledForm> recognizedForms)
      {
         if (!canceled)
         {
            if (recognizedForms.Count > 0)
            {
               //Show the results
               _lblStatus.Text = "Status: Complete";
               RecognitionResult resultDialog = new RecognitionResult(recognizedForms);
               resultDialog.ShowDialog(this);
            }
            else
               _lblStatus.Text = "Status: No Forms Recognized";
         }
         else
            _lblStatus.Text = "Status: Canceled";
      }

      private bool FeederLoaded()
      {
         try
         {
            //first enable feeder
            TwainCapability autoFeedCap = new TwainCapability();

            autoFeedCap.Information.Type = TwainCapabilityType.FeederEnabled;
            autoFeedCap.Information.ContainerType = TwainContainerType.OneValue;

            autoFeedCap.OneValueCapability.ItemType = TwainItemType.Bool;
            autoFeedCap.OneValueCapability.Value = true;

            twainSession.SetCapability(autoFeedCap, TwainSetCapabilityMode.Set);

            //now check if feeder is loaded
            TwainCapability feederLoadedCap = new TwainCapability();
            feederLoadedCap = twainSession.GetCapability(TwainCapabilityType.FeederLoaded, TwainGetCapabilityMode.GetValues);
            return (bool)feederLoadedCap.OneValueCapability.Value;
         }
         catch
         {
            throw new Exception("To recognize scanned pages in this demo, your scanner must have a feeder");
         }
      }

      private void _menuItemRecognizeScannedForms_Click(object sender, EventArgs e)
      {
         try
         {
            recognitionInProcess = true;
            isScanning = true;
            UpdateControls();

            if (MessageBox.Show(scannerMessage, "Scanning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
               return;

            //select the desired scanner
            if (twainSession.SelectSource(string.Empty) != DialogResult.OK)
               return;

            canceled = false;
            _lblStatus.Text = "Status: NA";

            Application.DoEvents();
            //keep scanning until the feeder is empty
            AddOperationTime(null, null, TimeSpan.Zero, true);
            List<FilledForm> recognizedForms = new List<FilledForm>();
            while (FeederLoaded() && !canceled)
            {
               FilledForm filledForm = new FilledForm();
               if (scannedImage != null)
                  scannedImage.Dispose();
               //recognize and process the scanned images
               if (RunFormRecognitionAndProcessingScanner(filledForm))
                  recognizedForms.Add(filledForm);
               Application.DoEvents();
            }

            ShowResults(recognizedForms);
         }
         catch (Exception exp)
         {
            if (!exp.Message.Contains("no need for your app to report the error"))
               Messager.ShowError(this, exp);
         }
         finally
         {
            recognitionInProcess = false;
            isScanning = false;
            UpdateControls();
         }
      }

      private void twnSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         try
         {
            if (e.Image == null)
               return;
            if (scannedImage != null && !scannedImage.IsDisposed)
               scannedImage.AddPage(e.Image.Clone());
            else
               scannedImage = e.Image.Clone();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         ShutDownEngines();
      }

      private void ShutDownEngines()
      {
         if (autoEngine != null)
            autoEngine.Dispose();

         Properties.Settings settings = new Properties.Settings();
         settings.OcrEngineType = ocrEngineType.ToString();
         settings.Save();

         for (int i = 0; i < ocrEngines.Count; i++)
         {
            if (ocrEngines[i] != null && ocrEngines[i].IsStarted)
            {
               ocrEngines[i].Shutdown();
               ocrEngines[i].Dispose();
            }
         }
         if (cleanUpOcrEngine != null && cleanUpOcrEngine.IsStarted)
         {
            cleanUpOcrEngine.Shutdown();
            cleanUpOcrEngine.Dispose();
         }
         if (twainSession != null)
            twainSession.Shutdown();
      }

      private void _btnHowTo_Click(object sender, EventArgs e)
      {
         try
         {
            DemosGlobal.LaunchHowTo("FormsRecognitionDemo.html");
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }
      }

      public void LoadImageScanner(int numPages)
      {
         if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, twainSession.SelectedSourceName()))
            return;

         bool showUI = false;
         //Set the scanner to scan a specified number of pages, scan at 1bpp B/W, and at 300DPI
         try
         {
            twainSession.MaximumTransferCount = numPages;
            twainSession.Resolution = new SizeF(300, 300);
            TwainProperties twainProps = twainSession.Properties;
            TwainImageEffectsProperties imageEfx = twainProps.ImageEffects;
            imageEfx.ColorScheme = TwainColorScheme.BlackWhite;
            twainProps.ImageEffects = imageEfx;
            twainSession.Properties = twainProps;
            twainSession.ImageBitsPerPixel = 1;
         }
         catch
         {
            MessageBox.Show("Unable to set scanner to 1BPP B/W - 300DPI.");
            showUI = true;
         }

         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();

         if (showUI)
            twainSession.Acquire(TwainUserInterfaceFlags.Modal);
         else
            twainSession.Acquire(TwainUserInterfaceFlags.None);
         stopWatch.Stop();
         AddOperationTime("NA", "Scan Image", stopWatch.Elapsed, false);
         //Only clean new pages
         CleanupImage(scannedImage, String.Empty, (scannedImage.PageCount - numPages) + 1, numPages);
      }

      public RasterImage LoadImageFile(string fileName, int firstPage, int lastPage)
      {
         // Load the image 
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();
         RasterImage image = rasterCodecs.Load(fileName, 0, CodecsLoadByteOrder.Bgr, firstPage, lastPage);
         stopWatch.Stop();
         AddOperationTime(Path.GetFileNameWithoutExtension(fileName), "Load Image", stopWatch.Elapsed, false);
         return image;
      }

#if FOR_DOTNET4
      IFullTextSearchManager CreateFullTextSearchManager(string path)
      {
         DiskFullTextSearchManager fullTextSearchManager = new DiskFullTextSearchManager();
         fullTextSearchManager.IndexDirectory = Path.Combine(path, "index");
         return fullTextSearchManager;
      }
#endif

      public bool RunFormRecognitionAndProcessingScanner(FilledForm filledForm)
      {
         //Scan the first page
         LoadImageScanner(1);

         if ((scannedImage != null && scannedImage.PageCount < 1) || scannedImage == null)
            throw new Exception("No forms were scanned.");

         filledForm.Name = "Scanned Form";
         filledForm.Image = scannedImage.Clone();
         filledForm.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft);

         _lblFormName.Text = String.Concat("Form Name: ", filledForm.Name);
         Application.DoEvents();
         autoEngine.RecognizeFirstPageOnly = true;
         recognitionTimer.Reset();
         recognitionTimer.Start();
                            
         AutoFormsRunResult result = autoEngine.Run(filledForm.Image, MyPageRequestCallback, filledForm, null);
         Application.DoEvents();
         recognitionTimer.Stop();
         AddOperationTime(filledForm.Name, "Recognize and Process", recognitionTimer.Elapsed, false);
         if (result != null && !canceled)
         {
            //We need to make sure we scanned all the pages for this form. 
            //We check the master to see how many pages this form needs and scan
            //until we have all pages. 
            if (result.RecognitionResult.Properties.Pages - scannedImage.PageCount > 0)
            {
               LoadImageScanner(result.RecognitionResult.Properties.Pages - scannedImage.PageCount);
               //Add the rest of the already scanned pages to the filled form image collection
               filledForm.Image.AddPages(scannedImage, filledForm.Image.PageCount + 1, -1);
            }

            MasterForm master = new MasterForm();
            master.Properties = result.RecognitionResult.Properties;
            filledForm.Master = master;
            filledForm.Result = result.RecognitionResult.Result;
            filledForm.Alignment = result.RecognitionResult.Alignments;

            if (result.FormFields != null)
               filledForm.ProcessingPages = result.FormFields;

            //We have successfully recognized and processed a form
            return true;
         }
         return false;
      }

      //In some cases, only a single page is provided to the engine for recognition,
      //but the form is multiple pages so more pages are needed for processing. 
      //This callback is called to notify you that it needs more pages for processing
      //The required page is passed here.
      public void MyPageRequestCallback(PageRequestCallbackData data)
      {
         //Stop the timer. We do not want to skew attribute generation,recognition,
         //or processing times with work done in this event (image loading, scanning, etc). 
         //Those times are recorded separately
         recognitionTimer.Stop();

         FilledForm workingForm = data.UserData as FilledForm;

         if (isScanning)
         {
            //if it is asking for a page we do not have yet, scan until we have that page
            if (scannedImage.PageCount < data.FormPageNumber)
               LoadImageScanner(data.FormPageNumber - scannedImage.PageCount);

            //Give the new page to the engine for processing
            scannedImage.Page = data.FormPageNumber;
            data.Page = scannedImage.Clone();
            workingForm.Image.AddPages(scannedImage.CloneAll(), workingForm.Image.PageCount + 1, -1);
         }
         else
         {
            //Load all pages up to the page we need
            RasterImage image = LoadImageFile(workingForm.FileName, workingForm.Image.PageCount + 1, data.FormPageNumber).CloneAll();
            CleanupImage(image, workingForm.Name, 1, image.PageCount);
            image.Page = image.PageCount; //Set current page to last page (data.FormPageNumber)
            data.Page = image.Clone();
            workingForm.Image.AddPages(image, 1, -1);
         }

         //Resume timer
         recognitionTimer.Start();
         Application.DoEvents();
      }

      //This callback is fired during the recognition and processing process.
      //It provides progress information, as well as the specific operation being performed
      void autoEngine_Progress(object sender, AutoFormsProgressEventArgs e)
      {
         Application.DoEvents();
         if (canceled)
            e.Cancel = true;

         else
         {
            switch (e.Operation)
            {
               case AutoFormsOperation.Generating:
                  if (this.InvokeRequired)
                  {
                     this.BeginInvoke(new MethodInvoker(delegate()
                     {
                        _lblStatus.Text = "Status: Generating Form Attributes...";
                     }));
                  }
                  else
                     _lblStatus.Text = "Status: Generating Form Attributes...";
                  break;
               case AutoFormsOperation.Recognizing:
                  if (this.InvokeRequired)
                  {
                     this.BeginInvoke(new MethodInvoker(delegate()
                     {
                        _lblStatus.Text = "Status: Recognizing Form...";
                     }));
                  }
                  else
                     _lblStatus.Text = "Status: Recognizing Form...";
                  break;
               case AutoFormsOperation.Processing:
                  if (this.InvokeRequired)
                  {
                     this.BeginInvoke(new MethodInvoker(delegate()
                     {
                        _lblStatus.Text = "Status: Processing Form...";
                     }));
                  }
                  else
                     _lblStatus.Text = "Status: Processing Form...";
                  break;
               default:
                  break;
            }

            if (this.InvokeRequired)
            {
               this.BeginInvoke(new MethodInvoker(delegate()
               {
                  _pbProgress.Value = Math.Min(100,e.Percentage);
               }));
            }
            else
               _pbProgress.Value = Math.Min(100,e.Percentage);
         }

         Application.DoEvents();
      }

      //Used to display the amount of time a specific operation may take
      //private delegate void AddOperationTimeDelagate(string imageFile, string operationName, TimeSpan operationTime, bool clearExisting);
      void AddOperationTime(string imageFile, string operationName, TimeSpan operationTime, bool clearExisting)
      {
         if (clearExisting)
            _lvLastOperation.Items.Clear();

         if (!String.IsNullOrEmpty(imageFile))
         {
            _lvLastOperation.Items.Add(imageFile);
            _lvLastOperation.Items[_lvLastOperation.Items.Count - 1].SubItems.Add(operationName);
            _lvLastOperation.Items[_lvLastOperation.Items.Count - 1].SubItems.Add(Convert.ToString(Math.Round(operationTime.TotalSeconds, 2)));
         }

         //ensure last item is visible
         if (_lvLastOperation.Items.Count > 0)
         {
            _lvLastOperation.EnsureVisible(_lvLastOperation.Items.Count - 1);
            _lvLastOperation.Refresh();
         }

         Application.DoEvents();
      }

      //This function is used to cleanup images
      private void CleanupImage(RasterImage imageToClean, string fileName, int startIndex, int count)
      {
         Stopwatch stopWatch = new Stopwatch();
         try
         {
            stopWatch.Start();
            int oldPageNumber = imageToClean.Page;
            //Deskew
            if (_rb_OMR.Checked)
            {
                for (int i = startIndex; i < startIndex + count; i++)
                {
                    imageToClean.Page = i;
                    DeskewCommand deskew = new DeskewCommand();

                    deskew.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea | DeskewCommandFlags.RotateResample;
                    deskew.Run(imageToClean);
                }
            }
            else if (cleanUpOcrEngine != null && cleanUpOcrEngine.IsStarted)
            {
               using (IOcrDocument document = cleanUpOcrEngine.DocumentManager.CreateDocument())
               {
                  for (int i = startIndex; i < startIndex + count; i++)
                  {
                     imageToClean.Page = i;
                     document.Pages.AddPage(imageToClean, null);
                     int angle = -document.Pages[0].GetDeskewAngle();
                     RotateCommand cmd = new RotateCommand(angle * 10, RotateCommandFlags.Bicubic, RasterColor.FromKnownColor(RasterKnownColor.White));
                     cmd.Run(imageToClean);
                     document.Pages.Clear();
                  }
               }
            }
            else
            {
               for (int i = startIndex; i < startIndex + count; i++)
               {
                  imageToClean.Page = i;

                  DeskewCommand deskewCommand = new DeskewCommand();
                  if (imageToClean.Height > 3500)
                     deskewCommand.Flags = DeskewCommandFlags.DocumentAndPictures |
                                           DeskewCommandFlags.DoNotPerformPreProcessing |
                                           DeskewCommandFlags.UseNormalDetection |
                                           DeskewCommandFlags.DoNotFillExposedArea;
                  else
                     deskewCommand.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea;
                  deskewCommand.Run(imageToClean);
               }
            }
            stopWatch.Stop();
            if (String.IsNullOrEmpty(fileName))
               AddOperationTime("NA", "Clean Image", stopWatch.Elapsed, false);
            else
               AddOperationTime(fileName, "Clean Image", stopWatch.Elapsed, false);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            stopWatch.Stop();
         }
      }

      public bool RunFormRecognitionAndProcessing(FilledForm form)
      {
         form.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
         CleanupImage(form.Image, form.Name, 1, form.Image.PageCount);
         Application.DoEvents();
         autoEngine.RecognizeFirstPageOnly = _menuItemRecognizeFirstPageOnly.Checked;
                   
         recognitionTimer.Reset();
         recognitionTimer.Start();
                  
         AutoFormsRunResult result = autoEngine.Run(form.Image, MyPageRequestCallback, form, null);
         Application.DoEvents();
         recognitionTimer.Stop();
         AddOperationTime(form.Name, "Recognize and Process", recognitionTimer.Elapsed, false);
         if (result != null && !canceled)
         {
            //We need to make sure we loaded all the pages for this form. 
            //We check the master to see how many pages this form needs and load
            //the rest of the pages. 
            if (result.RecognitionResult.Properties.Pages - form.Image.PageCount > 0)
            {
               RasterImage remainingPages = LoadImageFile(form.FileName, form.Image.PageCount + 1, result.RecognitionResult.Properties.Pages);
               CleanupImage(remainingPages, form.Name, 1, remainingPages.PageCount);
               form.Image.AddPages(remainingPages, 1, -1);
            }

            form.Alignment = result.RecognitionResult.Alignments;
            MasterForm master = new MasterForm();
            master.Properties = result.RecognitionResult.Properties;
            form.Master = master;
            form.Result = result.RecognitionResult.Result;

            if (result.FormFields != null)
               form.ProcessingPages = result.FormFields;

            //We have successfully recognized and processed a form
            return true;
         }
         return false;
      }

      private void StartUpOcrEngine()
      {
         try
         {
            Properties.Settings settings = new Properties.Settings();
            string engineType = settings.OcrEngineType;
            ocrEngines = new List<IOcrEngine>();

            // Show the engine selection dialog
            using (OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, false))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  ocrEngineType = dlg.SelectedOcrEngineType;

                  if (ocrEngineType == OcrEngineType.LEAD)
                  {
                     //For LEAD OCR Engine we need only one Engine to be used with ThreadPool
                     IOcrEngine engine = OcrEngineManager.CreateEngine(ocrEngineType, true);
                     ocrEngines.Add(engine);
                     ocrEngines[0].Startup(null, null, null, null);
                     SetEngineSettings(engine);
                  }
                  else
                  {
                     IOcrEngine engine = OcrEngineManager.CreateEngine(ocrEngineType, true);
                     ocrEngines.Add(engine);
                     ocrEngines[0].Startup(null, null, null, null);
                  }

                  cleanUpOcrEngine = OcrEngineManager.CreateEngine(ocrEngineType, true);
                  cleanUpOcrEngine.Startup(null, null, null, null);

                  this.Text = String.Format("{0} [{1} Engine]", this.Text, ocrEngineType.ToString());
               }
               else
                  throw new Exception("No engine selected.");
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void SetEngineSettings(IOcrEngine engine)
      {
         try
         {
            engine.SettingManager.SetEnumValue("Recognition.Fonts.DetectFontStyles", 0);
            engine.SettingManager.SetBooleanValue("Recognition.Fonts.RecognizeFontAttributes", false);

            if (engine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff"))
               engine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate");

            //if (engine.SettingManager.IsSettingNameSupported("Recognition.Zoning.EnableDoubleZoning")) 
            //   engine.SettingManager.SetBooleanValue("Recognition.Zoning.EnableDoubleZoning", false);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

      }

      private void StartUpBarcodeEngine()
      {
         try
         {
            barcodeEngine = new BarcodeEngine();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void SetupAutoFormsEngine()
      {
         try
         {
            if (autoEngine != null)
               autoEngine.Dispose();

            //Add appropriate object managers to AutoForms engine. We need to recreate it first
            AutoFormsRecognitionManager managers = AutoFormsRecognitionManager.None;
            if (_menuItemBarcodeManager.Checked)
               managers |= AutoFormsRecognitionManager.Barcode;
            if (_menuItemDefaultManager.Checked)
               managers |= AutoFormsRecognitionManager.Default;
            if (_menuItemOCRManager.Checked)
               managers |= AutoFormsRecognitionManager.Ocr;
            
            if (ocrEngines != null && ocrEngines.Count == 1 && ocrEngines[0].EngineType == OcrEngineType.LEAD)
            {
               autoEngine = new AutoFormsEngine(workingRepository, ocrEngines[0], barcodeEngine, managers, 30, 80, _menuItemRecognizeFirstPageOnly.Checked);
               autoEngine.UseThreadPool = true;
            }
            else
            {
               autoEngine = new AutoFormsEngine(workingRepository, ocrEngines[0], barcodeEngine, managers, 30, 80, _menuItemRecognizeFirstPageOnly.Checked);
            }
#if FOR_DOTNET4
            if (Directory.Exists(Path.Combine(workingRepository.Path, "index")))
               autoEngine.SetFullTextSearchManager(CreateFullTextSearchManager(workingRepository.Path), "index", null);
#endif

#if LEADTOOLS_V19_OR_LATER
            autoEngine.FilledFormType = GetPageType();
#endif
            autoEngine.Progress += new EventHandler<AutoFormsProgressEventArgs>(autoEngine_Progress);
            if (this.DemoMode == DemoDefaultModes.Default)
            {
               if (ocrEngines == null || ocrEngines.Count == 0 || ocrEngines[0].EngineType == OcrEngineType.LEAD)
               {
                  _rb_OCR_ICR.Enabled = false;
               }
               else
               {
                  if (ocrEngines[0].ZoneManager.IsZoneTypeSupported(OcrZoneType.Icr))
                     _rb_OCR_ICR.Enabled = true;
                  else
                     _rb_OCR_ICR.Enabled = false;
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void CreateRepository()
      {
         string path = "";
         if (this.DemoMode == DemoDefaultModes.Default)
            path = _txtMasterFormRespository.Text;
         else
            path = GetFormsDir();
          
         workingRepository  = new DiskMasterFormsRepository(rasterCodecs, path);
         currentMasterCount = GetMasterFormCount(workingRepository.RootCategory);
      }

      public bool StartUpEngines()
      {
         try
         {
            StartUpRasterCodecs();
            StartUpOcrEngine();
            StartUpBarcodeEngine();
            StartupTwain();
            return true;
         }
         catch
         {
            return false;
         }
      }

      private void StartupTwain()
      {
         try
         {
            twainSession = new TwainSession();

            if (TwainSession.IsAvailable(this.Handle))
            {
               twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
               twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(twnSession_AcquirePage);
            }
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               twainSession = null;
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
            }
            else
            {
               twainSession = null;
               Messager.ShowError(this, ex);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            twainSession = null;
         }
      }

      private void StartUpRasterCodecs()
      {
         try
         {
            rasterCodecs = new RasterCodecs();

            //To turn off the dithering method when converting colored images to 1-bit black and white image during the load
            //so the text in the image is not damaged.
            RasterDefaults.DitheringMethod = RasterDitheringMethod.None;

            //To ensure better results from OCR engine, set the loading resolution to 300 DPI 
            rasterCodecs.Options.Load.Resolution = 300;
            rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void _menuItemExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _btnBrowseMasterFormRespository_Click(object sender, EventArgs e)
      {
         try
         {
            using (FolderBrowserDialogEx fbd = new FolderBrowserDialogEx())
            {
               fbd.Description = "Select Master Form Repository";
               fbd.SelectedPath = GetFormsDir();
               fbd.ShowEditBox = true;
               fbd.ShowFullPathInEditBox = true;
               fbd.ShowNewFolderButton = false;
               if (fbd.ShowDialog() == DialogResult.OK)
               {
                  _txtMasterFormRespository.Text = fbd.SelectedPath;
                  CreateRepository();
                  SetupAutoFormsEngine();
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void RecognitionOptionsChanged(object sender, EventArgs e)
      {
         SetupAutoFormsEngine();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         canceled = true;
      }

      private void _menuItemAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Forms", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _menuItemLaunchMasterFormsEditor_Click(object sender, EventArgs e)
      {
         ProcessStartInfo startInfo = new ProcessStartInfo();

         startInfo.FileName = Path.Combine(Application.StartupPath, "CSMasterFormsEditor_Original.exe");

         // Make sure either CSMasterFormsEditor_Original.exe or CSMasterFormsEditor.exe exist before attempting to start it
         if (!File.Exists(startInfo.FileName))
         {
            startInfo.FileName = startInfo.FileName.Replace("_Original", string.Empty);
         }

         if (!File.Exists(startInfo.FileName))
         {
            startInfo.FileName = startInfo.FileName.Replace("FormsDemo", "MasterFormsEditor");
         }

         if (!File.Exists(startInfo.FileName))
         {
               MessageBox.Show(String.Format("Cannot find: {0}{1}{1}Please build the CSMasterFormsEditor.exe from the MasterFormsEditor project.", startInfo.FileName, Environment.NewLine), "File Not Found");
               return;
         }

         startInfo.Arguments = String.Format("\"{0}\"", ocrEngines[0].EngineType.ToString());

         try
         {
            using (Process process = new Process())
            {
               process.StartInfo = startInfo;
               process.Start();
               process.Close();
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _menuItemLanguages_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user change the current enabled languages
         using (EnableLanguagesDialog dlg = new EnableLanguagesDialog(ocrEngines[0]))
            dlg.ShowDialog(this);

         //Enable selected languages for all OCR engines
         string [] enabledLanguages = ocrEngines[0].LanguageManager.GetEnabledLanguages();
         for (int i = 1; i < ocrEngines.Count; i++)
            ocrEngines[i].LanguageManager.EnableLanguages(enabledLanguages);
      }

      private void _menuItemComponents_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user see the OCR components installed on this system
         using (OcrEngineComponentsDialog dlg = new OcrEngineComponentsDialog(ocrEngines[0]))
            dlg.ShowDialog(this);
      }

      private void _rb_Respository_CheckedChanged(object sender, EventArgs e)
      {
          if (!(sender as RadioButton).Checked)
              return;

         _txtMasterFormRespository.Text = GetFormsDir();
         CreateRepository();
         SetupAutoFormsEngine();
      }
   }
}
