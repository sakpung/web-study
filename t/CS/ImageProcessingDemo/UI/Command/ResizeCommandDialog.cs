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
using Leadtools.ImageProcessing;
using Leadtools.Demos; 

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the ResizeCommand

   public partial class ResizeCommandDialog : Form
   {
      private ResizeCommand _ResizeCommand;
      private RasterImage RasImage;

      public int ImageWidth;
      public int ImageHeight;

      public ResizeCommandDialog()
      {
         InitializeComponent();
         _ResizeCommand = new ResizeCommand();

         //Set command default values
         InitializeUI();
      }

      public ResizeCommandDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _ResizeCommand = new ResizeCommand();
         RasImage = TempImage;
         InitializeUI();
      }      

      public ResizeCommand ResizeCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ResizeCommand;
         }
         set
         {
            _ResizeCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {

         string[] names;
         names = Enum.GetNames(typeof(RasterSizeFlags));
         foreach (string name in names)
         {
            _cmbResizeType.Items.Add(name);
         }
         _cmbResizeType.SelectedIndex = 0;

         ImageWidth = RasImage.Width;
         ImageHeight = RasImage.Height;

         _numWidth.Value = ImageWidth;
         _numHeight.Value = ImageHeight;
      }

      private void UpdateCommand()
      {
         ImageWidth = Convert.ToInt32(_numWidth.Value);
         ImageHeight = Convert.ToInt32(_numHeight.Value);
         
         _ResizeCommand.Flags = TranslateType();         

      }


      public RasterSizeFlags TranslateType()
      {
         switch (_cmbResizeType.SelectedIndex)
         {
            case 0:
               return RasterSizeFlags.None;  
            case 1:
               return RasterSizeFlags.FavorBlack | RasterSizeFlags.Resample;  
            case 2:
               return RasterSizeFlags.Resample;  
            case 3:
               return RasterSizeFlags.Bicubic;              
            default:
               return RasterSizeFlags.None;  
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }

      private void _cmbResizeType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if(_cmbResizeType.SelectedItem.ToString() == "FavorBlack")
            MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "resx_FavorBlack"));
         }
   }
}
