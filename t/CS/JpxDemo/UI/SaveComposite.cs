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
using System.IO;
using Leadtools.Jpeg2000;
using Leadtools.Demos;

namespace JPXDemo
{
   public partial class SaveComposite : Form
   {
      public SaveComposite(MainForm mainForm, string dialogName, string buttonName, bool isComposite)
      {
         InitializeComponent();

         _mainForm = mainForm;
         this.Text = dialogName;
         _btnSave.Text = buttonName;
         IsComposite = isComposite;

         InitClass();
      }

      private MainForm _mainForm;
      private bool _isComposite;

      private bool IsComposite
      {
         get
         {
            return _isComposite;
         }
         set
         {
            _isComposite = value;
         }
      }

      private void InitClass()
      {
         foreach (ViewerForm child in _mainForm.MdiChildren)
         {
            ListItem item = new ListItem(Path.GetFileName(child.Text), child.Viewer.Image);
            _cbAvailableColorImages.Items.Add(item);
            _cbAvailableOpacityImages.Items.Add(item);
         }

         _cbAvailableColorImages.SelectedIndex = 0;
         _cbAvailableOpacityImages.SelectedIndex = 0;

         // Set the Use Opacity to true and to use opacity...
         _cbUseOpacity.Checked = true;
         _rbOpacity.Checked = true;

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

      private void _cbUseOpacity_CheckedChanged(object sender, EventArgs e)
      {
         _lblAvailableOpacityImages.Enabled = _cbUseOpacity.Checked;

         _cbAvailableOpacityImages.Enabled = _cbUseOpacity.Checked;
         _rbOpacity.Enabled = _cbUseOpacity.Checked;
         _rbPreopacity.Enabled = _cbUseOpacity.Checked;
      }

      private void _btnAdd_Click(object sender, EventArgs e)
      {
         _lstColorImages.Items.Add(_cbAvailableColorImages.Items[_cbAvailableColorImages.SelectedIndex]);
         _lstColorImages.SelectedIndex = _lstColorImages.Items.Count - 1;

         if (_cbUseOpacity.Checked)
         {
            if (_rbOpacity.Checked)
            {
               _lstPreOpacityImages.Items.Add(new ListItem("*", null));
               _lstOpacityImages.Items.Add(
                  _cbAvailableOpacityImages.Items[_cbAvailableOpacityImages.SelectedIndex]);
               _lstOpacityImages.SelectedIndex = _lstOpacityImages.Items.Count - 1;
            }
            else
            {
               _lstOpacityImages.Items.Add(new ListItem("*", null));
               _lstPreOpacityImages.Items.Add(
                  _cbAvailableOpacityImages.Items[_cbAvailableOpacityImages.SelectedIndex]);
               _lstPreOpacityImages.SelectedIndex = _lstPreOpacityImages.Items.Count - 1;
            }
         }
         else
         {
            _lstOpacityImages.Items.Add(new ListItem("*", null));
            _lstPreOpacityImages.Items.Add(new ListItem("*", null));
         }

         SetSelectedItem(_lstColorImages.Items.Count - 1);

         _lstColorImages.ScrollAlwaysVisible = false;
         _lstPreOpacityImages.ScrollAlwaysVisible = false;
         _lstOpacityImages.ScrollAlwaysVisible = false;
      }

      private void _btnMoveUp_Click(object sender, EventArgs e)
      {
         if (_lstColorImages.SelectedIndex < 0)
            return;

         int index = Math.Max(_lstColorImages.SelectedIndex - 1, 0);
         SetSelectedItem(index);
      }

      private void _btnMoveDown_Click(object sender, EventArgs e)
      {
         if (_lstColorImages.SelectedIndex < 0)
            return;

         int index = Math.Min(_lstColorImages.SelectedIndex + 1, _lstColorImages.Items.Count - 1);
         SetSelectedItem(index);
      }

      private void _btnDelete_Click(object sender, EventArgs e)
      {
         if (_lstColorImages.SelectedIndex < 0)
            return;

         int index = _lstColorImages.SelectedIndex;
         _lstColorImages.Items.RemoveAt(index);
         _lstOpacityImages.Items.RemoveAt(index);
         _lstPreOpacityImages.Items.RemoveAt(index);
         if (_lstColorImages.Items.Count > 0)
         {
            index = Math.Max(0, index - 1);
            SetSelectedItem(index);
         }
      }

      private void _btnUp_Click(object sender, EventArgs e)
      {
         int index = _lstColorImages.SelectedIndex;
         if (index <= 0)
            return;

         ListItem item = (ListItem)_lstColorImages.Items[index];
         _lstColorImages.Items.RemoveAt(index);
         _lstColorImages.Items.Insert(index - 1, item);

         item = (ListItem)_lstOpacityImages.Items[index];
         _lstOpacityImages.Items.RemoveAt(index);
         _lstOpacityImages.Items.Insert(index - 1, item);

         item = (ListItem)_lstPreOpacityImages.Items[index];
         _lstPreOpacityImages.Items.RemoveAt(index);
         _lstPreOpacityImages.Items.Insert(index - 1, item);

         SetSelectedItem(index - 1);
      }

      private void _btnDown_Click(object sender, EventArgs e)
      {
         int index = _lstColorImages.SelectedIndex;
         if (index >= _lstColorImages.Items.Count - 1)
            return;

         ListItem item = (ListItem)_lstColorImages.Items[index];
         _lstColorImages.Items.RemoveAt(index);
         _lstColorImages.Items.Insert(index + 1, item);

         item = (ListItem)_lstOpacityImages.Items[index];
         _lstOpacityImages.Items.RemoveAt(index);
         _lstOpacityImages.Items.Insert(index + 1, item);

         item = (ListItem)_lstPreOpacityImages.Items[index];
         _lstPreOpacityImages.Items.RemoveAt(index);
         _lstPreOpacityImages.Items.Insert(index + 1, item);

         SetSelectedItem(index + 1);
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         if (IsComposite)
         {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2";
            sfd.Title = "Save As";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
               _txtFileName.Text = sfd.FileName;
               _btnSave.Enabled = true;
            }
         }
         else
         {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2";
            ofd.Title = "Open file";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
               _txtFileName.Text = ofd.FileName;
               _btnSave.Enabled = true;
            }
         }
      }

      private void _btnSave_Click(object sender, EventArgs e)
      {
         if (_lstColorImages.Items.Count == 0)
         {
            Messager.ShowError(this, "Please select images to save");
            return;
         }

         Jpeg2000FileFormat format = (Path.GetExtension(_txtFileName.Text) == ".jp2") ?
                                     Jpeg2000FileFormat.LeadJp2 :
                                     Jpeg2000FileFormat.LeadJpx;

         List<CompositeJpxImages> saveCompositeImage = new List<CompositeJpxImages>();

         CompositeJpxImages itemImage;
         ListItem item;
         for (int index = 0; index < _lstColorImages.Items.Count; index++)
         {
            itemImage = new CompositeJpxImages();

            item = (ListItem)_lstColorImages.Items[index];
            itemImage.ColorImage = item.Image.CloneAll();

            item  = (ListItem)_lstOpacityImages.Items[index];
            if(item.Name == "*")
               itemImage.OpacityImage = null;
            else
               itemImage.OpacityImage = item.Image.CloneAll();

            item  = (ListItem)_lstPreOpacityImages.Items[index];
            if (item.Name == "*")
               itemImage.PreOpacityImage = null;
            else
               itemImage.PreOpacityImage = item.Image.CloneAll();

            saveCompositeImage.Add(itemImage);
         }

         try
         {
            if (IsComposite)
            {
               _mainForm.Jpeg2000Eng.SaveComposite(_mainForm.Codecs,
                  _txtFileName.Text,
                  saveCompositeImage,
                  format,
                  Convert.ToInt32(_cbBPP.SelectedItem),
                  Convert.ToInt32(_cbQualityFactor.SelectedIndex));
            }
            else
            {
               _mainForm.Jpeg2000Eng.AppendFrames(_mainForm.Codecs,
                  _txtFileName.Text,
                  saveCompositeImage,
                  Convert.ToInt32(_cbBPP.SelectedItem),
                  Convert.ToInt32(_cbQualityFactor.SelectedIndex));
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void SetSelectedItem(int index)
      {
         _lstColorImages.SelectedIndex = index;
         _lstOpacityImages.SelectedIndex = index;
         _lstPreOpacityImages.SelectedIndex = index;
      }

      private void _lst_Click(object sender, EventArgs e)
      {
         SetSelectedItem(((ListBox)sender).SelectedIndex);
      }
   }
}
