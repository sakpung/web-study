// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Windows.Forms;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{
   internal partial class ReviewTreeNode : AutomationTreeNode
   {
      public ReviewTreeNode(AnnObject annObject, IList<AnnReview> reviews, AnnReview reply, AutomationTreeNode treeParentNode, AnnAutomation automation, AutomationObjectsListControl tree) : base(tree)
      {
         InitializeComponent();
         if (annObject == null) throw new ArgumentNullException("annObject");
         if (annObject.Id == AnnObject.SelectObjectId || annObject.Id == AnnObject.None)
            throw new ArgumentException("Cannot create this item with a selection or none annotation object", "annObject");
         if (reviews == null) throw new ArgumentNullException("reviews");
         if (reply == null) throw new ArgumentNullException("reply");
         if (automation == null) throw new ArgumentNullException("automation");
         _annObject = annObject;
         _automation = automation;
         _reviews = reviews;
         _reply = reply;
         AnnAutomationObject automationObject = _automation.Manager.FindObjectById(_annObject.Id);
         if (automationObject != null)
         {
            _lblObjectName.Text = automationObject.Name;
         }
         else
         {
            _lblObjectName.Text = _annObject.FriendlyName;
         }
         _pbObjetIcon.Image = _replyImage;

         if (!String.IsNullOrEmpty(_reply.Author))
            _lblAuthor.Text = _reply.Author;

         string date = _reply.Date.ToString();
         if (!String.IsNullOrEmpty(date))
            _lblDate.Text = date;

         string status = _reply.Status;
         if (!String.IsNullOrEmpty(status))
            _lblDate.Text = status + ": " +_lblDate.Text;

         foreach (ToolStripMenuItem item in _miSetStatus.DropDownItems)
         {
            item.Checked = (item.Text == status);
         }

         if (!String.IsNullOrEmpty(_reply.Comment))
            _tbComment.Text = _reply.Comment;

         _cbChecked.Checked = _reply.IsChecked;

         TreeParentNode = treeParentNode;
         IsExpanded = false;
         Width = Tree.TreeRootNode.Width - Margin.Left;
      }
      private static Image _replyImage = Tools.LoadImageFromResource(typeof(Tools), "Leadtools.Annotations.WinForms.Resources", "Reply.png");

      private AnnObject _annObject;
      public AnnObject AnnObject
      {
         get { return _annObject; }
      }

      private AnnAutomation _automation;

      private IList<AnnReview> _reviews;
      public IList<AnnReview> Reviews
      {
         get { return _reviews; }
      }

      private AnnReview _reply;
      public AnnReview Reply
      {
         get { return _reply; }
      }

      private void _btnCollapseExpand_Click(object sender, EventArgs e)
      {
         IsExpanded = !IsExpanded;
         _btnCollapseExpand.Text = IsExpanded ? "-" : "+";
         _miExpandCollapse.Text = IsExpanded ? "Collapse" : "Expand";
         _lblObjectName.Visible = IsExpanded;
         _lblDate.Visible = IsExpanded;
         if (IsExpanded)
         {
            int parentIndex = Tree.Controls.GetChildIndex(this);
            Tree.AddChildsToTree(ChildNodes, ref parentIndex);
         }
         else
         {
            Tree.RemoveChildsFromTree(ChildNodes);
         }
      }

      private void _cbChecked_CheckedChanged(object sender, EventArgs e)
      {
         _reply.IsChecked = (sender as CheckBox).Checked;
      }

      private void _tbComment_TextChanged(object sender, EventArgs e)
      {
         _reply.Comment = (sender as TextBox).Text;
      }

      private void _deleteReview_Click(object sender, EventArgs e)
      {
         _reviews.Remove(Reply);
         if (IsExpanded)
         {
            Tree.RemoveChildsFromTree(ChildNodes);
         }
         Tree.Controls.Remove(this);
         TreeParentNode.ChildNodes.Remove(this);
      }

      private void _replyReview_Click(object sender, EventArgs e)
      {
         AnnReview reply = new AnnReview();
         reply.Author = Environment.UserName;
         reply.Date = DateTime.Now;
         reply.Status = AnnReview.Reply;
         _reply.Replies.Add(reply);
         ReviewTreeNode child = new ReviewTreeNode(_annObject, _reviews, reply, this, _automation, Tree);
         ChildNodes.Add(child);
         IsExpanded = true;
         _btnCollapseExpand.Text = "-";
         _lblObjectName.Visible = true;
         _lblDate.Visible = true;
         Tree.RemoveChildsFromTree(ChildNodes);
         int parentIndex = Tree.Controls.GetChildIndex(this);
         Tree.AddChildsToTree(ChildNodes, ref parentIndex);
      }

      private void _addReview_Click(object sender, EventArgs e)
      {
         AnnReview review = new AnnReview();
         review.Author = Environment.UserName;
         review.Date = DateTime.Now;
         review.Status = AnnReview.Reply;
         _reviews.Add(review);
         ReviewTreeNode reply = new ReviewTreeNode(_annObject, _reviews, review, TreeParentNode, _automation, Tree);
         TreeParentNode.ChildNodes.Add(reply);
         Tree.RemoveChildsFromTree(TreeParentNode.ChildNodes);
         int parentIndex = Tree.Controls.GetChildIndex(TreeParentNode);
         Tree.AddChildsToTree(TreeParentNode.ChildNodes, ref parentIndex);
      }

      private void _checkReview_Click(object sender, EventArgs e)
      {
         _cbChecked.Checked = !_cbChecked.Checked;
      }

      private void _miStatus_Click(object sender, EventArgs e)
      {
         _reply.Status = (sender as ToolStripMenuItem).Text;
         foreach (ToolStripMenuItem item in _miSetStatus.DropDownItems)
         {
            item.Checked = item.Equals(sender);
         }

         string date = _reply.Date.ToString();
         if (!String.IsNullOrEmpty(date))
            _lblDate.Text = date;

         string status = _reply.Status;
         if (!String.IsNullOrEmpty(status))
            _lblDate.Text = status + ": " + _lblDate.Text;
      }

      private void _reviewNodeContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
      {
         _checkReview.Text = _reply.IsChecked ? "Uncheck" : "Check";
      }
   }
}
