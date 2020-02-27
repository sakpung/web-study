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
using Leadtools.ImageProcessing.Effects;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the EdgeDetectorCommand

   public partial class EdgeDetectorDialog : Form
   {
      private EdgeDetectorCommand _EdgeDetectorCommand;
      private int _Threshold;

      public EdgeDetectorDialog()
      {
         InitializeComponent();
         _EdgeDetectorCommand = new EdgeDetectorCommand();

         //Set command default values
         _Threshold = 60;
         InitializeUI();
      }

      public EdgeDetectorCommand EdgeDetectorCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _EdgeDetectorCommand;
         }
         set
         {
            _EdgeDetectorCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         string[] names;

         names = Enum.GetNames(typeof(EdgeDetectorCommandType));

         foreach (string name in names)
            _cmbFilter.Items.Add(name);

         _cmbFilter.SelectedIndex = 0;

         _txbThreshold.Text = _Threshold.ToString();
      }

      private void UpdateCommand()
      {
         _Threshold = Convert.ToInt32(_txbThreshold.Text);

         _EdgeDetectorCommand.Filter = TranslateFilter();
         _EdgeDetectorCommand.Threshold = _Threshold;
      }

      private EdgeDetectorCommandType TranslateFilter()
      {
         switch (_cmbFilter.SelectedIndex)
         {
            case 0:
               return EdgeDetectorCommandType.SobelVertical;
            case 1:
               return EdgeDetectorCommandType.SobelHorizontal;
            case 2:
               return EdgeDetectorCommandType.SobelBoth;
            case 3:
               return EdgeDetectorCommandType.PrewittVertical;
            case 4:
               return EdgeDetectorCommandType.PrewittHorizontal;
            case 5:
               return EdgeDetectorCommandType.PrewittBoth;
            case 6:
               return EdgeDetectorCommandType.Laplace1;
            case 7:
               return EdgeDetectorCommandType.Laplace2;
            case 8:
               return EdgeDetectorCommandType.Laplace3;
            case 9:
               return EdgeDetectorCommandType.LaplaceDiagonal;
            case 10:
               return EdgeDetectorCommandType.LaplaceHorizontal;
            case 11:
               return EdgeDetectorCommandType.LaplaceVertical;
            case 12:
               return EdgeDetectorCommandType.GradientNorth;
            case 13:
               return EdgeDetectorCommandType.GradientNorthEast;
            case 14:
               return EdgeDetectorCommandType.GradientEast;
            case 15:
               return EdgeDetectorCommandType.GradientSouthEast;
            case 16:
               return EdgeDetectorCommandType.GradientSouth;
            case 17:
               return EdgeDetectorCommandType.GradientSouthWest;
            case 18:
               return EdgeDetectorCommandType.GradientWest;
            case 19:
               return EdgeDetectorCommandType.GradientNorthWest;
            default:
               return EdgeDetectorCommandType.SobelVertical;
         }
      }

      private void _tbThreshold_Scroll(object sender, EventArgs e)
      {
         _txbThreshold.Text = _tbThreshold.Value.ToString();
      }

      private void _txbThreshold_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbThreshold.Text = MainForm.IsValidNumber(_txbThreshold.Text, 0, 255);

            int Val = int.Parse(_txbThreshold.Text);
            if (Val >= _tbThreshold.Minimum && Val <= _tbThreshold.Maximum)
               _tbThreshold.Value = Val;
         }
         catch
         {
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
