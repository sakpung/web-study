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
using Leadtools.Jpeg2000;
using Leadtools.Demos;

namespace JPXDemo
{
   public partial class ExtractFrames : Form
   {
      public ExtractFrames(MainForm mainParentForm)
      {
         InitializeComponent();

         InitClass();

         _mainParentForm = mainParentForm;
      }

      private ExtractFrameStructure _extractFrame;
      private MainForm _mainParentForm;

      private void InitClass()
      {
         _txtFromFrame.Text = "0";
         _txtToFrame.Text = "0";
      }

      private void _btnInputBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtInputFile.Text = ofd.FileName;
         }
      }

      private void _btnOutputBrowse_Click(object sender, EventArgs e)
      {
         SaveFileDialog sfd = new SaveFileDialog();

         sfd.Title = "Save a File";
         sfd.Filter = "All Files (*.*)|*.*";

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            _txtOutputFile.Text = sfd.FileName;
         }
      }

      private void _btnExtract_Click(object sender, EventArgs e)
      {
         if (_txtInputFile.Text == "")
         {
            Messager.ShowError(this, "Please select an input file.");
            return;
         }

         if (_txtOutputFile.Text == "")
         {
            Messager.ShowError(this, "Please select an output file.");
            return;
         }

         if (ExtractFrameProcess())
         {
            Messager.ShowInformation(this, "Frames Extracted Successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private bool ExtractFrameProcess()
      {
         List<int> frames = new List<int>();
         Jpeg2000FileInformation _fileInformation;

         //Get In Jpeg 2000 file name
         _extractFrame.inJPG2FileName = _txtInputFile.Text;

         //Get Out Jpeg 2000 file name
         _extractFrame.outJPG2FileName = _txtOutputFile.Text;

         //Get Frame Index
         _fileInformation = _mainParentForm.Jpeg2000Eng.GetFileInformation(_extractFrame.inJPG2FileName);

         if ((Convert.ToInt32(_txtFromFrame.Text) >= _fileInformation.Frame.Length) || (Convert.ToInt32(_txtToFrame.Text) >= _fileInformation.Frame.Length) || (Convert.ToInt32(_txtToFrame.Text) < Convert.ToInt32(_txtFromFrame.Text)))
         {
            if(_fileInformation.Frame.Length > 1)
               Messager.ShowError(this, string.Format("Frame Index should be between 0 and {0}.", _fileInformation.Frame.Length - 1));
            else if(_fileInformation.Frame.Length == 1)
               Messager.ShowError(this, string.Format("Frame Index should be 0, only one frame is available in this file."));
            else
               Messager.ShowError(this, string.Format("No frame avialable."));
            return false;
         }

         frames = new List<int>();
         for (int index = Convert.ToInt32(_txtFromFrame.Text); index <= Convert.ToInt32(_txtToFrame.Text); index++)
         {
            frames.Add(index);
         }

         try
         {
            _mainParentForm.Jpeg2000Eng.ExtractFrames(_extractFrame.inJPG2FileName, _extractFrame.outJPG2FileName, frames);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         return true;
      }

      private void _txtFromToFrames_TextChanged(object sender, EventArgs e)
      {
         int index = 0;
         string tempString = ((TextBox)sender).Text;

         while (index < tempString.Length)
         {
            if (!Char.IsNumber(tempString[index]))
               tempString = tempString.Remove(index, 1);
            else
               index++;
         }

         if (tempString.Length == 0)
            ((TextBox)sender).Text = "0";
         else
            ((TextBox)sender).Text = tempString;
      }
   }
}
