// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;

namespace CSDicomDirLinqDemo.UI
{
    public static class TreeviewExtensions
    {
        public static void LoadDirectory(this TreeView treeview, DicomDataSet ds)
        {
            FillTreeKeys(treeview,ds,null, null);
        }

        private static void FillTreeKeys(TreeView treeview,DicomDataSet ds,DicomElement ParentKeyElement, TreeNode ParentNode)
        {
            DicomElement CurrentKeyElement, CurrentKeyChildElement;
            TreeNode node;
            string name;
            string temp = "";

            if (ParentKeyElement == null)
            {
                CurrentKeyElement = ds.GetFirstKey(null, true);
            }
            else
            {
                CurrentKeyElement = ds.GetChildKey(ParentKeyElement);
            }

            // Add the keys to the TreeView
            while (CurrentKeyElement != null)
            {
                // Get key name
                temp = ds.GetKeyValueString(CurrentKeyElement);

                if ((temp != null) || (temp == ""))
                {
                    name = temp;
                }
                else
                {
                    name = "UNKNOWN";
                }

                // Add at root or beneath its parent
                if (ParentNode == null)
                {
                    node = treeview.Nodes.Add(name);
                }
                else
                {
                    node = ParentNode.Nodes.Add(name);
                }

                node.Tag = CurrentKeyElement;

                // Add the current key's non-key child elements
                CurrentKeyChildElement = ds.GetChildElement(CurrentKeyElement, true);
                while (CurrentKeyChildElement != null)
                {
                    FillKeySubTree(treeview,ds,CurrentKeyChildElement, node, false);
                    CurrentKeyChildElement = ds.GetNextElement(CurrentKeyChildElement, true, true);
                }


                // Recursively add child keys
                if (ds.GetChildKey(CurrentKeyElement) != null)
                {
                    FillTreeKeys(treeview,ds,CurrentKeyElement, node);
                }

                CurrentKeyElement = ds.GetNextKey(CurrentKeyElement, true);
            }
        }

        private static void FillKeySubTree(TreeView treeview, DicomDataSet ds, DicomElement element, TreeNode ParentNode, bool recurse)
        {
            TreeNode node;
            string name;
            string temp = "";
            DicomElement tempElement;
            DicomTag tag;

            // Get the tag's numerical display value (XXXX:XXXX)
            tag = DicomTagTable.Instance.Find(element.Tag);
            temp = string.Format("{0:x4}:{1:x4} - ", element.Tag.GetGroup(), element.Tag.GetElement());

            // Get the tag's name
            if (tag == null)
                name = "Item";
            else
                name = tag.Name;

            temp = temp + name;

            // Add the node either on the root or beneath its parent
            if (ParentNode != null)
            {
                node = ParentNode.Nodes.Add(temp);
            }
            else
            {
                node = treeview.Nodes.Add(temp);
            }

            node.Tag = element;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            // If the element has children, recursively add them
            tempElement = ds.GetChildElement(element, true);
            if (tempElement != null)
            {
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                FillKeySubTree(treeview,ds,tempElement, node, true);
            }

            if (recurse)
            {
                tempElement = ds.GetNextElement(element, true, true);
                if (tempElement != null)
                {
                    FillKeySubTree(treeview,ds,tempElement, ParentNode, true);
                }
            }
        }
    }
}
