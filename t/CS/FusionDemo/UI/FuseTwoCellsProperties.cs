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
using Leadtools.MedicalViewer;

namespace FusionDemo
{
   public partial class FuseTwoCellsProperties : Form
   {
      private int _orgCellImagesCount = 0;
      private int _fuCellImagesCount = 0;

      public FuseTwoCellsProperties()
      {
         InitializeComponent();
      }

      public int Start
      {
         get { return (int)_numStart.Value; }
      }

      public int End
      {
         get { return (int)_numEnd.Value; }
      }

      public bool UseBestAligned
      {
         get { return _chkBestAligned.Checked && _chkBestAligned.Enabled; }
      }

      public bool EnableBestAligned
      {
         get { return _chkBestAligned.Enabled; }
         set { _chkBestAligned.Enabled = value; }
      }

      public bool BestAlignedChecked
      {
         get { return _chkBestAligned.Checked; }
         set { _chkBestAligned.Checked = value; }
      }

      public FuseTwoCellsProperties(MedicalViewerMultiCell orgCell, MedicalViewerMultiCell fuCell)
      {
         InitializeComponent();

         _orgCellImagesCount = orgCell.VirtualImage.Count;
         _fuCellImagesCount = fuCell.VirtualImage.Count;

         _numStart.Minimum = 1;
         _numStart.Value = 1;
         _numStart.Maximum = _orgCellImagesCount;

         _numEnd.Minimum = 1;
         _numEnd.Maximum = _orgCellImagesCount;
         _numEnd.Value = Math.Min(_orgCellImagesCount, _fuCellImagesCount);

         _numStart.ValueChanged += new EventHandler(_num_ValueChanged);
         _numEnd.ValueChanged += new EventHandler(_num_ValueChanged);
      }

      ~FuseTwoCellsProperties()
      {
         _numStart.ValueChanged -= new EventHandler(_num_ValueChanged);
         _numEnd.ValueChanged -= new EventHandler(_num_ValueChanged);
      }

      void _num_ValueChanged(object sender, EventArgs e)
      {
         NumericUpDown numberInput = (NumericUpDown)sender;

         if (numberInput == _numStart)
         {
            if (numberInput.Value > _numEnd.Value)
               numberInput.Value = _numEnd.Value;
         }
         else
         {
            if (numberInput.Value < _numStart.Value)
               numberInput.Value = _numStart.Value;
            else if (numberInput.Value - _numStart.Value + 1 > Math.Min(_orgCellImagesCount, _fuCellImagesCount))
               numberInput.Value = Math.Min(Math.Min(_orgCellImagesCount, _fuCellImagesCount) + _numStart.Value - 1, _orgCellImagesCount);
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
