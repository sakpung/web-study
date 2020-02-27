// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.IO;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.ImageProcessing;
using Leadtools.Controls;

using Leadtools.Drawing;

namespace AnimationDemo
{
   public partial class MainForm : Form
   {
      private RasterCodecs _codecs;
      private RasterColor _fillColor;
      public ProgressForm _progressDlg;
      private RasterPaintProperties _paintProperties;
      private bool _animateRegions;
      private ImageFileSaver _saver;
      private bool _useDpi = true;
      RasterPictureBoxAnimationMode _animationMode = RasterPictureBoxAnimationMode.Infinite;
      private FrameSettings _frameSettings;
      private string _openInitialPath = string.Empty;
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main( )
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      public MainForm( )
      {
         InitializeComponent();

         InitClass();

         _saver = new ImageFileSaver();

         LoadImage(true, false);
         UpdateControls();
      }

      private void InitClass( )
      {
         Messager.Caption = "LEADTOOLS for .NET C# Animation Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();
         _codecs.Options.Txt.Load.Enabled = false;
         _fillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);
         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
         _animateRegions = false;

         UpdateControls();
      }

      private void CleanUp( )
      {
      }

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      public void UpdateControls( )
      {
         ViewerForm activeForm = ActiveViewerForm;

         EnableAndVisibleMenu(_menuItemFileSave, activeForm != null);
         EnableAndVisibleMenu(_menuItemEditCopy, activeForm != null);
         EnableAndVisibleMenu(_menuItemPage, activeForm != null);
         EnableAndVisibleMenu(_menuItemView, activeForm != null);
         EnableAndVisibleMenu(_menuItemWindow, activeForm != null && MdiChildren.Length > 0);
         EnableAndVisibleMenu(_menuItemAnimation, activeForm != null);
         if(activeForm != null)
         {
            EnableAndVisibleMenu(_menuItemPageFirst, activeForm.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPagePrevious, activeForm.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPageNext, activeForm.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPageLast, activeForm.Image.PageCount > 1);
            _menuItemPageSep1.Visible = activeForm.Image.PageCount > 1;
            EnableAndVisibleMenu(_menuItemPageDeleteCurrentPage, activeForm.Image.PageCount > 1);

            if(activeForm.Image.PageCount > 1)
            {
               _menuItemPageFirst.Enabled = activeForm.Image.Page > 1;
               _menuItemPagePrevious.Enabled = activeForm.Image.Page > 1;
               _menuItemPageNext.Enabled = activeForm.Image.Page != activeForm.Image.PageCount;
               _menuItemPageLast.Enabled = activeForm.Image.Page != activeForm.Image.PageCount;
            }

            _menuItemViewSizeModeNormal.Checked = activeForm.Viewer.SizeMode == RasterPictureBoxSizeMode.Normal;
            _menuItemViewSizeModeStretch.Checked = activeForm.Viewer.SizeMode == RasterPictureBoxSizeMode.StretchImage;
            _menuItemViewSizeModeCenter.Checked = activeForm.Viewer.SizeMode == RasterPictureBoxSizeMode.CenterImage;
            _menuItemViewSizeModeZoom.Checked = activeForm.Viewer.SizeMode == RasterPictureBoxSizeMode.Fit;
            _menuItemViewSizeModeAuto.Checked = activeForm.Viewer.SizeMode == RasterPictureBoxSizeMode.AutoSize;
         }
      }

      private void EnableAndVisibleMenu(ToolStripMenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void _menuItemFileOpen_Click(object sender, EventArgs e)
      {
         LoadImage(false, false);
         UpdateControls();
      }

      private void _menuItemFileSave_Click(object sender, EventArgs e)
      {
         try
         {
            DemosGlobal.SetDefaultComments(ActiveViewerForm.Viewer.Image, _codecs);
            _saver.Save(this, _codecs, ActiveViewerForm.Viewer.Image);
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, _saver.FileName, ex);
         }
      }

      private void _menuItemFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void MainForm_MdiChildActivate(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         UpdateControls();
      }

      void _menuItemEdit_DropDownOpened(object sender, EventArgs e)
      {
         _menuItemEditPaste.Enabled = RasterClipboard.IsReady;
      }

      private void _menuItemEditCopy_Click(object sender, EventArgs e)
      {
         try
         {
            using(WaitCursor wait = new WaitCursor())
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
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemEditPaste_Click(object sender, EventArgs e)
      {
         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               RasterImage image = RasterClipboard.Paste(this.Handle);
               if(image != null)
               {
                  ViewerForm activeForm = ActiveViewerForm;
                  NewImage(new ImageInformation(image));
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }


      private void _menuItemPage_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;
            RasterColor background = activeForm.Image.AnimationBackground;

            if(activeForm.Viewer.Image.HasRegion)
               activeForm.Viewer.Image.MakeRegionEmpty();

            if(sender == _menuItemPageFirst)
               activeForm.Image.Page = 1;
            else if(sender == _menuItemPagePrevious)
               activeForm.Image.Page--;
            else if(sender == _menuItemPageNext)
               activeForm.Image.Page++;
            else if(sender == _menuItemPageLast)
               activeForm.Image.Page = activeForm.Image.PageCount;

            activeForm.Image.AnimationBackground = background;
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemPageAdd_Click(object sender, EventArgs e)
      {
         LoadImage(false, true);
         UpdateControls();
      }

      private void _menuItemPageDeleteCurrentPage_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            activeForm.Image.RemovePageAt(activeForm.Image.Page);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }


      private void _menuItemViewSizeMode_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         if(sender == _menuItemViewSizeModeNormal)
         {
            activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.Normal;
         }
         else
         {
            activeForm.Viewer.BeginUpdate();
            if(sender == _menuItemViewSizeModeStretch)
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.StretchImage;
            else if(sender == _menuItemViewSizeModeCenter)
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.CenterImage;
            else if(sender == _menuItemViewSizeModeZoom)
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.Fit;
            else if(sender == _menuItemViewSizeModeAuto)
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.AutoSize;

            activeForm.Viewer.EndUpdate();
         }

         UpdateControls();
      }

      private void _menuItemPreferencesPaintProperties_Click(object sender, EventArgs e)
      {
         PaintPropertiesDialog dlg = new PaintPropertiesDialog();
         dlg.PaintProperties = _paintProperties;
         dlg.Apply += new EventHandler(PaintPropertiesDialog_Apply);
         dlg.ShowDialog(this);
      }

      private void PaintPropertiesDialog_Apply(object sender, EventArgs e)
      {
         PaintPropertiesDialog dlg = sender as PaintPropertiesDialog;
         _paintProperties = dlg.PaintProperties;
         foreach(ViewerForm i in MdiChildren)
            i.UpdatePaintProperties(_paintProperties);
      }

      private void _menuItemHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Animation", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _menuItemWindow_Click(object sender, EventArgs e)
      {
         if(sender == _menuItemWindowCascade)
            LayoutMdi(MdiLayout.Cascade);
         else if(sender == _menuItemWindowTileHorizontally)
            LayoutMdi(MdiLayout.TileHorizontal);
         else if(sender == _menuItemWindowTileVertically)
            LayoutMdi(MdiLayout.TileVertical);
         else if(sender == _menuItemWindowArrangeIcons)
            LayoutMdi(MdiLayout.ArrangeIcons);
         else if(sender == _menuItemWindowCloseAll)
         {
            while(MdiChildren.Length > 0)
               MdiChildren[0].Close();
            UpdateControls();
         }
      }

      private void LoadImage(bool loadDefaultImage, bool addingPage)
      {
         ImageFileLoader loader = new ImageFileLoader();
         loader.OpenDialogInitialPath = _openInitialPath;
         
         
         try
         {
            loader.ShowLoadPagesDialog = true;

            if (loadDefaultImage)
            {
                string imagePath = System.IO.Path.Combine( DemosGlobal.ImagesFolder, "image1.gif" );
                if ( !System.IO.File.Exists( imagePath ) )
                {
                   imagePath = System.IO.Path.Combine( Application.StartupPath, "image1.gif" );
                }
                if (loader.Load(this, imagePath, _codecs, 1, -1))
                {
                    NewImage(new ImageInformation(loader.Image, loader.FileName));
                }
            }
            else
            {
               if (loader.Load(this, _codecs, true) > 0)
               {
                  _openInitialPath = Path.GetDirectoryName(loader.FileName);
                  if (addingPage)
                     ActiveViewerForm.Image.AddPages(loader.Image, 1, loader.Image.PageCount);
                  else
                     NewImage(new ImageInformation(loader.Image, loader.FileName));
               }           
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private void NewImage(ImageInformation info)
      {
         ViewerForm child = new ViewerForm();
         child.MdiParent = this;
         child.Initialize(info, _paintProperties, _animateRegions, true, _useDpi, _animationMode);
         child.Show();
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
            if(value != null)
            {
               ViewerForm activeForm = ActiveViewerForm;
               activeForm.Viewer.Image = value;
            }
         }
      }

      public void LoadDropFiles(ViewerForm viewer, string[] files)
      {
         try
         {
            if(files != null)
            {
               for(int i = 0; i < files.Length; i++)
               {
                  try
                  {
                     RasterImage image = _codecs.Load(files[i]);
                     ImageInformation info = new ImageInformation(image, files[i]);
                     if(i == 0 && viewer != null)
                        viewer.Initialize(info, _paintProperties, _animateRegions, false, _useDpi, _animationMode);
                     else
                        NewImage(info);
                  }
                  catch(Exception ex)
                  {
                     Messager.ShowFileOpenError(this, files[i], ex);
                  }
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void MainForm_Closing(object sender, CancelEventArgs e)
      {
         CleanUp();
      }

      private void _menuItemPreferencesUseDpi_Click(object sender, EventArgs e)
      {  
         _menuItemPreferencesUseDpi.Checked = !_menuItemPreferencesUseDpi.Checked;
         foreach (ViewerForm i in MdiChildren)
         {
            i.Viewer.UseDpi = _menuItemPreferencesUseDpi.Checked;
            i.Viewer.Invalidate(true);  
         }
         _useDpi = _menuItemPreferencesUseDpi.Checked;
      }

      private void _menuItemAnimationPlay_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.Viewer.PlayAnimation();
      }

      private void _menuItemAnimationPause_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.Viewer.PauseAnimation();
      }

      private void _menuItemAnimationLoop_Click(object sender, EventArgs e)
      {
         RasterPictureBoxAnimationMode mode = RasterPictureBoxAnimationMode.Infinite;
         _menuItemAnimationLoop.Checked = !_menuItemAnimationLoop.Checked;
         if (!_menuItemAnimationLoop.Checked)
            mode = RasterPictureBoxAnimationMode.UseImageGlobalLoop;

         foreach (ViewerForm i in MdiChildren)
            i.Viewer.AnimationMode = mode;

         _animationMode = mode;
      }

      private void _menuItemAnimationCreate_Click(object sender, EventArgs e)
      {
         CreateAnimationDialog createAnimationDialog = new CreateAnimationDialog();
         createAnimationDialog.Owner = this;
         if (createAnimationDialog.ShowDialog() == DialogResult.OK)
         {
            createAnimationDialog.Image.AnimationGlobalLoop = 1000;
            createAnimationDialog.Image.AnimationDelay = 500;
            ImageInformation info = new ImageInformation(createAnimationDialog.Image);
            ViewerForm child = new ViewerForm();
            child.MdiParent = this;
            child.Initialize(info, _paintProperties, _animateRegions, true, _useDpi, _animationMode);
            child.Show();
         }
      }

      private void _menuItemAnimationFrameSettings_Click(object sender, EventArgs e)
      {
         if (_frameSettings == null)
         {
            _frameSettings = new FrameSettings(ActiveViewerForm.Viewer.Image);
         }
         else
         {
            _frameSettings.Image = ActiveViewerForm.Viewer.Image;
         }

         _frameSettings.ShowDialog();
      }

      private void _menuItemBackground_Click(object sender, EventArgs e)
      {
         if (ActiveViewerForm.Viewer.Image.BitsPerPixel <= 8)
         {
            ChooseColorDialog colorDialog = new ChooseColorDialog(ActiveViewerForm.Viewer.Image, true);

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
               ActiveViewerForm.Viewer.Image.AnimationBackground = Leadtools.Demos.Converters.FromGdiPlusColor(colorDialog.SelectedColor);
            }
         }
         else
         {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
               ActiveViewerForm.Viewer.Image.AnimationBackground = Leadtools.Demos.Converters.FromGdiPlusColor(colorDialog.Color);
            }
         }
      }

      private void _menuItemAnimationOptimizeColors_Click(object sender, EventArgs e)
      {
         try
         {
            RasterCommand command = null;
            ViewerForm activeForm = ActiveViewerForm;
            ColorResolutionDialog dlg = new ColorResolutionDialog(activeForm.Viewer.Image);
            dlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               int page = activeForm.Viewer.Image.Page;
               command = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, dlg.BitsPerPixel, dlg.Order, dlg.DitheringMethod, dlg.PaletteFlags, null);

               for (int i = 0; i < activeForm.Viewer.Image.PageCount; ++i)
               {
                  activeForm.Viewer.Image.Page = i + 1;
                  command.Run(activeForm.Viewer.Image);
               }

               activeForm.Viewer.Image.Page = page;
            }
         }
         catch (System.Exception ex)
         {
            Messager.Show(this, ex, MessageBoxIcon.Warning);
         }
      }
   }
}
