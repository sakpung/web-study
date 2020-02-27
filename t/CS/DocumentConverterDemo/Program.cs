// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Document.Writer;
using Leadtools.Ocr;
using Leadtools.Caching;
using Leadtools.Document;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.WinForms;

namespace DocumentConverterDemo
{
   static class Program
   {      
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static int Main(string[] args)
      {
         var preferencesFileName = args.Length == 1 ? args[0] : null;
         try
         {
            return Run(preferencesFileName);
         }
         catch (Exception ex)
         {
            try
            {
               // Load it from the file specified by the user
               if (!string.IsNullOrEmpty(preferencesFileName))
               {
                  var preferences = DocumentConverterPreferences.Load(preferencesFileName);
                  preferences.ErrorMessage = ex.Message;
                  preferences.Save(preferencesFileName);
               }
            }
            catch
            {
            }

            return 1;
         }
      }

      private static int Run(string preferencesFileName)
      {

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         Messager.Caption = "Document Converter Demo";

         // Initialize Trace
         Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

         Console.WriteLine("LEADTOOLS " + Messager.Caption);

         DocumentConverterPreferences preferences;
         ConvertRedactionOptions convertRedactionOptions = null;

         if (!string.IsNullOrEmpty(preferencesFileName))
         {
            // Load it from the file specified by the user
            preferences = DocumentConverterPreferences.Load(preferencesFileName);
            preferences.IsSilentMode = true;
         }
         else
         {
            // Load the preferences file
            DocumentConverterPreferences.DemoName = "Document Converter Demo";
            DocumentConverterPreferences.XmlFileName = "DocumentConverterDemo";
            preferences = DocumentConverterPreferences.Load();
            preferences.IsSilentMode = false;
         }

         if (!Support.SetLicense(preferences.IsSilentMode))
         {
            if (preferences.IsSilentMode)
               throw new Exception("Your license file is missing, invalid or expired.");
            return -1;
         }

         // Create the rendering engine
         try
         {
            if (preferences.AnnRenderingEngine == null)
            {
               preferences.AnnRenderingEngine = new AnnWinFormsRenderingEngine();
               preferences.AnnRenderingEngine.Resources = Tools.LoadResources();
            }
         }
         catch { }

         if (!preferences.IsSilentMode)
         {
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
         }
         else
         {
            // Initialize the default OCR engine
            preferences.OcrEngineInstance = InitOcrEngine(preferences);
         }

         // Initialize the RasterCodecs instance
         var rasterCodecs = new RasterCodecs();
         rasterCodecs.Options = DocumentFactory.RasterCodecsTemplate.Options.Clone();
         preferences.RasterCodecsInstance = rasterCodecs;

         if (!string.IsNullOrEmpty(preferences.RasterCodecsOptionsPath))
            preferences.RasterCodecsInstance.LoadOptions(preferences.RasterCodecsOptionsPath);

         // Initialize the DocumentWriter instance
         preferences.DocumentWriterInstance = new DocumentWriter();
         if (!string.IsNullOrEmpty(preferences.DocumentWriterOptionsPath))
            preferences.DocumentWriterInstance.LoadOptions(preferences.DocumentWriterOptionsPath);

         // Cache to use
         ObjectCache cache = null;

         // Initialize the cache
         if (!string.IsNullOrEmpty(preferences.CacheDirectory))
         {
            var fileCache = new FileCache();
            fileCache.CacheDirectory = preferences.CacheDirectory;
            fileCache.DataSerializationMode = preferences.CacheDataSerializationMode;
            fileCache.PolicySerializationMode = preferences.CachePolicySerializationMode;
            cache = fileCache;
         }

         // Do conversions
         var more = true;
         while (more)
         {
            Console.WriteLine("Obtaining conversion options");

            if (!preferences.IsSilentMode)
            {
               // Collect the options
               using (var dlg = new DocumentConverterDialog())
               {
                  dlg.Preferences = preferences.Clone();
                  dlg.RedactionOptions = convertRedactionOptions;
                  if (dlg.ShowDialog() == DialogResult.OK)
                  {
                     preferences = dlg.Preferences.Clone();
                     convertRedactionOptions = dlg.RedactionOptions;
                  }
                  else
                  {
                     more = false;
                  }
               }
            }

            if (more)
            {
               try
               {
                  // Save the preferences
                  if (!preferences.IsSilentMode)
                     preferences.Save();

                  // Run the conversion
                  if (preferences.DocumentId != null)
                  {
                     var loadFromCacheOptions = new LoadFromCacheOptions
                     {
                        Cache = cache,
                        DocumentId = preferences.DocumentId,
                        UserToken = preferences.DocumentUserToken
                     };
                     using (var document = DocumentFactory.LoadFromCache(loadFromCacheOptions))
                     {
                        if (document == null)
                           throw new Exception(string.Format("Could not load document with ID '{0}' from the cache", preferences.DocumentId));

                        preferences.Run(cache, document, null, convertRedactionOptions);
                     }
                  }
                  else
                  {
                     preferences.Run(null, null, null, convertRedactionOptions);
                  }
               }
               catch (Exception ex)
               {
                  if (!preferences.IsSilentMode)
                     Messager.ShowError(null, ex.Message);
                  else
                     preferences.ErrorMessage = ex.Message;
               }
            }

            if (more)
            {
               if (!preferences.IsSilentMode)
               {
                  // Ask if user wants to convert another document
                  more = (Messager.ShowQuestion(null, "Convert more?", MessageBoxButtons.YesNo) == DialogResult.Yes);
               }
               else
               {
                  more = false;
               }
            }
         }

         if (preferences.OcrEngineInstance != null)
            preferences.OcrEngineInstance.Dispose();

         if (preferences.RasterCodecsInstance != null)
            preferences.RasterCodecsInstance.Dispose();

         if (preferencesFileName != null)
            preferences.Save(preferencesFileName);

         if (preferences.ErrorMessage != null)
            return 1;

         return 0;
      }

      // Initialize the OCR engine used throughout the application
      private static IOcrEngine InitOcrEngine(DocumentConverterPreferences preferences)
      {
         // try to start the OCR engine
         IOcrEngine ocrEngine = null;

         var ocrEngineType = preferences.OCREngineType;

         try
         {
            Trace.WriteLine("Starting OCR engine");
            ocrEngine = OcrEngineManager.CreateEngine(ocrEngineType, false);

#if LT_CLICKONCE
            var ocrEngineRuntimePath = Path.Combine(Application.StartupPath, @"OCR Engine");
#else
            var ocrEngineRuntimePath = preferences.OCREngineRuntimePath;

            if (string.IsNullOrEmpty(ocrEngineRuntimePath))
            {
               // Maybe in a local folder under this EXE?
               if (ocrEngineType == OcrEngineType.LEAD)
                  ocrEngineRuntimePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"LEADTOOLS\OcrLEADRuntime");
               else if (ocrEngineType == OcrEngineType.OmniPage)
               {
                  if (IntPtr.Size == 8)
                     ocrEngineRuntimePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"LEADTOOLS\OcrOmniPageRuntime64");
                  else
                     ocrEngineRuntimePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"LEADTOOLS\OcrOmniPageRuntime");
               }
            }

            if (!Directory.Exists(ocrEngineRuntimePath))
            {
               // No, check the registry if this machine has LEADTOOLS installed
               ocrEngineRuntimePath = null;
            }
#endif

            ocrEngine.Startup(null, null, null, ocrEngineRuntimePath);
         }
         catch (Exception ex)
         {
            ocrEngine = null;

            var message = string.Format("Failed to start the OCR engine. The demo will continue running without OCR functionality and you will not be able to parse text from non-document files such as TIFF or Raster PDF.\n\nError message:\n{0}", ex.Message);
            Trace.WriteLine(message);
         }

         return ocrEngine;
      }
   }
}
