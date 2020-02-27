// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.MedicalViewer;

namespace MedicalViewerLayoutDemo
{
    public partial class OverlapDialog : Form
    {
        private List<ListBoxCellItem> _Items;

        public List<ListBoxCellItem> Items
        {
            get
            {
                return _Items;
            }
        }
        public OverlapDialog(MedicalViewerCellCollection<MedicalViewerBaseCell> cells)
        {
            List<ListBoxCellItem> lbc = new List<ListBoxCellItem>();
            InitializeComponent();

            foreach(MedicalViewerCell cell in cells)
            {
                lbc.Add(new ListBoxCellItem(cell));
            }
            lbc.Sort(new ListBoxCellComparer());

            foreach(ListBoxCellItem item in lbc)
            {
                listBoxCells.Items.Add(item);                
            }
            UnSelectCells();
        }

        private void UnSelectCells()
        {
            foreach (ListBoxCellItem item in listBoxCells.Items)
            {
                item.Cell.Selected = false;
            }
        }

        private void listBoxCells_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxCellItem selectedItem = listBoxCells.SelectedItem as ListBoxCellItem;

            buttonMoveUp.Enabled = listBoxCells.SelectedIndex != 0 && listBoxCells.Items.Count > 1;
            buttonMoveDown.Enabled = listBoxCells.SelectedIndex != listBoxCells.Items.Count - 1 &&
                                     listBoxCells.Items.Count != 0;
            foreach(ListBoxCellItem item in listBoxCells.Items)
            {
                item.Cell.Selected = (item == selectedItem);
            }            
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            Int32 iSelectedIndex = listBoxCells.SelectedIndex;
            ListBoxCellItem sSelectedItem = listBoxCells.SelectedItem as ListBoxCellItem;           
            
            listBoxCells.Items.RemoveAt(iSelectedIndex);
            listBoxCells.Items.Insert(iSelectedIndex-1, sSelectedItem);
            listBoxCells.SelectedIndex = iSelectedIndex - 1;
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            Int32 iSelectedIndex = listBoxCells.SelectedIndex;
            ListBoxCellItem sSelectedItem = listBoxCells.SelectedItem as ListBoxCellItem;

            listBoxCells.Items.RemoveAt(iSelectedIndex);
            listBoxCells.Items.Insert(iSelectedIndex + 1, sSelectedItem);
            listBoxCells.SelectedIndex = iSelectedIndex + 1;
        }

        private void OverlapDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                _Items = new List<ListBoxCellItem>();

                foreach(ListBoxCellItem item in listBoxCells.Items)
                {
                    _Items.Add(item);
                }
            }
            UnSelectCells();
        }        
    }

    public class ListBoxCellComparer : IComparer<ListBoxCellItem>
    {

        #region IComparer<ListBoxCellItem> Members

        public int Compare(ListBoxCellItem x, ListBoxCellItem y)
        {
            return x.Cell.OverlapPriority.CompareTo(y.Cell.OverlapPriority);
        }

        #endregion
    }

    public class ListBoxCellItem
    {
        private MedicalViewerCell _Cell;

        public MedicalViewerCell Cell
        {
            get
            {
                return _Cell;
            }
        }

        public ListBoxCellItem(MedicalViewerCell cell)
        {
            _Cell = cell;
        }

        public override string ToString()
        {
            return "Image Box " + _Cell.Tag;
        }
    }
}
