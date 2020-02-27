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
using Leadtools.Document.Writer;

namespace DocumentWritersDemo
{
   public partial class InsertBookmarkForm : Form
   {
      private TreeNode _treeNode;
      private int _pagesCount = 0;
      private int _selectedPageIndex = 0;
      private int _maxPageWidth = 0;
      private int _maxPageHeight = 0;

      public InsertBookmarkForm(TreeNode treeNode, int pagesCount, int selectedPageIndex, int maxPageWidth, int maxPageHeight)
      {
         InitializeComponent();
         _treeNode = treeNode;
         _pagesCount = pagesCount;
         _selectedPageIndex = selectedPageIndex;
         _maxPageWidth = maxPageWidth;
         _maxPageHeight = maxPageHeight;
      }

      /// <summary>
      /// This action will be fired when the user changes the PageNumber selection from the combo box
      /// which causes the MainForm to handle this event and activate the corresponding page.
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;

      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it
         if (Action != null)
            Action(this, new ActionEventArgs(action, data));
      }

      public TextBox PositionX
      {
         get { return _tbX; }
      }

      public TextBox PositionY
      {
         get { return _tbY; }
      }

      private void InsertBookmarkForm_Load(object sender, EventArgs e)
      {
         for (int i = 1; i <= _pagesCount; i++)
            _cbPageNumber.Items.Add(i.ToString());

         _tbName.Text = "Untitled";

         _cbPageNumber.SelectedIndex = _selectedPageIndex;

         _tbX.Text = (0).ToString();
         _tbY.Text = (0).ToString();

         // check if the tree node tag has value then re-update the controls
         if (_treeNode != null)
         {
            _tbName.Text = _treeNode.Text;
            if (_treeNode.Tag != null)
            {
               PdfCustomBookmark bookmark = (PdfCustomBookmark)_treeNode.Tag;

               int pageIndex = bookmark.PageNumber - 1;
               if (pageIndex > _selectedPageIndex)
                  pageIndex = _selectedPageIndex;
               _cbPageNumber.SelectedIndex = pageIndex;

               _tbX.Text = bookmark.XCoordinate.ToString();
               _tbY.Text = bookmark.YCoordinate.ToString();
            }
         }

         UpdateUIState();
      }

      private void UpdateUIState()
      {
         _btnOk.Enabled = !string.IsNullOrEmpty(_tbName.Text);
      }

      private void _tbName_TextChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _tbX_TextChanged(object sender, EventArgs e)
      {
         int val;
         if (!int.TryParse(_tbX.Text, out val) || val < 0)
            _tbX.Text = (0).ToString();

         if (val < 0)
            val = 0;
         if (val > _maxPageWidth)
            val = _maxPageWidth;

         _tbX.Text = val.ToString();
         UpdateUIState();
      }

      private void _tbY_TextChanged(object sender, EventArgs e)
      {
         int val;
         if (!int.TryParse(_tbY.Text, out val) || val < 0)
            _tbY.Text = (0).ToString();

         if (val < 0)
            val = 0;
         if (val > _maxPageHeight)
            val = _maxPageHeight;

         _tbY.Text = val.ToString();
         UpdateUIState();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         int val = 0;
         PdfCustomBookmark bookmark = new PdfCustomBookmark();

         bookmark.LevelNumber = _treeNode.Level;
         bookmark.Name = _tbName.Text;
         bookmark.PageNumber = _cbPageNumber.SelectedIndex + 1;
         int.TryParse(_tbX.Text, out val);
         bookmark.XCoordinate = val;
         int.TryParse(_tbY.Text, out val);
         bookmark.YCoordinate = val;

         _treeNode.Text = _tbName.Text;
         _treeNode.Tag = bookmark;

         Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         if (_treeNode != null)
         {
            _treeNode.Remove();
         }
         Close();
      }

      private void _cbPageNumber_SelectedIndexChanged(object sender, EventArgs e)
      {
         DoAction("PageNumberChanged", _cbPageNumber.SelectedIndex + 1);
      }
   }
}
