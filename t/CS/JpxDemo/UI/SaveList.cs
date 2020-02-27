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
using Leadtools;
using System.IO;
using Leadtools.Jpeg2000;
using Leadtools.Demos;

namespace JPXDemo
{
   public partial class SaveList : Form
   {
      private MainForm _mainForm;

      public SaveList(MainForm mainForm)
      {
         InitializeComponent();

         _mainForm = mainForm;

         InitClass();
      }

      private void InitClass()
      {
         foreach (ViewerForm child in _mainForm.MdiChildren)
         {
            ListItem item;

            item.Name = Path.GetFileName(child.Text);
            item.Image = child.Viewer.Image;
            _lstAvailableImages.Items.Add(item);
         }

         _lstAvailableImages.SelectedIndex = 0;

         // Set the BBP ComboBox...
         _cbBPP.Items.Add("0");
         _cbBPP.Items.Add("8");
         _cbBPP.Items.Add("12");
         _cbBPP.Items.Add("16");
         _cbBPP.Items.Add("24");
         _cbBPP.Items.Add("32");
         _cbBPP.Items.Add("48");
         _cbBPP.SelectedIndex = 0;

         // Set the Quality Factor ComboBox...
         _cbQualityFactor.Items.Add("0-Lossless");
         for (int index = 1; index < 256; index++)
         {
            _cbQualityFactor.Items.Add(index.ToString());
         }
         _cbQualityFactor.SelectedIndex = 0;

         // Disable the Save Button until the save file name is specified...
         _btnSave.Enabled = false;
      }

      private void _btnAdd_Click(object sender, EventArgs e)
      {
         _lstSelectedImages.Items.Add(_lstAvailableImages.Items[_lstAvailableImages.SelectedIndex]);
         _lstSelectedImages.SelectedIndex = _lstSelectedImages.Items.Count - 1;
      }

      private void _btnRemove_Click(object sender, EventArgs e)
      {
         int index = _lstSelectedImages.SelectedIndex;
         if (index < 0)
            return;

         _lstSelectedImages.Items.RemoveAt(_lstSelectedImages.SelectedIndex);

         if(_lstSelectedImages.Items.Count > 0)
            _lstSelectedImages.SelectedIndex = Math.Max(0, index - 1);
         else
            _lstSelectedImages.SelectedIndex = -1;
      }

      private void _btnAddAll_Click(object sender, EventArgs e)
      {
         for (int index = 0; index < _lstAvailableImages.Items.Count; index++)
         {
            _lstSelectedImages.Items.Add(_lstAvailableImages.Items[index]);
            _lstSelectedImages.SelectedIndex = _lstSelectedImages.Items.Count - 1;
         }
      }

      private void _btnRemoveAll_Click(object sender, EventArgs e)
      {
         _lstSelectedImages.Items.Clear();
      }

      private void _btnUp_Click(object sender, EventArgs e)
      {
         int index = _lstSelectedImages.SelectedIndex;
         if (index <= 0)
            return;

         ListItem item = (ListItem) _lstSelectedImages.Items[_lstSelectedImages.SelectedIndex];

         _lstSelectedImages.Items.RemoveAt(_lstSelectedImages.SelectedIndex);
         _lstSelectedImages.Items.Insert(index - 1, item);
         _lstSelectedImages.SelectedIndex = index - 1;
      }

      private void _btnDown_Click(object sender, EventArgs e)
      {
         int index = _lstSelectedImages.SelectedIndex;
         if (index >= _lstSelectedImages.Items.Count - 1)
            return;

         ListItem item = (ListItem) _lstSelectedImages.Items[_lstSelectedImages.SelectedIndex];

         _lstSelectedImages.Items.RemoveAt(_lstSelectedImages.SelectedIndex);
         _lstSelectedImages.Items.Insert(index + 1, item);
         _lstSelectedImages.SelectedIndex = index + 1;
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         SaveFileDialog sfd = new SaveFileDialog();

         sfd.Filter = "JPX Files(*.jpx)|*.jpx";
         sfd.Title = "Save As";

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            _txtFileName.Text = sfd.FileName;
            _btnSave.Enabled = true;
         }
      }

      private void _btnSave_Click(object sender, EventArgs e)
      {
         if (_lstSelectedImages.Items.Count == 0)
         {
            Messager.ShowError(this, "Please select images to save");
            return;
         }

         Jpeg2000FileFormat format = (Path.GetExtension(_txtFileName.Text) == ".jp2") ?
                                     Jpeg2000FileFormat.LeadJp2 :
                                     Jpeg2000FileFormat.LeadJpx ;

         RasterImage saveImage = ((ListItem)_lstSelectedImages.Items[0]).Image.CloneAll();
         for(int index = 1 ; index < _lstSelectedImages.Items.Count ; index++)
         {
            saveImage.AddPage(((ListItem)_lstSelectedImages.Items[index]).Image.CloneAll());
         }

         try
         {
            _mainForm.Jpeg2000Eng.Save(_mainForm.Codecs,
                                    _txtFileName.Text,
                                    saveImage,
                                    format,
                                    Convert.ToInt32(_cbBPP.SelectedItem),
                                    Convert.ToInt32(_cbQualityFactor.SelectedIndex));

            DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }
   }
}
