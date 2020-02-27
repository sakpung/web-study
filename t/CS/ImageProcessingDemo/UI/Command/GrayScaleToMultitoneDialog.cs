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
   //will be used for the GrayScaleToMultitoneCommand

   public partial class GrayScaleToMultitoneDialog : Form
   {
      private GrayScaleToMultitoneCommand _GrayScaleToMultitoneCommand;
      private RasterColor[] _Colors;
      public GrayScaleToMultitoneDialog()
      {
         InitializeComponent();
         _GrayScaleToMultitoneCommand = new GrayScaleToMultitoneCommand();

         //Set command default values
         InitializeUI();
      }

      public GrayScaleToMultitoneCommand GrayScaleToMultitoneCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _GrayScaleToMultitoneCommand; 
         }
         set
         {
            _GrayScaleToMultitoneCommand = value;
            InitializeUI(); 
         }
      }
      private void InitializeUI()
      {
         string[] names;
         names = Enum.GetNames(typeof(GrayScaleToMultitoneCommandToneType));
         foreach (string name in names)
            _cmbChannels.Items.Add(name);         
         _cmbChannels.SelectedIndex = 0;

         names = Enum.GetNames(typeof(GrayScaleToDuotoneCommandMixingType));
         foreach (string name in names)
            _cmbType.Items.Add(name);
         _cmbType.SelectedIndex = 0;
         
      }

      private void UpdateCommand()
      {
         if (_cmbChannels.SelectedItem.ToString() == "Monotone")
         {
            _Colors[0] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor);
         }

         if (_cmbChannels.SelectedItem.ToString() == "Duotone")
         {
            _Colors[0] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor);
            _Colors[1] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor2.BackColor);
         }

         if (_cmbChannels.SelectedItem.ToString() == "Tritone")
         {
            _Colors[0] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor);
            _Colors[1] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor2.BackColor);
            _Colors[2] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor3.BackColor);

         }

         if (_cmbChannels.SelectedItem.ToString() == "Quadtone")
         {
            _Colors[0] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor1.BackColor);
            _Colors[1] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor2.BackColor);
            _Colors[2] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor3.BackColor);
            _Colors[3] = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor4.BackColor);
         }

         _GrayScaleToMultitoneCommand.Colors = _Colors;
         _GrayScaleToMultitoneCommand.Type = TranslateType();
         _GrayScaleToMultitoneCommand.Tone = TranslateChannels();
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

      public GrayScaleToMultitoneCommandToneType TranslateChannels()
      {
         switch (_cmbChannels.SelectedIndex)
         {
            case 0:
               return GrayScaleToMultitoneCommandToneType.Monotone;  
            case 1:
               return GrayScaleToMultitoneCommandToneType.Duotone;
            case 2:
               return GrayScaleToMultitoneCommandToneType.Tritone;  
            case 3:
               return GrayScaleToMultitoneCommandToneType.Quadtone;    
            default:
               return GrayScaleToMultitoneCommandToneType.Monotone;
         }
      }

      
      private void _cmbChannels_SelectedIndexChanged(object sender, EventArgs e)
      {
         _Colors = null; 
         _lblColor1.Enabled = false;
         _lblColor2.Enabled = false;
         _lblColor3.Enabled = false;
         _lblColor4.Enabled = false;

         if (_cmbChannels.SelectedItem.ToString() == "Monotone")
         {
            _Colors = new RasterColor[1];
            
            _lblColor1.Enabled = true;
            
            _lblColor1.Visible  = true;
            _lblColor2.Visible = false;
            _lblColor3.Visible = false;
            _lblColor4.Visible = false;
         }

         if (_cmbChannels.SelectedItem.ToString() == "Duotone")
         {
            _Colors = new RasterColor[2];
            
            _lblColor1.Enabled = true;
            _lblColor2.Enabled = true;
            
            _lblColor1.Visible = true;
            _lblColor2.Visible = true;
            _lblColor3.Visible = false;
            _lblColor4.Visible = false;
         }

         if (_cmbChannels.SelectedItem.ToString() == "Tritone")
         {
            _Colors = new RasterColor[3];
            
            _lblColor1.Enabled = true;
            _lblColor2.Enabled = true;
            _lblColor3.Enabled = true;
            
            _lblColor1.Visible = true;
            _lblColor2.Visible = true;
            _lblColor3.Visible = true;
            _lblColor4.Visible = false;
         }

         if (_cmbChannels.SelectedItem.ToString() == "Quadtone")
         {
            _Colors = new RasterColor[4];
            _lblColor1.Enabled = true;
            _lblColor2.Enabled = true;
            _lblColor3.Enabled = true;
            _lblColor4.Enabled = true;

            _lblColor1.Visible = true;
            _lblColor2.Visible = true;
            _lblColor3.Visible = true;
            _lblColor4.Visible = true;
         }
      }

      private void _lblColor1_MouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            ColorDialog ColorDlg = new ColorDialog();
            if (ColorDlg.ShowDialog(this) == DialogResult.OK)
               _lblColor1.BackColor = ColorDlg.Color;   
         }
      }

      private void _lblColor2_MouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            ColorDialog ColorDlg = new ColorDialog();
            if (ColorDlg.ShowDialog(this) == DialogResult.OK)
               _lblColor2.BackColor = ColorDlg.Color;
         }
      }

      private void _lblColor3_MouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            ColorDialog ColorDlg = new ColorDialog();
            if (ColorDlg.ShowDialog(this) == DialogResult.OK)
               _lblColor3.BackColor = ColorDlg.Color;
         }
      }

      private void _lblColor4_MouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            ColorDialog ColorDlg = new ColorDialog();
            if (ColorDlg.ShowDialog(this) == DialogResult.OK)
               _lblColor4.BackColor = ColorDlg.Color;
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
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
