// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.WinForms.CommonDialogs.File;


namespace J2KLargeImageSaveDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpenSave;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private Label _lblImageFileName;
      private Label _lblImageDimensions;
      private Label _lblImageBitsPerPixel;
      private Label _lblCurrentRow;
      private Label _lblStatus;
      private Button _btnCancel;
      private Label _lblStatusValue;
      private Label _lblCurrentRowValue;
      private Label _lblImageBitsPerPixelValue;
      private Label _lblDimensionValue;
      private Label _lblFilenameValue;
      private IContainer components;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpenSave = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._lblImageFileName = new System.Windows.Forms.Label();
         this._lblImageDimensions = new System.Windows.Forms.Label();
         this._lblImageBitsPerPixel = new System.Windows.Forms.Label();
         this._lblCurrentRow = new System.Windows.Forms.Label();
         this._lblStatus = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._lblStatusValue = new System.Windows.Forms.Label();
         this._lblCurrentRowValue = new System.Windows.Forms.Label();
         this._lblImageBitsPerPixelValue = new System.Windows.Forms.Label();
         this._lblDimensionValue = new System.Windows.Forms.Label();
         this._lblFilenameValue = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpenSave,
            this._miFileSep1,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileOpenSave
         // 
         this._miFileOpenSave.Index = 0;
         this._miFileOpenSave.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpenSave.Text = "&Open and Save...";
         this._miFileOpenSave.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 1;
         this._miFileSep1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 2;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 1;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _lblImageFileName
         // 
         this._lblImageFileName.AutoSize = true;
         this._lblImageFileName.Location = new System.Drawing.Point(26, 29);
         this._lblImageFileName.Name = "_lblImageFileName";
         this._lblImageFileName.Size = new System.Drawing.Size(92, 13);
         this._lblImageFileName.TabIndex = 0;
         this._lblImageFileName.Text = "Image File Name: ";
         // 
         // _lblImageDimensions
         // 
         this._lblImageDimensions.AutoSize = true;
         this._lblImageDimensions.Location = new System.Drawing.Point(26, 67);
         this._lblImageDimensions.Name = "_lblImageDimensions";
         this._lblImageDimensions.Size = new System.Drawing.Size(99, 13);
         this._lblImageDimensions.TabIndex = 1;
         this._lblImageDimensions.Text = "Image Dimensions: ";
         // 
         // _lblImageBitsPerPixel
         // 
         this._lblImageBitsPerPixel.AutoSize = true;
         this._lblImageBitsPerPixel.Location = new System.Drawing.Point(26, 107);
         this._lblImageBitsPerPixel.Name = "_lblImageBitsPerPixel";
         this._lblImageBitsPerPixel.Size = new System.Drawing.Size(106, 13);
         this._lblImageBitsPerPixel.TabIndex = 2;
         this._lblImageBitsPerPixel.Text = "Image Bits Per Pixel: ";
         // 
         // _lblCurrentRow
         // 
         this._lblCurrentRow.AutoSize = true;
         this._lblCurrentRow.Location = new System.Drawing.Point(26, 148);
         this._lblCurrentRow.Name = "_lblCurrentRow";
         this._lblCurrentRow.Size = new System.Drawing.Size(72, 13);
         this._lblCurrentRow.TabIndex = 3;
         this._lblCurrentRow.Text = "Current Row: ";
         // 
         // _lblStatus
         // 
         this._lblStatus.AutoSize = true;
         this._lblStatus.Location = new System.Drawing.Point(26, 188);
         this._lblStatus.Name = "_lblStatus";
         this._lblStatus.Size = new System.Drawing.Size(43, 13);
         this._lblStatus.TabIndex = 4;
         this._lblStatus.Text = "Status: ";
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(159, 223);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(179, 39);
         this._btnCancel.TabIndex = 5;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _lblStatusValue
         // 
         this._lblStatusValue.AutoSize = true;
         this._lblStatusValue.Location = new System.Drawing.Point(138, 188);
         this._lblStatusValue.Name = "_lblStatusValue";
         this._lblStatusValue.Size = new System.Drawing.Size(22, 13);
         this._lblStatusValue.TabIndex = 10;
         this._lblStatusValue.Text = "NA";
         // 
         // _lblCurrentRowValue
         // 
         this._lblCurrentRowValue.AutoSize = true;
         this._lblCurrentRowValue.Location = new System.Drawing.Point(138, 148);
         this._lblCurrentRowValue.Name = "_lblCurrentRowValue";
         this._lblCurrentRowValue.Size = new System.Drawing.Size(22, 13);
         this._lblCurrentRowValue.TabIndex = 9;
         this._lblCurrentRowValue.Text = "NA";
         // 
         // _lblImageBitsPerPixelValue
         // 
         this._lblImageBitsPerPixelValue.AutoSize = true;
         this._lblImageBitsPerPixelValue.Location = new System.Drawing.Point(138, 107);
         this._lblImageBitsPerPixelValue.Name = "_lblImageBitsPerPixelValue";
         this._lblImageBitsPerPixelValue.Size = new System.Drawing.Size(22, 13);
         this._lblImageBitsPerPixelValue.TabIndex = 8;
         this._lblImageBitsPerPixelValue.Text = "NA";
         // 
         // _lblDimensionValue
         // 
         this._lblDimensionValue.AutoSize = true;
         this._lblDimensionValue.Location = new System.Drawing.Point(138, 67);
         this._lblDimensionValue.Name = "_lblDimensionValue";
         this._lblDimensionValue.Size = new System.Drawing.Size(22, 13);
         this._lblDimensionValue.TabIndex = 7;
         this._lblDimensionValue.Text = "NA";
         // 
         // _lblFilenameValue
         // 
         this._lblFilenameValue.AutoSize = true;
         this._lblFilenameValue.Location = new System.Drawing.Point(138, 29);
         this._lblFilenameValue.Name = "_lblFilenameValue";
         this._lblFilenameValue.Size = new System.Drawing.Size(22, 13);
         this._lblFilenameValue.TabIndex = 6;
         this._lblFilenameValue.Text = "NA";
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(528, 269);
         this.Controls.Add(this._lblStatusValue);
         this.Controls.Add(this._lblCurrentRowValue);
         this.Controls.Add(this._lblImageBitsPerPixelValue);
         this.Controls.Add(this._lblDimensionValue);
         this.Controls.Add(this._lblFilenameValue);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._lblStatus);
         this.Controls.Add(this._lblCurrentRow);
         this.Controls.Add(this._lblImageBitsPerPixel);
         this.Controls.Add(this._lblImageDimensions);
         this.Controls.Add(this._lblImageFileName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "J2KLargeImageSave Demo";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.Run(new MainForm());
      }

      private bool bCompressing = false;
      private bool bCancel = false;
      private FileStream outputFile = null;
      private int bytesPerLine = 0;

      /// <summary>
      /// Initialize the Application.
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Messager.Caption = "C# J2KLargeImageSave Demo";
         Text = Messager.Caption;

         UpdateMyControls();
      }

      /// <summary>
      /// Update the UI depending on the program state
      /// </summary>
      private void UpdateMyControls()
      {
         _btnCancel.Enabled = bCompressing;
         _miFileOpenSave.Enabled = !bCompressing;
      }

      /// <summary>
      /// Load a new image
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         RasterCodecs _codecs = null;
         CodecsImageInfo imageInfo = null;
         try
         {
            // initialize the codecs object.
            _codecs = new RasterCodecs();
            // Since we are dealing with large images, we do not want to allocate the entire image. We are only going to load it row by row
            _codecs.Options.Load.AllocateImage = false;
            _codecs.Options.Load.StoreDataInImage = false;
            _codecs.LoadImage += new EventHandler<CodecsLoadImageEventArgs>(codecs_LoadImage);

            // load the image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open File";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               //Check if image is valid for this demo
               imageInfo = _codecs.GetInformation(openFileDialog.FileName, false);
               if (!IsImageValid(imageInfo))
               {
                  Messager.ShowError(this, "The input image has to be 8-bit Gray scale, 12-bit Gray scale, 16-bit Gray scale, RGB (color), and TopLeft view perspective." +
                    " This DEMO is not meant to be used with small or palletized images (like GIF, PNG, or 1-bit images)." +
                    " Use this DEMO to save large dimension images efficiently using JPEG2000 compression.");
                  return;
               }

               using (RasterSaveDialog saveDialog = new RasterSaveDialog(_codecs))
               {
                  saveDialog.AutoProcess = false;
                  saveDialog.Title = "Save As";
                  saveDialog.ShowFileOptionsBasicJ2kOptions = true;
                  saveDialog.ShowFileOptionsJ2kOptions = true;
                  saveDialog.ShowOptions = true;
                  saveDialog.ShowQualityFactor = true;
                  saveDialog.ShowFileOptionsProgressive = true;
                  saveDialog.ShowFileOptionsStamp = true;
                  saveDialog.QualityFactor = 20;
                  SetupFormats(saveDialog);

                  if (saveDialog.ShowDialog(this) != DialogResult.OK)
                     return;

                  _lblFilenameValue.Text = Path.GetFileName(openFileDialog.FileName);
                  _lblDimensionValue.Text = String.Format("{0} x {1}", imageInfo.Width, imageInfo.Height);
                  _lblImageBitsPerPixelValue.Text = imageInfo.BitsPerPixel.ToString();

                  //Get the selected compression type
                  CodecsCompression selectedCompression;
                  if (saveDialog.Format == RasterImageFormat.J2k)
                     selectedCompression = CodecsCompression.J2k;
                  else
                     selectedCompression = CodecsCompression.Jp2;

                  RasterByteOrder rasterByteOrder = ((saveDialog.BitsPerPixel == 12) || (saveDialog.BitsPerPixel == 16)) ? RasterByteOrder.Gray : RasterByteOrder.Bgr;
                  CodecsLoadByteOrder codecsLoadByteOrder = ((saveDialog.BitsPerPixel == 12) || (saveDialog.BitsPerPixel == 16)) ? CodecsLoadByteOrder.Gray : CodecsLoadByteOrder.Bgr;
                  bytesPerLine = CalculateBytesPerLine(saveDialog.BitsPerPixel, imageInfo.Width);

                  _codecs.Options.Jpeg.Save.QualityFactor = saveDialog.QualityFactor;
                  _codecs.Options.Jpeg.Save.Passes = saveDialog.Passes;

                  _codecs.Options.Jpeg.Save.SaveWithStamp = saveDialog.WithStamp;
                  _codecs.Options.Jpeg.Save.StampWidth = saveDialog.StampWidth;
                  _codecs.Options.Jpeg.Save.StampHeight = saveDialog.StampHeight;
                  _codecs.Options.Jpeg.Save.StampBitsPerPixel = saveDialog.StampBitsPerPixel;

                  _codecs.Options.Jpeg2000.Save.CompressionControl = saveDialog.FileJ2kOptions.CompressionControl;
                  _codecs.Options.Jpeg2000.Save.CompressionRatio = saveDialog.FileJ2kOptions.CompressionRatio;
                  _codecs.Options.Jpeg2000.Save.DecompositionLevels = saveDialog.FileJ2kOptions.DecompositionLevels;
                  _codecs.Options.Jpeg2000.Save.DerivedQuantization = saveDialog.FileJ2kOptions.DerivedQuantization;
                  _codecs.Options.Jpeg2000.Save.ImageAreaHorizontalOffset = saveDialog.FileJ2kOptions.ImageAreaHorizontalOffset;
                  _codecs.Options.Jpeg2000.Save.ImageAreaVerticalOffset = saveDialog.FileJ2kOptions.ImageAreaVerticalOffset;
                  _codecs.Options.Jpeg2000.Save.ProgressingOrder = saveDialog.FileJ2kOptions.ProgressingOrder;
                  _codecs.Options.Jpeg2000.Save.ReferenceTileHeight = saveDialog.FileJ2kOptions.ReferenceTileHeight;
                  _codecs.Options.Jpeg2000.Save.ReferenceTileWidth = saveDialog.FileJ2kOptions.ReferenceTileWidth;
                  _codecs.Options.Jpeg2000.Save.RegionOfInterest = saveDialog.FileJ2kOptions.RegionOfInterest;
                  _codecs.Options.Jpeg2000.Save.RegionOfInterestRectangle = saveDialog.FileJ2kOptions.RegionOfInterestRectangle;
                  _codecs.Options.Jpeg2000.Save.RegionOfInterestWeight = saveDialog.FileJ2kOptions.RegionOfInterestWeight;
                  _codecs.Options.Jpeg2000.Save.TargetFileSize = saveDialog.FileJ2kOptions.TargetFileSize;
                  _codecs.Options.Jpeg2000.Save.TileHorizontalOffset = saveDialog.FileJ2kOptions.TileHorizontalOffset;
                  _codecs.Options.Jpeg2000.Save.TileVerticalOffset = saveDialog.FileJ2kOptions.TileVerticalOffset;
                  _codecs.Options.Jpeg2000.Save.UseColorTransform = saveDialog.FileJ2kOptions.UseColorTransform;
                  _codecs.Options.Jpeg2000.Save.UseEphMarker = saveDialog.FileJ2kOptions.UseEphMarker;
                  _codecs.Options.Jpeg2000.Save.UseRegionOfInterest = saveDialog.FileJ2kOptions.UseRegionOfInterest;
                  _codecs.Options.Jpeg2000.Save.UseSopMarker = saveDialog.FileJ2kOptions.UseSopMarker;

                  bCancel = false;
                  bCompressing = true;
                  UpdateMyControls();

                  //Start Compressing
                  using (outputFile = File.Create(saveDialog.FileName))
                  {
                     _codecs.StartCompress(imageInfo.Width, imageInfo.Height, saveDialog.BitsPerPixel, rasterByteOrder, RasterViewPerspective.TopLeft, bytesPerLine, IntPtr.Zero, 0, selectedCompression, MyCodecsCompressDataCallback);
                     _codecs.Load(openFileDialog.FileName, saveDialog.BitsPerPixel, codecsLoadByteOrder, 1, 1);
                     _codecs.StopCompress();

                     _lblStatusValue.Text = bCancel ? "Aborted" : "Complete";
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            _lblStatusValue.Text = "Error";
         }
         finally
         {
            if (_codecs != null)
               _codecs.Dispose();

            if (imageInfo != null)
               imageInfo.Dispose();
            bCompressing = false;
            UpdateMyControls();
         }
      }

      int CalculateBytesPerLine(int bitsPerPixel, int imageWidth)
      {
         int bitsPerLine = bitsPerPixel * imageWidth;
         double bytesPerLine = bitsPerLine / 8;

         //Round up to nearest multiple of 4
         return (int)Math.Ceiling(bytesPerLine / 4.0) * 4;
      }

      /// <summary>
      /// Load Image callback. This is called as the image is decompressed
      /// </summary>
      void codecs_LoadImage(object sender, CodecsLoadImageEventArgs e)
      {
         IntPtr lineBuffer = e.Buffer.Data;
         for (int i = 0; i < e.Lines; i++)
         {
            if (bCancel)
            {
               e.Cancel = true;
               return;
            }

            try
            {
               RasterCodecs _codecs = (RasterCodecs)sender;
               _codecs.Compress(lineBuffer);
               lineBuffer = new IntPtr(lineBuffer.ToInt64() + bytesPerLine);
               UpdateStatus(e.Row, e.TotalPercent);
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex.Message);
               e.Cancel = true;
               return;
            }

            Application.DoEvents();
         }
      }

      /// <summary>
      /// Called when compressed data is available
      /// </summary>
      bool MyCodecsCompressDataCallback(int width, int height, int bitsPerPixel, RasterByteOrder order, RasterViewPerspective viewPerspective, RasterNativeBuffer buffer)
      {
         // Write compressed data to the file 
         byte[] dataBuffer = new byte[(int)buffer.Length];
         Marshal.Copy(buffer.Data, dataBuffer, 0, (int)buffer.Length);
         outputFile.Write(dataBuffer, 0, (int)buffer.Length);

         return true;
      }

      /// <summary>
      /// Cancel Save Process
      /// </summary>
      private void _btnCancel_Click(object sender, EventArgs e)
      {
         bCancel = true;
      }

      void UpdateStatus(int currentRow, int currentProgress)
      {
         _lblCurrentRowValue.Text = (currentRow +1).ToString();
         _lblStatusValue.Text = String.Format("{0} %", currentProgress);
      }

      /// <summary>
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (bCompressing)
         {
            if (Messager.Show(this, "Would you like to cancel the current operation?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) == DialogResult.No)
            {
               e.Cancel = true;
               return;
            }
            else
               _btnCancel_Click(this, null);
         }
      }

      /// <summary>
      /// show the about dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("J2KLargeImageSave Demo", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private bool IsImageValid(CodecsImageInfo imageInfo)
      {
         bool imageValid = false;

         switch (imageInfo.BitsPerPixel)
         {
            case 32:
            case 24:
            case 16:
            case 12:
            case 8:
               imageValid = true;
               break;
            default:
               imageValid = false;
               break;
         }

         return (imageValid && imageInfo.ViewPerspective == RasterViewPerspective.TopLeft);
      }

      void SetupFormats(RasterSaveDialog saveDialog)
      {
         saveDialog.FileFormatsList = new Leadtools.WinForms.CommonDialogs.File.RasterSaveDialogFileFormatsList(Leadtools.WinForms.CommonDialogs.File.RasterDialogFileFormatDataContent.User);
         saveDialog.FileFormatsList.Add(RasterDialogFileTypesIndex.Jpeg2000, RasterDialogBitsPerPixelDataContent.User);

         int[] saveBBP = new int[] { 8, 12, 16, 24, 32 };
         for (int i = 0; i < saveBBP.Length; i++)
         {
            saveDialog.FileFormatsList[0].BitsPerPixelList.Add(RasterDialogFileTypesIndex.Jpeg2000, saveBBP[i], RasterDialogFileSubTypeDataContent.User);
            saveDialog.FileFormatsList[0].BitsPerPixelList[i].SubFormatsList.Add(RasterDialogFileTypesIndex.Jpeg2000, saveBBP[i], (int)RasterDialogJ2kSubTypesIndex.Jpeg2000File);
            saveDialog.FileFormatsList[0].BitsPerPixelList[i].SubFormatsList.Add(RasterDialogFileTypesIndex.Jpeg2000, saveBBP[i], (int)RasterDialogJ2kSubTypesIndex.Jpeg2000Stream);
         }
      }
   }
}
