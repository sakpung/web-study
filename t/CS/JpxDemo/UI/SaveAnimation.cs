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
   public partial class SaveAnimation : Form
   {
      public SaveAnimation(MainForm  parentMainForm)
      {
         InitializeComponent();

         _parentMainForm = parentMainForm;
         _btnSave.Enabled = false;
      }

      private MainForm _parentMainForm;

      public MainForm ParentMainForm
      {
         get
         {
            return _parentMainForm;
         }
         set
         {
            _parentMainForm = value;
         }
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Filter = "JPX Files(*.jpx)|*.jpx";
         ofd.Title = "Save Animation to file";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtFileName.Text = ofd.FileName;
            _btnSave.Enabled = true;
         }
      }

      private void _btnSave_Click(object sender, EventArgs e)
      {
         if (_txtFileName.Text == "")
         {
            Messager.ShowError(this, "Please select a file");
            return;
         }

         Jpeg2000FileInformation _fileInformation;
         CompositionBox _compositionBox;
         CompositionBoxOptions _compositionBoxOptionsNode;
         InstructionSet _instructionSetNode;
         InstructionSetParameter _instructionSetParameterNode;

         _fileInformation = (Jpeg2000FileInformation) ParentMainForm.Jpeg2000Eng.GetFileInformation(_txtFileName.Text);
         if(_fileInformation.Composition != null)
         {
            Messager.ShowError(this, "This file already has animation information!");
            return;
         }

         _compositionBox = new CompositionBox();
         _compositionBoxOptionsNode = new CompositionBoxOptions();
         _compositionBoxOptionsNode.Height = ParentMainForm.ActiveViewerForm.RenderHeight;
         _compositionBoxOptionsNode.Width = ParentMainForm.ActiveViewerForm.RenderWidth;

         if(ParentMainForm.ActiveViewerForm.LoopAnimation)
            _compositionBoxOptionsNode.Loop = 255;
         else
            _compositionBoxOptionsNode.Loop = 0;
         _compositionBox.CompositionOptions = _compositionBoxOptionsNode;

         _instructionSetNode = new InstructionSet();
         _instructionSetNode.Type = 0x4;//Life Persis, N
         _instructionSetNode.Repetition = _fileInformation.Frame.Length;;
         _instructionSetNode.Tick = 1;

         _instructionSetParameterNode = new InstructionSetParameter();
         _instructionSetParameterNode.Life = ParentMainForm.ActiveViewerForm.AnimationDelay;
         _instructionSetParameterNode.Persist = 0;
         _instructionSetParameterNode.NextUse = 0;
         _instructionSetNode.Instructions.Add(_instructionSetParameterNode);

         _compositionBox.Instructions.Add(_instructionSetNode);

         try
         {
            ParentMainForm.Jpeg2000Eng.AppendBox(_txtFileName.Text, _compositionBox);

            Messager.ShowInformation(this, "Animation settings was saved successfully!");
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }
  }
}
