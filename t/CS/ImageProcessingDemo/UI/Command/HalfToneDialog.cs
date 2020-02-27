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
   //will be used for the HalfToneCommand

   public partial class HalfToneDialog : Form
   {
      private HalfToneCommand _HalfToneCommand;
      private int _Angle, _Dimension;
      public bool UserDefined;

      public HalfToneDialog()
      {
         InitializeComponent();
         _HalfToneCommand = new HalfToneCommand();

         //Set command default values
         _Angle = 0;
         _Dimension = 1;
         UserDefined = false;
         InitializeUI();
      }

      public HalfToneCommand HalfToneCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _HalfToneCommand;
         }
         set
         {
            _HalfToneCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         string[] names;
         names = Enum.GetNames(typeof(HalfToneCommandType));
         foreach (string name in names)
         {
            _cmbType.Items.Add(name);
         }
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_HalfToneCommand.Type.ToString());

         _numDimension.Value = _Dimension;
         _numAngle.Value = _Angle;
      }

      private void UpdateCommand()
      {
         _HalfToneCommand.Angle = Convert.ToInt32(_numAngle.Value);
         _HalfToneCommand.Dimension = Convert.ToInt32(_numDimension.Value);
         _HalfToneCommand.Type = TranslateType();
      }

      public HalfToneCommandType TranslateType()
      {
         switch (_cmbType.SelectedIndex)
         {
            case 0:
               return HalfToneCommandType.Print;
            case 1:
               return HalfToneCommandType.View;
            case 2:
               return HalfToneCommandType.Rectangular;
            case 3:
               return HalfToneCommandType.Circular;
            case 4:
               return HalfToneCommandType.Elliptical;
            case 5:
               return HalfToneCommandType.Random;
            case 6:
               return HalfToneCommandType.Linear;
            case 7:
               return HalfToneCommandType.UserDefined;
            default:
               return HalfToneCommandType.Print;
         }
      }

      private void _tbAngle_Scroll(object sender, EventArgs e)
      {
         _numAngle.Value = _tbAngle.Value;
      }

      private void _tbDimension_Scroll(object sender, EventArgs e)
      {
         _numDimension.Value = _tbDimension.Value;
      }

      private void _cmbType_SelectedIndexChanged(object sender, EventArgs e)
      {
         string str = _cmbType.SelectedItem.ToString();

         if ((str == "Rectangular") | (str == "Circular") | (str == "Random") | (str == "UserDefined"))
            _gbAngle.Enabled = false;
         else
            _gbAngle.Enabled = true;

         if ((str == "View") | (str == "Print"))
            _gbDimension.Enabled = false;
         else
            _gbDimension.Enabled = true;

         if (str == "UserDefined")
            UserDefined = true;
         else
            UserDefined = false;
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

      private void _numAngle_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numDimension_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numAngle_ValueChanged(object sender, EventArgs e)
      {
         _tbAngle.Value = Convert.ToInt32(_numAngle.Value);
      }

      private void _numDimension_ValueChanged(object sender, EventArgs e)
      {
         _tbDimension.Value = Convert.ToInt32(_numDimension.Value);
      }
   }
}
