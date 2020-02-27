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
using Leadtools.ImageProcessing.Core;
using Leadtools.Demos;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the AverageCommand

   public partial class BlankPageDetectorDialog : Form
   {
      enum Units
      {
         Pixels,
         Inches,
         Centimeters
      }

      private BlankPageDetectorCommand _BlankPageDetectorCommand;
      private RasterImage RasImage;
      private int _Left, _Top, _Right, _Bottom;
      private Units _unit;

      public BlankPageDetectorDialog()
      {
         InitializeComponent();
         _BlankPageDetectorCommand = new BlankPageDetectorCommand();
         _Left = 1;
         _Top = 1;
         _Right = 1;
         _Bottom = 1;

         _BlankPageDetectorCommand.Flags = BlankPageDetectorCommandFlags.UseAdvanced | BlankPageDetectorCommandFlags.UsePixels;
         _unit = Units.Pixels;

         //Set command default values
         InitializeUI();
      }

      public BlankPageDetectorDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _BlankPageDetectorCommand = new BlankPageDetectorCommand();
         _Left = 1;
         _Top = 1;
         _Right = 1;
         _Bottom = 1;
         RasImage = TempImage;

         _BlankPageDetectorCommand.Flags = BlankPageDetectorCommandFlags.UseAdvanced | BlankPageDetectorCommandFlags.UsePixels;
         _unit = Units.Pixels;
         InitializeUI();
      }

      public BlankPageDetectorCommand BlankPageDetectorcommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _BlankPageDetectorCommand;
         }
         set
         {
            _BlankPageDetectorCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _Left = 1;
         _Top = 1;
         _Right = 1;
         _Bottom = 1;

         _tbLeft.Text = _Left.ToString();
         _tbTop.Text = _Top.ToString();
         _tbRight.Text = _Right.ToString();
         _tbBottom.Text = _Bottom.ToString();

         _chkDetectNoisyPage.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.DetectNoisyPage) == BlankPageDetectorCommandFlags.DetectNoisyPage);
         _chkIgnorBleedThrough.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.UseBleedThrough) == BlankPageDetectorCommandFlags.UseBleedThrough);
         _chkDetectLinedPage.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.DetectLinedPage) == BlankPageDetectorCommandFlags.DetectLinedPage);
         _chkUseActiveArea.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.UseActiveArea) == BlankPageDetectorCommandFlags.UseActiveArea);
         _chkUseDefaultMargin.Checked = !((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.UseUserMargins) == BlankPageDetectorCommandFlags.UseUserMargins);
         _rdUseCentimeters.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.UseCentimeters) == BlankPageDetectorCommandFlags.UseCentimeters);
         _rdUsePixels.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.UsePixels) == BlankPageDetectorCommandFlags.UsePixels);
         _rdUseInches.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.UseInches) == BlankPageDetectorCommandFlags.UseInches);
         _chkUseAdvanced.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.UseAdvanced) == BlankPageDetectorCommandFlags.UseAdvanced);
         _chkDetectTextOnly.Checked = ((_BlankPageDetectorCommand.Flags & BlankPageDetectorCommandFlags.DetectTextOnly) == BlankPageDetectorCommandFlags.DetectTextOnly);
         _chkDetectTextOnly.Enabled = _chkUseAdvanced.Checked;

         if (_rdUsePixels.Checked) _unit = Units.Pixels;
         if (_rdUseInches.Checked) _unit = Units.Inches;
         if (_rdUseCentimeters.Checked) _unit = Units.Centimeters;
      }

      private void UpdateCommand()
      {
         _BlankPageDetectorCommand.Flags = (BlankPageDetectorCommandFlags)0;

         if (_chkUseAdvanced.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.UseAdvanced;
         if (_rdUseCentimeters.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.UseCentimeters;
         if (_rdUseInches.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.UseInches;
         if (_rdUsePixels.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.UsePixels;
         if (_chkDetectNoisyPage.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.DetectNoisyPage;
         if (_chkIgnorBleedThrough.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.UseBleedThrough;
         if (_chkDetectLinedPage.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.DetectLinedPage;
         if (_chkUseActiveArea.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.UseActiveArea;

         if (_chkDetectTextOnly.Checked && _chkUseAdvanced.Checked)
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.DetectTextOnly;

         if (!_chkUseDefaultMargin.Checked)
         {
            _BlankPageDetectorCommand.Flags |= BlankPageDetectorCommandFlags.UseUserMargins;

            _Left = Convert.ToInt32(_tbLeft.Text);
            _Top = Convert.ToInt32(_tbTop.Text);
            _Right = Convert.ToInt32(_tbRight.Text);
            _Bottom = Convert.ToInt32(_tbBottom.Text);

            _BlankPageDetectorCommand.LeftMargin = _Left;
            _BlankPageDetectorCommand.TopMargin = _Top;
            _BlankPageDetectorCommand.RightMargin = _Right;
            _BlankPageDetectorCommand.BottomMargin = _Bottom;
         }
      }

      private void _tbLeft_TextChanged(object sender, EventArgs e)
      {
         _tbLeft.Text = MainForm.IsValidNumber(_tbLeft.Text, 0, Int32.MaxValue);
      }

      private void _tbTop_TextChanged(object sender, EventArgs e)
      {
         _tbTop.Text = MainForm.IsValidNumber(_tbTop.Text, 0, Int32.MaxValue);
      }

      private void _tbRight_TextChanged(object sender, EventArgs e)
      {
         _tbRight.Text = MainForm.IsValidNumber(_tbRight.Text, 0, Int32.MaxValue);
      }

      private void _tbBottom_TextChanged(object sender, EventArgs e)
      {
         _tbBottom.Text = MainForm.IsValidNumber(_tbBottom.Text, 0, Int32.MaxValue);
      }

      private void _btnok_Click(object sender, EventArgs e)
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

      private void _chkUseDefaultMargin_CheckedChanged(object sender, EventArgs e)
      {
         _gbUserMargins.Enabled = !_chkUseDefaultMargin.Checked;
      }

      private void _chkUseAdvanced_CheckedChanged(object sender, EventArgs e)
      {
         _chkDetectTextOnly.Enabled = _chkUseAdvanced.Checked;
      }

      private void UnitCheckedChanged(object sender, EventArgs e)
      {
         if (_rdUsePixels.Checked) _unit = Units.Pixels;
         else if (_rdUseInches.Checked) _unit = Units.Inches;
         else _unit = Units.Centimeters;

         if (_unit == Units.Pixels)
         {
            _lblUnitLeft.Text = "Pixels";
            _lblUnitTop.Text = "Pixels";
            _lblUnitRight.Text = "Pixels";
            _lblUnitBottom.Text = "Pixels";

            _lblUnits.Text = "";
         }
         else
         {
            string unitName = (_unit == Units.Inches) ? "Inch" : "cm";
            _lblUnitLeft.Text = string.Format("1/1000 {0}", unitName);
            _lblUnitTop.Text = string.Format("1/1000 {0}", unitName);
            _lblUnitRight.Text = string.Format("1/1000 {0}", unitName);
            _lblUnitBottom.Text = string.Format("1/1000 {0}", unitName);

            _lblUnits.Text = string.Format("Units of 1/1000 {0} means 1000 is an {0}", unitName.ToLower());
         }
      }
   }
}
