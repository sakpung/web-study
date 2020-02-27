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

using Leadtools.Demos;
using Leadtools;
using Leadtools.Twain;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.ImageProcessing.Core;

namespace OcrTwainScanningDemo
{
   public partial class ProcessDialog : Form
   {
      private TwainSession _twainSession;
      private IOcrDocument _document;
      private string _documentFileName;
      private DocumentFormat _format;

      private bool _canceled;

      private delegate void DoWorkDelegate();

      public ProcessDialog(TwainSession twainSession, IOcrEngine ocrEngine, string documentFileName, DocumentFormat format)
      {
         InitializeComponent();

         _twainSession = twainSession;
         _document = ocrEngine.DocumentManager.CreateDocument();
         _documentFileName = documentFileName;
         _format = format;
      }

      protected override void OnLoad(EventArgs e)
      {
         BeginInvoke(new DoWorkDelegate(DoWork));

         base.OnLoad(e);
      }

      private void DoWork()
      {
         if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
         {
            _canceled = true;
            DialogResult = DialogResult.Cancel;
            return;
         }

         // Create an OCR document
         // Acquire the page(s)
         // Deskew the page
         // Add the pages to the engine
         // Recognize
         // Save to final document

         _lblProcessing.Text = "Acquiring a page...";

         _canceled = false;

         _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);

         try
         {
            if(!_canceled)
            {
               DialogResult res = _twainSession.Acquire(TwainUserInterfaceFlags.Show);
               if (res != DialogResult.OK && _document.Pages.Count <= 0)
                  _canceled = true;
            }

            if(_document.Pages.Count > 0)
            {
               // We have the pages in the OCR engine, recognize them
               if(!_canceled)
                  _document.Pages.Recognize(new OcrProgressCallback(OcrProgress));
               if(!_canceled)
                  _document.Save(_documentFileName, _format, new OcrProgressCallback(OcrProgress));

               // Show the final document
               if(!_canceled && File.Exists(_documentFileName))
                  Process.Start(_documentFileName);
            }
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            // Unhook from the twain events
            _twainSession.AcquirePage -= new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);

            // Remove all the pages from the document
            _document.Pages.Clear();
            _document.Dispose();

            if(!_canceled)
               DialogResult = DialogResult.OK;
            else
               DialogResult = DialogResult.Cancel;
         }
      }

      private void ShowError(Exception ex)
      {
         if(ex is OcrException)
         {
            OcrException oe = ex as OcrException;
            Messager.ShowError(this, string.Format("LEADTOOLS Error\nCode: {0}\nMessage:{1}", oe.Code, ex.Message));
            _canceled = true;
         }
         else if(ex is RasterException)
         {
            RasterException re = ex as RasterException;
            Messager.ShowError(this, string.Format("OCR Error\nCode: {0}\nMessage:{1}", re.Code, ex.Message));
            _canceled = true;
         }
         else
         {
            Messager.ShowError(this, ex);
            _canceled = true;
         }
      }

      private void _twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         if(!_canceled)
         {
            try
            {
               RasterImage image = e.Image;

               // Deskew the image
               DeskewCommand cmd = new DeskewCommand();
               cmd.FillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);
               cmd.Flags = DeskewCommandFlags.DocumentImage;
               cmd.Run(image);

               // Add the page to the OCR engine
               _document.Pages.AddPage(image, new OcrProgressCallback(OcrProgress));
            }
            catch(Exception ex)
            {
               ShowError(ex);
               e.Cancel = true;
            }
         }

         // Check if we canceled
         if(_canceled)
            e.Cancel = true;
      }

      private delegate void UpdateOcrProgressDelegate(string str);
      private void OcrProgress(IOcrProgressData data)
      {
         if (!_canceled)
         {
            if (InvokeRequired)
               BeginInvoke(new UpdateOcrProgressDelegate(DoUpdateOcrProgress), new object[] { "OCR operation: " + data.Operation.ToString() });
            else
               DoUpdateOcrProgress("OCR operation: " + data.Operation.ToString());

            Application.DoEvents();
         }
         else
            data.Status = OcrProgressStatus.Abort;
      }

      private void DoUpdateOcrProgress(string str)
      {
         _lblProcessing.Text = str;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         // Signal canceling
         _canceled = true;

         // We will set the dialog result in DoWork
         DialogResult = DialogResult.None;
      }
   }
}
