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

using Leadtools.ImageProcessing.Color;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the HistogramEqualizeCommand

   public partial class HistogramEqualizeDialog : Form
   {
      private static bool _firstTimer = true;
      private static HistogramEqualizeType _initialColorSpace;
      private HistogramEqualizeCommand _HistogramEqualizeCommand;

      public HistogramEqualizeType ColorSpace;

      public HistogramEqualizeDialog( )
      {
         InitializeComponent();
         _HistogramEqualizeCommand = new HistogramEqualizeCommand(); 
      }

      public HistogramEqualizeCommand HistogramEqualizeCommand
      {
         get
         {
            return _HistogramEqualizeCommand;
         }
         set
         {
            _HistogramEqualizeCommand = value; 
         }

      }
      private void HistogramEqualizeDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            _initialColorSpace = _HistogramEqualizeCommand.Type;
         }

         ColorSpace = _initialColorSpace;

         //Set command default values
         string[] names;
         names = Enum.GetNames(typeof(HistogramEqualizeType));
         foreach (string name in names)
         {
            if(name != "None")
            _cmbColorSpace.Items.Add(name);
         }
         _cmbColorSpace.SelectedIndex = _cmbColorSpace.Items.IndexOf(ColorSpace.ToString());
      }
      public HistogramEqualizeType TranslateType()
      {
         switch (_cmbColorSpace.SelectedIndex)
         {
            case 0:
               return HistogramEqualizeType.Rgb;
            case 1:
               return HistogramEqualizeType.Yuv; 
            case 2:
               return HistogramEqualizeType.Gray; 
            default:
               return HistogramEqualizeType.Rgb;
         }
      }
      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         //Update command values
         ColorSpace = TranslateType();
         _HistogramEqualizeCommand.Type = ColorSpace;  
         _initialColorSpace = ColorSpace;
         this.DialogResult = DialogResult.OK;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
