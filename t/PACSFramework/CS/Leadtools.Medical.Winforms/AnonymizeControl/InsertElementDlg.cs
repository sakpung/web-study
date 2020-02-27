// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using System.Reflection;

namespace Leadtools.Medical.Winforms.Anonymize
{
   public partial class InsertElementDlg : Form
   {

      //private bool _Sequence = false;
      //private bool _Child = true;


      private readonly ListViewColumnSorter _Sorter = new ListViewColumnSorter();
      private readonly List<long> _Excludes = new List<long>();
      private readonly BackgroundWorker _SearchWorker = new BackgroundWorker();
      private Thread _TagThread = null;


      //public bool Sequence
      //{
      //   get
      //   {
      //      return _Sequence;
      //   }
      //}

      //public bool Child
      //{
      //   get
      //   {
      //      return _Child;
      //   }
      //}

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

      public static void SetDoubleBuffered(System.Windows.Forms.Control control)
      {
         // set instance non-public property with name "DoubleBuffered" to true
         typeof(System.Windows.Forms.Control).InvokeMember("DoubleBuffered",
             BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
             null, control, new object[] { true });
      }


      private void InsertElementDlg_Load(object sender, System.EventArgs e)
      {
         SetDoubleBuffered(listViewTags);
         listViewTags.ListViewItemSorter = _Sorter;
         _SearchWorker.DoWork += new DoWorkEventHandler(SearchWorker_DoWork);
         _SearchWorker.WorkerSupportsCancellation = true;
         LoadTags();
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
                      tag.Code.GetElement() != 0)
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
            lastIndex = foundItem.Index + 1;
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
         _Sorter.ShowHeaderIcon(listViewTags, e.Column, _Sorter.Order);
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
         if (_TagThread != null && _TagThread.IsAlive)
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
