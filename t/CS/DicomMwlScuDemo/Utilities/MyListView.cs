// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools.Dicom;


namespace DicomDemo
{
    class MyListView : ListView
    {
        private MyTreeView m_TreeView;

        public void SetTreeView(ref MyTreeView tv)
        {
            m_TreeView = tv;
        }

        /*
         * Parses through the data set, finds the mandatory type 1 elements, and adds them
         *   to the ListView.
         */
        public void Update(MyDicomDataSet ds, DicomClassType nClass)
        {
            try
            {
                if (ds == null)
                    return;

                MyListViewItem currentItem;
                string strTag = "";
                string strDesc= "";

                DicomElement element;
                element = ds.GetFirstEmptyElementType1(nClass, ref strTag, ref strDesc);
                while (element != null)
                {
                    currentItem = new MyListViewItem();
                    currentItem.Text = strTag;
                    currentItem.SubItems.Add(strDesc);
                    currentItem.SubItems.Add("");
                    currentItem.m_Element = element;
                    currentItem.ImageIndex = (int)MyIconIndex.Missing;

                    MyTreeNode treeNode = m_TreeView.FindNodeByElement(element, null, null);
                    if (treeNode != null)
                    {
                        m_TreeView.FindNodeByElement(element, null, null).ImageIndex = (int)MyIconIndex.Missing;
                        m_TreeView.FindNodeByElement(element, null, null).SelectedImageIndex = (int)MyIconIndex.Missing;
                        Items.Add(currentItem);
                    }

                    element = ds.GetNextEmptyElementType1(element, nClass, ref strTag, ref strDesc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
