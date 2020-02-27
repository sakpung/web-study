// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PDFFormsDemo
{
   public partial class ColorPickerPanel : UserControl
   {
      public ColorPickerPanel()
      {
         InitializeComponent();

         _colorPickerDialog.Color = _colorPanel.BackColor;
      }

      private void _openButton_Click(object sender, EventArgs e)
      {
         _colorPickerDialog.Color = _colorPanel.BackColor;
         if (_colorPickerDialog.ShowDialog() == DialogResult.OK)
         {
            _colorPanel.BackColor = _colorPickerDialog.Color;
         }
      }

      public Color Color
      {
         get
         {
            return _colorPanel.BackColor;
         }
         set
         {
            _colorPanel.BackColor = value;
         }
      }
   }
}
