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

using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    public partial class Page5 : UserControl
    {
        private Globals _globals;

        public Page5(ref Globals pGlobals)
        {
            InitializeComponent();

            _globals = pGlobals;
        }

        private void Page5_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateListAndTree();
            }
        }

        /*
         * When the user selects an element tree node, it will update the textbox with the element's value
         */
        private void treeDSResult_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((MyTreeNode)e.Node).m_Element != null)
            {
               txtElementValue.Text = ((MyTreeNode)e.Node).m_DS.GetConvertValue(((MyTreeNode)e.Node).m_Element);
            }
            else
            {
                txtElementValue.Text = "";
            }
        }

        private void Page5_Load(object sender, EventArgs e)
        {
            try
            {
                lstEmptyTags.SmallImageList = _globals.m_IconImageList;
                lstEmptyTags.SetTreeView(ref treeDSResult);
                treeDSResult.ImageList = _globals.m_IconImageList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * When a ListView item is selected, the corresponding node in the treeview will also get selected
         */
        private void lstEmptyTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmptyTags.SelectedItems.Count > 0)
            {
                MyListViewItem selItem = (MyListViewItem)lstEmptyTags.SelectedItems[0];
                MyTreeNode selNode = (MyTreeNode)treeDSResult.SelectedNode;

                try
                {
                    if ((selNode != null) && (selNode.m_Element != null))
                    {

                      if (!(selItem.m_Element.Tag == selNode.m_Element.Tag))

                        {
                            treeDSResult.SelectNodeByElement(selItem.m_Element);
                        }
                    }
                    else
                    {
                        treeDSResult.SelectNodeByElement(selItem.m_Element);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /*
         * When a list view item is double-clicked, the user can modify the element's data
         */
        private void lstEmptyTags_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UpdateElement(((MyListViewItem)lstEmptyTags.SelectedItems[0]).m_Element);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Clears and populates the tree and list view based on the global dataset.
         * Called each time the dataset on which the tree and list view get their information from.
         */
        private void UpdateListAndTree()
        {
            try
            {
                treeDSResult.Nodes.Clear();
                lstEmptyTags.Items.Clear();
                treeDSResult.BuildTreeFromDataset(_globals.m_DS, false);
                lstEmptyTags.Update(_globals.m_DS, _globals.m_nClass);
                _globals.m_bMandatoryElementsFilled = (lstEmptyTags.Items.Count == 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /*
         * When a tree view item with an element is double-clicked, the user can modify the element's data
         */
        private void treeDSResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ((treeDSResult.SelectedNode != null) && (((MyTreeNode)treeDSResult.SelectedNode).m_Element != null))
                {

                    if (!IsImageElement(((MyTreeNode)treeDSResult.SelectedNode).m_Element))
                    {
                        try
                        {
                            UpdateElement(((MyTreeNode)treeDSResult.SelectedNode).m_Element);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Modifys an element from a MyTreeNode or a MyListViewItem, updates the global dataset
         *   and redisplays the dataset in the tree and list views.
         */
        private void UpdateElement(DicomElement element)
        {
            try
            {
                EditValueDlg dlgEdit = new EditValueDlg(_globals.m_DS, element);

                if (dlgEdit.ShowDialog() == DialogResult.OK)
                {
                    int count;

                    count = dlgEdit.listBoxValues.Items.Count;
                    if (count > 0)
                    {
                        string values = "";

                        foreach (string item in dlgEdit.listBoxValues.Items)
                        {
                            if (values.Length > 0)
                                values += @"\";

                            values += item;
                        }
                        _globals.m_DS.FreeElementValue(element);
                        
                        if (Utils.IsAscii(values))
                           _globals.m_DS.SetConvertValue(element, values, count);
                        else
                           _globals.m_DS.SetStringValue(element, values, DicomCharacterSetType.UnicodeInUtf8);
                    }
                    else
                    {
                        _globals.m_DS.FreeElementValue(element);
                    }

                    UpdateListAndTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * Determines whether or not the element is an image
         */
        private bool IsImageElement(DicomElement element)
        {
            try
            {
                if (element != null)
                {
                    DicomTag tag;

                    tag = DicomTagTable.Instance.Find(element.Tag);


                    
                    // Pixel Data tags will not be displayed in our list box instead we will load
                    //  them in the image viewer
                    if (tag != null && tag.Name.IndexOf("Pixel Data") == -1)
                    {
                        element = _globals.m_DS.GetParentElement(element);
                        if (element != null)
                        {

                           tag = DicomTagTable.Instance.Find(element.Tag);


                            if (tag != null && tag.Name.IndexOf("Pixel Data") != -1)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }
    }
}
