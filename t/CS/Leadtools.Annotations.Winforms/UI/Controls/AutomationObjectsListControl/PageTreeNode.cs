// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Annotations.Engine;

namespace Leadtools.Annotations.WinForms
{
   internal partial class PageTreeNode : AutomationTreeNode
   {
      public PageTreeNode(AnnContainer annContainer, AutomationObjectsListControl tree) : base(tree)
      {
         InitializeComponent();

         if (annContainer == null) throw new ArgumentNullException("annContainer");
         _annContainer = annContainer;

         Width = Tree.TreeRootNode.Width;
         IsExpanded = false;
         UpdateTitle();
      }

      public void UpdateTitle()
      {
         string text = "Page " + _annContainer.PageNumber;
         if (!_annContainer.IsEnabled)
            text += " [Disabled]";
         _lblPageNumber.Text = text;
      }

      private AnnContainer _annContainer;
      public AnnContainer AnnContainer
      {
         get { return _annContainer; }
      }

      private void _btnCollapseExpand_Click(object sender, EventArgs e)
      {
         IsExpanded = !IsExpanded;
         _btnCollapseExpand.Text = IsExpanded ? "-" : "+";
         if (IsExpanded)
         {
            if (Tree.Controls.Contains(this))
            {
               int parentIndex = Tree.Controls.GetChildIndex(this);
               Tree.AddChildsToTree(ChildNodes, ref parentIndex);
            }
         }
         else
         {
            Tree.RemoveChildsFromTree(ChildNodes);
         }
      }

      internal void ExpandPage()
      {
         foreach (AnnObjectTreeNode annNode in ChildNodes)
         {
            if (!IsExpanded)
            {
               IsExpanded = true;
               _btnCollapseExpand.Text = "-";
               if ( Tree.Controls.Contains(this))
               {
                  int parentIndex = Tree.Controls.GetChildIndex(this);
                  Tree.AddChildsToTree(ChildNodes, ref parentIndex);
               }
            }
         }
      }

      internal void CollapsePage()
      {
         foreach (AnnObjectTreeNode annNode in ChildNodes)
         {
            if (IsExpanded)
            {
               IsExpanded = false;
               _btnCollapseExpand.Text = "+";
               foreach (AnnObjectTreeNode child in ChildNodes)
               {
                  Tree.RemoveChildsFromTree(ChildNodes);
               }
            }
         }
      }

      private void PageTreeNode_Click(object sender, EventArgs e)
      {
         if (IsExpanded)
         {
            CollapsePage();
         }
         else
         {
            ExpandPage();
         }
      }
   }
}
