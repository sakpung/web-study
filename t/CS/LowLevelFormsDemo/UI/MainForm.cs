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
using Microsoft.Win32;

using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.WinForms;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.Codecs;
using Leadtools.Forms.Processing;
using Leadtools.Forms.Recognition;
using Leadtools.Ocr;
using Leadtools.Forms.Common;
using Leadtools.Forms.Recognition.Barcode;
using Leadtools.Forms.Recognition.Ocr;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Twain;
using Leadtools.Barcode;
using Leadtools.ImageProcessing.Core;
using System.Diagnostics;

namespace FormsDemo
{
   public partial class MainForm : Form
   {
#if FOR_NUGET
      private readonly string NUGET_LIC_WARNING = "When using a LEADTOOLS 30-day, limited license file, LEADTOOLS will randomly watermark your images and documents." +
         " This may cause unexpected results in this demo. " +
         "To obtain a fully functional license with no watermarking, contact LEADTOOLS Technical Support or visit: https://www.leadtools.com/downloads/evaluation-form";
#endif // FOR_NUGET

      private IOcrEngine ocrEngine;
      private IOcrEngine cleanUpOcrEngine;
      private BarcodeEngine barcodeEngine;
      private FormRecognitionEngine recognitionEngine;
      private FormProcessingEngine processingEngine;
      private RasterCodecs rasterCodecs;
      private RasterImage scannedImage;
      private bool canceled = false;
      private OcrEngineType ocrEngineType;
      private Stopwatch recognitionTimer = new Stopwatch();
      private TwainSession twainSession = null;
      private bool recognitionInProcess = false;
      int currentMasterCount = 0;
      private string scannerMessage = String.Format("Although scanning can be implemented in multiple ways within a Forms Recognition and processing application, this demo uses the below implementation:{0}{0}" +
                                                   "1) The scanner must have a feeder{0}" +
                                                   "2) Any number of filled forms can be loaded into the scanner in any order. Pages within each filled form must be in order however.{0}" +
                                                   "3) Only the first page will be used for recognition. Once the first page of a form is scanned, recognized, and processed, the rest of the pages for that form (if multipage) will be scanned and processed as needed. This process is repeated for all forms.{0}" +
                                                   "4) We will attempt to set your scanner to scan in B/W at 300DPI. If your scanner does not support this configuration, an error message will appear and the scanner dialog will be shown so that you can configure the scanner's settings.", Environment.NewLine);
      private string _openInitialPath = string.Empty;

      public MainForm()
      {
         InitializeComponent();
      }

      [STAThread]
      static void Main()
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

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private void Startup()
      {
         try
         {
            if (!StartUpEngines())
            {
               Messager.ShowError(this, "One or more required engines did not start. The application will now close.");
               this.Close();
               return;
            }

            _txtMasterFormRespository.Text = GetFormsDir();
            currentMasterCount = GetMasterFormCount();
            SetupRecognitionEngine();
            SetupProcessingEngine();

            Messager.Caption = "LEADTOOLS Forms Demo";
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }

#if FOR_NUGET
         Properties.Settings settings = new Properties.Settings();
         if (settings.ShowNuGetLicenseWarning)
         {
            Messager.ShowWarning(this, NUGET_LIC_WARNING);
            settings.ShowNuGetLicenseWarning = false;
            settings.Save();
         }
#endif // FOR_NUGET

         UpdateControls();
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
         _btnBrowseMasterFormRespository.Enabled = !recognitionInProcess;

         _btnCancel.Enabled = recognitionInProcess;

         if (!recognitionInProcess)
         {
            _lblFormName.Text = "Form Name: NA";
            _pbProgress.Value = 0;
         }
      }

      private int GetMasterFormCount()
      {
         try
         {
            string[] files = Directory.GetFiles(_txtMasterFormRespository.Text, "*.bin", SearchOption.AllDirectories);
            return files.Length;
         }
         catch
         {
            return 0;
         }
      }

      private string GetFormsDir()
      {
         string formsDir;
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
         return formsDir;
      }

#if LEADTOOLS_V19_OR_LATER
      private FormsPageType GetPageType()
      {
         FormsPageType pageType = FormsPageType.Normal;
         if (_rb_DL.Checked == true)
            pageType = FormsPageType.IDCard;
         if (_rb_Omr.Checked == true)
            pageType = FormsPageType.Omr;
         return pageType;
      }
#endif

      private void _menuItemRecognizeMultipleForms_Click(object sender, EventArgs e)
      {
         try
         {
            recognitionInProcess = true;
            UpdateControls();

            using (FolderBrowserDialogEx fbd = new FolderBrowserDialogEx())
            {
               fbd.SelectedPath = GetSamplesPath();
               fbd.ShowNewFolderButton = false;
               fbd.ShowFullPathInEditBox = true;
               fbd.ShowEditBox = true;
               if (fbd.ShowDialog(this) == DialogResult.OK)
               {
                  canceled = false;
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
            //loader.OpenDialogInitialPath = _openInitialPath;

            AddOperationTime(null, null, TimeSpan.Zero, true);
            if (loader.Load(this, rasterCodecs, false) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
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

      private void _menuItemRecognizeScannedForms_Click(object sender, EventArgs e)
      {
         try
         {
            recognitionInProcess = true;
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
         Properties.Settings settings = new Properties.Settings();
         settings.OcrEngineType = ocrEngineType.ToString();
         settings.Save();

         if (ocrEngine != null && ocrEngine.IsStarted)
         {
            ocrEngine.Shutdown();
            ocrEngine.Dispose();
         }

         if (cleanUpOcrEngine != null && cleanUpOcrEngine.IsStarted)
         {
            cleanUpOcrEngine.Shutdown();
            cleanUpOcrEngine.Dispose();
         }

         if (twainSession != null)
            twainSession.Shutdown();
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

      //Used to display the amount of time a specific operation may take
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
         Application.DoEvents();
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


      public void CreateFormForRecognition(FilledForm form, FormsRecognitionMethod method)
      {
         form.Attributes = CreateForm(method);
         int saveCurrentPageIndex = form.Image.Page;
         RasterImage image = form.Image.CloneAll();
         for (int i = 0; i < form.Image.PageCount; i++)
         {
            if (!canceled)
            {
               form.Image.Page = i + 1;//page index is a 1-based starts from 1 not zero

               PageRecognitionOptions pageOptions = new PageRecognitionOptions();
               pageOptions.UpdateImage = true;
#if LEADTOOLS_V19_OR_LATER
               pageOptions.PageType = GetPageType();
#endif
               AddPageToForm(form.Image, form.Attributes, pageOptions);

               Application.DoEvents();
            }
         }
         form.Image = image;
         form.Image.Page = saveCurrentPageIndex;
      }

      public FormRecognitionAttributes CreateForm(FormsRecognitionMethod method)
      {
         FormRecognitionOptions options = new FormRecognitionOptions();
         options.RecognitionMethod = method;
         FormRecognitionAttributes attributes = recognitionEngine.CreateForm(options);
         recognitionEngine.CloseForm(attributes);
         return attributes;
      }

      public void AddPageToForm(RasterImage image, FormRecognitionAttributes attributes, PageRecognitionOptions options)
      {
         recognitionEngine.OpenForm(attributes);
         recognitionEngine.AddFormPage(attributes, image, options);
         recognitionEngine.CloseForm(attributes);
      }

      FormRecognitionResult CompareFormsFast(FormRecognitionAttributes formAttributes, List<MasterForm> masterForms, ref MasterForm foundedMasterForm)
      {
         List<FormRecognitionAttributes> mastersAttributes = new List<FormRecognitionAttributes>();
         for (int i = 0; i < masterForms.Count; i++)
         {
            mastersAttributes.Add(masterForms[i].Attributes);
            mastersAttributes[mastersAttributes.Count - 1].Image = masterForms[i].Image;
         }

         FormRecognitionResult result = recognitionEngine.CompareFormFast(mastersAttributes, formAttributes, null);
         //Find selected MasterForm
         FormRecognitionAttributes masterAttributes = result.MasterAttributes;
         if (masterAttributes != null)
         {
            for (int i = 0; i < mastersAttributes.Count; i++)
            {
               if (mastersAttributes[i] == masterAttributes)
               {
                  foundedMasterForm = masterForms[i];
                  break;
               }
            }
         }

         //check for missing page results
         if (result.Reason == FormRecognitionReason.Success && result.Confidence > 0)
         {
            List<int> missingPageIndeces = new List<int>();
            for (int i = 0; i < result.PageResults.Count; i++)
            {
               if (result.PageResults[i] == null)
                  missingPageIndeces.Add(i);
            }

            if (missingPageIndeces.Count > 0)
            {

               recognitionEngine.OpenForm(formAttributes);
               recognitionEngine.OpenMasterForm(masterAttributes);

               for (int i = 0; i < missingPageIndeces.Count; i++)
               {
                  PageRecognitionOptions pageOptions = new PageRecognitionOptions();
                  formAttributes.Image.Page = missingPageIndeces[i] + 1;
#if LEADTOOLS_V19_OR_LATER
                  pageOptions.PageType = GetPageType();
#endif
                  recognitionEngine.DeleteFormPage(formAttributes, missingPageIndeces[i] + 1);
                  recognitionEngine.InsertFormPage(missingPageIndeces[i] + 1, formAttributes, formAttributes.Image, pageOptions, null);
                  result.PageResults[missingPageIndeces[i]] = recognitionEngine.ComparePage(masterAttributes, missingPageIndeces[i] + 1, formAttributes, missingPageIndeces[i] + 1);
               }

               recognitionEngine.CloseForm(formAttributes);
               recognitionEngine.CloseMasterForm(masterAttributes);

               // Total the confidence
               int maxPageIndex = 0;
               int maxConfidence = 0;
               int confidenceSum = 0;
               for (int i = 0; i < result.PageResults.Count; i++)
               {
                  PageRecognitionResult pageResult = result.PageResults[i];
                  confidenceSum += pageResult.Confidence;
                  if (pageResult.Confidence > maxConfidence)
                  {
                     maxConfidence = pageResult.Confidence;
                     maxPageIndex = i;
                  }
               }

               // all pages have the same weight here , this meight change in the future, we may give more weight to the first pages

               // rounded to the closest integer
               if (result.PageResults.Count > 0)
               {
                  result.Confidence = (confidenceSum + result.PageResults.Count / 2) / result.PageResults.Count;
               }
               else
                  result.Confidence = 0;

               result.LargestConfidencePageNumber = maxPageIndex + 1;
            }
         }

         return result;
      }



      FormRecognitionResult CompareForm(FormRecognitionAttributes master, FormRecognitionAttributes form, bool isExtended)
      {
         _pbProgress.Step = 1;
         _pbProgress.Minimum = 0;
         _pbProgress.Value = 0;
         _pbProgress.Maximum = 100;
         if (isExtended)
            return recognitionEngine.CompareExtendedForm(master, form, new FormProgressCallback(RecognitionFormCallback), null);
         else
            return recognitionEngine.CompareForm(master, form, new FormProgressCallback(RecognitionFormCallback));
      }

      FormRecognitionResult CompareFirstPage(FormRecognitionAttributes master, FormRecognitionAttributes form)
      {
         _pbProgress.Step = 1;
         _pbProgress.Minimum = 0;
         _pbProgress.Value = 0;
         _pbProgress.Maximum = 100;
         PageRecognitionResult resultPage = recognitionEngine.ComparePage(master, 1, form, 1, new PageProgressCallback(RecognitionPageCallback));
         FormRecognitionResult result = new FormRecognitionResult();
         result.Confidence = resultPage.Confidence;
         result.LargestConfidencePageNumber = 1;
         result.PageResults.Add(resultPage);
         result.Reason = FormRecognitionReason.Success;
         return result;
      }

      //Finds the master form with the highest confidence and returns it's index. 
      //If the highest confidence is < 30, we consider this form having no match
      public int IdentifyForm(List<FormRecognitionResult> results)
      {
         int maxIndex = 0;
         for (int i = 1; i < results.Count; i++)
         {
            if (results[maxIndex].Confidence < results[i].Confidence)
               maxIndex = i;
         }
         if (results[maxIndex].Confidence < 30)
            maxIndex = -1;//no match
         return maxIndex;
      }

      private bool RecognitionFormCallback(int currentPage, int totalPages, int percentage)
      {
         if (canceled)
            return false;

         _pbProgress.Value = percentage;
         return true;
      }

      private void RecognitionPageCallback(PageProgressCallbackData data)
      {
         _pbProgress.Value = data.Percentage;
      }


      public bool RecognizeFormComplex(FilledForm form)
      {
         _lblStatus.Text = "Status: Generating Form Attributes...";
         Application.DoEvents();

         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();
         CreateFormForRecognition(form, FormsRecognitionMethod.Complex);
         stopWatch.Stop();
         AddOperationTime(form.Name, "Generate Attributes", stopWatch.Elapsed, false);

         stopWatch.Reset();
         stopWatch.Start();
         List<FormRecognitionResult> results = new List<FormRecognitionResult>();
         string[] masterFormAttributes = Directory.GetFiles(_txtMasterFormRespository.Text, "*.bin", SearchOption.AllDirectories);
         MasterForm currentMasterForm = null;
         foreach (string masterFormAttribute in masterFormAttributes)
         {
            string fieldsfName = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttribute), ".xml");
            string fieldsfullPath = Path.Combine(Path.GetDirectoryName(masterFormAttribute), fieldsfName);
            currentMasterForm = LoadMasterForm(masterFormAttribute, fieldsfullPath);

            if (!canceled)
            {
               _pbProgress.Value = 0;
               _lblStatus.Text = String.Concat("Status: Comparing with Master form: ", currentMasterForm.Properties.Name);
               Application.DoEvents();

               if (_menuItemRecognizeFirstPageOnly.Checked && !currentMasterForm.IsExtendable)
                  results.Add(CompareFirstPage(currentMasterForm.Attributes, form.Attributes));
               else
                  results.Add(CompareForm(currentMasterForm.Attributes, form.Attributes, currentMasterForm.IsExtendable));

               //If we recognize a form with 80% or higher confidence, stop searching
               if (results[results.Count - 1].Confidence >= 80)
                  break;
            }
            else
            {
               stopWatch.Stop();
               return false;
            }
         }

         stopWatch.Stop();
         AddOperationTime(form.Name, "Recognize Form", stopWatch.Elapsed, false);

         if (!canceled)
         {
            int index = IdentifyForm(results);
            if (index >= 0)
            {
               string fieldsfName = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttributes[index]), ".xml");
               string fieldsfullPath = Path.Combine(Path.GetDirectoryName(masterFormAttributes[index]), fieldsfName);
               form.Master = LoadMasterForm(masterFormAttributes[index], fieldsfullPath);
               FormPages formPages = form.Master.ProcessingPages;
               List<PageAlignment> alignments = new List<PageAlignment>();
               for (int i = 0; i < results[index].PageResults.Count; i++)
                  alignments.Add(results[index].PageResults[i].Alignment);
               //recognitionEngine.FillFieldsInformation(form.Master.Attributes, form.Attributes, formPages, alignments);
               recognitionEngine.FillFieldsInformation(form.Image, form.Master.Attributes, form.Attributes, formPages, alignments);
               form.ProcessingPages = formPages;
               form.Result = results[index];
               return true;
            }
            else
               return false; //no match
         }
         else
            return false;
      }

      public bool RecognizeFormSimple(FilledForm form)
      {
         _lblStatus.Text = "Status: Generating Form Attributes...";
         Application.DoEvents();
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();
         CreateFormForRecognition(form, FormsRecognitionMethod.Simple);
         stopWatch.Stop();
         AddOperationTime(form.Name, "Generate Attributes", stopWatch.Elapsed, false);

         stopWatch.Reset();
         stopWatch.Start();
         string[] masterFormAttributes = Directory.GetFiles(_txtMasterFormRespository.Text, "*.bin", SearchOption.AllDirectories);
         List<MasterForm> masterForms = new List<MasterForm>();
         MasterForm currentMasterForm = null;
         foreach (string masterFormAttribute in masterFormAttributes)
         {
            string fieldsfName = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttribute), ".xml");
            string fieldsfullPath = Path.Combine(Path.GetDirectoryName(masterFormAttribute), fieldsfName);
            currentMasterForm = LoadMasterForm(masterFormAttribute, fieldsfullPath);

            bool isCard = HasIDCard(currentMasterForm.Attributes, currentMasterForm.Properties);
            if (!currentMasterForm.IsExtendable && !isCard)
            {
               masterForms.Add(currentMasterForm);
               string imageName = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttribute), ".tif");
               string imagefullPath = Path.Combine(Path.GetDirectoryName(masterFormAttribute), imageName);
               masterForms[masterForms.Count - 1].Image = rasterCodecs.Load(imagefullPath, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, 1, -1);
            }
         }

         //we must add image to Form Attributes to use Simple Method
         form.Attributes.Image = form.Image;

         MasterForm foundedMasterForm = null;
         FormRecognitionResult result = CompareFormsFast(form.Attributes, masterForms, ref foundedMasterForm);

         stopWatch.Stop();
         AddOperationTime(form.Name, "Recognize Form", stopWatch.Elapsed, false);

         if (!canceled)
         {
            if (foundedMasterForm != null)
            {
               form.Master = foundedMasterForm;
               FormPages formPages = form.Master.ProcessingPages;
               List<PageAlignment> alignments = new List<PageAlignment>();
               for (int i = 0; i < result.PageResults.Count; i++)
                  alignments.Add(result.PageResults[i].Alignment);
               //recognitionEngine.FillFieldsInformation(form.Master.Attributes, form.Attributes, formPages, null);
               recognitionEngine.FillFieldsInformation(form.Image, form.Master.Attributes, form.Attributes, formPages, null);
               form.ProcessingPages = formPages;
               form.Result = result;
               return true;
            }
            else
               return false; //no match
         }
         else
            return false;
      }

      private bool HasIDCard(FormRecognitionAttributes masterAttributes, FormRecognitionProperties properties)
      {
         FormRecognitionEngine engine = new FormRecognitionEngine();
         engine.OpenMasterForm(masterAttributes);

         bool isCard = false;
         for (int i = 0; i < properties.Pages; i++)
         {
            PageRecognitionOptions options = engine.GetPageOptions(masterAttributes, i);
            if (options != null)
            {
               if (options.PageType == FormsPageType.IDCard)
               {
                  isCard = true;
                  break;
               }
            }
         }

         engine.CloseMasterForm(masterAttributes);


         return isCard;
      }

      public void AlignForm(FilledForm form, bool calculateAlignment)
      {
         if (calculateAlignment)
         {

            CreateFormForRecognition(form, FormsRecognitionMethod.Complex);

            form.Alignment = recognitionEngine.GetFormAlignment(form.Master.Attributes, form.Attributes, null);
         }
         else
         {
            form.Alignment = new List<PageAlignment>();
            for (int i = 0; i < form.Result.PageResults.Count; i++)
               form.Alignment.Add(form.Result.PageResults[i].Alignment);
         }
      }

      private void processingEngine_ProcessField(object sender, ProcessFieldEventArgs e)
      {
         if (canceled)
         {
            e.Cancel = true;
            return;
         }

         if (e.Field != null)
         {
            _lblStatus.Text = String.Format("Status: Processing form fields... (Page: {0} of {1} Field Name: {2})", e.FormCurrentPageNumber, e.FormLastPageNumber, e.Field.Name);
         }

         _pbProgress.PerformStep();
         Application.DoEvents();
      }

      private int GetTotalFieldCount(FilledForm form)
      {
         int count = 0;
         foreach (FormPage page in form.ProcessingPages)
         {
            foreach (FormField field in page)
            {
               count++;
            }
         }

         return count;
      }

      public void ProcessForm(FilledForm form)
      {
         if (form.Master.ProcessingPages == null)
            return; //no fields

         _lblStatus.Text = "Status: Processing form fields...";

         if (form.ProcessingPages == null)
            form.ProcessingPages = form.Master.ProcessingPages;

         processingEngine.Pages.Clear();
         processingEngine.Pages.AddRange(form.ProcessingPages);

         _pbProgress.Step = 1;
         _pbProgress.Minimum = 0;
         _pbProgress.Value = 0;
         _pbProgress.Maximum = GetTotalFieldCount(form);
         processingEngine.ProcessField += new EventHandler<ProcessFieldEventArgs>(processingEngine_ProcessField);

         Application.DoEvents();
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();
         processingEngine.Process(form.Image, form.Alignment);
         stopWatch.Stop();
         AddOperationTime(form.Name, "Process Form", stopWatch.Elapsed, false);
         Application.DoEvents();

         processingEngine.ProcessField -= new EventHandler<ProcessFieldEventArgs>(processingEngine_ProcessField);
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
            if (_rb_Omr.Checked)
            {
               for (int i = startIndex; i < startIndex + count; i++)
               {
                  imageToClean.Page = i;
                  DeskewCommand deskew = new DeskewCommand();

                  deskew.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea;
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
         //In this demo, we only use the first page when recognizing scanned forms
         bool oldRecognizeFirstPage = _menuItemRecognizeFirstPageOnly.Checked;
         _menuItemRecognizeFirstPageOnly.Checked = true;
         Application.DoEvents();
         bool bRecognized = false;

         bRecognized = RecognizeFormComplex(filledForm);

         if (!canceled && bRecognized)
         {
            //We need to make sure we scanned all the pages for this form. 
            //We check the master to see how many pages this form needs and scan
            //until we have all pages. 
            if (filledForm.Master.Properties.Pages - scannedImage.PageCount > 0)
               LoadImageScanner(filledForm.Master.Properties.Pages - scannedImage.PageCount);

            //Add the rest of the already scanned pages to the filled form image collection
            if (scannedImage.PageCount > filledForm.Image.PageCount)
               filledForm.Image.AddPages(scannedImage, filledForm.Image.PageCount + 1, -1);

            //Only calculate the alignment if the form has multiple pages and only
            //the first page was loaded and used for recognition. In that case, the alignment has
            //only been calculated for the first page but we need it calculated for all pages
            AlignForm(filledForm, _menuItemRecognizeFirstPageOnly.Checked && (filledForm.Master.Properties.Pages > 1) && !filledForm.Master.IsExtendable);
            ProcessForm(filledForm);

            //We have successfully recognized and processed a form
            return true;
         }
         return false;
      }

      public bool RunFormRecognitionAndProcessing(FilledForm form)
      {
         form.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
         CleanupImage(form.Image, form.Name, 1, form.Image.PageCount);

         bool bRecognizedSimple = false;
         bool bRecognizedComplex = false;

         bRecognizedSimple = RecognizeFormSimple(form);
         if (!bRecognizedSimple)
            bRecognizedComplex = RecognizeFormComplex(form);

         if (!canceled && (bRecognizedSimple | bRecognizedComplex))
         {
            //We need to make sure we loaded all the pages for this form. 
            //We check the master to see how many pages this form needs and load
            //the rest of the pages. 

            //Only calculate the alignment if the form has multiple pages and only
            //the first page was loaded and used for recognition. In that case, the alignment has
            //only been calculated for the first page but we need it calculated for all pages
            if (_menuItemRecognizeFirstPageOnly.Checked && form.Master.Properties.Pages > 1 && !bRecognizedSimple && !form.Master.IsExtendable)
            {
               if (form.Master.Properties.Pages - form.Image.PageCount > 0)
               {
                  RasterImage neededPages = LoadImageFile(form.FileName, form.Image.PageCount + 1, form.Master.Properties.Pages);
                  CleanupImage(neededPages, form.Name, 1, neededPages.PageCount);
                  form.Image.AddPages(neededPages, 1, -1);
               }
               AlignForm(form, true);
            }
            else
               AlignForm(form, false);

            ProcessForm(form);
            //We have successfully recognized and processed a form
            return true;
         }
         return false;
      }

      public MasterForm LoadMasterForm(string attributesFileName, string fieldsFileName)
      {
         FormProcessingEngine tempProcessingEngine = new FormProcessingEngine();
         tempProcessingEngine.OcrEngine = ocrEngine;
         tempProcessingEngine.BarcodeEngine = barcodeEngine;

         MasterForm form = new MasterForm();

         if (File.Exists(attributesFileName))
         {
            byte[] formData = File.ReadAllBytes(attributesFileName);
            form.Attributes.SetData(formData);
            form.Properties = recognitionEngine.GetFormProperties(form.Attributes);
         }

         if (File.Exists(fieldsFileName))
         {
            tempProcessingEngine.LoadFields(fieldsFileName);
            form.ProcessingPages = tempProcessingEngine.Pages;
         }

         return form;
      }

      private void StartUpOcrEngine()
      {
         try
         {
            Properties.Settings settings = new Properties.Settings();
            string engineType = settings.OcrEngineType;

            // Show the engine selection dialog
            using (OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, false))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  ocrEngineType = dlg.SelectedOcrEngineType;
                  ocrEngine = OcrEngineManager.CreateEngine(ocrEngineType, true);
                  ocrEngine.Startup(null, null, null, null);

                  cleanUpOcrEngine = OcrEngineManager.CreateEngine(ocrEngineType, true);
                  cleanUpOcrEngine.Startup(null, null, null, null);
                  this.Text = String.Format("{0} [{1} Engine]", this.Text, ocrEngineType.ToString());
                  if (ocrEngineType == OcrEngineType.LEAD)
                  {
                     _rb_OCR_ICR.Enabled = false;
                     SetEngineSettings(ocrEngine);
                  }
                  else
                  {
                     _rb_OCR_ICR.Enabled = true;
                  }
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

      private void SetupProcessingEngine()
      {
         processingEngine.OcrEngine = ocrEngine;
         if (barcodeEngine != null)
            processingEngine.BarcodeEngine = barcodeEngine;
      }

      public void SetupRecognitionEngine()
      {
         try
         {
            //Add appropriate object managers to recognition engine
            recognitionEngine.ObjectsManagers.Clear();
            if (_menuItemDefaultManager.Checked)
            {
               DefaultObjectsManager defaultObjectManager = new DefaultObjectsManager();
               recognitionEngine.ObjectsManagers.Add(defaultObjectManager);
            }

            if (_menuItemOCRManager.Checked && ocrEngine.IsStarted)
            {
               OcrObjectsManager ocrObjectManager = new OcrObjectsManager(ocrEngine);
               recognitionEngine.ObjectsManagers.Add(ocrObjectManager);
            }

            if (_menuItemBarcodeManager.Checked && barcodeEngine != null)
            {
               BarcodeObjectsManager barcodeObjectManager = new BarcodeObjectsManager(barcodeEngine);
               recognitionEngine.ObjectsManagers.Add(barcodeObjectManager);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private bool StartUpEngines()
      {
         try
         {
            recognitionEngine = new FormRecognitionEngine();
            processingEngine = new FormProcessingEngine();
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

      private void _menuItemHowto_Click(object sender, EventArgs e)
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

      private void _menuItemAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Low Level Forms", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
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
               fbd.ShowNewFolderButton = false;
               fbd.ShowEditBox = true;
               fbd.ShowFullPathInEditBox = true;
               if (fbd.ShowDialog() == DialogResult.OK)
               {
                  _txtMasterFormRespository.Text = fbd.SelectedPath;
                  currentMasterCount = GetMasterFormCount();
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         canceled = true;
      }

      private void _menuItemLaunchMasterFormsEditor_Click(object sender, EventArgs e)
      {
         ProcessStartInfo startInfo = new ProcessStartInfo();
         startInfo.FileName = Path.Combine(Application.StartupPath, "CSMasterFormsEditor_Original.exe");

         if (!File.Exists(startInfo.FileName))
         {
            startInfo.FileName = startInfo.FileName.Replace("_Original", string.Empty);
         }

         if (!File.Exists(startInfo.FileName))
         {
            startInfo.FileName = startInfo.FileName.Replace("LowLevelFormsDemo", "MasterFormsEditor");
         }

         if (!File.Exists(startInfo.FileName))
         {
            MessageBox.Show(String.Format("Cannot find: {0}{1}{1}Please build the CSMasterFormsEditor.exe from the MasterFormsEditor project.", startInfo.FileName, Environment.NewLine), "File Not Found");
            return;
         }

         startInfo.Arguments = String.Format("\"{0}\"", ocrEngine.EngineType.ToString());

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

      private void _rb_Respository_CheckedChanged(object sender, EventArgs e)
      {
         _txtMasterFormRespository.Text = GetFormsDir();
         currentMasterCount = GetMasterFormCount();
         UpdateControls();
      }

      private void ManagerChange_Click(object sender, EventArgs e)
      {
         SetupRecognitionEngine();
      }
   }
}
