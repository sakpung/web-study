// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Leadtools;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Printer;
using Leadtools.Document.Writer;
using Leadtools.Codecs;

namespace PrinterDemo
{
   struct JobInfoStruct
   {
      private int _jobId;
      private int _pageNo;

      public JobInfoStruct(int jobId, int pageNo)
      {
         _jobId = jobId;
         _pageNo = pageNo;
      }

      public int JobId
      {
         get { return _jobId; }
      }

      public int PageNo
      {
         get { return _pageNo; }
      }
   }

   public partial class FrmMain : Form
   {
      [DllImport("kernel32.dll")]
      static extern IntPtr GlobalLock(IntPtr hMem);

      [DllImport("kernel32.dll")]
      static extern bool GlobalUnlock(IntPtr hMem);

      [DllImport("kernel32.dll")]
      static extern bool GlobalFree(IntPtr hMem);

#if LEADTOOLS_V175_OR_LATER
      //Dotnet does not have functions to add or remove font files, we will have to use the API ones
      [DllImport("gdi32")]
      public static extern int AddFontResource(string lpFileName);

      [DllImport("gdi32")]
      public static extern int RemoveFontResource(string lpFileName);
#endif

      private const Int32 DM_OUT_BUFFER = 14;

      #region Main...
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         try
         {
#if LEADTOOLS_V175_OR_LATER
            if (!Support.SetLicense())
               return;
#else
            Support.Unlock(false);
#endif // #if LEADTOOLS_V175_OR_LATER

            if (args.Length > 0)
            {
               FrmMain.StartedPrinter = args[0];

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
         }
         catch
         {
         }
      }
      #endregion

      #region Constructor...
      public FrmMain()
      {
         try
         {
            if (InitClass())
               InitializeComponent();
            else
               Close();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
         }
      }
      #endregion

      #region Fields...
      PrintDocument _printDocument = new PrintDocument();
      Printer _printer;
      FrmProgress _frmProgress = new FrmProgress();
      List<IntPtr> _lstMetaFiles = new List<IntPtr>();
      List<JobInfoStruct> _lstJobInfo = new List<JobInfoStruct>();
      int _pageNo = 0;
      int _jobId = 0;
      string _currentPrinterName = string.Empty;
      static string StartedPrinter = string.Empty;
      bool bSelectedPrinter = true;
      RasterCodecs _codec;
      List<string> _tempFiles = new List<string>();
#if LEADTOOLS_V175_OR_LATER
      //Array to hold the font names
      List<string> _fonts = new List<string>();
      //Path to save the font files to
      string _fontsPath;
#endif
      #endregion

      #region Properties...
      private bool ReceiveJobEvent
      {
         get
         {
            return _miEventsJob.Checked;
         }
      }

      private bool ReceiveEmfEvent
      {
         get
         {
            return _miEventsEmf.Checked;
         }
      }

      private bool ViewOutputFile
      {
         get
         {
            if (_miViewOutputFile == null)
               return true;

            return _miViewOutputFile.Checked;
         }
      }
      #endregion

      #region Events...
      private void FrmMain_Load(object sender, EventArgs e)
      {
         try
         {
            _codec = new RasterCodecs();
            _miPrinterDefaultSpecs.Visible = true;
            if (bSelectedPrinter == false)
               this.Close();
            else
            {
               _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
            }

            _miViewOutputFile.Checked = true;
            this.Text = "LEADTOOLS C# Printer Demo - Active printer is: " + _currentPrinterName;

            string newGuid = Guid.NewGuid().ToString("N");
            //Get the path to the shared documents
            _fontsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), newGuid);
            Directory.CreateDirectory(_fontsPath);
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
         }
      }

      private void FrmMain_Resize(object sender, EventArgs e)
      {
         _pictureBox.Invalidate();
         _lstBoxPages.Invalidate();
      }

      void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         DrawStartedPage(e.Graphics);
      }

      private void _pictureBox_Paint(object sender, Leadtools.Controls.ImageViewerRenderEventArgs e)
      {
         if (_lstBoxPages.Items.Count == 0 || _pictureBox.Image == null)
         {
            DrawStartedPage(e.PaintEventArgs.Graphics);
            _miNormal.Enabled = false;
            _miFit.Enabled = false;
            _miZoomIn.Enabled = false;
            _miZoomOut.Enabled = false;
         }
         else
         {
            _miNormal.Enabled = true;
            _miFit.Enabled = true;
            _miZoomIn.Enabled = true;
            _miZoomOut.Enabled = true;
         }

      }

      public void _printer_EmfEvent(object sender, EmfEventArgs e)
      {
         this.Enabled = false;
         string tempFile = Path.GetTempFileName();
         _tempFiles.Add(tempFile);
         File.WriteAllBytes(tempFile, e.Stream.ToArray());

         Metafile metaFile = new Metafile(e.Stream);
         _pageNo++;

         if (_frmProgress.Visible)
         {
            _frmProgress.SetProgressState(_pageNo, _jobId);
         }

         Image emfImage = metaFile.GetThumbnailImage(_lstBoxPages.Width, _lstBoxPages.ItemHeight, null, IntPtr.Zero);
         int nLastIndex = _lstBoxPages.Items.Add(emfImage);
         _lstMetaFiles.Add(metaFile.GetHenhmetafile());
         _lstJobInfo.Add(new JobInfoStruct(_jobId, _pageNo));
      }

      public void _printer_JobEvent(object sender, JobEventArgs e)
      {
         if (e.JobEventState == EventState.JobStart)
         {
            this.Enabled = true;
            this.BringToFront();
            this.Focus();
            _pageNo = 0;
            _jobId = e.JobID;
            if (!_frmProgress.Visible)
            {
               _frmProgress = new FrmProgress(e.PrinterName, _printer);
               _frmProgress.Show();
            }
         }
         else if (e.JobEventState == EventState.JobEnd)
         {
            _frmProgress.Close();
            //job-end event we may have embedded font attached to the job
            //we will save the font files so we can use them when saving
            AddAndInstallFonts(e.JobID);
            this.Enabled = true;
            _lstBoxPages.SelectedIndex = 0;
            this.BringToFront();
            this.Focus();
         }
      }

      private void _miSetActivePrinter_Click(object sender, EventArgs e)
      {
         try
         {
            GetPrinterName(false);
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miInstallPrinter_Click(object sender, EventArgs e)
      {
         try
         {
            FrmInstallPrinter frmInstallPrinter = new FrmInstallPrinter();
            DialogResult dialogResult = frmInstallPrinter.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
               string newPrinterName = frmInstallPrinter.PrinterName;
               string newPrinterPassword = frmInstallPrinter.PrinterPassword;

               bool bSuccess = PrintingUtilities.InstallNewPrinter(newPrinterName, newPrinterPassword);

               if (bSuccess)
               {
                  _currentPrinterName = newPrinterName;
                  SetCurrentPrinter();

               }
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private DialogResult UninstallPrinter(string printerName)
      {
         DialogResult dialogResult = DialogResult.Ignore;

         try
         {
            string warningMessage = string.Format("Are you sure you want to remove the {0} printer from the system?", printerName);
            dialogResult = MessageBox.Show(warningMessage, "LEADTOOLS Printer Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
               PrinterInfo printerInfo = new PrinterInfo();
               printerInfo.PrinterName = printerName;
               printerInfo.MonitorName = printerName;
               printerInfo.PortName = printerName;

               Printer.UnInstall(printerInfo);
               MessageBox.Show("Uninstall Printer Completed Successfully", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }

         return dialogResult;
      }

      private void _miUninstallPrinter_Click(object sender, EventArgs e)
      {
         try
         {
            FrmUninstallPrinter frmUninstallPrinter = new FrmUninstallPrinter();
            DialogResult dialogResult = frmUninstallPrinter.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
               string printerName = frmUninstallPrinter.PrinterName;

               if ((printerName == _currentPrinterName) && IsCurrentPrinterLocked())
               {
                  UnLockPrinter();
                  if (IsCurrentPrinterLocked())
                     return;
               }

               if (UninstallPrinter(printerName) == DialogResult.Yes)
               {
                  if (printerName == _currentPrinterName)
                  {
                     if (!GetPrinterName(true))
                     {
                        this.Close();
                     }
                  }
               }
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miLockPrinter_Click(object sender, EventArgs e)
      {
         try
         {
            LockPrinter();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miUnLockPrinter_Click(object sender, EventArgs e)
      {
         try
         {
            UnLockPrinter();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miPrintCurrentPage_Click(object sender, EventArgs e)
      {
         try
         {
            if (IsCurrentPrinterLocked())
            {
               UnLockPrinter();
            }

            if (IsCurrentPrinterLocked() == false)
            {
               this.Enabled = false;
               _printDocument.PrinterSettings.PrinterName = _currentPrinterName;
               _printer.Specifications.DimensionsInInches = false;

               _printDocument.DefaultPageSettings.Landscape = !_printer.Specifications.PortraitOrient;

               if (_printer.Specifications.PaperID == 0)
               {
                  PaperSize paperSize = new PaperSize();
                  paperSize.PaperName = _printer.Specifications.PaperSizeName;
                  paperSize.Height = Convert.ToInt32(_printer.Specifications.PaperHeight) * 100;
                  paperSize.Width = Convert.ToInt32(_printer.Specifications.PaperWidth) * 100;
                  _printDocument.DefaultPageSettings.PaperSize = paperSize;
               }
               else
               {
                  if (_printer.Specifications.PaperID < _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes.Count)
                     _printDocument.DefaultPageSettings.PaperSize.RawKind = _printer.Specifications.PaperID;
               }

               PrinterResolution paperResolution = new PrinterResolution();
               paperResolution.X = _printer.Specifications.YResolution;
               paperResolution.Y = _printer.Specifications.YResolution;

               _printDocument.DefaultPageSettings.PrinterResolution = paperResolution;
               _printDocument.Print();
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
            this.Enabled = true;
         }
      }

      private void _miClearPrintedList_Click(object sender, EventArgs e)
      {
         try
         {
            ClearList();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miEventsEmf_Click(object sender, EventArgs e)
      {
         try
         {
            if (ReceiveEmfEvent)
            {
               _printer.EmfEvent += new EventHandler<EmfEventArgs>(_printer_EmfEvent);
            }
            else
            {
               _printer.EmfEvent -= new EventHandler<EmfEventArgs>(_printer_EmfEvent);
               MessageBox.Show("By disabling this event, you will not see a thumbnail of the printed document in the list on the left.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miEventsJob_Click(object sender, EventArgs e)
      {
         try
         {
            if (ReceiveJobEvent)
            {
               _printer.JobEvent += new EventHandler<JobEventArgs>(_printer_JobEvent);
            }
            else
            {
               _printer.JobEvent -= new EventHandler<JobEventArgs>(_printer_JobEvent);
               MessageBox.Show("By disabling this event, you will not get any information on the print job.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miAbout_Click(object sender, EventArgs e)
      {
         try
         {
            using (AboutDialog aboutDialog = new AboutDialog("Printer", ProgrammingInterface.CS))
               aboutDialog.ShowDialog(this);
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miExit_Click(object sender, EventArgs e)
      {
         try
         {
            this.Close();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _lstBoxPages_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (_lstBoxPages.Items.Count > 0)
            {
               double oldScaleFactor = _pictureBox.ScaleFactor;
               if (oldScaleFactor <= 0)
                  oldScaleFactor = 1;

               if (_pictureBox.Image != null)
                  _pictureBox.Image.Dispose();

               byte[] buffer = File.ReadAllBytes(_tempFiles[_lstBoxPages.SelectedIndex]);
               MemoryStream stream = new MemoryStream(buffer);
               _pictureBox.Image = _codec.Load(stream, 24, CodecsLoadByteOrder.BgrOrGray, 1, 1);

               if(_miFit.Checked)
                  View_Clicked(_miFit, new EventArgs());
               else
                  _pictureBox.Zoom(Leadtools.Controls.ControlSizeMode.None, oldScaleFactor, _pictureBox.DefaultZoomOrigin);
               stream.Close();
            }

            _pictureBox.Invalidate();
            _lstBoxPages.Invalidate();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private Rectangle GetFitRect(Rectangle rect, int width, int height)
      {
         int newWidth = 0;
         int newHeight = 0;

         newHeight = rect.Height;
         newWidth = newHeight * width / height;

         if (newWidth > rect.Width)
         {
            newWidth = rect.Width;
            newHeight = newWidth * height / width;
         }

         return new Rectangle(rect.Left, rect.Top, newWidth, newHeight);
      }

      private void _lstBoxPages_DrawItem(object sender, DrawItemEventArgs e)
      {
         try
         {
            if (e.Index >= 0)
            {
               Graphics graphics = e.Graphics;
               float fontSize = 1;
               Brush brush = Brushes.LightBlue;

               if (e.Index == _lstBoxPages.SelectedIndex)
               {
                  fontSize = 5;
                  brush = Brushes.Blue;
               }
               Rectangle rect = e.Bounds;
               rect.Inflate(new Size(-30, -05));
               Rectangle thumbnailRect = new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height - 20);
               graphics.FillRectangle(Brushes.Pink, new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height));
               graphics.FillRectangle(Brushes.White, new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height - 20));
               graphics.DrawRectangle(new Pen(brush, fontSize), new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height));
               graphics.DrawImage((_lstBoxPages.Items[e.Index] as Image), thumbnailRect);
               graphics.DrawString("Page " + _lstJobInfo[e.Index].PageNo.ToString() + ", Job ID " + _lstJobInfo[e.Index].JobId.ToString(), this.Font, Brushes.Black, rect.Left + 2, rect.Bottom - 20);
            }
         }
         catch { }
      }

      private void _miFile_DropDownOpening(object sender, EventArgs e)
      {
         try
         {
            bool bItemsExist = (_lstMetaFiles.Count > 0);

            _miClearPrintedList.Enabled = bItemsExist;
            _miSavePrintJobsAs.Enabled = bItemsExist;
            _miSavePrintJobsAsAndClearList.Enabled = bItemsExist;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miPrinterLock_DropDownOpening(object sender, EventArgs e)
      {
         try
         {
            bool bEnableUnLockPrinter = _printer.IsPrinterLocked();
            _miLockPrinter.Enabled = !bEnableUnLockPrinter;
            _miUnLockPrinter.Enabled = bEnableUnLockPrinter;
            _miPrinterSpecs.Enabled = _miLockPrinter.Enabled;
         }
         catch (PrinterDriverException Ex)
         {
            if (Ex.Code == PrinterDriverExceptionCode.PrinterCannotBeLocked)
            {
               _miLockPrinter.Enabled = false;
               _miUnLockPrinter.Enabled = false;
               _miPrinterSpecs.Enabled = true;
            }
         }
      }

      private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
      {
      }

      private void _miRaster_Click(object sender, EventArgs e)
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            SavePrintedJobsRaster();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
            Cursor = Cursors.Default;
         }
      }

      private void _miDocument_Click(object sender, EventArgs e)
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            SavePrintedJobsDocument();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
            Cursor = Cursors.Default;
         }

      }

      private void _miDocumentClear_Click(object sender, EventArgs e)
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            if (SavePrintedJobsDocument() == DialogResult.OK)
               ClearList();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
            Cursor = Cursors.Default;
         }
      }

      private void _miRasterClear_Click(object sender, EventArgs e)
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            if (SavePrintedJobsRaster() == DialogResult.OK)
               ClearList();
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
            Cursor = Cursors.Default;
         }
      }

      private void _lstBoxPages_KeyDown(object sender, KeyEventArgs e)
      {
         try
         {
            if (e.KeyCode == Keys.Delete && _lstBoxPages.SelectedItems.Count == 1)
            {
               int index = _lstBoxPages.SelectedIndex;

               if (_lstBoxPages.SelectedIndex == _lstBoxPages.Items.Count - 1 && _lstBoxPages.Items.Count > 1)
                  _lstBoxPages.SelectedIndex = 0;
               else if (_lstBoxPages.Items.Count > 1)
                  _lstBoxPages.SelectedIndex = index + 1;

               (_lstBoxPages.Items[index] as Image).Dispose();
               _lstBoxPages.Items.RemoveAt(index);

               Metafile emf = new Metafile(_lstMetaFiles[index], true);
               emf.Dispose();
               _lstMetaFiles.RemoveAt(index);
               _lstJobInfo.RemoveAt(index);

               if (File.Exists(_tempFiles[index]))
                  File.Delete(_tempFiles[index]);

               _tempFiles.RemoveAt(index);

               if (_lstBoxPages.Items.Count == 0)
               {
                  //We dont have any page left, delete font files
                  DeleteAndUninstallFonts();
                  _pictureBox.Image = null;
               }
            }
            else if (e.KeyCode == Keys.Add)
            {
               View_Clicked(_miZoomIn, new EventArgs());
            }
            else if (e.KeyCode == Keys.Subtract)
            {
               View_Clicked(_miZoomOut, new EventArgs());
            }
         }
         catch (ArgumentOutOfRangeException)
         {
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void _miPrinterSpecs_Click(object sender, EventArgs e)
      {
         _printDocument.PrinterSettings.PrinterName = _currentPrinterName;
         FrmSpecifications specDialog = new FrmSpecifications(_printer.Specifications, _printDocument);

         if (specDialog.ShowDialog(this) == DialogResult.OK)
         {
            PrinterSpecifications printerSpecs = new PrinterSpecifications();
            printerSpecs.MarginsPrinter = specDialog.MarginsPrinter;
            printerSpecs.PaperID = specDialog.PaperID;
            printerSpecs.PortraitOrient = specDialog.Portrait;
            printerSpecs.PrintQuality = specDialog.PrintQuality;
            printerSpecs.YResolution = specDialog.PrintQuality;

            _printer.Specifications = printerSpecs;
         }
      }

      private void _miPrinterDefaultSpecs_Click(object sender, EventArgs e)
      {
         _printDocument.PrinterSettings.PrinterName = _currentPrinterName;
         FrmSpecifications specDialog = new FrmSpecifications(_printer.UserDefaultSpecifications, _printDocument);

         if (specDialog.ShowDialog(this) == DialogResult.OK)
         {
            PrinterSpecifications printerSpecs = new PrinterSpecifications();
            printerSpecs.MarginsPrinter = specDialog.MarginsPrinter;
            printerSpecs.PaperID = specDialog.PaperID;
            printerSpecs.PortraitOrient = specDialog.Portrait;
            printerSpecs.PrintQuality = specDialog.PrintQuality;
            printerSpecs.YResolution = specDialog.PrintQuality;

            _printer.UserDefaultSpecifications = printerSpecs;
         }
      }

      private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            DeleteTempFiles();
            //Application will exit, delete font files
            DeleteAndUninstallFonts();

            if (Directory.Exists(_fontsPath))
               Directory.Delete(_fontsPath, true);

            if (_codec != null)
               _codec.Dispose();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      private void View_Clicked(object sender, EventArgs e)
      {
         _miNormal.Checked = false;
         _miFit.Checked = false;
         _miZoomIn.Checked = false;
         _miZoomOut.Checked = false;

         Leadtools.Controls.ControlSizeMode sizeMode = Leadtools.Controls.ControlSizeMode.None;
         double scaleFactor = _pictureBox.ScaleFactor;
         if (sender == _miNormal)
         {
            sizeMode = Leadtools.Controls.ControlSizeMode.ActualSize;
            scaleFactor = 1.0;
            _miNormal.Checked = true;
         }
         else if (sender == _miFit)
         {
            sizeMode = Leadtools.Controls.ControlSizeMode.FitAlways;
            scaleFactor = 1.0;
            _miFit.Checked = true;
         }
         else if (sender == _miZoomIn)
         {
            sizeMode = Leadtools.Controls.ControlSizeMode.None;
            scaleFactor += 0.1;
            _miZoomIn.Checked = true;
         }
         else if (sender == _miZoomOut)
         {
            sizeMode = Leadtools.Controls.ControlSizeMode.None;
            if (scaleFactor > 1)
               scaleFactor -= 0.1;
            _miZoomOut.Checked = true;
         }

         try
         {
            _pictureBox.Zoom(sizeMode, scaleFactor, _pictureBox.DefaultZoomOrigin);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _pictureBox_KeyDown(object sender, KeyEventArgs e)
      {
         try
         {
            if (e.KeyCode == Keys.Add)
            {
               View_Clicked(_miZoomIn, new EventArgs());
            }
            else if (e.KeyCode == Keys.Subtract)
            {
               View_Clicked(_miZoomOut, new EventArgs());
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
      #endregion

      #region Methods...
      private bool InitClass()
      {
         if (RasterSupport.IsLocked(RasterSupportType.PrintDriver) && RasterSupport.IsLocked(RasterSupportType.PrintDriverServer))
         {
            throw new Exception("Printer driver capability is required.");
         }

         if (FrmMain.StartedPrinter == string.Empty)
         {
            bSelectedPrinter = GetPrinterName(true);
         }
         else
         {
            bSelectedPrinter = true;
            _currentPrinterName = FrmMain.StartedPrinter;
            SetCurrentPrinter();
         }

         return bSelectedPrinter;
      }

#if LEADTOOLS_V175_OR_LATER
      //On job-end event we will get the embedded fonts generated by the print job if any exist
      public void AddAndInstallFonts(int nJobID)
      {
         string[] arrFonts = _printer.GetEmbeddedFonts(_fontsPath, nJobID);
         if (arrFonts != null && arrFonts.Length > 0)
         {
            _fonts.AddRange(arrFonts);

            for (int i = 0; i < arrFonts.Length; i++)
            {
               AddFontResource(_fontsPath + "\\" + arrFonts[i]);
            }
         }
      }

      //Delete the font files if we dont need them anymore
      public void DeleteAndUninstallFonts()
      {
         foreach (string strFont in _fonts)
         {
            if (File.Exists(_fontsPath + "\\" + strFont))
            {
               RemoveFontResource(_fontsPath + "\\" + strFont);
               File.Delete(_fontsPath + "\\" + strFont);
            }
         }

         _fonts.Clear();
      }
#endif

      private DialogResult SavePrintedJobsRaster()
      {
         System.Windows.Forms.DialogResult result = DialogResult.Cancel;

         Cursor = Cursors.WaitCursor;
         ImageFileSaver saver = new ImageFileSaver();

         if (saver.Save(this, _codec, _tempFiles, ViewOutputFile))
            result = DialogResult.OK;

         return result;
      }

      private void SaveAsEmf(string fileName)
      {
         int index = fileName.LastIndexOf(Path.GetExtension(fileName));

         for (int i = 0; i < _tempFiles.Count; i++)
         {
            string destFileName = fileName.Insert(index, "_" + (i + 1).ToString());
            File.Copy(_tempFiles[i], destFileName);
         }

         if (ViewOutputFile)
         {
            System.Diagnostics.Process.Start(fileName.Insert(index, "_1"));
         }
      }

      private DialogResult SavePrintedJobsDocument()
      {
         System.Windows.Forms.DialogResult result = DialogResult.Cancel;

         try
         {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string strFilter;
#if LTV16_CONFIG
            strFilter = "(*.PDF Files)|*.pdf|(*.PDFA Files)|*.pdf|(*.Doc Files)|*.doc|(*.RTF Files)|*.rtf|(*.Text Files)|*.txt|(*.HTML Files)|*.html|(*.DOCX Files)|*.docx|(*.XPS Files)|*.xps";
#endif
#if LEADTOOLS_V17_OR_LATER
            strFilter = "(*.PDF Files)|*.pdf|(*.PDFA Files)|*.pdf|(*.Doc Files)|*.doc|(*.RTF Files)|*.rtf|(*.Text Files)|*.txt|(*.HTML Files)|*.html|(*.DOCX Files)|*.docx|(*.XPS Files)|*.xps|(*.XLS Files)|*.xls";
#endif
            saveFileDialog.Filter = strFilter;
            result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
               Application.DoEvents();
               Cursor = Cursors.WaitCursor;
               DocumentFormat documentFormat = DocumentFormat.User;
               DocumentOptions documentOptions = null;
               PdfDocumentOptions PdfdocumentOptions = new PdfDocumentOptions();
               string fileName = saveFileDialog.FileName;

               switch (saveFileDialog.FilterIndex)
               {
                  case 1:
                     documentFormat = DocumentFormat.Pdf;
                     documentOptions = new PdfDocumentOptions();
                     (documentOptions as PdfDocumentOptions).DocumentType = PdfDocumentType.Pdf;
                     (documentOptions as PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto;
                     break;

                  case 2:
                     documentFormat = DocumentFormat.Pdf;
                     documentOptions = new PdfDocumentOptions();
                     (documentOptions as PdfDocumentOptions).DocumentType = PdfDocumentType.PdfA;
                     (documentOptions as PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto;
                     (documentOptions as PdfDocumentOptions).ImageOverText = true;
                     break;

                  case 3:
                     documentFormat = DocumentFormat.Doc;
                     documentOptions = new DocDocumentOptions();
                     (documentOptions as DocDocumentOptions).TextMode = DocumentTextMode.Framed;
                     break;

                  case 4:
                     documentFormat = DocumentFormat.Rtf;
                     documentOptions = new RtfDocumentOptions();
                     (documentOptions as RtfDocumentOptions).TextMode = DocumentTextMode.Framed;
                     break;

                  case 5:
                     documentFormat = DocumentFormat.Text;
                     documentOptions = new TextDocumentOptions();
                     (documentOptions as TextDocumentOptions).DocumentType = TextDocumentType.Unicode;
                     (documentOptions as TextDocumentOptions).Formatted = true;
                     break;

                  case 6:
                     documentFormat = DocumentFormat.Html;
                     documentOptions = new HtmlDocumentOptions();
                     (documentOptions as HtmlDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto;
                     break;

                  case 7:
                     documentFormat = DocumentFormat.Docx;
                     documentOptions = new DocxDocumentOptions();
                     (documentOptions as DocxDocumentOptions).MaintainAspectRatio = true;
                     (documentOptions as DocxDocumentOptions).PageRestriction = DocumentPageRestriction.Default;
                     (documentOptions as DocxDocumentOptions).TextMode = DocumentTextMode.Framed;
                     break;

                  case 8:
                     documentFormat = DocumentFormat.Xps;
                     documentOptions = new XpsDocumentOptions();
                     break;
#if LTV16_CONFIG
                  case 9:
                     SaveAsEmf(fileName);
                     return result;
#endif
#if LEADTOOLS_V17_OR_LATER
                  case 9:
                     documentFormat = DocumentFormat.Xls;
                     documentOptions = new XlsDocumentOptions();
                     (documentOptions as XlsDocumentOptions).PageRestriction = DocumentPageRestriction.Relaxed;
                     break;

                  case 10:
                     SaveAsEmf(fileName);
                     return result;
#endif
               }

               DocumentWriter documentWriter = new DocumentWriter();
               documentWriter.SetOptions(documentFormat, documentOptions);
               documentWriter.BeginDocument(fileName, documentFormat);

               foreach (IntPtr metaFile in _lstMetaFiles)
               {
#if LEADTOOLS_V20_OR_LATER
                  DocumentWriterEmfPage documentPage = new DocumentWriterEmfPage();
#elif LEADTOOLS_V19_OR_LATER
                  DocumentEmfPage documentPage = new DocumentEmfPage();
#else
                  DocumentPage documentPage = DocumentPage.Empty;
#endif // #if LEADTOOLS_V19_OR_LATER

                  int index = _lstMetaFiles.IndexOf(metaFile);
                  
                  documentPage.EmfHandle = metaFile;

                  if (saveFileDialog.FilterIndex == 2)
                     documentPage.Image = _codec.Load(_tempFiles[index]);

                  documentWriter.AddPage(documentPage);
               }
               documentWriter.EndDocument();

               if (ViewOutputFile)
               {
                  System.Diagnostics.Process.Start(fileName);
               }
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }

         return result;
      }

      private void ClearList()
      {
         try
         {
            foreach (Image image in _lstBoxPages.Items)
            {
               image.Dispose();
            }

            foreach (IntPtr emf in _lstMetaFiles)
            {
               Metafile metaFile = new Metafile(emf, true);
               metaFile.Dispose();
            }
            _lstBoxPages.Items.Clear();
            _lstMetaFiles.Clear();
            _lstJobInfo.Clear();
            DeleteTempFiles();
#if LEADTOOLS_V175_OR_LATER
            //Clear the font files when we delete all the jobs
            DeleteAndUninstallFonts();
#endif
            _tempFiles.Clear();

            if (_pictureBox.Image != null)
            {
               _pictureBox.Image.Dispose();
               _pictureBox.Image = null;
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
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

            if (dialogResult == DialogResult.OK && frmGetPrinterName.PrinterName != _currentPrinterName)
            {
               _currentPrinterName = frmGetPrinterName.PrinterName;
               SetCurrentPrinter();
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

      private void LockPrinter()
      {
         try
         {
            FrmPassword frmPassword = new FrmPassword(true);
            DialogResult dialogResult = frmPassword.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
               string lockPassword = frmPassword.Password;
               _printer.Lock(lockPassword);

               if (IsCurrentPrinterLocked())
               {
                  MessageBox.Show("Printer is locked.  You will no longer be able to print to it.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               }
               else
                  MessageBox.Show("Incorrect password.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void UnLockPrinter()
      {
         try
         {
            FrmPassword frmPassword = new FrmPassword(false);
            DialogResult dialogResult = frmPassword.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
               string unLockPassword = frmPassword.Password;
               _printer.UnLock(unLockPassword);

               if (IsCurrentPrinterLocked() == false)
               {
                  MessageBox.Show("Printer is unlocked.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               else
                  MessageBox.Show("Incorrect password.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private bool IsCurrentPrinterLocked()
      {
         bool bPrinterLocked = true;

         try
         {
            bPrinterLocked = _printer.IsPrinterLocked();
         }
         catch (PrinterDriverException Ex)
         {
            if (Ex.Code == PrinterDriverExceptionCode.PrinterCannotBeLocked)
            {
               bPrinterLocked = false;
            }
         }

         return bPrinterLocked;
      }

      private void SetDefaultSpecs(Printer printer)
      {
         PrinterSpecifications specs = new PrinterSpecifications();
         specs.DimensionsInInches = true;

         if (PrinterSettings.InstalledPrinters.Count > 0)
            specs.MarginsPrinter = PrinterSettings.InstalledPrinters[0];

         specs.PaperHeight = 11;
         specs.PaperID = 0;
         specs.PaperSizeName = "Custom";
         specs.PaperWidth = 8;
         specs.PortraitOrient = true;
         specs.PrintQuality = -3;
         specs.YResolution = 300;

         printer.Specifications = specs;
      }

      private void SetCurrentPrinter()
      {
         try
         {
            if (_printer != null)
            {
               _printer.Dispose();
            }

            _printer = new Printer(_currentPrinterName);

            _printer.EmfEvent += new EventHandler<EmfEventArgs>(_printer_EmfEvent);

            _printer.JobEvent += new EventHandler<JobEventArgs>(_printer_JobEvent);

            this.Text = "LEADTOOLS C# Printer Demo - Active printer is: " + _currentPrinterName;
         }
         catch (Exception Ex)
         {
            MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      private void DrawStartedPage(Graphics graphics)
      {
         try
         {
            const float leftLocation = 10;
            const float topLocation = 20;
            PointF pointF = new PointF(leftLocation, topLocation);

            string drawingText = "\n   LEADTOOLS Printer Main Demo"
                                 + "\n   ------------------------------------------------------------ "
                                 + "\n   This demo program demonstrates the usage of the LEADTOOLS Printer functionality. "
                                 + "\n   ------------------------------------------------------------ "
                                 + "\n"
                                 + "\n   You can use this demo in one of two ways: "
                                 + "\n"
                                 + "\n   Printing from other applications: "
                                 + "\n   1 - Print from any application to the currently selected printer (see the demo caption for the currently selected printer). "
                                 + "\n   2 - From the main menu, select \"File | Save As\", then save the printed document as PDF, DOC, etc, or as a supported raster format. "
                                 + "\n         You can repeat the save as many times as necessary. "
                                 + "\n"
                                 + "\n   Printing from this application: "
                                 + "\n   1 - From the main menu, select \"File | Print Start Page\", to print the contents of this page. "
                                 + "\n   2 - From the main menu, select \"File | Save As\", then save the printed document as PDF, DOC, etc, or as a supported raster format. "
                                 + "\n         You can repeat the save as many times as necessary. ";

            Font drawingFont = new Font("Times New Roman", 11, FontStyle.Regular);
            Brush brush = Brushes.Blue;
            graphics.DrawString(drawingText, drawingFont, brush, pointF);
         }
         catch { }
      }

      private void DeleteTempFiles()
      {
         foreach (string tempFile in _tempFiles)
         {
            if (File.Exists(tempFile))
               File.Delete(tempFile);
         }
      }
      #endregion

   }
}
