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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

using Leadtools;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using Leadtools.Controls;

namespace Leadtools.Annotations.WinForms
{
   public class AutomationSimpleObjectsListItem
   {
      private AutomationSimpleObjectsListItem() { }

      public AutomationSimpleObjectsListItem(AnnContainer annContainer, AnnObject annObject)
      {
         if (annContainer == null) throw new ArgumentNullException("annContainer");
         if (annObject == null) throw new ArgumentNullException("annObject");
         if (annObject.Id == AnnObject.SelectObjectId || annObject.Id == AnnObject.None)
            throw new ArgumentException("Cannot create this item with a selection or none annotation object", "annObject");

         _annContainer = annContainer;
         _annObject = annObject;
      }

      private AnnContainer _annContainer;
      public AnnContainer AnnContainer
      {
         get { return _annContainer; }
      }

      private AnnObject _annObject;
      public AnnObject AnnObject
      {
         get { return _annObject; }
      }
   }

   public class AutomationSimpleObjectsListControl : ListBox
   {
      public AutomationSimpleObjectsListControl()
      {
         this.DrawMode = DrawMode.OwnerDrawFixed;
         this.FormattingEnabled = true;
         this.SelectionMode = SelectionMode.MultiExtended;
         this.IntegralHeight = false;

         UpdateResources();
      }

      private AnnAutomation _automation;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AnnAutomation Automation
      {
         get { return _automation; }
         set
         {
            if (_automation != value)
            {
               if (_automation != null)
                  HookEvents(false);

               _automation = value;

               Clear();

               if (_automation != null)
                  HookEvents(true);
            }
         }
      }

      private ImageViewer _imageViewer;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer ImageViewer
      {
         get { return _imageViewer; }
         set { _imageViewer = value; }
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (_automation != null)
               this.Automation = null;

            if (_boldFont != null)
            {
               _boldFont.Dispose();
               _boldFont = null;
            }
         }

         base.Dispose(disposing);
      }

      private void HookEvents(bool hook)
      {
         if (hook)
         {
            _automation.AfterObjectChanged += _automation_AfterObjectChanged;
            _automation.Containers.CollectionChanged += _automationContainers_CollectionChanged;
            _automation.CurrentDesignerChanged += _automation_CurrentDesignerChanged;
            _automation.AfterUndoRedo += _automation_AfterUndoRedo;
         }
         else
         {
            _automation.AfterObjectChanged -= _automation_AfterObjectChanged;
            _automation.Containers.CollectionChanged -= _automationContainers_CollectionChanged;
            _automation.CurrentDesignerChanged -= _automation_CurrentDesignerChanged;
            _automation.AfterUndoRedo -= _automation_AfterUndoRedo;
         }
      }

      private void _automationContainers_CollectionChanged(object sender, AnnNotifyCollectionChangedEventArgs e)
      {
         Populate();
      }

      private void _automation_AfterUndoRedo(object sender, EventArgs e)
      {
         Populate();
      }

      private void _automation_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
      {
         switch (e.ChangeType)
         {
            case AnnObjectChangedType.Added:
            case AnnObjectChangedType.DesignerDraw:
            case AnnObjectChangedType.Deleted:
            case AnnObjectChangedType.Paste:
               PopulateContainer(_automation.ActiveContainer);
               break;

            default:
               // Just paint
               Invalidate();
               break;
         }
      }

      private void _automation_CurrentDesignerChanged(object sender, EventArgs e)
      {
         _ignoreAutomationSelected++;

         // Sync the selection
         var editObject = _automation.CurrentEditObject;
         if (editObject != null)
         {
            var selectionObject = editObject as AnnSelectionObject;
            List<AutomationSimpleObjectsListItem> toSelectItems = new List<AutomationSimpleObjectsListItem>();

            // get the object
            foreach (AutomationSimpleObjectsListItem item in this.Items)
            {
               if (item.AnnContainer != _automation.ActiveContainer)
                  continue;

               if (selectionObject == null)
               {
                  if (item.AnnObject == editObject)
                  {
                     toSelectItems.Add(item);
                     break;
                  }
               }
               else
               {
                  foreach (var annObject in selectionObject.SelectedObjects)
                  {
                     if (item.AnnObject == annObject)
                        toSelectItems.Add(item);
                  }
               }
            }

            this.ClearSelected();

            foreach (var item in toSelectItems)
               this.SelectedItems.Add(item);
         }
         else
         {
            this.ClearSelected();
         }

         _ignoreAutomationSelected--;
      }

      public void Clear()
      {
         this.SuspendLayout();
         this.Items.Clear();
         this.ResumeLayout();
      }

      public void Populate()
      {
         this.SuspendLayout();
         this.Items.Clear();

         if (_automation != null)
         {
            foreach (var annContainer in _automation.Containers)
            {
               foreach (var annObject in annContainer.Children)
               {
                  if (annObject.Id != AnnObject.SelectObjectId && annObject.Id != AnnObject.None)
                  {
                     this.Items.Add(new AutomationSimpleObjectsListItem(annContainer, annObject));
                  }
               }
            }
         }

         this.ResumeLayout();
      }

      public void PopulateContainer(AnnContainer annContainer)
      {
         this.SuspendLayout();

         // Find the first/last index of the container items
         int insertIndex = -1;
         int firstIndex = -1;
         int lastIndex = -1;
         var count = this.Items.Count;
         for (var i = 0; i < count && firstIndex == -1; i++)
         {
            var item = this.Items[i] as AutomationSimpleObjectsListItem;
            if (item.AnnContainer == annContainer)
            {
               firstIndex = i;
               for (var j = i + 1; j < count && lastIndex == -1; j++)
               {
                  item = this.Items[j] as AutomationSimpleObjectsListItem;
                  if (item.AnnContainer != annContainer)
                     lastIndex = j - 1;
               }

               if (lastIndex == -1)
                  lastIndex = count - 1;
            }
            else if (item.AnnContainer.PageNumber > annContainer.PageNumber && insertIndex == -1)
            {
               insertIndex = i;
            }
         }

         // Remove these items
         if (firstIndex != -1 && lastIndex != -1)
         {
            var removeCount = (lastIndex - firstIndex + 1);
            while (removeCount > 0)
            {
               this.Items.RemoveAt(firstIndex);
               removeCount--;
            }
         }

         // re-add the objects
         if (insertIndex == -1)
            insertIndex = 0;

         if (firstIndex != -1)
            insertIndex = firstIndex;

         foreach (var annObject in annContainer.Children)
         {
            if (annObject.Id != AnnObject.SelectObjectId && annObject.Id != AnnObject.None)
            {
               this.Items.Insert(insertIndex, new AutomationSimpleObjectsListItem(annContainer, annObject));
               insertIndex++;
            }
         }

         this.ResumeLayout();
      }

      private void UpdateResources()
      {
         if (_boldFont != null)
            _boldFont.Dispose();

         _boldFont = new Font(this.Font, FontStyle.Bold);

         Font[] fonts = { _boldFont, this.Font };
         _lineHeight = -1;

         using (var graphics = this.CreateGraphics())
         {
            foreach (var font in fonts)
            {
               // 3 lines of string
               var thisHeight = (int)(graphics.MeasureString("gH", this.Font).Height + 0.5f);
               if (thisHeight > _lineHeight)
                  _lineHeight = thisHeight;
            }
         }

         this.ItemHeight = _lineHeight * 3 + 8;
      }

      protected override void OnFontChanged(EventArgs e)
      {
         base.OnFontChanged(e);

         UpdateResources();
      }

      private Font _boldFont;
      private int _lineHeight;

      [DllImport("gdi32.dll")]
      private static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
      private const uint SRCCOPY = 0x00CC0020;

      protected override void OnDrawItem(DrawItemEventArgs e)
      {
         var currentContext = BufferedGraphicsManager.Current;
         var bounds = new Rectangle(0, 0, e.Bounds.Width + 1, e.Bounds.Height + 1);
         if (bounds.Width <= 0 || bounds.Height <= 0)
            return;
         using (BufferedGraphics bufferedGraphics = currentContext.Allocate(e.Graphics, bounds))
         {
            Rectangle rect = new Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height);
            var newArgs = new DrawItemEventArgs(
                bufferedGraphics.Graphics, e.Font, rect, e.Index, e.State, e.ForeColor, e.BackColor);

            this.DoDrawItem(newArgs);

            var hdcDest = e.Graphics.GetHdc();
            var hdcSrc = bufferedGraphics.Graphics.GetHdc();
            try
            {
               BitBlt(hdcDest, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height, hdcSrc, 0, 0, SRCCOPY);

            }
            finally
            {
               if (hdcDest != IntPtr.Zero) e.Graphics.ReleaseHdc(hdcDest);
               if (hdcSrc != IntPtr.Zero) bufferedGraphics.Graphics.ReleaseHdc(hdcDest);
            }
         }
      }

      private static Image _replyImage = Tools.LoadImageFromResource(typeof(Tools), "Leadtools.Annotations.WinForms.Resources", "Reply.png");

      private void DoDrawItem(DrawItemEventArgs e)
      {
         var bounds = e.Bounds;
         var graphics = e.Graphics;

         var isSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

         var brush = isSelected ? SystemBrushes.Info : SystemBrushes.Window;
         graphics.FillRectangle(brush, bounds);
         graphics.DrawLine(Pens.Black, bounds.X, bounds.Y, bounds.Width - 1, bounds.Y);
         if (e.Index == this.Items.Count - 1)
            graphics.DrawLine(Pens.Black, bounds.X, bounds.Bottom - 1, bounds.Width - 1, bounds.Bottom - 1);
         e.DrawFocusRectangle();

         if (e.Index == -1)
            return;

         // Get the object
         var item = this.Items[e.Index] as AutomationSimpleObjectsListItem;
         var annObject = item.AnnObject;

         var imageRect = new Rectangle(bounds.X + 2, bounds.Y + 2, _lineHeight, _lineHeight);

         var automationObject = _automation.Manager.FindObjectById(annObject.Id);
         if (automationObject != null)
         {
            var image = automationObject.ToolBarImage as Image;
            DrawImage(graphics, image, true, imageRect);
         }

         var metadata = annObject.Metadata;

         string author = null;
         if (metadata.ContainsKey(AnnObject.AuthorMetadataKey))
            author = metadata[AnnObject.AuthorMetadataKey];

         if (string.IsNullOrEmpty(author))
            author = "[author]";

         var lineRect = new Rectangle(imageRect.Right + 2, bounds.Y + 2, bounds.Width - 2, _lineHeight);
         var textFormatFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis;
         TextRenderer.DrawText(graphics, author, _boldFont, lineRect, SystemColors.ControlText, Color.Transparent, textFormatFormat);

         string lastModified = null;
         if (metadata.ContainsKey(AnnObject.ModifiedMetadataKey))
            lastModified = metadata[AnnObject.ModifiedMetadataKey];

         if (string.IsNullOrEmpty(lastModified))
            lastModified = "[date]";

#if DEBUG__NO
         var textObject = annObject as AnnTextObject;
         var line = string.Format("Page {0} {1} {2}", item.AnnContainer.PageNumber, lastModified, textObject != null ? textObject.Text : "");
#else
         var line = string.Format("Page {0} {1}", item.AnnContainer.PageNumber, lastModified);
#endif
         if (!item.AnnContainer.IsEnabled)
            line += " [Disabled]";

         lineRect.Y += _lineHeight + 2;

         TextRenderer.DrawText(graphics, line, this.Font, lineRect, SystemColors.ControlText, Color.Transparent, textFormatFormat);

         // Get the text
         string text = null;

         var textObject = annObject as AnnTextObject;
         if (textObject != null)
         {
            text = textObject.Text;
         }
         else
         {
            // Get it from the content
            if (metadata.ContainsKey(AnnObject.ContentMetadataKey))
               text = metadata[AnnObject.ContentMetadataKey];
         }

         if (!string.IsNullOrEmpty(text))
         {
            lineRect.Y += _lineHeight + 2;

            if (annObject.Reviews.Count > 0)
            {
               // Has reviews, show the little icon
               imageRect.Y = lineRect.Y;
               DrawImage(graphics, _replyImage, false, imageRect);
            }

            TextRenderer.DrawText(graphics, text, this.Font, lineRect, SystemColors.ControlText, Color.Transparent, textFormatFormat);
         }
      }

      private static void DrawImage(Graphics graphics, Image image, bool setTransparentColor, Rectangle bounds)
      {
         var bitmap = image as Bitmap;
         if (bitmap == null)
            return;

         var factor = 1.0;

         if (bitmap.Height > bounds.Height && bounds.Height > 0)
            factor = (double)bounds.Height / (double)bitmap.Height;

         var width = (int)(bitmap.Width * factor + 0.5);
         var height = (int)(bitmap.Height * factor + 0.5);

         var bitmapRect = new Rectangle(bounds.X, bounds.Y + (bounds.Height - height) / 2, width, height);

         if (setTransparentColor)
         {
            using (var ia = new ImageAttributes())
            {
               var color = bitmap.GetPixel(0, 0);
               ia.SetColorKey(color, color);
               graphics.DrawImage(bitmap, bitmapRect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
            }
         }
         else
         {
            graphics.DrawImage(bitmap, bitmapRect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
         }
      }

      private List<int> _trackSelection = new List<int>();
      private int _ignoreSelectionChanged;
      private int _ignoreAutomationSelected;

      protected override void OnSelectedIndexChanged(EventArgs e)
      {
         if (_ignoreSelectionChanged > 0)
            return;

         // Update our list
         var selectedIndicies = this.SelectedIndices;
         foreach (int index in selectedIndicies)
         {
            if (!_trackSelection.Contains(index))
               _trackSelection.Add(index);
         }

         foreach (int index in new List<int>(_trackSelection))
         {
            if (!selectedIndicies.Contains(index))
               _trackSelection.Remove(index);
         }

         // _trackSelection contains the current selected items in chronological order
         // make sure all objects are in the same container
         if (_trackSelection.Count > 1 && _automation != null)
         {
            var firstItem = this.Items[_trackSelection[0]] as AutomationSimpleObjectsListItem;
            var lastItem = this.Items[_trackSelection[_trackSelection.Count - 1]] as AutomationSimpleObjectsListItem;

            if (firstItem.AnnContainer != lastItem.AnnContainer)
            {
               // Unselect all but last object
               _ignoreSelectionChanged++;
               this.ClearSelected();
               this.SelectedItems.Add(lastItem);
               _ignoreSelectionChanged--;
            }
         }

         // Select the objects in the automation
         if (_automation != null && _ignoreAutomationSelected == 0)
         {
            var annObjects = new AnnObjectCollection();
            AnnContainer annContainer = null;
            foreach (var index in _trackSelection)
            {
               var item = this.Items[index] as AutomationSimpleObjectsListItem;
               annObjects.Add(item.AnnObject);
               if (annContainer == null)
                  annContainer = item.AnnContainer;
            }

            if (annContainer != null && annContainer != _automation.ActiveContainer)
               _automation.ActiveContainer = annContainer;

            _automation.SelectObjects(annObjects);

            if (_imageViewer != null)
            {
               var invalidRect = LeadRectD.Empty;
               foreach (var annObject in annObjects)
               {
                  if (annObject != null)
                     invalidRect = LeadRectD.UnionRects(invalidRect, _automation.GetObjectInvalidateRect(annObject));
               }

               _imageViewer.EnsureBoundsVisible(invalidRect);
            }
         }

         base.OnSelectedIndexChanged(e);
      }

      protected override void OnMouseDown(MouseEventArgs e)
      {
         if (_automation != null && e.Button == MouseButtons.Right)
         {
            var index = this.IndexFromPoint(new Point(e.X, e.Y));
            if (index != -1)
            {
               // If it is not selected, select it
               if (!this.SelectedIndices.Contains(index))
               {
                  this.ClearSelected();
                  this.SelectedIndex = index;
               }

               // Show its context menu
               ShowContextMenu();
            }
         }

         base.OnMouseDown(e);
      }

      private void ShowContextMenu()
      {
         if (_automation == null)
            return;

         var editObject = _automation.CurrentEditObject;
         if (editObject == null)
            return;

         var automationObject = _automation.Manager.FindObjectById(editObject.Id);
         if (automationObject == null)
            return;

         var position = this.PointToClient(Cursor.Position);
         var contextMenu = automationObject.ContextMenu as ObjectContextMenu;
         if (contextMenu != null)
         {
            contextMenu.Automation = _automation;
            contextMenu.Show(this, this.PointToClient(Cursor.Position));
         }
      }

      protected override void OnDoubleClick(EventArgs e)
      {
         ShowObjectProperties();

         base.OnDoubleClick(e);
      }

      protected override void OnKeyDown(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            ShowObjectProperties();

         base.OnKeyDown(e);
      }

      private void ShowObjectProperties()
      {
         if (_automation != null && _automation.CanShowObjectProperties)
            _automation.ShowObjectProperties();
      }
   }
}
