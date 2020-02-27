// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Document.Writer;
using Leadtools.Ocr;
using Leadtools.Document;
using Leadtools.Document.Converter;
using System.Runtime.InteropServices;

namespace DocumentConverterDemo
{
   static class Program
   {
      #region unmanaged
      // Declare the SetConsoleCtrlHandler function as external and receiving a delegate.
      [DllImport("Kernel32")]
      private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

      private delegate bool EventHandler(int sig);
      static EventHandler _handler;

      private static bool Handler(int sig)
      {
         return true;
      }
      #endregion // #region unmanaged

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         Messager.Caption = "Document Converter Folder Demo";

         // Initialize Trace
         Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

         Console.WriteLine("LEADTOOLS " + Messager.Caption);

         // Load the preferences file
         DocumentConverterPreferences.DemoName = "Document Converter Folder Demo";
         DocumentConverterPreferences.XmlFileName = "DocumentConverterFolderDemo";
         var preferences = DocumentConverterPreferences.Load();
         preferences.OpenOutputDocumentAllowed = false;

         MyOptions.XmlFileName = "DocumentConverterFolderOptions";
         var myOptions = MyOptions.Load();

         var runConversion = false;

         using (var dlg = new MyOptionsDialog())
         {
            dlg.MyOptions = myOptions.Clone();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               runConversion = true;
               myOptions = dlg.MyOptions.Clone();
               myOptions.Save();
            }
         }

         if (!runConversion)
            return;

         // Initialize OCR engine
         // Show the OCR engine selection dialog to startup the OCR engine
         Trace.WriteLine("Starting OCR engine");
         var engineType = preferences.OCREngineType;
         using (var dlg = new OcrEngineSelectDialog(DocumentConverterPreferences.DemoName, engineType.ToString(), true))
         {
            dlg.AllowNoOcr = true;
            dlg.AllowNoOcrMessage = "The demo runs without OCR functionality but you will not be able to parse text from non-document files such as TIFF or Raster PDF. Click 'Cancel' to start this demo without an OCR engine.";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               preferences.OcrEngineInstance = dlg.OcrEngine;
               preferences.OCREngineType = dlg.OcrEngine.EngineType;
               Trace.WriteLine(string.Format("OCR engine {0} started", preferences.OCREngineType));
            }
         }

         _handler += new EventHandler(Handler);
         SetConsoleCtrlHandler(_handler, true);

         try
         {
            // Initialize the RasterCodecs instance
            var rasterCodecs = new RasterCodecs();
            rasterCodecs.Options = DocumentFactory.RasterCodecsTemplate.Options.Clone();
            preferences.RasterCodecsInstance = rasterCodecs;

            // Initialize the DocumentWriter instance
            preferences.DocumentWriterInstance = new DocumentWriter();

            // Get the options
            Console.WriteLine("Obtaining conversion options");

            // Collect the options
            using (var dlg = new DocumentConverterDialog())
            {
               // Create a dummy document so the options do not bug us about a input/output files
               using (var document = DocumentFactory.Create("Raster", new CreateDocumentOptions { MimeType = "image/tiff" }))
               {
                  dlg.InputDocument = document;
                  dlg.Preferences = preferences.Clone();
                  dlg.InputDocument = document;
                  if (dlg.ShowDialog() == DialogResult.OK)
                  {
                     preferences = dlg.Preferences.Clone();
                     // Save the preferences
                     preferences.Save();
                  }
                  else
                  {
                     runConversion = false;
                  }
               }
            }

            if (runConversion)
            {
               // Set the RasterCodecs instance, should go into the DocumentFactory class which will be used to load the document
               if (preferences.RasterCodecsInstance != null)
                  DocumentFactory.RasterCodecsTemplate = preferences.RasterCodecsInstance;

               DocumentConverter converter = new DocumentConverter();

               // Set the OCR engine
               if (preferences.OcrEngineInstance != null)
                  converter.SetOcrEngineInstance(preferences.OcrEngineInstance, false);

               if (preferences.DocumentWriterInstance != null)
                  converter.SetDocumentWriterInstance(preferences.DocumentWriterInstance);

               // Set pre-processing options
               converter.Preprocessor.Deskew = preferences.PreprocessingDeskew;
               converter.Preprocessor.Invert = preferences.PreprocessingInvert;
               converter.Preprocessor.Orient = preferences.PreprocessingOrient;

               // Enable trace
               converter.Diagnostics.EnableTrace = preferences.EnableTrace;

               // Set options
               converter.Options.JobErrorMode = preferences.ErrorMode;
               converter.Options.EnableSvgConversion = preferences.EnableSvgConversion;
               converter.Options.SvgImagesRecognitionMode = (preferences.OcrEngineInstance != null && preferences.OcrEngineInstance.IsStarted) ? preferences.SvgImagesRecognitionMode : DocumentConverterSvgImagesRecognitionMode.Disabled;
               converter.Diagnostics.EnableTrace = preferences.EnableTrace;

               try
               {
                  RunConversion(converter, preferences, myOptions);
               }
               catch (Exception ex)
               {
                  Trace.WriteLine("Error " + ex.Message);
               }
            }

            if (preferences.OcrEngineInstance != null)
               preferences.OcrEngineInstance.Dispose();

            if (preferences.RasterCodecsInstance != null)
               preferences.RasterCodecsInstance.Dispose();

            _handler -= new EventHandler(Handler);

            Console.WriteLine("\nDone, Press and key to close demo.");
            Console.ReadKey();
         }
         finally
         {
            _handler -= new EventHandler(Handler);
         }
      }

      private static string GetExtension(DocumentConverterPreferences preferences)
      {
         if (preferences.DocumentFormat != DocumentFormat.User)
            return DocumentWriter.GetFormatFileExtension(preferences.DocumentFormat);
         else
            return RasterCodecs.GetExtension(preferences.RasterImageFormat);
      }

      private static void RunConversion(DocumentConverter converter, DocumentConverterPreferences preferences, MyOptions myOptions)
      {
         if (string.IsNullOrEmpty(myOptions.InputFolder) || !Directory.Exists(myOptions.InputFolder))
         {
            Trace.WriteLine("Input filder does not exist");
            return;
         }

         if (!Directory.Exists(myOptions.OutputFolder))
            Directory.CreateDirectory(myOptions.OutputFolder);

         _logFile = Path.Combine(myOptions.OutputFolder, "_log.txt");
         if (File.Exists(_logFile))
            File.Delete(_logFile);

         _totalTime = 0;

         // Run here
         var filter = myOptions.Extension != null ? myOptions.Extension.Trim() : null;
         if (string.IsNullOrEmpty(filter))
            filter = "*.*";
         var files = Directory.GetFiles(myOptions.InputFolder, filter);
         var temp = new List<string>();
         foreach (var file in files)
         {
            if (Path.GetExtension(file).ToLower() != ".db")
               temp.Add(file);
         }

         files = temp.ToArray();

         Trace.WriteLine(string.Format("{0} files", files.Length));

         var extension = GetExtension(preferences);

         var index = 0;
         var count = files.Length;
         foreach (var inFile in files)
         {
            var tmp = Path.GetFileName(inFile);
            tmp = tmp.Remove(tmp.IndexOf(Path.GetExtension(inFile)));

            var outFile = (tmp + "_" + Path.GetExtension(inFile).Replace(".", "")).Replace(".", "_");

            outFile = Path.Combine(myOptions.OutputFolder, Path.ChangeExtension(outFile, extension));
            Trace.WriteLine(string.Format("{0}:{1}", index + 1, count));
            Trace.WriteLine(inFile);
            Trace.WriteLine(outFile);
            index++;

            Convert(converter, inFile, outFile, preferences);
         }

         Log("Overall conversion time: " + _totalTime.ToString());
         Trace.WriteLine("Overall conversion time: " + _totalTime.ToString());
      }

      private static double _totalTime;
      private static string _logFile;
      private static void Log(string message)
      {
         File.AppendAllText(_logFile, string.Format("{0} - {1}\r\n", DateTime.Now, message));
      }

      private static bool Convert(DocumentConverter converter, string inFile, string outFile, DocumentConverterPreferences preferences)
      {
         // Setup the load document options
         var loadDocumentOptions = new LoadDocumentOptions();
         // Not using cache
         loadDocumentOptions.UseCache = false;

         // Set the input annotation mode or file name
         loadDocumentOptions.LoadEmbeddedAnnotations = preferences.LoadEmbeddedAnnotation;

         converter.LoadDocumentOptions = loadDocumentOptions;

         if (preferences.DocumentFormat == DocumentFormat.Ltd && File.Exists(outFile))
            File.Delete(outFile);

         // Create a job
         var jobData = new DocumentConverterJobData
         {
            InputDocumentFileName = inFile,
            InputDocumentFirstPageNumber = preferences.InputFirstPage,
            InputDocumentLastPageNumber = preferences.InputLastPage,
            DocumentFormat = preferences.DocumentFormat,
            RasterImageFormat = preferences.RasterImageFormat,
            RasterImageBitsPerPixel = preferences.RasterImageBitsPerPixel,
            OutputDocumentFileName = outFile,
            AnnotationsMode = preferences.OutputAnnotationsMode,
            JobName = preferences.JobName,
            UserData = null,
         };

         // Create the job
         var job = converter.Jobs.CreateJob(jobData);
         var ret = true;

         // Run it
         try
         {
            Trace.WriteLine("Running job...");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            converter.Jobs.RunJob(job);
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            _totalTime += elapsed;

            // If we have errors, show them
            Trace.WriteLine("----------------------------------");
            Trace.WriteLine("Status: " + job.Status);
            Trace.WriteLine("----------------------------------");
            Trace.WriteLine("Conversion modes: " +  job.ConversionModes);

            Log(string.Format("{0} - {1} - {2}", job.Status, job.ConversionModes, inFile));

            ret = job.Status == DocumentConverterJobStatus.Success;

            if (job.Errors.Count > 0)
            {
               ret = false;
               // We have errors, show them
               Trace.WriteLine("Errors found:");
               Log("Errors found:");
               foreach (var error in job.Errors)
               {
                  var message = string.Format("Page: {0} - Operation: {1} - Error: {2}", error.InputDocumentPageNumber, error.Operation, error.Error);
                  Trace.WriteLine(message);
                  Log(message);
               }
            }

            Trace.WriteLine("Total conversion time: " + elapsed.ToString());
            Log("Total conversion time: " + elapsed.ToString());
            Trace.WriteLine("----------------------------");
         }
         catch (OcrException ex)
         {
            var message = string.Format("OCR error code: {0} - {1}", ex.Code, ex.Message);
            Trace.WriteLine(message);
            Log(string.Format("{0} - {1}", message, inFile));
            ret = false;
         }
         catch (RasterException ex)
         {
            var message = string.Format("LEADTOOLS error code: {0} - {1}", ex.Code, ex.Message);
            Trace.WriteLine(message);
            Log(string.Format("{0} - {1}", message, inFile));
            ret = false;
         }
         catch (Exception ex)
         {
            var message = string.Format("Error: {0} - {1}", ex.GetType().FullName, ex.Message);
            Trace.WriteLine(message);
            Log(string.Format("{0} - {1}", message, inFile));
            ret = false;
         }

         return ret;
      }
   }
}
