// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.SharePoint.Client;

namespace Ocr2SharePointDemo
{
   public partial class RecognizeAndUploadControl : UserControl
   {
      public RecognizeAndUploadControl()
      {
         InitializeComponent();
      }

      private MainForm _mainForm;
      public void SetOwner(MainForm mainForm)
      {
         _mainForm = mainForm;
      }

      private SharePoint.SharePointServerSettings _serverSettings;
      private string _imageDocumentFileName;
      private string _serverDocumentPathAndFileName;
      private Uri _serverDocumentFullUri;
      private MyDocumentFormat _format;

      private Uri _lastUploadedDocumentUri;

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public Uri LastUplodedDocumentUri
      {
         get { return _lastUploadedDocumentUri; }
      }

      public void SetProperties(
         SharePoint.SharePointServerSettings serverSettings,
         string imageDocumentFileName,
         string serverDocumentPathAndFileName,
         MyDocumentFormat format)

      {
         _serverSettings = serverSettings;
         _imageDocumentFileName = imageDocumentFileName;
         _serverDocumentPathAndFileName = serverDocumentPathAndFileName;
         _format = format;

         UriBuilder builder = new UriBuilder(_serverSettings.Uri);
         builder.Path = Path.Combine(builder.Path, serverDocumentPathAndFileName);
         _serverDocumentFullUri = builder.Uri;

         _imageDocumentFileNameTextBox.Text = _imageDocumentFileName;
         _serverDocumentNameTextBox.Text = _serverDocumentFullUri.ToString();
      }

      public void Run()
      {
         // Try to connect
         _successLabel.Visible = false;
         _errorLabel.Visible = false;
         _lastUploadedDocumentUri = null;
         _mainForm.BeginOperation(new MethodInvoker(RecognizeAndUpload));
      }

      private void RecognizeAndUpload()
      {
         Exception error = null;
         string outputFileName = null;

         try
         {
            _mainForm.SetOperationText("Creating OCR engine...");

            using (IOcrEngine ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false))
            {
               ocrEngine.Startup(null, null, null, null);

               // Recognize to a temp file name
               _mainForm.SetOperationText("Recognizing document...");
               outputFileName = System.IO.Path.GetTempFileName();
               DoRecognize(ocrEngine, outputFileName);

               _mainForm.SetOperationText("Uploading document...");
               UploadDocument(outputFileName);
            }

            BeginInvoke((MethodInvoker)delegate
            {
               _successLabel.Visible = true;
            });

            _lastUploadedDocumentUri = _serverDocumentFullUri;
         }
         catch (Exception ex)
         {
            error = ex;

            BeginInvoke((MethodInvoker)delegate
            {
               _errorLabel.Visible = true;
            });
         }
         finally
         {
            if (outputFileName != null && System.IO.File.Exists(outputFileName))
            {
               try
               {
                  System.IO.File.Delete(outputFileName);
               }
               catch { }
            }
         }

         _mainForm.EndOperation(error);
      }

      private void DoRecognize(IOcrEngine ocrEngine, string outputFileName)
      {
         // Set the output format options
         DocumentFormat docFormat;

         switch (_format)
         {
            case MyDocumentFormat.DOC:
               docFormat = DocumentFormat.Doc;
               break;

            case MyDocumentFormat.DOCX:
               docFormat = DocumentFormat.Docx;
               break;

            case MyDocumentFormat.TEXT:
               docFormat = DocumentFormat.Text;
               break;

            case MyDocumentFormat.PDFImageOverText:
            case MyDocumentFormat.PDF:
            default:
               docFormat = DocumentFormat.Pdf;
               if (_format == MyDocumentFormat.PDFImageOverText)
               {
                  PdfDocumentOptions pdfOptions = ocrEngine.DocumentWriterInstance.GetOptions(docFormat) as PdfDocumentOptions;
                  pdfOptions.ImageOverText = true;
                  ocrEngine.DocumentWriterInstance.SetOptions(docFormat, pdfOptions);
               }
               break;
         }

         IOcrAutoRecognizeManager autoRecognizeManager = ocrEngine.AutoRecognizeManager;
         autoRecognizeManager.Run(
            _imageDocumentFileName,
            outputFileName,
            docFormat,
            null,
            null);
      }

      private void UploadDocument(string outputFileName)
      {
         SharePointClient spClient = new SharePointClient();
         spClient.OverwriteExistingFiles = true;

         // Set the credentials and proxy
         if (_serverSettings.UserName != null)
         {
            spClient.Credentials = new NetworkCredential(_serverSettings.UserName, _serverSettings.Password, _serverSettings.Domain);
         }

         if (_serverSettings.ProxyUri != null)
         {
            WebProxy proxy = new WebProxy(_serverSettings.ProxyUri, _serverSettings.ProxyPort);
            if (proxy.Credentials == null && spClient.Credentials != null)
            {
               proxy.Credentials = spClient.Credentials;
            }
            else
            {
               proxy.Credentials = CredentialCache.DefaultCredentials;
            }

            spClient.Proxy = proxy;
         }
         else
            spClient.Proxy = WebRequest.GetSystemWebProxy(); // Get default system proxy settings

         // Upload the file
         spClient.UploadFile(outputFileName, new Uri(_serverSettings.Uri), _serverDocumentPathAndFileName);
      }
   }
}
