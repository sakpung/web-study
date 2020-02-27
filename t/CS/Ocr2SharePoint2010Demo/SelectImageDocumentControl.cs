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

namespace Ocr2SharePointDemo
{
   public partial class SelectImageDocumentControl : UserControl
   {
      public SelectImageDocumentControl()
      {
         InitializeComponent();
      }

      private string _imageDocumentFileName;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public string ImageDocumentFileName
      {
         get { return _imageDocumentFileName; }
      }

      private MainForm _mainForm;
      public void SetOwner(MainForm mainForm, string imageDocumentFileName)
      {
         _mainForm = mainForm;
         _imageDocumentFileName = imageDocumentFileName;
         _fileNameTextBox.Text = _imageDocumentFileName;

         MyDocumentFormatItem[] items = MyDocumentFormatItem.DefaultItems;
         foreach (MyDocumentFormatItem item in items)
         {
            _formatComboBox.Items.Add(item);
         }

         _formatComboBox.SelectedIndex = 0;
      }

      private void _browseButton_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Filter = "Common Images Files|*.tif;*.tiff;*.jpg;*.jpeg;*.png;*.pdf|All Files|*.*";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _fileNameTextBox.Text = dlg.FileName;
            }
         }
      }

      private void _fileNameTextBox_TextChanged(object sender, EventArgs e)
      {
         _imageDocumentFileName = _fileNameTextBox.Text;
         _mainForm.UpdateUIState();
      }

      public MyDocumentFormat GetSelectedDocumentFormat()
      {
         MyDocumentFormatItem item = (MyDocumentFormatItem)_formatComboBox.SelectedItem;
         return item.FormatType;
      }
   }
}
