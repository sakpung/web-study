// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Document.Writer;
using Leadtools.Ocr;
using System.Runtime.InteropServices;

namespace OcrAutoRecognizeDemo
{
   class Program
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

      [STAThread]
      static int Main(string[] args)
      {
         Messager.Caption = "C# OCR Auto Recognize Demo";

#if LEADTOOLS_V175_OR_LATER
         if (!Support.SetLicense())
            return -1;

#else
         Leadtools.Demos.Support.Unlock(false);
#endif // #if LEADTOOLS_V175_OR_LATER

         _handler += new EventHandler(Handler);
         SetConsoleCtrlHandler(_handler, true);

         // Trace to the console
         Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         JobData jobData = new JobData();
         RasterCodecs _rasterCodecs = new RasterCodecs();
#if !LEADTOOLS_V175_OR_LATER
         _rasterCodecs.Options.RasterizeDocument.Load.Enabled = true;
#endif
         _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24;
#if LEADTOOLS_V16_OR_LATER
         // Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300;
         _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300;
         _rasterCodecs.Options.Pdf.Load.EnableInterpolate = true;
         _rasterCodecs.Options.Load.AutoFixImageResolution = true;
#endif // #if LEADTOOLS_V16_OR_LATER

         bool unexpectedShutdown = false;
         try
         {
            do
            {
               // Get the demo job data
               JobForm form = new JobForm(_rasterCodecs);
               form.JobData = jobData;
               if(form.ShowDialog() != DialogResult.OK)
               {
                  Console.WriteLine("Exiting");
                  return 0;
               }

               bool deleteExistingFile = File.Exists(form.JobData.DocumentFileName);

               if (deleteExistingFile && form.JobData.Format == DocumentFormat.Ltd)
               {
                  // This is an LTD file that already exists, so ask the user what to do here, delete or append to it
                  var message = string.Format("Delete the existing output file '{0}' first?{1}The file already exists. Select 'Yes' to delete it and create a new one or 'No' to append this result to it.",
                     form.JobData.DocumentFileName, Environment.NewLine);
                  switch (Messager.ShowQuestion(null, message, MessageBoxButtons.YesNoCancel))
                  {
                     case DialogResult.Yes:
                        deleteExistingFile = true;
                        break;

                     case DialogResult.No:
                        deleteExistingFile = false;
                        break;

                     default:
                        continue;
                  }
               }

               // Delete the output file first
               if(deleteExistingFile)
                  File.Delete(form.JobData.DocumentFileName);

               // Now run
               IOcrAutoRecognizeManager ocrAutoRecognizeManager = jobData.OcrEngine.AutoRecognizeManager;
               ocrAutoRecognizeManager.EnableTrace = jobData.EnableTrace;
               ocrAutoRecognizeManager.MaximumThreadsPerJob = jobData.MaximumThreadsPerJob;
               ocrAutoRecognizeManager.MaximumPagesBeforeLtd = jobData.MaximumPagesBeforeLtd;
               ocrAutoRecognizeManager.JobErrorMode = jobData.JobErrorMode;
               ocrAutoRecognizeManager.PreprocessPageCommands.Clear();
               foreach(OcrAutoPreprocessPageCommand command in jobData.PreprocessPageCommands)
               {
                  ocrAutoRecognizeManager.PreprocessPageCommands.Add(command);
               }

               Console.WriteLine("Running job...");

               Stopwatch watch = new Stopwatch();
               watch.Start();

               // get an OCR job
               OcrAutoRecognizeJobData ocrJobData = new OcrAutoRecognizeJobData(
                  jobData.ImageFileName,
                  jobData.FirstPageNumber,
                  jobData.LastPageNumber,
                  jobData.ZonesFileName,
                  jobData.Format,
                  jobData.DocumentFileName);
               ocrJobData.JobName = "MyJob";

               IOcrAutoRecognizeJob ocrJob = ocrAutoRecognizeManager.CreateJob(ocrJobData);

               try
               {
                  ocrAutoRecognizeManager.RunJob(ocrJob);
               }
               catch (Exception)
               {
               }

               watch.Stop();
               Console.WriteLine("----------------------------");
               if(ocrJob.Errors.Count > 0)
               {
                  Console.WriteLine("Errors found:");
                  foreach(OcrAutoRecognizeManagerJobError error in ocrJob.Errors)
                  {
                     Console.WriteLine("Page: {0} - Operation: {1} - Error: {2}", error.ImagePageNumber, error.Operation, error.Exception);
                  }
               }

               Console.WriteLine("Total conversion time: " + watch.Elapsed.ToString());
               Console.WriteLine("----------------------------");

               if (jobData.ViewFinalDocument && jobData.Format != DocumentFormat.Ltd)
               {
                  try
                  {
                     System.Diagnostics.Process.Start(jobData.DocumentFileName);
                  }
                  catch(Exception ex)
                  {
                     Messager.ShowError(null, ex);
                  }
               }
            }
            while(true);
         }
         catch(OcrException ex)
         {
            unexpectedShutdown = true;
            Console.WriteLine("OCR error code: {0}\n{1}", ex.Code, ex.Message);
            return 1;
         }
         catch(RasterException ex)
         {
            unexpectedShutdown = true;
            Console.WriteLine("LEADTOOLS error code: {0}\n{1}", ex.Code, ex.Message);
            return 1;
         }
         catch(Exception ex)
         {
            unexpectedShutdown = true;
            Console.WriteLine("Error: " + ex.Message);
            return 1;
         }
         finally
         {
            _handler -= new EventHandler(Handler);
            if(jobData.OcrEngine != null)
            {
               // Dispose the OCR engine (this will call Shutdown as well)
               jobData.OcrEngine.Dispose();
               jobData.OcrEngine = null;
            }
            if (_rasterCodecs != null)
            {
                _rasterCodecs.Dispose();
                _rasterCodecs = null;
            }

            if (unexpectedShutdown)
            {
               Console.WriteLine("Hit Enter...");
               while (Console.ReadKey(true).Key != ConsoleKey.Enter)
               {
               }
            }
         }
      }
   }
}
