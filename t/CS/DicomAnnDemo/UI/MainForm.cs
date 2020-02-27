// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Demos;
using Leadtools.Controls;
using Leadtools.DicomDemos;
using Leadtools.Annotations.Engine;
using Leadtools.Dicom.Annotations;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace DicomAnnDemo
{
   public enum DicomAnnotationSizeMode
   {
      ScaleToFit = 0,
      TrueSize = 1,
      Magnify = 2,
   }

   public enum AnnObjects
   {
      GroupObjectId = 0,
      SelectObjectId = -1,
      LineObjectId = -2,
      RectangleObjectId = -3,
      EllipseObjectId = -4,
      PolylineObjectId = -5,
      PolygonObjectId = -6,
      CurveObjectId = -7,
      ClosedCurveObjectId = -8,
      PointerObjectId = -9,
      TextObjectId = -12,
      TextPointerObjectId = -14,
      PointObjectId = -21,
   }

   public class MainForm : System.Windows.Forms.Form
   {
      private System.ComponentModel.IContainer components;
      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _menuItemHelp;
      private System.Windows.Forms.MenuItem _menuItemHelpAbout;
      private System.Windows.Forms.MenuItem _menuItemFile;
      private System.Windows.Forms.MenuItem _menuItemFileOpen;
      private System.Windows.Forms.MenuItem _menuItemFileSave;
      private System.Windows.Forms.MenuItem _menuItemFileExit;
      private System.Windows.Forms.MenuItem _menuItemView;
      private System.Windows.Forms.MenuItem _menuItemViewNormal;
      private System.Windows.Forms.MenuItem _menuItemViewFitToWindow;
      private System.Windows.Forms.MenuItem _menuItemViewSpiltter1;
      private System.Windows.Forms.MenuItem _menuItemViewAnnotationToolbar;
      private System.Windows.Forms.MenuItem _menuItem_Annotations;
      private System.Windows.Forms.MenuItem _menuItemAnnotationsPresentationStateInfo;
      private System.Windows.Forms.ImageList _imageList;
      private System.Windows.Forms.OpenFileDialog _openFileDialog;
      private System.Windows.Forms.SaveFileDialog _saveFileDialog;
      private System.Windows.Forms.TreeView _treeView_Elements;
      private System.Windows.Forms.SplitContainer _splitContainer;

      PresentationStateAttributesDialog _presentationStateDialog;
      private DicomDataSet _dsImage;
      private DicomImageInformation _imageInfo = null;
      private AnnAutomation _automation = null;
      AnnAutomationManager _annManager;
      AutomationManagerHelper _automationHelper;
      private DicomAnnotationsUtilities _dicomAnnotationsUtilities;
      DicomPresentationStateInformation _presentation;
      private string _openInitialPath = string.Empty;
      private AutomationInteractiveMode _automationInteractiveMode = null;
      private AutomationTextBox _automationTextBox;
      public MainForm()
      {
         StartupMessageBox startupMsgBox = new StartupMessageBox("CSDicomAnnDemo");
         if (startupMsgBox.ShowStartUpDialog)
            startupMsgBox.ShowDialog();
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         InitClass();
      }

      private void InitClass()
      {
         Messager.Caption = "LEADTOOLS for .NET C# Dicom Annotation Demo";
         Text = Messager.Caption;
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
         this._mainMenu = new System.Windows.Forms.MainMenu(this.components);
         this._menuItemFile = new System.Windows.Forms.MenuItem();
         this._menuItemFileOpen = new System.Windows.Forms.MenuItem();
         this._menuItemFileSave = new System.Windows.Forms.MenuItem();
         this._menuItemFileExit = new System.Windows.Forms.MenuItem();
         this._menuItemView = new System.Windows.Forms.MenuItem();
         this._menuItemViewNormal = new System.Windows.Forms.MenuItem();
         this._menuItemViewFitToWindow = new System.Windows.Forms.MenuItem();
         this._menuItemViewSpiltter1 = new System.Windows.Forms.MenuItem();
         this._menuItemViewAnnotationToolbar = new System.Windows.Forms.MenuItem();
         this._menuItem_Annotations = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsPresentationStateInfo = new System.Windows.Forms.MenuItem();
         this._menuItemHelp = new System.Windows.Forms.MenuItem();
         this._menuItemHelpAbout = new System.Windows.Forms.MenuItem();
         this._imageList = new System.Windows.Forms.ImageList(this.components);
         this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
         this._treeView_Elements = new System.Windows.Forms.TreeView();
         this._splitContainer = new System.Windows.Forms.SplitContainer();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
         this._splitContainer.Panel1.SuspendLayout();
         this._splitContainer.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile,
            this._menuItemView,
            this._menuItem_Annotations,
            this._menuItemHelp});
         // 
         // _menuItemFile
         // 
         this._menuItemFile.Index = 0;
         this._menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFileOpen,
            this._menuItemFileSave,
            this._menuItemFileExit});
         this._menuItemFile.Text = "&File";
         this._menuItemFile.Popup += new System.EventHandler(this.menuItemFile_Popup);
         // 
         // _menuItemFileOpen
         // 
         this._menuItemFileOpen.Index = 0;
         this._menuItemFileOpen.Text = "&Open...";
         this._menuItemFileOpen.Click += new System.EventHandler(this.menuItemFileOpen_Click);
         // 
         // _menuItemFileSave
         // 
         this._menuItemFileSave.Enabled = false;
         this._menuItemFileSave.Index = 1;
         this._menuItemFileSave.Text = "&Save...";
         this._menuItemFileSave.Click += new System.EventHandler(this.menuItemFileSave_Click);
         // 
         // _menuItemFileExit
         // 
         this._menuItemFileExit.Index = 2;
         this._menuItemFileExit.Text = "&Exit";
         this._menuItemFileExit.Click += new System.EventHandler(this.menuItemFileExit_Click);
         // 
         // _menuItemView
         // 
         this._menuItemView.Index = 1;
         this._menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewNormal,
            this._menuItemViewFitToWindow,
            this._menuItemViewSpiltter1,
            this._menuItemViewAnnotationToolbar});
         this._menuItemView.Text = "&View";
         this._menuItemView.Popup += new System.EventHandler(this.menuItemView_Popup);
         // 
         // _menuItemViewNormal
         // 
         this._menuItemViewNormal.Index = 0;
         this._menuItemViewNormal.Text = "&Normal";
         this._menuItemViewNormal.Click += new System.EventHandler(this.menuItemViewNormal_Click);
         // 
         // _menuItemViewFitToWindow
         // 
         this._menuItemViewFitToWindow.Index = 1;
         this._menuItemViewFitToWindow.Text = "&Fit to Window";
         this._menuItemViewFitToWindow.Click += new System.EventHandler(this.menuItemViewFitToWindow_Click);
         // 
         // _menuItemViewSpiltter1
         // 
         this._menuItemViewSpiltter1.Index = 2;
         this._menuItemViewSpiltter1.Text = "-";
         // 
         // _menuItemViewAnnotationToolbar
         // 
         this._menuItemViewAnnotationToolbar.Checked = true;
         this._menuItemViewAnnotationToolbar.Index = 3;
         this._menuItemViewAnnotationToolbar.Text = "Annotation Toolbar";
         this._menuItemViewAnnotationToolbar.Click += new System.EventHandler(this._menuItemViewAnnotationToolbar_Click);
         // 
         // _menuItem_Annotations
         // 
         this._menuItem_Annotations.Index = 2;
         this._menuItem_Annotations.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsPresentationStateInfo});
         this._menuItem_Annotations.Text = "&Annotations";
         // 
         // _menuItemAnnotationsPresentationStateInfo
         // 
         this._menuItemAnnotationsPresentationStateInfo.Index = 0;
         this._menuItemAnnotationsPresentationStateInfo.Text = "Presentation State Info";
         this._menuItemAnnotationsPresentationStateInfo.Click += new System.EventHandler(this._menuItemAnnotationsPresentationStateInfo_Click);
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
         this._menuItemHelpAbout.Text = "&About";
         this._menuItemHelpAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
         // 
         // _imageList
         // 
         this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
         this._imageList.TransparentColor = System.Drawing.Color.Transparent;
         this._imageList.Images.SetKeyName(0, "");
         this._imageList.Images.SetKeyName(1, "");
         this._imageList.Images.SetKeyName(2, "");
         this._imageList.Images.SetKeyName(3, "");
         // 
         // _openFileDialog
         // 
         this._openFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
         this._openFileDialog.Multiselect = true;
         this._openFileDialog.Title = "Open Dicom File";
         // 
         // _treeView_Elements
         // 
         this._treeView_Elements.Dock = System.Windows.Forms.DockStyle.Fill;
         this._treeView_Elements.FullRowSelect = true;
         this._treeView_Elements.HideSelection = false;
         this._treeView_Elements.ImageIndex = 0;
         this._treeView_Elements.ImageList = this._imageList;
         this._treeView_Elements.Location = new System.Drawing.Point(0, 0);
         this._treeView_Elements.Name = "_treeView_Elements";
         this._treeView_Elements.SelectedImageIndex = 0;
         this._treeView_Elements.Size = new System.Drawing.Size(80, 518);
         this._treeView_Elements.TabIndex = 3;
         // 
         // _splitContainer
         // 
         this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer.Location = new System.Drawing.Point(0, 0);
         this._splitContainer.Name = "_splitContainer";
         // 
         // _splitContainer.Panel1
         // 
         this._splitContainer.Panel1.Controls.Add(this._treeView_Elements);
         this._splitContainer.Size = new System.Drawing.Size(673, 518);
         this._splitContainer.SplitterDistance = 80;
         this._splitContainer.TabIndex = 4;
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(673, 518);
         this.Controls.Add(this._splitContainer);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.Text = "DicomAnnDemo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.MainForm_Load);
         this._splitContainer.Panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
         this._splitContainer.ResumeLayout(false);
         this.ResumeLayout(false);

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

         Boolean bMedicalLocked = RasterSupport.IsLocked(RasterSupportType.Medical);
         if (bMedicalLocked)
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         Boolean bDocLocked = RasterSupport.IsLocked(RasterSupportType.Document);
         if (bDocLocked)
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         if (bMedicalLocked | bDocLocked)
            return;

         Application.Run(new MainForm());
      }

      // Automation viewer object.
      private MyAutomationImageViewer _viewer;
      private void menuItemAbout_Click(object sender, System.EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("DICOM Annotation", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("DICOM Annotation"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void menuItemFileExit_Click(object sender, System.EventArgs e)
      {
         Application.Exit();
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // Initialize the viewer object.
         DicomEngine.Startup();

         _viewer = new MyAutomationImageViewer();
         _viewer.BackColor = SystemColors.Control;
         _viewer.KeyDown += new KeyEventHandler(_viewer_KeyDown);
         _viewer.Dock = DockStyle.Fill;
         this._splitContainer.Panel2.Controls.Add(_viewer);

         _automationInteractiveMode = new AutomationInteractiveMode();

         _automationInteractiveMode.IdleCursor = Cursors.Arrow;
         _automationInteractiveMode.WorkingCursor = Cursors.Cross;

         _viewer.InteractiveModes.BeginUpdate();
         _viewer.InteractiveModes.Add(_automationInteractiveMode);
         _viewer.InteractiveModes.EndUpdate();

         _dsImage = new DicomDataSet();

         if (_dsImage == null)
         {
            Messager.ShowError(this, "Can't create dicom object. Quitting app.");
            Application.Exit();
            return;
         }

         BringToFront();

         InitAutomationManager();

         _presentation = new DicomPresentationStateInformation();
         _presentation.InstanceNumber = 1;
         _presentation.PresentationLabel = "LABEL";

         _presentationStateDialog = new PresentationStateAttributesDialog();
         _dicomAnnotationsUtilities = new DicomAnnotationsUtilities();

         Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

         LoadImage(true);
      }

      void Application_ApplicationExit(object sender, EventArgs e)
      {
         DicomEngine.Shutdown();
      }

      private void FreeImage()
      {
         if (_viewer.Image != null)
         {
            if (_viewer.Image.PageCount > 1)
            {
               _viewer.Image.RemoveAllPages();
            }

            _viewer.Image.Dispose();
            _viewer.Image = null;
         }
      }

      private void menuItemFileOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
      }

      private void menuItemView_Popup(object sender, System.EventArgs e)
      {
         bool enable = false;
         if (_viewer.Image == null || (_viewer.Image.PageCount < 1))
         {
            enable = false;
         }
         else
         {
            enable = true;
         }

         _menuItemViewNormal.Enabled = enable;
         _menuItemViewNormal.Checked = _viewer.SizeMode == ControlSizeMode.ActualSize;

         _menuItemViewFitToWindow.Enabled = enable;
         _menuItemViewFitToWindow.Checked = _viewer.SizeMode == ControlSizeMode.FitAlways;
      }

      private void ChangeView(ControlSizeMode rasterPaintSizeMode)
      {
         _viewer.Zoom(rasterPaintSizeMode, 1, _viewer.DefaultZoomOrigin);
      }

      private void menuItemViewNormal_Click(object sender, System.EventArgs e)
      {
         ChangeView(ControlSizeMode.ActualSize);
      }

      private void menuItemViewFitToWindow_Click(object sender, System.EventArgs e)
      {
         ChangeView(ControlSizeMode.FitAlways);
      }

      private void _menuItemViewAnnotationToolbar_Click(object sender, EventArgs e)
      {
         _automationHelper.ToolBar.Visible = !_automationHelper.ToolBar.Visible;
         (sender as MenuItem).Checked = _automationHelper.ToolBar.Visible;
      }

      private void _menuItemAnnotationsPresentationStateInfo_Click(object sender, EventArgs e)
      {
         PresentationStateDialog(false);
      }

      private void CloseCurrentFile()
      {
         _treeView_Elements.BeginUpdate();
         _treeView_Elements.Nodes.Clear();
         _treeView_Elements.EndUpdate();

         _dsImage.Reset();

         FreeImage();
      }

      private void menuItemFile_Popup(object sender, System.EventArgs e)
      {
         bool valid = IsDatasetValid();

         _menuItemFileSave.Enabled = valid;
      }

      void _viewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete && _automation.CanDeleteObjects )
            _automation.DeleteSelectedObjects();
      }

      private void LoadImage(bool loadDefaultImage)
      {
         try
         {
            if (loadDefaultImage)
            {
#if LT_CLICKONCE
               OpenDataset("image2.dcm", loadDefaultImage);
#else
               OpenDataset(DemosGlobal.ImagesFolder + @"\image2.dcm", loadDefaultImage);
#endif // LT_CLICKONCE
            }
            else
            {
               this._openFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
               this._openFileDialog.Multiselect = false;
               this._openFileDialog.Title = "Open Dicom File";
               this._openFileDialog.InitialDirectory = _openInitialPath;

               if (_openFileDialog.ShowDialog() == DialogResult.OK)
               {
                  _openInitialPath = Path.GetDirectoryName(_openFileDialog.FileName);
                  OpenDataset(_openFileDialog.FileName, loadDefaultImage);
               }
            }
            _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin);
            EnableMenuItems(true);
         }
         catch
         {
            EnableMenuItems(false);
            Messager.ShowError(this, "Error loading image");
         }
      }

      private void InitAutomationManager()
      {
         _annManager = new AnnAutomationManager();

         _annManager.CreateDefaultObjects();
         List<AnnAutomationObject> objectsToRemove = new List<AnnAutomationObject>();
         foreach (AnnAutomationObject obj in _annManager.Objects)
         {
            if (Enum.GetName(typeof(AnnObjects), obj.Id) == null)
            {
               objectsToRemove.Add(obj);
            }
         }

         foreach (AnnAutomationObject obj in objectsToRemove)
         {
            _annManager.Objects.Remove(obj);
         }
         _automationHelper = new AutomationManagerHelper(_annManager);
         _automationHelper.CreateToolBar();
         if (_annManager.RenderingEngine != null)
            _annManager.RenderingEngine.LoadPicture += RenderingEngine_LoadPicture;

         _automationHelper.ToolBar.Dock = DockStyle.Right;
         _automationHelper.ToolBar.Appearance = ToolBarAppearance.Flat;
         _automationHelper.ToolBar.AutoSize = false;
         _automationHelper.ToolBar.Visible = true;
         _automationHelper.ToolBar.BringToFront();

         this.Controls.Add(_automationHelper.ToolBar);
         
         foreach (AnnAutomationObject obj in _annManager.Objects)
         {
            obj.UseRotateThumbs = true;
            if (obj.ObjectTemplate != null && obj.ObjectTemplate.SupportsStroke)
            {
               //obj.Object.Pen = new AnnPen(Color.White, new AnnLength(1));
            }
         }

         _automation = new AnnAutomation(_annManager, _viewer);

         _automation.EditText += new EventHandler<AnnEditTextEventArgs>(automation_EditText);

         //Change AnnText to use Pen
         LeadLengthD annLength = new LeadLengthD(1);
         AnnAutomationObject annAutText = _automation.Manager.FindObjectById((int)AnnObjects.TextObjectId);
         annAutText.ObjectTemplate.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), annLength);
         _automation.Active = true;
      }

      void RenderingEngine_LoadPicture(object sender, AnnLoadPictureEventArgs e)
      {
         _automation.Invalidate(LeadRectD.Empty);
      }

      void automation_EditText(object sender, AnnEditTextEventArgs e)
      {
         RemoveAutomationTextBox(true);

         if (e.TextObject == null)
            return;

         _automationTextBox = new AutomationTextBox(_viewer, this._automation, e, RemoveAutomationTextBox);
      }

      private void RemoveAutomationTextBox(bool update)
      {
         if (_automationTextBox == null)
            return;

         _automationTextBox.Remove(update);
         _automationTextBox.Dispose();
         _automationTextBox = null;
      }

      private void ClearAnnotations()
      {
         if (_automation != null && _automation.Container != null && _automation.Container.Children.Count > 0)
            _automation.Container.Children.Clear();
      }

#if !LEADTOOLS_V20_OR_LATER
      private const DicomGetImageFlags _getImageFlags =
                    DicomGetImageFlags.AutoApplyModalityLut |
                    DicomGetImageFlags.AutoApplyVoiLut |
                    DicomGetImageFlags.AutoScaleModalityLut |
                    DicomGetImageFlags.AutoScaleVoiLut |
                    DicomGetImageFlags.AutoDectectInvalidRleCompression;
#else
      private const DicomGetImageFlags _getImageFlags =
                    DicomGetImageFlags.AutoApplyModalityLut |
                    DicomGetImageFlags.AutoApplyVoiLut |
                    DicomGetImageFlags.AutoScaleModalityLut |
                    DicomGetImageFlags.AutoScaleVoiLut |
                    DicomGetImageFlags.AutoDetectInvalidRleCompression;
#endif // #if !LEADTOOLS_V20_OR_LATER

      private bool ShowImage()
      {
         try
         {
            DicomElement element = null;
            element = _dsImage.FindFirstElement(null, DemoDicomTags.PixelData, true);
            int bitmapCount = _dsImage.GetImageCount(element);
            if (bitmapCount > 0)
            {
               FreeImage();
               if (bitmapCount == 1)
               {
                  if (element != null)
                  {
                     RasterImage image;

                     image = _dsImage.GetImage(element, 0, 0, RasterByteOrder.Gray, _getImageFlags);

                     _viewer.Image = image;
                  }
               }
               else
               {
                  if (element != null)
                     LoadBitmapList(element);
               }

               if (element != null)
               {
                  _imageInfo = _dsImage.GetImageInformation(element, 0);
               }

               if ((_dicomAnnotationsUtilities != null) && (_viewer.Image != null))
               {
                  _dicomAnnotationsUtilities.DisplayWidth = _viewer.Image.Width;
                  _dicomAnnotationsUtilities.DisplayHeight = _viewer.Image.Height;
               }

               return true;
            }
            else
            {
               Messager.ShowInformation(this, "Please note that this dataset doesn't include any images.");
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);
            throw exception;
         }
         return false;
      }

      private void OpenDataset(string file, bool loadDefaultImage)
      {
         if (File.Exists(file))
         {
            Cursor = Cursors.WaitCursor;
            bool bImageLoaded = false;
            try
            {
               try
               {
                  _dsImage.Load(file, DicomDataSetLoadFlags.LoadAndClose);
                  bImageLoaded = ShowImage();
           
                  // Update the container size
                  _automation.Container.Size = _automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight));

               }
               catch (Exception)
               {
                  string msg = string.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM file.", file);
                  Messager.ShowError(this, msg);
                  return;
               }

               if (_dsImage.InformationClass == DicomClassType.BasicDirectory)
               {
                  Messager.ShowError(this, "This demo does not support opening Dicom Directory datasets.  " +
                      "Please see the Dicom Directory demo.");
                  return;
               }

               //if dicom file loaded successfully
               if (bImageLoaded)
               {
                  UpdateTree();
                  //Load ".pre" File
                  string fileName = Path.GetFileNameWithoutExtension(file) + ".pre";
                  string DirectoryName = Path.GetDirectoryName(file);
                  CloseAnnotations();
                  LoadAnnotationFile(Path.Combine(DirectoryName, fileName), loadDefaultImage);
               }
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
            finally
            {
               Cursor = Cursors.Arrow;
            }

            if (_treeView_Elements.Nodes.Count > 0)
            {
               _treeView_Elements.SelectedNode = _treeView_Elements.Nodes[0];
            }
         }
         else
         {
            Messager.ShowError(this, String.Format("\"{0}\" Not Found", Path.GetFileName(file)));
         }
      }

      private bool LoadAnnotationFile(string fileName, bool loadDefaultImage)
      {
         if (File.Exists(fileName))
         {
            try
            {
               DicomDataSet dsPresentationState = new DicomDataSet();
               dsPresentationState.Load(fileName, DicomDataSetLoadFlags.LoadAndClose);

               AnnContainer annContainer = _dicomAnnotationsUtilities.FromDataSetToAnnContainer(dsPresentationState, null, _dsImage);
               if (annContainer != null)
               {
                  foreach (AnnObject annObject in annContainer.Children)
                  {
                     DrawLeadAnnotationObject(annObject);
                  }
               }


               _presentation = dsPresentationState.GetPresentationStateInformation();

               DicomPresentationStateInformation PresState = dsPresentationState.GetPresentationStateInformation();
               if (PresState != null)
               {
                  _presentationStateDialog.Presentation.InstanceNumber = PresState.InstanceNumber;
                  _presentationStateDialog.Presentation.PresentationCreator = PresState.PresentationCreator;
                  _presentationStateDialog.Presentation.PresentationLabel = PresState.PresentationLabel;
                  _presentationStateDialog.Presentation.PresentationDescription = PresState.PresentationDescription;
                  if (PresState.PresentationCreationDate.Year != 0)
                  {
                     _presentationStateDialog.Presentation.CreationDate = PresState.PresentationCreationDate.ToDateTime();
                  }
                  if (PresState.PresentationCreationTime.Hours != 0)
                  {
                     _presentationStateDialog.Presentation.CreationTime = PresState.PresentationCreationTime.ToDateTime();
                  }

                  _automation.SelectObjects(null);
                  return true;
               }
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex.Message);
            }
         }
         else
         {
            ClearAnnotations();

            //if not the default file, show a message
            if (!loadDefaultImage)
               Messager.ShowInformation(
                  this,
                  "No related Presentation State file (.pre) was found. A Grayscale Softcopy Presentation State object will be created for the loaded image."
                  );
         }
         return false;
      }

      private void LoadBitmapList(DicomElement element)
      {
         int count;

         count = _dsImage.GetImageCount(element);
         for (int x = 0; x < count; x++)
         {
            RasterImage image;

            image = _dsImage.GetImage(element, x, 0, RasterByteOrder.Rgb | RasterByteOrder.Gray, _getImageFlags);

            if (image != null)
            {
               if (x == 0)
               {
                  _viewer.Image = image;
               }
               else
               {
                  _viewer.Image.AddPage(image);
               }
            }
            else
            {
               string err = string.Format("Error reading dicom image ");

               Messager.ShowError(this, err);
               break;
            }
         }

         if (_viewer.Image.PageCount > 0)
         {
            _viewer.Image.Page = 1;
         }
      }

      private void FillTreeModules()
      {
         for (int x = 0; x < _dsImage.ModuleCount; x++)
         {
            TreeNode node;
            DicomModule module;
            DicomIod iod;

            module = _dsImage.FindModuleByIndex(x);
            iod = DicomIodTable.Instance.FindModule(_dsImage.InformationClass, module.Type);

            node = _treeView_Elements.Nodes.Add(iod.Name);
            node.Tag = module;
            foreach (DicomElement element in module.Elements)
            {
               FillModuleSubTree(element, node, false);
            }
         }
      }

      void FillModuleSubTree(DicomElement element, TreeNode ParentNode, bool recurse)
      {
         TreeNode node;
         string name;
         string temp = "";
         DicomElement tempElement;

         DicomTag tag = DicomTagTable.Instance.Find(element.Tag);
         temp = string.Format("{0:x4}:{1:x4} - ", Utils.GetGroup((long)element.Tag), Utils.GetElement((long)element.Tag));

         if (tag == null)
            name = "Item";
         else
            name = tag.Name;

         temp = temp + name;

         if (ParentNode != null)
         {
            node = ParentNode.Nodes.Add(temp);
         }
         else
         {
            node = _treeView_Elements.Nodes.Add(temp);
         }

         node.Tag = element;

         if (_dsImage.IsVolatileElement(element))
         {
            node.ForeColor = Color.Red;
         }

         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         tempElement = _dsImage.GetChildElement(element, true);
         if (tempElement != null)
         {
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            FillModuleSubTree(tempElement, node, true);
         }

         if (recurse)
         {
            tempElement = _dsImage.GetNextElement(element, true, true);
            if (tempElement != null)
            {
               FillModuleSubTree(tempElement, ParentNode, true);
            }
         }
      }

      private bool IsDatasetValid()
      {
         DicomElement element;

         element = _dsImage.FindFirstElement(null, DemoDicomTags.SOPClassUID, true);
         if (element == null)
         {
            return false;
         }
         return true;
      }

      private void UpdateTree()
      {
         try
         {
            _treeView_Elements.BeginUpdate();
            _treeView_Elements.Nodes.Clear();
            FillTreeModules();
            _treeView_Elements.EndUpdate();
         }
         catch
         {
         }
      }

      private void EnableMenuItems(bool bEnable)
      {
         _menuItemView.Enabled = bEnable;
         _menuItem_Annotations.Enabled = bEnable;
      }

      private void menuItemFileSave_Click(object sender, System.EventArgs e)
      {
         PresentationStateDialog(true);

         _saveFileDialog.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*";
         _saveFileDialog.AddExtension = true;
         _saveFileDialog.Title = "Save Dicom File";
         if (_saveFileDialog.ShowDialog() == DialogResult.OK)
         {
            try
            {
               _dsImage.Save(_saveFileDialog.FileName, DicomDataSetSaveFlags.None);
               SaveDicomAnnotations(_saveFileDialog.FileName);
            }
            catch (DicomException de)
            {
               string err = string.Format("Error saving dicom dataset!\r\n\r\n{0}", de.Code.ToString());

               Messager.ShowError(this, err);
               return;
            }
         }
      }

      private void SaveDicomAnnotations(string datasetFileName)
      {
         if ((_dsImage != null))
         {
            _dicomAnnotationsUtilities.DisplayWidth = _viewer.Image.Width;
            _dicomAnnotationsUtilities.DisplayHeight = _viewer.Image.Height;

            SetPresentationStateInfo();

            DicomDataSet ds = new DicomDataSet();
            _dicomAnnotationsUtilities.FromAnnContainerToDataSet(ds, _automation.Container, _dsImage, string.Empty, string.Empty);

            string DirectoryName = Path.GetDirectoryName(datasetFileName);
            string fileName = Path.GetFileNameWithoutExtension(datasetFileName) + ".pre";
            try
            {
               ds.Save(Path.Combine(DirectoryName, fileName), DicomDataSetSaveFlags.None);
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex.Message);
            }
         }
      }

      private void PresentationStateDialog(bool useCurrentDate)
      {
         if (null != _presentation)
         {
            DateTime now = DateTime.Now;

            _presentationStateDialog.Presentation.InstanceNumber = _presentation.InstanceNumber;
            _presentationStateDialog.Presentation.PresentationLabel = _presentation.PresentationLabel;
            _presentationStateDialog.Presentation.PresentationDescription = _presentation.PresentationDescription;

            if ((_presentation.PresentationCreationDate.Year == 0) || useCurrentDate)
               _presentation.PresentationCreationDate = new DicomDateValue(now);

            if ((_presentation.PresentationCreationTime.Hours == 0) || useCurrentDate)
               _presentation.PresentationCreationTime = new DicomTimeValue(now);

            _presentationStateDialog.Presentation.CreationDate = _presentation.PresentationCreationDate.ToDateTime();
            _presentationStateDialog.Presentation.CreationTime = _presentation.PresentationCreationTime.ToDateTime();
         }

         if (_presentationStateDialog.ShowDialog() == DialogResult.OK)
         {
            _presentation.PresentationCreator = _presentationStateDialog.Presentation.PresentationCreator;
            _presentation.InstanceNumber = _presentationStateDialog.Presentation.InstanceNumber;
            _presentation.PresentationLabel = _presentationStateDialog.Presentation.PresentationLabel;
            _presentation.PresentationDescription = _presentationStateDialog.Presentation.PresentationDescription;
         }
      }

      private void DrawLeadAnnotationObject(AnnObject annObject)
      {
         if (_automation == null || _automation.Container == null || annObject == null)
            return;

         _automation.Container.Children.Add(annObject);
      }

      private void SetPresentationStateInfo()
      {
         _dicomAnnotationsUtilities.PresentationStateIdentification = new Leadtools.Dicom.Annotations.PresentationStateIdentificationModule();
         _dicomAnnotationsUtilities.PresentationStateIdentification.ContentCreatorName = _presentationStateDialog.Presentation.PresentationCreator;
         _dicomAnnotationsUtilities.PresentationStateIdentification.ContentDescription = _presentationStateDialog.Presentation.PresentationDescription;
         _dicomAnnotationsUtilities.PresentationStateIdentification.ContentLabel = _presentationStateDialog.Presentation.PresentationLabel;
         _dicomAnnotationsUtilities.PresentationStateIdentification.CreationDate = new DicomDateValue(_presentationStateDialog.Presentation.CreationDate);
         _dicomAnnotationsUtilities.PresentationStateIdentification.CreationTime = new DicomTimeValue(_presentationStateDialog.Presentation.CreationTime);
         _dicomAnnotationsUtilities.PresentationStateIdentification.InstanceNumber = _presentationStateDialog.Presentation.InstanceNumber;
      }

      private void CloseAnnotations()
      {
         if (_automation.CurrentDesigner != null)
         {
            _automation.CurrentDesigner.Cancel();
         }
         _automation.SelectObjects(null);
         _automation.Container.Children.Clear();

      }
   }


   //We will create custom viewer to work on default image resolution 
   public class MyAutomationImageViewer : AutomationImageViewer
   {
      public override double AutomationXResolution
      {
         get
         {
            return 96.0;
         }
      }

      public override double AutomationYResolution
      {
         get
         {
            return 96.0;
         }
      }
   }
   public class DISPLAYEDAREA
   {
      public int[] TLHCorner;       // Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
      public int[] BRHCorner;       // Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
      public DicomAnnotationSizeMode uSizeMode;       // Presentation Size Mode
      public double[] PixelSpacing;    // Presentation Pixel Spacing. User should allocate two L_DOUBLE memory units for Row spacing\Column spacing
      public int[] AspectRatio;    // Presentation Pixel Aspect Ratio. User should allocate two L_INT32 memory units for Row spacing\Column spacing
      public float fMagnifyRatio;   // Presentation Pixel Magnification Ratio

      public void ZeroOut()
      {
         TLHCorner = new int[2];       // Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
         BRHCorner = new int[2];       // Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
         uSizeMode = 0;       // Presentation Size Mode
         PixelSpacing = new double[2];    // Presentation Pixel Spacing. User should allocate two L_DOUBLE memory units for Row spacing\Column spacing
         AspectRatio = new int[2];    // Presentation Pixel Aspect Ratio. User should allocate two L_INT32 memory units for Row spacing\Column spacing
         fMagnifyRatio = 0.0f;
      }

      public DISPLAYEDAREA()
      {
         ZeroOut();
      }
   } ;

}
