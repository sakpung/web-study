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
using Leadtools.Twain;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools;
using Leadtools.Ocr;
using Leadtools.Barcode;
using Leadtools.Forms.Common;
using Leadtools.Forms.Auto;
using Leadtools.Forms.Recognition;
using Leadtools.Forms.Recognition.Barcode;
using Leadtools.Forms.Recognition.Ocr;
using FormsDemo;
using Leadtools.Forms.Processing;
using System.IO;
using System.Diagnostics;
using CSMasterFormsEditor.UI;

using Leadtools.Drawing;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using Leadtools.Controls;
using System.Drawing.Drawing2D;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.WinForms;
using System.Runtime.Serialization.Formatters.Binary;
#if FOR_DOTNET4
using Leadtools.Forms.Recognition.Search;
#endif

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif


namespace CSMasterFormsEditor
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      public MainForm(string MasterFormsPath)
      {
         InitializeComponent();

         _masterformspath = MasterFormsPath;
      }

      public MainForm(RasterImage MasterFormsImage, string MasterFormsName, string MasterFormsDirectory, FormsPageType pageType)
      {
         InitializeComponent();

         _masterformsimage = MasterFormsImage;
         _masterformsname = MasterFormsName;
         _masterformsdirectory = MasterFormsDirectory;
         _createdFormPageType = pageType;
      }

      private TwainSession twainSession = null;
      private RasterCodecs rasterCodecs;
      private IOcrEngine ocrEngine;
      private BarcodeEngine barcodeEngine;
      private FormRecognitionEngine recognitionEngine;
      private DiskMasterFormsRepository workingRepository;
      private AnnAutomationManager annAutomationManager = null;
      private AnnAutomation automation = null;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      private SelectMultiFieldsMode _currentSelectMode = SelectMultiFieldsMode.None;
      private FormsPageType _createdFormPageType = FormsPageType.Normal;

      RasterImage scannedImage = null;
      bool regionMode = false;
      bool cancelRegion = false;
      bool isFieldDirty = false;

      int oldSelectedPageIndex = 0;
      private string _openInitialPath = string.Empty;
      private string _masterformspath;
      private RasterImage _masterformsimage = null;
      private string _masterformsname = string.Empty;
      private string _masterformsdirectory = string.Empty;
      private Stream EditorStream = null;
      private enum SelectMultiFieldsMode
      {
         None,
         RenameFields,
         ChangeSensitivity,
         DeleteFields,
      }

      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get
         {
            return _noneInteractiveMode;
         }
         set
         {
            _noneInteractiveMode = value;
         }
      }

      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get
         {
            return _panInteractiveMode;
         }
         set
         {
            _panInteractiveMode = value;
         }
      }

      public ImageViewerZoomToInteractiveMode ZoomToInteractiveMode
      {
         get
         {
            return _zoomToInteractiveMode;
         }
         set
         {
            _zoomToInteractiveMode = value;
         }
      }

      private AutomationInteractiveMode _automationInteractiveMode = null;
      public AutomationInteractiveMode AutomationInteractiveMode
      {
         get
         {
            return _automationInteractiveMode;
         }
         set
         {
            _automationInteractiveMode = value;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            InitViewers();
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private AutomationImageViewer rasterImageViewer1;
      private ImageViewer rasterImageList1;

      private void InitViewers()
      {
         rasterImageViewer1 = new AutomationImageViewer();
         rasterImageViewer1.Dock = DockStyle.Fill;
         rasterImageViewer1.UseDpi = true;
         rasterImageViewer1.KeyUp += new KeyEventHandler(rasterImageViewer1_KeyUp);
         _splViewerList.Panel1.Controls.Add(rasterImageViewer1);
         rasterImageViewer1.BringToFront();


         rasterImageList1 = new ImageViewer(new ImageViewerHorizontalViewLayout() { Rows = 1 });
         rasterImageList1.Dock = DockStyle.Fill;
         rasterImageList1.ViewHorizontalAlignment = ControlAlignment.Center;
         rasterImageList1.ViewVerticalAlignment = ControlAlignment.Center;
         rasterImageList1.ItemSpacing = new LeadSize(20, 20);
         rasterImageList1.ItemBorderThickness = 2;
         rasterImageList1.SelectedItemBorderColor = Color.Blue;
         rasterImageList1.BackColor = SystemColors.AppWorkspace;
         rasterImageList1.BorderStyle = BorderStyle.FixedSingle;
         rasterImageList1.ItemSizeMode = ControlSizeMode.Fit;
         rasterImageList1.ItemSize = new LeadSize(180, 200);
         rasterImageList1.SelectedItemsChanged += new EventHandler(rasterImageList1_SelectedIndexChanged);
         rasterImageList1.InteractiveModes.Add(new ImageViewerSelectItemsInteractiveMode() { SelectionMode = ImageViewerSelectionMode.Single });
         _splViewerList.Panel2.Controls.Add(rasterImageList1);
         rasterImageList1.BringToFront();
      }

      private void Startup()
      {
         try
         {
            //Check if ocr engine was passed in. The recognition demos have the ability to launch this demo and it will pass
            //the ocr engine it is using. We will default to that engine
            string[] commandArgs = Environment.GetCommandLineArgs();
            if (commandArgs.Length == 2)
            {
               Properties.Settings settings = new Properties.Settings();
               settings.OcrEngineType = commandArgs[1];
               settings.Save();
            }

            if (!StartUpEngines())
            {
               Messager.ShowError(this, "One or more required engines did not start. The application will now close.");
               this.Close();
               return;
            }

            SetUpViewers();
            SetupAnnotations();

            Messager.Caption = "LEADTOOLS Master Forms Editor";
            _splFormsViewer.Panel2MinSize = 270;//Workaround for a bug in splitter container which restricts the values you can use for Panel2MinSize in the designer 


            //if (Properties.Settings.Default.FirstRun)
            //{
            //   MessageBox.Show("LEADTOOLS provides extra sample forms available for download online. For more information and the download link, please see the How-to document under Help-->How To.", "Sample Forms", MessageBoxButtons.OK);
            //   Properties.Settings.Default.FirstRun = false;
            //   Properties.Settings.Default.Save();
            //}

            //Load Default MasterForms Folder
            if (_masterformsname == string.Empty)
            {
               LoadMasterForms();
            }
            else
            {
               CreateMasterForms();
            }

            UpdateControls();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }

         _noneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _panInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();
         _automationInteractiveMode = new AutomationInteractiveMode();

         rasterImageViewer1.InteractiveModes.BeginUpdate();
         rasterImageViewer1.InteractiveModes.Add(_noneInteractiveMode);
         rasterImageViewer1.InteractiveModes.Add(_panInteractiveMode);
         rasterImageViewer1.InteractiveModes.Add(_zoomToInteractiveMode);
         rasterImageViewer1.InteractiveModes.Add(_automationInteractiveMode);
         rasterImageViewer1.InteractiveModes.EndUpdate();

         DisableInteractiveModes();

         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);

         UpdateControls();
      }

      private void LoadMasterForms()
      {
         try
         {
            CreateNewRepository(_masterformspath);

            //Clear viewer, imagelist, and fields
            if (rasterImageViewer1.Image != null && !rasterImageViewer1.Image.IsDisposed)
            {
               rasterImageViewer1.Image.Dispose();
               rasterImageViewer1.Image = null;
            }

            rasterImageList1.Items.Clear();
            BuildFieldList();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void CreateMasterForms()
      {
         try
         {
            IMasterFormsCategory parentCategory = null;
            TreeNode parentCategoryNode = null;
            if (_tvMasterForms.SelectedNode == null)
            {
               //nothing selected, add it to root category
               workingRepository = new DiskMasterFormsRepository(rasterCodecs, _masterformsdirectory);
               BuildMasterFormList(workingRepository.RootCategory, _tvMasterForms.Nodes, true);
               parentCategory = workingRepository.RootCategory;
               parentCategoryNode = _tvMasterForms.Nodes[0];
            }
            else
            {
               //if selected node is category, add it as child. Otherwise add it to parent of selected node
               Type type = _tvMasterForms.SelectedNode.Tag.GetType();
               if (type == typeof(DiskMasterFormsCategory))
               {
                  //selected node is category
                  parentCategory = _tvMasterForms.SelectedNode.Tag as IMasterFormsCategory;
                  parentCategoryNode = _tvMasterForms.SelectedNode;
               }
               else
               {
                  //selected node is master form
                  parentCategory = _tvMasterForms.SelectedNode.Parent.Tag as IMasterFormsCategory;
                  parentCategoryNode = _tvMasterForms.SelectedNode.Parent;
               }
            }

            //Add master form to repository and treeview
            IMasterForm newForm = parentCategory.AddMasterForm(CreateMasterForm(_masterformsname), null, (RasterImage)null);
            TreeNode newNode = parentCategoryNode.Nodes.Add(newForm.Name);
            newNode.Tag = newForm;
            _tvMasterForms.SelectedNode = newNode;

            if (_masterformsimage != null)
            {
               if (_createdFormPageType == FormsPageType.Normal)
                  PageTypeToolStripMenuItem_Click(normalItem, null);
               else if (_createdFormPageType == FormsPageType.IDCard)
                  PageTypeToolStripMenuItem_Click(cardItem, null);
               else if (_createdFormPageType == FormsPageType.Omr)
                  PageTypeToolStripMenuItem_Click(omrItem, null);

               AddMasterFormPages(_masterformsimage);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private AutomationManagerHelper _managerHelper = null;
      private void SetupAnnotations()
      {
         // create and setup the automation manager
         annAutomationManager = new AnnAutomationManager();
         annAutomationManager.CreateDefaultObjects();

         _managerHelper = new AutomationManagerHelper(annAutomationManager);
         //_magnagerHalper.ContextMenu = null;

         annAutomationManager.EditObjectAfterDraw = true;

         automation = new AnnAutomation(annAutomationManager, rasterImageViewer1);
         automation.AfterObjectChanged += new EventHandler<AnnAfterObjectChangedEventArgs>(automation_AfterObjectChanged);
         automation.Draw += new EventHandler<AnnDrawDesignerEventArgs>(Children_CollectionChanged);
         automation.Active = true;
         automation.CurrentDesignerChanged += new EventHandler(automation_CurrentDesignerChanged);
         automation.SetCursor += new EventHandler<AnnCursorEventArgs>(automation_SetCursor);
         automation.RestoreCursor += new EventHandler(automation_RestoreCursor);

         foreach (AnnAutomationObject obj in annAutomationManager.Objects)
         {
            obj.UseRotateThumbs = false;
            obj.ContextMenu = null;
            //if (obj.Id == AnnObject.GroupObjectId) //Remove the grouping object
            //   annAutomationManager.Objects.Remove(obj);
         }
      }

      void rasterImageViewer1_MouseUp(object sender, MouseEventArgs e)
      {
         //If no annotation is selected, make sure no field in the listbox is selected. keep them synched
         if (automation.CurrentEditObject == null)
         {
            _lbFields.SelectedIndex = -1;
            _lbFields_SelectedIndexChanged(this, null);

            _lbSelection.SelectedIndex = -1;
            _lbSelection_SelectedIndexChanged(this, null);

            _lbBubble.SelectedIndex = -1;
            _lbBubble_SelectedIndexChanged(this, null);
#if LEADTOOLS_V20_OR_LATER
            _lbAnswerArea.SelectedIndex = -1;
            _lbAnswerArea_SelectedIndexChanged(this, null);

            _lbOmrDate.SelectedIndex = -1;
            _lbOmrDate_SelectedIndexChanged(this, null);
#endif //#if LEADTOOLS_V20_OR_LATER
         }
      }

      private string GetFreeFieldName()
      {
         //Look for a field name that does not exist
         int i = 0;
         string newName = String.Empty;
         while (true)
         {
            newName = String.Format("New Field {0}", i);
            if (_lbFields.Items.IndexOf(newName) == -1
               && _lbSelection.Items.IndexOf(newName) == -1
               && _lbBubble.Items.IndexOf(newName) == -1
#if LEADTOOLS_V20_OR_LATER
               && _lbAnswerArea.Items.IndexOf(newName) == -1
               && _lbOmrDate.Items.IndexOf(newName) == -1)
#else
)
#endif //#if LEADTOOLS_V20_OR_LATER
               break;
            i++;
         }

         return newName;
      }

      void automation_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
      {
         if (automation.CurrentDesigner is AnnSelectionEditDesigner)
            return;

         if (e.ChangeType == AnnObjectChangedType.DesignerEdit)
         {
            if (e.Objects[0].Tag == null)
               return;

            if (e.Objects[0].Tag is SingleSelectionField || e.Objects[0].Tag is BubbleWordField
#if LEADTOOLS_V20_OR_LATER
                || e.Objects[0].Tag is OmrAnswerAreaField || e.Objects[0].Tag is OmrDateField)
#else
)
#endif //#if LEADTOOLS_V20_OR_LATER
               return;

            //Field was edited/moved
            string selectedFieldName = (e.Objects[0].Tag as FormField).Name;
            if (!String.IsNullOrEmpty(selectedFieldName))
            {
               int index = _lbFields.Items.IndexOf(selectedFieldName);
               if (_lbFields.SelectedIndex != index)
               {
                  //new annotation field selected
                  _lbFields.SelectedIndex = index;
               }
            }
            //Get it's position
            LeadRect newBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(e.Objects[0]));
            //Convert to rectangle to get whole number for pixel value

            LeadRect newBoundsRounded = newBounds;

            //Check if field moved
            if ((e.Objects[0].Tag as FormField).Bounds != newBoundsRounded)
            {
               isFieldDirty = true;
               UpdateField();
            }

            if (getSelectedField() is TableFormField)
               UpdateTable(getSelectedField() as TableFormField);

            if (getSelectedField() is UnStructuredTextFormField)
               UpdateUnStructuredText(getSelectedField() as UnStructuredTextFormField);

         }

         UpdateControls();
      }

      private void UpdateUnStructuredText(UnStructuredTextFormField UnStructuredTextField)
      {
         if (automation.CurrentEditObject is AnnTextObject || automation.CurrentEditObject is AnnHiliteObject)
         {
            LeadRect AreaBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(UnStructuredTextField.TextFormField.Tag as AnnObject));
            LeadRect FieldsBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(UnStructuredTextField.Tag as AnnObject));
            LeadRect newBounds = new LeadRect();
            if (UnStructuredTextField.TextFormField.Tag == automation.CurrentEditObject)
            {
               newBounds = new LeadRect(AreaBounds.X - FieldsBounds.X, Convert.ToInt32(0), (FieldsBounds.Right - FieldsBounds.X) - (AreaBounds.X - FieldsBounds.X), Convert.ToInt32(FieldsBounds.Height));
               if (newBounds.Width < 1 || newBounds.Width > FieldsBounds.Width)
               {
                  newBounds.X = (Convert.ToInt32(FieldsBounds.Width) - Convert.ToInt32(AreaBounds.Width));
                  newBounds.Width = Convert.ToInt32(AreaBounds.Width);
               }
            }
            else
            {
               newBounds = new LeadRect((Convert.ToInt32(FieldsBounds.Width) - Convert.ToInt32(AreaBounds.Width)), Convert.ToInt32(0), Convert.ToInt32(AreaBounds.Width), Convert.ToInt32(FieldsBounds.Height));
            }

            UnStructuredTextField.TextFormField.Bounds = newBounds;
            automation.Container.Children.Remove(UnStructuredTextField.TextFormField.Tag as AnnObject);

            AnnTextObject obj = null;
            obj = new AnnTextObject();
            UnStructuredTextField.TextFormField.Tag = obj;
            automation.Container.Children.Add(obj);
            ColorConverter c = new ColorConverter();
            string st = c.ConvertToString(Color.FromArgb(64, 0, 0, 0));
            obj.Fill = AnnSolidColorBrush.Create(st);
            obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), new LeadLengthD(1));

            obj = UnStructuredTextField.TextFormField.Tag as AnnTextObject;

            if (!automation.Container.Children.Contains(obj))
               automation.Container.Children.Add(obj);

            obj.Text = UnStructuredTextField.TextFormField.Name;
            LeadRect lrc = UnStructuredTextField.TextFormField.Bounds;
            lrc.Offset(UnStructuredTextField.Bounds.Location);
            RectangleF rc = new RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height);
            obj.Rect = BoundsToAnnotations(obj, rc);
            obj.Tag = UnStructuredTextField;
            UnStructuredTextField.TextFormField.Tag = obj;
         }
         rasterImageViewer1.Invalidate();
      }

      private void UpdateTable(TableFormField tableField)
      {
         if (automation.CurrentEditObject is AnnHiliteObject)
         {
            LeadRect rc;
            rc = tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds;
            rc.Width = tableField.Bounds.Width - rc.Left;
            tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds = rc;

            updateColumnsPosition(tableField);
         }

         if (automation.CurrentEditObject is AnnTextObject)
         {
            for (int i = 0; i < tableField.Columns.Count; i++)
            {
               if (tableField.Columns[i].Tag == automation.CurrentEditObject)
               {
                  LeadRect columnBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(tableField.Columns[i].Tag as AnnObject));
                  LeadRect tableBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(tableField.Tag as AnnObject));

                  if (tableBounds.Height == columnBounds.Height && LeadRect.Intersect(tableBounds, columnBounds) != LeadRect.Empty)
                  {
                     LeadRect newBounds = new LeadRect(columnBounds.X - tableBounds.X, Convert.ToInt32(0), Convert.ToInt32(columnBounds.Width), Convert.ToInt32(tableBounds.Height));
                     if (!IsOverlapped(tableField.Columns[i], newBounds, tableField))
                     {
                        bool bIsLeft = newBounds.Right == tableField.Columns[i].OcrField.Bounds.Right;

                        tableField.Columns[i].OcrField.Bounds = newBounds;

                        LeadRect rc;
                        if (bIsLeft || i == tableField.Columns.Count - 1)
                        {
                           rc = tableField.Columns[i - 1].OcrField.Bounds;
                           rc.Width = Math.Abs(newBounds.Left - rc.Left);
                           tableField.Columns[i - 1].OcrField.Bounds = rc;
                        }
                        else
                        {
                           rc = tableField.Columns[i + 1].OcrField.Bounds;
                           rc.Width = Math.Abs(newBounds.Right - rc.Right);
                           tableField.Columns[i + 1].OcrField.Bounds = rc;
                        }
                        updateColumnsPosition(tableField);
                     }
                  }
                  break;
               }
            }
         }

         updateColumnsList(tableField as TableFormField);
         AlignmentTableFields(tableField as TableFormField);
      }

      private bool IsOverlapped(TableColumn Column, LeadRect newBounds, TableFormField tableField)
      {
         if (Column.OcrField.Bounds.Width == newBounds.Width)
            return true;
         else if (newBounds.Right > tableField.Bounds.Width)
            return true;
         else if (newBounds.Left < 0)
            return true;
         else if (newBounds.Right <= Column.OcrField.Bounds.Left)
            return true;
         else if (newBounds.Left >= Column.OcrField.Bounds.Right)
            return true;

         for (int i = 0; i < tableField.Columns.Count; i++)
         {
            if (Column.Tag == tableField.Columns[i].Tag)
            {
               if (i == 0 && newBounds.Left != 0)
                  return true;
               else if (i + 2 < tableField.Columns.Count && newBounds.IntersectsWith(tableField.Columns[i + 2].OcrField.Bounds))
                  return true;
               else if (i - 2 >= 0 && newBounds.IntersectsWith(tableField.Columns[i - 2].OcrField.Bounds))
                  return true;
            }
         }
         return false;
      }

      private void UnStructuredTextFormFieldDisplay(UnStructuredTextFormField UnStructuredTextField)
      {
         if (UnStructuredTextField != null)
         {
            AnnHiliteObject hiliteObject = UnStructuredTextField.Tag as AnnHiliteObject;
            LeadRect tableRect = UnStructuredTextField.Bounds;
            RectangleF tablerc = new RectangleF(tableRect.Left, tableRect.Top, tableRect.Width, tableRect.Height);
            hiliteObject.Rect = BoundsToAnnotations(hiliteObject, tablerc);

            AnnTextObject obj = null;
            obj = new AnnTextObject();
            UnStructuredTextField.TextFormField.Tag = obj;
            automation.Container.Children.Add(obj);
            ColorConverter c = new ColorConverter();
            string st = c.ConvertToString(Color.FromArgb(64, 0, 0, 0));
            obj.Fill = AnnSolidColorBrush.Create(st);
            obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), new LeadLengthD(1));

            obj = UnStructuredTextField.TextFormField.Tag as AnnTextObject;

            if (!automation.Container.Children.Contains(obj))
               automation.Container.Children.Add(obj);

            obj.Text = UnStructuredTextField.TextFormField.Name;
            LeadRect lrc = UnStructuredTextField.TextFormField.Bounds;
            lrc.Offset(UnStructuredTextField.Bounds.Location);
            RectangleF rc = new RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height);
            obj.Rect = BoundsToAnnotations(obj, rc);
            obj.Tag = UnStructuredTextField;
            UnStructuredTextField.TextFormField.Tag = obj;
         }
         rasterImageViewer1.Invalidate();
      }

#if LEADTOOLS_V20_OR_LATER
      private void OmrDateFieldDisplay(OmrDateField omrDateField)
      {
         if (omrDateField != null)
         {
            AnnObject newObject = omrDateField.Tag as AnnObject;

            if (newObject != null)
            {
               newObject.Opacity = 0.3;
               newObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(2));
            }

            AnnRectangleObject newRectObject = null;

            if (newObject != null)
            {
               newRectObject = new AnnRectangleObject(newObject.Bounds);

               string st = new ColorConverter().ConvertToString(Color.FromArgb(93, 255, 100, 100));
               newRectObject.Fill = AnnSolidColorBrush.Create(st);
               newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(2));

               automation.Container.Children.Add(newRectObject);
               automation.Container.Children.Remove(newObject);
               omrDateField.Tag = newRectObject;
               newRectObject.Tag = omrDateField;
            }

            SingleSelectionFieldDisplay(omrDateField.MonthField);
            BubbleWordFieldDisplay(omrDateField.YearField);
            BubbleWordFieldDisplay(omrDateField.DayField);
         }
      }

      private void AnswerAreaFieldDisplay(OmrAnswerAreaField answerAreaField)
      {
         if (answerAreaField != null)
         {
            AnnObject newObject = answerAreaField.Tag as AnnObject;

            if (newObject != null)
            {
               newObject.Opacity = 0.3;
               newObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Aqua"), new LeadLengthD(2));
            }

            AnnRectangleObject newRectObject = null;

            if (newObject != null)
            {
               newRectObject = new AnnRectangleObject(newObject.Bounds);

               string st = new ColorConverter().ConvertToString(Color.FromArgb(93, 100, 192, 255));
               newRectObject.Fill = AnnSolidColorBrush.Create(st);
               newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Aqua"), new LeadLengthD(2));

               automation.Container.Children.Add(newRectObject);
               automation.Container.Children.Remove(newObject);
               answerAreaField.Tag = newRectObject;
               newRectObject.Tag = answerAreaField;
            }

            foreach (SingleSelectionField field in answerAreaField.Answers)
               SingleSelectionFieldDisplay(field);
         }
      }
#endif //#if LEADTOOLS_V20_OR_LATER

      private void BubbleWordFieldDisplay(BubbleWordField bubbleWordField)
      {
         if (bubbleWordField != null)
         {
            LeadRect bubbleWordRect = bubbleWordField.Bounds;

            AnnObject newObject = bubbleWordField.Tag as AnnObject;

            if (newObject != null)
            {
               newObject.Opacity = 0.3;
               newObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(2));
            }

            AnnRectangleObject newRectObject = null;

            if (newObject != null)
            {
               newRectObject = new AnnRectangleObject(newObject.Bounds);
               automation.Container.Children.Remove(newObject);
            }
            else
            {
               LeadRectD transformedRect = BoundsToAnnotations(null, new RectangleF((float)bubbleWordField.Bounds.X, (float)bubbleWordField.Bounds.Y, (float)bubbleWordField.Bounds.Width, (float)bubbleWordField.Bounds.Height));
               newRectObject = new AnnRectangleObject(transformedRect);
            }

            string st = new ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203));
            newRectObject.Fill = AnnSolidColorBrush.Create(st);
            newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(2));

            automation.Container.Children.Add(newRectObject);

            bubbleWordField.Tag = newRectObject;
            newRectObject.Tag = bubbleWordField;

            if (String.IsNullOrEmpty(bubbleWordField.Parent))
               foreach (SingleSelectionField field in bubbleWordField.Fields)
               {
                  field.Parent = bubbleWordField.Name;
                  SingleSelectionFieldDisplay(field);
               }
         }

         rasterImageViewer1.Invalidate();
      }

      private void SingleSelectionFieldDisplay(SingleSelectionField singleSelection)
      {
         if (singleSelection != null)
         {
            LeadRect selectionRect = singleSelection.Bounds;
            List<LeadRect> objectsRects = new List<LeadRect>();
            LeadRect nameRect = singleSelection.NameBounds;

            for (int i = 0; i < singleSelection.Fields.Count; ++i)
               objectsRects.Add(singleSelection.Fields[i].Bounds);

            AnnObject newObject = singleSelection.Tag as AnnObject;
            AnnRectangleObject newRectObject = null;

            if (newObject != null)
            {
               newRectObject = new AnnRectangleObject(newObject.Bounds);

               string st = new ColorConverter().ConvertToString(Color.FromArgb(30, 255, 0, 0));
               newRectObject.Fill = AnnSolidColorBrush.Create(st);
               newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(1));

               automation.Container.Children.Add(newRectObject);
               automation.Container.Children.Remove(newObject);
               singleSelection.Tag = newRectObject;
               newRectObject.Tag = singleSelection;
            }

            AnnRectangleObject obj = new AnnRectangleObject();

            automation.Container.Children.Add(obj);
            ColorConverter c = new ColorConverter();
            string color = c.ConvertToString(Color.FromArgb(20, 0, 0, 0));

            obj.Fill = AnnSolidColorBrush.Create(color);
            obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(1));
            obj.Tag = singleSelection;

            obj.Rect = BoundsToAnnotations(obj, new RectangleF(nameRect.Left, nameRect.Top, nameRect.Width, nameRect.Height));

            if (objectsRects != null)
            {
               foreach (LeadRect fieldRect in objectsRects)
               {
                  AnnRectangleObject fieldObject = new AnnRectangleObject();
                  automation.Container.Children.Add(fieldObject);

                  fieldObject.Fill = AnnSolidColorBrush.Create(color);
                  fieldObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(1));
                  fieldObject.Tag = singleSelection;

                  fieldObject.Rect = BoundsToAnnotations(obj, new RectangleF(fieldRect.Left, fieldRect.Top, fieldRect.Width, fieldRect.Height));
               }
            }
         }

         rasterImageViewer1.Invalidate();
      }

      private void AlignmentTableFields(TableFormField tableField)
      {
         if (tableField != null)
         {
            AnnHiliteObject hiliteObject = tableField.Tag as AnnHiliteObject;
            LeadRect tableRect = tableField.Bounds;
            RectangleF tablerc = new RectangleF(tableRect.Left, tableRect.Top, tableRect.Width, tableRect.Height);
            hiliteObject.Rect = BoundsToAnnotations(hiliteObject, tablerc);


            foreach (TableColumn column in tableField.Columns)
            {
               AnnTextObject obj = null;

               if (column.Tag == null)
               {
                  obj = new AnnTextObject();
                  column.Tag = obj;
                  automation.Container.Children.Add(obj);
                  obj.TextForeground = AnnSolidColorBrush.Create("Black");
                  ColorConverter c = new ColorConverter();
                  string st = c.ConvertToString(Color.FromArgb(64, 0, 0, 0));
                  obj.Fill = AnnSolidColorBrush.Create(st);
                  obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), new LeadLengthD(1));
                  obj.Font = new AnnFont("Arial", 12);
               }

               obj = column.Tag as AnnTextObject;

               if (!automation.Container.Children.Contains(obj))
                  automation.Container.Children.Add(obj);

               obj.Text = column.OcrField.Name;
               LeadRect lrc = column.OcrField.Bounds;
               lrc.Offset(tableField.Bounds.Location);
               RectangleF rc = new RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height);
               obj.Rect = BoundsToAnnotations(obj, rc);
               obj.Tag = tableField;
               column.Tag = obj;
            }

            rasterImageViewer1.Invalidate();
            UpdateControls();
         }
      }

      private LeadRect BoundsFromAnnotations(AnnObject annObject)
      {
         if (annObject == null)
            return LeadRect.Empty;

         // Convert a rectangle from annotation object to logical coordinates (top-left)
         LeadRectD temp = automation.Container.Mapper.RectFromContainerCoordinates(annObject.Bounds, AnnFixedStateOperations.None);

         temp = rasterImageViewer1.ConvertRect(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, temp);

         RectangleF rc = new RectangleF((float)temp.X, (float)temp.Y, (float)temp.Width, (float)temp.Height);

         LeadRect rect = new LeadRect((int)Math.Round(rc.Left), (int)Math.Round(rc.Top), (int)Math.Round(rc.Width), (int)Math.Round(rc.Height));
         return rect;
      }

      private LeadRectD BoundsToAnnotations(AnnObject annObject, RectangleF rect)
      {
         // Convert a rectangle from logical (top-left) to annotation object coordinates
         LeadRectD rc = new LeadRectD(Math.Max(rect.X, 0), Math.Max(rect.Y, 0), Math.Max(rect.Width, 0), Math.Max(rect.Height, 0));

         rc = rasterImageViewer1.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc);

         rc = automation.Container.Mapper.RectToContainerCoordinates(rc);
         return rc;
      }

      private LeadRect RestrictZoneBoundsToPage(RasterImage image, LeadRect bounds)
      {
         LeadRect pageBounds = new LeadRect(0, 0, image.Width, image.Height);
         LeadRect rc = bounds;

         rc = LeadRect.Intersect(pageBounds, rc);

         return rc;
      }

      private string GetFormsDir()
      {
         string formsDir;
         formsDir = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets";

         if (ocrEngine.EngineType == OcrEngineType.LEAD)
         {
            formsDir += "\\OCR";
         }

         return formsDir;
      }

      private void SetUpViewers()
      {
         try
         {
            RasterPaintProperties properties = RasterPaintProperties.Default;
            properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic | RasterPaintDisplayModeFlags.ScaleToGray;
            properties.PaintEngine = RasterPaintEngine.Gdi;
            properties.UsePaintPalette = true;
            rasterImageViewer1.PaintProperties = properties;
            rasterImageViewer1.UseDpi = _btnUseDpi.Checked;
            rasterImageList1.UseDpi = _btnUseDpi.Checked;
            rasterImageList1.PaintProperties = properties;
            rasterImageViewer1.MouseUp += new MouseEventHandler(rasterImageViewer1_MouseUp);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void StartupTwain()
      {
         try
         {
            twainSession = new TwainSession();
            if (TwainSession.IsAvailable(this.Handle))
            {
               twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
               twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(twainSession_AcquirePage);
            }
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               twainSession = null;
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
            }
            else
            {
               twainSession = null;
               Messager.ShowError(this, ex);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            twainSession = null;
         }
      }

      public bool StartUpEngines()
      {
         try
         {
            StartUpRasterCodecs();
            StartUpOcrEngine();
            StartUpBarcodeEngine();
            StartupTwain();
            SetupRecognitionEngine();
            return true;
         }
         catch
         {
            return false;
         }
      }

      private void ShutDownEngines()
      {
         if (ocrEngine != null && ocrEngine.IsStarted)
         {
            Properties.Settings settings = new Properties.Settings();
            settings.OcrEngineType = ocrEngine.EngineType.ToString();
            settings.Save();

            ocrEngine.Shutdown();
            ocrEngine.Dispose();
         }

         if (twainSession != null)
            twainSession.Shutdown();
      }

      private void StartUpRasterCodecs()
      {
         try
         {
            rasterCodecs = new RasterCodecs();

            //To turn off the dithering method when converting colored images to 1-bit black and white image during the load
            //so the text in the image is not damaged.
            RasterDefaults.DitheringMethod = RasterDitheringMethod.None;
            rasterCodecs.Options.Load.Resolution = 300;
            rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void StartUpOcrEngine()
      {
         try
         {
            Properties.Settings settings = new Properties.Settings();
            string engineType = settings.OcrEngineType;

            // Show the engine selection dialog
            using (OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, false))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  ocrEngine = OcrEngineManager.CreateEngine(dlg.SelectedOcrEngineType, false);
                  ocrEngine.Startup(null, null, null, null);
                  this.Text = String.Format("{0} [{1} Engine]", this.Text, dlg.SelectedOcrEngineType.ToString());

                  if (ocrEngine.EngineType != OcrEngineType.LEAD)
                  {
                     _rbtextTypeData.Visible = false;
                     _gbFieldTextType.Size = new Size(_gbFieldTextType.Size.Width, 75);
                  }
                  else
                  {
                     if (ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff"))
                        ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate");
                  }
               }
               else
                  throw new Exception("No engine selected.");
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void StartUpBarcodeEngine()
      {
         try
         {
            barcodeEngine = new BarcodeEngine();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void SetupRecognitionEngine()
      {
         try
         {
            if (recognitionEngine == null)
               recognitionEngine = new FormRecognitionEngine();

            //Add appropriate object managers to recognition engine
            recognitionEngine.ObjectsManagers.Clear();
            if (_menuItemDefaultManager.Checked)
            {
               DefaultObjectsManager defaultObjectManager = new DefaultObjectsManager();
               recognitionEngine.ObjectsManagers.Add(defaultObjectManager);
            }

            if (_menuItemOCRManager.Checked && ocrEngine.IsStarted)
            {
               OcrObjectsManager ocrObejectManager = new OcrObjectsManager(ocrEngine);
               ocrObejectManager.Engine = ocrEngine;
               recognitionEngine.ObjectsManagers.Add(ocrObejectManager);
            }

            if (_menuItemBarcodeManager.Checked && barcodeEngine != null)
            {
               BarcodeObjectsManager barcodeObjectManager = new BarcodeObjectsManager(barcodeEngine);
               barcodeObjectManager.Engine = barcodeEngine;
               recognitionEngine.ObjectsManagers.Add(barcodeObjectManager);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void LoadFormSet_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         try
         {
            FolderBrowserDialogEx fbd = new FolderBrowserDialogEx();
            fbd.Description = "Please select the root directory for your master form set.";
            fbd.SelectedPath = GetFormsDir();
            fbd.ShowFullPathInEditBox = true;
            fbd.ShowEditBox = true;
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
               CreateNewRepository(fbd.SelectedPath);

               //Clear viewer, imagelist, and fields
               if (rasterImageViewer1.Image != null && !rasterImageViewer1.Image.IsDisposed)
               {
                  rasterImageViewer1.Image.Dispose();
                  rasterImageViewer1.Image = null;
               }

               rasterImageList1.Items.Clear();
               BuildFieldList();
            }

         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void BuildMasterFormList(IMasterFormsCategory rootCategory, TreeNodeCollection nodes, bool clearExisting)
      {
         if (clearExisting)
         {
            //Loading new master form set
            _tvMasterForms.Nodes.Clear();
            TreeNode rootNode = nodes.Add("MasterForms");
            rootNode.Tag = rootCategory;
            BuildMasterFormList(rootCategory, rootNode.Nodes, false);
            rootNode.Expand();
         }
         else
         {
            //Processing child categories (from recursion)
            foreach (IMasterForm masterForm in rootCategory.MasterForms)
            {
               TreeNode masterFormNode = nodes.Add(masterForm.Name);
               masterFormNode.Tag = masterForm;
            }

            foreach (IMasterFormsCategory childCategory in rootCategory.ChildCategories)
            {
               TreeNode childNode = nodes.Add(childCategory.Name);
               childNode.Tag = childCategory;
               BuildMasterFormList(childCategory, childNode.Nodes, false);
            }
         }
         UpdateControls();
      }

      private void _tvMasterForms_AfterSelect(object sender, TreeViewEventArgs e)
      {
         try
         {
            //Clear viewer and image list
            if (rasterImageViewer1.Image != null && !rasterImageViewer1.Image.IsDisposed)
            {
               rasterImageViewer1.Image.Dispose();
               rasterImageViewer1.Image = null;
            }
            rasterImageList1.Items.Clear();
            _lbFields.SelectedIndex = -1;
            _lbSelection.SelectedIndex = -1;
            _lbBubble.SelectedIndex = -1;
#if LEADTOOLS_V20_OR_LATER
            _lbAnswerArea.SelectedIndex = -1;
            _lbOmrDate.SelectedIndex = -1;
            _lbAnswerArea.Items.Clear();
            _lbOmrDate.Items.Clear();
#endif //#if LEADTOOLS_V20_OR_LATER
            _lbFields.Items.Clear();
            _lbSelection.Items.Clear();
            _lbBubble.Items.Clear();

            if (e.Node.Tag != null)
            {
               Type type = e.Node.Tag.GetType();
               if (type == typeof(DiskMasterFormsCategory))
               {

               }
               else if (type == typeof(DiskMasterForm))
               {
                  //A new master form has been selected. 
                  BuildMasterPageList();
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void BuildMasterPageList()
      {
         //Clear viewer and image list
         if (rasterImageViewer1.Image != null && !rasterImageViewer1.Image.IsDisposed)
         {
            rasterImageViewer1.Image.Dispose();
            rasterImageViewer1.Image = null;
         }
         rasterImageList1.Items.Clear();
         _lbFields.Items.Clear();

         //Add pages of master form to imagelist
         DiskMasterForm currentMasterForm = GetCurrentMasterForm();
         if (currentMasterForm == null)
            return;

         RasterImage masterImage = currentMasterForm.ReadForm();
         if (masterImage != null)
         {
            for (int i = 0; i < masterImage.PageCount; i++)
            {
               masterImage.Page = i + 1;
               ImageViewerItem item = new ImageViewerItem();
               item.Image = masterImage.Clone();
               rasterImageList1.Items.Add(item);
            }
            if (masterImage != null && !masterImage.IsDisposed)
               masterImage.Dispose();

            if (rasterImageList1.Items.Count > 0)
            {
               rasterImageList1.Items[0].IsSelected = true;
               rasterImageList1_SelectedIndexChanged(this, null);
            }
         }
         UpdateControls();
      }

      private void BuildFieldList()
      {
         if (_lbFields.IsDisposed)
            return;

         //Add fields for current form and page to listbox
         _lbFields.Items.Clear();
         automation.SelectObject(null);

         automation.Container.Children.Clear();

         DiskMasterForm currentMasterForm = GetCurrentMasterForm();
         if (currentMasterForm == null)
            return;

         if (rasterImageList1.Items.Count == 0)
            return;

         FormPages formPages = currentMasterForm.ReadFields();

         if (formPages != null)
         {
            int currentPage = 0;
            for (int i = 0; i < rasterImageList1.Items.Count; i++)
            {
               if (rasterImageList1.Items[i].IsSelected)
               {
                  currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
                  break;
               }
            }

            List<FormField> highLevelFields = new List<FormField>();

            foreach (FormField field in formPages[currentPage])
            {
               if (field is SingleSelectionField || field is BubbleWordField
#if LEADTOOLS_V20_OR_LATER
                   || field is OmrAnswerAreaField || field is OmrDateField)
#else
)
#endif //#if LEADTOOLS_V20_OR_LATER
               {
                  highLevelFields.Add(field);
               }
               else
               {
                  AddField(field);
               }
            }

            if (highLevelFields.Count > 0)
            {
               foreach (FormField field in highLevelFields)
               {
                  AddField(field);
               }
            }

            if (_lbFields.Items.Count > 0)
            {
               //Select first field
               _lbFields.SelectedIndex = 0;
            }
         }

         UpdateControls();
      }

      private void AddField(FormField fieldToAdd)
      {
         if (!(fieldToAdd is SingleSelectionField) && !(fieldToAdd is BubbleWordField)
#if LEADTOOLS_V20_OR_LATER
            && !(fieldToAdd is OmrAnswerAreaField) && !(fieldToAdd is OmrDateField))
#else
)
#endif //#if LEADTOOLS_V20_OR_LATER
         {
            _lbFields.Items.Add(fieldToAdd.Name);
         }
#if LEADTOOLS_V20_OR_LATER
         else if (fieldToAdd is OmrAnswerAreaField)
         {
            if (!_lbAnswerArea.Items.Contains(fieldToAdd.Name))
            {
               _lbAnswerArea.Items.Add(fieldToAdd.Name);
            }
         }
         else if (fieldToAdd is OmrDateField)
         {
            if (!_lbOmrDate.Items.Contains(fieldToAdd.Name))
            {
               _lbOmrDate.Items.Add(fieldToAdd.Name);
            }
         }
#endif //#if LEADTOOLS_V20_OR_LATER
         else if (fieldToAdd is SingleSelectionField)
         {
            if (!_lbSelection.Items.Contains(fieldToAdd.Name))
            {
               if (String.IsNullOrEmpty((fieldToAdd as SingleSelectionField).Parent))
                  _lbSelection.Items.Add(fieldToAdd.Name);
            }
         }
         else if (fieldToAdd is BubbleWordField)
         {
            if (!_lbBubble.Items.Contains(fieldToAdd.Name))
            {
               _lbBubble.Items.Add(fieldToAdd.Name);
            }
         }

         AnnHiliteObject annotationField = new AnnHiliteObject();
         annotationField.Tag = fieldToAdd;
         annotationField.HiliteColor = GetHighlightColor(fieldToAdd.GetType());

         //temporarily disable item added event so it does not fire while adding these fields
         automation.Draw -= new EventHandler<AnnDrawDesignerEventArgs>(Children_CollectionChanged);
         automation.Container.Children.Add(annotationField);
         automation.Draw += new EventHandler<AnnDrawDesignerEventArgs>(Children_CollectionChanged);

         // Now we can calculate the object bounds correctly

         LeadRect lrc = fieldToAdd.Bounds;
         RectangleF rc = new RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height);

         LeadRectD rect = BoundsToAnnotations(annotationField, rc);
         annotationField.Rect = rect;

         if (fieldToAdd is TableFormField)
         {
            fieldToAdd.Tag = annotationField;
            updateColumnsList(fieldToAdd as TableFormField);
            AlignmentTableFields(fieldToAdd as TableFormField);
         }

         if (fieldToAdd is UnStructuredTextFormField)
         {
            fieldToAdd.Tag = annotationField;
            UnStructuredTextFormFieldDisplay(fieldToAdd as UnStructuredTextFormField);
         }
#if LEADTOOLS_V20_OR_LATER
         if (fieldToAdd is OmrAnswerAreaField)
         {
            fieldToAdd.Tag = annotationField;
            AnswerAreaFieldDisplay(fieldToAdd as OmrAnswerAreaField);
            automation.Container.Children.BringToFront(fieldToAdd.Tag as AnnObject, true);
         }

         if (fieldToAdd is OmrDateField)
         {
            fieldToAdd.Tag = annotationField;
            OmrDateFieldDisplay(fieldToAdd as OmrDateField);
            automation.Container.Children.BringToFront(fieldToAdd.Tag as AnnObject, true);
         }
#endif //#if LEADTOOLS_V20_OR_LATER

         if (fieldToAdd is SingleSelectionField)
         {
            fieldToAdd.Tag = annotationField;
            SingleSelectionFieldDisplay(fieldToAdd as SingleSelectionField);
            automation.Container.Children.BringToFront(fieldToAdd.Tag as AnnObject, true);
         }

         if (fieldToAdd is BubbleWordField)
         {
            if (String.IsNullOrEmpty((fieldToAdd as BubbleWordField).Parent))
            {
               fieldToAdd.Tag = annotationField;
               BubbleWordFieldDisplay(fieldToAdd as BubbleWordField);
               automation.Container.Children.BringToFront(fieldToAdd.Tag as AnnObject, true);
            }
         }
      }

#if LEADTOOLS_V20_OR_LATER
      private void SetOmrDateParentName(OmrDateField omrDateField)
      {
         omrDateField.MonthField.Parent = omrDateField.Name;
         omrDateField.DayField.Parent = omrDateField.Name;
         for (int i = 0; i < omrDateField.DayField.Fields.Count; ++i)
         {
            omrDateField.DayField.Fields[i].Tag = omrDateField;
            omrDateField.DayField.Fields[i].Parent = omrDateField.Name;
         }
         omrDateField.YearField.Parent = omrDateField.Name;
         for (int i = 0; i < omrDateField.YearField.Fields.Count; ++i)
         {
            omrDateField.YearField.Fields[i].Tag = omrDateField;
            omrDateField.YearField.Fields[i].Parent = omrDateField.Name;
         }
      }
#endif //#if LEADTOOLS_V20_OR_LATER

      private List<FormField> GetOmrFormFields()
      {
         List<FormField> fields = new List<FormField>();

         foreach (AnnObject annotationField in automation.Container.Children)
         {
            FormField currentField = annotationField.Tag as OmrFormField;
            if (currentField != null)
            {
               if (!fields.Contains(currentField))
                  fields.Add(currentField);
            }
         }

         return fields;
      }
      void Children_CollectionChanged(object sender, AnnDrawDesignerEventArgs e)
      {

         if (e.OperationStatus == AnnDesignerOperationStatus.End)
         {

            CheckToolButtons(_btnPointerTool);
            if (regionMode)
               return;

            try
            {
               //No object added yet
               if (e.Object == null || e.Object.Bounds == LeadRectD.Empty)
                  return;

               AnnHiliteObject newObject = e.Object as AnnHiliteObject;
               FormField newField = null;

               if (newObject == null)
                  return;

               //Check the type of field drawn
               if (newObject.HiliteColor == "Green")
               {
                  if (newObject.Tag == null)
                  {
                     //This is a new field
                     newField = new TextFormField();
                  }
                  else
                  {
                     //This is a pasted field
                     newField = newObject.Tag as TextFormField;
                  }
               }
               else if (newObject.HiliteColor == "Purple")
               {
                  if (newObject.Tag == null)
                  {
                     //This is a new field
                     newField = new OmrFormField();
                  }
                  else
                  {
                     //This is a pasted field
                     newField = newObject.Tag as OmrFormField;
                  }
               }
               else if (newObject.HiliteColor == "Yellow")
               {
                  if (newObject.Tag == null)
                  {
                     //This is a new field
                     newField = new ImageFormField();
                  }
                  else
                  {
                     //This is a pasted field
                     newField = newObject.Tag as ImageFormField;
                  }
               }
               else if (newObject.HiliteColor == "Orange")
               {
                  if (newObject.Tag == null)
                  {
                     //This is a new field
                     newField = new BarcodeFormField();
                  }
                  else
                  {
                     //This is a pasted field
                     newField = newObject.Tag as BarcodeFormField;
                  }
               }
               else if (newObject.HiliteColor == "Red")
               {
                  if (newObject.Tag == null)
                  {
                     //This is a new field
                     newField = new TableFormField();
                  }
                  else
                  {
                     //This is a pasted field
                     newField = newObject.Tag as TableFormField;
                  }
               }
               else if (newObject.HiliteColor == "DarkSeaGreen")
               {
                  if (newObject.Tag == null)
                  {
                     //This is a new field
                     newField = new UnStructuredTextFormField();
                  }
                  else
                  {
                     //This is a pasted field
                     newField = newObject.Tag as UnStructuredTextFormField;
                  }
               }
               else if (newObject.HiliteColor == "Brown")
               {
                  if (newObject.Tag == null)
                  {
                     int currentPage = 0;
                     for (int i = 0; i < rasterImageList1.Items.Count; i++)
                     {
                        if (rasterImageList1.Items[i].IsSelected)
                           currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
                     }

                     LeadRect objectBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(e.Object as AnnObject));

                     LeadRect bounds = new LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height);

                     List<FormField> fields = GetOmrFormFields();

                     SingleSelectionField singleSelectionField = GetCurrentMasterForm().CreateSingleSelectionField(fields, bounds, currentPage + 1);
                     
                     if (singleSelectionField == null)
                     {
                        automation.Container.Children.Remove(newObject);
                        rasterImageViewer1.Invalidate();
                        return;
                     }

                     newObject.Tag = singleSelectionField;
                     singleSelectionField.Tag = newObject;

                     if (String.IsNullOrEmpty(singleSelectionField.Name))
                     {
                        singleSelectionField.Name = GetFreeFieldName();
                     }

                     SingleSelectionFieldDisplay(singleSelectionField);

                     SingleSelectionFieldDlg dlg = new SingleSelectionFieldDlg(this, singleSelectionField);
                     if (dlg.ShowDialog() == DialogResult.Cancel)
                     {
                        for (int i = automation.Container.Children.Count - 1; i >= 0; --i)
                        {
                           if (automation.Container.Children[i].Tag == singleSelectionField)
                              automation.Container.Children.RemoveAt(i);
                        }
                        rasterImageViewer1.Invalidate();

                        return;
                     }

                     if (!_lbSelection.Items.Contains(singleSelectionField.Name))
                        _lbSelection.Items.Add(singleSelectionField.Name);

                     automation.Container.Children.BringToFront(singleSelectionField.Tag as AnnObject, true);

                     DisableInteractiveModes();
                     rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);

                     _lbSelection.SelectedIndex = _lbSelection.Items.IndexOf(singleSelectionField.Name);
                     rasterImageViewer1.Invalidate();

                     UpdateControls();

                     return;
                  }
               }
               else if (newObject.HiliteColor == "Pink")
               {
                  if (newObject.Tag == null)
                  {
                     AnnRectangleObject newRectObject = new AnnRectangleObject(newObject.Bounds);

                     string st = new ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203));
                     newRectObject.Fill = AnnSolidColorBrush.Create(st);
                     newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(2));

                     automation.Container.Children.Add(newRectObject);
                     automation.Container.Children.Remove(newObject);

                     int currentPage = 0;
                     for (int i = 0; i < rasterImageList1.Items.Count; i++)
                     {
                        if (rasterImageList1.Items[i].IsSelected)
                           currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
                     }

                     LeadRect objectBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(e.Object as AnnObject));

                     LeadRect bounds = new LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height);

                     List<FormField> fields = GetOmrFormFields();

                     BubbleWordField bubbleWordField = GetCurrentMasterForm().CreateBubbleWordField(rasterImageList1.Image, fields, bounds, currentPage + 1);

                     if (bubbleWordField != null)
                     {
                        bubbleWordField.Name = GetFreeFieldName();
                        bubbleWordField.Tag = newRectObject;
                        newRectObject.Tag = bubbleWordField;

                        if (!_lbBubble.Items.Contains(bubbleWordField.Name))
                           _lbBubble.Items.Add(bubbleWordField.Name);

                        BubbleWordFieldDisplay(bubbleWordField);

                        BubbleWordFieldDlg dlg = new BubbleWordFieldDlg(this, bubbleWordField);
                        if (dlg.ShowDialog() == DialogResult.Cancel)
                        {
                           RemoveBubble(bubbleWordField);
                        }
                        else
                        {
                           automation.Container.Children.BringToFront(bubbleWordField.Tag as AnnObject, true);
                        }
                     }
                     else
                     {
                        automation.Container.Children.Remove(newRectObject);
                     }

                     DisableInteractiveModes();
                     rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);
                     rasterImageViewer1.Invalidate();

                     UpdateControls();

                     return;
                  }
               }
#if LEADTOOLS_V20_OR_LATER
               else if (newObject.HiliteColor == "Aqua")
               {
                  if (newObject.Tag == null)
                  {
                     AnnRectangleObject newRectObject = new AnnRectangleObject(newObject.Bounds);

                     string st = new ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203));
                     newRectObject.Fill = AnnSolidColorBrush.Create(st);
                     newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(2));

                     automation.Container.Children.Add(newRectObject);
                     automation.Container.Children.Remove(newObject);

                     int currentPage = 0;
                     for (int i = 0; i < rasterImageList1.Items.Count; i++)
                     {
                        if (rasterImageList1.Items[i].IsSelected)
                           currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
                     }

                     LeadRect objectBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(e.Object as AnnObject));

                     LeadRect bounds = new LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height);

                     List<FormField> fields = GetOmrFormFields();

                     OmrAnswerAreaField answerAreaField = GetCurrentMasterForm().CreateAnswerAreaField(rasterImageList1.Image, fields, bounds, currentPage + 1);

                     if (answerAreaField != null)
                     {
                        answerAreaField.Name = GetFreeFieldName();
                        answerAreaField.Tag = newRectObject;
                        newRectObject.Tag = answerAreaField;

                        foreach (SingleSelectionField field in answerAreaField.Answers)
                        {
                           field.Parent = answerAreaField.Name;
                        }

                        if (!_lbAnswerArea.Items.Contains(answerAreaField.Name))
                           _lbAnswerArea.Items.Add(answerAreaField.Name);

                        AnswerAreaFieldDisplay(answerAreaField);

                        OmrAnswerAreaFieldDlg dlg = new OmrAnswerAreaFieldDlg(this, answerAreaField);
                        if (dlg.ShowDialog() == DialogResult.Cancel)
                        {
                           RemoveAnswerAreaField(answerAreaField);
                        }
                        else
                        {
                           automation.Container.Children.BringToFront(answerAreaField.Tag as AnnObject, true);
                        }
                     }
                     else
                     {
                        automation.Container.Children.Remove(newRectObject);
                     }

                     DisableInteractiveModes();
                     rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);
                     rasterImageViewer1.Invalidate();

                     UpdateControls();

                     return;
                  }
               }
               else if (newObject.HiliteColor == "DeepPink")
               {
                  if (newObject.Tag == null)
                  {
                     AnnRectangleObject newRectObject = new AnnRectangleObject(newObject.Bounds);

                     string st = new ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203));
                     newRectObject.Fill = AnnSolidColorBrush.Create(st);
                     newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), new LeadLengthD(2));

                     automation.Container.Children.Add(newRectObject);
                     automation.Container.Children.Remove(newObject);

                     int currentPage = 0;
                     for (int i = 0; i < rasterImageList1.Items.Count; i++)
                     {
                        if (rasterImageList1.Items[i].IsSelected)
                           currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
                     }

                     LeadRect objectBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(e.Object as AnnObject));

                     LeadRect bounds = new LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height);

                     List<FormField> fields = GetOmrFormFields();

                     OmrDateField omrDateField = GetCurrentMasterForm().CreateOmrDateField(rasterImageList1.Image, fields, bounds, currentPage + 1);

                     if (omrDateField != null)
                     {
                        omrDateField.Name = GetFreeFieldName();
                        omrDateField.Tag = newRectObject;
                        newRectObject.Tag = omrDateField;

                        SetOmrDateParentName(omrDateField);

                        if (!_lbOmrDate.Items.Contains(omrDateField.Name))
                           _lbOmrDate.Items.Add(omrDateField.Name);

                        OmrDateFieldDisplay(omrDateField);

                        OmrDateFieldDlg dlg = new OmrDateFieldDlg(this, omrDateField);
                        if (dlg.ShowDialog() == DialogResult.Cancel)
                        {
                           RemoveOmrDateField(omrDateField);
                        }
                        else
                        {
                           automation.Container.Children.BringToFront(omrDateField.Tag as AnnObject, true);
                        }
                     }
                     else
                     {
                        automation.Container.Children.Remove(newRectObject);
                     }

                     DisableInteractiveModes();
                     rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);
                     rasterImageViewer1.Invalidate();

                     UpdateControls();

                     return;
                  }
               }
#endif //#if LEADTOOLS_V20_OR_LATER

               newField.Name = GetFreeFieldName();

               LeadRect newBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(e.Object as AnnObject));
               //Convert to rectangle to get whole number for pixel value

               newField.Bounds = new LeadRect(newBounds.X, newBounds.Y, newBounds.Width, newBounds.Height);
               newObject.Tag = newField;

               TableFormField tableField = newField as TableFormField;
               if (tableField != null)
               {
                  tableField.ExtractInfo(rasterImageViewer1.Image, ocrEngine);

                  if(tableField.Columns.Count == 0)
                  {
                     //add two columns to new table field
                     TextFormField column1 = new TextFormField();
                     column1.Name = "Column1";
                     column1.Bounds = new LeadRect(0, 0, tableField.Bounds.Width / 2, tableField.Bounds.Height);
                     tableField.Columns.Add(new TableColumn(column1));
                     TextFormField column2 = new TextFormField();
                     column2.Name = "Column2";
                     column2.Bounds = new LeadRect(tableField.Bounds.Width / 2, 0, tableField.Bounds.Width / 2, tableField.Bounds.Height);
                     tableField.Columns.Add(new TableColumn(column2));
                  }

                  tableField.Tag = newObject;
                  AlignmentTableFields(tableField);
                  UpdateTable(tableField);
               }

               UnStructuredTextFormField UnStructuredTextField = newField as UnStructuredTextFormField;
               if (UnStructuredTextField != null)
               {
                  UnStructuredTextField.TextFormField.Bounds = new LeadRect(UnStructuredTextField.Bounds.Width / 2, 0, UnStructuredTextField.Bounds.Width / 2, UnStructuredTextField.Bounds.Height);
                  UnStructuredTextField.Tag = newObject;

                  UnStructuredTextFormFieldDisplay(UnStructuredTextField);
               }

               _lbFields.Items.Add(newField.Name);
               _lbFields.SelectedIndex = _lbFields.Items.IndexOf(newField.Name);

               _lbSelection.SelectedIndex = -1;
               _lbBubble.SelectedIndex = -1;
#if LEADTOOLS_V20_OR_LATER
               _lbAnswerArea.SelectedIndex = -1;
               _lbOmrDate.SelectedIndex = -1;
#endif //#if LEADTOOLS_V20_OR_LATER
            }
            catch (Exception exp)
            {
               Messager.ShowError(this, exp);
            }

            isFieldDirty = true;
            UpdateControls();
         }
      }

      private void DeleteMultipleOmrFields()
      {
         AnnSelectionObject annObject = automation.CurrentEditObject as AnnSelectionObject;
         if (annObject == null)
            return;

         if (Messager.ShowQuestion(this, "This will permanently delete the selected Omr fields. Are you sure you want to continue?", MessageBoxButtons.YesNo) == DialogResult.No)
            return;

         List<AnnObject> objectsToDelete = new List<AnnObject>(annObject.SelectedObjects);

         for (int j = 0; j < objectsToDelete.Count; ++j)
         {
            AnnObject obj = objectsToDelete[j];
            FormField currentField = obj.Tag as FormField;
            _lbFields.SelectedItem = currentField.Name;

            DeleteSelectedField();
         }

         rasterImageViewer1.Invalidate();
         isFieldDirty = true;
         UpdateControls();
      }

      public void ApplyRenameMultipleFields(List<string> omrFieldsNames)
      {
         AnnSelectionObject annObject = automation.CurrentEditObject as AnnSelectionObject;
         if (annObject == null)
            return;

         int index = 0;

         for (int j = 0; j < annObject.SelectedObjects.Count; ++j)
         {
            AnnObject obj = annObject.SelectedObjects[j];
            FormField currentField = obj.Tag as FormField;
            _lbFields.SelectedItem = currentField.Name;

            if ((obj.Tag as FormField).Name == _lbFields.Text)
            {
               currentField.Name = omrFieldsNames[index];
               isFieldDirty = true;
               _lbFields.Items[_lbFields.SelectedIndex] = omrFieldsNames[index];

               ++index;
            }
         }
      }

      public void ApplySetOmrSensitivity(OcrOmrSensitivity sensitivity)
      {
         AnnSelectionObject annObject = automation.CurrentEditObject as AnnSelectionObject;
         if (annObject == null)
            return;

         for (int j = 0; j < annObject.SelectedObjects.Count; ++j)
         {
            AnnObject obj = annObject.SelectedObjects[j];
            OmrFormField currentField = obj.Tag as OmrFormField;
            _lbFields.SelectedItem = currentField.Name;

            if (currentField.Name == _lbFields.Text)
            {
               currentField.Sensitivity = sensitivity;
               isFieldDirty = true;
            }
         }
      }

      void automation_CurrentDesignerChanged(object sender, EventArgs e)
      {
         if (automation.CurrentDesigner is AnnSelectionEditDesigner)
         {
            if (_currentSelectMode == SelectMultiFieldsMode.None)
               return;

            AnnSelectionObject annObject = automation.CurrentEditObject as AnnSelectionObject;
            if (annObject == null)
               return;

            foreach (var field in annObject.SelectedObjects)
            {
               if (field.Tag != null && !(field.Tag is OmrFormField))
               {
                  Messager.ShowInformation(this, "Select OMR fields only.");
                  return;
               }
            }
            DialogResult result = DialogResult.None;

            if (_currentSelectMode == SelectMultiFieldsMode.ChangeSensitivity)
            {
               _lbFields.SelectedIndexChanged -= new EventHandler(_lbFields_SelectedIndexChanged);

               OmrSensitivityDialog omrSensitivityDlg = new OmrSensitivityDialog(this, annObject.SelectedObjects);
               result = omrSensitivityDlg.ShowDialog();

               _lbFields.SelectedIndexChanged += new EventHandler(_lbFields_SelectedIndexChanged);
            }
            else if (_currentSelectMode == SelectMultiFieldsMode.RenameFields)
            {
               _lbFields.SelectedIndexChanged -= new EventHandler(_lbFields_SelectedIndexChanged);

               RenameOmrFieldsDlg renameOmrFieldsDlg = new RenameOmrFieldsDlg(this, annObject.SelectedObjects.Count);
               result = renameOmrFieldsDlg.ShowDialog();

               _lbFields.SelectedIndexChanged += new EventHandler(_lbFields_SelectedIndexChanged);
            }
            else if (_currentSelectMode == SelectMultiFieldsMode.DeleteFields)
            {
               DeleteMultipleOmrFields();
            }

            _currentSelectMode = SelectMultiFieldsMode.None;

            if (result == DialogResult.OK)
               isFieldDirty = true;

            DisableInteractiveModes();
            rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);
            automation.Manager.CurrentObjectId = AnnObject.None;

            return;
         }

         if (automation.CurrentDesigner != null && automation.CurrentDesigner is AnnTextEditDesigner)
         {
            AnnTextEditDesigner textDesigner = automation.CurrentDesigner as AnnTextEditDesigner;
            textDesigner.EditText += new EventHandler<AnnEditTextEventArgs>(textDesigner_EditText);
         }

         if (automation.CurrentEditObject != null)
         {
            CheckHighLevelMenuItem(null);

            AnnObject annObject = automation.CurrentEditObject;
            if (annObject.Tag is SingleSelectionField)
            {
               SingleSelectionField field = annObject.Tag as SingleSelectionField;
               _lbSelection.SelectedItem = field.Name;
            }
            else if (annObject.Tag is BubbleWordField)
            {
               BubbleWordField field = annObject.Tag as BubbleWordField;
               _lbBubble.SelectedItem = field.Name;
            }
#if LEADTOOLS_V20_OR_LATER
            else if (annObject.Tag is OmrAnswerAreaField)
            {
               OmrAnswerAreaField field = annObject.Tag as OmrAnswerAreaField;
               _lbAnswerArea.SelectedItem = field.Name;
            }
            else if (annObject.Tag is OmrDateField)
            {
               OmrDateField field = annObject.Tag as OmrDateField;
               _lbOmrDate.SelectedItem = field.Name;
            }
#endif //#if LEADTOOLS_V20_OR_LATER
            else if (annObject.Tag is FormField)
            {
               FormField field = annObject.Tag as FormField;
               _lbFields.SelectedItem = field.Name;
            }
         }
      }

      void automation_SetCursor(object sender, AnnCursorEventArgs e)
      {
         if (!_automationInteractiveMode.IsEnabled)
            return;

         var automation = sender as AnnAutomation;
         Cursor newCursor = null;

         switch (e.DesignerType)
         {
            case AnnDesignerType.Draw:
               {
                  var allow = true;

                  var drawDesigner = automation.CurrentDesigner as AnnDrawDesigner;
                  if (drawDesigner != null && !drawDesigner.IsTargetObjectAdded && e.PointerEvent != null)
                  {
                     // See if we can draw or not
                     var container = automation.ActiveContainer;

                     allow = false;

                     if (automation.HitTestContainer(e.PointerEvent.Location, false) != null)
                        allow = true;
                  }

                  if (allow)
                  {
                     var annAutomationObject = automation.Manager.FindObjectById(e.Id);
                     if (annAutomationObject != null)
                        newCursor = annAutomationObject.DrawCursor as Cursor;
                  }
                  else
                  {
                     newCursor = Cursors.No;
                  }
               }
               break;

            case AnnDesignerType.Edit:
               {
                  if (e.IsRotateCenter)
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateCenterControlPoint];
                  else if (e.IsRotateGripper)
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateGripperControlPoint];
                  }
                  else if (e.ThumbIndex < 0)
                  {
                     if (e.DragDropEvent != null && !e.DragDropEvent.Allowed)
                        newCursor = Cursors.No;
                     else
                        newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectedObject];
                  }
                  else
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.ControlPoint];
                  }

               }
               break;

            case AnnDesignerType.Run:
               {
                  newCursor = AutomationManagerHelper.AutomationCursors[CursorType.Run];
               }
               break;

            default:
               newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectObject];
               break;

         }

         if (rasterImageViewer1.Cursor != newCursor)
            rasterImageViewer1.Cursor = newCursor;
      }

      void automation_RestoreCursor(object sender, EventArgs e)
      {
         if (rasterImageViewer1.Cursor != Cursors.Default)
            rasterImageViewer1.Cursor = Cursors.Default;
      }

      void textDesigner_EditText(object sender, AnnEditTextEventArgs e)
      {
         TextBox text = new TextBox();
         Rectangle rc = new Rectangle((int)e.Bounds.Left, (int)e.Bounds.Top, (int)e.Bounds.Width, (int)e.Bounds.Height);
         rc.Inflate(12, 12);
         text.Location = rc.Location;
         text.Size = rc.Size;
         text.AutoSize = false;
         text.Tag = e.TextObject;
         text.Text = e.TextObject.Text;
         text.ForeColor = Color.FromName((e.TextObject.TextForeground as AnnSolidColorBrush).Color);
         text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font);
         text.WordWrap = false;
         text.AcceptsReturn = true;
         text.Multiline = true;
         text.Tag = e.TextObject;

         text.LostFocus += new EventHandler(text_LostFocus);
         rasterImageViewer1.Controls.Add(text);
         text.Focus();
         text.SelectAll();
      }

      void text_LostFocus(object sender, EventArgs e)
      {
         TextBox textObject = sender as TextBox;
         if (textObject != null && getSelectedField() is TableFormField)
         {
            TableFormField tableField = automation.CurrentEditObject.Tag as TableFormField;
            OcrFormField columnField = null;
            foreach (TableColumn column in tableField.Columns)
            {
               if (column.Tag == automation.CurrentEditObject)
               {
                  columnField = column.OcrField;
                  break;
               }
            }

            if (columnField != null)
            {
               columnField.Name = textObject.Text;
            }
         }
         rasterImageViewer1.Controls.Remove(textObject);

         updateColumnsList(getSelectedField() as TableFormField);
         AlignmentTableFields(getSelectedField() as TableFormField);
      }

      private Matrix LeadMatrixToMatrix(LeadMatrix leadMatrix)
      {
         return new Matrix((float)leadMatrix.M11, (float)leadMatrix.M12, (float)leadMatrix.M21, (float)leadMatrix.M22, (float)leadMatrix.OffsetX, (float)leadMatrix.OffsetY);
      }

      private DiskMasterForm GetCurrentMasterForm()
      {
         //get currently selected master form
         if (_tvMasterForms.SelectedNode == null)
            return null;

         Type type = _tvMasterForms.SelectedNode.Tag.GetType();
         if (type != typeof(DiskMasterForm))
            return null;

         return _tvMasterForms.SelectedNode.Tag as DiskMasterForm;
      }

      private void _lbFields_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {

            if (rasterImageList1.Items.Count > 0 && _lbFields.SelectedIndex != -1)
            {
               AnnObject selectedObject = automation.CurrentEditObject;

               //New field in listbox. 
               for (int i = 0; i < automation.Container.Children.Count; i++)
               {
                  if (automation.Container.Children[i].Tag is FormField && !(automation.Container.Children[i].Tag is SingleSelectionField))
                  {
                     if ((automation.Container.Children[i].Tag as FormField).Name == _lbFields.Text)
                     {
                        selectedObject = automation.Container.Children[i];
                        //Select correct annotation if it is not already selected
                        if (automation.CurrentEditObject != selectedObject)
                        {
                           automation.SelectObject(selectedObject);
                        }
                        break;
                     }
                  }
               }

               //Update UI properties
               //Temporarily disable events
               _txtFieldName.TextChanged -= new EventHandler(_txtFieldName_TextChanged);
               _cmbFieldType.SelectedIndexChanged -= new EventHandler(_cmbFieldType_SelectedIndexChanged);
               _chkEnableIcr.CheckedChanged -= new EventHandler(_chkOCRMethod_CheckedChanged);
               _chkEnableOcr.CheckedChanged -= new EventHandler(_chkOCRMethod_CheckedChanged);
               _chkDropoutCells.CheckedChanged -= new EventHandler(_chkDropoutCells_CheckedChanged);
               _chkDropoutWords.CheckedChanged -= new EventHandler(_chkDropoutWords_CheckedChanged);
               _rbTextTypeChar.CheckedChanged -= new EventHandler(_rbTextType_CheckedChanged);
               _rbtextTypeNum.CheckedChanged -= new EventHandler(_rbTextType_CheckedChanged);
               _rbtextTypeData.CheckedChanged -= new EventHandler(_rbTextType_CheckedChanged);
               _rbOMRWithFrame.CheckedChanged -= new EventHandler(_rbOMRFrame_CheckedChanged);
               _rbOMRWithoutFrame.CheckedChanged -= new EventHandler(_rbOMRFrame_CheckedChanged);
               _rbOMRAutoFrame.CheckedChanged -= new EventHandler(_rbOMRFrame_CheckedChanged);
               _rbOMRSensitivityLowest.CheckedChanged -= new EventHandler(_rbOMRSensitivity_CheckedChanged);
               _rbOMRSensitivityLow.CheckedChanged -= new EventHandler(_rbOMRSensitivity_CheckedChanged);
               _rbOMRSensitivityHigh.CheckedChanged -= new EventHandler(_rbOMRSensitivity_CheckedChanged);
               _rbOMRSensitivityHighest.CheckedChanged -= new EventHandler(_rbOMRSensitivity_CheckedChanged);

               FormField currentField = (selectedObject.Tag as FormField);
               Type fieldType = currentField.GetType();
               _txtFieldHeight.Text = currentField.Bounds.Height.ToString();
               _txtFieldWidth.Text = currentField.Bounds.Width.ToString();
               _txtFieldLeft.Text = currentField.Bounds.Left.ToString();
               _txtFieldTop.Text = currentField.Bounds.Top.ToString();
               _txtFieldName.Text = currentField.Name;
               _gbFieldMethod.Enabled = fieldType == typeof(TextFormField) || fieldType == typeof(UnStructuredTextFormField);
               _gbFieldTextType.Enabled = fieldType == typeof(TextFormField) || fieldType == typeof(UnStructuredTextFormField);
               _gbOMRFrame.Enabled = fieldType == typeof(OmrFormField);
               _gbOMRSensitivity.Enabled = fieldType == typeof(OmrFormField);
               _tpTable.Enabled = fieldType == typeof(TableFormField);
               _lbSelection.SelectedIndex = -1;
               _lbBubble.SelectedIndex = -1;
#if LEADTOOLS_V20_OR_LATER
               _lbAnswerArea.SelectedIndex = -1;
               _lbOmrDate.SelectedIndex = -1;
#endif //#if LEADTOOLS_V20_OR_LATER

               _cmbFieldType.Enabled = true;

               if (fieldType == typeof(TextFormField))
               {
                  TextFormField textField = currentField as TextFormField;
                  _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Text");

                  _chkEnableIcr.Checked = textField.EnableIcr;
                  _chkEnableOcr.Checked = textField.EnableOcr;
                  _rbTextTypeChar.Checked = (textField.Type == TextFieldType.Character);
                  _rbtextTypeNum.Checked = (textField.Type == TextFieldType.Numerical);
                  _rbtextTypeData.Checked = (textField.Type == TextFieldType.Data);
                  _chkDropoutCells.Checked = (textField.Dropout & DropoutFlag.CellsDropout) == DropoutFlag.CellsDropout;
                  _chkDropoutWords.Checked = (textField.Dropout & DropoutFlag.WordsDropout) == DropoutFlag.WordsDropout;
               }
               else if (fieldType == typeof(OmrFormField))
               {
                  OmrFormField omrField = currentField as OmrFormField;
                  _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Omr");

                  _rbOMRWithFrame.Checked = omrField.FrameMethod == OcrOmrFrameDetectionMethod.WithFrame;
                  _rbOMRWithoutFrame.Checked = omrField.FrameMethod == OcrOmrFrameDetectionMethod.WithoutFrame;
                  _rbOMRAutoFrame.Checked = omrField.FrameMethod == OcrOmrFrameDetectionMethod.Auto;
                  _rbOMRSensitivityLowest.Checked = omrField.Sensitivity == OcrOmrSensitivity.Lowest;
                  _rbOMRSensitivityLow.Checked = omrField.Sensitivity == OcrOmrSensitivity.Low;
                  _rbOMRSensitivityHigh.Checked = omrField.Sensitivity == OcrOmrSensitivity.High;
                  _rbOMRSensitivityHighest.Checked = omrField.Sensitivity == OcrOmrSensitivity.Highest;
               }

               else if (fieldType == typeof(ImageFormField))
               {
                  ImageFormField imageField = currentField as ImageFormField;
                  _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Image");
               }

               else if (fieldType == typeof(BarcodeFormField))
               {
                  BarcodeFormField barcodeField = currentField as BarcodeFormField;
                  _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Barcode");
               }

               else if (fieldType == typeof(TableFormField))
               {
                  _cmbFieldType.Enabled = false;
                  _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Table");
               }
               else if (fieldType == typeof(UnStructuredTextFormField))
               {
                  UnStructuredTextFormField textField = currentField as UnStructuredTextFormField;
                  _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("UnStructured Text");

                  _chkEnableIcr.Checked = textField.TextFormField.EnableIcr;
                  _chkEnableOcr.Checked = textField.TextFormField.EnableOcr;
                  _rbTextTypeChar.Checked = (textField.TextFormField.Type == TextFieldType.Character);
                  _rbtextTypeNum.Checked = (textField.TextFormField.Type == TextFieldType.Numerical);
                  _rbtextTypeData.Checked = (textField.TextFormField.Type == TextFieldType.Data);
                  _chkDropoutCells.Checked = (textField.Dropout & DropoutFlag.CellsDropout) == DropoutFlag.CellsDropout;
                  _chkDropoutWords.Checked = (textField.Dropout & DropoutFlag.WordsDropout) == DropoutFlag.WordsDropout;
               }

               _txtFieldName.TextChanged += new EventHandler(_txtFieldName_TextChanged);
               _cmbFieldType.SelectedIndexChanged += new EventHandler(_cmbFieldType_SelectedIndexChanged);
               _chkEnableIcr.CheckedChanged += new EventHandler(_chkOCRMethod_CheckedChanged);
               _chkEnableOcr.CheckedChanged += new EventHandler(_chkOCRMethod_CheckedChanged);
               _chkDropoutCells.CheckedChanged += new EventHandler(_chkDropoutCells_CheckedChanged);
               _chkDropoutWords.CheckedChanged += new EventHandler(_chkDropoutWords_CheckedChanged);
               _rbTextTypeChar.CheckedChanged += new EventHandler(_rbTextType_CheckedChanged);
               _rbtextTypeNum.CheckedChanged += new EventHandler(_rbTextType_CheckedChanged);
               _rbtextTypeData.CheckedChanged += new EventHandler(_rbTextType_CheckedChanged);
               _rbOMRWithFrame.CheckedChanged += new EventHandler(_rbOMRFrame_CheckedChanged);
               _rbOMRWithoutFrame.CheckedChanged += new EventHandler(_rbOMRFrame_CheckedChanged);
               _rbOMRAutoFrame.CheckedChanged += new EventHandler(_rbOMRFrame_CheckedChanged);
               _rbOMRSensitivityLowest.CheckedChanged += new EventHandler(_rbOMRSensitivity_CheckedChanged);
               _rbOMRSensitivityLow.CheckedChanged += new EventHandler(_rbOMRSensitivity_CheckedChanged);
               _rbOMRSensitivityHigh.CheckedChanged += new EventHandler(_rbOMRSensitivity_CheckedChanged);
               _rbOMRSensitivityHighest.CheckedChanged += new EventHandler(_rbOMRSensitivity_CheckedChanged);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void rasterImageList1_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
         {
            //Temporarily disable event
            rasterImageList1.SelectedItemsChanged -= new EventHandler(rasterImageList1_SelectedIndexChanged);
            rasterImageList1.Items[0].IsSelected = false;
            rasterImageList1.Items[oldSelectedPageIndex].IsSelected = true;
            rasterImageList1.SelectedItemsChanged += new EventHandler(rasterImageList1_SelectedIndexChanged);
            rasterImageList1.Refresh();
            return;
         }

         if (rasterImageList1.Items.Count > 0)
         {
            for (int i = 0; i < rasterImageList1.Items.Count; i++)
            {
               if (rasterImageList1.Items[i].IsSelected)
                  oldSelectedPageIndex = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
            }
         }
         else
            oldSelectedPageIndex = -1;

         //Clear viewer
         if (rasterImageViewer1.Image != null && !rasterImageViewer1.Image.IsDisposed)
         {
            rasterImageViewer1.Image.Dispose();
            rasterImageViewer1.Image = null;
         }

         if (rasterImageList1.Items.Count != 0)
         {
            //Copy selected image in list to main viewer
            for (int i = 0; i < rasterImageList1.Items.Count; i++)
            {
               if (rasterImageList1.Items[i].IsSelected)
               {
                  rasterImageViewer1.Image = rasterImageList1.Items[i].Image.Clone();

                  //when setting container size we should have identity trasnform for the viewer
                  bool useDpi = rasterImageViewer1.UseDpi;
                  ControlSizeMode sizeMode = rasterImageViewer1.SizeMode;

                  rasterImageViewer1.UseDpi = false;
                  rasterImageViewer1.Zoom(ControlSizeMode.ActualSize, 1, rasterImageViewer1.DefaultZoomOrigin);

                  //update annotations container size based on selected image size
                  automation.Container.Size = automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(rasterImageViewer1.Image.Width, rasterImageViewer1.Image.Height));
                  //restore use dpi value
                  rasterImageViewer1.UseDpi = useDpi;
                  rasterImageViewer1.Zoom(sizeMode, 1, rasterImageViewer1.DefaultZoomOrigin);
               }
            }

         }
         BuildFieldList();
         UpdatePageType();
      }

      private void UpdateControls()
      {
         //Fields
         _lbFields.Enabled = !regionMode;
         _tsFields.Enabled = (!regionMode);
         _chkEnableIcr.Enabled = (_tcFieldProps.Enabled && ocrEngine.EngineType != OcrEngineType.LEAD);
         _btnApply.Enabled = !regionMode && isFieldDirty;
         _btnCutField.Enabled = _lbFields.SelectedIndex != -1 && !(automation.CurrentEditObject is AnnTextObject);
         _btnCopyField.Enabled = _lbFields.SelectedIndex != -1 && !(automation.CurrentEditObject is AnnTextObject);
         _btnPasteField.Enabled = automation.CanPaste && rasterImageList1.Items.Count > 0;
         _btnDeleteField.Enabled = _lbFields.SelectedIndex != -1;

         if (automation.CurrentEditObject != null &&
            (automation.CurrentEditObject.Tag as SingleSelectionField != null
            || automation.CurrentEditObject.Tag as BubbleWordField != null
#if LEADTOOLS_V20_OR_LATER
            || automation.CurrentEditObject.Tag as OmrAnswerAreaField != null
            || automation.CurrentEditObject.Tag as OmrDateField != null))
#else 
            ))
#endif //#if LEADTOOLS_V20_OR_LATER
         {
            _tcFieldProps.Enabled = (!regionMode);
            foreach (TabPage tab in _tcFieldProps.TabPages)
            {
               if (tab != _tpSelection && tab != _tpBubble
#if LEADTOOLS_V20_OR_LATER
                    && tab != _tpAnswerArea && tab != _tpOmrDate)
#else
)
#endif //#if LEADTOOLS_V20_OR_LATER
                  (tab as Control).Enabled = false;
            }
         }
         else
         {
            _tcFieldProps.Enabled = (!regionMode);
            foreach (TabPage tab in _tcFieldProps.TabPages)
            {
               if (tab != _tpSelection && tab != _tpBubble
#if LEADTOOLS_V20_OR_LATER
                    && tab != _tpAnswerArea && tab != _tpOmrDate)
#else
)
#endif //#if LEADTOOLS_V20_OR_LATER
                  (tab as Control).Enabled = _tcFieldProps.Enabled && _lbFields.SelectedIndex != -1;
            }
         }

         TableFormField tableField = getSelectedField() as TableFormField;
         if (tableField != null)
         {
            _tcFieldProps.Enabled = !regionMode;
         }
         _tpTable.Enabled = !regionMode && (tableField != null);
         updateColumnsList(tableField);

         //Main menu and image buttons
         _menuItemFile.Enabled = !regionMode;
         _menuItemOptions.Enabled = !regionMode;
         _menuItemHelp.Enabled = !regionMode;
         _tsForms.Enabled = !regionMode;
         _menuItemSaveChanges.Enabled = isFieldDirty;
         _menuItemMasterFormPropsMain.Enabled = _btnMasterFormProps.Enabled = GetCurrentMasterForm() != null;
         _menuItemSaveFormSetAs.Enabled = _btnSaveMasterFormsAs.Enabled = _tvMasterForms.Nodes.Count > 0;
         _menuItemAddMasterMain.Enabled = _menuItemAddMaster.Enabled = _tvMasterForms.Nodes.Count > 0;
         _menuItemDeleteMasterMain.Enabled = _menuItemDeleteMaster.Enabled = GetCurrentMasterForm() != null;
         _menuItemAddMasterPageMain.Enabled = _menuItemAddMasterPage.Enabled = GetCurrentMasterForm() != null;
         _menuItemAddMasterPageDiskMain.Enabled = _menuItemAddMasterPageDisk.Enabled = GetCurrentMasterForm() != null;
         _menuItemAddMasterPageScannerMain.Enabled = _menuItemAddMasterPageScanner.Enabled = (GetCurrentMasterForm() != null && twainSession != null);
         _menuItemDeleteMasterPageMain.Enabled = _menuItemDeleteMasterPage.Enabled = rasterImageList1.Items.Count > 0;
         _menuItemAddChildCategoryMain.Enabled = _menuItemAddChildCategory.Enabled = _tvMasterForms.Nodes.Count > 0;
         _menuItemDeleteChildCategoryMain.Enabled = _menuItemDeleteChildCategory.Enabled = (_tvMasterForms.SelectedNode != null && _tvMasterForms.SelectedNode.Tag.GetType() == typeof(DiskMasterFormsCategory));

         _menuItemIncludeExcludeRegions.Enabled = rasterImageList1.Items.Count > 0;
         pageTypeToolStripMenuItem.Enabled = GetCurrentMasterForm() != null;
         _miDetectOmrFields.Enabled = (GetPageType() == FormsPageType.Omr ? true : false) && GetCurrentMasterForm() != null && pageTypeToolStripMenuItem.Enabled && rasterImageList1.ActiveItem != null;
         _miRenameOmr.Enabled = _miDetectOmrFields.Enabled;
         _miSetOmrSensitivity.Enabled = _miDetectOmrFields.Enabled;
         _miDeleteOmrFields.Enabled = _miDetectOmrFields.Enabled;

         //Viewer toolstrip buttons
         _btnPointerTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnPanTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnOcrTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnUNOcrTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnBarcodeTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnImageTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnOmrTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnOmrHighLevelObjects.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnShowFields.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnZoomDrawTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnTableTool.Enabled = (!regionMode && rasterImageViewer1.Image != null);
         _btnSelectRegion.Enabled = (regionMode && rasterImageViewer1.Image != null);
         _btnRemoveSelection.Enabled = (!regionMode && _lbSelection.SelectedIndex != -1);
         _btnEditSelection.Enabled = (!regionMode && _lbSelection.SelectedIndex != -1);
         _cbHideSelectionAnn.Enabled = (!regionMode && _lbSelection.Items.Count > 0);

         _btnRemoveBubble.Enabled = (!regionMode && _lbBubble.SelectedIndex != -1);
         _btnEditBubble.Enabled = (!regionMode && _lbBubble.SelectedIndex != -1);
         _cbHideBubbleAnn.Enabled = (!regionMode && _lbBubble.Items.Count > 0);

#if LEADTOOLS_V20_OR_LATER
         _btnRemoveAnswerArea.Enabled = (!regionMode && _lbAnswerArea.SelectedIndex != -1);
         _btnEditAnswerArea.Enabled = (!regionMode && _lbAnswerArea.SelectedIndex != -1);
         _cbHideAnswerAnn.Enabled = (!regionMode && _lbAnswerArea.Items.Count > 0);

         _btnRemoveOmrDate.Enabled = (!regionMode && _lbOmrDate.SelectedIndex != -1);
         _btnEditOmrDate.Enabled = (!regionMode && _lbOmrDate.SelectedIndex != -1);
         _cbHideOmrDateAnn.Enabled = (!regionMode && _lbOmrDate.Items.Count > 0);
#endif //#if LEADTOOLS_V20_OR_LATER

         _tvMasterForms.Enabled = !regionMode;

         rasterImageList1.Enabled = !regionMode;
         automation.DefaultCurrentObjectId = AnnObject.None;

         if (automation.CurrentEditObject != null && automation.CurrentEditObject.Tag is FormField)
         {
            FormField currentField = (automation.CurrentEditObject.Tag as FormField);
            Type fieldType = currentField.GetType();
            _gbFieldMethod.Enabled = fieldType == typeof(TextFormField) || fieldType == typeof(UnStructuredTextFormField);
            _gbFieldTextType.Enabled = fieldType == typeof(TextFormField) || fieldType == typeof(UnStructuredTextFormField);
            _gbOMRFrame.Enabled = fieldType == typeof(OmrFormField);
            _gbOMRSensitivity.Enabled = fieldType == typeof(OmrFormField);
            _tpTable.Enabled = fieldType == typeof(TableFormField);

            _gbDropoutOptions.Enabled = fieldType == typeof(TextFormField) || fieldType == typeof(UnStructuredTextFormField);

            _cmbFieldType.Enabled = true;
         }
      }

      private void _menuItemExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (regionMode)
         {
            e.Cancel = true;
            return;
         }

         if (!CheckForUnsavedChanges())
            e.Cancel = true;

         if (EditorStream != null)
         {
            EditorStream.Dispose();
         }

         ShutDownEngines();
         Application.Exit();
      }

      private FormField getSelectedField()
      {
         int index = _lbFields.SelectedIndex;
         if (index == -1)
            return null;

         if (automation.CurrentEditObject == null)
            return null;

         FormField currentField = automation.CurrentEditObject.Tag as FormField;
         return currentField;
      }

      private void CreateNewRepository(string newDirectory)
      {
         using (WaitCursor cursor = new WaitCursor())
         {
            //Create the repository 
            if (workingRepository != null)
               workingRepository = null;
            workingRepository = new DiskMasterFormsRepository(rasterCodecs, newDirectory);
            BuildMasterFormList(workingRepository.RootCategory, _tvMasterForms.Nodes, true);

            if (Properties.Settings.Default.MasterFormsPath != newDirectory)
            {
               Properties.Settings.Default.MasterFormsPath = newDirectory;
               Properties.Settings.Default.Save();
            }
         }
      }

      private void _menuItemAddMasterSetMain_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         try
         {
            FolderBrowserDialogEx fbd = new FolderBrowserDialogEx();
            fbd.Description = "Please select a directory to create the new master form set";
            fbd.ShowFullPathInEditBox = true;
            fbd.ShowEditBox = true;
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
               string[] existingDirs = Directory.GetDirectories(fbd.SelectedPath);
               NewElement newFormSet = new NewElement("Create a new form set", "Master Form Set Name:", existingDirs);
               if (newFormSet.ShowDialog() == DialogResult.OK)
                  CreateNewRepository(Path.Combine(fbd.SelectedPath, newFormSet.ElementName));
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void _menuItemSaveChanges_Click(object sender, EventArgs e)
      {
         if (ApplyChanges())
            isFieldDirty = false;
      }

      private void _menuItemSaveFormSetAs_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         try
         {
            FolderBrowserDialogEx fbd = new FolderBrowserDialogEx();
            fbd.Description = "Please select a directory to create the new master form set";
            fbd.ShowFullPathInEditBox = true;
            fbd.ShowEditBox = true;
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
               string[] existingDirs = Directory.GetDirectories(fbd.SelectedPath);
               NewElement newFormSet = new NewElement("Create a new form set", "Master Form Set Name:", existingDirs);
               if (newFormSet.ShowDialog() == DialogResult.OK)
               {
                  //Create a new repository and copy the forms from the old repository to the new one
                  DiskMasterFormsRepository oldRepository = new DiskMasterFormsRepository(rasterCodecs, workingRepository.Path);
                  CreateNewRepository(Path.Combine(fbd.SelectedPath, newFormSet.ElementName));
                  CopyMasterForms(oldRepository.RootCategory, workingRepository.RootCategory);
                  BuildMasterFormList(workingRepository.RootCategory, _tvMasterForms.Nodes, true);
                  oldRepository = null;
                  Messager.Show(this, "Master form set saved.", MessageBoxIcon.Information, MessageBoxButtons.OK);
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void CopyMasterForms(IMasterFormsCategory sourceCategory, IMasterFormsCategory targetCategory)
      {
         //Copy master forms
         foreach (IMasterForm masterForm in sourceCategory.MasterForms)
            targetCategory.AddMasterForm(masterForm.ReadAttributes(), masterForm.ReadFields(), masterForm.ReadForm());

         //copy categories
         foreach (IMasterFormsCategory sourceChildCategory in sourceCategory.ChildCategories)
         {
            IMasterFormsCategory targetChildCategory = targetCategory.AddChildCategory(sourceChildCategory.Name);
            CopyMasterForms(sourceChildCategory, targetChildCategory);
         }
      }

      private void _menuItemAddMasterMain_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         try
         {
            IMasterFormsCategory parentCategory = null;
            TreeNode parentCategoryNode = null;
            if (_tvMasterForms.SelectedNode == null)
            {
               //nothing selected, add it to root category
               parentCategory = workingRepository.RootCategory;
               parentCategoryNode = _tvMasterForms.Nodes[0];
            }
            else
            {
               //if selected node is category, add it as child. Otherwise add it to parent of selected node
               Type type = _tvMasterForms.SelectedNode.Tag.GetType();
               if (type == typeof(DiskMasterFormsCategory))
               {
                  //selected node is category
                  parentCategory = _tvMasterForms.SelectedNode.Tag as IMasterFormsCategory;
                  parentCategoryNode = _tvMasterForms.SelectedNode;
               }
               else
               {
                  //selected node is master form
                  parentCategory = _tvMasterForms.SelectedNode.Parent.Tag as IMasterFormsCategory;
                  parentCategoryNode = _tvMasterForms.SelectedNode.Parent;
               }
            }

            //Build array of current form names
            string[] existingForms = new string[parentCategory.MasterForms.Count];
            for (int i = 0; i < parentCategory.MasterForms.Count; i++)
               existingForms[i] = parentCategory.MasterForms[i].Name;

            NewElement newelement = new NewElement("Create a new master form", "Master Form Name:", existingForms);
            if (newelement.ShowDialog() == DialogResult.OK)
            {
               //Add master form to repository and treeview
               IMasterForm newForm = parentCategory.AddMasterForm(CreateMasterForm(newelement.ElementName), null, (RasterImage)null);
               TreeNode newNode = parentCategoryNode.Nodes.Add(newForm.Name);
               newNode.Tag = newForm;
               _tvMasterForms.SelectedNode = newNode;
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      public FormRecognitionAttributes CreateMasterForm(string name)
      {
         FormRecognitionOptions options = new FormRecognitionOptions();
         FormRecognitionAttributes attributes = recognitionEngine.CreateMasterForm(name, new Guid(), options);
         recognitionEngine.CloseMasterForm(attributes);
         return attributes;
      }

      private void _menuItemDeleteMasterMain_Click(object sender, EventArgs e)
      {
         try
         {
            if (Messager.ShowQuestion(this, "This will permanently delete the selected master form.  Are you sure you want to continue?", MessageBoxButtons.YesNo) != DialogResult.Yes)
               return;

            //We know the selected node is a masterform node, otherwise the delete button would have been disabled
            IMasterFormsCategory parentCategory = _tvMasterForms.SelectedNode.Parent.Tag as IMasterFormsCategory;
            isFieldDirty = false;
            parentCategory.DeleteMasterForm(_tvMasterForms.SelectedNode.Tag as IMasterForm);
            _tvMasterForms.SelectedNode.Remove();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void _menuItemAddMasterPageDiskMain_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         try
         {
            ImageFileLoader loader = new ImageFileLoader();
            loader.OpenDialogInitialPath = _openInitialPath;
            loader.ShowLoadPagesDialog = true;
            loader.MultiSelect = false;
            loader.ShowPdfOptions = true;
            if (loader.Load(this, rasterCodecs, true) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               AddMasterFormPages(loader.Image);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

#if LEADTOOLS_V19_OR_LATER
      private FormsPageType GetPageType()
      {
         FormsPageType type = FormsPageType.Normal;
         if (cardItem.Checked)
            type = FormsPageType.IDCard;
         else if (omrItem.Checked)
            type = FormsPageType.Omr;

         return type;
      }
#endif //#if LEADTOOLS_V19_OR_LATER

      private void AddMasterFormPages(RasterImage imagesToAdd)
      {
         //Load masterform attributes, fields, and image
         DiskMasterForm currentMasterForm = GetCurrentMasterForm();
         FormRecognitionAttributes attributes = currentMasterForm.ReadAttributes();
         FormPages formPages = currentMasterForm.ReadFields();
         RasterImage formImage = currentMasterForm.ReadForm();
         PageRecognitionOptions options = new PageRecognitionOptions();
#if LEADTOOLS_V19_OR_LATER
         options.PageType = GetPageType();
#endif

         for (int i = 0; i < imagesToAdd.PageCount; i++)
         {
            //Add each new page to the masterform by creating attributes for each page
            imagesToAdd.Page = i + 1;
            AddPageToMasterForm(imagesToAdd.Clone(), attributes, -1, options);
         }

         //Add image
         if (formImage != null)
            formImage.AddPages(imagesToAdd.CloneAll(), 1, imagesToAdd.PageCount);
         else
            formImage = imagesToAdd.CloneAll();

         //Only add processing pages for the new pages
         if (formPages != null)
         {
            for (int i = 0; i < imagesToAdd.PageCount; i++)
               formPages.Add(new FormPage(formPages.Count + 1, imagesToAdd.XResolution, imagesToAdd.YResolution));
         }
         else
         {
            //No processing pages exist so we must create them
            FormProcessingEngine tempProcessingEngine = new FormProcessingEngine();
            tempProcessingEngine.OcrEngine = ocrEngine;
            tempProcessingEngine.BarcodeEngine = barcodeEngine;

            for (int i = 0; i < recognitionEngine.GetFormProperties(attributes).Pages; i++)
               tempProcessingEngine.Pages.Add(new FormPage(i + 1, imagesToAdd.XResolution, imagesToAdd.YResolution));

            formPages = tempProcessingEngine.Pages;
         }

         currentMasterForm.WriteForm(formImage);
         currentMasterForm.WriteAttributes(attributes);
         currentMasterForm.WriteFields(formPages);

         BuildMasterPageList();
         UpdatePageType();
      }

      public void AddPageToMasterForm(RasterImage image, FormRecognitionAttributes attributes, int pageIndex, PageRecognitionOptions pageOptions)
      {
         using (WaitCursor cursor = new WaitCursor())
         {
            recognitionEngine.OpenMasterForm(attributes);
            recognitionEngine.InsertMasterFormPage(pageIndex, attributes, image, pageOptions, null);
#if FOR_DOTNET4
            if (_useFullTextSearchButton.Checked)
            {
               if (recognitionEngine.FullTextSearchManager == null)
                  recognitionEngine.FullTextSearchManager = CreateFullTextSearchManager(workingRepository.Path);

               recognitionEngine.UpsertMasterFormToFullTextSearch(attributes, "index", null, null, null, null);
            }
#endif

            recognitionEngine.CloseMasterForm(attributes);

#if FOR_DOTNET4
            if (_useFullTextSearchButton.Checked)
               recognitionEngine.FullTextSearchManager.Index();
#endif
         }
      }

      private void _menuItemAddMasterPageScannerMain_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         try
         {
            if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, twainSession.SelectedSourceName()))
               return;

            Messager.Show(this, "For best results, scan at 150DPI (or higher) and 1 bits per pixel", MessageBoxIcon.Information, MessageBoxButtons.OK);

            if (twainSession.SelectSource(String.Empty) != DialogResult.OK)
               return;

            if (twainSession.Acquire(TwainUserInterfaceFlags.Show) != DialogResult.OK)
               return;

            AddMasterFormPages(scannedImage);
            scannedImage.Dispose();
            scannedImage = null;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         finally
         {
            UpdateControls();
         }
      }

      void twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         if (scannedImage == null)
            scannedImage = e.Image.Clone();
         else
            scannedImage.AddPage(e.Image.Clone());
      }

      private void _menuItemDeleteMasterPageMain_Click(object sender, EventArgs e)
      {
         try
         {
            if (Messager.ShowQuestion(this, "This will permanently delete the selected master form page.  Are you sure you want to continue?", MessageBoxButtons.YesNo) != DialogResult.Yes)
               return;

            DiskMasterForm currentMasterForm = GetCurrentMasterForm();
            int currentPageIdx = 0;
            for (int i = 0; i < rasterImageList1.Items.Count; i++)
            {
               if (rasterImageList1.Items[i].IsSelected)
                  currentPageIdx = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
            }
            FormRecognitionAttributes attributes = currentMasterForm.ReadAttributes();
            FormPages formPages = currentMasterForm.ReadFields();
            RasterImage formImage = currentMasterForm.ReadForm();

            //Delete page from master form attaributes
            DeletePageFromMasterForm(currentPageIdx + 1, attributes); //page number here is 1 based
            //Delete fields page
            formPages.RemoveAt(currentPageIdx);
            //Delete the page from the image
            if (formImage.PageCount == 1)
               formImage = null; //You cannot remove the only page from a rasterimage, an exception will occur
            else
               formImage.RemovePageAt(currentPageIdx + 1);

            //We need to recreate the FormPages to ensure the page numbers are updated correctly
            for (int i = 0; i < formPages.Count; i++)
            {
               FormPage currentPage = formPages[i];
               FormPage newPage = new FormPage(i + 1, currentPage.DpiX, currentPage.DpiY);
               newPage.AddRange(currentPage.GetRange(0, currentPage.Count));
               formPages[i] = newPage;
            }

            isFieldDirty = false;
            //Write the updated masterform to disk. Delete it first just in case the entire image was deleted
            DiskMasterFormsCategory parentCategory = _tvMasterForms.SelectedNode.Parent.Tag as DiskMasterFormsCategory;
            parentCategory.DeleteMasterForm(currentMasterForm);
            parentCategory.AddMasterForm(attributes, formPages, formImage);

            //Delete the page from the imagelist
            rasterImageList1.Items.RemoveAt(currentPageIdx);
            rasterImageList1_SelectedIndexChanged(this, null);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void DeletePageFromMasterForm(int pagenumber, FormRecognitionAttributes form)
      {
         recognitionEngine.OpenMasterForm(form);
         recognitionEngine.DeleteMasterFormPage(form, pagenumber);

#if FOR_DOTNET4
         if (_useFullTextSearchButton.Checked)
         {
            recognitionEngine.UpsertMasterFormToFullTextSearch(form, "index", null, null, null, null);
         }
#endif

         recognitionEngine.CloseMasterForm(form);
      }

      private void _menuItemAddChildCategoryMain_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         try
         {
            IMasterFormsCategory parentCategory = null;
            TreeNode parentCategoryNode = null;
            if (_tvMasterForms.SelectedNode == null)
            {
               //nothing selected, add it as a child of the root
               parentCategory = workingRepository.RootCategory;
               parentCategoryNode = _tvMasterForms.Nodes[0];
            }
            else
            {
               //if selected node is category, add it as child. Otherwise add it to parent of selected node
               Type type = _tvMasterForms.SelectedNode.Tag.GetType();
               if (type == typeof(DiskMasterFormsCategory))
               {
                  //selected node is category
                  parentCategory = _tvMasterForms.SelectedNode.Tag as IMasterFormsCategory;
                  parentCategoryNode = _tvMasterForms.SelectedNode;
               }
               else
               {
                  //selected node is master form
                  parentCategory = _tvMasterForms.SelectedNode.Parent.Tag as IMasterFormsCategory;
                  parentCategoryNode = _tvMasterForms.SelectedNode.Parent;
               }
            }

            //Build array of current category names
            string[] existingCategories = new string[parentCategory.ChildCategories.Count];
            for (int i = 0; i < parentCategory.ChildCategories.Count; i++)
               existingCategories[i] = parentCategory.ChildCategories[i].Name;

            NewElement newelement = new NewElement("Create a new child category", "Category Name:", existingCategories);
            if (newelement.ShowDialog() == DialogResult.OK)
            {
               //Add child category to repository and treeview
               IMasterFormsCategory newCategory = parentCategory.AddChildCategory(newelement.ElementName);
               TreeNode newNode = parentCategoryNode.Nodes.Add(newCategory.Name);
               newNode.Tag = newCategory;
               _tvMasterForms.SelectedNode = newNode;
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void _menuItemDeleteChildCategoryMain_Click(object sender, EventArgs e)
      {
         try
         {
            if (Messager.ShowQuestion(this, "This will permanently delete the selected category.  Are you sure you want to continue?", MessageBoxButtons.YesNo) != DialogResult.Yes)
               return;

            IMasterFormsCategory category = _tvMasterForms.SelectedNode.Tag as IMasterFormsCategory;
            isFieldDirty = false;
            category.Clear();
            _tvMasterForms.SelectedNode.Remove();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
         UpdateControls();
      }

      private void _menuItemInformation_Click(object sender, EventArgs e)
      {
         InformationDlg infoDlg = new InformationDlg();
         infoDlg.ShowDialog();
      }

      private void _menuItemHowTo_Click(object sender, EventArgs e)
      {
         try
         {
            DemosGlobal.LaunchHowTo("FormsRecognitionDemo.html");
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }
      }

      private void _menuItemAbout_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("Master Forms Editor", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("Master Forms Editor"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void RecognitionOptionsChanged(object sender, EventArgs e)
      {
         SetupRecognitionEngine();
      }

      private void DisableInteractiveModes()
      {
         foreach (ImageViewerInteractiveMode mode in rasterImageViewer1.InteractiveModes)
         {
            mode.IsEnabled = false;
         }
      }

      private void _btnPointerTool_Click(object sender, EventArgs e)
      {
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);
         CheckToolButtons(sender);
      }

      private void _btnPanTool_Click(object sender, EventArgs e)
      {
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_panInteractiveMode.Id);
         CheckToolButtons(sender);
      }

      private void EnableHighlight(Type fieldType)
      {
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);

         foreach (AnnAutomationObject obj in annAutomationManager.Objects)
         {
            if (obj.Id == AnnObject.HiliteObjectId)
            {
               AnnHiliteObject highlight = obj.ObjectTemplate as AnnHiliteObject;
               highlight.HiliteColor = GetHighlightColor(fieldType).ToString();
               break;
            }
         }

         automation.Manager.CurrentObjectId = AnnObject.HiliteObjectId;

         isFieldDirty = true;
      }

      private String GetHighlightColor(Type fieldType)
      {
         if (typeof(TextFormField) == fieldType)
            return "Green";

         else if (typeof(OmrFormField) == fieldType)
            return "Purple";

         else if (typeof(ImageFormField) == fieldType)
            return "Yellow";

         else if (typeof(BarcodeFormField) == fieldType)
            return "Orange";

         else if (typeof(TableFormField) == fieldType)
            return "Red";

         else if (typeof(UnStructuredTextFormField) == fieldType)
            return "DarkSeaGreen";

         else if (typeof(SingleSelectionField) == fieldType)
            return "Brown";

         else if (typeof(BubbleWordField) == fieldType)
            return "Pink";
#if LEADTOOLS_V20_OR_LATER
         else if (typeof(OmrDateField) == fieldType)
            return "DeepPink";

         else if (typeof(OmrAnswerAreaField) == fieldType)
            return "Aqua";
#endif //#if LEADTOOLS_V20_OR_LATER
         else
            return "Blue"; //default
      }

      private void _btnSelectRegion_Click(object sender, EventArgs e)
      {
         EnableHighlight(null);
         CheckToolButtons(sender);
      }

      private void _btnOcrTool_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(TextFormField));
         CheckToolButtons(sender);
      }

      private void _btnUNOcrTool_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(UnStructuredTextFormField));
         CheckToolButtons(sender);
      }

      private void _btnOmrTool_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(OmrFormField));
         CheckToolButtons(sender);
      }

      private void _miSingleSelectionField_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(SingleSelectionField));
         CheckToolButtons(_btnOmrHighLevelObjects);
         CheckHighLevelMenuItem(sender);
      }

      private void _miBubbleWordField_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(BubbleWordField));
         CheckToolButtons(_btnOmrHighLevelObjects);
         CheckHighLevelMenuItem(sender);
      }

#if LEADTOOLS_V20_OR_LATER
      private void _miAnswerAreaField_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(OmrAnswerAreaField));
         CheckToolButtons(_btnOmrHighLevelObjects);
         CheckHighLevelMenuItem(sender);
      }

      private void _miOmrDateField_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(OmrDateField));
         CheckToolButtons(_btnOmrHighLevelObjects);
         CheckHighLevelMenuItem(sender);
      }
#endif //#if LEADTOOLS_V20_OR_LATER

      private void _btnOmrHighLevelObjects_Click(object sender, EventArgs e)
      {
         _cmHighLevelObjects.Show(MousePosition);
      }

      private void _btnBarcodeTool_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(BarcodeFormField));
         CheckToolButtons(sender);
      }

      private void _btnImageTool_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(ImageFormField));
         CheckToolButtons(sender);
      }

      private void _btnTableTool_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(TableFormField));
         CheckToolButtons(sender);
      }

      private void _btnShowFields_Click(object sender, EventArgs e)
      {
         automation.Container.IsVisible = !automation.Container.IsVisible;
         rasterImageViewer1.Refresh();
      }

      private void _btnZoomNormal_Click(object sender, EventArgs e)
      {
         try
         {
            rasterImageViewer1.Zoom(ControlSizeMode.ActualSize, 1, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFit_Click(object sender, EventArgs e)
      {
         try
         {
            rasterImageViewer1.Zoom(ControlSizeMode.FitAlways, 1, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFitWidth_Click(object sender, EventArgs e)
      {
         try
         {
            rasterImageViewer1.Zoom(ControlSizeMode.FitWidth, 1, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnZoomIn_Click(object sender, EventArgs e)
      {
         try
         {
            double oldScaleFactor = rasterImageViewer1.ScaleFactor;
            rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1f, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnZoomOut_Click(object sender, EventArgs e)
      {
         try
         {
            if (rasterImageViewer1.ScaleFactor > 0.1f)
            {
               double oldScaleFactor = rasterImageViewer1.ScaleFactor;
               rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1f, rasterImageViewer1.DefaultZoomOrigin);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnZoomDrawTool_Click(object sender, EventArgs e)
      {
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
         CheckToolButtons(sender);
      }

      private void CheckToolButtons(object sender)
      {
         _btnPointerTool.Checked = false;
         _btnPanTool.Checked = false;
         _btnZoomDrawTool.Checked = false;
         _btnOcrTool.Checked = false;
         _btnUNOcrTool.Checked = false;
         _btnBarcodeTool.Checked = false;
         _btnImageTool.Checked = false;
         _btnOmrTool.Checked = false;
         _btnSelectRegion.Checked = false;
         _btnTableTool.Checked = false;
         _btnOmrHighLevelObjects.Checked = false;
         ((ToolStripButton)sender).Checked = true;
      }

      private void CheckHighLevelMenuItem(object sender)
      {
         _miSingleSelectionField.Checked = false;
         _miBubbleWordField.Checked = false;
#if LEADTOOLS_V20_OR_LATER
         _miAnswerAreaField.Checked = false;
         _miOmrDateField.Checked = false;
#endif //#if LEADTOOLS_V20_OR_LATER

         if (sender as ToolStripMenuItem != null)
            ((ToolStripMenuItem)sender).Checked = true;
      }

      private void _btnUseDpi_Click(object sender, EventArgs e)
      {
         rasterImageViewer1.UseDpi = _btnUseDpi.Checked;

         if (_btnUseDpi.Checked)
            _btnUseDpi.ToolTipText = "Ignore Image DPI When Viewing";
         else
            _btnUseDpi.ToolTipText = "Use Image DPI When Viewing";
      }

      private void DeleteSelectedField()
      {
         try
         {
            //Delete annotation field and remove from field listbox
            AnnObject currentAnnotationField = automation.CurrentEditObject;
            automation.Cancel();

            TableFormField tableForm = currentAnnotationField.Tag as TableFormField;
            UnStructuredTextFormField UnStructuredTextForm = currentAnnotationField.Tag as UnStructuredTextFormField;
            if (tableForm != null)
            {
               foreach (TableColumn column in tableForm.Columns)
               {
                  automation.Container.Children.Remove(column.Tag as AnnObject);
               }

               automation.Container.Children.Remove(tableForm.Tag as AnnObject);
            }
            else if (UnStructuredTextForm != null)
            {
               automation.Container.Children.Remove(UnStructuredTextForm.TextFormField.Tag as AnnObject);
               automation.Container.Children.Remove(UnStructuredTextForm.Tag as AnnObject);
            }
            else
            {
               automation.Container.Children.Remove(currentAnnotationField);
            }

            _lbFields.Items.RemoveAt(_lbFields.SelectedIndex);
            rasterImageViewer1.Invalidate();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnDeleteField_Click(object sender, EventArgs e)
      {
         DeleteSelectedField();
         isFieldDirty = true;
         UpdateControls();
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         ApplyChanges();
      }

      private void _btnPasteField_Click(object sender, EventArgs e)
      {
         if (FormCopy == null && Origform == null) return;

         automation.Paste();

         if (FormCopy != null)//copy
         {
            automation.CurrentEditObject.Tag = FormCopy;
            (automation.CurrentEditObject.Tag as FormField).Tag = automation.CurrentEditObject;
            (automation.CurrentEditObject.Tag as FormField).Name = GetFreeFieldName();
         }
         else//cut
         {
            automation.CurrentEditObject.Tag = Origform;
         }

         AlignmentTableFields(automation.CurrentEditObject.Tag as TableFormField);
         UnStructuredTextFormFieldDisplay(automation.CurrentEditObject.Tag as UnStructuredTextFormField);
         _lbFields.Items.Add((automation.CurrentEditObject.Tag as FormField).Name);
         isFieldDirty = true;

         Origform = automation.CurrentEditObject.Tag as FormField;
         FormCopy = (FormField)Origform.Clone();
         Origform = null;

         UpdateControls();
      }

      FormField FormCopy = null;
      FormField Origform = null;

      private void _btnCopyField_Click(object sender, EventArgs e)
      {
         Origform = automation.CurrentEditObject.Tag as FormField;
         FormCopy = (FormField)Origform.Clone();

         automation.CurrentEditObject.Tag = null;
         automation.Copy();
         automation.CurrentEditObject.Tag = Origform;
         Origform = null;

         UpdateControls();
      }

      private void _btnCutField_Click(object sender, EventArgs e)
      {
         FormCopy = null;

         Origform = (FormField)(automation.CurrentEditObject.Tag as FormField);
         automation.CurrentEditObject.Tag = null;
         automation.Copy();
         automation.CurrentEditObject.Tag = Origform;

         DeleteSelectedField();
         isFieldDirty = true;
         UpdateControls();
      }

      private PageRecognitionOptions GetPageOptions(int pageIndex, FormRecognitionAttributes attributes)
      {
         PageRecognitionOptions options = null;
         using (WaitCursor cursor = new WaitCursor())
         {
            recognitionEngine.OpenMasterForm(attributes);
            options = recognitionEngine.GetPageOptions(attributes, pageIndex);
            recognitionEngine.CloseMasterForm(attributes);
         }

         return options;
      }

      private void AddRectangle(LeadRect fieldToAdd)
      {
         AnnHiliteObject annotationField = new AnnHiliteObject();
         annotationField.HiliteColor = "Blue";
         //temporarily disable item added event so it does not fire while adding these fields
         automation.Draw -= new EventHandler<AnnDrawDesignerEventArgs>(Children_CollectionChanged);
         automation.Container.Children.Add(annotationField);
         automation.Draw += new EventHandler<AnnDrawDesignerEventArgs>(Children_CollectionChanged);

         // Now we can calculate the object bounds correctly

         RectangleF rc = new RectangleF(fieldToAdd.Left, fieldToAdd.Top, fieldToAdd.Width, fieldToAdd.Height);

         LeadRectD rect = BoundsToAnnotations(annotationField, rc);
         annotationField.Rect = rect;
      }

      private void SelectRegions_Click(object sender, EventArgs e)
      {
         if (!CheckForUnsavedChanges())
            return;

         using (RegionForm regionForm = new RegionForm())
         {
            if (regionForm.ShowDialog() != DialogResult.OK)
               return;

            try
            {
               int currentPage = 0;
               for (int i = 0; i < rasterImageList1.Items.Count; i++)
               {
                  if (rasterImageList1.Items[i].IsSelected)
                     currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items[i]);
               }

               DiskMasterForm currentMasterForm = GetCurrentMasterForm();
               FormRecognitionAttributes attributes = currentMasterForm.ReadAttributes();
               LeadRect[] regionList = null;
               PageRecognitionOptions pageOptions = GetPageOptions(currentPage, attributes);

               if (regionForm.UseInterestRegions)
               {
                  cancelRegion = false;
                  regionList = null;
                  //Select regions of interest
                  if (Messager.Show(this, "Please select the regions of interest for this page using the \"Select Regions\" tool. Press Enter to accept your selections, or Escape to exit this mode.", MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel) == DialogResult.OK)
                  {
                     regionList = SelectRectangles(pageOptions.RegionOfInterestRectangles);
                     if (regionList != null)
                     {
                        pageOptions.RegionOfInterestRectangles.Clear();
                        foreach (LeadRect regionOfInterest in regionList)
                           pageOptions.RegionOfInterestRectangles.Add(regionOfInterest);
                     }
                  }
               }
               if (regionForm.UseIncludeRegions)
               {
                  cancelRegion = false;
                  regionList = null;
                  //Select include regions
                  if (Messager.Show(this, "Please select the include regions for this page using the \"Select Regions\" tool. Press Enter to accept your selections, or Escape to exit this mode.", MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel) == DialogResult.OK)
                  {
                     regionList = SelectRectangles(pageOptions.IncludeRectangles);
                     if (regionList != null)
                     {
                        pageOptions.IncludeRectangles.Clear();
                        foreach (LeadRect includeRegion in regionList)
                           pageOptions.IncludeRectangles.Add(includeRegion);
                     }
                  }
               }
               if (regionForm.UseExcludeRegions)
               {
                  cancelRegion = false;
                  regionList = null;
                  //Select exclude regions
                  if (Messager.Show(this, "Please select the regions to exclude for this page using the \"Select Regions\" tool. Press Enter to accept your selections, or Escape to exit this mode.", MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel) == DialogResult.OK)
                  {
                     regionList = SelectRectangles(pageOptions.ExcludeRectangles);
                     if (regionList != null)
                     {
                        pageOptions.ExcludeRectangles.Clear();
                        foreach (LeadRect excludeRegion in regionList)
                           pageOptions.ExcludeRectangles.Add(excludeRegion);
                     }
                  }
               }

               if (regionList != null && regionList.Length > 0)
               {
                  //Delete old page from attributes (1 based index)
                  DeletePageFromMasterForm(currentPage + 1, attributes);
                  //Insert new page into attributes (1 based index)
                  AddPageToMasterForm(rasterImageViewer1.Image.Clone(), attributes, currentPage + 1, pageOptions);
                  //Write updated masterform attributes
                  currentMasterForm.WriteAttributes(attributes);
                  //Reload fields
                  isFieldDirty = false;
                  rasterImageList1_SelectedIndexChanged(this, null);
               }

               if (regionList == null && automation.Container.Children.Count == 0)
                  BuildFieldList();
            }
            catch (Exception exp)
            {
               Messager.ShowError(this, exp);
            }
         }

         UpdateControls();
      }

      private LeadRect[] SelectRectangles(IList<LeadRect> oldRects)
      {
         ImageViewerInteractiveMode oldInteractiveMode = null;
         foreach (ImageViewerInteractiveMode mode in rasterImageViewer1.InteractiveModes)
         {
            if (mode.IsEnabled == true)
               oldInteractiveMode = mode;
         }

         try
         {
            //Make sure we are not in any interactive modes for drawing annotations
            DisableInteractiveModes();
            rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);
            //temporarily disable after changed event so it does not fire while adding these regions
            automation.AfterObjectChanged -= new EventHandler<AnnAfterObjectChangedEventArgs>(automation_AfterObjectChanged);
            //clear current annotations
            automation.SelectObject(null);
            automation.Container.Children.Clear();
            rasterImageViewer1.Invalidate();

            foreach (LeadRect rect in oldRects)
               AddRectangle(rect);

            regionMode = true;
            _btnSelectRegion_Click(_btnSelectRegion, null);
            UpdateControls();
            while (regionMode)
               Application.DoEvents();
            UpdateControls();

            if (cancelRegion)
            {
               automation.SelectObject(null);
               automation.Container.Children.Clear();
               rasterImageViewer1.Invalidate();
               return null;
            }

            List<LeadRect> regionsOfInterest = new List<LeadRect>();
            foreach (AnnObject obj in automation.Container.Children)
               regionsOfInterest.Add(BoundsFromAnnotations(obj));

            return regionsOfInterest.ToArray();
         }
         catch
         {
            throw;
         }
         finally
         {
            DisableInteractiveModes();
            rasterImageViewer1.InteractiveModes.EnableById(oldInteractiveMode.Id);
            annAutomationManager.EditObjectAfterDraw = true;
            automation.AfterObjectChanged += new EventHandler<AnnAfterObjectChangedEventArgs>(automation_AfterObjectChanged);
            rasterImageViewer1.Invalidate();
         }
      }

      private void rasterImageViewer1_KeyUp(object sender, KeyEventArgs e)
      {
         if (regionMode)
         {
            if (e.KeyCode == Keys.Enter)
               regionMode = false; //region mode complete
            if (e.KeyCode == Keys.Escape)
            {
               regionMode = false;
               cancelRegion = true;
            }
         }
      }

      private void _menuItemMasterFormPropsMain_Click(object sender, EventArgs e)
      {
         try
         {
            DiskMasterFormsCategory parentCategory = _tvMasterForms.SelectedNode.Parent.Tag as DiskMasterFormsCategory;
            DiskMasterForm currentMasterForm = GetCurrentMasterForm();
            FormRecognitionProperties masterProps = recognitionEngine.GetFormProperties(currentMasterForm.ReadAttributes());
            MasterFormProperties properties = new MasterFormProperties(masterProps, parentCategory.Path);
            properties.ShowDialog(this);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            UpdateControls();
         }
      }

      private void _menuItemLaunchFormsDemo_Click(object sender, EventArgs e)
      {
         //When launching the demo, pass the current engine we are using, and the repository path, if available
         ProcessStartInfo startInfo = new ProcessStartInfo();
         startInfo.FileName = Path.Combine(Application.StartupPath, "CSFormsDemo_Original.exe");

         // Make sure either CSMasterFormsEditor_Original.exe or CSMasterFormsEditor.exe exist before attempting to start it
         if (!File.Exists(startInfo.FileName))
         {
            startInfo.FileName = startInfo.FileName.Replace("_Original", string.Empty);
         }

         if (!File.Exists(startInfo.FileName))
         {
            startInfo.FileName = startInfo.FileName.Replace("MasterFormsEditor", "FormsDemo");
         }

         if (!File.Exists(startInfo.FileName))
         {
            MessageBox.Show(String.Format("Cannot find: {0}{1}{1}Please build the CSFormsDemo.exe from the FormsDemo project.", startInfo.FileName, Environment.NewLine), "File Not Found");
            return;
         }

         startInfo.Arguments = String.Format("\"{0}\"", ocrEngine.EngineType.ToString());
         if (workingRepository != null)
            startInfo.Arguments = String.Format("{0} \"{1}\"", startInfo.Arguments, workingRepository.Path);

         try
         {
            using (Process process = new Process())
            {
               process.StartInfo = startInfo;
               process.Start();
               process.Close();
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _menuItemUpdateMasterFormsData_Click(object sender, EventArgs e)
      {
         UpdateMasterFormsData updateMasterFormsData = new UpdateMasterFormsData();
         updateMasterFormsData.ocrEngine = ocrEngine;
         updateMasterFormsData.barcodeEngine = barcodeEngine;
         updateMasterFormsData.recognitionEngine = recognitionEngine;
         updateMasterFormsData.ShowDialog(this);
      }

      private bool ApplyChanges()
      {
         try
         {
            DiskMasterForm currentMasterForm = GetCurrentMasterForm();
            if (currentMasterForm == null)
               return false;

            FormPages formPages = currentMasterForm.ReadFields();
            formPages[oldSelectedPageIndex].Clear();

            //Clear Tags that we do not want to save.
            PushFieldsTags();

            //All of the field data is stored in each annotations UserData property.
            //We will enumerate each object to extract all the fields and save them.
            foreach (AnnObject annotationField in automation.Container.Children)
            {
               if (annotationField is AnnTextObject)
                  continue;

               SingleSelectionField selectionField = annotationField.Tag as SingleSelectionField;
               if (selectionField != null)
               {
                  if (!String.IsNullOrEmpty(selectionField.Parent))
                     continue;
               }

               BubbleWordField bubbleField = annotationField.Tag as BubbleWordField;
               if (bubbleField != null)
               {
                  if (!String.IsNullOrEmpty(bubbleField.Parent))
                     continue;
               }

               FormField currentField = annotationField.Tag as FormField;
               if (currentField != null)
               {
                  if (!formPages[oldSelectedPageIndex].Contains(currentField))
                     formPages[oldSelectedPageIndex].Add(currentField);
               }
            }

            currentMasterForm.WriteFields(formPages);

            //Return back cleared Tags
            PopFieldsTags();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }

         isFieldDirty = false;
         UpdateControls();
         return true;
      }

      Dictionary<FormField, Object> tags = new Dictionary<FormField, object>();

      private void PushFieldsTags()
      {
         tags.Clear();

         foreach (AnnObject annotationField in automation.Container.Children)
         {
            if (annotationField is AnnTextObject)
               continue;

            FormField currentField = annotationField.Tag as FormField;
            if (currentField != null && currentField.Tag != null)
            {
               tags.Add(currentField, currentField.Tag);
               currentField.Tag = null;
            }
         }
      }

      private void PopFieldsTags()
      {
         foreach (AnnObject annotationField in automation.Container.Children)
         {
            if (annotationField is AnnTextObject)
               continue;

            FormField currentField = annotationField.Tag as FormField;
            if (tags.ContainsKey(currentField))
            {
               Object tag = tags[currentField];
               if (tag != null)
                  currentField.Tag = tag;
            }
         }

         tags.Clear();
      }

      private bool CheckForUnsavedChanges()
      {
         if (isFieldDirty)
         {
            DialogResult result = MessageBox.Show("You have made changes to the fields on this form without saving them. Would you like to apply these changes?", "Warning", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
               return ApplyChanges();
            else if (result == DialogResult.Cancel)
               return false;
            else
            {
               isFieldDirty = false;
               // There were dirty objects but the user chose not to save them
               return true;
            }
         }

         return true;
      }

      private void _tvMasterForms_BeforeSelect(object sender, TreeViewCancelEventArgs e)
      {
         if (!CheckForUnsavedChanges())
            e.Cancel = true;
      }

      private void _txtFieldName_TextChanged(object sender, EventArgs e)
      {
         if (_lbFields.SelectedIndex == -1 || regionMode)
            return;

         if (String.IsNullOrEmpty(_txtFieldName.Text))
         {
            Messager.Show(this, "You must specify a field name.", MessageBoxIcon.Error, MessageBoxButtons.OK);
            _txtFieldName.Text = (automation.CurrentEditObject.Tag as FormField).Name;
            _txtFieldName.Focus();
            return;
         }

         for (int i = 0; i < _lbFields.Items.Count; i++)
         {
            //Check for existing field name
            if (String.Compare(_txtFieldName.Text, _lbFields.Items[i] as string) == 0 && i != _lbFields.SelectedIndex)
            {
               Messager.Show(this, "That field name already exist.", MessageBoxIcon.Error, MessageBoxButtons.OK);
               _txtFieldName.Focus();
               return;
            }
         }

         //name is ok, update it
         foreach (AnnObject annotationField in automation.Container.Children)
         {
            if ((annotationField.Tag as FormField).Name == _lbFields.Text)
            {
               FormField currentField = annotationField.Tag as FormField;
               currentField.Name = _txtFieldName.Text;
               isFieldDirty = true;

               //temporaily disable event to prevent field data from reloading
               _lbFields.SelectedIndexChanged -= new EventHandler(_lbFields_SelectedIndexChanged);
               _lbFields.Items[_lbFields.SelectedIndex] = _txtFieldName.Text;
               _lbFields.SelectedIndexChanged += new EventHandler(_lbFields_SelectedIndexChanged);

               break;
            }
         }

         UpdateControls();
      }

      private void _cmbFieldType_SelectedIndexChanged(object sender, EventArgs e)
      {
         isFieldDirty = true;
         UpdateField();
      }

      private void _rbTextType_CheckedChanged(object sender, EventArgs e)
      {
         isFieldDirty = true;
         UpdateField();
      }

      private void _chkOCRMethod_CheckedChanged(object sender, EventArgs e)
      {
         isFieldDirty = true;
         UpdateField();
      }

      private void _rbOMRSensitivity_CheckedChanged(object sender, EventArgs e)
      {
         isFieldDirty = true;
         UpdateField();
      }

      private void _rbOMRFrame_CheckedChanged(object sender, EventArgs e)
      {
         isFieldDirty = true;
         UpdateField();
      }

      private void CopyFieldAttributes(FormField newField, FormField oldField)
      {
         newField.Name = oldField.Name;
         newField.Bounds = oldField.Bounds;
         newField.MasterPageNumber = oldField.MasterPageNumber;

         if (newField is UnStructuredTextFormField)
            (newField as UnStructuredTextFormField).TextFormField.Bounds = new LeadRect(newField.Bounds.Width / 2, 0, newField.Bounds.Width / 2, newField.Bounds.Height);

         if (newField is TableFormField)
         {
            TextFormField column1 = new TextFormField();
            column1.Name = "Column1";
            column1.Bounds = new LeadRect(0, 0, newField.Bounds.Width / 2, newField.Bounds.Height);
            column1.Tag = null;
            (newField as TableFormField).Columns.Add(new TableColumn(column1));
            TextFormField column2 = new TextFormField();
            column2.Name = "Column2";
            column2.Bounds = new LeadRect(newField.Bounds.Width / 2, 0, newField.Bounds.Width / 2, newField.Bounds.Height);
            column2.Tag = null;
            (newField as TableFormField).Columns.Add(new TableColumn(column2));

            AlignmentTableFields(newField as TableFormField);
            UpdateTable(newField as TableFormField);
         }
      }

      private void UpdateField()
      {
         //One or more of the fields properties changed so we need to update the field data
         //which is stored in the annotation objects UserData
         if (automation.CurrentEditObject == null)
            return;

         FormField currentField = automation.CurrentEditObject.Tag as FormField;
         bool isNewField = false;
         FormField tempOldField = currentField;

         string fieldType = _cmbFieldType.Text;
         switch (fieldType)
         {
            case "Text":
               if (!(currentField is TextFormField))
               {
                  isNewField = true;
                  currentField = new TextFormField();
                  _rbTextTypeChar.Checked = true;
                  CopyFieldAttributes(currentField, tempOldField);
               }

               //set text field options
               (currentField as TextFormField).EnableIcr = _chkEnableIcr.Checked;
               (currentField as TextFormField).EnableOcr = _chkEnableOcr.Checked;
               (currentField as TextFormField).Type = _rbTextTypeChar.Checked ? TextFieldType.Character : (_rbtextTypeNum.Checked ? TextFieldType.Numerical : TextFieldType.Data);

               if (_chkDropoutCells.Checked)
                  currentField.Dropout |= DropoutFlag.CellsDropout;
               else
                  currentField.Dropout &= ~DropoutFlag.CellsDropout;

               if (_chkDropoutWords.Checked)
                  currentField.Dropout |= DropoutFlag.WordsDropout;
               else
                  currentField.Dropout &= ~DropoutFlag.WordsDropout;

               break;

            case "Omr":
               if (!(currentField is OmrFormField))
               {
                  isNewField = true;
                  currentField = new OmrFormField();
                  CopyFieldAttributes(currentField, tempOldField);
               }

               //set omr field options
               if (_rbOMRWithFrame.Checked)
                  (currentField as OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithFrame;
               else if (_rbOMRWithoutFrame.Checked)
                  (currentField as OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithoutFrame;
               else if (_rbOMRAutoFrame.Checked)
                  (currentField as OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.Auto;

               if (_rbOMRSensitivityLowest.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.Lowest;
               else if (_rbOMRSensitivityLow.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.Low;
               else if (_rbOMRSensitivityHigh.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.High;
               else if (_rbOMRSensitivityHighest.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.Highest;

               break;

            case "Image":
               //set image field options
               if (!(currentField is ImageFormField))
               {
                  isNewField = true;
                  currentField = new ImageFormField();
                  CopyFieldAttributes(currentField, tempOldField);
               }

               break;

            case "Barcode":
               //set barcode field options
               if (!(currentField is BarcodeFormField))
               {
                  isNewField = true;
                  currentField = new BarcodeFormField();
                  CopyFieldAttributes(currentField, tempOldField);
               }

               break;

            case "Table":
               //set Table fields options
               if (!(currentField is TableFormField))
               {
                  isNewField = true;
                  currentField = new TableFormField();
                  currentField.Tag = automation.CurrentEditObject;
                  CopyFieldAttributes(currentField, tempOldField);
               }
               else
               {
                  TableFormField tableField = (currentField as TableFormField);
                  updateColumnsList(tableField);
               }
               break;

            case "UnStructured Text":
               if (!(currentField is UnStructuredTextFormField))
               {
                  isNewField = true;
                  currentField = new UnStructuredTextFormField();
                  CopyFieldAttributes(currentField, tempOldField);
               }

               //set text field options
               (currentField as UnStructuredTextFormField).TextFormField.EnableIcr = _chkEnableIcr.Checked;
               (currentField as UnStructuredTextFormField).TextFormField.EnableOcr = _chkEnableOcr.Checked;
               (currentField as UnStructuredTextFormField).TextFormField.Type = _rbTextTypeChar.Checked ? TextFieldType.Character : (_rbtextTypeNum.Checked ? TextFieldType.Numerical : TextFieldType.Data);

               if (_chkDropoutCells.Checked)
                  currentField.Dropout |= DropoutFlag.CellsDropout;
               else
                  currentField.Dropout &= ~DropoutFlag.CellsDropout;

               if (_chkDropoutWords.Checked)
                  currentField.Dropout |= DropoutFlag.WordsDropout;
               else
                  currentField.Dropout &= ~DropoutFlag.WordsDropout;

               break;
         }

         if (isNewField)
         {
            DeleteSelectedField();
            AddField(currentField);
            _lbFields.SelectedItem = currentField.Name;
         }

         //Set field back to userdata in case a new form field type was created.
         automation.CurrentEditObject.Tag = currentField;

         LeadRect newBounds = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(automation.CurrentEditObject));
         //Convert to rectangle to get whole number for pixel value

         if (getSelectedField() is TableFormField && automation.CurrentEditObject is AnnHiliteObject)
         {
            if (!isValidBounds(newBounds, currentField as TableFormField))
               return;

            UpdateTableBounds(currentField as TableFormField, newBounds);
         }
         else if (!(automation.CurrentEditObject is AnnTextObject))
         {
            currentField.Bounds = new LeadRect(Convert.ToInt32(newBounds.Left), Convert.ToInt32(newBounds.Top), Convert.ToInt32(newBounds.Width), Convert.ToInt32(newBounds.Height));
            currentField.Name = _txtFieldName.Text;
         }

         UpdateControls();
      }

      private void UpdateTableBounds(TableFormField tableField, LeadRect newBoundsRounded)
      {
         if (tableField.Bounds.Width == newBoundsRounded.Width)
         {
            //Moving table, no need to edit Columns
         }
         else if (newBoundsRounded.Right >= rasterImageViewer1.Image.Width)
         {
            newBoundsRounded.Width = rasterImageViewer1.Image.Width - newBoundsRounded.Left;
         }
         else if (tableField.Bounds.Left < newBoundsRounded.Left && (newBoundsRounded.Left - tableField.Bounds.Left) < tableField.Columns[0].OcrField.Bounds.Width)
         {
            LeadRect rc = tableField.Columns[0].OcrField.Bounds;
            rc.Width = rc.Width - (newBoundsRounded.Left - tableField.Bounds.Left);
            tableField.Columns[0].OcrField.Bounds = rc;
         }
         else if (tableField.Bounds.Left >= newBoundsRounded.Left || (tableField.Bounds.Left <= newBoundsRounded.Left && newBoundsRounded.Left < tableField.Bounds.Left + tableField.Columns[0].OcrField.Bounds.Right))
         {
            LeadRect rc = tableField.Columns[0].OcrField.Bounds;
            rc.Width = rc.Width + (tableField.Bounds.Left - newBoundsRounded.Left);
            tableField.Columns[0].OcrField.Bounds = rc;
         }

         tableField.Bounds = new LeadRect(Convert.ToInt32(newBoundsRounded.Left), Convert.ToInt32(newBoundsRounded.Top), Convert.ToInt32(newBoundsRounded.Width), Convert.ToInt32(newBoundsRounded.Height));
         tableField.Name = _txtFieldName.Text;
      }

      private bool isValidBounds(LeadRect newBoundsRounded, TableFormField tableField)
      {
         if (newBoundsRounded.Left >= tableField.Bounds.Right && newBoundsRounded.Width != tableField.Bounds.Width ||
            newBoundsRounded.Right <= tableField.Bounds.Left && newBoundsRounded.Width != tableField.Bounds.Width ||
            newBoundsRounded.Width <= tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds.Left && (newBoundsRounded.Left == tableField.Bounds.Left || newBoundsRounded.Height != tableField.Bounds.Height) ||
            newBoundsRounded.Left >= tableField.Columns[0].OcrField.Bounds.Right + tableField.Bounds.Left && (newBoundsRounded.Right == tableField.Bounds.Right || newBoundsRounded.Height != tableField.Bounds.Height))
            return false;
         return true;
      }

      private void _menuItemLanguages_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user change the current enabled languages
         using (EnableLanguagesDialog dlg = new EnableLanguagesDialog(ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _menuItemComponents_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user see the OCR components installed on this system
         using (OcrEngineComponentsDialog dlg = new OcrEngineComponentsDialog(ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _btn_RemoveColumn_Click(object sender, EventArgs e)
      {
         int index = _lbColumns.SelectedIndex;

         if (index == -1)
            return;

         TableFormField tableField = automation.CurrentEditObject.Tag as TableFormField;

         if (tableField.Columns.Count == 1)
         {
            //If the table contains only one column, delete entire table
            DeleteSelectedField();
            isFieldDirty = true;
            UpdateControls();
            return;
         }
         else if (index == 0)
         {
            //If the deleted column is the first one, shift columns to the left
            tableField.Columns[index + 1].OcrField.Bounds = new LeadRect(0, 0, tableField.Columns[index + 1].OcrField.Bounds.Width + tableField.Columns[index].OcrField.Bounds.Width, tableField.Bounds.Height);
         }
         else
         {
            //Shift columns to the right
            tableField.Columns[index - 1].OcrField.Bounds = new LeadRect(tableField.Columns[index - 1].OcrField.Bounds.X, 0, tableField.Columns[index - 1].OcrField.Bounds.Width + tableField.Columns[index].OcrField.Bounds.Width, tableField.Bounds.Height);
         }

         TableColumn column = tableField.Columns[index];
         automation.Container.Children.Remove(column.Tag as AnnObject);
         tableField.Columns.RemoveAt(index);
         isFieldDirty = true;
         updateColumnsList(tableField);
         AlignmentTableFields(tableField);
      }

      private void updateColumnsPosition(TableFormField tableField)
      {
         if (tableField != null)
         {
            LeadRect rc;
            for (int i = 0; i < tableField.Columns.Count; i++)
            {
               rc = tableField.Columns[i].OcrField.Bounds;
               rc.Height = tableField.Bounds.Height;
               rc.Y = 0;

               if (i == 0)
                  rc.X = 0;
               else
                  rc.X = tableField.Columns[i - 1].OcrField.Bounds.Right;

               tableField.Columns[i].OcrField.Bounds = rc;
            }

            if (tableField.Bounds.Width > tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds.Left)
            {
               rc = tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds;
               rc.Width = tableField.Bounds.Width - tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds.Left;
               tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds = rc;
            }
         }
      }

      private void updateColumnsList(TableFormField tableField)
      {
         _lbColumns.Items.Clear();
         _lbColumns.Tag = tableField;

         if (tableField != null)
         {
            for (int i = 0; i < tableField.Columns.Count; i++)
            {
               int index = _lbColumns.Items.Add(tableField.Columns[i].OcrField.Name);
            }
         }

         _btn_RemoveColumn.Enabled = (_lbColumns.SelectedIndex != -1);
         _btn_ColumnOptions.Enabled = (_lbColumns.SelectedIndex != -1);
         _gb_ColumnOcr.Enabled = (_lbColumns.SelectedIndex == -1);
      }

      private void _btn_AddColumn_Click(object sender, EventArgs e)
      {
         UI.FieldNameDlg fileNameDlg = new UI.FieldNameDlg("Column" + (this._lbColumns.Items.Count + 1).ToString());
         if (fileNameDlg.ShowDialog() != DialogResult.OK)
            return;

         TableFormField tableField = automation.CurrentEditObject.Tag as TableFormField;
         if (tableField != null)
         {
            OcrFormField columnField = null;

            if (_rB_ColumnOcr.Checked)
               columnField = new TextFormField();
            else
               columnField = new OmrFormField();

            columnField.Name = fileNameDlg.TextFieldName;
            if (rasterImageViewer1.Image.Width <= tableField.Bounds.Right)
            {
               MessageBox.Show("Table's width exceeds the image's width", "Unable to add new column", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            else if (tableField.Bounds.Right + tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds.Width > rasterImageViewer1.Image.Width)
            {
               columnField.Bounds = new LeadRect(tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds.Right, 0, rasterImageViewer1.Image.Width - tableField.Bounds.Right, tableField.Bounds.Height);
            }
            else
            {
               columnField.Bounds = new LeadRect(tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds.Right, 0, tableField.Columns[tableField.Columns.Count - 1].OcrField.Bounds.Width, tableField.Bounds.Height);
            }

            if (columnField.Bounds.Right > tableField.Bounds.Width)
            {
               LeadRect rect = tableField.Bounds;
               rect.Width = columnField.Bounds.Width + columnField.Bounds.X;
               tableField.Bounds = rect;
            }

            tableField.Columns.Add(new TableColumn(columnField));
            isFieldDirty = true;

            updateColumnsList(tableField);

            AlignmentTableFields(tableField);
         }
      }

      private void _lbColumns_SelectedIndexChanged(object sender, EventArgs e)
      {
         _btn_RemoveColumn.Enabled = (_lbColumns.SelectedIndex != -1);
         _btn_ColumnOptions.Enabled = (_lbColumns.SelectedIndex != -1);
         _gb_ColumnOcr.Enabled = (_lbColumns.SelectedIndex != -1);

         if (automation.CurrentEditObject == null)
         {
            automation.SelectObject((_lbColumns.Tag as TableFormField).Tag as AnnObject);
         }

         TableFormField tableField = automation.CurrentEditObject.Tag as TableFormField;
         if (tableField != null && _lbColumns.SelectedIndex != -1)
         {
            OcrFormField ocrField = tableField.Columns[_lbColumns.SelectedIndex].OcrField;
            if (ocrField is TextFormField)
               _rB_ColumnOcr.Checked = true;
            else
               _rB_ColumnOmr.Checked = true;
         }
      }

      private void _btn_ColumnOptions_Click(object sender, EventArgs e)
      {
         TableFormField selectedTable = getSelectedField() as TableFormField;

         if (selectedTable != null)
         {
            object selectedItem = _lbColumns.SelectedItem;
            ColumnOptions options = new ColumnOptions(ocrEngine.EngineType != OcrEngineType.LEAD);
            options.Column = selectedTable.Columns[_lbColumns.SelectedIndex];
            options.ShowDialog();
            updateColumnsList(selectedTable);
            AlignmentTableFields(selectedTable);
            isFieldDirty = true;
            UpdateControls();
            _lbColumns.SelectedItem = selectedItem;
         }
      }

      private void _chkDropoutWords_CheckedChanged(object sender, EventArgs e)
      {
         isFieldDirty = true;
         UpdateField();
      }

      private void _chkDropoutCells_CheckedChanged(object sender, EventArgs e)
      {
         isFieldDirty = true;
         UpdateField();
      }

      private void _btn_Rules_Click(object sender, EventArgs e)
      {
         TableFormField selectedTable = getSelectedField() as TableFormField;

         if (selectedTable != null)
         {
            TableRulesForm rulesForm = new TableRulesForm(selectedTable);
            rulesForm.ShowDialog();

            if (rulesForm.RulesChanged)
            {
               isFieldDirty = true;
               UpdateControls();
            }
         }
      }

#if LEADTOOLS_V19_OR_LATER
      private void UpdatePageType()
      {

         if (rasterImageList1.ActiveItem == null)
            return;

         PageRecognitionOptions options = null;
         int currentPageIndex = rasterImageList1.Items.IndexOf(rasterImageList1.ActiveItem);
         IMasterForm currentMaster = GetCurrentMasterForm();
         FormRecognitionAttributes attributes = currentMaster.ReadAttributes();
         recognitionEngine.OpenMasterForm(attributes);
         options = recognitionEngine.GetPageOptions(attributes, currentPageIndex);
         recognitionEngine.CloseMasterForm(attributes);

         if (options != null && options.PageType == FormsPageType.IDCard)
         {
            cardItem.Checked = true;
            normalItem.Checked = false;
            omrItem.Checked = false;
         }
         else if (options != null && options.PageType == FormsPageType.Omr)
         {
            cardItem.Checked = false;
            normalItem.Checked = false;
            omrItem.Checked = true;
         }
         else
         {
            cardItem.Checked = false;
            normalItem.Checked = true;
            omrItem.Checked = false;
         }

      }
#endif //#if LEADTOOLS_V19_OR_LATER

      private void PageTypeToolStripMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         FormsPageType pageType = FormsPageType.Normal;
         if (sender == cardItem)
         {
            pageType = FormsPageType.IDCard;
         }
         else if (sender == omrItem)
         {
            pageType = FormsPageType.Omr;
         }
#endif //#if LEADTOOLS_V19_OR_LATER

         PageRecognitionOptions options = null;
         int currentPageIndex = rasterImageList1.Items.IndexOf(rasterImageList1.ActiveItem);
         IMasterForm currentMaster = GetCurrentMasterForm();
         FormRecognitionAttributes attributes = currentMaster.ReadAttributes();
         recognitionEngine.OpenMasterForm(attributes);
         options = recognitionEngine.GetPageOptions(attributes, currentPageIndex);
         if (options == null)
            options = new PageRecognitionOptions();
#if LEADTOOLS_V19_OR_LATER
         options.PageType = pageType;
         recognitionEngine.SetPageOptions(attributes, currentPageIndex + 1, options);
         if (rasterImageList1.ActiveItem != null)
            recognitionEngine.UpdatePageType(attributes, rasterImageList1.ActiveItem.Image, currentPageIndex + 1);
#endif //#if LEADTOOLS_V19_OR_LATER
         recognitionEngine.CloseMasterForm(attributes);

         this.GetCurrentMasterForm().WriteAttributes(attributes);
#if LEADTOOLS_V19_OR_LATER
         if (pageType == FormsPageType.Omr)
         {
            cardItem.Checked = false;
            normalItem.Checked = false;
            omrItem.Checked = true;
         }
         else if (pageType == FormsPageType.IDCard)
         {
            cardItem.Checked = true;
            normalItem.Checked = false;
            omrItem.Checked = false;
         }
         else
         {
            cardItem.Checked = false;
            normalItem.Checked = true;
            omrItem.Checked = false;
         }

         UpdatePageType();
         UpdateControls();
#endif //#if LEADTOOLS_V19_OR_LATER
      }

      private void _miDetectOmrFields_Click(object sender, EventArgs e)
      {
         OmrDetectionDialog dlg = new OmrDetectionDialog(this, GetCurrentMasterForm(), oldSelectedPageIndex + 1);
         dlg.ShowDialog(this);
      }

      public void FillDetectedOmrFields(List<OmrFormField> omrFields)
      {
         foreach (var field in omrFields)
         {
            AddField(field);
         }

         isFieldDirty = true;
         UpdateControls();

         rasterImageViewer1.Invalidate();
      }

      private void _miRenameOmrFields_Click(object sender, EventArgs e)
      {
         _currentSelectMode = SelectMultiFieldsMode.RenameFields;
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);

         automation.Manager.CurrentObjectId = AnnSelectionObject.SelectObjectId;
      }

      private void _miDeleteOmrFields_Click(object sender, EventArgs e)
      {
         _currentSelectMode = SelectMultiFieldsMode.DeleteFields;
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);

         automation.Manager.CurrentObjectId = AnnSelectionObject.SelectObjectId;
      }

      private void _miSetOmrSensitivity_Click(object sender, EventArgs e)
      {
         _currentSelectMode = SelectMultiFieldsMode.ChangeSensitivity;
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id);

         automation.Manager.CurrentObjectId = AnnSelectionObject.SelectObjectId;
      }

      private void _rB_Column_CheckedChanged(object sender, EventArgs e)
      {
         if (sender != null && !(sender as RadioButton).Checked)
            return;

         if (_lbColumns.SelectedItem == null)
            return;

         TableFormField tableField = automation.CurrentEditObject.Tag as TableFormField;
         if (tableField != null)
         {
            object selectedItem = _lbColumns.SelectedItem;
            TableColumn columnField = null;
            int index = -1;
            for (int col = 0; col < tableField.Columns.Count; ++col)
            {
               TableColumn column = tableField.Columns[col];
               if (column.OcrField.Name.Equals(_lbColumns.SelectedItem.ToString()))
               {
                  columnField = column;
                  index = col;
                  break;
               }
            }

            if (index == -1)
               return;

            if ((_rB_ColumnOcr.Checked && columnField.OcrField is TextFormField) || (_rB_ColumnOmr.Checked && columnField.OcrField is OmrFormField))
               return;

            OcrFormField tempField = null;

            if (_rB_ColumnOcr.Checked)
            {
               tempField = new TextFormField();
            }
            else
            {
               tempField = new OmrFormField();
            }

            tempField.Name = columnField.OcrField.Name;
            tempField.Bounds = columnField.OcrField.Bounds;

            tableField.Columns[index] = new TableColumn(tempField);
            tableField.Columns[index].Tag = columnField.Tag;

            isFieldDirty = true;

            updateColumnsList(tableField);

            AlignmentTableFields(tableField);

            _lbColumns.SelectedItem = selectedItem;
         }
      }

      private void _lbSelection_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (rasterImageList1.Items.Count > 0 && _lbSelection.SelectedIndex != -1)
         {
            _lbFields.SelectedItem = null;
            _lbBubble.SelectedItem = null;

#if LEADTOOLS_V20_OR_LATER
            _lbAnswerArea.SelectedItem = null;
            _lbOmrDate.SelectedItem = null;
#endif //#if LEADTOOLS_V20_OR_LATER

            AnnObject selectedObject = automation.CurrentEditObject;

            //New field in listbox. 
            for (int i = 0; i < automation.Container.Children.Count; ++i)
            {
               SingleSelectionField obj = automation.Container.Children[i].Tag as SingleSelectionField;
               if (obj != null && obj.Name == _lbSelection.Text)
               {
                  selectedObject = automation.Container.Children[i];

                  if (automation.CurrentEditObject != selectedObject)
                  {
                     automation.SelectObject(selectedObject);
                  }
                  break;
               }
            }

            if (selectedObject.Tag as SingleSelectionField != null)
            {
               SingleSelectionField obj = selectedObject.Tag as SingleSelectionField;

               _tbSelectionLeft.Text = obj.Bounds.Left.ToString();
               _tbSelectionTop.Text = obj.Bounds.Top.ToString();
               _tbSelectionWidth.Text = obj.Bounds.Width.ToString();
               _tbSelectionHeight.Text = obj.Bounds.Height.ToString();
            }

            UpdateControls();
         }
         else //if (_lbSelection.SelectedIndex == -1)
         {
            _tbSelectionLeft.Text = "";
            _tbSelectionTop.Text = "";
            _tbSelectionWidth.Text = "";
            _tbSelectionHeight.Text = "";
         }
      }

      private void _lbBubble_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (rasterImageList1.Items.Count > 0 && _lbBubble.SelectedIndex != -1)
         {
            _lbFields.SelectedItem = null;
            _lbSelection.SelectedItem = null;
#if LEADTOOLS_V20_OR_LATER
            _lbAnswerArea.SelectedItem = null;
            _lbOmrDate.SelectedItem = null;
#endif // #if LEADTOOLS_V20_OR_LATER

            AnnObject selectedObject = automation.CurrentEditObject;

            //New field in listbox. 
            for (int i = 0; i < automation.Container.Children.Count; ++i)
            {
               BubbleWordField obj = automation.Container.Children[i].Tag as BubbleWordField;
               if (obj != null && obj.Name == _lbBubble.Text)
               {
                  selectedObject = automation.Container.Children[i];

                  if (automation.CurrentEditObject != selectedObject)
                  {
                     automation.SelectObject(selectedObject);
                  }
                  break;
               }
            }

            if (selectedObject.Tag as BubbleWordField != null)
            {
               BubbleWordField obj = selectedObject.Tag as BubbleWordField;

               _tbBubbleLeft.Text = obj.Bounds.Left.ToString();
               _tbBubbleTop.Text = obj.Bounds.Top.ToString();
               _tbBubbleWidth.Text = obj.Bounds.Width.ToString();
               _tbBubbleHeight.Text = obj.Bounds.Height.ToString();
            }

            UpdateControls();
         }

         if (_lbBubble.SelectedIndex == -1)
         {
            _tbBubbleLeft.Text = "";
            _tbBubbleTop.Text = "";
            _tbBubbleWidth.Text = "";
            _tbBubbleHeight.Text = "";
         }
      }

      private void _cbHideSelection_CheckedChanged(object sender, EventArgs e)
      {
         foreach (var obj in automation.Container.Children)
         {
            SingleSelectionField singleField = obj.Tag as SingleSelectionField;
            if (singleField != null && String.IsNullOrEmpty(singleField.Parent))
            {
               obj.IsVisible = !_cbHideSelectionAnn.Checked;
            }
         }

         if (_cbHideSelectionAnn.Checked)
            _cbHideSelectionAnn.Text = "Show Annotations";
         else
            _cbHideSelectionAnn.Text = "Hide Annotations";

         rasterImageViewer1.Invalidate();
      }

      private void _cbHideBubbleAnn_CheckedChanged(object sender, EventArgs e)
      {
         foreach (var obj in automation.Container.Children)
         {
            SingleSelectionField singleField = obj.Tag as SingleSelectionField;
            if (singleField != null && !String.IsNullOrEmpty(singleField.Parent) && _lbBubble.Items.Contains(singleField.Parent))
            {
               obj.IsVisible = !_cbHideBubbleAnn.Checked;
            }
            else if (obj.Tag is BubbleWordField && String.IsNullOrEmpty((obj.Tag as BubbleWordField).Parent))
            {
               obj.IsVisible = !_cbHideBubbleAnn.Checked;
            }
         }

         if (_cbHideBubbleAnn.Checked)
            _cbHideBubbleAnn.Text = "Show Annotations";
         else
            _cbHideBubbleAnn.Text = "Hide Annotations";

         rasterImageViewer1.Invalidate();
      }

      private void _btnEditSelection_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         SingleSelectionField singleSelectionField = selectedObject.Tag as SingleSelectionField;

         if (singleSelectionField != null)
         {
            SingleSelectionFieldDlg dlg = new SingleSelectionFieldDlg(this, singleSelectionField);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               isFieldDirty = true;
               UpdateControls();
            }
         }
      }

      public void UpdateSingleSelection(string oldName, SingleSelectionField singleSelectionField)
      {
         if (_lbSelection.Items.Contains(oldName))
         {
            _lbSelection.Items.Remove(oldName);
            _lbSelection.Items.Add(singleSelectionField.Name);
            _lbSelection.SelectedIndex = _lbSelection.Items.IndexOf(singleSelectionField.Name);
            rasterImageViewer1.Invalidate();
         }
      }

      public void UpdateBubbleWord(string oldName, BubbleWordField bubbleWordField)
      {
         if (_lbBubble.Items.Contains(oldName))
         {
            _lbBubble.Items.Remove(oldName);
            _lbBubble.Items.Add(bubbleWordField.Name);
            _lbBubble.SelectedIndex = _lbBubble.Items.IndexOf(bubbleWordField.Name);
            rasterImageViewer1.Invalidate();
         }
      }

#if LEADTOOLS_V20_OR_LATER
      public void UpdateOmrAnswerArea(string oldName, OmrAnswerAreaField omrAnswerAreaField)
      {
         if (_lbAnswerArea.Items.Contains(oldName))
         {
            _lbAnswerArea.Items.Remove(oldName);
            _lbAnswerArea.Items.Add(omrAnswerAreaField.Name);
            _lbAnswerArea.SelectedIndex = _lbAnswerArea.Items.IndexOf(omrAnswerAreaField.Name);
            rasterImageViewer1.Invalidate();
         }
      }

      public void UpdateOmrDateField(string oldName, OmrDateField omrDateField)
      {
         if (_lbOmrDate.Items.Contains(oldName))
         {
            _lbOmrDate.Items.Remove(oldName);
            _lbOmrDate.Items.Add(omrDateField.Name);
            _lbOmrDate.SelectedIndex = _lbOmrDate.Items.IndexOf(omrDateField.Name);
            rasterImageViewer1.Invalidate();

            SetOmrDateParentName(omrDateField);
         }
      }
#endif //#if LEADTOOLS_V20_OR_LATER

      private void _btnRemoveSelection_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         SingleSelectionField singleSelectionField = selectedObject.Tag as SingleSelectionField;

         if (singleSelectionField != null)
         {
            for (int i = automation.Container.Children.Count - 1; i >= 0; --i)
            {
               var field = automation.Container.Children[i];
               if (field.Tag is SingleSelectionField && field.Tag == singleSelectionField)
               {
                  automation.Container.Children.RemoveAt(i);
               }
            }

            _lbSelection.Items.Remove(singleSelectionField.Name);
            if (_lbSelection.Items.Count > 0)
               _lbSelection.SetSelected(_lbSelection.Items.Count - 1, true);

            isFieldDirty = true;

            rasterImageViewer1.Invalidate();
            UpdateControls();
         }
      }

      private void _btnEditBubble_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         BubbleWordField bubbleWordField = selectedObject.Tag as BubbleWordField;

         if (bubbleWordField != null)
         {
            BubbleWordFieldDlg dlg = new BubbleWordFieldDlg(this, bubbleWordField);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               isFieldDirty = true;
               UpdateControls();
            }
         }
      }

#if LEADTOOLS_V20_OR_LATER
      private void RemoveAnswerAreaField(OmrAnswerAreaField answerAreaField)
      {
         for (int i = automation.Container.Children.Count - 1; i >= 0; --i)
         {
            var field = automation.Container.Children[i];
            if (field.Tag is OmrAnswerAreaField && field.Tag == answerAreaField)
            {
               automation.Container.Children.RemoveAt(i);
            }
            else if (field.Tag is SingleSelectionField
               && (field.Tag as SingleSelectionField).Parent == answerAreaField.Name)
            {
               automation.Container.Children.RemoveAt(i);
            }
         }

         _lbAnswerArea.Items.Remove(answerAreaField.Name);
         if (_lbAnswerArea.Items.Count > 0)
            _lbAnswerArea.SetSelected(_lbAnswerArea.Items.Count - 1, true);
      }

      private void RemoveOmrDateField(OmrDateField omrDateField)
      {
         for (int i = automation.Container.Children.Count - 1; i >= 0; --i)
         {
            var field = automation.Container.Children[i];
            if (field.Tag is OmrDateField && field.Tag == omrDateField)
            {
               automation.Container.Children.RemoveAt(i);
            }
            else if (field.Tag is SingleSelectionField && !String.IsNullOrEmpty((field.Tag as SingleSelectionField).Parent) && (field.Tag as SingleSelectionField).Parent == omrDateField.Name)
            {
               automation.Container.Children.RemoveAt(i);
            }
            else if (field.Tag is BubbleWordField
               && !String.IsNullOrEmpty((field.Tag as BubbleWordField).Parent)
               && (field.Tag as BubbleWordField).Parent == omrDateField.Name)
            {
               RemoveBubble(field.Tag as BubbleWordField);
               i = automation.Container.Children.Count;
            }
         }

         _lbOmrDate.Items.Remove(omrDateField.Name);
         if (_lbOmrDate.Items.Count > 0)
            _lbOmrDate.SetSelected(_lbOmrDate.Items.Count - 1, true);
      }
#endif //#if LEADTOOLS_V20_OR_LATER

      private void RemoveBubble(BubbleWordField bubbleWordField)
      {
         List<SingleSelectionField> singleSelectionFields = new List<SingleSelectionField>(bubbleWordField.Fields);
         for (int i = automation.Container.Children.Count - 1; i >= 0; --i)
         {
            var field = automation.Container.Children[i];
            if (field.Tag is BubbleWordField && field.Tag == bubbleWordField)
            {
               automation.Container.Children.RemoveAt(i);
            }
            else if (field.Tag is SingleSelectionField
               && !String.IsNullOrEmpty((field.Tag as SingleSelectionField).Parent)
               && ((field.Tag as SingleSelectionField).Parent == bubbleWordField.Name
               || singleSelectionFields.Contains(field.Tag as SingleSelectionField)))
            {
               automation.Container.Children.RemoveAt(i);
            }
         }

         _lbBubble.Items.Remove(bubbleWordField.Name);
         if (_lbBubble.Items.Count > 0)
            _lbBubble.SetSelected(_lbBubble.Items.Count - 1, true);
      }

      private void _btnRemoveBubble_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         BubbleWordField bubbleWordField = selectedObject.Tag as BubbleWordField;

         if (bubbleWordField != null)
         {
            RemoveBubble(bubbleWordField);
            isFieldDirty = true;

            rasterImageViewer1.Invalidate();
            UpdateControls();
         }
      }
#if LEADTOOLS_V20_OR_LATER
      private void _btnOmrDate_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(OmrDateField));
      }

      private void _btnOmrAnswerArea_Click(object sender, EventArgs e)
      {
         EnableHighlight(typeof(OmrAnswerAreaField));
      }


      private void _lbAnswerArea_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (rasterImageList1.Items.Count > 0 && _lbAnswerArea.SelectedIndex != -1)
         {
            _lbFields.SelectedItem = null;
            _lbBubble.SelectedItem = null;
            _lbSelection.SelectedItem = null;

            AnnObject selectedObject = automation.CurrentEditObject;

            //New field in listbox. 
            for (int i = 0; i < automation.Container.Children.Count; ++i)
            {
               OmrAnswerAreaField obj = automation.Container.Children[i].Tag as OmrAnswerAreaField;
               if (obj != null && obj.Name == _lbAnswerArea.Text)
               {
                  selectedObject = automation.Container.Children[i];

                  if (automation.CurrentEditObject != selectedObject)
                  {
                     automation.SelectObject(selectedObject);
                  }
                  break;
               }
            }

            if (selectedObject.Tag as OmrAnswerAreaField != null)
            {
               OmrAnswerAreaField obj = selectedObject.Tag as OmrAnswerAreaField;

               _tbAnswerAreaLeft.Text = obj.Bounds.Left.ToString();
               _tbAnswerAreaTop.Text = obj.Bounds.Top.ToString();
               _tbAnswerAreaWidth.Text = obj.Bounds.Width.ToString();
               _tbAnswerAreaHeight.Text = obj.Bounds.Height.ToString();
            }
         }

         if (_lbAnswerArea.SelectedIndex == -1)
         {
            _tbAnswerAreaLeft.Text = "";
            _tbAnswerAreaTop.Text = "";
            _tbAnswerAreaWidth.Text = "";
            _tbAnswerAreaHeight.Text = "";
         }

         UpdateControls();
      }

      private void _btnRemoveAnswerArea_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         OmrAnswerAreaField answerAreaField = selectedObject.Tag as OmrAnswerAreaField;

         if (answerAreaField != null)
         {
            RemoveAnswerAreaField(answerAreaField);
            isFieldDirty = true;

            rasterImageViewer1.Invalidate();
            UpdateControls();
         }
      }

      private void _cbHideAnswerAnn_CheckedChanged(object sender, EventArgs e)
      {
         foreach (var obj in automation.Container.Children)
         {
            SingleSelectionField singleField = obj.Tag as SingleSelectionField;
            if (singleField != null && !String.IsNullOrEmpty(singleField.Parent) && _lbAnswerArea.Items.Contains(singleField.Parent))
            {
               obj.IsVisible = !_cbHideAnswerAnn.Checked;
            }
            else if (obj.Tag is OmrAnswerAreaField)
               obj.IsVisible = !_cbHideAnswerAnn.Checked;
         }

         if (_cbHideAnswerAnn.Checked)
            _cbHideAnswerAnn.Text = "Show Annotations";
         else
            _cbHideAnswerAnn.Text = "Hide Annotations";

         rasterImageViewer1.Invalidate();
      }

      private void _btnEditAnswerArea_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         OmrAnswerAreaField omrAnswerAreaField = selectedObject.Tag as OmrAnswerAreaField;

         if (omrAnswerAreaField != null)
         {
            OmrAnswerAreaFieldDlg dlg = new OmrAnswerAreaFieldDlg(this, omrAnswerAreaField);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               isFieldDirty = true;
               UpdateControls();
            }
         }
      }

      private void _btnRemoveOmrDate_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         OmrDateField omrDateField = selectedObject.Tag as OmrDateField;

         if (omrDateField != null)
         {
            RemoveOmrDateField(omrDateField);
            isFieldDirty = true;

            rasterImageViewer1.Invalidate();
            UpdateControls();
         }
      }

      private void _lbOmrDate_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (rasterImageList1.Items.Count > 0 && _lbOmrDate.SelectedIndex != -1)
         {
            _lbFields.SelectedItem = null;
            _lbBubble.SelectedItem = null;
            _lbSelection.SelectedItem = null;
            _lbAnswerArea.SelectedItem = null;

            AnnObject selectedObject = automation.CurrentEditObject;

            //New field in listbox. 
            for (int i = 0; i < automation.Container.Children.Count; ++i)
            {
               OmrDateField obj = automation.Container.Children[i].Tag as OmrDateField;
               if (obj != null && obj.Name == _lbOmrDate.Text)
               {
                  selectedObject = automation.Container.Children[i];

                  if (automation.CurrentEditObject != selectedObject)
                  {
                     automation.SelectObject(selectedObject);
                  }
                  break;
               }
            }

            if (selectedObject.Tag as OmrDateField != null)
            {
               OmrDateField obj = selectedObject.Tag as OmrDateField;

               _tbOmrDateLeft.Text = obj.Bounds.Left.ToString();
               _tbOmrDateTop.Text = obj.Bounds.Top.ToString();
               _tbOmrDateWidth.Text = obj.Bounds.Width.ToString();
               _tbOmrDateHeight.Text = obj.Bounds.Height.ToString();
            }
         }

         if (_lbOmrDate.SelectedIndex == -1)
         {
            _tbOmrDateLeft.Text = "";
            _tbOmrDateTop.Text = "";
            _tbOmrDateWidth.Text = "";
            _tbOmrDateHeight.Text = "";
         }

         UpdateControls();
      }

      private void _cbHideOmrDateAnn_CheckedChanged(object sender, EventArgs e)
      {
         List<SingleSelectionField> singleSelectionFields = new List<SingleSelectionField>();

         for (int i = 0; i < automation.Container.Children.Count; ++i)
         {
            if (automation.Container.Children[i].Tag is OmrDateField)
            {
               singleSelectionFields.Add((automation.Container.Children[i].Tag as OmrDateField).MonthField);
               singleSelectionFields.AddRange((automation.Container.Children[i].Tag as OmrDateField).DayField.Fields);
               singleSelectionFields.AddRange((automation.Container.Children[i].Tag as OmrDateField).YearField.Fields);
            }
         }

         foreach (var obj in automation.Container.Children)
         {
            SingleSelectionField singleField = obj.Tag as SingleSelectionField;
            if (singleField != null && ((!String.IsNullOrEmpty(singleField.Parent) && _lbOmrDate.Items.Contains(singleField.Parent)) || singleSelectionFields.Contains(singleField)))
            {
               obj.IsVisible = !_cbHideOmrDateAnn.Checked;
            }
            else if (obj.Tag is BubbleWordField && !String.IsNullOrEmpty((obj.Tag as BubbleWordField).Parent) && _lbOmrDate.Items.Contains((obj.Tag as BubbleWordField).Parent))
            {
               obj.IsVisible = !_cbHideOmrDateAnn.Checked;
            }
            else if (obj.Tag is OmrDateField)
            {
               obj.IsVisible = !_cbHideOmrDateAnn.Checked;
            }
         }

         if (_cbHideOmrDateAnn.Checked)
            _cbHideOmrDateAnn.Text = "Show Annotations";
         else
            _cbHideOmrDateAnn.Text = "Hide Annotations";

         rasterImageViewer1.Invalidate();
      }

      private void _btnEditOmrDate_Click(object sender, EventArgs e)
      {
         AnnObject selectedObject = automation.CurrentEditObject;

         OmrDateField omrDateField = selectedObject.Tag as OmrDateField;

         if (omrDateField != null)
         {
            OmrDateFieldDlg dlg = new OmrDateFieldDlg(this, omrDateField);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               isFieldDirty = true;
               UpdateControls();
            }
         }
      }
#endif //#if LEADTOOLS_V20_OR_LATER

#if FOR_DOTNET4
      IFullTextSearchManager CreateFullTextSearchManager(string path)
      {
         DiskFullTextSearchManager fullTextSearchManager = new DiskFullTextSearchManager();
         fullTextSearchManager.IndexDirectory = Path.Combine(path, "index");
         return fullTextSearchManager;
      }
#endif

      private void _useFullTextSearchButton_Click(object sender, EventArgs e)
      {
#if FOR_DOTNET4
         ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
         _useFullTextSearchButton.Image = _useFullTextSearchButton.Checked ? ((Image)(resources.GetObject("_useFullTextSearchButton_checked.Image"))) :
         ((Image)(resources.GetObject("_useFullTextSearchButton_Unchecked.Image")));
            

         if (_useFullTextSearchButton.Checked)
         {
            recognitionEngine.FullTextSearchManager = CreateFullTextSearchManager(workingRepository.Path);
         }
#endif
      }
   }
}
