// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    public class MyTreeView : TreeView
    {

        public MyTreeView() : base()
        {
            // Do nothing extra
        }

        public MyTreeNode GetSelectedRootNode()
        {
            // Get the root parent node of the currently selected node
            MyTreeNode RootNode = (MyTreeNode)SelectedNode;

            try
            {

                while (RootNode.Parent != null)
                {
                    RootNode = (MyTreeNode)RootNode.Parent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }

            return RootNode;
        }

        /*
         * This function takes a DicomDataSet and builds the tree.  
         * If IsMWLDS == true then it will create a new root node because there are likely going to be 
         *   more than one datasets in this tree
         * If IsMWLDS == false then all of the IOD Class nodes will be put into the root level of the tree
         *   because there is only expected to be one dataset in the tree
         */
        public delegate void BuildTreeFromDatasetDelegate(DicomDataSet ds, bool IsMWLDS);
        public void BuildTreeFromDataset(DicomDataSet ds, bool IsMWLDS)
        {
           if (Globals._closing == true || this.Disposing || this.IsDisposed)
              return;
            if (InvokeRequired)
            {
                Invoke(new BuildTreeFromDatasetDelegate(BuildTreeFromDataset), ds, IsMWLDS);
            }
            else
            {
                try
                {
                    TreeNodeCollection IODClassNodes;
                    if (IsMWLDS)
                    {
                       // Add a root level node since there could be multiple MWL datasets to be displayed
                       string parentNodeString = String.Format(
                           "{0:D3} Modality Work List - {1} ",
                           (Nodes.Count + 1),
                           Utils.GetStringValue(ds, DemoDicomTags.Modality, false));
                       MyTreeNode rootNode = new MyTreeNode(parentNodeString, ds);
                       Nodes.Add(rootNode);
                       rootNode.ImageIndex = (int)MyIconIndex.Worklist;
                       rootNode.SelectedImageIndex = (int)MyIconIndex.Worklist;
                       IODClassNodes = rootNode.Nodes;
                    }
                    else
                    {
                        // Use the tree's root for IOD classes
                        IODClassNodes = Nodes;
                    }
                    
                    // Insert nodes for IOD classes
                    for (int i = 0; i < ds.ModuleCount; i++)
                    {
                        DicomModule dm = ds.FindModuleByIndex(i);
                        DicomIod dIod = DicomIodTable.Instance.FindModule(ds.InformationClass, dm.Type);

                        if (dIod != null)
                        {
                            IODClassNodes.Add(
                                new MyTreeNode(dIod.Name, ds, dIod));
                            IODClassNodes[i].ImageIndex = (int)MyIconIndex.Folder;
                            IODClassNodes[i].SelectedImageIndex = (int)MyIconIndex.Folder;
                        }
                        else
                        {
                            IODClassNodes.Add(
                                new MyTreeNode("UNKNOWN"));
                            IODClassNodes[i].ImageIndex = (int)MyIconIndex.Missing;
                            IODClassNodes[i].SelectedImageIndex = (int)MyIconIndex.Missing;
                        }

                        // Insert nodes for the elements within the current IOD class
                        for (int j = 0; j < dm.Elements.Length; j++)
                        {
                            // Determine the element tag
                            DicomTag tag;
                            long tagValue;
#if (LTV15_CONFIG)

                            if (dm.Elements[j].Tag != DemoDicomTags.Undefined)
                            {
                                tag = DicomTagTable.Instance.Find(dm.Elements[j].Tag);
                                tagValue = (long)dm.Elements[j].Tag;
                            }
                            else
                            {
                                tag = DicomTagTable.Instance.Find(dm.Elements[j].UserTag);
                                tagValue = dm.Elements[j].UserTag;
                            }
#else
                            tag = DicomTagTable.Instance.Find(dm.Elements[j].Tag);
                            tagValue = (long)dm.Elements[j].Tag;
#endif
                            // Add new element TreeNode
                            IODClassNodes[i].Nodes.Add(
                                new MyTreeNode(String.Format("{0:X4}:{1:X4} - {2}",
                                    Utils.GetGroup(tagValue),
                                    Utils.GetElement(tagValue),
                                    tag.Name),
                                ds,
                                dm.Elements[j]));

                            IODClassNodes[i].Nodes[j].ImageIndex = (int)MyIconIndex.Element;
                            IODClassNodes[i].Nodes[j].SelectedImageIndex = (int)MyIconIndex.Element;

                            // Check to see if the element has children
                            if (ds.GetChildElement(dm.Elements[j], true) != null)
                            {
                                IODClassNodes[i].Nodes[j].ImageIndex = (int)MyIconIndex.Sequence;
                                IODClassNodes[i].Nodes[j].SelectedImageIndex = (int)MyIconIndex.Sequence;

                                // Recursively add children of this element
                                AddChildrenOfElement(ds, (MyTreeNode)IODClassNodes[i].Nodes[j], dm.Elements[j]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /*
         * Recursively add children of an element TreeNode
         */
        private void AddChildrenOfElement(DicomDataSet ds, MyTreeNode parentNode, DicomElement parentElement)
        {
            try
            {
                DicomElement currentElement = ds.GetChildElement(parentElement, true);
                int parentNodeChildCount = 0;
                while (currentElement != null)
                {
                    DicomIod dIod = DicomIodTable.Instance.Find(null, parentElement.Tag, DicomIodType.Element, false);

                    // Determine the element tag
                    DicomTag tag;
                    long tagValue;
#if (LTV15_CONFIG)

                    if (currentElement.Tag != DemoDicomTags.Undefined)
                    {
                        tag = DicomTagTable.Instance.Find(currentElement.Tag);
                        tagValue = (long)currentElement.Tag;
                    }
                    else
                    {
                        tag = DicomTagTable.Instance.Find(currentElement.UserTag);
                        tagValue = currentElement.UserTag;
                    }
#else
                    tag = DicomTagTable.Instance.Find(currentElement.Tag);
                    tagValue = (long)currentElement.Tag;
#endif
                    // Add new element TreeNode
                    parentNode.Nodes.Add(
                        new MyTreeNode(String.Format("{0:X4}:{1:X4} - {2}",
                            Utils.GetGroup(tagValue),
                            Utils.GetElement(tagValue),
                            tag.Name),
                        ds,
                        currentElement));

                    // Check to see if the element has children
                    if (ds.GetChildElement(currentElement, true) != null)
                    {
                        parentNode.Nodes[parentNodeChildCount].ImageIndex = (int)MyIconIndex.Sequence;
                        parentNode.Nodes[parentNodeChildCount].SelectedImageIndex = (int)MyIconIndex.Sequence;

                        // Recursively add children of this element
                        AddChildrenOfElement(ds, (MyTreeNode)parentNode.Nodes[parentNode.Nodes.Count - 1], currentElement);
                    }

                    currentElement = ds.GetNextElement(currentElement, true, true);
                    parentNodeChildCount++;
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Finds and selects the TreeNode with the specified DicomElement.
         */
        public void SelectNodeByElement(DicomElement element)
        {
            try
            {
                MyTreeNode nodeToSelect = FindNodeByElement(element, null, null);

                if (nodeToSelect != null)
                    SelectedNode = nodeToSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Recursively search the tree for the a node with the specified DicomElement.
         */
        public MyTreeNode FindNodeByElement(DicomElement element, MyTreeNode parentNode, MyTreeNode foundNode)
        {
            if (Nodes.Count == 0)
                return null;
            MyTreeNode currentNode;

            try
            {
                if (parentNode == null)
                {
                     currentNode = (MyTreeNode)Nodes[0];
                }
                else
                     currentNode = (MyTreeNode)parentNode.Nodes[0];

                
                while ((currentNode != null) && (foundNode == null))
                {
                    if (currentNode.m_Element != null)
                    {
                       //The current node is an element
#if (LTV15_CONFIG)
                       if ((currentNode.m_Element.Tag == element.Tag) && (currentNode.m_Element.UserTag == element.UserTag))
#else
                       if (currentNode.m_Element.Tag == element.Tag)
#endif
                        {
                            // We've found the node
                            foundNode = currentNode;
                        }
                        else if (currentNode.Nodes.Count > 0)
                        {
                            // We didn't find the node and this node has children
                            foundNode = FindNodeByElement(element, currentNode, null);
                            currentNode = (MyTreeNode)currentNode.NextNode;
                        }
                        else
                        {
                            // We didn't find the node and there aren't any children
                            currentNode = (MyTreeNode)currentNode.NextNode;
                        }
                    }
                    else
                    {
                        //the current node is not an element
                        if (currentNode.Nodes.Count > 0)
                        {
                            // We didn't find the node and this node has children
                            foundNode = FindNodeByElement(element, currentNode, null);
                            currentNode = (MyTreeNode)currentNode.NextNode;
                        }
                        else
                        {
                            // We didn't find the node and there aren't any children
                            currentNode = (MyTreeNode)currentNode.NextNode;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }

            return foundNode;
        }
    }
}
