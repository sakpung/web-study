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

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.ImageProcessing;
using Leadtools.Annotations.Engine;
using Leadtools.Pdf.Annotations;
using Leadtools.Annotations.WinForms;
using Leadtools.Annotations.Automation;
using Leadtools.Document.Writer;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Leadtools.Pdf;
using Leadtools.Annotations.Rendering;
using Leadtools.Svg;

namespace DocumentWritersDemo
{
   public partial class MainForm : Form
   {
      private RasterCodecs _rasterCodecsInstance;
      private DocumentWriter _documentWriterInstance;
      private string _lastSavedDocumentFileName;
      private RasterDialogRasterizeDocumentFileOptions _rasterizeDocOptions;
      private string _rtfFileName;
      private Dictionary<int, string> _emfFileNames;
      private Dictionary<int, int> _rtfDictionary; // to keep rtf pages associated with container pages 
      private bool _isRtfLoaded;
      private bool _isEmfLoaded;
      private const int _rtfEmfStampTag = 1234; // We use this tag to identify Rtf and Emf stamps
      private List<PdfCustomBookmark> _pdfCustomBookmarks = new List<PdfCustomBookmark>();
      Random _randomNumber = new Random();


      public MainForm()
      {
         InitializeComponent();

         if (!DesignMode)
         {
            // Setup the caption for this demo
            Messager.Caption = "C# Document Writers Demo";
            Text = Messager.Caption;

            _rasterCodecsInstance = new RasterCodecs();
            _viewerControl.Title = "Document";
            _viewerControl.RasterCodecsInstance = _rasterCodecsInstance;

            _documentWriterInstance = new DocumentWriter();
         }
      }

      public ViewerControl Viewer
      {
         get { return _viewerControl; }
      }

      private void CreateTextObject(int x0, int y0, int x1, int y1, string text)
      {
         AnnTextObject annObject = new AnnTextObject();
         annObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("transparent"), LeadLengthD.Create(1));
         annObject.IsVisible = true;
         annObject.Text = text;
         RectangleF rect = new RectangleF(x0, y0, x1 - x0, y1 - y0);
         LeadMatrix mm = _viewerControl.RasterImageViewer.ViewTransform;
         Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
         Transformer ts = new Transformer(m);
         rect = ts.RectangleToPhysical(rect);

         LeadRectD leadrect = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height);
         leadrect = _viewerControl.Automation.Container.Mapper.RectToContainerCoordinates(leadrect);
         annObject.Rect = leadrect;
         annObject.TextForeground = AnnSolidColorBrush.Create("Red");
         annObject.Font = new AnnFont("Arial", 11);
         annObject.Font.FontStyle = AnnFontStyle.Normal;
         _viewerControl.Automation.Container.Children.Add(annObject);
      }

      private void CreateStampAndTextObjects()
      {
         // stamp
         AnnStampObject stamp = new AnnStampObject();
         stamp.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), new LeadLengthD(4));
         stamp.IsVisible = true;

         AnnContainer container = _viewerControl.Automation.Container;
         LeadPointD origin = new LeadPointD(0, 0);
         RectangleF rect = new RectangleF((float)75, (float)100, (float)675, (float)875);
         LeadMatrix mm = _viewerControl.RasterImageViewer.ViewTransform;
         Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
         Transformer ts = new Transformer(m);
         rect = ts.RectangleToPhysical(rect);

         LeadRectD leadrect = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height);
         leadrect = container.Mapper.RectToContainerCoordinates(leadrect);

         stamp.Rect = leadrect;
         stamp.Font = new AnnFont("Arial", 48);
         stamp.Text = "";
         stamp.Font.FontStyle = AnnFontStyle.Normal;

         try
         {
            System.Drawing.Bitmap StampPic = global::DocumentWritersDemo.Properties.Resources.ExpenseReport;
            ImageConverter converter = new ImageConverter();
            using (MemoryStream ms = new MemoryStream())
            {
               StampPic.Save(ms, ImageFormat.Bmp);
               stamp.Picture = new AnnPicture(ms.ToArray());
               container.Children.Add(stamp);
            }
         }
         catch (Exception)
         {
         }

         // text (submitted by)
         CreateTextObject(305, 230, 690, 250, "Terry Smith");

         // text (submit date)
         CreateTextObject(305, 260, 690, 280, "06/05/2009");

         // text (description )
         CreateTextObject(305, 285, 690, 305, "Food");

         // text (item description )
         CreateTextObject(145, 465, 365, 485, "Joe's Restaurant");

         // text (item cost )
         CreateTextObject(465, 465, 535, 485, "$9.50");

         // text (item date )
         CreateTextObject(370, 465, 450, 485, "06/01/2009");

         // text (total )
         CreateTextObject(465, 700, 535, 720, "$9.50");

         // Ellipse
         AnnEllipseObject ellipse = new AnnEllipseObject();
         ellipse.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), new LeadLengthD(4));

         rect = new RectangleF((float)430, (float)685, (float)100, (float)60);
         mm = _viewerControl.RasterImageViewer.ViewTransform;
         m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
         ts = new Transformer(m);
         rect = ts.RectangleToPhysical(rect);

         leadrect = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height);
         leadrect = container.Mapper.RectToContainerCoordinates(leadrect);

         ellipse.Rect = leadrect;
         container.Children.Add(ellipse);

         // StickyNote
         AnnNoteObject note = new AnnNoteObject();
         note.Text = "\r\nJohn, please review this when you get a chance.\r\n\r\n-- Thanks";
         note.TextForeground = AnnSolidColorBrush.Create("Red");
         note.Font = new AnnFont("Arial", 11);
         note.Font.FontStyle = AnnFontStyle.Normal;
         note.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), new LeadLengthD(1));
         note.Fill = AnnSolidColorBrush.Create("Yellow");

         rect = new RectangleF((float)540, (float)130, (float)200, (float)130);
         mm = _viewerControl.RasterImageViewer.ViewTransform;
         m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
         ts = new Transformer(m);
         rect = ts.RectangleToPhysical(rect);

         leadrect = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height);
         leadrect = container.Mapper.RectToContainerCoordinates(leadrect);

         note.Rect = leadrect;
         container.Children.Add(note);
      }

      protected override void OnLoad(EventArgs e)
      {
         try
         {
            if (!DesignMode && _viewerControl.AutomationManager != null)
            {
               // Add the objects to the annotations objects menu
               AnnAutomationManager automationManager = _viewerControl.AutomationManager;
               foreach (AnnAutomationObject obj in automationManager.Objects)
               {
                  if (obj.Id != AnnObject.GroupObjectId)
                  {
                     ToolStripMenuItem item = new ToolStripMenuItem(obj.Name);
                     item.Click += new EventHandler(_annotationsCurrentObjectItem_Click);
                     item.Tag = obj.Id;
                     _annotationsCurrentObjectToolStripMenuItem.DropDownItems.Add(item);
                  }
               }

               // Tie the automation manager objects
               _pagesControl.SetAutomation(_viewerControl.AutomationManager, _viewerControl.Automation);

               // Create a new document
               NewDocument(8.5F, 11, 300, 300);

               // Create a stamp annotation with text objects
               CreateStampAndTextObjects();

               PdfDocumentOptions pdfOptions = _documentWriterInstance.GetOptions(DocumentFormat.Pdf) as PdfDocumentOptions;
               pdfOptions.FontEmbedMode = DocumentFontEmbedMode.None;
               if(string.IsNullOrEmpty(pdfOptions.Creator))
                  pdfOptions.Creator = "LEADTOOLS PDFWriter";
               if (string.IsNullOrEmpty(pdfOptions.Producer))
                  pdfOptions.Producer = "LEAD Technologies, Inc.";
               _documentWriterInstance.SetOptions(DocumentFormat.Pdf, pdfOptions);

               _viewerControl.automationInteractiveMode.IsEnabled = true;
               _viewerControl.RasterImageViewer.InteractiveModes.EnableById(_viewerControl.automationInteractiveMode.Id);

               BeginInvoke(new MethodInvoker(ShowWelcomeMessage));
            }

            base.OnLoad(e);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void ShowWelcomeMessage()
      {

         Messager.ShowInformation(this, "This example demonstrates how to use the LEADTOOLS Document Writers functionality to convert RTF and EMF documents into PDF files. This example has annotation functionality, which can be used to create PDF files. This example also allows you to convert RTF and EMF files using the LEADTOOLS Document Writers and then save them to one multi-page PDF file. For a list of Document Writers, see https://www.leadtools.com/sdk/document/document-writers");

      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         _rasterCodecsInstance.Dispose();

         base.OnFormClosed(e);
      }

      private void _fileNewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            // Get the last properties
            Properties.Settings settings = new Properties.Settings();

            float width = 8.5F;
            float height = 11;
            int resolution = 300;

            if (!string.IsNullOrEmpty(settings.NewDocumentWidth))
            {
               float val;
               if (float.TryParse(settings.NewDocumentWidth, out val))
                  width = val;
            }

            if (!string.IsNullOrEmpty(settings.NewDocumentHeight))
            {
               float val;
               if (float.TryParse(settings.NewDocumentHeight, out val))
                  height = val;
            }

            if (!string.IsNullOrEmpty(settings.NewDocumentResolution))
            {
               int val;
               if (int.TryParse(settings.NewDocumentResolution, out val))
                  resolution = val;
            }

            using (NewDocumentDialogBox dlg = new NewDocumentDialogBox(width, height, resolution))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {

                  _isEmfLoaded = _isRtfLoaded = false;

                  // Save the settings
                  settings.NewDocumentWidth = dlg.DocumentWidth.ToString();
                  settings.NewDocumentHeight = dlg.DocumentHeight.ToString();
                  settings.NewDocumentResolution = dlg.DocumentResolution.ToString();
                  settings.Save();


                  //Clear the existing containers , we will create new one when setting the document to viewer
                  _viewerControl.Automation.Containers.Clear();

                  NewDocument(dlg.DocumentWidth, dlg.DocumentHeight, dlg.DocumentResolution, dlg.DocumentResolution);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _fileSaveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         PdfDocumentOptions pdfOptions = _documentWriterInstance.GetOptions(DocumentFormat.Pdf) as PdfDocumentOptions;

         try
         {
            double pageWidth = 0, pageHeight = 0; // in inches
            int emptyPageResolution;

            using (SavePdfDialog dlg = new SavePdfDialog(_lastSavedDocumentFileName, pdfOptions, _isRtfLoaded ? _rasterizeDocOptions.XResolution : _viewerControl.RasterImage.XResolution, _pagesControl.RasterImageList.Items.Count))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  _lastSavedDocumentFileName = dlg.DocumentFileName;
                  if (!_isEmfLoaded && !_isRtfLoaded)
                  {
                     emptyPageResolution = pdfOptions.DocumentResolution;
                     // The saving of annotations only (without loading RTF or EMF) 
                     // Needs empty page resolution instead of document resolution
                     pdfOptions.EmptyPageResolution = emptyPageResolution;
                     pdfOptions.DocumentResolution = 0;
                     pageWidth = (double)_viewerControl.RasterImage.Width / pdfOptions.EmptyPageResolution;
                     pageHeight = (double)_viewerControl.RasterImage.Height / pdfOptions.EmptyPageResolution;
                     pdfOptions.EmptyPageWidth = pageWidth * 72.0 / pdfOptions.EmptyPageResolution;
                     pdfOptions.EmptyPageHeight = pageHeight * 72.0 / pdfOptions.EmptyPageResolution;
                     pdfOptions.PageRestriction = DocumentPageRestriction.Relaxed;
                     pdfOptions.ImageOverText = true;

                     // Clear the bookmarks list we previously created inside the PdfDocumentOptions.
                     if (pdfOptions.CustomBookmarks.Count != 0)
                        pdfOptions.CustomBookmarks.Clear();

                     // Set the bookmarks into the PDF options.
                     pdfOptions.AutoBookmarksEnabled = false;
                     List<PdfCustomBookmark> pdfBookmarks = GetCustomBookmarks();
                     foreach (PdfCustomBookmark bookmark in pdfBookmarks)
                     {
                        pdfOptions.CustomBookmarks.Add(bookmark);
                     }
                  }

                  _documentWriterInstance.SetOptions(DocumentFormat.Pdf, pdfOptions);

                  SaveDocument(dlg.DocumentFileName, pdfOptions, pageWidth, pageHeight);
               }
            }
         }
         catch (Exception)
         {
         }

      }

      private List<PdfCustomBookmark> GetCustomBookmarks()
      {
         List<PdfCustomBookmark> pdfBookmarks = new List<PdfCustomBookmark>();
         foreach (TreeNode parentNode in _pagesControl.PdfBookmarksList.Nodes)
         {
            EnumerateChildNodes(parentNode, pdfBookmarks);
         }

         return pdfBookmarks;
      }

      private void EnumerateChildNodes(TreeNode parentNode, List<PdfCustomBookmark> pdfBookmarks)
      {
         PdfCustomBookmark pdfBookmark = (PdfCustomBookmark)parentNode.Tag;
         pdfBookmarks.Add(pdfBookmark);
         foreach (TreeNode node in parentNode.Nodes)
         {
            EnumerateChildNodes(node, pdfBookmarks);
         }
      }


      private void _fileExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         bool documentHasPages = automation != null && _viewerControl.RasterImage.PageCount > 0;

         if (documentHasPages)
         {
            _editUndoToolStripMenuItem.Enabled = automation.CanUndo;
            _editRedoToolStripMenuItem.Enabled = automation.CanRedo;
            _editCutToolStripMenuItem.Enabled = automation.CanCopy;
            _editCopyToolStripMenuItem.Enabled = automation.CanCopy;
            _editPasteToolStripMenuItem.Enabled = automation.CanPaste;
            _editDeleteToolStripMenuItem.Enabled = automation.CanDeleteObjects;
            _editSelectAllToolStripMenuItem.Enabled = automation.CanSelectObjects;
            _editSelectNoneToolStripMenuItem.Enabled = automation.CanSelectNone;
         }
         else
         {
            _editUndoToolStripMenuItem.Enabled = false;
            _editRedoToolStripMenuItem.Enabled = false;
            _editCutToolStripMenuItem.Enabled = false;
            _editCopyToolStripMenuItem.Enabled = false;
            _editPasteToolStripMenuItem.Enabled = false;
            _editDeleteToolStripMenuItem.Enabled = false;
            _editSelectAllToolStripMenuItem.Enabled = false;
            _editSelectNoneToolStripMenuItem.Enabled = false;
         }
      }

      private void _editUndoToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanUndo)
            automation.Undo();
      }

      private void _editRedoToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanRedo)
            automation.Redo();
      }

      private void _editCutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanCopy)
         {
            automation.Copy();
            automation.DeleteSelectedObjects();
         }
      }

      private void _editCopyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanCopy)
            automation.Copy();
      }

      private void _editPasteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanPaste)
            automation.Paste();
      }

      private void _editDeleteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanDeleteObjects)
            automation.DeleteSelectedObjects();
      }

      private void _editSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanSelectObjects)
            automation.SelectObjects(automation.Container.Children);
      }

      private void _editSelectNoneToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null && automation.CanSelectNone)
            automation.SelectObjects(null);
      }

      private void _annotationsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation != null)
         {
            _annotationsPropertiesToolStripMenuItem.Enabled = automation.CanShowObjectProperties;
         }
         else
         {
            _annotationsPropertiesToolStripMenuItem.Enabled = false;
         }
      }

      private void _annotationsCurrentObjectToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Check the current object id item
         AnnAutomationManager automationManager = _viewerControl.AutomationManager;
         if (automationManager != null)
         {
            int currentObjectId = automationManager.CurrentObjectId;

            foreach (ToolStripMenuItem item in _annotationsCurrentObjectToolStripMenuItem.DropDownItems)
            {
               int id = (int)item.Tag;
               item.Checked = (id == currentObjectId);
            }
         }
      }

      private void _annotationsCurrentObjectItem_Click(object sender, EventArgs e)
      {
         // Select the new object
         AnnAutomationManager automationManager = _viewerControl.AutomationManager;
         ToolStripMenuItem item = sender as ToolStripMenuItem;
         int id = (int)item.Tag;
         automationManager.CurrentObjectId = id;
      }

      private void _annotationsAlignToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         if (automation != null)
         {
            _alignBringToFrontToolStripMenuItem.Enabled = automation.CanBringToFront;
            _alignSendToBackToolStripMenuItem.Enabled = automation.CanSendToBack;
            _alignBringToFirstToolStripMenuItem.Enabled = automation.CanBringToFirst;
            _alignSendToLastToolStripMenuItem.Enabled = automation.CanSendToLast;
         }
         else
         {
            _alignBringToFrontToolStripMenuItem.Enabled = false;
            _alignSendToBackToolStripMenuItem.Enabled = false;
            _alignBringToFirstToolStripMenuItem.Enabled = false;
            _alignSendToLastToolStripMenuItem.Enabled = false;
         }
      }

      private void _alignBringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanBringToFront)
            automation.BringToFront(false);
      }

      private void _alignSendToBackToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanSendToBack)
            automation.SendToBack(false);
      }

      private void _alignBringToFirstToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanBringToFirst)
            automation.BringToFront(true);
      }

      private void _alignSendToLastToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanSendToLast)
            automation.SendToBack(true);
      }

      private void _flipHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanFlip)
            automation.Flip(true);
      }

      private void _flipVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanFlip)
            automation.Flip(false);
      }

      private void _groupSelectedObjectsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         AnnContainer annContainer = _viewerControl.Automation.Container;
         if (annContainer.SelectionObject != null && annContainer.SelectionObject.SelectedObjects.Count > 1)
         {
            string groupName = string.Format("Group{0}", _randomNumber.Next() % 100);
            foreach (AnnObject annObject in annContainer.SelectionObject.SelectedObjects)
            {
               annObject.GroupName = groupName;
            }
         }
      }

      private void _groupUngroupToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanUngroup)
         {
            AnnContainer annContainer = _viewerControl.Automation.Container;
            if (annContainer.SelectionObject != null && annContainer.SelectionObject.SelectedObjects.Count > 1)
            {
               annContainer.SelectionObject.Ungroup(annContainer.SelectionObject.SelectedObjects[0].GroupName);
            }
         }
      }

      private void _annotationsResetRotatePointsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation.CanResetRotatePoints)
            automation.ResetRotatePoints();
      }

      private void _annotationsPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;

         if (automation != null)
         {
            if (automation.CanShowObjectProperties)
               automation.ShowObjectProperties();
         }

      }

      private void _helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Document Writers", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }


      private void _newToolStripButton_Click(object sender, EventArgs e)
      {
         _fileNewToolStripMenuItem.PerformClick();
      }

      private void _saveToolStripButton_Click(object sender, EventArgs e)
      {
         _fileSaveToolStripMenuItem.PerformClick();
      }

      private void _copyToolStripButton_Click(object sender, EventArgs e)
      {
         _editCopyToolStripMenuItem.PerformClick();
      }

      private void _pasteToolStripButton_Click(object sender, EventArgs e)
      {
         _editPasteToolStripMenuItem.PerformClick();
      }

      private void _deleteToolStripButton_Click(object sender, EventArgs e)
      {
         _editDeleteToolStripMenuItem.PerformClick();
      }

      private void _undoToolStripButton_Click(object sender, EventArgs e)
      {
         _editUndoToolStripMenuItem.PerformClick();
      }

      private void _redoToolStripButton_Click(object sender, EventArgs e)
      {
         _editRedoToolStripMenuItem.PerformClick();
      }

      private void _pagesControl_Action(object sender, ActionEventArgs e)
      {
         switch (e.Action)
         {
            case "NewPage":
               AddNewPage();
               break;

            case "DeletePage":
               DeleteCurrentPage();
               break;

            case "MovePageUp":
               MoveCurrentPage(true);
               break;

            case "MovePageDown":
               MoveCurrentPage(false);
               break;

            case "PageNumberChanged":
               {
                  int pageNumber = (int)e.Data;
                  GotoPage(pageNumber);
               }
               break;

            case "CenterAtPoint":
               {
                  PdfCustomBookmark pdfBookmark = (PdfCustomBookmark)e.Data;
                  PointF bookmarkPosition = new PointF((float)pdfBookmark.XCoordinate, (float)pdfBookmark.YCoordinate);

                  bookmarkPosition.X = bookmarkPosition.X / (_viewerControl.RasterImageViewer.Image.XResolution / 96);
                  bookmarkPosition.Y = bookmarkPosition.Y / (_viewerControl.RasterImageViewer.Image.YResolution / 96);

                  LeadMatrix LMatrix = _viewerControl.RasterImageViewer.ImageTransform;//.ImageTransform;
                  Matrix m = new Matrix((float)LMatrix.M11, (float)LMatrix.M12, (float)LMatrix.M21, (float)LMatrix.M22, (float)LMatrix.OffsetX, (float)LMatrix.OffsetY);
                  Transformer t = new Transformer(m);
                  bookmarkPosition = t.PointToPhysical(bookmarkPosition);

                  GotoPage(pdfBookmark.PageNumber);
                  if (pdfBookmark.PageNumber <= _pagesControl.RasterImageList.Items.Count)
                     _viewerControl.RasterImageViewer.CenterAtPoint(LeadPoint.Create((int)bookmarkPosition.X, (int)bookmarkPosition.Y));
               }
               break;

            default:
               break;
         }
      }

      private void _viewerControl_Action(object sender, ActionEventArgs e)
      {
         switch (e.Action)
         {
            case "PageNumberChanged":
               {
                  int pageNumber = (int)e.Data;
                  GotoPage(pageNumber);
               }
               break;

            case "UpdateUIState":
               UpdateUIState();
               // Re-paint the thumbnails
               _pagesControl.RasterImageList.Invalidate();
               break;

            case "UpdateBookmarkPosition":
               _pagesControl.BookmarkPosition = (Point)e.Data;
               break;

            default:
               break;
         }
      }

      private void NewDocument(float widthInInches, float heightInInches, int dpiX, int dpiY)
      {
         // Create a new empty RasterImage object with one page with
         // the specified DPI

         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               RasterImage image = CreateNewDocumentPage(null, widthInInches, heightInInches, dpiX, dpiY);
               _viewerControl.SetDocument(image);

               if (_viewerControl.AutomationManager != null)
               {
                  // Clear the pages image list and add the new page
                  ImageViewer imageList = _pagesControl.RasterImageList;
                  imageList.BeginUpdate();
                  imageList.Items.Clear();

                  // Create a thumbnail for the image and add it to the image list
                  RasterImage thumbnailImage = CreateThumbnailImage(image, 160, 160, 24);
                  thumbnailImage.XResolution = 96;
                  thumbnailImage.YResolution = 96;
                  ImageViewerItem item = new ImageViewerItem();
                  item.Image = thumbnailImage;
                  item.PageNumber = 1;
                  item.Tag = image.Clone();
                  imageList.Items.Add(item);
                  item.Text = "Page 1";

                  imageList.EndUpdate();

                  GotoPage(1);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private RasterImage CreateNewDocumentPage(RasterImage image, float widthInInches, float heightInInches, int dpiX, int dpiY)
      {
         int width;
         int height;
         int xResolution;
         int yResolution;

         // See if image is not null, then create the new page as the same
         // size of the image
         if (image != null)
         {
            width = image.Width;
            height = image.Height;
            xResolution = image.XResolution;
            yResolution = image.YResolution;
         }
         else
         {
            width = (int)(widthInInches * dpiX);
            height = (int)(heightInInches * dpiY);
            xResolution = dpiX;
            yResolution = dpiY;
         }

         RasterImage page = new RasterImage(
            RasterMemoryFlags.Conventional,
            width,
            height,
            1,
            RasterByteOrder.Rgb,
            RasterViewPerspective.TopLeft,
            null,
            IntPtr.Zero,
            0);
         page.XResolution = xResolution;
         page.YResolution = yResolution;

         // Fill with white

         FillCommand cmd = new FillCommand(Leadtools.Demos.Converters.FromGdiPlusColor(Color.White));

         cmd.Run(page);

         return page;
      }

      private static RasterImage CreateThumbnailImage(RasterImage image, int thumbnailWidth, int thumbnailHeight, int bitsPerPixel)
      {
         // Creates a thumbnail for the image
         // First clone the image
         RasterImage destinationImage = image.Clone();

         // See if we need to change the bits/pixel
         if (destinationImage.BitsPerPixel != bitsPerPixel)
         {
            ColorResolutionCommand colorResolutionCommand = new ColorResolutionCommand(
               ColorResolutionCommandMode.InPlace,
               bitsPerPixel,
               RasterByteOrder.Bgr,
               RasterDitheringMethod.Clustered,
               ColorResolutionCommandPaletteFlags.Optimized,
               null);
            colorResolutionCommand.Run(destinationImage);
         }

         // See if we need to change the view perspective
         if (destinationImage.ViewPerspective != RasterViewPerspective.TopLeft)
         {
            ChangeViewPerspectiveCommand changeViewPerspectiveCommand = new ChangeViewPerspectiveCommand(true, RasterViewPerspective.TopLeft);
            changeViewPerspectiveCommand.Run(destinationImage);
         }

         // Get the real size of the image (including DPI)
         int imageWidth = image.ImageWidth * 96 / image.XResolution;
         int imageHeight = image.ImageHeight * 96 / image.YResolution;

         if (imageWidth > thumbnailWidth || imageHeight > thumbnailHeight)
         {
            double factor;

            if (thumbnailWidth > thumbnailHeight)
            {
               factor = (double)thumbnailWidth / (double)imageWidth;
               if ((factor * (double)imageHeight) > (double)thumbnailHeight)
                  factor = (double)thumbnailHeight / (double)imageHeight;
            }
            else
            {
               factor = (double)thumbnailHeight / (double)imageHeight;
               if ((factor * (double)imageWidth) > (double)thumbnailWidth)
                  factor = (double)thumbnailWidth / (double)imageWidth;
            }

            int scaledImageWidth = (int)(factor * imageWidth);
            int scaledImageHeight = (int)(factor * imageHeight);

            // Resize it
            SizeCommand sizeCommand = new SizeCommand(scaledImageWidth, scaledImageHeight, RasterSizeFlags.Bicubic);
            sizeCommand.Run(destinationImage);
         }

         return destinationImage;
      }

      private void GotoPage(int pageNumber)
      {
         // Go to the page number in the viewer and pages controls
         _viewerControl.SetCurrentPageNumber(pageNumber);
         _pagesControl.SetCurrentPageNumber(pageNumber);
         UpdateUIState();
      }

      private void AddNewPage()
      {
         // Add a new page to the document
         try
         {
            RasterImage page = CreateNewDocumentPage(_viewerControl.RasterImage, 0, 0, 0, 0);

            // Clear the pages image list and add the new page
            ImageViewer imageList = _pagesControl.RasterImageList;

            imageList.BeginUpdate();

            // Create a thumbnail for the image and add it to the image list
            RasterImage thumbnailImage = CreateThumbnailImage(page, 160, 160, 24);

            int pageNumber = _viewerControl.RasterImage.PageCount + 1;
            ImageViewerItem item = new ImageViewerItem();
            item.Image = thumbnailImage;
            item.Tag = pageNumber;
            item.Text = "Page " + pageNumber.ToString();
            item.Tag = page.Clone();
            imageList.Items.Add(item);

            imageList.EndUpdate();

            // Add the page to the viewer
            // This will call RasterImage.AddPage which will dispose "page"
            _viewerControl.RasterImageViewer.Zoom(ControlSizeMode.ActualSize, 1, _viewerControl.RasterImageViewer.DefaultZoomOrigin);
            _viewerControl.RasterImageViewer.UseDpi = false;

            _viewerControl.AddPage(page, page.ImageWidth, page.ImageHeight);

            GotoPage(pageNumber);

            _viewerControl.RasterImageViewer.Zoom(ControlSizeMode.Fit, 1, _viewerControl.RasterImageViewer.DefaultZoomOrigin);
            _viewerControl.RasterImageViewer.UseDpi = true;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void AddNewPage(float width, float Height, int dpiX, int dpiY)
      {
         // Add a new page to the document
         try
         {
            RasterImage page = CreateNewDocumentPage(null, width, Height, dpiX, dpiY);

            // Clear the pages image list and add the new page
            ImageViewer imageList = _pagesControl.RasterImageList;

            imageList.BeginUpdate();

            // Create a thumbnail for the image and add it to the image list
            RasterImage thumbnailImage = CreateThumbnailImage(page, 160, 160, 24);
            int pageNumber = _viewerControl.RasterImage.PageCount + 1;
            ImageViewerItem item = new ImageViewerItem();
            item.Image = thumbnailImage;
            item.Tag = pageNumber;
            item.Text = "Page " + pageNumber.ToString();
            imageList.Items.Add(item);

            imageList.EndUpdate();

            // Add the page to the viewer
            // This will call RasterImage.AddPage which will dispose "page"
            _viewerControl.AddPage(page, page.ImageWidth, page.ImageHeight);

            GotoPage(pageNumber);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void DeleteCurrentPage()
      {
         // Delete the current page
         int pageNumber = _viewerControl.RasterImage.Page;

         _viewerControl.DeleteCurrentPage();
         _pagesControl.DeleteCurrentPage();

         // Update the text for the thumbnails
         ImageViewer imageList = _pagesControl.RasterImageList;
         for (int i = 0; i < imageList.Items.Count; i++)
            imageList.Items[i].Text = "Page " + (i + 1).ToString();


         // Update Rtf and Emf pages according to container pages
         if (_isRtfLoaded && _rtfDictionary.ContainsKey(pageNumber))
         {
            if (_rtfDictionary.ContainsKey(pageNumber + 1))
            {
               for (int i = pageNumber; i <= _viewerControl.AutomationManager.Automations.Count; i++)
               {
                  if (_rtfDictionary.ContainsKey(i))
                  {
                     if (_rtfDictionary.ContainsKey(i + 1))
                     {
                        _rtfDictionary[i] = _rtfDictionary[i + 1];
                     }
                     else
                     {
                        _rtfDictionary.Remove(i + 1);
                        break;
                     }
                  }
               }
            }
            else
            {
               _rtfDictionary.Remove(pageNumber + 1);
            }
         }
         else if (_isEmfLoaded && _emfFileNames.ContainsKey(pageNumber))
         {
            if (_emfFileNames.ContainsKey(pageNumber + 1))
            {
               for (int i = pageNumber; i <= _viewerControl.AutomationManager.Automations.Count; i++)
               {
                  if (_emfFileNames.ContainsKey(i))
                  {
                     if (_emfFileNames.ContainsKey(i + 1))
                     {
                        _emfFileNames[i] = _emfFileNames[i + 1];
                     }
                     else
                     {
                        _emfFileNames.Remove(i + 1);
                        break;
                     }
                  }
               }
            }
            else
            {
               _emfFileNames.Remove(pageNumber + 1);
            }
         }


         if (pageNumber > _viewerControl.RasterImage.PageCount)
            pageNumber = _viewerControl.RasterImage.PageCount;

         // Go to the current page
         GotoPage(pageNumber);
      }

      private void MoveCurrentPage(bool up)
      {
         // Move the current page up or down
         // We will do the move by swapping the two pages

         RasterImage image = _viewerControl.RasterImage;
         image.Page = _viewerControl.RasterImage.Page;

         // Get the page numbers to move
         int pageNumber1 = image.Page;
         int pageNumber2;

         RasterImage page1 = null;
         RasterImage page2 = null;

         if (up)
            pageNumber2 = pageNumber1 - 1;
         else
            pageNumber2 = pageNumber1 + 1;


         // Modify rtf and emf page dictionary according to page moving
         if (_isRtfLoaded)
         {
            if (_rtfDictionary.ContainsKey(pageNumber1) || _rtfDictionary.ContainsKey(pageNumber2))
            {
               int tempPageIndex1, tempPageIndex2;
               if (_rtfDictionary.ContainsKey(pageNumber1) && !_rtfDictionary.ContainsKey(pageNumber2))
               {
                  tempPageIndex1 = _rtfDictionary[pageNumber1];
                  _rtfDictionary.Remove(pageNumber1);
                  _rtfDictionary.Add(pageNumber2, tempPageIndex1);
               }
               else if (_rtfDictionary.ContainsKey(pageNumber2) && !_rtfDictionary.ContainsKey(pageNumber1))
               {
                  tempPageIndex2 = _rtfDictionary[pageNumber2];
                  _rtfDictionary.Remove(pageNumber2);
                  _rtfDictionary.Add(pageNumber1, tempPageIndex2);
               }
               else
               {
                  tempPageIndex1 = _rtfDictionary[pageNumber1];
                  tempPageIndex2 = _rtfDictionary[pageNumber2];
                  _rtfDictionary.Remove(pageNumber1);
                  _rtfDictionary.Remove(pageNumber2);
                  _rtfDictionary.Add(pageNumber2, tempPageIndex1);
                  _rtfDictionary.Add(pageNumber1, tempPageIndex2);
               }
            }
         }
         else if (_isEmfLoaded)
         {
            if (_emfFileNames.ContainsKey(pageNumber1) || _emfFileNames.ContainsKey(pageNumber2))
            {
               string tempEmf1, tempEmf2;
               if (_emfFileNames.ContainsKey(pageNumber1) && !_emfFileNames.ContainsKey(pageNumber2))
               {
                  tempEmf1 = _emfFileNames[pageNumber1];
                  _emfFileNames.Remove(pageNumber1);
                  _emfFileNames.Add(pageNumber2, tempEmf1);
               }
               else if (_emfFileNames.ContainsKey(pageNumber2) && !_emfFileNames.ContainsKey(pageNumber1))
               {
                  tempEmf2 = _emfFileNames[pageNumber2];
                  _emfFileNames.Remove(pageNumber2);
                  _emfFileNames.Add(pageNumber1, tempEmf2);
               }
               else
               {
                  tempEmf1 = _emfFileNames[pageNumber1];
                  tempEmf2 = _emfFileNames[pageNumber2];
                  _emfFileNames.Remove(pageNumber1);
                  _emfFileNames.Remove(pageNumber2);
                  _emfFileNames.Add(pageNumber2, tempEmf1);
                  _emfFileNames.Add(pageNumber1, tempEmf2);
               }
            }
         }


         _viewerControl.RasterImageViewer.BeginUpdate();

         ImageViewer imageList = _pagesControl.RasterImageList;

         imageList.BeginUpdate();

         using (WaitCursor wait = new WaitCursor())
         {
            // First move the pages in the image itself
            image.Page = pageNumber1;
            page1 = image.Clone();

            image.Page = pageNumber2;
            page2 = image.Clone();

            image.RemovePageAt(pageNumber1);
            image.InsertPage(pageNumber1 - 1, page2);

            image.RemovePageAt(pageNumber2);
            image.InsertPage(pageNumber2 - 1, page1);

            // Now, exchange the items in the image list
            page1 = imageList.Items[pageNumber1 - 1].Image.Clone();

            imageList.Items[pageNumber1 - 1].Image = imageList.Items[pageNumber2 - 1].Image.Clone();
            imageList.Items[pageNumber2 - 1].Image = page1.Clone();

            // Finally, swap the  containers
            AnnContainer container1 = _viewerControl.Automation.Containers[pageNumber1 - 1];
            _viewerControl.Automation.Containers[pageNumber1 - 1] = _viewerControl.Automation.Containers[pageNumber2 - 1];
            _viewerControl.Automation.Containers[pageNumber2 - 1] = container1;

         }

         imageList.EndUpdate();

         _viewerControl.RasterImageViewer.EndUpdate();

         GotoPage(pageNumber2);

         //Free the temp images
         page1.Dispose();
         page1 = null;

         page2.Dispose();
         page2 = null;
      }


      private void UpdateUIState()
      {
         try
         {
            AnnAutomation automation = _viewerControl.Automation;
            if (automation != null)
            {
               _copyToolStripButton.Enabled = automation.CanCopy;
               _pasteToolStripButton.Enabled = automation.CanPaste;
               _deleteToolStripButton.Enabled = automation.CanDeleteObjects;
               _undoToolStripButton.Enabled = automation.CanUndo;
               _redoToolStripButton.Enabled = automation.CanRedo;
            }
            else
            {
               _copyToolStripButton.Enabled = false;
               _pasteToolStripButton.Enabled = false;
               _deleteToolStripButton.Enabled = false;
               _undoToolStripButton.Enabled = false;
               _redoToolStripButton.Enabled = false;
            }

            _pagesControl.RasterImageList.Refresh();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }


      private void SaveDocument(string fileName, PdfDocumentOptions pdfOptions, double pageWidth, double pageHeight)
      {
         List<string> emfFileNames = new List<string>();

         int currentPageNumber = _pagesControl.CurrentPageNumber;

         try
         {
            AnnAutomation automation = _viewerControl.Automation;

            //start from first container
            _viewerControl.SetCurrentPageNumber(1);

            // First, save all the objects as EMF to temporary files
            AnnCodecs annCodecsObj = new AnnCodecs();

            using (WaitCursor wait = new WaitCursor())
            {
               // Start a new PDF document
               _documentWriterInstance.BeginDocument(fileName, DocumentFormat.Pdf);
               int i = 0;
               foreach (AnnContainer container in automation.Containers)
               {
                  // If we loaded rtf documents, we should add annotation container with Svg file to page
                  if (_isRtfLoaded)
                  {
                     if (_rtfDictionary.ContainsKey(i + 1))
                     {
                        // Get its handle
                        using (RasterCodecs codecs = new RasterCodecs())
                        {
                           SvgDocument svgDocument = null;
                           DocumentWriterSvgPage page = new DocumentWriterSvgPage();
                           codecs.Options.RasterizeDocument.Load.TopMargin = _rasterizeDocOptions.TopMargin;
                           codecs.Options.RasterizeDocument.Load.BottomMargin = _rasterizeDocOptions.BottomMargin;
                           codecs.Options.RasterizeDocument.Load.LeftMargin = _rasterizeDocOptions.LeftMargin;
                           codecs.Options.RasterizeDocument.Load.RightMargin = _rasterizeDocOptions.RightMargin;
                           codecs.Options.RasterizeDocument.Load.PageWidth = _rasterizeDocOptions.PageWidth;
                           codecs.Options.RasterizeDocument.Load.PageHeight = _rasterizeDocOptions.PageHeight;
                           // Use default resolution to get svg from Rtf document
                           codecs.Options.RasterizeDocument.Load.XResolution = _rasterizeDocOptions.XResolution;
                           codecs.Options.RasterizeDocument.Load.YResolution = _rasterizeDocOptions.YResolution;

                           svgDocument = codecs.LoadSvg(_rtfFileName, _rtfDictionary[i + 1] + 1, null) as SvgDocument;

                           if (!svgDocument.IsFlat)
                              svgDocument.Flat(null);

                           var bounds = svgDocument.Bounds;
                           if (!bounds.IsValid)
                              svgDocument.CalculateBounds(false);

                           page.Height = svgDocument.Bounds.Bounds.Height;
                           page.Width = svgDocument.Bounds.Bounds.Width;
                           page.SvgDocument = svgDocument;

                           // Add it as a PDF page
                           _documentWriterInstance.AddPage(page);
                        }
                     }
                     else
                     {
                        DocumentWriterEmptyPage Page = new DocumentWriterEmptyPage();

                        Page.Width = 850;
                        Page.Height = 1100;

                        pageWidth = Page.Width;
                        pageHeight = Page.Height;

                        // Add it as a PDF page
                        _documentWriterInstance.AddPage(Page);
                     }
                  }
                  else if (_isEmfLoaded)
                  {
                     if (_emfFileNames.ContainsKey(i + 1))
                     {
                        DocumentWriterEmfPage page = new DocumentWriterEmfPage();
                        // Get its handle
                        using (Metafile mf = new Metafile(_emfFileNames[i + 1]))
                        {
                           pageWidth = mf.Size.Width;
                           pageHeight = mf.Size.Height;

                           // Get its handle
                           page.EmfHandle = mf.GetHenhmetafile();

                           // Add it as a PDF page
                           _documentWriterInstance.AddPage(page);
                        }
                     }
                     else
                     {
                        DocumentWriterEmptyPage Page = new DocumentWriterEmptyPage();

                        Page.Width = 850;
                        Page.Height = 1100;

                        pageWidth = Page.Width;
                        pageHeight = Page.Height;

                        // Add it as a PDF page
                        _documentWriterInstance.AddPage(Page);
                     }
                  }
                  else
                  {
                     //Create Empty Raster page
                     DocumentWriterRasterPage page = new DocumentWriterRasterPage();

                     _viewerControl.RasterImageViewer.Image.Page = automation.Containers.IndexOf(container) + 1;

                     //Assign the viewer's image to the document writer page
                     page.Image = _viewerControl.RasterImageViewer.Image.Clone();

                     if (page.Image.XResolution > 100)
                     {
                        pageWidth = page.Image.Width / (page.Image.XResolution / 100);
                        pageHeight = page.Image.Height / (page.Image.YResolution / 100);
                     }

                     //Since standard Annotation's stamp objects are not supported in PDF Annotations
                     //we will burn the stamp object to the original image, before saving the annotations

                     //Get the graphic object from our raster image
                     Leadtools.Drawing.RasterImageGdiPlusGraphicsContainer GdiPlusGraphicsContainer = new RasterImageGdiPlusGraphicsContainer(page.Image);
                     Graphics PageG = GdiPlusGraphicsContainer.Graphics;

                     //Get the image Bounds
                     LeadRect ImageLeadRect = _viewerControl.RasterImageViewer.ImageBounds;

                     //Set the destination rectangle that will be used to burn the stamp object
                     var destRect = LeadRectD.Create(ImageLeadRect.X, ImageLeadRect.Y, ImageLeadRect.Width * 720.0 / 96.0, ImageLeadRect.Height * 720.0 / 96.0);

                     //Create a Temp Annotation container to hold the stamp object
                     AnnContainer stampContainer = container.Clone();

                     //Remove all objects from the current , and leave the stamp object only 
                     stampContainer.Children.Clear();
                     AnnObject stampObject = null;

                     foreach (var annObject in container.Children)
                     {
                        if (annObject.Id == AnnObject.StampObjectId)
                        {
                           stampObject = annObject.Clone();
                           break;
                        }
                     }

                     if (stampObject != null)
                        stampContainer.Children.Add(stampObject);

                     AnnWinFormsRenderingEngine engine = new AnnWinFormsRenderingEngine();
                     engine.Attach(stampContainer, PageG);
                     engine.BurnToRectWithDpi(destRect, 96, 96, 96, 96);
                     engine.Detach();

                     stampContainer.Children.Clear();
                     stampContainer = null;

                     // Add it as a PDF page
                     _documentWriterInstance.AddPage(page);
                  }

                  i++;
               }

               _documentWriterInstance.EndDocument();
            }

            //Convert our Annotations to PDF annotations, and then save them to our PDF file
            SaveDocument2(fileName, pdfOptions);

            //restore the page number
            _viewerControl.SetCurrentPageNumber(currentPageNumber);
         }

         catch (Exception ex)
         {
            _documentWriterInstance.EndDocument();
            Messager.ShowError(this, ex);
         }
         finally
         {
            // Clean up by deleteing all the temporay files
            foreach (string tempFileName in emfFileNames)
            {
               if (File.Exists(tempFileName))
               {
                  try
                  {
                     File.Delete(tempFileName);
                  }
                  catch
                  {
                  }
               }
            }

         }
      }

      public void SaveDocument2(string fileName, PdfDocumentOptions pdfOptions)
      {
         AnnAutomation automation = _viewerControl.Automation;
         List<PDFAnnotation> fileAnnotations = new List<PDFAnnotation>();

         PDFDocument pdfDocument = new PDFDocument(fileName, !string.IsNullOrEmpty(pdfOptions.OwnerPassword) ? pdfOptions.OwnerPassword : !string.IsNullOrEmpty(pdfOptions.UserPassword) ? pdfOptions.UserPassword : null);
         int count = 1;

         // Loop through the containers
         foreach (AnnContainer container in automation.Containers)
         {
            // Get a list of all the annotations in this document
            List<PDFAnnotation> pageAnnotations = new List<PDFAnnotation>();
            AnnPDFConvertor.ConvertToPDF(container, pageAnnotations, pdfDocument.Pages[automation.Containers.IndexOf(container)].Height);
            //Change the page number of each PDFAnnotation to match the reference page
            foreach (PDFAnnotation PDFAnnObj in pageAnnotations)
               PDFAnnObj.PageNumber = count;

            fileAnnotations.AddRange(pageAnnotations);

            count++;
         }

         // Make the file writable if exists
         if (File.Exists(fileName))
            MakeWriteable(fileName);

         // Load the original file in a PDFFile object
         PDFFile file = new PDFFile(fileName, !string.IsNullOrEmpty(pdfOptions.OwnerPassword) ? pdfOptions.OwnerPassword : !string.IsNullOrEmpty(pdfOptions.UserPassword) ? pdfOptions.UserPassword : null);

         if (fileAnnotations.Count > 0)
            file.WriteAnnotations(fileAnnotations, fileName);

         // PDF Compatibility Level
         switch (pdfOptions.DocumentType)
         {
            case PdfDocumentType.Pdf:
               file.CompatibilityLevel = PDFCompatibilityLevel.Default;
               break;
            case PdfDocumentType.PdfA:
               file.CompatibilityLevel = PDFCompatibilityLevel.PDFA;
               break;
            case PdfDocumentType.Pdf12:
               file.CompatibilityLevel = PDFCompatibilityLevel.PDF12;
               break;
            case PdfDocumentType.Pdf13:
               file.CompatibilityLevel = PDFCompatibilityLevel.PDF13;
               break;
            case PdfDocumentType.Pdf15:
               file.CompatibilityLevel = PDFCompatibilityLevel.PDF15;
               break;
         }

         // PDF Document Properties
         file.DocumentProperties = new PDFDocumentProperties();
         file.DocumentProperties.Author = pdfOptions.Author;
         file.DocumentProperties.Creator = pdfOptions.Creator;
         file.DocumentProperties.Keywords = pdfOptions.Keywords;
         file.DocumentProperties.Producer = pdfOptions.Producer;
         file.DocumentProperties.Subject = pdfOptions.Subject;
         file.DocumentProperties.Title = pdfOptions.Title;

         // PDF Initial View Options
         file.InitialViewOptions = new PDFInitialViewOptions();
         file.InitialViewOptions.CenterWindow = pdfOptions.CenterWindow;
         file.InitialViewOptions.DisplayDocTitle = pdfOptions.DisplayDocTitle;
         file.InitialViewOptions.FitWindow = pdfOptions.FitWindow;
         file.InitialViewOptions.HideMenubar = pdfOptions.HideMenubar;
         file.InitialViewOptions.HideToolbar = pdfOptions.HideToolbar;
         file.InitialViewOptions.HideWindowUI = pdfOptions.HideWindowUI;
         file.InitialViewOptions.PageFitType = (PDFPageFitType)pdfOptions.PageFitType;
         file.InitialViewOptions.PageLayoutType = (PDFPageLayoutType)pdfOptions.PageLayoutType;
         file.InitialViewOptions.PageModeType = (PDFPageModeType)pdfOptions.PageModeType;
         file.InitialViewOptions.PageNumber = pdfOptions.InitialPageNumber;
         file.InitialViewOptions.Position = new PDFPoint(pdfOptions.XCoordinate, pdfOptions.YCoordinate);
         file.InitialViewOptions.ZoomPercent = pdfOptions.ZoomPercent;

         // PDF Security Options
         if (pdfOptions.Protected)
         {
            file.SecurityOptions = new PDFSecurityOptions();
            file.SecurityOptions.AnnotationsEnabled = pdfOptions.AnnotationsEnabled;
            file.SecurityOptions.AssemblyEnabled = pdfOptions.AssemblyEnabled;
            file.SecurityOptions.CopyEnabled = pdfOptions.CopyEnabled;
            file.SecurityOptions.CopyForAccessibilityEnabled = pdfOptions.CopyEnabled;
            file.SecurityOptions.EditEnabled = pdfOptions.EditEnabled;
            file.SecurityOptions.EncryptionMode = (PDFEncryptionMode)pdfOptions.EncryptionMode;
            file.SecurityOptions.HighQualityPrintEnabled = pdfOptions.HighQualityPrintEnabled;
            file.SecurityOptions.PrintEnabled = pdfOptions.PrintEnabled;
            file.SecurityOptions.OwnerPassword = pdfOptions.OwnerPassword;
            file.SecurityOptions.UserPassword = pdfOptions.UserPassword;
         }

         file.SetDocumentProperties(fileName);
         file.SetInitialView(fileName);

         file.Convert(1, -1, fileName);

         // If the user wanted Fast Web (linearized), then we need to re-optimize the file
         if (pdfOptions.Linearized)
            file.Linearize(fileName);
      }

      private static void MakeWriteable(string fileName)
      {
         // Remove read-only if there
         FileAttributes attr = File.GetAttributes(fileName);
         attr &= ~FileAttributes.ReadOnly;
         File.SetAttributes(fileName, attr);
      }

      private void _viewFitWidthToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(true);
      }

      private void _viewFitPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(false);
      }

      private void _viewZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(true);
      }

      private void _viewZoomInToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(false);
      }

      private void _fileOpenRtfToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = _viewerControl.Automation;
         
         RasterDialogRasterizeDocumentFileOptions rasterizeDocOptions;
         using (RasterCodecs codecs = new RasterCodecs())
         {
            using (RasterOpenDialog ofd = new RasterOpenDialog(codecs))
            {
               ofd.DereferenceLinks = true;
               ofd.CheckFileExists = true;
               ofd.CheckPathExists = true;
               ofd.EnableSizing = true;

               ofd.Filter = new RasterOpenDialogLoadFormat[1] { new RasterOpenDialogLoadFormat("Rich Text Format", "*.rtf") };
               ofd.LoadFileImage = false;
               ofd.ShowLoadOptions = true;
               ofd.ShowRasterizeDocumentOptions = true;
               ofd.ShowPreview = true;
               ofd.ShowRasterOptions = true;
               ofd.ShowTotalPages = true;
               ofd.ShowFileInformation = true;
               ofd.UseFileStamptoPreview = true;
               ofd.PreviewWindowVisible = true;
               ofd.Multiselect = false;
               ofd.Title = "LEADTOOLS Open Dialog";

               if (ofd.ShowDialog(this) == DialogResult.OK)
               {
                  double convertFactor;

                  _isRtfLoaded = true;
                  _isEmfLoaded = false;
                  rasterizeDocOptions = ofd.OpenedFileData[0].Options.RasterizeDocumentOptions;

                  _rtfFileName = ofd.FileName;
                  if (rasterizeDocOptions.XResolution == 0)
                     rasterizeDocOptions.XResolution = 96;
                  if (rasterizeDocOptions.YResolution == 0)
                     rasterizeDocOptions.YResolution = 96;

                  if (rasterizeDocOptions.Unit == CodecsRasterizeDocumentUnit.Millimeter)
                     convertFactor = 1.0 / 25.4; // convert from millimeters to inches
                  else if (rasterizeDocOptions.Unit == CodecsRasterizeDocumentUnit.Pixel)
                     convertFactor = 1.0 / rasterizeDocOptions.XResolution; // convert from pixels to inches
                  else
                     convertFactor = 1.0; // inches

                  rasterizeDocOptions.Unit = CodecsRasterizeDocumentUnit.Inch;
                  rasterizeDocOptions.TopMargin *= convertFactor;
                  rasterizeDocOptions.BottomMargin *= convertFactor;
                  rasterizeDocOptions.LeftMargin *= convertFactor;
                  rasterizeDocOptions.RightMargin *= convertFactor;
                  rasterizeDocOptions.PageHeight *= convertFactor;
                  rasterizeDocOptions.PageWidth *= convertFactor;
                  //Force loading all pages
                  codecs.Options.Load.AllPages = true;

                  try
                  {
                     _rasterizeDocOptions = rasterizeDocOptions;
                     using (RasterImage rasterImage = codecs.Load(_rtfFileName))
                     {
                        NewDocument((float)_rasterizeDocOptions.PageWidth, (float)_rasterizeDocOptions.PageHeight, _rasterizeDocOptions.XResolution, _rasterizeDocOptions.YResolution);
                        using (WaitCursor wait = new WaitCursor())
                        {
                           // Add rtf pages as stamps
                           int i;

                           for (i = 0; i < rasterImage.PageCount - 1; i++)
                           {
                              AddNewPage();
                           }
                           _rtfDictionary = new Dictionary<int, int>();



                           for (i = 0; i < rasterImage.PageCount; i++)
                           {
                              AnnStampObject stamp;
                              rasterImage.Page = i + 1;
                              stamp = new AnnStampObject();
                              stamp.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), LeadLengthD.Create(4));
                              stamp.IsVisible = true;
                              stamp.Rect = new LeadRectD(automation.Container.Size);
                              stamp.Font = new AnnFont("Arial", 48);
                              stamp.Font.FontStyle = AnnFontStyle.Normal;
                              using (MemoryStream Mem = new MemoryStream())
                              {
                                 codecs.Save(rasterImage, Mem, RasterImageFormat.Jpeg, 24);
                                 Mem.Seek(0, SeekOrigin.Begin);
                                 stamp.Picture = new AnnPicture(Mem.ToArray());
                              }
                              stamp.Lock(_rtfFileName);
                              stamp.Tag = _rtfEmfStampTag;
                              automation.Containers[i].Children.Clear();
                              automation.Containers[i].Children.Add(stamp);
                              _rtfDictionary.Add(i + 1, i);
                           }
                        }
                     }
                  }
                  catch(RasterException rex)
                  {
                     MessageBox.Show(rex.Message.ToString() + "\nCould not load: " + _rtfFileName, "File Open Error");
                  }

                  GotoPage(1);

               }
            }
         }
      }


      private AnnContainer PrepareAnnotationsContainer(AnnContainer container)
      {
         AnnContainer tempContainer = (AnnContainer)container.Clone();
         int j = 0;

         // Remove Rtf stamps since each Rtf page is atteched to document writer as emf
         while (j < tempContainer.Children.Count)
         {
            AnnObject obj = tempContainer.Children[j];
            if (obj is AnnStampObject)
            {
               AnnStampObject stamp = obj as AnnStampObject;
               if ((int)stamp.Tag == _rtfEmfStampTag)
               {
                  stamp.Picture.Source = null;
                  tempContainer.Children.Remove(obj);
                  j--;
               }
            }
            j++;
         }

         return tempContainer;
      }


      private void _fileOpenEmfToolStripMenuItem_Click(object sender, EventArgs e)
      {
         float pageWidth, pageHeight;
         int dpiX, dpiY;

         using (RasterCodecs codecs = new RasterCodecs())
         {
            using (RasterOpenDialog ofd = new RasterOpenDialog(codecs))
            {
               ofd.DereferenceLinks = true;
               ofd.CheckFileExists = true;
               ofd.CheckPathExists = true;
               ofd.EnableSizing = true;

               ofd.Filter = new RasterOpenDialogLoadFormat[1] { new RasterOpenDialogLoadFormat("Enhanced Metafile", "*.emf") };
               ofd.LoadFileImage = false;
               ofd.ShowLoadOptions = true;
               ofd.ShowPreview = true;
               ofd.ShowTotalPages = true;
               ofd.ShowFileInformation = true;
               ofd.UseFileStamptoPreview = true;
               ofd.PreviewWindowVisible = true;
               ofd.Multiselect = true;
               ofd.Title = "LEADTOOLS Open Dialog";

               if (ofd.ShowDialog(this) == DialogResult.OK)
               {
                  _viewerControl.Automation.Containers.Clear();

                  _isRtfLoaded = false;
                  _isEmfLoaded = true;
                  _emfFileNames = new Dictionary<int, string>();

                  int i = 0;
                  foreach (RasterDialogFileData item in ofd.OpenedFileData)
                  {
                     dpiX = item.FileInfo.XResolution > 0 ? item.FileInfo.XResolution : 96;
                     dpiY = item.FileInfo.YResolution > 0 ? item.FileInfo.YResolution : 96;
                     pageWidth = (float)item.FileInfo.Width / dpiX;    // Page width in inches
                     pageHeight = (float)item.FileInfo.Height / dpiY;  // Page height in inches

                     if (i == 0)
                     {
                        NewDocument(pageWidth, pageHeight, dpiX, dpiY);
                     }
                     else
                     {
                        AddNewPage(pageWidth, pageHeight, dpiX, dpiY);
                     }

                     using (WaitCursor wait = new WaitCursor())
                     {
                        // Add emf pages as stamps

                        AnnAutomation automation = _viewerControl.AutomationManager.Automations[_viewerControl.AutomationManager.Automations.Count - 1];
                        AnnStampObject stamp;
                        stamp = new AnnStampObject();
                        stamp.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), LeadLengthD.Create(4));
                        stamp.IsVisible = true;
                        stamp.Rect = new LeadRectD(automation.Container.Size);
                        stamp.Font = new AnnFont("Arial", 48);
                        stamp.Font.FontStyle = AnnFontStyle.Normal;
                        ImageConverter converter = new ImageConverter();
                        using (MemoryStream ms = new MemoryStream())
                        {
                           RasterImage StampPic = codecs.Load(item.Name);
                           codecs.Save(StampPic, ms, RasterImageFormat.Png, 24);
                           stamp.Picture = new AnnPicture(ms.ToArray());
                           StampPic.Dispose();
                           StampPic = null;
                        }
                        stamp.Lock(item.Name);
                        stamp.Tag = _rtfEmfStampTag;
                        _emfFileNames.Add(i + 1, item.Name);
                        automation.Container.Children.Add(stamp);
                     }
                     i++;
                  }

                  GotoPage(1);

                  _pagesControl.RasterImageList.Invalidate();
               }
            }
         }
      }
   }
}
