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
   internal partial class AnnObjectTreeNode : AutomationTreeNode
   {
      public AnnObjectTreeNode(AnnObject annObject, AutomationTreeNode treeParentNode, AnnAutomation automation, AutomationObjectsListControl tree): base(tree)
      {
         InitializeComponent();

         if (annObject == null) throw new ArgumentNullException("annObject");
         if (annObject.Id == AnnObject.SelectObjectId || annObject.Id == AnnObject.None)
            throw new ArgumentException("Cannot create this item with a selection or none annotation object", "annObject");

         if (treeParentNode == null) throw new ArgumentNullException("treeParentNode");
         if (automation == null) throw new ArgumentNullException("automation");

         _annObject = annObject;
         _automation = automation;

         _tbComment.Visible = _annObject.SupportsContent;

         AnnAutomationObject automationObject = _automation.Manager.FindObjectById(_annObject.Id);
         if (automationObject != null)
         {
            _lblObjectName.Text = automationObject.Name;
            _pbObjetIcon.Image = automationObject.ToolBarImage as Image;
         }
         else
         {
            _lblObjectName.Text = _annObject.FriendlyName;
            _pbObjetIcon.Image = null;
         }

         UpdateMetadata();

         Width = Tree.TreeRootNode.Width - Margin.Left;
         TreeParentNode = treeParentNode;
         IsExpanded = false;
         GetReviews(AnnObject, this, AnnObject.Reviews);
      }

      private AnnObject _annObject;
      public AnnObject AnnObject
      {
         get { return _annObject; }
      }

      private AnnAutomation _automation;

      private void GetReviews(AnnObject annObject, AutomationTreeNode parent, IList<AnnReview> reviews)
      {
         foreach (AnnReview reply in reviews)
         {
            ReviewTreeNode reviewNode = new ReviewTreeNode(annObject, reviews, reply, parent, _automation, Tree);
            parent.ChildNodes.Add(reviewNode);
            GetReviews(annObject, reviewNode, reply.Replies);
         }
      }

      public static string ToLocalTimeString(string utcString)
      {
         if (string.IsNullOrEmpty(utcString))
            return null;

         try
         {
            DateTime date = AnnObject.DateFromString(utcString);
            date = date.ToLocalTime();

            string localTimeString = date.ToString();
            return localTimeString;
         }
         catch
         {
            return null;
         }
      }

      public void UpdateMetadata()
      {
         Dictionary<string, string> metadata = _annObject.Metadata;
         string author = null;
         if (metadata.ContainsKey(AnnObject.AuthorMetadataKey))
            author = metadata[AnnObject.AuthorMetadataKey];

         if (!string.IsNullOrEmpty(author))
            _lblAuthor.Text = author;

         string lastModified = null;
         if (metadata.ContainsKey(AnnObject.ModifiedMetadataKey))
            lastModified = AnnObjectTreeNode.ToLocalTimeString(metadata[AnnObject.ModifiedMetadataKey]);

         if (!string.IsNullOrEmpty(lastModified))
            _lblDate.Text = lastModified;

         if (metadata.ContainsKey(AnnObject.ContentMetadataKey))
            _tbComment.Text = metadata[AnnObject.ContentMetadataKey];
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

      private void _tbComment_TextChanged(object sender, EventArgs e)
      {
         bool hasChanged = false;
         Dictionary<string, string> metadata = _annObject.Metadata;
         if (metadata.ContainsKey(AnnObject.ContentMetadataKey))
         {
            string oldValue = metadata[AnnObject.ContentMetadataKey];
            if (string.Compare(oldValue, _tbComment.Text, StringComparison.OrdinalIgnoreCase) != 0)
            {
               metadata[AnnObject.ContentMetadataKey] = _tbComment.Text;
               hasChanged = true;
            }
         }

         if (hasChanged && _automation != null)
         {
            AnnObjectCollection modifiedObjects = new AnnObjectCollection();
            modifiedObjects.Add(_annObject);

            this.Tree.BeginIgnoreChanged();
            try
            {
               _automation.InvokeAfterObjectChanged(modifiedObjects, AnnObjectChangedType.Metadata);
            }
            finally
            {
               this.Tree.EndIgnoreChanged();
            }
         }
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

      private void _replyReview_Click(object sender, EventArgs e)
      {
         AnnReview review = new AnnReview();
         review.Author = Environment.UserName;
         review.Date = DateTime.Now;
         review.Status = AnnReview.Reply;
         _annObject.Reviews.Add(review);
         ReviewTreeNode child = new ReviewTreeNode(_annObject, _annObject.Reviews, review, this, _automation, Tree);
         ChildNodes.Add(child);
         IsExpanded = true;
         _btnCollapseExpand.Text = "-";
         _miExpandCollapse.Text = "Collapse";
         _lblObjectName.Visible = true;
         _lblDate.Visible = true;
         if (IsExpanded)
         {
            Tree.RemoveChildsFromTree(ChildNodes);
            int parentIndex = Tree.Controls.GetChildIndex(this);
            Tree.AddChildsToTree(ChildNodes, ref parentIndex);
         }
         else
         {
            int parentIndex = Tree.Controls.GetChildIndex(this);
            Tree.AddChildsToTree(ChildNodes, ref parentIndex);
         }
      }

      private void _miExpandCollapse_Click(object sender, EventArgs e)
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

      private void _annNodeContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
      {
         _miDelete.Enabled = _automation.CanDeleteObjects;
         _miProperties.Enabled = _automation.CanShowObjectProperties;
         _miReply.Enabled = _automation.CanShowObjectProperties;
      }

      private void _miDelete_Click(object sender, EventArgs e)
      {
         _automation.DeleteSelectedObjects();
      }

      private void _miProperties_Click(object sender, EventArgs e)
      {
         ShowObjectProperties();
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         if (IsSelected)
         {
            _lblBottomSeparetor.Visible = false;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                  Color.DarkGray, 3, ButtonBorderStyle.Outset,
                                  Color.DarkGray, 3, ButtonBorderStyle.Outset,
                                  Color.DarkGray, 3, ButtonBorderStyle.Inset,
                                  Color.DarkGray, 3, ButtonBorderStyle.Inset);
         }
         else
         {
            _lblBottomSeparetor.Visible = true;
         }
         base.OnPaint(e);
      }

      private void AnnObjectTreeNode_Click(object sender, EventArgs e)
      {
         if (_annObject != null && _automation != null)
         {
            if (!Tree.SelectedItems.Contains(this))
            {
               Tree.ClearSelection();
               Tree.AddSelectedObject(this);
            }
         }
      }

      private void AnnObjectTreeNode_DoubleClick(object sender, EventArgs e)
      {
         ShowObjectProperties();
      }

      private void AnnObjectTreeNode_MouseDown(object sender, MouseEventArgs e)
      {
         if (_annObject != null && _automation != null)
         {
            _automation.SelectObject(_annObject);
            if (!Tree.SelectedItems.Contains(this))
            {
               Tree.ClearSelection();
               Tree.AddSelectedObject(this);
            }
         }
      }
   }
}
