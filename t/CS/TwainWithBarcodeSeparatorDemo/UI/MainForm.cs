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

using Leadtools;
using Leadtools.Twain;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Drawing;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Barcode;

namespace TwainWithBarcodeSeparatorDemo
{
   public partial class MainForm : Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      public MainForm()
      {
         StartUpDialog startDlg = new StartUpDialog();
         if (startDlg.ShowStartUpDialog)
         {
            startDlg.ShowDialog();
         }

         InitializeComponent();

         InitClass();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
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
         this._mainMenu = new System.Windows.Forms.MainMenu(this.components);
         this._menuItemFile = new System.Windows.Forms.MenuItem();
         this._menuItemFileSelectSource = new System.Windows.Forms.MenuItem();
         this._menuItemFileAcuire = new System.Windows.Forms.MenuItem();
         this._menuItemFileExit = new System.Windows.Forms.MenuItem();
         this._menuItemPage = new System.Windows.Forms.MenuItem();
         this._menuItemPageFirst = new System.Windows.Forms.MenuItem();
         this._menuItemPagePrevious = new System.Windows.Forms.MenuItem();
         this._menuItemPageNext = new System.Windows.Forms.MenuItem();
         this._menuItemPageLast = new System.Windows.Forms.MenuItem();
         this._menuItemOptions = new System.Windows.Forms.MenuItem();
         this._menuItemOptionsSetSeparatorString = new System.Windows.Forms.MenuItem();
         this._menuItemOptionsSetResultsPath = new System.Windows.Forms.MenuItem();
         this._menuItemHelp = new System.Windows.Forms.MenuItem();
         this._menuItemHelpAbout = new System.Windows.Forms.MenuItem();
         this._sbMain = new System.Windows.Forms.StatusBar();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile,
            this._menuItemPage,
            this._menuItemOptions,
            this._menuItemHelp});
         // 
         // _menuItemFile
         // 
         this._menuItemFile.Index = 0;
         this._menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFileSelectSource,
            this._menuItemFileAcuire,
            this._menuItemFileExit});
         this._menuItemFile.Text = "&File";
         // 
         // _menuItemFileSelectSource
         // 
         this._menuItemFileSelectSource.Index = 0;
         this._menuItemFileSelectSource.Text = "&Select Source...";
         this._menuItemFileSelectSource.Click += new System.EventHandler(this._menuItemFileSelectSource_Click);
         // 
         // _menuItemFileAcuire
         // 
         this._menuItemFileAcuire.Index = 1;
         this._menuItemFileAcuire.Text = "&Acquire...";
         this._menuItemFileAcuire.Click += new System.EventHandler(this._menuItemFileAcuire_Click);
         // 
         // _menuItemFileExit
         // 
         this._menuItemFileExit.Index = 2;
         this._menuItemFileExit.Text = "E&xit";
         this._menuItemFileExit.Click += new System.EventHandler(this._menuItemFileExit_Click);
         // 
         // _menuItemPage
         // 
         this._menuItemPage.Index = 1;
         this._menuItemPage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemPageFirst,
            this._menuItemPagePrevious,
            this._menuItemPageNext,
            this._menuItemPageLast});
         this._menuItemPage.Text = "&Page";
         // 
         // _menuItemPageFirst
         // 
         this._menuItemPageFirst.Index = 0;
         this._menuItemPageFirst.Text = "&First";
         this._menuItemPageFirst.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPagePrevious
         // 
         this._menuItemPagePrevious.Index = 1;
         this._menuItemPagePrevious.Text = "&Previous";
         this._menuItemPagePrevious.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPageNext
         // 
         this._menuItemPageNext.Index = 2;
         this._menuItemPageNext.Text = "&Next";
         this._menuItemPageNext.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPageLast
         // 
         this._menuItemPageLast.Index = 3;
         this._menuItemPageLast.Text = "&Last";
         this._menuItemPageLast.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemOptions
         // 
         this._menuItemOptions.Index = 2;
         this._menuItemOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemOptionsSetSeparatorString,
            this._menuItemOptionsSetResultsPath});
         this._menuItemOptions.Text = "&Options";
         // 
         // _menuItemOptionsSetSeparatorString
         // 
         this._menuItemOptionsSetSeparatorString.Index = 0;
         this._menuItemOptionsSetSeparatorString.Text = "Set Separator String";
         this._menuItemOptionsSetSeparatorString.Click += new System.EventHandler(this._menuItemOptionsSetSeparatorString_Click);
         // 
         // _menuItemOptionsSetResultsPath
         // 
         this._menuItemOptionsSetResultsPath.Index = 1;
         this._menuItemOptionsSetResultsPath.Text = "Set Results Path";
         this._menuItemOptionsSetResultsPath.Click += new System.EventHandler(this._menuItemOptionsSetResultsPath_Click);
         // 
         // _menuItemHelp
         // 
         this._menuItemHelp.Index = 3;
         this._menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemHelpAbout});
         this._menuItemHelp.Text = "&Help";
         // 
         // _menuItemHelpAbout
         // 
         this._menuItemHelpAbout.Index = 0;
         this._menuItemHelpAbout.Text = "&About...";
         this._menuItemHelpAbout.Click += new System.EventHandler(this._menuItemHelpAbout_Click);
         // 
         // _sbMain
         // 
         this._sbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
         this._sbMain.Location = new System.Drawing.Point(0, 326);
         this._sbMain.Name = "_sbMain";
         this._sbMain.Size = new System.Drawing.Size(558, 22);
         this._sbMain.TabIndex = 2;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(558, 348);
         this.Controls.Add(this._sbMain);
         this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Margin = new System.Windows.Forms.Padding(4);
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_Closed);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _menuItemFile;
      private System.Windows.Forms.MenuItem _menuItemFileExit;
      private System.Windows.Forms.MenuItem _menuItemHelp;
      private System.Windows.Forms.MenuItem _menuItemHelpAbout;
      private System.Windows.Forms.MenuItem _menuItemFileSelectSource;
      private System.Windows.Forms.MenuItem _menuItemFileAcuire;
      SeperatorStringDialog _seperatorStringDlg;
      private ImageViewer _viewer;
      private TwainSession _twnSession = null;
      private RasterCodecs _codecs;

      /*SaveFilesCount variable is used to count the number of files 
      to be saved to the disk when calling the Acquire method*/
      private int _saveFilesCount;

      /*TwainSaveFilePath variable is the twain images save path*/
      private string _twainSaveFilePath;

      /*TwainSaveFileName variable is the name of the current save file*/
      private string _twainSaveFileName;
      private MenuItem _menuItemOptions;
      private MenuItem _menuItemOptionsSetSeparatorString;
      private MenuItem _menuItemOptionsSetResultsPath;
      private MenuItem _menuItemPage;
      private MenuItem _menuItemPageFirst;
      private MenuItem _menuItemPagePrevious;
      private MenuItem _menuItemPageNext;
      private MenuItem _menuItemPageLast;
      private StatusBar _sbMain;

      public TwainTransferMechanism _transferMode = TwainTransferMechanism.Native;

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      private void InitClass()
      {
         Messager.Caption = "LEADTOOLS for .Net C# TwainWithBarcodeSeparator Demo";
         Text = Messager.Caption;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         try
         {
            bool bTwainAvailable = TwainSession.IsAvailable(this.Handle);
            if (bTwainAvailable)
            {
               //Initialize codecs object
               _codecs = new RasterCodecs();

               //Initialize the number of Files to be saved using Twain
               _saveFilesCount = 0; //Variable

               _twainSaveFilePath = Leadtools.Demos.DemosGlobal.ImagesFolder;
               //Set the name of the first file to be saved using Twain 
               _twainSaveFileName = ChangeSaveFileName("");//variable

               //Initialize the twnSession object
               _twnSession = new TwainSession();

               //For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
               //_twnSession.Startup(this.Handle, "LEADTOOLS", "LEADTOOLS for .NET", String.Empty, "TwainWithBarcodeSeparatorDemo", TwainStartupFlags.UseThunkServer);

               //Start the twnSession object
               _twnSession.Startup(this.Handle, "LEADTOOLS", "LEADTOOLS for .NET", String.Empty, "TwainWithBarcodeSeparatorDemo", TwainStartupFlags.None);
               //handle the AcquirePage event
               _twnSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(Twain_AcquirePage);

               _seperatorStringDlg = new SeperatorStringDialog();

               InitViewer();
               UpdateControls();
               UpdateStatusBarText();
            }
            EnableControls(bTwainAvailable);
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
            else
               Messager.ShowError(this, ex);

            EnableControls(false);
         }
      }

      private void InitViewer()
      {
         /*set the properties to control the display of 
               the image on the rasterImageViewer control*/
         _viewer = new ImageViewer();
         RasterPaintProperties props = new RasterPaintProperties();
         props = _viewer.PaintProperties;
         props.PaintDisplayMode = RasterPaintDisplayModeFlags.ScaleToGray | RasterPaintDisplayModeFlags.Resample;
         _viewer.PaintProperties = props;
         _viewer.Dock = DockStyle.Fill;
         this.Controls.Add(_viewer);
         _viewer.BringToFront();
      }

      private void EnableControls(bool bEnable)
      {
         this._menuItemFileSelectSource.Enabled = bEnable;
         this._menuItemFileAcuire.Enabled = bEnable;
         this._menuItemOptions.Enabled = bEnable;
         this._menuItemPage.Enabled = bEnable;
      }

      private void _menuItemFileSelectSource_Click(object sender, EventArgs e)
      {
         try
         {
            //Selct the Twain source
            _twnSession.SelectSource(string.Empty);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }
      }

      private void _menuItemFileAcuire_Click(object sender, EventArgs e)
      {
         if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twnSession.SelectedSourceName()))
            return;

         if (Directory.Exists(_twainSaveFilePath))
         {
            using (WaitCursor cursor = new WaitCursor())
            {
               try
               {
                  if (_viewer.Image != null)
                     _viewer.Image.Dispose();

                  _twainSaveFileName = ChangeSaveFileName(_saveFilesCount.ToString());
                  //Call the Acquire method to start the scanning process
                  if (_twnSession.Acquire(TwainUserInterfaceFlags.Show) != DialogResult.OK)
                     Messager.ShowError(this, "Error Acquiring From Source");
                  else
                  {
                     _saveFilesCount++;
                     _twainSaveFileName = ChangeSaveFileName(_saveFilesCount.ToString());
                  }
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex.Message);
               }
               finally
               {
                  UpdateControls();
                  UpdateStatusBarText();
               }
            }
         }
         else
         {
            Messager.ShowError(this, "Set Results Path please.");
         }
      }

      private void _menuItemOptionsSetSeparatorString_Click(object sender, EventArgs e)
      {
         string seperatorString = _seperatorStringDlg.SeperatorString;
         _seperatorStringDlg.ShowDialog();
      }

      private void _menuItemOptionsSetResultsPath_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog browserDlg = new FolderBrowserDialog();
         browserDlg.SelectedPath = _twainSaveFilePath;

         if (browserDlg.ShowDialog() == DialogResult.OK)
         {
            //Set the Save path of twain images
            _twainSaveFilePath = browserDlg.SelectedPath;
         }
      }

      private void _menuItemPage_Click(object sender, EventArgs e)
      {
         int page = _viewer.Image.Page;
         if (sender == _menuItemPageFirst)
            page = 1;
         else if (sender == _menuItemPagePrevious)
            page--;
         else if (sender == _menuItemPageNext)
            page++;
         else if (sender == _menuItemPageLast)
            page = _viewer.Image.PageCount;

         page = Math.Max(1, Math.Min(_viewer.Image.PageCount, page));

         if (page != _viewer.Image.Page)
         {
            _viewer.Image.Page = page;
            UpdateControls();
            UpdateStatusBarText();
         }
      }

      private void Twain_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         string[] barDataArray = ReadBarcode(e.Image);

         //Check if Barcodes found
         if (barDataArray != null)
            foreach (string barData in barDataArray)
               if (barData != null && barData == _seperatorStringDlg.SeperatorString)
               {
                  //If barData equals "Separator" string, save the image to a sperate file
                  _saveFilesCount++;
                  _twainSaveFileName = ChangeSaveFileName(_saveFilesCount.ToString());
               }

         // Save the scanned images to the TwainSaveFileName file
         _codecs.Save(e.Image,
                     _twainSaveFileName,
                     RasterImageFormat.Tif,
                     e.Image.BitsPerPixel,
                     1,
                     1,
                     1,
                     CodecsSavePageMode.Append);

         //Add the scanned image to the viewer control
         if (_viewer.Image == null || _viewer.Image.PageCount == 0)
            _viewer.Image = e.Image;
         else
            _viewer.Image.AddPage(e.Image);
      }

      private void MainForm_Closed(object sender, FormClosedEventArgs e)
      {
         if (_twnSession != null)
         {
            //Shutdown the twnSession object
            _twnSession.Shutdown();
         }
      }

      // ReadBarcode function search the scanned image  for 1D Code128 barcode
      private string[] ReadBarcode(RasterImage TwainImage)
      {
         _codecs.ThrowExceptionsOnInvalidImages = true;
         BarcodeEngine barEngine;
         string[] strDataArray = null;
         try
         {
            barEngine = new BarcodeEngine();

            // Set the Barcode search rectangle
            LeadRect searchRect = LeadRect.Empty;

            // Read the barcodes using default options
            barEngine.Reader.ErrorMode = BarcodeReaderErrorMode.IgnoreAll;
            BarcodeData[] barcodes = barEngine.Reader.ReadBarcodes(TwainImage, searchRect, 0, new BarcodeSymbology[]{BarcodeSymbology.Code128});

            if (barcodes.Length > 0)
            {
               strDataArray = new string[barcodes.Length];
               for (int nIndex = 0; nIndex < barcodes.Length; nIndex++)
               {
                  strDataArray[nIndex] = barcodes[nIndex].Value;
               }

               return strDataArray;
            }
            else
            {
               return null;
            }
         }
         catch(BarcodeException ex)
         {
            Messager.ShowError(this, ex.Message);
            return null;
         }
      }

      private string ChangeSaveFileName(string str)
      {
         str = _twainSaveFilePath + @"\File" + str;
         str += ".TIF";
         if (File.Exists(str))
            File.Delete(str);
         return str;
      }

      private void UpdateControls()
      {
         // update the menu items
         if (_viewer.Image != null)
         {
            _menuItemPage.Enabled = true;
            _menuItemPage.Visible = true;
            int page = _viewer.Image.Page;
            _menuItemPageFirst.Enabled = (page != 1);
            _menuItemPageFirst.Visible = true;
            _menuItemPagePrevious.Enabled = (page != 1);
            _menuItemPagePrevious.Visible = true;
            _menuItemPageNext.Enabled = (page != _viewer.Image.PageCount);
            _menuItemPageNext.Visible = true;
            _menuItemPageLast.Enabled = (page != _viewer.Image.PageCount);
            _menuItemPageLast.Visible = true;
         }
         else
         {
            _menuItemPage.Enabled = false;
            _menuItemPage.Visible = false;
            _menuItemPageFirst.Enabled = false;
            _menuItemPageFirst.Visible = false;
            _menuItemPagePrevious.Enabled = false;
            _menuItemPagePrevious.Visible = false;
            _menuItemPageNext.Enabled = false;
            _menuItemPageNext.Visible = false;
            _menuItemPageLast.Enabled = false;
            _menuItemPageLast.Visible = false;
         }
      }

      private void UpdateStatusBarText()
      {
         if (_viewer.Image != null)
            _sbMain.Text = string.Format("Page {0}:{1}", _viewer.Image.Page, _viewer.Image.PageCount);
         else
            _sbMain.Text = "Ready";
      }

      private void _menuItemFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _menuItemHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Twain With Barcode Separator", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
   }
}
