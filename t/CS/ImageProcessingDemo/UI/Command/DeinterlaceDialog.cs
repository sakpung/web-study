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
   //will be used for the DeinterlaceCommand

   public partial class DeinterlaceDialog : Form
   {
      private DeinterlaceCommand _DeinterlaceCommand;

      public DeinterlaceDialog()
      {
         InitializeComponent();
         _DeinterlaceCommand = new DeinterlaceCommand();

         //Set command default values
         InitializeUI();
      }

      public DeinterlaceCommand DeinterlaceCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _DeinterlaceCommand;
         }
         set
         {
            _DeinterlaceCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {     
         if ((_DeinterlaceCommand.Flags & DeinterlaceCommandFlags.Smooth) == DeinterlaceCommandFlags.Smooth)
            _rbSmooth.Checked = true;
         if ((_DeinterlaceCommand.Flags & DeinterlaceCommandFlags.Normal) == DeinterlaceCommandFlags.Normal)
            _rbNormal.Checked = true;
         if ((_DeinterlaceCommand.Flags & DeinterlaceCommandFlags.Odd) == DeinterlaceCommandFlags.Odd)
            _rbOddLines.Checked = true;
         if ((_DeinterlaceCommand.Flags & DeinterlaceCommandFlags.Even) == DeinterlaceCommandFlags.Even)
            _rbEvenLines.Checked = true;
      }

      private void UpdateCommand()
      {
         _DeinterlaceCommand.Flags = (DeinterlaceCommandFlags)0;
         if (_rbSmooth.Checked)
            _DeinterlaceCommand.Flags |= DeinterlaceCommandFlags.Smooth;
         if (_rbNormal.Checked)
            _DeinterlaceCommand.Flags |= DeinterlaceCommandFlags.Normal;
         if (_rbOddLines.Checked)
            _DeinterlaceCommand.Flags |= DeinterlaceCommandFlags.Odd;
         if (_rbEvenLines.Checked)
            _DeinterlaceCommand.Flags |= DeinterlaceCommandFlags.Even;
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
