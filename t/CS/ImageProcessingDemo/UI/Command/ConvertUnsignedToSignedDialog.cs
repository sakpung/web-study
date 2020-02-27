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
   //will be used for the ConvertUnsignedToSignedCommand

   public partial class ConvertUnsignedToSignedDialog : Form
   {
      private ConvertUnsignedToSignedCommand _ConvertUnsignedToSignedCommand;

      public ConvertUnsignedToSignedDialog()
      {
         InitializeComponent();
         _ConvertUnsignedToSignedCommand = new ConvertUnsignedToSignedCommand();

         //Set command default values
         InitializeUI();
      }

      public ConvertUnsignedToSignedCommand ConvertUnsignedToSignedCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ConvertUnsignedToSignedCommand;
         }
         set
         {
            _ConvertUnsignedToSignedCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {

         string[] names;
         names = Enum.GetNames(typeof(ConvertUnsignedToSignedCommandType));
         foreach (string name in names)
         {
            _cmbType.Items.Add(name);
         }
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_ConvertUnsignedToSignedCommand.Type.ToString());
      }

      private void UpdateCommand()
      {
         _ConvertUnsignedToSignedCommand.Type = TranslateType();
      }

      private ConvertUnsignedToSignedCommandType TranslateType()
      {
         switch (_cmbType.SelectedIndex)
         {
            case 0:
               return ConvertUnsignedToSignedCommandType.ProcessRangeOnly;
            case 1:
               return ConvertUnsignedToSignedCommandType.ProcessOutSideRange;
            default:
               return ConvertUnsignedToSignedCommandType.ProcessRangeOnly;

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
