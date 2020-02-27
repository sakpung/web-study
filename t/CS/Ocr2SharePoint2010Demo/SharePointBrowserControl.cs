// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using Leadtools.Demos;
using Leadtools.SharePoint.Client;

namespace Ocr2SharePointDemo
{
   public partial class SharePointBrowserControl : UserControl
   {
      public SharePointBrowserControl()
      {
         InitializeComponent();
      }

      private MainForm _mainForm;
      public void SetOwner(MainForm mainForm)
      {
         _mainForm = mainForm;
         _sharePointItemsListView.FillHeaders();
      }

      private SharePoint.SharePointServerSettings _serverSettings;

      public void SetSharePointSettings(SharePoint.SharePointServerSettings serverSettings, SharePoint.SPListInfo[] lists)
      {
         _serverSettings = serverSettings;

         _curerntFolderItem = null;
         _errorLabel.Visible = false;

         // Populate the document libraries, select "Shared Documents" initially if it exists

         _documentLibrariesListBox.BeginUpdate();
         _documentLibrariesListBox.Items.Clear();

         SharePoint.SPListInfo sharedDocumentList = null;

         foreach (SharePoint.SPListInfo list in lists)
         {
            _documentLibrariesListBox.Items.Add(list);

            if (string.Compare(list.Title, "Shared Documents", StringComparison.OrdinalIgnoreCase) == 0)
               sharedDocumentList = list;
         }
         _documentLibrariesListBox.EndUpdate();

         if (_documentLibrariesListBox.Items.Count > 0)
         {
            if (sharedDocumentList != null)
               _documentLibrariesListBox.SelectedItem = sharedDocumentList;
            else
               _documentLibrariesListBox.SelectedIndex = 0;
         }

         UpdateUIState();
      }

      private void _documentLibrariesListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Fill in the folders and documents from share point

         FillItems(null);
      }

      private SharePoint.SPItemInfo _curerntFolderItem;

      private void FillItems(SharePoint.SPItemInfo parentItem)
      {
         _curerntFolderItem = parentItem;
         _errorLabel.Visible = false;

         _sharePointItemsListView.BeginUpdate();
         _sharePointItemsListView.Items.Clear();

         // Get the items of the selected list
         SharePoint.SPListInfo listInfo = _documentLibrariesListBox.SelectedItem as SharePoint.SPListInfo;
         if (listInfo != null)
         {
            try
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  SharePoint.SPHelper helper = new SharePoint.SPHelper(_serverSettings);
                  SharePoint.SPItemInfo[] items = helper.GetChildren(listInfo, parentItem);

                  // If we have a parent item, add the special "move folder up" item
                  if (parentItem != null)
                  {
                     SharePoint.SPItemInfo item = new SharePoint.SPItemInfo();
                     item.ItemType = SharePoint.SPItemType.Folder;
                     item.Name = "..";
                     item.ParentItem = parentItem.ParentItem;
                     _sharePointItemsListView.AddSharePointItem(item);
                  }

                  // Add the children (folders first) to the list view
                  foreach (SharePoint.SPItemInfo item in items)
                  {
                     if (item.ItemType == Ocr2SharePointDemo.SharePoint.SPItemType.Folder)
                     {
                        _sharePointItemsListView.AddSharePointItem(item);
                     }
                  }

                  foreach (SharePoint.SPItemInfo item in items)
                  {
                     if (item.ItemType == Ocr2SharePointDemo.SharePoint.SPItemType.File)
                     {
                        _sharePointItemsListView.AddSharePointItem(item);
                     }
                  }
               }
            }
            catch (Exception ex)
            {
               _errorLabel.Text = "Error: " + ex.Message;
               _errorLabel.Visible = true;
            }
         }

         _sharePointItemsListView.EndUpdate();

         UpdateUIState();
      }

      private void _sharePointItemsListView_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _sharePointItemsListView_ItemActivate(object sender, EventArgs e)
      {
         if (_sharePointItemsListView.SelectedItems != null && _sharePointItemsListView.SelectedItems.Count > 0)
         {
            ListViewItem lvItem = _sharePointItemsListView.SelectedItems[0];
            SharePoint.SPItemInfo item = lvItem.Tag as SharePoint.SPItemInfo;

            if(item.ItemType == SharePoint.SPItemType.Folder)
            {
               // If this is our special ".." folder, go up
               // Go into this folder
               if (string.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) == 0)
               {
                  FillItems(item.ParentItem);
               }
               else
               {
                  FillItems(item);
               }
            }
            else if (item.ItemType == SharePoint.SPItemType.File)
            {
            }
         }

         UpdateUIState();
      }

      private void UpdateUIState()
      {
         string folderPath = GetCurrentFolderPath(false);
         if (folderPath != null)
         {
            _selectedFolderTextBox.Text = folderPath;
         }
         else
         {
            _selectedFolderTextBox.Text = string.Empty;
         }

         string filePath = GetCurrentFilePath(false);
         if (filePath != null)
         {
            _selectedFileTextBox.Text = filePath;
            _downloadButton.Enabled = true;
         }
         else
         {
            _selectedFileTextBox.Text = string.Empty;
            _downloadButton.Enabled = false;
         }

         _mainForm.UpdateUIState();
      }

      public string GetCurrentFolderPath(bool absolute)
      {
         string folderPath = null;

         if (_curerntFolderItem != null)
         {
            if (absolute)
            {
               if (_curerntFolderItem.AbsoluteUri != null)
                  folderPath = _curerntFolderItem.AbsoluteUri.ToString();
            }
            else
               folderPath = _curerntFolderItem.ServerRelativeUrl;
         }
         else
         {
            // Get the folder path from the parent list
            SharePoint.SPListInfo list = _documentLibrariesListBox.SelectedItem as SharePoint.SPListInfo;
            if (list != null)
            {
               if (absolute)
                  folderPath = list.AbsoluteUri.ToString();
               else
                  folderPath = list.ServerRelativeUrl;
            }
         }

         return folderPath;
      }

      public string GetCurrentFilePath(bool absolute)
      {
         string filePath = null;

         if (_sharePointItemsListView.SelectedItems != null && _sharePointItemsListView.SelectedItems.Count > 0)
         {
            ListViewItem lvItem = _sharePointItemsListView.SelectedItems[0];
            SharePoint.SPItemInfo item = lvItem.Tag as SharePoint.SPItemInfo;

            if (item.ItemType == SharePoint.SPItemType.File)
            {
               if (absolute)
               {
                  if (item.AbsoluteUri != null)
                     filePath = item.AbsoluteUri.ToString();
               }
               else
                  filePath = item.ServerRelativeUrl;
            }
         }

         return filePath;
      }

      private void _listsContextMenuStrip_Opening(object sender, CancelEventArgs e)
      {
         e.Cancel = _documentLibrariesListBox.SelectedItem == null;
      }

      private void _listsCopyAbsoluteURLToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SharePoint.SPListInfo list = _documentLibrariesListBox.SelectedItem as SharePoint.SPListInfo;
         if (list != null)
         {
            Clipboard.SetText(list.AbsoluteUri.ToString());
         }
      }

      private void _itemsContextMenuStrip_Opening(object sender, CancelEventArgs e)
      {
         if (_sharePointItemsListView.SelectedItems != null && _sharePointItemsListView.SelectedItems.Count > 0)
         {
            SharePoint.SPItemInfo item = _sharePointItemsListView.SelectedItems[0].Tag as SharePoint.SPItemInfo;
            e.Cancel = string.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) == 0;

            if (!e.Cancel && item.ItemType != SharePoint.SPItemType.File)
               _itemsDownloadToDiskToolStripMenuItem.Enabled = false;
            else
               _itemsDownloadToDiskToolStripMenuItem.Enabled = true;
         }
         else
         {
            e.Cancel = true;
         }
      }

      private void _itemsCopyAbsoluteURLToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_sharePointItemsListView.SelectedItems != null && _sharePointItemsListView.SelectedItems.Count > 0)
         {
            SharePoint.SPItemInfo item = _sharePointItemsListView.SelectedItems[0].Tag as SharePoint.SPItemInfo;
            if (item.AbsoluteUri != null && string.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) != 0)
            {
               Clipboard.SetText(item.AbsoluteUri.ToString());
            }
         }
      }

      private void _itemsDownloadToDiskToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _downloadButton.PerformClick();
      }

      private void _refreshButton_Click(object sender, EventArgs e)
      {
         RefreshCurrentFolder();
      }

      public void RefreshCurrentFolder()
      {
         FillItems(_curerntFolderItem);
      }

      public void SelectItem(Uri serverDocumentUri)
      {
         if (serverDocumentUri != null)
         {
            // In current items, find if the absolute URI is equivalant to 'serverDocumentUri'
            foreach (ListViewItem lvItem in _sharePointItemsListView.Items)
            {
               SharePoint.SPItemInfo item = lvItem.Tag as SharePoint.SPItemInfo;
               if (item.AbsoluteUri != null && string.CompareOrdinal(item.AbsoluteUri.ToString(), serverDocumentUri.ToString()) == 0)
               {
                  _sharePointItemsListView.SelectedItems.Clear();
                  lvItem.Selected = true;
                  _sharePointItemsListView.Focus();
                  break;
               }
            }
         }
      }

      private SharePoint.SPItemInfo _tryDownloadItem;
      private string _tryDownloadFileName;
      private void _downloadButton_Click(object sender, EventArgs e)
      {
         if (_sharePointItemsListView.SelectedItems != null && _sharePointItemsListView.SelectedItems.Count > 0)
         {
            ListViewItem lvItem = _sharePointItemsListView.SelectedItems[0];
            _tryDownloadItem = lvItem.Tag as SharePoint.SPItemInfo;
            if (_tryDownloadItem.ItemType == SharePoint.SPItemType.File)
            {
               using (SaveFileDialog dlg = new SaveFileDialog())
               {
                  if (!string.IsNullOrEmpty(_tryDownloadItem.FileExtension))
                     dlg.Filter = string.Format("*.{0}|*.{0}|All Files|*.*", _tryDownloadItem.FileExtension);
                  else
                     dlg.Filter = "All Files|*.*";

                  dlg.FileName = _tryDownloadItem.Name;
                  if (dlg.ShowDialog(this) == DialogResult.OK)
                  {
                     _tryDownloadFileName = dlg.FileName;
                     _mainForm.BeginOperation(new MethodInvoker(TryDownload));
                  }
               }
            }
         }
      }

      private void TryDownload()
      {
         _mainForm.SetOperationText("Downloading " + _tryDownloadItem.AbsoluteUri);

         Exception error = null;

         // Download the file
         try
         {
            SharePointClient spClient = new SharePointClient();

            // Set the credentials and proxy
            if (_serverSettings.UserName != null)
            {
               spClient.Credentials = new NetworkCredential(_serverSettings.UserName, _serverSettings.Password, _serverSettings.Domain);
            }

            if (_serverSettings.ProxyUri != null)
            {
               WebProxy proxy = new WebProxy(_serverSettings.ProxyUri, _serverSettings.ProxyPort);
               if (proxy.Credentials == null && spClient.Credentials != null)
               {
                  proxy.Credentials = spClient.Credentials;
               }
               else
               {
                  proxy.Credentials = CredentialCache.DefaultCredentials;
               }

               spClient.Proxy = proxy;
            }
            else
               spClient.Proxy = WebRequest.GetSystemWebProxy(); // Get default system proxy settings

            // Download the file
            spClient.DownloadFile(_tryDownloadItem.AbsoluteUri, _tryDownloadFileName);
            System.Diagnostics.Process.Start(_tryDownloadFileName);
         }
         catch (Exception ex)
         {
            error = ex;
         }

         _mainForm.EndOperation(error);
      }
   }
}
