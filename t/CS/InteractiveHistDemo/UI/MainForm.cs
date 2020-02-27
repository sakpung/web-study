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
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Controls;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.Drawing;

namespace InteractiveHist
{
   public partial class MainForm : Form
   {
      public RasterCodecs _codecs;
      private RasterPaintProperties _paintProperties;
      private ImageFileSaver _saver;
      private string _openInitialPath = string.Empty;
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
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

         _saver = new ImageFileSaver();
      }

      void ShowHelpFile()
      {
         string helpPath = string.Empty;

         try
         {
            helpPath = Application.ExecutablePath;
            int index = helpPath.ToLower().IndexOf("bin");
            helpPath = helpPath.Remove(index);
#if FOR_NUGET
            helpPath += @"Help\Interactive Histogram Demo.htm";

#else
            helpPath += @"Examples\DotNet\CS\InteractiveHistDemo\Help\Interactive Histogram Demo.htm";
#endif // #if FOR_NUGET
            System.Diagnostics.Process.Start(helpPath);
         }
         catch (Exception)
         {
            Messager.ShowError(this, "Error opening file:\r\n" + helpPath);
         }
      }

      private void InitClass()
      {
         Messager.Caption = "LEADTOOLS for .NET C# Interactive Histogram Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();
         _codecs.Options.Txt.Load.Enabled = false;

         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintEngine = RasterPaintEngine.GdiPlus;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;

         ShowHelpFile();
         UpdateControls();
      }

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      public void UpdateControls()
      {
         ViewerForm activeForm = ActiveViewerForm;

         // Update File menu items...
         EnableAndVisibleMenu(_miFileSave, activeForm != null);
         EnableAndVisibleMenu(_miFileClose, activeForm != null);

         // Update Edit menu items...
         EnableAndVisibleMenu(_miEditUndo, activeForm != null);
         EnableAndVisibleMenu(_miEditRedo, activeForm != null);
         _miEditSeperator1.Visible = (activeForm != null);
         EnableAndVisibleMenu(_miEditCopy, activeForm != null);
         _miEditPaste.Enabled = RasterClipboard.IsReady;

         // Update Analysis menu items...
         EnableAndVisibleMenu(_miAnalysis, activeForm != null);
         EnableAndVisibleMenu(_miAnalysisInteractiveHistogram, activeForm != null);

         if (activeForm != null)
         {
            if (activeForm.UndoList.Index <= 0)
               _miEditUndo.Enabled = false;
            else
               _miEditUndo.Enabled = true;

            if (activeForm.UndoList.Index >= activeForm.UndoList.Counter - 1)
               _miEditRedo.Enabled = false;
            else
               _miEditRedo.Enabled = true;

            _menuItemMagGlassStart.Checked = activeForm.IsMagGlass;
            _menuItemMagGlassStop.Checked = !activeForm.IsMagGlass;
         }

         // Update Window menu items...
         EnableAndVisibleMenu(_miWindow, activeForm != null);
      }

      private void EnableAndVisibleMenu(ToolStripMenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private RasterImage ImageToRun
      {
         get
         {
            ViewerForm activeForm = ActiveViewerForm;

            return activeForm.Viewer.Image;
         }
         set
         {
            if (value != null)
            {
               ViewerForm activeForm = ActiveViewerForm;
               activeForm.Viewer.Image = value;
            }
         }
      }

      private void MainForm_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }

      private void MainForm_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
         {
            string[] files = Tools.GetDropFiles(e.Data);
            if (files != null)
               LoadDropFiles(null, files);
         }
      }

      public void LoadDropFiles(ViewerForm viewer, string[] files)
      {
         try
         {
            if (files != null)
            {
               for (int i = 0; i < files.Length; i++)
               {
                  try
                  {
                     RasterImage image = _codecs.Load(files[i]);
                     ImageInformation info = new ImageInformation(image, files[i]);
                     if (i == 0 && viewer != null)
                        viewer.Initialize(info, _paintProperties, false);
                     else
                        NewImage(info);
                  }
                  catch (Exception ex)
                  {
                     Messager.ShowFileOpenError(this, files[i], ex);
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void NewImage(ImageInformation info)
      {
         ViewerForm child = new ViewerForm();
         child.MdiParent = this;

         child.Initialize(info, _paintProperties, true);
         child.Show();
         child.Viewer.Dock = DockStyle.Fill;
      }

      private ImageInformation LoadImage()
      {
         ImageFileLoader loader = new ImageFileLoader();

         loader.OpenDialogInitialPath = _openInitialPath;

         try
         {
            loader.LoadOnlyOnePage = true;
            loader.ShowLoadPagesDialog = false;
            if (loader.Load(this, _codecs, true) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               return new ImageInformation(loader.Image, loader.FileName);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }

         return null;
      }

      private void _miFileOpen_Click(object sender, EventArgs e)
      {
         try
         {
            ImageInformation info = LoadImage();
            if (info != null)
               NewImage(info);

            if (ActiveViewerForm != null)
               AddImageToUndoList(ActiveViewerForm.Viewer.Image);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _miFileSave_Click(object sender, EventArgs e)
      {
         try
         {
            _saver.Save(this, _codecs, ActiveViewerForm.Viewer.Image);
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, _saver.FileName, ex);
         }
      }

      private void _miFileClose_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.Close();

         UpdateControls();
      }

      private void _miFileExit_Click(object sender, EventArgs e)
      {
         GC.Collect();
         this.Close();
      }

      private void _miEditUndo_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.UndoList.Index--;
         ActiveViewerForm.Viewer.Image = ActiveViewerForm.UndoList.GetImage(ActiveViewerForm.UndoList.Index).CloneAll();
         UpdateControls();
      }

      private void _miEditRedo_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.UndoList.Index++;
         ActiveViewerForm.Viewer.Image = ActiveViewerForm.UndoList.GetImage(ActiveViewerForm.UndoList.Index).CloneAll();
         UpdateControls();
      }

      private void _miEditCopy_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               RasterClipboard.Copy(
                  this.Handle,
                  ImageToRun,
                  RasterClipboardCopyFlags.Empty |
                  RasterClipboardCopyFlags.Dib |
                  RasterClipboardCopyFlags.Palette |
                  RasterClipboardCopyFlags.Region);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _miEditPaste_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               RasterImage image = RasterClipboard.Paste(this.Handle);
               if (image != null)
               {
                  ViewerForm activeForm = ActiveViewerForm;

                  if (image.HasRegion && activeForm == null)
                     image.MakeRegionEmpty();

                  if (image.HasRegion)
                  {
                     // make sure the images have the same BitsPerPixel and Palette
                     if (activeForm.Viewer.Image.BitsPerPixel > 8)
                     {
                        if (image.BitsPerPixel != activeForm.Viewer.Image.BitsPerPixel)
                        {
                           try
                           {
                              ColorResolutionCommand colorRes = new ColorResolutionCommand();
                              colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
                              colorRes.Order = activeForm.Viewer.Image.Order;
                              colorRes.Mode = Leadtools.ImageProcessing.ColorResolutionCommandMode.InPlace;
                              colorRes.Run(image);
                           }
                           catch (Exception ex)
                           {
                              Messager.ShowError(this, ex);
                           }
                        }
                     }
                     else
                     {
                        try
                        {
                           ColorResolutionCommand colorRes = new ColorResolutionCommand();
                           colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
                           colorRes.SetPalette(activeForm.Viewer.Image.GetPalette());
                           colorRes.PaletteFlags = Leadtools.ImageProcessing.ColorResolutionCommandPaletteFlags.UsePalette;
                           colorRes.Mode = Leadtools.ImageProcessing.ColorResolutionCommandMode.InPlace;
                           colorRes.Run(image);
                        }
                        catch (Exception ex)
                        {
                           Messager.ShowError(this, ex);
                        }
                     }
                  }
                  else
                     NewImage(new ImageInformation(image));
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void AddImageToUndoList(RasterImage image)
      {
         ActiveViewerForm.UndoList.AddToUndoList(image);
         UpdateControls();
      }

      private void _miAnalysisInteractiveHistogram_Click(object sender, EventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;
         InteractiveHistogramDialog interactiveHistoramDialog = new InteractiveHistogramDialog(this);

         try
         {
            if (interactiveHistoramDialog.ShowDialog() == DialogResult.OK)
            {
               ActiveViewerForm.UndoList.AddToUndoList(ActiveViewerForm.Viewer.Image);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Interactive histogram Demo");
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _miWindow_Click(object sender, EventArgs e)
      {
         if (sender == _miWindowCascade)
            LayoutMdi(MdiLayout.Cascade);
         else if (sender == _miWindowTileHorizontally)
            LayoutMdi(MdiLayout.TileHorizontal);
         else if (sender == _miWindowTileVertically)
            LayoutMdi(MdiLayout.TileVertical);
         else if (sender == _miWindowArrangeIcons)
            LayoutMdi(MdiLayout.ArrangeIcons);
         else if (sender == _miWindowCloseAll)
         {
            while (MdiChildren.Length > 0)
               MdiChildren[0].Close();
            UpdateControls();
         }
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Interactive Histogram", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _mi_DropDownOpening(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void MainForm_MdiChildActivate(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _menuFileHowTo_Click(object sender, EventArgs e)
      {
         ShowHelpFile();
      }

      private void _menuHelpHowTo_Click(object sender, EventArgs e)
      {
         ShowHelpFile();
      }

      private void _menuItemMagGlassStart_Click(object sender, EventArgs e)
      {
         _menuItemMagGlassStart.Checked = true;
         _menuItemMagGlassStop.Checked = false;
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         if (activeForm != null)
            activeForm.StartMagGlass();
      }

      private void _menuItemMagGlassStop_Click(object sender, EventArgs e)
      {
         _menuItemMagGlassStop.Checked = true;
         _menuItemMagGlassStart.Checked = false;
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         if(activeForm != null)
            activeForm.StopMagGlass();
      }
   }
}
