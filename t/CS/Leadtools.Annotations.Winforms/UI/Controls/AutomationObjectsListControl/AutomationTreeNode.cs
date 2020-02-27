// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.Windows.Forms;

namespace Leadtools.Annotations.WinForms
{
   internal class AutomationTreeNode : UserControl
   {
      public AutomationTreeNode()
      {
      }
      public AutomationTreeNode(AutomationObjectsListControl tree)
      {
         _tree = tree;
         ChildNodes = new List<AutomationTreeNode>();
         _isSelected = false;
      }

      private AutomationObjectsListControl _tree;
      public AutomationObjectsListControl Tree
      {
         get { return _tree; }
         set
         {
            _tree = value;
            foreach (AutomationTreeNode node in ChildNodes)
            {
               node.Tree = _tree;
            }
         }
      }

      private bool _isExpanded;
      public bool IsExpanded
      {
         get { return _isExpanded; }
         set 
         {
            _isExpanded = value;
         }
      }

      private bool _isSelected;
      public bool IsSelected
      {
         get { return _isSelected; }
         set
         {
            _isSelected = value;
         }
      }

      private int _depth;
      public int Depth
      {
         get { return _depth; }
         set 
         { 
            _depth = value;
            Margin = new Padding(25 * (_depth - 1), 0, 0, 0);
         }
      }

      private List<AutomationTreeNode> _childNodes;

      public List<AutomationTreeNode> ChildNodes
      {
         get { return _childNodes; }
         set { _childNodes = value; }
      }

      private AutomationTreeNode _treeParentNode;
      public AutomationTreeNode TreeParentNode
      {
         get { return _treeParentNode; }
         set
         {
            _treeParentNode = value;
            if (_treeParentNode != null)
            {
               Depth = _treeParentNode.Depth + 1;
            }
            else
            {
               Depth = 0;
               IsExpanded = true;
            }
         }
      }
   }
}
