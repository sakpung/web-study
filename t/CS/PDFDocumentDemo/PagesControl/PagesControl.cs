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
using Leadtools.Drawing;
using Leadtools.Pdf;

namespace PDFDocumentDemo.PagesControl
{
   public partial class PagesControl : UserControl
   {
      private Workers.GenerateThumbnailsWorker _generateThumbnailsWorker;

      public PagesControl()
      {
         InitializeComponent();

         // Use GDI+ paint
         RasterPaintProperties props = _rasterImageList.PaintProperties;
         props.PaintEngine = RasterPaintEngine.GdiPlus;
         _rasterImageList.PaintProperties = props;

         _thumbnailsToolStripButton.Checked = true;
         _bookmarksToolStripButton.Checked = false;
         _signaturesToolStripButton.Checked = false;

         // This object generates the thumbnails for the pages in a separate thread
         _generateThumbnailsWorker = new Workers.GenerateThumbnailsWorker();
         _generateThumbnailsWorker.PrePageProcessed += new EventHandler<Workers.ThreadedPageWorkerPageProcessedEventArgs>(_generateThumbnailsWorker_PrePageProcessed);
         _generateThumbnailsWorker.PostPageProcessed += new EventHandler<Workers.ThreadedPageWorkerPageProcessedEventArgs>(_generateThumbnailsWorker_PostPageProcessed);
         _generateThumbnailsWorker.ProcessFinished += new EventHandler<EventArgs>(_generateThumbnailsWorker_ProcessFinished);

         UpdateUIState();
      }

      private void Cleanup(bool disposing)
      {
         if (disposing)
         {
            if (_generateThumbnailsWorker != null)
            {
               _generateThumbnailsWorker.Stop();
               _generateThumbnailsWorker.PostPageProcessed -= new EventHandler<Workers.ThreadedPageWorkerPageProcessedEventArgs>(_generateThumbnailsWorker_PostPageProcessed);
               _generateThumbnailsWorker.PrePageProcessed -= new EventHandler<Workers.ThreadedPageWorkerPageProcessedEventArgs>(_generateThumbnailsWorker_PrePageProcessed);
               _generateThumbnailsWorker.ProcessFinished -= new EventHandler<EventArgs>(_generateThumbnailsWorker_ProcessFinished);
               _generateThumbnailsWorker.Dispose();
               _generateThumbnailsWorker = null;
            }
         }
      }

      #region Public
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer RasterImageList
      {
         get { return _rasterImageList; }
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ShowThumbnails
      {
         get { return _thumbnailsToolStripButton.Checked; }
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ShowBookmarks
      {
         get { return _bookmarksToolStripButton.Checked; }
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ShowSignatures
      {
         get { return _signaturesToolStripButton.Checked; }
      }

      public void SetActiveTab(bool thumbnails, bool bookmarks, bool signatures)
      {
         _thumbnailsToolStripButton.Checked = thumbnails;
         _bookmarksToolStripButton.Checked = bookmarks;
         _signaturesToolStripButton.Checked = signatures;

         UpdateUIState();
      }

      private void UpdateUIState()
      {
         if (_thumbnailsToolStripButton.Checked)
         {
            _rasterImageList.Visible = true;
            _bookmarksTreeView.Visible = false;
            _noBookmarksLabel.Visible = false;
            _signaturesTreeView.Visible = false;
            _noSignaturesLabel.Visible = false;
         }
         else if (_bookmarksToolStripButton.Checked)
         {
            _rasterImageList.Visible = false;
            bool hasBookmarks = _bookmarksTreeView.Nodes.Count > 0;
            _bookmarksTreeView.Visible = hasBookmarks;
            _noBookmarksLabel.Visible = !hasBookmarks;
            _signaturesTreeView.Visible = false;
            _noSignaturesLabel.Visible = false;
         }
         else
         {
            _rasterImageList.Visible = false;
            _bookmarksTreeView.Visible = false;
            _noBookmarksLabel.Visible = false;
            bool hasSignatures = _signaturesTreeView.Nodes.Count > 0;
            _signaturesTreeView.Visible = hasSignatures;
            _noSignaturesLabel.Visible = !hasSignatures;
         }
      }

      public void SetDocument(PDFDocument document)
      {
         _rasterImageList.BeginUpdate();
         _bookmarksTreeView.BeginUpdate();
         _signaturesTreeView.BeginUpdate();

         _rasterImageList.Items.Clear();
         _bookmarksTreeView.Nodes.Clear();
         _signaturesTreeView.Nodes.Clear();

         // This is the image we will load till the thumbnails are loaded
         using (Bitmap loadingThumbnailBitmap = global::PDFDocumentDemo.Properties.Resources.LoadingThumbnail)
         {
            using (RasterImage itemImage = RasterImageConverter.ConvertFromImage(loadingThumbnailBitmap, ConvertFromImageOptions.None))
            {
               if (document != null && document.Pages.Count >= 1)
               {
                  for (int page = 1; page <= document.Pages.Count; page++)
                  {
                     // We need to clone itemImage since the image list has AutoDisposeImages set to true
                     ImageViewerItem item = new ImageViewerItem();
                     item.Image = itemImage.Clone();
                     item.PageNumber = page;
                     item.Text = "Page " + page.ToString();
                     _rasterImageList.Items.Add(item);
                  }
               }
            }
         }

         // Add the bookmarks (if any)
         if (document != null && document.Bookmarks != null)
         {
            AddBookmarks(document.Bookmarks);
         }
         // Add the signatures (if any)
         if (document != null)
         {
            AddSignatures(document);
         }

         _rasterImageList.EndUpdate();
         _bookmarksTreeView.EndUpdate();
         _signaturesTreeView.EndUpdate();


         if (document != null && document.Pages.Count >= 1)
         {
            // Start reading the thumbnails            
            _generateThumbnailsWorker.Start(document, _rasterImageList.GetItemImageSize(_rasterImageList.ActiveItem, true).Width, _rasterImageList.GetItemImageSize(_rasterImageList.ActiveItem, true).Height);
         }

         UpdateUIState();
      }

      private void AddBookmarks(IList<PDFBookmark> bookmarks)
      {
         TreeNode lastNode = null;
         int lastNodeLevel = 0;

         foreach (PDFBookmark bookmark in bookmarks)
         {
            TreeNode node = new TreeNode(bookmark.Title);
            node.Tag = bookmark;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Level: {0}\n", bookmark.Level);
            sb.AppendFormat("Target page number: {0}\n", bookmark.TargetPageNumber);
            sb.AppendFormat("Target X/Y: {0}, {1}\n", bookmark.TargetPosition.X, bookmark.TargetPosition.Y);
            sb.AppendFormat("Target Zoom: {0}%\n", bookmark.TargetZoomPercent);
            sb.AppendFormat("Target Page Fit: {0}\n", bookmark.TargetPageFitType.ToString());
            sb.AppendFormat("Style: {0}", bookmark.BookmarkStyle.ToString());

            node.ToolTipText = sb.ToString();

            // This code takes care of PDF files that might have bookmarks with levels
            // that are not right: previous/next node level is homogeneous

            if (bookmark.Level == lastNodeLevel)
            {
               // Same as last level
               AddNode(_bookmarksTreeView, lastNode, node, true);
            }
            else if (bookmark.Level > lastNodeLevel)
            {
               // Add it as a child

               // Add empty nodes if the difference is greater than 1
               for (int i = lastNodeLevel + 1; i < bookmark.Level; i++)
               {
                  TreeNode emptyNode = new TreeNode("Missing");
                  // These nodes do not have a bookmarks
                  emptyNode.Tag = null;

                  AddNode(_bookmarksTreeView, lastNode, emptyNode, false);

                  lastNode = emptyNode;
               }

               // Now add it as a child
               AddNode(_bookmarksTreeView, lastNode, node, false);
            }
            else
            {
               // Move up

               // Go back to the last level equal to our level
               for (int i = bookmark.Level; i < lastNodeLevel && lastNode != null; i++)
               {
                  lastNode = lastNode.Parent;
               }

               // Now add it as a sibling
               AddNode(_bookmarksTreeView, lastNode, node, true);
            }

            lastNode = node;
            lastNodeLevel = node.Level;
         }
      }


      private void AddSignatures(PDFDocument document)
      {
         for (int i = 0; i < document.Pages.Count; i++)
         {
            if (document.Pages[i].Signatures == null)
               continue;

            foreach (PDFSignature signature in document.Pages[i].Signatures)
            {
               // Create Parent Node
               string title = string.Format("Signed By {0}", PDFSignaturesHelper.GetSubstring(signature.CertificateInfo["Subject"], "/CN=", "/"));

               TreeNode signatureNode = new TreeNode(title);

               AddNode(_signaturesTreeView, null, signatureNode, false);

               // Add Validity Node
               string validity = string.Format("Signature is {0}", PDFSignaturesHelper.GetState(signature.State));

               TreeNode validityNode = new TreeNode(validity);

               AddNode(_signaturesTreeView, signatureNode, validityNode, false);

               string info = "The Document has not been modified since this signature was applied.";

               TreeNode validityInfoNode = new TreeNode(info);

               AddNode(_signaturesTreeView, validityNode, validityInfoNode, false);

               if (signature.State == PDFSignature.StateUnknown)
               {
                  string unknownInfo = "The signer's identity is unknown because it not trusted identity.";

                  TreeNode unknownInfoNode = new TreeNode(unknownInfo);

                  AddNode(_signaturesTreeView, validityNode, unknownInfoNode, false);
               }

               // Add details Node
               string details = string.Format("Signature Details...");

               TreeNode detailsNode = new TreeNode(details);

               AddNode(_signaturesTreeView, signatureNode, detailsNode, false);

               string certificateDetails = string.Format("Certificate Details...");

               TreeNode certificateDetailsNode = new TreeNode(certificateDetails);
               certificateDetailsNode.Tag = signature;

               AddNode(_signaturesTreeView, detailsNode, certificateDetailsNode, false);
            }
         }
      }

      private static void AddNode(TreeView treeView, TreeNode relativeNode, TreeNode node, bool sibling)
      {
         if (sibling)
         {
            if (relativeNode != null && relativeNode.Parent != null)
            {
               relativeNode.Parent.Nodes.Add(node);
            }
            else
            {
               treeView.Nodes.Add(node);
            }
         }
         else
         {
            if (relativeNode != null)
            {
               relativeNode.Nodes.Add(node);
            }
            else
            {
               treeView.Nodes.Add(node);
            }
         }
      }

      private bool _ignoreSelectedChanged = false;

      public void SetCurrentPageNumber(int pageNumber)
      {
         _ignoreSelectedChanged = true;
         int pageIndex = pageNumber - 1;

         // De-select all items but 'pageIndex'

         _rasterImageList.BeginUpdate();

         for (int i = 0; i < _rasterImageList.Items.Count; i++)
         {
            ImageViewerItem item = _rasterImageList.Items[i];

            if (i == pageIndex)
            {
               item.IsSelected = true;
            }
            else
            {
               item.IsSelected = false;
            }
         }

         _rasterImageList.EnsureItemVisibleByIndex(pageIndex);
         _rasterImageList.EndUpdate();
         _ignoreSelectedChanged = false;
      }

      public void StopLoadingThumbnails()
      {
         if (_generateThumbnailsWorker != null)
         {
            _generateThumbnailsWorker.Stop();
         }
      }

      public event EventHandler<ActionEventArgs> Action;
      #endregion Public

      #region Private
      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if (Action != null)
         {
            Action(this, new ActionEventArgs(action, data));
         }
      }

      private int CurrentPageNumber
      {
         get
         {
            // Find the first selected item in the image list, it is
            // a single selection control
            for (int i = 0; i < _rasterImageList.Items.Count; i++)
            {
               if (_rasterImageList.Items[i].IsSelected)
               {
                  return i + 1;
               }
            }

            // No items
            return 0;
         }
      }

      private delegate void PageThumbnailDelegate(Workers.ThreadedPageWorkerPageProcessedEventArgs e);

      private void PreSetPageThumbnail(Workers.ThreadedPageWorkerPageProcessedEventArgs e)
      {
         _titleLabel.Text = string.Format("Page {0}...", e.PageNumber);
      }

      private void PostSetPageThumbnail(Workers.ThreadedPageWorkerPageProcessedEventArgs e)
      {
         int itemIndex = e.PageNumber - 1;
         if (itemIndex >= 0 && itemIndex < _rasterImageList.Items.Count)
         {
            ImageViewerItem item = _rasterImageList.Items[itemIndex];

            RasterImage image = e.Data as RasterImage;
            if (image == null || e.Error != null)
            {
               // Could no be loaded
               using (Bitmap loadingThumbnailBitmap = global::PDFDocumentDemo.Properties.Resources.ErrorThumbnail)
               {
                  image = RasterImageConverter.ConvertFromImage(loadingThumbnailBitmap, ConvertFromImageOptions.None);
               }
            }

            item.Image = image;
            _rasterImageList.Invalidate(true);
         }
      }

      private void SetPageThumbnailsFinished()
      {
         _titleLabel.Text = string.Empty;
      }

      private void _generateThumbnailsWorker_PrePageProcessed(object sender, Workers.ThreadedPageWorkerPageProcessedEventArgs e)
      {
         // This fires in the thumbnails generator thread context, so invoke our updates
         BeginInvoke(new PageThumbnailDelegate(PreSetPageThumbnail), new object[] { e });
      }

      private void _generateThumbnailsWorker_PostPageProcessed(object sender, Workers.ThreadedPageWorkerPageProcessedEventArgs e)
      {
         // This fires in the thumbnails generator thread context, so invoke our updates
         BeginInvoke(new PageThumbnailDelegate(PostSetPageThumbnail), new object[] { e });
      }

      private void _generateThumbnailsWorker_ProcessFinished(object sender, EventArgs e)
      {
         BeginInvoke(new MethodInvoker(SetPageThumbnailsFinished));
      }

      #endregion Private

      #region UI
      private void _thumbnailsToolStripButton_Click(object sender, EventArgs e)
      {
         SetActiveTab(true, false, false);
      }

      private void _bookmarksToolStripButton_Click(object sender, EventArgs e)
      {
         SetActiveTab(false, true, false);
      }

      private void _signaturesToolStripButton_Click(object sender, System.EventArgs e)
      {
         SetActiveTab(false, false, true);
      }

      private void _bookmarksTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         if (e.Node != null)
         {
            GotoBookmark(e.Node);
         }
      }

      private void _bookmarksTreeView_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)Keys.Return && _bookmarksTreeView.SelectedNode != null)
         {
            GotoBookmark(_bookmarksTreeView.SelectedNode);
         }
      }

      private void _signaturesTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         if (e.Node != null)
         {
            if (e.Node.Tag is PDFSignature)
            {
               PDFSignature signature = e.Node.Tag as PDFSignature;
               using (DigitalSignaturesDialog signaturesDialog = new DigitalSignaturesDialog(signature))
               {
                  signaturesDialog.ShowDialog();
               }
            }
         }
      }

      private void _signaturesTreeView_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)Keys.Return && _signaturesTreeView.SelectedNode != null)
         {
            TreeNode node = _signaturesTreeView.SelectedNode;

            if (node != null && node.Tag is PDFSignature)
            {
               PDFSignature signature = node.Tag as PDFSignature;
               using (DigitalSignaturesDialog signaturesDialog = new DigitalSignaturesDialog(signature))
               {
                  signaturesDialog.ShowDialog();
               }
            }
         }
      }

      private void GotoBookmark(TreeNode node)
      {
         if (node != null && node.Tag != null)
         {
            PDFBookmark bookmark = (PDFBookmark)node.Tag;
            DoAction("GotoBookmark", bookmark);
         }
      }

      void _rasterImageList_SelectedItemsChanged(object sender, System.EventArgs e)
      {
         if (_ignoreSelectedChanged)
            return;
         int pageNumber = CurrentPageNumber;
         DoAction("PageNumberChanged", pageNumber);
      }

      private void _rasterImageList_Scroll(object sender, EventArgs e)
      {
         // Find the an item above where the user clicked.
         int index = _rasterImageList.GetFirstVisibleItemIndex(ImageViewerItemPart.Item);

         if (index != -1 && _generateThumbnailsWorker != null && _generateThumbnailsWorker.IsWorking)
         {
            _generateThumbnailsWorker.NextPageNumber = index;
         }
      }
      #endregion UI
   }
}
