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
using Leadtools.Demos;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the ChangeHueSaturationIntensityCommand
   public partial class ChangeHueSaturationIntensityDialog : Form
   {
      private ChangeHueSaturationIntensityCommand _ChangeHueSaturationIntensityCommand;
      private ChangeHueSaturationIntensityCommandData[] _changeHSIData = new ChangeHueSaturationIntensityCommandData[6];

      private int _hue, _saturation, _intensity;
      private int _colorHue, _colorSaturation, _colorIntensity;
      private int _innerLow, _innerHigh, _outerLow, _outerHigh;
      private int[] nPosInit = { 0, 0, 0, 0, 359, 90, 180 };
      private int _lastIndex;
      private bool _finished;

      public ChangeHueSaturationIntensityDialog()
      {
         InitializeComponent();
         _ChangeHueSaturationIntensityCommand = new ChangeHueSaturationIntensityCommand();

         //Set command default values
         InitializeUI();
      }

      public ChangeHueSaturationIntensityCommand ChangeHueSaturationIntensityCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ChangeHueSaturationIntensityCommand;
         }
         set
         {
            _ChangeHueSaturationIntensityCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _cmbMask.Items.Add("Master");
         _cmbMask.Items.Add("Color 1");
         _cmbMask.Items.Add("Color 2");
         _cmbMask.Items.Add("Color 3");
         _cmbMask.Items.Add("Color 4");
         _cmbMask.Items.Add("Color 5");
         _cmbMask.Items.Add("Color 6");

         _cmbMask.SelectedIndex = 0;

         _numIntensity.Value = _numHue.Value = _numSaturation.Value = 0;
         _hue = _saturation = _intensity = 0;

         _numOuterLow.Value = _outerLow = nPosInit[3];
         _numOuterHigh.Value = _outerHigh = nPosInit[4];
         _numInnerLow.Value = _innerLow = nPosInit[5];
         _numInnerHigh.Value = _innerHigh = nPosInit[6];

         for (int nCounter = 0; nCounter <= 5; nCounter++)
         {
            _changeHSIData[nCounter] = new ChangeHueSaturationIntensityCommandData();

            _changeHSIData[nCounter].Intensity =
            _changeHSIData[nCounter].Saturation =
            _changeHSIData[nCounter].Hue = 0;

            _changeHSIData[nCounter].OuterLow = nPosInit[3];
            _changeHSIData[nCounter].OuterHigh = nPosInit[4];
            _changeHSIData[nCounter].InnerLow = nPosInit[5];
            _changeHSIData[nCounter].InnerHigh = nPosInit[6];
         }

         _finished = true;
      }

      private void UpdateCommand()
      {
         AssignValues();
         _ChangeHueSaturationIntensityCommand.Hue = _hue * 100;
         _ChangeHueSaturationIntensityCommand.Saturation = _saturation * 10;
         _ChangeHueSaturationIntensityCommand.Intensity = _intensity * 10;
         _ChangeHueSaturationIntensityCommand.Data = (ChangeHueSaturationIntensityCommandData[])_changeHSIData.Clone();
      }

      private void _cmbMask_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetDefaultValues();
      }

      private void SetDefaultValues()
      {
         _finished = false;
         if (_cmbMask.SelectedItem != null)
         {
            if (_cmbMask.SelectedItem.ToString() == "Master")
            {
               _numHue.Value = _hue;
               _numSaturation.Value = _saturation;
               _numIntensity.Value = _intensity;

               _gbInnerRange.Enabled = false;
               _gbOuterRange.Enabled = false;
            }

            if (_cmbMask.SelectedItem.ToString().LastIndexOf("Color") != -1)
            {
               _gbInnerRange.Enabled = true;
               _gbOuterRange.Enabled = true;

               if (_numInnerLow.Value <= _numOuterLow.Value)
               {
                  _numInnerLow.Value = _numOuterLow.Value + 1;
                  return;
               }
               if (_numInnerHigh.Value <= _numInnerLow.Value)
               {
                  _numInnerHigh.Value = _numInnerLow.Value + 1;
                  return;
               }
               _numHue.Value = _changeHSIData[_cmbMask.SelectedIndex - 1].Hue;
               _numSaturation.Value = _changeHSIData[_cmbMask.SelectedIndex - 1].Saturation;
               _numIntensity.Value = _changeHSIData[_cmbMask.SelectedIndex - 1].Intensity;
               _numInnerLow.Value = _changeHSIData[_cmbMask.SelectedIndex - 1].InnerLow;
               _numInnerHigh.Value = _changeHSIData[_cmbMask.SelectedIndex - 1].InnerHigh;
               _numOuterLow.Value = _changeHSIData[_cmbMask.SelectedIndex - 1].OuterLow;
               _numOuterHigh.Value = _changeHSIData[_cmbMask.SelectedIndex - 1].OuterHigh;
            }
            _finished = true;
         }
      }
      private void AssignValues()
      {

         if (_cmbMask.SelectedItem != null)
         {
            if (_finished)
            {
               if (_cmbMask.SelectedItem.ToString() == "Master")
               {
                  _hue = Convert.ToInt32(_numHue.Value);
                  _saturation = Convert.ToInt32(_numSaturation.Value);
                  _intensity = Convert.ToInt32(_numIntensity.Value);

                  _gbInnerRange.Enabled = false;
                  _gbOuterRange.Enabled = false;
               }

               if (_cmbMask.SelectedItem.ToString().LastIndexOf("Color") != -1)
               {
                  _gbInnerRange.Enabled = true;
                  _gbOuterRange.Enabled = true;

                  if (_numInnerLow.Value <= _numOuterLow.Value)
                  {
                     _numInnerLow.Value = _numOuterLow.Value + 1;
                     return;
                  }
                  if (_numInnerHigh.Value <= _numInnerLow.Value)
                  {
                     _numInnerHigh.Value = _numInnerLow.Value + 1;
                     return;
                  }
                  _colorHue = Convert.ToInt32(_numHue.Value);
                  _colorSaturation = Convert.ToInt32(_numSaturation.Value);
                  _colorIntensity = Convert.ToInt32(_numIntensity.Value);
                  _innerLow = Convert.ToInt32(_numInnerLow.Value);
                  _innerHigh = Convert.ToInt32(_numInnerHigh.Value);
                  _outerLow = Convert.ToInt32(_numOuterLow.Value);
                  _outerHigh = Convert.ToInt32(_numOuterHigh.Value);

                  _changeHSIData[_cmbMask.SelectedIndex - 1].Hue = _colorHue;
                  _changeHSIData[_cmbMask.SelectedIndex - 1].Saturation = _colorSaturation;
                  _changeHSIData[_cmbMask.SelectedIndex - 1].Intensity = _colorIntensity;
                  _changeHSIData[_cmbMask.SelectedIndex - 1].InnerLow = _innerLow;
                  _changeHSIData[_cmbMask.SelectedIndex - 1].InnerHigh = _innerHigh;
                  _changeHSIData[_cmbMask.SelectedIndex - 1].OuterLow = _outerLow;
                  _changeHSIData[_cmbMask.SelectedIndex - 1].OuterHigh = _outerHigh;
               }
            }
         }
      }

      private void _numHue_ValueChanged(object sender, EventArgs e)
      {
         _tbHue.Value = Convert.ToInt32(_numHue.Value);
         AssignValues();
      }

      private void _numSaturation_ValueChanged(object sender, EventArgs e)
      {
         _tbSaturation.Value = Convert.ToInt32(_numSaturation.Value);
         AssignValues();
      }

      private void _numIntensity_ValueChanged(object sender, EventArgs e)
      {
         _tbIntensity.Value = Convert.ToInt32(_numIntensity.Value);
         AssignValues();
      }

      private void _numOuterLow_ValueChanged(object sender, EventArgs e)
      {
         _tbOuterLow.Value = Convert.ToInt32(_numOuterLow.Value);
         AssignValues();
      }

      private void _numOuterHigh_ValueChanged(object sender, EventArgs e)
      {
         _tbOuterHigh.Value = Convert.ToInt32(_numOuterHigh.Value);
         AssignValues();
      }

      private void _numInnerLow_ValueChanged(object sender, EventArgs e)
      {
         _tbInnerLow.Value = Convert.ToInt32(_numInnerLow.Value);
         AssignValues();
      }

      private void _numInnerHigh_ValueChanged(object sender, EventArgs e)
      {
         _tbInnerHigh.Value = Convert.ToInt32(_numInnerHigh.Value);
         AssignValues();
      }

      private void _numHue_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         AssignValues();
      }

      private void _numSaturation_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         AssignValues();
      }

      private void _numIntensity_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         AssignValues();
      }

      private void _numOuterLow_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         AssignValues();
      }

      private void _numOuterHigh_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         AssignValues();
      }

      private void _numInnerLow_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         AssignValues();
      }

      private void _numInnerHigh_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         AssignValues();
      }

      private void _tbHue_Scroll(object sender, EventArgs e)
      {
         _numHue.Value = _tbHue.Value;
         AssignValues();
      }

      private void _tbSaturation_Scroll(object sender, EventArgs e)
      {
         _numSaturation.Value = _tbSaturation.Value;
         AssignValues();
      }

      private void _tbIntensity_Scroll(object sender, EventArgs e)
      {
         _numIntensity.Value = _tbIntensity.Value;
         AssignValues();
      }

      private void _tbOuterLow_Scroll(object sender, EventArgs e)
      {
         if (_tbOuterLow.Value <= _tbInnerLow.Value)
         {
            _numOuterLow.Value = _tbOuterLow.Value;
         }
         else
         {
            _tbOuterLow.Value = _tbInnerLow.Value - 1;
            return;
         }


         AssignValues();
      }

      private void _tbOuterHigh_Scroll(object sender, EventArgs e)
      {
         if (_tbOuterHigh.Value > _tbInnerHigh.Value)
            _numOuterHigh.Value = _tbOuterHigh.Value;
         else
         {
            _tbOuterHigh.Value = _tbInnerHigh.Value + 1;
            return;
         }
         AssignValues();
      }

      private void _tbInnerLow_Scroll(object sender, EventArgs e)
      {
         if (_tbInnerLow.Value <= _tbInnerHigh.Value)
         {
            _numInnerLow.Value = _tbInnerLow.Value;
         }
         else
         {
            _tbInnerLow.Value = _tbInnerHigh.Value - 1;
            return;
         }
         AssignValues();
      }

      private void _tbInnerHigh_Scroll(object sender, EventArgs e)
      {
         if (_tbInnerHigh.Value <= _tbOuterHigh.Value)
         {
            _numInnerHigh.Value = _tbInnerHigh.Value;
         }
         else
         {
            _tbInnerHigh.Value = _tbOuterHigh.Value - 1;
            return;
         }

         AssignValues();
      }

      private void _btnok_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }

      private void ChangeHueSaturationIntensityDialog_MouseMove(object sender, MouseEventArgs e)
      {
         _lastIndex = _cmbMask.SelectedIndex;
      }
   }
}
