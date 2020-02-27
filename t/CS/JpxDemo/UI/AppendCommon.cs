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
using Leadtools.Demos;

namespace JPXDemo
{
   public partial class AppendCommon : Form
   {
      private string _dialogName;
      private bool _showFilterType;
      private AppendCommonStructure _appendCommonData;
      private List<string> _filterTypes;
      private byte[] pGZIP = {0xEC, 0x34, 0x0B, 0x04, 0x74, 0xC5, 0x11, 0xD4, 0xA7, 0x29, 0x87, 0x9E, 0xA3, 0x54, 0x8F, 0x0E };
      private byte[] pDES  = {0xEC, 0x34, 0x0B, 0x04, 0x74, 0xC5, 0x11, 0xD4, 0xA7, 0x29, 0x87, 0x9E, 0xA3, 0x54, 0x8F, 0x0F };

      public List<string> FilterTypes
      {
         get
         {
            return _filterTypes;
         }
         set
         {
            _filterTypes = value;
         }
      }

      public AppendCommonStructure AppendCommonData
      {
         get
         {
            return _appendCommonData;
         }
         set
         {
            _appendCommonData = value;
         }
      }

      public string DialogName
      {
         get
         {
            return _dialogName;
         }
         set
         {
            _dialogName = value;
         }
      }

      public bool ShowFilterType
      {
         get
         {
            return _showFilterType;
         }
         set
         {
            _showFilterType = value;
         }
      }

      public string Jpeg2000FileName
      {
         get
         {
            return _txtJPEG2000.Text;
         }
         set
         {
            _txtJPEG2000.Text = value;
         }
      }

      public string SecondLabel
      {
         get
         {
            return _lblSecond.Text;
         }
         set
         {
            _lblSecond.Text = value;
         }
      }

      public AppendCommon()
      {
         InitializeComponent();

         ShowFilterType = false;
         DialogName = "Append Common";
         FilterTypes = null;

         AppendCommonData = new AppendCommonStructure();

         InitClass();
      }

      public AppendCommon(string dialogName, bool showFilterType, List<String> filterItems)
      {
         InitializeComponent();

         ShowFilterType = showFilterType;
         DialogName = dialogName;

         FilterTypes = filterItems;

         InitClass();
      }

      private void InitClass()
      {
         this.Text = "Append " + DialogName + " Box Dialog";

         SecondLabel = DialogName + " Box Data File:";

         ShowFilterTypeControls(ShowFilterType);
      }

      private void ShowFilterTypeControls(object showFilterType)
      {
         if (ShowFilterType)
         {
            for (int index = 0; index < FilterTypes.Count; index++)
            {
               _cbFilterType.Items.Add(FilterTypes[index]);
            }
            _cbFilterType.SelectedIndex = 0;
            return;
         }

         _lblFilterType.Visible = false;
         _cbFilterType.Visible = false;

         _grpData.Height -= _cbFilterType.Height;
         _lblSecond.Location = new Point(_lblSecond.Location.X, _lblSecond.Location.Y - _cbFilterType.Height);
         _txtSecond.Location = new Point(_txtSecond.Location.X, _txtSecond.Location.Y - _cbFilterType.Height);
         _btnSecondBrowse.Location = new Point(_btnSecondBrowse.Location.X, _btnSecondBrowse.Location.Y - _cbFilterType.Height);
         _btnOk.Location = new Point(_btnOk.Location.X, _btnOk.Location.Y - _cbFilterType.Height);
         _btnCancel.Location = new Point(_btnCancel.Location.X, _btnCancel.Location.Y - _cbFilterType.Height);
         this.Height -= _cbFilterType.Height;
      }

      private void _btnFirstBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtJPEG2000.Text = ofd.FileName;
         }
      }

      private void _btnSecondBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "All Files (*.*)|*.*";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtSecond.Text = ofd.FileName;
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if (_txtJPEG2000.Text == "")
         {
            Messager.ShowError(this, "Please set the Jpeg2000 file");
            return;
         }

         if (_txtSecond.Text == "")
         {
            Messager.ShowError(this, "Please set the Data file");
            return;
         }

         using (WaitCursor wait = new WaitCursor())
         {
            try
            {
               AppendCommonStructure temp = new AppendCommonStructure();
               if (ShowFilterType)
               {
                  switch (_cbFilterType.SelectedIndex)
                  {
                     case 0: temp.type.Id = pGZIP; break;
                     case 1: temp.type.Id = pDES; break;
                  }
               }

               temp.data = File.ReadAllBytes(_txtSecond.Text);
               AppendCommonData = temp;
               this.DialogResult = DialogResult.OK;
               this.Close();
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }
   }
}
