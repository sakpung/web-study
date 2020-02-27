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

using Leadtools.Demos;
using Leadtools.Controls;

namespace ScreenCaptureDemo
{
   public partial class CapturedImageForm : Form
   {
      public CapturedImageForm()
      {
         InitializeComponent();

         InitClass();
      }

      // a raster image viewer that holds the image
      private ImageViewer _viewer;

      // boolean variable to check if the image is saved or not
      private bool _isImageNotSaved;

      // instance of MainForm
      private MainForm _mainForm;

      private void InitClass( )
      {
         // Initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      public bool IsImageNotSaved
      {
         get
         {
            return _isImageNotSaved;
         }
         set
         {
            _isImageNotSaved = value;
         }
      }


      private void CapturedImageForm_Load(object sender, EventArgs e)
      {
         // make sure the viewer interactive mode is set to none
          _viewer.InteractiveModes.Clear();

         // the image is not saved as a start
         _isImageNotSaved = true;

         // get instance of main form
         _mainForm = ParentForm as MainForm;
      }

      private void CapturedImageForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         _mainForm.CountOfOpenedImages--;

         if(_mainForm.CountOfOpenedImages >= 1)
         {
            _mainForm.EnableSaveAs = true;
            _mainForm.EnableCut = true;
            _mainForm.EnableCopy = true;
         }
         else
         {
            _mainForm.EnableSaveAs = false;
            _mainForm.EnableCut = false;
            _mainForm.EnableCopy = false;
         }
      }
   }
}
