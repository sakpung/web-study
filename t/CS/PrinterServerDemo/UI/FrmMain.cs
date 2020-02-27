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
using Leadtools.Demos;
using Leadtools.Printer;
using Leadtools.Codecs;
using Leadtools;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using Leadtools.Document.Writer;
using System.Threading;
using System.Runtime.InteropServices;

namespace ServerPrinterDemo.UI
{
   public partial class FrmMain : Form
   {

      #region Main...
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         try
         {
            if (!Support.SetLicense())
               return;

            if (args.Length > 0)
            {
               FrmMain.StartedPrinter = args[0];

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
         }
         catch { }
      }

      private static bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }

      #endregion

      #region Fields...

      public static string _strTittle
      {
         get
         {
            if(Is64Bit())
               return "LEADTOOLS C# Printer Server Demo 64-bit";
            else
               return "LEADTOOLS C# Printer Server Demo 32-bit";
         }
      }

      Printer _printer;
      static string StartedPrinter = string.Empty;
      bool bSelectedPrinter = true;
      string _currentPrinterName = string.Empty;
      string _fontPath = string.Empty;
      RasterCodecs _codec;
      JobHolder _jobHolder;
      int _nIndex;
      delegate void UpdateListboxDelegate(int nIndex, JobHolder jobHolder);
      delegate void EnableButtonDialog(Control control, bool bEnable);
      #endregion

      public FrmMain()
      {
         try
         {
            if (InitClass())
               InitializeComponent();
            else
            {
               Close();
               return;
            }

            this.Text = _strTittle;

            _codec = new RasterCodecs();

            _txtPrinterName.Text = _currentPrinterName;

            string newGuid = Guid.NewGuid().ToString("N");
            _fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), newGuid);
            Directory.CreateDirectory(_fontPath);
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
         }
      }

      private bool InitClass()
      {
         if (RasterSupport.IsLocked(RasterSupportType.PrintDriver) && RasterSupport.IsLocked(RasterSupportType.PrintDriverServer))
         {
            throw new Exception("Printer driver capability is required.");
         }

         if (FrmMain.StartedPrinter == string.Empty)
         {
            bSelectedPrinter = GetPrinterName(true);
            if (!bSelectedPrinter)
               return false;

            SetCurrentPrinter();
         }
         else
         {
            bSelectedPrinter = true;
            _currentPrinterName = FrmMain.StartedPrinter;
            SetCurrentPrinter();
         }

         return bSelectedPrinter;
      }

      private bool GetPrinterName(bool bShowInstall)
      {
         try
         {
            string currentPrinterName = string.Empty;

            if (!bShowInstall)
            {
               currentPrinterName = _currentPrinterName;
            }

            FrmGetPrinterName frmGetPrinterName = new FrmGetPrinterName(currentPrinterName);
            DialogResult dialogResult = frmGetPrinterName.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
               if (_currentPrinterName != frmGetPrinterName.PrinterName && _lstBoxLog != null)
               {
                  _lstBoxLog.Items.Clear();
                  _btnOpen.Enabled = _btnShow.Enabled = _btnClear.Enabled = false;
               }

               _currentPrinterName = frmGetPrinterName.PrinterName;

               return true;
            }
            else
            {
               return false;
            }
         }
         catch
         {
            return false;
         }
      }

      private void SetCurrentPrinter()
      {
         try
         {
            if (_printer != null)
            {
               _printer.EmfEvent -= new EventHandler<EmfEventArgs>(_printer_EmfEvent);

               _printer.JobEvent -= new EventHandler<JobEventArgs>(_printer_JobEvent);

#if INTERNET_PRINTING
               _printer.EnableInternetPrinting = false;
#endif // #if INTERNET_PRINTING

               _printer.Dispose();
            }

            _printer = new Printer(_currentPrinterName);

            _printer.EmfEvent += new EventHandler<EmfEventArgs>(_printer_EmfEvent);

            _printer.JobEvent += new EventHandler<JobEventArgs>(_printer_JobEvent);

#if INTERNET_PRINTING
            _printer.EnableInternetPrinting = true;
#endif // #if INTERNET_PRINTING
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      public void SetProgressState()
      {
         try
         {
            if (_jobHolder._jobData != null)
            {
               //Job has client custom data, we will use these data to perform the save
               _jobHolder._message = "( " + _jobHolder._jobData.IPAddress + " ) Job name " + _jobHolder._jobData.PrintJobName + " Job ID " +
                                     _jobHolder._jobData.JobID + " Page No: " + _jobHolder._tempFiles.Count.ToString();
            }
            else
            {
               //Job does not have the additional data, we will save the job using the Job ID
               _jobHolder._message = "( No Extra Information ) JobID " + _jobHolder._jobID + " Page No: " + _jobHolder._tempFiles.Count.ToString();
            }

            _lstBoxLog.Items[_nIndex] = _jobHolder;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      public void _printer_EmfEvent(object sender, EmfEventArgs e)
      {
         if (_jobHolder == null)
            return;

         string tempFile = Path.GetTempFileName();
         File.WriteAllBytes(tempFile, e.Stream.ToArray());

         SetProgressState();

         _jobHolder.AddEmf(tempFile);
      }

      public void _printer_JobEvent(object sender, JobEventArgs e)
      {
         if (e.JobEventState == EventState.JobStart)
         {
            _btnCancel.Enabled = true;
            _btnChange.Enabled = false;

            this.BringToFront();
            this.Focus();

            PrintJobData jobData = _printer.RemoteData;
            if (_printer.RemoteData != null)
            {
               _jobHolder = new JobHolder(e.JobID, jobData.UserData, _codec, jobData, _fontPath);

               _jobHolder._message = "( " + _jobHolder._jobData.IPAddress + " ) Job name " +
                                     jobData.PrintJobName + " Job ID " + jobData.JobID;

               _nIndex = _lstBoxLog.Items.Add(_jobHolder);
            }
            else
            {
               _jobHolder = new JobHolder(e.JobID, _codec, _fontPath);

               _jobHolder._message = "Job Received With No Extra Information ( Job ID  " + e.JobID + " )";
               _nIndex = _lstBoxLog.Items.Add(_jobHolder);
            }
         }
         else if (e.JobEventState == EventState.JobEnd)
         {
            JobHolder tmpHolder = null;
            for (int i = 0; i < _lstBoxLog.Items.Count; i++)
            {
               if (_lstBoxLog.Items[i].GetType() != typeof(JobHolder))
                  continue;

               tmpHolder = (JobHolder)_lstBoxLog.Items[i];
               if (tmpHolder._jobID == e.JobID)
               {
                  _jobHolder = tmpHolder;
                  break;
               }
            }

            if (_jobHolder != null)
            {
               _btnCancel.Enabled = false;
               this.BringToFront();
               this.Focus();

               string strMessage = "";

               //Check if Job has client custom data
               if (_jobHolder._jobData != null)
                  strMessage = "( " + _jobHolder._jobData.IPAddress + " ) Saving " + _jobHolder._format + " file, please wait ... ";
               else
                  strMessage = "( No Extra Information ) Saving " + _jobHolder._format + " file, please wait ... ";

               _jobHolder._message = strMessage;
               _lstBoxLog.Items[_nIndex] = _jobHolder;

               //Get embedded fonts related to the Job ID
               string[] arrFonts = _printer.GetEmbeddedFonts(_jobHolder._fontPath, e.JobID);
               _jobHolder.SetFonts(arrFonts);

               //Save on a different thread
               ParameterizedThreadStart pStart = new ParameterizedThreadStart(DoSave);
               Thread tSaving = new Thread(pStart);
               tSaving.Start(new object[] { _jobHolder, _nIndex });
               _jobHolder = null;
            }
         }
      }

      void EnableButton(Control control, bool bEnable)
      {
         if (control.InvokeRequired)
         {
            EnableButtonDialog d = new EnableButtonDialog(EnableButton);
            this.Invoke(d, new object[] { control, bEnable });
         }
         else
         {
            control.Enabled = bEnable;
         }
      }

      void UpdateListbox(int nIndex, JobHolder jobHolder)
      {
         if (_lstBoxLog.InvokeRequired)
         {
            UpdateListboxDelegate d = new UpdateListboxDelegate(UpdateListbox);
            this.Invoke(d, new object[] { nIndex, jobHolder });
         }
         else
         {
            this._lstBoxLog.Items[nIndex] = jobHolder;
         }
      }

      void DoSave(object data)
      {
         try
         {
            object[] objects = (object[])data;
            JobHolder jobHolder = (JobHolder)objects[0];
            int nIndex = (int)objects[1];

            jobHolder.Save();

            jobHolder.UninstallFonts();
            jobHolder.DeleteFonts();
            jobHolder.ClearFiles();

            EnableButton(_btnChange, true);
            EnableButton(_btnClear, true);

            //Check if Job has client custom data
            if (jobHolder._jobData != null)
               jobHolder._message = "( " + jobHolder._jobData.IPAddress + " )File saved to: " + jobHolder._fileSaved;
            else
               jobHolder._message = "( No Extra Information )File saved to: " + jobHolder._fileSaved;

            UpdateListbox(nIndex, jobHolder);
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _printer.CancelPrintedJob(_jobHolder._jobID);
      }

      private void _btnChange_Click(object sender, EventArgs e)
      {
         this.Hide();

         _printer.EmfEvent -= new EventHandler<EmfEventArgs>(_printer_EmfEvent);
         _printer.JobEvent -= new EventHandler<JobEventArgs>(_printer_JobEvent);
#if INTERNET_PRINTING
         _printer.EnableInternetPrinting = false;
#endif // #if INTERNET_PRINTING
         _printer.Dispose();
         _printer = null;

         GetPrinterName(false);
         SetCurrentPrinter();

         _txtPrinterName.Text = _currentPrinterName;
         this.Show();
      }

      private void _lstBoxLog_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_lstBoxLog.SelectedItem == null || _lstBoxLog.SelectedItem.GetType() != typeof(JobHolder))
         {
            _btnShow.Enabled = _btnOpen.Enabled = false;
            return;
         }

         JobHolder jobHolder = (JobHolder)_lstBoxLog.SelectedItem;
         if (jobHolder != null)
         {
            _btnShow.Enabled = jobHolder._saved && Directory.Exists(Path.GetDirectoryName(jobHolder._fileSaved));
            _btnOpen.Enabled = jobHolder._saved && File.Exists(jobHolder._fileSaved);
            _btnOpen.Tag = _btnShow.Tag = jobHolder;
         }
      }

      private void _btnOpen_Click(object sender, EventArgs e)
      {
         JobHolder jobHolder = (JobHolder)_btnOpen.Tag;

         if (jobHolder != null && jobHolder._saved)
         {
            if (!File.Exists(jobHolder._fileSaved))
            {
               MessageBox.Show("File not found.", FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
               _btnOpen.Enabled = false;
               return;
            }

            try
            {
               Process.Start(jobHolder._fileSaved);
            }
            catch (System.Exception ex)
            {
               MessageBox.Show(ex.Message, FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
      }

      private void _btnShow_Click(object sender, EventArgs e)
      {
         JobHolder jobHolder = (JobHolder)_btnShow.Tag;

         if (jobHolder != null && jobHolder._saved)
            Process.Start(Path.GetDirectoryName(jobHolder._fileSaved));
      }

      private void _btnClear_Click(object sender, EventArgs e)
      {
         _lstBoxLog.Items.Clear();
         _btnShow.Enabled = _btnOpen.Enabled = _btnClear.Enabled = false;

      }

      private void FrmMain_Shown(object sender, EventArgs e)
      {
         this.Focus();
         this.BringToFront();
      }

      bool CanClose()
      {
         bool bCanClose = true;
         foreach (object item in _lstBoxLog.Items)
         {
            if (item.GetType() != typeof(JobHolder))
               continue;

            JobHolder holder = (JobHolder)item;
            if (holder._saving)
            {
               bCanClose = false;
               break;
            }

         }
         return bCanClose;
      }

      private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (!CanClose())
         {
            MessageBox.Show("Application cant close while saving, try to close the application later", _strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
         }
         else
         {

            //Dispose of printer before closing
            _printer.EmfEvent -= new EventHandler<EmfEventArgs>(_printer_EmfEvent);

            _printer.JobEvent -= new EventHandler<JobEventArgs>(_printer_JobEvent);
#if INTERNET_PRINTING
            _printer.EnableInternetPrinting = false;
#endif // #if INTERNET_PRINTING
            _printer.Dispose();

            try
            {
               if (Directory.Exists(_fontPath))
                  Directory.Delete(_fontPath, true);
            }
            catch
            {
               // Do nothing
            }
         }
      }

      private void _btnReadMe_Click(object sender, EventArgs e)
      {
         Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "\\ServerDemoReadMe.txt");
      }

   }

   class JobHolder
   {
      public int _jobID;
      public List<string> _tempFiles = new List<string>();
      public List<string> _fontNames = new List<string>();

      public string _format;
      public string _savename;
      public string _message;
      public string _fileSaved;
      public bool _saving;
      public string _fontPath;

      public PrintJobData _jobData;
      RasterCodecs _codec;
      public bool _saved;

      [DllImport("gdi32")]
      public static extern int AddFontResource(string lpFileName);

      [DllImport("gdi32")]
      public static extern int RemoveFontResource(string lpFileName);

      public JobHolder(int jobID, RasterCodecs codec, string fontPath)
      {
         _jobID = jobID;
         _codec = codec;
         _saving = false;
         _saved = false;

         _format = "pdf";
         _savename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Job ID " + jobID;

         _fontPath = fontPath;
      }

      public JobHolder(int jobID, byte[] bytes, RasterCodecs codec, PrintJobData jobData, string fontPath)
      {
         _jobID = jobID;
         _codec = codec;
         _jobData = jobData;
         _saving = false;

         Encoding unicode = Encoding.Unicode;

         string strBytes = unicode.GetString(bytes);
         int nIndex;
         nIndex = strBytes.IndexOf("---");
         _saved = false;

         _format = strBytes.Substring(0, nIndex);
         strBytes = strBytes.Substring(nIndex + 3);
         _savename = strBytes;

         _fontPath = fontPath;
      }


      public void ClearFiles()
      {
         foreach (string str in _tempFiles)
         {
            if (File.Exists(str))
               File.Delete(str);
         }
      }

      public void AddEmf(string file)
      {
         _tempFiles.Add(file);
      }

      public void SetFonts(string[] fonts)
      {
         if (fonts != null)
            _fontNames.AddRange(fonts);
      }

      public void InstallFonts()
      {
         foreach (string strFont in _fontNames)
         {
            AddFontResource(_fontPath + "\\" + strFont);
         }
      }

      public void UninstallFonts()
      {
         foreach (string strFont in _fontNames)
         {
            RemoveFontResource(_fontPath + "\\" + strFont);
         }
      }

      public void DeleteFonts()
      {
         foreach (string strFont in _fontNames)
         {
            try
            {
               File.Delete(_fontPath + "\\" + strFont);
            }
            catch
            {
               // Do nothing
            }
         }
      }

      public void Save()
      {
         try
         {
            _saving = true;
            if (_tempFiles.Count == 0)
            {
               MessageBox.Show("No pages where printed.", FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
            }

            Application.DoEvents();
            string strName = _savename;
            DocumentFormat documentFormat = DocumentFormat.User;
            DocumentOptions documentOptions = null;
            PdfDocumentOptions PdfdocumentOptions = new PdfDocumentOptions();

            InstallFonts();

            string strExt = "";

            if (_format.ToLower() == "pdf")
            {
               documentFormat = DocumentFormat.Pdf;
               documentOptions = new PdfDocumentOptions();
               (documentOptions as PdfDocumentOptions).DocumentType = PdfDocumentType.Pdf;
               (documentOptions as PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto;
               strExt = "pdf";
            }

            if (_format.ToLower() == "doc")
            {
               documentFormat = DocumentFormat.Doc;
               documentOptions = new DocDocumentOptions();
               (documentOptions as DocDocumentOptions).TextMode = DocumentTextMode.Framed;
               strExt = "doc";
            }

            if (_format.ToLower() == "xps")
            {
               documentFormat = DocumentFormat.Xps;
               documentOptions = new XpsDocumentOptions();
               strExt = "xps";
            }

            if (_format.ToLower() == "text")
            {
               documentFormat = DocumentFormat.Text;
               documentOptions = new TextDocumentOptions();
               strExt = "txt";
            }

            if (!strName.Contains("." + strExt.ToLower()))
               strName += "." + strExt.ToLower();

            if (_jobData != null)
               strName = Path.GetDirectoryName(strName) + "\\(" + _jobData.IPAddress + ") " + Path.GetFileName(strName);

            _fileSaved = strName;

            DocumentWriter documentWriter = new DocumentWriter();
            documentWriter.SetOptions(documentFormat, documentOptions);
            documentWriter.BeginDocument(strName, documentFormat);

            foreach (string strFile in _tempFiles)
            {
#if LEADTOOLS_V20_OR_LATER
               DocumentWriterEmfPage documentPage = new DocumentWriterEmfPage();
#elif LEADTOOLS_V19_OR_LATER
               DocumentEmfPage documentPage = new DocumentEmfPage();
#else
               DocumentPage documentPage = DocumentPage.Empty;
#endif // #if LEADTOOLS_V19_OR_LATER
               Metafile metaFile = new Metafile(strFile);

               documentPage.EmfHandle = metaFile.GetHenhmetafile();

               documentWriter.AddPage(documentPage);

               (new Metafile(documentPage.EmfHandle, true)).Dispose();
               metaFile.Dispose();
            }
            documentWriter.EndDocument();

            _saved = true;
            _saving = false;
         }
         catch (Exception Ex)
         {
            _saving = false;
            MessageBox.Show(Ex.Message, FrmMain._strTittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      public override string ToString()
      {
         return _message;
      }

   }
}
