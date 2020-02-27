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

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
    public partial class LoadPagesDialog : Form
    {
       private MedicalViewer _control;
       private int _maxPagesAllowed;
       private int _pageCount;
       private MainForm _mainForm;

        public LoadPagesDialog()
        {
            InitializeComponent();
        }
        public LoadPagesDialog(MainForm mainForm, MedicalViewer control, int maxPagesAllowed, int pageCount)
        {
           InitializeComponent();
           _control = control;
           _maxPagesAllowed = maxPagesAllowed;
           _pageCount = pageCount;
           _txtFirstPage.MinimumAllowed = 1;
           _txtLastPage.MinimumAllowed = 1;

           _mainForm = mainForm;
           _txtFirstPage.MaximumAllowed = pageCount;
           _txtLastPage.MaximumAllowed = pageCount;

           if (maxPagesAllowed < pageCount)
           {
              _lblLoadPages.Text = "The series you are trying to load consist of " + pageCount + " frames, but your current graphics card can support only up to " + maxPagesAllowed + ". loading all of them will make the VRT and MPR disabled";

              _txtFirstPage.Value = Math.Max(1, Math.Min(pageCount, (pageCount - maxPagesAllowed) / 2 + 1));
              _txtLastPage.Value = Math.Max(1, Math.Min(pageCount, (pageCount + maxPagesAllowed) / 2));
           }
           else
           {
              _lblLoadPages.Text = "This series has " + pageCount + " total pages. Select the pages you want to load:";
              _txtFirstPage.Enabled = false;
              _txtLastPage.Enabled = false;
              _txtFirstPage.Value = 1;
              _txtLastPage.Value = pageCount;
              _chkLoad.Checked = true;
           }
        }

       private void _btnOK_Click(object sender, EventArgs e)
       {
          if (_chkLoad.Checked)
          {
             _mainForm.loadPagesFrom = 1;
             _mainForm.loadPagesTo = _pageCount;
          }
          else
          {
             _mainForm.loadPagesFrom = _txtFirstPage.Value;
             _mainForm.loadPagesTo = _txtLastPage.Value;
          }
    }

       private void _chkLoad_CheckedChanged(object sender, EventArgs e)
       {
          _txtFirstPage.Enabled = !_chkLoad.Checked;
          _txtLastPage.Enabled = !_chkLoad.Checked;
       }
    }
}
