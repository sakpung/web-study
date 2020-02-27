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
   //will be used for the EmbossCommand

   public partial class EmbossDialog : Form
   {
      private EmbossCommand _EmbossCommand;
      private int _Depth;

      public EmbossDialog()
      {
         InitializeComponent();
         _EmbossCommand = new EmbossCommand();

         //Set command default values
         InitializeUI();
      }

      public EmbossCommand Embosscommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _EmbossCommand;
         }
         set
         {
            _EmbossCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {

         string[] names;
         names = Enum.GetNames(typeof(EmbossCommandDirection));
         foreach (string name in names)
         {
            _cmbDirection.Items.Add(name);
         }
         _cmbDirection.SelectedIndex = _cmbDirection.Items.IndexOf(_EmbossCommand.Direction.ToString());

         _Depth = 500;
         _txbDepth.Text = _Depth.ToString();
      }

      private void UpdateCommand()
      {
         if (_txbDepth.Text != "")
            _EmbossCommand.Depth = Convert.ToInt32(_txbDepth.Text);

         _EmbossCommand.Direction = TranslateDirection();
      }


      public EmbossCommandDirection TranslateDirection()
      {
         switch (_cmbDirection.SelectedIndex)
         {
            case 0:
               return EmbossCommandDirection.North;
            case 1:
               return EmbossCommandDirection.NorthEast;
            case 2:
               return EmbossCommandDirection.East;
            case 3:
               return EmbossCommandDirection.SouthEast;
            case 4:
               return EmbossCommandDirection.South;
            case 5:
               return EmbossCommandDirection.SouthWest;
            case 6:
               return EmbossCommandDirection.West;
            case 7:
               return EmbossCommandDirection.NorthWest;
            default:
               return EmbossCommandDirection.North;
         }
      }

      private void _tbDepth_Scroll(object sender, EventArgs e)
      {
         _txbDepth.Text = _tbDepth.Value.ToString();
      }

      private void _txbDepth_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbDepth.Text = MainForm.IsValidNumber(_txbDepth.Text, 0, 1000);

            int Val = int.Parse(_txbDepth.Text);
            if (Val >= _tbDepth.Minimum && Val <= _tbDepth.Maximum)
               _tbDepth.Value = Val;
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
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }

   }
}
