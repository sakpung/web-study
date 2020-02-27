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
using System.IO;

namespace SharePointDemo
{
   public partial class ServerControl : UserControl
   {
      public ServerControl()
      {
         InitializeComponent();

         // Initialize the list view sorter
         _listView.ListViewItemSorter = new FileListViewColumnSorter();

         _refreshToolStripButton.Enabled = false;
         _downloadToolStripButton.Enabled = false;
      }

      protected override void OnLoad(EventArgs e)
      {
         // Resize the second column to fill the client area
         _listView.Columns[1].Width = _listView.ClientSize.Width - _listView.Columns[0].Width;
         base.OnLoad(e);
      }

      private void _listView_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         // Sort
         FileListViewColumnSorter sorter = _listView.ListViewItemSorter as FileListViewColumnSorter;
         sorter.Sort(_listView, e.Column);
      }

      private void _listView_SelectedIndexChanged(object sender, EventArgs e)
      {
         _downloadToolStripButton.Enabled = _listView.SelectedItems.Count > 0;
      }

      private void _listView_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         if(_downloadToolStripButton.Enabled)
            _downloadToolStripButton.PerformClick();
      }

      private void _listView_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == '\r' && _downloadToolStripButton.Enabled)
            _downloadToolStripButton.PerformClick();
      }

      protected override void OnTextChanged(EventArgs e)
      {
         _titleLabel.Text = Text;

         base.OnTextChanged(e);
      }

      public event EventHandler<EventArgs> ServerClicked;

      private void _serverToolStripButton_Click(object sender, EventArgs e)
      {
         if(ServerClicked != null)
            ServerClicked(this, e);
      }

      public event EventHandler<EventArgs> RefreshClicked;

      private void _refreshToolStripButton_Click(object sender, EventArgs e)
      {
         if(RefreshClicked != null)
            RefreshClicked(this, e);
      }

      public event EventHandler<EventArgs> DownloadClicked;

      private void _downloadToolStripButton_Click(object sender, EventArgs e)
      {
         if(DownloadClicked != null)
            DownloadClicked(this, e);
      }

      public void Populate(IList<string> fileNames)
      {
         // Populate the list

         // First, remove all old items
         _listView.BeginUpdate();

         _listView.Items.Clear();

         FileTypeDictionary dictionary = new FileTypeDictionary(_imageList);

         for(int i = 0; i < fileNames.Count; i++)
         {
            string fileName = fileNames[i];

            // Get the extension of the file name without the leading "."
            // We will use this to find the icon and description of this
            // file from the system

            string extension = Path.GetExtension(fileName);
            if(!string.IsNullOrEmpty(extension))
               extension = extension.Substring(1, extension.Length - 1).ToLower();

            // Add this extension to our dictionary
            // The dictionary will check if it is already added and does nothing

            dictionary.Add(extension);

            ListViewItem item = new ListViewItem();

            // Set the item text and image index
            item.Text = fileName;
            item.ImageIndex = dictionary.GetImageIndex(extension);

            // Add the description to the second column
            string description = dictionary.GetDescription(extension);

            item.SubItems.Add(description);

            _listView.Items.Add(item);
         }

         _listView.EndUpdate();
         _listView_SelectedIndexChanged(this, EventArgs.Empty);

         // Since this is populated, we can enable the refresh button
         _refreshToolStripButton.Enabled = true;
      }

      public bool CanRefresh
      {
         get
         {
            return _refreshToolStripButton.Enabled;
         }
      }

      public string GetSelectedItemName()
      {
         string name = string.Empty;

         if(_listView.SelectedItems.Count > 0)
            name = _listView.SelectedItems[0].Text;

         return name;
      }
   }
}
