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
using System.IO;

namespace Ocr2SharePointDemo
{
   public partial class SharePointItemsListView : ListView
   {
      public SharePointItemsListView()
      {
         InitializeComponent();

         if (!DesignMode)
         {
            this.View = View.Details;
            this.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.HideSelection = false;
            this.MultiSelect = false;

            CreateColumns();
            SmallImageList = new ImageList();
            SmallImageList.ImageSize = new Size(16, 16);
            SmallImageList.ColorDepth = ColorDepth.Depth32Bit;

            _fileTypes = new FileTypeDictionary(this.SmallImageList);
            _fileTypes.Add(FileTypeDictionary.DiretoryType);
         }
      }

      private FileTypeDictionary _fileTypes;

      private void CreateColumns()
      {
         ColumnHeader nameHeader = new ColumnHeader();
         nameHeader.Text = "Name";
         nameHeader.Width = 150;
         Columns.Add(nameHeader);

         ColumnHeader createdHeader = new ColumnHeader();
         createdHeader.Text = "Created";
         createdHeader.Width = 150;
         Columns.Add(createdHeader);

         ColumnHeader descriptionHeader = new ColumnHeader();
         descriptionHeader.Text = "Description";
         descriptionHeader.Width = 150;
         Columns.Add(descriptionHeader);
      }

      public void FillHeaders()
      {
         Columns[0].Width = ClientSize.Width - Columns[1].Width - Columns[2].Width;
      }

      public void AddSharePointItem(SharePoint.SPItemInfo item)
      {
         string extension;

         if (item.ItemType == SharePoint.SPItemType.File)
            extension = Path.GetExtension(item.Name);
         else if (item.ItemType == SharePoint.SPItemType.Folder)
            extension = FileTypeDictionary.DiretoryType;
         else
            return;

         _fileTypes.Add(extension);

         ListViewItem lvItem = new ListViewItem();
         lvItem.Text = item.Name;
         lvItem.ImageIndex = _fileTypes.GetImageIndex(extension);

         ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();

         if (string.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) != 0)
            subItem.Text = item.Created.ToString();
         else
            subItem.Text = string.Empty;
         lvItem.SubItems.Add(subItem);

         subItem = new ListViewItem.ListViewSubItem();
         subItem.Text = _fileTypes.GetDescription(extension);
         lvItem.SubItems.Add(subItem);

         lvItem.Tag = item;

         Items.Add(lvItem);
      }
   }
}
