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
using System.Threading;
using System.IO;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Codecs;
using Leadtools.Demos;

namespace OcrMultiThreadingDemo
{
   public partial class ConversionControl : UserControl
   {
      public ConversionControl()
      {
         InitializeComponent();
      }

      public event EventHandler ConversionFinished;

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         lock(_abortedLockObject)
            _aborted = true;

         _lblInformation.Text = "Aborting...";
      }

      public event EventHandler ConvertMoreFiles;

      private void _btnConvertMoreFiles_Click(object sender, EventArgs e)
      {
         if(ConvertMoreFiles != null)
            ConvertMoreFiles(this, e);
      }

      private struct WorkItemData
      {
         public OcrEngineType EngineType;
         public IOcrEngine OcrEngine;
         public byte[] DocumentWriterOptions;
         public string SourceFile;
         public string DestinationDirectory;
         public DocumentFormat Format;
         public bool FirstTry;
      }

      private int _workItemCount;
      private AutoResetEvent _batchFinishedEvent;
      private bool _aborted;
      private object _abortedLockObject = new object();

      private IOcrEngine _ocrEngine;
      private DocumentWriter _docWriter;
      private OcrEngineType _engineType;
      private string[] _sourceFiles;
      private string _destinationDirectory;
      private DocumentFormat _format;
      private bool _loopContinuously;
      private int _iteration = 0;
      private string _logFileName;

      public void Convert(DocumentWriter docWriter, OcrEngineType engineType, string[] sourceFiles, string destinationDirectory, DocumentFormat format, bool loopContinuously)
      {
         _docWriter = docWriter;
         _engineType = engineType;
         _sourceFiles = sourceFiles;
         _destinationDirectory = destinationDirectory;
         _format = format;
         _loopContinuously = loopContinuously;
         _logFileName = Path.Combine(destinationDirectory, "_Log.txt");

         // number of documents to process together maximum of 8 or number of cores
         int maxThreadCount = Math.Min(8, Environment.ProcessorCount);
         int documentCount = sourceFiles.Length;
         
         if(loopContinuously)
         {
            _lblInformation.Text = string.Format("Total number of documents is {0}, maximum number of threads is {1}, Iteration {2}", documentCount, maxThreadCount, _iteration + 1);
         }
         else
         {
            _lblInformation.Text = string.Format("Total number of documents is {0}, maximum number of threads is {1}", documentCount, maxThreadCount);
         }

         _pbProgress.Minimum = 0;
         _pbProgress.Maximum = documentCount;
         _pbProgress.Value = 0;
         _btnConvertMoreFiles.Enabled = false;
         _btnCancel.Enabled = true;
         _lbSuccess.Items.Clear();

         if(!loopContinuously)
         {
            _lbError.Items.Clear();
         }

         _aborted = false;

         byte[] docWriterOptions = null;
         using (MemoryStream ms = new MemoryStream())
         {
            docWriter.SaveOptions(ms);
            docWriterOptions = ms.ToArray();
         }

         try
         {
            _ocrEngine = CreateEngine(_engineType, docWriterOptions, false);
         }
         catch (Exception ex)
         {
            OnError(ex.Message);
            OnDone();
            return;
         }

         ThreadPool.QueueUserWorkItem((object state) =>
         {
            // Queue up to maxThreadCount of threads a time
            int sourceFileIndex = 0;
            int documentLeft = documentCount;
            while (documentLeft > 0 && !_aborted)
            {
               int batchCount = Math.Min(maxThreadCount, documentLeft);
               _workItemCount = batchCount;

               ClearQuarantine();

               using (_batchFinishedEvent = new AutoResetEvent(false))
               {
                  for (int i = 0; i < batchCount; i++)
                  {
                     WorkItemData data = new WorkItemData();
                     data.DocumentWriterOptions = docWriterOptions;
                     data.EngineType = engineType;
                     data.OcrEngine = _ocrEngine;
                     data.SourceFile = sourceFiles[i + sourceFileIndex];
                     data.DestinationDirectory = destinationDirectory;
                     data.Format = format;
                     data.FirstTry = true;

                     ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), data);
                  }

                  _batchFinishedEvent.WaitOne();

                  //anything in the quarantine to retry?
                  List<string> quarantineList = new List<string>();
                  GetQuarantine(quarantineList);

                  for (int i = 0; i < quarantineList.Count; i++)
                  {
                     WorkItemData data = new WorkItemData();
                     data.DocumentWriterOptions = docWriterOptions;
                     data.EngineType = engineType;
                     data.OcrEngine = _ocrEngine;
                     data.SourceFile = quarantineList[i];
                     data.DestinationDirectory = destinationDirectory;
                     data.Format = format;
                     data.FirstTry = false;

                     ThreadProc(data);
                  }

                  sourceFileIndex += batchCount;
                  documentLeft -= batchCount;
               }
            }

            OnDone();
         });
      }

      private static IOcrEngine CreateEngine(OcrEngineType engineType, byte[] documentWriterOptions, bool useThunk)
      {
         IOcrEngine ocrEngine = OcrEngineManager.CreateEngine(engineType, useThunk);
         ocrEngine.Startup(null, null, null, null);

         using (MemoryStream ms = new MemoryStream(documentWriterOptions))
         {
            ocrEngine.DocumentWriterInstance.LoadOptions(ms);
         }

         RasterCodecs codecs = ocrEngine.RasterCodecsInstance;

         // Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         codecs.Options.RasterizeDocument.Load.XResolution = 300;
         codecs.Options.RasterizeDocument.Load.YResolution = 300;
         codecs.Options.Pdf.Load.EnableInterpolate = true;
         codecs.Options.Load.AutoFixImageResolution = true;

         // We fine-tuned our app to only run a certain number of threads. The OCR engine can spawn it is own
         // threads to increase the performance of a single recognition process, however, we do not want this
         // in this scenario, these extra threads will decrease the overall performance of our app and we will
         // not be able to keep track of how many threads are actually running

         IOcrSettingManager settingManager = ocrEngine.SettingManager;

         // Disable multi-threaded recognition
         if(settingManager.IsSettingNameSupported("Recognition.Threading.MaximumThreads"))
         {
            settingManager.SetIntegerValue("Recognition.Threading.MaximumThreads", 1);
         }

         // Disable multi-threaded auto-zoning
         if(settingManager.IsSettingNameSupported("Recognition.Zoning.DisableMultiThreading"))
         {
            settingManager.SetBooleanValue("Recognition.Zoning.DisableMultiThreading", true);
         }

         return ocrEngine;
      }

      private static void SetRecommendedLoadingOptions(RasterCodecs rasterCodecs, CodecsImageInfo info, long maximumMemorySize)
      {
         // Do not throw exceptions if we cannot read the file, not our job
         var savedValue = rasterCodecs.ThrowExceptionsOnInvalidImages;

         try
         {
            bool forceDiskMemory = false;
            bool saveLoadDiskMemory = rasterCodecs.Options.Load.DiskMemory;
            bool saveLoadCompressed = rasterCodecs.Options.Load.Compressed;
            bool saveLoadSuperCompressed = rasterCodecs.Options.Load.SuperCompressed;
            int resolution = 300;//always start with 300
            int newResolution = resolution;

            if (maximumMemorySize > 0) //0 means unlimited memory available!
            {
               if (info.SizeMemory > maximumMemorySize)
               {
                  // Is this a document file format that uses resolution?
                  if (info.Document.IsDocumentFile)
                  {
                     // Calculate the exact new resolution
                     long size = info.Width * info.Height * info.BitsPerPixel / 8;
                     newResolution = (int)((double)resolution * (double)Math.Sqrt((double)maximumMemorySize / (double)size));

                     // These are the DPI's to try, everything else is not a standard value and we dont want it
                     // so find the closest to ours
                     int[] validResolutions = { 200, 150, 96, 72 };
                     int validIndex = -1;
                     for (int i = 0; i < validResolutions.Length && validIndex == -1; i++)
                     {
                        if (newResolution > validResolutions[i])
                           validIndex = i;
                     }

                     if (validIndex == -1)
                        validIndex = validResolutions.Length - 1;

                     // Re-calculate the size of memory with new resolution
                     double widthInInches = (double)info.Width / (double)info.XResolution;
                     double heightInInches = (double)info.Height / (double)info.YResolution;

                     newResolution = validResolutions[validIndex];
                     size = (long)((widthInInches * newResolution) * (heightInInches * newResolution) * info.BitsPerPixel / 8);
                     if (size > maximumMemorySize)
                        forceDiskMemory = true;
                  }
                  else
                  {
                     forceDiskMemory = true;
                  }
               }
               else
               {
                  forceDiskMemory = false;
               }
            }

            if (newResolution != resolution)
            {
               rasterCodecs.Options.RasterizeDocument.Load.XResolution = newResolution;
               rasterCodecs.Options.RasterizeDocument.Load.YResolution = newResolution;
            }

            if (forceDiskMemory)
            {
               rasterCodecs.Options.Load.DiskMemory = true;
               rasterCodecs.Options.Load.Compressed = false;
               rasterCodecs.Options.Load.SuperCompressed = false;
            }
         }
         finally
         {
            // reset
            rasterCodecs.ThrowExceptionsOnInvalidImages = savedValue;
         }
      }

      private void ThreadProc(object stateInfo)
      {
         WorkItemData data = (WorkItemData)stateInfo;
         IOcrEngine ocrEngine = null;
         bool passedCriticalStage = false;

         try
         {
            // See if we have canceled
            lock(_abortedLockObject)
            {
               if(_aborted)
                  return;
            }

            string destinationFile = Path.Combine(data.DestinationDirectory, Path.GetFileName(data.SourceFile));

            ocrEngine = data.OcrEngine;

            lock(_abortedLockObject)
            {
               if(_aborted)
                  return;
            }

            // Convert this image file to a document
            string extension = DocumentWriter.GetFormatFileExtension(data.Format);
            destinationFile = string.Concat(destinationFile, ".", extension);
            if (data.Format == DocumentFormat.Ltd && File.Exists(destinationFile))
               File.Delete(destinationFile);

            string sourceFile = Path.GetFileName(data.SourceFile);

            try
            {
               // Create a document and add the pages
               using (IOcrDocument ocrDocument = ocrEngine.DocumentManager.CreateDocument(null, OcrCreateDocumentOptions.AutoDeleteFile))
               {
                  // Get the image number of pages
                  int imagePageCount;

                  RasterCodecs codecs = ocrDocument.RasterCodecsInstance;

                  using (CodecsImageInfo imageInfo = codecs.GetInformation(data.SourceFile, true))
                  {
                     long maximumMemorySize = 42187;
                     IOcrSettingManager settingManager = ocrEngine.SettingManager;

                     // Get the maximum size of the bitmap from the setting
                     if(settingManager.IsSettingNameSupported("Recognition.MaximumPageConventionalMemorySize"))
                     {
                        int maximumConventionalMemorySize = settingManager.GetIntegerValue("Recognition.MaximumPageConventionalMemorySize");
                        maximumMemorySize = (long)maximumConventionalMemorySize * 1024;
                     }
                     
                     SetRecommendedLoadingOptions(codecs, imageInfo, maximumMemorySize);

                     imagePageCount = imageInfo.TotalPages;
                  }

                  // Set the DocumentWriter options
                  using(MemoryStream ms = new MemoryStream(data.DocumentWriterOptions))
                  {
                     ocrDocument.DocumentWriterInstance.LoadOptions(ms);
                  }

                  passedCriticalStage = true;
                  
                  //recognize and add pages
                  for(int pageNumber=1; pageNumber<=imagePageCount; pageNumber++)
                  {
                     lock(_abortedLockObject)
                     {
                        if(_aborted)
                           return;
                     }

                     var image = codecs.Load(data.SourceFile, pageNumber);

                     using(var ocrPage = ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose))
                     {
                        ocrPage.Recognize(null);
                        ocrDocument.Pages.Add(ocrPage);                        
                     }
                  }

                  // Save
                  ocrDocument.Save(destinationFile, data.Format, null);
              }
            }
            finally
            {
            }

            OnSuccess(destinationFile);
         }
         catch(Exception ex)
         {
            string message;
            
            if (passedCriticalStage && data.FirstTry)
            {
               message = string.Format("Error '{0}' while converting file '{1}' (first time, quarantined)", ex.Message, data.SourceFile);
               AddToQuarantine(data.SourceFile);
            }
            else if (passedCriticalStage && !data.FirstTry)
            {
               message = string.Format("Error '{0}' while converting file '{1}' (quarantined error)", ex.Message, data.SourceFile);               
            }
            else
            {
               message = string.Format("Error '{0}' while converting file '{1}'", ex.Message, data.SourceFile);               
            }

            OnError(message);
         }
         finally
         {
            if(ocrEngine != null && ocrEngine != data.OcrEngine)
            {
               ocrEngine.Dispose();
            }

            if (Interlocked.Decrement(ref _workItemCount) == 0)
            {
               _batchFinishedEvent.Set();
            }
         }
      }

      private static void ScrollToBottom(ListBox listBox)
      {
         int visibleItems = listBox.ClientSize.Height / listBox.ItemHeight;
         listBox.TopIndex = Math.Max(listBox.Items.Count - visibleItems + 1, 0);
      }

      private void OnSuccess(string destinationFile)
      {
         this.BeginInvoke(new MethodInvoker(delegate()
         {
            DateTime now = DateTime.Now;

            _pbProgress.Increment(1);
            _lbSuccess.Items.Add(destinationFile);
            ScrollToBottom(_lbSuccess);

            using (StreamWriter sw = File.AppendText(_logFileName))
               sw.WriteLine("Success: Iteration {0} at {1} {2}", _iteration + 1, now, destinationFile);
         }));

         Application.DoEvents();
      }

      private void OnError(string message)
      {
         this.BeginInvoke(new MethodInvoker(delegate()
         {
            DateTime now = DateTime.Now;

            _pbProgress.Increment(1);
            _lbError.Items.Add(now + " " + message);
            ScrollToBottom(_lbError);

            using (StreamWriter sw = File.AppendText(_logFileName))
               sw.WriteLine("Error:  Iteration {0} at {1} {2}", _iteration + 1, now, message);
         }));

         Application.DoEvents();
      }

      private object _quarantineListLockObject = new object();
      private List<string> _quarantineList = new List<string>();
      private void AddToQuarantine(string fileName)
      {
         lock (_quarantineListLockObject)
         {
            _quarantineList.Add(fileName);
         }
      }

      private void GetQuarantine(List<string> quarantineList)
      {
         lock (_quarantineListLockObject)
         {
            quarantineList.AddRange(_quarantineList);
         }
      }

      private void ClearQuarantine()
      {
         lock (_quarantineListLockObject)
         {
            _quarantineList.Clear();
         }
      }

      private void OnMessage(string message)
      {
         this.BeginInvoke(new MethodInvoker(delegate()
         {
            _lbError.Items.Add(message);
         }));

         Application.DoEvents();
      }

      private void OnDone()
      {
         this.BeginInvoke(new MethodInvoker(delegate()
         {
            if(_ocrEngine != null)
            {
               _ocrEngine.Dispose();
            }

            if(_aborted)
               _lblInformation.Text = "Aborted";
            else
               _lblInformation.Text = "Done";

            _pbProgress.Value = 0;
            _btnConvertMoreFiles.Enabled = true;
            _btnCancel.Enabled = false;

            if(!_aborted && _loopContinuously)
            {
               _iteration++;
               Convert(_docWriter, _engineType, _sourceFiles, _destinationDirectory, _format, _loopContinuously);
            }
            else
            {
               _iteration = 0;

               if(ConversionFinished != null)
                  ConversionFinished(this, EventArgs.Empty);
            }
         }));

         Application.DoEvents();
      }
   }
}
