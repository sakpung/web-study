// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;
using Leadtools.Document.Writer;
using Leadtools.Annotations.Rendering;
using Leadtools.Drawing;

namespace DocumentWritersDemo
{
   /// <summary>
   /// This control contains an instance of RasterImageList plus
   /// a tool strip control for common operations
   /// </summary>
   public partial class PagesControl : UserControl
   {
      // The automation manager object
      private AnnAutomationManager _automationManager;
      private AnnAutomation _automation;
      private RasterImage _viewerImage = null;
      private InsertBookmarkForm _insertBookmaksForm = null;
      private Point _bookmarkPosition = Point.Empty;


      public PagesControl()
      {
         InitializeComponent();

         UpdateUIState();
      }

      /// <summary>
      /// Called by the main form to tie the automation manager to the object in the viewer control
      /// </summary>
      public void SetAutomation(AnnAutomationManager automationManager, AnnAutomation automation)
      {
         _automationManager = automationManager;
         _automation = automation;
      }

      /// <summary>
      /// The image list control is needed by the main form
      /// </summary>
      public ImageViewer RasterImageList
      {
         get
         {
            return _rasterImageList;
         }
      }

      /// <summary>
      /// The image list control is needed by the main form
      /// </summary>
      public TreeView PdfBookmarksList
      {
         get
         {
            return _treeBookmarks;
         }
      }

      public RasterImage ViewerImage
      {
         get
         {
            return _viewerImage;
         }
         set
         {
            _viewerImage = value;
         }
      }

      /// <summary>
      /// Called from the main form when the user changes the page number
      /// from outside this control (main menu or the viewer control)
      /// </summary>
      public void SetCurrentPageNumber(int pageNumber)
      {
         if (pageNumber != CurrentPageNumber && pageNumber <= _rasterImageList.Items.Count)
         {
            // De-select all items but 'pageNumber'

            _rasterImageList.BeginUpdate();

            for (int i = 0; i < _rasterImageList.Items.Count; i++)
            {
               ImageViewerItem item = _rasterImageList.Items[i];

               if (i == (pageNumber - 1))
                  item.IsSelected = true;
               else
                  item.IsSelected = false;
            }

            _rasterImageList.EnsureItemVisibleByIndex(pageNumber - 1);
            _rasterImageList.EndUpdate();
         }

         UpdateUIState();
      }

      /// <summary>
      /// Called by the main form to delete the current selected page
      /// </summary>
      public void DeleteCurrentPage()
      {
         int pageNumber = CurrentPageNumber;
         _rasterImageList.Items.RemoveAt(pageNumber - 1);
      }

      /// <summary>
      /// Called by the main form to update the UI state
      /// </summary>
      public void UpdateUIState()
      {

         // Update the UI based on the state of the control
         int pageCount = _rasterImageList.Items.Count;
         _deleteCurrentPageToolStripButton.Enabled = pageCount > 0;

         int pageNumber = CurrentPageNumber;
         _deleteCurrentPageToolStripButton.Enabled = pageCount > 1;
         _movePageUpToolStripButton.Enabled = pageCount > 0 && pageNumber > 1;
         _movePageDownToolStripButton.Enabled = pageCount > 0 && pageNumber < pageCount;

         // Update the bookmarks tool strip items
         _deleteToolStripDropDownButton.Enabled = _treeBookmarks.SelectedNode != null;
         _deleteSelectedBookmarkToolStripMenuItem.Enabled = _treeBookmarks.SelectedNode != null;
         _clearAllBookmarksToolStripMenuItem.Enabled = _treeBookmarks.Nodes.Count > 0;
         _bookmarkPropertiesToolStripButton.Enabled = _treeBookmarks.SelectedNode != null;
      }

      /// <summary>
      /// Any action that happens in this control that must be handled by the owner
      /// For example, any of the tool strip buttons clicked
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;

      public int CurrentPageNumber
      {
         get
         {
            // Find the first selected item in the image list, it is
            // a single selection control
            for (int i = 0; i < _rasterImageList.Items.Count; i++)
            {
               if (_rasterImageList.Items[i].IsSelected)
                  return i + 1;
            }

            // No items
            return -1;
         }
      }

      private void _rasterImageList_SelectedIndexChanged(object sender, EventArgs e)
      {
         int pageNumber = CurrentPageNumber;
         DoAction("PageNumberChanged", pageNumber);
         UpdateUIState();
      }

      private void _newPageToolStripButton_Click(object sender, EventArgs e)
      {
         DoAction("NewPage", null);
      }

      private void _deleteCurrentPageToolStripButton_Click(object sender, EventArgs e)
      {
         DoAction("DeletePage", null);
      }

      private void _movePageUpToolStripButton_Click(object sender, EventArgs e)
      {
         DoAction("MovePageUp", null);
      }

      private void _movePageDownToolStripButton_Click(object sender, EventArgs e)
      {
         DoAction("MovePageDown", null);
      }

      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if (Action != null)
            Action(this, new ActionEventArgs(action, data));
      }

      void _rasterImageList_PostRender(object sender, Leadtools.Controls.ImageViewerRenderEventArgs e)
      {         
         
         for (int i = 0; i < _rasterImageList.Items.Count; i++)
         {
            ImageViewerItem item = _rasterImageList.Items[i];

            LeadRectD itemLeadRect = _rasterImageList.GetItemBounds(item, ImageViewerItemPart.Item);
            Rectangle itemRect = new Rectangle((int)itemLeadRect.X, (int)itemLeadRect.Y, (int)itemLeadRect.Width, (int)itemLeadRect.Height);
            LeadSize itemImageSize = _rasterImageList.GetItemImageSize(item, false);

            LeadRect imageRect = new LeadRect(
                    itemRect.Left + (itemRect.Width - itemImageSize.Width) / 2,
                    itemRect.Top + (itemRect.Height - itemImageSize.Height) / 2,
                    itemImageSize.Width,
                    itemImageSize.Height);

            itemLeadRect = ImageViewer.GetDestinationRectangle(item.Image.ImageWidth, item.Image.ImageHeight, imageRect, ControlSizeMode.None, ControlAlignment.Near, ControlAlignment.Near).ToLeadRectD();

            var destRect = LeadRectD.Create(itemLeadRect.X, itemLeadRect.Y, itemLeadRect.Width * 720.0 / 96.0, itemLeadRect.Height * 720.0 / 96.0);
            
            destRect.X = 0.0;
            destRect.Y = 0.0;

            //Get the graphic object from the item's image to draw (burn) annotations on it.
            Leadtools.Drawing.RasterImageGdiPlusGraphicsContainer GdiPlusGraphicsContainer = new RasterImageGdiPlusGraphicsContainer(item.Image);            
            Graphics g = GdiPlusGraphicsContainer.Graphics;

            // Use anti-aliasing
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Now draw the annotation s on this rectangle
            if (_automationManager != null && _automation.Containers.Count > 0 && _automation.Containers.Count > i)
            {
               AnnContainer container = _automation.Containers[i];
               
               //Clear the old painting
               g.Clear(Color.White);
               
               //Burn the current annotations to the image list item
               if (container != null)
               {
                  AnnWinFormsRenderingEngine engine = new AnnWinFormsRenderingEngine();
                  engine.Resources = _automationManager.Resources;

                  // Save its visible state and set it to true (it is false if viewer is in single mode)
                  bool containerIsVisible = container.IsVisible;
                  container.IsVisible = true;

                  engine.Attach(container, g);
                  engine.BurnToRectWithDpi(destRect, 96, 96, 96, 96);
                  engine.Detach();

                  if (container.IsVisible != containerIsVisible)
                     container.IsVisible = containerIsVisible;
               }               
            }
         }
      }

      void _rasterImageList_SelectedItemsChanged(object sender, System.EventArgs e)
      {
         int pageNumber = CurrentPageNumber;

         if (pageNumber != -1)
         {
            DoAction("PageNumberChanged", pageNumber);
            UpdateUIState();
         }
      }


      public Point BookmarkPosition
      {
         get { return _bookmarkPosition; }
         set
         {
            _bookmarkPosition = value;

            if (_insertBookmaksForm != null && _insertBookmaksForm.Visible)
            {
               _insertBookmaksForm.PositionX.Text = _bookmarkPosition.X.ToString();
               _insertBookmaksForm.PositionY.Text = _bookmarkPosition.Y.ToString();
            }
         }
      }

      private PdfCustomBookmark GetDefaultPdfBookmark(TreeNode node)
      {
         PdfCustomBookmark pdfBookmark = new PdfCustomBookmark();
         pdfBookmark.Name = node.Text;
         pdfBookmark.LevelNumber = node.Level;
         pdfBookmark.PageNumber = CurrentPageNumber;
         pdfBookmark.XCoordinate = 0;
         pdfBookmark.YCoordinate = 0;

         return pdfBookmark;
      }

      private void ShowBookmarksDialog(TreeNode node)
      {
         RasterImage page = (RasterImage)_rasterImageList.Items.GetSelected()[0].Tag;
         _insertBookmaksForm = new InsertBookmarkForm(node, _rasterImageList.Items.Count, CurrentPageNumber - 1, page.Width, page.Height);
         _insertBookmaksForm.Action += new EventHandler<ActionEventArgs>(_insertBookmaksForm_Action);
         _insertBookmaksForm.Show(this);
      }

      void _insertBookmaksForm_Action(object sender, ActionEventArgs e)
      {
         int pageNumber = (int)e.Data;
         DoAction("PageNumberChanged", pageNumber);
      }



      private void _insertBookmarkAfterToolStripMenuItem_Click(object sender, EventArgs e)
      {

         _treeBookmarks.Focus();

         TreeNode selectedNode = _treeBookmarks.SelectedNode;
         if (selectedNode == null)
            selectedNode = _treeBookmarks.Nodes.Add("Untitled");
         else
         {
            if (selectedNode.Parent == null)
               selectedNode = _treeBookmarks.Nodes.Insert(selectedNode.Index + 1, "Untitled");
            else
               selectedNode = selectedNode.Parent.Nodes.Insert(selectedNode.Index + 1, "Untitled");
         }

         PdfCustomBookmark pdfBookmark = GetDefaultPdfBookmark(selectedNode);
         selectedNode.Tag = pdfBookmark;
         _treeBookmarks.SelectedNode = selectedNode;

         ShowBookmarksDialog(_treeBookmarks.SelectedNode);
         UpdateUIState();

      }

      private void _insertBookmarkBeforeToolStripMenuItem_Click(object sender, EventArgs e)
      {

         _treeBookmarks.Focus();

         TreeNode selectedNode = _treeBookmarks.SelectedNode;
         if (selectedNode == null)
            selectedNode = _treeBookmarks.Nodes.Add("Untitled");
         else
         {
            if (selectedNode.Parent == null)
               selectedNode = _treeBookmarks.Nodes.Insert(selectedNode.Index, "Untitled");
            else
               selectedNode = selectedNode.Parent.Nodes.Insert(selectedNode.Index, "Untitled");
         }

         PdfCustomBookmark pdfBookmark = GetDefaultPdfBookmark(selectedNode);
         selectedNode.Tag = pdfBookmark;
         _treeBookmarks.SelectedNode = selectedNode;

         ShowBookmarksDialog(_treeBookmarks.SelectedNode);
         UpdateUIState();

      }

      private void _insertChildBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
      {

         _treeBookmarks.Focus();

         TreeNode selectedNode = _treeBookmarks.SelectedNode;
         if (selectedNode == null)
            selectedNode = _treeBookmarks.Nodes.Add("Untitled");
         else
         {
            selectedNode = selectedNode.Nodes.Add("Untitled");
         }

         PdfCustomBookmark pdfBookmark = GetDefaultPdfBookmark(selectedNode);
         selectedNode.Tag = pdfBookmark;
         _treeBookmarks.SelectedNode = selectedNode;

         ShowBookmarksDialog(_treeBookmarks.SelectedNode);
         UpdateUIState();

      }

      private void _deleteSelectedBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
      {

         TreeNode selectedNode = _treeBookmarks.SelectedNode;
         if (selectedNode != null)
         {
            int index = selectedNode.Index;
            _treeBookmarks.Nodes.Remove(selectedNode);
            if (_treeBookmarks.Nodes.Count > index)
               _treeBookmarks.SelectedNode = _treeBookmarks.Nodes[index];
         }

         UpdateUIState();

      }

      private void _clearAllBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
      {

         _treeBookmarks.Nodes.Clear();
         UpdateUIState();

      }

      private void _bookmarkPropertiesToolStripButton_Click(object sender, EventArgs e)
      {

         if (_treeBookmarks.SelectedNode != null)
            ShowBookmarksDialog(_treeBookmarks.SelectedNode);

      }

      private void _treeBookmarks_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            // Show the context menu.
            _contextMenuBookmarks.Show((TreeView)sender, e.X, e.Y);
         }
      }

      private void _treeBookmarks_Click(object sender, EventArgs e)
      {

         MouseEventArgs mouseArgs = (MouseEventArgs)e;
         if (mouseArgs.Button != MouseButtons.Right)
         {
            TreeNode selectedNode = _treeBookmarks.GetNodeAt(mouseArgs.X, mouseArgs.Y);
            if (selectedNode != null && selectedNode.Tag != null)
            {
               PdfCustomBookmark pdfBookmark = (PdfCustomBookmark)selectedNode.Tag;
               if (pdfBookmark.PageNumber > _rasterImageList.Items.Count)
               {
                  MessageBox.Show("The page this bookmark points to was deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
               DoAction("CenterAtPoint", pdfBookmark);
            }
         }

      }
   }
}
