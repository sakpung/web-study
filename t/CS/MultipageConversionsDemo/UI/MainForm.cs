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
using Leadtools.Codecs;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using System.Security.Permissions;

namespace MultipageConversions
{
   public class MainForm : Form
   {
      private System.Windows.Forms.MenuStrip menuMain;
      private System.Windows.Forms.ToolStripMenuItem _mnuOptions;
      private System.Windows.Forms.ToolStripMenuItem _mnuHelp;
      private System.Windows.Forms.ToolStripMenuItem _mnuFileExit;
      private System.Windows.Forms.ToolStripMenuItem _mnuHelpAbout;
      private System.Windows.Forms.ToolStripMenuItem _mnuFileLoadTifFiles;
      private System.Windows.Forms.ToolStripMenuItem _mnuFileSave;
      private System.Windows.Forms.ToolStripMenuItem _mnuOptionsSingleRasterImage;
      private System.Windows.Forms.ToolStripMenuItem _mnuOptionsOnePageAtTime;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label _labelLoadedFiles;
      private System.Windows.Forms.Label _labelConverted;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ToolStripMenuItem _mnuFile;

      private RasterCodecs _codecs;
      SaveFileDialog _saveDialog;
      ImageFileLoader _loader;
      private string _szMultiPageFile;
      List<ImageInformation> _lstImagesInfoMulti = null;
      private System.ComponentModel.IContainer components = null;

      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      public MainForm()
      {
         InitializeComponent();
         InitClass();
      }

      private void InitClass()
      {
         Messager.Caption = "LEADTOOLS for .NET C# Multipage Conversions";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();
         _saveDialog = new SaveFileDialog();
         _saveDialog.Filter = "Tiff Files (*.tif)|*.tif|Pdf Files (*.pdf)|*.pdf";
         if (Directory.Exists(DemosGlobal.ImagesFolder))
            _saveDialog.InitialDirectory = DemosGlobal.ImagesFolder;
         
         _mnuFileSave.Enabled = false;
      }

      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mnuFile = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuFileLoadTifFiles = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this.menuMain = new System.Windows.Forms.MenuStrip();
         this._mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOptionsSingleRasterImage = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOptionsOnePageAtTime = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this.label2 = new System.Windows.Forms.Label();
         this._labelLoadedFiles = new System.Windows.Forms.Label();
         this._labelConverted = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this.menuMain.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mnuFile
         // 
         this._mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuFileLoadTifFiles,
            this._mnuFileSave,
            this._mnuFileExit});
         this._mnuFile.Name = "_mnuFile";
         this._mnuFile.Size = new System.Drawing.Size(37, 20);
         this._mnuFile.Text = "&File";
         // 
         // _mnuFileLoadTifFiles
         // 
         this._mnuFileLoadTifFiles.Name = "_mnuFileLoadTifFiles";
         this._mnuFileLoadTifFiles.Size = new System.Drawing.Size(143, 22);
         this._mnuFileLoadTifFiles.Text = "&Load Tif Files";
         this._mnuFileLoadTifFiles.Click += new System.EventHandler(this._mnuFileLoadTifFiles_Click);
         // 
         // _mnuFileSave
         // 
         this._mnuFileSave.Name = "_mnuFileSave";
         this._mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this._mnuFileSave.Size = new System.Drawing.Size(143, 22);
         this._mnuFileSave.Text = "&Save";
         this._mnuFileSave.Click += new System.EventHandler(this._mnuFileSave_Click);
         // 
         // _mnuFileExit
         // 
         this._mnuFileExit.Name = "_mnuFileExit";
         this._mnuFileExit.Size = new System.Drawing.Size(143, 22);
         this._mnuFileExit.Text = "E&xit";
         this._mnuFileExit.Click += new System.EventHandler(this._mnuFileExit_Click);
         // 
         // menuMain
         // 
         this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuFile,
            this._mnuOptions,
            this._mnuHelp});
         this.menuMain.Location = new System.Drawing.Point(0, 0);
         this.menuMain.Name = "menuMain";
         this.menuMain.Size = new System.Drawing.Size(586, 24);
         this.menuMain.TabIndex = 4;
         // 
         // _mnuOptions
         // 
         this._mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuOptionsSingleRasterImage,
            this._mnuOptionsOnePageAtTime});
         this._mnuOptions.Name = "_mnuOptions";
         this._mnuOptions.Size = new System.Drawing.Size(61, 20);
         this._mnuOptions.Text = "&Options";
         // 
         // _mnuOptionsSingleRasterImage
         // 
         this._mnuOptionsSingleRasterImage.Checked = true;
         this._mnuOptionsSingleRasterImage.CheckState = System.Windows.Forms.CheckState.Checked;
         this._mnuOptionsSingleRasterImage.Name = "_mnuOptionsSingleRasterImage";
         this._mnuOptionsSingleRasterImage.Size = new System.Drawing.Size(174, 22);
         this._mnuOptionsSingleRasterImage.Text = "Single RasterImage";
         this._mnuOptionsSingleRasterImage.Click += new System.EventHandler(this._mnuOptionsSingleRasterImage_Click);
         // 
         // _mnuOptionsOnePageAtTime
         // 
         this._mnuOptionsOnePageAtTime.Name = "_mnuOptionsOnePageAtTime";
         this._mnuOptionsOnePageAtTime.Size = new System.Drawing.Size(174, 22);
         this._mnuOptionsOnePageAtTime.Text = "One Page At time";
         this._mnuOptionsOnePageAtTime.Click += new System.EventHandler(this._mnuOptionsOnePageAtTime_Click);
         // 
         // _mnuHelp
         // 
         this._mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuHelpAbout});
         this._mnuHelp.Name = "_mnuHelp";
         this._mnuHelp.Size = new System.Drawing.Size(44, 20);
         this._mnuHelp.Text = "&Help";
         // 
         // _mnuHelpAbout
         // 
         this._mnuHelpAbout.Name = "_mnuHelpAbout";
         this._mnuHelpAbout.Size = new System.Drawing.Size(107, 22);
         this._mnuHelpAbout.Text = "&About";
         this._mnuHelpAbout.Click += new System.EventHandler(this._mnuHelpAbout_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 314);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(127, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "Number Of Loaded Files :";
         // 
         // _labelLoadedFiles
         // 
         this._labelLoadedFiles.AutoSize = true;
         this._labelLoadedFiles.Location = new System.Drawing.Point(145, 314);
         this._labelLoadedFiles.Name = "_labelLoadedFiles";
         this._labelLoadedFiles.Size = new System.Drawing.Size(13, 13);
         this._labelLoadedFiles.TabIndex = 7;
         this._labelLoadedFiles.Text = "0";
         // 
         // _labelConverted
         // 
         this._labelConverted.AutoSize = true;
         this._labelConverted.Location = new System.Drawing.Point(347, 314);
         this._labelConverted.Name = "_labelConverted";
         this._labelConverted.Size = new System.Drawing.Size(13, 13);
         this._labelConverted.TabIndex = 9;
         this._labelConverted.Text = "0";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(255, 314);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(86, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Converted Files :";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 38);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(549, 185);
         this.groupBox1.TabIndex = 10;
         this.groupBox1.TabStop = false;
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(15, 34);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(510, 130);
         this.label1.TabIndex = 6;
         this.label1.Text = resources.GetString("label1.Text");
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(586, 336);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._labelConverted);
         this.Controls.Add(this.label5);
         this.Controls.Add(this._labelLoadedFiles);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.menuMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuMain;
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "MultipageConversions";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.menuMain.ResumeLayout(false);
         this.menuMain.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {

      }

      private List<ImageInformation> LoadImages(bool bMultiSelect)
      {
         try
         {
            bool bSetInitialPath = false;
            if (_loader == null)
               bSetInitialPath = true;

            _loader = new ImageFileLoader();
            _loader.ShowLoadPagesDialog = false;

            if (bSetInitialPath)
            if (Directory.Exists(DemosGlobal.ImagesFolder))
               _loader.OpenDialogInitialPath = DemosGlobal.ImagesFolder;

            _loader.MultiSelect = bMultiSelect;
            RasterOpenDialogLoadFormat[] filters = { new RasterOpenDialogLoadFormat("Tiff", "*.tif;*.tiff") };
            _loader.Filters = filters;
            _loader.Images.Clear();
            int filesCount = _loader.Load(this, _codecs, true);
            if (filesCount > 0)
            {
               for (int i = 0; i < _loader.Images.Count; i++)
               {
                  if (_loader.Images[i].Image != null)
                     _loader.Images[i].Image.Dispose();
               }

               return _loader.Images;               
            }            
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, _loader.FileName, ex);
         }

         return null;
      }

      private void EnableControls(bool bEnable)
      {
          _mnuFile.Enabled = bEnable;
         _mnuOptions.Enabled = bEnable;
      }

      private void _mnuFileExit_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void _mnuFileLoadTifFiles_Click(object sender, EventArgs e)
      {
         Cursor cursor = null;
         try
         {
            cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            EnableControls(false);

            _lstImagesInfoMulti = LoadImages(true);

            if (_lstImagesInfoMulti != null)
            {
               this._labelLoadedFiles.Text = _lstImagesInfoMulti.Count.ToString();
               _mnuFileSave.Enabled = true;
               this._labelConverted.Text = "0";
            }
            else
            {
               this._labelLoadedFiles.Text = "0";
               this._labelConverted.Text = "0";
               _mnuFileSave.Enabled = false;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            EnableControls(true);
            this.Cursor = cursor;
         }
      }

      private void _mnuFileSave_Click(object sender, EventArgs e)
      {
         if (_lstImagesInfoMulti == null || _lstImagesInfoMulti.Count <= 0)
         {
            Messager.ShowError(this, "Please Load Files");
            return;
         }

         RasterImage img = null;
         Cursor cursor = this.Cursor;

         try
         {
            cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            EnableControls(false);

            this._labelConverted.Text = "0";

            if (_saveDialog.ShowDialog() == DialogResult.OK)
            {
               RasterImageFormat selectedformat = RasterImageFormat.CcittGroup4;
               if (_saveDialog.FilterIndex == 2)
                  selectedformat = RasterImageFormat.RasPdfG4;

               _szMultiPageFile = _saveDialog.FileName;
               if (_mnuOptionsSingleRasterImage.Checked)
               {
                  for (int i = 0; i < _lstImagesInfoMulti.Count; i++)
                  {
                     RasterImage loadedImage = _codecs.Load(_lstImagesInfoMulti[i].Name, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, 1, -1);
                     if (i == 0)
                        img = loadedImage;
                     else
                        img.AddPages(loadedImage, 1, -1);

                     _labelConverted.Text=(Convert.ToInt32(_labelConverted.Text) + 1).ToString();
                     Application.DoEvents();
                  }

                  _codecs.Save(img, _szMultiPageFile, selectedformat, 0);

                  img.Dispose();
               }
               else
               {
                  for (int i = 0; i < _lstImagesInfoMulti.Count; i++)
                  {
                     CodecsImageInfo info = _codecs.GetInformation(_lstImagesInfoMulti[i].Name, true);
                     for (int j = 1; j <= info.TotalPages; j++)
                     {
                        
                        img = _codecs.Load(_lstImagesInfoMulti[i].Name, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, j, j);
                        if (i == 0 && j == 1)
                        {
                           _codecs.Save(img, _szMultiPageFile, selectedformat, 0, 1, 1, 1, CodecsSavePageMode.Overwrite);
                        }
                        else
                        {
                              while(!ReadyToAccess(_szMultiPageFile))//Insure File is not inused by other processes
                                 Application.DoEvents();

                              _codecs.Save(img, _szMultiPageFile, selectedformat, 0, 1, 1, -1, CodecsSavePageMode.Append);                      
                        }

                        img.Dispose();
                        Application.DoEvents();
                     }
                     _labelConverted.Text = (Convert.ToInt32(_labelConverted.Text) + 1).ToString();
                     info.Dispose();
                     Application.DoEvents();
                  }
               }

               Messager.ShowInformation(this, "Save in MultiPageFile Done");
            }            
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            this.Cursor = cursor;
            EnableControls(true);
         }
      }

      private bool ReadyToAccess(string szFileName)
      {
         try
         {
            using (Stream stream = File.OpenWrite(szFileName))
            { 
            }
            return true;
         }
         catch 
         {
            return false;
         }        
      }
      
      private void _mnuOptionsSingleRasterImage_Click(object sender, EventArgs e)
      {
         _mnuOptionsSingleRasterImage.Checked = true;
         _mnuOptionsOnePageAtTime.Checked = false;
      }

      private void _mnuOptionsOnePageAtTime_Click(object sender, EventArgs e)
      {
         _mnuOptionsOnePageAtTime.Checked = true;
         _mnuOptionsSingleRasterImage.Checked = false;
      }

      private void _mnuHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("MultipageConversions", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
   }
}
