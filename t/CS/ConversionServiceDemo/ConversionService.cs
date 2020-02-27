// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;
using Leadtools;
using Leadtools.Codecs;
using System.Threading;
using System.Reflection;
using ConversionServiceHelper;

#warning "You should run the ConversionServiceConfigDemo before attempting to use this service. The ConversionServiceConfigDemo will allow you to install the service, as well as configure the service behavior."

namespace ConversionServiceDemo
{
   public partial class ConversionService : ServiceBase
   {
      //Represents an image to convert
      struct ConversionItem
      {
         public string SourceFile;
         public string DestFile;
         public RasterImageFormat SaveFormat;

         public ConversionItem(string _sourceFile, string _destFile, RasterImageFormat _saveFormat)
         {
            SourceFile = _sourceFile;
            DestFile = _destFile;
            SaveFormat = _saveFormat;
         }

         //Only compare the source file when checking if an item already exist.
         public override bool Equals(object e)
         {
            ConversionItem conversionItem = (ConversionItem)e;
            return String.Compare(SourceFile, conversionItem.SourceFile, true) == 0;
         }

         public override int GetHashCode()
         {
            return SourceFile.GetHashCode();
         }
      }

      public ConversionService()
      {
         InitializeComponent();
         CreateEventLog();
      }

      private SettingsHelper.ConversionSettings _conversionSettings;
      private System.Timers.Timer _conversionTimer;
      private Dictionary<string, ConversionItem> conversionList = new Dictionary<string, ConversionItem>();
      private bool bContinue = true;
      private long numItemsInPool = 0;
      private object conversionListLockObj = new object();
      private object filenameLockObj = new object();
      private EventLog eventLog = null;

      void CreateEventLog()
      {
         if (!EventLog.SourceExists(Constants.ServiceName))
            EventLog.CreateEventSource(Constants.ServiceName, null); //null default to application log

         eventLog = new EventLog();
         eventLog.Source = Constants.ServiceName;
      }

      private void LoadSettings()
      {
         _conversionSettings = SettingsHelper.LoadSettings(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Constants.ConfigFile));
      }

      private void SetupTimer()
      {
         if (_conversionTimer != null)
         {
            _conversionTimer.Stop();
            _conversionTimer.Elapsed -= new ElapsedEventHandler(_conversionTimer_Elapsed);
            _conversionTimer.Dispose();
         }

         _conversionTimer = new System.Timers.Timer(_conversionSettings.ConversionFrequency * 1000);
         _conversionTimer.Elapsed += new ElapsedEventHandler(_conversionTimer_Elapsed);
         _conversionTimer.Start();
      }

      protected override void OnStart(string[] args)
      {
         InitService();
      }

      protected override void OnStop()
      {
         this.RequestAdditionalTime(60000);
         bContinue = false;

         //Wait for thread pool jobs to process
         while (Interlocked.Read(ref numItemsInPool) != 0)
            Thread.Sleep(1);
      }

      protected override void OnCustomCommand(int command)
      {
         if (command == Constants.ReloadSettingsCommand)
         {
            //Reload settings
            InitService();
         }

         base.OnCustomCommand(command);
      }

      private void InitService()
      {
         try
         {
            LoadSettings();
         }
         catch (Exception ex)
         {
            //Log
            string error = String.Format("An Error occured while loading the service settings. Exception = {0}", ex.Message);
            eventLog.WriteEntry(error, EventLogEntryType.Error);
            this.Stop();
            return;
         }

         try
         {
            SetupTimer();
         }
         catch (Exception ex)
         {
            //Log
            string error = String.Format("An Error occured while initializing the service timer. Exception = {0}", ex.Message);
            eventLog.WriteEntry(error, EventLogEntryType.Error);
            this.Stop();
            return;
         }
      }

      void _conversionTimer_Elapsed(object sender, ElapsedEventArgs e)
      {
         //Stop the timer while we process files
         _conversionTimer.Stop();

         CheckForNewFiles(_conversionSettings.JPEGInputPath, RasterImageFormat.Jpeg);
         CheckForNewFiles(_conversionSettings.PDFInputPath, RasterImageFormat.RasPdfJpeg);

         //Enable timer
         _conversionTimer.Start();
      }

      void CheckForNewFiles(string inputDirectory, RasterImageFormat saveFormat)
      {
         try
         {
            if (!Directory.Exists(inputDirectory))
               return;

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string file in files)
            {
               if (!bContinue)
                  break;

               if (FileLocked(file))
                  continue;

               ConversionItem newItem = new ConversionItem(file, String.Empty, RasterImageFormat.Unknown);
               if (!conversionList.ContainsKey(file))
               {
                  //This is a new file. Add it to our internal list
                  newItem.SaveFormat = saveFormat;
                  lock (conversionListLockObj)
                  {
                     conversionList.Add(file, newItem);
                  }
                  ThreadPool.QueueUserWorkItem(new WaitCallback(ConversionProc), newItem);
               }
            }
         }
         catch (Exception ex)
         {
            //log
            string error = String.Format("An unexpected error has occured. Exception = {0}", ex.Message);
            eventLog.WriteEntry(error, EventLogEntryType.Error);
         }
      }

      void ConversionProc(object stateInfo)
      {
         if (!bContinue)
            return;

         Interlocked.Increment(ref numItemsInPool);
         ConversionItem conversionItem = (ConversionItem)stateInfo;
         bool deleteDummyDest = false;

         try
         {
            //convert file
            RasterCodecs codecs = GetRasterCodecs(conversionItem.SaveFormat);
            conversionItem.DestFile = GetFreeFilename(Path.Combine(_conversionSettings.OutputPath, Path.GetFileNameWithoutExtension(conversionItem.SourceFile) + GetExtension(conversionItem.SaveFormat)));

            using (RasterImage image = codecs.Load(conversionItem.SourceFile))
               codecs.Save(image, conversionItem.DestFile, conversionItem.SaveFormat, 0);
         }
         catch (Exception ex)
         {
            deleteDummyDest = true;

            if (!String.IsNullOrEmpty(conversionItem.SourceFile))
            {
               //Create error file in output directory
               try
               {
                  using (TextWriter textWriter = new StreamWriter(Path.Combine(_conversionSettings.OutputPath, Path.GetFileNameWithoutExtension(conversionItem.SourceFile) + ".log"), true))
                  {
                     textWriter.WriteLine(String.Format("Source: {0}", conversionItem.SourceFile));
                     textWriter.WriteLine(String.Format("Format: {0}", conversionItem.SaveFormat));
                     textWriter.WriteLine(String.Format("Error: {0}", ex.Message));
                  }
               }
               catch (Exception ex2)
               {
                  //Log
                  string error = String.Format("An unexpected error has occured while writing the error file. Sourcefile = {0} Exception = {1}", conversionItem.SourceFile, ex2.Message);
                  eventLog.WriteEntry(error, EventLogEntryType.Error);
               }
            }
         }
         finally
         {
            try
            {
               //Should we move the source file?
               if (!String.IsNullOrEmpty(_conversionSettings.MoveSourcePath))
               {
                  //Does nothing if the directory already exist
                  Directory.CreateDirectory(_conversionSettings.MoveSourcePath);
                  //Move source file
                  string destFile = Path.Combine(_conversionSettings.MoveSourcePath, Path.GetFileName(conversionItem.SourceFile));
                  File.Copy(conversionItem.SourceFile, GetFreeFilename(destFile), true);
               }
            }
            catch (Exception ex)
            {
               //Log
               string error = String.Format("An error occured while moving the source file. Sourcefile = {0} Exception = {1}", conversionItem.SourceFile, ex.Message);
               eventLog.WriteEntry(error, EventLogEntryType.Error);
            }

            try
            {
               //If we did not convert the file successfully, we need to delete the dummy file
               if (deleteDummyDest && File.Exists(conversionItem.DestFile))
                  File.Delete(conversionItem.DestFile);

               //Delete the sourcefile
               File.Delete(conversionItem.SourceFile);
            }
            catch (Exception ex)
            {
               //Log
               string error = String.Format("An error occured while deleting the source file. Sourcefile = {0} Exception = {1}", conversionItem.SourceFile, ex.Message);
               eventLog.WriteEntry(error, EventLogEntryType.Error);
            }

            //remove from list
            lock (conversionListLockObj)
            {
               conversionList.Remove(conversionItem.SourceFile);
            }

            Interlocked.Decrement(ref numItemsInPool);
         }
      }

      string GetFreeFilename(string fileName)
      {
         //get a free file name
         lock (filenameLockObj)
         {
            string filePathNoExt = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName));
            string extension = Path.GetExtension(fileName);

            string newName = filePathNoExt + extension;
            int i = 0;

            while (File.Exists(newName))
            {
               newName = String.Format("{0}_{1}{2}", filePathNoExt, i, extension);
               i++;
            }

            //Create a dummy file so another thread does not use the same filename
            using (FileStream fileStream = File.Create(newName))
            { }

            return newName;
         }
      }

      string GetExtension(RasterImageFormat imageFormat)
      {
         switch (imageFormat)
         {
            case RasterImageFormat.Jpeg:
               return ".jpg";

            case RasterImageFormat.RasPdfJpeg:
               return ".pdf";
         }

         //default
         return ".jpg";
      }

      RasterCodecs GetRasterCodecs(RasterImageFormat imageFormat)
      {
         RasterCodecs codecs = new RasterCodecs();
         switch (imageFormat)
         {
            case RasterImageFormat.Jpeg:
               codecs.Options.Jpeg.Save.QualityFactor = 2;
               break;

            case RasterImageFormat.RasPdfJpeg:
               codecs.Options.Pdf.Save.Version = CodecsRasterPdfVersion.V12;
               break;
         }

         return codecs;
      }

      //Checks to see if the file is ready for conversion. We do not want to
      //convert this file if it is currently copying
      private bool FileLocked(string fileName)
      {
         try
         {
            using (FileStream inputStream = File.Open(fileName, FileMode.Open,
                                            FileAccess.ReadWrite,
                                            FileShare.None))
            {
               return false;
            }
         }
         catch
         {
            return true;
         }
      }
   }
}
