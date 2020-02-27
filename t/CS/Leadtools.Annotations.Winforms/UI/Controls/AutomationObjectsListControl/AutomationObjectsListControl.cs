// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using Leadtools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Leadtools.Annotations.WinForms
{
   public class AutomationObjectsListControl : TableLayoutPanel
   {
      public AutomationObjectsListControl()
      {
         SetDoubleBuffered(this);
         AutoScroll = true;
         Padding = new Padding(0, 0, 0, SystemInformation.HorizontalScrollBarHeight);
         AutoSize = true;
         AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         TreeRootNode = new AutomationTreeNode(this);
         TreeRootNode.TreeParentNode = null;
         TreeRootNode.Width = Width;
         BackColor = Control.DefaultBackColor;
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
      private AutomationTreeNode _treeRootNode;

      internal AutomationTreeNode TreeRootNode
      {
         get { return _treeRootNode; }
         set { _treeRootNode = value; }
      }

      internal List<AnnObjectTreeNode> SelectedItems
      {
         get { return _selectedItems; }
         set { _selectedItems = value; }
      }
      List<AnnObjectTreeNode> _selectedItems = new List<AnnObjectTreeNode>();

      private void Clear()
      {
         SuspendLayout();
         Controls.Clear();
         TreeRootNode.ChildNodes.Clear();
         ResumeLayout(true);
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

      private int _ignoreChangedCounter = 0;
      public void BeginIgnoreChanged()
      {
         _ignoreChangedCounter++;
      }
      public void EndIgnoreChanged()
      {
         _ignoreChangedCounter--;
      }

      private void _automation_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
      {
         if (_ignoreChangedCounter > 0)
            return;

         switch (e.ChangeType)
         {
            case AnnObjectChangedType.Added:
            case AnnObjectChangedType.DesignerDraw:
            case AnnObjectChangedType.Deleted:
            case AnnObjectChangedType.Paste:
            case AnnObjectChangedType.Modified:
            case AnnObjectChangedType.Metadata:
               PopulateContainer(_automation.ActiveContainer);
               break;

            case AnnObjectChangedType.DesignerEdit:
               UpdateAllMetadata();
               break;

            default:
               // Just paint
               Invalidate();
               break;
         }
      }

      private void UpdateAllMetadata()
      {
         var editObject = _automation.CurrentEditObject;
         if (editObject != null)
         {
            var selectedItems = GetSelectedItems();
            if (selectedItems != null)
            {
               foreach (var item in selectedItems)
                  item.UpdateMetadata();
            }
         }
      }

      private void _automation_CurrentDesignerChanged(object sender, EventArgs e)
      {
         UpdateSelection();
      }

      private void UpdateSelection()
      {
         SuspendLayout();

         // Sync the selection
         var editObject = _automation.CurrentEditObject;
         if (editObject != null)
         {
            var selectedItems = GetSelectedItems();

            ClearSelection();

            if (selectedItems != null)
            {
               foreach (var item in selectedItems)
               {
                  item.IsSelected = true;
                  item.Invalidate();
                  SelectedItems.Add(item);
               }
            }
         }
         else
         {
            ClearSelection();
         }
         foreach (AnnObjectTreeNode annNode in SelectedItems)
         {
            if (annNode.AnnObject.Id != AnnObject.SelectObjectId)
            {
               (annNode.TreeParentNode as PageTreeNode).ExpandPage();
            }
         }
         ResumeLayout();
      }

      private IList<AnnObjectTreeNode> GetSelectedItems()
      {
         var editObject = _automation.CurrentEditObject;
         if (editObject == null)
            return null;

         var selectionObject = editObject as AnnSelectionObject;
         var selectedItems = new List<AnnObjectTreeNode>();

         foreach (PageTreeNode page in TreeRootNode.ChildNodes)
         {
            if (page.AnnContainer != _automation.ActiveContainer)
               continue;
            // get the object
            foreach (AnnObjectTreeNode item in page.ChildNodes)
            {

               if (selectionObject == null)
               {
                  if (item.AnnObject == editObject)
                  {
                     selectedItems.Add(item);
                     break;
                  }
               }
               else
               {
                  foreach (AnnObject annObject in selectionObject.SelectedObjects)
                  {
                     if (item.AnnObject == annObject)
                        selectedItems.Add(item);
                  }
               }
            }
         }

         return selectedItems;
      }

      public void HandleAnnotationsPagesDisabledEnabled()
      {
         SuspendLayout();
         foreach (Control child in this.Controls)
         {
            if (child is PageTreeNode)
               (child as PageTreeNode).UpdateTitle();
         }
         ResumeLayout();
      }

      public void Populate()
      {
         SuspendLayout();
         Clear();

         if (_automation != null)
         {
            foreach (var annContainer in _automation.Containers)
            {
               if (annContainer.Children.Count > 0)
               {
                  PageTreeNode page = new PageTreeNode(annContainer, this);
                  TreeRootNode.ChildNodes.Add(page);
                  page.TreeParentNode = TreeRootNode;

                  foreach (var annObject in annContainer.Children)
                  {
                     if (annObject.Id != AnnObject.SelectObjectId && annObject.Id != AnnObject.None)
                     {
                        AnnObjectTreeNode annNode = new AnnObjectTreeNode(annObject, page, _automation, this);
                        page.ChildNodes.Add(annNode);
                     }
                  }

                  if (page.ChildNodes.Count > 0)
                     Controls.Add(page);
               }
            }
         }
         ResumeLayout();
      }

      public void PopulateContainer(AnnContainer annContainer)
      {
         SuspendLayout();
         List<AutomationTreeNode> pages = TreeRootNode.ChildNodes;
         PageTreeNode insertedPage = null;
         bool pageExists = false;
         if (pages.Count > 0)
         {
            foreach (PageTreeNode page in pages)
            {
               if (page.AnnContainer.PageNumber == annContainer.PageNumber)// page already exists
               {
                  pageExists = true;
                  RemoveChildsFromTree(page.ChildNodes);
                  page.ChildNodes.Clear();
                  if (annContainer.Children.Count > 0)
                  {
                     foreach (AnnObject annObject in annContainer.Children)
                     {
                        if (annObject.Id != AnnObject.SelectObjectId && annObject.Id != AnnObject.None)
                        {
                           AnnObjectTreeNode annNode = new AnnObjectTreeNode(annObject, page, _automation, this);
                           page.ChildNodes.Add(annNode);
                        }
                     }

                     if (page.ChildNodes.Count > 0 && !Controls.Contains(page))
                        Controls.Add(page);

                     if (page.IsExpanded)
                     {
                        int startingIndex = Controls.IndexOf(page);
                        AddChildsToTree(page.ChildNodes, ref startingIndex);
                     }
                  }
                  else //Empty Page
                  {
                     pages.Remove(page);
                     Controls.Remove(page);
                  }
                  break;
               }
               else if (page.AnnContainer.PageNumber > annContainer.PageNumber) // insert new page
               {
                  pageExists = true;
                  if (annContainer.Children.Count > 0)
                  {
                     insertedPage = new PageTreeNode(annContainer, this);
                     insertedPage.TreeParentNode = TreeRootNode;
                     foreach (AnnObject annObject in annContainer.Children)
                     {
                        if (annObject.Id != AnnObject.SelectObjectId && annObject.Id != AnnObject.None)
                        {
                           AnnObjectTreeNode annNode = new AnnObjectTreeNode(annObject, insertedPage, _automation, this);
                           insertedPage.ChildNodes.Add(annNode);
                        }
                     }
                     pages.Insert(pages.IndexOf(page), insertedPage);
                     Controls.Add(insertedPage);
                     Controls.SetChildIndex(insertedPage, Controls.GetChildIndex(page));
                  }
                  break;
               }
            }
         }
         if (!pageExists) //add new page
         {
            if (annContainer.Children.Count > 0)
            {
               PageTreeNode newPage = new PageTreeNode(annContainer, this);
               newPage.TreeParentNode = TreeRootNode;
               List<AutomationTreeNode> annNodes = new List<AutomationTreeNode>();
               foreach (AnnObject annObject in annContainer.Children)
               {
                  if (annObject.Id != AnnObject.SelectObjectId && annObject.Id != AnnObject.None)
                  {
                     AnnObjectTreeNode annNode = new AnnObjectTreeNode(annObject, newPage, _automation, this);
                     annNodes.Add(annNode);
                  }
               }
               newPage.ChildNodes = annNodes;
               pages.Add(newPage);
               Controls.Add(newPage);
            }
         }
         ResumeLayout();

         UpdateSelection();
      }

      internal void AddChildsToTree(List<AutomationTreeNode> nodes, ref int startingIndex)
      {
         foreach (AutomationTreeNode node in nodes)
         {
            Controls.Add(node);
            startingIndex++;
            Controls.SetChildIndex(node, startingIndex);
            if (node.IsExpanded)
            {
               AddChildsToTree(node.ChildNodes, ref startingIndex);
            }
         }
      }

      internal void RemoveChildsFromTree(List<AutomationTreeNode> nodes)
      {
         foreach (AutomationTreeNode node in nodes)
         {
            Controls.Remove(node);
            if (node.IsExpanded)
            {
               RemoveChildsFromTree(node.ChildNodes);
            }
         }
      }

      protected override void OnSizeChanged(EventArgs e)
      {
         SuspendLayout();
         TreeRootNode.Width = Width;
         ChangeChildrenWidth(TreeRootNode);
         base.OnSizeChanged(e);
         ResumeLayout();
      }
      private void ChangeChildrenWidth(AutomationTreeNode parent)
      {
         foreach (AutomationTreeNode child in parent.ChildNodes)
         {
            child.Width = TreeRootNode.Width - child.Margin.Left;
            ChangeChildrenWidth(child);
         }
      }

      internal void ClearSelection()
      {
         foreach (AnnObjectTreeNode item in SelectedItems)
         {
            item.IsSelected = false;
            item.Invalidate();
         }

         SelectedItems.Clear();
      }

      internal void AddSelectedObject(AnnObjectTreeNode node)
      {
         node.IsSelected = true;
         node.Invalidate();
         SelectedItems.Add(node);
         AnnObjectCollection annObjects = new AnnObjectCollection();
         foreach (AnnObjectTreeNode item in SelectedItems)
         {
            annObjects.Add(item.AnnObject);
         }
         if (_imageViewer != null && _automation != null)
         {
            var invalidRect = LeadRectD.Empty;
            foreach (AnnObject annObject in annObjects)
            {
               if (annObject != null)
                  invalidRect = LeadRectD.UnionRects(invalidRect, _automation.GetObjectInvalidateRect(annObject));
            }
            _automation.ActiveContainer = ((PageTreeNode)node.TreeParentNode).AnnContainer;
            _automation.SelectObjects(annObjects);
            _imageViewer.EnsureBoundsVisible(invalidRect);
         }
      }

      //To remove flicker when add/remove controls from tree
      public static void SetDoubleBuffered(System.Windows.Forms.Control c)
      {
         if (System.Windows.Forms.SystemInformation.TerminalServerSession)
            return;
         PropertyInfo propertyInfo = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
         propertyInfo.SetValue(c, true, null);
      }

      protected override CreateParams CreateParams
      {
         get
         {
            CreateParams createParams = base.CreateParams;
            createParams.ExStyle |= 0x02000000;
            return createParams;
         }
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (_automation != null)
               Automation = null;
         }
         base.Dispose(disposing);
      }
   }
}
