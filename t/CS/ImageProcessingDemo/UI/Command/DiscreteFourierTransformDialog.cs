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

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the DiscreteFourierTransformCommand

   public partial class DiscreteFourierTransformDialog : Form
   {
      private DiscreteFourierTransformCommand _DiscreteFourierTransformCommand;
      private FourierTransformDisplayCommand _FourierTransformDisplayCommand;
      private int _X, _Y, _Width, _Height;

      public DiscreteFourierTransformDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _DiscreteFourierTransformCommand = new DiscreteFourierTransformCommand();
         _FourierTransformDisplayCommand = new FourierTransformDisplayCommand();
         _X = 0;
         _Y = 0;
         _Width = TempImage.Width;
         _Height = TempImage.Height;

         //Set command default values
         InitializeUI();
      }

      public DiscreteFourierTransformCommand DiscreteFourierTransformCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _DiscreteFourierTransformCommand;
         }
         set
         {
            _DiscreteFourierTransformCommand = value;
            InitializeUI();
         }
      }

      public FourierTransformDisplayCommand FourierTransformDisplayCommand
      {
         get
         {
            UpdateCommand();
            return _FourierTransformDisplayCommand;
         }
         set
         {
            _FourierTransformDisplayCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _numX.Maximum = _Width;
         _numX.Value = _X;
         _numY.Maximum = _Height;
         _numY.Value = _Y;
         _numWidth.Maximum = _Width-1;
         _numWidth.Value = _Width - 1;
         _numHeight.Maximum = _Height-1;
         _numHeight.Value = _Height - 1;

         _rbDiscreteFourierTransform.Checked = true;
         _rbClip.Checked = true;
         _rbRed.Checked = true;
         _rbAll.Checked = true;
         _rbMagnitude.Checked = true;
         _rbInsideX.Checked = true;
         _rbInsideY.Checked = true;
         _rbDMagnitude.Checked = true;
         _rbNormal.Checked = true;
      }
      private void UpdateCommand()
      {
         _DiscreteFourierTransformCommand.Flags = (DiscreteFourierTransformCommandFlags)0;
         _FourierTransformDisplayCommand.Flags = (FourierTransformDisplayCommandFlags)0;

         if (_rbDiscreteFourierTransform.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.DiscreteFourierTransform;
         if (_rbInverseDiscreteFourierTransform.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.InverseDiscreteFourierTransform;
         if (_rbClip.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Clip;
         if (_rbScale.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Scale;
         if (_rbRed.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Red;
         if (_rbGreen.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Green;
         if (_rbBlue.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Blue;
         if (_rbGray.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Gray;
         if (_rbAll.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.All;
         if (_rbRange.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Range;
         if (_rbMagnitude.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Magnitude;
         if (_rbPhase.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Phase;
         if (_rbBoth.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.Both;
         if (_rbInsideX.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.InsideX;
         if (_rbOutsideX.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.OutsideX;
         if (_rbInsideY.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.InsideY;
         if (_rbOutsideY.Checked)
            _DiscreteFourierTransformCommand.Flags |= DiscreteFourierTransformCommandFlags.OutsideY;

         _X = Convert.ToInt32(_numX.Value);
         _Y = Convert.ToInt32(_numY.Value);
         _Width = Convert.ToInt32(_numWidth.Value);
         _Height = Convert.ToInt32(_numHeight.Value);

         _DiscreteFourierTransformCommand.Range = new LeadRect(_X, _Y, _Width, _Height);

         if (_rbDMagnitude.Checked)
            _FourierTransformDisplayCommand.Flags |= FourierTransformDisplayCommandFlags.Magnitude;
         if (_rbDPhase.Checked)
            _FourierTransformDisplayCommand.Flags |= FourierTransformDisplayCommandFlags.Phase;
         if (_rbNormal.Checked)
            _FourierTransformDisplayCommand.Flags |= FourierTransformDisplayCommandFlags.Normal;
         if (_rbLogarithm.Checked)
            _FourierTransformDisplayCommand.Flags |= FourierTransformDisplayCommandFlags.Log;
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

      private void _numX_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numY_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numWidth_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numHeight_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }
   }
}
