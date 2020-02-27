// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using System.Collections.Generic;
using System.Threading;

namespace DicomAnonymizer
{
    /// <summary>
    /// Summary description for InsertElementDlg.
    /// </summary>
    public class InsertElementDlg : Form
    {
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.CheckBox checkBoxChild;
        private System.Windows.Forms.CheckBox checkBoxFolder;
       
        private bool _Sequence = false;
        private bool _Child = true;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private TagListView listViewTags;
        private ColumnHeader columnHeaderTag;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderVr;
        
        private TextBox textBoxSearch;

        private ListViewColumnSorter _Sorter = new ListViewColumnSorter();
        private List<long> _Excludes = new List<long>();
        private BackgroundWorker _SearchWorker = new BackgroundWorker();
        private Thread _TagThread = null;
        private Button buttonSearch;
        private Label label2;

        public bool Sequence
        {
            get
            {
                return _Sequence;
            }
        }

        public bool Child
        {
            get
            {
                return _Child;
            }
        }

        private List<long> _Tags = new List<long>();

        public List<long> Tags
        {
            get
            {
                return _Tags;
            }
        }

        public InsertElementDlg(List<long> excludedTags)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            if (excludedTags != null && excludedTags.Count > 0)
               _Excludes.AddRange(excludedTags);
        }        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           this.label1 = new System.Windows.Forms.Label();
           this.buttonCancel = new System.Windows.Forms.Button();
           this.buttonOK = new System.Windows.Forms.Button();
           this.checkBoxChild = new System.Windows.Forms.CheckBox();
           this.checkBoxFolder = new System.Windows.Forms.CheckBox();
           this.textBoxSearch = new System.Windows.Forms.TextBox();
           this.buttonSearch = new System.Windows.Forms.Button();
           this.listViewTags = new DicomAnonymizer.TagListView();
           this.columnHeaderTag = new System.Windows.Forms.ColumnHeader();
           this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
           this.columnHeaderVr = new System.Windows.Forms.ColumnHeader();
           this.label2 = new System.Windows.Forms.Label();
           this.SuspendLayout();
           // 
           // label1
           // 
           this.label1.Location = new System.Drawing.Point(10, 8);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(100, 16);
           this.label1.TabIndex = 0;
           this.label1.Text = "Tag:";
           // 
           // buttonCancel
           // 
           this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.buttonCancel.Location = new System.Drawing.Point(539, 428);
           this.buttonCancel.Name = "buttonCancel";
           this.buttonCancel.Size = new System.Drawing.Size(75, 23);
           this.buttonCancel.TabIndex = 2;
           this.buttonCancel.Text = "&Cancel";
           // 
           // buttonOK
           // 
           this.buttonOK.Location = new System.Drawing.Point(458, 428);
           this.buttonOK.Name = "buttonOK";
           this.buttonOK.Size = new System.Drawing.Size(75, 23);
           this.buttonOK.TabIndex = 3;
           this.buttonOK.Text = "&OK";
           this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
           // 
           // checkBoxChild
           // 
           this.checkBoxChild.Checked = true;
           this.checkBoxChild.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxChild.Location = new System.Drawing.Point(324, 415);
           this.checkBoxChild.Name = "checkBoxChild";
           this.checkBoxChild.Size = new System.Drawing.Size(104, 24);
           this.checkBoxChild.TabIndex = 4;
           this.checkBoxChild.Text = "Insert as child";
           this.checkBoxChild.Visible = false;
           this.checkBoxChild.CheckedChanged += new System.EventHandler(this.checkBoxChild_CheckedChanged);
           // 
           // checkBoxFolder
           // 
           this.checkBoxFolder.Location = new System.Drawing.Point(324, 438);
           this.checkBoxFolder.Name = "checkBoxFolder";
           this.checkBoxFolder.Size = new System.Drawing.Size(128, 24);
           this.checkBoxFolder.TabIndex = 5;
           this.checkBoxFolder.Text = "Element is a folder";
           this.checkBoxFolder.Visible = false;
           this.checkBoxFolder.CheckedChanged += new System.EventHandler(this.checkBoxFolder_CheckedChanged);
           // 
           // textBoxSearch
           // 
           this.textBoxSearch.AcceptsReturn = true;
           this.textBoxSearch.Location = new System.Drawing.Point(313, 7);
           this.textBoxSearch.Name = "textBoxSearch";
           this.textBoxSearch.Size = new System.Drawing.Size(227, 20);
           this.textBoxSearch.TabIndex = 7;
           this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
           this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
           this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
           // 
           // buttonSearch
           // 
           this.buttonSearch.Location = new System.Drawing.Point(540, 4);
           this.buttonSearch.Name = "buttonSearch";
           this.buttonSearch.Size = new System.Drawing.Size(75, 23);
           this.buttonSearch.TabIndex = 8;
           this.buttonSearch.Text = "Search";
           this.buttonSearch.UseVisualStyleBackColor = true;
           this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
           // 
           // listViewTags
           // 
           this.listViewTags.CheckBoxes = true;
           this.listViewTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTag,
            this.columnHeaderName,
            this.columnHeaderVr});
           this.listViewTags.FullRowSelect = true;
           this.listViewTags.HideSelection = false;
           this.listViewTags.Location = new System.Drawing.Point(13, 28);
           this.listViewTags.Name = "listViewTags";
           this.listViewTags.Size = new System.Drawing.Size(601, 381);
           this.listViewTags.TabIndex = 6;
           this.listViewTags.UseCompatibleStateImageBehavior = false;
           this.listViewTags.View = System.Windows.Forms.View.Details;
           this.listViewTags.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewTags_ItemChecked);
           this.listViewTags.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewTags_ItemCheck);
           this.listViewTags.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewTags_ColumnClick);
           // 
           // columnHeaderTag
           // 
           this.columnHeaderTag.Text = "Tag";
           this.columnHeaderTag.Width = 119;
           // 
           // columnHeaderName
           // 
           this.columnHeaderName.Text = "Name";
           this.columnHeaderName.Width = 328;
           // 
           // columnHeaderVr
           // 
           this.columnHeaderVr.Text = "VR";
           this.columnHeaderVr.Width = 150;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(263, 14);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(44, 13);
           this.label2.TabIndex = 9;
           this.label2.Text = "Search:";
           // 
           // InsertElementDlg
           // 
           this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
           this.CancelButton = this.buttonCancel;
           this.ClientSize = new System.Drawing.Size(626, 463);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.buttonSearch);
           this.Controls.Add(this.textBoxSearch);
           this.Controls.Add(this.listViewTags);
           this.Controls.Add(this.checkBoxFolder);
           this.Controls.Add(this.checkBoxChild);
           this.Controls.Add(this.buttonOK);
           this.Controls.Add(this.buttonCancel);
           this.Controls.Add(this.label1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "InsertElementDlg";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Insert Element";
           this.Load += new System.EventHandler(this.InsertElementDlg_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsertElementDlg_FormClosing);
           this.ResumeLayout(false);
           this.PerformLayout();

        }
        #endregion

        private void InsertElementDlg_Load(object sender, System.EventArgs e)
        {
            listViewTags.ListViewItemSorter = _Sorter;
            _SearchWorker.DoWork += new DoWorkEventHandler(SearchWorker_DoWork);
            _SearchWorker.WorkerSupportsCancellation = true;
            LoadTags();            
        }       

        private void checkBoxChild_CheckedChanged(object sender, System.EventArgs e)
        {
            _Child = checkBoxChild.Checked;
        }

        private void checkBoxFolder_CheckedChanged(object sender, System.EventArgs e)
        {
            _Sequence = checkBoxFolder.Checked;
        }        

        private void LoadTags()
        {
            DicomTag tag;
            _TagThread = new Thread(() =>
            {
                try
                {
                    tag = DicomTagTable.Instance.GetFirst();
                    while (tag != null)
                    {
                        if (tag.Code != DicomTag.DataSetTrailingPadding &&
                           tag.Code != DicomTag.ItemDelimitationItem &&
                           tag.Code != DicomTag.SequenceDelimitationItem &&
                            tag.Code != DicomTag.CommandGroupLength && 
                            tag.Code.GetElement()!=0)
                        {
                            ListViewItem item = new ListViewItem();

                            item.Text = String.Format("({0:X4},{1:X4})", tag.Code.GetGroup(), tag.Code.GetElement());
                            item.SubItems.Add(tag.Name);
                            item.SubItems.Add(tag.VR.ToString());
                            item.Tag = tag.Code;
                            if (_Excludes.Contains(tag.Code))
                            {
                                item.ForeColor = SystemColors.InactiveCaptionText;
                                item.Font = new Font(item.Font, FontStyle.Strikeout);
                            }
                            SynchronizedInvoke(delegate
                            {
                                listViewTags.Items.Add(item);
                                Application.DoEvents();
                            });
                        }
                        Thread.Sleep(1);
                        tag = DicomTagTable.Instance.GetNext(tag);
                    }
                }
                catch { }
            });
            
            _TagThread.Start();
        }

        public void SynchronizedInvoke(MethodInvoker del)
        {
            if (InvokeRequired)
                Invoke(del, null);
            else
                del();
        }                

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            _Sorter.ShowHeaderIcon(listViewTags, _Sorter.SortColumn, SortOrder.None);
            _Sorter.Order = SortOrder.None;
            listViewTags.Sort();            
            SearchListView(listViewTags, textBoxSearch.Text);           
        }        

        private void SearchListView(ListView listView, string txtFind)
        {            
            int lastIndex = 0;
            ListViewItem foundItem = null;

            listView.SelectedItems.Clear();
            foundItem = foundItem = listView.FindItemWithText(txtFind, true, lastIndex);
            while (foundItem != null)
            {
                lastIndex = foundItem.Index+1;
                //listView.Items[foundItem.Index].Selected = true;
                listView.Items.Remove(foundItem);
                listView.Items.Insert(0, foundItem);
                if (lastIndex >= listView.Items.Count)
                   foundItem = null;
                else
                  foundItem = listView.FindItemWithText(txtFind, true, lastIndex);                
            }            
        }

        private void listViewTags_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            long tag = (long)e.Item.Tag;

            if (e.Item.Checked == true)
            {
                if (!_Tags.Contains(tag))
                    _Tags.Add(tag);
            }
            else
            {
                if (_Tags.Contains(tag))
                    _Tags.Remove(tag);
            }
        }

        private void listViewTags_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _Sorter.ShowHeaderIcon(listViewTags, _Sorter.SortColumn, SortOrder.None);
            if (e.Column == _Sorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_Sorter.Order == SortOrder.Ascending)
                {
                    _Sorter.Order = SortOrder.Descending;
                }
                else
                {
                    _Sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _Sorter.SortColumn = e.Column;
                _Sorter.Order = SortOrder.Ascending;
            }
            listViewTags.Sort();
            _Sorter.ShowHeaderIcon(listViewTags, e.Column,_Sorter.Order);
        }

        private void listViewTags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            long tag = (long)listViewTags.Items[e.Index].Tag;

            if (e.NewValue == CheckState.Checked && _Excludes.Contains(tag))
                e.NewValue = CheckState.Unchecked;
        }

        void SearchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int lastIndex = 0;
            ListViewItem foundItem = null;
            string txtFind = e.Argument as string;
            BackgroundWorker bg = sender as BackgroundWorker;

            SynchronizedInvoke(delegate
            {
                listViewTags.SelectedItems.Clear();
                foundItem = listViewTags.FindItemWithText(txtFind, true, lastIndex);
            });
            while (foundItem != null)
            {
                if (bg.CancellationPending)
                    break;
                lastIndex = foundItem.Index + 1;
                SynchronizedInvoke(delegate
                {
                    listViewTags.Items[foundItem.Index].Selected = true;
                    listViewTags.Items.Remove(foundItem);
                    listViewTags.Items.Insert(0, foundItem);
                    foundItem = foundItem = listViewTags.FindItemWithText(txtFind, true, lastIndex);
                });
            }    
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {           
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _Sorter.ShowHeaderIcon(listViewTags, _Sorter.SortColumn, SortOrder.None);
                _Sorter.Order = SortOrder.None;
                listViewTags.Sort();
                SearchListView(listViewTags, textBoxSearch.Text); 
                e.Handled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InsertElementDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_TagThread!=null && _TagThread.IsAlive)
            {
                _TagThread.Abort();
                _TagThread.Join();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
           buttonSearch.Enabled = textBoxSearch.Text.Length > 0;
        }        
    }

    internal class TagListView : ListView
    {
        public TagListView()
        {
            //Activate double buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
