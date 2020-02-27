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

using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{
   public partial class AutomationReviewControl : UserControl
   {
      public AutomationReviewControl()
      {
         InitializeComponent();

         _statusComboBox.Items.AddRange(
            new string[]
            {
               AnnReview.Accepted,
               AnnReview.Cancelled,
               AnnReview.Completed,
               AnnReview.Created,
               AnnReview.Modified,
               AnnReview.None,
               AnnReview.Rejected,
               AnnReview.Reply
            });

         _statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

         UpdateResources();
      }

      private void CleanUp()
      {
         if (_boldFont != null)
         {
            _boldFont.Dispose();
            _boldFont = null;
         }
      }

      private Font _boldFont;
      private int _lineHeight;

      private void UpdateResources()
      {
         if (_boldFont != null)
            _boldFont.Dispose();

         _boldFont = new Font(_treeView.Font, FontStyle.Bold);

         Font[] fonts = { _boldFont, _treeView.Font };
         _lineHeight = -1;

         using (var graphics = _treeView.CreateGraphics())
         {
            foreach (var font in fonts)
            {
               // 3 lines of string
               var thisHeight = (int)(graphics.MeasureString("gH", _treeView.Font).Height + 0.5f);
               if (thisHeight > _lineHeight)
                  _lineHeight = thisHeight;
            }
         }

         _treeView.ItemHeight = _lineHeight * 3 + 8;
      }

      private string _userName;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public string UserName
      {
         get { return _userName; }
         set { _userName = value; }
      }

      private bool _isModified;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool IsModified
      {
         get { return _isModified; }
         set { _isModified = value; }
      }

      public void CopyReviewsFrom(AnnObject annObject)
      {
         if (annObject == null) throw new ArgumentNullException("annObject");

         // Add the content (if available)
         UpdateContent(annObject);

         _treeView.SuspendLayout();
         _treeView.Nodes.Clear();

         foreach (var review in annObject.Reviews)
         {
            AddNode(_treeView, null, true, review);
         }

         _treeView.ResumeLayout();
         _treeView.ExpandAll();

         if (_treeView.SelectedNode == null && _treeView.Nodes.Count > 0)
            _treeView.SelectedNode = _treeView.Nodes[0];

         UpdateUIState();
      }

      private void UpdateContent(AnnObject annObject)
      {
         var metadata = annObject.Metadata;

         string author = null;
         if (metadata.ContainsKey(AnnObject.AuthorMetadataKey))
            author = metadata[AnnObject.AuthorMetadataKey];

         if (string.IsNullOrEmpty(author))
            author = "[author]";

         string lastModified = null;
         if (metadata.ContainsKey(AnnObject.ModifiedMetadataKey))
            lastModified = AnnObjectTreeNode.ToLocalTimeString(AnnObject.ModifiedMetadataKey);

         if (string.IsNullOrEmpty(lastModified))
            lastModified = "[date]";

         _contentGroupBox.Text = string.Format("By {0} at {1}", author, lastModified);

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

         _contentTextBox.Text = text;
      }

      public void ReplacesReviewsIn(AnnObject annObject)
      {
         if (annObject == null) throw new ArgumentNullException("annObject");

         annObject.Reviews.Clear();

         foreach (TreeNode node in _treeView.Nodes)
         {
            GetNode(_treeView, node, annObject, null);
         }
      }

      private static void GetNode(TreeView treeView, TreeNode node, AnnObject annObject, AnnReview parentReview)
      {
         var nodeReview = node != null ? node.Tag as AnnReview : null;
         var review = nodeReview != null ? nodeReview.Clone() : null;

         foreach (TreeNode childNode in node.Nodes)
         {
            GetNode(treeView, childNode, annObject, review);
         }

         if (parentReview != null)
            parentReview.Replies.Add(review);
         else
            annObject.Reviews.Add(review);
      }

      private static TreeNode AddNode(TreeView treeView, TreeNode relativeNode, bool sibling, AnnReview review)
      {
         // Add some text to make it wide. We will custom-draw this anyway
         TreeNode node = new TreeNode(GetReviewNodeText(review));

         // add a copy so we don't change the original reviews if the user cancels
         node.Tag = review != null ? review.Clone() : null;
         review = node.Tag as AnnReview;

         foreach (var reply in review.Replies)
         {
            AddNode(treeView, node, true, reply);
         }

         // Clean its replies, we dont need them here
         review.Replies.Clear();

         if (sibling)
         {
            if (relativeNode != null)
               relativeNode.Nodes.Add(node);
            else
               treeView.Nodes.Add(node);
         }
         else
         {
            if (relativeNode != null)
            {
               TreeNodeCollection nodes;

               if (relativeNode.Parent != null)
                  nodes = relativeNode.Parent.Nodes;
               else
                  nodes = treeView.Nodes;

               var index = nodes.IndexOf(relativeNode);
               if (index != -1)
                  nodes.Insert(index + 1, node);
               else
                  nodes.Add(node);
            }
            else
            {
               treeView.Nodes.Add(node);
            }
         }

         return node;
      }

      private static string[] GetReviewTextLines(AnnReview review)
      {
         // We are drawing the following lines
         // author
         // status date
         // comment

         var lines = new string[3];

         var author = review != null ? review.Author : null;
         if (string.IsNullOrEmpty(author))
            author = "[author]";

         lines[0] = author;

         if (review != null)
         {
            lines[1] = string.Format("{0} {1}", review.Status, review.Date);
            lines[2] = review.Comment;
         }
         else
         {
            lines[1] = string.Empty;
            lines[2] = string.Empty;
         }

         return lines;
      }

      private static string GetReviewNodeText(AnnReview review)
      {
         var lines = GetReviewTextLines(review);

         // Miminum length is 4
         var maxLength = 4;
         foreach (var line in lines)
         {
            if (!string.IsNullOrEmpty(line))
               maxLength = Math.Max(line.Length, maxLength);
         }

         var sb = new StringBuilder();
         for (var i = 0; i < maxLength; i++)
            sb.Append("W");
         return sb.ToString();
      }

      private void _treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
      {
         e.DrawDefault = false;

         var node = e.Node;
         var review = node.Tag as AnnReview;
         var graphics = e.Graphics;

         var bounds = e.Bounds;
         var isHighlighted = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected && (e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused;
         var textColor = isHighlighted ? SystemColors.HighlightText : SystemColors.ControlText;

         var lines = GetReviewTextLines(review);

         var lineRect = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width - 2, _lineHeight);

         var textFormatFormat = TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis;
         TextRenderer.DrawText(graphics, lines[0], _boldFont, lineRect, textColor, Color.Transparent, textFormatFormat);

         lineRect.Y += _lineHeight + 2;
         TextRenderer.DrawText(graphics, lines[1], _treeView.Font, lineRect, textColor, Color.Transparent, textFormatFormat);

         lineRect.Y += _lineHeight + 2;
         TextRenderer.DrawText(graphics, lines[2], _treeView.Font, lineRect, textColor, Color.Transparent, textFormatFormat);
      }

      private void _treeView_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            var node = _treeView.GetNodeAt(e.X, e.Y);
            if (node != null)
               _treeView.SelectedNode = node;
         }
      }

      private void _treeView_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete)
            DeleteReview(_treeView.SelectedNode);
      }

      private void _treeView_AfterSelect(object sender, TreeViewEventArgs e)
      {
         UpdateUIState();
         ReviewToDetails();
      }

      private void UpdateUIState()
      {
         var node = _treeView.SelectedNode;
         _replyButton.Enabled = node != null;
         _deleteButton.Enabled = node != null;
         _detailsGroupBox.Enabled = node != null;
      }

      private void _contextMenuStrip_Opening(object sender, CancelEventArgs e)
      {
         var node = _treeView.SelectedNode;
         var review = node != null ? node.Tag as AnnReview : null;
         _deleteToolStripMenuItem.Enabled = (node != null);
         _replyToolStripMenuItem.Enabled = (node != null);
         _checkToolStripMenuItem.Enabled = (node != null);
         if (review != null)
            _checkToolStripMenuItem.Checked = review.IsChecked;
      }

      private void _replyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _replyButton.PerformClick();
      }

      private void _addToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _addButton.PerformClick();
      }

      private void _deleteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _deleteButton.PerformClick();
      }

      private void _checkToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var node = _treeView.SelectedNode;
         var review = node != null ? node.Tag as AnnReview : null;
         if (review != null)
         {
            review.IsChecked = !review.IsChecked;
            ReviewToDetails();
         }
      }

      private void _replyButton_Click(object sender, EventArgs e)
      {
         AddOrReply(_treeView.SelectedNode, true);
      }

      private void _addButton_Click(object sender, EventArgs e)
      {
         AddOrReply(_treeView.SelectedNode, false);
      }

      private void _deleteButton_Click(object sender, EventArgs e)
      {
         DeleteReview(_treeView.SelectedNode);
      }

      private void DeleteReview(TreeNode node)
      {
         if (node == null)
            return;

         // Remove it from its parent
         if (node.Parent != null)
         {
            var parentReview = node.Parent.Tag as AnnReview;
            node.Parent.Nodes.Remove(node);
         }
         else
            _treeView.Nodes.Remove(node);

         UpdateUIState();
         ReviewToDetails();
      }

      private void AddOrReply(TreeNode node, bool isReply)
      {
         _isModified = true;

         // add after selected
         var review = new AnnReview();
         review.Author = this.UserName;
         review.Date = DateTime.Now;
         review.Status = AnnReview.Reply;

         var newNode = AddNode(_treeView, node, isReply, review);
         _treeView.SelectedNode = newNode;
      }

      private void _detailsTextBox_TextChanged(object sender, EventArgs e)
      {
         _isModified = true;

         DetailsToReview();
      }

      private void _checkedCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _isModified = true;

         DetailsToReview();
      }

      private void _dateTimePicker_ValueChanged(object sender, EventArgs e)
      {
         _isModified = true;

         DetailsToReview();
      }

      private void ReviewToDetails()
      {
         var node = _treeView.SelectedNode;
         var review = node != null ? node.Tag as AnnReview : null;

         _ignoreChanges = true;

         _detailsGroupBox.Enabled = node != null;
         _authorTextBox.Text = review != null ? review.Author : string.Empty;
         _dateTimePicker.Value = review != null ? review.Date : DateTime.Now;
         _statusComboBox.Text = review != null ? review.Status : string.Empty;
         _checkedCheckBox.Checked = review != null ? review.IsChecked : false;
         _commentTextBox.Text = review != null ? review.Comment : string.Empty;

         _ignoreChanges = false;
      }

      private bool _ignoreChanges;

      private void DetailsToReview()
      {
         if (_ignoreChanges)
            return;

         var node = _treeView.SelectedNode;
         if (node == null)
            return;

         var review = node.Tag as AnnReview;

         if (review != null)
         {
            if (review.Author != _authorTextBox.Text) review.Author = _authorTextBox.Text;
            if (review.Date != _dateTimePicker.Value) review.Date = _dateTimePicker.Value;
            if (review.Status != _statusComboBox.Text) review.Status = _statusComboBox.Text;
            if (review.IsChecked != _checkedCheckBox.Checked) review.IsChecked = _checkedCheckBox.Checked;
            if (review.Comment != _commentTextBox.Text) review.Comment = _commentTextBox.Text;
         }

         node.Text = GetReviewNodeText(review);

         _treeView.Invalidate(node.Bounds);
      }
   }
}
