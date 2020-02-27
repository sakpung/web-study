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

using Leadtools;
using Leadtools.Controls;

namespace OcrDemo.PagesControl
{
   /// <summary>
   /// This control contains an instance of RasterImageList plus
   /// a tool strip control for common operations
   /// </summary>
   public partial class PagesControl : UserControl
   {
      public PagesControl()
      {
         InitializeComponent();

         _rasterImageList.Dock = System.Windows.Forms.DockStyle.Fill;
         _rasterImageList.ItemBorderThickness = 1;
         _rasterImageList.ItemSize = new Leadtools.LeadSize(160, 180);
         _rasterImageList.ViewPadding = new System.Windows.Forms.Padding(6);
         _rasterImageList.ItemPadding = new System.Windows.Forms.Padding(5, 0, 5, 20);

         UpdateUIState();
      }

      private void _rasterImageList_Paint(object sender, ImageViewerRenderEventArgs e)
      {
         // Draw the letter R on each recognized page 

         LeadSize itemImageSize = _rasterImageList.ItemSize;
         Graphics g = e.PaintEventArgs.Graphics;

         using (Brush textBrush = new SolidBrush(Color.FromArgb(128, Color.Black)))
         {
            foreach (ImageViewerItem item in _rasterImageList.Items)
            {
               bool isPageRecognized = false;

               if (item.Tag != null)
               {
                  ImageListItemData itemData = item.Tag as ImageListItemData;
                  isPageRecognized = itemData.IsRecognized;
               }

               if (isPageRecognized)
               {
                  LeadRectD itemRect = _rasterImageList.GetItemBounds(item, ImageViewerItemPart.Image);
                  var transform = _rasterImageList.GetItemImageTransform(item);
                  itemRect.X = transform.OffsetX;
                  itemRect.Y = transform.OffsetY;

                  SizeF textSize = g.MeasureString("R", _rasterImageList.Font);
                  RectangleF textRect = new RectangleF((float)itemRect.X + 2, (float)itemRect.Y + 2, textSize.Width, textSize.Height);

                  g.FillRectangle(textBrush, textRect);

                  g.DrawString("R", _rasterImageList.Font, Brushes.White, textRect.Location);
               }
            }
         }
      }

      /// <summary>
      /// The image list control is needed by the main form
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer RasterImageList
      {
         get
         {
            return _rasterImageList;
         }
      }

      /// <summary>
      /// Called from the main form when the user changes the page index
      /// from outside this control (main menu or the viewer control)
      /// </summary>
      private ImageViewerItem[] _oldSelectedItem = null;
      public void SetCurrentPageIndex(int pageIndex)
      {
         if(pageIndex != CurrentPageIndex)
         {
            // De-select all items but 'pageIndex'

            _rasterImageList.BeginUpdate();

            for(int i = 0; i < _rasterImageList.Items.Count; i++)
            {
               ImageViewerItem item = _rasterImageList.Items[i];

               if(i == pageIndex)
                  item.IsSelected = true;
               else
                  item.IsSelected = false;
            }

            _rasterImageList.EnsureItemVisible(_rasterImageList.Items[pageIndex]);
            _rasterImageList.EndUpdate();
            _oldSelectedItem = _rasterImageList.Items.GetSelected();
         }

         UpdateUIState();
      }

      /// <summary>
      /// Called by the main form to update the UI state
      /// </summary>
      public void UpdateUIState()
      {
         if (MainForm.PerspectiveDeskewActive)
         {
            _toolStrip.Enabled = false;
            return;
         }

         _toolStrip.Enabled = true;
         // Update the UI based on the state of the control
         int pageCount = _rasterImageList.Items.Count;
         _deleteCurrentPageToolStripButton.Enabled = pageCount > 0;

         int pageIndex = CurrentPageIndex;
         _movePageUpToolStripButton.Enabled = pageCount > 0 && pageIndex > 0;
         _movePageDownToolStripButton.Enabled = pageCount > 0 && pageIndex < (pageCount - 1);
      }

      /// <summary>
      /// Any action that happens in this control that must be handled by the owner
      /// For example, any of the tool strip buttons clicked
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;

      private int CurrentPageIndex
      {
         get
         {
            // Find the first selected item in the image list, it is
            // a single selection control
            for(int i = 0; i < _rasterImageList.Items.Count; i++)
            {
               if (_rasterImageList.Items[i].IsSelected)
                  return i;
            }

            // No items
            return -1;
         }
      }

      private void _rasterImageList_SelectedIndexChanged(object sender, EventArgs e)
      {
         int pageIndex = CurrentPageIndex;
         DoAction("PageIndexChanged", pageIndex);
         UpdateUIState();
      }

      private void _insertPageToolStripButton_Click(object sender, EventArgs e)
      {
         DoAction("InsertPage", null);
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

         if(Action != null)
            Action(this, new ActionEventArgs(action, data));
      }

      private void _rasterImageList_SelectedItemChanged(object sender, EventArgs e)
      {
         if (MainForm.PerspectiveDeskewActive)
         {
            // Prevent selecting other items from image list while Inverse perspective is active.
            _rasterImageList.SelectedItemsChanged -= new System.EventHandler(this._rasterImageList_SelectedItemChanged);
            _rasterImageList.Items.Select(null);
            _rasterImageList.Items.Select(_oldSelectedItem);
            _rasterImageList.SelectedItemsChanged += new System.EventHandler(this._rasterImageList_SelectedItemChanged);
            return;
         }

         int pageIndex = CurrentPageIndex;
         _oldSelectedItem = _rasterImageList.Items.GetSelected();
         // Check for -1, means nothing is selected. Happens when we close the document
         if (pageIndex != -1)
            DoAction("PageIndexChanged", pageIndex);
         UpdateUIState();
      }
   }
}
