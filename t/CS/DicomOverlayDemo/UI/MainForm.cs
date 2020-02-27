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
using Leadtools.Dicom;
using Leadtools;
using Leadtools.Controls;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using System.IO;

namespace DicomOverlay
{
   public class MainForm : Form
   {
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.SplitContainer m_splitContainer;
      private System.Windows.Forms.ToolStripMenuItem _mnuFile;
      private System.Windows.Forms.ToolStripMenuItem _mnuFileOpen;
      private System.Windows.Forms.ToolStripMenuItem _mnuFileSave;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem _mnuFileExit;
      private System.Windows.Forms.ToolStripMenuItem _mnuOverlays;
      private System.Windows.Forms.ToolStripMenuItem _mnuOverlaysShowOverlay;
      private System.Windows.Forms.ToolStripMenuItem _mnuOverlaysChangeOverlayColor;
      private System.Windows.Forms.ToolStripMenuItem _mnuOverlaysSaveOverlay;
      private System.Windows.Forms.ToolStripMenuItem _mnuOverlaysShowOverlayAttributes;
      private System.Windows.Forms.ToolStripMenuItem _mnuOverlaysInsertOverlay;
      private System.Windows.Forms.ToolStripMenuItem _mnuHelp;
      private System.Windows.Forms.ToolStripMenuItem _mnuHelpAboutOverlay;

      private DicomElement _PixelElement;
      private DicomDataSet _DataSet;
      private Color _overlayColor = Color.White;
      private ImageViewer _rasterImageViewer;
      private ImageViewer _rasterImageList;
      private string _openInitialPath = string.Empty;

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      private System.ComponentModel.IContainer components = null;

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

      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this._mnuFile = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this._mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOverlays = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOverlaysShowOverlay = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOverlaysChangeOverlayColor = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOverlaysSaveOverlay = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOverlaysShowOverlayAttributes = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuOverlaysInsertOverlay = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._mnuHelpAboutOverlay = new System.Windows.Forms.ToolStripMenuItem();
         this.m_splitContainer = new System.Windows.Forms.SplitContainer();
         this.menuStrip1.SuspendLayout();
         this.m_splitContainer.SuspendLayout();
         this.SuspendLayout();
         // 
         // statusStrip1
         // 
         this.statusStrip1.Location = new System.Drawing.Point(0, 562);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(911, 22);
         this.statusStrip1.TabIndex = 0;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuFile,
            this._mnuOverlays,
            this._mnuHelp});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(911, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // _mnuFile
         // 
         this._mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuFileOpen,
            this._mnuFileSave,
            this.toolStripMenuItem1,
            this._mnuFileExit});
         this._mnuFile.Name = "_mnuFile";
         this._mnuFile.Size = new System.Drawing.Size(37, 20);
         this._mnuFile.Text = "&File";
         // 
         // _mnuFileOpen
         // 
         this._mnuFileOpen.Name = "_mnuFileOpen";
         this._mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._mnuFileOpen.Size = new System.Drawing.Size(146, 22);
         this._mnuFileOpen.Text = "&Open";
         this._mnuFileOpen.Click += new System.EventHandler(this._mnuFileOpen_Click);
         // 
         // _mnuFileSave
         // 
         this._mnuFileSave.Name = "_mnuFileSave";
         this._mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this._mnuFileSave.Size = new System.Drawing.Size(146, 22);
         this._mnuFileSave.Text = "&Save";
         this._mnuFileSave.Click += new System.EventHandler(this._mnuFileSave_Click);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
         // 
         // _mnuFileExit
         // 
         this._mnuFileExit.Name = "_mnuFileExit";
         this._mnuFileExit.Size = new System.Drawing.Size(146, 22);
         this._mnuFileExit.Text = "E&xit";
         this._mnuFileExit.Click += new System.EventHandler(this._mnuFileExit_Click);
         // 
         // _mnuOverlays
         // 
         this._mnuOverlays.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuOverlaysShowOverlay,
            this._mnuOverlaysChangeOverlayColor,
            this._mnuOverlaysSaveOverlay,
            this._mnuOverlaysShowOverlayAttributes,
            this._mnuOverlaysInsertOverlay});
         this._mnuOverlays.Name = "_mnuOverlays";
         this._mnuOverlays.Size = new System.Drawing.Size(64, 20);
         this._mnuOverlays.Text = "&Overlays";
         // 
         // _mnuOverlaysShowOverlay
         // 
         this._mnuOverlaysShowOverlay.Name = "_mnuOverlaysShowOverlay";
         this._mnuOverlaysShowOverlay.Size = new System.Drawing.Size(201, 22);
         this._mnuOverlaysShowOverlay.Text = "&Show Overlay";
         this._mnuOverlaysShowOverlay.CheckedChanged += new System.EventHandler(this._mnuOverlaysShowOverlay_CheckedChanged);
         this._mnuOverlaysShowOverlay.Click += new System.EventHandler(this._mnuOverlaysShowOverlay_Click);
         // 
         // _mnuOverlaysChangeOverlayColor
         // 
         this._mnuOverlaysChangeOverlayColor.Name = "_mnuOverlaysChangeOverlayColor";
         this._mnuOverlaysChangeOverlayColor.Size = new System.Drawing.Size(201, 22);
         this._mnuOverlaysChangeOverlayColor.Text = "Change Overlay &Color";
         this._mnuOverlaysChangeOverlayColor.Click += new System.EventHandler(this._mnuOverlaysChangeOverlayColor_Click);
         // 
         // _mnuOverlaysSaveOverlay
         // 
         this._mnuOverlaysSaveOverlay.Name = "_mnuOverlaysSaveOverlay";
         this._mnuOverlaysSaveOverlay.Size = new System.Drawing.Size(201, 22);
         this._mnuOverlaysSaveOverlay.Text = "&Save Overlay";
         this._mnuOverlaysSaveOverlay.Click += new System.EventHandler(this._mnuOverlaysSaveOverlay_Click);
         // 
         // _mnuOverlaysShowOverlayAttributes
         // 
         this._mnuOverlaysShowOverlayAttributes.Name = "_mnuOverlaysShowOverlayAttributes";
         this._mnuOverlaysShowOverlayAttributes.Size = new System.Drawing.Size(201, 22);
         this._mnuOverlaysShowOverlayAttributes.Text = "Show Overlay A&ttributes";
         this._mnuOverlaysShowOverlayAttributes.Click += new System.EventHandler(this._mnuOverlaysShowOverlayAttributes_Click);
         // 
         // _mnuOverlaysInsertOverlay
         // 
         this._mnuOverlaysInsertOverlay.Name = "_mnuOverlaysInsertOverlay";
         this._mnuOverlaysInsertOverlay.Size = new System.Drawing.Size(201, 22);
         this._mnuOverlaysInsertOverlay.Text = "&Insert Overlay";
         this._mnuOverlaysInsertOverlay.Click += new System.EventHandler(this._mnuOverlaysInsertOverlay_Click);
         // 
         // _mnuHelp
         // 
         this._mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuHelpAboutOverlay});
         this._mnuHelp.Name = "_mnuHelp";
         this._mnuHelp.Size = new System.Drawing.Size(44, 20);
         this._mnuHelp.Text = "&Help";
         // 
         // _mnuHelpAboutOverlay
         // 
         this._mnuHelpAboutOverlay.Name = "_mnuHelpAboutOverlay";
         this._mnuHelpAboutOverlay.Size = new System.Drawing.Size(159, 22);
         this._mnuHelpAboutOverlay.Text = "&About Overlay...";
         this._mnuHelpAboutOverlay.Click += new System.EventHandler(this._mnuHelpAboutOverlay_Click);
         // 
         // m_splitContainer
         // 
         this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.m_splitContainer.Location = new System.Drawing.Point(0, 24);
         this.m_splitContainer.Name = "m_splitContainer";
         this.m_splitContainer.Size = new System.Drawing.Size(911, 538);
         this.m_splitContainer.SplitterDistance = 165;
         this.m_splitContainer.TabIndex = 2;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(911, 584);
         this.Controls.Add(this.m_splitContainer);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.Text = "DICOM Overlay Demo";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.m_splitContainer.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      public MainForm()
      {
         InitializeComponent();
         InitClass();
         InitControls();
         _mnuOverlaysShowOverlay.Checked = true;

         if (File.Exists(Path.Combine(DemosGlobal.ImagesFolder, "Overlay.dcm")))
            OpenDataset(Path.Combine(DemosGlobal.ImagesFolder, "Overlay.dcm"));
      }

      private void InitClass()
      {
         DicomEngine.Startup();
         Messager.Caption = "LEADTOOLS for .NET C# DICOM Overlay";
         Text = Messager.Caption;
         _DataSet = new DicomDataSet();
      }

      private void InitControls()
      {
         this._rasterImageList = new ImageViewer(new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 });
         this._rasterImageViewer = new ImageViewer();

         this._rasterImageList.BackColor = System.Drawing.SystemColors.Control;
         this._rasterImageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
         this._rasterImageList.ItemBorderThickness = 2;
         this._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._rasterImageList.Dock = System.Windows.Forms.DockStyle.Left;
         this._rasterImageList.ItemSize = new Leadtools.LeadSize(160, 160);
         this._rasterImageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this._rasterImageList.Location = new System.Drawing.Point(0, 93);
         this._rasterImageList.Name = "_imageList";
         this._rasterImageList.Size = new System.Drawing.Size(197, 475);
         this._rasterImageList.TabIndex = 11;
         this._rasterImageList.SelectedItemsChanged += new EventHandler(_rasterImageList_SelectedItemsChanged);
         this.m_splitContainer.Panel1.Controls.Add(this._rasterImageList);

         this._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._rasterImageViewer.Location = new System.Drawing.Point(0, 0);
         this._rasterImageViewer.Name = "rasterImageViewer1";
         this._rasterImageViewer.Size = new System.Drawing.Size(742, 538);
         this._rasterImageViewer.TabIndex = 0;
         this.m_splitContainer.Panel2.Controls.Add(this._rasterImageViewer);


         this._rasterImageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
      }

      void _rasterImageList_SelectedItemsChanged(object sender, EventArgs e)
      {
         if (_rasterImageList.Items.GetSelected().Length > 0)
         {
            int selected = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()[0]);
            RasterOverlayAttributes attributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, RasterGetSetOverlayAttributesFlags.Flags);
            _mnuOverlaysShowOverlay.Checked = attributes.AutoPaint;
         }
      }
      private void _mnuFileOpen_Click(object sender, EventArgs e)
      {
         OpenFileDialog openFileDialog = new OpenFileDialog();
         openFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
         openFileDialog.Title = "Open Dicom File";
         openFileDialog.InitialDirectory = _openInitialPath;

         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            _openInitialPath = Path.GetDirectoryName(openFileDialog.FileName);
            // Reset Globals
            ResetGlobals();

            OpenDataset(openFileDialog.FileName);
         }
      }
      private void OpenDataset(string filename)
      {
         try
         {
            _DataSet.Load(filename, DicomDataSetLoadFlags.LoadAndClose);

            // Find Pixel Data
            _PixelElement = _DataSet.FindFirstElement(null, DicomTag.PixelData, true);
            if (_PixelElement != null)
            {
               // Load Base Image
#if !LEADTOOLS_V20_OR_LATER
               DicomGetImageFlags getImageFlags =
                    DicomGetImageFlags.AutoApplyModalityLut |
                    DicomGetImageFlags.AutoApplyVoiLut |
                    DicomGetImageFlags.AutoScaleModalityLut |
                    DicomGetImageFlags.AutoScaleVoiLut |
                    DicomGetImageFlags.AutoDectectInvalidRleCompression |
                    DicomGetImageFlags.AutoLoadOverlays;
#else
               DicomGetImageFlags getImageFlags =
                    DicomGetImageFlags.AutoApplyModalityLut |
                    DicomGetImageFlags.AutoApplyVoiLut |
                    DicomGetImageFlags.AutoScaleModalityLut |
                    DicomGetImageFlags.AutoScaleVoiLut |
                    DicomGetImageFlags.AutoDetectInvalidRleCompression |
                    DicomGetImageFlags.AutoLoadOverlays;
#endif // #if !LEADTOOLS_V20_OR_LATER

               _rasterImageViewer.Image = _DataSet.GetImage(_PixelElement, 0, 0, RasterByteOrder.Gray, getImageFlags);
               LoadOverlays();
               _mnuOverlaysInsertOverlay.Enabled = true;
               _mnuFileSave.Enabled = true;
            }
            else
            {
               Messager.ShowError(this, "NO Pixel Data");
               _mnuOverlaysInsertOverlay.Enabled = false;
               _mnuFileSave.Enabled = false;
            }

            EnableOverlayOptions();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            EnableOverlayOptions();
         }
      }

      private void EnableOverlayOptions()
      {
         bool bValue = _rasterImageList.Items.GetSelected().Length > 0;
         _mnuOverlaysShowOverlay.Enabled = bValue;
         _mnuOverlaysShowOverlay.Checked = bValue;
         _mnuOverlaysChangeOverlayColor.Enabled = bValue;
         _mnuOverlaysSaveOverlay.Enabled = bValue;
         _mnuOverlaysShowOverlayAttributes.Enabled = bValue;
      }

      private void LoadOverlays()
      {
         if (_DataSet.OverlayCount > 0)
         {
            for (int i = 0; i < _DataSet.OverlayCount; i++)
            {
               ImageViewerItem item = new ImageViewerItem();
               item.Size = new LeadSize(100, 100);
               item.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageList.DefaultZoomOrigin.ToLeadPointD());
               RasterOverlayAttributes attribte = _DataSet.GetOverlayAttributes(0);
               if (attribte.FramesInOverlay > 1)
               {
                  item.Image = _DataSet.GetOverlayImages(0, 0, attribte.FramesInOverlay);
               }
               else
               {
                  // Add to image list                  
                  item.Image = _rasterImageViewer.Image.GetOverlayImage(i, RasterGetSetOverlayImageMode.Copy);

                  _rasterImageList.Items.Add(item);
                  _rasterImageList.Items.Select(null);
                  _rasterImageList.Items[i].IsSelected = true;

                  // Add to Viewer
                  _rasterImageViewer.Image.SetOverlayImage(i, item.Image, RasterGetSetOverlayImageMode.Copy);

                  // Update Attributes
                  RasterOverlayAttributes attributes = _rasterImageViewer.Image.GetOverlayAttributes(i, RasterGetSetOverlayAttributesFlags.Flags);
                  attributes.AutoPaint = _mnuOverlaysShowOverlay.Checked;
                  attributes.AutoProcess = true;
                  attributes.Origin = new LeadPoint(0, 0);
                  attributes.Color = new RasterColor(_overlayColor.R, _overlayColor.G, _overlayColor.B);
                  attributes.Columns = item.Image.ImageWidth;
                  attributes.Rows = item.Image.ImageHeight;
                  attributes.BitsAllocated = 1;
                  attributes.FramesInOverlay = item.Image.PageCount;
                  attributes.ImageFrameOrigin = 1;
                  attributes.Type = "G";
                  _rasterImageViewer.Image.UpdateOverlayAttributes(i, attributes, RasterGetSetOverlayAttributesFlags.Flags | RasterGetSetOverlayAttributesFlags.Origin | RasterGetSetOverlayAttributesFlags.Color | RasterGetSetOverlayAttributesFlags.Dicom);
               }
            }
         }
         else
         {
            MessageBox.Show("This dataset has no overlays.\nTo insert a new overlay, please select \"Overlays\\ Insert Overlay\" from the menu.");
         }
      }

      private void _mnuOverlaysShowOverlay_Click(object sender, EventArgs e)
      {
         _mnuOverlaysShowOverlay.Checked = !_mnuOverlaysShowOverlay.Checked;
      }

      private void _mnuOverlaysChangeOverlayColor_Click(object sender, EventArgs e)
      {
         ColorDialog clrDlg = new ColorDialog();
         clrDlg.Color = _overlayColor;
         int selected = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()[0]);

         if (clrDlg.ShowDialog() == DialogResult.OK)
         {
            _overlayColor = clrDlg.Color;
            // Update all overlays with new color
            RasterOverlayAttributes attributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, RasterGetSetOverlayAttributesFlags.Color);
            attributes.Color = new RasterColor(_overlayColor.R, _overlayColor.G, _overlayColor.B);
            _rasterImageViewer.Image.UpdateOverlayAttributes(selected, attributes, RasterGetSetOverlayAttributesFlags.Color);
            RasterImage img = _rasterImageViewer.Image.GetOverlayImage(selected, RasterGetSetOverlayImageMode.Copy);
            img.MakeRegionEmpty();
            RasterColor[] aPalette = { new RasterColor(0, 0, 0), new RasterColor(clrDlg.Color.R, clrDlg.Color.G, clrDlg.Color.B) };
            img.SetPalette(aPalette, 0, 2);
            if (_rasterImageList != null)
               if (_rasterImageList.Items.Count > 0)
               {
                  _rasterImageList.Items[selected].Image.Dispose();
                  _rasterImageList.Items[selected].Image = img;
                  _rasterImageList.Invalidate();
               }
         }
      }

      private void _mnuOverlaysSaveOverlay_Click(object sender, EventArgs e)
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp";
         dlg.FilterIndex = 0;

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            int selected = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()[0]);
            RasterImage overlay = _rasterImageViewer.Image.GetOverlayImage(selected, RasterGetSetOverlayImageMode.Copy);

            RasterCodecs codecs = new RasterCodecs();
            codecs.Save(overlay, dlg.FileName, RasterImageFormat.Bmp, overlay.BitsPerPixel);

            codecs.Dispose();
            overlay.Dispose();
         }
      }

      private void _mnuOverlaysShowOverlayAttributes_Click(object sender, EventArgs e)
      {

         string strAttributes = string.Empty;
         int selected = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()[0]);

         RasterGetSetOverlayAttributesFlags flags = RasterGetSetOverlayAttributesFlags.Color | RasterGetSetOverlayAttributesFlags.BitIndex | RasterGetSetOverlayAttributesFlags.Dicom | RasterGetSetOverlayAttributesFlags.Origin | RasterGetSetOverlayAttributesFlags.Flags;
         RasterOverlayAttributes attributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, flags);

         strAttributes = "Overlay Origin\t\tX: " + attributes.Origin.X.ToString() + "  Y: " + attributes.Origin.Y.ToString() + "\n";
         strAttributes += "Overlay Color\t\t" + attributes.Color.ToRgb() + "\n";
         strAttributes += "Overlay Index\t\t" + selected.ToString() + "\n";
         strAttributes += "AutoPaint Flag\t\t" + (attributes.AutoPaint ? "On" : "Off") + "\n";
         strAttributes += "AutoProcess Flag\t\t" + (attributes.AutoProcess ? "On" : "Off") + "\n";
         strAttributes += "UseBitPlane Flag\t\t" + (attributes.UseBitPlane ? "On" : "Off") + "\n";
         strAttributes += "Num. Of Overlay Rows\t" + attributes.Rows.ToString() + "\n";
         strAttributes += "Num. Of Overlay Columns\t" + attributes.Columns.ToString() + "\n";
         strAttributes += "Overlay Type:\t\t" + attributes.Type + "\n";
         strAttributes += "Num. Of Allocated Bits\t" + attributes.BitsAllocated.ToString() + "\n";
         strAttributes += "Overlay Subtype\t" + attributes.Subtype + "\n";
         strAttributes += "Overlay Label\t" + attributes.Label + "\n";
         strAttributes += "ROI Area\t\t\t" + attributes.RoiArea.ToString() + "\n";
         strAttributes += "ROI Mean\t\t\t" + attributes.RoiMean.ToString() + "\n";
         strAttributes += "ROI Standard Deviation\t" + attributes.RoiStandardDeviation.ToString() + "\n";
         strAttributes += "Num. Of Overlay Frames\t" + attributes.FramesInOverlay.ToString() + "\n";
         strAttributes += "Image Frame Origin\t\t" + attributes.ImageFrameOrigin.ToString() + "\n";
         strAttributes += "Overlay Activation Layer\t\t" + attributes.ActivationLayer + "\n";
         strAttributes += "Overlay Description\t\t" + attributes.Description + "\n";

         MessageBox.Show(strAttributes, "Overlay " + selected + " Attributes");
      }

      private void _mnuOverlaysInsertOverlay_Click(object sender, EventArgs e)
      {
         try
         {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (*.*)|*.*";
            dlg.FilterIndex = 0;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               RasterImage overlay;
               RasterCodecs codecs = new RasterCodecs();

               overlay = codecs.Load(dlg.FileName, 1, CodecsLoadByteOrder.Bgr, 1, 1);

               ImageViewerItem item = new ImageViewerItem();
               int overlayIndex;

               // Add to image list
               item.Image = overlay;
               _rasterImageList.Items.Add(item);
               overlayIndex = _rasterImageList.Items.Count - 1;
               _rasterImageList.Items.Select(null);//   .SelectAll(false);


               // Add to Viewer               
               _rasterImageViewer.Image.SetOverlayImage(overlayIndex, item.Image, RasterGetSetOverlayImageMode.Copy);

               // Update Attributes
               RasterOverlayAttributes attributes = _rasterImageViewer.Image.GetOverlayAttributes(overlayIndex, RasterGetSetOverlayAttributesFlags.Flags);
               attributes.AutoPaint = _mnuOverlaysShowOverlay.Checked;
               attributes.Origin = new LeadPoint(0, 0);
               attributes.Color = new RasterColor(0xFF, 0xFF, 0xFF);
               attributes.Columns = item.Image.ImageWidth;
               attributes.Rows = item.Image.ImageHeight;
               attributes.BitsAllocated = 1;
               attributes.FramesInOverlay = item.Image.PageCount;
               attributes.ImageFrameOrigin = 1;
               attributes.Type = "G";
               _rasterImageViewer.Image.UpdateOverlayAttributes(overlayIndex, attributes, RasterGetSetOverlayAttributesFlags.Flags | RasterGetSetOverlayAttributesFlags.Origin | RasterGetSetOverlayAttributesFlags.Color | RasterGetSetOverlayAttributesFlags.Dicom);

               _rasterImageList.Items[overlayIndex].IsSelected = true;
               EnableOverlayOptions();
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _mnuFileSave_Click(object sender, EventArgs e)
      {
         SaveFileDialog dlg = new SaveFileDialog();
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|All files (*.*)|*.*";
         dlg.FilterIndex = 0;

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            // Get Image Information
            DicomImageInformation imageInfo = _DataSet.GetImageInformation(_PixelElement, 0);

            // Replace image information in DicomDataSet
            _DataSet.SetImage(null, _rasterImageViewer.Image, imageInfo.Compression, imageInfo.PhotometricInterpretation, 0, 0, DicomSetImageFlags.AutoSaveOverlays);

            // Save to disk
            _DataSet.Save(dlg.FileName, DicomDataSetSaveFlags.None);
         }
      }

      private void ResetGlobals()
      {
         _DataSet.Reset();
         _PixelElement = null;
         _overlayColor = Color.White;
         _mnuOverlaysShowOverlay.Checked = true;

         _rasterImageList.Items.Clear();
         if (_rasterImageViewer.Image != null)
            _rasterImageViewer.Image.Dispose();
         _rasterImageViewer.Image = null;
      }

      private void _mnuHelpAboutOverlay_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("DICOM Overlay", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _mnuFileExit_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void _mnuOverlaysShowOverlay_CheckedChanged(object sender, EventArgs e)
      {
         if (_rasterImageList.Items.GetSelected().Length > 0)
         {
            int selected = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()[0]);
            RasterOverlayAttributes attributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, RasterGetSetOverlayAttributesFlags.Flags);
            attributes.AutoPaint = _mnuOverlaysShowOverlay.Checked;
            _rasterImageViewer.Image.UpdateOverlayAttributes(selected, attributes, RasterGetSetOverlayAttributesFlags.Flags);
         }
      }
   }
}
