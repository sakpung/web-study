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
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace DocumentCleanupDemo
{
   public partial class SmoothTextDialog : Form
   {     
      // The SmoothCommand Class is part of the LEAD Document Imaging function group, This class will smooth the bumps and fills in the nicks of a 1-bit black and white image.
      // This dialog will use the SmoothCommand flags that will indicate how this command will process and the SmoothCommand.Length member.
      // The Flags used are:
      // SmoothCommandFlags.FavorLong and SmoothCommandFlags.FavorShort
      // SmoothCommand.Length, this member will be used to set the length of the bump (or nick) to remove (or fill).   

      private SmoothCommand _SmoothCommand = null;

      public SmoothTextDialog()
      {
         InitializeComponent();
         _SmoothCommand = new SmoothCommand();
         InitializeUI();
      }
      public SmoothTextDialog(SmoothCommand SmoothCommand)
      {
         InitializeComponent();
         _SmoothCommand = SmoothCommand;
         InitializeUI();
      }
      public SmoothCommand SmoothCommand
      {
         get
         {
            UpdateCommand();
            return _SmoothCommand;
         }
         set
         {
            _SmoothCommand = value;
            InitializeUI();
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

      private void InitializeUI()
      {
         // Set the behavior of the smoothing process
         _tbLength.Text = _SmoothCommand.Length.ToString();
         if ((_SmoothCommand.Flags & SmoothCommandFlags.FavorLong) == SmoothCommandFlags.FavorLong)
            _rbLong.Checked = true;
         else
            _rbShort.Checked = true;
      }

      private void UpdateCommand()
      {
         // Set the length of the bump (or nick) to remove (or fill).
         if (_tbLength.Text != "")
            _SmoothCommand.Length = Convert.ToInt32(_tbLength.Text);
         _SmoothCommand.Flags = (_rbLong.Checked ? SmoothCommandFlags.FavorLong : SmoothCommandFlags.None);
      }

      bool IsValidNumber(string s, Int32 minVal, Int32 maxVal)
      {
         bool retval = true;
         try
         {
            int x = Int32.Parse(s);
            if (x > maxVal || x < minVal)
               retval = false;
         }
         catch (Exception)
         {
            retval = false;
         }
         return retval;
      }

      private void _tbLength_TextChanged(object sender, EventArgs e)
      {
         _tbLength.Text = MainForm.IsValidNumber(_tbLength.Text, 1, 10000);
      }
   }
}
