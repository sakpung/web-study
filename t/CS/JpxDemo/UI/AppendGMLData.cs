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
   public partial class AppendGMLData : Form
   {
      public AppendGMLData(MainForm mainParentForm)
      {
         InitializeComponent();

         _mainParentForm = mainParentForm;

         InitClass();
      }

      private void InitClass()
      {
         AppendGMLStructure temp = new AppendGMLStructure();
         temp.gMLData = new GmlData();

         AppendGML = temp;

         _btnOk.Enabled = false;
      }

      private MainForm _mainParentForm;
      private AppendGMLStructure _appendGML;

      public MainForm MainParentForm
      {
         get
         {
            return _mainParentForm;
         }
         set
         {
            _mainParentForm = value;
         }
      }

      public AppendGMLStructure AppendGML
      {
         get
         {
            return _appendGML;
         }
         set
         {
            _appendGML = value;
         }
      }

      private void _btnJPEG2000Browse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Filter = "JPX Files(*.jpx)|*.jpx";
         ofd.Title = "Open a File";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtJPEG2000FileName.Text = ofd.FileName;
         }
      }

      private void _btnXMLBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Filter = "XML Files(*.xml)|*.xml";
         ofd.Title = "Open a File";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtXMLDataFile.Text = ofd.FileName;
         }
      }

      private void _btnAdd_Click(object sender, EventArgs e)
      {
         if (AppendGMLUpdateGMLInfo())
         {
            GMLListItem item = new GMLListItem(_txtLabel.Text, Path.GetFileName(_txtXMLDataFile.Text), AppendGML.gMLData.Data[AppendGML.gMLData.Data.Count - 1]);

            _lstLabel.Items.Add(_txtLabel.Text);
            _lstXmlDataFile.Items.Add(item);

            SetSelectedItem(_lstLabel.Items.Count - 1);

            _btnOk.Enabled = true;
         }
      }


      private void _btnUp_Click(object sender, EventArgs e)
      {
         int index = _lstLabel.SelectedIndex;
         if (index <= 0)
            return;

         string stringItem = (string)_lstLabel.Items[index];
         _lstLabel.Items.RemoveAt(index);
         _lstLabel.Items.Insert(index - 1, stringItem);

         GMLListItem item = (GMLListItem)_lstXmlDataFile.Items[index];
         _lstXmlDataFile.Items.RemoveAt(index);
         _lstXmlDataFile.Items.Insert(index - 1, item);

         SetSelectedItem(index - 1);
      }

      private void _btnDown_Click(object sender, EventArgs e)
      {
         int index = _lstLabel.SelectedIndex;
         if (index >= _lstLabel.Items.Count - 1)
            return;

         string stringItem = (string)_lstLabel.Items[index];
         _lstLabel.Items.RemoveAt(index);
         _lstLabel.Items.Insert(index + 1, stringItem);

         GMLListItem item = (GMLListItem)_lstXmlDataFile.Items[index];
         _lstXmlDataFile.Items.RemoveAt(index);
         _lstXmlDataFile.Items.Insert(index + 1, item);

         SetSelectedItem(index + 1);
      }

      private void _btnDelete_Click(object sender, EventArgs e)
      {
         int index = _lstLabel.SelectedIndex;

         if (index < 0)
            return;

         _lstLabel.Items.RemoveAt(index);
         _lstXmlDataFile.Items.RemoveAt(index);

         index = Math.Max(0, index - 1);

         if(_lstLabel.Items.Count > 0)
            SetSelectedItem(index);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if (AppendGMLProcess())
         {
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private void _lst_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetSelectedItem(((ListBox)sender).SelectedIndex);
      }

      private void SetSelectedItem(int index)
      {
         _lstLabel.SelectedIndex = index;
         _lstXmlDataFile.SelectedIndex = index;
      }

      private bool AppendGMLProcess()
      {
         GmlData _gmlData;

         if (_txtJPEG2000FileName.Text == "")
         {
            Messager.ShowError(this, "You must select a JPX file!");
            return false;
         }

         if (_lstXmlDataFile.Items.Count == 0)
         {
            Messager.ShowError(this, "There is no GML data to append");
            return false;
         }

         if (_lstXmlDataFile.Items.Count == 0)
         {
            Messager.ShowError(this, "There is no GML data to append");
            return false;
         }

         _gmlData = new GmlData();
         _gmlData.Data = new List<GmlElement>();

         int index;
         for (index = 0; index < _lstXmlDataFile.Items.Count; index++)
         {
            _gmlData.Data.Add(((GMLListItem)_lstXmlDataFile.Items[index]).GMLElement);
         }

         try
         {
            MainParentForm.Jpeg2000Eng.AppendGmlData(_txtJPEG2000FileName.Text, _gmlData);

            Messager.ShowError(this, "Appending Succeeded");
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         return true;
      }

      private bool AppendGMLUpdateGMLInfo()
      {
         if (_txtLabel.Text == "")
         {
            Messager.ShowError(this, "No Label");
            return false;
         }

         GmlElement gmlElement = new GmlElement();
         gmlElement.Label = Encoding.UTF8.GetBytes(_txtLabel.Text);
         gmlElement.Data = File.ReadAllBytes(_txtXMLDataFile.Text);

         GmlData dataItem = new GmlData();
         AppendGML.gMLData.Data.Add(gmlElement);

         return true;
      }
   }
}
