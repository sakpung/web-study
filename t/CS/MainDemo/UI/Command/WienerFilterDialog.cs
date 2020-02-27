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
using Leadtools;
using Leadtools.ImageProcessing.Core;
using Leadtools.Controls;
using Leadtools.ImageProcessing;

namespace MainDemo
{
   public partial class WienerFilterDialog : Form
   {
      private ImageViewer _viewer;
      private MainDemo.ViewerForm _form;
      private MainDemo.MainForm _mainForm;
      private bool _applied;
      private RasterImage _orgImage;
      private PointSpreadFunctionData _psf;
      private double _nsr = 0.001;
      private double _parameter1 = 5.0;
      private double _parameter2 = 0.8;
      private PreDefinedFilterType _parameter3 = PreDefinedFilterType.GAUSSIAN;

      public WienerFilterDialog(MainDemo.MainForm form, MainDemo.ViewerForm viewer)
      {
         _mainForm = form;
         _form = viewer;
         _viewer = viewer.Viewer;
         InitializeComponent();
      }

      private void WienerFilterDialog_Load(object sender, EventArgs e)
      {
         _applied = false;
         _orgImage = _viewer.Image.Clone();
         _btnApply.Enabled = true;
         _btnReset.Enabled = false;

         Tools.FillComboBoxWithEnum(_cbP3, typeof(PreDefinedFilterType), PreDefinedFilterType.GAUSSIAN);
         _numFirstP.Text = _parameter1.ToString();
         _numSecondP.Text = _parameter2.ToString();
         _numNSR.Text = _nsr.ToString();

         try
         {
            if (_viewer.Floater != null)
            {
               _viewer.Floater.Dispose();
               _viewer.Floater = null;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void ApplyFilter()
      {
         using (WaitCursor wait = new WaitCursor())
         {
            _applied = true;
            _viewer.Image.MakeRegionEmpty();
            try {  _parameter1 = double.Parse(_numFirstP.Text); }
            catch (System.Exception /*ex*/) {  _parameter1 = 5; /* default */ _numFirstP.Text = _parameter1.ToString(); }
            try  {  _parameter2 = double.Parse(_numSecondP.Text);   if (_parameter2 < 0)    { _parameter2 = Math.Abs(_parameter2); _numSecondP.Text = _parameter2.ToString();} }
            catch (System.Exception /*ex*/) {  _parameter1 = 0.8; /* default */ _numSecondP.Text = _parameter2.ToString(); }
            try { _nsr = double.Parse(_numNSR.Text); } 
            catch (System.Exception /*ex*/)  {  _nsr = 0.001; /* default */ _numNSR.Text = _nsr.ToString(); }
            _parameter3 = (_cbP3.SelectedIndex == 0) ? PreDefinedFilterType.GAUSSIAN : PreDefinedFilterType.MOTION;

            RasterCommand command;

            command = new PreDefinedFilterCommand(_parameter1, _parameter2, _parameter3);
            try
            {
               command.Run(_viewer.Image);
            }
            catch (System.Exception ex)
            {
               Messager.ShowError(this, ex);
               return;
            }
            _psf = (command as PreDefinedFilterCommand).PSF;

            command = new WienerFilterCommand(_psf, _nsr);
            try
            {
               command.Run(_viewer.Image);
            }
            catch (System.Exception ex)
            {
               Messager.ShowError(this, ex);
               return;
            }
            
            _viewer.Invalidate();
            _form.Invalidate();
            _btnReset.Enabled = true;
            _btnApply.Enabled = false;
         }
      }

      private void _bntApply_Click(object sender, EventArgs e)
      {
         ApplyFilter();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (!_applied)
         {
            ApplyFilter();
         }
         this.Close();
      }

      private void WienerFilterDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _viewer.Invalidate();
         _form.Invalidate();
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         _viewer.Image = _orgImage.Clone();
         _applied = false;
         _btnApply.Enabled = true;
         _btnReset.Enabled = false;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         if (_applied)
         {
            _viewer.Image = _orgImage.Clone();
         }
         this.Close();
      }

      private void WienerFilter_ChangeLabels(object sender, EventArgs e)
      {
         if (_cbP3.SelectedItem.ToString() == "Gaussian")
         {
            labelP1.Text = "Size";
            labelP2.Text = "Sigma";
         }
         else if (_cbP3.SelectedItem.ToString() == "Motion")
         {
            labelP1.Text = "Length";
            labelP2.Text = "Angle";
         }
      }
   }
}
