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

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the FastFourierTransformCommand

   public partial class FastFourierTransformDialog : Form
   {
      private FastFourierTransformCommand _FastFourierTransformCommand;
      private FrequencyFilterCommand _FrequencyFilterCommand;

      public FastFourierTransformDialog()
      {
         InitializeComponent();
         _FastFourierTransformCommand = new FastFourierTransformCommand();
         _FrequencyFilterCommand = new FrequencyFilterCommand();

         //Set command default values
         InitializeUI();
      }

      public FastFourierTransformCommand FastFourierTransformCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _FastFourierTransformCommand;
         }
         set
         {
            _FastFourierTransformCommand = value;
            InitializeUI();
         }
      }

      public FrequencyFilterCommand FrequencyFilterCommand
      {
         get
         {
            UpdateCommand();
            return _FrequencyFilterCommand;
         }
         set
         {
            _FrequencyFilterCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _rbInsideX.Checked = true;
         _rbInsideY.Checked = true;  
         _rbGray.Checked = true;
         _rbBoth.Checked = true;
         _rbScale.Checked = true;

         if ((_FrequencyFilterCommand.Flags & FrequencyFilterCommandFlags.InsideX) == FrequencyFilterCommandFlags.InsideX)
            _rbInsideX.Checked = true;

         if ((_FrequencyFilterCommand.Flags & FrequencyFilterCommandFlags.OutsideX) == FrequencyFilterCommandFlags.OutsideX)
            _rbOutsideX.Checked = true;

         if ((_FrequencyFilterCommand.Flags & FrequencyFilterCommandFlags.InsideY) == FrequencyFilterCommandFlags.InsideY)
            _rbInsideY.Checked = true;

         if ((_FrequencyFilterCommand.Flags & FrequencyFilterCommandFlags.OutsideY) == FrequencyFilterCommandFlags.OutsideY)
            _rbOutsideY.Checked = true;         
  
         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Blue) == FastFourierTransformCommandFlags.Blue)
         {
            _rbBlue.Checked = true;
         }

         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Green) == FastFourierTransformCommandFlags.Green)
         {
            _rbGreen.Checked = true;
         }

         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Gray) == FastFourierTransformCommandFlags.Gray)
         {
            _rbGray.Checked = true;
         }

         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Red) == FastFourierTransformCommandFlags.Red)
         {
            _rbRed.Checked = true;
         }


         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Magnitude) == FastFourierTransformCommandFlags.Magnitude)
         {
            _rbMagnitude.Checked = true;
         }
         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Phase) == FastFourierTransformCommandFlags.Phase)
         {
            _rbPhase.Checked = true;
         }
         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Both) == FastFourierTransformCommandFlags.Both)
         {
            _rbBoth.Checked = true;
         }


         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Clip) == FastFourierTransformCommandFlags.Clip)
         {
            _rbClip.Checked = true;
         }
         if ((_FastFourierTransformCommand.Flags & FastFourierTransformCommandFlags.Scale) == FastFourierTransformCommandFlags.Scale)
         {
            _rbScale.Checked = true;
         }
      }

      private void UpdateCommand()
      {
         _FastFourierTransformCommand.Flags = (FastFourierTransformCommandFlags)0;
         _FrequencyFilterCommand.Flags = (FrequencyFilterCommandFlags)0;

         if (_rbInsideX.Checked)
            _FrequencyFilterCommand.Flags |= FrequencyFilterCommandFlags.InsideX;  
         if(_rbOutsideX.Checked)
            _FrequencyFilterCommand.Flags |= FrequencyFilterCommandFlags.OutsideX;
         if(_rbInsideY.Checked)
            _FrequencyFilterCommand.Flags |= FrequencyFilterCommandFlags.InsideY;
         if(_rbOutsideY.Checked)
            _FrequencyFilterCommand.Flags |= FrequencyFilterCommandFlags.OutsideY;
         if(_rbNoneX.Checked)
            _FrequencyFilterCommand.Flags |= FrequencyFilterCommandFlags.None;
         if (_rbNoneY.Checked)
            _FrequencyFilterCommand.Flags |= FrequencyFilterCommandFlags.None;
  
         if (_rbBlue.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Blue;
         }

         if (_rbGreen.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Green;
         }

         if (_rbGray.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Gray;
         }

         if (_rbRed.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Red;
         }

         if (_rbMagnitude.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Magnitude;
         }

         if (_rbPhase.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Phase;
         }

         if (_rbBoth.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Both;
         }

         if (_rbClip.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Clip;
         }

         if (_rbScale.Checked)
         {
            _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.Scale;
         }

         _FastFourierTransformCommand.Flags |= FastFourierTransformCommandFlags.FastFourierTransform;

      }

      private void _btnOk_Click_1(object sender, EventArgs e)
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
