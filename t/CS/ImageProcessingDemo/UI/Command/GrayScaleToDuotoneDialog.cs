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
using Leadtools.ImageProcessing.Color;  

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the GrayScaleToDuotoneCommand

   public partial class GrayScaleToDuotoneDialog : Form
   {
      private GrayScaleToDuotoneCommand _GrayScaleToDuotoneCommand;
      private RasterColor _Color;

      public GrayScaleToDuotoneDialog()
      {
         InitializeComponent();
         _GrayScaleToDuotoneCommand = new GrayScaleToDuotoneCommand();

         //Set command default values
         InitializeUI();
 
      }

      public GrayScaleToDuotoneCommand GrayScaleToDuotoneCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _GrayScaleToDuotoneCommand;
         }
         set
         {
            _GrayScaleToDuotoneCommand = value;
            InitializeUI(); 
         }
      }

      private void InitializeUI()
      {
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);

         string[] names;
         names = Enum.GetNames(typeof(GrayScaleToDuotoneCommandMixingType));
         foreach (string name in names)
         {
            if (name != "None")
               _cmbType.Items.Add(name);
         }
         _cmbType.SelectedIndex = 0;
      }

      private void UpdateCommand()
      {
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor.BackColor);
         _GrayScaleToDuotoneCommand.Color = _Color;  
         _GrayScaleToDuotoneCommand.Type = TranslateType();
      }

      public GrayScaleToDuotoneCommandMixingType TranslateType()
      {
         switch (_cmbType.SelectedIndex)
         {
            case 0:
               return GrayScaleToDuotoneCommandMixingType.MixWithOldValue;
            case 1:
               return GrayScaleToDuotoneCommandMixingType.ReplaceOldWithNew;
            default:
               return GrayScaleToDuotoneCommandMixingType.MixWithOldValue;
         }
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         ColorDialog ColorDlg = new ColorDialog();
         if (ColorDlg.ShowDialog(this) == DialogResult.OK)
            _lblColor.BackColor = ColorDlg.Color;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
            this.DialogResult = DialogResult.OK;
            this.Close();
      }
      
      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
