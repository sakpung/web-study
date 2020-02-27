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

namespace OcrMultiEngineDemo.PagesControl
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

         _ImageList.Dock = System.Windows.Forms.DockStyle.Fill;
         _ImageList.ItemBorderThickness = 1;
         _ImageList.ItemSize = new Leadtools.LeadSize(160, 180);
         _ImageList.ViewPadding = new System.Windows.Forms.Padding(6);
         _ImageList.ItemPadding = new System.Windows.Forms.Padding(5, 0, 5, 20);

         UpdateUIState();
      }

      private void _ImageList_Paint(object sender, ImageViewerRenderEventArgs e)
      {
         // Draw the letter R on each recognized page 

         LeadSize itemImageSize = _ImageList.ItemSize;
         Graphics g = e.PaintEventArgs.Graphics;

         using (Brush textBrush = new SolidBrush(Color.FromArgb(128, Color.Black)))
         {
            foreach (ImageViewerItem item in _ImageList.Items)
            {
               bool isPageRecognized = false;

               if (item.Tag != null)
                  isPageRecognized = (bool)item.Tag;

               if (isPageRecognized)
               {
                  LeadRectD itemRect = _ImageList.GetItemBounds(item, ImageViewerItemPart.Image);
                  var transform = _ImageList.GetItemImageTransform(item);
                  itemRect.X = transform.OffsetX;
                  itemRect.Y = transform.OffsetY;

                  SizeF textSize = g.MeasureString("R", _ImageList.Font);
                  RectangleF textRect = new RectangleF((float)itemRect.X + 2, (float)itemRect.Y + 2, textSize.Width, textSize.Height);

                  g.FillRectangle(textBrush, textRect);

                  g.DrawString("R", _ImageList.Font, Brushes.White, textRect.Location);
               }
            }
         }
      }

      /// <summary>
      /// The image list control is needed by the main form
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer ImageList
      {
         get
         {
            return _ImageList;
         }
      }

      /// <summary>
      /// Called from the main form when the user changes the page index
      /// from outside this control (main menu or the viewer control)
      /// </summary>
      private ImageViewerItem[] _oldSelectedItem = null;
      public void SetCurrentPageIndex(int pageIndex)
      {
         if (pageIndex != CurrentPageIndex)
         {
            // De-select all items but 'pageIndex'

            _ImageList.BeginUpdate();

            for (int i = 0; i < _ImageList.Items.Count; i++)
            {
               ImageViewerItem item = _ImageList.Items[i];

               if (i == pageIndex)
                  item.IsSelected = true;
               else
                  item.IsSelected = false;
            }

            _ImageList.EnsureItemVisible(_ImageList.Items[pageIndex]);
            _ImageList.EndUpdate();
            _oldSelectedItem = _ImageList.Items.GetSelected();
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
         int pageCount = _ImageList.Items.Count;
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
            for (int i = 0; i < _ImageList.Items.Count; i++)
            {
               if (_ImageList.Items[i].IsSelected)
                  return i;
            }

            // No items
            return -1;
         }
      }

      private void _ImageList_SelectedItemChanged(object sender, EventArgs e)
      {
         if (MainForm.PerspectiveDeskewActive)
         {
            // Prevent selecting other items from image list while Inverse perspective is active.
            _ImageList.SelectedItemsChanged -= new System.EventHandler(this._ImageList_SelectedItemChanged);
            _ImageList.Items.Select(null);
            _ImageList.Items.Select(_oldSelectedItem);
            _ImageList.SelectedItemsChanged += new System.EventHandler(this._ImageList_SelectedItemChanged);
            return;
         }

         int pageIndex = CurrentPageIndex;
         _oldSelectedItem = _ImageList.Items.GetSelected();
         // Check for -1, means nothing is selected. Happens when we close the document
         if (pageIndex != -1)
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

         if (Action != null)
            Action(this, new ActionEventArgs(action, data));
      }
   }
}
